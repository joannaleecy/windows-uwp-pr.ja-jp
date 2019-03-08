---
ms.assetid: 7B6A99C6-AC86-41A1-85D0-3EB39A7211B6
description: Microsoft Store 送信 API でこのメソッドを使用して、パートナー センター アカウントに登録されているすべてのアプリのすべてのアドオン データを取得します。
title: すべてのアドオンの入手
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオン, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 50733bc0617d56b7e6b8596b661aff8056961f18
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599907"
---
# <a name="get-all-add-ons"></a><span data-ttu-id="ad82c-104">すべてのアドオンの入手</span><span class="sxs-lookup"><span data-stu-id="ad82c-104">Get all add-ons</span></span>

<span data-ttu-id="ad82c-105">Microsoft Store 送信 API でこのメソッドを使用して、データ、パートナー センター アカウントに登録されているすべてのアプリのすべてのアドオンを取得します。</span><span class="sxs-lookup"><span data-stu-id="ad82c-105">Use this method in the Microsoft Store submission API to retrieve data for all add-ons for all the apps that are registered to your Partner Center account.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="ad82c-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="ad82c-106">Prerequisites</span></span>

<span data-ttu-id="ad82c-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="ad82c-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="ad82c-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="ad82c-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="ad82c-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="ad82c-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="ad82c-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="ad82c-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="ad82c-111">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="ad82c-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="ad82c-112">要求</span><span class="sxs-lookup"><span data-stu-id="ad82c-112">Request</span></span>

<span data-ttu-id="ad82c-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="ad82c-113">This method has the following syntax.</span></span> <span data-ttu-id="ad82c-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad82c-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="ad82c-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="ad82c-115">Method</span></span> | <span data-ttu-id="ad82c-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="ad82c-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="ad82c-117">GET</span><span class="sxs-lookup"><span data-stu-id="ad82c-117">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts``` |


### <a name="request-header"></a><span data-ttu-id="ad82c-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ad82c-118">Request header</span></span>

| <span data-ttu-id="ad82c-119">Header</span><span class="sxs-lookup"><span data-stu-id="ad82c-119">Header</span></span>        | <span data-ttu-id="ad82c-120">種類</span><span class="sxs-lookup"><span data-stu-id="ad82c-120">Type</span></span>   | <span data-ttu-id="ad82c-121">説明</span><span class="sxs-lookup"><span data-stu-id="ad82c-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="ad82c-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="ad82c-122">Authorization</span></span> | <span data-ttu-id="ad82c-123">string</span><span class="sxs-lookup"><span data-stu-id="ad82c-123">string</span></span> | <span data-ttu-id="ad82c-124">必須。</span><span class="sxs-lookup"><span data-stu-id="ad82c-124">Required.</span></span> <span data-ttu-id="ad82c-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="ad82c-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="ad82c-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="ad82c-126">Request parameters</span></span>

<span data-ttu-id="ad82c-127">このメソッドでは、要求パラメーターはすべてオプションです。</span><span class="sxs-lookup"><span data-stu-id="ad82c-127">All request parameters are optional for this method.</span></span> <span data-ttu-id="ad82c-128">パラメーターを指定せずにこのメソッドを呼び出す場合、応答には、アカウントに登録するすべてのアプリのすべてのアドオンのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ad82c-128">If you call this method without parameters, the response contains data for all add-ons for all apps that are registered to your account.</span></span>

|  <span data-ttu-id="ad82c-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ad82c-129">Parameter</span></span>  |  <span data-ttu-id="ad82c-130">種類</span><span class="sxs-lookup"><span data-stu-id="ad82c-130">Type</span></span>  |  <span data-ttu-id="ad82c-131">説明</span><span class="sxs-lookup"><span data-stu-id="ad82c-131">Description</span></span>  |  <span data-ttu-id="ad82c-132">必須</span><span class="sxs-lookup"><span data-stu-id="ad82c-132">Required</span></span>  |
|------|------|------|------|
|  <span data-ttu-id="ad82c-133">top</span><span class="sxs-lookup"><span data-stu-id="ad82c-133">top</span></span>  |  <span data-ttu-id="ad82c-134">int</span><span class="sxs-lookup"><span data-stu-id="ad82c-134">int</span></span>  |  <span data-ttu-id="ad82c-135">要求で返される項目の数 (つまり、返されるアドオンの数)。</span><span class="sxs-lookup"><span data-stu-id="ad82c-135">The number of items to return in the request (that is, the number of add-ons to return).</span></span> <span data-ttu-id="ad82c-136">クエリで指定した値よりアカウントのアドオンの数が多い場合、応答本文には、データの次のページを要求するためにメソッド URI に追加できる相対 URI パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ad82c-136">If your account has more add-ons than the value you specify in the query, the response body includes a relative URI path that you can append to the method URI to request the next page of data.</span></span>  |  <span data-ttu-id="ad82c-137">X</span><span class="sxs-lookup"><span data-stu-id="ad82c-137">No</span></span>  |
|  <span data-ttu-id="ad82c-138">skip</span><span class="sxs-lookup"><span data-stu-id="ad82c-138">skip</span></span>  |  <span data-ttu-id="ad82c-139">int</span><span class="sxs-lookup"><span data-stu-id="ad82c-139">int</span></span>  |  <span data-ttu-id="ad82c-140">残りの項目を返す前にクエリでバイパスする項目の数。</span><span class="sxs-lookup"><span data-stu-id="ad82c-140">The number of items to bypass in the query before returning the remaining items.</span></span> <span data-ttu-id="ad82c-141">データ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="ad82c-141">Use this parameter to page through data sets.</span></span> <span data-ttu-id="ad82c-142">たとえば、top = 10 と skip = 0 は、1 から 10 の項目を取得し、top=10 と skip=10 は 11 から 20 の項目を取得するという具合です。</span><span class="sxs-lookup"><span data-stu-id="ad82c-142">For example, top=10 and skip=0 retrieves items 1 through 10, top=10 and skip=10 retrieves items 11 through 20, and so on.</span></span>  |  <span data-ttu-id="ad82c-143">X</span><span class="sxs-lookup"><span data-stu-id="ad82c-143">No</span></span>  |


### <a name="request-body"></a><span data-ttu-id="ad82c-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="ad82c-144">Request body</span></span>

<span data-ttu-id="ad82c-145">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="ad82c-145">Do not provide a request body for this method.</span></span>

### <a name="request-examples"></a><span data-ttu-id="ad82c-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="ad82c-146">Request examples</span></span>

<span data-ttu-id="ad82c-147">次の例は、アカウントに登録するすべてのアプリのすべてのアドオン データを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ad82c-147">The following example demonstrates how to retrieve all add-on data for all the apps that are registered to your account.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts HTTP/1.1
Authorization: Bearer <your access token>
```

<span data-ttu-id="ad82c-148">次の例は、最初の 10 個のアドオンのみを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ad82c-148">The following example demonstrates how to retrieve the first 10 add-ons only.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts?top=10 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="ad82c-149">応答</span><span class="sxs-lookup"><span data-stu-id="ad82c-149">Response</span></span>

<span data-ttu-id="ad82c-150">次の例は、合計 1072 個のアドオンがある開発者アカウントに登録されている、最初の 5 個のアドオンに対する要求が成功した場合に返される JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="ad82c-150">The following example demonstrates the JSON response body returned by a successful request for the first 5 add-ons that are registered to a developer account with 1072 total add-ons.</span></span> <span data-ttu-id="ad82c-151">簡潔にするために、この例では、要求によって返される最初の 2 つのアドオンのデータのみが示されています。</span><span class="sxs-lookup"><span data-stu-id="ad82c-151">For brevity, this example only shows the data for the first two add-ons returned by the request.</span></span> <span data-ttu-id="ad82c-152">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad82c-152">For more details about the values in the response body, see the following section.</span></span>

```json
{
  "@nextLink": "inappproducts/?skip=5&top=5",
  "value": [
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
      "productId": "a8b8310b-fa8d-4da0-aca0-577ef6dce4dd",
      "productType": "Consumable",
      "pendingInAppProductSubmission": {
        "id": "1152921504621243619",
        "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243619"
      },
      "lastPublishedInAppProductSubmission": {
        "id": "1152921504621243705",
        "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243705"
      }
    },
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
      "id": "9NBLGGH4TNMN",
      "productId": "6a3c9788-a350-448a-bd32-16160a13018a",
      "productType": "Consumable",
      "pendingInAppProductSubmission": {
        "id": "1152921504621243538",
        "resourceLocation": "inappproducts/9NBLGGH4TNMN/submissions/1152921504621243538"
      },
      "lastPublishedInAppProductSubmission": {
        "id": "1152921504621243106",
        "resourceLocation": "inappproducts/9NBLGGH4TNMN/submissions/1152921504621243106"
      }
    },

  // Other add-ons omitted for brevity...
  ],
  "totalCount": 1072
}
```

### <a name="response-body"></a><span data-ttu-id="ad82c-153">応答本文</span><span class="sxs-lookup"><span data-stu-id="ad82c-153">Response body</span></span>

| <span data-ttu-id="ad82c-154">Value</span><span class="sxs-lookup"><span data-stu-id="ad82c-154">Value</span></span>      | <span data-ttu-id="ad82c-155">種類</span><span class="sxs-lookup"><span data-stu-id="ad82c-155">Type</span></span>   | <span data-ttu-id="ad82c-156">説明</span><span class="sxs-lookup"><span data-stu-id="ad82c-156">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| @nextLink  | <span data-ttu-id="ad82c-157">string</span><span class="sxs-lookup"><span data-stu-id="ad82c-157">string</span></span> | <span data-ttu-id="ad82c-158">データの追加ページが存在する場合、この文字列には、データの次のページを要求するために、ベースとなる ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に追加できる相対パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ad82c-158">If there are additional pages of data, this string contains a relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to request the next page of data.</span></span> <span data-ttu-id="ad82c-159">たとえば、最初の要求本文の *top* パラメーターが 10 に設定されていて、アカウントには 100 個のアドオンが登録されている場合、応答本文には、```inappproducts?skip=10&top=10``` という @nextLink 値が含まれます。これは、次の 10 個のアドオンを要求するために、```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts?skip=10&top=10``` を呼び出すことができることを示しています。</span><span class="sxs-lookup"><span data-stu-id="ad82c-159">For example, if the *top* parameter of the initial request body is set to 10 but there are 100 add-ons registered to your account, the response body will include a @nextLink value of ```inappproducts?skip=10&top=10```, which indicates that you can call ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts?skip=10&top=10``` to request the next 10 add-ons.</span></span> |
| <span data-ttu-id="ad82c-160">value</span><span class="sxs-lookup"><span data-stu-id="ad82c-160">value</span></span>            | <span data-ttu-id="ad82c-161">array</span><span class="sxs-lookup"><span data-stu-id="ad82c-161">array</span></span>  |  <span data-ttu-id="ad82c-162">各アドオンに関する情報を提供するオブジェクトを格納する配列。</span><span class="sxs-lookup"><span data-stu-id="ad82c-162">An array that contains objects that provide information about each add-on.</span></span> <span data-ttu-id="ad82c-163">詳しくは、「[アドオン リソース](manage-add-ons.md#add-on-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad82c-163">For more information, see [add-on resource](manage-add-ons.md#add-on-object).</span></span>   |
| <span data-ttu-id="ad82c-164">totalCount</span><span class="sxs-lookup"><span data-stu-id="ad82c-164">totalCount</span></span>   | <span data-ttu-id="ad82c-165">int</span><span class="sxs-lookup"><span data-stu-id="ad82c-165">int</span></span>  | <span data-ttu-id="ad82c-166">応答本文の *value* 配列のアプリ オブジェクトの数。</span><span class="sxs-lookup"><span data-stu-id="ad82c-166">The number of app objects in the *value* array of the response body.</span></span>     |


## <a name="error-codes"></a><span data-ttu-id="ad82c-167">エラー コード</span><span class="sxs-lookup"><span data-stu-id="ad82c-167">Error codes</span></span>

<span data-ttu-id="ad82c-168">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="ad82c-168">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="ad82c-169">エラー コード</span><span class="sxs-lookup"><span data-stu-id="ad82c-169">Error code</span></span> |  <span data-ttu-id="ad82c-170">説明</span><span class="sxs-lookup"><span data-stu-id="ad82c-170">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="ad82c-171">404</span><span class="sxs-lookup"><span data-stu-id="ad82c-171">404</span></span>  | <span data-ttu-id="ad82c-172">アドオンは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="ad82c-172">No add-ons were found.</span></span> |
| <span data-ttu-id="ad82c-173">409</span><span class="sxs-lookup"><span data-stu-id="ad82c-173">409</span></span>  | <span data-ttu-id="ad82c-174">アプリまたはアドオンはパートナー センターの機能を使用して、[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。</span><span class="sxs-lookup"><span data-stu-id="ad82c-174">The apps or add-ons use Partner Center features that are [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="ad82c-175">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ad82c-175">Related topics</span></span>

* [<span data-ttu-id="ad82c-176">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="ad82c-176">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="ad82c-177">アドオンの送信を管理します。</span><span class="sxs-lookup"><span data-stu-id="ad82c-177">Manage add-on submissions</span></span>](manage-add-on-submissions.md)
* [<span data-ttu-id="ad82c-178">アドオンを入手します。</span><span class="sxs-lookup"><span data-stu-id="ad82c-178">Get an add-on</span></span>](get-an-add-on.md)
* [<span data-ttu-id="ad82c-179">アドオンを作成します。</span><span class="sxs-lookup"><span data-stu-id="ad82c-179">Create an add-on</span></span>](create-an-add-on.md)
* [<span data-ttu-id="ad82c-180">アドオンを削除します。</span><span class="sxs-lookup"><span data-stu-id="ad82c-180">Delete an add-on</span></span>](delete-an-add-on.md)
