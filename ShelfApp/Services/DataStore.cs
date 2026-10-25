using System.Text.Json;
using ShelfApp.Models;

namespace ShelfApp.Services;

// Saves the user's data as JSON in %AppData%\Shelf.
public static class DataStore
{
    private static readonly string Folder =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Shelf");

    public static readonly string FilePath = Path.Combine(Folder, "shelf-data.json");

    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public static UserData Load()
    {
        if (!File.Exists(FilePath))
            return UserData.CreateSample();

        try
        {
            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<UserData>(json, Options) ?? UserData.CreateSample();
        }
        catch (JsonException)
        {
            // Keep the broken file instead of silently overwriting the user's data.
            File.Copy(FilePath, FilePath + ".broken", overwrite: true);
            return UserData.CreateSample();
        }
    }

    public static void Save(UserData data)
    {
        Directory.CreateDirectory(Folder);

        // Write to a temp file first, so a crash mid-write can't corrupt the real file.
        string temp = FilePath + ".tmp";
        File.WriteAllText(temp, JsonSerializer.Serialize(data, Options));
        File.Move(temp, FilePath, overwrite: true);
    }
}
