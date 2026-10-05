namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_it = new()
    {
 ["home"]="Home", ["browsers"]="Browser", ["tools"]="Strumenti", ["tweaking"]="Ottimizzazione", ["troubleshooting"]="Risoluzione problemi" 
    };
    private static readonly Dictionary<string, string> SectionDescs_it = new()
    {
 ["home"]="Benvenuto nella tua cassetta degli attrezzi", ["browsers"]="Utilità e correzioni per i browser", ["tools"]="Scarica ed esegue utilità portatili", ["tweaking"]="Ottimizzazioni di driver, GPU e sistema.", ["troubleshooting"]="Interruttori rapidi e correzioni del sistema." 
    };
    private static readonly Dictionary<string, string> TabTitles_it = new()
    {
 ["mainstream"]="Principali", ["privacy"]="Privacy", ["forks"]="Fork e personalizzati", ["software"]="Software", ["store-downloader"]="Downloader Microsoft Store", ["utilities"]="Utilità", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Registro", ["win32"]="Win32Priority", ["powerplans"]="Piani di alimentazione", ["connectivity"]="Connettività", ["devices"]="Dispositivi", ["security"]="Sicurezza", ["gaming"]="Giochi", ["ai"]="IA", ["debloat"]="Debloat", ["system"]="Sistema" , ["telemetry"]="Telemetria",
["app-privacy"]="Privacy delle app",
    };
    private static readonly Dictionary<string, string> Notifications_it = new()
    {
 ["opened"]="Aperto - avviato", ["installed"]="Installazione riuscita", ["failed"]="Installazione non riuscita", ["open_failed"]="Apertura non riuscita", ["enabled"]="Abilitato", ["disabled"]="Disabilitato", ["apply_failed"]="Applicazione non riuscita", ["applied"]="Applicato" , ["telemetry"]="Telemetria"
    };
    private static readonly Dictionary<string, string> Ui_it = new()
    {

            ["settings"]="Impostazioni", ["language"]="Lingua", ["theme"]="Tema", ["dark"]="Scuro", ["light"]="Chiaro", ["auto"]="Automatico", ["default_theme"]="Tema predefinito",
            ["style"]="Stile", ["win10_style"]="Stile Windows 10", ["win11_style"]="Stile Windows 11", ["close"]="Chiudi",
            ["search_placeholder"]="Cerca per nome, URL o ID.", ["store_no_results"]="Nessun risultato trovato. Prova un'altra ricerca.", ["search"]="Cerca", ["install"]="Installa",
            ["run"]="Esegui", ["download"]="Scarica", ["open"]="Apri", ["apply"]="Applica",
            ["check_updates"]="Verifica aggiornamenti", ["update"]="Aggiorna", ["disclaimer"]="Le modifiche sono sotto la tua esclusiva responsabilità.",
            ["quantum_title"]="Mappa Quantum", ["quantum_subtitle"]="Tutti i valori validi di Win32PrioritySeparation. Fai clic su una riga per applicarla.",
            ["open_quantum"]="Apri la mappa Quantum", ["current_win32"]="Win32PrioritySeparation corrente",
            ["load_list"]="Carica elenco", ["unload_list"]="Scarica elenco", ["activate"]="Attiva", ["import"]="Importa", ["export"]="Esporta",
            ["select_all"]="Seleziona tutto", ["unselect_all"]="Deseleziona tutto", ["uninstall"]="Disinstalla", ["delete"]="Elimina",
            ["restore_default"]="Ripristina predefiniti", ["yes"]="Sì", ["no"]="No",
            ["searching_for"]="Ricerca di '{0}' in corso...", ["downloading"]="Download di {0} in corso...", ["starting"]="Avvio di {0} in corso...",
            ["applying"]="Applicazione di {0} in corso...", ["installing"]="Installazione di {0} in corso...",             ["loading"]="Caricamento di {0} in corso...",
            ["reading_plans"]="Lettura dei piani di alimentazione in corso...", ["populating_list"]="Compilazione dell'elenco in corso...",
            ["apps_found"]="{0} app trovate", ["nothing_found"]="Nessun elemento trovato", ["loaded_items"]="{0} elementi caricati",
            ["list_unloaded"]="Elenco scaricato",
            ["exported"]="{0} esportato",
            ["installed_n"]="{0} app installate", ["install_failed"]="Installazione non riuscita",
            ["failed_admin"]="Non riuscito: esegui come amministratore o riavvia", ["failed"]="Non riuscito",
            ["win32_set"]="Win32PrioritySeparation impostato su {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_it = new()
    {
 ["run"]="Esegui", ["download"]="Scarica", ["apply"]="Applica", ["enable"]="Abilita", ["disable"]="Disabilita", ["search"]="Cerca", ["install"]="Installa", ["load list"]="Carica elenco", ["uninstall"]="Disinstalla", ["activate"]="Attiva", ["delete"]="Elimina", ["import .pow"]="Importa .pow", ["default"]="Predefinito", ["custom"]="Personalizzato", ["minimum"]="Minimo", ["disable mmcss"]="Disabilita MMCSS", ["bypass"]="Bypass", ["repeater"]="Ripetitore", ["realtime"]="Tempo reale", ["high"]="Alta", ["abovenormal"]="Sopra il normale", ["normal"]="Normale", ["belownormal"]="Sotto il normale", ["enhanced"]="Migliorata", ["legacy"]="Legacy", ["disabled"]="Disabilitato", ["enabled"]="Abilitato", ["alwayson"]="Sempre attiva", ["alwaysoff"]="Sempre disattiva", ["optin"]="Attivazione", ["optout"]="Disattivazione", ["open cru"]="Apri CRU", ["coming soon"]="Prossimamente", ["safe fivem/minecraft services"]="Servizi sicuri FiveM/Minecraft", ["kernelos default"]="Predefinito Superiorly" , ["telemetry"]="Telemetria"
    };
    private static readonly Dictionary<string, string> TabDescs_it = new()
    {
 ["mainstream"]="Browser per tutti i giorni.", ["privacy"]="Browser progettati per la privacy e l'anonimato.", ["forks"]="Build della community basate su Chromium e Firefox.", ["utilities"]="Strumenti per la diagnostica di sistema e hardware.", ["amd"]="Strumenti AMD GPU per driver, clock, voltaggi e Registro.", ["nvidia"]="Strumenti NVIDIA per installazioni pulite, profili e P-State.", ["connectivity"]="Impostazioni Wi-Fi, Bluetooth e limite hop dell'hotspot.", ["devices"]="Correzioni per stampante, Gestione attività e input di testo.", ["security"]="Isolamento del core, firewall, UAC, blocklist dei driver e protezioni della memoria.", ["gaming"]="Servizi Xbox e Opera GX.", ["ai"]="Navigazione Chromium, WebKit e incentrata sull'IA.", ["debloat"]="Criteri privacy dei browser e interruttori di telemetria dei vendor: Chrome, Edge, Firefox e Office.", ["system"]="Driver tramite Windows Update, menu Start e correzioni del pannello Intel." , ["telemetry"]="Interruttori per telemetria, suggerimenti, annunci e raccolta dati dei vendor.",
["app-privacy"]="Autorizzazioni delle app e opzioni privacy.",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_it = new()
    {
 ["browsers|gaming"]="Opera GX con limitatori integrati di CPU, RAM e rete.", ["tweaking|gaming"]="Servizi Xbox e servizi sicuri FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_it = new()
    {
 ["mainstream"]="Browser quotidiani", ["privacy"]="Navigazione anonima", ["forks"]="Fork indipendenti", ["utilities"]="Utilità di sistema", ["amd"]="Strumenti Radeon", ["nvidia"]="Strumenti GeForce", ["connectivity"]="Impostazioni wireless", ["devices"]="Correzioni dispositivi", ["security"]="Protezioni di sistema", ["gaming"]="Servizi di gioco", ["ai"]="Browser IA", ["debloat"]="Debloat browser", ["system"]="Correzioni Windows" , ["telemetry"]="Correzioni telemetria",
["app-privacy"]="Privacy delle app",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_it = new()
    {
 ["browsers|gaming"]="Browser da gioco", ["tweaking|gaming"]="Servizi di gioco" , ["troubleshooting|telemetry"]="Correzioni telemetria"
    };
    private static readonly Dictionary<string, string> UiExtra_it = new()
    {
["state_on"]="Attivato", ["state_off"]="Disattivato", 
            ["confirm_delete"]="Confermare l'eliminazione",
            ["confirm_enable"]="Applicare questa modifica?",
            ["confirm_disable"]="Disattivare questa protezione?",
            ["delete_plans"]="Eliminare {0} piani di alimentazione?",
            ["cant_delete_active"]="Impossibile eliminare il piano di alimentazione attivo. Passa prima a un altro piano.",
            ["import_plan"]="Importa piano di alimentazione", ["export_plan"]="Esporta piano di alimentazione",
            ["ratio"]="rapporto", ["long"]="Lungo", ["short"]="Breve", ["fixed"]="Fisso", ["variable"]="Variabile", ["boost"]="boost", ["current"]="corrente",
            ["needs_admin"]="Questa azione richiede privilegi di amministratore.",
            ["restart_driver"]="Riavvia driver dello schermo", ["reset_all"]="Reimposta tutto", ["download_cru"]="Scarica CRU",
            ["modify_quantum"]="Modifica Quantum", ["quantum_length"]="Durata Quantum", ["quantum_interval"]="Intervallo Quantum",
            ["fix"]="Correggi", ["preview_hex"]="Anteprima Hex", ["preview_bits"]="Anteprima bit",
            ["minimize"]="Riduci a icona", ["maximize"]="Ingrandisci", ["toggle_theme"]="Alterna tema chiaro/scuro",
            ["follow_theme"]="Segui il tema Windows", ["square"]="Angoli squadrati", ["rounded"]="Angoli arrotondati",
            ["join"]="UNISCITI", ["follow"]="SEGUI", ["visit"]="VISITA", ["copy_link"]="Copia collegamento", ["copied"]="Copiato",
            ["no_profiles_found"]="Nessun profilo trovato. Inserisci i file .nip nella cartella Nvidia Profiles.",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="Sicurezza: ", ["power_plan_filter"]="Piano di alimentazione",
            ["theme_changed"]="Tema cambiato in {0}", ["style_changed"]="Stile cambiato in {0}",
            ["powerplan_custom"]="Personalizzato", ["powerplan_restore"]="Ripristina ufficiali",
            ["update_available"]="Aggiornamento {0} disponibile", ["new_update"]="Nuovo aggiornamento: {0}", ["up_to_date"]="Tutto aggiornato", ["update_check_failed"]="Impossibile verificare gli aggiornamenti",
        
    };
}
