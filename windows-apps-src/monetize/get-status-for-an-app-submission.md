---
author: Xansky
ms.assetid: 039B8810-5C9E-4DB9-A6AF-33E7401311FF
description: アプリの申請の状態を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請の状態の取得
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリの申請, 状態
ms.localizationpriority: medium
ms.openlocfilehash: f92911d431579f9408b02680abf1d49f17740903
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6050290"
---
# <a name="get-the-status-of-an-app-submission"></a><span data-ttu-id="25c3e-104">アプリの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="25c3e-104">Get the status of an app submission</span></span>

<span data-ttu-id="25c3e-105">アプリの申請の状態を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="25c3e-105">Use this method in the Microsoft Store submission API to get the status of an app submission.</span></span> <span data-ttu-id="25c3e-106">Microsoft Store 申請 API を使ったアプリの申請の作成プロセスについて詳しくは、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="25c3e-106">For more information about the process of process of creating an app submission by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="25c3e-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="25c3e-107">Prerequisites</span></span>

<span data-ttu-id="25c3e-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="25c3e-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="25c3e-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="25c3e-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="25c3e-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="25c3e-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="25c3e-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="25c3e-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="25c3e-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="25c3e-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="25c3e-113">要求</span><span class="sxs-lookup"><span data-stu-id="25c3e-113">Request</span></span>

<span data-ttu-id="25c3e-114">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="25c3e-114">This method has the following syntax.</span></span> <span data-ttu-id="25c3e-115">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="25c3e-115">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="25c3e-116">メソッド</span><span class="sxs-lookup"><span data-stu-id="25c3e-116">Method</span></span> | <span data-ttu-id="25c3e-117">要求 URI</span><span class="sxs-lookup"><span data-stu-id="25c3e-117">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="25c3e-118">GET</span><span class="sxs-lookup"><span data-stu-id="25c3e-118">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/status``` |


### <a name="request-header"></a><span data-ttu-id="25c3e-119">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25c3e-119">Request header</span></span>

| <span data-ttu-id="25c3e-120">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25c3e-120">Header</span></span>        | <span data-ttu-id="25c3e-121">型</span><span class="sxs-lookup"><span data-stu-id="25c3e-121">Type</span></span>   | <span data-ttu-id="25c3e-122">説明</span><span class="sxs-lookup"><span data-stu-id="25c3e-122">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="25c3e-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="25c3e-123">Authorization</span></span> | <span data-ttu-id="25c3e-124">string</span><span class="sxs-lookup"><span data-stu-id="25c3e-124">string</span></span> | <span data-ttu-id="25c3e-125">必須。</span><span class="sxs-lookup"><span data-stu-id="25c3e-125">Required.</span></span> <span data-ttu-id="25c3e-126">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="25c3e-126">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="25c3e-127">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="25c3e-127">Request parameters</span></span>

| <span data-ttu-id="25c3e-128">名前</span><span class="sxs-lookup"><span data-stu-id="25c3e-128">Name</span></span>        | <span data-ttu-id="25c3e-129">種類</span><span class="sxs-lookup"><span data-stu-id="25c3e-129">Type</span></span>   | <span data-ttu-id="25c3e-130">説明</span><span class="sxs-lookup"><span data-stu-id="25c3e-130">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="25c3e-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="25c3e-131">applicationId</span></span> | <span data-ttu-id="25c3e-132">string</span><span class="sxs-lookup"><span data-stu-id="25c3e-132">string</span></span> | <span data-ttu-id="25c3e-133">必須。</span><span class="sxs-lookup"><span data-stu-id="25c3e-133">Required.</span></span> <span data-ttu-id="25c3e-134">状態を取得する申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="25c3e-134">The Store ID of the app that contains the submission for which you want to get the status.</span></span> <span data-ttu-id="25c3e-135">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="25c3e-135">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="25c3e-136">submissionId</span><span class="sxs-lookup"><span data-stu-id="25c3e-136">submissionId</span></span> | <span data-ttu-id="25c3e-137">string</span><span class="sxs-lookup"><span data-stu-id="25c3e-137">string</span></span> | <span data-ttu-id="25c3e-138">必須。</span><span class="sxs-lookup"><span data-stu-id="25c3e-138">Required.</span></span> <span data-ttu-id="25c3e-139">状態を取得する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="25c3e-139">The ID of the submission for which you want to get the status.</span></span> <span data-ttu-id="25c3e-140">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="25c3e-140">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="25c3e-141">パートナー センターで作成された申請はこの ID はパートナー センターでの申請ページの URL で利用可能なも。</span><span class="sxs-lookup"><span data-stu-id="25c3e-141">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="25c3e-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="25c3e-142">Request body</span></span>

<span data-ttu-id="25c3e-143">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="25c3e-143">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="25c3e-144">要求の例</span><span class="sxs-lookup"><span data-stu-id="25c3e-144">Request example</span></span>

<span data-ttu-id="25c3e-145">次の例は、アプリの申請の状態を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="25c3e-145">The following example demonstrates how to get the status of an app submission.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243610/status HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="25c3e-146">応答</span><span class="sxs-lookup"><span data-stu-id="25c3e-146">Response</span></span>

<span data-ttu-id="25c3e-147">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="25c3e-147">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="25c3e-148">応答本文には、指定された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="25c3e-148">The response body contains information about the specified submission.</span></span> <span data-ttu-id="25c3e-149">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="25c3e-149">For more details about the values in the response body, see the following sections.</span></span>

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

### <a name="response-body"></a><span data-ttu-id="25c3e-150">応答本文</span><span class="sxs-lookup"><span data-stu-id="25c3e-150">Response body</span></span>

| <span data-ttu-id="25c3e-151">値</span><span class="sxs-lookup"><span data-stu-id="25c3e-151">Value</span></span>      | <span data-ttu-id="25c3e-152">型</span><span class="sxs-lookup"><span data-stu-id="25c3e-152">Type</span></span>   | <span data-ttu-id="25c3e-153">説明</span><span class="sxs-lookup"><span data-stu-id="25c3e-153">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="25c3e-154">status</span><span class="sxs-lookup"><span data-stu-id="25c3e-154">status</span></span>           | <span data-ttu-id="25c3e-155">string</span><span class="sxs-lookup"><span data-stu-id="25c3e-155">string</span></span>  | <span data-ttu-id="25c3e-156">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="25c3e-156">The status of the submission.</span></span> <span data-ttu-id="25c3e-157">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="25c3e-157">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="25c3e-158">None</span><span class="sxs-lookup"><span data-stu-id="25c3e-158">None</span></span></li><li><span data-ttu-id="25c3e-159">Canceled</span><span class="sxs-lookup"><span data-stu-id="25c3e-159">Canceled</span></span></li><li><span data-ttu-id="25c3e-160">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="25c3e-160">PendingCommit</span></span></li><li><span data-ttu-id="25c3e-161">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="25c3e-161">CommitStarted</span></span></li><li><span data-ttu-id="25c3e-162">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="25c3e-162">CommitFailed</span></span></li><li><span data-ttu-id="25c3e-163">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="25c3e-163">PendingPublication</span></span></li><li><span data-ttu-id="25c3e-164">Publishing</span><span class="sxs-lookup"><span data-stu-id="25c3e-164">Publishing</span></span></li><li><span data-ttu-id="25c3e-165">Published</span><span class="sxs-lookup"><span data-stu-id="25c3e-165">Published</span></span></li><li><span data-ttu-id="25c3e-166">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="25c3e-166">PublishFailed</span></span></li><li><span data-ttu-id="25c3e-167">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="25c3e-167">PreProcessing</span></span></li><li><span data-ttu-id="25c3e-168">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="25c3e-168">PreProcessingFailed</span></span></li><li><span data-ttu-id="25c3e-169">Certification</span><span class="sxs-lookup"><span data-stu-id="25c3e-169">Certification</span></span></li><li><span data-ttu-id="25c3e-170">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="25c3e-170">CertificationFailed</span></span></li><li><span data-ttu-id="25c3e-171">Release</span><span class="sxs-lookup"><span data-stu-id="25c3e-171">Release</span></span></li><li><span data-ttu-id="25c3e-172">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="25c3e-172">ReleaseFailed</span></span></li></ul>   |
| <span data-ttu-id="25c3e-173">statusDetails</span><span class="sxs-lookup"><span data-stu-id="25c3e-173">statusDetails</span></span>           | <span data-ttu-id="25c3e-174">object</span><span class="sxs-lookup"><span data-stu-id="25c3e-174">object</span></span>  |  <span data-ttu-id="25c3e-175">エラーに関する情報など、申請の状態に関する追加詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="25c3e-175">Contains additional details about the status of the submission, including information about any errors.</span></span> <span data-ttu-id="25c3e-176">詳しくは、[ステータスの詳細に関するリソース](manage-app-submissions.md#status-details-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="25c3e-176">For more information, see the [Status details resource](manage-app-submissions.md#status-details-object).</span></span> |


## <a name="error-codes"></a><span data-ttu-id="25c3e-177">エラー コード</span><span class="sxs-lookup"><span data-stu-id="25c3e-177">Error codes</span></span>

<span data-ttu-id="25c3e-178">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="25c3e-178">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="25c3e-179">エラー コード</span><span class="sxs-lookup"><span data-stu-id="25c3e-179">Error code</span></span> |  <span data-ttu-id="25c3e-180">説明</span><span class="sxs-lookup"><span data-stu-id="25c3e-180">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="25c3e-181">404</span><span class="sxs-lookup"><span data-stu-id="25c3e-181">404</span></span>  | <span data-ttu-id="25c3e-182">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="25c3e-182">The submission could not be found.</span></span> |
| <span data-ttu-id="25c3e-183">409</span><span class="sxs-lookup"><span data-stu-id="25c3e-183">409</span></span>  | <span data-ttu-id="25c3e-184">アプリでは、 [Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センターの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="25c3e-184">The app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="25c3e-185">関連トピック</span><span class="sxs-lookup"><span data-stu-id="25c3e-185">Related topics</span></span>

* [<span data-ttu-id="25c3e-186">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="25c3e-186">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="25c3e-187">アプリの申請の取得</span><span class="sxs-lookup"><span data-stu-id="25c3e-187">Get an app submission</span></span>](get-an-app-submission.md)
* [<span data-ttu-id="25c3e-188">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="25c3e-188">Create an app submission</span></span>](create-an-app-submission.md)
* [<span data-ttu-id="25c3e-189">アプリの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="25c3e-189">Commit an app submission</span></span>](commit-an-app-submission.md)
* [<span data-ttu-id="25c3e-190">アプリの申請の更新</span><span class="sxs-lookup"><span data-stu-id="25c3e-190">Update an app submission</span></span>](update-an-app-submission.md)
* [<span data-ttu-id="25c3e-191">アプリの申請の削除</span><span class="sxs-lookup"><span data-stu-id="25c3e-191">Delete an app submission</span></span>](delete-an-app-submission.md)
