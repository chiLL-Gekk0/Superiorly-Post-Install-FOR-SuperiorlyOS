namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    public static readonly string[] Supported = ["en", "zh", "es", "ja", "pt", "de", "ru", "fr", "ko", "tr", "pl"];

    public static string Normalize(string? lang) =>
        string.IsNullOrEmpty(lang) ? "en" : Supported.Contains(lang) ? lang : "en";

    // ponytail: "en" is the canonical key set (matches Normalize default); no English prose is hardcoded at call sites
    public static bool HasActionInfo(string id) =>
        ActionInfo.TryGetValue("en", out var d) && d.ContainsKey(id);

    private static string Get(Dictionary<string, Dictionary<string, string>> composite, string id, string lang) =>
        composite.TryGetValue(Normalize(lang), out var d) && d.TryGetValue(id, out var v) ? v
        : composite.TryGetValue("en", out var e) && e.TryGetValue(id, out var w) ? w : id;

    static TranslationService()
    {
        UiExtra = new()
        {
            ["en"] = UiExtra_en,
            ["zh"] = UiExtra_zh,
            ["es"] = UiExtra_es,
            ["ja"] = UiExtra_ja,
            ["pt"] = UiExtra_pt,
            ["de"] = UiExtra_de,
            ["ru"] = UiExtra_ru,
            ["fr"] = UiExtra_fr,
            ["ko"] = UiExtra_ko,
            ["tr"] = UiExtra_tr,
            ["pl"] = UiExtra_pl,
        };
        SectionTabTitles = new()
        {
            ["en"] = SectionTabTitles_en,
            ["fr"] = SectionTabTitles_fr,
            ["ko"] = SectionTabTitles_ko,
            ["tr"] = SectionTabTitles_tr,
            ["pl"] = SectionTabTitles_pl,
        };
        TabBannerTitles = new()
        {
            ["en"] = TabBannerTitles_en,
            ["fr"] = TabBannerTitles_fr,
            ["ko"] = TabBannerTitles_ko,
            ["tr"] = TabBannerTitles_tr,
            ["pl"] = TabBannerTitles_pl,
        };
        SectionTabDescs = new()
        {
            ["en"] = SectionTabDescs_en,
            ["fr"] = SectionTabDescs_fr,
            ["ko"] = SectionTabDescs_ko,
            ["tr"] = SectionTabDescs_tr,
            ["pl"] = SectionTabDescs_pl,
        };
        TabDescs = new()
        {
            ["en"] = TabDescs_en,
            ["es"] = TabDescs_es,
            ["fr"] = TabDescs_fr,
            ["ko"] = TabDescs_ko,
            ["tr"] = TabDescs_tr,
            ["pl"] = TabDescs_pl,
        };
        OptionLabels = new()
        {
            ["en"] = OptionLabels_en,
            ["zh"] = OptionLabels_zh,
            ["es"] = OptionLabels_es,
            ["ja"] = OptionLabels_ja,
            ["pt"] = OptionLabels_pt,
            ["de"] = OptionLabels_de,
            ["ru"] = OptionLabels_ru,
            ["fr"] = OptionLabels_fr,
            ["ko"] = OptionLabels_ko,
            ["tr"] = OptionLabels_tr,
            ["pl"] = OptionLabels_pl,
        };
        Ui = new()
        {
            ["en"] = Ui_en,
            ["zh"] = Ui_zh,
            ["es"] = Ui_es,
            ["ja"] = Ui_ja,
            ["pt"] = Ui_pt,
            ["de"] = Ui_de,
            ["ru"] = Ui_ru,
            ["fr"] = Ui_fr,
            ["ko"] = Ui_ko,
            ["tr"] = Ui_tr,
            ["pl"] = Ui_pl,
        };
        Notifications = new()
        {
            ["en"] = Notifications_en,
            ["zh"] = Notifications_zh,
            ["es"] = Notifications_es,
            ["ja"] = Notifications_ja,
            ["pt"] = Notifications_pt,
            ["de"] = Notifications_de,
            ["ru"] = Notifications_ru,
            ["fr"] = Notifications_fr,
            ["ko"] = Notifications_ko,
            ["tr"] = Notifications_tr,
            ["pl"] = Notifications_pl,
        };
        TabTitles = new()
        {
            ["en"] = TabTitles_en,
            ["zh"] = TabTitles_zh,
            ["es"] = TabTitles_es,
            ["ja"] = TabTitles_ja,
            ["pt"] = TabTitles_pt,
            ["de"] = TabTitles_de,
            ["ru"] = TabTitles_ru,
            ["fr"] = TabTitles_fr,
            ["ko"] = TabTitles_ko,
            ["tr"] = TabTitles_tr,
            ["pl"] = TabTitles_pl,
        };
        SectionDescs = new()
        {
            ["en"] = SectionDescs_en,
            ["zh"] = SectionDescs_zh,
            ["es"] = SectionDescs_es,
            ["ja"] = SectionDescs_ja,
            ["pt"] = SectionDescs_pt,
            ["de"] = SectionDescs_de,
            ["ru"] = SectionDescs_ru,
            ["fr"] = SectionDescs_fr,
            ["ko"] = SectionDescs_ko,
            ["tr"] = SectionDescs_tr,
            ["pl"] = SectionDescs_pl,
        };
        SectionTitles = new()
        {
            ["en"] = SectionTitles_en,
            ["zh"] = SectionTitles_zh,
            ["es"] = SectionTitles_es,
            ["ja"] = SectionTitles_ja,
            ["pt"] = SectionTitles_pt,
            ["de"] = SectionTitles_de,
            ["ru"] = SectionTitles_ru,
            ["fr"] = SectionTitles_fr,
            ["ko"] = SectionTitles_ko,
            ["tr"] = SectionTitles_tr,
            ["pl"] = SectionTitles_pl,
        };
        ActionDescriptions = new()
        {
            ["en"] = ActionDescriptions_en,
            ["zh"] = ActionDescriptions_zh,
            ["es"] = ActionDescriptions_es,
            ["ja"] = ActionDescriptions_ja,
            ["pt"] = ActionDescriptions_pt,
            ["de"] = ActionDescriptions_de,
            ["ru"] = ActionDescriptions_ru,
            ["fr"] = ActionDescriptions_fr,
            ["ko"] = ActionDescriptions_ko,
            ["tr"] = ActionDescriptions_tr,
            ["pl"] = ActionDescriptions_pl,
        };
        ActionTitles = new()
        {
            ["en"] = ActionTitles_en,
            ["zh"] = ActionTitles_zh,
            ["es"] = ActionTitles_es,
            ["ja"] = ActionTitles_ja,
            ["pt"] = ActionTitles_pt,
            ["de"] = ActionTitles_de,
            ["ru"] = ActionTitles_ru,
            ["fr"] = ActionTitles_fr,
            ["ko"] = ActionTitles_ko,
            ["tr"] = ActionTitles_tr,
            ["pl"] = ActionTitles_pl,
        };
        ActionInfo = new()
        {
            ["en"] = ActionInfo_en,
            ["zh"] = ActionInfo_zh,
            ["es"] = ActionInfo_es,
            ["ja"] = ActionInfo_ja,
            ["pt"] = ActionInfo_pt,
            ["de"] = ActionInfo_de,
            ["ru"] = ActionInfo_ru,
            ["fr"] = ActionInfo_fr,
            ["ko"] = ActionInfo_ko,
            ["tr"] = ActionInfo_tr,
            ["pl"] = ActionInfo_pl,
        };
        TooltipData = new()
        {
            ["en"] = TooltipData_en,
            ["zh"] = TooltipData_zh,
            ["es"] = TooltipData_es,
            ["ja"] = TooltipData_ja,
            ["pt"] = TooltipData_pt,
            ["de"] = TooltipData_de,
            ["ru"] = TooltipData_ru,
            ["fr"] = TooltipData_fr,
            ["ko"] = TooltipData_ko,
            ["tr"] = TooltipData_tr,
            ["pl"] = TooltipData_pl,
        };
        TooltipControversy = new()
        {
            ["en"] = TooltipControversy_en,
            ["zh"] = TooltipControversy_zh,
            ["es"] = TooltipControversy_es,
            ["ja"] = TooltipControversy_ja,
            ["pt"] = TooltipControversy_pt,
            ["de"] = TooltipControversy_de,
            ["ru"] = TooltipControversy_ru,
            ["fr"] = TooltipControversy_fr,
            ["ko"] = TooltipControversy_ko,
            ["tr"] = TooltipControversy_tr,
            ["pl"] = TooltipControversy_pl,
        };
    }
}
