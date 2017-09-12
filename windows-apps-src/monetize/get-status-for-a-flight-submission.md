---
author: mcleanbyron
ms.assetid: C78176D6-47BB-4C63-92F8-426719A70F04
description: "パッケージ フライトの申請の状態を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "パッケージ フライトの申請の状態を取得する"
ms.author: mcleans
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, フライトの申請, 状態"
ms.openlocfilehash: 9397b0e3bd43ae77fd68e564c0af9a1c4ad67282
ms.sourcegitcommit: a8e7dc247196eee79b67aaae2b2a4496c54ce253
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/04/2017
---
# <a name="get-the-status-of-a-package-flight-submission"></a><span data-ttu-id="7ffb6-104">パッケージ フライトの申請の状態を取得する</span><span class="sxs-lookup"><span data-stu-id="7ffb6-104">Get the status of a package flight submission</span></span>




<span data-ttu-id="7ffb6-105">パッケージ フライトの申請の状態を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-105">Use this method in the Windows Store submission API to get the status of a package flight submission.</span></span> <span data-ttu-id="7ffb6-106">Windows ストア申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-106">For more information about the process of process of creating a package flight submission by using the Windows Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="7ffb6-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="7ffb6-107">Prerequisites</span></span>

<span data-ttu-id="7ffb6-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="7ffb6-109">Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API.</span></span>
* <span data-ttu-id="7ffb6-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="7ffb6-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="7ffb6-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="7ffb6-113">デベロッパー センターのアカウントでアプリのパッケージ フライトの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-113">Create a package flight submission for an app in your Dev Center account.</span></span> <span data-ttu-id="7ffb6-114">これは、デベロッパー センターのダッシュボードで行うことも、[パッケージ フライトの申請の作成](create-a-flight-submission.md)メソッドを使って行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-114">You can do this in the Dev Center dashboard, or you can do this by using the [create a package flight submission](create-a-flight-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="7ffb6-115">要求</span><span class="sxs-lookup"><span data-stu-id="7ffb6-115">Request</span></span>

<span data-ttu-id="7ffb6-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-116">This method has the following syntax.</span></span> <span data-ttu-id="7ffb6-117">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-117">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="7ffb6-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="7ffb6-118">Method</span></span> | <span data-ttu-id="7ffb6-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="7ffb6-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="7ffb6-120">GET</span><span class="sxs-lookup"><span data-stu-id="7ffb6-120">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions{submissionId}/status``` |

<span/>
 

### <a name="request-header"></a><span data-ttu-id="7ffb6-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ffb6-121">Request header</span></span>

| <span data-ttu-id="7ffb6-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ffb6-122">Header</span></span>        | <span data-ttu-id="7ffb6-123">型</span><span class="sxs-lookup"><span data-stu-id="7ffb6-123">Type</span></span>   | <span data-ttu-id="7ffb6-124">説明</span><span class="sxs-lookup"><span data-stu-id="7ffb6-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="7ffb6-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="7ffb6-125">Authorization</span></span> | <span data-ttu-id="7ffb6-126">string</span><span class="sxs-lookup"><span data-stu-id="7ffb6-126">string</span></span> | <span data-ttu-id="7ffb6-127">必須。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-127">Required.</span></span> <span data-ttu-id="7ffb6-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |

<span/>

### <a name="request-parameters"></a><span data-ttu-id="7ffb6-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ffb6-129">Request parameters</span></span>

| <span data-ttu-id="7ffb6-130">名前</span><span class="sxs-lookup"><span data-stu-id="7ffb6-130">Name</span></span>        | <span data-ttu-id="7ffb6-131">種類</span><span class="sxs-lookup"><span data-stu-id="7ffb6-131">Type</span></span>   | <span data-ttu-id="7ffb6-132">説明</span><span class="sxs-lookup"><span data-stu-id="7ffb6-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="7ffb6-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="7ffb6-133">applicationId</span></span> | <span data-ttu-id="7ffb6-134">string</span><span class="sxs-lookup"><span data-stu-id="7ffb6-134">string</span></span> | <span data-ttu-id="7ffb6-135">必須。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-135">Required.</span></span> <span data-ttu-id="7ffb6-136">状態を取得するパッケージ フライトの申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-136">The Store ID of the app that contains the package flight submission for which you want to get the status.</span></span> <span data-ttu-id="7ffb6-137">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-137">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="7ffb6-138">flightId</span><span class="sxs-lookup"><span data-stu-id="7ffb6-138">flightId</span></span> | <span data-ttu-id="7ffb6-139">string</span><span class="sxs-lookup"><span data-stu-id="7ffb6-139">string</span></span> | <span data-ttu-id="7ffb6-140">必須。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-140">Required.</span></span> <span data-ttu-id="7ffb6-141">状態を取得する申請が含まれているパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-141">The ID of the package flight that contains the submission for which you want to get the status.</span></span> <span data-ttu-id="7ffb6-142">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-142">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span>  |
| <span data-ttu-id="7ffb6-143">submissionId</span><span class="sxs-lookup"><span data-stu-id="7ffb6-143">submissionId</span></span> | <span data-ttu-id="7ffb6-144">string</span><span class="sxs-lookup"><span data-stu-id="7ffb6-144">string</span></span> | <span data-ttu-id="7ffb6-145">必須。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-145">Required.</span></span> <span data-ttu-id="7ffb6-146">状態を取得する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-146">The ID of the submission for which you want to get the status.</span></span> <span data-ttu-id="7ffb6-147">この ID は、[パッケージ フライトの申請を作成する](create-a-flight-submission.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-147">This ID is available in the Dev Center dashboard, and it is included in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span>  |

<span/>

### <a name="request-body"></a><span data-ttu-id="7ffb6-148">要求本文</span><span class="sxs-lookup"><span data-stu-id="7ffb6-148">Request body</span></span>

<span data-ttu-id="7ffb6-149">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-149">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="7ffb6-150">要求の例</span><span class="sxs-lookup"><span data-stu-id="7ffb6-150">Request example</span></span>

<span data-ttu-id="7ffb6-151">次の例は、パッケージ フライトの申請の状態を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-151">The following example demonstrates how to get the status of a package flight submission.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649/status HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="7ffb6-152">応答</span><span class="sxs-lookup"><span data-stu-id="7ffb6-152">Response</span></span>

<span data-ttu-id="7ffb6-153">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-153">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="7ffb6-154">応答本文には、指定された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-154">The response body contains information about the specified submission.</span></span> <span data-ttu-id="7ffb6-155">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-155">For more details about the values in the response body, see the following section.</span></span>

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

### <a name="response-body"></a><span data-ttu-id="7ffb6-156">応答本文</span><span class="sxs-lookup"><span data-stu-id="7ffb6-156">Response body</span></span>

| <span data-ttu-id="7ffb6-157">値</span><span class="sxs-lookup"><span data-stu-id="7ffb6-157">Value</span></span>      | <span data-ttu-id="7ffb6-158">型</span><span class="sxs-lookup"><span data-stu-id="7ffb6-158">Type</span></span>   | <span data-ttu-id="7ffb6-159">説明</span><span class="sxs-lookup"><span data-stu-id="7ffb6-159">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="7ffb6-160">status</span><span class="sxs-lookup"><span data-stu-id="7ffb6-160">status</span></span>           | <span data-ttu-id="7ffb6-161">string</span><span class="sxs-lookup"><span data-stu-id="7ffb6-161">string</span></span>  | <span data-ttu-id="7ffb6-162">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-162">The status of the submission.</span></span> <span data-ttu-id="7ffb6-163">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-163">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="7ffb6-164">None</span><span class="sxs-lookup"><span data-stu-id="7ffb6-164">None</span></span></li><li><span data-ttu-id="7ffb6-165">Canceled</span><span class="sxs-lookup"><span data-stu-id="7ffb6-165">Canceled</span></span></li><li><span data-ttu-id="7ffb6-166">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="7ffb6-166">PendingCommit</span></span></li><li><span data-ttu-id="7ffb6-167">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="7ffb6-167">CommitStarted</span></span></li><li><span data-ttu-id="7ffb6-168">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="7ffb6-168">CommitFailed</span></span></li><li><span data-ttu-id="7ffb6-169">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="7ffb6-169">PendingPublication</span></span></li><li><span data-ttu-id="7ffb6-170">Publishing</span><span class="sxs-lookup"><span data-stu-id="7ffb6-170">Publishing</span></span></li><li><span data-ttu-id="7ffb6-171">Published</span><span class="sxs-lookup"><span data-stu-id="7ffb6-171">Published</span></span></li><li><span data-ttu-id="7ffb6-172">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="7ffb6-172">PublishFailed</span></span></li><li><span data-ttu-id="7ffb6-173">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="7ffb6-173">PreProcessing</span></span></li><li><span data-ttu-id="7ffb6-174">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="7ffb6-174">PreProcessingFailed</span></span></li><li><span data-ttu-id="7ffb6-175">Certification</span><span class="sxs-lookup"><span data-stu-id="7ffb6-175">Certification</span></span></li><li><span data-ttu-id="7ffb6-176">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="7ffb6-176">CertificationFailed</span></span></li><li><span data-ttu-id="7ffb6-177">Release</span><span class="sxs-lookup"><span data-stu-id="7ffb6-177">Release</span></span></li><li><span data-ttu-id="7ffb6-178">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="7ffb6-178">ReleaseFailed</span></span></li></ul>   |
| <span data-ttu-id="7ffb6-179">statusDetails</span><span class="sxs-lookup"><span data-stu-id="7ffb6-179">statusDetails</span></span>           | <span data-ttu-id="7ffb6-180">object</span><span class="sxs-lookup"><span data-stu-id="7ffb6-180">object</span></span>  |  <span data-ttu-id="7ffb6-181">エラーに関する情報など、申請の状態に関する追加詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-181">Contains additional details about the status of the submission, including information about any errors.</span></span> <span data-ttu-id="7ffb6-182">詳しくは、[ステータスの詳細に関するリソース](manage-flight-submissions.md#status-details-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-182">For more information, see [Status details resource](manage-flight-submissions.md#status-details-object).</span></span> |


<span/>

## <a name="error-codes"></a><span data-ttu-id="7ffb6-183">エラー コード</span><span class="sxs-lookup"><span data-stu-id="7ffb6-183">Error codes</span></span>

<span data-ttu-id="7ffb6-184">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-184">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="7ffb6-185">エラー コード</span><span class="sxs-lookup"><span data-stu-id="7ffb6-185">Error code</span></span> |  <span data-ttu-id="7ffb6-186">説明</span><span class="sxs-lookup"><span data-stu-id="7ffb6-186">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="7ffb6-187">404</span><span class="sxs-lookup"><span data-stu-id="7ffb6-187">404</span></span>  | <span data-ttu-id="7ffb6-188">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-188">The submission could not be found.</span></span> |
| <span data-ttu-id="7ffb6-189">409</span><span class="sxs-lookup"><span data-stu-id="7ffb6-189">409</span></span>  | <span data-ttu-id="7ffb6-190">アプリは、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="7ffb6-190">The app uses a Dev Center dashboard feature that is [currently not supported by the Windows Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |

<span/>


## <a name="related-topics"></a><span data-ttu-id="7ffb6-191">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7ffb6-191">Related topics</span></span>

* [<span data-ttu-id="7ffb6-192">Windows ストア サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="7ffb6-192">Create and manage submissions using Windows Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="7ffb6-193">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="7ffb6-193">Manage package flight submissions</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="7ffb6-194">アプリの申請の取得</span><span class="sxs-lookup"><span data-stu-id="7ffb6-194">Get an app submission</span></span>](get-an-app-submission.md)
* [<span data-ttu-id="7ffb6-195">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="7ffb6-195">Create an app submission</span></span>](create-an-app-submission.md)
* [<span data-ttu-id="7ffb6-196">アプリの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="7ffb6-196">Commit an app submission</span></span>](commit-an-app-submission.md)
* [<span data-ttu-id="7ffb6-197">アプリの申請の更新</span><span class="sxs-lookup"><span data-stu-id="7ffb6-197">Update an app submission</span></span>](update-an-app-submission.md)
* [<span data-ttu-id="7ffb6-198">アプリの申請の削除</span><span class="sxs-lookup"><span data-stu-id="7ffb6-198">Delete an app submission</span></span>](delete-an-app-submission.md)
