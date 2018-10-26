---
author: Xansky
ms.assetid: A26A287C-B4B0-49E9-BB28-6F02472AE1BA
description: 日付範囲やその他のオプション フィルターを指定して、特定のアプリケーションの広告キャンペーンのパフォーマンスに関する集計データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: 広告キャンペーンのパフォーマンス データの取得
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 337342378fc42b33c0bddb980b143ab195305458
ms.sourcegitcommit: b7e3d222e229cdbf04e837fcb94fb7d84a93de09
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5621711"
---
# <a name="get-ad-campaign-performance-data"></a><span data-ttu-id="5425c-104">広告キャンペーンのパフォーマンス データの取得</span><span class="sxs-lookup"><span data-stu-id="5425c-104">Get ad campaign performance data</span></span>


<span data-ttu-id="5425c-105">日付範囲やその他のオプション フィルターを指定して、アプリケーションに関するプロモーション用広告キャンペーンのパフォーマンス データの集計サマリーを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="5425c-105">Use this method in the Microsoft Store analytics API to get an aggregate summary of promotional ad campaign performance data for your applications during a given date range and other optional filters.</span></span> <span data-ttu-id="5425c-106">このメソッドは、データを JSON 形式で返します。</span><span class="sxs-lookup"><span data-stu-id="5425c-106">This method returns the data in JSON format.</span></span>

<span data-ttu-id="5425c-107">このメソッドは、Windows デベロッパー センター ダッシュボードの[アプリのインストールの広告レポート](../publish/app-install-ads-reports.md)で提供されるデータと同じデータを返します。</span><span class="sxs-lookup"><span data-stu-id="5425c-107">This method returns the same data that is provided by the [App install ads report](../publish/app-install-ads-reports.md) on the Windows Dev Center dashboard.</span></span> <span data-ttu-id="5425c-108">広告キャンペーンについて詳しくは、「[アプリ向けの広告キャンペーンの作成](../publish/create-an-ad-campaign-for-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5425c-108">For more information about ad campaigns, see [Create an ad campaign for your app](../publish/create-an-ad-campaign-for-your-app.md).</span></span>

<span data-ttu-id="5425c-109">広告キャンペーンの詳細を作成、更新、取得するには、[Microsoft Store プロモーション API](run-ad-campaigns-using-windows-store-services.md) の[広告キャンペーンの管理](manage-ad-campaigns.md)メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="5425c-109">To create, update, or retrieve details for ad campaigns, you can use the [Manage ad campaigns](manage-ad-campaigns.md) methods in the [Microsoft Store promotions API](run-ad-campaigns-using-windows-store-services.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="5425c-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="5425c-110">Prerequisites</span></span>

<span data-ttu-id="5425c-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5425c-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="5425c-112">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="5425c-112">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="5425c-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="5425c-113">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="5425c-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="5425c-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="5425c-115">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="5425c-115">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="5425c-116">要求</span><span class="sxs-lookup"><span data-stu-id="5425c-116">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="5425c-117">要求の構文</span><span class="sxs-lookup"><span data-stu-id="5425c-117">Request syntax</span></span>

| <span data-ttu-id="5425c-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="5425c-118">Method</span></span> | <span data-ttu-id="5425c-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="5425c-119">Request URI</span></span>                                                              |
|--------|--------------------------------------------------------------------------|
| <span data-ttu-id="5425c-120">GET</span><span class="sxs-lookup"><span data-stu-id="5425c-120">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/promotion``` |


### <a name="request-header"></a><span data-ttu-id="5425c-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5425c-121">Request header</span></span>

| <span data-ttu-id="5425c-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5425c-122">Header</span></span>        | <span data-ttu-id="5425c-123">型</span><span class="sxs-lookup"><span data-stu-id="5425c-123">Type</span></span>   | <span data-ttu-id="5425c-124">説明</span><span class="sxs-lookup"><span data-stu-id="5425c-124">Description</span></span>                |
|---------------|--------|---------------|
| <span data-ttu-id="5425c-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="5425c-125">Authorization</span></span> | <span data-ttu-id="5425c-126">string</span><span class="sxs-lookup"><span data-stu-id="5425c-126">string</span></span> | <span data-ttu-id="5425c-127">必須。</span><span class="sxs-lookup"><span data-stu-id="5425c-127">Required.</span></span> <span data-ttu-id="5425c-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="5425c-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="5425c-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="5425c-129">Request parameters</span></span>

<span data-ttu-id="5425c-130">特定のアプリに関する広告キャンペーンのパフォーマンス データを取得するには、*applicationId* パラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="5425c-130">To retrieve ad campaign performance data for a specific app, use the *applicationId* parameter.</span></span> <span data-ttu-id="5425c-131">開発者アカウントに関連付けられているすべてのアプリに関する広告パフォーマンス データを取得するには、*applicationId* パラメーターは省略します。</span><span class="sxs-lookup"><span data-stu-id="5425c-131">To retrieve ad performance data for all apps that are associated with your developer account, omit the *applicationId* parameter.</span></span>

| <span data-ttu-id="5425c-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5425c-132">Parameter</span></span>     | <span data-ttu-id="5425c-133">型</span><span class="sxs-lookup"><span data-stu-id="5425c-133">Type</span></span>   | <span data-ttu-id="5425c-134">説明</span><span class="sxs-lookup"><span data-stu-id="5425c-134">Description</span></span>     | <span data-ttu-id="5425c-135">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="5425c-135">Required</span></span> |
|---------------|--------|-----------------|----------|
| <span data-ttu-id="5425c-136">applicationId</span><span class="sxs-lookup"><span data-stu-id="5425c-136">applicationId</span></span>   | <span data-ttu-id="5425c-137">string</span><span class="sxs-lookup"><span data-stu-id="5425c-137">string</span></span>    | <span data-ttu-id="5425c-138">広告キャンペーンのパフォーマンス データを取得するアプリの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="5425c-138">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the app for which you want to retrieve ad campaign performance data.</span></span> |    <span data-ttu-id="5425c-139">必須ではない</span><span class="sxs-lookup"><span data-stu-id="5425c-139">No</span></span>      |
|  <span data-ttu-id="5425c-140">startDate</span><span class="sxs-lookup"><span data-stu-id="5425c-140">startDate</span></span>  |  <span data-ttu-id="5425c-141">date</span><span class="sxs-lookup"><span data-stu-id="5425c-141">date</span></span>   |  <span data-ttu-id="5425c-142">広告キャンペーンのパフォーマンス データを取得する日付範囲の開始日です。YYYY/MM/DD の形式で指定します。</span><span class="sxs-lookup"><span data-stu-id="5425c-142">The start date in the date range of ad campaign performance data to retrieve, in the format YYYY/MM/DD.</span></span> <span data-ttu-id="5425c-143">既定値は、現在の日付から 30 日を差し引いた日付になります。</span><span class="sxs-lookup"><span data-stu-id="5425c-143">The default is the current date minus 30 days.</span></span>   |   <span data-ttu-id="5425c-144">必須ではない</span><span class="sxs-lookup"><span data-stu-id="5425c-144">No</span></span>    |
| <span data-ttu-id="5425c-145">endDate</span><span class="sxs-lookup"><span data-stu-id="5425c-145">endDate</span></span>   |  <span data-ttu-id="5425c-146">date</span><span class="sxs-lookup"><span data-stu-id="5425c-146">date</span></span>   |  <span data-ttu-id="5425c-147">広告キャンペーンのパフォーマンス データを取得する日付範囲の終了日です。YYYY/MM/DD の形式で指定します。</span><span class="sxs-lookup"><span data-stu-id="5425c-147">The end date in the date range of ad campaign performance data to retrieve, in the format YYYY/MM/DD.</span></span> <span data-ttu-id="5425c-148">既定値は、現在の日付から 1 日を差し引いた日付になります。</span><span class="sxs-lookup"><span data-stu-id="5425c-148">The default is the current date minus one day.</span></span>   |   <span data-ttu-id="5425c-149">必須ではない</span><span class="sxs-lookup"><span data-stu-id="5425c-149">No</span></span>    |
| <span data-ttu-id="5425c-150">top</span><span class="sxs-lookup"><span data-stu-id="5425c-150">top</span></span>   |  <span data-ttu-id="5425c-151">int</span><span class="sxs-lookup"><span data-stu-id="5425c-151">int</span></span>   |  <span data-ttu-id="5425c-152">要求で返すデータの行数です。</span><span class="sxs-lookup"><span data-stu-id="5425c-152">The number of rows of data to return in the request.</span></span> <span data-ttu-id="5425c-153">指定されない場合の既定値は、最大値でもある 10000 です。</span><span class="sxs-lookup"><span data-stu-id="5425c-153">The maximum value and the default value if not specified is 10000.</span></span> <span data-ttu-id="5425c-154">クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。</span><span class="sxs-lookup"><span data-stu-id="5425c-154">If there are more rows in the query, the response body includes a next link that you can use to request the next page of data.</span></span>   |   <span data-ttu-id="5425c-155">必須ではない</span><span class="sxs-lookup"><span data-stu-id="5425c-155">No</span></span>    |
| <span data-ttu-id="5425c-156">skip</span><span class="sxs-lookup"><span data-stu-id="5425c-156">skip</span></span>   | <span data-ttu-id="5425c-157">int</span><span class="sxs-lookup"><span data-stu-id="5425c-157">int</span></span>    |  <span data-ttu-id="5425c-158">クエリでスキップする行数です。</span><span class="sxs-lookup"><span data-stu-id="5425c-158">The number of rows to skip in the query.</span></span> <span data-ttu-id="5425c-159">大きなデータ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="5425c-159">Use this parameter to page through large data sets.</span></span> <span data-ttu-id="5425c-160">たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。</span><span class="sxs-lookup"><span data-stu-id="5425c-160">For example, top=10000 and skip=0 retrieves the first 10000 rows of data, top=10000 and skip=10000 retrieves the next 10000 rows of data, and so on.</span></span>   |   <span data-ttu-id="5425c-161">必須ではない</span><span class="sxs-lookup"><span data-stu-id="5425c-161">No</span></span>    |
| <span data-ttu-id="5425c-162">filter</span><span class="sxs-lookup"><span data-stu-id="5425c-162">filter</span></span>   |  <span data-ttu-id="5425c-163">string</span><span class="sxs-lookup"><span data-stu-id="5425c-163">string</span></span>   |  <span data-ttu-id="5425c-164">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。</span><span class="sxs-lookup"><span data-stu-id="5425c-164">One or more statements that filter the rows in the response.</span></span> <span data-ttu-id="5425c-165">サポートされているフィルターは **campaignId** のみです。</span><span class="sxs-lookup"><span data-stu-id="5425c-165">The only supported filter is **campaignId**.</span></span> <span data-ttu-id="5425c-166">各ステートメントでは **eq** や **ne** 演算子を使用できます。また、ステートメントを **and** や **or** で結合することもできます。</span><span class="sxs-lookup"><span data-stu-id="5425c-166">Each statement can use the **eq** or **ne** operators, and statements can be combined using **and** or **or**.</span></span>  <span data-ttu-id="5425c-167">*filter* パラメーターの例: ```filter=campaignId eq '100023'```。</span><span class="sxs-lookup"><span data-stu-id="5425c-167">Here is an example *filter* parameter: ```filter=campaignId eq '100023'```.</span></span>   |   <span data-ttu-id="5425c-168">必須ではない</span><span class="sxs-lookup"><span data-stu-id="5425c-168">No</span></span>    |
|  <span data-ttu-id="5425c-169">aggregationLevel</span><span class="sxs-lookup"><span data-stu-id="5425c-169">aggregationLevel</span></span>  |  <span data-ttu-id="5425c-170">string</span><span class="sxs-lookup"><span data-stu-id="5425c-170">string</span></span>   | <span data-ttu-id="5425c-171">集計データを取得する時間範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="5425c-171">Specifies the time range for which to retrieve aggregate data.</span></span> <span data-ttu-id="5425c-172">次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。</span><span class="sxs-lookup"><span data-stu-id="5425c-172">Can be one of the following strings: <strong>day</strong>, <strong>week</strong>, or <strong>month</strong>.</span></span> <span data-ttu-id="5425c-173">指定されていない場合、既定値は <strong>day</strong> です。</span><span class="sxs-lookup"><span data-stu-id="5425c-173">If unspecified, the default is <strong>day</strong>.</span></span>    |   <span data-ttu-id="5425c-174">必須ではない</span><span class="sxs-lookup"><span data-stu-id="5425c-174">No</span></span>    |
| <span data-ttu-id="5425c-175">orderby</span><span class="sxs-lookup"><span data-stu-id="5425c-175">orderby</span></span>   |  <span data-ttu-id="5425c-176">string</span><span class="sxs-lookup"><span data-stu-id="5425c-176">string</span></span>   |  <p><span data-ttu-id="5425c-177">広告キャンペーンのパフォーマンス データに関する結果データ値の順序を指定するステートメントです。</span><span class="sxs-lookup"><span data-stu-id="5425c-177">A statement that orders the result data values for the ad campaign performance data.</span></span> <span data-ttu-id="5425c-178">構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターは次のいずれかの文字列になります。</span><span class="sxs-lookup"><span data-stu-id="5425c-178">The syntax is <em>orderby=field [order],field [order],...</em>. The <em>field</em> parameter can be one of the following strings:</span></span></p><ul><li><strong><span data-ttu-id="5425c-179">date</span><span class="sxs-lookup"><span data-stu-id="5425c-179">date</span></span></strong></li><li><strong><span data-ttu-id="5425c-180">campaignId</span><span class="sxs-lookup"><span data-stu-id="5425c-180">campaignId</span></span></strong></li></ul><p><span data-ttu-id="5425c-181"><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。</span><span class="sxs-lookup"><span data-stu-id="5425c-181">The <em>order</em> parameter is optional, and can be <strong>asc</strong> or <strong>desc</strong> to specify ascending or descending order for each field.</span></span> <span data-ttu-id="5425c-182">既定値は <strong>asc</strong> です。</span><span class="sxs-lookup"><span data-stu-id="5425c-182">The default is <strong>asc</strong>.</span></span></p><p><span data-ttu-id="5425c-183"><em>orderby</em> 文字列の例: <em>orderby=date,campaignId</em></span><span class="sxs-lookup"><span data-stu-id="5425c-183">Here is an example <em>orderby</em> string: <em>orderby=date,campaignId</em></span></span></p>   |   <span data-ttu-id="5425c-184">必須ではない</span><span class="sxs-lookup"><span data-stu-id="5425c-184">No</span></span>    |
|  <span data-ttu-id="5425c-185">groupby</span><span class="sxs-lookup"><span data-stu-id="5425c-185">groupby</span></span>  |  <span data-ttu-id="5425c-186">string</span><span class="sxs-lookup"><span data-stu-id="5425c-186">string</span></span>   |  <p><span data-ttu-id="5425c-187">指定したフィールドのみにデータ集計を適用するステートメントです。</span><span class="sxs-lookup"><span data-stu-id="5425c-187">A statement that applies data aggregation only to the specified fields.</span></span> <span data-ttu-id="5425c-188">次のフィールドを指定できます。</span><span class="sxs-lookup"><span data-stu-id="5425c-188">You can specify the following fields:</span></span></p><ul><li><strong><span data-ttu-id="5425c-189">campaignId</span><span class="sxs-lookup"><span data-stu-id="5425c-189">campaignId</span></span></strong></li><li><strong><span data-ttu-id="5425c-190">applicationId</span><span class="sxs-lookup"><span data-stu-id="5425c-190">applicationId</span></span></strong></li><li><strong><span data-ttu-id="5425c-191">date</span><span class="sxs-lookup"><span data-stu-id="5425c-191">date</span></span></strong></li><li><strong><span data-ttu-id="5425c-192">currencyCode</span><span class="sxs-lookup"><span data-stu-id="5425c-192">currencyCode</span></span></strong></li></ul><p><span data-ttu-id="5425c-193"><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。</span><span class="sxs-lookup"><span data-stu-id="5425c-193">The <em>groupby</em> parameter can be used with the <em>aggregationLevel</em> parameter.</span></span> <span data-ttu-id="5425c-194">例: <em>&amp;groupby=applicationId&amp;aggregationLevel=week</em></span><span class="sxs-lookup"><span data-stu-id="5425c-194">For example: <em>&amp;groupby=applicationId&amp;aggregationLevel=week</em></span></span></p>   |   <span data-ttu-id="5425c-195">必須ではない</span><span class="sxs-lookup"><span data-stu-id="5425c-195">No</span></span>    |


### <a name="request-example"></a><span data-ttu-id="5425c-196">要求の例</span><span class="sxs-lookup"><span data-stu-id="5425c-196">Request example</span></span>

<span data-ttu-id="5425c-197">広告キャンペーンのパフォーマンス データを取得するための要求の例を、いくつか次に示します。</span><span class="sxs-lookup"><span data-stu-id="5425c-197">The following example demonstrates several requests for getting ad campaign performance data.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/promotion?aggregationLevel=week&groupby=applicationId,campaignId,date  HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/promotion?applicationId=9NBLGGH0XK8Z&startDate=2015/1/20&endDate=2016/8/31&skip=0&filter=campaignId eq '31007388' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="5425c-198">応答</span><span class="sxs-lookup"><span data-stu-id="5425c-198">Response</span></span>


### <a name="response-body"></a><span data-ttu-id="5425c-199">応答本文</span><span class="sxs-lookup"><span data-stu-id="5425c-199">Response body</span></span>

| <span data-ttu-id="5425c-200">値</span><span class="sxs-lookup"><span data-stu-id="5425c-200">Value</span></span>      | <span data-ttu-id="5425c-201">型</span><span class="sxs-lookup"><span data-stu-id="5425c-201">Type</span></span>   | <span data-ttu-id="5425c-202">説明</span><span class="sxs-lookup"><span data-stu-id="5425c-202">Description</span></span>  |
|------------|--------|---------------|
| <span data-ttu-id="5425c-203">Value</span><span class="sxs-lookup"><span data-stu-id="5425c-203">Value</span></span>      | <span data-ttu-id="5425c-204">array</span><span class="sxs-lookup"><span data-stu-id="5425c-204">array</span></span>  | <span data-ttu-id="5425c-205">広告キャンペーンのパフォーマンスに関する集計データが含まれるオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="5425c-205">An array of objects that contain aggregate ad campaign performance data.</span></span> <span data-ttu-id="5425c-206">各オブジェクトのデータについて詳しくは、次の「[キャンペーンのパフォーマンス オブジェクト](#campaign-performance-object)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5425c-206">For more information about the data in each object, see the [campaign performance object](#campaign-performance-object) section below.</span></span>          |
| @nextLink  | <span data-ttu-id="5425c-207">string</span><span class="sxs-lookup"><span data-stu-id="5425c-207">string</span></span> | <span data-ttu-id="5425c-208">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="5425c-208">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="5425c-209">たとえば、要求の **top** パラメーターが 5 に設定されたが、クエリに対するデータに 5 個を超える項目が含まれている場合に、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="5425c-209">For example, this value is returned if the **top** parameter of the request is set to 5 but there are more than 5 items of data for the query.</span></span> |
| <span data-ttu-id="5425c-210">TotalCount</span><span class="sxs-lookup"><span data-stu-id="5425c-210">TotalCount</span></span> | <span data-ttu-id="5425c-211">int</span><span class="sxs-lookup"><span data-stu-id="5425c-211">int</span></span>    | <span data-ttu-id="5425c-212">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="5425c-212">The total number of rows in the data result for the query.</span></span>                                |


<span id="campaign-performance-object" />


### <a name="campaign-performance-object"></a><span data-ttu-id="5425c-213">キャンペーンのパフォーマンス オブジェクト</span><span class="sxs-lookup"><span data-stu-id="5425c-213">Campaign performance object</span></span>

<span data-ttu-id="5425c-214">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="5425c-214">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="5425c-215">値</span><span class="sxs-lookup"><span data-stu-id="5425c-215">Value</span></span>               | <span data-ttu-id="5425c-216">型</span><span class="sxs-lookup"><span data-stu-id="5425c-216">Type</span></span>   | <span data-ttu-id="5425c-217">説明</span><span class="sxs-lookup"><span data-stu-id="5425c-217">Description</span></span>            |
|---------------------|--------|------------------------|
| <span data-ttu-id="5425c-218">date</span><span class="sxs-lookup"><span data-stu-id="5425c-218">date</span></span>                | <span data-ttu-id="5425c-219">string</span><span class="sxs-lookup"><span data-stu-id="5425c-219">string</span></span> | <span data-ttu-id="5425c-220">広告キャンペーンのパフォーマンス データの対象となる日付範囲の最初の日付です。</span><span class="sxs-lookup"><span data-stu-id="5425c-220">The first date in the date range for the ad campaign performance data.</span></span> <span data-ttu-id="5425c-221">要求に日付を指定した場合、この値はその日付になります。</span><span class="sxs-lookup"><span data-stu-id="5425c-221">If the request specified a single day, this value is that date.</span></span> <span data-ttu-id="5425c-222">要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。</span><span class="sxs-lookup"><span data-stu-id="5425c-222">If the request specified a week, month, or other date range, this value is the first date in that date range.</span></span> |
| <span data-ttu-id="5425c-223">applicationId</span><span class="sxs-lookup"><span data-stu-id="5425c-223">applicationId</span></span>       | <span data-ttu-id="5425c-224">string</span><span class="sxs-lookup"><span data-stu-id="5425c-224">string</span></span> | <span data-ttu-id="5425c-225">広告キャンペーンのパフォーマンス データを取得するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="5425c-225">The Store ID of the app for which you are retrieving ad campaign performance data.</span></span>                     |
| <span data-ttu-id="5425c-226">campaignId</span><span class="sxs-lookup"><span data-stu-id="5425c-226">campaignId</span></span>     | <span data-ttu-id="5425c-227">string</span><span class="sxs-lookup"><span data-stu-id="5425c-227">string</span></span> | <span data-ttu-id="5425c-228">広告キャンペーンの ID です。</span><span class="sxs-lookup"><span data-stu-id="5425c-228">The ID of the ad campaign.</span></span>           |
| <span data-ttu-id="5425c-229">lineId</span><span class="sxs-lookup"><span data-stu-id="5425c-229">lineId</span></span>     | <span data-ttu-id="5425c-230">string</span><span class="sxs-lookup"><span data-stu-id="5425c-230">string</span></span> |    <span data-ttu-id="5425c-231">このパフォーマンス データを生成した広告キャンペーン[配信ライン](manage-delivery-lines-for-ad-campaigns.md)の ID です。</span><span class="sxs-lookup"><span data-stu-id="5425c-231">The ID of the ad campaign [delivery line](manage-delivery-lines-for-ad-campaigns.md) that generated this performance data.</span></span>        |
| <span data-ttu-id="5425c-232">currencyCode</span><span class="sxs-lookup"><span data-stu-id="5425c-232">currencyCode</span></span>              | <span data-ttu-id="5425c-233">string</span><span class="sxs-lookup"><span data-stu-id="5425c-233">string</span></span> | <span data-ttu-id="5425c-234">キャンペーン予算の通貨コードです。</span><span class="sxs-lookup"><span data-stu-id="5425c-234">The currency code of the campaign budget.</span></span>              |
| <span data-ttu-id="5425c-235">spend</span><span class="sxs-lookup"><span data-stu-id="5425c-235">spend</span></span>          | <span data-ttu-id="5425c-236">string</span><span class="sxs-lookup"><span data-stu-id="5425c-236">string</span></span> |  <span data-ttu-id="5425c-237">広告キャンペーンで消費した予算金額です。</span><span class="sxs-lookup"><span data-stu-id="5425c-237">The budget amount that has been spent for the ad campaign.</span></span>     |
| <span data-ttu-id="5425c-238">impressions</span><span class="sxs-lookup"><span data-stu-id="5425c-238">impressions</span></span>           | <span data-ttu-id="5425c-239">long</span><span class="sxs-lookup"><span data-stu-id="5425c-239">long</span></span> | <span data-ttu-id="5425c-240">キャンペーンの広告インプレッションの数です。</span><span class="sxs-lookup"><span data-stu-id="5425c-240">The number of ad impressions for the campaign.</span></span>        |
| <span data-ttu-id="5425c-241">installs</span><span class="sxs-lookup"><span data-stu-id="5425c-241">installs</span></span>              | <span data-ttu-id="5425c-242">long</span><span class="sxs-lookup"><span data-stu-id="5425c-242">long</span></span> | <span data-ttu-id="5425c-243">キャンペーンに関連するアプリのインストールの数です。</span><span class="sxs-lookup"><span data-stu-id="5425c-243">The number of app installs related to the campaign.</span></span>   |
| <span data-ttu-id="5425c-244">clicks</span><span class="sxs-lookup"><span data-stu-id="5425c-244">clicks</span></span>            | <span data-ttu-id="5425c-245">long</span><span class="sxs-lookup"><span data-stu-id="5425c-245">long</span></span> | <span data-ttu-id="5425c-246">キャンペーンの広告クリックの数です。</span><span class="sxs-lookup"><span data-stu-id="5425c-246">The number of ad clicks for the campaign.</span></span>      |
| <span data-ttu-id="5425c-247">iapInstalls</span><span class="sxs-lookup"><span data-stu-id="5425c-247">iapInstalls</span></span>            | <span data-ttu-id="5425c-248">long</span><span class="sxs-lookup"><span data-stu-id="5425c-248">long</span></span> | <span data-ttu-id="5425c-249">キャンペーンに関連するアドオン (アプリ内購入または IAP とも呼ばれます) のインストールの数。</span><span class="sxs-lookup"><span data-stu-id="5425c-249">The number of add-on (also called in-app purchase or IAP) installs related to the campaign.</span></span>      |
| <span data-ttu-id="5425c-250">activeUsers</span><span class="sxs-lookup"><span data-stu-id="5425c-250">activeUsers</span></span>            | <span data-ttu-id="5425c-251">long</span><span class="sxs-lookup"><span data-stu-id="5425c-251">long</span></span> | <span data-ttu-id="5425c-252">キャンペーンの一部である広告をクリックし、アプリに戻ったユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="5425c-252">The number of users who have clicked an ad that is part of the campaign and returned to the app.</span></span>      |


### <a name="response-example"></a><span data-ttu-id="5425c-253">応答の例</span><span class="sxs-lookup"><span data-stu-id="5425c-253">Response example</span></span>

<span data-ttu-id="5425c-254">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="5425c-254">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Value": [
    {
      "date": "2015-04-12",
      "applicationId": "9WZDNCRFJ31Q",
      "campaignId": "4568",
      "lineId": "0001",
      "currencyCode": "USD",
      "spend": 700.6,
      "impressions": 200,
      "installs": 30,
      "clicks": 8,
      "iapInstalls": 0,
      "activeUsers": 0
    },
    {
      "date": "2015-05-12",
      "applicationId": "9WZDNCRFJ31Q",
      "campaignId": "1234",
      "lineId": "0002",
      "currencyCode": "USD",
      "spend": 325.3,
      "impressions": 20,
      "installs": 2,
      "clicks": 5,
      "iapInstalls": 0,
      "activeUsers": 0
    }
  ],
  "@nextLink": "promotion?applicationId=9NBLGGGZ5QDR&aggregationLevel=day&startDate=2015/1/20&endDate=2016/8/31&top=2&skip=2",
  "TotalCount": 1917
}
```

## <a name="related-topics"></a><span data-ttu-id="5425c-255">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5425c-255">Related topics</span></span>

* [<span data-ttu-id="5425c-256">アプリの広告キャンペーンの作成</span><span class="sxs-lookup"><span data-stu-id="5425c-256">Create an ad campaign for your app</span></span>](https://msdn.microsoft.com/windows/uwp/publish/create-an-ad-campaign-for-your-app)
* [<span data-ttu-id="5425c-257">Microsoft Store サービスを使用した広告キャンペーンの実行</span><span class="sxs-lookup"><span data-stu-id="5425c-257">Run ad campaigns using Microsoft Store services</span></span>](run-ad-campaigns-using-windows-store-services.md)
* [<span data-ttu-id="5425c-258">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="5425c-258">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
