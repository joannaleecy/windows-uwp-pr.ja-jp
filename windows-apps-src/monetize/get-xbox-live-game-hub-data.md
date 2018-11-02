---
author: Xansky
description: Xbox Live ゲーム ハブのデータを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live ゲーム ハブのデータの取得
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, ゲーム ハブ
ms.localizationpriority: medium
ms.openlocfilehash: f565f0fc3799ebf2d23f9dd7b9320323588f4caa
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5997741"
---
# <a name="get-xbox-live-game-hub-data"></a><span data-ttu-id="e3759-104">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="e3759-104">Get Xbox Live Game Hub data</span></span>


<span data-ttu-id="e3759-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)のゲーム ハブ データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="e3759-105">Use this method in the Microsoft Store analytics API to get Game Hub data for your [Xbox Live-enabled game](../xbox-live/index.md).</span></span> <span data-ttu-id="e3759-106">この情報は、 [Xbox 分析レポート](../publish/xbox-analytics-report.md)では、パートナー センターで利用可能なもできます。</span><span class="sxs-lookup"><span data-stu-id="e3759-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in Partner Center.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e3759-107">このメソッドは、Xbox のゲームまたは Xbox Live サービスを使用するゲームのみサポートします。</span><span class="sxs-lookup"><span data-stu-id="e3759-107">This method only supports games for Xbox or games that use Xbox Live services.</span></span> <span data-ttu-id="e3759-108">これらのゲームは、[概念の承認プロセス](../gaming/concept-approval.md)を完了する必要があります。これには、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)が発行したゲームと [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)を介して申請されたゲームが含まれます。</span><span class="sxs-lookup"><span data-stu-id="e3759-108">These games must go through the [concept approval process](../gaming/concept-approval.md), which includes games published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) and games submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="e3759-109">このメソッドでは、[Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)を介して発行されたゲームは現在サポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e3759-109">This method does not currently support games published via the [Xbox Live Creators Program](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="e3759-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="e3759-110">Prerequisites</span></span>

<span data-ttu-id="e3759-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e3759-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="e3759-112">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="e3759-112">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="e3759-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="e3759-113">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="e3759-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="e3759-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="e3759-115">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="e3759-115">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="e3759-116">要求</span><span class="sxs-lookup"><span data-stu-id="e3759-116">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="e3759-117">要求の構文</span><span class="sxs-lookup"><span data-stu-id="e3759-117">Request syntax</span></span>

| <span data-ttu-id="e3759-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="e3759-118">Method</span></span> | <span data-ttu-id="e3759-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="e3759-119">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="e3759-120">GET</span><span class="sxs-lookup"><span data-stu-id="e3759-120">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="e3759-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e3759-121">Request header</span></span>

| <span data-ttu-id="e3759-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e3759-122">Header</span></span>        | <span data-ttu-id="e3759-123">型</span><span class="sxs-lookup"><span data-stu-id="e3759-123">Type</span></span>   | <span data-ttu-id="e3759-124">説明</span><span class="sxs-lookup"><span data-stu-id="e3759-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="e3759-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="e3759-125">Authorization</span></span> | <span data-ttu-id="e3759-126">string</span><span class="sxs-lookup"><span data-stu-id="e3759-126">string</span></span> | <span data-ttu-id="e3759-127">必須。</span><span class="sxs-lookup"><span data-stu-id="e3759-127">Required.</span></span> <span data-ttu-id="e3759-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="e3759-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="e3759-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="e3759-129">Request parameters</span></span>

| <span data-ttu-id="e3759-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e3759-130">Parameter</span></span>        | <span data-ttu-id="e3759-131">型</span><span class="sxs-lookup"><span data-stu-id="e3759-131">Type</span></span>   |  <span data-ttu-id="e3759-132">説明</span><span class="sxs-lookup"><span data-stu-id="e3759-132">Description</span></span>      |  <span data-ttu-id="e3759-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="e3759-133">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="e3759-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="e3759-134">applicationId</span></span> | <span data-ttu-id="e3759-135">string</span><span class="sxs-lookup"><span data-stu-id="e3759-135">string</span></span> | <span data-ttu-id="e3759-136">Xbox Live ゲーム ハブのデータを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="e3759-136">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve Xbox Live Game Hub data.</span></span>  |  <span data-ttu-id="e3759-137">必須</span><span class="sxs-lookup"><span data-stu-id="e3759-137">Yes</span></span>  |
| <span data-ttu-id="e3759-138">metricType</span><span class="sxs-lookup"><span data-stu-id="e3759-138">metricType</span></span> | <span data-ttu-id="e3759-139">string</span><span class="sxs-lookup"><span data-stu-id="e3759-139">string</span></span> | <span data-ttu-id="e3759-140">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="e3759-140">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="e3759-141">このメソッドでは、値 **communitymanagergamehub** を指定します。</span><span class="sxs-lookup"><span data-stu-id="e3759-141">For this method, specify the value **communitymanagergamehub**.</span></span>  |  <span data-ttu-id="e3759-142">必須</span><span class="sxs-lookup"><span data-stu-id="e3759-142">Yes</span></span>  |
| <span data-ttu-id="e3759-143">startDate</span><span class="sxs-lookup"><span data-stu-id="e3759-143">startDate</span></span> | <span data-ttu-id="e3759-144">date</span><span class="sxs-lookup"><span data-stu-id="e3759-144">date</span></span> | <span data-ttu-id="e3759-145">取得するゲーム ハブ データの日付範囲の開始日です。</span><span class="sxs-lookup"><span data-stu-id="e3759-145">The start date in the date range of Game Hub data to retrieve.</span></span> <span data-ttu-id="e3759-146">既定値は、現在の日付の 30 日前です。</span><span class="sxs-lookup"><span data-stu-id="e3759-146">The default is 30 days before the current date.</span></span> |  <span data-ttu-id="e3759-147">必須ではない</span><span class="sxs-lookup"><span data-stu-id="e3759-147">No</span></span>  |
| <span data-ttu-id="e3759-148">endDate</span><span class="sxs-lookup"><span data-stu-id="e3759-148">endDate</span></span> | <span data-ttu-id="e3759-149">date</span><span class="sxs-lookup"><span data-stu-id="e3759-149">date</span></span> | <span data-ttu-id="e3759-150">取得するゲーム ハブ データの日付範囲の終了日です。</span><span class="sxs-lookup"><span data-stu-id="e3759-150">The end date in the date range of Game Hub data to retrieve.</span></span> <span data-ttu-id="e3759-151">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="e3759-151">The default is the current date.</span></span> |  <span data-ttu-id="e3759-152">必須ではない</span><span class="sxs-lookup"><span data-stu-id="e3759-152">No</span></span>  |
| <span data-ttu-id="e3759-153">top</span><span class="sxs-lookup"><span data-stu-id="e3759-153">top</span></span> | <span data-ttu-id="e3759-154">int</span><span class="sxs-lookup"><span data-stu-id="e3759-154">int</span></span> | <span data-ttu-id="e3759-155">要求で返すデータの行数です。</span><span class="sxs-lookup"><span data-stu-id="e3759-155">The number of rows of data to return in the request.</span></span> <span data-ttu-id="e3759-156">指定されない場合の既定値は、最大値でもある 10000 です。</span><span class="sxs-lookup"><span data-stu-id="e3759-156">The maximum value and the default value if not specified is 10000.</span></span> <span data-ttu-id="e3759-157">クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。</span><span class="sxs-lookup"><span data-stu-id="e3759-157">If there are more rows in the query, the response body includes a next link that you can use to request the next page of data.</span></span> |  <span data-ttu-id="e3759-158">必須ではない</span><span class="sxs-lookup"><span data-stu-id="e3759-158">No</span></span>  |
| <span data-ttu-id="e3759-159">skip</span><span class="sxs-lookup"><span data-stu-id="e3759-159">skip</span></span> | <span data-ttu-id="e3759-160">int</span><span class="sxs-lookup"><span data-stu-id="e3759-160">int</span></span> | <span data-ttu-id="e3759-161">クエリでスキップする行数です。</span><span class="sxs-lookup"><span data-stu-id="e3759-161">The number of rows to skip in the query.</span></span> <span data-ttu-id="e3759-162">大きなデータ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="e3759-162">Use this parameter to page through large data sets.</span></span> <span data-ttu-id="e3759-163">たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。</span><span class="sxs-lookup"><span data-stu-id="e3759-163">For example, top=10000 and skip=0 retrieves the first 10000 rows of data, top=10000 and skip=10000 retrieves the next 10000 rows of data, and so on.</span></span> |  <span data-ttu-id="e3759-164">必須ではない</span><span class="sxs-lookup"><span data-stu-id="e3759-164">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="e3759-165">要求の例</span><span class="sxs-lookup"><span data-stu-id="e3759-165">Request example</span></span>

<span data-ttu-id="e3759-166">次の例では、Xbox Live 対応ゲームのゲーム ハブのデータを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="e3759-166">The following example demonstrates a request for getting Game Hub data for your Xbox Live-enabled game.</span></span> <span data-ttu-id="e3759-167">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="e3759-167">Replace the *applicationId* value with the Store ID for your game.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=communitymanagergamehub&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="e3759-168">応答</span><span class="sxs-lookup"><span data-stu-id="e3759-168">Response</span></span>


| <span data-ttu-id="e3759-169">値</span><span class="sxs-lookup"><span data-stu-id="e3759-169">Value</span></span>      | <span data-ttu-id="e3759-170">型</span><span class="sxs-lookup"><span data-stu-id="e3759-170">Type</span></span>   | <span data-ttu-id="e3759-171">説明</span><span class="sxs-lookup"><span data-stu-id="e3759-171">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="e3759-172">Value</span><span class="sxs-lookup"><span data-stu-id="e3759-172">Value</span></span>      | <span data-ttu-id="e3759-173">array</span><span class="sxs-lookup"><span data-stu-id="e3759-173">array</span></span>  | <span data-ttu-id="e3759-174">指定された日付範囲の日付ごとのゲーム ハブ データを含むオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="e3759-174">An array of objects that contain Game Hub data for each date in the specified date range.</span></span> <span data-ttu-id="e3759-175">各オブジェクト内のデータについて詳しくは、次の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e3759-175">For more information about the data in each object, see the following table.</span></span>                                                                                                                      |
| @nextLink  | <span data-ttu-id="e3759-176">string</span><span class="sxs-lookup"><span data-stu-id="e3759-176">string</span></span> | <span data-ttu-id="e3759-177">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e3759-177">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="e3759-178">たとえば、要求の **top** パラメーターが 10000 に設定されていたとき、クエリに対して 10000 行を超えるデータが一致すると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="e3759-178">For example, this value is returned if the **top** parameter of the request is set to 10000 but there are more than 10000 rows of data for the query.</span></span> |
| <span data-ttu-id="e3759-179">TotalCount</span><span class="sxs-lookup"><span data-stu-id="e3759-179">TotalCount</span></span> | <span data-ttu-id="e3759-180">int</span><span class="sxs-lookup"><span data-stu-id="e3759-180">int</span></span>    | <span data-ttu-id="e3759-181">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="e3759-181">The total number of rows in the data result for the query.</span></span>  |


<span data-ttu-id="e3759-182">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e3759-182">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="e3759-183">値</span><span class="sxs-lookup"><span data-stu-id="e3759-183">Value</span></span>               | <span data-ttu-id="e3759-184">型</span><span class="sxs-lookup"><span data-stu-id="e3759-184">Type</span></span>   | <span data-ttu-id="e3759-185">説明</span><span class="sxs-lookup"><span data-stu-id="e3759-185">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="e3759-186">date</span><span class="sxs-lookup"><span data-stu-id="e3759-186">date</span></span>                | <span data-ttu-id="e3759-187">string</span><span class="sxs-lookup"><span data-stu-id="e3759-187">string</span></span> | <span data-ttu-id="e3759-188">このオブジェクトに含まれるゲーム ハブ データの日付です。</span><span class="sxs-lookup"><span data-stu-id="e3759-188">The date for the Game Hub data in this object.</span></span> |
| <span data-ttu-id="e3759-189">applicationId</span><span class="sxs-lookup"><span data-stu-id="e3759-189">applicationId</span></span>       | <span data-ttu-id="e3759-190">string</span><span class="sxs-lookup"><span data-stu-id="e3759-190">string</span></span> | <span data-ttu-id="e3759-191">ゲーム ハブ データを取得しているゲームの Store ID です。</span><span class="sxs-lookup"><span data-stu-id="e3759-191">The Store ID of the game for which you are retrieving Game Hub data.</span></span>     |
| <span data-ttu-id="e3759-192">gameHubLikeCount</span><span class="sxs-lookup"><span data-stu-id="e3759-192">gameHubLikeCount</span></span>     | <span data-ttu-id="e3759-193">number</span><span class="sxs-lookup"><span data-stu-id="e3759-193">number</span></span> |   <span data-ttu-id="e3759-194">指定の日付にゲーム ハブ ページに追加された "いいね" の数です。</span><span class="sxs-lookup"><span data-stu-id="e3759-194">The number of likes added to the Game Hub page on the specified date.</span></span>   |
| <span data-ttu-id="e3759-195">gameHubCommentCount</span><span class="sxs-lookup"><span data-stu-id="e3759-195">gameHubCommentCount</span></span>          | <span data-ttu-id="e3759-196">number</span><span class="sxs-lookup"><span data-stu-id="e3759-196">number</span></span> |  <span data-ttu-id="e3759-197">指定の日付に対象アプリのゲーム ハブ ページに追加されたコメントの数です。</span><span class="sxs-lookup"><span data-stu-id="e3759-197">The number of comments added to the Game Hub page for your app on the specified date.</span></span>  |
| <span data-ttu-id="e3759-198">gameHubShareCount</span><span class="sxs-lookup"><span data-stu-id="e3759-198">gameHubShareCount</span></span>           | <span data-ttu-id="e3759-199">number</span><span class="sxs-lookup"><span data-stu-id="e3759-199">number</span></span> | <span data-ttu-id="e3759-200">指定の日付にユーザーによって対象アプリのゲーム ハブ ページが共有された回数です。</span><span class="sxs-lookup"><span data-stu-id="e3759-200">The number of times the Game Hub page for your app was shared by customers on the specified date.</span></span>   |
| <span data-ttu-id="e3759-201">gameHubFollowerCount</span><span class="sxs-lookup"><span data-stu-id="e3759-201">gameHubFollowerCount</span></span>          | <span data-ttu-id="e3759-202">number</span><span class="sxs-lookup"><span data-stu-id="e3759-202">number</span></span> | <span data-ttu-id="e3759-203">アプリのゲーム ハブ ページの通算フォロワーの数。</span><span class="sxs-lookup"><span data-stu-id="e3759-203">The number of all-time followers for the Game Hub page for your app.</span></span>   |


### <a name="response-example"></a><span data-ttu-id="e3759-204">応答の例</span><span class="sxs-lookup"><span data-stu-id="e3759-204">Response example</span></span>

<span data-ttu-id="e3759-205">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e3759-205">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Value": [
    {
      "date": "2018-01-04",
      "applicationId": "9NBLGGGZ5QDR",
      "gameHubLikeCount": 10,
      "gameHubCommentCount": 1,
      "gameHubShareCount": 0,
      "gameHubFollowerCount": 15924
    },
    {
      "date": "2018-01-05",
      "applicationId": "9NBLGGGZ5QDR",
      "gameHubLikeCount": 12,
      "gameHubCommentCount": 1,
      "gameHubShareCount": 0,
      "gameHubFollowerCount": 15931
    }
  ],
  "@nextLink": null,
  "TotalCount": 26
}
```

## <a name="related-topics"></a><span data-ttu-id="e3759-206">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e3759-206">Related topics</span></span>

* [<span data-ttu-id="e3759-207">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="e3759-207">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="e3759-208">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="e3759-208">Get Xbox Live analytics data</span></span>](get-xbox-live-analytics.md)
* [<span data-ttu-id="e3759-209">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="e3759-209">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="e3759-210">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="e3759-210">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="e3759-211">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="e3759-211">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="e3759-212">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="e3759-212">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
