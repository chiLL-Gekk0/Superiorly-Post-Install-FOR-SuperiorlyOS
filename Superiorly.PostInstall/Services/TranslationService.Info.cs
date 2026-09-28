namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, Dictionary<string, string>> ActionInfo;

    public static string GetActionInfo(string id, string lang) =>
        ActionInfo.TryGetValue(Normalize(lang), out var d) && d.TryGetValue(id, out var v) ? v : id;
}
