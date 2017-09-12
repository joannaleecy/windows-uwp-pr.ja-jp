---
author: jnHs
Description: "Windows デベロッパー センター ダッシュボードの [取得] レポートでは、アプリを取得してインストールしたユーザーと、人口統計データやプラットフォームの詳細を確認できます。"
title: "[取得] レポート"
ms.assetid: 21126362-F3CD-4006-AD3F-82FC88E3B862
ms.author: wdg-dev-content
ms.date: 08/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: d6540db7a3d0a045fa6a2c8fec617f045f4a1bf4
ms.sourcegitcommit: 2b436dc5e5681b8884e0531ee303f851a3e3ccf2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/18/2017
---
# <a name="acquisitions-report"></a><span data-ttu-id="54c68-104">[取得] レポート</span><span class="sxs-lookup"><span data-stu-id="54c68-104">Acquisitions report</span></span>


<span data-ttu-id="54c68-105">Windows デベロッパー センター ダッシュボードの **[取得]** レポートでは、アプリを取得してインストールしたユーザーと、人口統計データやプラットフォームの詳細を確認できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-105">The **Acquisitions** report in the Windows Dev Center dashboard lets you see who has acquired and installed your app, along with demographic and platform details.</span></span> <span data-ttu-id="54c68-106">また、Windows 10 をお使いのお客様が、アプリの登録情報にたどり着いた経路についての情報も確認できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-106">It also lets you get info about how customers on Windows 10 have arrived at your app's listing.</span></span>

<span data-ttu-id="54c68-107">このデータは、ダッシュボードで表示することも、[レポートをダウンロード](download-analytic-reports.md)してオフラインで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-107">You can view this data in your dashboard, or [download the report](download-analytic-reports.md) to view offline.</span></span> <span data-ttu-id="54c68-108">または、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) を使って、プログラムでこのデータを取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-108">Alternatively, you can programmatically retrieve this data by using our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

<span data-ttu-id="54c68-109">このレポートでは、**取得**は、新しいユーザーがアプリのライセンスを入手したことを意味します (有料の場合も無料の場合も含む)。</span><span class="sxs-lookup"><span data-stu-id="54c68-109">In this report, an **acquisition** means a new customer has obtained a license to your app (whether you charged money or you've offered it for free).</span></span> <span data-ttu-id="54c68-110">**インストール**は、アプリが Windows 10 デバイスにインストールされたことを表します。</span><span class="sxs-lookup"><span data-stu-id="54c68-110">An **install** refers to the app being installed on a Windows 10 device.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="54c68-111">**[取得]** レポートには、払戻し、取り消し、支払取り消しなどのデータは含まれません。アプリの収益を見積もるには、[[入金状況]](payout-summary.md) に移動します。</span><span class="sxs-lookup"><span data-stu-id="54c68-111">The **Acquisitions** report does not include data about refunds, reversals, chargebacks, etc. To estimate your app proceeds, visit [Payout summary](payout-summary.md).</span></span> <span data-ttu-id="54c68-112">次に、**[予約済み]** セクションで、**予約済みのトランザクションをダウンロード**するためのリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="54c68-112">In the **Reserved** section, click the **Download reserved transactions** link.</span></span>
>
> <span data-ttu-id="54c68-113">ページ ビューのデータ (後述) を除き、このレポートには Microsoft アカウントにサインインせずにアプリを取得したお客様についてのデータは含まれません。</span><span class="sxs-lookup"><span data-stu-id="54c68-113">Except for page view data (as described below), this report does not include data related to customers who acquire an app without being signed in to a Microsoft account.</span></span>


## <a name="apply-filters"></a><span data-ttu-id="54c68-114">フィルターを適用</span><span class="sxs-lookup"><span data-stu-id="54c68-114">Apply filters</span></span>

<span data-ttu-id="54c68-115">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-115">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="54c68-116">既定では **[30 日間]** が選択されていますが、3、6、12 か月間のデータや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-116">The default selection is **30D** (30 days), but you can choose to show data for 3, 6, or 12 months, or for a custom data range that you specify.</span></span>

<span data-ttu-id="54c68-117">このページにある **[フィルター]** を展開して、このページのすべてのデータを市場やデバイスの種類を基にフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-117">You can also expand **Filters** to filter all of the data on this page by market and/or by device type.</span></span>

-   <span data-ttu-id="54c68-118">**[マーケット]**: 既定のフィルターは **[すべてのマーケット]** ですが、特定の 1 つまたは複数のマーケットの取得データのみを抽出することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-118">**Market**: The default filter is **All markets**, but you can limit the data to acquisitions in one or more markets.</span></span>
-   <span data-ttu-id="54c68-119">**[デバイスの種類]**: 既定の設定は **[すべてのデバイス]** です。</span><span class="sxs-lookup"><span data-stu-id="54c68-119">**Device type**: The default setting is **All devices**.</span></span> <span data-ttu-id="54c68-120">特定のデバイスの種類についてのみ取得データを表示するには、ここでそのデバイスの種類を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="54c68-120">If you want to show data for acquisitions from a certain device type only, you can choose a specific one here.</span></span>

<span data-ttu-id="54c68-121">以下のすべてのグラフで、指定した期間とフィルターに応じた情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="54c68-121">The info in all of the charts listed below will reflect the date range and any filters you've selected.</span></span> <span data-ttu-id="54c68-122">セクションの中には、追加のフィルターを適用できるものもあります。</span><span class="sxs-lookup"><span data-stu-id="54c68-122">Some sections also allow you to apply additional filters.</span></span>


## <a name="acquisitions"></a><span data-ttu-id="54c68-123">取得</span><span class="sxs-lookup"><span data-stu-id="54c68-123">Acquisitions</span></span>

<span data-ttu-id="54c68-124">**[取得]** のグラフには、選んだ期間中の日ごとまたは週ごとのアドオン取得数 (アプリのライセンスを取得した新規顧客数) が示されます。</span><span class="sxs-lookup"><span data-stu-id="54c68-124">The **Acquisitions** chart shows the number of daily or weekly acquisitions (a new customer obtaining a license for your app) over the selected period of time.</span></span> <span data-ttu-id="54c68-125">(**[フィルターを適用]** を使ってより長期間のデータを表示する場合、取得のデータは週単位でグループ化されます)。このグラフに含まれるのは、有効な Microsoft アカウントを使ってサインインしたお客様による取得数のみです。</span><span class="sxs-lookup"><span data-stu-id="54c68-125">(When you use **Apply filters** to show data for a longer duration, the acquisition data will be grouped by week.) Only acquisitions made by customers who are signed in with a valid Microsoft account are included in this chart.</span></span>

<span data-ttu-id="54c68-126">**[アプリの累計]** を選ぶと、アプリの有効期間内の取得数を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-126">You can also see the lifetime number of acquisitions for your app by selecting **App cumulative**.</span></span> <span data-ttu-id="54c68-127">この値は、アプリが初めて公開されたときからの全取得数の累計です。</span><span class="sxs-lookup"><span data-stu-id="54c68-127">This shows the cumulative total of all acquisitions, starting from when your app was first published.</span></span>

<span data-ttu-id="54c68-128">または、取得経路 (ストア クライアントまたは Web ストア) や OS のバージョンによって、結果をフィルター処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-128">You can optionally filter the results by whether the acquisition originated from the client or web-based Store and/or by OS version.</span></span>

> [!NOTE]
> <span data-ttu-id="54c68-129">また、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[アプリの入手数の取得](../monetize/get-app-acquisitions.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-129">You can also programmatically retrieve this data by using the [get app acquisitions](../monetize/get-app-acquisitions.md) method in our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

## <a name="installs"></a><span data-ttu-id="54c68-130">インストール</span><span class="sxs-lookup"><span data-stu-id="54c68-130">Installs</span></span>

<span data-ttu-id="54c68-131">**[インストール]** グラフは、指定された期間で、Microsoft が検出できた、ユーザーがアプリを Windows 10 デバイスに正常にインストールした回数を示します。</span><span class="sxs-lookup"><span data-stu-id="54c68-131">The **Installs** chart shows how many times we have detected that customers have successfully installed your app on Windows 10 devices over the selected period of time.</span></span> <span data-ttu-id="54c68-132">合計数と、(指定された期間に応じて) 日次または週次でのインストール数を示すグラフが表示されます。</span><span class="sxs-lookup"><span data-stu-id="54c68-132">The total number is shown, along with a chart showing installs by day or week (depending on the duration you've selected).</span></span> <span data-ttu-id="54c68-133">特定のパッケージ バージョンを基に、結果をフィルター処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-133">You can optionally filter the results by a specific package version.</span></span>

<span data-ttu-id="54c68-134">インストールの合計数には、次のケースが含まれます。</span><span class="sxs-lookup"><span data-stu-id="54c68-134">The install total includes:</span></span>
-   **<span data-ttu-id="54c68-135">複数の Windows 10 デバイスにおけるインストール。</span><span class="sxs-lookup"><span data-stu-id="54c68-135">Installs on multiple Windows 10 devices.</span></span>** <span data-ttu-id="54c68-136">たとえば、同じユーザーがアプリを 2 台の Windows 10 PC と 1 台の Windows 10 スマートフォンにインストールした場合、3 回のインストールとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="54c68-136">For example, if the same customer installs your app on two Windows 10 PCs and one Windows 10 phone, that counts as three installs.</span></span>
-   **<span data-ttu-id="54c68-137">再インストール。</span><span class="sxs-lookup"><span data-stu-id="54c68-137">Reinstalls.</span></span>** <span data-ttu-id="54c68-138">たとえば、ユーザーが今日アプリをインストールして翌日アプリをアンインストールし、翌月にアプリを再インストールした場合、2 回のインストールとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="54c68-138">For example, if a customer installs your app today, uninstalls your app tomorrow, and then reinstalls your app next month, that counts as two installs.</span></span>

<span data-ttu-id="54c68-139">インストールの合計数には、次のケースは含まれないか反映されません。</span><span class="sxs-lookup"><span data-stu-id="54c68-139">The install total does not include or reflect:</span></span>
-   **<span data-ttu-id="54c68-140">Windows 10 以外のデバイスにおけるインストール。</span><span class="sxs-lookup"><span data-stu-id="54c68-140">Installs on non-Windows 10 devices.</span></span>** <span data-ttu-id="54c68-141">アプリが Windows 8.x や Windows Phone 8.x など、OS 以前のバージョンをサポートしている場合、それらのデバイスへのインストールはカウントされません。</span><span class="sxs-lookup"><span data-stu-id="54c68-141">If your app supports earlier OS versions such as Windows 8.x or Windows Phone 8.x, we don't count any installs on those devices.</span></span>
-   **<span data-ttu-id="54c68-142">アンインストール。</span><span class="sxs-lookup"><span data-stu-id="54c68-142">Uninstalls.</span></span>** <span data-ttu-id="54c68-143">ユーザーがデバイスからアプリをアンインストールした場合、インストールの合計数からアンインストール分は減算されません。</span><span class="sxs-lookup"><span data-stu-id="54c68-143">When a customer uninstalls your app from their device, we don’t subtract that from the total number of installs.</span></span>
-   **<span data-ttu-id="54c68-144">更新プログラム。</span><span class="sxs-lookup"><span data-stu-id="54c68-144">Updates.</span></span>** <span data-ttu-id="54c68-145">たとえば、ユーザーが今日アプリをインストールして翌週アプリの更新プログラムをインストールした場合、1 回のインストールとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="54c68-145">For example, if a customer installs your app today, and then installs an app update a week later, that only counts as one install.</span></span>
-   **<span data-ttu-id="54c68-146">プレインストール。</span><span class="sxs-lookup"><span data-stu-id="54c68-146">Preinstalls.</span></span>** <span data-ttu-id="54c68-147">アプリがプレインストールされたデバイスをユーザーが購入した場合、インストールとしてカウントされません。</span><span class="sxs-lookup"><span data-stu-id="54c68-147">If a customer buys a device that has your app preinstalled, we don’t count that as an install.</span></span>
-   **<span data-ttu-id="54c68-148">システムにより開始されたインストール。</span><span class="sxs-lookup"><span data-stu-id="54c68-148">System-initiated installs.</span></span>** <span data-ttu-id="54c68-149">Windows が何らかの理由でアプリを自動的にインストールした場合、インストールとしてカウントされません。</span><span class="sxs-lookup"><span data-stu-id="54c68-149">If Windows installs your app automatically for some reason, we don’t count that as an install.</span></span>

> [!NOTE]
> <span data-ttu-id="54c68-150">また、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[アプリのインストール数の取得](../monetize/get-app-installs.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-150">You can also programmatically retrieve this data by using the [get app installs](../monetize/get-app-installs.md) method in our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

## <a name="acquisition-funnel"></a><span data-ttu-id="54c68-151">顧客獲得モデル</span><span class="sxs-lookup"><span data-stu-id="54c68-151">Acquisition funnel</span></span>

<span data-ttu-id="54c68-152">**[顧客獲得モデル]** は、ストア ページの閲覧からアプリの使用にいたるまでのファネルの各ステップを完了したユーザー数とコンバージョン率を示します。</span><span class="sxs-lookup"><span data-stu-id="54c68-152">The **Acquisition funnel** shows you how many customers completed each step of the funnel, from viewing the Store page to using the app, along with the conversion rate.</span></span> <span data-ttu-id="54c68-153">このデータは、取得数、インストール数、または使用率を向上するために、より注力した方がよい領域を特定するときの参考になります。</span><span class="sxs-lookup"><span data-stu-id="54c68-153">This data can help you identify areas where you might want to invest more to increase your acquisitions, installs, or usage.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="54c68-154">**[顧客獲得モデル]** に表示されるのは、過去 90 日間の Windows 10 ユーザーについてのデータのみです。</span><span class="sxs-lookup"><span data-stu-id="54c68-154">The **Acquisition funnel** shows data only for customers on Windows 10 over the last 90 days.</span></span>

<span data-ttu-id="54c68-155">ファネルのステップは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="54c68-155">The steps in the funnel are:</span></span>

- <span data-ttu-id="54c68-156">**[ページ ビュー]**: アプリのストア登録情報の合計ビュー数を表します。これには、Microsoft アカウントを使ってサインインしていない閲覧者も含まれます。</span><span class="sxs-lookup"><span data-stu-id="54c68-156">**Page views**: This number represents the total views of your app's Store listing, including people who aren't signed in with a Microsoft account.</span></span> <span data-ttu-id="54c68-157">この情報を Microsoft に提供しないよう設定しているユーザーのデータは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="54c68-157">This does not include data from customers who have opted out of providing this information to Microsoft.</span></span>
- <span data-ttu-id="54c68-158">**[取得]**: ストア登録情報を閲覧してから 48 時間以内に (Microsoft アカウントを使ってサインイン中に) アプリのライセンスを入手した新規ユーザー数。</span><span class="sxs-lookup"><span data-stu-id="54c68-158">**Acquisitions**: The number of new customers who obtained a license to your app (when signed in with their Microsoft account) within 48 hours of viewing its Store listing.</span></span>
- <span data-ttu-id="54c68-159">**[インストール]**: アプリの取得後にアプリをインストールしたユーザー数。</span><span class="sxs-lookup"><span data-stu-id="54c68-159">**Installs**: The number of customers who installed the app after acquiring it.</span></span>
- <span data-ttu-id="54c68-160">**[使用状況]**: アプリのインストール後にアプリを使用したユーザー数。</span><span class="sxs-lookup"><span data-stu-id="54c68-160">**Usage**: The number of customers who used the app after installing it.</span></span>

<span data-ttu-id="54c68-161">性別や年齢グループのほか、カスタム キャンペーン ID を基に、結果をフィルター処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-161">You can optionally filter the results by gender and/or age group, as well as by custom campaign ID.</span></span>

> [!NOTE]
> <span data-ttu-id="54c68-162">また、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[アプリの顧客獲得モデル データの取得](../monetize/get-acquisition-funnel-data.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-162">You can also programmatically retrieve this data by using the [get app acquisition funnel data](../monetize/get-acquisition-funnel-data.md) method in our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

## <a name="markets"></a><span data-ttu-id="54c68-163">市場</span><span class="sxs-lookup"><span data-stu-id="54c68-163">Markets</span></span>

<span data-ttu-id="54c68-164">**[市場]** グラフには、指定した期間での取得数やインストール数の合計が、アプリを提供している市場ごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="54c68-164">The **Markets** chart shows the total number of acquisitions or installs over the selected period of time for each market in which your app is available.</span></span> <span data-ttu-id="54c68-165">**取得数**と**インストール数**のどちらのデータを表示するかを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="54c68-165">You can choose whether to display data for **Acquisitions** or **Installs**.</span></span>

<span data-ttu-id="54c68-166">このデータは**マップ** フォームで視覚化して表示することも、設定を切り替えて**テーブル** フォームで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-166">You can view this data in a visual **Map** form, or toggle the setting to view it in **Table** form.</span></span> <span data-ttu-id="54c68-167">テーブル フォームでは一度に 5 つの市場を表示でき、アルファベット順か、取得数またはインストール数の多い順か少ない順で並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="54c68-167">Table form will show five markets at a time, sorted either alphabetically or by highest/lowest number of acquisitions or installs.</span></span> <span data-ttu-id="54c68-168">また、データをダウンロードして、すべての市場の情報をまとめて閲覧することもできます。</span><span class="sxs-lookup"><span data-stu-id="54c68-168">You can also download the data to view info for all markets together.</span></span>


## <a name="customer-demographic"></a><span data-ttu-id="54c68-169">ユーザーの統計データ</span><span class="sxs-lookup"><span data-stu-id="54c68-169">Customer demographic</span></span>

<span data-ttu-id="54c68-170">**[ユーザーの統計データ]** のグラフには、アプリを取得したユーザーに関する人口統計情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="54c68-170">The **Customer demographic** chart shows demographic info about the people who acquired your app.</span></span> <span data-ttu-id="54c68-171">特定の年齢グループや性別のユーザーによる (選んだ期間中の) 取得の数を確認できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-171">You can see how many acquisitions (over the selected period of time) were made by people in a certain age group and by which gender.</span></span>

> [!NOTE]
> <span data-ttu-id="54c68-172">ユーザーによっては、この情報を共有することを選んでいない場合があります。</span><span class="sxs-lookup"><span data-stu-id="54c68-172">Some customers have opted not to share this info.</span></span> <span data-ttu-id="54c68-173">年齢グループや性別を特定できない場合、その取得は**不明**として分類されます。</span><span class="sxs-lookup"><span data-stu-id="54c68-173">If we were unable to determine the age group or gender, the acquisition is categorized as **Unknown**.</span></span>

 

## <a name="app-page-views-and-conversions-by-channel"></a><span data-ttu-id="54c68-174">チャネルごとのアプリ ページ ビューとコンバージョン</span><span class="sxs-lookup"><span data-stu-id="54c68-174">App page views and conversions by channel</span></span>

<span data-ttu-id="54c68-175">**[チャネルごとのアプリ ページ ビューとコンバージョン]** グラフでは、指定した期間中に、Windows 10 ユーザーがアプリの登録情報にアクセスした経路を確認できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-175">The **App page views and conversions by channel** chart lets you see how customers on Windows 10 arrived at your app's listing over the selected period of time.</span></span>

<span data-ttu-id="54c68-176">このグラフでは、*チャネル*は、ユーザーがアプリの登録情報ページにアクセスするために使用した方法 (たとえば、ストア内での閲覧や検索、外部 Web サイトからのリンク、カスタム キャンペーンからのリンクなど) を指します。</span><span class="sxs-lookup"><span data-stu-id="54c68-176">In this chart, a *channel* refers to the method in which a customer arrived at your app's listing page (for example, browsing and searching in the Store, a link from an external website, a link from one of your custom campaigns, etc.).</span></span> <span data-ttu-id="54c68-177">以下のチャネルの種類が含まれます。</span><span class="sxs-lookup"><span data-stu-id="54c68-177">The following channel types are included:</span></span>

-   <span data-ttu-id="54c68-178">**ストアのトラフィック:** ユーザーは、ストア内で閲覧または検索することによって、アプリの登録情報を表示しました。</span><span class="sxs-lookup"><span data-stu-id="54c68-178">**Store traffic:** The customer was browsing or searching within the Store when they viewed your app's listing.</span></span>
-   <span data-ttu-id="54c68-179">**カスタム キャンペーン:** ユーザーは、[カスタム キャンペーン ID](create-a-custom-app-promotion-campaign.md) を含むリンクを使用しました。</span><span class="sxs-lookup"><span data-stu-id="54c68-179">**Custom campaign:** The customer followed a link that used a [custom campaign ID](create-a-custom-app-promotion-campaign.md).</span></span>
-   <span data-ttu-id="54c68-180">**その他:** ユーザーは、ウェブサイトからアプリのリスティングへの外部リンク (カスタムキャンペーン ID を含まない) を使用したか、または検索エンジンからアプリのリスティングへのリンクを使用しました。</span><span class="sxs-lookup"><span data-stu-id="54c68-180">**Other:** The customer followed an external link (without any custom campaign ID) from a website to your app's listing or the customer followed a link from a search engine to your app's listing.</span></span>

<span data-ttu-id="54c68-181">*ページ ビュー*は、ユーザーが、Web ベースのストアまたは Windows 10 のストア アプリ内から、アプリのストア登録情報ページを表示したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="54c68-181">A *page view* means that a customer viewed your app's Store listing page, either via the web-based Store or from within the Store app on Windows 10.</span></span> <span data-ttu-id="54c68-182">これには、Microsoft アカウントを使ってサインインしていない閲覧者数も含まれます。</span><span class="sxs-lookup"><span data-stu-id="54c68-182">This includes views by people who aren't signed in with a Microsoft account.</span></span> <span data-ttu-id="54c68-183">ユーザーによっては、この情報を Microsoft に提供しないよう設定している場合もあります。</span><span class="sxs-lookup"><span data-stu-id="54c68-183">Some customers have opted out of providing this information to Microsoft.</span></span>

<span data-ttu-id="54c68-184">*コンバージョン*は、(Microsoft アカウントでサインインした) ユーザーが、アプリ (有料の場合も無料の場合も含む) のライセンスを新しく取得したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="54c68-184">A *conversion* means that a customer (signed in with a Microsoft account) has newly obtained a license to your app (whether you charged money or you've offered it for free).</span></span>

<span data-ttu-id="54c68-185">ページ ビューとコンバージョンの数値は、ユニーク ユーザー数ではありません。</span><span class="sxs-lookup"><span data-stu-id="54c68-185">Page view and conversion numbers are not counts of unique customers.</span></span> <span data-ttu-id="54c68-186">コンバージョン率については、[[顧客獲得モデル]](#acquisition-funnel) グラフを参照してください。</span><span class="sxs-lookup"><span data-stu-id="54c68-186">For conversion rate info, see the [Acquisition funnel](#acquisition-funnel) chart.</span></span>

> [!NOTE]
> <span data-ttu-id="54c68-187">ユーザーは、アプリの作成者が作成したものではないカスタム キャンペーンをクリックして、アプリの登録情報に到達する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="54c68-187">Customers could arrive at your app's listing by clicking on a custom campaign not created by you.</span></span> <span data-ttu-id="54c68-188">Microsoft では、セッション内のすべてのページ ビューに、ユーザーが初めてストアに到達したときの経路となったキャンペーン ID を記録しています。</span><span class="sxs-lookup"><span data-stu-id="54c68-188">We stamp every page view within a session with the campaign ID from which the customer first entered the Store.</span></span> <span data-ttu-id="54c68-189">その後、24 時間以内に発生したアプリの取得についてはすべて、そのキャンペーン ID にコンバージョンが関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="54c68-189">We then attribute conversions to that campaign ID for all acquisitions within 24 hours.</span></span> <span data-ttu-id="54c68-190">合計コンバージョン数の方がキャンペーン ID のコンバージョン数の合計よりも多い場合や、ページビューがゼロであるコンバージョンやアドオンのコンバージョンがレポートされることがあるのはこのためです。</span><span class="sxs-lookup"><span data-stu-id="54c68-190">Because of this, you may see a higher number of total conversions than the total conversions for your campaign IDs, and you may have conversions or add-on conversions that have zero page views.</span></span>

> [!NOTE]
> <span data-ttu-id="54c68-191">また、[分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) の[チャネルごとのアプリのコンバージョンの取得](../monetize/get-app-conversions-by-channel.md)メソッドを使って、プログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-191">You can also programmatically retrieve this data by using the [get app conversions by channel](../monetize/get-app-conversions-by-channel.md) method in our [analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>

## <a name="app-page-views-and-conversions-by-campaign-id"></a><span data-ttu-id="54c68-192">キャンペーン ID ごとのアプリ ページ ビューとコンバージョン</span><span class="sxs-lookup"><span data-stu-id="54c68-192">App page views and conversions by campaign ID</span></span>

<span data-ttu-id="54c68-193">**[キャンペーン ID ごとのアプリ ページ ビューとコンバージョン]** グラフでは、前述のように、[カスタム プロモーション キャンペーン](create-a-custom-app-promotion-campaign.md)ごとにコンバージョン数とページ ビュー数を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="54c68-193">The **App page views and conversions by campaign ID** chart lets you track conversions and page views, as described above, for each of your [custom promotion campaigns](create-a-custom-app-promotion-campaign.md).</span></span> <span data-ttu-id="54c68-194">最も反応が得られたキャンペーン ID が表示されます。また、フィルターを使って、特定のキャンペーン ID を除外したり、含めたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="54c68-194">The top campaign IDs are shown, and you can use the filters to exclude or include specific campaign IDs.</span></span>

## <a name="total-campaign-conversions"></a><span data-ttu-id="54c68-195">キャンペーンのコンバージョン合計</span><span class="sxs-lookup"><span data-stu-id="54c68-195">Total campaign conversions</span></span>

<span data-ttu-id="54c68-196">**[キャンペーンのコンバージョン合計]** グラフは、指定した期間での、すべてのカスタム キャンペーンのアプリとアドオンのコンバージョン数の合計を示します。</span><span class="sxs-lookup"><span data-stu-id="54c68-196">The **Total campaign conversions** chart shows the total number of app and add-on conversions from all custom campaigns during the selected period of time.</span></span>





 

 
