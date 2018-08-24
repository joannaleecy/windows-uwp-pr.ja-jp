---
author: mcleanbyron
description: マイクロソフトの広告仲介サービスを利用すると、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。
title: マイクロソフトの広告仲介サービス
ms.author: mcleans
ms.date: 06/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 広告, 広告, 広告仲介
ms.localizationpriority: medium
ms.openlocfilehash: e2774b44891934e10a72c1a944d6a0dad45872b5
ms.sourcegitcommit: cd91724c9b81c836af4773df8cd78e9f808a0bb4
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/07/2018
ms.locfileid: "1989269"
---
# <a name="microsoft-ad-mediation-service"></a><span data-ttu-id="e2a20-104">マイクロソフトの広告仲介サービス</span><span class="sxs-lookup"><span data-stu-id="e2a20-104">Microsoft ad mediation service</span></span>

<span data-ttu-id="e2a20-105">[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) を使用して[アプリに広告を表示する場合](display-ads-in-your-app.md)、必要に応じてマイクロソフトの広告仲介サービスを使って、広告の収益を最大化できます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-105">When you use the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) to [display ads in your apps](display-ads-in-your-app.md), you can optionally use the Microsoft ad mediation service to maximize your ad revenue.</span></span> <span data-ttu-id="e2a20-106">この記事では、広告仲介サービスとその目標の概要を示します。</span><span class="sxs-lookup"><span data-stu-id="e2a20-106">This article provides an overview of the ad mediation service and its goals.</span></span>

<span data-ttu-id="e2a20-107">広告仲介サービスは、[マイクロソフトの広告の収益化プラットフォーム](https://developer.microsoft.com/windows/ad-monetization-platform)の一部です。</span><span class="sxs-lookup"><span data-stu-id="e2a20-107">The ad mediation service is a part of the [Microsoft Ad Monetization platform](https://developer.microsoft.com/windows/ad-monetization-platform).</span></span> <span data-ttu-id="e2a20-108">プラットフォームは、次の部分で構成されます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-108">The platform is composed of the following parts.</span></span>

![addreferences](images/ad-mediation-service.png)

<span data-ttu-id="e2a20-110">広告仲介サービスは、これらの機能に基づいて構築することにより、アプリの広告収益を最大化することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="e2a20-110">The ad mediation service aims to maximize ad revenue for your apps by building on these capabilities.</span></span>

## <a name="diversity-of-demand-by-market-and-format"></a><span data-ttu-id="e2a20-111">市場と形式による需要の多様性</span><span class="sxs-lookup"><span data-stu-id="e2a20-111">Diversity of demand by market and format</span></span>

<span data-ttu-id="e2a20-112">広告仲介サービスは、(バナー、スポット バナー、スポット ビデオ、およびネイティブ) のさまざまな広告形式で、さまざまな広告ネットワークと統合されます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-112">The ad mediation service integrates with a variety of ad networks across the different ad formats (banner, interstitial banner, interstitial video, and native).</span></span> <span data-ttu-id="e2a20-113">広告仲介サービスは、各広告ネットワークと連携しエンド ユーザーとのエンゲージメントを最大限に高める可能性のある広告を提供できるようにします。</span><span class="sxs-lookup"><span data-stu-id="e2a20-113">The ad mediation service works with each ad network to ensure that they can serve ads with the highest potential for engaging the end user.</span></span> <span data-ttu-id="e2a20-114">引き続きさまざまな広告パートナーを追加して、需要の多様性と質を拡大する予定です。</span><span class="sxs-lookup"><span data-stu-id="e2a20-114">We will continue to add different ad partners to expand the variety and quality of demand.</span></span>

## <a name="manage-complexity-of-ad-network-relationships"></a><span data-ttu-id="e2a20-115">広告ネットワークの関係の複雑さの管理</span><span class="sxs-lookup"><span data-stu-id="e2a20-115">Manage complexity of ad network relationships</span></span>  

<span data-ttu-id="e2a20-116">広告仲介サービスはさまざまな広告ネットワークと統合されるため、開発者がこの作業を行う必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e2a20-116">The ad mediation service integrates with a wide variety of ad networks so that you don't need to do this work.</span></span> <span data-ttu-id="e2a20-117">Microsoft Advertising SDK を使用してアプリで広告を表示したら、[デベロッパー センター ダッシュボードを使用して](../publish/in-app-ads.md#mediation-settings)広告仲介設定を変更し、複数の広告ネットワークからの広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="e2a20-117">After you use the Microsoft Advertising SDK to display ads in your app, you can modify your ad mediation settings [using the Dev Center dashboard](../publish/in-app-ads.md#mediation-settings) to display ads from multiple ad networks.</span></span> <span data-ttu-id="e2a20-118">コードを変更することなく、新しい広告ネットワークから広告を取得できるという利点があります。</span><span class="sxs-lookup"><span data-stu-id="e2a20-118">You benefit from getting ads from new ad networks without having to make any changes to your code.</span></span>

<span data-ttu-id="e2a20-119">マイクロソフトでは、開発者に代わって広告ネットワークとのエンド ツー エンドの関係を管理します。</span><span class="sxs-lookup"><span data-stu-id="e2a20-119">We manage the end-to-end relationship with the ad networks on your behalf.</span></span> <span data-ttu-id="e2a20-120">開発者が余分な手間をかける必要はなく、広告ネットワークの統合から、広告の提供、レポートおよび支払いまですべてマイクロソフトが行います。</span><span class="sxs-lookup"><span data-stu-id="e2a20-120">Everything from ad network integration to serving ads, reporting and payouts are taken care of by us with no additional effort from you.</span></span>

## <a name="machine-learning-based-yield-optimization-algorithms"></a><span data-ttu-id="e2a20-121">機械学習に基づく収益最適化のアルゴリズム</span><span class="sxs-lookup"><span data-stu-id="e2a20-121">Machine learning-based yield optimization algorithms</span></span>

<span data-ttu-id="e2a20-122">広告仲介サービスは、開発者の最大の収益を生成するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-122">The ad mediation service works to generate the highest yield for developers.</span></span> <span data-ttu-id="e2a20-123">そのために、機械学習に基づく収益最適化のアルゴリズムを採用しています。</span><span class="sxs-lookup"><span data-stu-id="e2a20-123">To do so, it employs machine learning-based yield optimization algorithms.</span></span> <span data-ttu-id="e2a20-124">すべての広告呼び出しで、広告ネットワークが開発者の収益を最大化するために呼び出される必要がある最適な*連鎖的*順序をアルゴリズムが決定します。</span><span class="sxs-lookup"><span data-stu-id="e2a20-124">For every ad call, the algorithms determine the best *waterfall* order in which the ad networks need to be called to maximize revenue for you.</span></span> <span data-ttu-id="e2a20-125">これは次のような多くの要因を考慮して行われます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-125">This is done by considering many factors, including:</span></span>

* <span data-ttu-id="e2a20-126">要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="e2a20-126">The user making the request.</span></span>
* <span data-ttu-id="e2a20-127">要求の対象となるアプリケーション。</span><span class="sxs-lookup"><span data-stu-id="e2a20-127">The application the request is made for.</span></span>
* <span data-ttu-id="e2a20-128">広告ネットワークの過去のパフォーマンス。</span><span class="sxs-lookup"><span data-stu-id="e2a20-128">Past performance of the ad network.</span></span>
* <span data-ttu-id="e2a20-129">要求の送信元である広告形式と市場。</span><span class="sxs-lookup"><span data-stu-id="e2a20-129">The ad format and market where the request is coming from.</span></span>
* <span data-ttu-id="e2a20-130">広告呼び出しの回数。</span><span class="sxs-lookup"><span data-stu-id="e2a20-130">The time of the ad call.</span></span>
* <span data-ttu-id="e2a20-131">アプリのコンテンツのカテゴリー。</span><span class="sxs-lookup"><span data-stu-id="e2a20-131">The category of the app content.</span></span>
* <span data-ttu-id="e2a20-132">ユーザー セグメント。</span><span class="sxs-lookup"><span data-stu-id="e2a20-132">The user segment.</span></span>
* <span data-ttu-id="e2a20-133">ユーザーの位置情報。</span><span class="sxs-lookup"><span data-stu-id="e2a20-133">The user's location.</span></span>

<span data-ttu-id="e2a20-134">新しい広告ネットワークは自動的に含まれ、学習予算を通じてパフォーマンスが評価されます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-134">New ad networks are automatically included and evaluated for performance through a learning budget.</span></span> <span data-ttu-id="e2a20-135">短時間に、広告ネットワークは大量のイベント内で自分の場所を見つけます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-135">Within a short period of time, they find their place in the waterfall.</span></span> <span data-ttu-id="e2a20-136">これにより、広告ネットワークの競争力が強化され、開発者は、アプリの収益化を最大限に活用できます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-136">This makes the ad networks more competitive and helps the developer make the most of monetizing through apps.</span></span>

<span data-ttu-id="e2a20-137">[推奨される仲介設定](../publish/in-app-ads.md#mediation-settings)を使用してアプリ内広告で得られる収入を最大化することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2a20-137">We highly recommend using our [recommended mediation settings](../publish/in-app-ads.md#mediation-settings) to maximize revenue made from ads in your apps.</span></span> <span data-ttu-id="e2a20-138">これにより、アルゴリズムでアプリの最適な収益を可能にすることができます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-138">This allows for our algorithms to enable the best yield for your app.</span></span> <span data-ttu-id="e2a20-139">ただし、デベロッパー センター ダッシュボードで独自の仲介設定を自由に選択し、広告を提供する広告ネットワークや広告を提供する順序をより詳細に制御することもできます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-139">However, you also have the freedom to choose your own mediation settings in the Dev Center dashboard to have more control over the ad networks that serve ads and the order in which they do.</span></span>

## <a name="rich-data-and-signals"></a><span data-ttu-id="e2a20-140">豊富なデータと信号</span><span class="sxs-lookup"><span data-stu-id="e2a20-140">Rich data and signals</span></span>

<span data-ttu-id="e2a20-141">広告仲介サービスは、各ユーザーにとってより関連性の高い広告を表示するためのユーザーのターゲット設定を向上させるためにさまざまな広告ネットワークと連携します。</span><span class="sxs-lookup"><span data-stu-id="e2a20-141">The ad mediation service works with various ad networks to improve user targeting to show more relevant ads for each user.</span></span> <span data-ttu-id="e2a20-142">これは、プライバシー要件を考慮しながら、ユーザーやアプリに関する豊富な信号を広告ネットワークに送信することで行われます。</span><span class="sxs-lookup"><span data-stu-id="e2a20-142">This is done by sending richer signals about the user and the app to the ad network, while keeping privacy requirements in mind.</span></span>

## <a name="related-topics"></a><span data-ttu-id="e2a20-143">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e2a20-143">Related topics</span></span>

* [<span data-ttu-id="e2a20-144">Microsoft Advertising SDK</span><span class="sxs-lookup"><span data-stu-id="e2a20-144">Microsoft Advertising SDK</span></span>](http://aka.ms/ads-sdk-uwp)
* [<span data-ttu-id="e2a20-145">仲介設定</span><span class="sxs-lookup"><span data-stu-id="e2a20-145">Mediation settings</span></span>](../publish/in-app-ads.md#mediation-settings)
* [<span data-ttu-id="e2a20-146">[広告パフォーマンス] レポート</span><span class="sxs-lookup"><span data-stu-id="e2a20-146">Advertising performance report</span></span>](../publish/advertising-performance-report.md)