namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, Dictionary<string, string>> Ui;

    private static readonly Dictionary<string, Dictionary<string, string>> OptionLabels;

    private static readonly Dictionary<string, Dictionary<string, string>> UiExtra;

    private static readonly Dictionary<string, string> DynamicOptionUi = new()
    {
        ["restart display driver"]="restart_driver", ["reset all"]="reset_all", ["download cru"]="download_cru",
    };

    public static string GetUi(string key, string lang)
    {
        var l = Normalize(lang);
        if (Ui.TryGetValue(l, out var d) && d.TryGetValue(key, out var v)) return v;
        if (UiExtra.TryGetValue(l, out var e) && e.TryGetValue(key, out var w)) return w;
        return key;
    }

    public static string GetOptionLabel(string label, string lang)
    {
        var l = Normalize(lang);
        var t = label.Trim().ToLowerInvariant();
        if (DynamicOptionUi.TryGetValue(t, out var ui)) return GetUi(ui, l);
        if (OptionLabels.TryGetValue(l, out var d) && d.TryGetValue(t, out var v)) return v;
        if (l == "en") return label;
        var technical = new[] { "ms", "mb", "mhz", "0x" };
        foreach (var u in technical)
            if (t.EndsWith(u) || t.EndsWith(" " + u)) return label;
        if (double.TryParse(t.Replace(" ", ""), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out _)) return label;
        return OptionLabels["en"].TryGetValue(t, out var en) ? en : label;
    }
}
