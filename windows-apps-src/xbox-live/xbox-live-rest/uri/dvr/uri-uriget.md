---
title: GET (/{uri})
assetID: a67a3288-88f9-c504-5fa8-8fd06055d079
permalink: en-us/docs/xboxlive/rest/uri-uriget.html
author: KevinAsgari
description: " GET (/{uri})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b70c87b848cec5f9bbe3ad4a4b3fdf224c84c1dc
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4020153"
---
# <a name="get-uri"></a><span data-ttu-id="c3070-104">GET (/{uri})</span><span class="sxs-lookup"><span data-stu-id="c3070-104">GET (/{uri})</span></span>
<span data-ttu-id="c3070-105">ゲーム クリップをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="c3070-105">Download game clip.</span></span> <span data-ttu-id="c3070-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`問題の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="c3070-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="c3070-107">注釈</span><span class="sxs-lookup"><span data-stu-id="c3070-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="c3070-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c3070-108">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="c3070-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-109">Required Request Headers</span></span>](#ID4EEC)
  * [<span data-ttu-id="c3070-110">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-110">Optional Request Headers</span></span>](#ID4EQE)
  * [<span data-ttu-id="c3070-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="c3070-111">Request body</span></span>](#ID4EZF)
  * [<span data-ttu-id="c3070-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-112">Required Response Headers</span></span>](#ID4EEG)
  * [<span data-ttu-id="c3070-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="c3070-113">HTTP status codes</span></span>](#ID4EYAAC)
  * [<span data-ttu-id="c3070-114">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-114">Optional Response Headers</span></span>](#ID4EOFAC)
  * [<span data-ttu-id="c3070-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="c3070-115">Response body</span></span>](#ID4EOGAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="c3070-116">注釈</span><span class="sxs-lookup"><span data-stu-id="c3070-116">Remarks</span></span>
 
<span data-ttu-id="c3070-117">クライアントは、クリップや公開済みの状態に達したと**GameClipUri**オブジェクトで指定されている、ダウンロード可能な型のサムネイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="c3070-117">The client can download any clip or thumbnail that has reached the Published state and is of the Downloadable type, as specified in a **GameClipUri** object.</span></span> <span data-ttu-id="c3070-118">ユーザーやパブリック クリップの一覧を取得するときに、応答本文で、ファイルを要求の URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c3070-118">The URI for requesting the file is included in the response body when retrieving a list of user or public clips.</span></span>
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c3070-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c3070-119">URI parameters</span></span>
 
| <span data-ttu-id="c3070-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c3070-120">Parameter</span></span>| <span data-ttu-id="c3070-121">型</span><span class="sxs-lookup"><span data-stu-id="c3070-121">Type</span></span>| <span data-ttu-id="c3070-122">説明</span><span class="sxs-lookup"><span data-stu-id="c3070-122">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="c3070-123">uri</span><span class="sxs-lookup"><span data-stu-id="c3070-123">uri</span></span></b>| <span data-ttu-id="c3070-124">string</span><span class="sxs-lookup"><span data-stu-id="c3070-124">string</span></span>| <span data-ttu-id="c3070-125"><b>GameClipUri</b>オブジェクト内で<b>uri</b>フィールド。</span><span class="sxs-lookup"><span data-stu-id="c3070-125">The <b>uri</b> field within the <b>GameClipUri</b> object.</span></span>| 
  
<a id="ID4EEC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="c3070-126">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-126">Required Request Headers</span></span>
 
| <span data-ttu-id="c3070-127">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-127">Header</span></span>| <span data-ttu-id="c3070-128">型</span><span class="sxs-lookup"><span data-stu-id="c3070-128">Type</span></span>| <span data-ttu-id="c3070-129">説明</span><span class="sxs-lookup"><span data-stu-id="c3070-129">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c3070-130">Authorization</span><span class="sxs-lookup"><span data-stu-id="c3070-130">Authorization</span></span>| <span data-ttu-id="c3070-131">string</span><span class="sxs-lookup"><span data-stu-id="c3070-131">string</span></span>| <span data-ttu-id="c3070-132">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="c3070-132">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="c3070-133">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="c3070-133">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="c3070-134">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="c3070-134">X-RequestedServiceVersion</span></span>| <span data-ttu-id="c3070-135">string</span><span class="sxs-lookup"><span data-stu-id="c3070-135">string</span></span>| <span data-ttu-id="c3070-136">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="c3070-136">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="c3070-137">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="c3070-137">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="c3070-138">Content-Type</span><span class="sxs-lookup"><span data-stu-id="c3070-138">Content-Type</span></span>| <span data-ttu-id="c3070-139">string</span><span class="sxs-lookup"><span data-stu-id="c3070-139">string</span></span>| <span data-ttu-id="c3070-140">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="c3070-140">MIME type of the response body.</span></span> <span data-ttu-id="c3070-141">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="c3070-141">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="c3070-142">Accept</span><span class="sxs-lookup"><span data-stu-id="c3070-142">Accept</span></span>| <span data-ttu-id="c3070-143">string</span><span class="sxs-lookup"><span data-stu-id="c3070-143">string</span></span>| <span data-ttu-id="c3070-144">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="c3070-144">Acceptable values of Content-Type.</span></span> <span data-ttu-id="c3070-145">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="c3070-145">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="c3070-146">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="c3070-146">Cache-Control</span></span>| <span data-ttu-id="c3070-147">string</span><span class="sxs-lookup"><span data-stu-id="c3070-147">string</span></span>| <span data-ttu-id="c3070-148">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="c3070-148">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EQE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="c3070-149">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-149">Optional Request Headers</span></span>
 
| <span data-ttu-id="c3070-150">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-150">Header</span></span>| <span data-ttu-id="c3070-151">型</span><span class="sxs-lookup"><span data-stu-id="c3070-151">Type</span></span>| <span data-ttu-id="c3070-152">説明</span><span class="sxs-lookup"><span data-stu-id="c3070-152">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c3070-153">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="c3070-153">Accept-Encoding</span></span>| <span data-ttu-id="c3070-154">string</span><span class="sxs-lookup"><span data-stu-id="c3070-154">string</span></span>| <span data-ttu-id="c3070-155">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="c3070-155">Acceptable compression encodings.</span></span> <span data-ttu-id="c3070-156">値の例: gzip、圧縮を識別します。</span><span class="sxs-lookup"><span data-stu-id="c3070-156">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="c3070-157">ETag</span><span class="sxs-lookup"><span data-stu-id="c3070-157">ETag</span></span>| <span data-ttu-id="c3070-158">string</span><span class="sxs-lookup"><span data-stu-id="c3070-158">string</span></span>| <span data-ttu-id="c3070-159">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="c3070-159">Used for cache optimization.</span></span> <span data-ttu-id="c3070-160">値の例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="c3070-160">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EZF"></a>

 
## <a name="request-body"></a><span data-ttu-id="c3070-161">要求本文</span><span class="sxs-lookup"><span data-stu-id="c3070-161">Request body</span></span>
 
<span data-ttu-id="c3070-162">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="c3070-162">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EEG"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="c3070-163">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-163">Required Response Headers</span></span>
 
| <span data-ttu-id="c3070-164">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-164">Header</span></span>| <span data-ttu-id="c3070-165">型</span><span class="sxs-lookup"><span data-stu-id="c3070-165">Type</span></span>| <span data-ttu-id="c3070-166">説明</span><span class="sxs-lookup"><span data-stu-id="c3070-166">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c3070-167">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="c3070-167">X-RequestedServiceVersion</span></span>| <span data-ttu-id="c3070-168">string</span><span class="sxs-lookup"><span data-stu-id="c3070-168">string</span></span>| <span data-ttu-id="c3070-169">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="c3070-169">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="c3070-170">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="c3070-170">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="c3070-171">Content-Type</span><span class="sxs-lookup"><span data-stu-id="c3070-171">Content-Type</span></span>| <span data-ttu-id="c3070-172">string</span><span class="sxs-lookup"><span data-stu-id="c3070-172">string</span></span>| <span data-ttu-id="c3070-173">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="c3070-173">MIME type of the response body.</span></span> <span data-ttu-id="c3070-174">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="c3070-174">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="c3070-175">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="c3070-175">Cache-Control</span></span>| <span data-ttu-id="c3070-176">string</span><span class="sxs-lookup"><span data-stu-id="c3070-176">string</span></span>| <span data-ttu-id="c3070-177">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="c3070-177">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="c3070-178">Accept</span><span class="sxs-lookup"><span data-stu-id="c3070-178">Accept</span></span>| <span data-ttu-id="c3070-179">string</span><span class="sxs-lookup"><span data-stu-id="c3070-179">string</span></span>| <span data-ttu-id="c3070-180">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="c3070-180">Acceptable values of Content-Type.</span></span> <span data-ttu-id="c3070-181">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="c3070-181">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="c3070-182">Retry-after</span><span class="sxs-lookup"><span data-stu-id="c3070-182">Retry-After</span></span>| <span data-ttu-id="c3070-183">string</span><span class="sxs-lookup"><span data-stu-id="c3070-183">string</span></span>| <span data-ttu-id="c3070-184">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="c3070-184">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="c3070-185">異なる</span><span class="sxs-lookup"><span data-stu-id="c3070-185">Vary</span></span>| <span data-ttu-id="c3070-186">string</span><span class="sxs-lookup"><span data-stu-id="c3070-186">string</span></span>| <span data-ttu-id="c3070-187">下位のプロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="c3070-187">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4EYAAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="c3070-188">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="c3070-188">HTTP status codes</span></span>
 
<span data-ttu-id="c3070-189">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="c3070-189">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="c3070-190">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c3070-190">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="c3070-191">コード</span><span class="sxs-lookup"><span data-stu-id="c3070-191">Code</span></span>| <span data-ttu-id="c3070-192">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="c3070-192">Reason phrase</span></span>| <span data-ttu-id="c3070-193">説明</span><span class="sxs-lookup"><span data-stu-id="c3070-193">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c3070-194">200</span><span class="sxs-lookup"><span data-stu-id="c3070-194">200</span></span>| <span data-ttu-id="c3070-195">OK</span><span class="sxs-lookup"><span data-stu-id="c3070-195">OK</span></span>| <span data-ttu-id="c3070-196">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="c3070-196">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="c3070-197">301</span><span class="sxs-lookup"><span data-stu-id="c3070-197">301</span></span>| <span data-ttu-id="c3070-198">完全に移動</span><span class="sxs-lookup"><span data-stu-id="c3070-198">Moved Permanently</span></span>| <span data-ttu-id="c3070-199">サービスは、さまざまな URI に移動しました。</span><span class="sxs-lookup"><span data-stu-id="c3070-199">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="c3070-200">307</span><span class="sxs-lookup"><span data-stu-id="c3070-200">307</span></span>| <span data-ttu-id="c3070-201">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="c3070-201">Temporary Redirect</span></span>| <span data-ttu-id="c3070-202">サービスは、さまざまな URI に移動しました。</span><span class="sxs-lookup"><span data-stu-id="c3070-202">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="c3070-203">400</span><span class="sxs-lookup"><span data-stu-id="c3070-203">400</span></span>| <span data-ttu-id="c3070-204">Bad Request</span><span class="sxs-lookup"><span data-stu-id="c3070-204">Bad Request</span></span>| <span data-ttu-id="c3070-205">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c3070-205">Service could not understand malformed request.</span></span> <span data-ttu-id="c3070-206">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="c3070-206">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="c3070-207">401</span><span class="sxs-lookup"><span data-stu-id="c3070-207">401</span></span>| <span data-ttu-id="c3070-208">権限がありません</span><span class="sxs-lookup"><span data-stu-id="c3070-208">Unauthorized</span></span>| <span data-ttu-id="c3070-209">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="c3070-209">The request requires user authentication.</span></span>| 
| <span data-ttu-id="c3070-210">403</span><span class="sxs-lookup"><span data-stu-id="c3070-210">403</span></span>| <span data-ttu-id="c3070-211">Forbidden</span><span class="sxs-lookup"><span data-stu-id="c3070-211">Forbidden</span></span>| <span data-ttu-id="c3070-212">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="c3070-212">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="c3070-213">404</span><span class="sxs-lookup"><span data-stu-id="c3070-213">404</span></span>| <span data-ttu-id="c3070-214">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="c3070-214">Not Found</span></span>| <span data-ttu-id="c3070-215">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="c3070-215">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="c3070-216">406</span><span class="sxs-lookup"><span data-stu-id="c3070-216">406</span></span>| <span data-ttu-id="c3070-217">許容できません。</span><span class="sxs-lookup"><span data-stu-id="c3070-217">Not Acceptable</span></span>| <span data-ttu-id="c3070-218">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c3070-218">Resource version is not supported.</span></span>| 
| <span data-ttu-id="c3070-219">408</span><span class="sxs-lookup"><span data-stu-id="c3070-219">408</span></span>| <span data-ttu-id="c3070-220">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="c3070-220">Request Timeout</span></span>| <span data-ttu-id="c3070-221">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="c3070-221">The request took too long to complete.</span></span>| 
| <span data-ttu-id="c3070-222">410</span><span class="sxs-lookup"><span data-stu-id="c3070-222">410</span></span>| <span data-ttu-id="c3070-223">なった</span><span class="sxs-lookup"><span data-stu-id="c3070-223">Gone</span></span>| <span data-ttu-id="c3070-224">要求されたリソースが利用可能ではありません。</span><span class="sxs-lookup"><span data-stu-id="c3070-224">The requested resource is no longer available.</span></span>| 
  
<a id="ID4EOFAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="c3070-225">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-225">Optional Response Headers</span></span>
 
| <span data-ttu-id="c3070-226">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c3070-226">Header</span></span>| <span data-ttu-id="c3070-227">型</span><span class="sxs-lookup"><span data-stu-id="c3070-227">Type</span></span>| <span data-ttu-id="c3070-228">説明</span><span class="sxs-lookup"><span data-stu-id="c3070-228">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c3070-229">Etag</span><span class="sxs-lookup"><span data-stu-id="c3070-229">Etag</span></span>| <span data-ttu-id="c3070-230">string</span><span class="sxs-lookup"><span data-stu-id="c3070-230">string</span></span>| <span data-ttu-id="c3070-231">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="c3070-231">Used for cache optimization.</span></span> <span data-ttu-id="c3070-232">例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="c3070-232">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EOGAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="c3070-233">応答本文</span><span class="sxs-lookup"><span data-stu-id="c3070-233">Response body</span></span>
 
<a id="ID4EUGAC"></a>

  
 
<span data-ttu-id="c3070-234">成功した場合、サーバーはおそらく範囲要求ヘッダーに従って切り詰められている、ビデオ クリップを返します。</span><span class="sxs-lookup"><span data-stu-id="c3070-234">If successful, the server will return the video clip, possibly truncated according to the Range request header.</span></span> <span data-ttu-id="c3070-235">切り捨てられたクリップの応答は部分的なコンテンツ (206) になります。</span><span class="sxs-lookup"><span data-stu-id="c3070-235">For a truncated clip, the response will be Partial Content (206).</span></span> <span data-ttu-id="c3070-236">サーバーがファイル全体を返す場合、[ok] (200) を応答します。</span><span class="sxs-lookup"><span data-stu-id="c3070-236">If the server returns the entire file, it will respond OK (200).</span></span> <span data-ttu-id="c3070-237">エラーが発生した**GameClipsServiceErrorResponse**オブジェクトを適切な HTTP ステータス コード (たとえば、416、要求された範囲が満たされていません) と共に返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c3070-237">On error, a **GameClipsServiceErrorResponse** object may be returned along with an appropriate HTTP status code (e.g., 416, Requested Range Not Satisfiable).</span></span>
   
<a id="ID4E4GAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c3070-238">関連項目</span><span class="sxs-lookup"><span data-stu-id="c3070-238">See also</span></span>
 
<a id="ID4E6GAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c3070-239">Parent</span><span class="sxs-lookup"><span data-stu-id="c3070-239">Parent</span></span> 

[<span data-ttu-id="c3070-240">/{uri}</span><span class="sxs-lookup"><span data-stu-id="c3070-240">/{uri}</span></span>](uri-uri.md)

   