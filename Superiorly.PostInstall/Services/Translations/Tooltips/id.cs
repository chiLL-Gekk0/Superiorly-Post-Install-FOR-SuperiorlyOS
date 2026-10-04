namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_id = new()
    {

            ["arc"]="Pengembangan dibekukan (2025) saat perusahaan beralih ke browser AI Dia; CVE sebelumnya memungkinkan penyerang membajak sesi via ID pengguna; tim keamanan bertumbuh dari 1 menjadi 5.",
            ["operagx"]="Induk yang sama dengan Opera: Kunlun Tech Tiongkok memegang ~72%. Pembatas CPU/RAM yang terkenal sebagian besar kosmetik; tuduhan Hindenburg berlaku untuk grup.",
            ["mullvad"]="Tanpa skandal besar. Dikembangkan bersama Tor Project (2023); VPN Mullvad terkenal menolak permintaan akses polisi.",
            ["thorium"]="Build Chromium tak resmi oleh satu pengembang; dioptimalkan untuk CPU AVX2; tanpa jaminan reproducible-build, jadi Anda memercayai pengelola.",
            ["floorp"]="Proyek Jepang yang bertahun-tahun sumber tertutup meski memakai Firefox; membuka kodenya pada 2023. Tata kelola digerakkan komunitas tetapi kecil.",
            ["waterfox"]="Dijual ke perusahaan iklan System1 (2020); pendiri Alex Kontos membeli kembali independensinya (2023). Tanpa skandal sejak itu.",
            ["ungoogled"]="Tanpa skandal; imbalannya adalah pemeriksaan pembaruan manual dan kadang situs rusak akibat penghapusan agresif dependensi Google.",
            ["dia"]="Penerus Arc, beta undangan; AI membaca konten halaman dan riwayat chat untuk bertindak atas nama Anda; belum ada audit keamanan independen.",
            ["avast-secure"]="Induk Avast ketahuan menjual riwayat penjelajahan via anak perusahaan Jumpshot (ditutup 2020; penyelesaian FTC $16,5 jt 2024); browser didorong agresif oleh antivirus Avast.",
            ["librewolf"]="Tanpa skandal besar. Satu-satunya keluhan: patch keamanan bisa tertinggal beberapa hari dari rilis Firefox sementara komunitas membangun ulang.",
            ["firefox"]="Mozilla memperoleh sebagian besar pendapatan dari kesepakatan default Google; telemetri aktif secara default; ToS 2025 sempat menyiratkan lisensi data luas (dibatalkan setelah protes).",
            ["opera"]="Dimiliki ~72% oleh Kunlun Tech Tiongkok (pengajuan SEC). Hindenburg Research menuduh aplikasi fintech-nya mengenakan pinjaman APR 365-876%. VPN diaudit Deloitte (tanpa log).",
            ["whale"]="Dimiliki raksasa internet Korea Naver; tunduk pada hukum data Korea Selatan; layanan bilah sisi (terjemahan, belanja) menghubungi server Naver.",
            ["kagi-orion"]="Sumber tertutup; port Windows masih muda dan kasar. Model pencarian berbayar Kagi adalah bisnisnya — privasi sebagai produk, bukan pengawasan.",
            ["pale-moon"]="Mesin Goanna kuno kehilangan mitigasi keamanan Chromium/Firefox bertahun-tahun; situs sering rusak; proyek satu pengelola.",
            ["vivaldi"]="Menyertakan bookmark afiliasi dan memonetisasi pencarian default (afiliasi Google); UI sumber tertutup meski inti Chromium terbuka. Des 2024: diam-diam mengaktifkan skrip atribusi iklan pada mesin pencari mitra demi pendapatan. Perusahaan Norwegia, tanpa profiling.",
            ["tor-browser"]="Dipakai untuk menghindari sensor sekaligus pasar darknet (Silk Road); node keluar dapat melihat lalu lintas non-HTTPS; diblokir atau ditandai sebagian pemerintah dan situs.",
            ["zen"]="Proyek muda dengan tim kecil; belum ada audit keamanan independen. Rilis yang bergerak cepat bisa menimbulkan regresi.",
            ["edge"]="Mengirim ID perangkat unik meski telemetri nonaktif; iklan bilah sisi Bing agresif, saran bersponsor, dan perintah kembali yang persisten.",
            ["falkon"]="Patch keamanan QtWebEngine (inti Chromium) tertinggal dari hulu; tim KDE kecil; build Windows kurang teruji dibanding Linux.",
            ["epic-browser"]="Sumber tertutup meski mengklaim privasi: daftar blokir pelacak dan penanganan data tak dapat diaudit independen.",
            ["yandex"]="Yurisdiksi Rusia: hukum data memungkinkan akses negara (SORM); mode Turbo mem-proxy halaman melalui server Yandex; asisten Alice memproses suara di Rusia.",
            ["chrome"]="Kasus antimonopoli: DOJ memenangkan pemulihan (Sep 2025) — Google harus berbagi data pencarian dengan rival, tanpa kesepakatan default eksklusif. Gugatan pelacakan Incognito berakhir dengan penghapusan miliaran catatan. Privacy Sandbox menjaga profiling iklan di dalam.",
            ["brave"]="2020: otomatis menambahkan kode afiliasi ke URL bursa kripto (CEO meminta maaf). Donasi Prop-8 pendiri Brendan Eich kadang mencuat lagi. Selain itu rekam privasi kuat.",
            ["brave-debloat"]="Tampil sebagai dikelola oleh organisasi Anda.",
            ["edge-debloat"]="Tampil sebagai dikelola oleh organisasi Anda.",
            ["comet"]="Browser AI Perplexity: konten halaman dikirim ke model AI; Cloudflare menuduhnya melakukan scraping agresif (2025); penjelajahan agenik menimbulkan pertanyaan privasi baru.",
            ["duckduckgo"]="2022: browser-nya membiarkan pelacak Microsoft lolos akibat kesepakatan sindikasi Bing (diungkap peneliti Zach Edwards); ditambal Agustus 2022.",
            ["chromium"]="Tanpa pembaru otomatis pada build Windows: perbaikan keamanan bergantung pada siapa pun yang mengompilasi biner Anda (Hibbiki, dll.); sebagian API Google (sinkronisasi) dihapus.",
            ["cachy-browser"]="Build niche oleh komunitas CachyOS (Arch); memerlukan AVX2; permukaan peninjauan kecil, jadi lebih sedikit mata pada kode dibanding browser arus utama.",
        
    };
    private static readonly Dictionary<string, string> TooltipData_id = new()
    {

            ["arc"]="Sinkronisasi berbasis akun melalui server The Browser Company; fitur AI mengirim konten halaman ke model mereka.",
            ["operagx"]="Sama seperti Opera: data penjelajahan di server Opera; VPN gratis via infrastruktur Opera.",
            ["mullvad"]="Tidak ada: tanpa telemetri, tanpa pengenal, anti-fingerprinting aktif secara default.",
            ["thorium"]="Sama seperti Chromium minus beberapa layanan Google dan permintaan latar belakang.",
            ["floorp"]="Telemetri dinonaktifkan secara default; beberapa fitur menghubungi server proyek Jepang.",
            ["waterfox"]="Telemetri dihapus; monetisasi hanya via mesin pencari mitra.",
            ["ungoogled"]="Tanpa koneksi Google secara desain; tanpa telemetri; pencarian web bergantung pada mesin pilihan Anda.",
            ["dia"]="Konten halaman dan percakapan dikirim ke model AI The Browser Company; memerlukan akun.",
            ["avast-secure"]="Telemetri Avast dan penawaran promosi; mengingat rekam induknya, anggap profiling kecuali terbukti sebaliknya.",
            ["librewolf"]="Nol secara default: telemetri, Pocket, layanan Google, dan pengumpulan data dihapus saat build.",
            ["firefox"]="Telemetri, laporan crash, dan saran berbasis lokasi; eksperimen pengukuran iklan yang menjaga privasi (PPA).",
            ["opera"]="Data penjelajahan diproses di server Opera; VPN gratis merutekan lalu lintas melalui infrastruktur Opera.",
            ["whale"]="Sinkronisasi akun Naver, telemetri penggunaan ke server Naver; personalisasi terikat layanan Naver.",
            ["kagi-orion"]="Diklaim nol telemetri; tanpa profil iklan; sinkronisasi di Apple via iCloud, lokal di Windows.",
            ["pale-moon"]="Telemetri rendah, tetapi mesin yang kedaluwarsa sendiri adalah risiko yang lebih besar.",
            ["vivaldi"]="Tanpa profiling; sinkronisasi terenkripsi ujung ke ujung; statistik penggunaan hanya jika Anda ikut serta.",
            ["tor-browser"]="Lalu lintas melompat melalui 3 relai sukarelawan terenkripsi; tanpa telemetri; masuk ke akun pribadi merusak anonimitas Anda sendiri.",
            ["zen"]="Berbasis Firefox dengan telemetri nonaktif; pembaruan mengalir melalui infrastruktur Mozilla.",
            ["edge"]="Data diagnostik, riwayat penjelajahan saat sinkronisasi aktif, ID iklan untuk iklan personal.",
            ["falkon"]="Telemetri minimal; integrasi desktop KDE hanya jika Anda memakai layanan tersebut.",
            ["epic-browser"]="Mengklaim tanpa telemetri dan memblokir pelacak agresif; tak terverifikasi karena kode tertutup.",
            ["yandex"]="Telemetri ekstensif, data pencarian, lokasi, dan suara ke Yandex (Rusia); iklan personal.",
            ["chrome"]="Menyinkronkan riwayat, pencarian, lokasi, dan suara ke akun Google Anda; personalisasi iklan secara default.",
            ["brave"]="Minimal secara desain: statistik P3A yang menjaga privasi (dapat dinonaktifkan), tanpa pelacakan pencarian atau profil.",
            ["brave-debloat"]="Mematikan fitur tambahan dan telemetri.",
            ["edge-debloat"]="Mematikan belanja, fitur tambahan, dan telemetri.",
            ["comet"]="Konteks penjelajahan diproses oleh AI Perplexity; memerlukan akun; riwayat pencarian terikat profil Perplexity Anda.",
            ["duckduckgo"]="Tanpa profil iklan; pencarian menyimpan log anonim; sinkronisasi browser terenkripsi.",
            ["chromium"]="Mesin Chrome tanpa sinkronisasi dan layanan Google; pencarian web bergantung pada mesin yang Anda pilih.",
            ["cachy-browser"]="Berbasis Chromium dengan patch terdokumentasi minimal; telemetri mengikuti default Chromium hulu minus layanan Google.",
        
    };
}
