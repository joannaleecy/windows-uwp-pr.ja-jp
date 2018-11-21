---
author: Xansky
ms.assetid: 9ca1f880-2ced-46b4-8ea7-aba43d2ff863
description: Microsoft Advertising SDK の現在のリリースにおける既知の問題について説明します。
title: アプリ内広告の既知の問題とトラブルシューティング
ms.author: mhopkins
ms.date: 04/16/2018
ms.topic: article
keywords: Windows 10, UWP, 広告, Advertising, 既知の問題, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: d1b3b1fb68ed246d6a5a8334c5cf4d1c0754b719
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7427461"
---
# <a name="known-issues-and-troubleshooting-for-ads-in-apps"></a><span data-ttu-id="bc3a3-104">アプリ内広告の既知の問題とトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="bc3a3-104">Known issues and troubleshooting for ads in apps</span></span>

<span data-ttu-id="bc3a3-105">このトピックでは、Microsoft Advertising SDK の現在のリリースにおける既知の問題を示します。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-105">This topic lists the known issues with the current release of the Microsoft Advertising SDK.</span></span> <span data-ttu-id="bc3a3-106">トラブルシューティングのガイダンスについては、以下のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-106">For additional troubleshooting guidance, see the following topics.</span></span>

* [<span data-ttu-id="bc3a3-107">HTML と JavaScript のトラブルシューティング ガイド</span><span class="sxs-lookup"><span data-stu-id="bc3a3-107">HTML and JavaScript troubleshooting guide</span></span>](html-and-javascript-troubleshooting-guide.md)
* [<span data-ttu-id="bc3a3-108">XAML と C# のトラブルシューティング ガイド</span><span class="sxs-lookup"><span data-stu-id="bc3a3-108">XAML and C# troubleshooting guide</span></span>](xaml-and-c-troubleshooting-guide.md)

## <a name="adcontrol-interface-unknown-in-xaml"></a><span data-ttu-id="bc3a3-109">XAML での不明な AdControl インターフェイス</span><span class="sxs-lookup"><span data-stu-id="bc3a3-109">AdControl interface unknown in XAML</span></span>

<span data-ttu-id="bc3a3-110">[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) の XAML マークアップに、そのインターフェイスが不明であることを示す青い破線が表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-110">The XAML markup for an [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) may incorrectly show a blue curvy line implying that the interface is unknown.</span></span> <span data-ttu-id="bc3a3-111">これは、x86 をターゲットとして設定している場合にのみ発生するもので、無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-111">This occurs only when targeting x86, and it may be ignored.</span></span>

## <a name="lasterror-from-previous-ad-request"></a><span data-ttu-id="bc3a3-112">以前の広告要求からの lastError</span><span class="sxs-lookup"><span data-stu-id="bc3a3-112">lastError from previous ad request</span></span>

<span data-ttu-id="bc3a3-113">以前の広告要求の **lastError** が残っている場合、次の広告呼び出し中にこのイベントが 2 回を発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-113">If there is a leftover **lastError** from the previous ad request, the event may be fired twice during the next ad call.</span></span> <span data-ttu-id="bc3a3-114">その一方で新しい広告要求が行われ、有効な広告が生成されると、この動作によって混乱が生じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-114">While the new ad request will still be made and may yield a valid ad, this behavior may cause confusion.</span></span>

## <a name="interstitial-ads-and-navigation-buttons-on-phones"></a><span data-ttu-id="bc3a3-115">スポット広告と電話のナビゲーション ボタン</span><span class="sxs-lookup"><span data-stu-id="bc3a3-115">Interstitial ads and navigation buttons on phones</span></span>

<span data-ttu-id="bc3a3-116">ハードウェア ボタンの代わりにソフトウェア ボタンの **"戻る"**、**"スタート"**、**"検索"** を備えた電話 (またはエミュレーター) では、スポット広告用のカウントダウン タイマー ボタンとクリックスルー ボタンが隠れる場合があります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-116">On phones (or emulators) that have software **Back**, **Start**, and **Search** buttons instead of hardware buttons, the countdown timer and click through buttons for interstitial ads may be obscured.</span></span>

## <a name="recently-created-ads-are-not-being-served-to-your-app"></a><span data-ttu-id="bc3a3-117">最近作成した広告がアプリに提供されない</span><span class="sxs-lookup"><span data-stu-id="bc3a3-117">Recently created ads are not being served to your app</span></span>

<span data-ttu-id="bc3a3-118">その広告が最近 (1 日以内) 作成された広告の場合は、すぐに利用可能にならない場合があります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-118">If you have created an ad recently (less than a day), it might not be available immediately.</span></span> <span data-ttu-id="bc3a3-119">編集コンテンツに関する承認が済んでいる場合、広告は、広告サーバーによって処理され、インベントリとして利用可能になった時点で提供されるようになります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-119">If the ad has been approved for editorial content, it will be served once the advertising server has processed it and the ad is available as inventory.</span></span>

## <a name="no-ads-are-shown-in-your-app"></a><span data-ttu-id="bc3a3-120">アプリに広告が表示されない</span><span class="sxs-lookup"><span data-stu-id="bc3a3-120">No ads are shown in your app</span></span>

<span data-ttu-id="bc3a3-121">広告が表示されない場合、ネットワーク エラーを含むさまざまな理由があります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-121">There are many reasons you may see no ads, including network errors.</span></span> <span data-ttu-id="bc3a3-122">次の理由も考えられます。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-122">Other reasons might include:</span></span>

* <span data-ttu-id="bc3a3-123">パートナー センターで大きいまたはアプリのコードで**AdControl**のサイズより小さいサイズの広告ユニットを選択します。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-123">Selecting an ad unit in Partner Center with a size that is greater or less than the size of the **AdControl** in your app's code.</span></span>

* <span data-ttu-id="bc3a3-124">広告ユニット ID に[テスト モードの値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってライブ アプリを実行した場合、広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-124">Ads will not appear if you're using a [test mode value](set-up-ad-units-in-your-app.md#test-ad-units) for your ad unit ID when running a live app.</span></span>

* <span data-ttu-id="bc3a3-125">新しい広告ユニット ID の作成を行ったのがこの 30 分以内の場合、サーバーによってシステムに新しいデータが伝達されるまで、広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-125">If you created a new ad unit ID in the past half-hour, you might not see an ad until the servers propagate new data through the system.</span></span> <span data-ttu-id="bc3a3-126">広告が表示されていた既存の ID を使用すると、広告はすぐに表示されます。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-126">Existing IDs that have shown ads before should show ads immediately.</span></span>

<span data-ttu-id="bc3a3-127">アプリにテスト広告が表示される場合は、コードが正常に動作していて広告を表示できることを示します。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-127">If you can see test ads in the app, your code is working and is able to display ads.</span></span> <span data-ttu-id="bc3a3-128">問題が発生した場合は、[製品サポート](https://developer.microsoft.com/en-us/windows/support)にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-128">If you encounter issues, contact [product support](https://developer.microsoft.com/en-us/windows/support).</span></span> <span data-ttu-id="bc3a3-129">このページで、**[アプリ内広告]** を選択してください。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-129">On that page, choose **Ads-In-Apps**.</span></span>

<span data-ttu-id="bc3a3-130">[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)に質問を投稿することもできます。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-130">You can also post a question in the [forum](http://go.microsoft.com/fwlink/p/?LinkId=401266).</span></span>

## <a name="test-ads-are-showing-in-your-app-instead-of-live-ads"></a><span data-ttu-id="bc3a3-131">ライブ広告ではなくテスト広告がアプリに表示される</span><span class="sxs-lookup"><span data-stu-id="bc3a3-131">Test ads are showing in your app instead of live ads</span></span>

<span data-ttu-id="bc3a3-132">ライブ広告が想定されているときでもテスト広告が表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-132">Test ads can be shown, even when you are expecting live ads.</span></span> <span data-ttu-id="bc3a3-133">これは、次の状況で発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-133">This can happen in the following scenarios:</span></span>

* <span data-ttu-id="bc3a3-134">ストアで使用されているライブ アプリケーション ID を広告プラットフォームが確認または検出できない。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-134">Our advertising platform cannot verify or find the live application ID used in the Store.</span></span> <span data-ttu-id="bc3a3-135">この場合、広告ユニットがユーザーによって作成されたとき、その状態は "ライブ" (非テスト) として開始されますが、最初の広告要求が行われてから 6 時間以内にテスト状態に移行します。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-135">In this case, when an ad unit is created by a user, its status can start as live (non-test) but will move to test status within 6 hours after the first ad request.</span></span> <span data-ttu-id="bc3a3-136">その状態は、10 日間テスト アプリからの要求がない場合に "ライブ" に戻ります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-136">It will change back to live if there are no requests from test apps for 10 days.</span></span>

* <span data-ttu-id="bc3a3-137">サイドローディングされたアプリやエミュレーターで実行されているアプリには、ライブ広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-137">Side-loaded apps or apps that are running in the emulator will not show live ads.</span></span>

<span data-ttu-id="bc3a3-138">ライブ広告ユニットがテスト広告を提供すると、広告ユニットの状態はパートナー センターで**アクティブなサービスのテストの広告**表示されます。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-138">When a live ad unit is serving test ads, the ad unit’s status shows **Active and serving test ads** in Partner Center.</span></span> <span data-ttu-id="bc3a3-139">現時点で、これは、電話アプリには適用されません。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-139">This does not currently apply to phone apps.</span></span>


<span id="reference_errors"/>

## <a name="reference-errors-caused-by-targeting-any-cpu-in-your-project"></a><span data-ttu-id="bc3a3-140">プロジェクトのターゲットを "任意の CPU" に設定すると参照エラーが発生する</span><span class="sxs-lookup"><span data-stu-id="bc3a3-140">Reference errors caused by targeting Any CPU in your project</span></span>

<span data-ttu-id="bc3a3-141">Microsoft Advertising SDK を使う場合、プロジェクトで**任意の CPU** をターゲットにすることはできません。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-141">When using the Microsoft Advertising SDK, you cannot target **Any CPU** in your project.</span></span> <span data-ttu-id="bc3a3-142">プロジェクトのターゲットを**任意の CPU** プラットフォームに設定した場合、次のような参照を追加した後で警告が表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-142">If your project targets the **Any CPU** platform, you may see a warning after adding the reference similar to this one.</span></span>

![referenceerror\-solutionexplorer](images/13-19629921-023c-42ec-b8f5-bc0b63d5a191.jpg)

<span data-ttu-id="bc3a3-144">この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-144">To remove this warning, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="bc3a3-145">デバッグおよびリリース用の構成のプラットフォームのターゲットを設定するには、**Configuration Manager** を使用します。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-145">Use **Configuration Manager** to set the platform targets for debug and release configurations.</span></span>

![configurationmanagerwin10](images/13-87074274-c10d-4dbd-9a06-453b7184f8de.png)

<span data-ttu-id="bc3a3-147">(次の図に示すように) ストアに申請するアプリ パッケージを作成するときは、ターゲットのアーキテクチャを必ず指定してください。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-147">When you create your app packages for store submission (as shown in the following images), be sure to include the architectures you intend to target.</span></span> <span data-ttu-id="bc3a3-148">x64 OS で x86 ビルドを実行する場合は、x64 をスキップしてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-148">You may opt to skip x64 if you intend to run x86 builds on the x64 OS.</span></span>

![projectstorecreateapppackages](images/13-a99b05a4-8917-4c53-822e-2548fadf828a.png)

![createapppackages](images/13-16280cb1-a838-42b9-9256-eac7f33f5603.png)

## <a name="z-order-in-javascripthtml-apps"></a><span data-ttu-id="bc3a3-151">JavaScript/HTML アプリでの Z オーダー</span><span class="sxs-lookup"><span data-stu-id="bc3a3-151">Z-order in JavaScript/HTML apps</span></span>

<span data-ttu-id="bc3a3-152">JavaScript/HTML アプリでは、z オーダーの予約済みの MAX-10 の範囲に要素を配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-152">JavaScript/HTML apps must not place elements into the reserved MAX-10 range of z-order.</span></span> <span data-ttu-id="bc3a3-153">この唯一の例外として、Skype アプリの着信通知などの割り込みオーバーレイがあります。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-153">The sole exception is an interrupt overlay, such as an inbound call notification for a Skype app.</span></span>

<span id="bkmk-ui"/>

## <a name="do-not-use-borders"></a><span data-ttu-id="bc3a3-154">境界線を使わない</span><span class="sxs-lookup"><span data-stu-id="bc3a3-154">Do not use borders</span></span>

<span data-ttu-id="bc3a3-155">**AdControl** によってその親クラスから継承される境界線に関連するプロパティを設定すると、広告の配置に関して問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-155">Setting border-related properties inherited by the **AdControl** from its parent class will cause the ad placement to be wrong.</span></span>

## <a name="more-information"></a><span data-ttu-id="bc3a3-156">詳細情報</span><span class="sxs-lookup"><span data-stu-id="bc3a3-156">More Information</span></span>

<span data-ttu-id="bc3a3-157">最新の既知の問題についての詳細を調べたり、Microsoft Advertising SDK に関連する質問を投稿したりするには、[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)をご利用ください。</span><span class="sxs-lookup"><span data-stu-id="bc3a3-157">For more information about the latest known issues and to post questions related to the Microsoft Advertising SDK, visit the [forum](http://go.microsoft.com/fwlink/p/?LinkId=401266).</span></span>

 

 
