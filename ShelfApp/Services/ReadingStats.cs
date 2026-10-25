using ShelfApp.Models;

namespace ShelfApp.Services;

public static class ReadingStats
{
    // Rough estimate used for "Reading Time": about one minute per page.
    public const double MinutesPerPage = 1.0;

    public static int BooksCompleted(UserData data) =>
        data.Library.Count(e => e.Status == ReadingStatus.Finished);

    public static int PagesRead(UserData data) => data.Library.Sum(e => e.CurrentPage);

    public static int HoursRead(UserData data) => (int)Math.Round(PagesRead(data) * MinutesPerPage / 60);

    // Consecutive days with reading, counting back from today
    // (or from yesterday, so the streak isn't "lost" before you read today).
    public static int CurrentStreak(IEnumerable<DateTime> readingDays, DateTime today)
    {
        var days = readingDays.Select(d => d.Date).ToHashSet();
        var day = days.Contains(today.Date) ? today.Date : today.Date.AddDays(-1);

        int streak = 0;
        while (days.Contains(day))
        {
            streak++;
            day = day.AddDays(-1);
        }
        return streak;
    }

    public static int Percent(LibraryEntry entry, Book book) =>
        book.Pages == 0 ? 0 : (int)Math.Round(100.0 * entry.CurrentPage / book.Pages);

    public static string TimeAgo(DateTime time, DateTime now)
    {
        var diff = now - time;
        if (diff.TotalMinutes < 1) return "just now";
        if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes} min ago";
        if (diff.TotalHours < 24) return $"{(int)diff.TotalHours} h ago";
        return $"{(int)diff.TotalDays} days ago";
    }
}
