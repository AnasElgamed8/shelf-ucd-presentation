using ShelfApp.Models;

namespace ShelfApp.Services;

public enum RiskLevel { NotEnoughHistory, Low, Medium, High }

public record DropRisk(RiskLevel Level, string Reason);

// Story 3: warn the reader when a book is likely to be dropped.
// Simple rule: look at books of a similar length in the reader's history
// and check how many of them were dropped.
public static class DropRiskCalculator
{
    public const int MinHistory = 5;
    public const int LongBookPages = 400;

    public static DropRisk Calculate(Book book, IEnumerable<(int Pages, ReadingStatus Status)> history)
    {
        // Books still being read don't tell us anything yet.
        var done = history.Where(h => h.Status != ReadingStatus.Reading).ToList();
        if (done.Count < MinHistory)
            return new DropRisk(RiskLevel.NotEnoughHistory, "Not enough history yet — add more books to see drop risk.");

        bool isLong = book.Pages >= LongBookPages;
        var similar = done.Where(h => h.Pages >= LongBookPages == isLong).ToList();
        string kind = isLong ? $"long ({LongBookPages}+ page)" : "shorter";

        if (similar.Count == 0)
            return new DropRisk(RiskLevel.Low, $"You haven't tried any {kind} books yet.");

        int dropped = similar.Count(h => h.Status == ReadingStatus.Dropped);
        double rate = (double)dropped / similar.Count;

        if (rate >= 0.6)
        {
            string tip = isLong ? " Consider a shorter novel." : "";
            return new DropRisk(RiskLevel.High, $"You dropped {dropped} of {similar.Count} {kind} books.{tip}");
        }
        if (rate >= 0.3)
            return new DropRisk(RiskLevel.Medium, $"You dropped {dropped} of {similar.Count} {kind} books. Maybe read a sample first.");

        return new DropRisk(RiskLevel.Low, $"You finished {similar.Count - dropped} of {similar.Count} {kind} books.");
    }

    // Convenience overload that reads the history straight from the user's library.
    public static DropRisk Calculate(Book book, UserData data) =>
        Calculate(book, data.Library
            .Select(e => (Book: BookCatalog.Find(e.BookId), e.Status))
            .Where(x => x.Book != null && x.Book.Id != book.Id)
            .Select(x => (x.Book!.Pages, x.Status)));
}
