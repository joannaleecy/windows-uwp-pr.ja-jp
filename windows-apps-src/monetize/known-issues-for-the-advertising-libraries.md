---
author: mcleanbyron
ms.assetid: 9ca1f880-2ced-46b4-8ea7-aba43d2ff863
description: "Microsoft Advertising ライブラリの現在のリリースにおける既知の問題について説明します。"
title: "Advertising ライブラリに関する既知の問題"
ms.author: mcleans
ms.date: 07/20/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, UWP, 広告, Advertising, 既知の問題"
ms.openlocfilehash: b18c4568770afb70bcca991c79d59a9912981705
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="known-issues-for-the-advertising-libraries"></a><span data-ttu-id="7e541-104">Advertising ライブラリに関する既知の問題</span><span class="sxs-lookup"><span data-stu-id="7e541-104">Known issues for the advertising libraries</span></span>




<span data-ttu-id="7e541-105">このトピックでは、Microsoft Advertising SDK (UWP アプリ用) と、Windows および Windows Phone 8.x 用の Microsoft Advertising SDK (Windows 8.1 アプリおよび Windows Phone 8.x アプリ用) に含まれている Microsoft Advertising ライブラリの現在のリリースに関する既知の問題を示します。</span><span class="sxs-lookup"><span data-stu-id="7e541-105">This topic lists the known issues with the current release of the Microsoft advertising libraries in the Microsoft Advertising SDK (for UWP apps) and the Microsoft Advertising SDK for Windows and Windows Phone 8.x (for Windows 8.1 and Windows Phone 8.x apps).</span></span>

## <a name="windows-phone-8x-silverlight-projects"></a><span data-ttu-id="7e541-106">Windows Phone 8.x Silverlight プロジェクト</span><span class="sxs-lookup"><span data-stu-id="7e541-106">Windows Phone 8.x Silverlight projects</span></span>

<span data-ttu-id="7e541-107">Windows および Windows Phone 8.x 用の Microsoft Advertising SDK では、Windows Phone 8.x Silverlight プロジェクトのサポートが制限されています。</span><span class="sxs-lookup"><span data-stu-id="7e541-107">The Microsoft Advertising SDK for Windows and Windows Phone 8.x has limited support for Windows Phone 8.x Silverlight projects.</span></span> <span data-ttu-id="7e541-108">詳細については、[Windows Phone 8.x Silverlight プロジェクト用の広告のサポート](adcontrol-in-windows-phone-silverlight.md#silverlight_support)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e541-108">For more information, see [Advertising support for Windows Phone 8.x Silverlight projects](adcontrol-in-windows-phone-silverlight.md#silverlight_support).</span></span>

<span data-ttu-id="7e541-109">Windows Phone 8.x Silverlight プロジェクト用の Microsoft Advertising アセンブリを入手するには、[Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。次に、プロジェクトを Visual Studio で開き、**[プロジェクト]** > **[接続済みサービスを追加します]** > **[広告メディエーター]** の順に移動して、アセンブリを自動的にダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="7e541-109">To get the Microsoft advertising assemblies for Windows Phone 8.x Silverlight projects, install the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk), open your project in Visual Studio, and then go to **Project** > **Add Connected Service** > **Ad Mediator** to automatically download the assemblies.</span></span> <span data-ttu-id="7e541-110">その後、広告仲介を使用しない場合は、広告メディエーターの参照をプロジェクトから削除できます。</span><span class="sxs-lookup"><span data-stu-id="7e541-110">After doing this, you can remove the ad mediator references from your project if you do not want to use ad mediation.</span></span> <span data-ttu-id="7e541-111">詳しくは、「[Windows Phone Silverlight の AdControl](adcontrol-in-windows-phone-silverlight.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e541-111">For more information, see [AdControl in Windows Phone Silverlight](adcontrol-in-windows-phone-silverlight.md).</span></span>

## <a name="adcontrol-interface-unknown-in-xaml"></a><span data-ttu-id="7e541-112">XAML での不明な AdControl インターフェイス</span><span class="sxs-lookup"><span data-stu-id="7e541-112">AdControl interface unknown in XAML</span></span>

<span data-ttu-id="7e541-113">[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) の XAML マークアップに、そのインターフェイスが不明であることを示す青い破線が表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="7e541-113">The XAML markup for an [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) may incorrectly show a blue curvy line implying that the interface is unknown.</span></span> <span data-ttu-id="7e541-114">これは、x86 をターゲットとして設定している場合にのみ発生するもので、無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="7e541-114">This occurs only when targeting x86, and it may be ignored.</span></span>

## <a name="lasterror-from-previous-ad-request"></a><span data-ttu-id="7e541-115">以前の広告要求からの lastError</span><span class="sxs-lookup"><span data-stu-id="7e541-115">lastError from previous ad request</span></span>

<span data-ttu-id="7e541-116">以前の広告要求の **lastError** が残っている場合、次の広告呼び出し中にこのイベントが 2 回を発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7e541-116">If there is a leftover **lastError** from the previous ad request, the event may be fired twice during the next ad call.</span></span> <span data-ttu-id="7e541-117">その一方で新しい広告要求が行われ、有効な広告が生成されると、この動作によって混乱が生じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7e541-117">While the new ad request will still be made and may yield a valid ad, this behavior may cause confusion.</span></span>

## <a name="interstitial-ads-and-navigation-buttons-on-phones"></a><span data-ttu-id="7e541-118">スポット広告と電話のナビゲーション ボタン</span><span class="sxs-lookup"><span data-stu-id="7e541-118">Interstitial ads and navigation buttons on phones</span></span>

<span data-ttu-id="7e541-119">ハードウェア ボタンの代わりにソフトウェア ボタンの **"戻る"**、**"スタート"**、**"検索"** を備えた電話 (またはエミュレーター) では、スポット広告用のカウントダウン タイマー ボタンとクリックスルー ボタンが隠れる場合があります。</span><span class="sxs-lookup"><span data-stu-id="7e541-119">On phones (or emulators) that have software **Back**, **Start**, and **Search** buttons instead of hardware buttons, the countdown timer and click through buttons for interstitial ads may be obscured.</span></span>

## <a name="recently-created-ads-are-not-being-served-to-your-app"></a><span data-ttu-id="7e541-120">最近作成した広告がアプリに提供されない</span><span class="sxs-lookup"><span data-stu-id="7e541-120">Recently created ads are not being served to your app</span></span>

<span data-ttu-id="7e541-121">その広告が最近 (1 日以内) 作成された広告の場合は、すぐに利用可能にならない場合があります。</span><span class="sxs-lookup"><span data-stu-id="7e541-121">If you have created an ad recently (less than a day), it might not be available immediately.</span></span> <span data-ttu-id="7e541-122">編集コンテンツに関する承認が済んでいる場合、広告は、広告サーバーによって処理され、インベントリとして利用可能になった時点で提供されるようになります。</span><span class="sxs-lookup"><span data-stu-id="7e541-122">If the ad has been approved for editorial content, it will be served once the advertising server has processed it and the ad is available as inventory.</span></span>

## <a name="no-ads-are-shown-in-your-app"></a><span data-ttu-id="7e541-123">アプリに広告が表示されない</span><span class="sxs-lookup"><span data-stu-id="7e541-123">No ads are shown in your app</span></span>

<span data-ttu-id="7e541-124">広告が表示されない場合、ネットワーク エラーを含むさまざまな理由があります。</span><span class="sxs-lookup"><span data-stu-id="7e541-124">There are many reasons you may see no ads, including network errors.</span></span> <span data-ttu-id="7e541-125">次の理由も考えられます。</span><span class="sxs-lookup"><span data-stu-id="7e541-125">Other reasons might include:</span></span>

* <span data-ttu-id="7e541-126">Windows デベロッパー センターで、アプリのコードの **AdControl** を超えるサイズまたはこれよりも小さいサイズの広告ユニットが選択されています。</span><span class="sxs-lookup"><span data-stu-id="7e541-126">Selecting an ad unit in Windows Dev Center with a size that is greater or less than the size of the **AdControl** in your app's code.</span></span>

* <span data-ttu-id="7e541-127">広告ユニット ID に[テスト モードの値](test-mode-values.md)を使ってライブ アプリを実行した場合、広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="7e541-127">Ads will not appear if you're using a [test mode value](test-mode-values.md) for your ad unit ID when running a live app.</span></span>

* <span data-ttu-id="7e541-128">新しい広告ユニット ID の作成を行ったのがこの 30 分以内の場合、サーバーによってシステムに新しいデータが伝達されるまで、広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="7e541-128">If you created a new ad unit ID in the past half-hour, you might not see an ad until the servers propagate new data through the system.</span></span> <span data-ttu-id="7e541-129">広告が表示されていた既存の ID を使用すると、広告はすぐに表示されます。</span><span class="sxs-lookup"><span data-stu-id="7e541-129">Existing IDs that have shown ads before should show ads immediately.</span></span>

<span data-ttu-id="7e541-130">アプリにテスト広告が表示される場合は、コードが正常に動作していて広告を表示できることを示します。</span><span class="sxs-lookup"><span data-stu-id="7e541-130">If you can see test ads in the app, your code is working and is able to display ads.</span></span> <span data-ttu-id="7e541-131">問題が発生した場合は、[製品サポート](https://go.microsoft.com/fwlink/p/?LinkId=331508)にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="7e541-131">If you encounter issues, contact [product support](https://go.microsoft.com/fwlink/p/?LinkId=331508).</span></span> <span data-ttu-id="7e541-132">このページで、**[In-App 広告]** を選択してください。</span><span class="sxs-lookup"><span data-stu-id="7e541-132">On that page, choose **In-App Advertising**.</span></span>

<span data-ttu-id="7e541-133">[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)に質問を投稿することもできます。</span><span class="sxs-lookup"><span data-stu-id="7e541-133">You can also post a question in the [forum](http://go.microsoft.com/fwlink/p/?LinkId=401266).</span></span>

## <a name="test-ads-are-showing-in-your-app-instead-of-live-ads"></a><span data-ttu-id="7e541-134">ライブ広告ではなくテスト広告がアプリに表示される</span><span class="sxs-lookup"><span data-stu-id="7e541-134">Test ads are showing in your app instead of live ads</span></span>

<span data-ttu-id="7e541-135">ライブ広告が想定されているときでもテスト広告が表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="7e541-135">Test ads can be shown, even when you are expecting live ads.</span></span> <span data-ttu-id="7e541-136">これは、次の状況で発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="7e541-136">This can happen in the following scenarios:</span></span>

* <span data-ttu-id="7e541-137">ストアで使用されているライブ アプリケーション ID を広告プラットフォームが確認または検出できない。</span><span class="sxs-lookup"><span data-stu-id="7e541-137">Our advertising platform cannot verify or find the live application ID used in the Store.</span></span> <span data-ttu-id="7e541-138">この場合、広告ユニットがユーザーによって作成されたとき、その状態は "ライブ" (非テスト) として開始されますが、最初の広告要求が行われてから 6 時間以内にテスト状態に移行します。</span><span class="sxs-lookup"><span data-stu-id="7e541-138">In this case, when an ad unit is created by a user, its status can start as live (non-test) but will move to test status within 6 hours after the first ad request.</span></span> <span data-ttu-id="7e541-139">その状態は、10 日間テスト アプリからの要求がない場合に "ライブ" に戻ります。</span><span class="sxs-lookup"><span data-stu-id="7e541-139">It will change back to live if there are no requests from test apps for 10 days.</span></span>

* <span data-ttu-id="7e541-140">サイドローディングされたアプリやエミュレーターで実行されているアプリには、ライブ広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="7e541-140">Side-loaded apps or apps that are running in the emulator will not show live ads.</span></span>

<span data-ttu-id="7e541-141">ライブ広告ユニットによってテスト広告が提供されているとき、Windows デベロッパー センターには、広告ユニットの状態として **"Active and serving test ads"** が表示されます。</span><span class="sxs-lookup"><span data-stu-id="7e541-141">When a live ad unit is serving test ads, the ad unit’s status shows **Active and serving test ads** in Windows Dev Center.</span></span> <span data-ttu-id="7e541-142">現時点で、これは、電話アプリには適用されません。</span><span class="sxs-lookup"><span data-stu-id="7e541-142">This does not currently apply to phone apps.</span></span>

## <a name="obsolete-test-values-for-ad-unit-id-and-application-id-no-longer-working"></a><span data-ttu-id="7e541-143">廃止され、現在無効となっている広告ユニット ID とアプリケーション ID のテスト値</span><span class="sxs-lookup"><span data-stu-id="7e541-143">Obsolete test values for ad unit ID and application ID no longer working</span></span>

<span data-ttu-id="7e541-144">以下の Windows Phone Silverlight アプリ用の次のテスト値は廃止され、現在無効になっています。</span><span class="sxs-lookup"><span data-stu-id="7e541-144">The following test values for Windows Phone Silverlight apps are obsolete, and will no longer work.</span></span> <span data-ttu-id="7e541-145">既存のプロジェクトでこれらのテスト値を使用している場合は、「[テスト モードの値](test-mode-values.md)」で提供されている値を使用するようにプロジェクトを更新してください。</span><span class="sxs-lookup"><span data-stu-id="7e541-145">If you have an existing project that uses these test values, update your project to use the values provided in [Test mode values](test-mode-values.md).</span></span>

| <span data-ttu-id="7e541-146">アプリケーション ID</span><span class="sxs-lookup"><span data-stu-id="7e541-146">Application ID</span></span>  |  <span data-ttu-id="7e541-147">広告ユニット ID</span><span class="sxs-lookup"><span data-stu-id="7e541-147">Ad unit ID</span></span>    |
|-----------------|----------------|
| <span data-ttu-id="7e541-148">test_client</span><span class="sxs-lookup"><span data-stu-id="7e541-148">test_client</span></span>     |  <span data-ttu-id="7e541-149">Image320_50</span><span class="sxs-lookup"><span data-stu-id="7e541-149">Image320_50</span></span>   |
| <span data-ttu-id="7e541-150">test_client</span><span class="sxs-lookup"><span data-stu-id="7e541-150">test_client</span></span>     |  <span data-ttu-id="7e541-151">Image300_50</span><span class="sxs-lookup"><span data-stu-id="7e541-151">Image300_50</span></span>   |
| <span data-ttu-id="7e541-152">test_client</span><span class="sxs-lookup"><span data-stu-id="7e541-152">test_client</span></span>     |  <span data-ttu-id="7e541-153">TextAd</span><span class="sxs-lookup"><span data-stu-id="7e541-153">TextAd</span></span>   |
| <span data-ttu-id="7e541-154">test_client</span><span class="sxs-lookup"><span data-stu-id="7e541-154">test_client</span></span>     |  <span data-ttu-id="7e541-155">Image480_80</span><span class="sxs-lookup"><span data-stu-id="7e541-155">Image480_80</span></span>   |

<span id="reference_errors"/>
## <a name="reference-errors-caused-by-targeting-any-cpu-in-your-project"></a><span data-ttu-id="7e541-156">プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する</span><span class="sxs-lookup"><span data-stu-id="7e541-156">Reference errors caused by targeting Any CPU in your project</span></span>

<span data-ttu-id="7e541-157">Microsoft Advertising ライブラリを使う場合、プロジェクトで **"Any CPU"** をターゲットにすることはできません。</span><span class="sxs-lookup"><span data-stu-id="7e541-157">When using the Microsoft advertising libraries, you cannot target **Any CPU** in your project.</span></span> <span data-ttu-id="7e541-158">プロジェクトのターゲットを **Any CPU** プラットフォームに設定した場合、次のような参照を追加した後で警告が表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="7e541-158">If your project targets the **Any CPU** platform, you may see a warning after adding the reference similar to this one.</span></span>

![referenceerror\-solutionexplorer](images/13-19629921-023c-42ec-b8f5-bc0b63d5a191.jpg)

<span data-ttu-id="7e541-160">この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="7e541-160">To remove this warning, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="7e541-161">デバッグおよびリリース用の構成のプラットフォームのターゲットを設定するには、**Configuration Manager** を使用します。</span><span class="sxs-lookup"><span data-stu-id="7e541-161">Use **Configuration Manager** to set the platform targets for debug and release configurations.</span></span>

![configurationmanagerwin10](images/13-87074274-c10d-4dbd-9a06-453b7184f8de.png)

<span data-ttu-id="7e541-163">(次の図に示すように) ストアに申請するアプリ パッケージを作成するときは、ターゲットのアーキテクチャを必ず指定してください。</span><span class="sxs-lookup"><span data-stu-id="7e541-163">When you create your app packages for store submission (as shown in the following images), be sure to include the architectures you intend to target.</span></span> <span data-ttu-id="7e541-164">x64 OS で x86 ビルドを実行する場合は、x64 をスキップしてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="7e541-164">You may opt to skip x64 if you intend to run x86 builds on the x64 OS.</span></span>

![projectstorecreateapppackages](images/13-a99b05a4-8917-4c53-822e-2548fadf828a.png)

![createapppackages](images/13-16280cb1-a838-42b9-9256-eac7f33f5603.png)

## <a name="z-order-in-javascripthtml-apps"></a><span data-ttu-id="7e541-167">JavaScript/HTML アプリでの Z オーダー</span><span class="sxs-lookup"><span data-stu-id="7e541-167">Z-order in JavaScript/HTML apps</span></span>

<span data-ttu-id="7e541-168">JavaScript/HTML アプリでは、z オーダーの予約済みの MAX-10 の範囲に要素を配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="7e541-168">JavaScript/HTML apps must not place elements into the reserved MAX-10 range of z-order.</span></span> <span data-ttu-id="7e541-169">この唯一の例外として、Skype アプリの着信通知などの割り込みオーバーレイがあります。</span><span class="sxs-lookup"><span data-stu-id="7e541-169">The sole exception is an interrupt overlay, such as an inbound call notification for a Skype app.</span></span>

<span id="bkmk-ui"/>
## <a name="do-not-use-borders"></a><span data-ttu-id="7e541-170">境界線を使わない</span><span class="sxs-lookup"><span data-stu-id="7e541-170">Do not use borders</span></span>

<span data-ttu-id="7e541-171">**AdControl** によってその親クラスから継承される境界線に関連するプロパティを設定すると、広告の配置に関して問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="7e541-171">Setting border-related properties inherited by the **AdControl** from its parent class will cause the ad placement to be wrong.</span></span>

## <a name="more-information"></a><span data-ttu-id="7e541-172">詳細情報</span><span class="sxs-lookup"><span data-stu-id="7e541-172">More Information</span></span>


<span data-ttu-id="7e541-173">最新の既知の問題についての詳細を調べたり、Microsoft Advertising ライブラリに関連する質問を投稿したりするには、[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)をご利用ください。</span><span class="sxs-lookup"><span data-stu-id="7e541-173">For more information about the latest known issues and to post questions related to the Microsoft advertising libraries, visit the [forum](http://go.microsoft.com/fwlink/p/?LinkId=401266).</span></span>

## <a name="support"></a><span data-ttu-id="7e541-174">サポート</span><span class="sxs-lookup"><span data-stu-id="7e541-174">Support</span></span>


<span data-ttu-id="7e541-175">Microsoft Advertising ライブラリに関する問題について製品サポートに問い合わせる場合は、[サポート ページ](https://go.microsoft.com/fwlink/p/?LinkId=331508)にアクセスし、**[In-App 広告]** を選択してください。</span><span class="sxs-lookup"><span data-stu-id="7e541-175">To contact product support for issues with the Microsoft advertising libraries, visit the [support page](https://go.microsoft.com/fwlink/p/?LinkId=331508) and choose **In-App Advertising**.</span></span>

 

 
