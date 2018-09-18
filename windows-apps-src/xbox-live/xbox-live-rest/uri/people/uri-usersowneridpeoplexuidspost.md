---
title: POST (/users/{ownerId}/people/xuids)
assetID: e20bfb58-9c3b-14ed-6462-85d42fa6fe1a
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuidspost.html
author: KevinAsgari
description: " POST (/users/{ownerId}/people/xuids)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 27fbc0e209439fca01cf1e7d8c7c3bf98c4b9053
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4015417"
---
# <a name="post-usersowneridpeoplexuids"></a><span data-ttu-id="8f3a6-104">POST (/users/{ownerId}/people/xuids)</span><span class="sxs-lookup"><span data-stu-id="8f3a6-104">POST (/users/{ownerId}/people/xuids)</span></span>
<span data-ttu-id="8f3a6-105">呼び出し元のユーザーからコレクションの XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-105">Gets people by XUID from caller's people collection.</span></span> <span data-ttu-id="8f3a6-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="8f3a6-107">注釈</span><span class="sxs-lookup"><span data-stu-id="8f3a6-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="8f3a6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8f3a6-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="8f3a6-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="8f3a6-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="8f3a6-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-110">Required Request Headers</span></span>](#ID4ERC)
  * [<span data-ttu-id="8f3a6-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-111">Optional Request Headers</span></span>](#ID4EBE)
  * [<span data-ttu-id="8f3a6-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="8f3a6-112">Request body</span></span>](#ID4EHF)
  * [<span data-ttu-id="8f3a6-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8f3a6-113">HTTP status codes</span></span>](#ID4EKH)
  * [<span data-ttu-id="8f3a6-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-114">Required Response Headers</span></span>](#ID4ENBAC)
  * [<span data-ttu-id="8f3a6-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="8f3a6-115">Response body</span></span>](#ID4EZCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="8f3a6-116">注釈</span><span class="sxs-lookup"><span data-stu-id="8f3a6-116">Remarks</span></span>
 
<span data-ttu-id="8f3a6-117">POST ので、これと同じ結果に 1 回または複数回実行する場合、操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-117">POST operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="8f3a6-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8f3a6-118">URI parameters</span></span>
 
| <span data-ttu-id="8f3a6-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8f3a6-119">Parameter</span></span>| <span data-ttu-id="8f3a6-120">型</span><span class="sxs-lookup"><span data-stu-id="8f3a6-120">Type</span></span>| <span data-ttu-id="8f3a6-121">説明</span><span class="sxs-lookup"><span data-stu-id="8f3a6-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="8f3a6-122">ownerId</span><span class="sxs-lookup"><span data-stu-id="8f3a6-122">ownerId</span></span>| <span data-ttu-id="8f3a6-123">string</span><span class="sxs-lookup"><span data-stu-id="8f3a6-123">string</span></span>| <span data-ttu-id="8f3a6-124">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="8f3a6-125">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-125">Must match the authenticated user.</span></span> <span data-ttu-id="8f3a6-126">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-126">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="8f3a6-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="8f3a6-127">Authorization</span></span>
 
| <span data-ttu-id="8f3a6-128">型</span><span class="sxs-lookup"><span data-stu-id="8f3a6-128">Type</span></span>| <span data-ttu-id="8f3a6-129">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="8f3a6-129">Required</span></span>| <span data-ttu-id="8f3a6-130">説明</span><span class="sxs-lookup"><span data-stu-id="8f3a6-130">Description</span></span>| <span data-ttu-id="8f3a6-131">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="8f3a6-131">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8f3a6-132">XUID</span><span class="sxs-lookup"><span data-stu-id="8f3a6-132">XUID</span></span>| <span data-ttu-id="8f3a6-133">必須</span><span class="sxs-lookup"><span data-stu-id="8f3a6-133">yes</span></span>| <span data-ttu-id="8f3a6-134">呼び出し元では、ユーザーの Xbox ユーザー ID (XUID) があります。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-134">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="8f3a6-135">401 承認されていません。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-135">401 Unauthorized</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="8f3a6-136">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-136">Required Request Headers</span></span>
 
| <span data-ttu-id="8f3a6-137">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-137">Header</span></span>| <span data-ttu-id="8f3a6-138">説明</span><span class="sxs-lookup"><span data-stu-id="8f3a6-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8f3a6-139">Authorization</span><span class="sxs-lookup"><span data-stu-id="8f3a6-139">Authorization</span></span>| <span data-ttu-id="8f3a6-140">[String]。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-140">String.</span></span> <span data-ttu-id="8f3a6-141">Xbox LIVE のデータを承認します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-141">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="8f3a6-142">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-142">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="8f3a6-143">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-143">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>| 
| <span data-ttu-id="8f3a6-144">Content-Length</span><span class="sxs-lookup"><span data-stu-id="8f3a6-144">Content-Length</span></span>| <span data-ttu-id="8f3a6-145">32 ビット符号なし整数。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-145">32-bit unsigned integer.</span></span> <span data-ttu-id="8f3a6-146">バイト単位の長さ、要求本文。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-146">Length, in bytes, of the request body.</span></span> <span data-ttu-id="8f3a6-147">値の例: 22 します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-147">Example value: 22.</span></span>| 
| <span data-ttu-id="8f3a6-148">Content-Type</span><span class="sxs-lookup"><span data-stu-id="8f3a6-148">Content-Type</span></span>| <span data-ttu-id="8f3a6-149">[String]。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-149">String.</span></span> <span data-ttu-id="8f3a6-150">要求本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-150">MIME type of the request body.</span></span> <span data-ttu-id="8f3a6-151">これは、<b>アプリケーション/json</b>でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-151">This must be <b>application/json</b>.</span></span>| 
  
<a id="ID4EBE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="8f3a6-152">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-152">Optional Request Headers</span></span>
 
| <span data-ttu-id="8f3a6-153">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-153">Header</span></span>| <span data-ttu-id="8f3a6-154">説明</span><span class="sxs-lookup"><span data-stu-id="8f3a6-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8f3a6-155">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="8f3a6-155">X-RequestedServiceVersion</span></span>| <span data-ttu-id="8f3a6-156">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-156">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="8f3a6-157">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-157">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="8f3a6-158">Accept</span><span class="sxs-lookup"><span data-stu-id="8f3a6-158">Accept</span></span>| <span data-ttu-id="8f3a6-159">[String]。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-159">String.</span></span> <span data-ttu-id="8f3a6-160">コンテンツ タイプを呼び出し元が応答で受け取る。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-160">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="8f3a6-161">すべての応答は、<b>アプリケーション/json</b>です。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-161">All responses are <b>application/json</b>.</span></span>| 
  
<a id="ID4EHF"></a>

 
## <a name="request-body"></a><span data-ttu-id="8f3a6-162">要求本文</span><span class="sxs-lookup"><span data-stu-id="8f3a6-162">Request body</span></span>
 
<a id="ID4ENF"></a>

 
### <a name="required-members"></a><span data-ttu-id="8f3a6-163">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-163">Required members</span></span>
 
| <span data-ttu-id="8f3a6-164">メンバー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-164">Member</span></span>| <span data-ttu-id="8f3a6-165">説明</span><span class="sxs-lookup"><span data-stu-id="8f3a6-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8f3a6-166">XuidList</span><span class="sxs-lookup"><span data-stu-id="8f3a6-166">XuidList</span></span>| <span data-ttu-id="8f3a6-167">呼び出し元のユーザーのコレクションから返される人を識別する Xuid の配列です。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-167">Array of XUIDs that identify the people to be returned from the caller's people collection.</span></span> <span data-ttu-id="8f3a6-168">[XuidList (JSON)](../../json/json-xuidlist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-168">See [XuidList (JSON)](../../json/json-xuidlist.md).</span></span>| 
  
<a id="ID4EKG"></a>

 
### <a name="optional-members"></a><span data-ttu-id="8f3a6-169">省略可能なメンバー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-169">Optional members</span></span>
 
<span data-ttu-id="8f3a6-170">この要求の省略可能なメンバーはありません。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-170">There are no optional members for this request.</span></span>
  
<a id="ID4EVG"></a>

 
### <a name="prohibited-members"></a><span data-ttu-id="8f3a6-171">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-171">Prohibited members</span></span>
 
<span data-ttu-id="8f3a6-172">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-172">All other members are prohibited in a request.</span></span>
  
<a id="ID4EAH"></a>

 
### <a name="sample-request"></a><span data-ttu-id="8f3a6-173">要求の例</span><span class="sxs-lookup"><span data-stu-id="8f3a6-173">Sample request</span></span>
 

```cpp
{
    "xuids": [
        "2533274790395904", 
        "2533274792986770", 
        "2533274794866999"
    ]
}
      
```

   
<a id="ID4EKH"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="8f3a6-174">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8f3a6-174">HTTP status codes</span></span>
 
<span data-ttu-id="8f3a6-175">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-175">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="8f3a6-176">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-176">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="8f3a6-177">コード</span><span class="sxs-lookup"><span data-stu-id="8f3a6-177">Code</span></span>| <span data-ttu-id="8f3a6-178">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="8f3a6-178">Reason phrase</span></span>| <span data-ttu-id="8f3a6-179">説明</span><span class="sxs-lookup"><span data-stu-id="8f3a6-179">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8f3a6-180">200</span><span class="sxs-lookup"><span data-stu-id="8f3a6-180">200</span></span>| <span data-ttu-id="8f3a6-181">OK</span><span class="sxs-lookup"><span data-stu-id="8f3a6-181">OK</span></span>| <span data-ttu-id="8f3a6-182">メソッドは、「取得」するときに成功します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-182">Success when method is "get".</span></span>| 
| <span data-ttu-id="8f3a6-183">204</span><span class="sxs-lookup"><span data-stu-id="8f3a6-183">204</span></span>| <span data-ttu-id="8f3a6-184">No Content</span><span class="sxs-lookup"><span data-stu-id="8f3a6-184">No Content</span></span>| <span data-ttu-id="8f3a6-185">成功の方法が「追加」または「削除」します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-185">Success when method is "add" or "remove".</span></span>| 
| <span data-ttu-id="8f3a6-186">400</span><span class="sxs-lookup"><span data-stu-id="8f3a6-186">400</span></span>| <span data-ttu-id="8f3a6-187">Bad Request</span><span class="sxs-lookup"><span data-stu-id="8f3a6-187">Bad Request</span></span>| <span data-ttu-id="8f3a6-188">メソッドのパラメーターが不足しているか、正しくないか、ユーザー Id が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-188">Method parameter was missing or malformed, or user IDs were malformed.</span></span>| 
| <span data-ttu-id="8f3a6-189">403</span><span class="sxs-lookup"><span data-stu-id="8f3a6-189">403</span></span>| <span data-ttu-id="8f3a6-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="8f3a6-190">Forbidden</span></span>| <span data-ttu-id="8f3a6-191">承認ヘッダーから XUID クレームを解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-191">XUID claim could not be parsed from the authorization header.</span></span>| 
  
<a id="ID4ENBAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="8f3a6-192">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-192">Required Response Headers</span></span>
 
| <span data-ttu-id="8f3a6-193">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f3a6-193">Header</span></span>| <span data-ttu-id="8f3a6-194">型</span><span class="sxs-lookup"><span data-stu-id="8f3a6-194">Type</span></span>| <span data-ttu-id="8f3a6-195">説明</span><span class="sxs-lookup"><span data-stu-id="8f3a6-195">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8f3a6-196">Content-Length</span><span class="sxs-lookup"><span data-stu-id="8f3a6-196">Content-Length</span></span>| <span data-ttu-id="8f3a6-197">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="8f3a6-197">32-bit unsigned integer</span></span>| <span data-ttu-id="8f3a6-198">バイト単位の長さ、応答本文。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-198">Length, in bytes, of the response body.</span></span> <span data-ttu-id="8f3a6-199">値の例: 22 します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-199">Example value: 22.</span></span>| 
| <span data-ttu-id="8f3a6-200">Content-Type</span><span class="sxs-lookup"><span data-stu-id="8f3a6-200">Content-Type</span></span>| <span data-ttu-id="8f3a6-201">string</span><span class="sxs-lookup"><span data-stu-id="8f3a6-201">string</span></span>| <span data-ttu-id="8f3a6-202">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-202">MIME type of the response body.</span></span> <span data-ttu-id="8f3a6-203">これにより、<b>アプリケーション/json</b>は常になります。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-203">This will always be <b>application/json</b>.</span></span>| 
  
<a id="ID4EZCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="8f3a6-204">応答本文</span><span class="sxs-lookup"><span data-stu-id="8f3a6-204">Response body</span></span>
 
<span data-ttu-id="8f3a6-205">応答本文は要求メソッドは、「取得」するときにのみ送信されます。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-205">A response body is only sent when the request method is "get".</span></span> <span data-ttu-id="8f3a6-206">「追加」または「削除」の応答の本文はありません。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-206">There is no response body for "add" or "remove".</span></span>
 
<span data-ttu-id="8f3a6-207">「取得」メソッドの呼び出しが成功した場合は、サービスはコレクション、および呼び出し元のユーザーのコレクションが含まれた配列で呼び出し元のユーザーのユーザーの合計数を返します。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-207">If a "get" method call is successful, the service returns the total number of people in the caller's people collection, and an array containing the caller's people collection.</span></span> <span data-ttu-id="8f3a6-208">「追加」と「を削除する」メソッドの応答は返されません。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-208">No response is returned for "add" and "remove" methods.</span></span> <span data-ttu-id="8f3a6-209">[PeopleList (JSON)](../../json/json-peoplelist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8f3a6-209">See [PeopleList (JSON)](../../json/json-peoplelist.md).</span></span>
 
<a id="ID4EHDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="8f3a6-210">応答の例</span><span class="sxs-lookup"><span data-stu-id="8f3a6-210">Sample response</span></span>
 

```cpp
{
    "people": [
        {
            "xuid": "2603643534573573",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573572",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573577",
            "isFavorite": false,
            "isFollowingCaller": false
        },
    ],
    "totalCount": 3
}
         
```

   
<a id="ID4ERDAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="8f3a6-211">関連項目</span><span class="sxs-lookup"><span data-stu-id="8f3a6-211">See also</span></span>
 
<a id="ID4ETDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="8f3a6-212">Parent</span><span class="sxs-lookup"><span data-stu-id="8f3a6-212">Parent</span></span> 

[<span data-ttu-id="8f3a6-213">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="8f3a6-213">/users/{ownerId}/people/xuids</span></span>](uri-usersowneridpeoplexuids.md)

   