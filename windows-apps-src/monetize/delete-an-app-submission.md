---
author: Xansky
ms.assetid: 96C090C1-88F8-42E7-AED1-AFA9031E952B
description: 既存のアプリの申請を削除するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請の削除
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリの申請, 削除
ms.localizationpriority: medium
ms.openlocfilehash: da2533eb8b6e45e4426a1d25931638466547e01b
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6255852"
---
# <a name="delete-an-app-submission"></a><span data-ttu-id="676c2-104">アプリの申請の削除</span><span class="sxs-lookup"><span data-stu-id="676c2-104">Delete an app submission</span></span>

<span data-ttu-id="676c2-105">既存のアプリの申請を削除するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="676c2-105">Use this method in the Microsoft Store submission API to delete an existing app submission.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="676c2-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="676c2-106">Prerequisites</span></span>

<span data-ttu-id="676c2-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="676c2-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="676c2-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="676c2-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="676c2-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="676c2-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="676c2-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="676c2-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="676c2-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="676c2-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="676c2-112">要求</span><span class="sxs-lookup"><span data-stu-id="676c2-112">Request</span></span>

<span data-ttu-id="676c2-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="676c2-113">This method has the following syntax.</span></span> <span data-ttu-id="676c2-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="676c2-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="676c2-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="676c2-115">Method</span></span> | <span data-ttu-id="676c2-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="676c2-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="676c2-117">DELETE</span><span class="sxs-lookup"><span data-stu-id="676c2-117">DELETE</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}``` |


### <a name="request-header"></a><span data-ttu-id="676c2-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="676c2-118">Request header</span></span>

| <span data-ttu-id="676c2-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="676c2-119">Header</span></span>        | <span data-ttu-id="676c2-120">型</span><span class="sxs-lookup"><span data-stu-id="676c2-120">Type</span></span>   | <span data-ttu-id="676c2-121">説明</span><span class="sxs-lookup"><span data-stu-id="676c2-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="676c2-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="676c2-122">Authorization</span></span> | <span data-ttu-id="676c2-123">string</span><span class="sxs-lookup"><span data-stu-id="676c2-123">string</span></span> | <span data-ttu-id="676c2-124">必須。</span><span class="sxs-lookup"><span data-stu-id="676c2-124">Required.</span></span> <span data-ttu-id="676c2-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="676c2-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="676c2-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="676c2-126">Request parameters</span></span>

| <span data-ttu-id="676c2-127">名前</span><span class="sxs-lookup"><span data-stu-id="676c2-127">Name</span></span>        | <span data-ttu-id="676c2-128">種類</span><span class="sxs-lookup"><span data-stu-id="676c2-128">Type</span></span>   | <span data-ttu-id="676c2-129">説明</span><span class="sxs-lookup"><span data-stu-id="676c2-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="676c2-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="676c2-130">applicationId</span></span> | <span data-ttu-id="676c2-131">string</span><span class="sxs-lookup"><span data-stu-id="676c2-131">string</span></span> | <span data-ttu-id="676c2-132">必須。</span><span class="sxs-lookup"><span data-stu-id="676c2-132">Required.</span></span> <span data-ttu-id="676c2-133">削除する申請に含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="676c2-133">The Store ID of the app that contains the submission to delete.</span></span> <span data-ttu-id="676c2-134">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="676c2-134">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="676c2-135">submissionId</span><span class="sxs-lookup"><span data-stu-id="676c2-135">submissionId</span></span> | <span data-ttu-id="676c2-136">string</span><span class="sxs-lookup"><span data-stu-id="676c2-136">string</span></span> | <span data-ttu-id="676c2-137">必須。</span><span class="sxs-lookup"><span data-stu-id="676c2-137">Required.</span></span> <span data-ttu-id="676c2-138">削除する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="676c2-138">The ID of the submission to delete.</span></span> <span data-ttu-id="676c2-139">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="676c2-139">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="676c2-140">パートナー センターで作成された申請はこの ID はパートナー センターでの申請ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="676c2-140">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="676c2-141">要求本文</span><span class="sxs-lookup"><span data-stu-id="676c2-141">Request body</span></span>

<span data-ttu-id="676c2-142">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="676c2-142">Do not provide a request body for this method.</span></span>


### <a name="request-example"></a><span data-ttu-id="676c2-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="676c2-143">Request example</span></span>

<span data-ttu-id="676c2-144">次の例は、アプリの申請を削除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="676c2-144">The following example demonstrates how to delete an app submission.</span></span>

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243610 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="676c2-145">応答</span><span class="sxs-lookup"><span data-stu-id="676c2-145">Response</span></span>

<span data-ttu-id="676c2-146">成功した場合、このメソッドは空の応答の本文を返します。</span><span class="sxs-lookup"><span data-stu-id="676c2-146">If successful, this method returns an empty response body.</span></span>

## <a name="error-codes"></a><span data-ttu-id="676c2-147">エラー コード</span><span class="sxs-lookup"><span data-stu-id="676c2-147">Error codes</span></span>

<span data-ttu-id="676c2-148">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="676c2-148">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="676c2-149">エラー コード</span><span class="sxs-lookup"><span data-stu-id="676c2-149">Error code</span></span> |  <span data-ttu-id="676c2-150">説明</span><span class="sxs-lookup"><span data-stu-id="676c2-150">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="676c2-151">400</span><span class="sxs-lookup"><span data-stu-id="676c2-151">400</span></span>  | <span data-ttu-id="676c2-152">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="676c2-152">The request parameters are invalid.</span></span> |
| <span data-ttu-id="676c2-153">404</span><span class="sxs-lookup"><span data-stu-id="676c2-153">404</span></span>  | <span data-ttu-id="676c2-154">指定した申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="676c2-154">The specified submission could not be found.</span></span> |
| <span data-ttu-id="676c2-155">409</span><span class="sxs-lookup"><span data-stu-id="676c2-155">409</span></span>  | <span data-ttu-id="676c2-156">指定した申請は見つかりましたが、現在の状態で削除できなかった可能性がありますか、アプリが[Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="676c2-156">The specified submission was found but it could not be deleted in its current state, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |


## <a name="related-topics"></a><span data-ttu-id="676c2-157">関連トピック</span><span class="sxs-lookup"><span data-stu-id="676c2-157">Related topics</span></span>

* [<span data-ttu-id="676c2-158">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="676c2-158">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="676c2-159">アプリの申請の取得</span><span class="sxs-lookup"><span data-stu-id="676c2-159">Get an app submission</span></span>](get-an-app-submission.md)
* [<span data-ttu-id="676c2-160">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="676c2-160">Create an app submission</span></span>](create-an-app-submission.md)
* [<span data-ttu-id="676c2-161">アプリの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="676c2-161">Commit an app submission</span></span>](commit-an-app-submission.md)
* [<span data-ttu-id="676c2-162">アプリの申請の更新</span><span class="sxs-lookup"><span data-stu-id="676c2-162">Update an app submission</span></span>](update-an-app-submission.md)
* [<span data-ttu-id="676c2-163">アプリの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="676c2-163">Get the status of an app submission</span></span>](get-status-for-an-app-submission.md)
