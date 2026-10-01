namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_de = new()
    {
 ["home"]="Startseite", ["browsers"]="Browser", ["tools"]="Werkzeuge", ["tweaking"]="Optimierung", ["troubleshooting"]="Fehlerbehebung" 
    };
    private static readonly Dictionary<string, string> SectionDescs_de = new()
    {
 ["home"]="Willkommen in Ihrem Werkzeugkasten", ["browsers"]="Browser-bezogene Dienstprogramme und Korrekturen", ["tools"]="Portable Dienstprogramme herunterladen und ausführen", ["tweaking"]="Treiber-, GPU- und Systemoptimierungen.", ["troubleshooting"]="Schnelle Schalter und Systemkorrekturen." 
    };
    private static readonly Dictionary<string, string> TabTitles_de = new()
    {
 ["mainstream"]="Mainstream", ["privacy"]="Datenschutz", ["forks"]="Forks & Angepasst", ["software"]="Software", ["store-downloader"]="Microsoft Store-Downloader", ["utilities"]="Dienstprogramme", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Registry-Optimierungen", ["win32"]="Win32PrioritySeparation", ["powerplans"]="Energiepläne", ["connectivity"]="Netzwerkverbindung", ["devices"]="Geräte", ["security"]="Sicherheit", ["gaming"]="Gaming", ["ai"]="KI", ["debloat"]="Debloat", ["system"]="System" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Notifications_de = new()
    {
 ["opened"]="Geöffnet - gestartet", ["installed"]="Erfolgreich installiert", ["failed"]="Installation fehlgeschlagen", ["open_failed"]="Konnte nicht geöffnet werden", ["enabled"]="Aktiviert", ["disabled"]="Deaktiviert", ["apply_failed"]="Konnte nicht angewendet werden", ["applied"]="Angewendet" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_de = new()
    {

            ["settings"]="Einstellungen", ["language"]="Sprache", ["theme"]="Design", ["dark"]="Dunkel", ["light"]="Hell", ["auto"]="Automatisch", ["default_theme"]="Standard-Design",
            ["style"]="Stil", ["win10_style"]="Windows-10-Stil", ["win11_style"]="Windows-11-Stil", ["close"]="Schließen",
            ["search_placeholder"]="Nach Name, URL oder ID suchen.", ["store_no_results"]="Keine Ergebnisse. Versuchen Sie eine andere Suche.", ["search"]="Suchen", ["install"]="Installieren",
            ["run"]="Ausführen", ["download"]="Herunterladen", ["open"]="Öffnen", ["apply"]="Anwenden",
            ["check_updates"]="Nach Updates suchen", ["update"]="Update", ["disclaimer"]="Änderungen erfolgen in Ihrer alleinigen Verantwortung.",
            ["quantum_title"]="Quantum-Karte", ["quantum_subtitle"]="Alle gültigen Win32PrioritySeparation-Werte. Klicken Sie auf eine Zeile, um sie anzuwenden.",
            ["open_quantum"]="Quantum-Karte öffnen", ["current_win32"]="Aktuelle Win32PrioritySeparation",
            ["load_list"]="Liste laden", ["unload_list"]="Liste schließen", ["activate"]="Aktivieren", ["import"]="Importieren", ["export"]="Exportieren",
            ["select_all"]="Alle auswählen", ["unselect_all"]="Auswahl aufheben", ["uninstall"]="Deinstallieren", ["delete"]="Löschen",
            ["restore_default"]="Standards wiederherstellen", ["yes"]="Ja", ["no"]="Nein",
            ["searching_for"]="Suche nach '{0}'...", ["downloading"]="{0} wird heruntergeladen...", ["starting"]="{0} wird gestartet...",
            ["applying"]="{0} wird angewendet...", ["installing"]="{0} wird installiert...",             ["loading"]="{0} wird geladen...",
            ["reading_plans"]="Energiepläne werden gelesen...", ["populating_list"]="Liste wird erstellt...",
            ["apps_found"]="{0} Apps gefunden", ["nothing_found"]="Nichts gefunden.", ["loaded_items"]="{0} Einträge geladen",
            ["list_unloaded"]="Liste geschlossen",
            ["exported"]="{0} exportiert",
            ["installed_n"]="{0} App(s) installiert", ["install_failed"]="Installation fehlgeschlagen",
            ["failed_admin"]="Fehler - als Administrator ausführen oder neu starten", ["failed"]="Fehlgeschlagen",
            ["win32_set"]="Win32PrioritySeparation auf {0} gesetzt",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_de = new()
    {
 ["run"]="Ausführen", ["download"]="Herunterladen", ["apply"]="Anwenden", ["enable"]="Aktivieren", ["disable"]="Deaktivieren", ["search"]="Suchen", ["install"]="Installieren", ["load list"]="Liste laden", ["uninstall"]="Deinstallieren", ["activate"]="Aktivieren", ["delete"]="Löschen", ["import .pow"]=".pow importieren", ["default"]="Standard", ["custom"]="Benutzerdefiniert", ["minimum"]="Minimum", ["disable mmcss"]="MMCSS deaktivieren", ["bypass"]="Bypass", ["repeater"]="Repeater", ["realtime"]="Echtzeit", ["high"]="Hoch", ["abovenormal"]="Über Normal", ["normal"]="Normal", ["belownormal"]="Unter Normal", ["enhanced"]="Erweitert", ["legacy"]="Legacy", ["disabled"]="Deaktiviert", ["enabled"]="Aktiviert", ["alwayson"]="Immer an", ["alwaysoff"]="Immer aus", ["optin"]="Opt-in", ["optout"]="Opt-out", ["open cru"]="CRU öffnen", ["coming soon"]="Demnächst", ["safe fivem/minecraft services"]="Sichere FiveM/Minecraft-Dienste", ["kernelos default"]="Superiorly-Standard" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> UiExtra_de = new()
    {
["state_on"]="Ein", ["state_off"]="Aus", 
            ["confirm_delete"]="Löschen bestätigen",
            ["confirm_enable"]="Änderung anwenden?",
            ["delete_plans"]="{0} Energieplan/Energiepläne löschen?",
            ["cant_delete_active"]="Der aktive Energieplan kann nicht gelöscht werden. Wechseln Sie zuerst zu einem anderen Plan.",
            ["import_plan"]="Energieplan importieren", ["export_plan"]="Energieplan exportieren",
            ["ratio"]="Verhältnis", ["long"]="Lang", ["short"]="Kurz", ["fixed"]="Fest", ["variable"]="Variabel", ["boost"]="Boost", ["current"]="Aktuell",
            ["needs_admin"]="Diese Aktion erfordert Administratorrechte.",
            ["restart_driver"]="Anzeigetreiber neu starten", ["reset_all"]="Alles zurücksetzen", ["download_cru"]="CRU herunterladen",
            ["modify_quantum"]="Quantum ändern", ["quantum_length"]="Quantum-Länge", ["quantum_interval"]="Quantum-Intervall",
            ["fix"]="Fest", ["preview_hex"]="Hex-Vorschau", ["preview_bits"]="Bit-Vorschau",
            ["minimize"]="Minimieren", ["maximize"]="Maximieren", ["toggle_theme"]="Helles / dunkles Design wechseln",
            ["follow_theme"]="Windows-Design folgen", ["square"]="Eckige Ecken", ["rounded"]="Runde Ecken",
            ["join"]="BEITRETEN", ["follow"]="FOLGEN", ["visit"]="BESUCHEN", ["copy_link"]="Link kopieren", ["copied"]="Kopiert",
            ["no_profiles_found"]="Keine Profile gefunden. Lege .nip-Dateien im Ordner Nvidia Profiles ab.",
            ["confirm_disable"]="Diesen Schutz deaktivieren?",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="Sicherheit: ", ["power_plan_filter"]="Energieplan",
            ["theme_changed"]="Design gewechselt zu {0}", ["style_changed"]="Stil gewechselt zu {0}",
            ["powerplan_custom"]="Benutzerdefiniert", ["powerplan_restore"]="Offizielle wiederherstellen",
            ["update_available"]="Update {0} verfügbar", ["new_update"]="Neues Update: {0}", ["up_to_date"]="Auf dem neuesten Stand", ["update_check_failed"]="Updateprüfung fehlgeschlagen",
        
    };
}
