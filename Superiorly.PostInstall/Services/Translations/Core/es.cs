namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_es = new()
    {
 ["home"]="Inicio", ["browsers"]="Navegadores", ["tools"]="Herramientas", ["tweaking"]="Optimización", ["troubleshooting"]="Soluci\u00f3n de problemas" 
    };
    private static readonly Dictionary<string, string> SectionDescs_es = new()
    {
 ["home"]="Bienvenido a tu caja de herramientas", ["browsers"]="Utilidades y correcciones de navegadores", ["tools"]="Descarga y ejecuta utilidades portátiles", ["tweaking"]="Ajustes de controlador, GPU y sistema.", ["troubleshooting"]="Controles rápidos y correcciones del sistema." 
    };
    private static readonly Dictionary<string, string> TabTitles_es = new()
    {
 ["mainstream"]="Principal", ["privacy"]="Privacidad", ["forks"]="Derivados y personalizados", ["software"]="Software", ["store-downloader"]="Descargador de Microsoft Store", ["utilities"]="Utilidades", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Ajustes del registro", ["win32"]="Win32Priority", ["powerplans"]="Planes de energía", ["connectivity"]="Conectividad", ["devices"]="Dispositivos", ["security"]="Seguridad", ["gaming"]="Juegos", ["ai"]="Inteligencia artificial", ["debloat"]="Debloat", ["system"]="Sistema" , ["telemetry"]="Telemetría"
    };
    private static readonly Dictionary<string, string> Notifications_es = new()
    {
 ["opened"]="Abierto - iniciado", ["installed"]="Instalado correctamente", ["failed"]="Error de instalación", ["open_failed"]="No se pudo abrir", ["enabled"]="Activado", ["disabled"]="Desactivado", ["apply_failed"]="No se pudo aplicar", ["applied"]="Aplicado" , ["telemetry"]="Telemetría"
    };
    private static readonly Dictionary<string, string> Ui_es = new()
    {

            ["settings"]="Configuración", ["language"]="Idioma", ["theme"]="Tema", ["dark"]="Oscuro", ["light"]="Claro", ["auto"]="Automático", ["default_theme"]="Tema predeterminado",
            ["style"]="Estilo", ["win10_style"]="Estilo Windows 10", ["win11_style"]="Estilo Windows 11", ["close"]="Cerrar",
            ["search_placeholder"]="Buscar por nombre, URL o ID.", ["store_no_results"]="Sin resultados. Prueba con otra búsqueda.", ["search"]="Buscar", ["install"]="Instalar",
            ["run"]="Ejecutar", ["download"]="Descargar", ["open"]="Abrir", ["apply"]="Aplicar",
            ["check_updates"]="Buscar actualizaciones", ["update"]="Actualizar", ["disclaimer"]="Las modificaciones son tu exclusiva responsabilidad.",
            ["quantum_title"]="Mapa Quantum", ["quantum_subtitle"]="Todos los valores válidos de Win32PrioritySeparation. Pulsa una fila para aplicarla.",
            ["open_quantum"]="Abrir Mapa Quantum", ["current_win32"]="Win32PrioritySeparation actual",
            ["load_list"]="Cargar lista", ["unload_list"]="Vaciar lista", ["activate"]="Activar", ["import"]="Importar", ["export"]="Exportar",
            ["select_all"]="Seleccionar todo", ["unselect_all"]="Deseleccionar todo", ["uninstall"]="Desinstalar", ["delete"]="Eliminar",
            ["restore_default"]="Restaurar valores predeterminados", ["yes"]="Sí", ["no"]="No",
            ["searching_for"]="Buscando '{0}'...", ["downloading"]="Descargando {0}...", ["starting"]="Iniciando {0}...",
            ["applying"]="Aplicando {0}...", ["installing"]="Instalando {0}...",             ["loading"]="Cargando {0}...",
            ["reading_plans"]="Leyendo planes de energía...", ["populating_list"]="Generando lista...",
            ["apps_found"]="{0} aplicaciones encontradas", ["nothing_found"]="No se encontraron elementos", ["loaded_items"]="{0} elementos cargados",
            ["list_unloaded"]="Lista vaciada",
            ["exported"]="{0} exportado",
            ["installed_n"]="{0} aplicaciones instaladas", ["install_failed"]="Error de instalación",
            ["failed_admin"]="Error - ejecuta como administrador o reinicia", ["failed"]="Error",
            ["win32_set"]="Win32PrioritySeparation establecido en {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_es = new()
    {
 ["run"]="Ejecutar", ["download"]="Descargar", ["apply"]="Aplicar", ["enable"]="Activar", ["disable"]="Desactivar", ["search"]="Buscar", ["install"]="Instalar", ["load list"]="Cargar lista", ["uninstall"]="Desinstalar", ["activate"]="Activar", ["delete"]="Eliminar", ["import .pow"]="Importar .pow", ["default"]="Predeterminado", ["custom"]="Personalizado", ["minimum"]="Mínimo", ["disable mmcss"]="Desactivar MMCSS", ["bypass"]="Bypass", ["repeater"]="Repetidor", ["realtime"]="Tiempo real", ["high"]="Alta", ["abovenormal"]="Superior a normal", ["normal"]="Normal", ["belownormal"]="Inferior a normal", ["enhanced"]="Mejorado", ["legacy"]="Heredado", ["disabled"]="Desactivado", ["enabled"]="Activado", ["alwayson"]="Siempre activado", ["alwaysoff"]="Siempre desactivado", ["optin"]="Activación selectiva", ["optout"]="Desactivación selectiva", ["open cru"]="Abrir CRU", ["coming soon"]="Próximamente", ["safe fivem/minecraft services"]="Servicios seguros FiveM/Minecraft", ["kernelos default"]="Superiorly predeterminado" , ["telemetry"]="Telemetría"
    };
    private static readonly Dictionary<string, string> TabDescs_es = new()
    {
 ["mainstream"]="Navegadores populares, listos para instalar.", ["privacy"]="Navegadores centrados en privacidad y anonimato.", ["forks"]="Derivados alternativos de Chromium y Firefox.", ["utilities"]="Utilidades portátiles de sistema y hardware.", ["amd"]="Herramientas GPU AMD: drivers ligeros, frecuencia, voltaje y registro.", ["nvidia"]="Herramientas NVIDIA: instalación limpia, inspector, perfiles y P-states.", ["connectivity"]="Controles de red: Wi-Fi, Bluetooth y límite de saltos.", ["devices"]="Impresoras, reemplazo del Administrador de tareas y entrada de texto.", ["security"]="Aislamiento de núcleo, firewall, UAC y protecciones de memoria.", ["gaming"]="Servicios de Xbox y Opera GX.", ["ai"]="Navegadores Chromium, WebKit e IA.", ["debloat"]="Políticas de privacidad de navegadores y telemetría de proveedores: Chrome, Edge, Firefox y Office.", ["system"]="Controladores por Windows Update, menú Inicio y panel Intel." , ["telemetry"]="Interruptores de telemetría, sugerencias, anuncios y recopilación de datos."
    };
    private static readonly Dictionary<string, string> UiExtra_es = new()
    {
["state_on"]="Activado", ["state_off"]="Desactivado", 
            ["confirm_delete"]="Confirmar eliminación",
            ["confirm_enable"]="¿Aplicar este cambio?",
            ["confirm_disable"]="¿Desactivar esta protección?",
            ["delete_plans"]="¿Eliminar {0} planes de energía?",
            ["cant_delete_active"]="No se puede eliminar el plan de energía activo. Cambia primero a otro plan.",
            ["import_plan"]="Importar plan de energía", ["export_plan"]="Exportar plan de energía",
            ["ratio"]="proporción", ["long"]="Largo", ["short"]="Corto", ["fixed"]="Fijo", ["variable"]="Variable", ["boost"]="impulso", ["current"]="actual",
            ["needs_admin"]="Esta acción requiere privilegios de administrador.",
            ["restart_driver"]="Reiniciar controlador de pantalla", ["reset_all"]="Restablecer todo", ["download_cru"]="Descargar CRU",
            ["modify_quantum"]="Modificar Quantum", ["quantum_length"]="Duración de Quantum", ["quantum_interval"]="Intervalo de Quantum",
            ["fix"]="Fijo", ["preview_hex"]="Vista previa hexadecimal", ["preview_bits"]="Vista previa de bits",
            ["minimize"]="Minimizar", ["maximize"]="Maximizar", ["toggle_theme"]="Alternar tema claro / oscuro",
            ["follow_theme"]="Seguir el tema de Windows", ["square"]="Esquinas cuadradas", ["rounded"]="Esquinas redondeadas",
            ["join"]="UNIRSE", ["follow"]="SEGUIR", ["visit"]="VISITAR", ["copy_link"]="Copiar enlace", ["copied"]="Copiado",
            ["no_profiles_found"]="Sin perfiles. Coloca archivos .nip en la carpeta Nvidia Profiles.",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="Seguridad: ", ["power_plan_filter"]="Plan de energía",
            ["theme_changed"]="Tema cambiado a {0}", ["style_changed"]="Estilo cambiado a {0}",
            ["powerplan_custom"]="Personalizado", ["powerplan_restore"]="Restaurar oficiales",
            ["update_available"]="Actualización {0} disponible", ["new_update"]="Nueva actualización: {0}", ["up_to_date"]="Está actualizado", ["update_check_failed"]="No se pudo buscar actualizaciones",
        
    };
    private static readonly Dictionary<string, string> SectionTabDescs_es = new()
    {
 ["browsers|gaming"]="Opera GX con limitadores integrados de CPU, RAM y red.", ["tweaking|gaming"]="Servicios de Xbox y servicios seguros de FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_es = new()
    {
 ["mainstream"]="Navegadores populares", ["privacy"]="Navegación anónima", ["forks"]="Derivados independientes", ["utilities"]="Utilidades del sistema", ["amd"]="Herramientas Radeon", ["nvidia"]="Herramientas GeForce", ["connectivity"]="Ajustes inalámbricos", ["devices"]="Correcciones de dispositivos", ["security"]="Protecciones del sistema", ["gaming"]="Servicios de juego", ["ai"]="Navegadores con IA", ["debloat"]="Limpieza de navegadores", ["system"]="Correcciones de Windows" , ["telemetry"]="Correcciones de telemetría"
    };
    private static readonly Dictionary<string, string> SectionTabTitles_es = new()
    {
 ["browsers|gaming"]="Navegador gaming", ["tweaking|gaming"]="Servicios de juego" , ["troubleshooting|telemetry"]="Correcciones de telemetría"
    };
}
