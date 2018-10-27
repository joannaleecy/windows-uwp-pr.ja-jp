---
author: Xansky
ms.assetid: 78278741-09A4-4406-A112-9AF3C73F5C16
description: Windows デベロッパー センター アカウントに登録されているアプリのアドオンに関する情報を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの取得
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオン, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 36638c3e3890d5e2bca149d1006469bb97057f05
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5685970"
---
# <a name="get-an-add-on"></a><span data-ttu-id="d670c-104">アドオンの取得</span><span class="sxs-lookup"><span data-stu-id="d670c-104">Get an add-on</span></span>

<span data-ttu-id="d670c-105">Windows デベロッパー センター アカウントに登録されているアプリのアドオン (アプリ内製品または IAP とも呼ばれます) に関する情報を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="d670c-105">Use this method in the Microsoft Store submission API to retrieve information about an add-on (also known as in-app product or IAP) for an app that is registered to your Windows Dev Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d670c-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="d670c-106">Prerequisites</span></span>

<span data-ttu-id="d670c-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d670c-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="d670c-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="d670c-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="d670c-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="d670c-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="d670c-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="d670c-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="d670c-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d670c-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="d670c-112">要求</span><span class="sxs-lookup"><span data-stu-id="d670c-112">Request</span></span>

<span data-ttu-id="d670c-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="d670c-113">This method has the following syntax.</span></span> <span data-ttu-id="d670c-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d670c-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="d670c-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="d670c-115">Method</span></span> | <span data-ttu-id="d670c-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="d670c-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="d670c-117">GET</span><span class="sxs-lookup"><span data-stu-id="d670c-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}``` |


### <a name="request-header"></a><span data-ttu-id="d670c-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d670c-118">Request header</span></span>

| <span data-ttu-id="d670c-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d670c-119">Header</span></span>        | <span data-ttu-id="d670c-120">型</span><span class="sxs-lookup"><span data-stu-id="d670c-120">Type</span></span>   | <span data-ttu-id="d670c-121">説明</span><span class="sxs-lookup"><span data-stu-id="d670c-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d670c-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="d670c-122">Authorization</span></span> | <span data-ttu-id="d670c-123">string</span><span class="sxs-lookup"><span data-stu-id="d670c-123">string</span></span> | <span data-ttu-id="d670c-124">必須。</span><span class="sxs-lookup"><span data-stu-id="d670c-124">Required.</span></span> <span data-ttu-id="d670c-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="d670c-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="d670c-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="d670c-126">Request parameters</span></span>

| <span data-ttu-id="d670c-127">名前</span><span class="sxs-lookup"><span data-stu-id="d670c-127">Name</span></span>        | <span data-ttu-id="d670c-128">種類</span><span class="sxs-lookup"><span data-stu-id="d670c-128">Type</span></span>   | <span data-ttu-id="d670c-129">説明</span><span class="sxs-lookup"><span data-stu-id="d670c-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d670c-130">id</span><span class="sxs-lookup"><span data-stu-id="d670c-130">id</span></span> | <span data-ttu-id="d670c-131">string</span><span class="sxs-lookup"><span data-stu-id="d670c-131">string</span></span> | <span data-ttu-id="d670c-132">必須。</span><span class="sxs-lookup"><span data-stu-id="d670c-132">Required.</span></span> <span data-ttu-id="d670c-133">取得するアドオンのストア ID。</span><span class="sxs-lookup"><span data-stu-id="d670c-133">The Store ID of the add-on to retrieve.</span></span> <span data-ttu-id="d670c-134">ストア ID はデベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="d670c-134">The Store ID is available on the Dev Center dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="d670c-135">要求本文</span><span class="sxs-lookup"><span data-stu-id="d670c-135">Request body</span></span>

<span data-ttu-id="d670c-136">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="d670c-136">Do not provide a request body for this method.</span></span>


### <a name="request-example"></a><span data-ttu-id="d670c-137">要求の例</span><span class="sxs-lookup"><span data-stu-id="d670c-137">Request example</span></span>

<span data-ttu-id="d670c-138">次の例は、アドオンの情報を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d670c-138">The following example demonstrates how to retrieve information about an add-on.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="d670c-139">応答</span><span class="sxs-lookup"><span data-stu-id="d670c-139">Response</span></span>

<span data-ttu-id="d670c-140">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="d670c-140">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="d670c-141">応答の本文内の値について詳しくは、[アドオンのリソース](manage-add-ons.md#add-on-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d670c-141">For more details about the values in the response body, see [add-on resource](manage-add-ons.md#add-on-object).</span></span>

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

## <a name="error-codes"></a><span data-ttu-id="d670c-142">エラー コード</span><span class="sxs-lookup"><span data-stu-id="d670c-142">Error codes</span></span>

<span data-ttu-id="d670c-143">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="d670c-143">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="d670c-144">エラー コード</span><span class="sxs-lookup"><span data-stu-id="d670c-144">Error code</span></span> |  <span data-ttu-id="d670c-145">説明</span><span class="sxs-lookup"><span data-stu-id="d670c-145">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="d670c-146">404</span><span class="sxs-lookup"><span data-stu-id="d670c-146">404</span></span>  | <span data-ttu-id="d670c-147">指定したアドオンは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="d670c-147">The specified add-on could not be found.</span></span> |
| <span data-ttu-id="d670c-148">409</span><span class="sxs-lookup"><span data-stu-id="d670c-148">409</span></span>  | <span data-ttu-id="d670c-149">アドオンが、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能を使用しています。</span><span class="sxs-lookup"><span data-stu-id="d670c-149">The add-on uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="d670c-150">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d670c-150">Related topics</span></span>

* [<span data-ttu-id="d670c-151">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="d670c-151">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="d670c-152">アドオンの申請の管理</span><span class="sxs-lookup"><span data-stu-id="d670c-152">Manage add-on submissions</span></span>](manage-add-on-submissions.md)
* [<span data-ttu-id="d670c-153">すべてのアドオンの入手</span><span class="sxs-lookup"><span data-stu-id="d670c-153">Get all add-ons</span></span>](get-all-add-ons.md)
* [<span data-ttu-id="d670c-154">アドオンの作成</span><span class="sxs-lookup"><span data-stu-id="d670c-154">Create an add-on</span></span>](create-an-add-on.md)
* [<span data-ttu-id="d670c-155">アドオンの削除</span><span class="sxs-lookup"><span data-stu-id="d670c-155">Delete an add-on</span></span>](delete-an-add-on.md)
