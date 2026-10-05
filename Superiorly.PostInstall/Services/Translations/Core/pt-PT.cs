namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_ptPT = new()
    {
 ["home"]="Bem-vindo à sua caixa de ferramentas", ["browsers"]="Utilitários e correções de navegadores", ["tools"]="Baixe e execute utilitários portáteis", ["tweaking"]="Ajustes de drivers, GPU e sistema.", ["troubleshooting"]="Controles rápidos e correções do sistema." 
    };
    private static readonly Dictionary<string, string> SectionDescs_ptPT = new()
    {
 ["home"]="Bem-vindo à sua caixa de ferramentas", ["browsers"]="Utilitários e correções de navegadores", ["tools"]="Baixe e execute utilitários portáteis", ["tweaking"]="Ajustes de drivers, GPU e sistema.", ["troubleshooting"]="Controles rápidos e correções do sistema." 
    };
    private static readonly Dictionary<string, string> TabTitles_ptPT = new()
    {
 ["mainstream"]="Navegadores do dia a dia", ["privacy"]="Navegação anônima", ["forks"]="Derivados independentes", ["software"]="Software", ["store-downloader"]="Baixador da Microsoft Store", ["utilities"]="Utilitários de sistema", ["amd"]="Ferramentas Radeon", ["nvidia"]="Ferramentas GeForce", ["registry"]="Ajustes do registo", ["win32"]="Win32Priority", ["powerplans"]="Planos de energia", ["connectivity"]="Ajustes sem fio", ["devices"]="Correções de dispositivos", ["security"]="Proteções do sistema", ["gaming"]="Serviços de jogos", ["ai"]="Navegadores com IA", ["debloat"]="Limpeza de navegadores", ["system"]="Correções do Windows" , ["telemetry"]="Correções de telemetria",
            ["app-privacy"]="Privacidade de Apps",
    };
    private static readonly Dictionary<string, string> Notifications_ptPT = new()
    {
 ["opened"]="Aberto - iniciado", ["installed"]="Instalado com sucesso", ["failed"]="Falha", ["open_failed"]="Não foi possível abrir", ["enabled"]="Ativado", ["disabled"]="Desativado", ["apply_failed"]="Não foi possível aplicar", ["applied"]="Aplicado" , ["telemetry"]="Correções de telemetria"
    };
    private static readonly Dictionary<string, string> Ui_ptPT = new()
    {

            ["settings"]="Definições", ["language"]="Idioma", ["theme"]="Tema", ["dark"]="Escuro", ["light"]="Claro", ["auto"]="Automático", ["default_theme"]="Tema predefinido",
            ["style"]="Estilo", ["win10_style"]="Estilo Windows 10", ["win11_style"]="Estilo Windows 11", ["close"]="Fechar",
            ["search_placeholder"]="Procurar por nome, URL ou ID.", ["store_no_results"]="Nenhum resultado. Tente outra procura.", ["search"]="Procurar", ["install"]="Instalar",
            ["run"]="Executar", ["download"]="Baixar", ["open"]="Abrir", ["apply"]="Aplicar",
            ["check_updates"]="Verificar atualizações", ["update"]="Update", ["disclaimer"]="As modificações são de sua exclusiva responsabilidade.",
            ["quantum_title"]="Mapa Quantum", ["quantum_subtitle"]="Todos os valores válidos de Win32PrioritySeparation. Clique em uma linha para aplicar.",
            ["open_quantum"]="Abrir Mapa Quantum", ["current_win32"]="Win32PrioritySeparation atual",
            ["load_list"]="Carregar lista", ["unload_list"]="Fechar lista", ["activate"]="Ativar", ["import"]="Importar", ["export"]="Exportar",
            ["select_all"]="Selecionar tudo", ["unselect_all"]="Desmarcar tudo", ["uninstall"]="Desinstalar", ["delete"]="Eliminar",
            ["restore_default"]="Repor predefinição", ["yes"]="Sim", ["no"]="Não",
            ["searching_for"]="Procurando '{0}'...", ["downloading"]="Baixando {0}...", ["starting"]="Iniciando {0}...",
            ["applying"]="Aplicando {0}...", ["installing"]="Instalando {0}...",             ["loading"]="Carregando {0}...",
            ["reading_plans"]="Lendo planos de energia...", ["populating_list"]="Gerando lista...",
            ["apps_found"]="{0} aplicações encontradas", ["nothing_found"]="Nenhum item encontrado", ["loaded_items"]="{0} itens carregados",
            ["list_unloaded"]="Lista descarregada",
            ["exported"]="{0} exportado",
            ["installed_n"]="{0} aplicação(s) instalado(s)", ["install_failed"]="Falha na instalação",
            ["failed_admin"]="Falha - Execute como administrador ou reinicie o computador", ["failed"]="Falha",
            ["win32_set"]="Win32PrioritySeparation definido como {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_ptPT = new()
    {
 ["run"]="Executar", ["download"]="Baixar", ["apply"]="Aplicar", ["enable"]="Ativar", ["disable"]="Desativar", ["search"]="Procurar", ["install"]="Instalar", ["load list"]="Carregar lista", ["uninstall"]="Desinstalar", ["activate"]="Ativar", ["delete"]="Eliminar", ["import .pow"]="Importar .pow", ["default"]="Padrão", ["custom"]="Personalizado", ["full"]="Completo", ["reduced"]="Reduzido", ["minimum"]="Mínimo", ["disable mmcss"]="Desativar MMCSS", ["bypass"]="Bypass", ["repeater"]="Repetidor", ["realtime"]="Tempo real", ["high"]="Alta", ["abovenormal"]="Acima do normal", ["normal"]="Normal", ["belownormal"]="Abaixo do normal", ["enhanced"]="Aprimorado", ["legacy"]="Legado", ["disabled"]="Desativado", ["enabled"]="Ativado", ["alwayson"]="Sempre ativado", ["alwaysoff"]="Sempre desativado", ["optin"]="Ativação seletiva", ["optout"]="Desativação seletiva", ["open cru"]="Abrir CRU", ["coming soon"]="Em breve", ["safe fivem/minecraft services"]="Serviços seguros FiveM/Minecraft", ["kernelos default"]="Padrão Superiorly" , ["telemetry"]="Correções de telemetria"
    };
    private static readonly Dictionary<string, string> UiExtra_ptPT = new()
    {
["state_on"]="Ativado", ["state_off"]="Desligado", 
            ["confirm_delete"]="Confirmar exclusão",
            ["confirm_enable"]="Aplicar esta alteração?",
            ["delete_plans"]="Eliminar {0} plano(s) de energia?",
            ["cant_delete_active"]="Não é possível eliminar o plano de energia ativo. Troque para outro plano primeiro.",
            ["import_plan"]="Importar plano de energia", ["export_plan"]="Exportar plano de energia",
            ["ratio"]="proporção", ["long"]="Longo", ["short"]="Curto", ["fixed"]="Fixo", ["variable"]="Variável", ["boost"]="Aumento", ["current"]="Atual",
            ["needs_admin"]="Esta ação requer privilégios de administrador.",
            ["restart_driver"]="Reiniciar driver de vídeo", ["reset_all"]="Repor tudo", ["download_cru"]="Baixar CRU",
            ["modify_quantum"]="Modificar Quantum", ["quantum_length"]="Duração do Quantum", ["quantum_interval"]="Intervalo do Quantum",
            ["fix"]="Corrigir", ["preview_hex"]="Prévia hexadecimal", ["preview_bits"]="Prévia de bits",
            ["minimize"]="Minimizar", ["maximize"]="Maximizar", ["toggle_theme"]="Alternar tema claro / escuro",
            ["follow_theme"]="Seguir o tema do Windows", ["square"]="Cantos quadrados", ["rounded"]="Cantos arredondados",
            ["join"]="ENTRAR", ["follow"]="SEGUIR", ["visit"]="VISITAR", ["copy_link"]="Copiar link", ["copied"]="Copiado",
            ["no_profiles_found"]="Nenhum perfil encontrado. Coloque ficheiros .nip na pasta Nvidia Profiles.",
            ["confirm_disable"]="Desativar esta proteção?",
            ["home_discord_desc"]="Comunidade Superiorly",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="Proteções do sistema", ["power_plan_filter"]="Plano de energia",
            ["theme_changed"]="Tema alterado para {0}", ["style_changed"]="Estilo alterado para {0}",
            ["powerplan_custom"]="Personalizado", ["powerplan_restore"]="Restaurar oficiais",
            ["update_available"]="Atualização {0} disponível", ["new_update"]="Nova atualização: {0}", ["up_to_date"]="Está atualizado", ["update_check_failed"]="Não foi possível verificar atualizações",
        
    };
    private static readonly Dictionary<string, string> TabDescs_ptPT = new()
    {
 ["mainstream"]="Navegadores do dia a dia", ["privacy"]="Navegação anônima", ["forks"]="Derivados independentes", ["utilities"]="Utilitários de sistema", ["amd"]="Ferramentas Radeon", ["nvidia"]="Ferramentas GeForce", ["connectivity"]="Ajustes sem fio", ["devices"]="Correções de dispositivos", ["security"]="Proteções do sistema", ["gaming"]="Serviços de jogos", ["ai"]="Navegadores com IA", ["debloat"]="Limpeza de navegadores", ["system"]="Correções do Windows" , ["telemetry"]="Correções de telemetria",
            ["app-privacy"]="Privacidade de Apps",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_ptPT = new()
    {
 ["browsers|gaming"]="Navegador gamer", ["tweaking|gaming"]="Serviços Xbox e serviços seguros FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_ptPT = new()
    {
 ["mainstream"]="Navegadores do dia a dia", ["privacy"]="Navegação anônima", ["forks"]="Derivados independentes", ["utilities"]="Utilitários de sistema", ["amd"]="Ferramentas Radeon", ["nvidia"]="Ferramentas GeForce", ["connectivity"]="Ajustes sem fio", ["devices"]="Correções de dispositivos", ["security"]="Proteções do sistema", ["gaming"]="Serviços de jogos", ["ai"]="Navegadores com IA", ["debloat"]="Limpeza de navegadores", ["system"]="Correções do Windows" , ["telemetry"]="Correções de telemetria",
            ["app-privacy"]="Privacidade de Apps",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_ptPT = new()
    {
 ["browsers|gaming"]="Navegador gamer"
    };
}
