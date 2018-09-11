---
author: jnHs
Description: The Add-on acquisitions report in the Windows Dev Center dashboard lets you see how many add-ons you've sold, along with demographic and platform details.
title: '[アドオン取得] レポート'
ms.assetid: F2DF9188-0A98-4AC3-81C0-3E2C37B15582
ms.author: wdg-dev-content
ms.date: 05/24/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アドオン販売, アドオン取得, IAP 売り上げ, アプリ内製品, iap, アドオン
ms.localizationpriority: medium
ms.openlocfilehash: 019bb410e6ac65f9951f06052c78f40e9a5f32e2
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3847736"
---
# <a name="add-on-acquisitions-report"></a><span data-ttu-id="f5205-103">アドオン取得レポート</span><span class="sxs-lookup"><span data-stu-id="f5205-103">Add-on acquisitions report</span></span>


<span data-ttu-id="f5205-104">Windows デベロッパー センター ダッシュ ボードで**アドオン取得]** レポートでは、人口統計データと共に、販売したアドオンの数を確認できます。 プラットフォームの詳細、および Windows 10 (Xbox を含む) のユーザーのコンバージョン情報を示しています。</span><span class="sxs-lookup"><span data-stu-id="f5205-104">The **Add-on acquisitions** report in the Windows Dev Center dashboard lets you see how many add-ons you've sold, along with demographic and platform details, and shows conversion info for customers on Windows 10 (including Xbox).</span></span> <span data-ttu-id="f5205-105">最後の時間、または 70-2 時間の期間のリアルタイムの入手データの近く表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5205-105">You can also view near real-time acquisition data for the last hour or seventy-two hour period.</span></span>

<span data-ttu-id="f5205-106">このデータは、ダッシュボードで表示することも、[レポートをダウンロード](download-analytic-reports.md) してオフラインで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5205-106">You can view this data in your dashboard, or [download the report](download-analytic-reports.md) to view offline.</span></span> <span data-ttu-id="f5205-107">または、[Microsoft Store 分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[アドオンの入手数の取得](../monetize/get-in-app-acquisitions.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f5205-107">Alternatively, you can programmatically retrieve this data by using the [get add-on acquisitions](../monetize/get-in-app-acquisitions.md) method in the [Microsoft Store analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

<span data-ttu-id="f5205-108">このレポートで、アドオン取得とは、ユーザーが開発者からアドオンを購入 (または、無料で提供している場合は、支払いなしでアドオンを獲得) したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="f5205-108">In this report, an add-on acquisition means a customer has purchased an add-on from you (or acquired it without paying, if you offered it for free).</span></span> <span data-ttu-id="f5205-109">同じユーザーが同じコンシューマブルなアドオンを複数回購入した場合は、個別のアドオン取得としてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="f5205-109">Multiple purchases of the same consumable add-on by the same customer are counted as separate add-on acquisitions.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f5205-110">**[アドオン取得]** レポートには、払戻し、取り消し、支払取り消しなどのデータは含まれません。アプリの収益を見積もるには、「[支払いの要約](payout-summary.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5205-110">The **Add-on acquisitions** report does not include data about refunds, reversals, chargebacks, etc. To estimate your app proceeds, visit [Payout summary](payout-summary.md).</span></span> <span data-ttu-id="f5205-111">次に、**[予約済み]** セクションで、**予約済みのトランザクションをダウンロード**するためのリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="f5205-111">In the **Reserved** section, click the **Download reserved transactions** link.</span></span>


## <a name="apply-filters"></a><span data-ttu-id="f5205-112">フィルターを適用</span><span class="sxs-lookup"><span data-stu-id="f5205-112">Apply filters</span></span>

<span data-ttu-id="f5205-113">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="f5205-113">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="f5205-114">既定では **[30 日間]** が選択されていますが、3、6、12 か月間のデータや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5205-114">The default selection is **30D** (30 days), but you can choose to show data for 3, 6, or 12 months, or for a custom data range that you specify.</span></span> <span data-ttu-id="f5205-115">1 時間、または 70-2 時間をほぼリアルタイムでの入手データを表示するには、 **1 H**または**72 H**を選択することもできます。これらの期間は、**アドオンの入手数**グラフの**アドオンを毎日**タブと**市場**グラフの**取得**] タブにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="f5205-115">You can also select **1H** or **72H** to show acquisition data in near real time for either one hour or seventy-two hours; these time periods only apply to the **Add-on daily** tab of the **Add-on acquisitions** chart and to the **Acquisitions** tab of the **Markets** chart.</span></span> 

<span data-ttu-id="f5205-116">このページにある **[フィルター]** を展開して、このページのすべてのデータを特定のアドオン、および市場やデバイスの種類を基にフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="f5205-116">You can also expand **Filters** to filter all of the data on this page by particular add-on(s), by market and/or by device type.</span></span>

-   <span data-ttu-id="f5205-117">**[アドオン]**: 既定のフィルターは **[すべてのアドオン]** ですが、特定の 1 つまたは複数のアプリのアドオンのデータのみを抽出することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5205-117">**Add-on**: The default filter is **All add-ons**, but you can limit the data to one or more of the app's add-ons.</span></span>
-   <span data-ttu-id="f5205-118">**[マーケット]**: 既定のフィルターは **[すべてのマーケット]** ですが、特定の 1 つまたは複数のマーケットの取得データのみを抽出することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5205-118">**Market**: The default filter is **All markets**, but you can limit the data to acquisitions in one or more markets.</span></span>
-   <span data-ttu-id="f5205-119">**[デバイスの種類]**: 既定の設定は **[すべてのデバイス]** です。</span><span class="sxs-lookup"><span data-stu-id="f5205-119">**Device type**: The default setting is **All devices**.</span></span> <span data-ttu-id="f5205-120">特定のデバイスの種類 (PC、コンソール、タブレットなど) についてのみ取得データを表示するには、ここでそのデバイスの種類を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="f5205-120">If you want to show data for acquisitions from a certain device type only (such as PC, console, or tablet), you can choose a specific one here.</span></span>

<span data-ttu-id="f5205-121">以下のすべてのグラフで、指定した期間とフィルターに応じた情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="f5205-121">The info in all of the charts listed below will reflect the date range and any filters you've selected.</span></span> <span data-ttu-id="f5205-122">セクションの中には、追加のフィルターを適用できるものもあります。</span><span class="sxs-lookup"><span data-stu-id="f5205-122">Some sections also allow you to apply additional filters.</span></span>


## <a name="add-on-acquisitions"></a><span data-ttu-id="f5205-123">アドオン取得</span><span class="sxs-lookup"><span data-stu-id="f5205-123">Add-on acquisitions</span></span>

<span data-ttu-id="f5205-124">**[アドオン取得]** グラフには、選んだ期間中の日ごとまたは週ごとのアドオン取得数が示されます </span><span class="sxs-lookup"><span data-stu-id="f5205-124">The **Add-on acquisitions** chart shows the number of daily or weekly acquisitions of your add-ons over the selected period of time.</span></span> <span data-ttu-id="f5205-125">(**[フィルターを適用]** を使ってより長期間のデータを表示する場合、取得のデータは週単位でグループ化されます)。</span><span class="sxs-lookup"><span data-stu-id="f5205-125">(When you use **Apply filters** to show data for a longer duration, the acquisition data will be grouped by week.)</span></span>

<span data-ttu-id="f5205-126">**[アドオンの累計]** を選ぶと、アプリの有効期間内の取得数を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5205-126">You can also see the lifetime number of acquisitions for your app by selecting **Add-on cumulative**.</span></span> <span data-ttu-id="f5205-127">この値は、アプリが初めて公開されたときからの全取得数の累計です。</span><span class="sxs-lookup"><span data-stu-id="f5205-127">This shows the cumulative total of all acquisitions, starting from when your app was first published.</span></span>

<span data-ttu-id="f5205-128">または、アドオンの取得経路 (ストア クライアントまたは Web ストア) や OS のバージョンによって、結果をフィルター処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5205-128">You can optionally filter the results by whether the add-on acquisition originated from the client or web-based Store and/or by OS version.</span></span>


## <a name="customer-demographic"></a><span data-ttu-id="f5205-129">ユーザーの統計データ</span><span class="sxs-lookup"><span data-stu-id="f5205-129">Customer demographic</span></span>

<span data-ttu-id="f5205-130">**[ユーザーの統計データ]** のグラフには、アドオンを取得したユーザーに関する人口統計情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="f5205-130">The **Customer demographic** chart shows demographic info about the people who acquired your add-ons.</span></span> <span data-ttu-id="f5205-131">特定の年齢グループや性別のユーザーによる (選んだ期間中の) 取得の数を確認できます。</span><span class="sxs-lookup"><span data-stu-id="f5205-131">You can see how many acquisitions (over the selected period of time) were made by people in a certain age group and by which gender.</span></span>

> [!NOTE]
> <span data-ttu-id="f5205-132">ユーザーによっては、この情報を共有することを選んでいない場合があります。</span><span class="sxs-lookup"><span data-stu-id="f5205-132">Some customers have opted not to share this info.</span></span> <span data-ttu-id="f5205-133">年齢グループや性別を特定できない場合、その取得は**不明**として分類されます。</span><span class="sxs-lookup"><span data-stu-id="f5205-133">If we were unable to determine the age group or gender, the acquisition is categorized as **Unknown**.</span></span>


## <a name="markets"></a><span data-ttu-id="f5205-134">市場</span><span class="sxs-lookup"><span data-stu-id="f5205-134">Markets</span></span>

<span data-ttu-id="f5205-135">**[市場]** グラフには、指定した期間でのアドオンの取得数の合計が、アプリを提供している市場ごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="f5205-135">The **Markets** chart shows the total number of add-on acquisitions over the selected period of time for each market in which your app is available.</span></span> 

<span data-ttu-id="f5205-136">このデータは**マップ** フォームで視覚化して表示することも、設定を切り替えて**テーブル** フォームで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5205-136">You can view this data in a visual **Map** form, or toggle the setting to view it in **Table** form.</span></span> <span data-ttu-id="f5205-137">テーブル フォームでは一度に 5 つの市場を表示でき、アルファベット順か、取得数またはインストール数の多い順か少ない順で並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="f5205-137">Table form will show five markets at a time, sorted either alphabetically or by highest/lowest number of acquisitions or installs.</span></span> <span data-ttu-id="f5205-138">また、データをダウンロードして、すべての市場の情報をまとめて閲覧することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5205-138">You can also download the data to view info for all markets together.</span></span>


## <a name="add-on-page-views-and-conversions-by-campaign-id"></a><span data-ttu-id="f5205-139">キャンペーン ID ごとのアドオン ページ ビューとコンバージョン</span><span class="sxs-lookup"><span data-stu-id="f5205-139">Add-on page views and conversions by campaign ID</span></span>

<span data-ttu-id="f5205-140">**[キャンペーン ID ごとのアドオン ページ ビューとコンバージョン]** グラフには、指定した期間でのキャンペーン ID ごとのアドオンのコンバージョン数 (取得数) が示され、[カスタム プロモーション キャンペーン](create-a-custom-app-promotion-campaign.md)ごとの Windows 10 ユーザー (Xbox ユーザーを含む) のコンバージョン数とページ ビュー数を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="f5205-140">The **Add-on page views and conversions by campaign ID** chart shows you the total number of add-on conversions (acquisitions) per campaign ID over the selected period of time, helping you track conversions and page views from customers on Windows 10 (including Xbox) for each of your [custom promotion campaigns](create-a-custom-app-promotion-campaign.md).</span></span> <span data-ttu-id="f5205-141">このグラフに表示されるのは、アドオンのコンバージョン数のみです。</span><span class="sxs-lookup"><span data-stu-id="f5205-141">Only add-on conversions are shown in this chart.</span></span>

> [!NOTE]
> <span data-ttu-id="f5205-142">ユーザーは、アプリの作成者が作成したものではないカスタム キャンペーンをクリックして、アプリの登録情報に到達する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f5205-142">Customers could arrive at your app's listing by clicking on a custom campaign not created by you.</span></span> <span data-ttu-id="f5205-143">Microsoft では、セッション内のすべてのページ ビューに、ユーザーが初めてストアに到達したときの経路となったキャンペーン ID を記録しています。</span><span class="sxs-lookup"><span data-stu-id="f5205-143">We stamp every page view within a session with the campaign ID from which the customer first entered the Store.</span></span> <span data-ttu-id="f5205-144">その後、24 時間以内に発生したアプリの取得についてはすべて、そのキャンペーン ID にコンバージョンが関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="f5205-144">We then attribute conversions to that campaign ID for all acquisitions within 24 hours.</span></span> <span data-ttu-id="f5205-145">合計コンバージョン数の方がキャンペーン ID のコンバージョン数の合計よりも多い場合や、ページビューがゼロであるコンバージョンやアドオンのコンバージョンがレポートされることがあるのはこのためです。</span><span class="sxs-lookup"><span data-stu-id="f5205-145">Because of this, you may see a higher number of total conversions than the total conversions for your campaign IDs, and you may have conversions or add-on conversions that have zero page views.</span></span> 


## <a name="conversions-breakdown-by-campaign-id"></a><span data-ttu-id="f5205-146">キャンペーン ID ごとのコンバージョンの内訳</span><span class="sxs-lookup"><span data-stu-id="f5205-146">Conversions breakdown by campaign ID</span></span>

<span data-ttu-id="f5205-147">**[キャンペーン ID ごとのコンバージョンの内訳]** グラフでは、[カスタム プロモーション キャンペーン](create-a-custom-app-promotion-campaign.md)ごとに Windows 10 ユーザーのコンバージョン数とページ ビュー数を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="f5205-147">The **Conversions breakdown by campaign ID** chart lets you track conversions and page views from customers on Windows 10 for each of your [custom promotion campaigns](create-a-custom-app-promotion-campaign.md).</span></span> <span data-ttu-id="f5205-148">アプリとアドオンのコンバージョン数が、キャンペーン ID ごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="f5205-148">Both app and add-on conversions are shown per campaign ID.</span></span>

<span data-ttu-id="f5205-149">このグラフでは、*ページ ビュー*は、アプリのストア登録情報をユーザーが閲覧したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="f5205-149">In this chart, a *page view* means that a customer viewed the app's Store listing.</span></span> <span data-ttu-id="f5205-150">*コンバージョン*は、ユーザーがアプリまたはアドオンのライセンス (有料の場合も無料の場合も含む) を新しく取得したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="f5205-150">A *conversion* means that a customer has newly obtained a license for the app or add-on (whether you charged money or you've offered it for free).</span></span>

<span data-ttu-id="f5205-151">これらのページ ビューとコンバージョンの数値は、ユニーク ユーザー数ではないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f5205-151">Keep in mind that these page views and conversion numbers are not counts of unique customers.</span></span> 


## <a name="top-add-ons"></a><span data-ttu-id="f5205-152">トップ アドオン</span><span class="sxs-lookup"><span data-stu-id="f5205-152">Top add-ons</span></span>

<span data-ttu-id="f5205-153">**[トップ アドオン]** のグラフには、指定した期間での各アドオンの合計取得数が示されるので、どのアドオンが最も人気があるかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="f5205-153">The **Top add-ons** chart shows the total number of acquisitions for each of your add-ons over the selected period of time, so you can see which of your add-ons are the most popular.</span></span> 



 

 
