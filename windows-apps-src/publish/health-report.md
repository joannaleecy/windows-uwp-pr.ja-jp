---
author: jnHs
Description: "Windows デベロッパー センター ダッシュボードの [安定性] レポートによって、クラッシュや応答停止イベントなど、アプリの品質とパフォーマンスに関連するデータを取得できます。"
title: "[安定性] レポート"
ms.assetid: 4F671543-1E91-4E59-88A3-638E3E64539A
ms.author: wdg-dev-content
ms.date: 07/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 67f87405f7738dec591c71678ecfa5122e673502
ms.sourcegitcommit: ae93435e1f9c010a054f55ed7d6bd2f268223957
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/10/2017
---
# <a name="health-report"></a><span data-ttu-id="ef249-104">[安定性] レポート</span><span class="sxs-lookup"><span data-stu-id="ef249-104">Health report</span></span>


<span data-ttu-id="ef249-105">Windows デベロッパー センター ダッシュボードの **[安定性]** レポートによって、クラッシュや応答停止イベントなど、アプリの品質とパフォーマンスに関連するデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="ef249-105">The **Health** report in the Windows Dev Center dashboard lets you get data related to the performance and quality of your app, including crashes and unresponsive events.</span></span> <span data-ttu-id="ef249-106">このデータは、ダッシュボードで表示することも、[レポートをダウンロード](download-analytic-reports.md)してオフラインで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="ef249-106">You can view this data in your dashboard, or [download the report](download-analytic-reports.md) to view offline.</span></span> <span data-ttu-id="ef249-107">該当する場合、さらにデバッグのスタック トレースや CAB ファイルを表示できます。</span><span class="sxs-lookup"><span data-stu-id="ef249-107">Where applicable, you can view stack traces and/or CAB files for further debugging.</span></span>

<span data-ttu-id="ef249-108">または、[Windows ストア分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) を使って、プログラムによりこのレポートのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="ef249-108">Alternatively, you can programmatically retrieve the data in this report by using the [Windows Store analytics REST API](../monetize/access-analytics-data-using-windows-store-services.md).</span></span>


## <a name="apply-filters"></a><span data-ttu-id="ef249-109">フィルターを適用</span><span class="sxs-lookup"><span data-stu-id="ef249-109">Apply filters</span></span>

<span data-ttu-id="ef249-110">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="ef249-110">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="ef249-111">既定では **[72 時間]** が選択されていますが、**[30 日間]** を選んで過去 30 日間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="ef249-111">The default selection is **72H** (72 hours), but you can choose **30D** instead to show data over the last 30 days.</span></span>

<span data-ttu-id="ef249-112">このページにある **[フィルター]** を展開して、このページのすべてのデータをパッケージ バージョンや市場、デバイスの種類を基にフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="ef249-112">You can also expand **Filters** to filter all of the data on this page by package version, market, and/or device type.</span></span>

-   <span data-ttu-id="ef249-113">**[パッケージ バージョン]**: 既定の設定は **[すべて]** です。</span><span class="sxs-lookup"><span data-stu-id="ef249-113">**Package version**: The default setting is **All**.</span></span> <span data-ttu-id="ef249-114">アプリに複数のパッケージが含まれる場合、ここで特定のパッケージを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="ef249-114">If your app includes more than one package, you can choose a specific one here.</span></span>
-   <span data-ttu-id="ef249-115">**[マーケット]**: 既定のフィルターは **[すべてのマーケット]** ですが、特定の 1 つまたは複数のマーケットの取得データのみを抽出することもできます。</span><span class="sxs-lookup"><span data-stu-id="ef249-115">**Market**: The default filter is **All markets**, but you can limit the data to acquisitions in one or more markets.</span></span>
-   <span data-ttu-id="ef249-116">**[デバイスの種類]**: 既定の設定は **[すべて]** ですが、特定の 1 つのデバイスの種類のデータのみを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="ef249-116">**Device type**: The default setting is **All**, but you can choose to show data for only one specific device type.</span></span>
-   <span data-ttu-id="ef249-117">**[OSバージョン]**: 既定は **[すべての OS バージョン]** ですが、特定の OS バージョンを選ぶこともできます。</span><span class="sxs-lookup"><span data-stu-id="ef249-117">**OS version**: The default is **All OS versions**, but you can choose a specific OS version.</span></span>

<span data-ttu-id="ef249-118">以下のすべてのグラフで、指定した期間とフィルターに応じた情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-118">The info in all of the charts listed below will reflect the date range and any filters you've selected.</span></span> <span data-ttu-id="ef249-119">セクションの中には、追加のフィルターを適用できるものもあります。</span><span class="sxs-lookup"><span data-stu-id="ef249-119">Some sections also allow you to apply additional filters.</span></span>


## <a name="failure-hits"></a><span data-ttu-id="ef249-120">Failure hits (エラーのヒット数)</span><span class="sxs-lookup"><span data-stu-id="ef249-120">Failure hits</span></span>

<span data-ttu-id="ef249-121">**[Failure hits] (エラーのヒット数)** のグラフには、選んだ期間中にユーザーがアプリを使用したときに発生した 1 日のクラッシュとイベントの数が表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-121">The **Failure hits** chart shows the number of daily crashes and events that customers experienced when using your app during the selected period of time.</span></span> <span data-ttu-id="ef249-122">各アプリで発生した各種のイベント (クラッシュ、ハング、JavaScript の例外、メモリ エラー) は個別に追跡されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-122">Each type of event that your app experienced is tracked separately: crashes, hangs, JavaScript exceptions, and memory failures.</span></span>


## <a name="failure-hits-by-market"></a><span data-ttu-id="ef249-123">[Failure hits by market] (市場別のエラーのヒット数)</span><span class="sxs-lookup"><span data-stu-id="ef249-123">Failure hits by market</span></span>

<span data-ttu-id="ef249-124">**[Failure hits by market] (市場別のエラーのヒット数)** のグラフには、選んだ期間中に発生した市場別のクラッシュとイベントの合計数が表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-124">The **Failure hits by market** chart shows the total number of crashes and events over the selected period of time by market.</span></span>

<span data-ttu-id="ef249-125">このデータは**マップ** フォームで視覚化して表示することも、設定を切り替えて**テーブル** フォームで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="ef249-125">You can view this data in a visual **Map** form, or toggle the setting to view it in **Table** form.</span></span> <span data-ttu-id="ef249-126">テーブル フォームでは一度に 5 つの市場を表示でき、アルファベット順か、ユーザー セッション数の多い順か少ない順で並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="ef249-126">Table form will show five markets at a time, sorted either alphabetically or by highest/lowest number of user sessions.</span></span> <span data-ttu-id="ef249-127">また、データをダウンロードして、すべての市場の情報をまとめて閲覧することもできます。</span><span class="sxs-lookup"><span data-stu-id="ef249-127">You can also download the data to view info for all markets together.</span></span>


## <a name="package-version"></a><span data-ttu-id="ef249-128">パッケージ バージョン</span><span class="sxs-lookup"><span data-stu-id="ef249-128">Package version</span></span>

<span data-ttu-id="ef249-129">**[パッケージ バージョン]** のグラフには、選んだ期間中に発生したクラッシュとイベントの合計数がパッケージ バージョン別に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-129">The **Package version** chart shows the total number of crashes and events over the selected period of time by package version.</span></span> <span data-ttu-id="ef249-130">既定では、クラッシュとイベントの合計数が最も多いパッケージ バージョンが一番上に表示され、そこから降順に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-130">By default, we show you the package version that had the most hits on top and continue downward from there.</span></span> <span data-ttu-id="ef249-131">このグラフの **[ヒット]** 列の矢印をクリックすることで、この順序を逆にすることができます。</span><span class="sxs-lookup"><span data-stu-id="ef249-131">You can reverse this order by toggling the arrow in the **Hits** column of this chart.</span></span>

## <a name="failures"></a><span data-ttu-id="ef249-132">エラー</span><span class="sxs-lookup"><span data-stu-id="ef249-132">Failures</span></span>

<span data-ttu-id="ef249-133">**[エラー]** のグラフには、選んだ期間中に発生したクラッシュとイベントの合計数がエラー名別に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-133">The **Failures** chart shows the total number of crashes and events over the selected period of time by failure name.</span></span> <span data-ttu-id="ef249-134">既定では、クラッシュとイベントの合計数が最も多いエラーが一番上に表示され、そこから降順に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-134">By default, we show you the failure that had the most hits on top and continue downward from there.</span></span> <span data-ttu-id="ef249-135">このグラフの **[ヒット]** 列の矢印をクリックすることで、この順序を逆にすることができます。</span><span class="sxs-lookup"><span data-stu-id="ef249-135">You can reverse this order by toggling the arrow in the **Hits** column of this chart.</span></span> <span data-ttu-id="ef249-136">各エラーには、エラーの合計数に対する割合も表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-136">For each failure, we also show its percentage of the total number of failures.</span></span>

<span data-ttu-id="ef249-137">特定のエラーに関する **[エラーの詳細]** レポートを表示するには、エラー名を選びます。</span><span class="sxs-lookup"><span data-stu-id="ef249-137">To display the **Failure details** report for a particular failure, select the failure name.</span></span> <span data-ttu-id="ef249-138">PDB シンボル ファイルが含まれている場合、**[エラーの詳細]** レポートには、先月のエラー ヒットの数、エラーの発生に関する詳細 (日付、パッケージ バージョン、デバイスの種類、デバイス モデル、OS ビルド) を示すエラー ログ、スタック トレースまたは CAB ファイル (ある場合) へのリンクが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef249-138">If you have included PDB symbol files, the **Failure details** report includes the number of failure hits over the last month, as well as a failure log that lists occurrence details (date, package version, device type, device model, OS build) and a link to the stack trace and/or CAB file, if available.</span></span>

> [!TIP]
> <span data-ttu-id="ef249-139">CAB ファイルを利用できるのは、Windows Insider ビルドを使っているコンピューターでエラーが発生した場合のみです。したがって、すべてのエラーに CAB のダウンロード オプションがあるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="ef249-139">CAB files will only be available when the failure occurred on a computer using a Windows Insider build, so not all failures will include the CAB download option.</span></span> <span data-ttu-id="ef249-140">**[エラー ログ]** の **[リンク]** 見出しをクリックすると、結果を並べ替えて、CAB ファイルのあるエラーを一覧の先頭に表示できます。</span><span class="sxs-lookup"><span data-stu-id="ef249-140">You can click the **Links** header in the **Failure log** to sort the results so that failures which include CAB files appear at the top of the list.</span></span>

 

 
