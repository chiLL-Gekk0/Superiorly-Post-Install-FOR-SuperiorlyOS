namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> ActionTitles_tr = new()
    {

            ["group-sys-services"]="Services & Performance", ["group-sys-network"]="Network & Sharing", ["group-sys-shell"]="Explorer, Start & Taskbar", ["group-sys-recovery"]="Files, Recovery & Power", ["group-sys-privacy"]="Telemetry & Suggestions",
            ["show-tray-icons"]="Show tray icons", ["menus-delay"]="Menus delay", ["network-throttling"]="Network throttling", ["error-reporting"]="Error reporting", ["compat-assistant"]="Compatibility assistant", ["sticky-keys"]="Sticky keys", ["smb1"]="SMBv1 protocol", ["smb2"]="SMBv2 protocol", ["ntfs-timestamp"]="NTFS timestamp", ["system-restore"]="System restore", ["superfetch"]="Superfetch", ["homegroup"]="HomeGroup", ["media-sharing"]="Media sharing", ["regbackup"]="Periodic registry backup", ["compact-mode"]="Compact mode", ["long-paths"]="Long paths", ["quickaccess-history"]="Quick access history", ["insider-service"]="Insider service", ["sensor-services"]="Sensor services", ["search-index"]="Search index", ["telemetry-services"]="Telemetry services", ["modern-standby"]="Modern standby", ["widgets-board"]="Widgets board", ["news-interests"]="News and interests", ["store-updates"]="Store suggested apps", ["telemetry-tasks"]="Telemetry tasks", ["cortana"]="Cortana and web search", ["startmenu-ads"]="Start menu ads", ["gamebar"]="Game Bar and DVR", ["gamemode"]="Game Mode", ["ink-workspace"]="Windows Ink workspace", ["spelling-typing"]="Spelling and typing", ["cloud-clipboard"]="Cloud clipboard", ["cast-to-device"]="Cast to device", ["chrome-debloat"]="Chrome debloat", ["firefox-debloat"]="Firefox debloat", ["office-debloat"]="Office debloat", ["vs-telemetry"]="Visual Studio telemetry", ["nvidia-telemetry"]="NVIDIA telemetry", ["vscode"]="VS Code",
            ["chrome"]="Google Chrome", ["firefox"]="Mozilla Firefox", ["librewolf"]="LibreWolf", ["brave"]="Brave",
            ["thorium"]="Thorium AVX2", ["edge"]="Microsoft Edge", ["vivaldi"]="Vivaldi", ["opera"]="Opera",
            ["operagx"]="Opera GX", ["comet"]="Perplexity Comet", ["floorp"]="Floorp", ["waterfox"]="Waterfox",
            ["ungoogled"]="Ungoogled Chromium", ["zen"]="Zen Browser", ["arc"]="Arc", ["duckduckgo"]="DuckDuckGo",
            ["mullvad"]="Mullvad Browser", ["pale-moon"]="Pale Moon", ["yandex"]="Yandex Browser", ["epic-browser"]="Epic Privacy Browser",
            ["cachy-browser"]="Cachy Browser", ["kagi-orion"]="Kagi Orion", ["tor-browser"]="Tor Browser", ["chromium"]="Chromium",
            ["avast-secure"]="Avast Secure Browser", ["whale"]="Naver Whale", ["falkon"]="Falkon", ["dia"]="Dia",
            ["brave-debloat"]="Brave Debloat", ["edge-debloat"]="Edge Debloat", ["process-explorer"]="Process Explorer", ["nsudo"]="NSudo",
            ["driverview"]="DriverView", ["cru"]="Özel Çözünürlük Yardımcısı (CRU)", ["windows-update-manager"]="Windows Update Yöneticisi", ["mousetester"]="MouseTester",
            ["geek-uninstaller"]="Geek Uninstaller", ["measuresleep"]="MeasureSleep", ["ocat"]="OCAT", ["onboard-memory-manager"]="OnboardMemoryManager",
            ["performance-measurement"]="PerformanceMeasurementTool", ["msstore-downloader"]="Microsoft Store İndiricisi", ["autoruns"]="Autoruns", ["devicecleanup"]="DeviceCleanup",
            ["gointerruptpolicy"]="GoInterruptPolicy", ["serviwin"]="Serviwin", ["usbtreeview"]="UsbTreeView", ["ddu"]="DDU",
            ["filterkeysetter"]="FilterKeysSetter", ["throttlestop"]="ThrottleStop", ["radeonsoftwareslimmer"]="RadeonSoftwareSlimmer", ["moreclocktool"]="MoreClockTool",
            ["morepowertool"]="MorePowerTool", ["radeonmod"]="RadeonMod", ["nvcleanstall"]="NVCleanstall", ["nvidia-inspector"]="NVIDIA Profile Inspector",
            ["apply-nip"]="NIP Uygulayın", ["force-pstate0"]="PState0 Zorlayın", ["group-cpu-scheduling"]="CPU ve Zamanlama", ["lazymodetimeout"]="LazyModeTimeout",
            ["systemresponsiveness"]="SystemResponsiveness", ["receive-buffers"]="Alma Arabellekleri", ["transmit-buffers"]="Gönderme Arabellekleri", ["csrss-priority"]="CSRS Önceliği",
            ["iolatencycap"]="IoLatencyCap", ["iopagelocklimit"]="IOPageLockLimit", ["group-network"]="Ağ", ["nagle-algorithm"]="Nagle Algoritması",
            ["nolazymode"]="NoLazyMode", ["tsc-sync-policy"]="TSC Eşitleme İlkesi", ["group-timer-interrupts"]="Zamanlayıcı ve Kesmeler", ["useplatformtick"]="useplatformtick",
            ["group-gpu-display"]="GPU ve Ekran", ["disable-mpo"]="Multi-Plane Overlay (MPO) Devre Dışı Bırakın", ["disable-interrupt-steering"]="Kesme Yönlendirmeyi Devre Dışı Bırakın", ["group-power"]="Güç",
            ["disable-power-throttling"]="Güç Kısmayı Devre Dışı Bırakın", ["group-system-tools"]="Sistem Araçları", ["group-maintenance"]="Bakım", ["group-benchmarks-peripherals"]="Benchmarklar ve Çevre Birimleri",
            ["threaded-dpc"]="İş Parçacıklı DPC", ["cpu-idle"]="CPU Boşta (güç planı)", ["force-direct-flip"]="Direct Flip Zorlayın", ["force-independent-flip"]="Independent Flip Zorlayın",
            ["force-flip-true-immediate"]="Gerçek Anında Modu Zorlayın", ["group-memory-io"]="Bellek ve G/Ç", ["disablepagingexecutive"]="DisablePagingExecutive", ["disablepagecombining"]="DisablePageCombining",
            ["queued-present-limit"]="Kuyruklu Sunum Sınırı", ["win32priorityseparation"]="Win32PrioritySeparation", ["powerplan-manager"]="Güç Planları", ["wifi"]="Wi-Fi",
            ["bluetooth"]="Bluetooth", ["hop-limit"]="HopLimit (etkin nokta)", ["printer"]="Yazıcılar", ["task-manager"]="Task Manager - Process Explorer",
            ["textinputhost"]="TextInputHost", ["vbs"]="VBS (sanallaştırma tabanlı güvenlik)", ["hvci"]="HVCI (bellek bütünlüğü)",
            ["firewall"]="Güvenlik Duvarı", ["lua"]="UAC / LUA", ["vulnerable-driver-blocklist"]="Savunmasız Sürücü Engelleme Listesi", ["nx-mode"]="No-Execute (NX) Modu",
            ["xbox"]="Xbox Hizmetleri", ["fivem-safe-services"]="FiveM/Minecraft Güvenli Hizmetleri", ["windows-update-drivers"]="Windows Update Sürücüleri", ["start-menu"]="Başlat Menüsü",
            ["use-default-tile"]="Varsayılan Kutucuğu Kullanın", ["fix-intel-panel"]="Intel Denetim Masasını Onarın",
        
    };
}
