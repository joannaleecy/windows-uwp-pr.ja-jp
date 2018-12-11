---
ms.assetid: AC74B4FA-5554-4C03-9683-86EE48546C05
description: パートナー センターへの新規または更新されたアドオンの申請をコミットするのに、Microsoft Store 申請 API の以下のメソッドを使用します。
title: アドオンの申請のコミット
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請のコミット, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: efab4412486566ae817eb66e78f5407533a30d5b
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8872383"
---
# <a name="commit-an-add-on-submission"></a><span data-ttu-id="c3c6c-104">アドオンの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="c3c6c-104">Commit an add-on submission</span></span>

<span data-ttu-id="c3c6c-105">パートナー センターに (別名アプリ内製品または IAP) の新規または更新されたアドオンの申請をコミットするのに、Microsoft Store 申請 API の以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-105">Use this method in the Microsoft Store submission API to commit a new or updated add-on (also known as in-app product or IAP) submission to Partner Center.</span></span> <span data-ttu-id="c3c6c-106">コミット アクション パートナー センターに通知 (関連アイコンを含む)、申請データをアップロードされています。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-106">The commit action alerts Partner Center that the submission data has been uploaded (including any related icons).</span></span> <span data-ttu-id="c3c6c-107">応答には、パートナー センターは、インジェストと公開の申請のデータへの変更をコミットします。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-107">In response, Partner Center commits the changes to the submission data for ingestion and publishing.</span></span> <span data-ttu-id="c3c6c-108">コミット操作が成功した後、申請に対する変更はパートナー センターで表示されます。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-108">After the commit operation succeeds, the changes to the submission are shown in Partner Center.</span></span>

<span data-ttu-id="c3c6c-109">コミット操作が Microsoft Store 申請 API を使ったアドオンの申請プロセスにどのように適合するかについては、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-109">For more information about how the commit operation fits into the process of submitting an add-on by using the Microsoft Store submission API, see [Manage add-on submissions](manage-add-on-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="c3c6c-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="c3c6c-110">Prerequisites</span></span>

<span data-ttu-id="c3c6c-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="c3c6c-112">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-112">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="c3c6c-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-113">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="c3c6c-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="c3c6c-115">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-115">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="c3c6c-116">[アドオンの申請を作成](create-an-add-on-submission.md)し、申請データを必要に応じて変更して[申請を更新](update-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-116">[Create an add-on submission](create-an-add-on-submission.md) and then [update the submission](update-an-add-on-submission.md) with any necessary changes to the submission data.</span></span>

## <a name="request"></a><span data-ttu-id="c3c6c-117">要求</span><span class="sxs-lookup"><span data-stu-id="c3c6c-117">Request</span></span>

<span data-ttu-id="c3c6c-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-118">This method has the following syntax.</span></span> <span data-ttu-id="c3c6c-119">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-119">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="c3c6c-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="c3c6c-120">Method</span></span> | <span data-ttu-id="c3c6c-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c3c6c-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="c3c6c-122">POST</span><span class="sxs-lookup"><span data-stu-id="c3c6c-122">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId}/commit``` |


### <a name="request-header"></a><span data-ttu-id="c3c6c-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3c6c-123">Request header</span></span>

| <span data-ttu-id="c3c6c-124">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3c6c-124">Header</span></span>        | <span data-ttu-id="c3c6c-125">型</span><span class="sxs-lookup"><span data-stu-id="c3c6c-125">Type</span></span>   | <span data-ttu-id="c3c6c-126">説明</span><span class="sxs-lookup"><span data-stu-id="c3c6c-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="c3c6c-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="c3c6c-127">Authorization</span></span> | <span data-ttu-id="c3c6c-128">string</span><span class="sxs-lookup"><span data-stu-id="c3c6c-128">string</span></span> | <span data-ttu-id="c3c6c-129">必須。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-129">Required.</span></span> <span data-ttu-id="c3c6c-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="c3c6c-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="c3c6c-131">Request parameters</span></span>

| <span data-ttu-id="c3c6c-132">名前</span><span class="sxs-lookup"><span data-stu-id="c3c6c-132">Name</span></span>        | <span data-ttu-id="c3c6c-133">種類</span><span class="sxs-lookup"><span data-stu-id="c3c6c-133">Type</span></span>   | <span data-ttu-id="c3c6c-134">説明</span><span class="sxs-lookup"><span data-stu-id="c3c6c-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="c3c6c-135">inAppProductId</span><span class="sxs-lookup"><span data-stu-id="c3c6c-135">inAppProductId</span></span> | <span data-ttu-id="c3c6c-136">string</span><span class="sxs-lookup"><span data-stu-id="c3c6c-136">string</span></span> | <span data-ttu-id="c3c6c-137">必須。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-137">Required.</span></span> <span data-ttu-id="c3c6c-138">コミットする申請が含まれるアドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-138">The Store ID of the add-on that contains the submission you want to commit.</span></span> <span data-ttu-id="c3c6c-139">パートナー センターで、ストア ID は利用可能なと、[すべてのアドオンを取得](get-all-add-ons.md)し[、アドオンを作成](create-an-add-on.md)する要求の応答データに含まれています。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-139">The Store ID is available in Partner Center, and it is included in the response data for requests to [Get all add-ons](get-all-add-ons.md) and [Create an add-on](create-an-add-on.md).</span></span> |
| <span data-ttu-id="c3c6c-140">submissionId</span><span class="sxs-lookup"><span data-stu-id="c3c6c-140">submissionId</span></span> | <span data-ttu-id="c3c6c-141">string</span><span class="sxs-lookup"><span data-stu-id="c3c6c-141">string</span></span> | <span data-ttu-id="c3c6c-142">必須。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-142">Required.</span></span> <span data-ttu-id="c3c6c-143">コミットする申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-143">The ID of the submission you want to commit.</span></span> <span data-ttu-id="c3c6c-144">この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-144">This ID is available in the response data for requests to [create an add-on submission](create-an-add-on-submission.md).</span></span> <span data-ttu-id="c3c6c-145">パートナー センターで作成された申請はこの ID はパートナー センターでの申請ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-145">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="c3c6c-146">要求本文</span><span class="sxs-lookup"><span data-stu-id="c3c6c-146">Request body</span></span>

<span data-ttu-id="c3c6c-147">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-147">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="c3c6c-148">要求の例</span><span class="sxs-lookup"><span data-stu-id="c3c6c-148">Request example</span></span>

<span data-ttu-id="c3c6c-149">次の例は、アドオンの申請をコミットする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-149">The following example demonstrates how to commit an add-on submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621230023/commit HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="c3c6c-150">応答</span><span class="sxs-lookup"><span data-stu-id="c3c6c-150">Response</span></span>

<span data-ttu-id="c3c6c-151">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-151">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="c3c6c-152">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-152">For more details about the values in the response body, see the following sections.</span></span>

```json
{
  "status": "CommitStarted"
}
```

### <a name="response-body"></a><span data-ttu-id="c3c6c-153">応答本文</span><span class="sxs-lookup"><span data-stu-id="c3c6c-153">Response body</span></span>

| <span data-ttu-id="c3c6c-154">値</span><span class="sxs-lookup"><span data-stu-id="c3c6c-154">Value</span></span>      | <span data-ttu-id="c3c6c-155">型</span><span class="sxs-lookup"><span data-stu-id="c3c6c-155">Type</span></span>   | <span data-ttu-id="c3c6c-156">説明</span><span class="sxs-lookup"><span data-stu-id="c3c6c-156">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="c3c6c-157">status</span><span class="sxs-lookup"><span data-stu-id="c3c6c-157">status</span></span>           | <span data-ttu-id="c3c6c-158">string</span><span class="sxs-lookup"><span data-stu-id="c3c6c-158">string</span></span>  | <span data-ttu-id="c3c6c-159">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-159">The status of the submission.</span></span> <span data-ttu-id="c3c6c-160">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-160">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="c3c6c-161">None</span><span class="sxs-lookup"><span data-stu-id="c3c6c-161">None</span></span></li><li><span data-ttu-id="c3c6c-162">Canceled</span><span class="sxs-lookup"><span data-stu-id="c3c6c-162">Canceled</span></span></li><li><span data-ttu-id="c3c6c-163">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="c3c6c-163">PendingCommit</span></span></li><li><span data-ttu-id="c3c6c-164">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="c3c6c-164">CommitStarted</span></span></li><li><span data-ttu-id="c3c6c-165">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="c3c6c-165">CommitFailed</span></span></li><li><span data-ttu-id="c3c6c-166">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="c3c6c-166">PendingPublication</span></span></li><li><span data-ttu-id="c3c6c-167">Publishing</span><span class="sxs-lookup"><span data-stu-id="c3c6c-167">Publishing</span></span></li><li><span data-ttu-id="c3c6c-168">Published</span><span class="sxs-lookup"><span data-stu-id="c3c6c-168">Published</span></span></li><li><span data-ttu-id="c3c6c-169">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="c3c6c-169">PublishFailed</span></span></li><li><span data-ttu-id="c3c6c-170">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="c3c6c-170">PreProcessing</span></span></li><li><span data-ttu-id="c3c6c-171">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="c3c6c-171">PreProcessingFailed</span></span></li><li><span data-ttu-id="c3c6c-172">Certification</span><span class="sxs-lookup"><span data-stu-id="c3c6c-172">Certification</span></span></li><li><span data-ttu-id="c3c6c-173">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="c3c6c-173">CertificationFailed</span></span></li><li><span data-ttu-id="c3c6c-174">Release</span><span class="sxs-lookup"><span data-stu-id="c3c6c-174">Release</span></span></li><li><span data-ttu-id="c3c6c-175">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="c3c6c-175">ReleaseFailed</span></span></li></ul>  |


## <a name="error-codes"></a><span data-ttu-id="c3c6c-176">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c3c6c-176">Error codes</span></span>

<span data-ttu-id="c3c6c-177">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-177">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="c3c6c-178">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c3c6c-178">Error code</span></span> |  <span data-ttu-id="c3c6c-179">説明</span><span class="sxs-lookup"><span data-stu-id="c3c6c-179">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="c3c6c-180">400</span><span class="sxs-lookup"><span data-stu-id="c3c6c-180">400</span></span>  | <span data-ttu-id="c3c6c-181">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-181">The request parameters are invalid.</span></span> |
| <span data-ttu-id="c3c6c-182">404</span><span class="sxs-lookup"><span data-stu-id="c3c6c-182">404</span></span>  | <span data-ttu-id="c3c6c-183">指定した申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-183">The specified submission could not be found.</span></span> |
| <span data-ttu-id="c3c6c-184">409</span><span class="sxs-lookup"><span data-stu-id="c3c6c-184">409</span></span>  | <span data-ttu-id="c3c6c-185">指定した申請は見つかりましたが、現在の状態でコミットできなかった可能性がありますかアドオンは[、Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)パートナー センターの機能を使用しています。</span><span class="sxs-lookup"><span data-stu-id="c3c6c-185">The specified submission was found but it could not be committed in its current state, or the add-on uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |


## <a name="related-topics"></a><span data-ttu-id="c3c6c-186">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c3c6c-186">Related topics</span></span>

* [<span data-ttu-id="c3c6c-187">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="c3c6c-187">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="c3c6c-188">アドオンの申請の取得</span><span class="sxs-lookup"><span data-stu-id="c3c6c-188">Get an add-on submission</span></span>](get-an-add-on-submission.md)
* [<span data-ttu-id="c3c6c-189">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="c3c6c-189">Create an add-on submission</span></span>](create-an-add-on-submission.md)
* [<span data-ttu-id="c3c6c-190">アドオンの申請の更新</span><span class="sxs-lookup"><span data-stu-id="c3c6c-190">Update an add-on submission</span></span>](update-an-add-on-submission.md)
* [<span data-ttu-id="c3c6c-191">アドオンの申請の削除</span><span class="sxs-lookup"><span data-stu-id="c3c6c-191">Delete an add-on submission</span></span>](delete-an-add-on-submission.md)
* [<span data-ttu-id="c3c6c-192">アドオンの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="c3c6c-192">Get the status of an add-on submission</span></span>](get-status-for-an-add-on-submission.md)
