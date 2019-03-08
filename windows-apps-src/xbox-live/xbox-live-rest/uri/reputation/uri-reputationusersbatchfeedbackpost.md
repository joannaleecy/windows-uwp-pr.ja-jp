---
title: POST (/users/batchfeedback)
assetID: f94dcf19-a4e3-5bd0-5276-23e43bdcae52
permalink: en-us/docs/xboxlive/rest/uri-reputationusersbatchfeedbackpost.html
description: " POST (/users/batchfeedback)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0906d32a0e15b2eaaf9c33e7f658e9e9f0cd5124
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622727"
---
# <a name="post-usersbatchfeedback"></a><span data-ttu-id="5795d-104">POST (/users/batchfeedback)</span><span class="sxs-lookup"><span data-stu-id="5795d-104">POST (/users/batchfeedback)</span></span>
<span data-ttu-id="5795d-105">タイトルのインターフェイスの外部でのバッチの形式でフィードバックを送信するタイトルのサービスで使用します。</span><span class="sxs-lookup"><span data-stu-id="5795d-105">Used by your title's service to send feedback in batch form outside of your title's interface.</span></span> <span data-ttu-id="5795d-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="5795d-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="5795d-107">要求本文</span><span class="sxs-lookup"><span data-stu-id="5795d-107">Request body</span></span>](#ID4EX)
  * [<span data-ttu-id="5795d-108">必要なヘッダー</span><span class="sxs-lookup"><span data-stu-id="5795d-108">Required Headers</span></span>](#ID4E3E)
  * [<span data-ttu-id="5795d-109">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="5795d-109">HTTP status codes</span></span>](#ID4EWG)
  * [<span data-ttu-id="5795d-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="5795d-110">Response body</span></span>](#ID4EDAAC)
 
<a id="ID4EX"></a>

 
## <a name="request-body"></a><span data-ttu-id="5795d-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="5795d-111">Request body</span></span> 
 
<span data-ttu-id="5795d-112">呼び出し元は、web 要求オブジェクトの ClientCertificates セクションでは、要求証明書を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="5795d-112">Callers must include their Claims Cert in the ClientCertificates section of their web request object.</span></span>
 
<a id="ID4EBB"></a>

 
### <a name="required-members"></a><span data-ttu-id="5795d-113">必須メンバー</span><span class="sxs-lookup"><span data-stu-id="5795d-113">Required members</span></span> 
 
<span data-ttu-id="5795d-114">要求の配列を含める必要があります**BatchFeedback**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="5795d-114">The request should contain an array of **BatchFeedback** objects.</span></span> 
  
<a id="ID4EPB"></a>

 
### <a name="prohibited-members"></a><span data-ttu-id="5795d-115">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="5795d-115">Prohibited members</span></span> 
 
<span data-ttu-id="5795d-116">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="5795d-116">All other members are prohibited in a request.</span></span>
  
<a id="ID4E3B"></a>

 
### <a name="sample-request"></a><span data-ttu-id="5795d-117">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="5795d-117">Sample request</span></span> 
 

```cpp
{
    "items" :
    [
        {
            "targetXuid": "33445566778899",
            "titleId": "6487",
            "sessionRef":
            {
                "scid": "372D829B-FA8E-471F-B696-07B61F09EC20",
                "templateName": "CaptureFlag5",
                "name": "Halo556932",
            },
            "feedbackType": "FairPlayKillsTeammates",
            "textReason": "Killed 19 team members in a single session",
            "evidenceId": null
        },
        {
            "targetXuid": "33445566778899",
            "titleId": "6487",
            "sessionRef":
            {
                "scid": "372D829B-FA8E-471F-B696-07B61F09EC20",
                "templateName": "CaptureFlag5",
                "name": "Halo556932",
            },
            "feedbackType": "FairPlayQuitter",
            "textReason": "Quit 6 times from 9 sessions",
            "evidenceId": null
        }
    ]
}

      
```

 
| <span data-ttu-id="5795d-118"><b>フィールド</b></span><span class="sxs-lookup"><span data-stu-id="5795d-118"><b>Field</b></span></span>| <span data-ttu-id="5795d-119"><b>JSON 型</b></span><span class="sxs-lookup"><span data-stu-id="5795d-119"><b>JSON Type</b></span></span>| <span data-ttu-id="5795d-120"><b>説明</b></span><span class="sxs-lookup"><span data-stu-id="5795d-120"><b>Description</b></span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5795d-121">items</span><span class="sxs-lookup"><span data-stu-id="5795d-121">items</span></span>| <span data-ttu-id="5795d-122">array</span><span class="sxs-lookup"><span data-stu-id="5795d-122">array</span></span>| <span data-ttu-id="5795d-123">フィードバックの JSON ドキュメントのコレクション。</span><span class="sxs-lookup"><span data-stu-id="5795d-123">A collection of Feedback JSON documents.</span></span>| 
| <span data-ttu-id="5795d-124">targetXuid</span><span class="sxs-lookup"><span data-stu-id="5795d-124">targetXuid</span></span>| <span data-ttu-id="5795d-125">string</span><span class="sxs-lookup"><span data-stu-id="5795d-125">string</span></span>| <span data-ttu-id="5795d-126">ターゲット ユーザーの XUID</span><span class="sxs-lookup"><span data-stu-id="5795d-126">The target user's XUID</span></span>| 
| <span data-ttu-id="5795d-127">titleId</span><span class="sxs-lookup"><span data-stu-id="5795d-127">titleId</span></span>| <span data-ttu-id="5795d-128">string</span><span class="sxs-lookup"><span data-stu-id="5795d-128">string</span></span>| <span data-ttu-id="5795d-129">このフィードバックから送信されたタイトルまたは NULL。</span><span class="sxs-lookup"><span data-stu-id="5795d-129">The title that this feedback was sent from, or NULL.</span></span>| 
| <span data-ttu-id="5795d-130">sessionRef</span><span class="sxs-lookup"><span data-stu-id="5795d-130">sessionRef</span></span>| <span data-ttu-id="5795d-131">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="5795d-131">object</span></span>| <span data-ttu-id="5795d-132">MPSD セッションを表すオブジェクトです。 このフィードバックは、または NULL を関連付けます。</span><span class="sxs-lookup"><span data-stu-id="5795d-132">An object describing the MPSD session this feedback relates to, or NULL.</span></span>| 
| <span data-ttu-id="5795d-133">feedbackType</span><span class="sxs-lookup"><span data-stu-id="5795d-133">feedbackType</span></span>| <span data-ttu-id="5795d-134">string</span><span class="sxs-lookup"><span data-stu-id="5795d-134">string</span></span>| <span data-ttu-id="5795d-135">FeedbackType 列挙の値の文字列バージョン。</span><span class="sxs-lookup"><span data-stu-id="5795d-135">A string version of a value in the FeedbackType enumeration.</span></span>| 
| <span data-ttu-id="5795d-136">textReason</span><span class="sxs-lookup"><span data-stu-id="5795d-136">textReason</span></span>| <span data-ttu-id="5795d-137">string</span><span class="sxs-lookup"><span data-stu-id="5795d-137">string</span></span>| <span data-ttu-id="5795d-138">送信者は送信されたフィードバックの詳細情報を追加するパートナーが指定したテキストです。</span><span class="sxs-lookup"><span data-stu-id="5795d-138">Partner-supplied text that the sender may add to give more details about the feedback that was submitted.</span></span>| 
| <span data-ttu-id="5795d-139">evidenceId</span><span class="sxs-lookup"><span data-stu-id="5795d-139">evidenceId</span></span>| <span data-ttu-id="5795d-140">string</span><span class="sxs-lookup"><span data-stu-id="5795d-140">string</span></span>| <span data-ttu-id="5795d-141">フィードバックの送信中の証拠として使用できるリソースの ID。</span><span class="sxs-lookup"><span data-stu-id="5795d-141">The ID of a resource that can be used as evidence of the feedback being submitted.</span></span> <span data-ttu-id="5795d-142">例: ビデオ ファイルの ID。</span><span class="sxs-lookup"><span data-stu-id="5795d-142">e.g. the ID of a video file.</span></span>| 
   
<a id="ID4E3E"></a>

 
## <a name="required-headers"></a><span data-ttu-id="5795d-143">必要なヘッダー</span><span class="sxs-lookup"><span data-stu-id="5795d-143">Required Headers</span></span>
 
<span data-ttu-id="5795d-144">Xbox Live サービス要求を行うときに、次のヘッダーが必要です。</span><span class="sxs-lookup"><span data-stu-id="5795d-144">The following headers are required when making an Xbox Live Services request.</span></span> 

> [!NOTE] 
> <span data-ttu-id="5795d-145">パートナー要求の証明書は、バッチのフィードバックを送信するには、要求と共に送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5795d-145">A Partner Claims Certificate must be sent up with the request in order to submit batch feedback.</span></span> 


 
| <span data-ttu-id="5795d-146">Header</span><span class="sxs-lookup"><span data-stu-id="5795d-146">Header</span></span>| <span data-ttu-id="5795d-147">Value</span><span class="sxs-lookup"><span data-stu-id="5795d-147">Value</span></span>| <span data-ttu-id="5795d-148">説明</span><span class="sxs-lookup"><span data-stu-id="5795d-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="5795d-149">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="5795d-149">x-xbl-contract-version</span></span>| <span data-ttu-id="5795d-150">101</span><span class="sxs-lookup"><span data-stu-id="5795d-150">101</span></span>| <span data-ttu-id="5795d-151">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="5795d-151">API contract version.</span></span>| 
| <span data-ttu-id="5795d-152">Content-Type</span><span class="sxs-lookup"><span data-stu-id="5795d-152">Content-Type</span></span>| <span data-ttu-id="5795d-153">application/json</span><span class="sxs-lookup"><span data-stu-id="5795d-153">application/json</span></span>| <span data-ttu-id="5795d-154">送信されるデータの型。</span><span class="sxs-lookup"><span data-stu-id="5795d-154">Type of data being submitted.</span></span>| 
| <span data-ttu-id="5795d-155">Authorization</span><span class="sxs-lookup"><span data-stu-id="5795d-155">Authorization</span></span>| <span data-ttu-id="5795d-156">"XBL3.0 x=&lt;userhash>;&lt;token>"</span><span class="sxs-lookup"><span data-stu-id="5795d-156">"XBL3.0 x=&lt;userhash>;&lt;token>"</span></span>| <span data-ttu-id="5795d-157">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="5795d-157">Authentication credentials for HTTP authentication.</span></span>| 
| <span data-ttu-id="5795d-158">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="5795d-158">X-RequestedServiceVersion</span></span>| <span data-ttu-id="5795d-159">101</span><span class="sxs-lookup"><span data-stu-id="5795d-159">101</span></span>| <span data-ttu-id="5795d-160">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="5795d-160">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="5795d-161">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="5795d-161">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span>| 
  
<a id="ID4EWG"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="5795d-162">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="5795d-162">HTTP status codes</span></span>
 
<span data-ttu-id="5795d-163">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="5795d-163">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="5795d-164">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="5795d-164">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="5795d-165">コード</span><span class="sxs-lookup"><span data-stu-id="5795d-165">Code</span></span>| <span data-ttu-id="5795d-166">理由語句</span><span class="sxs-lookup"><span data-stu-id="5795d-166">Reason phrase</span></span>| <span data-ttu-id="5795d-167">説明</span><span class="sxs-lookup"><span data-stu-id="5795d-167">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="5795d-168">400</span><span class="sxs-lookup"><span data-stu-id="5795d-168">400</span></span>| <span data-ttu-id="5795d-169">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="5795d-169">Bad Request</span></span>| <span data-ttu-id="5795d-170">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="5795d-170">Service could not understand malformed request.</span></span> <span data-ttu-id="5795d-171">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="5795d-171">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="5795d-172">401</span><span class="sxs-lookup"><span data-stu-id="5795d-172">401</span></span>| <span data-ttu-id="5795d-173">権限がありません</span><span class="sxs-lookup"><span data-stu-id="5795d-173">Unauthorized</span></span>| <span data-ttu-id="5795d-174">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="5795d-174">The request requires user authentication.</span></span>| 
| <span data-ttu-id="5795d-175">404</span><span class="sxs-lookup"><span data-stu-id="5795d-175">404</span></span>| <span data-ttu-id="5795d-176">検出不可</span><span class="sxs-lookup"><span data-stu-id="5795d-176">Not Found</span></span>| <span data-ttu-id="5795d-177">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="5795d-177">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="5795d-178">500</span><span class="sxs-lookup"><span data-stu-id="5795d-178">500</span></span>| <span data-ttu-id="5795d-179">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="5795d-179">Internal Server Error</span></span>| <span data-ttu-id="5795d-180">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="5795d-180">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="5795d-181">503</span><span class="sxs-lookup"><span data-stu-id="5795d-181">503</span></span>| <span data-ttu-id="5795d-182">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="5795d-182">Service Unavailable</span></span>| <span data-ttu-id="5795d-183">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="5795d-183">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EDAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="5795d-184">応答本文</span><span class="sxs-lookup"><span data-stu-id="5795d-184">Response body</span></span> 
 
<span data-ttu-id="5795d-185">呼び出しが成功した場合、この応答からのオブジェクトは返されません。</span><span class="sxs-lookup"><span data-stu-id="5795d-185">If the call is successful, no objects are returned from this response.</span></span> <span data-ttu-id="5795d-186">サービスを返しますそれ以外の場合、[サービス エラー](../../json/json-serviceerror.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="5795d-186">Otherwise, the service returns a [ServiceError](../../json/json-serviceerror.md) object.</span></span>
  
<a id="ID4EXAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5795d-187">関連項目</span><span class="sxs-lookup"><span data-stu-id="5795d-187">See also</span></span>
 
<a id="ID4EZAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5795d-188">Parent</span><span class="sxs-lookup"><span data-stu-id="5795d-188">Parent</span></span> 

[<span data-ttu-id="5795d-189">/users/batchfeedback</span><span class="sxs-lookup"><span data-stu-id="5795d-189">/users/batchfeedback</span></span>](uri-reputationusersbatchfeedback.md)

  
<a id="ID4EFBAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="5795d-190">リファレンス</span><span class="sxs-lookup"><span data-stu-id="5795d-190">Reference</span></span> 

[<span data-ttu-id="5795d-191">フィードバック (JSON)</span><span class="sxs-lookup"><span data-stu-id="5795d-191">Feedback (JSON)</span></span>](../../json/json-feedback.md)

 [<span data-ttu-id="5795d-192">サービス エラー (JSON)</span><span class="sxs-lookup"><span data-stu-id="5795d-192">ServiceError (JSON)</span></span>](../../json/json-serviceerror.md)

   