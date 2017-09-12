---
author: mcleanbyron
ms.assetid: 1A69A388-B1CC-4D2C-886B-EA07E6E60252
description: "既存のパッケージ フライトの申請を削除するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "パッケージ フライトの申請の削除"
ms.author: mcleans
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, フライトの申請, 削除, パッケージ フライト"
ms.openlocfilehash: b2d6e2a1f92541478b4639133978cf6bdb009214
ms.sourcegitcommit: a8e7dc247196eee79b67aaae2b2a4496c54ce253
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/04/2017
---
# <a name="delete-a-package-flight-submission"></a><span data-ttu-id="1d772-104">パッケージ フライトの申請の削除</span><span class="sxs-lookup"><span data-stu-id="1d772-104">Delete a package flight submission</span></span>




<span data-ttu-id="1d772-105">既存のパッケージ フライトの申請を削除するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="1d772-105">Use this method in the Windows Store submission API to delete an existing package flight submission.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="1d772-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="1d772-106">Prerequisites</span></span>

<span data-ttu-id="1d772-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="1d772-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="1d772-108">Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="1d772-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API.</span></span>
* <span data-ttu-id="1d772-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="1d772-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="1d772-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="1d772-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="1d772-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="1d772-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="1d772-112">要求</span><span class="sxs-lookup"><span data-stu-id="1d772-112">Request</span></span>

<span data-ttu-id="1d772-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="1d772-113">This method has the following syntax.</span></span> <span data-ttu-id="1d772-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1d772-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="1d772-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="1d772-115">Method</span></span> | <span data-ttu-id="1d772-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="1d772-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="1d772-117">DELETE</span><span class="sxs-lookup"><span data-stu-id="1d772-117">DELETE</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationid}/flights/{flightId}/submissions/{submissionId}``` |

<span/>
 

### <a name="request-header"></a><span data-ttu-id="1d772-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1d772-118">Request header</span></span>

| <span data-ttu-id="1d772-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1d772-119">Header</span></span>        | <span data-ttu-id="1d772-120">型</span><span class="sxs-lookup"><span data-stu-id="1d772-120">Type</span></span>   | <span data-ttu-id="1d772-121">説明</span><span class="sxs-lookup"><span data-stu-id="1d772-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="1d772-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="1d772-122">Authorization</span></span> | <span data-ttu-id="1d772-123">string</span><span class="sxs-lookup"><span data-stu-id="1d772-123">string</span></span> | <span data-ttu-id="1d772-124">必須。</span><span class="sxs-lookup"><span data-stu-id="1d772-124">Required.</span></span> <span data-ttu-id="1d772-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="1d772-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |

<span/>

### <a name="request-parameters"></a><span data-ttu-id="1d772-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="1d772-126">Request parameters</span></span>

| <span data-ttu-id="1d772-127">名前</span><span class="sxs-lookup"><span data-stu-id="1d772-127">Name</span></span>        | <span data-ttu-id="1d772-128">種類</span><span class="sxs-lookup"><span data-stu-id="1d772-128">Type</span></span>   | <span data-ttu-id="1d772-129">説明</span><span class="sxs-lookup"><span data-stu-id="1d772-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="1d772-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="1d772-130">applicationId</span></span> | <span data-ttu-id="1d772-131">string</span><span class="sxs-lookup"><span data-stu-id="1d772-131">string</span></span> | <span data-ttu-id="1d772-132">必須。</span><span class="sxs-lookup"><span data-stu-id="1d772-132">Required.</span></span> <span data-ttu-id="1d772-133">削除するパッケージ フライトの申請が含まれるアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="1d772-133">The Store ID of the app that contains the package flight submission you want to delete.</span></span> <span data-ttu-id="1d772-134">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1d772-134">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="1d772-135">flightId</span><span class="sxs-lookup"><span data-stu-id="1d772-135">flightId</span></span> | <span data-ttu-id="1d772-136">string</span><span class="sxs-lookup"><span data-stu-id="1d772-136">string</span></span> | <span data-ttu-id="1d772-137">必須。</span><span class="sxs-lookup"><span data-stu-id="1d772-137">Required.</span></span> <span data-ttu-id="1d772-138">削除する申請が含まれるパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="1d772-138">The ID of the package flight that contains the submission to delete.</span></span> <span data-ttu-id="1d772-139">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="1d772-139">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span>  |
| <span data-ttu-id="1d772-140">submissionId</span><span class="sxs-lookup"><span data-stu-id="1d772-140">submissionId</span></span> | <span data-ttu-id="1d772-141">string</span><span class="sxs-lookup"><span data-stu-id="1d772-141">string</span></span> | <span data-ttu-id="1d772-142">必須。</span><span class="sxs-lookup"><span data-stu-id="1d772-142">Required.</span></span> <span data-ttu-id="1d772-143">削除する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="1d772-143">The ID of the submission to delete.</span></span> <span data-ttu-id="1d772-144">この ID は、[パッケージ フライト申請の作成](create-a-flight-submission.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="1d772-144">This ID is available in the Dev Center dashboard, and it is included in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span>  |

<span/>

### <a name="request-body"></a><span data-ttu-id="1d772-145">要求本文</span><span class="sxs-lookup"><span data-stu-id="1d772-145">Request body</span></span>

<span data-ttu-id="1d772-146">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="1d772-146">Do not provide a request body for this method.</span></span>

<span/>

### <a name="request-example"></a><span data-ttu-id="1d772-147">要求の例</span><span class="sxs-lookup"><span data-stu-id="1d772-147">Request example</span></span>

<span data-ttu-id="1d772-148">次の例は、パッケージ フライトの申請を削除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1d772-148">The following example demonstrates how to delete a submission for a package flight.</span></span>

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="1d772-149">応答</span><span class="sxs-lookup"><span data-stu-id="1d772-149">Response</span></span>

<span data-ttu-id="1d772-150">成功した場合、このメソッドは空の応答の本文を返します。</span><span class="sxs-lookup"><span data-stu-id="1d772-150">If successful, this method returns an empty response body.</span></span>

## <a name="error-codes"></a><span data-ttu-id="1d772-151">エラー コード</span><span class="sxs-lookup"><span data-stu-id="1d772-151">Error codes</span></span>

<span data-ttu-id="1d772-152">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="1d772-152">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="1d772-153">エラー コード</span><span class="sxs-lookup"><span data-stu-id="1d772-153">Error code</span></span> |  <span data-ttu-id="1d772-154">説明</span><span class="sxs-lookup"><span data-stu-id="1d772-154">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="1d772-155">400</span><span class="sxs-lookup"><span data-stu-id="1d772-155">400</span></span>  | <span data-ttu-id="1d772-156">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="1d772-156">The request parameters are invalid.</span></span> |
| <span data-ttu-id="1d772-157">404</span><span class="sxs-lookup"><span data-stu-id="1d772-157">404</span></span>  | <span data-ttu-id="1d772-158">指定した申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="1d772-158">The specified submission could not be found.</span></span> |
| <span data-ttu-id="1d772-159">409</span><span class="sxs-lookup"><span data-stu-id="1d772-159">409</span></span>  | <span data-ttu-id="1d772-160">指定した申請は見つかりましたが、現在の状態で削除できなかったか、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。</span><span class="sxs-lookup"><span data-stu-id="1d772-160">The specified submission was found but it could not be deleted in its current state, or the app uses a Dev Center dashboard feature that is [currently not supported by the Windows Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |

<span/>

## <a name="related-topics"></a><span data-ttu-id="1d772-161">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1d772-161">Related topics</span></span>

* [<span data-ttu-id="1d772-162">Windows ストア サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="1d772-162">Create and manage submissions using Windows Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="1d772-163">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="1d772-163">Manage package flight submissions</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="1d772-164">パッケージ フライトの申請の取得</span><span class="sxs-lookup"><span data-stu-id="1d772-164">Get a package flight submission</span></span>](get-a-flight-submission.md)
* [<span data-ttu-id="1d772-165">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="1d772-165">Create a package flight submission</span></span>](create-a-flight-submission.md)
* [<span data-ttu-id="1d772-166">パッケージ フライトの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="1d772-166">Commit a package flight submission</span></span>](commit-a-flight-submission.md)
* [<span data-ttu-id="1d772-167">パッケージ フライトの申請の更新</span><span class="sxs-lookup"><span data-stu-id="1d772-167">Update a package flight submission</span></span>](update-a-flight-submission.md)
* [<span data-ttu-id="1d772-168">パッケージ フライトの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="1d772-168">Get the status of a package flight submission</span></span>](get-status-for-a-flight-submission.md)
