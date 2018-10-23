---
author: Xansky
ms.assetid: 87708690-079A-443D-807E-D2BF9F614DDF
description: Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトに関するデータを取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの取得
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライト, パッケージ フライト
ms.localizationpriority: medium
ms.openlocfilehash: 53d6117355b431fd142b8e2749dacd9a88024297
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5409018"
---
# <a name="get-a-package-flight"></a><span data-ttu-id="02df0-104">パッケージ フライトの取得</span><span class="sxs-lookup"><span data-stu-id="02df0-104">Get a package flight</span></span>

<span data-ttu-id="02df0-105">Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトに関するデータを取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="02df0-105">Use this method in the Microsoft Store submission API to get data for a package flight for an app that is registered to your Windows Dev Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="02df0-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="02df0-106">Prerequisites</span></span>

<span data-ttu-id="02df0-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="02df0-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="02df0-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="02df0-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="02df0-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="02df0-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="02df0-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="02df0-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="02df0-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="02df0-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="02df0-112">要求</span><span class="sxs-lookup"><span data-stu-id="02df0-112">Request</span></span>

<span data-ttu-id="02df0-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="02df0-113">This method has the following syntax.</span></span> <span data-ttu-id="02df0-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02df0-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="02df0-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="02df0-115">Method</span></span> | <span data-ttu-id="02df0-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="02df0-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="02df0-117">GET</span><span class="sxs-lookup"><span data-stu-id="02df0-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` |


### <a name="request-header"></a><span data-ttu-id="02df0-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="02df0-118">Request header</span></span>

| <span data-ttu-id="02df0-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="02df0-119">Header</span></span>        | <span data-ttu-id="02df0-120">型</span><span class="sxs-lookup"><span data-stu-id="02df0-120">Type</span></span>   | <span data-ttu-id="02df0-121">説明</span><span class="sxs-lookup"><span data-stu-id="02df0-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="02df0-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="02df0-122">Authorization</span></span> | <span data-ttu-id="02df0-123">string</span><span class="sxs-lookup"><span data-stu-id="02df0-123">string</span></span> | <span data-ttu-id="02df0-124">必須。</span><span class="sxs-lookup"><span data-stu-id="02df0-124">Required.</span></span> <span data-ttu-id="02df0-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="02df0-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="02df0-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="02df0-126">Request parameters</span></span>

| <span data-ttu-id="02df0-127">名前</span><span class="sxs-lookup"><span data-stu-id="02df0-127">Name</span></span>        | <span data-ttu-id="02df0-128">種類</span><span class="sxs-lookup"><span data-stu-id="02df0-128">Type</span></span>   | <span data-ttu-id="02df0-129">説明</span><span class="sxs-lookup"><span data-stu-id="02df0-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="02df0-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="02df0-130">applicationId</span></span> | <span data-ttu-id="02df0-131">string</span><span class="sxs-lookup"><span data-stu-id="02df0-131">string</span></span> | <span data-ttu-id="02df0-132">必須。</span><span class="sxs-lookup"><span data-stu-id="02df0-132">Required.</span></span> <span data-ttu-id="02df0-133">取得するパッケージ フライトが含まれるアプリのストア ID。</span><span class="sxs-lookup"><span data-stu-id="02df0-133">The Store ID of the app that contains the package flight you want to get.</span></span> <span data-ttu-id="02df0-134">アプリのストア ID は、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="02df0-134">The Store ID for the app is available on the Dev Center dashboard.</span></span>  |
| <span data-ttu-id="02df0-135">flightId</span><span class="sxs-lookup"><span data-stu-id="02df0-135">flightId</span></span> | <span data-ttu-id="02df0-136">string</span><span class="sxs-lookup"><span data-stu-id="02df0-136">string</span></span> | <span data-ttu-id="02df0-137">必須。</span><span class="sxs-lookup"><span data-stu-id="02df0-137">Required.</span></span> <span data-ttu-id="02df0-138">取得するパッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="02df0-138">The ID of the package flight to get.</span></span> <span data-ttu-id="02df0-139">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="02df0-139">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="02df0-140">デベロッパー センター ダッシュボードで作成されたフライトの場合、この ID はダッシュボードのフライト ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="02df0-140">For a flight that was created in the Dev Center dashboard, this ID is also available in the URL for the flight page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="02df0-141">要求本文</span><span class="sxs-lookup"><span data-stu-id="02df0-141">Request body</span></span>

<span data-ttu-id="02df0-142">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="02df0-142">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="02df0-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="02df0-143">Request example</span></span>

<span data-ttu-id="02df0-144">次の例は、ストア ID 値が 9WZDNCRD91MD で、アプリの ID が 43e448df-97c9-4a43-a0bc-2a445e736bcd であるパッケージ フライトに関する情報を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="02df0-144">The following example demonstrates how to retrieve information about a package flight with the ID 43e448df-97c9-4a43-a0bc-2a445e736bcd for an app with the Store ID value 9WZDNCRD91MD.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="02df0-145">応答</span><span class="sxs-lookup"><span data-stu-id="02df0-145">Response</span></span>

<span data-ttu-id="02df0-146">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="02df0-146">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="02df0-147">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02df0-147">For more details about the values in the response body, see the following sections.</span></span>

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

### <a name="response-body"></a><span data-ttu-id="02df0-148">応答本文</span><span class="sxs-lookup"><span data-stu-id="02df0-148">Response body</span></span>

| <span data-ttu-id="02df0-149">値</span><span class="sxs-lookup"><span data-stu-id="02df0-149">Value</span></span>      | <span data-ttu-id="02df0-150">型</span><span class="sxs-lookup"><span data-stu-id="02df0-150">Type</span></span>   | <span data-ttu-id="02df0-151">説明</span><span class="sxs-lookup"><span data-stu-id="02df0-151">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="02df0-152">flightId</span><span class="sxs-lookup"><span data-stu-id="02df0-152">flightId</span></span>            | <span data-ttu-id="02df0-153">string</span><span class="sxs-lookup"><span data-stu-id="02df0-153">string</span></span>  | <span data-ttu-id="02df0-154">パッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="02df0-154">The ID for the package flight.</span></span> <span data-ttu-id="02df0-155">この値は、デベロッパー センターによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="02df0-155">This value is supplied by Dev Center.</span></span>  |
| <span data-ttu-id="02df0-156">friendlyName</span><span class="sxs-lookup"><span data-stu-id="02df0-156">friendlyName</span></span>           | <span data-ttu-id="02df0-157">string</span><span class="sxs-lookup"><span data-stu-id="02df0-157">string</span></span>  | <span data-ttu-id="02df0-158">開発者によって指定されているパッケージ フライトの名前。</span><span class="sxs-lookup"><span data-stu-id="02df0-158">The name of the package flight, as specified by the developer.</span></span>   |  
| <span data-ttu-id="02df0-159">lastPublishedFlightSubmission</span><span class="sxs-lookup"><span data-stu-id="02df0-159">lastPublishedFlightSubmission</span></span>       | <span data-ttu-id="02df0-160">object</span><span class="sxs-lookup"><span data-stu-id="02df0-160">object</span></span> | <span data-ttu-id="02df0-161">パッケージ フライトの最後に公開された申請に関する情報を提供するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="02df0-161">An object that provides information about the last published submission for the package flight.</span></span> <span data-ttu-id="02df0-162">詳しくは、以下の「[申請オブジェクト](#submission_object)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02df0-162">For more information, see the [Submission object](#submission_object) section below.</span></span>  |
| <span data-ttu-id="02df0-163">pendingFlightSubmission</span><span class="sxs-lookup"><span data-stu-id="02df0-163">pendingFlightSubmission</span></span>        | <span data-ttu-id="02df0-164">object</span><span class="sxs-lookup"><span data-stu-id="02df0-164">object</span></span>  |  <span data-ttu-id="02df0-165">パッケージ フライトの現在保留中の申請に関する情報を提供するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="02df0-165">An object that provides information about the current pending submission for the package flight.</span></span> <span data-ttu-id="02df0-166">詳しくは、以下の「[申請オブジェクト](#submission_object)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02df0-166">For more information, see the [Submission object](#submission_object) section below.</span></span>  |   
| <span data-ttu-id="02df0-167">groupIds</span><span class="sxs-lookup"><span data-stu-id="02df0-167">groupIds</span></span>           | <span data-ttu-id="02df0-168">array</span><span class="sxs-lookup"><span data-stu-id="02df0-168">array</span></span>  | <span data-ttu-id="02df0-169">パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。</span><span class="sxs-lookup"><span data-stu-id="02df0-169">An array of strings that contain the IDs of the flight groups that are associated with the package flight.</span></span> <span data-ttu-id="02df0-170">フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02df0-170">For more information about flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>   |
| <span data-ttu-id="02df0-171">rankHigherThan</span><span class="sxs-lookup"><span data-stu-id="02df0-171">rankHigherThan</span></span>           | <span data-ttu-id="02df0-172">string</span><span class="sxs-lookup"><span data-stu-id="02df0-172">string</span></span>  | <span data-ttu-id="02df0-173">現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="02df0-173">The friendly name of the package flight that is ranked immediately lower than the current package flight.</span></span> <span data-ttu-id="02df0-174">フライト グループのランク付けについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02df0-174">For more information about ranking flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>  |


<span id="submission_object" />

### <a name="submission-object"></a><span data-ttu-id="02df0-175">申請オブジェクト</span><span class="sxs-lookup"><span data-stu-id="02df0-175">Submission object</span></span>

<span data-ttu-id="02df0-176">応答本文の *lastPublishedFlightSubmission* と *pendingFlightSubmission* の値には、パッケージ フライトの申請に関するリソース情報を提供するオブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="02df0-176">The *lastPublishedFlightSubmission* and *pendingFlightSubmission* values in the response body contain objects that provide resource information about a submission for the package flight.</span></span> <span data-ttu-id="02df0-177">これらのオブジェクトには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="02df0-177">These objects have the following values.</span></span>

| <span data-ttu-id="02df0-178">値</span><span class="sxs-lookup"><span data-stu-id="02df0-178">Value</span></span>           | <span data-ttu-id="02df0-179">型</span><span class="sxs-lookup"><span data-stu-id="02df0-179">Type</span></span>    | <span data-ttu-id="02df0-180">説明</span><span class="sxs-lookup"><span data-stu-id="02df0-180">Description</span></span>                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="02df0-181">id</span><span class="sxs-lookup"><span data-stu-id="02df0-181">id</span></span>            | <span data-ttu-id="02df0-182">string</span><span class="sxs-lookup"><span data-stu-id="02df0-182">string</span></span>  | <span data-ttu-id="02df0-183">申請 ID。</span><span class="sxs-lookup"><span data-stu-id="02df0-183">The ID of the submission.</span></span>    |
| <span data-ttu-id="02df0-184">resourceLocation</span><span class="sxs-lookup"><span data-stu-id="02df0-184">resourceLocation</span></span>   | <span data-ttu-id="02df0-185">string</span><span class="sxs-lookup"><span data-stu-id="02df0-185">string</span></span>  | <span data-ttu-id="02df0-186">申請の完全なデータを取得するために、ベースとなる ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。</span><span class="sxs-lookup"><span data-stu-id="02df0-186">A relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to retrieve the complete data for the submission.</span></span>               |


## <a name="error-codes"></a><span data-ttu-id="02df0-187">エラー コード</span><span class="sxs-lookup"><span data-stu-id="02df0-187">Error codes</span></span>

<span data-ttu-id="02df0-188">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="02df0-188">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="02df0-189">エラー コード</span><span class="sxs-lookup"><span data-stu-id="02df0-189">Error code</span></span> |  <span data-ttu-id="02df0-190">説明</span><span class="sxs-lookup"><span data-stu-id="02df0-190">Description</span></span>     |
|--------|---------------------  |
| <span data-ttu-id="02df0-191">400</span><span class="sxs-lookup"><span data-stu-id="02df0-191">400</span></span>  | <span data-ttu-id="02df0-192">要求が無効です。</span><span class="sxs-lookup"><span data-stu-id="02df0-192">The request is invalid.</span></span> |
| <span data-ttu-id="02df0-193">404</span><span class="sxs-lookup"><span data-stu-id="02df0-193">404</span></span>  | <span data-ttu-id="02df0-194">指定されたパッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="02df0-194">The specified package flight could not be found.</span></span>   |   
| <span data-ttu-id="02df0-195">409</span><span class="sxs-lookup"><span data-stu-id="02df0-195">409</span></span>  | <span data-ttu-id="02df0-196">アプリが、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能を使用しています。</span><span class="sxs-lookup"><span data-stu-id="02df0-196">The app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |                                                                                                 


## <a name="related-topics"></a><span data-ttu-id="02df0-197">関連トピック</span><span class="sxs-lookup"><span data-stu-id="02df0-197">Related topics</span></span>

* [<span data-ttu-id="02df0-198">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="02df0-198">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="02df0-199">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="02df0-199">Create a package flight</span></span>](create-a-flight.md)
* [<span data-ttu-id="02df0-200">パッケージ フライトの削除</span><span class="sxs-lookup"><span data-stu-id="02df0-200">Delete a package flight</span></span>](delete-a-flight.md)
