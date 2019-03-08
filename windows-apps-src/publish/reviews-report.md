---
Description: パートナー センターでレビュー レポートでは、ストアでアプリを評価する際に、お客様が入力されたレビュー (コメント) を表示できます。
title: レビュー レポート
ms.assetid: E50C3A4D-1D8A-4E5B-8182-3FAD049F2A2D
ms.date: 08/16/2018
ms.topic: article
keywords: windows 10、uwp、レビュー、コメント、レビュー担当者
ms.localizationpriority: medium
ms.openlocfilehash: 7ec883e7bcb98d69673b520df918e085182d35ec
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57621827"
---
# <a name="reviews-report"></a><span data-ttu-id="e6cb3-104">レビュー レポート</span><span class="sxs-lookup"><span data-stu-id="e6cb3-104">Reviews report</span></span>


<span data-ttu-id="e6cb3-105">**レビュー**レポート[パートナー センター](https://partner.microsoft.com/dashboard)できますが、ストアでアプリを評価する際に、お客様が入力されたレビュー (コメント) を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-105">The **Reviews** report in [Partner Center](https://partner.microsoft.com/dashboard) lets you see the reviews (comments) that customers entered when rating your app in the Store.</span></span>

<span data-ttu-id="e6cb3-106">パートナー センターでこのデータを表示または[レポートをダウンロード](download-analytic-reports.md)オフラインで表示します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-106">You can view this data in Partner Center, or [download the report](download-analytic-reports.md) to view offline.</span></span> <span data-ttu-id="e6cb3-107">使用してこのデータをプログラムで取得する代わりに、[取得アプリ レビュー](../monetize/get-app-reviews.md)メソッドで、 [Microsoft Store analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md)します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-107">Alternatively, you can programmatically retrieve this data by using the [get app reviews](../monetize/get-app-reviews.md) method in the [Microsoft Store analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

<span data-ttu-id="e6cb3-108">顧客のレビューに応答することもできます。[このページから直接](respond-to-customer-reviews.md)またはプログラムによって[Microsoft Store を使用してレビュー API](../monetize/submit-responses-to-app-reviews.md)します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-108">You can also respond to customer reviews [directly from this page](respond-to-customer-reviews.md) or programmatically [via the Microsoft Store reviews API](../monetize/submit-responses-to-app-reviews.md).</span></span>

> [!TIP]
> <span data-ttu-id="e6cb3-109">左側のナビゲーション メニューで **[Engage] (関心を引く)** を展開して **[レビューとフィードバック]** を選ぶと、自分のすべてのアプリの過去 30 日間のレビュー、評価、ユーザー フィードバックの概要を確認できます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-109">For a quick look at the reviews, ratings, and user feedback for all of your apps in the last 30 days, expand **Engage** in the left navigation menu and select **Reviews and feedback.**</span></span> 


## <a name="apply-filters"></a><span data-ttu-id="e6cb3-110">フィルターの適用</span><span class="sxs-lookup"><span data-stu-id="e6cb3-110">Apply filters</span></span>

<span data-ttu-id="e6cb3-111">ページの上部で、レビューを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-111">Near the top of the page, you can select the time period for which you want to show reviews.</span></span> <span data-ttu-id="e6cb3-112">既定では **[有効期間]** が選択されていますが、30 日間、3 カ月間、6 か月間、12 か月間のレビューや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-112">The default selection is **Lifetime**, but you can choose to show reviews for 30 days, 3 months, 6 months, or 12 months, or for a custom data range that you specify.</span></span>

<span data-ttu-id="e6cb3-113">**[フィルター]** を展開すると、次のオプションを使って、このページに表示するレビューをフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-113">You can expand **Filters** to filter the reviews shown on this page by the following options.</span></span> <span data-ttu-id="e6cb3-114">これらのフィルターは **[評価の内訳]** と **[長期的な平均評価]** のグラフには、適用されません。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-114">These filters will not apply to the **Ratings breakdown** and **Average rating over time** charts.</span></span>

-   <span data-ttu-id="e6cb3-115">**評価**:既定では、すべての星評価とレビューがチェックします、をチェックしてのみ特定の星評価に関連付けられているレビューを表示する場合は、(1 ~ 5 個の星) から特定の評価をオフにします。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-115">**Rating**: By default reviews with all star ratings are checked, but you can check and uncheck specific ratings (from 1 to 5 stars) if you want to only see reviews associated with particular star ratings.</span></span>
- <span data-ttu-id="e6cb3-116">**コンテンツをレビューして**:既定の設定は**規制とコンテンツをレビューして**、つまりの評価だけがコンテンツを確認することが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-116">**Review content**: The default setting is **Ratings with review content**, which means that only ratings with review content will be shown.</span></span> <span data-ttu-id="e6cb3-117">選択できる**すべて**テキストを確認して記述されたいずれかが含まれていないものもすべての評価を表示します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-117">You can select **All** to show all ratings, even those that don't include any written review text.</span></span> <span data-ttu-id="e6cb3-118">なお、**評価の内訳**グラフは、選択内容に関係なく、すべてのレビューに常に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-118">Note that the **Ratings breakdown** chart will always show all reviews, regardless of your selection.</span></span>
-   <span data-ttu-id="e6cb3-119">**OS バージョン**:既定の設定は**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-119">**OS version**: The default setting is **All**.</span></span> <span data-ttu-id="e6cb3-120">特定の OS バージョンを選ぶと、その OS バージョンを使っているユーザーによるレビューのみをこのページに表示できます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-120">You can choose a specific OS version if you want this page to only show reviews left by customers on that OS version.</span></span>
-   <span data-ttu-id="e6cb3-121">**パッケージ バージョン**:既定の設定は**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-121">**Package version**: The default setting is **All**.</span></span> <span data-ttu-id="e6cb3-122">アプリに複数のパッケージがある場合、ここで特定のパッケージを選ぶと、アプリのレビュー時にそのパッケージを持っていたユーザーによるレビューのみをこのページに表示できます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-122">If your app includes more than one package, you can choose a specific one here to only show reviews left by customers who had that package when they reviewed your app.</span></span>
-   <span data-ttu-id="e6cb3-123">**応答**:既定の設定は**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-123">**Responses**: The default setting is **All**.</span></span> <span data-ttu-id="e6cb3-124">レビューをフィルター処理して、[ユーザーに返信した](respond-to-customer-reviews.md)レビューのみ、または、まだ返信していないレビューのみを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-124">You can choose to filter the reviews to only show the reviews where you have [responded to customers](respond-to-customer-reviews.md), or only those where you have not yet responded.</span></span>
-   <span data-ttu-id="e6cb3-125">**更新プログラムの管理**:既定の設定は**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-125">**Updates**: The default setting is **All**.</span></span> <span data-ttu-id="e6cb3-126">レビューをフィルター処理して、[レビューへの返信](respond-to-customer-reviews.md)以降に、ユーザーによって更新されているレビューのみ、または、ユーザーによって更新されていないレビューのみを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-126">You can choose to filter the reviews to only show the reviews that have been updated by the customer since you [responded to a review](respond-to-customer-reviews.md), or only those which have not yet been updated by the customer.</span></span>
-   <span data-ttu-id="e6cb3-127">**市場**:既定の設定は**すべての市場**します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-127">**Market**: The default setting is **All markets**.</span></span> <span data-ttu-id="e6cb3-128">このページに特定の市場のユーザーからのレビューのみを表示する場合は、特定の市場を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-128">You can choose a specific market if you want this page to only show reviews from customers in that market.</span></span>
-   <span data-ttu-id="e6cb3-129">**デバイスの種類**:既定のフィルタは**すべてのデバイス**します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-129">**Device type**: The default filter is **All devices**.</span></span> <span data-ttu-id="e6cb3-130">このページにその種類のデバイスを使っているユーザーによるレビューのみを表示する場合は、特定のデバイスの種類を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-130">You can choose a specific device type if you want this page to only show reviews left by customers using that type of device.</span></span>
-   <span data-ttu-id="e6cb3-131">**カテゴリ名**:既定のフィルタは**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-131">**Category name**: The default filter is **All**.</span></span> <span data-ttu-id="e6cb3-132">特定のことができます[insight カテゴリを確認して](#review-insight-categories)のみレビューが表示カテゴリに関連付けています。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-132">You can choose a specific [review insight category](#review-insight-categories) to only show reviews that we’ve associated with that category.</span></span> 

> [!TIP]
> <span data-ttu-id="e6cb3-133">このページにレビューが表示されない場合は、フィルターですべてのレビューを除外していないかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-133">If you don't see any reviews on the page, check to make sure your filters haven't excluded all of your reviews.</span></span> <span data-ttu-id="e6cb3-134">たとえば、アプリがサポートされていないターゲット OS でフィルター処理する場合、レビューは表示されません。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-134">For example, if you filter by a Target OS that your app doesn't support, you won't see any reviews.</span></span>


## <a name="ratings-breakdown"></a><span data-ttu-id="e6cb3-135">評価の内訳</span><span class="sxs-lookup"><span data-stu-id="e6cb3-135">Ratings breakdown</span></span>

<span data-ttu-id="e6cb3-136">**評価の内訳**次の概要を取得するため、このレポートの上部にあるグラフが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-136">The **Ratings breakdown** chart appears at the top of this report so that you can get a quick look at the following:</span></span> 
- <span data-ttu-id="e6cb3-137">アプリの平均の星評価。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-137">The average rating star rating for the app.</span></span>
- <span data-ttu-id="e6cb3-138">過去 12 か月間のアプリの評価の合計数。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-138">The total number of ratings of your app over the past 12 months.</span></span>
- <span data-ttu-id="e6cb3-139">各星評価の評価総数。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-139">The total number of ratings for each star rating.</span></span>
- <span data-ttu-id="e6cb3-140">評価の種類 (新着または更新済み) 別に示した、星評価ごとの過去 12 か月間の評価の数。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-140">The number of ratings for each type of rating (new or revised) per star rating over the past 12 months.</span></span>
 - <span data-ttu-id="e6cb3-141">**新しい評価**は、ユーザーが送信し、まったく変更していない評価です。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-141">**New ratings** are ratings that customers have submitted but haven't changed at all.</span></span>
 - <span data-ttu-id="e6cb3-142">**更新済み評価**は、単にレビューのテキストを変更しただけであっても、何かしらユーザーによって変更されている評価です。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-142">**Revised ratings** are ratings that have been changed by the customer in any way, even just changing the text of the review.</span></span>

> [!TIP]
> <span data-ttu-id="e6cb3-143">ストア内でユーザーに表示される平均評価では、ユーザーの市場とデバイスの種類が考慮されているため、このレポートに表示される内容と異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-143">The average rating that a customer sees in the Store takes into account the customer’s market and device type, so it may differ from what you see in this report.</span></span>

<span data-ttu-id="e6cb3-144">このグラフ常に含まれているすべてのレビューには、選択した場合でも注**規制とコンテンツをレビューして**で、**コンテンツをレビューして**ページ フィルター。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-144">Note that this chart always includes all of your reviews, even if you selected **Ratings with review content** in the **Review content** page filter.</span></span>

<span data-ttu-id="e6cb3-145">このグラフにも表示されます、[評価レポート](ratings-report.md)、およびアプリの評価に関する詳細情報。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-145">This chart can also be seen in the [Ratings report](ratings-report.md), along with more details about your app's ratings.</span></span>


<span id = "review-insight-categories" />

## <a name="insight-categories"></a><span data-ttu-id="e6cb3-146">Insight カテゴリ</span><span class="sxs-lookup"><span data-stu-id="e6cb3-146">Insight categories</span></span>

<span data-ttu-id="e6cb3-147">**Insight カテゴリ**グラフが、レビューのレビューを関連付けることができますを特定のカテゴリに従ってグループ化します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-147">The **Insight categories** chart groups your reviews according to categories that we've determined may be associated with the review.</span></span>

> [!NOTE]
> <span data-ttu-id="e6cb3-148">カテゴリ別にレビューを表示するときは、24 時間以内のレビューや英語以外の言語でのレビューは含まれません。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-148">Reviews less than 24 hours old and/or in a language other than English are not included when viewing reviews by categories.</span></span>

<span data-ttu-id="e6cb3-149">ページ上部に、レビューのカテゴリ別に色分けされたブロックが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-149">Near the top of the page you will see colored blocks representing reviews by category.</span></span> <span data-ttu-id="e6cb3-150">カテゴリの 1 つを選ぶと、そのカテゴリに関連付けられているレビューのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-150">Select one of these categories to view only reviews that we've associated with that category.</span></span> <span data-ttu-id="e6cb3-151">[ページ フィルター](#apply-filters)を使って、カテゴリを基にフィルターを適用することもできます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-151">You can also use the [page filters](#apply-filters) to filter by category.</span></span>

<span data-ttu-id="e6cb3-152">カテゴリごとのレビュー数の内訳を確認するには、**[詳細の表示]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-152">To see a breakdown of the number of reviews per category, select **Show details**.</span></span> 


## <a name="reviews"></a><span data-ttu-id="e6cb3-153">レビュー</span><span class="sxs-lookup"><span data-stu-id="e6cb3-153">Reviews</span></span>

<span data-ttu-id="e6cb3-154">各ユーザー レビューには、次の情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-154">Each customer review contains:</span></span>

-   <span data-ttu-id="e6cb3-155">ユーザーが記入したタイトルとレビュー本文 </span><span class="sxs-lookup"><span data-stu-id="e6cb3-155">The title and review text provided by the customer.</span></span> <span data-ttu-id="e6cb3-156">(Windows Phone 8.1 およびそれ以前のユーザーによって作成されたレビューにはタイトルはありません)。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-156">(Reviews written by customers on Windows Phone 8.1 and earlier will not have a title.)</span></span>
-   <span data-ttu-id="e6cb3-157">レビューの日付。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-157">The date of the review.</span></span>
-   <span data-ttu-id="e6cb3-158">Microsoft Store として、レビュー担当者の名前が表示されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-158">The name of the reviewer as it appears in the Microsoft Store.</span></span>
-   <span data-ttu-id="e6cb3-159">レビューアーの国/地域。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-159">The reviewer's country/region.</span></span>
-   <span data-ttu-id="e6cb3-160">レビューが残された時点でのユーザーのデバイス上のアプリのパッケージ バージョン </span><span class="sxs-lookup"><span data-stu-id="e6cb3-160">The package version of the app on the customer's device at the time the review was left.</span></span> <span data-ttu-id="e6cb3-161">(この情報はオンラインで送信された、または Windows 8.1 以降の顧客が送信したレビューを使用できません) です。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-161">(This info is not available for reviews submitted online or submitted by customers on Windows 8.1 and earlier.)</span></span>
-   <span data-ttu-id="e6cb3-162">レビューが残されたときにユーザーが使っていたデバイスの OS のバージョン。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-162">The OS version of the device which the customer was using when the review was left.</span></span>
-   <span data-ttu-id="e6cb3-163">レビューが残されたときにユーザーが使っていたデバイスの名前 </span><span class="sxs-lookup"><span data-stu-id="e6cb3-163">The name of the device which the customer was using when the review was left.</span></span> <span data-ttu-id="e6cb3-164">(この情報はオンラインで送信された、または Windows 8.1 以降の顧客が送信したレビューを使用できません) です。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-164">(This info is not available for reviews submitted online or submitted by customers on Windows 8.1 and earlier.)</span></span>
-   <span data-ttu-id="e6cb3-165">他のユーザーがこのレビューを読んだ際に評価される、レビューの "役立ち度" も表示されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-165">The review's "usefulness count," as rated by other customers when reading that review.</span></span> <span data-ttu-id="e6cb3-166">これらは、2 つの数字のセットで示されます。最初の数字はこのレビューが役に立ったと評価したユーザーの数、2 番目の数字はレビューを評価したユーザーの総数です。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-166">These are shown as a series of two numbers: the first number shows how many customers rated it as useful, and the second number is the total number of customers who rated the review.</span></span> <span data-ttu-id="e6cb3-167">たとえば、役立ち度が "4/10" であった場合、10 人の評価者のうち 4 人はレビューが役立ったと評価し、6 人は役立ったとは評価していないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-167">For example, a usefulness count of 4/10 means that out of 10 raters, 4 found the review useful and 6 did not.</span></span> <span data-ttu-id="e6cb3-168">(レビューに対する役立ち度の評価がない場合、役立ち度は表示されません)。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-168">(If there are no usefulness votes for a review, no usefulness count is displayed.)</span></span>

<span data-ttu-id="e6cb3-169">ユーザーはコメントを追加しなくてもアプリを評価できるため、通常は評価数よりもレビュー数が少なくなります。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-169">Note that customers can leave a rating for your app without adding any comments, so you will typically see fewer reviews than ratings.</span></span>

<span data-ttu-id="e6cb3-170">このページのレビューは、日付や評価によって昇順または降順に並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-170">You can sort the reviews on the page by date and/or by rating, in ascending or descending order.</span></span> <span data-ttu-id="e6cb3-171">をクリックして、**並べ替える**を並べ替えるにはオプションを表示するリンク**日付**や**評価**します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-171">Click the **Sort by** link to view options to sort by **Date** and/or **Rating**.</span></span>

<span data-ttu-id="e6cb3-172">アプリのレビューで特定の単語や語句を検索する検索ボックスを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-172">You can also use the search box to search for specific words or phrases in your app's reviews.</span></span> <span data-ttu-id="e6cb3-173">レビューが別の言語で記述された場合でも、元のみが、顧客が書き込まれるテキストを確認することに注意してくださいが検索されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-173">Note that only the original review text written by the customer is searched, even if the review was written in a different language.</span></span> <span data-ttu-id="e6cb3-174">レビューの翻訳されたテキストは検索されません。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-174">Translated review text is not searched.</span></span>

> [!NOTE]
> <span data-ttu-id="e6cb3-175">場合によっては、レビューがこのレポートに表示されなくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-175">You may occasionally notice that reviews disappear from this report.</span></span> <span data-ttu-id="e6cb3-176">原因としては、Windows 10 の特定のプレリリース版と Insider ビルドを実行しているお客様によって書き込まれたレビューが、Microsoft によってストアから削除されたことが考えられます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-176">This can happen because Microsoft removes reviews from the Store that are written by customers running certain pre-release and Insider builds of Windows 10.</span></span> <span data-ttu-id="e6cb3-177">これは、プレリリース版の Windows ビルドの問題が原因で発生した、否定的なレビューを削除する目的で行われるものです。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-177">We do this to reduce the possibility of a negative review that is caused by a problem in a pre-release Windows build.</span></span> <span data-ttu-id="e6cb3-178">また、スパム、不適切、不快感を与えるなどのポリシー違反と見なされたレビューが、Microsoft によってストアから削除される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-178">We may also remove reviews from the Store that have been identified as spam, inappropriate, offensive or have other policy violations.</span></span> <span data-ttu-id="e6cb3-179">この操作は、カスタマー エクスペリエンスの改善になることを期待して行われています。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-179">We expect this action will result in a better customer experience.</span></span>


## <a name="translating-reviews"></a><span data-ttu-id="e6cb3-180">レビューの翻訳</span><span class="sxs-lookup"><span data-stu-id="e6cb3-180">Translating reviews</span></span>

<span data-ttu-id="e6cb3-181">既定では、優先する言語で記述されていないレビューは翻訳されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-181">By default, reviews that were not written in your preferred language are translated for you.</span></span> <span data-ttu-id="e6cb3-182">必要に応じて、レビューの一覧の右上にある **[レビューを翻訳する]** チェック ボックスをオフにして、レビューの翻訳を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-182">If you prefer, review translation can be disabled by unchecking the **Translate reviews** checkbox at the upper right, above the list of reviews.</span></span>

<span data-ttu-id="e6cb3-183">レビューは自動翻訳システムによって翻訳されるため、翻訳の結果が正確でない場合があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-183">Please note that reviews are translated by an automatic translation system, and the resulting translation may not always be accurate.</span></span> <span data-ttu-id="e6cb3-184">元のテキストと翻訳を比較する場合や、元のテキストを他の方法で翻訳する場合は、元のテキストが提供されます。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-184">The original text is provided if you wish to compare it to the translation, or translate it through some other means.</span></span>

<span data-ttu-id="e6cb3-185">前述のように、ときに、レビューを検索するには、左、顧客が元のテキストのみが検索されます (しなく翻訳テキスト) がある場合でも、**レビューを変換**ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-185">As noted above, when searching your reviews, only the original text left by the customer is searched (and not any translated text), even if you have the **Translate reviews** box checked.</span></span>


## <a name="responding-to-customer-reviews"></a><span data-ttu-id="e6cb3-186">顧客のレビューへの返信</span><span class="sxs-lookup"><span data-stu-id="e6cb3-186">Responding to customer reviews</span></span>

<span data-ttu-id="e6cb3-187">使用することができます[パートナー センター](https://partner.microsoft.com/dashboard)または[Microsoft Store のレビュー API](../monetize/submit-responses-to-app-reviews.md)多くの顧客のレビューに応答を送信します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-187">You can use [Partner Center](https://partner.microsoft.com/dashboard) or the [Microsoft Store reviews API](../monetize/submit-responses-to-app-reviews.md) to send responses to many of your customers' reviews.</span></span> <span data-ttu-id="e6cb3-188">詳しくは、「[顧客のレビューに返信する](respond-to-customer-reviews.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-188">For more info, see [Respond to customer reviews](respond-to-customer-reviews.md).</span></span>

<span data-ttu-id="e6cb3-189">アプリについて確認した評価とレビューに基づいて検討できるその他の対応を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-189">Here are some additional actions you may wish to consider, based on the ratings and reviews you're seeing.</span></span>

-   <span data-ttu-id="e6cb3-190">機能の追加または変更を望む意見や、問題に関する不満の声が多数ある場合は、特定のフィードバックに対応した新しいバージョンのリリースを検討します </span><span class="sxs-lookup"><span data-stu-id="e6cb3-190">If you notice many reviews that suggest a new or changed feature, or complain about a problem, consider releasing a new version that addresses the specific feedback.</span></span> <span data-ttu-id="e6cb3-191">(その場合は、必ずアプリの[説明](create-app-descriptions.md)を更新して、問題が解決したことを示してください)。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-191">(Be sure to update your app's [description](create-app-descriptions.md) to indicate that the issue has been fixed.)</span></span>
-   <span data-ttu-id="e6cb3-192">平均評価は高いが、ダウンロード数が少ない場合は、アプリを試した人には好評だったことを意味するため、[より多くの人にアプリについて知ってもらう](attract-customers-and-promote-your-apps.md)方法を検討します。</span><span class="sxs-lookup"><span data-stu-id="e6cb3-192">If the average rating is high, but your number of downloads is low, you might want to look for ways to [expose your app to more people](attract-customers-and-promote-your-apps.md), since it's been well-received by those who have tried it out.</span></span>


 

 

 
