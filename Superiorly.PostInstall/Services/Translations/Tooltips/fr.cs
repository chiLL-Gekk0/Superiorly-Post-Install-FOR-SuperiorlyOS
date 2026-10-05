namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_fr = new()
    {

            ["arc"]="Fonctionnalités figées (2025) car l'entreprise mise sur le navigateur IA Dia, mais les mises à jour de sécurité Chromium continuent chaque semaine ; le CVE-2024-45489 (ACL Firebase mal configurées) a permis d'exécuter du JavaScript arbitraire dans le contexte de synchronisation privilégié d'un autre utilisateur (signalé par xyz3va ; zéro utilisateur affecté) ; l'équipe sécurité est passée de 1 à 5.",
            ["operagx"]="Même maison mère qu'Opera : le chinois Kunlun Tech détient ~72 %. Les célèbres limiteurs CPU/RAM sont surtout cosmétiques ; les allégations de Hindenburg concernent le groupe.",
            ["mullvad"]="Aucun scandale majeur. Codéveloppé avec le Tor Project (2023) ; le VPN Mullvad a refusé des demandes d'accès de la police.",
            ["thorium"]="Compilations Chromium non officielles par un seul développeur ; optimisé pour CPU AVX2 ; sans garantie de builds reproductibles, vous faites confiance au mainteneur.",
            ["floorp"]="Projet japonais resté fermé des années malgré Firefox ; code ouvert en 2023. Gouvernance communautaire mais réduite.",
            ["waterfox"]="Vendu à la régie System1 (2020) ; le fondateur Alex Kontos a racheté son indépendance (2023). Aucun scandale depuis.",
            ["ungoogled"]="Aucun scandale ; le prix est une vérification manuelle des mises à jour et des sites parfois cassés par la suppression agressive des dépendances Google.",
            ["dia"]="Successeur d'Arc, disponible pour tous sur macOS depuis le 8 octobre 2025 ; l'IA lit le contenu des pages et l'historique pour agir pour vous ; The Browser Company a été racheté par Atlassian pour 610 millions de dollars.",
            ["avast-secure"]="La maison mère Avast a vendu des historiques via Jumpshot (fermé en 2020 ; accord $16.5M avec la FTC en 2024) ; le navigateur est poussé par l'antivirus Avast.",
            ["librewolf"]="Aucun scandale majeur. Seul reproche : les correctifs peuvent suivre la version Firefox de quelques jours pendant la reconstruction communautaire.",
            ["firefox"]="Mozilla tire l'essentiel de ses revenus de l'accord Google par défaut ; télémétrie activée par défaut ; en 2025 des CGU ont brièvement suggéré une large licence de données (retirée après protestations).",
            ["opera"]="Détenu à ~72 % par le chinois Kunlun Tech (dépôts SEC). Hindenburg Research a dénoncé des prêts à 365-876% APR via ses apps fintech. VPN audité par Deloitte (sans journaux).",
            ["whale"]="Détenu par le géant coréen Naver ; soumis au droit sud-coréen des données ; les services latéraux (traduction, achats) contactent Naver.",
            ["kagi-orion"]="Code fermé ; la version Windows est jeune et perfectible. Le modèle payant de Kagi est l'activité : la confidentialité comme produit, pas la surveillance.",
            ["pale-moon"]="Son ancien moteur Goanna manque des années d'atténuations Chromium/Firefox ; sites cassés fréquents ; projet d'un seul mainteneur.",
            ["vivaldi"]="Livre des favoris affiliés et monétise la recherche par défaut ; interface fermée bien que le cœur Chromium soit ouvert. Déc. 2024 : scripts d'attribution pub activés discrètement sur des moteurs partenaires (Google) pour revenu. Société norvégienne, sans profilage.",
            ["tor-browser"]="Sert au contournement de la censure comme aux marchés du darknet ; les nœuds de sortie voient le trafic non HTTPS ; bloqué ou signalé par certains gouvernements et sites.",
            ["zen"]="Jeune projet à petite équipe ; sans audit de sécurité indépendant. Des versions rapides peuvent apporter des régressions.",
            ["edge"]="Envoie des identifiants uniques même avec la télémétrie coupée ; pubs Bing agressives dans la barre latérale, suggestions sponsorisées et relances persistantes.",
            ["falkon"]="Correctifs QtWebEngine (cœur Chromium) en retard sur l'amont ; petite équipe KDE ; versions Windows moins éprouvées que celles Linux.",
            ["epic-browser"]="Code fermé malgré les promesses de confidentialité : la liste de bloqueurs et le traitement des données ne sont pas auditables.",
            ["yandex"]="Juridiction russe : les lois permettent l'accès de l'État (SORM) ; le mode Turbo proxifie les pages via les serveurs Yandex ; l'assistant Alice traite la voix en Russie.",
            ["chrome"]="Antitrust : le DOJ a obtenu des remèdes (sept. 2025) — Google doit partager les données de recherche, sans accords d'exclusivité. Le procès du mode incognito s'est soldé par la suppression de milliards d'enregistrements. La plupart des API de mesure publicitaire de Privacy Sandbox ont été retirées en oct. 2025 et Google a conservé les cookies tiers : le pistage publicitaire intersites n'est donc pas confiné à Google.",
            ["brave"]="2020 : codes affiliés ajoutés aux URL d'échanges crypto (le PDG s'est excusé). Le passé de dons de Brendan Eich refait parfois surface. Sinon bon bilan confidentialité.",
            ["comet"]="Navigateur IA de Perplexity : le contenu est envoyé aux modèles IA ; injection indirecte de prompts publiée par Brave (20/08/2025) et CometJacking publié par LayerX (04/10/2025).",
            ["duckduckgo"]="2022 : son navigateur laissait passer les traqueurs Microsoft à cause d'un accord Bing (révélé par Zach Edwards) ; corrigé en août 2022.",
            ["chromium"]="Sans mise à jour auto sur Windows : les correctifs dépendent de celui qui compile votre binaire ; certaines API Google (sync) sont retirées.",
            ["cachy-browser"]="Compilation de niche par la communauté CachyOS (Arch) ; exige AVX2 ; surface de revue réduite, moins d'yeux que les grands navigateurs.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_fr = new()
    {

            ["arc"]="Synchronisation par compte via les serveurs de The Browser Company ; l'IA envoie le contenu aux prestataires OpenAI et Anthropic, activation par fonctionnalité.",
            ["operagx"]="Comme Opera : données de navigation sur les serveurs Opera ; VPN gratuit via l'infrastructure Opera.",
            ["mullvad"]="Aucune : sans télémétrie ni identifiants, anti-fingerprinting activé par défaut.",
            ["thorium"]="Comme Chromium sans plusieurs services Google ni requêtes en arrière-plan.",
            ["floorp"]="Télémétrie désactivée par défaut ; quelques fonctions contactent les serveurs du projet japonais.",
            ["waterfox"]="Télémétrie supprimée ; monétisation via les moteurs partenaires uniquement.",
            ["ungoogled"]="Sans connexions Google par conception ; sans télémétrie ; la recherche dépend de votre moteur.",
            ["dia"]="Le contenu et les conversations sont envoyés aux prestataires de services IA que The Browser Company utilise pour ses fonctions IA ; compte requis.",
            ["avast-secure"]="Télémétrie Avast et offres promotionnelles ; vu le passé de la maison mère, supposez un profilage sauf preuve contraire.",
            ["librewolf"]="Rien par défaut : télémétrie, Pocket, services Google et collecte supprimés à la compilation.",
            ["firefox"]="Télémétrie, rapports de crash et suggestions géolocalisées ; essais de mesure pub respectueuse (PPA).",
            ["opera"]="Données traitées sur les serveurs Opera ; le VPN gratuit passe par l'infrastructure Opera.",
            ["whale"]="Sync du compte Naver, télémétrie d'usage vers Naver ; personnalisation liée aux services Naver.",
            ["kagi-orion"]="Zéro télémétrie annoncée ; sans profils pub ; sync sur Apple via iCloud, locale sur Windows.",
            ["pale-moon"]="Peu de télémétrie, mais le moteur dépassé est le risque majeur.",
            ["vivaldi"]="Sans profilage ; sync chiffrée de bout en bout ; stats d'usage seulement si vous l'acceptez.",
            ["tor-browser"]="Le trafic passe par 3 relais bénévoles chiffrés ; sans télémétrie ; vous connecter à vos comptes brise votre anonymat.",
            ["zen"]="Basé sur Firefox sans télémétrie ; mises à jour via l'infrastructure Mozilla.",
            ["edge"]="Données de diagnostic, historique avec sync activée et ID publicitaire pour annonces personnalisées.",
            ["falkon"]="Télémétrie minimale ; intégration KDE seulement si vous utilisez ces services.",
            ["epic-browser"]="Annonce sans télémétrie et bloque les traqueurs ; invérifiable car code fermé.",
            ["yandex"]="Télémétrie large, recherche, position et voix vers Yandex (Russie) ; pubs personnalisées.",
            ["chrome"]="Synchronise historique, recherches, position et voix avec votre compte Google ; personnalisation par défaut.",
            ["brave"]="Minimal par conception : stats privées P3A (désactivables), sans suivi de recherche ni profils.",
            ["comet"]="Contexte traité par l'IA Perplexity ; compte requis ; historique lié à votre profil Perplexity.",
            ["duckduckgo"]="Sans profils pub ; recherche avec journaux anonymes ; sync chiffrée.",
            ["chromium"]="Moteur Chrome sans sync ni services Google ; la recherche dépend de votre moteur.",
            ["cachy-browser"]="Basé sur Chromium avec correctifs documentés minimaux ; télémétrie comme Chromium sans services Google.",
        
    };
}
