---
ms.assetid: AD80F9B3-CED0-40BD-A199-AB81CDAE466C
description: Microsoft Store 送信 API でこのメソッドを使用して、パートナー センター アカウントに登録されているアプリのパッケージのフライトを削除します。
title: パッケージ フライトの削除
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの削除
ms.localizationpriority: medium
ms.openlocfilehash: a3455973d86b0c9e7c779cca429e36fa32266ed6
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58335110"
---
# <a name="delete-a-package-flight"></a><span data-ttu-id="d26fd-104">パッケージ フライトの削除</span><span class="sxs-lookup"><span data-stu-id="d26fd-104">Delete a package flight</span></span>

<span data-ttu-id="d26fd-105">Microsoft Store 送信 API でこのメソッドを使用して、パートナー センター アカウントに登録されているアプリのパッケージのフライトを削除します。</span><span class="sxs-lookup"><span data-stu-id="d26fd-105">Use this method in the Microsoft Store submission API to delete a package flight for an app that is registered to your Partner Center account.</span></span>


## <a name="prerequisites"></a><span data-ttu-id="d26fd-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="d26fd-106">Prerequisites</span></span>

<span data-ttu-id="d26fd-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d26fd-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="d26fd-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="d26fd-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="d26fd-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="d26fd-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="d26fd-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="d26fd-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="d26fd-111">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d26fd-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="d26fd-112">要求</span><span class="sxs-lookup"><span data-stu-id="d26fd-112">Request</span></span>

<span data-ttu-id="d26fd-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="d26fd-113">This method has the following syntax.</span></span> <span data-ttu-id="d26fd-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d26fd-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="d26fd-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="d26fd-115">Method</span></span> | <span data-ttu-id="d26fd-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="d26fd-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="d26fd-117">Del</span><span class="sxs-lookup"><span data-stu-id="d26fd-117">DELETE</span></span>    | `https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}` |


### <a name="request-header"></a><span data-ttu-id="d26fd-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d26fd-118">Request header</span></span>

| <span data-ttu-id="d26fd-119">Header</span><span class="sxs-lookup"><span data-stu-id="d26fd-119">Header</span></span>        | <span data-ttu-id="d26fd-120">種類</span><span class="sxs-lookup"><span data-stu-id="d26fd-120">Type</span></span>   | <span data-ttu-id="d26fd-121">説明</span><span class="sxs-lookup"><span data-stu-id="d26fd-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d26fd-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="d26fd-122">Authorization</span></span> | <span data-ttu-id="d26fd-123">string</span><span class="sxs-lookup"><span data-stu-id="d26fd-123">string</span></span> | <span data-ttu-id="d26fd-124">必須。</span><span class="sxs-lookup"><span data-stu-id="d26fd-124">Required.</span></span> <span data-ttu-id="d26fd-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="d26fd-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="d26fd-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="d26fd-126">Request parameters</span></span>

| <span data-ttu-id="d26fd-127">名前</span><span class="sxs-lookup"><span data-stu-id="d26fd-127">Name</span></span>        | <span data-ttu-id="d26fd-128">種類</span><span class="sxs-lookup"><span data-stu-id="d26fd-128">Type</span></span>   | <span data-ttu-id="d26fd-129">説明</span><span class="sxs-lookup"><span data-stu-id="d26fd-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d26fd-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="d26fd-130">applicationId</span></span> | <span data-ttu-id="d26fd-131">string</span><span class="sxs-lookup"><span data-stu-id="d26fd-131">string</span></span> | <span data-ttu-id="d26fd-132">必須。</span><span class="sxs-lookup"><span data-stu-id="d26fd-132">Required.</span></span> <span data-ttu-id="d26fd-133">削除するパッケージ フライトが含まれるアプリのストア ID。</span><span class="sxs-lookup"><span data-stu-id="d26fd-133">The Store ID of the app that contains the package flight you want to delete.</span></span> <span data-ttu-id="d26fd-134">アプリの Store ID は、パートナー センターで使用できます。</span><span class="sxs-lookup"><span data-stu-id="d26fd-134">The Store ID for the app is available in Partner Center.</span></span>  |
| <span data-ttu-id="d26fd-135">flightId</span><span class="sxs-lookup"><span data-stu-id="d26fd-135">flightId</span></span> | <span data-ttu-id="d26fd-136">string</span><span class="sxs-lookup"><span data-stu-id="d26fd-136">string</span></span> | <span data-ttu-id="d26fd-137">必須。</span><span class="sxs-lookup"><span data-stu-id="d26fd-137">Required.</span></span> <span data-ttu-id="d26fd-138">削除するパッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="d26fd-138">The ID of the package flight to delete.</span></span> <span data-ttu-id="d26fd-139">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="d26fd-139">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="d26fd-140">パートナー センターで作成されたフライトはこの ID はパートナー センターでのフライトのページの URL で使用できるも。</span><span class="sxs-lookup"><span data-stu-id="d26fd-140">For a flight that was created in Partner Center, this ID is also available in the URL for the flight page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="d26fd-141">要求本文</span><span class="sxs-lookup"><span data-stu-id="d26fd-141">Request body</span></span>

<span data-ttu-id="d26fd-142">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="d26fd-142">Do not provide a request body for this method.</span></span>


### <a name="request-example"></a><span data-ttu-id="d26fd-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="d26fd-143">Request example</span></span>

<span data-ttu-id="d26fd-144">次の例は、新しいパッケージ フライトを削除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d26fd-144">The following example demonstrates how to delete a package flight.</span></span>

```json
DELETE https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="d26fd-145">応答</span><span class="sxs-lookup"><span data-stu-id="d26fd-145">Response</span></span>

<span data-ttu-id="d26fd-146">成功した場合、このメソッドは空の応答の本文を返します。</span><span class="sxs-lookup"><span data-stu-id="d26fd-146">If successful, this method returns an empty response body.</span></span>

## <a name="error-codes"></a><span data-ttu-id="d26fd-147">エラー コード</span><span class="sxs-lookup"><span data-stu-id="d26fd-147">Error codes</span></span>

<span data-ttu-id="d26fd-148">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="d26fd-148">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="d26fd-149">エラー コード</span><span class="sxs-lookup"><span data-stu-id="d26fd-149">Error code</span></span> |  <span data-ttu-id="d26fd-150">説明</span><span class="sxs-lookup"><span data-stu-id="d26fd-150">Description</span></span>                                                                                                                                                                           |
|--------|------------------|
| <span data-ttu-id="d26fd-151">400</span><span class="sxs-lookup"><span data-stu-id="d26fd-151">400</span></span>  | <span data-ttu-id="d26fd-152">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="d26fd-152">The request parameters are invalid.</span></span> |
| <span data-ttu-id="d26fd-153">404</span><span class="sxs-lookup"><span data-stu-id="d26fd-153">404</span></span>  | <span data-ttu-id="d26fd-154">指定されたパッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="d26fd-154">The specified package flight could not be found.</span></span>  |
| <span data-ttu-id="d26fd-155">409</span><span class="sxs-lookup"><span data-stu-id="d26fd-155">409</span></span>  | <span data-ttu-id="d26fd-156">指定したパッケージのフライトが見つかりましたが、現在の状態で削除できませんでしたまたはアプリであるパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。</span><span class="sxs-lookup"><span data-stu-id="d26fd-156">The specified package flight was found but it could not be deleted in its current state, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="d26fd-157">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d26fd-157">Related topics</span></span>

* [<span data-ttu-id="d26fd-158">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="d26fd-158">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="d26fd-159">パッケージをフライトします。</span><span class="sxs-lookup"><span data-stu-id="d26fd-159">Create a package flight</span></span>](create-a-flight.md)
* [<span data-ttu-id="d26fd-160">パッケージのフライトを取得します。</span><span class="sxs-lookup"><span data-stu-id="d26fd-160">Get a package flight</span></span>](get-a-flight.md)
