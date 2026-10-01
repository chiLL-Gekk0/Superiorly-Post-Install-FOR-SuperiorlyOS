namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_ko = new()
    {
 ["home"]="홈", ["browsers"]="브라우저", ["tools"]="도구", ["tweaking"]="최적화", ["troubleshooting"]="문제 해결" 
    };
    private static readonly Dictionary<string, string> SectionDescs_ko = new()
    {
 ["home"]="도구 상자에 오신 것을 환영합니다.", ["browsers"]="브라우저 관련 유틸리티 및 수정 사항입니다.", ["tools"]="휴대용 유틸리티를 다운로드하고 실행합니다.", ["tweaking"]="드라이버, GPU 및 시스템 조정입니다.", ["troubleshooting"]="빠른 전환 및 OS 수정 사항입니다." 
    };
    private static readonly Dictionary<string, string> TabTitles_ko = new()
    {
 ["mainstream"]="일반", ["privacy"]="개인정보 보호", ["forks"]="포크 및 커스텀", ["software"]="소프트웨어", ["store-downloader"]="Microsoft Store 다운로더", ["utilities"]="유틸리티", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="레지스트리 조정", ["win32"]="Win32PrioritySeparation", ["powerplans"]="전원 계획", ["connectivity"]="연결", ["devices"]="장치", ["security"]="보안", ["gaming"]="게임", ["ai"]="인공지능", ["debloat"]="Debloat", ["system"]="시스템" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Notifications_ko = new()
    {
 ["opened"]="열림 - 실행되었습니다.", ["installed"]="성공적으로 설치되었습니다.", ["failed"]="설치하지 못했습니다.", ["open_failed"]="열지 못했습니다.", ["enabled"]="사용으로 설정되었습니다.", ["disabled"]="사용 안 함으로 설정되었습니다.", ["apply_failed"]="적용하지 못했습니다.", ["applied"]="적용되었습니다." , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_ko = new()
    {

            ["settings"]="설정", ["language"]="언어", ["theme"]="테마", ["dark"]="다크", ["light"]="라이트", ["auto"]="자동", ["default_theme"]="기본 테마",
            ["style"]="스타일", ["win10_style"]="Windows 10 스타일", ["win11_style"]="Windows 11 스타일", ["close"]="닫기",
            ["search_placeholder"]="이름, URL 또는 ID로 검색합니다.", ["store_no_results"]="결과가 없습니다. 다른 검색을 시도하십시오.", ["search"]="검색", ["install"]="설치",
            ["run"]="실행", ["download"]="다운로드", ["open"]="열기", ["apply"]="적용",
            ["check_updates"]="업데이트 확인", ["update"]="Update", ["disclaimer"]="수정 사항에 대한 책임은 사용자에게 있습니다.",
            ["quantum_title"]="Quantum 맵", ["quantum_subtitle"]="유효한 모든 Win32PrioritySeparation 값입니다. 행을 클릭하여 적용하십시오.",
            ["open_quantum"]="Quantum 맵 열기", ["current_win32"]="현재 Win32PrioritySeparation",
            ["load_list"]="목록 불러오기", ["unload_list"]="목록 닫기", ["activate"]="활성화", ["import"]="가져오기", ["export"]="내보내기",
            ["select_all"]="모두 선택", ["unselect_all"]="선택 해제", ["uninstall"]="제거", ["delete"]="삭제",
            ["restore_default"]="기본값으로 복원", ["yes"]="예", ["no"]="아니요",
            ["searching_for"]="'{0}' 검색 중...", ["downloading"]="{0} 다운로드 중...", ["starting"]="{0} 시작 중...",
            ["applying"]="{0} 적용 중...", ["installing"]="{0} 설치 중...",             ["loading"]="{0} 불러오는 중...",
            ["reading_plans"]="전원 계획을 읽는 중...", ["populating_list"]="목록 생성 중...",
            ["apps_found"]="{0}개의 앱을 찾았습니다.", ["nothing_found"]="찾을 수 없습니다.", ["loaded_items"]="{0}개 항목을 불러왔습니다.",
            ["list_unloaded"]="목록을 닫았습니다.",
            ["exported"]="{0} 내보냈습니다.",
            ["installed_n"]="{0}개 앱을 설치했습니다.", ["install_failed"]="설치하지 못했습니다.",
            ["failed_admin"]="실패 - 관리자 권한으로 실행하거나 다시 시작하십시오.", ["failed"]="실패했습니다.",
            ["win32_set"]="Win32PrioritySeparation이(가) {0}(으)로 설정되었습니다.",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_ko = new()
    {
 ["run"]="실행", ["download"]="다운로드", ["apply"]="적용", ["enable"]="사용", ["disable"]="사용 안 함", ["search"]="검색", ["install"]="설치", ["load list"]="목록 불러오기", ["uninstall"]="제거", ["activate"]="활성화", ["delete"]="삭제", ["import .pow"]=".pow 가져오기", ["default"]="기본값", ["custom"]="사용자 지정", ["minimum"]="최소", ["disable mmcss"]="MMCSS 사용 안 함", ["bypass"]="우회", ["repeater"]="리피터", ["realtime"]="실시간", ["high"]="높음", ["abovenormal"]="보통보다 높음", ["normal"]="보통", ["belownormal"]="보통보다 낮음", ["enhanced"]="향상됨", ["legacy"]="레거시", ["disabled"]="사용 안 함", ["enabled"]="사용", ["alwayson"]="항상 켜기", ["alwaysoff"]="항상 끄기", ["optin"]="선택적 참가", ["optout"]="선택적 제외", ["open cru"]="CRU 열기", ["coming soon"]="곧 제공 예정", ["safe fivem/minecraft services"]="안전한 FiveM/Minecraft 서비스", ["kernelos default"]="Superiorly 기본값" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> TabDescs_ko = new()
    {
 ["mainstream"]="일상적인 브라우저입니다.", ["privacy"]="개인정보 보호 및 익명성을 위한 브라우저입니다.", ["forks"]="Chromium 및 Firefox 기반 커뮤니티 빌드입니다.", ["utilities"]="시스템 및 하드웨어 진단 도구입니다.", ["amd"]="드라이버, 클록, 전압 및 레지스트리용 AMD GPU 도구입니다.", ["nvidia"]="클린 설치, 프로필 및 P-States용 NVIDIA 도구입니다.", ["connectivity"]="Wi-Fi, Bluetooth 및 핫스팟 홉 제한 설정입니다.", ["devices"]="프린터, 작업 관리자 및 텍스트 입력 수정 사항입니다.", ["security"]="코어 격리, 방화벽, UAC, 드라이버 차단 목록 및 메모리 보호입니다.", ["gaming"]="Xbox 서비스 및 Opera GX입니다.", ["ai"]="Chromium, WebKit 및 AI 우선 브라우징입니다.", ["debloat"]="Browser privacy policies and vendor telemetry switches: Chrome, Edge, Firefox and Office.", ["system"]="Windows Update 드라이버, 시작 메뉴 및 Intel 패널 수정 사항입니다." , ["telemetry"]="텔레메리, 제안, 광고 및 공급업체 데이터 수집 스위치."
    };
    private static readonly Dictionary<string, string> SectionTabDescs_ko = new()
    {
 ["browsers|gaming"]="CPU, RAM 및 네트워크 제한기가 내장된 Opera GX입니다.", ["troubleshooting|gaming"]="Xbox 서비스 및 안전한 FiveM/Minecraft 서비스입니다." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_ko = new()
    {
 ["mainstream"]="일상 브라우저", ["privacy"]="익명 브라우징", ["forks"]="독립 포크", ["utilities"]="시스템 유틸리티", ["amd"]="Radeon 도구", ["nvidia"]="GeForce 도구", ["connectivity"]="무선 설정", ["devices"]="장치 수정", ["security"]="시스템 보호", ["gaming"]="게임 서비스", ["ai"]="AI 브라우저", ["debloat"]="브라우저 경량화", ["system"]="Windows 수정" , ["telemetry"]="Telemetry Fixes"
    };
    private static readonly Dictionary<string, string> SectionTabTitles_ko = new()
    {
 ["browsers|gaming"]="게이밍 브라우저", ["troubleshooting|gaming"]="게임 서비스" 
    };
    private static readonly Dictionary<string, string> UiExtra_ko = new()
    {
["state_on"]="켬", ["state_off"]="끔", 
            ["confirm_delete"]="삭제 확인",
            ["confirm_enable"]="이 변경 사항을 적용할까요?",
            ["delete_plans"]="{0}개 전원 계획을 삭제하시겠습니까?",
            ["cant_delete_active"]="활성 전원 계획은 삭제할 수 없습니다. 먼저 다른 계획으로 전환하십시오.",
            ["import_plan"]="전원 계획 가져오기", ["export_plan"]="전원 계획 내보내기",
            ["ratio"]="비율", ["long"]="긴", ["short"]="짧은", ["fixed"]="고정", ["variable"]="가변", ["boost"]="부스트", ["current"]="현재",
            ["needs_admin"]="이 작업에는 관리자 권한이 필요합니다.",
            ["restart_driver"]="디스플레이 드라이버 다시 시작", ["reset_all"]="모두 초기화", ["download_cru"]="CRU 다운로드",
            ["modify_quantum"]="Quantum 수정", ["quantum_length"]="Quantum 길이", ["quantum_interval"]="Quantum 간격",
            ["fix"]="수정", ["preview_hex"]="Hex 미리 보기", ["preview_bits"]="비트 미리 보기",
            ["minimize"]="최소화", ["maximize"]="최대화", ["toggle_theme"]="밝은 테마와 어두운 테마 전환",
            ["follow_theme"]="Windows 테마 따르기", ["square"]="직선 모서리", ["rounded"]="둥근 모서리",
            ["join"]="참여", ["follow"]="팔로우", ["visit"]="방문", ["copy_link"]="링크 복사", ["copied"]="복사되었습니다.",
            ["no_profiles_found"]="프로필을 찾을 수 없습니다. Nvidia Profiles 폴더에 .nip 파일을 넣으세요.",
            ["confirm_disable"]="이 보호 기능을 비활성화하시겠습니까?",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="보안: ", ["power_plan_filter"]="전원 계획",
            ["theme_changed"]="테마가 {0}(으)로 변경되었습니다.", ["style_changed"]="스타일이 {0}(으)로 변경되었습니다.",
            ["powerplan_custom"]="사용자 지정", ["powerplan_restore"]="공식 복원",
            ["update_available"]="업데이트 {0} 사용 가능", ["new_update"]="새 업데이트: {0}", ["up_to_date"]="최신 상태입니다.", ["update_check_failed"]="업데이트를 확인할 수 없습니다.",
        
    };
}
