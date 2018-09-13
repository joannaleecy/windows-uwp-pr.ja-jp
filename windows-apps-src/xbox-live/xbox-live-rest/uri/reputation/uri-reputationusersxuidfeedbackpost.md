---
title: POST (/users/xuid({xuid})/feedback)
assetID: 48a7a510-a658-f2a3-c6bc-28a3610006e7
permalink: en-us/docs/xboxlive/rest/uri-reputationusersxuidfeedbackpost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/feedback)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8cb56b51e2d558b2a4ef05d117244d464756e6ec
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3957551"
---
# <a name="post-usersxuidxuidfeedback"></a><span data-ttu-id="81e92-104">POST (/users/xuid({xuid})/feedback)</span><span class="sxs-lookup"><span data-stu-id="81e92-104">POST (/users/xuid({xuid})/feedback)</span></span>
<span data-ttu-id="81e92-105">シェルを使用するのではなく、ゲームでフィードバック オプションを追加したい場合に、タイトルから使われます。</span><span class="sxs-lookup"><span data-stu-id="81e92-105">Used from your title if you desire to add a feedback option in your game, as opposed to using the shell.</span></span> <span data-ttu-id="81e92-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="81e92-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="81e92-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81e92-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="81e92-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81e92-108">Required Request Headers</span></span>](#ID4EEB)
  * [<span data-ttu-id="81e92-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="81e92-109">Request body</span></span>](#ID4ENC)
  * [<span data-ttu-id="81e92-110">必要なヘッダー</span><span class="sxs-lookup"><span data-stu-id="81e92-110">Required headers</span></span>](#ID4EDE)
  * [<span data-ttu-id="81e92-111">Authorization</span><span class="sxs-lookup"><span data-stu-id="81e92-111">Authorization</span></span>](#ID4EXF)
  * [<span data-ttu-id="81e92-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="81e92-112">HTTP status codes</span></span>](#ID4EEG)
  * [<span data-ttu-id="81e92-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="81e92-113">Response body</span></span>](#ID4EZH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="81e92-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81e92-114">URI parameters</span></span>
 
| <span data-ttu-id="81e92-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="81e92-115">Parameter</span></span>| <span data-ttu-id="81e92-116">型</span><span class="sxs-lookup"><span data-stu-id="81e92-116">Type</span></span>| <span data-ttu-id="81e92-117">説明</span><span class="sxs-lookup"><span data-stu-id="81e92-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="81e92-118">xuid</span><span class="sxs-lookup"><span data-stu-id="81e92-118">xuid</span></span>| <span data-ttu-id="81e92-119">ulong</span><span class="sxs-lookup"><span data-stu-id="81e92-119">ulong</span></span>| <span data-ttu-id="81e92-120">Xbox ユーザー ID (XUID)、ユーザーが報告されるのです。</span><span class="sxs-lookup"><span data-stu-id="81e92-120">Xbox User ID (XUID) of the user being reported.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="81e92-121">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81e92-121">Required Request Headers</span></span>
 
| <span data-ttu-id="81e92-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81e92-122">Header</span></span>| <span data-ttu-id="81e92-123">型</span><span class="sxs-lookup"><span data-stu-id="81e92-123">Type</span></span>| <span data-ttu-id="81e92-124">説明</span><span class="sxs-lookup"><span data-stu-id="81e92-124">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="81e92-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="81e92-125">Authorization</span></span>| <span data-ttu-id="81e92-126">string</span><span class="sxs-lookup"><span data-stu-id="81e92-126">string</span></span>| <span data-ttu-id="81e92-127">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="81e92-127">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="81e92-128">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。</span><span class="sxs-lookup"><span data-stu-id="81e92-128">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="81e92-129">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="81e92-129">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="81e92-130">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="81e92-130">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="81e92-131">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="81e92-131">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="81e92-132">既定値: 101 します。</span><span class="sxs-lookup"><span data-stu-id="81e92-132">Default value: 101.</span></span>| 
  
<a id="ID4ENC"></a>

 
## <a name="request-body"></a><span data-ttu-id="81e92-133">要求本文</span><span class="sxs-lookup"><span data-stu-id="81e92-133">Request body</span></span> 
 
<a id="ID4EVC"></a>

 
### <a name="required-members"></a><span data-ttu-id="81e92-134">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="81e92-134">Required members</span></span> 
 
<span data-ttu-id="81e92-135">要求は、[フィードバック](../../json/json-feedback.md)のオブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="81e92-135">The request should contain a [Feedback](../../json/json-feedback.md) object.</span></span> 
  
<a id="ID4EED"></a>

 
### <a name="prohibited-members"></a><span data-ttu-id="81e92-136">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="81e92-136">Prohibited members</span></span> 
 
<span data-ttu-id="81e92-137">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="81e92-137">All other members are prohibited in a request.</span></span>
  
<a id="ID4ETD"></a>

 
### <a name="sample-request"></a><span data-ttu-id="81e92-138">要求の例</span><span class="sxs-lookup"><span data-stu-id="81e92-138">Sample request</span></span> 
 

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

 
## <a name="required-headers"></a><span data-ttu-id="81e92-139">必要なヘッダー</span><span class="sxs-lookup"><span data-stu-id="81e92-139">Required headers</span></span>
 
<span data-ttu-id="81e92-140">次のヘッダーは、Xbox Live サービス要求を行ったとき必要があります。</span><span class="sxs-lookup"><span data-stu-id="81e92-140">The following headers are required when making an Xbox Live Services request.</span></span>
 
| <b><span data-ttu-id="81e92-141">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81e92-141">Header</span></span></b>| <b><span data-ttu-id="81e92-142">値</span><span class="sxs-lookup"><span data-stu-id="81e92-142">Value</span></span></b>| <b><span data-ttu-id="81e92-143">Deacription</span><span class="sxs-lookup"><span data-stu-id="81e92-143">Deacription</span></span></b>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="81e92-144">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="81e92-144">x-xbl-contract-version</span></span>| <span data-ttu-id="81e92-145">101</span><span class="sxs-lookup"><span data-stu-id="81e92-145">101</span></span>| <span data-ttu-id="81e92-146">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="81e92-146">API contract version.</span></span>| 
| <span data-ttu-id="81e92-147">Authorization</span><span class="sxs-lookup"><span data-stu-id="81e92-147">Authorization</span></span>| <span data-ttu-id="81e92-148">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="81e92-148">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="81e92-149">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="81e92-149">STS authentication token.</span></span> <span data-ttu-id="81e92-150">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="81e92-150">STSTokenString is replaced by the token returned by the authentication request.</span></span>| 
<span data-ttu-id="81e92-151">Content-Type</span><span class="sxs-lookup"><span data-stu-id="81e92-151">Content-Type</span></span>| 
<span data-ttu-id="81e92-152">application/json</span><span class="sxs-lookup"><span data-stu-id="81e92-152">application/json</span></span>| 
<span data-ttu-id="81e92-153">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="81e92-153">Type of data being submitted.</span></span>| 
  
<a id="ID4EXF"></a>

 
## <a name="authorization"></a><span data-ttu-id="81e92-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="81e92-154">Authorization</span></span>
 
<span data-ttu-id="81e92-155">要求は、Xbox Live の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="81e92-155">The request must include a valid Xbox Live authorization header.</span></span> <span data-ttu-id="81e92-156">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden コードを返します。</span><span class="sxs-lookup"><span data-stu-id="81e92-156">If the caller is not allowed to access this resource, the service returns a 403 Forbidden code.</span></span> <span data-ttu-id="81e92-157">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていないコードを返します。</span><span class="sxs-lookup"><span data-stu-id="81e92-157">If the header is invalid or missing, the service returns a 401 Unauthorized code.</span></span>
  
<a id="ID4EEG"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="81e92-158">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="81e92-158">HTTP status codes</span></span>
 
<span data-ttu-id="81e92-159">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="81e92-159">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="81e92-160">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="81e92-160">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="81e92-161">コード</span><span class="sxs-lookup"><span data-stu-id="81e92-161">Code</span></span>| <span data-ttu-id="81e92-162">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="81e92-162">Reason phrase</span></span>| <span data-ttu-id="81e92-163">説明</span><span class="sxs-lookup"><span data-stu-id="81e92-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="81e92-164">204</span><span class="sxs-lookup"><span data-stu-id="81e92-164">204</span></span>| <span data-ttu-id="81e92-165">No Content</span><span class="sxs-lookup"><span data-stu-id="81e92-165">No Content</span></span>| <span data-ttu-id="81e92-166">要求が完了したらが、返されるコンテンツはありません。</span><span class="sxs-lookup"><span data-stu-id="81e92-166">The request has completed, but does not have content to return.</span></span>| 
| <span data-ttu-id="81e92-167">401</span><span class="sxs-lookup"><span data-stu-id="81e92-167">401</span></span>| <span data-ttu-id="81e92-168">権限がありません</span><span class="sxs-lookup"><span data-stu-id="81e92-168">Unauthorized</span></span>| <span data-ttu-id="81e92-169">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="81e92-169">The request requires user authentication.</span></span>| 
| <span data-ttu-id="81e92-170">404</span><span class="sxs-lookup"><span data-stu-id="81e92-170">404</span></span>| <span data-ttu-id="81e92-171">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="81e92-171">Not Found</span></span>| <span data-ttu-id="81e92-172">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="81e92-172">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="81e92-173">406</span><span class="sxs-lookup"><span data-stu-id="81e92-173">406</span></span>| <span data-ttu-id="81e92-174">許容できません。</span><span class="sxs-lookup"><span data-stu-id="81e92-174">Not Acceptable</span></span>| <span data-ttu-id="81e92-175">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="81e92-175">Resource version is not supported.</span></span>| 
| <span data-ttu-id="81e92-176">408</span><span class="sxs-lookup"><span data-stu-id="81e92-176">408</span></span>| <span data-ttu-id="81e92-177">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="81e92-177">Request Timeout</span></span>| <span data-ttu-id="81e92-178">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="81e92-178">The request took too long to complete.</span></span>| 
| <span data-ttu-id="81e92-179">409</span><span class="sxs-lookup"><span data-stu-id="81e92-179">409</span></span>| <span data-ttu-id="81e92-180">Conflict</span><span class="sxs-lookup"><span data-stu-id="81e92-180">Conflict</span></span>| <span data-ttu-id="81e92-181">継続トークンが無効になった。</span><span class="sxs-lookup"><span data-stu-id="81e92-181">Continuation token no longer valid.</span></span>| 
  
<a id="ID4EZH"></a>

 
## <a name="response-body"></a><span data-ttu-id="81e92-182">応答本文</span><span class="sxs-lookup"><span data-stu-id="81e92-182">Response body</span></span> 
 
<span data-ttu-id="81e92-183">呼び出しが成功した場合は、この応答からのオブジェクトは返されません。</span><span class="sxs-lookup"><span data-stu-id="81e92-183">If the call is successful, no objects are returned from this response.</span></span> <span data-ttu-id="81e92-184">それ以外の場合、サービスは、 [ServiceError](../../json/json-serviceerror.md)オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="81e92-184">Otherwise, the service returns a [ServiceError](../../json/json-serviceerror.md) object.</span></span>
  
<a id="ID4EOAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="81e92-185">関連項目</span><span class="sxs-lookup"><span data-stu-id="81e92-185">See also</span></span>
 
<a id="ID4EQAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="81e92-186">Parent</span><span class="sxs-lookup"><span data-stu-id="81e92-186">Parent</span></span> 

[<span data-ttu-id="81e92-187">/users/xuid({xuid})/feedback</span><span class="sxs-lookup"><span data-stu-id="81e92-187">/users/xuid({xuid})/feedback</span></span>](uri-reputationusersxuidfeedback.md)

  
<a id="ID4E3AAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="81e92-188">リファレンス</span><span class="sxs-lookup"><span data-stu-id="81e92-188">Reference</span></span> 

[<span data-ttu-id="81e92-189">フィードバック (JSON)</span><span class="sxs-lookup"><span data-stu-id="81e92-189">Feedback (JSON)</span></span>](../../json/json-feedback.md)

 [<span data-ttu-id="81e92-190">ServiceError (JSON)</span><span class="sxs-lookup"><span data-stu-id="81e92-190">ServiceError (JSON)</span></span>](../../json/json-serviceerror.md)

   