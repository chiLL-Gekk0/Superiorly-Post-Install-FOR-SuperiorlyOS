namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> ActionTitles_ko = new()
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
            ["driverview"]="DriverView", ["cru"]="사용자 지정 해상도 유틸리티 (CRU)", ["windows-update-manager"]="Windows Update 관리자", ["mousetester"]="MouseTester",
            ["geek-uninstaller"]="Geek Uninstaller", ["measuresleep"]="MeasureSleep", ["ocat"]="OCAT", ["onboard-memory-manager"]="OnboardMemoryManager",
            ["performance-measurement"]="PerformanceMeasurementTool", ["msstore-downloader"]="Microsoft Store 다운로더", ["autoruns"]="Autoruns", ["devicecleanup"]="DeviceCleanup",
            ["gointerruptpolicy"]="GoInterruptPolicy", ["serviwin"]="Serviwin", ["usbtreeview"]="UsbTreeView", ["ddu"]="DDU",
            ["filterkeysetter"]="FilterKeysSetter", ["throttlestop"]="ThrottleStop", ["radeonsoftwareslimmer"]="RadeonSoftwareSlimmer", ["moreclocktool"]="MoreClockTool",
            ["morepowertool"]="MorePowerTool", ["radeonmod"]="RadeonMod", ["nvcleanstall"]="NVCleanstall", ["nvidia-inspector"]="NVIDIA Profile Inspector",
            ["apply-nip"]="NIP 적용", ["force-pstate0"]="PState0 강제", ["group-cpu-scheduling"]="CPU 및 스케줄링", ["lazymodetimeout"]="LazyModeTimeout",
            ["systemresponsiveness"]="SystemResponsiveness", ["receive-buffers"]="수신 버퍼", ["transmit-buffers"]="송신 버퍼", ["csrss-priority"]="CSRS 우선순위",
            ["iolatencycap"]="IoLatencyCap", ["iopagelocklimit"]="IOPageLockLimit", ["group-network"]="네트워크", ["nagle-algorithm"]="Nagle 알고리즘",
            ["nolazymode"]="NoLazyMode", ["tsc-sync-policy"]="TSC 동기화 정책", ["group-timer-interrupts"]="타이머 및 인터럽트", ["useplatformtick"]="useplatformtick",
            ["group-gpu-display"]="GPU 및 디스플레이", ["disable-mpo"]="Multi-Plane Overlay (MPO) 비활성화", ["disable-interrupt-steering"]="인터럽트 스티어링 비활성화", ["group-power"]="전원",
            ["disable-power-throttling"]="전원 스로틀링 비활성화", ["group-system-tools"]="시스템 도구", ["group-maintenance"]="유지 관리", ["group-benchmarks-peripherals"]="벤치마크 및 주변 장치",
            ["threaded-dpc"]="스레드 DPC", ["cpu-idle"]="CPU 유휴 (전원 계획)", ["force-direct-flip"]="Direct Flip 강제", ["force-independent-flip"]="Independent Flip 강제",
            ["force-flip-true-immediate"]="실제 즉시 모드 강제", ["group-memory-io"]="메모리 및 I/O", ["disablepagingexecutive"]="DisablePagingExecutive", ["disablepagecombining"]="DisablePageCombining",
            ["queued-present-limit"]="대기열 표시 제한", ["win32priorityseparation"]="Win32PrioritySeparation", ["powerplan-manager"]="전원 계획", ["wifi"]="Wi-Fi",
            ["bluetooth"]="Bluetooth", ["hop-limit"]="HopLimit (핫스팟)", ["printer"]="프린터", ["task-manager"]="Task Manager에서 Process Explorer로",
            ["textinputhost"]="TextInputHost", ["vbs"]="VBS (가상화 기반 보안)", ["hvci"]="HVCI (메모리 무결성)",
            ["firewall"]="방화벽", ["lua"]="UAC / LUA", ["vulnerable-driver-blocklist"]="취약한 드라이버 차단 목록", ["nx-mode"]="No-Execute (NX) 모드",
            ["xbox"]="Xbox 서비스", ["fivem-safe-services"]="FiveM/Minecraft 안전 서비스", ["windows-update-drivers"]="Windows Update 드라이버", ["start-menu"]="시작 메뉴",
            ["use-default-tile"]="기본 타일 사용", ["fix-intel-panel"]="Intel 제어판 수정",
        
    };
}
