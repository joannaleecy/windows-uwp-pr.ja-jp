---
title: よく寄せられる質問
description: Xbox の UWP についてのよく寄せられる質問。
ms.date: 03/29/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 265fe827-bd4a-48d4-b362-8793b9b25705
ms.localizationpriority: medium
ms.openlocfilehash: 036c3c1832bbb3e27a93671f399a9a97c7afaba3
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7840682"
---
# <a name="frequently-asked-questions"></a><span data-ttu-id="ce4cd-104">よく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="ce4cd-104">Frequently asked questions</span></span>

<span data-ttu-id="ce4cd-105">期待どおりに動作しない場合には、</span><span class="sxs-lookup"><span data-stu-id="ce4cd-105">Things not working the way you expected?</span></span> <span data-ttu-id="ce4cd-106">このページのよく寄せられる質問を確認します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-106">Look through this page of frequently asked questions.</span></span> <span data-ttu-id="ce4cd-107">また、「[既知の問題](known-issues.md)」と「[ユニバーサル Windows アプリの開発](https://go.microsoft.com/fwlink/?linkid=839446)」のフォーラムも確認します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-107">Also check out the [Known issues](known-issues.md) topic and the [Developing Universal Windows apps](https://go.microsoft.com/fwlink/?linkid=839446) forum.</span></span> 

### <a name="why-arent-my-games-and-apps-working"></a><span data-ttu-id="ce4cd-108">作成したゲームとアプリが動作しない</span><span class="sxs-lookup"><span data-stu-id="ce4cd-108">Why aren't my games and apps working?</span></span>

<span data-ttu-id="ce4cd-109">ゲームやアプリが動作しない場合、またストアや Live サービスにアクセスできない場合、開発者モードで実行している場合があります。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-109">If your games and apps aren't working, or if you don't have access to the store or to Live services, you are probably running in Developer Mode.</span></span> <span data-ttu-id="ce4cd-110">現在のモードを調べるには、コントローラーの **[ホーム]** ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-110">To figure out which mode you're currently in, press the **Home** button on your controller.</span></span> <span data-ttu-id="ce4cd-111">製品版ホーム エクスペリエンスではなく Dev Home に移動した場合は、開発者モードです。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-111">If this takes you to Dev Home instead of the retail Home experience, you're in Developer Mode.</span></span> <span data-ttu-id="ce4cd-112">ゲームをプレイする場合には、Dev Home を開き、\*\*[Leave developer mode] \*\* ボタンを使って、リテール モードに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-112">If you want to play games, you can open Dev Home and switch back to Retail Mode by using the **Leave developer mode** button.</span></span>

### <a name="why-cant-i-connect-to-my-xbox-one-using-visual-studio"></a><span data-ttu-id="ce4cd-113">Visual Studio を使って Xbox One に接続できない</span><span class="sxs-lookup"><span data-stu-id="ce4cd-113">Why can't I connect to my Xbox One using Visual Studio?</span></span>

<span data-ttu-id="ce4cd-114">まず、リテール モードでなく、開発者モードで実行していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-114">Start by verifying that you are running in Developer Mode, and not in Retail Mode.</span></span> <span data-ttu-id="ce4cd-115">リテール モードでは、Xbox One に接続できません。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-115">You cannot connect to your Xbox One when it is in Retail Mode.</span></span> <span data-ttu-id="ce4cd-116">現在のモードを調べるには、コントローラーの **[ホーム]** ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-116">To figure out which mode you're currently in, press the **Home** button on your controller.</span></span> <span data-ttu-id="ce4cd-117">Dev Home ではなく Gold/Live コンテンツが表示される場合はリテール モードであるため、開発者モードのアクティブ化用アプリを実行して開発者モードに切り替える必要があります。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-117">If you see Gold/Live content instead of Dev Home, you're in Retail Mode and you need to run the Dev Mode Activation app to switch to Developer Mode.</span></span>

> [!NOTE]
> <span data-ttu-id="ce4cd-118">アプリを展開するには、ユーザーをサインインさせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-118">You must have a user signed in to deploy an app.</span></span>

<span data-ttu-id="ce4cd-119">詳しくは、このページの「[展開の失敗を修正する](#fixing-deployment-failures)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-119">For more information, see [Fixing deployment failures](#fixing-deployment-failures) later on this page.</span></span>

### <a name="how-do-i-switch-between-retail-mode-and-developer-mode"></a><span data-ttu-id="ce4cd-120">リテール モードと開発者モードの切り替え方法</span><span class="sxs-lookup"><span data-stu-id="ce4cd-120">How do I switch between Retail Mode and Developer Mode?</span></span>

<span data-ttu-id="ce4cd-121">これらの状態について詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」の指示に従います。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-121">Follow the [Xbox One Developer Mode Activation](devkit-activation.md) instructions to understand more about these states.</span></span>

### <a name="how-do-i-know-if-i-am-in-retail-mode-or-developer-mode"></a><span data-ttu-id="ce4cd-122">リテール モードと開発者モードのどちらで実行されているかを確認する方法</span><span class="sxs-lookup"><span data-stu-id="ce4cd-122">How do I know if I am in Retail Mode or Developer Mode?</span></span>

<span data-ttu-id="ce4cd-123">これらの状態について詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」の指示に従います。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-123">Follow the [Xbox One Developer Mode Activation](devkit-activation.md) instructions to understand more about these states.</span></span> 

<span data-ttu-id="ce4cd-124">現在のモードを調べるには、コントローラーの **[ホーム]** ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-124">To figure out which mode you're currently in, press the **Home** button on your controller.</span></span> 
- <span data-ttu-id="ce4cd-125">Dev Home が表示される場合は開発者モードです。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-125">If this takes you to Dev Home, you're in Developer Mode.</span></span>
- <span data-ttu-id="ce4cd-126">Gold/Live コンテンツが表示された場合はリテール モードです。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-126">If you see Gold/Live content, you're in Retail Mode.</span></span>

### <a name="will-my-games-and-apps-still-work-if-i-activate-developer-mode"></a><span data-ttu-id="ce4cd-127">開発者モードをアクティブ化してもゲームやアプリは動作しますか</span><span class="sxs-lookup"><span data-stu-id="ce4cd-127">Will my games and apps still work if I activate Developer Mode?</span></span>

<span data-ttu-id="ce4cd-128">はい、開発者モードからリテール モードに切り替えて、ゲームをプレイできます。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-128">Yes, you can switch from Developer Mode to Retail Mode, where you can play your games.</span></span> <span data-ttu-id="ce4cd-129">詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-129">For more information, see the [Xbox One Developer Mode Activation](devkit-activation.md) page.</span></span> 

### <a name="can-i-develop-and-publish-x86-apps-for-xbox"></a><span data-ttu-id="ce4cd-130">Xbox 用の x86 アプリを開発および公開できますか</span><span class="sxs-lookup"><span data-stu-id="ce4cd-130">Can I develop and publish x86 apps for Xbox?</span></span>
<span data-ttu-id="ce4cd-131">Xbox では、x86 アプリの開発または x86 アプリのストアへの申請をサポートしなくなりました。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-131">Xbox no longer supports x86 app development or x86 app submissions to the store.</span></span> 

### <a name="will-i-lose-my-games-and-apps-or-saved-changes"></a><span data-ttu-id="ce4cd-132">ゲームやアプリ、保存した変更を失うことがありますか</span><span class="sxs-lookup"><span data-stu-id="ce4cd-132">Will I lose my games and apps or saved changes?</span></span>

<span data-ttu-id="ce4cd-133">開発者プログラムへの参加を停止しても、インストールしたゲームやアプリは失われません。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-133">If you decide to leave the Developer Program, you won't lose your installed games and apps.</span></span> <span data-ttu-id="ce4cd-134">またオンラインでプレイした場合には、保存したゲームはすべて Live アカウントのクラウド プロファイルに保存されていますので、それを失うことはありません。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-134">In addition, as long as you were online when you played them, your saved games are all saved on your Live account cloud profile, so you won't lose them.</span></span>

### <a name="how-do-i-leave-the-developer-program"></a><span data-ttu-id="ce4cd-135">開発者プログラムへの参加を停止する方法</span><span class="sxs-lookup"><span data-stu-id="ce4cd-135">How do I leave the Developer Program?</span></span>

<span data-ttu-id="ce4cd-136">開発者プログラムへの参加を停止する方法について詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-deactivation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-136">See the [Xbox One Developer Mode Deactivation](devkit-deactivation.md) topic for details about how to leave the Developer Program.</span></span>

### <a name="i-sold-my-xbox-one-and-left-it-in-developer-mode-how-do-i-deactivate-developer-mode"></a><span data-ttu-id="ce4cd-137">Xbox One を開発者モードにしたままで売却した場合に、</span><span class="sxs-lookup"><span data-stu-id="ce4cd-137">I sold my Xbox One and left it in Developer Mode.</span></span> <span data-ttu-id="ce4cd-138">開発者モードを非アクティブ化する方法</span><span class="sxs-lookup"><span data-stu-id="ce4cd-138">How do I deactivate Developer Mode?</span></span>

<span data-ttu-id="ce4cd-139">しなくなった Xbox One にアクセスできる場合、は、Windows のパートナー センターで無効にできます。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-139">If you no longer have access to your Xbox One, you can deactivate it in Windows Partner Center.</span></span> <span data-ttu-id="ce4cd-140">詳細については、 [Xbox One 開発者モードのアクティブ化](devkit-deactivation.md#deactivate-your-console-using-partner-center)のトピックで、**パートナー センターを使用して、本体を非アクティブ化**のセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-140">For details, see the **Deactivate your console using Partner Center** section in the [Xbox One Developer Mode Deactivation](devkit-deactivation.md#deactivate-your-console-using-partner-center) topic.</span></span> 

### <a name="i-left-the-developer-program-using-partner-center-but-im-in-still-developer-mode-what-do-i-do"></a><span data-ttu-id="ce4cd-141">まだ開発者モードで停止しますが、パートナー センターを使用して開発者プログラムをまま教えてください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-141">I left the Developer Program using Partner Center but I'm in still Developer Mode.</span></span> <span data-ttu-id="ce4cd-142">どうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-142">What do I do?</span></span>

<span data-ttu-id="ce4cd-143">Dev Home を開始し、**[Leave developer mode]** ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-143">Start Dev Home and select the **Leave developer mode** button.</span></span> <span data-ttu-id="ce4cd-144">コンソールがリテール モードで再起動します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-144">This will restart your console in Retail Mode.</span></span> 

### <a name="can-i-publish-my-app"></a><span data-ttu-id="ce4cd-145">自分のアプリを公開できますか</span><span class="sxs-lookup"><span data-stu-id="ce4cd-145">Can I publish my app?</span></span>

<span data-ttu-id="ce4cd-146">[開発者アカウント](https://developer.microsoft.com/store/register)がある場合はパートナー センターを使用して[アプリを公開](../publish/index.md)できます。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-146">You can [publish apps](../publish/index.md) through Partner Center if you have a [developer account](https://developer.microsoft.com/store/register).</span></span> <span data-ttu-id="ce4cd-147">市販の Xbox One コンソールで作成されテストされた UWP アプリは、Windows で現在行われているものと同様の取り込み、レビュー、公開のプロセスが行われ、さらに Xbox One の標準を満たすための追加のレビューが行われます。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-147">UWP apps created and tested on a retail Xbox One console will go through the same ingestion, review, and publication process that Windows conducts today, with additional reviews to meet today's Xbox One standards.</span></span>

### <a name="can-i-publish-my-game"></a><span data-ttu-id="ce4cd-148">自分のゲームを公開できますか</span><span class="sxs-lookup"><span data-stu-id="ce4cd-148">Can I publish my game?</span></span>

<span data-ttu-id="ce4cd-149">UWP と Xbox One の開発者モードを使って、Xbox One でゲームの構築とテストを行えます。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-149">You can use UWP and your Xbox One in Developer Mode to build and test your games on Xbox One.</span></span> <span data-ttu-id="ce4cd-150">UWP ゲームを公開するには、[ID@XBOX](http://www.xbox.com/Developers/id) に登録するか、[Xbox Live Creators プログラム](https://developer.microsoft.com/games/xbox/xboxlive/creator)に参加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-150">To publish UWP games, you must register with [ID@XBOX](http://www.xbox.com/Developers/id) or be part of the [Xbox Live Creators Program](https://developer.microsoft.com/games/xbox/xboxlive/creator).</span></span> <span data-ttu-id="ce4cd-151">詳しくは、「[開発者プログラムの概要](https://developer.microsoft.com/games/xbox/docs/xboxlive/get-started/developer-program-overview.html)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-151">For more info, see [Developer Program Overview](https://developer.microsoft.com/games/xbox/docs/xboxlive/get-started/developer-program-overview.html).</span></span>

### <a name="will-the-standard-game-engines-work"></a><span data-ttu-id="ce4cd-152">標準的なゲーム エンジンは機能しますか</span><span class="sxs-lookup"><span data-stu-id="ce4cd-152">Will the standard Game engines work?</span></span>

<span data-ttu-id="ce4cd-153">このリリースの「[既知の問題](known-issues.md)」ページを確認してください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-153">Check out the [Known issues](known-issues.md) page for this release.</span></span>

### <a name="what-capabilities-and-system-resources-are-available-to-uwp-games-on-xbox-one"></a><span data-ttu-id="ce4cd-154">Xbox One の UWP ゲームで利用可能な機能とシステム リソース</span><span class="sxs-lookup"><span data-stu-id="ce4cd-154">What capabilities and system resources are available to UWP games on Xbox One?</span></span> 

<span data-ttu-id="ce4cd-155">詳しくは、「[Xbox One 上の UWP アプリとゲームのシステム リソース](system-resource-allocation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-155">For information, see [System resources for UWP apps and games on Xbox One](system-resource-allocation.md).</span></span>

### <a name="if-i-create-a-directx-12-uwp-game-will-it-run-on-my-xbox-one-in-developer-mode"></a><span data-ttu-id="ce4cd-156">DirectX 12 の UWP ゲームを作成する場合、それは Xbox One の開発者モードで動作しますか</span><span class="sxs-lookup"><span data-stu-id="ce4cd-156">If I create a DirectX 12 UWP game, will it run on my Xbox One in Developer Mode?</span></span>

<span data-ttu-id="ce4cd-157">詳しくは、「[Xbox One 上の UWP アプリとゲームのシステム リソース](system-resource-allocation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-157">For information, see [System resources for UWP apps and games on Xbox One](system-resource-allocation.md).</span></span>

### <a name="will-the-entire-uwp-api-surface-be-available-on-xbox"></a><span data-ttu-id="ce4cd-158">Xbox では UWP API のすべてを利用できますか</span><span class="sxs-lookup"><span data-stu-id="ce4cd-158">Will the entire UWP API surface be available on Xbox?</span></span>

<span data-ttu-id="ce4cd-159">このリリースの「[既知の問題](known-issues.md)」ページを確認してください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-159">Check out the [Known issues](known-issues.md) page for this release.</span></span>

### <a name="fixing-deployment-failures"></a><span data-ttu-id="ce4cd-160">展開の失敗を修正する</span><span class="sxs-lookup"><span data-stu-id="ce4cd-160">Fixing deployment failures</span></span>

<span data-ttu-id="ce4cd-161">Visual Studio からアプリを展開できない場合、次の手順が問題の解決に役立つ場合があります。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-161">If you can't deploy your app from Visual Studio, these steps may help you fix the problem.</span></span> <span data-ttu-id="ce4cd-162">それでも解決できない場合には、フォーラムに投稿してみます。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-162">If you get stuck, ask for help on the forum.</span></span>

> [!NOTE]
> <span data-ttu-id="ce4cd-163">アプリを展開するには、ユーザーをサインインさせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-163">You must have a user signed in to deploy an app.</span></span> <span data-ttu-id="ce4cd-164">0x87e10008 エラー メッセージが表示された場合は、ユーザーがサインインしているかどうかを確認し、もう一度サインインさせます。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-164">If you receive a 0x87e10008 error message, make sure you have a user signed in and try again.</span></span>

<span data-ttu-id="ce4cd-165">Visual Studio が Xbox One に接続できない場合:</span><span class="sxs-lookup"><span data-stu-id="ce4cd-165">If Visual Studio cannot connect to your Xbox One:</span></span>

1. <span data-ttu-id="ce4cd-166">開発者モードであることを確認します (このページで既に説明した方法を確認します)。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-166">Make sure that you are in Developer Mode (discussed earlier on this page).</span></span>
2. <span data-ttu-id="ce4cd-167">開発用 PC が正しく設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-167">Make sure that you have set up your development PC correctly.</span></span> <span data-ttu-id="ce4cd-168">[Xbox One の UWP アプリ開発の概要](getting-started.md)の*すべての*指示に従いましたか。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-168">Did you follow *all* of the directions in [Getting started with UWP app development on Xbox One](getting-started.md)?</span></span> 

3. <span data-ttu-id="ce4cd-169">まだの場合、「[開発環境のセットアップ](development-environment-setup.md)」と「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をよくお読みください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-169">If you haven't yet, read through the [Development environment setup](development-environment-setup.md) topic and the [Introduction to Xbox One tools](introduction-to-xbox-tools.md) topic.</span></span>

4. <span data-ttu-id="ce4cd-170">開発用 PC から本体の IP アドレスに "ping" ができることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-170">Make sure that you can “ping” your console IP address from your development PC.</span></span>
  > [!NOTE]
  > <span data-ttu-id="ce4cd-171">展開のパフォーマンスを最大限に引き出すために、本体には、有線接続を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-171">In order to get the best deployment performance, we recommend that you use a wired connection to your console.</span></span>

5. <span data-ttu-id="ce4cd-172">**[デバッグ]** タブの [認証] ドロップダウン リストで [ユニバーサル (暗号化されていないプロトコル)] を使用していることを確認します。詳しくは、「[開発環境のセットアップ](development-environment-setup.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-172">Make sure that you are using the Universal (Unencrypted Protocol) in the Authentication drop-down list on the **Debug** tab. For more details, see [Development environment setup](development-environment-setup.md).</span></span>


### <a name="if-im-building-an-app-using-htmljavascript-how-do-i-enable-gamepad-navigation"></a><span data-ttu-id="ce4cd-173">HTML/JavaScript を使用したアプリを構築する場合に、ゲームパッドのナビゲーションを有効にする方法</span><span class="sxs-lookup"><span data-stu-id="ce4cd-173">If I'm building an app using HTML/JavaScript, how do I enable Gamepad navigation?</span></span>

<span data-ttu-id="ce4cd-174">TVHelpers は、JavaScript と XAML/C# のサンプルとライブラリです。JavaScript と C# による、Xbox One とテレビの優れたエクスペリエンスの構築をサポートします。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-174">TVHelpers is a set of JavaScript and XAML/C# samples and libraries to help you build great Xbox One and TV experiences in JavaScript and C#.</span></span> <span data-ttu-id="ce4cd-175">TVJS は Xbox One のための優れた UWP アプリの構築をサポートします。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-175">TVJS is a library that helps you build premium UWP apps for Xbox One.</span></span> <span data-ttu-id="ce4cd-176">TVJS には、自動コントローラー ナビゲーション、リッチ メディアの再生、検索などのサポートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-176">TVJS includes support for automatic controller navigation, rich media playback, search, and more.</span></span> <span data-ttu-id="ce4cd-177">ホストされた Web アプリで TVJS を使うと、パッケージ化された Web UWP アプリを使う場合のように容易に、すべての Windows ランタイム API にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-177">You can use TVJS with your hosted web app just as easily as with a packaged web UWP app with full access to the Windows Runtime APIs.</span></span>

<span data-ttu-id="ce4cd-178">詳しくは、「[TVHelpers](https://github.com/Microsoft/TVHelpers) プロジェクトとプロジェクト [wiki](https://github.com/Microsoft/TVHelpers/wiki)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce4cd-178">For more information, see the [TVHelpers](https://github.com/Microsoft/TVHelpers) project and the project [wiki](https://github.com/Microsoft/TVHelpers/wiki).</span></span>

## <a name="see-also"></a><span data-ttu-id="ce4cd-179">関連項目</span><span class="sxs-lookup"><span data-stu-id="ce4cd-179">See also</span></span>
- [<span data-ttu-id="ce4cd-180">Xbox One の UWP の既知の問題</span><span class="sxs-lookup"><span data-stu-id="ce4cd-180">Known issues with UWP on Xbox One</span></span>](known-issues.md)
- [<span data-ttu-id="ce4cd-181">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="ce4cd-181">UWP on Xbox One</span></span>](index.md)
- [<span data-ttu-id="ce4cd-182">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="ce4cd-182">UWP on Xbox One</span></span>](index.md)
