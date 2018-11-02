---
author: Xansky
description: アプリのインサイト データを取得するのに、Microsoft Store 分析 API の以下のメソッドを使用します。
title: インサイト データを取得します。
ms.author: mhopkins
ms.date: 07/31/2018
ms.topic: article
keywords: windows 10, uwp, Store サービス, Microsoft Store 分析 API, インサイト
ms.localizationpriority: medium
ms.openlocfilehash: ff70f38ff636b0b1d885981fb9e353ac9afe69c2
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5933263"
---
# <a name="get-insights-data"></a><span data-ttu-id="60336-104">インサイト データを取得します。</span><span class="sxs-lookup"><span data-stu-id="60336-104">Get insights data</span></span>

<span data-ttu-id="60336-105">特定の日付範囲やその他のオプション フィルター、取得、正常性, アプリの使用状況のメトリックに関連するインサイト データを取得するには、Microsoft Store 分析 API の以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="60336-105">Use this method in the Microsoft Store analytics API to get insights data related to acquisitions, health, and usage metrics for an app during a given date range and other optional filters.</span></span> <span data-ttu-id="60336-106">この情報も[インサイト レポート](../publish/insights-report.md)では、Windows デベロッパー センター ダッシュ ボードで使用できます。</span><span class="sxs-lookup"><span data-stu-id="60336-106">This information is also available in the [Insights report](../publish/insights-report.md) in the Windows Dev Center dashboard.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="60336-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="60336-107">Prerequisites</span></span>


<span data-ttu-id="60336-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="60336-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="60336-109">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="60336-109">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="60336-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="60336-110">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="60336-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="60336-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="60336-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="60336-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="60336-113">要求</span><span class="sxs-lookup"><span data-stu-id="60336-113">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="60336-114">要求の構文</span><span class="sxs-lookup"><span data-stu-id="60336-114">Request syntax</span></span>

| <span data-ttu-id="60336-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="60336-115">Method</span></span> | <span data-ttu-id="60336-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="60336-116">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="60336-117">GET</span><span class="sxs-lookup"><span data-stu-id="60336-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights``` |


### <a name="request-header"></a><span data-ttu-id="60336-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="60336-118">Request header</span></span>

| <span data-ttu-id="60336-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="60336-119">Header</span></span>        | <span data-ttu-id="60336-120">型</span><span class="sxs-lookup"><span data-stu-id="60336-120">Type</span></span>   | <span data-ttu-id="60336-121">説明</span><span class="sxs-lookup"><span data-stu-id="60336-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="60336-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="60336-122">Authorization</span></span> | <span data-ttu-id="60336-123">string</span><span class="sxs-lookup"><span data-stu-id="60336-123">string</span></span> | <span data-ttu-id="60336-124">必須。</span><span class="sxs-lookup"><span data-stu-id="60336-124">Required.</span></span> <span data-ttu-id="60336-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="60336-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="60336-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="60336-126">Request parameters</span></span>

| <span data-ttu-id="60336-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="60336-127">Parameter</span></span>        | <span data-ttu-id="60336-128">型</span><span class="sxs-lookup"><span data-stu-id="60336-128">Type</span></span>   |  <span data-ttu-id="60336-129">説明</span><span class="sxs-lookup"><span data-stu-id="60336-129">Description</span></span>      |  <span data-ttu-id="60336-130">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="60336-130">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="60336-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="60336-131">applicationId</span></span> | <span data-ttu-id="60336-132">string</span><span class="sxs-lookup"><span data-stu-id="60336-132">string</span></span> | <span data-ttu-id="60336-133">インサイト データを取得するアプリの[ストア ID です](in-app-purchases-and-trials.md#store-ids)。</span><span class="sxs-lookup"><span data-stu-id="60336-133">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the app for which you want to retrieve insights data.</span></span> <span data-ttu-id="60336-134">このパラメーターを指定しない場合、応答本文にはアカウントに登録されているすべてのアプリのインサイト データが含まれます。</span><span class="sxs-lookup"><span data-stu-id="60336-134">If you do not specify this parameter, the response body will contain insights data for all apps registered to your account.</span></span>  |  <span data-ttu-id="60336-135">必須ではない</span><span class="sxs-lookup"><span data-stu-id="60336-135">No</span></span>  |
| <span data-ttu-id="60336-136">startDate</span><span class="sxs-lookup"><span data-stu-id="60336-136">startDate</span></span> | <span data-ttu-id="60336-137">date</span><span class="sxs-lookup"><span data-stu-id="60336-137">date</span></span> | <span data-ttu-id="60336-138">取得するインサイト データの日付範囲の開始日です。</span><span class="sxs-lookup"><span data-stu-id="60336-138">The start date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="60336-139">既定値は、現在の日付の 30 日前です。</span><span class="sxs-lookup"><span data-stu-id="60336-139">The default is 30 days before the current date.</span></span> |  <span data-ttu-id="60336-140">必須ではない</span><span class="sxs-lookup"><span data-stu-id="60336-140">No</span></span>  |
| <span data-ttu-id="60336-141">endDate</span><span class="sxs-lookup"><span data-stu-id="60336-141">endDate</span></span> | <span data-ttu-id="60336-142">date</span><span class="sxs-lookup"><span data-stu-id="60336-142">date</span></span> | <span data-ttu-id="60336-143">取得するインサイト データの日付範囲の終了日です。</span><span class="sxs-lookup"><span data-stu-id="60336-143">The end date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="60336-144">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="60336-144">The default is the current date.</span></span> |  <span data-ttu-id="60336-145">必須ではない</span><span class="sxs-lookup"><span data-stu-id="60336-145">No</span></span>  |
| <span data-ttu-id="60336-146">filter</span><span class="sxs-lookup"><span data-stu-id="60336-146">filter</span></span> | <span data-ttu-id="60336-147">string</span><span class="sxs-lookup"><span data-stu-id="60336-147">string</span></span>  | <span data-ttu-id="60336-148">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。</span><span class="sxs-lookup"><span data-stu-id="60336-148">One or more statements that filter the rows in the response.</span></span> <span data-ttu-id="60336-149">各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="60336-149">Each statement contains a field name from the response body and value that are associated with the **eq** or **ne** operators, and statements can be combined using **and** or **or**.</span></span> <span data-ttu-id="60336-150">*filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。</span><span class="sxs-lookup"><span data-stu-id="60336-150">String values must be surrounded by single quotes in the *filter* parameter.</span></span> <span data-ttu-id="60336-151">たとえば、*フィルター = dataType eq '入手'* します。</span><span class="sxs-lookup"><span data-stu-id="60336-151">For example, *filter=dataType eq 'acquisition'*.</span></span> <p/><p/><span data-ttu-id="60336-152">次のフィルター フィールドを指定することができます。</span><span class="sxs-lookup"><span data-stu-id="60336-152">You can specify the following filter fields:</span></span><p/><ul><li><strong><span data-ttu-id="60336-153">入手</span><span class="sxs-lookup"><span data-stu-id="60336-153">acquisition</span></span></strong></li><li><strong><span data-ttu-id="60336-154">正常性</span><span class="sxs-lookup"><span data-stu-id="60336-154">health</span></span></strong></li><li><strong><span data-ttu-id="60336-155">使用状況</span><span class="sxs-lookup"><span data-stu-id="60336-155">usage</span></span></strong></li></ul> | <span data-ttu-id="60336-156">いいえ</span><span class="sxs-lookup"><span data-stu-id="60336-156">No</span></span>   |

### <a name="request-example"></a><span data-ttu-id="60336-157">要求の例</span><span class="sxs-lookup"><span data-stu-id="60336-157">Request example</span></span>

<span data-ttu-id="60336-158">次の例では、インサイト データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="60336-158">The following example demonstrates a request for getting insights data.</span></span> <span data-ttu-id="60336-159">*applicationId* 値を、目的のアプリのストア ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="60336-159">Replace the *applicationId* value with the Store ID for your app.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights?applicationId=9NBLGGGZ5QDR&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'acquisition' or dataType eq 'health' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="60336-160">応答</span><span class="sxs-lookup"><span data-stu-id="60336-160">Response</span></span>

### <a name="response-body"></a><span data-ttu-id="60336-161">応答本文</span><span class="sxs-lookup"><span data-stu-id="60336-161">Response body</span></span>

| <span data-ttu-id="60336-162">値</span><span class="sxs-lookup"><span data-stu-id="60336-162">Value</span></span>      | <span data-ttu-id="60336-163">型</span><span class="sxs-lookup"><span data-stu-id="60336-163">Type</span></span>   | <span data-ttu-id="60336-164">説明</span><span class="sxs-lookup"><span data-stu-id="60336-164">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="60336-165">Value</span><span class="sxs-lookup"><span data-stu-id="60336-165">Value</span></span>      | <span data-ttu-id="60336-166">array</span><span class="sxs-lookup"><span data-stu-id="60336-166">array</span></span>  | <span data-ttu-id="60336-167">アプリのインサイト データが含まれるオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="60336-167">An array of objects that contain insights data for the app.</span></span> <span data-ttu-id="60336-168">各オブジェクトのデータについて詳しくは、以下の[洞察値](#insight-values)のセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="60336-168">For more information about the data in each object, see the [Insight values](#insight-values) section below.</span></span>                                                                                                                      |
| <span data-ttu-id="60336-169">TotalCount</span><span class="sxs-lookup"><span data-stu-id="60336-169">TotalCount</span></span> | <span data-ttu-id="60336-170">int</span><span class="sxs-lookup"><span data-stu-id="60336-170">int</span></span>    | <span data-ttu-id="60336-171">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="60336-171">The total number of rows in the data result for the query.</span></span>                 |


### <a name="insight-values"></a><span data-ttu-id="60336-172">洞察値</span><span class="sxs-lookup"><span data-stu-id="60336-172">Insight values</span></span>

<span data-ttu-id="60336-173">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="60336-173">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="60336-174">値</span><span class="sxs-lookup"><span data-stu-id="60336-174">Value</span></span>               | <span data-ttu-id="60336-175">型</span><span class="sxs-lookup"><span data-stu-id="60336-175">Type</span></span>   | <span data-ttu-id="60336-176">説明</span><span class="sxs-lookup"><span data-stu-id="60336-176">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="60336-177">applicationId</span><span class="sxs-lookup"><span data-stu-id="60336-177">applicationId</span></span>       | <span data-ttu-id="60336-178">string</span><span class="sxs-lookup"><span data-stu-id="60336-178">string</span></span> | <span data-ttu-id="60336-179">インサイト データを取得するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="60336-179">The Store ID of the app for which you are retrieving insights data.</span></span>     |
| <span data-ttu-id="60336-180">insightDate</span><span class="sxs-lookup"><span data-stu-id="60336-180">insightDate</span></span>                | <span data-ttu-id="60336-181">string</span><span class="sxs-lookup"><span data-stu-id="60336-181">string</span></span> | <span data-ttu-id="60336-182">個々 の測定値の変更わかりました日です。</span><span class="sxs-lookup"><span data-stu-id="60336-182">The date on which we identified the change in a specific metric.</span></span> <span data-ttu-id="60336-183">この日付は、大幅に増加が検出されましたが、1 週間の末尾を表すメトリックがそれより前に、の週との比較の増減します。</span><span class="sxs-lookup"><span data-stu-id="60336-183">This date represents the end of the week in which we detected a significant increase or decrease in a metric compared to the week before that.</span></span> |
| <span data-ttu-id="60336-184">データ型</span><span class="sxs-lookup"><span data-stu-id="60336-184">dataType</span></span>     | <span data-ttu-id="60336-185">string</span><span class="sxs-lookup"><span data-stu-id="60336-185">string</span></span> | <span data-ttu-id="60336-186">この情報を記述する一般的な分析領域を指定する次の文字列のいずれか。</span><span class="sxs-lookup"><span data-stu-id="60336-186">One of the following strings that specifies the general analytics area that this insight describes:</span></span><p/><ul><li><strong><span data-ttu-id="60336-187">入手</span><span class="sxs-lookup"><span data-stu-id="60336-187">acquisition</span></span></strong></li><li><strong><span data-ttu-id="60336-188">正常性</span><span class="sxs-lookup"><span data-stu-id="60336-188">health</span></span></strong></li><li><strong><span data-ttu-id="60336-189">使用状況</span><span class="sxs-lookup"><span data-stu-id="60336-189">usage</span></span></strong></li></ul>   |
| <span data-ttu-id="60336-190">insightDetail</span><span class="sxs-lookup"><span data-stu-id="60336-190">insightDetail</span></span>          | <span data-ttu-id="60336-191">array</span><span class="sxs-lookup"><span data-stu-id="60336-191">array</span></span> | <span data-ttu-id="60336-192">1 つまたは複数[InsightDetail 値](#insightdetail-values)を表す現在インサイトの詳細情報。</span><span class="sxs-lookup"><span data-stu-id="60336-192">One or more [InsightDetail values](#insightdetail-values) that represent the details for current insight.</span></span>    |


### <a name="insightdetail-values"></a><span data-ttu-id="60336-193">InsightDetail 値</span><span class="sxs-lookup"><span data-stu-id="60336-193">InsightDetail values</span></span>

| <span data-ttu-id="60336-194">値</span><span class="sxs-lookup"><span data-stu-id="60336-194">Value</span></span>               | <span data-ttu-id="60336-195">型</span><span class="sxs-lookup"><span data-stu-id="60336-195">Type</span></span>   | <span data-ttu-id="60336-196">説明</span><span class="sxs-lookup"><span data-stu-id="60336-196">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="60336-197">FactName</span><span class="sxs-lookup"><span data-stu-id="60336-197">FactName</span></span>           | <span data-ttu-id="60336-198">string</span><span class="sxs-lookup"><span data-stu-id="60336-198">string</span></span> | <span data-ttu-id="60336-199">現在の洞察または現在のディメンションを記述するメトリックを示す次の値のいずれかの**データ型**の値に基づいています。</span><span class="sxs-lookup"><span data-stu-id="60336-199">One of the following values that indicates the metric that the current insight or current dimension describes, based on the **dataType** value.</span></span><ul><li><span data-ttu-id="60336-200">**正常性**、この値は常に値が**ヒット数です**。</span><span class="sxs-lookup"><span data-stu-id="60336-200">For **health**, this value is always **HitCount**.</span></span></li><li><span data-ttu-id="60336-201">**入手**、この値は常に値が**AcquisitionQuantity です**。</span><span class="sxs-lookup"><span data-stu-id="60336-201">For **acquisition**, this value is always **AcquisitionQuantity**.</span></span></li><li><span data-ttu-id="60336-202">**使用状況**、この値は、次の文字列のいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="60336-202">For **usage**, this value can be one of the following strings:</span></span><ul><li><strong><span data-ttu-id="60336-203">DailyActiveUsers</span><span class="sxs-lookup"><span data-stu-id="60336-203">DailyActiveUsers</span></span></strong></li><li><strong><span data-ttu-id="60336-204">EngagementDurationMinutes</span><span class="sxs-lookup"><span data-stu-id="60336-204">EngagementDurationMinutes</span></span></strong></li><li><strong><span data-ttu-id="60336-205">DailyActiveDevices</span><span class="sxs-lookup"><span data-stu-id="60336-205">DailyActiveDevices</span></span></strong></li><li><strong><span data-ttu-id="60336-206">DailyNewUsers</span><span class="sxs-lookup"><span data-stu-id="60336-206">DailyNewUsers</span></span></strong></li><li><strong><span data-ttu-id="60336-207">DailySessionCount</span><span class="sxs-lookup"><span data-stu-id="60336-207">DailySessionCount</span></span></strong></li></ul></ul>  |
| <span data-ttu-id="60336-208">SubDimensions</span><span class="sxs-lookup"><span data-stu-id="60336-208">SubDimensions</span></span>         | <span data-ttu-id="60336-209">array</span><span class="sxs-lookup"><span data-stu-id="60336-209">array</span></span> |  <span data-ttu-id="60336-210">情報を得ることの 1 つのメトリックを記述する 1 つまたは複数のオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="60336-210">One or more objects that describe a single metric for the insight.</span></span>   |
| <span data-ttu-id="60336-211">PercentChange</span><span class="sxs-lookup"><span data-stu-id="60336-211">PercentChange</span></span>            | <span data-ttu-id="60336-212">string</span><span class="sxs-lookup"><span data-stu-id="60336-212">string</span></span> |  <span data-ttu-id="60336-213">メトリックは、全体の顧客ベースの間で変更された割合。</span><span class="sxs-lookup"><span data-stu-id="60336-213">The percentage that the metric changed across your entire customer base.</span></span>  |
| <span data-ttu-id="60336-214">DimensionName</span><span class="sxs-lookup"><span data-stu-id="60336-214">DimensionName</span></span>           | <span data-ttu-id="60336-215">string</span><span class="sxs-lookup"><span data-stu-id="60336-215">string</span></span> |  <span data-ttu-id="60336-216">現在のディメンションで説明されているメトリックの名前です。</span><span class="sxs-lookup"><span data-stu-id="60336-216">The name of the metric described in the current dimension.</span></span> <span data-ttu-id="60336-217">例には、**イベントの種類**、**市場**、 **DeviceType**、 **PackageVersion**、 **AcquisitionType**、 **AgeGroup** 、**性別**が含まれます。</span><span class="sxs-lookup"><span data-stu-id="60336-217">Examples include **EventType**, **Market**, **DeviceType**, **PackageVersion**, **AcquisitionType**, **AgeGroup** and **Gender**.</span></span>   |
| <span data-ttu-id="60336-218">DimensionValue</span><span class="sxs-lookup"><span data-stu-id="60336-218">DimensionValue</span></span>              | <span data-ttu-id="60336-219">string</span><span class="sxs-lookup"><span data-stu-id="60336-219">string</span></span> | <span data-ttu-id="60336-220">現在のディメンションに記載されているメトリックの値。</span><span class="sxs-lookup"><span data-stu-id="60336-220">The value of the metric that is described in the current dimension.</span></span> <span data-ttu-id="60336-221">たとえば、 **DimensionName**が**イベントの種類**である場合は、**クラッシュ**や**ハング**が**DimensionValue**することがあります。</span><span class="sxs-lookup"><span data-stu-id="60336-221">For example, if **DimensionName** is **EventType**, **DimensionValue** might be **crash** or **hang**.</span></span>   |
| <span data-ttu-id="60336-222">FactValue</span><span class="sxs-lookup"><span data-stu-id="60336-222">FactValue</span></span>     | <span data-ttu-id="60336-223">string</span><span class="sxs-lookup"><span data-stu-id="60336-223">string</span></span> | <span data-ttu-id="60336-224">情報を得ることが検出された日付、メトリックの絶対値します。</span><span class="sxs-lookup"><span data-stu-id="60336-224">The absolute value of the metric on the date the insight was detected.</span></span>  |
| <span data-ttu-id="60336-225">Direction</span><span class="sxs-lookup"><span data-stu-id="60336-225">Direction</span></span> | <span data-ttu-id="60336-226">string</span><span class="sxs-lookup"><span data-stu-id="60336-226">string</span></span> |  <span data-ttu-id="60336-227">(**正**または**負**) の変更の方向です。</span><span class="sxs-lookup"><span data-stu-id="60336-227">The direction of the change (**Positive** or **Negative**).</span></span>   |
| <span data-ttu-id="60336-228">Date</span><span class="sxs-lookup"><span data-stu-id="60336-228">Date</span></span>              | <span data-ttu-id="60336-229">string</span><span class="sxs-lookup"><span data-stu-id="60336-229">string</span></span> |  <span data-ttu-id="60336-230">現在の洞察または現在のディメンションに関連する変更わかりました日です。</span><span class="sxs-lookup"><span data-stu-id="60336-230">The date on which we identified the change related to the current insight or the current dimension.</span></span>   |

### <a name="response-example"></a><span data-ttu-id="60336-231">応答の例</span><span class="sxs-lookup"><span data-stu-id="60336-231">Response example</span></span>

<span data-ttu-id="60336-232">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="60336-232">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="60336-233">関連トピック</span><span class="sxs-lookup"><span data-stu-id="60336-233">Related topics</span></span>

* [<span data-ttu-id="60336-234">インサイト レポート</span><span class="sxs-lookup"><span data-stu-id="60336-234">Insights report</span></span>](../publish/insights-report.md)
* [<span data-ttu-id="60336-235">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="60336-235">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
