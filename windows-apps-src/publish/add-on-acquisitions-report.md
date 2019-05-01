---
Description: パートナー センターでアドオン買収レポートでは、人口統計と、販売した数のアドオンを表示できます。 プラットフォームの詳細とします。
title: アドオン取得レポート
ms.assetid: F2DF9188-0A98-4AC3-81C0-3E2C37B15582
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, アドオン販売, アドオン取得, IAP 売り上げ, アプリ内製品, iap, アドオン
ms.localizationpriority: medium
ms.openlocfilehash: 7996761076d7d913ad73f0d7e050c69f9b64084d
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63777864"
---
# <a name="add-on-acquisitions-report"></a><span data-ttu-id="7a47a-104">アドオン取得レポート</span><span class="sxs-lookup"><span data-stu-id="7a47a-104">Add-on acquisitions report</span></span>


<span data-ttu-id="7a47a-105">**アドオン買収**レポート[パートナー センター](https://partner.microsoft.com/dashboard)人口統計と、販売した数のアドオンを表示することができますプラットフォームの詳細、および Windows 10 (お客様の変換情報を示していますXbox を含む)。</span><span class="sxs-lookup"><span data-stu-id="7a47a-105">The **Add-on acquisitions** report in [Partner Center](https://partner.microsoft.com/dashboard) lets you see how many add-ons you've sold, along with demographic and platform details, and shows conversion info for customers on Windows 10 (including Xbox).</span></span> <span data-ttu-id="7a47a-106">最後の時間または足す 2 時間の期間をほぼリアルタイムの取得のデータ表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-106">You can also view near real-time acquisition data for the last hour or seventy-two hour period.</span></span>

<span data-ttu-id="7a47a-107">パートナー センターでこのデータを表示または[レポートをダウンロード](download-analytic-reports.md)オフラインで表示します。</span><span class="sxs-lookup"><span data-stu-id="7a47a-107">You can view this data in Partner Center, or [download the report](download-analytic-reports.md) to view offline.</span></span> <span data-ttu-id="7a47a-108">または、[Microsoft Store 分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[アドオンの入手数の取得](../monetize/get-in-app-acquisitions.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-108">Alternatively, you can programmatically retrieve this data by using the [get add-on acquisitions](../monetize/get-in-app-acquisitions.md) method in the [Microsoft Store analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

<span data-ttu-id="7a47a-109">このレポートで、アドオン取得とは、ユーザーが開発者からアドオンを購入 (または、無料で提供している場合は、支払いなしでアドオンを獲得) したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="7a47a-109">In this report, an add-on acquisition means a customer has purchased an add-on from you (or acquired it without paying, if you offered it for free).</span></span> <span data-ttu-id="7a47a-110">同じユーザーが同じコンシューマブルなアドオンを複数回購入した場合は、個別のアドオン取得としてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-110">Multiple purchases of the same consumable add-on by the same customer are counted as separate add-on acquisitions.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="7a47a-111">**アドオン買収**レポートでは、返金、取消、配賦などに関するデータは含まれません。アプリの収益を見積もるを参照してください。[入金](payout-summary.md)します。</span><span class="sxs-lookup"><span data-stu-id="7a47a-111">The **Add-on acquisitions** report does not include data about refunds, reversals, chargebacks, etc. To estimate your app proceeds, visit [Payout summary](payout-summary.md).</span></span> <span data-ttu-id="7a47a-112">次に、**[予約済み]** セクションで、**予約済みのトランザクションをダウンロード**するためのリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a47a-112">In the **Reserved** section, click the **Download reserved transactions** link.</span></span>


## <a name="apply-filters"></a><span data-ttu-id="7a47a-113">フィルターの適用</span><span class="sxs-lookup"><span data-stu-id="7a47a-113">Apply filters</span></span>

<span data-ttu-id="7a47a-114">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-114">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="7a47a-115">既定では **[30 日間]** が選択されていますが、3、6、12 か月間のデータや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-115">The default selection is **30D** (30 days), but you can choose to show data for 3, 6, or 12 months, or for a custom data range that you specify.</span></span> <span data-ttu-id="7a47a-116">選択することも**1 H**または**72 H**ほぼリアルタイムで取得データを表示するいずれか 1 つの 1 時間または足す 2 時間ですこれらの期間にのみ適用されます、**アドオン毎日** タブ。**アドオン買収**グラフと、**買収**のタブ、**市場**グラフ。</span><span class="sxs-lookup"><span data-stu-id="7a47a-116">You can also select **1H** or **72H** to show acquisition data in near real time for either one hour or seventy-two hours; these time periods only apply to the **Add-on daily** tab of the **Add-on acquisitions** chart and to the **Acquisitions** tab of the **Markets** chart.</span></span> 

<span data-ttu-id="7a47a-117">このページにある **[フィルター]** を展開して、このページのすべてのデータを特定のアドオン、および市場やデバイスの種類を基にフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-117">You can also expand **Filters** to filter all of the data on this page by particular add-on(s), by market and/or by device type.</span></span>

-   <span data-ttu-id="7a47a-118">**アドオン**:既定のフィルター**アドオンはすべて**アプリのアドオンの 1 つ以上のデータを制限できます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-118">**Add-on**: The default filter is **All add-ons**, but you can limit the data to one or more of the app's add-ons.</span></span>
-   <span data-ttu-id="7a47a-119">**市場**:既定のフィルタは**すべての市場**、1 つまたは複数の市場で取得するデータを制限できます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-119">**Market**: The default filter is **All markets**, but you can limit the data to acquisitions in one or more markets.</span></span>
-   <span data-ttu-id="7a47a-120">**デバイスの種類**:既定の設定は**すべてのデバイス**します。</span><span class="sxs-lookup"><span data-stu-id="7a47a-120">**Device type**: The default setting is **All devices**.</span></span> <span data-ttu-id="7a47a-121">特定のデバイスの種類 (PC、コンソール、タブレットなど) についてのみ取得データを表示するには、ここでそのデバイスの種類を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-121">If you want to show data for acquisitions from a certain device type only (such as PC, console, or tablet), you can choose a specific one here.</span></span>

<span data-ttu-id="7a47a-122">以下のすべてのグラフで、指定した期間とフィルターに応じた情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-122">The info in all of the charts listed below will reflect the date range and any filters you've selected.</span></span> <span data-ttu-id="7a47a-123">セクションの中には、追加のフィルターを適用できるものもあります。</span><span class="sxs-lookup"><span data-stu-id="7a47a-123">Some sections also allow you to apply additional filters.</span></span>


## <a name="add-on-acquisitions"></a><span data-ttu-id="7a47a-124">アドオン取得</span><span class="sxs-lookup"><span data-stu-id="7a47a-124">Add-on acquisitions</span></span>

<span data-ttu-id="7a47a-125">**[アドオン取得]** のグラフには、選んだ期間中の日ごとまたは週ごとのアドオン取得数が示されます </span><span class="sxs-lookup"><span data-stu-id="7a47a-125">The **Add-on acquisitions** chart shows the number of daily or weekly acquisitions of your add-ons over the selected period of time.</span></span> <span data-ttu-id="7a47a-126">(**[フィルターを適用]** を使ってより長期間のデータを表示する場合、取得のデータは週単位でグループ化されます)。</span><span class="sxs-lookup"><span data-stu-id="7a47a-126">(When you use **Apply filters** to show data for a longer duration, the acquisition data will be grouped by week.)</span></span>

<span data-ttu-id="7a47a-127">**[アドオンの累計]** を選ぶと、アプリの有効期間内の取得数を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-127">You can also see the lifetime number of acquisitions for your app by selecting **Add-on cumulative**.</span></span> <span data-ttu-id="7a47a-128">この値は、アプリが初めて公開されたときからの全取得数の累計です。</span><span class="sxs-lookup"><span data-stu-id="7a47a-128">This shows the cumulative total of all acquisitions, starting from when your app was first published.</span></span>

<span data-ttu-id="7a47a-129">または、アドオンの取得経路 (ストア クライアントまたは Web ストア) や OS のバージョンによって、結果をフィルター処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-129">You can optionally filter the results by whether the add-on acquisition originated from the client or web-based Store and/or by OS version.</span></span>


## <a name="customer-demographic"></a><span data-ttu-id="7a47a-130">ユーザーの統計データ</span><span class="sxs-lookup"><span data-stu-id="7a47a-130">Customer demographic</span></span>

<span data-ttu-id="7a47a-131">**[ユーザーの統計データ]** のグラフには、アドオンを取得したユーザーに関する人口統計情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-131">The **Customer demographic** chart shows demographic info about the people who acquired your add-ons.</span></span> <span data-ttu-id="7a47a-132">特定の年齢グループや性別のユーザーによる (選んだ期間中の) 取得の数を確認できます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-132">You can see how many acquisitions (over the selected period of time) were made by people in a certain age group and by which gender.</span></span>

> [!NOTE]
> <span data-ttu-id="7a47a-133">ユーザーによっては、この情報を共有することを選んでいない場合があります。</span><span class="sxs-lookup"><span data-stu-id="7a47a-133">Some customers have opted not to share this info.</span></span> <span data-ttu-id="7a47a-134">年齢グループや性別を特定できない場合、その取得は**不明**として分類されます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-134">If we were unable to determine the age group or gender, the acquisition is categorized as **Unknown**.</span></span>


## <a name="markets"></a><span data-ttu-id="7a47a-135">市場</span><span class="sxs-lookup"><span data-stu-id="7a47a-135">Markets</span></span>

<span data-ttu-id="7a47a-136">**[市場]** グラフには、指定した期間でのアドオンの取得数の合計が、アプリを提供している市場ごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-136">The **Markets** chart shows the total number of add-on acquisitions over the selected period of time for each market in which your app is available.</span></span> 

<span data-ttu-id="7a47a-137">このデータは**マップ** フォームで視覚化して表示することも、設定を切り替えて**テーブル** フォームで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-137">You can view this data in a visual **Map** form, or toggle the setting to view it in **Table** form.</span></span> <span data-ttu-id="7a47a-138">テーブル フォームでは一度に 5 つの市場を表示でき、アルファベット順か、取得数またはインストール数の多い順か少ない順で並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-138">Table form will show five markets at a time, sorted either alphabetically or by highest/lowest number of acquisitions or installs.</span></span> <span data-ttu-id="7a47a-139">また、データをダウンロードして、すべての市場の情報をまとめて閲覧することもできます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-139">You can also download the data to view info for all markets together.</span></span>


## <a name="add-on-page-views-and-conversions-by-campaign-id"></a><span data-ttu-id="7a47a-140">キャンペーン ID ごとのアドオン ページ ビューとコンバージョン</span><span class="sxs-lookup"><span data-stu-id="7a47a-140">Add-on page views and conversions by campaign ID</span></span>

<span data-ttu-id="7a47a-141">**[キャンペーン ID ごとのアドオン ページ ビューとコンバージョン]** グラフには、指定した期間でのキャンペーン ID ごとのアドオンのコンバージョン数 (取得数) が示され、[カスタム プロモーション キャンペーン](create-a-custom-app-promotion-campaign.md)ごとの Windows 10 ユーザー (Xbox ユーザーを含む) のコンバージョン数とページ ビュー数を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-141">The **Add-on page views and conversions by campaign ID** chart shows you the total number of add-on conversions (acquisitions) per campaign ID over the selected period of time, helping you track conversions and page views from customers on Windows 10 (including Xbox) for each of your [custom promotion campaigns](create-a-custom-app-promotion-campaign.md).</span></span> <span data-ttu-id="7a47a-142">このグラフに表示されるのは、アドオンのコンバージョン数のみです。</span><span class="sxs-lookup"><span data-stu-id="7a47a-142">Only add-on conversions are shown in this chart.</span></span>

> [!NOTE]
> <span data-ttu-id="7a47a-143">ユーザーは、アプリの作成者が作成したものではないカスタム キャンペーンをクリックして、アプリの登録情報に到達する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7a47a-143">Customers could arrive at your app's listing by clicking on a custom campaign not created by you.</span></span> <span data-ttu-id="7a47a-144">Microsoft では、セッション内のすべてのページ ビューに、ユーザーが初めてストアに到達したときの経路となったキャンペーン ID を記録しています。</span><span class="sxs-lookup"><span data-stu-id="7a47a-144">We stamp every page view within a session with the campaign ID from which the customer first entered the Store.</span></span> <span data-ttu-id="7a47a-145">その後、24 時間以内に発生したアプリの取得についてはすべて、そのキャンペーン ID にコンバージョンが関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-145">We then attribute conversions to that campaign ID for all acquisitions within 24 hours.</span></span> <span data-ttu-id="7a47a-146">合計コンバージョン数の方がキャンペーン ID のコンバージョン数の合計よりも多い場合や、ページビューがゼロであるコンバージョンやアドオンのコンバージョンがレポートされることがあるのはこのためです。</span><span class="sxs-lookup"><span data-stu-id="7a47a-146">Because of this, you may see a higher number of total conversions than the total conversions for your campaign IDs, and you may have conversions or add-on conversions that have zero page views.</span></span> 


## <a name="conversions-breakdown-by-campaign-id"></a><span data-ttu-id="7a47a-147">キャンペーン ID ごとのコンバージョンの内訳</span><span class="sxs-lookup"><span data-stu-id="7a47a-147">Conversions breakdown by campaign ID</span></span>

<span data-ttu-id="7a47a-148">**[キャンペーン ID ごとのコンバージョンの内訳]** グラフでは、[カスタム プロモーション キャンペーン](create-a-custom-app-promotion-campaign.md)ごとに Windows 10 ユーザーのコンバージョン数とページ ビュー数を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-148">The **Conversions breakdown by campaign ID** chart lets you track conversions and page views from customers on Windows 10 for each of your [custom promotion campaigns](create-a-custom-app-promotion-campaign.md).</span></span> <span data-ttu-id="7a47a-149">アプリとアドオンのコンバージョン数が、キャンペーン ID ごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-149">Both app and add-on conversions are shown per campaign ID.</span></span>

<span data-ttu-id="7a47a-150">このグラフでは、*ページ ビュー*は、アプリのストア登録情報をユーザーが閲覧したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="7a47a-150">In this chart, a *page view* means that a customer viewed the app's Store listing.</span></span> <span data-ttu-id="7a47a-151">*コンバージョン*は、ユーザーがアプリまたはアドオンのライセンス (有料の場合も無料の場合も含む) を新しく取得したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="7a47a-151">A *conversion* means that a customer has newly obtained a license for the app or add-on (whether you charged money or you've offered it for free).</span></span>

<span data-ttu-id="7a47a-152">これらのページ ビューとコンバージョンの数値は、ユニーク ユーザー数ではないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="7a47a-152">Keep in mind that these page views and conversion numbers are not counts of unique customers.</span></span> 


## <a name="top-add-ons"></a><span data-ttu-id="7a47a-153">トップ アドオン</span><span class="sxs-lookup"><span data-stu-id="7a47a-153">Top add-ons</span></span>

<span data-ttu-id="7a47a-154">**[トップ アドオン]** のグラフには、指定した期間での各アドオンの合計取得数が示されるので、どのアドオンが最も人気があるかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="7a47a-154">The **Top add-ons** chart shows the total number of acquisitions for each of your add-ons over the selected period of time, so you can see which of your add-ons are the most popular.</span></span> 



 

 
