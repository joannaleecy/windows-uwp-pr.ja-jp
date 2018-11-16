---
author: jnHs
Description: The Acquisitions report in Partner Center lets you see who has acquired and installed your app, along with demographic and platform details.
title: '[取得] レポート'
ms.assetid: 21126362-F3CD-4006-AD3F-82FC88E3B862
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, 取得, アプリの売り上げ, アプリのダウンロード, インストール, ファネル, 購入, コンバージョン, チャネル, アプリ ページ ビュー
ms.localizationpriority: medium
ms.openlocfilehash: bbd84b32a4e94687ff50f553137a86885094a7d6
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "6994901"
---
# <a name="acquisitions-report"></a><span data-ttu-id="d8a04-103">取得レポート</span><span class="sxs-lookup"><span data-stu-id="d8a04-103">Acquisitions report</span></span>


<span data-ttu-id="d8a04-104">[パートナー センター](https://partner.microsoft.com/dashboard)での**取得]** レポートでは、取得してと共に、人口統計データ、アプリをインストールしたユーザーを表示できます。 プラットフォームの詳細と、アプリの内容が windows 10 (Xbox を含む) のユーザーにアクセスする方法に関する情報を示しています。</span><span class="sxs-lookup"><span data-stu-id="d8a04-104">The **Acquisitions** report in [Partner Center](https://partner.microsoft.com/dashboard) lets you see who has acquired and installed your app, along with demographic and platform details, and shows info about how customers on Windows10 (including Xbox) have arrived at your app's listing.</span></span> <span data-ttu-id="d8a04-105">最後の時間、または 70 2 時間の期間のリアルタイムの入手データの近く表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-105">You can also view near real-time acquisition data for the last hour or seventy-two hour period.</span></span> 

<span data-ttu-id="d8a04-106">このデータは、パートナー中央揃え、または[レポートをダウンロード](download-analytic-reports.md)してオフラインで表示できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-106">You can view this data in Partner Center, or [download the report](download-analytic-reports.md) to view offline.</span></span> <span data-ttu-id="d8a04-107">または、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) を使って、プログラムでこのデータを取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-107">Alternatively, you can programmatically retrieve this data by using our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

<span data-ttu-id="d8a04-108">このレポートでは、**取得**は、新しいユーザーがアプリのライセンスを入手したことを意味します (有料の場合も無料の場合も含む)。</span><span class="sxs-lookup"><span data-stu-id="d8a04-108">In this report, an **acquisition** means a new customer has obtained a license to your app (whether you charged money or you've offered it for free).</span></span> <span data-ttu-id="d8a04-109">**インストール**は、アプリが Windows 10 デバイスにインストールされたことを表します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-109">An **install** refers to the app being installed on a Windows 10 device.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d8a04-110">**[取得]** レポートには、払戻し、取り消し、支払取り消しなどのデータは含まれません。アプリの収益を見積もるには、[[入金状況]](payout-summary.md) に移動します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-110">The **Acquisitions** report does not include data about refunds, reversals, chargebacks, etc. To estimate your app proceeds, visit [Payout summary](payout-summary.md).</span></span> <span data-ttu-id="d8a04-111">次に、**[予約済み]** セクションで、**予約済みのトランザクションをダウンロード**するためのリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="d8a04-111">In the **Reserved** section, click the **Download reserved transactions** link.</span></span>
>
> <span data-ttu-id="d8a04-112">ページ ビューのデータ (後述) を除き、このレポートには Microsoft アカウントにサインインせずにアプリを取得したお客様についてのデータは含まれません。</span><span class="sxs-lookup"><span data-stu-id="d8a04-112">Except for page view data (as described below), this report does not include data related to customers who acquire an app without being signed in to a Microsoft account.</span></span>


## <a name="apply-filters"></a><span data-ttu-id="d8a04-113">フィルターを適用</span><span class="sxs-lookup"><span data-stu-id="d8a04-113">Apply filters</span></span>

<span data-ttu-id="d8a04-114">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-114">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="d8a04-115">既定では **[30 日間]** が選択されていますが、3、6、12 か月間のデータや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-115">The default selection is **30D** (30 days), but you can choose to show data for 3, 6, or 12 months, or for a custom data range that you specify.</span></span> <span data-ttu-id="d8a04-116">すべてのオプションについては、データを表示リアルタイムに近い (**アプリの累積的な**データを除く)。</span><span class="sxs-lookup"><span data-stu-id="d8a04-116">Near real time data will be shown for all options (except in **App cumulative** data).</span></span> <span data-ttu-id="d8a04-117">**1 H**と**72**時間期間のみ**取得**グラフの**毎日アプリ**タブと適用**市場**グラフの**取得**] タブにされます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-117">The **1H** and **72H** time periods only apply to the **App daily** tab of the **Acquisitions** chart and to the **Acquisitions** tab of the **Markets** chart.</span></span> 

<span data-ttu-id="d8a04-118">このページにある **[フィルター]** を展開して、このページのすべてのデータを市場やデバイスの種類を基にフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-118">You can also expand **Filters** to filter all of the data on this page by market and/or by device type.</span></span>

-   <span data-ttu-id="d8a04-119">**[マーケット]**: 既定のフィルターは **[すべてのマーケット]** ですが、特定の 1 つまたは複数のマーケットの取得データのみを抽出することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-119">**Market**: The default filter is **All markets**, but you can limit the data to acquisitions in one or more markets.</span></span>
-   <span data-ttu-id="d8a04-120">**[デバイスの種類]**: 既定の設定は **[すべてのデバイス]** です。</span><span class="sxs-lookup"><span data-stu-id="d8a04-120">**Device type**: The default setting is **All devices**.</span></span> <span data-ttu-id="d8a04-121">特定のデバイスの種類 (PC、コンソール、タブレットなど) についてのみ取得データを表示するには、ここでそのデバイスの種類を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-121">If you want to show data for acquisitions from a certain device type only (such as PC, console, or tablet), you can choose a specific one here.</span></span>

<span data-ttu-id="d8a04-122">以下のすべてのグラフで、指定した期間とフィルターに応じた情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-122">The info in all of the charts listed below will reflect the date range and any filters you've selected.</span></span> <span data-ttu-id="d8a04-123">セクションの中には、追加のフィルターを適用できるものもあります。</span><span class="sxs-lookup"><span data-stu-id="d8a04-123">Some sections also allow you to apply additional filters.</span></span>


## <a name="acquisitions"></a><span data-ttu-id="d8a04-124">取得</span><span class="sxs-lookup"><span data-stu-id="d8a04-124">Acquisitions</span></span>

<span data-ttu-id="d8a04-125">**[取得]** のグラフには、選んだ期間中の日ごとまたは週ごとのアドオン取得数 (アプリのライセンスを取得した新規顧客数) が示されます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-125">The **Acquisitions** chart shows the number of daily or weekly acquisitions (a new customer obtaining a license for your app) over the selected period of time.</span></span> <span data-ttu-id="d8a04-126">(**[フィルターを適用]** を使ってより長期間のデータを表示する場合、取得のデータは週単位でグループ化されます)。このグラフに含まれるのは、有効な Microsoft アカウントを使ってサインインしたお客様による取得数のみです。</span><span class="sxs-lookup"><span data-stu-id="d8a04-126">(When you use **Apply filters** to show data for a longer duration, the acquisition data will be grouped by week.) Only acquisitions made by customers who are signed in with a valid Microsoft account are included in this chart.</span></span> 

<span data-ttu-id="d8a04-127">既定では、ほぼリアルタイムにデータが含まれている**アプリを毎日**ビューを表示します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-127">By default, we show the **App daily** view, which includes near real time data.</span></span> <span data-ttu-id="d8a04-128">**[アプリの累計]** を選ぶと、アプリの有効期間内の取得数を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-128">You can also see the lifetime number of acquisitions for your app by selecting **App cumulative**.</span></span> <span data-ttu-id="d8a04-129">この値は、アプリが初めて公開されたときからの全取得数の累計です。</span><span class="sxs-lookup"><span data-stu-id="d8a04-129">This shows the cumulative total of all acquisitions, starting from when your app was first published.</span></span>

<span data-ttu-id="d8a04-130">**粗販売**(2016 年 10 月に存在する) からアプリの使用もこのグラフで合計金額 (USD) でのアプリ販売から獲得を示すできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-130">**Gross sales** for your app (from October 2016 - present) are also available in this chart, showing the total amount earned from app sales (in USD).</span></span> <span data-ttu-id="d8a04-131">この時間が、払い戻し、払戻し、チャージ バックなどのアカウントしないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d8a04-131">Note that this amount does not account for any refunds,  reversals, chargeback, etc.</span></span>

<span data-ttu-id="d8a04-132">または、取得経路 (ストア クライアントまたは Web ストア) や OS のバージョンによって、結果をフィルター処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-132">You can optionally filter the results by whether the acquisition originated from the client or web-based Store and/or by OS version.</span></span>

> [!NOTE]
> <span data-ttu-id="d8a04-133">また、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[アプリの入手数の取得](../monetize/get-app-acquisitions.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-133">You can also programmatically retrieve this data by using the [get app acquisitions](../monetize/get-app-acquisitions.md) method in our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

<span data-ttu-id="d8a04-134">**毎日のアプリ**ビューでは、 **30 日間**の期間を選択すると円形のマーカーを表示があります。</span><span class="sxs-lookup"><span data-stu-id="d8a04-134">In the **App daily** view, when the **30D** time period is selected, you may see circle markers.</span></span> <span data-ttu-id="d8a04-135">これらは、大幅に増加を表すまたは知りたいと考えている、指定された値が減少します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-135">These represent a significant increase or decrease in a given value that we think you'll want to know about.</span></span> <span data-ttu-id="d8a04-136">円が表示される日付は、大幅に増加または減少それより前に、の週との比較を検出しました週の終わりを表します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-136">The date on which the circle appears represents the end of the week in which we detected a significant increase or decrease compared to the week before that.</span></span> <span data-ttu-id="d8a04-137">変更された内容に関する詳細を表示するには、円の上に置きます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-137">To see more details about what's changed, hover over the circle.</span></span>  

> [!TIP]
> <span data-ttu-id="d8a04-138">[インサイト レポート](insights-report.md)で過去 30 日間の大幅な変更に関連する他の情報を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-138">You can view more insights related to significant changes over the last 30 days in the [Insights report](insights-report.md).</span></span>

## <a name="installs"></a><span data-ttu-id="d8a04-139">インストール</span><span class="sxs-lookup"><span data-stu-id="d8a04-139">Installs</span></span>

<span data-ttu-id="d8a04-140">**[インストール]** グラフは、指定された期間に検出された、ユーザーがアプリを Windows 10 デバイス (Xbox One 本体を含む) に正常にインストールした回数を示します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-140">The **Installs** chart shows how many times we have detected that customers have successfully installed your app on Windows 10 devices (including Xbox One consoles) over the selected period of time.</span></span> <span data-ttu-id="d8a04-141">合計数と、(指定された期間に応じて) 日次または週次でのインストール数を示すグラフが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-141">The total number is shown, along with a chart showing installs by day or week (depending on the duration you've selected).</span></span> <span data-ttu-id="d8a04-142">特定のパッケージ バージョンを基に、結果をフィルター処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-142">You can optionally filter the results by a specific package version.</span></span>

<span data-ttu-id="d8a04-143">インストールの合計数には、次のケースが含まれます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-143">The install total includes:</span></span>
-   **<span data-ttu-id="d8a04-144">複数の Windows 10 デバイスにおけるインストール。</span><span class="sxs-lookup"><span data-stu-id="d8a04-144">Installs on multiple Windows 10 devices.</span></span>** <span data-ttu-id="d8a04-145">たとえば、同じユーザーがアプリを 2 台の Windows 10 PC と 1 台の Xbox One 本体にインストールした場合、3 回のインストールとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-145">For example, if the same customer installs your app on two Windows 10 PCs and one Xbox One console, that counts as three installs.</span></span>
-   **<span data-ttu-id="d8a04-146">再インストール。</span><span class="sxs-lookup"><span data-stu-id="d8a04-146">Reinstalls.</span></span>** <span data-ttu-id="d8a04-147">たとえば、ユーザーが今日アプリをインストールして翌日アプリをアンインストールし、翌月にアプリを再インストールした場合、2 回のインストールとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-147">For example, if a customer installs your app today, uninstalls your app tomorrow, and then reinstalls your app next month, that counts as two installs.</span></span>

<span data-ttu-id="d8a04-148">インストールの合計数には、次のケースは含まれないか反映されません。</span><span class="sxs-lookup"><span data-stu-id="d8a04-148">The install total does not include or reflect:</span></span>
-   **<span data-ttu-id="d8a04-149">Windows 10 以外のデバイスにおけるインストール。</span><span class="sxs-lookup"><span data-stu-id="d8a04-149">Installs on non-Windows 10 devices.</span></span>** <span data-ttu-id="d8a04-150">アプリが Windows 8.x や Windows Phone 8.x など、OS 以前のバージョンをサポートしている場合、それらのデバイスへのインストールはカウントされません。</span><span class="sxs-lookup"><span data-stu-id="d8a04-150">If your app supports earlier OS versions such as Windows 8.x or Windows Phone 8.x, we don't count any installs on those devices.</span></span>
-   **<span data-ttu-id="d8a04-151">アンインストール。</span><span class="sxs-lookup"><span data-stu-id="d8a04-151">Uninstalls.</span></span>** <span data-ttu-id="d8a04-152">ユーザーがデバイスからアプリをアンインストールした場合、インストールの合計数からアンインストール分は減算されません。</span><span class="sxs-lookup"><span data-stu-id="d8a04-152">When a customer uninstalls your app from their device, we don’t subtract that from the total number of installs.</span></span>
-   **<span data-ttu-id="d8a04-153">更新プログラム。</span><span class="sxs-lookup"><span data-stu-id="d8a04-153">Updates.</span></span>** <span data-ttu-id="d8a04-154">たとえば、ユーザーが今日アプリをインストールして翌週アプリの更新プログラムをインストールした場合、1 回のインストールとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-154">For example, if a customer installs your app today, and then installs an app update a week later, that only counts as one install.</span></span>
-   **<span data-ttu-id="d8a04-155">プレインストール。</span><span class="sxs-lookup"><span data-stu-id="d8a04-155">Preinstalls.</span></span>** <span data-ttu-id="d8a04-156">アプリがプレインストールされたデバイスをユーザーが購入した場合、インストールとしてカウントされません。</span><span class="sxs-lookup"><span data-stu-id="d8a04-156">If a customer buys a device that has your app preinstalled, we don’t count that as an install.</span></span>
-   **<span data-ttu-id="d8a04-157">システムにより開始されたインストール。</span><span class="sxs-lookup"><span data-stu-id="d8a04-157">System-initiated installs.</span></span>** <span data-ttu-id="d8a04-158">Windows が何らかの理由でアプリを自動的にインストールした場合、インストールとしてカウントされません。</span><span class="sxs-lookup"><span data-stu-id="d8a04-158">If Windows installs your app automatically for some reason, we don’t count that as an install.</span></span>

> [!NOTE]
> <span data-ttu-id="d8a04-159">また、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[アプリのインストール数の取得](../monetize/get-app-installs.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-159">You can also programmatically retrieve this data by using the [get app installs](../monetize/get-app-installs.md) method in our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

## <a name="acquisition-funnel"></a><span data-ttu-id="d8a04-160">顧客獲得モデル</span><span class="sxs-lookup"><span data-stu-id="d8a04-160">Acquisition funnel</span></span>

<span data-ttu-id="d8a04-161">**[顧客獲得モデル]** は、ストア ページの閲覧からアプリの使用にいたるまでのファネルの各ステップを完了したユーザー数とコンバージョン率を示します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-161">The **Acquisition funnel** shows you how many customers completed each step of the funnel, from viewing the Store page to using the app, along with the conversion rate.</span></span> <span data-ttu-id="d8a04-162">このデータは、取得数、インストール数、または使用率を向上するために、より注力した方がよい領域を特定するときの参考になります。</span><span class="sxs-lookup"><span data-stu-id="d8a04-162">This data can help you identify areas where you might want to invest more to increase your acquisitions, installs, or usage.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d8a04-163">**[顧客獲得モデル]** に表示されるのは、過去 90 日間の Windows 10 ユーザー (Xbox ユーザーを含む) についてのデータのみです。</span><span class="sxs-lookup"><span data-stu-id="d8a04-163">The **Acquisition funnel** shows data only for customers on Windows 10 (including Xbox) over the last 90 days.</span></span>

<span data-ttu-id="d8a04-164">ファネルのステップは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="d8a04-164">The steps in the funnel are:</span></span>

- <span data-ttu-id="d8a04-165">**[ページ ビュー]**: アプリのストア登録情報の合計ビュー数を表します。これには、Microsoft アカウントを使ってサインインしていない閲覧者も含まれます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-165">**Page views**: This number represents the total views of your app's Store listing, including people who aren't signed in with a Microsoft account.</span></span> <span data-ttu-id="d8a04-166">この情報を Microsoft に提供しないよう設定しているユーザーのデータは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="d8a04-166">This does not include data from customers who have opted out of providing this information to Microsoft.</span></span>
- <span data-ttu-id="d8a04-167">**[取得]**: ストア登録情報を閲覧してから 48 時間以内に (Microsoft アカウントを使ってサインイン中に) アプリのライセンスを入手した新規ユーザー数。</span><span class="sxs-lookup"><span data-stu-id="d8a04-167">**Acquisitions**: The number of new customers who obtained a license to your app (when signed in with their Microsoft account) within 48 hours of viewing its Store listing.</span></span>
- <span data-ttu-id="d8a04-168">**[インストール]**: アプリの取得後にアプリをインストールしたユーザー数。</span><span class="sxs-lookup"><span data-stu-id="d8a04-168">**Installs**: The number of customers who installed the app after acquiring it.</span></span>
- <span data-ttu-id="d8a04-169">**[使用状況]**: アプリのインストール後にアプリを使用したユーザー数。</span><span class="sxs-lookup"><span data-stu-id="d8a04-169">**Usage**: The number of customers who used the app after installing it.</span></span>

<span data-ttu-id="d8a04-170">性別や年齢グループのほか、カスタム キャンペーン ID を基に、結果をフィルター処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-170">You can optionally filter the results by gender and/or age group, as well as by custom campaign ID.</span></span>

> [!NOTE]
> <span data-ttu-id="d8a04-171">また、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[アプリの顧客獲得モデル データの取得](../monetize/get-acquisition-funnel-data.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-171">You can also programmatically retrieve this data by using the [get app acquisition funnel data](../monetize/get-acquisition-funnel-data.md) method in our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

## <a name="markets"></a><span data-ttu-id="d8a04-172">市場</span><span class="sxs-lookup"><span data-stu-id="d8a04-172">Markets</span></span>

<span data-ttu-id="d8a04-173">**[市場]** グラフには、指定した期間での取得数やインストール数の合計が、アプリを提供している市場ごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-173">The **Markets** chart shows the total number of acquisitions or installs over the selected period of time for each market in which your app is available.</span></span> <span data-ttu-id="d8a04-174">**取得数**と**インストール数**のどちらのデータを表示するかを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-174">You can choose whether to display data for **Acquisitions** or **Installs**.</span></span>

<span data-ttu-id="d8a04-175">このデータは**マップ** フォームで視覚化して表示することも、設定を切り替えて**テーブル** フォームで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-175">You can view this data in a visual **Map** form, or toggle the setting to view it in **Table** form.</span></span> <span data-ttu-id="d8a04-176">テーブル フォームでは一度に 5 つの市場を表示でき、アルファベット順か、取得数またはインストール数の多い順か少ない順で並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-176">Table form will show five markets at a time, sorted either alphabetically or by highest/lowest number of acquisitions or installs.</span></span> <span data-ttu-id="d8a04-177">また、データをダウンロードして、すべての市場の情報をまとめて閲覧することもできます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-177">You can also download the data to view info for all markets together.</span></span>


## <a name="customer-demographic"></a><span data-ttu-id="d8a04-178">ユーザーの統計データ</span><span class="sxs-lookup"><span data-stu-id="d8a04-178">Customer demographic</span></span>

<span data-ttu-id="d8a04-179">**[ユーザーの統計データ]** のグラフには、アプリを取得したユーザーに関する人口統計情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-179">The **Customer demographic** chart shows demographic info about the people who acquired your app.</span></span> <span data-ttu-id="d8a04-180">特定の年齢グループや性別のユーザーによる (選んだ期間中の) 取得の数を確認できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-180">You can see how many acquisitions (over the selected period of time) were made by people in a certain age group and by which gender.</span></span>

> [!NOTE]
> <span data-ttu-id="d8a04-181">ユーザーによっては、この情報を共有することを選んでいない場合があります。</span><span class="sxs-lookup"><span data-stu-id="d8a04-181">Some customers have opted not to share this info.</span></span> <span data-ttu-id="d8a04-182">年齢グループや性別を特定できない場合、その取得は**不明**として分類されます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-182">If we were unable to determine the age group or gender, the acquisition is categorized as **Unknown**.</span></span>

 

## <a name="app-page-views-and-conversions-by-channel"></a><span data-ttu-id="d8a04-183">チャネルごとのアプリ ページ ビューとコンバージョン</span><span class="sxs-lookup"><span data-stu-id="d8a04-183">App page views and conversions by channel</span></span>

<span data-ttu-id="d8a04-184">**アプリ ページ ビューとコンバージョン チャネルごと**のグラフでは、windows 10 のユーザーが選択した期間中のアプリの登録情報に到着する方法を確認できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-184">The **App page views and conversions by channel** chart lets you see how customers on Windows10 arrived at your app's listing over the selected period of time.</span></span>

<span data-ttu-id="d8a04-185">このグラフでは、*チャネル*は、ユーザーがアプリの登録情報ページにアクセスするために使用した方法 (たとえば、ストア内での閲覧や検索、外部 Web サイトからのリンク、カスタム キャンペーンからのリンクなど) を指します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-185">In this chart, a *channel* refers to the method in which a customer arrived at your app's listing page (for example, browsing and searching in the Store, a link from an external website, a link from one of your custom campaigns, etc.).</span></span> <span data-ttu-id="d8a04-186">以下のチャネルの種類が含まれます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-186">The following channel types are included:</span></span>

-   <span data-ttu-id="d8a04-187">**ストアのトラフィック:** ユーザーは、ストア内で閲覧または検索することによって、アプリの内容を表示しました。</span><span class="sxs-lookup"><span data-stu-id="d8a04-187">**Store traffic:** The customer was browsing or searching within the Store when they viewed your app's listing.</span></span>
-   <span data-ttu-id="d8a04-188">**カスタム キャンペーン:** ユーザーは、[カスタム キャンペーン ID](create-a-custom-app-promotion-campaign.md) を含むリンクを使用しました。</span><span class="sxs-lookup"><span data-stu-id="d8a04-188">**Custom campaign:** The customer followed a link that used a [custom campaign ID](create-a-custom-app-promotion-campaign.md).</span></span>
-   <span data-ttu-id="d8a04-189">**その他:** ユーザーは、ウェブサイトからアプリのリスティングへの外部リンク (カスタムキャンペーン ID を含まない) を使用したか、または検索エンジンからアプリのリスティングへのリンクを使用しました。</span><span class="sxs-lookup"><span data-stu-id="d8a04-189">**Other:** The customer followed an external link (without any custom campaign ID) from a website to your app's listing or the customer followed a link from a search engine to your app's listing.</span></span>

<span data-ttu-id="d8a04-190">*ページ ビュー*内からまたは web ベースのストアによって、ユーザーがアプリのストア登録情報] ページを閲覧したことを意味 windows 10 上のストア アプリ。</span><span class="sxs-lookup"><span data-stu-id="d8a04-190">A *page view* means that a customer viewed your app's Store listing page, either via the web-based Store or from within the Store app on Windows10.</span></span> <span data-ttu-id="d8a04-191">これには、Microsoft アカウントを使ってサインインしていない閲覧者数も含まれます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-191">This includes views by people who aren't signed in with a Microsoft account.</span></span> <span data-ttu-id="d8a04-192">ユーザーによっては、この情報を Microsoft に提供しないよう設定している場合もあります。</span><span class="sxs-lookup"><span data-stu-id="d8a04-192">Some customers have opted out of providing this information to Microsoft.</span></span>

<span data-ttu-id="d8a04-193">*コンバージョン*は、(Microsoft アカウントでサインインした) ユーザーが、アプリ (有料の場合も無料の場合も含む) のライセンスを新しく取得したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-193">A *conversion* means that a customer (signed in with a Microsoft account) has newly obtained a license to your app (whether you charged money or you've offered it for free).</span></span>

<span data-ttu-id="d8a04-194">ページ ビューとコンバージョンの数値は、ユニーク ユーザー数ではありません。</span><span class="sxs-lookup"><span data-stu-id="d8a04-194">Page view and conversion numbers are not counts of unique customers.</span></span> <span data-ttu-id="d8a04-195">コンバージョン率については、[[顧客獲得モデル]](#acquisition-funnel) グラフを参照してください。</span><span class="sxs-lookup"><span data-stu-id="d8a04-195">For conversion rate info, see the [Acquisition funnel](#acquisition-funnel) chart.</span></span>

> [!NOTE]
> <span data-ttu-id="d8a04-196">ユーザーは、アプリの作成者が作成したものではないカスタム キャンペーンをクリックして、アプリの登録情報に到達する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d8a04-196">Customers could arrive at your app's listing by clicking on a custom campaign not created by you.</span></span> <span data-ttu-id="d8a04-197">Microsoft では、セッション内のすべてのページ ビューに、ユーザーが初めてストアに到達したときの経路となったキャンペーン ID を記録しています。</span><span class="sxs-lookup"><span data-stu-id="d8a04-197">We stamp every page view within a session with the campaign ID from which the customer first entered the Store.</span></span> <span data-ttu-id="d8a04-198">その後、24 時間以内に発生したアプリの取得についてはすべて、そのキャンペーン ID にコンバージョンが関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-198">We then attribute conversions to that campaign ID for all acquisitions within 24 hours.</span></span> <span data-ttu-id="d8a04-199">合計コンバージョン数の方がキャンペーン ID のコンバージョン数の合計よりも多い場合や、ページビューがゼロであるコンバージョンやアドオンのコンバージョンがレポートされることがあるのはこのためです。</span><span class="sxs-lookup"><span data-stu-id="d8a04-199">Because of this, you may see a higher number of total conversions than the total conversions for your campaign IDs, and you may have conversions or add-on conversions that have zero page views.</span></span>

> [!NOTE]
> <span data-ttu-id="d8a04-200">また、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[チャネルごとのアプリのコンバージョンの取得](../monetize/get-app-conversions-by-channel.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-200">You can also programmatically retrieve this data by using the [get app conversions by channel](../monetize/get-app-conversions-by-channel.md) method in our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

## <a name="app-page-views-and-conversions-by-campaign-id"></a><span data-ttu-id="d8a04-201">キャンペーン ID ごとのアプリ ページ ビューとコンバージョン</span><span class="sxs-lookup"><span data-stu-id="d8a04-201">App page views and conversions by campaign ID</span></span>

<span data-ttu-id="d8a04-202">**[キャンペーン ID ごとのアプリ ページ ビューとコンバージョン]** グラフでは、前述のように、[カスタム プロモーション キャンペーン](create-a-custom-app-promotion-campaign.md)ごとにコンバージョン数とページ ビュー数を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-202">The **App page views and conversions by campaign ID** chart lets you track conversions and page views, as described above, for each of your [custom promotion campaigns](create-a-custom-app-promotion-campaign.md).</span></span> <span data-ttu-id="d8a04-203">最も反応が得られたキャンペーン ID が表示されます。また、フィルターを使って、特定のキャンペーン ID を除外したり、含めたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="d8a04-203">The top campaign IDs are shown, and you can use the filters to exclude or include specific campaign IDs.</span></span>

## <a name="total-campaign-conversions"></a><span data-ttu-id="d8a04-204">キャンペーンのコンバージョン合計</span><span class="sxs-lookup"><span data-stu-id="d8a04-204">Total campaign conversions</span></span>

<span data-ttu-id="d8a04-205">**[キャンペーンのコンバージョン合計]** グラフは、指定した期間での、すべてのカスタム キャンペーンのアプリとアドオンのコンバージョン数の合計を示します。</span><span class="sxs-lookup"><span data-stu-id="d8a04-205">The **Total campaign conversions** chart shows the total number of app and add-on conversions from all custom campaigns during the selected period of time.</span></span>





 

 
