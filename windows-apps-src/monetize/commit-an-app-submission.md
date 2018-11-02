---
author: Xansky
ms.assetid: 934F2DBF-2C7E-4B77-997D-17B9B0535D51
description: 新しいアプリの申請または更新されたアプリの申請を Windows デベロッパー センターにコミットするには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請のコミット
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリの申請のコミット
ms.localizationpriority: medium
ms.openlocfilehash: 594fb7bdbf1e56243837d2e9e3ebe1aced7eceff
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5932108"
---
# <a name="commit-an-app-submission"></a><span data-ttu-id="33eb9-104">アプリの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="33eb9-104">Commit an app submission</span></span>


<span data-ttu-id="33eb9-105">新しいアプリの申請または更新されたアプリの申請を Windows デベロッパー センターにコミットするには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="33eb9-105">Use this method in the Microsoft Store submission API to commit a new or updated app submission to Windows Dev Center.</span></span> <span data-ttu-id="33eb9-106">コミット アクションにより、申請データ (関連パッケージおよび画像を含む) がアップロードされたことがデベロッパー センターに通知されます。</span><span class="sxs-lookup"><span data-stu-id="33eb9-106">The commit action alerts Dev Center that the submission data has been uploaded (including any related packages and images).</span></span> <span data-ttu-id="33eb9-107">通知を受けたデベロッパー センターは、申請データに対する変更をインジェストと公開のためにコミットします。</span><span class="sxs-lookup"><span data-stu-id="33eb9-107">In response, Dev Center commits the changes to the submission data for ingestion and publishing.</span></span> <span data-ttu-id="33eb9-108">適切にコミットされると、申請に対する変更はデベロッパー センター ダッシュボードに表示されます。</span><span class="sxs-lookup"><span data-stu-id="33eb9-108">After the commit operation succeeds, the changes to the submission are shown in the Dev Center dashboard.</span></span>

<span data-ttu-id="33eb9-109">コミット操作が Microsoft Store 申請 API を使ったアプリ申請プロセスにどのように適合するかについては、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="33eb9-109">For more information about how the commit operation fits into the process of submitting an app by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="33eb9-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="33eb9-110">Prerequisites</span></span>

<span data-ttu-id="33eb9-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="33eb9-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="33eb9-112">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="33eb9-112">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="33eb9-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="33eb9-113">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="33eb9-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="33eb9-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="33eb9-115">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="33eb9-115">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="33eb9-116">[アプリの申請を作成](create-an-app-submission.md)し、申請データを必要に応じて変更して[申請を更新](update-an-app-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="33eb9-116">[Create an app submission](create-an-app-submission.md) and then [update the submission](update-an-app-submission.md) with any necessary changes to the submission data.</span></span>

## <a name="request"></a><span data-ttu-id="33eb9-117">要求</span><span class="sxs-lookup"><span data-stu-id="33eb9-117">Request</span></span>

<span data-ttu-id="33eb9-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="33eb9-118">This method has the following syntax.</span></span> <span data-ttu-id="33eb9-119">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="33eb9-119">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="33eb9-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="33eb9-120">Method</span></span> | <span data-ttu-id="33eb9-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="33eb9-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="33eb9-122">POST</span><span class="sxs-lookup"><span data-stu-id="33eb9-122">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/commit``` |


### <a name="request-header"></a><span data-ttu-id="33eb9-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="33eb9-123">Request header</span></span>

| <span data-ttu-id="33eb9-124">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="33eb9-124">Header</span></span>        | <span data-ttu-id="33eb9-125">型</span><span class="sxs-lookup"><span data-stu-id="33eb9-125">Type</span></span>   | <span data-ttu-id="33eb9-126">説明</span><span class="sxs-lookup"><span data-stu-id="33eb9-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="33eb9-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="33eb9-127">Authorization</span></span> | <span data-ttu-id="33eb9-128">string</span><span class="sxs-lookup"><span data-stu-id="33eb9-128">string</span></span> | <span data-ttu-id="33eb9-129">必須。</span><span class="sxs-lookup"><span data-stu-id="33eb9-129">Required.</span></span> <span data-ttu-id="33eb9-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="33eb9-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="33eb9-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="33eb9-131">Request parameters</span></span>

| <span data-ttu-id="33eb9-132">名前</span><span class="sxs-lookup"><span data-stu-id="33eb9-132">Name</span></span>        | <span data-ttu-id="33eb9-133">種類</span><span class="sxs-lookup"><span data-stu-id="33eb9-133">Type</span></span>   | <span data-ttu-id="33eb9-134">説明</span><span class="sxs-lookup"><span data-stu-id="33eb9-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="33eb9-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="33eb9-135">applicationId</span></span> | <span data-ttu-id="33eb9-136">string</span><span class="sxs-lookup"><span data-stu-id="33eb9-136">string</span></span> | <span data-ttu-id="33eb9-137">必須。</span><span class="sxs-lookup"><span data-stu-id="33eb9-137">Required.</span></span> <span data-ttu-id="33eb9-138">コミットする申請が含まれるアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="33eb9-138">The Store ID of the app that contains the submission you want to commit.</span></span> <span data-ttu-id="33eb9-139">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="33eb9-139">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="33eb9-140">submissionId</span><span class="sxs-lookup"><span data-stu-id="33eb9-140">submissionId</span></span> | <span data-ttu-id="33eb9-141">string</span><span class="sxs-lookup"><span data-stu-id="33eb9-141">string</span></span> | <span data-ttu-id="33eb9-142">必須。</span><span class="sxs-lookup"><span data-stu-id="33eb9-142">Required.</span></span> <span data-ttu-id="33eb9-143">コミットする申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="33eb9-143">The ID of the submission you want to commit.</span></span> <span data-ttu-id="33eb9-144">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="33eb9-144">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="33eb9-145">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="33eb9-145">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="33eb9-146">要求本文</span><span class="sxs-lookup"><span data-stu-id="33eb9-146">Request body</span></span>

<span data-ttu-id="33eb9-147">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="33eb9-147">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="33eb9-148">要求の例</span><span class="sxs-lookup"><span data-stu-id="33eb9-148">Request example</span></span>

<span data-ttu-id="33eb9-149">次の例は、アプリの申請をコミットする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="33eb9-149">The following example demonstrates how to commit an app submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243610/commit HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="33eb9-150">応答</span><span class="sxs-lookup"><span data-stu-id="33eb9-150">Response</span></span>

<span data-ttu-id="33eb9-151">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="33eb9-151">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="33eb9-152">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="33eb9-152">For more details about the values in the response body, see the following sections.</span></span>

```json
{
  "status": "CommitStarted"
}
```

### <a name="response-body"></a><span data-ttu-id="33eb9-153">応答本文</span><span class="sxs-lookup"><span data-stu-id="33eb9-153">Response body</span></span>

| <span data-ttu-id="33eb9-154">値</span><span class="sxs-lookup"><span data-stu-id="33eb9-154">Value</span></span>      | <span data-ttu-id="33eb9-155">型</span><span class="sxs-lookup"><span data-stu-id="33eb9-155">Type</span></span>   | <span data-ttu-id="33eb9-156">説明</span><span class="sxs-lookup"><span data-stu-id="33eb9-156">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="33eb9-157">status</span><span class="sxs-lookup"><span data-stu-id="33eb9-157">status</span></span>           | <span data-ttu-id="33eb9-158">string</span><span class="sxs-lookup"><span data-stu-id="33eb9-158">string</span></span>  | <span data-ttu-id="33eb9-159">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="33eb9-159">The status of the submission.</span></span> <span data-ttu-id="33eb9-160">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="33eb9-160">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="33eb9-161">None</span><span class="sxs-lookup"><span data-stu-id="33eb9-161">None</span></span></li><li><span data-ttu-id="33eb9-162">Canceled</span><span class="sxs-lookup"><span data-stu-id="33eb9-162">Canceled</span></span></li><li><span data-ttu-id="33eb9-163">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="33eb9-163">PendingCommit</span></span></li><li><span data-ttu-id="33eb9-164">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="33eb9-164">CommitStarted</span></span></li><li><span data-ttu-id="33eb9-165">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="33eb9-165">CommitFailed</span></span></li><li><span data-ttu-id="33eb9-166">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="33eb9-166">PendingPublication</span></span></li><li><span data-ttu-id="33eb9-167">Publishing</span><span class="sxs-lookup"><span data-stu-id="33eb9-167">Publishing</span></span></li><li><span data-ttu-id="33eb9-168">Published</span><span class="sxs-lookup"><span data-stu-id="33eb9-168">Published</span></span></li><li><span data-ttu-id="33eb9-169">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="33eb9-169">PublishFailed</span></span></li><li><span data-ttu-id="33eb9-170">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="33eb9-170">PreProcessing</span></span></li><li><span data-ttu-id="33eb9-171">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="33eb9-171">PreProcessingFailed</span></span></li><li><span data-ttu-id="33eb9-172">Certification</span><span class="sxs-lookup"><span data-stu-id="33eb9-172">Certification</span></span></li><li><span data-ttu-id="33eb9-173">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="33eb9-173">CertificationFailed</span></span></li><li><span data-ttu-id="33eb9-174">Release</span><span class="sxs-lookup"><span data-stu-id="33eb9-174">Release</span></span></li><li><span data-ttu-id="33eb9-175">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="33eb9-175">ReleaseFailed</span></span></li></ul>  |


## <a name="error-codes"></a><span data-ttu-id="33eb9-176">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33eb9-176">Error codes</span></span>

<span data-ttu-id="33eb9-177">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="33eb9-177">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="33eb9-178">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33eb9-178">Error code</span></span> |  <span data-ttu-id="33eb9-179">説明</span><span class="sxs-lookup"><span data-stu-id="33eb9-179">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="33eb9-180">400</span><span class="sxs-lookup"><span data-stu-id="33eb9-180">400</span></span>  | <span data-ttu-id="33eb9-181">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="33eb9-181">The request parameters are invalid.</span></span> |
| <span data-ttu-id="33eb9-182">404</span><span class="sxs-lookup"><span data-stu-id="33eb9-182">404</span></span>  | <span data-ttu-id="33eb9-183">指定した申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="33eb9-183">The specified submission could not be found.</span></span> |
| <span data-ttu-id="33eb9-184">409</span><span class="sxs-lookup"><span data-stu-id="33eb9-184">409</span></span>  | <span data-ttu-id="33eb9-185">指定した申請は見つかりましたが、現在の状態でコミットできなかったか、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。</span><span class="sxs-lookup"><span data-stu-id="33eb9-185">The specified submission was found but it could not be committed in its current state, or the app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |


## <a name="related-topics"></a><span data-ttu-id="33eb9-186">関連トピック</span><span class="sxs-lookup"><span data-stu-id="33eb9-186">Related topics</span></span>

* [<span data-ttu-id="33eb9-187">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="33eb9-187">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="33eb9-188">アプリの申請の取得</span><span class="sxs-lookup"><span data-stu-id="33eb9-188">Get an app submission</span></span>](get-an-app-submission.md)
* [<span data-ttu-id="33eb9-189">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="33eb9-189">Create an app submission</span></span>](create-an-app-submission.md)
* [<span data-ttu-id="33eb9-190">アプリの申請の更新</span><span class="sxs-lookup"><span data-stu-id="33eb9-190">Update an app submission</span></span>](update-an-app-submission.md)
* [<span data-ttu-id="33eb9-191">アプリの申請の削除</span><span class="sxs-lookup"><span data-stu-id="33eb9-191">Delete an app submission</span></span>](delete-an-app-submission.md)
* [<span data-ttu-id="33eb9-192">アプリの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="33eb9-192">Get the status of an app submission</span></span>](get-status-for-an-app-submission.md)
