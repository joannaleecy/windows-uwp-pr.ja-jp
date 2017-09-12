---
author: jnHs
Description: "Windows デベロッパー センター ダッシュボードの [レビュー] レポートでは、ユーザーがストアでアプリを評価したときに入力した評価とコメントを確認できます。"
title: "[レビュー] レポート"
ms.assetid: E50C3A4D-1D8A-4E5B-8182-3FAD049F2A2D
ms.author: wdg-dev-content
ms.date: 08/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b28883ffe2e1993e87c2d41fdb64108d94c8e841
ms.sourcegitcommit: a8e7dc247196eee79b67aaae2b2a4496c54ce253
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/04/2017
---
# <a name="reviews-report"></a><span data-ttu-id="da850-104">[レビュー] レポート</span><span class="sxs-lookup"><span data-stu-id="da850-104">Reviews report</span></span>


<span data-ttu-id="da850-105">Windows デベロッパー センター ダッシュボードの **[レビュー]** レポートでは、ユーザーがストアでアプリを評価したときに入力した評価とコメントを確認できます。</span><span class="sxs-lookup"><span data-stu-id="da850-105">The **Reviews** report in the Windows Dev Center dashboard lets you see the ratings and comments that customers entered when rating your app in the Store.</span></span> <span data-ttu-id="da850-106">このデータは、ダッシュボードで表示することも、[レポートをダウンロード](download-analytic-reports.md)してオフラインで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="da850-106">You can view this data in your dashboard, or [download the report](download-analytic-reports.md) to view offline.</span></span> <span data-ttu-id="da850-107">または、[Windows ストア分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[アプリ レビューの取得](../monetize/get-app-reviews.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="da850-107">Alternatively, you can programmatically retrieve this data by using the [get app reviews](../monetize/get-app-reviews.md) method in the [Windows Store analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

<span data-ttu-id="da850-108">また、ユーザー レビューに対して、[このページから直接](respond-to-customer-reviews.md)、[Windows ストア レビュー API](../monetize/submit-responses-to-app-reviews.md) を使ってプログラムにより、または[デベロッパー センター アプリ](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws) を使って、返信することもできます。</span><span class="sxs-lookup"><span data-stu-id="da850-108">You can also respond to customer reviews [directly from this page](respond-to-customer-reviews.md), programmatically [via the Windows Store reviews API](../monetize/submit-responses-to-app-reviews.md), or by using the [Dev Center app](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws).</span></span>

> [!TIP]
> <span data-ttu-id="da850-109">左側のナビゲーション メニューで **[Engage] (関心を引く)** を展開して **[レビューとフィードバック]** を選ぶと、自分のすべてのアプリの過去 30 日間のレビュー、評価、ユーザー フィードバックの概要を確認できます。</span><span class="sxs-lookup"><span data-stu-id="da850-109">For a quick look at the reviews, ratings, and user feedback for all of your apps in the last 30 days, expand **Engage** in the left navigation menu and select **Reviews and feedback.**</span></span> 

## <a name="apply-filters"></a><span data-ttu-id="da850-110">フィルターを適用</span><span class="sxs-lookup"><span data-stu-id="da850-110">Apply filters</span></span>

<span data-ttu-id="da850-111">ページの上部で、レビューを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="da850-111">Near the top of the page, you can select the time period for which you want to show reviews.</span></span> <span data-ttu-id="da850-112">既定では **[有効期間]** が選択されていますが、30 日間、3 カ月間、6 か月間、12 か月間のレビューや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="da850-112">The default selection is **Lifetime**, but you can choose to show reviews for 30 days, 3 months, 6 months, or 12 months, or for a custom data range that you specify.</span></span> <span data-ttu-id="da850-113">**[評価の内訳]** と **[長期的な平均評価]** のグラフには、常に、過去 12 カ月間のデータが表示され、前述の期間のオプションはこれらのグラフには適用されません。</span><span class="sxs-lookup"><span data-stu-id="da850-113">Note that the **Ratings breakdown** and **Average rating over time** charts will always show data for the past 12 months; these time period options will not affect those charts.</span></span>

<span data-ttu-id="da850-114">**[フィルター]** を展開すると、次のオプションを使って、このページに表示するレビューをフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="da850-114">You can expand **Filters** to filter the reviews shown on this page by the following options.</span></span> <span data-ttu-id="da850-115">これらのフィルターは **[評価の内訳]** と **[長期的な平均評価]** のグラフには、適用されません。</span><span class="sxs-lookup"><span data-stu-id="da850-115">These filters will not apply to the **Ratings breakdown** and **Average rating over time** charts.</span></span>

-   <span data-ttu-id="da850-116">**[評価]**: 既定ではすべての星評価のレビューが表示される設定になっていますが、特定の星評価に関連するレビューのみを表示する場合は、特定の評価 (1 ～ 5 つの星) をオンまたはオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="da850-116">**Rating**: By default reviews with all star ratings are checked, but you can check and uncheck specific ratings (from 1 to 5 stars) if you want to only see reviews associated with particular star ratings.</span></span>
-   <span data-ttu-id="da850-117">**[レビュー コンテンツ]**: 既定の設定は **[すべて]** で、レビューのテキストが追加されていない評価が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da850-117">**Review content**: The default setting is **All**, which includes ratings without review text added.</span></span> <span data-ttu-id="da850-118">**[評価 (レビュー コンテンツあり)]** を選ぶと、記述されたレビュー コンテンツを含む評価のみを表示できます。</span><span class="sxs-lookup"><span data-stu-id="da850-118">You can select **Ratings with review content** to only show ratings that include written review content.</span></span>
-   <span data-ttu-id="da850-119">**[OS バージョン]**: 既定の設定は **[すべて]** です。</span><span class="sxs-lookup"><span data-stu-id="da850-119">**OS version**: The default setting is **All**.</span></span> <span data-ttu-id="da850-120">特定の OS バージョンを選ぶと、その OS バージョンを使っているユーザーによるレビューのみをこのページに表示できます。</span><span class="sxs-lookup"><span data-stu-id="da850-120">You can choose a specific OS version if you want this page to only show reviews left by customers on that OS version.</span></span>
-   <span data-ttu-id="da850-121">**[パッケージ バージョン]**: 既定の設定は **[すべて]** です。</span><span class="sxs-lookup"><span data-stu-id="da850-121">**Package version**: The default setting is **All**.</span></span> <span data-ttu-id="da850-122">アプリに複数のパッケージがある場合、ここで特定のパッケージを選ぶと、アプリのレビュー時にそのパッケージを持っていたユーザーによるレビューのみをこのページに表示できます。</span><span class="sxs-lookup"><span data-stu-id="da850-122">If your app includes more than one package, you can choose a specific one here to only show reviews left by customers who had that package when they reviewed your app.</span></span>
-   <span data-ttu-id="da850-123">**[応答]**: 既定の設定は **[すべて]** です。</span><span class="sxs-lookup"><span data-stu-id="da850-123">**Responses**: The default setting is **All**.</span></span> <span data-ttu-id="da850-124">レビューをフィルター処理して、[ユーザーに返信した](respond-to-customer-reviews.md)レビューのみ、または、まだ返信していないレビューのみを表示できます。</span><span class="sxs-lookup"><span data-stu-id="da850-124">You can choose to filter the reviews to only show the reviews where you have [responded to customers](respond-to-customer-reviews.md), or only those where you have not yet responded.</span></span>
-   <span data-ttu-id="da850-125">**[更新]**: 既定の設定は **[すべて]** です。</span><span class="sxs-lookup"><span data-stu-id="da850-125">**Updates**: The default setting is **All**.</span></span> <span data-ttu-id="da850-126">レビューをフィルター処理して、[レビューへの返信](respond-to-customer-reviews.md)以降に、ユーザーによって更新されているレビューのみ、または、ユーザーによって更新されていないレビューのみを表示できます。</span><span class="sxs-lookup"><span data-stu-id="da850-126">You can choose to filter the reviews to only show the reviews that have been updated by the customer since you [responded to a review](respond-to-customer-reviews.md), or only those which have not yet been updated by the customer.</span></span>
-   <span data-ttu-id="da850-127">**[市場]**: 既定の設定は **[すべての市場]** です。</span><span class="sxs-lookup"><span data-stu-id="da850-127">**Market**: The default setting is **All markets**.</span></span> <span data-ttu-id="da850-128">このページに特定の市場のユーザーからのレビューのみを表示する場合は、特定の市場を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="da850-128">You can choose a specific market if you want this page to only show reviews from customers in that market.</span></span>
-   <span data-ttu-id="da850-129">**[デバイスの種類]**: 既定のフィルターは **[すべてのデバイス]** です。</span><span class="sxs-lookup"><span data-stu-id="da850-129">**Device type**: The default filter is **All devices**.</span></span> <span data-ttu-id="da850-130">特定のデバイスの種類を選ぶと、その種類のデバイスを使っているユーザーによるレビューのみをこのページに表示できます。</span><span class="sxs-lookup"><span data-stu-id="da850-130">You can choose a specific device type if you want this page to only show reviews left by customers using that type of device.</span></span>
-   <span data-ttu-id="da850-131">**[カテゴリ名]**: 既定のフィルターは **[すべて]** です。</span><span class="sxs-lookup"><span data-stu-id="da850-131">**Category name**: The default filter is **All**.</span></span> <span data-ttu-id="da850-132">特定の[レビュー インサイト カテゴリ](#review-insights-categories)を選ぶと、そのカテゴリに関連付けられているレビューのみを表示できます。</span><span class="sxs-lookup"><span data-stu-id="da850-132">You can choose a specific [review insights category](#review-insights-categories) to only show reviews that we’ve associated with that category.</span></span> 


> [!TIP]
> <span data-ttu-id="da850-133">このページにレビューが表示されない場合は、フィルターですべてのレビューを除外していないかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="da850-133">If you don't see any reviews on the page, check to make sure your filters haven't excluded all of your reviews.</span></span> <span data-ttu-id="da850-134">たとえば、アプリがサポートされていないターゲット OS でフィルター処理する場合、レビューは表示されません。</span><span class="sxs-lookup"><span data-stu-id="da850-134">For example, if you filter by a Target OS that your app doesn't support, you won't see any reviews.</span></span>


## <a name="ratings-breakdown"></a><span data-ttu-id="da850-135">評価の内訳</span><span class="sxs-lookup"><span data-stu-id="da850-135">Ratings breakdown</span></span>

<span data-ttu-id="da850-136">**[評価の内訳]** グラフには次のデータが表示されます。</span><span class="sxs-lookup"><span data-stu-id="da850-136">The **Ratings breakdown** chart shows:</span></span> 
- <span data-ttu-id="da850-137">アプリの平均の星評価。</span><span class="sxs-lookup"><span data-stu-id="da850-137">The average rating star rating for the app.</span></span>
- <span data-ttu-id="da850-138">過去 12 か月間のアプリの評価の合計数。</span><span class="sxs-lookup"><span data-stu-id="da850-138">The total number of ratings of your app over the past 12 months.</span></span>
- <span data-ttu-id="da850-139">各星評価の評価総数。</span><span class="sxs-lookup"><span data-stu-id="da850-139">The total number of ratings for each star rating.</span></span>
- <span data-ttu-id="da850-140">評価の種類 (新着または更新済み) 別に示した、星評価ごとの過去 12 か月間の評価の数。</span><span class="sxs-lookup"><span data-stu-id="da850-140">The number of ratings for each type of rating (new or revised) per star rating over the past 12 months.</span></span>
 - <span data-ttu-id="da850-141">**新しい評価**は、ユーザーが送信し、まったく変更していない評価です。</span><span class="sxs-lookup"><span data-stu-id="da850-141">**New ratings** are ratings that customers have submitted but haven't changed at all.</span></span>
 - <span data-ttu-id="da850-142">**更新済み評価**は、単にレビューのテキストを変更しただけであっても、何かしらユーザーによって変更されている評価です。</span><span class="sxs-lookup"><span data-stu-id="da850-142">**Revised ratings** are ratings that have been changed by the customer in any way, even just changing the text of the review.</span></span>

> [!TIP]
> <span data-ttu-id="da850-143">ストア内でユーザーに表示される平均評価では、ユーザーの市場とデバイスの種類が考慮されているため、このレポートに表示される内容と異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da850-143">The average rating that a customer sees in the Store takes into account the customer’s market and device type, so it may differ from what you see in this report.</span></span> <span data-ttu-id="da850-144">ストア内で特定のユーザーに対して平均評価がどのように表示されるかを確認するには、フィルターを適用して特定の市場とデバイスの種類を選びます。</span><span class="sxs-lookup"><span data-stu-id="da850-144">To see how the average rating will appear in the Store for a given customer, you’ll need to apply filters to select a specific market and device type.</span></span>


## <a name="average-rating-over-time"></a><span data-ttu-id="da850-145">長期的な平均評価</span><span class="sxs-lookup"><span data-stu-id="da850-145">Average rating over time</span></span>

<span data-ttu-id="da850-146">**[長期的な平均評価]** のグラフには、過去 12 か月間に、アプリの平均評価がどのように変化したかが示されます。</span><span class="sxs-lookup"><span data-stu-id="da850-146">The **Average rating over time** chart shows how the app's average rating has changed over the past 12 months.</span></span>

<span data-ttu-id="da850-147">**[長期的な平均評価]** グラフは、(**[評価の内訳]** グラフのように) 過去 12 か月間に残されたすべての評価の平均を計算するのではなく、特定の週にユーザーがどのようにアプリを評価したかを示します。</span><span class="sxs-lookup"><span data-stu-id="da850-147">Rather than calculating the average of all ratings left during the past 12 months (as in the **Ratings breakdown** chart), the **Average rating over time** chart shows you how customers rated the app on a given week.</span></span> <span data-ttu-id="da850-148">このグラフは、傾向を特定する、または更新プログラムまたはその他の要因によって評価が影響を受けたかどうかを判断する場合に参考にできます。</span><span class="sxs-lookup"><span data-stu-id="da850-148">This can help you identify trends or determine if ratings were affected by updates or other factors.</span></span>


## <a name="reviews"></a><span data-ttu-id="da850-149">レビュー</span><span class="sxs-lookup"><span data-stu-id="da850-149">Reviews</span></span>

<span data-ttu-id="da850-150">このページにはユーザーが残したレビューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="da850-150">Reviews left by your customers are shown on this page.</span></span>  

<span data-ttu-id="da850-151">各ユーザー レビューには、次の情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da850-151">Each customer review contains:</span></span>

-   <span data-ttu-id="da850-152">ユーザーが記入したタイトルとレビュー本文 </span><span class="sxs-lookup"><span data-stu-id="da850-152">The title and review text provided by the customer.</span></span> <span data-ttu-id="da850-153">(Windows Phone 8.1 およびそれ以前のユーザーによって作成されたレビューにはタイトルはありません)。</span><span class="sxs-lookup"><span data-stu-id="da850-153">(Reviews written by customers on Windows Phone 8.1 and earlier will not have a title.)</span></span>
-   <span data-ttu-id="da850-154">レビューの日付。</span><span class="sxs-lookup"><span data-stu-id="da850-154">The date of the review.</span></span>
-   <span data-ttu-id="da850-155">Windows ストアに表示されるレビューアーの名前。</span><span class="sxs-lookup"><span data-stu-id="da850-155">The name of the reviewer as it appears in the Windows Store.</span></span>
-   <span data-ttu-id="da850-156">レビューアーの国/地域。</span><span class="sxs-lookup"><span data-stu-id="da850-156">The reviewer's country/region.</span></span>
-   <span data-ttu-id="da850-157">レビューが残された時点でのユーザーのデバイス上のアプリのパッケージ バージョン </span><span class="sxs-lookup"><span data-stu-id="da850-157">The package version of the app on the customer's device at the time the review was left.</span></span> <span data-ttu-id="da850-158">(この情報はオンラインまたは Windows 8.1 およびそれ以前の顧客から送信されたレビューについては利用できません)。</span><span class="sxs-lookup"><span data-stu-id="da850-158">(This info is not available for reviews submitted online or submitted by customers on Windows 8.1 and earlier.)</span></span>
-   <span data-ttu-id="da850-159">レビューが残されたときにユーザーが使っていたデバイスの OS のバージョン。</span><span class="sxs-lookup"><span data-stu-id="da850-159">The OS version of the device which the customer was using when the review was left.</span></span>
-   <span data-ttu-id="da850-160">レビューが残されたときにユーザーが使っていたデバイスの名前 </span><span class="sxs-lookup"><span data-stu-id="da850-160">The name of the device which the customer was using when the review was left.</span></span> <span data-ttu-id="da850-161">(この情報はオンラインまたは Windows 8.1 およびそれ以前の顧客から送信されたレビューについては利用できません)。</span><span class="sxs-lookup"><span data-stu-id="da850-161">(This info is not available for reviews submitted online or submitted by customers on Windows 8.1 and earlier.)</span></span>
-   <span data-ttu-id="da850-162">他のユーザーがこのレビューを読んだ際に評価される、レビューの "役立ち度" も表示されます。</span><span class="sxs-lookup"><span data-stu-id="da850-162">The review's "usefulness count," as rated by other customers when reading that review.</span></span> <span data-ttu-id="da850-163">これらは、2 つの数字のセットで示されます。最初の数字はこのレビューが役に立ったと評価したユーザーの数、2 番目の数字はレビューを評価したユーザーの総数です。</span><span class="sxs-lookup"><span data-stu-id="da850-163">These are shown as a series of two numbers: the first number shows how many customers rated it as useful, and the second number is the total number of customers who rated the review.</span></span> <span data-ttu-id="da850-164">たとえば、役立ち度が "4/10" であった場合、10 人の評価者のうち 4 人はレビューが役立ったと評価し、6 人は役立ったとは評価していないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="da850-164">For example, a usefulness count of 4/10 means that out of 10 raters, 4 found the review useful and 6 did not.</span></span> <span data-ttu-id="da850-165">(レビューに対する役立ち度の評価がない場合、役立ち度は表示されません)。</span><span class="sxs-lookup"><span data-stu-id="da850-165">(If there are no usefulness votes for a review, no usefulness count is displayed.)</span></span>

<span data-ttu-id="da850-166">ユーザーはコメントを追加しなくてもアプリを評価できるため、通常は評価数よりもレビュー数が少なくなります。</span><span class="sxs-lookup"><span data-stu-id="da850-166">Note that customers can leave a rating for your app without adding any comments, so you will typically see fewer reviews than ratings.</span></span>

<span data-ttu-id="da850-167">このページのレビューは、日付や評価によって昇順または降順に並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="da850-167">You can sort the reviews on the page by date and/or by rating, in ascending or descending order.</span></span> <span data-ttu-id="da850-168">**[並べ替え]** リンクをクリックして、日付や評価で並べ替えるオプションを表示します。</span><span class="sxs-lookup"><span data-stu-id="da850-168">Click the **Sort by** link to view options to sort by Date and/or Rating.</span></span> 

> [!NOTE]
> <span data-ttu-id="da850-169">場合によっては、レビューがこのレポートに表示されなくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="da850-169">You may occasionally notice that reviews disappear from this report.</span></span> <span data-ttu-id="da850-170">原因としては、Windows 10 の特定のプレリリース版と Insider ビルドを実行しているお客様によって書き込まれたレビューが、Microsoft によってストアから削除されたことが考えられます。</span><span class="sxs-lookup"><span data-stu-id="da850-170">This can happen because Microsoft removes reviews from the Store that are written by customers running certain pre-release and Insider builds of Windows 10.</span></span> <span data-ttu-id="da850-171">これは、プレリリース版の Windows ビルドの問題が原因で発生した、否定的なレビューを削除する目的で行われるものです。</span><span class="sxs-lookup"><span data-stu-id="da850-171">We do this to reduce the possibility of a negative review that is caused by a problem in a pre-release Windows build.</span></span> <span data-ttu-id="da850-172">また、スパム、不適切、不快感を与えるなどのポリシー違反と見なされたレビューが、Microsoft によってストアから削除される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="da850-172">We may also remove reviews from the Store that have been identified as spam, inappropriate, offensive or have other policy violations.</span></span> <span data-ttu-id="da850-173">この操作は、カスタマー エクスペリエンスの改善になることを期待して行われています。</span><span class="sxs-lookup"><span data-stu-id="da850-173">We expect this action will result in a better customer experience.</span></span>


## <a name="translating-reviews"></a><span data-ttu-id="da850-174">レビューの翻訳</span><span class="sxs-lookup"><span data-stu-id="da850-174">Translating reviews</span></span>

<span data-ttu-id="da850-175">既定では、優先する言語で記述されていないレビューは翻訳されます。</span><span class="sxs-lookup"><span data-stu-id="da850-175">By default, reviews that were not written in your preferred language are translated for you.</span></span> <span data-ttu-id="da850-176">必要に応じて、レビューの一覧の右上にある **[レビューを翻訳する]** チェック ボックスをオフにして、レビューの翻訳を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="da850-176">If you prefer, review translation can be disabled by unchecking the **Translate reviews** checkbox at the upper right, above the list of reviews.</span></span>

<span data-ttu-id="da850-177">レビューは自動翻訳システムによって翻訳されるため、翻訳の結果が正確でない場合があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="da850-177">Please note that reviews are translated by an automatic translation system, and the resulting translation may not always be accurate.</span></span> <span data-ttu-id="da850-178">元のテキストと翻訳を比較する場合や、元のテキストを他の方法で翻訳する場合は、元のテキストが提供されます。</span><span class="sxs-lookup"><span data-stu-id="da850-178">The original text is provided if you wish to compare it to the translation, or translate it through some other means.</span></span>


## <a name="review-insight-categories"></a><span data-ttu-id="da850-179">レビュー インサイト カテゴリ</span><span class="sxs-lookup"><span data-stu-id="da850-179">Review insight categories</span></span>

<span data-ttu-id="da850-180">**レビュー インサイト カテゴリ**を使うと、特定のレビューに関連があると判断されたカテゴリに従ってグループ分けされたレビューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="da850-180">You can view **Review insight categories** to view your reviews grouped according to categories that we've determined may be associated with the review.</span></span>

> [!NOTE]
> <span data-ttu-id="da850-181">カテゴリ別にレビューを表示するときは、24 時間以内のレビューや英語以外の言語でのレビューは含まれません。</span><span class="sxs-lookup"><span data-stu-id="da850-181">Reviews less than 24 hours old and/or in a language other than English are not included when viewing reviews by categories.</span></span>

<span data-ttu-id="da850-182">ページ上部に、レビューのカテゴリ別に色分けされたブロックが表示されます。</span><span class="sxs-lookup"><span data-stu-id="da850-182">Near the top of the page you will see colored blocks representing reviews by category.</span></span> <span data-ttu-id="da850-183">カテゴリの 1 つを選ぶと、そのカテゴリに関連付けられているレビューのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="da850-183">Select one of these categories to view only reviews that we've associated with that category.</span></span> <span data-ttu-id="da850-184">[ページ フィルター](#apply-filters)を使って、カテゴリを基にフィルターを適用することもできます。</span><span class="sxs-lookup"><span data-stu-id="da850-184">You can also use the [page filters](#apply-filters) to filter by category.</span></span>

<span data-ttu-id="da850-185">カテゴリごとのレビュー数の内訳を確認するには、**[詳細の表示]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="da850-185">To see a breakdown of the number of reviews per category, select **Show details**.</span></span> 


## <a name="responding-to-customer-reviews"></a><span data-ttu-id="da850-186">顧客のレビューへの返信</span><span class="sxs-lookup"><span data-stu-id="da850-186">Responding to customer reviews</span></span>

<span data-ttu-id="da850-187">Windows ストア デベロッパー センター ダッシュボード、[Windows ストア レビュー API](../monetize/submit-responses-to-app-reviews.md)、または[デベロッパー センター アプリ](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws)を使って、お客様のレビューの多くに返信できます。</span><span class="sxs-lookup"><span data-stu-id="da850-187">You can use the Windows Store Dev Center dashboard, the [Windows Store reviews API](../monetize/submit-responses-to-app-reviews.md), or the [Dev Center app](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws) to send responses to many of your customers' reviews.</span></span> <span data-ttu-id="da850-188">詳しくは、「[顧客のレビューに返信する](respond-to-customer-reviews.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da850-188">For more info, see [Respond to customer reviews](respond-to-customer-reviews.md).</span></span>

<span data-ttu-id="da850-189">アプリについて確認した評価とレビューに基づいて検討できるその他の対応を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="da850-189">Here are some additional actions you may wish to consider, based on the ratings and reviews you're seeing.</span></span>

-   <span data-ttu-id="da850-190">機能の追加または変更を望む意見や、問題に関する不満の声が多数ある場合は、特定のフィードバックに対応した新しいバージョンのリリースを検討します </span><span class="sxs-lookup"><span data-stu-id="da850-190">If you notice many reviews that suggest a new or changed feature, or complain about a problem, consider releasing a new version that addresses the specific feedback.</span></span> <span data-ttu-id="da850-191">(その場合は、必ずアプリの[説明](create-app-descriptions.md)を更新して、問題が解決したことを示してください)。</span><span class="sxs-lookup"><span data-stu-id="da850-191">(Be sure to update your app's [description](create-app-descriptions.md) to indicate that the issue has been fixed.)</span></span>
-   <span data-ttu-id="da850-192">平均評価は高いが、ダウンロード数が少ない場合は、アプリを試した人には好評だったことを意味するため、[より多くの人にアプリについて知ってもらう](attract-customers-and-promote-your-apps.md)方法を検討します。</span><span class="sxs-lookup"><span data-stu-id="da850-192">If the average rating is high, but your number of downloads is low, you might want to look for ways to [expose your app to more people](attract-customers-and-promote-your-apps.md), since it's been well-received by those who have tried it out.</span></span>


 

 

 
