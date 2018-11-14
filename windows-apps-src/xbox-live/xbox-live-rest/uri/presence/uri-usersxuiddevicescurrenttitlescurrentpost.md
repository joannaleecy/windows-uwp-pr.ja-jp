---
title: POST (/users/xuid({xuid})/devices/current/titles/current)
assetID: d5e2d12d-ba75-2d04-2805-c69a4c143f73
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentpost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/devices/current/titles/current)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 31e04f1711d83679ac0b41c74c1c391b26bc7969
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6265786"
---
# <a name="post-usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="c2bea-104">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="c2bea-104">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>
<span data-ttu-id="c2bea-105">ユーザーのプレゼンスでは、タイトルを更新します。</span><span class="sxs-lookup"><span data-stu-id="c2bea-105">Update a title with a user's presence.</span></span> <span data-ttu-id="c2bea-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c2bea-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="c2bea-107">注釈</span><span class="sxs-lookup"><span data-stu-id="c2bea-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="c2bea-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c2bea-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="c2bea-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="c2bea-109">Authorization</span></span>](#ID4EPB)
  * [<span data-ttu-id="c2bea-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2bea-110">Required Request Headers</span></span>](#ID4ENE)
  * [<span data-ttu-id="c2bea-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2bea-111">Optional Request Headers</span></span>](#ID4ERG)
  * [<span data-ttu-id="c2bea-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="c2bea-112">Request body</span></span>](#ID4ERH)
  * [<span data-ttu-id="c2bea-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="c2bea-113">Response body</span></span>](#ID4EKAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="c2bea-114">注釈</span><span class="sxs-lookup"><span data-stu-id="c2bea-114">Remarks</span></span>
 
<span data-ttu-id="c2bea-115">この URI は、コンソール以外のプラットフォームでのすべてのタイトルを追加し、プレゼンス、リッチ プレゼンスは、タイトルのメディアのプレゼンス データを更新するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="c2bea-115">This URI can be used by all titles on non-console platforms to add and update the presence, rich presence, and media presence data for a title.</span></span>
 
<span data-ttu-id="c2bea-116">**SandboxId**はここで、XToken で要求から取得され、適用されます。</span><span class="sxs-lookup"><span data-stu-id="c2bea-116">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="c2bea-117">**SandboxId**が存在しない場合は、エンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。</span><span class="sxs-lookup"><span data-stu-id="c2bea-117">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c2bea-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c2bea-118">URI parameters</span></span>
 
| <span data-ttu-id="c2bea-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c2bea-119">Parameter</span></span>| <span data-ttu-id="c2bea-120">型</span><span class="sxs-lookup"><span data-stu-id="c2bea-120">Type</span></span>| <span data-ttu-id="c2bea-121">説明</span><span class="sxs-lookup"><span data-stu-id="c2bea-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c2bea-122">xuid</span><span class="sxs-lookup"><span data-stu-id="c2bea-122">xuid</span></span>| <span data-ttu-id="c2bea-123">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="c2bea-123">64-bit unsigned integer</span></span>| <span data-ttu-id="c2bea-124">Xbox ユーザー ID (XUID) 対象ユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="c2bea-124">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="authorization"></a><span data-ttu-id="c2bea-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="c2bea-125">Authorization</span></span>
 
| <span data-ttu-id="c2bea-126">型</span><span class="sxs-lookup"><span data-stu-id="c2bea-126">Type</span></span>| <span data-ttu-id="c2bea-127">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="c2bea-127">Required</span></span>| <span data-ttu-id="c2bea-128">説明</span><span class="sxs-lookup"><span data-stu-id="c2bea-128">Description</span></span>| <span data-ttu-id="c2bea-129">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="c2bea-129">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c2bea-130">XUID</span><span class="sxs-lookup"><span data-stu-id="c2bea-130">XUID</span></span>| <span data-ttu-id="c2bea-131">はい</span><span class="sxs-lookup"><span data-stu-id="c2bea-131">Yes</span></span>| <span data-ttu-id="c2bea-132">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="c2bea-132">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="c2bea-133">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="c2bea-133">403 Forbidden</span></span>| 
| <span data-ttu-id="c2bea-134">titleId</span><span class="sxs-lookup"><span data-stu-id="c2bea-134">titleId</span></span>| <span data-ttu-id="c2bea-135">はい</span><span class="sxs-lookup"><span data-stu-id="c2bea-135">Yes</span></span>| <span data-ttu-id="c2bea-136">タイトルの titleId</span><span class="sxs-lookup"><span data-stu-id="c2bea-136">titleId of the title</span></span>| <span data-ttu-id="c2bea-137">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="c2bea-137">403 Forbidden</span></span>| 
| <span data-ttu-id="c2bea-138">deviceId</span><span class="sxs-lookup"><span data-stu-id="c2bea-138">deviceId</span></span>| <span data-ttu-id="c2bea-139">Windows と Web 以外のすべての [はい] します。</span><span class="sxs-lookup"><span data-stu-id="c2bea-139">Yes for all except Windows and Web</span></span>| <span data-ttu-id="c2bea-140">呼び出し元の deviceId</span><span class="sxs-lookup"><span data-stu-id="c2bea-140">deviceId of the caller</span></span>| <span data-ttu-id="c2bea-141">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="c2bea-141">403 Forbidden</span></span>| 
| <span data-ttu-id="c2bea-142">deviceType</span><span class="sxs-lookup"><span data-stu-id="c2bea-142">deviceType</span></span>| <span data-ttu-id="c2bea-143">Web 以外のすべての [はい]</span><span class="sxs-lookup"><span data-stu-id="c2bea-143">Yes for all except Web</span></span>| <span data-ttu-id="c2bea-144">呼び出し元の deviceType</span><span class="sxs-lookup"><span data-stu-id="c2bea-144">deviceType of the caller</span></span>| <span data-ttu-id="c2bea-145">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="c2bea-145">403 Forbidden</span></span>| 
| <span data-ttu-id="c2bea-146">sandboxId</span><span class="sxs-lookup"><span data-stu-id="c2bea-146">sandboxId</span></span>| <span data-ttu-id="c2bea-147">呼び出しの [はい]</span><span class="sxs-lookup"><span data-stu-id="c2bea-147">Yes for calls coming from</span></span> | <span data-ttu-id="c2bea-148">呼び出し元のサンド ボックス</span><span class="sxs-lookup"><span data-stu-id="c2bea-148">sandbox of the caller</span></span>| <span data-ttu-id="c2bea-149">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="c2bea-149">403 Forbidden</span></span>| 
  
<a id="ID4ENE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="c2bea-150">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2bea-150">Required Request Headers</span></span>
 
| <span data-ttu-id="c2bea-151">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2bea-151">Header</span></span>| <span data-ttu-id="c2bea-152">型</span><span class="sxs-lookup"><span data-stu-id="c2bea-152">Type</span></span>| <span data-ttu-id="c2bea-153">説明</span><span class="sxs-lookup"><span data-stu-id="c2bea-153">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c2bea-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="c2bea-154">Authorization</span></span>| <span data-ttu-id="c2bea-155">string</span><span class="sxs-lookup"><span data-stu-id="c2bea-155">string</span></span>| <span data-ttu-id="c2bea-156">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="c2bea-156">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="c2bea-157">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="c2bea-157">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="c2bea-158">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="c2bea-158">x-xbl-contract-version</span></span>| <span data-ttu-id="c2bea-159">string</span><span class="sxs-lookup"><span data-stu-id="c2bea-159">string</span></span>| <span data-ttu-id="c2bea-160">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="c2bea-160">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="c2bea-161">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="c2bea-161">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="c2bea-162">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="c2bea-162">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="c2bea-163">Content-Type</span><span class="sxs-lookup"><span data-stu-id="c2bea-163">Content-Type</span></span>| <span data-ttu-id="c2bea-164">string</span><span class="sxs-lookup"><span data-stu-id="c2bea-164">string</span></span>| <span data-ttu-id="c2bea-165">値の例の要求の本文の mime タイプ: アプリケーション/json します。</span><span class="sxs-lookup"><span data-stu-id="c2bea-165">The mime type of the body of the request Example value: application/json.</span></span>| 
| <span data-ttu-id="c2bea-166">Content-Length</span><span class="sxs-lookup"><span data-stu-id="c2bea-166">Content-Length</span></span>| <span data-ttu-id="c2bea-167">string</span><span class="sxs-lookup"><span data-stu-id="c2bea-167">string</span></span>| <span data-ttu-id="c2bea-168">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="c2bea-168">The length of the request body.</span></span> <span data-ttu-id="c2bea-169">値の例: 312 します。</span><span class="sxs-lookup"><span data-stu-id="c2bea-169">Example value: 312.</span></span>| 
| <span data-ttu-id="c2bea-170">Host</span><span class="sxs-lookup"><span data-stu-id="c2bea-170">Host</span></span>| <span data-ttu-id="c2bea-171">string</span><span class="sxs-lookup"><span data-stu-id="c2bea-171">string</span></span>| <span data-ttu-id="c2bea-172">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="c2bea-172">Domain name of the server.</span></span> <span data-ttu-id="c2bea-173">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="c2bea-173">Example value: presencebeta.xboxlive.com.</span></span>| 
  
<a id="ID4ERG"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="c2bea-174">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2bea-174">Optional Request Headers</span></span>
 
| <span data-ttu-id="c2bea-175">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2bea-175">Header</span></span>| <span data-ttu-id="c2bea-176">型</span><span class="sxs-lookup"><span data-stu-id="c2bea-176">Type</span></span>| <span data-ttu-id="c2bea-177">説明</span><span class="sxs-lookup"><span data-stu-id="c2bea-177">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c2bea-178">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="c2bea-178">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="c2bea-179">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="c2bea-179">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="c2bea-180">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="c2bea-180">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="c2bea-181">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="c2bea-181">Default value: 1.</span></span>| 
  
<a id="ID4ERH"></a>

 
## <a name="request-body"></a><span data-ttu-id="c2bea-182">要求本文</span><span class="sxs-lookup"><span data-stu-id="c2bea-182">Request body</span></span>
 
<span data-ttu-id="c2bea-183">要求、 [TitleRequest](../../json/json-titlerequest.md)です。</span><span class="sxs-lookup"><span data-stu-id="c2bea-183">The request object is a [TitleRequest](../../json/json-titlerequest.md).</span></span> <span data-ttu-id="c2bea-184">本体で実際に存在するプロパティのみが更新されます。</span><span class="sxs-lookup"><span data-stu-id="c2bea-184">Only the properties actually present in the body are updated.</span></span> <span data-ttu-id="c2bea-185">任意のプロパティは、本文の一部ではないが、上に存在するサーバーは変更されません。</span><span class="sxs-lookup"><span data-stu-id="c2bea-185">Any properties that are not part of the body but exist on the server will not be modified.</span></span>
 
<a id="ID4EAAAC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="c2bea-186">要求の例</span><span class="sxs-lookup"><span data-stu-id="c2bea-186">Sample request</span></span>
 

```cpp
{
  id:"12341234",
  placement:"snapped",
  state:"active"
}
      
```

   
<a id="ID4EKAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="c2bea-187">応答本文</span><span class="sxs-lookup"><span data-stu-id="c2bea-187">Response body</span></span>
 
<span data-ttu-id="c2bea-188">成功した場合、発生 200 または 201 Created の HTTP ステータス コードが返されますで適切なします。</span><span class="sxs-lookup"><span data-stu-id="c2bea-188">In case of success, an HTTP status code of 200 or 201 Created is returned, as appropriate.</span></span>
 
<span data-ttu-id="c2bea-189">エラー (4 xx の HTTP または 5 xx) の場合は、適切なエラー情報は、応答本文で返されます。</span><span class="sxs-lookup"><span data-stu-id="c2bea-189">In case of an error (HTTP 4xx or 5xx), appropriate error information is returned in the response body.</span></span>
  
<a id="ID4EVAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c2bea-190">関連項目</span><span class="sxs-lookup"><span data-stu-id="c2bea-190">See also</span></span>
 
<a id="ID4EXAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c2bea-191">Parent</span><span class="sxs-lookup"><span data-stu-id="c2bea-191">Parent</span></span> 

[<span data-ttu-id="c2bea-192">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="c2bea-192">/users/xuid({xuid})/devices/current/titles/current</span></span>](uri-usersxuiddevicescurrenttitlescurrent.md)

  
<a id="ID4EBBAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="c2bea-193">詳細情報</span><span class="sxs-lookup"><span data-stu-id="c2bea-193">Further Information</span></span> 

[<span data-ttu-id="c2bea-194">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="c2bea-194">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

 [<span data-ttu-id="c2bea-195">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="c2bea-195">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   