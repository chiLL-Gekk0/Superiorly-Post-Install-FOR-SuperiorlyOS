using System.IO;
using System.Text.Json;

namespace Superiorly.PostInstall.Services;

public sealed class JsonSettingsService : ISettingsService
{
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    private static string DirectoryPath =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Superiorly Post-Install");

    private static string FilePath => Path.Combine(DirectoryPath, "settings.json");

    public AppSettings Load()
    {
        if (!File.Exists(FilePath)) return new AppSettings();
        try
        {
            var text = File.ReadAllText(FilePath);
            if (string.IsNullOrWhiteSpace(text)) return new AppSettings();
            return JsonSerializer.Deserialize<AppSettings>(text, Options) ?? new AppSettings();
        }
        catch
        {
            return new AppSettings();
        }
    }

    public void Save(AppSettings settings)
    {
        Directory.CreateDirectory(DirectoryPath);
        using var stream = File.Create(FilePath);
        JsonSerializer.Serialize(stream, settings, Options);
    }
}
