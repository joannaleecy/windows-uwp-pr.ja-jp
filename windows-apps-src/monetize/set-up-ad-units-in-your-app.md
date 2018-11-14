---
author: Xansky
ms.assetid: bb105fbe-bbbd-4d78-899b-345af2757720
description: アプリをストアに提出する前に、パートナー センターからアプリケーション ID と広告ユニット ID の値をアプリを追加する方法について説明します。
title: アプリの広告ユニットをセットアップする
ms.author: mhopkins
ms.date: 05/11/2018
ms.topic: article
keywords: Windows 10, UWP, 広告, Advertising, 広告ユニット, テスト
ms.localizationpriority: medium
ms.openlocfilehash: 11c66756d95e041a45fbc075b02eb744bf542871
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6191084"
---
# <a name="set-up-ad-units-in-your-app"></a><span data-ttu-id="b9abf-104">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="b9abf-104">Set up ad units in your app</span></span>

<span data-ttu-id="b9abf-105">ユニバーサル Windows プラットフォーム (UWP) アプリ内の各広告コントロールには、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-105">Every ad control in your Universal Windows Platform (UWP) app has a corresponding *ad unit* that is used by our services to serve ads to the control.</span></span> <span data-ttu-id="b9abf-106">各広告ユニットは、*広告ユニット ID* と*アプリケーション ID* があり、これらをアプリ内でコードに割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="b9abf-106">Each ad unit consists of an *ad unit ID* and *application ID* that you must assign to code in your app.</span></span>

<span data-ttu-id="b9abf-107">テスト中にテスト広告がアプリに表示されていることを確認するために使用できる[テスト広告ユニット値](#test-ad-units)が用意されています。</span><span class="sxs-lookup"><span data-stu-id="b9abf-107">We provide [test ad unit values](#test-ad-units) that you can use during testing to confirm that your app shows test ads.</span></span> <span data-ttu-id="b9abf-108">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-108">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="b9abf-109">いったん公開したアプリでテスト用の値を使うと、ライブ アプリで広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="b9abf-109">If you try to use test values in your app after you publish it, your live app not receive ads.</span></span>

<span data-ttu-id="b9abf-110">UWP アプリのテストが完了し、パートナー センターに提出する準備ができたらは、パートナー センターで[アプリ内広告](../publish/in-app-ads.md)ページからの[ライブ広告ユニットを作成](#live-ad-units)する必要があります。 し、この広告ユニットのアプリケーション ID と広告ユニット ID の値を使用するアプリのコードを更新します。</span><span class="sxs-lookup"><span data-stu-id="b9abf-110">After you finish testing your UWP app and you are ready to submit it to Partner Center, you must [create a live ad unit](#live-ad-units) from the [In-app ads](../publish/in-app-ads.md) page in Partner Center and update your app code to use the application ID and ad unit ID values for this ad unit.</span></span>

<span data-ttu-id="b9abf-111">アプリケーション ID と広告ユニット ID の値をアプリのコードに割り当てる方法の詳細については、次の記事を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b9abf-111">For more information about assigning the application ID and ad unit ID values in your app's code, see the following articles:</span></span>
* [<span data-ttu-id="b9abf-112">XAML および .NET の AdControl</span><span class="sxs-lookup"><span data-stu-id="b9abf-112">AdControl in XAML and .NET</span></span>](adcontrol-in-xaml-and--net.md)
* [<span data-ttu-id="b9abf-113">HTML 5 および Javascript の AdControl</span><span class="sxs-lookup"><span data-stu-id="b9abf-113">AdControl in HTML 5 and Javascript</span></span>](adcontrol-in-html-5-and-javascript.md)
* [<span data-ttu-id="b9abf-114">スポット広告</span><span class="sxs-lookup"><span data-stu-id="b9abf-114">Interstitial ads</span></span>](../monetize/interstitial-ads.md)
* [<span data-ttu-id="b9abf-115">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="b9abf-115">Native ads</span></span>](../monetize/native-ads.md)

<span id="test-ad-units" />

## <a name="test-ad-units"></a><span data-ttu-id="b9abf-116">広告ユニットをテストする</span><span class="sxs-lookup"><span data-stu-id="b9abf-116">Test ad units</span></span>

<span data-ttu-id="b9abf-117">アプリを開発しているときには、このセクションに示されているテスト用のアプリケーション ID と広告ユニット ID の値を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。</span><span class="sxs-lookup"><span data-stu-id="b9abf-117">While you are developing your app, use the test application ID and ad unit ID values from this section to see how your app renders ads during testing.</span></span>

### <a name="banner-ads-using-the-adcontrol-class"></a><span data-ttu-id="b9abf-118">バナー広告 (AdControl クラスを使用)</span><span class="sxs-lookup"><span data-stu-id="b9abf-118">Banner ads (using the AdControl class)</span></span>

* <span data-ttu-id="b9abf-119">広告ユニット ID:</span><span class="sxs-lookup"><span data-stu-id="b9abf-119">Ad unit ID:</span></span> ```test```
* <span data-ttu-id="b9abf-120">アプリケーション ID:</span><span class="sxs-lookup"><span data-stu-id="b9abf-120">Application ID:</span></span>  ```3f83fe91-d6be-434d-a0ae-7351c5a997f1```

    > [!IMPORTANT]
    > <span data-ttu-id="b9abf-121">**AdControl** では、ライブ広告のサイズは **Width** プロパティと **Height** プロパティによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-121">For an **AdControl**, the size of a live ad is defined by the **Width** and **Height** properties.</span></span> <span data-ttu-id="b9abf-122">最善の結果を得るには、コード内の **Width** プロパティと **Height** プロパティが、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b9abf-122">For best results, make sure that the **Width** and **Height** properties in your code are one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span> <span data-ttu-id="b9abf-123">**Width** プロパティと **Height** プロパティは、ライブ広告のサイズに基づいて変更されません。</span><span class="sxs-lookup"><span data-stu-id="b9abf-123">The **Width** and **Height** properties will not change based on the size of a live ad.</span></span>

### <a name="interstitial-ads-and-native-ads"></a><span data-ttu-id="b9abf-124">スポット広告やネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="b9abf-124">Interstitial ads and native ads</span></span>

* <span data-ttu-id="b9abf-125">広告ユニット ID:</span><span class="sxs-lookup"><span data-stu-id="b9abf-125">Ad unit ID:</span></span> ```test```
* <span data-ttu-id="b9abf-126">アプリケーション ID:</span><span class="sxs-lookup"><span data-stu-id="b9abf-126">Application ID:</span></span>  ```d25517cb-12d4-4699-8bdc-52040c712cab```

<span id="live-ad-units" />

## <a name="live-ad-units"></a><span data-ttu-id="b9abf-127">ライブ広告ユニット</span><span class="sxs-lookup"><span data-stu-id="b9abf-127">Live ad units</span></span>

<span data-ttu-id="b9abf-128">パートナー センターからライブ広告ユニットを取得し、アプリで使用します。</span><span class="sxs-lookup"><span data-stu-id="b9abf-128">To get a live ad unit from Partner Center and use it in your app:</span></span>

1.  <span data-ttu-id="b9abf-129">パートナー センターで**アプリ内広告**] ページでの[広告ユニットを作成](../publish/in-app-ads.md#create-ad-unit)します。</span><span class="sxs-lookup"><span data-stu-id="b9abf-129">[Create an ad unit](../publish/in-app-ads.md#create-ad-unit) on the **In-app ads** page in Partner Center.</span></span> <span data-ttu-id="b9abf-130">アプリで使用している広告コントロールに合わせて、適切な種類の広告ユニットを指定してください。</span><span class="sxs-lookup"><span data-stu-id="b9abf-130">Be sure to specify the correct type of ad unit for the ad control you are using in your app.</span></span>
    > [!NOTE]
    > <span data-ttu-id="b9abf-131">必要に応じて、[[仲介設定]](../publish/in-app-ads.md#mediation) セクションで設定を構成することで、広告ユニットの広告仲介を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-131">You can optionally enable ad mediation for your ad unit by configuring the settings in the [Mediation settings](../publish/in-app-ads.md#mediation) section.</span></span> <span data-ttu-id="b9abf-132">広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-132">Ad mediation enables you to maximize your ad revenue and app promotion capabilities by displaying ads from multiple ad networks, including ads from other paid ad networks and ads for Microsoft app promotion campaigns.</span></span> <span data-ttu-id="b9abf-133">既定では、アプリがサポートする市場全体で広告の収益を最大化できるように、機械学習アルゴリズムを使った仲介設定が自動的に構成されますが、必要に応じて仲介設定を手動で構成することができます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-133">By default, we automatically choose the ad mediation settings for your app using machine-learning algorithms to help you maximize your ad revenue across the markets your app supports, but you can optionally manually configure your mediation settings.</span></span>

2.  <span data-ttu-id="b9abf-134">新しい広告ユニットを作成したら、**[収益化]** &gt; **[アプリ内広告]** ページにある利用可能な広告ユニットの表で、作成した広告ユニットの**アプリケーション ID** と**広告ユニット ID** を取得します。</span><span class="sxs-lookup"><span data-stu-id="b9abf-134">After you create the new ad unit, retrieve the **Application ID** and **Ad unit ID** for the ad unit in the table of available ad units in the **Monetize** &gt; **In-app ads** page.</span></span>
    > [!NOTE]
    > <span data-ttu-id="b9abf-135">テスト広告ユニットとライブ UWP 広告ユニットでは、アプリケーション ID の値の形式が異なります。</span><span class="sxs-lookup"><span data-stu-id="b9abf-135">The application ID values for test ad units and live UWP ad units have different formats.</span></span> <span data-ttu-id="b9abf-136">テスト アプリケーション ID の値は GUID です。</span><span class="sxs-lookup"><span data-stu-id="b9abf-136">Test application ID values are GUIDs.</span></span> <span data-ttu-id="b9abf-137">パートナー センターでライブ UWP 広告ユニットを作成するとき、広告ユニットのアプリケーション ID の値は (ストア ID の値は、たとえばは 9NBLGGH4R315 のようになります)、アプリのストア ID を常に一致します。</span><span class="sxs-lookup"><span data-stu-id="b9abf-137">When you create a live UWP ad unit in Partner Center, the application ID value for the ad unit always matches the Store ID for your app (an example Store ID value looks like 9NBLGGH4R315).</span></span>

3.  <span data-ttu-id="b9abf-138">アプリのコードで、アプリケーション ID と広告ユニット ID の値を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-138">Assign the application ID and ad unit ID values in your app's code.</span></span> <span data-ttu-id="b9abf-139">詳細については、次の記事を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b9abf-139">For more information, see the following articles:</span></span>
    * [<span data-ttu-id="b9abf-140">XAML および .NET の AdControl</span><span class="sxs-lookup"><span data-stu-id="b9abf-140">AdControl in XAML and .NET</span></span>](adcontrol-in-xaml-and--net.md)
    * [<span data-ttu-id="b9abf-141">HTML 5 および Javascript の AdControl</span><span class="sxs-lookup"><span data-stu-id="b9abf-141">AdControl in HTML 5 and Javascript</span></span>](adcontrol-in-html-5-and-javascript.md)
    * [<span data-ttu-id="b9abf-142">スポット広告</span><span class="sxs-lookup"><span data-stu-id="b9abf-142">Interstitial ads</span></span>](../monetize/interstitial-ads.md)
    * [<span data-ttu-id="b9abf-143">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="b9abf-143">Native ads</span></span>](../monetize/native-ads.md)

<span id="manage" />

## <a name="manage-ad-units-for-multiple-ad-controls-in-your-app"></a><span data-ttu-id="b9abf-144">アプリで複数の広告コントロールの広告ユニットを管理する</span><span class="sxs-lookup"><span data-stu-id="b9abf-144">Manage ad units for multiple ad controls in your app</span></span>

<span data-ttu-id="b9abf-145">1 つのアプリに複数のバナー広告コントロール、スポット広告コントロール、ネイティブ広告コントロールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-145">You can use multiple banner, interstitial, and native ad controls in a single app.</span></span> <span data-ttu-id="b9abf-146">このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b9abf-146">In this scenario, we recommend that you assign a different ad unit to each control.</span></span> <span data-ttu-id="b9abf-147">各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/in-app-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="b9abf-147">Using different ad units for each control enables you to separately [configure the mediation settings](../publish/in-app-ads.md#mediation) and get discrete [reporting data](../publish/advertising-performance-report.md) for each control.</span></span> <span data-ttu-id="b9abf-148">また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-148">This also enables our services to better optimize the ads we serve to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b9abf-149">各広告ユニットは 1 つのアプリのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="b9abf-149">You can use each ad unit in only one app.</span></span> <span data-ttu-id="b9abf-150">複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。</span><span class="sxs-lookup"><span data-stu-id="b9abf-150">If you use an ad unit in more than one app, ads will not be served for that ad unit.</span></span>

## <a name="related-topics"></a><span data-ttu-id="b9abf-151">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b9abf-151">Related topics</span></span>

* [<span data-ttu-id="b9abf-152">XAML および .NET の AdControl</span><span class="sxs-lookup"><span data-stu-id="b9abf-152">AdControl in XAML and .NET</span></span>](adcontrol-in-xaml-and--net.md)
* [<span data-ttu-id="b9abf-153">HTML 5 および Javascript の AdControl</span><span class="sxs-lookup"><span data-stu-id="b9abf-153">AdControl in HTML 5 and Javascript</span></span>](adcontrol-in-html-5-and-javascript.md)
* [<span data-ttu-id="b9abf-154">スポット広告</span><span class="sxs-lookup"><span data-stu-id="b9abf-154">Interstitial ads</span></span>](interstitial-ads.md)
* [<span data-ttu-id="b9abf-155">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="b9abf-155">Native ads</span></span>](native-ads.md)


 

 
