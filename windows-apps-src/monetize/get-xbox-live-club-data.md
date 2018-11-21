---
author: Xansky
description: Xbox Live クラブのデータを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live クラブのデータの取得
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, クラブ
ms.localizationpriority: medium
ms.openlocfilehash: fd28e6877f5b2bb3fa7d85f9dbc7c82672b7ea2f
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7434180"
---
# <a name="get-xbox-live-club-data"></a><span data-ttu-id="09e41-104">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="09e41-104">Get Xbox Live club data</span></span>

<span data-ttu-id="09e41-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)のクラブ データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="09e41-105">Use this method in the Microsoft Store analytics API to get club data for your [Xbox Live-enabled game](../xbox-live/index.md).</span></span> <span data-ttu-id="09e41-106">この情報は、 [Xbox 分析レポート](../publish/xbox-analytics-report.md)では、パートナー センターで利用可能なもできます。</span><span class="sxs-lookup"><span data-stu-id="09e41-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in Partner Center.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="09e41-107">このメソッドは、Xbox のゲームまたは Xbox Live サービスを使用するゲームのみサポートします。</span><span class="sxs-lookup"><span data-stu-id="09e41-107">This method only supports games for Xbox or games that use Xbox Live services.</span></span> <span data-ttu-id="09e41-108">これらのゲームは、[概念の承認プロセス](../gaming/concept-approval.md)を完了する必要があります。これには、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)が発行したゲームと [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)を介して申請されたゲームが含まれます。</span><span class="sxs-lookup"><span data-stu-id="09e41-108">These games must go through the [concept approval process](../gaming/concept-approval.md), which includes games published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) and games submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="09e41-109">このメソッドでは、[Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)を介して発行されたゲームは現在サポートされていません。</span><span class="sxs-lookup"><span data-stu-id="09e41-109">This method does not currently support games published via the [Xbox Live Creators Program](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="09e41-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="09e41-110">Prerequisites</span></span>

<span data-ttu-id="09e41-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="09e41-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="09e41-112">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="09e41-112">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="09e41-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="09e41-113">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="09e41-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="09e41-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="09e41-115">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="09e41-115">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="09e41-116">要求</span><span class="sxs-lookup"><span data-stu-id="09e41-116">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="09e41-117">要求の構文</span><span class="sxs-lookup"><span data-stu-id="09e41-117">Request syntax</span></span>

| <span data-ttu-id="09e41-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="09e41-118">Method</span></span> | <span data-ttu-id="09e41-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="09e41-119">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="09e41-120">GET</span><span class="sxs-lookup"><span data-stu-id="09e41-120">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="09e41-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09e41-121">Request header</span></span>

| <span data-ttu-id="09e41-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09e41-122">Header</span></span>        | <span data-ttu-id="09e41-123">型</span><span class="sxs-lookup"><span data-stu-id="09e41-123">Type</span></span>   | <span data-ttu-id="09e41-124">説明</span><span class="sxs-lookup"><span data-stu-id="09e41-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="09e41-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="09e41-125">Authorization</span></span> | <span data-ttu-id="09e41-126">string</span><span class="sxs-lookup"><span data-stu-id="09e41-126">string</span></span> | <span data-ttu-id="09e41-127">必須。</span><span class="sxs-lookup"><span data-stu-id="09e41-127">Required.</span></span> <span data-ttu-id="09e41-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="09e41-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="09e41-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="09e41-129">Request parameters</span></span>


| <span data-ttu-id="09e41-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09e41-130">Parameter</span></span>        | <span data-ttu-id="09e41-131">型</span><span class="sxs-lookup"><span data-stu-id="09e41-131">Type</span></span>   |  <span data-ttu-id="09e41-132">説明</span><span class="sxs-lookup"><span data-stu-id="09e41-132">Description</span></span>      |  <span data-ttu-id="09e41-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="09e41-133">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="09e41-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="09e41-134">applicationId</span></span> | <span data-ttu-id="09e41-135">string</span><span class="sxs-lookup"><span data-stu-id="09e41-135">string</span></span> | <span data-ttu-id="09e41-136">Xbox Live クラブのデータを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="09e41-136">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve Xbox Live club data.</span></span>  |  <span data-ttu-id="09e41-137">必須</span><span class="sxs-lookup"><span data-stu-id="09e41-137">Yes</span></span>  |
| <span data-ttu-id="09e41-138">metricType</span><span class="sxs-lookup"><span data-stu-id="09e41-138">metricType</span></span> | <span data-ttu-id="09e41-139">string</span><span class="sxs-lookup"><span data-stu-id="09e41-139">string</span></span> | <span data-ttu-id="09e41-140">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="09e41-140">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="09e41-141">このメソッドでは、値 **communitymanagerclub** を指定します。</span><span class="sxs-lookup"><span data-stu-id="09e41-141">For this method, specify the value **communitymanagerclub**.</span></span>  |  <span data-ttu-id="09e41-142">必須</span><span class="sxs-lookup"><span data-stu-id="09e41-142">Yes</span></span>  |
| <span data-ttu-id="09e41-143">startDate</span><span class="sxs-lookup"><span data-stu-id="09e41-143">startDate</span></span> | <span data-ttu-id="09e41-144">date</span><span class="sxs-lookup"><span data-stu-id="09e41-144">date</span></span> | <span data-ttu-id="09e41-145">取得するクラブ データの日付範囲の開始日です。</span><span class="sxs-lookup"><span data-stu-id="09e41-145">The start date in the date range of club data to retrieve.</span></span> <span data-ttu-id="09e41-146">既定値は、現在の日付の 30 日前です。</span><span class="sxs-lookup"><span data-stu-id="09e41-146">The default is 30 days before the current date.</span></span> |  <span data-ttu-id="09e41-147">必須ではない</span><span class="sxs-lookup"><span data-stu-id="09e41-147">No</span></span>  |
| <span data-ttu-id="09e41-148">endDate</span><span class="sxs-lookup"><span data-stu-id="09e41-148">endDate</span></span> | <span data-ttu-id="09e41-149">date</span><span class="sxs-lookup"><span data-stu-id="09e41-149">date</span></span> | <span data-ttu-id="09e41-150">取得するクラブ データの日付範囲の終了日です。</span><span class="sxs-lookup"><span data-stu-id="09e41-150">The end date in the date range of club data to retrieve.</span></span> <span data-ttu-id="09e41-151">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="09e41-151">The default is the current date.</span></span> |  <span data-ttu-id="09e41-152">必須ではない</span><span class="sxs-lookup"><span data-stu-id="09e41-152">No</span></span>  |
| <span data-ttu-id="09e41-153">top</span><span class="sxs-lookup"><span data-stu-id="09e41-153">top</span></span> | <span data-ttu-id="09e41-154">int</span><span class="sxs-lookup"><span data-stu-id="09e41-154">int</span></span> | <span data-ttu-id="09e41-155">要求で返すデータの行数です。</span><span class="sxs-lookup"><span data-stu-id="09e41-155">The number of rows of data to return in the request.</span></span> <span data-ttu-id="09e41-156">指定されない場合の既定値は、最大値でもある 10000 です。</span><span class="sxs-lookup"><span data-stu-id="09e41-156">The maximum value and the default value if not specified is 10000.</span></span> <span data-ttu-id="09e41-157">クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。</span><span class="sxs-lookup"><span data-stu-id="09e41-157">If there are more rows in the query, the response body includes a next link that you can use to request the next page of data.</span></span> |  <span data-ttu-id="09e41-158">必須ではない</span><span class="sxs-lookup"><span data-stu-id="09e41-158">No</span></span>  |
| <span data-ttu-id="09e41-159">skip</span><span class="sxs-lookup"><span data-stu-id="09e41-159">skip</span></span> | <span data-ttu-id="09e41-160">int</span><span class="sxs-lookup"><span data-stu-id="09e41-160">int</span></span> | <span data-ttu-id="09e41-161">クエリでスキップする行数です。</span><span class="sxs-lookup"><span data-stu-id="09e41-161">The number of rows to skip in the query.</span></span> <span data-ttu-id="09e41-162">大きなデータ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="09e41-162">Use this parameter to page through large data sets.</span></span> <span data-ttu-id="09e41-163">たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。</span><span class="sxs-lookup"><span data-stu-id="09e41-163">For example, top=10000 and skip=0 retrieves the first 10000 rows of data, top=10000 and skip=10000 retrieves the next 10000 rows of data, and so on.</span></span> |  <span data-ttu-id="09e41-164">必須ではない</span><span class="sxs-lookup"><span data-stu-id="09e41-164">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="09e41-165">要求の例</span><span class="sxs-lookup"><span data-stu-id="09e41-165">Request example</span></span>

<span data-ttu-id="09e41-166">次の例では、Xbox Live 対応ゲームのクラブ データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="09e41-166">The following example demonstrates a request for getting club data for your Xbox Live-enabled game.</span></span> <span data-ttu-id="09e41-167">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="09e41-167">Replace the *applicationId* value with the Store ID for your game.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=communitymanagerclub&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="09e41-168">応答</span><span class="sxs-lookup"><span data-stu-id="09e41-168">Response</span></span>

| <span data-ttu-id="09e41-169">値</span><span class="sxs-lookup"><span data-stu-id="09e41-169">Value</span></span>      | <span data-ttu-id="09e41-170">型</span><span class="sxs-lookup"><span data-stu-id="09e41-170">Type</span></span>   | <span data-ttu-id="09e41-171">説明</span><span class="sxs-lookup"><span data-stu-id="09e41-171">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="09e41-172">Value</span><span class="sxs-lookup"><span data-stu-id="09e41-172">Value</span></span>      | <span data-ttu-id="09e41-173">array</span><span class="sxs-lookup"><span data-stu-id="09e41-173">array</span></span>  | <span data-ttu-id="09e41-174">対象ゲームに関連するクラブのデータを含む 1 つの [ProductData](#productdata) オブジェクトと、すべての Xbox Live ユーザーに関するクラブ データを含む 1 つの [XboxwideData](#xboxwidedata) オブジェクトを格納する配列です。</span><span class="sxs-lookup"><span data-stu-id="09e41-174">An array that contains one [ProductData](#productdata) object that contains data for clubs related to your game and one [XboxwideData](#xboxwidedata) object that contains club data for all Xbox Live customers.</span></span> <span data-ttu-id="09e41-175">このデータは、対象ゲームのデータとの比較のために用意されています。</span><span class="sxs-lookup"><span data-stu-id="09e41-175">This data is included for comparison purposes with the data for your game.</span></span>  |
| @nextLink  | <span data-ttu-id="09e41-176">string</span><span class="sxs-lookup"><span data-stu-id="09e41-176">string</span></span> | <span data-ttu-id="09e41-177">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="09e41-177">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="09e41-178">たとえば、要求の **top** パラメーターが 10000 に設定されていたとき、クエリに対して 10000 行を超えるデータが一致すると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="09e41-178">For example, this value is returned if the **top** parameter of the request is set to 10000 but there are more than 10000 rows of data for the query.</span></span> |
| <span data-ttu-id="09e41-179">TotalCount</span><span class="sxs-lookup"><span data-stu-id="09e41-179">TotalCount</span></span> | <span data-ttu-id="09e41-180">int</span><span class="sxs-lookup"><span data-stu-id="09e41-180">int</span></span>    | <span data-ttu-id="09e41-181">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="09e41-181">The total number of rows in the data result for the query.</span></span> |


### <a name="productdata"></a><span data-ttu-id="09e41-182">ProductData</span><span class="sxs-lookup"><span data-stu-id="09e41-182">ProductData</span></span>

<span data-ttu-id="09e41-183">このリソースには、対象ゲームのクラブ データが含まれます。</span><span class="sxs-lookup"><span data-stu-id="09e41-183">This resource contains club data for your game.</span></span>

| <span data-ttu-id="09e41-184">値</span><span class="sxs-lookup"><span data-stu-id="09e41-184">Value</span></span>           | <span data-ttu-id="09e41-185">型</span><span class="sxs-lookup"><span data-stu-id="09e41-185">Type</span></span>    | <span data-ttu-id="09e41-186">説明</span><span class="sxs-lookup"><span data-stu-id="09e41-186">Description</span></span>        |
|-----------------|---------|------|
| <span data-ttu-id="09e41-187">date</span><span class="sxs-lookup"><span data-stu-id="09e41-187">date</span></span>            |  <span data-ttu-id="09e41-188">string</span><span class="sxs-lookup"><span data-stu-id="09e41-188">string</span></span> |   <span data-ttu-id="09e41-189">クラブ データの日付です。</span><span class="sxs-lookup"><span data-stu-id="09e41-189">The date for the club data.</span></span>   |
|  <span data-ttu-id="09e41-190">applicationId</span><span class="sxs-lookup"><span data-stu-id="09e41-190">applicationId</span></span>               |    <span data-ttu-id="09e41-191">string</span><span class="sxs-lookup"><span data-stu-id="09e41-191">string</span></span>     |  <span data-ttu-id="09e41-192">クラブ データを取得したゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="09e41-192">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you retrieved club data.</span></span>   |
|  <span data-ttu-id="09e41-193">clubsWithTitleActivity</span><span class="sxs-lookup"><span data-stu-id="09e41-193">clubsWithTitleActivity</span></span>               |    <span data-ttu-id="09e41-194">int</span><span class="sxs-lookup"><span data-stu-id="09e41-194">int</span></span>     |  <span data-ttu-id="09e41-195">対象ゲームにソーシャルに関与しているクラブの数です。</span><span class="sxs-lookup"><span data-stu-id="09e41-195">The number of clubs that are socially engaged with your game.</span></span>   |     
|  <span data-ttu-id="09e41-196">clubsExclusiveToGame</span><span class="sxs-lookup"><span data-stu-id="09e41-196">clubsExclusiveToGame</span></span>               |   <span data-ttu-id="09e41-197">int</span><span class="sxs-lookup"><span data-stu-id="09e41-197">int</span></span>      |  <span data-ttu-id="09e41-198">対象ゲームだけにソーシャルに関与しているクラブの数です。</span><span class="sxs-lookup"><span data-stu-id="09e41-198">The number of clubs that are socially engaged exclusively with your game.</span></span>   |     
|  <span data-ttu-id="09e41-199">clubFacts</span><span class="sxs-lookup"><span data-stu-id="09e41-199">clubFacts</span></span>               |   <span data-ttu-id="09e41-200">array</span><span class="sxs-lookup"><span data-stu-id="09e41-200">array</span></span>      |   <span data-ttu-id="09e41-201">対象ゲームにソーシャルに関与している各クラブの情報を格納する [ClubFacts](#clubfacts) オブジェクトが 1 つ以上含まれます。</span><span class="sxs-lookup"><span data-stu-id="09e41-201">Contains one or more [ClubFacts](#clubfacts) objects about each of the clubs that are socially engaged with your game.</span></span>   |


### <a name="xboxwidedata"></a><span data-ttu-id="09e41-202">XboxwideData</span><span class="sxs-lookup"><span data-stu-id="09e41-202">XboxwideData</span></span>

<span data-ttu-id="09e41-203">このリソースには、すべての Xbox Live ユーザーを対象とした平均的なクラブ データが含まれます。</span><span class="sxs-lookup"><span data-stu-id="09e41-203">This resource contains average club data across all Xbox Live customers.</span></span>

| <span data-ttu-id="09e41-204">値</span><span class="sxs-lookup"><span data-stu-id="09e41-204">Value</span></span>           | <span data-ttu-id="09e41-205">型</span><span class="sxs-lookup"><span data-stu-id="09e41-205">Type</span></span>    | <span data-ttu-id="09e41-206">説明</span><span class="sxs-lookup"><span data-stu-id="09e41-206">Description</span></span>        |
|-----------------|---------|------|
| <span data-ttu-id="09e41-207">date</span><span class="sxs-lookup"><span data-stu-id="09e41-207">date</span></span>            |  <span data-ttu-id="09e41-208">string</span><span class="sxs-lookup"><span data-stu-id="09e41-208">string</span></span> |   <span data-ttu-id="09e41-209">クラブ データの日付です。</span><span class="sxs-lookup"><span data-stu-id="09e41-209">The date for the club data.</span></span>   |
|  <span data-ttu-id="09e41-210">applicationId</span><span class="sxs-lookup"><span data-stu-id="09e41-210">applicationId</span></span>  |    <span data-ttu-id="09e41-211">string</span><span class="sxs-lookup"><span data-stu-id="09e41-211">string</span></span>     |   <span data-ttu-id="09e41-212">**XboxwideData** オブジェクトの場合、この文字列は常に値 **XBOXWIDE** になります。</span><span class="sxs-lookup"><span data-stu-id="09e41-212">In the **XboxwideData** object, this string is always the value **XBOXWIDE**.</span></span>  |
|  <span data-ttu-id="09e41-213">clubsWithTitleActivity</span><span class="sxs-lookup"><span data-stu-id="09e41-213">clubsWithTitleActivity</span></span>               |   <span data-ttu-id="09e41-214">int</span><span class="sxs-lookup"><span data-stu-id="09e41-214">int</span></span>     |  <span data-ttu-id="09e41-215">Xbox Live 対応ゲームにソーシャルに関与しているユーザーのいるクラブの平均数です。</span><span class="sxs-lookup"><span data-stu-id="09e41-215">On average, the number of clubs with customers that are socially engaged with an Xbox Live-enabled game.</span></span>    |     
|  <span data-ttu-id="09e41-216">clubsExclusiveToGame</span><span class="sxs-lookup"><span data-stu-id="09e41-216">clubsExclusiveToGame</span></span>               |   <span data-ttu-id="09e41-217">int</span><span class="sxs-lookup"><span data-stu-id="09e41-217">int</span></span>      |  <span data-ttu-id="09e41-218">1 つの Xbox Live 対応ゲームだけにソーシャルに関与しているクラブの平均数です。</span><span class="sxs-lookup"><span data-stu-id="09e41-218">On average, the number of clubs that are socially engaged exclusively with an Xbox Live-enabled game.</span></span>   |     
|  <span data-ttu-id="09e41-219">clubFacts</span><span class="sxs-lookup"><span data-stu-id="09e41-219">clubFacts</span></span>               |   <span data-ttu-id="09e41-220">object</span><span class="sxs-lookup"><span data-stu-id="09e41-220">object</span></span>      |  <span data-ttu-id="09e41-221">1 つの [ClubFacts](#clubfacts) オブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="09e41-221">Contains one [ClubFacts](#clubfacts) object.</span></span> <span data-ttu-id="09e41-222">このオブジェクトは、**XboxwideData** オブジェクトのコンテキストでは意味を持たず、既定値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="09e41-222">This object is meaningless in the context of the **XboxwideData** object and has default values.</span></span>  |


### <a name="clubfacts"></a><span data-ttu-id="09e41-223">ClubFacts</span><span class="sxs-lookup"><span data-stu-id="09e41-223">ClubFacts</span></span>

<span data-ttu-id="09e41-224">**ProductData** オブジェクトの場合、このオブジェクトには、対象ゲームに関連するアクティビティのある特定のクラブのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="09e41-224">In the **ProductData** object, this object contains data for a specific club that has activity related to your game.</span></span> <span data-ttu-id="09e41-225">**XboxwideData** オブジェクトの場合、このオブジェクトは意味を持たず、既定値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="09e41-225">In the **XboxwideData** object, this object is meaningless and has default values.</span></span>

| <span data-ttu-id="09e41-226">値</span><span class="sxs-lookup"><span data-stu-id="09e41-226">Value</span></span>           | <span data-ttu-id="09e41-227">型</span><span class="sxs-lookup"><span data-stu-id="09e41-227">Type</span></span>    | <span data-ttu-id="09e41-228">説明</span><span class="sxs-lookup"><span data-stu-id="09e41-228">Description</span></span>        |
|-----------------|---------|--------------------|
|  <span data-ttu-id="09e41-229">name</span><span class="sxs-lookup"><span data-stu-id="09e41-229">name</span></span>            |  <span data-ttu-id="09e41-230">string</span><span class="sxs-lookup"><span data-stu-id="09e41-230">string</span></span>  |   <span data-ttu-id="09e41-231">**ProductData** オブジェクトの場合、これはクラブの名前です。</span><span class="sxs-lookup"><span data-stu-id="09e41-231">In the **ProductData** object, this is the name of the club.</span></span> <span data-ttu-id="09e41-232">**XboxwideData** オブジェクトの場合、これは常に値 **XBOXWIDE** になります。</span><span class="sxs-lookup"><span data-stu-id="09e41-232">In the **XboxwideData** object, this is always the value **XBOXWIDE**.</span></span>           |
|  <span data-ttu-id="09e41-233">memberCount</span><span class="sxs-lookup"><span data-stu-id="09e41-233">memberCount</span></span>               |    <span data-ttu-id="09e41-234">int</span><span class="sxs-lookup"><span data-stu-id="09e41-234">int</span></span>     | <span data-ttu-id="09e41-235">**ProductData** オブジェクトの場合、これはクラブ内のメンバーの数です。クラブを参照しただけの非メンバーは除外されます。</span><span class="sxs-lookup"><span data-stu-id="09e41-235">In the **ProductData** object, this is the number of members in the club, excluding non-members who are just visiting the club.</span></span> <span data-ttu-id="09e41-236">**XboxwideData** オブジェクトの場合、これは常に 0 になります。</span><span class="sxs-lookup"><span data-stu-id="09e41-236">In the **XboxwideData** object, this is always 0.</span></span>    |
|  <span data-ttu-id="09e41-237">titleSocialActionsCount</span><span class="sxs-lookup"><span data-stu-id="09e41-237">titleSocialActionsCount</span></span>               |    <span data-ttu-id="09e41-238">int</span><span class="sxs-lookup"><span data-stu-id="09e41-238">int</span></span>     |  <span data-ttu-id="09e41-239">**ProductData** オブジェクトの場合、これはクラブ内のメンバーが実行した、対象ゲームに関連するソーシャル活動の数です。</span><span class="sxs-lookup"><span data-stu-id="09e41-239">In the **ProductData** object, this is the number of social actions that members in the club have performed that are related to your game.</span></span> <span data-ttu-id="09e41-240">**XboxwideData** オブジェクトの場合、これは常に 0 になります。</span><span class="sxs-lookup"><span data-stu-id="09e41-240">In the **XboxwideData** object, this is always 0</span></span>   |
|  <span data-ttu-id="09e41-241">isExclusiveToGame</span><span class="sxs-lookup"><span data-stu-id="09e41-241">isExclusiveToGame</span></span>               |    <span data-ttu-id="09e41-242">Boolean</span><span class="sxs-lookup"><span data-stu-id="09e41-242">Boolean</span></span>     |  <span data-ttu-id="09e41-243">**ProductData** オブジェクトの場合、これは現在のクラブが対象ゲームにソーシャルに関与しているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="09e41-243">In the **ProductData** object, this indicates whether the current club is socially engaged exclusively with your game.</span></span> <span data-ttu-id="09e41-244">**XboxwideData** オブジェクトの場合、これは常に true になります。</span><span class="sxs-lookup"><span data-stu-id="09e41-244">In the **XboxwideData** object, this is always true.</span></span>  |


### <a name="response-example"></a><span data-ttu-id="09e41-245">応答の例</span><span class="sxs-lookup"><span data-stu-id="09e41-245">Response example</span></span>

<span data-ttu-id="09e41-246">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="09e41-246">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Value": [
    {
      "ProductData": [
        {
          "date": "2018-01-30",
          "applicationId": "9NBLGGGZ5QDR",
          "clubsWithTitleActivity": 3,
          "clubsExclusiveToGame": 1,
          "clubFacts": [
            {
              "name": "Club Contoso Racing",
              "memberCount": 1,
              "titleSocialActionsCount": 1,
              "isExclusiveToGame": false
            },
            {
              "name": "Club Contoso Sports",
              "memberCount": 12,
              "titleSocialActionsCount": 9,
              "isExclusiveToGame": false
            },
            {
              "name": "Club Contoso Maze",
              "memberCount": 4,
              "titleSocialActionsCount": 2,
              "isExclusiveToGame": false
            }
          ]
        }
      ],
      "XboxwideData": [
        {
          "date": "2018-01-30",
          "applicationId": "XBOXWIDE",
          "clubsWithTitleActivity": 25,
          "clubsExclusiveToGame": 3,
          "clubFacts": [
            {
              "name": "XBOXWIDE",
              "memberCount": 0,
              "titleSocialActionsCount": 0,
              "isExclusiveToGame": true
            }
          ]
        }
      ]
    }
  ],
  "@nextLink": "gameanalytics?applicationId=9NBLGGGZ5QDR&metricType=communitymanagerclub&top=1&skip=1&startDate=2018/01/04&endDate=2018/02/02&orderby=date desc",
  "TotalCount": 27
}
```

## <a name="related-topics"></a><span data-ttu-id="09e41-247">関連トピック</span><span class="sxs-lookup"><span data-stu-id="09e41-247">Related topics</span></span>

* [<span data-ttu-id="09e41-248">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="09e41-248">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="09e41-249">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="09e41-249">Get Xbox Live analytics data</span></span>](get-xbox-live-analytics.md)
* [<span data-ttu-id="09e41-250">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="09e41-250">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="09e41-251">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="09e41-251">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="09e41-252">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="09e41-252">Get Xbox Live game hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="09e41-253">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="09e41-253">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
