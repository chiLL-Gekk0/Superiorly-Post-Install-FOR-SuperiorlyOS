namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_ar = new()
    {
 ["home"]="الرئيسية", ["browsers"]="المتصفحات", ["tools"]="الأدوات", ["tweaking"]="التحسينات", ["troubleshooting"]="استكشاف الأخطاء وإصلاحها" 
    };
    private static readonly Dictionary<string, string> SectionDescs_ar = new()
    {
 ["home"]="مرحباً بك في صندوق الأدوات الخاص بك", ["browsers"]="أدوات وإصلاحات متعلقة بالمتصفحات", ["tools"]="تنزيل الأدوات المحمولة وتشغيلها", ["tweaking"]="تعديلات برامج التشغيل ووحدة معالجة الرسومات والنظام.", ["troubleshooting"]="مفاتيح سريعة وإصلاحات لنظام التشغيل." 
    };
    private static readonly Dictionary<string, string> TabTitles_ar = new()
    {
 ["mainstream"]="شائعة", ["privacy"]="الخصوصية", ["forks"]="التفرعات والمخصصة", ["software"]="البرامج", ["store-downloader"]="أداة تنزيل Microsoft Store", ["utilities"]="الأدوات المساعدة", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="السجل", ["win32"]="Win32Priority", ["powerplans"]="خطط الطاقة", ["connectivity"]="الاتصال", ["devices"]="الأجهزة", ["security"]="الحماية", ["gaming"]="الألعاب", ["ai"]="الذكاء الاصطناعي", ["debloat"]="إزالة الانتفاخ", ["system"]="النظام" , ["telemetry"]="القياس عن بُعد",
["app-privacy"]="خصوصية التطبيقات",
    };
    private static readonly Dictionary<string, string> Notifications_ar = new()
    {
 ["opened"]="تم الفتح - تم التشغيل", ["installed"]="تم التثبيت بنجاح", ["failed"]="فشل التثبيت", ["open_failed"]="فشل الفتح", ["enabled"]="تم التمكين", ["disabled"]="تم التعطيل", ["apply_failed"]="فشل التطبيق", ["applied"]="تم التطبيق" , ["telemetry"]="القياس عن بُعد"
    };
    private static readonly Dictionary<string, string> Ui_ar = new()
    {

            ["settings"]="الإعدادات", ["language"]="اللغة", ["theme"]="النسق", ["dark"]="داكن", ["light"]="فاتح", ["auto"]="تلقائي", ["default_theme"]="النسق الافتراضي",
            ["style"]="النمط", ["win10_style"]="نمط Windows 10", ["win11_style"]="نمط Windows 11", ["close"]="إغلاق",
            ["search_placeholder"]="ابحث بالاسم أو URL أو المعرف.", ["store_no_results"]="لم يتم العثور على نتائج. جرّب بحثاً آخر.", ["search"]="بحث", ["install"]="تثبيت",
            ["run"]="تشغيل", ["download"]="تنزيل", ["open"]="فتح", ["apply"]="تطبيق",
            ["check_updates"]="التحقق من وجود تحديثات", ["update"]="تحديث", ["disclaimer"]="التعديلات مسؤوليتك وحدك.",
            ["quantum_title"]="خريطة الكم", ["quantum_subtitle"]="جميع قيم Win32PrioritySeparation الصالحة. انقر على صف لتطبيقها.",
            ["open_quantum"]="فتح خريطة الكم", ["current_win32"]="قيمة Win32PrioritySeparation الحالية",
            ["load_list"]="تحميل القائمة", ["unload_list"]="إلغاء تحميل القائمة", ["activate"]="تنشيط", ["import"]="استيراد", ["export"]="تصدير",
            ["select_all"]="تحديد الكل", ["unselect_all"]="إلغاء تحديد الكل", ["uninstall"]="إلغاء التثبيت", ["delete"]="حذف",
            ["restore_default"]="استعادة الافتراضي", ["yes"]="نعم", ["no"]="لا",
            ["searching_for"]="جارٍ البحث عن '{0}'...", ["downloading"]="جارٍ تنزيل {0}...", ["starting"]="جارٍ بدء {0}...",
            ["applying"]="جارٍ تطبيق {0}...", ["installing"]="جارٍ تثبيت {0}...",             ["loading"]="جارٍ تحميل {0}...",
            ["reading_plans"]="جارٍ قراءة خطط الطاقة...", ["populating_list"]="جارٍ ملء القائمة...",
            ["apps_found"]="تم العثور على {0} من التطبيقات", ["nothing_found"]="لم يتم العثور على شيء", ["loaded_items"]="تم تحميل {0} من العناصر",
            ["list_unloaded"]="تم إلغاء تحميل القائمة",
            ["exported"]="تم تصدير {0}",
            ["installed_n"]="تم تثبيت {0} من التطبيقات", ["install_failed"]="فشل التثبيت",
            ["failed_admin"]="فشل - قم بالتشغيل كمسؤول أو يلزم إعادة التشغيل", ["failed"]="فشل",
            ["win32_set"]="تم تعيين Win32PrioritySeparation إلى {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_ar = new()
    {
 ["run"]="تشغيل", ["download"]="تنزيل", ["apply"]="تطبيق", ["enable"]="تمكين", ["disable"]="تعطيل", ["search"]="بحث", ["install"]="تثبيت", ["load list"]="تحميل القائمة", ["uninstall"]="إلغاء التثبيت", ["activate"]="تنشيط", ["delete"]="حذف", ["import .pow"]="استيراد .pow", ["default"]="افتراضي", ["custom"]="مخصص", ["full"]="كامل", ["reduced"]="مُصغَّر", ["minimum"]="الحد الأدنى", ["disable mmcss"]="تعطيل MMCSS", ["bypass"]="تجاوز", ["repeater"]="مكرر", ["realtime"]="الوقت الحقيقي", ["high"]="مرتفع", ["abovenormal"]="أعلى من العادي", ["normal"]="عادي", ["belownormal"]="أقل من العادي", ["enhanced"]="محسّن", ["legacy"]="قديم", ["disabled"]="معطّل", ["enabled"]="مُمكَّن", ["alwayson"]="تشغيل دائم", ["alwaysoff"]="إيقاف دائم", ["optin"]="اشتراك", ["optout"]="إلغاء الاشتراك", ["open cru"]="فتح CRU", ["coming soon"]="قريباً", ["safe fivem/minecraft services"]="خدمات FiveM/Minecraft الآمنة", ["kernelos default"]="Superiorly الافتراضي" , ["telemetry"]="القياس عن بُعد"
    };
    private static readonly Dictionary<string, string> TabDescs_ar = new()
    {
 ["mainstream"]="متصفحات يومية.", ["privacy"]="متصفحات مصممة للخصوصية وإخفاء الهوية.", ["forks"]="إصدارات مجتمعية مبنية على Chromium و Firefox.", ["utilities"]="أدوات لتشخيص النظام والعتاد.", ["amd"]="أدوات AMD لوحدات معالجة الرسومات لبرامج التشغيل والتردد والجهد والسجل.", ["nvidia"]="أدوات NVIDIA للتثبيت النظيف والملفات الشخصية وحالات P-States.", ["connectivity"]="إعدادات Wi-Fi و Bluetooth وحد القفز لنقطة الاتصال.", ["devices"]="إصلاحات الطابعة ومدير المهام وإدخال النص.", ["security"]="العزل الأساسي وجدار الحماية وUAC وقائمة برامج التشغيل المحظورة وحماية الذاكرة.", ["gaming"]="خدمات Xbox و Opera GX.", ["ai"]="تصفح Chromium و WebKit مع أولوية الذكاء الاصطناعي.", ["debloat"]="سياسات خصوصية المتصفحات ومفاتيح القياس عن بُعد للمورّدين: Chrome و Edge و Firefox و Office.", ["system"]="إصلاحات برامج التشغيل عبر Windows Update وقائمة ابدأ ولوحة Intel." , ["telemetry"]="مفاتيح القياس عن بُعد والاقتراحات والإعلانات وجمع بيانات المورّدين.",
["app-privacy"]="أذونات التطبيقات وإعدادات الخصوصية.",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_ar = new()
    {
 ["browsers|gaming"]="Opera GX مع محددات مدمجة لوحدة المعالجة المركزية وذاكرة الوصول العشوائي والشبكة.", ["tweaking|gaming"]="خدمات Xbox وخدمات FiveM/Minecraft الآمنة." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_ar = new()
    {
 ["mainstream"]="متصفحات يومية", ["privacy"]="تصفح مجهول", ["forks"]="تفرعات مستقلة", ["utilities"]="أدوات النظام المساعدة", ["amd"]="أدوات Radeon", ["nvidia"]="أدوات GeForce", ["connectivity"]="إعدادات اللاسلكي", ["devices"]="إصلاحات الأجهزة", ["security"]="حماية النظام", ["gaming"]="خدمات الألعاب", ["ai"]="متصفحات الذكاء الاصطناعي", ["debloat"]="تنظيف المتصفح", ["system"]="إصلاحات Windows" , ["telemetry"]="إصلاحات القياس عن بُعد",
["app-privacy"]="خصوصية التطبيقات",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_ar = new()
    {
 ["browsers|gaming"]="متصفح الألعاب"
    };
    private static readonly Dictionary<string, string> UiExtra_ar = new()
    {
["state_on"]="تشغيل", ["state_off"]="إيقاف", 
            ["confirm_delete"]="تأكيد الحذف",
            ["confirm_enable"]="هل تريد تطبيق هذا التغيير؟",
            ["confirm_disable"]="هل تريد إيقاف هذه الحماية؟",
            ["delete_plans"]="هل تريد حذف {0} من خطط الطاقة؟",
            ["cant_delete_active"]="لا يمكن حذف خطة الطاقة النشطة. انتقل إلى خطة أخرى أولاً.",
            ["import_plan"]="استيراد خطة الطاقة", ["export_plan"]="تصدير خطة الطاقة",
            ["ratio"]="النسبة", ["long"]="طويل", ["short"]="قصير", ["fixed"]="ثابت", ["variable"]="متغير", ["boost"]="تعزيز", ["current"]="الحالي",
            ["needs_admin"]="يتطلب هذا الإجراء امتيازات المسؤول.",
            ["restart_driver"]="إعادة تشغيل برنامج تشغيل العرض", ["reset_all"]="إعادة تعيين الكل", ["download_cru"]="تنزيل CRU",
            ["modify_quantum"]="تعديل الكم", ["quantum_length"]="طول الكم", ["quantum_interval"]="الفاصل الكمي",
            ["fix"]="إصلاح", ["preview_hex"]="معاينة سداسي عشري", ["preview_bits"]="معاينة البتات",
            ["minimize"]="تصغير", ["maximize"]="تكبير", ["toggle_theme"]="التبديل بين النسق الفاتح / الداكن",
            ["follow_theme"]="اتباع نسق Windows", ["square"]="زوايا مربعة", ["rounded"]="زوايا مستديرة",
            ["join"]="انضمام", ["follow"]="متابعة", ["visit"]="زيارة", ["copy_link"]="نسخ الرابط", ["copied"]="تم النسخ",
            ["no_profiles_found"]="لم يتم العثور على ملفات شخصية. ضع ملفات .nip في مجلد Nvidia Profiles.",
            ["home_discord_desc"]="مجتمع Superiorly",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0", ["welcome"]="أهلاً بك", ["hero_tagline"]="إلى SUPERIORLY",
            ["security"]="الأمان: ", ["power_plan_filter"]="خطة الطاقة",
            ["theme_changed"]="تم تغيير النسق إلى {0}", ["style_changed"]="تم تغيير النمط إلى {0}",
            ["powerplan_custom"]="مخصص", ["powerplan_restore"]="استعادة الرسمي",
            ["update_available"]="يتوفر التحديث {0}", ["new_update"]="تحديث جديد: {0}", ["up_to_date"]="أنت محدّث", ["update_check_failed"]="تعذر التحقق من وجود تحديثات",
        
    };
}
