---
ms.assetid: 2BCFF687-DC12-49CA-97E4-ACEC72BFCD9B
description: Microsoft Store 送信 API でこのメソッドを使用して、パートナー センター アカウントに登録されているすべてのアプリに関する情報を取得します。
title: すべてのアプリの取得
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリ
ms.localizationpriority: medium
ms.openlocfilehash: 267e1d4de3917ae332cdfe15309f3871ef7b6647
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641987"
---
# <a name="get-all-apps"></a><span data-ttu-id="373a6-104">すべてのアプリの取得</span><span class="sxs-lookup"><span data-stu-id="373a6-104">Get all apps</span></span>


<span data-ttu-id="373a6-105">Microsoft Store 送信 API でこのメソッドを使用して、パートナー センター アカウントに登録されているアプリのデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="373a6-105">Use this method in the Microsoft Store submission API to retrieve data for the apps that are registered to your Partner Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="373a6-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="373a6-106">Prerequisites</span></span>

<span data-ttu-id="373a6-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="373a6-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="373a6-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="373a6-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="373a6-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="373a6-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="373a6-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="373a6-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="373a6-111">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="373a6-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="373a6-112">要求</span><span class="sxs-lookup"><span data-stu-id="373a6-112">Request</span></span>

<span data-ttu-id="373a6-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="373a6-113">This method has the following syntax.</span></span> <span data-ttu-id="373a6-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="373a6-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="373a6-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="373a6-115">Method</span></span> | <span data-ttu-id="373a6-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="373a6-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="373a6-117">GET</span><span class="sxs-lookup"><span data-stu-id="373a6-117">GET</span></span>    | `https://manage.devcenter.microsoft.com/v1.0/my/applications` |


### <a name="request-header"></a><span data-ttu-id="373a6-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="373a6-118">Request header</span></span>

| <span data-ttu-id="373a6-119">Header</span><span class="sxs-lookup"><span data-stu-id="373a6-119">Header</span></span>        | <span data-ttu-id="373a6-120">種類</span><span class="sxs-lookup"><span data-stu-id="373a6-120">Type</span></span>   | <span data-ttu-id="373a6-121">説明</span><span class="sxs-lookup"><span data-stu-id="373a6-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="373a6-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="373a6-122">Authorization</span></span> | <span data-ttu-id="373a6-123">string</span><span class="sxs-lookup"><span data-stu-id="373a6-123">string</span></span> | <span data-ttu-id="373a6-124">必須。</span><span class="sxs-lookup"><span data-stu-id="373a6-124">Required.</span></span> <span data-ttu-id="373a6-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="373a6-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="373a6-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="373a6-126">Request parameters</span></span>

<span data-ttu-id="373a6-127">このメソッドでは、要求パラメーターはすべてオプションです。</span><span class="sxs-lookup"><span data-stu-id="373a6-127">All request parameters are optional for this method.</span></span> <span data-ttu-id="373a6-128">最初の 10 のデータが応答に含まれるパラメーターを指定せずには、このメソッドを呼び出す場合、アカウントに登録されているアプリ。</span><span class="sxs-lookup"><span data-stu-id="373a6-128">If you call this method without parameters, the response contains data for the first 10 apps that are registered to your account.</span></span>

|  <span data-ttu-id="373a6-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="373a6-129">Parameter</span></span>  |  <span data-ttu-id="373a6-130">種類</span><span class="sxs-lookup"><span data-stu-id="373a6-130">Type</span></span>  |  <span data-ttu-id="373a6-131">説明</span><span class="sxs-lookup"><span data-stu-id="373a6-131">Description</span></span>  |  <span data-ttu-id="373a6-132">必須</span><span class="sxs-lookup"><span data-stu-id="373a6-132">Required</span></span>  |
|------|------|------|------|
|  <span data-ttu-id="373a6-133">top</span><span class="sxs-lookup"><span data-stu-id="373a6-133">top</span></span>  |  <span data-ttu-id="373a6-134">int</span><span class="sxs-lookup"><span data-stu-id="373a6-134">int</span></span>  |  <span data-ttu-id="373a6-135">要求で返される項目の数 (つまり、返されるアプリの数)。</span><span class="sxs-lookup"><span data-stu-id="373a6-135">The number of items to return in the request (that is, the number of apps to return).</span></span> <span data-ttu-id="373a6-136">クエリで指定した値よりアカウントのアプリの数が多い場合、応答本文には、データの次のページを要求するためにメソッド URI に追加できる相対 URI パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="373a6-136">If your account has more apps than the value you specify in the query, the response body includes a relative URI path that you can append to the method URI to request the next page of data.</span></span>  |  <span data-ttu-id="373a6-137">X</span><span class="sxs-lookup"><span data-stu-id="373a6-137">No</span></span>  |
|  <span data-ttu-id="373a6-138">skip</span><span class="sxs-lookup"><span data-stu-id="373a6-138">skip</span></span>  |  <span data-ttu-id="373a6-139">int</span><span class="sxs-lookup"><span data-stu-id="373a6-139">int</span></span>  |  <span data-ttu-id="373a6-140">残りの項目を返す前にクエリでバイパスする項目の数。</span><span class="sxs-lookup"><span data-stu-id="373a6-140">The number of items to bypass in the query before returning the remaining items.</span></span> <span data-ttu-id="373a6-141">データ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="373a6-141">Use this parameter to page through data sets.</span></span> <span data-ttu-id="373a6-142">たとえば、top = 10 と skip = 0 は、1 から 10 の項目を取得し、top=10 と skip=10 は 11 から 20 の項目を取得するという具合です。</span><span class="sxs-lookup"><span data-stu-id="373a6-142">For example, top=10 and skip=0 retrieves items 1 through 10, top=10 and skip=10 retrieves items 11 through 20, and so on.</span></span>  |  <span data-ttu-id="373a6-143">いいえ</span><span class="sxs-lookup"><span data-stu-id="373a6-143">No</span></span>  |


### <a name="request-body"></a><span data-ttu-id="373a6-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="373a6-144">Request body</span></span>

<span data-ttu-id="373a6-145">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="373a6-145">Do not provide a request body for this method.</span></span>

### <a name="request-examples"></a><span data-ttu-id="373a6-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="373a6-146">Request examples</span></span>

<span data-ttu-id="373a6-147">次の例は、アカウントに登録されている最初の 10 個のアプリを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="373a6-147">The following example demonstrates how to retrieve the first 10 apps that are registered to your account.</span></span>

```http
GET https://manage.devcenter.microsoft.com/v1.0/my/applications HTTP/1.1
Authorization: Bearer <your access token>
```

<span data-ttu-id="373a6-148">次の例は、アカウントに登録するすべてのアプリに関する情報を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="373a6-148">The following example demonstrates how to retrieve information about all the apps that are registered to your account.</span></span> <span data-ttu-id="373a6-149">最初に、上位 10 個のアプリを取得します。</span><span class="sxs-lookup"><span data-stu-id="373a6-149">First, get the top 10 apps:</span></span>

```http
GET https://manage.devcenter.microsoft.com/v1.0/my/applications?top=10 HTTP/1.1
Authorization: Bearer <your access token>
```

<span data-ttu-id="373a6-150">再帰的に呼び出す操作を実行し、`GET https://manage.devcenter.microsoft.com/v1.0/my/{@nextLink}`まで`{@nextlink}`が null か、応答内に存在しません。</span><span class="sxs-lookup"><span data-stu-id="373a6-150">Then recursively call `GET https://manage.devcenter.microsoft.com/v1.0/my/{@nextLink}` until `{@nextlink}` is null or doesn't exist in the response.</span></span> <span data-ttu-id="373a6-151">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="373a6-151">For example:</span></span>

```http
GET https://manage.devcenter.microsoft.com/v1.0/my/applications?skip=10&top=10 HTTP/1.1
Authorization: Bearer <your access token>
```
  
```http
GET https://manage.devcenter.microsoft.com/v1.0/my/applications?skip=20&top=10 HTTP/1.1
Authorization: Bearer <your access token>
```

```http
GET https://manage.devcenter.microsoft.com/v1.0/my/applications?skip=30&top=10 HTTP/1.1
Authorization: Bearer <your access token>
```

<span data-ttu-id="373a6-152">自分のアカウントにあるアプリの合計数を既に知っている場合だけその数を渡すことができます、**上部**パラメーターすべてのアプリに関する情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="373a6-152">If you already know the total number of apps you have in your account, you can simply pass that number in the **top** parameter to get information about all your apps.</span></span>

```http
GET https://manage.devcenter.microsoft.com/v1.0/my/applications?top=23 HTTP/1.1
Authorization: Bearer <your access token>
```


## <a name="response"></a><span data-ttu-id="373a6-153">応答</span><span class="sxs-lookup"><span data-stu-id="373a6-153">Response</span></span>

<span data-ttu-id="373a6-154">次の例は、合計 21 個のアプリがある開発者アカウントに登録されている、最初の 10 個のアプリに対する要求が成功した場合に返される JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="373a6-154">The following example demonstrates the JSON response body returned by a successful request for the first 10 apps that are registered to a developer account with 21 total apps.</span></span> <span data-ttu-id="373a6-155">簡潔にするために、この例では、要求によって返される最初の 2 つのアプリのデータのみが示されています。</span><span class="sxs-lookup"><span data-stu-id="373a6-155">For brevity, this example only shows the data for the first two apps returned by the request.</span></span> <span data-ttu-id="373a6-156">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="373a6-156">For more details about the values in the response body, see the following section.</span></span>

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

### <a name="response-body"></a><span data-ttu-id="373a6-157">応答本文</span><span class="sxs-lookup"><span data-stu-id="373a6-157">Response body</span></span>

| <span data-ttu-id="373a6-158">Value</span><span class="sxs-lookup"><span data-stu-id="373a6-158">Value</span></span>      | <span data-ttu-id="373a6-159">種類</span><span class="sxs-lookup"><span data-stu-id="373a6-159">Type</span></span>   | <span data-ttu-id="373a6-160">説明</span><span class="sxs-lookup"><span data-stu-id="373a6-160">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="373a6-161">value</span><span class="sxs-lookup"><span data-stu-id="373a6-161">value</span></span>      | <span data-ttu-id="373a6-162">array</span><span class="sxs-lookup"><span data-stu-id="373a6-162">array</span></span>  | <span data-ttu-id="373a6-163">アカウントに登録されている各アプリについての情報が含まれるオブジェクトの配列。</span><span class="sxs-lookup"><span data-stu-id="373a6-163">An array of objects that contain information about each app that is registered to your account.</span></span> <span data-ttu-id="373a6-164">各オブジェクトのデータについて詳しくは、「[アプリケーション リソース](get-app-data.md#application_object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="373a6-164">For more information about the data in each object, see [Application resource](get-app-data.md#application_object).</span></span>                                                                                                                           |
| @nextLink  | <span data-ttu-id="373a6-165">string</span><span class="sxs-lookup"><span data-stu-id="373a6-165">string</span></span> | <span data-ttu-id="373a6-166">データの追加ページが存在する場合、この文字列には、データの次のページを要求するために、ベースとなる `https://manage.devcenter.microsoft.com/v1.0/my/` 要求 URI に追加できる相対パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="373a6-166">If there are additional pages of data, this string contains a relative path that you can append to the base `https://manage.devcenter.microsoft.com/v1.0/my/` request URI to request the next page of data.</span></span> <span data-ttu-id="373a6-167">たとえば、最初の要求本文の *top* パラメーターが 10 に設定されていて、アカウントには 20 個のアプリが登録されている場合、応答本文には、`applications?skip=10&top=10` という @nextLink 値が含まれます。これは、次の 10 個のアプリを要求するために、`https://manage.devcenter.microsoft.com/v1.0/my/applications?skip=10&top=10` を呼び出すことができることを示しています。</span><span class="sxs-lookup"><span data-stu-id="373a6-167">For example, if the *top* parameter of the initial request body is set to 10 but there are 20 apps registered to your account, the response body will include a @nextLink value of `applications?skip=10&top=10`, which indicates that you can call `https://manage.devcenter.microsoft.com/v1.0/my/applications?skip=10&top=10` to request the next 10 apps.</span></span> |
| <span data-ttu-id="373a6-168">totalCount</span><span class="sxs-lookup"><span data-stu-id="373a6-168">totalCount</span></span> | <span data-ttu-id="373a6-169">int</span><span class="sxs-lookup"><span data-stu-id="373a6-169">int</span></span>    | <span data-ttu-id="373a6-170">クエリの結果データ内の行の総数 (つまり、自分のアカウントに登録されているアプリの合計数)。</span><span class="sxs-lookup"><span data-stu-id="373a6-170">The total number of rows in the data result for the query (that is, the total number of apps that are registered to your account).</span></span>                                                |


## <a name="error-codes"></a><span data-ttu-id="373a6-171">エラー コード</span><span class="sxs-lookup"><span data-stu-id="373a6-171">Error codes</span></span>

<span data-ttu-id="373a6-172">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="373a6-172">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="373a6-173">エラー コード</span><span class="sxs-lookup"><span data-stu-id="373a6-173">Error code</span></span> |  <span data-ttu-id="373a6-174">説明</span><span class="sxs-lookup"><span data-stu-id="373a6-174">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="373a6-175">404</span><span class="sxs-lookup"><span data-stu-id="373a6-175">404</span></span>  | <span data-ttu-id="373a6-176">アプリが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="373a6-176">No apps were found.</span></span> |
| <span data-ttu-id="373a6-177">409</span><span class="sxs-lookup"><span data-stu-id="373a6-177">409</span></span>  | <span data-ttu-id="373a6-178">アプリはパートナー センターの機能を使用して、[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。</span><span class="sxs-lookup"><span data-stu-id="373a6-178">The apps use Partner Center features that are [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="373a6-179">関連トピック</span><span class="sxs-lookup"><span data-stu-id="373a6-179">Related topics</span></span>

* [<span data-ttu-id="373a6-180">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="373a6-180">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="373a6-181">アプリを取得します。</span><span class="sxs-lookup"><span data-stu-id="373a6-181">Get an app</span></span>](get-an-app.md)
* [<span data-ttu-id="373a6-182">アプリのパッケージのフライトを取得します。</span><span class="sxs-lookup"><span data-stu-id="373a6-182">Get package flights for an app</span></span>](get-flights-for-an-app.md)
* [<span data-ttu-id="373a6-183">アプリのアドオンを入手します。</span><span class="sxs-lookup"><span data-stu-id="373a6-183">Get add-ons for an app</span></span>](get-add-ons-for-an-app.md)
