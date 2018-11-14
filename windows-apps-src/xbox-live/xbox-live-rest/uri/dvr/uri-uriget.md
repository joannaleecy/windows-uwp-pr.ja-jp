---
title: GET (/{uri})
assetID: a67a3288-88f9-c504-5fa8-8fd06055d079
permalink: en-us/docs/xboxlive/rest/uri-uriget.html
author: KevinAsgari
description: " GET (/{uri})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cd195ccc7cdb8e3d34c6236c44144050d2029ef2
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6273886"
---
# <a name="get-uri"></a><span data-ttu-id="80a01-104">GET (/{uri})</span><span class="sxs-lookup"><span data-stu-id="80a01-104">GET (/{uri})</span></span>
<span data-ttu-id="80a01-105">ゲーム クリップをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="80a01-105">Download game clip.</span></span> <span data-ttu-id="80a01-106">これらの Uri のドメイン`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="80a01-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="80a01-107">注釈</span><span class="sxs-lookup"><span data-stu-id="80a01-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="80a01-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="80a01-108">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="80a01-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-109">Required Request Headers</span></span>](#ID4EEC)
  * [<span data-ttu-id="80a01-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-110">Optional Request Headers</span></span>](#ID4EQE)
  * [<span data-ttu-id="80a01-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="80a01-111">Request body</span></span>](#ID4EZF)
  * [<span data-ttu-id="80a01-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-112">Required Response Headers</span></span>](#ID4EEG)
  * [<span data-ttu-id="80a01-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="80a01-113">HTTP status codes</span></span>](#ID4EYAAC)
  * [<span data-ttu-id="80a01-114">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-114">Optional Response Headers</span></span>](#ID4EOFAC)
  * [<span data-ttu-id="80a01-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="80a01-115">Response body</span></span>](#ID4EOGAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="80a01-116">注釈</span><span class="sxs-lookup"><span data-stu-id="80a01-116">Remarks</span></span>
 
<span data-ttu-id="80a01-117">クライアントは、任意のクリップまたは公開済みの状態に達した、ダウンロード可能な種類の**GameClipUri**オブジェクトで指定されているは、サムネイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="80a01-117">The client can download any clip or thumbnail that has reached the Published state and is of the Downloadable type, as specified in a **GameClipUri** object.</span></span> <span data-ttu-id="80a01-118">ユーザーやパブリック クリップの一覧を取得するときに、応答本文で、ファイルを要求の URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="80a01-118">The URI for requesting the file is included in the response body when retrieving a list of user or public clips.</span></span>
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="80a01-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="80a01-119">URI parameters</span></span>
 
| <span data-ttu-id="80a01-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="80a01-120">Parameter</span></span>| <span data-ttu-id="80a01-121">型</span><span class="sxs-lookup"><span data-stu-id="80a01-121">Type</span></span>| <span data-ttu-id="80a01-122">説明</span><span class="sxs-lookup"><span data-stu-id="80a01-122">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="80a01-123">uri</span><span class="sxs-lookup"><span data-stu-id="80a01-123">uri</span></span></b>| <span data-ttu-id="80a01-124">string</span><span class="sxs-lookup"><span data-stu-id="80a01-124">string</span></span>| <span data-ttu-id="80a01-125"><b>GameClipUri</b>オブジェクト内で<b>uri</b>フィールド。</span><span class="sxs-lookup"><span data-stu-id="80a01-125">The <b>uri</b> field within the <b>GameClipUri</b> object.</span></span>| 
  
<a id="ID4EEC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="80a01-126">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-126">Required Request Headers</span></span>
 
| <span data-ttu-id="80a01-127">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-127">Header</span></span>| <span data-ttu-id="80a01-128">型</span><span class="sxs-lookup"><span data-stu-id="80a01-128">Type</span></span>| <span data-ttu-id="80a01-129">説明</span><span class="sxs-lookup"><span data-stu-id="80a01-129">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="80a01-130">Authorization</span><span class="sxs-lookup"><span data-stu-id="80a01-130">Authorization</span></span>| <span data-ttu-id="80a01-131">string</span><span class="sxs-lookup"><span data-stu-id="80a01-131">string</span></span>| <span data-ttu-id="80a01-132">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="80a01-132">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="80a01-133">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="80a01-133">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="80a01-134">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="80a01-134">X-RequestedServiceVersion</span></span>| <span data-ttu-id="80a01-135">string</span><span class="sxs-lookup"><span data-stu-id="80a01-135">string</span></span>| <span data-ttu-id="80a01-136">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="80a01-136">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="80a01-137">要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="80a01-137">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="80a01-138">Content-Type</span><span class="sxs-lookup"><span data-stu-id="80a01-138">Content-Type</span></span>| <span data-ttu-id="80a01-139">string</span><span class="sxs-lookup"><span data-stu-id="80a01-139">string</span></span>| <span data-ttu-id="80a01-140">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="80a01-140">MIME type of the response body.</span></span> <span data-ttu-id="80a01-141">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="80a01-141">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="80a01-142">Accept</span><span class="sxs-lookup"><span data-stu-id="80a01-142">Accept</span></span>| <span data-ttu-id="80a01-143">string</span><span class="sxs-lookup"><span data-stu-id="80a01-143">string</span></span>| <span data-ttu-id="80a01-144">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="80a01-144">Acceptable values of Content-Type.</span></span> <span data-ttu-id="80a01-145">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="80a01-145">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="80a01-146">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="80a01-146">Cache-Control</span></span>| <span data-ttu-id="80a01-147">string</span><span class="sxs-lookup"><span data-stu-id="80a01-147">string</span></span>| <span data-ttu-id="80a01-148">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="80a01-148">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EQE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="80a01-149">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-149">Optional Request Headers</span></span>
 
| <span data-ttu-id="80a01-150">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-150">Header</span></span>| <span data-ttu-id="80a01-151">型</span><span class="sxs-lookup"><span data-stu-id="80a01-151">Type</span></span>| <span data-ttu-id="80a01-152">説明</span><span class="sxs-lookup"><span data-stu-id="80a01-152">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="80a01-153">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="80a01-153">Accept-Encoding</span></span>| <span data-ttu-id="80a01-154">string</span><span class="sxs-lookup"><span data-stu-id="80a01-154">string</span></span>| <span data-ttu-id="80a01-155">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="80a01-155">Acceptable compression encodings.</span></span> <span data-ttu-id="80a01-156">値の例: gzip、圧縮を識別します。</span><span class="sxs-lookup"><span data-stu-id="80a01-156">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="80a01-157">ETag</span><span class="sxs-lookup"><span data-stu-id="80a01-157">ETag</span></span>| <span data-ttu-id="80a01-158">string</span><span class="sxs-lookup"><span data-stu-id="80a01-158">string</span></span>| <span data-ttu-id="80a01-159">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="80a01-159">Used for cache optimization.</span></span> <span data-ttu-id="80a01-160">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="80a01-160">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EZF"></a>

 
## <a name="request-body"></a><span data-ttu-id="80a01-161">要求本文</span><span class="sxs-lookup"><span data-stu-id="80a01-161">Request body</span></span>
 
<span data-ttu-id="80a01-162">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="80a01-162">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EEG"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="80a01-163">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-163">Required Response Headers</span></span>
 
| <span data-ttu-id="80a01-164">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-164">Header</span></span>| <span data-ttu-id="80a01-165">型</span><span class="sxs-lookup"><span data-stu-id="80a01-165">Type</span></span>| <span data-ttu-id="80a01-166">説明</span><span class="sxs-lookup"><span data-stu-id="80a01-166">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="80a01-167">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="80a01-167">X-RequestedServiceVersion</span></span>| <span data-ttu-id="80a01-168">string</span><span class="sxs-lookup"><span data-stu-id="80a01-168">string</span></span>| <span data-ttu-id="80a01-169">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="80a01-169">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="80a01-170">要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="80a01-170">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="80a01-171">Content-Type</span><span class="sxs-lookup"><span data-stu-id="80a01-171">Content-Type</span></span>| <span data-ttu-id="80a01-172">string</span><span class="sxs-lookup"><span data-stu-id="80a01-172">string</span></span>| <span data-ttu-id="80a01-173">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="80a01-173">MIME type of the response body.</span></span> <span data-ttu-id="80a01-174">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="80a01-174">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="80a01-175">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="80a01-175">Cache-Control</span></span>| <span data-ttu-id="80a01-176">string</span><span class="sxs-lookup"><span data-stu-id="80a01-176">string</span></span>| <span data-ttu-id="80a01-177">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="80a01-177">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="80a01-178">Accept</span><span class="sxs-lookup"><span data-stu-id="80a01-178">Accept</span></span>| <span data-ttu-id="80a01-179">string</span><span class="sxs-lookup"><span data-stu-id="80a01-179">string</span></span>| <span data-ttu-id="80a01-180">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="80a01-180">Acceptable values of Content-Type.</span></span> <span data-ttu-id="80a01-181">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="80a01-181">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="80a01-182">Retry-after</span><span class="sxs-lookup"><span data-stu-id="80a01-182">Retry-After</span></span>| <span data-ttu-id="80a01-183">string</span><span class="sxs-lookup"><span data-stu-id="80a01-183">string</span></span>| <span data-ttu-id="80a01-184">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="80a01-184">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="80a01-185">異なる</span><span class="sxs-lookup"><span data-stu-id="80a01-185">Vary</span></span>| <span data-ttu-id="80a01-186">string</span><span class="sxs-lookup"><span data-stu-id="80a01-186">string</span></span>| <span data-ttu-id="80a01-187">下位のプロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="80a01-187">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4EYAAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="80a01-188">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="80a01-188">HTTP status codes</span></span>
 
<span data-ttu-id="80a01-189">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="80a01-189">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="80a01-190">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="80a01-190">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="80a01-191">コード</span><span class="sxs-lookup"><span data-stu-id="80a01-191">Code</span></span>| <span data-ttu-id="80a01-192">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="80a01-192">Reason phrase</span></span>| <span data-ttu-id="80a01-193">説明</span><span class="sxs-lookup"><span data-stu-id="80a01-193">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="80a01-194">200</span><span class="sxs-lookup"><span data-stu-id="80a01-194">200</span></span>| <span data-ttu-id="80a01-195">OK</span><span class="sxs-lookup"><span data-stu-id="80a01-195">OK</span></span>| <span data-ttu-id="80a01-196">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="80a01-196">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="80a01-197">301</span><span class="sxs-lookup"><span data-stu-id="80a01-197">301</span></span>| <span data-ttu-id="80a01-198">完全に移動</span><span class="sxs-lookup"><span data-stu-id="80a01-198">Moved Permanently</span></span>| <span data-ttu-id="80a01-199">サービスは、さまざまな URI に移動しました。</span><span class="sxs-lookup"><span data-stu-id="80a01-199">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="80a01-200">307</span><span class="sxs-lookup"><span data-stu-id="80a01-200">307</span></span>| <span data-ttu-id="80a01-201">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="80a01-201">Temporary Redirect</span></span>| <span data-ttu-id="80a01-202">サービスは、さまざまな URI に移動しました。</span><span class="sxs-lookup"><span data-stu-id="80a01-202">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="80a01-203">400</span><span class="sxs-lookup"><span data-stu-id="80a01-203">400</span></span>| <span data-ttu-id="80a01-204">Bad Request</span><span class="sxs-lookup"><span data-stu-id="80a01-204">Bad Request</span></span>| <span data-ttu-id="80a01-205">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="80a01-205">Service could not understand malformed request.</span></span> <span data-ttu-id="80a01-206">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="80a01-206">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="80a01-207">401</span><span class="sxs-lookup"><span data-stu-id="80a01-207">401</span></span>| <span data-ttu-id="80a01-208">権限がありません</span><span class="sxs-lookup"><span data-stu-id="80a01-208">Unauthorized</span></span>| <span data-ttu-id="80a01-209">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="80a01-209">The request requires user authentication.</span></span>| 
| <span data-ttu-id="80a01-210">403</span><span class="sxs-lookup"><span data-stu-id="80a01-210">403</span></span>| <span data-ttu-id="80a01-211">Forbidden</span><span class="sxs-lookup"><span data-stu-id="80a01-211">Forbidden</span></span>| <span data-ttu-id="80a01-212">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="80a01-212">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="80a01-213">404</span><span class="sxs-lookup"><span data-stu-id="80a01-213">404</span></span>| <span data-ttu-id="80a01-214">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="80a01-214">Not Found</span></span>| <span data-ttu-id="80a01-215">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="80a01-215">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="80a01-216">406</span><span class="sxs-lookup"><span data-stu-id="80a01-216">406</span></span>| <span data-ttu-id="80a01-217">許容できません。</span><span class="sxs-lookup"><span data-stu-id="80a01-217">Not Acceptable</span></span>| <span data-ttu-id="80a01-218">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="80a01-218">Resource version is not supported.</span></span>| 
| <span data-ttu-id="80a01-219">408</span><span class="sxs-lookup"><span data-stu-id="80a01-219">408</span></span>| <span data-ttu-id="80a01-220">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="80a01-220">Request Timeout</span></span>| <span data-ttu-id="80a01-221">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="80a01-221">The request took too long to complete.</span></span>| 
| <span data-ttu-id="80a01-222">410</span><span class="sxs-lookup"><span data-stu-id="80a01-222">410</span></span>| <span data-ttu-id="80a01-223">なった</span><span class="sxs-lookup"><span data-stu-id="80a01-223">Gone</span></span>| <span data-ttu-id="80a01-224">要求されたリソースが利用可能ではなくなりました。</span><span class="sxs-lookup"><span data-stu-id="80a01-224">The requested resource is no longer available.</span></span>| 
  
<a id="ID4EOFAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="80a01-225">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-225">Optional Response Headers</span></span>
 
| <span data-ttu-id="80a01-226">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="80a01-226">Header</span></span>| <span data-ttu-id="80a01-227">型</span><span class="sxs-lookup"><span data-stu-id="80a01-227">Type</span></span>| <span data-ttu-id="80a01-228">説明</span><span class="sxs-lookup"><span data-stu-id="80a01-228">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="80a01-229">Etag</span><span class="sxs-lookup"><span data-stu-id="80a01-229">Etag</span></span>| <span data-ttu-id="80a01-230">string</span><span class="sxs-lookup"><span data-stu-id="80a01-230">string</span></span>| <span data-ttu-id="80a01-231">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="80a01-231">Used for cache optimization.</span></span> <span data-ttu-id="80a01-232">例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="80a01-232">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EOGAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="80a01-233">応答本文</span><span class="sxs-lookup"><span data-stu-id="80a01-233">Response body</span></span>
 
<a id="ID4EUGAC"></a>

  
 
<span data-ttu-id="80a01-234">成功した場合、サーバーはおそらく範囲要求ヘッダーに従って切り詰められている、ビデオ クリップを返します。</span><span class="sxs-lookup"><span data-stu-id="80a01-234">If successful, the server will return the video clip, possibly truncated according to the Range request header.</span></span> <span data-ttu-id="80a01-235">切り捨てられたクリップの応答は部分的なコンテンツ (206) になります。</span><span class="sxs-lookup"><span data-stu-id="80a01-235">For a truncated clip, the response will be Partial Content (206).</span></span> <span data-ttu-id="80a01-236">サーバーがファイル全体を返す場合、[ok] (200) を応答します。</span><span class="sxs-lookup"><span data-stu-id="80a01-236">If the server returns the entire file, it will respond OK (200).</span></span> <span data-ttu-id="80a01-237">エラーが発生した**GameClipsServiceErrorResponse**オブジェクトを適切な HTTP ステータス コード (例: 416、要求された範囲が満たされていません) と共に返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="80a01-237">On error, a **GameClipsServiceErrorResponse** object may be returned along with an appropriate HTTP status code (e.g., 416, Requested Range Not Satisfiable).</span></span>
   
<a id="ID4E4GAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="80a01-238">関連項目</span><span class="sxs-lookup"><span data-stu-id="80a01-238">See also</span></span>
 
<a id="ID4E6GAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="80a01-239">Parent</span><span class="sxs-lookup"><span data-stu-id="80a01-239">Parent</span></span> 

[<span data-ttu-id="80a01-240">/{uri}</span><span class="sxs-lookup"><span data-stu-id="80a01-240">/{uri}</span></span>](uri-uri.md)

   