---
ms.assetid: 4b0c86d3-f05b-450b-bf9c-6ab4d3f07d31
description: このロードマップでは、Windows10 と汎用の Windows プラットフォーム (UWP) アプリケーションの主要なエンタープライズ機能の概要を提供します。
title: Enterprise
author: awkoren
ms.author: alkoren
ms.date: 08/30/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ffdc88449c025ba0a590ccc2bbd3f0c05346630f
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919433"
---
# <a name="enterprise"></a>Enterprise

このロードマップでは、Windows10Universal Windows プラットフォーム (UWP) アプリケーションの主要なエンタープライズ機能の概要を提供します。

**注**この資料はエンタープライズ UWP のアプリケーションを作成する開発者が対象としています。 UWP の全般的な開発は、 [10 の Windows アプリケーションの操作方法に関するガイド](https://msdn.microsoft.com/library/windows/apps/mt244352)を参照してください。 WPF、Windows フォーム、または Win32 の開発の場合は、[デスクトップのデベロッパー センター](https://dev.windows.com/desktop)を参照してください。 10 の Windows を展開するか、エンタープライズのセキュリティ機能を管理するのと同様に、IT プロフェッショナル向けのリソースは、 [TechNet の Windows の 10](https://msdn.microsoft.com/library/dn986868)を参照してください。

このプレゼンテーションを[迅速に構築 LOB アプリケーション](https://channel9.msdn.com/Events/Build/2018/BRK3502)ビルドに展示されているメリットの一部を表示するこのアプリケーションのバージョンがあります。

前面に触れて以下の点。

## <a name="whats-new-for-enterprise-applications"></a>エンタープライズ ・ アプリケーションの新機能

ここでいくつかのツール、ライブラリ、および非常に作成された機能は、最近です。

> [!div class="checklist"]
> * [Windows Template Studio](#template-studio)
> * [デスクトップ スタイルの Ui を作成するためのコントロール](#desktop-style-UI)
> * [エンタープライズ シナリオをサポートするコントロール](#enterprise)
> * [Windows UI ライブラリ](#UI-library)
> * [デスクトップ アプリケーションの UWP コントロール](#xaml-islands)
> * [.NET Standard 2.0](#standard)
> * [SQL Server の接続性](#sql-server)
> * [MSIX の展開](#MSIX)

<a id="template-studio" />

### <a name="windows-template-studio"></a>Windows Template Studio

Windows テンプレート Studio は、ウィザード ・ ベースのエクスペリエンスを使用して、新しい汎用 Windows プラットフォーム (UWP) アプリケーションの作成を迅速化する Visual Studio 2017 拡張です。 UWP プロジェクトは、実証済みのパターンとベスト プラクティスを実装するときに最新の 10 の Windows 機能が組み込まれたコードを適切な形式で読みやすいです。

![Windows Template Studio](images/windows-template-studio.png)

[テンプレート Studio を Windows](https://marketplace.visualstudio.com/items?itemName=WASTeamAccount.WindowsTemplateStudio)を参照してください。

<a id="desktop-style-UI" />

### <a name="controls-to-create-desktop-style-uis"></a>デスクトップ スタイルの Ui を作成するためのコントロール

従来型デスクトップ アプリケーションの UI と UWP の UI との間のギャップを埋める新しい UWP XAML コントロールをリリースしましたしました。

たとえば、[メニュー バー](https://review.docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/menus?branch=jimwalk%2Frs5-menu-bar)、 [DropDownButton](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/buttons#create-a-drop-down-button)、 [SplitButton](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/buttons#create-a-split-button)、および[CommandBarFlyout](https://review.docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/command-bar-flyout?branch=jimwalk%2Frs5-command-bar-flyout)の新しいコントロールを使用すれば、コマンドを公開する方法をより柔軟な[EditableComboBox](https://review.docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/combo-box?branch=rs5#make-a-combo-box-editable)ユーザーが一覧にない値を入力してみましょうで事前に定義されたオプションの一覧です。

![メニュー バー](images/menu-bar.png)

<a id="enterprise" />

### <a name="controls-to-support-enterprise-scenarios"></a>エンタープライズ シナリオをサポートするコントロール

[DataGridView](https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/datagrid)では、行や列のデータのコレクションを表示するのには柔軟な方法を提供します。

[ツリー ビュー](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/tree-view)は、展開と折りたたみの入れ子になった項目が含まれるノードの階層リストを有効にします。 フォルダー構造や入れ子になった関係を UI で視覚的に示すために使用できます。

![データ グリッド コントロール](images/DataGrid.gif)


### <a name="windows-ui-library"></a>Windows UI ライブラリ

Windows UI ライブラリは、UWP のアプリケーションのコントロールおよびその他のユーザー インターフェイス要素を提供する NuGet パッケージのセットです。 10 を Windows の以前のバージョンとの下位互換性は、ユーザーが最新の OS を持っていない場合でも、アプリが動作しているようこともできます。

![Windows UI ライブラリ](images/win-ui.png)

[Windows UI ライブラリ (プレビュー版)](https://docs.microsoft.com/en-us/uwp/toolkits/winui/)を参照してください。

<a id="xaml-islands" />

### <a name="uwp-controls-in-desktop-applications"></a>デスクトップ アプリケーションの UWP コントロール

Windows 10 を使用すると、UWP コントロールを使用して、WPF、Windows フォーム、および C++ の Win32 のデスクトップ アプリケーションのようになりました。 これは、外観、使い勝手、および UWP コントロールは、Windows インクなど、流暢なシステムの構築をサポートするコントロールによって提供される最新の Windows 10 UI 機能と、既存のデスクトップ アプリケーションの機能を拡張できることを意味します。 この機能は、XAML の島と呼ばれます。

[デスクトップ アプリケーションで UWP のコントロール](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)を参照してください。

<a id="standard" />

### <a name="net-standard-20"></a>.NET Standard 2.0

.NET の標準よりも多く 20,000 以上の Api は、.NET 標準 1.x。 これにより、既存の.NET Framework ライブラリを移行し、UWP アプリケーションを含む別の .NET アプリケーションの間でそれらを使用して負担を軽減します。

![ネット標準](images/dot-net-standard-project-template.png)

[デスクトップ アプリケーションと UWP のアプリケーション間で共有コード](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-migrate)を参照してください。

<a id="sql-server" />

### <a name="sql-server-connectivity"></a>SQL Server の接続性

アプリで [System.Data.SqlClient](https://docs.microsoft.com/dotnet/api/system.data.sqlclient?redirectedfrom=MSDN&view=netframework-4.7.2) 名前空間のクラスを使用して、SQL Server データベースに直接接続し、データを保存および取得することができます。

「[UWP アプリでの SQL Server データベースの使用](https://docs.microsoft.com/en-us/windows/uwp/data-access/sql-server-databases)」をご覧ください。

<a id="MSIX" />

### <a name="msix-deployment"></a>MSIX の展開

MSIX は、すべての Windows アプリケーションに最新のパッケージのエクスペリエンスを提供する Windows アプリケーションのパッケージ形式です。 MSIX パッケージの形式は、既存のアプリケーション パッケージの機能を保持し、Win32、WPF および Windows フォーム アプリケーションを新しい、最新のパッケージ化および展開機能を有効にするほかのファイルをインストールします。

MSIX は、パッケージ形式には、安全性とセキュリティで保護された信頼性の高い、.msi、.appx、APP-V と ClickOnce インストール テクノロジの組み合わせに基づきます。

![MSIX アイコン](images/WinUI_MSIX_2col_740x417.png)

[MSIX のマニュアル](https://docs.microsoft.com/windows/msix/)を参照してください。

<a id="distribution" />

## <a name="security"></a>セキュリティ

Windows10 は、アプリケーション開発者は、ユーザー、企業ネットワークのセキュリティおよびデバイスに格納されている任意のビジネス データの id を保護するためのセキュリティ機能のスイートを提供します。 新しい Windows10 は、Microsoft Passport、PIN を使用してアクセス可能な 2 つの要素の導入が容易なパスワードの代わりまたは Windows こんにちは、エンタープライズ レベルのセキュリティを提供し、指紋、facial をサポートしてベースの虹彩認識します。

| トピック | 説明 |
|-------|-------------|
| [安全な Windows アプリの開発について](https://msdn.microsoft.com/library/windows/apps/mt622741) | この記事は入門編では、フライトのデータ、およびデータの保存は、認証の各段階にわたってさまざまな Windows のセキュリティ機能について説明します。 また、それらのステージをアプリケーションに統合する方法も説明します。 トピックでは、大規模な範囲をカバーし、主に支援することをアプリケーションの設計者が迅速かつ容易に作成する汎用の Windows プラットフォームのアプリケーションを構成する Windows の機能の理解を深める目的です。 |
| [認証とユーザー ID](https://msdn.microsoft.com/library/windows/apps/mt270184) | UWP のアプリケーションでは、この資料に記載されているユーザー認証のためのいくつかのオプションがあります。 企業では、Microsoft Passport の新機能は強く推奨します。 Microsoft Passport は、既存の資格情報を確認することで強力な二要素認証 (2FA) パスワードを置き換えます、デバイスに固有の資格情報を作成することによってバイオ メトリックまたは暗証番号 (pin) ベースのユーザー ジェスチャを保護する、両方に便利で高度とセキュリティで保護されたことがあります。 |
| [暗号化](https://msdn.microsoft.com/library/windows/apps/mt270191) | 暗号化」セクションでは、UWP のアプリケーションに利用可能な暗号化機能の概要を示します。 記事の範囲は、簡単に暗号化キーを操作して、Mac、ハッシュ、および署名の操作などの高度なトピックへの高度なビジネス上の機密データを暗号化する方法の入門編のチュートリアルです。 |
| [Windows 情報保護 (WIP)](wip-hub.md) | ここでは、Windows 情報保護 (WIP) と、ファイル、バッファー、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護との関係について、開発者向けに全体像を説明します。 |

## <a name="data-binding-and-databases"></a>データ バインディングとデータベース

データ バインディングは、アプリの UI がデータベースなどの外部ソースからデータを表示して、必要に応じてそのデータとの同期を維持するための方法です。 データ バインディングによって、UI の問題からデータの問題を切り離すことができるため、概念的なモデルが簡素化されると共に、アプリの読みやすさ、テストの容易性、保守容易性が向上します。

| トピック | 説明 |
|-------|-------------|
| [データ バインディングの概要](https://msdn.microsoft.com/library/windows/apps/mt269383) | このトピックでは、コントロール (または他の UI 要素) を 1 つの項目にバインドするか、汎用 Windows プラットフォーム (UWP) アプリケーション内の項目のコレクションに項目のコントロールにバインドする方法を示します。 さらに、アイテムのレンダリングを制御し、詳細ビューに、選択範囲を実装し、表示用にデータを変換する方法を示しています。 |
| [UWP の entity Framework 7](https://msdn.microsoft.com/library/windows/apps/mt592863) | 大きなデータ セットに対して複雑なクエリを実行することが大幅に合理化 UWP をサポートする、エンティティ フレームワーク 7 を使用します。 このチュートリアルでは、Entity Framework を使用してローカルの SQLite データベースに対して基本的なデータ アクセスを実行する UWP アプリケーションをビルドします。 |
| [ローカルの SQLite データベース](https://channel9.msdn.com/Series/A-Developers-Guide-to-Windows-10/10) | このビデオは、SQLite では、ローカルのアプリケーション データベースの推奨される解決方法を使用する包括的な開発者向けのガイドです。 UWP の最新バージョンをダウンロードするのには、 [SQLite](https://www.sqlite.org/download.html)を参照してくださいまたは Windows 10 SDK で提供されていないバージョンを使用します。 |

## <a name="networking-and-data-serialization"></a>ネットワークとデータのシリアル化

基幹業務アプリケーションは多くの場合との通信や、さまざまなその他のシステムにデータを格納する必要があります。 (REST や SOAP などのプロトコルを使用して) ネットワーク サービスに接続することでこれは通常のシリアル化するか、一般的な形式にデータを逆シリアル化します。 ネットワークと UWP WPF や WinForms、ASP.NET アプリケーションと同様のアプリケーションでのデータのシリアル化を使用します。 詳細については以下の資料を参照してください。

| トピック | 説明 |
|-------|-------------|
| [ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233) | このチュートリアルでは、使用中の通信プロトコルに関係なく、UWP のすべてのアプリケーションに関連する基本のネットワークの概念について説明します。  |
| [アプリに適したネットワーク テクノロジ](https://msdn.microsoft.com/library/windows/apps/mt280235) | UWP アプリケーションでは、アプリケーションに最適のテクノロジを選択する方法に関する推奨事項、使用可能なネットワーク テクノロジの概要です。 |
| [XML と SOAP のシリアル化](https://msdn.microsoft.com/library/90c86ass.aspx) | XML シリアル化では、特定の XML スキーマ定義言語 (XSD) に準拠する XML ストリームにオブジェクトを変換します。 XML と厳密に型指定されたクラス間の変換をするには、 [XDocument](https://msdn.microsoft.com/library/system.xml.linq.xdocument.aspx)のネイティブ クラス、または外部ライブラリを使用できます。 |
| [JSON シリアル化](https://msdn.microsoft.com/library/windows/apps/br240639) | JSON (JavaScript オブジェクト表記法) のシリアル化は、REST Api と通信するための一般的な形式です。 [Newtonsoft Json.NET](http://www.newtonsoft.com/json)UWP のアプリケーションを完全にサポートしています。 |

## <a name="devices"></a>デバイス

プリンター、バーコード スキャナー、または、スマート カード読み取り装置のように、ビジネス ・ ライン ・ ツールと統合するためにする必要があります外付けデバイスやセンサーをアプリに統合します。 ここでは、このセクションで説明するテクノロジを使って、アプリに追加できる機能例をいくつか紹介します。

| トピック  | 説明 |
|--------|-------------|
| [デバイスの列挙](https://msdn.microsoft.com/library/windows/apps/mt187355) | この資料では、ワイヤレスまたはネットワーク プロトコル経由で外部から接続している、または検出が可能なシステムに内部で接続されているデバイスを検索するのには、 [Windows.Devices.Enumeration](https://msdn.microsoft.com/library/windows/apps/br225459)名前空間を使用する方法について説明します。 デバイスで動作する任意のアプリケーションを構築する場合は、ここを起動します。 |
| [印刷とスキャン](https://msdn.microsoft.com/library/windows/apps/mt204544) | 印刷しに接続して、point-of-sale (POS) システム、レシート プリンター、スキャナーの処理能力の高いフィーダーなどのビジネスのデバイスの操作を含む、アプリケーションからスキャンを実行する方法について説明します。 |
| [Bluetooth](https://msdn.microsoft.com/library/windows/apps/mt270288) | データまたは制御デバイスの送受信を行うには、従来の Bluetooth 接続を使用して、他は、Windows 10 は、Bluetooth 低エネルギー (BTLE) を使用して、ビーコンをバック グラウンドで送受信を有効にします。 通知を表示、またはユーザーが閉じるを取得または特定の場所を離れるときに機能を有効にするには、これを使用します。 |
| [エンタープライズ共有記憶域](enterprise-shared-storage.md) | デバイスのロックダウンのシナリオで、アプリケーションのインスタンスとの間またはアプリケーション間でさえも、同じアプリケーション内のデータを共有する方法を説明します。 |

## <a name="device-targeting"></a>デバイスを対象とします。

今日、多くのユーザーは自分の電話することはまたはさまざまなフォーム ファクターと画面のサイズであるために、タブレットします。 ユニバーサル Windows プラットフォーム (UWP) で記述できますデバイス、デスクトップ Pc、PPI の表示などのさまざまな種類のすべてにシームレスに実行される 1 つの基幹業務アプリケーション アプリの範囲とコードの効率を最大化することを許可します。

| トピック | 説明 |
|-------|-------------|
| [UWP アプリ ガイド](https://msdn.microsoft.com/library/windows/apps/dn894631) | この入門ガイドですることをお試し Windows 10UWP プラットフォームを含む: どのようなデバイス ファミリは、新しい UI コントロールなど、さまざまなデバイス フォームの要因に、UI を調整するためのパネルを対象とするには、どちらかを決定する方法と方法を理解するにはアプリを利用可能な API サーフェイスを制御します。 |
| [適応型の XAML UI コードのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619992) | このコード サンプルは、すべての可能なレイアウトのオプションとデバイスの種類に関係なく、アプリのコントロールを示しています、探している任意のレイアウトを実現する方法を表示するパネルを操作することができます。 各コントロールが別のフォームの要素にどのように応答する方法を示すだけでなくアプリそのものは応答し、適応型の UI を実現するためのさまざまな方法を示しています。 |
| [Xamarin のトピック]() | Xamarin の電話を対象とします。 |

## <a name="deployment"></a>展開

組織のユーザーにアプリケーションを配布するためのオプションがあります。 マイクロソフトのストアを使用するには、既存のモバイル デバイス管理のビジネスまたは sideload デバイス アプリケーションを作成することができます。 行うこともアプリ利用可能な一般に公開マイクロソフト ストアへの発行によって。

| トピック | 説明 |
|-------|-------------|
| [LOB アプリの企業への配布](https://msdn.microsoft.com/library/windows/apps/mt608995) | 一般に広く利用可能なアプリケーションを加えずに、ボリュームの購入、ビジネスのマイクロソフト ストアを経由して企業に直接の基幹業務アプリケーションを発行できます。 |
| [アプリのサイドロード](https://technet.microsoft.com/library/mt269549) | Sideload アプリケーションは、展開する際に署名付きのアプリケーション パッケージのデバイスです。 署名、ホスト、およびこれらのアプリケーションの配置を維持します。 Windows 10 の sideloading アプリケーションのプロセスを合理化するとします。             |
| [マイクロソフト ストアにアプリケーションを発行します。](https://dev.windows.com/publish) | 統合された Microsoft ストアでは、公開し、すべての Windows デバイス アプリケーションのすべてを管理することができます。 市場ごとの価格設定、配布、表示/非表示コントロール、およびその他のオプションと、アプリケーションの可用性をカスタマイズします。 |

## <a name="enterprise-uwp-samples"></a>エンタープライズ UWP のサンプル

手順の概要がここに入ります。

アクション - 一緒に複数の企業に重点を置いたサンプルを取得するには、樹やカールを説明します。

| トピック |  説明 |
|------ |--------------|
| [VanArsdel の在庫の例](https://github.com/Microsoft/InventorySample) | 業務の場合は、デスクトップ アプリケーションで、最新の Windows の機能を使用する方法を示す (汎用の Windows プラットフォームを使用して) Windows の 10 のサンプル アプリケーションにフォーカスしています。 サンプルは、作成して、VanArsdel という架空の企業の顧客、注文、および製品を管理するのに基づいています。
MVVM を強調表示、エンティティ フレームワークである SQL データベースです。 他のユーザーの一覧を表示します。|

## <a name="patterns-and-practices"></a>パターンとプラクティス

大規模コード ベースを使用する、エンタープライズ ・ クラスのアプリケーションが扱いにくくなることができます。 プリズムは、WPF、Windows10 の UWP および Xamarin フォームの XAML アプリケーションの疎結合、保守、およびテストを作成するためのフレームワークです。 Prism では、MVVM、依存関係の注入、コマンド、EventAggregator、および他のユーザーなど、適切に構造化し、保守が容易な XAML アプリケーションの作成に役立つ設計パターンのコレクションの実装を提供します。

プリズムの詳細については、 [GitHub リポジトリの索引](https://github.com/PrismLibrary/Prism)を参照してください。

 

 
