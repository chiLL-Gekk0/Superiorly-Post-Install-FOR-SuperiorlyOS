namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_ko = new()
    {

            ["arc"]="Dia AI 브라우저로 전환하면서 기능 개발은 동결되었지만(2025년) Chromium 보안 업데이트는 매주 제공됩니다. CVE-2024-45489에서는 Firebase ACL 설정 오류로 다른 사용자의 권한 있는 동기화 컨텍스트에서 임의 JavaScript가 실행되었습니다(xyz3va 보고, 영향 사용자 0명). 보안 팀은 1명에서 5명으로 늘었습니다.",
            ["operagx"]="Opera와 같은 모회사로 중국 Kunlun Tech가 약 72%를 보유합니다. 유명한 CPU/RAM 제한 기능은 대부분 장식용이며 Hindenburg 의혹은 그룹 전체에 적용됩니다.",
            ["mullvad"]="큰 논란이 없습니다. Tor Project와 공동 개발(2023년)했으며 Mullvad VPN은 경찰의 접근 요청을 거부한 것으로 유명합니다.",
            ["thorium"]="1인 개발자의 비공식 Chromium 빌드이며 AVX2 CPU에 최적화되어 있습니다. 재현 가능 빌드 보장이 없어 유지 관리자를 신뢰해야 합니다.",
            ["floorp"]="Firefox 기반인데도 수년간 closed-source였던 일본 프로젝트이며 2023년에 코드를 공개했습니다. 커뮤니티 주도로 운영되지만 규모가 작습니다.",
            ["waterfox"]="광고 회사 System1에 매각(2020년)된 뒤 설립자 Alex Kontos가 독립을 되찾았습니다(2023년). 이후 논란이 없습니다.",
            ["ungoogled"]="논란이 없으며 대가로 업데이트를 수동으로 확인해야 하고 Google 의존성 제거로 사이트가 깨질 수 있습니다.",
            ["dia"]="Arc의 후속작으로 2025년 10월 8일 macOS에서 정식 출시되었습니다. AI가 페이지 내용과 대화 기록을 읽고 대신 행동합니다. The Browser Company는 Atlassian이 6억 1천 달러에 인수했습니다.",
            ["avast-secure"]="모회사 Avast가 자회사 Jumpshot을 통해 검색 기록을 판매했습니다(2020년 폐쇄, 2024년 FTC와 $16.5M 합의). Avast antivirus가 적극적으로 권유합니다.",
            ["librewolf"]="큰 논란이 없습니다. 유일한 단점은 커뮤니티 재빌드 기간에 Firefox 릴리스보다 보안 패치가 며칠 늦을 수 있다는 점입니다.",
            ["firefox"]="Mozilla 수익의 대부분은 Google 기본 계약에서 나오며 텔레메트리는 기본적으로 켜져 있습니다. 2025년 약관은 광범위한 데이터 이용을 시사했다가 반발로 철회되었습니다.",
            ["opera"]="중국 Kunlun Tech가 약 72%를 보유합니다(SEC filings). Hindenburg Research는 fintech 앱이 365-876% APR 대출을 제공했다고 주장했습니다. VPN은 Deloitte 감사를 받았습니다(no-log).",
            ["whale"]="한국 인터넷 대기업 Naver 소유이며 한국 데이터법의 적용을 받습니다. 사이드바 서비스(번역, 쇼핑)는 Naver에 연결됩니다.",
            ["kagi-orion"]="Closed source이며 Windows 버전은 아직 초기 단계로 불안정합니다. Kagi의 유료 검색 모델이 사업이며 감시가 아닌 상품으로서의 개인정보 보호입니다.",
            ["pale-moon"]="오래된 Goanna 엔진은 수년간의 Chromium/Firefox 보안 완화를 갖추지 못해 사이트 깨짐이 잦으며 1인 유지 관리자 프로젝트입니다.",
            ["vivaldi"]="제휴 북마크를 포함하고 기본 검색(Google)으로 수익을 얻으며 Chromium 코어는 공개되었지만 UI는 closed-source입니다. 2024년 12월에는 수익을 위해 제휴 검색 엔진에 광고 attribution 스크립트를 몰래 활성화했습니다. 노르웨이 회사이며 프로파일링은 없습니다.",
            ["tor-browser"]="검열 우회와 darknet 시장 모두에 사용되며 exit node는 비-HTTPS 트래픽을 볼 수 있고 일부 정부와 사이트에서 차단하거나 표시합니다.",
            ["zen"]="소규모 팀의 젊은 프로젝트이며 독립 보안 감사는 아직 없습니다. 빠른 릴리스로 회귀 오류가 생길 수 있습니다.",
            ["edge"]="텔레메트리를 꺼도 고유 장치 ID를 전송하며 적극적인 Bing 사이드바 광고, 스폰서 제안, 지속적인 복귀 유도가 있습니다.",
            ["falkon"]="QtWebEngine(Chromium 코어) 패치가 upstream보다 늦으며 소규모 KDE 팀이 맡고 있고 Windows 빌드는 Linux 버전보다 검증이 적습니다.",
            ["epic-browser"]="개인정보 보호 주장에도 불구하고 closed source이며 tracker 차단 목록과 데이터 처리를 독립적으로 감사할 수 없습니다.",
            ["yandex"]="러시아 관할로 법에 따라 국가 접근이 가능하며(SORM) Turbo 모드는 Yandex 서버를 통해 페이지를 프록시하고 Alice assistant는 러시아에서 음성을 처리합니다.",
            ["chrome"]="반독점 소송에서 DOJ가 구제조치를 받았습니다(2025년 9월). Google은 검색 데이터를 공유하고 독점 기본 계약을 금지해야 합니다. 시크릿 추적 소송은 수십억 건 삭제로 끝났습니다. Privacy Sandbox 광고 측정 API 대부분은 2025년 10월에 폐기됐고 Google은 서드파티 쿠키를 유지해 교 사이트 광고 추적은 Google 안에 국한되지 않습니다.",
            ["brave"]="2020년에 암호화폐 거래소 URL에 제휴 코드를 자동 추가했습니다(CEO가 사과). 설립자 Brendan Eich의 과거 기부 문제가 주기적으로 다시 제기됩니다. 그 외에는 탄탄한 기록을 유지합니다.",
            ["comet"]="Perplexity의 AI 브라우저로 페이지 내용이 AI 모델로 전송됩니다. Brave가 공개한 간접 프롬프트 인젝션(2025년 8월 20일)과 LayerX가 공개한 CometJacking(2025년 10월 4일).",
            ["duckduckgo"]="2022년에 Bing 유통 계약 때문에 Microsoft tracker를 허용했으며 연구자 Zach Edwards가 공개했고 2022년 8월에 수정되었습니다.",
            ["chromium"]="Windows 빌드에는 자동 업데이트가 없으며 수정은 바이너리를 컴파일한 제공자에 따라 다르고 일부 Google API(sync)가 제거되었습니다.",
            ["cachy-browser"]="CachyOS(Arch) 커뮤니티의 niche 빌드이며 AVX2가 필요하고 검토 범위가 좁아 주류 브라우저보다 검토자가 적습니다.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_ko = new()
    {

            ["arc"]="The Browser Company 서버를 통한 계정 기반 동기화를 사용하며 AI 기능은 페이지 내용을 서비스 제공업체 OpenAI와 Anthropic에 전송하고 기능별로 동의해야 합니다.",
            ["operagx"]="Opera와 동일하며 검색 데이터는 Opera 서버에 있고 무료 VPN은 Opera 인프라를 이용합니다.",
            ["mullvad"]="없음: 텔레메트리도 식별자도 없으며 anti-fingerprinting이 기본적으로 켜져 있습니다.",
            ["thorium"]="여러 Google 서비스와 백그라운드 요청을 제외하면 Chromium과 동일합니다.",
            ["floorp"]="텔레메트리는 기본적으로 꺼져 있으며 일부 기능이 일본 프로젝트 서버에 연결됩니다.",
            ["waterfox"]="텔레메트리가 제거되었으며 제휴 검색 엔진으로만 수익을 얻습니다.",
            ["ungoogled"]="설계상 Google 연결이 없으며 텔레메트리가 없고 웹 검색은 선택한 엔진에 따라 다릅니다.",
            ["dia"]="페이지 내용과 대화가 The Browser Company가 AI 기능에 사용하는 AI 서비스 제공업체로 전송되며 계정이 필요합니다.",
            ["avast-secure"]="Avast 텔레메트리와 판촉 혜택이 있으며 모회사 전력을 고려하면 반증이 없는 한 프로파일링을 가정합니다.",
            ["librewolf"]="기본적으로 없음: 텔레메트리, Pocket, Google 서비스와 데이터 수집이 빌드 시점에 제거되었습니다.",
            ["firefox"]="텔레메트리, 충돌 보고와 위치 기반 제안을 포함하며 개인정보 보호 광고 측정(PPA) 실험이 있습니다.",
            ["opera"]="검색 데이터는 Opera 서버에서 처리되며 무료 VPN은 Opera 인프라를 경유합니다.",
            ["whale"]="Naver 계정 동기화와 Naver 서버로의 사용량 텔레메트리가 있으며 개인화는 Naver 서비스와 연결됩니다.",
            ["kagi-orion"]="Zero 텔레메트리를 주장하며 광고 프로파일이 없고 Apple에서는 iCloud로, Windows에서는 로컬로 동기화합니다.",
            ["pale-moon"]="텔레메트리는 적지만 구식 엔진 자체가 더 큰 위험입니다.",
            ["vivaldi"]="프로파일링이 없으며 종단간 암호화 동기화를 사용하고 사용 통계는 opt-in한 경우에만 수집합니다.",
            ["tor-browser"]="트래픽은 3개의 암호화된 자원봉사 relay를 거치며 텔레메트리가 없고 개인 계정에 로그인하면 익명성이 깨집니다.",
            ["zen"]="텔레메트리를 끈 Firefox 기반이며 업데이트는 Mozilla 인프라를 통해 제공됩니다.",
            ["edge"]="진단 데이터, 동기화 사용 시 검색 기록, 개인 맞춤 광고용 광고 ID를 포함합니다.",
            ["falkon"]="텔레메트리는 최소이며 해당 서비스를 사용할 때만 KDE 데스크톱 통합을 사용합니다.",
            ["epic-browser"]="텔레메트리가 없고 tracker를 적극 차단한다고 주장하지만 closed code라 검증할 수 없습니다.",
            ["yandex"]="Yandex(러시아)로 광범위한 텔레메트리, 검색, 위치와 음성 데이터를 전송하며 개인 맞춤 광고가 있습니다.",
            ["chrome"]="기록, 검색, 위치와 음성을 Google 계정으로 동기화하며 광고 개인화가 기본적으로 켜져 있습니다.",
            ["brave"]="설계상 최소이며 P3A 개인정보 보호 통계(비활성화 가능)를 사용하고 검색이나 프로파일 추적이 없습니다.",
            ["comet"]="검색 맥락은 Perplexity AI가 처리하며 계정이 필요하고 검색 기록은 Perplexity 프로필과 연결됩니다.",
            ["duckduckgo"]="광고 프로파일이 없으며 검색은 익명 로그를 유지하고 브라우저 동기화는 암호화됩니다.",
            ["chromium"]="Google 동기화와 서비스가 없는 Chrome 엔진이며 웹 검색은 선택한 엔진에 따라 다릅니다.",
            ["cachy-browser"]="문서화된 패치가 최소인 Chromium 기반이며 텔레메트리는 Google 서비스를 제외한 upstream Chromium 기본값을 따릅니다.",
        
    };
}
