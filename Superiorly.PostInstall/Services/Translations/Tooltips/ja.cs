namespace Superiorly.PostInstall.Services;

public static partial class TranslationService
{
    private static readonly Dictionary<string, string> TooltipControversy_ja = new()
    {

            ["arc"]="Dia AI ブラウザへの転換により開発凍結（2025年）。過去の CVE ではユーザー ID でセッションを乗っ取られ、安全チームは1名から5名に拡大。",
            ["operagx"]="Opera と同じ親会社で中国 Kunlun Tech が約72%保有。有名な CPU/RAM リミッタはほぼ装飾的で、Hindenburg の疑惑はグループ全体に及びます。",
            ["mullvad"]="大きな不祥事なし。Tor Project と共同開発（2023年）。Mullvad VPN は警察のアクセス要求を拒否したことで有名です。",
            ["thorium"]="1人の開発者による非公式 Chromium ビルド。AVX2 CPU 向けに最適化。再現可能ビルドの保証がなく、メンテナへの信頼が前提です。",
            ["floorp"]="Firefox 使用にもかかわらず長年クローズドソースだった日本のプロジェクト。2023年にオープン化。コミュニティ主導ですが小規模です。",
            ["waterfox"]="広告企業 System1 に売却（2020年）後、創設者 Alex Kontos が独立を買い戻し（2023年）。以降不祥事なし。",
            ["ungoogled"]="不祥事なし。その代わり更新確認は手動で、Google 依存の積極除去によりサイトが壊れる場合があります。",
            ["dia"]="Arc の後継で招待制ベータ。AI がページ内容とチャット履歴を読み取り代行します。独立した監査はまだありません。",
            ["avast-secure"]="親会社 Avast は子会社 Jumpshot 経由で閲覧履歴を販売（2020年閉鎖、2024年に FTC と1650万ドルで和解）。Avast ウイルス対策が強く推奨しています。",
            ["librewolf"]="大きな不祥事なし。唯一の不満は、コミュニティ再ビルドの間 Firefox リリースより数日遅れる場合があることです。",
            ["firefox"]="Mozilla の収益の大半は Google 既定契約由来。テレメトリは既定でオン。2025年の利用規約は一時広範なデータ利用を示唆し（批判後に撤回）。",
            ["opera"]="中国 Kunlun Tech が約72%保有（SEC 届出）。Hindenburg は金融アプリが年利365～876%の貸付と主張。VPN は Deloitte 監査済み（ノーログ）。",
            ["whale"]="韓国ネット大手 Naver 所有で韓国データ法の対象。サイドバー機能（翻訳、買い物）は Naver に接続します。",
            ["kagi-orion"]="クローズドソースで Windows 版は若く荒削り。Kagi の有料検索モデルが事業そのもので、監視ではなく製品としてのプライバシーです。",
            ["pale-moon"]="古い Goanna エンジンは長年の Chromium/Firefox の緩和策を欠き、サイト破損が多発。単独メンテナのプロジェクトです。",
            ["vivaldi"]="アフィリエイトブックマーク同梱で既定検索を収益化（Google アフィリエイト）。Chromium コアはオープンでも UI は非公開。2024年12月には収益目的で提携検索エンジンに広告アトリビューションを密かに有効化。ノルウェー企業でプロファイリングなし。",
            ["tor-browser"]="検閲回避にもダークネット市場にも使用。出口ノードは非 HTTPS 通信を閲覧可能。一部の政府やサイトで遮断・標識されます。",
            ["zen"]="少人数の若いプロジェクトで独立監査はまだなし。速いリリースにより不具合が混入する場合があります。",
            ["edge"]="テレメトリをオフにしても一意のデバイス ID を送信。Bing サイドバー広告、スポンサー提案、執拗な切戻し表示が積極的です。",
            ["falkon"]="QtWebEngine（Chromium コア）の修正は上流より遅延。小規模 KDE チームで、Windows ビルドは Linux 版より枯れていません。",
            ["epic-browser"]="プライバシー主張にもかかわらずクローズドソースで、トラッカーリストやデータ取扱いを独立監査できません。",
            ["yandex"]="ロシア管轄で法令により国家アクセスが可能（SORM）。Turbo モードは Yandex 経由でプロキシし、Alice はロシアで音声処理します。",
            ["chrome"]="独禁法訴訟で司法省が救済を獲得（2025年9月）。Google は検索データ共有と独占的既定契約の禁止を義務付け。シークレット追跡訴訟は数十億件の削除で決着。Privacy Sandbox は広告プロファイルを社内保持します。",
            ["brave"]="2020年に暗号資産所 URL へアフィリエイトを自動付与（CEO が謝罪）。創設者 Brendan Eich の過去の献金が時折蒸し返されます。その他は堅実な実績です。",
            ["brave-debloat"]="組織に管理されていると表示。Brave 1.82+が必要（Playlistは1.84+）。",
            ["edge-debloat"]="組織に管理されていると表示。新規インストールのみ有効。",
            ["comet"]="Perplexity の AI ブラウザでページ内容は AI モデルへ送信。Cloudflare は積極的スクレイピングと非難（2025年）。エージェント閲覧は新たな懸念を提起します。",
            ["duckduckgo"]="2022年に Bing 配信契約のため Microsoft トラッカーを通過させ、研究者 Zach Edwards が暴露。2022年8月に修正済み。",
            ["chromium"]="Windows ビルドに自動更新なし。修正はバイナリのコンパイル者次第で、一部 Google API（同期）は除去済み。",
            ["cachy-browser"]="CachyOS（Arch）コミュニティのニッチビルドで AVX2 必須。レビュー層が薄く、大手より目が届きにくいです。",
        
    };
    private static readonly Dictionary<string, string> TooltipData_ja = new()
    {

            ["arc"]="The Browser Company サーバ経由のアカウント同期。AI 機能はページ内容をモデルへ送信します。",
            ["operagx"]="Opera と同様。閲覧データは Opera サーバ上で処理され、無料 VPN は Opera 基盤経由です。",
            ["mullvad"]="なし。テレメトリも識別子もなく、アンチフィンガープリントは既定でオンです。",
            ["thorium"]="複数の Google サービスとバックグラウンド要求を除いた Chromium と同様です。",
            ["floorp"]="テレメトリは既定で無効。一部機能は日本のプロジェクトサーバに接続します。",
            ["waterfox"]="テレメトリを除去。収益は提携検索エンジンのみです。",
            ["ungoogled"]="設計上 Google 接続なし。テレメトリなし。Web 検索は選択したエンジン次第です。",
            ["dia"]="ページ内容と会話は The Browser Company の AI モデルへ送信。アカウント必須です。",
            ["avast-secure"]="Avast テレメトリと販促。親会社の実績から、反証なき限りプロファイリングを想定してください。",
            ["librewolf"]="既定でなし。テレメトリ、Pocket、Google サービス、データ収集はビルド時に除去済みです。",
            ["firefox"]="テレメトリ、クラッシュ報告、位置ベースの提案。プライバシー保護広告測定（PPA）の実験あり。",
            ["opera"]="閲覧データは Opera サーバで処理。無料 VPN は Opera 基盤を経由します。",
            ["whale"]="Naver アカウント同期、使用状況テレメトリは Naver へ。パーソナライズは Naver 紐付けです。",
            ["kagi-orion"]="ゼロテレメトリを主張。広告プロファイルなし。Apple は iCloud 同期、Windows はローカルです。",
            ["pale-moon"]="テレメトリは少ないですが、旧式エンジン自体がより大きなリスクです。",
            ["vivaldi"]="プロファイリングなし。エンドツーエンド暗号化同期。使用統計はオプトイン時のみです。",
            ["tor-browser"]="3 つの暗号化ボランティアリレーを経由。テレメトリなし。個人アカウントにログインすると匿名性が損なわれます。",
            ["zen"]="テレメトリを切った Firefox ベース。更新は Mozilla 基盤経由です。",
            ["edge"]="診断データ、同期オン時の閲覧履歴、パーソナライズ広告用 ID。",
            ["falkon"]="テレメトリは最小限。KDE 統合は関連サービス利用時のみです。",
            ["epic-browser"]="テレメトリなしと積極的ブロックを主張しますが、クローズドのため検証不可です。",
            ["yandex"]="Yandex（ロシア）へ広範なテレメトリ、検索、位置、音声データ。パーソナライズ広告あり。",
            ["chrome"]="履歴、検索、位置、音声を Google アカウントへ同期。広告パーソナライズは既定でオンです。",
            ["brave"]="設計上最小限。P3A プライバシー保護統計（無効化可）で、検索やプロファイル追跡なし。",
            ["brave-debloat"]="12ポリシー：Rewards、Wallet、VPN、Leo、Tor、News、Talk、Speedreader、Wayback、Playlist、P3A、統計pingを無効化。",
            ["edge-debloat"]="14ポリシー：ショッピング、サイドバー、Rewards、ニュース、ウィジェット、テレメトリを無効化。",
            ["comet"]="閲覧コンテキストは Perplexity AI が処理。アカウント必須で、検索履歴はプロファイルに紐付きます。",
            ["duckduckgo"]="広告プロファイルなし。検索は匿名ログを保持。ブラウザ同期は暗号化済みです。",
            ["chromium"]="Google 同期・サービスなしの Chrome エンジン。Web 検索は選択したエンジン次第です。",
            ["cachy-browser"]="文書化パッチ最小限の Chromium ベース。テレメトリは Google サービスを除く上流既定に従います。",
        
    };
}
