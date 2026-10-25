using ShelfApp.Models;
using ShelfApp.Services;

namespace ShelfApp.UI.Views;

// Home v2: continue reading (progress bar + sync), recommendations with drop risk, stats.
public class HomeView : ViewBase
{
    public HomeView(MainForm app) : base(app)
    {
        // Theme toggle shows a text label, not just a sun icon (Heuristic #6).
        var themeButton = Ui.LinkButton(App.Data.DarkTheme ? "Theme: Dark" : "Theme: Light", App.ToggleTheme);
        themeButton.AccessibleName = $"Theme, currently {(App.Data.DarkTheme ? "dark" : "light")}. Press to switch.";
        Add(Ui.Header("Shelf", right: themeButton));

        Add(ContinueReadingCard());

        Add(Ui.Overline("Recommended for you"));
        Add(Recommendations());

        Add(StatsRow());
    }

    private Control ContinueReadingCard()
    {
        var entry = App.Data.Library
            .Where(e => e.Status == ReadingStatus.Reading)
            .OrderByDescending(e => e.LastUpdated)
            .FirstOrDefault();
        var book = entry == null ? null : BookCatalog.Find(entry.BookId);

        if (entry == null || book == null)
        {
            return Ui.Card(children:
            [
                Ui.Text("Nothing in progress", 14, FontStyle.Bold),
                Ui.Secondary("Search for a book and add it to your library to start tracking."),
                Ui.PrimaryButton("Search books", () => App.ShowSearch()),
            ]);
        }

        int inner = Ui.ContentWidth - 32;
        int percent = ReadingStats.Percent(entry, book);
        var (syncText, syncColor) = App.SyncStatus();

        return Ui.Card(children:
        [
            Ui.Row(
                Ui.Cover(book, 70, 100),
                Ui.Column(Ui.Text(book.Title, 15, FontStyle.Bold, maxWidth: inner - 90), Ui.Secondary(book.Author))),
            Ui.Progress(entry.CurrentPage / (double)book.Pages, inner),
            Ui.SplitRow(
                Ui.Secondary($"{percent}% · Page {entry.CurrentPage} of {book.Pages}"),
                Ui.Text(syncText, 10.5f, color: syncColor),
                inner),
            Ui.PrimaryButton("Continue Reading", () => App.AskProgress(entry)),
        ]);
    }

    private Control Recommendations()
    {
        // Books the reader doesn't have yet.
        var picks = BookCatalog.Books
            .Where(b => App.GetEntry(b.Id) == null)
            .Take(3)
            .ToList();

        if (picks.Count == 0)
            return Ui.Secondary("You've added every book we know about!");

        const int cardWidth = 224;
        var row = Ui.Row();
        foreach (var book in picks)
        {
            var risk = DropRiskCalculator.Calculate(book, App.Data);
            row.Controls.Add(Ui.Card(cardWidth, children:
            [
                Ui.Cover(book, cardWidth - 32, 150),
                Ui.Text(book.Title, 11, FontStyle.Bold, maxWidth: cardWidth - 32),
                Ui.Secondary(book.Author, maxWidth: cardWidth - 32),
                Ui.RiskBadge(risk.Level),
                Ui.SecondaryButton("View details", () => App.ShowBook(book), cardWidth - 32),
            ]));
        }
        return row;
    }

    private Control StatsRow()
    {
        var data = App.Data;
        return Ui.Card(children:
        [
            Ui.Row(
                Stat(ReadingStats.BooksCompleted(data).ToString("N0"), "books"),
                Stat(ReadingStats.PagesRead(data).ToString("N0"), "pages"),
                Stat($"{ReadingStats.HoursRead(data)}h", "hours (est.)")),
        ]);
    }

    private static Control Stat(string value, string label)
    {
        var column = Ui.Column(Ui.Text(value, 22, FontStyle.Bold), Ui.Secondary(label));
        column.MinimumSize = new Size((Ui.ContentWidth - 32) / 3, 0);
        return column;
    }
}
