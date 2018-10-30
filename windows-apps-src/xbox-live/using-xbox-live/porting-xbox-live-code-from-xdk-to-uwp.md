---
title: XDK から UWP への Xbox Live コードの移植
author: KevinAsgari
description: Xbox Live コードを Xbox 開発キット (XDK) プラットフォームからユニバーサル Windows プラットフォーム (UWP) に移植する方法について説明します。
ms.assetid: 69939f95-44ad-4ffd-851f-59b0745907c8
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, XDK, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 40389232f5a1f6ab606720068fe8c9ac80fd5093
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5742853"
---
# <a name="porting-xbox-live-code-from-the-xbox-developer-kit-xdk-to-universal-windows-platform-uwp"></a>Xbox 開発キット (XDK) からユニバーサル Windows プラットフォーム (UWP) への Xbox Live コード移植

## <a name="introduction"></a>概要

この記事では、Xbox One XDK を使用していたデベロッパーが、その Xbox Live コードの Windows 10 ユニバーサル Windows プラットフォーム (UWP) への移行を開始できるように情報を提供します。

この移行の一環として、XSAPI 1.0 (Xbox Live Services API、August 2015 まで Xbox One XDK に含まれていました) から XSAPI 2.0 (November 2015 以降 の Xbox One XDK に含まれ、Xbox Live SDK でも利用できます) への切り替えがあります。 これらの API の機能は実質的に同一ですが、実装上の重要な相違点がいくつかあります。

この記事で取り上げるその他のトピックには、Windows 開発用コンピューターを準備すること、通常は Xbox Live サービスの使用時に必要になる、セキュア ソケット API やクラウド バックアップのゲーム セーブを管理するための接続ストレージ API などの API をインストールすることが含まれます。

<a name="_Setting_up_and"></a>

## <a name="setting-up-and-configuring-your-project-in-dev-center-and-xdp"></a>デベロッパー センターおよび XDP でのプロジェクトの設定と構成

Xbox Live サービスを使用する UWP タイトルは、 [Windows デベロッパー センター](https://dev.windows.com/en-us)または[Xbox デベロッパー ポータル (XDP)](https://xdp.xboxlive.com/)で構成する必要があります。 最新の情報については、[Xbox Live SDK](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx) に含まれる『Xbox Live プログラミング ガイド』の「[新規または既存の UWP プロジェクトに Xbox Live を追加する方法](../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)」を参照してください。

そのページのトピックには、タイトルで Xbox Live サービスを使用するための、以下の手順が含まれています。

-   Windows デベロッパー センターで UWP アプリ プロジェクトを作成する。

-   XDP を使用して、Xbox Live を使用するためにプロジェクトをセットアップする。

-   デベロッパー センターのプロダクトを XDP のプロダクトにリンクする。

-   XDP でデベロッパー アカウントを作成する (サンドボックスでの Xbox Live タイトルの実行時に必要)。

タイトルでマルチプレイヤー プレイをサポートする場合は、マルチプレイヤー セッション テンプレートで、いくつかの追加設定が必要になることがあります。 Xbox Live マルチプレイヤーを使用し、MPSD (Multiplayer Session Directory) に書き込みを行うすべての Windows 10 タイトルで、セッション テンプレートにある "機能" のリスト内に、```userAuthorizationStyle: true``` という新しいフィールドが必要です。

### <a name="enabling-cross-play"></a>クロス プレイの有効化

"クロス プレイ" (デバイス横断型のマルチプレイヤー ゲームを可能にする、Xbox One と PC ゲーム 間で共有される Xbox Live 構成) をサポートする予定であれば、この機能も、セッション テンプレートに **crossPlay: true** として追加する必要があります。

XDP でクロス プレイとその構成要件をサポートにすることに関する追加情報については、『Xbox Live プログラミング ガイド』の「XDP での XDK および UWP のクロスプレイ タイトルの取り込み」を参照してください。

また、プログラムに関するいくつかの考慮事項については、後の「[Xbox One および PC UWP 間のマルチプレイヤー クロス プレイのサポート](#_Supporting_multiplayer_cross-play)」を参照してください。

## <a name="setting-up-your-windows-development-environment"></a>Windows 開発環境のセットアップ

1.  [最新の **Xbox Live SDK** をダウンロード](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx)して、ローカルに抽出します。

2.  UWP 用にセキュア ソケット API や Game Save API (別名接続ストレージ API) が必要な場合は、[**Xbox Live Platform Extensions SDK** をインストール](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx)します。

3.  Visual Studio で、ユニバーサル Windows アプリ プロジェクトに Xbox Live サポートを追加します。 完全なソースを追加したり、Visual Studio のプロジェクトに NuGet パッケージをインストールしてバイナリを参照することができます。 C++ と WinRT の両方にパッケージが提供されています。 詳細については、「[新規または既存の UWP プロジェクトに Xbox Live を追加する方法](../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)」を参照してください

4.  開発用コンピューターを、サンドボックスを使用するように構成します。 Xbox Live SDK の Tools ディレクトリに、管理者のコマンド プロンプトから使用できるコマンド ライン スクリプト (例: SwitchSandbox.cmd XDKS.1) があります。

  **注** Retail サンドボックスに切り替える場合は、スクリプトによって変更されたレジストリ キーを削除しても、RETAIL という名前のサンドボックスに切り替えてもかまいません。

1.  開発用コンピューターにデベロッパー アカウントを追加します。 XDP で作成したデベロッパー アカウントは、割り当てられたサンドボックスでの開発時やサンプルの実行時には、ランタイムで Xbox Live サービスとやり取りする必要があります。 Windows に 1 つまたは複数のアカウントを追加するには、次の操作を行います。

    1.  **[設定]** を開きます (ショートカット: Windows キー + I)。

    2.  **[アカウント]** を開きます。

    3.  **[アカウント]** タブで、**[Microsoft アカウントを追加]** をクリックします。

    4.  デベロッパー アカウントの電子メールとパスワードを入力します。

### <a name="appxmanifest-changes"></a>AppXManifest の変更

Xbox バージョンの appxmanifest.xml ファイルと、UWP バージョンの appxmanifest.xml ファイルの最も一般的な変更点は次のとおりです。

1. UWP では、開発中であっても Package Identity が問題となります。 Identity の Name と Publisher が、デベロッパー センターで UWP アプリのために定義されたものと一致している*必要があります*。

1. Package Dependency セクションが必要です。 次に、例を示します。

```xml
  <Dependencies>
    <TargetDeviceFamily Name="Windows.Universal" MinVersion="10.0.10240.0" MaxVersionTested="10.0.10240.0" />
  </Dependencies>
```

1.  アプリケーション マニフェストの、UWP には固有の要件があるその他のセクションについては、UWP アプリケーション マニフェストの例 (たとえば、```<VisualElements>``` など、Xbox Live SDK に含まれる UWP サンプルの 1 つや、Visual Studio 内に作成される既定のユニバーサル Windows アプリ プロジェクト) を参照してください。

1.  タイトルと SCID は、"xbox.live" 拡張機能カテゴリーではなく、xboxservices.config ファイル ([次のセクション](#_Define_your_title)を参照) で定義されます。

1.  "xbox.system.resources" 拡張機能カテゴリーは必要ありません。

1.  セキュア ソケットは、"windows.xbox.networking" カテゴリーではなく、networkmanifest.xml ファイル (「[セキュア ソケット](#_Secure_sockets)」を参照) で定義されます。

1.  UWP タイトルで Xbox Live の招待を受信するためには、"windows.protocol" 拡張機能カテゴリーが定義されている必要があります (「[招待の送受信](#_Sending_and_receiving)」を参照)。

1.  GameChat API を使用する場合は、```<Capabilities>``` 要素内にマイク デバイスの機能を追加することをお勧めします。 次に、例を示します。

  ```<DeviceCapability Name="microphone">```

<a name="_Define_your_title"></a>

### <a name="define-your-title-and-scid-for-the-xbox-live-sdk-in-a-config-file"></a>config ファイルで、Xbox Live SDK のタイトルと SCID を定義する

Xbox Live SDK はタイトルの ID と SCID を知る必要がありますが、それらは UWP タイトルの appxmanifest.xml には含まれなくなっています。 代わりに、プロジェクトのルート ディレクトリ内に **xboxservices.config** という名前のテキスト ファイルを作成し、タイトルの情報で値を置き換えて次のフィールドを追加します。

```
{
  "TitleId": 123456789,
  "PrimaryServiceConfigId": "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
}
```

> [!NOTE]
> xboxservices.config 内のすべての値で大文字と小文字が区別されます。

ビルド出力で使用できるように、この config ファイルを内容としてプロジェクトに含めます。

**注** これらの値は、次の API を使用することによって、タイトル内でプログラムから使用可能になります。

```cpp
Microsoft::Xbox::Services::XboxLiveAppConfiguration^ xblConfig = xblContext->AppConfig;
unsigned int titleId = xblConfig->TitleId;
Platform::String^ scid = xblConfig->ServiceConfigurationId;
```

### <a name="api-namespace-mapping"></a>API 名前空間のマッピング

表 1:  XDK から UWP への名前空間のマッピング

<table>
  <tr>
    <td></td>
    <td><b>Xbox One XDK</b></td><td><b>UWP</b></td>
    <td><b>API の収録先</b></td>
  </tr>
  <tr>
    <td>Xbox サービス API (XSAPI)</td>
    <td>Microsoft::Xbox::Services</td>
    <td>Microsoft::Xbox::Services (<i>変更なし</i>)</td>
    <td>Xbox Live SDK (NuGet バイナリまたはソースを使用)</td>
  </tr>
  <tr>
    <td>GameChat</td>
    <td>
Microsoft::Xbox::GameChat Windows::Xbox::Chat </td>
    <td>
Microsoft::Xbox::GameChat (*変更なし*) Microsoft::Xbox::ChatAudio </td>
    <td>
Xbox Live SDK (NuGet binary バイナリを使用) </td>
  </tr>
  <tr>
    <td>SecureSockets</td>
    <td>Windows::Xbox::Networking</td>
    <td>Windows::Networking::XboxLive</td>
    <td>Xbox Live Platform Extensions SDK</td>
  </tr>
  <tr>
    <td>接続ストレージ</td>
    <td>Windows::Xbox::Storage</td>
    <td>Windows::Gaming::XboxLive::Storage</td>
    <td>Xbox Live Platform Extensions SDK</td>
  </tr>
</table>

### <a name="multiplayer-subscriptions-and-event-handling"></a>マルチプレイヤーのサブスクリプションとイベント処理

ほとんどのマルチプレイヤー タイトルに影響する XSAPI 1.0 から XSAPI 2.0 への最新の変更の 1 つは、いくつかのメソッドとイベントが **RealTimeActivityService** から **MultiplayerService** に移されたことです。

次に、例を示します。

-   **EnableMultiplayerSubscriptions()\*** メソッド

-   **DisableMultiplayerSubscriptions()** メソッド

-   **MultiplayerSessionChanged** イベント

-   **MultiplayerSubscriptionLost** イベント

-   **MultiplayerSubscriptionsEnabled** プロパティ

**実装に関する重要事項** これらのイベントやメソッドの **MultiplayerService** への移行後、**RealTimeActivityService** で他に何も明示的に使用していなくても、マルチプレイヤーのサブスクリプションには RTA サービスが必要なため、**EnableMultiplayerSubscriptions()** を呼び出す前に **xblContext-&gt;RealTimeActivityService-&gt;Activate()** を呼び出す必要があります。

## <a name="whats-handled-differently-in-uwp"></a>UWP では処理が異なる事柄

次の非常に大まかなリストは、新しい [NetRumble サンプル](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx) (XDK および UWP の両方のバージョンが含まれます) で確認できるような、XDK と UWP の間で違いがある可能性が高いコードのセクションを示しています。

-   タイトル ID と SCID 情報へのアクセス

-   起動前アクティベーション (UWP では新機能)

-   PLM 処理の一時停止/再開

-   拡張実行 (UWP では新機能)

-   Xbox の **User** オブジェクトとユーザー処理の違い

    -   サインインおよびサインアウトの処理

    -   コントローラーのペアリング (Xbox でのみ処理されます)

    -   コントローラーの処理

-   マルチプレイヤー権限の確認

-   Xbox One および PC の間のマルチプレイヤー クロスプレイのサポート

-   ゲームへの招待の送信

    -   ゲーム内からパーティー アプリを開く機能 (UWP では対象外)

    -   ゲーム内からパーティー メンバーを列挙する機能 (UWP では対象外)

-   ゲーマー プロフィールの表示

-   セキュア ソケット API サーフェスの変更

-   QoS 測定の開始と結果の処理

-   ゲーム イベントの書き込み

-   GameChat: イベント、設定、ChatUser オブジェクト

-   接続ストレージ API サーフェスの変更

-   PIX イベント (Xbox のみ、このホワイト ペーパーの範囲外)

-   レンダリングに関するいくつかの相違

後続のセクションでは、これらの違いの多くについて、さらに詳しく説明してゆきます。

### <a name="accessing-title-id-and-scid-info"></a>タイトル ID と SCID 情報へのアクセス

UWP では、タイトル ID とサービス構成 ID には、**XboxLiveContext** のインスタンスで、AppConfig プロパティを通じてアクセスします。

```cpp
Microsoft::Xbox::Services::XboxLiveAppConfiguration^ xblConfig = xblContext->AppConfig;
unsigned int titleId = xblConfig->TitleId;
Platform::String^ scid = xblConfig->ServiceConfigurationId;
```

**注** XDK では、これらの新しいプロパティまたは **Windows::Xbox::Services::XboxLiveConfiguration** の古い静的プロパティを使用して、これらの ID を取得できます。

### <a name="prelaunch-activation"></a>起動前アクティベーション

Windows 10 で頻繁に使用されるタイトルは、ユーザーがサインインするときにあらかじめ起動されていることがあります。 これに対処するため、タイトルには、**PreLaunchActivated** の起動引数をチェックするコードを含める必要があります。 たとえば、このような種類のアクティベーションの間にすべてのリソースを読み込む必要は、おそらくないでしょう。 詳細については、MSDN のホワイトペーパー「[アプリの事前起動の処理](https://msdn.microsoft.com/library/windows/apps/mt593297.ASPx)」を参照してください。

### <a name="suspendresume-plm-handling"></a>PLM 処理の一時停止/再開

一時停止と再開、および PLM 全般は、ユニバーサル Windows アプリでも Xbox One と同様に動作します。ただし、留意すべきいくつかの重要な相違点があります。

-   PC には **Constrained** 状態はありません。これは Xbox One 限定の概念です。

-   一時停止は、タイトルが最小化されると直ちに始まります。これを回避する方法については、「[拡張実行](#_Extended_execution)」を参照してください。

-   タイミングが異なります。一時停止するまで、本体では 1 秒ですが、PC では 5 秒あります。

接続ストレージを使用する場合の別の重要な考慮事項は、UWP バージョンのこの API に含まれる新しい **ContainersChangedSinceLastSync** プロパティです。 再開イベントを処理するときには、このプロパティをチェックして、タイトルの一時停止中にコンテナーがクラウドで変更されたかどうかを確認できます。 これは、プレイヤーが 1 つの PC でゲームを一時停止し、別の場所でプレイしてから最初の PC に戻った場合に起きることがあります。 一時停止する前にこれらのコンテナーからメモリーにデータを読み込んだ場合は、おそらく、それらを再度読み込んで何が変化したかを確認し、それに応じて変更に対処する必要があります。

Windows 10 における UWP アプリでの PLM 処理の詳細については、MSDN のホワイトペーパー「[起動、再開、バックグラウンド タスク](https://msdn.microsoft.com/library/windows/apps/xaml/mt227652.aspx)」を参照してください。

ゲームを念頭に置いて記述されていて、アプリのライフサイクルの処理に関する概念の大半は PC にも当てはまるため、GDN のホワイト ペーパー「[Xbox One の PLM](https://developer.xboxlive.com/en-us/platform/development/education/Documents/PLM%20for%20Xbox%20One.aspx)」も役立つ場合があります。

<a name="_Extended_execution"></a>

### <a name="extended-execution"></a>拡張実行

PC 上で UWP アプリを最小化すると、すぐに一時停止が始まります。 拡張実行を使用することによって、この処理を遅らせる機会が得られます。 実装例:

```cpp
using namespace Windows::ApplicationModel::ExtendedExecution;
//If this goes out of scope the request is nullified
ExtendedExecutionSession^ session;
void App::RequestExtension()
{
       if (!session)
       {
              session = ref new ExtendedExecutionSession();
       }
       session->Reason = ExtendedExecutionReason::Unspecified;
       session->Description = "foo";
       session->Revoked += ref new TypedEventHandler<Platform::Object^, ExtendedExecutionRevokedEventArgs^>(this, &App::ExtensionRevokedHandler);
       IAsyncOperation<ExtendedExecutionResult>^ request = session->RequestExtensionAsync();
       //At this point the request has been made. When the IAsyncOperation request completes, verify that the ExtendedExecutionResult == Allowed and you will not suspend for up to 10 minutes while minimized.
}

void App::ExtensionRevokedHandler(Platform::Object^ obj, ExtendedExecutionRevokedEventArgs^ args)
{
       if (args->Reason == Windows::ApplicationModel::ExtendedExecutionRevokedReason::Resumed)
       {
              //Request the extension again in preparation for the next suspend.
RequestExtension();
       }
       //The app will either complete suspending if the extension was revoked by system policy or resume running if the user has switched back to the app.
}

```

**ExtensionRevokedHandler** が呼び出された後は、その後一時停止が起きる場合に備えて新しい拡張機能が必要です。 システム内にメモリー負荷があり、10 分が経過するか、ゲームが最小化されているときにユーザーがゲームに戻ると、**ExtensionRevokedHandler** が呼び出されます。 そのため、おそらく以下のときに **RequestExtension()** を呼び出す必要があります。

-   起動時。

-   args-&gt;Reason == Resumed のときに **ExtensionRevokedHandler** 内で (ゲームが最小化されていて、10 分のタイマーが期限切れになる前にユーザーがタブで戻った)。

-   **OnResuming** ハンドラー内で (メモリー負荷または 10 分のタイマーのためにタイトルが一時停止された場合)。

### <a name="handling-users-and-controllers"></a>ユーザーとコントローラーの処理

Windows では、一度に 1 人のサインイン ユーザーを扱います。 Xbox Live SDK では、まず **XboxLiveUser** オブジェクトを作成し、それらを Xbox Live にサインインした後に、このユーザーから **XboxLiveContext** オブジェクトを作成します。

以前は、Xbox One XDK で次のようにしました。

1.  ユーザーを取得します (たとえばゲームパッドの対話から)。
2.  そのユーザーから **XboxLiveContext** を作成します。
  ```
  ref new Microsoft::Xbox::Services::XboxLiveContext( Windows::Xbox::System::User^ user )
  ```
1.  **SignOut** イベントを処理します。
  ```
  Windows::Xbox::System::User::SignOutStarted
  ```
1.  次のコードを使用してゲームパッド/コントローラーのペアリングを処理します。
  ```
  Windows::Xbox::Input::Controller::ControllerRemoved
  Windows::Xbox::Input::Controller::ControllerPairingChanged
  ```

今回、UWP/Xbox Live SDK については次のようにします。

1.  **XboxLiveUser** を作成します。

  ```
  auto xblUser = ref new Microsoft::Xbox::Services::System::XboxLiveUser();
  ```

1.  それらの UI 操作は行わずに、最後に使用された Microsoft アカウントを使用してサインインを試みます。

  ```
  xblUser->SignInSilentlyAsync();
  ```

1.  この非同期操作の結果内で **SignInResult::Success** を取得したら、**XboxLiveContext** を作成し、終了します。

  ```
  auto xblContext = ref new Microsoft::Xbox::Services::XboxLiveContext( xblUser );
  ```

1.  代わりに **SignInResult::UserInteractionRequired** が返された場合は、システム UI を表示させる対話型のサインイン メソッドを呼び出す必要があります。

  ```
  xblUser->SignInAsync();
  ```

1.  ここから **SignInResult::UserCancel** が返されることがあります。この場合、サインインしたユーザーがいないので、再度サインインを試みられるようにメニュー オプションを提供することを検討してください。

  **注** メニュー オプションを提供する場合は、異なる Microsoft アカウントに切り替えるオプションを提供することをお勧めします。

  ```
  xblUser->SwitchAccountAsync( nullptr );
  ```

1.  サインインしたユーザーがいる状態になったら、ユーザーのサインアウトに対応できるように **XboxLiveUser::SignOutCompleted** イベントをフックすることをお勧めします。

  ```
  xblUser->SignOutCompleted += ref new Windows::Foundation::EventHandler<Microsoft::Xbox::Services::System::SignOutCompletedEventArgs^>( &OnSignOutCompleted );
  ```

1.  Windows 10 で処理するコントローラーのペアリングはありません。

これは、C++/WinRT 向けに単純化した例です。 詳細な例については、『Xbox Live プログラミング ガイド』の「Xbox Live Authentication in Windows 10」を参照してください。 より幅広い例が紹介されている「Adding Xbox Live to a new UWP project」も役立つ可能性があります。

### <a name="checking-multiplayer-privileges"></a>マルチプレイヤー権限の確認

Xbox Live SDK で、**CheckPrivilegeAsync()** と同等のものはまだ利用できません。 現在のところ、**XboxLiveUser** の **Privileges** プロパティで返される文字列リストで、必要な権限を検索する必要があります。 たとえば、マルチプレイヤー権限を確認するには、権限 "254" を探します。 XDK ドキュメントを参考に、**Windows::Xbox::ApplicationModel::Store::KnownPrivileges** 列挙型で返されるすべての Xbox Live 権限のリストを確認できます。

このトピックに関する議論については、[xsapi とユーザー権限](https://forums.xboxlive.com/questions/48513/xsapi-user-privileges.html)についてのフォーラムの投稿を参照してください。

<a name="_Supporting_multiplayer_cross-play"></a>

### <a name="supporting-multiplayer-cross-play-between-xbox-one-and-pc-uwp"></a>Xbox One および PC UWP の間のマルチプレイヤー クロスプレイのサポート

XDP での新しいセッション テンプレートの要件 (「[デベロッパー センターおよび XDP でのプロジェクトの設定と構成](#_Setting_up_and)」を参照) に加えて、クロス プレイによってセッションへの参加機能に新しい制限が加わっています。 セッションへの参加制限として "None" を使用できなくなりました。 "Followed" または "Local" のいずれかを使用する必要があります (既定の制限は "Local")。

また、Windows 10 でのマルチプレイヤーに必要な **userAuthorizationStyle** 機能のために、参加と読み取りの制限は既定で "Local" になります。

このフォーラムのホワイトペーパー「[Is it possible to create a public multiplayer session](https://forums.xboxlive.com/questions/46781/is-it-possible-to-create-public-multiplayer-sessio.html)」には、さらに詳しい情報が記載されています。

さらに詳しい情報や例については、更新されたマルチプレイヤー デベロッパーのフローチャート、クロス プレイ対応マルチプレイヤーのサンプル NetRumble、または担当のデベロッパー アカウント マネージャー (DAM) から入手できます。

<a name="_Sending_and_receiving"></a>

### <a name="sending-and-receiving-invites"></a>招待の送受信

現在では、招待を送信するための UI を表示する API は **Microsoft::Xbox::Services::System::TitleCallableUI::ShowGameInviteUIAsync()** です。 アクティビティ セッション (通常はロビー) の、セッション-&gt; **SessionReference** オブジェクトを渡します。 必要に応じて、XDP のサービス構成で定義されたカスタムの招待文字列 ID を参照する 2 番目のパラメーターを渡すことができます。 そこで定義する文字列は、招待されたプレイヤーに送信されるトースト通知内に表示されます。 このメソッドのパラメーターとして ID 番号を渡すときには、番号がそのサービスにとって適切な形式になっている必要があることに注意してください。 たとえば、文字列 ID "1" は "///1" として渡す必要があります。

マルチプレイヤー サービスを使用して (つまり、どの UI も表示せずに) 招待を直接送信する場合でも、ユーザーの **XboxLiveContext** から他の招待メソッド **Microsoft::Xbox::Services::Multiplayer::MultiplayerService::SendInvitesAsync()** を使用することができます。

招待が Windows に到着してプロトコルでタイトルをアクティベーションできるようにするには、appxmanifest で、次の拡張機能を **&lt;Application&gt;** 要素に追加する必要があります。

```xml
<Extensions>
  <uap:Extension Category="windows.protocol">
    <uap:Protocol Name="ms-xbl-multiplayer" />
  </uap:Extension>
</Extensions>
```

**CoreApplication** が **Activated** イベントを取得し、アクティベーションの種類が **ActivationKind::Protocol** であれば、以前に Xbox One で行ったように招待を処理することができます。

### <a name="showing-the-gamer-profile-card"></a>ゲーマー プロフィール カードの表示

UWP 上にゲーマー プロフィール カードを表示するには、**Microsoft::Xbox::Services::System::TitleCallableUI::ShowProfileCardUIAsync()** を使用して、ターゲット ユーザーの XUID を渡します。

<a name="_Secure_sockets"></a>

### <a name="secure-sockets"></a>セキュア ソケット

セキュア ソケット API は、別の [Xbox Live Platform Extensions SDK](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx) に含まれています。

API の使い方については、フォーラムの投稿「[Setting up SecureDeviceAssociation for cross platform](https://forums.xboxlive.com/answers/45722/view.html)」を参照してください。

**注** UWP では、**SocketDescriptions** セクションが、appxmanifest の外部の、独自の [networkmanifest.xml](https://forums.xboxlive.com/storage/attachments/410-networkmanifestxml.txt) に移動されました。 &lt;SocketDescriptions&gt; 要素内の形式は、ほぼ同じで、**mx:** プレフィックスがないだけです。

Xbox および Windows 10 間のクロスプレイについては、2 種類のマニフェスト (Xbox One の Package.appxmanifest と Windows 10 の networkmanifest.xml) で、すべてが*まったく同じ*に定義されていることを*確認*してください。 ソケット名、プロトコルなどが*正確に*一致している必要があります。

クロスプレイの場合も、Xbox One の Package.appxmanifest と Windows 10 の networkmanifest.xml の*両方*で、```<AllowedUsages>``` 要素内に次の 4 つの SDA 使用法を定義する必要があります。

```xml
<SecureDeviceAssociationUsage Type="InitiateFromMicrosoftConsole" />
<SecureDeviceAssociationUsage Type="AcceptOnMicrosoftConsole" />
<SecureDeviceAssociationUsage Type="InitiateFromWindowsDesktop" />
<SecureDeviceAssociationUsage Type="AcceptOnWindowsDesktop" />
```

### <a name="multiplayer-qos-measurements"></a>マルチプレイヤー QoS の測定

セキュア ソケット API における名前空間の変更に加えて、オブジェクトの名前と値の一部も変更されています。 次の表に、よく使用される測定ステータスのマッピングを示します。

表 2:  よく使用される測定ステータスのマッピング

| XDK (Windows::Xbox::Networking::QualityOfServiceMeasurementStatus)  | UWP (Windows::Networking::XboxLive::XboxLiveQualityOfServiceMeasurementStatus)  |
|------------------------------------|--------------------------------------------|
| HostUnreachable                    | NoCompatibleNetworkPaths                   |
| MeasurementTimedOut                | TimedOut                                   |
| PartialResults                     | InProgressWithProvisionalResults           |
| Success                            | Succeeded                                  |

QoS (サービスの品質) の*測定*と*結果の処理*に必要な手順は、API の XDK バージョンと UWP バージョンを比較すると、基本的に同じです。 ただし、名前の変更といくつかの設計変更のために、一部の場所では結果のコードが異なってきます。

**XDK** のために QoS を測定する場合、セキュア デバイス アドレスのコレクションとメトリックのコレクションを作成し、それらを **MeasureQualityOfServiceAsync()** メソッドに渡していました。

**UWP** のために QoS を測定するには、新しい **XboxLiveQualityOfServiceMeasurement()** オブジェクトを作成し、その **Metrics** プロパティと **DeviceAddresses** プロパティに対して **Append()** を呼び出してから、オブジェクトの **MeasureAsync()** メソッドを呼び出します。

次に、例を示します。

```cpp
auto qosMeasurement = ref new Windows::Networking::XboxLive::XboxLiveQualityOfServiceMeasurement();
qosMeasurement->Metrics->Append(Windows::Networking::XboxLive::XboxLiveQualityOfServiceMetric::AverageInboundBitsPerSecond);
qosMeasurement->Metrics->Append(Windows::Networking::XboxLive::XboxLiveQualityOfServiceMetric::AverageOutboundBitsPerSecond);
qosMeasurement->Metrics->Append(Windows::Networking::XboxLive::XboxLiveQualityOfServiceMetric::AverageLatencyInMilliseconds);
qosMeasurement->NumberOfProbesToAttempt = myDefaultQosProbeCount;
qosMeasurement->TimeoutInMilliseconds = myDefaultQosMeasurementTimeout;

// Add secure addresses for each session member
for (const auto& member : session->GetMembers())
{
    if (!member->IsCurrentUser)
    {
        auto sda = member->SecureDeviceAddressBase64;

        if (!sda->IsEmpty())
        {
qosMeasurement->DeviceAddresses->Append(Windows::Networking::XboxLive::XboxLiveDeviceAddress::CreateFromSnapshotBase64(sda));
        }
    }
}

if (qosMeasurement->DeviceAddresses->Size > 0)
{
    qosMeasurement->MeasureAsync();
}

```

詳細な例については、NetRumble サンプルの **MatchmakingSession::MeasureQualityOfService()** 関数と **MatchmakingSession::ProcessQosMeasurements()** 関数を参照してください。

### <a name="writing-game-events"></a>ゲーム イベントの書き込み

タイトルのサービス構成で構成されたゲーム イベントを送信する場合、UWP には異なる API があります。 Xbox Live SDK は、**EventsService** とプロパティ バッグ モデルを使用します。

次に、例を示します。

```cpp
auto properties = ref new Windows::Foundation::Collections::PropertySet();
properties->Insert("RoundId", m_roundId);
properties->Insert("SectionId", safe_cast<Platform::Object^>(0));
properties->Insert("MultiplayerCorrelationId", m_multiplayerCorrelationId);
properties->Insert("GameplayModeId", safe_cast<Platform::Object^>(0));
properties->Insert("MatchTypeId", safe_cast<Platform::Object^>(0));
properties->Insert("DifficultyLevelId", safe_cast<Platform::Object^>(0));

auto measurements = ref new Windows::Foundation::Collections::PropertySet();

xblContext->EventsService->WriteInGameEvent("MultiplayerRoundStart", properties, measurements);

```

詳細については、Xbox Live SDK のドキュメントを参照してください。

**ヒント** Xbox Live SDK (Tools ディレクトリにあります) で提供される **xcetool.exe** を使用して、XDP からダウンロードした events.man ファイルを .h ヘッダー ファイルに変換することができます。 新しい v2 プロパティ バッグ スキーマを使用してこの C++ ヘッダーを生成するには、'-x' オプションを使用します。 このヘッダーには、構成済みのイベントすべてに対して呼び出すことができる、**EventWriteMultiplayerRoundStart()** などの C++ 関数が含まれます。 WinRT インターフェイスを優先的に使用する場合でも、このヘッダー ファイルを参照して、それぞれのイベントに対してプロパティと測定がどのように構築されているかを確認できます。

### <a name="game-chat"></a>ゲーム チャット

UWP での GameChat は、Xbox Live SDK に NuGet パッケージ バイナリとして含まれています。 この NuGet パッケージをプロジェクトに追加する方法については、『Xbox Live プログラミング ガイド』の手順を参照してください。

基本的な使用方法は、XDK バージョンと UWP バージョンでほとんど同じです。 API のいくつかの違いとしては、以下があります。

1.  **User::AudioDeviceAdded** イベントは、UWP タイトルによってフックされる必要はありません。 基になっているチャット ライブラリーがデバイスの追加と削除を処理します。

2.  **ChatUser** は、**GameChatUser** と呼ばれるようになっています。

3.  **Microsoft::Xbox::GameChat** 名前空間は同じままですが、**Windows::Xbox::Chat** 名前空間は **Microsoft::Xbox::ChatAudio** になっています。

4.  **AddLocalUserToChatChannelAsync()** は、**XboxUser** ではなく、XUID または **ChatAudio::IChatUser^** を受け取ります。

5.  **RemoveLocalUserFromChatChannelAsync()** には、**XboxUser** ではなく **ChatAudio::IChatUser^** が必要です。 **IChatUser** は、**GameChatUser**-&gt;**User** から取得できます。

### <a name="connected-storage"></a>接続ストレージ

接続ストレージ API は、別の [Xbox Live Platform Extensions SDK](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx) で提供されます。 ドキュメントは Xbox Live SDK ドキュメントに含まれています。

全体の流れは Xbox One での場合と同じですが、UWP バージョンには **ContainersChangedSinceLastSync** プロパティが追加されています。 このプロパティは、タイトルが再開イベントを処理するとき、**GetForUserAsync()** をもう一度呼び出した後に、タイトルが一時停止されていた間にクラウドでどのコンテナーに変更があったかを確認するために調べる必要があります。 変更があったいずれかのコンテナーからメモリーにロードされたデータがある場合は、おそらく、データを再度読み込んで何が変わったかを確認し、それに応じて変更を処理する必要があります。

UWP バージョンでその他に注目すべき相違点には以下のものがあります。

1.  **Windows::Xbox::Storage** から **Windows::Gaming::XboxLive::Storage** への名前空間の変更。

2.  **ConnectedStorageSpace** は、**GameSaveProvider** に名前が変更されています。

3.  **GetForUserAsync()** では、**XboxUser** の代わりに **Windows::System::User** が使用され、SCID が必要になっています。

4.  ローカルの "マシン" ストレージはありません (つまり、**GetForMachineAsync()** が削除されました)。 ローミングされないローカル セーブ データの代わりに **Windows::Storage::ApplicationData** を使用することを検討してください。

5.  例外が発生しない \*Result-type オブジェクト (たとえば **GameSaveProviderGetResult**) では非同期の結果が返されます。この結果から、**Status** プロパティをチェックできます。そしてエラーがない場合は、返されたオブジェクトを **Value** プロパティから読み込みます。

6.  **ConnectedStorageErrorStatus 列挙型**は **GameSaveErrorStatus** に名前が変更され、Result の **Status** プロパティで返されます。 古い値はすべて存在しており、新しい値がいくつか追加されています。

-   中止

-   ObjectExpired

-   OK

-   UserHasNoXboxLiveInfo

使い方の例については、GameSave サンプルや NetRumble サンプルを参照してください。

**注** Gamesaveutil.exe は xbstorage.exe (XDK 付属のデベロッパー向けコマンド ライン ユーティリティ) と同等です。 Xbox Live Platform Extensions SDK のインストール後、このユーティリティは C:\\Program Files (x86)\\Windows Kits\\10\\Extension SDKs\\XboxLive\\1.0\\Bin\\x64 にあります。

## <a name="summary"></a>まとめ

このホワイト ペーパーで概要を説明した API の変更と新しい要件は、既存のゲーム コードを Xbox One XDK から新しい UWP に移植するときにかかわる可能性が高いものです。 特に、アプリケーションと環境の設定に加えて、マルチプレイヤーや接続ストレージなど、Xbox Live サービスに関連する機能領域を重点的に取り上げました。 詳細については、このホワイトペーパー全体を通して提供したリンクと、次の参考文献のリンクを利用してください。また、さらに多くの助け、疑問への答え、最新情報については、[デベロッパー フォーラム](https://forums.xboxlive.com)の「Windows 10」セクションにアクセスしてください。

## <a name="references"></a>参考資料

-   [Xbox One から Windows 10 への移植](https://developer.xboxlive.com/en-us/platform/development/education/Documents/Porting%20from%20Xbox%20One%20to%20Windows%2010.aspx)

-   [Xbox One のホワイト ペーパー](https://developer.xboxlive.com/en-us/platform/development/education/Pages/WhitePapers.aspx)

-   [サンプル](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx)
