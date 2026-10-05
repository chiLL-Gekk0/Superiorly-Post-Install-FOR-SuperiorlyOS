namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_ru = new()
    {
 ["home"]="Главная", ["browsers"]="Браузеры", ["tools"]="Инструменты", ["tweaking"]="Настройка", ["troubleshooting"]="Устранение неполадок" 
    };
    private static readonly Dictionary<string, string> SectionDescs_ru = new()
    {
 ["home"]="Добро пожаловать в ваш набор инструментов", ["browsers"]="Утилиты и исправления для браузеров", ["tools"]="Загрузка и запуск портативных утилит", ["tweaking"]="Настройка драйверов, GPU и системы.", ["troubleshooting"]="Быстрые переключатели и исправления ОС." 
    };
    private static readonly Dictionary<string, string> TabTitles_ru = new()
    {
 ["mainstream"]="Основное", ["privacy"]="Конфиденциальность", ["forks"]="Форки и кастомизация", ["software"]="Программы", ["store-downloader"]="Загрузчик Microsoft Store", ["utilities"]="Утилиты", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Настройки реестра", ["win32"]="Win32Priority", ["powerplans"]="Схемы питания", ["connectivity"]="Подключение", ["devices"]="Устройства", ["security"]="Рейтинг приватности: ", ["gaming"]="Игры", ["ai"]="ИИ", ["debloat"]="Деблоат", ["system"]="Система" , ["telemetry"]="Телеметрия",
["app-privacy"]="Конфиденциальность приложений",
    };
    private static readonly Dictionary<string, string> Notifications_ru = new()
    {
 ["opened"]="Открыто - запущено", ["installed"]="Успешно установлено", ["failed"]="Ошибка установки", ["open_failed"]="Не удалось открыть", ["enabled"]="Включено", ["disabled"]="Отключено", ["apply_failed"]="Не удалось применить", ["applied"]="Применено" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_ru = new()
    {

            ["settings"]="Настройки", ["language"]="Язык", ["theme"]="Тема", ["dark"]="Тёмная", ["light"]="Светлая", ["auto"]="Авто", ["default_theme"]="Тема по умолчанию",
            ["style"]="Стиль", ["win10_style"]="Стиль Windows 10", ["win11_style"]="Стиль Windows 11", ["close"]="Закрыть",
            ["search_placeholder"]="Поиск по имени, URL или ID.", ["store_no_results"]="Ничего не найдено. Попробуйте другой запрос.", ["search"]="Найти", ["install"]="Установить",
            ["run"]="Запустить", ["download"]="Скачать", ["open"]="Открыть", ["apply"]="Применить",
            ["check_updates"]="Проверить обновления", ["update"]="Обновить", ["disclaimer"]="Изменения выполняются под вашу ответственность.",
            ["quantum_title"]="Карта Quantum", ["quantum_subtitle"]="Все допустимые значения Win32PrioritySeparation. Нажмите на строку, чтобы применить.",
            ["open_quantum"]="Открыть карту Quantum", ["current_win32"]="Текущий Win32PrioritySeparation",
            ["load_list"]="Загрузить список", ["unload_list"]="Выгрузить список", ["activate"]="Активировать", ["import"]="Импортировать", ["export"]="Экспортировать",
            ["select_all"]="Выбрать всё", ["unselect_all"]="Снять выбор", ["uninstall"]="Деинсталлировать", ["delete"]="Удалить",
            ["restore_default"]="Восстановить значения по умолчанию", ["yes"]="Да", ["no"]="Нет",
            ["searching_for"]="Поиск '{0}'...", ["downloading"]="Загрузка {0}...", ["starting"]="Запуск {0}...",
            ["applying"]="Применение {0}...", ["installing"]="Установка {0}...",             ["loading"]="Загрузка {0}...",
            ["reading_plans"]="Чтение схем питания...", ["populating_list"]="Формирование списка...",
            ["apps_found"]="Найдено приложений: {0}", ["nothing_found"]="Ничего не найдено", ["loaded_items"]="Загружено элементов: {0}",
            ["list_unloaded"]="Список выгружен",
            ["exported"]="{0} экспортировано",
            ["installed_n"]="Установлено приложений: {0}", ["install_failed"]="Ошибка установки",
            ["failed_admin"]="Ошибка - запустите от имени администратора или перезагрузитесь", ["failed"]="Ошибка",
            ["win32_set"]="Win32PrioritySeparation установлено в {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_ru = new()
    {
 ["run"]="Запустить", ["download"]="Скачать", ["apply"]="Применить", ["enable"]="Включить", ["disable"]="Отключить", ["search"]="Найти", ["install"]="Установить", ["load list"]="Загрузить список", ["uninstall"]="Деинсталлировать", ["activate"]="Активировать", ["delete"]="Удалить", ["import .pow"]="Импорт .pow", ["default"]="По умолчанию", ["custom"]="Своё значение", ["minimum"]="Минимум", ["disable mmcss"]="Отключить MMCSS", ["bypass"]="Обход", ["repeater"]="Повторитель", ["realtime"]="Реальное время", ["high"]="Высокий", ["abovenormal"]="Выше обычного", ["normal"]="Обычный", ["belownormal"]="Ниже обычного", ["enhanced"]="Улучшенный", ["legacy"]="Устаревший", ["disabled"]="Отключено", ["enabled"]="Включено", ["alwayson"]="Всегда вкл.", ["alwaysoff"]="Всегда выкл.", ["optin"]="Включение выборочно", ["optout"]="Отключение выборочно", ["open cru"]="Открыть CRU", ["coming soon"]="Скоро", ["safe fivem/minecraft services"]="Безопасные службы FiveM/Minecraft", ["kernelos default"]="Superiorly по умолчанию" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> UiExtra_ru = new()
    {
["state_on"]="Вкл.", ["state_off"]="Выкл.", 
            ["confirm_delete"]="Подтвердите удаление",
            ["confirm_enable"]="Применить это изменение?",
            ["delete_plans"]="Удалить схем питания: {0}?",
            ["cant_delete_active"]="Нельзя удалить активную схему питания. Сначала переключитесь на другую.",
            ["import_plan"]="Импорт схемы питания", ["export_plan"]="Экспорт схемы питания",
            ["ratio"]="Соотношение", ["long"]="Длинный", ["short"]="Короткий", ["fixed"]="Фиксированный", ["variable"]="Переменный", ["boost"]="буст", ["current"]="Текущий",
            ["needs_admin"]="Для этого действия нужны права администратора.",
            ["restart_driver"]="Перезапустить видеодрайвер", ["reset_all"]="Сбросить всё", ["download_cru"]="Скачать CRU",
            ["modify_quantum"]="Изменить Quantum", ["quantum_length"]="Длина Quantum", ["quantum_interval"]="Интервал Quantum",
            ["fix"]="Фиксированный", ["preview_hex"]="Предпросмотр Hex", ["preview_bits"]="Предпросмотр бит",
            ["minimize"]="Свернуть", ["maximize"]="Развернуть", ["toggle_theme"]="Переключить светлую / тёмную тему",
            ["follow_theme"]="Следовать теме Windows", ["square"]="Прямые углы", ["rounded"]="Скруглённые углы",
            ["join"]="Вступить", ["follow"]="Подписаться", ["visit"]="Открыть", ["copy_link"]="Копировать ссылку", ["copied"]="Скопировано",
            ["no_profiles_found"]="Профили не найдены. Поместите .nip-файлы в папку Nvidia Profiles.",
            ["confirm_disable"]="Отключить эту защиту?",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="Безопасность: ", ["power_plan_filter"]="Схема питания",
            ["theme_changed"]="Тема изменена на {0}", ["style_changed"]="Стиль изменён на {0}",
            ["powerplan_custom"]="Пользовательская", ["powerplan_restore"]="Восстановить официальные",
            ["update_available"]="Доступно обновление {0}", ["new_update"]="Новое обновление: {0}", ["up_to_date"]="Установлена последняя версия", ["update_check_failed"]="Не удалось проверить обновления",
        
    };
    private static readonly Dictionary<string, string> TabDescs_ru = new()
    {
 ["mainstream"]="Браузеры на каждый день.", ["privacy"]="Браузеры для приватности и анонимности.", ["forks"]="Сборки сообщества на основе Chromium и Firefox.", ["utilities"]="Инструменты для диагностики системы и оборудования.", ["amd"]="Инструменты AMD GPU для драйверов, частот, напряжения и реестра.", ["nvidia"]="Инструменты NVIDIA для чистой установки, профилей и P-States.", ["connectivity"]="Настройки Wi-Fi, Bluetooth и лимита хопов хотспота.", ["devices"]="Исправления принтера, диспетчера задач и ввода текста.", ["security"]="Изоляция ядра, брандмауэр, UAC, чёрный список драйверов и защита памяти.", ["gaming"]="Службы Xbox и Opera GX.", ["ai"]="Браузеры Chromium, WebKit и с приоритетом ИИ.", ["debloat"]="Политики приватности браузеров и переключатели телеметрии вендоров: Chrome, Edge, Firefox и Office.", ["system"]="Драйверы через Windows Update, меню «Пуск» и исправления панели Intel." , ["telemetry"]="Переключатели телеметрии, рекомендаций, рекламы и сбора данных вендоров.",
["app-privacy"]="Разрешения приложений и настройки конфиденциальности.",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_ru = new()
    {
 ["browsers|gaming"]="Opera GX со встроенными ограничителями CPU, RAM и сети.", ["tweaking|gaming"]="Службы Xbox и безопасные службы FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_ru = new()
    {
 ["mainstream"]="Браузеры на каждый день", ["privacy"]="Анонимный просмотр", ["forks"]="Независимые форки", ["utilities"]="Системные утилиты", ["amd"]="Инструменты Radeon", ["nvidia"]="Инструменты GeForce", ["connectivity"]="Беспроводные настройки", ["devices"]="Исправления устройств", ["security"]="Защита системы", ["gaming"]="Игровые службы", ["ai"]="ИИ-браузеры", ["debloat"]="Деблоат браузеров", ["system"]="Исправления Windows" , ["telemetry"]="Исправления телеметрии",
["app-privacy"]="Конфиденциальность приложений",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_ru = new()
    {
 ["browsers|gaming"]="Игровой браузер"
    };
}
