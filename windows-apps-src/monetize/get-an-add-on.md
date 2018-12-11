---
ms.assetid: 78278741-09A4-4406-A112-9AF3C73F5C16
description: パートナー センター アカウントに登録されているアプリのアドオンに関する情報を取得する、Microsoft Store 申請 API でこのメソッドを使います。
title: アドオンの入手
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオン, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: cc02cd5ae94b51b274c0e3ce1245020222e101f1
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8889823"
---
# <a name="get-an-add-on"></a><span data-ttu-id="cceaa-104">アドオンの入手</span><span class="sxs-lookup"><span data-stu-id="cceaa-104">Get an add-on</span></span>

<span data-ttu-id="cceaa-105">パートナー センター アカウントに登録されているアプリのアドオン (別名アプリ内製品または IAP) に関する情報を取得、Microsoft Store 申請 API でこのメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="cceaa-105">Use this method in the Microsoft Store submission API to retrieve information about an add-on (also known as in-app product or IAP) for an app that is registered to your Partner Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="cceaa-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="cceaa-106">Prerequisites</span></span>

<span data-ttu-id="cceaa-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="cceaa-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="cceaa-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="cceaa-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="cceaa-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="cceaa-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="cceaa-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="cceaa-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="cceaa-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="cceaa-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="cceaa-112">要求</span><span class="sxs-lookup"><span data-stu-id="cceaa-112">Request</span></span>

<span data-ttu-id="cceaa-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="cceaa-113">This method has the following syntax.</span></span> <span data-ttu-id="cceaa-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cceaa-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="cceaa-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="cceaa-115">Method</span></span> | <span data-ttu-id="cceaa-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="cceaa-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="cceaa-117">GET</span><span class="sxs-lookup"><span data-stu-id="cceaa-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}``` |


### <a name="request-header"></a><span data-ttu-id="cceaa-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cceaa-118">Request header</span></span>

| <span data-ttu-id="cceaa-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cceaa-119">Header</span></span>        | <span data-ttu-id="cceaa-120">型</span><span class="sxs-lookup"><span data-stu-id="cceaa-120">Type</span></span>   | <span data-ttu-id="cceaa-121">説明</span><span class="sxs-lookup"><span data-stu-id="cceaa-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="cceaa-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="cceaa-122">Authorization</span></span> | <span data-ttu-id="cceaa-123">string</span><span class="sxs-lookup"><span data-stu-id="cceaa-123">string</span></span> | <span data-ttu-id="cceaa-124">必須。</span><span class="sxs-lookup"><span data-stu-id="cceaa-124">Required.</span></span> <span data-ttu-id="cceaa-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="cceaa-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="cceaa-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="cceaa-126">Request parameters</span></span>

| <span data-ttu-id="cceaa-127">名前</span><span class="sxs-lookup"><span data-stu-id="cceaa-127">Name</span></span>        | <span data-ttu-id="cceaa-128">種類</span><span class="sxs-lookup"><span data-stu-id="cceaa-128">Type</span></span>   | <span data-ttu-id="cceaa-129">説明</span><span class="sxs-lookup"><span data-stu-id="cceaa-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="cceaa-130">id</span><span class="sxs-lookup"><span data-stu-id="cceaa-130">id</span></span> | <span data-ttu-id="cceaa-131">string</span><span class="sxs-lookup"><span data-stu-id="cceaa-131">string</span></span> | <span data-ttu-id="cceaa-132">必須。</span><span class="sxs-lookup"><span data-stu-id="cceaa-132">Required.</span></span> <span data-ttu-id="cceaa-133">取得するアドオンのストア ID。</span><span class="sxs-lookup"><span data-stu-id="cceaa-133">The Store ID of the add-on to retrieve.</span></span> <span data-ttu-id="cceaa-134">ストア ID は、パートナー センターで利用できます。</span><span class="sxs-lookup"><span data-stu-id="cceaa-134">The Store ID is available in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="cceaa-135">要求本文</span><span class="sxs-lookup"><span data-stu-id="cceaa-135">Request body</span></span>

<span data-ttu-id="cceaa-136">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="cceaa-136">Do not provide a request body for this method.</span></span>


### <a name="request-example"></a><span data-ttu-id="cceaa-137">要求の例</span><span class="sxs-lookup"><span data-stu-id="cceaa-137">Request example</span></span>

<span data-ttu-id="cceaa-138">次の例は、アドオンの情報を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="cceaa-138">The following example demonstrates how to retrieve information about an add-on.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="cceaa-139">応答</span><span class="sxs-lookup"><span data-stu-id="cceaa-139">Response</span></span>

<span data-ttu-id="cceaa-140">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="cceaa-140">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="cceaa-141">応答の本文内の値について詳しくは、[アドオンのリソース](manage-add-ons.md#add-on-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cceaa-141">For more details about the values in the response body, see [add-on resource](manage-add-ons.md#add-on-object).</span></span>

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
  "productId": "Test-add-on",
  "productType": "Durable",
  "pendingInAppProductSubmission": {
    "id": "1152921504621243619",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243619"
  },
  "lastPublishedInAppProductSubmission": {
    "id": "1152921504621243705",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243705"
  }
}
```

## <a name="error-codes"></a><span data-ttu-id="cceaa-142">エラー コード</span><span class="sxs-lookup"><span data-stu-id="cceaa-142">Error codes</span></span>

<span data-ttu-id="cceaa-143">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="cceaa-143">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="cceaa-144">エラー コード</span><span class="sxs-lookup"><span data-stu-id="cceaa-144">Error code</span></span> |  <span data-ttu-id="cceaa-145">説明</span><span class="sxs-lookup"><span data-stu-id="cceaa-145">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="cceaa-146">404</span><span class="sxs-lookup"><span data-stu-id="cceaa-146">404</span></span>  | <span data-ttu-id="cceaa-147">指定したアドオンは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="cceaa-147">The specified add-on could not be found.</span></span> |
| <span data-ttu-id="cceaa-148">409</span><span class="sxs-lookup"><span data-stu-id="cceaa-148">409</span></span>  | <span data-ttu-id="cceaa-149">アドオンは、 [Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センターの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="cceaa-149">The add-on uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="cceaa-150">関連トピック</span><span class="sxs-lookup"><span data-stu-id="cceaa-150">Related topics</span></span>

* [<span data-ttu-id="cceaa-151">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="cceaa-151">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="cceaa-152">アドオンの申請の管理</span><span class="sxs-lookup"><span data-stu-id="cceaa-152">Manage add-on submissions</span></span>](manage-add-on-submissions.md)
* [<span data-ttu-id="cceaa-153">すべてのアドオンの入手</span><span class="sxs-lookup"><span data-stu-id="cceaa-153">Get all add-ons</span></span>](get-all-add-ons.md)
* [<span data-ttu-id="cceaa-154">アドオンの作成</span><span class="sxs-lookup"><span data-stu-id="cceaa-154">Create an add-on</span></span>](create-an-add-on.md)
* [<span data-ttu-id="cceaa-155">アドオンの削除</span><span class="sxs-lookup"><span data-stu-id="cceaa-155">Delete an add-on</span></span>](delete-an-add-on.md)
