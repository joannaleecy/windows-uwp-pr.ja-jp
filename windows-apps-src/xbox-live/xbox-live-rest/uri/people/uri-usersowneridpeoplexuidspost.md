---
title: POST (/users/{ownerId}/ユーザー/xuid)
assetID: e20bfb58-9c3b-14ed-6462-85d42fa6fe1a
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuidspost.html
author: KevinAsgari
description: " POST (/users/{ownerId}/ユーザー/xuid)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 27fbc0e209439fca01cf1e7d8c7c3bf98c4b9053
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881661"
---
# <a name="post-usersowneridpeoplexuids"></a><span data-ttu-id="ed79c-104">POST (/users/{ownerId}/ユーザー/xuid)</span><span class="sxs-lookup"><span data-stu-id="ed79c-104">POST (/users/{ownerId}/people/xuids)</span></span>
<span data-ttu-id="ed79c-105">呼び出し元のユーザーからコレクションに対応する XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-105">Gets people by XUID from caller's people collection.</span></span> <span data-ttu-id="ed79c-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ed79c-107">注釈</span><span class="sxs-lookup"><span data-stu-id="ed79c-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="ed79c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed79c-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="ed79c-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="ed79c-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="ed79c-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed79c-110">Required Request Headers</span></span>](#ID4ERC)
  * [<span data-ttu-id="ed79c-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed79c-111">Optional Request Headers</span></span>](#ID4EBE)
  * [<span data-ttu-id="ed79c-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="ed79c-112">Request body</span></span>](#ID4EHF)
  * [<span data-ttu-id="ed79c-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ed79c-113">HTTP status codes</span></span>](#ID4EKH)
  * [<span data-ttu-id="ed79c-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed79c-114">Required Response Headers</span></span>](#ID4ENBAC)
  * [<span data-ttu-id="ed79c-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="ed79c-115">Response body</span></span>](#ID4EZCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="ed79c-116">注釈</span><span class="sxs-lookup"><span data-stu-id="ed79c-116">Remarks</span></span>
 
<span data-ttu-id="ed79c-117">POST ので、これは、同じ結果に 1 回または複数回実行している場合、操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="ed79c-117">POST operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ed79c-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed79c-118">URI parameters</span></span>
 
| <span data-ttu-id="ed79c-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed79c-119">Parameter</span></span>| <span data-ttu-id="ed79c-120">型</span><span class="sxs-lookup"><span data-stu-id="ed79c-120">Type</span></span>| <span data-ttu-id="ed79c-121">説明</span><span class="sxs-lookup"><span data-stu-id="ed79c-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ed79c-122">ownerId</span><span class="sxs-lookup"><span data-stu-id="ed79c-122">ownerId</span></span>| <span data-ttu-id="ed79c-123">string</span><span class="sxs-lookup"><span data-stu-id="ed79c-123">string</span></span>| <span data-ttu-id="ed79c-124">そのリソースにアクセスしているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="ed79c-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="ed79c-125">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed79c-125">Must match the authenticated user.</span></span> <span data-ttu-id="ed79c-126">設定可能な値とは、"me"、だけ、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="ed79c-126">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="ed79c-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="ed79c-127">Authorization</span></span>
 
| <span data-ttu-id="ed79c-128">型</span><span class="sxs-lookup"><span data-stu-id="ed79c-128">Type</span></span>| <span data-ttu-id="ed79c-129">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="ed79c-129">Required</span></span>| <span data-ttu-id="ed79c-130">説明</span><span class="sxs-lookup"><span data-stu-id="ed79c-130">Description</span></span>| <span data-ttu-id="ed79c-131">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="ed79c-131">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ed79c-132">XUID</span><span class="sxs-lookup"><span data-stu-id="ed79c-132">XUID</span></span>| <span data-ttu-id="ed79c-133">必須</span><span class="sxs-lookup"><span data-stu-id="ed79c-133">yes</span></span>| <span data-ttu-id="ed79c-134">呼び出し元では、ユーザーの Xbox ユーザー ID (XUID) があります。</span><span class="sxs-lookup"><span data-stu-id="ed79c-134">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="ed79c-135">401 承認されていません。</span><span class="sxs-lookup"><span data-stu-id="ed79c-135">401 Unauthorized</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="ed79c-136">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed79c-136">Required Request Headers</span></span>
 
| <span data-ttu-id="ed79c-137">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed79c-137">Header</span></span>| <span data-ttu-id="ed79c-138">説明</span><span class="sxs-lookup"><span data-stu-id="ed79c-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ed79c-139">Authorization</span><span class="sxs-lookup"><span data-stu-id="ed79c-139">Authorization</span></span>| <span data-ttu-id="ed79c-140">[String]。</span><span class="sxs-lookup"><span data-stu-id="ed79c-140">String.</span></span> <span data-ttu-id="ed79c-141">Xbox LIVE のデータを承認します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-141">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="ed79c-142">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="ed79c-142">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="ed79c-143">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-143">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>| 
| <span data-ttu-id="ed79c-144">Content-Length</span><span class="sxs-lookup"><span data-stu-id="ed79c-144">Content-Length</span></span>| <span data-ttu-id="ed79c-145">32 ビットの符号なし整数。</span><span class="sxs-lookup"><span data-stu-id="ed79c-145">32-bit unsigned integer.</span></span> <span data-ttu-id="ed79c-146">、バイトで、要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="ed79c-146">Length, in bytes, of the request body.</span></span> <span data-ttu-id="ed79c-147">値の例: 22 します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-147">Example value: 22.</span></span>| 
| <span data-ttu-id="ed79c-148">Content-Type</span><span class="sxs-lookup"><span data-stu-id="ed79c-148">Content-Type</span></span>| <span data-ttu-id="ed79c-149">[String]。</span><span class="sxs-lookup"><span data-stu-id="ed79c-149">String.</span></span> <span data-ttu-id="ed79c-150">要求本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="ed79c-150">MIME type of the request body.</span></span> <span data-ttu-id="ed79c-151">これは、<b>アプリケーション/json</b>でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="ed79c-151">This must be <b>application/json</b>.</span></span>| 
  
<a id="ID4EBE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="ed79c-152">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed79c-152">Optional Request Headers</span></span>
 
| <span data-ttu-id="ed79c-153">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed79c-153">Header</span></span>| <span data-ttu-id="ed79c-154">説明</span><span class="sxs-lookup"><span data-stu-id="ed79c-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ed79c-155">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="ed79c-155">X-RequestedServiceVersion</span></span>| <span data-ttu-id="ed79c-156">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="ed79c-156">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="ed79c-157">要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="ed79c-157">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="ed79c-158">Accept</span><span class="sxs-lookup"><span data-stu-id="ed79c-158">Accept</span></span>| <span data-ttu-id="ed79c-159">[String]。</span><span class="sxs-lookup"><span data-stu-id="ed79c-159">String.</span></span> <span data-ttu-id="ed79c-160">コンテンツ タイプを呼び出し元が、応答で受け取る。</span><span class="sxs-lookup"><span data-stu-id="ed79c-160">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="ed79c-161">すべての応答では、<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-161">All responses are <b>application/json</b>.</span></span>| 
  
<a id="ID4EHF"></a>

 
## <a name="request-body"></a><span data-ttu-id="ed79c-162">要求本文</span><span class="sxs-lookup"><span data-stu-id="ed79c-162">Request body</span></span>
 
<a id="ID4ENF"></a>

 
### <a name="required-members"></a><span data-ttu-id="ed79c-163">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="ed79c-163">Required members</span></span>
 
| <span data-ttu-id="ed79c-164">メンバー</span><span class="sxs-lookup"><span data-stu-id="ed79c-164">Member</span></span>| <span data-ttu-id="ed79c-165">説明</span><span class="sxs-lookup"><span data-stu-id="ed79c-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ed79c-166">XuidList</span><span class="sxs-lookup"><span data-stu-id="ed79c-166">XuidList</span></span>| <span data-ttu-id="ed79c-167">呼び出し元のユーザーのコレクションから返される人を識別する Xuid の配列です。</span><span class="sxs-lookup"><span data-stu-id="ed79c-167">Array of XUIDs that identify the people to be returned from the caller's people collection.</span></span> <span data-ttu-id="ed79c-168">[XuidList (JSON)](../../json/json-xuidlist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ed79c-168">See [XuidList (JSON)](../../json/json-xuidlist.md).</span></span>| 
  
<a id="ID4EKG"></a>

 
### <a name="optional-members"></a><span data-ttu-id="ed79c-169">省略可能なメンバー</span><span class="sxs-lookup"><span data-stu-id="ed79c-169">Optional members</span></span>
 
<span data-ttu-id="ed79c-170">この要求のオプションのメンバーはありません。</span><span class="sxs-lookup"><span data-stu-id="ed79c-170">There are no optional members for this request.</span></span>
  
<a id="ID4EVG"></a>

 
### <a name="prohibited-members"></a><span data-ttu-id="ed79c-171">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="ed79c-171">Prohibited members</span></span>
 
<span data-ttu-id="ed79c-172">要求では、他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="ed79c-172">All other members are prohibited in a request.</span></span>
  
<a id="ID4EAH"></a>

 
### <a name="sample-request"></a><span data-ttu-id="ed79c-173">要求の例</span><span class="sxs-lookup"><span data-stu-id="ed79c-173">Sample request</span></span>
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="ed79c-174">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ed79c-174">HTTP status codes</span></span>
 
<span data-ttu-id="ed79c-175">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-175">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="ed79c-176">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ed79c-176">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="ed79c-177">コード</span><span class="sxs-lookup"><span data-stu-id="ed79c-177">Code</span></span>| <span data-ttu-id="ed79c-178">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="ed79c-178">Reason phrase</span></span>| <span data-ttu-id="ed79c-179">説明</span><span class="sxs-lookup"><span data-stu-id="ed79c-179">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ed79c-180">200</span><span class="sxs-lookup"><span data-stu-id="ed79c-180">200</span></span>| <span data-ttu-id="ed79c-181">OK</span><span class="sxs-lookup"><span data-stu-id="ed79c-181">OK</span></span>| <span data-ttu-id="ed79c-182">メソッドが「取得」は成功します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-182">Success when method is "get".</span></span>| 
| <span data-ttu-id="ed79c-183">204</span><span class="sxs-lookup"><span data-stu-id="ed79c-183">204</span></span>| <span data-ttu-id="ed79c-184">No Content</span><span class="sxs-lookup"><span data-stu-id="ed79c-184">No Content</span></span>| <span data-ttu-id="ed79c-185">成功メソッドが「追加」または「削除」します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-185">Success when method is "add" or "remove".</span></span>| 
| <span data-ttu-id="ed79c-186">400</span><span class="sxs-lookup"><span data-stu-id="ed79c-186">400</span></span>| <span data-ttu-id="ed79c-187">Bad Request</span><span class="sxs-lookup"><span data-stu-id="ed79c-187">Bad Request</span></span>| <span data-ttu-id="ed79c-188">メソッドのパラメーターが不足しているか、形式が正しくない、またはユーザー Id が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="ed79c-188">Method parameter was missing or malformed, or user IDs were malformed.</span></span>| 
| <span data-ttu-id="ed79c-189">403</span><span class="sxs-lookup"><span data-stu-id="ed79c-189">403</span></span>| <span data-ttu-id="ed79c-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="ed79c-190">Forbidden</span></span>| <span data-ttu-id="ed79c-191">承認ヘッダーに XUID クレームを解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="ed79c-191">XUID claim could not be parsed from the authorization header.</span></span>| 
  
<a id="ID4ENBAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="ed79c-192">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed79c-192">Required Response Headers</span></span>
 
| <span data-ttu-id="ed79c-193">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed79c-193">Header</span></span>| <span data-ttu-id="ed79c-194">型</span><span class="sxs-lookup"><span data-stu-id="ed79c-194">Type</span></span>| <span data-ttu-id="ed79c-195">説明</span><span class="sxs-lookup"><span data-stu-id="ed79c-195">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ed79c-196">Content-Length</span><span class="sxs-lookup"><span data-stu-id="ed79c-196">Content-Length</span></span>| <span data-ttu-id="ed79c-197">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ed79c-197">32-bit unsigned integer</span></span>| <span data-ttu-id="ed79c-198">、バイトで、応答の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="ed79c-198">Length, in bytes, of the response body.</span></span> <span data-ttu-id="ed79c-199">値の例: 22 します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-199">Example value: 22.</span></span>| 
| <span data-ttu-id="ed79c-200">Content-Type</span><span class="sxs-lookup"><span data-stu-id="ed79c-200">Content-Type</span></span>| <span data-ttu-id="ed79c-201">string</span><span class="sxs-lookup"><span data-stu-id="ed79c-201">string</span></span>| <span data-ttu-id="ed79c-202">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="ed79c-202">MIME type of the response body.</span></span> <span data-ttu-id="ed79c-203">これにより、<b>アプリケーション/json</b>は常になります。</span><span class="sxs-lookup"><span data-stu-id="ed79c-203">This will always be <b>application/json</b>.</span></span>| 
  
<a id="ID4EZCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="ed79c-204">応答本文</span><span class="sxs-lookup"><span data-stu-id="ed79c-204">Response body</span></span>
 
<span data-ttu-id="ed79c-205">応答本文は要求メソッドが「取得」の場合にのみ送信されます。</span><span class="sxs-lookup"><span data-stu-id="ed79c-205">A response body is only sent when the request method is "get".</span></span> <span data-ttu-id="ed79c-206">「追加」または「削除」の応答の本文はありません。</span><span class="sxs-lookup"><span data-stu-id="ed79c-206">There is no response body for "add" or "remove".</span></span>
 
<span data-ttu-id="ed79c-207">「取得」メソッドの呼び出しが成功した場合は、サービスはコレクション、および呼び出し元のユーザーのコレクションが含まれた配列で、呼び出し元のユーザーのユーザーの合計数を返します。</span><span class="sxs-lookup"><span data-stu-id="ed79c-207">If a "get" method call is successful, the service returns the total number of people in the caller's people collection, and an array containing the caller's people collection.</span></span> <span data-ttu-id="ed79c-208">「追加」と「削除」メソッドの応答は返されません。</span><span class="sxs-lookup"><span data-stu-id="ed79c-208">No response is returned for "add" and "remove" methods.</span></span> <span data-ttu-id="ed79c-209">[PeopleList (JSON)](../../json/json-peoplelist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ed79c-209">See [PeopleList (JSON)](../../json/json-peoplelist.md).</span></span>
 
<a id="ID4EHDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="ed79c-210">応答の例</span><span class="sxs-lookup"><span data-stu-id="ed79c-210">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="ed79c-211">関連項目</span><span class="sxs-lookup"><span data-stu-id="ed79c-211">See also</span></span>
 
<a id="ID4ETDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ed79c-212">Parent</span><span class="sxs-lookup"><span data-stu-id="ed79c-212">Parent</span></span> 

[<span data-ttu-id="ed79c-213">ユーザー/xuid/users/{ownerId}</span><span class="sxs-lookup"><span data-stu-id="ed79c-213">/users/{ownerId}/people/xuids</span></span>](uri-usersowneridpeoplexuids.md)

   