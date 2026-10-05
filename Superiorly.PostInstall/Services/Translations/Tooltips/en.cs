namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_en = new()
    {

            ["arc"]="Feature-frozen (2025) as the company pivots to the Dia AI browser, but still patched with weekly Chromium security releases; CVE-2024-45489 misconfigured Firebase ACLs let arbitrary JavaScript run in another user's privileged sync context (reported by xyz3va; zero users affected); security team grew from 1 to 5.",
            ["operagx"]="Same parent as Opera: China's Kunlun Tech holds ~72%. The famous CPU/RAM limiters are mostly cosmetic; Hindenburg allegations apply to the group.",
            ["mullvad"]="No major scandals. Co-developed with the Tor Project (2023); Mullvad VPN famously refused police access requests.",
            ["thorium"]="Unofficial Chromium builds by one developer; optimized for AVX2 CPUs; no reproducible-builds guarantee, so you trust the maintainer.",
            ["floorp"]="Japanese project that was closed-source for years despite using Firefox; opened its code in 2023. Governance is community-driven but small.",
            ["waterfox"]="Sold to ad company System1 (2020); founder Alex Kontos bought independence back (2023). No scandals since.",
            ["ungoogled"]="No scandals; the trade-off is manual update checking and occasional site breakage from aggressive removal of Google dependencies.",
            ["dia"]="Arc's successor, generally available on macOS since 2025-10-08; the AI reads page content and chat history to act on your behalf; The Browser Company was acquired by Atlassian for $610M.",
            ["avast-secure"]="Parent Avast was caught selling browsing histories via subsidiary Jumpshot (shut down 2020; $16.5M FTC settlement 2024); browser is pushed hard by Avast antivirus.",
            ["librewolf"]="No major scandals. Only gripe: security patches can lag Firefox release days slightly while the community rebuilds.",
            ["firefox"]="Mozilla earns most revenue from the Google default deal; telemetry on by default; 2025 ToS briefly implied a broad data license (rolled back after backlash).",
            ["opera"]="Owned ~72% by China's Kunlun Tech (SEC filings). Hindenburg Research alleged its fintech apps charged 365-876% APR loans. VPN audited by Deloitte (no-log).",
            ["whale"]="Owned by Korean internet giant Naver; subject to South Korean data law; sidebar services (translate, shopping) phone home to Naver.",
            ["kagi-orion"]="Closed source; the Windows port is young and rough. Kagi's paid search model is the business — privacy as a product, not surveillance.",
            ["pale-moon"]="Ancient Goanna engine misses years of Chromium/Firefox security mitigations; site breakage is common; one-maintainer project.",
            ["vivaldi"]="Ships affiliate bookmarks and monetizes default search (Google affiliate); UI is closed-source even though the Chromium core is open. Dec 2024: secretly enabled ad attribution scripts on partner search engines for revenue. Norwegian company, no profiling.",
            ["tor-browser"]="Used for both censorship circumvention and darknet markets (Silk Road); exit nodes can see non-HTTPS traffic; blocked or flagged by some governments and sites.",
            ["zen"]="Young project with a tiny team; no independent security audit yet. Fast-moving releases can introduce regressions.",
            ["edge"]="Sends unique device IDs even with telemetry off; aggressive Bing sidebar ads, sponsored suggestions and persistent switch-back prompts.",
            ["falkon"]="QtWebEngine (Chromium core) security patches lag upstream; small KDE team; Windows builds less battle-tested than the Linux ones.",
            ["epic-browser"]="Closed source despite privacy claims: the tracker blocklist and data handling cannot be independently audited.",
            ["yandex"]="Russian jurisdiction: data laws allow state access (SORM); Turbo mode proxies pages through Yandex servers; Alice assistant processes voice in Russia.",
            ["chrome"]="Antitrust case: DOJ won remedies (Sept 2025) — Google must share search data with rivals, no exclusive default deals. Incognito tracking lawsuit ended with deletion of billions of records. Most Privacy Sandbox ad-measurement APIs were retired in Oct 2025 and Google kept third-party cookies, so cross-site ad tracking is not confined to Google.",
            ["brave"]="2020: auto-added affiliate codes to crypto exchange URLs (CEO apologized). Founder Brendan Eich's Prop-8 donation past resurfaces periodically. Otherwise strong privacy record.",
            ["comet"]="Perplexity's AI browser: page content is sent to AI models; indirect prompt injection disclosed by Brave (2025-08-20) and CometJacking disclosed by LayerX (2025-10-04).",
            ["duckduckgo"]="2022: its browser let Microsoft trackers through due to a Bing syndication deal (researcher Zach Edwards exposed it); patched August 2022.",
            ["chromium"]="No auto-updater on Windows builds: security fixes depend on whoever compiles your binary (Hibbiki, etc.); some Google APIs (sync) removed.",
            ["cachy-browser"]="Niche build by the CachyOS (Arch) community; requires AVX2; tiny review surface, so fewer eyes on the code than mainstream browsers.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_en = new()
    {

            ["arc"]="Account-based sync through The Browser Company servers; AI features send page content to service providers OpenAI and Anthropic, opt-in per feature.",
            ["operagx"]="Same as Opera: browsing data on Opera servers; free VPN via Opera infrastructure.",
            ["mullvad"]="None: no telemetry, no identifiers, anti-fingerprinting on by default.",
            ["thorium"]="Same as Chromium minus several Google services and background requests.",
            ["floorp"]="Telemetry disabled by default; a few features contact Japanese project servers.",
            ["waterfox"]="Telemetry removed; monetization via partner search engines only.",
            ["ungoogled"]="No Google connections by design; no telemetry; web searches depend on your chosen engine.",
            ["dia"]="Page content and conversations are sent to the AI service providers The Browser Company uses for its AI features; account required.",
            ["avast-secure"]="Avast telemetry and promotional offers; given the parent's record, assume profiling unless proven otherwise.",
            ["librewolf"]="None by default: telemetry, Pocket, Google services and data collection removed at build time.",
            ["firefox"]="Telemetry, crash reports and location-based suggestions; privacy-preserving ad measurement (PPA) experiments.",
            ["opera"]="Browsing data processed on Opera servers; free VPN routes traffic through Opera infrastructure.",
            ["whale"]="Naver account sync, usage telemetry to Naver servers; personalization tied to Naver services.",
            ["kagi-orion"]="Zero telemetry claimed; no ad profiles; sync on Apple via iCloud, local on Windows.",
            ["pale-moon"]="Low telemetry, but the outdated engine itself is the bigger risk.",
            ["vivaldi"]="No profiling; end-to-end encrypted sync; usage stats only if you opt in.",
            ["tor-browser"]="Traffic hops through 3 encrypted volunteer relays; no telemetry; log into personal accounts and you break your own anonymity.",
            ["zen"]="Firefox-based with telemetry off; updates flow through Mozilla infrastructure.",
            ["edge"]="Diagnostic data, browsing history when sync is on, advertising ID for personalized ads.",
            ["falkon"]="Minimal telemetry; KDE desktop integration only if you use those services.",
            ["epic-browser"]="Claims no telemetry and blocks trackers aggressively; unverifiable due to closed code.",
            ["yandex"]="Extensive telemetry, search, location and voice data to Yandex (Russia); personalized ads.",
            ["chrome"]="Syncs history, searches, location and voice to your Google account; ad personalization by default.",
            ["brave"]="Minimal by design: P3A privacy-preserving stats (can disable), no search or profile tracking.",
            ["comet"]="Browsing context processed by Perplexity AI; account required; search history tied to your Perplexity profile.",
            ["duckduckgo"]="No ad profiles; search keeps anonymous logs; browser sync is encrypted.",
            ["chromium"]="Chrome engine without Google sync and services; web searches depend on the engine you pick.",
            ["cachy-browser"]="Chromium-based with minimal documented patches; telemetry follows upstream Chromium defaults minus Google services.",
        
    };
}
