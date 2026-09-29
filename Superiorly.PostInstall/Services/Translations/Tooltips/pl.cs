namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_pl = new()
    {

            ["arc"]="Rozwój zamrożony (2025), bo firma stawia na przeglądarkę Dia AI; dawny CVE pozwalał przejmować sesje przez ID użytkownika; zespół bezpieczeństwa urósł z 1 do 5 osób.",
            ["operagx"]="Ta sama spółka-matka co Opera: chiński Kunlun Tech ma ~72%. Słynne limitery CPU/RAM są głównie kosmetyczne; zarzuty Hindenburg dotyczą grupy.",
            ["mullvad"]="Bez większych skandali. Współtworzona z Tor Project (2023); VPN Mullvad odmówił policyjnych żądań dostępu.",
            ["thorium"]="Nieoficjalne kompilacje Chromium jednego dewelopera; zoptymalizowane pod CPU AVX2; bez gwarancji builds odtwarzalnych, więc ufasz opiekunowi.",
            ["floorp"]="Japoński projekt latami zamknięty mimo Firefoksa; kod otwarty w 2023. Zarządzanie społecznościowe, ale małe.",
            ["waterfox"]="Sprzedany reklamowej System1 (2020); założyciel Alex Kontos odkupił niezależność (2023). Od tego czasu bez skandali.",
            ["ungoogled"]="Bez skandali; ceną ręczne sprawdzanie aktualizacji i sporadyczne psucie stron przez agresywne usuwanie zależności Google.",
            ["dia"]="Następca Arc, beta na zaproszenia; AI czyta treść stron i historię czatu, by działać za Ciebie; brak niezależnego audytu bezpieczeństwa.",
            ["avast-secure"]="Spółka-matka Avast sprzedawała historie przez Jumpshot (zamknięty w 2020; ugoda $16.5M z FTC w 2024); przeglądarka mocno promowana przez Avast antivirus.",
            ["librewolf"]="Bez większych skandali. Jedyny zarzut: łatki mogą spóźniać się dni za Firefoksem, gdy społeczność przebudowuje.",
            ["firefox"]="Mozilla żyje głównie z umowy Google jako domyślnej; telemetria domyślnie włączona; w 2025 regulamin krótko sugerował szeroką licencję na dane (wycofano po krytyce).",
            ["opera"]="~72% u chińskiego Kunlun Tech (dokumenty SEC). Hindenburg Research zarzucił aplikacjom fintech pożyczki 365-876% APR. VPN audytowany przez Deloitte (bez logów).",
            ["whale"]="Własność koreańskiego giganta Naver; podlega południowokoreańskiemu prawu o danych; usługi boczne (tłumacz, zakupy) łączą się z Naver.",
            ["kagi-orion"]="Kod zamknięty; wersja Windows młoda i niedopracowana. Płatny model wyszukiwania Kagi to biznes: prywatność jako produkt, nie inwigilacja.",
            ["pale-moon"]="Starożytny silnik Goanna bez lat zabezpieczeń Chromium/Firefox; częste psucie stron; projekt jednego opiekuna.",
            ["vivaldi"]="Dostarcza afiliacyjne zakładki i zarabia na domyślnym wyszukiwaniu; UI zamknięte, choć rdzeń Chromium otwarty. Gru. 2024: po cichu włączył skrypty atrybucji reklam u partnerów dla przychodu. Norweska firma, bez profilowania.",
            ["tor-browser"]="Służy obchodzeniu cenzury i rynkom darknetu; węzły wyjściowe widzą ruch inny niż HTTPS; blokowany lub oznaczany przez rządy i strony.",
            ["zen"]="Młody projekt z małym zespołem; brak niezależnego audytu. Szybkie wydania mogą przynosić regresje.",
            ["edge"]="Wysyła unikalne ID urządzeń nawet przy wyłączonej telemetrii; agresywne reklamy Bing na pasku bocznym, sponsorowane sugestie i uporczywe zachęty do powrotu.",
            ["falkon"]="Łatki QtWebEngine (rdzeń Chromium) spóźnione wobec upstream; mały zespół KDE; kompilacje Windows mniej przetestowane niż linuksowe.",
            ["epic-browser"]="Kod zamknięty mimo obietnic prywatności: listy trackerów i przetwarzania danych nie da się niezależnie audytować.",
            ["yandex"]="Jurysdykcja rosyjska: przepisy pozwalają na dostęp państwa (SORM); tryb Turbo proxiuje strony przez serwery Yandex; asystent Alice przetwarza głos w Rosji.",
            ["chrome"]="Sprawa antymonopolowa: DOJ wywalczył środki (wrz. 2025) — Google musi dzielić się danymi wyszukiwania, bez wyłącznych umów. Pozew o incognito zakończył się usunięciem miliardów rekordów. Privacy Sandbox trzyma profilowanie u siebie.",
            ["brave"]="2020: automatycznie dodawał kody afiliacyjne do URL giełd krypto (CEO przeprosił). Przeszłość darowizn Brendan Eich okresowo wraca. Poza tym solidna reputacja.",
            ["brave-debloat"]="Wyświetla się jako zarządzana przez Twoją organizację.",
            ["edge-debloat"]="Wyświetla się jako zarządzana przez Twoją organizację.",
            ["comet"]="Przeglądarka AI Perplexity: treść trafia do modeli AI; Cloudflare oskarżył o agresywne scraping (2025); przeglądanie agentowe rodzi nowe pytania.",
            ["duckduckgo"]="W 2022 przepuszczała trackery Microsoft z powodu umowy z Bing (ujawnił Zach Edwards); naprawiono w sierpniu 2022.",
            ["chromium"]="Brak auto-aktualizacji w Windows: poprawki zależą od tego, kto kompiluje Twój binary; część API Google (sync) usunięta.",
            ["cachy-browser"]="Niszowa kompilacja społeczności CachyOS (Arch); wymaga AVX2; wąska powierzchnia przeglądu, mniej oczu niż w głównych przeglądarkach.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_pl = new()
    {

            ["arc"]="Synchronizacja konta przez serwery The Browser Company; funkcje AI wysyłają treść do modeli.",
            ["operagx"]="Jak Opera: dane przeglądania na serwerach Opera; darmowy VPN przez infrastrukturę Opera.",
            ["mullvad"]="Brak: bez telemetrii i identyfikatorów, anti-fingerprinting domyślnie włączony.",
            ["thorium"]="Jak Chromium minus kilka usług Google i żądań w tle.",
            ["floorp"]="Telemetria domyślnie wyłączona; kilka funkcji kontaktuje japońskie serwery projektu.",
            ["waterfox"]="Telemetria usunięta; zarobek tylko przez partnerskie wyszukiwarki.",
            ["ungoogled"]="Z projektu bez połączeń Google; bez telemetrii; wyszukiwanie zależy od wybranego silnika.",
            ["dia"]="Treść i rozmowy trafiają do modeli AI The Browser Company; wymagane konto.",
            ["avast-secure"]="Telemetria Avast i oferty promocyjne; zważywszy na przeszłość spółki-matki zakładaj profilowanie, dopóki nie udowodniono inaczej.",
            ["librewolf"]="Domyślnie nic: telemetria, Pocket, usługi Google i zbieranie danych usunięte podczas kompilacji.",
            ["firefox"]="Telemetria, raporty awarii i sugestie lokalizacyjne; eksperymenty prywatnego pomiaru reklam (PPA).",
            ["opera"]="Dane przetwarzane na serwerach Opera; darmowy VPN prowadzi przez infrastrukturę Opera.",
            ["whale"]="Synchronizacja konta Naver, telemetria użycia do Naver; personalizacja związana z usługami Naver.",
            ["kagi-orion"]="Deklarowane zero telemetrii; bez profili reklamowych; synchronizacja na Apple przez iCloud, lokalnie na Windows.",
            ["pale-moon"]="Mało telemetrii, ale przestarzały silnik to większe ryzyko.",
            ["vivaldi"]="Bez profilowania; synchronizacja szyfrowana end-to-end; statystyki tylko za zgodą.",
            ["tor-browser"]="Ruch przez 3 szyfrowane wolontariackie relay; bez telemetrii; logowanie na prywatne konta łamie Twoją anonimowość.",
            ["zen"]="Na Firefoksie bez telemetrii; aktualizacje przez infrastrukturę Mozilla.",
            ["edge"]="Dane diagnostyczne, historia przy włączonej synchronizacji, ID reklamowe do spersonalizowanych reklam.",
            ["falkon"]="Minimalna telemetria; integracja KDE tylko przy użyciu tych usług.",
            ["epic-browser"]="Deklaruje brak telemetrii i agresywnie blokuje trackery; nieweryfikowalne przez zamknięty kod.",
            ["yandex"]="Rozległa telemetria, wyszukiwanie, lokalizacja i głos do Yandex (Rosja); spersonalizowane reklamy.",
            ["chrome"]="Synchronizuje historię, wyszukiwania, lokalizację i głos z kontem Google; domyślna personalizacja reklam.",
            ["brave"]="Minimum z projektu: prywatne statystyki P3A (wyłączalne), bez śledzenia wyszukiwań i profili.",
            ["brave-debloat"]="Wyłącza dodatki i telemetrię.",
            ["edge-debloat"]="Wyłącza zakupy, dodatki i telemetrię.",
            ["comet"]="Kontekst przeglądania przetwarza Perplexity AI; wymagane konto; historia związana z profilem Perplexity.",
            ["duckduckgo"]="Bez profili reklamowych; wyszukiwanie z anonimowymi logami; synchronizacja szyfrowana.",
            ["chromium"]="Silnik Chrome bez synchronizacji i usług Google; wyszukiwanie zależy od silnika.",
            ["cachy-browser"]="Na Chromium z minimalnymi udokumentowanymi łatkami; telemetria jak upstream Chromium minus usługi Google.",
        
    };
}
