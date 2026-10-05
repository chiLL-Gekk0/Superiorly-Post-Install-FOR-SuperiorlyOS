namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_pt = new()
    {

            ["arc"]="Sincronização por conta via servidores da The Browser Company; recursos de IA enviam conteúdo da página aos modelos deles.",
            ["operagx"]="Igual ao Opera: dados de navegação em servidores da Opera; VPN grátis via infraestrutura da Opera.",
            ["mullvad"]="Nada: sem telemetria, sem identificadores, anti-impressão digital ativado por padrão.",
            ["thorium"]="Igual ao Chromium menos vários serviços do Google e solicitações em segundo plano.",
            ["floorp"]="Telemetria desativada por padrão; alguns recursos falam com servidores do projeto japonês.",
            ["waterfox"]="Telemetria removida; monetização só via buscadores parceiros.",
            ["ungoogled"]="Sem conexões com o Google por projeto; sem telemetria; pesquisas dependem do buscador que você escolher.",
            ["dia"]="Conteúdo da página e conversas enviados aos modelos de IA da The Browser Company; exige conta.",
            ["avast-secure"]="Telemetria da Avast e ofertas promocionais; dado o histórico da controladora, presuma perfilização até prova em contrário.",
            ["librewolf"]="Nada por padrão: telemetria, Pocket, serviços do Google e coleta de dados removidos na compilação.",
            ["firefox"]="Telemetria, relatórios de falha e sugestões por localização; experimentos de medição de anúncios com preservação de privacidade (PPA).",
            ["opera"]="Dados de navegação processados em servidores da Opera; VPN grátis passa pela infraestrutura da Opera.",
            ["whale"]="Sincronização por conta Naver, telemetria de uso para servidores da Naver; personalização ligada aos serviços Naver.",
            ["kagi-orion"]="Zero telemetria alegada; sem perfis de anúncios; sincronização na Apple via iCloud, local no Windows.",
            ["pale-moon"]="Pouca telemetria, mas o motor desatualizado é o risco maior.",
            ["vivaldi"]="Sem perfilização; sincronização criptografada de ponta a ponta; estatísticas de uso só se você optar.",
            ["tor-browser"]="Tráfego salta por 3 retransmissores voluntários criptografados; sem telemetria; entrar em contas pessoais quebra seu próprio anonimato.",
            ["zen"]="Baseado em Firefox com telemetria desligada; atualizações via infraestrutura da Mozilla.",
            ["edge"]="Dados de diagnóstico, histórico de navegação com sincronização ativada, ID de publicidade para anúncios personalizados.",
            ["falkon"]="Telemetria mínima; integração com a área de trabalho KDE só se você usar esses serviços.",
            ["epic-browser"]="Diz não ter telemetria e bloquear rastreadores agressivamente; inverificável por ser código fechado.",
            ["yandex"]="Telemetria ampla, dados de busca, localização e voz para o Yandex (Rússia); anúncios personalizados.",
            ["chrome"]="Sincroniza histórico, buscas, localização e voz com sua conta Google; personalização de anúncios por padrão.",
            ["brave"]="Mínimo por projeto: estatísticas P3A com preservação de privacidade (dá para desativar), sem rastreamento de busca ou perfil.",
            ["brave-debloat"]="Desliga extras e telemetria.",
            ["edge-debloat"]="Desliga compras, extras e telemetria.",
            ["comet"]="Contexto de navegação processado pela IA da Perplexity; exige conta; histórico de busca ligado ao seu perfil Perplexity.",
            ["duckduckgo"]="Sem perfis de anúncios; busca mantém logs anônimos; sincronização do navegador é criptografada.",
            ["chromium"]="Motor do Chrome sem sincronização e serviços do Google; buscas dependem do motor que você escolher.",
            ["cachy-browser"]="Baseado em Chromium com patches mínimos documentados; telemetria segue padrões do Chromium original menos serviços do Google.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_pt = new()
    {

            ["arc"]="Sincronização por conta via servidores da The Browser Company; recursos de IA enviam conteúdo da página aos modelos deles.",
            ["operagx"]="Igual ao Opera: dados de navegação em servidores da Opera; VPN grátis via infraestrutura da Opera.",
            ["mullvad"]="Nada: sem telemetria, sem identificadores, anti-impressão digital ativado por padrão.",
            ["thorium"]="Igual ao Chromium menos vários serviços do Google e solicitações em segundo plano.",
            ["floorp"]="Telemetria desativada por padrão; alguns recursos falam com servidores do projeto japonês.",
            ["waterfox"]="Telemetria removida; monetização só via buscadores parceiros.",
            ["ungoogled"]="Sem conexões com o Google por projeto; sem telemetria; pesquisas dependem do buscador que você escolher.",
            ["dia"]="Conteúdo da página e conversas enviados aos modelos de IA da The Browser Company; exige conta.",
            ["avast-secure"]="Telemetria da Avast e ofertas promocionais; dado o histórico da controladora, presuma perfilização até prova em contrário.",
            ["librewolf"]="Nada por padrão: telemetria, Pocket, serviços do Google e coleta de dados removidos na compilação.",
            ["firefox"]="Telemetria, relatórios de falha e sugestões por localização; experimentos de medição de anúncios com preservação de privacidade (PPA).",
            ["opera"]="Dados de navegação processados em servidores da Opera; VPN grátis passa pela infraestrutura da Opera.",
            ["whale"]="Sincronização por conta Naver, telemetria de uso para servidores da Naver; personalização ligada aos serviços Naver.",
            ["kagi-orion"]="Zero telemetria alegada; sem perfis de anúncios; sincronização na Apple via iCloud, local no Windows.",
            ["pale-moon"]="Pouca telemetria, mas o motor desatualizado é o risco maior.",
            ["vivaldi"]="Sem perfilização; sincronização criptografada de ponta a ponta; estatísticas de uso só se você optar.",
            ["tor-browser"]="Tráfego salta por 3 retransmissores voluntários criptografados; sem telemetria; entrar em contas pessoais quebra seu próprio anonimato.",
            ["zen"]="Baseado em Firefox com telemetria desligada; atualizações via infraestrutura da Mozilla.",
            ["edge"]="Dados de diagnóstico, histórico de navegação com sincronização ativada, ID de publicidade para anúncios personalizados.",
            ["falkon"]="Telemetria mínima; integração com a área de trabalho KDE só se você usar esses serviços.",
            ["epic-browser"]="Diz não ter telemetria e bloquear rastreadores agressivamente; inverificável por ser código fechado.",
            ["yandex"]="Telemetria ampla, dados de busca, localização e voz para o Yandex (Rússia); anúncios personalizados.",
            ["chrome"]="Sincroniza histórico, buscas, localização e voz com sua conta Google; personalização de anúncios por padrão.",
            ["brave"]="Mínimo por projeto: estatísticas P3A com preservação de privacidade (dá para desativar), sem rastreamento de busca ou perfil.",
            ["brave-debloat"]="Desliga extras e telemetria.",
            ["edge-debloat"]="Desliga compras, extras e telemetria.",
            ["comet"]="Contexto de navegação processado pela IA da Perplexity; exige conta; histórico de busca ligado ao seu perfil Perplexity.",
            ["duckduckgo"]="Sem perfis de anúncios; busca mantém logs anônimos; sincronização do navegador é criptografada.",
            ["chromium"]="Motor do Chrome sem sincronização e serviços do Google; buscas dependem do motor que você escolher.",
            ["cachy-browser"]="Baseado em Chromium com patches mínimos documentados; telemetria segue padrões do Chromium original menos serviços do Google.",
        
    };
}
