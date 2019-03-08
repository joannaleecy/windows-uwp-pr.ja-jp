---
title: POST (/users/xuid({xuid})/devices/current/titles/current)
assetID: d5e2d12d-ba75-2d04-2805-c69a4c143f73
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentpost.html
description: " POST (/users/xuid({xuid})/devices/current/titles/current)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b29a0bc796712d7b7c44a1fe8512f99bf09eb4fc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57649527"
---
# <a name="post-usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="b46a9-104">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="b46a9-104">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>
<span data-ttu-id="b46a9-105">ユーザーのプレゼンスとタイトルを更新します。</span><span class="sxs-lookup"><span data-stu-id="b46a9-105">Update a title with a user's presence.</span></span> <span data-ttu-id="b46a9-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b46a9-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b46a9-107">注釈</span><span class="sxs-lookup"><span data-stu-id="b46a9-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="b46a9-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b46a9-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="b46a9-109">承認</span><span class="sxs-lookup"><span data-stu-id="b46a9-109">Authorization</span></span>](#ID4EPB)
  * [<span data-ttu-id="b46a9-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b46a9-110">Required Request Headers</span></span>](#ID4ENE)
  * [<span data-ttu-id="b46a9-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b46a9-111">Optional Request Headers</span></span>](#ID4ERG)
  * [<span data-ttu-id="b46a9-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="b46a9-112">Request body</span></span>](#ID4ERH)
  * [<span data-ttu-id="b46a9-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="b46a9-113">Response body</span></span>](#ID4EKAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="b46a9-114">注釈</span><span class="sxs-lookup"><span data-stu-id="b46a9-114">Remarks</span></span>
 
<span data-ttu-id="b46a9-115">この URI は、追加およびプレゼンス、機能豊富なプレゼンス、およびタイトルのメディアの状態データを更新するコンソール以外のプラットフォームでのすべてのタイトルで使用できます。</span><span class="sxs-lookup"><span data-stu-id="b46a9-115">This URI can be used by all titles on non-console platforms to add and update the presence, rich presence, and media presence data for a title.</span></span>
 
<span data-ttu-id="b46a9-116">**SandboxId**今すぐ、XToken 内の要求から取得され、適用します。</span><span class="sxs-lookup"><span data-stu-id="b46a9-116">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="b46a9-117">場合、 **SandboxId**エンターテイメント検出サービス (EDS) は 400 Bad request エラーをスローしが存在しません。</span><span class="sxs-lookup"><span data-stu-id="b46a9-117">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b46a9-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b46a9-118">URI parameters</span></span>
 
| <span data-ttu-id="b46a9-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b46a9-119">Parameter</span></span>| <span data-ttu-id="b46a9-120">種類</span><span class="sxs-lookup"><span data-stu-id="b46a9-120">Type</span></span>| <span data-ttu-id="b46a9-121">説明</span><span class="sxs-lookup"><span data-stu-id="b46a9-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b46a9-122">xuid</span><span class="sxs-lookup"><span data-stu-id="b46a9-122">xuid</span></span>| <span data-ttu-id="b46a9-123">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="b46a9-123">64-bit unsigned integer</span></span>| <span data-ttu-id="b46a9-124">Xbox ユーザー ID (XUID) の対象ユーザーです。</span><span class="sxs-lookup"><span data-stu-id="b46a9-124">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="authorization"></a><span data-ttu-id="b46a9-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="b46a9-125">Authorization</span></span>
 
| <span data-ttu-id="b46a9-126">種類</span><span class="sxs-lookup"><span data-stu-id="b46a9-126">Type</span></span>| <span data-ttu-id="b46a9-127">必須</span><span class="sxs-lookup"><span data-stu-id="b46a9-127">Required</span></span>| <span data-ttu-id="b46a9-128">説明</span><span class="sxs-lookup"><span data-stu-id="b46a9-128">Description</span></span>| <span data-ttu-id="b46a9-129">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="b46a9-129">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="b46a9-130">XUID</span><span class="sxs-lookup"><span data-stu-id="b46a9-130">XUID</span></span>| <span data-ttu-id="b46a9-131">〇</span><span class="sxs-lookup"><span data-stu-id="b46a9-131">Yes</span></span>| <span data-ttu-id="b46a9-132">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="b46a9-132">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="b46a9-133">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="b46a9-133">403 Forbidden</span></span>| 
| <span data-ttu-id="b46a9-134">titleId</span><span class="sxs-lookup"><span data-stu-id="b46a9-134">titleId</span></span>| <span data-ttu-id="b46a9-135">〇</span><span class="sxs-lookup"><span data-stu-id="b46a9-135">Yes</span></span>| <span data-ttu-id="b46a9-136">タイトルのタイトルの Id</span><span class="sxs-lookup"><span data-stu-id="b46a9-136">titleId of the title</span></span>| <span data-ttu-id="b46a9-137">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="b46a9-137">403 Forbidden</span></span>| 
| <span data-ttu-id="b46a9-138">deviceId</span><span class="sxs-lookup"><span data-stu-id="b46a9-138">deviceId</span></span>| <span data-ttu-id="b46a9-139">Windows と Web 以外のすべての場合ははい</span><span class="sxs-lookup"><span data-stu-id="b46a9-139">Yes for all except Windows and Web</span></span>| <span data-ttu-id="b46a9-140">呼び出し元の deviceId</span><span class="sxs-lookup"><span data-stu-id="b46a9-140">deviceId of the caller</span></span>| <span data-ttu-id="b46a9-141">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="b46a9-141">403 Forbidden</span></span>| 
| <span data-ttu-id="b46a9-142">deviceType</span><span class="sxs-lookup"><span data-stu-id="b46a9-142">deviceType</span></span>| <span data-ttu-id="b46a9-143">Web 以外のすべての場合ははい</span><span class="sxs-lookup"><span data-stu-id="b46a9-143">Yes for all except Web</span></span>| <span data-ttu-id="b46a9-144">呼び出し元の deviceType</span><span class="sxs-lookup"><span data-stu-id="b46a9-144">deviceType of the caller</span></span>| <span data-ttu-id="b46a9-145">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="b46a9-145">403 Forbidden</span></span>| 
| <span data-ttu-id="b46a9-146">sandboxId</span><span class="sxs-lookup"><span data-stu-id="b46a9-146">sandboxId</span></span>| <span data-ttu-id="b46a9-147">呼び出しの場合ははい</span><span class="sxs-lookup"><span data-stu-id="b46a9-147">Yes for calls coming from</span></span> | <span data-ttu-id="b46a9-148">呼び出し元のサンド ボックス</span><span class="sxs-lookup"><span data-stu-id="b46a9-148">sandbox of the caller</span></span>| <span data-ttu-id="b46a9-149">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="b46a9-149">403 Forbidden</span></span>| 
  
<a id="ID4ENE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="b46a9-150">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b46a9-150">Required Request Headers</span></span>
 
| <span data-ttu-id="b46a9-151">Header</span><span class="sxs-lookup"><span data-stu-id="b46a9-151">Header</span></span>| <span data-ttu-id="b46a9-152">種類</span><span class="sxs-lookup"><span data-stu-id="b46a9-152">Type</span></span>| <span data-ttu-id="b46a9-153">説明</span><span class="sxs-lookup"><span data-stu-id="b46a9-153">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="b46a9-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="b46a9-154">Authorization</span></span>| <span data-ttu-id="b46a9-155">string</span><span class="sxs-lookup"><span data-stu-id="b46a9-155">string</span></span>| <span data-ttu-id="b46a9-156">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="b46a9-156">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="b46a9-157">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="b46a9-157">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="b46a9-158">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="b46a9-158">x-xbl-contract-version</span></span>| <span data-ttu-id="b46a9-159">string</span><span class="sxs-lookup"><span data-stu-id="b46a9-159">string</span></span>| <span data-ttu-id="b46a9-160">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="b46a9-160">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="b46a9-161">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="b46a9-161">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="b46a9-162">値の例:3、vnext。</span><span class="sxs-lookup"><span data-stu-id="b46a9-162">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="b46a9-163">Content-Type</span><span class="sxs-lookup"><span data-stu-id="b46a9-163">Content-Type</span></span>| <span data-ttu-id="b46a9-164">string</span><span class="sxs-lookup"><span data-stu-id="b46a9-164">string</span></span>| <span data-ttu-id="b46a9-165">要求の値の例の本文の mime の種類: アプリケーション/json します。</span><span class="sxs-lookup"><span data-stu-id="b46a9-165">The mime type of the body of the request Example value: application/json.</span></span>| 
| <span data-ttu-id="b46a9-166">Content-Length</span><span class="sxs-lookup"><span data-stu-id="b46a9-166">Content-Length</span></span>| <span data-ttu-id="b46a9-167">string</span><span class="sxs-lookup"><span data-stu-id="b46a9-167">string</span></span>| <span data-ttu-id="b46a9-168">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="b46a9-168">The length of the request body.</span></span> <span data-ttu-id="b46a9-169">値の例:312.</span><span class="sxs-lookup"><span data-stu-id="b46a9-169">Example value: 312.</span></span>| 
| <span data-ttu-id="b46a9-170">Host</span><span class="sxs-lookup"><span data-stu-id="b46a9-170">Host</span></span>| <span data-ttu-id="b46a9-171">string</span><span class="sxs-lookup"><span data-stu-id="b46a9-171">string</span></span>| <span data-ttu-id="b46a9-172">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="b46a9-172">Domain name of the server.</span></span> <span data-ttu-id="b46a9-173">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="b46a9-173">Example value: presencebeta.xboxlive.com.</span></span>| 
  
<a id="ID4ERG"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="b46a9-174">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b46a9-174">Optional Request Headers</span></span>
 
| <span data-ttu-id="b46a9-175">Header</span><span class="sxs-lookup"><span data-stu-id="b46a9-175">Header</span></span>| <span data-ttu-id="b46a9-176">種類</span><span class="sxs-lookup"><span data-stu-id="b46a9-176">Type</span></span>| <span data-ttu-id="b46a9-177">説明</span><span class="sxs-lookup"><span data-stu-id="b46a9-177">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="b46a9-178">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="b46a9-178">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="b46a9-179">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="b46a9-179">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="b46a9-180">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="b46a9-180">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="b46a9-181">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="b46a9-181">Default value: 1.</span></span>| 
  
<a id="ID4ERH"></a>

 
## <a name="request-body"></a><span data-ttu-id="b46a9-182">要求本文</span><span class="sxs-lookup"><span data-stu-id="b46a9-182">Request body</span></span>
 
<span data-ttu-id="b46a9-183">要求オブジェクトが、 [TitleRequest](../../json/json-titlerequest.md)します。</span><span class="sxs-lookup"><span data-stu-id="b46a9-183">The request object is a [TitleRequest](../../json/json-titlerequest.md).</span></span> <span data-ttu-id="b46a9-184">本文に実際に存在するプロパティのみが更新されます。</span><span class="sxs-lookup"><span data-stu-id="b46a9-184">Only the properties actually present in the body are updated.</span></span> <span data-ttu-id="b46a9-185">任意のプロパティは、本文の一部ではありませんが上に存在するサーバーは変更されません。</span><span class="sxs-lookup"><span data-stu-id="b46a9-185">Any properties that are not part of the body but exist on the server will not be modified.</span></span>
 
<a id="ID4EAAAC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="b46a9-186">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="b46a9-186">Sample request</span></span>
 

```cpp
{
  id:"12341234",
  placement:"snapped",
  state:"active"
}
      
```

   
<a id="ID4EKAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="b46a9-187">応答本文</span><span class="sxs-lookup"><span data-stu-id="b46a9-187">Response body</span></span>
 
<span data-ttu-id="b46a9-188">成功した場合の場合は、200 または 201 作成済みの HTTP ステータス コードは、に応じて、返されたは。</span><span class="sxs-lookup"><span data-stu-id="b46a9-188">In case of success, an HTTP status code of 200 or 201 Created is returned, as appropriate.</span></span>
 
<span data-ttu-id="b46a9-189">エラー (HTTP 4 xx または 5 xx) の場合は、適切なエラー情報は、応答本文で返されます。</span><span class="sxs-lookup"><span data-stu-id="b46a9-189">In case of an error (HTTP 4xx or 5xx), appropriate error information is returned in the response body.</span></span>
  
<a id="ID4EVAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b46a9-190">関連項目</span><span class="sxs-lookup"><span data-stu-id="b46a9-190">See also</span></span>
 
<a id="ID4EXAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b46a9-191">Parent</span><span class="sxs-lookup"><span data-stu-id="b46a9-191">Parent</span></span> 

[<span data-ttu-id="b46a9-192">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="b46a9-192">/users/xuid({xuid})/devices/current/titles/current</span></span>](uri-usersxuiddevicescurrenttitlescurrent.md)

  
<a id="ID4EBBAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="b46a9-193">詳細情報</span><span class="sxs-lookup"><span data-stu-id="b46a9-193">Further Information</span></span> 

[<span data-ttu-id="b46a9-194">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="b46a9-194">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

 [<span data-ttu-id="b46a9-195">その他の参照</span><span class="sxs-lookup"><span data-stu-id="b46a9-195">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   