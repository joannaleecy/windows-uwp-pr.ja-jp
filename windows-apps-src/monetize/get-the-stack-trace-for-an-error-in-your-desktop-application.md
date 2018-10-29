---
author: Xansky
description: デスクトップ アプリケーションのエラーに関するスタック トレースを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: デスクトップ アプリケーションのエラーに関するスタック トレースの取得
ms.author: mhopkins
ms.date: 06/05/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, スタック トレース, エラー, デスクトップ アプリケーション
ms.localizationpriority: medium
ms.openlocfilehash: b9b26f36d7fe2dc553e211ae48f7bd66651c5827
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5740594"
---
# <a name="get-the-stack-trace-for-an-error-in-your-desktop-application"></a><span data-ttu-id="3ab9a-104">デスクトップ アプリケーションのエラーに関するスタック トレースの取得</span><span class="sxs-lookup"><span data-stu-id="3ab9a-104">Get the stack trace for an error in your desktop application</span></span>

<span data-ttu-id="3ab9a-105">[Windows デスクトップ アプリケーション プログラム](https://msdn.microsoft.com/library/windows/desktop/mt826504)に追加したデスクトップ アプリケーションのエラーに関するスタック トレースを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-105">Use this method in the Microsoft Store analytics API to get the stack trace for an error in a desktop application that you have added to the [Windows Desktop Application program](https://msdn.microsoft.com/library/windows/desktop/mt826504).</span></span> <span data-ttu-id="3ab9a-106">このメソッドでダウンロードできるのは、過去 30 日以内に発生したエラーに関するスタック トレースのみです。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-106">This method can only download the stack trace for an error that occurred in the last 30 days.</span></span> <span data-ttu-id="3ab9a-107">スタック トレースは、Windows デベロッパー センター ダッシュボードにあるデスクトップ アプリケーションの[正常性レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)でも確認できます。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-107">Stack traces are also available in the [Health report](https://msdn.microsoft.com/library/windows/desktop/mt826504) for desktop applications in the Windows Dev Center dashboard.</span></span>

<span data-ttu-id="3ab9a-108">このメソッドを使うには、その前にまず「[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)」のメソッドを使って、スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID ハッシュを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-108">Before you can use this method, you must first use the [get details for an error in your desktop application](get-details-for-an-error-in-your-desktop-application.md) method to retrieve the ID hash of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="3ab9a-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="3ab9a-109">Prerequisites</span></span>


<span data-ttu-id="3ab9a-110">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-110">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="3ab9a-111">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-111">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="3ab9a-112">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-112">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="3ab9a-113">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-113">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="3ab9a-114">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-114">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="3ab9a-115">スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID ハッシュを取得します。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-115">Get the ID hash of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span> <span data-ttu-id="3ab9a-116">この値を取得するには、「[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)」のメソッドを使ってアプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文に含まれる **cabIdHash** 値を使用します。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-116">To get this value, use the [get details for an error in your desktop application](get-details-for-an-error-in-your-desktop-application.md) method to retrieve details for a specific error in your app, and use the **cabIdHash** value in the response body of that method.</span></span>

## <a name="request"></a><span data-ttu-id="3ab9a-117">要求</span><span class="sxs-lookup"><span data-stu-id="3ab9a-117">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="3ab9a-118">要求の構文</span><span class="sxs-lookup"><span data-stu-id="3ab9a-118">Request syntax</span></span>

| <span data-ttu-id="3ab9a-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="3ab9a-119">Method</span></span> | <span data-ttu-id="3ab9a-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="3ab9a-120">Request URI</span></span>                                                          |
|--------|----------------------------------------------------------------------|
| <span data-ttu-id="3ab9a-121">GET</span><span class="sxs-lookup"><span data-stu-id="3ab9a-121">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/stacktrace``` |


### <a name="request-header"></a><span data-ttu-id="3ab9a-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ab9a-122">Request header</span></span>

| <span data-ttu-id="3ab9a-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ab9a-123">Header</span></span>        | <span data-ttu-id="3ab9a-124">型</span><span class="sxs-lookup"><span data-stu-id="3ab9a-124">Type</span></span>   | <span data-ttu-id="3ab9a-125">説明</span><span class="sxs-lookup"><span data-stu-id="3ab9a-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3ab9a-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="3ab9a-126">Authorization</span></span> | <span data-ttu-id="3ab9a-127">string</span><span class="sxs-lookup"><span data-stu-id="3ab9a-127">string</span></span> | <span data-ttu-id="3ab9a-128">必須。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-128">Required.</span></span> <span data-ttu-id="3ab9a-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |
 

### <a name="request-parameters"></a><span data-ttu-id="3ab9a-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ab9a-130">Request parameters</span></span>

| <span data-ttu-id="3ab9a-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ab9a-131">Parameter</span></span>        | <span data-ttu-id="3ab9a-132">型</span><span class="sxs-lookup"><span data-stu-id="3ab9a-132">Type</span></span>   |  <span data-ttu-id="3ab9a-133">説明</span><span class="sxs-lookup"><span data-stu-id="3ab9a-133">Description</span></span>      |  <span data-ttu-id="3ab9a-134">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="3ab9a-134">Required</span></span>  |
|---------------|--------|---------------|------|
| <span data-ttu-id="3ab9a-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="3ab9a-135">applicationId</span></span> | <span data-ttu-id="3ab9a-136">string</span><span class="sxs-lookup"><span data-stu-id="3ab9a-136">string</span></span> | <span data-ttu-id="3ab9a-137">スタック トレースを取得するデスクトップ アプリケーションの製品 ID です。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-137">The product ID of the desktop application for which you want to get a stack trace.</span></span> <span data-ttu-id="3ab9a-138">デスクトップ アプリケーションの製品 ID を取得するには、[デベロッパー センターでデスクトップ アプリケーションの分析レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)のいずれか (**正常性レポート**など) を開き、URL から製品 ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-138">To get the product ID of a desktop application, open any [Dev Center analytics report for your desktop application](https://msdn.microsoft.com/library/windows/desktop/mt826504) (such as the **Health report**) and retrieve the product ID from the URL.</span></span> |  <span data-ttu-id="3ab9a-139">必須</span><span class="sxs-lookup"><span data-stu-id="3ab9a-139">Yes</span></span>  |
| <span data-ttu-id="3ab9a-140">cabIdHash</span><span class="sxs-lookup"><span data-stu-id="3ab9a-140">cabIdHash</span></span> | <span data-ttu-id="3ab9a-141">string</span><span class="sxs-lookup"><span data-stu-id="3ab9a-141">string</span></span> | <span data-ttu-id="3ab9a-142">スタック トレースを取得するエラーに関連付けられた CAB ファイルの一意の ID ハッシュです。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-142">The unique ID hash of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span> <span data-ttu-id="3ab9a-143">この値を取得するには、「[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)」のメソッドを使ってアプリケーションの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文に含まれる **cabIdHash** 値を使用します。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-143">To get this value, use the [get details for an error in your desktop application](get-details-for-an-error-in-your-desktop-application.md) method to retrieve details for a specific error in your application, and use the **cabIdHash** value in the response body of that method.</span></span> |  <span data-ttu-id="3ab9a-144">必須</span><span class="sxs-lookup"><span data-stu-id="3ab9a-144">Yes</span></span>  |

 
### <a name="request-example"></a><span data-ttu-id="3ab9a-145">要求の例</span><span class="sxs-lookup"><span data-stu-id="3ab9a-145">Request example</span></span>

<span data-ttu-id="3ab9a-146">次の例は、このメソッドを使ってスタック トレースを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-146">The following example demonstrates how to get a stack trace using this method.</span></span> <span data-ttu-id="3ab9a-147">*applicationId* パラメーターと *cabIdHash* パラメーターは、デスクトップ アプリケーションに合わせて適切な値に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-147">Replace the *applicationId* and *cabIdHash* parameters with the appropriate values for your desktop application.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/stacktrace?applicationId=10238467886765136388&cabIdHash=54ffb83a-e159-41d2-8158-f36f306cc01e HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="3ab9a-148">応答</span><span class="sxs-lookup"><span data-stu-id="3ab9a-148">Response</span></span>


### <a name="response-body"></a><span data-ttu-id="3ab9a-149">応答本文</span><span class="sxs-lookup"><span data-stu-id="3ab9a-149">Response body</span></span>

| <span data-ttu-id="3ab9a-150">値</span><span class="sxs-lookup"><span data-stu-id="3ab9a-150">Value</span></span>      | <span data-ttu-id="3ab9a-151">型</span><span class="sxs-lookup"><span data-stu-id="3ab9a-151">Type</span></span>    | <span data-ttu-id="3ab9a-152">説明</span><span class="sxs-lookup"><span data-stu-id="3ab9a-152">Description</span></span>                  |
|------------|---------|--------------------------------|
| <span data-ttu-id="3ab9a-153">Value</span><span class="sxs-lookup"><span data-stu-id="3ab9a-153">Value</span></span>      | <span data-ttu-id="3ab9a-154">array</span><span class="sxs-lookup"><span data-stu-id="3ab9a-154">array</span></span>   | <span data-ttu-id="3ab9a-155">各オブジェクトにスタック トレース データの 1 つのフレームが格納されたオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-155">An array of objects that each contain one frame of stack trace data.</span></span> <span data-ttu-id="3ab9a-156">各オブジェクトのデータについて詳しくは、次の「[スタック トレースの値](#stack-trace-values)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-156">For more information about the data in each object, see the [stack trace values](#stack-trace-values) section below.</span></span> |
| @nextLink  | <span data-ttu-id="3ab9a-157">string</span><span class="sxs-lookup"><span data-stu-id="3ab9a-157">string</span></span>  | <span data-ttu-id="3ab9a-158">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-158">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="3ab9a-159">たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-159">For example, this value is returned if the **top** parameter of the request is set to 10 but there are more than 10 rows of errors for the query.</span></span> |
| <span data-ttu-id="3ab9a-160">TotalCount</span><span class="sxs-lookup"><span data-stu-id="3ab9a-160">TotalCount</span></span> | <span data-ttu-id="3ab9a-161">整数</span><span class="sxs-lookup"><span data-stu-id="3ab9a-161">integer</span></span> | <span data-ttu-id="3ab9a-162">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-162">The total number of rows in the data result for the query.</span></span>          |


### <a name="stack-trace-values"></a><span data-ttu-id="3ab9a-163">スタック トレースの値</span><span class="sxs-lookup"><span data-stu-id="3ab9a-163">Stack trace values</span></span>

<span data-ttu-id="3ab9a-164">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-164">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="3ab9a-165">値</span><span class="sxs-lookup"><span data-stu-id="3ab9a-165">Value</span></span>           | <span data-ttu-id="3ab9a-166">型</span><span class="sxs-lookup"><span data-stu-id="3ab9a-166">Type</span></span>    | <span data-ttu-id="3ab9a-167">説明</span><span class="sxs-lookup"><span data-stu-id="3ab9a-167">Description</span></span>      |
|-----------------|---------|----------------|
| <span data-ttu-id="3ab9a-168">level</span><span class="sxs-lookup"><span data-stu-id="3ab9a-168">level</span></span>            | <span data-ttu-id="3ab9a-169">string</span><span class="sxs-lookup"><span data-stu-id="3ab9a-169">string</span></span>  |  <span data-ttu-id="3ab9a-170">コール スタックでこの要素が表すフレーム番号です。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-170">The frame number that this element represents in the call stack.</span></span>  |
| <span data-ttu-id="3ab9a-171">image</span><span class="sxs-lookup"><span data-stu-id="3ab9a-171">image</span></span>   | <span data-ttu-id="3ab9a-172">string</span><span class="sxs-lookup"><span data-stu-id="3ab9a-172">string</span></span>  |   <span data-ttu-id="3ab9a-173">このスタック フレームで呼び出される関数が含まれている実行可能ファイルまたはライブラリ イメージの名前です。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-173">The name of the executable or library image that contains the function that is called in this stack frame.</span></span>           |
| <span data-ttu-id="3ab9a-174">function</span><span class="sxs-lookup"><span data-stu-id="3ab9a-174">function</span></span> | <span data-ttu-id="3ab9a-175">string</span><span class="sxs-lookup"><span data-stu-id="3ab9a-175">string</span></span>  |  <span data-ttu-id="3ab9a-176">このスタック フレームで呼び出される関数の名前。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-176">The name of the function that is called in this stack frame.</span></span> <span data-ttu-id="3ab9a-177">これは、アプリが実行可能ファイルまたはライブラリのシンボルを含んでいる場合のみ使用可能です。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-177">This is available only if your app includes symbols for the executable or library.</span></span>              |
| <span data-ttu-id="3ab9a-178">offset</span><span class="sxs-lookup"><span data-stu-id="3ab9a-178">offset</span></span>     | <span data-ttu-id="3ab9a-179">string</span><span class="sxs-lookup"><span data-stu-id="3ab9a-179">string</span></span>  |  <span data-ttu-id="3ab9a-180">関数の先頭を基準とした現在の命令のバイト オフセットです。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-180">The byte offset of the current instruction relative to the start of the function.</span></span>      |


### <a name="response-example"></a><span data-ttu-id="3ab9a-181">応答の例</span><span class="sxs-lookup"><span data-stu-id="3ab9a-181">Response example</span></span>

<span data-ttu-id="3ab9a-182">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3ab9a-182">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="3ab9a-183">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3ab9a-183">Related topics</span></span>

* [<span data-ttu-id="3ab9a-184">[正常性] レポート</span><span class="sxs-lookup"><span data-stu-id="3ab9a-184">Health report</span></span>](../publish/health-report.md)
* [<span data-ttu-id="3ab9a-185">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="3ab9a-185">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="3ab9a-186">デスクトップ アプリケーションのエラー報告データの取得</span><span class="sxs-lookup"><span data-stu-id="3ab9a-186">Get error reporting data for your desktop application</span></span>](get-desktop-application-error-reporting-data.md)
* [<span data-ttu-id="3ab9a-187">デスクトップ アプリケーションのエラーに関する詳細情報の取得</span><span class="sxs-lookup"><span data-stu-id="3ab9a-187">Get details for an error in your desktop application</span></span>](get-details-for-an-error-in-your-desktop-application.md)
* [<span data-ttu-id="3ab9a-188">デスクトップ アプリケーションのエラーの CAB ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="3ab9a-188">Download the CAB file for an error in your desktop application</span></span>](download-the-cab-file-for-an-error-in-your-desktop-application.md)
