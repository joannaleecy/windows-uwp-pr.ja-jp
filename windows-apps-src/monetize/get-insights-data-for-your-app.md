---
description: Microsoft Store analytics API でこのメソッドを使用すると、アプリの insights のデータを取得できます。
title: Insights のデータを取得します。
ms.date: 07/31/2018
ms.topic: article
keywords: windows 10、uwp、Store services、Microsoft Store analytics API、insights
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 1847f22f52eb066115b5681e745e74ec74f77f7d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662847"
---
# <a name="get-insights-data"></a><span data-ttu-id="f6292-104">Insights のデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="f6292-104">Get insights data</span></span>

<span data-ttu-id="f6292-105">Insights データを取得するには、Microsoft Store analytics API では、このメソッドは、特定の日付範囲とその他のオプションのフィルターの中に、買収、ヘルス、およびアプリの使用状況メトリックに関連するを使用します。</span><span class="sxs-lookup"><span data-stu-id="f6292-105">Use this method in the Microsoft Store analytics API to get insights data related to acquisitions, health, and usage metrics for an app during a given date range and other optional filters.</span></span> <span data-ttu-id="f6292-106">この情報も記載されて、 [Insights レポート](../publish/insights-report.md)パートナー センターでします。</span><span class="sxs-lookup"><span data-stu-id="f6292-106">This information is also available in the [Insights report](../publish/insights-report.md) in Partner Center.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="f6292-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="f6292-107">Prerequisites</span></span>


<span data-ttu-id="f6292-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6292-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="f6292-109">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="f6292-109">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="f6292-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="f6292-110">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="f6292-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="f6292-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="f6292-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f6292-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="f6292-113">要求</span><span class="sxs-lookup"><span data-stu-id="f6292-113">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="f6292-114">要求の構文</span><span class="sxs-lookup"><span data-stu-id="f6292-114">Request syntax</span></span>

| <span data-ttu-id="f6292-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="f6292-115">Method</span></span> | <span data-ttu-id="f6292-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="f6292-116">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="f6292-117">GET</span><span class="sxs-lookup"><span data-stu-id="f6292-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights``` |


### <a name="request-header"></a><span data-ttu-id="f6292-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f6292-118">Request header</span></span>

| <span data-ttu-id="f6292-119">Header</span><span class="sxs-lookup"><span data-stu-id="f6292-119">Header</span></span>        | <span data-ttu-id="f6292-120">種類</span><span class="sxs-lookup"><span data-stu-id="f6292-120">Type</span></span>   | <span data-ttu-id="f6292-121">説明</span><span class="sxs-lookup"><span data-stu-id="f6292-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="f6292-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="f6292-122">Authorization</span></span> | <span data-ttu-id="f6292-123">string</span><span class="sxs-lookup"><span data-stu-id="f6292-123">string</span></span> | <span data-ttu-id="f6292-124">必須。</span><span class="sxs-lookup"><span data-stu-id="f6292-124">Required.</span></span> <span data-ttu-id="f6292-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="f6292-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="f6292-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="f6292-126">Request parameters</span></span>

| <span data-ttu-id="f6292-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f6292-127">Parameter</span></span>        | <span data-ttu-id="f6292-128">種類</span><span class="sxs-lookup"><span data-stu-id="f6292-128">Type</span></span>   |  <span data-ttu-id="f6292-129">説明</span><span class="sxs-lookup"><span data-stu-id="f6292-129">Description</span></span>      |  <span data-ttu-id="f6292-130">必須</span><span class="sxs-lookup"><span data-stu-id="f6292-130">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="f6292-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="f6292-131">applicationId</span></span> | <span data-ttu-id="f6292-132">string</span><span class="sxs-lookup"><span data-stu-id="f6292-132">string</span></span> | <span data-ttu-id="f6292-133">[Store ID](in-app-purchases-and-trials.md#store-ids) insights データを取得するアプリの。</span><span class="sxs-lookup"><span data-stu-id="f6292-133">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the app for which you want to retrieve insights data.</span></span> <span data-ttu-id="f6292-134">このパラメーターを指定しないと、応答本文は、自分のアカウントに登録されているすべてのアプリの insights のデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="f6292-134">If you do not specify this parameter, the response body will contain insights data for all apps registered to your account.</span></span>  |  <span data-ttu-id="f6292-135">X</span><span class="sxs-lookup"><span data-stu-id="f6292-135">No</span></span>  |
| <span data-ttu-id="f6292-136">startDate</span><span class="sxs-lookup"><span data-stu-id="f6292-136">startDate</span></span> | <span data-ttu-id="f6292-137">date</span><span class="sxs-lookup"><span data-stu-id="f6292-137">date</span></span> | <span data-ttu-id="f6292-138">取得する insights データの日付範囲の開始日。</span><span class="sxs-lookup"><span data-stu-id="f6292-138">The start date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="f6292-139">既定値は、現在の日付の 30 日前です。</span><span class="sxs-lookup"><span data-stu-id="f6292-139">The default is 30 days before the current date.</span></span> |  <span data-ttu-id="f6292-140">X</span><span class="sxs-lookup"><span data-stu-id="f6292-140">No</span></span>  |
| <span data-ttu-id="f6292-141">endDate</span><span class="sxs-lookup"><span data-stu-id="f6292-141">endDate</span></span> | <span data-ttu-id="f6292-142">date</span><span class="sxs-lookup"><span data-stu-id="f6292-142">date</span></span> | <span data-ttu-id="f6292-143">取得する insights データの日付範囲の終了日。</span><span class="sxs-lookup"><span data-stu-id="f6292-143">The end date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="f6292-144">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="f6292-144">The default is the current date.</span></span> |  <span data-ttu-id="f6292-145">X</span><span class="sxs-lookup"><span data-stu-id="f6292-145">No</span></span>  |
| <span data-ttu-id="f6292-146">filter</span><span class="sxs-lookup"><span data-stu-id="f6292-146">filter</span></span> | <span data-ttu-id="f6292-147">string</span><span class="sxs-lookup"><span data-stu-id="f6292-147">string</span></span>  | <span data-ttu-id="f6292-148">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。</span><span class="sxs-lookup"><span data-stu-id="f6292-148">One or more statements that filter the rows in the response.</span></span> <span data-ttu-id="f6292-149">各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="f6292-149">Each statement contains a field name from the response body and value that are associated with the **eq** or **ne** operators, and statements can be combined using **and** or **or**.</span></span> <span data-ttu-id="f6292-150">*filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6292-150">String values must be surrounded by single quotes in the *filter* parameter.</span></span> <span data-ttu-id="f6292-151">たとえば、*フィルター = データ型 eq '買収'* します。</span><span class="sxs-lookup"><span data-stu-id="f6292-151">For example, *filter=dataType eq 'acquisition'*.</span></span> <p/><p/><span data-ttu-id="f6292-152">次のフィルター フィールドを指定できます。</span><span class="sxs-lookup"><span data-stu-id="f6292-152">You can specify the following filter fields:</span></span><p/><ul><li><span data-ttu-id="f6292-153"><strong>取得</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-153"><strong>acquisition</strong></span></span></li><li><span data-ttu-id="f6292-154"><strong>正常性</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-154"><strong>health</strong></span></span></li><li><span data-ttu-id="f6292-155"><strong>使用状況</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-155"><strong>usage</strong></span></span></li></ul> | <span data-ttu-id="f6292-156">X</span><span class="sxs-lookup"><span data-stu-id="f6292-156">No</span></span>   |

### <a name="request-example"></a><span data-ttu-id="f6292-157">要求の例</span><span class="sxs-lookup"><span data-stu-id="f6292-157">Request example</span></span>

<span data-ttu-id="f6292-158">次の例では、insights データを取得するための要求を示します。</span><span class="sxs-lookup"><span data-stu-id="f6292-158">The following example demonstrates a request for getting insights data.</span></span> <span data-ttu-id="f6292-159">*applicationId* 値を、目的のアプリのストア ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="f6292-159">Replace the *applicationId* value with the Store ID for your app.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights?applicationId=9NBLGGGZ5QDR&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'acquisition' or dataType eq 'health' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="f6292-160">応答</span><span class="sxs-lookup"><span data-stu-id="f6292-160">Response</span></span>

### <a name="response-body"></a><span data-ttu-id="f6292-161">応答本文</span><span class="sxs-lookup"><span data-stu-id="f6292-161">Response body</span></span>

| <span data-ttu-id="f6292-162">Value</span><span class="sxs-lookup"><span data-stu-id="f6292-162">Value</span></span>      | <span data-ttu-id="f6292-163">種類</span><span class="sxs-lookup"><span data-stu-id="f6292-163">Type</span></span>   | <span data-ttu-id="f6292-164">説明</span><span class="sxs-lookup"><span data-stu-id="f6292-164">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="f6292-165">Value</span><span class="sxs-lookup"><span data-stu-id="f6292-165">Value</span></span>      | <span data-ttu-id="f6292-166">array</span><span class="sxs-lookup"><span data-stu-id="f6292-166">array</span></span>  | <span data-ttu-id="f6292-167">アプリの insights のデータを格納するオブジェクトの配列。</span><span class="sxs-lookup"><span data-stu-id="f6292-167">An array of objects that contain insights data for the app.</span></span> <span data-ttu-id="f6292-168">各オブジェクトのデータの詳細については、次を参照してください。、 [Insight 値](#insight-values)以下のセクション。</span><span class="sxs-lookup"><span data-stu-id="f6292-168">For more information about the data in each object, see the [Insight values](#insight-values) section below.</span></span>                                                                                                                      |
| <span data-ttu-id="f6292-169">TotalCount</span><span class="sxs-lookup"><span data-stu-id="f6292-169">TotalCount</span></span> | <span data-ttu-id="f6292-170">int</span><span class="sxs-lookup"><span data-stu-id="f6292-170">int</span></span>    | <span data-ttu-id="f6292-171">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="f6292-171">The total number of rows in the data result for the query.</span></span>                 |


### <a name="insight-values"></a><span data-ttu-id="f6292-172">Insight 値</span><span class="sxs-lookup"><span data-stu-id="f6292-172">Insight values</span></span>

<span data-ttu-id="f6292-173">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="f6292-173">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="f6292-174">Value</span><span class="sxs-lookup"><span data-stu-id="f6292-174">Value</span></span>               | <span data-ttu-id="f6292-175">種類</span><span class="sxs-lookup"><span data-stu-id="f6292-175">Type</span></span>   | <span data-ttu-id="f6292-176">説明</span><span class="sxs-lookup"><span data-stu-id="f6292-176">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="f6292-177">applicationId</span><span class="sxs-lookup"><span data-stu-id="f6292-177">applicationId</span></span>       | <span data-ttu-id="f6292-178">string</span><span class="sxs-lookup"><span data-stu-id="f6292-178">string</span></span> | <span data-ttu-id="f6292-179">Insights のデータを取得するアプリの Store ID。</span><span class="sxs-lookup"><span data-stu-id="f6292-179">The Store ID of the app for which you are retrieving insights data.</span></span>     |
| <span data-ttu-id="f6292-180">insightDate</span><span class="sxs-lookup"><span data-stu-id="f6292-180">insightDate</span></span>                | <span data-ttu-id="f6292-181">string</span><span class="sxs-lookup"><span data-stu-id="f6292-181">string</span></span> | <span data-ttu-id="f6292-182">日付が特定のメトリックの変化を特定しました。</span><span class="sxs-lookup"><span data-stu-id="f6292-182">The date on which we identified the change in a specific metric.</span></span> <span data-ttu-id="f6292-183">この日付は、大幅な増加を検出しました週の終わりを表すと比較する前に、その週とメトリックに増減します。</span><span class="sxs-lookup"><span data-stu-id="f6292-183">This date represents the end of the week in which we detected a significant increase or decrease in a metric compared to the week before that.</span></span> |
| <span data-ttu-id="f6292-184">データ型</span><span class="sxs-lookup"><span data-stu-id="f6292-184">dataType</span></span>     | <span data-ttu-id="f6292-185">string</span><span class="sxs-lookup"><span data-stu-id="f6292-185">string</span></span> | <span data-ttu-id="f6292-186">この情報を表す一般的な分析の領域を指定する次の文字列のいずれか:</span><span class="sxs-lookup"><span data-stu-id="f6292-186">One of the following strings that specifies the general analytics area that this insight describes:</span></span><p/><ul><li><span data-ttu-id="f6292-187"><strong>取得</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-187"><strong>acquisition</strong></span></span></li><li><span data-ttu-id="f6292-188"><strong>正常性</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-188"><strong>health</strong></span></span></li><li><span data-ttu-id="f6292-189"><strong>使用状況</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-189"><strong>usage</strong></span></span></li></ul>   |
| <span data-ttu-id="f6292-190">insightDetail</span><span class="sxs-lookup"><span data-stu-id="f6292-190">insightDetail</span></span>          | <span data-ttu-id="f6292-191">array</span><span class="sxs-lookup"><span data-stu-id="f6292-191">array</span></span> | <span data-ttu-id="f6292-192">1 つまたは複数[InsightDetail 値](#insightdetail-values)現在インサイトの詳細を表します。</span><span class="sxs-lookup"><span data-stu-id="f6292-192">One or more [InsightDetail values](#insightdetail-values) that represent the details for current insight.</span></span>    |


### <a name="insightdetail-values"></a><span data-ttu-id="f6292-193">InsightDetail 値</span><span class="sxs-lookup"><span data-stu-id="f6292-193">InsightDetail values</span></span>

| <span data-ttu-id="f6292-194">値</span><span class="sxs-lookup"><span data-stu-id="f6292-194">Value</span></span>               | <span data-ttu-id="f6292-195">種類</span><span class="sxs-lookup"><span data-stu-id="f6292-195">Type</span></span>   | <span data-ttu-id="f6292-196">説明</span><span class="sxs-lookup"><span data-stu-id="f6292-196">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="f6292-197">FactName</span><span class="sxs-lookup"><span data-stu-id="f6292-197">FactName</span></span>           | <span data-ttu-id="f6292-198">string</span><span class="sxs-lookup"><span data-stu-id="f6292-198">string</span></span> | <span data-ttu-id="f6292-199">現在 insight または現在のディメンションについて説明します、メトリックを示す値は次のいずれかに基づいて、 **dataType**値。</span><span class="sxs-lookup"><span data-stu-id="f6292-199">One of the following values that indicates the metric that the current insight or current dimension describes, based on the **dataType** value.</span></span><ul><li><span data-ttu-id="f6292-200">**ヘルス**、この値は常に**ヒット カウント**します。</span><span class="sxs-lookup"><span data-stu-id="f6292-200">For **health**, this value is always **HitCount**.</span></span></li><li><span data-ttu-id="f6292-201">**買収**、この値は常に**取得数**します。</span><span class="sxs-lookup"><span data-stu-id="f6292-201">For **acquisition**, this value is always **AcquisitionQuantity**.</span></span></li><li><span data-ttu-id="f6292-202">**使用状況**、この値は、次の文字列のいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="f6292-202">For **usage**, this value can be one of the following strings:</span></span><ul><li><span data-ttu-id="f6292-203"><strong>DailyActiveUsers</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-203"><strong>DailyActiveUsers</strong></span></span></li><li><span data-ttu-id="f6292-204"><strong>EngagementDurationMinutes</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-204"><strong>EngagementDurationMinutes</strong></span></span></li><li><span data-ttu-id="f6292-205"><strong>DailyActiveDevices</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-205"><strong>DailyActiveDevices</strong></span></span></li><li><span data-ttu-id="f6292-206"><strong>DailyNewUsers</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-206"><strong>DailyNewUsers</strong></span></span></li><li><span data-ttu-id="f6292-207"><strong>DailySessionCount</strong></span><span class="sxs-lookup"><span data-stu-id="f6292-207"><strong>DailySessionCount</strong></span></span></li></ul></ul>  |
| <span data-ttu-id="f6292-208">SubDimensions</span><span class="sxs-lookup"><span data-stu-id="f6292-208">SubDimensions</span></span>         | <span data-ttu-id="f6292-209">array</span><span class="sxs-lookup"><span data-stu-id="f6292-209">array</span></span> |  <span data-ttu-id="f6292-210">情報を得ることの 1 つのメトリックを記述する 1 つまたは複数のオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f6292-210">One or more objects that describe a single metric for the insight.</span></span>   |
| <span data-ttu-id="f6292-211">PercentChange</span><span class="sxs-lookup"><span data-stu-id="f6292-211">PercentChange</span></span>            | <span data-ttu-id="f6292-212">string</span><span class="sxs-lookup"><span data-stu-id="f6292-212">string</span></span> |  <span data-ttu-id="f6292-213">この割合は、全体の顧客ベースでメトリックを変更しました。</span><span class="sxs-lookup"><span data-stu-id="f6292-213">The percentage that the metric changed across your entire customer base.</span></span>  |
| <span data-ttu-id="f6292-214">DimensionName</span><span class="sxs-lookup"><span data-stu-id="f6292-214">DimensionName</span></span>           | <span data-ttu-id="f6292-215">string</span><span class="sxs-lookup"><span data-stu-id="f6292-215">string</span></span> |  <span data-ttu-id="f6292-216">現在のディメンションで説明されているメトリックの名前。</span><span class="sxs-lookup"><span data-stu-id="f6292-216">The name of the metric described in the current dimension.</span></span> <span data-ttu-id="f6292-217">例としては、 **EventType**、**市場**、 **DeviceType**、 **PackageVersion**、 **AcquisitionType**、 **AgeGroup**と**性別**します。</span><span class="sxs-lookup"><span data-stu-id="f6292-217">Examples include **EventType**, **Market**, **DeviceType**, **PackageVersion**, **AcquisitionType**, **AgeGroup** and **Gender**.</span></span>   |
| <span data-ttu-id="f6292-218">DimensionValue</span><span class="sxs-lookup"><span data-stu-id="f6292-218">DimensionValue</span></span>              | <span data-ttu-id="f6292-219">string</span><span class="sxs-lookup"><span data-stu-id="f6292-219">string</span></span> | <span data-ttu-id="f6292-220">現在のディメンションで説明されているメトリックの値。</span><span class="sxs-lookup"><span data-stu-id="f6292-220">The value of the metric that is described in the current dimension.</span></span> <span data-ttu-id="f6292-221">たとえば場合、 **DimensionName**は**EventType**、 **DimensionValue**可能性があります**クラッシュ**または**ハング**.</span><span class="sxs-lookup"><span data-stu-id="f6292-221">For example, if **DimensionName** is **EventType**, **DimensionValue** might be **crash** or **hang**.</span></span>   |
| <span data-ttu-id="f6292-222">FactValue</span><span class="sxs-lookup"><span data-stu-id="f6292-222">FactValue</span></span>     | <span data-ttu-id="f6292-223">string</span><span class="sxs-lookup"><span data-stu-id="f6292-223">string</span></span> | <span data-ttu-id="f6292-224">情報を得ることが検出された日付のメトリックの絶対値。</span><span class="sxs-lookup"><span data-stu-id="f6292-224">The absolute value of the metric on the date the insight was detected.</span></span>  |
| <span data-ttu-id="f6292-225">Direction</span><span class="sxs-lookup"><span data-stu-id="f6292-225">Direction</span></span> | <span data-ttu-id="f6292-226">string</span><span class="sxs-lookup"><span data-stu-id="f6292-226">string</span></span> |  <span data-ttu-id="f6292-227">変更の方向 (**正**または**負**)。</span><span class="sxs-lookup"><span data-stu-id="f6292-227">The direction of the change (**Positive** or **Negative**).</span></span>   |
| <span data-ttu-id="f6292-228">日付</span><span class="sxs-lookup"><span data-stu-id="f6292-228">Date</span></span>              | <span data-ttu-id="f6292-229">string</span><span class="sxs-lookup"><span data-stu-id="f6292-229">string</span></span> |  <span data-ttu-id="f6292-230">日付、現在の情報または現在のディメンションに関連する変更を特定しました。</span><span class="sxs-lookup"><span data-stu-id="f6292-230">The date on which we identified the change related to the current insight or the current dimension.</span></span>   |

### <a name="response-example"></a><span data-ttu-id="f6292-231">応答の例</span><span class="sxs-lookup"><span data-stu-id="f6292-231">Response example</span></span>

<span data-ttu-id="f6292-232">この要求の JSON 返信の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f6292-232">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="f6292-233">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f6292-233">Related topics</span></span>

* [<span data-ttu-id="f6292-234">Insights のレポート</span><span class="sxs-lookup"><span data-stu-id="f6292-234">Insights report</span></span>](../publish/insights-report.md)
* [<span data-ttu-id="f6292-235">Microsoft Store サービスを使用して分析データにアクセス</span><span class="sxs-lookup"><span data-stu-id="f6292-235">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
