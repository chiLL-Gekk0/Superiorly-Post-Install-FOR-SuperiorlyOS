namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_pl = new()
    {
 ["home"]="Strona główna", ["browsers"]="Przeglądarki", ["tools"]="Narzędzia", ["tweaking"]="Optymalizacja", ["troubleshooting"]="Rozwiązywanie problemów" 
    };
    private static readonly Dictionary<string, string> SectionDescs_pl = new()
    {
 ["home"]="Witamy w skrzynce narzędziowej", ["browsers"]="Narzędzia i poprawki związane z przeglądarkami", ["tools"]="Pobieranie i uruchamianie narzędzi przenośnych", ["tweaking"]="Poprawki sterowników, GPU i systemu.", ["troubleshooting"]="Szybkie przełączniki i poprawki systemu." 
    };
    private static readonly Dictionary<string, string> TabTitles_pl = new()
    {
 ["mainstream"]="Popularne", ["privacy"]="Prywatność", ["forks"]="Forki i niestandardowe", ["software"]="Oprogramowanie", ["store-downloader"]="Program pobierający Microsoft Store", ["utilities"]="Narzędzia", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Poprawki rejestru", ["win32"]="Win32Priority", ["powerplans"]="Plany zasilania", ["connectivity"]="Łączność", ["devices"]="Urządzenia", ["security"]="Ochrona", ["gaming"]="Gry", ["ai"]="SI", ["debloat"]="Debloat", ["system"]="System" , ["telemetry"]="Telemetria",
["app-privacy"]="Prywatność aplikacji",
    };
    private static readonly Dictionary<string, string> Notifications_pl = new()
    {
 ["opened"]="Otwarto - uruchomiono", ["installed"]="Pomyślnie zainstalowano", ["failed"]="Instalacja nie powiodła się", ["open_failed"]="Nie można otworzyć", ["enabled"]="Włączono", ["disabled"]="Wyłączono", ["apply_failed"]="Nie można zastosować", ["applied"]="Zastosowano" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_pl = new()
    {

            ["settings"]="Ustawienia", ["language"]="Język", ["theme"]="Motyw", ["dark"]="Ciemny", ["light"]="Jasny", ["auto"]="Automatyczny", ["default_theme"]="Domyślny motyw",
            ["style"]="Styl", ["win10_style"]="Styl Windows 10", ["win11_style"]="Styl Windows 11", ["close"]="Zamknij",
            ["search_placeholder"]="Wyszukiwanie według nazwy, adresu URL lub identyfikatora.", ["store_no_results"]="Nie znaleziono wyników. Proszę spróbować innego wyszukiwania.", ["search"]="Szukaj", ["install"]="Instaluj",
            ["run"]="Uruchom", ["download"]="Pobierz", ["open"]="Otwórz", ["apply"]="Zastosuj",
            ["check_updates"]="Sprawdź aktualizacje", ["update"]="Aktualizuj", ["disclaimer"]="Modyfikacje wykonywane są na własną odpowiedzialność.",
            ["quantum_title"]="Mapa Quantum", ["quantum_subtitle"]="Wszystkie prawidłowe wartości Win32PrioritySeparation. Wybranie wiersza powoduje zastosowanie wartości.",
            ["open_quantum"]="Otwórz mapę Quantum", ["current_win32"]="Bieżący Win32PrioritySeparation",
            ["load_list"]="Załaduj listę", ["unload_list"]="Zamknij listę", ["activate"]="Aktywuj", ["import"]="Importuj", ["export"]="Eksportuj",
            ["select_all"]="Zaznacz wszystko", ["unselect_all"]="Odznacz wszystko", ["uninstall"]="Odinstaluj", ["delete"]="Usuń",
            ["restore_default"]="Przywróć domyślne", ["yes"]="Tak", ["no"]="Nie",
            ["searching_for"]="Wyszukiwanie '{0}'...", ["downloading"]="Pobieranie {0}...", ["starting"]="Uruchamianie {0}...",
            ["applying"]="Stosowanie {0}...", ["installing"]="Instalowanie {0}...",             ["loading"]="Ładowanie {0}...",
            ["reading_plans"]="Odczytywanie planów zasilania...", ["populating_list"]="Tworzenie listy...",
            ["apps_found"]="Znaleziono aplikacji: {0}", ["nothing_found"]="Nie znaleziono nic", ["loaded_items"]="Załadowano elementów: {0}",
            ["list_unloaded"]="Lista zamknięta",
            ["exported"]="Wyeksportowano {0}",
            ["installed_n"]="Zainstalowano aplikacji: {0}", ["install_failed"]="Instalacja nie powiodła się",
            ["failed_admin"]="Niepowodzenie - Wymagane uruchomienie jako administrator lub ponowne uruchomienie.", ["failed"]="Niepowodzenie",
            ["win32_set"]="Ustawiono Win32PrioritySeparation na {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_pl = new()
    {
 ["run"]="Uruchom", ["download"]="Pobierz", ["apply"]="Zastosuj", ["enable"]="Włącz", ["disable"]="Wyłącz", ["search"]="Szukaj", ["install"]="Instaluj", ["load list"]="Załaduj listę", ["uninstall"]="Odinstaluj", ["activate"]="Aktywuj", ["delete"]="Usuń", ["import .pow"]="Importuj .pow", ["default"]="Domyślne", ["custom"]="Niestandardowe", ["full"]="Pełny", ["reduced"]="Zmniejszony", ["minimum"]="Minimalne", ["disable mmcss"]="Wyłącz MMCSS", ["bypass"]="Obejście", ["repeater"]="Powtarzacz", ["realtime"]="Czas rzeczywisty", ["high"]="Wysoki", ["abovenormal"]="Powyżej normalnego", ["normal"]="Normalny", ["belownormal"]="Poniżej normalnego", ["enhanced"]="Ulepszony", ["legacy"]="Starszy", ["disabled"]="Wyłączono", ["enabled"]="Włączono", ["alwayson"]="Zawsze włączone", ["alwaysoff"]="Zawsze wyłączone", ["optin"]="Selektywne włączenie", ["optout"]="Selektywne wyłączenie", ["open cru"]="Otwórz CRU", ["coming soon"]="Wkrótce", ["safe fivem/minecraft services"]="Bezpieczne usługi FiveM/Minecraft", ["kernelos default"]="Domyślne Superiorly" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> TabDescs_pl = new()
    {
 ["mainstream"]="Codzienne przeglądarki.", ["privacy"]="Przeglądarki nastawione na prywatność i anonimowość.", ["forks"]="Społecznościowe kompilacje oparte na Chromium i Firefox.", ["utilities"]="Narzędzia do diagnostyki systemu i sprzętu.", ["amd"]="Narzędzia AMD GPU do sterowników, taktowania, napięcia i rejestru.", ["nvidia"]="Narzędzia NVIDIA do czystej instalacji, profili i stanów P-States.", ["connectivity"]="Ustawienia Wi-Fi, Bluetooth i limitu przeskoków hotspotu.", ["devices"]="Poprawki drukarki, Menedżera zadań i wprowadzania tekstu.", ["security"]="Izolacja rdzenia, zapora, UAC, lista blokowanych sterowników i ochrona pamięci.", ["gaming"]="Usługi Xbox i Opera GX.", ["ai"]="Przeglądanie Chromium, WebKit i oparte na SI.", ["debloat"]="Polityki prywatności przeglądarek i przełączniki telemetrii dostawców: Chrome, Edge, Firefox i Office.", ["system"]="Sterowniki przez Windows Update, menu Start i poprawki panelu Intel." , ["telemetry"]="Przełączniki telemetrii, sugestii, reklam i zbierania danych przez dostawców.",
["app-privacy"]="Uprawnienia aplikacji i ustawienia prywatności.",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_pl = new()
    {
 ["browsers|gaming"]="Opera GX z wbudowanymi ogranicznikami CPU, RAM i sieci.", ["tweaking|gaming"]="Usługi Xbox oraz bezpieczne usługi FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_pl = new()
    {
 ["mainstream"]="Codzienne przeglądarki", ["privacy"]="Anonimowe przeglądanie", ["forks"]="Niezależne forki", ["utilities"]="Narzędzia systemowe", ["amd"]="Narzędzia Radeon", ["nvidia"]="Narzędzia GeForce", ["connectivity"]="Ustawienia bezprzewodowe", ["devices"]="Poprawki urządzeń", ["security"]="Ochrona systemu", ["gaming"]="Usługi gier", ["ai"]="Przeglądarki SI", ["debloat"]="Odchudzanie przeglądarek", ["system"]="Poprawki Windows" , ["telemetry"]="Poprawki telemetrii",
["app-privacy"]="Prywatność aplikacji",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_pl = new()
    {
 ["browsers|gaming"]="Przeglądarka dla graczy"
    };
    private static readonly Dictionary<string, string> UiExtra_pl = new()
    {
["state_on"]="Włączony", ["state_off"]="Wyłączony", 
            ["confirm_delete"]="Potwierdź usunięcie",
            ["confirm_enable"]="Zastosować tę zmianę?",
            ["delete_plans"]="Usunąć planów zasilania: {0}?",
            ["cant_delete_active"]="Nie można usunąć aktywnego planu zasilania. Najpierw należy przełączyć na inny plan.",
            ["import_plan"]="Importuj plan zasilania", ["export_plan"]="Eksportuj plan zasilania",
            ["ratio"]="proporcja", ["long"]="Długi", ["short"]="Krótki", ["fixed"]="Stały", ["variable"]="Zmienny", ["boost"]="wzmocnienie", ["current"]="bieżący",
            ["needs_admin"]="Ta operacja wymaga uprawnień administratora.",
            ["restart_driver"]="Uruchom ponownie sterownik ekranu", ["reset_all"]="Zresetuj wszystko", ["download_cru"]="Pobierz CRU",
            ["modify_quantum"]="Zmodyfikuj Quantum", ["quantum_length"]="Długość Quantum", ["quantum_interval"]="Interwał Quantum",
            ["fix"]="Napraw", ["preview_hex"]="Podgląd Hex", ["preview_bits"]="Podgląd bitów",
            ["minimize"]="Zminimalizuj", ["maximize"]="Zmaksymalizuj", ["toggle_theme"]="Przełącz motyw jasny i ciemny",
            ["follow_theme"]="Podążaj za motywem Windows", ["square"]="Kwadratowe rogi", ["rounded"]="Zaokrąglone rogi",
            ["join"]="DOŁĄCZ", ["follow"]="OBSERWUJ", ["visit"]="ODWIEDŹ", ["copy_link"]="Kopiuj link", ["copied"]="Skopiowano",
            ["no_profiles_found"]="Nie znaleziono profili. Umieść pliki .nip w folderze Nvidia Profiles.",
            ["confirm_disable"]="Wyłączyć tę ochronę?",
            ["home_discord_desc"]="Społeczność Superiorly",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0", ["welcome"]="WITAJ", ["hero_tagline"]="DO SUPERIORLY",
            ["security"]="Zabezpieczenia: ", ["power_plan_filter"]="Plan zasilania",
            ["theme_changed"]="Zmieniono motyw na {0}", ["style_changed"]="Zmieniono styl na {0}",
            ["powerplan_custom"]="Niestandardowy", ["powerplan_restore"]="Przywróć oficjalne",
            ["update_available"]="Dostępna aktualizacja {0}", ["new_update"]="Nowa aktualizacja: {0}", ["up_to_date"]="System jest aktualny", ["update_check_failed"]="Nie można sprawdzić aktualizacji",
        
    };
}
