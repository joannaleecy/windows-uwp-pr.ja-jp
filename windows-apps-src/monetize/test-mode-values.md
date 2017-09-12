---
author: mcleanbyron
ms.assetid: 2ed21281-f996-402d-a968-d1320a4691df
description: "この記事に示されているテスト用のアプリケーション ID と広告ユニット ID の値を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。"
title: "テスト モードの値"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, Advertising, テスト"
ms.openlocfilehash: 0c3e713d9a2bb7c10bda0d9517f5cb882d5e2e57
ms.sourcegitcommit: 6b772d2a224f8a9c557dc517c6ec0592545e9a43
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/02/2017
---
# <a name="test-mode-values"></a><span data-ttu-id="68a41-104">テスト モードの値</span><span class="sxs-lookup"><span data-stu-id="68a41-104">Test mode values</span></span>

<span data-ttu-id="68a41-105">[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx)、[InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx)、または [NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) を使ってアプリで広告を表示する場合、**AdUnitId** プロパティと **ApplicationId** プロパティで広告ユニット ID とアプリケーション ID を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="68a41-105">When you use an [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx),  [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx), or [NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) to display ads in your app, you must specify an ad unit ID and application ID in the **AdUnitId** and **ApplicationId** properties.</span></span> <span data-ttu-id="68a41-106">アプリを開発しているときには、この記事に示されているテスト用のアプリケーション ID と広告ユニット ID の値を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。</span><span class="sxs-lookup"><span data-stu-id="68a41-106">While you are developing your app, use the test application ID and ad unit ID values from this article to see how your app renders ads during testing.</span></span>

<span data-ttu-id="68a41-107">いったん公開したアプリでテスト用の値を使うと、ライブ アプリで広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="68a41-107">If you try to use test values in your app after you publish it, your live app not receive ads.</span></span> <span data-ttu-id="68a41-108">公開されたアプリで広告を表示するには、Windows デベロッパー センター ダッシュ ボードで提供されたアプリケーション ID と広告ユニット ID の値を使用するように、コードを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="68a41-108">To receive ads in your published app, you must update your code to use an application ID and ad unit ID provided by the Windows Dev Center dashboard.</span></span> <span data-ttu-id="68a41-109">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="68a41-109">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md).</span></span>
 
<span data-ttu-id="68a41-110">さまざまな広告の種類に使うためのテスト用の値を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="68a41-110">Here are the test values to use for the different ad types.</span></span>

* <span data-ttu-id="68a41-111">スポット広告の場合:</span><span class="sxs-lookup"><span data-stu-id="68a41-111">For interstitial ads:</span></span>

    <table>
    <colgroup>
    <col width="33%" />
    <col width="33%" />
    <col width="33%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="68a41-112">対象 OS</span><span class="sxs-lookup"><span data-stu-id="68a41-112">Target OS</span></span></th>
    <th align="left"><span data-ttu-id="68a41-113">AdUnitId</span><span class="sxs-lookup"><span data-stu-id="68a41-113">AdUnitId</span></span></th>
    <th align="left"><span data-ttu-id="68a41-114">ApplicationId</span><span class="sxs-lookup"><span data-stu-id="68a41-114">ApplicationId</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><p><span data-ttu-id="68a41-115">UWP (Windows 10)</span><span class="sxs-lookup"><span data-stu-id="68a41-115">UWP (Windows 10)</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-116">test</span><span class="sxs-lookup"><span data-stu-id="68a41-116">test</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-117">d25517cb-12d4-4699-8bdc-52040c712cab</span><span class="sxs-lookup"><span data-stu-id="68a41-117">d25517cb-12d4-4699-8bdc-52040c712cab</span></span></p></td>
    </tr>
    <tr class="odd">
    <td align="left"><p><span data-ttu-id="68a41-118">Windows 8.x および Windows Phone 8.x</span><span class="sxs-lookup"><span data-stu-id="68a41-118">Windows 8.x and Windows Phone 8.x</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-119">11389925</span><span class="sxs-lookup"><span data-stu-id="68a41-119">11389925</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-120">d25517cb-12d4-4699-8bdc-52040c712cab</span><span class="sxs-lookup"><span data-stu-id="68a41-120">d25517cb-12d4-4699-8bdc-52040c712cab</span></span></p></td>
    </tr>
    </tbody>
    </table>

     
* <span data-ttu-id="68a41-121">バナー広告の場合:</span><span class="sxs-lookup"><span data-stu-id="68a41-121">For banner ads:</span></span>

    <table>
    <colgroup>
    <col width="33%" />
    <col width="33%" />
    <col width="33%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="68a41-122">対象 OS</span><span class="sxs-lookup"><span data-stu-id="68a41-122">Target OS</span></span></th>
    <th align="left"><span data-ttu-id="68a41-123">AdUnitId</span><span class="sxs-lookup"><span data-stu-id="68a41-123">AdUnitId</span></span></th>
    <th align="left"><span data-ttu-id="68a41-124">ApplicationId</span><span class="sxs-lookup"><span data-stu-id="68a41-124">ApplicationId</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><p><span data-ttu-id="68a41-125">UWP (Windows 10)</span><span class="sxs-lookup"><span data-stu-id="68a41-125">UWP (Windows 10)</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-126">test</span><span class="sxs-lookup"><span data-stu-id="68a41-126">test</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-127">3f83fe91-d6be-434d-a0ae-7351c5a997f1</span><span class="sxs-lookup"><span data-stu-id="68a41-127">3f83fe91-d6be-434d-a0ae-7351c5a997f1</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><p><span data-ttu-id="68a41-128">Windows 8.x および Windows Phone 8.x</span><span class="sxs-lookup"><span data-stu-id="68a41-128">Windows 8.x and Windows Phone 8.x</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-129">10865270</span><span class="sxs-lookup"><span data-stu-id="68a41-129">10865270</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-130">3f83fe91-d6be-434d-a0ae-7351c5a997f1</span><span class="sxs-lookup"><span data-stu-id="68a41-130">3f83fe91-d6be-434d-a0ae-7351c5a997f1</span></span></p></td>
    </tr>
    </tbody>
    </table>

* <span data-ttu-id="68a41-131">ネイティブ広告の場合:</span><span class="sxs-lookup"><span data-stu-id="68a41-131">For native ads:</span></span>

    <table>
    <col width="33%" />
    <col width="33%" />
    <col width="33%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="68a41-132">対象 OS</span><span class="sxs-lookup"><span data-stu-id="68a41-132">Target OS</span></span></th>
    <th align="left"><span data-ttu-id="68a41-133">AdUnitId</span><span class="sxs-lookup"><span data-stu-id="68a41-133">AdUnitId</span></span></th>
    <th align="left"><span data-ttu-id="68a41-134">ApplicationId</span><span class="sxs-lookup"><span data-stu-id="68a41-134">ApplicationId</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><p><span data-ttu-id="68a41-135">UWP (Windows 10)</span><span class="sxs-lookup"><span data-stu-id="68a41-135">UWP (Windows 10)</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-136">test</span><span class="sxs-lookup"><span data-stu-id="68a41-136">test</span></span></p></td>
    <td align="left"><p><span data-ttu-id="68a41-137">d25517cb-12d4-4699-8bdc-52040c712cab</span><span class="sxs-lookup"><span data-stu-id="68a41-137">d25517cb-12d4-4699-8bdc-52040c712cab</span></span></p></td>
    </tbody>
    </table>

> [!IMPORTANT]
> <span data-ttu-id="68a41-138">**AdControl** では、ライブ広告のサイズは **Width** プロパティと **Height** プロパティによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="68a41-138">For an **AdControl**, the size of a live ad is defined by the **Width** and **Height** properties.</span></span> <span data-ttu-id="68a41-139">最善の結果を得るには、コード内の **Width** プロパティと **Height** プロパティが、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="68a41-139">For best results, make sure that the **Width** and **Height** properties in your code are one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span> <span data-ttu-id="68a41-140">**Width** プロパティと **Height** プロパティは、ライブ広告のサイズに基づいて変更されません。</span><span class="sxs-lookup"><span data-stu-id="68a41-140">The **Width** and **Height** properties will not change based on the size of a live ad.</span></span>


 

 
