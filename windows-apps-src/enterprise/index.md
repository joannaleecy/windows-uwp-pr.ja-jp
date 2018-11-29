---
ms.assetid: 4b0c86d3-f05b-450b-bf9c-6ab4d3f07d31
description: このロードマップは、windows 10 とユニバーサル Windows プラットフォーム (UWP) アプリの主要なエンタープライズ機能の概要を示します。
title: Enterprise
ms.date: 08/30/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6cce98591cdaa78a887d7a5fb495e999a4ffc453
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8194385"
---
# <a name="enterprise"></a>Enterprise

この記事では、Windows 10 のアプリにユニバーサル Windows プラットフォーム (UWP) によって提供される主要なエンタープライズ機能の概要を示します。

## <a name="whats-new-and-recent-for-enterprise-applications"></a>新機能および最近のエンタープライズ アプリケーション

> [!div class="checklist"]
> * [Windows Template Studio](#template-studio)
> * [コントロールをデスクトップ スタイルの Ui を作成するには](#desktop-style-UI)
> * [エンタープライズ シナリオをサポートするコントロール](#enterprise)
> * [Windows UI ライブラリ](#UI-library)
> * [デスクトップ アプリケーションの UWP コントロール](#xaml-islands)
> * [.NET Standard 2.0](#standard)
> * [SQL Server の接続](#sql-server)
> * [MSIX 展開](#MSIX)

これらの機能の詳細のいくつか示しますビデオ、[迅速に構築 LOB アプリケーション](https://channel9.msdn.com/Events/Build/2018/BRK3502)を参照してください。

<a id="template-studio" />

### <a name="windows-template-studio"></a>Windows Template Studio

Windows Template Studio は、ウィザード ベースのエクスペリエンスを使用して、新しいユニバーサル Windows プラットフォーム (UWP) アプリの作成を加速する Visual Studio 2017 拡張です。 結果として得られる UWP プロジェクトでは、実証済みのパターンとベスト プラクティスを実装するときに最新の Windows 10 の機能が組み込まれた適切な形式で読み取ることのコードを示します。

![Windows Template Studio](images/windows-template-studio.png)

[Windows Template Studio](https://marketplace.visualstudio.com/items?itemName=WASTeamAccount.WindowsTemplateStudio)を参照してください。

<a id="desktop-style-UI" />

### <a name="controls-to-create-desktop-style-uis"></a>コントロールをデスクトップ スタイルの Ui を作成するには

従来のデスクトップ アプリケーション UI と UWP の UI のギャップを埋めるための新しい UWP XAML コントロールをリリースしましたしました。

たとえば、[メニュー バー](https://review.docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/menus?branch=jimwalk%2Frs5-menu-bar)、 [DropDownButton](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/buttons#create-a-drop-down-button)、 [SplitButton](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/buttons#create-a-split-button)、および[CommandBarFlyout](https://review.docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/command-bar-flyout?branch=jimwalk%2Frs5-command-bar-flyout)の新しいコントロールを提供するより柔軟な方法は、コマンドを公開して、 [EditableComboBox](https://review.docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/combo-box?branch=rs5#make-a-combo-box-editable)ユーザーに記載されていない値を入力してみましょうオプションの定義済みのリスト。

![メニュー バー](images/menu-bar.png)

<a id="enterprise" />

### <a name="controls-to-support-enterprise-scenarios"></a>エンタープライズ シナリオをサポートするコントロール

[DataGridView](https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/datagrid)では、行と列でデータのコレクションを表示する柔軟な方法を提供します。

[ツリー ビュー](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/tree-view)は、階層リストが展開と折りたたみを入れ子になった項目を含むノードを使用できます。 フォルダー構造や入れ子になった関係を UI で視覚的に示すために使用できます。

![データ グリッド コントロール](images/DataGrid.gif)


### <a name="windows-ui-library"></a>Windows UI ライブラリ

Windows UI のライブラリでは、UWP アプリのコントロールとその他のユーザー インターフェイス要素を提供する NuGet パッケージのセットです。 下位レベルの互換性を以前のバージョンの Windows 10 は、ユーザーは、最新の OS があるない場合でも、アプリが動作するようにこともできます。

![Windows UI ライブラリ](images/win-ui.png)

[Windows UI ライブラリ (プレビュー版)](https://docs.microsoft.com/en-us/uwp/toolkits/winui/)を参照してください。

<a id="xaml-islands" />

### <a name="uwp-controls-in-desktop-applications"></a>デスクトップ アプリケーションの UWP コントロール

ここで、Windows 10 では、WPF、Windows フォーム、および C++ Win32 デスクトップ アプリケーションで UWP コントロールを使用できます。 つまり、外観、や、既存のデスクトップ アプリケーション、最新の Windows 10 の UI 機能のみで利用可能な Windows Ink と Fluent Design System をサポートするコントロールなどの UWP コントロールの機能を強化することができます。 この機能は、XAML 諸島と呼ばれます。

[デスクトップ アプリケーションで UWP コントロール](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)を参照してください。

<a id="standard" />

### <a name="net-standard-20"></a>.NET Standard 2.0

.NET Standard 含む .NET Standard のよりも多くの Api を超える 20,000 1.x します。 これにより、既存の .NET Framework ライブラリに移行し、それらを使用して、UWP アプリケーションを含むさまざまな .NET アプリケーション間でずっと簡単にします。

![net 標準](images/dot-net-standard-project-template.png)

[デスクトップ アプリと UWP アプリの間で共有コード](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-migrate)を参照してください。

<a id="sql-server" />

### <a name="sql-server-connectivity"></a>SQL Server の接続

アプリで [System.Data.SqlClient](https://docs.microsoft.com/dotnet/api/system.data.sqlclient?redirectedfrom=MSDN&view=netframework-4.7.2) 名前空間のクラスを使用して、SQL Server データベースに直接接続し、データを保存および取得することができます。

「[UWP アプリでの SQL Server データベースの使用](https://docs.microsoft.com/en-us/windows/uwp/data-access/sql-server-databases)」をご覧ください。

<a id="MSIX" />

### <a name="msix-deployment"></a>MSIX 展開

MSIX は、すべての Windows アプリを最新のパッケージ化エクスペリエンスを提供する Windows アプリ パッケージ形式です。 MSIX パッケージの形式では、既存のアプリ パッケージの機能を維持し、Win32、WPF、および Windows フォーム アプリを新しい、最新のパッケージ化と展開機能を有効にするだけでなく、ファイルをインストールします。

MSIX 安全性と信頼性の高い、セキュリティで保護されたに組み込まれているパッケージ形式は、.msi、.appx、APP-V と ClickOnce インストール テクノロジの組み合わせに基づいています。

![MSIX アイコン](images/MSIX-App-Package.ico)

[MSIX ドキュメント](https://docs.microsoft.com/windows/msix/)を参照してください。

<a id="distribution" />

## <a name="security"></a>セキュリティ

Windows 10 では、アプリ開発者の id、ユーザー、企業のネットワークのセキュリティやデバイスに保存されている任意のビジネス データを保護するためのセキュリティ機能のセットを提供します。 新しい windows 10 は Microsoft Passport、PIN を使用して、アクセス可能な 2 要素のパスワードの導入が容易な代替または Windows こんにちは、エンタープライズ レベルのセキュリティを提供し、指紋、顔をサポートする、ベース虹彩認識です。

| トピック | 説明 |
|-------|-------------|
| [安全な Windows アプリの開発について](https://msdn.microsoft.com/library/windows/apps/mt622741) | この概要記事では、認証、フライトのデータ、およびデータの保存の各ステージ間でさまざまな Windows のセキュリティ機能について説明します。 これらの段階をアプリに統合する方法も説明します。 これにより、大規模なさまざまなトピックについて説明していて、目的はアプリの設計者が迅速かつ簡単に作成するユニバーサル Windows プラットフォーム アプリを構成する Windows の機能を理解の支援、主にします。 |
| [認証とユーザー ID](https://msdn.microsoft.com/library/windows/apps/mt270184) | UWP アプリでは、この記事に記載されているユーザー認証のいくつかのオプションがあります。 Enterprise、Microsoft Passport の新機能は強く推奨します。 Microsoft Passport は、パスワードを強力な 2 要素認証 (2 fa) に既存の資格情報を確認することで置き換え、デバイス固有の資格情報を作成して、生体認証または PIN ベースのユーザーのジェスチャ保護、その結果、どちらも便利なと高度安全なエクスペリエンスです。 |
| [Cryptography](https://msdn.microsoft.com/library/windows/apps/mt270191) | 暗号化」セクションでは、UWP アプリで利用できる暗号化機能の概要を示します。 入門チュートリアルを簡単に暗号化キーを操作して、Mac、ハッシュ、署名操作などの高度なトピックへの高度なビジネス上の機密データを暗号化する方法に関する記事の範囲です。 |
| [Windows 情報保護 (WIP)](wip-hub.md) | ここでは、Windows 情報保護 (WIP) と、ファイル、バッファー、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護との関係について、開発者向けに全体像を説明します。 |

## <a name="data-binding-and-databases"></a>データ バインディングとデータベース

データ バインディングは、アプリの UI が、データベースなどの外部ソースからデータを表示および必要に応じてそのデータを同期を保つための方法です。 データ バインディングによって、UI の問題からデータの問題を切り離すことができるため、概念的なモデルが簡素化されると共に、アプリの読みやすさ、テストの容易性、保守容易性が向上します。

| トピック | 説明 |
|-------|-------------|
| [データ バインディングの概要](https://msdn.microsoft.com/library/windows/apps/mt269383) | このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリ内の項目のコレクションに項目コントロールやコントロール (または他の UI 要素) を 1 つの項目にバインドする方法を示しています。 さらに、項目のレンダリングを制御して、選択した内容に基づいて、詳細ビューを実装し、表示用にデータを変換する方法を示しています。 |
| [UWP 用の entity Framework 7](https://msdn.microsoft.com/library/windows/apps/mt592863) | に対して大きなデータ セットの複雑なクエリを実行するが大幅に簡略化 UWP をサポートする Entity Framework 7 を使用します。 このチュートリアルでは、Entity Framework を使用して、ローカルの SQLite データベースに対して基本的なデータ アクセスを実行する UWP アプリをビルドします。 |
| [SQLite ローカル データベース](https://channel9.msdn.com/Series/A-Developers-Guide-to-Windows-10/10) | このビデオでは、SQLite、お勧めアプリのローカル データベースのソリューションを使用する包括的な開発者向けのガイドです。 [SQLite](https://www.sqlite.org/download.html)を UWP 用の最新バージョンをダウンロードするを参照してください。 または Windows 10 SDK を使って既に提供されているバージョンを使用します。 |

## <a name="networking-and-data-serialization"></a>ネットワークとデータのシリアル化

基幹業務アプリは、多くの場合との通信やその他のシステムのさまざまなにデータを格納する必要があります。 (残りの部分や用洗剤などのプロトコルを使用) のネットワーク サービスに接続することによってこれは通常のシリアル化するか、一般的な形式にデータを逆シリアル化します。 ネットワークとデータのシリアル化と同様に、WPF、WinForms、ASP.NET アプリケーションなどの UWP アプリで操作します。 詳細については、次の記事を参照してください。

| トピック | 説明 |
|-------|-------------|
| [ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233) | このチュートリアルでは、使用中の通信プロトコルに関係なく、すべての UWP アプリに関連するネットワーク基本概念について説明します。  |
| [アプリに適したネットワーク テクノロジ](https://msdn.microsoft.com/library/windows/apps/mt280235) | UWP アプリの場合、アプリに最適であるテクノロジを選ぶ方法についての提案を利用可能なネットワーク テクノロジの概要。 |
| [XML と用洗剤シリアル化](https://msdn.microsoft.com/library/90c86ass.aspx) | XML のシリアル化は、オブジェクトを特定の XML スキーマ定義言語 (XSD) に準拠した XML ストリームに変換します。 XML と厳密に型指定されたクラスの間で変換するには、ネイティブの[XDocument](https://msdn.microsoft.com/library/system.xml.linq.xdocument.aspx)クラスまたは外部ライブラリを使用できます。 |
| [JSON シリアル化](https://msdn.microsoft.com/library/windows/apps/br240639) | JSON (JavaScript オブジェクト表記) シリアル化は、REST Api と通信するための一般的な形式です。 [Newtonsoft Json.NET](http://www.newtonsoft.com/json)、UWP アプリを完全にサポートしています。 |

## <a name="devices"></a>デバイス

プリンター、スキャナー、または、スマート カード リーダーなどの基幹業務のツールと統合するためにする必要があります外部デバイスまたはセンサーをアプリに統合します。 ここでは、このセクションで説明するテクノロジを使って、アプリに追加できる機能例をいくつか紹介します。

| トピック  | 説明 |
|--------|-------------|
| [デバイスの列挙](https://msdn.microsoft.com/library/windows/apps/mt187355) | この記事では、内部では、ワイヤレスまたはネットワーク プロトコル経由で外部接続されている、または検出可能なシステムに接続されているデバイスを検索する[Windows.Devices.Enumeration](https://msdn.microsoft.com/library/windows/apps/br225459)名前空間を使用する方法について説明します。 デバイスで動作するすべてのアプリを作成する場合は、ここから開始します。 |
| [印刷とスキャン](https://msdn.microsoft.com/library/windows/apps/mt204544) | 接続とビジネス デバイスは、販売時点管理 (POS) システム、レシート プリンター、大容量フィーダー スキャナーなどの操作を含む、アプリから印刷およびスキャンする方法について説明します。 |
| [Bluetooth](https://msdn.microsoft.com/library/windows/apps/mt270288) | 従来の Bluetooth 接続を使用するデータまたはコントロールのデバイスを送受信するだけでなく Windows 10 で、Bluetooth 低エネルギー (BTLE) を使用して、バック グラウンドでビーコンを送受信します。 通知を表示またはユーザーが閉じるを取得または特定の場所を離れるときは、機能を有効にするには、これを使用します。 |
| [エンタープライズ共有記憶域](enterprise-shared-storage.md) | デバイスのロックダウンのシナリオで、アプリのインスタンス間やアプリ間であっても、同じアプリ内でデータを共有する方法について説明します。 |

## <a name="device-targeting"></a>デバイスのターゲット設定

多くのユーザーは、自分の電話の移行は今日またはするのには、タブレット、さまざまなフォーム ファクターと画面サイズがある場合がします。 ユニバーサル Windows プラットフォーム (UWP) を記述できますデスクトップ Pc や PPI ディスプレイなど、デバイスのさまざまな種類のすべてにシームレスに実行される 1 つの基幹業務アプリをアプリのリーチの拡大とコードの効率を最大限に引き出すことができます。

| トピック | 説明 |
|-------|-------------|
| [UWP アプリ ガイド](https://msdn.microsoft.com/library/windows/apps/dn894631) | この入門ガイドでするありますをお試し、Windows 10UWP プラットフォームを含む: どのようなデバイス ファミリは、新しい UI コントロールと UI を別のデバイスのフォーム ファクターに合わせて調整できるパネルをターゲットにする 1 つを決定する方法とを把握する方法アプリを利用できる API サーフェスを制御します。 |
| [アダプティブ UI の XAML コード サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619992) | 次のコード サンプルでは、すべての可能なレイアウト オプションとデバイスの種類に関係なく、アプリのコントロールを示しています、探している任意のレイアウトを実現する方法を表示するパネルを操作することができます。 各コントロールはさまざまなフォーム ファクターに応答する方法を示すだけでなく、アプリ自体が応答性の高いでアダプティブ UI を実現するためのさまざまな方法を示しています。 |
| [Xamarin トピック]() | Xamarin 電話をターゲット設定 |

## <a name="deployment"></a>展開

組織のユーザーにアプリを配布するためのオプションがあります。 既存のモバイル デバイス管理、ビジネス向け Microsoft ストアを使用することができますか、デバイスにアプリのサイドローディングすることができます。 行うことも、アプリ利用可能な一般にパブリックによって、Microsoft Store に公開します。

| トピック | 説明 |
|-------|-------------|
| [LOB アプリの企業への配布](https://msdn.microsoft.com/library/windows/apps/mt608995) | 一般に、アプリを広く利用できるようにすることがなく、ビジネス向け Microsoft Store 経由でボリューム取得用に企業に直接基幹業務アプリを公開することができます。 |
| [アプリのサイドロード](https://technet.microsoft.com/library/mt269549) | サイドローディング アプリが、展開するときに署名されたアプリ パッケージをデバイス。 署名、ホスト、およびこれらのアプリの展開を保持しています。 アプリのサイドローディング用のプロセスは、Windows 10 を合理化しました。             |
| [アプリを Microsoft Store に公開します。](https://dev.windows.com/publish) | 統一された Microsoft Store では、公開し、すべてのすべての Windows デバイス向けにアプリを管理することができます。 市場ごとの価格設定、分布と認知度コントロール、およびその他のオプションで、アプリの可用性をカスタマイズします。 |

## <a name="enterprise-uwp-samples"></a>エンタープライズ UWP のサンプル

| トピック |  説明 |
|------ |--------------|
| [VanArsdel インベントリのサンプル](https://github.com/Microsoft/InventorySample) | UWP サンプル アプリを基幹業務のシナリオを紹介します。 このサンプルは、作成、架空の会社 VanArsdel 顧客、注文、および製品を管理するのに基づいています。 |
| [顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database) | UWP サンプル アプリを Azure Active Directory (AAD) 認証、UI コントロール (データ グリッドなど)、Sqlite、SQL Azure データベースの統合、Entity Framework、および API のクラウド サービスと同様に、エンタープライズ開発者の役に立つ機能を紹介します。 このサンプルは、作成、架空の企業 Contoso の顧客、注文、および製品を管理するのに基づいています。 |

## <a name="patterns-and-practices"></a>パターンとプラクティス

コード ベースを規模が大きい場合に、エンタープライズ レベルのアプリは扱いにくくなることができます。 プリズムは、WPF、windows 10 UWP, Xamarin フォームで疎結合、保守、およびテストの XAML アプリケーションを構築するフレームワークです。 プリズムは、MVVM、依存関係挿入、コマンド、EventAggregator、およびと保守性を適切に構成された XAML アプリケーションの作成に役立つの設計パターンのコレクションの実装を提供します。

プリズムについて詳しくは、 [GitHub のリポジトリ](https://github.com/PrismLibrary/Prism)を参照してください。

 

 
