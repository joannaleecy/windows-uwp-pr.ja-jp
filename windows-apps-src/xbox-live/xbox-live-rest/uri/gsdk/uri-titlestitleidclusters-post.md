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
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8748872"
---
# <a name="post-titlestitleidclusters"></a><span data-ttu-id="d1acf-104">POST (/titles/{titleId}/clusters)</span><span class="sxs-lookup"><span data-stu-id="d1acf-104">POST (/titles/{titleId}/clusters)</span></span>
<span data-ttu-id="d1acf-105">クライアントが Xbox Live Compute サーバー インスタンスを作成することができる URI。</span><span class="sxs-lookup"><span data-stu-id="d1acf-105">URI that allows a client to create an Xbox Live Compute server instance.</span></span> <span data-ttu-id="d1acf-106">これらの Uri のドメインが`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d1acf-106">The domain for these URIs is `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d1acf-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d1acf-107">URI Parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="d1acf-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d1acf-108">Required Request Headers</span></span>](#ID4EGB)
  * [<span data-ttu-id="d1acf-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="d1acf-109">Authorization</span></span>](#ID4ELD)
  * [<span data-ttu-id="d1acf-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="d1acf-110">Request Body</span></span>](#ID4EWD)
  * [<span data-ttu-id="d1acf-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d1acf-111">Required Response Headers</span></span>](#ID4EZE)
  * [<span data-ttu-id="d1acf-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="d1acf-112">Response Body</span></span>](#ID4E5G)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d1acf-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d1acf-113">URI Parameters</span></span>
 
| <span data-ttu-id="d1acf-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d1acf-114">Parameter</span></span>| <span data-ttu-id="d1acf-115">説明</span><span class="sxs-lookup"><span data-stu-id="d1acf-115">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="d1acf-116">titleId</span><span class="sxs-lookup"><span data-stu-id="d1acf-116">titleId</span></span>| <span data-ttu-id="d1acf-117">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="d1acf-117">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="d1acf-118">ホスト名</span><span class="sxs-lookup"><span data-stu-id="d1acf-118">Host Name</span></span>

<span data-ttu-id="d1acf-119">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="d1acf-119">gameserverms.xboxlive.com</span></span>
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="d1acf-120">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d1acf-120">Required Request Headers</span></span>
 
<span data-ttu-id="d1acf-121">要求を行う場合、次の表に示すようにヘッダーは必要です。</span><span class="sxs-lookup"><span data-stu-id="d1acf-121">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="d1acf-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d1acf-122">Header</span></span>| <span data-ttu-id="d1acf-123">設定値</span><span class="sxs-lookup"><span data-stu-id="d1acf-123">Value</span></span>| <span data-ttu-id="d1acf-124">説明</span><span class="sxs-lookup"><span data-stu-id="d1acf-124">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="d1acf-125">ユーザー エージェント</span><span class="sxs-lookup"><span data-stu-id="d1acf-125">User-Agent</span></span>|  | <span data-ttu-id="d1acf-126">要求を行っているユーザー エージェントについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d1acf-126">Information about the user agent making the request.</span></span>| 
| <span data-ttu-id="d1acf-127">Content-Type</span><span class="sxs-lookup"><span data-stu-id="d1acf-127">Content-Type</span></span>| <span data-ttu-id="d1acf-128">application/json</span><span class="sxs-lookup"><span data-stu-id="d1acf-128">application/json</span></span>| <span data-ttu-id="d1acf-129">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="d1acf-129">Type of data being submitted.</span></span>| 
| <span data-ttu-id="d1acf-130">Host</span><span class="sxs-lookup"><span data-stu-id="d1acf-130">Host</span></span>| <span data-ttu-id="d1acf-131">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="d1acf-131">gameserverms.xboxlive.com</span></span>|  | 
| <span data-ttu-id="d1acf-132">Content-Length</span><span class="sxs-lookup"><span data-stu-id="d1acf-132">Content-Length</span></span>|  | <span data-ttu-id="d1acf-133">要求のオブジェクトの長さ。</span><span class="sxs-lookup"><span data-stu-id="d1acf-133">Length of the request object.</span></span>| 
| <span data-ttu-id="d1acf-134">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="d1acf-134">x-xbl-contract-version</span></span>| <span data-ttu-id="d1acf-135">1</span><span class="sxs-lookup"><span data-stu-id="d1acf-135">1</span></span>| <span data-ttu-id="d1acf-136">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="d1acf-136">API contract version.</span></span>| 
| <span data-ttu-id="d1acf-137">Authorization</span><span class="sxs-lookup"><span data-stu-id="d1acf-137">Authorization</span></span>| <span data-ttu-id="d1acf-138">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="d1acf-138">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="d1acf-139">認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="d1acf-139">Authentication token.</span></span>| 
  
<a id="ID4ELD"></a>

 
## <a name="authorization"></a><span data-ttu-id="d1acf-140">Authorization</span><span class="sxs-lookup"><span data-stu-id="d1acf-140">Authorization</span></span>
 
<span data-ttu-id="d1acf-141">要求は、Xbox Live の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1acf-141">The request must include a valid Xbox Live authorization header.</span></span> <span data-ttu-id="d1acf-142">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは応答に 403 Forbidden を返します。</span><span class="sxs-lookup"><span data-stu-id="d1acf-142">If the caller is not allowed to access this resource, the service returns 403 Forbidden in response.</span></span> <span data-ttu-id="d1acf-143">ヘッダーが見つからないか無効な場合は、サービスは応答で 401 Unauthorized を返します。</span><span class="sxs-lookup"><span data-stu-id="d1acf-143">If the header is invalid or missing, the service returns 401 Unauthorized in response.</span></span>
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="d1acf-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="d1acf-144">Request Body</span></span>
 
<span data-ttu-id="d1acf-145">要求は、次のメンバーを含む JSON オブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1acf-145">The request must contain a JSON object with the following members.</span></span>
 
| <span data-ttu-id="d1acf-146">メンバー</span><span class="sxs-lookup"><span data-stu-id="d1acf-146">Member</span></span>| <span data-ttu-id="d1acf-147">説明</span><span class="sxs-lookup"><span data-stu-id="d1acf-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d1acf-148">sessionId</span><span class="sxs-lookup"><span data-stu-id="d1acf-148">sessionId</span></span>| <span data-ttu-id="d1acf-149">MPSD からセッション識別子です。</span><span class="sxs-lookup"><span data-stu-id="d1acf-149">Session identifier from the MPSD.</span></span>| 
| <span data-ttu-id="d1acf-150">abortIfQueued</span><span class="sxs-lookup"><span data-stu-id="d1acf-150">abortIfQueued</span></span>| <span data-ttu-id="d1acf-151">省略可能なパラメーターは、どの場合に true に設定する場合はすぐにフルフィルメントしないことができますが、リソースのこのセッションをキューに入れいない GSMS に指示します。</span><span class="sxs-lookup"><span data-stu-id="d1acf-151">Optional parameter, which when set to true tells GSMS not to queue this session for a resource if it can not be fulfilled immediately.</span></span> <span data-ttu-id="d1acf-152">この値が true であるため、要求が中止されると、応答オブジェクトを含むは<code>"fulfillmentState" : "Aborted"</code>します。</span><span class="sxs-lookup"><span data-stu-id="d1acf-152">If the request is aborted because this value is true, the response object will contain <code>"fulfillmentState" : "Aborted"</code>.</span></span> | 
 
<a id="ID4ERE"></a>

 
### <a name="sample-request"></a><span data-ttu-id="d1acf-153">要求の例</span><span class="sxs-lookup"><span data-stu-id="d1acf-153">Sample Request</span></span>
 

```cpp
{
  "sessionId" : "/serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/session/scott1",
  "abortIfQueued" : "true"
}

      
```

   
<a id="ID4EZE"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="d1acf-154">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d1acf-154">Required Response Headers</span></span>
 
<span data-ttu-id="d1acf-155">応答は常に、次の表に示すようにヘッダーを含めます。</span><span class="sxs-lookup"><span data-stu-id="d1acf-155">A response will always include the headers shown in the following table.</span></span>
 
| <span data-ttu-id="d1acf-156">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d1acf-156">Header</span></span>| <span data-ttu-id="d1acf-157">設定値</span><span class="sxs-lookup"><span data-stu-id="d1acf-157">Value</span></span>| <span data-ttu-id="d1acf-158">説明</span><span class="sxs-lookup"><span data-stu-id="d1acf-158">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d1acf-159">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="d1acf-159">Cache-Control</span></span>|  | <span data-ttu-id="d1acf-160">ディレクティブ要求/応答のチェーンに沿ったのすべてのキャッシュ メカニズムによって obeyed する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1acf-160">Directives that must be obeyed by all caching mechanisms along the request/response chain.</span></span>| 
| <span data-ttu-id="d1acf-161">Content-Type</span><span class="sxs-lookup"><span data-stu-id="d1acf-161">Content-Type</span></span>| <span data-ttu-id="d1acf-162">application/json</span><span class="sxs-lookup"><span data-stu-id="d1acf-162">application/json</span></span>| <span data-ttu-id="d1acf-163">応答には、データの種類です。</span><span class="sxs-lookup"><span data-stu-id="d1acf-163">Type of data in the response.</span></span>| 
| <span data-ttu-id="d1acf-164">Content-Length</span><span class="sxs-lookup"><span data-stu-id="d1acf-164">Content-Length</span></span>|  | <span data-ttu-id="d1acf-165">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="d1acf-165">Length of the response body.</span></span>| 
| <span data-ttu-id="d1acf-166">X コンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="d1acf-166">X-Content-Type-Options</span></span>|  |  | 
| <span data-ttu-id="d1acf-167">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="d1acf-167">X-XblCorrelationId</span></span>|  | <span data-ttu-id="d1acf-168">応答本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="d1acf-168">The mime type of the response body.</span></span>| 
| <span data-ttu-id="d1acf-169">Date</span><span class="sxs-lookup"><span data-stu-id="d1acf-169">Date</span></span>|  |  | 
  
<a id="ID4E5G"></a>

 
## <a name="response-body"></a><span data-ttu-id="d1acf-170">応答本文</span><span class="sxs-lookup"><span data-stu-id="d1acf-170">Response Body</span></span>
 
<span data-ttu-id="d1acf-171">呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="d1acf-171">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="d1acf-172">メンバー</span><span class="sxs-lookup"><span data-stu-id="d1acf-172">Member</span></span>| <span data-ttu-id="d1acf-173">説明</span><span class="sxs-lookup"><span data-stu-id="d1acf-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d1acf-174">pollIntervalMilliseconds</span><span class="sxs-lookup"><span data-stu-id="d1acf-174">pollIntervalMilliseconds</span></span>| <span data-ttu-id="d1acf-175">(ミリ秒) の完了をポーリング間隔をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d1acf-175">Recommended interval in ms to poll for completion.</span></span> <span data-ttu-id="d1acf-176">注意がこれには、クラスターが準備ができたらときの推定値ではありませんが、サブスクリプションと要求とフルフィルメントの完了率の現在のプールを指定された状態を更新する頻度、呼び出し元のポーリングを行うための推奨事項ではなく。</span><span class="sxs-lookup"><span data-stu-id="d1acf-176">Note that this is not an estimate of when the cluster will be ready, but rather a recommendation for how frequently the caller should poll for a status update given the current pool of subscriptions and request and fulfillment rates.</span></span>| 
| <span data-ttu-id="d1acf-177">fulfillmentState</span><span class="sxs-lookup"><span data-stu-id="d1acf-177">fulfillmentState</span></span>| <span data-ttu-id="d1acf-178">示します提供されているセッションは、リソースをすぐに割り当てられたかどうか「フルフィルメント、」リソースの今後の可用性のキューに追加される「キューに入れ」、または中止され、「中止」、要求を処理することができない原因とすぐに、要求"true"と指定した abortIfQueued します。</span><span class="sxs-lookup"><span data-stu-id="d1acf-178">Indicates whether the provided session was allocated a resource immediately, "Fulfilled", added to the queue for the availability of a future resource, "Queued", or aborted, "Aborted", due to the inability to fulfill the request immediately when the request specified abortIfQueued as "true".</span></span> | 
 
<a id="ID4EWH"></a>

 
### <a name="sample-response"></a><span data-ttu-id="d1acf-179">応答の例</span><span class="sxs-lookup"><span data-stu-id="d1acf-179">Sample Response</span></span>
 

```cpp
{
  "pollIntervalMilliseconds" : "1000",
  "fulfillmentState" : "Fulfilled" | "Queued" | "Aborted"
}
      
```

   
<a id="remarks"></a>

 
## <a name="remarks"></a><span data-ttu-id="d1acf-180">注釈</span><span class="sxs-lookup"><span data-stu-id="d1acf-180">Remarks</span></span>
 
<span data-ttu-id="d1acf-181">次の応答コードを受け取ったとき、タイトルはサービスに呼び出しをのみ再試行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1acf-181">A title should only retry the call to the service when the following response codes are received:</span></span>
 
   * <span data-ttu-id="d1acf-182">408-サーバー タイムアウト</span><span class="sxs-lookup"><span data-stu-id="d1acf-182">408—Server Timeout</span></span>
   * <span data-ttu-id="d1acf-183">429: too Many Requests</span><span class="sxs-lookup"><span data-stu-id="d1acf-183">429—Too Many Requests</span></span>
   * <span data-ttu-id="d1acf-184">500-サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="d1acf-184">500—Server Error</span></span>
   * <span data-ttu-id="d1acf-185">502-無効なゲートウェイ</span><span class="sxs-lookup"><span data-stu-id="d1acf-185">502—Bad Gateway</span></span>
   * <span data-ttu-id="d1acf-186">503-サービスを利用できません</span><span class="sxs-lookup"><span data-stu-id="d1acf-186">503—Service Unavailable</span></span>
   * <span data-ttu-id="d1acf-187">504-ゲートウェイ タイムアウト</span><span class="sxs-lookup"><span data-stu-id="d1acf-187">504—Gateway Timeout</span></span>
   
<a id="ID4EFBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d1acf-188">関連項目</span><span class="sxs-lookup"><span data-stu-id="d1acf-188">See also</span></span>
 [<span data-ttu-id="d1acf-189">/titles/{titleId}/clusters</span><span class="sxs-lookup"><span data-stu-id="d1acf-189">/titles/{titleId}/clusters</span></span>](uri-titlestitleidclusters.md)

  