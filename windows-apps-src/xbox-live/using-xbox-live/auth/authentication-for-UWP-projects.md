---
title: UWP プロジェクトの認証
author: aablackm
description: ユニバーサル Windows プラットフォーム (UWP) タイトルで Xbox Live ユーザーをサインインする方法について説明します。
ms.assetid: e54c98ce-e049-4189-a50d-bb1cb319697c
ms.author: aablackm
ms.date: 03/14/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 認証, サインイン
ms.localizationpriority: medium
ms.openlocfilehash: e6e833601bc02052a841c78bc4f140cb9f45e74f
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4359140"
---
# <a name="authentication-for-uwp-projects"></a>UWP プロジェクトの認証

ゲームで Xbox Live の機能を利用するために、ユーザーは Xbox Live プロフィールを作成し、Xbox Live コミュニティで自らの身元を明らかにする必要があります。  Xbox Live サービスは、ユーザーの Xbox Live プロフィール (ユーザーのゲーマータグやゲーマーアイコン、ユーザーが一緒にゲームをするフレンド、ユーザーがプレイしたゲーム、ユーザーがロック解除した実績、特定のゲームにおけるユーザーのランキング順位など) を使用してゲーム関連のアクティビティを追跡します。

特定のデバイス上の特定のゲームで Xbox Live サービスにアクセスしたいとき、ユーザーはまず認証を行う必要があります。  ゲームは Xbox Live API を呼び出して認証プロセスを開始できます。  追加情報を提供するためのインターフェイスがユーザーに提示される場合があります。たとえば、使用する Microsoft アカウントのユーザー名とパスワードを入力したり、ゲームにアクセス許可を付与することに同意したり、アカウントの問題を解決したり、新しい使用条件を承諾したりします。

認証されたユーザーは、Xbox アプリで Xbox Live から明示的にサインアウトするまで、そのデバイスと関連付けられます。  (すべての Xbox Live ゲームに対して) 1 台のデバイス上で同時に認証を受けられるのは 1 人のプレイヤーだけです。デバイス上で新しいプレイヤーが認証を行うには、まず既存の認証済みプレイヤーがサインアウトする必要があります。

## <a name="steps-to-sign-in"></a>サインイン手順

大まかには、以下の手順に従って Xbox Live API を使用します。

1. そのユーザーを表す XboxLiveUser オブジェクトを作成する
2. 起動時に暗黙的に Xbox Live にサインインする
3. 必要に応じて、UX を使用したサインインを試みる
4. 対話しているユーザーに基づいて Xbox Live コンテキストを作成する
5. 作成した Xbox Live コンテキストを使用して Xbox Live サービスにアクセスする
6. ゲームが終了またはユーザーがサインアウトしたら、XboxLiveUser オブジェクトと XboxLiveContext オブジェクトを null に設定して解放する

### <a name="creating-an-xboxliveuser-object"></a>XboxLiveUser オブジェクトの作成

ほとんどの Xbox Live アクティビティは Xbox Live ユーザーに関連します。  ゲーム デベロッパーは、まずローカル ユーザーを表す XboxLiveUser オブジェクトを作成する必要があります。

C++:

```cpp
auto xboxUser = std::make_shared<xbox_live_user>(Windows::System::User^ windowsSystemUser);
```

C++/CX (WinRT):

```cpp
XboxLiveUser xboxUser = ref new XboxLiveUser(Windows::System::User^ windowsSystemUser);
```

C# (WinRT):

```csharp
XboxLiveUser xboxUser = new XboxLiveUser(Windows.System.User windowsSystemUser);
```

* **windowsSystemUser** Xbox Live ユーザーとの関連付けに使う Windows システム ユーザー オブジェクト。 アプリがシングル ユーザー アプリケーション (SUA) の場合は nullptr になる可能性があります。
  * シングル ユーザー アプリケーション (SUA) とマルチ ユーザー アプリケーション (MUA) について詳しくは、「[マルチ ユーザー アプリケーションの概要](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/multi-user-applications#single-user-applications)」をご覧ください。
  * Windows から Windows::System::User^ を取得する方法について詳しくは、「[UWP での Windows システム ユーザーの取得](retrieving-windows-system-user-on-UWP.md)」を確認してください

### <a name="sign-in-silently-to-xbox-live-at-startup"></a>起動時に暗黙的に Xbox Live にサインインする ###

ゲームでは、Xbox Live サービスからデータをプリフェッチするために、起動後できるだけ早く、ユーザー インターフェイスを表示する前に、ユーザーの Xbox Live 認証を開始する必要があります。

ローカル ユーザーを暗黙的に認証するには、次の呼び出しを行います。

C++:

```cpp
pplx::task<xbox_live_result<sign_in_result>> xbox_live_user::signin_silently(Platform::Object^ coreDispatcher)
```

C++/CX (WinRT):

```cpp
Windows::Foundation::IAsyncOperation<SignInResult^>^ XboxLiveUser::SignInSilentlyAsync(Platform::Object^ coreDispatcher)
```

C# (WinRT):

```csharp
Microsoft.Xbox.Services.System.SignInResult XboxLiveUser.SignInSilentlyAsync(Windows.UI.Core.CoreDispatcher coreDispatcher);
```

* **coreDispatcher**

  Thread Dispatcher は、スレッド間の通信に使用されます。 サイレント サインイン API は UI をまったく表示しませんが、XSAPI には appx のロケールについての情報を取得するための UI スレッド ディスパッチャが引き続き必要です。 静的 UI スレッド ディスパッチャは、UI スレッドで Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher を呼び出すことで取得できます。 または、この API が UI スレッドで呼び出されることがはっきりしている場合、nullptr を渡すことができます (たとえば JS UWA など)。


暗黙的サインイン試行の結果には 3 つの可能性があります。

* **成功**

  デバイスがオンラインの場合、これはユーザーが Xbox Live に正しく認証され、有効なトークンを取得できたことを意味します。

  デバイスがオフラインの場合、これは、ユーザーが以前に Xbox Live に正しく認証されており、このタイトルから明示的にサインアウトしていないことを意味します。  この場合、タイトルが有効なトークンにアクセスできる保証はないことに注意してください。保証されるのはユーザーの身元が既知であり検証済みであることだけです。    タイトルは、ユーザーの身元を Xbox ユーザー ID (xuid) とゲーマータグによって認識しています。

* **UserInteractionRequired**

  ランタイムでユーザーの暗黙的サインインができませんでした。  ゲームでは、ユーザーがサインアップ/サインインするために必要な UX フローを表示する Xbox Identity Provider を呼び出す `xbox_live_user::sign_in` を呼び出す必要があります。  一般的な問題は次のとおりです。

  * ユーザーが Microsoft アカウントを持っていない
  * ユーザーがゲーム用の優先 Microsoft アカウントを設定していない
  * 選択された Microsoft アカウントに Xbox Live プロフィールがない
  * Microsoft アカウントの規約にユーザーが同意する必要がある

* **その他のエラー**

  ランタイムはその他の理由によりサインインできませんでした。  通常、ゲームまたはユーザーではこれらの問題に対処できません。 c++ API を使う場合、WinRT で xbox_live_result<>.err(); を確認してエラーをチェックし、Platform::Exception^ をキャッチする必要があります。

### <a name="attempt-to-sign-in-with-ux-if-required"></a>必要に応じて、UX を使用したサインインを試みる ###

暗黙的サインインに失敗し、ユーザー インターフェイスを表示する準備ができている場合、ゲームは UX を有効にしてユーザーを Xbox Live に対して認証する必要があります。

UX を使用してローカル ユーザーを認証するには、次の呼び出しを行います。

C++:

```cpp
pplx::task<xbox_live_result<sign_in_result>> xbox_live_user::signin(Platform::Object^ coreDispatcher)
```


C++/CX (WinRT):

```cpp
Windows::Foundation::IAsyncOperation<SignInResult^>^ XboxLiveUser::SignInAsync(Platform::Object^ coreDispatcher)
```

C# (WinRT):

```csharp
Microsoft.Xbox.Services.System.SignInResult  XboxLiveUser.SignInAsync(Windows.UI.Core.CoreDispatcher coreDispatcher);
```

* **coreDispatcher**

  Thread Dispatcher は、スレッド間の通信に使用されます。 サインイン API には、サインイン UI を表示して appx のロケールについての情報を取得するために UI ディスパッチャが必要です。 静的 UI スレッド ディスパッチャは、UI スレッドで Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher を呼び出すことで取得できます。 または、この API が UI スレッドで呼び出されることがはっきりしている場合、nullptr を渡すことができます (たとえば JS UWA など)。

UX を使用したサインイン試行の結果には 3 つの可能性があります。

* **成功**

  デバイスがオンラインの場合、これはユーザーが Xbox Live に正しく認証され、有効なトークンを取得できたことを意味します。

  デバイスがオフラインの場合、これは、ユーザーが以前に Xbox Live に正しく認証されており、このタイトルから明示的にサインアウトしていないことを意味します。  この場合、タイトルが有効なトークンにアクセスできる保証はないことに注意してください。保証されるのはユーザーの身元が既知であり検証済みであることだけです。    ユーザーの身元は、Xbox ユーザー ID (xuid) とゲーマータグによってタイトルに知られます。

* **UserCancel**

  サインイン操作が完了する前にユーザーが操作をキャンセルしました。  このとき、ゲームでは UX を使用したサインインを自動的に再試行しないでください。  代わりに、ユーザーがサインイン操作を再試行できるゲーム内 UX を表示してください。  (例: サインイン ボタン)

* **その他のエラー**

  ランタイムはその他の理由によりサインインできませんでした。  通常、ゲームまたはユーザーではこれらの問題に対処できません。 c++ API を使う場合、WinRT で xbox_live_result<>.err(); を確認してエラーをチェックし、Platform::Exception^ をキャッチする必要があります。

## <a name="sign-in-code-examples"></a>サインイン コードの例

### <a name="c"></a>C++

```cpp

#include "xsapi\services.h" // contains the xbox::services::system namespace

using namespace xbox::services::system; // contains definitions necessary for sign-in

void SignInSample::SignIn()
{
    //1. Create an xbox_live_user object
    m_user = std::make_shared<xbox::services::system::xbox_live_user>(); // m_user declared in header file

    //2. Sign-In silently to Xbox Live at startup
    m_user->signin_silently()
        .then([this](xbox::services::xbox_live_result<xbox::services::system::sign_in_result> result)
    {
        if (!result.err())
        {
            auto rPayload = result.payload();
            switch (rPayload.status())
            {
            case xbox::services::system::sign_in_status::success:
                // sign-in successful
                signIn = true;
                break;
            case xbox::services::system::sign_in_status::user_interaction_required:
                // 3. Attempt to sign-in with UX if required
                m_user->signin(Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher)
                    .then([this](xbox::services::xbox_live_result<xbox::services::system::sign_in_result> loudResult) // use task_continuation_context::use_current() to make the continuation task running in current apartment 
                {
                    if (!loudResult.err())
                    {
                        auto resPayload = loudResult.payload();
                        switch (resPayload.status())
                        {
                        case xbox::services::system::sign_in_status::success:
                            // sign-in successful
                            signIn = true;
                            break;
                        case xbox::services::system::sign_in_status::user_cancel:
                            // user cancelled sign in 
                            // present in-game UX that allows the user to retry the sign-in operation. (For example, a sign-in button)
                            break;
                        }
                    }
                    else
                    {
                        //login has failed at this point
                    }
                }, concurrency::task_continuation_context::use_current());
                break;
            }
        }
    });
    if (signIn)
    {
        // 4. Create an Xbox Live context based on the interacting user
        m_xboxLiveContext = std::make_shared<xbox::services::xbox_live_context>(m_user); // m_xboxLiveContext declared in header file

        // add sign out event handler
        AddSignOut();
    }
}

void SignInSample::AddSignOut()
{
    xbox::services::system::xbox_live_user::add_sign_out_completed_handler(
        [this](const xbox::services::system::sign_out_completed_event_args&)

    {
        // 6. When the game exits or the user signs-out, release the XboxLiveUser object and XboxLiveContext object by setting them to null
        m_user = NULL;
        m_xboxLiveContext = NULL;
    });
}

```

### <a name="c-winrt"></a>C# (WinRT)

```csharp

using System.Diagnostics;
using Microsoft.Xbox.Services.System;
using Microsoft.Xbox.Services;

public async Task SignIn()
{
    bool signedIn = false;

    // Get a list of the active Windows users.
    IReadOnlyList<Windows.System.User> users = await Windows.System.User.FindAllAsync();

    // Acquire the CoreDispatcher which will be required for SignInSilentlyAsync and SignInAsync.
    Windows.UI.Core.CoreDispatcher UIDispatcher = Windows.UI.Xaml.Window.Current.CoreWindow.Dispatcher; 

    try
    {
        // 1. Create an XboxLiveUser object to represent the user
        XboxLiveUser primaryUser = new XboxLiveUser(users[0]);

        // 2. Sign-in silently to Xbox Live
        SignInResult signInSilentResult = await primaryUser.SignInSilentlyAsync(UIDispatcher);
        switch (signInSilentResult.Status)
        {
            case SignInStatus.Success:
                signedIn = true;
                break;
            case SignInStatus.UserInteractionRequired:
                //3. Attempt to sign-in with UX if required
                SignInResult signInLoud = await primaryUser.SignInAsync(UIDispatcher);
                switch(signInLoud.Status)
                {
                    case SignInStatus.Success:
                        signedIn = true;
                        break;
                    case SignInStatus.UserCancel:
                        // present in-game UX that allows the user to retry the sign-in operation. (For example, a sign-in button)
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        if(signedIn)
        {
            // 4. Create an Xbox Live context based on the interacting user
            Microsoft.Xbox.Services.XboxLiveContext m_xboxLiveContext = new Microsoft.Xbox.Services.XboxLiveContext(user);

            //add the sign out event handler
            XboxLiveUser.SignOutCompleted += OnSignOut;
        }
    }
    catch (Exception e)
    {
        Debug.WriteLine(e.Message);
    }

}

public void OnSignOut(object sender, SignOutCompletedEventArgs e)
    {
        // 6. When the game exits or the user signs-out, release the XboxLiveUser object and XboxLiveContext object by setting them to null
        primaryUser = null;
        xboxLiveContext = null;
    }
```

## <a name="sign-out"></a>サインアウト

### <a name="handling-user-sign-out-completed-event"></a>ユーザーのサインアウト完了イベントの処理

以下のいずれかが発生した場合、ユーザーはタイトルからサインアウトします。

1. ユーザーが Xbox アプリ (Windows 10) または本体シェル (Xbox One) からサインアウトした。 サインアウトすることは、このユーザー用にインストールされたすべての Xbox Live 対応アプリに影響します。
2. ユーザーが別の Microsoft アカウントに切り替えた
3. ユーザーが別のデバイスから同じタイトルにサインインした

以上すべてのケースで、タイトルは `xbox_live_user::add_sign_out_completed_handler` または `XboxLiveUser::SignOutCompleted` ハンドラーからイベントを受け取ります。  ゲームではサインアウト完了イベントを適切に処理する必要があります。

1. ゲームでは、ユーザーが Xbox Live からサインアウトしたことを視覚的にユーザーに明示する必要があります。
2. ユーザーが既にサインアウトしており、利用可能な承認トークンがないため、ゲームはイベント ハンドラーでいかなる Xbox Live サービス API も呼び出すことができません。

## <a name="sign-out-handler-code-samples"></a>サインアウト ハンドラー コードのサンプル

### <a name="c"></a>C++

```cpp

xbox::services::system::xbox_live_user::add_sign_out_completed_handler(
        [this](const xbox::services::system::sign_out_completed_event_args&)

    {
        // 6. When the game exits or the user signs-out, release the XboxLiveUser object and XboxLiveContext object by setting them to null
        m_user = NULL;
        m_xboxLiveContext = NULL;
    });

```

### <a name="c-winrt"></a>C# (WinRT)

```csharp
XboxLiveUser.SignOutCompleted += OnUserSignOut;

public void OnSignOut(object sender, SignOutCompletedEventArgs e)
        {
            // 6. When the game exits or the user signs-out, release the XboxLiveUser object and XboxLiveContext object by setting them to null
            primaryUser = null;
            xboxLiveContext = null;
        }
```

## <a name="determining-if-the-device-is-offline"></a>デバイスがオフラインかどうかの判定

ユーザーが一度サインインしている場合は、オフラインのときでもサインイン API が成功し、前回サインインしたアカウントが返されます。

タイトルがオフラインでプレイできる場合 (キャンペーン モードなど): デバイスがオンラインかオフラインかを問わず、タイトルは、WriteInGameEvent API と接続ストレージ API によってゲームの進行状況を再生および記録することをユーザーに許可できます。これらの API はどちらも、デバイスがオフラインの状態で正しく動作します。

タイトルがオフラインでプレイできない場合 (マルチプレイヤー ゲーム、サーバー ベースのゲームなど): タイトルは GetNetworkConnectivityLevel API を呼び出して、デバイスがオフラインかどうかを調べ、状態および解決方法 (例: "続行するにはインターネットに接続する必要があります…") をユーザーに通知する必要があります。

## <a name="online-status-code-samples"></a>オンライン状態コードのサンプル

### <a name="c"></a>C++

```cpp

using namespace Windows::Networking::Connectivity;

//Retrieve the ConnectionProfile
ConnectionProfile^ InternetConnectionProfile = NetworkInformation::GetInternetConnectionProfile();

NetworkConnectivityLevel connectionLevel = InternetConnectionProfile->GetNetworkConnectivityLevel();

switch (connectionLevel)
{
case NetworkConnectivityLevel::InternetAccess:
    // User is connected to the internet.
    break;
case NetworkConnectivityLevel::ConstrainedInternetAccess: //Limited Internet Access Possible Authentication Required
     // display error message for user.
    LogConnectivityLine("Game Offline: Limited internet access, browser authentication may be required. "); //function writes to UI
    break;
default:
    LogConnectivityLine("Game Offline: No internet access.");
    break;
}

```

### <a name="c-winrt"></a>C# (WinRT)

```csharp
using Windows.Networking.Connectivity;

//Retrieve the ConnectionProfile
string connectionProfileInfo = string.Empty;
ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();

NetworkConnectivityLevel connectionLevel = InternetConnectionProfile.GetNetworkConnectivityLevel();

switch(connectionLevel)
    {
        case NetworkConnectivityLevel.InternetAccess:
            // User is connected to the internet.
            break;
        case NetworkConnectivityLevel.ConstrainedInternetAccess: //Limited Internet Access Possible Authentication Required
            // display error message for user.
            LogConnectivityLine("Game Offline: Limited internet access, browser authentication may be required. "); //function writes to UI
            break;
        default:
            LogConnectivityLine("Game Offline: No internet access.");
            break;
    }
```