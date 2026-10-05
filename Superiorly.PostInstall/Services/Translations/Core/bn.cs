namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_bn = new()
    {
 ["home"]="হোম", ["browsers"]="ব্রাউজার", ["tools"]="টুলস", ["tweaking"]="টুইকিং", ["troubleshooting"]="সমস্যা সমাধান" 
    };
    private static readonly Dictionary<string, string> SectionDescs_bn = new()
    {
 ["home"]="আপনার টুলবক্সে স্বাগতম", ["browsers"]="ব্রাউজার সম্পর্কিত ইউটিলিটি ও সমাধান", ["tools"]="পোর্টেবল ইউটিলিটি ডাউনলোড ও চালান", ["tweaking"]="ড্রাইভার, GPU ও সিস্টেম টুইক।", ["troubleshooting"]="দ্রুত টগল ও OS সমাধান।" 
    };
    private static readonly Dictionary<string, string> TabTitles_bn = new()
    {
 ["mainstream"]="মূলধারা", ["privacy"]="গোপনীয়তা", ["forks"]="ফোর্ক ও কাস্টম", ["software"]="সফটওয়্যার", ["store-downloader"]="Microsoft Store ডাউনলোডার", ["utilities"]="ইউটিলিটি", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="রেজিস্ট্রি", ["win32"]="Win32Priority", ["powerplans"]="পাওয়ার প্ল্যান", ["connectivity"]="সংযোগ", ["devices"]="ডিভাইস", ["security"]="নিরাপত্তা", ["gaming"]="গেমিং", ["ai"]="এআই", ["debloat"]="ডিব্লোট", ["system"]="সিস্টেম" , ["telemetry"]="টেলিমেট্রি",
["app-privacy"]="অ্যাপ গোপনীয়তা",
    };
    private static readonly Dictionary<string, string> Notifications_bn = new()
    {
 ["opened"]="খোলা হয়েছে - চালু হয়েছে", ["installed"]="সফলভাবে ইনস্টল হয়েছে", ["failed"]="ইনস্টলেশন ব্যর্থ হয়েছে", ["open_failed"]="খুলতে ব্যর্থ হয়েছে", ["enabled"]="সক্রিয় করা হয়েছে", ["disabled"]="নিষ্ক্রিয় করা হয়েছে", ["apply_failed"]="প্রয়োগ ব্যর্থ হয়েছে", ["applied"]="প্রয়োগ করা হয়েছে" , ["telemetry"]="টেলিমেট্রি"
    };
    private static readonly Dictionary<string, string> Ui_bn = new()
    {

            ["settings"]="সেটিংস", ["language"]="ভাষা", ["theme"]="থিম", ["dark"]="ডার্ক", ["light"]="লাইট", ["auto"]="স্বয়ংক্রিয়", ["default_theme"]="ডিফল্ট থিম",
            ["style"]="স্টাইল", ["win10_style"]="Windows 10 স্টাইল", ["win11_style"]="Windows 11 স্টাইল", ["close"]="বন্ধ করুন",
            ["search_placeholder"]="নাম, URL বা ID দিয়ে অনুসন্ধান করুন।", ["store_no_results"]="কোনো ফলাফল পাওয়া যায়নি। অন্য কিছু খুঁজে দেখুন।", ["search"]="অনুসন্ধান", ["install"]="ইনস্টল",
            ["run"]="চালান", ["download"]="ডাউনলোড", ["open"]="খুলুন", ["apply"]="প্রয়োগ করুন",
            ["check_updates"]="আপডেট পরীক্ষা করুন", ["update"]="আপডেট", ["disclaimer"]="পরিবর্তন সম্পূর্ণ আপনার নিজের দায়িত্বে।",
            ["quantum_title"]="কোয়ান্টাম মানচিত্র", ["quantum_subtitle"]="সব বৈধ Win32PrioritySeparation মান। প্রয়োগ করতে কোনো সারিতে ক্লিক করুন।",
            ["open_quantum"]="কোয়ান্টাম মানচিত্র খুলুন", ["current_win32"]="বর্তমান Win32PrioritySeparation",
            ["load_list"]="তালিকা লোড করুন", ["unload_list"]="তালিকা আনলোড করুন", ["activate"]="সক্রিয় করুন", ["import"]="আমদানি", ["export"]="রপ্তানি",
            ["select_all"]="সব নির্বাচন করুন", ["unselect_all"]="সব অনির্বাচন করুন", ["uninstall"]="আনইনস্টল", ["delete"]="মুছুন",
            ["restore_default"]="ডিফল্ট পুনরুদ্ধার করুন", ["yes"]="হ্যাঁ", ["no"]="না",
            ["searching_for"]="'{0}' অনুসন্ধান করা হচ্ছে...", ["downloading"]="{0} ডাউনলোড হচ্ছে...", ["starting"]="{0} চালু হচ্ছে...",
            ["applying"]="{0} প্রয়োগ করা হচ্ছে...", ["installing"]="{0} ইনস্টল হচ্ছে...",             ["loading"]="{0} লোড হচ্ছে...",
            ["reading_plans"]="পাওয়ার প্ল্যান পড়া হচ্ছে...", ["populating_list"]="তালিকা তৈরি হচ্ছে...",
            ["apps_found"]="{0}টি অ্যাপ পাওয়া গেছে", ["nothing_found"]="কিছু পাওয়া যায়নি", ["loaded_items"]="{0}টি আইটেম লোড হয়েছে",
            ["list_unloaded"]="তালিকা আনলোড হয়েছে",
            ["exported"]="{0} রপ্তানি হয়েছে",
            ["installed_n"]="{0}টি অ্যাপ ইনস্টল হয়েছে", ["install_failed"]="ইনস্টলেশন ব্যর্থ হয়েছে",
            ["failed_admin"]="ব্যর্থ - প্রশাসক হিসেবে চালান বা রিবুট প্রয়োজন", ["failed"]="ব্যর্থ",
            ["win32_set"]="Win32PrioritySeparation {0} এ সেট করা হয়েছে",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_bn = new()
    {
 ["run"]="চালান", ["download"]="ডাউনলোড", ["apply"]="প্রয়োগ করুন", ["enable"]="সক্রিয় করুন", ["disable"]="নিষ্ক্রিয় করুন", ["search"]="অনুসন্ধান", ["install"]="ইনস্টল", ["load list"]="তালিকা লোড করুন", ["uninstall"]="আনইনস্টল", ["activate"]="সক্রিয় করুন", ["delete"]="মুছুন", ["import .pow"]=".pow আমদানি করুন", ["default"]="ডিফল্ট", ["custom"]="কাস্টম", ["minimum"]="সর্বনিম্ন", ["disable mmcss"]="MMCSS নিষ্ক্রিয় করুন", ["bypass"]="বাইপাস", ["repeater"]="রিপিটার", ["realtime"]="রিয়েলটাইম", ["high"]="উচ্চ", ["abovenormal"]="স্বাভাবিকের উপরে", ["normal"]="স্বাভাবিক", ["belownormal"]="স্বাভাবিকের নিচে", ["enhanced"]="উন্নত", ["legacy"]="লিগ্যাসি", ["disabled"]="নিষ্ক্রিয়", ["enabled"]="সক্রিয়", ["alwayson"]="সর্বদা চালু", ["alwaysoff"]="সর্বদা বন্ধ", ["optin"]="অপ্ট-ইন", ["optout"]="অপ্ট-আউট", ["open cru"]="CRU খুলুন", ["coming soon"]="শীঘ্রই আসছে", ["safe fivem/minecraft services"]="নিরাপদ FiveM/Minecraft পরিষেবা", ["kernelos default"]="Superiorly ডিফল্ট" , ["telemetry"]="টেলিমেট্রি"
    };
    private static readonly Dictionary<string, string> TabDescs_bn = new()
    {
 ["mainstream"]="প্রতিদিনের ব্রাউজার।", ["privacy"]="গোপনীয়তা ও বেনামে ব্যবহারের জন্য তৈরি ব্রাউজার।", ["forks"]="Chromium ও Firefox ভিত্তিক কমিউনিটি বিল্ড।", ["utilities"]="সিস্টেম ও হার্ডওয়্যার নির্ণয়ের টুলস।", ["amd"]="ড্রাইভার, ক্লক, ভোল্টেজ ও রেজিস্ট্রির জন্য AMD GPU টুলস।", ["nvidia"]="ক্লিন ইনস্টল, প্রোফাইল ও P-State এর জন্য NVIDIA টুলস।", ["connectivity"]="Wi-Fi, Bluetooth ও হটস্পট হপ সীমার সেটিংস।", ["devices"]="প্রিন্টার, টাস্ক ম্যানেজার ও টেক্সট ইনপুট সমাধান।", ["security"]="কোর আইসোলেশন, ফায়ারওয়াল, UAC, ড্রাইভার ব্লকলিস্ট ও মেমোরি সুরক্ষা।", ["gaming"]="Xbox পরিষেবা ও Opera GX।", ["ai"]="Chromium, WebKit ও এআই-প্রথম ব্রাউজিং।", ["debloat"]="ব্রাউজার গোপনীয়তা নীতি ও ভেন্ডর টেলিমেট্রি সুইচ: Chrome, Edge, Firefox ও Office।", ["system"]="Windows Update ড্রাইভার, স্টার্ট মেনু ও Intel প্যানেল সমাধান।" , ["telemetry"]="টেলিমেট্রি, পরামর্শ, বিজ্ঞাপন ও ভেন্ডর ডেটা সংগ্রহ সুইচ।",
["app-privacy"]="অ্যাপ পারমিশন ও গোপনীয়তা সেটিংস।",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_bn = new()
    {
 ["browsers|gaming"]="বিল্ট-ইন CPU, RAM ও নেটওয়ার্ক লিমিটারসহ Opera GX।", ["tweaking|gaming"]="Xbox পরিষেবা ও FiveM/Minecraft নিরাপদ পরিষেবা।" 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_bn = new()
    {
 ["mainstream"]="প্রতিদিনের ব্রাউজার", ["privacy"]="বেনামে ব্রাউজিং", ["forks"]="স্বতন্ত্র ফোর্ক", ["utilities"]="সিস্টেম ইউটিলিটি", ["amd"]="Radeon টুলস", ["nvidia"]="GeForce টুলস", ["connectivity"]="ওয়্যারলেস সেটিংস", ["devices"]="ডিভাইস সমাধান", ["security"]="সিস্টেম সুরক্ষা", ["gaming"]="গেম পরিষেবা", ["ai"]="এআই ব্রাউজার", ["debloat"]="ব্রাউজার ডিব্লোট", ["system"]="Windows সমাধান" , ["telemetry"]="টেলিমেট্রি সমাধান",
["app-privacy"]="অ্যাপ গোপনীয়তা",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_bn = new()
    {
 ["browsers|gaming"]="গেমিং ব্রাউজার", ["tweaking|gaming"]="গেম পরিষেবা" , ["troubleshooting|telemetry"]="টেলিমেট্রি সমাধান"
    };
    private static readonly Dictionary<string, string> UiExtra_bn = new()
    {
["state_on"]="চালু", ["state_off"]="বন্ধ", 
            ["confirm_delete"]="মুছে ফেলা নিশ্চিত করুন",
            ["confirm_enable"]="এই পরিবর্তন প্রয়োগ করবেন?",
            ["confirm_disable"]="এই সুরক্ষা বন্ধ করবেন?",
            ["delete_plans"]="{0}টি পাওয়ার প্ল্যান মুছবেন?",
            ["cant_delete_active"]="সক্রিয় পাওয়ার প্ল্যান মোছা যাবে না। প্রথমে অন্য প্ল্যানে যান।",
            ["import_plan"]="পাওয়ার প্ল্যান আমদানি করুন", ["export_plan"]="পাওয়ার প্ল্যান রপ্তানি করুন",
            ["ratio"]="অনুপাত", ["long"]="দীর্ঘ", ["short"]="সংক্ষিপ্ত", ["fixed"]="স্থির", ["variable"]="পরিবর্তনশীল", ["boost"]="বুস্ট", ["current"]="বর্তমান",
            ["needs_admin"]="এই কাজের জন্য প্রশাসকের অনুমতি প্রয়োজন।",
            ["restart_driver"]="ডিসপ্লে ড্রাইভার পুনরায় চালু করুন", ["reset_all"]="সব রিসেট করুন", ["download_cru"]="CRU ডাউনলোড করুন",
            ["modify_quantum"]="কোয়ান্টাম পরিবর্তন করুন", ["quantum_length"]="কোয়ান্টাম দৈর্ঘ্য", ["quantum_interval"]="কোয়ান্টাম ব্যবধান",
            ["fix"]="ঠিক করুন", ["preview_hex"]="হেক্স প্রিভিউ", ["preview_bits"]="বিট প্রিভিউ",
            ["minimize"]="মিনিমাইজ", ["maximize"]="ম্যাক্সিমাইজ", ["toggle_theme"]="লাইট / ডার্ক থিম বদলান",
            ["follow_theme"]="Windows থিম অনুসরণ করুন", ["square"]="চৌকো কোণা", ["rounded"]="গোলাকার কোণা",
            ["join"]="যোগ দিন", ["follow"]="অনুসরণ করুন", ["visit"]="দেখুন", ["copy_link"]="লিংক কপি করুন", ["copied"]="কপি হয়েছে",
            ["no_profiles_found"]="কোনো প্রোফাইল পাওয়া যায়নি। .nip ফাইল Nvidia Profiles ফোল্ডারে রাখুন।",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="নিরাপত্তা: ", ["power_plan_filter"]="পাওয়ার প্ল্যান",
            ["theme_changed"]="থিম {0} এ পরিবর্তিত হয়েছে", ["style_changed"]="স্টাইল {0} এ পরিবর্তিত হয়েছে",
            ["powerplan_custom"]="কাস্টম", ["powerplan_restore"]="অফিসিয়াল পুনরুদ্ধার করুন",
            ["update_available"]="{0} আপডেট উপলব্ধ", ["new_update"]="নতুন আপডেট: {0}", ["up_to_date"]="আপনি হালনাগাদ আছেন", ["update_check_failed"]="আপডেট পরীক্ষা করা যায়নি",
        
    };
}
