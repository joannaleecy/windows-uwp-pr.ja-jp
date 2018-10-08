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
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4430847"
---
# <a name="authentication-for-uwp-projects"></a><span data-ttu-id="d5bac-104">UWP プロジェクトの認証</span><span class="sxs-lookup"><span data-stu-id="d5bac-104">Authentication for UWP projects</span></span>

<span data-ttu-id="d5bac-105">ゲームで Xbox Live の機能を利用するために、ユーザーは Xbox Live プロフィールを作成し、Xbox Live コミュニティで自らの身元を明らかにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-105">To take advantage of Xbox Live features in games, a user needs to create an Xbox Live profile to identify themselves in the Xbox Live community.</span></span>  <span data-ttu-id="d5bac-106">Xbox Live サービスは、ユーザーの Xbox Live プロフィール (ユーザーのゲーマータグやゲーマーアイコン、ユーザーが一緒にゲームをするフレンド、ユーザーがプレイしたゲーム、ユーザーがロック解除した実績、特定のゲームにおけるユーザーのランキング順位など) を使用してゲーム関連のアクティビティを追跡します。</span><span class="sxs-lookup"><span data-stu-id="d5bac-106">Xbox Live services keep track of game related activities using that Xbox Live profile, such as the user's gamertag and gamer picture, who the user's gaming friends are, what games the user has played, what achievements the user has unlocked, where the user stands on the leaderboard for a particular game, etc.</span></span>

<span data-ttu-id="d5bac-107">特定のデバイス上の特定のゲームで Xbox Live サービスにアクセスしたいとき、ユーザーはまず認証を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-107">When a user wants to access Xbox Live services in a particular game on a particular device, the user needs to authenticate first.</span></span>  <span data-ttu-id="d5bac-108">ゲームは Xbox Live API を呼び出して認証プロセスを開始できます。</span><span class="sxs-lookup"><span data-stu-id="d5bac-108">The game can call Xbox Live APIs to initiate the authenticate process.</span></span>  <span data-ttu-id="d5bac-109">追加情報を提供するためのインターフェイスがユーザーに提示される場合があります。たとえば、使用する Microsoft アカウントのユーザー名とパスワードを入力したり、ゲームにアクセス許可を付与することに同意したり、アカウントの問題を解決したり、新しい使用条件を承諾したりします。</span><span class="sxs-lookup"><span data-stu-id="d5bac-109">In some cases, the user will be presented with an interface to provide additional information, such as entering the username and password of the Microsoft Account to use, giving permission consent to the game, resolving account issues, accepting new terms of use, etc.</span></span>

<span data-ttu-id="d5bac-110">認証されたユーザーは、Xbox アプリで Xbox Live から明示的にサインアウトするまで、そのデバイスと関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="d5bac-110">Once authenticated, the user is associated with on that device until they explicitly sign out of Xbox Live from the Xbox app.</span></span>  <span data-ttu-id="d5bac-111">(すべての Xbox Live ゲームに対して) 1 台のデバイス上で同時に認証を受けられるのは 1 人のプレイヤーだけです。デバイス上で新しいプレイヤーが認証を行うには、まず既存の認証済みプレイヤーがサインアウトする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-111">Only one player is allowed to be authenticated on a device at a time (for all Xbox Live games);  for a new player to be authenticated on the device, the existing authenticated player must sign out first.</span></span>

## <a name="steps-to-sign-in"></a><span data-ttu-id="d5bac-112">サインイン手順</span><span class="sxs-lookup"><span data-stu-id="d5bac-112">Steps To Sign-In</span></span>

<span data-ttu-id="d5bac-113">大まかには、以下の手順に従って Xbox Live API を使用します。</span><span class="sxs-lookup"><span data-stu-id="d5bac-113">At a high level, you use the Xbox Live APIs by following these steps:</span></span>

1. <span data-ttu-id="d5bac-114">そのユーザーを表す XboxLiveUser オブジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="d5bac-114">Create an XboxLiveUser object to represent the user</span></span>
2. <span data-ttu-id="d5bac-115">起動時に暗黙的に Xbox Live にサインインする</span><span class="sxs-lookup"><span data-stu-id="d5bac-115">Sign-in silently to Xbox Live at startup</span></span>
3. <span data-ttu-id="d5bac-116">必要に応じて、UX を使用したサインインを試みる</span><span class="sxs-lookup"><span data-stu-id="d5bac-116">Attempt to sign-in with UX if required</span></span>
4. <span data-ttu-id="d5bac-117">対話しているユーザーに基づいて Xbox Live コンテキストを作成する</span><span class="sxs-lookup"><span data-stu-id="d5bac-117">Create an Xbox Live context based on the interacting user</span></span>
5. <span data-ttu-id="d5bac-118">作成した Xbox Live コンテキストを使用して Xbox Live サービスにアクセスする</span><span class="sxs-lookup"><span data-stu-id="d5bac-118">Use the Xbox Live context to access Xbox Live services</span></span>
6. <span data-ttu-id="d5bac-119">ゲームが終了またはユーザーがサインアウトしたら、XboxLiveUser オブジェクトと XboxLiveContext オブジェクトを null に設定して解放する</span><span class="sxs-lookup"><span data-stu-id="d5bac-119">When the game exits or the user signs-out, release the XboxLiveUser object and XboxLiveContext object by setting them to null</span></span>

### <a name="creating-an-xboxliveuser-object"></a><span data-ttu-id="d5bac-120">XboxLiveUser オブジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="d5bac-120">Creating an XboxLiveUser object</span></span>

<span data-ttu-id="d5bac-121">ほとんどの Xbox Live アクティビティは Xbox Live ユーザーに関連します。</span><span class="sxs-lookup"><span data-stu-id="d5bac-121">Most of the Xbox Live activities are related to the Xbox Live Users.</span></span>  <span data-ttu-id="d5bac-122">ゲーム デベロッパーは、まずローカル ユーザーを表す XboxLiveUser オブジェクトを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-122">As a game developer, you need to first create an XboxLiveUser object to represent the local user.</span></span>

<span data-ttu-id="d5bac-123">C++:</span><span class="sxs-lookup"><span data-stu-id="d5bac-123">C++:</span></span>

```cpp
auto xboxUser = std::make_shared<xbox_live_user>(Windows::System::User^ windowsSystemUser);
```

<span data-ttu-id="d5bac-124">C++/CX (WinRT):</span><span class="sxs-lookup"><span data-stu-id="d5bac-124">C++/CX (WinRT):</span></span>

```cpp
XboxLiveUser xboxUser = ref new XboxLiveUser(Windows::System::User^ windowsSystemUser);
```

<span data-ttu-id="d5bac-125">C# (WinRT):</span><span class="sxs-lookup"><span data-stu-id="d5bac-125">C# (WinRT):</span></span>

```csharp
XboxLiveUser xboxUser = new XboxLiveUser(Windows.System.User windowsSystemUser);
```

* <span data-ttu-id="d5bac-126">**windowsSystemUser** Xbox Live ユーザーとの関連付けに使う Windows システム ユーザー オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="d5bac-126">**windowsSystemUser** The windows system user object to be used to associate with xbox live user.</span></span> <span data-ttu-id="d5bac-127">アプリがシングル ユーザー アプリケーション (SUA) の場合は nullptr になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-127">Could be nullptr if the app is a single user application(SUA).</span></span>
  * <span data-ttu-id="d5bac-128">シングル ユーザー アプリケーション (SUA) とマルチ ユーザー アプリケーション (MUA) について詳しくは、「[マルチ ユーザー アプリケーションの概要](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/multi-user-applications#single-user-applications)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d5bac-128">For more information about Single User Application(SUA) and Multi User Application(MUA), please check [Introduction to multi-user applications](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/multi-user-applications#single-user-applications)</span></span>
  * <span data-ttu-id="d5bac-129">Windows から Windows::System::User^ を取得する方法について詳しくは、「[UWP での Windows システム ユーザーの取得](retrieving-windows-system-user-on-UWP.md)」を確認してください</span><span class="sxs-lookup"><span data-stu-id="d5bac-129">For more information about how to get Windows::System::User^ from Windows, please check [retrieving windows system user on UWP](retrieving-windows-system-user-on-UWP.md)</span></span>

### <a name="sign-in-silently-to-xbox-live-at-startup"></a><span data-ttu-id="d5bac-130">起動時に暗黙的に Xbox Live にサインインする</span><span class="sxs-lookup"><span data-stu-id="d5bac-130">Sign-in silently to Xbox Live at startup</span></span> ###

<span data-ttu-id="d5bac-131">ゲームでは、Xbox Live サービスからデータをプリフェッチするために、起動後できるだけ早く、ユーザー インターフェイスを表示する前に、ユーザーの Xbox Live 認証を開始する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-131">Your game should start to authenticate the user to Xbox Live as early as possible after launching, even before you present the user interface, to pre-fetch data from Xbox Live services.</span></span>

<span data-ttu-id="d5bac-132">ローカル ユーザーを暗黙的に認証するには、次の呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="d5bac-132">To authenticate the local user silently, call</span></span>

<span data-ttu-id="d5bac-133">C++:</span><span class="sxs-lookup"><span data-stu-id="d5bac-133">C++:</span></span>

```cpp
pplx::task<xbox_live_result<sign_in_result>> xbox_live_user::signin_silently(Platform::Object^ coreDispatcher)
```

<span data-ttu-id="d5bac-134">C++/CX (WinRT):</span><span class="sxs-lookup"><span data-stu-id="d5bac-134">C++/CX (WinRT):</span></span>

```cpp
Windows::Foundation::IAsyncOperation<SignInResult^>^ XboxLiveUser::SignInSilentlyAsync(Platform::Object^ coreDispatcher)
```

<span data-ttu-id="d5bac-135">C# (WinRT):</span><span class="sxs-lookup"><span data-stu-id="d5bac-135">C# (WinRT):</span></span>

```csharp
Microsoft.Xbox.Services.System.SignInResult XboxLiveUser.SignInSilentlyAsync(Windows.UI.Core.CoreDispatcher coreDispatcher);
```

* **<span data-ttu-id="d5bac-136">coreDispatcher</span><span class="sxs-lookup"><span data-stu-id="d5bac-136">coreDispatcher</span></span>**

  <span data-ttu-id="d5bac-137">Thread Dispatcher は、スレッド間の通信に使用されます。</span><span class="sxs-lookup"><span data-stu-id="d5bac-137">Thread Dispatcher is used to communication between threads.</span></span> <span data-ttu-id="d5bac-138">サイレント サインイン API は UI をまったく表示しませんが、XSAPI には appx のロケールについての情報を取得するための UI スレッド ディスパッチャが引き続き必要です。</span><span class="sxs-lookup"><span data-stu-id="d5bac-138">Although silent sign in API is not going to show any UI, XSAPI still need the UI thread dispatcher for getting the information about your appx's locale.</span></span> <span data-ttu-id="d5bac-139">静的 UI スレッド ディスパッチャは、UI スレッドで Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher を呼び出すことで取得できます。</span><span class="sxs-lookup"><span data-stu-id="d5bac-139">You can get the static UI thread dispatcher by calling Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher in the UI thread.</span></span> <span data-ttu-id="d5bac-140">または、この API が UI スレッドで呼び出されることがはっきりしている場合、nullptr を渡すことができます (たとえば JS UWA など)。</span><span class="sxs-lookup"><span data-stu-id="d5bac-140">Or if you're certain that this API is being called on the UI thread, you can pass in nullptr(for example on JS UWA).</span></span>


<span data-ttu-id="d5bac-141">暗黙的サインイン試行の結果には 3 つの可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-141">There are 3 possible outcomes from the silent sign-in attempt</span></span>

* **<span data-ttu-id="d5bac-142">成功</span><span class="sxs-lookup"><span data-stu-id="d5bac-142">Success</span></span>**

  <span data-ttu-id="d5bac-143">デバイスがオンラインの場合、これはユーザーが Xbox Live に正しく認証され、有効なトークンを取得できたことを意味します。</span><span class="sxs-lookup"><span data-stu-id="d5bac-143">If the device is online, this means the user authenticated to Xbox Live successfully, and we were able to get a valid token.</span></span>

  <span data-ttu-id="d5bac-144">デバイスがオフラインの場合、これは、ユーザーが以前に Xbox Live に正しく認証されており、このタイトルから明示的にサインアウトしていないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="d5bac-144">if the device is offline, This means the user has previously authenticated to Xbox Live successfully, and has not explicitly signed-out from this title.</span></span>  <span data-ttu-id="d5bac-145">この場合、タイトルが有効なトークンにアクセスできる保証はないことに注意してください。保証されるのはユーザーの身元が既知であり検証済みであることだけです。</span><span class="sxs-lookup"><span data-stu-id="d5bac-145">Note in this case there is no guarantee that title has access to a valid token, it is only guaranteed that the user’s identity is known and has been verified.</span></span>    <span data-ttu-id="d5bac-146">タイトルは、ユーザーの身元を Xbox ユーザー ID (xuid) とゲーマータグによって認識しています。</span><span class="sxs-lookup"><span data-stu-id="d5bac-146">The identity of the user is known to the title via their xbox user id (xuid) and gamertag.</span></span>

* **<span data-ttu-id="d5bac-147">UserInteractionRequired</span><span class="sxs-lookup"><span data-stu-id="d5bac-147">UserInteractionRequired</span></span>**

  <span data-ttu-id="d5bac-148">ランタイムでユーザーの暗黙的サインインができませんでした。</span><span class="sxs-lookup"><span data-stu-id="d5bac-148">This means the runtime was unable to sign-in the user silently.</span></span>  <span data-ttu-id="d5bac-149">ゲームでは、ユーザーがサインアップ/サインインするために必要な UX フローを表示する Xbox Identity Provider を呼び出す `xbox_live_user::sign_in` を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-149">The game should call `xbox_live_user::sign_in` which invokes the Xbox Identity Provider to show the necessary UX flow for the user to sign-up/sign-in.</span></span>  <span data-ttu-id="d5bac-150">一般的な問題は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="d5bac-150">Common issues are:</span></span>

  * <span data-ttu-id="d5bac-151">ユーザーが Microsoft アカウントを持っていない</span><span class="sxs-lookup"><span data-stu-id="d5bac-151">User does not have a Microsoft Account</span></span>
  * <span data-ttu-id="d5bac-152">ユーザーがゲーム用の優先 Microsoft アカウントを設定していない</span><span class="sxs-lookup"><span data-stu-id="d5bac-152">User has not set a preferred Microsoft Account for gaming</span></span>
  * <span data-ttu-id="d5bac-153">選択された Microsoft アカウントに Xbox Live プロフィールがない</span><span class="sxs-lookup"><span data-stu-id="d5bac-153">The selected Microsoft Account doesn’t have an Xbox Live profile</span></span>
  * <span data-ttu-id="d5bac-154">Microsoft アカウントの規約にユーザーが同意する必要がある</span><span class="sxs-lookup"><span data-stu-id="d5bac-154">User needs to accept Microsoft Account consent</span></span>

* **<span data-ttu-id="d5bac-155">その他のエラー</span><span class="sxs-lookup"><span data-stu-id="d5bac-155">Other errors</span></span>**

  <span data-ttu-id="d5bac-156">ランタイムはその他の理由によりサインインできませんでした。</span><span class="sxs-lookup"><span data-stu-id="d5bac-156">The runtime was unable to sign-in due to other reasons.</span></span>  <span data-ttu-id="d5bac-157">通常、ゲームまたはユーザーではこれらの問題に対処できません。</span><span class="sxs-lookup"><span data-stu-id="d5bac-157">Typically these issues are not actionable by the game or the user.</span></span> <span data-ttu-id="d5bac-158">c++ API を使う場合、WinRT で xbox_live_result<>.err(); を確認してエラーをチェックし、Platform::Exception^ をキャッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-158">When using c++ API, you would need to check error by checking xbox_live_result<>.err(); on WinRT, you would need to catch Platform::Exception^.</span></span>

### <a name="attempt-to-sign-in-with-ux-if-required"></a><span data-ttu-id="d5bac-159">必要に応じて、UX を使用したサインインを試みる</span><span class="sxs-lookup"><span data-stu-id="d5bac-159">Attempt to sign-in with UX if required</span></span> ###

<span data-ttu-id="d5bac-160">暗黙的サインインに失敗し、ユーザー インターフェイスを表示する準備ができている場合、ゲームは UX を有効にしてユーザーを Xbox Live に対して認証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-160">Your game should authenticate the user to Xbox Live with UX enabled when silent sign-in was unsuccessful, and you are ready to present the user interface.</span></span>

<span data-ttu-id="d5bac-161">UX を使用してローカル ユーザーを認証するには、次の呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="d5bac-161">To authenticate the local user with UX, call</span></span>

<span data-ttu-id="d5bac-162">C++:</span><span class="sxs-lookup"><span data-stu-id="d5bac-162">C++:</span></span>

```cpp
pplx::task<xbox_live_result<sign_in_result>> xbox_live_user::signin(Platform::Object^ coreDispatcher)
```


<span data-ttu-id="d5bac-163">C++/CX (WinRT):</span><span class="sxs-lookup"><span data-stu-id="d5bac-163">C++/CX (WinRT):</span></span>

```cpp
Windows::Foundation::IAsyncOperation<SignInResult^>^ XboxLiveUser::SignInAsync(Platform::Object^ coreDispatcher)
```

<span data-ttu-id="d5bac-164">C# (WinRT):</span><span class="sxs-lookup"><span data-stu-id="d5bac-164">C# (WinRT):</span></span>

```csharp
Microsoft.Xbox.Services.System.SignInResult  XboxLiveUser.SignInAsync(Windows.UI.Core.CoreDispatcher coreDispatcher);
```

* **<span data-ttu-id="d5bac-165">coreDispatcher</span><span class="sxs-lookup"><span data-stu-id="d5bac-165">coreDispatcher</span></span>**

  <span data-ttu-id="d5bac-166">Thread Dispatcher は、スレッド間の通信に使用されます。</span><span class="sxs-lookup"><span data-stu-id="d5bac-166">Thread Dispatcher is used to communication between threads.</span></span> <span data-ttu-id="d5bac-167">サインイン API には、サインイン UI を表示して appx のロケールについての情報を取得するために UI ディスパッチャが必要です。</span><span class="sxs-lookup"><span data-stu-id="d5bac-167">Sign in API requires the UI dispatcher so that it can show the sign in UI and get the information about your appx's locale.</span></span> <span data-ttu-id="d5bac-168">静的 UI スレッド ディスパッチャは、UI スレッドで Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher を呼び出すことで取得できます。</span><span class="sxs-lookup"><span data-stu-id="d5bac-168">You can get the static UI thread dispatcher by calling Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher in the UI thread.</span></span> <span data-ttu-id="d5bac-169">または、この API が UI スレッドで呼び出されることがはっきりしている場合、nullptr を渡すことができます (たとえば JS UWA など)。</span><span class="sxs-lookup"><span data-stu-id="d5bac-169">Or if you're certain that this API is being called on the UI thread, you can pass in nullptr(for example on JS UWA).</span></span>

<span data-ttu-id="d5bac-170">UX を使用したサインイン試行の結果には 3 つの可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-170">There are 3 possible outcomes from the sign-in attempt with UX:</span></span>

* **<span data-ttu-id="d5bac-171">成功</span><span class="sxs-lookup"><span data-stu-id="d5bac-171">Success</span></span>**

  <span data-ttu-id="d5bac-172">デバイスがオンラインの場合、これはユーザーが Xbox Live に正しく認証され、有効なトークンを取得できたことを意味します。</span><span class="sxs-lookup"><span data-stu-id="d5bac-172">If the device is online, this means the user authenticated to Xbox Live successfully, and we were able to get a valid token.</span></span>

  <span data-ttu-id="d5bac-173">デバイスがオフラインの場合、これは、ユーザーが以前に Xbox Live に正しく認証されており、このタイトルから明示的にサインアウトしていないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="d5bac-173">if the device is offline, This means the user has previously authenticated to Xbox Live successfully, and has not explicitly signed-out from this title.</span></span>  <span data-ttu-id="d5bac-174">この場合、タイトルが有効なトークンにアクセスできる保証はないことに注意してください。保証されるのはユーザーの身元が既知であり検証済みであることだけです。</span><span class="sxs-lookup"><span data-stu-id="d5bac-174">Note in this case there is no guarantee that title has access to a valid token, it is only guaranteed that the user’s identity is known and has been verified.</span></span>    <span data-ttu-id="d5bac-175">ユーザーの身元は、Xbox ユーザー ID (xuid) とゲーマータグによってタイトルに知られます。</span><span class="sxs-lookup"><span data-stu-id="d5bac-175">The identity of the user is known to the title xbox user id (xuid) and gamertag.</span></span>

* **<span data-ttu-id="d5bac-176">UserCancel</span><span class="sxs-lookup"><span data-stu-id="d5bac-176">UserCancel</span></span>**

  <span data-ttu-id="d5bac-177">サインイン操作が完了する前にユーザーが操作をキャンセルしました。</span><span class="sxs-lookup"><span data-stu-id="d5bac-177">This means that the user cancelled the sign-in operation before completion.</span></span>  <span data-ttu-id="d5bac-178">このとき、ゲームでは UX を使用したサインインを自動的に再試行しないでください。</span><span class="sxs-lookup"><span data-stu-id="d5bac-178">When this happens, the game should NOT automatically retry sign-in with UX.</span></span>  <span data-ttu-id="d5bac-179">代わりに、ユーザーがサインイン操作を再試行できるゲーム内 UX を表示してください。</span><span class="sxs-lookup"><span data-stu-id="d5bac-179">Instead, it should present in-game UX that allows the user to retry the sign-in operation.</span></span>  <span data-ttu-id="d5bac-180">(例: サインイン ボタン)</span><span class="sxs-lookup"><span data-stu-id="d5bac-180">(For example, a sign-in button)</span></span>

* **<span data-ttu-id="d5bac-181">その他のエラー</span><span class="sxs-lookup"><span data-stu-id="d5bac-181">Other errors</span></span>**

  <span data-ttu-id="d5bac-182">ランタイムはその他の理由によりサインインできませんでした。</span><span class="sxs-lookup"><span data-stu-id="d5bac-182">The runtime was unable to sign-in due to other reasons.</span></span>  <span data-ttu-id="d5bac-183">通常、ゲームまたはユーザーではこれらの問題に対処できません。</span><span class="sxs-lookup"><span data-stu-id="d5bac-183">Typically these issues are not actionable by the game or the user.</span></span> <span data-ttu-id="d5bac-184">c++ API を使う場合、WinRT で xbox_live_result<>.err(); を確認してエラーをチェックし、Platform::Exception^ をキャッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-184">When using c++ API, you would need to check error by checking xbox_live_result<>.err(); on WinRT, you would need to catch Platform::Exception^.</span></span>

## <a name="sign-in-code-examples"></a><span data-ttu-id="d5bac-185">サインイン コードの例</span><span class="sxs-lookup"><span data-stu-id="d5bac-185">Sign-In Code Examples</span></span>

### <a name="c"></a><span data-ttu-id="d5bac-186">C++</span><span class="sxs-lookup"><span data-stu-id="d5bac-186">C++</span></span>

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

### <a name="c-winrt"></a><span data-ttu-id="d5bac-187">C# (WinRT)</span><span class="sxs-lookup"><span data-stu-id="d5bac-187">C# (WinRT)</span></span>

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

## <a name="sign-out"></a><span data-ttu-id="d5bac-188">サインアウト</span><span class="sxs-lookup"><span data-stu-id="d5bac-188">Sign Out</span></span>

### <a name="handling-user-sign-out-completed-event"></a><span data-ttu-id="d5bac-189">ユーザーのサインアウト完了イベントの処理</span><span class="sxs-lookup"><span data-stu-id="d5bac-189">Handling user sign-out completed event</span></span>

<span data-ttu-id="d5bac-190">以下のいずれかが発生した場合、ユーザーはタイトルからサインアウトします。</span><span class="sxs-lookup"><span data-stu-id="d5bac-190">The user will sign-out from a title if one of the following happens:</span></span>

1. <span data-ttu-id="d5bac-191">ユーザーが Xbox アプリ (Windows 10) または本体シェル (Xbox One) からサインアウトした。</span><span class="sxs-lookup"><span data-stu-id="d5bac-191">The user signed-out from the Xbox App (Windows 10) or console shell (Xbox One).</span></span> <span data-ttu-id="d5bac-192">サインアウトすることは、このユーザー用にインストールされたすべての Xbox Live 対応アプリに影響します。</span><span class="sxs-lookup"><span data-stu-id="d5bac-192">Signing out will affect all Xbox Live enabled apps installed for this user.</span></span>
2. <span data-ttu-id="d5bac-193">ユーザーが別の Microsoft アカウントに切り替えた</span><span class="sxs-lookup"><span data-stu-id="d5bac-193">The user switched to a different Microsoft Account</span></span>
3. <span data-ttu-id="d5bac-194">ユーザーが別のデバイスから同じタイトルにサインインした</span><span class="sxs-lookup"><span data-stu-id="d5bac-194">The user signed into the same title from a different device</span></span>

<span data-ttu-id="d5bac-195">以上すべてのケースで、タイトルは `xbox_live_user::add_sign_out_completed_handler` または `XboxLiveUser::SignOutCompleted` ハンドラーからイベントを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-195">In all these cases, the title will receive an event from the `xbox_live_user::add_sign_out_completed_handler` or `XboxLiveUser::SignOutCompleted` handlers.</span></span>  <span data-ttu-id="d5bac-196">ゲームではサインアウト完了イベントを適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-196">The game must handle the sign out completed event appropriately:</span></span>

1. <span data-ttu-id="d5bac-197">ゲームでは、ユーザーが Xbox Live からサインアウトしたことを視覚的にユーザーに明示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-197">The game should display clear visual indication to the user that she/he has signed-out from Xbox Live.</span></span>
2. <span data-ttu-id="d5bac-198">ユーザーが既にサインアウトしており、利用可能な承認トークンがないため、ゲームはイベント ハンドラーでいかなる Xbox Live サービス API も呼び出すことができません。</span><span class="sxs-lookup"><span data-stu-id="d5bac-198">The game cannot call any Xbox Live service APIs in the event handler, because the user has already signed-out and there is no authorization token available.</span></span>

## <a name="sign-out-handler-code-samples"></a><span data-ttu-id="d5bac-199">サインアウト ハンドラー コードのサンプル</span><span class="sxs-lookup"><span data-stu-id="d5bac-199">Sign Out Handler Code Samples</span></span>

### <a name="c"></a><span data-ttu-id="d5bac-200">C++</span><span class="sxs-lookup"><span data-stu-id="d5bac-200">C++</span></span>

```cpp

xbox::services::system::xbox_live_user::add_sign_out_completed_handler(
        [this](const xbox::services::system::sign_out_completed_event_args&)

    {
        // 6. When the game exits or the user signs-out, release the XboxLiveUser object and XboxLiveContext object by setting them to null
        m_user = NULL;
        m_xboxLiveContext = NULL;
    });

```

### <a name="c-winrt"></a><span data-ttu-id="d5bac-201">C# (WinRT)</span><span class="sxs-lookup"><span data-stu-id="d5bac-201">C# (WinRT)</span></span>

```csharp
XboxLiveUser.SignOutCompleted += OnUserSignOut;

public void OnSignOut(object sender, SignOutCompletedEventArgs e)
        {
            // 6. When the game exits or the user signs-out, release the XboxLiveUser object and XboxLiveContext object by setting them to null
            primaryUser = null;
            xboxLiveContext = null;
        }
```

## <a name="determining-if-the-device-is-offline"></a><span data-ttu-id="d5bac-202">デバイスがオフラインかどうかの判定</span><span class="sxs-lookup"><span data-stu-id="d5bac-202">Determining if the device is offline</span></span>

<span data-ttu-id="d5bac-203">ユーザーが一度サインインしている場合は、オフラインのときでもサインイン API が成功し、前回サインインしたアカウントが返されます。</span><span class="sxs-lookup"><span data-stu-id="d5bac-203">Sign in APIs will still be success when offline if the user has signed in once, and the last signed in account will be returned.</span></span>

<span data-ttu-id="d5bac-204">タイトルがオフラインでプレイできる場合 (キャンペーン モードなど): デバイスがオンラインかオフラインかを問わず、タイトルは、WriteInGameEvent API と接続ストレージ API によってゲームの進行状況を再生および記録することをユーザーに許可できます。これらの API はどちらも、デバイスがオフラインの状態で正しく動作します。</span><span class="sxs-lookup"><span data-stu-id="d5bac-204">If the title can be played offline (Campaign mode, etc.) Regardless the device is online or offline, the title can allow the user to play and record game progress via WriteInGameEvent API and Connected Storage API, both of them work properly while the device is offline.</span></span>

<span data-ttu-id="d5bac-205">タイトルがオフラインでプレイできない場合 (マルチプレイヤー ゲーム、サーバー ベースのゲームなど): タイトルは GetNetworkConnectivityLevel API を呼び出して、デバイスがオフラインかどうかを調べ、状態および解決方法 (例: "続行するにはインターネットに接続する必要があります…") をユーザーに通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5bac-205">If the title cannot be played offline (Multiplayer game or Server based game, etc.) The title should call the GetNetworkConnectivityLevel API to find out if the device is offline, and inform the user about the status and possible solutions (for example, ‘You need to connect to Internet to continue…’)</span></span>

## <a name="online-status-code-samples"></a><span data-ttu-id="d5bac-206">オンライン状態コードのサンプル</span><span class="sxs-lookup"><span data-stu-id="d5bac-206">Online Status Code Samples</span></span>

### <a name="c"></a><span data-ttu-id="d5bac-207">C++</span><span class="sxs-lookup"><span data-stu-id="d5bac-207">C++</span></span>

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

### <a name="c-winrt"></a><span data-ttu-id="d5bac-208">C# (WinRT)</span><span class="sxs-lookup"><span data-stu-id="d5bac-208">C# (WinRT)</span></span>

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