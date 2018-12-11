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
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8872305"
---
# <a name="post-usersbatchfeedback"></a><span data-ttu-id="19c1c-104">POST (/users/batchfeedback)</span><span class="sxs-lookup"><span data-stu-id="19c1c-104">POST (/users/batchfeedback)</span></span>
<span data-ttu-id="19c1c-105">タイトルのサービスによってタイトルのインターフェイスの外部のバッチ形式でフィードバックを送信するために使用します。</span><span class="sxs-lookup"><span data-stu-id="19c1c-105">Used by your title's service to send feedback in batch form outside of your title's interface.</span></span> <span data-ttu-id="19c1c-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="19c1c-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="19c1c-107">要求本文</span><span class="sxs-lookup"><span data-stu-id="19c1c-107">Request body</span></span>](#ID4EX)
  * [<span data-ttu-id="19c1c-108">必要なヘッダー</span><span class="sxs-lookup"><span data-stu-id="19c1c-108">Required Headers</span></span>](#ID4E3E)
  * [<span data-ttu-id="19c1c-109">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="19c1c-109">HTTP status codes</span></span>](#ID4EWG)
  * [<span data-ttu-id="19c1c-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="19c1c-110">Response body</span></span>](#ID4EDAAC)
 
<a id="ID4EX"></a>

 
## <a name="request-body"></a><span data-ttu-id="19c1c-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="19c1c-111">Request body</span></span> 
 
<span data-ttu-id="19c1c-112">呼び出し元では、その web 要求のオブジェクトの [ClientCertificates] セクションで、要求の証明書を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="19c1c-112">Callers must include their Claims Cert in the ClientCertificates section of their web request object.</span></span>
 
<a id="ID4EBB"></a>

 
### <a name="required-members"></a><span data-ttu-id="19c1c-113">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="19c1c-113">Required members</span></span> 
 
<span data-ttu-id="19c1c-114">要求は、 **BatchFeedback**オブジェクトの配列を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="19c1c-114">The request should contain an array of **BatchFeedback** objects.</span></span> 
  
<a id="ID4EPB"></a>

 
### <a name="prohibited-members"></a><span data-ttu-id="19c1c-115">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="19c1c-115">Prohibited members</span></span> 
 
<span data-ttu-id="19c1c-116">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="19c1c-116">All other members are prohibited in a request.</span></span>
  
<a id="ID4E3B"></a>

 
### <a name="sample-request"></a><span data-ttu-id="19c1c-117">要求の例</span><span class="sxs-lookup"><span data-stu-id="19c1c-117">Sample request</span></span> 
 

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

 
| <b><span data-ttu-id="19c1c-118">フィールド</span><span class="sxs-lookup"><span data-stu-id="19c1c-118">Field</span></span></b>| <b><span data-ttu-id="19c1c-119">JSON 型</span><span class="sxs-lookup"><span data-stu-id="19c1c-119">JSON Type</span></span></b>| <b><span data-ttu-id="19c1c-120">説明</span><span class="sxs-lookup"><span data-stu-id="19c1c-120">Description</span></span></b>| 
| --- | --- | --- | 
| <span data-ttu-id="19c1c-121">items</span><span class="sxs-lookup"><span data-stu-id="19c1c-121">items</span></span>| <span data-ttu-id="19c1c-122">array</span><span class="sxs-lookup"><span data-stu-id="19c1c-122">array</span></span>| <span data-ttu-id="19c1c-123">フィードバックの JSON ドキュメントのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="19c1c-123">A collection of Feedback JSON documents.</span></span>| 
| <span data-ttu-id="19c1c-124">targetXuid</span><span class="sxs-lookup"><span data-stu-id="19c1c-124">targetXuid</span></span>| <span data-ttu-id="19c1c-125">string</span><span class="sxs-lookup"><span data-stu-id="19c1c-125">string</span></span>| <span data-ttu-id="19c1c-126">ターゲット ユーザーの XUID</span><span class="sxs-lookup"><span data-stu-id="19c1c-126">The target user's XUID</span></span>| 
| <span data-ttu-id="19c1c-127">titleId</span><span class="sxs-lookup"><span data-stu-id="19c1c-127">titleId</span></span>| <span data-ttu-id="19c1c-128">string</span><span class="sxs-lookup"><span data-stu-id="19c1c-128">string</span></span>| <span data-ttu-id="19c1c-129">このフィードバックから送信されたタイトルまたは NULL。</span><span class="sxs-lookup"><span data-stu-id="19c1c-129">The title that this feedback was sent from, or NULL.</span></span>| 
| <span data-ttu-id="19c1c-130">sessionRef</span><span class="sxs-lookup"><span data-stu-id="19c1c-130">sessionRef</span></span>| <span data-ttu-id="19c1c-131">object</span><span class="sxs-lookup"><span data-stu-id="19c1c-131">object</span></span>| <span data-ttu-id="19c1c-132">MPSD セッションを表すオブジェクトです。 このフィードバックが関連する、または NULL。</span><span class="sxs-lookup"><span data-stu-id="19c1c-132">An object describing the MPSD session this feedback relates to, or NULL.</span></span>| 
| <span data-ttu-id="19c1c-133">feedbackType</span><span class="sxs-lookup"><span data-stu-id="19c1c-133">feedbackType</span></span>| <span data-ttu-id="19c1c-134">string</span><span class="sxs-lookup"><span data-stu-id="19c1c-134">string</span></span>| <span data-ttu-id="19c1c-135">FeedbackType 列挙体の値の文字列バージョン。</span><span class="sxs-lookup"><span data-stu-id="19c1c-135">A string version of a value in the FeedbackType enumeration.</span></span>| 
| <span data-ttu-id="19c1c-136">textReason</span><span class="sxs-lookup"><span data-stu-id="19c1c-136">textReason</span></span>| <span data-ttu-id="19c1c-137">string</span><span class="sxs-lookup"><span data-stu-id="19c1c-137">string</span></span>| <span data-ttu-id="19c1c-138">送信者の追加される可能性が送信されたフィードバックに関する詳細を提供するパートナー製のテキストです。</span><span class="sxs-lookup"><span data-stu-id="19c1c-138">Partner-supplied text that the sender may add to give more details about the feedback that was submitted.</span></span>| 
| <span data-ttu-id="19c1c-139">evidenceId</span><span class="sxs-lookup"><span data-stu-id="19c1c-139">evidenceId</span></span>| <span data-ttu-id="19c1c-140">string</span><span class="sxs-lookup"><span data-stu-id="19c1c-140">string</span></span>| <span data-ttu-id="19c1c-141">送信されたフィードバックの証拠として使用できるリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="19c1c-141">The ID of a resource that can be used as evidence of the feedback being submitted.</span></span> <span data-ttu-id="19c1c-142">例: ビデオ ファイルの ID です。</span><span class="sxs-lookup"><span data-stu-id="19c1c-142">e.g. the ID of a video file.</span></span>| 
   
<a id="ID4E3E"></a>

 
## <a name="required-headers"></a><span data-ttu-id="19c1c-143">必要なヘッダー</span><span class="sxs-lookup"><span data-stu-id="19c1c-143">Required Headers</span></span>
 
<span data-ttu-id="19c1c-144">次のヘッダーは、Xbox Live サービス要求を行ったとき必要があります。</span><span class="sxs-lookup"><span data-stu-id="19c1c-144">The following headers are required when making an Xbox Live Services request.</span></span> 

> [!NOTE] 
> <span data-ttu-id="19c1c-145">パートナーの要求の証明書は、バッチ フィードバックを送信するために要求送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="19c1c-145">A Partner Claims Certificate must be sent up with the request in order to submit batch feedback.</span></span> 


 
| <span data-ttu-id="19c1c-146">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="19c1c-146">Header</span></span>| <span data-ttu-id="19c1c-147">設定値</span><span class="sxs-lookup"><span data-stu-id="19c1c-147">Value</span></span>| <span data-ttu-id="19c1c-148">説明</span><span class="sxs-lookup"><span data-stu-id="19c1c-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="19c1c-149">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="19c1c-149">x-xbl-contract-version</span></span>| <span data-ttu-id="19c1c-150">101</span><span class="sxs-lookup"><span data-stu-id="19c1c-150">101</span></span>| <span data-ttu-id="19c1c-151">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="19c1c-151">API contract version.</span></span>| 
| <span data-ttu-id="19c1c-152">Content-Type</span><span class="sxs-lookup"><span data-stu-id="19c1c-152">Content-Type</span></span>| <span data-ttu-id="19c1c-153">application/json</span><span class="sxs-lookup"><span data-stu-id="19c1c-153">application/json</span></span>| <span data-ttu-id="19c1c-154">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="19c1c-154">Type of data being submitted.</span></span>| 
| <span data-ttu-id="19c1c-155">Authorization</span><span class="sxs-lookup"><span data-stu-id="19c1c-155">Authorization</span></span>| <span data-ttu-id="19c1c-156">"XBL3.0 x =&lt;userhash > です。&lt;トークン >"</span><span class="sxs-lookup"><span data-stu-id="19c1c-156">"XBL3.0 x=&lt;userhash>;&lt;token>"</span></span>| <span data-ttu-id="19c1c-157">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="19c1c-157">Authentication credentials for HTTP authentication.</span></span>| 
| <span data-ttu-id="19c1c-158">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="19c1c-158">X-RequestedServiceVersion</span></span>| <span data-ttu-id="19c1c-159">101</span><span class="sxs-lookup"><span data-stu-id="19c1c-159">101</span></span>| <span data-ttu-id="19c1c-160">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="19c1c-160">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="19c1c-161">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="19c1c-161">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span>| 
  
<a id="ID4EWG"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="19c1c-162">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="19c1c-162">HTTP status codes</span></span>
 
<span data-ttu-id="19c1c-163">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="19c1c-163">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="19c1c-164">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="19c1c-164">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="19c1c-165">コード</span><span class="sxs-lookup"><span data-stu-id="19c1c-165">Code</span></span>| <span data-ttu-id="19c1c-166">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="19c1c-166">Reason phrase</span></span>| <span data-ttu-id="19c1c-167">説明</span><span class="sxs-lookup"><span data-stu-id="19c1c-167">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="19c1c-168">400</span><span class="sxs-lookup"><span data-stu-id="19c1c-168">400</span></span>| <span data-ttu-id="19c1c-169">Bad Request</span><span class="sxs-lookup"><span data-stu-id="19c1c-169">Bad Request</span></span>| <span data-ttu-id="19c1c-170">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="19c1c-170">Service could not understand malformed request.</span></span> <span data-ttu-id="19c1c-171">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="19c1c-171">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="19c1c-172">401</span><span class="sxs-lookup"><span data-stu-id="19c1c-172">401</span></span>| <span data-ttu-id="19c1c-173">権限がありません</span><span class="sxs-lookup"><span data-stu-id="19c1c-173">Unauthorized</span></span>| <span data-ttu-id="19c1c-174">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="19c1c-174">The request requires user authentication.</span></span>| 
| <span data-ttu-id="19c1c-175">404</span><span class="sxs-lookup"><span data-stu-id="19c1c-175">404</span></span>| <span data-ttu-id="19c1c-176">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="19c1c-176">Not Found</span></span>| <span data-ttu-id="19c1c-177">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="19c1c-177">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="19c1c-178">500</span><span class="sxs-lookup"><span data-stu-id="19c1c-178">500</span></span>| <span data-ttu-id="19c1c-179">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="19c1c-179">Internal Server Error</span></span>| <span data-ttu-id="19c1c-180">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="19c1c-180">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="19c1c-181">503</span><span class="sxs-lookup"><span data-stu-id="19c1c-181">503</span></span>| <span data-ttu-id="19c1c-182">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="19c1c-182">Service Unavailable</span></span>| <span data-ttu-id="19c1c-183">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="19c1c-183">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EDAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="19c1c-184">応答本文</span><span class="sxs-lookup"><span data-stu-id="19c1c-184">Response body</span></span> 
 
<span data-ttu-id="19c1c-185">呼び出しが成功した場合は、この応答からのオブジェクトは返されません。</span><span class="sxs-lookup"><span data-stu-id="19c1c-185">If the call is successful, no objects are returned from this response.</span></span> <span data-ttu-id="19c1c-186">それ以外の場合、サービスは、 [ServiceError](../../json/json-serviceerror.md)オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="19c1c-186">Otherwise, the service returns a [ServiceError](../../json/json-serviceerror.md) object.</span></span>
  
<a id="ID4EXAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="19c1c-187">関連項目</span><span class="sxs-lookup"><span data-stu-id="19c1c-187">See also</span></span>
 
<a id="ID4EZAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="19c1c-188">Parent</span><span class="sxs-lookup"><span data-stu-id="19c1c-188">Parent</span></span> 

[<span data-ttu-id="19c1c-189">/users/batchfeedback</span><span class="sxs-lookup"><span data-stu-id="19c1c-189">/users/batchfeedback</span></span>](uri-reputationusersbatchfeedback.md)

  
<a id="ID4EFBAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="19c1c-190">リファレンス</span><span class="sxs-lookup"><span data-stu-id="19c1c-190">Reference</span></span> 

[<span data-ttu-id="19c1c-191">Feedback (JSON)</span><span class="sxs-lookup"><span data-stu-id="19c1c-191">Feedback (JSON)</span></span>](../../json/json-feedback.md)

 [<span data-ttu-id="19c1c-192">ServiceError (JSON)</span><span class="sxs-lookup"><span data-stu-id="19c1c-192">ServiceError (JSON)</span></span>](../../json/json-serviceerror.md)

   