namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_pt = new()
    {

            ["arc"]="Desenvolvimento congelado (2025) com a aposta no navegador IA Dia; CVE antigo permitiu sequestro de sessões via ID de usuário; equipe de segurança cresceu de 1 para 5.",
            ["operagx"]="Mesma matriz do Opera: a chinesa Kunlun Tech detém ~72%. Os famosos limitadores de CPU/RAM são quase cosméticos; as acusações da Hindenburg atingem o grupo.",
            ["mullvad"]="Sem grandes escândalos. Codesenvolvido com o Projeto Tor (2023); a VPN da Mullvad recusou pedidos policiais de acesso.",
            ["thorium"]="Builds não oficiais de Chromium por um desenvolvedor; otimizado para CPUs AVX2; sem garantia de builds reproduzíveis, então há confiança no mantenedor.",
            ["floorp"]="Projeto japonês fechado por anos apesar de usar Firefox; abriu o código em 2023. Governança comunitária, mas pequena.",
            ["waterfox"]="Vendido à empresa de anúncios System1 (2020); o fundador Alex Kontos recomprou a independência (2023). Sem escândalos desde então.",
            ["ungoogled"]="Sem escândalos; o custo é verificar atualizações manualmente e quebras ocasionais pela remoção agressiva de dependências do Google.",
            ["dia"]="Sucessor do Arc, beta por convite; a IA lê conteúdo e histórico de chat para agir por você; ainda sem auditoria independente.",
            ["avast-secure"]="A matriz Avast vendeu históricos via Jumpshot (fechada em 2020; acordo de US$ 16,5 mi com a FTC em 2024); o antivírus Avast o promove com insistência.",
            ["librewolf"]="Sem grandes escândalos. Única queixa: patches podem chegar dias após o Firefox enquanto a comunidade recompila.",
            ["firefox"]="A Mozilla vive do acordo padrão com o Google; telemetria ativada por padrão; em 2025 os termos insinuaram licença ampla de dados (revertida após críticas).",
            ["opera"]="~72% da chinesa Kunlun Tech (registros SEC). A Hindenburg denunciou empréstimos de 365-876% de APR em seus apps fintech. VPN auditada pela Deloitte (sem logs).",
            ["whale"]="Do gigante coreano Naver; sujeito à lei de dados sul-coreana; serviços laterais (tradução, compras) falam com a Naver.",
            ["kagi-orion"]="Código fechado; a versão Windows é nova e instável. O negócio da Kagi é a busca paga: privacidade como produto, não vigilância.",
            ["pale-moon"]="Motor Goanna antigo, sem anos de mitigações do Chromium/Firefox; quebras frequentes; projeto de um mantenedor.",
            ["vivaldi"]="Traz favoritos afiliados e monetiza a busca padrão; a interface é fechada embora o núcleo seja aberto. Em dez. de 2024 ativou em segredo scripts de atribuição em buscadores parceiros. Empresa norueguesa, sem perfis.",
            ["tor-browser"]="Serve à evasão de censura e a mercados da darknet; nós de saída veem tráfego não HTTPS; bloqueado ou sinalizado por governos e sites.",
            ["zen"]="Projeto jovem com equipe mínima; ainda sem auditoria independente. Lançamentos rápidos podem trazer regressões.",
            ["edge"]="Envia IDs únicos mesmo com telemetria off; anúncios agressivos do Bing, sugestões patrocinadas e insistência em voltar.",
            ["falkon"]="Patches do QtWebEngine (núcleo Chromium) atrasados; equipe KDE pequena; builds Windows menos testados que os Linux.",
            ["epic-browser"]="Código fechado apesar das promessas: lista de rastreadores e tratamento de dados sem auditoria independente.",
            ["yandex"]="Jurisdição russa: leis permitem acesso estatal; modo Turbo proxia páginas via Yandex; a assistente Alice processa voz na Rússia.",
            ["chrome"]="Antitruste: DOJ obteve remédios (set. 2025): Google deve compartilhar dados e não assinar exclusivas. Ação do incógnito terminou com bilhões de registros apagados. Privacy Sandbox mantém perfis em casa.",
            ["brave"]="Em 2020 inseriu códigos de afiliado em URLs de corretoras (CEO pediu desculpas). Doações passadas de Brendan Eich voltam à tona às vezes. No mais, bom histórico.",
            ["brave-debloat"]="Aparece como gerenciado. Exige Brave 1.82+ (Playlist 1.84+).",
            ["edge-debloat"]="Aparece como gerenciado.",
            ["comet"]="Navegador IA da Perplexity: conteúdo enviado a modelos; Cloudflare acusou raspagem agressiva (2025); navegação agêntica traz novas dúvidas.",
            ["duckduckgo"]="Em 2022 deixou passar trackers da Microsoft por acordo com o Bing (revelado por Zach Edwards); corrigido em agosto de 2022.",
            ["chromium"]="Sem atualizador no Windows: patches dependem de quem compila seu binário; algumas APIs do Google (sync) foram removidas.",
            ["cachy-browser"]="Build de nicho da comunidade CachyOS (Arch); exige AVX2; poucos revisores frente aos grandes navegadores.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_pt = new()
    {

            ["arc"]="Sincronização com conta nos servidores da The Browser Company; a IA envia o conteúdo aos seus modelos.",
            ["operagx"]="Igual ao Opera: dados nos servidores Opera; VPN grátis via infraestrutura Opera.",
            ["mullvad"]="Nada: sem telemetria nem identificadores, anti-fingerprint ativado por padrão.",
            ["thorium"]="Igual ao Chromium sem vários serviços do Google nem requisições em segundo plano.",
            ["floorp"]="Telemetria desativada por padrão; alguns recursos falam com servidores do projeto japonês.",
            ["waterfox"]="Telemetria removida; monetização só via buscadores parceiros.",
            ["ungoogled"]="Sem conexões ao Google por projeto; sem telemetria; buscas dependem do seu motor.",
            ["dia"]="Conteúdo e conversas enviados aos modelos de IA da The Browser Company; exige conta.",
            ["avast-secure"]="Telemetria e ofertas da Avast; dado o histórico da matriz, presuma perfis salvo prova contrária.",
            ["librewolf"]="Nada por padrão: telemetria, Pocket, serviços do Google e coleta removidos na compilação.",
            ["firefox"]="Telemetria, relatórios de falha e sugestões por local; experimentos de medição privada de anúncios (PPA).",
            ["opera"]="Dados processados nos servidores Opera; VPN grátis passa pela infraestrutura Opera.",
            ["whale"]="Sincronização com conta Naver, telemetria de uso para a Naver; personalização ligada à Naver.",
            ["kagi-orion"]="Zero telemetria declarado; sem perfis de anúncios; sync na Apple via iCloud, local no Windows.",
            ["pale-moon"]="Pouca telemetria, mas o motor desatualizado é o risco maior.",
            ["vivaldi"]="Sem perfis; sincronização criptografada de ponta a ponta; estatísticas só com adesão.",
            ["tor-browser"]="Tráfego salta por 3 relays voluntários criptografados; sem telemetria; login quebra seu anonimato.",
            ["zen"]="Baseado em Firefox sem telemetria; atualizações via infraestrutura Mozilla.",
            ["edge"]="Dados de diagnóstico, histórico com sync ativada e ID de publicidade para anúncios personalizados.",
            ["falkon"]="Telemetria mínima; integração com KDE só com esses serviços.",
            ["epic-browser"]="Diz não ter telemetria e bloqueia rastreadores; inverificável por ser fechado.",
            ["yandex"]="Telemetria ampla: buscas, local e voz para a Yandex (Rússia); anúncios personalizados.",
            ["chrome"]="Sincroniza histórico, buscas, local e voz com sua conta Google; personalização por padrão.",
            ["brave"]="Mínimo por projeto: estatísticas privadas P3A (desativáveis), sem rastreio de buscas ou perfis.",
            ["brave-debloat"]="12 políticas: desativam Rewards, Wallet, VPN, Leo, Tor, News, Talk, Speedreader, Wayback, Playlist, P3A e ping de stats.",
            ["edge-debloat"]="14 políticas : desativam compras, sidebars, Rewards, notícias, widgets e telemetria.",
            ["comet"]="Contexto processado pela IA da Perplexity; exige conta; histórico ligado ao seu perfil.",
            ["duckduckgo"]="Sem perfis de anúncios; buscas com logs anônimos; sincronização criptografada.",
            ["chromium"]="Motor do Chrome sem sync nem serviços do Google; buscas dependem do seu motor.",
            ["cachy-browser"]="Baseado em Chromium com patches mínimos documentados; telemetria como o Chromium, sem serviços do Google.",
        
    };
}
