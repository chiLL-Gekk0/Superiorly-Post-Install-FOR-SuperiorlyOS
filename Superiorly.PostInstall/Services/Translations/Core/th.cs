namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_th = new()
    {
 ["home"]="หน้าแรก", ["browsers"]="เบราว์เซอร์", ["tools"]="เครื่องมือ", ["tweaking"]="ปรับแต่ง", ["troubleshooting"]="แก้ไขปัญหา" 
    };
    private static readonly Dictionary<string, string> SectionDescs_th = new()
    {
 ["home"]="ยินดีต้อนรับสู่กล่องเครื่องมือของคุณ", ["browsers"]="ยูทิลิตี้และการแก้ไขเกี่ยวกับเบราว์เซอร์", ["tools"]="ดาวน์โหลดและเรียกใช้ยูทิลิตี้แบบพกพา", ["tweaking"]="ปรับแต่งไดรเวอร์ GPU และระบบ", ["troubleshooting"]="สวิตช์ด่วนและการแก้ไข OS" 
    };
    private static readonly Dictionary<string, string> TabTitles_th = new()
    {
 ["mainstream"]="ทั่วไป", ["privacy"]="ความเป็นส่วนตัว", ["forks"]="ฟอร์กและกำหนดเอง", ["software"]="ซอฟต์แวร์", ["store-downloader"]="ตัวดาวน์โหลด Microsoft Store", ["utilities"]="ยูทิลิตี้", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="รีจิสทรี", ["win32"]="Win32Priority", ["powerplans"]="แผนพลังงาน", ["connectivity"]="การเชื่อมต่อ", ["devices"]="อุปกรณ์", ["security"]="คะแนนความเป็นส่วนตัว: ", ["gaming"]="เกม", ["ai"]="AI", ["debloat"]="ดีโบลต", ["system"]="ระบบ" , ["telemetry"]="เทเลเมทรี",
["app-privacy"]="ความเป็นส่วนตัวของแอป",
    };
    private static readonly Dictionary<string, string> Notifications_th = new()
    {
 ["opened"]="เปิดแล้ว - เริ่มใช้งานแล้ว", ["installed"]="ติดตั้งสำเร็จ", ["failed"]="การติดตั้งล้มเหลว", ["open_failed"]="เปิดไม่สำเร็จ", ["enabled"]="เปิดใช้งานแล้ว", ["disabled"]="ปิดใช้งานแล้ว", ["apply_failed"]="นำไปใช้ไม่สำเร็จ", ["applied"]="นำไปใช้แล้ว" , ["telemetry"]="เทเลเมทรี"
    };
    private static readonly Dictionary<string, string> Ui_th = new()
    {

            ["settings"]="การตั้งค่า", ["language"]="ภาษา", ["theme"]="ธีม", ["dark"]="สีเข้ม", ["light"]="สีอ่อน", ["auto"]="อัตโนมัติ", ["default_theme"]="ธีมเริ่มต้น",
            ["style"]="สไตล์", ["win10_style"]="ลักษณะ Windows 10", ["win11_style"]="ลักษณะ Windows 11", ["close"]="ปิด",
            ["search_placeholder"]="ค้นหาตามชื่อ URL หรือ ID", ["store_no_results"]="ไม่พบผลลัพธ์ ลองค้นหาอย่างอื่น", ["search"]="ค้นหา", ["install"]="ติดตั้ง",
            ["run"]="เรียกใช้", ["download"]="ดาวน์โหลด", ["open"]="เปิด", ["apply"]="นำไปใช้",
            ["check_updates"]="ตรวจสอบการอัปเดต", ["update"]="อัปเดต", ["disclaimer"]="การแก้ไขถือเป็นความรับผิดชอบของคุณแต่เพียงผู้เดียว",
            ["quantum_title"]="แผนผัง Quantum", ["quantum_subtitle"]="ค่า Win32PrioritySeparation ที่ใช้ได้ทั้งหมด คลิกแถวเพื่อนำไปใช้",
            ["open_quantum"]="เปิดแผนผัง Quantum", ["current_win32"]="ค่า Win32PrioritySeparation ปัจจุบัน",
            ["load_list"]="โหลดรายการ", ["unload_list"]="ยกเลิกรายการ", ["activate"]="เปิดใช้งาน", ["import"]="นำเข้า", ["export"]="ส่งออก",
            ["select_all"]="เลือกทั้งหมด", ["unselect_all"]="ยกเลิกการเลือกทั้งหมด", ["uninstall"]="ถอนการติดตั้ง", ["delete"]="ลบ",
            ["restore_default"]="คืนค่าเริ่มต้น", ["yes"]="ใช่", ["no"]="ไม่",
            ["searching_for"]="กำลังค้นหา '{0}'...", ["downloading"]="กำลังดาวน์โหลด {0}...", ["starting"]="กำลังเริ่ม {0}...",
            ["applying"]="กำลังนำ {0} ไปใช้...", ["installing"]="กำลังติดตั้ง {0}...",             ["loading"]="กำลังโหลด {0}...",
            ["reading_plans"]="กำลังอ่านแผนพลังงาน...", ["populating_list"]="กำลังสร้างรายการ...",
            ["apps_found"]="พบ {0} แอป", ["nothing_found"]="ไม่พบข้อมูล", ["loaded_items"]="โหลด {0} รายการแล้ว",
            ["list_unloaded"]="ยกเลิกรายการแล้ว",
            ["exported"]="ส่งออก {0} แล้ว",
            ["installed_n"]="ติดตั้ง {0} แอปแล้ว", ["install_failed"]="การติดตั้งล้มเหลว",
            ["failed_admin"]="ล้มเหลว - เรียกใช้ในฐานะผู้ดูแลระบบหรือต้องรีบูต", ["failed"]="ล้มเหลว",
            ["win32_set"]="ตั้งค่า Win32PrioritySeparation เป็น {0} แล้ว",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_th = new()
    {
 ["run"]="เรียกใช้", ["download"]="ดาวน์โหลด", ["apply"]="นำไปใช้", ["enable"]="เปิดใช้งาน", ["disable"]="ปิดใช้งาน", ["search"]="ค้นหา", ["install"]="ติดตั้ง", ["load list"]="โหลดรายการ", ["uninstall"]="ถอนการติดตั้ง", ["activate"]="เปิดใช้งาน", ["delete"]="ลบ", ["import .pow"]="นำเข้า .pow", ["default"]="ค่าเริ่มต้น", ["custom"]="กำหนดเอง", ["full"]="แบบเต็ม", ["reduced"]="ขนาดย่อ", ["minimum"]="ต่ำสุด", ["disable mmcss"]="ปิดใช้งาน MMCSS", ["bypass"]="บายพาส", ["repeater"]="รีพีตเตอร์", ["realtime"]="เรียลไทม์", ["high"]="สูง", ["abovenormal"]="สูงกว่าปกติ", ["normal"]="ปกติ", ["belownormal"]="ต่ำกว่าปกติ", ["enhanced"]="ปรับปรุงแล้ว", ["legacy"]="ดั้งเดิม", ["disabled"]="ปิดใช้งาน", ["enabled"]="เปิดใช้งาน", ["alwayson"]="เปิดตลอด", ["alwaysoff"]="ปิดตลอด", ["optin"]="เลือกเข้าร่วม", ["optout"]="เลือกไม่เข้าร่วม", ["open cru"]="เปิด CRU", ["coming soon"]="เร็ว ๆ นี้", ["safe fivem/minecraft services"]="บริการ Safe FiveM/Minecraft", ["kernelos default"]="ค่าเริ่มต้น Superiorly" , ["telemetry"]="เทเลเมทรี"
    };
    private static readonly Dictionary<string, string> TabDescs_th = new()
    {
 ["mainstream"]="เบราว์เซอร์ใช้ประจำวัน", ["privacy"]="เบราว์เซอร์ที่สร้างมาเพื่อความเป็นส่วนตัวและการไม่เปิดเผยตัวตน", ["forks"]="บิลด์ชุมชนที่พัฒนาจาก Chromium และ Firefox", ["utilities"]="เครื่องมือวินิจฉัยระบบและฮาร์ดแวร์", ["amd"]="เครื่องมือ GPU AMD สำหรับไดรเวอร์ นาฬิกา แรงดันไฟฟ้า และรีจิสทรี", ["nvidia"]="เครื่องมือ NVIDIA สำหรับติดตั้งแบบสะอาด โปรไฟล์ และ P-State", ["connectivity"]="การตั้งค่า Wi-Fi Bluetooth และขีดจำกัด Hop ของฮอตสปอต", ["devices"]="การแก้ไขเครื่องพิมพ์ Task Manager และการป้อนข้อความ", ["security"]="การแยกคอร์ ไฟร์วอลล์ UAC บัญชีดำไดรเวอร์ และการป้องกันหน่วยความจำ", ["gaming"]="บริการ Xbox และ Opera GX", ["ai"]="การท่องเว็บแบบ Chromium WebKit และ AI-first", ["debloat"]="นโยบายความเป็นส่วนตัวของเบราว์เซอร์และสวิตช์เทเลเมทรีของผู้จำหน่าย: Chrome, Edge, Firefox และ Office", ["system"]="การแก้ไขไดรเวอร์ Windows Update เมนู Start และแผง Intel" , ["telemetry"]="สวิตช์เทเลเมทรี คำแนะนำ โฆษณา และการเก็บข้อมูลของผู้จำหน่าย",
["app-privacy"]="สิทธิ์ของแอปและการตั้งค่าความเป็นส่วนตัว",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_th = new()
    {
 ["browsers|gaming"]="Opera GX พร้อมตัวจำกัด CPU RAM และเครือข่ายในตัว", ["tweaking|gaming"]="บริการ Xbox และบริการ Safe FiveM/Minecraft" 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_th = new()
    {
 ["mainstream"]="เบราว์เซอร์ประจำวัน", ["privacy"]="ท่องเว็บแบบไม่เปิดเผยตัวตน", ["forks"]="ฟอร์กอิสระ", ["utilities"]="ยูทิลิตี้ระบบ", ["amd"]="เครื่องมือ Radeon", ["nvidia"]="เครื่องมือ GeForce", ["connectivity"]="การตั้งค่าไร้สาย", ["devices"]="การแก้ไขอุปกรณ์", ["security"]="การป้องกันระบบ", ["gaming"]="บริการเกม", ["ai"]="เบราว์เซอร์ AI", ["debloat"]="ดีโบลตเบราว์เซอร์", ["system"]="การแก้ไข Windows" , ["telemetry"]="การแก้ไขเทเลเมทรี",
["app-privacy"]="ความเป็นส่วนตัวของแอป",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_th = new()
    {
 ["browsers|gaming"]="เบราว์เซอร์เกม"
    };
    private static readonly Dictionary<string, string> UiExtra_th = new()
    {
["state_on"]="เปิด", ["state_off"]="ปิด", 
            ["confirm_delete"]="ยืนยันการลบ",
            ["confirm_enable"]="นำการเปลี่ยนแปลงนี้ไปใช้?",
            ["confirm_disable"]="ปิดการป้องกันนี้?",
            ["delete_plans"]="ลบแผนพลังงาน {0} แผน?",
            ["cant_delete_active"]="ไม่สามารถลบแผนพลังงานที่ใช้งานอยู่ได้ สลับไปยังแผนอื่นก่อน",
            ["import_plan"]="นำเข้าแผนพลังงาน", ["export_plan"]="ส่งออกแผนพลังงาน",
            ["ratio"]="อัตราส่วน", ["long"]="ยาว", ["short"]="สั้น", ["fixed"]="คงที่", ["variable"]="แปรผัน", ["boost"]="บูสต์", ["current"]="ปัจจุบัน",
            ["needs_admin"]="การดำเนินการนี้ต้องใช้สิทธิ์ผู้ดูแลระบบ",
            ["restart_driver"]="รีสตาร์ตไดรเวอร์จอภาพ", ["reset_all"]="รีเซ็ตทั้งหมด", ["download_cru"]="ดาวน์โหลด CRU",
            ["modify_quantum"]="แก้ไข Quantum", ["quantum_length"]="ความยาว Quantum", ["quantum_interval"]="ช่วงเวลา Quantum",
            ["fix"]="แก้ไข", ["preview_hex"]="ดูตัวอย่าง Hex", ["preview_bits"]="ดูตัวอย่าง Bits",
            ["minimize"]="ย่อ", ["maximize"]="ขยาย", ["toggle_theme"]="สลับธีมสว่าง / สีเข้ม",
            ["follow_theme"]="ทำตามธีม Windows", ["square"]="มุมเหลี่ยม", ["rounded"]="มุมโค้ง",
            ["join"]="เข้าร่วม", ["follow"]="ติดตาม", ["visit"]="เยี่ยมชม", ["copy_link"]="คัดลอกลิงก์", ["copied"]="คัดลอกแล้ว",
            ["no_profiles_found"]="ไม่พบโปรไฟล์ วางไฟล์ .nip ในโฟลเดอร์ Nvidia Profiles",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0", ["welcome"]="ยินดีต้อนรับ", ["hero_tagline"]="SUPERIORLY",
            ["security"]="ความปลอดภัย: ", ["power_plan_filter"]="แผนพลังงาน",
            ["theme_changed"]="เปลี่ยนธีมเป็น {0} แล้ว", ["style_changed"]="เปลี่ยนลักษณะเป็น {0} แล้ว",
            ["powerplan_custom"]="กำหนดเอง", ["powerplan_restore"]="คืนค่าทางการ",
            ["update_available"]="มีการอัปเดต {0}", ["new_update"]="อัปเดตใหม่: {0}", ["up_to_date"]="คุณใช้เวอร์ชันล่าสุดแล้ว", ["update_check_failed"]="ไม่สามารถตรวจสอบการอัปเดตได้",
        
    };
}
