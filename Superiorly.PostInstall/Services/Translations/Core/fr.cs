namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_fr = new()
    {
 ["home"]="Accueil", ["browsers"]="Navigateurs", ["tools"]="Outils", ["tweaking"]="Optimisation", ["troubleshooting"]="Dépannage" 
    };
    private static readonly Dictionary<string, string> SectionDescs_fr = new()
    {
 ["home"]="Bienvenue dans votre boîte à outils", ["browsers"]="Utilitaires et correctifs pour navigateurs", ["tools"]="Téléchargez et exécutez des utilitaires portables.", ["tweaking"]="Ajustements des pilotes, GPU et système.", ["troubleshooting"]="Commutateurs rapides et correctifs du système." 
    };
    private static readonly Dictionary<string, string> TabTitles_fr = new()
    {
 ["mainstream"]="Populaires", ["privacy"]="Confidentialité", ["forks"]="Forks et personnalisés", ["software"]="Logiciels", ["store-downloader"]="Téléchargeur Microsoft Store", ["utilities"]="Utilitaires", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Ajustements du registre", ["win32"]="Win32PrioritySeparation", ["powerplans"]="Plans d’alimentation", ["connectivity"]="Connectivité", ["devices"]="Appareils", ["security"]="Sécurité", ["gaming"]="Jeux", ["ai"]="Intelligence artificielle", ["debloat"]="Debloat", ["system"]="Système" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Notifications_fr = new()
    {
 ["opened"]="Ouvert - lancé", ["installed"]="Installé avec succès", ["failed"]="Échec de l’installation", ["open_failed"]="Échec de l’ouverture", ["enabled"]="Activé", ["disabled"]="Désactivé", ["apply_failed"]="Échec de l’application", ["applied"]="Appliqué" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_fr = new()
    {

            ["settings"]="Paramètres", ["language"]="Langue", ["theme"]="Thème", ["dark"]="Sombre", ["light"]="Clair", ["auto"]="Auto", ["default_theme"]="Thème par défaut",
            ["style"]="Style", ["win10_style"]="Style Windows 10", ["win11_style"]="Style Windows 11", ["close"]="Fermer",
            ["search_placeholder"]="Rechercher par nom, URL ou ID.", ["store_no_results"]="Aucun résultat. Essayez une autre recherche.", ["search"]="Rechercher", ["install"]="Installer",
            ["run"]="Exécuter", ["download"]="Télécharger", ["open"]="Ouvrir", ["apply"]="Appliquer",
            ["check_updates"]="Vérifier les mises à jour", ["update"]="Update", ["disclaimer"]="Vous êtes seul responsable des modifications.",
            ["quantum_title"]="Carte Quantum", ["quantum_subtitle"]="Toutes les valeurs valides de Win32PrioritySeparation. Cliquez sur une ligne pour l’appliquer.",
            ["open_quantum"]="Ouvrir la carte Quantum", ["current_win32"]="Win32PrioritySeparation actuel",
            ["load_list"]="Charger la liste", ["unload_list"]="Fermer la liste", ["activate"]="Activer", ["import"]="Importer", ["export"]="Exporter",
            ["select_all"]="Tout sélectionner", ["unselect_all"]="Tout désélectionner", ["uninstall"]="Désinstaller", ["delete"]="Supprimer",
            ["restore_default"]="Restaurer les valeurs par défaut", ["yes"]="Oui", ["no"]="Non",
            ["searching_for"]="Recherche de « {0} »...", ["downloading"]="Téléchargement de {0}...", ["starting"]="Démarrage de {0}...",
            ["applying"]="Application de {0}...", ["installing"]="Installation de {0}...",             ["loading"]="Chargement de {0}...",
            ["reading_plans"]="Lecture des plans d’alimentation...", ["populating_list"]="Création de la liste...",
            ["apps_found"]="{0} applications trouvées", ["nothing_found"]="Aucun élément trouvé", ["loaded_items"]="{0} éléments chargés",
            ["list_unloaded"]="Liste fermée",
            ["exported"]="{0} exporté",
            ["installed_n"]="{0} application(s) installée(s)", ["install_failed"]="Échec de l’installation",
            ["failed_admin"]="Échec - Exécutez en tant qu’administrateur ou redémarrez", ["failed"]="Échec",
            ["win32_set"]="Win32PrioritySeparation défini sur {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_fr = new()
    {
 ["run"]="Exécuter", ["download"]="Télécharger", ["apply"]="Appliquer", ["enable"]="Activer", ["disable"]="Désactiver", ["search"]="Rechercher", ["install"]="Installer", ["load list"]="Charger la liste", ["uninstall"]="Désinstaller", ["activate"]="Activer", ["delete"]="Supprimer", ["import .pow"]="Importer .pow", ["default"]="Par défaut", ["custom"]="Personnalisé", ["minimum"]="Minimum", ["disable mmcss"]="Désactiver MMCSS", ["bypass"]="Bypass", ["repeater"]="Répéteur", ["realtime"]="Temps réel", ["high"]="Haute", ["abovenormal"]="Supérieur à la normale", ["normal"]="Normal", ["belownormal"]="Inférieur à la normale", ["enhanced"]="Amélioré", ["legacy"]="Hérité", ["disabled"]="Désactivé", ["enabled"]="Activé", ["alwayson"]="Toujours activé", ["alwaysoff"]="Toujours désactivé", ["optin"]="Activation sélective", ["optout"]="Désactivation sélective", ["open cru"]="Ouvrir CRU", ["coming soon"]="Bientôt disponible", ["safe fivem/minecraft services"]="Services sécurisés FiveM/Minecraft", ["kernelos default"]="Superiorly par défaut" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> TabDescs_fr = new()
    {
 ["mainstream"]="Navigateurs du quotidien.", ["privacy"]="Navigateurs axés sur la confidentialité et l’anonymat.", ["forks"]="Versions communautaires basées sur Chromium et Firefox.", ["utilities"]="Outils de diagnostic du système et du matériel.", ["amd"]="Outils AMD GPU pour pilotes, fréquence, tension et registre.", ["nvidia"]="Outils NVIDIA pour installations propres, profils et P-States.", ["connectivity"]="Paramètres Wi-Fi, Bluetooth et limite de sauts du point d’accès.", ["devices"]="Correctifs pour imprimante, Gestionnaire des tâches et saisie de texte.", ["security"]="Isolation du noyau, pare-feu, UAC, liste de blocage des pilotes et protections mémoire.", ["gaming"]="Services Xbox et Opera GX.", ["ai"]="Navigation Chromium, WebKit et axée sur l’IA.", ["debloat"]="Browser privacy policies and vendor telemetry switches: Chrome, Edge, Firefox and Office.", ["system"]="Pilotes via Windows Update, menu Démarrer et correctifs du panneau Intel." , ["telemetry"]="Commutateurs de télémétrie, suggestions, publicités et collecte de données des éditeurs."
    };
    private static readonly Dictionary<string, string> SectionTabDescs_fr = new()
    {
 ["browsers|gaming"]="Opera GX avec limiteurs CPU, RAM et réseau intégrés.", ["tweaking|gaming"]="Services Xbox et services sécurisés FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_fr = new()
    {
 ["mainstream"]="Navigateurs du quotidien", ["privacy"]="Navigation anonyme", ["forks"]="Forks indépendants", ["utilities"]="Utilitaires système", ["amd"]="Outils Radeon", ["nvidia"]="Outils GeForce", ["connectivity"]="Paramètres sans fil", ["devices"]="Correctifs des appareils", ["security"]="Protections système", ["gaming"]="Services de jeu", ["ai"]="Navigateurs IA", ["debloat"]="Allègement des navigateurs", ["system"]="Correctifs Windows" , ["telemetry"]="Telemetry Fixes"
    };
    private static readonly Dictionary<string, string> SectionTabTitles_fr = new()
    {
 ["browsers|gaming"]="Navigateur de jeu", ["tweaking|gaming"]="Services de jeu" 
    };
    private static readonly Dictionary<string, string> UiExtra_fr = new()
    {
["state_on"]="Activé", ["state_off"]="Désactivé", 
            ["confirm_delete"]="Confirmer la suppression",
            ["confirm_enable"]="Appliquer cette modification ?",
            ["delete_plans"]="Supprimer {0} plan(s) ?",
            ["cant_delete_active"]="Vous ne pouvez pas supprimer le plan actif. Basculez d’abord vers un autre plan.",
            ["import_plan"]="Importer un plan d’alimentation", ["export_plan"]="Exporter un plan d’alimentation",
            ["ratio"]="ratio", ["long"]="Long", ["short"]="Court", ["fixed"]="Fixe", ["variable"]="Variable", ["boost"]="boost", ["current"]="actuel",
            ["needs_admin"]="Cette action requiert des privilèges d’administrateur.",
            ["restart_driver"]="Redémarrer le pilote d’affichage", ["reset_all"]="Tout réinitialiser", ["download_cru"]="Télécharger CRU",
            ["modify_quantum"]="Modifier Quantum", ["quantum_length"]="Longueur de Quantum", ["quantum_interval"]="Intervalle de Quantum",
            ["fix"]="Corriger", ["preview_hex"]="Aperçu Hex", ["preview_bits"]="Aperçu des bits",
            ["minimize"]="Réduire", ["maximize"]="Agrandir", ["toggle_theme"]="Basculer entre thème clair et sombre",
            ["follow_theme"]="Suivre le thème Windows", ["square"]="Coins carrés", ["rounded"]="Coins arrondis",
            ["join"]="REJOINDRE", ["follow"]="SUIVRE", ["visit"]="VISITER", ["copy_link"]="Copier le lien", ["copied"]="Copié",
            ["no_profiles_found"]="Aucun profil trouvé. Placez des fichiers .nip dans le dossier Nvidia Profiles.",
            ["confirm_disable"]="Désactiver cette protection ?",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="Sécurité : ", ["power_plan_filter"]="Plan d’alimentation",
            ["theme_changed"]="Thème changé en {0}", ["style_changed"]="Style changé en {0}",
            ["powerplan_custom"]="Personnalisé", ["powerplan_restore"]="Restaurer les versions officielles",
            ["update_available"]="Mise à jour {0} disponible", ["new_update"]="Nouvelle mise à jour : {0}", ["up_to_date"]="Vous êtes à jour", ["update_check_failed"]="Impossible de vérifier les mises à jour",
        
    };
}
