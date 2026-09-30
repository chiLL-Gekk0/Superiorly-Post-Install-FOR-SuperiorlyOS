namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_tr = new()
    {
 ["home"]="Giriş", ["browsers"]="Tarayıcılar", ["tools"]="Araçlar", ["tweaking"]="İnce Ayar", ["troubleshooting"]="Sorun Giderme" 
    };
    private static readonly Dictionary<string, string> SectionDescs_tr = new()
    {
 ["home"]="Araç kutunuza hoş geldiniz", ["browsers"]="Tarayıcı ile ilgili yardımcı programlar ve düzeltmeler", ["tools"]="Taşınabilir yardımcı programları indirir ve çalıştırır", ["tweaking"]="Sürücü, GPU ve sistem ince ayarları.", ["troubleshooting"]="Hızlı geçişler ve sistem düzeltmeleri." 
    };
    private static readonly Dictionary<string, string> TabTitles_tr = new()
    {
 ["mainstream"]="Popüler", ["privacy"]="Gizlilik", ["forks"]="Çatal ve Özel", ["software"]="Yazılım", ["store-downloader"]="Microsoft Store İndiricisi", ["utilities"]="Yardımcı Programlar", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="Kayıt Defteri İnce Ayarları", ["win32"]="Win32PrioritySeparation", ["powerplans"]="Güç Planları", ["connectivity"]="Bağlantı", ["devices"]="Cihazlar", ["security"]="Güvenlik", ["gaming"]="Oyun", ["ai"]="Yapay Zeka", ["debloat"]="Debloat", ["system"]="Sistem" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Notifications_tr = new()
    {
 ["opened"]="Açıldı - başlatıldı", ["installed"]="Başarıyla yüklendi", ["failed"]="Yükleme başarısız oldu", ["open_failed"]="Açılamadı", ["enabled"]="Etkinleştirildi", ["disabled"]="Devre dışı bırakıldı", ["apply_failed"]="Uygulanamadı", ["applied"]="Uygulandı" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_tr = new()
    {

            ["settings"]="Ayarlar", ["language"]="Dil", ["theme"]="Tema", ["dark"]="Koyu", ["light"]="Açık", ["auto"]="Otomatik", ["default_theme"]="Varsayılan Tema",
            ["style"]="Stil", ["win10_style"]="Windows 10 stili", ["win11_style"]="Windows 11 stili", ["close"]="Kapat",
            ["search_placeholder"]="Ad, URL veya kimliğe göre arayın.", ["store_no_results"]="Sonuç bulunamadı. Başka bir arama deneyin.", ["search"]="Ara", ["install"]="Yükle",
            ["run"]="Çalıştır", ["download"]="İndir", ["apply"]="Uygula",
            ["check_updates"]="Güncelleştirmeleri denetle", ["update"]="Update", ["disclaimer"]="Değişiklikler tamamen sizin sorumluluğunuzdadır.",
            ["quantum_title"]="Quantum Haritası", ["quantum_subtitle"]="Tüm geçerli Win32PrioritySeparation değerleri. Uygulamak için bir satıra tıklayın.",
            ["open_quantum"]="Quantum Haritasını Aç", ["current_win32"]="Geçerli Win32PrioritySeparation",
            ["load_list"]="Listeyi yükle", ["unload_list"]="Listeyi kapat", ["activate"]="Etkinleştir", ["import"]="İçeri aktar", ["export"]="Dışarı aktar",
            ["select_all"]="Tümünü seç", ["unselect_all"]="Seçimi temizle", ["uninstall"]="Kaldır", ["delete"]="Sil",
            ["restore_default"]="Varsayılanları geri yükle", ["yes"]="Evet", ["no"]="Hayır",
            ["searching_for"]="'{0}' aranıyor...", ["downloading"]="{0} indiriliyor...", ["starting"]="{0} başlatılıyor...",
            ["applying"]="{0} uygulanıyor...", ["installing"]="{0} yükleniyor...",             ["loading"]="{0} yükleniyor...",
            ["reading_plans"]="Güç planları okunuyor...", ["populating_list"]="Liste oluşturuluyor...",
            ["apps_found"]="{0} uygulama bulundu", ["nothing_found"]="Hiçbir şey bulunamadı", ["loaded_items"]="{0} öğe yüklendi",
            ["list_unloaded"]="Liste kapatıldı",
            ["exported"]="{0} dışarı aktarıldı",
            ["installed_n"]="{0} uygulama yüklendi", ["install_failed"]="Yükleme başarısız oldu",
            ["failed_admin"]="Başarısız - Yönetici olarak çalıştırın veya yeniden başlatın.", ["failed"]="Başarısız",
            ["win32_set"]="Win32PrioritySeparation {0} olarak ayarlandı",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_tr = new()
    {
 ["run"]="Çalıştır", ["download"]="İndir", ["apply"]="Uygula", ["enable"]="Etkinleştir", ["disable"]="Devre dışı bırak", ["search"]="Ara", ["install"]="Yükle", ["load list"]="Listeyi yükle", ["uninstall"]="Kaldır", ["activate"]="Etkinleştir", ["delete"]="Sil", ["import .pow"]=".pow içeri aktar", ["default"]="Varsayılan", ["custom"]="Özel", ["minimum"]="En düşük", ["disable mmcss"]="MMCSS'yi devre dışı bırak", ["bypass"]="Atlat", ["repeater"]="Tekrarlayıcı", ["realtime"]="Gerçek Zamanlı", ["high"]="Yüksek", ["abovenormal"]="Normalin Üstü", ["normal"]="Normal", ["belownormal"]="Normalin Altı", ["enhanced"]="Gelişmiş", ["legacy"]="Eski", ["disabled"]="Devre dışı", ["enabled"]="Etkin", ["alwayson"]="Her Zaman Açık", ["alwaysoff"]="Her Zaman Kapalı", ["optin"]="Seçimli Katılım", ["optout"]="Seçimli Ayrılma", ["open cru"]="CRU Aç", ["coming soon"]="Yakında", ["safe fivem/minecraft services"]="Güvenli FiveM/Minecraft Hizmetleri", ["kernelos default"]="Superiorly Varsayılanı" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> TabDescs_tr = new()
    {
 ["mainstream"]="Günlük tarayıcılar.", ["privacy"]="Gizlilik ve anonimlik odaklı tarayıcılar.", ["forks"]="Chromium ve Firefox tabanlı topluluk derlemeleri.", ["utilities"]="Sistem ve donanım tanılama araçları.", ["amd"]="Sürücüler, saat hızı, voltaj ve kayıt defteri için AMD GPU araçları.", ["nvidia"]="Temiz yükleme, profiller ve P-States için NVIDIA araçları.", ["connectivity"]="Wi-Fi, Bluetooth ve erişim noktası atlama sınırı ayarları.", ["devices"]="Yazıcı, Görev Yöneticisi ve metin girişi düzeltmeleri.", ["security"]="Çekirdek yalıtım, güvenlik duvarı, UAC, sürücü engelleme listesi ve bellek korumaları.", ["gaming"]="Xbox hizmetleri ve Opera GX.", ["ai"]="Chromium, WebKit ve yapay zeka odaklı göz atma.", ["debloat"]="Browser privacy policies and vendor telemetry switches: Chrome, Edge, Firefox and Office.", ["system"]="Windows Update sürücüsü, Başlat menüsü ve Intel paneli düzeltmeleri." , ["telemetry"]=""
    };
    private static readonly Dictionary<string, string> SectionTabDescs_tr = new()
    {
 ["browsers|gaming"]="Yerleşik CPU, RAM ve ağ sınırlayıcılara sahip Opera GX.", ["troubleshooting|gaming"]="Xbox hizmetleri ve güvenli FiveM/Minecraft hizmetleri." 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_tr = new()
    {
 ["mainstream"]="Günlük Tarayıcılar", ["privacy"]="Anonim Göz Atma", ["forks"]="Bağımsız Çatallar", ["utilities"]="Sistem Yardımcı Programları", ["amd"]="Radeon Araçları", ["nvidia"]="GeForce Araçları", ["connectivity"]="Kablosuz Ayarları", ["devices"]="Cihaz Düzeltmeleri", ["security"]="Sistem Korumaları", ["gaming"]="Oyun Hizmetleri", ["ai"]="YZ Tarayıcıları", ["debloat"]="Tarayıcı Temizleme", ["system"]="Windows Düzeltmeleri" , ["telemetry"]="Telemetry Fixes"
    };
    private static readonly Dictionary<string, string> SectionTabTitles_tr = new()
    {
 ["browsers|gaming"]="Oyun Tarayıcısı", ["troubleshooting|gaming"]="Oyun Hizmetleri" 
    };
    private static readonly Dictionary<string, string> UiExtra_tr = new()
    {
["state_on"]="Açık", ["state_off"]="Kapalı", 
            ["confirm_delete"]="Silmeyi onayla",
            ["confirm_enable"]="Bu değişiklik uygulansın mı?",
            ["delete_plans"]="{0} güç planını silmek istiyor musunuz?",
            ["cant_delete_active"]="Etkin güç planı silinemez. Önce başka bir plana geçin.",
            ["import_plan"]="Güç planını içeri aktar", ["export_plan"]="Güç planını dışarı aktar",
            ["ratio"]="oran", ["long"]="Uzun", ["short"]="Kısa", ["fixed"]="Sabit", ["variable"]="Değişken", ["boost"]="hızlandırma", ["current"]="geçerli",
            ["needs_admin"]="Bu işlem yönetici ayrıcalıkları gerektirir.",
            ["restart_driver"]="Görüntü sürücüsünü yeniden başlat", ["reset_all"]="Tümünü sıfırla", ["download_cru"]="CRU indir",
            ["modify_quantum"]="Quantum değerini değiştir", ["quantum_length"]="Quantum Süresi", ["quantum_interval"]="Quantum Aralığı",
            ["fix"]="Düzelt", ["preview_hex"]="Hex Önizleme", ["preview_bits"]="Bit Önizleme",
            ["minimize"]="Simge durumuna küçült", ["maximize"]="Büyüt", ["toggle_theme"]="Açık ve koyu tema arasında geçiş yapın",
            ["follow_theme"]="Windows temasını izle", ["square"]="Kare köşeler", ["rounded"]="Yuvarlak köşeler",
            ["join"]="KATIL", ["follow"]="TAKİP ET", ["visit"]="ZİYARET ET", ["copy_link"]="Bağlantıyı kopyala", ["copied"]="Kopyalandı",
            ["no_profiles_found"]="Profil bulunamadı. Nvidia Profiles klasörüne .nip dosyaları koyun.",
            ["confirm_disable"]="Bu korumayı devre dışı bırak?",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="Güvenlik: ", ["power_plan_filter"]="Güç Planı",
            ["theme_changed"]="Tema {0} olarak değiştirildi", ["style_changed"]="Stil {0} olarak değiştirildi",
            ["powerplan_custom"]="Özel", ["powerplan_restore"]="Resmi olanı geri yükle",
            ["update_available"]="{0} güncellemesi mevcut", ["new_update"]="Yeni güncelleme: {0}", ["up_to_date"]="Güncelsiniz", ["update_check_failed"]="Güncelleştirmeler denetlenemedi",
        
    };
}
