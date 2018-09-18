---
author: mcleanbyron
description: デスクトップ アプリケーションのインサイト データを取得するのに Microsoft Store 分析 API の以下のメソッドを使用します。
title: デスクトップ アプリケーションのインサイト データの取得
ms.author: mcleans
ms.date: 07/31/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, Store サービス, Microsoft Store 分析 API, インサイト
ms.localizationpriority: medium
ms.openlocfilehash: e7ca6eed40af37276b5b4c98ec7b1b709bdadfb9
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4015267"
---
# <a name="get-insights-data-for-your-desktop-application"></a><span data-ttu-id="418fb-104">デスクトップ アプリケーションのインサイト データの取得</span><span class="sxs-lookup"><span data-stu-id="418fb-104">Get insights data for your desktop application</span></span>

<span data-ttu-id="418fb-105">[Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)に追加したデスクトップ アプリケーションの正常性のメトリックに関連するデータについての洞察を Microsoft Store 分析 API でこのメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="418fb-105">Use this method in the Microsoft Store analytics API to get insights data related to health metrics for a desktop application that you have added to the [Windows Desktop Application program](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program).</span></span> <span data-ttu-id="418fb-106">このデータも Windows デベロッパー センター ダッシュ ボードでのデスクトップ アプリケーションの[正常性レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)で使用できます。</span><span class="sxs-lookup"><span data-stu-id="418fb-106">This data is also available in the [Health report](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report) for desktop applications in the Windows Dev Center dashboard.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="418fb-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="418fb-107">Prerequisites</span></span>

<span data-ttu-id="418fb-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="418fb-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="418fb-109">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="418fb-109">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="418fb-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="418fb-110">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="418fb-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="418fb-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="418fb-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="418fb-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="418fb-113">要求</span><span class="sxs-lookup"><span data-stu-id="418fb-113">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="418fb-114">要求の構文</span><span class="sxs-lookup"><span data-stu-id="418fb-114">Request syntax</span></span>

| <span data-ttu-id="418fb-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="418fb-115">Method</span></span> | <span data-ttu-id="418fb-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="418fb-116">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="418fb-117">GET</span><span class="sxs-lookup"><span data-stu-id="418fb-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/insights``` |


### <a name="request-header"></a><span data-ttu-id="418fb-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="418fb-118">Request header</span></span>

| <span data-ttu-id="418fb-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="418fb-119">Header</span></span>        | <span data-ttu-id="418fb-120">型</span><span class="sxs-lookup"><span data-stu-id="418fb-120">Type</span></span>   | <span data-ttu-id="418fb-121">説明</span><span class="sxs-lookup"><span data-stu-id="418fb-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="418fb-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="418fb-122">Authorization</span></span> | <span data-ttu-id="418fb-123">string</span><span class="sxs-lookup"><span data-stu-id="418fb-123">string</span></span> | <span data-ttu-id="418fb-124">必須。</span><span class="sxs-lookup"><span data-stu-id="418fb-124">Required.</span></span> <span data-ttu-id="418fb-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="418fb-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="418fb-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="418fb-126">Request parameters</span></span>

| <span data-ttu-id="418fb-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="418fb-127">Parameter</span></span>        | <span data-ttu-id="418fb-128">型</span><span class="sxs-lookup"><span data-stu-id="418fb-128">Type</span></span>   |  <span data-ttu-id="418fb-129">説明</span><span class="sxs-lookup"><span data-stu-id="418fb-129">Description</span></span>      |  <span data-ttu-id="418fb-130">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="418fb-130">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="418fb-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="418fb-131">applicationId</span></span> | <span data-ttu-id="418fb-132">string</span><span class="sxs-lookup"><span data-stu-id="418fb-132">string</span></span> | <span data-ttu-id="418fb-133">インサイト データを取得するデスクトップ アプリケーションの製品 ID です。</span><span class="sxs-lookup"><span data-stu-id="418fb-133">The product ID of the desktop application for which you want to get insights data.</span></span> <span data-ttu-id="418fb-134">デスクトップ アプリケーションの製品 ID を取得するには、[デベロッパー センターでデスクトップ アプリケーションの分析レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)のいずれか (**正常性レポート**など) を開き、URL から製品 ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="418fb-134">To get the product ID of a desktop application, open any [Dev Center analytics report for your desktop application](https://msdn.microsoft.com/library/windows/desktop/mt826504) (such as the **Health report**) and retrieve the product ID from the URL.</span></span> <span data-ttu-id="418fb-135">このパラメーターを指定しない場合、応答本文にはアカウントに登録されているすべてのアプリのインサイト データが含まれます。</span><span class="sxs-lookup"><span data-stu-id="418fb-135">If you do not specify this parameter, the response body will contain insights data for all apps registered to your account.</span></span>  |  <span data-ttu-id="418fb-136">必須ではない</span><span class="sxs-lookup"><span data-stu-id="418fb-136">No</span></span>  |
| <span data-ttu-id="418fb-137">startDate</span><span class="sxs-lookup"><span data-stu-id="418fb-137">startDate</span></span> | <span data-ttu-id="418fb-138">date</span><span class="sxs-lookup"><span data-stu-id="418fb-138">date</span></span> | <span data-ttu-id="418fb-139">取得するインサイト データの日付範囲の開始日です。</span><span class="sxs-lookup"><span data-stu-id="418fb-139">The start date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="418fb-140">既定値は、現在の日付の 30 日前です。</span><span class="sxs-lookup"><span data-stu-id="418fb-140">The default is 30 days before the current date.</span></span> |  <span data-ttu-id="418fb-141">必須ではない</span><span class="sxs-lookup"><span data-stu-id="418fb-141">No</span></span>  |
| <span data-ttu-id="418fb-142">endDate</span><span class="sxs-lookup"><span data-stu-id="418fb-142">endDate</span></span> | <span data-ttu-id="418fb-143">date</span><span class="sxs-lookup"><span data-stu-id="418fb-143">date</span></span> | <span data-ttu-id="418fb-144">取得するインサイト データの日付範囲の終了日です。</span><span class="sxs-lookup"><span data-stu-id="418fb-144">The end date in the date range of insights data to retrieve.</span></span> <span data-ttu-id="418fb-145">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="418fb-145">The default is the current date.</span></span> |  <span data-ttu-id="418fb-146">必須ではない</span><span class="sxs-lookup"><span data-stu-id="418fb-146">No</span></span>  |
| <span data-ttu-id="418fb-147">filter</span><span class="sxs-lookup"><span data-stu-id="418fb-147">filter</span></span> | <span data-ttu-id="418fb-148">string</span><span class="sxs-lookup"><span data-stu-id="418fb-148">string</span></span>  | <span data-ttu-id="418fb-149">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。</span><span class="sxs-lookup"><span data-stu-id="418fb-149">One or more statements that filter the rows in the response.</span></span> <span data-ttu-id="418fb-150">各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="418fb-150">Each statement contains a field name from the response body and value that are associated with the **eq** or **ne** operators, and statements can be combined using **and** or **or**.</span></span> <span data-ttu-id="418fb-151">*filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。</span><span class="sxs-lookup"><span data-stu-id="418fb-151">String values must be surrounded by single quotes in the *filter* parameter.</span></span> <span data-ttu-id="418fb-152">たとえば、 *filter = dataType eq '入手'* します。</span><span class="sxs-lookup"><span data-stu-id="418fb-152">For example, *filter=dataType eq 'acquisition'*.</span></span> <p/><p/><span data-ttu-id="418fb-153">現在このメソッドでは、フィルター**の正常性**のみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="418fb-153">Currently this method only supports the filter **health**.</span></span>  | <span data-ttu-id="418fb-154">いいえ</span><span class="sxs-lookup"><span data-stu-id="418fb-154">No</span></span>   |

### <a name="request-example"></a><span data-ttu-id="418fb-155">要求の例</span><span class="sxs-lookup"><span data-stu-id="418fb-155">Request example</span></span>

<span data-ttu-id="418fb-156">次の例では、インサイト データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="418fb-156">The following example demonstrates a request for getting insights data.</span></span> <span data-ttu-id="418fb-157">*ApplicationId*値をデスクトップ アプリケーションの適切な値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="418fb-157">Replace the *applicationId* value with the appropriate value for your desktop application.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/insights?applicationId=10238467886765136388&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'health' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="418fb-158">応答</span><span class="sxs-lookup"><span data-stu-id="418fb-158">Response</span></span>

### <a name="response-body"></a><span data-ttu-id="418fb-159">応答本文</span><span class="sxs-lookup"><span data-stu-id="418fb-159">Response body</span></span>

| <span data-ttu-id="418fb-160">値</span><span class="sxs-lookup"><span data-stu-id="418fb-160">Value</span></span>      | <span data-ttu-id="418fb-161">型</span><span class="sxs-lookup"><span data-stu-id="418fb-161">Type</span></span>   | <span data-ttu-id="418fb-162">説明</span><span class="sxs-lookup"><span data-stu-id="418fb-162">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="418fb-163">Value</span><span class="sxs-lookup"><span data-stu-id="418fb-163">Value</span></span>      | <span data-ttu-id="418fb-164">array</span><span class="sxs-lookup"><span data-stu-id="418fb-164">array</span></span>  | <span data-ttu-id="418fb-165">アプリのインサイト データが含まれるオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="418fb-165">An array of objects that contain insights data for the app.</span></span> <span data-ttu-id="418fb-166">各オブジェクトのデータについて詳しくは、後述の「[インサイトの値](#insight-values)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="418fb-166">For more information about the data in each object, see the [Insight values](#insight-values) section below.</span></span>                                                                                                                      |
| <span data-ttu-id="418fb-167">TotalCount</span><span class="sxs-lookup"><span data-stu-id="418fb-167">TotalCount</span></span> | <span data-ttu-id="418fb-168">int</span><span class="sxs-lookup"><span data-stu-id="418fb-168">int</span></span>    | <span data-ttu-id="418fb-169">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="418fb-169">The total number of rows in the data result for the query.</span></span>                 |


### <a name="insight-values"></a><span data-ttu-id="418fb-170">Insight 値</span><span class="sxs-lookup"><span data-stu-id="418fb-170">Insight values</span></span>

<span data-ttu-id="418fb-171">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="418fb-171">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="418fb-172">値</span><span class="sxs-lookup"><span data-stu-id="418fb-172">Value</span></span>               | <span data-ttu-id="418fb-173">型</span><span class="sxs-lookup"><span data-stu-id="418fb-173">Type</span></span>   | <span data-ttu-id="418fb-174">説明</span><span class="sxs-lookup"><span data-stu-id="418fb-174">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="418fb-175">applicationId</span><span class="sxs-lookup"><span data-stu-id="418fb-175">applicationId</span></span>       | <span data-ttu-id="418fb-176">string</span><span class="sxs-lookup"><span data-stu-id="418fb-176">string</span></span> | <span data-ttu-id="418fb-177">インサイト データを取得するデスクトップ アプリケーションの製品 ID です。</span><span class="sxs-lookup"><span data-stu-id="418fb-177">The product ID of the desktop application for which you retrieved insights data.</span></span>     |
| <span data-ttu-id="418fb-178">insightDate</span><span class="sxs-lookup"><span data-stu-id="418fb-178">insightDate</span></span>                | <span data-ttu-id="418fb-179">string</span><span class="sxs-lookup"><span data-stu-id="418fb-179">string</span></span> | <span data-ttu-id="418fb-180">特定のメトリックの変更を特定しました日です。</span><span class="sxs-lookup"><span data-stu-id="418fb-180">The date on which we identified the change in a specific metric.</span></span> <span data-ttu-id="418fb-181">この日付またはそれより前に、の週との比較メトリックの短縮を大幅に増加を検出しました週の終わりを表します。</span><span class="sxs-lookup"><span data-stu-id="418fb-181">This date represents the end of the week in which we detected a significant increase or decrease in a metric compared to the week before that.</span></span> |
| <span data-ttu-id="418fb-182">データ型</span><span class="sxs-lookup"><span data-stu-id="418fb-182">dataType</span></span>     | <span data-ttu-id="418fb-183">string</span><span class="sxs-lookup"><span data-stu-id="418fb-183">string</span></span> | <span data-ttu-id="418fb-184">この情報に通知する一般的な分析領域を指定する文字列。</span><span class="sxs-lookup"><span data-stu-id="418fb-184">A string that specifies the general analytics area that this insight informs.</span></span> <span data-ttu-id="418fb-185">現時点では、このメソッドでは、**正常性**をのみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="418fb-185">Currently, this method only supports **health**.</span></span>    |
| <span data-ttu-id="418fb-186">insightDetail</span><span class="sxs-lookup"><span data-stu-id="418fb-186">insightDetail</span></span>          | <span data-ttu-id="418fb-187">array</span><span class="sxs-lookup"><span data-stu-id="418fb-187">array</span></span> | <span data-ttu-id="418fb-188">1 つまたは複数[InsightDetail 値](#insightdetail-values)を表す現在インサイトの詳細です。</span><span class="sxs-lookup"><span data-stu-id="418fb-188">One or more [InsightDetail values](#insightdetail-values) that represent the details for current insight.</span></span>    |


### <a name="insightdetail-values"></a><span data-ttu-id="418fb-189">InsightDetail 値</span><span class="sxs-lookup"><span data-stu-id="418fb-189">InsightDetail values</span></span>

| <span data-ttu-id="418fb-190">値</span><span class="sxs-lookup"><span data-stu-id="418fb-190">Value</span></span>               | <span data-ttu-id="418fb-191">型</span><span class="sxs-lookup"><span data-stu-id="418fb-191">Type</span></span>   | <span data-ttu-id="418fb-192">説明</span><span class="sxs-lookup"><span data-stu-id="418fb-192">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="418fb-193">FactName</span><span class="sxs-lookup"><span data-stu-id="418fb-193">FactName</span></span>           | <span data-ttu-id="418fb-194">string</span><span class="sxs-lookup"><span data-stu-id="418fb-194">string</span></span> | <span data-ttu-id="418fb-195">現在の洞察または現在のディメンションを説明するメトリックを示す文字列です。</span><span class="sxs-lookup"><span data-stu-id="418fb-195">A string that indicates the metric that the current insight or current dimension describes.</span></span> <span data-ttu-id="418fb-196">現時点では、このメソッドでは、**ヒット数**の値のみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="418fb-196">Currently, this method only supports the value **HitCount**.</span></span>  |
| <span data-ttu-id="418fb-197">SubDimensions</span><span class="sxs-lookup"><span data-stu-id="418fb-197">SubDimensions</span></span>         | <span data-ttu-id="418fb-198">array</span><span class="sxs-lookup"><span data-stu-id="418fb-198">array</span></span> |  <span data-ttu-id="418fb-199">情報を得ることの 1 つのメトリックを記述する 1 つまたは複数のオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="418fb-199">One or more objects that describe a single metric for the insight.</span></span>   |
| <span data-ttu-id="418fb-200">PercentChange</span><span class="sxs-lookup"><span data-stu-id="418fb-200">PercentChange</span></span>            | <span data-ttu-id="418fb-201">string</span><span class="sxs-lookup"><span data-stu-id="418fb-201">string</span></span> |  <span data-ttu-id="418fb-202">メトリックは、全体の顧客ベースの間で変更された割合。</span><span class="sxs-lookup"><span data-stu-id="418fb-202">The percentage that the metric changed across your entire customer base.</span></span>  |
| <span data-ttu-id="418fb-203">DimensionName</span><span class="sxs-lookup"><span data-stu-id="418fb-203">DimensionName</span></span>           | <span data-ttu-id="418fb-204">string</span><span class="sxs-lookup"><span data-stu-id="418fb-204">string</span></span> |  <span data-ttu-id="418fb-205">現在の次元で説明されているメトリックの名前です。</span><span class="sxs-lookup"><span data-stu-id="418fb-205">The name of the metric described in the current dimension.</span></span> <span data-ttu-id="418fb-206">例についてには、**イベントの種類**、**市場**、 **DeviceType**、および**PackageVersion**が含まれます。</span><span class="sxs-lookup"><span data-stu-id="418fb-206">Examples include **EventType**, **Market**, **DeviceType**, and **PackageVersion**.</span></span>   |
| <span data-ttu-id="418fb-207">DimensionValue</span><span class="sxs-lookup"><span data-stu-id="418fb-207">DimensionValue</span></span>              | <span data-ttu-id="418fb-208">string</span><span class="sxs-lookup"><span data-stu-id="418fb-208">string</span></span> | <span data-ttu-id="418fb-209">現在のディメンションに記載されているメトリックの値。</span><span class="sxs-lookup"><span data-stu-id="418fb-209">The value of the metric that is described in the current dimension.</span></span> <span data-ttu-id="418fb-210">たとえば、 **DimensionName**が**イベントの種類**である場合は、**クラッシュ**や**ハング**が**DimensionValue**することがあります。</span><span class="sxs-lookup"><span data-stu-id="418fb-210">For example, if **DimensionName** is **EventType**, **DimensionValue** might be **crash** or **hang**.</span></span>   |
| <span data-ttu-id="418fb-211">FactValue</span><span class="sxs-lookup"><span data-stu-id="418fb-211">FactValue</span></span>     | <span data-ttu-id="418fb-212">string</span><span class="sxs-lookup"><span data-stu-id="418fb-212">string</span></span> | <span data-ttu-id="418fb-213">情報を得ることが検出された日付のメトリックの絶対値。</span><span class="sxs-lookup"><span data-stu-id="418fb-213">The absolute value of the metric on the date the insight was detected.</span></span>  |
| <span data-ttu-id="418fb-214">Direction</span><span class="sxs-lookup"><span data-stu-id="418fb-214">Direction</span></span> | <span data-ttu-id="418fb-215">string</span><span class="sxs-lookup"><span data-stu-id="418fb-215">string</span></span> |  <span data-ttu-id="418fb-216">(**正**または**負**) の変更の方向です。</span><span class="sxs-lookup"><span data-stu-id="418fb-216">The direction of the change (**Positive** or **Negative**).</span></span>   |
| <span data-ttu-id="418fb-217">Date</span><span class="sxs-lookup"><span data-stu-id="418fb-217">Date</span></span>              | <span data-ttu-id="418fb-218">string</span><span class="sxs-lookup"><span data-stu-id="418fb-218">string</span></span> |  <span data-ttu-id="418fb-219">現在の洞察または現在のディメンションに関連する変更を特定しました日です。</span><span class="sxs-lookup"><span data-stu-id="418fb-219">The date on which we identified the change related to the current insight or the current dimension.</span></span>   |

### <a name="response-example"></a><span data-ttu-id="418fb-220">応答の例</span><span class="sxs-lookup"><span data-stu-id="418fb-220">Response example</span></span>

<span data-ttu-id="418fb-221">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="418fb-221">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="418fb-222">関連トピック</span><span class="sxs-lookup"><span data-stu-id="418fb-222">Related topics</span></span>

* [<span data-ttu-id="418fb-223">Windows デスクトップ アプリケーション プログラム</span><span class="sxs-lookup"><span data-stu-id="418fb-223">Windows Desktop Application program</span></span>](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)
* [<span data-ttu-id="418fb-224">状態レポート</span><span class="sxs-lookup"><span data-stu-id="418fb-224">Health report</span></span>](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)
* [<span data-ttu-id="418fb-225">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="418fb-225">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
