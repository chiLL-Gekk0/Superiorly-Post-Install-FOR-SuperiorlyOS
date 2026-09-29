namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_es = new()
    {

            ["arc"]="Desarrollo congelado (2025) porque la empresa apuesta por el navegador IA Dia; un CVE permitió secuestrar sesiones con un ID de usuario; el equipo de seguridad creció de 1 a 5 personas.",
            ["operagx"]="Misma matriz que Opera: la china Kunlun Tech posee ~72 %. Los famosos limitadores de CPU/RAM son casi cosméticos; las acusaciones de Hindenburg afectan al grupo.",
            ["mullvad"]="Sin grandes escándalos. Codesarrollado con el Proyecto Tor (2023); la VPN de Mullvad rechazó solicitudes policiales de acceso.",
            ["thorium"]="Compilaciones no oficiales de Chromium de un solo desarrollador; optimizado para CPU AVX2; sin garantía de compilaciones reproducibles, así que confía en el mantenedor.",
            ["floorp"]="Proyecto japonés que fue de código cerrado durante años pese a usar Firefox; abrió su código en 2023. Gobernanza comunitaria pero pequeña.",
            ["waterfox"]="Vendido a la empresa de anuncios System1 (2020); su fundador Alex Kontos recuperó la independencia (2023). Sin escándalos desde entonces.",
            ["ungoogled"]="Sin escándalos; el coste es revisar actualizaciones a mano y fallos ocasionales por la eliminación agresiva de dependencias de Google.",
            ["dia"]="Sucesor de Arc, beta por invitación; la IA lee el contenido y el historial de chat para actuar por usted; aún sin auditoría independiente.",
            ["avast-secure"]="Su matriz Avast vendió historiales de navegación vía Jumpshot (cerrada en 2020; acuerdo de 16,5 M USD con la FTC en 2024); el antivirus Avast lo promociona con insistencia.",
            ["librewolf"]="Sin grandes escándalos. Único reproche: los parches pueden llegar días después que los de Firefox mientras la comunidad recompila.",
            ["firefox"]="Mozilla obtiene casi todo de Google por el buscador predeterminado; telemetría activada por defecto; en 2025 sus términos insinuaron una licencia amplia de datos (retirada tras las críticas).",
            ["opera"]="~72 % en manos de la china Kunlun Tech (registros SEC). Hindenburg denunció préstamos de sus apps fintech con TAE de 365-876 %. VPN auditada por Deloitte (sin registros).",
            ["whale"]="Propiedad del gigante coreano Naver; sujeto a la ley de datos surcoreana; sus servicios laterales (traducción, compras) contactan con Naver.",
            ["kagi-orion"]="Código cerrado; la versión de Windows es joven e inestable. El negocio de Kagi es la búsqueda de pago: privacidad como producto, no vigilancia.",
            ["pale-moon"]="Su antiguo motor Goanna carece de años de mitigaciones de Chromium/Firefox; fallos frecuentes en sitios; proyecto de un solo mantenedor.",
            ["vivaldi"]="Incluye marcadores afiliados y monetiza la búsqueda predeterminada; la interfaz es cerrada aunque el núcleo Chromium es abierto. En dic. de 2024 activó en secreto scripts de atribución publicitaria en buscadores asociados. Empresa noruega, sin perfiles.",
            ["tor-browser"]="Sirve tanto para evitar la censura como para mercados de la red oscura; los nodos de salida ven el tráfico no HTTPS; algunos gobiernos y sitios lo bloquean o marcan.",
            ["zen"]="Proyecto joven con un equipo mínimo; aún sin auditoría independiente. Sus lanzamientos rápidos pueden traer regresiones.",
            ["edge"]="Envía identificadores únicos aun con la telemetría desactivada; anuncios agresivos de Bing, sugerencias patrocinadas e insistencia en volver.",
            ["falkon"]="Sus parches de QtWebEngine (núcleo Chromium) llegan tarde; equipo KDE pequeño; versiones de Windows menos probadas que las de Linux.",
            ["epic-browser"]="Código cerrado pese a sus promesas de privacidad: su lista de rastreadores y el manejo de datos no se pueden auditar.",
            ["yandex"]="Jurisdicción rusa: las leyes permiten el acceso estatal; el modo Turbo redirige páginas por servidores de Yandex; el asistente Alice procesa voz en Rusia.",
            ["chrome"]="Antimonopolio: el DOJ logró remedios (sep. 2025): Google debe compartir datos de búsqueda y no firmar exclusivas. La demanda del modo incógnito terminó con miles de millones de registros borrados. Privacy Sandbox mantiene los perfiles en casa.",
            ["brave"]="En 2020 añadió códigos de afiliado a URL de criptobolsas (el CEO se disculpó). El pasado de donaciones de Brendan Eich reaparece a veces. Por lo demás, buen historial.",
            ["brave-debloat"]="Aparece como gestionado por tu organización. Exige Brave 1.82+ (Playlist 1.84+).",
            ["edge-debloat"]="Aparece como gestionado.",
            ["comet"]="Navegador IA de Perplexity: el contenido se envía a modelos de IA; Cloudflare lo acusó de rastreo agresivo (2025); la navegación con agentes plantea nuevas dudas.",
            ["duckduckgo"]="En 2022 su navegador dejó pasar rastreadores de Microsoft por un acuerdo con Bing (lo reveló Zach Edwards); corregido en agosto de 2022.",
            ["chromium"]="Sin actualizador automático en Windows: los parches dependen de quien compile su binario; algunas API de Google (sincronización) están eliminadas.",
            ["cachy-browser"]="Compilación de nicho de la comunidad CachyOS (Arch); requiere AVX2; pocos revisores frente a los navegadores grandes.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_es = new()
    {

            ["arc"]="Sincronización con cuenta en servidores de The Browser Company; la IA envía el contenido a sus modelos.",
            ["operagx"]="Igual que Opera: datos de navegación en servidores de Opera; VPN gratuita vía su infraestructura.",
            ["mullvad"]="Nada: sin telemetría ni identificadores, antihuellas activado por defecto.",
            ["thorium"]="Igual que Chromium sin varios servicios de Google ni solicitudes en segundo plano.",
            ["floorp"]="Telemetría desactivada por defecto; algunas funciones contactan con servidores del proyecto japonés.",
            ["waterfox"]="Telemetría eliminada; monetización solo vía buscadores asociados.",
            ["ungoogled"]="Sin conexiones a Google por diseño; sin telemetría; las búsquedas dependen de su motor.",
            ["dia"]="El contenido y las conversaciones se envían a los modelos de IA de The Browser Company; requiere cuenta.",
            ["avast-secure"]="Telemetría y ofertas de Avast; dado el historial de su matriz, suponga perfiles salvo prueba en contrario.",
            ["librewolf"]="Nada por defecto: telemetría, Pocket, servicios de Google y recopilación eliminados al compilar.",
            ["firefox"]="Telemetría, informes de fallos y sugerencias por ubicación; experimentos de medición publicitaria privada (PPA).",
            ["opera"]="Datos procesados en servidores de Opera; la VPN gratuita pasa por su infraestructura.",
            ["whale"]="Sincronización con cuenta Naver, telemetría de uso a Naver; personalización ligada a Naver.",
            ["kagi-orion"]="Cero telemetría declarado; sin perfiles publicitarios; sincronización en Apple vía iCloud, local en Windows.",
            ["pale-moon"]="Poca telemetría, pero el motor desactualizado es el riesgo mayor.",
            ["vivaldi"]="Sin perfiles; sincronización cifrada de extremo a extremo; estadísticas solo si acepta.",
            ["tor-browser"]="El tráfico salta por 3 repetidores voluntarios cifrados; sin telemetría; si inicia sesión, rompe su anonimato.",
            ["zen"]="Basado en Firefox sin telemetría; actualizaciones vía infraestructura de Mozilla.",
            ["edge"]="Datos de diagnóstico, historial con sincronización activada e ID publicitario para anuncios personalizados.",
            ["falkon"]="Telemetría mínima; integración con KDE solo si usa esos servicios.",
            ["epic-browser"]="Dice no tener telemetría y bloquea rastreadores; inverificable por ser cerrado.",
            ["yandex"]="Telemetría amplia: búsquedas, ubicación y voz a Yandex (Rusia); anuncios personalizados.",
            ["chrome"]="Sincroniza historial, búsquedas, ubicación y voz con su cuenta de Google; personalización por defecto.",
            ["brave"]="Mínimo por diseño: estadísticas privadas P3A (desactivables), sin rastreo de búsquedas ni perfiles.",
            ["brave-debloat"]="12 políticas: desactivan Rewards, Wallet, VPN, Leo, Tor, News, Talk, Speedreader, Wayback, Playlist, P3A y ping de stats.",
            ["edge-debloat"]="14 políticas : desactivan compras, sidebars, Rewards, noticias, widgets y telemetría.",
            ["comet"]="Contexto procesado por la IA de Perplexity; requiere cuenta; historial ligado a su perfil.",
            ["duckduckgo"]="Sin perfiles publicitarios; registros de búsqueda anónimos; sincronización cifrada.",
            ["chromium"]="Motor de Chrome sin sincronización ni servicios de Google; las búsquedas dependen de su motor.",
            ["cachy-browser"]="Basado en Chromium con parches mínimos documentados; telemetría como Chromium salvo servicios de Google.",
        
    };
}
