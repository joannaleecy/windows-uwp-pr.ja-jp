---
author: mcleanbyron
ms.assetid: F94AF8F6-0742-4A3F-938E-177472F96C00
description: "新しいパッケージ フライトの申請または更新されたパッケージ フライトの申請を Windows デベロッパー センターにコミットするには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "パッケージ フライトの申請のコミット"
ms.author: mcleans
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、Windows ストア申請 API、フライトの申請のコミット"
ms.openlocfilehash: e0fd115dc5e394abe6c0353ba41ebc35fde086c4
ms.sourcegitcommit: a8e7dc247196eee79b67aaae2b2a4496c54ce253
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/04/2017
---
# <a name="commit-a-package-flight-submission"></a><span data-ttu-id="f2ca8-104">パッケージ フライトの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="f2ca8-104">Commit a package flight submission</span></span>




<span data-ttu-id="f2ca8-105">新しいパッケージ フライトの申請または更新されたパッケージ フライトの申請を Windows デベロッパー センターにコミットするには、Windows ストア申請 API に含まれる以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-105">Use this method in the Windows Store submission API to commit a new or updated package flight submission to Windows Dev Center.</span></span> <span data-ttu-id="f2ca8-106">コミット アクションにより、申請データ (関連パッケージを含む) がアップロードされたことがデベロッパー センターに通知されます。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-106">The commit action alerts Dev Center that the submission data has been uploaded (including any related packages).</span></span> <span data-ttu-id="f2ca8-107">通知を受けたデベロッパー センターは、申請データに対する変更をインジェストと公開のためにコミットします。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-107">In response, Dev Center commits the changes to the submission data for ingestion and publishing.</span></span> <span data-ttu-id="f2ca8-108">適切にコミットされると、申請に対する変更はデベロッパー センター ダッシュボードに表示されます。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-108">After the commit operation succeeds, the changes to the submission are shown in the Dev Center dashboard.</span></span>

<span data-ttu-id="f2ca8-109">コミット操作が Windows ストア申請 API を使ったパッケージ フライト申請の作成プロセスにどのように適合するかについては、[パッケージ フライト申請の管理に関するページ](manage-flight-submissions.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-109">For more information about how the commit operation fits into the process of creating a package flight submission by using the Windows Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="f2ca8-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="f2ca8-110">Prerequisites</span></span>

<span data-ttu-id="f2ca8-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="f2ca8-112">Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-112">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API.</span></span>
* <span data-ttu-id="f2ca8-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-113">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="f2ca8-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="f2ca8-115">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-115">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="f2ca8-116">[パッケージ フライトの申請を作成](create-a-flight-submission.md)し、申請データを必要に応じて変更して[申請を更新](update-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-116">[Create a package flight submission](create-a-flight-submission.md) and then [update the submission](update-a-flight-submission.md) with any necessary changes to the submission data.</span></span>

## <a name="request"></a><span data-ttu-id="f2ca8-117">要求</span><span class="sxs-lookup"><span data-stu-id="f2ca8-117">Request</span></span>

<span data-ttu-id="f2ca8-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-118">This method has the following syntax.</span></span> <span data-ttu-id="f2ca8-119">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-119">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="f2ca8-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="f2ca8-120">Method</span></span> | <span data-ttu-id="f2ca8-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="f2ca8-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="f2ca8-122">POST</span><span class="sxs-lookup"><span data-stu-id="f2ca8-122">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit``` |

<span/>
 

### <a name="request-header"></a><span data-ttu-id="f2ca8-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2ca8-123">Request header</span></span>

| <span data-ttu-id="f2ca8-124">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2ca8-124">Header</span></span>        | <span data-ttu-id="f2ca8-125">型</span><span class="sxs-lookup"><span data-stu-id="f2ca8-125">Type</span></span>   | <span data-ttu-id="f2ca8-126">説明</span><span class="sxs-lookup"><span data-stu-id="f2ca8-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="f2ca8-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="f2ca8-127">Authorization</span></span> | <span data-ttu-id="f2ca8-128">string</span><span class="sxs-lookup"><span data-stu-id="f2ca8-128">string</span></span> | <span data-ttu-id="f2ca8-129">必須。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-129">Required.</span></span> <span data-ttu-id="f2ca8-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |

<span/>

### <a name="request-parameters"></a><span data-ttu-id="f2ca8-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2ca8-131">Request parameters</span></span>

| <span data-ttu-id="f2ca8-132">名前</span><span class="sxs-lookup"><span data-stu-id="f2ca8-132">Name</span></span>        | <span data-ttu-id="f2ca8-133">種類</span><span class="sxs-lookup"><span data-stu-id="f2ca8-133">Type</span></span>   | <span data-ttu-id="f2ca8-134">説明</span><span class="sxs-lookup"><span data-stu-id="f2ca8-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="f2ca8-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="f2ca8-135">applicationId</span></span> | <span data-ttu-id="f2ca8-136">string</span><span class="sxs-lookup"><span data-stu-id="f2ca8-136">string</span></span> | <span data-ttu-id="f2ca8-137">必須。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-137">Required.</span></span> <span data-ttu-id="f2ca8-138">コミットするパッケージ フライトの申請が含まれるアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-138">The Store ID of the app that contains the package flight submission you want to commit.</span></span> <span data-ttu-id="f2ca8-139">アプリのストア ID は、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-139">The Store ID for the app is available on the Dev Center dashboard.</span></span>  |
| <span data-ttu-id="f2ca8-140">flightId</span><span class="sxs-lookup"><span data-stu-id="f2ca8-140">flightId</span></span> | <span data-ttu-id="f2ca8-141">string</span><span class="sxs-lookup"><span data-stu-id="f2ca8-141">string</span></span> | <span data-ttu-id="f2ca8-142">必須。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-142">Required.</span></span> <span data-ttu-id="f2ca8-143">コミットする申請が含まれるパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-143">The ID of the package flight that contains the submission to commit.</span></span> <span data-ttu-id="f2ca8-144">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-144">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span>  |
| <span data-ttu-id="f2ca8-145">submissionId</span><span class="sxs-lookup"><span data-stu-id="f2ca8-145">submissionId</span></span> | <span data-ttu-id="f2ca8-146">string</span><span class="sxs-lookup"><span data-stu-id="f2ca8-146">string</span></span> | <span data-ttu-id="f2ca8-147">必須。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-147">Required.</span></span> <span data-ttu-id="f2ca8-148">コミットする申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-148">The ID of the submission to commit.</span></span> <span data-ttu-id="f2ca8-149">この ID は、[パッケージ フライト申請の作成](create-a-flight-submission.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-149">This ID is available in the Dev Center dashboard, and it is included in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span>  |

<span/>

### <a name="request-body"></a><span data-ttu-id="f2ca8-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="f2ca8-150">Request body</span></span>

<span data-ttu-id="f2ca8-151">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-151">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="f2ca8-152">要求の例</span><span class="sxs-lookup"><span data-stu-id="f2ca8-152">Request example</span></span>

<span data-ttu-id="f2ca8-153">次の例は、パッケージ フライトの申請をコミットする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-153">The following example demonstrates how to commit a package flight submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649/commit HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="f2ca8-154">応答</span><span class="sxs-lookup"><span data-stu-id="f2ca8-154">Response</span></span>

<span data-ttu-id="f2ca8-155">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-155">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="f2ca8-156">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-156">For more details about the values in the response body, see the following sections.</span></span>

```json
{
  "status": "CommitStarted"
}
```

### <a name="response-body"></a><span data-ttu-id="f2ca8-157">応答本文</span><span class="sxs-lookup"><span data-stu-id="f2ca8-157">Response body</span></span>

| <span data-ttu-id="f2ca8-158">値</span><span class="sxs-lookup"><span data-stu-id="f2ca8-158">Value</span></span>      | <span data-ttu-id="f2ca8-159">型</span><span class="sxs-lookup"><span data-stu-id="f2ca8-159">Type</span></span>   | <span data-ttu-id="f2ca8-160">説明</span><span class="sxs-lookup"><span data-stu-id="f2ca8-160">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="f2ca8-161">status</span><span class="sxs-lookup"><span data-stu-id="f2ca8-161">status</span></span>           | <span data-ttu-id="f2ca8-162">string</span><span class="sxs-lookup"><span data-stu-id="f2ca8-162">string</span></span>  | <span data-ttu-id="f2ca8-163">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-163">The status of the submission.</span></span> <span data-ttu-id="f2ca8-164">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-164">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="f2ca8-165">None</span><span class="sxs-lookup"><span data-stu-id="f2ca8-165">None</span></span></li><li><span data-ttu-id="f2ca8-166">Canceled</span><span class="sxs-lookup"><span data-stu-id="f2ca8-166">Canceled</span></span></li><li><span data-ttu-id="f2ca8-167">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="f2ca8-167">PendingCommit</span></span></li><li><span data-ttu-id="f2ca8-168">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="f2ca8-168">CommitStarted</span></span></li><li><span data-ttu-id="f2ca8-169">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="f2ca8-169">CommitFailed</span></span></li><li><span data-ttu-id="f2ca8-170">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="f2ca8-170">PendingPublication</span></span></li><li><span data-ttu-id="f2ca8-171">Publishing</span><span class="sxs-lookup"><span data-stu-id="f2ca8-171">Publishing</span></span></li><li><span data-ttu-id="f2ca8-172">Published</span><span class="sxs-lookup"><span data-stu-id="f2ca8-172">Published</span></span></li><li><span data-ttu-id="f2ca8-173">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="f2ca8-173">PublishFailed</span></span></li><li><span data-ttu-id="f2ca8-174">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="f2ca8-174">PreProcessing</span></span></li><li><span data-ttu-id="f2ca8-175">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="f2ca8-175">PreProcessingFailed</span></span></li><li><span data-ttu-id="f2ca8-176">Certification</span><span class="sxs-lookup"><span data-stu-id="f2ca8-176">Certification</span></span></li><li><span data-ttu-id="f2ca8-177">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="f2ca8-177">CertificationFailed</span></span></li><li><span data-ttu-id="f2ca8-178">Release</span><span class="sxs-lookup"><span data-stu-id="f2ca8-178">Release</span></span></li><li><span data-ttu-id="f2ca8-179">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="f2ca8-179">ReleaseFailed</span></span></li></ul>  |

<span/>

## <a name="error-codes"></a><span data-ttu-id="f2ca8-180">エラー コード</span><span class="sxs-lookup"><span data-stu-id="f2ca8-180">Error codes</span></span>

<span data-ttu-id="f2ca8-181">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-181">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="f2ca8-182">エラー コード</span><span class="sxs-lookup"><span data-stu-id="f2ca8-182">Error code</span></span> |  <span data-ttu-id="f2ca8-183">説明</span><span class="sxs-lookup"><span data-stu-id="f2ca8-183">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="f2ca8-184">400</span><span class="sxs-lookup"><span data-stu-id="f2ca8-184">400</span></span>  | <span data-ttu-id="f2ca8-185">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-185">The request parameters are invalid.</span></span> |
| <span data-ttu-id="f2ca8-186">404</span><span class="sxs-lookup"><span data-stu-id="f2ca8-186">404</span></span>  | <span data-ttu-id="f2ca8-187">指定した申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-187">The specified submission could not be found.</span></span> |
| <span data-ttu-id="f2ca8-188">409</span><span class="sxs-lookup"><span data-stu-id="f2ca8-188">409</span></span>  | <span data-ttu-id="f2ca8-189">指定した申請は見つかりましたが、現在の状態でコミットできなかったか、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。</span><span class="sxs-lookup"><span data-stu-id="f2ca8-189">The specified submission was found but it could not be committed in its current state, or the app uses a Dev Center dashboard feature that is [currently not supported by the Windows Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |

<span/>


## <a name="related-topics"></a><span data-ttu-id="f2ca8-190">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f2ca8-190">Related topics</span></span>

* [<span data-ttu-id="f2ca8-191">Windows ストア サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="f2ca8-191">Create and manage submissions using Windows Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="f2ca8-192">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="f2ca8-192">Manage package flight submissions</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="f2ca8-193">パッケージ フライトの申請の取得</span><span class="sxs-lookup"><span data-stu-id="f2ca8-193">Get a package flight submission</span></span>](get-a-flight-submission.md)
* [<span data-ttu-id="f2ca8-194">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="f2ca8-194">Create a package flight submission</span></span>](create-a-flight-submission.md)
* [<span data-ttu-id="f2ca8-195">パッケージ フライトの申請の更新</span><span class="sxs-lookup"><span data-stu-id="f2ca8-195">Update a package flight submission</span></span>](update-a-flight-submission.md)
* [<span data-ttu-id="f2ca8-196">パッケージ フライトの申請の削除</span><span class="sxs-lookup"><span data-stu-id="f2ca8-196">Delete a package flight submission</span></span>](delete-a-flight-submission.md)
* [<span data-ttu-id="f2ca8-197">パッケージ フライトの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="f2ca8-197">Get the status of a package flight submission</span></span>](get-status-for-a-flight-submission.md)
