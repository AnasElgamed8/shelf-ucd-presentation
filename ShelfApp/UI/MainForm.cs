using System.ComponentModel;
using System.Runtime.InteropServices;
using ShelfApp.Models;
using ShelfApp.Services;
using ShelfApp.UI.Views;

namespace ShelfApp.UI;

// The main window: labelled bottom navigation + one screen at a time.
// It also owns the user's data, so every screen saves through here.
public class MainForm : Form
{
    public UserData Data { get; }
    public BookService Books { get; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string LastSearch { get; set; } = "";
    public HashSet<int> DismissedWarnings { get; } = [];

    private readonly Panel _content = new() { Dock = DockStyle.Fill };
    private readonly Panel _navDivider = new() { Dock = DockStyle.Bottom, Height = 1 };
    private readonly TableLayoutPanel _nav = new() { Dock = DockStyle.Bottom, Height = 72, ColumnCount = 4, RowCount = 1 };
    private readonly Dictionary<string, NavButton> _navButtons = [];

    // Screen = which nav tab is active + how to build the view.
    private record Screen(string Tab, Func<Control> Create);
    private readonly Stack<Screen> _history = new();
    private Screen? _current;

    public MainForm()
    {
        Data = DataStore.Load();
        Books = new BookService(() => !Data.OfflineMode && BookService.HasNetwork());
        Theme.Current = Data.DarkTheme ? Theme.Dark : Theme.Light;

        Text = "Shelf";
        Size = new Size(980, 820);
        MinimumSize = new Size(820, 600);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font(Ui.FontName, 10);

        AddNavButton("Home", "", ShowHome);
        AddNavButton("Search", "", () => ShowSearch());
        AddNavButton("Library", "", ShowLibrary);
        AddNavButton("Profile", "", ShowProfile);

        // Fill first, then the docked bottom bars.
        Controls.Add(_content);
        Controls.Add(_navDivider);
        Controls.Add(_nav);

        ApplyTheme();
        Save(); // syncs on start-up when online

        if (Data.OnboardingDone)
            ShowHome();
        else
            ShowOnboarding();
    }

    private void AddNavButton(string name, string glyph, Action onClick)
    {
        var button = new NavButton(name, glyph);
        button.Click += (_, _) => onClick();
        _nav.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
        _nav.Controls.Add(button);
        _navButtons[name] = button;
    }

    // ---------- Navigation ----------

    public void ShowHome() => ShowTab("Home", () => new HomeView(this));
    public void ShowSearch(string? query = null) => ShowTab("Search", () => new SearchView(this, query ?? LastSearch));
    public void ShowLibrary() => ShowTab("Library", () => new LibraryView(this));
    public void ShowProfile() => ShowTab("Profile", () => new ProfileView(this));
    public void ShowOnboarding() => ShowTab("Onboarding", () => new OnboardingView(this));

    // Detail screens keep the current tab highlighted and support "Back".
    public void ShowBook(Book book) => ShowDetail(() => new BookDetailView(this, book));
    public void ShowOffers(Book book) => ShowDetail(() => new OffersView(this, book));

    private void ShowTab(string tab, Func<Control> create)
    {
        _history.Clear();
        _current = new Screen(tab, create);
        RenderCurrent();
    }

    private void ShowDetail(Func<Control> create)
    {
        if (_current != null)
            _history.Push(_current);
        _current = new Screen(_current?.Tab ?? "Home", create);
        RenderCurrent();
    }

    public void GoBack()
    {
        if (_history.Count == 0)
            return;
        _current = _history.Pop();
        RenderCurrent();
    }

    // Rebuilds the current screen (after data or theme changes).
    public void RenderCurrent()
    {
        if (_current == null)
            return;

        _content.SuspendLayout();
        foreach (var old in _content.Controls.Cast<Control>().ToList())
            old.Dispose();

        var view = _current.Create();
        view.Dock = DockStyle.Fill;
        _content.Controls.Add(view);
        _content.ResumeLayout();

        bool onboarding = _current.Tab == "Onboarding";
        _nav.Visible = !onboarding;
        _navDivider.Visible = !onboarding;
        foreach (var (name, button) in _navButtons)
            button.Active = name == _current.Tab;

        view.SelectNextControl(view, true, true, true, true);
    }

    // ---------- Data ----------

    public void Save()
    {
        if (Data.SyncEnabled && Books.IsOnline)
            Data.LastSynced = DateTime.Now;

        try
        {
            DataStore.Save(Data);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            MessageBox.Show(this, $"Couldn't save your library.\n{ex.Message}", "Shelf",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // Story 2 / Heuristic #1: always show the sync state.
    public (string Text, Color Color) SyncStatus()
    {
        var theme = Theme.Current;
        if (!Data.SyncEnabled)
            return ("Sync off · saved on this PC", theme.TextSecondary);
        if (!Books.IsOnline)
            return ("Offline · saved on this PC, will sync when online", theme.Warning);
        if (Data.LastSynced == null)
            return ("Not synced yet", theme.TextSecondary);
        return ($"● Synced {ReadingStats.TimeAgo(Data.LastSynced.Value, DateTime.Now)}", theme.Success);
    }

    public LibraryEntry? GetEntry(int bookId) => Data.Library.FirstOrDefault(e => e.BookId == bookId);

    public void AddToLibrary(Book book)
    {
        if (GetEntry(book.Id) != null)
            return;
        Data.Library.Add(new LibraryEntry { BookId = book.Id, Status = ReadingStatus.Reading, LastUpdated = DateTime.Now });
        Save();
    }

    public void RemoveFromLibrary(LibraryEntry entry)
    {
        Data.Library.Remove(entry);
        Save();
    }

    public void SetStatus(LibraryEntry entry, ReadingStatus status)
    {
        var book = BookCatalog.Find(entry.BookId);
        entry.Status = status;
        if (status == ReadingStatus.Finished && book != null)
            entry.CurrentPage = book.Pages;
        entry.LastUpdated = DateTime.Now;
        Save();
    }

    // Opens the "Which page are you on?" dialog and saves the answer.
    public void AskProgress(LibraryEntry entry)
    {
        var book = BookCatalog.Find(entry.BookId);
        if (book == null)
            return;

        using var dialog = new ProgressDialog(book, entry.CurrentPage);
        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        entry.CurrentPage = dialog.Page;
        entry.Status = dialog.Page >= book.Pages ? ReadingStatus.Finished : ReadingStatus.Reading;
        entry.LastUpdated = DateTime.Now;
        if (!Data.ReadingDays.Any(d => d.Date == DateTime.Today))
            Data.ReadingDays.Add(DateTime.Today);
        Save();
        RenderCurrent();
    }

    public void ToggleTheme()
    {
        Data.DarkTheme = !Data.DarkTheme;
        Theme.Current = Data.DarkTheme ? Theme.Dark : Theme.Light;
        Save();
        ApplyTheme();
        RenderCurrent();
    }

    public void SignOut()
    {
        Data.OnboardingDone = false;
        Save();
        ShowOnboarding();
    }

    // ---------- Theme ----------

    private void ApplyTheme()
    {
        var theme = Theme.Current;
        BackColor = theme.Background;
        _content.BackColor = theme.Background;
        _nav.BackColor = theme.Background;
        _navDivider.BackColor = theme.Divider;
        foreach (var button in _navButtons.Values)
            button.Invalidate();
        SetDarkTitleBar(Data.DarkTheme);
    }

    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attribute, ref int value, int size);

    private void SetDarkTitleBar(bool dark)
    {
        const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        int value = dark ? 1 : 0;
        DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref value, sizeof(int));
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        Save();
        base.OnFormClosing(e);
    }
}
