---
author: Xansky
ms.assetid: d305746a-d370-4404-8cde-c85765bf3578
description: プロモーション用の広告キャンペーンのターゲット プロファイルを管理するには、Microsoft Store プロモーション API の以下のメソッドを使います。
title: ターゲット プロファイルの管理
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store プロモーション API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 8fa142f1df672703d2f14dc185481bb248efe07b
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5407645"
---
# <a name="manage-targeting-profiles"></a><span data-ttu-id="78562-104">ターゲット プロファイルの管理</span><span class="sxs-lookup"><span data-stu-id="78562-104">Manage targeting profiles</span></span>


<span data-ttu-id="78562-105">プロモーション用の広告キャンペーンの各配信ラインで対象とするユーザー、地域、インベントリの種類を選択するには、Microsoft Store プロモーション API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="78562-105">Use these methods in the Microsoft Store promotions API to select the users, geographies and inventory types that you want to target for each delivery line in a promotional ad campaign.</span></span> <span data-ttu-id="78562-106">ターゲット プロファイルは、複数の配信ライン間で作成して再利用できます。</span><span class="sxs-lookup"><span data-stu-id="78562-106">Targeting profiles can be created and reused across multiple delivery lines.</span></span>

<span data-ttu-id="78562-107">ターゲット プロファイルと広告キャンペーン、配信ライン、クリエイティブとの関係について詳しくは、「[Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78562-107">For more information about the relationship between targeting profiles and ad campaigns, delivery lines, and creatives, see [Run ad campaigns using Microsoft Store services](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="78562-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="78562-108">Prerequisites</span></span>

<span data-ttu-id="78562-109">これらのメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="78562-109">To use these methods, you need to first do the following:</span></span>

* <span data-ttu-id="78562-110">Microsoft Store プロモーション API に関するすべての[前提条件](run-ad-campaigns-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="78562-110">If you have not done so already, complete all the [prerequisites](run-ad-campaigns-using-windows-store-services.md#prerequisites) for the Microsoft Store promotions API.</span></span>
* <span data-ttu-id="78562-111">これらのメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="78562-111">[Obtain an Azure AD access token](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for these methods.</span></span> <span data-ttu-id="78562-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="78562-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="78562-113">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="78562-113">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="78562-114">要求</span><span class="sxs-lookup"><span data-stu-id="78562-114">Request</span></span>

<span data-ttu-id="78562-115">これらのメソッドでは、次の URL が使用されます。</span><span class="sxs-lookup"><span data-stu-id="78562-115">These methods have the following URIs.</span></span>

| <span data-ttu-id="78562-116">メソッドの種類</span><span class="sxs-lookup"><span data-stu-id="78562-116">Method type</span></span> | <span data-ttu-id="78562-117">要求 URI</span><span class="sxs-lookup"><span data-stu-id="78562-117">Request URI</span></span>                                                      |  <span data-ttu-id="78562-118">説明</span><span class="sxs-lookup"><span data-stu-id="78562-118">Description</span></span>  |
|--------|------------------------------------------------------------------|---------------|
| <span data-ttu-id="78562-119">POST</span><span class="sxs-lookup"><span data-stu-id="78562-119">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile``` |  <span data-ttu-id="78562-120">新しい対象プロファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="78562-120">Creates a new targeting profile.</span></span>  |
| <span data-ttu-id="78562-121">PUT</span><span class="sxs-lookup"><span data-stu-id="78562-121">PUT</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile/{targetingProfileId}``` |  <span data-ttu-id="78562-122">*targetingProfileId* により指定された対象プロファイルを編集します。</span><span class="sxs-lookup"><span data-stu-id="78562-122">Edits the targeting profile specified by *targetingProfileId*.</span></span>  |
| <span data-ttu-id="78562-123">GET</span><span class="sxs-lookup"><span data-stu-id="78562-123">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile/{targetingProfileId}``` |  <span data-ttu-id="78562-124">*targetingProfileId* により指定された対象プロファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="78562-124">Gets the targeting profile specified by *targetingProfileId*.</span></span>  |


### <a name="header"></a><span data-ttu-id="78562-125">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78562-125">Header</span></span>

| <span data-ttu-id="78562-126">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78562-126">Header</span></span>        | <span data-ttu-id="78562-127">型</span><span class="sxs-lookup"><span data-stu-id="78562-127">Type</span></span>   | <span data-ttu-id="78562-128">説明</span><span class="sxs-lookup"><span data-stu-id="78562-128">Description</span></span>         |
|---------------|--------|---------------------|
| <span data-ttu-id="78562-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="78562-129">Authorization</span></span> | <span data-ttu-id="78562-130">string</span><span class="sxs-lookup"><span data-stu-id="78562-130">string</span></span> | <span data-ttu-id="78562-131">必須。</span><span class="sxs-lookup"><span data-stu-id="78562-131">Required.</span></span> <span data-ttu-id="78562-132">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="78562-132">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |
| <span data-ttu-id="78562-133">追跡 ID</span><span class="sxs-lookup"><span data-stu-id="78562-133">Tracking ID</span></span>   | <span data-ttu-id="78562-134">GUID</span><span class="sxs-lookup"><span data-stu-id="78562-134">GUID</span></span>   | <span data-ttu-id="78562-135">省略可能。</span><span class="sxs-lookup"><span data-stu-id="78562-135">Optional.</span></span> <span data-ttu-id="78562-136">呼び出しフローを追跡する ID。</span><span class="sxs-lookup"><span data-stu-id="78562-136">An ID that tracks the call flow.</span></span>                                  |


### <a name="request-body"></a><span data-ttu-id="78562-137">要求本文</span><span class="sxs-lookup"><span data-stu-id="78562-137">Request body</span></span>

<span data-ttu-id="78562-138">POST メソッドと PUT メソッドには、[対象プロファイル](#targeting-profile) オブジェクトの必須フィールドと設定または変更する追加フィールドを持つ JSON 要求本文が必要です。</span><span class="sxs-lookup"><span data-stu-id="78562-138">The POST and PUT methods require a JSON request body with the required fields of a [Targeting profile](#targeting-profile) object and any additional fields you want to set or change.</span></span>


### <a name="request-examples"></a><span data-ttu-id="78562-139">要求の例</span><span class="sxs-lookup"><span data-stu-id="78562-139">Request examples</span></span>

<span data-ttu-id="78562-140">次の例は、POST メソッドを呼び出して対象プロファイルを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="78562-140">The following example demonstrates how to call the POST method to create a targeting profile.</span></span>

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile HTTP/1.1
Authorization: Bearer <your access token>

{
    "name": "Contoso App Campaign - Targeting Profile 1",
    "targetingType": "Manual",
    "age": [
      651,
      652],
    "gender": [
      700
    ],
    "country": [
      11,
      12
    ],
    "osVersion": [
      504
    ],
    "deviceType": [
      710
    ],
    "supplyType": [
      11470
    ]
}
```

<span data-ttu-id="78562-141">次の例は、GET メソッドを呼び出して対象プロファイルを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="78562-141">The following example demonstrates how to call the GET method to retrieve a targeting profile.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile/310023951  HTTP/1.1
Authorization: Bearer <your access token>
```

<span/>

## <a name="response"></a><span data-ttu-id="78562-142">応答</span><span class="sxs-lookup"><span data-stu-id="78562-142">Response</span></span>

<span data-ttu-id="78562-143">これらのメソッドは、作成、更新、または取得された対象プロファイルに関する情報を含む[対象プロファイル](#targeting-profile) オブジェクトを持つ JSON 応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="78562-143">These methods return a JSON response body with a [Targeting profile](#targeting-profile) object that contains information about the targeting profile that was created, updated, or retrieved.</span></span> <span data-ttu-id="78562-144">これらのメソッドの応答本文を次の例に示します。</span><span class="sxs-lookup"><span data-stu-id="78562-144">The following example demonstrates a response body for these methods.</span></span>

```json
{
  "Data": {
    "id": 310021746,
    "name": "Contoso App Campaign - Targeting Profile 1",
    "targetingType": "Manual",
    "age": [
      651,
      652
    ],
    "gender": [
      700
    ],
    "country": [
      6,
      13,
      29
    ],
    "osVersion": [
      504,
      505,
      506,
      507,
      508
    ],
    "deviceType": [
      710,
      711
    ],
    "supplyType": [
      11470
    ]
  }
}
```

<span id="targeting-profile"/>

## <a name="targeting-profile-object"></a><span data-ttu-id="78562-145">対象プロファイル オブジェクト</span><span class="sxs-lookup"><span data-stu-id="78562-145">Targeting profile object</span></span>

<span data-ttu-id="78562-146">これらのメソッドの要求本文と応答本文には、次のフィールドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="78562-146">The request and response bodies for these methods contain the following fields.</span></span> <span data-ttu-id="78562-147">この表は、読み取り専用のフィールド (つまり、PUT メソッドで変更できない) と POST メソッドの要求本文で必須のフィールドを示しています。</span><span class="sxs-lookup"><span data-stu-id="78562-147">This table shows which fields are read-only (meaning that they cannot be changed in the PUT method) and which fields are required in the request body for the POST method.</span></span>

| <span data-ttu-id="78562-148">フィールド</span><span class="sxs-lookup"><span data-stu-id="78562-148">Field</span></span>        | <span data-ttu-id="78562-149">型</span><span class="sxs-lookup"><span data-stu-id="78562-149">Type</span></span>   |  <span data-ttu-id="78562-150">説明</span><span class="sxs-lookup"><span data-stu-id="78562-150">Description</span></span>      |  <span data-ttu-id="78562-151">読み取り専用かどうか</span><span class="sxs-lookup"><span data-stu-id="78562-151">Read only</span></span>  | <span data-ttu-id="78562-152">既定値</span><span class="sxs-lookup"><span data-stu-id="78562-152">Default</span></span>  | <span data-ttu-id="78562-153">POST に必須かどうか</span><span class="sxs-lookup"><span data-stu-id="78562-153">Required for POST</span></span> |  
|--------------|--------|---------------|------|-------------|------------|
|  <span data-ttu-id="78562-154">id</span><span class="sxs-lookup"><span data-stu-id="78562-154">id</span></span>   |  <span data-ttu-id="78562-155">整数</span><span class="sxs-lookup"><span data-stu-id="78562-155">integer</span></span>   |  <span data-ttu-id="78562-156">対象プロファイルの ID。</span><span class="sxs-lookup"><span data-stu-id="78562-156">The ID of the targeting profile.</span></span>     |   <span data-ttu-id="78562-157">○</span><span class="sxs-lookup"><span data-stu-id="78562-157">Yes</span></span>    |       |   <span data-ttu-id="78562-158">×</span><span class="sxs-lookup"><span data-stu-id="78562-158">No</span></span>      |       
|  <span data-ttu-id="78562-159">name</span><span class="sxs-lookup"><span data-stu-id="78562-159">name</span></span>   |  <span data-ttu-id="78562-160">文字列</span><span class="sxs-lookup"><span data-stu-id="78562-160">string</span></span>   |   <span data-ttu-id="78562-161">対象プロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="78562-161">The name of the targeting profile.</span></span>    |    <span data-ttu-id="78562-162">×</span><span class="sxs-lookup"><span data-stu-id="78562-162">No</span></span>   |      |  <span data-ttu-id="78562-163">○</span><span class="sxs-lookup"><span data-stu-id="78562-163">Yes</span></span>     |       
|  <span data-ttu-id="78562-164">targetingType</span><span class="sxs-lookup"><span data-stu-id="78562-164">targetingType</span></span>   |  <span data-ttu-id="78562-165">文字列</span><span class="sxs-lookup"><span data-stu-id="78562-165">string</span></span>   |  <span data-ttu-id="78562-166">次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="78562-166">One of the following values:</span></span> <ul><li><span data-ttu-id="78562-167">**Auto**: デベロッパー センターでのアプリの設定に基づいて Microsoft が対象プロファイルを選択できるようにする場合は、この値を指定します。</span><span class="sxs-lookup"><span data-stu-id="78562-167">**Auto**: Specify this value to allow Microsoft to choose the targeting profile based on the settings for your app in Dev Center.</span></span></li><li><span data-ttu-id="78562-168">**Manual**: 独自の対象プロファイルを定義する場合は、この値を指定します。</span><span class="sxs-lookup"><span data-stu-id="78562-168">**Manual**: Specify this value to define your own targeting profile.</span></span></li></ul>     |  <span data-ttu-id="78562-169">×</span><span class="sxs-lookup"><span data-stu-id="78562-169">No</span></span>     |  <span data-ttu-id="78562-170">Auto</span><span class="sxs-lookup"><span data-stu-id="78562-170">Auto</span></span>    |   <span data-ttu-id="78562-171">○</span><span class="sxs-lookup"><span data-stu-id="78562-171">Yes</span></span>    |       
|  <span data-ttu-id="78562-172">age</span><span class="sxs-lookup"><span data-stu-id="78562-172">age</span></span>   |  <span data-ttu-id="78562-173">配列</span><span class="sxs-lookup"><span data-stu-id="78562-173">array</span></span>   |   <span data-ttu-id="78562-174">対象とするユーザーの年齢範囲を識別する 1 つ以上の整数です。</span><span class="sxs-lookup"><span data-stu-id="78562-174">One or more integers that identify the age ranges of the users to target.</span></span> <span data-ttu-id="78562-175">整数の詳しい一覧については、この記事の「[年齢の値](#age-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78562-175">For a complete list of integers, see [Age values](#age-values) in this article.</span></span>    |    <span data-ttu-id="78562-176">×</span><span class="sxs-lookup"><span data-stu-id="78562-176">No</span></span>    |  <span data-ttu-id="78562-177">null</span><span class="sxs-lookup"><span data-stu-id="78562-177">null</span></span>    |     <span data-ttu-id="78562-178">×</span><span class="sxs-lookup"><span data-stu-id="78562-178">No</span></span>    |       
|  <span data-ttu-id="78562-179">gender</span><span class="sxs-lookup"><span data-stu-id="78562-179">gender</span></span>   |  <span data-ttu-id="78562-180">配列</span><span class="sxs-lookup"><span data-stu-id="78562-180">array</span></span>   |  <span data-ttu-id="78562-181">対象とするユーザーの性別を識別する 1 つ以上の整数です。</span><span class="sxs-lookup"><span data-stu-id="78562-181">One or more integers that identify the genders of the users to target.</span></span> <span data-ttu-id="78562-182">整数の詳しい一覧については、この記事の「[性別の値](#gender-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78562-182">For a complete list of integers, see [Gender values](#gender-values) in this article.</span></span>       |  <span data-ttu-id="78562-183">×</span><span class="sxs-lookup"><span data-stu-id="78562-183">No</span></span>    |  <span data-ttu-id="78562-184">null</span><span class="sxs-lookup"><span data-stu-id="78562-184">null</span></span>    |     <span data-ttu-id="78562-185">×</span><span class="sxs-lookup"><span data-stu-id="78562-185">No</span></span>    |       
|  <span data-ttu-id="78562-186">country</span><span class="sxs-lookup"><span data-stu-id="78562-186">country</span></span>   |  <span data-ttu-id="78562-187">配列</span><span class="sxs-lookup"><span data-stu-id="78562-187">array</span></span>   |  <span data-ttu-id="78562-188">対象とするユーザーの国コードを識別する 1 つ以上の整数です。</span><span class="sxs-lookup"><span data-stu-id="78562-188">One or more integers that identify the country codes of the users to target.</span></span> <span data-ttu-id="78562-189">整数の詳しい一覧については、この記事の「[国コードの値](#country-code-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78562-189">For a complete list of integers, see [Country code values](#country-code-values) in this article.</span></span>    |  <span data-ttu-id="78562-190">×</span><span class="sxs-lookup"><span data-stu-id="78562-190">No</span></span>    |  <span data-ttu-id="78562-191">null</span><span class="sxs-lookup"><span data-stu-id="78562-191">null</span></span>   |      <span data-ttu-id="78562-192">×</span><span class="sxs-lookup"><span data-stu-id="78562-192">No</span></span>   |       
|  <span data-ttu-id="78562-193">osVersion</span><span class="sxs-lookup"><span data-stu-id="78562-193">osVersion</span></span>   |  <span data-ttu-id="78562-194">配列</span><span class="sxs-lookup"><span data-stu-id="78562-194">array</span></span>   |   <span data-ttu-id="78562-195">対象とするユーザーの OS バージョンを識別する 1 つ以上の整数です。</span><span class="sxs-lookup"><span data-stu-id="78562-195">One or more integers that identify the OS versions of the users to target.</span></span> <span data-ttu-id="78562-196">整数の詳しい一覧については、この記事の「[OS バージョンの値](#osversion-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78562-196">For a complete list of integers, see [OS version values](#osversion-values) in this article.</span></span>     |   <span data-ttu-id="78562-197">×</span><span class="sxs-lookup"><span data-stu-id="78562-197">No</span></span>    |  <span data-ttu-id="78562-198">null</span><span class="sxs-lookup"><span data-stu-id="78562-198">null</span></span>   |     <span data-ttu-id="78562-199">×</span><span class="sxs-lookup"><span data-stu-id="78562-199">No</span></span>    |       
|  <span data-ttu-id="78562-200">deviceType</span><span class="sxs-lookup"><span data-stu-id="78562-200">deviceType</span></span>   | <span data-ttu-id="78562-201">配列</span><span class="sxs-lookup"><span data-stu-id="78562-201">array</span></span>    |  <span data-ttu-id="78562-202">対象とするユーザーのデバイスの種類を識別する 1 つ以上の整数です。</span><span class="sxs-lookup"><span data-stu-id="78562-202">One or more integers that identify the device types of the users to target.</span></span> <span data-ttu-id="78562-203">整数の詳しい一覧については、この記事の「[デバイスの種類の値](#devicetype-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78562-203">For a complete list of integers, see [Device type values](#devicetype-values) in this article.</span></span>       |   <span data-ttu-id="78562-204">×</span><span class="sxs-lookup"><span data-stu-id="78562-204">No</span></span>    |  <span data-ttu-id="78562-205">null</span><span class="sxs-lookup"><span data-stu-id="78562-205">null</span></span>    |    <span data-ttu-id="78562-206">×</span><span class="sxs-lookup"><span data-stu-id="78562-206">No</span></span>     |       
|  <span data-ttu-id="78562-207">supplyType</span><span class="sxs-lookup"><span data-stu-id="78562-207">supplyType</span></span>   |  <span data-ttu-id="78562-208">配列</span><span class="sxs-lookup"><span data-stu-id="78562-208">array</span></span>   |  <span data-ttu-id="78562-209">キャンペーンの広告が表示されるインベントリの種類を識別する 1 つ以上の整数です。</span><span class="sxs-lookup"><span data-stu-id="78562-209">One or more integers that identify the type of inventory where the campaign's ads will be shown.</span></span> <span data-ttu-id="78562-210">整数の詳しい一覧については、この記事の「[サプライの種類の値](#supplytype-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78562-210">For a complete list of integers, see [Supply type values](#supplytype-values) in this article.</span></span>      |   <span data-ttu-id="78562-211">×</span><span class="sxs-lookup"><span data-stu-id="78562-211">No</span></span>    |  <span data-ttu-id="78562-212">null</span><span class="sxs-lookup"><span data-stu-id="78562-212">null</span></span>   |     <span data-ttu-id="78562-213">×</span><span class="sxs-lookup"><span data-stu-id="78562-213">No</span></span>    |   |  


<span id="age-values"/>

### <a name="age-values"></a><span data-ttu-id="78562-214">年齢の値</span><span class="sxs-lookup"><span data-stu-id="78562-214">Age values</span></span>

<span data-ttu-id="78562-215">[TargetingProfile](#targeting-profile) オブジェクトの *age* フィールドには、対象とするユーザーの年齢範囲を識別する次の整数が 1 つ以上含まれています。</span><span class="sxs-lookup"><span data-stu-id="78562-215">The *age* field in the [TargetingProfile](#targeting-profile) object contains one or more of the following integers that identify the age ranges of the users to target.</span></span>

|  <span data-ttu-id="78562-216">*age* フィールドの整数値</span><span class="sxs-lookup"><span data-stu-id="78562-216">Integer value for *age* field</span></span>  |  <span data-ttu-id="78562-217">対応する年齢範囲</span><span class="sxs-lookup"><span data-stu-id="78562-217">Corresponding age range</span></span>  |  
|---------------------------------|---------------------------|
|     <span data-ttu-id="78562-218">651</span><span class="sxs-lookup"><span data-stu-id="78562-218">651</span></span>     |            <span data-ttu-id="78562-219">13 ～ 17</span><span class="sxs-lookup"><span data-stu-id="78562-219">13 to 17</span></span>             |
|     <span data-ttu-id="78562-220">652</span><span class="sxs-lookup"><span data-stu-id="78562-220">652</span></span>     |           <span data-ttu-id="78562-221">18 ～ 24</span><span class="sxs-lookup"><span data-stu-id="78562-221">18 to 24</span></span>             |
|     <span data-ttu-id="78562-222">653</span><span class="sxs-lookup"><span data-stu-id="78562-222">653</span></span>     |            <span data-ttu-id="78562-223">25 ～ 34</span><span class="sxs-lookup"><span data-stu-id="78562-223">25 to 34</span></span>             |
|     <span data-ttu-id="78562-224">654</span><span class="sxs-lookup"><span data-stu-id="78562-224">654</span></span>     |            <span data-ttu-id="78562-225">35 ～ 49</span><span class="sxs-lookup"><span data-stu-id="78562-225">35 to 49</span></span>             |
|     <span data-ttu-id="78562-226">655</span><span class="sxs-lookup"><span data-stu-id="78562-226">655</span></span>     |            <span data-ttu-id="78562-227">50 以上</span><span class="sxs-lookup"><span data-stu-id="78562-227">50 and above</span></span>             |

<span data-ttu-id="78562-228">*age* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="78562-228">To get the supported values for the *age* field programmatically, you can call the following GET method.</span></span>  <span data-ttu-id="78562-229">```Authorization``` ヘッダーでは、**Bearer** &lt;*トークン*&gt; の形式で Azure AD アクセス トークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="78562-229">For the ```Authorization``` header, pass your Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/age
Authorization: Bearer <your access token>
```

<span data-ttu-id="78562-230">次の例は、このメソッドの応答本文を示します。</span><span class="sxs-lookup"><span data-stu-id="78562-230">The following example shows the response body for this method.</span></span>

```json
{
  "Data": {
    "Age": {
      "651": "Age13To17",
      "652": "Age18To24",
      "653": "Age25To34",
      "654": "Age35To49",
      "655": "Age50AndAbove"
    }
  }
}
```

<span id="gender-values"/>

### <a name="gender-values"></a><span data-ttu-id="78562-231">性別の値</span><span class="sxs-lookup"><span data-stu-id="78562-231">Gender values</span></span>

<span data-ttu-id="78562-232">[TargetingProfile](#targeting-profile) オブジェクトの *gender* フィールドには、対象とするユーザーの性別を識別する次の整数が 1 つ以上含まれています。</span><span class="sxs-lookup"><span data-stu-id="78562-232">The *gender* field in the [TargetingProfile](#targeting-profile) object contains one or more of the following integers that identify the genders of the users to target.</span></span>

|  <span data-ttu-id="78562-233">*gender* フィールドの整数値</span><span class="sxs-lookup"><span data-stu-id="78562-233">Integer value for *gender* field</span></span>  |  <span data-ttu-id="78562-234">対応する性別</span><span class="sxs-lookup"><span data-stu-id="78562-234">Corresponding gender</span></span>  |  
|---------------------------------|---------------------------|
|     <span data-ttu-id="78562-235">700</span><span class="sxs-lookup"><span data-stu-id="78562-235">700</span></span>     |            <span data-ttu-id="78562-236">男性</span><span class="sxs-lookup"><span data-stu-id="78562-236">Male</span></span>             |
|     <span data-ttu-id="78562-237">701</span><span class="sxs-lookup"><span data-stu-id="78562-237">701</span></span>     |           <span data-ttu-id="78562-238">女性</span><span class="sxs-lookup"><span data-stu-id="78562-238">Female</span></span>             |

<span data-ttu-id="78562-239">*gender* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="78562-239">To get the supported values for the *gender* field programmatically, you can call the following GET method.</span></span>  <span data-ttu-id="78562-240">```Authorization``` ヘッダーでは、**Bearer** &lt;*トークン*&gt; の形式で Azure AD アクセス トークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="78562-240">For the ```Authorization``` header, pass your Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/gender
Authorization: Bearer <your access token>
```

<span data-ttu-id="78562-241">次の例は、このメソッドの応答本文を示します。</span><span class="sxs-lookup"><span data-stu-id="78562-241">The following example shows the response body for this method.</span></span>

```json
{
  "Data": {
    "Gender": {
      "700": "Male",
      "701": "Female"
    }
  }
}
```


<span id="osversion-values"/>

### <a name="os-version-values"></a><span data-ttu-id="78562-242">OS バージョンの値</span><span class="sxs-lookup"><span data-stu-id="78562-242">OS version values</span></span>

<span data-ttu-id="78562-243">[TargetingProfile](#targeting-profile) オブジェクトの *osVersion* フィールドには、対象とするユーザーの OS バージョンを識別する次の整数が 1 つ以上含まれています。</span><span class="sxs-lookup"><span data-stu-id="78562-243">The *osVersion* field in the [TargetingProfile](#targeting-profile) object contains one or more of the following integers that identify the OS versions of the users to target.</span></span>

|  <span data-ttu-id="78562-244">*osVersion* フィールドの整数値</span><span class="sxs-lookup"><span data-stu-id="78562-244">Integer value for *osVersion* field</span></span>  |  <span data-ttu-id="78562-245">対応する OS バージョン</span><span class="sxs-lookup"><span data-stu-id="78562-245">Corresponding OS version</span></span>  |  
|---------------------------------|---------------------------|
|     <span data-ttu-id="78562-246">500</span><span class="sxs-lookup"><span data-stu-id="78562-246">500</span></span>     |            <span data-ttu-id="78562-247">Windows Phone 7</span><span class="sxs-lookup"><span data-stu-id="78562-247">Windows Phone 7</span></span>             |
|     <span data-ttu-id="78562-248">501</span><span class="sxs-lookup"><span data-stu-id="78562-248">501</span></span>     |           <span data-ttu-id="78562-249">Windows Phone 7.1</span><span class="sxs-lookup"><span data-stu-id="78562-249">Windows Phone 7.1</span></span>             |
|     <span data-ttu-id="78562-250">502</span><span class="sxs-lookup"><span data-stu-id="78562-250">502</span></span>     |           <span data-ttu-id="78562-251">Windows Phone 7.5</span><span class="sxs-lookup"><span data-stu-id="78562-251">Windows Phone 7.5</span></span>             |
|     <span data-ttu-id="78562-252">503</span><span class="sxs-lookup"><span data-stu-id="78562-252">503</span></span>     |           <span data-ttu-id="78562-253">Windows Phone 7.8</span><span class="sxs-lookup"><span data-stu-id="78562-253">Windows Phone 7.8</span></span>             |
|     <span data-ttu-id="78562-254">504</span><span class="sxs-lookup"><span data-stu-id="78562-254">504</span></span>     |           <span data-ttu-id="78562-255">Windows Phone 8.0</span><span class="sxs-lookup"><span data-stu-id="78562-255">Windows Phone 8.0</span></span>             |
|     <span data-ttu-id="78562-256">505</span><span class="sxs-lookup"><span data-stu-id="78562-256">505</span></span>     |           <span data-ttu-id="78562-257">Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="78562-257">Windows Phone 8.1</span></span>             |
|     <span data-ttu-id="78562-258">506</span><span class="sxs-lookup"><span data-stu-id="78562-258">506</span></span>     |           <span data-ttu-id="78562-259">Windows 8.0</span><span class="sxs-lookup"><span data-stu-id="78562-259">Windows 8.0</span></span>             |
|     <span data-ttu-id="78562-260">507</span><span class="sxs-lookup"><span data-stu-id="78562-260">507</span></span>     |           <span data-ttu-id="78562-261">Windows 8.1</span><span class="sxs-lookup"><span data-stu-id="78562-261">Windows 8.1</span></span>             |
|     <span data-ttu-id="78562-262">508</span><span class="sxs-lookup"><span data-stu-id="78562-262">508</span></span>     |           <span data-ttu-id="78562-263">Windows 10</span><span class="sxs-lookup"><span data-stu-id="78562-263">Windows 10</span></span>             |
|     <span data-ttu-id="78562-264">509</span><span class="sxs-lookup"><span data-stu-id="78562-264">509</span></span>     |           <span data-ttu-id="78562-265">Windows 10 Mobile</span><span class="sxs-lookup"><span data-stu-id="78562-265">Windows 10 Mobile</span></span>             |

<span data-ttu-id="78562-266">*osVersion* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="78562-266">To get the supported values for the *osVersion* field programmatically, you can call the following GET method.</span></span>  <span data-ttu-id="78562-267">```Authorization``` ヘッダーでは、**Bearer** &lt;*トークン*&gt; の形式で Azure AD アクセス トークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="78562-267">For the ```Authorization``` header, pass your Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/osversion
Authorization: Bearer <your access token>
```

<span data-ttu-id="78562-268">次の例は、このメソッドの応答本文を示します。</span><span class="sxs-lookup"><span data-stu-id="78562-268">The following example shows the response body for this method.</span></span>

```json
{
  "Data": {
    "OsVersion": {
      "500": "WindowsPhone70",
      "501": "WindowsPhone71",
      "502": "WindowsPhone75",
      "503": "WindowsPhone78",
      "504": "WindowsPhone80",
      "505": "WindowsPhone81",
      "506": "Windows80",
      "507": "Windows81",
      "508": "Windows10",
      "509": "WindowsPhone10"
    }
  }
}
```


<span id="devicetype-values"/>

### <a name="device-type-values"></a><span data-ttu-id="78562-269">デバイスの種類の値</span><span class="sxs-lookup"><span data-stu-id="78562-269">Device type values</span></span>

<span data-ttu-id="78562-270">[TargetingProfile](#targeting-profile) オブジェクトの *deviceType* フィールドには、対象とするユーザーのデバイスの種類を識別する次の整数が 1 つ以上含まれています。</span><span class="sxs-lookup"><span data-stu-id="78562-270">The *deviceType* field in the [TargetingProfile](#targeting-profile) object contains one or more of the following integers that identify the device types of the users to target.</span></span>

|  <span data-ttu-id="78562-271">*deviceType* フィールドの整数値</span><span class="sxs-lookup"><span data-stu-id="78562-271">Integer value for *deviceType* field</span></span>  |  <span data-ttu-id="78562-272">対応するデバイスの種類</span><span class="sxs-lookup"><span data-stu-id="78562-272">Corresponding device type</span></span>  |  <span data-ttu-id="78562-273">説明</span><span class="sxs-lookup"><span data-stu-id="78562-273">Description</span></span>  |
|---------------------------------|---------------------------|---------------------------|
|     <span data-ttu-id="78562-274">710</span><span class="sxs-lookup"><span data-stu-id="78562-274">710</span></span>     |  <span data-ttu-id="78562-275">Windows</span><span class="sxs-lookup"><span data-stu-id="78562-275">Windows</span></span>   |  <span data-ttu-id="78562-276">これは、Windows 10 または Windows 8.x のデスクトップ バージョンを実行しているデバイスを表しています。</span><span class="sxs-lookup"><span data-stu-id="78562-276">This represents devices running a desktop version of Windows 10 or Windows 8.x.</span></span>  |
|     <span data-ttu-id="78562-277">711</span><span class="sxs-lookup"><span data-stu-id="78562-277">711</span></span>     |  <span data-ttu-id="78562-278">携帯電話</span><span class="sxs-lookup"><span data-stu-id="78562-278">Phone</span></span>     |  <span data-ttu-id="78562-279">これは、Windows 10 Mobile、Windows Phone 8.x、Windows Phone 7.x を実行しているデバイスを表しています。</span><span class="sxs-lookup"><span data-stu-id="78562-279">This represents devices running Windows 10 Mobile, Windows Phone 8.x, or Windows Phone 7.x.</span></span>

<span data-ttu-id="78562-280">*deviceType* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="78562-280">To get the supported values for the *deviceType* field programmatically, you can call the following GET method.</span></span>  <span data-ttu-id="78562-281">```Authorization``` ヘッダーでは、**Bearer** &lt;*トークン*&gt; の形式で Azure AD アクセス トークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="78562-281">For the ```Authorization``` header, pass your Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/devicetype
Authorization: Bearer <your access token>
```

<span data-ttu-id="78562-282">次の例は、このメソッドの応答本文を示します。</span><span class="sxs-lookup"><span data-stu-id="78562-282">The following example shows the response body for this method.</span></span>

```json
{
  "Data": {
    "DeviceType": {
      "710": "Windows",
      "711": "Phone"
    }
  }
}
```


<span id="supplytype-values"/>

### <a name="supply-type-values"></a><span data-ttu-id="78562-283">サプライの種類の値</span><span class="sxs-lookup"><span data-stu-id="78562-283">Supply type values</span></span>

<span data-ttu-id="78562-284">[TargetingProfile](#targeting-profile) オブジェクトの *supplyType* フィールドには、キャンペーンの広告が表示されるインベントリの種類を識別する次の整数が 1 つ以上含まれています。</span><span class="sxs-lookup"><span data-stu-id="78562-284">The *supplyType* field in the [TargetingProfile](#targeting-profile) object contains one or more of the following integers that identify the type of inventory where the campaign's ads will be shown.</span></span>

|  <span data-ttu-id="78562-285">*supplyType* フィールドの整数値</span><span class="sxs-lookup"><span data-stu-id="78562-285">Integer value for *supplyType* field</span></span>  |  <span data-ttu-id="78562-286">対応するサプライの種類</span><span class="sxs-lookup"><span data-stu-id="78562-286">Corresponding supply type</span></span>  |  <span data-ttu-id="78562-287">説明</span><span class="sxs-lookup"><span data-stu-id="78562-287">Description</span></span>  |
|---------------------------------|---------------------------|---------------------------|
|     <span data-ttu-id="78562-288">11470</span><span class="sxs-lookup"><span data-stu-id="78562-288">11470</span></span>     |  <span data-ttu-id="78562-289">アプリ</span><span class="sxs-lookup"><span data-stu-id="78562-289">App</span></span>        |  <span data-ttu-id="78562-290">これは、アプリにのみ表示される広告を示しています。</span><span class="sxs-lookup"><span data-stu-id="78562-290">This refers to ads that appear in apps only.</span></span>  |
|     <span data-ttu-id="78562-291">11471</span><span class="sxs-lookup"><span data-stu-id="78562-291">11471</span></span>     |  <span data-ttu-id="78562-292">ユニバーサル</span><span class="sxs-lookup"><span data-stu-id="78562-292">Universal</span></span>        |  <span data-ttu-id="78562-293">これは、アプリ、Web、および他のディスプレイ サーフェスに表示される広告を示しています。</span><span class="sxs-lookup"><span data-stu-id="78562-293">This refers to ads that appear in apps, on the Web, and on and other display surfaces.</span></span>  |

<span data-ttu-id="78562-294">*supplyType* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="78562-294">To get the supported values for the *supplyType* field programmatically, you can call the following GET method.</span></span>  <span data-ttu-id="78562-295">```Authorization``` ヘッダーでは、**Bearer** &lt;*トークン*&gt; の形式で Azure AD アクセス トークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="78562-295">For the ```Authorization``` header, pass your Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/supplytype
Authorization: Bearer <your access token>
```

<span data-ttu-id="78562-296">次の例は、このメソッドの応答本文を示します。</span><span class="sxs-lookup"><span data-stu-id="78562-296">The following example shows the response body for this method.</span></span>

```json
{
  "Data": {
    "SupplyType": {
      "11470": "App",
      "11471": "Universal"
    }
  }
}
```

<span id="country-code-values"/>

### <a name="country-code-values"></a><span data-ttu-id="78562-297">国コードの値</span><span class="sxs-lookup"><span data-stu-id="78562-297">Country code values</span></span>

<span data-ttu-id="78562-298">[TargetingProfile](#targeting-profile) オブジェクトの *country* フィールドには、対象とするユーザーの [ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) 国コードを識別する次の整数が 1 つ以上含まれています。</span><span class="sxs-lookup"><span data-stu-id="78562-298">The *country* field in the [TargetingProfile](#targeting-profile) object contains one or more of the following integers that identify the [ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country codes of the users to target.</span></span>

|  <span data-ttu-id="78562-299">*country* フィールドの整数値</span><span class="sxs-lookup"><span data-stu-id="78562-299">Integer value for *country* field</span></span>  |  <span data-ttu-id="78562-300">対応する国コード</span><span class="sxs-lookup"><span data-stu-id="78562-300">Corresponding country code</span></span>  |  
|-------------------------------------|------------------------------|
|     <span data-ttu-id="78562-301">1</span><span class="sxs-lookup"><span data-stu-id="78562-301">1</span></span>      |            <span data-ttu-id="78562-302">US</span><span class="sxs-lookup"><span data-stu-id="78562-302">US</span></span>                  |
|     <span data-ttu-id="78562-303">2</span><span class="sxs-lookup"><span data-stu-id="78562-303">2</span></span>      |            <span data-ttu-id="78562-304">AU</span><span class="sxs-lookup"><span data-stu-id="78562-304">AU</span></span>                  |
|     <span data-ttu-id="78562-305">3</span><span class="sxs-lookup"><span data-stu-id="78562-305">3</span></span>      |            <span data-ttu-id="78562-306">AT</span><span class="sxs-lookup"><span data-stu-id="78562-306">AT</span></span>                  |
|     <span data-ttu-id="78562-307">4</span><span class="sxs-lookup"><span data-stu-id="78562-307">4</span></span>      |            <span data-ttu-id="78562-308">BE</span><span class="sxs-lookup"><span data-stu-id="78562-308">BE</span></span>                  |
|     <span data-ttu-id="78562-309">5</span><span class="sxs-lookup"><span data-stu-id="78562-309">5</span></span>      |            <span data-ttu-id="78562-310">BR</span><span class="sxs-lookup"><span data-stu-id="78562-310">BR</span></span>                  |
|     <span data-ttu-id="78562-311">6</span><span class="sxs-lookup"><span data-stu-id="78562-311">6</span></span>      |            <span data-ttu-id="78562-312">CA</span><span class="sxs-lookup"><span data-stu-id="78562-312">CA</span></span>                  |
|     <span data-ttu-id="78562-313">7</span><span class="sxs-lookup"><span data-stu-id="78562-313">7</span></span>      |            <span data-ttu-id="78562-314">DK</span><span class="sxs-lookup"><span data-stu-id="78562-314">DK</span></span>                  |
|     <span data-ttu-id="78562-315">8</span><span class="sxs-lookup"><span data-stu-id="78562-315">8</span></span>      |            <span data-ttu-id="78562-316">FI</span><span class="sxs-lookup"><span data-stu-id="78562-316">FI</span></span>                  |
|     <span data-ttu-id="78562-317">9</span><span class="sxs-lookup"><span data-stu-id="78562-317">9</span></span>      |            <span data-ttu-id="78562-318">FR</span><span class="sxs-lookup"><span data-stu-id="78562-318">FR</span></span>                  |
|     <span data-ttu-id="78562-319">10</span><span class="sxs-lookup"><span data-stu-id="78562-319">10</span></span>      |            <span data-ttu-id="78562-320">DE</span><span class="sxs-lookup"><span data-stu-id="78562-320">DE</span></span>                  |
|     <span data-ttu-id="78562-321">11</span><span class="sxs-lookup"><span data-stu-id="78562-321">11</span></span>      |            <span data-ttu-id="78562-322">GR</span><span class="sxs-lookup"><span data-stu-id="78562-322">GR</span></span>                  |
|     <span data-ttu-id="78562-323">12</span><span class="sxs-lookup"><span data-stu-id="78562-323">12</span></span>      |            <span data-ttu-id="78562-324">HK</span><span class="sxs-lookup"><span data-stu-id="78562-324">HK</span></span>                  |
|     <span data-ttu-id="78562-325">13</span><span class="sxs-lookup"><span data-stu-id="78562-325">13</span></span>      |            <span data-ttu-id="78562-326">IN</span><span class="sxs-lookup"><span data-stu-id="78562-326">IN</span></span>                  |
|     <span data-ttu-id="78562-327">14</span><span class="sxs-lookup"><span data-stu-id="78562-327">14</span></span>      |            <span data-ttu-id="78562-328">IE</span><span class="sxs-lookup"><span data-stu-id="78562-328">IE</span></span>                  |
|     <span data-ttu-id="78562-329">15</span><span class="sxs-lookup"><span data-stu-id="78562-329">15</span></span>      |            <span data-ttu-id="78562-330">IT</span><span class="sxs-lookup"><span data-stu-id="78562-330">IT</span></span>                  |
|     <span data-ttu-id="78562-331">16</span><span class="sxs-lookup"><span data-stu-id="78562-331">16</span></span>      |            <span data-ttu-id="78562-332">JP</span><span class="sxs-lookup"><span data-stu-id="78562-332">JP</span></span>                  |
|     <span data-ttu-id="78562-333">17</span><span class="sxs-lookup"><span data-stu-id="78562-333">17</span></span>      |            <span data-ttu-id="78562-334">LU</span><span class="sxs-lookup"><span data-stu-id="78562-334">LU</span></span>                  |
|     <span data-ttu-id="78562-335">18</span><span class="sxs-lookup"><span data-stu-id="78562-335">18</span></span>      |            <span data-ttu-id="78562-336">MX</span><span class="sxs-lookup"><span data-stu-id="78562-336">MX</span></span>                  |
|     <span data-ttu-id="78562-337">19</span><span class="sxs-lookup"><span data-stu-id="78562-337">19</span></span>      |            <span data-ttu-id="78562-338">NL</span><span class="sxs-lookup"><span data-stu-id="78562-338">NL</span></span>                  |
|     <span data-ttu-id="78562-339">20</span><span class="sxs-lookup"><span data-stu-id="78562-339">20</span></span>      |            <span data-ttu-id="78562-340">NZ</span><span class="sxs-lookup"><span data-stu-id="78562-340">NZ</span></span>                  |
|     <span data-ttu-id="78562-341">21</span><span class="sxs-lookup"><span data-stu-id="78562-341">21</span></span>      |            <span data-ttu-id="78562-342">NO</span><span class="sxs-lookup"><span data-stu-id="78562-342">NO</span></span>                  |
|     <span data-ttu-id="78562-343">22</span><span class="sxs-lookup"><span data-stu-id="78562-343">22</span></span>      |            <span data-ttu-id="78562-344">PL</span><span class="sxs-lookup"><span data-stu-id="78562-344">PL</span></span>                  |
|     <span data-ttu-id="78562-345">23</span><span class="sxs-lookup"><span data-stu-id="78562-345">23</span></span>      |            <span data-ttu-id="78562-346">PT</span><span class="sxs-lookup"><span data-stu-id="78562-346">PT</span></span>                  |
|     <span data-ttu-id="78562-347">24</span><span class="sxs-lookup"><span data-stu-id="78562-347">24</span></span>      |            <span data-ttu-id="78562-348">SG</span><span class="sxs-lookup"><span data-stu-id="78562-348">SG</span></span>                  |
|     <span data-ttu-id="78562-349">25</span><span class="sxs-lookup"><span data-stu-id="78562-349">25</span></span>      |            <span data-ttu-id="78562-350">ES</span><span class="sxs-lookup"><span data-stu-id="78562-350">ES</span></span>                  |
|     <span data-ttu-id="78562-351">26</span><span class="sxs-lookup"><span data-stu-id="78562-351">26</span></span>      |            <span data-ttu-id="78562-352">SE</span><span class="sxs-lookup"><span data-stu-id="78562-352">SE</span></span>                  |
|     <span data-ttu-id="78562-353">27</span><span class="sxs-lookup"><span data-stu-id="78562-353">27</span></span>      |            <span data-ttu-id="78562-354">CH</span><span class="sxs-lookup"><span data-stu-id="78562-354">CH</span></span>                  |
|     <span data-ttu-id="78562-355">28</span><span class="sxs-lookup"><span data-stu-id="78562-355">28</span></span>      |            <span data-ttu-id="78562-356">TW</span><span class="sxs-lookup"><span data-stu-id="78562-356">TW</span></span>                  |
|     <span data-ttu-id="78562-357">29</span><span class="sxs-lookup"><span data-stu-id="78562-357">29</span></span>      |            <span data-ttu-id="78562-358">GB</span><span class="sxs-lookup"><span data-stu-id="78562-358">GB</span></span>                  |
|     <span data-ttu-id="78562-359">30</span><span class="sxs-lookup"><span data-stu-id="78562-359">30</span></span>      |            <span data-ttu-id="78562-360">RU</span><span class="sxs-lookup"><span data-stu-id="78562-360">RU</span></span>                  |
|     <span data-ttu-id="78562-361">31</span><span class="sxs-lookup"><span data-stu-id="78562-361">31</span></span>      |            <span data-ttu-id="78562-362">CL</span><span class="sxs-lookup"><span data-stu-id="78562-362">CL</span></span>                  |
|     <span data-ttu-id="78562-363">32</span><span class="sxs-lookup"><span data-stu-id="78562-363">32</span></span>      |            <span data-ttu-id="78562-364">CO</span><span class="sxs-lookup"><span data-stu-id="78562-364">CO</span></span>                  |
|     <span data-ttu-id="78562-365">33</span><span class="sxs-lookup"><span data-stu-id="78562-365">33</span></span>      |            <span data-ttu-id="78562-366">CZ</span><span class="sxs-lookup"><span data-stu-id="78562-366">CZ</span></span>                  |
|     <span data-ttu-id="78562-367">34</span><span class="sxs-lookup"><span data-stu-id="78562-367">34</span></span>      |            <span data-ttu-id="78562-368">HU</span><span class="sxs-lookup"><span data-stu-id="78562-368">HU</span></span>                  |
|     <span data-ttu-id="78562-369">35</span><span class="sxs-lookup"><span data-stu-id="78562-369">35</span></span>      |            <span data-ttu-id="78562-370">ZA</span><span class="sxs-lookup"><span data-stu-id="78562-370">ZA</span></span>                  |
|     <span data-ttu-id="78562-371">36</span><span class="sxs-lookup"><span data-stu-id="78562-371">36</span></span>      |            <span data-ttu-id="78562-372">KR</span><span class="sxs-lookup"><span data-stu-id="78562-372">KR</span></span>                  |
|     <span data-ttu-id="78562-373">37</span><span class="sxs-lookup"><span data-stu-id="78562-373">37</span></span>      |            <span data-ttu-id="78562-374">CN</span><span class="sxs-lookup"><span data-stu-id="78562-374">CN</span></span>                  |
|     <span data-ttu-id="78562-375">38</span><span class="sxs-lookup"><span data-stu-id="78562-375">38</span></span>      |            <span data-ttu-id="78562-376">RO</span><span class="sxs-lookup"><span data-stu-id="78562-376">RO</span></span>                  |
|     <span data-ttu-id="78562-377">39</span><span class="sxs-lookup"><span data-stu-id="78562-377">39</span></span>      |            <span data-ttu-id="78562-378">TR</span><span class="sxs-lookup"><span data-stu-id="78562-378">TR</span></span>                  |
|     <span data-ttu-id="78562-379">40</span><span class="sxs-lookup"><span data-stu-id="78562-379">40</span></span>      |            <span data-ttu-id="78562-380">SK</span><span class="sxs-lookup"><span data-stu-id="78562-380">SK</span></span>                  |
|     <span data-ttu-id="78562-381">41</span><span class="sxs-lookup"><span data-stu-id="78562-381">41</span></span>      |            <span data-ttu-id="78562-382">IL</span><span class="sxs-lookup"><span data-stu-id="78562-382">IL</span></span>                  |
|     <span data-ttu-id="78562-383">42</span><span class="sxs-lookup"><span data-stu-id="78562-383">42</span></span>      |            <span data-ttu-id="78562-384">ID</span><span class="sxs-lookup"><span data-stu-id="78562-384">ID</span></span>                  |
|     <span data-ttu-id="78562-385">43</span><span class="sxs-lookup"><span data-stu-id="78562-385">43</span></span>      |            <span data-ttu-id="78562-386">AR</span><span class="sxs-lookup"><span data-stu-id="78562-386">AR</span></span>                  |
|     <span data-ttu-id="78562-387">44</span><span class="sxs-lookup"><span data-stu-id="78562-387">44</span></span>      |            <span data-ttu-id="78562-388">MY</span><span class="sxs-lookup"><span data-stu-id="78562-388">MY</span></span>                  |
|     <span data-ttu-id="78562-389">45</span><span class="sxs-lookup"><span data-stu-id="78562-389">45</span></span>      |            <span data-ttu-id="78562-390">PH</span><span class="sxs-lookup"><span data-stu-id="78562-390">PH</span></span>                  |
|     <span data-ttu-id="78562-391">46</span><span class="sxs-lookup"><span data-stu-id="78562-391">46</span></span>      |            <span data-ttu-id="78562-392">PE</span><span class="sxs-lookup"><span data-stu-id="78562-392">PE</span></span>                  |
|     <span data-ttu-id="78562-393">47</span><span class="sxs-lookup"><span data-stu-id="78562-393">47</span></span>      |            <span data-ttu-id="78562-394">UA</span><span class="sxs-lookup"><span data-stu-id="78562-394">UA</span></span>                  |
|     <span data-ttu-id="78562-395">48</span><span class="sxs-lookup"><span data-stu-id="78562-395">48</span></span>      |            <span data-ttu-id="78562-396">AE</span><span class="sxs-lookup"><span data-stu-id="78562-396">AE</span></span>                  |
|     <span data-ttu-id="78562-397">49</span><span class="sxs-lookup"><span data-stu-id="78562-397">49</span></span>      |            <span data-ttu-id="78562-398">TH</span><span class="sxs-lookup"><span data-stu-id="78562-398">TH</span></span>                  |
|     <span data-ttu-id="78562-399">50</span><span class="sxs-lookup"><span data-stu-id="78562-399">50</span></span>      |            <span data-ttu-id="78562-400">IQ</span><span class="sxs-lookup"><span data-stu-id="78562-400">IQ</span></span>                  |
|     <span data-ttu-id="78562-401">51</span><span class="sxs-lookup"><span data-stu-id="78562-401">51</span></span>      |            <span data-ttu-id="78562-402">VN</span><span class="sxs-lookup"><span data-stu-id="78562-402">VN</span></span>                  |
|     <span data-ttu-id="78562-403">52</span><span class="sxs-lookup"><span data-stu-id="78562-403">52</span></span>      |            <span data-ttu-id="78562-404">CR</span><span class="sxs-lookup"><span data-stu-id="78562-404">CR</span></span>                  |
|     <span data-ttu-id="78562-405">53</span><span class="sxs-lookup"><span data-stu-id="78562-405">53</span></span>      |            <span data-ttu-id="78562-406">VE</span><span class="sxs-lookup"><span data-stu-id="78562-406">VE</span></span>                  |
|     <span data-ttu-id="78562-407">54</span><span class="sxs-lookup"><span data-stu-id="78562-407">54</span></span>      |            <span data-ttu-id="78562-408">QA</span><span class="sxs-lookup"><span data-stu-id="78562-408">QA</span></span>                  |
|     <span data-ttu-id="78562-409">55</span><span class="sxs-lookup"><span data-stu-id="78562-409">55</span></span>      |            <span data-ttu-id="78562-410">SI</span><span class="sxs-lookup"><span data-stu-id="78562-410">SI</span></span>                  |
|     <span data-ttu-id="78562-411">56</span><span class="sxs-lookup"><span data-stu-id="78562-411">56</span></span>      |            <span data-ttu-id="78562-412">BG</span><span class="sxs-lookup"><span data-stu-id="78562-412">BG</span></span>                  |
|     <span data-ttu-id="78562-413">57</span><span class="sxs-lookup"><span data-stu-id="78562-413">57</span></span>      |            <span data-ttu-id="78562-414">LT</span><span class="sxs-lookup"><span data-stu-id="78562-414">LT</span></span>                  |
|     <span data-ttu-id="78562-415">58</span><span class="sxs-lookup"><span data-stu-id="78562-415">58</span></span>      |            <span data-ttu-id="78562-416">RS</span><span class="sxs-lookup"><span data-stu-id="78562-416">RS</span></span>                  |
|     <span data-ttu-id="78562-417">59</span><span class="sxs-lookup"><span data-stu-id="78562-417">59</span></span>      |            <span data-ttu-id="78562-418">HR</span><span class="sxs-lookup"><span data-stu-id="78562-418">HR</span></span>                  |
|     <span data-ttu-id="78562-419">60</span><span class="sxs-lookup"><span data-stu-id="78562-419">60</span></span>      |            <span data-ttu-id="78562-420">HR</span><span class="sxs-lookup"><span data-stu-id="78562-420">HR</span></span>                  |
|     <span data-ttu-id="78562-421">61</span><span class="sxs-lookup"><span data-stu-id="78562-421">61</span></span>      |            <span data-ttu-id="78562-422">LV</span><span class="sxs-lookup"><span data-stu-id="78562-422">LV</span></span>                  |
|     <span data-ttu-id="78562-423">62</span><span class="sxs-lookup"><span data-stu-id="78562-423">62</span></span>      |            <span data-ttu-id="78562-424">EE</span><span class="sxs-lookup"><span data-stu-id="78562-424">EE</span></span>                  |
|     <span data-ttu-id="78562-425">63</span><span class="sxs-lookup"><span data-stu-id="78562-425">63</span></span>      |            <span data-ttu-id="78562-426">IS</span><span class="sxs-lookup"><span data-stu-id="78562-426">IS</span></span>                  |
|     <span data-ttu-id="78562-427">64</span><span class="sxs-lookup"><span data-stu-id="78562-427">64</span></span>      |            <span data-ttu-id="78562-428">KZ</span><span class="sxs-lookup"><span data-stu-id="78562-428">KZ</span></span>                  |
|     <span data-ttu-id="78562-429">65</span><span class="sxs-lookup"><span data-stu-id="78562-429">65</span></span>      |            <span data-ttu-id="78562-430">SA</span><span class="sxs-lookup"><span data-stu-id="78562-430">SA</span></span>                  |
|     <span data-ttu-id="78562-431">67</span><span class="sxs-lookup"><span data-stu-id="78562-431">67</span></span>      |            <span data-ttu-id="78562-432">AL</span><span class="sxs-lookup"><span data-stu-id="78562-432">AL</span></span>                  |
|     <span data-ttu-id="78562-433">68</span><span class="sxs-lookup"><span data-stu-id="78562-433">68</span></span>      |            <span data-ttu-id="78562-434">DZ</span><span class="sxs-lookup"><span data-stu-id="78562-434">DZ</span></span>                  |
|     <span data-ttu-id="78562-435">70</span><span class="sxs-lookup"><span data-stu-id="78562-435">70</span></span>      |            <span data-ttu-id="78562-436">AO</span><span class="sxs-lookup"><span data-stu-id="78562-436">AO</span></span>                  |
|     <span data-ttu-id="78562-437">72</span><span class="sxs-lookup"><span data-stu-id="78562-437">72</span></span>      |            <span data-ttu-id="78562-438">AM</span><span class="sxs-lookup"><span data-stu-id="78562-438">AM</span></span>                  |
|     <span data-ttu-id="78562-439">73</span><span class="sxs-lookup"><span data-stu-id="78562-439">73</span></span>      |            <span data-ttu-id="78562-440">AZ</span><span class="sxs-lookup"><span data-stu-id="78562-440">AZ</span></span>                  |
|     <span data-ttu-id="78562-441">74</span><span class="sxs-lookup"><span data-stu-id="78562-441">74</span></span>      |            <span data-ttu-id="78562-442">BS</span><span class="sxs-lookup"><span data-stu-id="78562-442">BS</span></span>                  |
|     <span data-ttu-id="78562-443">75</span><span class="sxs-lookup"><span data-stu-id="78562-443">75</span></span>      |            <span data-ttu-id="78562-444">BD</span><span class="sxs-lookup"><span data-stu-id="78562-444">BD</span></span>                  |
|     <span data-ttu-id="78562-445">76</span><span class="sxs-lookup"><span data-stu-id="78562-445">76</span></span>      |            <span data-ttu-id="78562-446">BB</span><span class="sxs-lookup"><span data-stu-id="78562-446">BB</span></span>                  |
|     <span data-ttu-id="78562-447">77</span><span class="sxs-lookup"><span data-stu-id="78562-447">77</span></span>      |            <span data-ttu-id="78562-448">BY</span><span class="sxs-lookup"><span data-stu-id="78562-448">BY</span></span>                  |
|     <span data-ttu-id="78562-449">81</span><span class="sxs-lookup"><span data-stu-id="78562-449">81</span></span>      |            <span data-ttu-id="78562-450">BO</span><span class="sxs-lookup"><span data-stu-id="78562-450">BO</span></span>                  |
|     <span data-ttu-id="78562-451">82</span><span class="sxs-lookup"><span data-stu-id="78562-451">82</span></span>      |            <span data-ttu-id="78562-452">BA</span><span class="sxs-lookup"><span data-stu-id="78562-452">BA</span></span>                  |
|     <span data-ttu-id="78562-453">83</span><span class="sxs-lookup"><span data-stu-id="78562-453">83</span></span>      |            <span data-ttu-id="78562-454">BW</span><span class="sxs-lookup"><span data-stu-id="78562-454">BW</span></span>                  |
|     <span data-ttu-id="78562-455">87</span><span class="sxs-lookup"><span data-stu-id="78562-455">87</span></span>      |            <span data-ttu-id="78562-456">KH</span><span class="sxs-lookup"><span data-stu-id="78562-456">KH</span></span>                  |
|     <span data-ttu-id="78562-457">88</span><span class="sxs-lookup"><span data-stu-id="78562-457">88</span></span>      |            <span data-ttu-id="78562-458">CM</span><span class="sxs-lookup"><span data-stu-id="78562-458">CM</span></span>                  |
|     <span data-ttu-id="78562-459">94</span><span class="sxs-lookup"><span data-stu-id="78562-459">94</span></span>      |            <span data-ttu-id="78562-460">CD</span><span class="sxs-lookup"><span data-stu-id="78562-460">CD</span></span>                  |
|     <span data-ttu-id="78562-461">95</span><span class="sxs-lookup"><span data-stu-id="78562-461">95</span></span>      |            <span data-ttu-id="78562-462">CI</span><span class="sxs-lookup"><span data-stu-id="78562-462">CI</span></span>                  |
|     <span data-ttu-id="78562-463">96</span><span class="sxs-lookup"><span data-stu-id="78562-463">96</span></span>      |            <span data-ttu-id="78562-464">CY</span><span class="sxs-lookup"><span data-stu-id="78562-464">CY</span></span>                  |
|     <span data-ttu-id="78562-465">99</span><span class="sxs-lookup"><span data-stu-id="78562-465">99</span></span>      |            <span data-ttu-id="78562-466">DO</span><span class="sxs-lookup"><span data-stu-id="78562-466">DO</span></span>                  |
|     <span data-ttu-id="78562-467">100</span><span class="sxs-lookup"><span data-stu-id="78562-467">100</span></span>      |            <span data-ttu-id="78562-468">EC</span><span class="sxs-lookup"><span data-stu-id="78562-468">EC</span></span>                  |
|     <span data-ttu-id="78562-469">101</span><span class="sxs-lookup"><span data-stu-id="78562-469">101</span></span>      |            <span data-ttu-id="78562-470">EG</span><span class="sxs-lookup"><span data-stu-id="78562-470">EG</span></span>                  |
|     <span data-ttu-id="78562-471">102</span><span class="sxs-lookup"><span data-stu-id="78562-471">102</span></span>      |            <span data-ttu-id="78562-472">SV</span><span class="sxs-lookup"><span data-stu-id="78562-472">SV</span></span>                  |
|     <span data-ttu-id="78562-473">107</span><span class="sxs-lookup"><span data-stu-id="78562-473">107</span></span>      |            <span data-ttu-id="78562-474">FJ</span><span class="sxs-lookup"><span data-stu-id="78562-474">FJ</span></span>                  |
|     <span data-ttu-id="78562-475">108</span><span class="sxs-lookup"><span data-stu-id="78562-475">108</span></span>      |            <span data-ttu-id="78562-476">GA</span><span class="sxs-lookup"><span data-stu-id="78562-476">GA</span></span>                  |
|     <span data-ttu-id="78562-477">110</span><span class="sxs-lookup"><span data-stu-id="78562-477">110</span></span>      |            <span data-ttu-id="78562-478">GE</span><span class="sxs-lookup"><span data-stu-id="78562-478">GE</span></span>                  |
|     <span data-ttu-id="78562-479">111</span><span class="sxs-lookup"><span data-stu-id="78562-479">111</span></span>      |            <span data-ttu-id="78562-480">GH</span><span class="sxs-lookup"><span data-stu-id="78562-480">GH</span></span>                  |
|     <span data-ttu-id="78562-481">114</span><span class="sxs-lookup"><span data-stu-id="78562-481">114</span></span>      |            <span data-ttu-id="78562-482">GT</span><span class="sxs-lookup"><span data-stu-id="78562-482">GT</span></span>                  |
|     <span data-ttu-id="78562-483">118</span><span class="sxs-lookup"><span data-stu-id="78562-483">118</span></span>      |            <span data-ttu-id="78562-484">HT</span><span class="sxs-lookup"><span data-stu-id="78562-484">HT</span></span>                  |
|     <span data-ttu-id="78562-485">119</span><span class="sxs-lookup"><span data-stu-id="78562-485">119</span></span>      |            <span data-ttu-id="78562-486">HN</span><span class="sxs-lookup"><span data-stu-id="78562-486">HN</span></span>                  |
|     <span data-ttu-id="78562-487">120</span><span class="sxs-lookup"><span data-stu-id="78562-487">120</span></span>      |            <span data-ttu-id="78562-488">JM</span><span class="sxs-lookup"><span data-stu-id="78562-488">JM</span></span>                  |
|     <span data-ttu-id="78562-489">121</span><span class="sxs-lookup"><span data-stu-id="78562-489">121</span></span>      |            <span data-ttu-id="78562-490">JO</span><span class="sxs-lookup"><span data-stu-id="78562-490">JO</span></span>                  |
|     <span data-ttu-id="78562-491">122</span><span class="sxs-lookup"><span data-stu-id="78562-491">122</span></span>      |            <span data-ttu-id="78562-492">KE</span><span class="sxs-lookup"><span data-stu-id="78562-492">KE</span></span>                  |
|     <span data-ttu-id="78562-493">124</span><span class="sxs-lookup"><span data-stu-id="78562-493">124</span></span>      |            <span data-ttu-id="78562-494">KW</span><span class="sxs-lookup"><span data-stu-id="78562-494">KW</span></span>                  |
|     <span data-ttu-id="78562-495">125</span><span class="sxs-lookup"><span data-stu-id="78562-495">125</span></span>      |            <span data-ttu-id="78562-496">KG</span><span class="sxs-lookup"><span data-stu-id="78562-496">KG</span></span>                  |
|     <span data-ttu-id="78562-497">126</span><span class="sxs-lookup"><span data-stu-id="78562-497">126</span></span>      |            <span data-ttu-id="78562-498">LA</span><span class="sxs-lookup"><span data-stu-id="78562-498">LA</span></span>                  |
|     <span data-ttu-id="78562-499">127</span><span class="sxs-lookup"><span data-stu-id="78562-499">127</span></span>      |            <span data-ttu-id="78562-500">LB</span><span class="sxs-lookup"><span data-stu-id="78562-500">LB</span></span>                  |
|     <span data-ttu-id="78562-501">133</span><span class="sxs-lookup"><span data-stu-id="78562-501">133</span></span>      |            <span data-ttu-id="78562-502">MK</span><span class="sxs-lookup"><span data-stu-id="78562-502">MK</span></span>                  |
|     <span data-ttu-id="78562-503">135</span><span class="sxs-lookup"><span data-stu-id="78562-503">135</span></span>      |            <span data-ttu-id="78562-504">MW</span><span class="sxs-lookup"><span data-stu-id="78562-504">MW</span></span>                  |
|     <span data-ttu-id="78562-505">138</span><span class="sxs-lookup"><span data-stu-id="78562-505">138</span></span>      |            <span data-ttu-id="78562-506">MT</span><span class="sxs-lookup"><span data-stu-id="78562-506">MT</span></span>                  |
|     <span data-ttu-id="78562-507">141</span><span class="sxs-lookup"><span data-stu-id="78562-507">141</span></span>      |            <span data-ttu-id="78562-508">MU</span><span class="sxs-lookup"><span data-stu-id="78562-508">MU</span></span>                  |
|     <span data-ttu-id="78562-509">145</span><span class="sxs-lookup"><span data-stu-id="78562-509">145</span></span>      |            <span data-ttu-id="78562-510">ME</span><span class="sxs-lookup"><span data-stu-id="78562-510">ME</span></span>                  |
|     <span data-ttu-id="78562-511">146</span><span class="sxs-lookup"><span data-stu-id="78562-511">146</span></span>      |            <span data-ttu-id="78562-512">MA</span><span class="sxs-lookup"><span data-stu-id="78562-512">MA</span></span>                  |
|     <span data-ttu-id="78562-513">147</span><span class="sxs-lookup"><span data-stu-id="78562-513">147</span></span>      |            <span data-ttu-id="78562-514">MZ</span><span class="sxs-lookup"><span data-stu-id="78562-514">MZ</span></span>                  |
|     <span data-ttu-id="78562-515">148</span><span class="sxs-lookup"><span data-stu-id="78562-515">148</span></span>      |            <span data-ttu-id="78562-516">NA</span><span class="sxs-lookup"><span data-stu-id="78562-516">NA</span></span>                  |
|     <span data-ttu-id="78562-517">150</span><span class="sxs-lookup"><span data-stu-id="78562-517">150</span></span>      |            <span data-ttu-id="78562-518">NP</span><span class="sxs-lookup"><span data-stu-id="78562-518">NP</span></span>                  |
|     <span data-ttu-id="78562-519">151</span><span class="sxs-lookup"><span data-stu-id="78562-519">151</span></span>      |            <span data-ttu-id="78562-520">NI</span><span class="sxs-lookup"><span data-stu-id="78562-520">NI</span></span>                  |
|     <span data-ttu-id="78562-521">153</span><span class="sxs-lookup"><span data-stu-id="78562-521">153</span></span>      |            <span data-ttu-id="78562-522">NG</span><span class="sxs-lookup"><span data-stu-id="78562-522">NG</span></span>                  |
|     <span data-ttu-id="78562-523">154</span><span class="sxs-lookup"><span data-stu-id="78562-523">154</span></span>      |            <span data-ttu-id="78562-524">OM</span><span class="sxs-lookup"><span data-stu-id="78562-524">OM</span></span>                  |
|     <span data-ttu-id="78562-525">155</span><span class="sxs-lookup"><span data-stu-id="78562-525">155</span></span>      |            <span data-ttu-id="78562-526">PK</span><span class="sxs-lookup"><span data-stu-id="78562-526">PK</span></span>                  |
|     <span data-ttu-id="78562-527">157</span><span class="sxs-lookup"><span data-stu-id="78562-527">157</span></span>      |            <span data-ttu-id="78562-528">PA</span><span class="sxs-lookup"><span data-stu-id="78562-528">PA</span></span>                  |
|     <span data-ttu-id="78562-529">159</span><span class="sxs-lookup"><span data-stu-id="78562-529">159</span></span>      |            <span data-ttu-id="78562-530">PY</span><span class="sxs-lookup"><span data-stu-id="78562-530">PY</span></span>                  |
|     <span data-ttu-id="78562-531">167</span><span class="sxs-lookup"><span data-stu-id="78562-531">167</span></span>      |            <span data-ttu-id="78562-532">SN</span><span class="sxs-lookup"><span data-stu-id="78562-532">SN</span></span>                  |
|     <span data-ttu-id="78562-533">172</span><span class="sxs-lookup"><span data-stu-id="78562-533">172</span></span>      |            <span data-ttu-id="78562-534">LK</span><span class="sxs-lookup"><span data-stu-id="78562-534">LK</span></span>                  |
|     <span data-ttu-id="78562-535">176</span><span class="sxs-lookup"><span data-stu-id="78562-535">176</span></span>      |            <span data-ttu-id="78562-536">TZ</span><span class="sxs-lookup"><span data-stu-id="78562-536">TZ</span></span>                  |
|     <span data-ttu-id="78562-537">180</span><span class="sxs-lookup"><span data-stu-id="78562-537">180</span></span>      |            <span data-ttu-id="78562-538">TT</span><span class="sxs-lookup"><span data-stu-id="78562-538">TT</span></span>                  |
|     <span data-ttu-id="78562-539">181</span><span class="sxs-lookup"><span data-stu-id="78562-539">181</span></span>      |            <span data-ttu-id="78562-540">TN</span><span class="sxs-lookup"><span data-stu-id="78562-540">TN</span></span>                  |
|     <span data-ttu-id="78562-541">184</span><span class="sxs-lookup"><span data-stu-id="78562-541">184</span></span>      |            <span data-ttu-id="78562-542">UG</span><span class="sxs-lookup"><span data-stu-id="78562-542">UG</span></span>                  |
|     <span data-ttu-id="78562-543">185</span><span class="sxs-lookup"><span data-stu-id="78562-543">185</span></span>      |            <span data-ttu-id="78562-544">UY</span><span class="sxs-lookup"><span data-stu-id="78562-544">UY</span></span>                  |
|     <span data-ttu-id="78562-545">186</span><span class="sxs-lookup"><span data-stu-id="78562-545">186</span></span>      |            <span data-ttu-id="78562-546">UZ</span><span class="sxs-lookup"><span data-stu-id="78562-546">UZ</span></span>                  |
|     <span data-ttu-id="78562-547">189</span><span class="sxs-lookup"><span data-stu-id="78562-547">189</span></span>      |            <span data-ttu-id="78562-548">ZM</span><span class="sxs-lookup"><span data-stu-id="78562-548">ZM</span></span>                  |
|     <span data-ttu-id="78562-549">190</span><span class="sxs-lookup"><span data-stu-id="78562-549">190</span></span>      |            <span data-ttu-id="78562-550">ZW</span><span class="sxs-lookup"><span data-stu-id="78562-550">ZW</span></span>                  |
|     <span data-ttu-id="78562-551">219</span><span class="sxs-lookup"><span data-stu-id="78562-551">219</span></span>      |            <span data-ttu-id="78562-552">MD</span><span class="sxs-lookup"><span data-stu-id="78562-552">MD</span></span>                  |
|     <span data-ttu-id="78562-553">224</span><span class="sxs-lookup"><span data-stu-id="78562-553">224</span></span>      |            <span data-ttu-id="78562-554">PS</span><span class="sxs-lookup"><span data-stu-id="78562-554">PS</span></span>                  |
|     <span data-ttu-id="78562-555">225</span><span class="sxs-lookup"><span data-stu-id="78562-555">225</span></span>      |            <span data-ttu-id="78562-556">RE</span><span class="sxs-lookup"><span data-stu-id="78562-556">RE</span></span>                  |
|     <span data-ttu-id="78562-557">246</span><span class="sxs-lookup"><span data-stu-id="78562-557">246</span></span>      |            <span data-ttu-id="78562-558">PR</span><span class="sxs-lookup"><span data-stu-id="78562-558">PR</span></span>                  |

<span data-ttu-id="78562-559">*country* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="78562-559">To get the supported values for the *country* field programmatically, you can call the following GET method.</span></span>  <span data-ttu-id="78562-560">```Authorization``` ヘッダーでは、**Bearer** &lt;*トークン*&gt; の形式で Azure AD アクセス トークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="78562-560">For the ```Authorization``` header, pass your Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/country
Authorization: Bearer <your access token>
```

<span data-ttu-id="78562-561">次の例は、このメソッドの応答本文を示します。</span><span class="sxs-lookup"><span data-stu-id="78562-561">The following example shows the response body for this method.</span></span>

```json
{
  "Data": {
    "Country": {
      "1": "US",
      "2": "AU",
      "3": "AT",
      "4": "BE",
      "5": "BR",
      "6": "CA",
      "7": "DK",
      "8": "FI",
      "9": "FR",
      "10": "DE",
      "11": "GR",
      "12": "HK",
      "13": "IN",
      "14": "IE",
      "15": "IT",
      "16": "JP",
      "17": "LU",
      "18": "MX",
      "19": "NL",
      "20": "NZ",
      "21": "NO",
      "22": "PL",
      "23": "PT",
      "24": "SG",
      "25": "ES",
      "26": "SE",
      "27": "CH",
      "28": "TW",
      "29": "GB",
      "30": "RU",
      "31": "CL",
      "32": "CO",
      "33": "CZ",
      "34": "HU",
      "35": "ZA",
      "36": "KR",
      "37": "CN",
      "38": "RO",
      "39": "TR",
      "40": "SK",
      "41": "IL",
      "42": "ID",
      "43": "AR",
      "44": "MY",
      "45": "PH",
      "46": "PE",
      "47": "UA",
      "48": "AE",
      "49": "TH",
      "50": "IQ",
      "51": "VN",
      "52": "CR",
      "53": "VE",
      "54": "QA",
      "55": "SI",
      "56": "BG",
      "57": "LT",
      "58": "RS",
      "59": "HR",
      "60": "BH",
      "61": "LV",
      "62": "EE",
      "63": "IS",
      "64": "KZ",
      "65": "SA",
      "67": "AL",
      "68": "DZ",
      "70": "AO",
      "72": "AM",
      "73": "AZ",
      "74": "BS",
      "75": "BD",
      "76": "BB",
      "77": "BY",
      "81": "BO",
      "82": "BA",
      "83": "BW",
      "87": "KH",
      "88": "CM",
      "94": "CD",
      "95": "CI",
      "96": "CY",
      "99": "DO",
      "100": "EC",
      "101": "EG",
      "102": "SV",
      "107": "FJ",
      "108": "GA",
      "110": "GE",
      "111": "GH",
      "114": "GT",
      "118": "HT",
      "119": "HN",
      "120": "JM",
      "121": "JO",
      "122": "KE",
      "124": "KW",
      "125": "KG",
      "126": "LA",
      "127": "LB",
      "133": "MK",
      "135": "MW",
      "138": "MT",
      "141": "MU",
      "145": "ME",
      "146": "MA",
      "147": "MZ",
      "148": "NA",
      "150": "NP",
      "151": "NI",
      "153": "NG",
      "154": "OM",
      "155": "PK",
      "157": "PA",
      "159": "PY",
      "167": "SN",
      "172": "LK",
      "176": "TZ",
      "180": "TT",
      "181": "TN",
      "184": "UG",
      "185": "UY",
      "186": "UZ",
      "189": "ZM",
      "190": "ZW",
      "219": "MD",
      "224": "PS",
      "225": "RE",
      "246": "PR"
    }
  }
}
```

## <a name="related-topics"></a><span data-ttu-id="78562-562">関連トピック</span><span class="sxs-lookup"><span data-stu-id="78562-562">Related topics</span></span>

* [<span data-ttu-id="78562-563">Microsoft Store サービスを使用した広告キャンペーンの実行</span><span class="sxs-lookup"><span data-stu-id="78562-563">Run ad campaigns using Microsoft Store Services</span></span>](run-ad-campaigns-using-windows-store-services.md)
* [<span data-ttu-id="78562-564">広告キャンペーンの管理</span><span class="sxs-lookup"><span data-stu-id="78562-564">Manage ad campaigns</span></span>](manage-ad-campaigns.md)
* [<span data-ttu-id="78562-565">広告キャンペーンの配信ラインの管理</span><span class="sxs-lookup"><span data-stu-id="78562-565">Manage delivery lines for ad campaigns</span></span>](manage-delivery-lines-for-ad-campaigns.md)
* [<span data-ttu-id="78562-566">広告キャンペーンのクリエイティブの管理</span><span class="sxs-lookup"><span data-stu-id="78562-566">Manage creatives for ad campaigns</span></span>](manage-creatives-for-ad-campaigns.md)
* [<span data-ttu-id="78562-567">広告キャンペーンのパフォーマンス データの取得</span><span class="sxs-lookup"><span data-stu-id="78562-567">Get ad campaign performance data</span></span>](get-ad-campaign-performance-data.md)
