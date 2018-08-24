---
author: mcleanbyron
description: Microsoft ストア分析 API でこのメソッドを使用すると、デスクトップ アプリケーションのデータの分析結果を取得します。
title: デスクトップ アプリケーションのデータの分析結果を取得します。
ms.author: mcleans
ms.date: 07/31/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、ストア サービス、Microsoft ストア分析 API、分析結果
ms.localizationpriority: medium
ms.openlocfilehash: e7ca6eed40af37276b5b4c98ec7b1b709bdadfb9
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2837942"
---
# <a name="get-insights-data-for-your-desktop-application"></a><span data-ttu-id="51460-104">デスクトップ アプリケーションのデータの分析結果を取得します。</span><span class="sxs-lookup"><span data-stu-id="51460-104">Get insights data for your desktop application</span></span>

<span data-ttu-id="51460-105">[Windows デスクトップ アプリケーション](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)に追加したデスクトップ アプリケーションの正常性指標に関連するデータの分析結果を取得するには、Microsoft ストア分析 API このメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="51460-105">Use this method in the Microsoft Store analytics API to get insights data related to health metrics for a desktop application that you have added to the [Windows Desktop Application program](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program).</span></span> <span data-ttu-id="51460-106">このデータも Windows デベロッパー センターのダッシュ ボードでのデスクトップ アプリケーションの[正常性レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)で使用できます。</span><span class="sxs-lookup"><span data-stu-id="51460-106">This data is also available in the [Health report](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report) for desktop applications in the Windows Dev Center dashboard.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="51460-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="51460-107">Prerequisites</span></span>

<span data-ttu-id="51460-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="51460-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="51460-109">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="51460-109">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="51460-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="51460-110">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="51460-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="51460-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="51460-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="51460-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="51460-113">要求</span><span class="sxs-lookup"><span data-stu-id="51460-113">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="51460-114">要求の構文</span><span class="sxs-lookup"><span data-stu-id="51460-114">Request syntax</span></span>

| <span data-ttu-id="51460-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="51460-115">Method</span></span> | <span data-ttu-id="51460-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="51460-116">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="51460-117">GET</span><span class="sxs-lookup"><span data-stu-id="51460-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/insights``` |


### <a name="request-header"></a><span data-ttu-id="51460-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="51460-118">Request header</span></span>

| <span data-ttu-id="51460-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="51460-119">Header</span></span>        | <span data-ttu-id="51460-120">型</span><span class="sxs-lookup"><span data-stu-id="51460-120">Type</span></span>   | <span data-ttu-id="51460-121">説明</span><span class="sxs-lookup"><span data-stu-id="51460-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="51460-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="51460-122">Authorization</span></span> | <span data-ttu-id="51460-123">string</span><span class="sxs-lookup"><span data-stu-id="51460-123">string</span></span> | <span data-ttu-id="51460-124">必須。</span><span class="sxs-lookup"><span data-stu-id="51460-124">Required.</span></span> <span data-ttu-id="51460-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="51460-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="51460-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="51460-126">Request parameters</span></span>

| <span data-ttu-id="51460-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="51460-127">Parameter</span></span>        | <span data-ttu-id="51460-128">型</span><span class="sxs-lookup"><span data-stu-id="51460-128">Type</span></span>   |  <span data-ttu-id="51460-129">説明</span><span class="sxs-lookup"><span data-stu-id="51460-129">Description</span></span>      |  <span data-ttu-id="51460-130">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="51460-130">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="51460-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="51460-131">applicationId</span></span> | <span data-ttu-id="51460-132">string</span><span class="sxs-lookup"><span data-stu-id="51460-132">string</span></span> | <span data-ttu-id="51460-133">データの分析結果を取得するデスクトップ アプリケーションのプロダクト ID。</span><span class="sxs-lookup"><span data-stu-id="51460-133">The product ID of the desktop application for which you want to get insights data.</span></span> <span data-ttu-id="51460-134">デスクトップ アプリケーションの製品 ID を取得するには、[デベロッパー センターでデスクトップ アプリケーションの分析レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)のいずれか (**正常性レポート**など) を開き、URL から製品 ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="51460-134">To get the product ID of a desktop application, open any [Dev Center analytics report for your desktop application](https://msdn.microsoft.com/library/windows/desktop/mt826504) (such as the **Health report**) and retrieve the product ID from the URL.</span></span> <span data-ttu-id="51460-135">このパラメーターを指定しないと、応答本文が自分のアカウントに登録されているすべてのアプリのデータ分析にはが含まれます。</span><span class="sxs-lookup"><span data-stu-id="51460-135">If you do not specify this parameter, the response body will contain insights data for all apps registered to your account.</span></span>  |  <span data-ttu-id="51460-136">必須ではない</span><span class="sxs-lookup"><span data-stu-id="51460-136">No</span></span>  |
| <span data-ttu-id="51460-137">startDate</span><span class="sxs-lookup"><span data-stu-id="51460-137">startDate</span></span> | <span data-ttu-id="51460-138">date</span><span class="sxs-lookup"><span data-stu-id="51460-138">date</span></span> | <span data-ttu-id="51460-139">日付範囲内のデータの分析結果を取得する開始日です。</span><span class="sxs-lookup"><span data-stu-id="51460-139">The start date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="51460-140">既定値は、現在の日付の 30 日前です。</span><span class="sxs-lookup"><span data-stu-id="51460-140">The default is 30 days before the current date.</span></span> |  <span data-ttu-id="51460-141">必須ではない</span><span class="sxs-lookup"><span data-stu-id="51460-141">No</span></span>  |
| <span data-ttu-id="51460-142">endDate</span><span class="sxs-lookup"><span data-stu-id="51460-142">endDate</span></span> | <span data-ttu-id="51460-143">date</span><span class="sxs-lookup"><span data-stu-id="51460-143">date</span></span> | <span data-ttu-id="51460-144">日付範囲内のデータの分析結果を取得する終了日です。</span><span class="sxs-lookup"><span data-stu-id="51460-144">The end date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="51460-145">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="51460-145">The default is the current date.</span></span> |  <span data-ttu-id="51460-146">必須ではない</span><span class="sxs-lookup"><span data-stu-id="51460-146">No</span></span>  |
| <span data-ttu-id="51460-147">filter</span><span class="sxs-lookup"><span data-stu-id="51460-147">filter</span></span> | <span data-ttu-id="51460-148">string</span><span class="sxs-lookup"><span data-stu-id="51460-148">string</span></span>  | <span data-ttu-id="51460-149">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。</span><span class="sxs-lookup"><span data-stu-id="51460-149">One or more statements that filter the rows in the response.</span></span> <span data-ttu-id="51460-150">各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="51460-150">Each statement contains a field name from the response body and value that are associated with the **eq** or **ne** operators, and statements can be combined using **and** or **or**.</span></span> <span data-ttu-id="51460-151">*filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。</span><span class="sxs-lookup"><span data-stu-id="51460-151">String values must be surrounded by single quotes in the *filter* parameter.</span></span> <span data-ttu-id="51460-152">たとえば、*フィルター = データ型 eq '取得'* します。</span><span class="sxs-lookup"><span data-stu-id="51460-152">For example, *filter=dataType eq 'acquisition'*.</span></span> <p/><p/><span data-ttu-id="51460-153">現在この方法は、フィルター処理**の正常性**のみをサポートします。</span><span class="sxs-lookup"><span data-stu-id="51460-153">Currently this method only supports the filter **health**.</span></span>  | <span data-ttu-id="51460-154">いいえ</span><span class="sxs-lookup"><span data-stu-id="51460-154">No</span></span>   |

### <a name="request-example"></a><span data-ttu-id="51460-155">要求の例</span><span class="sxs-lookup"><span data-stu-id="51460-155">Request example</span></span>

<span data-ttu-id="51460-156">次の例では、データの分析結果を取得するための出席依頼を示します。</span><span class="sxs-lookup"><span data-stu-id="51460-156">The following example demonstrates a request for getting insights data.</span></span> <span data-ttu-id="51460-157">デスクトップ アプリケーションの適切な値を持つ*付きアプリケーション Id*の値を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="51460-157">Replace the *applicationId* value with the appropriate value for your desktop application.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/insights?applicationId=10238467886765136388&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'health' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="51460-158">応答</span><span class="sxs-lookup"><span data-stu-id="51460-158">Response</span></span>

### <a name="response-body"></a><span data-ttu-id="51460-159">応答本文</span><span class="sxs-lookup"><span data-stu-id="51460-159">Response body</span></span>

| <span data-ttu-id="51460-160">値</span><span class="sxs-lookup"><span data-stu-id="51460-160">Value</span></span>      | <span data-ttu-id="51460-161">型</span><span class="sxs-lookup"><span data-stu-id="51460-161">Type</span></span>   | <span data-ttu-id="51460-162">説明</span><span class="sxs-lookup"><span data-stu-id="51460-162">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="51460-163">Value</span><span class="sxs-lookup"><span data-stu-id="51460-163">Value</span></span>      | <span data-ttu-id="51460-164">array</span><span class="sxs-lookup"><span data-stu-id="51460-164">array</span></span>  | <span data-ttu-id="51460-165">アプリのデータを分析結果を含むオブジェクトの配列します。</span><span class="sxs-lookup"><span data-stu-id="51460-165">An array of objects that contain insights data for the app.</span></span> <span data-ttu-id="51460-166">各オブジェクト内のデータの詳細については、次の[値を把握](#insight-values)セクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="51460-166">For more information about the data in each object, see the [Insight values](#insight-values) section below.</span></span>                                                                                                                      |
| <span data-ttu-id="51460-167">TotalCount</span><span class="sxs-lookup"><span data-stu-id="51460-167">TotalCount</span></span> | <span data-ttu-id="51460-168">int</span><span class="sxs-lookup"><span data-stu-id="51460-168">int</span></span>    | <span data-ttu-id="51460-169">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="51460-169">The total number of rows in the data result for the query.</span></span>                 |


### <a name="insight-values"></a><span data-ttu-id="51460-170">値の把握</span><span class="sxs-lookup"><span data-stu-id="51460-170">Insight values</span></span>

<span data-ttu-id="51460-171">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="51460-171">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="51460-172">値</span><span class="sxs-lookup"><span data-stu-id="51460-172">Value</span></span>               | <span data-ttu-id="51460-173">型</span><span class="sxs-lookup"><span data-stu-id="51460-173">Type</span></span>   | <span data-ttu-id="51460-174">説明</span><span class="sxs-lookup"><span data-stu-id="51460-174">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="51460-175">applicationId</span><span class="sxs-lookup"><span data-stu-id="51460-175">applicationId</span></span>       | <span data-ttu-id="51460-176">string</span><span class="sxs-lookup"><span data-stu-id="51460-176">string</span></span> | <span data-ttu-id="51460-177">データの分析結果を取得するデスクトップ アプリケーションのプロダクト ID。</span><span class="sxs-lookup"><span data-stu-id="51460-177">The product ID of the desktop application for which you retrieved insights data.</span></span>     |
| <span data-ttu-id="51460-178">insightDate</span><span class="sxs-lookup"><span data-stu-id="51460-178">insightDate</span></span>                | <span data-ttu-id="51460-179">string</span><span class="sxs-lookup"><span data-stu-id="51460-179">string</span></span> | <span data-ttu-id="51460-180">特定のメトリックの変更わかりました日。</span><span class="sxs-lookup"><span data-stu-id="51460-180">The date on which we identified the change in a specific metric.</span></span> <span data-ttu-id="51460-181">この日付は、大幅に増加が検出されたことを週の最後を表す前に、その曜日と比較してメトリックの増減します。</span><span class="sxs-lookup"><span data-stu-id="51460-181">This date represents the end of the week in which we detected a significant increase or decrease in a metric compared to the week before that.</span></span> |
| <span data-ttu-id="51460-182">データ型</span><span class="sxs-lookup"><span data-stu-id="51460-182">dataType</span></span>     | <span data-ttu-id="51460-183">string</span><span class="sxs-lookup"><span data-stu-id="51460-183">string</span></span> | <span data-ttu-id="51460-184">この情報を通知する一般的な分析領域を指定する文字列。</span><span class="sxs-lookup"><span data-stu-id="51460-184">A string that specifies the general analytics area that this insight informs.</span></span> <span data-ttu-id="51460-185">現在、この方法は、**正常性**をのみをサポートします。</span><span class="sxs-lookup"><span data-stu-id="51460-185">Currently, this method only supports **health**.</span></span>    |
| <span data-ttu-id="51460-186">insightDetail</span><span class="sxs-lookup"><span data-stu-id="51460-186">insightDetail</span></span>          | <span data-ttu-id="51460-187">array</span><span class="sxs-lookup"><span data-stu-id="51460-187">array</span></span> | <span data-ttu-id="51460-188">1 つまたは複数の[InsightDetail 値](#insightdetail-values)を現在の情報の詳細を表します。</span><span class="sxs-lookup"><span data-stu-id="51460-188">One or more [InsightDetail values](#insightdetail-values) that represent the details for current insight.</span></span>    |


### <a name="insightdetail-values"></a><span data-ttu-id="51460-189">InsightDetail 値</span><span class="sxs-lookup"><span data-stu-id="51460-189">InsightDetail values</span></span>

| <span data-ttu-id="51460-190">値</span><span class="sxs-lookup"><span data-stu-id="51460-190">Value</span></span>               | <span data-ttu-id="51460-191">型</span><span class="sxs-lookup"><span data-stu-id="51460-191">Type</span></span>   | <span data-ttu-id="51460-192">説明</span><span class="sxs-lookup"><span data-stu-id="51460-192">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="51460-193">FactName</span><span class="sxs-lookup"><span data-stu-id="51460-193">FactName</span></span>           | <span data-ttu-id="51460-194">string</span><span class="sxs-lookup"><span data-stu-id="51460-194">string</span></span> | <span data-ttu-id="51460-195">現在の理解または現在のディメンションについて説明するメトリックを示す文字列。</span><span class="sxs-lookup"><span data-stu-id="51460-195">A string that indicates the metric that the current insight or current dimension describes.</span></span> <span data-ttu-id="51460-196">現在、この方法は、**ヒット カウント**] の値のみをサポートします。</span><span class="sxs-lookup"><span data-stu-id="51460-196">Currently, this method only supports the value **HitCount**.</span></span>  |
| <span data-ttu-id="51460-197">SubDimensions</span><span class="sxs-lookup"><span data-stu-id="51460-197">SubDimensions</span></span>         | <span data-ttu-id="51460-198">array</span><span class="sxs-lookup"><span data-stu-id="51460-198">array</span></span> |  <span data-ttu-id="51460-199">情報を得ることの 1 つの指標を説明する 1 つまたは複数のオブジェクト</span><span class="sxs-lookup"><span data-stu-id="51460-199">One or more objects that describe a single metric for the insight.</span></span>   |
| <span data-ttu-id="51460-200">PercentChange</span><span class="sxs-lookup"><span data-stu-id="51460-200">PercentChange</span></span>            | <span data-ttu-id="51460-201">string</span><span class="sxs-lookup"><span data-stu-id="51460-201">string</span></span> |  <span data-ttu-id="51460-202">全体の顧客ベースにわたって、メートル法が変更された割合です。</span><span class="sxs-lookup"><span data-stu-id="51460-202">The percentage that the metric changed across your entire customer base.</span></span>  |
| <span data-ttu-id="51460-203">DimensionName</span><span class="sxs-lookup"><span data-stu-id="51460-203">DimensionName</span></span>           | <span data-ttu-id="51460-204">string</span><span class="sxs-lookup"><span data-stu-id="51460-204">string</span></span> |  <span data-ttu-id="51460-205">現在のディメンションで説明するメトリックの名前。</span><span class="sxs-lookup"><span data-stu-id="51460-205">The name of the metric described in the current dimension.</span></span> <span data-ttu-id="51460-206">**イベントの種類**、**市場**、 **DeviceType**、および**PackageVersion**例が含まれます。</span><span class="sxs-lookup"><span data-stu-id="51460-206">Examples include **EventType**, **Market**, **DeviceType**, and **PackageVersion**.</span></span>   |
| <span data-ttu-id="51460-207">DimensionValue</span><span class="sxs-lookup"><span data-stu-id="51460-207">DimensionValue</span></span>              | <span data-ttu-id="51460-208">string</span><span class="sxs-lookup"><span data-stu-id="51460-208">string</span></span> | <span data-ttu-id="51460-209">現在のディメンションに記載されているメトリックの値。</span><span class="sxs-lookup"><span data-stu-id="51460-209">The value of the metric that is described in the current dimension.</span></span> <span data-ttu-id="51460-210">たとえば、 **DimensionName**が**イベントの種類**である場合は、**クラッシュ**または**ハング**が**DimensionValue**することがあります。</span><span class="sxs-lookup"><span data-stu-id="51460-210">For example, if **DimensionName** is **EventType**, **DimensionValue** might be **crash** or **hang**.</span></span>   |
| <span data-ttu-id="51460-211">FactValue</span><span class="sxs-lookup"><span data-stu-id="51460-211">FactValue</span></span>     | <span data-ttu-id="51460-212">string</span><span class="sxs-lookup"><span data-stu-id="51460-212">string</span></span> | <span data-ttu-id="51460-213">情報を得ることが検出された日付のメトリックの絶対値します。</span><span class="sxs-lookup"><span data-stu-id="51460-213">The absolute value of the metric on the date the insight was detected.</span></span>  |
| <span data-ttu-id="51460-214">Direction</span><span class="sxs-lookup"><span data-stu-id="51460-214">Direction</span></span> | <span data-ttu-id="51460-215">string</span><span class="sxs-lookup"><span data-stu-id="51460-215">string</span></span> |  <span data-ttu-id="51460-216">方向変更 (**正**または**負の値**) です。</span><span class="sxs-lookup"><span data-stu-id="51460-216">The direction of the change (**Positive** or **Negative**).</span></span>   |
| <span data-ttu-id="51460-217">Date</span><span class="sxs-lookup"><span data-stu-id="51460-217">Date</span></span>              | <span data-ttu-id="51460-218">string</span><span class="sxs-lookup"><span data-stu-id="51460-218">string</span></span> |  <span data-ttu-id="51460-219">現在の理解または現在のディメンションに関連する変更わかりました日。</span><span class="sxs-lookup"><span data-stu-id="51460-219">The date on which we identified the change related to the current insight or the current dimension.</span></span>   |

### <a name="response-example"></a><span data-ttu-id="51460-220">応答の例</span><span class="sxs-lookup"><span data-stu-id="51460-220">Response example</span></span>

<span data-ttu-id="51460-221">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="51460-221">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="51460-222">関連トピック</span><span class="sxs-lookup"><span data-stu-id="51460-222">Related topics</span></span>

* [<span data-ttu-id="51460-223">Windows デスクトップ アプリケーション</span><span class="sxs-lookup"><span data-stu-id="51460-223">Windows Desktop Application program</span></span>](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)
* [<span data-ttu-id="51460-224">状態レポート</span><span class="sxs-lookup"><span data-stu-id="51460-224">Health report</span></span>](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)
* [<span data-ttu-id="51460-225">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="51460-225">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)