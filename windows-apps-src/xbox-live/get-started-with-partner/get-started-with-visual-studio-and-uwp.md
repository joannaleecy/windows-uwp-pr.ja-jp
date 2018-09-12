---
title: UWP ゲーム用 Visual Studio の概要
author: KevinAsgari
description: UWP ゲーム用に Xbox Live を有効にするように Visual Studio プロジェクトをセットアップする方法について説明します
ms.assetid: b53bc91f-79db-4d8f-8919-b9144e2d609b
ms.author: kevinasg
ms.date: 11/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d727171b079bc05851e1c7ab4de6f01587ce460d
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3928605"
---
# <a name="get-started-using-visual-studio-for-uwp-games"></a>UWP ゲーム用 Visual Studio の使用に関する概要

## <a name="requirements"></a>要件

1. **[デベロッパー センターの開発者プログラム](https://developer.microsoft.com/store/register)** に登録します。
2. **[Windows 10](https://microsoft.com/windows)**。
3. **[Visual Studio](https://www.visualstudio.com/)** の**ユニバーサル Windows アプリ開発ツール**を使用します。 UWP アプリのバージョンは、Visual Studio 2015 Update 3 を最低限に必要です。 開発者とセキュリティ更新プログラムの最新リリースの Visual Studio を使用することをお勧めします。 
4. **[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** 以降。

> [!IMPORTANT]
> Windows 10 SDK バージョン 10.0.15063.0 (Creators Update とも呼ばれます) 以降を使っている場合は、Visual Studio 2017 が必要です。

## <a name="create-a-new-product-on-microsoft-dev-center"></a>Microsoft デベロッパー センターで新しい製品を作成する

すべての Xbox Live タイトルには、[Microsoft デベロッパー センター](https://developer.microsoft.com/store)で作成された製品が必要です。これにより、サインインして Xbox Live サービスを呼び出すことができるようになります。 詳しくは、[UDC でのタイトルの作成に関するページ](create-a-new-title.md)をご覧ください。

## <a name="configuring-your-development-device"></a>開発用デバイスの構成

正常に Xbox Live にログインし、さまざまな Xbox Live サービスを呼び出すことができるように、デバイスでは、次のセットアップ手順を事前に実行しておく必要があります。

### <a name="set-your-sandbox"></a>サンドボックスを設定する

サンドボックスを使用すると、タイトルをリリースする準備ができるまで、[Xbox Live サービス構成](../xbox-live-service-configuration.md)を製品版から分離したままにしておくことができます。 蓄積するデータにはサンドボックス固有のものがあります。 たとえば、タイトルで*ヘッドショット*という統計が定義されていて、タイトルをテストしている間にユーザー アカウントにいくつかのヘッドショットが蓄積されているとします。 この値は、タイトルの開発サンドボックスに固有であり、製品版のタイトルのプレイに切り替えた場合、ヘッドショットは繰り越されません。

詳しい情報およびサンドボックスの設定方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」の記事をご覧ください。

### <a name="sign-in-with-a-test-account"></a>テスト アカウントによるサインイン

開発サンドボックスにサインインするには、テスト アカウントを作成するか、サンドボックスにアクセスするための通常の Microsoft アカウント (MSA) をプロビジョニングする必要があります。 これにより、開発中のタイトルに対するセキュリティが向上し、他のメリットを受けることができます。

テスト アカウントとその作成方法について詳しくは、「[Xbox Live テスト アカウント](../xbox-live-test-accounts.md)」をご覧ください。

## <a name="visual-studio-project-setup"></a>Visual Studio プロジェクトのセットアップ

### <a name="1-open-a-uwp-project"></a>1. UWP プロジェクトを開く
既存の UWP プロジェクトがない場合は、次の手順で作成できます。

1. Visual Studio で、**[ファイル]** > **[新規作成]** > **[プロジェクト]** の順に選択します。
2. **[新しいプロジェクト]** ダイアログ ボックスが表示されたら、左側のウィンドウで **[Visual C#]** > **[Windows]** > **[ユニバーサル]** ノードを選択し、右側のウィンドウで **[空白のアプリ (ユニバーサル Windows)]** をクリックします。
3. ダイアログ ボックスの下部で、プロジェクトに名前を付け、プロジェクトの場所を指定します。
4. Windows 10 SDK のターゲット バージョンと最小バージョンを指定します。 詳しくは、「[UWP バージョンの選択](https://docs.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version)」をご覧ください。

![VS でのプロジェクトの作成](../images/getting_started/vs-create-project.gif)

> [!NOTE]
> Xbox Live API (XSAPI) は、バージョン 10.0.10586.0 以上でなければなりません。

### <a name="2-add-references-to-the-xbox-live-api-xsapi-in-your-project"></a>2. プロジェクトで Xbox Live API (XSAPI) への参照を追加する

Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあり名前空間の構造は **Microsoft.Xbox.Live.SDK.*.UWP** と **Microsoft.Xbox.Live.SDK.*.XboxOneXDK** です。

1. **UWP** は、PC、Xbox One、Windows Phone で実行できる UWP ゲームをビルドしている開発者向けのものです。
2. **XboxOneXDK** は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。
3. C++ SDK は C++ ゲーム エンジンに使用できます。 WinRT SDK は、C++、C#、JavaScript を使って記述されたゲーム エンジン用です。
4. C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用してください。 C++ は、C++ ゲーム エンジンで使用する際に推奨される API です。  

> [!TIP]
> Xbox One での UWP の実行について詳しくは、「[Xbox One の UWP アプリ開発の概要](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started)」をご覧ください。

プロジェクトから Xbox Live API を使用するには、NuGet パッケージを使うか API ソースを追加してバイナリへの参照を追加します。 NuGet パッケージを追加するとコンパイルが高速になりますが、ソースを追加するとデバッグが簡単になります。 この記事では、NuGet パッケージを使う方法について説明します。 ソースを使用する場合は、「[UWP プロジェクトでの Xbox Live API ソースのコンパイル](add-xbox-live-apis-source-to-a-uwp-project.md)」をご覧ください。 Xbox Live SDK NuGet パッケージは次の方法で追加できます。

1. Visual Studio では、**[ツール]** > **[NuGet パッケージ マネージャー]** > **[ソリューションの NuGet パッケージの管理...]** の順に移動します。
2. NuGet パッケージ マネージャーで、**[参照]** をクリックして検索ボックスに「**Xbox.Live.SDK**」と入力します。
3. 左側の一覧から使う Xbox Live SDK のバージョンを選びます。 この場合、Microsoft.Xbox.Live.UWP パッケージを使います。
3. ウィンドウの右側にある、プロジェクトの横にあるチェック ボックスをオンにして **[インストール]** をクリックします。

![NuGet による XBL の追加](../images/getting_started/vs-add-nuget-xbl.gif)


> [!IMPORTANT]
> `Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、必ずプロジェクトのソースにヘッダー `#include <xsapi\services.h>` を含めてください。

### <a name="3-optional-using-connected-storage-andor-secure-sockets"></a>3. (省略可能) 接続ストレージやセキュア ソケットを使う
使う Windows SDK のバージョンによっては、Xbox Live の[接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)やセキュア ソケットを使うために、追加のコンテンツをインストールしたり、プロジェクトに参照を手動で追加したりする必要があります。 接続ストレージ機能を使う場合、`Windows.Gaming.XboxLive.Storage` 名前空間にアクセスする必要があります。 セキュア ソケットを使う場合、`Windows.Networking.XboxLive` にアクセスする必要があります。

#### <a name="windows-10-sdk-version-10016299-or-higher"></a>Windows 10 SDK バージョン 10.0.16299 以降
Windows 10 SDK 10.0.16299 以降をターゲットとした場合、追加の作業を行わなくても接続ストレージ名前空間にアクセスできるようになります。 セキュア ソケットにアクセスには、**UWP 用の Windows デスクトップ拡張機能**に参照を追加する必要があります。 そのためには、次のようにします。

1. **ソリューション エクスプローラー**で、**[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。
2. **[参照マネージャー]** ダイアログ ボックスの左側で、**[ユニバーサル Windows]** > **[拡張機能]** の順に選びます。
3. 表示される一覧で、**[Windows Desktop Extensions for UWP]** を検索し、使っている Windows 10 SDK に一致するバージョンの横のチェック ボックスをオンにします。
4. **[OK]** をクリックします。

![VS での新しい参照の追加](../images/getting_started/get-started-vs-add-ref.png)

#### <a name="windows-10-sdk-version-10015063-or-lower"></a>Windows 10 SDK バージョン 10.0.15063 以下
接続ストレージまたはセキュア ソケットを使用する場合は、プロジェクトに参照を追加する前に、Xbox Live Platform Extensions SDK をインストールする必要があります。 そのためには、次のようにします。

1. [Xbox Live Platform Extensions SDK](http://aka.ms/xblextsdk) をダウンロードして抽出します。
2. 抽出されたら、使っている Windows 10 SDK バージョンに対応するインクルード MSI ファイルを実行します。

Xbox Live Platform Extensions SDK をインストールしたら、Visual Studio で参照を追加する必要があります。 そのためには、次のようにします。

1. **ソリューション エクスプローラー**で、**[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。
2. **[参照マネージャー]** ダイアログ ボックスの左側で、**[ユニバーサル Windows]** > **[拡張機能]** の順に選びます。
3. 表示される一覧で、**[Windows Desktop Extensions for UWP]** を検索し、使っている Windows 10 SDK に一致するバージョンの横のチェック ボックスをオンにします。
4. **[OK]** をクリックします。

### <a name="4-associate-your-visual-studio-project-with-your-uwp-app"></a>4. Visual Studio のプロジェクトと UWP アプリを関連付ける

ゲームがサインインするには、Microsoft デベロッパー センターで既に作成した製品に関連付けられる必要があります。 ゲームは、Visual Studio で Microsoft Store 関連付けウィザードを使って関連付けることができます。 Visual Studio で、次のようにします。

1.  プライマリー プロジェクト (スタートアップ プロジェクト) を右クリックし、**[Microsoft Store]** > **[アプリケーションを Microsoft Store と関連付ける...]** の順にクリックします
2.  要求されたら、アプリの作成に使用した **Windows デベロッパー アカウント**でサインインし、画面の指示に従います。

> [!TIP]
> Microsoft Store 用のゲームの準備について詳しくは、「[アプリのパッケージ化](https://docs.microsoft.com/windows/uwp/packaging/)」をご覧ください。

### <a name="5-add-internet-capabilities-to-your-visual-studio-project"></a>5. インターネット機能を Visual Studio のプロジェクトに追加する
UWP プロジェクトが Xbox Live と通信するにはインターネット機能を指定する必要があります。 これらのプロパティは、次の方法で設定できます。

1. Visual Studio で **package.appxmanifest** ファイルをダブルクリックして、**マニフェスト デザイナー**を開きます。
2. **[機能]** タブをクリックし、**[インターネット (クライアント)]** をオンにします。

![VS での新しい参照の追加](../images/getting_started/get-started-vs-add-capability.png)

### <a name="6-associate-your-visual-studio-project-with-your-xbox-live-enabled-title"></a>6. Visual Studio のプロジェクトと Xbox Live 対応のタイトルを関連付ける

Xbox Live サービスと通信するには、プロジェクトにサービス構成ファイルを追加する必要があります。 次の方法で行うと簡単です。

1. スタートアップ プロジェクトで、右クリックして **[追加]** > **[新しい項目]** の順に選びます。
2. 種類として **[テキスト ファイル]** を選び、名前を **xboxservices.config** に設定します。
3. ファイルを右クリックして **[プロパティ]** を選び、以下の点を確認します。
    1. **[ビルド アクション]** が **[コンテンツ]** に設定されている。  
    2. **[出力ディレクトリにコピー]** が **[常にコピーする]** に設定されている。
5.  次のテンプレートを使用して構成ファイルを編集し、**TitleId** と **PrimaryServiceConfigId** をタイトルに適用される値に置き換えます。 Microsoft デベロッパー センターでのルート Xbox Live ページから適切な値を取得できます。 **PrimaryServiceConfigId** は、Microsoft デベロッパー センターでは **SCID** として表示されます。

```json
    {
       "TitleId" : "your title ID (JSON number in decimal)",
       "PrimaryServiceConfigId" : "your primary service config ID"
    }
```

次に、例を示します。

```json
    {
        "TitleId" : 1563044810,
        "PrimaryServiceConfigId" : "12200100-88da-4d8b-af88-e38f5d2a2bca"
    }
```

> [!TIP]
> xboxservices.config 内のすべての値で大文字と小文字が区別されます。 TitleID と PrimaryServiceConfigId の取得について詳しくは、「[サービス構成](../xbox-live-service-configuration.md)」をご覧ください。

### <a name="7-optional-add-multiplayer-capabilities"></a>7. (省略可能) マルチプレイヤー機能を追加する

マルチプレイヤーのサポートをタイトルに追加する予定があり、プレイヤーが他のユーザーをマルチプレイヤー ゲームに招待する機能を実装する場合は、別のフィールドを AppXManifest ファイルに追加する必要があります。 詳しくは、「[マルチプレイヤー用に AppXManifest を構成する](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md)」をご覧ください。

## <a name="learn-more"></a>詳細情報

[Xbox Live SDK サンプル](https://github.com/Microsoft/xbox-live-samples)では、Xbox Live API の使用方法が示されており、ID@Xbox プログラムで開発者が利用できる API も挙げられています。 サンプルを使用するには、サンドボックスを XDKS.1 に変更する必要があります。1。
