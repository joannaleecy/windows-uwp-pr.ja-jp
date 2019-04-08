---
ms.assetid: 039B8810-5C9E-4DB9-A6AF-33E7401311FF
description: アプリの申請の状態を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請の状態の取得
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリの申請, 状態
ms.localizationpriority: medium
ms.openlocfilehash: 97070136f9e1f926a275185d2b4c222513aa49d7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607807"
---
# <a name="get-the-status-of-an-app-submission"></a><span data-ttu-id="981a3-104">アプリの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="981a3-104">Get the status of an app submission</span></span>

<span data-ttu-id="981a3-105">アプリの申請の状態を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="981a3-105">Use this method in the Microsoft Store submission API to get the status of an app submission.</span></span> <span data-ttu-id="981a3-106">Microsoft Store 申請 API を使ったアプリの申請の作成プロセスについて詳しくは、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="981a3-106">For more information about the process of process of creating an app submission by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="981a3-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="981a3-107">Prerequisites</span></span>

<span data-ttu-id="981a3-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="981a3-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="981a3-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="981a3-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="981a3-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="981a3-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="981a3-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="981a3-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="981a3-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="981a3-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="981a3-113">要求</span><span class="sxs-lookup"><span data-stu-id="981a3-113">Request</span></span>

<span data-ttu-id="981a3-114">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="981a3-114">This method has the following syntax.</span></span> <span data-ttu-id="981a3-115">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="981a3-115">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="981a3-116">メソッド</span><span class="sxs-lookup"><span data-stu-id="981a3-116">Method</span></span> | <span data-ttu-id="981a3-117">要求 URI</span><span class="sxs-lookup"><span data-stu-id="981a3-117">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="981a3-118">GET</span><span class="sxs-lookup"><span data-stu-id="981a3-118">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/status``` |


### <a name="request-header"></a><span data-ttu-id="981a3-119">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="981a3-119">Request header</span></span>

| <span data-ttu-id="981a3-120">Header</span><span class="sxs-lookup"><span data-stu-id="981a3-120">Header</span></span>        | <span data-ttu-id="981a3-121">種類</span><span class="sxs-lookup"><span data-stu-id="981a3-121">Type</span></span>   | <span data-ttu-id="981a3-122">説明</span><span class="sxs-lookup"><span data-stu-id="981a3-122">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="981a3-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="981a3-123">Authorization</span></span> | <span data-ttu-id="981a3-124">string</span><span class="sxs-lookup"><span data-stu-id="981a3-124">string</span></span> | <span data-ttu-id="981a3-125">必須。</span><span class="sxs-lookup"><span data-stu-id="981a3-125">Required.</span></span> <span data-ttu-id="981a3-126">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="981a3-126">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="981a3-127">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="981a3-127">Request parameters</span></span>

| <span data-ttu-id="981a3-128">名前</span><span class="sxs-lookup"><span data-stu-id="981a3-128">Name</span></span>        | <span data-ttu-id="981a3-129">種類</span><span class="sxs-lookup"><span data-stu-id="981a3-129">Type</span></span>   | <span data-ttu-id="981a3-130">説明</span><span class="sxs-lookup"><span data-stu-id="981a3-130">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="981a3-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="981a3-131">applicationId</span></span> | <span data-ttu-id="981a3-132">string</span><span class="sxs-lookup"><span data-stu-id="981a3-132">string</span></span> | <span data-ttu-id="981a3-133">必須。</span><span class="sxs-lookup"><span data-stu-id="981a3-133">Required.</span></span> <span data-ttu-id="981a3-134">状態を取得する申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="981a3-134">The Store ID of the app that contains the submission for which you want to get the status.</span></span> <span data-ttu-id="981a3-135">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="981a3-135">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="981a3-136">submissionId</span><span class="sxs-lookup"><span data-stu-id="981a3-136">submissionId</span></span> | <span data-ttu-id="981a3-137">string</span><span class="sxs-lookup"><span data-stu-id="981a3-137">string</span></span> | <span data-ttu-id="981a3-138">必須。</span><span class="sxs-lookup"><span data-stu-id="981a3-138">Required.</span></span> <span data-ttu-id="981a3-139">状態を取得する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="981a3-139">The ID of the submission for which you want to get the status.</span></span> <span data-ttu-id="981a3-140">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="981a3-140">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="981a3-141">パートナー センターで作成された送信、この ID はパートナー センターでの送信 ページの URL で使用できるも。</span><span class="sxs-lookup"><span data-stu-id="981a3-141">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="981a3-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="981a3-142">Request body</span></span>

<span data-ttu-id="981a3-143">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="981a3-143">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="981a3-144">要求の例</span><span class="sxs-lookup"><span data-stu-id="981a3-144">Request example</span></span>

<span data-ttu-id="981a3-145">次の例は、アプリの申請の状態を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="981a3-145">The following example demonstrates how to get the status of an app submission.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243610/status HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="981a3-146">応答</span><span class="sxs-lookup"><span data-stu-id="981a3-146">Response</span></span>

<span data-ttu-id="981a3-147">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="981a3-147">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="981a3-148">応答本文には、指定された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="981a3-148">The response body contains information about the specified submission.</span></span> <span data-ttu-id="981a3-149">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="981a3-149">For more details about the values in the response body, see the following sections.</span></span>

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

### <a name="response-body"></a><span data-ttu-id="981a3-150">応答本文</span><span class="sxs-lookup"><span data-stu-id="981a3-150">Response body</span></span>

| <span data-ttu-id="981a3-151">Value</span><span class="sxs-lookup"><span data-stu-id="981a3-151">Value</span></span>      | <span data-ttu-id="981a3-152">種類</span><span class="sxs-lookup"><span data-stu-id="981a3-152">Type</span></span>   | <span data-ttu-id="981a3-153">説明</span><span class="sxs-lookup"><span data-stu-id="981a3-153">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="981a3-154">status</span><span class="sxs-lookup"><span data-stu-id="981a3-154">status</span></span>           | <span data-ttu-id="981a3-155">string</span><span class="sxs-lookup"><span data-stu-id="981a3-155">string</span></span>  | <span data-ttu-id="981a3-156">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="981a3-156">The status of the submission.</span></span> <span data-ttu-id="981a3-157">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="981a3-157">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="981a3-158">なし</span><span class="sxs-lookup"><span data-stu-id="981a3-158">None</span></span></li><li><span data-ttu-id="981a3-159">Canceled</span><span class="sxs-lookup"><span data-stu-id="981a3-159">Canceled</span></span></li><li><span data-ttu-id="981a3-160">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="981a3-160">PendingCommit</span></span></li><li><span data-ttu-id="981a3-161">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="981a3-161">CommitStarted</span></span></li><li><span data-ttu-id="981a3-162">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="981a3-162">CommitFailed</span></span></li><li><span data-ttu-id="981a3-163">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="981a3-163">PendingPublication</span></span></li><li><span data-ttu-id="981a3-164">公開</span><span class="sxs-lookup"><span data-stu-id="981a3-164">Publishing</span></span></li><li><span data-ttu-id="981a3-165">公開済み</span><span class="sxs-lookup"><span data-stu-id="981a3-165">Published</span></span></li><li><span data-ttu-id="981a3-166">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="981a3-166">PublishFailed</span></span></li><li><span data-ttu-id="981a3-167">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="981a3-167">PreProcessing</span></span></li><li><span data-ttu-id="981a3-168">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="981a3-168">PreProcessingFailed</span></span></li><li><span data-ttu-id="981a3-169">認定</span><span class="sxs-lookup"><span data-stu-id="981a3-169">Certification</span></span></li><li><span data-ttu-id="981a3-170">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="981a3-170">CertificationFailed</span></span></li><li><span data-ttu-id="981a3-171">リリース</span><span class="sxs-lookup"><span data-stu-id="981a3-171">Release</span></span></li><li><span data-ttu-id="981a3-172">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="981a3-172">ReleaseFailed</span></span></li></ul>   |
| <span data-ttu-id="981a3-173">statusDetails</span><span class="sxs-lookup"><span data-stu-id="981a3-173">statusDetails</span></span>           | <span data-ttu-id="981a3-174">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="981a3-174">object</span></span>  |  <span data-ttu-id="981a3-175">エラーに関する情報など、申請の状態に関する追加詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="981a3-175">Contains additional details about the status of the submission, including information about any errors.</span></span> <span data-ttu-id="981a3-176">詳しくは、[ステータスの詳細に関するリソース](manage-app-submissions.md#status-details-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="981a3-176">For more information, see the [Status details resource](manage-app-submissions.md#status-details-object).</span></span> |


## <a name="error-codes"></a><span data-ttu-id="981a3-177">エラー コード</span><span class="sxs-lookup"><span data-stu-id="981a3-177">Error codes</span></span>

<span data-ttu-id="981a3-178">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="981a3-178">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="981a3-179">エラー コード</span><span class="sxs-lookup"><span data-stu-id="981a3-179">Error code</span></span> |  <span data-ttu-id="981a3-180">説明</span><span class="sxs-lookup"><span data-stu-id="981a3-180">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="981a3-181">404</span><span class="sxs-lookup"><span data-stu-id="981a3-181">404</span></span>  | <span data-ttu-id="981a3-182">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="981a3-182">The submission could not be found.</span></span> |
| <span data-ttu-id="981a3-183">409</span><span class="sxs-lookup"><span data-stu-id="981a3-183">409</span></span>  | <span data-ttu-id="981a3-184">アプリはパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。</span><span class="sxs-lookup"><span data-stu-id="981a3-184">The app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="981a3-185">関連トピック</span><span class="sxs-lookup"><span data-stu-id="981a3-185">Related topics</span></span>

* [<span data-ttu-id="981a3-186">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="981a3-186">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="981a3-187">アプリの提出を取得します。</span><span class="sxs-lookup"><span data-stu-id="981a3-187">Get an app submission</span></span>](get-an-app-submission.md)
* [<span data-ttu-id="981a3-188">アプリの提出を作成します。</span><span class="sxs-lookup"><span data-stu-id="981a3-188">Create an app submission</span></span>](create-an-app-submission.md)
* [<span data-ttu-id="981a3-189">アプリの提出をコミットします。</span><span class="sxs-lookup"><span data-stu-id="981a3-189">Commit an app submission</span></span>](commit-an-app-submission.md)
* [<span data-ttu-id="981a3-190">アプリの提出を更新します。</span><span class="sxs-lookup"><span data-stu-id="981a3-190">Update an app submission</span></span>](update-an-app-submission.md)
* [<span data-ttu-id="981a3-191">アプリの提出を削除します。</span><span class="sxs-lookup"><span data-stu-id="981a3-191">Delete an app submission</span></span>](delete-an-app-submission.md)
