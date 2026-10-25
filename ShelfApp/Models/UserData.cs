namespace ShelfApp.Models;

public enum ReadingStatus { Reading, Finished, Dropped }

public class LibraryEntry
{
    public int BookId { get; set; }
    public int CurrentPage { get; set; }
    public ReadingStatus Status { get; set; }
    public DateTime LastUpdated { get; set; }
}

// Everything we save to disk for the current user.
public class UserData
{
    public string Name { get; set; } = "Layla Hassan";
    public string Handle { get; set; } = "@layla";
    public DateTime Joined { get; set; } = DateTime.Today;

    public bool OnboardingDone { get; set; }
    public bool SyncEnabled { get; set; } = true;
    public bool DarkTheme { get; set; } = true;

    // Demo switch so we can show the offline / error paths during the presentation.
    public bool OfflineMode { get; set; }

    public List<LibraryEntry> Library { get; set; } = [];
    public List<DateTime> ReadingDays { get; set; } = [];

    public DateTime? LastSynced { get; set; }

    // Sample history based on our proto-persona Layla, so the drop-risk
    // warning has enough data (5+ books) to work on first launch.
    public static UserData CreateSample()
    {
        var now = DateTime.Now;
        var data = new UserData { Joined = new DateTime(2024, 1, 15) };

        data.Library.Add(new LibraryEntry { BookId = 4, CurrentPage = 248, Status = ReadingStatus.Reading, LastUpdated = now.AddMinutes(-2) });
        data.Library.Add(new LibraryEntry { BookId = 3, CurrentPage = 281, Status = ReadingStatus.Finished, LastUpdated = now.AddDays(-6) });
        data.Library.Add(new LibraryEntry { BookId = 2, CurrentPage = 200, Status = ReadingStatus.Finished, LastUpdated = now.AddDays(-20) });
        data.Library.Add(new LibraryEntry { BookId = 9, CurrentPage = 112, Status = ReadingStatus.Finished, LastUpdated = now.AddDays(-35) });
        data.Library.Add(new LibraryEntry { BookId = 8, CurrentPage = 796, Status = ReadingStatus.Finished, LastUpdated = now.AddDays(-60) });
        data.Library.Add(new LibraryEntry { BookId = 5, CurrentPage = 310, Status = ReadingStatus.Dropped, LastUpdated = now.AddDays(-90) });
        data.Library.Add(new LibraryEntry { BookId = 6, CurrentPage = 140, Status = ReadingStatus.Dropped, LastUpdated = now.AddDays(-120) });
        data.Library.Add(new LibraryEntry { BookId = 7, CurrentPage = 205, Status = ReadingStatus.Dropped, LastUpdated = now.AddDays(-150) });

        for (int i = 0; i < 14; i++)
            data.ReadingDays.Add(DateTime.Today.AddDays(-i));

        return data;
    }
}
