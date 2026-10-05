namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_ur = new()
    {
 ["home"]="ہوم", ["browsers"]="براؤزرز", ["tools"]="ٹولز", ["tweaking"]="ٹویکنگ", ["troubleshooting"]="خرابیوں کا حل" 
    };
    private static readonly Dictionary<string, string> SectionDescs_ur = new()
    {
 ["home"]="آپ کے ٹول باکس میں خوش آمدید", ["browsers"]="براؤزر سے متعلق یوٹیلیٹیز اور اصلاحات", ["tools"]="پورٹیبل یوٹیلیٹیز ڈاؤن لوڈ اور چلائیں", ["tweaking"]="ڈرائیور، GPU اور سسٹم ٹویکس۔", ["troubleshooting"]="فوری ٹوگلز اور OS اصلاحات۔" 
    };
    private static readonly Dictionary<string, string> TabTitles_ur = new()
    {
 ["mainstream"]="عام", ["privacy"]="رازداری", ["forks"]="فورکس اور کسٹم", ["software"]="سافٹ ویئر", ["store-downloader"]="Microsoft Store ڈاؤنلوڈر", ["utilities"]="یوٹیلیٹیز", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="رجسٹری", ["win32"]="Win32Priority", ["powerplans"]="پاور پلانز", ["connectivity"]="کنیکٹیویٹی", ["devices"]="ڈیوائسز", ["security"]="سیکیورٹی", ["gaming"]="گیمنگ", ["ai"]="مصنوعی ذہانت", ["debloat"]="ڈیبلوٹ", ["system"]="سسٹم" , ["telemetry"]="ٹیلی میٹری",
["app-privacy"]="ایپ پرائیویسی",
    };
    private static readonly Dictionary<string, string> Notifications_ur = new()
    {
 ["opened"]="کھولا گیا - لانچ ہو گیا", ["installed"]="کامیابی سے انسٹال ہو گیا", ["failed"]="انسٹالیشن ناکام ہو گئی", ["open_failed"]="کھولنے میں ناکام", ["enabled"]="فعال", ["disabled"]="غیر فعال", ["apply_failed"]="لاگو کرنے میں ناکام", ["applied"]="لاگو ہو گیا" , ["telemetry"]="ٹیلی میٹری"
    };
    private static readonly Dictionary<string, string> Ui_ur = new()
    {

            ["settings"]="ترتیبات", ["language"]="زبان", ["theme"]="تھیم", ["dark"]="گہرا", ["light"]="ہلکا", ["auto"]="خودکار", ["default_theme"]="ڈیفالٹ تھیم",
            ["style"]="اسٹائل", ["win10_style"]="Windows 10 اسٹائل", ["win11_style"]="Windows 11 اسٹائل", ["close"]="بند کریں",
            ["search_placeholder"]="نام، URL یا ID سے تلاش کریں۔", ["store_no_results"]="کوئی نتیجہ نہیں ملا۔ کوئی اور تلاش آزمائیں۔", ["search"]="تلاش کریں", ["install"]="انسٹال کریں",
            ["run"]="چلائیں", ["download"]="ڈاؤن لوڈ کریں", ["open"]="کھولیں", ["apply"]="لاگو کریں",
            ["check_updates"]="اپ ڈیٹس چیک کریں", ["update"]="اپ ڈیٹ", ["disclaimer"]="تبدیلیاں آپ کی اپنی ذمہ داری ہیں۔",
            ["quantum_title"]="کوانٹم میپ", ["quantum_subtitle"]="Win32PrioritySeparation کی تمام درست اقدار۔ لاگو کرنے کے لیے کسی قطار پر کلک کریں۔",
            ["open_quantum"]="کوانٹم میپ کھولیں", ["current_win32"]="موجودہ Win32PrioritySeparation",
            ["load_list"]="فہرست لوڈ کریں", ["unload_list"]="فہرست ان لوڈ کریں", ["activate"]="فعال کریں", ["import"]="امپورٹ کریں", ["export"]="ایکسپورٹ کریں",
            ["select_all"]="سب منتخب کریں", ["unselect_all"]="سب غیر منتخب کریں", ["uninstall"]="ان انسٹال کریں", ["delete"]="حذف کریں",
            ["restore_default"]="ڈیفالٹ بحال کریں", ["yes"]="جی ہاں", ["no"]="نہیں",
            ["searching_for"]="'{0}' تلاش کیا جا رہا ہے...", ["downloading"]="{0} ڈاؤن لوڈ ہو رہا ہے...", ["starting"]="{0} شروع کیا جا رہا ہے...",
            ["applying"]="{0} لاگو کیا جا رہا ہے...", ["installing"]="{0} انسٹال کیا جا رہا ہے...",             ["loading"]="{0} لوڈ ہو رہا ہے...",
            ["reading_plans"]="پاور پلانز پڑھے جا رہے ہیں...", ["populating_list"]="فہرست تیار کی جا رہی ہے...",
            ["apps_found"]="{0} ایپس ملیں", ["nothing_found"]="کچھ نہیں ملا", ["loaded_items"]="{0} آئٹمز لوڈ ہوئے",
            ["list_unloaded"]="فہرست ان لوڈ ہو گئی",
            ["exported"]="{0} ایکسپورٹ ہو گیا",
            ["installed_n"]="{0} ایپ(s) انسٹال ہو گئیں", ["install_failed"]="انسٹالیشن ناکام ہو گئی",
            ["failed_admin"]="ناکام - بطور ایڈمنسٹریٹر چلائیں یا ریبوٹ درکار ہے", ["failed"]="ناکام",
            ["win32_set"]="Win32PrioritySeparation {0} پر سیٹ ہو گیا",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_ur = new()
    {
 ["run"]="چلائیں", ["download"]="ڈاؤن لوڈ کریں", ["apply"]="لاگو کریں", ["enable"]="فعال کریں", ["disable"]="غیر فعال کریں", ["search"]="تلاش کریں", ["install"]="انسٹال کریں", ["load list"]="فہرست لوڈ کریں", ["uninstall"]="ان انسٹال کریں", ["activate"]="فعال کریں", ["delete"]="حذف کریں", ["import .pow"]=".pow امپورٹ کریں", ["default"]="ڈیفالٹ", ["custom"]="کسٹم", ["minimum"]="کم سے کم", ["disable mmcss"]="MMCSS غیر فعال کریں", ["bypass"]="بائی پاس", ["repeater"]="ریپیٹر", ["realtime"]="ریئل ٹائم", ["high"]="ہائی", ["abovenormal"]="نارمل سے اوپر", ["normal"]="نارمل", ["belownormal"]="نارمل سے نیچے", ["enhanced"]="بہتر", ["legacy"]="لیگیسی", ["disabled"]="غیر فعال", ["enabled"]="فعال", ["alwayson"]="ہمیشہ آن", ["alwaysoff"]="ہمیشہ آف", ["optin"]="آپٹ ان", ["optout"]="آپٹ آؤٹ", ["open cru"]="CRU کھولیں", ["coming soon"]="جلد آ رہا ہے", ["safe fivem/minecraft services"]="محفوظ FiveM/Minecraft سروسز", ["kernelos default"]="Superiorly ڈیفالٹ" , ["telemetry"]="ٹیلی میٹری"
    };
    private static readonly Dictionary<string, string> TabDescs_ur = new()
    {
 ["mainstream"]="روزمرہ کے براؤزرز۔", ["privacy"]="رازداری اور گمنامی کے لیے بنائے گئے براؤزرز۔", ["forks"]="Chromium اور Firefox پر مبنی کمیونٹی بلڈز۔", ["utilities"]="سسٹم اور ہارڈ ویئر کی تشخیص کے ٹولز۔", ["amd"]="AMD GPU ٹولز برائے ڈرائیورز، کلاک، وولٹیج اور رجسٹری۔", ["nvidia"]="NVIDIA ٹولز برائے کلین انسٹال، پروفائلز اور P-States۔", ["connectivity"]="Wi-Fi، Bluetooth اور ہاٹ اسپاٹ ہاپ لمٹ سیٹنگز۔", ["devices"]="پرنٹر، ٹاسک مینیجر اور ٹیکسٹ ان پٹ اصلاحات۔", ["security"]="کور آئسولیشن، فائر وال، UAC، ڈرائیور بلاک لسٹ اور میموری تحفظات۔", ["gaming"]="Xbox سروسز اور Opera GX۔", ["ai"]="Chromium، WebKit اور AI-فرسٹ براؤزنگ۔", ["debloat"]="براؤزر پرائیویسی پالیسیز اور وینڈر ٹیلی میٹری سوئچز: Chrome، Edge، Firefox اور Office۔", ["system"]="Windows Update ڈرائیور، اسٹارٹ مینیو اور Intel پینل اصلاحات۔" , ["telemetry"]="ٹیلی میٹری، تجاویز، اشتہارات اور وینڈر ڈیٹا کلیکشن سوئچز۔",
["app-privacy"]="ایپ اجازتیں اور پرائیویسی سیٹنگز۔",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_ur = new()
    {
 ["browsers|gaming"]="بلٹ ان CPU، RAM اور نیٹ ورک لمٹرز کے ساتھ Opera GX۔", ["tweaking|gaming"]="Xbox سروسز اور FiveM/Minecraft محفوظ سروسز۔" 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_ur = new()
    {
 ["mainstream"]="روزمرہ کے براؤزرز", ["privacy"]="گمنام براؤزنگ", ["forks"]="آزاد فورکس", ["utilities"]="سسٹم یوٹیلیٹیز", ["amd"]="Radeon ٹولز", ["nvidia"]="GeForce ٹولز", ["connectivity"]="وائرلیس سیٹنگز", ["devices"]="ڈیوائس اصلاحات", ["security"]="سسٹم تحفظات", ["gaming"]="گیم سروسز", ["ai"]="AI براؤزرز", ["debloat"]="براؤزر ڈیبلوٹ", ["system"]="Windows اصلاحات" , ["telemetry"]="ٹیلی میٹری اصلاحات",
["app-privacy"]="ایپ پرائیویسی",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_ur = new()
    {
 ["browsers|gaming"]="گیمنگ براؤزر", ["tweaking|gaming"]="گیم سروسز" , ["troubleshooting|telemetry"]="ٹیلی میٹری اصلاحات"
    };
    private static readonly Dictionary<string, string> UiExtra_ur = new()
    {
["state_on"]="آن", ["state_off"]="آف", 
            ["confirm_delete"]="حذف کی تصدیق کریں",
            ["confirm_enable"]="یہ تبدیلی لاگو کریں؟",
            ["confirm_disable"]="یہ تحفظ بند کر دیں؟",
            ["delete_plans"]="{0} پاور پلان(s) حذف کریں؟",
            ["cant_delete_active"]="فعال پاور پلان حذف نہیں کیا جا سکتا۔ پہلے کسی اور پلان پر جائیں۔",
            ["import_plan"]="پاور پلان امپورٹ کریں", ["export_plan"]="پاور پلان ایکسپورٹ کریں",
            ["ratio"]="تناسب", ["long"]="طویل", ["short"]="مختصر", ["fixed"]="فکسڈ", ["variable"]="متغیر", ["boost"]="بوسٹ", ["current"]="موجودہ",
            ["needs_admin"]="اس عمل کے لیے ایڈمنسٹریٹر اجازت درکار ہے۔",
            ["restart_driver"]="ڈسپلے ڈرائیور ری اسٹارٹ کریں", ["reset_all"]="سب ری سیٹ کریں", ["download_cru"]="CRU ڈاؤن لوڈ کریں",
            ["modify_quantum"]="کوانٹم تبدیل کریں", ["quantum_length"]="کوانٹم لمبائی", ["quantum_interval"]="کوانٹم وقفہ",
            ["fix"]="ٹھیک کریں", ["preview_hex"]="ہیکس پیش نظارہ", ["preview_bits"]="بٹس پیش نظارہ",
            ["minimize"]="منیمائز کریں", ["maximize"]="میکسیمائز کریں", ["toggle_theme"]="لائٹ / ڈارک تھیم بدلیں",
            ["follow_theme"]="Windows تھیم کی پیروی کریں", ["square"]="مربع کونے", ["rounded"]="گول کونے",
            ["join"]="شامل ہوں", ["follow"]="فالو کریں", ["visit"]="ملاحظہ کریں", ["copy_link"]="لنک کاپی کریں", ["copied"]="کاپی ہو گیا",
            ["no_profiles_found"]="کوئی پروفائل نہیں ملا۔ .nip فائلیں Nvidia Profiles فولڈر میں رکھیں۔",
            ["home_discord_desc"]="Superiorly کمیونٹی",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="سیکیورٹی: ", ["power_plan_filter"]="پاور پلان",
            ["theme_changed"]="تھیم {0} میں تبدیل ہو گئی", ["style_changed"]="اسٹائل {0} میں تبدیل ہو گیا",
            ["powerplan_custom"]="کسٹم", ["powerplan_restore"]="آفیشل بحال کریں",
            ["update_available"]="اپ ڈیٹ {0} دستیاب ہے", ["new_update"]="نئی اپ ڈیٹ: {0}", ["up_to_date"]="آپ اپ ٹو ڈیٹ ہیں", ["update_check_failed"]="اپ ڈیٹس چیک نہیں ہو سکے",
        
    };
}
