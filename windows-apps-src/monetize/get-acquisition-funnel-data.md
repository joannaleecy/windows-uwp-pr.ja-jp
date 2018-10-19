---
author: Xansky
description: 日付範囲やその他のオプション フィルターを指定して、アプリケーションの入手に関するファネル データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: アプリの入手に関するファネル データの取得
ms.author: mhopkins
ms.date: 08/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, 入手, ファネル
ms.localizationpriority: medium
ms.openlocfilehash: 362bcc956fa5945f9685aac7d6351b9fda7690de
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5157738"
---
# <a name="get-app-acquisition-funnel-data"></a><span data-ttu-id="26a1a-104">アプリの入手に関するファネル データの取得</span><span class="sxs-lookup"><span data-stu-id="26a1a-104">Get app acquisition funnel data</span></span>

<span data-ttu-id="26a1a-105">日付範囲やその他のオプション フィルターを指定して、アプリケーションの入手に関するファネル データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="26a1a-105">Use this method in the Microsoft Store analytics API to get acquisition funnel data for an application during a given date range and other optional filters.</span></span> <span data-ttu-id="26a1a-106">この情報は、Windows デベロッパー センター ダッシュボードの[取得レポート](../publish/acquisitions-report.md#acquisition-funnel)でも確認することができます。</span><span class="sxs-lookup"><span data-stu-id="26a1a-106">This information is also available in the [Acquisitions report](../publish/acquisitions-report.md#acquisition-funnel) in the Windows Dev Center dashboard.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="26a1a-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="26a1a-107">Prerequisites</span></span>


<span data-ttu-id="26a1a-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="26a1a-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="26a1a-109">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="26a1a-109">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="26a1a-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="26a1a-110">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="26a1a-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="26a1a-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="26a1a-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="26a1a-113">要求</span><span class="sxs-lookup"><span data-stu-id="26a1a-113">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="26a1a-114">要求の構文</span><span class="sxs-lookup"><span data-stu-id="26a1a-114">Request syntax</span></span>

| <span data-ttu-id="26a1a-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="26a1a-115">Method</span></span> | <span data-ttu-id="26a1a-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="26a1a-116">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="26a1a-117">GET</span><span class="sxs-lookup"><span data-stu-id="26a1a-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/funnel``` |


### <a name="request-header"></a><span data-ttu-id="26a1a-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="26a1a-118">Request header</span></span>

| <span data-ttu-id="26a1a-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="26a1a-119">Header</span></span>        | <span data-ttu-id="26a1a-120">型</span><span class="sxs-lookup"><span data-stu-id="26a1a-120">Type</span></span>   | <span data-ttu-id="26a1a-121">説明</span><span class="sxs-lookup"><span data-stu-id="26a1a-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="26a1a-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="26a1a-122">Authorization</span></span> | <span data-ttu-id="26a1a-123">string</span><span class="sxs-lookup"><span data-stu-id="26a1a-123">string</span></span> | <span data-ttu-id="26a1a-124">必須。</span><span class="sxs-lookup"><span data-stu-id="26a1a-124">Required.</span></span> <span data-ttu-id="26a1a-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="26a1a-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="26a1a-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="26a1a-126">Request parameters</span></span>

| <span data-ttu-id="26a1a-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="26a1a-127">Parameter</span></span>        | <span data-ttu-id="26a1a-128">型</span><span class="sxs-lookup"><span data-stu-id="26a1a-128">Type</span></span>   |  <span data-ttu-id="26a1a-129">説明</span><span class="sxs-lookup"><span data-stu-id="26a1a-129">Description</span></span>      |  <span data-ttu-id="26a1a-130">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="26a1a-130">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="26a1a-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="26a1a-131">applicationId</span></span> | <span data-ttu-id="26a1a-132">string</span><span class="sxs-lookup"><span data-stu-id="26a1a-132">string</span></span> | <span data-ttu-id="26a1a-133">入手に関するファネル データを取得するアプリの [ストア ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-133">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the app for which you want to retrieve acquisition funnel data.</span></span> <span data-ttu-id="26a1a-134">ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-134">An example Store ID is 9WZDNCRFJ3Q8.</span></span> |  <span data-ttu-id="26a1a-135">必須</span><span class="sxs-lookup"><span data-stu-id="26a1a-135">Yes</span></span>  |
| <span data-ttu-id="26a1a-136">startDate</span><span class="sxs-lookup"><span data-stu-id="26a1a-136">startDate</span></span> | <span data-ttu-id="26a1a-137">date</span><span class="sxs-lookup"><span data-stu-id="26a1a-137">date</span></span> | <span data-ttu-id="26a1a-138">取得する入手に関するファネル データの日付範囲開始日です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-138">The start date in the date range of acquisition funnel data to retrieve.</span></span> <span data-ttu-id="26a1a-139">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-139">The default is the current date.</span></span> |  <span data-ttu-id="26a1a-140">必須ではない</span><span class="sxs-lookup"><span data-stu-id="26a1a-140">No</span></span>  |
| <span data-ttu-id="26a1a-141">endDate</span><span class="sxs-lookup"><span data-stu-id="26a1a-141">endDate</span></span> | <span data-ttu-id="26a1a-142">date</span><span class="sxs-lookup"><span data-stu-id="26a1a-142">date</span></span> | <span data-ttu-id="26a1a-143">取得する入手に関するファネル データの日付範囲終了日です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-143">The end date in the date range of acquisition funnel data to retrieve.</span></span> <span data-ttu-id="26a1a-144">既定値は現在の日付です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-144">The default is the current date.</span></span> |  <span data-ttu-id="26a1a-145">必須ではない</span><span class="sxs-lookup"><span data-stu-id="26a1a-145">No</span></span>  |
| <span data-ttu-id="26a1a-146">filter</span><span class="sxs-lookup"><span data-stu-id="26a1a-146">filter</span></span> | <span data-ttu-id="26a1a-147">string</span><span class="sxs-lookup"><span data-stu-id="26a1a-147">string</span></span>  | <span data-ttu-id="26a1a-148">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。</span><span class="sxs-lookup"><span data-stu-id="26a1a-148">One or more statements that filter the rows in the response.</span></span> <span data-ttu-id="26a1a-149">詳しくは、次の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="26a1a-149">For more information, see the [filter fields](#filter-fields) section below.</span></span> | <span data-ttu-id="26a1a-150">必須ではない</span><span class="sxs-lookup"><span data-stu-id="26a1a-150">No</span></span>   |

 
### <a name="filter-fields"></a><span data-ttu-id="26a1a-151">フィルター フィールド</span><span class="sxs-lookup"><span data-stu-id="26a1a-151">Filter fields</span></span>

<span data-ttu-id="26a1a-152">要求の *filter* パラメーターには、応答内の行をフィルター処理する 1 つまたは複数のステートメントが含まれます。</span><span class="sxs-lookup"><span data-stu-id="26a1a-152">The *filter* parameter of the request contains one or more statements that filter the rows in the response.</span></span> <span data-ttu-id="26a1a-153">各ステートメントには **eq** 演算子または **ne** 演算子と関連付けられるフィールドと値が含まれ、**and** または **or** を使ってステートメントを組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="26a1a-153">Each statement contains a field and value that are associated with the **eq** or **ne** operators, and statements can be combined using **and** or **or**.</span></span>

<span data-ttu-id="26a1a-154">以下のフィルター フィールドがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="26a1a-154">The following filter fields are supported.</span></span> <span data-ttu-id="26a1a-155">*filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。</span><span class="sxs-lookup"><span data-stu-id="26a1a-155">String values must be surrounded by single quotes in the *filter* parameter.</span></span>

| <span data-ttu-id="26a1a-156">フィールド</span><span class="sxs-lookup"><span data-stu-id="26a1a-156">Fields</span></span>        |  <span data-ttu-id="26a1a-157">説明</span><span class="sxs-lookup"><span data-stu-id="26a1a-157">Description</span></span>        |
|---------------|-----------------|
| <span data-ttu-id="26a1a-158">campaignId</span><span class="sxs-lookup"><span data-stu-id="26a1a-158">campaignId</span></span> | <span data-ttu-id="26a1a-159">入手に関連付けられている[カスタム アプリ プロモーション キャンペーン](../publish/create-a-custom-app-promotion-campaign.md)の ID 文字列です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-159">The ID string for a [custom app promotion campaign](../publish/create-a-custom-app-promotion-campaign.md) that is associated with the acquisition.</span></span> |
| <span data-ttu-id="26a1a-160">market</span><span class="sxs-lookup"><span data-stu-id="26a1a-160">market</span></span> | <span data-ttu-id="26a1a-161">入手が発生した市場の ISO 3166 国コードを含む文字列です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-161">A string that contains the ISO 3166 country code of the market where the acquisition occurred.</span></span> |
| <span data-ttu-id="26a1a-162">deviceType</span><span class="sxs-lookup"><span data-stu-id="26a1a-162">deviceType</span></span> | <span data-ttu-id="26a1a-163">入手が発生したデバイスの種類を指定する、以下のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-163">One of the following strings that specifies the device type on which the acquisition occurred:</span></span><ul><li><strong><span data-ttu-id="26a1a-164">PC</span><span class="sxs-lookup"><span data-stu-id="26a1a-164">PC</span></span></strong></li><li><strong><span data-ttu-id="26a1a-165">Phone</span><span class="sxs-lookup"><span data-stu-id="26a1a-165">Phone</span></span></strong></li><li><strong><span data-ttu-id="26a1a-166">Console</span><span class="sxs-lookup"><span data-stu-id="26a1a-166">Console</span></span></strong></li><li><strong><span data-ttu-id="26a1a-167">IoT</span><span class="sxs-lookup"><span data-stu-id="26a1a-167">IoT</span></span></strong></li><li><strong><span data-ttu-id="26a1a-168">Holographic</span><span class="sxs-lookup"><span data-stu-id="26a1a-168">Holographic</span></span></strong></li><li><strong><span data-ttu-id="26a1a-169">Unknown</span><span class="sxs-lookup"><span data-stu-id="26a1a-169">Unknown</span></span></strong></li></ul> |
| <span data-ttu-id="26a1a-170">ageGroup</span><span class="sxs-lookup"><span data-stu-id="26a1a-170">ageGroup</span></span> | <span data-ttu-id="26a1a-171">入手を完了したユーザーの年齢グループを指定する、以下のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-171">One of the following strings that specifies the age group of the user who completed the acquisition:</span></span><ul><li><strong><span data-ttu-id="26a1a-172">0 – 17</span><span class="sxs-lookup"><span data-stu-id="26a1a-172">0 – 17</span></span></strong></li><li><strong><span data-ttu-id="26a1a-173">18 – 24</span><span class="sxs-lookup"><span data-stu-id="26a1a-173">18 – 24</span></span></strong></li><li><strong><span data-ttu-id="26a1a-174">25 – 34</span><span class="sxs-lookup"><span data-stu-id="26a1a-174">25 – 34</span></span></strong></li><li><strong><span data-ttu-id="26a1a-175">35 – 49</span><span class="sxs-lookup"><span data-stu-id="26a1a-175">35 – 49</span></span></strong></li><li><strong><span data-ttu-id="26a1a-176">50 or over</span><span class="sxs-lookup"><span data-stu-id="26a1a-176">50 or over</span></span></strong></li><li><strong><span data-ttu-id="26a1a-177">Unknown</span><span class="sxs-lookup"><span data-stu-id="26a1a-177">Unknown</span></span></strong></li></ul> |
| <span data-ttu-id="26a1a-178">gender</span><span class="sxs-lookup"><span data-stu-id="26a1a-178">gender</span></span> | <span data-ttu-id="26a1a-179">入手を完了したユーザーの性別を指定する、以下のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-179">One of the following strings that specifies the gender of the user who completed the acquisition:</span></span><ul><li><strong><span data-ttu-id="26a1a-180">M</span><span class="sxs-lookup"><span data-stu-id="26a1a-180">M</span></span></strong></li><li><strong><span data-ttu-id="26a1a-181">F</span><span class="sxs-lookup"><span data-stu-id="26a1a-181">F</span></span></strong></li><li><strong><span data-ttu-id="26a1a-182">Unknown</span><span class="sxs-lookup"><span data-stu-id="26a1a-182">Unknown</span></span></strong></li></ul> |


### <a name="request-example"></a><span data-ttu-id="26a1a-183">要求の例</span><span class="sxs-lookup"><span data-stu-id="26a1a-183">Request example</span></span>

<span data-ttu-id="26a1a-184">アプリの入手に関するファネル データを取得するための要求の例を、いくつか次に示します。</span><span class="sxs-lookup"><span data-stu-id="26a1a-184">The following example demonstrates several requests for getting acquisition funnel data for an app.</span></span> <span data-ttu-id="26a1a-185">*applicationId* 値を、目的のアプリのストア ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="26a1a-185">Replace the *applicationId* value with the Store ID for your app.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/funnel?applicationId=9NBLGGGZ5QDR&startDate=1/1/2017&endDate=2/1/2017  HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/funnel?applicationId=9NBLGGGZ5QDR&startDate=8/1/2016&endDate=8/31/2016&filter=market eq 'US' and gender eq 'm'  HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="26a1a-186">応答</span><span class="sxs-lookup"><span data-stu-id="26a1a-186">Response</span></span>


### <a name="response-body"></a><span data-ttu-id="26a1a-187">応答本文</span><span class="sxs-lookup"><span data-stu-id="26a1a-187">Response body</span></span>

| <span data-ttu-id="26a1a-188">値</span><span class="sxs-lookup"><span data-stu-id="26a1a-188">Value</span></span>      | <span data-ttu-id="26a1a-189">型</span><span class="sxs-lookup"><span data-stu-id="26a1a-189">Type</span></span>   | <span data-ttu-id="26a1a-190">説明</span><span class="sxs-lookup"><span data-stu-id="26a1a-190">Description</span></span>                  |
|------------|--------|-------------------------------------------------------|
| <span data-ttu-id="26a1a-191">Value</span><span class="sxs-lookup"><span data-stu-id="26a1a-191">Value</span></span>      | <span data-ttu-id="26a1a-192">array</span><span class="sxs-lookup"><span data-stu-id="26a1a-192">array</span></span>  | <span data-ttu-id="26a1a-193">アプリに関する入手のファネル データが含まれるオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-193">An array of objects that contain acquisition funnel data for the app.</span></span> <span data-ttu-id="26a1a-194">各オブジェクトのデータについて詳しくは、次の「[ファネル値](#funnel-values)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="26a1a-194">For more information about the data in each object, see the [funnel values](#funnel-values) section below.</span></span>                  |
| <span data-ttu-id="26a1a-195">TotalCount</span><span class="sxs-lookup"><span data-stu-id="26a1a-195">TotalCount</span></span> | <span data-ttu-id="26a1a-196">int</span><span class="sxs-lookup"><span data-stu-id="26a1a-196">int</span></span>    | <span data-ttu-id="26a1a-197">*Value* 配列のオブジェクトの合計数です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-197">The total number of objects in the *Value* array.</span></span>        |


### <a name="funnel-values"></a><span data-ttu-id="26a1a-198">ファネル値</span><span class="sxs-lookup"><span data-stu-id="26a1a-198">Funnel values</span></span>

<span data-ttu-id="26a1a-199">*Value* 配列のオブジェクトには、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="26a1a-199">Objects in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="26a1a-200">値</span><span class="sxs-lookup"><span data-stu-id="26a1a-200">Value</span></span>               | <span data-ttu-id="26a1a-201">型</span><span class="sxs-lookup"><span data-stu-id="26a1a-201">Type</span></span>   | <span data-ttu-id="26a1a-202">説明</span><span class="sxs-lookup"><span data-stu-id="26a1a-202">Description</span></span>                           |
|---------------------|--------|-------------------------------------------|
| <span data-ttu-id="26a1a-203">MetricType</span><span class="sxs-lookup"><span data-stu-id="26a1a-203">MetricType</span></span>                | <span data-ttu-id="26a1a-204">string</span><span class="sxs-lookup"><span data-stu-id="26a1a-204">string</span></span> | <span data-ttu-id="26a1a-205">このオブジェクトに含まれる[ファネル データの種類](../publish/acquisitions-report.md#acquisition-funnel)を指定する以下のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-205">One of the following strings that specifies the [type of funnel data](../publish/acquisitions-report.md#acquisition-funnel) that is included in this object:</span></span><ul><li><strong><span data-ttu-id="26a1a-206">PageView</span><span class="sxs-lookup"><span data-stu-id="26a1a-206">PageView</span></span></strong></li><li><strong><span data-ttu-id="26a1a-207">Acquisition</span><span class="sxs-lookup"><span data-stu-id="26a1a-207">Acquisition</span></span></strong></li><li><strong><span data-ttu-id="26a1a-208">Install</span><span class="sxs-lookup"><span data-stu-id="26a1a-208">Install</span></span></strong></li><li><strong><span data-ttu-id="26a1a-209">Usage</span><span class="sxs-lookup"><span data-stu-id="26a1a-209">Usage</span></span></strong></li></ul> |
| <span data-ttu-id="26a1a-210">UserCount</span><span class="sxs-lookup"><span data-stu-id="26a1a-210">UserCount</span></span>       | <span data-ttu-id="26a1a-211">string</span><span class="sxs-lookup"><span data-stu-id="26a1a-211">string</span></span> | <span data-ttu-id="26a1a-212">*MetricType* 値によって指定されたファネル手順を実行したユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="26a1a-212">The number of users who performed the funnel step specified by the *MetricType* value.</span></span>             |


### <a name="response-example"></a><span data-ttu-id="26a1a-213">応答の例</span><span class="sxs-lookup"><span data-stu-id="26a1a-213">Response example</span></span>

<span data-ttu-id="26a1a-214">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="26a1a-214">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="26a1a-215">関連トピック</span><span class="sxs-lookup"><span data-stu-id="26a1a-215">Related topics</span></span>

* [<span data-ttu-id="26a1a-216">取得レポート</span><span class="sxs-lookup"><span data-stu-id="26a1a-216">Acquisitions report</span></span>](../publish/acquisitions-report.md)
* [<span data-ttu-id="26a1a-217">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="26a1a-217">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="26a1a-218">アプリの入手数の取得</span><span class="sxs-lookup"><span data-stu-id="26a1a-218">Get app acquisitions</span></span>](get-app-acquisitions.md)
