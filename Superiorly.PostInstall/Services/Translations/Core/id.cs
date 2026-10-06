namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_id = new()
    {
 ["home"]="Beranda", ["browsers"]="Browser", ["tools"]="Alat", ["tweaking"]="Penyesuaian", ["troubleshooting"]="Pemecahan Masalah" 
    };
    private static readonly Dictionary<string, string> SectionDescs_id = new()
    {
 ["home"]="Selamat datang di kotak alat Anda", ["browsers"]="Utilitas dan perbaikan terkait browser", ["tools"]="Unduh dan jalankan utilitas portabel", ["tweaking"]="Tweak driver, GPU, dan sistem.", ["troubleshooting"]="Sakelar cepat dan perbaikan OS." 
    };
    private static readonly Dictionary<string, string> TabTitles_id = new()
    {
 ["mainstream"]="Populer", ["privacy"]="Privasi", ["forks"]="Fork & Kustom", ["software"]="Perangkat Lunak", ["store-downloader"]="Pengunduh Microsoft Store", ["utilities"]="Utilitas", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Registri", ["win32"]="Win32Priority", ["powerplans"]="Paket Daya", ["connectivity"]="Konektivitas", ["devices"]="Perangkat", ["security"]="Proteksi", ["gaming"]="Game", ["ai"]="AI", ["debloat"]="Debloat", ["system"]="Sistem" , ["telemetry"]="Telemetri",
["app-privacy"]="Privasi Aplikasi",
    };
    private static readonly Dictionary<string, string> Notifications_id = new()
    {
 ["opened"]="Dibuka - diluncurkan", ["installed"]="Berhasil diinstal", ["failed"]="Instalasi gagal", ["open_failed"]="Gagal dibuka", ["enabled"]="Diaktifkan", ["disabled"]="Dinonaktifkan", ["apply_failed"]="Gagal diterapkan", ["applied"]="Diterapkan" , ["telemetry"]="Telemetri"
    };
    private static readonly Dictionary<string, string> Ui_id = new()
    {

            ["settings"]="Pengaturan", ["language"]="Bahasa", ["theme"]="Tema", ["dark"]="Gelap", ["light"]="Terang", ["auto"]="Otomatis", ["default_theme"]="Tema Default",
            ["style"]="Gaya", ["win10_style"]="Gaya Windows 10", ["win11_style"]="Gaya Windows 11", ["close"]="Tutup",
            ["search_placeholder"]="Cari berdasarkan nama, URL, atau ID.", ["store_no_results"]="Tidak ada hasil. Coba pencarian lain.", ["search"]="Cari", ["install"]="Instal",
            ["run"]="Jalankan", ["download"]="Unduh", ["open"]="Buka", ["apply"]="Terapkan",
            ["check_updates"]="Periksa pembaruan", ["update"]="Perbarui", ["disclaimer"]="Modifikasi sepenuhnya menjadi tanggung jawab Anda.",
            ["quantum_title"]="Peta Quantum", ["quantum_subtitle"]="Semua nilai Win32PrioritySeparation yang valid. Klik baris untuk menerapkannya.",
            ["open_quantum"]="Buka Peta Quantum", ["current_win32"]="Win32PrioritySeparation Saat Ini",
            ["load_list"]="Muat daftar", ["unload_list"]="Tutup daftar", ["activate"]="Aktifkan", ["import"]="Impor", ["export"]="Ekspor",
            ["select_all"]="Pilih Semua", ["unselect_all"]="Batalkan Pilihan Semua", ["uninstall"]="Hapus instalan", ["delete"]="Hapus",
            ["restore_default"]="Kembalikan Default", ["yes"]="Ya", ["no"]="Tidak",
            ["searching_for"]="Mencari '{0}'...", ["downloading"]="Mengunduh {0}...", ["starting"]="Memulai {0}...",
            ["applying"]="Menerapkan {0}...", ["installing"]="Menginstal {0}...",             ["loading"]="Memuat {0}...",
            ["reading_plans"]="Membaca paket daya...", ["populating_list"]="Mengisi daftar...",
            ["apps_found"]="{0} aplikasi ditemukan", ["nothing_found"]="Tidak ada yang ditemukan", ["loaded_items"]="{0} item dimuat",
            ["list_unloaded"]="Daftar ditutup",
            ["exported"]="{0} diekspor",
            ["installed_n"]="{0} aplikasi terinstal", ["install_failed"]="Instalasi gagal",
            ["failed_admin"]="Gagal - Jalankan sebagai administrator atau mulai ulang diperlukan", ["failed"]="Gagal",
            ["win32_set"]="Win32PrioritySeparation diatur ke {0}",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_id = new()
    {
 ["run"]="Jalankan", ["download"]="Unduh", ["apply"]="Terapkan", ["enable"]="Aktifkan", ["disable"]="Nonaktifkan", ["search"]="Cari", ["install"]="Instal", ["load list"]="Muat daftar", ["uninstall"]="Hapus instalan", ["activate"]="Aktifkan", ["delete"]="Hapus", ["import .pow"]="Impor .pow", ["default"]="Default", ["custom"]="Kustom", ["full"]="Penuh", ["reduced"]="Dikecilkan", ["minimum"]="Minimum", ["disable mmcss"]="Nonaktifkan MMCSS", ["bypass"]="Bypass", ["repeater"]="Repeater", ["realtime"]="Waktu Nyata", ["high"]="Tinggi", ["abovenormal"]="Di Atas Normal", ["normal"]="Normal", ["belownormal"]="Di Bawah Normal", ["enhanced"]="Ditingkatkan", ["legacy"]="Lawas", ["disabled"]="Dinonaktifkan", ["enabled"]="Diaktifkan", ["alwayson"]="Selalu Aktif", ["alwaysoff"]="Selalu Nonaktif", ["optin"]="Ikut Serta", ["optout"]="Tidak Ikut Serta", ["open cru"]="Buka CRU", ["coming soon"]="Segera hadir", ["safe fivem/minecraft services"]="Layanan Aman FiveM/Minecraft", ["kernelos default"]="Default Superiorly" , ["telemetry"]="Telemetri"
    };
    private static readonly Dictionary<string, string> TabDescs_id = new()
    {
 ["mainstream"]="Browser sehari-hari.", ["privacy"]="Browser yang dibuat untuk privasi dan anonimitas.", ["forks"]="Build komunitas berbasis Chromium dan Firefox.", ["utilities"]="Alat untuk diagnostik sistem dan perangkat keras.", ["amd"]="Alat GPU AMD untuk driver, clock, voltase, dan registri.", ["nvidia"]="Alat NVIDIA untuk instalasi bersih, profil, dan P-State.", ["connectivity"]="Pengaturan Wi-Fi, Bluetooth, dan batas hop hotspot.", ["devices"]="Perbaikan printer, Task Manager, dan input teks.", ["security"]="Isolasi inti, firewall, UAC, daftar blokir driver, dan proteksi memori.", ["gaming"]="Layanan Xbox dan Opera GX.", ["ai"]="Penjelajahan Chromium, WebKit, dan berbasis AI.", ["debloat"]="Kebijakan privasi browser dan sakelar telemetri vendor: Chrome, Edge, Firefox, dan Office.", ["system"]="Driver Windows Update, Menu Mulai, dan perbaikan panel Intel." , ["telemetry"]="Sakelar telemetri, saran, iklan, dan pengumpulan data vendor.",
["app-privacy"]="Izin aplikasi dan opsi privasi.",
    };
    private static readonly Dictionary<string, string> SectionTabDescs_id = new()
    {
 ["browsers|gaming"]="Opera GX dengan pembatas CPU, RAM, dan jaringan bawaan.", ["tweaking|gaming"]="Layanan Xbox dan layanan aman FiveM/Minecraft." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_id = new()
    {
 ["mainstream"]="Browser Sehari-hari", ["privacy"]="Penjelajahan Anonim", ["forks"]="Fork Independen", ["utilities"]="Utilitas Sistem", ["amd"]="Alat Radeon", ["nvidia"]="Alat GeForce", ["connectivity"]="Pengaturan Nirkabel", ["devices"]="Perbaikan Perangkat", ["security"]="Proteksi Sistem", ["gaming"]="Layanan Game", ["ai"]="Browser AI", ["debloat"]="Debloat Browser", ["system"]="Perbaikan Windows" , ["telemetry"]="Perbaikan Telemetri",
["app-privacy"]="Privasi Aplikasi",
    };
    private static readonly Dictionary<string, string> SectionTabTitles_id = new()
    {
 ["browsers|gaming"]="Browser Game"
    };
    private static readonly Dictionary<string, string> UiExtra_id = new()
    {
["state_on"]="Aktif", ["state_off"]="Nonaktif", 
            ["confirm_delete"]="Konfirmasi hapus",
            ["confirm_enable"]="Terapkan perubahan ini?",
            ["confirm_disable"]="Matikan proteksi ini?",
            ["delete_plans"]="Hapus {0} paket daya?",
            ["cant_delete_active"]="Tidak dapat menghapus paket daya yang aktif. Beralih ke paket lain terlebih dahulu.",
            ["import_plan"]="Impor Paket Daya", ["export_plan"]="Ekspor Paket Daya",
            ["ratio"]="rasio", ["long"]="Panjang", ["short"]="Pendek", ["fixed"]="Tetap", ["variable"]="Variabel", ["boost"]="boost", ["current"]="saat ini",
            ["needs_admin"]="Tindakan ini memerlukan hak administrator.",
            ["restart_driver"]="Mulai Ulang Driver Tampilan", ["reset_all"]="Atur Ulang Semua", ["download_cru"]="Unduh CRU",
            ["modify_quantum"]="Ubah Quantum", ["quantum_length"]="Panjang Quantum", ["quantum_interval"]="Interval Quantum",
            ["fix"]="Perbaiki", ["preview_hex"]="Pratinjau Hex", ["preview_bits"]="Pratinjau Bit",
            ["minimize"]="Minimalkan", ["maximize"]="Maksimalkan", ["toggle_theme"]="Ganti tema terang / gelap",
            ["follow_theme"]="Ikuti tema Windows", ["square"]="Sudut persegi", ["rounded"]="Sudut membulat",
            ["join"]="GABUNG", ["follow"]="IKUTI", ["visit"]="KUNJUNGI", ["copy_link"]="Salin tautan", ["copied"]="Disalin",
            ["no_profiles_found"]="Tidak ada profil ditemukan. Letakkan file .nip di folder Nvidia Profiles.",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0", ["welcome"]="SELAMAT DATANG", ["hero_tagline"]="KE SUPERIORLY",
            ["security"]="Keamanan: ", ["power_plan_filter"]="Paket Daya",
            ["theme_changed"]="Tema diubah ke {0}", ["style_changed"]="Gaya diubah ke {0}",
            ["powerplan_custom"]="Kustom", ["powerplan_restore"]="Pulihkan versi resmi",
            ["update_available"]="Pembaruan {0} tersedia", ["new_update"]="Pembaruan baru: {0}", ["up_to_date"]="Anda sudah menggunakan versi terbaru", ["update_check_failed"]="Tidak dapat memeriksa pembaruan",
        
    };
}
