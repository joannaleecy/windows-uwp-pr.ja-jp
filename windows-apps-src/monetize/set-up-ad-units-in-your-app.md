---
author: mcleanbyron
ms.assetid: bb105fbe-bbbd-4d78-899b-345af2757720
description: アプリをストアに提出する前に、Windows デベロッパー センター ダッシュ ボードからアプリケーション ID と広告ユニット ID の値をアプリに追加する方法について説明します。
title: アプリの広告ユニットをセットアップする
ms.author: mcleans
ms.date: 10/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, Advertising, 広告ユニット, テスト
ms.localizationpriority: medium
ms.openlocfilehash: 6473d571ed44f60f8001b8a565d70c58d43407d1
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1654661"
---
# <a name="set-up-ad-units-in-your-app"></a><span data-ttu-id="178fd-104">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="178fd-104">Set up ad units in your app</span></span>

<span data-ttu-id="178fd-105">ユニバーサル Windows プラットフォーム (UWP) アプリ内の各広告コントロールには、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。</span><span class="sxs-lookup"><span data-stu-id="178fd-105">Every ad control in your Universal Windows Platform (UWP) app has a corresponding *ad unit* that is used by our services to serve ads to the control.</span></span> <span data-ttu-id="178fd-106">各広告ユニットは、*広告ユニット ID* と*アプリケーション ID* があり、これらをアプリ内で [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx)、[InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx)、[NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) に割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="178fd-106">Each ad unit consists of an *ad unit ID* and *application ID* that you must assign to the [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx),  [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx), or [NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) in your app.</span></span>

<span data-ttu-id="178fd-107">テスト中にテスト広告がアプリに表示されていることを確認するために使用できる[テスト広告ユニット値](#test-ad-units)が用意されています。</span><span class="sxs-lookup"><span data-stu-id="178fd-107">We provide [test ad unit values](#test-ad-units) that you can use during testing to confirm that your app shows test ads.</span></span> <span data-ttu-id="178fd-108">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="178fd-108">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="178fd-109">いったん公開したアプリでテスト用の値を使うと、ライブ アプリで広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="178fd-109">If you try to use test values in your app after you publish it, your live app not receive ads.</span></span>

<span data-ttu-id="178fd-110">UWP アプリのテストが終了し、Windows デベロッパー センターに提出する準備ができたら、Windows デベロッパー センター ダッシュボードの [[アプリ内広告]](../publish/in-app-ads.md) ページから[ライブ広告ユニットを作成](#live-ad-units)し、この広告ユニットのアプリケーション ID と広告ユニット ID の値を使うようにアプリ コードを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="178fd-110">After you finish testing your UWP app and you are ready to submit it to Windows Dev Center, you must [create a live ad unit](#live-ad-units) from the [In-app ads](../publish/in-app-ads.md) page in the Windows Dev Center dashboard and update your app code to use the application ID and ad unit ID values for this ad unit.</span></span>

<span id="test-ad-units" />

## <a name="test-ad-units"></a><span data-ttu-id="178fd-111">広告ユニットをテストする</span><span class="sxs-lookup"><span data-stu-id="178fd-111">Test ad units</span></span>

<span data-ttu-id="178fd-112">アプリを開発しているときには、このセクションに示されているテスト用のアプリケーション ID と広告ユニット ID の値を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。</span><span class="sxs-lookup"><span data-stu-id="178fd-112">While you are developing your app, use the test application ID and ad unit ID values from this section to see how your app renders ads during testing.</span></span>

### <a name="banner-ads-using-the-adcontrol-class"></a><span data-ttu-id="178fd-113">バナー広告 (AdControl クラスを使用)</span><span class="sxs-lookup"><span data-stu-id="178fd-113">Banner ads (using the AdControl class)</span></span>

* <span data-ttu-id="178fd-114">広告ユニット ID:</span><span class="sxs-lookup"><span data-stu-id="178fd-114">Ad unit ID:</span></span> ```test```
* <span data-ttu-id="178fd-115">アプリケーション ID:</span><span class="sxs-lookup"><span data-stu-id="178fd-115">Application ID:</span></span>  ```3f83fe91-d6be-434d-a0ae-7351c5a997f1```

    > [!IMPORTANT]
    > <span data-ttu-id="178fd-116">**AdControl** では、ライブ広告のサイズは **Width** プロパティと **Height** プロパティによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="178fd-116">For an **AdControl**, the size of a live ad is defined by the **Width** and **Height** properties.</span></span> <span data-ttu-id="178fd-117">最善の結果を得るには、コード内の **Width** プロパティと **Height** プロパティが、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="178fd-117">For best results, make sure that the **Width** and **Height** properties in your code are one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span> <span data-ttu-id="178fd-118">**Width** プロパティと **Height** プロパティは、ライブ広告のサイズに基づいて変更されません。</span><span class="sxs-lookup"><span data-stu-id="178fd-118">The **Width** and **Height** properties will not change based on the size of a live ad.</span></span>

### <a name="interstitial-ads-and-native-ads"></a><span data-ttu-id="178fd-119">スポット広告やネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="178fd-119">Interstitial ads and native ads</span></span>

* <span data-ttu-id="178fd-120">広告ユニット ID:</span><span class="sxs-lookup"><span data-stu-id="178fd-120">Ad unit ID:</span></span> ```test```
* <span data-ttu-id="178fd-121">アプリケーション ID:</span><span class="sxs-lookup"><span data-stu-id="178fd-121">Application ID:</span></span>  ```d25517cb-12d4-4699-8bdc-52040c712cab```

<span id="live-ad-units" />

## <a name="live-ad-units"></a><span data-ttu-id="178fd-122">ライブ広告ユニット</span><span class="sxs-lookup"><span data-stu-id="178fd-122">Live ad units</span></span>

<span data-ttu-id="178fd-123">デベロッパー センター ダッシュボードからライブ広告ユニットを取得し、アプリで使用するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="178fd-123">To get a live ad unit from the Dev Center dashboard and use it in your app:</span></span>

1.  <span data-ttu-id="178fd-124">ダッシュボードの **[アプリ内広告]** ページで、[広告ユニットを作成](../publish/in-app-ads.md#create-ad-unit)します。</span><span class="sxs-lookup"><span data-stu-id="178fd-124">[Create an ad unit](../publish/in-app-ads.md#create-ad-unit) on the **In-app ads** page in the dashboard.</span></span> <span data-ttu-id="178fd-125">アプリで使用している広告コントロールに合わせて、適切な種類の広告ユニットを指定してください。</span><span class="sxs-lookup"><span data-stu-id="178fd-125">Be sure to specify the correct type of ad unit for the ad control you are using in your app.</span></span>
    > [!NOTE]
    > <span data-ttu-id="178fd-126">必要に応じて、[[仲介設定]](../publish/in-app-ads.md#mediation) セクションで設定を構成することで、広告ユニットの広告仲介を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="178fd-126">You can optionally enable ad mediation for your ad unit by configuring the settings in the [Mediation settings](../publish/in-app-ads.md#mediation) section.</span></span> <span data-ttu-id="178fd-127">広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="178fd-127">Ad mediation enables you to maximize your ad revenue and app promotion capabilities by displaying ads from multiple ad networks, including ads from other paid ad networks and ads for Microsoft app promotion campaigns.</span></span> <span data-ttu-id="178fd-128">既定では、アプリがサポートする市場全体で広告の収益を最大化できるように、機械学習アルゴリズムを使った仲介設定が自動的に構成されますが、必要に応じて仲介設定を手動で構成することができます。</span><span class="sxs-lookup"><span data-stu-id="178fd-128">By default, we automatically choose the ad mediation settings for your app using machine-learning algorithms to help you maximize your ad revenue across the markets your app supports, but you can optionally manually configure your mediation settings.</span></span>

2.  <span data-ttu-id="178fd-129">新しい広告ユニットを作成したら、**[収益化]** &gt; **[アプリ内広告]** ページにある利用可能な広告ユニットの表で、作成した広告ユニットの**アプリケーション ID** と**広告ユニット ID** を取得します。</span><span class="sxs-lookup"><span data-stu-id="178fd-129">After you create the new ad unit, retrieve the **Application ID** and **Ad unit ID** for the ad unit in the table of available ad units in the **Monetize** &gt; **In-app ads** page.</span></span>
    > [!NOTE]
    > <span data-ttu-id="178fd-130">テスト広告ユニットとライブ UWP 広告ユニットでは、アプリケーション ID の値の形式が異なります。</span><span class="sxs-lookup"><span data-stu-id="178fd-130">The application ID values for test ad units and live UWP ad units have different formats.</span></span> <span data-ttu-id="178fd-131">テスト アプリケーション ID の値は GUID です。</span><span class="sxs-lookup"><span data-stu-id="178fd-131">Test application ID values are GUIDs.</span></span> <span data-ttu-id="178fd-132">ダッシュボードでライブ UWP 広告ユニットを作成する場合、広告ユニットのアプリケーション ID の値は常にアプリの Store ID に一致します (Store ID 値は、たとえば 9NBLGGH4R315 のようになります)。</span><span class="sxs-lookup"><span data-stu-id="178fd-132">When you create a live UWP ad unit in the dashboard, the application ID value for the ad unit always matches the Store ID for your app (an example Store ID value looks like 9NBLGGH4R315).</span></span>

3.  <span data-ttu-id="178fd-133">アプリのコードで、**アプリケーション ID** と**広告ユニット ID** の値を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="178fd-133">Assign the **Application ID** and **Ad unit ID** values in your app's code:</span></span>

    * <span data-ttu-id="178fd-134">アプリにバナー広告を表示する場合は、これらの値を [AdControl](https://msdn.microsoft.com/library/mt313154.aspx) オブジェクトの [ApplicationId](https://msdn.microsoft.com/library/mt313174.aspx) プロパティと [AdUnitId](https://msdn.microsoft.com/library/mt313171.aspx) プロパティに割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="178fd-134">If your app shows banner ads, assign these values to the [ApplicationId](https://msdn.microsoft.com/library/mt313174.aspx) and [AdUnitId](https://msdn.microsoft.com/library/mt313171.aspx) properties of your [AdControl](https://msdn.microsoft.com/library/mt313154.aspx) object.</span></span> <span data-ttu-id="178fd-135">詳しくは、「[XAML および .NET の AdControl](../monetize/adcontrol-in-xaml-and--net.md)」、または「[HTML5 および JavaScript の AdControl](../monetize/adcontrol-in-html-5-and-javascript.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="178fd-135">For more information, see [AdControl in XAML and .NET](../monetize/adcontrol-in-xaml-and--net.md) and [AdControl in HTML5 and JavaScript](../monetize/adcontrol-in-html-5-and-javascript.md).</span></span>

    * <span data-ttu-id="178fd-136">アプリでスポット広告を表示する場合は、[InterstitialAd](https://msdn.microsoft.com/library/mt313189.aspx) オブジェクトの [RequestAd](https://msdn.microsoft.com/library/mt313192.aspx) メソッドにこれらの値を渡します。</span><span class="sxs-lookup"><span data-stu-id="178fd-136">If your app shows interstitial ads, pass these values to the [RequestAd](https://msdn.microsoft.com/library/mt313192.aspx) method of your [InterstitialAd](https://msdn.microsoft.com/library/mt313189.aspx) object.</span></span> <span data-ttu-id="178fd-137">詳しくは、「[スポット広告](../monetize/interstitial-ads.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="178fd-137">For more information, see [Interstitial ads](../monetize/interstitial-ads.md).</span></span>

    * <span data-ttu-id="178fd-138">アプリにネイティブ広告が表示される場合、それらの値を [NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.nativeadsmanager.aspx) コンストラクターの *applicationId* パラメーターと *adUnitId* パラメーターに渡します。</span><span class="sxs-lookup"><span data-stu-id="178fd-138">If your app shows native ads, pass these values to the *applicationId* and *adUnitId* parameters of the [NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.nativeadsmanager.aspx) constructor.</span></span> <span data-ttu-id="178fd-139">詳しくは、「[ネイティブ広告](../monetize/native-ads.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="178fd-139">For more information, see [Native ads](../monetize/native-ads.md).</span></span>

<span id="manage" />

## <a name="manage-ad-units-for-multiple-ad-controls-in-your-app"></a><span data-ttu-id="178fd-140">アプリで複数の広告コントロールの広告ユニットを管理する</span><span class="sxs-lookup"><span data-stu-id="178fd-140">Manage ad units for multiple ad controls in your app</span></span>

<span data-ttu-id="178fd-141">1 つのアプリに複数のバナー広告コントロール、スポット広告コントロール、ネイティブ広告コントロールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="178fd-141">You can use multiple banner, interstitial, and native ad controls in a single app.</span></span> <span data-ttu-id="178fd-142">このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="178fd-142">In this scenario, we recommend that you assign a different ad unit to each control.</span></span> <span data-ttu-id="178fd-143">各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/in-app-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="178fd-143">Using different ad units for each control enables you to separately [configure the mediation settings](../publish/in-app-ads.md#mediation) and get discrete [reporting data](../publish/advertising-performance-report.md) for each control.</span></span> <span data-ttu-id="178fd-144">また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="178fd-144">This also enables our services to better optimize the ads we serve to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="178fd-145">各広告ユニットは 1 つのアプリのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="178fd-145">You can use each ad unit in only one app.</span></span> <span data-ttu-id="178fd-146">複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。</span><span class="sxs-lookup"><span data-stu-id="178fd-146">If you use an ad unit in more than one app, ads will not be served for that ad unit.</span></span>

## <a name="related-topics"></a><span data-ttu-id="178fd-147">関連トピック</span><span class="sxs-lookup"><span data-stu-id="178fd-147">Related topics</span></span>

* [<span data-ttu-id="178fd-148">XAML および .NET の AdControl</span><span class="sxs-lookup"><span data-stu-id="178fd-148">AdControl in XAML and .NET</span></span>](adcontrol-in-xaml-and--net.md)
* [<span data-ttu-id="178fd-149">HTML 5 および Javascript の AdControl</span><span class="sxs-lookup"><span data-stu-id="178fd-149">AdControl in HTML 5 and Javascript</span></span>](adcontrol-in-html-5-and-javascript.md)
* [<span data-ttu-id="178fd-150">スポット広告</span><span class="sxs-lookup"><span data-stu-id="178fd-150">Interstitial ads</span></span>](interstitial-ads.md)
* [<span data-ttu-id="178fd-151">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="178fd-151">Native ads</span></span>](native-ads.md)


 

 
