namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, Dictionary<string, string>> SectionTitles;

    private static readonly Dictionary<string, Dictionary<string, string>> SectionDescs;

    private static readonly Dictionary<string, Dictionary<string, string>> TabTitles;

    private static readonly Dictionary<string, Dictionary<string, string>> Notifications;

    public static string GetSectionTitle(string id, string lang) =>
        SectionTitles.TryGetValue(Normalize(lang), out var d) && d.TryGetValue(id, out var v) ? v : id;

    public static string GetSectionDesc(string id, string lang) =>
        SectionDescs.TryGetValue(Normalize(lang), out var d) && d.TryGetValue(id, out var v) ? v : id;

    public static string GetTabTitle(string id, string lang) =>
        TabTitles.TryGetValue(Normalize(lang), out var d) && d.TryGetValue(id, out var v) ? v : id;

    public static string GetNotification(string key, string lang) =>
        Notifications.TryGetValue(Normalize(lang), out var d) && d.TryGetValue(key, out var v) ? v : key;
}
