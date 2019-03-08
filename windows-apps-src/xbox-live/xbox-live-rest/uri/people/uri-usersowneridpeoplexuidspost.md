---
title: POST (/users/{ownerId}/people/xuids)
assetID: e20bfb58-9c3b-14ed-6462-85d42fa6fe1a
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuidspost.html
description: " POST (/users/{ownerId}/people/xuids)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1cb160f3276d215e3aba5dfd671c67fa17d883b5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589867"
---
# <a name="post-usersowneridpeoplexuids"></a><span data-ttu-id="3ff68-104">POST (/users/{ownerId}/people/xuids)</span><span class="sxs-lookup"><span data-stu-id="3ff68-104">POST (/users/{ownerId}/people/xuids)</span></span>
<span data-ttu-id="3ff68-105">呼び出し元のユーザーからコレクションの XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-105">Gets people by XUID from caller's people collection.</span></span> <span data-ttu-id="3ff68-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="3ff68-107">注釈</span><span class="sxs-lookup"><span data-stu-id="3ff68-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="3ff68-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ff68-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="3ff68-109">承認</span><span class="sxs-lookup"><span data-stu-id="3ff68-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="3ff68-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ff68-110">Required Request Headers</span></span>](#ID4ERC)
  * [<span data-ttu-id="3ff68-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ff68-111">Optional Request Headers</span></span>](#ID4EBE)
  * [<span data-ttu-id="3ff68-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="3ff68-112">Request body</span></span>](#ID4EHF)
  * [<span data-ttu-id="3ff68-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3ff68-113">HTTP status codes</span></span>](#ID4EKH)
  * [<span data-ttu-id="3ff68-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ff68-114">Required Response Headers</span></span>](#ID4ENBAC)
  * [<span data-ttu-id="3ff68-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="3ff68-115">Response body</span></span>](#ID4EZCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="3ff68-116">注釈</span><span class="sxs-lookup"><span data-stu-id="3ff68-116">Remarks</span></span>
 
<span data-ttu-id="3ff68-117">POST 操作はすべてのリソースを変更するはありませんので、この 1 回または複数回実行された場合、同じ結果が生成されます。</span><span class="sxs-lookup"><span data-stu-id="3ff68-117">POST operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3ff68-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ff68-118">URI parameters</span></span>
 
| <span data-ttu-id="3ff68-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ff68-119">Parameter</span></span>| <span data-ttu-id="3ff68-120">種類</span><span class="sxs-lookup"><span data-stu-id="3ff68-120">Type</span></span>| <span data-ttu-id="3ff68-121">説明</span><span class="sxs-lookup"><span data-stu-id="3ff68-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3ff68-122">ownerId</span><span class="sxs-lookup"><span data-stu-id="3ff68-122">ownerId</span></span>| <span data-ttu-id="3ff68-123">string</span><span class="sxs-lookup"><span data-stu-id="3ff68-123">string</span></span>| <span data-ttu-id="3ff68-124">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="3ff68-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="3ff68-125">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ff68-125">Must match the authenticated user.</span></span> <span data-ttu-id="3ff68-126">使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="3ff68-126">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="3ff68-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="3ff68-127">Authorization</span></span>
 
| <span data-ttu-id="3ff68-128">種類</span><span class="sxs-lookup"><span data-stu-id="3ff68-128">Type</span></span>| <span data-ttu-id="3ff68-129">必須</span><span class="sxs-lookup"><span data-stu-id="3ff68-129">Required</span></span>| <span data-ttu-id="3ff68-130">説明</span><span class="sxs-lookup"><span data-stu-id="3ff68-130">Description</span></span>| <span data-ttu-id="3ff68-131">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="3ff68-131">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3ff68-132">XUID</span><span class="sxs-lookup"><span data-stu-id="3ff68-132">XUID</span></span>| <span data-ttu-id="3ff68-133">○</span><span class="sxs-lookup"><span data-stu-id="3ff68-133">yes</span></span>| <span data-ttu-id="3ff68-134">呼び出し元が、ユーザーの Xbox ユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="3ff68-134">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="3ff68-135">401 許可されていません</span><span class="sxs-lookup"><span data-stu-id="3ff68-135">401 Unauthorized</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="3ff68-136">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ff68-136">Required Request Headers</span></span>
 
| <span data-ttu-id="3ff68-137">Header</span><span class="sxs-lookup"><span data-stu-id="3ff68-137">Header</span></span>| <span data-ttu-id="3ff68-138">説明</span><span class="sxs-lookup"><span data-stu-id="3ff68-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3ff68-139">Authorization</span><span class="sxs-lookup"><span data-stu-id="3ff68-139">Authorization</span></span>| <span data-ttu-id="3ff68-140">[String]。</span><span class="sxs-lookup"><span data-stu-id="3ff68-140">String.</span></span> <span data-ttu-id="3ff68-141">Xbox LIVE の承認データです。</span><span class="sxs-lookup"><span data-stu-id="3ff68-141">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="3ff68-142">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="3ff68-142">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="3ff68-143">値の例:<b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-143">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>| 
| <span data-ttu-id="3ff68-144">Content-Length</span><span class="sxs-lookup"><span data-stu-id="3ff68-144">Content-Length</span></span>| <span data-ttu-id="3ff68-145">32 ビット符号なし整数。</span><span class="sxs-lookup"><span data-stu-id="3ff68-145">32-bit unsigned integer.</span></span> <span data-ttu-id="3ff68-146">、(バイト単位)、要求本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="3ff68-146">Length, in bytes, of the request body.</span></span> <span data-ttu-id="3ff68-147">値の例:22.</span><span class="sxs-lookup"><span data-stu-id="3ff68-147">Example value: 22.</span></span>| 
| <span data-ttu-id="3ff68-148">Content-Type</span><span class="sxs-lookup"><span data-stu-id="3ff68-148">Content-Type</span></span>| <span data-ttu-id="3ff68-149">[String]。</span><span class="sxs-lookup"><span data-stu-id="3ff68-149">String.</span></span> <span data-ttu-id="3ff68-150">要求本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="3ff68-150">MIME type of the request body.</span></span> <span data-ttu-id="3ff68-151">これでなければなりません<b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-151">This must be <b>application/json</b>.</span></span>| 
  
<a id="ID4EBE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="3ff68-152">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ff68-152">Optional Request Headers</span></span>
 
| <span data-ttu-id="3ff68-153">Header</span><span class="sxs-lookup"><span data-stu-id="3ff68-153">Header</span></span>| <span data-ttu-id="3ff68-154">説明</span><span class="sxs-lookup"><span data-stu-id="3ff68-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3ff68-155">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="3ff68-155">X-RequestedServiceVersion</span></span>| <span data-ttu-id="3ff68-156">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="3ff68-156">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="3ff68-157">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="3ff68-157">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="3ff68-158">OK</span><span class="sxs-lookup"><span data-stu-id="3ff68-158">Accept</span></span>| <span data-ttu-id="3ff68-159">[String]。</span><span class="sxs-lookup"><span data-stu-id="3ff68-159">String.</span></span> <span data-ttu-id="3ff68-160">コンテンツ タイプを呼び出し元が応答で受け取る。</span><span class="sxs-lookup"><span data-stu-id="3ff68-160">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="3ff68-161">すべての応答は<b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-161">All responses are <b>application/json</b>.</span></span>| 
  
<a id="ID4EHF"></a>

 
## <a name="request-body"></a><span data-ttu-id="3ff68-162">要求本文</span><span class="sxs-lookup"><span data-stu-id="3ff68-162">Request body</span></span>
 
<a id="ID4ENF"></a>

 
### <a name="required-members"></a><span data-ttu-id="3ff68-163">必須メンバー</span><span class="sxs-lookup"><span data-stu-id="3ff68-163">Required members</span></span>
 
| <span data-ttu-id="3ff68-164">メンバー</span><span class="sxs-lookup"><span data-stu-id="3ff68-164">Member</span></span>| <span data-ttu-id="3ff68-165">説明</span><span class="sxs-lookup"><span data-stu-id="3ff68-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3ff68-166">XuidList</span><span class="sxs-lookup"><span data-stu-id="3ff68-166">XuidList</span></span>| <span data-ttu-id="3ff68-167">呼び出し元のユーザーのコレクションから返されるユーザーを識別する Xuid の配列。</span><span class="sxs-lookup"><span data-stu-id="3ff68-167">Array of XUIDs that identify the people to be returned from the caller's people collection.</span></span> <span data-ttu-id="3ff68-168">参照してください[XuidList (JSON)](../../json/json-xuidlist.md)します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-168">See [XuidList (JSON)](../../json/json-xuidlist.md).</span></span>| 
  
<a id="ID4EKG"></a>

 
### <a name="optional-members"></a><span data-ttu-id="3ff68-169">省略可能なメンバー</span><span class="sxs-lookup"><span data-stu-id="3ff68-169">Optional members</span></span>
 
<span data-ttu-id="3ff68-170">この要求のオプションのメンバーはありません。</span><span class="sxs-lookup"><span data-stu-id="3ff68-170">There are no optional members for this request.</span></span>
  
<a id="ID4EVG"></a>

 
### <a name="prohibited-members"></a><span data-ttu-id="3ff68-171">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="3ff68-171">Prohibited members</span></span>
 
<span data-ttu-id="3ff68-172">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="3ff68-172">All other members are prohibited in a request.</span></span>
  
<a id="ID4EAH"></a>

 
### <a name="sample-request"></a><span data-ttu-id="3ff68-173">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="3ff68-173">Sample request</span></span>
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="3ff68-174">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3ff68-174">HTTP status codes</span></span>
 
<span data-ttu-id="3ff68-175">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-175">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="3ff68-176">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-176">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="3ff68-177">コード</span><span class="sxs-lookup"><span data-stu-id="3ff68-177">Code</span></span>| <span data-ttu-id="3ff68-178">理由語句</span><span class="sxs-lookup"><span data-stu-id="3ff68-178">Reason phrase</span></span>| <span data-ttu-id="3ff68-179">説明</span><span class="sxs-lookup"><span data-stu-id="3ff68-179">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3ff68-180">200</span><span class="sxs-lookup"><span data-stu-id="3ff68-180">200</span></span>| <span data-ttu-id="3ff68-181">OK</span><span class="sxs-lookup"><span data-stu-id="3ff68-181">OK</span></span>| <span data-ttu-id="3ff68-182">メソッドは"get"時に成功しました。</span><span class="sxs-lookup"><span data-stu-id="3ff68-182">Success when method is "get".</span></span>| 
| <span data-ttu-id="3ff68-183">204</span><span class="sxs-lookup"><span data-stu-id="3ff68-183">204</span></span>| <span data-ttu-id="3ff68-184">コンテンツはありません</span><span class="sxs-lookup"><span data-stu-id="3ff68-184">No Content</span></span>| <span data-ttu-id="3ff68-185">成功メソッドが「追加」または"remove"します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-185">Success when method is "add" or "remove".</span></span>| 
| <span data-ttu-id="3ff68-186">400</span><span class="sxs-lookup"><span data-stu-id="3ff68-186">400</span></span>| <span data-ttu-id="3ff68-187">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="3ff68-187">Bad Request</span></span>| <span data-ttu-id="3ff68-188">メソッドのパラメーターがないか、形式が正しくない、またはユーザー Id が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="3ff68-188">Method parameter was missing or malformed, or user IDs were malformed.</span></span>| 
| <span data-ttu-id="3ff68-189">403</span><span class="sxs-lookup"><span data-stu-id="3ff68-189">403</span></span>| <span data-ttu-id="3ff68-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="3ff68-190">Forbidden</span></span>| <span data-ttu-id="3ff68-191">Authorization ヘッダーから XUID 要求を解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="3ff68-191">XUID claim could not be parsed from the authorization header.</span></span>| 
  
<a id="ID4ENBAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="3ff68-192">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ff68-192">Required Response Headers</span></span>
 
| <span data-ttu-id="3ff68-193">Header</span><span class="sxs-lookup"><span data-stu-id="3ff68-193">Header</span></span>| <span data-ttu-id="3ff68-194">種類</span><span class="sxs-lookup"><span data-stu-id="3ff68-194">Type</span></span>| <span data-ttu-id="3ff68-195">説明</span><span class="sxs-lookup"><span data-stu-id="3ff68-195">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3ff68-196">Content-Length</span><span class="sxs-lookup"><span data-stu-id="3ff68-196">Content-Length</span></span>| <span data-ttu-id="3ff68-197">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3ff68-197">32-bit unsigned integer</span></span>| <span data-ttu-id="3ff68-198">長さをバイト単位で、応答本文。</span><span class="sxs-lookup"><span data-stu-id="3ff68-198">Length, in bytes, of the response body.</span></span> <span data-ttu-id="3ff68-199">値の例:22.</span><span class="sxs-lookup"><span data-stu-id="3ff68-199">Example value: 22.</span></span>| 
| <span data-ttu-id="3ff68-200">Content-Type</span><span class="sxs-lookup"><span data-stu-id="3ff68-200">Content-Type</span></span>| <span data-ttu-id="3ff68-201">string</span><span class="sxs-lookup"><span data-stu-id="3ff68-201">string</span></span>| <span data-ttu-id="3ff68-202">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="3ff68-202">MIME type of the response body.</span></span> <span data-ttu-id="3ff68-203">常に<b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-203">This will always be <b>application/json</b>.</span></span>| 
  
<a id="ID4EZCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="3ff68-204">応答本文</span><span class="sxs-lookup"><span data-stu-id="3ff68-204">Response body</span></span>
 
<span data-ttu-id="3ff68-205">要求メソッドは"get"と応答本文はのみ送信されます。</span><span class="sxs-lookup"><span data-stu-id="3ff68-205">A response body is only sent when the request method is "get".</span></span> <span data-ttu-id="3ff68-206">「追加」または「削除」の応答本文はありません。</span><span class="sxs-lookup"><span data-stu-id="3ff68-206">There is no response body for "add" or "remove".</span></span>
 
<span data-ttu-id="3ff68-207">"Get"メソッドの呼び出しが成功した場合、サービスはコレクション、および呼び出し元のユーザー コレクションを格納する配列、呼び出し元のユーザーのユーザーの合計数を返します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-207">If a "get" method call is successful, the service returns the total number of people in the caller's people collection, and an array containing the caller's people collection.</span></span> <span data-ttu-id="3ff68-208">"Add"および"remove"メソッドの応答は返されません。</span><span class="sxs-lookup"><span data-stu-id="3ff68-208">No response is returned for "add" and "remove" methods.</span></span> <span data-ttu-id="3ff68-209">参照してください[PeopleList (JSON)](../../json/json-peoplelist.md)します。</span><span class="sxs-lookup"><span data-stu-id="3ff68-209">See [PeopleList (JSON)](../../json/json-peoplelist.md).</span></span>
 
<a id="ID4EHDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="3ff68-210">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="3ff68-210">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="3ff68-211">関連項目</span><span class="sxs-lookup"><span data-stu-id="3ff68-211">See also</span></span>
 
<a id="ID4ETDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3ff68-212">Parent</span><span class="sxs-lookup"><span data-stu-id="3ff68-212">Parent</span></span> 

[<span data-ttu-id="3ff68-213">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="3ff68-213">/users/{ownerId}/people/xuids</span></span>](uri-usersowneridpeoplexuids.md)

   