namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_ptBR = new()
    {
 ["home"]="Bem-vindo à sua caixa de ferramentas", ["browsers"]="Navegadores", ["tools"]="Ferramentas", ["tweaking"]="Otimização", ["troubleshooting"]="Solução de problemas" 
    };
    private static readonly Dictionary<string, string> SectionDescs_ptBR = new()
    {
 ["home"]="Bem-vindo à sua caixa de ferramentas", ["browsers"]="Utilitários e correções de navegadores", ["tools"]="Baixe e execute utilitários portáteis", ["tweaking"]="Ajustes de drivers, GPU e sistema.", ["troubleshooting"]="Controles rápidos e correções do sistema." 
    };
    private static readonly Dictionary<string, string> TabTitles_ptBR = new()
    {
 ["mainstream"]="Navegadores do dia a dia", ["privacy"]="Privacidade", ["forks"]="Derivados e personalizados", ["software"]="Software", ["store-downloader"]="Baixador da Microsoft Store", ["utilities"]="Utilitários", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Ajustes do registro", ["win32"]="Win32Priority", ["powerplans"]="Planos de energia", ["connectivity"]="Conectividade", ["devices"]="Dispositivos", ["security"]="Proteção", ["gaming"]="Jogos", ["ai"]="Inteligência artificial", ["debloat"]="Debloat", ["system"]="Sistema" , ["telemetry"]="Telemetria",
            ["app-privacy"]="Privacidade de Apps",
    };
    private static readonly Dictionary<string, string> Notifications_ptBR = new()
    {
 ["opened"]="Aberto - iniciado", ["installed"]="Instalado com sucesso", ["failed"]="Falha na instalação", ["open_failed"]="Não foi possível abrir", ["enabled"]="Ativado", ["disabled"]="Desativado", ["apply_failed"]="Não foi possível aplicar", ["applied"]="Aplicado" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_ptBR = new()
    {

            ["settings"]="Configurações", ["language"]="Idioma", ["theme"]="Tema", ["dark"]="Escuro", ["light"]="Claro", ["auto"]="Automático", ["default_theme"]="Tema padrão",
            ["style"]="Estilo", ["win10_style"]="Estilo Windows 10", ["win11_style"]="Estilo Windows 11", ["close"]="Fechar",
            ["search_placeholder"]="Pesquisar por nome, URL ou ID.", ["store_no_results"]="Nenhum resultado. Tente outra pesquisa.", ["search"]="Pesquisar", ["install"]="Instalar",
            ["run"]="Executar", ["download"]="Baixar", ["open"]="Abrir", ["apply"]="Aplicar",
            ["check_updates"]="Verificar atualizações", ["update"]="Update", ["disclaimer"]="As modificações são de sua exclusiva responsabilidade.",
            ["quantum_title"]="Mapa Quantum", ["quantum_subtitle"]="Todos os valores válidos de Win32PrioritySeparation. Clique em uma linha para aplicar.",
            ["open_quantum"]="Abrir Mapa Quantum", ["current_win32"]="Win32PrioritySeparation atual",
            ["load_list"]="Carregar lista", ["unload_list"]="Fechar lista", ["activate"]="Ativar", ["import"]="Importar", ["export"]="Exportar",
            ["select_all"]="Selecionar tudo", ["unselect_all"]="Desmarcar tudo", ["uninstall"]="Desinstalar", ["delete"]="Excluir",
            ["restore_default"]="Restaurar padrão", ["yes"]="Sim", ["no"]="Não",
            ["searching_for"]="Pesquisando '{0}'...", ["downloading"]="Baixando {0}...", ["starting"]="Iniciando {0}...",
            ["applying"]="Aplicando {0}...", ["installing"]="Instalando {0}...",             ["loading"]="Carregando {0}...",
            ["reading_plans"]="Lendo planos de energia...", ["populating_list"]="Gerando lista...",
            ["apps_found"]="{0} aplicativos encontrados", ["nothing_found"]="Nenhum item encontrado", ["loaded_items"]="{0} itens carregados",
            ["list_unloaded"]="Lista descarregada",
            ["exported"]="{0} exportado",
            ["installed_n"]="{0} aplicativo(s) instalado(s)", ["install_failed"]="Falha na instalação",
            ["failed_admin"]="Falha - Execute como administrador ou reinicie o computador", ["failed"]="Falha",
            ["win32_set"]="Win32PrioritySeparation definido como {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_ptBR = new()
    {
 ["run"]="Executar", ["download"]="Baixar", ["apply"]="Aplicar", ["enable"]="Ativar", ["disable"]="Desativar", ["search"]="Pesquisar", ["install"]="Instalar", ["load list"]="Carregar lista", ["uninstall"]="Desinstalar", ["activate"]="Ativar", ["delete"]="Excluir", ["import .pow"]="Importar .pow", ["default"]="Padrão", ["custom"]="Personalizado", ["full"]="Completo", ["reduced"]="Reduzido", ["minimum"]="Mínimo", ["disable mmcss"]="Desativar MMCSS", ["bypass"]="Bypass", ["repeater"]="Repetidor", ["realtime"]="Tempo real", ["high"]="Alta", ["abovenormal"]="Acima do normal", ["normal"]="Normal", ["belownormal"]="Abaixo do normal", ["enhanced"]="Aprimorado", ["legacy"]="Legado", ["disabled"]="Desativado", ["enabled"]="Ativado", ["alwayson"]="Sempre ativado", ["alwaysoff"]="Sempre desativado", ["optin"]="Ativação seletiva", ["optout"]="Desativação seletiva", ["open cru"]="Abrir CRU", ["coming soon"]="Em breve", ["safe fivem/minecraft services"]="Serviços seguros FiveM/Minecraft", ["kernelos default"]="Padrão Superiorly" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> UiExtra_ptBR = new()
    {
["state_on"]="Ativado", ["state_off"]="Desligado", 
            ["confirm_delete"]="Confirmar exclusão",
            ["confirm_enable"]="Aplicar esta alteração?",
            ["delete_plans"]="Excluir {0} plano(s) de energia?",
            ["cant_delete_active"]="Não é possível excluir o plano de energia ativo. Troque para outro plano primeiro.",
            ["import_plan"]="Importar plano de energia", ["export_plan"]="Exportar plano de energia",
            ["ratio"]="proporção", ["long"]="Longo", ["short"]="Curto", ["fixed"]="Fixo", ["variable"]="Variável", ["boost"]="Aumento", ["current"]="Atual",
            ["needs_admin"]="Esta ação requer privilégios de administrador.",
            ["restart_driver"]="Reiniciar driver de vídeo", ["reset_all"]="Redefinir tudo", ["download_cru"]="Baixar CRU",
            ["modify_quantum"]="Modificar Quantum", ["quantum_length"]="Duração do Quantum", ["quantum_interval"]="Intervalo do Quantum",
            ["fix"]="Corrigir", ["preview_hex"]="Prévia hexadecimal", ["preview_bits"]="Prévia de bits",
            ["minimize"]="Minimizar", ["maximize"]="Maximizar", ["toggle_theme"]="Alternar tema claro / escuro",
            ["follow_theme"]="Seguir o tema do Windows", ["square"]="Cantos quadrados", ["rounded"]="Cantos arredondados",
            ["join"]="ENTRAR", ["follow"]="SEGUIR", ["visit"]="VISITAR", ["copy_link"]="Copiar link", ["copied"]="Copiado",
            ["no_profiles_found"]="Nenhum perfil encontrado. Coloque arquivos .nip na pasta Nvidia Profiles.",
            ["confirm_disable"]="Desativar esta proteção?",
            ["home_discord_desc"]="Comunidade Superiorly",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0", ["welcome"]="BEM-VINDO", ["hero_tagline"]="AO SUPERIORLY",
            ["security"]="Segurança: ", ["power_plan_filter"]="Plano de energia",
            ["theme_changed"]="Tema alterado para {0}", ["style_changed"]="Estilo alterado para {0}",
            ["powerplan_custom"]="Personalizado", ["powerplan_restore"]="Restaurar oficiais",
            ["update_available"]="Atualização {0} disponível", ["new_update"]="Nova atualização: {0}", ["up_to_date"]="Está atualizado", ["update_check_failed"]="Não foi possível verificar atualizações",
        
    };
    private static readonly Dictionary<string, string> TabDescs_ptBR = new()
    {
 ["mainstream"]="Navegadores do dia a dia", ["privacy"]="Navegadores focados em privacidade e anonimato.", ["forks"]="Compilações comunitárias baseadas em Chromium e Firefox.", ["utilities"]="Ferramentas de diagnóstico de sistema e hardware.", ["amd"]="Ferramentas GPU AMD para drivers, clock, voltagem e registro.", ["nvidia"]="Ferramentas NVIDIA para instalação limpa, perfis e P-States.", ["connectivity"]="Configurações de Wi-Fi, Bluetooth e limite de saltos do hotspot.", ["devices"]="Correções de impressora, Gerenciador de tarefas e entrada de texto.", ["security"]="Isolamento de núcleo, firewall, UAC, lista de bloqueio de drivers e proteções de memória.", ["gaming"]="Serviços Xbox e Opera GX.", ["ai"]="Navegação Chromium, WebKit e focada em IA.", ["debloat"]="Políticas de privacidade de navegadores e chaves de telemetria de fornecedores: Chrome, Edge, Firefox e Office.", ["system"]="Drivers via Windows Update, menu Iniciar e correções do painel Intel." , ["telemetry"]="Chaves de telemetria, sugestões, anúncios e coleta de dados de fornecedores.",
            ["app-privacy"]="Permissões de aplicações e opções de privacidade.",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_ptBR = new()
    {
 ["browsers|gaming"]="Opera GX com limitadores integrados de CPU, RAM e rede.", ["tweaking|gaming"]="Serviços Xbox e serviços seguros FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_ptBR = new()
    {
 ["mainstream"]="Navegadores do dia a dia", ["privacy"]="Navegação anônima", ["forks"]="Derivados independentes", ["utilities"]="Utilitários de sistema", ["amd"]="Ferramentas Radeon", ["nvidia"]="Ferramentas GeForce", ["connectivity"]="Ajustes sem fio", ["devices"]="Correções de dispositivos", ["security"]="Proteções do sistema", ["gaming"]="Serviços de jogos", ["ai"]="Navegadores com IA", ["debloat"]="Limpeza de navegadores", ["system"]="Correções do Windows" , ["telemetry"]="Correções de telemetria",
            ["app-privacy"]="Privacidade de Apps",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_ptBR = new()
    {
 ["browsers|gaming"]="Navegador gamer"
    };
}
