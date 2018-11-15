---
author: Xansky
ms.assetid: C78176D6-47BB-4C63-92F8-426719A70F04
description: パッケージ フライトの申請の状態を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの申請の状態の取得
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請, 状態
ms.localizationpriority: medium
ms.openlocfilehash: 4378df5333e29dfe570ff50efd37b0361b9a6ca9
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6667151"
---
# <a name="get-the-status-of-a-package-flight-submission"></a><span data-ttu-id="afc05-104">パッケージ フライトの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="afc05-104">Get the status of a package flight submission</span></span>

<span data-ttu-id="afc05-105">パッケージ フライトの申請の状態を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="afc05-105">Use this method in the Microsoft Store submission API to get the status of a package flight submission.</span></span> <span data-ttu-id="afc05-106">Microsoft Store 申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="afc05-106">For more information about the process of process of creating a package flight submission by using the Microsoft Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="afc05-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="afc05-107">Prerequisites</span></span>

<span data-ttu-id="afc05-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="afc05-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="afc05-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="afc05-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="afc05-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="afc05-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="afc05-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="afc05-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="afc05-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="afc05-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="afc05-113">アプリのいずれかのパッケージ フライトの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="afc05-113">Create a package flight submission for one of your apps.</span></span> <span data-ttu-id="afc05-114">パートナー センターで、これを行うか、[パッケージ フライトの申請を作成する](create-a-flight-submission.md)方法を使用して、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="afc05-114">You can do this in Partner Center, or you can do this by using the [create a package flight submission](create-a-flight-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="afc05-115">要求</span><span class="sxs-lookup"><span data-stu-id="afc05-115">Request</span></span>

<span data-ttu-id="afc05-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="afc05-116">This method has the following syntax.</span></span> <span data-ttu-id="afc05-117">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="afc05-117">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="afc05-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="afc05-118">Method</span></span> | <span data-ttu-id="afc05-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="afc05-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="afc05-120">GET</span><span class="sxs-lookup"><span data-stu-id="afc05-120">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status``` |


### <a name="request-header"></a><span data-ttu-id="afc05-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="afc05-121">Request header</span></span>

| <span data-ttu-id="afc05-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="afc05-122">Header</span></span>        | <span data-ttu-id="afc05-123">型</span><span class="sxs-lookup"><span data-stu-id="afc05-123">Type</span></span>   | <span data-ttu-id="afc05-124">説明</span><span class="sxs-lookup"><span data-stu-id="afc05-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="afc05-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="afc05-125">Authorization</span></span> | <span data-ttu-id="afc05-126">string</span><span class="sxs-lookup"><span data-stu-id="afc05-126">string</span></span> | <span data-ttu-id="afc05-127">必須。</span><span class="sxs-lookup"><span data-stu-id="afc05-127">Required.</span></span> <span data-ttu-id="afc05-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="afc05-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="afc05-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="afc05-129">Request parameters</span></span>

| <span data-ttu-id="afc05-130">名前</span><span class="sxs-lookup"><span data-stu-id="afc05-130">Name</span></span>        | <span data-ttu-id="afc05-131">種類</span><span class="sxs-lookup"><span data-stu-id="afc05-131">Type</span></span>   | <span data-ttu-id="afc05-132">説明</span><span class="sxs-lookup"><span data-stu-id="afc05-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="afc05-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="afc05-133">applicationId</span></span> | <span data-ttu-id="afc05-134">string</span><span class="sxs-lookup"><span data-stu-id="afc05-134">string</span></span> | <span data-ttu-id="afc05-135">必須。</span><span class="sxs-lookup"><span data-stu-id="afc05-135">Required.</span></span> <span data-ttu-id="afc05-136">状態を取得するパッケージ フライトの申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="afc05-136">The Store ID of the app that contains the package flight submission for which you want to get the status.</span></span> <span data-ttu-id="afc05-137">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="afc05-137">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="afc05-138">flightId</span><span class="sxs-lookup"><span data-stu-id="afc05-138">flightId</span></span> | <span data-ttu-id="afc05-139">string</span><span class="sxs-lookup"><span data-stu-id="afc05-139">string</span></span> | <span data-ttu-id="afc05-140">必須。</span><span class="sxs-lookup"><span data-stu-id="afc05-140">Required.</span></span> <span data-ttu-id="afc05-141">状態を取得する申請が含まれているパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="afc05-141">The ID of the package flight that contains the submission for which you want to get the status.</span></span> <span data-ttu-id="afc05-142">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="afc05-142">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="afc05-143">パートナー センターで作成されたフライト、この ID はパートナー センターでのフライト ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="afc05-143">For a flight that was created in Partner Center, this ID is also available in the URL for the flight page in Partner Center.</span></span>  |
| <span data-ttu-id="afc05-144">submissionId</span><span class="sxs-lookup"><span data-stu-id="afc05-144">submissionId</span></span> | <span data-ttu-id="afc05-145">string</span><span class="sxs-lookup"><span data-stu-id="afc05-145">string</span></span> | <span data-ttu-id="afc05-146">必須。</span><span class="sxs-lookup"><span data-stu-id="afc05-146">Required.</span></span> <span data-ttu-id="afc05-147">状態を取得する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="afc05-147">The ID of the submission for which you want to get the status.</span></span> <span data-ttu-id="afc05-148">この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="afc05-148">This ID is available in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span> <span data-ttu-id="afc05-149">パートナー センターで作成された申請はこの ID はパートナー センターでの申請ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="afc05-149">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="afc05-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="afc05-150">Request body</span></span>

<span data-ttu-id="afc05-151">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="afc05-151">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="afc05-152">要求の例</span><span class="sxs-lookup"><span data-stu-id="afc05-152">Request example</span></span>

<span data-ttu-id="afc05-153">次の例は、パッケージ フライトの申請の状態を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="afc05-153">The following example demonstrates how to get the status of a package flight submission.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649/status HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="afc05-154">応答</span><span class="sxs-lookup"><span data-stu-id="afc05-154">Response</span></span>

<span data-ttu-id="afc05-155">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="afc05-155">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="afc05-156">応答本文には、指定された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="afc05-156">The response body contains information about the specified submission.</span></span> <span data-ttu-id="afc05-157">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="afc05-157">For more details about the values in the response body, see the following section.</span></span>

```json
{
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [],
    "warnings": [],
    "certificationReports": []
  },
}
```

### <a name="response-body"></a><span data-ttu-id="afc05-158">応答本文</span><span class="sxs-lookup"><span data-stu-id="afc05-158">Response body</span></span>

| <span data-ttu-id="afc05-159">値</span><span class="sxs-lookup"><span data-stu-id="afc05-159">Value</span></span>      | <span data-ttu-id="afc05-160">型</span><span class="sxs-lookup"><span data-stu-id="afc05-160">Type</span></span>   | <span data-ttu-id="afc05-161">説明</span><span class="sxs-lookup"><span data-stu-id="afc05-161">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="afc05-162">status</span><span class="sxs-lookup"><span data-stu-id="afc05-162">status</span></span>           | <span data-ttu-id="afc05-163">string</span><span class="sxs-lookup"><span data-stu-id="afc05-163">string</span></span>  | <span data-ttu-id="afc05-164">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="afc05-164">The status of the submission.</span></span> <span data-ttu-id="afc05-165">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="afc05-165">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="afc05-166">None</span><span class="sxs-lookup"><span data-stu-id="afc05-166">None</span></span></li><li><span data-ttu-id="afc05-167">Canceled</span><span class="sxs-lookup"><span data-stu-id="afc05-167">Canceled</span></span></li><li><span data-ttu-id="afc05-168">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="afc05-168">PendingCommit</span></span></li><li><span data-ttu-id="afc05-169">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="afc05-169">CommitStarted</span></span></li><li><span data-ttu-id="afc05-170">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="afc05-170">CommitFailed</span></span></li><li><span data-ttu-id="afc05-171">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="afc05-171">PendingPublication</span></span></li><li><span data-ttu-id="afc05-172">Publishing</span><span class="sxs-lookup"><span data-stu-id="afc05-172">Publishing</span></span></li><li><span data-ttu-id="afc05-173">Published</span><span class="sxs-lookup"><span data-stu-id="afc05-173">Published</span></span></li><li><span data-ttu-id="afc05-174">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="afc05-174">PublishFailed</span></span></li><li><span data-ttu-id="afc05-175">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="afc05-175">PreProcessing</span></span></li><li><span data-ttu-id="afc05-176">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="afc05-176">PreProcessingFailed</span></span></li><li><span data-ttu-id="afc05-177">Certification</span><span class="sxs-lookup"><span data-stu-id="afc05-177">Certification</span></span></li><li><span data-ttu-id="afc05-178">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="afc05-178">CertificationFailed</span></span></li><li><span data-ttu-id="afc05-179">Release</span><span class="sxs-lookup"><span data-stu-id="afc05-179">Release</span></span></li><li><span data-ttu-id="afc05-180">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="afc05-180">ReleaseFailed</span></span></li></ul>   |
| <span data-ttu-id="afc05-181">statusDetails</span><span class="sxs-lookup"><span data-stu-id="afc05-181">statusDetails</span></span>           | <span data-ttu-id="afc05-182">object</span><span class="sxs-lookup"><span data-stu-id="afc05-182">object</span></span>  |  <span data-ttu-id="afc05-183">エラーに関する情報など、申請の状態に関する追加詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="afc05-183">Contains additional details about the status of the submission, including information about any errors.</span></span> <span data-ttu-id="afc05-184">詳しくは、[ステータスの詳細に関するリソース](manage-flight-submissions.md#status-details-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="afc05-184">For more information, see [Status details resource](manage-flight-submissions.md#status-details-object).</span></span> |


## <a name="error-codes"></a><span data-ttu-id="afc05-185">エラー コード</span><span class="sxs-lookup"><span data-stu-id="afc05-185">Error codes</span></span>

<span data-ttu-id="afc05-186">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="afc05-186">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="afc05-187">エラー コード</span><span class="sxs-lookup"><span data-stu-id="afc05-187">Error code</span></span> |  <span data-ttu-id="afc05-188">説明</span><span class="sxs-lookup"><span data-stu-id="afc05-188">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="afc05-189">404</span><span class="sxs-lookup"><span data-stu-id="afc05-189">404</span></span>  | <span data-ttu-id="afc05-190">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="afc05-190">The submission could not be found.</span></span> |
| <span data-ttu-id="afc05-191">409</span><span class="sxs-lookup"><span data-stu-id="afc05-191">409</span></span>  | <span data-ttu-id="afc05-192">アプリでは、 [Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センターの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="afc05-192">The app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="afc05-193">関連トピック</span><span class="sxs-lookup"><span data-stu-id="afc05-193">Related topics</span></span>

* [<span data-ttu-id="afc05-194">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="afc05-194">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="afc05-195">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="afc05-195">Manage package flight submissions</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="afc05-196">アプリの申請の取得</span><span class="sxs-lookup"><span data-stu-id="afc05-196">Get an app submission</span></span>](get-an-app-submission.md)
* [<span data-ttu-id="afc05-197">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="afc05-197">Create an app submission</span></span>](create-an-app-submission.md)
* [<span data-ttu-id="afc05-198">アプリの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="afc05-198">Commit an app submission</span></span>](commit-an-app-submission.md)
* [<span data-ttu-id="afc05-199">アプリの申請の更新</span><span class="sxs-lookup"><span data-stu-id="afc05-199">Update an app submission</span></span>](update-an-app-submission.md)
* [<span data-ttu-id="afc05-200">アプリの申請の削除</span><span class="sxs-lookup"><span data-stu-id="afc05-200">Delete an app submission</span></span>](delete-an-app-submission.md)
