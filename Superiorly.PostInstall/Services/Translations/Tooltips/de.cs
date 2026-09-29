namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_de = new()
    {

            ["arc"]="Entwicklung eingefroren (2025), da die Firma auf den Dia-KI-Browser setzt; vergangene CVE erlaubte Session-Hijacking per Nutzer-ID; Sicherheitsteam wuchs von 1 auf 5.",
            ["operagx"]="Gleiche Mutter wie Opera: Chinas Kunlun Tech hält ~72 %. Die berühmten CPU-/RAM-Begrenzer sind weitgehend Kosmetik; Hindenburg-Vorwürfe betreffen den Konzern.",
            ["mullvad"]="Keine großen Skandale. Mit dem Tor Project co-entwickelt (2023); Mullvad VPN verweigerte bekanntermaßen Polizeizugriff.",
            ["thorium"]="Inoffizielle Chromium-Builds eines Entwicklers; für AVX2-CPUs optimiert; keine Reproduzierbarkeits­garantie – Vertrauenssache.",
            ["floorp"]="Japanisches Projekt, jahrelang Closed Source trotz Firefox; 2023 geöffnet. Community-governed, aber klein.",
            ["waterfox"]="An Werbefirma System1 verkauft (2020); Gründer Alex Kontos kaufte Unabhängigkeit zurück (2023). Seitdem keine Skandale.",
            ["ungoogled"]="Keine Skandale; der Preis ist manuelle Update-Prüfung und gelegentliche Seitenbrüche durch aggressive Google-Entfernung.",
            ["dia"]="Arc-Nachfolger, Invite-Beta; die KI liest Inhalte und Chatverlauf, um zu handeln; noch kein unabhängiges Audit.",
            ["avast-secure"]="Mutter Avast verkaufte Browserverläufe via Jumpshot (2020 geschlossen; 16,5-Mio.-USD-Vergleich mit FTC 2024); Avast-Antivirus pusht ihn stark.",
            ["librewolf"]="Keine großen Skandale. Einziger Kritikpunkt: Patches können Firefox-Release-Tage hinterherhinken, während die Community neu baut.",
            ["firefox"]="Mozilla lebt vom Google-Standarddeal; Telemetrie standardmäßig an; AGB 2025 deuteten kurz eine breite Datenlizenz an (nach Kritik zurückgenommen).",
            ["opera"]="~72 % bei Chinas Kunlun Tech (SEC-Akten). Hindenburg warf Fintech-Apps 365–876 % APR-Kredite vor. VPN von Deloitte auditiert (No-Log).",
            ["whale"]="Im Besitz des koreanischen Riesen Naver; südkoreanischem Datenrecht unterworfen; Seitenleisten-Dienste funken zu Naver.",
            ["kagi-orion"]="Closed Source; Windows-Port jung und rau. Kagis Bezahl-Suchmodell ist das Geschäft – Privatsphäre als Produkt, nicht Überwachung.",
            ["pale-moon"]="Uralte Goanna-Engine ohne Jahre an Chromium-/Firefox-Mitigationen; häufige Seitenbrüche; Ein-Maintainer-Projekt.",
            ["vivaldi"]="Liefert Affiliate-Lesezeichen und monetarisiert Standardsuche; UI Closed Source trotz offenem Kern. Dez. 2024: heimlich Ad-Attribution auf Partnersuchen für Umsatz aktiviert. Norwegische Firma, kein Profiling.",
            ["tor-browser"]="Für Zensurumgehung wie Darknet-Märkte genutzt; Exit-Nodes sehen Nicht-HTTPS-Verkehr; von Staaten und Seiten blockiert/markiert.",
            ["zen"]="Junges Projekt mit winzigem Team; noch kein unabhängiges Audit. Schnelle Releases können Regressionen bringen.",
            ["edge"]="Sendet eindeutige Geräte-IDs selbst bei ausgeschalteter Telemetrie; aggressive Bing-Werbung, gesponserte Vorschläge, penetrante Wechselaufforderungen.",
            ["falkon"]="QtWebEngine-Patches (Chromium-Kern) hinken hinterher; kleines KDE-Team; Windows-Builds weniger erprobt als Linux.",
            ["epic-browser"]="Trotz Datenschutzversprechen Closed Source: Tracker-Blockliste und Datenumgang nicht unabhängig auditierbar.",
            ["yandex"]="Russische Jurisdiktion: Gesetze erlauben Staatszugriff; Turbo-Modus proxyt Seiten über Yandex; Alice verarbeitet Sprache in Russland.",
            ["chrome"]="Kartellverfahren: DOJ setzte Abhilfen durch (Sept. 2025) – Google muss Suchdaten teilen, keine Exklusiv-Deals. Inkognito-Klage endete mit Löschung Milliarden Datensätze. Privacy Sandbox behält Profile im Haus.",
            ["brave"]="2020: Affiliate-Codes in Kryptobörsen-URLs auto-hinzugefügt (CEO entschuldigte sich). Brendan Eichs Prop-8-Spendenvergangenheit kocht periodisch hoch. Sonst starke Bilanz.",
            ["brave-debloat"]="Verwaltung durch Organisation. Braucht Brave 1.82+ (Playlist 1.84+).",
            ["edge-debloat"]="Verwaltung durch Organisation.",
            ["comet"]="Perplexitys KI-Browser: Inhalte gehen an KI-Modelle; Cloudflare warf aggressives Scraping vor (2025); agentisches Surfen wirft neue Fragen auf.",
            ["duckduckgo"]="2022: ließ Microsoft-Tracker wegen Bing-Syndizierungsdeal durch (Forscher Zach Edwards deckte auf); Aug. 2022 gepatcht.",
            ["chromium"]="Kein Auto-Updater unter Windows: Fixes hängen vom Ersteller Ihres Binaries ab; manche Google-APIs (Sync) entfernt.",
            ["cachy-browser"]="Nischen-Build der CachyOS-(Arch-)Community; erfordert AVX2; winzige Review-Fläche, weniger Augen als Mainstream.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_de = new()
    {

            ["arc"]="Kontobasierte Synchronisierung über Server von The Browser Company; KI sendet Inhalte an ihre Modelle.",
            ["operagx"]="Wie Opera: Browserdaten auf Opera-Servern; Gratis-VPN über Opera-Infrastruktur.",
            ["mullvad"]="Nichts: keine Telemetrie, keine Kennungen, Anti-Fingerprinting standardmäßig an.",
            ["thorium"]="Wie Chromium minus mehrerer Google-Dienste und Hintergrundanfragen.",
            ["floorp"]="Telemetrie standardmäßig aus; wenige Funktionen kontaktieren japanische Projektserver.",
            ["waterfox"]="Telemetrie entfernt; Monetarisierung nur über Partnersuchen.",
            ["ungoogled"]="Designbedingt keine Google-Verbindungen; keine Telemetrie; Websuche je nach Engine.",
            ["dia"]="Inhalte und Gespräche gehen an KI-Modelle von The Browser Company; Konto erforderlich.",
            ["avast-secure"]="Avast-Telemetrie und Werbeangebote; angesichts der Vorgeschichte Profiling annehmen, sofern nicht widerlegt.",
            ["librewolf"]="Standardmäßig nichts: Telemetrie, Pocket, Google-Dienste und Datensammlung zur Build-Zeit entfernt.",
            ["firefox"]="Telemetrie, Absturzberichte, standortbasierte Vorschläge; datenschutzfreundliche Ad-Messung (PPA).",
            ["opera"]="Browserdaten auf Opera-Servern verarbeitet; Gratis-VPN über Opera-Infrastruktur.",
            ["whale"]="Naver-Kontosync, Nutzungstelemetrie an Naver; Personalisierung an Naver gebunden.",
            ["kagi-orion"]="Zero-Telemetrie behauptet; keine Werbeprofile; Sync bei Apple via iCloud, lokal unter Windows.",
            ["pale-moon"]="Wenig Telemetrie, aber die veraltete Engine ist das größere Risiko.",
            ["vivaldi"]="Kein Profiling; Ende-zu-Ende-verschlüsselte Sync; Nutzungsstats nur per Opt-in.",
            ["tor-browser"]="Verkehr über 3 verschlüsselte Freiwilligen-Relays; keine Telemetrie; Login bricht eigene Anonymität.",
            ["zen"]="Firefox-basiert ohne Telemetrie; Updates über Mozilla-Infrastruktur.",
            ["edge"]="Diagnosedaten, Browserverlauf bei aktivem Sync, Werbe-ID für personalisierte Ads.",
            ["falkon"]="Minimale Telemetrie; KDE-Integration nur bei Nutzung dieser Dienste.",
            ["epic-browser"]="Behauptet keine Telemetrie und blockiert Tracker aggressiv; wegen Closed Code nicht verifizierbar.",
            ["yandex"]="Umfangreiche Telemetrie, Suche, Standort und Sprache an Yandex (Russland); personalisierte Werbung.",
            ["chrome"]="Synchronisiert Verlauf, Suchen, Standort und Sprache mit Google-Konto; Ad-Personalisierung standardmäßig.",
            ["brave"]="Designbedingt minimal: P3A-Privatsphärenstats (deaktivierbar), kein Such- oder Profil-Tracking.",
            ["brave-debloat"]="12 Richtlinien: deaktivieren Rewards, Wallet, VPN, Leo, Tor, News, Talk, Speedreader, Wayback, Playlist, P3A und Stats-Ping.",
            ["edge-debloat"]="14 Richtlinien : deaktivieren Shopping, Sidebars, Rewards, News, Widgets, Telemetrie.",
            ["comet"]="Browsing-Kontext von Perplexity-KI verarbeitet; Konto erforderlich; Verlauf ans Profil gebunden.",
            ["duckduckgo"]="Keine Werbeprofile; Suche mit anonymen Logs; Browser-Sync verschlüsselt.",
            ["chromium"]="Chrome-Engine ohne Google-Sync und -Dienste; Websuche je nach Engine.",
            ["cachy-browser"]="Chromium-basiert mit minimalen dokumentierten Patches; Telemetrie wie Upstream minus Google-Dienste.",
        
    };
}
