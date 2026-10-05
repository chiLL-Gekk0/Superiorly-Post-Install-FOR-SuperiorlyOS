namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_it = new()
    {

            ["arc"]="Funzionalità congelate (2025) mentre l'azienda punta sul browser IA Dia, ma continua a ricevere aggiornamenti di sicurezza Chromium settimanali; nel CVE-2024-45489 ACL Firebase mal configurate permettevano di eseguire JavaScript arbitrario nel contesto di sincronizzazione privilegiato di un altro utente (segnalato da xyz3va; zero utenti interessati); il team sicurezza è cresciuto da 1 a 5.",
            ["operagx"]="Stessa casa madre di Opera: la cinese Kunlun Tech detiene circa il 72%. I famosi limitatori CPU/RAM sono perlopiù cosmetici; le accuse di Hindenburg valgono per il gruppo.",
            ["mullvad"]="Nessuno scandalo rilevante. Co-sviluppato con il Tor Project (2023); la VPN Mullvad rifiutò notoriamente richieste di accesso della polizia.",
            ["thorium"]="Build Chromium non ufficiali di un singolo sviluppatore; ottimizzate per CPU AVX2; nessuna garanzia di build riproducibili, quindi devi fidarti del maintainer.",
            ["floorp"]="Progetto giapponese rimasto closed source per anni nonostante Firefox; codice aperto nel 2023. Governance guidata dalla community ma ristretta.",
            ["waterfox"]="Venduto alla società pubblicitaria System1 (2020); il fondatore Alex Kontos ne riacquistò l'indipendenza (2023). Nessuno scandalo da allora.",
            ["ungoogled"]="Nessuno scandalo; il compromesso è il controllo manuale degli aggiornamenti e qualche sito che si rompe per la rimozione aggressiva delle dipendenze Google.",
            ["dia"]="Successore di Arc, disponibile a tutti su macOS dall'8 ottobre 2025; l'IA legge contenuti delle pagine e cronologia chat per agire al tuo posto; The Browser Company è stata acquisita da Atlassian per 610 milioni di dollari.",
            ["avast-secure"]="La casa madre Avast fu sorpresa a vendere cronologie di navigazione tramite la controllata Jumpshot (chiusa nel 2020; accordo FTC da 16,5M$ nel 2024); il browser è spinto aggressivamente dall'antivirus Avast.",
            ["librewolf"]="Nessuno scandalo rilevante. Unico neo: le patch di sicurezza possono arrivare con giorni di ritardo su Firefox mentre la community ricompila.",
            ["firefox"]="Mozilla ricava gran parte dei ricavi dall'accordo di default con Google; telemetria attiva per impostazione predefinita; i ToS 2025 implicarono brevemente un'ampia licenza sui dati (ritirata dopo le proteste).",
            ["opera"]="Detenuta circa al 72% dalla cinese Kunlun Tech (atti SEC). Hindenburg Research accusò le sue app fintech di prestiti con TAEG 365-876%. VPN verificata da Deloitte (no-log).",
            ["whale"]="Di proprietà del colosso coreano Naver; soggetto alla legge coreana sui dati; i servizi della barra laterale (traduzione, shopping) contattano Naver.",
            ["kagi-orion"]="Closed source; la versione Windows è giovane e acerba. Il modello a pagamento di Kagi è il business: privacy come prodotto, non sorveglianza.",
            ["pale-moon"]="Il vetusto motore Goanna manca di anni di mitigazioni di sicurezza Chromium/Firefox; siti rotti frequenti; progetto di un singolo maintainer.",
            ["vivaldi"]="Include segnalibri affiliati e monetizza la ricerca predefinita (affiliazione Google); l'interfaccia è closed source anche se il core Chromium è aperto. Dic 2024: attivò in segreto script di attribuzione annunci sui motori partner per ricavi. Azienda norvegese, nessuna profilazione.",
            ["tor-browser"]="Usato sia per aggirare la censura sia per i darknet market (Silk Road); i nodi di uscita vedono il traffico non HTTPS; bloccato o segnalato da alcuni governi e siti.",
            ["zen"]="Progetto giovane con un team minuscolo; nessuna revisione di sicurezza indipendente ancora. Release rapide possono introdurre regressioni.",
            ["edge"]="Invia ID univoci del dispositivo anche con telemetria disattivata; annunci aggressivi della barra Bing, suggerimenti sponsorizzati e insistenti inviti a tornare indietro.",
            ["falkon"]="Le patch di sicurezza di QtWebEngine (core Chromium) arrivano in ritardo sull'upstream; piccolo team KDE; build Windows meno collaudate di quelle Linux.",
            ["epic-browser"]="Closed source nonostante le promesse privacy: blocklist dei tracker e gestione dati non verificabili in modo indipendente.",
            ["yandex"]="Giurisdizione russa: le leggi sui dati consentono l'accesso statale (SORM); la modalità Turbo instrada le pagine tramite i server Yandex; l'assistente Alice elabora la voce in Russia.",
            ["chrome"]="Caso antitrust: il DOJ ottenne rimedi (sett 2025): Google deve condividere i dati di ricerca con i rivali, niente accordi esclusivi di default. La causa sul tracciamento in incognito si chiuse con la cancellazione di miliardi di record. La maggior parte delle API di misurazione pubblicitaria di Privacy Sandbox è stata ritirata nell'ottobre 2025 e Google ha mantenuto i cookie di terze parti, quindi il tracciamento pubblicitario tra siti non è limitato a Google.",
            ["brave"]="2020: aggiunse automaticamente codici affiliati agli URL degli exchange crypto (il CEO si scusò). La donazione Prop-8 del fondatore Brendan Eich riemerge periodicamente. Per il resto solido record privacy.",
            ["comet"]="Browser IA di Perplexity: i contenuti delle pagine sono inviati ai modelli IA; iniezione indiretta di prompt divulgata da Brave (20/08/2025) e CometJacking divulgato da LayerX (04/10/2025).",
            ["duckduckgo"]="2022: il suo browser lasciava passare i tracker Microsoft per un accordo di sindacazione Bing (lo scoprì il ricercatore Zach Edwards); corretto ad agosto 2022.",
            ["chromium"]="Nessun aggiornamento automatico nelle build Windows: le fix di sicurezza dipendono da chi compila il binario (Hibbiki, ecc.); alcune API Google (sync) rimosse.",
            ["cachy-browser"]="Build di nicchia della community CachyOS (Arch); richiede AVX2; superficie di revisione minima, meno occhi sul codice dei browser mainstream.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_it = new()
    {

            ["arc"]="Sincronizzazione via account sui server di The Browser Company; le funzioni IA inviano i contenuti delle pagine ai fornitori di servizio OpenAI e Anthropic, opt-in per funzione.",
            ["operagx"]="Come Opera: dati di navigazione sui server Opera; VPN gratuita tramite infrastruttura Opera.",
            ["mullvad"]="Niente: nessuna telemetria, nessun identificatore, anti-fingerprinting attivo per impostazione predefinita.",
            ["thorium"]="Come Chromium meno diversi servizi Google e richieste in background.",
            ["floorp"]="Telemetria disabilitata per impostazione predefinita; alcune funzioni contattano i server del progetto giapponese.",
            ["waterfox"]="Telemetria rimossa; monetizzazione solo tramite motori di ricerca partner.",
            ["ungoogled"]="Nessuna connessione Google per progettazione; nessuna telemetria; le ricerche Web dipendono dal motore scelto.",
            ["dia"]="Contenuti delle pagine e conversazioni inviati ai fornitori di servizi IA usati da The Browser Company per le sue funzioni IA; account richiesto.",
            ["avast-secure"]="Telemetria Avast e offerte promozionali; visto il passato della casa madre, presume profilazione fino a prova contraria.",
            ["librewolf"]="Niente per impostazione predefinita: telemetria, Pocket, servizi Google e raccolta dati rimossi in fase di build.",
            ["firefox"]="Telemetria, segnalazioni crash e suggerimenti basati sulla posizione; esperimenti di misurazione pubblicitaria PPA.",
            ["opera"]="Dati di navigazione elaborati sui server Opera; la VPN gratuita instrada il traffico tramite infrastruttura Opera.",
            ["whale"]="Sincronizzazione account Naver, telemetria d'uso ai server Naver; personalizzazione legata ai servizi Naver.",
            ["kagi-orion"]="Zero telemetria dichiarata; nessun profilo pubblicitario; sync su Apple via iCloud, locale su Windows.",
            ["pale-moon"]="Telemetria ridotta, ma il motore obsoleto è il rischio maggiore.",
            ["vivaldi"]="Nessuna profilazione; sincronizzazione cifrata end-to-end; statistiche d'uso solo con opt-in.",
            ["tor-browser"]="Il traffico passa per 3 relay volontari cifrati; nessuna telemetria; accedi ad account personali e rompi il tuo stesso anonimato.",
            ["zen"]="Basato su Firefox con telemetria disattivata; gli aggiornamenti passano dall'infrastruttura Mozilla.",
            ["edge"]="Dati diagnostici, cronologia di navigazione con sync attiva, ID pubblicità per annunci personalizzati.",
            ["falkon"]="Telemetria minima; integrazione desktop KDE solo se usi quei servizi.",
            ["epic-browser"]="Dichiara nessuna telemetria e blocco aggressivo dei tracker; non verificabile per il codice chiuso.",
            ["yandex"]="Telemetria estesa, dati di ricerca, posizione e voce a Yandex (Russia); annunci personalizzati.",
            ["chrome"]="Sincronizza cronologia, ricerche, posizione e voce con l'account Google; personalizzazione annunci per impostazione predefinita.",
            ["brave"]="Minimo per progettazione: statistiche P3A anonime (disabilitabili), nessun tracciamento di ricerche o profilo.",
            ["comet"]="Contesto di navigazione elaborato dall'IA Perplexity; account richiesto; cronologia ricerche legata al profilo Perplexity.",
            ["duckduckgo"]="Nessun profilo pubblicitario; ricerca con log anonimi; sincronizzazione browser cifrata.",
            ["chromium"]="Motore Chrome senza sync e servizi Google; le ricerche Web dipendono dal motore scelto.",
            ["cachy-browser"]="Basato su Chromium con patch minime documentate; telemetria secondo i default Chromium upstream meno i servizi Google.",
        
    };
}
