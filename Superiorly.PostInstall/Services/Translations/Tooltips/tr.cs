namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_tr = new()
    {

            ["arc"]="Geliştirme donduruldu (2025), şirket Dia AI tarayıcıya yöneldi; geçmişteki bir CVE, kullanıcı kimliğiyle oturum ele geçirmeye izin verdi; güvenlik ekibi 1 kişiden 5 kişiye çıktı.",
            ["operagx"]="Opera ile aynı ana şirket: Çinli Kunlun Tech ~%72 hisseye sahip. Ünlü CPU/RAM sınırlayıcılar çoğunlukla görünümlük; Hindenburg iddiaları grubu kapsıyor.",
            ["mullvad"]="Büyük skandal yok. Tor Project ile birlikte geliştirildi (2023); Mullvad VPN polis erişim taleplerini reddetmesiyle tanınır.",
            ["thorium"]="Tek geliştiricinin resmi olmayan Chromium derlemeleri; AVX2 CPU için optimize; tekrarlanabilir derleme garantisi yok, bakımı yapan kişiye güvenirsiniz.",
            ["floorp"]="Firefox kullanmasına rağmen yıllarca kapalı kodlu kalan Japon projesi; 2023'te kodunu açtı. Topluluk yönetimli ama küçük.",
            ["waterfox"]="Reklam şirketi System1'e satıldı (2020); kurucu Alex Kontos bağımsızlığı geri aldı (2023). O zamandan beri skandal yok.",
            ["ungoogled"]="Skandal yok; bedeli güncellemeleri elle denetlemek ve Google bağımlılıklarının agresif kaldırılması nedeniyle ara sıra site bozulmaları.",
            ["dia"]="Arc'ın halefi, davetiyeli beta; AI, sizin adınıza işlem yapmak için sayfa içeriğini ve sohbet geçmişini okur; bağımsız güvenlik denetimi yok.",
            ["avast-secure"]="Ana şirket Avast, Jumpshot aracılığıyla gözatma geçmişlerini sattı (2020'de kapatıldı; 2024'te FTC ile $16.5M uzlaşma); Avast antivirus tarafından agresif şekilde öneriliyor.",
            ["librewolf"]="Büyük skandal yok. Tek eleştiri: topluluk yeniden derlerken güvenlik yamaları Firefox sürümünden günlerce geride kalabilir.",
            ["firefox"]="Mozilla gelirinin çoğunu Google varsayılan anlaşmasından alır; telemetri varsayılan açık; 2025 Kullanım Şartları kısaca geniş veri lisansı ima etti (tepki sonrası geri alındı).",
            ["opera"]="Çinli Kunlun Tech ~%72 sahip (SEC filings). Hindenburg Research, fintech uygulamalarının %365-876 APR krediler verdiğini iddia etti. VPN Deloitte denetimli (log yok).",
            ["whale"]="Koreli dev Naver'in malı; Güney Kore veri yasasına tabi; yan panel hizmetleri (çeviri, alışveriş) Naver'e bağlanır.",
            ["kagi-orion"]="Kapalı kaynak; Windows sürümü genç ve ham. Kagi'nin ücretli arama modeli işin kendisi: gözetim değil, ürün olarak gizlilik.",
            ["pale-moon"]="Eski Goanna motoru yılların Chromium/Firefox güvenlik önlemlerinden yoksun; site bozulmaları sık; tek bakıcılı proje.",
            ["vivaldi"]="Ortaklıklı yer imleri içerir ve varsayılan aramadan (Google) para kazanır; Chromium çekirdeği açık olsa da arayüz kapalı. Ara. 2024: gelir için ortak motorlarda reklam ilişkilendirme betiklerini gizlice etkinleştirdi. Norveç şirketi, profilleme yok.",
            ["tor-browser"]="Hem sansür aşma hem darknet pazarları için kullanılır; çıkış düğümleri HTTPS dışı trafiği görebilir; bazı hükümetler ve siteler tarafından engellenir veya işaretlenir.",
            ["zen"]="Küçük ekipli genç proje; bağımsız güvenlik denetimi yok. Hızlı sürümler gerilemelere yol açabilir.",
            ["edge"]="Telemetri kapalıyken bile benzersiz cihaz kimlikleri gönderir; agresif Bing kenar çubuğu reklamları, sponsorlu öneriler ve ısrarlı geri dönüş istemleri.",
            ["falkon"]="QtWebEngine (Chromium çekirdek) yamaları upstream gerisinden gelir; küçük KDE ekibi; Windows derlemeleri Linux kadar denenmiş değil.",
            ["epic-browser"]="Gizlilik iddialarına rağmen kapalı kaynak: izleyici listesi ve veri işleme bağımsız denetlenemez.",
            ["yandex"]="Rus yargısı: yasalar devlet erişimine izin verir (SORM); Turbo modu sayfaları Yandex sunucuları üzerinden proxiler; Alice asistanı sesi Rusya'da işler.",
            ["chrome"]="Rekabet davası: DOJ çareler kazandı (Eyl. 2025) — Google arama verilerini paylaşmalı, münhasır varsayılan anlaşma yok. Gizli mod davası milyarlarca kaydın silinmesiyle bitti. Privacy Sandbox profillemeyi içeride tutar.",
            ["brave"]="2020: kripto borsa URL'lerine otomatik ortaklık kodu ekledi (CEO özür diledi). Kurucu Brendan Eich'in bağış geçmişi zaman zaman gündeme gelir. Bunun dışında güçlü gizlilik kaydı.",
            ["brave-debloat"]="Kuruluşunuz tarafından yönetiliyor olarak görünür.",
            ["edge-debloat"]="Kuruluşunuz tarafından yönetiliyor olarak görünür.",
            ["comet"]="Perplexity AI tarayıcısı: sayfa içeriği AI modellerine gönderilir; Cloudflare agresif scraping ile suçladı (2025); aracılı gezinme yeni sorular doğurur.",
            ["duckduckgo"]="2022: Bing dağıtım anlaşması nedeniyle Microsoft izleyicilerine izin verdi (araştırmacı Zach Edwards ortaya çıkardı); Ağu. 2022'de düzeltildi.",
            ["chromium"]="Windows derlemelerinde otomatik güncelleyici yok: düzeltmeler binary'i derleyen kişiye bağlı; bazı Google API'leri (sync) kaldırılmış.",
            ["cachy-browser"]="CachyOS (Arch) topluluğunun niş derlemesi; AVX2 gerektirir; inceleme yüzeyi dar, ana akımdan daha az göz.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_tr = new()
    {

            ["arc"]="The Browser Company sunucuları üzerinden hesap tabanlı eşitleme; AI özellikleri sayfa içeriğini modellere gönderir.",
            ["operagx"]="Opera ile aynı: gözatma verileri Opera sunucularında; Opera altyapısı üzerinden ücretsiz VPN.",
            ["mullvad"]="Yok: telemetri yok, tanımlayıcı yok, anti-fingerprinting varsayılan açık.",
            ["thorium"]="Birkaç Google hizmeti ve arka plan isteği dışında Chromium ile aynı.",
            ["floorp"]="Telemetri varsayılan kapalı; birkaç özellik Japon proje sunucularına bağlanır.",
            ["waterfox"]="Telemetri kaldırıldı; yalnızca ortak arama motorlarıyla gelir.",
            ["ungoogled"]="Tasarım gereği Google bağlantısı yok; telemetri yok; aramalar seçtiğiniz motora bağlı.",
            ["dia"]="Sayfa içeriği ve konuşmalar The Browser Company AI modellerine gönderilir; hesap gerekli.",
            ["avast-secure"]="Avast telemetrisi ve tanıtım teklifleri; ana şirketin geçmişi nedeniyle aksi kanıtlanmadıkça profilleme varsayın.",
            ["librewolf"]="Varsayılan yok: telemetri, Pocket, Google hizmetleri ve veri toplama derleme sırasında kaldırıldı.",
            ["firefox"]="Telemetri, çökme raporları ve konuma dayalı öneriler; gizlilik korumalı reklam ölçümü (PPA) deneyleri.",
            ["opera"]="Gözatma verileri Opera sunucularında işlenir; ücretsiz VPN trafiği Opera altyapısından geçer.",
            ["whale"]="Naver hesap eşitleme, Naver sunucularına kullanım telemetrisi; kişiselleştirme Naver hizmetlerine bağlı.",
            ["kagi-orion"]="Sıfır telemetri iddiası; reklam profili yok; Apple'da iCloud ile, Windows'ta yerel eşitleme.",
            ["pale-moon"]="Telemetri düşük ama eski motorun kendisi daha büyük risk.",
            ["vivaldi"]="Profilleme yok; uçtan uca şifreli eşitleme; kullanım istatistikleri yalnızca siz kabul ederseniz.",
            ["tor-browser"]="Trafik 3 şifreli gönüllü relay üzerinden geçer; telemetri yok; kişisel hesaplara giriş yaparsanız anonimliğinizi bozarsınız.",
            ["zen"]="Telemetrisiz Firefox tabanlı; güncellemeler Mozilla altyapısı üzerinden.",
            ["edge"]="Tanı verileri, eşitleme açıkken gözatma geçmişi, kişiselleştirilmiş reklamlar için reklam kimliği.",
            ["falkon"]="Minimum telemetri; KDE entegrasyonu yalnızca bu hizmetleri kullanırsanız.",
            ["epic-browser"]="Telemetri yok iddiası ve izleyicileri agresif engeller; kapalı kod nedeniyle doğrulanamaz.",
            ["yandex"]="Yandex'e (Rusya) kapsamlı telemetri, arama, konum ve ses verisi; kişiselleştirilmiş reklamlar.",
            ["chrome"]="Geçmişi, aramaları, konumu ve sesi Google hesabınıza eşitler; varsayılan reklam kişiselleştirme.",
            ["brave"]="Tasarım gereği minimum: P3A gizlilik korumalı istatistikler (kapatılabilir), arama veya profil takibi yok.",
            ["brave-debloat"]="Ekstraları ve telemetriyi kapatır.",
            ["edge-debloat"]="Alışverişi, ekstraları ve telemetriyi kapatır.",
            ["comet"]="Gözatma bağlamı Perplexity AI tarafından işlenir; hesap gerekli; arama geçmişi Perplexity profilinize bağlı.",
            ["duckduckgo"]="Reklam profili yok; arama anonim günlük tutar; tarayıcı eşitleme şifreli.",
            ["chromium"]="Google eşitleme ve hizmetleri olmayan Chrome motoru; aramalar seçtiğiniz motora bağlı.",
            ["cachy-browser"]="Minimum belgelenmiş yamalı Chromium tabanlı; telemetri Google hizmetleri dışında upstream Chromium varsayılanları.",
        
    };
}
