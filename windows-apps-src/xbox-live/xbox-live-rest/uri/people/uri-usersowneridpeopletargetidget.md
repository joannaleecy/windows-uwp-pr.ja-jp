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
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4746808"
---
# <a name="get-usersowneridpeopletargetid"></a><span data-ttu-id="1e765-104">GET (/users/{ownerId}/people/{targetid})</span><span class="sxs-lookup"><span data-stu-id="1e765-104">GET (/users/{ownerId}/people/{targetid})</span></span>
<span data-ttu-id="1e765-105">呼び出し元のユーザーのコレクションからターゲット ID でユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="1e765-105">Gets a person by target ID from caller's people collection.</span></span> <span data-ttu-id="1e765-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="1e765-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="1e765-107">注釈</span><span class="sxs-lookup"><span data-stu-id="1e765-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="1e765-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1e765-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="1e765-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="1e765-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="1e765-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1e765-110">Required Request Headers</span></span>](#ID4ERC)
  * [<span data-ttu-id="1e765-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1e765-111">Optional Request Headers</span></span>](#ID4EQD)
  * [<span data-ttu-id="1e765-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="1e765-112">Request body</span></span>](#ID4EWE)
  * [<span data-ttu-id="1e765-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="1e765-113">HTTP status codes</span></span>](#ID4EBF)
  * [<span data-ttu-id="1e765-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1e765-114">Required Response Headers</span></span>](#ID4EDH)
  * [<span data-ttu-id="1e765-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="1e765-115">Response body</span></span>](#ID4EQAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="1e765-116">注釈</span><span class="sxs-lookup"><span data-stu-id="1e765-116">Remarks</span></span>
 
<span data-ttu-id="1e765-117">これと同じ結果に 1 回または複数回実行している場合、GET 操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="1e765-117">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="1e765-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1e765-118">URI parameters</span></span>
 
| <span data-ttu-id="1e765-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1e765-119">Parameter</span></span>| <span data-ttu-id="1e765-120">型</span><span class="sxs-lookup"><span data-stu-id="1e765-120">Type</span></span>| <span data-ttu-id="1e765-121">説明</span><span class="sxs-lookup"><span data-stu-id="1e765-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="1e765-122">ownerId</span><span class="sxs-lookup"><span data-stu-id="1e765-122">ownerId</span></span>| <span data-ttu-id="1e765-123">string</span><span class="sxs-lookup"><span data-stu-id="1e765-123">string</span></span>| <span data-ttu-id="1e765-124">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="1e765-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="1e765-125">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1e765-125">Must match the authenticated user.</span></span> <span data-ttu-id="1e765-126">可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="1e765-126">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="1e765-127">targetid</span><span class="sxs-lookup"><span data-stu-id="1e765-127">targetid</span></span>| <span data-ttu-id="1e765-128">string</span><span class="sxs-lookup"><span data-stu-id="1e765-128">string</span></span>| <span data-ttu-id="1e765-129">所有者のユーザー リスト、Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからのデータを取得するユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="1e765-129">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="1e765-130">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="1e765-130">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="1e765-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="1e765-131">Authorization</span></span>
 
| <span data-ttu-id="1e765-132">型</span><span class="sxs-lookup"><span data-stu-id="1e765-132">Type</span></span>| <span data-ttu-id="1e765-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="1e765-133">Required</span></span>| <span data-ttu-id="1e765-134">説明</span><span class="sxs-lookup"><span data-stu-id="1e765-134">Description</span></span>| <span data-ttu-id="1e765-135">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="1e765-135">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1e765-136">XUID</span><span class="sxs-lookup"><span data-stu-id="1e765-136">XUID</span></span>| <span data-ttu-id="1e765-137">必須</span><span class="sxs-lookup"><span data-stu-id="1e765-137">yes</span></span>| <span data-ttu-id="1e765-138">呼び出し元が、ユーザーの Xbox ユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="1e765-138">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="1e765-139">401 承認されていません。</span><span class="sxs-lookup"><span data-stu-id="1e765-139">401 Unauthorized</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="1e765-140">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1e765-140">Required Request Headers</span></span>
 
| <span data-ttu-id="1e765-141">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1e765-141">Header</span></span>| <span data-ttu-id="1e765-142">説明</span><span class="sxs-lookup"><span data-stu-id="1e765-142">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1e765-143">Authorization</span><span class="sxs-lookup"><span data-stu-id="1e765-143">Authorization</span></span>| <span data-ttu-id="1e765-144">[String]。</span><span class="sxs-lookup"><span data-stu-id="1e765-144">String.</span></span> <span data-ttu-id="1e765-145">Xbox LIVE のデータを承認します。</span><span class="sxs-lookup"><span data-stu-id="1e765-145">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="1e765-146">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="1e765-146">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="1e765-147">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。</span><span class="sxs-lookup"><span data-stu-id="1e765-147">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="1e765-148">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1e765-148">Optional Request Headers</span></span>
 
| <span data-ttu-id="1e765-149">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1e765-149">Header</span></span>| <span data-ttu-id="1e765-150">説明</span><span class="sxs-lookup"><span data-stu-id="1e765-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1e765-151">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="1e765-151">X-RequestedServiceVersion</span></span>| <span data-ttu-id="1e765-152">この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="1e765-152">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="1e765-153">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="1e765-153">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="1e765-154">Accept</span><span class="sxs-lookup"><span data-stu-id="1e765-154">Accept</span></span>| <span data-ttu-id="1e765-155">[String]。</span><span class="sxs-lookup"><span data-stu-id="1e765-155">String.</span></span> <span data-ttu-id="1e765-156">コンテンツ タイプを呼び出し元が応答で受け取る。</span><span class="sxs-lookup"><span data-stu-id="1e765-156">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="1e765-157">すべての応答とは、<b>アプリケーション/json</b>です。</span><span class="sxs-lookup"><span data-stu-id="1e765-157">All responses are <b>application/json</b>.</span></span>| 
  
<a id="ID4EWE"></a>

 
## <a name="request-body"></a><span data-ttu-id="1e765-158">要求本文</span><span class="sxs-lookup"><span data-stu-id="1e765-158">Request body</span></span>
 
<span data-ttu-id="1e765-159">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="1e765-159">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="1e765-160">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="1e765-160">HTTP status codes</span></span>
 
<span data-ttu-id="1e765-161">サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="1e765-161">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="1e765-162">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1e765-162">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="1e765-163">コード</span><span class="sxs-lookup"><span data-stu-id="1e765-163">Code</span></span>| <span data-ttu-id="1e765-164">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="1e765-164">Reason phrase</span></span>| <span data-ttu-id="1e765-165">説明</span><span class="sxs-lookup"><span data-stu-id="1e765-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1e765-166">200</span><span class="sxs-lookup"><span data-stu-id="1e765-166">200</span></span>| <span data-ttu-id="1e765-167">OK</span><span class="sxs-lookup"><span data-stu-id="1e765-167">OK</span></span>| <span data-ttu-id="1e765-168">成功します。</span><span class="sxs-lookup"><span data-stu-id="1e765-168">Success.</span></span>| 
| <span data-ttu-id="1e765-169">400</span><span class="sxs-lookup"><span data-stu-id="1e765-169">400</span></span>| <span data-ttu-id="1e765-170">Bad Request</span><span class="sxs-lookup"><span data-stu-id="1e765-170">Bad Request</span></span>| <span data-ttu-id="1e765-171">ユーザー Id が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="1e765-171">User IDs were malformed.</span></span>| 
| <span data-ttu-id="1e765-172">403</span><span class="sxs-lookup"><span data-stu-id="1e765-172">403</span></span>| <span data-ttu-id="1e765-173">Forbidden</span><span class="sxs-lookup"><span data-stu-id="1e765-173">Forbidden</span></span>| <span data-ttu-id="1e765-174">承認ヘッダーから、XUID クレームを解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="1e765-174">XUID claim could not be parsed from the authorization header.</span></span>| 
| <span data-ttu-id="1e765-175">404</span><span class="sxs-lookup"><span data-stu-id="1e765-175">404</span></span>| <span data-ttu-id="1e765-176">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="1e765-176">Not Found</span></span>| <span data-ttu-id="1e765-177">対象ユーザーが所有者の People リストに見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="1e765-177">Target user was not found in the owner's People list.</span></span>| 
  
<a id="ID4EDH"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="1e765-178">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1e765-178">Required Response Headers</span></span>
 
| <span data-ttu-id="1e765-179">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1e765-179">Header</span></span>| <span data-ttu-id="1e765-180">型</span><span class="sxs-lookup"><span data-stu-id="1e765-180">Type</span></span>| <span data-ttu-id="1e765-181">説明</span><span class="sxs-lookup"><span data-stu-id="1e765-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1e765-182">Content-Length</span><span class="sxs-lookup"><span data-stu-id="1e765-182">Content-Length</span></span>| <span data-ttu-id="1e765-183">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="1e765-183">32-bit unsigned integer</span></span>| <span data-ttu-id="1e765-184">バイト単位の長さ、応答本文。</span><span class="sxs-lookup"><span data-stu-id="1e765-184">Length, in bytes, of the response body.</span></span> <span data-ttu-id="1e765-185">値の例: 22 します。</span><span class="sxs-lookup"><span data-stu-id="1e765-185">Example value: 22.</span></span>| 
| <span data-ttu-id="1e765-186">Content-Type</span><span class="sxs-lookup"><span data-stu-id="1e765-186">Content-Type</span></span>| <span data-ttu-id="1e765-187">string</span><span class="sxs-lookup"><span data-stu-id="1e765-187">string</span></span>| <span data-ttu-id="1e765-188">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="1e765-188">MIME type of the response body.</span></span> <span data-ttu-id="1e765-189">これにより、<b>アプリケーション/json</b>は常になります。</span><span class="sxs-lookup"><span data-stu-id="1e765-189">This will always be <b>application/json</b>.</span></span>| 
  
<a id="ID4EQAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="1e765-190">応答本文</span><span class="sxs-lookup"><span data-stu-id="1e765-190">Response body</span></span>
 
<span data-ttu-id="1e765-191">呼び出しが成功した場合は、サービスは、対象のユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="1e765-191">If the call is successful, the service returns the target person.</span></span> <span data-ttu-id="1e765-192">[Person (JSON)](../../json/json-person.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1e765-192">See [Person (JSON)](../../json/json-person.md).</span></span>
 
<a id="ID4E3AAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="1e765-193">応答の例</span><span class="sxs-lookup"><span data-stu-id="1e765-193">Sample response</span></span>
 

```cpp
{
    "xuid": "2603643534573581",
    "isFavorite": false,
    "isFollowingCaller": false,
    "socialNetworks": ["LegacyXboxLive"]
}
         
```

   
<a id="ID4EGBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="1e765-194">関連項目</span><span class="sxs-lookup"><span data-stu-id="1e765-194">See also</span></span>
 
<a id="ID4EIBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="1e765-195">Parent</span><span class="sxs-lookup"><span data-stu-id="1e765-195">Parent</span></span> 

[<span data-ttu-id="1e765-196">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="1e765-196">/users/{ownerId}/people/{targetid}</span></span>](uri-usersowneridpeopletargetid.md)

   