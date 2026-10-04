namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_ptBR = new()
    {

            ["arc"]="Desenvolvimento congelado (2025) com a migração da empresa para o navegador de IA Dia; CVE passada permitiu sequestro de sessões via ID de usuário; equipe de segurança cresceu de 1 para 5.",
            ["operagx"]="Mesma controladora do Opera: a chinesa Kunlun Tech detém ~72%. Os famosos limitadores de CPU/RAM são majoritariamente cosméticos; as alegações da Hindenburg valem para o grupo.",
            ["mullvad"]="Sem grandes escândalos. Codesenvolvido com o Tor Project (2023); a Mullvad VPN recusou pedidos de acesso da polícia.",
            ["thorium"]="Compilações Chromium não oficiais de um desenvolvedor; otimizado para CPUs AVX2; sem garantia de compilações reproduzíveis, então você confia no mantenedor.",
            ["floorp"]="Projeto japonês que foi código fechado por anos apesar de usar Firefox; abriu o código em 2023. Governança comunitária, mas pequena.",
            ["waterfox"]="Vendido para a empresa de anúncios System1 (2020); o fundador Alex Kontos recomprou a independência (2023). Sem escândalos desde então.",
            ["ungoogled"]="Sem escândalos; o custo é verificar atualizações manualmente e quebras ocasionais de sites pela remoção agressiva de dependências do Google.",
            ["dia"]="Sucessor do Arc, beta por convite; a IA lê o conteúdo da página e o histórico de chat para agir por você; sem auditoria de segurança independente ainda.",
            ["avast-secure"]="A controladora Avast foi pega vendendo históricos de navegação via subsidiária Jumpshot (encerrada em 2020; acordo de US$ 16,5 mi com a FTC em 2024); o navegador é empurrado pelo antivírus Avast.",
            ["librewolf"]="Sem grandes escândalos. Única queixa: patches de segurança podem atrasar dias em relação ao Firefox enquanto a comunidade recompila.",
            ["firefox"]="A Mozilla ganha a maior parte da receita com o acordo padrão do Google; telemetria ativada por padrão; Termos de 2025 sugeriram brevemente licença ampla de dados (revertida após reação).",
            ["opera"]="~72% da chinesa Kunlun Tech (registros na SEC). A Hindenburg Research alegou que seus apps fintech cobravam 365-876% de juros anuais. VPN auditada pela Deloitte (sem logs).",
            ["whale"]="Da gigante coreana de internet Naver; sujeito à lei de dados sul-coreana; serviços da barra lateral (tradução, compras) falam com a Naver.",
            ["kagi-orion"]="Código fechado; a versão para Windows é nova e instável. O modelo de busca paga da Kagi é o negócio — privacidade como produto, não vigilância.",
            ["pale-moon"]="Motor Goanna antigo perde anos de mitigações de segurança do Chromium/Firefox; quebra de sites é comum; projeto de um mantenedor.",
            ["vivaldi"]="Traz favoritos afiliados e monetiza a busca padrão (afiliado Google); a interface é código fechado embora o núcleo Chromium seja aberto. Dez/2024: ativou em segredo scripts de atribuição de anúncios em buscadores parceiros por receita. Empresa norueguesa, sem perfilização.",
            ["tor-browser"]="Usado tanto para driblar censura quanto para mercados da darknet (Silk Road); nós de saída veem tráfego não HTTPS; bloqueado ou sinalizado por alguns governos e sites.",
            ["zen"]="Projeto novo com equipe minúscula; sem auditoria de segurança independente ainda. Lançamentos rápidos podem trazer regressões.",
            ["edge"]="Envia IDs únicos de dispositivo mesmo com telemetria desligada; anúncios agressivos da barra lateral Bing, sugestões patrocinadas e avisos persistentes para voltar.",
            ["falkon"]="Patches de segurança do QtWebEngine (núcleo Chromium) atrasam em relação ao original; equipe KDE pequena; compilações para Windows menos testadas que as de Linux.",
            ["epic-browser"]="Código fechado apesar das promessas de privacidade: a lista de bloqueio e o tratamento de dados não podem ser auditados de forma independente.",
            ["yandex"]="Jurisdição russa: leis de dados permitem acesso do Estado (SORM); o modo Turbo passa páginas por servidores do Yandex; a assistente Alice processa voz na Rússia.",
            ["chrome"]="Caso antitruste: DOJ venceu remédios (set/2025) — Google deve compartilhar dados de busca com rivais, sem acordos exclusivos de padrão. Ação do modo anônimo terminou com exclusão de bilhões de registros. Privacy Sandbox mantém o perfil de anúncios em casa.",
            ["brave"]="2020: adicionou códigos de afiliado a URLs de corretoras de cripto (CEO pediu desculpas). O passado de doação Prop-8 do fundador Brendan Eich reaparece às vezes. De resto, histórico forte de privacidade.",
            ["brave-debloat"]="Aparece como gerenciado pela sua organização.",
            ["edge-debloat"]="Aparece como gerenciado pela sua organização.",
            ["comet"]="Navegador de IA da Perplexity: conteúdo da página é enviado a modelos de IA; Cloudflare o acusou de raspagem agressiva (2025); navegação por agentes traz novas dúvidas de privacidade.",
            ["duckduckgo"]="2022: o navegador deixava passar rastreadores da Microsoft por acordo de distribuição do Bing (pesquisador Zach Edwards revelou); corrigido em ago/2022.",
            ["chromium"]="Sem atualizador automático nas compilações para Windows: correções de segurança dependem de quem compila seu binário (Hibbiki etc.); algumas APIs do Google (sincronização) removidas.",
            ["cachy-browser"]="Compilação de nicho da comunidade CachyOS (Arch); exige AVX2; superfície de revisão minúscula, menos olhos no código que navegadores populares.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_ptBR = new()
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
