---
author: Xansky
ms.assetid: F94AF8F6-0742-4A3F-938E-177472F96C00
description: 新しいパッケージ フライトの申請または更新されたパッケージ フライトの申請を Windows デベロッパー センターにコミットするには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの申請のコミット
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請のコミット
ms.localizationpriority: medium
ms.openlocfilehash: 7388e18f70cef0000d354536b0c78244f51f756d
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5941681"
---
# <a name="commit-a-package-flight-submission"></a><span data-ttu-id="3bf12-104">パッケージ フライトの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="3bf12-104">Commit a package flight submission</span></span>

<span data-ttu-id="3bf12-105">新しいパッケージ フライトの申請または更新されたパッケージ フライトの申請を Windows デベロッパー センターにコミットするには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="3bf12-105">Use this method in the Microsoft Store submission API to commit a new or updated package flight submission to Windows Dev Center.</span></span> <span data-ttu-id="3bf12-106">コミット アクションにより、申請データ (関連パッケージを含む) がアップロードされたことがデベロッパー センターに通知されます。</span><span class="sxs-lookup"><span data-stu-id="3bf12-106">The commit action alerts Dev Center that the submission data has been uploaded (including any related packages).</span></span> <span data-ttu-id="3bf12-107">通知を受けたデベロッパー センターは、申請データに対する変更をインジェストと公開のためにコミットします。</span><span class="sxs-lookup"><span data-stu-id="3bf12-107">In response, Dev Center commits the changes to the submission data for ingestion and publishing.</span></span> <span data-ttu-id="3bf12-108">適切にコミットされると、申請に対する変更はデベロッパー センター ダッシュボードに表示されます。</span><span class="sxs-lookup"><span data-stu-id="3bf12-108">After the commit operation succeeds, the changes to the submission are shown in the Dev Center dashboard.</span></span>

<span data-ttu-id="3bf12-109">コミット操作が Microsoft Store 申請 API を使ったパッケージ フライト申請の作成プロセスにどのように適合するかについては、「[パッケージ フライト申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3bf12-109">For more information about how the commit operation fits into the process of creating a package flight submission by using the Microsoft Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="3bf12-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="3bf12-110">Prerequisites</span></span>

<span data-ttu-id="3bf12-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3bf12-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="3bf12-112">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="3bf12-112">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="3bf12-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="3bf12-113">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="3bf12-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="3bf12-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="3bf12-115">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="3bf12-115">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="3bf12-116">[パッケージ フライトの申請を作成](create-a-flight-submission.md)し、申請データを必要に応じて変更して[申請を更新](update-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="3bf12-116">[Create a package flight submission](create-a-flight-submission.md) and then [update the submission](update-a-flight-submission.md) with any necessary changes to the submission data.</span></span>

## <a name="request"></a><span data-ttu-id="3bf12-117">要求</span><span class="sxs-lookup"><span data-stu-id="3bf12-117">Request</span></span>

<span data-ttu-id="3bf12-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="3bf12-118">This method has the following syntax.</span></span> <span data-ttu-id="3bf12-119">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3bf12-119">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="3bf12-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="3bf12-120">Method</span></span> | <span data-ttu-id="3bf12-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="3bf12-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="3bf12-122">POST</span><span class="sxs-lookup"><span data-stu-id="3bf12-122">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit``` |


### <a name="request-header"></a><span data-ttu-id="3bf12-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3bf12-123">Request header</span></span>

| <span data-ttu-id="3bf12-124">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3bf12-124">Header</span></span>        | <span data-ttu-id="3bf12-125">型</span><span class="sxs-lookup"><span data-stu-id="3bf12-125">Type</span></span>   | <span data-ttu-id="3bf12-126">説明</span><span class="sxs-lookup"><span data-stu-id="3bf12-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3bf12-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="3bf12-127">Authorization</span></span> | <span data-ttu-id="3bf12-128">string</span><span class="sxs-lookup"><span data-stu-id="3bf12-128">string</span></span> | <span data-ttu-id="3bf12-129">必須。</span><span class="sxs-lookup"><span data-stu-id="3bf12-129">Required.</span></span> <span data-ttu-id="3bf12-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="3bf12-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="3bf12-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="3bf12-131">Request parameters</span></span>

| <span data-ttu-id="3bf12-132">名前</span><span class="sxs-lookup"><span data-stu-id="3bf12-132">Name</span></span>        | <span data-ttu-id="3bf12-133">種類</span><span class="sxs-lookup"><span data-stu-id="3bf12-133">Type</span></span>   | <span data-ttu-id="3bf12-134">説明</span><span class="sxs-lookup"><span data-stu-id="3bf12-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3bf12-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="3bf12-135">applicationId</span></span> | <span data-ttu-id="3bf12-136">string</span><span class="sxs-lookup"><span data-stu-id="3bf12-136">string</span></span> | <span data-ttu-id="3bf12-137">必須。</span><span class="sxs-lookup"><span data-stu-id="3bf12-137">Required.</span></span> <span data-ttu-id="3bf12-138">コミットするパッケージ フライトの申請が含まれるアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="3bf12-138">The Store ID of the app that contains the package flight submission you want to commit.</span></span> <span data-ttu-id="3bf12-139">アプリのストア ID は、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="3bf12-139">The Store ID for the app is available on the Dev Center dashboard.</span></span>  |
| <span data-ttu-id="3bf12-140">flightId</span><span class="sxs-lookup"><span data-stu-id="3bf12-140">flightId</span></span> | <span data-ttu-id="3bf12-141">string</span><span class="sxs-lookup"><span data-stu-id="3bf12-141">string</span></span> | <span data-ttu-id="3bf12-142">必須。</span><span class="sxs-lookup"><span data-stu-id="3bf12-142">Required.</span></span> <span data-ttu-id="3bf12-143">コミットする申請が含まれるパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="3bf12-143">The ID of the package flight that contains the submission to commit.</span></span> <span data-ttu-id="3bf12-144">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="3bf12-144">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="3bf12-145">デベロッパー センター ダッシュボードで作成されたフライトの場合、この ID はダッシュボードのフライト ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="3bf12-145">For a flight that was created in the Dev Center dashboard, this ID is also available in the URL for the flight page in the dashboard.</span></span>  |
| <span data-ttu-id="3bf12-146">submissionId</span><span class="sxs-lookup"><span data-stu-id="3bf12-146">submissionId</span></span> | <span data-ttu-id="3bf12-147">string</span><span class="sxs-lookup"><span data-stu-id="3bf12-147">string</span></span> | <span data-ttu-id="3bf12-148">必須。</span><span class="sxs-lookup"><span data-stu-id="3bf12-148">Required.</span></span> <span data-ttu-id="3bf12-149">コミットする申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="3bf12-149">The ID of the submission to commit.</span></span> <span data-ttu-id="3bf12-150">この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="3bf12-150">This ID is available in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span> <span data-ttu-id="3bf12-151">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="3bf12-151">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="3bf12-152">要求本文</span><span class="sxs-lookup"><span data-stu-id="3bf12-152">Request body</span></span>

<span data-ttu-id="3bf12-153">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="3bf12-153">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="3bf12-154">要求の例</span><span class="sxs-lookup"><span data-stu-id="3bf12-154">Request example</span></span>

<span data-ttu-id="3bf12-155">次の例は、パッケージ フライトの申請をコミットする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3bf12-155">The following example demonstrates how to commit a package flight submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649/commit HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="3bf12-156">応答</span><span class="sxs-lookup"><span data-stu-id="3bf12-156">Response</span></span>

<span data-ttu-id="3bf12-157">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="3bf12-157">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="3bf12-158">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3bf12-158">For more details about the values in the response body, see the following sections.</span></span>

```json
{
  "status": "CommitStarted"
}
```

### <a name="response-body"></a><span data-ttu-id="3bf12-159">応答本文</span><span class="sxs-lookup"><span data-stu-id="3bf12-159">Response body</span></span>

| <span data-ttu-id="3bf12-160">値</span><span class="sxs-lookup"><span data-stu-id="3bf12-160">Value</span></span>      | <span data-ttu-id="3bf12-161">型</span><span class="sxs-lookup"><span data-stu-id="3bf12-161">Type</span></span>   | <span data-ttu-id="3bf12-162">説明</span><span class="sxs-lookup"><span data-stu-id="3bf12-162">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="3bf12-163">status</span><span class="sxs-lookup"><span data-stu-id="3bf12-163">status</span></span>           | <span data-ttu-id="3bf12-164">string</span><span class="sxs-lookup"><span data-stu-id="3bf12-164">string</span></span>  | <span data-ttu-id="3bf12-165">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="3bf12-165">The status of the submission.</span></span> <span data-ttu-id="3bf12-166">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3bf12-166">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="3bf12-167">None</span><span class="sxs-lookup"><span data-stu-id="3bf12-167">None</span></span></li><li><span data-ttu-id="3bf12-168">Canceled</span><span class="sxs-lookup"><span data-stu-id="3bf12-168">Canceled</span></span></li><li><span data-ttu-id="3bf12-169">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="3bf12-169">PendingCommit</span></span></li><li><span data-ttu-id="3bf12-170">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="3bf12-170">CommitStarted</span></span></li><li><span data-ttu-id="3bf12-171">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="3bf12-171">CommitFailed</span></span></li><li><span data-ttu-id="3bf12-172">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="3bf12-172">PendingPublication</span></span></li><li><span data-ttu-id="3bf12-173">Publishing</span><span class="sxs-lookup"><span data-stu-id="3bf12-173">Publishing</span></span></li><li><span data-ttu-id="3bf12-174">Published</span><span class="sxs-lookup"><span data-stu-id="3bf12-174">Published</span></span></li><li><span data-ttu-id="3bf12-175">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="3bf12-175">PublishFailed</span></span></li><li><span data-ttu-id="3bf12-176">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="3bf12-176">PreProcessing</span></span></li><li><span data-ttu-id="3bf12-177">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="3bf12-177">PreProcessingFailed</span></span></li><li><span data-ttu-id="3bf12-178">Certification</span><span class="sxs-lookup"><span data-stu-id="3bf12-178">Certification</span></span></li><li><span data-ttu-id="3bf12-179">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="3bf12-179">CertificationFailed</span></span></li><li><span data-ttu-id="3bf12-180">Release</span><span class="sxs-lookup"><span data-stu-id="3bf12-180">Release</span></span></li><li><span data-ttu-id="3bf12-181">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="3bf12-181">ReleaseFailed</span></span></li></ul>  |


## <a name="error-codes"></a><span data-ttu-id="3bf12-182">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3bf12-182">Error codes</span></span>

<span data-ttu-id="3bf12-183">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="3bf12-183">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="3bf12-184">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3bf12-184">Error code</span></span> |  <span data-ttu-id="3bf12-185">説明</span><span class="sxs-lookup"><span data-stu-id="3bf12-185">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="3bf12-186">400</span><span class="sxs-lookup"><span data-stu-id="3bf12-186">400</span></span>  | <span data-ttu-id="3bf12-187">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="3bf12-187">The request parameters are invalid.</span></span> |
| <span data-ttu-id="3bf12-188">404</span><span class="sxs-lookup"><span data-stu-id="3bf12-188">404</span></span>  | <span data-ttu-id="3bf12-189">指定した申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="3bf12-189">The specified submission could not be found.</span></span> |
| <span data-ttu-id="3bf12-190">409</span><span class="sxs-lookup"><span data-stu-id="3bf12-190">409</span></span>  | <span data-ttu-id="3bf12-191">指定した申請は見つかりましたが、現在の状態でコミットできなかったか、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。</span><span class="sxs-lookup"><span data-stu-id="3bf12-191">The specified submission was found but it could not be committed in its current state, or the app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |


## <a name="related-topics"></a><span data-ttu-id="3bf12-192">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3bf12-192">Related topics</span></span>

* [<span data-ttu-id="3bf12-193">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="3bf12-193">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="3bf12-194">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="3bf12-194">Manage package flight submissions</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="3bf12-195">パッケージ フライトの申請の取得</span><span class="sxs-lookup"><span data-stu-id="3bf12-195">Get a package flight submission</span></span>](get-a-flight-submission.md)
* [<span data-ttu-id="3bf12-196">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="3bf12-196">Create a package flight submission</span></span>](create-a-flight-submission.md)
* [<span data-ttu-id="3bf12-197">パッケージ フライトの申請の更新</span><span class="sxs-lookup"><span data-stu-id="3bf12-197">Update a package flight submission</span></span>](update-a-flight-submission.md)
* [<span data-ttu-id="3bf12-198">パッケージ フライトの申請の削除</span><span class="sxs-lookup"><span data-stu-id="3bf12-198">Delete a package flight submission</span></span>](delete-a-flight-submission.md)
* [<span data-ttu-id="3bf12-199">パッケージ フライトの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="3bf12-199">Get the status of a package flight submission</span></span>](get-status-for-a-flight-submission.md)
