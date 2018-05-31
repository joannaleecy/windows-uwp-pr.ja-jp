---
author: mcleanbyron
description: Xbox Live クラブのデータを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live クラブのデータの取得
ms.author: mcleans
ms.date: 04/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, クラブ
ms.localizationpriority: medium
ms.openlocfilehash: 09721bf1259c3f44ce2acd5014476aa7e962eaa5
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1816687"
---
# <a name="get-xbox-live-club-data"></a><span data-ttu-id="33764-104">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="33764-104">Get Xbox Live club data</span></span>

<span data-ttu-id="33764-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)のクラブ データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="33764-105">Use this method in the Microsoft Store analytics API to get club data for your [Xbox Live-enabled game](../xbox-live/index.md).</span></span> <span data-ttu-id="33764-106">この情報は、Windows デベロッパー センター ダッシュボードの [Xbox 分析レポート](../publish/xbox-analytics-report.md)でも確認できます。</span><span class="sxs-lookup"><span data-stu-id="33764-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in the Windows Dev Center dashboard.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="33764-107">現在このメソッドがサポートしているのは、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)によって公開された Xbox Live 対応ゲーム、または [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)経由で提出された Xbox Live 対応ゲームだけです。</span><span class="sxs-lookup"><span data-stu-id="33764-107">This method currently only supports Xbox Live-enabled games that are published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) or that are submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="33764-108">[Xbox Live クリエーターズ プログラム](../xbox-live/developer-program-overview.md#xbox-live-creators-program)経由で提出されたゲームのデータは返されません。</span><span class="sxs-lookup"><span data-stu-id="33764-108">It does not return data for games that were submitted via the [Xbox Live Creators Program](../xbox-live/developer-program-overview.md#xbox-live-creators-program).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="33764-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="33764-109">Prerequisites</span></span>

<span data-ttu-id="33764-110">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="33764-110">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="33764-111">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="33764-111">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="33764-112">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="33764-112">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="33764-113">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="33764-113">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="33764-114">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="33764-114">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="33764-115">要求</span><span class="sxs-lookup"><span data-stu-id="33764-115">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="33764-116">要求の構文</span><span class="sxs-lookup"><span data-stu-id="33764-116">Request syntax</span></span>

| <span data-ttu-id="33764-117">メソッド</span><span class="sxs-lookup"><span data-stu-id="33764-117">Method</span></span> | <span data-ttu-id="33764-118">要求 URI</span><span class="sxs-lookup"><span data-stu-id="33764-118">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="33764-119">GET</span><span class="sxs-lookup"><span data-stu-id="33764-119">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="33764-120">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="33764-120">Request header</span></span>

| <span data-ttu-id="33764-121">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="33764-121">Header</span></span>        | <span data-ttu-id="33764-122">型</span><span class="sxs-lookup"><span data-stu-id="33764-122">Type</span></span>   | <span data-ttu-id="33764-123">説明</span><span class="sxs-lookup"><span data-stu-id="33764-123">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="33764-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="33764-124">Authorization</span></span> | <span data-ttu-id="33764-125">文字列</span><span class="sxs-lookup"><span data-stu-id="33764-125">string</span></span> | <span data-ttu-id="33764-126">必須。</span><span class="sxs-lookup"><span data-stu-id="33764-126">Required.</span></span> <span data-ttu-id="33764-127">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="33764-127">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="33764-128">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="33764-128">Request parameters</span></span>


| <span data-ttu-id="33764-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="33764-129">Parameter</span></span>        | <span data-ttu-id="33764-130">型</span><span class="sxs-lookup"><span data-stu-id="33764-130">Type</span></span>   |  <span data-ttu-id="33764-131">説明</span><span class="sxs-lookup"><span data-stu-id="33764-131">Description</span></span>      |  <span data-ttu-id="33764-132">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="33764-132">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="33764-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="33764-133">applicationId</span></span> | <span data-ttu-id="33764-134">string</span><span class="sxs-lookup"><span data-stu-id="33764-134">string</span></span> | <span data-ttu-id="33764-135">Xbox Live クラブのデータを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="33764-135">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve Xbox Live club data.</span></span>  |  <span data-ttu-id="33764-136">必須</span><span class="sxs-lookup"><span data-stu-id="33764-136">Yes</span></span>  |
| <span data-ttu-id="33764-137">metricType</span><span class="sxs-lookup"><span data-stu-id="33764-137">metricType</span></span> | <span data-ttu-id="33764-138">string</span><span class="sxs-lookup"><span data-stu-id="33764-138">string</span></span> | <span data-ttu-id="33764-139">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="33764-139">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="33764-140">このメソッドでは、値 **communitymanagerclub** を指定します。</span><span class="sxs-lookup"><span data-stu-id="33764-140">For this method, specify the value **communitymanagerclub**.</span></span>  |  <span data-ttu-id="33764-141">必須</span><span class="sxs-lookup"><span data-stu-id="33764-141">Yes</span></span>  |
| <span data-ttu-id="33764-142">startDate</span><span class="sxs-lookup"><span data-stu-id="33764-142">startDate</span></span> | <span data-ttu-id="33764-143">date</span><span class="sxs-lookup"><span data-stu-id="33764-143">date</span></span> | <span data-ttu-id="33764-144">取得するクラブ データの日付範囲の開始日です。</span><span class="sxs-lookup"><span data-stu-id="33764-144">The start date in the date range of club data to retrieve.</span></span> <span data-ttu-id="33764-145">既定値は、現在の日付の 30 日前です。</span><span class="sxs-lookup"><span data-stu-id="33764-145">The default is 30 days before the current date.</span></span> |  <span data-ttu-id="33764-146">必須ではない</span><span class="sxs-lookup"><span data-stu-id="33764-146">No</span></span>  |
| <span data-ttu-id="33764-147">endDate</span><span class="sxs-lookup"><span data-stu-id="33764-147">endDate</span></span> | <span data-ttu-id="33764-148">date</span><span class="sxs-lookup"><span data-stu-id="33764-148">date</span></span> | <span data-ttu-id="33764-149">取得するクラブ データの日付範囲の終了日です。</span><span class="sxs-lookup"><span data-stu-id="33764-149">The end date in the date range of club data to retrieve.</span></span> <span data-ttu-id="33764-150">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="33764-150">The default is the current date.</span></span> |  <span data-ttu-id="33764-151">必須ではない</span><span class="sxs-lookup"><span data-stu-id="33764-151">No</span></span>  |
| <span data-ttu-id="33764-152">top</span><span class="sxs-lookup"><span data-stu-id="33764-152">top</span></span> | <span data-ttu-id="33764-153">int</span><span class="sxs-lookup"><span data-stu-id="33764-153">int</span></span> | <span data-ttu-id="33764-154">要求で返すデータの行数です。</span><span class="sxs-lookup"><span data-stu-id="33764-154">The number of rows of data to return in the request.</span></span> <span data-ttu-id="33764-155">指定されない場合の既定値は、最大値でもある 10000 です。</span><span class="sxs-lookup"><span data-stu-id="33764-155">The maximum value and the default value if not specified is 10000.</span></span> <span data-ttu-id="33764-156">クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。</span><span class="sxs-lookup"><span data-stu-id="33764-156">If there are more rows in the query, the response body includes a next link that you can use to request the next page of data.</span></span> |  <span data-ttu-id="33764-157">必須ではない</span><span class="sxs-lookup"><span data-stu-id="33764-157">No</span></span>  |
| <span data-ttu-id="33764-158">skip</span><span class="sxs-lookup"><span data-stu-id="33764-158">skip</span></span> | <span data-ttu-id="33764-159">int</span><span class="sxs-lookup"><span data-stu-id="33764-159">int</span></span> | <span data-ttu-id="33764-160">クエリでスキップする行数です。</span><span class="sxs-lookup"><span data-stu-id="33764-160">The number of rows to skip in the query.</span></span> <span data-ttu-id="33764-161">大きなデータ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="33764-161">Use this parameter to page through large data sets.</span></span> <span data-ttu-id="33764-162">たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。</span><span class="sxs-lookup"><span data-stu-id="33764-162">For example, top=10000 and skip=0 retrieves the first 10000 rows of data, top=10000 and skip=10000 retrieves the next 10000 rows of data, and so on.</span></span> |  <span data-ttu-id="33764-163">必須ではない</span><span class="sxs-lookup"><span data-stu-id="33764-163">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="33764-164">要求の例</span><span class="sxs-lookup"><span data-stu-id="33764-164">Request example</span></span>

<span data-ttu-id="33764-165">次の例では、Xbox Live 対応ゲームのクラブ データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="33764-165">The following example demonstrates a request for getting club data for your Xbox Live-enabled game.</span></span> <span data-ttu-id="33764-166">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="33764-166">Replace the *applicationId* value with the Store ID for your game.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=communitymanagerclub&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="33764-167">応答</span><span class="sxs-lookup"><span data-stu-id="33764-167">Response</span></span>

| <span data-ttu-id="33764-168">値</span><span class="sxs-lookup"><span data-stu-id="33764-168">Value</span></span>      | <span data-ttu-id="33764-169">型</span><span class="sxs-lookup"><span data-stu-id="33764-169">Type</span></span>   | <span data-ttu-id="33764-170">説明</span><span class="sxs-lookup"><span data-stu-id="33764-170">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="33764-171">Value</span><span class="sxs-lookup"><span data-stu-id="33764-171">Value</span></span>      | <span data-ttu-id="33764-172">array</span><span class="sxs-lookup"><span data-stu-id="33764-172">array</span></span>  | <span data-ttu-id="33764-173">対象ゲームに関連するクラブのデータを含む 1 つの [ProductData](#productdata) オブジェクトと、すべての Xbox Live ユーザーに関するクラブ データを含む 1 つの [XboxwideData](#xboxwidedata) オブジェクトを格納する配列です。</span><span class="sxs-lookup"><span data-stu-id="33764-173">An array that contains one [ProductData](#productdata) object that contains data for clubs related to your game and one [XboxwideData](#xboxwidedata) object that contains club data for all Xbox Live customers.</span></span> <span data-ttu-id="33764-174">このデータは、対象ゲームのデータとの比較のために用意されています。</span><span class="sxs-lookup"><span data-stu-id="33764-174">This data is included for comparison purposes with the data for your game.</span></span>  |
| @nextLink  | <span data-ttu-id="33764-175">string</span><span class="sxs-lookup"><span data-stu-id="33764-175">string</span></span> | <span data-ttu-id="33764-176">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="33764-176">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="33764-177">たとえば、要求の **top** パラメーターが 10000 に設定されていたとき、クエリに対して 10000 行を超えるデータが一致すると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="33764-177">For example, this value is returned if the **top** parameter of the request is set to 10000 but there are more than 10000 rows of data for the query.</span></span> |
| <span data-ttu-id="33764-178">TotalCount</span><span class="sxs-lookup"><span data-stu-id="33764-178">TotalCount</span></span> | <span data-ttu-id="33764-179">int</span><span class="sxs-lookup"><span data-stu-id="33764-179">int</span></span>    | <span data-ttu-id="33764-180">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="33764-180">The total number of rows in the data result for the query.</span></span> |


### <a name="productdata"></a><span data-ttu-id="33764-181">ProductData</span><span class="sxs-lookup"><span data-stu-id="33764-181">ProductData</span></span>

<span data-ttu-id="33764-182">このリソースには、対象ゲームのクラブ データが含まれます。</span><span class="sxs-lookup"><span data-stu-id="33764-182">This resource contains club data for your game.</span></span>

| <span data-ttu-id="33764-183">値</span><span class="sxs-lookup"><span data-stu-id="33764-183">Value</span></span>           | <span data-ttu-id="33764-184">型</span><span class="sxs-lookup"><span data-stu-id="33764-184">Type</span></span>    | <span data-ttu-id="33764-185">説明</span><span class="sxs-lookup"><span data-stu-id="33764-185">Description</span></span>        |
|-----------------|---------|------|
| <span data-ttu-id="33764-186">date</span><span class="sxs-lookup"><span data-stu-id="33764-186">date</span></span>            |  <span data-ttu-id="33764-187">string</span><span class="sxs-lookup"><span data-stu-id="33764-187">string</span></span> |   <span data-ttu-id="33764-188">クラブ データの日付です。</span><span class="sxs-lookup"><span data-stu-id="33764-188">The date for the club data.</span></span>   |
|  <span data-ttu-id="33764-189">applicationId</span><span class="sxs-lookup"><span data-stu-id="33764-189">applicationId</span></span>               |    <span data-ttu-id="33764-190">string</span><span class="sxs-lookup"><span data-stu-id="33764-190">string</span></span>     |  <span data-ttu-id="33764-191">クラブ データを取得したゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="33764-191">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you retrieved club data.</span></span>   |
|  <span data-ttu-id="33764-192">clubsWithTitleActivity</span><span class="sxs-lookup"><span data-stu-id="33764-192">clubsWithTitleActivity</span></span>               |    <span data-ttu-id="33764-193">int</span><span class="sxs-lookup"><span data-stu-id="33764-193">int</span></span>     |  <span data-ttu-id="33764-194">対象ゲームにソーシャルに関与しているクラブの数です。</span><span class="sxs-lookup"><span data-stu-id="33764-194">The number of clubs that are socially engaged with your game.</span></span>   |     
|  <span data-ttu-id="33764-195">clubsExclusiveToGame</span><span class="sxs-lookup"><span data-stu-id="33764-195">clubsExclusiveToGame</span></span>               |   <span data-ttu-id="33764-196">int</span><span class="sxs-lookup"><span data-stu-id="33764-196">int</span></span>      |  <span data-ttu-id="33764-197">対象ゲームだけにソーシャルに関与しているクラブの数です。</span><span class="sxs-lookup"><span data-stu-id="33764-197">The number of clubs that are socially engaged exclusively with your game.</span></span>   |     
|  <span data-ttu-id="33764-198">clubFacts</span><span class="sxs-lookup"><span data-stu-id="33764-198">clubFacts</span></span>               |   <span data-ttu-id="33764-199">array</span><span class="sxs-lookup"><span data-stu-id="33764-199">array</span></span>      |   <span data-ttu-id="33764-200">対象ゲームにソーシャルに関与している各クラブの情報を格納する [ClubFacts](#clubfacts) オブジェクトが 1 つ以上含まれます。</span><span class="sxs-lookup"><span data-stu-id="33764-200">Contains one or more [ClubFacts](#clubfacts) objects about each of the clubs that are socially engaged with your game.</span></span>   |


### <a name="xboxwidedata"></a><span data-ttu-id="33764-201">XboxwideData</span><span class="sxs-lookup"><span data-stu-id="33764-201">XboxwideData</span></span>

<span data-ttu-id="33764-202">このリソースには、すべての Xbox Live ユーザーを対象とした平均的なクラブ データが含まれます。</span><span class="sxs-lookup"><span data-stu-id="33764-202">This resource contains average club data across all Xbox Live customers.</span></span>

| <span data-ttu-id="33764-203">値</span><span class="sxs-lookup"><span data-stu-id="33764-203">Value</span></span>           | <span data-ttu-id="33764-204">型</span><span class="sxs-lookup"><span data-stu-id="33764-204">Type</span></span>    | <span data-ttu-id="33764-205">説明</span><span class="sxs-lookup"><span data-stu-id="33764-205">Description</span></span>        |
|-----------------|---------|------|
| <span data-ttu-id="33764-206">date</span><span class="sxs-lookup"><span data-stu-id="33764-206">date</span></span>            |  <span data-ttu-id="33764-207">string</span><span class="sxs-lookup"><span data-stu-id="33764-207">string</span></span> |   <span data-ttu-id="33764-208">クラブ データの日付です。</span><span class="sxs-lookup"><span data-stu-id="33764-208">The date for the club data.</span></span>   |
|  <span data-ttu-id="33764-209">applicationId</span><span class="sxs-lookup"><span data-stu-id="33764-209">applicationId</span></span>  |    <span data-ttu-id="33764-210">string</span><span class="sxs-lookup"><span data-stu-id="33764-210">string</span></span>     |   <span data-ttu-id="33764-211">**XboxwideData** オブジェクトの場合、この文字列は常に値 **XBOXWIDE** になります。</span><span class="sxs-lookup"><span data-stu-id="33764-211">In the **XboxwideData** object, this string is always the value **XBOXWIDE**.</span></span>  |
|  <span data-ttu-id="33764-212">clubsWithTitleActivity</span><span class="sxs-lookup"><span data-stu-id="33764-212">clubsWithTitleActivity</span></span>               |   <span data-ttu-id="33764-213">int</span><span class="sxs-lookup"><span data-stu-id="33764-213">int</span></span>     |  <span data-ttu-id="33764-214">Xbox Live 対応ゲームにソーシャルに関与しているユーザーのいるクラブの平均数です。</span><span class="sxs-lookup"><span data-stu-id="33764-214">On average, the number of clubs with customers that are socially engaged with an Xbox Live-enabled game.</span></span>    |     
|  <span data-ttu-id="33764-215">clubsExclusiveToGame</span><span class="sxs-lookup"><span data-stu-id="33764-215">clubsExclusiveToGame</span></span>               |   <span data-ttu-id="33764-216">int</span><span class="sxs-lookup"><span data-stu-id="33764-216">int</span></span>      |  <span data-ttu-id="33764-217">1 つの Xbox Live 対応ゲームだけにソーシャルに関与しているクラブの平均数です。</span><span class="sxs-lookup"><span data-stu-id="33764-217">On average, the number of clubs that are socially engaged exclusively with an Xbox Live-enabled game.</span></span>   |     
|  <span data-ttu-id="33764-218">clubFacts</span><span class="sxs-lookup"><span data-stu-id="33764-218">clubFacts</span></span>               |   <span data-ttu-id="33764-219">object</span><span class="sxs-lookup"><span data-stu-id="33764-219">object</span></span>      |  <span data-ttu-id="33764-220">1 つの [ClubFacts](#clubfacts) オブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="33764-220">Contains one [ClubFacts](#clubfacts) object.</span></span> <span data-ttu-id="33764-221">このオブジェクトは、**XboxwideData** オブジェクトのコンテキストでは意味を持たず、既定値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="33764-221">This object is meaningless in the context of the **XboxwideData** object and has default values.</span></span>  |


### <a name="clubfacts"></a><span data-ttu-id="33764-222">ClubFacts</span><span class="sxs-lookup"><span data-stu-id="33764-222">ClubFacts</span></span>

<span data-ttu-id="33764-223">**ProductData** オブジェクトの場合、このオブジェクトには、対象ゲームに関連するアクティビティのある特定のクラブのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="33764-223">In the **ProductData** object, this object contains data for a specific club that has activity related to your game.</span></span> <span data-ttu-id="33764-224">**XboxwideData** オブジェクトの場合、このオブジェクトは意味を持たず、既定値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="33764-224">In the **XboxwideData** object, this object is meaningless and has default values.</span></span>

| <span data-ttu-id="33764-225">値</span><span class="sxs-lookup"><span data-stu-id="33764-225">Value</span></span>           | <span data-ttu-id="33764-226">型</span><span class="sxs-lookup"><span data-stu-id="33764-226">Type</span></span>    | <span data-ttu-id="33764-227">説明</span><span class="sxs-lookup"><span data-stu-id="33764-227">Description</span></span>        |
|-----------------|---------|--------------------|
|  <span data-ttu-id="33764-228">name</span><span class="sxs-lookup"><span data-stu-id="33764-228">name</span></span>            |  <span data-ttu-id="33764-229">string</span><span class="sxs-lookup"><span data-stu-id="33764-229">string</span></span>  |   <span data-ttu-id="33764-230">**ProductData** オブジェクトの場合、これはクラブの名前です。</span><span class="sxs-lookup"><span data-stu-id="33764-230">In the **ProductData** object, this is the name of the club.</span></span> <span data-ttu-id="33764-231">**XboxwideData** オブジェクトの場合、これは常に値 **XBOXWIDE** になります。</span><span class="sxs-lookup"><span data-stu-id="33764-231">In the **XboxwideData** object, this is always the value **XBOXWIDE**.</span></span>           |
|  <span data-ttu-id="33764-232">memberCount</span><span class="sxs-lookup"><span data-stu-id="33764-232">memberCount</span></span>               |    <span data-ttu-id="33764-233">int</span><span class="sxs-lookup"><span data-stu-id="33764-233">int</span></span>     | <span data-ttu-id="33764-234">**ProductData** オブジェクトの場合、これはクラブ内のメンバーの数です。クラブを参照しただけの非メンバーは除外されます。</span><span class="sxs-lookup"><span data-stu-id="33764-234">In the **ProductData** object, this is the number of members in the club, excluding non-members who are just visiting the club.</span></span> <span data-ttu-id="33764-235">**XboxwideData** オブジェクトの場合、これは常に 0 になります。</span><span class="sxs-lookup"><span data-stu-id="33764-235">In the **XboxwideData** object, this is always 0.</span></span>    |
|  <span data-ttu-id="33764-236">titleSocialActionsCount</span><span class="sxs-lookup"><span data-stu-id="33764-236">titleSocialActionsCount</span></span>               |    <span data-ttu-id="33764-237">int</span><span class="sxs-lookup"><span data-stu-id="33764-237">int</span></span>     |  <span data-ttu-id="33764-238">**ProductData** オブジェクトの場合、これはクラブ内のメンバーが実行した、対象ゲームに関連するソーシャル活動の数です。</span><span class="sxs-lookup"><span data-stu-id="33764-238">In the **ProductData** object, this is the number of social actions that members in the club have performed that are related to your game.</span></span> <span data-ttu-id="33764-239">**XboxwideData** オブジェクトの場合、これは常に 0 になります。</span><span class="sxs-lookup"><span data-stu-id="33764-239">In the **XboxwideData** object, this is always 0</span></span>   |
|  <span data-ttu-id="33764-240">isExclusiveToGame</span><span class="sxs-lookup"><span data-stu-id="33764-240">isExclusiveToGame</span></span>               |    <span data-ttu-id="33764-241">Boolean</span><span class="sxs-lookup"><span data-stu-id="33764-241">Boolean</span></span>     |  <span data-ttu-id="33764-242">**ProductData** オブジェクトの場合、これは現在のクラブが対象ゲームにソーシャルに関与しているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="33764-242">In the **ProductData** object, this indicates whether the current club is socially engaged exclusively with your game.</span></span> <span data-ttu-id="33764-243">**XboxwideData** オブジェクトの場合、これは常に true になります。</span><span class="sxs-lookup"><span data-stu-id="33764-243">In the **XboxwideData** object, this is always true.</span></span>  |


### <a name="response-example"></a><span data-ttu-id="33764-244">応答の例</span><span class="sxs-lookup"><span data-stu-id="33764-244">Response example</span></span>

<span data-ttu-id="33764-245">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="33764-245">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="33764-246">関連トピック</span><span class="sxs-lookup"><span data-stu-id="33764-246">Related topics</span></span>

* [<span data-ttu-id="33764-247">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="33764-247">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="33764-248">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="33764-248">Get Xbox Live analytics data</span></span>](get-xbox-live-analytics.md)
* [<span data-ttu-id="33764-249">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="33764-249">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="33764-250">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="33764-250">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="33764-251">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="33764-251">Get Xbox Live game hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="33764-252">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="33764-252">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
