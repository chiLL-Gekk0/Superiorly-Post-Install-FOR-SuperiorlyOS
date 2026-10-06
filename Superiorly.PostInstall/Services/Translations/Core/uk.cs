namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_uk = new()
    {
 ["home"]="Головна", ["browsers"]="Браузери", ["tools"]="Інструменти", ["tweaking"]="Налаштування", ["troubleshooting"]="Усунення несправностей"
    };
    private static readonly Dictionary<string, string> SectionDescs_uk = new()
    {
 ["home"]="Ласкаво просимо до вашої скриньки інструментів", ["browsers"]="Утиліти та виправлення для браузерів", ["tools"]="Завантаження та запуск портативних утиліт", ["tweaking"]="Налаштування драйверів, GPU та системи.", ["troubleshooting"]="Швидкі перемикачі та виправлення ОС."
    };
    private static readonly Dictionary<string, string> TabTitles_uk = new()
    {
 ["mainstream"]="Популярні", ["privacy"]="Конфіденційність", ["forks"]="Форки та кастомні", ["software"]="Програми", ["store-downloader"]="Завантажувач Microsoft Store", ["utilities"]="Утиліти", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Реєстр", ["win32"]="Win32Priority", ["powerplans"]="Схеми живлення", ["connectivity"]="Підключення", ["devices"]="Пристрої", ["security"]="Захист", ["gaming"]="Ігри", ["ai"]="ШІ", ["debloat"]="Деблот", ["system"]="Система" , ["telemetry"]="Телеметрія",
["app-privacy"]="Приватність застосунків",
    };
    private static readonly Dictionary<string, string> Notifications_uk = new()
    {
 ["opened"]="Відкрито — запущено", ["installed"]="Успішно встановлено", ["failed"]="Не вдалося встановити", ["open_failed"]="Не вдалося відкрити", ["enabled"]="Увімкнено", ["disabled"]="Вимкнено", ["apply_failed"]="Не вдалося застосувати", ["applied"]="Застосовано" , ["telemetry"]="Телеметрія"
    };
    private static readonly Dictionary<string, string> Ui_uk = new()
    {

            ["settings"]="Налаштування", ["language"]="Мова", ["theme"]="Тема", ["dark"]="Темна", ["light"]="Світла", ["auto"]="Авто", ["default_theme"]="Тема за замовчуванням",
            ["style"]="Стиль", ["win10_style"]="У стилі Windows 10", ["win11_style"]="У стилі Windows 11", ["close"]="Закрити",
            ["search_placeholder"]="Пошук за назвою, URL або ID.", ["store_no_results"]="Нічого не знайдено. Спробуйте інший запит.", ["search"]="Пошук", ["install"]="Встановити",
            ["run"]="Запустити", ["download"]="Завантажити", ["open"]="Відкрити", ["apply"]="Застосувати",
            ["check_updates"]="Перевірити оновлення", ["update"]="Оновити", ["disclaimer"]="Зміни — ваша виключна відповідальність.",
            ["quantum_title"]="Квантова мапа", ["quantum_subtitle"]="Усі допустимі значення Win32PrioritySeparation. Клацніть рядок, щоб застосувати.",
            ["open_quantum"]="Відкрити квантову мапу", ["current_win32"]="Поточне Win32PrioritySeparation",
            ["load_list"]="Завантажити список", ["unload_list"]="Вивантажити список", ["activate"]="Активувати", ["import"]="Імпортувати", ["export"]="Експортувати",
            ["select_all"]="Вибрати все", ["unselect_all"]="Зняти вибір", ["uninstall"]="Видалити", ["delete"]="Видалити",
            ["restore_default"]="Відновити за замовчуванням", ["yes"]="Так", ["no"]="Ні",
            ["searching_for"]="Пошук «{0}»…", ["downloading"]="Завантаження {0}…", ["starting"]="Запуск {0}…",
            ["applying"]="Застосування {0}…", ["installing"]="Встановлення {0}…",             ["loading"]="Завантаження {0}…",
            ["reading_plans"]="Читання схем живлення…", ["populating_list"]="Формування списку…",
            ["apps_found"]="Знайдено програм: {0}", ["nothing_found"]="Нічого не знайдено", ["loaded_items"]="Завантажено елементів: {0}",
            ["list_unloaded"]="Список вивантажено",
            ["exported"]="Експортовано {0}",
            ["installed_n"]="Встановлено програм: {0}", ["install_failed"]="Не вдалося встановити",
            ["failed_admin"]="Не вдалося — запустіть від імені адміністратора або перезавантажтесь", ["failed"]="Не вдалося",
            ["win32_set"]="Win32PrioritySeparation встановлено: {0}",

    };
    private static readonly Dictionary<string, string> OptionLabels_uk = new()
    {
 ["run"]="Запустити", ["download"]="Завантажити", ["apply"]="Застосувати", ["enable"]="Увімкнути", ["disable"]="Вимкнути", ["search"]="Пошук", ["install"]="Встановити", ["load list"]="Завантажити список", ["uninstall"]="Видалити", ["activate"]="Активувати", ["delete"]="Видалити", ["import .pow"]="Імпорт .pow", ["default"]="За замовчуванням", ["custom"]="Власне", ["full"]="Повний", ["reduced"]="Зменшений", ["minimum"]="Мінімум", ["disable mmcss"]="Вимкнути MMCSS", ["bypass"]="Обхід", ["repeater"]="Ретранслятор", ["realtime"]="Реальний час", ["high"]="Високий", ["abovenormal"]="Вище звичайного", ["normal"]="Звичайний", ["belownormal"]="Нижче звичайного", ["enhanced"]="Покращений", ["legacy"]="Застарілий", ["disabled"]="Вимкнено", ["enabled"]="Увімкнено", ["alwayson"]="Завжди увімкнено", ["alwaysoff"]="Завжди вимкнено", ["optin"]="Увімкнути вибірково", ["optout"]="Вимкнути вибірково", ["open cru"]="Відкрити CRU", ["coming soon"]="Скоро", ["safe fivem/minecraft services"]="Безпечні служби FiveM/Minecraft", ["kernelos default"]="Superiorly за замовчуванням" , ["telemetry"]="Телеметрія"
    };
    private static readonly Dictionary<string, string> TabDescs_uk = new()
    {
 ["mainstream"]="Браузери на щодень.", ["privacy"]="Браузери для конфіденційності та анонімності.", ["forks"]="Збірки спільноти на основі Chromium і Firefox.", ["utilities"]="Інструменти для діагностики системи та обладнання.", ["amd"]="Інструменти AMD GPU для драйверів, частот, напруги та реєстру.", ["nvidia"]="Інструменти NVIDIA для чистого встановлення, профілів і P-станів.", ["connectivity"]="Налаштування Wi-Fi, Bluetooth і ліміту Hotspot Hop.", ["devices"]="Виправлення принтера, диспетчера завдань і введення тексту.", ["security"]="Ізоляція ядра, брандмауер, UAC, список заблокованих драйверів і захист пам'яті.", ["gaming"]="Служби Xbox та Opera GX.", ["ai"]="Браузери на Chromium, WebKit і з ШІ.", ["debloat"]="Політики конфіденційності браузерів і перемикачі телеметрії вендорів: Chrome, Edge, Firefox та Office.", ["system"]="Драйвери через Windows Update, виправлення меню Пуск і панелі Intel." , ["telemetry"]="Перемикачі телеметрії, рекомендацій, реклами та збору даних вендорами.",
["app-privacy"]="Дозволи застосунків і параметри приватності.",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_uk = new()
    {
 ["browsers|gaming"]="Opera GX із вбудованими обмежувачами CPU, RAM і мережі.", ["tweaking|gaming"]="Служби Xbox і безпечні служби FiveM/Minecraft."
    };
    private static readonly Dictionary<string, string> TabBannerTitles_uk = new()
    {
 ["mainstream"]="Браузери на щодень", ["privacy"]="Анонімний перегляд", ["forks"]="Незалежні форки", ["utilities"]="Системні утиліти", ["amd"]="Інструменти Radeon", ["nvidia"]="Інструменти GeForce", ["connectivity"]="Бездротові налаштування", ["devices"]="Виправлення пристроїв", ["security"]="Захист системи", ["gaming"]="Ігрові служби", ["ai"]="ШІ-браузери", ["debloat"]="Деблот браузерів", ["system"]="Виправлення Windows" , ["telemetry"]="Виправлення телеметрії",
["app-privacy"]="Приватність застосунків",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_uk = new()
    {
 ["browsers|gaming"]="Ігровий браузер"
    };
    private static readonly Dictionary<string, string> UiExtra_uk = new()
    {
["state_on"]="Увімк.", ["state_off"]="Вимк.",
            ["confirm_delete"]="Підтвердіть видалення",
            ["confirm_enable"]="Застосувати цю зміну?",
            ["confirm_disable"]="Вимкнути цей захист?",
            ["delete_plans"]="Видалити схем живлення: {0}?",
            ["cant_delete_active"]="Не можна видалити активну схему живлення. Спочатку перейдіть на іншу.",
            ["import_plan"]="Імпорт схеми живлення", ["export_plan"]="Експорт схеми живлення",
            ["ratio"]="співвідношення", ["long"]="Довгий", ["short"]="Короткий", ["fixed"]="Фіксований", ["variable"]="Змінний", ["boost"]="буст", ["current"]="поточний",
            ["needs_admin"]="Ця дія потребує прав адміністратора.",
            ["restart_driver"]="Перезапустити драйвер дисплея", ["reset_all"]="Скинути все", ["download_cru"]="Завантажити CRU",
            ["modify_quantum"]="Змінити Quantum", ["quantum_length"]="Довжина Quantum", ["quantum_interval"]="Інтервал Quantum",
            ["fix"]="Виправити", ["preview_hex"]="Перегляд Hex", ["preview_bits"]="Перегляд бітів",
            ["minimize"]="Згорнути", ["maximize"]="Розгорнути", ["toggle_theme"]="Перемкнути світлу / темну тему",
            ["follow_theme"]="Слідувати темі Windows", ["square"]="Прямі кути", ["rounded"]="Заокруглені кути",
            ["join"]="ПРИЄДНАТИСЬ", ["follow"]="ПІДПИСАТИСЬ", ["visit"]="ВІДВІДАТИ", ["copy_link"]="Копіювати посилання", ["copied"]="Скопійовано",
            ["no_profiles_found"]="Профілів не знайдено. Покладіть .nip-файли в теку Nvidia Profiles.",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0", ["welcome"]="ЛАСКАВО ПРОСИМО", ["hero_tagline"]="ДО SUPERIORLY",
            ["security"]="Безпека: ", ["power_plan_filter"]="Схема живлення",
            ["theme_changed"]="Тему змінено на {0}", ["style_changed"]="Стиль змінено на {0}",
            ["powerplan_custom"]="Власний", ["powerplan_restore"]="Відновити офіційні",
            ["update_available"]="Доступне оновлення {0}", ["new_update"]="Нове оновлення: {0}", ["up_to_date"]="У вас остання версія", ["update_check_failed"]="Не вдалося перевірити оновлення",

    };
}
