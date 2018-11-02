---
author: Xansky
ms.assetid: dc632a4c-ce48-400b-8e6e-1dddbd13afff
description: プロモーション用の広告キャンペーンの配信ラインを管理するには、Microsoft Store プロモーション API の以下のメソッドを使います。
title: 配信ラインの管理
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store プロモーション API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 346383504abd7927cf863afa59bcb574ddd2495d
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5939317"
---
# <a name="manage-delivery-lines"></a><span data-ttu-id="f129e-104">配信ラインの管理</span><span class="sxs-lookup"><span data-stu-id="f129e-104">Manage delivery lines</span></span>

<span data-ttu-id="f129e-105">1 つ以上の*配信ライン*を作成してインベントリを購入し、プロモーション用の広告キャンペーンの広告を配信するには、Microsoft Store プロモーション API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="f129e-105">Use these methods in the Microsoft Store promotions API to create one or more *delivery lines* to buy inventory and deliver your ads for a promotional ad campaign.</span></span> <span data-ttu-id="f129e-106">配信ラインごとに、ターゲットと入札額を設定できます。また、予算と使用したいクリエイティブへのリンクを設定することで、支払い額を決定できます。</span><span class="sxs-lookup"><span data-stu-id="f129e-106">For each delivery line, you can set targeting, set your bid price, and decide how much you want to spend by setting a budget and linking to creatives you want to use.</span></span>

<span data-ttu-id="f129e-107">配信ラインと広告キャンペーン、ターゲット プロファイル、クリエイティブとの関係について詳しくは、「[Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f129e-107">For more information about the relationship between delivery lines and ad campaigns, targeting profiles, and creatives, see [Run ad campaigns using Microsoft Store services](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api).</span></span>

><span data-ttu-id="f129e-108">**注**&nbsp;&nbsp;この API を使用して広告キャンペーンの配信ラインを正しく作成するには、事前に[デベロッパー センター ダッシュボードの **[アプリの宣伝]** ページを使って有料の広告キャンペーンを 1 つ作成する](../publish/create-an-ad-campaign-for-your-app.md)必要があります。また、このページで支払い方法を少なくとも 1 つ追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f129e-108">**Note**&nbsp;&nbsp;Before you can successfully create delivery lines for ad campaigns using this API, you must first [create one paid ad campaign using the **Promote your app** page in the Dev Center dashboard](../publish/create-an-ad-campaign-for-your-app.md), and you must add at least one payment instrument on this page.</span></span> <span data-ttu-id="f129e-109">これを行うと、この API を使用して、広告キャンペーンの請求可能な配信ラインを正しく作成することができます。</span><span class="sxs-lookup"><span data-stu-id="f129e-109">After you do this, you will be able to successfully create billable delivery lines for ad campaigns using this API.</span></span> <span data-ttu-id="f129e-110">API を使用して作成した広告キャンペーンでは、ダッシュ ボードの **[アプリの宣伝]** ページで選んだ既定の支払い方法に対して自動的に請求が行われます。</span><span class="sxs-lookup"><span data-stu-id="f129e-110">Ad campaigns you create using the API will automatically bill the default payment instrument chosen on the **Promote your app** page in the dashboard.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="f129e-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="f129e-111">Prerequisites</span></span>

<span data-ttu-id="f129e-112">これらのメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f129e-112">To use these methods, you need to first do the following:</span></span>

* <span data-ttu-id="f129e-113">Microsoft Store プロモーション API に関するすべての[前提条件](run-ad-campaigns-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="f129e-113">If you have not done so already, complete all the [prerequisites](run-ad-campaigns-using-windows-store-services.md#prerequisites) for the Microsoft Store promotions API.</span></span>

  > [!NOTE]
  > <span data-ttu-id="f129e-114">前提条件の一部として、[デベロッパー センター ダッシュボードで有料の広告キャンペーンを少なくとも 1 つ作成する](../publish/create-an-ad-campaign-for-your-app.md)必要があります。また、ダッシュボードで、広告キャンペーンの支払い方法を少なくとも 1 つ追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f129e-114">As part of the prerequisites, be sure that you [create at least one paid ad campaign in the Dev Center dashboard](../publish/create-an-ad-campaign-for-your-app.md) and that you add at least one payment instrument for the ad campaign in the dashboard.</span></span> <span data-ttu-id="f129e-115">この API を使用して作成した配信ラインでは、ダッシュ ボードの **[アプリの宣伝]** ページで選んだ既定の支払い方法に対して自動的に請求が行われます。</span><span class="sxs-lookup"><span data-stu-id="f129e-115">Delivery lines you create using this API will automatically bill the default payment instrument chosen on the **Promote your app** page in the dashboard.</span></span>

* <span data-ttu-id="f129e-116">これらのメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="f129e-116">[Obtain an Azure AD access token](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for these methods.</span></span> <span data-ttu-id="f129e-117">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="f129e-117">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="f129e-118">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f129e-118">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="f129e-119">要求</span><span class="sxs-lookup"><span data-stu-id="f129e-119">Request</span></span>

<span data-ttu-id="f129e-120">これらのメソッドでは、次の URL が使用されます。</span><span class="sxs-lookup"><span data-stu-id="f129e-120">These methods have the following URIs.</span></span>

| <span data-ttu-id="f129e-121">メソッドの種類</span><span class="sxs-lookup"><span data-stu-id="f129e-121">Method type</span></span> | <span data-ttu-id="f129e-122">要求 URI</span><span class="sxs-lookup"><span data-stu-id="f129e-122">Request URI</span></span>         |  <span data-ttu-id="f129e-123">説明</span><span class="sxs-lookup"><span data-stu-id="f129e-123">Description</span></span>  |
|--------|---------------------------|---------------|
| <span data-ttu-id="f129e-124">POST</span><span class="sxs-lookup"><span data-stu-id="f129e-124">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/line``` |  <span data-ttu-id="f129e-125">新しい配信ラインを作成します。</span><span class="sxs-lookup"><span data-stu-id="f129e-125">Creates a new delivery line.</span></span>  |
| <span data-ttu-id="f129e-126">PUT</span><span class="sxs-lookup"><span data-stu-id="f129e-126">PUT</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/line/{lineId}``` |  <span data-ttu-id="f129e-127">*lineId* により指定された配信ラインを編集します。</span><span class="sxs-lookup"><span data-stu-id="f129e-127">Edits the delivery line specified by *lineId*.</span></span>  |
| <span data-ttu-id="f129e-128">GET</span><span class="sxs-lookup"><span data-stu-id="f129e-128">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/line/{lineId}``` |  <span data-ttu-id="f129e-129">*lineId* により指定された配信ラインを取得します。</span><span class="sxs-lookup"><span data-stu-id="f129e-129">Gets the delivery line specified by *lineId*.</span></span>  |


### <a name="header"></a><span data-ttu-id="f129e-130">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f129e-130">Header</span></span>

| <span data-ttu-id="f129e-131">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f129e-131">Header</span></span>        | <span data-ttu-id="f129e-132">型</span><span class="sxs-lookup"><span data-stu-id="f129e-132">Type</span></span>   | <span data-ttu-id="f129e-133">説明</span><span class="sxs-lookup"><span data-stu-id="f129e-133">Description</span></span>         |
|---------------|--------|---------------------|
| <span data-ttu-id="f129e-134">Authorization</span><span class="sxs-lookup"><span data-stu-id="f129e-134">Authorization</span></span> | <span data-ttu-id="f129e-135">string</span><span class="sxs-lookup"><span data-stu-id="f129e-135">string</span></span> | <span data-ttu-id="f129e-136">必須。</span><span class="sxs-lookup"><span data-stu-id="f129e-136">Required.</span></span> <span data-ttu-id="f129e-137">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="f129e-137">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |
| <span data-ttu-id="f129e-138">追跡 ID</span><span class="sxs-lookup"><span data-stu-id="f129e-138">Tracking ID</span></span>   | <span data-ttu-id="f129e-139">GUID</span><span class="sxs-lookup"><span data-stu-id="f129e-139">GUID</span></span>   | <span data-ttu-id="f129e-140">省略可能。</span><span class="sxs-lookup"><span data-stu-id="f129e-140">Optional.</span></span> <span data-ttu-id="f129e-141">呼び出しフローを追跡する ID。</span><span class="sxs-lookup"><span data-stu-id="f129e-141">An ID that tracks the call flow.</span></span>                                  |


### <a name="request-body"></a><span data-ttu-id="f129e-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="f129e-142">Request body</span></span>

<span data-ttu-id="f129e-143">POST メソッドと PUT メソッドには、[配信ライン](#line) オブジェクトの必須フィールドと設定または変更する追加フィールドを持つ JSON 要求本文が必要です。</span><span class="sxs-lookup"><span data-stu-id="f129e-143">The POST and PUT methods require a JSON request body with the required fields of a [Delivery line](#line) object and any additional fields you want to set or change.</span></span>


### <a name="request-examples"></a><span data-ttu-id="f129e-144">要求の例</span><span class="sxs-lookup"><span data-stu-id="f129e-144">Request examples</span></span>

<span data-ttu-id="f129e-145">次の例は、POST メソッドを呼び出して配信ラインを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f129e-145">The following example demonstrates how to call the POST method to create a delivery line.</span></span>

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/promotion/line HTTP/1.1
Authorization: Bearer <your access token>

{
    "name": "Contoso App Campaign - Paid Line",
    "configuredStatus": "Active",
    "startDateTime": "2017-01-19T12:09:34Z",
    "endDateTime": "2017-01-31T23:59:59Z",
    "bidAmount": 0.4,
    "dailyBudget": 20,
    "targetProfileId": {
        "id": 310021746
    },
    "creatives": [
        {
            "id": 106851
        }
    ],
    "campaignId": 31043481,
    "minMinutesPerImp ": 1
}
```

<span data-ttu-id="f129e-146">次の例は、GET メソッドを呼び出して配信ラインを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f129e-146">The following example demonstrates how to call the GET method to retrieve a delivery line.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/line/31019990  HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="f129e-147">応答</span><span class="sxs-lookup"><span data-stu-id="f129e-147">Response</span></span>

<span data-ttu-id="f129e-148">これらのメソッドは、作成、更新、または取得された配信ラインに関する情報を含む[配信ライン](#line) オブジェクトを持つ JSON 応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="f129e-148">These methods return a JSON response body with a [Delivery line](#line) object that contains information about the delivery line that was created, updated, or retrieved.</span></span> <span data-ttu-id="f129e-149">これらのメソッドの応答本文を次の例に示します。</span><span class="sxs-lookup"><span data-stu-id="f129e-149">The following example demonstrates a response body for these methods.</span></span>

```json
{
    "Data": {
        "id": 31043476,
        "name": "Contoso App Campaign - Paid Line",
        "configuredStatus": "Active",
        "effectiveStatus": "Active",
        "effectiveStatusReasons": [
            "{\"ValidationStatusReasons\":null}"
        ],
        "startDateTime": "2017-01-19T12:09:34Z",
        "endDateTime": "2017-01-31T23:59:59Z",
        "createdDateTime": "2017-01-17T10:28:34Z",
        "bidType": "CPM",
        "bidAmount": 0.4,
        "dailyBudget": 20,
        "targetProfileId": {
            "id": 310021746
        },
        "creatives": [
            {
                "id": 106126
            }
        ],
        "campaignId": 31043481,
        "minMinutesPerImp ": 1,
        "pacingType ": "SpendEvenly",
        "currencyId ": 732
    }
}

```


<span id="line"/>

## <a name="delivery-line-object"></a><span data-ttu-id="f129e-150">配信ライン オブジェクト</span><span class="sxs-lookup"><span data-stu-id="f129e-150">Delivery line object</span></span>

<span data-ttu-id="f129e-151">これらのメソッドの要求本文と応答本文には、次のフィールドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f129e-151">The request and response bodies for these methods contain the following fields.</span></span> <span data-ttu-id="f129e-152">この表は、読み取り専用のフィールド (つまり、PUT メソッドで変更できない) と POST メソッドまたは PUT メソッドの要求本文で必須のフィールドを示しています。</span><span class="sxs-lookup"><span data-stu-id="f129e-152">This table shows which fields are read-only (meaning that they cannot be changed in the PUT method) and which fields are required in the request body for the POST or PUT methods.</span></span>

| <span data-ttu-id="f129e-153">フィールド</span><span class="sxs-lookup"><span data-stu-id="f129e-153">Field</span></span>        | <span data-ttu-id="f129e-154">型</span><span class="sxs-lookup"><span data-stu-id="f129e-154">Type</span></span>   |  <span data-ttu-id="f129e-155">説明</span><span class="sxs-lookup"><span data-stu-id="f129e-155">Description</span></span>      |  <span data-ttu-id="f129e-156">読み取り専用かどうか</span><span class="sxs-lookup"><span data-stu-id="f129e-156">Read only</span></span>  | <span data-ttu-id="f129e-157">既定値</span><span class="sxs-lookup"><span data-stu-id="f129e-157">Default</span></span>  | <span data-ttu-id="f129e-158">POST/PUT に必須かどうか</span><span class="sxs-lookup"><span data-stu-id="f129e-158">Required for POST/PUT</span></span> |   
|--------------|--------|---------------|------|-------------|------------|
|  <span data-ttu-id="f129e-159">id</span><span class="sxs-lookup"><span data-stu-id="f129e-159">id</span></span>   |  <span data-ttu-id="f129e-160">整数</span><span class="sxs-lookup"><span data-stu-id="f129e-160">integer</span></span>   |  <span data-ttu-id="f129e-161">配信ラインの ID です。</span><span class="sxs-lookup"><span data-stu-id="f129e-161">The ID of the delivery line.</span></span>     |   <span data-ttu-id="f129e-162">○</span><span class="sxs-lookup"><span data-stu-id="f129e-162">Yes</span></span>    |      |  <span data-ttu-id="f129e-163">×</span><span class="sxs-lookup"><span data-stu-id="f129e-163">No</span></span>      |    
|  <span data-ttu-id="f129e-164">name</span><span class="sxs-lookup"><span data-stu-id="f129e-164">name</span></span>   |  <span data-ttu-id="f129e-165">文字列</span><span class="sxs-lookup"><span data-stu-id="f129e-165">string</span></span>   |   <span data-ttu-id="f129e-166">配信ラインの名前です。</span><span class="sxs-lookup"><span data-stu-id="f129e-166">The name of the delivery line.</span></span>    |    <span data-ttu-id="f129e-167">×</span><span class="sxs-lookup"><span data-stu-id="f129e-167">No</span></span>   |      |  <span data-ttu-id="f129e-168">POST</span><span class="sxs-lookup"><span data-stu-id="f129e-168">POST</span></span>     |     
|  <span data-ttu-id="f129e-169">configuredStatus</span><span class="sxs-lookup"><span data-stu-id="f129e-169">configuredStatus</span></span>   |  <span data-ttu-id="f129e-170">文字列</span><span class="sxs-lookup"><span data-stu-id="f129e-170">string</span></span>   |  <span data-ttu-id="f129e-171">開発者により指定された配信ラインのステータスを指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="f129e-171">One of the following values that specifies the status of the delivery line specified by the developer:</span></span> <ul><li>**<span data-ttu-id="f129e-172">Active</span><span class="sxs-lookup"><span data-stu-id="f129e-172">Active</span></span>**</li><li>**<span data-ttu-id="f129e-173">Inactive</span><span class="sxs-lookup"><span data-stu-id="f129e-173">Inactive</span></span>**</li></ul>     |  <span data-ttu-id="f129e-174">×</span><span class="sxs-lookup"><span data-stu-id="f129e-174">No</span></span>     |      |   <span data-ttu-id="f129e-175">POST</span><span class="sxs-lookup"><span data-stu-id="f129e-175">POST</span></span>    |       
|  <span data-ttu-id="f129e-176">effectiveStatus</span><span class="sxs-lookup"><span data-stu-id="f129e-176">effectiveStatus</span></span>   |  <span data-ttu-id="f129e-177">文字列</span><span class="sxs-lookup"><span data-stu-id="f129e-177">string</span></span>   |   <span data-ttu-id="f129e-178">システム検証に基づいて配信ラインの有効ステータスを指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="f129e-178">One of the following values that specifies the effective status of the delivery line based on system validation:</span></span> <ul><li>**<span data-ttu-id="f129e-179">Active</span><span class="sxs-lookup"><span data-stu-id="f129e-179">Active</span></span>**</li><li>**<span data-ttu-id="f129e-180">Inactive</span><span class="sxs-lookup"><span data-stu-id="f129e-180">Inactive</span></span>**</li><li>**<span data-ttu-id="f129e-181">Processing</span><span class="sxs-lookup"><span data-stu-id="f129e-181">Processing</span></span>**</li><li>**<span data-ttu-id="f129e-182">Failed</span><span class="sxs-lookup"><span data-stu-id="f129e-182">Failed</span></span>**</li></ul>    |    <span data-ttu-id="f129e-183">○</span><span class="sxs-lookup"><span data-stu-id="f129e-183">Yes</span></span>   |      |  <span data-ttu-id="f129e-184">×</span><span class="sxs-lookup"><span data-stu-id="f129e-184">No</span></span>      |      
|  <span data-ttu-id="f129e-185">effectiveStatusReasons</span><span class="sxs-lookup"><span data-stu-id="f129e-185">effectiveStatusReasons</span></span>   |  <span data-ttu-id="f129e-186">配列</span><span class="sxs-lookup"><span data-stu-id="f129e-186">array</span></span>   |  <span data-ttu-id="f129e-187">配信ラインの有効ステータスの理由を指定する次のうち 1 つ以上の値です。</span><span class="sxs-lookup"><span data-stu-id="f129e-187">One or more of the following values that specify the reason for the effective status of the delivery line:</span></span> <ul><li>**<span data-ttu-id="f129e-188">AdCreativesInactive</span><span class="sxs-lookup"><span data-stu-id="f129e-188">AdCreativesInactive</span></span>**</li><li>**<span data-ttu-id="f129e-189">ValidationFailed</span><span class="sxs-lookup"><span data-stu-id="f129e-189">ValidationFailed</span></span>**</li></ul>      |  <span data-ttu-id="f129e-190">○</span><span class="sxs-lookup"><span data-stu-id="f129e-190">Yes</span></span>     |     |    <span data-ttu-id="f129e-191">×</span><span class="sxs-lookup"><span data-stu-id="f129e-191">No</span></span>    |           
|  <span data-ttu-id="f129e-192">startDatetime</span><span class="sxs-lookup"><span data-stu-id="f129e-192">startDatetime</span></span>   |  <span data-ttu-id="f129e-193">文字列</span><span class="sxs-lookup"><span data-stu-id="f129e-193">string</span></span>   |  <span data-ttu-id="f129e-194">配信ラインの開始日時です (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="f129e-194">The start date and time for the delivery line, in ISO 8601 format.</span></span> <span data-ttu-id="f129e-195">日時が過去の場合、この値を変更できません。</span><span class="sxs-lookup"><span data-stu-id="f129e-195">This value cannot be changed if it is already in the past.</span></span>     |    <span data-ttu-id="f129e-196">×</span><span class="sxs-lookup"><span data-stu-id="f129e-196">No</span></span>   |      |    <span data-ttu-id="f129e-197">POST、PUT</span><span class="sxs-lookup"><span data-stu-id="f129e-197">POST, PUT</span></span>     |
|  <span data-ttu-id="f129e-198">endDatetime</span><span class="sxs-lookup"><span data-stu-id="f129e-198">endDatetime</span></span>   |  <span data-ttu-id="f129e-199">文字列</span><span class="sxs-lookup"><span data-stu-id="f129e-199">string</span></span>   |  <span data-ttu-id="f129e-200">配信ラインの終了日時です (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="f129e-200">The end date and time for the delivery line, in ISO 8601 format.</span></span> <span data-ttu-id="f129e-201">日時が過去の場合、この値を変更できません。</span><span class="sxs-lookup"><span data-stu-id="f129e-201">This value cannot be changed if it is already in the past.</span></span>     |   <span data-ttu-id="f129e-202">×</span><span class="sxs-lookup"><span data-stu-id="f129e-202">No</span></span>    |      |  <span data-ttu-id="f129e-203">POST、PUT</span><span class="sxs-lookup"><span data-stu-id="f129e-203">POST, PUT</span></span>     |
|  <span data-ttu-id="f129e-204">createdDatetime</span><span class="sxs-lookup"><span data-stu-id="f129e-204">createdDatetime</span></span>   |  <span data-ttu-id="f129e-205">文字列</span><span class="sxs-lookup"><span data-stu-id="f129e-205">string</span></span>   |  <span data-ttu-id="f129e-206">配信ラインが作成された日時 (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="f129e-206">The date and time the delivery line was created, in ISO 8601 format.</span></span>      |    <span data-ttu-id="f129e-207">○</span><span class="sxs-lookup"><span data-stu-id="f129e-207">Yes</span></span>   |      |  <span data-ttu-id="f129e-208">×</span><span class="sxs-lookup"><span data-stu-id="f129e-208">No</span></span>      |
|  <span data-ttu-id="f129e-209">bidType</span><span class="sxs-lookup"><span data-stu-id="f129e-209">bidType</span></span>   |  <span data-ttu-id="f129e-210">文字列</span><span class="sxs-lookup"><span data-stu-id="f129e-210">string</span></span>   |  <span data-ttu-id="f129e-211">配信ラインの入札の種類を指定する値です。</span><span class="sxs-lookup"><span data-stu-id="f129e-211">A value that specifies the bidding type of the delivery line.</span></span> <span data-ttu-id="f129e-212">現時点では、サポートされている唯一の値は **CPM** です。</span><span class="sxs-lookup"><span data-stu-id="f129e-212">Currently, the only supported value is **CPM**.</span></span>      |    <span data-ttu-id="f129e-213">×</span><span class="sxs-lookup"><span data-stu-id="f129e-213">No</span></span>   |  <span data-ttu-id="f129e-214">CPM</span><span class="sxs-lookup"><span data-stu-id="f129e-214">CPM</span></span>    |  <span data-ttu-id="f129e-215">×</span><span class="sxs-lookup"><span data-stu-id="f129e-215">No</span></span>     |
|  <span data-ttu-id="f129e-216">bidAmount</span><span class="sxs-lookup"><span data-stu-id="f129e-216">bidAmount</span></span>   |  <span data-ttu-id="f129e-217">10 進数</span><span class="sxs-lookup"><span data-stu-id="f129e-217">decimal</span></span>   |  <span data-ttu-id="f129e-218">広告要求の入札に使う入札額です。</span><span class="sxs-lookup"><span data-stu-id="f129e-218">The bid amount to be used for bidding any ad request.</span></span>      |    <span data-ttu-id="f129e-219">×</span><span class="sxs-lookup"><span data-stu-id="f129e-219">No</span></span>   |  <span data-ttu-id="f129e-220">対象市場に基づく平均 CPM 値です (この値は定期的に変更されます)。</span><span class="sxs-lookup"><span data-stu-id="f129e-220">The average CPM value based on target markets (this value is revised periodically).</span></span>    |    <span data-ttu-id="f129e-221">×</span><span class="sxs-lookup"><span data-stu-id="f129e-221">No</span></span>    |  
|  <span data-ttu-id="f129e-222">dailyBudget</span><span class="sxs-lookup"><span data-stu-id="f129e-222">dailyBudget</span></span>   |  <span data-ttu-id="f129e-223">10 進数</span><span class="sxs-lookup"><span data-stu-id="f129e-223">decimal</span></span>   |  <span data-ttu-id="f129e-224">配信ラインの 1 日あたりの予算です。</span><span class="sxs-lookup"><span data-stu-id="f129e-224">The daily budget for the delivery line.</span></span> <span data-ttu-id="f129e-225">*dailyBudget* または *lifetimeBudget* を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f129e-225">Either *dailyBudget* or *lifetimeBudget* must be set.</span></span>      |    <span data-ttu-id="f129e-226">×</span><span class="sxs-lookup"><span data-stu-id="f129e-226">No</span></span>   |      |   <span data-ttu-id="f129e-227">POST、PUT (*lifetimeBudget* が設定されていない場合)</span><span class="sxs-lookup"><span data-stu-id="f129e-227">POST, PUT (if *lifetimeBudget* is not set)</span></span>       |
|  <span data-ttu-id="f129e-228">lifetimeBudget</span><span class="sxs-lookup"><span data-stu-id="f129e-228">lifetimeBudget</span></span>   |  <span data-ttu-id="f129e-229">10 進数</span><span class="sxs-lookup"><span data-stu-id="f129e-229">decimal</span></span>   |   <span data-ttu-id="f129e-230">配信ラインの全体予算です。</span><span class="sxs-lookup"><span data-stu-id="f129e-230">The lifetime budget for the delivery line.</span></span> <span data-ttu-id="f129e-231">lifetimeBudget\* または *dailyBudget* を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f129e-231">Either lifetimeBudget\* or *dailyBudget* must be set.</span></span>      |    <span data-ttu-id="f129e-232">×</span><span class="sxs-lookup"><span data-stu-id="f129e-232">No</span></span>   |      |   <span data-ttu-id="f129e-233">POST、PUT (*dailyBudget* が設定されていない場合)</span><span class="sxs-lookup"><span data-stu-id="f129e-233">POST, PUT  (if *dailyBudget* is not set)</span></span>    |
|  <span data-ttu-id="f129e-234">targetingProfileId</span><span class="sxs-lookup"><span data-stu-id="f129e-234">targetingProfileId</span></span>   |  <span data-ttu-id="f129e-235">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="f129e-235">object</span></span>   |  <span data-ttu-id="f129e-236">この配信ラインを対象にするユーザー、地域、およびインベントリの種類を指定する[対象プロファイル](manage-targeting-profiles-for-ad-campaigns.md#targeting-profile)を識別するオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="f129e-236">On object that identifies the [targeting profile](manage-targeting-profiles-for-ad-campaigns.md#targeting-profile) that describes the users, geographies and inventory types that you want to target for this delivery line.</span></span> <span data-ttu-id="f129e-237">このオブジェクトは、対象プロファイルの ID を指定する単一の *id* フィールドで構成されます。</span><span class="sxs-lookup"><span data-stu-id="f129e-237">This object consists of a single *id* field that specifies the ID of the targeting profile.</span></span>     |    <span data-ttu-id="f129e-238">×</span><span class="sxs-lookup"><span data-stu-id="f129e-238">No</span></span>   |      |  <span data-ttu-id="f129e-239">×</span><span class="sxs-lookup"><span data-stu-id="f129e-239">No</span></span>      |  
|  <span data-ttu-id="f129e-240">creatives</span><span class="sxs-lookup"><span data-stu-id="f129e-240">creatives</span></span>   |  <span data-ttu-id="f129e-241">配列</span><span class="sxs-lookup"><span data-stu-id="f129e-241">array</span></span>   |  <span data-ttu-id="f129e-242">配信ラインに関連づけられた[クリエイティブ](manage-creatives-for-ad-campaigns.md#creative)を表す 1 つ以上のオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="f129e-242">One or more objects that represent the [creatives](manage-creatives-for-ad-campaigns.md#creative) that are associated with the delivery line.</span></span> <span data-ttu-id="f129e-243">このフィールド内の各オブジェクトは、クリエイティブの ID を指定する単一の *id* フィールドで構成されます。</span><span class="sxs-lookup"><span data-stu-id="f129e-243">Each object in this field consists of a single *id* field that specifies the ID of a creative.</span></span>      |    <span data-ttu-id="f129e-244">×</span><span class="sxs-lookup"><span data-stu-id="f129e-244">No</span></span>   |      |   <span data-ttu-id="f129e-245">×</span><span class="sxs-lookup"><span data-stu-id="f129e-245">No</span></span>     |  
|  <span data-ttu-id="f129e-246">campaignId</span><span class="sxs-lookup"><span data-stu-id="f129e-246">campaignId</span></span>   |  <span data-ttu-id="f129e-247">整数</span><span class="sxs-lookup"><span data-stu-id="f129e-247">integer</span></span>   |  <span data-ttu-id="f129e-248">親広告キャンペーンの ID です。</span><span class="sxs-lookup"><span data-stu-id="f129e-248">The ID of the parent ad campaign.</span></span>      |    <span data-ttu-id="f129e-249">×</span><span class="sxs-lookup"><span data-stu-id="f129e-249">No</span></span>   |      |   <span data-ttu-id="f129e-250">×</span><span class="sxs-lookup"><span data-stu-id="f129e-250">No</span></span>     |  
|  <span data-ttu-id="f129e-251">minMinutesPerImp</span><span class="sxs-lookup"><span data-stu-id="f129e-251">minMinutesPerImp</span></span>   |  <span data-ttu-id="f129e-252">整数</span><span class="sxs-lookup"><span data-stu-id="f129e-252">integer</span></span>   |  <span data-ttu-id="f129e-253">この配信ラインから同じユーザーに表示される 2 つのインプレッション間の間隔 (分単位) を指定します。</span><span class="sxs-lookup"><span data-stu-id="f129e-253">Specifies the minimum time interval (in minutes) between two impressions shown to the same user from this delivery line.</span></span>      |    <span data-ttu-id="f129e-254">×</span><span class="sxs-lookup"><span data-stu-id="f129e-254">No</span></span>   |  <span data-ttu-id="f129e-255">4000</span><span class="sxs-lookup"><span data-stu-id="f129e-255">4000</span></span>    |  <span data-ttu-id="f129e-256">×</span><span class="sxs-lookup"><span data-stu-id="f129e-256">No</span></span>      |  
|  <span data-ttu-id="f129e-257">pacingType</span><span class="sxs-lookup"><span data-stu-id="f129e-257">pacingType</span></span>   |  <span data-ttu-id="f129e-258">文字列</span><span class="sxs-lookup"><span data-stu-id="f129e-258">string</span></span>   |  <span data-ttu-id="f129e-259">ペーシングの種類を指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="f129e-259">One of the following values that specify the pacing type:</span></span> <ul><li>**<span data-ttu-id="f129e-260">SpendEvenly</span><span class="sxs-lookup"><span data-stu-id="f129e-260">SpendEvenly</span></span>**</li><li>**<span data-ttu-id="f129e-261">SpendAsFastAsPossible</span><span class="sxs-lookup"><span data-stu-id="f129e-261">SpendAsFastAsPossible</span></span>**</li></ul>      |    <span data-ttu-id="f129e-262">×</span><span class="sxs-lookup"><span data-stu-id="f129e-262">No</span></span>   |  <span data-ttu-id="f129e-263">SpendEvenly</span><span class="sxs-lookup"><span data-stu-id="f129e-263">SpendEvenly</span></span>    |  <span data-ttu-id="f129e-264">×</span><span class="sxs-lookup"><span data-stu-id="f129e-264">No</span></span>      |
|  <span data-ttu-id="f129e-265">currencyId</span><span class="sxs-lookup"><span data-stu-id="f129e-265">currencyId</span></span>   |  <span data-ttu-id="f129e-266">整数</span><span class="sxs-lookup"><span data-stu-id="f129e-266">integer</span></span>   |  <span data-ttu-id="f129e-267">キャンペーンの通貨の ID です。</span><span class="sxs-lookup"><span data-stu-id="f129e-267">The ID of the currency of the campaign.</span></span>      |    <span data-ttu-id="f129e-268">○</span><span class="sxs-lookup"><span data-stu-id="f129e-268">Yes</span></span>   |  <span data-ttu-id="f129e-269">開発者アカウントの通貨 (POST または PUT 呼び出しではこのフィールドを指定する必要はありません)</span><span class="sxs-lookup"><span data-stu-id="f129e-269">The currency of the developer account (you do not need to specify this field in POST or PUT calls)</span></span>    |   <span data-ttu-id="f129e-270">×</span><span class="sxs-lookup"><span data-stu-id="f129e-270">No</span></span>     |      |


## <a name="related-topics"></a><span data-ttu-id="f129e-271">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f129e-271">Related topics</span></span>

* [<span data-ttu-id="f129e-272">Microsoft Store サービスを使用した広告キャンペーンの実行</span><span class="sxs-lookup"><span data-stu-id="f129e-272">Run ad campaigns using Microsoft Store Services</span></span>](run-ad-campaigns-using-windows-store-services.md)
* [<span data-ttu-id="f129e-273">広告キャンペーンの管理</span><span class="sxs-lookup"><span data-stu-id="f129e-273">Manage ad campaigns</span></span>](manage-ad-campaigns.md)
* [<span data-ttu-id="f129e-274">広告キャンペーンの対象プロファイルの管理</span><span class="sxs-lookup"><span data-stu-id="f129e-274">Manage targeting profiles for ad campaigns</span></span>](manage-targeting-profiles-for-ad-campaigns.md)
* [<span data-ttu-id="f129e-275">広告キャンペーンのクリエイティブの管理</span><span class="sxs-lookup"><span data-stu-id="f129e-275">Manage creatives for ad campaigns</span></span>](manage-creatives-for-ad-campaigns.md)
* [<span data-ttu-id="f129e-276">広告キャンペーンのパフォーマンス データの取得</span><span class="sxs-lookup"><span data-stu-id="f129e-276">Get ad campaign performance data</span></span>](get-ad-campaign-performance-data.md)
