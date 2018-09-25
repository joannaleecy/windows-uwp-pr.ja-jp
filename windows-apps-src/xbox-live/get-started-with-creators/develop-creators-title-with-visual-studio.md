---
title: Visual Studio を使用してクリエーターズ タイトルを開発する
author: aablackm
description: Visual Studio を使用して、Xbox Live クリエーターズ プログラムのタイトルの開発を開始する
ms.assetid: 6952dac0-66ff-4717-b3c7-8b3792e834e3
ms.author: aablackm
ms.date: 11/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Xbox Live クリエーターズ, Visual Studio
ms.localizationpriority: medium
ms.openlocfilehash: 19ee781a7143c0da5b1549776646ab5b133a9667
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4175646"
---
# <a name="get-started-developing-an-xbox-live-creators-program-title-with-visual-studio"></a>Visual Studio を使用して、Xbox Live クリエーターズ プログラムのタイトルの開発を開始する

> [!NOTE]
> Unity で開発されたゲームに利用できるプラグインがあります。 詳しくは、「[Unity を使用してクリエーターズ タイトルを開発する](develop-creators-title-with-unity.md)」の記事をご覧ください。

## <a name="requirements"></a>要件

1. **[デベロッパー センターの開発者プログラム](https://developer.microsoft.com/store/register)** に登録します。
2. **[Windows 10](https://microsoft.com/windows)**。
3. **ユニバーサル Windows アプリ開発ツール**を搭載した **[Visual Studio 2015](https://www.visualstudio.com/)** (またはそれ以降)。
4. **[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** 以降。

> [!IMPORTANT]
> Windows 10 SDK バージョン 10.0.15063.0 (Creators Update とも呼ばれます) 以降を使っている場合は、Visual Studio 2017 が必要です。

## <a name="create-a-new-product-on-microsoft-dev-center"></a>Microsoft デベロッパー センターで新しい製品を作成する

すべての Xbox Live タイトルには、[Microsoft デベロッパー センター](https://developer.microsoft.com/store)で作成された製品が必要です。これにより、サインインして Xbox Live サービスを呼び出すことができるようになります。 詳しくは、「[新しいクリエーターズ タイトルの作成](create-and-test-a-new-creators-title.md)」をご覧ください。

## <a name="configuring-your-development-device"></a>開発用デバイスの構成

正常に Xbox Live にログインし、さまざまな Xbox Live サービスを呼び出すことができるように、デバイスでは、次のセットアップ手順を事前に実行しておく必要があります。

### <a name="set-your-sandbox"></a>サンドボックスを設定する

サンドボックスを使用すると、タイトルをリリースする準備ができるまで、[Xbox Live サービス構成](xbox-live-service-configuration-creators.md)を製品版から分離したままにしておくことができます。 蓄積するデータにはサンドボックス固有のものがあります。 たとえば、タイトルで*ヘッドショット*という統計が定義されていて、タイトルをテストしている間にユーザー アカウントにいくつかのヘッドショットが蓄積されているとします。 この値は、タイトルの開発サンドボックスに固有であり、製品版のタイトルのプレイに切り替えた場合、ヘッドショットは繰り越されません。

詳しい情報およびサンドボックスの設定方法については、「[Xbox Live のサンドボックス](xbox-live-sandboxes-creators.md)」の記事をご覧ください。

### <a name="sign-in-with-an-xbox-live-account-that-has-been-authorized-for-testing"></a>テスト用に承認された Xbox Live アカウントでログインする

開発サンドボックスにログインするには、サンドボックスへのアクセス用に通常の Microsoft アカウント (MSA) をプロビジョニングする必要があります。 これにより、開発中のタイトルに対するセキュリティが向上し、他のメリットを受けることができます。

テスト アカウントとその作成方法について詳しくは、「[環境内でテスト用の Xbox Live アカウントを承認する](authorize-xbox-live-accounts.md)」をご覧ください。

## <a name="visual-studio-project-setup"></a>Visual Studio プロジェクトのセットアップ

### <a name="1-open-a-uwp-project"></a>1. UWP プロジェクトを開く
既存の UWP プロジェクトがない場合は、次の手順で作成できます。

1. Visual Studio で、**[ファイル]** > **[新規作成]** > **[プロジェクト]** の順に選択します。
2. **[新しいプロジェクト]** ダイアログ ボックスが表示されたら、左側のウィンドウで **[Visual C#]** > **[Windows]** > **[ユニバーサル]** ノードを選択し、右側のウィンドウで **[空白のアプリ (ユニバーサル Windows)]** をクリックします。
3. ダイアログ ボックスの下部で、プロジェクトに名前を付け、プロジェクトの場所を指定します。
4. Windows 10 SDK のターゲット バージョンと最小バージョンを指定します。 詳しくは、「[UWP バージョンの選択](https://docs.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version)」をご覧ください。

![VS でのプロジェクトの作成](../images/getting_started/vs-create-project.gif)

> [!NOTE]
> > Xbox Live API (XSAPI) は、バージョン 10.0.10586.0 以上でなければなりません。

### <a name="2-add-references-to-the-xbox-live-api-xsapi-in-your-project"></a>2. プロジェクトで Xbox Live API (XSAPI) への参照を追加する
Xbox Services API には、C++ に使用できるものと WinRT に使用できるものがあり、名前の構造は **Microsoft.Xbox.Live.SDK.*.UWP** です。 Xbox One での UWP の実行について詳しくは、[https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started) をご覧ください。 C++ SDK は C++ ゲーム エンジンに使用できます。 WinRT SDK は、C++、C#、JavaScript を使って記述されたゲーム エンジン用です。 C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。 C++ は、C++ ゲーム エンジンで使用する際に推奨される API です。  

プロジェクトから Xbox Live API を使用するには、NuGet パッケージを使うか API ソースを追加してバイナリへの参照を追加します。 NuGet パッケージを追加するとコンパイルが高速になりますが、ソースを追加するとデバッグが簡単になります。 この記事では、NuGet パッケージを使う方法について説明します。 ソースを使用する場合は、「[UWP プロジェクトでの Xbox Live API ソースのコンパイル](../get-started-with-partner/add-xbox-live-apis-source-to-a-uwp-project.md)」をご覧ください。 Xbox Live SDK NuGet パッケージは次の方法で追加できます。

1. Visual Studio では、**[ツール]** > **[NuGet パッケージ マネージャー]** > **[ソリューションの NuGet パッケージの管理...]** の順に移動します。
2. NuGet パッケージ マネージャーで、**[参照]** をクリックして検索ボックスに「**Xbox.Live.SDK**」と入力します。
3. 左側の一覧から使う Xbox Live SDK のバージョンを選びます。 この場合、Microsoft.Xbox.Live.UWP パッケージを使います。
3. ウィンドウの右側にある、プロジェクトの横にあるチェック ボックスをオンにして **[インストール]** をクリックします。

![NuGet による XBL の追加](../images/getting_started/vs-add-nuget-xbl.gif)

#### <a name="optionally-include-xsapi-header-in-your-project"></a>必要に応じて、XSAPI ヘッダーをプロジェクトにインクルードする

Microsoft.Xbox.Live.SDK.Cpp.* ベースのプロジェクトの場合は、`xsapi\\services.h` を C++ プロジェクトにインクルードして、Xbox Live Service API (XSAPI) NuGet パッケージのヘッダーを取り込む必要があります。 XSAPI ヘッダーをインクルードする前に、`XBOX_LIVE_CREATORS_SDK` を定義する必要があります。 これにより、Xbox Live クリエーターズ プログラムの開発者が使用できる API のみに、API サーフェス領域が制限されます。 次に、例を示します。

```c++
#define XBOX_LIVE_CREATORS_SDK
#include "xsapi\services.h"
```
### <a name="3-optional-using-connected-storage"></a>3. (省略可能) 接続ストレージを使う
[接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)サービスを使う場合、`Windows.Gaming.XboxLive.Storage` 名前空間にアクセスする必要があります。 使う Windows SDK のバージョンによっては、それを使うために、追加のコンテンツをインストールしたり、プロジェクトに参照を手動で追加したりする必要があります。 Windows 10 SDK 10.0.16299 以降をターゲットとした場合、追加の作業を行わなくても接続ストレージ名前空間にアクセスできるようになります。

#### <a name="windows-10-sdk-version-10015063-or-lower"></a>Windows 10 SDK バージョン 10.0.15063 以下
接続ストレージを使用する場合は、プロジェクトに参照を追加する前に、Xbox Live Platform Extensions SDK をインストールする必要があります。 そのためには、次のようにします。

1. [Xbox Live Platform Extensions SDK](http://aka.ms/xblextsdk) をダウンロードして抽出します。
2. 抽出されたら、使っている Windows 10 SDK バージョンに対応するインクルード MSI ファイルを実行します。

Xbox Live Platform Extensions SDK をインストールしたら、Visual Studio で参照を追加する必要があります。 そのためには、次のようにします。

1. **ソリューション エクスプローラー**で、**[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。
2. **[参照マネージャー]** ダイアログ ボックスの左側で、**[ユニバーサル Windows]** > **[拡張機能]** の順に選びます。
3. 表示される一覧で、**[Windows Desktop Extensions for UWP]** を検索し、使っている Windows 10 SDK に一致するバージョンの横のチェック ボックスをオンにします。
4. **[OK]** をクリックします。

![VS での新しい参照の追加](../images/getting_started/get-started-vs-add-ref.png)

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
       "PrimaryServiceConfigId" : "your primary service config ID",
       "XboxLiveCreatorsTitle" : true
    }
```

次に、例を示します。

```json
    {
        "TitleId" : 1563044810,
        "PrimaryServiceConfigId" : "12200100-88da-4d8b-af88-e38f5d2a2bca",
        "XboxLiveCreatorsTitle" : true
    }
```

> [!TIP]
> xboxservices.config 内のすべての値で大文字と小文字が区別されます。 TitleID と PrimaryServiceConfigId の取得について詳しくは、「[サービス構成](../xbox-live-service-configuration.md)」をご覧ください。

## <a name="learn-more"></a>詳細情報

[Xbox Live SDK サンプル](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/CreatorsSDK)では、Xbox Live クリエーターズ プログラムの開発者が使用可能な API が示されています。 サンプルを使用するには、サンドボックスを XDKS.1 に変更する必要があります。1。
