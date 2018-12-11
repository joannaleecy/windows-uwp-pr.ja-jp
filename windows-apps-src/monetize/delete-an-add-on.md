---
ms.assetid: 16D4C3B9-FC9B-46ED-9F87-1517E1B549FA
description: パートナー センター アカウントに登録されているアプリのアドオンを削除する、Microsoft Store 申請 API でこのメソッドを使います。
title: アドオンの削除
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオン, 削除, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 837cbc19268a88be986068f4a5e60002a1eb55e2
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8829576"
---
# <a name="delete-an-add-on"></a><span data-ttu-id="a2bc9-104">アドオンの削除</span><span class="sxs-lookup"><span data-stu-id="a2bc9-104">Delete an add-on</span></span>

<span data-ttu-id="a2bc9-105">パートナー センター アカウントに登録されているアプリのアドオン (別名アプリ内製品または IAP) を削除する、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-105">Use this method in the Microsoft Store submission API to delete an add-on (also known as in-app product or IAP) for an app that is registered to your Partner Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="a2bc9-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="a2bc9-106">Prerequisites</span></span>

<span data-ttu-id="a2bc9-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="a2bc9-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="a2bc9-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="a2bc9-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="a2bc9-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="a2bc9-112">要求</span><span class="sxs-lookup"><span data-stu-id="a2bc9-112">Request</span></span>

<span data-ttu-id="a2bc9-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-113">This method has the following syntax.</span></span> <span data-ttu-id="a2bc9-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="a2bc9-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="a2bc9-115">Method</span></span> | <span data-ttu-id="a2bc9-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a2bc9-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="a2bc9-117">DELETE</span><span class="sxs-lookup"><span data-stu-id="a2bc9-117">DELETE</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}``` |


### <a name="request-header"></a><span data-ttu-id="a2bc9-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a2bc9-118">Request header</span></span>

| <span data-ttu-id="a2bc9-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a2bc9-119">Header</span></span>        | <span data-ttu-id="a2bc9-120">型</span><span class="sxs-lookup"><span data-stu-id="a2bc9-120">Type</span></span>   | <span data-ttu-id="a2bc9-121">説明</span><span class="sxs-lookup"><span data-stu-id="a2bc9-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="a2bc9-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="a2bc9-122">Authorization</span></span> | <span data-ttu-id="a2bc9-123">string</span><span class="sxs-lookup"><span data-stu-id="a2bc9-123">string</span></span> | <span data-ttu-id="a2bc9-124">必須。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-124">Required.</span></span> <span data-ttu-id="a2bc9-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="a2bc9-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="a2bc9-126">Request parameters</span></span>

| <span data-ttu-id="a2bc9-127">名前</span><span class="sxs-lookup"><span data-stu-id="a2bc9-127">Name</span></span>        | <span data-ttu-id="a2bc9-128">種類</span><span class="sxs-lookup"><span data-stu-id="a2bc9-128">Type</span></span>   | <span data-ttu-id="a2bc9-129">説明</span><span class="sxs-lookup"><span data-stu-id="a2bc9-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="a2bc9-130">id</span><span class="sxs-lookup"><span data-stu-id="a2bc9-130">id</span></span> | <span data-ttu-id="a2bc9-131">string</span><span class="sxs-lookup"><span data-stu-id="a2bc9-131">string</span></span> | <span data-ttu-id="a2bc9-132">必須。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-132">Required.</span></span> <span data-ttu-id="a2bc9-133">削除するアドオンのストア ID。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-133">The Store ID of the add-on to delete.</span></span> <span data-ttu-id="a2bc9-134">ストア ID は、パートナー センターで利用できます。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-134">The Store ID is available in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="a2bc9-135">要求本文</span><span class="sxs-lookup"><span data-stu-id="a2bc9-135">Request body</span></span>

<span data-ttu-id="a2bc9-136">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-136">Do not provide a request body for this method.</span></span>


### <a name="request-example"></a><span data-ttu-id="a2bc9-137">要求の例</span><span class="sxs-lookup"><span data-stu-id="a2bc9-137">Request example</span></span>

<span data-ttu-id="a2bc9-138">次の例は、アドオンを削除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-138">The following example demonstrates how to delete an add-on.</span></span>

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="a2bc9-139">応答</span><span class="sxs-lookup"><span data-stu-id="a2bc9-139">Response</span></span>

<span data-ttu-id="a2bc9-140">成功した場合、このメソッドは空の応答の本文を返します。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-140">If successful, this method returns an empty response body.</span></span>

## <a name="error-codes"></a><span data-ttu-id="a2bc9-141">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a2bc9-141">Error codes</span></span>

<span data-ttu-id="a2bc9-142">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-142">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="a2bc9-143">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a2bc9-143">Error code</span></span> |  <span data-ttu-id="a2bc9-144">説明</span><span class="sxs-lookup"><span data-stu-id="a2bc9-144">Description</span></span>                                                                                                                                                                           |
|--------|------------------|
| <span data-ttu-id="a2bc9-145">400</span><span class="sxs-lookup"><span data-stu-id="a2bc9-145">400</span></span>  | <span data-ttu-id="a2bc9-146">要求が無効です。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-146">The request is invalid.</span></span> |
| <span data-ttu-id="a2bc9-147">404</span><span class="sxs-lookup"><span data-stu-id="a2bc9-147">404</span></span>  | <span data-ttu-id="a2bc9-148">指定したアドオンは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-148">The specified add-on could not be found.</span></span>  |
| <span data-ttu-id="a2bc9-149">409</span><span class="sxs-lookup"><span data-stu-id="a2bc9-149">409</span></span>  | <span data-ttu-id="a2bc9-150">指定したアドオンは見つかりましたが、現在の状態で削除できなかった可能性がありますか、アドオンが[Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="a2bc9-150">The specified add-on was found but it could not be deleted in its current state, or the add-on uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="a2bc9-151">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a2bc9-151">Related topics</span></span>

* [<span data-ttu-id="a2bc9-152">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="a2bc9-152">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="a2bc9-153">すべてのアドオンの取得</span><span class="sxs-lookup"><span data-stu-id="a2bc9-153">Get all add-ons</span></span>](get-all-add-ons.md)
* [<span data-ttu-id="a2bc9-154">アドオンの入手</span><span class="sxs-lookup"><span data-stu-id="a2bc9-154">Get an add-on</span></span>](get-an-add-on.md)
* [<span data-ttu-id="a2bc9-155">アドオンの作成</span><span class="sxs-lookup"><span data-stu-id="a2bc9-155">Create an add-on</span></span>](create-an-add-on.md)
