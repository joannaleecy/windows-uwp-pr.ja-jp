---
ms.assetid: 4b0c86d3-f05b-450b-bf9c-6ab4d3f07d31
description: このロードマップでは、Windows 10 およびユニバーサル Windows プラットフォーム (UWP) アプリの主要なエンタープライズ機能の概要について説明します。
title: エンタープライズ
ms.date: 08/30/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: fae4d5b57ac5cfb5c47fca1a2f3476cd16a56534
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57583202"
---
# <a name="enterprise"></a>エンタープライズ

この記事では、Windows 10 アプリ用のユニバーサル Windows プラットフォーム (UWP) で提供される主要なエンタープライズ機能の概要について説明します。 これらのいくつかの機能を詳しく説明するビデオについては、「[Rapidly Construct LOB Applications with UWP and Visual Studio](https://channel9.msdn.com/Events/Build/2018/BRK3502)」 (UWP と Visual Studio で LOB アプリケーションをすばやく構築する) をご覧ください。

<a id="template-studio" />

### <a name="windows-template-studio"></a>Windows Template Studio

Windows Template Studio は Visual Studio 2017 の拡張機能であり、ウィザード ベースのエクスペリエンスを使用して、新しいユニバーサル Windows プラットフォーム (UWP) アプリをより迅速に作成できます。 結果として得られる UWP プロジェクトは、実証済みのパターンとベスト プラクティスを実装するときに、最新の Windows 10 機能を組み込む適切な形式の読み取り可能なコードです。

![Windows Template Studio](images/windows-template-studio.png)

「[Windows Template Studio](https://marketplace.visualstudio.com/items?itemName=WASTeamAccount.WindowsTemplateStudio)」を参照してください

<a id="desktop-style-UI" />

### <a name="controls-to-create-desktop-style-uis"></a>デスクトップ スタイルの UI を作成するコントロール

従来のデスクトップ アプリケーション UI と UWP UI とのギャップを埋める、新しい UWP XAML コントロールがリリースされました。

たとえば、新しい [MenuBar](/windows/uwp/design/controls-and-patterns/menus)、[DropDownButton](/windows/uwp/design/controls-and-patterns/buttons#create-a-drop-down-button)、[SplitButton](/windows/uwp/design/controls-and-patterns/buttons#create-a-split-button)、および [CommandBarFlyout](/windows/uwp/design/controls-and-patterns/command-bar-flyout) コントロールでは、より柔軟にコマンドを公開することができます。また、[EditableComboBox](/windows/uwp/design/controls-and-patterns/combo-box#make-a-combo-box-editable) では、ユーザーが定義済みのオプション リストに示されていない値を入力することができます。

![MenuBar](images/menu-bar.png)

<a id="enterprise" />

### <a name="controls-to-support-enterprise-scenarios"></a>エンタープライズ シナリオをサポートするコントロール

[DataGridView](https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/datagrid) では、行と列に柔軟にデータ コレクションを表示できます。

[TreeView](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/tree-view) を使用すると、階層リストが有効になり、入れ子になった項目を含むノードを展開したり、折りたたんだりすることができるようになります。 フォルダー構造や入れ子になった関係を UI で視覚的に示すために使用できます。

![DataGrid コントロール](images/DataGrid.gif)


### <a name="windows-ui-library"></a>Windows UI ライブラリ

Windows UI ライブラリは、UWP アプリ用のコントロールとその他のユーザー インターフェイス要素を提供する NuGet パッケージのセットです。 また、以前のバージョンの Windows 10 との下位互換性が有効になるため、ユーザーが最新の OS を持っていない場合でも、アプリは動作します。

![Windows UI ライブラリ](images/win-ui.png)

[Windows UI ライブラリ (プレビュー バージョン)](https://docs.microsoft.com/uwp/toolkits/winui/) に関するページを参照してください。

<a id="xaml-islands" />

### <a name="uwp-controls-in-desktop-applications"></a>デスクトップ アプリケーションの UWP コントロール

Windows 10 では、WPF、Windows フォーム、および C++ Win32 デスクトップ アプリケーションで UWP コントロールを使用できるようになりました。 つまり、Windows Ink や Fluent Design System をサポートするコントロールなど、UWP コントロールでのみ利用可能な最新の Windows 10 UI 機能で、既存のデスクトップ アプリケーションの外観、操作性、機能を拡張することができます。 この機能を XAML アイランドといいます。

「[デスクトップ アプリケーションの UWP コントロール](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)」を参照してください。

<a id="standard" />

### <a name="net-standard-20"></a>.NET Standard 2.0

この .NET Standard には、.NET Standard 1.x の API のほかに、さらに 20,000 個を超える API が含まれています。 これにより、はるかに簡単に既存の .NET Framework ライブラリを移行でき、UWP アプリケーションを含む、さまざまな .NET アプリケーション間で使用できるようになります。

![net-standard](images/dot-net-standard-project-template.png)

「[Share code between a desktop app and a UWP app](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-migrate)」 (デスクトップ アプリと UWP アプリでコードを共有する) を参照してください。

<a id="sql-server" />

### <a name="sql-server-connectivity"></a>SQL Server の接続

アプリで [System.Data.SqlClient](https://docs.microsoft.com/dotnet/api/system.data.sqlclient?redirectedfrom=MSDN&view=netframework-4.7.2) 名前空間のクラスを使用して、SQL Server データベースに直接接続し、データを保存および取得することができます。

「[UWP アプリでの SQL Server データベースの使用](https://docs.microsoft.com/en-us/windows/uwp/data-access/sql-server-databases)」をご覧ください。

<a id="MSIX" />

### <a name="msix-deployment"></a>MSIX の展開

MSIX は、あらゆる Windows アプリに最新のパッケージ化エクスペリエンスを提供する Windows アプリ パッケージ形式です。 MSIX パッケージ形式では、Win32、WPF、および Windows フォームに対して新たな、最新のパッケージ化および展開機能が有効になるだけでなく、既存のアプリ パッケージとインストール ファイルの機能が維持されます。

MSIX は、.msi、.appx、App-V および ClickOnce インストール テクノロジの組み合わせに基づき、安全な、セキュアで信頼性の高いものとなるように構築されたパッケージ化形式です。

![MSIX アイコン](images/MSIX-App-Package.ico)

「[MSIX documentation](https://docs.microsoft.com/windows/msix/)」 (MSIX ドキュメント) を参照してください。

<a id="distribution" />

## <a name="security"></a>セキュリティ

Windows 10 には、一連のセキュリティ機能が用意されています。これらの機能を利用することで、アプリ開発者は、ユーザーの個人情報、企業ネットワークのセキュリティ、デバイスに保存されているビジネス データを保護することができます。 Windows 10 の新機能として、Microsoft Passport があります。これにより、従来のパスワードに代わる 2 要素のパスワードを簡単に展開することができます。2 要素のパスワードは、PIN や Windows Hello を使って利用することができ、エンタープライズ レベルのセキュリティを実現し、指紋認識、顔認識、虹彩認識をサポートしています。

| トピック | 説明 |
|-------|-------------|
| [安全な Windows アプリの開発について](https://msdn.microsoft.com/library/windows/apps/mt622741) | この概要記事では、認証、移動中データ、および保存データの各段階におけるさまざまな Windows のセキュリティ機能について説明します。 また、これらの段階をアプリに統合する方法についても説明します。 ここでは、さまざまなトピックを取り上げており、ユニバーサル Windows プラットフォーム アプリを短時間で簡単に作成するための Windows の機能を、アプリの設計者が詳しく理解できるようにすることを主な目的としています。 |
| [認証とユーザー ID](https://msdn.microsoft.com/library/windows/apps/mt270184) | この記事では、UWP アプリで利用できるユーザー認証のためオプションを説明します。 企業向けには、新しい Microsoft Passport 機能を強くお勧めします。 Microsoft Passport では、既存の資格情報を確認して、生体認証または PIN ベースのユーザー ジェスチャで保護されるデバイス固有の資格情報を作成することで、パスワードを強力な 2 要素認証 (2FA) に置き換えます。これにより、便利で安全性の高いエクスペリエンスが実現されます。 |
| [暗号化](https://msdn.microsoft.com/library/windows/apps/mt270191) | 「暗号化」セクションでは、UWP アプリで利用できる暗号化の機能の概要を説明します。 この記事では、重要なビジネス データを簡単に暗号化する方法についての入門用チュートリアルから、暗号化キーの操作や MAC、ハッシュ、署名の使用などの高度なトピックまでを取り上げています。 |
| [Windows 情報保護 (WIP)](wip-hub.md) | ここでは、Windows 情報保護 (WIP) と、ファイル、バッファー、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護との関係について、開発者向けに全体像を説明します。 |

## <a name="data-binding-and-databases"></a>データ バインディングとデータベース

データ バインディングは、データベースなどの外部ソースからのデータをアプリの UI で表示する方法であり、必要に応じてそのデータとの同期を維持することもできます。 データ バインディングによって、UI の問題からデータの問題を切り離すことができるため、概念的なモデルが簡素化されると共に、アプリの読みやすさ、テストの容易性、保守容易性が向上します。

| トピック | 説明 |
|-------|-------------|
| [データ バインディングの概要](https://msdn.microsoft.com/library/windows/apps/mt269383) | このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目コントロールを項目のコレクションにバインドする方法を説明します。 また、項目のレンダリングを制御する方法、選択内容に基づいて詳細ビューを実装する方法、表示するデータを変換する方法も紹介します。 |
| [UWP 用 Entity Framework 7](https://msdn.microsoft.com/library/windows/apps/mt592863) | 大きなデータ セットに対する複雑なクエリの実行は、UWP をサポートする Entity Framework 7 を使用することで大幅に簡素化されます。 このチュートリアルでは、Entity Framework を使用してローカル SQLite データベースへの基本的なデータ アクセスを実行する UWP アプリを構築します。 |
| [SQLite ローカル データベース](https://channel9.msdn.com/Series/A-Developers-Guide-to-Windows-10/10) | このビデオは、アプリのローカル データベースのソリューションとして推奨される SQLite を使用するための開発者向けの包括的なガイドです。 [SQLite](https://www.sqlite.org/download.html) にアクセスして UWP 用の最新バージョンをダウンロードするか、Windows 10 SDK で既に提供されているバージョンを使用してください。 |

## <a name="networking-and-data-serialization"></a>ネットワークとデータのシリアル化

基幹業務アプリでは、他のさまざまなシステムのデータと通信したり、こうしたシステムにデータを保存したりすることが必要になる場合があります。 通常、これはネットワーク サービスに接続し (REST や SOAP などのプロトコルを使用)、データを一般的な形式にシリアル化または逆シリアル化することによって実現されます。 UWP アプリでのネットワークとデータのシリアル化の操作は、WPF、WinForms、ASP.NET の各アプリケーションと類似しています。 詳しくは、以下の記事をご覧ください。

| トピック | 説明 |
|-------|-------------|
| [ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233) | このチュートリアルでは、使用する通信プロトコルに関係なく、すべての UWP アプリに関連する基本的なネットワークの概念について説明します。  |
| [アプリに適したネットワーク テクノロジ](https://msdn.microsoft.com/library/windows/apps/mt280235) | UWP アプリで利用できるネットワーク テクノロジの概要と、アプリに適したテクノロジの選び方に関する推奨事項について説明します。 |
| [XML シリアル化および SOAP シリアル化](https://msdn.microsoft.com/library/90c86ass.aspx) | XML シリアル化では、オブジェクトが、特定の XML スキーマ定義言語 (XSD) に準拠する XML ストリームに変換されます。 XML と厳密に型指定されたクラス間の変換を行うには、ネイティブの [XDocument](https://msdn.microsoft.com/library/system.xml.linq.xdocument.aspx) クラスまたは外部ライブラリを使用します。 |
| [JSON シリアル化](https://msdn.microsoft.com/library/windows/apps/br240639) | JSON (JavaScript Object Notation) シリアル化は、REST API と通信するための一般的な形式です。 [Newtonsoft Json.NET](https://www.newtonsoft.com/json) は、UWP アプリで完全にサポートされています。 |

## <a name="devices"></a>デバイス

基幹業務ツール (プリンター、バー コード スキャナー、スマート カード リーダーなど) と統合するには、外部のデバイスやセンサーをアプリに統合することが必要になる場合があります。 ここでは、このセクションで説明するテクノロジを使って、アプリに追加できる機能例をいくつか紹介します。

| トピック  | 説明 |
|--------|-------------|
| [デバイスの列挙](https://msdn.microsoft.com/library/windows/apps/mt187355) | この記事では、[Windows.Devices.Enumeration](https://msdn.microsoft.com/library/windows/apps/br225459) 名前空間を使って、システムに内部接続されているデバイス、外部接続されているデバイス、ワイヤレス プロトコルまたはネットワーク プロトコル経由で検出できるデバイスを検索する方法について説明します。 デバイスと連携して動作するアプリを構築する場合は、ここから始めてください。 |
| [印刷とスキャン](https://msdn.microsoft.com/library/windows/apps/mt204544) | アプリから印刷およびスキャンする方法について説明します。販売時点管理 (POS) システム、レシート プリンター、大容量フィーダー スキャナーなどの業務用デバイスに接続する方法やこれらのデバイスを操作する方法についても説明します。 |
| [Bluetooth](https://msdn.microsoft.com/library/windows/apps/mt270288) | 従来の Bluetooth 接続を使用したデータの送受信やデバイスの制御に加えて、Windows 10 では、Bluetooth 低エネルギー (BTLE) を使用してバックグラウンドでビーコンを送受信できるようになりました。 この BTLE を利用して、通知を表示します。また、ユーザーが特定の場所に近づいた場合や特定の場所から離れた場合の機能を有効にします。 |
| [エンタープライズ共有記憶域](enterprise-shared-storage.md) | デバイスのロックダウン シナリオにおける、同じアプリ内でのデータの共有、また 1 つのアプリの複数のインスタンス間でのデータの共有、さらに複数のアプリ間でのデータの共有について、その方法を説明します。 |

## <a name="device-targeting"></a>対象となるデバイス

今日、多くのユーザーは自分の電話やタブレットを持ち歩いて作業を行っています。また、それらの電話やタブレットのフォーム ファクターと画面サイズにはさまざまなものがあります。 ユニバーサル Windows プラットフォーム (UWP) では、すべての種類のデバイス (デスクトップ PC や PPI ディスプレイなど) でシームレスに動作する 1 つの基幹業務アプリを作成して、アプリの範囲やコードの効率を最大限に高めることができます。

| トピック | 説明 |
|-------|-------------|
| [UWP アプリ ガイド](https://msdn.microsoft.com/library/windows/apps/dn894631) | この入門用ガイドでは、Windows 10 UWP プラットフォームについて説明します。ここでは、デバイス ファミリの説明、対象となるデバイス ファミリを決定する方法、さまざまなデバイスのフォーム ファクターに合わせて UI を対応させることができる新しい UI コントロールとパネル、およびアプリで利用できる API サーフェスを理解し制御する方法を取り上げます。 |
| [アダプティブ XAML UI コードのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=619992) | このコード サンプルでは、デバイスの種類に関係なく、アプリで利用できるすべてのレイアウト オプションとコントロールが示されています。また、このコード サンプルを使うと、パネルを操作して、目的のレイアウトを実現する方法を確認できます。 さまざまなフォーム ファクターに対する各コントロールの応答方法に加えて、アプリ自体の応答性、およびアダプティブ UI を実現するためのさまざまな方法も示されています。 |
| [Xamarin のトピック](/xamarin/) | 電話をターゲットとする Xamarin |

## <a name="deployment"></a>展開

組織のユーザーにアプリを配布するための方法がいくつかあります。 ビジネス向け Microsoft Store や既存のモバイル デバイス管理を使うことも、アプリをデバイスにサイドロードすることもできます。 Microsoft Store に公開すると、一般ユーザーにもアプリを利用可能にすることができます。

| トピック | 説明 |
|-------|-------------|
| [企業に LOB アプリを配布する](https://msdn.microsoft.com/library/windows/apps/mt608995) | 基幹業務アプリを、ボリューム購入できるように、ビジネス向け Microsoft Store で企業に直接公開できます。一般ユーザーが利用できるようにアプリを公開する必要はありません。 |
| [アプリのサイドローディング](https://technet.microsoft.com/library/mt269549) | アプリをサイドローディングすると、署名されたアプリ パッケージをデバイスに展開します。 これらのアプリの署名、ホスティング、配置は維持されます。 アプリのサイドローディングのプロセスは、Windows 10 向けに簡素化されています。             |
| [Microsoft Store にアプリを公開する](https://dev.windows.com/publish) | 統合された Microsoft Store では、すべての Windows デバイス向けのすべてのアプリを公開して管理することができます。 市場ごとの価格、配布と表示のコントロール、その他のオプションを使って、アプリの使用可能状況をカスタマイズできます。 |

## <a name="enterprise-uwp-samples"></a>エンタープライズ UWP のサンプル

| トピック |  説明 |
|------ |--------------|
| [VanArsdel インベントリのサンプル](https://github.com/Microsoft/InventorySample) | 基幹業務シナリオを紹介する UWP のサンプル アプリ。 サンプルは、架空の会社である VanArsdel の顧客、注文、製品の作成と管理に基づくものです。 |
| [顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database) | Azure Active Directory (AAD) 認証、UI コントロール (データ グリッドなど)、Sqlite および SQL Azure データベース統合、Entity Framework、クラウド API サービスのような、エンタープライズ開発者の役に立つ機能を紹介する UWP サンプル アプリ。 サンプルは、架空の会社である Contoso の顧客アカウント、注文、製品の作成と管理に基づくものです。 |

## <a name="patterns-and-practices"></a>パターンとプラクティス

大規模なエンタープライズ レベルのアプリ向けのコード ベースは、扱うのが難しくなる場合があります。 Prism は、保守やテストが可能である疎結合な XAML アプリケーションを WPF、Windows 10 UWP、および Xamarin の各フォームで構築するためのフレームワークです。 Prism には、適切に構造化され、保守が可能な XAML アプリケーションの作成に役立つ設計パターンのコレクションの実装が用意されています (MVVM、依存関係挿入、コマンド、EventAggregator など)。

Prism について詳しくは、[GitHub リポジトリ](https://github.com/PrismLibrary/Prism)をご覧ください。

 

 
