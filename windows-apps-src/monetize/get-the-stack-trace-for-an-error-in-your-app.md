---
author: mcleanbyron
ms.assetid: b556a245-6359-4ddc-a4bd-76f9873ab694
description: アプリのエラーに関するスタック トレースを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: アプリのエラーに関するスタック トレースの取得
ms.author: mcleans
ms.date: 06/16/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, スタック トレース, エラー
ms.localizationpriority: medium
ms.openlocfilehash: d29237bfc36c745933c5c40bba9c584d2e705947
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1662782"
---
# <a name="get-the-stack-trace-for-an-error-in-your-app"></a><span data-ttu-id="a4c91-104">アプリのエラーに関するスタック トレースの取得</span><span class="sxs-lookup"><span data-stu-id="a4c91-104">Get the stack trace for an error in your app</span></span>

<span data-ttu-id="a4c91-105">アプリのエラーに関するスタック トレースを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="a4c91-105">Use this method in the Microsoft Store analytics API to get the stack trace for an error in your app.</span></span> <span data-ttu-id="a4c91-106">このメソッドでダウンロードできるのは、過去 30 日以内に発生したアプリのエラーに関するスタック トレースのみです。</span><span class="sxs-lookup"><span data-stu-id="a4c91-106">This method can only download the stack trace for an app error that occurred in the last 30 days.</span></span> <span data-ttu-id="a4c91-107">スタック トレースは、Windows デベロッパー センター ダッシュボードの[状態レポート](../publish/health-report.md)の **[エラー]** セクションでも確認できます。</span><span class="sxs-lookup"><span data-stu-id="a4c91-107">Stack traces are also available in the **Failures** section of the [Health report](../publish/health-report.md) in the Windows Dev Center dashboard.</span></span>

<span data-ttu-id="a4c91-108">このメソッドを使うには、その前にまず「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a4c91-108">Before you can use this method, you must first use the [get details for an error in your app](get-details-for-an-error-in-your-app.md) method to retrieve the ID of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="a4c91-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="a4c91-109">Prerequisites</span></span>


<span data-ttu-id="a4c91-110">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a4c91-110">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="a4c91-111">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="a4c91-111">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="a4c91-112">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="a4c91-112">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="a4c91-113">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="a4c91-113">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="a4c91-114">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="a4c91-114">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="a4c91-115">スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="a4c91-115">Get the ID of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span> <span data-ttu-id="a4c91-116">この ID を取得するには、「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で **cabId** 値を使います。</span><span class="sxs-lookup"><span data-stu-id="a4c91-116">To get this ID, use the [get details for an error in your app](get-details-for-an-error-in-your-app.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span>

## <a name="request"></a><span data-ttu-id="a4c91-117">要求</span><span class="sxs-lookup"><span data-stu-id="a4c91-117">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="a4c91-118">要求の構文</span><span class="sxs-lookup"><span data-stu-id="a4c91-118">Request syntax</span></span>

| <span data-ttu-id="a4c91-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="a4c91-119">Method</span></span> | <span data-ttu-id="a4c91-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a4c91-120">Request URI</span></span>                                                          |
|--------|----------------------------------------------------------------------|
| <span data-ttu-id="a4c91-121">GET</span><span class="sxs-lookup"><span data-stu-id="a4c91-121">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/stacktrace``` |


### <a name="request-header"></a><span data-ttu-id="a4c91-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a4c91-122">Request header</span></span>

| <span data-ttu-id="a4c91-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a4c91-123">Header</span></span>        | <span data-ttu-id="a4c91-124">型</span><span class="sxs-lookup"><span data-stu-id="a4c91-124">Type</span></span>   | <span data-ttu-id="a4c91-125">説明</span><span class="sxs-lookup"><span data-stu-id="a4c91-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="a4c91-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="a4c91-126">Authorization</span></span> | <span data-ttu-id="a4c91-127">string</span><span class="sxs-lookup"><span data-stu-id="a4c91-127">string</span></span> | <span data-ttu-id="a4c91-128">必須。</span><span class="sxs-lookup"><span data-stu-id="a4c91-128">Required.</span></span> <span data-ttu-id="a4c91-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="a4c91-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="a4c91-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="a4c91-130">Request parameters</span></span>

| <span data-ttu-id="a4c91-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a4c91-131">Parameter</span></span>        | <span data-ttu-id="a4c91-132">型</span><span class="sxs-lookup"><span data-stu-id="a4c91-132">Type</span></span>   |  <span data-ttu-id="a4c91-133">説明</span><span class="sxs-lookup"><span data-stu-id="a4c91-133">Description</span></span>      |  <span data-ttu-id="a4c91-134">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="a4c91-134">Required</span></span>  |
|---------------|--------|---------------|------|
| <span data-ttu-id="a4c91-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="a4c91-135">applicationId</span></span> | <span data-ttu-id="a4c91-136">string</span><span class="sxs-lookup"><span data-stu-id="a4c91-136">string</span></span> | <span data-ttu-id="a4c91-137">スタック トレースを取得するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="a4c91-137">The Store ID of the app for which you want to get the stack trace.</span></span> <span data-ttu-id="a4c91-138">ストア ID は、デベロッパー センター ダッシュボードの[アプリ ID ページ](../publish/view-app-identity-details.md)で確認できます。</span><span class="sxs-lookup"><span data-stu-id="a4c91-138">The Store ID is available on the [App identity page](../publish/view-app-identity-details.md) of the Dev Center dashboard.</span></span> <span data-ttu-id="a4c91-139">ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。</span><span class="sxs-lookup"><span data-stu-id="a4c91-139">An example Store ID is 9WZDNCRFJ3Q8.</span></span> |  <span data-ttu-id="a4c91-140">必須</span><span class="sxs-lookup"><span data-stu-id="a4c91-140">Yes</span></span>  |
| <span data-ttu-id="a4c91-141">cabId</span><span class="sxs-lookup"><span data-stu-id="a4c91-141">cabId</span></span> | <span data-ttu-id="a4c91-142">string</span><span class="sxs-lookup"><span data-stu-id="a4c91-142">string</span></span> | <span data-ttu-id="a4c91-143">スタック トレースを取得するエラーに関連付けられた CAB ファイルの一意の ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="a4c91-143">The unique ID of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span> <span data-ttu-id="a4c91-144">この ID を取得するには、「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で **cabId** 値を使います。</span><span class="sxs-lookup"><span data-stu-id="a4c91-144">To get this ID, use the [get details for an error in your app](get-details-for-an-error-in-your-app.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span> |  <span data-ttu-id="a4c91-145">必須</span><span class="sxs-lookup"><span data-stu-id="a4c91-145">Yes</span></span>  |

 
### <a name="request-example"></a><span data-ttu-id="a4c91-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="a4c91-146">Request example</span></span>

<span data-ttu-id="a4c91-147">次の例は、このメソッドを使ってスタック トレースを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a4c91-147">The following example demonstrates how to get a stack trace using this method.</span></span> <span data-ttu-id="a4c91-148">*applicationId* 値を、目的のアプリのストア ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="a4c91-148">Replace the *applicationId* value with the Store ID for your app.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/stacktrace?applicationId=9NBLGGGZ5QDR&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="a4c91-149">応答</span><span class="sxs-lookup"><span data-stu-id="a4c91-149">Response</span></span>


### <a name="response-body"></a><span data-ttu-id="a4c91-150">応答本文</span><span class="sxs-lookup"><span data-stu-id="a4c91-150">Response body</span></span>

| <span data-ttu-id="a4c91-151">値</span><span class="sxs-lookup"><span data-stu-id="a4c91-151">Value</span></span>      | <span data-ttu-id="a4c91-152">型</span><span class="sxs-lookup"><span data-stu-id="a4c91-152">Type</span></span>    | <span data-ttu-id="a4c91-153">説明</span><span class="sxs-lookup"><span data-stu-id="a4c91-153">Description</span></span>                  |
|------------|---------|--------------------------------|
| <span data-ttu-id="a4c91-154">Value</span><span class="sxs-lookup"><span data-stu-id="a4c91-154">Value</span></span>      | <span data-ttu-id="a4c91-155">array</span><span class="sxs-lookup"><span data-stu-id="a4c91-155">array</span></span>   | <span data-ttu-id="a4c91-156">各オブジェクトにスタック トレース データの 1 つのフレームが格納されたオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="a4c91-156">An array of objects that each contain one frame of stack trace data.</span></span> <span data-ttu-id="a4c91-157">各オブジェクトのデータについて詳しくは、次の「[スタック トレースの値](#stack-trace-values)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4c91-157">For more information about the data in each object, see the [stack trace values](#stack-trace-values) section below.</span></span> |
| @nextLink  | <span data-ttu-id="a4c91-158">string</span><span class="sxs-lookup"><span data-stu-id="a4c91-158">string</span></span>  | <span data-ttu-id="a4c91-159">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a4c91-159">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="a4c91-160">たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="a4c91-160">For example, this value is returned if the **top** parameter of the request is set to 10 but there are more than 10 rows of errors for the query.</span></span> |
| <span data-ttu-id="a4c91-161">TotalCount</span><span class="sxs-lookup"><span data-stu-id="a4c91-161">TotalCount</span></span> | <span data-ttu-id="a4c91-162">inumber</span><span class="sxs-lookup"><span data-stu-id="a4c91-162">inumber</span></span> | <span data-ttu-id="a4c91-163">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="a4c91-163">The total number of rows in the data result for the query.</span></span>          |


### <a name="stack-trace-values"></a><span data-ttu-id="a4c91-164">スタック トレースの値</span><span class="sxs-lookup"><span data-stu-id="a4c91-164">Stack trace values</span></span>

<span data-ttu-id="a4c91-165">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a4c91-165">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="a4c91-166">値</span><span class="sxs-lookup"><span data-stu-id="a4c91-166">Value</span></span>           | <span data-ttu-id="a4c91-167">型</span><span class="sxs-lookup"><span data-stu-id="a4c91-167">Type</span></span>    | <span data-ttu-id="a4c91-168">説明</span><span class="sxs-lookup"><span data-stu-id="a4c91-168">Description</span></span>      |
|-----------------|---------|----------------|
| <span data-ttu-id="a4c91-169">level</span><span class="sxs-lookup"><span data-stu-id="a4c91-169">level</span></span>            | <span data-ttu-id="a4c91-170">string</span><span class="sxs-lookup"><span data-stu-id="a4c91-170">string</span></span>  |  <span data-ttu-id="a4c91-171">コール スタックでこの要素が表すフレーム番号です。</span><span class="sxs-lookup"><span data-stu-id="a4c91-171">The frame number that this element represents in the call stack.</span></span>  |
| <span data-ttu-id="a4c91-172">image</span><span class="sxs-lookup"><span data-stu-id="a4c91-172">image</span></span>   | <span data-ttu-id="a4c91-173">string</span><span class="sxs-lookup"><span data-stu-id="a4c91-173">string</span></span>  |   <span data-ttu-id="a4c91-174">このスタック フレームで呼び出される関数が含まれている実行可能ファイルまたはライブラリ イメージの名前です。</span><span class="sxs-lookup"><span data-stu-id="a4c91-174">The name of the executable or library image that contains the function that is called in this stack frame.</span></span>           |
| <span data-ttu-id="a4c91-175">function</span><span class="sxs-lookup"><span data-stu-id="a4c91-175">function</span></span> | <span data-ttu-id="a4c91-176">string</span><span class="sxs-lookup"><span data-stu-id="a4c91-176">string</span></span>  |  <span data-ttu-id="a4c91-177">このスタック フレームで呼び出される関数の名前。</span><span class="sxs-lookup"><span data-stu-id="a4c91-177">The name of the function that is called in this stack frame.</span></span> <span data-ttu-id="a4c91-178">これは、アプリが実行可能ファイルまたはライブラリのシンボルを含んでいる場合のみ使用可能です。</span><span class="sxs-lookup"><span data-stu-id="a4c91-178">This is available only if your app includes symbols for the executable or library.</span></span>              |
| <span data-ttu-id="a4c91-179">offset</span><span class="sxs-lookup"><span data-stu-id="a4c91-179">offset</span></span>     | <span data-ttu-id="a4c91-180">string</span><span class="sxs-lookup"><span data-stu-id="a4c91-180">string</span></span>  |  <span data-ttu-id="a4c91-181">関数の先頭を基準とした現在の命令のバイト オフセットです。</span><span class="sxs-lookup"><span data-stu-id="a4c91-181">The byte offset of the current instruction relative to the start of the function.</span></span>      |


### <a name="response-example"></a><span data-ttu-id="a4c91-182">応答の例</span><span class="sxs-lookup"><span data-stu-id="a4c91-182">Response example</span></span>

<span data-ttu-id="a4c91-183">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a4c91-183">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Value": [
    {
      "level": "0",
      "image": "Contoso.ContosoApp",
      "function": "Contoso.ContosoApp.MainPage.DoWork",
      "offset": "0x25C"
    }
    {
      "level": "1",
      "image": "Contoso.ContosoApp",
      "function": "Contoso.ContosoApp.MainPage.Initialize",
      "offset": "0x26"
    }
    {
      "level": "2",
      "image": "Contoso.ContosoApp",
      "function": "Contoso.ContosoApp.Start",
      "offset": "0x66"
    }
  ],
  "@nextLink": null,
  "TotalCount": 3
}

```

## <a name="related-topics"></a><span data-ttu-id="a4c91-184">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a4c91-184">Related topics</span></span>

* [<span data-ttu-id="a4c91-185">状態レポート</span><span class="sxs-lookup"><span data-stu-id="a4c91-185">Health report</span></span>](../publish/health-report.md)
* [<span data-ttu-id="a4c91-186">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="a4c91-186">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="a4c91-187">エラー報告データの取得</span><span class="sxs-lookup"><span data-stu-id="a4c91-187">Get error reporting data</span></span>](get-error-reporting-data.md)
* [<span data-ttu-id="a4c91-188">アプリのエラーに関する詳細情報の取得</span><span class="sxs-lookup"><span data-stu-id="a4c91-188">Get details for an error in your app</span></span>](get-details-for-an-error-in-your-app.md)
* [<span data-ttu-id="a4c91-189">アプリのエラーの CAB ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="a4c91-189">Download the CAB file for an error in your app</span></span>](download-the-cab-file-for-an-error-in-your-app.md)
