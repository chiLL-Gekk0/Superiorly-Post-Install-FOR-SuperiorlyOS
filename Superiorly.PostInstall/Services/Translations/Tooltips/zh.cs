namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_zh = new()
    {

            ["arc"]="开发已冻结（2025 年），公司转向 Dia AI 浏览器；过去的 CVE 曾允许攻击者通过用户 ID 劫持会话；安全团队从 1 人增至 5 人。",
            ["operagx"]="与 Opera 同属同一母公司：中国昆仑科技持有约 72% 股份。著名的 CPU/RAM 限制器多为装饰性功能；Hindenburg 的指控适用于整个集团。",
            ["mullvad"]="无重大丑闻。与 Tor Project 联合开发（2023 年）；Mullvad VPN 曾拒绝警方的数据访问要求。",
            ["thorium"]="由一名开发者维护的非官方 Chromium 构建；针对 AVX2 CPU 优化；无可重复构建保证，因此需要信任维护者。",
            ["floorp"]="日本项目，尽管基于 Firefox，多年闭源；于 2023 年开源。社区治理，但规模较小。",
            ["waterfox"]="曾出售给广告公司 System1（2020 年）；创始人 Alex Kontos 于 2023 年回购并恢复独立。此后无丑闻。",
            ["ungoogled"]="无丑闻；代价是需手动检查更新，并因激进移除 Google 依赖而偶发网站兼容问题。",
            ["dia"]="Arc 的继任者，邀请制测试版；AI 会读取页面内容和聊天记录以代您执行操作；尚无独立安全审计。",
            ["avast-secure"]="母公司 Avast 曾通过子公司 Jumpshot 出售浏览记录（2020 年关闭；2024 年与 FTC 达成 1650 万美元和解）；该浏览器由 Avast 杀毒软件大力推广。",
            ["librewolf"]="无重大丑闻。唯一不足：社区重新构建需要时间，安全补丁可能比 Firefox 正式版晚几天。",
            ["firefox"]="Mozilla 大部分收入来自 Google 默认搜索引擎协议；默认启用遥测；2025 年服务条款曾短暂暗示广泛的数据授权，遭反对后撤回。",
            ["opera"]="由中国昆仑科技持有约 72% 股份（SEC 文件）。Hindenburg Research 指控其金融应用收取 365-876% 年利率的贷款。VPN 经 Deloitte 审计，无日志。",
            ["whale"]="归属韩国互联网巨头 Naver；受韩国数据法律约束；侧边栏服务如翻译和购物会回连 Naver。",
            ["kagi-orion"]="闭源；Windows 版本尚新且不稳定。Kagi 的付费搜索模式即其商业模式：隐私是产品，而非监控。",
            ["pale-moon"]="陈旧的 Goanna 引擎缺失多年来 Chromium/Firefox 的安全缓解措施；网站兼容问题常见；由单一维护者维护。",
            ["vivaldi"]="预装推广书签并通过默认搜索盈利；尽管 Chromium 内核开源，界面为闭源。2024 年 12 月曾为获取收入在合作搜索引擎上秘密启用广告归因脚本。挪威公司，无用户画像。",
            ["tor-browser"]="既用于规避审查，也用于暗网市场；出口节点可见非 HTTPS 流量；被部分政府和网站封锁或标记。",
            ["zen"]="年轻项目，团队很小；尚无独立安全审计。快速迭代可能引入回归问题。",
            ["edge"]="即使关闭遥测仍会发送唯一设备 ID；Bing 侧边栏广告、赞助建议和持续的切回提示较为激进。",
            ["falkon"]="QtWebEngine（Chromium 内核）安全补丁滞后于上游；KDE 团队较小；Windows 构建不如 Linux 构建成熟。",
            ["epic-browser"]="尽管宣称保护隐私但为闭源：追踪器黑名单和数据处理无法独立审计。",
            ["yandex"]="俄罗斯司法管辖：数据法律允许国家访问；Turbo 模式经 Yandex 服务器代理页面；Alice 助手在俄罗斯处理语音。",
            ["chrome"]="反垄断案：司法部胜诉并获得救济（2025 年 9 月），Google 须与竞争者共享搜索数据，不得签订独家默认协议。隐身模式追踪诉讼以删除数十亿条记录告终。Privacy Sandbox 将广告画像保留在内部。",
            ["brave"]="2020 年曾自动为加密交易所网址添加联盟代码，CEO 已道歉。创始人 Brendan Eich 的过往捐款时常被提及。除此之外隐私记录良好。",
            ["brave-debloat"]="显示为由组织管理。需 Brave 1.82+（Playlist 需 1.84+）。",
            ["edge-debloat"]="显示为由组织管理。",
            ["comet"]="Perplexity 的 AI 浏览器：页面内容会发送至 AI 模型；Cloudflare 曾指控其激进抓取（2025 年）；智能体浏览带来新的隐私问题。",
            ["duckduckgo"]="2022 年因与 Bing 的分发协议，其浏览器曾放行 Microsoft 追踪器，由研究员 Zach Edwards 披露；已于 2022 年 8 月修复。",
            ["chromium"]="Windows 构建无自动更新器：安全修复取决于编译二进制者；部分 Google API 如同步已被移除。",
            ["cachy-browser"]="由 CachyOS（Arch）社区维护的小众构建；需要 AVX2；审查面小，代码审查者远少于主流浏览器。",
        
    };
    private static readonly Dictionary<string, string> TooltipData_zh = new()
    {

            ["arc"]="通过 The Browser Company 服务器进行基于帐户的同步；AI 功能会将页面内容发送到其模型。",
            ["operagx"]="与 Opera 相同：浏览数据位于 Opera 服务器；通过 Opera 基础设施提供免费 VPN。",
            ["mullvad"]="无：无遥测、无标识符，默认开启抗指纹追踪。",
            ["thorium"]="与 Chromium 相同，但去除了多项 Google 服务和后台请求。",
            ["floorp"]="默认禁用遥测；少数功能会连接日本项目服务器。",
            ["waterfox"]="已移除遥测；仅通过合作搜索引擎盈利。",
            ["ungoogled"]="设计上无 Google 连接；无遥测；网页搜索取决于您选择的引擎。",
            ["dia"]="页面内容和对话会发送到 The Browser Company 的 AI 模型；需要帐户。",
            ["avast-secure"]="Avast 遥测和推广优惠；鉴于母公司的记录，除非证明否则假定存在用户画像。",
            ["librewolf"]="默认无：遥测、Pocket、Google 服务和数据收集均在构建时移除。",
            ["firefox"]="遥测、崩溃报告和基于位置的建议；隐私保护广告测量 (PPA) 实验。",
            ["opera"]="浏览数据在 Opera 服务器上处理；免费 VPN 经 Opera 基础设施传输流量。",
            ["whale"]="Naver 帐户同步，使用情况遥测发送到 Naver 服务器；个性化与 Naver 服务绑定。",
            ["kagi-orion"]="声称零遥测；无广告画像；Apple 端通过 iCloud 同步，Windows 端为本地。",
            ["pale-moon"]="遥测少，但过时的引擎本身才是更大风险。",
            ["vivaldi"]="无用户画像；端到端加密同步；仅在您选择加入时统计使用情况。",
            ["tor-browser"]="流量经 3 个加密志愿者中继跳转；无遥测；登录个人帐户会破坏您自己的匿名性。",
            ["zen"]="基于 Firefox 且关闭遥测；更新经 Mozilla 基础设施分发。",
            ["edge"]="诊断数据、开启同步时的浏览历史、用于个性化广告的广告 ID。",
            ["falkon"]="遥测极少；仅在使用相关服务时与 KDE 桌面集成。",
            ["epic-browser"]="声称无遥测并积极拦截追踪器；因闭源而无法验证。",
            ["yandex"]="向 Yandex（俄罗斯）发送大量遥测、搜索、位置和语音数据；个性化广告。",
            ["chrome"]="将历史、搜索、位置和语音同步到您的 Google 帐户；默认开启广告个性化。",
            ["brave"]="设计上最少：P3A 隐私保护统计（可关闭），无搜索或画像追踪。",
            ["brave-debloat"]="12条策略：禁用 Rewards、Wallet、VPN、Leo、Tor、News、Talk、Speedreader、Wayback、Playlist、P3A、统计ping。",
            ["edge-debloat"]="14条策略：禁用购物、侧边栏、Rewards、新闻、小组件、遥测。",
            ["comet"]="浏览上下文由 Perplexity AI 处理；需要帐户；搜索历史与您的 Perplexity 资料绑定。",
            ["duckduckgo"]="无广告画像；搜索保留匿名日志；浏览器同步已加密。",
            ["chromium"]="无 Google 同步和服务的 Chrome 引擎；网页搜索取决于您选择的引擎。",
            ["cachy-browser"]="基于 Chromium，文档化补丁最少；遥测遵循上游 Chromium 默认并去除 Google 服务。",
        
    };
}
