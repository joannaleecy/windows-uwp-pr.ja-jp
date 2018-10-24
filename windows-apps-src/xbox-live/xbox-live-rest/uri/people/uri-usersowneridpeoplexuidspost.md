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
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483534"
---
# <a name="post-usersowneridpeoplexuids"></a><span data-ttu-id="2390c-104">POST (/users/{ownerId}/people/xuids)</span><span class="sxs-lookup"><span data-stu-id="2390c-104">POST (/users/{ownerId}/people/xuids)</span></span>
<span data-ttu-id="2390c-105">呼び出し元のユーザーからコレクションの XUID のユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="2390c-105">Gets people by XUID from caller's people collection.</span></span> <span data-ttu-id="2390c-106">これらの Uri のドメインは、 `social.xboxlive.com`。</span><span class="sxs-lookup"><span data-stu-id="2390c-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="2390c-107">注釈</span><span class="sxs-lookup"><span data-stu-id="2390c-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="2390c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2390c-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="2390c-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="2390c-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="2390c-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2390c-110">Required Request Headers</span></span>](#ID4ERC)
  * [<span data-ttu-id="2390c-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2390c-111">Optional Request Headers</span></span>](#ID4EBE)
  * [<span data-ttu-id="2390c-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="2390c-112">Request body</span></span>](#ID4EHF)
  * [<span data-ttu-id="2390c-113">HTTP ステータス ・ コード</span><span class="sxs-lookup"><span data-stu-id="2390c-113">HTTP status codes</span></span>](#ID4EKH)
  * [<span data-ttu-id="2390c-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2390c-114">Required Response Headers</span></span>](#ID4ENBAC)
  * [<span data-ttu-id="2390c-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="2390c-115">Response body</span></span>](#ID4EZCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="2390c-116">注釈</span><span class="sxs-lookup"><span data-stu-id="2390c-116">Remarks</span></span>
 
<span data-ttu-id="2390c-117">投稿操作を使うと、1 回または複数回実行された場合は、同じ結果を生成これは、このリソースは変更されません。</span><span class="sxs-lookup"><span data-stu-id="2390c-117">POST operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="2390c-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2390c-118">URI parameters</span></span>
 
| <span data-ttu-id="2390c-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2390c-119">Parameter</span></span>| <span data-ttu-id="2390c-120">型</span><span class="sxs-lookup"><span data-stu-id="2390c-120">Type</span></span>| <span data-ttu-id="2390c-121">説明</span><span class="sxs-lookup"><span data-stu-id="2390c-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2390c-122">ownerId</span><span class="sxs-lookup"><span data-stu-id="2390c-122">ownerId</span></span>| <span data-ttu-id="2390c-123">string</span><span class="sxs-lookup"><span data-stu-id="2390c-123">string</span></span>| <span data-ttu-id="2390c-124">リソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="2390c-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="2390c-125">認証済みのユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2390c-125">Must match the authenticated user.</span></span> <span data-ttu-id="2390c-126">使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="2390c-126">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="2390c-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="2390c-127">Authorization</span></span>
 
| <span data-ttu-id="2390c-128">型</span><span class="sxs-lookup"><span data-stu-id="2390c-128">Type</span></span>| <span data-ttu-id="2390c-129">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2390c-129">Required</span></span>| <span data-ttu-id="2390c-130">説明</span><span class="sxs-lookup"><span data-stu-id="2390c-130">Description</span></span>| <span data-ttu-id="2390c-131">応答がない場合は、</span><span class="sxs-lookup"><span data-stu-id="2390c-131">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2390c-132">XUID</span><span class="sxs-lookup"><span data-stu-id="2390c-132">XUID</span></span>| <span data-ttu-id="2390c-133">必須</span><span class="sxs-lookup"><span data-stu-id="2390c-133">yes</span></span>| <span data-ttu-id="2390c-134">呼び出し元には、ユーザーの Xbox ユーザー ID (XUID) があります。</span><span class="sxs-lookup"><span data-stu-id="2390c-134">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="2390c-135">401 権限がありません。</span><span class="sxs-lookup"><span data-stu-id="2390c-135">401 Unauthorized</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="2390c-136">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2390c-136">Required Request Headers</span></span>
 
| <span data-ttu-id="2390c-137">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2390c-137">Header</span></span>| <span data-ttu-id="2390c-138">説明</span><span class="sxs-lookup"><span data-stu-id="2390c-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2390c-139">Authorization</span><span class="sxs-lookup"><span data-stu-id="2390c-139">Authorization</span></span>| <span data-ttu-id="2390c-140">[String]。</span><span class="sxs-lookup"><span data-stu-id="2390c-140">String.</span></span> <span data-ttu-id="2390c-141">Xbox LIVE 用のデータを承認します。</span><span class="sxs-lookup"><span data-stu-id="2390c-141">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="2390c-142">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="2390c-142">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="2390c-143">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>。</span><span class="sxs-lookup"><span data-stu-id="2390c-143">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>| 
| <span data-ttu-id="2390c-144">Content-Length</span><span class="sxs-lookup"><span data-stu-id="2390c-144">Content-Length</span></span>| <span data-ttu-id="2390c-145">32 ビット符号なし整数。</span><span class="sxs-lookup"><span data-stu-id="2390c-145">32-bit unsigned integer.</span></span> <span data-ttu-id="2390c-146">長さをバイト単位で要求の本体です。</span><span class="sxs-lookup"><span data-stu-id="2390c-146">Length, in bytes, of the request body.</span></span> <span data-ttu-id="2390c-147">値の例: 22 です。</span><span class="sxs-lookup"><span data-stu-id="2390c-147">Example value: 22.</span></span>| 
| <span data-ttu-id="2390c-148">Content-Type</span><span class="sxs-lookup"><span data-stu-id="2390c-148">Content-Type</span></span>| <span data-ttu-id="2390c-149">[String]。</span><span class="sxs-lookup"><span data-stu-id="2390c-149">String.</span></span> <span data-ttu-id="2390c-150">要求の本体の MIME の種類です。</span><span class="sxs-lookup"><span data-stu-id="2390c-150">MIME type of the request body.</span></span> <span data-ttu-id="2390c-151"><b>アプリケーションと json</b>でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="2390c-151">This must be <b>application/json</b>.</span></span>| 
  
<a id="ID4EBE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="2390c-152">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2390c-152">Optional Request Headers</span></span>
 
| <span data-ttu-id="2390c-153">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2390c-153">Header</span></span>| <span data-ttu-id="2390c-154">説明</span><span class="sxs-lookup"><span data-stu-id="2390c-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2390c-155">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="2390c-155">X-RequestedServiceVersion</span></span>| <span data-ttu-id="2390c-156">Xbox LIVE サービスは、この要求を送信するのには、名または番号を作成します。</span><span class="sxs-lookup"><span data-stu-id="2390c-156">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="2390c-157">要求は、ヘッダー、認証トークンなどの要求の妥当性を確認した後、そのサービスにのみルーティングされます。既定値: 1。</span><span class="sxs-lookup"><span data-stu-id="2390c-157">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="2390c-158">Accept</span><span class="sxs-lookup"><span data-stu-id="2390c-158">Accept</span></span>| <span data-ttu-id="2390c-159">[String]。</span><span class="sxs-lookup"><span data-stu-id="2390c-159">String.</span></span> <span data-ttu-id="2390c-160">コンテンツ タイプの応答で呼び出し元を受け入れる。</span><span class="sxs-lookup"><span data-stu-id="2390c-160">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="2390c-161">すべての応答は、<b>アプリケーションまたは json</b>です。</span><span class="sxs-lookup"><span data-stu-id="2390c-161">All responses are <b>application/json</b>.</span></span>| 
  
<a id="ID4EHF"></a>

 
## <a name="request-body"></a><span data-ttu-id="2390c-162">要求本文</span><span class="sxs-lookup"><span data-stu-id="2390c-162">Request body</span></span>
 
<a id="ID4ENF"></a>

 
### <a name="required-members"></a><span data-ttu-id="2390c-163">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="2390c-163">Required members</span></span>
 
| <span data-ttu-id="2390c-164">メンバー</span><span class="sxs-lookup"><span data-stu-id="2390c-164">Member</span></span>| <span data-ttu-id="2390c-165">説明</span><span class="sxs-lookup"><span data-stu-id="2390c-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2390c-166">XuidList</span><span class="sxs-lookup"><span data-stu-id="2390c-166">XuidList</span></span>| <span data-ttu-id="2390c-167">呼び出し元のユーザーのコレクションから返されるユーザーを識別する Xuid の配列です。</span><span class="sxs-lookup"><span data-stu-id="2390c-167">Array of XUIDs that identify the people to be returned from the caller's people collection.</span></span> <span data-ttu-id="2390c-168">[XuidList (JSON)](../../json/json-xuidlist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2390c-168">See [XuidList (JSON)](../../json/json-xuidlist.md).</span></span>| 
  
<a id="ID4EKG"></a>

 
### <a name="optional-members"></a><span data-ttu-id="2390c-169">省略可能なメンバー</span><span class="sxs-lookup"><span data-stu-id="2390c-169">Optional members</span></span>
 
<span data-ttu-id="2390c-170">この要求に対して省略可能なメンバーはありません。</span><span class="sxs-lookup"><span data-stu-id="2390c-170">There are no optional members for this request.</span></span>
  
<a id="ID4EVG"></a>

 
### <a name="prohibited-members"></a><span data-ttu-id="2390c-171">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="2390c-171">Prohibited members</span></span>
 
<span data-ttu-id="2390c-172">要求では、他のすべてのメンバーは禁止されています。</span><span class="sxs-lookup"><span data-stu-id="2390c-172">All other members are prohibited in a request.</span></span>
  
<a id="ID4EAH"></a>

 
### <a name="sample-request"></a><span data-ttu-id="2390c-173">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="2390c-173">Sample request</span></span>
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="2390c-174">HTTP ステータス ・ コード</span><span class="sxs-lookup"><span data-stu-id="2390c-174">HTTP status codes</span></span>
 
<span data-ttu-id="2390c-175">サービスは、このリソースにこのメソッドを使用して行われた要求への応答では、このセクションのステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="2390c-175">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="2390c-176">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧については、[標準的な HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2390c-176">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="2390c-177">コード</span><span class="sxs-lookup"><span data-stu-id="2390c-177">Code</span></span>| <span data-ttu-id="2390c-178">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="2390c-178">Reason phrase</span></span>| <span data-ttu-id="2390c-179">説明</span><span class="sxs-lookup"><span data-stu-id="2390c-179">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2390c-180">200</span><span class="sxs-lookup"><span data-stu-id="2390c-180">200</span></span>| <span data-ttu-id="2390c-181">OK</span><span class="sxs-lookup"><span data-stu-id="2390c-181">OK</span></span>| <span data-ttu-id="2390c-182">"Get"メソッドは、するときに成功します。</span><span class="sxs-lookup"><span data-stu-id="2390c-182">Success when method is "get".</span></span>| 
| <span data-ttu-id="2390c-183">204</span><span class="sxs-lookup"><span data-stu-id="2390c-183">204</span></span>| <span data-ttu-id="2390c-184">コンテンツはありません。</span><span class="sxs-lookup"><span data-stu-id="2390c-184">No Content</span></span>| <span data-ttu-id="2390c-185">成功がメソッドの追加] または [削除] します。</span><span class="sxs-lookup"><span data-stu-id="2390c-185">Success when method is "add" or "remove".</span></span>| 
| <span data-ttu-id="2390c-186">400</span><span class="sxs-lookup"><span data-stu-id="2390c-186">400</span></span>| <span data-ttu-id="2390c-187">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="2390c-187">Bad Request</span></span>| <span data-ttu-id="2390c-188">メソッドのパラメーターが指定されてないか、または形式が正しくない、またはユーザー Id の形式が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="2390c-188">Method parameter was missing or malformed, or user IDs were malformed.</span></span>| 
| <span data-ttu-id="2390c-189">403</span><span class="sxs-lookup"><span data-stu-id="2390c-189">403</span></span>| <span data-ttu-id="2390c-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="2390c-190">Forbidden</span></span>| <span data-ttu-id="2390c-191">承認ヘッダーの XUID の要求を解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="2390c-191">XUID claim could not be parsed from the authorization header.</span></span>| 
  
<a id="ID4ENBAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="2390c-192">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2390c-192">Required Response Headers</span></span>
 
| <span data-ttu-id="2390c-193">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2390c-193">Header</span></span>| <span data-ttu-id="2390c-194">型</span><span class="sxs-lookup"><span data-stu-id="2390c-194">Type</span></span>| <span data-ttu-id="2390c-195">説明</span><span class="sxs-lookup"><span data-stu-id="2390c-195">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2390c-196">Content-Length</span><span class="sxs-lookup"><span data-stu-id="2390c-196">Content-Length</span></span>| <span data-ttu-id="2390c-197">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="2390c-197">32-bit unsigned integer</span></span>| <span data-ttu-id="2390c-198">長さをバイト単位で、応答の本体です。</span><span class="sxs-lookup"><span data-stu-id="2390c-198">Length, in bytes, of the response body.</span></span> <span data-ttu-id="2390c-199">値の例: 22 です。</span><span class="sxs-lookup"><span data-stu-id="2390c-199">Example value: 22.</span></span>| 
| <span data-ttu-id="2390c-200">Content-Type</span><span class="sxs-lookup"><span data-stu-id="2390c-200">Content-Type</span></span>| <span data-ttu-id="2390c-201">string</span><span class="sxs-lookup"><span data-stu-id="2390c-201">string</span></span>| <span data-ttu-id="2390c-202">応答本体の MIME の種類です。</span><span class="sxs-lookup"><span data-stu-id="2390c-202">MIME type of the response body.</span></span> <span data-ttu-id="2390c-203">常に<b>アプリケーションまたは json</b>になります。</span><span class="sxs-lookup"><span data-stu-id="2390c-203">This will always be <b>application/json</b>.</span></span>| 
  
<a id="ID4EZCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="2390c-204">応答本文</span><span class="sxs-lookup"><span data-stu-id="2390c-204">Response body</span></span>
 
<span data-ttu-id="2390c-205">応答の本体は、"get"要求のメソッドは、ときにのみ送信されます。</span><span class="sxs-lookup"><span data-stu-id="2390c-205">A response body is only sent when the request method is "get".</span></span> <span data-ttu-id="2390c-206">追加] または [削除] の応答の本体がありません。</span><span class="sxs-lookup"><span data-stu-id="2390c-206">There is no response body for "add" or "remove".</span></span>
 
<span data-ttu-id="2390c-207">"Get"メソッドの呼び出しが成功した場合は、サービスはコレクション、および呼び出し元のユーザーのコレクションを格納した配列、呼び出し元のユーザーにユーザーの合計数を返します。</span><span class="sxs-lookup"><span data-stu-id="2390c-207">If a "get" method call is successful, the service returns the total number of people in the caller's people collection, and an array containing the caller's people collection.</span></span> <span data-ttu-id="2390c-208">メソッドの追加] および [削除] の応答は返されません。</span><span class="sxs-lookup"><span data-stu-id="2390c-208">No response is returned for "add" and "remove" methods.</span></span> <span data-ttu-id="2390c-209">[PeopleList (JSON)](../../json/json-peoplelist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2390c-209">See [PeopleList (JSON)](../../json/json-peoplelist.md).</span></span>
 
<a id="ID4EHDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="2390c-210">応答の例</span><span class="sxs-lookup"><span data-stu-id="2390c-210">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="2390c-211">関連項目</span><span class="sxs-lookup"><span data-stu-id="2390c-211">See also</span></span>
 
<a id="ID4ETDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2390c-212">Parent</span><span class="sxs-lookup"><span data-stu-id="2390c-212">Parent</span></span> 

[<span data-ttu-id="2390c-213">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="2390c-213">/users/{ownerId}/people/xuids</span></span>](uri-usersowneridpeoplexuids.md)

   