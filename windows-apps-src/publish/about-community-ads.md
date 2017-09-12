---
author: jnHs
Description: "自分のアプリと他の開発者が公開したアプリを相互に販売促進 (クロス プロモーション) することができます。 この機能をコミュニティ広告と呼びます。"
title: "コミュニティ広告について"
ms.assetid: F55CE478-99AF-4B70-90D1-D16419562136
ms.author: wdg-dev-content
ms.date: 07/05/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: c16f474fe8242e2994350f5261c26c7148aea5e4
ms.sourcegitcommit: 10f8dcf69d37cdb61562fc9f4d268ccb499c368f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/07/2017
---
# <a name="about-community-ads"></a><span data-ttu-id="b4dde-105">コミュニティ広告について</span><span class="sxs-lookup"><span data-stu-id="b4dde-105">About community ads</span></span>

<span data-ttu-id="b4dde-106">アプリで[バナー広告やバナースポット広告](../monetize/display-ads-in-your-app.md)を表示すると、Windows ストア内の自分のアプリと他の開発者のアプリを無料で相互に販売促進 (クロス プロモーション) できます。</span><span class="sxs-lookup"><span data-stu-id="b4dde-106">If your app [displays banner or banner interstitial ads](../monetize/display-ads-in-your-app.md), you can cross-promote your app with other developers with apps in the Windows Store for free.</span></span> <span data-ttu-id="b4dde-107">この機能を*コミュニティ広告*と呼びます。</span><span class="sxs-lookup"><span data-stu-id="b4dde-107">We call this feature *community ads*.</span></span>  

<span data-ttu-id="b4dde-108">このプログラムの内容を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b4dde-108">Here's how this program works:</span></span>

* <span data-ttu-id="b4dde-109">[コミュニティ広告にオプトイン](#how-to-opt-in-to-community-ads)して[無料のコミュニティ広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)すると、コミュニティ広告にオプトインした他の開発者とプロモーション用の広告スペースを共有します。</span><span class="sxs-lookup"><span data-stu-id="b4dde-109">After you [opt-in to community ads](#how-to-opt-in-to-community-ads) and [create a free community ad campaign](create-an-ad-campaign-for-your-app.md), your app will share promotional ad space with other developers who also opt in to community ads.</span></span> <span data-ttu-id="b4dde-110">自分のアプリに、コミュニティ広告に参加している他の開発者が公開したアプリの広告が表示され、他の開発者のアプリに自分のアプリの広告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b4dde-110">Your app will show ads for apps published by other developers who participate in community ads, and their apps will show ads for your app.</span></span>
* <span data-ttu-id="b4dde-111">アプリにコミュニティ広告を表示することによって、他のアプリ内のプロモーション用の広告スペースのクレジットを獲得できます。</span><span class="sxs-lookup"><span data-stu-id="b4dde-111">You earn credits for promotional ad space in other apps by showing community ads in your app.</span></span> <span data-ttu-id="b4dde-112">次のプロセスに従ってクレジットが計算されます。</span><span class="sxs-lookup"><span data-stu-id="b4dde-112">Credits are calculated according to the following process:</span></span>
  * <span data-ttu-id="b4dde-113">コミュニティ広告を提供するアプリが利用可能な国や地域ごとに、現在の市場レートの eCPM (1000 回の広告表示あたりの有効な料金) 値に、その国や地域でアプリが作成するコミュニティ広告に対するリクエスト数が掛けられます。</span><span class="sxs-lookup"><span data-stu-id="b4dde-113">For each country or region where an app that is serving community ads is available, the current market-rate eCPM (effective cost per thousand impressions) value for the country or region is multiplied by the number of requests for community ads made by your app in that country or region.</span></span> <span data-ttu-id="b4dde-114">この値は、対象の国や地域でアプリが獲得したクレジットです。</span><span class="sxs-lookup"><span data-stu-id="b4dde-114">This value is the credits you have earned for your app in that country or region.</span></span>
  * <span data-ttu-id="b4dde-115">特定の期間に獲得したクレジットの合計は、それぞれの国や地域でコミュニティ広告を提供する各アプリによって獲得したすべてのクレジットの合計と同じになります。</span><span class="sxs-lookup"><span data-stu-id="b4dde-115">Your total credits earned for a given time period is equal to the sum of all credits earned in each country or region for each of your apps that is serving community ads.</span></span>
* <span data-ttu-id="b4dde-116">クレジットは、すべてのアクティブなコミュニティ広告キャンペーンで均等に分割され、コミュニティ広告キャンペーンの対象となる国の現在の市場レートの eCPM 値に基づいてアプリの広告インプレッション数に変換されます。</span><span class="sxs-lookup"><span data-stu-id="b4dde-116">Your credits are divided equally across all active community ad campaigns, and are converted to ad impressions for your app based on the current market-rate eCPM values of the countries your community ad campaigns target.</span></span>
* <span data-ttu-id="b4dde-117">アプリ内のコミュニティ広告のパフォーマンスを追跡するには、「[[広告パフォーマンス] レポート](advertising-performance-report.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b4dde-117">To track the performance of the community ads in your app, refer to the [advertising performance report](advertising-performance-report.md).</span></span>

### <a name="opt-in-to-community-ads"></a><span data-ttu-id="b4dde-118">コミュニティ広告へのオプトイン</span><span class="sxs-lookup"><span data-stu-id="b4dde-118">Opt in to community ads</span></span>

<span data-ttu-id="b4dde-119">アプリの 1 つにコミュニティ広告キャンペーンを作成するには、Windows デベロッパー センター ダッシュボードでアプリの **[収益化]** &gt; **[広告で収入を増やす]** ページからオプトインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b4dde-119">Before you can create a community ad campaign for one of your apps, you must opt in on the **Monetization** &gt; **Monetize with ads** page for the app in the Windows Dev Center dashboard.</span></span>

<span data-ttu-id="b4dde-120">オプトインするには、次のいずれかを実行します。</span><span class="sxs-lookup"><span data-stu-id="b4dde-120">To opt in, do one of the following:</span></span>
  * <span data-ttu-id="b4dde-121">Windows 10 をターゲットとする UWP アプリでは、ページの **[広告仲介]** セクションに移動し、**[他の広告ネットワーク]** の一覧の **[Microsoft コミュニティ広告]** ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="b4dde-121">If your app is a UWP app that targets Windows 10, go to the **Ad mediation** section on the page and check the **Microsoft Community ads** box in the **Other ad networks** list.</span></span>
  * <span data-ttu-id="b4dde-122">Windows 8.x または Windows Phone 8.x をターゲットとするアプリでは、**[コミュニティ広告]** セクションに移動し、**[アプリにコミュニティ広告を表示する]** ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="b4dde-122">If your app targets Windows 8.x or Windows Phone 8.x, go to the **Community ads** section on the page and check the **Show community ads in my app** box.</span></span>

<span data-ttu-id="b4dde-123">この設定をした後にアプリを再公開する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="b4dde-123">You do not need to republish your app after making your selections.</span></span> <span data-ttu-id="b4dde-124">オプトインすると、[広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)するときに、キャンペーンの種類に **[コミュニティ広告 (無料)]** を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="b4dde-124">Once you've opted in, you'll be able to select **Community ad (free)** as the campaign type when you [create an ad campaign](create-an-ad-campaign-for-your-app.md).</span></span>

### <a name="related-topics"></a><span data-ttu-id="b4dde-125">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b4dde-125">Related topics</span></span>

* [<span data-ttu-id="b4dde-126">広告による収益獲得</span><span class="sxs-lookup"><span data-stu-id="b4dde-126">Monetize with ads</span></span>](monetize-with-ads.md)
* [<span data-ttu-id="b4dde-127">アプリの広告キャンペーンの作成</span><span class="sxs-lookup"><span data-stu-id="b4dde-127">Create an ad campaign for your app</span></span>](create-an-ad-campaign-for-your-app.md)
