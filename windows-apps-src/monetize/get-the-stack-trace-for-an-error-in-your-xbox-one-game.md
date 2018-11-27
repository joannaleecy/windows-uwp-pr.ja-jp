---
description: ゲーム、Xbox One でのエラーに関するスタック トレースを取得するのに、Microsoft Store 分析 API の以下のメソッドを使用します。
title: ゲームに Xbox One でのエラーに関するスタック トレースを取得します。
ms.date: 11/06/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, スタック トレース, エラー
ms.localizationpriority: medium
ms.openlocfilehash: fd43305c54245c3281a0e840d3df4c5c87ff7ad8
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7705331"
---
# <a name="get-the-stack-trace-for-an-error-in-your-xbox-one-game"></a><span data-ttu-id="d6d6a-104">ゲームに Xbox One でのエラーに関するスタック トレースを取得します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-104">Get the stack trace for an error in your Xbox One game</span></span>

<span data-ttu-id="d6d6a-105">Microsoft Store 分析 API ゲーム、Xbox One でのエラーに関するスタック トレースを取得する Xbox デベロッパー ポータル (XDP) を通じて取り込まれ、XDP 分析パートナー センター ダッシュ ボードで利用するには、このメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-105">Use this method in the Microsoft Store analytics API to get the stack trace for an error in your Xbox One game that was ingested through the Xbox Developer Portal (XDP) and available in the XDP Analytics Partner Center dashboard.</span></span> <span data-ttu-id="d6d6a-106">このメソッドでダウンロードできるのは、過去 30 日以内に発生したエラーに関するスタック トレースのみです。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-106">This method can only download the stack trace for an error that occurred in the last 30 days.</span></span>

<span data-ttu-id="d6d6a-107">以下のメソッドを使用する前に、まずは、スタック トレースを取得するエラーに関連付けられている CAB ファイルの ID を取得するのにことで、 [Xbox One ゲームのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-107">Before you can use this method, you must first use the [get details for an error in your Xbox One game](get-details-for-an-error-in-your-xbox-one-game.md) method to retrieve the ID of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d6d6a-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="d6d6a-108">Prerequisites</span></span>


<span data-ttu-id="d6d6a-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="d6d6a-110">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-110">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="d6d6a-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-111">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="d6d6a-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="d6d6a-113">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="d6d6a-114">スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-114">Get the ID of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span> <span data-ttu-id="d6d6a-115">この ID を取得するには、[ゲームの Xbox One でのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用して、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で**cabId**値を使用します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-115">To get this ID, use the [get details for an error in your Xbox One game](get-details-for-an-error-in-your-xbox-one-game.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span>

## <a name="request"></a><span data-ttu-id="d6d6a-116">要求</span><span class="sxs-lookup"><span data-stu-id="d6d6a-116">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="d6d6a-117">要求の構文</span><span class="sxs-lookup"><span data-stu-id="d6d6a-117">Request syntax</span></span>

| <span data-ttu-id="d6d6a-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="d6d6a-118">Method</span></span> | <span data-ttu-id="d6d6a-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="d6d6a-119">Request URI</span></span>                                                          |
|--------|----------------------------------------------------------------------|
| <span data-ttu-id="d6d6a-120">GET</span><span class="sxs-lookup"><span data-stu-id="d6d6a-120">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/stacktrace``` |


### <a name="request-header"></a><span data-ttu-id="d6d6a-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d6d6a-121">Request header</span></span>

| <span data-ttu-id="d6d6a-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d6d6a-122">Header</span></span>        | <span data-ttu-id="d6d6a-123">型</span><span class="sxs-lookup"><span data-stu-id="d6d6a-123">Type</span></span>   | <span data-ttu-id="d6d6a-124">説明</span><span class="sxs-lookup"><span data-stu-id="d6d6a-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d6d6a-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="d6d6a-125">Authorization</span></span> | <span data-ttu-id="d6d6a-126">string</span><span class="sxs-lookup"><span data-stu-id="d6d6a-126">string</span></span> | <span data-ttu-id="d6d6a-127">必須。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-127">Required.</span></span> <span data-ttu-id="d6d6a-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="d6d6a-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="d6d6a-129">Request parameters</span></span>

| <span data-ttu-id="d6d6a-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d6d6a-130">Parameter</span></span>        | <span data-ttu-id="d6d6a-131">型</span><span class="sxs-lookup"><span data-stu-id="d6d6a-131">Type</span></span>   |  <span data-ttu-id="d6d6a-132">説明</span><span class="sxs-lookup"><span data-stu-id="d6d6a-132">Description</span></span>      |  <span data-ttu-id="d6d6a-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="d6d6a-133">Required</span></span>  |
|---------------|--------|---------------|------|
| <span data-ttu-id="d6d6a-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="d6d6a-134">applicationId</span></span> | <span data-ttu-id="d6d6a-135">string</span><span class="sxs-lookup"><span data-stu-id="d6d6a-135">string</span></span> | <span data-ttu-id="d6d6a-136">スタック トレースを取得して、Xbox One ゲームの製品 ID です。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-136">The product ID of the Xbox One game for which you are retrieving a stack trace.</span></span> <span data-ttu-id="d6d6a-137">ゲームの製品 ID を取得するには、Xbox デベロッパー ポータル (XDP) で目的のゲームに移動し、URL から製品 ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-137">To get the product ID of your game, navigate to your game in the Xbox Developer Portal (XDP) and retrieve the product ID from the URL.</span></span> <span data-ttu-id="d6d6a-138">または、Windows パートナー センターの分析レポートから正常性データをダウンロードした場合、製品 ID は .tsv ファイルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-138">Alternatively, if you download your health data from the Windows Partner Center analytics report, the product ID is included in the .tsv file.</span></span> |  <span data-ttu-id="d6d6a-139">必須</span><span class="sxs-lookup"><span data-stu-id="d6d6a-139">Yes</span></span>  |
| <span data-ttu-id="d6d6a-140">cabId</span><span class="sxs-lookup"><span data-stu-id="d6d6a-140">cabId</span></span> | <span data-ttu-id="d6d6a-141">string</span><span class="sxs-lookup"><span data-stu-id="d6d6a-141">string</span></span> | <span data-ttu-id="d6d6a-142">スタック トレースを取得するエラーに関連付けられた CAB ファイルの一意の ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-142">The unique ID of the CAB file that is associated with the error for which you want to retrieve the stack trace.</span></span> <span data-ttu-id="d6d6a-143">この ID を取得するには、[ゲームの Xbox One でのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用して、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で**cabId**値を使用します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-143">To get this ID, use the [get details for an error in your Xbox One game](get-details-for-an-error-in-your-xbox-one-game.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span> |  <span data-ttu-id="d6d6a-144">はい</span><span class="sxs-lookup"><span data-stu-id="d6d6a-144">Yes</span></span>  |

 
### <a name="request-example"></a><span data-ttu-id="d6d6a-145">要求の例</span><span class="sxs-lookup"><span data-stu-id="d6d6a-145">Request example</span></span>

<span data-ttu-id="d6d6a-146">次の例は、以下のメソッドを使用してゲームの Xbox One のスタック トレースを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-146">The following example demonstrates how to get a stack trace for an Xbox One game using this method.</span></span> <span data-ttu-id="d6d6a-147">*ApplicationId*値をゲームの製品 ID に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-147">Replace the *applicationId* value with the product ID for your game.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/stacktrace?applicationId=BRRT4NJ9B3D1&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="d6d6a-148">応答</span><span class="sxs-lookup"><span data-stu-id="d6d6a-148">Response</span></span>


### <a name="response-body"></a><span data-ttu-id="d6d6a-149">応答本文</span><span class="sxs-lookup"><span data-stu-id="d6d6a-149">Response body</span></span>

| <span data-ttu-id="d6d6a-150">値</span><span class="sxs-lookup"><span data-stu-id="d6d6a-150">Value</span></span>      | <span data-ttu-id="d6d6a-151">型</span><span class="sxs-lookup"><span data-stu-id="d6d6a-151">Type</span></span>    | <span data-ttu-id="d6d6a-152">説明</span><span class="sxs-lookup"><span data-stu-id="d6d6a-152">Description</span></span>                  |
|------------|---------|--------------------------------|
| <span data-ttu-id="d6d6a-153">Value</span><span class="sxs-lookup"><span data-stu-id="d6d6a-153">Value</span></span>      | <span data-ttu-id="d6d6a-154">array</span><span class="sxs-lookup"><span data-stu-id="d6d6a-154">array</span></span>   | <span data-ttu-id="d6d6a-155">各オブジェクトにスタック トレース データの 1 つのフレームが格納されたオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-155">An array of objects that each contain one frame of stack trace data.</span></span> <span data-ttu-id="d6d6a-156">各オブジェクトのデータについて詳しくは、次の「[スタック トレースの値](#stack-trace-values)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-156">For more information about the data in each object, see the [stack trace values](#stack-trace-values) section below.</span></span> |
| @nextLink  | <span data-ttu-id="d6d6a-157">string</span><span class="sxs-lookup"><span data-stu-id="d6d6a-157">string</span></span>  | <span data-ttu-id="d6d6a-158">データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-158">If there are additional pages of data, this string contains a URI that you can use to request the next page of data.</span></span> <span data-ttu-id="d6d6a-159">たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-159">For example, this value is returned if the **top** parameter of the request is set to 10 but there are more than 10 rows of errors for the query.</span></span> |
| <span data-ttu-id="d6d6a-160">TotalCount</span><span class="sxs-lookup"><span data-stu-id="d6d6a-160">TotalCount</span></span> | <span data-ttu-id="d6d6a-161">整数</span><span class="sxs-lookup"><span data-stu-id="d6d6a-161">integer</span></span> | <span data-ttu-id="d6d6a-162">クエリの結果データ内の行の総数です。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-162">The total number of rows in the data result for the query.</span></span>          |


### <a name="stack-trace-values"></a><span data-ttu-id="d6d6a-163">スタック トレースの値</span><span class="sxs-lookup"><span data-stu-id="d6d6a-163">Stack trace values</span></span>

<span data-ttu-id="d6d6a-164">*Value* 配列の要素には、次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-164">Elements in the *Value* array contain the following values.</span></span>

| <span data-ttu-id="d6d6a-165">値</span><span class="sxs-lookup"><span data-stu-id="d6d6a-165">Value</span></span>           | <span data-ttu-id="d6d6a-166">型</span><span class="sxs-lookup"><span data-stu-id="d6d6a-166">Type</span></span>    | <span data-ttu-id="d6d6a-167">説明</span><span class="sxs-lookup"><span data-stu-id="d6d6a-167">Description</span></span>      |
|-----------------|---------|----------------|
| <span data-ttu-id="d6d6a-168">level</span><span class="sxs-lookup"><span data-stu-id="d6d6a-168">level</span></span>            | <span data-ttu-id="d6d6a-169">string</span><span class="sxs-lookup"><span data-stu-id="d6d6a-169">string</span></span>  |  <span data-ttu-id="d6d6a-170">コール スタックでこの要素が表すフレーム番号です。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-170">The frame number that this element represents in the call stack.</span></span>  |
| <span data-ttu-id="d6d6a-171">image</span><span class="sxs-lookup"><span data-stu-id="d6d6a-171">image</span></span>   | <span data-ttu-id="d6d6a-172">string</span><span class="sxs-lookup"><span data-stu-id="d6d6a-172">string</span></span>  |   <span data-ttu-id="d6d6a-173">このスタック フレームで呼び出される関数が含まれている実行可能ファイルまたはライブラリ イメージの名前です。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-173">The name of the executable or library image that contains the function that is called in this stack frame.</span></span>           |
| <span data-ttu-id="d6d6a-174">function</span><span class="sxs-lookup"><span data-stu-id="d6d6a-174">function</span></span> | <span data-ttu-id="d6d6a-175">string</span><span class="sxs-lookup"><span data-stu-id="d6d6a-175">string</span></span>  |  <span data-ttu-id="d6d6a-176">このスタック フレームで呼び出される関数の名前。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-176">The name of the function that is called in this stack frame.</span></span> <span data-ttu-id="d6d6a-177">これは、ゲームには、実行可能ファイルまたはライブラリのシンボルが含まれている場合のみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-177">This is available only if your game includes symbols for the executable or library.</span></span>              |
| <span data-ttu-id="d6d6a-178">offset</span><span class="sxs-lookup"><span data-stu-id="d6d6a-178">offset</span></span>     | <span data-ttu-id="d6d6a-179">string</span><span class="sxs-lookup"><span data-stu-id="d6d6a-179">string</span></span>  |  <span data-ttu-id="d6d6a-180">関数の先頭を基準とした現在の命令のバイト オフセットです。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-180">The byte offset of the current instruction relative to the start of the function.</span></span>      |


### <a name="response-example"></a><span data-ttu-id="d6d6a-181">応答の例</span><span class="sxs-lookup"><span data-stu-id="d6d6a-181">Response example</span></span>

<span data-ttu-id="d6d6a-182">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-182">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="d6d6a-183">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d6d6a-183">Related topics</span></span>

* [<span data-ttu-id="d6d6a-184">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="d6d6a-184">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="d6d6a-185">ゲームの Xbox One に関するエラー報告データを取得します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-185">Get error reporting data for your Xbox One game</span></span>](get-error-reporting-data-for-your-xbox-one-game.md)
* [<span data-ttu-id="d6d6a-186">ゲームの Xbox One のエラーに関する詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-186">Get details for an error in your Xbox One game</span></span>](get-details-for-an-error-in-your-xbox-one-game.md)
* [<span data-ttu-id="d6d6a-187">Xbox One ゲームのエラーに関する CAB ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="d6d6a-187">Download the CAB file for an error in your Xbox One game</span></span>](download-the-cab-file-for-an-error-in-your-xbox-one-game.md)
