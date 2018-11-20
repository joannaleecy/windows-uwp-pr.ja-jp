---
author: Xansky
ms.assetid: AD80F9B3-CED0-40BD-A199-AB81CDAE466C
description: パートナー センター アカウントに登録されているアプリのパッケージ フライトを削除する、Microsoft Store 申請 API でこのメソッドを使います。
title: パッケージ フライトの削除
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの削除
ms.localizationpriority: medium
ms.openlocfilehash: 23e90a322f347375cfdb33eca9315a5ca538fd4c
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7296612"
---
# <a name="delete-a-package-flight"></a><span data-ttu-id="1ce5c-104">パッケージ フライトの削除</span><span class="sxs-lookup"><span data-stu-id="1ce5c-104">Delete a package flight</span></span>

<span data-ttu-id="1ce5c-105">パートナー センター アカウントに登録されているアプリのパッケージ フライトを削除する、Microsoft Store 申請 API でこのメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-105">Use this method in the Microsoft Store submission API to delete a package flight for an app that is registered to your Partner Center account.</span></span>


## <a name="prerequisites"></a><span data-ttu-id="1ce5c-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="1ce5c-106">Prerequisites</span></span>

<span data-ttu-id="1ce5c-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="1ce5c-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="1ce5c-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="1ce5c-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="1ce5c-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="1ce5c-112">要求</span><span class="sxs-lookup"><span data-stu-id="1ce5c-112">Request</span></span>

<span data-ttu-id="1ce5c-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-113">This method has the following syntax.</span></span> <span data-ttu-id="1ce5c-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="1ce5c-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="1ce5c-115">Method</span></span> | <span data-ttu-id="1ce5c-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="1ce5c-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="1ce5c-117">DELETE</span><span class="sxs-lookup"><span data-stu-id="1ce5c-117">DELETE</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` |


### <a name="request-header"></a><span data-ttu-id="1ce5c-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1ce5c-118">Request header</span></span>

| <span data-ttu-id="1ce5c-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1ce5c-119">Header</span></span>        | <span data-ttu-id="1ce5c-120">型</span><span class="sxs-lookup"><span data-stu-id="1ce5c-120">Type</span></span>   | <span data-ttu-id="1ce5c-121">説明</span><span class="sxs-lookup"><span data-stu-id="1ce5c-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="1ce5c-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="1ce5c-122">Authorization</span></span> | <span data-ttu-id="1ce5c-123">string</span><span class="sxs-lookup"><span data-stu-id="1ce5c-123">string</span></span> | <span data-ttu-id="1ce5c-124">必須。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-124">Required.</span></span> <span data-ttu-id="1ce5c-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="1ce5c-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="1ce5c-126">Request parameters</span></span>

| <span data-ttu-id="1ce5c-127">名前</span><span class="sxs-lookup"><span data-stu-id="1ce5c-127">Name</span></span>        | <span data-ttu-id="1ce5c-128">種類</span><span class="sxs-lookup"><span data-stu-id="1ce5c-128">Type</span></span>   | <span data-ttu-id="1ce5c-129">説明</span><span class="sxs-lookup"><span data-stu-id="1ce5c-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="1ce5c-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="1ce5c-130">applicationId</span></span> | <span data-ttu-id="1ce5c-131">string</span><span class="sxs-lookup"><span data-stu-id="1ce5c-131">string</span></span> | <span data-ttu-id="1ce5c-132">必須。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-132">Required.</span></span> <span data-ttu-id="1ce5c-133">削除するパッケージ フライトが含まれるアプリのストア ID。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-133">The Store ID of the app that contains the package flight you want to delete.</span></span> <span data-ttu-id="1ce5c-134">アプリのストア ID は、パートナー センターで利用できます。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-134">The Store ID for the app is available in Partner Center.</span></span>  |
| <span data-ttu-id="1ce5c-135">flightId</span><span class="sxs-lookup"><span data-stu-id="1ce5c-135">flightId</span></span> | <span data-ttu-id="1ce5c-136">string</span><span class="sxs-lookup"><span data-stu-id="1ce5c-136">string</span></span> | <span data-ttu-id="1ce5c-137">必須。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-137">Required.</span></span> <span data-ttu-id="1ce5c-138">削除するパッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-138">The ID of the package flight to delete.</span></span> <span data-ttu-id="1ce5c-139">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-139">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="1ce5c-140">パートナー センターで作成されたフライト、この ID はパートナー センターでのフライト ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-140">For a flight that was created in Partner Center, this ID is also available in the URL for the flight page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="1ce5c-141">要求本文</span><span class="sxs-lookup"><span data-stu-id="1ce5c-141">Request body</span></span>

<span data-ttu-id="1ce5c-142">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-142">Do not provide a request body for this method.</span></span>


### <a name="request-example"></a><span data-ttu-id="1ce5c-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="1ce5c-143">Request example</span></span>

<span data-ttu-id="1ce5c-144">次の例は、新しいパッケージ フライトを削除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-144">The following example demonstrates how to delete a package flight.</span></span>

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="1ce5c-145">応答</span><span class="sxs-lookup"><span data-stu-id="1ce5c-145">Response</span></span>

<span data-ttu-id="1ce5c-146">成功した場合、このメソッドは空の応答の本文を返します。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-146">If successful, this method returns an empty response body.</span></span>

## <a name="error-codes"></a><span data-ttu-id="1ce5c-147">エラー コード</span><span class="sxs-lookup"><span data-stu-id="1ce5c-147">Error codes</span></span>

<span data-ttu-id="1ce5c-148">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-148">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="1ce5c-149">エラー コード</span><span class="sxs-lookup"><span data-stu-id="1ce5c-149">Error code</span></span> |  <span data-ttu-id="1ce5c-150">説明</span><span class="sxs-lookup"><span data-stu-id="1ce5c-150">Description</span></span>                                                                                                                                                                           |
|--------|------------------|
| <span data-ttu-id="1ce5c-151">400</span><span class="sxs-lookup"><span data-stu-id="1ce5c-151">400</span></span>  | <span data-ttu-id="1ce5c-152">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-152">The request parameters are invalid.</span></span> |
| <span data-ttu-id="1ce5c-153">404</span><span class="sxs-lookup"><span data-stu-id="1ce5c-153">404</span></span>  | <span data-ttu-id="1ce5c-154">指定されたパッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-154">The specified package flight could not be found.</span></span>  |
| <span data-ttu-id="1ce5c-155">409</span><span class="sxs-lookup"><span data-stu-id="1ce5c-155">409</span></span>  | <span data-ttu-id="1ce5c-156">指定されたパッケージ フライトは見つかりましたが、現在の状態で削除できなかった可能性がありますか、アプリが[Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="1ce5c-156">The specified package flight was found but it could not be deleted in its current state, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="1ce5c-157">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1ce5c-157">Related topics</span></span>

* [<span data-ttu-id="1ce5c-158">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="1ce5c-158">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="1ce5c-159">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="1ce5c-159">Create a package flight</span></span>](create-a-flight.md)
* [<span data-ttu-id="1ce5c-160">パッケージ フライトの取得</span><span class="sxs-lookup"><span data-stu-id="1ce5c-160">Get a package flight</span></span>](get-a-flight.md)
