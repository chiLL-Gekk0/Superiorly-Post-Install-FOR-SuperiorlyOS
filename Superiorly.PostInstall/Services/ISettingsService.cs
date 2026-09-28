namespace Superiorly.PostInstall.Services;

public sealed class AppSettings
{
    public string Theme { get; set; } = "light";
    public string Language { get; set; } = "en";
    public string CornerStyle { get; set; } = "win10";
    public double? WindowLeft { get; set; }
    public double? WindowTop { get; set; }
    public double WindowWidth { get; set; } = 1100;
    public double WindowHeight { get; set; } = 720;
    public bool WindowMaximized { get; set; }
}

public interface ISettingsService
{
    AppSettings Load();
    void Save(AppSettings settings);
}
