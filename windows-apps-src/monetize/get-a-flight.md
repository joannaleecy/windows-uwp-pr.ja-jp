---
author: Xansky
ms.assetid: 87708690-079A-443D-807E-D2BF9F614DDF
description: パートナー センター アカウントに登録されているアプリのパッケージ フライトのデータを取得する、Microsoft Store 申請 API でこのメソッドを使います。
title: パッケージ フライトの取得
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライト, パッケージ フライト
ms.localizationpriority: medium
ms.openlocfilehash: 09fd5c703e4a601ad28a05156aec9133444cfd9e
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6979693"
---
# <a name="get-a-package-flight"></a><span data-ttu-id="9bbad-104">パッケージ フライトの取得</span><span class="sxs-lookup"><span data-stu-id="9bbad-104">Get a package flight</span></span>

<span data-ttu-id="9bbad-105">パートナー センター アカウントに登録されているアプリのパッケージ フライトのデータを取得する、Microsoft Store 申請 API でこのメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="9bbad-105">Use this method in the Microsoft Store submission API to get data for a package flight for an app that is registered to your Partner Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="9bbad-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="9bbad-106">Prerequisites</span></span>

<span data-ttu-id="9bbad-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="9bbad-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="9bbad-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="9bbad-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="9bbad-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="9bbad-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="9bbad-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="9bbad-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="9bbad-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="9bbad-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="9bbad-112">要求</span><span class="sxs-lookup"><span data-stu-id="9bbad-112">Request</span></span>

<span data-ttu-id="9bbad-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9bbad-113">This method has the following syntax.</span></span> <span data-ttu-id="9bbad-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9bbad-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="9bbad-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="9bbad-115">Method</span></span> | <span data-ttu-id="9bbad-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="9bbad-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="9bbad-117">GET</span><span class="sxs-lookup"><span data-stu-id="9bbad-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` |


### <a name="request-header"></a><span data-ttu-id="9bbad-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9bbad-118">Request header</span></span>

| <span data-ttu-id="9bbad-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9bbad-119">Header</span></span>        | <span data-ttu-id="9bbad-120">型</span><span class="sxs-lookup"><span data-stu-id="9bbad-120">Type</span></span>   | <span data-ttu-id="9bbad-121">説明</span><span class="sxs-lookup"><span data-stu-id="9bbad-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="9bbad-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="9bbad-122">Authorization</span></span> | <span data-ttu-id="9bbad-123">string</span><span class="sxs-lookup"><span data-stu-id="9bbad-123">string</span></span> | <span data-ttu-id="9bbad-124">必須。</span><span class="sxs-lookup"><span data-stu-id="9bbad-124">Required.</span></span> <span data-ttu-id="9bbad-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="9bbad-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="9bbad-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="9bbad-126">Request parameters</span></span>

| <span data-ttu-id="9bbad-127">名前</span><span class="sxs-lookup"><span data-stu-id="9bbad-127">Name</span></span>        | <span data-ttu-id="9bbad-128">種類</span><span class="sxs-lookup"><span data-stu-id="9bbad-128">Type</span></span>   | <span data-ttu-id="9bbad-129">説明</span><span class="sxs-lookup"><span data-stu-id="9bbad-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="9bbad-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="9bbad-130">applicationId</span></span> | <span data-ttu-id="9bbad-131">string</span><span class="sxs-lookup"><span data-stu-id="9bbad-131">string</span></span> | <span data-ttu-id="9bbad-132">必須。</span><span class="sxs-lookup"><span data-stu-id="9bbad-132">Required.</span></span> <span data-ttu-id="9bbad-133">取得するパッケージ フライトが含まれるアプリのストア ID。</span><span class="sxs-lookup"><span data-stu-id="9bbad-133">The Store ID of the app that contains the package flight you want to get.</span></span> <span data-ttu-id="9bbad-134">アプリのストア ID は、パートナー センターで利用できます。</span><span class="sxs-lookup"><span data-stu-id="9bbad-134">The Store ID for the app is available in Partner Center.</span></span>  |
| <span data-ttu-id="9bbad-135">flightId</span><span class="sxs-lookup"><span data-stu-id="9bbad-135">flightId</span></span> | <span data-ttu-id="9bbad-136">string</span><span class="sxs-lookup"><span data-stu-id="9bbad-136">string</span></span> | <span data-ttu-id="9bbad-137">必須。</span><span class="sxs-lookup"><span data-stu-id="9bbad-137">Required.</span></span> <span data-ttu-id="9bbad-138">取得するパッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="9bbad-138">The ID of the package flight to get.</span></span> <span data-ttu-id="9bbad-139">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="9bbad-139">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="9bbad-140">パートナー センターで作成されたフライト、この ID はパートナー センターでのフライト ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="9bbad-140">For a flight that was created in Partner Center, this ID is also available in the URL for the flight page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="9bbad-141">要求本文</span><span class="sxs-lookup"><span data-stu-id="9bbad-141">Request body</span></span>

<span data-ttu-id="9bbad-142">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="9bbad-142">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="9bbad-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="9bbad-143">Request example</span></span>

<span data-ttu-id="9bbad-144">次の例は、ストア ID 値が 9WZDNCRD91MD で、アプリの ID が 43e448df-97c9-4a43-a0bc-2a445e736bcd であるパッケージ フライトに関する情報を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="9bbad-144">The following example demonstrates how to retrieve information about a package flight with the ID 43e448df-97c9-4a43-a0bc-2a445e736bcd for an app with the Store ID value 9WZDNCRD91MD.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="9bbad-145">応答</span><span class="sxs-lookup"><span data-stu-id="9bbad-145">Response</span></span>

<span data-ttu-id="9bbad-146">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="9bbad-146">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="9bbad-147">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9bbad-147">For more details about the values in the response body, see the following sections.</span></span>

```json
{
  "flightId": "43e448df-97c9-4a43-a0bc-2a445e736bcd",
  "friendlyName": "myflight",
  "lastPublishedFlightSubmission": {
    "id": "1152921504621086517",
    "resourceLocation": "flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621086517"
  },
  "pendingFlightSubmission": {
    "id": "115292150462124364",
    "resourceLocation": "flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243647"
  },
  "groupIds": [
    "0"
  ],
  "rankHigherThan": "671c2857-725e-4faf-9e9e-ea1191ef879c"
}
```

### <a name="response-body"></a><span data-ttu-id="9bbad-148">応答本文</span><span class="sxs-lookup"><span data-stu-id="9bbad-148">Response body</span></span>

| <span data-ttu-id="9bbad-149">値</span><span class="sxs-lookup"><span data-stu-id="9bbad-149">Value</span></span>      | <span data-ttu-id="9bbad-150">型</span><span class="sxs-lookup"><span data-stu-id="9bbad-150">Type</span></span>   | <span data-ttu-id="9bbad-151">説明</span><span class="sxs-lookup"><span data-stu-id="9bbad-151">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="9bbad-152">flightId</span><span class="sxs-lookup"><span data-stu-id="9bbad-152">flightId</span></span>            | <span data-ttu-id="9bbad-153">string</span><span class="sxs-lookup"><span data-stu-id="9bbad-153">string</span></span>  | <span data-ttu-id="9bbad-154">パッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="9bbad-154">The ID for the package flight.</span></span> <span data-ttu-id="9bbad-155">この値は、パートナー センターによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="9bbad-155">This value is supplied by Partner Center.</span></span>  |
| <span data-ttu-id="9bbad-156">friendlyName</span><span class="sxs-lookup"><span data-stu-id="9bbad-156">friendlyName</span></span>           | <span data-ttu-id="9bbad-157">string</span><span class="sxs-lookup"><span data-stu-id="9bbad-157">string</span></span>  | <span data-ttu-id="9bbad-158">開発者によって指定されているパッケージ フライトの名前。</span><span class="sxs-lookup"><span data-stu-id="9bbad-158">The name of the package flight, as specified by the developer.</span></span>   |  
| <span data-ttu-id="9bbad-159">lastPublishedFlightSubmission</span><span class="sxs-lookup"><span data-stu-id="9bbad-159">lastPublishedFlightSubmission</span></span>       | <span data-ttu-id="9bbad-160">object</span><span class="sxs-lookup"><span data-stu-id="9bbad-160">object</span></span> | <span data-ttu-id="9bbad-161">パッケージ フライトの最後に公開された申請に関する情報を提供するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="9bbad-161">An object that provides information about the last published submission for the package flight.</span></span> <span data-ttu-id="9bbad-162">詳しくは、以下の「[申請オブジェクト](#submission_object)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9bbad-162">For more information, see the [Submission object](#submission_object) section below.</span></span>  |
| <span data-ttu-id="9bbad-163">pendingFlightSubmission</span><span class="sxs-lookup"><span data-stu-id="9bbad-163">pendingFlightSubmission</span></span>        | <span data-ttu-id="9bbad-164">object</span><span class="sxs-lookup"><span data-stu-id="9bbad-164">object</span></span>  |  <span data-ttu-id="9bbad-165">パッケージ フライトの現在保留中の申請に関する情報を提供するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="9bbad-165">An object that provides information about the current pending submission for the package flight.</span></span> <span data-ttu-id="9bbad-166">詳しくは、以下の「[申請オブジェクト](#submission_object)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9bbad-166">For more information, see the [Submission object](#submission_object) section below.</span></span>  |   
| <span data-ttu-id="9bbad-167">groupIds</span><span class="sxs-lookup"><span data-stu-id="9bbad-167">groupIds</span></span>           | <span data-ttu-id="9bbad-168">array</span><span class="sxs-lookup"><span data-stu-id="9bbad-168">array</span></span>  | <span data-ttu-id="9bbad-169">パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。</span><span class="sxs-lookup"><span data-stu-id="9bbad-169">An array of strings that contain the IDs of the flight groups that are associated with the package flight.</span></span> <span data-ttu-id="9bbad-170">フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9bbad-170">For more information about flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>   |
| <span data-ttu-id="9bbad-171">rankHigherThan</span><span class="sxs-lookup"><span data-stu-id="9bbad-171">rankHigherThan</span></span>           | <span data-ttu-id="9bbad-172">string</span><span class="sxs-lookup"><span data-stu-id="9bbad-172">string</span></span>  | <span data-ttu-id="9bbad-173">現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="9bbad-173">The friendly name of the package flight that is ranked immediately lower than the current package flight.</span></span> <span data-ttu-id="9bbad-174">フライト グループのランク付けについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9bbad-174">For more information about ranking flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>  |


<span id="submission_object" />

### <a name="submission-object"></a><span data-ttu-id="9bbad-175">申請オブジェクト</span><span class="sxs-lookup"><span data-stu-id="9bbad-175">Submission object</span></span>

<span data-ttu-id="9bbad-176">応答本文の *lastPublishedFlightSubmission* と *pendingFlightSubmission* の値には、パッケージ フライトの申請に関するリソース情報を提供するオブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="9bbad-176">The *lastPublishedFlightSubmission* and *pendingFlightSubmission* values in the response body contain objects that provide resource information about a submission for the package flight.</span></span> <span data-ttu-id="9bbad-177">これらのオブジェクトには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="9bbad-177">These objects have the following values.</span></span>

| <span data-ttu-id="9bbad-178">値</span><span class="sxs-lookup"><span data-stu-id="9bbad-178">Value</span></span>           | <span data-ttu-id="9bbad-179">型</span><span class="sxs-lookup"><span data-stu-id="9bbad-179">Type</span></span>    | <span data-ttu-id="9bbad-180">説明</span><span class="sxs-lookup"><span data-stu-id="9bbad-180">Description</span></span>                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="9bbad-181">id</span><span class="sxs-lookup"><span data-stu-id="9bbad-181">id</span></span>            | <span data-ttu-id="9bbad-182">string</span><span class="sxs-lookup"><span data-stu-id="9bbad-182">string</span></span>  | <span data-ttu-id="9bbad-183">申請 ID。</span><span class="sxs-lookup"><span data-stu-id="9bbad-183">The ID of the submission.</span></span>    |
| <span data-ttu-id="9bbad-184">resourceLocation</span><span class="sxs-lookup"><span data-stu-id="9bbad-184">resourceLocation</span></span>   | <span data-ttu-id="9bbad-185">string</span><span class="sxs-lookup"><span data-stu-id="9bbad-185">string</span></span>  | <span data-ttu-id="9bbad-186">申請の完全なデータを取得するために、ベースとなる ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。</span><span class="sxs-lookup"><span data-stu-id="9bbad-186">A relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to retrieve the complete data for the submission.</span></span>               |


## <a name="error-codes"></a><span data-ttu-id="9bbad-187">エラー コード</span><span class="sxs-lookup"><span data-stu-id="9bbad-187">Error codes</span></span>

<span data-ttu-id="9bbad-188">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="9bbad-188">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="9bbad-189">エラー コード</span><span class="sxs-lookup"><span data-stu-id="9bbad-189">Error code</span></span> |  <span data-ttu-id="9bbad-190">説明</span><span class="sxs-lookup"><span data-stu-id="9bbad-190">Description</span></span>     |
|--------|---------------------  |
| <span data-ttu-id="9bbad-191">400</span><span class="sxs-lookup"><span data-stu-id="9bbad-191">400</span></span>  | <span data-ttu-id="9bbad-192">要求が無効です。</span><span class="sxs-lookup"><span data-stu-id="9bbad-192">The request is invalid.</span></span> |
| <span data-ttu-id="9bbad-193">404</span><span class="sxs-lookup"><span data-stu-id="9bbad-193">404</span></span>  | <span data-ttu-id="9bbad-194">指定されたパッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="9bbad-194">The specified package flight could not be found.</span></span>   |   
| <span data-ttu-id="9bbad-195">409</span><span class="sxs-lookup"><span data-stu-id="9bbad-195">409</span></span>  | <span data-ttu-id="9bbad-196">アプリでは、 [Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センターの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="9bbad-196">The app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |                                                                                                 


## <a name="related-topics"></a><span data-ttu-id="9bbad-197">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9bbad-197">Related topics</span></span>

* [<span data-ttu-id="9bbad-198">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="9bbad-198">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="9bbad-199">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="9bbad-199">Create a package flight</span></span>](create-a-flight.md)
* [<span data-ttu-id="9bbad-200">パッケージ フライトの削除</span><span class="sxs-lookup"><span data-stu-id="9bbad-200">Delete a package flight</span></span>](delete-a-flight.md)
