namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_en = new()
    {
 ["home"]="Home", ["browsers"]="Browsers", ["tools"]="Tools", ["tweaking"]="Tweaking", ["troubleshooting"]="Troubleshooting" 
    };
    private static readonly Dictionary<string, string> SectionDescs_en = new()
    {
 ["home"]="Welcome to your toolbox", ["browsers"]="Browser related utilities and fixes", ["tools"]="Downloads and runs portable utilities", ["tweaking"]="Driver, GPU and system tweaks.", ["troubleshooting"]="Quick toggles and OS fixes." 
    };
    private static readonly Dictionary<string, string> TabTitles_en = new()
    {
 ["mainstream"]="Mainstream", ["privacy"]="Privacy", ["forks"]="Forks & Custom", ["software"]="Software", ["store-downloader"]="Microsoft store downloader", ["utilities"]="Utilities", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Registry Tweaks", ["win32"]="Win32PrioritySeparation", ["powerplans"]="Power Plans", ["connectivity"]="Connectivity", ["devices"]="Devices", ["security"]="Security", ["gaming"]="Gaming", ["ai"]="AI", ["debloat"]="Debloat", ["system"]="System" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Notifications_en = new()
    {
 ["opened"]="Opened - launched", ["installed"]="Installed successfully", ["failed"]="Installation failed", ["open_failed"]="Failed to open", ["enabled"]="Enabled", ["disabled"]="Disabled", ["apply_failed"]="Failed to apply", ["applied"]="Applied" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_en = new()
    {

            ["settings"]="Settings", ["language"]="Language", ["theme"]="Theme", ["dark"]="Dark", ["light"]="Light", ["auto"]="Auto", ["default_theme"]="Default Theme",
            ["style"]="Style", ["win10_style"]="Windows 10 style", ["win11_style"]="Windows 11 style", ["close"]="Close",
            ["search_placeholder"]="Search by name, URL, or ID.", ["store_no_results"]="No results found. Try another search.", ["search"]="Search", ["install"]="Install",
            ["run"]="Run", ["download"]="Download", ["apply"]="Apply",
            ["check_updates"]="Check for updates", ["update"]="Update", ["disclaimer"]="Modifications are your sole responsibility.",
            ["quantum_title"]="Quantum Map", ["quantum_subtitle"]="All valid Win32PrioritySeparation values. Click a row to apply it.",
            ["open_quantum"]="Open Quantum Map", ["current_win32"]="Current Win32PrioritySeparation",
            ["load_list"]="Load list", ["unload_list"]="Unload list", ["activate"]="Activate", ["import"]="Import", ["export"]="Export",
            ["select_all"]="Select All", ["unselect_all"]="Unselect All", ["uninstall"]="Uninstall", ["delete"]="Delete",
            ["restore_default"]="Restore Default", ["yes"]="Yes", ["no"]="No",
            ["searching_for"]="Searching for '{0}'...", ["downloading"]="Downloading {0}...", ["starting"]="Starting {0}...",
            ["applying"]="Applying {0}...", ["installing"]="Installing {0}...",             ["loading"]="Loading {0}...",
            ["reading_plans"]="Reading power plans...", ["populating_list"]="Populating list...",
            ["apps_found"]="{0} apps found", ["nothing_found"]="Nothing found", ["loaded_items"]="Loaded {0} items",
            ["list_unloaded"]="List unloaded",
            ["exported"]="Exported {0}",
            ["installed_n"]="Installed {0} app(s)", ["install_failed"]="Installation failed",
            ["failed_admin"]="Failed - Run as administrator or reboot required", ["failed"]="Failed",
            ["win32_set"]="Win32PrioritySeparation set to {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_en = new()
    {
 ["run"]="Run", ["download"]="Download", ["apply"]="Apply", ["enable"]="Enable", ["disable"]="Disable", ["search"]="Search", ["install"]="Install", ["load list"]="Load list", ["uninstall"]="Uninstall", ["activate"]="Activate", ["delete"]="Delete", ["import .pow"]="Import .pow", ["default"]="Default", ["custom"]="Custom", ["minimum"]="Minimum", ["disable mmcss"]="Disable MMCSS", ["bypass"]="Bypass", ["repeater"]="Repeater", ["realtime"]="RealTime", ["high"]="High", ["abovenormal"]="AboveNormal", ["normal"]="Normal", ["belownormal"]="BelowNormal", ["enhanced"]="Enhanced", ["legacy"]="Legacy", ["disabled"]="Disabled", ["enabled"]="Enabled", ["alwayson"]="AlwaysOn", ["alwaysoff"]="AlwaysOff", ["optin"]="OptIn", ["optout"]="OptOut", ["open cru"]="Open CRU", ["coming soon"]="Coming soon", ["safe fivem/minecraft services"]="Safe FiveM/Minecraft Services", ["kernelos default"]="Superiorly Default" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> TabDescs_en = new()
    {
 ["mainstream"]="Everyday Browsers.", ["privacy"]="Browsers Built For Privacy And Anonymity.", ["forks"]="Community Builds Based On Chromium And Firefox.", ["utilities"]="Tools For System And Hardware Diagnostics.", ["amd"]="AMD GPU Tools For Drivers, Clock, Voltage And Registry.", ["nvidia"]="NVIDIA Tools For Clean Installs, Profiles And P-States.", ["connectivity"]="Wi-Fi, Bluetooth And Hotspot Hop Limit Settings.", ["devices"]="Printer, Task Manager And Text Input Fixes.", ["security"]="Core Isolation, Firewall, UAC, Driver Blocklist And Memory Protections.", ["gaming"]="Xbox Services And Opera GX.", ["ai"]="Chromium, WebKit And AI-First Browsing.", ["debloat"]="Browser privacy policies and vendor telemetry switches: Chrome, Edge, Firefox and Office.", ["system"]="Windows Update Driver, Start Menu And Intel Panel Fixes." , ["telemetry"]="Telemetry, suggestions, ads and vendor data collection switches."
    };
    private static readonly Dictionary<string, string> SectionTabDescs_en = new()
    {
 ["browsers|gaming"]="Opera GX With Built-In CPU, RAM And Network Limiters.", ["troubleshooting|gaming"]="Xbox Services And FiveM/Minecraft Safe Services." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_en = new()
    {
 ["mainstream"]="Everyday Browsers", ["privacy"]="Anonymous Browsing", ["forks"]="Independent Forks", ["utilities"]="System Utilities", ["amd"]="Radeon Tools", ["nvidia"]="GeForce Tools", ["connectivity"]="Wireless Settings", ["devices"]="Device Fixes", ["security"]="System Protections", ["gaming"]="Game Services", ["ai"]="AI Browsers", ["debloat"]="Browser Debloat", ["system"]="Windows Fixes" , ["telemetry"]="Telemetry Fixes"
    };
    private static readonly Dictionary<string, string> SectionTabTitles_en = new()
    {
 ["browsers|gaming"]="Gaming Browser", ["troubleshooting|gaming"]="Game Services" , ["troubleshooting|telemetry"]="Telemetry Fixes"
    };
    private static readonly Dictionary<string, string> UiExtra_en = new()
    {
["state_on"]="On", ["state_off"]="Off", 
            ["confirm_delete"]="Confirm delete",
            ["confirm_enable"]="Apply this change?",
            ["confirm_disable"]="Turn this protection off?",
            ["delete_plans"]="Delete {0} power plan(s)?",
            ["cant_delete_active"]="Cannot delete the active power plan. Switch to another plan first.",
            ["import_plan"]="Import Power Plan", ["export_plan"]="Export Power Plan",
            ["ratio"]="ratio", ["long"]="Long", ["short"]="Short", ["fixed"]="Fixed", ["variable"]="Variable", ["boost"]="boost", ["current"]="current",
            ["needs_admin"]="This action requires administrator privileges.",
            ["restart_driver"]="Restart Display Driver", ["reset_all"]="Reset All", ["download_cru"]="Download CRU",
            ["modify_quantum"]="Modify Quantum", ["quantum_length"]="Quantum Length", ["quantum_interval"]="Quantum Interval",
            ["fix"]="Fix", ["preview_hex"]="Preview Hex", ["preview_bits"]="Preview Bits",
            ["minimize"]="Minimize", ["maximize"]="Maximize", ["toggle_theme"]="Toggle light / dark theme",
            ["follow_theme"]="Follow Windows theme", ["square"]="Square corners", ["rounded"]="Rounded corners",
            ["join"]="JOIN", ["follow"]="FOLLOW", ["visit"]="VISIT", ["copy_link"]="Copy link", ["copied"]="Copied",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="@sebasprtl",
            ["security"]="Security: ", ["power_plan_filter"]="Power Plan",
            ["theme_changed"]="Theme changed to {0}", ["style_changed"]="Style changed to {0}",
            ["powerplan_custom"]="Custom", ["powerplan_restore"]="Restore official",
            ["update_available"]="Update {0} available", ["new_update"]="New update: {0}", ["up_to_date"]="You are up to date", ["update_check_failed"]="Could not check for updates",
        
    };
}
