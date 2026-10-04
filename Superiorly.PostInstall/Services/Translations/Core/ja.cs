namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> SectionTitles_ja = new()
    {
 ["home"]="ホーム", ["browsers"]="ブラウザ", ["tools"]="ツール", ["tweaking"]="チューニング", ["troubleshooting"]="トラブルシューティング" 
    };
    private static readonly Dictionary<string, string> SectionDescs_ja = new()
    {
 ["home"]="ツールボックスへようこそ", ["browsers"]="ブラウザ関連のツールと修正", ["tools"]="ポータブルツールのダウンロードと実行", ["tweaking"]="ドライバー、GPU、システムの調整。", ["troubleshooting"]="クイック切り替えとOS修正。" 
    };
    private static readonly Dictionary<string, string> TabTitles_ja = new()
    {
 ["mainstream"]="メインストリーム", ["privacy"]="プライバシー", ["forks"]="フォークとカスタム", ["software"]="ソフトウェア", ["store-downloader"]="Microsoft Store ダウンローダー", ["utilities"]="ユーティリティ", ["amd"]="AMD", ["nvidia"]="NVIDIA", ["registry"]="レジストリ調整", ["win32"]="Win32Priority", ["powerplans"]="電源プラン", ["connectivity"]="接続", ["devices"]="デバイス", ["security"]="セキュリティ", ["gaming"]="ゲーム", ["ai"]="人工知能", ["debloat"]="Debloat", ["system"]="システム" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Notifications_ja = new()
    {
 ["opened"]="開きました - 起動しました", ["installed"]="正常にインストールしました", ["failed"]="インストールに失敗しました", ["open_failed"]="開けませんでした", ["enabled"]="有効", ["disabled"]="無効", ["apply_failed"]="適用に失敗しました", ["applied"]="適用しました" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> Ui_ja = new()
    {

            ["settings"]="設定", ["language"]="言語", ["theme"]="テーマ", ["dark"]="ダーク", ["light"]="ライト", ["auto"]="自動", ["default_theme"]="デフォルトテーマ",
            ["style"]="スタイル", ["win10_style"]="Windows 10 スタイル", ["win11_style"]="Windows 11 スタイル", ["close"]="閉じる",
            ["search_placeholder"]="名前、URL、または ID で検索します。", ["store_no_results"]="結果が見つかりません。別の検索をお試しください。", ["search"]="検索", ["install"]="インストール",
            ["run"]="実行", ["download"]="ダウンロード", ["open"]="開く", ["apply"]="適用",
            ["check_updates"]="更新を確認します", ["update"]="Update", ["disclaimer"]="変更はお客様の責任において行ってください。",
            ["quantum_title"]="Quantum マップ", ["quantum_subtitle"]="有効な Win32PrioritySeparation の値一覧です。行をクリックして適用します。",
            ["open_quantum"]="Quantum マップを開きます", ["current_win32"]="現在の Win32PrioritySeparation",
            ["load_list"]="一覧を読み込みます", ["unload_list"]="一覧を閉じます", ["activate"]="有効にします", ["import"]="インポートします", ["export"]="エクスポートします",
            ["select_all"]="すべて選択します", ["unselect_all"]="選択を解除します", ["uninstall"]="アンインストールします", ["delete"]="削除します",
            ["restore_default"]="既定値に戻します", ["yes"]="はい", ["no"]="いいえ",
            ["searching_for"]="「{0}」を検索しています...", ["downloading"]="{0} をダウンロードしています...", ["starting"]="{0} を開始しています...",
            ["applying"]="{0} を適用しています...", ["installing"]="{0} をインストールしています...",             ["loading"]="{0} を読み込んでいます...",
            ["reading_plans"]="電源プランを読み取っています...", ["populating_list"]="一覧を作成しています...",
            ["apps_found"]="{0} 件のアプリが見つかりました", ["nothing_found"]="何も見つかりませんでした", ["loaded_items"]="{0} 件を読み込みました",
            ["list_unloaded"]="一覧を閉じました",
            ["exported"]="{0} をエクスポートしました",
            ["installed_n"]="{0} 件のアプリをインストールしました", ["install_failed"]="インストールに失敗しました",
            ["failed_admin"]="失敗しました - 管理者として実行するか再起動してください", ["failed"]="失敗しました",
            ["win32_set"]="Win32PrioritySeparation を {0} に設定しました",
        
    };
    private static readonly Dictionary<string, string> OptionLabels_ja = new()
    {
 ["run"]="実行", ["download"]="ダウンロード", ["apply"]="適用", ["enable"]="有効にする", ["disable"]="無効にする", ["search"]="検索", ["install"]="インストール", ["load list"]="一覧を読み込みます", ["uninstall"]="アンインストールします", ["activate"]="有効にします", ["delete"]="削除します", ["import .pow"]=".pow をインポートします", ["default"]="既定値", ["custom"]="カスタム", ["minimum"]="最小", ["disable mmcss"]="MMCSS を無効にします", ["bypass"]="バイパス", ["repeater"]="リピーター", ["realtime"]="リアルタイム", ["high"]="高", ["abovenormal"]="通常より上", ["normal"]="通常", ["belownormal"]="通常より下", ["enhanced"]="拡張", ["legacy"]="レガシー", ["disabled"]="無効", ["enabled"]="有効", ["alwayson"]="常にオン", ["alwaysoff"]="常にオフ", ["optin"]="オプトイン", ["optout"]="オプトアウト", ["open cru"]="CRU を開きます", ["coming soon"]="近日公開", ["safe fivem/minecraft services"]="FiveM/Minecraft セーフサービス", ["kernelos default"]="Superiorly 既定値" , ["telemetry"]="Telemetry"
    };
    private static readonly Dictionary<string, string> UiExtra_ja = new()
    {
["state_on"]="オン", ["state_off"]="オフ", 
            ["confirm_delete"]="削除の確認",
            ["confirm_enable"]="この変更を適用しますか?",
            ["delete_plans"]="{0} 件の電源プランを削除しますか？",
            ["cant_delete_active"]="使用中の電源プランは削除できません。先に別のプランに切り替えてください。",
            ["import_plan"]="電源プランのインポート", ["export_plan"]="電源プランのエクスポート",
            ["ratio"]="比率", ["long"]="ロング", ["short"]="ショート", ["fixed"]="固定", ["variable"]="可変", ["boost"]="ブースト", ["current"]="現在",
            ["needs_admin"]="この操作には管理者権限が必要です。",
            ["restart_driver"]="ディスプレイドライバーを再起動", ["reset_all"]="すべてリセット", ["download_cru"]="CRU をダウンロード",
            ["modify_quantum"]="Quantum を変更", ["quantum_length"]="Quantum 長", ["quantum_interval"]="Quantum 間隔",
            ["fix"]="固定", ["preview_hex"]="16進数プレビュー", ["preview_bits"]="ビットプレビュー",
            ["minimize"]="最小化します", ["maximize"]="最大化します", ["toggle_theme"]="ライト / ダークテーマを切り替えます",
            ["follow_theme"]="Windows テーマに従います", ["square"]="角ばったコーナー", ["rounded"]="丸いコーナー",
            ["join"]="参加する", ["follow"]="フォローする", ["visit"]="見る", ["copy_link"]="リンクをコピー", ["copied"]="コピー済み",
            ["no_profiles_found"]="プロ5ァイルが見つかりません。Nvidia Profilesフォルダに.nipファイルを配置してください。",
            ["confirm_disable"]="この保護を無効にしますか?",
            ["home_discord_desc"]="Superiorly Community",
            ["home_instagram_desc"]="@sebastianportella",
            ["home_github_desc"]="chiLL-Gekk0",
            ["security"]="セキュリティ: ", ["power_plan_filter"]="電源プラン",
            ["theme_changed"]="テーマを{0}に変更しました", ["style_changed"]="スタイルを{0}に変更しました",
            ["powerplan_custom"]="カスタム", ["powerplan_restore"]="公式を復元",
            ["update_available"]="更新 {0} があります", ["new_update"]="新しいアップデート：{0}", ["up_to_date"]="最新版です", ["update_check_failed"]="更新を確認できませんでした",
        
    };
    private static readonly Dictionary<string, string> TabDescs_ja = new()
    {
 ["mainstream"]="日常使いのブラウザ。", ["privacy"]="プライバシーと匿名性のためのブラウザ。", ["forks"]="ChromiumとFirefoxベースのコミュニティビルド。", ["utilities"]="システムとハードウェア診断のためのツール。", ["amd"]="ドライバー、クロック、電圧、レジストリ用のAMD GPUツール。", ["nvidia"]="クリーンインストール、プロファイル、P-State用のNVIDIAツール。", ["connectivity"]="Wi-Fi、Bluetooth、ホットスポットホップ制限の設定。", ["devices"]="プリンター、タスクマネージャー、テキスト入力の修正。", ["security"]="コア分離、ファイアウォール、UAC、ドライバーブロックリスト、メモリ保護。", ["gaming"]="XboxサービスとOpera GX。", ["ai"]="Chromium、WebKit、AIファーストのブラウジング。", ["debloat"]="ブラウザーのプライバシーポリシーとベンダーテレメトリスイッチ: Chrome、Edge、Firefox、Office。", ["system"]="Windows Updateドライバー、スタートメニュー、Intelパネルの修正。" , ["telemetry"]="テレメトリ、提案、広告、ベンダーデータ収集のスイッチ。"
    };
    private static readonly Dictionary<string, string> SectionTabDescs_ja = new()
    {
 ["browsers|gaming"]="CPU、RAM、ネットワーク制限内蔵のOpera GX。", ["tweaking|gaming"]="XboxサービスとFiveM/Minecraftセーフサービス。" 
    };
    private static readonly Dictionary<string, string> TabBannerTitles_ja = new()
    {
 ["mainstream"]="日常のブラウザ", ["privacy"]="匿名ブラウジング", ["forks"]="独立フォーク", ["utilities"]="システムユーティリティ", ["amd"]="Radeonツール", ["nvidia"]="GeForceツール", ["connectivity"]="ワイヤレス設定", ["devices"]="デバイス修正", ["security"]="システム保護", ["gaming"]="ゲームサービス", ["ai"]="AIブラウザ", ["debloat"]="ブラウザーデブロート", ["system"]="Windows修正" , ["telemetry"]="テレメトリ修正"
    };
    private static readonly Dictionary<string, string> SectionTabTitles_ja = new()
    {
 ["browsers|gaming"]="ゲーミングブラウザ", ["tweaking|gaming"]="ゲームサービス" , ["troubleshooting|telemetry"]="テレメトリ修正"
    };
}
