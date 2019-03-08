---
title: GET (/{uri})
assetID: a67a3288-88f9-c504-5fa8-8fd06055d079
permalink: en-us/docs/xboxlive/rest/uri-uriget.html
description: " GET (/{uri})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 757d84c9ad5a005e042b42d699ada08504dc57ff
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650617"
---
# <a name="get-uri"></a><span data-ttu-id="ecec9-104">GET (/{uri})</span><span class="sxs-lookup"><span data-stu-id="ecec9-104">GET (/{uri})</span></span>
<span data-ttu-id="ecec9-105">ゲームのクリップをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="ecec9-105">Download game clip.</span></span> <span data-ttu-id="ecec9-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="ecec9-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="ecec9-107">注釈</span><span class="sxs-lookup"><span data-stu-id="ecec9-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="ecec9-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ecec9-108">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="ecec9-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ecec9-109">Required Request Headers</span></span>](#ID4EEC)
  * [<span data-ttu-id="ecec9-110">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ecec9-110">Optional Request Headers</span></span>](#ID4EQE)
  * [<span data-ttu-id="ecec9-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="ecec9-111">Request body</span></span>](#ID4EZF)
  * [<span data-ttu-id="ecec9-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ecec9-112">Required Response Headers</span></span>](#ID4EEG)
  * [<span data-ttu-id="ecec9-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="ecec9-113">HTTP status codes</span></span>](#ID4EYAAC)
  * [<span data-ttu-id="ecec9-114">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ecec9-114">Optional Response Headers</span></span>](#ID4EOFAC)
  * [<span data-ttu-id="ecec9-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="ecec9-115">Response body</span></span>](#ID4EOGAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="ecec9-116">注釈</span><span class="sxs-lookup"><span data-stu-id="ecec9-116">Remarks</span></span>
 
<span data-ttu-id="ecec9-117">クリップまたは縮小表示が発行済み状態に達するし、ダウンロード可能な型で指定されているは、クライアントがダウンロードできる、 **GameClipUri**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ecec9-117">The client can download any clip or thumbnail that has reached the Published state and is of the Downloadable type, as specified in a **GameClipUri** object.</span></span> <span data-ttu-id="ecec9-118">ユーザーまたはパブリックのクリップの一覧を取得するときに、応答本文で、ファイルを要求するための URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ecec9-118">The URI for requesting the file is included in the response body when retrieving a list of user or public clips.</span></span>
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ecec9-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ecec9-119">URI parameters</span></span>
 
| <span data-ttu-id="ecec9-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ecec9-120">Parameter</span></span>| <span data-ttu-id="ecec9-121">種類</span><span class="sxs-lookup"><span data-stu-id="ecec9-121">Type</span></span>| <span data-ttu-id="ecec9-122">説明</span><span class="sxs-lookup"><span data-stu-id="ecec9-122">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ecec9-123"><b>Uri</b></span><span class="sxs-lookup"><span data-stu-id="ecec9-123"><b>uri</b></span></span>| <span data-ttu-id="ecec9-124">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-124">string</span></span>| <span data-ttu-id="ecec9-125"><b>Uri</b>内でフィールド、 <b>GameClipUri</b>オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ecec9-125">The <b>uri</b> field within the <b>GameClipUri</b> object.</span></span>| 
  
<a id="ID4EEC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="ecec9-126">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ecec9-126">Required Request Headers</span></span>
 
| <span data-ttu-id="ecec9-127">Header</span><span class="sxs-lookup"><span data-stu-id="ecec9-127">Header</span></span>| <span data-ttu-id="ecec9-128">種類</span><span class="sxs-lookup"><span data-stu-id="ecec9-128">Type</span></span>| <span data-ttu-id="ecec9-129">説明</span><span class="sxs-lookup"><span data-stu-id="ecec9-129">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ecec9-130">Authorization</span><span class="sxs-lookup"><span data-stu-id="ecec9-130">Authorization</span></span>| <span data-ttu-id="ecec9-131">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-131">string</span></span>| <span data-ttu-id="ecec9-132">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-132">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="ecec9-133">値の例:<b>Xauth=&lt;authtoken></b></span><span class="sxs-lookup"><span data-stu-id="ecec9-133">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="ecec9-134">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="ecec9-134">X-RequestedServiceVersion</span></span>| <span data-ttu-id="ecec9-135">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-135">string</span></span>| <span data-ttu-id="ecec9-136">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="ecec9-136">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="ecec9-137">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="ecec9-137">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="ecec9-138">Content-Type</span><span class="sxs-lookup"><span data-stu-id="ecec9-138">Content-Type</span></span>| <span data-ttu-id="ecec9-139">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-139">string</span></span>| <span data-ttu-id="ecec9-140">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="ecec9-140">MIME type of the response body.</span></span> <span data-ttu-id="ecec9-141">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-141">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="ecec9-142">OK</span><span class="sxs-lookup"><span data-stu-id="ecec9-142">Accept</span></span>| <span data-ttu-id="ecec9-143">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-143">string</span></span>| <span data-ttu-id="ecec9-144">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="ecec9-144">Acceptable values of Content-Type.</span></span> <span data-ttu-id="ecec9-145">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-145">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="ecec9-146">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="ecec9-146">Cache-Control</span></span>| <span data-ttu-id="ecec9-147">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-147">string</span></span>| <span data-ttu-id="ecec9-148">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="ecec9-148">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EQE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="ecec9-149">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ecec9-149">Optional Request Headers</span></span>
 
| <span data-ttu-id="ecec9-150">Header</span><span class="sxs-lookup"><span data-stu-id="ecec9-150">Header</span></span>| <span data-ttu-id="ecec9-151">種類</span><span class="sxs-lookup"><span data-stu-id="ecec9-151">Type</span></span>| <span data-ttu-id="ecec9-152">説明</span><span class="sxs-lookup"><span data-stu-id="ecec9-152">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ecec9-153">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="ecec9-153">Accept-Encoding</span></span>| <span data-ttu-id="ecec9-154">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-154">string</span></span>| <span data-ttu-id="ecec9-155">許容される圧縮エンコーディング。</span><span class="sxs-lookup"><span data-stu-id="ecec9-155">Acceptable compression encodings.</span></span> <span data-ttu-id="ecec9-156">値の例: gzip、deflate の id。</span><span class="sxs-lookup"><span data-stu-id="ecec9-156">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="ecec9-157">ETag</span><span class="sxs-lookup"><span data-stu-id="ecec9-157">ETag</span></span>| <span data-ttu-id="ecec9-158">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-158">string</span></span>| <span data-ttu-id="ecec9-159">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="ecec9-159">Used for cache optimization.</span></span> <span data-ttu-id="ecec9-160">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="ecec9-160">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EZF"></a>

 
## <a name="request-body"></a><span data-ttu-id="ecec9-161">要求本文</span><span class="sxs-lookup"><span data-stu-id="ecec9-161">Request body</span></span>
 
<span data-ttu-id="ecec9-162">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="ecec9-162">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EEG"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="ecec9-163">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ecec9-163">Required Response Headers</span></span>
 
| <span data-ttu-id="ecec9-164">Header</span><span class="sxs-lookup"><span data-stu-id="ecec9-164">Header</span></span>| <span data-ttu-id="ecec9-165">種類</span><span class="sxs-lookup"><span data-stu-id="ecec9-165">Type</span></span>| <span data-ttu-id="ecec9-166">説明</span><span class="sxs-lookup"><span data-stu-id="ecec9-166">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ecec9-167">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="ecec9-167">X-RequestedServiceVersion</span></span>| <span data-ttu-id="ecec9-168">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-168">string</span></span>| <span data-ttu-id="ecec9-169">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="ecec9-169">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="ecec9-170">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="ecec9-170">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="ecec9-171">Content-Type</span><span class="sxs-lookup"><span data-stu-id="ecec9-171">Content-Type</span></span>| <span data-ttu-id="ecec9-172">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-172">string</span></span>| <span data-ttu-id="ecec9-173">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="ecec9-173">MIME type of the response body.</span></span> <span data-ttu-id="ecec9-174">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-174">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="ecec9-175">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="ecec9-175">Cache-Control</span></span>| <span data-ttu-id="ecec9-176">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-176">string</span></span>| <span data-ttu-id="ecec9-177">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="ecec9-177">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="ecec9-178">OK</span><span class="sxs-lookup"><span data-stu-id="ecec9-178">Accept</span></span>| <span data-ttu-id="ecec9-179">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-179">string</span></span>| <span data-ttu-id="ecec9-180">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="ecec9-180">Acceptable values of Content-Type.</span></span> <span data-ttu-id="ecec9-181">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-181">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="ecec9-182">再試行後</span><span class="sxs-lookup"><span data-stu-id="ecec9-182">Retry-After</span></span>| <span data-ttu-id="ecec9-183">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-183">string</span></span>| <span data-ttu-id="ecec9-184">後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-184">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="ecec9-185">異なる</span><span class="sxs-lookup"><span data-stu-id="ecec9-185">Vary</span></span>| <span data-ttu-id="ecec9-186">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-186">string</span></span>| <span data-ttu-id="ecec9-187">ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-187">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4EYAAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="ecec9-188">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="ecec9-188">HTTP status codes</span></span>
 
<span data-ttu-id="ecec9-189">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-189">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="ecec9-190">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-190">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="ecec9-191">コード</span><span class="sxs-lookup"><span data-stu-id="ecec9-191">Code</span></span>| <span data-ttu-id="ecec9-192">理由語句</span><span class="sxs-lookup"><span data-stu-id="ecec9-192">Reason phrase</span></span>| <span data-ttu-id="ecec9-193">説明</span><span class="sxs-lookup"><span data-stu-id="ecec9-193">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ecec9-194">200</span><span class="sxs-lookup"><span data-stu-id="ecec9-194">200</span></span>| <span data-ttu-id="ecec9-195">OK</span><span class="sxs-lookup"><span data-stu-id="ecec9-195">OK</span></span>| <span data-ttu-id="ecec9-196">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-196">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="ecec9-197">301</span><span class="sxs-lookup"><span data-stu-id="ecec9-197">301</span></span>| <span data-ttu-id="ecec9-198">完全に移動</span><span class="sxs-lookup"><span data-stu-id="ecec9-198">Moved Permanently</span></span>| <span data-ttu-id="ecec9-199">サービスが別の URI に移動します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-199">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="ecec9-200">307</span><span class="sxs-lookup"><span data-stu-id="ecec9-200">307</span></span>| <span data-ttu-id="ecec9-201">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="ecec9-201">Temporary Redirect</span></span>| <span data-ttu-id="ecec9-202">サービスが別の URI に移動します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-202">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="ecec9-203">400</span><span class="sxs-lookup"><span data-stu-id="ecec9-203">400</span></span>| <span data-ttu-id="ecec9-204">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="ecec9-204">Bad Request</span></span>| <span data-ttu-id="ecec9-205">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="ecec9-205">Service could not understand malformed request.</span></span> <span data-ttu-id="ecec9-206">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="ecec9-206">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="ecec9-207">401</span><span class="sxs-lookup"><span data-stu-id="ecec9-207">401</span></span>| <span data-ttu-id="ecec9-208">権限がありません</span><span class="sxs-lookup"><span data-stu-id="ecec9-208">Unauthorized</span></span>| <span data-ttu-id="ecec9-209">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="ecec9-209">The request requires user authentication.</span></span>| 
| <span data-ttu-id="ecec9-210">403</span><span class="sxs-lookup"><span data-stu-id="ecec9-210">403</span></span>| <span data-ttu-id="ecec9-211">Forbidden</span><span class="sxs-lookup"><span data-stu-id="ecec9-211">Forbidden</span></span>| <span data-ttu-id="ecec9-212">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="ecec9-212">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="ecec9-213">404</span><span class="sxs-lookup"><span data-stu-id="ecec9-213">404</span></span>| <span data-ttu-id="ecec9-214">検出不可</span><span class="sxs-lookup"><span data-stu-id="ecec9-214">Not Found</span></span>| <span data-ttu-id="ecec9-215">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="ecec9-215">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="ecec9-216">406</span><span class="sxs-lookup"><span data-stu-id="ecec9-216">406</span></span>| <span data-ttu-id="ecec9-217">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="ecec9-217">Not Acceptable</span></span>| <span data-ttu-id="ecec9-218">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="ecec9-218">Resource version is not supported.</span></span>| 
| <span data-ttu-id="ecec9-219">408</span><span class="sxs-lookup"><span data-stu-id="ecec9-219">408</span></span>| <span data-ttu-id="ecec9-220">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="ecec9-220">Request Timeout</span></span>| <span data-ttu-id="ecec9-221">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-221">The request took too long to complete.</span></span>| 
| <span data-ttu-id="ecec9-222">410</span><span class="sxs-lookup"><span data-stu-id="ecec9-222">410</span></span>| <span data-ttu-id="ecec9-223">なった</span><span class="sxs-lookup"><span data-stu-id="ecec9-223">Gone</span></span>| <span data-ttu-id="ecec9-224">要求されたリソースは使用できなくします。</span><span class="sxs-lookup"><span data-stu-id="ecec9-224">The requested resource is no longer available.</span></span>| 
  
<a id="ID4EOFAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="ecec9-225">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ecec9-225">Optional Response Headers</span></span>
 
| <span data-ttu-id="ecec9-226">Header</span><span class="sxs-lookup"><span data-stu-id="ecec9-226">Header</span></span>| <span data-ttu-id="ecec9-227">種類</span><span class="sxs-lookup"><span data-stu-id="ecec9-227">Type</span></span>| <span data-ttu-id="ecec9-228">説明</span><span class="sxs-lookup"><span data-stu-id="ecec9-228">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ecec9-229">Etag</span><span class="sxs-lookup"><span data-stu-id="ecec9-229">Etag</span></span>| <span data-ttu-id="ecec9-230">string</span><span class="sxs-lookup"><span data-stu-id="ecec9-230">string</span></span>| <span data-ttu-id="ecec9-231">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="ecec9-231">Used for cache optimization.</span></span> <span data-ttu-id="ecec9-232">以下に例を示します。"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="ecec9-232">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EOGAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="ecec9-233">応答本文</span><span class="sxs-lookup"><span data-stu-id="ecec9-233">Response body</span></span>
 
<a id="ID4EUGAC"></a>

  
 
<span data-ttu-id="ecec9-234">成功した場合、サーバーは範囲の要求ヘッダーに従って切り捨てられる可能性があります、ビデオ クリップを返します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-234">If successful, the server will return the video clip, possibly truncated according to the Range request header.</span></span> <span data-ttu-id="ecec9-235">切り捨てられたクリップ、応答を Partial Content (206) になります。</span><span class="sxs-lookup"><span data-stu-id="ecec9-235">For a truncated clip, the response will be Partial Content (206).</span></span> <span data-ttu-id="ecec9-236">サーバーは、ファイル全体を返します、これは OK (200) が応答します。</span><span class="sxs-lookup"><span data-stu-id="ecec9-236">If the server returns the entire file, it will respond OK (200).</span></span> <span data-ttu-id="ecec9-237">エラーの場合、 **GameClipsServiceErrorResponse**オブジェクトは、適切な HTTP ステータス コード (例: 416、Requested Range Not Satisfiable) と共に返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ecec9-237">On error, a **GameClipsServiceErrorResponse** object may be returned along with an appropriate HTTP status code (e.g., 416, Requested Range Not Satisfiable).</span></span>
   
<a id="ID4E4GAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ecec9-238">関連項目</span><span class="sxs-lookup"><span data-stu-id="ecec9-238">See also</span></span>
 
<a id="ID4E6GAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ecec9-239">Parent</span><span class="sxs-lookup"><span data-stu-id="ecec9-239">Parent</span></span> 

[<span data-ttu-id="ecec9-240">/{uri}</span><span class="sxs-lookup"><span data-stu-id="ecec9-240">/{uri}</span></span>](uri-uri.md)

   