---
author: Xansky
ms.assetid: c5246681-82c7-44df-87e1-a84a926e6496
description: プロモーション用の広告キャンペーンのクリエイティブを管理するには、Microsoft Store プロモーション API の以下のメソッドを使います。
title: クリエイティブの管理
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store プロモーション API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 838329101695c21abfb7ac89dd9c83330b7bd26b
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5440856"
---
# <a name="manage-creatives"></a><span data-ttu-id="1a1de-104">クリエイティブの管理</span><span class="sxs-lookup"><span data-stu-id="1a1de-104">Manage creatives</span></span>

<span data-ttu-id="1a1de-105">プロモーション用の広告キャンペーンで使う独自のカスタム クリエイティブをアップロードしたり、既存のクリエイティブを取得したりするには、Microsoft Store プロモーション API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="1a1de-105">Use these methods in the Microsoft Store promotions API to upload your own custom creatives to use in promotional ad campaigns or get an existing creative.</span></span> <span data-ttu-id="1a1de-106">クリエイティブは、常に同じアプリを表す場合は、同一の広告キャンペーンでなくても、1 つ以上の配信ラインに関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="1a1de-106">A creative may be associated with one or more delivery lines, even across ad campaigns, provided it always represents the same app.</span></span>

<span data-ttu-id="1a1de-107">クリエイティブと広告キャンペーン、配信ライン、ターゲット プロファイルとの関係について詳しくは、「[Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a1de-107">For more information about the relationship between creatives and ad campaigns, delivery lines, and targeting profiles, see [Run ad campaigns using Microsoft Store services](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api).</span></span>

> [!NOTE]
> <span data-ttu-id="1a1de-108">この API を使って独自のクリエイティブをアップロードする場合、クリエイティブの最大許容サイズは 40 KB です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-108">When using this API to upload your own creative, the maximum allowed size for your creative is 40 KB.</span></span> <span data-ttu-id="1a1de-109">これよりも大きいクリエイティブ ファイルを送信しても、この API からはエラーが返されず、キャンペーンは正しく作成されません。</span><span class="sxs-lookup"><span data-stu-id="1a1de-109">If you submit a creative file larger than this, this API will not return an error, but the campaign will not successfully be created.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="1a1de-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="1a1de-110">Prerequisites</span></span>

<span data-ttu-id="1a1de-111">これらのメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a1de-111">To use these methods, you need to first do the following:</span></span>

* <span data-ttu-id="1a1de-112">Microsoft Store プロモーション API に関するすべての[前提条件](run-ad-campaigns-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="1a1de-112">If you have not done so already, complete all the [prerequisites](run-ad-campaigns-using-windows-store-services.md#prerequisites) for the Microsoft Store promotions API.</span></span>
* <span data-ttu-id="1a1de-113">これらのメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="1a1de-113">[Obtain an Azure AD access token](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for these methods.</span></span> <span data-ttu-id="1a1de-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="1a1de-115">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="1a1de-115">After the token expires, you can obtain a new one.</span></span>


## <a name="request"></a><span data-ttu-id="1a1de-116">要求</span><span class="sxs-lookup"><span data-stu-id="1a1de-116">Request</span></span>

<span data-ttu-id="1a1de-117">これらのメソッドでは、次の URL が使用されます。</span><span class="sxs-lookup"><span data-stu-id="1a1de-117">These methods have the following URIs.</span></span>

| <span data-ttu-id="1a1de-118">メソッドの種類</span><span class="sxs-lookup"><span data-stu-id="1a1de-118">Method type</span></span> | <span data-ttu-id="1a1de-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="1a1de-119">Request URI</span></span>     |  <span data-ttu-id="1a1de-120">説明</span><span class="sxs-lookup"><span data-stu-id="1a1de-120">Description</span></span>  |
|--------|-----------------------------|---------------|
| <span data-ttu-id="1a1de-121">POST</span><span class="sxs-lookup"><span data-stu-id="1a1de-121">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/creative``` |  <span data-ttu-id="1a1de-122">新しいクリエイティブを作成します。</span><span class="sxs-lookup"><span data-stu-id="1a1de-122">Creates a new creative.</span></span>  |
| <span data-ttu-id="1a1de-123">GET</span><span class="sxs-lookup"><span data-stu-id="1a1de-123">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/creative/{creativeId}``` |  <span data-ttu-id="1a1de-124">*creativeId* で指定されたクリエイティブを取得します。</span><span class="sxs-lookup"><span data-stu-id="1a1de-124">Gets the creative specified by *creativeId*.</span></span>  |

> [!NOTE]
> <span data-ttu-id="1a1de-125">現在、この API は PUT メソッドをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="1a1de-125">This API currently does not support a PUT method.</span></span>


### <a name="header"></a><span data-ttu-id="1a1de-126">Header</span><span class="sxs-lookup"><span data-stu-id="1a1de-126">Header</span></span>

| <span data-ttu-id="1a1de-127">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1a1de-127">Header</span></span>        | <span data-ttu-id="1a1de-128">型</span><span class="sxs-lookup"><span data-stu-id="1a1de-128">Type</span></span>   | <span data-ttu-id="1a1de-129">説明</span><span class="sxs-lookup"><span data-stu-id="1a1de-129">Description</span></span>         |
|---------------|--------|---------------------|
| <span data-ttu-id="1a1de-130">Authorization</span><span class="sxs-lookup"><span data-stu-id="1a1de-130">Authorization</span></span> | <span data-ttu-id="1a1de-131">string</span><span class="sxs-lookup"><span data-stu-id="1a1de-131">string</span></span> | <span data-ttu-id="1a1de-132">必須。</span><span class="sxs-lookup"><span data-stu-id="1a1de-132">Required.</span></span> <span data-ttu-id="1a1de-133">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="1a1de-133">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |
| <span data-ttu-id="1a1de-134">追跡 ID</span><span class="sxs-lookup"><span data-stu-id="1a1de-134">Tracking ID</span></span>   | <span data-ttu-id="1a1de-135">GUID</span><span class="sxs-lookup"><span data-stu-id="1a1de-135">GUID</span></span>   | <span data-ttu-id="1a1de-136">省略可能。</span><span class="sxs-lookup"><span data-stu-id="1a1de-136">Optional.</span></span> <span data-ttu-id="1a1de-137">呼び出しフローを追跡する ID。</span><span class="sxs-lookup"><span data-stu-id="1a1de-137">An ID that tracks the call flow.</span></span>                                  |


### <a name="request-body"></a><span data-ttu-id="1a1de-138">要求本文</span><span class="sxs-lookup"><span data-stu-id="1a1de-138">Request body</span></span>

<span data-ttu-id="1a1de-139">POST メソッドには、[クリエイティブ](#creative) オブジェクトの必須フィールドを含む JSON 要求本文が必要です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-139">The POST method requires a JSON request body with the required fields of a [Creative](#creative) object.</span></span>


### <a name="request-examples"></a><span data-ttu-id="1a1de-140">要求の例</span><span class="sxs-lookup"><span data-stu-id="1a1de-140">Request examples</span></span>

<span data-ttu-id="1a1de-141">次の例は、POST メソッドを呼び出してクリエイティブを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1a1de-141">The following example demonstrates how to call the POST method to create a creative.</span></span> <span data-ttu-id="1a1de-142">この例では、簡潔にするために *content* 値が短縮されています。</span><span class="sxs-lookup"><span data-stu-id="1a1de-142">In this example, the *content* value has been shortened for brevity.</span></span>

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/promotion/creative HTTP/1.1
Authorization: Bearer <your access token>

{
  "name": "Contoso App Campaign - Creative 1",
  "content": "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAAQABAAD/2wBDAAgGB...other base64 data shortened for brevity...",
  "height": 80,
  "width": 480,
  "imageAttributes":
  {
    "imageExtension": "PNG"
  }
}
```

<span data-ttu-id="1a1de-143">次の例は、GET メソッドを呼び出してクリエイティブを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1a1de-143">The following example demonstrates how to call the GET method to retrieve a creative.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/creative/106851  HTTP/1.1
Authorization: Bearer <your access token>
```


## <a name="response"></a><span data-ttu-id="1a1de-144">応答</span><span class="sxs-lookup"><span data-stu-id="1a1de-144">Response</span></span>

<span data-ttu-id="1a1de-145">これらのメソッドは、作成または取得されたクリエイティブに関する情報を含む[クリエイティブ](#creative) オブジェクトを持つ JSON 応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="1a1de-145">These methods return a JSON response body with a [Creative](#creative) object that contains information about the creative that was created or retrieved.</span></span> <span data-ttu-id="1a1de-146">これらのメソッドの応答本文を次の例に示します。</span><span class="sxs-lookup"><span data-stu-id="1a1de-146">The following example demonstrates a response body for these methods.</span></span> <span data-ttu-id="1a1de-147">この例では、簡潔にするために *content* 値が短縮されています。</span><span class="sxs-lookup"><span data-stu-id="1a1de-147">In this example, the *content* value has been shortened for brevity.</span></span>

```json
{
    "Data": {
        "id": 106126,
        "name": "Contoso App Campaign - Creative 2",
        "content": "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAAQABAAD/2wBDAAgGB...other base64 data shortened for brevity...",
        "height": 50,
        "width": 300,
        "format": "Banner",
        "imageAttributes":
        {
          "imageExtension": "PNG"
        },
        "storeProductId": "9nblggh42cfd"
    }
}
```


<span id="creative"/>

## <a name="creative-object"></a><span data-ttu-id="1a1de-148">クリエイティブ オブジェクト</span><span class="sxs-lookup"><span data-stu-id="1a1de-148">Creative object</span></span>

<span data-ttu-id="1a1de-149">これらのメソッドの要求本文と応答本文には、次のフィールドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1a1de-149">The request and response bodies for these methods contain the following fields.</span></span> <span data-ttu-id="1a1de-150">この表は、読み取り専用のフィールド (つまり、PUT メソッドで変更できない) と POST メソッドの要求本文で必須のフィールドを示しています。</span><span class="sxs-lookup"><span data-stu-id="1a1de-150">This table shows which fields are read-only (meaning that they cannot be changed in the PUT method) and which fields are required in the request body for the POST method.</span></span>

| <span data-ttu-id="1a1de-151">フィールド</span><span class="sxs-lookup"><span data-stu-id="1a1de-151">Field</span></span>        | <span data-ttu-id="1a1de-152">型</span><span class="sxs-lookup"><span data-stu-id="1a1de-152">Type</span></span>   |  <span data-ttu-id="1a1de-153">説明</span><span class="sxs-lookup"><span data-stu-id="1a1de-153">Description</span></span>      |  <span data-ttu-id="1a1de-154">読み取り専用かどうか</span><span class="sxs-lookup"><span data-stu-id="1a1de-154">Read only</span></span>  | <span data-ttu-id="1a1de-155">既定値</span><span class="sxs-lookup"><span data-stu-id="1a1de-155">Default</span></span>  |  <span data-ttu-id="1a1de-156">POST に必須かどうか</span><span class="sxs-lookup"><span data-stu-id="1a1de-156">Required for POST</span></span> |  
|--------------|--------|---------------|------|-------------|------------|
|  <span data-ttu-id="1a1de-157">id</span><span class="sxs-lookup"><span data-stu-id="1a1de-157">id</span></span>   |  <span data-ttu-id="1a1de-158">整数</span><span class="sxs-lookup"><span data-stu-id="1a1de-158">integer</span></span>   |  <span data-ttu-id="1a1de-159">クリエイティブの ID です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-159">The ID of the creative.</span></span>     |   <span data-ttu-id="1a1de-160">○</span><span class="sxs-lookup"><span data-stu-id="1a1de-160">Yes</span></span>    |      |    <span data-ttu-id="1a1de-161">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-161">No</span></span>   |       
|  <span data-ttu-id="1a1de-162">name</span><span class="sxs-lookup"><span data-stu-id="1a1de-162">name</span></span>   |  <span data-ttu-id="1a1de-163">文字列</span><span class="sxs-lookup"><span data-stu-id="1a1de-163">string</span></span>   |   <span data-ttu-id="1a1de-164">クリエイティブの名前です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-164">The name of the creative.</span></span>    |    <span data-ttu-id="1a1de-165">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-165">No</span></span>   |      |  <span data-ttu-id="1a1de-166">○</span><span class="sxs-lookup"><span data-stu-id="1a1de-166">Yes</span></span>     |       
|  <span data-ttu-id="1a1de-167">content</span><span class="sxs-lookup"><span data-stu-id="1a1de-167">content</span></span>   |  <span data-ttu-id="1a1de-168">文字列</span><span class="sxs-lookup"><span data-stu-id="1a1de-168">string</span></span>   |  <span data-ttu-id="1a1de-169">クリエイティブ イメージのコンテンツです (Base64 でエンコードされた形式)。</span><span class="sxs-lookup"><span data-stu-id="1a1de-169">The content of the creative image, in Base64-encoded format.</span></span><br/><br/><span data-ttu-id="1a1de-170">**注**&nbsp;&nbsp;クリエイティブの最大許容サイズは 40 KB です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-170">**Note**&nbsp;&nbsp;The maximum allowed size for your creative is 40 KB.</span></span> <span data-ttu-id="1a1de-171">これよりも大きいクリエイティブ ファイルを送信しても、この API からはエラーが返されず、キャンペーンは正しく作成されません。</span><span class="sxs-lookup"><span data-stu-id="1a1de-171">If you submit a creative file larger than this, this API will not return an error, but the campaign will not successfully be created.</span></span>     |  <span data-ttu-id="1a1de-172">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-172">No</span></span>     |      |   <span data-ttu-id="1a1de-173">○</span><span class="sxs-lookup"><span data-stu-id="1a1de-173">Yes</span></span>    |       
|  <span data-ttu-id="1a1de-174">height</span><span class="sxs-lookup"><span data-stu-id="1a1de-174">height</span></span>   |  <span data-ttu-id="1a1de-175">整数</span><span class="sxs-lookup"><span data-stu-id="1a1de-175">integer</span></span>   |   <span data-ttu-id="1a1de-176">クリエイティブの高さです。</span><span class="sxs-lookup"><span data-stu-id="1a1de-176">The height of the creative.</span></span>    |    <span data-ttu-id="1a1de-177">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-177">No</span></span>    |      |   <span data-ttu-id="1a1de-178">○</span><span class="sxs-lookup"><span data-stu-id="1a1de-178">Yes</span></span>    |       
|  <span data-ttu-id="1a1de-179">width</span><span class="sxs-lookup"><span data-stu-id="1a1de-179">width</span></span>   |  <span data-ttu-id="1a1de-180">整数</span><span class="sxs-lookup"><span data-stu-id="1a1de-180">integer</span></span>   |  <span data-ttu-id="1a1de-181">クリエイティブの幅です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-181">The width of the creative.</span></span>     |  <span data-ttu-id="1a1de-182">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-182">No</span></span>    |     |    <span data-ttu-id="1a1de-183">○</span><span class="sxs-lookup"><span data-stu-id="1a1de-183">Yes</span></span>   |       
|  <span data-ttu-id="1a1de-184">landingUrl</span><span class="sxs-lookup"><span data-stu-id="1a1de-184">landingUrl</span></span>   |  <span data-ttu-id="1a1de-185">文字列</span><span class="sxs-lookup"><span data-stu-id="1a1de-185">string</span></span>   |  <span data-ttu-id="1a1de-186">Kochava、AppsFlyer、Tune などのキャンペーン追跡サービスを使用して、アプリのインストール分析を行う場合、POST メソッドを呼び出すときに、このフィールドの追跡 URL を割り当てます (このフィールドを指定する場合、値は有効な URI であることが必要です)。</span><span class="sxs-lookup"><span data-stu-id="1a1de-186">If you are using a campaign tracking service such as Kochava, AppsFlyer or Tune to measure install analytics for your app, assign your tracking URL in this field when you call the POST method (if specified, this value must be a valid URI).</span></span> <span data-ttu-id="1a1de-187">キャンペーン追跡サービスを使用していない場合、POST メソッドを呼び出すときには、この値を省略します (その場合、この URL は自動的に作成されます)。</span><span class="sxs-lookup"><span data-stu-id="1a1de-187">If you are not using a campaign tracking service, omit this value when you call the POST method (in this case, this URL will be created automatically).</span></span>   |  <span data-ttu-id="1a1de-188">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-188">No</span></span>    |     |   <span data-ttu-id="1a1de-189">○</span><span class="sxs-lookup"><span data-stu-id="1a1de-189">Yes</span></span>    |       
|  <span data-ttu-id="1a1de-190">format</span><span class="sxs-lookup"><span data-stu-id="1a1de-190">format</span></span>   |  <span data-ttu-id="1a1de-191">文字列</span><span class="sxs-lookup"><span data-stu-id="1a1de-191">string</span></span>   |   <span data-ttu-id="1a1de-192">広告形式です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-192">The ad format.</span></span> <span data-ttu-id="1a1de-193">現時点では、サポートされている唯一の値は **Banner** です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-193">Currently, the only supported value is **Banner**.</span></span>    |   <span data-ttu-id="1a1de-194">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-194">No</span></span>    |  <span data-ttu-id="1a1de-195">Banner</span><span class="sxs-lookup"><span data-stu-id="1a1de-195">Banner</span></span>   |  <span data-ttu-id="1a1de-196">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-196">No</span></span>     |       
|  <span data-ttu-id="1a1de-197">imageAttributes</span><span class="sxs-lookup"><span data-stu-id="1a1de-197">imageAttributes</span></span>   | [<span data-ttu-id="1a1de-198">ImageAttributes</span><span class="sxs-lookup"><span data-stu-id="1a1de-198">ImageAttributes</span></span>](#image-attributes)    |   <span data-ttu-id="1a1de-199">クリエイティブの属性を指定します。</span><span class="sxs-lookup"><span data-stu-id="1a1de-199">Provides attributes for the creative.</span></span>     |   <span data-ttu-id="1a1de-200">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-200">No</span></span>    |      |   <span data-ttu-id="1a1de-201">○</span><span class="sxs-lookup"><span data-stu-id="1a1de-201">Yes</span></span>    |       
|  <span data-ttu-id="1a1de-202">storeProductId</span><span class="sxs-lookup"><span data-stu-id="1a1de-202">storeProductId</span></span>   |  <span data-ttu-id="1a1de-203">文字列</span><span class="sxs-lookup"><span data-stu-id="1a1de-203">string</span></span>   |   <span data-ttu-id="1a1de-204">この広告キャンペーンが関連付けられているアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-204">The [Store ID](in-app-purchases-and-trials.md#store-ids) for the app that this ad campaign is associated with.</span></span> <span data-ttu-id="1a1de-205">製品のストア ID の例は、9nblggh42cfd です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-205">An example Store ID for a product is 9nblggh42cfd.</span></span>    |   <span data-ttu-id="1a1de-206">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-206">No</span></span>    |    |  <span data-ttu-id="1a1de-207">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-207">No</span></span>     |   |  


<span id="image-attributes"/>

## <a name="imageattributes-object"></a><span data-ttu-id="1a1de-208">ImageAttributes オブジェクト</span><span class="sxs-lookup"><span data-stu-id="1a1de-208">ImageAttributes object</span></span>

| <span data-ttu-id="1a1de-209">フィールド</span><span class="sxs-lookup"><span data-stu-id="1a1de-209">Field</span></span>        | <span data-ttu-id="1a1de-210">型</span><span class="sxs-lookup"><span data-stu-id="1a1de-210">Type</span></span>   |  <span data-ttu-id="1a1de-211">説明</span><span class="sxs-lookup"><span data-stu-id="1a1de-211">Description</span></span>      |  <span data-ttu-id="1a1de-212">読み取り専用かどうか</span><span class="sxs-lookup"><span data-stu-id="1a1de-212">Read-only</span></span>  | <span data-ttu-id="1a1de-213">既定値</span><span class="sxs-lookup"><span data-stu-id="1a1de-213">Default value</span></span>  | <span data-ttu-id="1a1de-214">POST に必須かどうか</span><span class="sxs-lookup"><span data-stu-id="1a1de-214">Required for POST</span></span> |  
|--------------|--------|---------------|------|-------------|------------|
|  <span data-ttu-id="1a1de-215">imageExtension</span><span class="sxs-lookup"><span data-stu-id="1a1de-215">imageExtension</span></span>   |   <span data-ttu-id="1a1de-216">文字列</span><span class="sxs-lookup"><span data-stu-id="1a1de-216">string</span></span>  |   <span data-ttu-id="1a1de-217">**PNG** または **JPG** のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="1a1de-217">One of the following values: **PNG** or **JPG**.</span></span>    |    <span data-ttu-id="1a1de-218">×</span><span class="sxs-lookup"><span data-stu-id="1a1de-218">No</span></span>   |      |   <span data-ttu-id="1a1de-219">○</span><span class="sxs-lookup"><span data-stu-id="1a1de-219">Yes</span></span>    |       |


## <a name="related-topics"></a><span data-ttu-id="1a1de-220">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1a1de-220">Related topics</span></span>

* [<span data-ttu-id="1a1de-221">Microsoft Store サービスを使用した広告キャンペーンの実行</span><span class="sxs-lookup"><span data-stu-id="1a1de-221">Run ad campaigns using Microsoft Store Services</span></span>](run-ad-campaigns-using-windows-store-services.md)
* [<span data-ttu-id="1a1de-222">広告キャンペーンの管理</span><span class="sxs-lookup"><span data-stu-id="1a1de-222">Manage ad campaigns</span></span>](manage-ad-campaigns.md)
* [<span data-ttu-id="1a1de-223">広告キャンペーンの配信ラインの管理</span><span class="sxs-lookup"><span data-stu-id="1a1de-223">Manage delivery lines for ad campaigns</span></span>](manage-delivery-lines-for-ad-campaigns.md)
* [<span data-ttu-id="1a1de-224">広告キャンペーンの対象プロファイルの管理</span><span class="sxs-lookup"><span data-stu-id="1a1de-224">Manage targeting profiles for ad campaigns</span></span>](manage-targeting-profiles-for-ad-campaigns.md)
* [<span data-ttu-id="1a1de-225">広告キャンペーンのパフォーマンス データの取得</span><span class="sxs-lookup"><span data-stu-id="1a1de-225">Get ad campaign performance data</span></span>](get-ad-campaign-performance-data.md)
