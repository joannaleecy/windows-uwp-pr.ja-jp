---
author: mcleanbyron
description: Xbox Live ゲーム ハブのデータを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live ゲーム ハブのデータの取得
ms.author: mcleans
ms.date: 04/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, ゲーム ハブ
ms.localizationpriority: medium
ms.openlocfilehash: 0d34c95e615a10131b3e7f3ffe9ceb246b652727
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1815787"
---
# <a name="get-xbox-live-game-hub-data"></a><span data-ttu-id="f9a1e-104">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="f9a1e-104">Get Xbox Live Game Hub data</span></span>


<span data-ttu-id="f9a1e-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)のゲーム ハブ データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-105">Use this method in the Microsoft Store analytics API to get Game Hub data for your [Xbox Live-enabled game](../xbox-live/index.md).</span></span> <span data-ttu-id="f9a1e-106">この情報は、Windows デベロッパー センター ダッシュボードの [Xbox 分析レポート](../publish/xbox-analytics-report.md)でも確認できます。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in the Windows Dev Center dashboard.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f9a1e-107">現在このメソッドがサポートしているのは、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)によって公開された Xbox Live 対応ゲーム、または [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)経由で提出された Xbox Live 対応ゲームだけです。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-107">This method currently only supports Xbox Live-enabled games that are published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) or that are submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="f9a1e-108">[Xbox Live クリエーターズ プログラム](../xbox-live/developer-program-overview.md#xbox-live-creators-program)経由で提出されたゲームのデータは返されません。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-108">It does not return data for games that were submitted via the [Xbox Live Creators Program](../xbox-live/developer-program-overview.md#xbox-live-creators-program).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="f9a1e-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="f9a1e-109">Prerequisites</span></span>

<span data-ttu-id="f9a1e-110">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-110">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="f9a1e-111">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-111">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="f9a1e-112">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-112">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="f9a1e-113">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-113">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="f9a1e-114">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-114">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="f9a1e-115">要求</span><span class="sxs-lookup"><span data-stu-id="f9a1e-115">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="f9a1e-116">要求の構文</span><span class="sxs-lookup"><span data-stu-id="f9a1e-116">Request syntax</span></span>

| <span data-ttu-id="f9a1e-117">メソッド</span><span class="sxs-lookup"><span data-stu-id="f9a1e-117">Method</span></span> | <span data-ttu-id="f9a1e-118">要求 URI</span><span class="sxs-lookup"><span data-stu-id="f9a1e-118">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="f9a1e-119">GET</span><span class="sxs-lookup"><span data-stu-id="f9a1e-119">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="f9a1e-120">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9a1e-120">Request header</span></span>

| <span data-ttu-id="f9a1e-121">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9a1e-121">Header</span></span>        | <span data-ttu-id="f9a1e-122">型</span><span class="sxs-lookup"><span data-stu-id="f9a1e-122">Type</span></span>   | <span data-ttu-id="f9a1e-123">説明</span><span class="sxs-lookup"><span data-stu-id="f9a1e-123">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="f9a1e-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="f9a1e-124">Authorization</span></span> | <span data-ttu-id="f9a1e-125">文字列</span><span class="sxs-lookup"><span data-stu-id="f9a1e-125">string</span></span> | <span data-ttu-id="f9a1e-126">必須。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-126">Required.</span></span> <span data-ttu-id="f9a1e-127">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-127">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="f9a1e-128">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9a1e-128">Request parameters</span></span>

| <span data-ttu-id="f9a1e-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9a1e-129">Parameter</span></span>        | <span data-ttu-id="f9a1e-130">型</span><span class="sxs-lookup"><span data-stu-id="f9a1e-130">Type</span></span>   |  <span data-ttu-id="f9a1e-131">説明</span><span class="sxs-lookup"><span data-stu-id="f9a1e-131">Description</span></span>      |  <span data-ttu-id="f9a1e-132">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="f9a1e-132">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="f9a1e-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="f9a1e-133">applicationId</span></span> | <span data-ttu-id="f9a1e-134">string</span><span class="sxs-lookup"><span data-stu-id="f9a1e-134">string</span></span> | <span data-ttu-id="f9a1e-135">Xbox Live ゲーム ハブのデータを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-135">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve Xbox Live Game Hub data.</span></span>  |  <span data-ttu-id="f9a1e-136">必須</span><span class="sxs-lookup"><span data-stu-id="f9a1e-136">Yes</span></span>  |
| <span data-ttu-id="f9a1e-137">metricType</span><span class="sxs-lookup"><span data-stu-id="f9a1e-137">metricType</span></span> | <span data-ttu-id="f9a1e-138">string</span><span class="sxs-lookup"><span data-stu-id="f9a1e-138">string</span></span> | <span data-ttu-id="f9a1e-139">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-139">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="f9a1e-140">このメソッドでは、値 **communitymanagergamehub** を指定します。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-140">For this method, specify the value **communitymanagergamehub**.</span></span>  |  <span data-ttu-id="f9a1e-141">必須</span><span class="sxs-lookup"><span data-stu-id="f9a1e-141">Yes</span></span>  |
| <span data-ttu-id="f9a1e-142">startDate</span><span class="sxs-lookup"><span data-stu-id="f9a1e-142">startDate</span></span> | <span data-ttu-id="f9a1e-143">date</span><span class="sxs-lookup"><span data-stu-id="f9a1e-143">date</span></span> | <span data-ttu-id="f9a1e-144">取得するゲーム ハブ データの日付範囲の開始日です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-144">The start date in the date range of Game Hub data to retrieve.</span></span> <span data-ttu-id="f9a1e-145">既定値は、現在の日付の 30 日前です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-145">The default is 30 days before the current date.</span></span> |  <span data-ttu-id="f9a1e-146">必須ではない</span><span class="sxs-lookup"><span data-stu-id="f9a1e-146">No</span></span>  |
| <span data-ttu-id="f9a1e-147">endDate</span><span class="sxs-lookup"><span data-stu-id="f9a1e-147">endDate</span></span> | <span data-ttu-id="f9a1e-148">date</span><span class="sxs-lookup"><span data-stu-id="f9a1e-148">date</span></span> | <span data-ttu-id="f9a1e-149">取得するゲーム ハブ データの日付範囲の終了日です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-149">The end date in the date range of Game Hub data to retrieve.</span></span> <span data-ttu-id="f9a1e-150">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-150">The default is the current date.</span></span> |  <span data-ttu-id="f9a1e-151">必須ではない</span><span class="sxs-lookup"><span data-stu-id="f9a1e-151">No</span></span>  |
| <span data-ttu-id="f9a1e-152">top</span><span class="sxs-lookup"><span data-stu-id="f9a1e-152">top</span></span> | <span data-ttu-id="f9a1e-153">int</span><span class="sxs-lookup"><span data-stu-id="f9a1e-153">int</span></span> | <span data-ttu-id="f9a1e-154">要求で返すデータの行数です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-154">The number of rows of data to return in the request.</span></span> <span data-ttu-id="f9a1e-155">指定されない場合の既定値は、最大値でもある 10000 です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-155">The maximum value and the default value if not specified is 10000.</span></span> <span data-ttu-id="f9a1e-156">クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-156">If there are more rows in the query, the response body includes a next link that you can use to request the next page of data.</span></span> |  <span data-ttu-id="f9a1e-157">必須ではない</span><span class="sxs-lookup"><span data-stu-id="f9a1e-157">No</span></span>  |
| <span data-ttu-id="f9a1e-158">skip</span><span class="sxs-lookup"><span data-stu-id="f9a1e-158">skip</span></span> | <span data-ttu-id="f9a1e-159">int</span><span class="sxs-lookup"><span data-stu-id="f9a1e-159">int</span></span> | <span data-ttu-id="f9a1e-160">クエリでスキップする行数です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-160">The number of rows to skip in the query.</span></span> <span data-ttu-id="f9a1e-161">大きなデータ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-161">Use this parameter to page through large data sets.</span></span> <span data-ttu-id="f9a1e-162">たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-162">For example, top=10000 and skip=0 retrieves the first 10000 rows of data, top=10000 and skip=10000 retrieves the next 10000 rows of data, and so on.</span></span> |  <span data-ttu-id="f9a1e-163">必須ではない</span><span class="sxs-lookup"><span data-stu-id="f9a1e-163">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="f9a1e-164">要求の例</span><span class="sxs-lookup"><span data-stu-id="f9a1e-164">Request example</span></span>

<span data-ttu-id="f9a1e-165">次の例では、Xbox Live 対応ゲームのゲーム ハブのデータを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-165">The following example demonstrates a request for getting Game Hub data for your Xbox Live-enabled game.</span></span> <span data-ttu-id="f9a1e-166">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-166">Replace the *applicationId* value with the Store ID for your game.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=communitymanagergamehub&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="f9a1e-167">応答</span><span class="sxs-lookup"><span data-stu-id="f9a1e-167">Response</span></span>


| <span data-ttu-id="f9a1e-168">値</span><span class="sxs-lookup"><span data-stu-id="f9a1e-168">Value</span></span>      | <span data-ttu-id="f9a1e-169">型</span><span class="sxs-lookup"><span data-stu-id="f9a1e-169">Type</span></span>   | <span data-ttu-id="f9a1e-170">説明</span><span class="sxs-lookup"><span data-stu-id="f9a1e-170">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="f9a1e-171">Value</span><span class="sxs-lookup"><span data-stu-id="f9a1e-171">Value</span></span>      | <span data-ttu-id="f9a1e-172">array</span><span class="sxs-lookup"><span data-stu-id="f9a1e-172">array</span></span>  | <span data-ttu-id="f9a1e-173">指定された日付範囲の日付ごとのゲーム ハブ データを含むオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-173">An array of objects that contain Game Hub data for each date in the specified date range.</span></span> <span data-ttu-id="f9a1e-174">各オブジェクト内のデータについて詳しくは、次の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-174">For more information about the data in each object, see the following table.</span></span>                                                                                                                      |
| @nextLink  | <span data-ttu-id="f9a1e-175">string</span><span class="sxs-lookup"><span data-stu-id="f9a1e-175">string</span></span> | <span data-ttu-id="f9a1e-176">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-176">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="f9a1e-177">たとえば、要求の **top** パラメーターが 10000 に設定されていたとき、クエリに対して 10000 行を超えるデータが一致すると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-177">For example, this value is returned if the **top** parameter of the request is set to 10000 but there are more than 10000 rows of data for the query.</span></span> |
| <span data-ttu-id="f9a1e-178">TotalCount</span><span class="sxs-lookup"><span data-stu-id="f9a1e-178">TotalCount</span></span> | <span data-ttu-id="f9a1e-179">int</span><span class="sxs-lookup"><span data-stu-id="f9a1e-179">int</span></span>    | <span data-ttu-id="f9a1e-180">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-180">The total number of rows in the data result for the query.</span></span>  |


<span data-ttu-id="f9a1e-181">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-181">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="f9a1e-182">値</span><span class="sxs-lookup"><span data-stu-id="f9a1e-182">Value</span></span>               | <span data-ttu-id="f9a1e-183">型</span><span class="sxs-lookup"><span data-stu-id="f9a1e-183">Type</span></span>   | <span data-ttu-id="f9a1e-184">説明</span><span class="sxs-lookup"><span data-stu-id="f9a1e-184">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="f9a1e-185">date</span><span class="sxs-lookup"><span data-stu-id="f9a1e-185">date</span></span>                | <span data-ttu-id="f9a1e-186">string</span><span class="sxs-lookup"><span data-stu-id="f9a1e-186">string</span></span> | <span data-ttu-id="f9a1e-187">このオブジェクトに含まれるゲーム ハブ データの日付です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-187">The date for the Game Hub data in this object.</span></span> |
| <span data-ttu-id="f9a1e-188">applicationId</span><span class="sxs-lookup"><span data-stu-id="f9a1e-188">applicationId</span></span>       | <span data-ttu-id="f9a1e-189">string</span><span class="sxs-lookup"><span data-stu-id="f9a1e-189">string</span></span> | <span data-ttu-id="f9a1e-190">ゲーム ハブ データを取得しているゲームの Store ID です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-190">The Store ID of the game for which you are retrieving Game Hub data.</span></span>     |
| <span data-ttu-id="f9a1e-191">gameHubLikeCount</span><span class="sxs-lookup"><span data-stu-id="f9a1e-191">gameHubLikeCount</span></span>     | <span data-ttu-id="f9a1e-192">number</span><span class="sxs-lookup"><span data-stu-id="f9a1e-192">number</span></span> |   <span data-ttu-id="f9a1e-193">指定の日付にゲーム ハブ ページに追加された "いいね" の数です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-193">The number of likes added to the Game Hub page on the specified date.</span></span>   |
| <span data-ttu-id="f9a1e-194">gameHubCommentCount</span><span class="sxs-lookup"><span data-stu-id="f9a1e-194">gameHubCommentCount</span></span>          | <span data-ttu-id="f9a1e-195">number</span><span class="sxs-lookup"><span data-stu-id="f9a1e-195">number</span></span> |  <span data-ttu-id="f9a1e-196">指定の日付に対象アプリのゲーム ハブ ページに追加されたコメントの数です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-196">The number of comments added to the Game Hub page for your app on the specified date.</span></span>  |
| <span data-ttu-id="f9a1e-197">gameHubShareCount</span><span class="sxs-lookup"><span data-stu-id="f9a1e-197">gameHubShareCount</span></span>           | <span data-ttu-id="f9a1e-198">number</span><span class="sxs-lookup"><span data-stu-id="f9a1e-198">number</span></span> | <span data-ttu-id="f9a1e-199">指定の日付にユーザーによって対象アプリのゲーム ハブ ページが共有された回数です。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-199">The number of times the Game Hub page for your app was shared by customers on the specified date.</span></span>   |


### <a name="response-example"></a><span data-ttu-id="f9a1e-200">応答の例</span><span class="sxs-lookup"><span data-stu-id="f9a1e-200">Response example</span></span>

<span data-ttu-id="f9a1e-201">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f9a1e-201">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Value": [
    {
      "date": "2018-01-04",
      "applicationId": "9NBLGGGZ5QDR",
      "gameHubLikeCount": 10,
      "gameHubCommentCount": 1,
      "gameHubShareCount": 0
    },
    {
      "date": "2018-01-05",
      "applicationId": "9NBLGGGZ5QDR",
      "gameHubLikeCount": 12,
      "gameHubCommentCount": 1,
      "gameHubShareCount": 0
    }
  ],
  "@nextLink": null,
  "TotalCount": 26
}
```

## <a name="related-topics"></a><span data-ttu-id="f9a1e-202">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f9a1e-202">Related topics</span></span>

* [<span data-ttu-id="f9a1e-203">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="f9a1e-203">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="f9a1e-204">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="f9a1e-204">Get Xbox Live analytics data</span></span>](get-xbox-live-analytics.md)
* [<span data-ttu-id="f9a1e-205">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="f9a1e-205">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="f9a1e-206">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="f9a1e-206">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="f9a1e-207">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="f9a1e-207">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="f9a1e-208">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="f9a1e-208">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
