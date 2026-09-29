namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, Dictionary<string, string>> TabDescs;

    private static readonly Dictionary<string, Dictionary<string, string>> SectionTabDescs;

    private static readonly Dictionary<string, Dictionary<string, string>> TabBannerTitles;

    private static readonly Dictionary<string, Dictionary<string, string>> SectionTabTitles;

    public static string GetTabDesc(string id, string lang, string? sectionId = null)
    {
        var l = Normalize(lang);
        if (!string.IsNullOrEmpty(sectionId) && SectionTabDescs.TryGetValue(l, out var s) && s.TryGetValue(sectionId + "|" + id, out var v) && !string.IsNullOrEmpty(v)) return v;
        if (TabDescs.TryGetValue(l, out var d) && d.TryGetValue(id, out var w)) return w;
        return "";
    }

    public static string GetTabBannerTitle(string id, string lang, string? sectionId = null)
    {
        var l = Normalize(lang);
        if (!string.IsNullOrEmpty(sectionId) && SectionTabTitles.TryGetValue(l, out var s) && s.TryGetValue(sectionId + "|" + id, out var v) && !string.IsNullOrEmpty(v)) return v;
        if (TabBannerTitles.TryGetValue(l, out var d) && d.TryGetValue(id, out var w)) return w;
        return "";
    }
}
