---
ms.assetid: E59FB6FE-5318-46DF-B050-73F599C3972A
description: Microsoft Store 申請 API で、パートナー センターに登録されているアプリのアプリ内購入に関する情報を取得するのに以下のメソッドを使用します。
title: アプリのアドオンの入手
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオン, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: ec065eef5d411e35515837b169fd57d71e4ef6ac
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7974110"
---
# <a name="get-add-ons-for-an-app"></a><span data-ttu-id="c9016-104">アプリのアドオンの入手</span><span class="sxs-lookup"><span data-stu-id="c9016-104">Get add-ons for an app</span></span>

<span data-ttu-id="c9016-105">パートナー センター アカウントに登録されているアプリのアドオンを一覧表示する、Microsoft Store 申請 API でこのメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="c9016-105">Use this method in the Microsoft Store submission API to list the add-ons for an app that is registered to your Partner Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="c9016-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="c9016-106">Prerequisites</span></span>

<span data-ttu-id="c9016-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c9016-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="c9016-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="c9016-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="c9016-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="c9016-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="c9016-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="c9016-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="c9016-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c9016-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="c9016-112">要求</span><span class="sxs-lookup"><span data-stu-id="c9016-112">Request</span></span>

<span data-ttu-id="c9016-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c9016-113">This method has the following syntax.</span></span> <span data-ttu-id="c9016-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c9016-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="c9016-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="c9016-115">Method</span></span> | <span data-ttu-id="c9016-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c9016-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="c9016-117">GET</span><span class="sxs-lookup"><span data-stu-id="c9016-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listinappproducts``` |


### <a name="request-header"></a><span data-ttu-id="c9016-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9016-118">Request header</span></span>

| <span data-ttu-id="c9016-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9016-119">Header</span></span>        | <span data-ttu-id="c9016-120">型</span><span class="sxs-lookup"><span data-stu-id="c9016-120">Type</span></span>   | <span data-ttu-id="c9016-121">説明</span><span class="sxs-lookup"><span data-stu-id="c9016-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="c9016-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="c9016-122">Authorization</span></span> | <span data-ttu-id="c9016-123">string</span><span class="sxs-lookup"><span data-stu-id="c9016-123">string</span></span> | <span data-ttu-id="c9016-124">必須。</span><span class="sxs-lookup"><span data-stu-id="c9016-124">Required.</span></span> <span data-ttu-id="c9016-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="c9016-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="c9016-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9016-126">Request parameters</span></span>


|  <span data-ttu-id="c9016-127">名前</span><span class="sxs-lookup"><span data-stu-id="c9016-127">Name</span></span>  |  <span data-ttu-id="c9016-128">種類</span><span class="sxs-lookup"><span data-stu-id="c9016-128">Type</span></span>  |  <span data-ttu-id="c9016-129">説明</span><span class="sxs-lookup"><span data-stu-id="c9016-129">Description</span></span>  |  <span data-ttu-id="c9016-130">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="c9016-130">Required</span></span>  |
|------|------|------|------|
|  <span data-ttu-id="c9016-131">applicationId</span><span class="sxs-lookup"><span data-stu-id="c9016-131">applicationId</span></span>  |  <span data-ttu-id="c9016-132">string</span><span class="sxs-lookup"><span data-stu-id="c9016-132">string</span></span>  |  <span data-ttu-id="c9016-133">アドオンを取得するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="c9016-133">The Store ID of the app for which you want to retrieve the add-ons.</span></span> <span data-ttu-id="c9016-134">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c9016-134">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |  <span data-ttu-id="c9016-135">必須</span><span class="sxs-lookup"><span data-stu-id="c9016-135">Yes</span></span>  |
|  <span data-ttu-id="c9016-136">top</span><span class="sxs-lookup"><span data-stu-id="c9016-136">top</span></span>  |  <span data-ttu-id="c9016-137">int</span><span class="sxs-lookup"><span data-stu-id="c9016-137">int</span></span>  |  <span data-ttu-id="c9016-138">要求で返される項目の数 (つまり、返されるアドオンの数)。</span><span class="sxs-lookup"><span data-stu-id="c9016-138">The number of items to return in the request (that is, the number of add-ons to return).</span></span> <span data-ttu-id="c9016-139">クエリで指定した値よりアプリのアドオンの数が多い場合、応答本文には、データの次のページを要求するためにメソッド URI に追加できる相対 URI パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c9016-139">If the app has more add-ons than the value you specify in the query, the response body includes a relative URI path that you can append to the method URI to request the next page of data.</span></span>  |  <span data-ttu-id="c9016-140">必須ではない</span><span class="sxs-lookup"><span data-stu-id="c9016-140">No</span></span>  |
|  <span data-ttu-id="c9016-141">skip</span><span class="sxs-lookup"><span data-stu-id="c9016-141">skip</span></span> |  <span data-ttu-id="c9016-142">int</span><span class="sxs-lookup"><span data-stu-id="c9016-142">int</span></span>  | <span data-ttu-id="c9016-143">残りの項目を返す前にクエリでバイパスする項目の数。</span><span class="sxs-lookup"><span data-stu-id="c9016-143">The number of items to bypass in the query before returning the remaining items.</span></span> <span data-ttu-id="c9016-144">データ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="c9016-144">Use this parameter to page through data sets.</span></span> <span data-ttu-id="c9016-145">たとえば、top = 10 と skip = 0 は、1 から 10 の項目を取得し、top=10 と skip=10 は 11 から 20 の項目を取得するという具合です。</span><span class="sxs-lookup"><span data-stu-id="c9016-145">For example, top=10 and skip=0 retrieves items 1 through 10, top=10 and skip=10 retrieves items 11 through 20, and so on.</span></span>   |  <span data-ttu-id="c9016-146">必須ではない</span><span class="sxs-lookup"><span data-stu-id="c9016-146">No</span></span>  |


### <a name="request-body"></a><span data-ttu-id="c9016-147">要求本文</span><span class="sxs-lookup"><span data-stu-id="c9016-147">Request body</span></span>

<span data-ttu-id="c9016-148">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="c9016-148">Do not provide a request body for this method.</span></span>

### <a name="request-examples"></a><span data-ttu-id="c9016-149">要求の例</span><span class="sxs-lookup"><span data-stu-id="c9016-149">Request examples</span></span>

<span data-ttu-id="c9016-150">次の例は、アプリのすべてのアドオンを一覧表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c9016-150">The following example demonstrates how to list all the add-ons for an app.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/listinappproducts HTTP/1.1
Authorization: Bearer <your access token>
```

<span data-ttu-id="c9016-151">次の例は、アプリの最初の 10 個のアドオンを一覧表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c9016-151">The following example demonstrates how to list the first 10 add-ons for an app.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/listinappproducts?top=10 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="c9016-152">応答</span><span class="sxs-lookup"><span data-stu-id="c9016-152">Response</span></span>

<span data-ttu-id="c9016-153">次の例は、合計 53 個のアドオンがあるアプリの、最初の 10 個のアドオンに対する要求が成功した場合に返される JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="c9016-153">The following example demonstrates the JSON response body returned by a successful request for the first 10 add-ons for an app with 53 total add-ons.</span></span> <span data-ttu-id="c9016-154">簡潔にするために、この例では、要求によって返される最初の 3 つのアドオンのデータのみが示されています。</span><span class="sxs-lookup"><span data-stu-id="c9016-154">For brevity, this example only shows the data for the first three add-ons returned by the request.</span></span> <span data-ttu-id="c9016-155">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c9016-155">For more details about the values in the response body, see the following section.</span></span>

```json
{
  "@nextLink": "applications/9NBLGGH4R315/listinappproducts/?skip=10&top=10",
  "value": [
    {
      "inAppProductId": "9NBLGGH4TNMP"
    },
    {
      "inAppProductId": "9NBLGGH4TNMN"
    },
    {
      "inAppProductId": "9NBLGGH4TNNR"
    },
    // Next 7 add-ons  are omitted for brevity ...
  ],
  "totalCount": 53
}
```

### <a name="response-body"></a><span data-ttu-id="c9016-156">応答本文</span><span class="sxs-lookup"><span data-stu-id="c9016-156">Response body</span></span>

| <span data-ttu-id="c9016-157">値</span><span class="sxs-lookup"><span data-stu-id="c9016-157">Value</span></span>      | <span data-ttu-id="c9016-158">型</span><span class="sxs-lookup"><span data-stu-id="c9016-158">Type</span></span>   | <span data-ttu-id="c9016-159">説明</span><span class="sxs-lookup"><span data-stu-id="c9016-159">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| @nextLink  | <span data-ttu-id="c9016-160">string</span><span class="sxs-lookup"><span data-stu-id="c9016-160">string</span></span> | <span data-ttu-id="c9016-161">データの追加ページが存在する場合、この文字列には、データの次のページを要求するために、ベースとなる ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に追加できる相対パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c9016-161">If there are additional pages of data, this string contains a relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to request the next page of data.</span></span> <span data-ttu-id="c9016-162">たとえば、最初の要求本文の *top* パラメーターが 10 に設定されていて、アプリには 50 個のアドオンが存在する場合、応答本文には、```applications/{applicationid}/listinappproducts/?skip=10&top=10``` という @nextLink 値が含まれます。これは、次の 10 個のアドオンを要求するために、```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationid}/listinappproducts/?skip=10&top=10``` を呼び出すことができることを示しています。</span><span class="sxs-lookup"><span data-stu-id="c9016-162">For example, if the *top* parameter of the initial request body is set to 10 but there are 50 add-ons for the app, the response body will include a @nextLink value of ```applications/{applicationid}/listinappproducts/?skip=10&top=10```, which indicates that you can call ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationid}/listinappproducts/?skip=10&top=10``` to request the next 10 add-ons.</span></span> |
| <span data-ttu-id="c9016-163">value</span><span class="sxs-lookup"><span data-stu-id="c9016-163">value</span></span>      | <span data-ttu-id="c9016-164">array</span><span class="sxs-lookup"><span data-stu-id="c9016-164">array</span></span>  | <span data-ttu-id="c9016-165">指定されたアプリの各アドオンのストア ID を一覧表示するオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="c9016-165">An array of objects that list the Store ID of each add-on for the specified app.</span></span> <span data-ttu-id="c9016-166">各オブジェクトのデータについて詳しくは、「[アドオン リソース](get-app-data.md#add-on-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c9016-166">For more information about the data in each object, see [add-on resource](get-app-data.md#add-on-object).</span></span>                                                                                                                           |
| <span data-ttu-id="c9016-167">totalCount</span><span class="sxs-lookup"><span data-stu-id="c9016-167">totalCount</span></span> | <span data-ttu-id="c9016-168">int</span><span class="sxs-lookup"><span data-stu-id="c9016-168">int</span></span>    | <span data-ttu-id="c9016-169">クエリのデータ結果の行の合計 (つまり、指定されたアプリのアドオンの合計)。</span><span class="sxs-lookup"><span data-stu-id="c9016-169">The total number of rows in the data result for the query (that is, the total number of add-ons for the specified app).</span></span>    |


## <a name="error-codes"></a><span data-ttu-id="c9016-170">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c9016-170">Error codes</span></span>

<span data-ttu-id="c9016-171">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="c9016-171">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="c9016-172">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c9016-172">Error code</span></span> |  <span data-ttu-id="c9016-173">説明</span><span class="sxs-lookup"><span data-stu-id="c9016-173">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="c9016-174">404</span><span class="sxs-lookup"><span data-stu-id="c9016-174">404</span></span>  | <span data-ttu-id="c9016-175">アドオンは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="c9016-175">No add-ons were found.</span></span> |
| <span data-ttu-id="c9016-176">409</span><span class="sxs-lookup"><span data-stu-id="c9016-176">409</span></span>  | <span data-ttu-id="c9016-177">アドオンは、 [Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)は、パートナー センターの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="c9016-177">The add-ons use Partner Center features that are [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="c9016-178">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c9016-178">Related topics</span></span>

* [<span data-ttu-id="c9016-179">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="c9016-179">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="c9016-180">すべてのアプリの取得</span><span class="sxs-lookup"><span data-stu-id="c9016-180">Get all apps</span></span>](get-all-apps.md)
* [<span data-ttu-id="c9016-181">アプリの入手</span><span class="sxs-lookup"><span data-stu-id="c9016-181">Get an app</span></span>](get-an-app.md)
* [<span data-ttu-id="c9016-182">アプリのパッケージ フライトの入手</span><span class="sxs-lookup"><span data-stu-id="c9016-182">Get package flights for an app</span></span>](get-flights-for-an-app.md)
