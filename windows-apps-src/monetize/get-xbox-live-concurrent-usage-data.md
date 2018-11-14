---
author: Xansky
description: Xbox Live の同時使用状況データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live の同時使用状況データの取得
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, 同時使用状況
ms.localizationpriority: medium
ms.openlocfilehash: 4506176dcd62a4699c57343c50dfc1b0e7a40b14
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6654861"
---
# <a name="get-xbox-live-concurrent-usage-data"></a><span data-ttu-id="a589a-104">Xbox Live の同時使用状況データの取得</span><span class="sxs-lookup"><span data-stu-id="a589a-104">Get Xbox Live concurrent usage data</span></span>


<span data-ttu-id="a589a-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)をプレイしたユーザーの平均数について、分単位、時間単位、または日単位でリアルタイムに近い使用状況データ (5 ～ 15 分の遅延) を取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="a589a-105">Use this method in the Microsoft Store analytics API to get near real-time usage data (with 5-15 minutes latency) about the average number of customers playing your [Xbox Live-enabled game](../xbox-live/index.md) every minute, hour, or day during a specified time range.</span></span> <span data-ttu-id="a589a-106">この情報は、 [Xbox 分析レポート](../publish/xbox-analytics-report.md)では、パートナー センターで利用可能なもできます。</span><span class="sxs-lookup"><span data-stu-id="a589a-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in Partner Center.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a589a-107">このメソッドは、Xbox のゲームまたは Xbox Live サービスを使用するゲームのみサポートします。</span><span class="sxs-lookup"><span data-stu-id="a589a-107">This method only supports games for Xbox or games that use Xbox Live services.</span></span> <span data-ttu-id="a589a-108">これらのゲームは、[概念の承認プロセス](../gaming/concept-approval.md)を完了する必要があります。これには、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)が発行したゲームと [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)を介して申請されたゲームが含まれます。</span><span class="sxs-lookup"><span data-stu-id="a589a-108">These games must go through the [concept approval process](../gaming/concept-approval.md), which includes games published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) and games submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="a589a-109">このメソッドでは、[Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)を介して発行されたゲームは現在サポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a589a-109">This method does not currently support games published via the [Xbox Live Creators Program](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="a589a-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="a589a-110">Prerequisites</span></span>

<span data-ttu-id="a589a-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a589a-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="a589a-112">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="a589a-112">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="a589a-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="a589a-113">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="a589a-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="a589a-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="a589a-115">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="a589a-115">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="a589a-116">要求</span><span class="sxs-lookup"><span data-stu-id="a589a-116">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="a589a-117">要求の構文</span><span class="sxs-lookup"><span data-stu-id="a589a-117">Request syntax</span></span>

| <span data-ttu-id="a589a-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="a589a-118">Method</span></span> | <span data-ttu-id="a589a-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a589a-119">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="a589a-120">GET</span><span class="sxs-lookup"><span data-stu-id="a589a-120">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="a589a-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a589a-121">Request header</span></span>

| <span data-ttu-id="a589a-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a589a-122">Header</span></span>        | <span data-ttu-id="a589a-123">型</span><span class="sxs-lookup"><span data-stu-id="a589a-123">Type</span></span>   | <span data-ttu-id="a589a-124">説明</span><span class="sxs-lookup"><span data-stu-id="a589a-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="a589a-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="a589a-125">Authorization</span></span> | <span data-ttu-id="a589a-126">string</span><span class="sxs-lookup"><span data-stu-id="a589a-126">string</span></span> | <span data-ttu-id="a589a-127">必須。</span><span class="sxs-lookup"><span data-stu-id="a589a-127">Required.</span></span> <span data-ttu-id="a589a-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="a589a-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="a589a-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="a589a-129">Request parameters</span></span>


| <span data-ttu-id="a589a-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a589a-130">Parameter</span></span>        | <span data-ttu-id="a589a-131">型</span><span class="sxs-lookup"><span data-stu-id="a589a-131">Type</span></span>   |  <span data-ttu-id="a589a-132">説明</span><span class="sxs-lookup"><span data-stu-id="a589a-132">Description</span></span>      |  <span data-ttu-id="a589a-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="a589a-133">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="a589a-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="a589a-134">applicationId</span></span> | <span data-ttu-id="a589a-135">string</span><span class="sxs-lookup"><span data-stu-id="a589a-135">string</span></span> | <span data-ttu-id="a589a-136">Xbox Live の同時使用状況データを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="a589a-136">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve Xbox Live concurrent usage data.</span></span>  |  <span data-ttu-id="a589a-137">必須</span><span class="sxs-lookup"><span data-stu-id="a589a-137">Yes</span></span>  |
| <span data-ttu-id="a589a-138">metricType</span><span class="sxs-lookup"><span data-stu-id="a589a-138">metricType</span></span> | <span data-ttu-id="a589a-139">string</span><span class="sxs-lookup"><span data-stu-id="a589a-139">string</span></span> | <span data-ttu-id="a589a-140">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="a589a-140">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="a589a-141">このメソッドでは、値 **concurrency** を指定します。</span><span class="sxs-lookup"><span data-stu-id="a589a-141">For this method, specify the value **concurrency**.</span></span>  |  <span data-ttu-id="a589a-142">必須</span><span class="sxs-lookup"><span data-stu-id="a589a-142">Yes</span></span>  |
| <span data-ttu-id="a589a-143">startDate</span><span class="sxs-lookup"><span data-stu-id="a589a-143">startDate</span></span> | <span data-ttu-id="a589a-144">date</span><span class="sxs-lookup"><span data-stu-id="a589a-144">date</span></span> | <span data-ttu-id="a589a-145">取得する同時使用状況データの日付範囲の開始日です。</span><span class="sxs-lookup"><span data-stu-id="a589a-145">The start date in the date range of concurrent usage data to retrieve.</span></span> <span data-ttu-id="a589a-146">既定の動作については *aggregationLevel* の説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a589a-146">See the *aggregationLevel* description for default behavior.</span></span> |  <span data-ttu-id="a589a-147">必須ではない</span><span class="sxs-lookup"><span data-stu-id="a589a-147">No</span></span>  |
| <span data-ttu-id="a589a-148">endDate</span><span class="sxs-lookup"><span data-stu-id="a589a-148">endDate</span></span> | <span data-ttu-id="a589a-149">date</span><span class="sxs-lookup"><span data-stu-id="a589a-149">date</span></span> | <span data-ttu-id="a589a-150">取得する同時使用状況データの日付範囲の終了日です。</span><span class="sxs-lookup"><span data-stu-id="a589a-150">The end date in the date range of concurrent usage data to retrieve.</span></span> <span data-ttu-id="a589a-151">既定の動作については *aggregationLevel* の説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a589a-151">See the *aggregationLevel* description for default behavior.</span></span> |  <span data-ttu-id="a589a-152">必須ではない</span><span class="sxs-lookup"><span data-stu-id="a589a-152">No</span></span>  |
| <span data-ttu-id="a589a-153">aggregationLevel</span><span class="sxs-lookup"><span data-stu-id="a589a-153">aggregationLevel</span></span> | <span data-ttu-id="a589a-154">string</span><span class="sxs-lookup"><span data-stu-id="a589a-154">string</span></span> | <span data-ttu-id="a589a-155">集計データを取得する時間範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="a589a-155">Specifies the time range for which to retrieve aggregate data.</span></span> <span data-ttu-id="a589a-156">**minute**、**hour**、**day** のいずれかの文字列を指定できます。</span><span class="sxs-lookup"><span data-stu-id="a589a-156">Can be one of the following strings: **minute**, **hour**, or **day**.</span></span> <span data-ttu-id="a589a-157">指定しない場合、既定値は **day** です。</span><span class="sxs-lookup"><span data-stu-id="a589a-157">If unspecified, the default is **day**.</span></span> <p/><p/><span data-ttu-id="a589a-158">*startDate* または *endDate* を指定しなかった場合、応答本文は既定で次のようになります。</span><span class="sxs-lookup"><span data-stu-id="a589a-158">If you do not specify *startDate* or *endDate*, the response body defaults to the following:</span></span> <ul><li><span data-ttu-id="a589a-159">**minute**: 利用可能なデータの最新の 60 レコード。</span><span class="sxs-lookup"><span data-stu-id="a589a-159">**minute**: The last 60 records of available data.</span></span></li><li><span data-ttu-id="a589a-160">**hour**: 利用可能なデータの最新の 24 レコード</span><span class="sxs-lookup"><span data-stu-id="a589a-160">**hour**: The last 24 records of available data.</span></span></li><li><span data-ttu-id="a589a-161">**day**: 利用可能なデータの最新の 7 レコード。</span><span class="sxs-lookup"><span data-stu-id="a589a-161">**day**: The last 7 records of available data.</span></span></li></ul><p/><span data-ttu-id="a589a-162">各集計レベルでは、返すことのできるレコード数にサイズ制限があります。</span><span class="sxs-lookup"><span data-stu-id="a589a-162">The following aggregation levels have size limits on the number of records that can be returned.</span></span> <span data-ttu-id="a589a-163">要求された期間が大きすぎる場合、レコードは切り捨てられます。</span><span class="sxs-lookup"><span data-stu-id="a589a-163">The records will be truncated if the requested time span is too large.</span></span> <ul><li><span data-ttu-id="a589a-164">**minute**: 最大 1440 レコード (24 時間のデータ)。</span><span class="sxs-lookup"><span data-stu-id="a589a-164">**minute**: Up to 1440 records (24 hours of data).</span></span></li><li><span data-ttu-id="a589a-165">**hour**: 最大 720 レコード (30 日間のデータ)。</span><span class="sxs-lookup"><span data-stu-id="a589a-165">**hour**: Up to 720 records (30 days of data).</span></span></li><li><span data-ttu-id="a589a-166">**day**: 最大 60 レコード (60 日間のデータ)。</span><span class="sxs-lookup"><span data-stu-id="a589a-166">**day**: Up to 60 records (60 days of data).</span></span></li></ul>  |  <span data-ttu-id="a589a-167">必須ではない</span><span class="sxs-lookup"><span data-stu-id="a589a-167">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="a589a-168">要求の例</span><span class="sxs-lookup"><span data-stu-id="a589a-168">Request example</span></span>

<span data-ttu-id="a589a-169">次の例では、Xbox Live 対応ゲームの同時使用状況データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="a589a-169">The following example demonstrates a request for getting concurrent usage data for your Xbox Live-enabled game.</span></span> <span data-ttu-id="a589a-170">この要求は、2018 年 2 月 1 日から 2018 年 2 月 2 日までの毎分のデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="a589a-170">This request retrieves data for every minute between February 1 2018 and February 2 2018.</span></span> <span data-ttu-id="a589a-171">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="a589a-171">Replace the *applicationId* value with the Store ID for your game.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=concurrency&aggregationLevel=hour&startDate=2018-02-01&endData=2018-02-02 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="a589a-172">応答</span><span class="sxs-lookup"><span data-stu-id="a589a-172">Response</span></span>

<span data-ttu-id="a589a-173">応答本文にはオブジェクトの配列が含まれ、各要素のオブジェクトは、指定された分、時間、または日に対応する同時使用状況データのセットを 1 つ保持します。</span><span class="sxs-lookup"><span data-stu-id="a589a-173">The response body contains an array of objects that each contain one set of concurrent usage data for a specified minute, hour, or day.</span></span> <span data-ttu-id="a589a-174">各オブジェクトには次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a589a-174">Each object contains the following values.</span></span>

| <span data-ttu-id="a589a-175">値</span><span class="sxs-lookup"><span data-stu-id="a589a-175">Value</span></span>      | <span data-ttu-id="a589a-176">型</span><span class="sxs-lookup"><span data-stu-id="a589a-176">Type</span></span>   | <span data-ttu-id="a589a-177">説明</span><span class="sxs-lookup"><span data-stu-id="a589a-177">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="a589a-178">Count</span><span class="sxs-lookup"><span data-stu-id="a589a-178">Count</span></span>      | <span data-ttu-id="a589a-179">number</span><span class="sxs-lookup"><span data-stu-id="a589a-179">number</span></span>  | <span data-ttu-id="a589a-180">指定された分、時間、または日に Xbox Live 対応ゲームをプレイしたユーザーの平均数です。</span><span class="sxs-lookup"><span data-stu-id="a589a-180">The average number of customers playing your Xbox Live-enabled for the specified minute, hour, or day.</span></span> <p/><p/><span data-ttu-id="a589a-181">**注**&nbsp;&nbsp;値 0 は、指定期間に同時ユーザーがいなかったか、指定期間に対するゲームの同時ユーザー データの収集中にエラーが発生したことを示します。</span><span class="sxs-lookup"><span data-stu-id="a589a-181">**Note**&nbsp;&nbsp;A value of 0 indicates either that there were no concurrent users during the specified interval, or that there was a failure while collecting concurrent user data for the game during the specified interval.</span></span> |
| <span data-ttu-id="a589a-182">Date</span><span class="sxs-lookup"><span data-stu-id="a589a-182">Date</span></span>  | <span data-ttu-id="a589a-183">string</span><span class="sxs-lookup"><span data-stu-id="a589a-183">string</span></span> | <span data-ttu-id="a589a-184">同時使用状況データが発生した分、時間、または日を指定する日付と時刻です。</span><span class="sxs-lookup"><span data-stu-id="a589a-184">The date and time that specifies the minute, hour or day during which the concurrent usage data occurred.</span></span>  |
| <span data-ttu-id="a589a-185">SeriesName</span><span class="sxs-lookup"><span data-stu-id="a589a-185">SeriesName</span></span> | <span data-ttu-id="a589a-186">string</span><span class="sxs-lookup"><span data-stu-id="a589a-186">string</span></span>    | <span data-ttu-id="a589a-187">この値は常に **UserConcurrency** になります。</span><span class="sxs-lookup"><span data-stu-id="a589a-187">This always has the value **UserConcurrency**.</span></span> |


### <a name="response-example"></a><span data-ttu-id="a589a-188">応答の例</span><span class="sxs-lookup"><span data-stu-id="a589a-188">Response example</span></span>

<span data-ttu-id="a589a-189">分単位のデータ集計要求に対する JSON 応答本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a589a-189">The following example demonstrates an example JSON response body for this request with data aggregation by minute.</span></span>

```json
[   {
        "Count": 418.0,
        "Date": "2018-02-02T04:42:13.65Z",
        "SeriesName": "UserConcurrency"
    }, {
        "Count": 418.0,
        "Date": "2018-02-02T04:43:13.65Z",
        "SeriesName": "UserConcurrency"
    }, {
        "Count": 415.0,
        "Date": "2018-02-02T04:44:13.65Z",
        "SeriesName": "UserConcurrency"
    }, {
        "Count": 412.0,
        "Date": "2018-02-02T04:45:13.65Z",
        "SeriesName": "UserConcurrency"
    }, {
        "Count": 414.0,
        "Date": "2018-02-02T04:46:13.65Z",
        "SeriesName": "UserConcurrency"
    }
]
```

## <a name="related-topics"></a><span data-ttu-id="a589a-190">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a589a-190">Related topics</span></span>

* [<span data-ttu-id="a589a-191">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="a589a-191">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="a589a-192">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="a589a-192">Get Xbox Live analytics data</span></span>](get-xbox-live-analytics.md)
* [<span data-ttu-id="a589a-193">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="a589a-193">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="a589a-194">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="a589a-194">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="a589a-195">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="a589a-195">Get Xbox Live game hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="a589a-196">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="a589a-196">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="a589a-197">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="a589a-197">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
