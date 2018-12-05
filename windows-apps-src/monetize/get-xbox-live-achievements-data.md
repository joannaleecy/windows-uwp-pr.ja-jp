---
description: Xbox Live の実績データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live の実績データの取得
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, 実績
ms.localizationpriority: medium
ms.openlocfilehash: 23a99c637dfd466ba21169626315803dec60e4e8
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8692192"
---
# <a name="get-xbox-live-achievements-data"></a><span data-ttu-id="dcc40-104">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="dcc40-104">Get Xbox Live achievements data</span></span>

<span data-ttu-id="dcc40-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)の各実績のロックを解除したユーザーの数を取得するには、Microsoft Store 分析 API の以下のメソッドを使います。実績データがある直近の日付、その日から過去 30 日間、およびゲームのリリースからその日までの期間のデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="dcc40-105">Use this method in the Microsoft Store analytics API to get the number of customers who have unlocked each achievement for your [Xbox Live-enabled game](../xbox-live/index.md) during the most recent day for which achievements data is available, the previous 30 days leading up to that day, and the total lifetime of your game up to that day.</span></span> <span data-ttu-id="dcc40-106">この情報は、 [Xbox 分析レポート](../publish/xbox-analytics-report.md)では、パートナー センターで利用可能なもできます。</span><span class="sxs-lookup"><span data-stu-id="dcc40-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in Partner Center.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="dcc40-107">このメソッドは、Xbox のゲームまたは Xbox Live サービスを使用するゲームのみサポートします。</span><span class="sxs-lookup"><span data-stu-id="dcc40-107">This method only supports games for Xbox or games that use Xbox Live services.</span></span> <span data-ttu-id="dcc40-108">これらのゲームは、[概念の承認プロセス](../gaming/concept-approval.md)を完了する必要があります。これには、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)が発行したゲームと [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)を介して申請されたゲームが含まれます。</span><span class="sxs-lookup"><span data-stu-id="dcc40-108">These games must go through the [concept approval process](../gaming/concept-approval.md), which includes games published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) and games submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="dcc40-109">このメソッドでは、[Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)を介して発行されたゲームは現在サポートされていません。</span><span class="sxs-lookup"><span data-stu-id="dcc40-109">This method does not currently support games published via the [Xbox Live Creators Program](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="dcc40-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="dcc40-110">Prerequisites</span></span>

<span data-ttu-id="dcc40-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="dcc40-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="dcc40-112">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="dcc40-112">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="dcc40-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="dcc40-113">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="dcc40-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="dcc40-115">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="dcc40-115">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="dcc40-116">要求</span><span class="sxs-lookup"><span data-stu-id="dcc40-116">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="dcc40-117">要求の構文</span><span class="sxs-lookup"><span data-stu-id="dcc40-117">Request syntax</span></span>

| <span data-ttu-id="dcc40-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="dcc40-118">Method</span></span> | <span data-ttu-id="dcc40-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="dcc40-119">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="dcc40-120">GET</span><span class="sxs-lookup"><span data-stu-id="dcc40-120">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="dcc40-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="dcc40-121">Request header</span></span>

| <span data-ttu-id="dcc40-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="dcc40-122">Header</span></span>        | <span data-ttu-id="dcc40-123">型</span><span class="sxs-lookup"><span data-stu-id="dcc40-123">Type</span></span>   | <span data-ttu-id="dcc40-124">説明</span><span class="sxs-lookup"><span data-stu-id="dcc40-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="dcc40-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="dcc40-125">Authorization</span></span> | <span data-ttu-id="dcc40-126">string</span><span class="sxs-lookup"><span data-stu-id="dcc40-126">string</span></span> | <span data-ttu-id="dcc40-127">必須。</span><span class="sxs-lookup"><span data-stu-id="dcc40-127">Required.</span></span> <span data-ttu-id="dcc40-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="dcc40-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="dcc40-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="dcc40-129">Request parameters</span></span>


| <span data-ttu-id="dcc40-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="dcc40-130">Parameter</span></span>        | <span data-ttu-id="dcc40-131">型</span><span class="sxs-lookup"><span data-stu-id="dcc40-131">Type</span></span>   |  <span data-ttu-id="dcc40-132">説明</span><span class="sxs-lookup"><span data-stu-id="dcc40-132">Description</span></span>      |  <span data-ttu-id="dcc40-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="dcc40-133">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="dcc40-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="dcc40-134">applicationId</span></span> | <span data-ttu-id="dcc40-135">string</span><span class="sxs-lookup"><span data-stu-id="dcc40-135">string</span></span> | <span data-ttu-id="dcc40-136">Xbox Live の実績データを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-136">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve Xbox Live achievements data.</span></span>  |  <span data-ttu-id="dcc40-137">必須</span><span class="sxs-lookup"><span data-stu-id="dcc40-137">Yes</span></span>  |
| <span data-ttu-id="dcc40-138">metricType</span><span class="sxs-lookup"><span data-stu-id="dcc40-138">metricType</span></span> | <span data-ttu-id="dcc40-139">string</span><span class="sxs-lookup"><span data-stu-id="dcc40-139">string</span></span> | <span data-ttu-id="dcc40-140">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-140">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="dcc40-141">このメソッドでは、値 **achievements** を指定します。</span><span class="sxs-lookup"><span data-stu-id="dcc40-141">For this method, specify the value **achievements**.</span></span>  |  <span data-ttu-id="dcc40-142">必須</span><span class="sxs-lookup"><span data-stu-id="dcc40-142">Yes</span></span>  |
| <span data-ttu-id="dcc40-143">top</span><span class="sxs-lookup"><span data-stu-id="dcc40-143">top</span></span> | <span data-ttu-id="dcc40-144">int</span><span class="sxs-lookup"><span data-stu-id="dcc40-144">int</span></span> | <span data-ttu-id="dcc40-145">要求で返すデータの行数です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-145">The number of rows of data to return in the request.</span></span> <span data-ttu-id="dcc40-146">指定されない場合の既定値は、最大値でもある 10000 です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-146">The maximum value and the default value if not specified is 10000.</span></span> <span data-ttu-id="dcc40-147">クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。</span><span class="sxs-lookup"><span data-stu-id="dcc40-147">If there are more rows in the query, the response body includes a next link that you can use to request the next page of data.</span></span> |  <span data-ttu-id="dcc40-148">必須ではない</span><span class="sxs-lookup"><span data-stu-id="dcc40-148">No</span></span>  |
| <span data-ttu-id="dcc40-149">skip</span><span class="sxs-lookup"><span data-stu-id="dcc40-149">skip</span></span> | <span data-ttu-id="dcc40-150">int</span><span class="sxs-lookup"><span data-stu-id="dcc40-150">int</span></span> | <span data-ttu-id="dcc40-151">クエリでスキップする行数です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-151">The number of rows to skip in the query.</span></span> <span data-ttu-id="dcc40-152">大きなデータ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="dcc40-152">Use this parameter to page through large data sets.</span></span> <span data-ttu-id="dcc40-153">たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。</span><span class="sxs-lookup"><span data-stu-id="dcc40-153">For example, top=10000 and skip=0 retrieves the first 10000 rows of data, top=10000 and skip=10000 retrieves the next 10000 rows of data, and so on.</span></span> |  <span data-ttu-id="dcc40-154">必須ではない</span><span class="sxs-lookup"><span data-stu-id="dcc40-154">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="dcc40-155">要求の例</span><span class="sxs-lookup"><span data-stu-id="dcc40-155">Request example</span></span>

<span data-ttu-id="dcc40-156">次の例では、Xbox Live 対応ゲームで最初の 10 個の実績のロックを解除したユーザーの実績データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="dcc40-156">The following example demonstrates a request for getting achievements data for customers who have unlocked the first 10 achievements for your Xbox Live-enabled game.</span></span> <span data-ttu-id="dcc40-157">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="dcc40-157">Replace the *applicationId* value with the Store ID for your game.</span></span>


```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=achievements&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="dcc40-158">応答</span><span class="sxs-lookup"><span data-stu-id="dcc40-158">Response</span></span>

| <span data-ttu-id="dcc40-159">値</span><span class="sxs-lookup"><span data-stu-id="dcc40-159">Value</span></span>      | <span data-ttu-id="dcc40-160">型</span><span class="sxs-lookup"><span data-stu-id="dcc40-160">Type</span></span>   | <span data-ttu-id="dcc40-161">説明</span><span class="sxs-lookup"><span data-stu-id="dcc40-161">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="dcc40-162">Value</span><span class="sxs-lookup"><span data-stu-id="dcc40-162">Value</span></span>      | <span data-ttu-id="dcc40-163">array</span><span class="sxs-lookup"><span data-stu-id="dcc40-163">array</span></span>  | <span data-ttu-id="dcc40-164">対象ゲームの各実績のデータを含むオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-164">An array of objects that contain data for each achievement in your game.</span></span> <span data-ttu-id="dcc40-165">各オブジェクト内のデータについて詳しくは、次の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dcc40-165">For more information about the data in each object, see the following table.</span></span>                                                                                                                      |
| @nextLink  | <span data-ttu-id="dcc40-166">string</span><span class="sxs-lookup"><span data-stu-id="dcc40-166">string</span></span> | <span data-ttu-id="dcc40-167">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="dcc40-167">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="dcc40-168">たとえば、要求の **top** パラメーターが 100 に設定されていたとき、クエリに対して 100 行を超えるデータが一致すると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="dcc40-168">For example, this value is returned if the **top** parameter of the request is set to 100 but there are more than 100 rows of data for the query.</span></span> |
| <span data-ttu-id="dcc40-169">TotalCount</span><span class="sxs-lookup"><span data-stu-id="dcc40-169">TotalCount</span></span> | <span data-ttu-id="dcc40-170">int</span><span class="sxs-lookup"><span data-stu-id="dcc40-170">int</span></span>    | <span data-ttu-id="dcc40-171">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-171">The total number of rows in the data result for the query.</span></span>  |


<span data-ttu-id="dcc40-172">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="dcc40-172">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="dcc40-173">値</span><span class="sxs-lookup"><span data-stu-id="dcc40-173">Value</span></span>               | <span data-ttu-id="dcc40-174">型</span><span class="sxs-lookup"><span data-stu-id="dcc40-174">Type</span></span>   | <span data-ttu-id="dcc40-175">説明</span><span class="sxs-lookup"><span data-stu-id="dcc40-175">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="dcc40-176">applicationId</span><span class="sxs-lookup"><span data-stu-id="dcc40-176">applicationId</span></span>       | <span data-ttu-id="dcc40-177">string</span><span class="sxs-lookup"><span data-stu-id="dcc40-177">string</span></span> | <span data-ttu-id="dcc40-178">実績データを取得しているゲームの Store ID です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-178">The Store ID of the game for which you are retrieving achievements data.</span></span>     |
| <span data-ttu-id="dcc40-179">reportDateTime</span><span class="sxs-lookup"><span data-stu-id="dcc40-179">reportDateTime</span></span>     | <span data-ttu-id="dcc40-180">string</span><span class="sxs-lookup"><span data-stu-id="dcc40-180">string</span></span> |  <span data-ttu-id="dcc40-181">実績データの日付です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-181">The date for the achievements data.</span></span>    |
| <span data-ttu-id="dcc40-182">achievementId</span><span class="sxs-lookup"><span data-stu-id="dcc40-182">achievementId</span></span>          | <span data-ttu-id="dcc40-183">number</span><span class="sxs-lookup"><span data-stu-id="dcc40-183">number</span></span> |  <span data-ttu-id="dcc40-184">実績の ID です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-184">The ID of the achievement.</span></span> |
| <span data-ttu-id="dcc40-185">achievementName</span><span class="sxs-lookup"><span data-stu-id="dcc40-185">achievementName</span></span>           | <span data-ttu-id="dcc40-186">string</span><span class="sxs-lookup"><span data-stu-id="dcc40-186">string</span></span> | <span data-ttu-id="dcc40-187">実績の名前です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-187">The name of the achievement.</span></span>  |
| <span data-ttu-id="dcc40-188">gamerscore</span><span class="sxs-lookup"><span data-stu-id="dcc40-188">gamerscore</span></span>           | <span data-ttu-id="dcc40-189">number</span><span class="sxs-lookup"><span data-stu-id="dcc40-189">number</span></span> |  <span data-ttu-id="dcc40-190">実績のゲーマースコア リワードです。</span><span class="sxs-lookup"><span data-stu-id="dcc40-190">The gamerscore reward for the achievement.</span></span>  |
| <span data-ttu-id="dcc40-191">dailyUnlocks</span><span class="sxs-lookup"><span data-stu-id="dcc40-191">dailyUnlocks</span></span>           | <span data-ttu-id="dcc40-192">number</span><span class="sxs-lookup"><span data-stu-id="dcc40-192">number</span></span> |  <span data-ttu-id="dcc40-193">*reportDateTime* で指定された日付に実績のロックを解除したユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-193">The number of customers who unlocked the achievement on the day specified by *reportDateTime*.</span></span>  |
| <span data-ttu-id="dcc40-194">monthlyUnlocks</span><span class="sxs-lookup"><span data-stu-id="dcc40-194">monthlyUnlocks</span></span>              | <span data-ttu-id="dcc40-195">number</span><span class="sxs-lookup"><span data-stu-id="dcc40-195">number</span></span> |  <span data-ttu-id="dcc40-196">*reportDateTime* で指定された日付から過去 30 日間に実績のロックを解除したユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-196">The number of customers who unlocked the achievement in the 30 days prior to the day specified by *reportDateTime*.</span></span>   |
| <span data-ttu-id="dcc40-197">totalUnlocks</span><span class="sxs-lookup"><span data-stu-id="dcc40-197">totalUnlocks</span></span> | <span data-ttu-id="dcc40-198">number</span><span class="sxs-lookup"><span data-stu-id="dcc40-198">number</span></span> |  <span data-ttu-id="dcc40-199">ゲームのリリースから *reportDateTime* で指定された日付までの期間に実績のロックを解除したユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="dcc40-199">The number of customers who have unlocked the achievement during the lifetime of your game, up to the day specified by *reportDateTime*.</span></span>   |


### <a name="response-example"></a><span data-ttu-id="dcc40-200">応答の例</span><span class="sxs-lookup"><span data-stu-id="dcc40-200">Response example</span></span>

<span data-ttu-id="dcc40-201">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="dcc40-201">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Value": [
    {
      "applicationId": "9NBLGGGZ5QDR",
      "reportDateTime": "2018-01-30T00:00:00",
      "achievementId": 6,
      "achievementName": "Yoink!",
      "gamerscore": 10,
      "dailyUnlocks": 0,
      "monthlyUnlocks": 10310,
      "totalUnlocks": 1215360
    },
    {
      "applicationId": "9NBLGGGZ5QDR",
      "reportDateTime": "2018-01-30T00:00:00",
      "achievementId": 7,
      "achievementName": "Ding!",
      "gamerscore": 10,
      "dailyUnlocks": 0,
      "monthlyUnlocks": 10897,
      "totalUnlocks": 1282524
    },
    {
      "applicationId": "9NBLGGGZ5QDR",
      "reportDateTime": "2018-01-30T00:00:00",
      "achievementId": 8,
      "achievementName": "End of the Beginning",
      "gamerscore": 30,
      "dailyUnlocks": 0,
      "monthlyUnlocks": 9848,
      "totalUnlocks": 1105074
    }
  ],
  "@nextLink": null,
  "TotalCount": 3
}
```

## <a name="related-topics"></a><span data-ttu-id="dcc40-202">関連トピック</span><span class="sxs-lookup"><span data-stu-id="dcc40-202">Related topics</span></span>

* [<span data-ttu-id="dcc40-203">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="dcc40-203">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="dcc40-204">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="dcc40-204">Get Xbox Live analytics data</span></span>](get-xbox-live-analytics.md)
* [<span data-ttu-id="dcc40-205">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="dcc40-205">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="dcc40-206">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="dcc40-206">Get Xbox Live Game Hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="dcc40-207">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="dcc40-207">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="dcc40-208">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="dcc40-208">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
