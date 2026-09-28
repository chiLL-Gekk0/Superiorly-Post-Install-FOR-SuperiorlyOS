namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, Dictionary<string, string>> TooltipControversy;

    private static readonly Dictionary<string, Dictionary<string, string>> TooltipData;

    public static string GetTooltipControversy(string id, string lang) =>
        TooltipControversy.TryGetValue(Normalize(lang), out var d) && d.TryGetValue(id, out var v) ? v : id;

    public static string GetTooltipData(string id, string lang) =>
        TooltipData.TryGetValue(Normalize(lang), out var d) && d.TryGetValue(id, out var v) ? v : id;
}
