namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_vi = new()
    {

            ["arc"]="Phát triển bị đóng băng (2025) khi công ty chuyển sang trình duyệt AI Dia; CVE trước đây cho phép chiếm đoạt phiên qua ID người dùng; đội bảo mật tăng từ 1 lên 5.",
            ["operagx"]="Cùng công ty mẹ với Opera: Kunlun Tech của Trung Quốc nắm ~72%. Bộ giới hạn CPU/RAM nổi tiếng chủ yếu mang tính trang trí; cáo buộc của Hindenburg áp dụng cho cả tập đoàn.",
            ["mullvad"]="Không có bê bối lớn. Đồng phát triển với Tor Project (2023); VPN Mullvad từng từ chối yêu cầu truy cập của cảnh sát.",
            ["thorium"]="Bản dựng Chromium không chính thức của một nhà phát triển; tối ưu cho CPU AVX2; không đảm bảo build tái lập, nên bạn phải tin người bảo trì.",
            ["floorp"]="Dự án Nhật Bản từng đóng mã nguồn nhiều năm dù dùng Firefox; mở mã năm 2023. Quản trị cộng đồng nhưng nhỏ.",
            ["waterfox"]="Bán cho công ty quảng cáo System1 (2020); nhà sáng lập Alex Kontos mua lại độc lập (2023). Không bê bối từ đó.",
            ["ungoogled"]="Không bê bối; đánh đổi là tự kiểm tra cập nhật và thỉnh thoảng vỡ trang do loại bỏ mạnh dependency Google.",
            ["dia"]="Kế nhiệm Arc, beta mời; AI đọc nội dung trang và lịch sử trò chuyện để hành động thay bạn; chưa có kiểm toán bảo mật độc lập.",
            ["avast-secure"]="Công ty mẹ Avast từng bị phát hiện bán lịch sử duyệt web qua công ty con Jumpshot (đóng 2020; thỏa thuận 16,5 triệu USD với FTC năm 2024); trình duyệt bị antivirus Avast đẩy mạnh.",
            ["librewolf"]="Không bê bối lớn. Điểm trừ duy nhất: bản vá bảo mật có thể chậm hơn Firefox vài ngày khi cộng đồng build lại.",
            ["firefox"]="Mozilla kiếm phần lớn doanh thu từ thỏa thuận mặc định với Google; đo lường từ xa bật mặc định; Điều khoản 2025 từng hàm ý giấy phép dữ liệu rộng (đã rút sau phản ứng).",
            ["opera"]="Thuộc ~72% của Kunlun Tech Trung Quốc (hồ sơ SEC). Hindenburg Research cáo buộc ứng dụng fintech cho vay lãi 365-876% APR. VPN được Deloitte kiểm toán (không log).",
            ["whale"]="Thuộc gã khổng lồ Internet Hàn Quốc Naver; chịu luật dữ liệu Hàn Quốc; dịch vụ thanh bên (dịch, mua sắm) gọi về Naver.",
            ["kagi-orion"]="Mã nguồn đóng; bản Windows còn non và thô. Mô hình tìm kiếm trả phí của Kagi là hoạt động kinh doanh — riêng tư là sản phẩm, không phải giám sát.",
            ["pale-moon"]="Engine Goanna cổ thiếu nhiều năm biện pháp giảm thiểu của Chromium/Firefox; vỡ trang thường xuyên; dự án một người bảo trì.",
            ["vivaldi"]="Kèm dấu trang liên kết và kiếm tiền từ tìm kiếm mặc định (liên kết Google); giao diện mã nguồn đóng dù lõi Chromium mở. Tháng 12/2024: lén bật script ghi công quảng cáo trên công cụ tìm kiếm đối tác để kiếm doanh thu. Công ty Na Uy, không lập hồ sơ.",
            ["tor-browser"]="Dùng cho cả vượt kiểm duyệt và chợ darknet (Silk Road); nút thoát có thể thấy lưu lượng không HTTPS; bị một số chính phủ và trang chặn hoặc gắn cờ.",
            ["zen"]="Dự án trẻ với đội ngũ nhỏ; chưa kiểm toán bảo mật độc lập. Phát hành nhanh có thể gây hồi quy.",
            ["edge"]="Gửi ID thiết bị duy nhất ngay cả khi tắt đo lường từ xa; quảng cáo thanh bên Bing hung hăng, gợi ý tài trợ và lời nhắc chuyển lại liên tục.",
            ["falkon"]="Bản vá bảo mật QtWebEngine (lõi Chromium) chậm hơn upstream; đội KDE nhỏ; bản Windows ít thử thách hơn bản Linux.",
            ["epic-browser"]="Mã nguồn đóng dù tuyên bố riêng tư: danh sách chặn và xử lý dữ liệu không thể kiểm toán độc lập.",
            ["yandex"]="Thẩm quyền Nga: luật dữ liệu cho phép nhà nước truy cập (SORM); chế độ Turbo proxy trang qua máy chủ Yandex; trợ lý Alice xử lý giọng nói ở Nga.",
            ["chrome"]="Vụ chống độc quyền: DOJ thắng biện pháp (tháng 9/2025) — Google phải chia sẻ dữ liệu tìm kiếm với đối thủ, không thỏa thuận mặc định độc quyền. Vụ kiện theo dõi ẩn danh kết thúc bằng xóa hàng tỷ bản ghi. Privacy Sandbox giữ lập hồ sơ quảng cáo nội bộ.",
            ["brave"]="2020: tự thêm mã liên kết vào URL sàn tiền mã hóa (CEO đã xin lỗi). Quá khứ quyên góp Prop-8 của nhà sáng lập Brendan Eich thỉnh thoảng bị nhắc lại. Còn lại hồ sơ riêng tư tốt.",
            ["brave-debloat"]="Hiện là do tổ chức của bạn quản lý.",
            ["edge-debloat"]="Hiện là do tổ chức của bạn quản lý.",
            ["comet"]="Trình duyệt AI của Perplexity: nội dung trang được gửi tới mô hình AI; Cloudflare cáo buộc quét hung hăng (2025); duyệt tác tử đặt câu hỏi riêng tư mới.",
            ["duckduckgo"]="2022: trình duyệt để lọt trình theo dõi Microsoft do thỏa thuận phân phối Bing (nhà nghiên cứu Zach Edwards phanh phui); đã vá tháng 8/2022.",
            ["chromium"]="Không có trình tự cập nhật trên bản Windows: bản vá bảo mật phụ thuộc người biên dịch binary của bạn (Hibbiki, v.v.); một số API Google (đồng bộ) bị loại bỏ.",
            ["cachy-browser"]="Bản dựng ngách của cộng đồng CachyOS (Arch); yêu cầu AVX2; ít người rà soát mã hơn trình duyệt phổ biến.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_vi = new()
    {

            ["arc"]="Đồng bộ qua tài khoản bằng máy chủ The Browser Company; tính năng AI gửi nội dung trang tới mô hình của họ.",
            ["operagx"]="Giống Opera: dữ liệu duyệt web trên máy chủ Opera; VPN miễn phí qua hạ tầng Opera.",
            ["mullvad"]="Không có: không đo lường từ xa, không định danh, chống vân tay bật mặc định.",
            ["thorium"]="Giống Chromium trừ một số dịch vụ Google và yêu cầu nền.",
            ["floorp"]="Tắt đo lường từ xa mặc định; một số tính năng liên hệ máy chủ dự án Nhật.",
            ["waterfox"]="Đã loại bỏ đo lường từ xa; chỉ kiếm tiền qua công cụ tìm kiếm đối tác.",
            ["ungoogled"]="Không kết nối Google theo thiết kế; không đo lường từ xa; tìm kiếm web phụ thuộc công cụ bạn chọn.",
            ["dia"]="Nội dung trang và hội thoại được gửi tới mô hình AI của The Browser Company; yêu cầu tài khoản.",
            ["avast-secure"]="Đo lường từ xa và ưu đãi quảng cáo của Avast; với hồ sơ của công ty mẹ, hãy coi như bị lập hồ sơ trừ khi có bằng chứng ngược lại.",
            ["librewolf"]="Không có theo mặc định: đo lường từ xa, Pocket, dịch vụ Google và thu thập dữ liệu bị loại bỏ khi build.",
            ["firefox"]="Đo lường từ xa, báo cáo sự cố và gợi ý theo vị trí; thử nghiệm đo lường quảng cáo bảo vệ riêng tư (PPA).",
            ["opera"]="Dữ liệu duyệt web xử lý trên máy chủ Opera; VPN miễn phí định tuyến qua hạ tầng Opera.",
            ["whale"]="Đồng bộ tài khoản Naver, đo lường sử dụng tới máy chủ Naver; cá nhân hóa gắn với dịch vụ Naver.",
            ["kagi-orion"]="Tuyên bố không đo lường từ xa; không hồ sơ quảng cáo; đồng bộ trên Apple qua iCloud, cục bộ trên Windows.",
            ["pale-moon"]="Ít đo lường từ xa, nhưng engine lỗi thời mới là rủi ro lớn hơn.",
            ["vivaldi"]="Không lập hồ sơ; đồng bộ mã hóa đầu cuối; chỉ thống kê sử dụng nếu bạn opt-in.",
            ["tor-browser"]="Lưu lượng nhảy qua 3 rơ-le tình nguyện mã hóa; không đo lường từ xa; đăng nhập tài khoản cá nhân sẽ tự phá vỡ ẩn danh.",
            ["zen"]="Dựa trên Firefox đã tắt đo lường từ xa; cập nhật qua hạ tầng Mozilla.",
            ["edge"]="Dữ liệu chẩn đoán, lịch sử duyệt web khi bật đồng bộ, ID quảng cáo cho quảng cáo cá nhân hóa.",
            ["falkon"]="Đo lường tối thiểu; tích hợp máy tính KDE chỉ nếu bạn dùng dịch vụ đó.",
            ["epic-browser"]="Tuyên bố không đo lường và chặn trình theo dõi mạnh; không thể xác minh do mã đóng.",
            ["yandex"]="Đo lường sâu rộng, tìm kiếm, vị trí và giọng nói tới Yandex (Nga); quảng cáo cá nhân hóa.",
            ["chrome"]="Đồng bộ lịch sử, tìm kiếm, vị trí và giọng nói với tài khoản Google của bạn; cá nhân hóa quảng cáo theo mặc định.",
            ["brave"]="Tối thiểu theo thiết kế: thống kê P3A bảo vệ riêng tư (có thể tắt), không theo dõi tìm kiếm hay hồ sơ.",
            ["brave-debloat"]="Tắt tiện ích phụ và đo lường từ xa.",
            ["edge-debloat"]="Tắt mua sắm, tiện ích phụ và đo lường từ xa.",
            ["comet"]="Ngữ cảnh duyệt web do AI Perplexity xử lý; yêu cầu tài khoản; lịch sử tìm kiếm gắn với hồ sơ Perplexity của bạn.",
            ["duckduckgo"]="Không hồ sơ quảng cáo; tìm kiếm lưu nhật ký ẩn danh; đồng bộ trình duyệt mã hóa.",
            ["chromium"]="Engine Chrome không có đồng bộ và dịch vụ Google; tìm kiếm web phụ thuộc công cụ bạn chọn.",
            ["cachy-browser"]="Dựa trên Chromium với ít bản vá tài liệu; đo lường theo mặc định upstream Chromium trừ dịch vụ Google.",
        
    };
}
