---
title: POST (/titles/{titleId}/clusters)
assetID: 0977b0b0-872d-f7ad-9ba0-30d56cff4912
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidclusters-post.html
author: KevinAsgari
description: " POST (/titles/{titleId}/clusters)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 459624ea487c158f3fc92b9c6024b086d49c204e
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4017901"
---
# <a name="post-titlestitleidclusters"></a><span data-ttu-id="fd7dd-104">POST (/titles/{titleId}/clusters)</span><span class="sxs-lookup"><span data-stu-id="fd7dd-104">POST (/titles/{titleId}/clusters)</span></span>
<span data-ttu-id="fd7dd-105">Xbox Live Compute サーバー インスタンスを作成するクライアントをできる URI。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-105">URI that allows a client to create an Xbox Live Compute server instance.</span></span> <span data-ttu-id="fd7dd-106">これらの Uri のドメインが`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-106">The domain for these URIs is `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="fd7dd-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fd7dd-107">URI Parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="fd7dd-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd7dd-108">Required Request Headers</span></span>](#ID4EGB)
  * [<span data-ttu-id="fd7dd-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="fd7dd-109">Authorization</span></span>](#ID4ELD)
  * [<span data-ttu-id="fd7dd-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="fd7dd-110">Request Body</span></span>](#ID4EWD)
  * [<span data-ttu-id="fd7dd-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd7dd-111">Required Response Headers</span></span>](#ID4EZE)
  * [<span data-ttu-id="fd7dd-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="fd7dd-112">Response Body</span></span>](#ID4E5G)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="fd7dd-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fd7dd-113">URI Parameters</span></span>
 
| <span data-ttu-id="fd7dd-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fd7dd-114">Parameter</span></span>| <span data-ttu-id="fd7dd-115">説明</span><span class="sxs-lookup"><span data-stu-id="fd7dd-115">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="fd7dd-116">titleId</span><span class="sxs-lookup"><span data-stu-id="fd7dd-116">titleId</span></span>| <span data-ttu-id="fd7dd-117">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-117">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="fd7dd-118">ホスト名</span><span class="sxs-lookup"><span data-stu-id="fd7dd-118">Host Name</span></span>

<span data-ttu-id="fd7dd-119">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="fd7dd-119">gameserverms.xboxlive.com</span></span>
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="fd7dd-120">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd7dd-120">Required Request Headers</span></span>
 
<span data-ttu-id="fd7dd-121">要求を行う場合、次の表に示すようにヘッダーは必要です。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-121">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="fd7dd-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd7dd-122">Header</span></span>| <span data-ttu-id="fd7dd-123">設定値</span><span class="sxs-lookup"><span data-stu-id="fd7dd-123">Value</span></span>| <span data-ttu-id="fd7dd-124">説明</span><span class="sxs-lookup"><span data-stu-id="fd7dd-124">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="fd7dd-125">ユーザー エージェント</span><span class="sxs-lookup"><span data-stu-id="fd7dd-125">User-Agent</span></span>|  | <span data-ttu-id="fd7dd-126">要求を行っているユーザー エージェントについて説明します。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-126">Information about the user agent making the request.</span></span>| 
| <span data-ttu-id="fd7dd-127">Content-Type</span><span class="sxs-lookup"><span data-stu-id="fd7dd-127">Content-Type</span></span>| <span data-ttu-id="fd7dd-128">application/json</span><span class="sxs-lookup"><span data-stu-id="fd7dd-128">application/json</span></span>| <span data-ttu-id="fd7dd-129">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-129">Type of data being submitted.</span></span>| 
| <span data-ttu-id="fd7dd-130">Host</span><span class="sxs-lookup"><span data-stu-id="fd7dd-130">Host</span></span>| <span data-ttu-id="fd7dd-131">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="fd7dd-131">gameserverms.xboxlive.com</span></span>|  | 
| <span data-ttu-id="fd7dd-132">Content-Length</span><span class="sxs-lookup"><span data-stu-id="fd7dd-132">Content-Length</span></span>|  | <span data-ttu-id="fd7dd-133">要求オブジェクトの長さ。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-133">Length of the request object.</span></span>| 
| <span data-ttu-id="fd7dd-134">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="fd7dd-134">x-xbl-contract-version</span></span>| <span data-ttu-id="fd7dd-135">1</span><span class="sxs-lookup"><span data-stu-id="fd7dd-135">1</span></span>| <span data-ttu-id="fd7dd-136">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-136">API contract version.</span></span>| 
| <span data-ttu-id="fd7dd-137">Authorization</span><span class="sxs-lookup"><span data-stu-id="fd7dd-137">Authorization</span></span>| <span data-ttu-id="fd7dd-138">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="fd7dd-138">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="fd7dd-139">認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-139">Authentication token.</span></span>| 
  
<a id="ID4ELD"></a>

 
## <a name="authorization"></a><span data-ttu-id="fd7dd-140">Authorization</span><span class="sxs-lookup"><span data-stu-id="fd7dd-140">Authorization</span></span>
 
<span data-ttu-id="fd7dd-141">要求は、Xbox Live の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-141">The request must include a valid Xbox Live authorization header.</span></span> <span data-ttu-id="fd7dd-142">呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは応答に 403 Forbidden を返します。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-142">If the caller is not allowed to access this resource, the service returns 403 Forbidden in response.</span></span> <span data-ttu-id="fd7dd-143">ヘッダーが見つからないか無効な場合は、サービスは応答で 401 Unauthorized を返します。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-143">If the header is invalid or missing, the service returns 401 Unauthorized in response.</span></span>
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="fd7dd-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="fd7dd-144">Request Body</span></span>
 
<span data-ttu-id="fd7dd-145">要求は、次のメンバーを含む JSON オブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-145">The request must contain a JSON object with the following members.</span></span>
 
| <span data-ttu-id="fd7dd-146">メンバー</span><span class="sxs-lookup"><span data-stu-id="fd7dd-146">Member</span></span>| <span data-ttu-id="fd7dd-147">説明</span><span class="sxs-lookup"><span data-stu-id="fd7dd-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fd7dd-148">sessionId</span><span class="sxs-lookup"><span data-stu-id="fd7dd-148">sessionId</span></span>| <span data-ttu-id="fd7dd-149">MPSD からセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-149">Session identifier from the MPSD.</span></span>| 
| <span data-ttu-id="fd7dd-150">abortIfQueued</span><span class="sxs-lookup"><span data-stu-id="fd7dd-150">abortIfQueued</span></span>| <span data-ttu-id="fd7dd-151">省略可能なパラメーターは、どの場合に true に設定する場合はすぐにフルフィルメントしないことができますが、リソースのこのセッションをキューに入れいない GSMS に指示します。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-151">Optional parameter, which when set to true tells GSMS not to queue this session for a resource if it can not be fulfilled immediately.</span></span> <span data-ttu-id="fd7dd-152">この値が true であるため、要求が中止されると、応答オブジェクトに含まは<code>"fulfillmentState" : "Aborted"</code>します。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-152">If the request is aborted because this value is true, the response object will contain <code>"fulfillmentState" : "Aborted"</code>.</span></span> | 
 
<a id="ID4ERE"></a>

 
### <a name="sample-request"></a><span data-ttu-id="fd7dd-153">要求の例</span><span class="sxs-lookup"><span data-stu-id="fd7dd-153">Sample Request</span></span>
 

```cpp
{
  "sessionId" : "/serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/session/scott1",
  "abortIfQueued" : "true"
}

      
```

   
<a id="ID4EZE"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="fd7dd-154">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd7dd-154">Required Response Headers</span></span>
 
<span data-ttu-id="fd7dd-155">応答は常に、次の表に示すようにヘッダーを含めます。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-155">A response will always include the headers shown in the following table.</span></span>
 
| <span data-ttu-id="fd7dd-156">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd7dd-156">Header</span></span>| <span data-ttu-id="fd7dd-157">設定値</span><span class="sxs-lookup"><span data-stu-id="fd7dd-157">Value</span></span>| <span data-ttu-id="fd7dd-158">説明</span><span class="sxs-lookup"><span data-stu-id="fd7dd-158">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fd7dd-159">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="fd7dd-159">Cache-Control</span></span>|  | <span data-ttu-id="fd7dd-160">ディレクティブ要求/応答のチェーンに沿ったすべてのキャッシュ メカニズムによって obeyed する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-160">Directives that must be obeyed by all caching mechanisms along the request/response chain.</span></span>| 
| <span data-ttu-id="fd7dd-161">Content-Type</span><span class="sxs-lookup"><span data-stu-id="fd7dd-161">Content-Type</span></span>| <span data-ttu-id="fd7dd-162">application/json</span><span class="sxs-lookup"><span data-stu-id="fd7dd-162">application/json</span></span>| <span data-ttu-id="fd7dd-163">応答には、データの種類です。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-163">Type of data in the response.</span></span>| 
| <span data-ttu-id="fd7dd-164">Content-Length</span><span class="sxs-lookup"><span data-stu-id="fd7dd-164">Content-Length</span></span>|  | <span data-ttu-id="fd7dd-165">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-165">Length of the response body.</span></span>| 
| <span data-ttu-id="fd7dd-166">X コンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="fd7dd-166">X-Content-Type-Options</span></span>|  |  | 
| <span data-ttu-id="fd7dd-167">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="fd7dd-167">X-XblCorrelationId</span></span>|  | <span data-ttu-id="fd7dd-168">応答本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-168">The mime type of the response body.</span></span>| 
| <span data-ttu-id="fd7dd-169">Date</span><span class="sxs-lookup"><span data-stu-id="fd7dd-169">Date</span></span>|  |  | 
  
<a id="ID4E5G"></a>

 
## <a name="response-body"></a><span data-ttu-id="fd7dd-170">応答本文</span><span class="sxs-lookup"><span data-stu-id="fd7dd-170">Response Body</span></span>
 
<span data-ttu-id="fd7dd-171">呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-171">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="fd7dd-172">メンバー</span><span class="sxs-lookup"><span data-stu-id="fd7dd-172">Member</span></span>| <span data-ttu-id="fd7dd-173">説明</span><span class="sxs-lookup"><span data-stu-id="fd7dd-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fd7dd-174">pollIntervalMilliseconds</span><span class="sxs-lookup"><span data-stu-id="fd7dd-174">pollIntervalMilliseconds</span></span>| <span data-ttu-id="fd7dd-175">(ミリ秒) の完了をポーリング間隔をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-175">Recommended interval in ms to poll for completion.</span></span> <span data-ttu-id="fd7dd-176">注意がこれには、クラスターが準備ができたら、するときの推定値ではありませんが、サブスクリプションとレートを要求し、フルフィルメントの現在のプールを指定された状態を更新する頻度、呼び出し元のポーリングを行うための推奨事項ではなく。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-176">Note that this is not an estimate of when the cluster will be ready, but rather a recommendation for how frequently the caller should poll for a status update given the current pool of subscriptions and request and fulfillment rates.</span></span>| 
| <span data-ttu-id="fd7dd-177">fulfillmentState</span><span class="sxs-lookup"><span data-stu-id="fd7dd-177">fulfillmentState</span></span>| <span data-ttu-id="fd7dd-178">提供されているセッションは、リソースをすぐに割り当てられたかどうか「フルフィルメント、」リソースの今後の可用性のキューに追加される「キューに入れ」を示すまたは中止され、「中止」、要求を処理することができない原因とすぐに要求"true"と指定した abortIfQueued します。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-178">Indicates whether the provided session was allocated a resource immediately, "Fulfilled", added to the queue for the availability of a future resource, "Queued", or aborted, "Aborted", due to the inability to fulfill the request immediately when the request specified abortIfQueued as "true".</span></span> | 
 
<a id="ID4EWH"></a>

 
### <a name="sample-response"></a><span data-ttu-id="fd7dd-179">応答の例</span><span class="sxs-lookup"><span data-stu-id="fd7dd-179">Sample Response</span></span>
 

```cpp
{
  "pollIntervalMilliseconds" : "1000",
  "fulfillmentState" : "Fulfilled" | "Queued" | "Aborted"
}
      
```

   
<a id="remarks"></a>

 
## <a name="remarks"></a><span data-ttu-id="fd7dd-180">注釈</span><span class="sxs-lookup"><span data-stu-id="fd7dd-180">Remarks</span></span>
 
<span data-ttu-id="fd7dd-181">次の応答コードを受け取ったとき、タイトルはサービスへの呼び出しをのみ再試行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd7dd-181">A title should only retry the call to the service when the following response codes are received:</span></span>
 
   * <span data-ttu-id="fd7dd-182">408-サーバー タイムアウト</span><span class="sxs-lookup"><span data-stu-id="fd7dd-182">408—Server Timeout</span></span>
   * <span data-ttu-id="fd7dd-183">429: too Many Requests</span><span class="sxs-lookup"><span data-stu-id="fd7dd-183">429—Too Many Requests</span></span>
   * <span data-ttu-id="fd7dd-184">500-サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="fd7dd-184">500—Server Error</span></span>
   * <span data-ttu-id="fd7dd-185">502-無効なゲートウェイ</span><span class="sxs-lookup"><span data-stu-id="fd7dd-185">502—Bad Gateway</span></span>
   * <span data-ttu-id="fd7dd-186">503-Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="fd7dd-186">503—Service Unavailable</span></span>
   * <span data-ttu-id="fd7dd-187">504-ゲートウェイ タイムアウト</span><span class="sxs-lookup"><span data-stu-id="fd7dd-187">504—Gateway Timeout</span></span>
   
<a id="ID4EFBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="fd7dd-188">関連項目</span><span class="sxs-lookup"><span data-stu-id="fd7dd-188">See also</span></span>
 [<span data-ttu-id="fd7dd-189">/titles/{titleId}/clusters</span><span class="sxs-lookup"><span data-stu-id="fd7dd-189">/titles/{titleId}/clusters</span></span>](uri-titlestitleidclusters.md)

  