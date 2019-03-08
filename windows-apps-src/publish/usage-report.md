---
Description: パートナー センターでの使用状況レポートでは、顧客がアプリを使用する方法を確認できます。
title: 利用状況レポート
ms.assetid: 5F0E7F94-D121-4AD3-A6E5-9C0DEC437BD3
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, 使用状況, カスタム イベント, レポート, 利用統計情報, ユーザー セッション
ms.localizationpriority: medium
ms.openlocfilehash: 0d0be1399ebc00ffda57ecf27a72be994fa994ce
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610907"
---
# <a name="usage-report"></a><span data-ttu-id="c6c6d-104">利用状況レポート</span><span class="sxs-lookup"><span data-stu-id="c6c6d-104">Usage report</span></span>


<span data-ttu-id="c6c6d-105">**使用状況**レポート[パートナー センター](https://partner.microsoft.com/dashboard) (Xbox を含む)、Windows 10 でのお客様に、アプリを使用している方法を確認することができ、定義したカスタム イベントに関する情報を示しています。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-105">The **Usage** report in [Partner Center](https://partner.microsoft.com/dashboard) lets you see how customers on Windows 10 (including Xbox) are using your app, and shows info about custom events that you've defined.</span></span> <span data-ttu-id="c6c6d-106">パートナー センターでこのデータを表示または[レポートをダウンロード](download-analytic-reports.md)オフラインで表示します。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-106">You can view this data in Partner Center, or [download the report](download-analytic-reports.md) to view offline.</span></span>


## <a name="apply-filters"></a><span data-ttu-id="c6c6d-107">フィルターの適用</span><span class="sxs-lookup"><span data-stu-id="c6c6d-107">Apply filters</span></span>

<span data-ttu-id="c6c6d-108">ページの上部で、データを表示する期間を選択できます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-108">Near the top of the page, you can select the time period for which you want to show data.</span></span> <span data-ttu-id="c6c6d-109">既定では **[30 日間]** が選択されていますが、3、6、12 か月間のデータや、指定した任意の期間のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-109">The default selection is **30D** (30 days), but you can choose to show data for 3, 6, or 12 months, or for a custom data range that you specify.</span></span>

<span data-ttu-id="c6c6d-110">このページにある **[フィルター]** を展開して、このページのデータをパッケージ バージョンや市場、デバイスの種類を基にフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-110">You can also expand **Filters** to filter the data on this page by package version, market, and/or device type.</span></span>

-   <span data-ttu-id="c6c6d-111">**パッケージ バージョン**:既定の設定は**すべて**します。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-111">**Package version**: The default setting is **All**.</span></span> <span data-ttu-id="c6c6d-112">アプリに複数のパッケージが含まれる場合、ここで特定のパッケージを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-112">If your app includes more than one package, you can choose a specific one here.</span></span>
-   <span data-ttu-id="c6c6d-113">**市場**:既定のフィルター**すべての市場**、1 つまたは複数の市場にデータを制限できます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-113">**Market**: The default filter is **All markets**, but you can limit the data to one or more markets.</span></span>
-   <span data-ttu-id="c6c6d-114">**デバイスの種類**:既定の設定は**すべて**が、1 つだけ特定のデバイスの種類 (PC、コンソール、タブレットなど) のデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-114">**Device type**: The default setting is **All**, but you can choose to show data for only one specific device type (PC, console, tablet, etc.).</span></span>

<span data-ttu-id="c6c6d-115">以下のすべてのグラフに示される情報は、選択した日付の範囲とフィルターが適用されます (ただし、**[使用状況]** グラフの**新しいユーザー**は例外で、この情報はフィルターが選択されていると表示されません)。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-115">The info in all of the charts listed below will reflect the date range and any filters you've selected (with the exception of **New users** in the **Usage** chart, which will not appear if any filters are selected).</span></span> <span data-ttu-id="c6c6d-116">セクションの中には、追加のフィルターを適用できるものもあります。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-116">Some sections also allow you to apply additional filters.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c6c6d-117">このレポートに含まれるのは、Windows 10 ユーザー (Xbox ユーザーを含む) で製品利用統計情報の提供を辞退していないユーザーの使用状況データのみです。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-117">This report only includes usage data from customers on Windows 10 (including Xbox) who have not opted out of providing telemetry info.</span></span> <span data-ttu-id="c6c6d-118">Xbox ゲームの使用状況データは、ユーザーが Xbox Live にサインインしているかどうかに関係なく含まれます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-118">The usage data for Xbox games is included here regardless of whether the customer was signed into Xbox Live.</span></span> 


## <a name="usage"></a><span data-ttu-id="c6c6d-119">使用方法</span><span class="sxs-lookup"><span data-stu-id="c6c6d-119">Usage</span></span>

<span data-ttu-id="c6c6d-120">**[使用状況]** グラフからは、選択された期間中にアプリがどのように使われたかについて詳しく知ることができます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-120">The **Usage** chart shows details about how your customers are using your app over the selected period of time.</span></span> <span data-ttu-id="c6c6d-121">このグラフでは、アプリの一意のユーザーまたは一意のユーザー セッションは追跡されないことに注意してください (つまり、ユーザーがその日にアプリを 1 回しか使っていなくても、複数回使っていても、1 ユーザーとしてカウントされます)。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-121">Note this chart does not track unique users for your app or unique user sessions (that is, a user is represented in this chart whether they used your app just once or multiple times).</span></span>

<span data-ttu-id="c6c6d-122">このグラフには、使用状況を表示するには、日または週 (に応じて選択した期間) を表示する別のタブがあります。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-122">This chart has separate tabs that you can view, showing usage by day or week (depending on the duration you've selected).</span></span>

- <span data-ttu-id="c6c6d-123">**Users**:合計数を示します**ユーザー セッション**選択した期間にわたっています。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-123">**Users**: Shows the total number of **user sessions** over the selected period of time.</span></span> <span data-ttu-id="c6c6d-124">各ユーザー セッションは、個別の期間を表します。各期間は、アプリが起動 (プロセスが開始) したときに始まり、アプリの終了 (プロセスの終了) 時または非アクティブな状態が一定期間続いた後に終わります。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-124">Each user session represents a distinct period of time, starting when the app launches (process start) and ending when it terminates (process end) or after a period of inactivity.</span></span> <span data-ttu-id="c6c6d-125">このため、1 人のユーザーに、同じ日または同じ週に複数のユーザー セッションが関連付けられている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-125">Because of this, a single customer could have multiple user sessions over the same day or week.</span></span> <span data-ttu-id="c6c6d-126">**アクティブ ユーザー** (その日または週にアプリを使用している顧客) と**新しいユーザー** (その日または週に初めてアプリを使用した顧客) の合計も表示されます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-126">The total number of **Active users** (any customer using the app that day or week) and **New users** (a customer who used your app for the first time that day or week) are also shown.</span></span> <span data-ttu-id="c6c6d-127">ただし、ページにフィルターを適用している場合は、**新しいユーザー**はこのグラフに表示されないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-127">Note that if you have applied any filters to the page, you won't see **New users** in this chart.</span></span>
- <span data-ttu-id="c6c6d-128">**デバイス**:すべてのユーザーがアプリと対話に使用される 1 日のデバイスの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-128">**Devices**: Shows the number of daily devices used to interact with your app by all users.</span></span>
- <span data-ttu-id="c6c6d-129">**期間**:Engagement の合計時間 (ユーザーが積極的にアプリで使用して、時間単位) を示しています。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-129">**Duration**: Shows the total engagement hours (hours where a user is actively using your app).</span></span>
- <span data-ttu-id="c6c6d-130">**Engagement**:ユーザー (すべてのユーザー セッションの平均実行時間) ごとの平均の契約分を示しています。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-130">**Engagement**: Shows the average engagement minutes per user (average duration of all user sessions).</span></span> 
- <span data-ttu-id="c6c6d-131">**保有期間**:合計数を示します**DAU/MAU** (日次アクティブ ユーザー/月アクティブなユーザー)、選択した期間にわたっています。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-131">**Retention**: Shows the total number of **DAU/MAU** (Daily Active Users/Monthly Active Users) over the selected period of time.</span></span>
- <span data-ttu-id="c6c6d-132">**チャーン予測**:停止する可能性を予測するユーザーの数を示します、アプリをすぐを使用して、最近の使用量に基づいています。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-132">**Churn prediction**: Shows how many users we predict are likely to stop using your app soon, based on their recent usage.</span></span>

<span data-ttu-id="c6c6d-133">ときに、 **30 D**期間を選択すると、表示するときに、円のマーカーを表示可能性があります、**ユーザー**、**デバイス**、または**期間**タブ。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-133">When the **30D** time period is selected, you may see circle markers when viewing the **Users**, **Devices**, or **Duration** tabs.</span></span> <span data-ttu-id="c6c6d-134">これらは大幅な増加を表すまたは知りたいと思われる特定の値が減少します。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-134">These represent a significant increase or decrease in a given value that we think you'll want to know about.</span></span> <span data-ttu-id="c6c6d-135">円が表示される日付は、大幅に増加または減少するより前に、の週と比較を検出しました週の終わりを表します。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-135">The date on which the circle appears represents the end of the week in which we detected a significant increase or decrease compared to the week before that.</span></span> <span data-ttu-id="c6c6d-136">変更内容の詳細を表示するには、円を合わせます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-136">To see more details about what's changed, hover over the circle.</span></span>  

> [!TIP]
> <span data-ttu-id="c6c6d-137">過去 30 日間に大幅な変更に関連するその他の情報を表示することができます、 [Insights レポート](insights-report.md)します。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-137">You can view more insights related to significant changes over the last 30 days in the [Insights report](insights-report.md).</span></span>


## <a name="user-sessions"></a><span data-ttu-id="c6c6d-138">ユーザー セッション</span><span class="sxs-lookup"><span data-stu-id="c6c6d-138">User sessions</span></span>

<span data-ttu-id="c6c6d-139">**[ユーザー セッション]** グラフには、選んだ期間中のアプリに対するユーザー セッション数の合計が市場ごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-139">The **User sessions** chart shows the total number of user sessions for your app per market, over the selected period of time.</span></span>

<span data-ttu-id="c6c6d-140">**[使用状況]** グラフの **[ユーザー セッション]** の情報と同様に、1 ユーザー セッションはユーザーがアプリを操作した一期間を表します。このグラフでは、アプリの一意のユーザーは追跡されません。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-140">As with the **User sessions** info in the **Usage** chart, a user session represents one distinct period of time when a customer interacted with your app, and this chart does not track unique users for your app.</span></span>

<span data-ttu-id="c6c6d-141">このデータは**マップ** フォームで視覚化して表示することも、設定を切り替えて**テーブル** フォームで表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-141">You can view this data in a visual **Map** form, or toggle the setting to view it in **Table** form.</span></span> <span data-ttu-id="c6c6d-142">テーブル フォームでは一度に 5 つの市場を表示でき、アルファベット順か、ユーザー セッション数の多い順か少ない順で並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-142">Table form will show five markets at a time, sorted either alphabetically or by highest/lowest number of user sessions.</span></span> <span data-ttu-id="c6c6d-143">また、データをダウンロードして、すべての市場の情報をまとめて閲覧することもできます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-143">You can also download the data to view info for all markets together.</span></span>


## <a name="package-version"></a><span data-ttu-id="c6c6d-144">パッケージ バージョン</span><span class="sxs-lookup"><span data-stu-id="c6c6d-144">Package version</span></span>

<span data-ttu-id="c6c6d-145">**[ユーザー セッション]** グラフには、指定した期間内での、アプリに対する日次のユーザー セッションの合計数がパッケージ バージョンごとに示されます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-145">The **User sessions** chart shows the total number of daily user sessions for your app per package version over the selected period of time.</span></span>

<span data-ttu-id="c6c6d-146">**[ユーザー セッション]** グラフと同様に、1 ユーザー セッションはユーザーがアプリを操作した一期間を表します。このグラフでは、アプリの一意のユーザーは追跡されません。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-146">As with the **User sessions** chart, a user session represents one distinct period of time when a customer interacted with your app, and this chart does not track unique users for your app.</span></span>


## <a name="custom-events"></a><span data-ttu-id="c6c6d-147">カスタム イベント</span><span class="sxs-lookup"><span data-stu-id="c6c6d-147">Custom events</span></span>

<span data-ttu-id="c6c6d-148">**[カスタム イベント]** グラフには、アプリに定義したカスタム イベントが発生した合計回数が示されます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-148">The **Custom events** chart shows the total occurrences for custom events that you have defined for your app.</span></span> <span data-ttu-id="c6c6d-149">この回数には、それらのイベントが同じお客様によって複数回発生した場合も含まれます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-149">This may include multiple occurrences for the same customer.</span></span> <span data-ttu-id="c6c6d-150">フィルターを使って特定のカスタム イベントを選び、このデータを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-150">You can use the filters to select the specific custom events for which you want to see this data.</span></span>

<span data-ttu-id="c6c6d-151">カスタム イベントは、[Microsoft Store Services SDK](../monetize/microsoft-store-services-sdk.md) の [StoreServicesCustomEventLogger.Log](https://docs.microsoft.com/en-us/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) メソッドを使って実装されています。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-151">Custom events are implemented using the [StoreServicesCustomEventLogger.Log](https://docs.microsoft.com/en-us/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) method in the [Microsoft Store Services SDK](../monetize/microsoft-store-services-sdk.md).</span></span>

<span data-ttu-id="c6c6d-152">詳しくは、「[デベロッパー センターのカスタム イベントをログに記録する](../monetize/log-custom-events-for-dev-center.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-152">For more info, see [Log custom events for Dev Center](../monetize/log-custom-events-for-dev-center.md).</span></span>


## <a name="custom-events-breakdown"></a><span data-ttu-id="c6c6d-153">[Custom events breakdown] (カスタム イベントの内訳)</span><span class="sxs-lookup"><span data-stu-id="c6c6d-153">Custom events breakdown</span></span>

<span data-ttu-id="c6c6d-154">**[Custom events breakdown] (カスタム イベントの内訳)** グラフは、各カスタム イベントの発生頻度について詳しい情報を示します。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-154">The **Custom events breakdown** chart shows more details about how often each of your custom events occurred.</span></span> <span data-ttu-id="c6c6d-155">これは、特定の市場、デバイスの種類、またはパッケージ バージョンでイベントの発生頻度が高くなっているかどうかを知る参考になります。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-155">This can help you determine if events are occurring more often for a particular market, device type, or package versions.</span></span>

<span data-ttu-id="c6c6d-156">ユーザーの市場、デバイスの種類、パッケージ バージョンの特定の組み合わせに対して、各イベントの名前と発生回数が示されます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-156">For each event, you will see the event name and an event count that correspond to a specific combination of the user's market, device type, and package version.</span></span> <span data-ttu-id="c6c6d-157">通常、これらの要素の組み合わせは複数あるので、1 つのイベントが複数表示されます。</span><span class="sxs-lookup"><span data-stu-id="c6c6d-157">Typically, you'll see an event listed multiple times along with different combinations of these factors.</span></span> 




 
