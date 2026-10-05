namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_zht = new()
    {

            ["arc"]="功能已凍結 (2025)，因公司轉向 Dia AI 瀏覽器，但仍每週收到 Chromium 安全性更新；CVE-2024-45489 中設定錯誤的 Firebase ACL 讓任意 JavaScript 能在其他使用者的特權同步內容中執行 (由 xyz3va 報告；影響使用者為零)；安全團隊已從 1 人擴編至 5 人。",
            ["operagx"]="與 Opera 相同的母公司：中國崑崙科技持有約 72%。著名的 CPU/RAM 限制器多為裝飾；Hindenburg 指控適用於整個集團。",
            ["mullvad"]="無重大醜聞。與 Tor Project 共同開發 (2023)；Mullvad VPN 曾拒絕警方存取要求而聞名。",
            ["thorium"]="一位開發者的非官方 Chromium 版本；針對 AVX2 CPU 最佳化；無可重現版本保證，因此您必須信任維護者。",
            ["floorp"]="日本專案，儘管使用 Firefox 卻封閉原始碼多年；於 2023 年開放程式碼。由社群治理，但規模小。",
            ["waterfox"]="曾售予廣告公司 System1 (2020)；創辦人 Alex Kontos 於 2023 年買回獨立。之後無醜聞。",
            ["ungoogled"]="無醜聞；代價是手動檢查更新，以及因積極移除 Google 相依性而偶爾導致網站損壞。",
            ["dia"]="Arc 的後繼者，已於 2025 年 10 月 8 日在 macOS 正式推出；AI 會讀取頁面內容與聊天歷程記錄以代您行動；The Browser Company 已被 Atlassian 以 6.1 億美元收購。",
            ["avast-secure"]="母公司 Avast 曾透過子公司 Jumpshot 販售瀏覽歷程記錄而被逮 (2020 年關閉；2024 年 FTC 和解 $16.5M)；Avast 防毒軟體會強力推銷此瀏覽器。",
            ["librewolf"]="無重大醜聞。唯一的缺點：社群重建期間，安全性修補可能比 Firefox 發布晚幾天。",
            ["firefox"]="Mozilla 多數收入來自 Google 預設交易；預設開啟遙測；2025 年 ToS 曾暗示廣泛資料授權 (反彈後撤回)。",
            ["opera"]="約 72% 由中國崑崙科技持有 (SEC 文件)。Hindenburg Research 指控其金融科技應用程式收取 365-876% APR 貸款。VPN 經 Deloitte 稽核 (無記錄)。",
            ["whale"]="由韓國網路巨頭 Naver 擁有；受南韓資料法約束；側邊欄服務 (翻譯、購物) 會回傳至 Naver。",
            ["kagi-orion"]="封閉原始碼；Windows 版本年輕且粗糙。Kagi 的付費搜尋模式即其業務 — 隱私是產品，而非監控。",
            ["pale-moon"]="古老的 Goanna 引擎缺少多年 Chromium/Firefox 安全緩解；網站損壞常見；一人維護的專案。",
            ["vivaldi"]="出貨附聯盟書籤並從預設搜尋營利 (Google 聯盟)；即使 Chromium 核心開放，UI 仍為封閉原始碼。2024 年 12 月：為營利在合作搜尋引擎上偷偷啟用廣告歸因指令碼。挪威公司，無側寫。",
            ["tor-browser"]="同時用於規避審查與暗網市集 (Silk Road)；出口節點可看到非 HTTPS 流量；被部分政府與網站封鎖或標記。",
            ["zen"]="年輕的專案，團隊極小；尚無獨立安全稽核。快速推進的版本可能引入迴歸。",
            ["edge"]="即使關閉遙測仍傳送唯一裝置 ID；積極的 Bing 側邊欄廣告、贊助建議與持續的切換回來提示。",
            ["falkon"]="QtWebEngine (Chromium 核心) 安全性修補落後上游；KDE 團隊小；Windows 版本不如 Linux 版本久經考驗。",
            ["epic-browser"]="儘管宣稱隱私卻為封閉原始碼：追蹤器封鎖清單與資料處理無法獨立稽核。",
            ["yandex"]="俄羅斯管轄：資料法允許國家存取 (SORM)；Turbo 模式經 Yandex 伺服器代理頁面；Alice 助理在俄羅斯處理語音。",
            ["chrome"]="反壟斷案：DOJ 贏得救濟 (2025 年 9 月) — Google 必須與競爭者分享搜尋資料，不得有獨家預設交易。無痕追蹤訴訟以刪除數十億筆記錄落幕。Privacy Sandbox 大部分廣告量測 API 已於 2025 年 10 月退役，Google 也保留第三方 Cookie，因此跨站廣告追蹤並非僅限於 Google。",
            ["brave"]="2020 年：自動在加密貨幣交易所 URL 加上聯盟碼 (CEO 已道歉)。創辦人 Brendan Eich 的 Prop-8 捐款過去不時被提起。整體隱私記錄良好。",
            ["comet"]="Perplexity 的 AI 瀏覽器：頁面內容會傳送至 AI 模型；Brave 揭露的間接提示注入 (2025 年 8 月 20 日) 與 LayerX 揭露的 CometJacking (2025 年 10 月 4 日)。",
            ["duckduckgo"]="2022 年：因 Bing 聯播交易，其瀏覽器放行 Microsoft 追蹤器 (研究員 Zach Edwards 揭露)；已於 2022 年 8 月修補。",
            ["chromium"]="Windows 版本無自動更新器：安全性修正取決於編譯二進位的人 (Hibbiki 等)；部分 Google API (同步) 已移除。",
            ["cachy-browser"]="CachyOS (Arch) 社群的小眾版本；需要 AVX2；審查面小，檢視程式碼的眼睛比主流瀏覽器少。",
        
    };
    private static readonly Dictionary<string, string> TooltipData_zht = new()
    {

            ["arc"]="透過 The Browser Company 伺服器以帳戶同步；AI 功能會將頁面內容傳送給服務供應商 OpenAI 與 Anthropic，各功能選擇加入。",
            ["operagx"]="與 Opera 相同：瀏覽資料存於 Opera 伺服器；免費 VPN 經 Opera 基礎設施。",
            ["mullvad"]="無：無遙測、無識別碼，預設開啟抗指紋追蹤。",
            ["thorium"]="與 Chromium 相同，減去數個 Google 服務與背景要求。",
            ["floorp"]="預設停用遙測；少數功能會連繫日本專案伺服器。",
            ["waterfox"]="已移除遙測；僅透過合作搜尋引擎營利。",
            ["ungoogled"]="設計上無 Google 連線；無遙測；網頁搜尋取決於您選擇的引擎。",
            ["dia"]="頁面內容與對話會傳送給 The Browser Company 用於其 AI 功能的服務供應商；需要帳戶。",
            ["avast-secure"]="Avast 遙測與促銷優惠；鑑於母公司的記錄，除非證明無虞，否則假設會側寫。",
            ["librewolf"]="預設無：遙測、Pocket、Google 服務與資料收集均在建置時移除。",
            ["firefox"]="遙測、當機報告與基於位置的建議；隱私保留廣告量測 (PPA) 實驗。",
            ["opera"]="瀏覽資料在 Opera 伺服器上處理；免費 VPN 經 Opera 基礎設施路由流量。",
            ["whale"]="Naver 帳戶同步、使用量遙測至 Naver 伺服器；個人化與 Naver 服務連結。",
            ["kagi-orion"]="宣稱零遙測；無廣告側寫；在 Apple 上透過 iCloud 同步，在 Windows 上為本機。",
            ["pale-moon"]="遙測低，但過時的引擎本身才是更大的風險。",
            ["vivaldi"]="無側寫；端對端加密同步；僅在您選擇加入時才有使用量統計。",
            ["tor-browser"]="流量經 3 個加密志願中繼站跳轉；無遙測；登入個人帳戶即自行破壞匿名。",
            ["zen"]="以 Firefox 為基礎並關閉遙測；更新經 Mozilla 基礎設施。",
            ["edge"]="診斷資料、開啟同步時的瀏覽歷程記錄、用於個人化廣告的廣告 ID。",
            ["falkon"]="遙測極少；僅在使用相關服務時才有 KDE 桌面整合。",
            ["epic-browser"]="宣稱無遙測並積極封鎖追蹤器；因封閉程式碼而無法驗證。",
            ["yandex"]="大量遙測、搜尋、位置與語音資料至 Yandex (俄羅斯)；個人化廣告。",
            ["chrome"]="將歷程記錄、搜尋、位置與語音同步至您的 Google 帳戶；預設個人化廣告。",
            ["brave"]="設計上最少：P3A 隱私保留統計 (可停用)，無搜尋或設定檔追蹤。",
            ["comet"]="瀏覽內容由 Perplexity AI 處理；需要帳戶；搜尋歷程記錄與您的 Perplexity 設定檔連結。",
            ["duckduckgo"]="無廣告側寫；搜尋保留匿名記錄；瀏覽器同步已加密。",
            ["chromium"]="無 Google 同步與服務的 Chrome 引擎；網頁搜尋取決於您選擇的引擎。",
            ["cachy-browser"]="以 Chromium 為基礎，記錄的修補最少；遙測遵循上游 Chromium 預設值減去 Google 服務。",
        
    };
}
