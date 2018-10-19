---
author: jnHs
Description: To view performance data for the ad units in your apps, use the advertising performance report on the Windows Dev Center dashboard.
title: '[広告パフォーマンス] レポート'
ms.assetid: 32E555C3-C34D-4503-82BB-4C3F5CAE4500
ms.author: wdg-dev-content
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a1a82c91aeafa253427d8e526b38b8ac304591a2
ms.sourcegitcommit: 310a4555fedd4246188a98b31f6c094abb33ec60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5134998"
---
# <a name="advertising-performance-report"></a><span data-ttu-id="c41c3-103">[広告パフォーマンス] レポート</span><span class="sxs-lookup"><span data-stu-id="c41c3-103">Advertising performance report</span></span>


<span data-ttu-id="c41c3-104">**[広告パフォーマンス] レポート**は、コミュニティ広告など、[広告ユニット](in-app-ads.md)のパフォーマンスを示します。</span><span class="sxs-lookup"><span data-stu-id="c41c3-104">The **Advertising performance report** shows how your [ad units](in-app-ads.md) are performing, including community ads.</span></span> <span data-ttu-id="c41c3-105">このレポートには、[広告仲介](in-app-ads.md#mediation)を使う UWP アプリの複数のプロバイダーからのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-105">This report includes data from multiple ad providers in UWP apps that use [ad mediation](in-app-ads.md#mediation).</span></span>

<span data-ttu-id="c41c3-106">このレポートを表示するには、左側のナビゲーション メニューで **[分析]** を展開し、**[広告パフォーマンス]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-106">To view this report, expand **Analyze** in the left navigation menu and then select **Ad performance**.</span></span> <span data-ttu-id="c41c3-107">このデータは、ダッシュボードで表示することも、ページの矢印アイコンをクリックすることによりレポートをダウンロードしてオフラインで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-107">You can view this data in your dashboard, or download the report data to view offline by clicking the arrow icons on the page.</span></span> <span data-ttu-id="c41c3-108">このデータは、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[広告のパフォーマンス データの取得](../monetize/get-ad-performance-data.md)メソッドを使ってプログラムで取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-108">Alternatively, you can programmatically retrieve this data by using the [get ad performance data](../monetize/get-ad-performance-data.md) method in our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

<span data-ttu-id="c41c3-109">[広告パフォーマンス] レポートのデータを見るときは、さまざまなソースから新しいデータを受け取って処理するため、過去 3 日間のレポートのデータは変化する可能性があることにご注意ください。</span><span class="sxs-lookup"><span data-stu-id="c41c3-109">When viewing the advertising performance reports, be aware that reporting data for the last three days might change as we receive and process new data from various sources.</span></span> <span data-ttu-id="c41c3-110">また、最大で過去 90 日間のデータが再構成される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c41c3-110">Additionally, data restatements can happen up to 90 days in the past.</span></span>

## <a name="apply-filters"></a><span data-ttu-id="c41c3-111">フィルターを適用</span><span class="sxs-lookup"><span data-stu-id="c41c3-111">Apply filters</span></span>

<span data-ttu-id="c41c3-112">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-112">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="c41c3-113">既定では [30 日間] が選択されていますが、3、6、12 か月間のデータや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-113">The default selection is 30D (30 days), but you can choose to show data for 3, 6, or 12 months, or for a custom data range that you specify.</span></span>

<span data-ttu-id="c41c3-114">このページにある **[フィルター]** を展開して、このページのすべてのデータを広告ユニット、アプリ、広告プロバイダー、デバイスの種類を基にフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-114">You can also expand **Filters** to filter all of the data on this page by ad unit, app, ad provider, and device type.</span></span> <span data-ttu-id="c41c3-115">次のオプションから選択できます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-115">You can choose from the following options:</span></span>

* <span data-ttu-id="c41c3-116">**[集計]**: レポート データの集計方法と、そのデータに必要に応じてさらにフィルターを適用する方法を選びます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-116">**Aggregation**: Choose how the report data is aggregated and how it may be filtered further.</span></span> <span data-ttu-id="c41c3-117">既定では、このフィルターは **[すべての広告ユニット]** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-117">By default, this filter is set to **All ad units**.</span></span> <span data-ttu-id="c41c3-118">必要に応じてこのフィルターを **[すべてのアプリ]** や **[すべての広告プロバイダー]** に変更したり、広告を使う特定のアプリを基に集計したりするように選択することもできます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-118">You can optionally change this filter to **All apps** or **All ad providers**, or you can choose to aggregate by a specific app in which you use ads.</span></span>
* <span data-ttu-id="c41c3-119">**[広告プロバイダー]**: 特定の[広告プロバイダー](in-app-ads.md#paid-networks)のパフォーマンス データを表示するようにレポートにフィルターをかけます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-119">**Ad providers**: Filter the report to performance data for certain [ad providers](in-app-ads.md#paid-networks).</span></span> <span data-ttu-id="c41c3-120">既定では、すべての広告プロバイダーのデータが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-120">By default, the report shows data from all ad providers.</span></span> <span data-ttu-id="c41c3-121">このオプションは **[集計]** のドロップダウンで **[すべての広告プロバイダー]** を選んでいる場合は、無効になります。</span><span class="sxs-lookup"><span data-stu-id="c41c3-121">This option will be disabled if you chose **All ad providers** in the **Aggregation** drop-down.</span></span>
* <span data-ttu-id="c41c3-122">**[デバイス]**: 特定の種類のデバイスのパフォーマンス データを表示するようにレポートにフィルターをかけます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-122">**Device**: Filter the report to performance data for certain device types.</span></span> <span data-ttu-id="c41c3-123">既定では、すべての種類のデバイスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-123">By default, the report shows data for all device types.</span></span>

## <a name="overall-performance"></a><span data-ttu-id="c41c3-124">全体的なパフォーマンス</span><span class="sxs-lookup"><span data-stu-id="c41c3-124">Overall performance</span></span>

<span data-ttu-id="c41c3-125">このセクションには、広告ユニット、アプリ、レポート フィルターで選んだ広告プロバイダーの広告パフォーマンス メトリックがグラフまたは世界地図ビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-125">This section displays ad performance metrics in a chart or world map view for the ad units, apps, and ad providers you have selected in the report filters.</span></span>

<span data-ttu-id="c41c3-126">データのビューを切り替えるには、**[全体的なパフォーマンス]** セクションの上部で **[グラフ]** または **[マップ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c41c3-126">To switch to a different view of the data, click **Chart** or **Map** at the top of the **Overall performance** section.</span></span> <span data-ttu-id="c41c3-127">マップ ビューで、濃い網掛けは高い値を示し、淡い網掛けは低い値を示します。</span><span class="sxs-lookup"><span data-stu-id="c41c3-127">In the map view, darker shades represent higher values and lighter shades represent lower values.</span></span> <span data-ttu-id="c41c3-128">地図上の特定の国や地域をポイントすることによって、選択したメトリックの値を分析できます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-128">You can hover over a specific country or region on the map to analyze the value of the selected metric.</span></span> <span data-ttu-id="c41c3-129">地図の任意の領域を拡大して、小さい国々のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-129">You can also zoom in on any area of the map to view data for smaller countries.</span></span>

<span data-ttu-id="c41c3-130">グラフまたはマップに表示されるデータを絞り込むには、**[グラフ]** または **[マップ]** ドロップダウンの横にあるフィルター アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="c41c3-130">You can refine the data shown in the chart or map by clicking the filter icon next to the **Chart** or **Map** drop-down.</span></span> <span data-ttu-id="c41c3-131">このフィルターを使うと、最大 6 つの異なる広告ユニット、アプリ、または広告プロバイダーから選んで、グラフまたはマップ ビューで比較できます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-131">This filter enables you to choose from up to six different ad units, apps, or ad providers to compare in the chart or map view.</span></span> <span data-ttu-id="c41c3-132">このフィルターから選ぶことができるデータの種類は、レポートの上部にある **[集計]** 最上位レベル フィルターで選んだ内容によって異なります。</span><span class="sxs-lookup"><span data-stu-id="c41c3-132">The type of data you can choose from in this filter depends on what you selected for the **Aggregation** top-level filter at the top of the report.</span></span>


## <a name="overall-performance-breakdown"></a><span data-ttu-id="c41c3-133">全体的なパフォーマンスの詳細</span><span class="sxs-lookup"><span data-stu-id="c41c3-133">Overall performance breakdown</span></span>

<span data-ttu-id="c41c3-134">このセクションには、レポートで選んだフィルターにより指定されたデータ セットのすべての広告パフォーマンス メトリックを含む表が表示されます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-134">This section displays a table that contains all the ad performance metrics for the data set specified by the filters you have selected in the report.</span></span>

## <a name="performance-metrics"></a><span data-ttu-id="c41c3-135">パフォーマンス メトリック</span><span class="sxs-lookup"><span data-stu-id="c41c3-135">Performance metrics</span></span>

<span data-ttu-id="c41c3-136">**広告パフォーマンス** レポートには、次のパフォーマンス メトリックのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-136">The **Advertising performance** report includes data for the following performance metrics.</span></span> <span data-ttu-id="c41c3-137">メトリックによっては、特定の広告プロバイダーにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="c41c3-137">Some metrics are shown only for certain ad providers.</span></span>

|  <span data-ttu-id="c41c3-138">メトリック</span><span class="sxs-lookup"><span data-stu-id="c41c3-138">Metric</span></span>  |  <span data-ttu-id="c41c3-139">説明</span><span class="sxs-lookup"><span data-stu-id="c41c3-139">Description</span></span>  |
|----------|---------------|
| <span data-ttu-id="c41c3-140">売上見込み</span><span class="sxs-lookup"><span data-stu-id="c41c3-140">Estimated revenue</span></span>  |  <span data-ttu-id="c41c3-141">アプリで実行されている広告から受け取った見込み金額。</span><span class="sxs-lookup"><span data-stu-id="c41c3-141">The estimated amount of money you received from the ads running on your app.</span></span> |
| <span data-ttu-id="c41c3-142">eCPM</span><span class="sxs-lookup"><span data-stu-id="c41c3-142">eCPM</span></span>  |  <span data-ttu-id="c41c3-143">1,000 回の広告表示あたりの実効コスト。</span><span class="sxs-lookup"><span data-stu-id="c41c3-143">Effective cost per thousand impressions.</span></span> |
| <span data-ttu-id="c41c3-144">要求</span><span class="sxs-lookup"><span data-stu-id="c41c3-144">Requests</span></span>  | <span data-ttu-id="c41c3-145">アプリから広告要求が送信された回数。</span><span class="sxs-lookup"><span data-stu-id="c41c3-145">The number of times an ad request was sent from your app.</span></span>  |
| <span data-ttu-id="c41c3-146">インプレッション数</span><span class="sxs-lookup"><span data-stu-id="c41c3-146">Impressions</span></span>  | <span data-ttu-id="c41c3-147">広告がアプリに表示された回数。</span><span class="sxs-lookup"><span data-stu-id="c41c3-147">The number of times an ad was shown in your app.</span></span>  |
| <span data-ttu-id="c41c3-148">フィル レート</span><span class="sxs-lookup"><span data-stu-id="c41c3-148">Fill rate</span></span>  | <span data-ttu-id="c41c3-149">アプリから送信された広告要求に対して広告が表示された割合。</span><span class="sxs-lookup"><span data-stu-id="c41c3-149">The percentage of ad requests sent from your app in which an ad was shown.</span></span>  |
| <span data-ttu-id="c41c3-150">クリック数</span><span class="sxs-lookup"><span data-stu-id="c41c3-150">Clicks</span></span>  |  <span data-ttu-id="c41c3-151">アプリ内の広告がクリックされた回数。</span><span class="sxs-lookup"><span data-stu-id="c41c3-151">The number of times someone clicked on an ad in your app.</span></span> |
| <span data-ttu-id="c41c3-152">CTR</span><span class="sxs-lookup"><span data-stu-id="c41c3-152">CTR</span></span>  |  <span data-ttu-id="c41c3-153">クリック スルー レート、つまり広告がクリックされた回数をインプレッション数で割った値。</span><span class="sxs-lookup"><span data-stu-id="c41c3-153">Click-through rate, meaning the number of times an ad was clicked, divided by the number of impressions.</span></span> |
| <span data-ttu-id="c41c3-154">視認性</span><span class="sxs-lookup"><span data-stu-id="c41c3-154">Viewability</span></span> | <span data-ttu-id="c41c3-155">アプリで表示可能な広告インプレッションの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="c41c3-155">The percentage of ad impressions that are viewable in your app.</span></span> <span data-ttu-id="c41c3-156">この値を計算する方法について詳しくは、[広告ユニットの視認性の最適化](../monetize/optimize-ad-unit-viewability.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c41c3-156">For more details about how this value is calculated, see [Optimize the viewability of your ad units](../monetize/optimize-ad-unit-viewability.md).</span></span> |
| <span data-ttu-id="c41c3-157">取得したクレジット</span><span class="sxs-lookup"><span data-stu-id="c41c3-157">Credits earned</span></span>  | <span data-ttu-id="c41c3-158">[コミュニティ広告](https://docs.microsoft.com/windows/uwp/publish/about-community-ads)キャンペーンを実行している場合、このアプリ内にコミュニティ広告を表示することで獲得したプロモーション用広告スペースのクレジット数。</span><span class="sxs-lookup"><span data-stu-id="c41c3-158">If you are running a [community ad](https://docs.microsoft.com/windows/uwp/publish/about-community-ads) campaign, this indicates the number of credits you have earned for promotional ad space by showing community ads in your app.</span></span>  |
| <span data-ttu-id="c41c3-159">使用したクレジット</span><span class="sxs-lookup"><span data-stu-id="c41c3-159">Credits spent</span></span>  | <span data-ttu-id="c41c3-160">[コミュニティ広告](https://docs.microsoft.com/windows/uwp/publish/about-community-ads)キャンペーンを実行している場合、このアプリの広告のために消費したクレジット数。</span><span class="sxs-lookup"><span data-stu-id="c41c3-160">If you are running a [community ad](https://docs.microsoft.com/windows/uwp/publish/about-community-ads) campaign, this indicates the number of credits you have spent on ads for your app.</span></span>  |

## <a name="related-topics"></a><span data-ttu-id="c41c3-161">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c41c3-161">Related topics</span></span>

* [<span data-ttu-id="c41c3-162">アプリ内広告</span><span class="sxs-lookup"><span data-stu-id="c41c3-162">In-app ads</span></span>](in-app-ads.md)
* [<span data-ttu-id="c41c3-163">Microsoft Advertising SDK を使用したアプリでの広告の表示</span><span class="sxs-lookup"><span data-stu-id="c41c3-163">Display ads in your app with the Microsoft Advertising SDK</span></span>](../monetize/display-ads-in-your-app.md)
* [<span data-ttu-id="c41c3-164">広告ユニットの見やすさを最適化する</span><span class="sxs-lookup"><span data-stu-id="c41c3-164">Optimize the viewability of your ad units</span></span>](../monetize/optimize-ad-unit-viewability.md)


 
