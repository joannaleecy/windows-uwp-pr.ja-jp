---
author: mcleanbyron
description: Xbox Live の実績データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live の実績データの取得
ms.author: mcleans
ms.date: 04/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, 実績
ms.localizationpriority: medium
ms.openlocfilehash: 76cbe9abf3b6d668bb157e40f3e61aff885e3cbb
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1816017"
---
# <a name="get-xbox-live-achievements-data"></a><span data-ttu-id="0b7ce-104">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="0b7ce-104">Get Xbox Live achievements data</span></span>

<span data-ttu-id="0b7ce-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)の各実績のロックを解除したユーザーの数を取得するには、Microsoft Store 分析 API の以下のメソッドを使います。実績データがある直近の日付、その日から過去 30 日間、およびゲームのリリースからその日までの期間のデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-105">Use this method in the Microsoft Store analytics API to get the number of customers who have unlocked each achievement for your [Xbox Live-enabled game](../xbox-live/index.md) during the most recent day for which achievements data is available, the previous 30 days leading up to that day, and the total lifetime of your game up to that day.</span></span> <span data-ttu-id="0b7ce-106">この情報は、Windows デベロッパー センター ダッシュボードの [Xbox 分析レポート](../publish/xbox-analytics-report.md)でも確認できます。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in the Windows Dev Center dashboard.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="0b7ce-107">現在このメソッドがサポートしているのは、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)によって公開された Xbox Live 対応ゲーム、または [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)経由で提出された Xbox Live 対応ゲームだけです。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-107">This method currently only supports Xbox Live-enabled games that are published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) or that are submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="0b7ce-108">[Xbox Live クリエーターズ プログラム](../xbox-live/developer-program-overview.md#xbox-live-creators-program)経由で提出されたゲームのデータは返されません。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-108">It does not return data for games that were submitted via the [Xbox Live Creators Program](../xbox-live/developer-program-overview.md#xbox-live-creators-program).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="0b7ce-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="0b7ce-109">Prerequisites</span></span>

<span data-ttu-id="0b7ce-110">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-110">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="0b7ce-111">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-111">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="0b7ce-112">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-112">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="0b7ce-113">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-113">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="0b7ce-114">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-114">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="0b7ce-115">要求</span><span class="sxs-lookup"><span data-stu-id="0b7ce-115">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="0b7ce-116">要求の構文</span><span class="sxs-lookup"><span data-stu-id="0b7ce-116">Request syntax</span></span>

| <span data-ttu-id="0b7ce-117">メソッド</span><span class="sxs-lookup"><span data-stu-id="0b7ce-117">Method</span></span> | <span data-ttu-id="0b7ce-118">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0b7ce-118">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="0b7ce-119">GET</span><span class="sxs-lookup"><span data-stu-id="0b7ce-119">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="0b7ce-120">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b7ce-120">Request header</span></span>

| <span data-ttu-id="0b7ce-121">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b7ce-121">Header</span></span>        | <span data-ttu-id="0b7ce-122">型</span><span class="sxs-lookup"><span data-stu-id="0b7ce-122">Type</span></span>   | <span data-ttu-id="0b7ce-123">説明</span><span class="sxs-lookup"><span data-stu-id="0b7ce-123">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="0b7ce-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="0b7ce-124">Authorization</span></span> | <span data-ttu-id="0b7ce-125">文字列</span><span class="sxs-lookup"><span data-stu-id="0b7ce-125">string</span></span> | <span data-ttu-id="0b7ce-126">必須。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-126">Required.</span></span> <span data-ttu-id="0b7ce-127">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-127">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="0b7ce-128">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="0b7ce-128">Request parameters</span></span>


| <span data-ttu-id="0b7ce-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0b7ce-129">Parameter</span></span>        | <span data-ttu-id="0b7ce-130">型</span><span class="sxs-lookup"><span data-stu-id="0b7ce-130">Type</span></span>   |  <span data-ttu-id="0b7ce-131">説明</span><span class="sxs-lookup"><span data-stu-id="0b7ce-131">Description</span></span>      |  <span data-ttu-id="0b7ce-132">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="0b7ce-132">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="0b7ce-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="0b7ce-133">applicationId</span></span> | <span data-ttu-id="0b7ce-134">string</span><span class="sxs-lookup"><span data-stu-id="0b7ce-134">string</span></span> | <span data-ttu-id="0b7ce-135">Xbox Live の実績データを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-135">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve Xbox Live achievements data.</span></span>  |  <span data-ttu-id="0b7ce-136">必須</span><span class="sxs-lookup"><span data-stu-id="0b7ce-136">Yes</span></span>  |
| <span data-ttu-id="0b7ce-137">metricType</span><span class="sxs-lookup"><span data-stu-id="0b7ce-137">metricType</span></span> | <span data-ttu-id="0b7ce-138">string</span><span class="sxs-lookup"><span data-stu-id="0b7ce-138">string</span></span> | <span data-ttu-id="0b7ce-139">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-139">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="0b7ce-140">このメソッドでは、値 **achievements** を指定します。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-140">For this method, specify the value **achievements**.</span></span>  |  <span data-ttu-id="0b7ce-141">必須</span><span class="sxs-lookup"><span data-stu-id="0b7ce-141">Yes</span></span>  |
| <span data-ttu-id="0b7ce-142">top</span><span class="sxs-lookup"><span data-stu-id="0b7ce-142">top</span></span> | <span data-ttu-id="0b7ce-143">int</span><span class="sxs-lookup"><span data-stu-id="0b7ce-143">int</span></span> | <span data-ttu-id="0b7ce-144">要求で返すデータの行数です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-144">The number of rows of data to return in the request.</span></span> <span data-ttu-id="0b7ce-145">指定されない場合の既定値は、最大値でもある 10000 です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-145">The maximum value and the default value if not specified is 10000.</span></span> <span data-ttu-id="0b7ce-146">クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-146">If there are more rows in the query, the response body includes a next link that you can use to request the next page of data.</span></span> |  <span data-ttu-id="0b7ce-147">必須ではない</span><span class="sxs-lookup"><span data-stu-id="0b7ce-147">No</span></span>  |
| <span data-ttu-id="0b7ce-148">skip</span><span class="sxs-lookup"><span data-stu-id="0b7ce-148">skip</span></span> | <span data-ttu-id="0b7ce-149">int</span><span class="sxs-lookup"><span data-stu-id="0b7ce-149">int</span></span> | <span data-ttu-id="0b7ce-150">クエリでスキップする行数です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-150">The number of rows to skip in the query.</span></span> <span data-ttu-id="0b7ce-151">大きなデータ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-151">Use this parameter to page through large data sets.</span></span> <span data-ttu-id="0b7ce-152">たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-152">For example, top=10000 and skip=0 retrieves the first 10000 rows of data, top=10000 and skip=10000 retrieves the next 10000 rows of data, and so on.</span></span> |  <span data-ttu-id="0b7ce-153">必須ではない</span><span class="sxs-lookup"><span data-stu-id="0b7ce-153">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="0b7ce-154">要求の例</span><span class="sxs-lookup"><span data-stu-id="0b7ce-154">Request example</span></span>

<span data-ttu-id="0b7ce-155">次の例では、Xbox Live 対応ゲームで最初の 10 個の実績のロックを解除したユーザーの実績データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-155">The following example demonstrates a request for getting achievements data for customers who have unlocked the first 10 achievements for your Xbox Live-enabled game.</span></span> <span data-ttu-id="0b7ce-156">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-156">Replace the *applicationId* value with the Store ID for your game.</span></span>


```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=achievements&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="0b7ce-157">応答</span><span class="sxs-lookup"><span data-stu-id="0b7ce-157">Response</span></span>

| <span data-ttu-id="0b7ce-158">値</span><span class="sxs-lookup"><span data-stu-id="0b7ce-158">Value</span></span>      | <span data-ttu-id="0b7ce-159">型</span><span class="sxs-lookup"><span data-stu-id="0b7ce-159">Type</span></span>   | <span data-ttu-id="0b7ce-160">説明</span><span class="sxs-lookup"><span data-stu-id="0b7ce-160">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="0b7ce-161">Value</span><span class="sxs-lookup"><span data-stu-id="0b7ce-161">Value</span></span>      | <span data-ttu-id="0b7ce-162">array</span><span class="sxs-lookup"><span data-stu-id="0b7ce-162">array</span></span>  | <span data-ttu-id="0b7ce-163">対象ゲームの各実績のデータを含むオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-163">An array of objects that contain data for each achievement in your game.</span></span> <span data-ttu-id="0b7ce-164">各オブジェクト内のデータについて詳しくは、次の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-164">For more information about the data in each object, see the following table.</span></span>                                                                                                                      |
| @nextLink  | <span data-ttu-id="0b7ce-165">string</span><span class="sxs-lookup"><span data-stu-id="0b7ce-165">string</span></span> | <span data-ttu-id="0b7ce-166">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-166">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="0b7ce-167">たとえば、要求の **top** パラメーターが 100 に設定されていたとき、クエリに対して 100 行を超えるデータが一致すると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-167">For example, this value is returned if the **top** parameter of the request is set to 100 but there are more than 100 rows of data for the query.</span></span> |
| <span data-ttu-id="0b7ce-168">TotalCount</span><span class="sxs-lookup"><span data-stu-id="0b7ce-168">TotalCount</span></span> | <span data-ttu-id="0b7ce-169">int</span><span class="sxs-lookup"><span data-stu-id="0b7ce-169">int</span></span>    | <span data-ttu-id="0b7ce-170">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-170">The total number of rows in the data result for the query.</span></span>  |


<span data-ttu-id="0b7ce-171">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-171">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="0b7ce-172">値</span><span class="sxs-lookup"><span data-stu-id="0b7ce-172">Value</span></span>               | <span data-ttu-id="0b7ce-173">型</span><span class="sxs-lookup"><span data-stu-id="0b7ce-173">Type</span></span>   | <span data-ttu-id="0b7ce-174">説明</span><span class="sxs-lookup"><span data-stu-id="0b7ce-174">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="0b7ce-175">applicationId</span><span class="sxs-lookup"><span data-stu-id="0b7ce-175">applicationId</span></span>       | <span data-ttu-id="0b7ce-176">string</span><span class="sxs-lookup"><span data-stu-id="0b7ce-176">string</span></span> | <span data-ttu-id="0b7ce-177">実績データを取得しているゲームの Store ID です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-177">The Store ID of the game for which you are retrieving achievements data.</span></span>     |
| <span data-ttu-id="0b7ce-178">reportDateTime</span><span class="sxs-lookup"><span data-stu-id="0b7ce-178">reportDateTime</span></span>     | <span data-ttu-id="0b7ce-179">string</span><span class="sxs-lookup"><span data-stu-id="0b7ce-179">string</span></span> |  <span data-ttu-id="0b7ce-180">実績データの日付です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-180">The date for the achievements data.</span></span>    |
| <span data-ttu-id="0b7ce-181">achievementId</span><span class="sxs-lookup"><span data-stu-id="0b7ce-181">achievementId</span></span>          | <span data-ttu-id="0b7ce-182">number</span><span class="sxs-lookup"><span data-stu-id="0b7ce-182">number</span></span> |  <span data-ttu-id="0b7ce-183">実績の ID です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-183">The ID of the achievement.</span></span> |
| <span data-ttu-id="0b7ce-184">achievementName</span><span class="sxs-lookup"><span data-stu-id="0b7ce-184">achievementName</span></span>           | <span data-ttu-id="0b7ce-185">string</span><span class="sxs-lookup"><span data-stu-id="0b7ce-185">string</span></span> | <span data-ttu-id="0b7ce-186">実績の名前です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-186">The name of the achievement.</span></span>  |
| <span data-ttu-id="0b7ce-187">gamerscore</span><span class="sxs-lookup"><span data-stu-id="0b7ce-187">gamerscore</span></span>           | <span data-ttu-id="0b7ce-188">number</span><span class="sxs-lookup"><span data-stu-id="0b7ce-188">number</span></span> |  <span data-ttu-id="0b7ce-189">実績のゲーマースコア リワードです。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-189">The gamerscore reward for the achievement.</span></span>  |
| <span data-ttu-id="0b7ce-190">dailyUnlocks</span><span class="sxs-lookup"><span data-stu-id="0b7ce-190">dailyUnlocks</span></span>           | <span data-ttu-id="0b7ce-191">number</span><span class="sxs-lookup"><span data-stu-id="0b7ce-191">number</span></span> |  <span data-ttu-id="0b7ce-192">*reportDateTime* で指定された日付に実績のロックを解除したユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-192">The number of customers who unlocked the achievement on the day specified by *reportDateTime*.</span></span>  |
| <span data-ttu-id="0b7ce-193">monthlyUnlocks</span><span class="sxs-lookup"><span data-stu-id="0b7ce-193">monthlyUnlocks</span></span>              | <span data-ttu-id="0b7ce-194">number</span><span class="sxs-lookup"><span data-stu-id="0b7ce-194">number</span></span> |  <span data-ttu-id="0b7ce-195">*reportDateTime* で指定された日付から過去 30 日間に実績のロックを解除したユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-195">The number of customers who unlocked the achievement in the 30 days prior to the day specified by *reportDateTime*.</span></span>   |
| <span data-ttu-id="0b7ce-196">totalUnlocks</span><span class="sxs-lookup"><span data-stu-id="0b7ce-196">totalUnlocks</span></span> | <span data-ttu-id="0b7ce-197">number</span><span class="sxs-lookup"><span data-stu-id="0b7ce-197">number</span></span> |  <span data-ttu-id="0b7ce-198">ゲームのリリースから *reportDateTime* で指定された日付までの期間に実績のロックを解除したユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-198">The number of customers who have unlocked the achievement during the lifetime of your game, up to the day specified by *reportDateTime*.</span></span>   |


### <a name="response-example"></a><span data-ttu-id="0b7ce-199">応答の例</span><span class="sxs-lookup"><span data-stu-id="0b7ce-199">Response example</span></span>

<span data-ttu-id="0b7ce-200">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0b7ce-200">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="0b7ce-201">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0b7ce-201">Related topics</span></span>

* [<span data-ttu-id="0b7ce-202">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="0b7ce-202">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="0b7ce-203">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="0b7ce-203">Get Xbox Live analytics data</span></span>](get-xbox-live-analytics.md)
* [<span data-ttu-id="0b7ce-204">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="0b7ce-204">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="0b7ce-205">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="0b7ce-205">Get Xbox Live Game Hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="0b7ce-206">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="0b7ce-206">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="0b7ce-207">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="0b7ce-207">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
