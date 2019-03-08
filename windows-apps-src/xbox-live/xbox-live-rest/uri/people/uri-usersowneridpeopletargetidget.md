---
title: GET (/users/{ownerId}/people/{targetid})
assetID: 2fd37b8e-b886-14f2-3399-59f530d85e4e
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopletargetidget.html
description: " GET (/users/{ownerId}/people/{targetid})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 408b4df30f53e27b04e2a1e654e9686d2b359637
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632677"
---
# <a name="get-usersowneridpeopletargetid"></a><span data-ttu-id="85b85-104">GET (/users/{ownerId}/people/{targetid})</span><span class="sxs-lookup"><span data-stu-id="85b85-104">GET (/users/{ownerId}/people/{targetid})</span></span>
<span data-ttu-id="85b85-105">呼び出し元のユーザーのコレクションからターゲットの ID でユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="85b85-105">Gets a person by target ID from caller's people collection.</span></span> <span data-ttu-id="85b85-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="85b85-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="85b85-107">注釈</span><span class="sxs-lookup"><span data-stu-id="85b85-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="85b85-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="85b85-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="85b85-109">承認</span><span class="sxs-lookup"><span data-stu-id="85b85-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="85b85-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="85b85-110">Required Request Headers</span></span>](#ID4ERC)
  * [<span data-ttu-id="85b85-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="85b85-111">Optional Request Headers</span></span>](#ID4EQD)
  * [<span data-ttu-id="85b85-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="85b85-112">Request body</span></span>](#ID4EWE)
  * [<span data-ttu-id="85b85-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="85b85-113">HTTP status codes</span></span>](#ID4EBF)
  * [<span data-ttu-id="85b85-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="85b85-114">Required Response Headers</span></span>](#ID4EDH)
  * [<span data-ttu-id="85b85-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="85b85-115">Response body</span></span>](#ID4EQAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="85b85-116">注釈</span><span class="sxs-lookup"><span data-stu-id="85b85-116">Remarks</span></span>
 
<span data-ttu-id="85b85-117">GET 操作は、この 1 回または複数回実行された場合、同じ結果が生成されますのですべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="85b85-117">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="85b85-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="85b85-118">URI parameters</span></span>
 
| <span data-ttu-id="85b85-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="85b85-119">Parameter</span></span>| <span data-ttu-id="85b85-120">種類</span><span class="sxs-lookup"><span data-stu-id="85b85-120">Type</span></span>| <span data-ttu-id="85b85-121">説明</span><span class="sxs-lookup"><span data-stu-id="85b85-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="85b85-122">ownerId</span><span class="sxs-lookup"><span data-stu-id="85b85-122">ownerId</span></span>| <span data-ttu-id="85b85-123">string</span><span class="sxs-lookup"><span data-stu-id="85b85-123">string</span></span>| <span data-ttu-id="85b85-124">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="85b85-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="85b85-125">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b85-125">Must match the authenticated user.</span></span> <span data-ttu-id="85b85-126">使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="85b85-126">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="85b85-127">targetid</span><span class="sxs-lookup"><span data-stu-id="85b85-127">targetid</span></span>| <span data-ttu-id="85b85-128">string</span><span class="sxs-lookup"><span data-stu-id="85b85-128">string</span></span>| <span data-ttu-id="85b85-129">所有者の連絡先リスト、Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからデータを取得するユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="85b85-129">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="85b85-130">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="85b85-130">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="85b85-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="85b85-131">Authorization</span></span>
 
| <span data-ttu-id="85b85-132">種類</span><span class="sxs-lookup"><span data-stu-id="85b85-132">Type</span></span>| <span data-ttu-id="85b85-133">必須</span><span class="sxs-lookup"><span data-stu-id="85b85-133">Required</span></span>| <span data-ttu-id="85b85-134">説明</span><span class="sxs-lookup"><span data-stu-id="85b85-134">Description</span></span>| <span data-ttu-id="85b85-135">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="85b85-135">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="85b85-136">XUID</span><span class="sxs-lookup"><span data-stu-id="85b85-136">XUID</span></span>| <span data-ttu-id="85b85-137">○</span><span class="sxs-lookup"><span data-stu-id="85b85-137">yes</span></span>| <span data-ttu-id="85b85-138">呼び出し元が、ユーザーの Xbox ユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="85b85-138">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="85b85-139">401 許可されていません</span><span class="sxs-lookup"><span data-stu-id="85b85-139">401 Unauthorized</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="85b85-140">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="85b85-140">Required Request Headers</span></span>
 
| <span data-ttu-id="85b85-141">Header</span><span class="sxs-lookup"><span data-stu-id="85b85-141">Header</span></span>| <span data-ttu-id="85b85-142">説明</span><span class="sxs-lookup"><span data-stu-id="85b85-142">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="85b85-143">Authorization</span><span class="sxs-lookup"><span data-stu-id="85b85-143">Authorization</span></span>| <span data-ttu-id="85b85-144">[String]。</span><span class="sxs-lookup"><span data-stu-id="85b85-144">String.</span></span> <span data-ttu-id="85b85-145">Xbox LIVE の承認データです。</span><span class="sxs-lookup"><span data-stu-id="85b85-145">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="85b85-146">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="85b85-146">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="85b85-147">値の例:<b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。</span><span class="sxs-lookup"><span data-stu-id="85b85-147">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="85b85-148">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="85b85-148">Optional Request Headers</span></span>
 
| <span data-ttu-id="85b85-149">Header</span><span class="sxs-lookup"><span data-stu-id="85b85-149">Header</span></span>| <span data-ttu-id="85b85-150">説明</span><span class="sxs-lookup"><span data-stu-id="85b85-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="85b85-151">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="85b85-151">X-RequestedServiceVersion</span></span>| <span data-ttu-id="85b85-152">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="85b85-152">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="85b85-153">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="85b85-153">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="85b85-154">OK</span><span class="sxs-lookup"><span data-stu-id="85b85-154">Accept</span></span>| <span data-ttu-id="85b85-155">[String]。</span><span class="sxs-lookup"><span data-stu-id="85b85-155">String.</span></span> <span data-ttu-id="85b85-156">コンテンツ タイプを呼び出し元が応答で受け取る。</span><span class="sxs-lookup"><span data-stu-id="85b85-156">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="85b85-157">すべての応答は<b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="85b85-157">All responses are <b>application/json</b>.</span></span>| 
  
<a id="ID4EWE"></a>

 
## <a name="request-body"></a><span data-ttu-id="85b85-158">要求本文</span><span class="sxs-lookup"><span data-stu-id="85b85-158">Request body</span></span>
 
<span data-ttu-id="85b85-159">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="85b85-159">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="85b85-160">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="85b85-160">HTTP status codes</span></span>
 
<span data-ttu-id="85b85-161">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="85b85-161">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="85b85-162">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="85b85-162">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="85b85-163">コード</span><span class="sxs-lookup"><span data-stu-id="85b85-163">Code</span></span>| <span data-ttu-id="85b85-164">理由語句</span><span class="sxs-lookup"><span data-stu-id="85b85-164">Reason phrase</span></span>| <span data-ttu-id="85b85-165">説明</span><span class="sxs-lookup"><span data-stu-id="85b85-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="85b85-166">200</span><span class="sxs-lookup"><span data-stu-id="85b85-166">200</span></span>| <span data-ttu-id="85b85-167">OK</span><span class="sxs-lookup"><span data-stu-id="85b85-167">OK</span></span>| <span data-ttu-id="85b85-168">成功しました。</span><span class="sxs-lookup"><span data-stu-id="85b85-168">Success.</span></span>| 
| <span data-ttu-id="85b85-169">400</span><span class="sxs-lookup"><span data-stu-id="85b85-169">400</span></span>| <span data-ttu-id="85b85-170">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="85b85-170">Bad Request</span></span>| <span data-ttu-id="85b85-171">ユーザー Id は、形式が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="85b85-171">User IDs were malformed.</span></span>| 
| <span data-ttu-id="85b85-172">403</span><span class="sxs-lookup"><span data-stu-id="85b85-172">403</span></span>| <span data-ttu-id="85b85-173">Forbidden</span><span class="sxs-lookup"><span data-stu-id="85b85-173">Forbidden</span></span>| <span data-ttu-id="85b85-174">Authorization ヘッダーから XUID 要求を解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="85b85-174">XUID claim could not be parsed from the authorization header.</span></span>| 
| <span data-ttu-id="85b85-175">404</span><span class="sxs-lookup"><span data-stu-id="85b85-175">404</span></span>| <span data-ttu-id="85b85-176">検出不可</span><span class="sxs-lookup"><span data-stu-id="85b85-176">Not Found</span></span>| <span data-ttu-id="85b85-177">ターゲット ユーザーは、所有者のユーザー の一覧で見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="85b85-177">Target user was not found in the owner's People list.</span></span>| 
  
<a id="ID4EDH"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="85b85-178">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="85b85-178">Required Response Headers</span></span>
 
| <span data-ttu-id="85b85-179">Header</span><span class="sxs-lookup"><span data-stu-id="85b85-179">Header</span></span>| <span data-ttu-id="85b85-180">種類</span><span class="sxs-lookup"><span data-stu-id="85b85-180">Type</span></span>| <span data-ttu-id="85b85-181">説明</span><span class="sxs-lookup"><span data-stu-id="85b85-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="85b85-182">Content-Length</span><span class="sxs-lookup"><span data-stu-id="85b85-182">Content-Length</span></span>| <span data-ttu-id="85b85-183">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="85b85-183">32-bit unsigned integer</span></span>| <span data-ttu-id="85b85-184">長さをバイト単位で、応答本文。</span><span class="sxs-lookup"><span data-stu-id="85b85-184">Length, in bytes, of the response body.</span></span> <span data-ttu-id="85b85-185">値の例:22.</span><span class="sxs-lookup"><span data-stu-id="85b85-185">Example value: 22.</span></span>| 
| <span data-ttu-id="85b85-186">Content-Type</span><span class="sxs-lookup"><span data-stu-id="85b85-186">Content-Type</span></span>| <span data-ttu-id="85b85-187">string</span><span class="sxs-lookup"><span data-stu-id="85b85-187">string</span></span>| <span data-ttu-id="85b85-188">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="85b85-188">MIME type of the response body.</span></span> <span data-ttu-id="85b85-189">常に<b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="85b85-189">This will always be <b>application/json</b>.</span></span>| 
  
<a id="ID4EQAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="85b85-190">応答本文</span><span class="sxs-lookup"><span data-stu-id="85b85-190">Response body</span></span>
 
<span data-ttu-id="85b85-191">呼び出しが成功した場合、サービスは、ターゲット ユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="85b85-191">If the call is successful, the service returns the target person.</span></span> <span data-ttu-id="85b85-192">参照してください[人 (JSON)](../../json/json-person.md)します。</span><span class="sxs-lookup"><span data-stu-id="85b85-192">See [Person (JSON)](../../json/json-person.md).</span></span>
 
<a id="ID4E3AAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="85b85-193">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="85b85-193">Sample response</span></span>
 

```cpp
{
    "xuid": "2603643534573581",
    "isFavorite": false,
    "isFollowingCaller": false,
    "socialNetworks": ["LegacyXboxLive"]
}
         
```

   
<a id="ID4EGBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="85b85-194">関連項目</span><span class="sxs-lookup"><span data-stu-id="85b85-194">See also</span></span>
 
<a id="ID4EIBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="85b85-195">Parent</span><span class="sxs-lookup"><span data-stu-id="85b85-195">Parent</span></span> 

[<span data-ttu-id="85b85-196">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="85b85-196">/users/{ownerId}/people/{targetid}</span></span>](uri-usersowneridpeopletargetid.md)

   