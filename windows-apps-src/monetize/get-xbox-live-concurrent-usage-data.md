---
author: mcleanbyron
description: Xbox Live の同時使用状況データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live の同時使用状況データの取得
ms.author: mcleans
ms.date: 04/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, 同時使用状況
ms.localizationpriority: medium
ms.openlocfilehash: b739c9ac3ce9fe4501ecaa1071df4fd3901484ab
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1816247"
---
# <a name="get-xbox-live-concurrent-usage-data"></a><span data-ttu-id="3ffc5-104">Xbox Live の同時使用状況データの取得</span><span class="sxs-lookup"><span data-stu-id="3ffc5-104">Get Xbox Live concurrent usage data</span></span>


<span data-ttu-id="3ffc5-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)をプレイしたユーザーの平均数について、分単位、時間単位、または日単位でリアルタイムに近い使用状況データ (5 ～ 15 分の遅延) を取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-105">Use this method in the Microsoft Store analytics API to get near real-time usage data (with 5-15 minutes latency) about the average number of customers playing your [Xbox Live-enabled game](../xbox-live/index.md) every minute, hour, or day during a specified time range.</span></span> <span data-ttu-id="3ffc5-106">この情報は、Windows デベロッパー センター ダッシュボードの [Xbox 分析レポート](../publish/xbox-analytics-report.md)でも確認できます。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in the Windows Dev Center dashboard.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3ffc5-107">現在このメソッドがサポートしているのは、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)によって公開された Xbox Live 対応ゲーム、または [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)経由で提出された Xbox Live 対応ゲームだけです。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-107">This method currently only supports Xbox Live-enabled games that are published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) or that are submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="3ffc5-108">[Xbox Live クリエーターズ プログラム](../xbox-live/developer-program-overview.md#xbox-live-creators-program)経由で提出されたゲームのデータは返されません。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-108">It does not return data for games that were submitted via the [Xbox Live Creators Program](../xbox-live/developer-program-overview.md#xbox-live-creators-program).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="3ffc5-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="3ffc5-109">Prerequisites</span></span>

<span data-ttu-id="3ffc5-110">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-110">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="3ffc5-111">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-111">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="3ffc5-112">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-112">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="3ffc5-113">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-113">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="3ffc5-114">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-114">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="3ffc5-115">要求</span><span class="sxs-lookup"><span data-stu-id="3ffc5-115">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="3ffc5-116">要求の構文</span><span class="sxs-lookup"><span data-stu-id="3ffc5-116">Request syntax</span></span>

| <span data-ttu-id="3ffc5-117">メソッド</span><span class="sxs-lookup"><span data-stu-id="3ffc5-117">Method</span></span> | <span data-ttu-id="3ffc5-118">要求 URI</span><span class="sxs-lookup"><span data-stu-id="3ffc5-118">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="3ffc5-119">GET</span><span class="sxs-lookup"><span data-stu-id="3ffc5-119">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="3ffc5-120">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ffc5-120">Request header</span></span>

| <span data-ttu-id="3ffc5-121">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ffc5-121">Header</span></span>        | <span data-ttu-id="3ffc5-122">型</span><span class="sxs-lookup"><span data-stu-id="3ffc5-122">Type</span></span>   | <span data-ttu-id="3ffc5-123">説明</span><span class="sxs-lookup"><span data-stu-id="3ffc5-123">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3ffc5-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="3ffc5-124">Authorization</span></span> | <span data-ttu-id="3ffc5-125">文字列</span><span class="sxs-lookup"><span data-stu-id="3ffc5-125">string</span></span> | <span data-ttu-id="3ffc5-126">必須。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-126">Required.</span></span> <span data-ttu-id="3ffc5-127">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-127">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="3ffc5-128">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ffc5-128">Request parameters</span></span>


| <span data-ttu-id="3ffc5-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ffc5-129">Parameter</span></span>        | <span data-ttu-id="3ffc5-130">型</span><span class="sxs-lookup"><span data-stu-id="3ffc5-130">Type</span></span>   |  <span data-ttu-id="3ffc5-131">説明</span><span class="sxs-lookup"><span data-stu-id="3ffc5-131">Description</span></span>      |  <span data-ttu-id="3ffc5-132">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3ffc5-132">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="3ffc5-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="3ffc5-133">applicationId</span></span> | <span data-ttu-id="3ffc5-134">string</span><span class="sxs-lookup"><span data-stu-id="3ffc5-134">string</span></span> | <span data-ttu-id="3ffc5-135">Xbox Live の同時使用状況データを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-135">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve Xbox Live concurrent usage data.</span></span>  |  <span data-ttu-id="3ffc5-136">必須</span><span class="sxs-lookup"><span data-stu-id="3ffc5-136">Yes</span></span>  |
| <span data-ttu-id="3ffc5-137">metricType</span><span class="sxs-lookup"><span data-stu-id="3ffc5-137">metricType</span></span> | <span data-ttu-id="3ffc5-138">string</span><span class="sxs-lookup"><span data-stu-id="3ffc5-138">string</span></span> | <span data-ttu-id="3ffc5-139">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-139">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="3ffc5-140">このメソッドでは、値 **concurrency** を指定します。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-140">For this method, specify the value **concurrency**.</span></span>  |  <span data-ttu-id="3ffc5-141">必須</span><span class="sxs-lookup"><span data-stu-id="3ffc5-141">Yes</span></span>  |
| <span data-ttu-id="3ffc5-142">startDate</span><span class="sxs-lookup"><span data-stu-id="3ffc5-142">startDate</span></span> | <span data-ttu-id="3ffc5-143">date</span><span class="sxs-lookup"><span data-stu-id="3ffc5-143">date</span></span> | <span data-ttu-id="3ffc5-144">取得する同時使用状況データの日付範囲の開始日です。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-144">The start date in the date range of concurrent usage data to retrieve.</span></span> <span data-ttu-id="3ffc5-145">既定の動作については *aggregationLevel* の説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-145">See the *aggregationLevel* description for default behavior.</span></span> |  <span data-ttu-id="3ffc5-146">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3ffc5-146">No</span></span>  |
| <span data-ttu-id="3ffc5-147">endDate</span><span class="sxs-lookup"><span data-stu-id="3ffc5-147">endDate</span></span> | <span data-ttu-id="3ffc5-148">date</span><span class="sxs-lookup"><span data-stu-id="3ffc5-148">date</span></span> | <span data-ttu-id="3ffc5-149">取得する同時使用状況データの日付範囲の終了日です。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-149">The end date in the date range of concurrent usage data to retrieve.</span></span> <span data-ttu-id="3ffc5-150">既定の動作については *aggregationLevel* の説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-150">See the *aggregationLevel* description for default behavior.</span></span> |  <span data-ttu-id="3ffc5-151">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3ffc5-151">No</span></span>  |
| <span data-ttu-id="3ffc5-152">aggregationLevel</span><span class="sxs-lookup"><span data-stu-id="3ffc5-152">aggregationLevel</span></span> | <span data-ttu-id="3ffc5-153">string</span><span class="sxs-lookup"><span data-stu-id="3ffc5-153">string</span></span> | <span data-ttu-id="3ffc5-154">集計データを取得する時間範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-154">Specifies the time range for which to retrieve aggregate data.</span></span> <span data-ttu-id="3ffc5-155">**minute**、**hour**、**day** のいずれかの文字列を指定できます。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-155">Can be one of the following strings: **minute**, **hour**, or **day**.</span></span> <span data-ttu-id="3ffc5-156">指定しない場合、既定値は **day** です。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-156">If unspecified, the default is **day**.</span></span> <p/><p/><span data-ttu-id="3ffc5-157">*startDate* または *endDate* を指定しなかった場合、応答本文は既定で次のようになります。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-157">If you do not specify *startDate* or *endDate*, the response body defaults to the following:</span></span> <ul><li><span data-ttu-id="3ffc5-158">**minute**: 利用可能なデータの最新の 60 レコード。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-158">**minute**: The last 60 records of available data.</span></span></li><li><span data-ttu-id="3ffc5-159">**hour**: 利用可能なデータの最新の 24 レコード</span><span class="sxs-lookup"><span data-stu-id="3ffc5-159">**hour**: The last 24 records of available data.</span></span></li><li><span data-ttu-id="3ffc5-160">**day**: 利用可能なデータの最新の 7 レコード。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-160">**day**: The last 7 records of available data.</span></span></li></ul><p/><span data-ttu-id="3ffc5-161">各集計レベルでは、返すことのできるレコード数にサイズ制限があります。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-161">The following aggregation levels have size limits on the number of records that can be returned.</span></span> <span data-ttu-id="3ffc5-162">要求された期間が大きすぎる場合、レコードは切り捨てられます。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-162">The records will be truncated if the requested time span is too large.</span></span> <ul><li><span data-ttu-id="3ffc5-163">**minute**: 最大 1440 レコード (24 時間のデータ)。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-163">**minute**: Up to 1440 records (24 hours of data).</span></span></li><li><span data-ttu-id="3ffc5-164">**hour**: 最大 720 レコード (30 日間のデータ)。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-164">**hour**: Up to 720 records (30 days of data).</span></span></li><li><span data-ttu-id="3ffc5-165">**day**: 最大 60 レコード (60 日間のデータ)。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-165">**day**: Up to 60 records (60 days of data).</span></span></li></ul>  |  <span data-ttu-id="3ffc5-166">必須ではない</span><span class="sxs-lookup"><span data-stu-id="3ffc5-166">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="3ffc5-167">要求の例</span><span class="sxs-lookup"><span data-stu-id="3ffc5-167">Request example</span></span>

<span data-ttu-id="3ffc5-168">次の例では、Xbox Live 対応ゲームの同時使用状況データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-168">The following example demonstrates a request for getting concurrent usage data for your Xbox Live-enabled game.</span></span> <span data-ttu-id="3ffc5-169">この要求は、2018 年 2 月 1 日から 2018 年 2 月 2 日までの毎分のデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-169">This request retrieves data for every minute between February 1 2018 and February 2 2018.</span></span> <span data-ttu-id="3ffc5-170">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-170">Replace the *applicationId* value with the Store ID for your game.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=concurrency&aggregationLevel=hour&startDate=2018-02-01&endData=2018-02-02 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="3ffc5-171">応答</span><span class="sxs-lookup"><span data-stu-id="3ffc5-171">Response</span></span>

<span data-ttu-id="3ffc5-172">応答本文にはオブジェクトの配列が含まれ、各要素のオブジェクトは、指定された分、時間、または日に対応する同時使用状況データのセットを 1 つ保持します。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-172">The response body contains an array of objects that each contain one set of concurrent usage data for a specified minute, hour, or day.</span></span> <span data-ttu-id="3ffc5-173">各オブジェクトには次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-173">Each object contains the following values.</span></span>

| <span data-ttu-id="3ffc5-174">値</span><span class="sxs-lookup"><span data-stu-id="3ffc5-174">Value</span></span>      | <span data-ttu-id="3ffc5-175">型</span><span class="sxs-lookup"><span data-stu-id="3ffc5-175">Type</span></span>   | <span data-ttu-id="3ffc5-176">説明</span><span class="sxs-lookup"><span data-stu-id="3ffc5-176">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="3ffc5-177">Count</span><span class="sxs-lookup"><span data-stu-id="3ffc5-177">Count</span></span>      | <span data-ttu-id="3ffc5-178">number</span><span class="sxs-lookup"><span data-stu-id="3ffc5-178">number</span></span>  | <span data-ttu-id="3ffc5-179">指定された分、時間、または日に Xbox Live 対応ゲームをプレイしたユーザーの平均数です。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-179">The average number of customers playing your Xbox Live-enabled for the specified minute, hour, or day.</span></span> <p/><p/><span data-ttu-id="3ffc5-180">**注**&nbsp;&nbsp;値 0 は、指定期間に同時ユーザーがいなかったか、指定期間に対するゲームの同時ユーザー データの収集中にエラーが発生したことを示します。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-180">**Note**&nbsp;&nbsp;A value of 0 indicates either that there were no concurrent users during the specified interval, or that there was a failure while collecting concurrent user data for the game during the specified interval.</span></span> |
| <span data-ttu-id="3ffc5-181">Date</span><span class="sxs-lookup"><span data-stu-id="3ffc5-181">Date</span></span>  | <span data-ttu-id="3ffc5-182">string</span><span class="sxs-lookup"><span data-stu-id="3ffc5-182">string</span></span> | <span data-ttu-id="3ffc5-183">同時使用状況データが発生した分、時間、または日を指定する日付と時刻です。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-183">The date and time that specifies the minute, hour or day during which the concurrent usage data occurred.</span></span>  |
| <span data-ttu-id="3ffc5-184">SeriesName</span><span class="sxs-lookup"><span data-stu-id="3ffc5-184">SeriesName</span></span> | <span data-ttu-id="3ffc5-185">string</span><span class="sxs-lookup"><span data-stu-id="3ffc5-185">string</span></span>    | <span data-ttu-id="3ffc5-186">この値は常に **UserConcurrency** になります。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-186">This always has the value **UserConcurrency**.</span></span> |


### <a name="response-example"></a><span data-ttu-id="3ffc5-187">応答の例</span><span class="sxs-lookup"><span data-stu-id="3ffc5-187">Response example</span></span>

<span data-ttu-id="3ffc5-188">分単位のデータ集計要求に対する JSON 応答本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3ffc5-188">The following example demonstrates an example JSON response body for this request with data aggregation by minute.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="3ffc5-189">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3ffc5-189">Related topics</span></span>

* [<span data-ttu-id="3ffc5-190">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="3ffc5-190">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="3ffc5-191">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="3ffc5-191">Get Xbox Live analytics data</span></span>](get-xbox-live-analytics.md)
* [<span data-ttu-id="3ffc5-192">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="3ffc5-192">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="3ffc5-193">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="3ffc5-193">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="3ffc5-194">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="3ffc5-194">Get Xbox Live game hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="3ffc5-195">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="3ffc5-195">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="3ffc5-196">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="3ffc5-196">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
