---
Description: パートナー センターで評価レポートでは、顧客がストアでアプリを評価する方法を確認できます。
title: レーティング レポート
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10、評価、uwp、速度、スター、星評価
ms.localizationpriority: medium
ms.openlocfilehash: 9b507212cd660a025bc3d858fc2938cf59d4219f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640057"
---
# <a name="ratings-report"></a><span data-ttu-id="98cb4-104">レーティング レポート</span><span class="sxs-lookup"><span data-stu-id="98cb4-104">Ratings report</span></span>


<span data-ttu-id="98cb4-105">**評価**レポート[パートナー センター](https://partner.microsoft.com/dashboard)で顧客がストアでアプリを評価する方法を確認できます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-105">The **Ratings** report in [Partner Center](https://partner.microsoft.com/dashboard) lets you see how customers rated your app in the Store.</span></span> 

<span data-ttu-id="98cb4-106">パートナー センターでこのデータを表示または[レポートをダウンロード](download-analytic-reports.md)オフラインで表示します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-106">You can view this data in Partner Center, or [download the report](download-analytic-reports.md) to view offline.</span></span> <span data-ttu-id="98cb4-107">使用してこのデータをプログラムで取得する代わりに、[取得アプリ レビュー](../monetize/get-app-reviews.md)メソッドで、 [Microsoft Store analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md)します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-107">Alternatively, you can programmatically retrieve this data by using the [get app reviews](../monetize/get-app-reviews.md) method in the [Microsoft Store analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

> [!TIP]
> <span data-ttu-id="98cb4-108">左側のナビゲーション メニューで **[Engage] (関心を引く)** を展開して **[レビューとフィードバック]** を選ぶと、自分のすべてのアプリの過去 30 日間のレビュー、評価、ユーザー フィードバックの概要を確認できます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-108">For a quick look at the reviews, ratings, and user feedback for all of your apps in the last 30 days, expand **Engage** in the left navigation menu and select **Reviews and feedback.**</span></span> 

## <a name="apply-filters"></a><span data-ttu-id="98cb4-109">フィルターの適用</span><span class="sxs-lookup"><span data-stu-id="98cb4-109">Apply filters</span></span>

<span data-ttu-id="98cb4-110">ページの上部で、レビューを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-110">Near the top of the page, you can select the time period for which you want to show reviews.</span></span> <span data-ttu-id="98cb4-111">既定では **[有効期間]** が選択されていますが、30 日間、3 カ月間、6 か月間、12 か月間のレビューや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-111">The default selection is **Lifetime**, but you can choose to show reviews for 30 days, 3 months, 6 months, or 12 months, or for a custom data range that you specify.</span></span> <span data-ttu-id="98cb4-112">**[評価の内訳]** と **[長期的な平均評価]** のグラフには、常に、過去 12 カ月間のデータが表示され、前述の期間のオプションはこれらのグラフには適用されません。</span><span class="sxs-lookup"><span data-stu-id="98cb4-112">Note that the **Ratings breakdown** and **Average rating over time** charts will always show data for the past 12 months; these time period options will not affect those charts.</span></span>

<span data-ttu-id="98cb4-113">**[フィルター]** を展開すると、次のオプションを使って、このページに表示するレビューをフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-113">You can expand **Filters** to filter the reviews shown on this page by the following options.</span></span> <span data-ttu-id="98cb4-114">これらのフィルターは **[評価の内訳]** と **[長期的な平均評価]** のグラフには、適用されません。</span><span class="sxs-lookup"><span data-stu-id="98cb4-114">These filters will not apply to the **Ratings breakdown** and **Average rating over time** charts.</span></span>

-   <span data-ttu-id="98cb4-115">**市場**:既定の設定は**すべての市場**します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-115">**Market**: The default setting is **All markets**.</span></span> <span data-ttu-id="98cb4-116">このページに特定の市場のユーザーからの評価のみを表示する場合は、特定の市場を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-116">You can choose a specific market if you want this page to only show ratings from customers in that market.</span></span>
-   <span data-ttu-id="98cb4-117">**デバイスの種類**:既定のフィルタは**すべてのデバイス**します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-117">**Device type**: The default filter is **All devices**.</span></span> <span data-ttu-id="98cb4-118">このページにその種類のデバイスを使っているユーザーによる評価のみを表示する場合は、特定のデバイスの種類を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-118">You can choose a specific device type if you want this page to only show ratings left by customers using that type of device.</span></span>
-   <span data-ttu-id="98cb4-119">**OS バージョン**:既定の設定は**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-119">**OS version**: The default setting is **All**.</span></span> <span data-ttu-id="98cb4-120">このページには、その OS のバージョンでのみお客様の規制左を表示する場合は、特定の OS バージョンを選択できます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-120">You can choose a specific OS version if you want this page to only show ratings left by customers on that OS version.</span></span>
-   <span data-ttu-id="98cb4-121">**カテゴリ名**:既定のフィルタは**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-121">**Category name**: The default filter is **All**.</span></span> <span data-ttu-id="98cb4-122">評価の特定に属するものとして特定したレビューに関連付けられているのみを表示することもできます[insight カテゴリを確認して](reviews-report.md#insight-categories)のみレビューが表示カテゴリに関連付けています。</span><span class="sxs-lookup"><span data-stu-id="98cb4-122">You can choose to only show ratings associated with reviews that we've identified as belonging to a specific [review insight category](reviews-report.md#insight-categories) to only show reviews that we’ve associated with that category.</span></span> 

> [!TIP]
> <span data-ttu-id="98cb4-123">任意の評価 ページが表示されない場合は、フィルターは、すべての評価を除外していないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-123">If you don't see any ratings on the page, check to make sure your filters haven't excluded all of your ratings.</span></span> <span data-ttu-id="98cb4-124">たとえば、アプリでサポートされていないターゲット OS をフィルター処理する場合は、任意の評価が表示されません。</span><span class="sxs-lookup"><span data-stu-id="98cb4-124">For example, if you filter by a Target OS that your app doesn't support, you won't see any ratings.</span></span>


## <a name="rating-breakdown"></a><span data-ttu-id="98cb4-125">評価の内訳</span><span class="sxs-lookup"><span data-stu-id="98cb4-125">Rating breakdown</span></span>

<span data-ttu-id="98cb4-126">**評価の内訳**グラフには。</span><span class="sxs-lookup"><span data-stu-id="98cb4-126">The **Rating breakdown** chart shows:</span></span> 
- <span data-ttu-id="98cb4-127">アプリの平均の星評価。</span><span class="sxs-lookup"><span data-stu-id="98cb4-127">The average rating star rating for the app.</span></span>
- <span data-ttu-id="98cb4-128">過去 12 か月間のアプリの評価の合計数。</span><span class="sxs-lookup"><span data-stu-id="98cb4-128">The total number of ratings of your app over the past 12 months.</span></span>
- <span data-ttu-id="98cb4-129">各星評価の評価総数。</span><span class="sxs-lookup"><span data-stu-id="98cb4-129">The total number of ratings for each star rating.</span></span>
- <span data-ttu-id="98cb4-130">評価の種類 (新着または更新済み) 別に示した、星評価ごとの過去 12 か月間の評価の数。</span><span class="sxs-lookup"><span data-stu-id="98cb4-130">The number of ratings for each type of rating (new or revised) per star rating over the past 12 months.</span></span>
 - <span data-ttu-id="98cb4-131">**新しい評価**は、ユーザーが送信し、まったく変更していない評価です。</span><span class="sxs-lookup"><span data-stu-id="98cb4-131">**New ratings** are ratings that customers have submitted but haven't changed at all.</span></span>
 - <span data-ttu-id="98cb4-132">**更新済み評価**は、単にレビューのテキストを変更しただけであっても、何かしらユーザーによって変更されている評価です。</span><span class="sxs-lookup"><span data-stu-id="98cb4-132">**Revised ratings** are ratings that have been changed by the customer in any way, even just changing the text of the review.</span></span>

> [!TIP]
> <span data-ttu-id="98cb4-133">ストア内でユーザーに表示される平均評価では、ユーザーの市場とデバイスの種類が考慮されているため、このレポートに表示される内容と異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="98cb4-133">The average rating that a customer sees in the Store takes into account the customer’s market and device type, so it may differ from what you see in this report.</span></span>


## <a name="average-rating"></a><span data-ttu-id="98cb4-134">平均評価</span><span class="sxs-lookup"><span data-stu-id="98cb4-134">Average rating</span></span>

<span data-ttu-id="98cb4-135">**平均評価**グラフは、過去 12 か月間、アプリの平均評価が変更された方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="98cb4-135">The **Average rating** chart shows how the app's average rating has changed over the past 12 months.</span></span>

<span data-ttu-id="98cb4-136">過去 12 か月の中にすべての評価の左の平均を計算するのではなく (ように、**評価の内訳**グラフ)、**平均評価**グラフは、お客様が指定した週で、アプリを評価する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-136">Rather than calculating the average of all ratings left during the past 12 months (as in the **Ratings breakdown** chart), the **Average rating** chart shows you how customers rated the app on a given week.</span></span> <span data-ttu-id="98cb4-137">このグラフは、傾向を特定する、または更新プログラムまたはその他の要因によって評価が影響を受けたかどうかを判断する場合に参考にできます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-137">This can help you identify trends or determine if ratings were affected by updates or other factors.</span></span>

## <a name="rating-by-market"></a><span data-ttu-id="98cb4-138">市場別の評価</span><span class="sxs-lookup"><span data-stu-id="98cb4-138">Rating by market</span></span>

<span data-ttu-id="98cb4-139">**市場で評価**グラフは、選択した期間の時間の経過と共にで各マーケット平均評価の内訳を示します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-139">The **Rating by market** chart shows a breakdown of the average ratings in each market over the time period selected.</span></span> <span data-ttu-id="98cb4-140">既定では、ビジュアルでこのデータを表示**マップ**がフォームとしてそれを表示する右上隅にあるコントロールを切り替えることができます、**テーブル**します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-140">By default, we show this data in a visual **Map** form, but you can also toggle the control in the upper right corner to view it as a **Table**.</span></span>

<span data-ttu-id="98cb4-141">**テーブル**ビューからアルファベット順または最高/最低、平均評価を並べ替え、一度に 5 の市場が表示されます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-141">The **Table** view shows five markets at a time, sorted either alphabetically or by highest/lowest average rating.</span></span> <span data-ttu-id="98cb4-142">すべての市場向けの情報を一緒に表示するグラフのデータをダウンロードすることもできます。</span><span class="sxs-lookup"><span data-stu-id="98cb4-142">You can also download this chart's data to view info for all markets together.</span></span>

<span data-ttu-id="98cb4-143">このグラフをフィルターすることもできます。**評価**します。</span><span class="sxs-lookup"><span data-stu-id="98cb4-143">You can also filter this chart by **Rating**.</span></span> <span data-ttu-id="98cb4-144">既定では、すべての星評価とレビューがチェックします、をチェックしてのみ特定の星評価に関連付けられているレビューを表示する場合は、(1 ~ 5 個の星) から特定の評価をオフにします。</span><span class="sxs-lookup"><span data-stu-id="98cb4-144">By default reviews with all star ratings are checked, but you can check and uncheck specific ratings (from 1 to 5 stars) if you want to only see reviews associated with particular star ratings.</span></span>