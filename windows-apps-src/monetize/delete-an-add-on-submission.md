---
author: Xansky
ms.assetid: D677E126-C3D6-46B6-87A5-6237EBEDF1A9
description: 既存のアドオンの申請を削除するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの申請の削除
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請, 削除, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: ca534cfc7c38dba9d77749e17f15dd66766de7ca
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5987819"
---
# <a name="delete-an-add-on-submission"></a><span data-ttu-id="419da-104">アドオンの申請の削除</span><span class="sxs-lookup"><span data-stu-id="419da-104">Delete an add-on submission</span></span>

<span data-ttu-id="419da-105">既存のアドオン (アプリ内製品または IAP とも呼ばれます) を削除するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="419da-105">Use this method in the Microsoft Store submission API to delete an existing add-on (also known as in-app product or IAP) submission.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="419da-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="419da-106">Prerequisites</span></span>

<span data-ttu-id="419da-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="419da-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="419da-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="419da-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="419da-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="419da-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="419da-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="419da-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="419da-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="419da-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="419da-112">要求</span><span class="sxs-lookup"><span data-stu-id="419da-112">Request</span></span>

<span data-ttu-id="419da-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="419da-113">This method has the following syntax.</span></span> <span data-ttu-id="419da-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="419da-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="419da-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="419da-115">Method</span></span> | <span data-ttu-id="419da-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="419da-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="419da-117">DELETE</span><span class="sxs-lookup"><span data-stu-id="419da-117">DELETE</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId}``` |


### <a name="request-header"></a><span data-ttu-id="419da-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="419da-118">Request header</span></span>

| <span data-ttu-id="419da-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="419da-119">Header</span></span>        | <span data-ttu-id="419da-120">型</span><span class="sxs-lookup"><span data-stu-id="419da-120">Type</span></span>   | <span data-ttu-id="419da-121">説明</span><span class="sxs-lookup"><span data-stu-id="419da-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="419da-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="419da-122">Authorization</span></span> | <span data-ttu-id="419da-123">string</span><span class="sxs-lookup"><span data-stu-id="419da-123">string</span></span> | <span data-ttu-id="419da-124">必須。</span><span class="sxs-lookup"><span data-stu-id="419da-124">Required.</span></span> <span data-ttu-id="419da-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="419da-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="419da-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="419da-126">Request parameters</span></span>

| <span data-ttu-id="419da-127">名前</span><span class="sxs-lookup"><span data-stu-id="419da-127">Name</span></span>        | <span data-ttu-id="419da-128">種類</span><span class="sxs-lookup"><span data-stu-id="419da-128">Type</span></span>   | <span data-ttu-id="419da-129">説明</span><span class="sxs-lookup"><span data-stu-id="419da-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="419da-130">inAppProductId</span><span class="sxs-lookup"><span data-stu-id="419da-130">inAppProductId</span></span> | <span data-ttu-id="419da-131">string</span><span class="sxs-lookup"><span data-stu-id="419da-131">string</span></span> | <span data-ttu-id="419da-132">必須。</span><span class="sxs-lookup"><span data-stu-id="419da-132">Required.</span></span> <span data-ttu-id="419da-133">削除する申請に含まれているアドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="419da-133">The Store ID of the add-on that contains the submission to delete.</span></span> <span data-ttu-id="419da-134">ストア ID は、パートナー センターで利用できます。</span><span class="sxs-lookup"><span data-stu-id="419da-134">The Store ID is available in Partner Center.</span></span>  |
| <span data-ttu-id="419da-135">submissionId</span><span class="sxs-lookup"><span data-stu-id="419da-135">submissionId</span></span> | <span data-ttu-id="419da-136">string</span><span class="sxs-lookup"><span data-stu-id="419da-136">string</span></span> | <span data-ttu-id="419da-137">必須。</span><span class="sxs-lookup"><span data-stu-id="419da-137">Required.</span></span> <span data-ttu-id="419da-138">削除する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="419da-138">The ID of the submission to delete.</span></span> <span data-ttu-id="419da-139">この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="419da-139">This ID is available in the response data for requests to [create an add-on submission](create-an-add-on-submission.md).</span></span> <span data-ttu-id="419da-140">パートナー センターで作成された申請はこの ID はパートナー センターでの申請ページの URL で利用可能なも。</span><span class="sxs-lookup"><span data-stu-id="419da-140">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="419da-141">要求本文</span><span class="sxs-lookup"><span data-stu-id="419da-141">Request body</span></span>

<span data-ttu-id="419da-142">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="419da-142">Do not provide a request body for this method.</span></span>


### <a name="request-example"></a><span data-ttu-id="419da-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="419da-143">Request example</span></span>

<span data-ttu-id="419da-144">次の例は、アドオンの申請を削除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="419da-144">The following example demonstrates how to delete an add-on submission.</span></span>

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621230023 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="419da-145">応答</span><span class="sxs-lookup"><span data-stu-id="419da-145">Response</span></span>

<span data-ttu-id="419da-146">成功した場合、このメソッドは空の応答の本文を返します。</span><span class="sxs-lookup"><span data-stu-id="419da-146">If successful, this method returns an empty response body.</span></span>

## <a name="error-codes"></a><span data-ttu-id="419da-147">エラー コード</span><span class="sxs-lookup"><span data-stu-id="419da-147">Error codes</span></span>

<span data-ttu-id="419da-148">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="419da-148">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="419da-149">エラー コード</span><span class="sxs-lookup"><span data-stu-id="419da-149">Error code</span></span> |  <span data-ttu-id="419da-150">説明</span><span class="sxs-lookup"><span data-stu-id="419da-150">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="419da-151">400</span><span class="sxs-lookup"><span data-stu-id="419da-151">400</span></span>  | <span data-ttu-id="419da-152">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="419da-152">The request parameters are invalid.</span></span> |
| <span data-ttu-id="419da-153">404</span><span class="sxs-lookup"><span data-stu-id="419da-153">404</span></span>  | <span data-ttu-id="419da-154">指定した申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="419da-154">The specified submission could not be found.</span></span> |
| <span data-ttu-id="419da-155">409</span><span class="sxs-lookup"><span data-stu-id="419da-155">409</span></span>  | <span data-ttu-id="419da-156">指定した申請は見つかりましたが、現在の状態で削除できなかった可能性がありますかアドオンは[、Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="419da-156">The specified submission was found but it could not be deleted in its current state, or the add-on uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |


## <a name="related-topics"></a><span data-ttu-id="419da-157">関連トピック</span><span class="sxs-lookup"><span data-stu-id="419da-157">Related topics</span></span>

* [<span data-ttu-id="419da-158">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="419da-158">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="419da-159">アドオンの申請の取得</span><span class="sxs-lookup"><span data-stu-id="419da-159">Get an add-on submission</span></span>](get-an-add-on-submission.md)
* [<span data-ttu-id="419da-160">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="419da-160">Create an add-on submission</span></span>](create-an-add-on-submission.md)
* [<span data-ttu-id="419da-161">アドオンの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="419da-161">Commit an add-on submission</span></span>](commit-an-add-on-submission.md)
* [<span data-ttu-id="419da-162">アドオンの申請の更新</span><span class="sxs-lookup"><span data-stu-id="419da-162">Update an add-on submission</span></span>](update-an-add-on-submission.md)
* [<span data-ttu-id="419da-163">アドオンの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="419da-163">Get the status of an add-on submission</span></span>](get-status-for-an-add-on-submission.md)
