---
title: POST (/users/xuid({xuid})/devices/current/titles/current)
assetID: d5e2d12d-ba75-2d04-2805-c69a4c143f73
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentpost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/devices/current/titles/current)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ac24fb580696f1524ce7a6cf09dc1e492e9d2378
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4384672"
---
# <a name="post-usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="bdee4-104">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="bdee4-104">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>
<span data-ttu-id="bdee4-105">ユーザーのプレゼンスでは、タイトルを更新します。</span><span class="sxs-lookup"><span data-stu-id="bdee4-105">Update a title with a user's presence.</span></span> <span data-ttu-id="bdee4-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="bdee4-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="bdee4-107">注釈</span><span class="sxs-lookup"><span data-stu-id="bdee4-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="bdee4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bdee4-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="bdee4-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="bdee4-109">Authorization</span></span>](#ID4EPB)
  * [<span data-ttu-id="bdee4-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bdee4-110">Required Request Headers</span></span>](#ID4ENE)
  * [<span data-ttu-id="bdee4-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bdee4-111">Optional Request Headers</span></span>](#ID4ERG)
  * [<span data-ttu-id="bdee4-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="bdee4-112">Request body</span></span>](#ID4ERH)
  * [<span data-ttu-id="bdee4-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="bdee4-113">Response body</span></span>](#ID4EKAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="bdee4-114">注釈</span><span class="sxs-lookup"><span data-stu-id="bdee4-114">Remarks</span></span>
 
<span data-ttu-id="bdee4-115">この URI は、追加およびプレゼンス、リッチ プレゼンス、およびタイトルのメディアのプレゼンス データを更新するコンソール以外のプラットフォームですべてのタイトルで使用できます。</span><span class="sxs-lookup"><span data-stu-id="bdee4-115">This URI can be used by all titles on non-console platforms to add and update the presence, rich presence, and media presence data for a title.</span></span>
 
<span data-ttu-id="bdee4-116">**SandboxId**は今すぐ、XToken で要求から取得され、適用されます。</span><span class="sxs-lookup"><span data-stu-id="bdee4-116">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="bdee4-117">**SandboxId**が存在しない場合は、エンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。</span><span class="sxs-lookup"><span data-stu-id="bdee4-117">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bdee4-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bdee4-118">URI parameters</span></span>
 
| <span data-ttu-id="bdee4-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bdee4-119">Parameter</span></span>| <span data-ttu-id="bdee4-120">型</span><span class="sxs-lookup"><span data-stu-id="bdee4-120">Type</span></span>| <span data-ttu-id="bdee4-121">説明</span><span class="sxs-lookup"><span data-stu-id="bdee4-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bdee4-122">xuid</span><span class="sxs-lookup"><span data-stu-id="bdee4-122">xuid</span></span>| <span data-ttu-id="bdee4-123">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bdee4-123">64-bit unsigned integer</span></span>| <span data-ttu-id="bdee4-124">Xbox ユーザー ID (XUID) 対象ユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="bdee4-124">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="authorization"></a><span data-ttu-id="bdee4-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="bdee4-125">Authorization</span></span>
 
| <span data-ttu-id="bdee4-126">型</span><span class="sxs-lookup"><span data-stu-id="bdee4-126">Type</span></span>| <span data-ttu-id="bdee4-127">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="bdee4-127">Required</span></span>| <span data-ttu-id="bdee4-128">説明</span><span class="sxs-lookup"><span data-stu-id="bdee4-128">Description</span></span>| <span data-ttu-id="bdee4-129">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="bdee4-129">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bdee4-130">XUID</span><span class="sxs-lookup"><span data-stu-id="bdee4-130">XUID</span></span>| <span data-ttu-id="bdee4-131">はい</span><span class="sxs-lookup"><span data-stu-id="bdee4-131">Yes</span></span>| <span data-ttu-id="bdee4-132">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="bdee4-132">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="bdee4-133">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="bdee4-133">403 Forbidden</span></span>| 
| <span data-ttu-id="bdee4-134">titleId</span><span class="sxs-lookup"><span data-stu-id="bdee4-134">titleId</span></span>| <span data-ttu-id="bdee4-135">はい</span><span class="sxs-lookup"><span data-stu-id="bdee4-135">Yes</span></span>| <span data-ttu-id="bdee4-136">タイトルの titleId</span><span class="sxs-lookup"><span data-stu-id="bdee4-136">titleId of the title</span></span>| <span data-ttu-id="bdee4-137">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="bdee4-137">403 Forbidden</span></span>| 
| <span data-ttu-id="bdee4-138">deviceId</span><span class="sxs-lookup"><span data-stu-id="bdee4-138">deviceId</span></span>| <span data-ttu-id="bdee4-139">Windows と Web 以外のすべての [はい] します。</span><span class="sxs-lookup"><span data-stu-id="bdee4-139">Yes for all except Windows and Web</span></span>| <span data-ttu-id="bdee4-140">呼び出し元の deviceId</span><span class="sxs-lookup"><span data-stu-id="bdee4-140">deviceId of the caller</span></span>| <span data-ttu-id="bdee4-141">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="bdee4-141">403 Forbidden</span></span>| 
| <span data-ttu-id="bdee4-142">deviceType</span><span class="sxs-lookup"><span data-stu-id="bdee4-142">deviceType</span></span>| <span data-ttu-id="bdee4-143">Web 以外のすべての [はい]</span><span class="sxs-lookup"><span data-stu-id="bdee4-143">Yes for all except Web</span></span>| <span data-ttu-id="bdee4-144">呼び出し元の deviceType</span><span class="sxs-lookup"><span data-stu-id="bdee4-144">deviceType of the caller</span></span>| <span data-ttu-id="bdee4-145">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="bdee4-145">403 Forbidden</span></span>| 
| <span data-ttu-id="bdee4-146">sandboxId</span><span class="sxs-lookup"><span data-stu-id="bdee4-146">sandboxId</span></span>| <span data-ttu-id="bdee4-147">[はい] からの呼び出し</span><span class="sxs-lookup"><span data-stu-id="bdee4-147">Yes for calls coming from</span></span> | <span data-ttu-id="bdee4-148">呼び出し元のサンド ボックス</span><span class="sxs-lookup"><span data-stu-id="bdee4-148">sandbox of the caller</span></span>| <span data-ttu-id="bdee4-149">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="bdee4-149">403 Forbidden</span></span>| 
  
<a id="ID4ENE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="bdee4-150">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bdee4-150">Required Request Headers</span></span>
 
| <span data-ttu-id="bdee4-151">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bdee4-151">Header</span></span>| <span data-ttu-id="bdee4-152">型</span><span class="sxs-lookup"><span data-stu-id="bdee4-152">Type</span></span>| <span data-ttu-id="bdee4-153">説明</span><span class="sxs-lookup"><span data-stu-id="bdee4-153">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bdee4-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="bdee4-154">Authorization</span></span>| <span data-ttu-id="bdee4-155">string</span><span class="sxs-lookup"><span data-stu-id="bdee4-155">string</span></span>| <span data-ttu-id="bdee4-156">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="bdee4-156">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="bdee4-157">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。</span><span class="sxs-lookup"><span data-stu-id="bdee4-157">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="bdee4-158">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="bdee4-158">x-xbl-contract-version</span></span>| <span data-ttu-id="bdee4-159">string</span><span class="sxs-lookup"><span data-stu-id="bdee4-159">string</span></span>| <span data-ttu-id="bdee4-160">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="bdee4-160">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="bdee4-161">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="bdee4-161">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="bdee4-162">値の例: 3、vnext します。</span><span class="sxs-lookup"><span data-stu-id="bdee4-162">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="bdee4-163">Content-Type</span><span class="sxs-lookup"><span data-stu-id="bdee4-163">Content-Type</span></span>| <span data-ttu-id="bdee4-164">string</span><span class="sxs-lookup"><span data-stu-id="bdee4-164">string</span></span>| <span data-ttu-id="bdee4-165">値の例の要求の本文の mime タイプ: アプリケーション/json します。</span><span class="sxs-lookup"><span data-stu-id="bdee4-165">The mime type of the body of the request Example value: application/json.</span></span>| 
| <span data-ttu-id="bdee4-166">Content-Length</span><span class="sxs-lookup"><span data-stu-id="bdee4-166">Content-Length</span></span>| <span data-ttu-id="bdee4-167">string</span><span class="sxs-lookup"><span data-stu-id="bdee4-167">string</span></span>| <span data-ttu-id="bdee4-168">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="bdee4-168">The length of the request body.</span></span> <span data-ttu-id="bdee4-169">値の例: 312 します。</span><span class="sxs-lookup"><span data-stu-id="bdee4-169">Example value: 312.</span></span>| 
| <span data-ttu-id="bdee4-170">Host</span><span class="sxs-lookup"><span data-stu-id="bdee4-170">Host</span></span>| <span data-ttu-id="bdee4-171">string</span><span class="sxs-lookup"><span data-stu-id="bdee4-171">string</span></span>| <span data-ttu-id="bdee4-172">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="bdee4-172">Domain name of the server.</span></span> <span data-ttu-id="bdee4-173">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="bdee4-173">Example value: presencebeta.xboxlive.com.</span></span>| 
  
<a id="ID4ERG"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="bdee4-174">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bdee4-174">Optional Request Headers</span></span>
 
| <span data-ttu-id="bdee4-175">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bdee4-175">Header</span></span>| <span data-ttu-id="bdee4-176">型</span><span class="sxs-lookup"><span data-stu-id="bdee4-176">Type</span></span>| <span data-ttu-id="bdee4-177">説明</span><span class="sxs-lookup"><span data-stu-id="bdee4-177">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bdee4-178">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="bdee4-178">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="bdee4-179">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="bdee4-179">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="bdee4-180">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="bdee4-180">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="bdee4-181">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="bdee4-181">Default value: 1.</span></span>| 
  
<a id="ID4ERH"></a>

 
## <a name="request-body"></a><span data-ttu-id="bdee4-182">要求本文</span><span class="sxs-lookup"><span data-stu-id="bdee4-182">Request body</span></span>
 
<span data-ttu-id="bdee4-183">要求は、 [TitleRequest](../../json/json-titlerequest.md)です。</span><span class="sxs-lookup"><span data-stu-id="bdee4-183">The request object is a [TitleRequest](../../json/json-titlerequest.md).</span></span> <span data-ttu-id="bdee4-184">本体で実際に存在するプロパティのみが更新されます。</span><span class="sxs-lookup"><span data-stu-id="bdee4-184">Only the properties actually present in the body are updated.</span></span> <span data-ttu-id="bdee4-185">任意のプロパティは、本文の一部ではないが、上に存在するサーバーは変更されません。</span><span class="sxs-lookup"><span data-stu-id="bdee4-185">Any properties that are not part of the body but exist on the server will not be modified.</span></span>
 
<a id="ID4EAAAC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="bdee4-186">要求の例</span><span class="sxs-lookup"><span data-stu-id="bdee4-186">Sample request</span></span>
 

```cpp
{
  id:"12341234",
  placement:"snapped",
  state:"active"
}
      
```

   
<a id="ID4EKAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="bdee4-187">応答本文</span><span class="sxs-lookup"><span data-stu-id="bdee4-187">Response body</span></span>
 
<span data-ttu-id="bdee4-188">成功した場合、発生 200 または 201 Created の HTTP ステータス コードが返されますで適切なします。</span><span class="sxs-lookup"><span data-stu-id="bdee4-188">In case of success, an HTTP status code of 200 or 201 Created is returned, as appropriate.</span></span>
 
<span data-ttu-id="bdee4-189">エラー (HTTP 4 xx または 5 xx) の場合は、適切なエラー情報は、応答本文で返されます。</span><span class="sxs-lookup"><span data-stu-id="bdee4-189">In case of an error (HTTP 4xx or 5xx), appropriate error information is returned in the response body.</span></span>
  
<a id="ID4EVAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="bdee4-190">関連項目</span><span class="sxs-lookup"><span data-stu-id="bdee4-190">See also</span></span>
 
<a id="ID4EXAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bdee4-191">Parent</span><span class="sxs-lookup"><span data-stu-id="bdee4-191">Parent</span></span> 

[<span data-ttu-id="bdee4-192">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="bdee4-192">/users/xuid({xuid})/devices/current/titles/current</span></span>](uri-usersxuiddevicescurrenttitlescurrent.md)

  
<a id="ID4EBBAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="bdee4-193">詳細情報</span><span class="sxs-lookup"><span data-stu-id="bdee4-193">Further Information</span></span> 

[<span data-ttu-id="bdee4-194">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="bdee4-194">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

 [<span data-ttu-id="bdee4-195">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="bdee4-195">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   