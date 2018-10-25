---
author: Xansky
ms.assetid: 55315F38-6EC5-4889-A14E-7D8EC282FE98
description: アドオンの申請の状態を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの申請の状態の取得
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請, 状態
ms.localizationpriority: medium
ms.openlocfilehash: 07c1dd89ce31ad70e5ee3b79c09caf36a89ad926
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5480904"
---
# <a name="get-the-status-of-an-add-on-submission"></a><span data-ttu-id="b4382-104">アドオンの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="b4382-104">Get the status of an add-on submission</span></span>

<span data-ttu-id="b4382-105">アドオン (アプリ内製品または IAP とも呼ばれます) の申請の状態を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="b4382-105">Use this method in the Microsoft Store submission API to get the status of an add-on (also known as in-app product or IAP) submission.</span></span> <span data-ttu-id="b4382-106">Microsoft Store 申請 API を使ったアドオンの申請の作成プロセスについて詳しくは、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b4382-106">For more information about the process of process of creating an add-on submission by using the Microsoft Store submission API, see [Manage add-on submissions](manage-add-on-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="b4382-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="b4382-107">Prerequisites</span></span>

<span data-ttu-id="b4382-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="b4382-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="b4382-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="b4382-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="b4382-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="b4382-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="b4382-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="b4382-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="b4382-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="b4382-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="b4382-113">デベロッパー センター アカウントにアドオン申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="b4382-113">Create an add-on submission for an app in your Dev Center account.</span></span> <span data-ttu-id="b4382-114">この操作は、デベロッパー センター ダッシュボードまたは[アドオン申請の作成](create-an-add-on-submission.md)メソッドを使って実行できます。</span><span class="sxs-lookup"><span data-stu-id="b4382-114">You can do this in the Dev Center dashboard, or you can do this by using the [Create an add-on submission](create-an-add-on-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="b4382-115">要求</span><span class="sxs-lookup"><span data-stu-id="b4382-115">Request</span></span>

<span data-ttu-id="b4382-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="b4382-116">This method has the following syntax.</span></span> <span data-ttu-id="b4382-117">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b4382-117">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="b4382-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="b4382-118">Method</span></span> | <span data-ttu-id="b4382-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="b4382-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="b4382-120">GET</span><span class="sxs-lookup"><span data-stu-id="b4382-120">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId}/status``` |


### <a name="request-header"></a><span data-ttu-id="b4382-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4382-121">Request header</span></span>

| <span data-ttu-id="b4382-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4382-122">Header</span></span>        | <span data-ttu-id="b4382-123">型</span><span class="sxs-lookup"><span data-stu-id="b4382-123">Type</span></span>   | <span data-ttu-id="b4382-124">説明</span><span class="sxs-lookup"><span data-stu-id="b4382-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="b4382-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="b4382-125">Authorization</span></span> | <span data-ttu-id="b4382-126">string</span><span class="sxs-lookup"><span data-stu-id="b4382-126">string</span></span> | <span data-ttu-id="b4382-127">必須。</span><span class="sxs-lookup"><span data-stu-id="b4382-127">Required.</span></span> <span data-ttu-id="b4382-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="b4382-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="b4382-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4382-129">Request parameters</span></span>

| <span data-ttu-id="b4382-130">名前</span><span class="sxs-lookup"><span data-stu-id="b4382-130">Name</span></span>        | <span data-ttu-id="b4382-131">種類</span><span class="sxs-lookup"><span data-stu-id="b4382-131">Type</span></span>   | <span data-ttu-id="b4382-132">説明</span><span class="sxs-lookup"><span data-stu-id="b4382-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="b4382-133">inAppProductId</span><span class="sxs-lookup"><span data-stu-id="b4382-133">inAppProductId</span></span> | <span data-ttu-id="b4382-134">string</span><span class="sxs-lookup"><span data-stu-id="b4382-134">string</span></span> | <span data-ttu-id="b4382-135">必須。</span><span class="sxs-lookup"><span data-stu-id="b4382-135">Required.</span></span> <span data-ttu-id="b4382-136">状態を取得する申請が含まれているアドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="b4382-136">The Store ID of the add-on that contains the submission for which you want to get the status.</span></span> <span data-ttu-id="b4382-137">ストア ID はデベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="b4382-137">The Store ID is available on the Dev Center dashboard.</span></span>  |
| <span data-ttu-id="b4382-138">submissionId</span><span class="sxs-lookup"><span data-stu-id="b4382-138">submissionId</span></span> | <span data-ttu-id="b4382-139">string</span><span class="sxs-lookup"><span data-stu-id="b4382-139">string</span></span> | <span data-ttu-id="b4382-140">必須。</span><span class="sxs-lookup"><span data-stu-id="b4382-140">Required.</span></span> <span data-ttu-id="b4382-141">状態を取得する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="b4382-141">The ID of the submission for which you want to get the status.</span></span> <span data-ttu-id="b4382-142">この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="b4382-142">This ID is available in the response data for requests to [create an add-on submission](create-an-add-on-submission.md).</span></span> <span data-ttu-id="b4382-143">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="b4382-143">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="b4382-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="b4382-144">Request body</span></span>

<span data-ttu-id="b4382-145">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="b4382-145">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="b4382-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="b4382-146">Request example</span></span>

<span data-ttu-id="b4382-147">次の例は、アドオン申請の状態を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b4382-147">The following example demonstrates how to get the status of an add-on submission.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621243680/status HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="b4382-148">応答</span><span class="sxs-lookup"><span data-stu-id="b4382-148">Response</span></span>

<span data-ttu-id="b4382-149">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="b4382-149">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="b4382-150">応答本文には、指定された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b4382-150">The response body contains information about the specified submission.</span></span> <span data-ttu-id="b4382-151">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b4382-151">For more details about the values in the response body, see the following sections.</span></span>

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

### <a name="response-body"></a><span data-ttu-id="b4382-152">応答本文</span><span class="sxs-lookup"><span data-stu-id="b4382-152">Response body</span></span>

| <span data-ttu-id="b4382-153">値</span><span class="sxs-lookup"><span data-stu-id="b4382-153">Value</span></span>      | <span data-ttu-id="b4382-154">型</span><span class="sxs-lookup"><span data-stu-id="b4382-154">Type</span></span>   | <span data-ttu-id="b4382-155">説明</span><span class="sxs-lookup"><span data-stu-id="b4382-155">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="b4382-156">status</span><span class="sxs-lookup"><span data-stu-id="b4382-156">status</span></span>           | <span data-ttu-id="b4382-157">string</span><span class="sxs-lookup"><span data-stu-id="b4382-157">string</span></span>  | <span data-ttu-id="b4382-158">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="b4382-158">The status of the submission.</span></span> <span data-ttu-id="b4382-159">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="b4382-159">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="b4382-160">None</span><span class="sxs-lookup"><span data-stu-id="b4382-160">None</span></span></li><li><span data-ttu-id="b4382-161">Canceled</span><span class="sxs-lookup"><span data-stu-id="b4382-161">Canceled</span></span></li><li><span data-ttu-id="b4382-162">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="b4382-162">PendingCommit</span></span></li><li><span data-ttu-id="b4382-163">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="b4382-163">CommitStarted</span></span></li><li><span data-ttu-id="b4382-164">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="b4382-164">CommitFailed</span></span></li><li><span data-ttu-id="b4382-165">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="b4382-165">PendingPublication</span></span></li><li><span data-ttu-id="b4382-166">Publishing</span><span class="sxs-lookup"><span data-stu-id="b4382-166">Publishing</span></span></li><li><span data-ttu-id="b4382-167">Published</span><span class="sxs-lookup"><span data-stu-id="b4382-167">Published</span></span></li><li><span data-ttu-id="b4382-168">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="b4382-168">PublishFailed</span></span></li><li><span data-ttu-id="b4382-169">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="b4382-169">PreProcessing</span></span></li><li><span data-ttu-id="b4382-170">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="b4382-170">PreProcessingFailed</span></span></li><li><span data-ttu-id="b4382-171">Certification</span><span class="sxs-lookup"><span data-stu-id="b4382-171">Certification</span></span></li><li><span data-ttu-id="b4382-172">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="b4382-172">CertificationFailed</span></span></li><li><span data-ttu-id="b4382-173">Release</span><span class="sxs-lookup"><span data-stu-id="b4382-173">Release</span></span></li><li><span data-ttu-id="b4382-174">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="b4382-174">ReleaseFailed</span></span></li></ul>   |
| <span data-ttu-id="b4382-175">statusDetails</span><span class="sxs-lookup"><span data-stu-id="b4382-175">statusDetails</span></span>           | <span data-ttu-id="b4382-176">object</span><span class="sxs-lookup"><span data-stu-id="b4382-176">object</span></span>  |  <span data-ttu-id="b4382-177">エラーに関する情報など、申請の状態に関する追加詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b4382-177">Contains additional details about the status of the submission, including information about any errors.</span></span> <span data-ttu-id="b4382-178">詳しくは、[ステータスの詳細に関するリソース](manage-add-on-submissions.md#status-details-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b4382-178">For more information, see [Status details resource](manage-add-on-submissions.md#status-details-object).</span></span> |


## <a name="error-codes"></a><span data-ttu-id="b4382-179">エラー コード</span><span class="sxs-lookup"><span data-stu-id="b4382-179">Error codes</span></span>

<span data-ttu-id="b4382-180">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="b4382-180">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="b4382-181">エラー コード</span><span class="sxs-lookup"><span data-stu-id="b4382-181">Error code</span></span> |  <span data-ttu-id="b4382-182">説明</span><span class="sxs-lookup"><span data-stu-id="b4382-182">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="b4382-183">404</span><span class="sxs-lookup"><span data-stu-id="b4382-183">404</span></span>  | <span data-ttu-id="b4382-184">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="b4382-184">The submission could not be found.</span></span> |
| <span data-ttu-id="b4382-185">409</span><span class="sxs-lookup"><span data-stu-id="b4382-185">409</span></span>  | <span data-ttu-id="b4382-186">アドオンが、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能を使用しています。</span><span class="sxs-lookup"><span data-stu-id="b4382-186">The add-on uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="b4382-187">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b4382-187">Related topics</span></span>

* [<span data-ttu-id="b4382-188">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="b4382-188">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="b4382-189">アドオンの申請の取得</span><span class="sxs-lookup"><span data-stu-id="b4382-189">Get an add-on submission</span></span>](get-an-add-on-submission.md)
* [<span data-ttu-id="b4382-190">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="b4382-190">Create an add-on submission</span></span>](create-an-add-on-submission.md)
* [<span data-ttu-id="b4382-191">アドオンの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="b4382-191">Commit an add-on submission</span></span>](commit-an-add-on-submission.md)
* [<span data-ttu-id="b4382-192">アドオンの申請の更新</span><span class="sxs-lookup"><span data-stu-id="b4382-192">Update an add-on submission</span></span>](update-an-add-on-submission.md)
* [<span data-ttu-id="b4382-193">アドオンの申請の削除</span><span class="sxs-lookup"><span data-stu-id="b4382-193">Delete an add-on submission</span></span>](delete-an-add-on-submission.md)
