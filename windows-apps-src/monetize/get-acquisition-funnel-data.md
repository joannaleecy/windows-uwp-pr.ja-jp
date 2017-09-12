---
author: mcleanbyron
description: "特定の日付範囲などのオプション フィルターを使って、アプリの入手に関するファネル データを取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。"
title: "アプリの入手に関するファネル データの取得"
ms.author: mcleans
ms.date: 08/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス, Windows ストア分析 API, 入手, ファネル"
ms.openlocfilehash: 5e09504eb7ed787fcf330a5cf92027eed5f6bc59
ms.sourcegitcommit: 2b436dc5e5681b8884e0531ee303f851a3e3ccf2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/18/2017
---
# <a name="get-app-acquisition-funnel-data"></a><span data-ttu-id="123a7-104">アプリの入手に関するファネル データの取得</span><span class="sxs-lookup"><span data-stu-id="123a7-104">Get app acquisition funnel data</span></span>

<span data-ttu-id="123a7-105">特定の日付範囲などのオプション フィルターを使って、アプリの入手に関するファネル データを取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="123a7-105">Use this method in the Windows Store analytics API to get acquisition funnel data for an application during a given date range and other optional filters.</span></span> <span data-ttu-id="123a7-106">この情報は、Windows デベロッパー センター ダッシュボードの[取得レポート](../publish/acquisitions-report.md#acquisition-funnel)でも確認することができます。</span><span class="sxs-lookup"><span data-stu-id="123a7-106">This information is also available in the [Acquisitions report](../publish/acquisitions-report.md#acquisition-funnel) in the Windows Dev Center dashboard.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="123a7-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="123a7-107">Prerequisites</span></span>


<span data-ttu-id="123a7-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="123a7-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="123a7-109">Windows ストア分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="123a7-109">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Windows Store analytics API.</span></span>
* <span data-ttu-id="123a7-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="123a7-110">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="123a7-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="123a7-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="123a7-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="123a7-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="123a7-113">要求</span><span class="sxs-lookup"><span data-stu-id="123a7-113">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="123a7-114">要求の構文</span><span class="sxs-lookup"><span data-stu-id="123a7-114">Request syntax</span></span>

| <span data-ttu-id="123a7-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="123a7-115">Method</span></span> | <span data-ttu-id="123a7-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="123a7-116">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="123a7-117">GET</span><span class="sxs-lookup"><span data-stu-id="123a7-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/funnel``` |

<span/>

### <a name="request-header"></a><span data-ttu-id="123a7-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="123a7-118">Request header</span></span>

| <span data-ttu-id="123a7-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="123a7-119">Header</span></span>        | <span data-ttu-id="123a7-120">型</span><span class="sxs-lookup"><span data-stu-id="123a7-120">Type</span></span>   | <span data-ttu-id="123a7-121">説明</span><span class="sxs-lookup"><span data-stu-id="123a7-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="123a7-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="123a7-122">Authorization</span></span> | <span data-ttu-id="123a7-123">string</span><span class="sxs-lookup"><span data-stu-id="123a7-123">string</span></span> | <span data-ttu-id="123a7-124">必須。</span><span class="sxs-lookup"><span data-stu-id="123a7-124">Required.</span></span> <span data-ttu-id="123a7-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="123a7-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |

<span/> 

### <a name="request-parameters"></a><span data-ttu-id="123a7-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="123a7-126">Request parameters</span></span>

| <span data-ttu-id="123a7-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="123a7-127">Parameter</span></span>        | <span data-ttu-id="123a7-128">型</span><span class="sxs-lookup"><span data-stu-id="123a7-128">Type</span></span>   |  <span data-ttu-id="123a7-129">説明</span><span class="sxs-lookup"><span data-stu-id="123a7-129">Description</span></span>      |  <span data-ttu-id="123a7-130">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="123a7-130">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="123a7-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="123a7-131">applicationId</span></span> | <span data-ttu-id="123a7-132">string</span><span class="sxs-lookup"><span data-stu-id="123a7-132">string</span></span> | <span data-ttu-id="123a7-133">入手に関するファネル データを取得するアプリの [ストア ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="123a7-133">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the app for which you want to retrieve acquisition funnel data.</span></span> <span data-ttu-id="123a7-134">ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。</span><span class="sxs-lookup"><span data-stu-id="123a7-134">An example Store ID is 9WZDNCRFJ3Q8.</span></span> |  <span data-ttu-id="123a7-135">必須</span><span class="sxs-lookup"><span data-stu-id="123a7-135">Yes</span></span>  |
| <span data-ttu-id="123a7-136">startDate</span><span class="sxs-lookup"><span data-stu-id="123a7-136">startDate</span></span> | <span data-ttu-id="123a7-137">date</span><span class="sxs-lookup"><span data-stu-id="123a7-137">date</span></span> | <span data-ttu-id="123a7-138">取得する入手に関するファネル データの日付範囲開始日です。</span><span class="sxs-lookup"><span data-stu-id="123a7-138">The start date in the date range of acquisition funnel data to retrieve.</span></span> <span data-ttu-id="123a7-139">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="123a7-139">The default is the current date.</span></span> |  <span data-ttu-id="123a7-140">必須ではない</span><span class="sxs-lookup"><span data-stu-id="123a7-140">No</span></span>  |
| <span data-ttu-id="123a7-141">endDate</span><span class="sxs-lookup"><span data-stu-id="123a7-141">endDate</span></span> | <span data-ttu-id="123a7-142">date</span><span class="sxs-lookup"><span data-stu-id="123a7-142">date</span></span> | <span data-ttu-id="123a7-143">取得する入手に関するファネル データの日付範囲終了日です。</span><span class="sxs-lookup"><span data-stu-id="123a7-143">The end date in the date range of acquisition funnel data to retrieve.</span></span> <span data-ttu-id="123a7-144">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="123a7-144">The default is the current date.</span></span> |  <span data-ttu-id="123a7-145">必須ではない</span><span class="sxs-lookup"><span data-stu-id="123a7-145">No</span></span>  |
| <span data-ttu-id="123a7-146">filter</span><span class="sxs-lookup"><span data-stu-id="123a7-146">filter</span></span> | <span data-ttu-id="123a7-147">string</span><span class="sxs-lookup"><span data-stu-id="123a7-147">string</span></span>  | <span data-ttu-id="123a7-148">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。</span><span class="sxs-lookup"><span data-stu-id="123a7-148">One or more statements that filter the rows in the response.</span></span> <span data-ttu-id="123a7-149">詳しくは、次の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="123a7-149">For more information, see the [filter fields](#filter-fields) section below.</span></span> | <span data-ttu-id="123a7-150">必須ではない</span><span class="sxs-lookup"><span data-stu-id="123a7-150">No</span></span>   |

<span/>
 
### <a name="filter-fields"></a><span data-ttu-id="123a7-151">フィルター フィールド</span><span class="sxs-lookup"><span data-stu-id="123a7-151">Filter fields</span></span>

<span data-ttu-id="123a7-152">要求の *filter* パラメーターには、応答内の行をフィルター処理する 1 つまたは複数のステートメントが含まれます。</span><span class="sxs-lookup"><span data-stu-id="123a7-152">The *filter* parameter of the request contains one or more statements that filter the rows in the response.</span></span> <span data-ttu-id="123a7-153">各ステートメントには **eq** 演算子または **ne** 演算子と関連付けられるフィールドと値が含まれ、**and** または **or** を使ってステートメントを組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="123a7-153">Each statement contains a field and value that are associated with the **eq** or **ne** operators, and statements can be combined using **and** or **or**.</span></span>

<span data-ttu-id="123a7-154">以下のフィルター フィールドがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="123a7-154">The following filter fields are supported.</span></span> <span data-ttu-id="123a7-155">*filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。</span><span class="sxs-lookup"><span data-stu-id="123a7-155">String values must be surrounded by single quotes in the *filter* parameter.</span></span>

| <span data-ttu-id="123a7-156">フィールド</span><span class="sxs-lookup"><span data-stu-id="123a7-156">Fields</span></span>        |  <span data-ttu-id="123a7-157">説明</span><span class="sxs-lookup"><span data-stu-id="123a7-157">Description</span></span>        |
|---------------|-----------------|
| <span data-ttu-id="123a7-158">campaignId</span><span class="sxs-lookup"><span data-stu-id="123a7-158">campaignId</span></span> | <span data-ttu-id="123a7-159">入手に関連付けられている[カスタム アプリ プロモーション キャンペーン](../publish/create-a-custom-app-promotion-campaign.md)の ID 文字列です。</span><span class="sxs-lookup"><span data-stu-id="123a7-159">The ID string for a [custom app promotion campaign](../publish/create-a-custom-app-promotion-campaign.md) that is associated with the acquisition.</span></span> |
| <span data-ttu-id="123a7-160">market</span><span class="sxs-lookup"><span data-stu-id="123a7-160">market</span></span> | <span data-ttu-id="123a7-161">入手が発生した市場の ISO 3166 国コードを含む文字列です。</span><span class="sxs-lookup"><span data-stu-id="123a7-161">A string that contains the ISO 3166 country code of the market where the acquisition occurred.</span></span> |
| <span data-ttu-id="123a7-162">deviceType</span><span class="sxs-lookup"><span data-stu-id="123a7-162">deviceType</span></span> | <span data-ttu-id="123a7-163">入手が発生したデバイスの種類を指定する、以下のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="123a7-163">One of the following strings that specifies the device type on which the acquisition occurred:</span></span><ul><li><strong><span data-ttu-id="123a7-164">PC</span><span class="sxs-lookup"><span data-stu-id="123a7-164">PC</span></span></strong></li><li><strong><span data-ttu-id="123a7-165">Phone</span><span class="sxs-lookup"><span data-stu-id="123a7-165">Phone</span></span></strong></li><li><strong><span data-ttu-id="123a7-166">Console</span><span class="sxs-lookup"><span data-stu-id="123a7-166">Console</span></span></strong></li><li><strong><span data-ttu-id="123a7-167">IoT</span><span class="sxs-lookup"><span data-stu-id="123a7-167">IoT</span></span></strong></li><li><strong><span data-ttu-id="123a7-168">Holographic</span><span class="sxs-lookup"><span data-stu-id="123a7-168">Holographic</span></span></strong></li><li><strong><span data-ttu-id="123a7-169">Unknown</span><span class="sxs-lookup"><span data-stu-id="123a7-169">Unknown</span></span></strong></li></ul> |
| <span data-ttu-id="123a7-170">ageGroup</span><span class="sxs-lookup"><span data-stu-id="123a7-170">ageGroup</span></span> | <span data-ttu-id="123a7-171">入手を完了したユーザーの年齢グループを指定する、以下のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="123a7-171">One of the following strings that specifies the age group of the user who completed the acquisition:</span></span><ul><li><strong><span data-ttu-id="123a7-172">0 – 17</span><span class="sxs-lookup"><span data-stu-id="123a7-172">0 – 17</span></span></strong></li><li><strong><span data-ttu-id="123a7-173">18 – 24</span><span class="sxs-lookup"><span data-stu-id="123a7-173">18 – 24</span></span></strong></li><li><strong><span data-ttu-id="123a7-174">25 – 34</span><span class="sxs-lookup"><span data-stu-id="123a7-174">25 – 34</span></span></strong></li><li><strong><span data-ttu-id="123a7-175">35 – 49</span><span class="sxs-lookup"><span data-stu-id="123a7-175">35 – 49</span></span></strong></li><li><strong><span data-ttu-id="123a7-176">50 or over</span><span class="sxs-lookup"><span data-stu-id="123a7-176">50 or over</span></span></strong></li><li><strong><span data-ttu-id="123a7-177">Unknown</span><span class="sxs-lookup"><span data-stu-id="123a7-177">Unknown</span></span></strong></li></ul> |
| <span data-ttu-id="123a7-178">gender</span><span class="sxs-lookup"><span data-stu-id="123a7-178">gender</span></span> | <span data-ttu-id="123a7-179">入手を完了したユーザーの性別を指定する、以下のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="123a7-179">One of the following strings that specifies the gender of the user who completed the acquisition:</span></span><ul><li><strong><span data-ttu-id="123a7-180">M</span><span class="sxs-lookup"><span data-stu-id="123a7-180">M</span></span></strong></li><li><strong><span data-ttu-id="123a7-181">F</span><span class="sxs-lookup"><span data-stu-id="123a7-181">F</span></span></strong></li><li><strong><span data-ttu-id="123a7-182">Unknown</span><span class="sxs-lookup"><span data-stu-id="123a7-182">Unknown</span></span></strong></li></ul> |


<span data-ttu-id="123a7-183">*filter* パラメーターの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="123a7-183">Here are some example *filter* parameters.</span></span>

```filter=market eq 'US' and gender eq 'M'```

```filter=(market ne 'US') and (gender ne 'Unknown') and (gender ne 'M') and (market ne 'NO') and (ageGroup ne '50 or over' or ageGroup ne ‘0 - 17’)```

<span/> 

### <a name="request-example"></a><span data-ttu-id="123a7-184">要求の例</span><span class="sxs-lookup"><span data-stu-id="123a7-184">Request example</span></span>

<span data-ttu-id="123a7-185">アプリの入手に関するファネル データを取得するための要求の例を、いくつか次に示します。</span><span class="sxs-lookup"><span data-stu-id="123a7-185">The following example demonstrates several requests for getting acquisition funnel data for an app.</span></span> <span data-ttu-id="123a7-186">*applicationId* 値を、目的のアプリのストア ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="123a7-186">Replace the *applicationId* value with the Store ID for your app.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/funnel?applicationId=9NBLGGGZ5QDR&startDate=1/1/2017&endDate=2/1/2017  HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/funnel?applicationId=9NBLGGGZ5QDR&startDate=8/1/2016&endDate=8/31/2016&filter=market eq 'US' and gender eq 'm'  HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="123a7-187">応答</span><span class="sxs-lookup"><span data-stu-id="123a7-187">Response</span></span>


### <a name="response-body"></a><span data-ttu-id="123a7-188">応答本文</span><span class="sxs-lookup"><span data-stu-id="123a7-188">Response body</span></span>

| <span data-ttu-id="123a7-189">値</span><span class="sxs-lookup"><span data-stu-id="123a7-189">Value</span></span>      | <span data-ttu-id="123a7-190">型</span><span class="sxs-lookup"><span data-stu-id="123a7-190">Type</span></span>   | <span data-ttu-id="123a7-191">説明</span><span class="sxs-lookup"><span data-stu-id="123a7-191">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="123a7-192">Value</span><span class="sxs-lookup"><span data-stu-id="123a7-192">Value</span></span>      | <span data-ttu-id="123a7-193">array</span><span class="sxs-lookup"><span data-stu-id="123a7-193">array</span></span>  | <span data-ttu-id="123a7-194">アプリに関する入手のファネル データが含まれるオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="123a7-194">An array of objects that contain acquisition funnel data for the app.</span></span> <span data-ttu-id="123a7-195">各オブジェクトのデータについて詳しくは、次の「[ファネル値](#funnel-values)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="123a7-195">For more information about the data in each object, see the [funnel values](#funnel-values) section below.</span></span>                                                                                                                      |
| <span data-ttu-id="123a7-196">TotalCount</span><span class="sxs-lookup"><span data-stu-id="123a7-196">TotalCount</span></span> | <span data-ttu-id="123a7-197">int</span><span class="sxs-lookup"><span data-stu-id="123a7-197">int</span></span>    | <span data-ttu-id="123a7-198">*Value* 配列のオブジェクトの合計数です。</span><span class="sxs-lookup"><span data-stu-id="123a7-198">The total number of objects in the *Value* array.</span></span>                         |
<span/>
 
### <a name="funnel-values"></a><span data-ttu-id="123a7-199">ファネル値</span><span class="sxs-lookup"><span data-stu-id="123a7-199">Funnel values</span></span>

<span data-ttu-id="123a7-200">*Value* 配列のオブジェクトには、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="123a7-200">Objects in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="123a7-201">値</span><span class="sxs-lookup"><span data-stu-id="123a7-201">Value</span></span>               | <span data-ttu-id="123a7-202">型</span><span class="sxs-lookup"><span data-stu-id="123a7-202">Type</span></span>   | <span data-ttu-id="123a7-203">説明</span><span class="sxs-lookup"><span data-stu-id="123a7-203">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="123a7-204">MetricType</span><span class="sxs-lookup"><span data-stu-id="123a7-204">MetricType</span></span>                | <span data-ttu-id="123a7-205">string</span><span class="sxs-lookup"><span data-stu-id="123a7-205">string</span></span> | <span data-ttu-id="123a7-206">このオブジェクトに含まれる[ファネル データの種類](../publish/acquisitions-report.md#acquisition-funnel)を指定する以下のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="123a7-206">One of the following strings that specifies the [type of funnel data](../publish/acquisitions-report.md#acquisition-funnel) that is included in this object:</span></span><ul><li><strong><span data-ttu-id="123a7-207">PageView</span><span class="sxs-lookup"><span data-stu-id="123a7-207">PageView</span></span></strong></li><li><strong><span data-ttu-id="123a7-208">Acquisition</span><span class="sxs-lookup"><span data-stu-id="123a7-208">Acquisition</span></span></strong></li><li><strong><span data-ttu-id="123a7-209">Install</span><span class="sxs-lookup"><span data-stu-id="123a7-209">Install</span></span></strong></li><li><strong><span data-ttu-id="123a7-210">Usage</span><span class="sxs-lookup"><span data-stu-id="123a7-210">Usage</span></span></strong></li></ul> |
| <span data-ttu-id="123a7-211">UserCount</span><span class="sxs-lookup"><span data-stu-id="123a7-211">UserCount</span></span>       | <span data-ttu-id="123a7-212">string</span><span class="sxs-lookup"><span data-stu-id="123a7-212">string</span></span> | <span data-ttu-id="123a7-213">*MetricType* 値によって指定されたファネル手順を実行したユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="123a7-213">The number of users who performed the funnel step specified by the *MetricType* value.</span></span>             |

<span/> 

### <a name="response-example"></a><span data-ttu-id="123a7-214">応答の例</span><span class="sxs-lookup"><span data-stu-id="123a7-214">Response example</span></span>

<span data-ttu-id="123a7-215">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="123a7-215">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Value": [
    {
      "MetricType": "PageView",
      "UserCount": 100
    },
    {
      "MetricType": "Acquisition",
      "UserCount": 80
    },
    {
      "MetricType": "Install",
      "UserCount": 50
    },
    {
      "MetricType": "Usage",
      "UserCount": 10
    }
  ],
  "TotalCount": 4
}
```

## <a name="related-topics"></a><span data-ttu-id="123a7-216">関連トピック</span><span class="sxs-lookup"><span data-stu-id="123a7-216">Related topics</span></span>

* [<span data-ttu-id="123a7-217">取得レポート</span><span class="sxs-lookup"><span data-stu-id="123a7-217">Acquisitions report</span></span>](../publish/acquisitions-report.md)
* [<span data-ttu-id="123a7-218">Windows ストア サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="123a7-218">Access analytics data using Windows Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="123a7-219">アプリの入手数の取得</span><span class="sxs-lookup"><span data-stu-id="123a7-219">Get app acquisitions</span></span>](get-app-acquisitions.md)
