namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_ptPT = new()
    {

            ["arc"]="Desenvolvimento congelado (2025) enquanto a empresa migra para o navegador de IA Dia, mas ainda recebe atualizações de segurança do Chromium toda semana; no CVE-2024-45489, ACLs do Firebase mal configuradas permitiram executar JavaScript arbitrário no contexto de sincronização privilegiado de outro utilizador (relatado por xyz3va; nenhum utilizador afetado); a equipe de segurança cresceu de 1 para 5.",
            ["operagx"]="Mesma controladora do Opera: a China's Kunlun Tech tem ~72%. Os famosos limitadores de CPU/RAM são mais cosmetic; as acusações da Hindenburg valem para o grupo.",
            ["mullvad"]="Sem escândalos grandes. Desenvolvido junto com o Tor Project (2023); o Mullvad VPN ganhou fama por recusar pedidos de acesso da polícia.",
            ["thorium"]="Builds não oficiais do Chromium feitos por um único desenvolvedor; otimizado para CPUs com AVX2; sem garantia de builds reproduzíveis, então você confia no mantenedor.",
            ["floorp"]="Projeto japonês que ficou anos de código fechado apesar de usar o Firefox; abriu o código em 2023. A gestão é da comunidade, mas pequena.",
            ["waterfox"]="Vendido para a empresa de anúncios System1 (2020); o fundador Alex Kontos recomprou a independência (2023). Sem escândalos desde então.",
            ["ungoogled"]="Sem escândalos; o preço é conferir as atualizações manualmente e a quebra ocasional de sites pela remoção agressiva de dependências do Google.",
            ["dia"]="Sucessor do Arc, disponível em geral no macOS desde 8 de outubro de 2025; a IA lê o conteúdo das páginas e o histórico de chat para agir por você; The Browser Company foi adquirida pela Atlassian por US$ 610 milhões.",
            ["avast-secure"]="A controladora Avast foi flagrada vendendo históricos de navegação pela subsidiária Jumpshot (encerrada em 2020; acordo de US$ 16,5 milhões com o FTC em 2024); o antivírus da Avast empurra o navegador com força.",
            ["librewolf"]="Sem escândalos grandes. Única queixa: os patches de segurança podem atrasar alguns dias em relação ao lançamento do Firefox enquanto a comunidade recompila.",
            ["firefox"]="A Mozilla tira a maior parte da receita do acordo de predefinição com o Google; telemetria ligada por predefinição; os termos de 2025 sugeriram por pouco tempo uma licença ampla de dados (desfeita após a reação).",
            ["opera"]="~72% da China's Kunlun Tech (documentos da SEC). A Hindenburg Research acusou os apps de fintech de cobrar empréstimos a 365–876% ao ano (APR). VPN auditada pela Deloitte (no-log).",
            ["whale"]="Pertence ao gigante de internet sul-coreano Naver; sujeito à lei de dados da Coreia do Sul; os serviços da barra lateral (tradução, compras) ligam para a Naver.",
            ["kagi-orion"]="Código fechado; a versão para Windows é nova e crua. O negócio é o modelo de busca paga da Kagi — privacidade como produto, não vigilância.",
            ["pale-moon"]="O motor Goanna, antiquíssimo, perde anos de mitigações de segurança do Chromium/Firefox; quebra de sites é comum; projeto com um único mantenedor.",
            ["vivaldi"]="Vem com favoritos de afiliado e monetiza a busca predefinição (afiliado do Google); a interface é de código fechado, mesmo com o núcleo do Chromium aberto. Dez. de 2024: ligou scripts de atribuição de anúncios em buscadores parceiros sem avisar, para gerar receita. Empresa norueguesa, sem perfilização.",
            ["tor-browser"]="Usado tanto para driblar censura quanto em mercados da darknet (Silk Road); os nós de saída podem ver o tráfego que não é HTTPS; bloqueado ou sinalizado por alguns governos e sites.",
            ["zen"]="Projeto novo com uma equipe minúscula; ainda sem auditoria de segurança independente. Lançamentos rápidos podem introduzir regressões.",
            ["edge"]="Envia IDs únicos de dispositivo mesmo com a telemetria desligada; anúncios agressivos do Bing na barra lateral, sugestões patrocinadas e avisos persistentes para voltar ao Edge.",
            ["falkon"]="Os patches de segurança do QtWebEngine (núcleo do Chromium) atrasam em relação ao upstream; equipe pequena do KDE; builds para Windows são menos testados que os de Linux.",
            ["epic-browser"]="Código fechado apesar das alegações de privacidade: a lista de bloqueadores e o tratamento de dados não podem ser auditados de forma independente.",
            ["yandex"]="Jurisdição russa: as leis de dados permitem acesso do Estado (SORM); o modo Turbo faz proxy das páginas pelos servidores do Yandex; a assistente Alice processa voz na Rússia.",
            ["chrome"]="Caso antitruste: o DOJ venceu os remédios (set. 2025) — o Google precisa partilhar dados de busca com rivais, sem contratos default exclusivos. A ação sobre rastreamento no modo anônimo terminou com a exclusão de bilhões de registros. A maioria das APIs de medição de anúncios do Privacy Sandbox foi descontinuada em out. de 2025 e o Google manteve cookies de terceiros, então o rastreamento de anúncios entre sites não fica restrito ao Google.",
            ["brave"]="2020: adicionou automaticamente códigos de afiliado em URLs de corretoras de cripto (o CEO pediu desculpas). O passado de doação da Prop-8 do fundador Brendan Eich volta à tona de tempos em tempos. Fora isso, histórico forte de privacidade.",
            ["comet"]="Navegador de IA da Perplexity: o conteúdo das páginas é enviado a modelos de IA; injeção indireta de prompts divulgada pela Brave (20/08/2025) e CometJacking divulgado pela LayerX (04/10/2025).",
            ["duckduckgo"]="2022: o navegador deixava passar rastreadores da Microsoft por causa de um acordo de sindicância com o Bing (o procurador Zach Edwards expôs); corrigido em agosto de 2022.",
            ["chromium"]="Sem atualizador automático nos builds para Windows: as correções de segurança dependem de quem compilou seu binário (Hibbiki etc.); alguns serviços do Google (sincronização) foram removidos.",
            ["cachy-browser"]="Build de nicho feito pela comunidade do CachyOS (Arch); exige AVX2; superfície de revisão mínima, então menos olhos no código do que nos navegadores mais usados.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_ptPT = new()
    {

            ["arc"]="Sincronização por conta via servidores da The Browser Company; recursos de IA enviam o conteúdo da página aos provedores de serviço OpenAI e Anthropic, com opt-in por recurso.",
            ["operagx"]="Igual ao Opera: dados de navegação em servidores da Opera; VPN grátis via infraestrutura da Opera.",
            ["mullvad"]="Nada: sem telemetria, sem identificadores, anti-impressão digital ativado por predefinição.",
            ["thorium"]="Igual ao Chromium menos vários serviços do Google e solicitações em segundo plano.",
            ["floorp"]="Telemetria desativada por predefinição; alguns recursos falam com servidores do projeto japonês.",
            ["waterfox"]="Telemetria removida; monetização só via buscadores parceiros.",
            ["ungoogled"]="Sem conexões com o Google por projeto; sem telemetria; procuras dependem do buscador que você escolher.",
            ["dia"]="Conteúdo da página e conversas enviados aos provedores de serviço de IA que a The Browser Company usa nos recursos de IA; exige conta.",
            ["avast-secure"]="Telemetria da Avast e ofertas promocionais; dado o histórico da controladora, presuma perfilização até prova em contrário.",
            ["librewolf"]="Nada por predefinição: telemetria, Pocket, serviços do Google e coleta de dados removidos na compilação.",
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
            ["chrome"]="Sincroniza histórico, buscas, localização e voz com sua conta Google; personalização de anúncios por predefinição.",
            ["brave"]="Mínimo por projeto: estatísticas P3A com preservação de privacidade (dá para desativar), sem rastreamento de busca ou perfil.",
            ["comet"]="Contexto de navegação processado pela IA da Perplexity; exige conta; histórico de busca ligado ao seu perfil Perplexity.",
            ["duckduckgo"]="Sem perfis de anúncios; busca mantém logs anônimos; sincronização do navegador é criptografada.",
            ["chromium"]="Motor do Chrome sem sincronização e serviços do Google; buscas dependem do motor que você escolher.",
            ["cachy-browser"]="Baseado em Chromium com patches mínimos documentados; telemetria segue padrões do Chromium original menos serviços do Google.",
        
    };
}
