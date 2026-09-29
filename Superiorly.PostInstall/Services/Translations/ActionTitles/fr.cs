namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> ActionTitles_fr = new()
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
            ["driverview"]="DriverView", ["cru"]="Utilitaire de résolution personnalisée (CRU)", ["windows-update-manager"]="Gestionnaire de Windows Update", ["mousetester"]="MouseTester",
            ["geek-uninstaller"]="Geek Uninstaller", ["measuresleep"]="MeasureSleep", ["ocat"]="OCAT", ["onboard-memory-manager"]="OnboardMemoryManager",
            ["performance-measurement"]="PerformanceMeasurementTool", ["msstore-downloader"]="Téléchargeur Microsoft Store", ["autoruns"]="Autoruns", ["devicecleanup"]="DeviceCleanup",
            ["gointerruptpolicy"]="GoInterruptPolicy", ["serviwin"]="Serviwin", ["usbtreeview"]="UsbTreeView", ["ddu"]="DDU",
            ["filterkeysetter"]="FilterKeysSetter", ["throttlestop"]="ThrottleStop", ["radeonsoftwareslimmer"]="RadeonSoftwareSlimmer", ["moreclocktool"]="MoreClockTool",
            ["morepowertool"]="MorePowerTool", ["radeonmod"]="RadeonMod", ["nvcleanstall"]="NVCleanstall", ["nvidia-inspector"]="NVIDIA Profile Inspector",
            ["apply-nip"]="Appliquer NIP", ["force-pstate0"]="Forcer PState0", ["group-cpu-scheduling"]="CPU et planification", ["lazymodetimeout"]="LazyModeTimeout",
            ["systemresponsiveness"]="SystemResponsiveness", ["receive-buffers"]="Tampons de réception", ["transmit-buffers"]="Tampons de transmission", ["csrss-priority"]="Priorité CSRS",
            ["iolatencycap"]="IoLatencyCap", ["iopagelocklimit"]="IOPageLockLimit", ["group-network"]="Réseau", ["nagle-algorithm"]="Algorithme de Nagle",
            ["nolazymode"]="NoLazyMode", ["tsc-sync-policy"]="Stratégie de synchronisation TSC", ["group-timer-interrupts"]="Minuteur et interruptions", ["useplatformtick"]="useplatformtick",
            ["group-gpu-display"]="GPU et affichage", ["disable-mpo"]="Désactiver Multi-Plane Overlay (MPO)", ["disable-interrupt-steering"]="Désactiver la redirection des interruptions", ["group-power"]="Alimentation",
            ["disable-power-throttling"]="Désactiver la limitation d’alimentation", ["group-system-tools"]="Outils système", ["group-maintenance"]="Maintenance", ["group-benchmarks-peripherals"]="Benchmarks et périphériques",
            ["threaded-dpc"]="DPC multithread", ["cpu-idle"]="Veille CPU (plan d’alimentation)", ["force-direct-flip"]="Forcer Direct Flip", ["force-independent-flip"]="Forcer Independent Flip",
            ["force-flip-true-immediate"]="Forcer le mode immédiat réel", ["group-memory-io"]="Mémoire et E/S", ["disablepagingexecutive"]="DisablePagingExecutive", ["disablepagecombining"]="DisablePageCombining",
            ["queued-present-limit"]="Limite de présentation en file", ["win32priorityseparation"]="Win32PrioritySeparation", ["powerplan-manager"]="Plans d’alimentation", ["wifi"]="Wi-Fi",
            ["bluetooth"]="Bluetooth", ["hop-limit"]="HopLimit (point d’accès)", ["printer"]="Imprimantes", ["task-manager"]="Task Manager vers Process Explorer",
            ["textinputhost"]="TextInputHost", ["vbs"]="VBS (sécurité basée sur la virtualisation)", ["hvci"]="HVCI (intégrité de la mémoire)", ["core-isolation"]="Isolation du noyau",
            ["firewall"]="Pare-feu", ["lua"]="UAC / LUA", ["vulnerable-driver-blocklist"]="Liste de blocage des pilotes vulnérables", ["nx-mode"]="Mode No-Execute (NX)",
            ["xbox"]="Services Xbox", ["fivem-safe-services"]="Services sécurisés FiveM/Minecraft", ["windows-update-drivers"]="Pilotes Windows Update", ["start-menu"]="Menu Démarrer",
            ["use-default-tile"]="Utiliser la tuile par défaut", ["fix-intel-panel"]="Réparer le panneau Intel",
        
    };
}
