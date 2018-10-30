---
author: Xansky
ms.assetid: DAF92881-6AF6-44C7-B466-215F5226AE04
description: Windows デベロッパー センター アカウントに登録されている特定のアプリに関する情報を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの取得
ms.author: mhopkins
ms.date: 02/28/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリ
ms.localizationpriority: medium
ms.openlocfilehash: 94c46363f75c75bb595b184e5a142e737a32ea50
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5761264"
---
# <a name="get-an-app"></a><span data-ttu-id="3cd6f-104">アプリの取得</span><span class="sxs-lookup"><span data-stu-id="3cd6f-104">Get an app</span></span>

<span data-ttu-id="3cd6f-105">Windows デベロッパー センター アカウントに登録されている特定のアプリに関する情報を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-105">Use this method in the Microsoft Store submission API to retrieve information about a specific app that is registered to your Windows Dev Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="3cd6f-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="3cd6f-106">Prerequisites</span></span>

<span data-ttu-id="3cd6f-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="3cd6f-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="3cd6f-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="3cd6f-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="3cd6f-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="3cd6f-112">要求</span><span class="sxs-lookup"><span data-stu-id="3cd6f-112">Request</span></span>

<span data-ttu-id="3cd6f-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-113">This method has the following syntax.</span></span> <span data-ttu-id="3cd6f-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="3cd6f-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="3cd6f-115">Method</span></span> | <span data-ttu-id="3cd6f-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="3cd6f-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="3cd6f-117">GET</span><span class="sxs-lookup"><span data-stu-id="3cd6f-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}``` |


### <a name="request-header"></a><span data-ttu-id="3cd6f-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3cd6f-118">Request header</span></span>

| <span data-ttu-id="3cd6f-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3cd6f-119">Header</span></span>        | <span data-ttu-id="3cd6f-120">型</span><span class="sxs-lookup"><span data-stu-id="3cd6f-120">Type</span></span>   | <span data-ttu-id="3cd6f-121">説明</span><span class="sxs-lookup"><span data-stu-id="3cd6f-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3cd6f-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="3cd6f-122">Authorization</span></span> | <span data-ttu-id="3cd6f-123">string</span><span class="sxs-lookup"><span data-stu-id="3cd6f-123">string</span></span> | <span data-ttu-id="3cd6f-124">必須。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-124">Required.</span></span> <span data-ttu-id="3cd6f-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="3cd6f-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="3cd6f-126">Request parameters</span></span>

| <span data-ttu-id="3cd6f-127">名前</span><span class="sxs-lookup"><span data-stu-id="3cd6f-127">Name</span></span>        | <span data-ttu-id="3cd6f-128">種類</span><span class="sxs-lookup"><span data-stu-id="3cd6f-128">Type</span></span>   | <span data-ttu-id="3cd6f-129">説明</span><span class="sxs-lookup"><span data-stu-id="3cd6f-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3cd6f-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="3cd6f-130">applicationId</span></span> | <span data-ttu-id="3cd6f-131">string</span><span class="sxs-lookup"><span data-stu-id="3cd6f-131">string</span></span> | <span data-ttu-id="3cd6f-132">必須。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-132">Required.</span></span> <span data-ttu-id="3cd6f-133">取得するアプリのストア ID。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-133">The Store ID of the app to retrieve.</span></span> <span data-ttu-id="3cd6f-134">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-134">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |


### <a name="request-body"></a><span data-ttu-id="3cd6f-135">要求本文</span><span class="sxs-lookup"><span data-stu-id="3cd6f-135">Request body</span></span>

<span data-ttu-id="3cd6f-136">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-136">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="3cd6f-137">要求の例</span><span class="sxs-lookup"><span data-stu-id="3cd6f-137">Request example</span></span>

<span data-ttu-id="3cd6f-138">次の例は、Store ID 値が 9NBLGGH4R315 であるアプリに関する情報を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-138">The following example demonstrates how to retrieve information about an app with the Store ID value 9NBLGGH4R315.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="3cd6f-139">応答</span><span class="sxs-lookup"><span data-stu-id="3cd6f-139">Response</span></span>

<span data-ttu-id="3cd6f-140">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-140">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="3cd6f-141">応答の本文内の値について詳しくは、[アプリケーションのリソース](get-app-data.md#application_object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-141">For more details about the values in the response body, see [Application resource](get-app-data.md#application_object).</span></span>

```json
{
  "id": "9NBLGGH4R315",
  "primaryName": "ApiTestApp",
  "packageFamilyName": "30481DevCenterAPITester.ApiTestAppForDevbox_ng6try80pwt52",
  "packageIdentityName": "30481DevCenterAPITester.ApiTestAppForDevbox",
  "publisherName": "CN=…",
  "firstPublishedDate": "1601-01-01T00:00:00Z",
  "lastPublishedApplicationSubmission": {
    "id": "1152921504621086517",
    "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621086517"
  },
  "pendingApplicationSubmission": {
    "id": "1152921504621243487",
    "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621243487"
  },
  "hasAdvancedListingPermission": false
}
```

## <a name="error-codes"></a><span data-ttu-id="3cd6f-142">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3cd6f-142">Error codes</span></span>

<span data-ttu-id="3cd6f-143">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-143">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="3cd6f-144">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3cd6f-144">Error code</span></span> |  <span data-ttu-id="3cd6f-145">説明</span><span class="sxs-lookup"><span data-stu-id="3cd6f-145">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="3cd6f-146">404</span><span class="sxs-lookup"><span data-stu-id="3cd6f-146">404</span></span>  | <span data-ttu-id="3cd6f-147">指定したアプリは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-147">The specified app could not be found.</span></span> |
| <span data-ttu-id="3cd6f-148">409</span><span class="sxs-lookup"><span data-stu-id="3cd6f-148">409</span></span>  | <span data-ttu-id="3cd6f-149">アプリが、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能を使用しています。</span><span class="sxs-lookup"><span data-stu-id="3cd6f-149">The app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="3cd6f-150">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3cd6f-150">Related topics</span></span>

* [<span data-ttu-id="3cd6f-151">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="3cd6f-151">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="3cd6f-152">すべてのアプリの取得</span><span class="sxs-lookup"><span data-stu-id="3cd6f-152">Get all apps</span></span>](get-all-apps.md)
* [<span data-ttu-id="3cd6f-153">アプリのパッケージ フライトの入手</span><span class="sxs-lookup"><span data-stu-id="3cd6f-153">Get package flights for an app</span></span>](get-flights-for-an-app.md)
* [<span data-ttu-id="3cd6f-154">アプリのアドオンの入手</span><span class="sxs-lookup"><span data-stu-id="3cd6f-154">Get add-ons for an app</span></span>](get-add-ons-for-an-app.md)
