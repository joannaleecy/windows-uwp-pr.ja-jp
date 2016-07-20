---
author: joannaleecy
title: "UWP ゲーム用のクラウド サービスの使用"
description: "UWP ゲーム用のバックエンドとしてクラウドを実装することについて説明します。"
ms.assetid: 1a7088e0-0d7b-11e6-8e05-0002a5d5c51b
translationtype: Human Translation
ms.sourcegitcommit: 3de603aec1dd4d4e716acbbb3daa52a306dfa403
ms.openlocfilehash: 8bf42e9c2c2e074240eb8e7b94efdfbca65cc7f9

---
#  UWP ゲーム用のクラウド サービスの使用

Windows 10 のユニバーサル Windows プラットフォーム (UWP) では、Microsoft デバイス間でのゲームの開発のために使用できる一連の API が用意されています。 複数のプラットフォームやデバイスを対象としてゲームを開発する場合、クラウド バックエンドを使って、需要に応じてゲームをスケーリングすることができます。

##  クラウド コンピューティングとは

クラウド コンピューティングでは、需要に応じてインターネット経由で IT リソースやアプリケーションを利用することにより、デバイスのデータを保存および処理します。 _クラウド_という用語は、不特定の場所からアクセスできる外部の膨大なリソース (ローカル リソースではない) の可用性を表すメタファーです。
クラウド コンピューティングの原則により、リソースやソフトウェアを利用するための新しい方法が提供されます。 ユーザーは、完全な製品やリソースの料金を事前に支払う必要がなくなり、代わりに、プラットフォーム、ソフトウェア、リソースをサービスとして利用できます。 クラウド プロバイダーは通常、使用量やサービス プランに基づいて顧客に料金を請求します。

##  クラウド サービスを使う理由

ゲームでクラウド サービスを使う利点の 1 つは、物理サーバー ハードウェアに事前に投資する必要がなく、後で使用量やサービス プランに従って支払うだけで済むことです。 これは、新しいゲーム タイトルの開発に伴うリスクを管理するための 1 つの方法です。 

もう 1 つの利点として、膨大なクラウド リソースを活用してゲームのスケーラビリティ (同時接続プレイヤー数の急激な増加、負荷の高いリアルタイム ゲームの計算やデータの要件) を実現できることが挙げられます。 これにより、ゲームのパフォーマンスが常に安定します。 さらに、クラウド リソースには、世界中のどこからでも、任意のプラットフォームで実行されている任意のデバイスからアクセスできます。つまり、全世界のすべてのユーザーにゲームを提供できることを意味します。

魅力的なゲームプレイ エクスペリエンスをプレイヤーに提供することが重要です。 クラウドで実行されているゲーム サーバーはクライアント側の更新プログラムに依存しないため、ゲーム全体の制御された安全な環境を実現できます。   また、クライアントを信頼したり、サーバー側のゲーム ロジックを使用したりしないため、クラウドを通じてゲームプレイの整合性を実現できます。 サービス間の接続を構成して、さらに統合されたゲーム エクスペリエンスを実現することもできます。たとえば、ゲーム内購入をさまざまな支払い方法にリンクする、異なるゲーム ネットワークを接続する、ゲーム内の更新を Facebook や Twitter などの人気のソーシャル メディア ポータルで共有することが可能になります。 

専用のクラウド サーバーを使用することによって、大規模で永続的なゲーム ワールドの作成、ゲーマー コミュニティの構築、時間の経過に伴うゲーマー データ収集と分析によるゲームプレイの向上、ゲームの収益化設計モデルの最適化を行うこともできます。

さらに、非同期のマルチプレイヤーのしくみを使うソーシャル ゲームなど、負荷の高いゲーム データ管理機能を必要とするゲームを、クラウド サービスを使って実装できます。

##  ゲーム開発企業によるクラウド テクノロジの使用方法

さまざまな開発者がどのようにゲームにクラウド ソリューションを実装しているかについて説明します。

<table>
    <colgroup>
    <col width="10%" />
    <col width="30%" />
    <col width="30%" />
    <col width="30%" />
    </colgroup>
    <tr class="header">
        <th>開発者</th>
        <th>説明</th>
        <th>主なゲームのシナリオ</th>
        <th>詳細情報</th>
    </tr>
    <tr>
        <td>[343 Industries](https://www.halowaypoint.com/)</td>
        <td>
              _Halo 5: Guardians_ では、Microsoft Azure DocumentDB を使うことにより、ソーシャル ゲームプレイ プラットフォームとして [Halo: Spartan Companies](https://www.halowaypoint.com/spartan-companies) を実装しました。Microsoft Azure DocumentDB が選択された理由は、自動インデックス作成機能による速度と柔軟性です。</td>
        <td>
            <ul>
                <li>マルチ プレイヤー ゲームプレイでグループの作成/管理を処理するスケーラブルなデータ層 <li>ゲームとソーシャル メディアの統合 <li>複数の属性を使った、リアルタイムのデータ クエリ <li>ゲームプレイの達成度や統計情報の同期 </ul>
        </td>
        <td>
            <ul>
                <li>[Azure DocumentDB を使って実装されるソーシャル ゲームプレイ](https://azure.microsoft.com/blog/how-halo-5-guardians-implemented-social-gameplay-using-azure-documentdb/)</td>
            </ul>
    </tr>
    <tr>
        <td>[Illyriad Games](http://web.ageofascent.com/)</td>
        <td>Illyriad Games は _Age of Ascent_ を開発した企業です。このゲームは、壮大な 3D 空間を舞台にした大規模マルチプレイヤー オンライン (MMO) ゲームであり、最新のブラウザーを備えたデバイスでプレイできます。 したがって、このゲームは、プラグインなしで、PC、ノート PC、スマートフォン、その他のモバイル デバイスでプレイできます。 このゲームでは、ASP.NET Core、HTML5、WebGL、Microsoft Azure が使用されています。</td>
        <td>
            <ul>
                <li>クロスプラットフォーム、ブラウザー ベースのゲーム <li>1 つの大規模かつ永続的でオープンな世界 <li>負荷の高いリアルタイムのゲームプレイの計算を処理 <li>プレイヤー数に応じたスケーリング </ul>
        </td>
        <td>
            <ul>
                <li>[Azure Service Fabric を使用したマイクロサービスとしてのゲーム コンポーネントの管理 (ビデオ)](https://channel9.msdn.com/Events/Build/2016/KEY02#time=57m20s)  
                <li>[Age of Ascent 開発者のインタビュー (ビデオ)](https://channel9.msdn.com/Shows/Azure-Friday/Age-of-Ascent-from-Illyriad-Powered-by-Azure-Service-Fabric-and-ASPNET)
            </ul>
        </td>
    </tr>
    <tr>
        <td>[Next Games](http://www.nextgames.com/)</td>
        <td>Next Games は、AMC のオリジナル シリーズをベースにしたビデオ ゲーム _The Walking Dead: No Man's Land_ の開発元です。 Walking Dead ゲームでは、バックエンドとして Azure を使用しています。 公開後の最初の週末にダウンロード数は 1,000,000 回に達し、最初の 1 週間で、このゲームは、米国 App Store で iPhone と iPad の無料アプリ第 1 位、12 か国で無料アプリ第 1 位、13 か国で無料ゲーム第 1 に成りました。
        </td>
        <td>
            <ul>
                <li>クロスプラットフォーム <li>ターン制のマルチプレイヤー <li>弾力性のあるパフォーマンスのスケーリング </ul>
        </td>
        <td>
            <ul>
                <li>[Next Games の CTO、Kalle Hiitola 氏へのインタビュー (ビデオ)](https://channel9.msdn.com/Blogs/AzureDocumentDB/azure-documentdb-walking-dead)
                <li>[Walking Dead では、開発サイクルの高速化と、より魅力的なゲームプレイのために DocumentDB を使用](https://azure.microsoft.com/blog/the-walking-dead-no-mans-land-game-soars-to-1-with-azure-documentdb/)
            </ul>
    </tr>
    </td>
        <td>[Pixel Squad](http://www.crimecoast.com/)</td>
        <td>Pixel Squad では、Unity ゲーム エンジンと Azure を使って _Crime Coast_ を開発しました。 
              _Crime Coast_ は、Android、iOS、Windows プラットフォームでプレイできるソーシャル戦略ゲームです。 このゲームでは、Azure BLOB ストレージ、Managed Azure Redis Cache、負荷分散された IIS VM アレイ、Microsoft 通知ハブが使用されています。 同社のスケーリングの管理方法や、同時接続プレイヤー数が 5,000 人にもなるプレイヤーの急増の処理方法を参考にしてください。
        </td>
        <td>
            <ul>
                <li>クロスプラットフォーム <li>マルチプレイヤー オンライン ゲーム <li>プレイヤー数に応じたスケーリング </ul>
        </td>
        <td>
            <ul>
                <li>[Crime Coast MMO ゲームでの Azure Cloud Services の使用方法](https://channel9.msdn.com/Blogs/The-Game-Blog/BizSpark-Interview-with-Pixel-Squad-How-the-used-Azure-Cloud-Services-to-make-an-MMO-with-a-3-man-te)
            </ul>
        </td>
    </tr> 
</table>

    
### その他のリンク

* [Hitcents、Game Troopers、InnoSpark の秘密のソースとしての Azure](http://news.microsoft.com/features/game-developers-use-microsoft-azure-as-secret-sauce-for-scale-and-growth-2/)
* [Bizspark プログラムで Azure を使用しているゲーム関連新興企業](https://blogs.technet.microsoft.com/bizspark_featured_startups/2015/09/25/azure-open-for-gaming-startups/)


## クラウド バックエンドを設計する方法

プロデューサーやゲーム設計者は、ゲームの特徴やゲームに必要な機能について話し合いますが、ゲームのインフラストラクチャをどのように設計するかについての検討から始めることをお勧めします。 さまざまなデバイスや複数の主要プラットフォームを対象にゲームを開発する場合、Azure Cloud をゲームのバックエンドとして使用できます。

### ステップ バイ ステップの学習ガイド

* [ビルド 2016 Codelabs: Microsoft Azure App Service と Microsoft SQL Azure バックエンドを使ってゲームのスコアを保存する](https://github.com/Microsoft-Build-2016/CodeLabs-GameDev-6-Azure)
* [ゲームのモバイル エンゲージメント戦略の設計](https://azure.microsoft.com/documentation/articles/mobile-engagement-gaming-scenario/)
* [Unity の iOS 展開向けの Azure Mobile Engagement の使用](https://azure.microsoft.com/documentation/articles/mobile-engagement-unity-ios-get-started/)

### IaaS、PaaS、SaaS について

まず、ゲームに最適なサービスのレベルについて検討する必要があります。 次の 3 つのサービスの相違点を把握することにより、バックエンドを構築に必要なアプローチを決定できます。

* [サービスとしてのインフラストラクチャ (IaaS)](https://azure.microsoft.com/overview/what-is-iaas/)

    サービスとしてのインフラストラクチャ (IaaS) は、インターネット経由でプロビジョニングおよび管理される、インスタント コンピューティング インフラストラクチャです。 需要に応じてすばやくスケールアップおよびスケールダウンできるように、多くのコンピューターが用意されている可能性を想像してみてください。 IaaS によって、自社で物理サーバーやその他のデータ センターのインフラストラクチャを購入および管理するためのコストや面倒を避けることができます。

* [サービスとしてのプラットフォーム (PaaS)](https://azure.microsoft.com/overview/what-is-paas/)

    サービスとしてプラットフォーム (PaaS) は IaaS と同様ですが、サーバー、ストレージ、ネットワークなどのインフラストラクチャの管理も含まれています。 物理サーバーやデータ センターのインフラストラクチャを購入しなくてもよいことに加えて、ソフトウェア ライセンス、基盤となるアプリケーション インフラストラクチャ、ミドルウェア、開発ツール、その他のリソースを購入して管理する必要もありません。

* サービスとしてのソフトウェア (SaaS)

    サービスとしてのソフトウェアは、通常、既に構築済みであり、既存のクラウド プラットフォームでホストされているアプリケーションです。 それらのサービスでゲームの実行をより簡単に開始できるように設計されています。


### Azure を使ったゲーム インフラストラクチャの設計

Azure のクラウド サービスをゲームに使用するためのいくつかの方法を以下に示します。 Azure は、Windows や Linux、および Ruby、Python、Java、PHP などのオープン ソース テクノロジと連携して動作します。 詳しくは、[Azure クラウドに関するページ](https://azure.microsoft.com)をご覧ください。

| 要件                 | アクティビティのシナリオ                            | 提供されるサービス                      | サービスの機能                               |
|-----------------------------------|-----------------------------------------------|---------------------------------------|----------------------------------------------------|
| クラウドでのドメインのホスティング     | 効率的に DNS クエリに応答する            | [Azure DNS](https://azure.microsoft.com/services/dns/) | 高パフォーマンスと高可用性を備えたドメインのホスティング  |
| サインイン、本人確認      | ゲーマーがサインインし、ゲーマーの ID が認証される  | [Azure Active Directory](https://azure.microsoft.com/services/active-directory/) | 多要素認証を備えた、あらゆるクラウドとオンプレミス Web アプリへのシングル サインオン            |
| サービスとしてのインフラストラクチャ モデル (IaaS) を使用したゲーム      | ゲームがクラウド内の仮想マシンでホストされる       | [Azure VM](https://azure.microsoft.com/services/virtual-machines/) | 組み込みの仮想ネットワークと負荷分散の機能や、オンプレミス システムとのハイブリッド整合性機能を備えたゲーム サーバーとして、1 から数千台の仮想マシンのインスタンスにスケーリング           |
| サービスとしてのプラットフォーム モデル (PaaS) を使用した Web ゲームやモバイル ゲーム            | ゲームが管理対象のプラットフォームでホストされる                | [Azure App Service](https://azure.microsoft.com/services/app-service/) | Web サイトやモバイル ゲーム用の PaaS (つまり Azure VMs とミドルウェア/開発ツール/BI/DB 管理)   |
| ゲーム データ用のクラウド ストレージ       | 最新のゲーム データがクラウドに格納され、クライアント デバイスに送信される | [Azure Blob Storage](https://azure.microsoft.com/services/storage/blobs/)| 格納できるファイルの種類に制限はない。画像、オーディオ、ビデオなどの大量の構造化されていないデータのオブジェクト ストレージ  |
| 一時的なデータ ストレージ テーブル| ゲームのトランザクション (ゲームの状態の変化) が一時的にテーブルに格納される | [Azure Table Storage](https://azure.microsoft.com/services/storage/tables/)| ゲーム データは、ゲームでの必要性に応じて柔軟なスキーマで格納できる |
| ゲームのトランザクションと要求のキュー| ゲームのトランザクションがキューの形式で処理される | [Azure Queue Storage](https://azure.microsoft.com/services/storage/queues/)| キューが予期しないトラフィックのバーストを吸収し、ゲーム中に要求が急激に増加してもサーバーがパンク状態になることを防止できる   |
| スケーラブルなリレーショナル ゲーム データベース| データベースへのゲーム内のトランザクションなど、リレーショナル データの構造化されたストレージ | [Azure SQL Database](https://azure.microsoft.com/services/sql-database/)| サービスとしての SQL データベース ([VM 上の SQL との比較](https://azure.microsoft.com/documentation/articles/data-management-azure-sql-database-and-sql-server-iaas/))  |
| スケーラブルで分散型の待機時間が短いゲーム データベース| 柔軟なスキーマによる、ゲーム データやプレイヤー データの高速の読み取り、書き込み、照会 | [Azure DocumentDB](https://azure.microsoft.com/services/documentdb/)| 待機時間の短い、サービスとしての NoSQL ドキュメント データベース   |
| 独自のデータ センターと Azure サービスを使用する | ゲームは独自のデータ センターから取得され、クライアント デバイスに送信される | [Azure Stack](https://azure.microsoft.com/overview/azure-stack/) | 組織で独自のデータ センターからの Azure サービスを提供することで、より多くのことを実現できる  |
| 大量のデータ チャンクの転送| Azure CDN により、ゲームの画像、オーディオ、ビデオなどの大きなファイルを、ユーザーに最も近いコンテンツ配信ネットワーク (CDN) の POP の場所から送信できる  | [Azure Content Delivery Network](https://azure.microsoft.com/services/cdn/) | Azure CDN は、集中管理された大規模なノードの最新ネットワーク トポロジをベースに構築されており、突然のトラフィック スパイクや大きな負荷を処理することにより処理速度と可用性が大幅に向上し、ユーザー エクスペリエンスの向上につながる  |
| 短い待機時間               | より細かい制御とデータの分離の保証により、高速でスケーラブルなゲームを構築するためのキャッシュを実行する。ゲームのマッチメイキング機能の向上にも利用できる | [Azure Redis Cache](https://azure.microsoft.com/services/cache/) | 高速でスケーラブルな Azure アプリケーションを実現するための高スループットで、一貫性のある低待機時間のデータ アクセス  |
| 高スケーラビリティ、低待機時間 | 待機時間の短い読み取りと書き込みによりゲーム ユーザー数の変動を処理する | [Azure Service Fabric](https://azure.microsoft.com/services/service-fabric/) | 複雑で待機時間が短く、データを多用するシナリオを実現し、一度により多くのユーザーを処理できるように拡張できる。 Service Fabric により、ステートレス アプリケーションで必要な、独立したストアやキャッシュを作成することなくゲームを構築できる |
| デバイスから 1 秒あたり数百万件のイベントを収集する機能                         | デバイスから 1 秒あたり数百万件のイベントをログに記録する | [Azure イベント ハブ](https://azure.microsoft.com/services/event-hubs/) | ゲーム、Web サイト、アプリ、デバイスからのクラウド規模の利用統計情報の取り込み  |
| リアルタイムのゲーム データの処理  | ゲームプレイを向上させるためにゲーム データのリアルタイム分析を実行する| [Azure Stream Analytics](https://azure.microsoft.com/services/stream-analytics/) | クラウドでのリアルタイムのストリーム処理  |
| 予測的なゲームプレイの開発         | ゲーマーのデータに基づいてカスタマイズされた動的なゲームプレイを作成する  | [Azure Machine Learning](https://azure.microsoft.com/services/machine-learning/) | 完全に管理されているクラウド サービスにより、簡単に予測分析ソリューションを構築、展開、共有できる  |
| ゲーム データの収集と分析| リレーショナル データベースと非リレーショナル データベースからのデータの大規模な並列処理 | [Azure Data Warehouse](https://azure.microsoft.com/services/sql-data-warehouse/)| エンタープライズ クラスの機能を備えたサービスとしての柔軟なデータ ウェアハウス   |
| 使用と顧客維持を促進するマーケティング キャンペーンの作成  | データ分析に基づいて対象となるプレイヤーにプッシュ通知を送信し、特定のゲーム操作に対する関心を引き出して利用を促進する | [Mobile engagement](https://azure.microsoft.com/services/mobile-engagement/) |  すべての主要なプラットフォーム (iOS、Android、Windows、Windows Phone) でのゲームプレイ時間とユーザー維持率を向上させる |


##  新興企業と開発者向けのリソース

* [Microsoft BizSpark](https://www.microsoft.com/bizspark/)

    Microsoft BizSpark は、Azure クラウド サービス、ソフトウェア、サポートを無料で利用できるようにすることで新興企業を支援するグローバル プログラムです。 BizSpark メンバーには、5 つの Visual Studio Enterprise with MSDN サブスクリプションと、それぞれ月額 150 ドルの Azure クレジットが付与されます。 5 人の開発者で合計 1 か月あたり 750 ドル相当の Azure サービスを利用できます。 BizSpark を利用できるのは、株式非公開で、設立から 5 年以内、年間収益が 100 万ドル未満の企業です。 マイクロソフトでは、新興企業の成功を支援することで、より価値のある長期的なパートナーシップを構築できると考えています。
    
* [ID@Xbox](http://www.xbox.com/Developers/id)

    マルチプレイヤーのゲームプレイ、クロスプラットフォームのマッチメイ キング、ゲーマースコア、達成度、ランキングなどの Xbox Live の機能を Windows 10 ゲームにも追加する場合は、ID@Xbox にサインアップして、創造性を発揮し、成功を最大限にするために必要なツールを入手してください。 ID@Xbox への登録を申し込む前に、[Windows デベロッパー センター](https://developer.microsoft.com/windows/programs/join)で開発者アカウントを登録してください。

## ゲームのバックエンド向けのサービスとしてのソフトウェア

主要なクラウド サービス プロバイダーに基づいてゲーム用のクラウド バックエンドを提供している企業の一部を紹介します。

* [GameSparks](http://www.gamesparks.com/)

    GameSparks はゲーム開発者向けのクラウド ベースの開発プラットフォームで、開発者はゲームのサーバー側をすべて構築できます。

* [Photon エンジン](https://www.photonengine.com/en/Photon)

    Photon は、ゲーム用の独立系ネットワーク エンジンおよびマルチプレイヤー プラットフォームです。 サービスとしてのソフトウェア (SaaS) を提供する Photon Cloud を提供し、それ自体は完全に管理されたサービスです。 ホストされている間、開発者は完全にアプリケーション クライアントに集中することができます。サーバーの運用とスケーリングはすべて、Exit Games によって行われます。

* [Playfab](https://playfab.com/)

    Playfab は、シンプルかつ迅速に、世界規模のライブ ゲーム管理とバックエンド テクノロジを、モバイル、PC、コンソールのゲームにもたらします。

## 関連リンク

* [Windows 10 ゲーム開発ガイド](https://msdn.microsoft.com/windows/uwp/gaming/e2e)
* [Microsoft Azure](https://azure.microsoft.com/)
* [Microsoft BizSpark](https://www.microsoft.com/bizspark/)
* [ID@Xbox](http://www.xbox.com/Developers/id)


 

 



<!--HONumber=Jul16_HO2-->


