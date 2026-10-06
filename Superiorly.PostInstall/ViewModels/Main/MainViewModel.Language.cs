using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class MainViewModel : ObservableObject {

    // Verified against the cmap of Assets/Fonts/ClimateCrisis-1979.otf:
    // ru, uk, vi, ar, fa, ur, hi, th, bn, zh, zht, ja and ko have glyphs
    // missing from that font (Cyrillic, Arabic, CJK, Thai, Devanagari, Bengali
    // and the Vietnamese Latin Extended Additional subset).
    private static readonly HashSet<string> HeroDisplayFontLocales = new(StringComparer.OrdinalIgnoreCase)
    { "en", "es", "pt-BR", "pt-PT", "de", "fr", "it", "pl", "tr", "id" };

    private void ApplyLanguage(string lang)
    {
        lang = TranslationService.Normalize(lang);
        SettingsTitle = TranslationService.GetUi("settings", lang);
        LanguageLabel = TranslationService.GetUi("language", lang);
        ThemeLabel = TranslationService.GetUi("theme", lang);
        DefaultThemeLabel = TranslationService.GetUi("default_theme", lang);
        StyleLabel = TranslationService.GetUi("style", lang);
        Win10StyleLabel = TranslationService.GetUi("square", lang);
        Win11StyleLabel = TranslationService.GetUi("rounded", lang);
        LightThemeLabel = TranslationService.GetUi("light", lang);
        DarkThemeLabel = TranslationService.GetUi("dark", lang);
        AutoThemeLabel = TranslationService.GetUi("auto", lang);
        CloseLabel = TranslationService.GetUi("close", lang);
        CheckUpdatesLabel = TranslationService.GetUi("check_updates", lang);
        UpdateLabel = TranslationService.GetUi("update", lang);
        UpdateAvailableLabel = HasUpdate && !string.IsNullOrEmpty(_latestVersion) ? string.Format(TranslationService.GetUi("new_update", lang), _latestVersion) : "";
        DisclaimerText = TranslationService.GetUi("disclaimer", lang);
        QuantumTitle = TranslationService.GetUi("quantum_title", lang);
        QuantumSubtitle = TranslationService.GetUi("quantum_subtitle", lang);

        HeroWelcomeText = TranslationService.GetUi("welcome", lang);
        HeroTaglineText = TranslationService.GetUi("hero_tagline", lang);
        HeroFont = HeroDisplayFontLocales.Contains(lang) ? "/Assets/Fonts/#Climate Crisis 1979" : "";
        HeroTaglineBoxHeight = HeroFont.Length > 0 ? 64 : 92;
        ThemeToggleTip = TranslationService.GetUi("toggle_theme", lang);
        YesLabel = TranslationService.GetUi("yes", lang);
        NoLabel = TranslationService.GetUi("no", lang);
        MinimizeLabel = TranslationService.GetUi("minimize", lang);
        MaximizeLabel = TranslationService.GetUi("maximize", lang);

        HomeJoinLabel = TranslationService.GetUi("join", lang);
        HomeFollowLabel = TranslationService.GetUi("follow", lang);
        HomeVisitLabel = TranslationService.GetUi("visit", lang);
        HomeCopyLinkLabel = TranslationService.GetUi("copy_link", lang);
        HomeDiscordDesc = TranslationService.GetUi("home_discord_desc", lang);
        HomeInstagramDesc = TranslationService.GetUi("home_instagram_desc", lang);
        HomeGithubDesc = TranslationService.GetUi("home_github_desc", lang);
        OnPropertyChanged(nameof(ThemeToggleGlyph));
    }
}
