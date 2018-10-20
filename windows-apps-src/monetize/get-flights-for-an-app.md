---
author: Xansky
ms.assetid: B0AD0B8E-867E-4403-9CF6-43C81F3C30CA
description: Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライト情報を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリのパッケージ フライトの取得
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライト, パッケージ フライト
ms.localizationpriority: medium
ms.openlocfilehash: d6349e5c597b923ba05abe5ed74492409350e36e
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/20/2018
ms.locfileid: "5170989"
---
# <a name="get-package-flights-for-an-app"></a><span data-ttu-id="9a262-104">アプリのパッケージ フライトの取得</span><span class="sxs-lookup"><span data-stu-id="9a262-104">Get package flights for an app</span></span>

<span data-ttu-id="9a262-105">Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトの一覧を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="9a262-105">Use this method in the Microsoft Store submission API to list the package flights for an app that is registered to your Windows Dev Center account.</span></span> <span data-ttu-id="9a262-106">パッケージ フライトについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a262-106">For more information about package flights, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="9a262-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="9a262-107">Prerequisites</span></span>

<span data-ttu-id="9a262-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a262-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="9a262-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="9a262-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="9a262-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="9a262-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="9a262-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="9a262-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="9a262-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="9a262-112">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="9a262-113">要求</span><span class="sxs-lookup"><span data-stu-id="9a262-113">Request</span></span>

<span data-ttu-id="9a262-114">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9a262-114">This method has the following syntax.</span></span> <span data-ttu-id="9a262-115">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a262-115">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="9a262-116">メソッド</span><span class="sxs-lookup"><span data-stu-id="9a262-116">Method</span></span> | <span data-ttu-id="9a262-117">要求 URI</span><span class="sxs-lookup"><span data-stu-id="9a262-117">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="9a262-118">GET</span><span class="sxs-lookup"><span data-stu-id="9a262-118">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listflights``` |


### <a name="request-header"></a><span data-ttu-id="9a262-119">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9a262-119">Request header</span></span>

| <span data-ttu-id="9a262-120">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9a262-120">Header</span></span>        | <span data-ttu-id="9a262-121">型</span><span class="sxs-lookup"><span data-stu-id="9a262-121">Type</span></span>   | <span data-ttu-id="9a262-122">説明</span><span class="sxs-lookup"><span data-stu-id="9a262-122">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="9a262-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="9a262-123">Authorization</span></span> | <span data-ttu-id="9a262-124">string</span><span class="sxs-lookup"><span data-stu-id="9a262-124">string</span></span> | <span data-ttu-id="9a262-125">必須。</span><span class="sxs-lookup"><span data-stu-id="9a262-125">Required.</span></span> <span data-ttu-id="9a262-126">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="9a262-126">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="9a262-127">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="9a262-127">Request parameters</span></span>

|  <span data-ttu-id="9a262-128">名前</span><span class="sxs-lookup"><span data-stu-id="9a262-128">Name</span></span>  |  <span data-ttu-id="9a262-129">種類</span><span class="sxs-lookup"><span data-stu-id="9a262-129">Type</span></span>  |  <span data-ttu-id="9a262-130">説明</span><span class="sxs-lookup"><span data-stu-id="9a262-130">Description</span></span>  |  <span data-ttu-id="9a262-131">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="9a262-131">Required</span></span>  |
|------|------|------|------|
|  <span data-ttu-id="9a262-132">applicationId</span><span class="sxs-lookup"><span data-stu-id="9a262-132">applicationId</span></span>  |  <span data-ttu-id="9a262-133">string</span><span class="sxs-lookup"><span data-stu-id="9a262-133">string</span></span>  |  <span data-ttu-id="9a262-134">パッケージ フライトを取得するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="9a262-134">The Store ID of the app for which you want to retrieve the package flights.</span></span> <span data-ttu-id="9a262-135">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a262-135">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |  <span data-ttu-id="9a262-136">必須</span><span class="sxs-lookup"><span data-stu-id="9a262-136">Yes</span></span>  |
|  <span data-ttu-id="9a262-137">top</span><span class="sxs-lookup"><span data-stu-id="9a262-137">top</span></span>  |  <span data-ttu-id="9a262-138">int</span><span class="sxs-lookup"><span data-stu-id="9a262-138">int</span></span>  |  <span data-ttu-id="9a262-139">要求で返される項目の数 (つまり、返されるパッケージ フライトの数)。</span><span class="sxs-lookup"><span data-stu-id="9a262-139">The number of items to return in the request (that is, the number of package flights to return).</span></span> <span data-ttu-id="9a262-140">クエリで指定した値よりアカウントのパッケージ フライトの数が多い場合、応答本文には、データの次のページを要求するためにメソッド URI に追加できる相対 URI パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="9a262-140">If your account has more package flights than the value you specify in the query, the response body includes a relative URI path that you can append to the method URI to request the next page of data.</span></span>  |  <span data-ttu-id="9a262-141">必須ではない</span><span class="sxs-lookup"><span data-stu-id="9a262-141">No</span></span>  |
|  <span data-ttu-id="9a262-142">skip</span><span class="sxs-lookup"><span data-stu-id="9a262-142">skip</span></span>  |  <span data-ttu-id="9a262-143">int</span><span class="sxs-lookup"><span data-stu-id="9a262-143">int</span></span>  |  <span data-ttu-id="9a262-144">残りの項目を返す前にクエリでバイパスする項目の数。</span><span class="sxs-lookup"><span data-stu-id="9a262-144">The number of items to bypass in the query before returning the remaining items.</span></span> <span data-ttu-id="9a262-145">データ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="9a262-145">Use this parameter to page through data sets.</span></span> <span data-ttu-id="9a262-146">たとえば、top = 10 と skip = 0 は、1 から 10 の項目を取得し、top=10 と skip=10 は 11 から 20 の項目を取得するという具合です。</span><span class="sxs-lookup"><span data-stu-id="9a262-146">For example, top=10 and skip=0 retrieves items 1 through 10, top=10 and skip=10 retrieves items 11 through 20, and so on.</span></span>  |  <span data-ttu-id="9a262-147">必須ではない</span><span class="sxs-lookup"><span data-stu-id="9a262-147">No</span></span>  |


### <a name="request-body"></a><span data-ttu-id="9a262-148">要求本文</span><span class="sxs-lookup"><span data-stu-id="9a262-148">Request body</span></span>

<span data-ttu-id="9a262-149">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="9a262-149">Do not provide a request body for this method.</span></span>

### <a name="request-examples"></a><span data-ttu-id="9a262-150">要求の例</span><span class="sxs-lookup"><span data-stu-id="9a262-150">Request examples</span></span>

<span data-ttu-id="9a262-151">次の例は、アプリのすべてのパッケージ フライトを一覧表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="9a262-151">The following example demonstrates how to list all the package flights for an app.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/listflights HTTP/1.1
Authorization: Bearer <your access token>
```

<span data-ttu-id="9a262-152">次の例は、アプリの 1 番目のパッケージ フライトを表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="9a262-152">The following example demonstrates how to list the first package flight for an app.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/listflights?top=1 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="9a262-153">応答</span><span class="sxs-lookup"><span data-stu-id="9a262-153">Response</span></span>

<span data-ttu-id="9a262-154">次の例は、合計 3 個のパッケージ フライトがあるアプリの、1 番目のパッケージ フライトに対する要求が成功した場合に返される JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="9a262-154">The following example demonstrates the JSON response body returned by a successful request for the first package flight for an app with three total package flights.</span></span> <span data-ttu-id="9a262-155">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a262-155">For more details about the values in the response body, see the following section.</span></span>

```json
{
  "value": [
    {
      "flightId": "7bfc11d5-f710-47c5-8a98-e04bb5aad310",
      "friendlyName": "myflight",
      "lastPublishedFlightSubmission": {
        "id": "1152921504621086517",
        "resourceLocation": "flights/7bfc11d5-f710-47c5-8a98-e04bb5aad310/submissions/1152921504621086517"
      },
      "pendingFlightSubmission": {
        "id": "1152921504621215786",
        "resourceLocation": "flights/7bfc11d5-f710-47c5-8a98-e04bb5aad310/submissions/1152921504621215786"
      },
      "groupIds": [
        "1152921504606962205"
      ],
      "rankHigherThan": "Non-flighted submission"
    }
  ],
  "totalCount": 3
}
```

### <a name="response-body"></a><span data-ttu-id="9a262-156">応答本文</span><span class="sxs-lookup"><span data-stu-id="9a262-156">Response body</span></span>

| <span data-ttu-id="9a262-157">値</span><span class="sxs-lookup"><span data-stu-id="9a262-157">Value</span></span>      | <span data-ttu-id="9a262-158">型</span><span class="sxs-lookup"><span data-stu-id="9a262-158">Type</span></span>   | <span data-ttu-id="9a262-159">説明</span><span class="sxs-lookup"><span data-stu-id="9a262-159">Description</span></span>       |
|------------|--------|---------------------|
| @nextLink  | <span data-ttu-id="9a262-160">string</span><span class="sxs-lookup"><span data-stu-id="9a262-160">string</span></span> | <span data-ttu-id="9a262-161">データの追加ページが存在する場合、この文字列には、データの次のページを要求するために、ベースとなる ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に追加できる相対パスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="9a262-161">If there are additional pages of data, this string contains a relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to request the next page of data.</span></span> <span data-ttu-id="9a262-162">たとえば、最初の要求本文の *top* パラメーターが 2 に設定されていて、アプリには 4 個のパッケージ フライトが存在する場合、応答本文には、```applications/{applicationid}/listflights/?skip=2&top=2``` という @nextLink 値が含まれます。これは、次の 2 個のパッケージ フライトを要求するために、```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationid}/listflights/?skip=2&top=2``` を呼び出すことができることを示しています。</span><span class="sxs-lookup"><span data-stu-id="9a262-162">For example, if the *top* parameter of the initial request body is set to 2 but there are 4 package flights for the app, the response body will include a @nextLink value of ```applications/{applicationid}/listflights/?skip=2&top=2```, which indicates that you can call ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationid}/listflights/?skip=2&top=2``` to request the next 2 package flights.</span></span> |
| <span data-ttu-id="9a262-163">value</span><span class="sxs-lookup"><span data-stu-id="9a262-163">value</span></span>      | <span data-ttu-id="9a262-164">array</span><span class="sxs-lookup"><span data-stu-id="9a262-164">array</span></span>  | <span data-ttu-id="9a262-165">指定されたアプリのパッケージ フライトに関する情報を提供するオブジェクトの配列。</span><span class="sxs-lookup"><span data-stu-id="9a262-165">An array of objects that provide information about package flights for the specified app.</span></span> <span data-ttu-id="9a262-166">各オブジェクトのデータについて詳しくは、「[フライト リソース](get-app-data.md#flight-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a262-166">For more information about the data in each object, see [Flight resource](get-app-data.md#flight-object).</span></span>               |
| <span data-ttu-id="9a262-167">totalCount</span><span class="sxs-lookup"><span data-stu-id="9a262-167">totalCount</span></span> | <span data-ttu-id="9a262-168">int</span><span class="sxs-lookup"><span data-stu-id="9a262-168">int</span></span>    | <span data-ttu-id="9a262-169">クエリのデータ結果の行の合計数 (つまり、指定されたアプリのパッケージ フライトの合計数)。</span><span class="sxs-lookup"><span data-stu-id="9a262-169">The total number of rows in the data result for the query (that is, the total number of package flights for the specified app).</span></span>   |


## <a name="error-codes"></a><span data-ttu-id="9a262-170">エラー コード</span><span class="sxs-lookup"><span data-stu-id="9a262-170">Error codes</span></span>

<span data-ttu-id="9a262-171">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="9a262-171">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="9a262-172">エラー コード</span><span class="sxs-lookup"><span data-stu-id="9a262-172">Error code</span></span> |  <span data-ttu-id="9a262-173">説明</span><span class="sxs-lookup"><span data-stu-id="9a262-173">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="9a262-174">404</span><span class="sxs-lookup"><span data-stu-id="9a262-174">404</span></span>  | <span data-ttu-id="9a262-175">パッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="9a262-175">No package flights were found.</span></span> |
| <span data-ttu-id="9a262-176">409</span><span class="sxs-lookup"><span data-stu-id="9a262-176">409</span></span>  | <span data-ttu-id="9a262-177">アプリが、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能を使用しています。</span><span class="sxs-lookup"><span data-stu-id="9a262-177">The app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span>  |


## <a name="related-topics"></a><span data-ttu-id="9a262-178">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9a262-178">Related topics</span></span>

* [<span data-ttu-id="9a262-179">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="9a262-179">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="9a262-180">すべてのアプリの取得</span><span class="sxs-lookup"><span data-stu-id="9a262-180">Get all apps</span></span>](get-all-apps.md)
* [<span data-ttu-id="9a262-181">アプリの入手</span><span class="sxs-lookup"><span data-stu-id="9a262-181">Get an app</span></span>](get-an-app.md)
* [<span data-ttu-id="9a262-182">アプリのアドオンの入手</span><span class="sxs-lookup"><span data-stu-id="9a262-182">Get add-ons for an app</span></span>](get-add-ons-for-an-app.md)
