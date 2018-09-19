---
title: PUT (/{uri})
assetID: 24a24c93-f43b-017e-91e0-29e190fec8a8
permalink: en-us/docs/xboxlive/rest/uri-uriput.html
author: KevinAsgari
description: " PUT (/{uri})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 61eecfbc6d5ebeda4825b8a3d29e90347b9988af
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4054639"
---
# <a name="put-uri"></a><span data-ttu-id="41333-104">PUT (/{uri})</span><span class="sxs-lookup"><span data-stu-id="41333-104">PUT (/{uri})</span></span>
<span data-ttu-id="41333-105">ゲーム クリップのデータをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="41333-105">Upload game clip data.</span></span>
<span data-ttu-id="41333-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`問題の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="41333-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>

  * [<span data-ttu-id="41333-107">注釈</span><span class="sxs-lookup"><span data-stu-id="41333-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="41333-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="41333-108">URI parameters</span></span>](#ID4EQB)
  * [<span data-ttu-id="41333-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="41333-109">Query string parameters</span></span>](#ID4ERC)
  * [<span data-ttu-id="41333-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-110">Required Request Headers</span></span>](#ID4EBE)
  * [<span data-ttu-id="41333-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-111">Optional Request Headers</span></span>](#ID4ENG)
  * [<span data-ttu-id="41333-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="41333-112">Request body</span></span>](#ID4EWH)
  * [<span data-ttu-id="41333-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="41333-113">HTTP status codes</span></span>](#ID4ECAAC)
  * [<span data-ttu-id="41333-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-114">Required Response Headers</span></span>](#ID4EYEAC)
  * [<span data-ttu-id="41333-115">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-115">Optional Response Headers</span></span>](#ID4ELHAC)
  * [<span data-ttu-id="41333-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="41333-116">Response body</span></span>](#ID4ELIAC)

<a id="ID4EX"></a>


## <a name="remarks"></a><span data-ttu-id="41333-117">注釈</span><span class="sxs-lookup"><span data-stu-id="41333-117">Remarks</span></span>

<span data-ttu-id="41333-118">**InitialUploadResponse**が返された後、アップロードはそのオブジェクトで返される**uploadUri**を通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="41333-118">After the **InitialUploadResponse** is returned, the upload is performed through the **uploadUri** returned in that object.</span></span> <span data-ttu-id="41333-119">クライアントする必要がありますファイルに分割**expectedBlocks**連番のブロックで各 2 MB を超えるします。</span><span class="sxs-lookup"><span data-stu-id="41333-119">The client should split the file into **expectedBlocks** sequential blocks, no larger than 2 MB each.</span></span> <span data-ttu-id="41333-120">これらは、並列にアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="41333-120">They can be uploaded in parallel.</span></span>

<span data-ttu-id="41333-121">ブロック内のファイルをアップロードする場合、サーバー (202) を承諾済みの各要求の HTTP ステータス コードが返されます、Created (201) を返す、1 つのファイルとすべてのブロックをコミットを受け取るまで、予想されるすべてのブロックの場合はします。</span><span class="sxs-lookup"><span data-stu-id="41333-121">If you are uploading the file in blocks, the server will return an HTTP status code of Accepted (202) for each request, until it has received all expected blocks, in which case it commits all blocks as one file, returning Created (201).</span></span> <span data-ttu-id="41333-122">このような場合、応答に、オブジェクトが含まれていないと、サーバーは、追加の処理をスケジュール可能性があります。</span><span class="sxs-lookup"><span data-stu-id="41333-122">In these cases, the response does not contain an object, and the server may schedule additional processing.</span></span> <span data-ttu-id="41333-123">エラーが発生した**ServiceErrorResponse**オブジェクトを適切な HTTP ステータス コードと共に返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="41333-123">On error, a **ServiceErrorResponse** object may be returned along with an appropriate HTTP status code.</span></span>

<span data-ttu-id="41333-124">、回復不可能なエラー コード バックオフ再試行の標準的なメカニズムを使用して、クライアントを再試行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="41333-124">On a recoverable error code, the client should retry using a standard back-off retry mechanism.</span></span>

> [!NOTE] 
> <span data-ttu-id="41333-125">場合でも、アップロードが正常に完了すると、さらに処理が発生する可能性があります拒否上の理由から、クリップがアップロードまたはメタデータに関連しない方法を進めますプロセスします。</span><span class="sxs-lookup"><span data-stu-id="41333-125">Even if an upload completes successfully, further processing will occur that could reject the clip for reasons not related to the upload or metadata supplementing process.</span></span>


<a id="ID4EQB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="41333-126">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="41333-126">URI parameters</span></span>

| <span data-ttu-id="41333-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="41333-127">Parameter</span></span>| <span data-ttu-id="41333-128">型</span><span class="sxs-lookup"><span data-stu-id="41333-128">Type</span></span>| <span data-ttu-id="41333-129">説明</span><span class="sxs-lookup"><span data-stu-id="41333-129">Description</span></span>|
| --- | --- | --- | --- |
| <b><span data-ttu-id="41333-130">uri</span><span class="sxs-lookup"><span data-stu-id="41333-130">uri</span></span></b>| <span data-ttu-id="41333-131">string</span><span class="sxs-lookup"><span data-stu-id="41333-131">string</span></span>| <span data-ttu-id="41333-132"><b>InitialUploadResponse</b>オブジェクト内で<b>uploadUri</b>フィールド。</span><span class="sxs-lookup"><span data-stu-id="41333-132">The <b>uploadUri</b> field within the <b>InitialUploadResponse</b> object.</span></span>|

<a id="ID4ERC"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="41333-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="41333-133">Query string parameters</span></span>

| <span data-ttu-id="41333-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="41333-134">Parameter</span></span>| <span data-ttu-id="41333-135">型</span><span class="sxs-lookup"><span data-stu-id="41333-135">Type</span></span>| <span data-ttu-id="41333-136">説明</span><span class="sxs-lookup"><span data-stu-id="41333-136">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <b><span data-ttu-id="41333-137">blockNum</span><span class="sxs-lookup"><span data-stu-id="41333-137">blockNum</span></span></b>| <span data-ttu-id="41333-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="41333-138">32-bit unsigned integer</span></span>| <span data-ttu-id="41333-139"><b>ExpectedBlocks</b>が設定されているかどうかに必要です。</span><span class="sxs-lookup"><span data-stu-id="41333-139">Required if <b>expectedBlocks</b> is set.</span></span> <span data-ttu-id="41333-140">ファイルのブロックの順序を決定するインデックス 0 で始まるブロックの数です。</span><span class="sxs-lookup"><span data-stu-id="41333-140">Zero-indexed block number determining ordering of block in file.</span></span> <span data-ttu-id="41333-141">たとえば、 <b>expectedBlocks</b>が 7 の場合は、し<b>blockNum</b>は、0 から 6 にします。</span><span class="sxs-lookup"><span data-stu-id="41333-141">For example, if <b>expectedBlocks</b> is 7, then <b>blockNum</b> can be from 0 to 6.</span></span> |
| <b><span data-ttu-id="41333-142">uploadId</span><span class="sxs-lookup"><span data-stu-id="41333-142">uploadId</span></span></b>| <span data-ttu-id="41333-143">string</span><span class="sxs-lookup"><span data-stu-id="41333-143">string</span></span>| <span data-ttu-id="41333-144">必須。</span><span class="sxs-lookup"><span data-stu-id="41333-144">Required.</span></span> <span data-ttu-id="41333-145"><b>GameClipsServiceUploadResponse</b>オブジェクトの不透明な ID です。</span><span class="sxs-lookup"><span data-stu-id="41333-145">Opaque ID in <b>GameClipsServiceUploadResponse</b> object.</span></span>|

<a id="ID4EBE"></a>


## <a name="required-request-headers"></a><span data-ttu-id="41333-146">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-146">Required Request Headers</span></span>

| <span data-ttu-id="41333-147">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-147">Header</span></span>| <span data-ttu-id="41333-148">型</span><span class="sxs-lookup"><span data-stu-id="41333-148">Type</span></span>| <span data-ttu-id="41333-149">説明</span><span class="sxs-lookup"><span data-stu-id="41333-149">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="41333-150">Authorization</span><span class="sxs-lookup"><span data-stu-id="41333-150">Authorization</span></span>| <span data-ttu-id="41333-151">string</span><span class="sxs-lookup"><span data-stu-id="41333-151">string</span></span>| <span data-ttu-id="41333-152">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="41333-152">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="41333-153">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="41333-153">Example values: <b>Xauth=&lt;authtoken></b></span></span>|
| <span data-ttu-id="41333-154">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="41333-154">X-RequestedServiceVersion</span></span>| <span data-ttu-id="41333-155">string</span><span class="sxs-lookup"><span data-stu-id="41333-155">string</span></span>| <span data-ttu-id="41333-156">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="41333-156">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="41333-157">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="41333-157">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>|
| <span data-ttu-id="41333-158">Content-Type</span><span class="sxs-lookup"><span data-stu-id="41333-158">Content-Type</span></span>| <span data-ttu-id="41333-159">string</span><span class="sxs-lookup"><span data-stu-id="41333-159">string</span></span>| <span data-ttu-id="41333-160">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="41333-160">MIME type of the response body.</span></span> <span data-ttu-id="41333-161">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="41333-161">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="41333-162">Accept</span><span class="sxs-lookup"><span data-stu-id="41333-162">Accept</span></span>| <span data-ttu-id="41333-163">string</span><span class="sxs-lookup"><span data-stu-id="41333-163">string</span></span>| <span data-ttu-id="41333-164">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="41333-164">Acceptable values of Content-Type.</span></span> <span data-ttu-id="41333-165">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="41333-165">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="41333-166">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="41333-166">Cache-Control</span></span>| <span data-ttu-id="41333-167">string</span><span class="sxs-lookup"><span data-stu-id="41333-167">string</span></span>| <span data-ttu-id="41333-168">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="41333-168">Polite request to specify caching behavior.</span></span>|

<a id="ID4ENG"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="41333-169">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-169">Optional Request Headers</span></span>

| <span data-ttu-id="41333-170">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-170">Header</span></span>| <span data-ttu-id="41333-171">型</span><span class="sxs-lookup"><span data-stu-id="41333-171">Type</span></span>| <span data-ttu-id="41333-172">説明</span><span class="sxs-lookup"><span data-stu-id="41333-172">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="41333-173">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="41333-173">Accept-Encoding</span></span>| <span data-ttu-id="41333-174">string</span><span class="sxs-lookup"><span data-stu-id="41333-174">string</span></span>| <span data-ttu-id="41333-175">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="41333-175">Acceptable compression encodings.</span></span> <span data-ttu-id="41333-176">値の例: gzip、圧縮を識別します。</span><span class="sxs-lookup"><span data-stu-id="41333-176">Example values: gzip, deflate, identity.</span></span>|
| <span data-ttu-id="41333-177">ETag</span><span class="sxs-lookup"><span data-stu-id="41333-177">ETag</span></span>| <span data-ttu-id="41333-178">string</span><span class="sxs-lookup"><span data-stu-id="41333-178">string</span></span>| <span data-ttu-id="41333-179">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="41333-179">Used for cache optimization.</span></span> <span data-ttu-id="41333-180">値の例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="41333-180">Example value: "686897696a7c876b7e".</span></span>|

<a id="ID4EWH"></a>


## <a name="request-body"></a><span data-ttu-id="41333-181">要求本文</span><span class="sxs-lookup"><span data-stu-id="41333-181">Request body</span></span>

<span data-ttu-id="41333-182">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="41333-182">No objects are sent in the body of this request.</span></span>

<a id="ID4ECAAC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="41333-183">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="41333-183">HTTP status codes</span></span>

<span data-ttu-id="41333-184">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="41333-184">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="41333-185">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="41333-185">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="41333-186">コード</span><span class="sxs-lookup"><span data-stu-id="41333-186">Code</span></span>| <span data-ttu-id="41333-187">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="41333-187">Reason phrase</span></span>| <span data-ttu-id="41333-188">説明</span><span class="sxs-lookup"><span data-stu-id="41333-188">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="41333-189">200</span><span class="sxs-lookup"><span data-stu-id="41333-189">200</span></span>| <span data-ttu-id="41333-190">OK</span><span class="sxs-lookup"><span data-stu-id="41333-190">OK</span></span>| <span data-ttu-id="41333-191">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="41333-191">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="41333-192">301</span><span class="sxs-lookup"><span data-stu-id="41333-192">301</span></span>| <span data-ttu-id="41333-193">完全に移動</span><span class="sxs-lookup"><span data-stu-id="41333-193">Moved Permanently</span></span>| <span data-ttu-id="41333-194">サービスは、さまざまな URI に移動しました。</span><span class="sxs-lookup"><span data-stu-id="41333-194">The service has moved to a different URI.</span></span>|
| <span data-ttu-id="41333-195">307</span><span class="sxs-lookup"><span data-stu-id="41333-195">307</span></span>| <span data-ttu-id="41333-196">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="41333-196">Temporary Redirect</span></span>| <span data-ttu-id="41333-197">サービスは、さまざまな URI に移動しました。</span><span class="sxs-lookup"><span data-stu-id="41333-197">The service has moved to a different URI.</span></span>|
| <span data-ttu-id="41333-198">400</span><span class="sxs-lookup"><span data-stu-id="41333-198">400</span></span>| <span data-ttu-id="41333-199">Bad Request</span><span class="sxs-lookup"><span data-stu-id="41333-199">Bad Request</span></span>| <span data-ttu-id="41333-200">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="41333-200">Service could not understand malformed request.</span></span> <span data-ttu-id="41333-201">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="41333-201">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="41333-202">401</span><span class="sxs-lookup"><span data-stu-id="41333-202">401</span></span>| <span data-ttu-id="41333-203">権限がありません</span><span class="sxs-lookup"><span data-stu-id="41333-203">Unauthorized</span></span>| <span data-ttu-id="41333-204">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="41333-204">The request requires user authentication.</span></span>|
| <span data-ttu-id="41333-205">403</span><span class="sxs-lookup"><span data-stu-id="41333-205">403</span></span>| <span data-ttu-id="41333-206">Forbidden</span><span class="sxs-lookup"><span data-stu-id="41333-206">Forbidden</span></span>| <span data-ttu-id="41333-207">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="41333-207">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="41333-208">404</span><span class="sxs-lookup"><span data-stu-id="41333-208">404</span></span>| <span data-ttu-id="41333-209">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="41333-209">Not Found</span></span>| <span data-ttu-id="41333-210">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="41333-210">The specified resource could not be found.</span></span>|
| <span data-ttu-id="41333-211">406</span><span class="sxs-lookup"><span data-stu-id="41333-211">406</span></span>| <span data-ttu-id="41333-212">許容できません。</span><span class="sxs-lookup"><span data-stu-id="41333-212">Not Acceptable</span></span>| <span data-ttu-id="41333-213">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="41333-213">Resource version is not supported.</span></span>|
| <span data-ttu-id="41333-214">408</span><span class="sxs-lookup"><span data-stu-id="41333-214">408</span></span>| <span data-ttu-id="41333-215">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="41333-215">Request Timeout</span></span>| <span data-ttu-id="41333-216">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="41333-216">The request took too long to complete.</span></span>|
| <span data-ttu-id="41333-217">410</span><span class="sxs-lookup"><span data-stu-id="41333-217">410</span></span>| <span data-ttu-id="41333-218">なった</span><span class="sxs-lookup"><span data-stu-id="41333-218">Gone</span></span>| <span data-ttu-id="41333-219">要求されたリソースが利用可能ではありません。</span><span class="sxs-lookup"><span data-stu-id="41333-219">The requested resource is no longer available.</span></span>|

<a id="ID4EYEAC"></a>


## <a name="required-response-headers"></a><span data-ttu-id="41333-220">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-220">Required Response Headers</span></span>

| <span data-ttu-id="41333-221">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-221">Header</span></span>| <span data-ttu-id="41333-222">型</span><span class="sxs-lookup"><span data-stu-id="41333-222">Type</span></span>| <span data-ttu-id="41333-223">説明</span><span class="sxs-lookup"><span data-stu-id="41333-223">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="41333-224">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="41333-224">X-RequestedServiceVersion</span></span>| <span data-ttu-id="41333-225">string</span><span class="sxs-lookup"><span data-stu-id="41333-225">string</span></span>| <span data-ttu-id="41333-226">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="41333-226">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="41333-227">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="41333-227">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>|
| <span data-ttu-id="41333-228">Content-Type</span><span class="sxs-lookup"><span data-stu-id="41333-228">Content-Type</span></span>| <span data-ttu-id="41333-229">string</span><span class="sxs-lookup"><span data-stu-id="41333-229">string</span></span>| <span data-ttu-id="41333-230">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="41333-230">MIME type of the response body.</span></span> <span data-ttu-id="41333-231">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="41333-231">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="41333-232">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="41333-232">Cache-Control</span></span>| <span data-ttu-id="41333-233">string</span><span class="sxs-lookup"><span data-stu-id="41333-233">string</span></span>| <span data-ttu-id="41333-234">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="41333-234">Polite request to specify caching behavior.</span></span>|
| <span data-ttu-id="41333-235">Accept</span><span class="sxs-lookup"><span data-stu-id="41333-235">Accept</span></span>| <span data-ttu-id="41333-236">string</span><span class="sxs-lookup"><span data-stu-id="41333-236">string</span></span>| <span data-ttu-id="41333-237">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="41333-237">Acceptable values of Content-Type.</span></span> <span data-ttu-id="41333-238">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="41333-238">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="41333-239">Retry-after</span><span class="sxs-lookup"><span data-stu-id="41333-239">Retry-After</span></span>| <span data-ttu-id="41333-240">string</span><span class="sxs-lookup"><span data-stu-id="41333-240">string</span></span>| <span data-ttu-id="41333-241">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="41333-241">Instructs client to try again later in the case of an unavailable server.</span></span>|
| <span data-ttu-id="41333-242">異なる</span><span class="sxs-lookup"><span data-stu-id="41333-242">Vary</span></span>| <span data-ttu-id="41333-243">string</span><span class="sxs-lookup"><span data-stu-id="41333-243">string</span></span>| <span data-ttu-id="41333-244">下位のプロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="41333-244">Instructs downstream proxies how to cache responses.</span></span>|

<a id="ID4ELHAC"></a>


## <a name="optional-response-headers"></a><span data-ttu-id="41333-245">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-245">Optional Response Headers</span></span>

| <span data-ttu-id="41333-246">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="41333-246">Header</span></span>| <span data-ttu-id="41333-247">型</span><span class="sxs-lookup"><span data-stu-id="41333-247">Type</span></span>| <span data-ttu-id="41333-248">説明</span><span class="sxs-lookup"><span data-stu-id="41333-248">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="41333-249">Etag</span><span class="sxs-lookup"><span data-stu-id="41333-249">Etag</span></span>| <span data-ttu-id="41333-250">string</span><span class="sxs-lookup"><span data-stu-id="41333-250">string</span></span>| <span data-ttu-id="41333-251">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="41333-251">Used for cache optimization.</span></span> <span data-ttu-id="41333-252">例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="41333-252">Example: "686897696a7c876b7e".</span></span>|

<a id="ID4ELIAC"></a>


## <a name="response-body"></a><span data-ttu-id="41333-253">応答本文</span><span class="sxs-lookup"><span data-stu-id="41333-253">Response body</span></span>

<span data-ttu-id="41333-254">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="41333-254">No objects are sent in the body of the response.</span></span>

<a id="ID4EWIAC"></a>


## <a name="see-also"></a><span data-ttu-id="41333-255">関連項目</span><span class="sxs-lookup"><span data-stu-id="41333-255">See also</span></span>

<a id="ID4EYIAC"></a>


##### <a name="parent"></a><span data-ttu-id="41333-256">Parent</span><span class="sxs-lookup"><span data-stu-id="41333-256">Parent</span></span>

[<span data-ttu-id="41333-257">/{uri}</span><span class="sxs-lookup"><span data-stu-id="41333-257">/{uri}</span></span>](uri-uri.md)
