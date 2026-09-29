using System.Windows;
using Microsoft.Win32;

namespace Superiorly.PostInstall.Services;

// light / dark / auto (auto follows Windows AppsUseLightTheme; live refresh via WM_SETTINGCHANGE)
public sealed class ThemeService : IThemeService
{
    private static readonly Lazy<ResourceDictionary> Light = new(() => new() { Source = new Uri("pack://application:,,,/Themes/Light.xaml") });
    private static readonly Lazy<ResourceDictionary> Dark = new(() => new() { Source = new Uri("pack://application:,,,/Themes/Dark.xaml") });
    private static readonly Lazy<ResourceDictionary> CornersSquare = new(() => new() { Source = new Uri("pack://application:,,,/Themes/CornersSquare.xaml") });
    private static readonly Lazy<ResourceDictionary> CornersRounded = new(() => new() { Source = new Uri("pack://application:,,,/Themes/CornersRounded.xaml") });

    public void Apply(string name)
    {
        name = (name ?? "").ToLowerInvariant();
        if (name != "light" && name != "dark") name = "auto";
        var use = name == "light" ? Light.Value : name == "dark" ? Dark.Value : (SystemUsesLight() ? Light.Value : Dark.Value);
        var dictionaries = Application.Current.Resources.MergedDictionaries;
        if (Light.IsValueCreated) dictionaries.Remove(Light.Value);
        if (Dark.IsValueCreated) dictionaries.Remove(Dark.Value);
        dictionaries.Insert(0, use);
    }

    public void RefreshSystem() => Apply("auto");

    public static bool SystemUsesLight()
    {
        try { return Convert.ToInt32(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1)) != 0; }
        catch { return false; }
    }

    public void ApplyCorners(string style)
    {
        var dictionaries = Application.Current.Resources.MergedDictionaries;
        if (CornersSquare.IsValueCreated) dictionaries.Remove(CornersSquare.Value);
        if (CornersRounded.IsValueCreated) dictionaries.Remove(CornersRounded.Value);
        dictionaries.Insert(0, (style == "win11" ? CornersRounded : CornersSquare).Value);
    }
}
