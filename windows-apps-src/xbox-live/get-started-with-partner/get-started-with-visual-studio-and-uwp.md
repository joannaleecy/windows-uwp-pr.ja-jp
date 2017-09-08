---
title: "UWP ゲーム用 Visual Studio の概要"
author: KevinAsgari
description: "UWP ゲーム用に Xbox Live を有効にするように Visual Studio プロジェクトをセットアップする方法について説明します"
ms.assetid: b53bc91f-79db-4d8f-8919-b9144e2d609b
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One"
ms.openlocfilehash: 9dc93bc0adf4709f586366145b5a978aa3fc2e77
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="get-started-using-visual-studio-for-uwp-games"></a>UWP ゲーム用 Visual Studio の使用に関する概要

## <a name="setup"></a>セットアップ

### <a name="software-requirements"></a>ソフトウェア要件

- Windows オペレーティング システム
    - Windows 8.1 (開発用コンピューターとして)
    - Windows 10 (開発用/テスト用コンピューターとして)
- Visual Studio
    - Visual Studio 2015。  [https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx](https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx) をご覧ください
        - Windows 10 SDK v10.0.14393.0 以降 [https://developer.microsoft.com/ja-JP/windows/downloads/windows-10-sdk](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)

### <a name="install-the-windows-10-sdk"></a>Windows 10 SDK をインストールする

Windows 10 SDK には、Windows 10 アプリを作成するための最新のヘッダー、ライブラリー、メタデータ、ツールが用意されています。 この SDK、最新の Visual Studio 2015 リリース、IDE 環境をインストールすることにより、新しい Windows 10 API にアクセスできます。 Windows 10 SDK を使用すると、ユニバーサル Windows アプリだけでなく Windows 10 用のデスクトップ アプリも作成できます。

この SDK は、通常、Visual Studio 2015 によってインストールおよび更新されます。  既に Visual Studio 2015 がインストールされている場合は、メニューの [ツール]、[拡張機能と更新プログラム] の順に移動し、[更新] タブを調べて、最新の Windows SDK をインストールします。

Visual Studio 2015 をお持ちでない場合は、[https://developer.microsoft.com/ja-JP/windows/downloads/windows-10-sdk](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk) でスタンドアロン バージョンをインストールできます。

### <a name="create-a-new-title-on-windows-dev-center"></a>Windows デベロッパー センターで新しいタイトルを作成する

Xbox Live にサインインできるようにするには、デベロッパー センターで新しい UWP タイトルを作成する必要があります。  実績の定義付けなど、サービス構成はタイトルに関連付けられています。

新しいタイトルを作成する方法については、「[新しいタイトルを作成する](create-a-new-title.md)」をご覧ください。

### <a name="configuring-your-development-device"></a>開発用デバイスの構成

正常に Xbox Live にログインし、さまざまな Xbox Live サービスを呼び出すことができるように、デバイスでは、次のセットアップ手順を事前に実行しておく必要があります。

#### <a name="set-your-sandbox"></a>サンドボックスを設定する

サンドボックスについて詳しくは、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」の記事をご覧ください。  記事を読んでからここに戻ってくることもできますが、簡単な概要は以下で確認できます。

サンドボックスを使用すると、タイトルをリリースする準備ができるまで、[Xbox Live サービス構成](../xbox-live-service-configuration.md)を製品版から分離したままにしておくことができます。  蓄積するデータにはサンドボックス固有のものがあります。  たとえば、タイトルで*ヘッドショット*という統計が定義されていて、タイトルをテストしている間にユーザー アカウントにいくつかのヘッドショットが蓄積されているとします。  この値は、タイトルの開発サンドボックスに固有であり、製品版のタイトルをプレイしている場合、それらのヘッドショットは繰り越されません。

詳しい情報およびサンドボックスの設定方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」の記事をご覧ください。

#### <a name="sign-in-with-a-test-account"></a>テスト アカウントによるサインイン

開発サンドボックスにサインインするには、テスト アカウントを作成するか、サンドボックスにアクセスするための通常の Microsoft アカウント (MSA) をプロビジョニングする必要があります。  これにより、開発中のタイトルに対するセキュリティが向上し、他のメリットを受けることができます。

テスト アカウントとその作成方法について詳しくは、「[Xbox Live テスト アカウント](../xbox-live-test-accounts.md)」をご覧ください。

#### <a name="sdk-samples"></a>SDK サンプル

Xbox Live API の使用方法を確認するには、SDK サンプルが適しています。

[https://github.com/Microsoft/xbox-live-samples](https://github.com/Microsoft/xbox-live-samples) の /Samples/ID@Xbox/ にあるサンプルでは、ID@Xbox プログラムの開発者が利用できる API を紹介しています。  

サンプルを使用するには、サンドボックスを XDKS.1 に変更する必要があります。サンドボックスの設定方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」をご覧ください。

## <a name="visual-studio-project-setup"></a>Visual Studio プロジェクトのセットアップ

### <a name="1-create-a-blank-project"></a>1. 空のプロジェクトを作成する

UWP アプリが既にある場合は、このステップを省略できます。

[スタート] メニューまたはタスク バーから Visual Studio 2015 を起動します。  
Visual Studio 2015 がインストールされていない場合は、[https://www.visualstudio.com/](https://www.visualstudio.com/) で入手できます。

![Visual Studio の起動](../images/VisualStudioStart.png)

Visual Studio を起動した後、図のように **[ファイル]** -> **[新規作成]** -> **[プロジェクト]** の順に選択します。

![](../images/VS_new_project.png)

**[新しいプロジェクト]** ダイアログ ボックスが表示されたら、左側のウィンドウで **[Visual C#]**、**[Windows]**、**[ユニバーサル]** ノードを選択し、右側のウィンドウで **[空白のアプリ (ユニバーサル Windows)]** をクリックします。  ダイアログ ボックスの下部で、プロジェクトの名前を指定します。

### <a name="2-add-references-to-the-xbox-live-api-xsapi-in-your-project"></a>2. プロジェクトで Xbox Live API (XSAPI) への参照を追加する

プロジェクトから Xbox Live API を使用するには、次のいずれかを実行します。

* Xbox Live API `binaries`への参照を NuGet パッケージの形式でプロジェクトに追加します。  `binaries`を参照すると、コンパイルの時間が短くなります。
<p/>
`or`
<p/>
* プロジェクトで Xbox Live API `source`への参照を追加します。  `source`を参照すると、デバッグが容易になります。

この記事では、NuGet パッケージを使用していると想定します。  ソースを使用する場合は、「[UWP プロジェクトでの Xbox Live API ソースのコンパイル](add-xbox-live-apis-source-to-a-uwp-project.md)」をご覧ください。

#### <a name="add-references-to-xbox-live-api-binaries-to-your-project"></a>プロジェクトに Xbox Live API バイナリへの参照を追加する
プロジェクトに Xbox Live API NuGet パッケージへの参照を追加するには、Visual Studio の [Nuget パッケージの管理] に移動します。

![](../images/getting_started/first_vstitle_nuget.png)

#### <a name="locate-xbox-live"></a>Xbox Live を検索する
NuGet の検索フィールドに "Xbox Live" (ただし引用符は付けない) と入力すると、以下に示す 4 種類の Xbox Live SDK が表示されます。

![](../images/getting_started/first_vstitle_nuget_xbox.png)

Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあります。  

`Microsoft.Xbox.Live.SDK.*.UWP` または `Microsoft.Xbox.Live.SDK.*.XboxOneXDK` を選択します。  `XboxOneXDK` は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。  `UWP` は、PC、Xbox One、Windows Phone で実行できる UWP ゲーム用のものです。  Xbox One での UWP の実行について詳しくは、[https://docs.microsoft.com/ja-jp/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started) をご覧ください。

`Microsoft.Xbox.Live.SDK.Cpp.*` または `Microsoft.Xbox.Live.SDK.WinRT.*` を選択します。 `Cpp` は、Xbox Live API を使用している C++ ゲーム エンジン用のものです。  `WinRT` は、Xbox Live API を使用し、C++、C#、または Javascript で記述されたゲーム エンジン用のものです。  C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。  `Cpp` は、C++ ゲーム エンジンで使用する際に推奨される API です。   

### <a name="optional-install-the-xbox-live-platform-extensions-sdk"></a>(オプション) Xbox Live Platform Extensions SDK をインストールする

接続ストレージまたはセキュア ソケットを使用する場合は、Xbox Live Platform Extensions SDK の zip ファイルを [http://aka.ms/xblextsdk](http://aka.ms/xblextsdk) からダウンロードする必要があります。

> **注:** Xbox Live クリエーターズ プログラムに参加している場合は、セキュア ソケットにはアクセスできません。  ただし、接続ストレージを使用できます。

zip ファイルをダウンロードした後、任意のフォルダーに内容を展開して、MSI をインストールします。  
パッケージには、UWP プラットフォーム用のネットワークのセキュリティ保護機能および接続ストレージ機能に関する winmd ファイルとドキュメントが含まれています。

Xbox Live Platform Extensions SDK をインストールすると、Visual Studio を使用して Extensions SDK への参照を追加し、次の名前空間をユニバーサル Windows プラットフォーム (UWP) ゲームで使用できます。

- Windows.Gaming.XboxLive.Storage
- Windows.Networking.XboxLive

### <a name="3-associate-your-visual-studio-project-with-your-uwp-app"></a>3. Visual Studio のプロジェクトと UWP アプリを関連付ける

アプリがサインインできるようにするには、デベロッパー センターで既に作成した UWP アプリにリンクする必要があります。  この関連付けを作成する方法を説明します。

**[ストア]** -> **[アプリケーションをストアと関連付ける…]**  オプションを Visual Studio で利用できる場合は、次の手順を実行します。

1.  Visual Studio 2015 でプロジェクトを開きます
1.  プライマリー プロジェクト (スタートアップ プロジェクト) を右クリックし、**[ストア]** -> **[アプリケーションをストアと関連付ける...]** の順にクリックします
1.  要求されたら、アプリの作成に使用した **Windows デベロッパー アカウント**でサインインします
1.  次のページで、作成したアプリを選択し、情報を確認して、**[関連付け]** をクリックします

**[ストア]** -> **[アプリケーションをストアと関連付ける…]**  オプションを Visual Studio で利用できない場合は、アプリのストア パッケージ ID を使用するように、アプリのパッケージ マニフェストを手動で更新することができます。

1.  Package.appxmanifest ファイルをテキスト エディターで開き、Identity ノードを **[アプリ名の予約]** セクションの **[アプリケーション ID]** に更新します。
1.  プロジェクトから .pfx ファイルを削除します (プロジェクトから除外するのでは不十分です)。

### <a name="4-associate-your-visual-studio-project-with-your-xbox-live-enabled-title"></a>4. Visual Studio のプロジェクトと Xbox Live 対応のタイトルを関連付ける

これを行うには、実行時に読み取るように Xbox Live SDK の構成ファイルを追加する必要があります。

1.  テキスト ファイルを作成し、名前を **xboxservices.config** に設定します。  ファイル拡張子が .config であることに注意してください。
1.  プライマリー プロジェクト (スタートアップ プロジェクト) にテキスト ファイルを追加します。
1.  ファイルを右クリックし、[プロパティ] を選択して、**[コンテンツ]** が **[はい]** に設定されているか、または **[ビルド アクション]** が **[コンテンツ]** に設定されていることを確認して、**[出力ディレクトリにコピー]** の **[常にコピーする]** を設定します。  これにより、ファイルは正しく AppX フォルダーにコピーされます。
1.  [項目の種類] は **[ビルドに含めない]** のままで問題ありません。
1.  次のテンプレートを使用して JSON ファイルを編集し、TitleId と PrimaryServiceConfigId を Windows デベロッパー センターから取得した値に置き換えます。  PrimaryServiceConfigId は、Windows デベロッパー センターでは "SCID" として表示されます。

```
    {
       "TitleId" : your title ID (JSON number in decimal),
       "PrimaryServiceConfigId" : "{your primary service config ID}"
    }
```

次に、例を示します。

```
    {
        "TitleId" : 1563044810,
        "PrimaryServiceConfigId" : "12200100-88da-4d8b-af88-e38f5d2a2bca"
    }
```

### <a name="5-if-you-plan-to-use-multiplayer-update-your-appxmanifest"></a>5. マルチプレイヤーを使う予定の場合は、AppXManifest を更新する

マルチプレイヤーのサポートをタイトルに追加する予定があり、プレイヤーが他のユーザーをマルチプレイヤー ゲームに招待する機能を実装する場合は、別のフィールドを AppXManifest ファイルに追加する必要があります。  「[マルチプレイヤー用に AppXManifest を構成する](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md)」をご覧ください。

### <a name="6-add-internet-capabilities-to-your-visual-studio-project"></a>6. インターネット機能を Visual Studio のプロジェクトに追加する

1. Visual Studio 2015 で **package.appxmanifest** ファイルをダブルクリックして、マニフェスト デザイナーを開きます。
2. **[機能]** タブをクリックします。
3. **[インターネット (クライアント)]** をクリックします。
4. ファイルを閉じて変更を保存します。

### <a name="7-change-the-sandbox-of-your-target-device"></a>7. ターゲット デバイスのサンドボックスを変更する

サンドボックスの設定方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」をご覧ください。

### <a name="8-learn-more"></a>8. 詳細情報

[https://github.com/Microsoft/xbox-live-samples](https://github.com/Microsoft/xbox-live-samples) の /Samples/ID@Xbox/ にあるサンプルでは、ID@Xbox プログラムの開発者が利用できる API を紹介しています。  サンプルを使用するには、サンドボックスを XDKS.1 に変更する必要があります。
