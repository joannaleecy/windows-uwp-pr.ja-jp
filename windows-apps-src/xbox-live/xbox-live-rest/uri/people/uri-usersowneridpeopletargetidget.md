---
title: GET (/users/{ownerId}/people/{targetid})
assetID: 2fd37b8e-b886-14f2-3399-59f530d85e4e
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopletargetidget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/people/{targetid})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a0735a65afe8b5748efefce5dec9ad1989a77b4d
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4354421"
---
# <a name="get-usersowneridpeopletargetid"></a><span data-ttu-id="90104-104">GET (/users/{ownerId}/people/{targetid})</span><span class="sxs-lookup"><span data-stu-id="90104-104">GET (/users/{ownerId}/people/{targetid})</span></span>
<span data-ttu-id="90104-105">呼び出し元のユーザーのコレクションからターゲット ID でユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="90104-105">Gets a person by target ID from caller's people collection.</span></span> <span data-ttu-id="90104-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="90104-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="90104-107">注釈</span><span class="sxs-lookup"><span data-stu-id="90104-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="90104-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90104-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="90104-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="90104-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="90104-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90104-110">Required Request Headers</span></span>](#ID4ERC)
  * [<span data-ttu-id="90104-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90104-111">Optional Request Headers</span></span>](#ID4EQD)
  * [<span data-ttu-id="90104-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="90104-112">Request body</span></span>](#ID4EWE)
  * [<span data-ttu-id="90104-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="90104-113">HTTP status codes</span></span>](#ID4EBF)
  * [<span data-ttu-id="90104-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90104-114">Required Response Headers</span></span>](#ID4EDH)
  * [<span data-ttu-id="90104-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="90104-115">Response body</span></span>](#ID4EQAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="90104-116">注釈</span><span class="sxs-lookup"><span data-stu-id="90104-116">Remarks</span></span>
 
<span data-ttu-id="90104-117">これと同じ結果に 1 回または複数回実行している場合、GET 操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="90104-117">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="90104-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90104-118">URI parameters</span></span>
 
| <span data-ttu-id="90104-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="90104-119">Parameter</span></span>| <span data-ttu-id="90104-120">型</span><span class="sxs-lookup"><span data-stu-id="90104-120">Type</span></span>| <span data-ttu-id="90104-121">説明</span><span class="sxs-lookup"><span data-stu-id="90104-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="90104-122">ownerId</span><span class="sxs-lookup"><span data-stu-id="90104-122">ownerId</span></span>| <span data-ttu-id="90104-123">string</span><span class="sxs-lookup"><span data-stu-id="90104-123">string</span></span>| <span data-ttu-id="90104-124">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="90104-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="90104-125">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90104-125">Must match the authenticated user.</span></span> <span data-ttu-id="90104-126">可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="90104-126">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="90104-127">targetid</span><span class="sxs-lookup"><span data-stu-id="90104-127">targetid</span></span>| <span data-ttu-id="90104-128">string</span><span class="sxs-lookup"><span data-stu-id="90104-128">string</span></span>| <span data-ttu-id="90104-129">所有者のユーザーのリストが Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからのデータを取得するユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="90104-129">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="90104-130">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="90104-130">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="90104-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="90104-131">Authorization</span></span>
 
| <span data-ttu-id="90104-132">型</span><span class="sxs-lookup"><span data-stu-id="90104-132">Type</span></span>| <span data-ttu-id="90104-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="90104-133">Required</span></span>| <span data-ttu-id="90104-134">説明</span><span class="sxs-lookup"><span data-stu-id="90104-134">Description</span></span>| <span data-ttu-id="90104-135">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="90104-135">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90104-136">XUID</span><span class="sxs-lookup"><span data-stu-id="90104-136">XUID</span></span>| <span data-ttu-id="90104-137">必須</span><span class="sxs-lookup"><span data-stu-id="90104-137">yes</span></span>| <span data-ttu-id="90104-138">呼び出し元では、ユーザーの Xbox ユーザー ID (XUID) があります。</span><span class="sxs-lookup"><span data-stu-id="90104-138">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="90104-139">401 承認されていません。</span><span class="sxs-lookup"><span data-stu-id="90104-139">401 Unauthorized</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="90104-140">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90104-140">Required Request Headers</span></span>
 
| <span data-ttu-id="90104-141">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90104-141">Header</span></span>| <span data-ttu-id="90104-142">説明</span><span class="sxs-lookup"><span data-stu-id="90104-142">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90104-143">Authorization</span><span class="sxs-lookup"><span data-stu-id="90104-143">Authorization</span></span>| <span data-ttu-id="90104-144">[String]。</span><span class="sxs-lookup"><span data-stu-id="90104-144">String.</span></span> <span data-ttu-id="90104-145">Xbox LIVE のデータを承認します。</span><span class="sxs-lookup"><span data-stu-id="90104-145">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="90104-146">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="90104-146">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="90104-147">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。</span><span class="sxs-lookup"><span data-stu-id="90104-147">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="90104-148">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90104-148">Optional Request Headers</span></span>
 
| <span data-ttu-id="90104-149">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90104-149">Header</span></span>| <span data-ttu-id="90104-150">説明</span><span class="sxs-lookup"><span data-stu-id="90104-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90104-151">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="90104-151">X-RequestedServiceVersion</span></span>| <span data-ttu-id="90104-152">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="90104-152">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="90104-153">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="90104-153">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="90104-154">Accept</span><span class="sxs-lookup"><span data-stu-id="90104-154">Accept</span></span>| <span data-ttu-id="90104-155">[String]。</span><span class="sxs-lookup"><span data-stu-id="90104-155">String.</span></span> <span data-ttu-id="90104-156">コンテンツ タイプを呼び出し元が応答で受け取る。</span><span class="sxs-lookup"><span data-stu-id="90104-156">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="90104-157">すべての応答は、<b>アプリケーション/json</b>です。</span><span class="sxs-lookup"><span data-stu-id="90104-157">All responses are <b>application/json</b>.</span></span>| 
  
<a id="ID4EWE"></a>

 
## <a name="request-body"></a><span data-ttu-id="90104-158">要求本文</span><span class="sxs-lookup"><span data-stu-id="90104-158">Request body</span></span>
 
<span data-ttu-id="90104-159">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="90104-159">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="90104-160">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="90104-160">HTTP status codes</span></span>
 
<span data-ttu-id="90104-161">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="90104-161">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="90104-162">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90104-162">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="90104-163">コード</span><span class="sxs-lookup"><span data-stu-id="90104-163">Code</span></span>| <span data-ttu-id="90104-164">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="90104-164">Reason phrase</span></span>| <span data-ttu-id="90104-165">説明</span><span class="sxs-lookup"><span data-stu-id="90104-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90104-166">200</span><span class="sxs-lookup"><span data-stu-id="90104-166">200</span></span>| <span data-ttu-id="90104-167">OK</span><span class="sxs-lookup"><span data-stu-id="90104-167">OK</span></span>| <span data-ttu-id="90104-168">成功します。</span><span class="sxs-lookup"><span data-stu-id="90104-168">Success.</span></span>| 
| <span data-ttu-id="90104-169">400</span><span class="sxs-lookup"><span data-stu-id="90104-169">400</span></span>| <span data-ttu-id="90104-170">Bad Request</span><span class="sxs-lookup"><span data-stu-id="90104-170">Bad Request</span></span>| <span data-ttu-id="90104-171">ユーザー Id が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="90104-171">User IDs were malformed.</span></span>| 
| <span data-ttu-id="90104-172">403</span><span class="sxs-lookup"><span data-stu-id="90104-172">403</span></span>| <span data-ttu-id="90104-173">Forbidden</span><span class="sxs-lookup"><span data-stu-id="90104-173">Forbidden</span></span>| <span data-ttu-id="90104-174">承認ヘッダーから XUID クレームを解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="90104-174">XUID claim could not be parsed from the authorization header.</span></span>| 
| <span data-ttu-id="90104-175">404</span><span class="sxs-lookup"><span data-stu-id="90104-175">404</span></span>| <span data-ttu-id="90104-176">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="90104-176">Not Found</span></span>| <span data-ttu-id="90104-177">対象ユーザーが所有者のユーザー リストに見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="90104-177">Target user was not found in the owner's People list.</span></span>| 
  
<a id="ID4EDH"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="90104-178">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90104-178">Required Response Headers</span></span>
 
| <span data-ttu-id="90104-179">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90104-179">Header</span></span>| <span data-ttu-id="90104-180">型</span><span class="sxs-lookup"><span data-stu-id="90104-180">Type</span></span>| <span data-ttu-id="90104-181">説明</span><span class="sxs-lookup"><span data-stu-id="90104-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90104-182">Content-Length</span><span class="sxs-lookup"><span data-stu-id="90104-182">Content-Length</span></span>| <span data-ttu-id="90104-183">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="90104-183">32-bit unsigned integer</span></span>| <span data-ttu-id="90104-184">バイト単位の長さ、応答本文。</span><span class="sxs-lookup"><span data-stu-id="90104-184">Length, in bytes, of the response body.</span></span> <span data-ttu-id="90104-185">値の例: 22 します。</span><span class="sxs-lookup"><span data-stu-id="90104-185">Example value: 22.</span></span>| 
| <span data-ttu-id="90104-186">Content-Type</span><span class="sxs-lookup"><span data-stu-id="90104-186">Content-Type</span></span>| <span data-ttu-id="90104-187">string</span><span class="sxs-lookup"><span data-stu-id="90104-187">string</span></span>| <span data-ttu-id="90104-188">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="90104-188">MIME type of the response body.</span></span> <span data-ttu-id="90104-189">これにより、<b>アプリケーション/json</b>は常になります。</span><span class="sxs-lookup"><span data-stu-id="90104-189">This will always be <b>application/json</b>.</span></span>| 
  
<a id="ID4EQAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="90104-190">応答本文</span><span class="sxs-lookup"><span data-stu-id="90104-190">Response body</span></span>
 
<span data-ttu-id="90104-191">呼び出しが成功した場合は、サービスは、対象のユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="90104-191">If the call is successful, the service returns the target person.</span></span> <span data-ttu-id="90104-192">[Person (JSON)](../../json/json-person.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90104-192">See [Person (JSON)](../../json/json-person.md).</span></span>
 
<a id="ID4E3AAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="90104-193">応答の例</span><span class="sxs-lookup"><span data-stu-id="90104-193">Sample response</span></span>
 

```cpp
{
    "xuid": "2603643534573581",
    "isFavorite": false,
    "isFollowingCaller": false,
    "socialNetworks": ["LegacyXboxLive"]
}
         
```

   
<a id="ID4EGBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="90104-194">関連項目</span><span class="sxs-lookup"><span data-stu-id="90104-194">See also</span></span>
 
<a id="ID4EIBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="90104-195">Parent</span><span class="sxs-lookup"><span data-stu-id="90104-195">Parent</span></span> 

[<span data-ttu-id="90104-196">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="90104-196">/users/{ownerId}/people/{targetid}</span></span>](uri-usersowneridpeopletargetid.md)

   