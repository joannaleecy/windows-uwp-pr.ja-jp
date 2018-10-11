---
ms.assetid: 4b0c86d3-f05b-450b-bf9c-6ab4d3f07d31
description: このロードマップは、Windows 10 とユニバーサル Windows プラットフォーム (UWP) アプリの主要なエンタープライズ機能の概要を示します。
title: Enterprise
author: awkoren
ms.author: alkoren
ms.date: 08/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0f7c5ad355aa6b99f8f76df230fefb283e54cffd
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4506346"
---
# <a name="enterprise"></a>Enterprise

このロードマップは、Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリの主要なエンタープライズ機能の概要を提供します。

**注:** この記事では、エンタープライズ UWP アプリを作成する開発者を対象としてです。 一般的な UWP 開発では、 [Windows 10 アプリに関するハウツー ガイド](https://msdn.microsoft.com/library/windows/apps/mt244352)をご覧ください。 WPF、Windows フォーム、または Win32 の開発では、[デスクトップのデベロッパー センター](https://dev.windows.com/desktop)を参照してください。 Windows 10 の展開またはエンタープライズ セキュリティ機能を管理するように、IT プロフェッショナル向けのリソースは、 [technet の「Windows 10](https://msdn.microsoft.com/library/dn986868)を参照してください。

このプレゼンテーションを[迅速に構築 LOB アプリケーション](https://channel9.msdn.com/Events/Build/2018/BRK3502)ビルドに展示されている強化機能の一部を示すこのアプリケーションのバージョンはあります。

前面に触れて事項:

## <a name="whats-new-for-enterprise-applications"></a>エンタープライズ アプリケーション向けの最新情報

次にいくつかのツール、ライブラリ、および非常に作成されている機能は、最近します。

> [!div class="checklist"]
> * [Windows Template Studio](#template-studio)
> * [コントロールをデスクトップ スタイルの Ui を作成するには](#desktop-style-UI)
> * [エンタープライズ シナリオをサポートするコントロール](#enterprise)
> * [Windows UI ライブラリ](#UI-library)
> * [デスクトップ アプリケーションで UWP コントロール](#xaml-islands)
> * [.NET Standard 2.0](#standard)
> * [SQL Server の接続](#sql-server)
> * [MSIX 展開](#MSIX)

<a id="template-studio" />

### <a name="windows-template-studio"></a>Windows Template Studio

Windows Template Studio は、ウィザード ベースのエクスペリエンスを使用して、新しいユニバーサル Windows プラットフォーム (UWP) アプリの作成を加速する Visual Studio 2017 拡張です。 結果として得られる UWP プロジェクトでは、実証済みのパターンとベスト プラクティスを実装するときに最新の Windows 10 の機能が組み込まれた適切な形式で読みやすいコードを示します。

![Windows Template Studio](images/windows-template-studio.png)

[Windows Template Studio](https://marketplace.visualstudio.com/items?itemName=WASTeamAccount.WindowsTemplateStudio)を参照してください。

<a id="desktop-style-UI" />

### <a name="controls-to-create-desktop-style-uis"></a>コントロールをデスクトップ スタイルの Ui を作成するには

従来のデスクトップ アプリケーション UI と UWP の UI のギャップを埋める新しい UWP XAML コントロールをリリースしましたしました。

たとえば、新しい[メニュー バー](https://review.docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/menus?branch=jimwalk%2Frs5-menu-bar)、 [DropDownButton](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/buttons#create-a-drop-down-button)、 [SplitButton](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/buttons#create-a-split-button)、および[CommandBarFlyout](https://review.docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/command-bar-flyout?branch=jimwalk%2Frs5-command-bar-flyout)コントロールは、コマンドを公開するより柔軟な方法を提供し、 [EditableComboBox](https://review.docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/combo-box?branch=rs5#make-a-combo-box-editable)ユーザーに記載されていない値を入力してみましょうオプションの定義済みのリスト。

![メニュー バー](images/menu-bar.png)

<a id="enterprise" />

### <a name="controls-to-support-enterprise-scenarios"></a>エンタープライズ シナリオをサポートするコントロール

[DataGridView](https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/datagrid)では、行と列でデータのコレクションを表示する柔軟な方法を提供します。

[ツリー ビュー](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/tree-view)は、展開したり、折りたたんだり入れ子になった項目が含まれるノードと、階層リストを使用できます。 フォルダー構造や入れ子になった関係を UI で視覚的に示すために使用できます。

![データ グリッド コントロール](images/DataGrid.gif)


### <a name="windows-ui-library"></a>Windows UI ライブラリ

Windows UI のライブラリでは、UWP アプリのコントロールとその他のユーザー インターフェイス要素を提供する NuGet パッケージのセットです。 下位レベルの互換性を以前のバージョンの Windows 10 は、ユーザーは、最新の OS があるない場合でも、アプリが機能するようにこともできます。

![Windows UI ライブラリ](images/win-ui.png)

[Windows UI ライブラリ (プレビュー版)](https://docs.microsoft.com/en-us/uwp/toolkits/winui/)を参照してください。

<a id="xaml-islands" />

### <a name="uwp-controls-in-desktop-applications"></a>デスクトップ アプリケーションで UWP コントロール

これで、Windows 10 では、WPF、Windows フォーム、および C++ Win32 デスクトップ アプリケーションで UWP コントロールを使用できます。 つまり、外観、や、最新の Windows 10 の UI 機能のみで利用可能な Windows Ink と Fluent Design System をサポートするコントロールなどの UWP コントロールは、既存のデスクトップ アプリケーションの機能を強化することができます。 この機能は、XAML 諸島と呼ばれます。

[デスクトップ アプリケーションで UWP コントロール](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)を参照してください。

<a id="standard" />

### <a name="net-standard-20"></a>.NET Standard 2.0

.NET Standard が含まれていますより、.NET Standard より多くの Api 超える 20,000 には 1.x します。 これにより、既存の .NET Framework ライブラリに移行し、それらを使用して、UWP アプリケーションを含むさまざまな .NET アプリケーション間でずっと簡単にします。

![net 標準](images/dot-net-standard-project-template.png)

[デスクトップ アプリと UWP アプリの間で共有コード](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-migrate)を参照してください。

<a id="sql-server" />

### <a name="sql-server-connectivity"></a>SQL Server の接続

アプリで [System.Data.SqlClient](https://docs.microsoft.com/dotnet/api/system.data.sqlclient?redirectedfrom=MSDN&view=netframework-4.7.2) 名前空間のクラスを使用して、SQL Server データベースに直接接続し、データを保存および取得することができます。

「[UWP アプリでの SQL Server データベースの使用](https://docs.microsoft.com/en-us/windows/uwp/data-access/sql-server-databases)」をご覧ください。

<a id="MSIX" />

### <a name="msix-deployment"></a>MSIX 展開

MSIX は、すべての Windows アプリを最新のパッケージ化エクスペリエンスを提供する Windows アプリ パッケージ形式です。 MSIX パッケージの形式では、既存のアプリ パッケージの機能を維持し、Win32、WPF、および Windows フォーム アプリを新しい、最新のパッケージ化と展開機能を有効にするだけでなく、ファイルをインストールします。

MSIX 安全性と信頼性の高い、セキュリティで保護されたに組み込まれているパッケージ形式は、.msi、.appx、APP-V と ClickOnce インストールのテクノロジの組み合わせに基づいています。

![MSIX アイコン](images/WinUI_MSIX_2col_740x417.png)

[MSIX ドキュメント](https://docs.microsoft.com/windows/msix/)を参照してください。

<a id="distribution" />

## <a name="security"></a>Security

Windows 10 では、アプリ開発者の id、ユーザー、企業のネットワークのセキュリティやデバイスに保存されている任意のビジネス データを保護するためのセキュリティ機能のセットを提供します。 新しい Windows 10 は Microsoft Passport、PIN を使用して、アクセス可能な 2 要素のパスワードの導入が容易な代替または Windows こんにちは、エンタープライズ レベルのセキュリティを提供し、指紋、顔をサポートする、ベース虹彩認識です。

| トピック | 説明 |
|-------|-------------|
| [安全な Windows アプリの開発について](https://msdn.microsoft.com/library/windows/apps/mt622741) | この概要記事では、認証、フライトのデータ、およびデータの保存の各ステージ間でさまざまな Windows のセキュリティ機能について説明します。 これらの段階をアプリに統合する方法も説明します。 大規模なトピックで説明し、目的はアプリの設計者が迅速かつ簡単に作成するユニバーサル Windows プラットフォーム アプリを構成する Windows の機能を理解の支援、主にします。 |
| [認証とユーザー ID](https://msdn.microsoft.com/library/windows/apps/mt270184) | UWP アプリには、この記事に記載されているユーザー認証のためのいくつかのオプションがあります。 企業の Microsoft Passport の新機能は強くお勧めします。 Microsoft Passport は、パスワードを強力な 2 要素認証 (2 fa) に既存の資格情報を確認することで置き換え、デバイス固有の資格情報を作成して、生体認証または PIN ベースのユーザーのジェスチャ保護、その結果、どちらも便利なと高度安全なエクスペリエンスです。 |
| [Cryptography](https://msdn.microsoft.com/library/windows/apps/mt270191) | 暗号化」セクションでは、UWP アプリで利用できる暗号化機能の概要を示します。 入門チュートリアルを簡単に暗号化キーを操作して、Mac、ハッシュ、署名操作などの高度なトピックへの高度なビジネス上の機密データを暗号化する方法に関する記事範囲です。 |
| [Windows 情報保護 (WIP)](wip-hub.md) | ここでは、Windows 情報保護 (WIP) と、ファイル、バッファー、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護との関係について、開発者向けに全体像を説明します。 |

## <a name="data-binding-and-databases"></a>データ バインディングとデータベース

データ バインディングは、アプリの UI が、データベースなどの外部ソースからデータを表示および必要に応じてそのデータを同期を保つための方法です。 データ バインディングによって、UI の問題からデータの問題を切り離すことができるため、概念的なモデルが簡素化されると共に、アプリの読みやすさ、テストの容易性、保守容易性が向上します。

| トピック | 説明 |
|-------|-------------|
| [データ バインディングの概要](https://msdn.microsoft.com/library/windows/apps/mt269383) | このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリ内の項目のコレクションに項目コントロールやコントロール (または他の UI 要素) を 1 つの項目にバインドする方法を示しています。 さらに、項目のレンダリングを制御して、選択した内容に基づいて、詳細ビューを実装し、表示用にデータを変換する方法を示しています。 |
| [UWP 用の entity Framework 7](https://msdn.microsoft.com/library/windows/apps/mt592863) | 大きなデータ セットに対して複雑なクエリを実行するが大幅に簡略化 UWP をサポートしている Entity Framework 7 を使用します。 このチュートリアルでは、Entity Framework を使用して、ローカルの SQLite データベースに対して基本的なデータ アクセスを実行する UWP アプリをビルドします。 |
| [SQLite ローカル データベース](https://channel9.msdn.com/Series/A-Developers-Guide-to-Windows-10/10) | このビデオでは、SQLite、お勧めアプリのローカル データベースのソリューションを使用する包括的な開発者向けのガイドです。 [SQLite](https://www.sqlite.org/download.html)を UWP 用の最新バージョンをダウンロードするを参照してください。 または Windows 10 SDK を使って既に提供されているバージョンを使用します。 |

## <a name="networking-and-data-serialization"></a>ネットワークとデータのシリアル化

基幹業務アプリは、多くの場合との通信やその他のシステムのさまざまなにデータを格納する必要があります。 (REST または用洗剤などのプロトコルを使用) のネットワーク サービスに接続することによってこれは通常のシリアル化するか、一般的な形式にデータを逆シリアル化します。 ネットワークとデータのシリアル化と同様に、WPF、WinForms、ASP.NET アプリケーションなどの UWP アプリで操作します。 詳細については、次の記事を参照してください。

| トピック | 説明 |
|-------|-------------|
| [ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233) | このチュートリアルでは、使用中の通信プロトコルに関係なく、すべての UWP アプリに関連するネットワーク基本概念について説明します。  |
| [アプリに適したネットワーク テクノロジ](https://msdn.microsoft.com/library/windows/apps/mt280235) | UWP アプリの場合、アプリに最適であるテクノロジを選ぶ方法についての提案を利用可能なネットワーク テクノロジの概要。 |
| [XML と用洗剤シリアル化](https://msdn.microsoft.com/library/90c86ass.aspx) | XML のシリアル化は、オブジェクトを特定の XML スキーマ定義言語 (XSD) に準拠した XML ストリームに変換します。 XML と厳密に型指定されたクラスの間で変換するには、ネイティブの[XDocument](https://msdn.microsoft.com/library/system.xml.linq.xdocument.aspx)クラスまたは外部ライブラリを使用できます。 |
| [JSON シリアル化](https://msdn.microsoft.com/library/windows/apps/br240639) | JSON (JavaScript オブジェクト表記) シリアル化は、REST Api と通信するための一般的な形式です。 [Newtonsoft Json.NET](http://www.newtonsoft.com/json)、UWP アプリを完全にサポートしています。 |

## <a name="devices"></a>デバイス

プリンター、スキャナー、または、スマート カード リーダーなどの基幹業務ツールと統合するためにする必要があります外部デバイスまたはセンサーをアプリに統合します。 ここでは、このセクションで説明するテクノロジを使って、アプリに追加できる機能例をいくつか紹介します。

| トピック  | 説明 |
|--------|-------------|
| [デバイスの列挙](https://msdn.microsoft.com/library/windows/apps/mt187355) | この記事では、内部では、ワイヤレスまたはネットワーク プロトコル経由で外部接続されている、または検出可能なシステムに接続されているデバイスを検索する[Windows.Devices.Enumeration](https://msdn.microsoft.com/library/windows/apps/br225459)名前空間を使用する方法について説明します。 デバイスで動作するすべてのアプリを作成する場合は、ここから開始します。 |
| [印刷とスキャン](https://msdn.microsoft.com/library/windows/apps/mt204544) | 接続とビジネス デバイスは、販売時点管理 (POS) システム、レシート プリンター、大容量フィーダー スキャナーなどの操作を含む、アプリから印刷およびスキャンする方法について説明します。 |
| [Bluetooth](https://msdn.microsoft.com/library/windows/apps/mt270288) | データまたはコントロールのデバイスを送受信する従来の Bluetooth 接続を使用するだけでなく Windows 10 で、Bluetooth 低エネルギー (BTLE) を使用して、バック グラウンドでビーコンを送受信します。 通知を表示またはユーザーが閉じるを取得または特定の場所を離れるときは、機能を有効にするには、これを使用します。 |
| [エンタープライズ共有記憶域](enterprise-shared-storage.md) | デバイスのロックダウンのシナリオで、アプリのインスタンス間やアプリ間であっても、同じアプリ内でデータを共有する方法について説明します。 |

## <a name="device-targeting"></a>デバイスのターゲット設定

多くのユーザーは、自分の電話の移行は今日またはするのには、タブレット、さまざまなフォーム ファクターと画面サイズがある場合がします。 ユニバーサル Windows プラットフォーム (UWP) を記述できますデスクトップ Pc や PPI の表示など、デバイスのさまざまな種類のすべてでシームレスに動作する 1 つの基幹業務アプリをアプリのリーチの拡大と、コードの効率を最大限に引き出すことができます。

| トピック | 説明 |
|-------|-------------|
| [UWP アプリ ガイド](https://msdn.microsoft.com/library/windows/apps/dn894631) | この入門ガイドでするありますをお試し、Windows 10UWP プラットフォームを含む: どのようなデバイス ファミリは、新しい UI コントロールと UI を別のデバイスのフォーム ファクターに合わせて調整できるパネルをターゲットには、どちらかを決定する方法とを把握する方法アプリを利用できる API サーフェスを制御します。 |
| [アダプティブ UI の XAML コード サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619992) | 次のコード サンプルでは、すべての可能なレイアウト オプションとデバイスの種類に関係なく、アプリのコントロールを示しています、探している任意のレイアウトを実現する方法を表示するパネルを操作することができます。 各コントロールはさまざまなフォーム ファクターに応答する方法を示すだけでなく、アプリ自体が応答性の高いでアダプティブ UI を実現するためのさまざまな方法を示しています。 |
| [Xamarin トピック]() | Xamarin の電話をターゲットと |

## <a name="deployment"></a>展開

組織のユーザーにアプリを配布するためのオプションがあります。 既存のモバイル デバイス管理、ビジネス向け Microsoft ストアを使用することができますか、デバイスにアプリのサイドローディングすることができます。 行うことも、アプリ利用可能な一般にパブリックによって、Microsoft Store に公開します。

| トピック | 説明 |
|-------|-------------|
| [LOB アプリの企業への配布](https://msdn.microsoft.com/library/windows/apps/mt608995) | 基幹業務アプリは、一般に、アプリを広く利用できるようにすることがなく、ビジネス向け Microsoft Store 経由でボリューム取得用に企業に直接公開できます。 |
| [アプリのサイドロード](https://technet.microsoft.com/library/mt269549) | サイドローディング アプリが、展開するとき、署名済みのアプリ パッケージをデバイス。 署名、ホスト、およびこれらのアプリの展開を保持しています。 アプリのサイドローディング用のプロセスは、Windows 10 を合理化しました。             |
| [アプリを Microsoft Store に公開します。](https://dev.windows.com/publish) | 統一された Microsoft Store では、公開し、すべてのすべての Windows デバイス向けにアプリを管理することができます。 市場ごとの価格設定、分布と認知度コントロール、およびその他のオプションを使用したアプリの可用性をカスタマイズします。 |

## <a name="enterprise-uwp-samples"></a>エンタープライズ UWP のサンプル

手順の概要がここに入ります。

操作 - を一緒に複数の企業に重点を置いたのサンプルを取得するには、Josh やカールを説明します。

| トピック |  説明 |
|------ |--------------|
| [VanArsdel インベントリのサンプル](https://github.com/Microsoft/InventorySample) | デスクトップ アプリケーションに最新の Windows の機能を使用する方法を示す、基幹業務のシナリオに重点を置いたサンプル アプリケーション Windows 10 (ユニバーサル Windows プラットフォームを使用)。 このサンプルは、作成して、VanArsdel 架空の会社の顧客、注文、および製品を管理するために基づいています。
MVVM、強調表示 SQL データベース、Entity Framework します。 他のユーザーの一覧を表示します。|

## <a name="patterns-and-practices"></a>パターンとプラクティス

コード ベースを規模が大きい場合に、エンタープライズ レベルのアプリは扱いにくくなることができます。 プリズムは、WPF、Windows 10 UWP および Xamarin フォームの疎結合、保守、およびテストの XAML アプリケーションを構築するフレームワークです。 プリズムは、MVVM、依存関係挿入、コマンド、EventAggregator、およびと保守性を適切に構成された XAML アプリケーションの作成に役立つの設計パターンのコレクションの実装を提供します。

プリズムについて詳しくは、 [GitHub のリポジトリ](https://github.com/PrismLibrary/Prism)を参照してください。

 

 
