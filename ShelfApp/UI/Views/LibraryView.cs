using ShelfApp.Models;
using ShelfApp.Services;

namespace ShelfApp.UI.Views;

// Library: every book grouped by status, with progress bar and actions.
public class LibraryView : ViewBase
{
    public LibraryView(MainForm app) : base(app)
    {
        var (syncText, syncColor) = App.SyncStatus();
        Add(Ui.Header("Library", right: Ui.Text(syncText, 10.5f, color: syncColor)));

        if (App.Data.Library.Count == 0)
        {
            Add(Ui.Card(children:
            [
                Ui.Text("Your library is empty", 14, FontStyle.Bold),
                Ui.Secondary("Search for a book and press \"Add to library\"."),
                Ui.PrimaryButton("Search books", () => App.ShowSearch()),
            ]));
            return;
        }

        AddSection("Reading", ReadingStatus.Reading);
        AddSection("Finished", ReadingStatus.Finished);
        AddSection("Dropped", ReadingStatus.Dropped);
    }

    private void AddSection(string title, ReadingStatus status)
    {
        var entries = App.Data.Library
            .Where(e => e.Status == status)
            .OrderByDescending(e => e.LastUpdated)
            .ToList();
        if (entries.Count == 0)
            return;

        Add(Ui.Overline($"{title} ({entries.Count})"));
        foreach (var entry in entries)
        {
            var book = BookCatalog.Find(entry.BookId);
            if (book != null)
                Add(EntryCard(entry, book));
        }
    }

    private Control EntryCard(LibraryEntry entry, Book book)
    {
        int inner = Ui.ContentWidth - 32;
        int textWidth = inner - 70;
        int percent = ReadingStats.Percent(entry, book);

        var actions = Ui.Row();
        switch (entry.Status)
        {
            case ReadingStatus.Reading:
                actions.Controls.Add(Ui.PrimaryButton("Log progress", () => App.AskProgress(entry), 150));
                actions.Controls.Add(Ui.SecondaryButton("Mark finished", () => Change(entry, ReadingStatus.Finished), 150));
                actions.Controls.Add(Ui.SecondaryButton("Drop", () => Change(entry, ReadingStatus.Dropped), 100));
                break;
            case ReadingStatus.Dropped:
                actions.Controls.Add(Ui.SecondaryButton("Resume", () => Change(entry, ReadingStatus.Reading), 120));
                break;
        }
        actions.Controls.Add(Ui.LinkButton("Details", () => App.ShowBook(book)));
        actions.Controls.Add(Ui.LinkButton("Remove", () => Remove(entry, book), T.Error));

        return Ui.Card(children:
        [
            Ui.Row(
                Ui.Cover(book, 54, 78),
                Ui.Column(
                    Ui.Text(book.Title, 12, FontStyle.Bold, maxWidth: textWidth),
                    Ui.Secondary(book.Author, maxWidth: textWidth),
                    Ui.Progress(entry.CurrentPage / (double)book.Pages, textWidth),
                    Ui.Secondary($"{percent}% · Page {entry.CurrentPage} of {book.Pages}"))),
            actions,
        ]);
    }

    private void Change(LibraryEntry entry, ReadingStatus status)
    {
        App.SetStatus(entry, status);
        App.RenderCurrent();
    }

    private void Remove(LibraryEntry entry, Book book)
    {
        if (!ConfirmDialog.Ask(this, "Remove book", $"Remove \"{book.Title}\" from your library? Its progress will be lost.", "Remove"))
            return;
        App.RemoveFromLibrary(entry);
        App.RenderCurrent();
    }
}
