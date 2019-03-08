---
title: PUT (/{uri})
assetID: 24a24c93-f43b-017e-91e0-29e190fec8a8
permalink: en-us/docs/xboxlive/rest/uri-uriput.html
description: " PUT (/{uri})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 862b956e29222bb9d28f98510f13d42fd1a51b6f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57633117"
---
# <a name="put-uri"></a><span data-ttu-id="ab4f1-104">PUT (/{uri})</span><span class="sxs-lookup"><span data-stu-id="ab4f1-104">PUT (/{uri})</span></span>
<span data-ttu-id="ab4f1-105">ゲームのクリップのデータをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-105">Upload game clip data.</span></span>
<span data-ttu-id="ab4f1-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>

  * [<span data-ttu-id="ab4f1-107">注釈</span><span class="sxs-lookup"><span data-stu-id="ab4f1-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="ab4f1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab4f1-108">URI parameters</span></span>](#ID4EQB)
  * [<span data-ttu-id="ab4f1-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab4f1-109">Query string parameters</span></span>](#ID4ERC)
  * [<span data-ttu-id="ab4f1-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ab4f1-110">Required Request Headers</span></span>](#ID4EBE)
  * [<span data-ttu-id="ab4f1-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ab4f1-111">Optional Request Headers</span></span>](#ID4ENG)
  * [<span data-ttu-id="ab4f1-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="ab4f1-112">Request body</span></span>](#ID4EWH)
  * [<span data-ttu-id="ab4f1-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="ab4f1-113">HTTP status codes</span></span>](#ID4ECAAC)
  * [<span data-ttu-id="ab4f1-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ab4f1-114">Required Response Headers</span></span>](#ID4EYEAC)
  * [<span data-ttu-id="ab4f1-115">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ab4f1-115">Optional Response Headers</span></span>](#ID4ELHAC)
  * [<span data-ttu-id="ab4f1-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="ab4f1-116">Response body</span></span>](#ID4ELIAC)

<a id="ID4EX"></a>


## <a name="remarks"></a><span data-ttu-id="ab4f1-117">注釈</span><span class="sxs-lookup"><span data-stu-id="ab4f1-117">Remarks</span></span>

<span data-ttu-id="ab4f1-118">後に、 **InitialUploadResponse**返されるか、アップロードを行います、 **uploadUri**そのオブジェクトで返されます。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-118">After the **InitialUploadResponse** is returned, the upload is performed through the **uploadUri** returned in that object.</span></span> <span data-ttu-id="ab4f1-119">クライアントは、ファイルを分割する必要があります**expectedBlocks**シーケンシャル ブロックは、各 2 MB を超える。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-119">The client should split the file into **expectedBlocks** sequential blocks, no larger than 2 MB each.</span></span> <span data-ttu-id="ab4f1-120">並行でアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-120">They can be uploaded in parallel.</span></span>

<span data-ttu-id="ab4f1-121">ブロック内のファイルをアップロードする場合、サーバーは各要求の承諾済み (202) の HTTP 状態コードが返されますを受け取るまで、すべての期待されるブロックの場合は、Created (201) を返す 1 つのファイルとしてすべてのブロックをコミットします。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-121">If you are uploading the file in blocks, the server will return an HTTP status code of Accepted (202) for each request, until it has received all expected blocks, in which case it commits all blocks as one file, returning Created (201).</span></span> <span data-ttu-id="ab4f1-122">このような場合は、応答に、オブジェクトが含まれていないと、サーバーは、追加の処理をスケジュール可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-122">In these cases, the response does not contain an object, and the server may schedule additional processing.</span></span> <span data-ttu-id="ab4f1-123">エラーの場合、 **ServiceErrorResponse**オブジェクトは、適切な HTTP ステータス コードと共に返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-123">On error, a **ServiceErrorResponse** object may be returned along with an appropriate HTTP status code.</span></span>

<span data-ttu-id="ab4f1-124">回復可能なエラー コード、クライアントは、標準的なバックオフの再試行メカニズムを使用して再試行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-124">On a recoverable error code, the client should retry using a standard back-off retry mechanism.</span></span>

> [!NOTE] 
> <span data-ttu-id="ab4f1-125">場合でも、アップロードが正常に完了すると、さらに処理する可能性があります上の理由からクリップがアップロードまたはメタデータに関連しない却下を補うためプロセス発生します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-125">Even if an upload completes successfully, further processing will occur that could reject the clip for reasons not related to the upload or metadata supplementing process.</span></span>


<a id="ID4EQB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="ab4f1-126">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab4f1-126">URI parameters</span></span>

| <span data-ttu-id="ab4f1-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab4f1-127">Parameter</span></span>| <span data-ttu-id="ab4f1-128">種類</span><span class="sxs-lookup"><span data-stu-id="ab4f1-128">Type</span></span>| <span data-ttu-id="ab4f1-129">説明</span><span class="sxs-lookup"><span data-stu-id="ab4f1-129">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="ab4f1-130"><b>Uri</b></span><span class="sxs-lookup"><span data-stu-id="ab4f1-130"><b>uri</b></span></span>| <span data-ttu-id="ab4f1-131">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-131">string</span></span>| <span data-ttu-id="ab4f1-132"><b>UploadUri</b>内でフィールド、 <b>InitialUploadResponse</b>オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-132">The <b>uploadUri</b> field within the <b>InitialUploadResponse</b> object.</span></span>|

<a id="ID4ERC"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="ab4f1-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab4f1-133">Query string parameters</span></span>

| <span data-ttu-id="ab4f1-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab4f1-134">Parameter</span></span>| <span data-ttu-id="ab4f1-135">種類</span><span class="sxs-lookup"><span data-stu-id="ab4f1-135">Type</span></span>| <span data-ttu-id="ab4f1-136">説明</span><span class="sxs-lookup"><span data-stu-id="ab4f1-136">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ab4f1-137"><b>blockNum</b></span><span class="sxs-lookup"><span data-stu-id="ab4f1-137"><b>blockNum</b></span></span>| <span data-ttu-id="ab4f1-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ab4f1-138">32-bit unsigned integer</span></span>| <span data-ttu-id="ab4f1-139">場合に、必ず<b>expectedBlocks</b>設定されます。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-139">Required if <b>expectedBlocks</b> is set.</span></span> <span data-ttu-id="ab4f1-140">ファイル内のブロックの順序を決定する、インデックス 0 のブロック数。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-140">Zero-indexed block number determining ordering of block in file.</span></span> <span data-ttu-id="ab4f1-141">たとえば場合、 <b>expectedBlocks</b>は 7、 <b>blockNum</b>は、0 から 6 までです。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-141">For example, if <b>expectedBlocks</b> is 7, then <b>blockNum</b> can be from 0 to 6.</span></span> |
| <span data-ttu-id="ab4f1-142"><b>uploadId</b></span><span class="sxs-lookup"><span data-stu-id="ab4f1-142"><b>uploadId</b></span></span>| <span data-ttu-id="ab4f1-143">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-143">string</span></span>| <span data-ttu-id="ab4f1-144">必須。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-144">Required.</span></span> <span data-ttu-id="ab4f1-145">不透明な ID で<b>GameClipsServiceUploadResponse</b>オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-145">Opaque ID in <b>GameClipsServiceUploadResponse</b> object.</span></span>|

<a id="ID4EBE"></a>


## <a name="required-request-headers"></a><span data-ttu-id="ab4f1-146">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ab4f1-146">Required Request Headers</span></span>

| <span data-ttu-id="ab4f1-147">Header</span><span class="sxs-lookup"><span data-stu-id="ab4f1-147">Header</span></span>| <span data-ttu-id="ab4f1-148">種類</span><span class="sxs-lookup"><span data-stu-id="ab4f1-148">Type</span></span>| <span data-ttu-id="ab4f1-149">説明</span><span class="sxs-lookup"><span data-stu-id="ab4f1-149">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ab4f1-150">Authorization</span><span class="sxs-lookup"><span data-stu-id="ab4f1-150">Authorization</span></span>| <span data-ttu-id="ab4f1-151">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-151">string</span></span>| <span data-ttu-id="ab4f1-152">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-152">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="ab4f1-153">値の例:<b>Xauth=&lt;authtoken></b></span><span class="sxs-lookup"><span data-stu-id="ab4f1-153">Example values: <b>Xauth=&lt;authtoken></b></span></span>|
| <span data-ttu-id="ab4f1-154">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="ab4f1-154">X-RequestedServiceVersion</span></span>| <span data-ttu-id="ab4f1-155">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-155">string</span></span>| <span data-ttu-id="ab4f1-156">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-156">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="ab4f1-157">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-157">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>|
| <span data-ttu-id="ab4f1-158">Content-Type</span><span class="sxs-lookup"><span data-stu-id="ab4f1-158">Content-Type</span></span>| <span data-ttu-id="ab4f1-159">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-159">string</span></span>| <span data-ttu-id="ab4f1-160">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-160">MIME type of the response body.</span></span> <span data-ttu-id="ab4f1-161">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-161">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="ab4f1-162">OK</span><span class="sxs-lookup"><span data-stu-id="ab4f1-162">Accept</span></span>| <span data-ttu-id="ab4f1-163">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-163">string</span></span>| <span data-ttu-id="ab4f1-164">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-164">Acceptable values of Content-Type.</span></span> <span data-ttu-id="ab4f1-165">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-165">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="ab4f1-166">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="ab4f1-166">Cache-Control</span></span>| <span data-ttu-id="ab4f1-167">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-167">string</span></span>| <span data-ttu-id="ab4f1-168">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-168">Polite request to specify caching behavior.</span></span>|

<a id="ID4ENG"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="ab4f1-169">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ab4f1-169">Optional Request Headers</span></span>

| <span data-ttu-id="ab4f1-170">Header</span><span class="sxs-lookup"><span data-stu-id="ab4f1-170">Header</span></span>| <span data-ttu-id="ab4f1-171">種類</span><span class="sxs-lookup"><span data-stu-id="ab4f1-171">Type</span></span>| <span data-ttu-id="ab4f1-172">説明</span><span class="sxs-lookup"><span data-stu-id="ab4f1-172">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ab4f1-173">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="ab4f1-173">Accept-Encoding</span></span>| <span data-ttu-id="ab4f1-174">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-174">string</span></span>| <span data-ttu-id="ab4f1-175">許容される圧縮エンコーディング。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-175">Acceptable compression encodings.</span></span> <span data-ttu-id="ab4f1-176">値の例: gzip、deflate の id。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-176">Example values: gzip, deflate, identity.</span></span>|
| <span data-ttu-id="ab4f1-177">ETag</span><span class="sxs-lookup"><span data-stu-id="ab4f1-177">ETag</span></span>| <span data-ttu-id="ab4f1-178">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-178">string</span></span>| <span data-ttu-id="ab4f1-179">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-179">Used for cache optimization.</span></span> <span data-ttu-id="ab4f1-180">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-180">Example value: "686897696a7c876b7e".</span></span>|

<a id="ID4EWH"></a>


## <a name="request-body"></a><span data-ttu-id="ab4f1-181">要求本文</span><span class="sxs-lookup"><span data-stu-id="ab4f1-181">Request body</span></span>

<span data-ttu-id="ab4f1-182">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-182">No objects are sent in the body of this request.</span></span>

<a id="ID4ECAAC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="ab4f1-183">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="ab4f1-183">HTTP status codes</span></span>

<span data-ttu-id="ab4f1-184">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-184">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="ab4f1-185">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-185">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="ab4f1-186">コード</span><span class="sxs-lookup"><span data-stu-id="ab4f1-186">Code</span></span>| <span data-ttu-id="ab4f1-187">理由語句</span><span class="sxs-lookup"><span data-stu-id="ab4f1-187">Reason phrase</span></span>| <span data-ttu-id="ab4f1-188">説明</span><span class="sxs-lookup"><span data-stu-id="ab4f1-188">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ab4f1-189">200</span><span class="sxs-lookup"><span data-stu-id="ab4f1-189">200</span></span>| <span data-ttu-id="ab4f1-190">OK</span><span class="sxs-lookup"><span data-stu-id="ab4f1-190">OK</span></span>| <span data-ttu-id="ab4f1-191">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-191">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="ab4f1-192">301</span><span class="sxs-lookup"><span data-stu-id="ab4f1-192">301</span></span>| <span data-ttu-id="ab4f1-193">完全に移動</span><span class="sxs-lookup"><span data-stu-id="ab4f1-193">Moved Permanently</span></span>| <span data-ttu-id="ab4f1-194">サービスが別の URI に移動します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-194">The service has moved to a different URI.</span></span>|
| <span data-ttu-id="ab4f1-195">307</span><span class="sxs-lookup"><span data-stu-id="ab4f1-195">307</span></span>| <span data-ttu-id="ab4f1-196">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="ab4f1-196">Temporary Redirect</span></span>| <span data-ttu-id="ab4f1-197">サービスが別の URI に移動します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-197">The service has moved to a different URI.</span></span>|
| <span data-ttu-id="ab4f1-198">400</span><span class="sxs-lookup"><span data-stu-id="ab4f1-198">400</span></span>| <span data-ttu-id="ab4f1-199">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="ab4f1-199">Bad Request</span></span>| <span data-ttu-id="ab4f1-200">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-200">Service could not understand malformed request.</span></span> <span data-ttu-id="ab4f1-201">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-201">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="ab4f1-202">401</span><span class="sxs-lookup"><span data-stu-id="ab4f1-202">401</span></span>| <span data-ttu-id="ab4f1-203">権限がありません</span><span class="sxs-lookup"><span data-stu-id="ab4f1-203">Unauthorized</span></span>| <span data-ttu-id="ab4f1-204">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-204">The request requires user authentication.</span></span>|
| <span data-ttu-id="ab4f1-205">403</span><span class="sxs-lookup"><span data-stu-id="ab4f1-205">403</span></span>| <span data-ttu-id="ab4f1-206">Forbidden</span><span class="sxs-lookup"><span data-stu-id="ab4f1-206">Forbidden</span></span>| <span data-ttu-id="ab4f1-207">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-207">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="ab4f1-208">404</span><span class="sxs-lookup"><span data-stu-id="ab4f1-208">404</span></span>| <span data-ttu-id="ab4f1-209">検出不可</span><span class="sxs-lookup"><span data-stu-id="ab4f1-209">Not Found</span></span>| <span data-ttu-id="ab4f1-210">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-210">The specified resource could not be found.</span></span>|
| <span data-ttu-id="ab4f1-211">406</span><span class="sxs-lookup"><span data-stu-id="ab4f1-211">406</span></span>| <span data-ttu-id="ab4f1-212">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="ab4f1-212">Not Acceptable</span></span>| <span data-ttu-id="ab4f1-213">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-213">Resource version is not supported.</span></span>|
| <span data-ttu-id="ab4f1-214">408</span><span class="sxs-lookup"><span data-stu-id="ab4f1-214">408</span></span>| <span data-ttu-id="ab4f1-215">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="ab4f1-215">Request Timeout</span></span>| <span data-ttu-id="ab4f1-216">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-216">The request took too long to complete.</span></span>|
| <span data-ttu-id="ab4f1-217">410</span><span class="sxs-lookup"><span data-stu-id="ab4f1-217">410</span></span>| <span data-ttu-id="ab4f1-218">なった</span><span class="sxs-lookup"><span data-stu-id="ab4f1-218">Gone</span></span>| <span data-ttu-id="ab4f1-219">要求されたリソースは使用できなくします。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-219">The requested resource is no longer available.</span></span>|

<a id="ID4EYEAC"></a>


## <a name="required-response-headers"></a><span data-ttu-id="ab4f1-220">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ab4f1-220">Required Response Headers</span></span>

| <span data-ttu-id="ab4f1-221">Header</span><span class="sxs-lookup"><span data-stu-id="ab4f1-221">Header</span></span>| <span data-ttu-id="ab4f1-222">種類</span><span class="sxs-lookup"><span data-stu-id="ab4f1-222">Type</span></span>| <span data-ttu-id="ab4f1-223">説明</span><span class="sxs-lookup"><span data-stu-id="ab4f1-223">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ab4f1-224">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="ab4f1-224">X-RequestedServiceVersion</span></span>| <span data-ttu-id="ab4f1-225">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-225">string</span></span>| <span data-ttu-id="ab4f1-226">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-226">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="ab4f1-227">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-227">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>|
| <span data-ttu-id="ab4f1-228">Content-Type</span><span class="sxs-lookup"><span data-stu-id="ab4f1-228">Content-Type</span></span>| <span data-ttu-id="ab4f1-229">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-229">string</span></span>| <span data-ttu-id="ab4f1-230">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-230">MIME type of the response body.</span></span> <span data-ttu-id="ab4f1-231">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-231">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="ab4f1-232">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="ab4f1-232">Cache-Control</span></span>| <span data-ttu-id="ab4f1-233">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-233">string</span></span>| <span data-ttu-id="ab4f1-234">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-234">Polite request to specify caching behavior.</span></span>|
| <span data-ttu-id="ab4f1-235">OK</span><span class="sxs-lookup"><span data-stu-id="ab4f1-235">Accept</span></span>| <span data-ttu-id="ab4f1-236">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-236">string</span></span>| <span data-ttu-id="ab4f1-237">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-237">Acceptable values of Content-Type.</span></span> <span data-ttu-id="ab4f1-238">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-238">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="ab4f1-239">再試行後</span><span class="sxs-lookup"><span data-stu-id="ab4f1-239">Retry-After</span></span>| <span data-ttu-id="ab4f1-240">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-240">string</span></span>| <span data-ttu-id="ab4f1-241">後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-241">Instructs client to try again later in the case of an unavailable server.</span></span>|
| <span data-ttu-id="ab4f1-242">異なる</span><span class="sxs-lookup"><span data-stu-id="ab4f1-242">Vary</span></span>| <span data-ttu-id="ab4f1-243">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-243">string</span></span>| <span data-ttu-id="ab4f1-244">ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-244">Instructs downstream proxies how to cache responses.</span></span>|

<a id="ID4ELHAC"></a>


## <a name="optional-response-headers"></a><span data-ttu-id="ab4f1-245">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ab4f1-245">Optional Response Headers</span></span>

| <span data-ttu-id="ab4f1-246">Header</span><span class="sxs-lookup"><span data-stu-id="ab4f1-246">Header</span></span>| <span data-ttu-id="ab4f1-247">種類</span><span class="sxs-lookup"><span data-stu-id="ab4f1-247">Type</span></span>| <span data-ttu-id="ab4f1-248">説明</span><span class="sxs-lookup"><span data-stu-id="ab4f1-248">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ab4f1-249">Etag</span><span class="sxs-lookup"><span data-stu-id="ab4f1-249">Etag</span></span>| <span data-ttu-id="ab4f1-250">string</span><span class="sxs-lookup"><span data-stu-id="ab4f1-250">string</span></span>| <span data-ttu-id="ab4f1-251">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-251">Used for cache optimization.</span></span> <span data-ttu-id="ab4f1-252">以下に例を示します。"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-252">Example: "686897696a7c876b7e".</span></span>|

<a id="ID4ELIAC"></a>


## <a name="response-body"></a><span data-ttu-id="ab4f1-253">応答本文</span><span class="sxs-lookup"><span data-stu-id="ab4f1-253">Response body</span></span>

<span data-ttu-id="ab4f1-254">応答の本文では、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="ab4f1-254">No objects are sent in the body of the response.</span></span>

<a id="ID4EWIAC"></a>


## <a name="see-also"></a><span data-ttu-id="ab4f1-255">関連項目</span><span class="sxs-lookup"><span data-stu-id="ab4f1-255">See also</span></span>

<a id="ID4EYIAC"></a>


##### <a name="parent"></a><span data-ttu-id="ab4f1-256">Parent</span><span class="sxs-lookup"><span data-stu-id="ab4f1-256">Parent</span></span>

[<span data-ttu-id="ab4f1-257">/{uri}</span><span class="sxs-lookup"><span data-stu-id="ab4f1-257">/{uri}</span></span>](uri-uri.md)
