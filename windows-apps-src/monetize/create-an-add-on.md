---
author: Xansky
ms.assetid: 5BD650D2-AA26-4DE9-8243-374FDB7D932B
description: Windows デベロッパー センター アカウントに登録されているアプリのアドオンを作成するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの作成
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの作成, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 36b6be05d1efc1cbc23f26a509230750c8896c87
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5868231"
---
# <a name="create-an-add-on"></a><span data-ttu-id="21426-104">アドオンの作成</span><span class="sxs-lookup"><span data-stu-id="21426-104">Create an add-on</span></span>

<span data-ttu-id="21426-105">Windows デベロッパー センター アカウントに登録されているアプリのアドオン (アプリ内製品または IAP とも呼ばれます) を作成するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="21426-105">Use this method in the Microsoft Store submission API to create an add-on (also known as in-app product or IAP) for an app that is registered to your Windows Dev Center account.</span></span>

> [!NOTE]
> <span data-ttu-id="21426-106">このメソッドは、申請なしでアドオンを作成します。</span><span class="sxs-lookup"><span data-stu-id="21426-106">This method creates an add-on without any submissions.</span></span> <span data-ttu-id="21426-107">アドオンの申請を作成する方法については、「[アドオンの申請の管理](manage-add-on-submissions.md)」のメソッドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21426-107">To create a submission for an add-on, see the methods in [Manage add-on submissions](manage-add-on-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="21426-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="21426-108">Prerequisites</span></span>

<span data-ttu-id="21426-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="21426-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="21426-110">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="21426-110">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="21426-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="21426-111">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="21426-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="21426-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="21426-113">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="21426-113">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="21426-114">要求</span><span class="sxs-lookup"><span data-stu-id="21426-114">Request</span></span>

<span data-ttu-id="21426-115">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="21426-115">This method has the following syntax.</span></span> <span data-ttu-id="21426-116">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21426-116">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="21426-117">メソッド</span><span class="sxs-lookup"><span data-stu-id="21426-117">Method</span></span> | <span data-ttu-id="21426-118">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21426-118">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="21426-119">POST</span><span class="sxs-lookup"><span data-stu-id="21426-119">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts``` |


### <a name="request-header"></a><span data-ttu-id="21426-120">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21426-120">Request header</span></span>

| <span data-ttu-id="21426-121">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21426-121">Header</span></span>        | <span data-ttu-id="21426-122">型</span><span class="sxs-lookup"><span data-stu-id="21426-122">Type</span></span>   | <span data-ttu-id="21426-123">説明</span><span class="sxs-lookup"><span data-stu-id="21426-123">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="21426-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="21426-124">Authorization</span></span> | <span data-ttu-id="21426-125">string</span><span class="sxs-lookup"><span data-stu-id="21426-125">string</span></span> | <span data-ttu-id="21426-126">必須。</span><span class="sxs-lookup"><span data-stu-id="21426-126">Required.</span></span> <span data-ttu-id="21426-127">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="21426-127">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-body"></a><span data-ttu-id="21426-128">要求本文</span><span class="sxs-lookup"><span data-stu-id="21426-128">Request body</span></span>

<span data-ttu-id="21426-129">要求本文には次のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="21426-129">The request body has the following parameters.</span></span>

|  <span data-ttu-id="21426-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="21426-130">Parameter</span></span>  |  <span data-ttu-id="21426-131">型</span><span class="sxs-lookup"><span data-stu-id="21426-131">Type</span></span>  |  <span data-ttu-id="21426-132">説明</span><span class="sxs-lookup"><span data-stu-id="21426-132">Description</span></span>  |  <span data-ttu-id="21426-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="21426-133">Required</span></span>  |
|------|------|------|------|
|  <span data-ttu-id="21426-134">applicationIds</span><span class="sxs-lookup"><span data-stu-id="21426-134">applicationIds</span></span>  |  <span data-ttu-id="21426-135">array</span><span class="sxs-lookup"><span data-stu-id="21426-135">array</span></span>  |  <span data-ttu-id="21426-136">このアドオンが関連付けられるアプリのストア ID を含む配列です。</span><span class="sxs-lookup"><span data-stu-id="21426-136">An array that contains the Store ID of the app that this add-on is associated with.</span></span> <span data-ttu-id="21426-137">この配列でサポートされる項目は 1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="21426-137">Only one item is supported in this array.</span></span>   |  <span data-ttu-id="21426-138">はい</span><span class="sxs-lookup"><span data-stu-id="21426-138">Yes</span></span>  |
|  <span data-ttu-id="21426-139">productId</span><span class="sxs-lookup"><span data-stu-id="21426-139">productId</span></span>  |  <span data-ttu-id="21426-140">string</span><span class="sxs-lookup"><span data-stu-id="21426-140">string</span></span>  |  <span data-ttu-id="21426-141">アドオンの製品 ID です。</span><span class="sxs-lookup"><span data-stu-id="21426-141">The product ID of the add-on.</span></span> <span data-ttu-id="21426-142">これは、アドオンを参照する、コード内で使用できる識別子です。</span><span class="sxs-lookup"><span data-stu-id="21426-142">This is an identifier that can use in code to refer to the add-on.</span></span> <span data-ttu-id="21426-143">詳しくは、「[IAP の製品の種類と製品 ID を設定する](https://msdn.microsoft.com/windows/uwp/publish/set-your-iap-product-id)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21426-143">For more information, see [Set your product type and product ID](https://msdn.microsoft.com/windows/uwp/publish/set-your-iap-product-id).</span></span>  |  <span data-ttu-id="21426-144">はい</span><span class="sxs-lookup"><span data-stu-id="21426-144">Yes</span></span>  |
|  <span data-ttu-id="21426-145">productType</span><span class="sxs-lookup"><span data-stu-id="21426-145">productType</span></span>  |  <span data-ttu-id="21426-146">string</span><span class="sxs-lookup"><span data-stu-id="21426-146">string</span></span>  |  <span data-ttu-id="21426-147">アドオンの製品の種類です。</span><span class="sxs-lookup"><span data-stu-id="21426-147">The product type of the add-on.</span></span> <span data-ttu-id="21426-148">値 **Durable** と **Consumable** がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="21426-148">The following values are supported: **Durable** and **Consumable**.</span></span>  |  <span data-ttu-id="21426-149">はい</span><span class="sxs-lookup"><span data-stu-id="21426-149">Yes</span></span>  |


### <a name="request-example"></a><span data-ttu-id="21426-150">要求の例</span><span class="sxs-lookup"><span data-stu-id="21426-150">Request example</span></span>

<span data-ttu-id="21426-151">次の例は、アプリの新しいコンシューマブルなアドオンを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="21426-151">The following example demonstrates how to create a new consumable add-on for an app.</span></span>

```syntax
POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts HTTP/1.1
Authorization: Bearer eyJ0eXAiOiJKV1Q...
Content-Type: application/json
{
    "applicationIds": [  "9NBLGGH4R315"  ],
    "productId": "my-new-add-on",
    "productType": "Consumable",
}
```

## <a name="response"></a><span data-ttu-id="21426-152">応答</span><span class="sxs-lookup"><span data-stu-id="21426-152">Response</span></span>

<span data-ttu-id="21426-153">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="21426-153">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="21426-154">応答の本文内の値について詳しくは、[アドオンのリソース](manage-add-ons.md#add-on-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21426-154">For more details about the values in the response body, see [add-on resource](manage-add-ons.md#add-on-object).</span></span>

```json
{
  "applications": {
    "value": [
      {
        "id": "9NBLGGH4R315",
        "resourceLocation": "applications/9NBLGGH4R315"
      }
    ],
    "totalCount": 1
  },
  "id": "9NBLGGH4TNMP",
  "productId": "my-new-add-on",
  "productType": "Consumable",
}
```

## <a name="error-codes"></a><span data-ttu-id="21426-155">エラー コード</span><span class="sxs-lookup"><span data-stu-id="21426-155">Error codes</span></span>

<span data-ttu-id="21426-156">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="21426-156">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="21426-157">エラー コード</span><span class="sxs-lookup"><span data-stu-id="21426-157">Error code</span></span> |  <span data-ttu-id="21426-158">説明</span><span class="sxs-lookup"><span data-stu-id="21426-158">Description</span></span>                                                                                                                                                                           |
|--------|------------------|
| <span data-ttu-id="21426-159">400</span><span class="sxs-lookup"><span data-stu-id="21426-159">400</span></span>  | <span data-ttu-id="21426-160">要求が無効です。</span><span class="sxs-lookup"><span data-stu-id="21426-160">The request is invalid.</span></span> |
| <span data-ttu-id="21426-161">409</span><span class="sxs-lookup"><span data-stu-id="21426-161">409</span></span>  | <span data-ttu-id="21426-162">現在の状態が原因でアドオンを作成できませんでした。または、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアドオンで使用されています。</span><span class="sxs-lookup"><span data-stu-id="21426-162">The add-on could not be created because of its current state, or the add-on uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="21426-163">関連トピック</span><span class="sxs-lookup"><span data-stu-id="21426-163">Related topics</span></span>

* [<span data-ttu-id="21426-164">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="21426-164">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="21426-165">アドオンの申請の管理</span><span class="sxs-lookup"><span data-stu-id="21426-165">Manage add-on submissions</span></span>](manage-add-on-submissions.md)
* [<span data-ttu-id="21426-166">すべてのアドオンの入手</span><span class="sxs-lookup"><span data-stu-id="21426-166">Get all add-ons</span></span>](get-all-add-ons.md)
* [<span data-ttu-id="21426-167">アドオンの入手</span><span class="sxs-lookup"><span data-stu-id="21426-167">Get an add-on</span></span>](get-an-add-on.md)
* [<span data-ttu-id="21426-168">アドオンの削除</span><span class="sxs-lookup"><span data-stu-id="21426-168">Delete an add-on</span></span>](delete-an-add-on.md)
