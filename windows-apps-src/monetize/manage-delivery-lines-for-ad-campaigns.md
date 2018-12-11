---
ms.assetid: dc632a4c-ce48-400b-8e6e-1dddbd13afff
description: プロモーション用の広告キャンペーンの配信ラインを管理するには、Microsoft Store プロモーション API の以下のメソッドを使います。
title: 配信ラインの管理
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store プロモーション API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 363f7034d7e353d9ee110637971e7b848dbca1bb
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8898554"
---
# <a name="manage-delivery-lines"></a><span data-ttu-id="d42ec-104">配信ラインの管理</span><span class="sxs-lookup"><span data-stu-id="d42ec-104">Manage delivery lines</span></span>

<span data-ttu-id="d42ec-105">1 つ以上の*配信ライン*を作成してインベントリを購入し、プロモーション用の広告キャンペーンの広告を配信するには、Microsoft Store プロモーション API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="d42ec-105">Use these methods in the Microsoft Store promotions API to create one or more *delivery lines* to buy inventory and deliver your ads for a promotional ad campaign.</span></span> <span data-ttu-id="d42ec-106">配信ラインごとに、ターゲットと入札額を設定できます。また、予算と使用したいクリエイティブへのリンクを設定することで、支払い額を決定できます。</span><span class="sxs-lookup"><span data-stu-id="d42ec-106">For each delivery line, you can set targeting, set your bid price, and decide how much you want to spend by setting a budget and linking to creatives you want to use.</span></span>

<span data-ttu-id="d42ec-107">配信ラインと広告キャンペーン、ターゲット プロファイル、クリエイティブとの関係について詳しくは、「[Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d42ec-107">For more information about the relationship between delivery lines and ad campaigns, targeting profiles, and creatives, see [Run ad campaigns using Microsoft Store services](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api).</span></span>

><span data-ttu-id="d42ec-108">**注:**&nbsp;&nbsp;を前に、この API を使用して広告キャンペーンの配信ラインを正しく作成するは、最初は[パートナー センターでの**広告キャンペーン**のページを使用して 1 つの有料の広告キャンペーンを作成](../publish/create-an-ad-campaign-for-your-app.md)する必要があります 1 つ以上の支払いを追加する必要があります。このページで機器です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-108">**Note**&nbsp;&nbsp;Before you can successfully create delivery lines for ad campaigns using this API, you must first [create one paid ad campaign using the **Ad campaigns** page in Partner Center](../publish/create-an-ad-campaign-for-your-app.md), and you must add at least one payment instrument on this page.</span></span> <span data-ttu-id="d42ec-109">これを行うと、この API を使用して、広告キャンペーンの請求可能な配信ラインを正しく作成することができます。</span><span class="sxs-lookup"><span data-stu-id="d42ec-109">After you do this, you will be able to successfully create billable delivery lines for ad campaigns using this API.</span></span> <span data-ttu-id="d42ec-110">API を使用して作成した広告キャンペーンでは、パートナー センターでの**広告キャンペーン**] ページで選んだ既定の支払い方法を自動的に請求されます。</span><span class="sxs-lookup"><span data-stu-id="d42ec-110">Ad campaigns you create using the API will automatically bill the default payment instrument chosen on the **Ad campaigns** page in Partner Center.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d42ec-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="d42ec-111">Prerequisites</span></span>

<span data-ttu-id="d42ec-112">これらのメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d42ec-112">To use these methods, you need to first do the following:</span></span>

* <span data-ttu-id="d42ec-113">Microsoft Store プロモーション API に関するすべての[前提条件](run-ad-campaigns-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="d42ec-113">If you have not done so already, complete all the [prerequisites](run-ad-campaigns-using-windows-store-services.md#prerequisites) for the Microsoft Store promotions API.</span></span>

  > [!NOTE]
  > <span data-ttu-id="d42ec-114">前提条件の一部として、そのする[パートナー センターで、少なくとも 1 つの有料の広告キャンペーンを作成](../publish/create-an-ad-campaign-for-your-app.md)していることを確認する追加、広告キャンペーンの支払い方法を少なくとも 1 つパートナー センターでします。</span><span class="sxs-lookup"><span data-stu-id="d42ec-114">As part of the prerequisites, be sure that you [create at least one paid ad campaign in Partner Center](../publish/create-an-ad-campaign-for-your-app.md) and that you add at least one payment instrument for the ad campaign in Partner Center.</span></span> <span data-ttu-id="d42ec-115">この API を使用して作成した配信ラインでは、パートナー センターでの**広告キャンペーン**] ページで選んだ既定の支払い方法を自動的に請求されます。</span><span class="sxs-lookup"><span data-stu-id="d42ec-115">Delivery lines you create using this API will automatically bill the default payment instrument chosen on the **Ad campaigns** page in Partner Center.</span></span>

* <span data-ttu-id="d42ec-116">これらのメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="d42ec-116">[Obtain an Azure AD access token](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for these methods.</span></span> <span data-ttu-id="d42ec-117">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-117">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="d42ec-118">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d42ec-118">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="d42ec-119">要求</span><span class="sxs-lookup"><span data-stu-id="d42ec-119">Request</span></span>

<span data-ttu-id="d42ec-120">これらのメソッドでは、次の URL が使用されます。</span><span class="sxs-lookup"><span data-stu-id="d42ec-120">These methods have the following URIs.</span></span>

| <span data-ttu-id="d42ec-121">メソッドの種類</span><span class="sxs-lookup"><span data-stu-id="d42ec-121">Method type</span></span> | <span data-ttu-id="d42ec-122">要求 URI</span><span class="sxs-lookup"><span data-stu-id="d42ec-122">Request URI</span></span>         |  <span data-ttu-id="d42ec-123">説明</span><span class="sxs-lookup"><span data-stu-id="d42ec-123">Description</span></span>  |
|--------|---------------------------|---------------|
| <span data-ttu-id="d42ec-124">POST</span><span class="sxs-lookup"><span data-stu-id="d42ec-124">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/line``` |  <span data-ttu-id="d42ec-125">新しい配信ラインを作成します。</span><span class="sxs-lookup"><span data-stu-id="d42ec-125">Creates a new delivery line.</span></span>  |
| <span data-ttu-id="d42ec-126">PUT</span><span class="sxs-lookup"><span data-stu-id="d42ec-126">PUT</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/line/{lineId}``` |  <span data-ttu-id="d42ec-127">*lineId* により指定された配信ラインを編集します。</span><span class="sxs-lookup"><span data-stu-id="d42ec-127">Edits the delivery line specified by *lineId*.</span></span>  |
| <span data-ttu-id="d42ec-128">GET</span><span class="sxs-lookup"><span data-stu-id="d42ec-128">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/line/{lineId}``` |  <span data-ttu-id="d42ec-129">*lineId* により指定された配信ラインを取得します。</span><span class="sxs-lookup"><span data-stu-id="d42ec-129">Gets the delivery line specified by *lineId*.</span></span>  |


### <a name="header"></a><span data-ttu-id="d42ec-130">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d42ec-130">Header</span></span>

| <span data-ttu-id="d42ec-131">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d42ec-131">Header</span></span>        | <span data-ttu-id="d42ec-132">型</span><span class="sxs-lookup"><span data-stu-id="d42ec-132">Type</span></span>   | <span data-ttu-id="d42ec-133">説明</span><span class="sxs-lookup"><span data-stu-id="d42ec-133">Description</span></span>         |
|---------------|--------|---------------------|
| <span data-ttu-id="d42ec-134">Authorization</span><span class="sxs-lookup"><span data-stu-id="d42ec-134">Authorization</span></span> | <span data-ttu-id="d42ec-135">string</span><span class="sxs-lookup"><span data-stu-id="d42ec-135">string</span></span> | <span data-ttu-id="d42ec-136">必須。</span><span class="sxs-lookup"><span data-stu-id="d42ec-136">Required.</span></span> <span data-ttu-id="d42ec-137">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="d42ec-137">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |
| <span data-ttu-id="d42ec-138">追跡 ID</span><span class="sxs-lookup"><span data-stu-id="d42ec-138">Tracking ID</span></span>   | <span data-ttu-id="d42ec-139">GUID</span><span class="sxs-lookup"><span data-stu-id="d42ec-139">GUID</span></span>   | <span data-ttu-id="d42ec-140">省略可能。</span><span class="sxs-lookup"><span data-stu-id="d42ec-140">Optional.</span></span> <span data-ttu-id="d42ec-141">呼び出しフローを追跡する ID。</span><span class="sxs-lookup"><span data-stu-id="d42ec-141">An ID that tracks the call flow.</span></span>                                  |


### <a name="request-body"></a><span data-ttu-id="d42ec-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="d42ec-142">Request body</span></span>

<span data-ttu-id="d42ec-143">POST メソッドと PUT メソッドには、[配信ライン](#line) オブジェクトの必須フィールドと設定または変更する追加フィールドを持つ JSON 要求本文が必要です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-143">The POST and PUT methods require a JSON request body with the required fields of a [Delivery line](#line) object and any additional fields you want to set or change.</span></span>


### <a name="request-examples"></a><span data-ttu-id="d42ec-144">要求の例</span><span class="sxs-lookup"><span data-stu-id="d42ec-144">Request examples</span></span>

<span data-ttu-id="d42ec-145">次の例は、POST メソッドを呼び出して配信ラインを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d42ec-145">The following example demonstrates how to call the POST method to create a delivery line.</span></span>

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

<span data-ttu-id="d42ec-146">次の例は、GET メソッドを呼び出して配信ラインを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d42ec-146">The following example demonstrates how to call the GET method to retrieve a delivery line.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/line/31019990  HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="d42ec-147">応答</span><span class="sxs-lookup"><span data-stu-id="d42ec-147">Response</span></span>

<span data-ttu-id="d42ec-148">これらのメソッドは、作成、更新、または取得された配信ラインに関する情報を含む[配信ライン](#line) オブジェクトを持つ JSON 応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="d42ec-148">These methods return a JSON response body with a [Delivery line](#line) object that contains information about the delivery line that was created, updated, or retrieved.</span></span> <span data-ttu-id="d42ec-149">これらのメソッドの応答本文を次の例に示します。</span><span class="sxs-lookup"><span data-stu-id="d42ec-149">The following example demonstrates a response body for these methods.</span></span>

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

## <a name="delivery-line-object"></a><span data-ttu-id="d42ec-150">配信ライン オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d42ec-150">Delivery line object</span></span>

<span data-ttu-id="d42ec-151">これらのメソッドの要求本文と応答本文には、次のフィールドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d42ec-151">The request and response bodies for these methods contain the following fields.</span></span> <span data-ttu-id="d42ec-152">この表は、読み取り専用のフィールド (つまり、PUT メソッドで変更できない) と POST メソッドまたは PUT メソッドの要求本文で必須のフィールドを示しています。</span><span class="sxs-lookup"><span data-stu-id="d42ec-152">This table shows which fields are read-only (meaning that they cannot be changed in the PUT method) and which fields are required in the request body for the POST or PUT methods.</span></span>

| <span data-ttu-id="d42ec-153">フィールド</span><span class="sxs-lookup"><span data-stu-id="d42ec-153">Field</span></span>        | <span data-ttu-id="d42ec-154">型</span><span class="sxs-lookup"><span data-stu-id="d42ec-154">Type</span></span>   |  <span data-ttu-id="d42ec-155">説明</span><span class="sxs-lookup"><span data-stu-id="d42ec-155">Description</span></span>      |  <span data-ttu-id="d42ec-156">読み取り専用かどうか</span><span class="sxs-lookup"><span data-stu-id="d42ec-156">Read only</span></span>  | <span data-ttu-id="d42ec-157">既定値</span><span class="sxs-lookup"><span data-stu-id="d42ec-157">Default</span></span>  | <span data-ttu-id="d42ec-158">POST/PUT に必須かどうか</span><span class="sxs-lookup"><span data-stu-id="d42ec-158">Required for POST/PUT</span></span> |   
|--------------|--------|---------------|------|-------------|------------|
|  <span data-ttu-id="d42ec-159">id</span><span class="sxs-lookup"><span data-stu-id="d42ec-159">id</span></span>   |  <span data-ttu-id="d42ec-160">整数</span><span class="sxs-lookup"><span data-stu-id="d42ec-160">integer</span></span>   |  <span data-ttu-id="d42ec-161">配信ラインの ID です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-161">The ID of the delivery line.</span></span>     |   <span data-ttu-id="d42ec-162">○</span><span class="sxs-lookup"><span data-stu-id="d42ec-162">Yes</span></span>    |      |  <span data-ttu-id="d42ec-163">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-163">No</span></span>      |    
|  <span data-ttu-id="d42ec-164">name</span><span class="sxs-lookup"><span data-stu-id="d42ec-164">name</span></span>   |  <span data-ttu-id="d42ec-165">文字列</span><span class="sxs-lookup"><span data-stu-id="d42ec-165">string</span></span>   |   <span data-ttu-id="d42ec-166">配信ラインの名前です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-166">The name of the delivery line.</span></span>    |    <span data-ttu-id="d42ec-167">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-167">No</span></span>   |      |  <span data-ttu-id="d42ec-168">POST</span><span class="sxs-lookup"><span data-stu-id="d42ec-168">POST</span></span>     |     
|  <span data-ttu-id="d42ec-169">configuredStatus</span><span class="sxs-lookup"><span data-stu-id="d42ec-169">configuredStatus</span></span>   |  <span data-ttu-id="d42ec-170">文字列</span><span class="sxs-lookup"><span data-stu-id="d42ec-170">string</span></span>   |  <span data-ttu-id="d42ec-171">開発者により指定された配信ラインのステータスを指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-171">One of the following values that specifies the status of the delivery line specified by the developer:</span></span> <ul><li>**<span data-ttu-id="d42ec-172">Active</span><span class="sxs-lookup"><span data-stu-id="d42ec-172">Active</span></span>**</li><li>**<span data-ttu-id="d42ec-173">Inactive</span><span class="sxs-lookup"><span data-stu-id="d42ec-173">Inactive</span></span>**</li></ul>     |  <span data-ttu-id="d42ec-174">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-174">No</span></span>     |      |   <span data-ttu-id="d42ec-175">POST</span><span class="sxs-lookup"><span data-stu-id="d42ec-175">POST</span></span>    |       
|  <span data-ttu-id="d42ec-176">effectiveStatus</span><span class="sxs-lookup"><span data-stu-id="d42ec-176">effectiveStatus</span></span>   |  <span data-ttu-id="d42ec-177">文字列</span><span class="sxs-lookup"><span data-stu-id="d42ec-177">string</span></span>   |   <span data-ttu-id="d42ec-178">システム検証に基づいて配信ラインの有効ステータスを指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-178">One of the following values that specifies the effective status of the delivery line based on system validation:</span></span> <ul><li>**<span data-ttu-id="d42ec-179">Active</span><span class="sxs-lookup"><span data-stu-id="d42ec-179">Active</span></span>**</li><li>**<span data-ttu-id="d42ec-180">Inactive</span><span class="sxs-lookup"><span data-stu-id="d42ec-180">Inactive</span></span>**</li><li>**<span data-ttu-id="d42ec-181">Processing</span><span class="sxs-lookup"><span data-stu-id="d42ec-181">Processing</span></span>**</li><li>**<span data-ttu-id="d42ec-182">Failed</span><span class="sxs-lookup"><span data-stu-id="d42ec-182">Failed</span></span>**</li></ul>    |    <span data-ttu-id="d42ec-183">○</span><span class="sxs-lookup"><span data-stu-id="d42ec-183">Yes</span></span>   |      |  <span data-ttu-id="d42ec-184">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-184">No</span></span>      |      
|  <span data-ttu-id="d42ec-185">effectiveStatusReasons</span><span class="sxs-lookup"><span data-stu-id="d42ec-185">effectiveStatusReasons</span></span>   |  <span data-ttu-id="d42ec-186">配列</span><span class="sxs-lookup"><span data-stu-id="d42ec-186">array</span></span>   |  <span data-ttu-id="d42ec-187">配信ラインの有効ステータスの理由を指定する次のうち 1 つ以上の値です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-187">One or more of the following values that specify the reason for the effective status of the delivery line:</span></span> <ul><li>**<span data-ttu-id="d42ec-188">AdCreativesInactive</span><span class="sxs-lookup"><span data-stu-id="d42ec-188">AdCreativesInactive</span></span>**</li><li>**<span data-ttu-id="d42ec-189">ValidationFailed</span><span class="sxs-lookup"><span data-stu-id="d42ec-189">ValidationFailed</span></span>**</li></ul>      |  <span data-ttu-id="d42ec-190">○</span><span class="sxs-lookup"><span data-stu-id="d42ec-190">Yes</span></span>     |     |    <span data-ttu-id="d42ec-191">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-191">No</span></span>    |           
|  <span data-ttu-id="d42ec-192">startDatetime</span><span class="sxs-lookup"><span data-stu-id="d42ec-192">startDatetime</span></span>   |  <span data-ttu-id="d42ec-193">文字列</span><span class="sxs-lookup"><span data-stu-id="d42ec-193">string</span></span>   |  <span data-ttu-id="d42ec-194">配信ラインの開始日時です (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="d42ec-194">The start date and time for the delivery line, in ISO 8601 format.</span></span> <span data-ttu-id="d42ec-195">日時が過去の場合、この値を変更できません。</span><span class="sxs-lookup"><span data-stu-id="d42ec-195">This value cannot be changed if it is already in the past.</span></span>     |    <span data-ttu-id="d42ec-196">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-196">No</span></span>   |      |    <span data-ttu-id="d42ec-197">POST、PUT</span><span class="sxs-lookup"><span data-stu-id="d42ec-197">POST, PUT</span></span>     |
|  <span data-ttu-id="d42ec-198">endDatetime</span><span class="sxs-lookup"><span data-stu-id="d42ec-198">endDatetime</span></span>   |  <span data-ttu-id="d42ec-199">文字列</span><span class="sxs-lookup"><span data-stu-id="d42ec-199">string</span></span>   |  <span data-ttu-id="d42ec-200">配信ラインの終了日時です (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="d42ec-200">The end date and time for the delivery line, in ISO 8601 format.</span></span> <span data-ttu-id="d42ec-201">日時が過去の場合、この値を変更できません。</span><span class="sxs-lookup"><span data-stu-id="d42ec-201">This value cannot be changed if it is already in the past.</span></span>     |   <span data-ttu-id="d42ec-202">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-202">No</span></span>    |      |  <span data-ttu-id="d42ec-203">POST、PUT</span><span class="sxs-lookup"><span data-stu-id="d42ec-203">POST, PUT</span></span>     |
|  <span data-ttu-id="d42ec-204">createdDatetime</span><span class="sxs-lookup"><span data-stu-id="d42ec-204">createdDatetime</span></span>   |  <span data-ttu-id="d42ec-205">文字列</span><span class="sxs-lookup"><span data-stu-id="d42ec-205">string</span></span>   |  <span data-ttu-id="d42ec-206">配信ラインが作成された日時 (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="d42ec-206">The date and time the delivery line was created, in ISO 8601 format.</span></span>      |    <span data-ttu-id="d42ec-207">○</span><span class="sxs-lookup"><span data-stu-id="d42ec-207">Yes</span></span>   |      |  <span data-ttu-id="d42ec-208">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-208">No</span></span>      |
|  <span data-ttu-id="d42ec-209">bidType</span><span class="sxs-lookup"><span data-stu-id="d42ec-209">bidType</span></span>   |  <span data-ttu-id="d42ec-210">文字列</span><span class="sxs-lookup"><span data-stu-id="d42ec-210">string</span></span>   |  <span data-ttu-id="d42ec-211">配信ラインの入札の種類を指定する値です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-211">A value that specifies the bidding type of the delivery line.</span></span> <span data-ttu-id="d42ec-212">現時点では、サポートされている唯一の値は **CPM** です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-212">Currently, the only supported value is **CPM**.</span></span>      |    <span data-ttu-id="d42ec-213">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-213">No</span></span>   |  <span data-ttu-id="d42ec-214">CPM</span><span class="sxs-lookup"><span data-stu-id="d42ec-214">CPM</span></span>    |  <span data-ttu-id="d42ec-215">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-215">No</span></span>     |
|  <span data-ttu-id="d42ec-216">bidAmount</span><span class="sxs-lookup"><span data-stu-id="d42ec-216">bidAmount</span></span>   |  <span data-ttu-id="d42ec-217">10 進数</span><span class="sxs-lookup"><span data-stu-id="d42ec-217">decimal</span></span>   |  <span data-ttu-id="d42ec-218">広告要求の入札に使う入札額です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-218">The bid amount to be used for bidding any ad request.</span></span>      |    <span data-ttu-id="d42ec-219">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-219">No</span></span>   |  <span data-ttu-id="d42ec-220">対象市場に基づく平均 CPM 値です (この値は定期的に変更されます)。</span><span class="sxs-lookup"><span data-stu-id="d42ec-220">The average CPM value based on target markets (this value is revised periodically).</span></span>    |    <span data-ttu-id="d42ec-221">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-221">No</span></span>    |  
|  <span data-ttu-id="d42ec-222">dailyBudget</span><span class="sxs-lookup"><span data-stu-id="d42ec-222">dailyBudget</span></span>   |  <span data-ttu-id="d42ec-223">10 進数</span><span class="sxs-lookup"><span data-stu-id="d42ec-223">decimal</span></span>   |  <span data-ttu-id="d42ec-224">配信ラインの 1 日あたりの予算です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-224">The daily budget for the delivery line.</span></span> <span data-ttu-id="d42ec-225">*dailyBudget* または *lifetimeBudget* を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d42ec-225">Either *dailyBudget* or *lifetimeBudget* must be set.</span></span>      |    <span data-ttu-id="d42ec-226">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-226">No</span></span>   |      |   <span data-ttu-id="d42ec-227">POST、PUT (*lifetimeBudget* が設定されていない場合)</span><span class="sxs-lookup"><span data-stu-id="d42ec-227">POST, PUT (if *lifetimeBudget* is not set)</span></span>       |
|  <span data-ttu-id="d42ec-228">lifetimeBudget</span><span class="sxs-lookup"><span data-stu-id="d42ec-228">lifetimeBudget</span></span>   |  <span data-ttu-id="d42ec-229">10 進数</span><span class="sxs-lookup"><span data-stu-id="d42ec-229">decimal</span></span>   |   <span data-ttu-id="d42ec-230">配信ラインの全体予算です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-230">The lifetime budget for the delivery line.</span></span> <span data-ttu-id="d42ec-231">lifetimeBudget\* または *dailyBudget* を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d42ec-231">Either lifetimeBudget\* or *dailyBudget* must be set.</span></span>      |    <span data-ttu-id="d42ec-232">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-232">No</span></span>   |      |   <span data-ttu-id="d42ec-233">POST、PUT (*dailyBudget* が設定されていない場合)</span><span class="sxs-lookup"><span data-stu-id="d42ec-233">POST, PUT  (if *dailyBudget* is not set)</span></span>    |
|  <span data-ttu-id="d42ec-234">targetingProfileId</span><span class="sxs-lookup"><span data-stu-id="d42ec-234">targetingProfileId</span></span>   |  <span data-ttu-id="d42ec-235">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d42ec-235">object</span></span>   |  <span data-ttu-id="d42ec-236">この配信ラインを対象にするユーザー、地域、およびインベントリの種類を指定する[対象プロファイル](manage-targeting-profiles-for-ad-campaigns.md#targeting-profile)を識別するオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="d42ec-236">On object that identifies the [targeting profile](manage-targeting-profiles-for-ad-campaigns.md#targeting-profile) that describes the users, geographies and inventory types that you want to target for this delivery line.</span></span> <span data-ttu-id="d42ec-237">このオブジェクトは、対象プロファイルの ID を指定する単一の *id* フィールドで構成されます。</span><span class="sxs-lookup"><span data-stu-id="d42ec-237">This object consists of a single *id* field that specifies the ID of the targeting profile.</span></span>     |    <span data-ttu-id="d42ec-238">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-238">No</span></span>   |      |  <span data-ttu-id="d42ec-239">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-239">No</span></span>      |  
|  <span data-ttu-id="d42ec-240">creatives</span><span class="sxs-lookup"><span data-stu-id="d42ec-240">creatives</span></span>   |  <span data-ttu-id="d42ec-241">配列</span><span class="sxs-lookup"><span data-stu-id="d42ec-241">array</span></span>   |  <span data-ttu-id="d42ec-242">配信ラインに関連づけられた[クリエイティブ](manage-creatives-for-ad-campaigns.md#creative)を表す 1 つ以上のオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="d42ec-242">One or more objects that represent the [creatives](manage-creatives-for-ad-campaigns.md#creative) that are associated with the delivery line.</span></span> <span data-ttu-id="d42ec-243">このフィールド内の各オブジェクトは、クリエイティブの ID を指定する単一の *id* フィールドで構成されます。</span><span class="sxs-lookup"><span data-stu-id="d42ec-243">Each object in this field consists of a single *id* field that specifies the ID of a creative.</span></span>      |    <span data-ttu-id="d42ec-244">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-244">No</span></span>   |      |   <span data-ttu-id="d42ec-245">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-245">No</span></span>     |  
|  <span data-ttu-id="d42ec-246">campaignId</span><span class="sxs-lookup"><span data-stu-id="d42ec-246">campaignId</span></span>   |  <span data-ttu-id="d42ec-247">整数</span><span class="sxs-lookup"><span data-stu-id="d42ec-247">integer</span></span>   |  <span data-ttu-id="d42ec-248">親広告キャンペーンの ID です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-248">The ID of the parent ad campaign.</span></span>      |    <span data-ttu-id="d42ec-249">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-249">No</span></span>   |      |   <span data-ttu-id="d42ec-250">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-250">No</span></span>     |  
|  <span data-ttu-id="d42ec-251">minMinutesPerImp</span><span class="sxs-lookup"><span data-stu-id="d42ec-251">minMinutesPerImp</span></span>   |  <span data-ttu-id="d42ec-252">整数</span><span class="sxs-lookup"><span data-stu-id="d42ec-252">integer</span></span>   |  <span data-ttu-id="d42ec-253">この配信ラインから同じユーザーに表示される 2 つのインプレッション間の間隔 (分単位) を指定します。</span><span class="sxs-lookup"><span data-stu-id="d42ec-253">Specifies the minimum time interval (in minutes) between two impressions shown to the same user from this delivery line.</span></span>      |    <span data-ttu-id="d42ec-254">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-254">No</span></span>   |  <span data-ttu-id="d42ec-255">4000</span><span class="sxs-lookup"><span data-stu-id="d42ec-255">4000</span></span>    |  <span data-ttu-id="d42ec-256">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-256">No</span></span>      |  
|  <span data-ttu-id="d42ec-257">pacingType</span><span class="sxs-lookup"><span data-stu-id="d42ec-257">pacingType</span></span>   |  <span data-ttu-id="d42ec-258">文字列</span><span class="sxs-lookup"><span data-stu-id="d42ec-258">string</span></span>   |  <span data-ttu-id="d42ec-259">ペーシングの種類を指定する次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-259">One of the following values that specify the pacing type:</span></span> <ul><li>**<span data-ttu-id="d42ec-260">SpendEvenly</span><span class="sxs-lookup"><span data-stu-id="d42ec-260">SpendEvenly</span></span>**</li><li>**<span data-ttu-id="d42ec-261">SpendAsFastAsPossible</span><span class="sxs-lookup"><span data-stu-id="d42ec-261">SpendAsFastAsPossible</span></span>**</li></ul>      |    <span data-ttu-id="d42ec-262">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-262">No</span></span>   |  <span data-ttu-id="d42ec-263">SpendEvenly</span><span class="sxs-lookup"><span data-stu-id="d42ec-263">SpendEvenly</span></span>    |  <span data-ttu-id="d42ec-264">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-264">No</span></span>      |
|  <span data-ttu-id="d42ec-265">currencyId</span><span class="sxs-lookup"><span data-stu-id="d42ec-265">currencyId</span></span>   |  <span data-ttu-id="d42ec-266">整数</span><span class="sxs-lookup"><span data-stu-id="d42ec-266">integer</span></span>   |  <span data-ttu-id="d42ec-267">キャンペーンの通貨の ID です。</span><span class="sxs-lookup"><span data-stu-id="d42ec-267">The ID of the currency of the campaign.</span></span>      |    <span data-ttu-id="d42ec-268">○</span><span class="sxs-lookup"><span data-stu-id="d42ec-268">Yes</span></span>   |  <span data-ttu-id="d42ec-269">開発者アカウントの通貨 (POST または PUT 呼び出しではこのフィールドを指定する必要はありません)</span><span class="sxs-lookup"><span data-stu-id="d42ec-269">The currency of the developer account (you do not need to specify this field in POST or PUT calls)</span></span>    |   <span data-ttu-id="d42ec-270">×</span><span class="sxs-lookup"><span data-stu-id="d42ec-270">No</span></span>     |      |


## <a name="related-topics"></a><span data-ttu-id="d42ec-271">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d42ec-271">Related topics</span></span>

* [<span data-ttu-id="d42ec-272">Microsoft Store サービスを使用した広告キャンペーンの実行</span><span class="sxs-lookup"><span data-stu-id="d42ec-272">Run ad campaigns using Microsoft Store Services</span></span>](run-ad-campaigns-using-windows-store-services.md)
* [<span data-ttu-id="d42ec-273">広告キャンペーンの管理</span><span class="sxs-lookup"><span data-stu-id="d42ec-273">Manage ad campaigns</span></span>](manage-ad-campaigns.md)
* [<span data-ttu-id="d42ec-274">広告キャンペーンの対象プロファイルの管理</span><span class="sxs-lookup"><span data-stu-id="d42ec-274">Manage targeting profiles for ad campaigns</span></span>](manage-targeting-profiles-for-ad-campaigns.md)
* [<span data-ttu-id="d42ec-275">広告キャンペーンのクリエイティブの管理</span><span class="sxs-lookup"><span data-stu-id="d42ec-275">Manage creatives for ad campaigns</span></span>](manage-creatives-for-ad-campaigns.md)
* [<span data-ttu-id="d42ec-276">広告キャンペーンのパフォーマンス データの取得</span><span class="sxs-lookup"><span data-stu-id="d42ec-276">Get ad campaign performance data</span></span>](get-ad-campaign-performance-data.md)
