namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_fa = new()
    {
 ["home"]="خانه", ["browsers"]="مرورگرها", ["tools"]="ابزارها", ["tweaking"]="بهینه‌سازی", ["troubleshooting"]="عیب‌یابی" 
    };
    private static readonly Dictionary<string, string> SectionDescs_fa = new()
    {
 ["home"]="به جعبه‌ابزار خود خوش آمدید", ["browsers"]="ابزارها و رفع‌اشکال‌های مرتبط با مرورگر", ["tools"]="دانلود و اجرای ابزارهای قابل‌حمل", ["tweaking"]="توییک‌های درایور، GPU و سیستم.", ["troubleshooting"]="کلیدهای سریع و رفع‌اشکال‌های سیستم‌عامل." 
    };
    private static readonly Dictionary<string, string> TabTitles_fa = new()
    {
 ["mainstream"]="رایج", ["privacy"]="حریم خصوصی", ["forks"]="فورک‌ها و سفارشی", ["software"]="نرم‌افزار", ["store-downloader"]="دانلودکننده Microsoft Store", ["utilities"]="ابزارهای کمکی", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="رجیستری", ["win32"]="Win32Priority", ["powerplans"]="طرح‌های انرژی", ["connectivity"]="اتصال‌پذیری", ["devices"]="دستگاه‌ها", ["security"]="حفاظت", ["gaming"]="بازی", ["ai"]="هوش مصنوعی", ["debloat"]="حذف نفخ‌افزار", ["system"]="سیستم" , ["telemetry"]="تله‌متری",
["app-privacy"]="حریم خصوصی برنامه‌ها",
    };
    private static readonly Dictionary<string, string> Notifications_fa = new()
    {
 ["opened"]="باز شد - اجرا شد", ["installed"]="با موفقیت نصب شد", ["failed"]="نصب ناموفق بود", ["open_failed"]="باز کردن ناموفق بود", ["enabled"]="فعال شد", ["disabled"]="غیرفعال شد", ["apply_failed"]="اعمال ناموفق بود", ["applied"]="اعمال شد" , ["telemetry"]="تله‌متری"
    };
    private static readonly Dictionary<string, string> Ui_fa = new()
    {

            ["settings"]="تنظیمات", ["language"]="زبان", ["theme"]="تم", ["dark"]="تیره", ["light"]="روشن", ["auto"]="خودکار", ["default_theme"]="تم پیش‌فرض",
            ["style"]="سبک", ["win10_style"]="سبک Windows 10", ["win11_style"]="سبک Windows 11", ["close"]="بستن",
            ["search_placeholder"]="جستجو با نام، URL یا شناسه.", ["store_no_results"]="نتیجه‌ای یافت نشد. جستجوی دیگری را امتحان کنید.", ["search"]="جستجو", ["install"]="نصب",
            ["run"]="اجرا", ["download"]="دانلود", ["open"]="باز کردن", ["apply"]="اعمال",
            ["check_updates"]="بررسی به‌روزرسانی‌ها", ["update"]="به‌روزرسانی", ["disclaimer"]="مسئولیت تغییرات صرفاً با شماست.",
            ["quantum_title"]="نقشه کوانتوم", ["quantum_subtitle"]="همه مقادیر معتبر Win32PrioritySeparation. برای اعمال روی یک ردیف کلیک کنید.",
            ["open_quantum"]="باز کردن نقشه کوانتوم", ["current_win32"]="Win32PrioritySeparation فعلی",
            ["load_list"]="بارگذاری فهرست", ["unload_list"]="بستن فهرست", ["activate"]="فعال‌سازی", ["import"]="درون‌ریزی", ["export"]="برون‌بری",
            ["select_all"]="انتخاب همه", ["unselect_all"]="لغو انتخاب همه", ["uninstall"]="حذف نصب", ["delete"]="حذف",
            ["restore_default"]="بازگردانی پیش‌فرض", ["yes"]="بله", ["no"]="خیر",
            ["searching_for"]="در حال جستجوی «{0}»...", ["downloading"]="در حال دانلود {0}...", ["starting"]="در حال شروع {0}...",
            ["applying"]="در حال اعمال {0}...", ["installing"]="در حال نصب {0}...",             ["loading"]="در حال بارگذاری {0}...",
            ["reading_plans"]="در حال خواندن طرح‌های انرژی...", ["populating_list"]="در حال تهیه فهرست...",
            ["apps_found"]="{0} برنامه یافت شد", ["nothing_found"]="چیزی یافت نشد", ["loaded_items"]="{0} مورد بارگذاری شد",
            ["list_unloaded"]="فهرست بسته شد",
            ["exported"]="{0} برون‌بری شد",
            ["installed_n"]="{0} برنامه نصب شد", ["install_failed"]="نصب ناموفق بود",
            ["failed_admin"]="ناموفق بود - به‌عنوان مدیر اجرا کنید یا راه‌اندازی مجدد لازم است", ["failed"]="ناموفق بود",
            ["win32_set"]="Win32PrioritySeparation روی {0} تنظیم شد",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_fa = new()
    {
 ["run"]="اجرا", ["download"]="دانلود", ["apply"]="اعمال", ["enable"]="فعال‌سازی", ["disable"]="غیرفعال‌سازی", ["search"]="جستجو", ["install"]="نصب", ["load list"]="بارگذاری فهرست", ["uninstall"]="حذف نصب", ["activate"]="فعال‌سازی", ["delete"]="حذف", ["import .pow"]="درون‌ریزی .pow", ["default"]="پیش‌فرض", ["custom"]="سفارشی", ["full"]="کامل", ["reduced"]="مُصغَّر", ["minimum"]="حداقل", ["disable mmcss"]="غیرفعال‌سازی MMCSS", ["bypass"]="میان‌بر", ["repeater"]="تکرارکننده", ["realtime"]="بلادرنگ", ["high"]="بالا", ["abovenormal"]="بالاتر از عادی", ["normal"]="عادی", ["belownormal"]="پایین‌تر از عادی", ["enhanced"]="بهبودیافته", ["legacy"]="قدیمی", ["disabled"]="غیرفعال", ["enabled"]="فعال", ["alwayson"]="همیشه روشن", ["alwaysoff"]="همیشه خاموش", ["optin"]="فعال‌سازی انتخابی", ["optout"]="غیرفعال‌سازی انتخابی", ["open cru"]="باز کردن CRU", ["coming soon"]="به‌زودی", ["safe fivem/minecraft services"]="سرویس‌های امن FiveM/Minecraft", ["kernelos default"]="پیش‌فرض Superiorly" , ["telemetry"]="تله‌متری"
    };
    private static readonly Dictionary<string, string> TabDescs_fa = new()
    {
 ["mainstream"]="مرورگرهای روزمره.", ["privacy"]="مرورگرهای ساخته‌شده برای حریم خصوصی و ناشناسی.", ["forks"]="بیلدهای اجتماعی مبتنی بر Chromium و Firefox.", ["utilities"]="ابزارهای تشخیص سیستم و سخت‌افزار.", ["amd"]="ابزارهای GPU ساخت AMD برای درایور، کلاک، ولتاژ و رجیستری.", ["nvidia"]="ابزارهای NVIDIA برای نصب تمیز، پروفایل‌ها و P-Stateها.", ["connectivity"]="تنظیمات Wi-Fi، بلوتوث و محدودیت هاپ هات‌اسپات.", ["devices"]="رفع‌اشکال‌های چاپگر، Task Manager و ورودی متن.", ["security"]="ایزولاسیون هسته، فایروال، UAC، فهرست blocked درایورها و محافظت‌های حافظه.", ["gaming"]="سرویس‌های Xbox و Opera GX.", ["ai"]="مرور Chromium، WebKit و مرورگرهای هوش‌مصنوعی‌محور.", ["debloat"]="سیاست‌های حریم خصوصی مرورگر و کلیدهای تله‌متری vendorها: Chrome، Edge، Firefox و Office.", ["system"]="رفع‌اشکال‌های درایور Windows Update، منوی Start و پنل Intel." , ["telemetry"]="کلیدهای تله‌متری، پیشنهادها، تبلیغات و جمع‌آوری داده vendorها.",
["app-privacy"]="دسترسی‌های برنامه‌ها و تنظیمات حریم خصوصی.",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_fa = new()
    {
 ["browsers|gaming"]="Opera GX با محدودکننده‌های داخلی CPU، RAM و شبکه.", ["tweaking|gaming"]="سرویس‌های Xbox و سرویس‌های امن FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_fa = new()
    {
 ["mainstream"]="مرورگرهای روزمره", ["privacy"]="مرور ناشناس", ["forks"]="فورک‌های مستقل", ["utilities"]="ابزارهای سیستمی", ["amd"]="ابزارهای Radeon", ["nvidia"]="ابزارهای GeForce", ["connectivity"]="تنظیمات بی‌سیم", ["devices"]="رفع‌اشکال دستگاه‌ها", ["security"]="محافظت‌های سیستم", ["gaming"]="سرویس‌های بازی", ["ai"]="مرورگرهای هوش مصنوعی", ["debloat"]="حذف نفخ‌افزار مرورگر", ["system"]="رفع‌اشکال‌های Windows" , ["telemetry"]="رفع‌اشکال‌های تله‌متری",
["app-privacy"]="حریم خصوصی برنامه‌ها",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_fa = new()
    {
 ["browsers|gaming"]="مرورگر بازی"
    };
    private static readonly Dictionary<string, string> UiExtra_fa = new()
    {
["state_on"]="روشن", ["state_off"]="خاموش", 
            ["confirm_delete"]="تأیید حذف",
            ["confirm_enable"]="این تغییر اعمال شود؟",
            ["confirm_disable"]="این محافظت خاموش شود؟",
            ["delete_plans"]="{0} طرح انرژی حذف شود؟",
            ["cant_delete_active"]="نمی‌توان طرح انرژی فعال را حذف کرد. ابتدا به طرح دیگری بروید.",
            ["import_plan"]="درون‌ریزی طرح انرژی", ["export_plan"]="برون‌بری طرح انرژی",
            ["ratio"]="نسبت", ["long"]="طولانی", ["short"]="کوتاه", ["fixed"]="ثابت", ["variable"]="متغیر", ["boost"]="بوست", ["current"]="فعلی",
            ["needs_admin"]="این عمل نیاز به دسترسی مدیر دارد.",
            ["restart_driver"]="راه‌اندازی مجدد درایور نمایشگر", ["reset_all"]="بازنشانی همه", ["download_cru"]="دانلود CRU",
            ["modify_quantum"]="تغییر کوانتوم", ["quantum_length"]="طول کوانتوم", ["quantum_interval"]="بازه کوانتوم",
            ["fix"]="رفع‌اشکال", ["preview_hex"]="پیش‌نمایش هگز", ["preview_bits"]="پیش‌نمایش بیت‌ها",
            ["minimize"]="کمینه‌سازی", ["maximize"]="بیشینه‌سازی", ["toggle_theme"]="تغییر تم روشن / تیره",
            ["follow_theme"]="پیروی از تم Windows", ["square"]="گوشه‌های مربع", ["rounded"]="گوشه‌های گرد",
            ["join"]="عضویت", ["follow"]="دنبال کردن", ["visit"]="بازدید", ["copy_link"]="کپی پیوند", ["copied"]="کپی شد",
            ["no_profiles_found"]="پروفایلی یافت نشد. فایل‌های .nip را در پوشه Nvidia Profiles قرار دهید.",
            ["home_discord_desc"]="انجمن Superiorly",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0", ["welcome"]="خوش آمدید", ["hero_tagline"]="به SUPERIORLY",
            ["security"]="امنیت: ", ["power_plan_filter"]="طرح انرژی",
            ["theme_changed"]="تم به {0} تغییر کرد", ["style_changed"]="سبک به {0} تغییر کرد",
            ["powerplan_custom"]="سفارشی", ["powerplan_restore"]="بازگردانی رسمی",
            ["update_available"]="به‌روزرسانی {0} موجود است", ["new_update"]="به‌روزرسانی جدید: {0}", ["up_to_date"]="شما به‌روز هستید", ["update_check_failed"]="بررسی به‌روزرسانی‌ها ممکن نشد",
        
    };
}
