---
title: POST (/titles/{titleId}/clusters)
assetID: 0977b0b0-872d-f7ad-9ba0-30d56cff4912
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidclusters-post.html
description: " POST (/titles/{titleId}/clusters)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 91d7c49628914f887c5d2243942e10e47d47b095
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608907"
---
# <a name="post-titlestitleidclusters"></a><span data-ttu-id="9d02e-104">POST (/titles/{titleId}/clusters)</span><span class="sxs-lookup"><span data-stu-id="9d02e-104">POST (/titles/{titleId}/clusters)</span></span>
<span data-ttu-id="9d02e-105">により、クライアントは Xbox Live コンピューティング サーバー インスタンスを作成する URI。</span><span class="sxs-lookup"><span data-stu-id="9d02e-105">URI that allows a client to create an Xbox Live Compute server instance.</span></span> <span data-ttu-id="9d02e-106">これらの Uri のドメインが`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9d02e-106">The domain for these URIs is `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="9d02e-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d02e-107">URI Parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="9d02e-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9d02e-108">Required Request Headers</span></span>](#ID4EGB)
  * [<span data-ttu-id="9d02e-109">承認</span><span class="sxs-lookup"><span data-stu-id="9d02e-109">Authorization</span></span>](#ID4ELD)
  * [<span data-ttu-id="9d02e-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="9d02e-110">Request Body</span></span>](#ID4EWD)
  * [<span data-ttu-id="9d02e-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9d02e-111">Required Response Headers</span></span>](#ID4EZE)
  * [<span data-ttu-id="9d02e-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="9d02e-112">Response Body</span></span>](#ID4E5G)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9d02e-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d02e-113">URI Parameters</span></span>
 
| <span data-ttu-id="9d02e-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d02e-114">Parameter</span></span>| <span data-ttu-id="9d02e-115">説明</span><span class="sxs-lookup"><span data-stu-id="9d02e-115">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="9d02e-116">titleId</span><span class="sxs-lookup"><span data-stu-id="9d02e-116">titleId</span></span>| <span data-ttu-id="9d02e-117">要求の操作対象のタイトルの ID。</span><span class="sxs-lookup"><span data-stu-id="9d02e-117">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="9d02e-118">ホスト名</span><span class="sxs-lookup"><span data-stu-id="9d02e-118">Host Name</span></span>

<span data-ttu-id="9d02e-119">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="9d02e-119">gameserverms.xboxlive.com</span></span>
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="9d02e-120">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9d02e-120">Required Request Headers</span></span>
 
<span data-ttu-id="9d02e-121">要求を行う場合は、次の表に示されているヘッダーが必要です。</span><span class="sxs-lookup"><span data-stu-id="9d02e-121">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="9d02e-122">Header</span><span class="sxs-lookup"><span data-stu-id="9d02e-122">Header</span></span>| <span data-ttu-id="9d02e-123">Value</span><span class="sxs-lookup"><span data-stu-id="9d02e-123">Value</span></span>| <span data-ttu-id="9d02e-124">説明</span><span class="sxs-lookup"><span data-stu-id="9d02e-124">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="9d02e-125">ユーザー エージェント</span><span class="sxs-lookup"><span data-stu-id="9d02e-125">User-Agent</span></span>|  | <span data-ttu-id="9d02e-126">要求を行うユーザー エージェントに関する情報。</span><span class="sxs-lookup"><span data-stu-id="9d02e-126">Information about the user agent making the request.</span></span>| 
| <span data-ttu-id="9d02e-127">Content-Type</span><span class="sxs-lookup"><span data-stu-id="9d02e-127">Content-Type</span></span>| <span data-ttu-id="9d02e-128">application/json</span><span class="sxs-lookup"><span data-stu-id="9d02e-128">application/json</span></span>| <span data-ttu-id="9d02e-129">送信されるデータの型。</span><span class="sxs-lookup"><span data-stu-id="9d02e-129">Type of data being submitted.</span></span>| 
| <span data-ttu-id="9d02e-130">Host</span><span class="sxs-lookup"><span data-stu-id="9d02e-130">Host</span></span>| <span data-ttu-id="9d02e-131">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="9d02e-131">gameserverms.xboxlive.com</span></span>|  | 
| <span data-ttu-id="9d02e-132">Content-Length</span><span class="sxs-lookup"><span data-stu-id="9d02e-132">Content-Length</span></span>|  | <span data-ttu-id="9d02e-133">要求オブジェクトの長さ。</span><span class="sxs-lookup"><span data-stu-id="9d02e-133">Length of the request object.</span></span>| 
| <span data-ttu-id="9d02e-134">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="9d02e-134">x-xbl-contract-version</span></span>| <span data-ttu-id="9d02e-135">1</span><span class="sxs-lookup"><span data-stu-id="9d02e-135">1</span></span>| <span data-ttu-id="9d02e-136">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="9d02e-136">API contract version.</span></span>| 
| <span data-ttu-id="9d02e-137">Authorization</span><span class="sxs-lookup"><span data-stu-id="9d02e-137">Authorization</span></span>| <span data-ttu-id="9d02e-138">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="9d02e-138">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="9d02e-139">認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="9d02e-139">Authentication token.</span></span>| 
  
<a id="ID4ELD"></a>

 
## <a name="authorization"></a><span data-ttu-id="9d02e-140">Authorization</span><span class="sxs-lookup"><span data-stu-id="9d02e-140">Authorization</span></span>
 
<span data-ttu-id="9d02e-141">要求には、有効な Xbox Live の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d02e-141">The request must include a valid Xbox Live authorization header.</span></span> <span data-ttu-id="9d02e-142">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは応答 403 Forbidden を返します。</span><span class="sxs-lookup"><span data-stu-id="9d02e-142">If the caller is not allowed to access this resource, the service returns 403 Forbidden in response.</span></span> <span data-ttu-id="9d02e-143">ヘッダーが無効であるか不足している場合、サービスは応答で 401 Unauthorized を返します。</span><span class="sxs-lookup"><span data-stu-id="9d02e-143">If the header is invalid or missing, the service returns 401 Unauthorized in response.</span></span>
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="9d02e-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="9d02e-144">Request Body</span></span>
 
<span data-ttu-id="9d02e-145">要求には、次のメンバーを持つ JSON オブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d02e-145">The request must contain a JSON object with the following members.</span></span>
 
| <span data-ttu-id="9d02e-146">メンバー</span><span class="sxs-lookup"><span data-stu-id="9d02e-146">Member</span></span>| <span data-ttu-id="9d02e-147">説明</span><span class="sxs-lookup"><span data-stu-id="9d02e-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="9d02e-148">sessionId</span><span class="sxs-lookup"><span data-stu-id="9d02e-148">sessionId</span></span>| <span data-ttu-id="9d02e-149">MPSD からセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="9d02e-149">Session identifier from the MPSD.</span></span>| 
| <span data-ttu-id="9d02e-150">abortIfQueued</span><span class="sxs-lookup"><span data-stu-id="9d02e-150">abortIfQueued</span></span>| <span data-ttu-id="9d02e-151">省略可能なパラメーターは、どの場合に true に設定されませんをすぐに実行しないことができます、場合にリソースとして、このセッションをキューに GSMS に指示します。</span><span class="sxs-lookup"><span data-stu-id="9d02e-151">Optional parameter, which when set to true tells GSMS not to queue this session for a resource if it can not be fulfilled immediately.</span></span> <span data-ttu-id="9d02e-152">応答オブジェクトには、要求が中止されたは、この値が true であるため場合、<code>"fulfillmentState" : "Aborted"</code>します。</span><span class="sxs-lookup"><span data-stu-id="9d02e-152">If the request is aborted because this value is true, the response object will contain <code>"fulfillmentState" : "Aborted"</code>.</span></span> | 
 
<a id="ID4ERE"></a>

 
### <a name="sample-request"></a><span data-ttu-id="9d02e-153">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="9d02e-153">Sample Request</span></span>
 

```cpp
{
  "sessionId" : "/serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/session/scott1",
  "abortIfQueued" : "true"
}

      
```

   
<a id="ID4EZE"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="9d02e-154">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9d02e-154">Required Response Headers</span></span>
 
<span data-ttu-id="9d02e-155">応答には、常に、次の表に示すようにヘッダーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="9d02e-155">A response will always include the headers shown in the following table.</span></span>
 
| <span data-ttu-id="9d02e-156">Header</span><span class="sxs-lookup"><span data-stu-id="9d02e-156">Header</span></span>| <span data-ttu-id="9d02e-157">Value</span><span class="sxs-lookup"><span data-stu-id="9d02e-157">Value</span></span>| <span data-ttu-id="9d02e-158">説明</span><span class="sxs-lookup"><span data-stu-id="9d02e-158">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="9d02e-159">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="9d02e-159">Cache-Control</span></span>|  | <span data-ttu-id="9d02e-160">要求/応答のチェーンに沿ってすべてのキャッシュ メカニズムによって obeyed する必要がありますディレクティブ。</span><span class="sxs-lookup"><span data-stu-id="9d02e-160">Directives that must be obeyed by all caching mechanisms along the request/response chain.</span></span>| 
| <span data-ttu-id="9d02e-161">Content-Type</span><span class="sxs-lookup"><span data-stu-id="9d02e-161">Content-Type</span></span>| <span data-ttu-id="9d02e-162">application/json</span><span class="sxs-lookup"><span data-stu-id="9d02e-162">application/json</span></span>| <span data-ttu-id="9d02e-163">応答内のデータの型。</span><span class="sxs-lookup"><span data-stu-id="9d02e-163">Type of data in the response.</span></span>| 
| <span data-ttu-id="9d02e-164">Content-Length</span><span class="sxs-lookup"><span data-stu-id="9d02e-164">Content-Length</span></span>|  | <span data-ttu-id="9d02e-165">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="9d02e-165">Length of the response body.</span></span>| 
| <span data-ttu-id="9d02e-166">X のコンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="9d02e-166">X-Content-Type-Options</span></span>|  |  | 
| <span data-ttu-id="9d02e-167">X-XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="9d02e-167">X-XblCorrelationId</span></span>|  | <span data-ttu-id="9d02e-168">応答本文の mime の種類。</span><span class="sxs-lookup"><span data-stu-id="9d02e-168">The mime type of the response body.</span></span>| 
| <span data-ttu-id="9d02e-169">日付</span><span class="sxs-lookup"><span data-stu-id="9d02e-169">Date</span></span>|  |  | 
  
<a id="ID4E5G"></a>

 
## <a name="response-body"></a><span data-ttu-id="9d02e-170">応答本文</span><span class="sxs-lookup"><span data-stu-id="9d02e-170">Response Body</span></span>
 
<span data-ttu-id="9d02e-171">呼び出しが成功した場合、サービスは、次のメンバーを持つ JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="9d02e-171">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="9d02e-172">メンバー</span><span class="sxs-lookup"><span data-stu-id="9d02e-172">Member</span></span>| <span data-ttu-id="9d02e-173">説明</span><span class="sxs-lookup"><span data-stu-id="9d02e-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="9d02e-174">pollIntervalMilliseconds</span><span class="sxs-lookup"><span data-stu-id="9d02e-174">pollIntervalMilliseconds</span></span>| <span data-ttu-id="9d02e-175">(ミリ秒) の完了をポーリングする間隔をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9d02e-175">Recommended interval in ms to poll for completion.</span></span> <span data-ttu-id="9d02e-176">これには、クラスターが準備完了となる場合の推定値ではありませんので注意が、呼び出し元がサブスクリプションと要求と調達の料金の現在のプールを指定された状態の更新をポーリングする頻度の推奨事項ではなく。</span><span class="sxs-lookup"><span data-stu-id="9d02e-176">Note that this is not an estimate of when the cluster will be ready, but rather a recommendation for how frequently the caller should poll for a status update given the current pool of subscriptions and request and fulfillment rates.</span></span>| 
| <span data-ttu-id="9d02e-177">fulfillmentState</span><span class="sxs-lookup"><span data-stu-id="9d02e-177">fulfillmentState</span></span>| <span data-ttu-id="9d02e-178">指定されたセッションは、リソースをすぐに割り当てられたかどうか"Fulfilled、"将来のリソースの可用性のためにキューに追加された"Queued"、ことを示しますまたは中止され、「中止」、要求を処理することができないのためすぐに要求"true"として abortIfQueued を指定します。</span><span class="sxs-lookup"><span data-stu-id="9d02e-178">Indicates whether the provided session was allocated a resource immediately, "Fulfilled", added to the queue for the availability of a future resource, "Queued", or aborted, "Aborted", due to the inability to fulfill the request immediately when the request specified abortIfQueued as "true".</span></span> | 
 
<a id="ID4EWH"></a>

 
### <a name="sample-response"></a><span data-ttu-id="9d02e-179">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="9d02e-179">Sample Response</span></span>
 

```cpp
{
  "pollIntervalMilliseconds" : "1000",
  "fulfillmentState" : "Fulfilled" | "Queued" | "Aborted"
}
      
```

   
<a id="remarks"></a>

 
## <a name="remarks"></a><span data-ttu-id="9d02e-180">注釈</span><span class="sxs-lookup"><span data-stu-id="9d02e-180">Remarks</span></span>
 
<span data-ttu-id="9d02e-181">タイトルがサービスへの呼び出しを再試行する必要がありますは、次の応答コードが受信したときにのみ。</span><span class="sxs-lookup"><span data-stu-id="9d02e-181">A title should only retry the call to the service when the following response codes are received:</span></span>
 
   * <span data-ttu-id="9d02e-182">408-サーバーのタイムアウト</span><span class="sxs-lookup"><span data-stu-id="9d02e-182">408—Server Timeout</span></span>
   * <span data-ttu-id="9d02e-183">429: 要求が多すぎます</span><span class="sxs-lookup"><span data-stu-id="9d02e-183">429—Too Many Requests</span></span>
   * <span data-ttu-id="9d02e-184">500-サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="9d02e-184">500—Server Error</span></span>
   * <span data-ttu-id="9d02e-185">502-無効なゲートウェイ</span><span class="sxs-lookup"><span data-stu-id="9d02e-185">502—Bad Gateway</span></span>
   * <span data-ttu-id="9d02e-186">503-サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="9d02e-186">503—Service Unavailable</span></span>
   * <span data-ttu-id="9d02e-187">504-ゲートウェイ タイムアウト</span><span class="sxs-lookup"><span data-stu-id="9d02e-187">504—Gateway Timeout</span></span>
   
<a id="ID4EFBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9d02e-188">関連項目</span><span class="sxs-lookup"><span data-stu-id="9d02e-188">See also</span></span>
 [<span data-ttu-id="9d02e-189">/titles/{titleId}/clusters</span><span class="sxs-lookup"><span data-stu-id="9d02e-189">/titles/{titleId}/clusters</span></span>](uri-titlestitleidclusters.md)

  