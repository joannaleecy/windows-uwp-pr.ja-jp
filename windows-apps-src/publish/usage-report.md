---
author: jnHs
Description: The Usage report in the Windows Dev Center dashboard lets you see how customers are using your app.
title: '[使用状況] レポート'
ms.assetid: 5F0E7F94-D121-4AD3-A6E5-9C0DEC437BD3
ms.author: wdg-dev-content
ms.date: 10/05/2018
ms.topic: article
keywords: windows 10, uwp, 使用状況, カスタム イベント, レポート, 利用統計情報, ユーザー セッション
ms.localizationpriority: medium
ms.openlocfilehash: 3998e8c5b207d8484a621db16d2e72a136f22c80
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5546383"
---
# <a name="usage-report"></a><span data-ttu-id="aa777-103">[使用状況] レポート</span><span class="sxs-lookup"><span data-stu-id="aa777-103">Usage report</span></span>


<span data-ttu-id="aa777-104">Windows デベロッパー センター ダッシュボードの **[使用状況]** レポートでは、Windows 10 ユーザー (Xbox ユーザーを含む) のアプリの使用状況を確認し、定義したカスタム イベントに関する情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="aa777-104">The **Usage** report in the Windows Dev Center dashboard lets you see how customers on Windows 10 (including Xbox) are using your app, and shows info about custom events that you've defined.</span></span> <span data-ttu-id="aa777-105">このデータは、ダッシュボードで表示することも、[レポートをダウンロード](download-analytic-reports.md)してオフラインで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="aa777-105">You can view this data in your dashboard, or [download the report](download-analytic-reports.md) to view offline.</span></span>


## <a name="apply-filters"></a><span data-ttu-id="aa777-106">フィルターを適用</span><span class="sxs-lookup"><span data-stu-id="aa777-106">Apply filters</span></span>

<span data-ttu-id="aa777-107">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="aa777-107">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="aa777-108">既定では **[30 日間]** が選択されていますが、3、6、12 か月間のデータや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="aa777-108">The default selection is **30D** (30 days), but you can choose to show data for 3, 6, or 12 months, or for a custom data range that you specify.</span></span>

<span data-ttu-id="aa777-109">このページにある **[フィルター]** を展開して、このページのデータをパッケージ バージョンや市場、デバイスの種類を基にフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="aa777-109">You can also expand **Filters** to filter the data on this page by package version, market, and/or device type.</span></span>

-   <span data-ttu-id="aa777-110">**[パッケージ バージョン]**: 既定の設定は **[すべて]** です。</span><span class="sxs-lookup"><span data-stu-id="aa777-110">**Package version**: The default setting is **All**.</span></span> <span data-ttu-id="aa777-111">アプリに複数のパッケージが含まれる場合、ここで特定のパッケージを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="aa777-111">If your app includes more than one package, you can choose a specific one here.</span></span>
-   <span data-ttu-id="aa777-112">**[市場]**: 既定のフィルターは **[すべての市場]** ですが、特定の 1 つまたは複数の市場のデータのみを抽出することもできます。</span><span class="sxs-lookup"><span data-stu-id="aa777-112">**Market**: The default filter is **All markets**, but you can limit the data to one or more markets.</span></span>
-   <span data-ttu-id="aa777-113">**[デバイスの種類]**: 既定の設定は **[すべて]** ですが、特定の 1 つのデバイスの種類 (PC、コンソール、タブレットなど) のデータのみを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="aa777-113">**Device type**: The default setting is **All**, but you can choose to show data for only one specific device type (PC, console, tablet, etc.).</span></span>

<span data-ttu-id="aa777-114">以下のすべてのグラフに示される情報は、選択した日付の範囲とフィルターが適用されます (ただし、**[使用状況]** グラフの**新しいユーザー**は例外で、この情報はフィルターが選択されていると表示されません)。</span><span class="sxs-lookup"><span data-stu-id="aa777-114">The info in all of the charts listed below will reflect the date range and any filters you've selected (with the exception of **New users** in the **Usage** chart, which will not appear if any filters are selected).</span></span> <span data-ttu-id="aa777-115">セクションの中には、追加のフィルターを適用できるものもあります。</span><span class="sxs-lookup"><span data-stu-id="aa777-115">Some sections also allow you to apply additional filters.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="aa777-116">このレポートに含まれるのは、Windows 10 ユーザー (Xbox ユーザーを含む) で製品利用統計情報の提供を辞退していないユーザーの使用状況データのみです。</span><span class="sxs-lookup"><span data-stu-id="aa777-116">This report only includes usage data from customers on Windows 10 (including Xbox) who have not opted out of providing telemetry info.</span></span> <span data-ttu-id="aa777-117">Xbox ゲームの使用状況データは、ユーザーが Xbox Live にサインインしているかどうかに関係なく含まれます。</span><span class="sxs-lookup"><span data-stu-id="aa777-117">The usage data for Xbox games is included here regardless of whether the customer was signed into Xbox Live.</span></span> 


## <a name="usage"></a><span data-ttu-id="aa777-118">使用状況</span><span class="sxs-lookup"><span data-stu-id="aa777-118">Usage</span></span>

<span data-ttu-id="aa777-119">**[使用状況]** グラフからは、選択された期間中にアプリがどのように使われたかについて詳しく知ることができます。</span><span class="sxs-lookup"><span data-stu-id="aa777-119">The **Usage** chart shows details about how your customers are using your app over the selected period of time.</span></span> <span data-ttu-id="aa777-120">このグラフでは、アプリの一意のユーザーまたは一意のユーザー セッションは追跡されないことに注意してください (つまり、ユーザーがその日にアプリを 1 回しか使っていなくても、複数回使っていても、1 ユーザーとしてカウントされます)。</span><span class="sxs-lookup"><span data-stu-id="aa777-120">Note this chart does not track unique users for your app or unique user sessions (that is, a user is represented in this chart whether they used your app just once or multiple times).</span></span>

<span data-ttu-id="aa777-121">このグラフには、参照できるタブが 4 つあり、それぞれ (指定された期間に応じて) 日次または週次での使用状況を示しています。</span><span class="sxs-lookup"><span data-stu-id="aa777-121">This chart has four separate tabs that you can view, showing usage by day or week (depending on the duration you've selected).</span></span>

- <span data-ttu-id="aa777-122">**[ユーザー]**: 選択した期間の**ユーザー セッション数**の合計を示します。</span><span class="sxs-lookup"><span data-stu-id="aa777-122">**Users**: Shows the total number of **user sessions** over the selected period of time.</span></span> <span data-ttu-id="aa777-123">各ユーザー セッションは、個別の期間を表します。各期間は、アプリが起動 (プロセスが開始) したときに始まり、アプリの終了 (プロセスの終了) 時または非アクティブな状態が一定期間続いた後に終わります。</span><span class="sxs-lookup"><span data-stu-id="aa777-123">Each user session represents a distinct period of time, starting when the app launches (process start) and ending when it terminates (process end) or after a period of inactivity.</span></span> <span data-ttu-id="aa777-124">このため、1 人のユーザーに、同じ日または同じ週に複数のユーザー セッションが関連付けられている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="aa777-124">Because of this, a single customer could have multiple user sessions over the same day or week.</span></span> <span data-ttu-id="aa777-125">**アクティブ ユーザー** (その日または週にアプリを使用している顧客) と**新しいユーザー** (その日または週に初めてアプリを使用した顧客) の合計も表示されます。</span><span class="sxs-lookup"><span data-stu-id="aa777-125">The total number of **Active users** (any customer using the app that day or week) and **New users** (a customer who used your app for the first time that day or week) are also shown.</span></span> <span data-ttu-id="aa777-126">ただし、ページにフィルターを適用している場合は、**新しいユーザー**はこのグラフに表示されないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="aa777-126">Note that if you have applied any filters to the page, you won't see **New users** in this chart.</span></span>
- <span data-ttu-id="aa777-127">**[デバイス]**: 全ユーザーを対象に、アプリの操作に使われたデバイス数を日単位で示します。</span><span class="sxs-lookup"><span data-stu-id="aa777-127">**Devices**: Shows the number of daily devices used to interact with your app by all users.</span></span>
- <span data-ttu-id="aa777-128">**[長さ]**: エンゲージメント時間 (ユーザーが実際にアプリを使用した時間) の合計を時間単位で示します。</span><span class="sxs-lookup"><span data-stu-id="aa777-128">**Duration**: Shows the total engagement hours (hours where a user is actively using your app).</span></span>
- <span data-ttu-id="aa777-129">**エンゲージメント**: ユーザー (すべてのユーザー セッションの平均期間) あたり平均エンゲージメント分を示しています。</span><span class="sxs-lookup"><span data-stu-id="aa777-129">**Engagement**: Shows the average engagement minutes per user (average duration of all user sessions).</span></span> 
- <span data-ttu-id="aa777-130">**[Retention]** (リテンション期間): 選んだ期間中の **DAU/MAU** (日次アクティブ ユーザー数/月間アクティブ ユーザー数) の合計を示します。</span><span class="sxs-lookup"><span data-stu-id="aa777-130">**Retention**: Shows the total number of **DAU/MAU** (Daily Active Users/Monthly Active Users) over the selected period of time.</span></span>

<span data-ttu-id="aa777-131">**30 日間**の期間を選択すると、**ユーザー**、**デバイス**、または**期間**のタブを表示するとき、円形のマーカーを表示があります。</span><span class="sxs-lookup"><span data-stu-id="aa777-131">When the **30D** time period is selected, you may see circle markers when viewing the **Users**, **Devices**, or **Duration** tabs.</span></span> <span data-ttu-id="aa777-132">これらは、大幅に増加を表すまたは特定の値について理解しているたいと考えることが減少します。</span><span class="sxs-lookup"><span data-stu-id="aa777-132">These represent a significant increase or decrease in a given value that we think you'll want to know about.</span></span> <span data-ttu-id="aa777-133">円が表示されている日付は、大幅に増加または減少それより前に、の週との比較を検出しました週の終わりを表します。</span><span class="sxs-lookup"><span data-stu-id="aa777-133">The date on which the circle appears represents the end of the week in which we detected a significant increase or decrease compared to the week before that.</span></span> <span data-ttu-id="aa777-134">変更された内容に関する詳細を表示するには、円の上に置きます。</span><span class="sxs-lookup"><span data-stu-id="aa777-134">To see more details about what's changed, hover over the circle.</span></span>  

> [!TIP]
> <span data-ttu-id="aa777-135">[インサイト レポート](insights-report.md)で過去 30 日間の大幅な変更に関連する他の情報を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="aa777-135">You can view more insights related to significant changes over the last 30 days in the [Insights report](insights-report.md).</span></span>


## <a name="user-sessions"></a><span data-ttu-id="aa777-136">ユーザー セッション</span><span class="sxs-lookup"><span data-stu-id="aa777-136">User sessions</span></span>

<span data-ttu-id="aa777-137">**[ユーザー セッション]** グラフには、選んだ期間中のアプリに対するユーザー セッション数の合計が市場ごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="aa777-137">The **User sessions** chart shows the total number of user sessions for your app per market, over the selected period of time.</span></span>

<span data-ttu-id="aa777-138">**[使用状況]** グラフの **[ユーザー セッション]** の情報と同様に、1 ユーザー セッションはユーザーがアプリを操作した一期間を表します。このグラフでは、アプリの一意のユーザーは追跡されません。</span><span class="sxs-lookup"><span data-stu-id="aa777-138">As with the **User sessions** info in the **Usage** chart, a user session represents one distinct period of time when a customer interacted with your app, and this chart does not track unique users for your app.</span></span>

<span data-ttu-id="aa777-139">このデータは**マップ** フォームで視覚化して表示することも、設定を切り替えて**テーブル** フォームで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="aa777-139">You can view this data in a visual **Map** form, or toggle the setting to view it in **Table** form.</span></span> <span data-ttu-id="aa777-140">テーブル フォームでは一度に 5 つの市場を表示でき、アルファベット順か、ユーザー セッション数の多い順か少ない順で並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="aa777-140">Table form will show five markets at a time, sorted either alphabetically or by highest/lowest number of user sessions.</span></span> <span data-ttu-id="aa777-141">また、データをダウンロードして、すべての市場の情報をまとめて閲覧することもできます。</span><span class="sxs-lookup"><span data-stu-id="aa777-141">You can also download the data to view info for all markets together.</span></span>


## <a name="package-version"></a><span data-ttu-id="aa777-142">パッケージ バージョン</span><span class="sxs-lookup"><span data-stu-id="aa777-142">Package version</span></span>

<span data-ttu-id="aa777-143">**[ユーザー セッション]** グラフには、指定した期間内での、アプリに対する日次のユーザー セッションの合計数がパッケージ バージョンごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="aa777-143">The **User sessions** chart shows the total number of daily user sessions for your app per package version over the selected period of time.</span></span>

<span data-ttu-id="aa777-144">**[ユーザー セッション]** グラフと同様に、1 ユーザー セッションはユーザーがアプリを操作した一期間を表します。このグラフでは、アプリの一意のユーザーは追跡されません。</span><span class="sxs-lookup"><span data-stu-id="aa777-144">As with the **User sessions** chart, a user session represents one distinct period of time when a customer interacted with your app, and this chart does not track unique users for your app.</span></span>


## <a name="custom-events"></a><span data-ttu-id="aa777-145">カスタム イベント</span><span class="sxs-lookup"><span data-stu-id="aa777-145">Custom events</span></span>

<span data-ttu-id="aa777-146">**[カスタム イベント]** グラフには、アプリに定義したカスタム イベントが発生した合計回数が示されます。</span><span class="sxs-lookup"><span data-stu-id="aa777-146">The **Custom events** chart shows the total occurrences for custom events that you have defined for your app.</span></span> <span data-ttu-id="aa777-147">この回数には、それらのイベントが同じユーザーによって複数回発生した場合も含まれます。</span><span class="sxs-lookup"><span data-stu-id="aa777-147">This may include multiple occurrences for the same customer.</span></span> <span data-ttu-id="aa777-148">フィルターを使って特定のカスタム イベントを選び、このデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="aa777-148">You can use the filters to select the specific custom events for which you want to see this data.</span></span>

<span data-ttu-id="aa777-149">カスタム イベントは、[Microsoft Store Services SDK](../monetize/microsoft-store-services-sdk.md) の [StoreServicesCustomEventLogger.Log](https://docs.microsoft.com/en-us/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) メソッドを使って実装されています。</span><span class="sxs-lookup"><span data-stu-id="aa777-149">Custom events are implemented using the [StoreServicesCustomEventLogger.Log](https://docs.microsoft.com/en-us/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) method in the [Microsoft Store Services SDK](../monetize/microsoft-store-services-sdk.md).</span></span>

<span data-ttu-id="aa777-150">詳しくは、「[デベロッパー センターのカスタム イベントをログに記録する](../monetize/log-custom-events-for-dev-center.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="aa777-150">For more info, see [Log custom events for Dev Center](../monetize/log-custom-events-for-dev-center.md).</span></span>


## <a name="custom-events-breakdown"></a><span data-ttu-id="aa777-151">[Custom events breakdown] (カスタム イベントの内訳)</span><span class="sxs-lookup"><span data-stu-id="aa777-151">Custom events breakdown</span></span>

<span data-ttu-id="aa777-152">**[Custom events breakdown] (カスタム イベントの内訳)** グラフは、各カスタム イベントの発生頻度について詳しい情報を示します。</span><span class="sxs-lookup"><span data-stu-id="aa777-152">The **Custom events breakdown** chart shows more details about how often each of your custom events occurred.</span></span> <span data-ttu-id="aa777-153">これは、特定の市場、デバイスの種類、またはパッケージ バージョンでイベントの発生頻度が高くなっているかどうかを知る参考になります。</span><span class="sxs-lookup"><span data-stu-id="aa777-153">This can help you determine if events are occurring more often for a particular market, device type, or package versions.</span></span>

<span data-ttu-id="aa777-154">ユーザーの市場、デバイスの種類、パッケージ バージョンの特定の組み合わせに対して、各イベントの名前と発生回数が示されます。</span><span class="sxs-lookup"><span data-stu-id="aa777-154">For each event, you will see the event name and an event count that correspond to a specific combination of the user's market, device type, and package version.</span></span> <span data-ttu-id="aa777-155">通常、これらの要素の組み合わせは複数あるので、1 つのイベントが複数表示されます。</span><span class="sxs-lookup"><span data-stu-id="aa777-155">Typically, you'll see an event listed multiple times along with different combinations of these factors.</span></span> 




 
