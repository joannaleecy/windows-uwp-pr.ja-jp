---
author: mcleanbyron
description: アプリのインサイト データを取得するのに Microsoft Store 分析 API の以下のメソッドを使用します。
title: 分析データを取得します。
ms.author: mcleans
ms.date: 07/31/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, Store サービス, Microsoft Store 分析 API, インサイト
ms.localizationpriority: medium
ms.openlocfilehash: 53fbd91437e5dc702f8672c6cbadeea32a8a96bf
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4130137"
---
# <a name="get-insights-data"></a><span data-ttu-id="a81b1-104">分析データを取得します。</span><span class="sxs-lookup"><span data-stu-id="a81b1-104">Get insights data</span></span>

<span data-ttu-id="a81b1-105">特定の日付範囲やその他のオプション フィルター、取得、正常性, アプリの使用状況のメトリックに関連するインサイト データを取得するのには、Microsoft Store 分析 API の以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="a81b1-105">Use this method in the Microsoft Store analytics API to get insights data related to acquisitions, health, and usage metrics for an app during a given date range and other optional filters.</span></span> <span data-ttu-id="a81b1-106">この情報も[インサイト レポート](../publish/insights-report.md)では、Windows デベロッパー センター ダッシュ ボードで使用できます。</span><span class="sxs-lookup"><span data-stu-id="a81b1-106">This information is also available in the [Insights report](../publish/insights-report.md) in the Windows Dev Center dashboard.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="a81b1-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="a81b1-107">Prerequisites</span></span>


<span data-ttu-id="a81b1-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a81b1-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="a81b1-109">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="a81b1-109">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="a81b1-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="a81b1-110">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="a81b1-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="a81b1-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="a81b1-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="a81b1-113">要求</span><span class="sxs-lookup"><span data-stu-id="a81b1-113">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="a81b1-114">要求の構文</span><span class="sxs-lookup"><span data-stu-id="a81b1-114">Request syntax</span></span>

| <span data-ttu-id="a81b1-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="a81b1-115">Method</span></span> | <span data-ttu-id="a81b1-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a81b1-116">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="a81b1-117">GET</span><span class="sxs-lookup"><span data-stu-id="a81b1-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights``` |


### <a name="request-header"></a><span data-ttu-id="a81b1-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a81b1-118">Request header</span></span>

| <span data-ttu-id="a81b1-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a81b1-119">Header</span></span>        | <span data-ttu-id="a81b1-120">型</span><span class="sxs-lookup"><span data-stu-id="a81b1-120">Type</span></span>   | <span data-ttu-id="a81b1-121">説明</span><span class="sxs-lookup"><span data-stu-id="a81b1-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="a81b1-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="a81b1-122">Authorization</span></span> | <span data-ttu-id="a81b1-123">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-123">string</span></span> | <span data-ttu-id="a81b1-124">必須。</span><span class="sxs-lookup"><span data-stu-id="a81b1-124">Required.</span></span> <span data-ttu-id="a81b1-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="a81b1-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="a81b1-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="a81b1-126">Request parameters</span></span>

| <span data-ttu-id="a81b1-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a81b1-127">Parameter</span></span>        | <span data-ttu-id="a81b1-128">型</span><span class="sxs-lookup"><span data-stu-id="a81b1-128">Type</span></span>   |  <span data-ttu-id="a81b1-129">説明</span><span class="sxs-lookup"><span data-stu-id="a81b1-129">Description</span></span>      |  <span data-ttu-id="a81b1-130">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="a81b1-130">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="a81b1-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="a81b1-131">applicationId</span></span> | <span data-ttu-id="a81b1-132">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-132">string</span></span> | <span data-ttu-id="a81b1-133">分析データを取得するアプリの[ストア ID です](in-app-purchases-and-trials.md#store-ids)。</span><span class="sxs-lookup"><span data-stu-id="a81b1-133">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the app for which you want to retrieve insights data.</span></span> <span data-ttu-id="a81b1-134">このパラメーターを指定しない場合、応答本文にはアカウントに登録されているすべてのアプリのインサイト データが含まれます。</span><span class="sxs-lookup"><span data-stu-id="a81b1-134">If you do not specify this parameter, the response body will contain insights data for all apps registered to your account.</span></span>  |  <span data-ttu-id="a81b1-135">必須ではない</span><span class="sxs-lookup"><span data-stu-id="a81b1-135">No</span></span>  |
| <span data-ttu-id="a81b1-136">startDate</span><span class="sxs-lookup"><span data-stu-id="a81b1-136">startDate</span></span> | <span data-ttu-id="a81b1-137">date</span><span class="sxs-lookup"><span data-stu-id="a81b1-137">date</span></span> | <span data-ttu-id="a81b1-138">取得するインサイト データの日付範囲の開始日です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-138">The start date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="a81b1-139">既定値は、現在の日付の 30 日前です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-139">The default is 30 days before the current date.</span></span> |  <span data-ttu-id="a81b1-140">必須ではない</span><span class="sxs-lookup"><span data-stu-id="a81b1-140">No</span></span>  |
| <span data-ttu-id="a81b1-141">endDate</span><span class="sxs-lookup"><span data-stu-id="a81b1-141">endDate</span></span> | <span data-ttu-id="a81b1-142">date</span><span class="sxs-lookup"><span data-stu-id="a81b1-142">date</span></span> | <span data-ttu-id="a81b1-143">取得するインサイト データの日付範囲の終了日です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-143">The end date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="a81b1-144">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-144">The default is the current date.</span></span> |  <span data-ttu-id="a81b1-145">必須ではない</span><span class="sxs-lookup"><span data-stu-id="a81b1-145">No</span></span>  |
| <span data-ttu-id="a81b1-146">filter</span><span class="sxs-lookup"><span data-stu-id="a81b1-146">filter</span></span> | <span data-ttu-id="a81b1-147">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-147">string</span></span>  | <span data-ttu-id="a81b1-148">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。</span><span class="sxs-lookup"><span data-stu-id="a81b1-148">One or more statements that filter the rows in the response.</span></span> <span data-ttu-id="a81b1-149">各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="a81b1-149">Each statement contains a field name from the response body and value that are associated with the **eq** or **ne** operators, and statements can be combined using **and** or **or**.</span></span> <span data-ttu-id="a81b1-150">*filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。</span><span class="sxs-lookup"><span data-stu-id="a81b1-150">String values must be surrounded by single quotes in the *filter* parameter.</span></span> <span data-ttu-id="a81b1-151">たとえば、 *filter = dataType eq '入手'* します。</span><span class="sxs-lookup"><span data-stu-id="a81b1-151">For example, *filter=dataType eq 'acquisition'*.</span></span> <p/><p/><span data-ttu-id="a81b1-152">次のフィルター フィールドを指定することができます。</span><span class="sxs-lookup"><span data-stu-id="a81b1-152">You can specify the following filter fields:</span></span><p/><ul><li><strong><span data-ttu-id="a81b1-153">入手</span><span class="sxs-lookup"><span data-stu-id="a81b1-153">acquisition</span></span></strong></li><li><strong><span data-ttu-id="a81b1-154">正常性</span><span class="sxs-lookup"><span data-stu-id="a81b1-154">health</span></span></strong></li><li><strong><span data-ttu-id="a81b1-155">使用状況</span><span class="sxs-lookup"><span data-stu-id="a81b1-155">usage</span></span></strong></li></ul> | <span data-ttu-id="a81b1-156">いいえ</span><span class="sxs-lookup"><span data-stu-id="a81b1-156">No</span></span>   |

### <a name="request-example"></a><span data-ttu-id="a81b1-157">要求の例</span><span class="sxs-lookup"><span data-stu-id="a81b1-157">Request example</span></span>

<span data-ttu-id="a81b1-158">次の例では、インサイト データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="a81b1-158">The following example demonstrates a request for getting insights data.</span></span> <span data-ttu-id="a81b1-159">*applicationId* 値を、目的のアプリのストア ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="a81b1-159">Replace the *applicationId* value with the Store ID for your app.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights?applicationId=9NBLGGGZ5QDR&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'acquisition' or dataType eq 'health' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="a81b1-160">応答</span><span class="sxs-lookup"><span data-stu-id="a81b1-160">Response</span></span>

### <a name="response-body"></a><span data-ttu-id="a81b1-161">応答本文</span><span class="sxs-lookup"><span data-stu-id="a81b1-161">Response body</span></span>

| <span data-ttu-id="a81b1-162">値</span><span class="sxs-lookup"><span data-stu-id="a81b1-162">Value</span></span>      | <span data-ttu-id="a81b1-163">型</span><span class="sxs-lookup"><span data-stu-id="a81b1-163">Type</span></span>   | <span data-ttu-id="a81b1-164">説明</span><span class="sxs-lookup"><span data-stu-id="a81b1-164">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="a81b1-165">Value</span><span class="sxs-lookup"><span data-stu-id="a81b1-165">Value</span></span>      | <span data-ttu-id="a81b1-166">array</span><span class="sxs-lookup"><span data-stu-id="a81b1-166">array</span></span>  | <span data-ttu-id="a81b1-167">アプリのインサイト データが含まれるオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-167">An array of objects that contain insights data for the app.</span></span> <span data-ttu-id="a81b1-168">各オブジェクトのデータについて詳しくは、後述の「[インサイトの値](#insight-values)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a81b1-168">For more information about the data in each object, see the [Insight values](#insight-values) section below.</span></span>                                                                                                                      |
| <span data-ttu-id="a81b1-169">TotalCount</span><span class="sxs-lookup"><span data-stu-id="a81b1-169">TotalCount</span></span> | <span data-ttu-id="a81b1-170">int</span><span class="sxs-lookup"><span data-stu-id="a81b1-170">int</span></span>    | <span data-ttu-id="a81b1-171">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-171">The total number of rows in the data result for the query.</span></span>                 |


### <a name="insight-values"></a><span data-ttu-id="a81b1-172">Insight 値</span><span class="sxs-lookup"><span data-stu-id="a81b1-172">Insight values</span></span>

<span data-ttu-id="a81b1-173">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a81b1-173">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="a81b1-174">値</span><span class="sxs-lookup"><span data-stu-id="a81b1-174">Value</span></span>               | <span data-ttu-id="a81b1-175">型</span><span class="sxs-lookup"><span data-stu-id="a81b1-175">Type</span></span>   | <span data-ttu-id="a81b1-176">説明</span><span class="sxs-lookup"><span data-stu-id="a81b1-176">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="a81b1-177">applicationId</span><span class="sxs-lookup"><span data-stu-id="a81b1-177">applicationId</span></span>       | <span data-ttu-id="a81b1-178">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-178">string</span></span> | <span data-ttu-id="a81b1-179">インサイト データを取得するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-179">The Store ID of the app for which you are retrieving insights data.</span></span>     |
| <span data-ttu-id="a81b1-180">insightDate</span><span class="sxs-lookup"><span data-stu-id="a81b1-180">insightDate</span></span>                | <span data-ttu-id="a81b1-181">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-181">string</span></span> | <span data-ttu-id="a81b1-182">特定のメトリックの変更を特定しました日です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-182">The date on which we identified the change in a specific metric.</span></span> <span data-ttu-id="a81b1-183">この日付またはそれより前に、の週との比較メトリックの短縮を大幅に増加を検出しました週の終わりを表します。</span><span class="sxs-lookup"><span data-stu-id="a81b1-183">This date represents the end of the week in which we detected a significant increase or decrease in a metric compared to the week before that.</span></span> |
| <span data-ttu-id="a81b1-184">データ型</span><span class="sxs-lookup"><span data-stu-id="a81b1-184">dataType</span></span>     | <span data-ttu-id="a81b1-185">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-185">string</span></span> | <span data-ttu-id="a81b1-186">この情報を記述する一般的な分析領域を指定する次の文字列のいずれか。</span><span class="sxs-lookup"><span data-stu-id="a81b1-186">One of the following strings that specifies the general analytics area that this insight describes:</span></span><p/><ul><li><strong><span data-ttu-id="a81b1-187">入手</span><span class="sxs-lookup"><span data-stu-id="a81b1-187">acquisition</span></span></strong></li><li><strong><span data-ttu-id="a81b1-188">正常性</span><span class="sxs-lookup"><span data-stu-id="a81b1-188">health</span></span></strong></li><li><strong><span data-ttu-id="a81b1-189">使用状況</span><span class="sxs-lookup"><span data-stu-id="a81b1-189">usage</span></span></strong></li></ul>   |
| <span data-ttu-id="a81b1-190">insightDetail</span><span class="sxs-lookup"><span data-stu-id="a81b1-190">insightDetail</span></span>          | <span data-ttu-id="a81b1-191">array</span><span class="sxs-lookup"><span data-stu-id="a81b1-191">array</span></span> | <span data-ttu-id="a81b1-192">1 つまたは複数[InsightDetail 値](#insightdetail-values)を表す現在インサイトの詳細です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-192">One or more [InsightDetail values](#insightdetail-values) that represent the details for current insight.</span></span>    |


### <a name="insightdetail-values"></a><span data-ttu-id="a81b1-193">InsightDetail 値</span><span class="sxs-lookup"><span data-stu-id="a81b1-193">InsightDetail values</span></span>

| <span data-ttu-id="a81b1-194">値</span><span class="sxs-lookup"><span data-stu-id="a81b1-194">Value</span></span>               | <span data-ttu-id="a81b1-195">型</span><span class="sxs-lookup"><span data-stu-id="a81b1-195">Type</span></span>   | <span data-ttu-id="a81b1-196">説明</span><span class="sxs-lookup"><span data-stu-id="a81b1-196">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="a81b1-197">FactName</span><span class="sxs-lookup"><span data-stu-id="a81b1-197">FactName</span></span>           | <span data-ttu-id="a81b1-198">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-198">string</span></span> | <span data-ttu-id="a81b1-199">現在の洞察または現在のディメンションを記述するメトリックを示す次の値のいずれかの**データ型**の値に基づいています。</span><span class="sxs-lookup"><span data-stu-id="a81b1-199">One of the following values that indicates the metric that the current insight or current dimension describes, based on the **dataType** value.</span></span><ul><li><span data-ttu-id="a81b1-200">**正常性**、この値は常に値が**ヒット数です**。</span><span class="sxs-lookup"><span data-stu-id="a81b1-200">For **health**, this value is always **HitCount**.</span></span></li><li><span data-ttu-id="a81b1-201">**入手**、この値は常に値が**AcquisitionQuantity です**。</span><span class="sxs-lookup"><span data-stu-id="a81b1-201">For **acquisition**, this value is always **AcquisitionQuantity**.</span></span></li><li><span data-ttu-id="a81b1-202">**使用状況**、この値は、次の文字列のいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="a81b1-202">For **usage**, this value can be one of the following strings:</span></span><ul><li><strong><span data-ttu-id="a81b1-203">DailyActiveUsers</span><span class="sxs-lookup"><span data-stu-id="a81b1-203">DailyActiveUsers</span></span></strong></li><li><strong><span data-ttu-id="a81b1-204">EngagementDurationMinutes</span><span class="sxs-lookup"><span data-stu-id="a81b1-204">EngagementDurationMinutes</span></span></strong></li><li><strong><span data-ttu-id="a81b1-205">DailyActiveDevices</span><span class="sxs-lookup"><span data-stu-id="a81b1-205">DailyActiveDevices</span></span></strong></li><li><strong><span data-ttu-id="a81b1-206">DailyNewUsers</span><span class="sxs-lookup"><span data-stu-id="a81b1-206">DailyNewUsers</span></span></strong></li><li><strong><span data-ttu-id="a81b1-207">DailySessionCount</span><span class="sxs-lookup"><span data-stu-id="a81b1-207">DailySessionCount</span></span></strong></li></ul></ul>  |
| <span data-ttu-id="a81b1-208">SubDimensions</span><span class="sxs-lookup"><span data-stu-id="a81b1-208">SubDimensions</span></span>         | <span data-ttu-id="a81b1-209">array</span><span class="sxs-lookup"><span data-stu-id="a81b1-209">array</span></span> |  <span data-ttu-id="a81b1-210">情報を得ることの 1 つのメトリックを記述する 1 つまたは複数のオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a81b1-210">One or more objects that describe a single metric for the insight.</span></span>   |
| <span data-ttu-id="a81b1-211">PercentChange</span><span class="sxs-lookup"><span data-stu-id="a81b1-211">PercentChange</span></span>            | <span data-ttu-id="a81b1-212">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-212">string</span></span> |  <span data-ttu-id="a81b1-213">メトリックは、全体の顧客ベースの間で変更された割合。</span><span class="sxs-lookup"><span data-stu-id="a81b1-213">The percentage that the metric changed across your entire customer base.</span></span>  |
| <span data-ttu-id="a81b1-214">DimensionName</span><span class="sxs-lookup"><span data-stu-id="a81b1-214">DimensionName</span></span>           | <span data-ttu-id="a81b1-215">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-215">string</span></span> |  <span data-ttu-id="a81b1-216">現在の次元で説明されているメトリックの名前です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-216">The name of the metric described in the current dimension.</span></span> <span data-ttu-id="a81b1-217">例には、**イベントの種類**、**市場**、 **DeviceType**、 **PackageVersion**、 **AcquisitionType**、 **AgeGroup** 、**性別**が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a81b1-217">Examples include **EventType**, **Market**, **DeviceType**, **PackageVersion**, **AcquisitionType**, **AgeGroup** and **Gender**.</span></span>   |
| <span data-ttu-id="a81b1-218">DimensionValue</span><span class="sxs-lookup"><span data-stu-id="a81b1-218">DimensionValue</span></span>              | <span data-ttu-id="a81b1-219">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-219">string</span></span> | <span data-ttu-id="a81b1-220">現在のディメンションに記載されているメトリックの値。</span><span class="sxs-lookup"><span data-stu-id="a81b1-220">The value of the metric that is described in the current dimension.</span></span> <span data-ttu-id="a81b1-221">たとえば、 **DimensionName**が**イベントの種類**である場合は、**クラッシュ**や**ハング**が**DimensionValue**することがあります。</span><span class="sxs-lookup"><span data-stu-id="a81b1-221">For example, if **DimensionName** is **EventType**, **DimensionValue** might be **crash** or **hang**.</span></span>   |
| <span data-ttu-id="a81b1-222">FactValue</span><span class="sxs-lookup"><span data-stu-id="a81b1-222">FactValue</span></span>     | <span data-ttu-id="a81b1-223">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-223">string</span></span> | <span data-ttu-id="a81b1-224">情報を得ることが検出された日付のメトリックの絶対値。</span><span class="sxs-lookup"><span data-stu-id="a81b1-224">The absolute value of the metric on the date the insight was detected.</span></span>  |
| <span data-ttu-id="a81b1-225">Direction</span><span class="sxs-lookup"><span data-stu-id="a81b1-225">Direction</span></span> | <span data-ttu-id="a81b1-226">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-226">string</span></span> |  <span data-ttu-id="a81b1-227">(**正**または**負**) の変更の方向です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-227">The direction of the change (**Positive** or **Negative**).</span></span>   |
| <span data-ttu-id="a81b1-228">Date</span><span class="sxs-lookup"><span data-stu-id="a81b1-228">Date</span></span>              | <span data-ttu-id="a81b1-229">string</span><span class="sxs-lookup"><span data-stu-id="a81b1-229">string</span></span> |  <span data-ttu-id="a81b1-230">現在の洞察または現在のディメンションに関連する変更を特定しました日です。</span><span class="sxs-lookup"><span data-stu-id="a81b1-230">The date on which we identified the change related to the current insight or the current dimension.</span></span>   |

### <a name="response-example"></a><span data-ttu-id="a81b1-231">応答の例</span><span class="sxs-lookup"><span data-stu-id="a81b1-231">Response example</span></span>

<span data-ttu-id="a81b1-232">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a81b1-232">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Value": [
    {
      "applicationId": "9NBLGGGZ5QDR",
      "insightDate": "2018-06-03T00:00:00",
      "dataType": "health",
      "insightDetail": [
        {
          "FactName": "HitCount",
          "SubDimensions": [
            {
              "FactName:": "HitCount",
              "PercentChange": "21",
              "DimensionValue:": "DE",
              "FactValue": "109",
              "Direction": "Positive",
              "Date": "6/3/2018 12:00:00 AM",
              "DimensionName": "Market"
            }
          ],
          "DimensionValue": "crash",
          "Date": "6/3/2018 12:00:00 AM",
          "DimensionName": "EventType"
        },
        {
          "FactName": "HitCount",
          "SubDimensions": [
            {
              "FactName:": "HitCount",
              "PercentChange": "71",
              "DimensionValue:": "JP",
              "FactValue": "112",
              "Direction": "Positive",
              "Date": "6/3/2018 12:00:00 AM",
              "DimensionName": "Market"
            }
          ],
          "DimensionValue": "hang",
          "Date": "6/3/2018 12:00:00 AM",
          "DimensionName": "EventType"
        },
      ],
      "insightId": "9CY0F3VBT1AS942AFQaeyO0k2zUKfyOhrOHc0036Iwc="
    }
  ],
  "@nextLink": null,
  "TotalCount": 2
}
```

## <a name="related-topics"></a><span data-ttu-id="a81b1-233">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a81b1-233">Related topics</span></span>

* [<span data-ttu-id="a81b1-234">インサイト レポート</span><span class="sxs-lookup"><span data-stu-id="a81b1-234">Insights report</span></span>](../publish/insights-report.md)
* [<span data-ttu-id="a81b1-235">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="a81b1-235">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
