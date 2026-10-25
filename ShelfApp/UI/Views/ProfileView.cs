using ShelfApp.Models;
using ShelfApp.Services;

namespace ShelfApp.UI.Views;

// Profile v2: fixed stat labels, clear streak, history, settings, ONE Sign Out with confirmation.
public class ProfileView : ViewBase
{
    public ProfileView(MainForm app) : base(app)
    {
        var data = App.Data;
        Add(Ui.Header("Profile"));

        string initials = string.Concat(data.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Take(2).Select(w => w[0]));
        var avatar = new Label
        {
            Text = initials.ToUpper(),
            Size = new Size(96, 96),
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font(Ui.FontName, 22, FontStyle.Bold),
            ForeColor = T.TextPrimary,
            BackColor = T.SurfaceElevated,
            Margin = new Padding(0, 0, 16, 16),
            AccessibleRole = AccessibleRole.Graphic,
        };
        Add(Ui.Row(avatar, Ui.Column(
            Ui.Text(data.Name, 16, FontStyle.Bold),
            Ui.Secondary(data.Handle),
            Ui.Secondary($"Joined {data.Joined:MMM yyyy}"))));

        // 2 x 2 stats grid with correct grammar ("12 books", not "12 Book").
        int half = (Ui.ContentWidth - 16) / 2;
        int streak = ReadingStats.CurrentStreak(data.ReadingDays, DateTime.Today);
        Add(Ui.Row(
            StatCard("Books Completed", ReadingStats.BooksCompleted(data).ToString("N0"), "books", half),
            StatCard("Pages Read", ReadingStats.PagesRead(data).ToString("N0"), "pages", half)));
        Add(Ui.Row(
            StatCard("Reading Time (est.)", $"{ReadingStats.HoursRead(data)}h", "hours", half),
            StatCard("Current Streak", streak.ToString(), streak == 1 ? "day in a row" : "days in a row", half)));

        Add(Ui.Overline("Reading history"));
        foreach (var entry in data.Library.OrderByDescending(e => e.LastUpdated).Take(5))
        {
            var book = BookCatalog.Find(entry.BookId);
            if (book == null)
                continue;
            string status = entry.Status == ReadingStatus.Dropped ? "Dropped" : $"{ReadingStats.Percent(entry, book)}%";
            Add(Ui.SplitRow(
                Ui.Column(Ui.Text(book.Title, 11.5f), Ui.Secondary(book.Author)),
                Ui.Badge(status, T.TextPrimary, T.SurfaceElevated),
                Ui.ContentWidth));
        }

        Add(Ui.Overline("Settings"));
        var (syncText, syncColor) = App.SyncStatus();
        Add(Ui.Card(children:
        [
            Toggle("Sync progress across devices", data.SyncEnabled, on =>
            {
                data.SyncEnabled = on;
                App.Save();
                App.RenderCurrent();
            }),
            Toggle("Offline mode (demo: simulates no connection)", data.OfflineMode, on =>
            {
                data.OfflineMode = on;
                App.Save(); // going back online syncs the pending changes
                App.RenderCurrent();
            }),
            Ui.Text(syncText, 10.5f, color: syncColor),
            Ui.SecondaryButton(data.DarkTheme ? "Theme: Dark (switch to Light)" : "Theme: Light (switch to Dark)", App.ToggleTheme, 320),
            Ui.Secondary($"Data file: {DataStore.FilePath}", 9),
        ]));

        // The only Sign Out in the app, with a confirmation (Heuristic #5: error prevention).
        var signOut = Ui.SecondaryButton("Sign Out", SignOut, Ui.ContentWidth);
        signOut.ForeColor = T.Error;
        signOut.FlatAppearance.BorderColor = T.Error;
        Add(signOut);
    }

    private static Control StatCard(string title, string value, string unit, int width) =>
        Ui.Card(width, children:
        [
            Ui.Secondary(title),
            Ui.Text(value, 24, FontStyle.Bold),
            Ui.Secondary(unit),
        ]);

    private static CheckBox Toggle(string text, bool value, Action<bool> onChange)
    {
        var box = new CheckBox
        {
            Text = text,
            Checked = value,
            AutoSize = true,
            Font = new Font(Ui.FontName, 11),
            ForeColor = T.TextPrimary,
            Margin = new Padding(0, 4, 0, 8),
        };
        box.CheckedChanged += (_, _) => onChange(box.Checked);
        return box;
    }

    private void SignOut()
    {
        if (ConfirmDialog.Ask(this, "Sign out", "Sign out of Shelf? Your library stays saved on this PC.", "Sign Out"))
            App.SignOut();
    }
}
