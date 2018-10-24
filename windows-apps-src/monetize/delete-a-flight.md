---
author: Xansky
ms.assetid: AD80F9B3-CED0-40BD-A199-AB81CDAE466C
description: Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトを削除するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの削除
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの削除
ms.localizationpriority: medium
ms.openlocfilehash: 436a28cc1be0c106928784086731fe078d789527
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5478378"
---
# <a name="delete-a-package-flight"></a><span data-ttu-id="97571-104">パッケージ フライトの削除</span><span class="sxs-lookup"><span data-stu-id="97571-104">Delete a package flight</span></span>

<span data-ttu-id="97571-105">Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトを削除するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="97571-105">Use this method in the Microsoft Store submission API to delete a package flight for an app that is registered to your Windows Dev Center account.</span></span>


## <a name="prerequisites"></a><span data-ttu-id="97571-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="97571-106">Prerequisites</span></span>

<span data-ttu-id="97571-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="97571-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="97571-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="97571-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="97571-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="97571-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="97571-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="97571-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="97571-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="97571-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="97571-112">要求</span><span class="sxs-lookup"><span data-stu-id="97571-112">Request</span></span>

<span data-ttu-id="97571-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="97571-113">This method has the following syntax.</span></span> <span data-ttu-id="97571-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97571-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="97571-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="97571-115">Method</span></span> | <span data-ttu-id="97571-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="97571-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="97571-117">DELETE</span><span class="sxs-lookup"><span data-stu-id="97571-117">DELETE</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` |


### <a name="request-header"></a><span data-ttu-id="97571-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="97571-118">Request header</span></span>

| <span data-ttu-id="97571-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="97571-119">Header</span></span>        | <span data-ttu-id="97571-120">型</span><span class="sxs-lookup"><span data-stu-id="97571-120">Type</span></span>   | <span data-ttu-id="97571-121">説明</span><span class="sxs-lookup"><span data-stu-id="97571-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="97571-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="97571-122">Authorization</span></span> | <span data-ttu-id="97571-123">string</span><span class="sxs-lookup"><span data-stu-id="97571-123">string</span></span> | <span data-ttu-id="97571-124">必須。</span><span class="sxs-lookup"><span data-stu-id="97571-124">Required.</span></span> <span data-ttu-id="97571-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="97571-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="97571-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="97571-126">Request parameters</span></span>

| <span data-ttu-id="97571-127">名前</span><span class="sxs-lookup"><span data-stu-id="97571-127">Name</span></span>        | <span data-ttu-id="97571-128">種類</span><span class="sxs-lookup"><span data-stu-id="97571-128">Type</span></span>   | <span data-ttu-id="97571-129">説明</span><span class="sxs-lookup"><span data-stu-id="97571-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="97571-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="97571-130">applicationId</span></span> | <span data-ttu-id="97571-131">string</span><span class="sxs-lookup"><span data-stu-id="97571-131">string</span></span> | <span data-ttu-id="97571-132">必須。</span><span class="sxs-lookup"><span data-stu-id="97571-132">Required.</span></span> <span data-ttu-id="97571-133">削除するパッケージ フライトが含まれるアプリのストア ID。</span><span class="sxs-lookup"><span data-stu-id="97571-133">The Store ID of the app that contains the package flight you want to delete.</span></span> <span data-ttu-id="97571-134">アプリのストア ID は、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="97571-134">The Store ID for the app is available on the Dev Center dashboard.</span></span>  |
| <span data-ttu-id="97571-135">flightId</span><span class="sxs-lookup"><span data-stu-id="97571-135">flightId</span></span> | <span data-ttu-id="97571-136">string</span><span class="sxs-lookup"><span data-stu-id="97571-136">string</span></span> | <span data-ttu-id="97571-137">必須。</span><span class="sxs-lookup"><span data-stu-id="97571-137">Required.</span></span> <span data-ttu-id="97571-138">削除するパッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="97571-138">The ID of the package flight to delete.</span></span> <span data-ttu-id="97571-139">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="97571-139">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="97571-140">デベロッパー センター ダッシュボードで作成されたフライトの場合、この ID はダッシュボードのフライト ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="97571-140">For a flight that was created in the Dev Center dashboard, this ID is also available in the URL for the flight page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="97571-141">要求本文</span><span class="sxs-lookup"><span data-stu-id="97571-141">Request body</span></span>

<span data-ttu-id="97571-142">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="97571-142">Do not provide a request body for this method.</span></span>


### <a name="request-example"></a><span data-ttu-id="97571-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="97571-143">Request example</span></span>

<span data-ttu-id="97571-144">次の例は、新しいパッケージ フライトを削除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="97571-144">The following example demonstrates how to delete a package flight.</span></span>

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="97571-145">応答</span><span class="sxs-lookup"><span data-stu-id="97571-145">Response</span></span>

<span data-ttu-id="97571-146">成功した場合、このメソッドは空の応答の本文を返します。</span><span class="sxs-lookup"><span data-stu-id="97571-146">If successful, this method returns an empty response body.</span></span>

## <a name="error-codes"></a><span data-ttu-id="97571-147">エラー コード</span><span class="sxs-lookup"><span data-stu-id="97571-147">Error codes</span></span>

<span data-ttu-id="97571-148">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="97571-148">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="97571-149">エラー コード</span><span class="sxs-lookup"><span data-stu-id="97571-149">Error code</span></span> |  <span data-ttu-id="97571-150">説明</span><span class="sxs-lookup"><span data-stu-id="97571-150">Description</span></span>                                                                                                                                                                           |
|--------|------------------|
| <span data-ttu-id="97571-151">400</span><span class="sxs-lookup"><span data-stu-id="97571-151">400</span></span>  | <span data-ttu-id="97571-152">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="97571-152">The request parameters are invalid.</span></span> |
| <span data-ttu-id="97571-153">404</span><span class="sxs-lookup"><span data-stu-id="97571-153">404</span></span>  | <span data-ttu-id="97571-154">指定されたパッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="97571-154">The specified package flight could not be found.</span></span>  |
| <span data-ttu-id="97571-155">409</span><span class="sxs-lookup"><span data-stu-id="97571-155">409</span></span>  | <span data-ttu-id="97571-156">指定したパッケージ フライトは見つかりましたが、現在の状態で削除できなかったか、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。</span><span class="sxs-lookup"><span data-stu-id="97571-156">The specified package flight was found but it could not be deleted in its current state, or the app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="97571-157">関連トピック</span><span class="sxs-lookup"><span data-stu-id="97571-157">Related topics</span></span>

* [<span data-ttu-id="97571-158">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="97571-158">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="97571-159">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="97571-159">Create a package flight</span></span>](create-a-flight.md)
* [<span data-ttu-id="97571-160">パッケージ フライトの取得</span><span class="sxs-lookup"><span data-stu-id="97571-160">Get a package flight</span></span>](get-a-flight.md)
