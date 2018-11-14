---
title: GET (/users/{ownerId}/people/{targetid})
assetID: 2fd37b8e-b886-14f2-3399-59f530d85e4e
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopletargetidget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/people/{targetid})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b9c821e9d2cecc0b9a6bd02da650d40385a3fd91
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6275605"
---
# <a name="get-usersowneridpeopletargetid"></a><span data-ttu-id="78e1d-104">GET (/users/{ownerId}/people/{targetid})</span><span class="sxs-lookup"><span data-stu-id="78e1d-104">GET (/users/{ownerId}/people/{targetid})</span></span>
<span data-ttu-id="78e1d-105">呼び出し元のユーザーのコレクションからターゲット ID でユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-105">Gets a person by target ID from caller's people collection.</span></span> <span data-ttu-id="78e1d-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="78e1d-107">注釈</span><span class="sxs-lookup"><span data-stu-id="78e1d-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="78e1d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="78e1d-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="78e1d-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="78e1d-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="78e1d-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78e1d-110">Required Request Headers</span></span>](#ID4ERC)
  * [<span data-ttu-id="78e1d-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78e1d-111">Optional Request Headers</span></span>](#ID4EQD)
  * [<span data-ttu-id="78e1d-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="78e1d-112">Request body</span></span>](#ID4EWE)
  * [<span data-ttu-id="78e1d-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="78e1d-113">HTTP status codes</span></span>](#ID4EBF)
  * [<span data-ttu-id="78e1d-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78e1d-114">Required Response Headers</span></span>](#ID4EDH)
  * [<span data-ttu-id="78e1d-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="78e1d-115">Response body</span></span>](#ID4EQAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="78e1d-116">注釈</span><span class="sxs-lookup"><span data-stu-id="78e1d-116">Remarks</span></span>
 
<span data-ttu-id="78e1d-117">これと同じ結果に 1 回または複数回実行する場合、GET 操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="78e1d-117">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="78e1d-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="78e1d-118">URI parameters</span></span>
 
| <span data-ttu-id="78e1d-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="78e1d-119">Parameter</span></span>| <span data-ttu-id="78e1d-120">型</span><span class="sxs-lookup"><span data-stu-id="78e1d-120">Type</span></span>| <span data-ttu-id="78e1d-121">説明</span><span class="sxs-lookup"><span data-stu-id="78e1d-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="78e1d-122">ownerId</span><span class="sxs-lookup"><span data-stu-id="78e1d-122">ownerId</span></span>| <span data-ttu-id="78e1d-123">string</span><span class="sxs-lookup"><span data-stu-id="78e1d-123">string</span></span>| <span data-ttu-id="78e1d-124">そのリソースにアクセスしているユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="78e1d-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="78e1d-125">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="78e1d-125">Must match the authenticated user.</span></span> <span data-ttu-id="78e1d-126">可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="78e1d-126">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="78e1d-127">targetid</span><span class="sxs-lookup"><span data-stu-id="78e1d-127">targetid</span></span>| <span data-ttu-id="78e1d-128">string</span><span class="sxs-lookup"><span data-stu-id="78e1d-128">string</span></span>| <span data-ttu-id="78e1d-129">所有者のユーザーのリストが Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからのデータを取得するユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="78e1d-129">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="78e1d-130">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-130">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="78e1d-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="78e1d-131">Authorization</span></span>
 
| <span data-ttu-id="78e1d-132">型</span><span class="sxs-lookup"><span data-stu-id="78e1d-132">Type</span></span>| <span data-ttu-id="78e1d-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="78e1d-133">Required</span></span>| <span data-ttu-id="78e1d-134">説明</span><span class="sxs-lookup"><span data-stu-id="78e1d-134">Description</span></span>| <span data-ttu-id="78e1d-135">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="78e1d-135">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="78e1d-136">XUID</span><span class="sxs-lookup"><span data-stu-id="78e1d-136">XUID</span></span>| <span data-ttu-id="78e1d-137">必須</span><span class="sxs-lookup"><span data-stu-id="78e1d-137">yes</span></span>| <span data-ttu-id="78e1d-138">呼び出し元が、ユーザーの Xbox ユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="78e1d-138">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="78e1d-139">401 承認されていません。</span><span class="sxs-lookup"><span data-stu-id="78e1d-139">401 Unauthorized</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="78e1d-140">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78e1d-140">Required Request Headers</span></span>
 
| <span data-ttu-id="78e1d-141">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78e1d-141">Header</span></span>| <span data-ttu-id="78e1d-142">説明</span><span class="sxs-lookup"><span data-stu-id="78e1d-142">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="78e1d-143">Authorization</span><span class="sxs-lookup"><span data-stu-id="78e1d-143">Authorization</span></span>| <span data-ttu-id="78e1d-144">[String]。</span><span class="sxs-lookup"><span data-stu-id="78e1d-144">String.</span></span> <span data-ttu-id="78e1d-145">Xbox LIVE のデータを承認します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-145">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="78e1d-146">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="78e1d-146">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="78e1d-147">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-147">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="78e1d-148">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78e1d-148">Optional Request Headers</span></span>
 
| <span data-ttu-id="78e1d-149">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78e1d-149">Header</span></span>| <span data-ttu-id="78e1d-150">説明</span><span class="sxs-lookup"><span data-stu-id="78e1d-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="78e1d-151">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="78e1d-151">X-RequestedServiceVersion</span></span>| <span data-ttu-id="78e1d-152">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="78e1d-152">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="78e1d-153">要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="78e1d-153">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="78e1d-154">Accept</span><span class="sxs-lookup"><span data-stu-id="78e1d-154">Accept</span></span>| <span data-ttu-id="78e1d-155">[String]。</span><span class="sxs-lookup"><span data-stu-id="78e1d-155">String.</span></span> <span data-ttu-id="78e1d-156">コンテンツ タイプを呼び出し元が応答で受け取る。</span><span class="sxs-lookup"><span data-stu-id="78e1d-156">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="78e1d-157">すべての返信は、<b>アプリケーション/json</b>です。</span><span class="sxs-lookup"><span data-stu-id="78e1d-157">All responses are <b>application/json</b>.</span></span>| 
  
<a id="ID4EWE"></a>

 
## <a name="request-body"></a><span data-ttu-id="78e1d-158">要求本文</span><span class="sxs-lookup"><span data-stu-id="78e1d-158">Request body</span></span>
 
<span data-ttu-id="78e1d-159">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="78e1d-159">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="78e1d-160">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="78e1d-160">HTTP status codes</span></span>
 
<span data-ttu-id="78e1d-161">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-161">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="78e1d-162">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="78e1d-162">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="78e1d-163">コード</span><span class="sxs-lookup"><span data-stu-id="78e1d-163">Code</span></span>| <span data-ttu-id="78e1d-164">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="78e1d-164">Reason phrase</span></span>| <span data-ttu-id="78e1d-165">説明</span><span class="sxs-lookup"><span data-stu-id="78e1d-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="78e1d-166">200</span><span class="sxs-lookup"><span data-stu-id="78e1d-166">200</span></span>| <span data-ttu-id="78e1d-167">OK</span><span class="sxs-lookup"><span data-stu-id="78e1d-167">OK</span></span>| <span data-ttu-id="78e1d-168">成功します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-168">Success.</span></span>| 
| <span data-ttu-id="78e1d-169">400</span><span class="sxs-lookup"><span data-stu-id="78e1d-169">400</span></span>| <span data-ttu-id="78e1d-170">Bad Request</span><span class="sxs-lookup"><span data-stu-id="78e1d-170">Bad Request</span></span>| <span data-ttu-id="78e1d-171">ユーザー Id が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="78e1d-171">User IDs were malformed.</span></span>| 
| <span data-ttu-id="78e1d-172">403</span><span class="sxs-lookup"><span data-stu-id="78e1d-172">403</span></span>| <span data-ttu-id="78e1d-173">Forbidden</span><span class="sxs-lookup"><span data-stu-id="78e1d-173">Forbidden</span></span>| <span data-ttu-id="78e1d-174">承認ヘッダーから XUID クレームを解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="78e1d-174">XUID claim could not be parsed from the authorization header.</span></span>| 
| <span data-ttu-id="78e1d-175">404</span><span class="sxs-lookup"><span data-stu-id="78e1d-175">404</span></span>| <span data-ttu-id="78e1d-176">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-176">Not Found</span></span>| <span data-ttu-id="78e1d-177">対象ユーザーが所有者の People リストに見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="78e1d-177">Target user was not found in the owner's People list.</span></span>| 
  
<a id="ID4EDH"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="78e1d-178">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78e1d-178">Required Response Headers</span></span>
 
| <span data-ttu-id="78e1d-179">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="78e1d-179">Header</span></span>| <span data-ttu-id="78e1d-180">型</span><span class="sxs-lookup"><span data-stu-id="78e1d-180">Type</span></span>| <span data-ttu-id="78e1d-181">説明</span><span class="sxs-lookup"><span data-stu-id="78e1d-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="78e1d-182">Content-Length</span><span class="sxs-lookup"><span data-stu-id="78e1d-182">Content-Length</span></span>| <span data-ttu-id="78e1d-183">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="78e1d-183">32-bit unsigned integer</span></span>| <span data-ttu-id="78e1d-184">バイト単位の長さ、応答本文。</span><span class="sxs-lookup"><span data-stu-id="78e1d-184">Length, in bytes, of the response body.</span></span> <span data-ttu-id="78e1d-185">値の例: 22 します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-185">Example value: 22.</span></span>| 
| <span data-ttu-id="78e1d-186">Content-Type</span><span class="sxs-lookup"><span data-stu-id="78e1d-186">Content-Type</span></span>| <span data-ttu-id="78e1d-187">string</span><span class="sxs-lookup"><span data-stu-id="78e1d-187">string</span></span>| <span data-ttu-id="78e1d-188">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="78e1d-188">MIME type of the response body.</span></span> <span data-ttu-id="78e1d-189">これにより、<b>アプリケーション/json</b>は常になります。</span><span class="sxs-lookup"><span data-stu-id="78e1d-189">This will always be <b>application/json</b>.</span></span>| 
  
<a id="ID4EQAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="78e1d-190">応答本文</span><span class="sxs-lookup"><span data-stu-id="78e1d-190">Response body</span></span>
 
<span data-ttu-id="78e1d-191">呼び出しが成功した場合は、サービスは、対象のユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="78e1d-191">If the call is successful, the service returns the target person.</span></span> <span data-ttu-id="78e1d-192">[Person (JSON)](../../json/json-person.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="78e1d-192">See [Person (JSON)](../../json/json-person.md).</span></span>
 
<a id="ID4E3AAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="78e1d-193">応答の例</span><span class="sxs-lookup"><span data-stu-id="78e1d-193">Sample response</span></span>
 

```cpp
{
    "xuid": "2603643534573581",
    "isFavorite": false,
    "isFollowingCaller": false,
    "socialNetworks": ["LegacyXboxLive"]
}
         
```

   
<a id="ID4EGBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="78e1d-194">関連項目</span><span class="sxs-lookup"><span data-stu-id="78e1d-194">See also</span></span>
 
<a id="ID4EIBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="78e1d-195">Parent</span><span class="sxs-lookup"><span data-stu-id="78e1d-195">Parent</span></span> 

[<span data-ttu-id="78e1d-196">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="78e1d-196">/users/{ownerId}/people/{targetid}</span></span>](uri-usersowneridpeopletargetid.md)

   