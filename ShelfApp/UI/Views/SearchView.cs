using ShelfApp.Models;
using ShelfApp.Services;

namespace ShelfApp.UI.Views;

// Search by title, author or ISBN. Handles the "no results" and "network error" paths
// from our user flow — no dead ends, always a way to recover.
public class SearchView : ViewBase
{
    private readonly TextBox _query;
    private readonly FlowLayoutPanel _results;

    public SearchView(MainForm app, string query) : base(app)
    {
        Add(Ui.Header("Search"));

        // Visible label + placeholder (accessibility checklist #5).
        var label = Ui.Text("Search by title, author or ISBN", 10.5f, FontStyle.Bold);
        _query = new TextBox
        {
            Text = query,
            PlaceholderText = "e.g. Crime and Punishment",
            Width = Ui.ContentWidth - 140,
            Font = new Font(Ui.FontName, 14),
            BackColor = T.SurfaceElevated,
            ForeColor = T.TextPrimary,
            BorderStyle = BorderStyle.FixedSingle,
            AccessibleName = "Search by title, author or ISBN",
            Margin = new Padding(0, 8, 8, 8),
        };
        var searchButton = Ui.PrimaryButton("Search", RunSearch, 120);
        _query.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                RunSearch();
            }
        };

        _results = Ui.Column();

        Add(label, Ui.Row(_query, searchButton), _results);

        if (query.Length > 0)
            RunSearch();
        else
            ShowHint();
    }

    private void ShowHint()
    {
        ClearResults();
        _results.Controls.Add(Ui.Secondary("Type a book title, author or ISBN and press Enter."));
        _results.Controls.Add(Ui.LinkButton("Browse all books", BrowseAll));
    }

    private void RunSearch()
    {
        App.LastSearch = _query.Text.Trim();
        if (App.LastSearch.Length == 0)
        {
            ShowHint();
            return;
        }

        try
        {
            ShowBooks(App.Books.Search(App.LastSearch), $"Results for \"{App.LastSearch}\"");
        }
        catch (SellersUnavailableException ex)
        {
            ShowError(ex.Message);
        }
    }

    private void BrowseAll()
    {
        try
        {
            ShowBooks(App.Books.All(), "All books");
        }
        catch (SellersUnavailableException ex)
        {
            ShowError(ex.Message);
        }
    }

    private void ShowBooks(List<Book> books, string title)
    {
        ClearResults();

        if (books.Count == 0)
        {
            ShowError($"No results for \"{App.LastSearch}\". Try a different spelling, search by author, or check your connection.");
            return;
        }

        _results.Controls.Add(Ui.Overline($"{title} ({books.Count})"));
        foreach (var book in books)
            _results.Controls.Add(BookRow(book));
    }

    private Control BookRow(Book book)
    {
        var best = BookService.SortLocalFirst(book.Offers).FirstOrDefault();
        string price = best == null
            ? "No sellers right now"
            : $"From EGP {best.Total:N0} · {(best.IsLocal ? "Local" : "Overseas")}";

        int textWidth = Ui.ContentWidth - 32 - 70 - 170;
        return Ui.Card(children:
        [
            Ui.Row(
                Ui.Cover(book, 54, 78),
                Ui.Column(
                    Ui.Text(book.Title, 12, FontStyle.Bold, maxWidth: textWidth),
                    Ui.Secondary(book.Author, maxWidth: textWidth),
                    Ui.Text(price, 10.5f, color: T.TextPrimary, maxWidth: textWidth)),
                Ui.SecondaryButton("View details", () => App.ShowBook(book), 150)),
        ]);
    }

    // Error card with recovery actions: Retry / Browse all books.
    private void ShowError(string message)
    {
        ClearResults();
        _results.Controls.Add(Ui.Card(background: T.ErrorBg, children:
        [
            Ui.Row(Ui.Icon("", 16, T.Error), Ui.Text(message, 11, maxWidth: Ui.ContentWidth - 80)),
            Ui.Row(
                Ui.PrimaryButton("Retry", RunSearch, 160),
                Ui.SecondaryButton("Browse all books", BrowseAll, 200)),
        ]));
    }

    private void ClearResults()
    {
        foreach (var old in _results.Controls.Cast<Control>().ToList())
            old.Dispose();
    }
}
