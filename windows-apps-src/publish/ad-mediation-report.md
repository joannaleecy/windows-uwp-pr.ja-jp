---
author: jnHs
Description: "広告仲介レポートでは、有効なフィル レートと、使っている広告ネットワークの対応するフィル レートを確認できます。"
title: "広告仲介レポート"
ms.assetid: 18A33928-B9F2-4F76-9A9C-F01FEE42FEA1
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 0c08c1061231b033dc5401c77085e16ea7001bb1
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="ad-mediation-report"></a><span data-ttu-id="78be2-104">広告仲介レポート</span><span class="sxs-lookup"><span data-stu-id="78be2-104">Ad mediation report</span></span>

<span data-ttu-id="78be2-105">このレポートは、Windows 8.x アプリまたは Windows Phone 8.x アプリで [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) の **AdMediatorControl** を使って、複数の広告ネットワークからのバナー広告を仲介している場合に、アプリの広告仲介データを表示します。</span><span class="sxs-lookup"><span data-stu-id="78be2-105">This report shows ad mediation data for Windows 8.x or Windows Phone 8.x apps that use an **AdMediatorControl** from the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk) to mediate banner ads from multiple ad networks.</span></span> <span data-ttu-id="78be2-106">このレポートでは、このようなアプリについて、有効なフィル レートと、使用している広告ネットワークごとのフィル レートを確認できます。</span><span class="sxs-lookup"><span data-stu-id="78be2-106">For these apps, this report lets you see your effective fill rate and the respective fill rates for the ad networks you're using.</span></span> <span data-ttu-id="78be2-107">さらに、メディエーション構成ごとの導入率や、広告ネットワークとメディエーターによって報告されたエラーも表示されます。</span><span class="sxs-lookup"><span data-stu-id="78be2-107">It also shows the adoption rates of each of your mediation configurations and provides visibility into errors reported by ad networks and the mediator.</span></span> <span data-ttu-id="78be2-108">このデータは、ダッシュボードで表示することも、[レポートをダウンロード](download-analytic-reports.md)してオフラインで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="78be2-108">You can view this data in your dashboard, or [download the report](download-analytic-reports.md) to view offline.</span></span>

> [!NOTE]
> <span data-ttu-id="78be2-109">**広告仲介**レポートは、Windows 8.x または Windows Phone 8.x アプリで **AdMediatorControl** を使っている場合にのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="78be2-109">The **Ad mediation** report is only available if you are using an **AdMediatorControl** in your Windows 8.x or Windows Phone 8.x app.</span></span> <span data-ttu-id="78be2-110">詳しくは、[こちらの記事](https://msdn.microsoft.com/library/windows/apps/xaml/dn864359)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78be2-110">For more information, see [this article](https://msdn.microsoft.com/library/windows/apps/xaml/dn864359).</span></span> <span data-ttu-id="78be2-111">**AdControl** コントロールまたは **InterstitialAd** コントロールで[広告仲介](monetize-with-ads.md#mediation)を使う UWP アプリについて広告ネットワークのパフォーマンス データを確認するには、[[広告パフォーマンス] レポート](advertising-performance-report.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="78be2-111">For a UWP app that uses [ad mediation](monetize-with-ads.md#mediation) in an **AdControl** or **InterstitialAd** control, use the [Advertising performance report](advertising-performance-report.md) to review performance data for the ad networks.</span></span>

## <a name="page-filters"></a><span data-ttu-id="78be2-112">ページ フィルター</span><span class="sxs-lookup"><span data-stu-id="78be2-112">Page filters</span></span>

<span data-ttu-id="78be2-113">ページの上部にある **[ページ フィルター]** を展開して、このページのすべてのデータを日付の範囲や市場によってフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="78be2-113">Near the top of the page, you can expand **Page filters** to filter all of the data on this page by date range and/or by market.</span></span>

-   <span data-ttu-id="78be2-114">**[日付]**: 既定のフィルターは **[過去 30 日]** ですが、これを **[過去 12 か月]** まで拡張できます。</span><span class="sxs-lookup"><span data-stu-id="78be2-114">**Date**: The default filter is **Last 30 days**, but you can expand this up to **Last 12 months**.</span></span>
-   <span data-ttu-id="78be2-115">**[市場]**: 既定の設定は **[すべての市場]** です。</span><span class="sxs-lookup"><span data-stu-id="78be2-115">**Market**: The default setting is **All markets**.</span></span> <span data-ttu-id="78be2-116">このページに特定の市場のユーザーからの評価のみを表示する場合は、特定の市場を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="78be2-116">You can choose a specific market if you want this page to only show ratings from customers in that market.</span></span>
-   <span data-ttu-id="78be2-117">**[プラットフォーム]**: 既定の設定は **[すべてのプラットフォーム]** です。</span><span class="sxs-lookup"><span data-stu-id="78be2-117">**Platform**: The default setting is **All platforms**.</span></span> <span data-ttu-id="78be2-118">アプリが複数のプラットフォームを対象としている場合、特定のプラットフォームを選択できます。</span><span class="sxs-lookup"><span data-stu-id="78be2-118">If your app targets multiple platforms, you can choose a specific platform.</span></span>

<span data-ttu-id="78be2-119">次に挙げているすべてのグラフに表示される情報には、**[ページ フィルター]** で選んだ期間が反映されます。</span><span class="sxs-lookup"><span data-stu-id="78be2-119">The info in all of the charts listed below will reflect the period of time selected in **Page filters**.</span></span> <span data-ttu-id="78be2-120">既定では、**[ページ フィルター]** を使用して特定の市場やプラットフォームを指定している場合を除き、アプリが一覧に表示されているすべての市場およびプラットフォームからのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="78be2-120">By default this will include data from all of the markets and platforms in which your app is listed, unless you've used the **Page filters** to specify a specific market and/or platform.</span></span>

## <a name="ad-mediation-performance"></a><span data-ttu-id="78be2-121">広告仲介のパフォーマンス</span><span class="sxs-lookup"><span data-stu-id="78be2-121">Ad mediation performance</span></span>

<span data-ttu-id="78be2-122">**広告仲介のパフォーマンス** グラフには、選んだ期間の平均合計フィル レートが表示されます。</span><span class="sxs-lookup"><span data-stu-id="78be2-122">The **Ad mediation performance** chart shows the average total fill rate over the selected period of time.</span></span> <span data-ttu-id="78be2-123">これは、メディエーション構成や、さまざまな広告ネットワークが呼び出された頻度に関係なく、すべてのユーザー セッションの平均フィル レートです。</span><span class="sxs-lookup"><span data-stu-id="78be2-123">This is the average fill rate across all user sessions, regardless of your mediation configuration or how often different ad networks were called.</span></span>

<span data-ttu-id="78be2-124">**[メディエーション要求]** 見出しをクリックすると、個々のメディエーション要求の平均数が表示され、**[配信された広告数]** をクリックすると配信された広告の平均合計数が表示されます。</span><span class="sxs-lookup"><span data-stu-id="78be2-124">You can click the **Mediation requests** heading to see the average number of individual mediation requests, or click **Ads delivered** to see the average total number of ads delivered.</span></span>

## <a name="ad-provider-fill-rates"></a><span data-ttu-id="78be2-125">広告プロバイダー フィル レート</span><span class="sxs-lookup"><span data-stu-id="78be2-125">Ad provider fill rates</span></span>

<span data-ttu-id="78be2-126">**広告プロバイダーのフィル レート** グラフには、選んだ期間における各広告ネットワークの平均フィル レートが表示されます。</span><span class="sxs-lookup"><span data-stu-id="78be2-126">The **Ad provider fill rates** chart shows the average fill rate of each of your ad networks over the selected period of time.</span></span>

<span data-ttu-id="78be2-127">各広告ネットワークの情報は、各広告ネットワークのパフォーマンスを比較できるように一緒に表示されます。</span><span class="sxs-lookup"><span data-stu-id="78be2-127">Info for each ad network is shown together to help you compare each ad network's performance.</span></span>

## <a name="unique-users-per-mediation-configuration"></a><span data-ttu-id="78be2-128">メディエーション構成ごとの固有ユーザー</span><span class="sxs-lookup"><span data-stu-id="78be2-128">Unique users per mediation configuration</span></span>

<span data-ttu-id="78be2-129">**メディエーション構成ごとの固有ユーザー数**グラフには、選んだ期間におけるメディエーション構成の各バージョンを受信した固有ユーザーの合計数が表示されます。</span><span class="sxs-lookup"><span data-stu-id="78be2-129">The **Unique users per mediation configuration** chart shows the total number of unique users who received each version of your mediation configuration over the selected period of time.</span></span>

## <a name="errors-by-ad-network"></a><span data-ttu-id="78be2-130">広告ネットワーク別エラー数</span><span class="sxs-lookup"><span data-stu-id="78be2-130">Errors by ad network</span></span>

<span data-ttu-id="78be2-131">**広告ネットワーク別エラー数**グラフには、各広告ネットワークの要求とエラーの合計数に加えて、エラーになった要求の割合が表示されます。</span><span class="sxs-lookup"><span data-stu-id="78be2-131">The **Errors by ad network** chart shows the total number of requests and errors for each of your ad networks, along with the percentage of requests that resulted in an error.</span></span>

## <a name="errors-by-type"></a><span data-ttu-id="78be2-132">種類別エラー数</span><span class="sxs-lookup"><span data-stu-id="78be2-132">Errors by type</span></span>

<span data-ttu-id="78be2-133">**種類別エラー数**グラフには、各広告ネットワークで発生した特定のエラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="78be2-133">The **Errors by type** chart shows the specific errors experienced by each ad network.</span></span> <span data-ttu-id="78be2-134">特定のエラーが示すそのネットワークの合計エラー数の割合も表示されるため、広告ネットワークごとに頻繁に発生するエラーを知ることができます。</span><span class="sxs-lookup"><span data-stu-id="78be2-134">It also shows the percentage of total errors for that network that a specific error represents, so you can get an idea of which errors are coming up frequently per ad network.</span></span>

 

 
