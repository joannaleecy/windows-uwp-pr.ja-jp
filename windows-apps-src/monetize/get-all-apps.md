---
author: Xansky
ms.assetid: 2BCFF687-DC12-49CA-97E4-ACEC72BFCD9B
description: パートナー センター アカウントに登録されているすべてのアプリに関する情報を取得する、Microsoft Store 申請 API でこのメソッドを使います。
title: すべてのアプリの入手
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリ
ms.localizationpriority: medium
ms.openlocfilehash: a689f540cb939cea3549b6660f2daf9a70f9b1f6
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6461709"
---
# <a name="get-all-apps"></a><span data-ttu-id="df954-104">すべてのアプリの入手</span><span class="sxs-lookup"><span data-stu-id="df954-104">Get all apps</span></span>


<span data-ttu-id="df954-105">パートナー センター アカウントに登録されているすべてのアプリに関するデータを取得、Microsoft Store 申請 API でこのメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="df954-105">Use this method in the Microsoft Store submission API to retrieve data for all the apps that are registered to your Partner Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="df954-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="df954-106">Prerequisites</span></span>

<span data-ttu-id="df954-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="df954-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="df954-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="df954-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="df954-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="df954-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="df954-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="df954-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="df954-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="df954-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="df954-112">要求</span><span class="sxs-lookup"><span data-stu-id="df954-112">Request</span></span>

<span data-ttu-id="df954-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="df954-113">This method has the following syntax.</span></span> <span data-ttu-id="df954-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df954-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="df954-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="df954-115">Method</span></span> | <span data-ttu-id="df954-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="df954-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="df954-117">GET</span><span class="sxs-lookup"><span data-stu-id="df954-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications``` |


### <a name="request-header"></a><span data-ttu-id="df954-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="df954-118">Request header</span></span>

| <span data-ttu-id="df954-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="df954-119">Header</span></span>        | <span data-ttu-id="df954-120">型</span><span class="sxs-lookup"><span data-stu-id="df954-120">Type</span></span>   | <span data-ttu-id="df954-121">説明</span><span class="sxs-lookup"><span data-stu-id="df954-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="df954-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="df954-122">Authorization</span></span> | <span data-ttu-id="df954-123">string</span><span class="sxs-lookup"><span data-stu-id="df954-123">string</span></span> | <span data-ttu-id="df954-124">必須。</span><span class="sxs-lookup"><span data-stu-id="df954-124">Required.</span></span> <span data-ttu-id="df954-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="df954-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="df954-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="df954-126">Request parameters</span></span>

<span data-ttu-id="df954-127">このメソッドでは、要求パラメーターはすべてオプションです。</span><span class="sxs-lookup"><span data-stu-id="df954-127">All request parameters are optional for this method.</span></span> <span data-ttu-id="df954-128">パラメーターを指定せずにこのメソッドを呼び出す場合、応答には、アカウントに登録するすべてのアプリのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="df954-128">If you call this method without parameters, the response contains data for all apps that are registered to your account.</span></span>

|  <span data-ttu-id="df954-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="df954-129">Parameter</span></span>  |  <span data-ttu-id="df954-130">型</span><span class="sxs-lookup"><span data-stu-id="df954-130">Type</span></span>  |  <span data-ttu-id="df954-131">説明</span><span class="sxs-lookup"><span data-stu-id="df954-131">Description</span></span>  |  <span data-ttu-id="df954-132">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="df954-132">Required</span></span>  |
|------|------|------|------|
|  <span data-ttu-id="df954-133">top</span><span class="sxs-lookup"><span data-stu-id="df954-133">top</span></span>  |  <span data-ttu-id="df954-134">int</span><span class="sxs-lookup"><span data-stu-id="df954-134">int</span></span>  |  <span data-ttu-id="df954-135">要求で返される項目の数 (つまり、返されるアプリの数)。</span><span class="sxs-lookup"><span data-stu-id="df954-135">The number of items to return in the request (that is, the number of apps to return).</span></span> <span data-ttu-id="df954-136">クエリで指定した値よりアカウントのアプリの数が多い場合、応答本文には、データの次のページを要求するためにメソッド URI に追加できる相対 URI パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="df954-136">If your account has more apps than the value you specify in the query, the response body includes a relative URI path that you can append to the method URI to request the next page of data.</span></span>  |  <span data-ttu-id="df954-137">必須ではない</span><span class="sxs-lookup"><span data-stu-id="df954-137">No</span></span>  |
|  <span data-ttu-id="df954-138">skip</span><span class="sxs-lookup"><span data-stu-id="df954-138">skip</span></span>  |  <span data-ttu-id="df954-139">int</span><span class="sxs-lookup"><span data-stu-id="df954-139">int</span></span>  |  <span data-ttu-id="df954-140">残りの項目を返す前にクエリでバイパスする項目の数。</span><span class="sxs-lookup"><span data-stu-id="df954-140">The number of items to bypass in the query before returning the remaining items.</span></span> <span data-ttu-id="df954-141">データ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="df954-141">Use this parameter to page through data sets.</span></span> <span data-ttu-id="df954-142">たとえば、top = 10 と skip = 0 は、1 から 10 の項目を取得し、top=10 と skip=10 は 11 から 20 の項目を取得するという具合です。</span><span class="sxs-lookup"><span data-stu-id="df954-142">For example, top=10 and skip=0 retrieves items 1 through 10, top=10 and skip=10 retrieves items 11 through 20, and so on.</span></span>  |  <span data-ttu-id="df954-143">必須ではない</span><span class="sxs-lookup"><span data-stu-id="df954-143">No</span></span>  |


### <a name="request-body"></a><span data-ttu-id="df954-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="df954-144">Request body</span></span>

<span data-ttu-id="df954-145">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="df954-145">Do not provide a request body for this method.</span></span>

### <a name="request-examples"></a><span data-ttu-id="df954-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="df954-146">Request examples</span></span>

<span data-ttu-id="df954-147">次の例は、アカウントに登録するすべてのアプリに関する情報を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="df954-147">The following example demonstrates how to retrieve information about all the apps that are registered to your account.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications HTTP/1.1
Authorization: Bearer <your access token>
```

<span data-ttu-id="df954-148">次の例は、アカウントに登録されている最初の 10 個のアプリを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="df954-148">The following example demonstrates how to retrieve the first 10 apps that are registered to your account.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications?top=10 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="df954-149">応答</span><span class="sxs-lookup"><span data-stu-id="df954-149">Response</span></span>

<span data-ttu-id="df954-150">次の例は、合計 21 個のアプリがある開発者アカウントに登録されている、最初の 10 個のアプリに対する要求が成功した場合に返される JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="df954-150">The following example demonstrates the JSON response body returned by a successful request for the first 10 apps that are registered to a developer account with 21 total apps.</span></span> <span data-ttu-id="df954-151">簡潔にするために、この例では、要求によって返される最初の 2 つのアプリのデータのみが示されています。</span><span class="sxs-lookup"><span data-stu-id="df954-151">For brevity, this example only shows the data for the first two apps returned by the request.</span></span> <span data-ttu-id="df954-152">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df954-152">For more details about the values in the response body, see the following section.</span></span>

```json
{
  "@nextLink": "applications?skip=10&top=10",
  "value": [
    {
      "id": "9NBLGGH4R315",
      "primaryName": "Contoso sample app",
      "packageFamilyName": "5224ContosoDeveloper.ContosoSampleApp_ng6try80pwt52",
      "packageIdentityName": "5224ContosoDeveloper.ContosoSampleApp",
      "publisherName": "CN=…",
      "firstPublishedDate": "2016-03-11T01:32:11.0747851Z",
      "pendingApplicationSubmission": {
        "id": "1152921504621134883",
        "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621134883"
      }
    },
    {
      "id": "9NBLGGH29DM8",
      "primaryName": "Contoso sample app 2",
      "packageFamilyName": "5224ContosoDeveloper.ContosoSampleApp2_ng6try80pwt52",
      "packageIdentityName": "5224ContosoDeveloper.ContosoSampleApp2",
      "publisherName": "CN=…",
      "firstPublishedDate": "2016-03-12T01:49:11.0747851Z",
      "lastPublishedApplicationSubmission": {
        "id": "1152921504621225621",
        "resourceLocation": "applications/9NBLGGH29DM8/submissions/1152921504621225621"
      }
      // Next 8 apps are omitted for brevity ...
    }
  ],
  "totalCount": 21
}
```

### <a name="response-body"></a><span data-ttu-id="df954-153">応答本文</span><span class="sxs-lookup"><span data-stu-id="df954-153">Response body</span></span>

| <span data-ttu-id="df954-154">値</span><span class="sxs-lookup"><span data-stu-id="df954-154">Value</span></span>      | <span data-ttu-id="df954-155">型</span><span class="sxs-lookup"><span data-stu-id="df954-155">Type</span></span>   | <span data-ttu-id="df954-156">説明</span><span class="sxs-lookup"><span data-stu-id="df954-156">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="df954-157">value</span><span class="sxs-lookup"><span data-stu-id="df954-157">value</span></span>      | <span data-ttu-id="df954-158">array</span><span class="sxs-lookup"><span data-stu-id="df954-158">array</span></span>  | <span data-ttu-id="df954-159">アカウントに登録されている各アプリについての情報が含まれるオブジェクトの配列。</span><span class="sxs-lookup"><span data-stu-id="df954-159">An array of objects that contain information about each app that is registered to your account.</span></span> <span data-ttu-id="df954-160">各オブジェクトのデータについて詳しくは、「[アプリケーション リソース](get-app-data.md#application_object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df954-160">For more information about the data in each object, see [Application resource](get-app-data.md#application_object).</span></span>                                                                                                                           |
| @nextLink  | <span data-ttu-id="df954-161">string</span><span class="sxs-lookup"><span data-stu-id="df954-161">string</span></span> | <span data-ttu-id="df954-162">データの追加ページが存在する場合、この文字列には、データの次のページを要求するために、ベースとなる ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に追加できる相対パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="df954-162">If there are additional pages of data, this string contains a relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to request the next page of data.</span></span> <span data-ttu-id="df954-163">たとえば、最初の要求本文の *top* パラメーターが 10 に設定されていて、アカウントには 20 個のアプリが登録されている場合、応答本文には、```applications?skip=10&top=10``` という @nextLink 値が含まれます。これは、次の 10 個のアプリを要求するために、```https://manage.devcenter.microsoft.com/v1.0/my/applications?skip=10&top=10``` を呼び出すことができることを示しています。</span><span class="sxs-lookup"><span data-stu-id="df954-163">For example, if the *top* parameter of the initial request body is set to 10 but there are 20 apps registered to your account, the response body will include a @nextLink value of ```applications?skip=10&top=10```, which indicates that you can call ```https://manage.devcenter.microsoft.com/v1.0/my/applications?skip=10&top=10``` to request the next 10 apps.</span></span> |
| <span data-ttu-id="df954-164">totalCount</span><span class="sxs-lookup"><span data-stu-id="df954-164">totalCount</span></span> | <span data-ttu-id="df954-165">int</span><span class="sxs-lookup"><span data-stu-id="df954-165">int</span></span>    | <span data-ttu-id="df954-166">クエリの結果データ内の行の総数 (つまり、自分のアカウントに登録されているアプリの合計数)。</span><span class="sxs-lookup"><span data-stu-id="df954-166">The total number of rows in the data result for the query (that is, the total number of apps that are registered to your account).</span></span>                                                |


## <a name="error-codes"></a><span data-ttu-id="df954-167">エラー コード</span><span class="sxs-lookup"><span data-stu-id="df954-167">Error codes</span></span>

<span data-ttu-id="df954-168">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="df954-168">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="df954-169">エラー コード</span><span class="sxs-lookup"><span data-stu-id="df954-169">Error code</span></span> |  <span data-ttu-id="df954-170">説明</span><span class="sxs-lookup"><span data-stu-id="df954-170">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="df954-171">404</span><span class="sxs-lookup"><span data-stu-id="df954-171">404</span></span>  | <span data-ttu-id="df954-172">アプリが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="df954-172">No apps were found.</span></span> |
| <span data-ttu-id="df954-173">409</span><span class="sxs-lookup"><span data-stu-id="df954-173">409</span></span>  | <span data-ttu-id="df954-174">アプリでは、 [Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)は、パートナー センターの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="df954-174">The apps use Partner Center features that are [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="df954-175">関連トピック</span><span class="sxs-lookup"><span data-stu-id="df954-175">Related topics</span></span>

* [<span data-ttu-id="df954-176">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="df954-176">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="df954-177">アプリの取得</span><span class="sxs-lookup"><span data-stu-id="df954-177">Get an app</span></span>](get-an-app.md)
* [<span data-ttu-id="df954-178">アプリのパッケージ フライトの入手</span><span class="sxs-lookup"><span data-stu-id="df954-178">Get package flights for an app</span></span>](get-flights-for-an-app.md)
* [<span data-ttu-id="df954-179">アプリのアドオンの入手</span><span class="sxs-lookup"><span data-stu-id="df954-179">Get add-ons for an app</span></span>](get-add-ons-for-an-app.md)
