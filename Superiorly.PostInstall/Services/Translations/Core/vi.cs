namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_vi = new()
    {
 ["home"]="Trang chủ", ["browsers"]="Trình duyệt", ["tools"]="Công cụ", ["tweaking"]="Tinh chỉnh", ["troubleshooting"]="Khắc phục sự cố" 
    };
    private static readonly Dictionary<string, string> SectionDescs_vi = new()
    {
 ["home"]="Chào mừng bạn đến với hộp công cụ", ["browsers"]="Tiện ích và bản sửa lỗi liên quan đến trình duyệt", ["tools"]="Tải xuống và chạy các tiện ích portable", ["tweaking"]="Tinh chỉnh trình điều khiển, GPU và hệ thống.", ["troubleshooting"]="Công tắc nhanh và bản sửa lỗi hệ điều hành." 
    };
    private static readonly Dictionary<string, string> TabTitles_vi = new()
    {
 ["mainstream"]="Phổ thông", ["privacy"]="Riêng tư", ["forks"]="Bản phân nhánh & tùy chỉnh", ["software"]="Phần mềm", ["store-downloader"]="Trình tải Microsoft Store", ["utilities"]="Tiện ích", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Sổ đăng ký", ["win32"]="Win32Priority", ["powerplans"]="Gói điện", ["connectivity"]="Kết nối", ["devices"]="Thiết bị", ["security"]="Xep hang rieng tu: ", ["gaming"]="Chơi game", ["ai"]="AI", ["debloat"]="Gỡ bloat", ["system"]="Hệ thống" , ["telemetry"]="Dữ liệu chẩn đoán",
["app-privacy"]="Quyền riêng tư ứng dụng",
    };
    private static readonly Dictionary<string, string> Notifications_vi = new()
    {
 ["opened"]="Đã mở - đã khởi chạy", ["installed"]="Cài đặt thành công", ["failed"]="Cài đặt thất bại", ["open_failed"]="Mở thất bại", ["enabled"]="Đã bật", ["disabled"]="Đã tắt", ["apply_failed"]="Áp dụng thất bại", ["applied"]="Đã áp dụng" , ["telemetry"]="Dữ liệu chẩn đoán"
    };
    private static readonly Dictionary<string, string> Ui_vi = new()
    {

            ["settings"]="Cài đặt", ["language"]="Ngôn ngữ", ["theme"]="Chủ đề", ["dark"]="Tối", ["light"]="Sáng", ["auto"]="Tự động", ["default_theme"]="Chủ đề mặc định",
            ["style"]="Kiểu", ["win10_style"]="Kiểu Windows 10", ["win11_style"]="Kiểu Windows 11", ["close"]="Đóng",
            ["search_placeholder"]="Tìm kiếm theo tên, URL hoặc ID.", ["store_no_results"]="Không tìm thấy kết quả. Hãy thử tìm kiếm khác.", ["search"]="Tìm kiếm", ["install"]="Cài đặt",
            ["run"]="Chạy", ["download"]="Tải xuống", ["open"]="Mở", ["apply"]="Áp dụng",
            ["check_updates"]="Kiểm tra cập nhật", ["update"]="Cập nhật", ["disclaimer"]="Mọi thay đổi là trách nhiệm của riêng bạn.",
            ["quantum_title"]="Bản đồ Quantum", ["quantum_subtitle"]="Tất cả giá trị Win32PrioritySeparation hợp lệ. Nhấp vào một hàng để áp dụng.",
            ["open_quantum"]="Mở Bản đồ Quantum", ["current_win32"]="Win32PrioritySeparation hiện tại",
            ["load_list"]="Tải danh sách", ["unload_list"]="Gỡ danh sách", ["activate"]="Kích hoạt", ["import"]="Nhập", ["export"]="Xuất",
            ["select_all"]="Chọn tất cả", ["unselect_all"]="Bỏ chọn tất cả", ["uninstall"]="Gỡ cài đặt", ["delete"]="Xóa",
            ["restore_default"]="Khôi phục mặc định", ["yes"]="Có", ["no"]="Không",
            ["searching_for"]="Đang tìm kiếm '{0}'...", ["downloading"]="Đang tải xuống {0}...", ["starting"]="Đang khởi động {0}...",
            ["applying"]="Đang áp dụng {0}...", ["installing"]="Đang cài đặt {0}...",             ["loading"]="Đang tải {0}...",
            ["reading_plans"]="Đang đọc gói điện...", ["populating_list"]="Đang tạo danh sách...",
            ["apps_found"]="Tìm thấy {0} ứng dụng", ["nothing_found"]="Không tìm thấy gì", ["loaded_items"]="Đã tải {0} mục",
            ["list_unloaded"]="Đã gỡ danh sách",
            ["exported"]="Đã xuất {0}",
            ["installed_n"]="Đã cài đặt {0} ứng dụng", ["install_failed"]="Cài đặt thất bại",
            ["failed_admin"]="Thất bại - Hãy chạy với quyền quản trị viên hoặc khởi động lại", ["failed"]="Thất bại",
            ["win32_set"]="Đã đặt Win32PrioritySeparation thành {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_vi = new()
    {
 ["run"]="Chạy", ["download"]="Tải xuống", ["apply"]="Áp dụng", ["enable"]="Bật", ["disable"]="Tắt", ["search"]="Tìm kiếm", ["install"]="Cài đặt", ["load list"]="Tải danh sách", ["uninstall"]="Gỡ cài đặt", ["activate"]="Kích hoạt", ["delete"]="Xóa", ["import .pow"]="Nhập .pow", ["default"]="Mặc định", ["custom"]="Tùy chỉnh", ["full"]="Đầy đủ", ["reduced"]="Thu nhỏ", ["minimum"]="Tối thiểu", ["disable mmcss"]="Tắt MMCSS", ["bypass"]="Bỏ qua", ["repeater"]="Tiếp sóng", ["realtime"]="Thời gian thực", ["high"]="Cao", ["abovenormal"]="Trên trung bình", ["normal"]="Bình thường", ["belownormal"]="Dưới trung bình", ["enhanced"]="Nâng cao", ["legacy"]="Cũ", ["disabled"]="Đã tắt", ["enabled"]="Đã bật", ["alwayson"]="Luôn bật", ["alwaysoff"]="Luôn tắt", ["optin"]="Tham gia", ["optout"]="Không tham gia", ["open cru"]="Mở CRU", ["coming soon"]="Sắp ra mắt", ["safe fivem/minecraft services"]="Dịch vụ an toàn FiveM/Minecraft", ["kernelos default"]="Superiorly mặc định" , ["telemetry"]="Dữ liệu chẩn đoán"
    };
    private static readonly Dictionary<string, string> TabDescs_vi = new()
    {
 ["mainstream"]="Trình duyệt hằng ngày.", ["privacy"]="Trình duyệt được xây dựng cho quyền riêng tư và ẩn danh.", ["forks"]="Bản dựng cộng đồng dựa trên Chromium và Firefox.", ["utilities"]="Công cụ chẩn đoán hệ thống và phần cứng.", ["amd"]="Công cụ AMD GPU cho trình điều khiển, xung nhịp, điện áp và sổ đăng ký.", ["nvidia"]="Công cụ NVIDIA cho cài đặt sạch, hồ sơ và P-State.", ["connectivity"]="Cài đặt giới hạn Wi-Fi, Bluetooth và điểm phát sóng.", ["devices"]="Bản sửa lỗi máy in, Trình quản lý Tác vụ và nhập liệu văn bản.", ["security"]="Cách ly lõi, tường lửa, UAC, danh sách chặn trình điều khiển và bảo vệ bộ nhớ.", ["gaming"]="Dịch vụ Xbox và Opera GX.", ["ai"]="Trình duyệt Chromium, WebKit và ưu tiên AI.", ["debloat"]="Chính sách riêng tư trình duyệt và công tắc đo lường từ xa của nhà cung cấp: Chrome, Edge, Firefox và Office.", ["system"]="Trình điều khiển Windows Update, Menu Bắt đầu và bản sửa lỗi bảng Intel." , ["telemetry"]="Công tắc dữ liệu chẩn đoán, gợi ý, quảng cáo và thu thập dữ liệu của nhà cung cấp.",
["app-privacy"]="Quyền ứng dụng và tùy chọn quyền riêng tư.",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_vi = new()
    {
 ["browsers|gaming"]="Opera GX với giới hạn CPU, RAM và mạng tích hợp.", ["tweaking|gaming"]="Dịch vụ Xbox và dịch vụ an toàn FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_vi = new()
    {
 ["mainstream"]="Trình duyệt hằng ngày", ["privacy"]="Duyệt web ẩn danh", ["forks"]="Bản phân nhánh độc lập", ["utilities"]="Tiện ích hệ thống", ["amd"]="Công cụ Radeon", ["nvidia"]="Công cụ GeForce", ["connectivity"]="Cài đặt không dây", ["devices"]="Sửa lỗi thiết bị", ["security"]="Bảo vệ hệ thống", ["gaming"]="Dịch vụ trò chơi", ["ai"]="Trình duyệt AI", ["debloat"]="Gỡ bloat trình duyệt", ["system"]="Sửa lỗi Windows" , ["telemetry"]="Sửa lỗi dữ liệu chẩn đoán",
["app-privacy"]="Quyền riêng tư ứng dụng",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_vi = new()
    {
 ["browsers|gaming"]="Trình duyệt chơi game"
    };
    private static readonly Dictionary<string, string> UiExtra_vi = new()
    {
["state_on"]="Bật", ["state_off"]="Tắt", 
            ["confirm_delete"]="Xác nhận xóa",
            ["confirm_enable"]="Áp dụng thay đổi này?",
            ["confirm_disable"]="Tắt biện pháp bảo vệ này?",
            ["delete_plans"]="Xóa {0} gói điện?",
            ["cant_delete_active"]="Không thể xóa gói điện đang dùng. Hãy chuyển sang gói khác trước.",
            ["import_plan"]="Nhập gói điện", ["export_plan"]="Xuất gói điện",
            ["ratio"]="tỷ lệ", ["long"]="Dài", ["short"]="Ngắn", ["fixed"]="Cố định", ["variable"]="Thay đổi", ["boost"]="tăng tốc", ["current"]="hiện tại",
            ["needs_admin"]="Hành động này yêu cầu quyền quản trị viên.",
            ["restart_driver"]="Khởi động lại trình điều khiển hiển thị", ["reset_all"]="Đặt lại tất cả", ["download_cru"]="Tải xuống CRU",
            ["modify_quantum"]="Sửa đổi Quantum", ["quantum_length"]="Độ dài Quantum", ["quantum_interval"]="Khoảng Quantum",
            ["fix"]="Sửa lỗi", ["preview_hex"]="Xem trước Hex", ["preview_bits"]="Xem trước bit",
            ["minimize"]="Thu nhỏ", ["maximize"]="Phóng to", ["toggle_theme"]="Chuyển đổi chủ đề sáng / tối",
            ["follow_theme"]="Theo chủ đề Windows", ["square"]="Góc vuông", ["rounded"]="Góc bo tròn",
            ["join"]="THAM GIA", ["follow"]="THEO DÕI", ["visit"]="TRUY CẬP", ["copy_link"]="Sao chép liên kết", ["copied"]="Đã sao chép",
            ["no_profiles_found"]="Không tìm thấy hồ sơ. Hãy đặt tệp .nip vào thư mục NVIDIA Profiles.",
            ["home_discord_desc"]="Cộng đồng Superiorly",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="Bảo mật: ", ["power_plan_filter"]="Gói điện",
            ["theme_changed"]="Đã đổi chủ đề thành {0}", ["style_changed"]="Đã đổi kiểu thành {0}",
            ["powerplan_custom"]="Tùy chỉnh", ["powerplan_restore"]="Khôi phục bản chính thức",
            ["update_available"]="Có bản cập nhật {0}", ["new_update"]="Bản cập nhật mới: {0}", ["up_to_date"]="Bạn đã cập nhật mới nhất", ["update_check_failed"]="Không thể kiểm tra cập nhật",
        
    };
}
