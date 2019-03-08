---
title: POST (/users/xuid({xuid})/feedback)
assetID: 48a7a510-a658-f2a3-c6bc-28a3610006e7
permalink: en-us/docs/xboxlive/rest/uri-reputationusersxuidfeedbackpost.html
description: " POST (/users/xuid({xuid})/feedback)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d8a6e118811203fd34c310840e8688c2255c6beb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660047"
---
# <a name="post-usersxuidxuidfeedback"></a><span data-ttu-id="52527-104">POST (/users/xuid({xuid})/feedback)</span><span class="sxs-lookup"><span data-stu-id="52527-104">POST (/users/xuid({xuid})/feedback)</span></span>
<span data-ttu-id="52527-105">シェルを使用するのではなく、ゲームのフィードバックのオプションを追加したい場合、タイトルから使用されます。</span><span class="sxs-lookup"><span data-stu-id="52527-105">Used from your title if you desire to add a feedback option in your game, as opposed to using the shell.</span></span> <span data-ttu-id="52527-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="52527-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="52527-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="52527-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="52527-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="52527-108">Required Request Headers</span></span>](#ID4EEB)
  * [<span data-ttu-id="52527-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="52527-109">Request body</span></span>](#ID4ENC)
  * [<span data-ttu-id="52527-110">必要なヘッダー</span><span class="sxs-lookup"><span data-stu-id="52527-110">Required headers</span></span>](#ID4EDE)
  * [<span data-ttu-id="52527-111">承認</span><span class="sxs-lookup"><span data-stu-id="52527-111">Authorization</span></span>](#ID4EXF)
  * [<span data-ttu-id="52527-112">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="52527-112">HTTP status codes</span></span>](#ID4EEG)
  * [<span data-ttu-id="52527-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="52527-113">Response body</span></span>](#ID4EZH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="52527-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="52527-114">URI parameters</span></span>
 
| <span data-ttu-id="52527-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="52527-115">Parameter</span></span>| <span data-ttu-id="52527-116">種類</span><span class="sxs-lookup"><span data-stu-id="52527-116">Type</span></span>| <span data-ttu-id="52527-117">説明</span><span class="sxs-lookup"><span data-stu-id="52527-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="52527-118">xuid</span><span class="sxs-lookup"><span data-stu-id="52527-118">xuid</span></span>| <span data-ttu-id="52527-119">ulong</span><span class="sxs-lookup"><span data-stu-id="52527-119">ulong</span></span>| <span data-ttu-id="52527-120">Xbox ユーザー ID (XUID)、ユーザーが報告されているのです。</span><span class="sxs-lookup"><span data-stu-id="52527-120">Xbox User ID (XUID) of the user being reported.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="52527-121">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="52527-121">Required Request Headers</span></span>
 
| <span data-ttu-id="52527-122">Header</span><span class="sxs-lookup"><span data-stu-id="52527-122">Header</span></span>| <span data-ttu-id="52527-123">種類</span><span class="sxs-lookup"><span data-stu-id="52527-123">Type</span></span>| <span data-ttu-id="52527-124">説明</span><span class="sxs-lookup"><span data-stu-id="52527-124">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="52527-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="52527-125">Authorization</span></span>| <span data-ttu-id="52527-126">string</span><span class="sxs-lookup"><span data-stu-id="52527-126">string</span></span>| <span data-ttu-id="52527-127">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="52527-127">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="52527-128">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="52527-128">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="52527-129">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="52527-129">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="52527-130">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="52527-130">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="52527-131">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="52527-131">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="52527-132">［既定値］:101.</span><span class="sxs-lookup"><span data-stu-id="52527-132">Default value: 101.</span></span>| 
  
<a id="ID4ENC"></a>

 
## <a name="request-body"></a><span data-ttu-id="52527-133">要求本文</span><span class="sxs-lookup"><span data-stu-id="52527-133">Request body</span></span> 
 
<a id="ID4EVC"></a>

 
### <a name="required-members"></a><span data-ttu-id="52527-134">必須メンバー</span><span class="sxs-lookup"><span data-stu-id="52527-134">Required members</span></span> 
 
<span data-ttu-id="52527-135">要求に含める必要があります、[フィードバック](../../json/json-feedback.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="52527-135">The request should contain a [Feedback](../../json/json-feedback.md) object.</span></span> 
  
<a id="ID4EED"></a>

 
### <a name="prohibited-members"></a><span data-ttu-id="52527-136">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="52527-136">Prohibited members</span></span> 
 
<span data-ttu-id="52527-137">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="52527-137">All other members are prohibited in a request.</span></span>
  
<a id="ID4ETD"></a>

 
### <a name="sample-request"></a><span data-ttu-id="52527-138">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="52527-138">Sample request</span></span> 
 

```cpp
{
    "sessionRef":
    {
        "scid": "372D829B-FA8E-471F-B696-07B61F09EC20",
        "templateName": "CaptureFlag5",
        "name": "Halo556932",
    },
    "feedbackType": "CommsAbusiveVoice",
    "textReason": "He called me a doodoo-head!",
    "voiceReasonId": null,
    "evidenceId": null
}

      
```

   
<a id="ID4EDE"></a>

 
## <a name="required-headers"></a><span data-ttu-id="52527-139">必要なヘッダー</span><span class="sxs-lookup"><span data-stu-id="52527-139">Required headers</span></span>
 
<span data-ttu-id="52527-140">Xbox Live サービス要求を行うときに、次のヘッダーが必要です。</span><span class="sxs-lookup"><span data-stu-id="52527-140">The following headers are required when making an Xbox Live Services request.</span></span>
 
| <span data-ttu-id="52527-141"><b>ヘッダー</b></span><span class="sxs-lookup"><span data-stu-id="52527-141"><b>Header</b></span></span>| <span data-ttu-id="52527-142"><b>値</b></span><span class="sxs-lookup"><span data-stu-id="52527-142"><b>Value</b></span></span>| <span data-ttu-id="52527-143"><b>Deacription</b></span><span class="sxs-lookup"><span data-stu-id="52527-143"><b>Deacription</b></span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="52527-144">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="52527-144">x-xbl-contract-version</span></span>| <span data-ttu-id="52527-145">101</span><span class="sxs-lookup"><span data-stu-id="52527-145">101</span></span>| <span data-ttu-id="52527-146">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="52527-146">API contract version.</span></span>| 
| <span data-ttu-id="52527-147">Authorization</span><span class="sxs-lookup"><span data-stu-id="52527-147">Authorization</span></span>| <span data-ttu-id="52527-148">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="52527-148">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="52527-149">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="52527-149">STS authentication token.</span></span> <span data-ttu-id="52527-150">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="52527-150">STSTokenString is replaced by the token returned by the authentication request.</span></span>| 
<span data-ttu-id="52527-151">Content-Type</span><span class="sxs-lookup"><span data-stu-id="52527-151">Content-Type</span></span>| 
<span data-ttu-id="52527-152">application/json</span><span class="sxs-lookup"><span data-stu-id="52527-152">application/json</span></span>| 
<span data-ttu-id="52527-153">送信されるデータの型。</span><span class="sxs-lookup"><span data-stu-id="52527-153">Type of data being submitted.</span></span>| 
  
<a id="ID4EXF"></a>

 
## <a name="authorization"></a><span data-ttu-id="52527-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="52527-154">Authorization</span></span>
 
<span data-ttu-id="52527-155">要求には、有効な Xbox Live の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="52527-155">The request must include a valid Xbox Live authorization header.</span></span> <span data-ttu-id="52527-156">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 Forbidden コードを返します。</span><span class="sxs-lookup"><span data-stu-id="52527-156">If the caller is not allowed to access this resource, the service returns a 403 Forbidden code.</span></span> <span data-ttu-id="52527-157">ヘッダーが無効であるか不足している場合、サービスは、401 未承認のコードを返します。</span><span class="sxs-lookup"><span data-stu-id="52527-157">If the header is invalid or missing, the service returns a 401 Unauthorized code.</span></span>
  
<a id="ID4EEG"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="52527-158">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="52527-158">HTTP status codes</span></span>
 
<span data-ttu-id="52527-159">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="52527-159">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="52527-160">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="52527-160">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="52527-161">コード</span><span class="sxs-lookup"><span data-stu-id="52527-161">Code</span></span>| <span data-ttu-id="52527-162">理由語句</span><span class="sxs-lookup"><span data-stu-id="52527-162">Reason phrase</span></span>| <span data-ttu-id="52527-163">説明</span><span class="sxs-lookup"><span data-stu-id="52527-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="52527-164">204</span><span class="sxs-lookup"><span data-stu-id="52527-164">204</span></span>| <span data-ttu-id="52527-165">コンテンツはありません</span><span class="sxs-lookup"><span data-stu-id="52527-165">No Content</span></span>| <span data-ttu-id="52527-166">要求が完了したらが、コンテンツを返すことはありません。</span><span class="sxs-lookup"><span data-stu-id="52527-166">The request has completed, but does not have content to return.</span></span>| 
| <span data-ttu-id="52527-167">401</span><span class="sxs-lookup"><span data-stu-id="52527-167">401</span></span>| <span data-ttu-id="52527-168">権限がありません</span><span class="sxs-lookup"><span data-stu-id="52527-168">Unauthorized</span></span>| <span data-ttu-id="52527-169">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="52527-169">The request requires user authentication.</span></span>| 
| <span data-ttu-id="52527-170">404</span><span class="sxs-lookup"><span data-stu-id="52527-170">404</span></span>| <span data-ttu-id="52527-171">検出不可</span><span class="sxs-lookup"><span data-stu-id="52527-171">Not Found</span></span>| <span data-ttu-id="52527-172">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="52527-172">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="52527-173">406</span><span class="sxs-lookup"><span data-stu-id="52527-173">406</span></span>| <span data-ttu-id="52527-174">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="52527-174">Not Acceptable</span></span>| <span data-ttu-id="52527-175">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="52527-175">Resource version is not supported.</span></span>| 
| <span data-ttu-id="52527-176">408</span><span class="sxs-lookup"><span data-stu-id="52527-176">408</span></span>| <span data-ttu-id="52527-177">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="52527-177">Request Timeout</span></span>| <span data-ttu-id="52527-178">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="52527-178">The request took too long to complete.</span></span>| 
| <span data-ttu-id="52527-179">409</span><span class="sxs-lookup"><span data-stu-id="52527-179">409</span></span>| <span data-ttu-id="52527-180">Conflict</span><span class="sxs-lookup"><span data-stu-id="52527-180">Conflict</span></span>| <span data-ttu-id="52527-181">継続トークンが無効になりました。</span><span class="sxs-lookup"><span data-stu-id="52527-181">Continuation token no longer valid.</span></span>| 
  
<a id="ID4EZH"></a>

 
## <a name="response-body"></a><span data-ttu-id="52527-182">応答本文</span><span class="sxs-lookup"><span data-stu-id="52527-182">Response body</span></span> 
 
<span data-ttu-id="52527-183">呼び出しが成功した場合、この応答からのオブジェクトは返されません。</span><span class="sxs-lookup"><span data-stu-id="52527-183">If the call is successful, no objects are returned from this response.</span></span> <span data-ttu-id="52527-184">サービスを返しますそれ以外の場合、[サービス エラー](../../json/json-serviceerror.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="52527-184">Otherwise, the service returns a [ServiceError](../../json/json-serviceerror.md) object.</span></span>
  
<a id="ID4EOAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="52527-185">関連項目</span><span class="sxs-lookup"><span data-stu-id="52527-185">See also</span></span>
 
<a id="ID4EQAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="52527-186">Parent</span><span class="sxs-lookup"><span data-stu-id="52527-186">Parent</span></span> 

[<span data-ttu-id="52527-187">/users/xuid({xuid})/feedback</span><span class="sxs-lookup"><span data-stu-id="52527-187">/users/xuid({xuid})/feedback</span></span>](uri-reputationusersxuidfeedback.md)

  
<a id="ID4E3AAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="52527-188">リファレンス</span><span class="sxs-lookup"><span data-stu-id="52527-188">Reference</span></span> 

[<span data-ttu-id="52527-189">フィードバック (JSON)</span><span class="sxs-lookup"><span data-stu-id="52527-189">Feedback (JSON)</span></span>](../../json/json-feedback.md)

 [<span data-ttu-id="52527-190">サービス エラー (JSON)</span><span class="sxs-lookup"><span data-stu-id="52527-190">ServiceError (JSON)</span></span>](../../json/json-serviceerror.md)

   