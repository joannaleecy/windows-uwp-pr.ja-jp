---
author: Xansky
description: デスクトップ アプリケーションのエラーに関するスタック トレースを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: デスクトップ アプリケーションのエラーに関するスタック トレースの取得
ms.author: mhopkins
ms.date: 06/05/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, スタック トレース, エラー, デスクトップ アプリケーション
ms.localizationpriority: medium
ms.openlocfilehash: 024c903ea43d9fabc90b2f6b7891f6de4e92b1d5
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7280714"
---
# <a name="get-the-stack-trace-for-an-error-in-your-desktop-application"></a><span data-ttu-id="e5766-104">デスクトップ アプリケーションのエラーに関するスタック トレースの取得</span><span class="sxs-lookup"><span data-stu-id="e5766-104">Get the stack trace for an error in your desktop application</span></span>

<span data-ttu-id="e5766-105">[Windows デスクトップ アプリケーション プログラム](https://msdn.microsoft.com/library/windows/desktop/mt826504)に追加したデスクトップ アプリケーションのエラーに関するスタック トレースを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="e5766-105">Use this method in the Microsoft Store analytics API to get the stack trace for an error in a desktop application that you have added to the [Windows Desktop Application program](https://msdn.microsoft.com/library/windows/desktop/mt826504).</span></span> <span data-ttu-id="e5766-106">このメソッドでダウンロードできるのは、過去 30 日以内に発生したエラーに関するスタック トレースのみです。</span><span class="sxs-lookup"><span data-stu-id="e5766-106">This method can only download the stack trace for an error that occurred in the last 30 days.</span></span> <span data-ttu-id="e5766-107">スタック トレースでは、パートナー センターでのデスクトップ アプリケーションの[正常性レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)で利用できます。</span><span class="sxs-lookup"><span data-stu-id="e5766-107">Stack traces are also available in the [Health report](https://msdn.microsoft.com/library/windows/desktop/mt826504) for desktop applications in Partner Center.</span></span>

<span data-ttu-id="e5766-108">このメソッドを使うには、その前にまず「[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)」のメソッドを使って、スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID ハッシュを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e5766-108">Before you can use this method, you must first use the [get details for an error in your desktop application](get-details-for-an-error-in-your-desktop-application.md) method to retrieve the ID hash of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="e5766-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="e5766-109">Prerequisites</span></span>


<span data-ttu-id="e5766-110">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e5766-110">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="e5766-111">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="e5766-111">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="e5766-112">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="e5766-112">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="e5766-113">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="e5766-113">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="e5766-114">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="e5766-114">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="e5766-115">スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID ハッシュを取得します。</span><span class="sxs-lookup"><span data-stu-id="e5766-115">Get the ID hash of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span> <span data-ttu-id="e5766-116">この値を取得するには、「[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)」のメソッドを使ってアプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文に含まれる **cabIdHash** 値を使用します。</span><span class="sxs-lookup"><span data-stu-id="e5766-116">To get this value, use the [get details for an error in your desktop application](get-details-for-an-error-in-your-desktop-application.md) method to retrieve details for a specific error in your app, and use the **cabIdHash** value in the response body of that method.</span></span>

## <a name="request"></a><span data-ttu-id="e5766-117">要求</span><span class="sxs-lookup"><span data-stu-id="e5766-117">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="e5766-118">要求の構文</span><span class="sxs-lookup"><span data-stu-id="e5766-118">Request syntax</span></span>

| <span data-ttu-id="e5766-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="e5766-119">Method</span></span> | <span data-ttu-id="e5766-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="e5766-120">Request URI</span></span>                                                          |
|--------|----------------------------------------------------------------------|
| <span data-ttu-id="e5766-121">GET</span><span class="sxs-lookup"><span data-stu-id="e5766-121">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/stacktrace``` |


### <a name="request-header"></a><span data-ttu-id="e5766-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e5766-122">Request header</span></span>

| <span data-ttu-id="e5766-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e5766-123">Header</span></span>        | <span data-ttu-id="e5766-124">型</span><span class="sxs-lookup"><span data-stu-id="e5766-124">Type</span></span>   | <span data-ttu-id="e5766-125">説明</span><span class="sxs-lookup"><span data-stu-id="e5766-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="e5766-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="e5766-126">Authorization</span></span> | <span data-ttu-id="e5766-127">string</span><span class="sxs-lookup"><span data-stu-id="e5766-127">string</span></span> | <span data-ttu-id="e5766-128">必須。</span><span class="sxs-lookup"><span data-stu-id="e5766-128">Required.</span></span> <span data-ttu-id="e5766-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="e5766-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |
 

### <a name="request-parameters"></a><span data-ttu-id="e5766-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="e5766-130">Request parameters</span></span>

| <span data-ttu-id="e5766-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e5766-131">Parameter</span></span>        | <span data-ttu-id="e5766-132">型</span><span class="sxs-lookup"><span data-stu-id="e5766-132">Type</span></span>   |  <span data-ttu-id="e5766-133">説明</span><span class="sxs-lookup"><span data-stu-id="e5766-133">Description</span></span>      |  <span data-ttu-id="e5766-134">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="e5766-134">Required</span></span>  |
|---------------|--------|---------------|------|
| <span data-ttu-id="e5766-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="e5766-135">applicationId</span></span> | <span data-ttu-id="e5766-136">string</span><span class="sxs-lookup"><span data-stu-id="e5766-136">string</span></span> | <span data-ttu-id="e5766-137">スタック トレースを取得するデスクトップ アプリケーションの製品 ID です。</span><span class="sxs-lookup"><span data-stu-id="e5766-137">The product ID of the desktop application for which you want to get a stack trace.</span></span> <span data-ttu-id="e5766-138">デスクトップ アプリケーションの製品 ID を取得するには、(などの**正常性レポート**で) すべての[パートナー センターで、デスクトップ アプリケーションの分析レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)を開き、URL から製品 ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="e5766-138">To get the product ID of a desktop application, open any [analytics report for your desktop application in Partner Center](https://msdn.microsoft.com/library/windows/desktop/mt826504) (such as the **Health report**) and retrieve the product ID from the URL.</span></span> |  <span data-ttu-id="e5766-139">はい</span><span class="sxs-lookup"><span data-stu-id="e5766-139">Yes</span></span>  |
| <span data-ttu-id="e5766-140">cabIdHash</span><span class="sxs-lookup"><span data-stu-id="e5766-140">cabIdHash</span></span> | <span data-ttu-id="e5766-141">string</span><span class="sxs-lookup"><span data-stu-id="e5766-141">string</span></span> | <span data-ttu-id="e5766-142">スタック トレースを取得するエラーに関連付けられた CAB ファイルの一意の ID ハッシュです。</span><span class="sxs-lookup"><span data-stu-id="e5766-142">The unique ID hash of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span> <span data-ttu-id="e5766-143">この値を取得するには、「[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)」のメソッドを使ってアプリケーションの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文に含まれる **cabIdHash** 値を使用します。</span><span class="sxs-lookup"><span data-stu-id="e5766-143">To get this value, use the [get details for an error in your desktop application](get-details-for-an-error-in-your-desktop-application.md) method to retrieve details for a specific error in your application, and use the **cabIdHash** value in the response body of that method.</span></span> |  <span data-ttu-id="e5766-144">必須</span><span class="sxs-lookup"><span data-stu-id="e5766-144">Yes</span></span>  |

 
### <a name="request-example"></a><span data-ttu-id="e5766-145">要求の例</span><span class="sxs-lookup"><span data-stu-id="e5766-145">Request example</span></span>

<span data-ttu-id="e5766-146">次の例は、このメソッドを使ってスタック トレースを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e5766-146">The following example demonstrates how to get a stack trace using this method.</span></span> <span data-ttu-id="e5766-147">*applicationId* パラメーターと *cabIdHash* パラメーターは、デスクトップ アプリケーションに合わせて適切な値に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="e5766-147">Replace the *applicationId* and *cabIdHash* parameters with the appropriate values for your desktop application.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/stacktrace?applicationId=10238467886765136388&cabIdHash=54ffb83a-e159-41d2-8158-f36f306cc01e HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="e5766-148">応答</span><span class="sxs-lookup"><span data-stu-id="e5766-148">Response</span></span>


### <a name="response-body"></a><span data-ttu-id="e5766-149">応答本文</span><span class="sxs-lookup"><span data-stu-id="e5766-149">Response body</span></span>

| <span data-ttu-id="e5766-150">値</span><span class="sxs-lookup"><span data-stu-id="e5766-150">Value</span></span>      | <span data-ttu-id="e5766-151">型</span><span class="sxs-lookup"><span data-stu-id="e5766-151">Type</span></span>    | <span data-ttu-id="e5766-152">説明</span><span class="sxs-lookup"><span data-stu-id="e5766-152">Description</span></span>                  |
|------------|---------|--------------------------------|
| <span data-ttu-id="e5766-153">Value</span><span class="sxs-lookup"><span data-stu-id="e5766-153">Value</span></span>      | <span data-ttu-id="e5766-154">array</span><span class="sxs-lookup"><span data-stu-id="e5766-154">array</span></span>   | <span data-ttu-id="e5766-155">各オブジェクトにスタック トレース データの 1 つのフレームが格納されたオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="e5766-155">An array of objects that each contain one frame of stack trace data.</span></span> <span data-ttu-id="e5766-156">各オブジェクトのデータについて詳しくは、次の「[スタック トレースの値](#stack-trace-values)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e5766-156">For more information about the data in each object, see the [stack trace values](#stack-trace-values) section below.</span></span> |
| @nextLink  | <span data-ttu-id="e5766-157">string</span><span class="sxs-lookup"><span data-stu-id="e5766-157">string</span></span>  | <span data-ttu-id="e5766-158">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e5766-158">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="e5766-159">たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="e5766-159">For example, this value is returned if the **top** parameter of the request is set to 10 but there are more than 10 rows of errors for the query.</span></span> |
| <span data-ttu-id="e5766-160">TotalCount</span><span class="sxs-lookup"><span data-stu-id="e5766-160">TotalCount</span></span> | <span data-ttu-id="e5766-161">整数</span><span class="sxs-lookup"><span data-stu-id="e5766-161">integer</span></span> | <span data-ttu-id="e5766-162">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="e5766-162">The total number of rows in the data result for the query.</span></span>          |


### <a name="stack-trace-values"></a><span data-ttu-id="e5766-163">スタック トレースの値</span><span class="sxs-lookup"><span data-stu-id="e5766-163">Stack trace values</span></span>

<span data-ttu-id="e5766-164">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e5766-164">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="e5766-165">値</span><span class="sxs-lookup"><span data-stu-id="e5766-165">Value</span></span>           | <span data-ttu-id="e5766-166">型</span><span class="sxs-lookup"><span data-stu-id="e5766-166">Type</span></span>    | <span data-ttu-id="e5766-167">説明</span><span class="sxs-lookup"><span data-stu-id="e5766-167">Description</span></span>      |
|-----------------|---------|----------------|
| <span data-ttu-id="e5766-168">level</span><span class="sxs-lookup"><span data-stu-id="e5766-168">level</span></span>            | <span data-ttu-id="e5766-169">string</span><span class="sxs-lookup"><span data-stu-id="e5766-169">string</span></span>  |  <span data-ttu-id="e5766-170">コール スタックでこの要素が表すフレーム番号です。</span><span class="sxs-lookup"><span data-stu-id="e5766-170">The frame number that this element represents in the call stack.</span></span>  |
| <span data-ttu-id="e5766-171">image</span><span class="sxs-lookup"><span data-stu-id="e5766-171">image</span></span>   | <span data-ttu-id="e5766-172">string</span><span class="sxs-lookup"><span data-stu-id="e5766-172">string</span></span>  |   <span data-ttu-id="e5766-173">このスタック フレームで呼び出される関数が含まれている実行可能ファイルまたはライブラリ イメージの名前です。</span><span class="sxs-lookup"><span data-stu-id="e5766-173">The name of the executable or library image that contains the function that is called in this stack frame.</span></span>           |
| <span data-ttu-id="e5766-174">function</span><span class="sxs-lookup"><span data-stu-id="e5766-174">function</span></span> | <span data-ttu-id="e5766-175">string</span><span class="sxs-lookup"><span data-stu-id="e5766-175">string</span></span>  |  <span data-ttu-id="e5766-176">このスタック フレームで呼び出される関数の名前。</span><span class="sxs-lookup"><span data-stu-id="e5766-176">The name of the function that is called in this stack frame.</span></span> <span data-ttu-id="e5766-177">これは、アプリが実行可能ファイルまたはライブラリのシンボルを含んでいる場合のみ使用可能です。</span><span class="sxs-lookup"><span data-stu-id="e5766-177">This is available only if your app includes symbols for the executable or library.</span></span>              |
| <span data-ttu-id="e5766-178">offset</span><span class="sxs-lookup"><span data-stu-id="e5766-178">offset</span></span>     | <span data-ttu-id="e5766-179">string</span><span class="sxs-lookup"><span data-stu-id="e5766-179">string</span></span>  |  <span data-ttu-id="e5766-180">関数の先頭を基準とした現在の命令のバイト オフセットです。</span><span class="sxs-lookup"><span data-stu-id="e5766-180">The byte offset of the current instruction relative to the start of the function.</span></span>      |


### <a name="response-example"></a><span data-ttu-id="e5766-181">応答の例</span><span class="sxs-lookup"><span data-stu-id="e5766-181">Response example</span></span>

<span data-ttu-id="e5766-182">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e5766-182">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="e5766-183">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e5766-183">Related topics</span></span>

* [<span data-ttu-id="e5766-184">[正常性] レポート</span><span class="sxs-lookup"><span data-stu-id="e5766-184">Health report</span></span>](../publish/health-report.md)
* [<span data-ttu-id="e5766-185">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="e5766-185">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="e5766-186">デスクトップ アプリケーションのエラー報告データの取得</span><span class="sxs-lookup"><span data-stu-id="e5766-186">Get error reporting data for your desktop application</span></span>](get-desktop-application-error-reporting-data.md)
* [<span data-ttu-id="e5766-187">デスクトップ アプリケーションのエラーに関する詳細情報の取得</span><span class="sxs-lookup"><span data-stu-id="e5766-187">Get details for an error in your desktop application</span></span>](get-details-for-an-error-in-your-desktop-application.md)
* [<span data-ttu-id="e5766-188">デスクトップ アプリケーションのエラーの CAB ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="e5766-188">Download the CAB file for an error in your desktop application</span></span>](download-the-cab-file-for-an-error-in-your-desktop-application.md)
