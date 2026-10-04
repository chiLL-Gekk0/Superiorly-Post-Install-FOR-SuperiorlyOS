namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_zht = new()
    {
 ["home"]="首頁", ["browsers"]="瀏覽器", ["tools"]="工具", ["tweaking"]="系統調校", ["troubleshooting"]="疑難排解" 
    };
    private static readonly Dictionary<string, string> SectionDescs_zht = new()
    {
 ["home"]="歡迎使用您的工具箱", ["browsers"]="瀏覽器相關工具與修正", ["tools"]="下載並執行可攜式工具", ["tweaking"]="驅動程式、GPU 與系統調校。", ["troubleshooting"]="快速切換與作業系統修正。" 
    };
    private static readonly Dictionary<string, string> TabTitles_zht = new()
    {
 ["mainstream"]="主流", ["privacy"]="隱私", ["forks"]="分支與自訂", ["software"]="軟體", ["store-downloader"]="Microsoft Store 下載器", ["utilities"]="公用程式", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="登錄檔", ["win32"]="Win32Priority", ["powerplans"]="電源計畫", ["connectivity"]="連線", ["devices"]="裝置", ["security"]="安全性", ["gaming"]="遊戲", ["ai"]="AI", ["debloat"]="精簡", ["system"]="系統" , ["telemetry"]="遙測"
    };
    private static readonly Dictionary<string, string> Notifications_zht = new()
    {
 ["opened"]="已開啟 - 已啟動", ["installed"]="安裝成功", ["failed"]="安裝失敗", ["open_failed"]="開啟失敗", ["enabled"]="已啟用", ["disabled"]="已停用", ["apply_failed"]="套用失敗", ["applied"]="已套用" , ["telemetry"]="遙測"
    };
    private static readonly Dictionary<string, string> Ui_zht = new()
    {

            ["settings"]="設定", ["language"]="語言", ["theme"]="主題", ["dark"]="深色", ["light"]="淺色", ["auto"]="自動", ["default_theme"]="預設主題",
            ["style"]="樣式", ["win10_style"]="Windows 10 樣式", ["win11_style"]="Windows 11 樣式", ["close"]="關閉",
            ["search_placeholder"]="依名稱、URL 或 ID 搜尋。", ["store_no_results"]="找不到結果。請嘗試其他搜尋。", ["search"]="搜尋", ["install"]="安裝",
            ["run"]="執行", ["download"]="下載", ["open"]="開啟", ["apply"]="套用",
            ["check_updates"]="檢查更新", ["update"]="更新", ["disclaimer"]="任何修改均由您自行負責。",
            ["quantum_title"]="Quantum 對應表", ["quantum_subtitle"]="所有有效的 Win32PrioritySeparation 值。按一下資料列即可套用。",
            ["open_quantum"]="開啟 Quantum 對應表", ["current_win32"]="目前的 Win32PrioritySeparation",
            ["load_list"]="載入清單", ["unload_list"]="卸載清單", ["activate"]="啟用", ["import"]="匯入", ["export"]="匯出",
            ["select_all"]="全選", ["unselect_all"]="取消全選", ["uninstall"]="解除安裝", ["delete"]="刪除",
            ["restore_default"]="還原預設值", ["yes"]="是", ["no"]="否",
            ["searching_for"]="正在搜尋「{0}」...", ["downloading"]="正在下載 {0}...", ["starting"]="正在啟動 {0}...",
            ["applying"]="正在套用 {0}...", ["installing"]="正在安裝 {0}...",             ["loading"]="正在載入 {0}...",
            ["reading_plans"]="正在讀取電源計畫...", ["populating_list"]="正在填入清單...",
            ["apps_found"]="找到 {0} 個應用程式", ["nothing_found"]="找不到任何項目", ["loaded_items"]="已載入 {0} 個項目",
            ["list_unloaded"]="清單已卸載",
            ["exported"]="已匯出 {0}",
            ["installed_n"]="已安裝 {0} 個應用程式", ["install_failed"]="安裝失敗",
            ["failed_admin"]="失敗 - 請以系統管理員身分執行或需要重新啟動", ["failed"]="失敗",
            ["win32_set"]="Win32PrioritySeparation 已設為 {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_zht = new()
    {
 ["run"]="執行", ["download"]="下載", ["apply"]="套用", ["enable"]="啟用", ["disable"]="停用", ["search"]="搜尋", ["install"]="安裝", ["load list"]="載入清單", ["uninstall"]="解除安裝", ["activate"]="啟用", ["delete"]="刪除", ["import .pow"]="匯入 .pow", ["default"]="預設值", ["custom"]="自訂", ["minimum"]="最小", ["disable mmcss"]="停用 MMCSS", ["bypass"]="略過", ["repeater"]="中繼器", ["realtime"]="RealTime", ["high"]="High", ["abovenormal"]="AboveNormal", ["normal"]="Normal", ["belownormal"]="BelowNormal", ["enhanced"]="增強", ["legacy"]="舊版", ["disabled"]="已停用", ["enabled"]="已啟用", ["alwayson"]="AlwaysOn", ["alwaysoff"]="AlwaysOff", ["optin"]="OptIn", ["optout"]="OptOut", ["open cru"]="開啟 CRU", ["coming soon"]="即將推出", ["safe fivem/minecraft services"]="安全的 FiveM/Minecraft 服務", ["kernelos default"]="Superiorly 預設值" , ["telemetry"]="遙測"
    };
    private static readonly Dictionary<string, string> TabDescs_zht = new()
    {
 ["mainstream"]="日常使用的瀏覽器。", ["privacy"]="為隱私與匿名打造的瀏覽器。", ["forks"]="以 Chromium 與 Firefox 為基礎的社群版本。", ["utilities"]="系統與硬體診斷工具。", ["amd"]="AMD GPU 驅動程式、時脈、電壓與登錄檔工具。", ["nvidia"]="NVIDIA 乾淨安裝、設定檔與 P-State 工具。", ["connectivity"]="Wi-Fi、藍牙與熱點 Hop Limit 設定。", ["devices"]="印表機、工作管理員與文字輸入修正。", ["security"]="核心隔離、防火牆、UAC、驅動程式封鎖清單與記憶體保護。", ["gaming"]="Xbox 服務與 Opera GX。", ["ai"]="Chromium、WebKit 與 AI 優先瀏覽。", ["debloat"]="瀏覽器隱私權原則與廠商遙測開關：Chrome、Edge、Firefox 與 Office。", ["system"]="Windows Update 驅動程式、開始功能表與 Intel 面板修正。" , ["telemetry"]="遙測、建議、廣告與廠商資料收集開關。"
    };
    private static readonly Dictionary<string, string> SectionTabDescs_zht = new()
    {
 ["browsers|gaming"]="內建 CPU、RAM 與網路限制器的 Opera GX。", ["tweaking|gaming"]="Xbox 服務與 FiveM/Minecraft 安全服務。" 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_zht = new()
    {
 ["mainstream"]="日常瀏覽器", ["privacy"]="匿名瀏覽", ["forks"]="獨立分支", ["utilities"]="系統公用程式", ["amd"]="Radeon 工具", ["nvidia"]="GeForce 工具", ["connectivity"]="無線設定", ["devices"]="裝置修正", ["security"]="系統保護", ["gaming"]="遊戲服務", ["ai"]="AI 瀏覽器", ["debloat"]="瀏覽器精簡", ["system"]="Windows 修正" , ["telemetry"]="遙測修正"
    };
    private static readonly Dictionary<string, string> SectionTabTitles_zht = new()
    {
 ["browsers|gaming"]="遊戲瀏覽器", ["tweaking|gaming"]="遊戲服務" , ["troubleshooting|telemetry"]="遙測修正"
    };
    private static readonly Dictionary<string, string> UiExtra_zht = new()
    {
["state_on"]="開啟", ["state_off"]="關閉", 
            ["confirm_delete"]="確認刪除",
            ["confirm_enable"]="要套用此變更嗎?",
            ["confirm_disable"]="要關閉此保護嗎?",
            ["delete_plans"]="要刪除 {0} 個電源計畫嗎?",
            ["cant_delete_active"]="無法刪除使用中的電源計畫。請先切換到另一個計畫。",
            ["import_plan"]="匯入電源計畫", ["export_plan"]="匯出電源計畫",
            ["ratio"]="比例", ["long"]="長", ["short"]="短", ["fixed"]="固定", ["variable"]="變動", ["boost"]="加速", ["current"]="目前",
            ["needs_admin"]="此動作需要系統管理員權限。",
            ["restart_driver"]="重新啟動顯示驅動程式", ["reset_all"]="全部重設", ["download_cru"]="下載 CRU",
            ["modify_quantum"]="修改 Quantum", ["quantum_length"]="Quantum 長度", ["quantum_interval"]="Quantum 間隔",
            ["fix"]="修正", ["preview_hex"]="預覽 Hex", ["preview_bits"]="預覽位元",
            ["minimize"]="最小化", ["maximize"]="最大化", ["toggle_theme"]="切換淺色 / 深色主題",
            ["follow_theme"]="跟隨 Windows 主題", ["square"]="方形角", ["rounded"]="圓角",
            ["join"]="加入", ["follow"]="追隨", ["visit"]="造訪", ["copy_link"]="複製連結", ["copied"]="已複製",
            ["no_profiles_found"]="找不到設定檔。請將 .nip 檔案放入 Nvidia Profiles 資料夾。",
            ["home_discord_desc"]="Superiorly 社群",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="安全性：", ["power_plan_filter"]="電源計畫",
            ["theme_changed"]="主題已變更為 {0}", ["style_changed"]="樣式已變更為 {0}",
            ["powerplan_custom"]="自訂", ["powerplan_restore"]="還原官方",
            ["update_available"]="有可用的更新 {0}", ["new_update"]="新更新：{0}", ["up_to_date"]="您已是最新版本", ["update_check_failed"]="無法檢查更新",
        
    };
}
