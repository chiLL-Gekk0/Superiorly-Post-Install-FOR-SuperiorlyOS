namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_hi = new()
    {
 ["home"]="होम", ["browsers"]="ब्राउज़र", ["tools"]="टूल्स", ["tweaking"]="ट्वीकिंग", ["troubleshooting"]="समस्या निवारण" 
    };
    private static readonly Dictionary<string, string> SectionDescs_hi = new()
    {
 ["home"]="आपके टूलबॉक्स में आपका स्वागत है", ["browsers"]="ब्राउज़र संबंधी उपयोगिताएँ और सुधार", ["tools"]="पोर्टेबल उपयोगिताएँ डाउनलोड और चलाएँ", ["tweaking"]="ड्राइवर, GPU और सिस्टम ट्वीक।", ["troubleshooting"]="त्वरित टॉगल और OS सुधार।" 
    };
    private static readonly Dictionary<string, string> TabTitles_hi = new()
    {
 ["mainstream"]="मुख्यधारा", ["privacy"]="गोपनीयता", ["forks"]="फोर्क और कस्टम", ["software"]="सॉफ़्टवेयर", ["store-downloader"]="Microsoft Store डाउनलोडर", ["utilities"]="उपयोगिताएँ", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="रजिस्ट्री", ["win32"]="Win32Priority", ["powerplans"]="पावर प्लान", ["connectivity"]="कनेक्टिविटी", ["devices"]="डिवाइस", ["security"]="सुरक्षा", ["gaming"]="गेमिंग", ["ai"]="AI", ["debloat"]="डीब्लोट", ["system"]="सिस्टम" , ["telemetry"]="टेलीमेट्री"
    };
    private static readonly Dictionary<string, string> Notifications_hi = new()
    {
 ["opened"]="खोला गया - लॉन्च हुआ", ["installed"]="सफलतापूर्वक इंस्टॉल हुआ", ["failed"]="इंस्टॉलेशन विफल", ["open_failed"]="खोलने में विफल", ["enabled"]="सक्षम", ["disabled"]="अक्षम", ["apply_failed"]="लागू करने में विफल", ["applied"]="लागू हुआ" , ["telemetry"]="टेलीमेट्री"
    };
    private static readonly Dictionary<string, string> Ui_hi = new()
    {

            ["settings"]="सेटिंग्स", ["language"]="भाषा", ["theme"]="थीम", ["dark"]="डार्क", ["light"]="लाइट", ["auto"]="ऑटो", ["default_theme"]="डिफ़ॉल्ट थीम",
            ["style"]="शैली", ["win10_style"]="Windows 10 शैली", ["win11_style"]="Windows 11 शैली", ["close"]="बंद करें",
            ["search_placeholder"]="नाम, URL या ID से खोजें।", ["store_no_results"]="कोई परिणाम नहीं मिला। कोई अन्य खोज आज़माएँ।", ["search"]="खोजें", ["install"]="इंस्टॉल करें",
            ["run"]="चलाएँ", ["download"]="डाउनलोड करें", ["open"]="खोलें", ["apply"]="लागू करें",
            ["check_updates"]="अपडेट की जाँच करें", ["update"]="अपडेट करें", ["disclaimer"]="संशोधन आपकी पूर्ण जिम्मेदारी है।",
            ["quantum_title"]="क्वांटम मानचित्र", ["quantum_subtitle"]="सभी मान्य Win32PrioritySeparation मान। लागू करने के लिए किसी पंक्ति पर क्लिक करें।",
            ["open_quantum"]="क्वांटम मानचित्र खोलें", ["current_win32"]="वर्तमान Win32PrioritySeparation",
            ["load_list"]="सूची लोड करें", ["unload_list"]="सूची अनलोड करें", ["activate"]="सक्रिय करें", ["import"]="आयात करें", ["export"]="निर्यात करें",
            ["select_all"]="सभी चुनें", ["unselect_all"]="सभी अचयनित करें", ["uninstall"]="अनइंस्टॉल करें", ["delete"]="हटाएँ",
            ["restore_default"]="डिफ़ॉल्ट पुनर्स्थापित करें", ["yes"]="हाँ", ["no"]="नहीं",
            ["searching_for"]="'{0}' खोजा जा रहा है...", ["downloading"]="{0} डाउनलोड हो रहा है...", ["starting"]="{0} प्रारंभ हो रहा है...",
            ["applying"]="{0} लागू हो रहा है...", ["installing"]="{0} इंस्टॉल हो रहा है...",             ["loading"]="{0} लोड हो रहा है...",
            ["reading_plans"]="पावर प्लान पढ़े जा रहे हैं...", ["populating_list"]="सूची भरी जा रही है...",
            ["apps_found"]="{0} ऐप्स मिले", ["nothing_found"]="कुछ नहीं मिला", ["loaded_items"]="{0} आइटम लोड हुए",
            ["list_unloaded"]="सूची अनलोड हुई",
            ["exported"]="{0} निर्यात हुआ",
            ["installed_n"]="{0} ऐप इंस्टॉल हुए", ["install_failed"]="इंस्टॉलेशन विफल",
            ["failed_admin"]="विफल - व्यवस्थापक के रूप में चलाएँ या रीबूट आवश्यक", ["failed"]="विफल",
            ["win32_set"]="Win32PrioritySeparation {0} पर सेट हुआ",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_hi = new()
    {
 ["run"]="चलाएँ", ["download"]="डाउनलोड करें", ["apply"]="लागू करें", ["enable"]="सक्षम करें", ["disable"]="अक्षम करें", ["search"]="खोजें", ["install"]="इंस्टॉल करें", ["load list"]="सूची लोड करें", ["uninstall"]="अनइंस्टॉल करें", ["activate"]="सक्रिय करें", ["delete"]="हटाएँ", ["import .pow"]=".pow आयात करें", ["default"]="डिफ़ॉल्ट", ["custom"]="कस्टम", ["minimum"]="न्यूनतम", ["disable mmcss"]="MMCSS अक्षम करें", ["bypass"]="बायपास", ["repeater"]="रिपीटर", ["realtime"]="रियलटाइम", ["high"]="उच्च", ["abovenormal"]="सामान्य से ऊपर", ["normal"]="सामान्य", ["belownormal"]="सामान्य से नीचे", ["enhanced"]="उन्नत", ["legacy"]="लेगेसी", ["disabled"]="अक्षम", ["enabled"]="सक्षम", ["alwayson"]="हमेशा चालू", ["alwaysoff"]="हमेशा बंद", ["optin"]="ऑप्ट-इन", ["optout"]="ऑप्ट-आउट", ["open cru"]="CRU खोलें", ["coming soon"]="जल्द आ रहा है", ["safe fivem/minecraft services"]="सुरक्षित FiveM/Minecraft सेवाएँ", ["kernelos default"]="Superiorly डिफ़ॉल्ट" , ["telemetry"]="टेलीमेट्री"
    };
    private static readonly Dictionary<string, string> TabDescs_hi = new()
    {
 ["mainstream"]="रोज़मर्रा के ब्राउज़र।", ["privacy"]="गोपनीयता और गुमनामी के लिए बने ब्राउज़र।", ["forks"]="Chromium और Firefox पर आधारित समुदाय बिल्ड।", ["utilities"]="सिस्टम और हार्डवेयर निदान के लिए उपकरण।", ["amd"]="ड्राइवर, क्लॉक, वोल्टेज और रजिस्ट्री के लिए AMD GPU उपकरण।", ["nvidia"]="क्लीन इंस्टॉल, प्रोफाइल और P-States के लिए NVIDIA उपकरण।", ["connectivity"]="Wi-Fi, Bluetooth और हॉटस्पॉट हॉप सीमा सेटिंग्स।", ["devices"]="प्रिंटर, टास्क मैनेजर और टेक्स्ट इनपुट सुधार।", ["security"]="कोर आइसोलेशन, फ़ायरवॉल, UAC, ड्राइवर ब्लॉकलिस्ट और मेमोरी सुरक्षा।", ["gaming"]="Xbox सेवाएँ और Opera GX।", ["ai"]="Chromium, WebKit और AI-प्रथम ब्राउज़िंग।", ["debloat"]="ब्राउज़र गोपनीयता नीतियाँ और विक्रेता टेलीमेट्री स्विच: Chrome, Edge, Firefox और Office।", ["system"]="Windows Update ड्राइवर, स्टार्ट मेनू और Intel पैनल सुधार।" , ["telemetry"]="टेलीमेट्री, सुझाव, विज्ञापन और विक्रेता डेटा संग्रह स्विच।"
    };
    private static readonly Dictionary<string, string> SectionTabDescs_hi = new()
    {
 ["browsers|gaming"]="अंतर्निहित CPU, RAM और नेटवर्क सीमाओं वाला Opera GX।", ["tweaking|gaming"]="Xbox सेवाएँ और FiveM/Minecraft सुरक्षित सेवाएँ।" 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_hi = new()
    {
 ["mainstream"]="रोज़मर्रा के ब्राउज़र", ["privacy"]="गुमनाम ब्राउज़िंग", ["forks"]="स्वतंत्र फोर्क", ["utilities"]="सिस्टम उपयोगिताएँ", ["amd"]="Radeon उपकरण", ["nvidia"]="GeForce उपकरण", ["connectivity"]="वायरलेस सेटिंग्स", ["devices"]="डिवाइस सुधार", ["security"]="सिस्टम सुरक्षा", ["gaming"]="गेम सेवाएँ", ["ai"]="AI ब्राउज़र", ["debloat"]="ब्राउज़र डीब्लोट", ["system"]="Windows सुधार" , ["telemetry"]="टेलीमेट्री सुधार"
    };
    private static readonly Dictionary<string, string> SectionTabTitles_hi = new()
    {
 ["browsers|gaming"]="गेमिंग ब्राउज़र", ["tweaking|gaming"]="गेम सेवाएँ" , ["troubleshooting|telemetry"]="टेलीमेट्री सुधार"
    };
    private static readonly Dictionary<string, string> UiExtra_hi = new()
    {
["state_on"]="चालू", ["state_off"]="बंद", 
            ["confirm_delete"]="हटाने की पुष्टि करें",
            ["confirm_enable"]="क्या यह परिवर्तन लागू करें?",
            ["confirm_disable"]="क्या यह सुरक्षा बंद करें?",
            ["delete_plans"]="क्या {0} पावर प्लान हटाएँ?",
            ["cant_delete_active"]="सक्रिय पावर प्लान हटाया नहीं जा सकता। पहले किसी अन्य प्लान पर जाएँ।",
            ["import_plan"]="पावर प्लान आयात करें", ["export_plan"]="पावर प्लान निर्यात करें",
            ["ratio"]="अनुपात", ["long"]="लंबा", ["short"]="छोटा", ["fixed"]="निश्चित", ["variable"]="परिवर्ती", ["boost"]="बूस्ट", ["current"]="वर्तमान",
            ["needs_admin"]="इस क्रिया के लिए व्यवस्थापक अधिकार आवश्यक हैं।",
            ["restart_driver"]="डिस्प्ले ड्राइवर पुनरारंभ करें", ["reset_all"]="सभी रीसेट करें", ["download_cru"]="CRU डाउनलोड करें",
            ["modify_quantum"]="क्वांटम संशोधित करें", ["quantum_length"]="क्वांटम अवधि", ["quantum_interval"]="क्वांटम अंतराल",
            ["fix"]="सुधारें", ["preview_hex"]="हेक्स पूर्वावलोकन", ["preview_bits"]="बिट्स पूर्वावलोकन",
            ["minimize"]="छोटा करें", ["maximize"]="बड़ा करें", ["toggle_theme"]="लाइट / डार्क थीम बदलें",
            ["follow_theme"]="Windows थीम का पालन करें", ["square"]="चौकोर कोने", ["rounded"]="गोल कोने",
            ["join"]="JOIN", ["follow"]="FOLLOW", ["visit"]="VISIT", ["copy_link"]="लिंक कॉपी करें", ["copied"]="कॉपी हुआ",
            ["no_profiles_found"]="कोई प्रोफाइल नहीं मिली। .nip फ़ाइलें Nvidia Profiles फ़ोल्डर में रखें।",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="सुरक्षा: ", ["power_plan_filter"]="पावर प्लान",
            ["theme_changed"]="थीम {0} में बदली", ["style_changed"]="शैली {0} में बदली",
            ["powerplan_custom"]="कस्टम", ["powerplan_restore"]="आधिकारिक पुनर्स्थापित करें",
            ["update_available"]="अपडेट {0} उपलब्ध", ["new_update"]="नया अपडेट: {0}", ["up_to_date"]="आप अप-टू-डेट हैं", ["update_check_failed"]="अपडेट की जाँच नहीं हो सकी",
        
    };
}
