namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, Dictionary<string, string>> TooltipControversy;

    private static readonly Dictionary<string, Dictionary<string, string>> TooltipData;

    public static string GetTooltipControversy(string id, string lang) =>
        Get(TooltipControversy, id, lang);

    public static string GetTooltipData(string id, string lang) =>
        Get(TooltipData, id, lang);
}
