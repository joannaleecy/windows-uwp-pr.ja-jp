---
title: GET (/users/{ownerId}/clips)
assetID: da972b4e-bc38-66f5-2222-5e79d7c8a183
permalink: en-us/docs/xboxlive/rest/uri-usersowneridclipsget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/clips)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a215e9e1abb6daad2c011f38d56c2e501bd16e40
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4388165"
---
# <a name="get-usersowneridclips"></a><span data-ttu-id="8094a-104">GET (/users/{ownerId}/clips)</span><span class="sxs-lookup"><span data-stu-id="8094a-104">GET (/users/{ownerId}/clips)</span></span>
<span data-ttu-id="8094a-105">ユーザーのクリップの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="8094a-105">Retrieve list of user's clips.</span></span>
<span data-ttu-id="8094a-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`対象の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="8094a-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>

  * [<span data-ttu-id="8094a-107">注釈</span><span class="sxs-lookup"><span data-stu-id="8094a-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="8094a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8094a-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="8094a-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="8094a-109">Query string parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="8094a-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="8094a-110">Request body</span></span>](#ID4EPE)
  * [<span data-ttu-id="8094a-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8094a-111">Required Response Headers</span></span>](#ID4E1E)
  * [<span data-ttu-id="8094a-112">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8094a-112">Optional Response Headers</span></span>](#ID4ENH)
  * [<span data-ttu-id="8094a-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="8094a-113">Response body</span></span>](#ID4EOAAC)
  * [<span data-ttu-id="8094a-114">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="8094a-114">Related URIs</span></span>](#ID4EABAC)

<a id="ID4EX"></a>


## <a name="remarks"></a><span data-ttu-id="8094a-115">注釈</span><span class="sxs-lookup"><span data-stu-id="8094a-115">Remarks</span></span>

<span data-ttu-id="8094a-116">この API を使用すると、ユーザー独自のサービスに保存されているも他のユーザーのクリップのクリップの一覧にさまざまな方法です。</span><span class="sxs-lookup"><span data-stu-id="8094a-116">This API enables various ways to list a user's own clips as well as other users' clips that are stored in the service.</span></span> <span data-ttu-id="8094a-117">複数のエントリ ポイントは、異なるレベルのデータが返され、クエリ パラメーターによってフィルター処理するためです。</span><span class="sxs-lookup"><span data-stu-id="8094a-117">Several entry points return data from different levels and allow for filtering via query parameters.</span></span> <span data-ttu-id="8094a-118">要求で XUID には、URI で指定された所有者が一致すると場合、は、コンテンツの分離がチェックされた後、ユーザーのクリップは返されます。</span><span class="sxs-lookup"><span data-stu-id="8094a-118">If the XUID in the claim matches the owner specified in the URI, then the user's own clips are returned after content isolation checks.</span></span> <span data-ttu-id="8094a-119">URI の所有者が要求 XUID が一致しない場合、指定されたユーザーのクリップ返されるプライバシー チェックと要求元の XUID に対してコンテンツの分離チェックします。</span><span class="sxs-lookup"><span data-stu-id="8094a-119">If the owner in the URI does not match the claim XUID, then the specified user's clips are returned based on privacy checks and content isolation checks against the requesting XUID.</span></span>

<span data-ttu-id="8094a-120">ユーザーごと、サービス構成 id (scid) は、クエリが最適化されています。</span><span class="sxs-lookup"><span data-stu-id="8094a-120">Queries are optimized per user per service configuration id (scid).</span></span> <span data-ttu-id="8094a-121">または指定するさらにフィルターを使って、既定値以外の並べ替え順序の下に指定されているいくつかの状況で長い時間がかかるに戻ります。</span><span class="sxs-lookup"><span data-stu-id="8094a-121">Specifying further filters or sort orders other than the defaults as specified below can in some circumstances take longer to return.</span></span> <span data-ttu-id="8094a-122">これは、ユーザーごとのビデオの大きなセットのより顕著です。</span><span class="sxs-lookup"><span data-stu-id="8094a-122">This is more evident for larger sets of videos per user.</span></span>

<span data-ttu-id="8094a-123">同じ API の呼び出し内で複数のユーザーの一覧を取得するためのバッチ API はありません。</span><span class="sxs-lookup"><span data-stu-id="8094a-123">There is no batch API for getting multiple users' list within the same API call.</span></span> <span data-ttu-id="8094a-124">推奨されるパターン (現在) SLS 深くからではユーザーごとに照会します。</span><span class="sxs-lookup"><span data-stu-id="8094a-124">The recommended pattern (currently) from the SLS Architects is to query for each user in turn.</span></span>

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="8094a-125">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8094a-125">URI parameters</span></span>

| <span data-ttu-id="8094a-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8094a-126">Parameter</span></span>| <span data-ttu-id="8094a-127">型</span><span class="sxs-lookup"><span data-stu-id="8094a-127">Type</span></span>| <span data-ttu-id="8094a-128">説明</span><span class="sxs-lookup"><span data-stu-id="8094a-128">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="8094a-129">ownerId</span><span class="sxs-lookup"><span data-stu-id="8094a-129">ownerId</span></span>| <span data-ttu-id="8094a-130">string</span><span class="sxs-lookup"><span data-stu-id="8094a-130">string</span></span>| <span data-ttu-id="8094a-131">そのリソースにアクセスしているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="8094a-131">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="8094a-132">サポートされる形式:"me"または"xuid(123456789)"です。</span><span class="sxs-lookup"><span data-stu-id="8094a-132">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="8094a-133">最大長: 16 します。</span><span class="sxs-lookup"><span data-stu-id="8094a-133">Maximum length: 16.</span></span>|

<a id="ID4EPB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="8094a-134">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="8094a-134">Query string parameters</span></span>

| <span data-ttu-id="8094a-135">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8094a-135">Parameter</span></span>| <span data-ttu-id="8094a-136">型</span><span class="sxs-lookup"><span data-stu-id="8094a-136">Type</span></span>| <span data-ttu-id="8094a-137">説明</span><span class="sxs-lookup"><span data-stu-id="8094a-137">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="8094a-138">skipItems</span><span class="sxs-lookup"><span data-stu-id="8094a-138">skipItems</span></span>| <span data-ttu-id="8094a-139">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8094a-139">32-bit signed integer</span></span>| <span data-ttu-id="8094a-140">省略可能。</span><span class="sxs-lookup"><span data-stu-id="8094a-140">Optional.</span></span> <span data-ttu-id="8094a-141">N+1 コレクション (つまり、スキップ N 項目) で始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="8094a-141">Return the items starting at N+1 in the collection (i.e., skip N items).</span></span>|
| <span data-ttu-id="8094a-142">continuationToken</span><span class="sxs-lookup"><span data-stu-id="8094a-142">continuationToken</span></span>| <span data-ttu-id="8094a-143">文字列</span><span class="sxs-lookup"><span data-stu-id="8094a-143">string</span></span>| <span data-ttu-id="8094a-144">省略可能。</span><span class="sxs-lookup"><span data-stu-id="8094a-144">Optional.</span></span> <span data-ttu-id="8094a-145">特定の継続トークンで始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="8094a-145">Return the items starting at the given continuation token.</span></span> <span data-ttu-id="8094a-146">ContinuationToken パラメーターよりも優先 skipItems 両方が提供されている場合。</span><span class="sxs-lookup"><span data-stu-id="8094a-146">The continuationToken parameter takes precedence over skipItems if both are provided.</span></span> <span data-ttu-id="8094a-147">つまり、continuationToken パラメーターが存在する場合、skipItems パラメーターは無視されます。</span><span class="sxs-lookup"><span data-stu-id="8094a-147">In other words, the skipItems parameter is ignored if continuationToken parameter is present.</span></span> <span data-ttu-id="8094a-148">最大サイズ: 36 です。</span><span class="sxs-lookup"><span data-stu-id="8094a-148">Maximum size: 36.</span></span>|
| <span data-ttu-id="8094a-149">maxItems</span><span class="sxs-lookup"><span data-stu-id="8094a-149">maxItems</span></span>| <span data-ttu-id="8094a-150">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8094a-150">32-bit signed integer</span></span>| <span data-ttu-id="8094a-151">省略可能。</span><span class="sxs-lookup"><span data-stu-id="8094a-151">Optional.</span></span> <span data-ttu-id="8094a-152">(SkipItems と項目の範囲を返す continuationToken と組み合わせることができます)、コレクションから返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="8094a-152">Maximum number of items to return from the collection (can be combined with skipItems and continuationToken to return a range of items).</span></span> <span data-ttu-id="8094a-153">MaxItems が存在しないと、(結果の最後のページが返されていない) 場合でも maxItems よりも少ない返す可能性がある場合、サービスは既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8094a-153">The service may provide a default value if maxItems is not present and may return fewer than maxItems (even if the last page of results has not yet been returned).</span></span>|
| <span data-ttu-id="8094a-154">順序</span><span class="sxs-lookup"><span data-stu-id="8094a-154">order</span></span>| <span data-ttu-id="8094a-155">Unicode 文字</span><span class="sxs-lookup"><span data-stu-id="8094a-155">Unicode character</span></span>| <span data-ttu-id="8094a-156">省略可能。</span><span class="sxs-lookup"><span data-stu-id="8094a-156">Optional.</span></span> <span data-ttu-id="8094a-157">(D) escending でリストが返されるかどうかを指定します (最初に値が最高) または (A) scending (最初に値が最も低い) 注文します。</span><span class="sxs-lookup"><span data-stu-id="8094a-157">Specifies if list is returned in (D)escending (highest value first) or (A)scending (lowest value first) order.</span></span> <span data-ttu-id="8094a-158">既定: D.</span><span class="sxs-lookup"><span data-stu-id="8094a-158">Default: D.</span></span>|
| <span data-ttu-id="8094a-159">type</span><span class="sxs-lookup"><span data-stu-id="8094a-159">type</span></span>| <span data-ttu-id="8094a-160">GameClipTypes</span><span class="sxs-lookup"><span data-stu-id="8094a-160">GameClipTypes</span></span>| <span data-ttu-id="8094a-161">省略可能。</span><span class="sxs-lookup"><span data-stu-id="8094a-161">Optional.</span></span> <span data-ttu-id="8094a-162">返すクリップの種類のコンマ区切りのセット。</span><span class="sxs-lookup"><span data-stu-id="8094a-162">Comma-delimited set of the type of clips to return.</span></span> <span data-ttu-id="8094a-163">既定: すべてします。</span><span class="sxs-lookup"><span data-stu-id="8094a-163">Default: All.</span></span>|
| <span data-ttu-id="8094a-164">イベント Id</span><span class="sxs-lookup"><span data-stu-id="8094a-164">eventId</span></span>| <span data-ttu-id="8094a-165">string</span><span class="sxs-lookup"><span data-stu-id="8094a-165">string</span></span>| <span data-ttu-id="8094a-166">省略可能。</span><span class="sxs-lookup"><span data-stu-id="8094a-166">Optional.</span></span> <span data-ttu-id="8094a-167">EventIDs で結果をフィルター処理のコンマ区切りのセット。</span><span class="sxs-lookup"><span data-stu-id="8094a-167">Comma-delimited set of eventIDs to filter results by.</span></span> <span data-ttu-id="8094a-168">既定: Null。</span><span class="sxs-lookup"><span data-stu-id="8094a-168">Default: Null.</span></span>|
| <span data-ttu-id="8094a-169">修飾子</span><span class="sxs-lookup"><span data-stu-id="8094a-169">qualifer</span></span>| <span data-ttu-id="8094a-170">string</span><span class="sxs-lookup"><span data-stu-id="8094a-170">string</span></span>| <span data-ttu-id="8094a-171">省略可能。</span><span class="sxs-lookup"><span data-stu-id="8094a-171">Optional.</span></span> <span data-ttu-id="8094a-172">クリップを取得するために使用される順序の修飾子を指定します。</span><span class="sxs-lookup"><span data-stu-id="8094a-172">Specifies the order qualifier to be used for getting the clips.</span></span> <ul><li><span data-ttu-id="8094a-173">作成した - クリップがシステムに日付の順序で返されるを指定します。</span><span class="sxs-lookup"><span data-stu-id="8094a-173">created - specifies the clips are returned in order of date into the system</span></span></li><li><span data-ttu-id="8094a-174">評価 - [Top 評価] - クリップがその評価値によって返されるを指定します</span><span class="sxs-lookup"><span data-stu-id="8094a-174">rating - [Top Rated] - specifies the clips are returned by their rating value</span></span></li><li><span data-ttu-id="8094a-175">[最も表示] - ビュー - クリップはビューの数によって返されるを指定します。</span><span class="sxs-lookup"><span data-stu-id="8094a-175">views - [Most Viewed] - specifies the clips are returned by number of views</span></span></li></ul><br/> <span data-ttu-id="8094a-176">最大サイズ: 12。</span><span class="sxs-lookup"><span data-stu-id="8094a-176">Maximum size: 12.</span></span> <span data-ttu-id="8094a-177">既定値:「作成」されます。</span><span class="sxs-lookup"><span data-stu-id="8094a-177">Default: "created".</span></span>| 

<a id="ID4EPE"></a>


## <a name="request-body"></a><span data-ttu-id="8094a-178">要求本文</span><span class="sxs-lookup"><span data-stu-id="8094a-178">Request body</span></span>

<span data-ttu-id="8094a-179">この要求の必要なメンバーはありません。</span><span class="sxs-lookup"><span data-stu-id="8094a-179">There are no required members for this request.</span></span>

<a id="ID4E1E"></a>


## <a name="required-response-headers"></a><span data-ttu-id="8094a-180">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8094a-180">Required Response Headers</span></span>

| <span data-ttu-id="8094a-181">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8094a-181">Header</span></span>| <span data-ttu-id="8094a-182">型</span><span class="sxs-lookup"><span data-stu-id="8094a-182">Type</span></span>| <span data-ttu-id="8094a-183">説明</span><span class="sxs-lookup"><span data-stu-id="8094a-183">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="8094a-184">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="8094a-184">X-RequestedServiceVersion</span></span>| <span data-ttu-id="8094a-185">string</span><span class="sxs-lookup"><span data-stu-id="8094a-185">string</span></span>| <span data-ttu-id="8094a-186">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="8094a-186">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="8094a-187">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="8094a-187">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>|
| <span data-ttu-id="8094a-188">Content-Type</span><span class="sxs-lookup"><span data-stu-id="8094a-188">Content-Type</span></span>| <span data-ttu-id="8094a-189">string</span><span class="sxs-lookup"><span data-stu-id="8094a-189">string</span></span>| <span data-ttu-id="8094a-190">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="8094a-190">MIME type of the response body.</span></span> <span data-ttu-id="8094a-191">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="8094a-191">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="8094a-192">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="8094a-192">Cache-Control</span></span>| <span data-ttu-id="8094a-193">string</span><span class="sxs-lookup"><span data-stu-id="8094a-193">string</span></span>| <span data-ttu-id="8094a-194">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="8094a-194">Polite request to specify caching behavior.</span></span>|
| <span data-ttu-id="8094a-195">Accept</span><span class="sxs-lookup"><span data-stu-id="8094a-195">Accept</span></span>| <span data-ttu-id="8094a-196">string</span><span class="sxs-lookup"><span data-stu-id="8094a-196">string</span></span>| <span data-ttu-id="8094a-197">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="8094a-197">Acceptable values of Content-Type.</span></span> <span data-ttu-id="8094a-198">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="8094a-198">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="8094a-199">Retry-after</span><span class="sxs-lookup"><span data-stu-id="8094a-199">Retry-After</span></span>| <span data-ttu-id="8094a-200">string</span><span class="sxs-lookup"><span data-stu-id="8094a-200">string</span></span>| <span data-ttu-id="8094a-201">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="8094a-201">Instructs client to try again later in the case of an unavailable server.</span></span>|
| <span data-ttu-id="8094a-202">異なる</span><span class="sxs-lookup"><span data-stu-id="8094a-202">Vary</span></span>| <span data-ttu-id="8094a-203">string</span><span class="sxs-lookup"><span data-stu-id="8094a-203">string</span></span>| <span data-ttu-id="8094a-204">下位のプロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="8094a-204">Instructs downstream proxies how to cache responses.</span></span>|

<a id="ID4ENH"></a>


## <a name="optional-response-headers"></a><span data-ttu-id="8094a-205">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8094a-205">Optional Response Headers</span></span>

| <span data-ttu-id="8094a-206">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8094a-206">Header</span></span>| <span data-ttu-id="8094a-207">型</span><span class="sxs-lookup"><span data-stu-id="8094a-207">Type</span></span>| <span data-ttu-id="8094a-208">説明</span><span class="sxs-lookup"><span data-stu-id="8094a-208">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="8094a-209">Etag</span><span class="sxs-lookup"><span data-stu-id="8094a-209">Etag</span></span>| <span data-ttu-id="8094a-210">string</span><span class="sxs-lookup"><span data-stu-id="8094a-210">string</span></span>| <span data-ttu-id="8094a-211">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="8094a-211">Used for cache optimization.</span></span> <span data-ttu-id="8094a-212">例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="8094a-212">Example: "686897696a7c876b7e".</span></span>|

<a id="ID4EOAAC"></a>


## <a name="response-body"></a><span data-ttu-id="8094a-213">応答本文</span><span class="sxs-lookup"><span data-stu-id="8094a-213">Response body</span></span>

<a id="ID4EUAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="8094a-214">応答の例</span><span class="sxs-lookup"><span data-stu-id="8094a-214">Sample response</span></span>


```cpp
{
       "gameClips":
       [
           {
               "xuid": "2716903703773872",
               "clipName": "[en-US] Localized Greatest Moment Name",
               "titleName": "[en-US] Localized Title Name",
               "gameClipLocale": "en-US",
               "gameClipId": "6873f6cf-af12-48a5-8be6-f3dfc3f61538-000",
               "state": "Published",
               "dateRecorded": "2013-06-14T01:02:55.4918465Z",
               "lastModified": "2013-06-14T01:05:41.3652693Z",
               "userCaption": "Set by user!",
               "type": "DeveloperInitiated",
               "source": "Console",
               "visibility": "Public",
               "durationInSeconds": 30,
               "scid": "00000000-0000-0012-0023-000000000070",
               "titleId": 354975,
               "rating": 3.75,
               "ratingCount": 245,
               "views": 7453,
               "titleData": "",
               "systemProperties": "",
               "savedByUser": false,
               "achievementId": "AchievementId",
               "greatestMomentId": "GreatestMomentId",
               "thumbnails": [
                   {
                       "uri": "http://localhost/users/xuid(2716903703773872)/scids/00000000-0000-0012-0023-000000000070/clips/6873f6cf-af12-48a5-8be6-f3dfc3f61538-000/thumbnails/large",
                       "fileSize": 637293,
                       "thumbnailType": "Large"
                   },
                   {
                       "uri": "http://localhost/users/xuid(2716903703773872)/scids/00000000-0000-0012-0023-000000000070/clips/6873f6cf-af12-48a5-8be6-f3dfc3f61538-000/thumbnails/small",
                       "fileSize": 163998,
                       "thumbnailType": "Small"
                   }
               ],
               "gameClipUris": [
                   {
                       "uri": "http://localhost/897f65a9-63f0-45a0-926f-05a3155c04fc/GameClip-Original_4000.ism/manifest",
                       "uriType": "SmoothStreaming",
                       "expiration": "2013-06-14T01:10:08.73652Z"
                   },
                   {
                       "uri": "http://localhost/897f65a9-63f0-45a0-926f-05a3155c04fc/GameClip-Original_4000.ism/manifest(format=m3u8-aapl)",
                       "uriType": "Ahls",
                       "expiration": "2013-06-14T01:10:08.73652Z"
                   },
                   {
                       "uri": "http://localhost/users/xuid(2716903703773872)/scids/00000000-0000-0012-0023-000000000070/clips/6873f6cf-af12-48a5-8be6-f3dfc3f61538-000",
                       "fileSize": 88820,
                       "uriType": "Download",
                       "expiration": "2999-12-31T11:59:40Z"
                   }
               ]
           }
       ],
   "pagingInfo":
       {
           "continuationToken": null,
           "totalItems": 1
       }
   }

```


<a id="ID4EABAC"></a>


## <a name="related-uris"></a><span data-ttu-id="8094a-215">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="8094a-215">Related URIs</span></span>

<span data-ttu-id="8094a-216">次の URI は、このドキュメントでは、SCID を指定する追加のパス パラメーターを使って、プライマリ チャネルと同じです。</span><span class="sxs-lookup"><span data-stu-id="8094a-216">The following URI is identical to the primary one in this document, but with an extra path parameter to specify a SCID.</span></span> <span data-ttu-id="8094a-217">その SCID にそのユーザーのクリップのみが返されます。</span><span class="sxs-lookup"><span data-stu-id="8094a-217">Only that user's clips for that SCID will be returned.</span></span> <span data-ttu-id="8094a-218">要求元のユーザーに要求された SCID にアクセスする必要があります、それ以外の場合 HTTP エラー 403 が返されます。</span><span class="sxs-lookup"><span data-stu-id="8094a-218">The requesting user must have access to the requested SCID, otherwise HTTP error 403 will be returned.</span></span>

   * **<span data-ttu-id="8094a-219">/users/{ownerId}/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="8094a-219">/users/{ownerId}/scids/{scid}/clips</span></span>**

<a id="ID4ENBAC"></a>


## <a name="see-also"></a><span data-ttu-id="8094a-220">関連項目</span><span class="sxs-lookup"><span data-stu-id="8094a-220">See also</span></span>

<a id="ID4EPBAC"></a>


##### <a name="parent"></a><span data-ttu-id="8094a-221">Parent</span><span class="sxs-lookup"><span data-stu-id="8094a-221">Parent</span></span>

[<span data-ttu-id="8094a-222">/users/{ownerId}/clips</span><span class="sxs-lookup"><span data-stu-id="8094a-222">/users/{ownerId}/clips</span></span>](uri-usersowneridclips.md)
