namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> ActionTitles_pl = new()
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
            ["driverview"]="DriverView", ["cru"]="Narzędzie niestandardowej rozdzielczości (CRU)", ["windows-update-manager"]="Menedżer Windows Update", ["mousetester"]="MouseTester",
            ["geek-uninstaller"]="Geek Uninstaller", ["measuresleep"]="MeasureSleep", ["ocat"]="OCAT", ["onboard-memory-manager"]="OnboardMemoryManager",
            ["performance-measurement"]="PerformanceMeasurementTool", ["msstore-downloader"]="Program pobierający Microsoft Store", ["autoruns"]="Autoruns", ["devicecleanup"]="DeviceCleanup",
            ["gointerruptpolicy"]="GoInterruptPolicy", ["serviwin"]="Serviwin", ["usbtreeview"]="UsbTreeView", ["ddu"]="DDU",
            ["filterkeysetter"]="FilterKeysSetter", ["throttlestop"]="ThrottleStop", ["radeonsoftwareslimmer"]="RadeonSoftwareSlimmer", ["moreclocktool"]="MoreClockTool",
            ["morepowertool"]="MorePowerTool", ["radeonmod"]="RadeonMod", ["nvcleanstall"]="NVCleanstall", ["nvidia-inspector"]="NVIDIA Profile Inspector",
            ["apply-nip"]="Zastosowanie NIP", ["force-pstate0"]="Wymuszenie PState0", ["group-cpu-scheduling"]="CPU i planowanie", ["lazymodetimeout"]="LazyModeTimeout",
            ["systemresponsiveness"]="SystemResponsiveness", ["receive-buffers"]="Bufory odbioru", ["transmit-buffers"]="Bufory nadawania", ["csrss-priority"]="Priorytet CSRS",
            ["iolatencycap"]="IoLatencyCap", ["iopagelocklimit"]="IOPageLockLimit", ["group-network"]="Sieć", ["nagle-algorithm"]="Algorytm Nagle",
            ["nolazymode"]="NoLazyMode", ["tsc-sync-policy"]="Polityka synchronizacji TSC", ["group-timer-interrupts"]="Zegar i przerwania", ["useplatformtick"]="useplatformtick",
            ["group-gpu-display"]="GPU i wyświetlanie", ["disable-mpo"]="Wyłączenie Multi-Plane Overlay (MPO)", ["disable-interrupt-steering"]="Wyłączenie sterowania przerwaniami", ["group-power"]="Zasilanie",
            ["disable-power-throttling"]="Wyłączenie ograniczania zasilania", ["group-system-tools"]="Narzędzia systemowe", ["group-maintenance"]="Konserwacja", ["group-benchmarks-peripherals"]="Benchmarki i urządzenia peryferyjne",
            ["threaded-dpc"]="Wątkowe DPC", ["cpu-idle"]="Bezczynność CPU (plan zasilania)", ["force-direct-flip"]="Wymuszenie Direct Flip", ["force-independent-flip"]="Wymuszenie Independent Flip",
            ["force-flip-true-immediate"]="Wymuszenie trybu natychmiastowego", ["group-memory-io"]="Pamięć i We/Wy", ["disablepagingexecutive"]="DisablePagingExecutive", ["disablepagecombining"]="DisablePageCombining",
            ["queued-present-limit"]="Limit prezentacji w kolejce", ["win32priorityseparation"]="Win32PrioritySeparation", ["powerplan-manager"]="Plany zasilania", ["wifi"]="Wi-Fi",
            ["bluetooth"]="Bluetooth", ["hop-limit"]="HopLimit (hotspot)", ["printer"]="Drukarki", ["task-manager"]="Task Manager do Process Explorer",
            ["textinputhost"]="TextInputHost", ["vbs"]="VBS (zabezpieczenia oparte na wirtualizacji)", ["hvci"]="HVCI (integralność pamięci)", ["core-isolation"]="Izolacja rdzenia",
            ["firewall"]="Zapora", ["lua"]="UAC / LUA", ["vulnerable-driver-blocklist"]="Lista blokowanych podatnych sterowników", ["nx-mode"]="Tryb No-Execute (NX)",
            ["xbox"]="Usługi Xbox", ["fivem-safe-services"]="Bezpieczne usługi FiveM/Minecraft", ["windows-update-drivers"]="Sterowniki Windows Update", ["start-menu"]="Menu Start",
            ["use-default-tile"]="Użycie domyślnego kafelka", ["fix-intel-panel"]="Naprawa panelu Intel",
        
    };
}
