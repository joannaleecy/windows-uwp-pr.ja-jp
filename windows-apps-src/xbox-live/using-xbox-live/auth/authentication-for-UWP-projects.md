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
# <a name="authentication-for-uwp-projects"></a><span data-ttu-id="fd58e-104">UWP プロジェクトの認証</span><span class="sxs-lookup"><span data-stu-id="fd58e-104">Authentication for UWP projects</span></span>

<span data-ttu-id="fd58e-105">ゲームで Xbox Live の機能を利用するために、ユーザーは Xbox Live プロフィールを作成し、Xbox Live コミュニティで自らの身元を明らかにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-105">To take advantage of Xbox Live features in games, a user needs to create an Xbox Live profile to identify themselves in the Xbox Live community.</span></span>  <span data-ttu-id="fd58e-106">Xbox Live サービスは、ユーザーの Xbox Live プロフィール (ユーザーのゲーマータグやゲーマーアイコン、ユーザーが一緒にゲームをするフレンド、ユーザーがプレイしたゲーム、ユーザーがロック解除した実績、特定のゲームにおけるユーザーのランキング順位など) を使用してゲーム関連のアクティビティを追跡します。</span><span class="sxs-lookup"><span data-stu-id="fd58e-106">Xbox Live services keep track of game related activities using that Xbox Live profile, such as the user's gamertag and gamer picture, who the user's gaming friends are, what games the user has played, what achievements the user has unlocked, where the user stands on the leaderboard for a particular game, etc.</span></span>

<span data-ttu-id="fd58e-107">特定のデバイス上の特定のゲームで Xbox Live サービスにアクセスしたいとき、ユーザーはまず認証を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-107">When a user wants to access Xbox Live services in a particular game on a particular device, the user needs to authenticate first.</span></span>  <span data-ttu-id="fd58e-108">ゲームは Xbox Live API を呼び出して認証プロセスを開始できます。</span><span class="sxs-lookup"><span data-stu-id="fd58e-108">The game can call Xbox Live APIs to initiate the authenticate process.</span></span>  <span data-ttu-id="fd58e-109">追加情報を提供するためのインターフェイスがユーザーに提示される場合があります。たとえば、使用する Microsoft アカウントのユーザー名とパスワードを入力したり、ゲームにアクセス許可を付与することに同意したり、アカウントの問題を解決したり、新しい使用条件を承諾したりします。</span><span class="sxs-lookup"><span data-stu-id="fd58e-109">In some cases, the user will be presented with an interface to provide additional information, such as entering the username and password of the Microsoft Account to use, giving permission consent to the game, resolving account issues, accepting new terms of use, etc.</span></span>

<span data-ttu-id="fd58e-110">認証されたユーザーは、Xbox アプリで Xbox Live から明示的にサインアウトするまで、そのデバイスと関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="fd58e-110">Once authenticated, the user is associated with on that device until they explicitly sign out of Xbox Live from the Xbox app.</span></span>  <span data-ttu-id="fd58e-111">(すべての Xbox Live ゲームに対して) 1 台のデバイス上で同時に認証を受けられるのは 1 人のプレイヤーだけです。デバイス上で新しいプレイヤーが認証を行うには、まず既存の認証済みプレイヤーがサインアウトする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-111">Only one player is allowed to be authenticated on a device at a time (for all Xbox Live games);  for a new player to be authenticated on the device, the existing authenticated player must sign out first.</span></span>

<span data-ttu-id="fd58e-112">大まかには、以下の手順に従って Xbox Live API を使用します。</span><span class="sxs-lookup"><span data-stu-id="fd58e-112">At a high level, you use the Xbox Live APIs by following these steps:</span></span>

1. <span data-ttu-id="fd58e-113">そのユーザーを表す XboxLiveUser オブジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="fd58e-113">Create an XboxLiveUser object to represent the user</span></span>
2. <span data-ttu-id="fd58e-114">起動時に暗黙的に Xbox Live にサインインする</span><span class="sxs-lookup"><span data-stu-id="fd58e-114">Sign-in silently to Xbox Live at startup</span></span>
3. <span data-ttu-id="fd58e-115">必要に応じて、UX を使用したサインインを試みる</span><span class="sxs-lookup"><span data-stu-id="fd58e-115">Attempt to sign-in with UX if required</span></span>
4. <span data-ttu-id="fd58e-116">対話しているユーザーに基づいて Xbox Live コンテキストを作成する</span><span class="sxs-lookup"><span data-stu-id="fd58e-116">Create an Xbox Live context based on the interacting user</span></span>
5. <span data-ttu-id="fd58e-117">作成した Xbox Live コンテキストを使用して Xbox Live サービスにアクセスする</span><span class="sxs-lookup"><span data-stu-id="fd58e-117">Use the Xbox Live context to access Xbox Live services</span></span>
6. <span data-ttu-id="fd58e-118">ゲームが終了またはユーザーがサインアウトしたら、XboxLiveUser オブジェクトと XboxLiveContext オブジェクトを null に設定して解放する</span><span class="sxs-lookup"><span data-stu-id="fd58e-118">When the game exits or the user signs-out, release the XboxLiveUser object and XboxLiveContext object by setting them to null</span></span>

### <a name="creating-an-xboxliveuser-object"></a><span data-ttu-id="fd58e-119">XboxLiveUser オブジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="fd58e-119">Creating an XboxLiveUser object</span></span> ###
<span data-ttu-id="fd58e-120">ほとんどの Xbox Live アクティビティは Xbox Live ユーザーに関連します。</span><span class="sxs-lookup"><span data-stu-id="fd58e-120">Most of the Xbox Live activities are related to the Xbox Live Users.</span></span>  <span data-ttu-id="fd58e-121">ゲーム デベロッパーは、まずローカル ユーザーを表す XboxLiveUser オブジェクトを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-121">As a game developer, you need to first create an XboxLiveUser object to represent the local user.</span></span>

<span data-ttu-id="fd58e-122">C++:</span><span class="sxs-lookup"><span data-stu-id="fd58e-122">C++:</span></span>
```
auto user = std::make_shared<xbox_live_user>(Windows::System::User^ windowsSystemUser);
```

<span data-ttu-id="fd58e-123">WinRT:</span><span class="sxs-lookup"><span data-stu-id="fd58e-123">WinRT:</span></span>
```
XboxLiveUser user = ref new XboxLiveUser(Windows::System::User^ windowsSystemUser);
```

* <span data-ttu-id="fd58e-124">**windowsSystemUser** Xbox Live ユーザーとの関連付けに使う Windows システム ユーザー オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="fd58e-124">**windowsSystemUser** The windows system user object to be used to associate with xbox live user.</span></span> <span data-ttu-id="fd58e-125">アプリがシングル ユーザー アプリケーション (SUA) の場合は nullptr になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-125">Could be nullptr if the app is a single user application(SUA).</span></span>
  * <span data-ttu-id="fd58e-126">シングル ユーザー アプリケーション (SUA) とマルチ ユーザー アプリケーション (MUA) について詳しくは、「[マルチ ユーザー アプリケーションの概要](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/multi-user-applications#single-user-applications)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fd58e-126">For more information about Single User Application(SUA) and Multi User Application(MUA), please check [Introduction to multi-user applications](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/multi-user-applications#single-user-applications)</span></span>
  * <span data-ttu-id="fd58e-127">Windows から Windows::System::User^ を取得する方法について詳しくは、「[UWP での Windows システム ユーザーの取得](retrieving-windows-system-user-on-UWP.md)」を確認してください</span><span class="sxs-lookup"><span data-stu-id="fd58e-127">For more information about how to get Windows::System::User^ from Windows, please check [retrieving windows system user on UWP](retrieving-windows-system-user-on-UWP.md)</span></span>

### <a name="sign-in-silently-to-xbox-live-at-startup"></a><span data-ttu-id="fd58e-128">起動時に暗黙的に Xbox Live にサインインする</span><span class="sxs-lookup"><span data-stu-id="fd58e-128">Sign-in silently to Xbox Live at startup</span></span> ###
<span data-ttu-id="fd58e-129">ゲームでは、Xbox Live サービスからデータをプリフェッチするために、起動後できるだけ早く、ユーザー インターフェイスを表示する前に、ユーザーの Xbox Live 認証を開始する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-129">Your game should start to authenticate the user to Xbox Live as early as possible after launching, even before you present the user interface, to pre-fetch data from Xbox Live services.</span></span>

<span data-ttu-id="fd58e-130">ローカル ユーザーを暗黙的に認証するには、次の呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="fd58e-130">To authenticate the local user silently, call</span></span>

<span data-ttu-id="fd58e-131">C++:</span><span class="sxs-lookup"><span data-stu-id="fd58e-131">C++:</span></span>
```
pplx::task<xbox_live_result<sign_in_result>> xbox_live_user::signin_silently(Platform::Object^ coreDispatcher)
```

<span data-ttu-id="fd58e-132">WinRT:</span><span class="sxs-lookup"><span data-stu-id="fd58e-132">WinRT:</span></span>
```
Windows::Foundation::IAsyncOperation<SignInResult^>^ XboxLiveUser::SignInSilentlyAsync(Platform::Object^ coreDispatcher)
```


* **<span data-ttu-id="fd58e-133">coreDispatcher</span><span class="sxs-lookup"><span data-stu-id="fd58e-133">coreDispatcher</span></span>**

  <span data-ttu-id="fd58e-134">Thread Dispatcher は、スレッド間の通信に使用されます。</span><span class="sxs-lookup"><span data-stu-id="fd58e-134">Thread Dispatcher is used to communication between threads.</span></span> <span data-ttu-id="fd58e-135">サイレント サインイン API は UI をまったく表示しませんが、XSAPI には appx のロケールについての情報を取得するための UI スレッド ディスパッチャが引き続き必要です。</span><span class="sxs-lookup"><span data-stu-id="fd58e-135">Although silent sign in API is not going to show any UI, XSAPI still need the UI thread dispatcher for getting the information about your appx's locale.</span></span> <span data-ttu-id="fd58e-136">静的 UI スレッド ディスパッチャは、UI スレッドで Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher を呼び出すことで取得できます。</span><span class="sxs-lookup"><span data-stu-id="fd58e-136">You can get the static UI thread dispatcher by calling Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher in the UI thread.</span></span> <span data-ttu-id="fd58e-137">または、この API が UI スレッドで呼び出されることがはっきりしている場合、nullptr を渡すことができます (たとえば JS UWA など)。</span><span class="sxs-lookup"><span data-stu-id="fd58e-137">Or if you're certain that this API is being called on the UI thread, you can pass in nullptr(for example on JS UWA).</span></span>


<span data-ttu-id="fd58e-138">暗黙的サインイン試行の結果には 3 つの可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-138">There are 3 possible outcomes from the silent sign-in attempt</span></span>

* **<span data-ttu-id="fd58e-139">成功</span><span class="sxs-lookup"><span data-stu-id="fd58e-139">Success</span></span>**

  <span data-ttu-id="fd58e-140">デバイスがオンラインの場合、これはユーザーが Xbox Live に正しく認証され、有効なトークンを取得できたことを意味します。</span><span class="sxs-lookup"><span data-stu-id="fd58e-140">If the device is online, this means the user authenticated to Xbox Live successfully, and we were able to get a valid token.</span></span>

  <span data-ttu-id="fd58e-141">デバイスがオフラインの場合、これは、ユーザーが以前に Xbox Live に正しく認証されており、このタイトルから明示的にサインアウトしていないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="fd58e-141">if the device is offline, This means the user has previously authenticated to Xbox Live successfully, and has not explicitly signed-out from this title.</span></span>  <span data-ttu-id="fd58e-142">この場合、タイトルが有効なトークンにアクセスできる保証はないことに注意してください。保証されるのはユーザーの身元が既知であり検証済みであることだけです。</span><span class="sxs-lookup"><span data-stu-id="fd58e-142">Note in this case there is no guarantee that title has access to a valid token, it is only guaranteed that the user’s identity is known and has been verified.</span></span>  <span data-ttu-id="fd58e-143">タイトルは、ユーザーの身元を Xbox ユーザー ID (xuid) とゲーマータグによって認識しています。</span><span class="sxs-lookup"><span data-stu-id="fd58e-143">The identity of the user is known to the title via their xbox user id (xuid) and gamertag.</span></span>

* **<span data-ttu-id="fd58e-144">UserInteractionRequired</span><span class="sxs-lookup"><span data-stu-id="fd58e-144">UserInteractionRequired</span></span>**

  <span data-ttu-id="fd58e-145">ランタイムでユーザーの暗黙的サインインができませんでした。</span><span class="sxs-lookup"><span data-stu-id="fd58e-145">This means the runtime was unable to sign-in the user silently.</span></span>  <span data-ttu-id="fd58e-146">ゲームでは、ユーザーがサインアップ/サインインするために必要な UX フローを表示する Xbox Identity Provider を呼び出す `xbox_live_user::sign_in` を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-146">The game should call `xbox_live_user::sign_in` which invokes the Xbox Identity Provider to show the necessary UX flow for the user to sign-up/sign-in.</span></span>  <span data-ttu-id="fd58e-147">一般的な問題は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="fd58e-147">Common issues are:</span></span>

  * <span data-ttu-id="fd58e-148">ユーザーが Microsoft アカウントを持っていない</span><span class="sxs-lookup"><span data-stu-id="fd58e-148">User does not have a Microsoft Account</span></span>
  * <span data-ttu-id="fd58e-149">ユーザーがゲーム用の優先 Microsoft アカウントを設定していない</span><span class="sxs-lookup"><span data-stu-id="fd58e-149">User has not set a preferred Microsoft Account for gaming</span></span>
  * <span data-ttu-id="fd58e-150">選択された Microsoft アカウントに Xbox Live プロフィールがない</span><span class="sxs-lookup"><span data-stu-id="fd58e-150">The selected Microsoft Account doesn’t have an Xbox Live profile</span></span>
  * <span data-ttu-id="fd58e-151">Microsoft アカウントの規約にユーザーが同意する必要がある</span><span class="sxs-lookup"><span data-stu-id="fd58e-151">User needs to accept Microsoft Account consent</span></span>


* **<span data-ttu-id="fd58e-152">その他のエラー</span><span class="sxs-lookup"><span data-stu-id="fd58e-152">Other errors</span></span>**

  <span data-ttu-id="fd58e-153">ランタイムはその他の理由によりサインインできませんでした。</span><span class="sxs-lookup"><span data-stu-id="fd58e-153">The runtime was unable to sign-in due to other reasons.</span></span>  <span data-ttu-id="fd58e-154">通常、ゲームまたはユーザーではこれらの問題に対処できません。</span><span class="sxs-lookup"><span data-stu-id="fd58e-154">Typically these issues are not actionable by the game or the user.</span></span> <span data-ttu-id="fd58e-155">c++ API を使う場合、WinRT で xbox_live_result<>.err(); を確認してエラーをチェックし、Platform::Exception^ をキャッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-155">When using c++ API, you would need to check error by checking xbox_live_result<>.err(); on WinRT, you would need to catch Platform::Exception^.</span></span>


### <a name="attempt-to-sign-in-with-ux-if-required"></a><span data-ttu-id="fd58e-156">必要に応じて、UX を使用したサインインを試みる</span><span class="sxs-lookup"><span data-stu-id="fd58e-156">Attempt to sign-in with UX if required</span></span> ###
<span data-ttu-id="fd58e-157">暗黙的サインインに失敗し、ユーザー インターフェイスを表示する準備ができている場合、ゲームは UX を有効にしてユーザーを Xbox Live に対して認証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-157">Your game should authenticate the user to Xbox Live with UX enabled when silent sign-in was unsuccessful, and you are ready to present the user interface.</span></span>

<span data-ttu-id="fd58e-158">UX を使用してローカル ユーザーを認証するには、次の呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="fd58e-158">To authenticate the local user with UX, call</span></span>

<span data-ttu-id="fd58e-159">C++:</span><span class="sxs-lookup"><span data-stu-id="fd58e-159">C++:</span></span>
```
pplx::task<xbox_live_result<sign_in_result>> xbox_live_user::signin(Platform::Object^ coreDispatcher)
```

<span data-ttu-id="fd58e-160">WinRT:</span><span class="sxs-lookup"><span data-stu-id="fd58e-160">WinRT:</span></span>
```
Windows::Foundation::IAsyncOperation<SignInResult^>^ XboxLiveUser::SignInAsync(Platform::Object^ coreDispatcher)
```


* **<span data-ttu-id="fd58e-161">coreDispatcher</span><span class="sxs-lookup"><span data-stu-id="fd58e-161">coreDispatcher</span></span>**

  <span data-ttu-id="fd58e-162">Thread Dispatcher は、スレッド間の通信に使用されます。</span><span class="sxs-lookup"><span data-stu-id="fd58e-162">Thread Dispatcher is used to communication between threads.</span></span> <span data-ttu-id="fd58e-163">サインイン API には、サインイン UI を表示して appx のロケールについての情報を取得するために UI ディスパッチャが必要です。</span><span class="sxs-lookup"><span data-stu-id="fd58e-163">Sign in API requires the UI dispatcher so that it can show the sign in UI and get the information about your appx's locale.</span></span> <span data-ttu-id="fd58e-164">静的 UI スレッド ディスパッチャは、UI スレッドで Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher を呼び出すことで取得できます。</span><span class="sxs-lookup"><span data-stu-id="fd58e-164">You can get the static UI thread dispatcher by calling Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher in the UI thread.</span></span> <span data-ttu-id="fd58e-165">または、この API が UI スレッドで呼び出されることがはっきりしている場合、nullptr を渡すことができます (たとえば JS UWA など)。</span><span class="sxs-lookup"><span data-stu-id="fd58e-165">Or if you're certain that this API is being called on the UI thread, you can pass in nullptr(for example on JS UWA).</span></span>

<span data-ttu-id="fd58e-166">UX を使用したサインイン試行の結果には 3 つの可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-166">There are 3 possible outcomes from the sign-in attempt with UX:</span></span>

* **<span data-ttu-id="fd58e-167">成功</span><span class="sxs-lookup"><span data-stu-id="fd58e-167">Success</span></span>**

  <span data-ttu-id="fd58e-168">デバイスがオンラインの場合、これはユーザーが Xbox Live に正しく認証され、有効なトークンを取得できたことを意味します。</span><span class="sxs-lookup"><span data-stu-id="fd58e-168">If the device is online, this means the user authenticated to Xbox Live successfully, and we were able to get a valid token.</span></span>

  <span data-ttu-id="fd58e-169">デバイスがオフラインの場合、これは、ユーザーが以前に Xbox Live に正しく認証されており、このタイトルから明示的にサインアウトしていないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="fd58e-169">if the device is offline, This means the user has previously authenticated to Xbox Live successfully, and has not explicitly signed-out from this title.</span></span>  <span data-ttu-id="fd58e-170">この場合、タイトルが有効なトークンにアクセスできる保証はないことに注意してください。保証されるのはユーザーの身元が既知であり検証済みであることだけです。</span><span class="sxs-lookup"><span data-stu-id="fd58e-170">Note in this case there is no guarantee that title has access to a valid token, it is only guaranteed that the user’s identity is known and has been verified.</span></span>  <span data-ttu-id="fd58e-171">ユーザーの身元は、Xbox ユーザー ID (xuid) とゲーマータグによってタイトルに知られます。</span><span class="sxs-lookup"><span data-stu-id="fd58e-171">The identity of the user is known to the title xbox user id (xuid) and gamertag.</span></span>

* **<span data-ttu-id="fd58e-172">UserCancel</span><span class="sxs-lookup"><span data-stu-id="fd58e-172">UserCancel</span></span>**

  <span data-ttu-id="fd58e-173">サインイン操作が完了する前にユーザーが操作をキャンセルしました。</span><span class="sxs-lookup"><span data-stu-id="fd58e-173">This means that the user cancelled the sign-in operation before completion.</span></span>  <span data-ttu-id="fd58e-174">このとき、ゲームでは UX を使用したサインインを自動的に再試行しないでください。</span><span class="sxs-lookup"><span data-stu-id="fd58e-174">When this happens, the game should NOT automatically retry sign-in with UX.</span></span>  <span data-ttu-id="fd58e-175">代わりに、ユーザーがサインイン操作を再試行できるゲーム内 UX を表示してください。</span><span class="sxs-lookup"><span data-stu-id="fd58e-175">Instead, it should present in-game UX that allows the user to retry the sign-in operation.</span></span>  <span data-ttu-id="fd58e-176">(例: サインイン ボタン)</span><span class="sxs-lookup"><span data-stu-id="fd58e-176">(For example, a sign-in button)</span></span>

* **<span data-ttu-id="fd58e-177">その他のエラー</span><span class="sxs-lookup"><span data-stu-id="fd58e-177">Other errors</span></span>**

  <span data-ttu-id="fd58e-178">ランタイムはその他の理由によりサインインできませんでした。</span><span class="sxs-lookup"><span data-stu-id="fd58e-178">The runtime was unable to sign-in due to other reasons.</span></span>  <span data-ttu-id="fd58e-179">通常、ゲームまたはユーザーではこれらの問題に対処できません。</span><span class="sxs-lookup"><span data-stu-id="fd58e-179">Typically these issues are not actionable by the game or the user.</span></span> <span data-ttu-id="fd58e-180">c++ API を使う場合、WinRT で xbox_live_result<>.err(); を確認してエラーをチェックし、Platform::Exception^ をキャッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-180">When using c++ API, you would need to check error by checking xbox_live_result<>.err(); on WinRT, you would need to catch Platform::Exception^.</span></span>

### <a name="handling-user-sign-out-completed-event"></a><span data-ttu-id="fd58e-181">ユーザーのサインアウト完了イベントの処理</span><span class="sxs-lookup"><span data-stu-id="fd58e-181">Handling user sign-out completed event</span></span> ###

<span data-ttu-id="fd58e-182">以下のいずれかが発生した場合、ユーザーはタイトルからサインアウトします。</span><span class="sxs-lookup"><span data-stu-id="fd58e-182">The user will sign-out from a title if one of the following happens:</span></span>

1.  <span data-ttu-id="fd58e-183">ユーザーが Xbox アプリ (Windows 10) または本体シェル (Xbox One) からサインアウトした。</span><span class="sxs-lookup"><span data-stu-id="fd58e-183">The user signed-out from the Xbox App (Windows 10) or console shell (Xbox One).</span></span> <span data-ttu-id="fd58e-184">サインアウトすることは、このユーザー用にインストールされたすべての Xbox Live 対応アプリに影響します。</span><span class="sxs-lookup"><span data-stu-id="fd58e-184">Signing out will affect all Xbox Live enabled apps installed for this user.</span></span>
2.  <span data-ttu-id="fd58e-185">ユーザーが別の Microsoft アカウントに切り替えた</span><span class="sxs-lookup"><span data-stu-id="fd58e-185">The user switched to a different Microsoft Account</span></span>
3.  <span data-ttu-id="fd58e-186">ユーザーが別のデバイスから同じタイトルにサインインした</span><span class="sxs-lookup"><span data-stu-id="fd58e-186">The user signed into the same title from a different device</span></span>

<span data-ttu-id="fd58e-187">以上すべてのケースで、タイトルは `xbox_live_user::add_sign_out_completed_handler` または `XboxLiveUser::SignOutCompleted` ハンドラーからイベントを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-187">In all these cases, the title will receive an event from the `xbox_live_user::add_sign_out_completed_handler` or `XboxLiveUser::SignOutCompleted` handlers.</span></span>  <span data-ttu-id="fd58e-188">ゲームではサインアウト完了イベントを適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-188">The game must handle the sign out completed event appropriately:</span></span>
1. <span data-ttu-id="fd58e-189">ゲームでは、ユーザーが Xbox Live からサインアウトしたことを視覚的にユーザーに明示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-189">The game should display clear visual indication to the user that she/he has signed-out from Xbox Live.</span></span>
2. <span data-ttu-id="fd58e-190">ユーザーが既にサインアウトしており、利用可能な承認トークンがないため、ゲームはイベント ハンドラーでいかなる Xbox Live サービス API も呼び出すことができません。</span><span class="sxs-lookup"><span data-stu-id="fd58e-190">The game cannot call any Xbox Live service APIs in the event handler, because the user has already signed-out and there is no authorization token available.</span></span>

### <a name="determining-if-the-device-is-offline"></a><span data-ttu-id="fd58e-191">デバイスがオフラインかどうかの判定</span><span class="sxs-lookup"><span data-stu-id="fd58e-191">Determining if the device is offline</span></span> ###

<span data-ttu-id="fd58e-192">ユーザーが一度サインインしている場合は、オフラインのときでもサインイン API が成功し、前回サインインしたアカウントが返されます。</span><span class="sxs-lookup"><span data-stu-id="fd58e-192">Sign in APIs will still be success when offline if the user has signed in once, and the last signed in account will be returned.</span></span>

<span data-ttu-id="fd58e-193">タイトルがオフラインでプレイできる場合 (キャンペーン モードなど): デバイスがオンラインかオフラインかを問わず、タイトルは、WriteInGameEvent API と接続ストレージ API によってゲームの進行状況を再生および記録することをユーザーに許可できます。これらの API はどちらも、デバイスがオフラインの状態で正しく動作します。</span><span class="sxs-lookup"><span data-stu-id="fd58e-193">If the title can be played offline (Campaign mode, etc.) Regardless the device is online or offline, the title can allow the user to play and record game progress via WriteInGameEvent API and Connected Storage API, both of them work properly while the device is offline.</span></span>

<span data-ttu-id="fd58e-194">タイトルがオフラインでプレイできない場合 (マルチプレイヤー ゲーム、サーバー ベースのゲームなど): タイトルは GetNetworkConnectivityLevel API を呼び出して、デバイスがオフラインかどうかを調べ、状態および解決方法 (例: "続行するにはインターネットに接続する必要があります…") をユーザーに通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd58e-194">If the title cannot be played offline (Multiplayer game or Server based game, etc.) The title should call the GetNetworkConnectivityLevel API to find out if the device is offline, and inform the user about the status and possible solutions (for example, ‘You need to connect to Internet to continue…’)</span></span>
