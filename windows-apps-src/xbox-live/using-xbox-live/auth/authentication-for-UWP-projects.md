---
title: "UWP プロジェクトの認証"
author: KevinAsgari
description: "ユニバーサル Windows プラットフォーム (UWP) タイトルで Xbox Live ユーザーをサインインする方法について説明します。"
ms.assetid: e54c98ce-e049-4189-a50d-bb1cb319697c
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 認証, サインイン"
ms.openlocfilehash: 82ea421e8697d0231cd8ab00d42481594aee2145
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="authentication-for-uwp-projects"></a>UWP プロジェクトの認証

ゲームで Xbox Live の機能を利用するために、ユーザーは Xbox Live プロフィールを作成し、Xbox Live コミュニティで自らの身元を明らかにする必要があります。  Xbox Live サービスは、ユーザーの Xbox Live プロフィール (ユーザーのゲーマータグやゲーマーアイコン、ユーザーが一緒にゲームをするフレンド、ユーザーがプレイしたゲーム、ユーザーがロック解除した実績、特定のゲームにおけるユーザーのランキング順位など) を使用してゲーム関連のアクティビティを追跡します。

特定のデバイス上の特定のゲームで Xbox Live サービスにアクセスしたいとき、ユーザーはまず認証を行う必要があります。  ゲームは Xbox Live API を呼び出して認証プロセスを開始できます。  追加情報を提供するためのインターフェイスがユーザーに提示される場合があります。たとえば、使用する Microsoft アカウントのユーザー名とパスワードを入力したり、ゲームにアクセス許可を付与することに同意したり、アカウントの問題を解決したり、新しい使用条件を承諾したりします。

認証されたユーザーは、Xbox アプリで Xbox Live から明示的にサインアウトするまで、そのデバイスと関連付けられます。  (すべての Xbox Live ゲームに対して) 1 台のデバイス上で同時に認証を受けられるのは 1 人のプレイヤーだけです。デバイス上で新しいプレイヤーが認証を行うには、まず既存の認証済みプレイヤーがサインアウトする必要があります。

大まかには、以下の手順に従って Xbox Live API を使用します。

1. そのユーザーを表す XboxLiveUser オブジェクトを作成する
2. 起動時に暗黙的に Xbox Live にサインインする
3. 必要に応じて、UX を使用したサインインを試みる
4. 対話しているユーザーに基づいて Xbox Live コンテキストを作成する
5. 作成した Xbox Live コンテキストを使用して Xbox Live サービスにアクセスする
6. ゲームが終了またはユーザーがサインアウトしたら、XboxLiveUser オブジェクトと XboxLiveContext オブジェクトを null に設定して解放する

### <a name="creating-an-xboxliveuser-object"></a>XboxLiveUser オブジェクトの作成 ###
ほとんどの Xbox Live アクティビティは Xbox Live ユーザーに関連します。  ゲーム デベロッパーは、まずローカル ユーザーを表す XboxLiveUser オブジェクトを作成する必要があります。

C++:
```
auto user = std::make_shared<xbox_live_user>(Windows::System::User^ windowsSystemUser);
```

WinRT:
```
XboxLiveUser user = ref new XboxLiveUser(Windows::System::User^ windowsSystemUser);
```

* **windowsSystemUser** Xbox Live ユーザーとの関連付けに使う Windows システム ユーザー オブジェクト。 アプリがシングル ユーザー アプリケーション (SUA) の場合は nullptr になる可能性があります。
  * シングル ユーザー アプリケーション (SUA) とマルチ ユーザー アプリケーション (MUA) について詳しくは、「[マルチ ユーザー アプリケーションの概要](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/multi-user-applications#single-user-applications)」をご覧ください。
  * Windows から Windows::System::User^ を取得する方法について詳しくは、「[UWP での Windows システム ユーザーの取得](retrieving-windows-system-user-on-UWP.md)」を確認してください

### <a name="sign-in-silently-to-xbox-live-at-startup"></a>起動時に暗黙的に Xbox Live にサインインする ###
ゲームでは、Xbox Live サービスからデータをプリフェッチするために、起動後できるだけ早く、ユーザー インターフェイスを表示する前に、ユーザーの Xbox Live 認証を開始する必要があります。

ローカル ユーザーを暗黙的に認証するには、次の呼び出しを行います。

C++:
```
pplx::task<xbox_live_result<sign_in_result>> xbox_live_user::signin_silently(Platform::Object^ coreDispatcher)
```

WinRT:
```
Windows::Foundation::IAsyncOperation<SignInResult^>^ XboxLiveUser::SignInSilentlyAsync(Platform::Object^ coreDispatcher)
```


* **coreDispatcher**

  Thread Dispatcher は、スレッド間の通信に使用されます。 サイレント サインイン API は UI をまったく表示しませんが、XSAPI には appx のロケールについての情報を取得するための UI スレッド ディスパッチャが引き続き必要です。 静的 UI スレッド ディスパッチャは、UI スレッドで Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher を呼び出すことで取得できます。 または、この API が UI スレッドで呼び出されることがはっきりしている場合、nullptr を渡すことができます (たとえば JS UWA など)。


暗黙的サインイン試行の結果には 3 つの可能性があります。

* **成功**

  デバイスがオンラインの場合、これはユーザーが Xbox Live に正しく認証され、有効なトークンを取得できたことを意味します。

  デバイスがオフラインの場合、これは、ユーザーが以前に Xbox Live に正しく認証されており、このタイトルから明示的にサインアウトしていないことを意味します。  この場合、タイトルが有効なトークンにアクセスできる保証はないことに注意してください。保証されるのはユーザーの身元が既知であり検証済みであることだけです。  タイトルは、ユーザーの身元を Xbox ユーザー ID (xuid) とゲーマータグによって認識しています。

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
```
pplx::task<xbox_live_result<sign_in_result>> xbox_live_user::signin(Platform::Object^ coreDispatcher)
```

WinRT:
```
Windows::Foundation::IAsyncOperation<SignInResult^>^ XboxLiveUser::SignInAsync(Platform::Object^ coreDispatcher)
```


* **coreDispatcher**

  Thread Dispatcher は、スレッド間の通信に使用されます。 サインイン API には、サインイン UI を表示して appx のロケールについての情報を取得するために UI ディスパッチャが必要です。 静的 UI スレッド ディスパッチャは、UI スレッドで Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher を呼び出すことで取得できます。 または、この API が UI スレッドで呼び出されることがはっきりしている場合、nullptr を渡すことができます (たとえば JS UWA など)。

UX を使用したサインイン試行の結果には 3 つの可能性があります。

* **成功**

  デバイスがオンラインの場合、これはユーザーが Xbox Live に正しく認証され、有効なトークンを取得できたことを意味します。

  デバイスがオフラインの場合、これは、ユーザーが以前に Xbox Live に正しく認証されており、このタイトルから明示的にサインアウトしていないことを意味します。  この場合、タイトルが有効なトークンにアクセスできる保証はないことに注意してください。保証されるのはユーザーの身元が既知であり検証済みであることだけです。  ユーザーの身元は、Xbox ユーザー ID (xuid) とゲーマータグによってタイトルに知られます。

* **UserCancel**

  サインイン操作が完了する前にユーザーが操作をキャンセルしました。  このとき、ゲームでは UX を使用したサインインを自動的に再試行しないでください。  代わりに、ユーザーがサインイン操作を再試行できるゲーム内 UX を表示してください。  (例: サインイン ボタン)

* **その他のエラー**

  ランタイムはその他の理由によりサインインできませんでした。  通常、ゲームまたはユーザーではこれらの問題に対処できません。 c++ API を使う場合、WinRT で xbox_live_result<>.err(); を確認してエラーをチェックし、Platform::Exception^ をキャッチする必要があります。

### <a name="handling-user-sign-out-completed-event"></a>ユーザーのサインアウト完了イベントの処理 ###

以下のいずれかが発生した場合、ユーザーはタイトルからサインアウトします。

1.  ユーザーが Xbox アプリ (Windows 10) または本体シェル (Xbox One) からサインアウトした。 サインアウトすることは、このユーザー用にインストールされたすべての Xbox Live 対応アプリに影響します。
2.  ユーザーが別の Microsoft アカウントに切り替えた
3.  ユーザーが別のデバイスから同じタイトルにサインインした

以上すべてのケースで、タイトルは `xbox_live_user::add_sign_out_completed_handler` または `XboxLiveUser::SignOutCompleted` ハンドラーからイベントを受け取ります。  ゲームではサインアウト完了イベントを適切に処理する必要があります。
1. ゲームでは、ユーザーが Xbox Live からサインアウトしたことを視覚的にユーザーに明示する必要があります。
2. ユーザーが既にサインアウトしており、利用可能な承認トークンがないため、ゲームはイベント ハンドラーでいかなる Xbox Live サービス API も呼び出すことができません。

### <a name="determining-if-the-device-is-offline"></a>デバイスがオフラインかどうかの判定 ###

ユーザーが一度サインインしている場合は、オフラインのときでもサインイン API が成功し、前回サインインしたアカウントが返されます。

タイトルがオフラインでプレイできる場合 (キャンペーン モードなど): デバイスがオンラインかオフラインかを問わず、タイトルは、WriteInGameEvent API と接続ストレージ API によってゲームの進行状況を再生および記録することをユーザーに許可できます。これらの API はどちらも、デバイスがオフラインの状態で正しく動作します。

タイトルがオフラインでプレイできない場合 (マルチプレイヤー ゲーム、サーバー ベースのゲームなど): タイトルは GetNetworkConnectivityLevel API を呼び出して、デバイスがオフラインかどうかを調べ、状態および解決方法 (例: "続行するにはインターネットに接続する必要があります…") をユーザーに通知する必要があります。
