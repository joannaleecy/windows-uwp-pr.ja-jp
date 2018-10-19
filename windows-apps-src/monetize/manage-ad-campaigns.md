---
author: Xansky
ms.assetid: 7b07a6ca-4be1-497c-a901-0a2da3762555
description: プロモーション用の広告キャンペーンを作成、編集、取得するには、Microsoft Store プロモーション API の以下のメソッドを使います。
title: 広告キャンペーンの管理
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store プロモーション API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: f707c252e404da3aaf6e82317c80a266f4d91d26
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4962613"
---
# <a name="manage-ad-campaigns"></a><span data-ttu-id="a9e0b-104">広告キャンペーンの管理</span><span class="sxs-lookup"><span data-stu-id="a9e0b-104">Manage ad campaigns</span></span>

<span data-ttu-id="a9e0b-105">アプリのプロモーション用の広告キャンペーンを作成、編集、取得するには、[Microsoft Store プロモーション API](run-ad-campaigns-using-windows-store-services.md) の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-105">Use these methods in the [Microsoft Store promotions API](run-ad-campaigns-using-windows-store-services.md) to create, edit and get promotional ad campaigns for your app.</span></span> <span data-ttu-id="a9e0b-106">このメソッドを使って作成した各キャンペーンに関連付けることができるのは、1 つのアプリのみです。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-106">Each campaign you create using this method can be associated with only one app.</span></span>

><span data-ttu-id="a9e0b-107">**注**&nbsp;&nbsp;Windows デベロッパー センター ダッシュボードを使用して広告キャンペーンを作成し、管理することもできます。プログラムにより作成したキャンペーンには、ダッシュボードからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-107">**Note**&nbsp;&nbsp;You can also create and manage ad campaigns using the Windows Dev Center dashboard, and campaigns that you create programmatically can be accessed in the dashboard.</span></span> <span data-ttu-id="a9e0b-108">ダッシュボードでの広告キャンペーンの管理について詳しくは、「[アプリ向けの広告キャンペーンの作成](../publish/create-an-ad-campaign-for-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-108">For more information about managing ad campaigns in the dashboard, see [Create an ad campaign for your app](../publish/create-an-ad-campaign-for-your-app.md).</span></span>

<span data-ttu-id="a9e0b-109">これらのメソッドを使ってキャンペーンを作成または更新する場合、通常は以下のメソッドも 1 つ以上呼び出し、キャンペーンに関連付けられた*配信ライン*、*対象プロファイル*、*クリエイティブ*を管理します。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-109">When you use these methods to create or update a campaign, you typically also call one or more of the following methods to manage the *delivery lines*, *targeting profiles*, and *creatives* that are associated with the campaign.</span></span> <span data-ttu-id="a9e0b-110">キャンペーン、配信ライン、ターゲット プロファイル、クリエイティブ間の関係について詳しくは、「[Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-110">For more information about the relationship between campaigns, delivery lines, targeting profiles, and creatives, see [Run ad campaigns using Microsoft Store services](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api).</span></span>

* [<span data-ttu-id="a9e0b-111">広告キャンペーンの配信ラインの管理</span><span class="sxs-lookup"><span data-stu-id="a9e0b-111">Manage delivery lines for ad campaigns</span></span>](manage-delivery-lines-for-ad-campaigns.md)
* [<span data-ttu-id="a9e0b-112">広告キャンペーンの対象プロファイルの管理</span><span class="sxs-lookup"><span data-stu-id="a9e0b-112">Manage targeting profiles for ad campaigns</span></span>](manage-targeting-profiles-for-ad-campaigns.md)
* [<span data-ttu-id="a9e0b-113">広告キャンペーンのクリエイティブの管理</span><span class="sxs-lookup"><span data-stu-id="a9e0b-113">Manage creatives for ad campaigns</span></span>](manage-creatives-for-ad-campaigns.md)

## <a name="prerequisites"></a><span data-ttu-id="a9e0b-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="a9e0b-114">Prerequisites</span></span>

<span data-ttu-id="a9e0b-115">これらのメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-115">To use these methods, you need to first do the following:</span></span>

* <span data-ttu-id="a9e0b-116">Microsoft Store プロモーション API に関するすべての[前提条件](run-ad-campaigns-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-116">If you have not done so already, complete all the [prerequisites](run-ad-campaigns-using-windows-store-services.md#prerequisites) for the Microsoft Store promotions API.</span></span>

  ><span data-ttu-id="a9e0b-117">**注**&nbsp;&nbsp;前提条件の一部として、[デベロッパー センター ダッシュボードで有料の広告キャンペーンを少なくとも 1 つ作成する](../publish/create-an-ad-campaign-for-your-app.md)必要があります。また、ダッシュボードで、広告キャンペーンの支払い方法を少なくとも 1 つ追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-117">**Note**&nbsp;&nbsp;As part of the prerequisites, be sure that you [create at least one paid ad campaign in the Dev Center dashboard](../publish/create-an-ad-campaign-for-your-app.md) and that you add at least one payment instrument for the ad campaign in the dashboard.</span></span> <span data-ttu-id="a9e0b-118">この API を使用して作成した広告キャンペーンの配信ラインでは、ダッシュ ボードの **[アプリの宣伝]** ページで選んだ既定の支払い方法に対して自動的に請求が行われます。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-118">Delivery lines for ad campaigns you create using this API will automatically bill the default payment instrument chosen on the **Promote your app** page in the dashboard.</span></span>

* <span data-ttu-id="a9e0b-119">これらのメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-119">[Obtain an Azure AD access token](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for these methods.</span></span> <span data-ttu-id="a9e0b-120">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-120">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="a9e0b-121">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-121">After the token expires, you can obtain a new one.</span></span>


## <a name="request"></a><span data-ttu-id="a9e0b-122">要求</span><span class="sxs-lookup"><span data-stu-id="a9e0b-122">Request</span></span>

<span data-ttu-id="a9e0b-123">これらのメソッドでは、次の URL が使用されます。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-123">These methods have the following URIs.</span></span>

| <span data-ttu-id="a9e0b-124">メソッドの種類</span><span class="sxs-lookup"><span data-stu-id="a9e0b-124">Method type</span></span> | <span data-ttu-id="a9e0b-125">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a9e0b-125">Request URI</span></span>                                                      |  <span data-ttu-id="a9e0b-126">説明</span><span class="sxs-lookup"><span data-stu-id="a9e0b-126">Description</span></span>  |
|--------|------------------------------------------------------------------|---------------|
| <span data-ttu-id="a9e0b-127">POST</span><span class="sxs-lookup"><span data-stu-id="a9e0b-127">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign``` |  <span data-ttu-id="a9e0b-128">新しい広告キャンペーンを作成します。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-128">Creates a new ad campaign.</span></span>  |
| <span data-ttu-id="a9e0b-129">PUT</span><span class="sxs-lookup"><span data-stu-id="a9e0b-129">PUT</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign/{campaignId}``` |  <span data-ttu-id="a9e0b-130">*campaignId* により指定された広告キャンペーンを編集します。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-130">Edits the ad campaign specified by *campaignId*.</span></span>  |
| <span data-ttu-id="a9e0b-131">GET</span><span class="sxs-lookup"><span data-stu-id="a9e0b-131">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign/{campaignId}``` |  <span data-ttu-id="a9e0b-132">*campaignId* により指定された広告キャンペーンを取得します。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-132">Gets the ad campaign specified by *campaignId*.</span></span>  |
| <span data-ttu-id="a9e0b-133">GET</span><span class="sxs-lookup"><span data-stu-id="a9e0b-133">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign``` |  <span data-ttu-id="a9e0b-134">広告キャンペーンのクエリ。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-134">Queries for ad campaigns.</span></span> <span data-ttu-id="a9e0b-135">サポートされるクエリ パラメーターの「[パラメーター](#parameters)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-135">See the [Parameters](#parameters) section for the supported query parameters.</span></span>  |


### <a name="header"></a><span data-ttu-id="a9e0b-136">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a9e0b-136">Header</span></span>

| <span data-ttu-id="a9e0b-137">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a9e0b-137">Header</span></span>        | <span data-ttu-id="a9e0b-138">型</span><span class="sxs-lookup"><span data-stu-id="a9e0b-138">Type</span></span>   | <span data-ttu-id="a9e0b-139">説明</span><span class="sxs-lookup"><span data-stu-id="a9e0b-139">Description</span></span>         |
|---------------|--------|---------------------|
| <span data-ttu-id="a9e0b-140">Authorization</span><span class="sxs-lookup"><span data-stu-id="a9e0b-140">Authorization</span></span> | <span data-ttu-id="a9e0b-141">string</span><span class="sxs-lookup"><span data-stu-id="a9e0b-141">string</span></span> | <span data-ttu-id="a9e0b-142">必須。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-142">Required.</span></span> <span data-ttu-id="a9e0b-143">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-143">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |
| <span data-ttu-id="a9e0b-144">追跡 ID</span><span class="sxs-lookup"><span data-stu-id="a9e0b-144">Tracking ID</span></span>   | <span data-ttu-id="a9e0b-145">GUID</span><span class="sxs-lookup"><span data-stu-id="a9e0b-145">GUID</span></span>   | <span data-ttu-id="a9e0b-146">省略可能。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-146">Optional.</span></span> <span data-ttu-id="a9e0b-147">呼び出しフローを追跡する ID。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-147">An ID that tracks the call flow.</span></span>                                  |


<span id="parameters"/> 

### <a name="parameters"></a><span data-ttu-id="a9e0b-148">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a9e0b-148">Parameters</span></span>

<span data-ttu-id="a9e0b-149">広告キャンペーンを問い合わせる GET メソッドは、次のオプション クエリ パラメーターをサポートします。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-149">The GET method to query for ad campaigns supports the following optional query parameters.</span></span>

| <span data-ttu-id="a9e0b-150">名前</span><span class="sxs-lookup"><span data-stu-id="a9e0b-150">Name</span></span>        | <span data-ttu-id="a9e0b-151">種類</span><span class="sxs-lookup"><span data-stu-id="a9e0b-151">Type</span></span>   |  <span data-ttu-id="a9e0b-152">説明</span><span class="sxs-lookup"><span data-stu-id="a9e0b-152">Description</span></span>      |    
|-------------|--------|---------------|------|
| <span data-ttu-id="a9e0b-153">skip</span><span class="sxs-lookup"><span data-stu-id="a9e0b-153">skip</span></span>  |  <span data-ttu-id="a9e0b-154">int</span><span class="sxs-lookup"><span data-stu-id="a9e0b-154">int</span></span>   | <span data-ttu-id="a9e0b-155">クエリでスキップする行数です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-155">The number of rows to skip in the query.</span></span> <span data-ttu-id="a9e0b-156">データ セットを操作するには、このパラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-156">Use this parameter to page through data sets.</span></span> <span data-ttu-id="a9e0b-157">たとえば、fetch=10 と skip=0 を指定すると、データの最初の 10 行が取得され、top=10 と skip=10 を指定すると、データの次の 10 行が取得されます。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-157">For example, fetch=10 and skip=0 retrieves the first 10 rows of data, top=10 and skip=10 retrieves the next 10 rows of data, and so on.</span></span>    |       
| <span data-ttu-id="a9e0b-158">fetch</span><span class="sxs-lookup"><span data-stu-id="a9e0b-158">fetch</span></span>  |  <span data-ttu-id="a9e0b-159">整数</span><span class="sxs-lookup"><span data-stu-id="a9e0b-159">int</span></span>   | <span data-ttu-id="a9e0b-160">要求で返すデータの行数です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-160">The number of rows of data to return in the request.</span></span>    |       
| <span data-ttu-id="a9e0b-161">campaignSetSortColumn</span><span class="sxs-lookup"><span data-stu-id="a9e0b-161">campaignSetSortColumn</span></span>  |  <span data-ttu-id="a9e0b-162">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-162">string</span></span>   | <span data-ttu-id="a9e0b-163">応答本文で、指定されたフィールドにより[キャンペーン](#campaign) オブジェクトを順序付けます。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-163">Orders the [Campaign](#campaign) objects in the response body by the specified field.</span></span> <span data-ttu-id="a9e0b-164">構文は <em>CampaignSetSortColumn=field</em> です。ここで、<em>field</em> パラメーターは次のいずれかの文字列になります。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-164">The syntax is <em>CampaignSetSortColumn=field</em>, where the <em>field</em> parameter can be one of the following strings:</span></span></p><ul><li><strong><span data-ttu-id="a9e0b-165">id</span><span class="sxs-lookup"><span data-stu-id="a9e0b-165">id</span></span></strong></li><li><strong><span data-ttu-id="a9e0b-166">createdDateTime</span><span class="sxs-lookup"><span data-stu-id="a9e0b-166">createdDateTime</span></span></strong></li></ul><p><span data-ttu-id="a9e0b-167">既定値は **createdDateTime** です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-167">The default is **createdDateTime**.</span></span>     |     
| <span data-ttu-id="a9e0b-168">isDescending</span><span class="sxs-lookup"><span data-stu-id="a9e0b-168">isDescending</span></span>  |  <span data-ttu-id="a9e0b-169">ブール値</span><span class="sxs-lookup"><span data-stu-id="a9e0b-169">Boolean</span></span>   | <span data-ttu-id="a9e0b-170">応答本文で、[キャンペーン](#campaign) オブジェクトを降順または昇順で並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-170">Sorts the [Campaign](#campaign) objects in the response body in descending or ascending order.</span></span>   |         
| <span data-ttu-id="a9e0b-171">storeProductId</span><span class="sxs-lookup"><span data-stu-id="a9e0b-171">storeProductId</span></span>  |  <span data-ttu-id="a9e0b-172">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-172">string</span></span>   | <span data-ttu-id="a9e0b-173">指定された[ストア ID](in-app-purchases-and-trials.md#store-ids) を持つアプリに関連付けられた広告キャンペーンのみ返す場合は、この値を使います。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-173">Use this value to return only the ad campaigns that are associated with the app with the specified [Store ID](in-app-purchases-and-trials.md#store-ids).</span></span> <span data-ttu-id="a9e0b-174">製品のストア ID の例は、9nblggh42cfd です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-174">An example Store ID for a product is 9nblggh42cfd.</span></span>   |         
| <span data-ttu-id="a9e0b-175">label</span><span class="sxs-lookup"><span data-stu-id="a9e0b-175">label</span></span>  |  <span data-ttu-id="a9e0b-176">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-176">string</span></span>   | <span data-ttu-id="a9e0b-177">[キャンペーン](#campaign) オブジェクトに指定された*ラベル*が含まれる広告キャンペーンのみ返す場合は、この値を使います。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-177">Use this value to return only the ad campaigns that include the specified *label* in the [Campaign](#campaign) object.</span></span>    |       |    


### <a name="request-body"></a><span data-ttu-id="a9e0b-178">要求本文</span><span class="sxs-lookup"><span data-stu-id="a9e0b-178">Request body</span></span>

<span data-ttu-id="a9e0b-179">POST メソッドと PUT メソッドには、[キャンペーン](#campaign) オブジェクトの必須フィールドと設定または変更する追加フィールドを持つ JSON 要求本文が必要です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-179">The POST and PUT methods require a JSON request body with the required fields of a [Campaign](#campaign) object and any additional fields you want to set or change.</span></span>


### <a name="request-examples"></a><span data-ttu-id="a9e0b-180">要求の例</span><span class="sxs-lookup"><span data-stu-id="a9e0b-180">Request examples</span></span>

<span data-ttu-id="a9e0b-181">次の例は、POST メソッドを呼び出して広告キャンペーンを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-181">The following example demonstrates how to call the POST method to create an ad campaign.</span></span>

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign HTTP/1.1
Authorization: Bearer <your access token>

{
    "name": "Contoso App Campaign",
    "storeProductId": "9nblggh42cfd",
    "configuredStatus": "Active",
    "objective": "DriveInstalls",
    "type": "Community"
}
```

<span data-ttu-id="a9e0b-182">次の例は、GET メソッドを呼び出して特定の広告キャンペーンを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-182">The following example demonstrates how to call the GET method to retrieve a specific ad campaign.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign/31043481  HTTP/1.1
Authorization: Bearer <your access token>
```

<span data-ttu-id="a9e0b-183">次の例は、GET メソッドを呼び出して、作成日により並べ替えられた一連の広告キャンペーンを問い合わせる方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-183">The following example demonstrates how to call the GET method to query for a set of ad campaigns, sorted by the created date.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign?storeProductId=9nblggh42cfd&fetch=100&skip=0&campaignSetSortColumn=createdDateTime HTTP/1.1
Authorization: Bearer <your access token>
```


## <a name="response"></a><span data-ttu-id="a9e0b-184">応答</span><span class="sxs-lookup"><span data-stu-id="a9e0b-184">Response</span></span>

<span data-ttu-id="a9e0b-185">これらのメソッドは、呼び出したメソッドに応じて 1 つ以上の[キャンペーン](#campaign) オブジェクトを含む JSON 応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-185">These methods return a JSON response body with one or more [Campaign](#campaign) objects, depending on the method you called.</span></span> <span data-ttu-id="a9e0b-186">次の例は、特定のキャンペーンの GET メソッドの応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-186">The following example demonstrates a response body for the GET method for a specific campaign.</span></span>

```json
{
    "Data": {
        "id": 31043481,
        "name": "Contoso App Campaign",
        "createdDate": "2017-01-17T10:12:15Z",
        "storeProductId": "9nblggh42cfd",
        "configuredStatus": "Active",
        "effectiveStatus": "Active",
        "effectiveStatusReasons": [
            "{\"ValidationStatusReasons\":null}"
        ],
        "labels": [],
        "objective": "DriveInstalls",
        "type": "Paid",
        "lines": [
            {
                "id": 31043476,
                "name": "Contoso App Campaign - Paid Line"
            }
        ]
    }
}
```


<span id="campaign"/>

## <a name="campaign-object"></a><span data-ttu-id="a9e0b-187">キャンペーン オブジェクト</span><span class="sxs-lookup"><span data-stu-id="a9e0b-187">Campaign object</span></span>

<span data-ttu-id="a9e0b-188">これらのメソッドの要求本文と応答本文には、次のフィールドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-188">The request and response bodies for these methods contain the following fields.</span></span> <span data-ttu-id="a9e0b-189">この表は、読み取り専用のフィールド (つまり、PUT メソッドで変更できない) と POST メソッドの要求本文で必須のフィールドを示しています。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-189">This table shows which fields are read-only (meaning that they cannot be changed in the PUT method) and which fields are required in the request body for the POST method.</span></span>

| <span data-ttu-id="a9e0b-190">フィールド</span><span class="sxs-lookup"><span data-stu-id="a9e0b-190">Field</span></span>        | <span data-ttu-id="a9e0b-191">型</span><span class="sxs-lookup"><span data-stu-id="a9e0b-191">Type</span></span>   |  <span data-ttu-id="a9e0b-192">説明</span><span class="sxs-lookup"><span data-stu-id="a9e0b-192">Description</span></span>      |  <span data-ttu-id="a9e0b-193">読み取り専用かどうか</span><span class="sxs-lookup"><span data-stu-id="a9e0b-193">Read only</span></span>  | <span data-ttu-id="a9e0b-194">既定値</span><span class="sxs-lookup"><span data-stu-id="a9e0b-194">Default</span></span>  | <span data-ttu-id="a9e0b-195">POST に必須かどうか</span><span class="sxs-lookup"><span data-stu-id="a9e0b-195">Required for POST</span></span> |  
|--------------|--------|---------------|------|-------------|------------|
|  <span data-ttu-id="a9e0b-196">id</span><span class="sxs-lookup"><span data-stu-id="a9e0b-196">id</span></span>   |  <span data-ttu-id="a9e0b-197">整数</span><span class="sxs-lookup"><span data-stu-id="a9e0b-197">integer</span></span>   |  <span data-ttu-id="a9e0b-198">広告キャンペーンの ID です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-198">The ID of the ad campaign.</span></span>     |   <span data-ttu-id="a9e0b-199">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-199">Yes</span></span>    |      |  <span data-ttu-id="a9e0b-200">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-200">No</span></span>     |       
|  <span data-ttu-id="a9e0b-201">name</span><span class="sxs-lookup"><span data-stu-id="a9e0b-201">name</span></span>   |  <span data-ttu-id="a9e0b-202">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-202">string</span></span>   |   <span data-ttu-id="a9e0b-203">広告キャンペーンの名前です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-203">The name of the ad campaign.</span></span>    |    <span data-ttu-id="a9e0b-204">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-204">No</span></span>   |      |  <span data-ttu-id="a9e0b-205">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-205">Yes</span></span>     |       
|  <span data-ttu-id="a9e0b-206">configuredStatus</span><span class="sxs-lookup"><span data-stu-id="a9e0b-206">configuredStatus</span></span>   |  <span data-ttu-id="a9e0b-207">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-207">string</span></span>   |  <span data-ttu-id="a9e0b-208">開発者により指定された広告キャンペーンのステータスを指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-208">One of the following values that specifies the status of the ad campaign specified by the developer:</span></span> <ul><li>**<span data-ttu-id="a9e0b-209">Active</span><span class="sxs-lookup"><span data-stu-id="a9e0b-209">Active</span></span>**</li><li>**<span data-ttu-id="a9e0b-210">Inactive</span><span class="sxs-lookup"><span data-stu-id="a9e0b-210">Inactive</span></span>**</li></ul>     |  <span data-ttu-id="a9e0b-211">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-211">No</span></span>     |  <span data-ttu-id="a9e0b-212">Active</span><span class="sxs-lookup"><span data-stu-id="a9e0b-212">Active</span></span>    |   <span data-ttu-id="a9e0b-213">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-213">Yes</span></span>    |       
|  <span data-ttu-id="a9e0b-214">effectiveStatus</span><span class="sxs-lookup"><span data-stu-id="a9e0b-214">effectiveStatus</span></span>   |  <span data-ttu-id="a9e0b-215">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-215">string</span></span>   |   <span data-ttu-id="a9e0b-216">システム検証に基づいて広告キャンペーンの有効ステータスを指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-216">One of the following values that specifies the effective status of the ad campaign based on system validation:</span></span> <ul><li>**<span data-ttu-id="a9e0b-217">Active</span><span class="sxs-lookup"><span data-stu-id="a9e0b-217">Active</span></span>**</li><li>**<span data-ttu-id="a9e0b-218">Inactive</span><span class="sxs-lookup"><span data-stu-id="a9e0b-218">Inactive</span></span>**</li><li>**<span data-ttu-id="a9e0b-219">Processing</span><span class="sxs-lookup"><span data-stu-id="a9e0b-219">Processing</span></span>**</li></ul>    |    <span data-ttu-id="a9e0b-220">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-220">Yes</span></span>   |      |   <span data-ttu-id="a9e0b-221">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-221">No</span></span>      |       
|  <span data-ttu-id="a9e0b-222">effectiveStatusReasons</span><span class="sxs-lookup"><span data-stu-id="a9e0b-222">effectiveStatusReasons</span></span>   |  <span data-ttu-id="a9e0b-223">配列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-223">array</span></span>   |  <span data-ttu-id="a9e0b-224">広告キャンペーンの有効ステータスの理由を指定する次のうち 1 つ以上の値です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-224">One or more of the following values that specify the reason for the effective status of the ad campaign:</span></span> <ul><li>**<span data-ttu-id="a9e0b-225">AdCreativesInactive</span><span class="sxs-lookup"><span data-stu-id="a9e0b-225">AdCreativesInactive</span></span>**</li><li>**<span data-ttu-id="a9e0b-226">BillingFailed</span><span class="sxs-lookup"><span data-stu-id="a9e0b-226">BillingFailed</span></span>**</li><li>**<span data-ttu-id="a9e0b-227">AdLinesInactive</span><span class="sxs-lookup"><span data-stu-id="a9e0b-227">AdLinesInactive</span></span>**</li><li>**<span data-ttu-id="a9e0b-228">ValidationFailed</span><span class="sxs-lookup"><span data-stu-id="a9e0b-228">ValidationFailed</span></span>**</li><li>**<span data-ttu-id="a9e0b-229">Failed</span><span class="sxs-lookup"><span data-stu-id="a9e0b-229">Failed</span></span>**</li></ul>      |  <span data-ttu-id="a9e0b-230">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-230">Yes</span></span>     |     |    <span data-ttu-id="a9e0b-231">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-231">No</span></span>     |       
|  <span data-ttu-id="a9e0b-232">storeProductId</span><span class="sxs-lookup"><span data-stu-id="a9e0b-232">storeProductId</span></span>   |  <span data-ttu-id="a9e0b-233">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-233">string</span></span>   |  <span data-ttu-id="a9e0b-234">この広告キャンペーンが関連付けられているアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-234">The [Store ID](in-app-purchases-and-trials.md#store-ids) for the app that this ad campaign is associated with.</span></span> <span data-ttu-id="a9e0b-235">製品のストア ID の例は、9nblggh42cfd です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-235">An example Store ID for a product is 9nblggh42cfd.</span></span>     |   <span data-ttu-id="a9e0b-236">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-236">Yes</span></span>    |      |  <span data-ttu-id="a9e0b-237">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-237">Yes</span></span>     |       
|  <span data-ttu-id="a9e0b-238">labels</span><span class="sxs-lookup"><span data-stu-id="a9e0b-238">labels</span></span>   |  <span data-ttu-id="a9e0b-239">配列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-239">array</span></span>   |   <span data-ttu-id="a9e0b-240">キャンペーンのカスタム ラベルを表す 1 つ以上の文字列です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-240">One or more strings that represent custom labels for the campaign.</span></span> <span data-ttu-id="a9e0b-241">これらのラベルは、キャンペーンの検索とタグ付けに使われます。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-241">These labels be used for searching and tagging campaigns.</span></span>    |   <span data-ttu-id="a9e0b-242">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-242">No</span></span>    |  <span data-ttu-id="a9e0b-243">null</span><span class="sxs-lookup"><span data-stu-id="a9e0b-243">null</span></span>    |    <span data-ttu-id="a9e0b-244">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-244">No</span></span>     |       
|  <span data-ttu-id="a9e0b-245">type</span><span class="sxs-lookup"><span data-stu-id="a9e0b-245">type</span></span>   | <span data-ttu-id="a9e0b-246">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-246">string</span></span>    |  <span data-ttu-id="a9e0b-247">キャンペーンの種類を指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-247">One of the following values that specifies the campaign type:</span></span> <ul><li>**<span data-ttu-id="a9e0b-248">有料</span><span class="sxs-lookup"><span data-stu-id="a9e0b-248">Paid</span></span>**</li><li>**<span data-ttu-id="a9e0b-249">自社</span><span class="sxs-lookup"><span data-stu-id="a9e0b-249">House</span></span>**</li><li>**<span data-ttu-id="a9e0b-250">コミュニティ</span><span class="sxs-lookup"><span data-stu-id="a9e0b-250">Community</span></span>**</li></ul>      |   <span data-ttu-id="a9e0b-251">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-251">Yes</span></span>    |      |   <span data-ttu-id="a9e0b-252">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-252">Yes</span></span>    |       
|  <span data-ttu-id="a9e0b-253">objective</span><span class="sxs-lookup"><span data-stu-id="a9e0b-253">objective</span></span>   |  <span data-ttu-id="a9e0b-254">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-254">string</span></span>   |  <span data-ttu-id="a9e0b-255">キャンペーンの目的を指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-255">One of the following values that specifies the objective of the campaign:</span></span> <ul><li>**<span data-ttu-id="a9e0b-256">DriveInstall</span><span class="sxs-lookup"><span data-stu-id="a9e0b-256">DriveInstall</span></span>**</li><li>**<span data-ttu-id="a9e0b-257">DriveReengagement</span><span class="sxs-lookup"><span data-stu-id="a9e0b-257">DriveReengagement</span></span>**</li><li>**<span data-ttu-id="a9e0b-258">DriveInAppPurchase</span><span class="sxs-lookup"><span data-stu-id="a9e0b-258">DriveInAppPurchase</span></span>**</li></ul>     |   <span data-ttu-id="a9e0b-259">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-259">No</span></span>    |  <span data-ttu-id="a9e0b-260">DriveInstall</span><span class="sxs-lookup"><span data-stu-id="a9e0b-260">DriveInstall</span></span>    |   <span data-ttu-id="a9e0b-261">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-261">Yes</span></span>    |       
|  <span data-ttu-id="a9e0b-262">lines</span><span class="sxs-lookup"><span data-stu-id="a9e0b-262">lines</span></span>   |  <span data-ttu-id="a9e0b-263">配列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-263">array</span></span>   |   <span data-ttu-id="a9e0b-264">広告キャンペーンに関連づけられた[配信ライン](manage-delivery-lines-for-ad-campaigns.md#line)を識別する 1 つ以上のオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-264">One or more objects that identify the [delivery lines](manage-delivery-lines-for-ad-campaigns.md#line) that are associated with the ad campaign.</span></span> <span data-ttu-id="a9e0b-265">このフィールドの各オブジェクトは、配信ラインの ID と名前を指定する *id* フィールドと *name* フィールドで構成されます。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-265">Each object in this field consists of an *id* and *name* field that specifies the ID and name of the delivery line.</span></span>     |   <span data-ttu-id="a9e0b-266">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-266">No</span></span>    |      |    <span data-ttu-id="a9e0b-267">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-267">No</span></span>     |       
|  <span data-ttu-id="a9e0b-268">createdDate</span><span class="sxs-lookup"><span data-stu-id="a9e0b-268">createdDate</span></span>   |  <span data-ttu-id="a9e0b-269">文字列</span><span class="sxs-lookup"><span data-stu-id="a9e0b-269">string</span></span>   |  <span data-ttu-id="a9e0b-270">広告キャンペーンが作成された日時 (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="a9e0b-270">The date and time the ad campaign was created, in ISO 8601 format.</span></span>     |  <span data-ttu-id="a9e0b-271">○</span><span class="sxs-lookup"><span data-stu-id="a9e0b-271">Yes</span></span>     |      |     <span data-ttu-id="a9e0b-272">×</span><span class="sxs-lookup"><span data-stu-id="a9e0b-272">No</span></span>    |       |


## <a name="related-topics"></a><span data-ttu-id="a9e0b-273">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a9e0b-273">Related topics</span></span>

* [<span data-ttu-id="a9e0b-274">Microsoft Store サービスを使用した広告キャンペーンの実行</span><span class="sxs-lookup"><span data-stu-id="a9e0b-274">Run ad campaigns using Microsoft Store Services</span></span>](run-ad-campaigns-using-windows-store-services.md)
* [<span data-ttu-id="a9e0b-275">広告キャンペーンの配信ラインの管理</span><span class="sxs-lookup"><span data-stu-id="a9e0b-275">Manage delivery lines for ad campaigns</span></span>](manage-delivery-lines-for-ad-campaigns.md)
* [<span data-ttu-id="a9e0b-276">広告キャンペーンの対象プロファイルの管理</span><span class="sxs-lookup"><span data-stu-id="a9e0b-276">Manage targeting profiles for ad campaigns</span></span>](manage-targeting-profiles-for-ad-campaigns.md)
* [<span data-ttu-id="a9e0b-277">広告キャンペーンのクリエイティブの管理</span><span class="sxs-lookup"><span data-stu-id="a9e0b-277">Manage creatives for ad campaigns</span></span>](manage-creatives-for-ad-campaigns.md)
* [<span data-ttu-id="a9e0b-278">広告キャンペーンのパフォーマンス データの取得</span><span class="sxs-lookup"><span data-stu-id="a9e0b-278">Get ad campaign performance data</span></span>](get-ad-campaign-performance-data.md)
