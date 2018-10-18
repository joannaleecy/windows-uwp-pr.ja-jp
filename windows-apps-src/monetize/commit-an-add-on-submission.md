---
author: Xansky
ms.assetid: AC74B4FA-5554-4C03-9683-86EE48546C05
description: 新しいアドオンの申請または更新されたアドオンの申請を Windows デベロッパー センターにコミットするには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの申請のコミット
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請のコミット, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: b9d20bffe2be163db568af0b16bdfef8cd600271
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4753254"
---
# <a name="commit-an-add-on-submission"></a><span data-ttu-id="d0e98-104">アドオンの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="d0e98-104">Commit an add-on submission</span></span>

<span data-ttu-id="d0e98-105">新しいアドオンの申請または更新されたアドオンの申請を Windows デベロッパー センターにコミットするには、Microsoft Store 申請 API の以下のメソッドを使います (アドオンはアプリ内製品または IAP とも呼ばれます)。</span><span class="sxs-lookup"><span data-stu-id="d0e98-105">Use this method in the Microsoft Store submission API to commit a new or updated add-on (also known as in-app product or IAP) submission to Windows Dev Center.</span></span> <span data-ttu-id="d0e98-106">コミット アクションにより、申請データ (関連アイコンを含む) がアップロードされたことがデベロッパー センターに通知されます。</span><span class="sxs-lookup"><span data-stu-id="d0e98-106">The commit action alerts Dev Center that the submission data has been uploaded (including any related icons).</span></span> <span data-ttu-id="d0e98-107">通知を受けたデベロッパー センターは、申請データに対する変更をインジェストと公開のためにコミットします。</span><span class="sxs-lookup"><span data-stu-id="d0e98-107">In response, Dev Center commits the changes to the submission data for ingestion and publishing.</span></span> <span data-ttu-id="d0e98-108">適切にコミットされると、申請に対する変更はデベロッパー センター ダッシュボードに表示されます。</span><span class="sxs-lookup"><span data-stu-id="d0e98-108">After the commit operation succeeds, the changes to the submission are shown in the Dev Center dashboard.</span></span>

<span data-ttu-id="d0e98-109">コミット操作が Microsoft Store 申請 API を使ったアドオンの申請プロセスにどのように適合するかについては、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d0e98-109">For more information about how the commit operation fits into the process of submitting an add-on by using the Microsoft Store submission API, see [Manage add-on submissions](manage-add-on-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d0e98-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="d0e98-110">Prerequisites</span></span>

<span data-ttu-id="d0e98-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d0e98-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="d0e98-112">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="d0e98-112">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="d0e98-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="d0e98-113">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="d0e98-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="d0e98-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="d0e98-115">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d0e98-115">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="d0e98-116">[アドオンの申請を作成](create-an-add-on-submission.md)し、申請データを必要に応じて変更して[申請を更新](update-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="d0e98-116">[Create an add-on submission](create-an-add-on-submission.md) and then [update the submission](update-an-add-on-submission.md) with any necessary changes to the submission data.</span></span>

## <a name="request"></a><span data-ttu-id="d0e98-117">要求</span><span class="sxs-lookup"><span data-stu-id="d0e98-117">Request</span></span>

<span data-ttu-id="d0e98-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="d0e98-118">This method has the following syntax.</span></span> <span data-ttu-id="d0e98-119">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d0e98-119">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="d0e98-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="d0e98-120">Method</span></span> | <span data-ttu-id="d0e98-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="d0e98-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="d0e98-122">POST</span><span class="sxs-lookup"><span data-stu-id="d0e98-122">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId}/commit``` |


### <a name="request-header"></a><span data-ttu-id="d0e98-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d0e98-123">Request header</span></span>

| <span data-ttu-id="d0e98-124">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d0e98-124">Header</span></span>        | <span data-ttu-id="d0e98-125">型</span><span class="sxs-lookup"><span data-stu-id="d0e98-125">Type</span></span>   | <span data-ttu-id="d0e98-126">説明</span><span class="sxs-lookup"><span data-stu-id="d0e98-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d0e98-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="d0e98-127">Authorization</span></span> | <span data-ttu-id="d0e98-128">string</span><span class="sxs-lookup"><span data-stu-id="d0e98-128">string</span></span> | <span data-ttu-id="d0e98-129">必須。</span><span class="sxs-lookup"><span data-stu-id="d0e98-129">Required.</span></span> <span data-ttu-id="d0e98-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="d0e98-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="d0e98-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="d0e98-131">Request parameters</span></span>

| <span data-ttu-id="d0e98-132">名前</span><span class="sxs-lookup"><span data-stu-id="d0e98-132">Name</span></span>        | <span data-ttu-id="d0e98-133">種類</span><span class="sxs-lookup"><span data-stu-id="d0e98-133">Type</span></span>   | <span data-ttu-id="d0e98-134">説明</span><span class="sxs-lookup"><span data-stu-id="d0e98-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d0e98-135">inAppProductId</span><span class="sxs-lookup"><span data-stu-id="d0e98-135">inAppProductId</span></span> | <span data-ttu-id="d0e98-136">string</span><span class="sxs-lookup"><span data-stu-id="d0e98-136">string</span></span> | <span data-ttu-id="d0e98-137">必須。</span><span class="sxs-lookup"><span data-stu-id="d0e98-137">Required.</span></span> <span data-ttu-id="d0e98-138">コミットする申請が含まれるアドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="d0e98-138">The Store ID of the add-on that contains the submission you want to commit.</span></span> <span data-ttu-id="d0e98-139">ストア ID は、[すべてのアドオン取得](get-all-add-ons.md)要求と[アドオン作成](create-an-add-on.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="d0e98-139">The Store ID is available on the Dev Center dashboard, and it is included in the response data for requests to [Get all add-ons](get-all-add-ons.md) and [Create an add-on](create-an-add-on.md).</span></span> |
| <span data-ttu-id="d0e98-140">submissionId</span><span class="sxs-lookup"><span data-stu-id="d0e98-140">submissionId</span></span> | <span data-ttu-id="d0e98-141">string</span><span class="sxs-lookup"><span data-stu-id="d0e98-141">string</span></span> | <span data-ttu-id="d0e98-142">必須。</span><span class="sxs-lookup"><span data-stu-id="d0e98-142">Required.</span></span> <span data-ttu-id="d0e98-143">コミットする申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="d0e98-143">The ID of the submission you want to commit.</span></span> <span data-ttu-id="d0e98-144">この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="d0e98-144">This ID is available in the response data for requests to [create an add-on submission](create-an-add-on-submission.md).</span></span> <span data-ttu-id="d0e98-145">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="d0e98-145">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="d0e98-146">要求本文</span><span class="sxs-lookup"><span data-stu-id="d0e98-146">Request body</span></span>

<span data-ttu-id="d0e98-147">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="d0e98-147">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="d0e98-148">要求の例</span><span class="sxs-lookup"><span data-stu-id="d0e98-148">Request example</span></span>

<span data-ttu-id="d0e98-149">次の例は、アドオンの申請をコミットする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d0e98-149">The following example demonstrates how to commit an add-on submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621230023/commit HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="d0e98-150">応答</span><span class="sxs-lookup"><span data-stu-id="d0e98-150">Response</span></span>

<span data-ttu-id="d0e98-151">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="d0e98-151">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="d0e98-152">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d0e98-152">For more details about the values in the response body, see the following sections.</span></span>

```json
{
  "status": "CommitStarted"
}
```

### <a name="response-body"></a><span data-ttu-id="d0e98-153">応答本文</span><span class="sxs-lookup"><span data-stu-id="d0e98-153">Response body</span></span>

| <span data-ttu-id="d0e98-154">値</span><span class="sxs-lookup"><span data-stu-id="d0e98-154">Value</span></span>      | <span data-ttu-id="d0e98-155">型</span><span class="sxs-lookup"><span data-stu-id="d0e98-155">Type</span></span>   | <span data-ttu-id="d0e98-156">説明</span><span class="sxs-lookup"><span data-stu-id="d0e98-156">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="d0e98-157">status</span><span class="sxs-lookup"><span data-stu-id="d0e98-157">status</span></span>           | <span data-ttu-id="d0e98-158">string</span><span class="sxs-lookup"><span data-stu-id="d0e98-158">string</span></span>  | <span data-ttu-id="d0e98-159">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="d0e98-159">The status of the submission.</span></span> <span data-ttu-id="d0e98-160">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d0e98-160">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d0e98-161">None</span><span class="sxs-lookup"><span data-stu-id="d0e98-161">None</span></span></li><li><span data-ttu-id="d0e98-162">Canceled</span><span class="sxs-lookup"><span data-stu-id="d0e98-162">Canceled</span></span></li><li><span data-ttu-id="d0e98-163">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="d0e98-163">PendingCommit</span></span></li><li><span data-ttu-id="d0e98-164">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="d0e98-164">CommitStarted</span></span></li><li><span data-ttu-id="d0e98-165">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="d0e98-165">CommitFailed</span></span></li><li><span data-ttu-id="d0e98-166">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="d0e98-166">PendingPublication</span></span></li><li><span data-ttu-id="d0e98-167">Publishing</span><span class="sxs-lookup"><span data-stu-id="d0e98-167">Publishing</span></span></li><li><span data-ttu-id="d0e98-168">Published</span><span class="sxs-lookup"><span data-stu-id="d0e98-168">Published</span></span></li><li><span data-ttu-id="d0e98-169">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="d0e98-169">PublishFailed</span></span></li><li><span data-ttu-id="d0e98-170">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="d0e98-170">PreProcessing</span></span></li><li><span data-ttu-id="d0e98-171">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="d0e98-171">PreProcessingFailed</span></span></li><li><span data-ttu-id="d0e98-172">Certification</span><span class="sxs-lookup"><span data-stu-id="d0e98-172">Certification</span></span></li><li><span data-ttu-id="d0e98-173">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="d0e98-173">CertificationFailed</span></span></li><li><span data-ttu-id="d0e98-174">Release</span><span class="sxs-lookup"><span data-stu-id="d0e98-174">Release</span></span></li><li><span data-ttu-id="d0e98-175">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="d0e98-175">ReleaseFailed</span></span></li></ul>  |


## <a name="error-codes"></a><span data-ttu-id="d0e98-176">エラー コード</span><span class="sxs-lookup"><span data-stu-id="d0e98-176">Error codes</span></span>

<span data-ttu-id="d0e98-177">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="d0e98-177">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="d0e98-178">エラー コード</span><span class="sxs-lookup"><span data-stu-id="d0e98-178">Error code</span></span> |  <span data-ttu-id="d0e98-179">説明</span><span class="sxs-lookup"><span data-stu-id="d0e98-179">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="d0e98-180">400</span><span class="sxs-lookup"><span data-stu-id="d0e98-180">400</span></span>  | <span data-ttu-id="d0e98-181">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="d0e98-181">The request parameters are invalid.</span></span> |
| <span data-ttu-id="d0e98-182">404</span><span class="sxs-lookup"><span data-stu-id="d0e98-182">404</span></span>  | <span data-ttu-id="d0e98-183">指定した申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="d0e98-183">The specified submission could not be found.</span></span> |
| <span data-ttu-id="d0e98-184">409</span><span class="sxs-lookup"><span data-stu-id="d0e98-184">409</span></span>  | <span data-ttu-id="d0e98-185">指定した申請は見つかりましたが、現在の状態でコミットできなかったか、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアドオンで使用されています。</span><span class="sxs-lookup"><span data-stu-id="d0e98-185">The specified submission was found but it could not be committed in its current state, or the add-on uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |


## <a name="related-topics"></a><span data-ttu-id="d0e98-186">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d0e98-186">Related topics</span></span>

* [<span data-ttu-id="d0e98-187">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="d0e98-187">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="d0e98-188">アドオンの申請の取得</span><span class="sxs-lookup"><span data-stu-id="d0e98-188">Get an add-on submission</span></span>](get-an-add-on-submission.md)
* [<span data-ttu-id="d0e98-189">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="d0e98-189">Create an add-on submission</span></span>](create-an-add-on-submission.md)
* [<span data-ttu-id="d0e98-190">アドオンの申請の更新</span><span class="sxs-lookup"><span data-stu-id="d0e98-190">Update an add-on submission</span></span>](update-an-add-on-submission.md)
* [<span data-ttu-id="d0e98-191">アドオンの申請の削除</span><span class="sxs-lookup"><span data-stu-id="d0e98-191">Delete an add-on submission</span></span>](delete-an-add-on-submission.md)
* [<span data-ttu-id="d0e98-192">アドオンの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="d0e98-192">Get the status of an add-on submission</span></span>](get-status-for-an-add-on-submission.md)
