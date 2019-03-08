---
title: GET (/users/{ownerId}/clips)
assetID: da972b4e-bc38-66f5-2222-5e79d7c8a183
permalink: en-us/docs/xboxlive/rest/uri-usersowneridclipsget.html
description: " GET (/users/{ownerId}/clips)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7c52daf4a07914c34f1aadc84a7238771669d65f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623207"
---
# <a name="get-usersowneridclips"></a><span data-ttu-id="c4cee-104">GET (/users/{ownerId}/clips)</span><span class="sxs-lookup"><span data-stu-id="c4cee-104">GET (/users/{ownerId}/clips)</span></span>
<span data-ttu-id="c4cee-105">ユーザーのクリップの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-105">Retrieve list of user's clips.</span></span>
<span data-ttu-id="c4cee-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="c4cee-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>

  * [<span data-ttu-id="c4cee-107">注釈</span><span class="sxs-lookup"><span data-stu-id="c4cee-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="c4cee-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4cee-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="c4cee-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4cee-109">Query string parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="c4cee-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="c4cee-110">Request body</span></span>](#ID4EPE)
  * [<span data-ttu-id="c4cee-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c4cee-111">Required Response Headers</span></span>](#ID4E1E)
  * [<span data-ttu-id="c4cee-112">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c4cee-112">Optional Response Headers</span></span>](#ID4ENH)
  * [<span data-ttu-id="c4cee-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="c4cee-113">Response body</span></span>](#ID4EOAAC)
  * [<span data-ttu-id="c4cee-114">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="c4cee-114">Related URIs</span></span>](#ID4EABAC)

<a id="ID4EX"></a>


## <a name="remarks"></a><span data-ttu-id="c4cee-115">注釈</span><span class="sxs-lookup"><span data-stu-id="c4cee-115">Remarks</span></span>

<span data-ttu-id="c4cee-116">この API は、ユーザー独自のサービスに格納されているにも他のユーザーのクリップのクリップ リストにさまざまな方法を使用できます。</span><span class="sxs-lookup"><span data-stu-id="c4cee-116">This API enables various ways to list a user's own clips as well as other users' clips that are stored in the service.</span></span> <span data-ttu-id="c4cee-117">いくつかのエントリ ポイントは、さまざまなレベルからデータを返すし、クエリ パラメーターを使用してフィルター処理するためです。</span><span class="sxs-lookup"><span data-stu-id="c4cee-117">Several entry points return data from different levels and allow for filtering via query parameters.</span></span> <span data-ttu-id="c4cee-118">要求 XUID には、URI で指定された所有者が一致すると、し、ユーザーのクリップが返されます後、コンテンツの分離を確認します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-118">If the XUID in the claim matches the owner specified in the URI, then the user's own clips are returned after content isolation checks.</span></span> <span data-ttu-id="c4cee-119">場合は、URI の所有者では、指定したユーザーのクリップのプライバシーに関する確認と要求元 XUID に対してコンテンツの分離のチェックがに基づいて返されます、XUID、要求は一致しません。</span><span class="sxs-lookup"><span data-stu-id="c4cee-119">If the owner in the URI does not match the claim XUID, then the specified user's clips are returned based on privacy checks and content isolation checks against the requesting XUID.</span></span>

<span data-ttu-id="c4cee-120">ユーザーごと、サービス構成の id (scid) は、クエリが最適化されています。</span><span class="sxs-lookup"><span data-stu-id="c4cee-120">Queries are optimized per user per service configuration id (scid).</span></span> <span data-ttu-id="c4cee-121">指定するさらにフィルターまたは既定値以外の並べ替え順序以下に示すいくつかの状況で長い時間がかかるを返します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-121">Specifying further filters or sort orders other than the defaults as specified below can in some circumstances take longer to return.</span></span> <span data-ttu-id="c4cee-122">ユーザーごとの動画の大規模な一連のより明らかになります。</span><span class="sxs-lookup"><span data-stu-id="c4cee-122">This is more evident for larger sets of videos per user.</span></span>

<span data-ttu-id="c4cee-123">同じ API の呼び出し内で複数のユーザーの一覧を取得するためのバッチ API はありません。</span><span class="sxs-lookup"><span data-stu-id="c4cee-123">There is no batch API for getting multiple users' list within the same API call.</span></span> <span data-ttu-id="c4cee-124">推奨されるパターン (現在) SLS アーキテクトからはさらに各ユーザーに対してクエリを実行します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-124">The recommended pattern (currently) from the SLS Architects is to query for each user in turn.</span></span>

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="c4cee-125">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4cee-125">URI parameters</span></span>

| <span data-ttu-id="c4cee-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4cee-126">Parameter</span></span>| <span data-ttu-id="c4cee-127">種類</span><span class="sxs-lookup"><span data-stu-id="c4cee-127">Type</span></span>| <span data-ttu-id="c4cee-128">説明</span><span class="sxs-lookup"><span data-stu-id="c4cee-128">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="c4cee-129">ownerId</span><span class="sxs-lookup"><span data-stu-id="c4cee-129">ownerId</span></span>| <span data-ttu-id="c4cee-130">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-130">string</span></span>| <span data-ttu-id="c4cee-131">リソースがアクセスされているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="c4cee-131">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="c4cee-132">サポートされている形式:"xuid(123456789)"または"me"。</span><span class="sxs-lookup"><span data-stu-id="c4cee-132">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="c4cee-133">最大長:16.</span><span class="sxs-lookup"><span data-stu-id="c4cee-133">Maximum length: 16.</span></span>|

<a id="ID4EPB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="c4cee-134">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4cee-134">Query string parameters</span></span>

| <span data-ttu-id="c4cee-135">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4cee-135">Parameter</span></span>| <span data-ttu-id="c4cee-136">種類</span><span class="sxs-lookup"><span data-stu-id="c4cee-136">Type</span></span>| <span data-ttu-id="c4cee-137">説明</span><span class="sxs-lookup"><span data-stu-id="c4cee-137">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c4cee-138">skipItems</span><span class="sxs-lookup"><span data-stu-id="c4cee-138">skipItems</span></span>| <span data-ttu-id="c4cee-139">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="c4cee-139">32-bit signed integer</span></span>| <span data-ttu-id="c4cee-140">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="c4cee-140">Optional.</span></span> <span data-ttu-id="c4cee-141">N+1 コレクション (つまり、skip N 項目) で始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-141">Return the items starting at N+1 in the collection (i.e., skip N items).</span></span>|
| <span data-ttu-id="c4cee-142">continuationToken</span><span class="sxs-lookup"><span data-stu-id="c4cee-142">continuationToken</span></span>| <span data-ttu-id="c4cee-143">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-143">string</span></span>| <span data-ttu-id="c4cee-144">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="c4cee-144">Optional.</span></span> <span data-ttu-id="c4cee-145">指定された継続トークンで始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-145">Return the items starting at the given continuation token.</span></span> <span data-ttu-id="c4cee-146">ContinuationToken パラメーターよりも優先 skipItems 両方を指定しない場合。</span><span class="sxs-lookup"><span data-stu-id="c4cee-146">The continuationToken parameter takes precedence over skipItems if both are provided.</span></span> <span data-ttu-id="c4cee-147">つまり、skipItems パラメーターには、continuationToken パラメーターが存在する場合は無視されます。</span><span class="sxs-lookup"><span data-stu-id="c4cee-147">In other words, the skipItems parameter is ignored if continuationToken parameter is present.</span></span> <span data-ttu-id="c4cee-148">最大サイズ:36.</span><span class="sxs-lookup"><span data-stu-id="c4cee-148">Maximum size: 36.</span></span>|
| <span data-ttu-id="c4cee-149">maxItems</span><span class="sxs-lookup"><span data-stu-id="c4cee-149">maxItems</span></span>| <span data-ttu-id="c4cee-150">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="c4cee-150">32-bit signed integer</span></span>| <span data-ttu-id="c4cee-151">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="c4cee-151">Optional.</span></span> <span data-ttu-id="c4cee-152">(SkipItems と項目の範囲を取得するように continuationToken と組み合わせることができます) のコレクションから返されるアイテムの最大数。</span><span class="sxs-lookup"><span data-stu-id="c4cee-152">Maximum number of items to return from the collection (can be combined with skipItems and continuationToken to return a range of items).</span></span> <span data-ttu-id="c4cee-153">MaxItems が存在しないと、(結果の最後のページはまだ返送されていない) 場合でも、maxItems よりも少ないを返すことが場合、サービスは既定値を提供できます。</span><span class="sxs-lookup"><span data-stu-id="c4cee-153">The service may provide a default value if maxItems is not present and may return fewer than maxItems (even if the last page of results has not yet been returned).</span></span>|
| <span data-ttu-id="c4cee-154">順序</span><span class="sxs-lookup"><span data-stu-id="c4cee-154">order</span></span>| <span data-ttu-id="c4cee-155">Unicode 文字</span><span class="sxs-lookup"><span data-stu-id="c4cee-155">Unicode character</span></span>| <span data-ttu-id="c4cee-156">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="c4cee-156">Optional.</span></span> <span data-ttu-id="c4cee-157">かどうか、(D) escending に返される一覧を指定します (最初に値が最高) scending (A) または (最初に最小値) の順序。</span><span class="sxs-lookup"><span data-stu-id="c4cee-157">Specifies if list is returned in (D)escending (highest value first) or (A)scending (lowest value first) order.</span></span> <span data-ttu-id="c4cee-158">既定:D。</span><span class="sxs-lookup"><span data-stu-id="c4cee-158">Default: D.</span></span>|
| <span data-ttu-id="c4cee-159">type</span><span class="sxs-lookup"><span data-stu-id="c4cee-159">type</span></span>| <span data-ttu-id="c4cee-160">GameClipTypes</span><span class="sxs-lookup"><span data-stu-id="c4cee-160">GameClipTypes</span></span>| <span data-ttu-id="c4cee-161">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="c4cee-161">Optional.</span></span> <span data-ttu-id="c4cee-162">返されるクリップの種類のコンマ区切りのセット。</span><span class="sxs-lookup"><span data-stu-id="c4cee-162">Comma-delimited set of the type of clips to return.</span></span> <span data-ttu-id="c4cee-163">既定:すべての。</span><span class="sxs-lookup"><span data-stu-id="c4cee-163">Default: All.</span></span>|
| <span data-ttu-id="c4cee-164">イベント Id</span><span class="sxs-lookup"><span data-stu-id="c4cee-164">eventId</span></span>| <span data-ttu-id="c4cee-165">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-165">string</span></span>| <span data-ttu-id="c4cee-166">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="c4cee-166">Optional.</span></span> <span data-ttu-id="c4cee-167">結果をフィルター処理する Eventid のコンマ区切りのセット。</span><span class="sxs-lookup"><span data-stu-id="c4cee-167">Comma-delimited set of eventIDs to filter results by.</span></span> <span data-ttu-id="c4cee-168">既定:null を返します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-168">Default: Null.</span></span>|
| <span data-ttu-id="c4cee-169">修飾子</span><span class="sxs-lookup"><span data-stu-id="c4cee-169">qualifer</span></span>| <span data-ttu-id="c4cee-170">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-170">string</span></span>| <span data-ttu-id="c4cee-171">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="c4cee-171">Optional.</span></span> <span data-ttu-id="c4cee-172">クリップを取得するために使用される order 修飾子を指定します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-172">Specifies the order qualifier to be used for getting the clips.</span></span> <ul><li><span data-ttu-id="c4cee-173">作成 - クリップがシステムに日付の順序で返されるを指定します</span><span class="sxs-lookup"><span data-stu-id="c4cee-173">created - specifies the clips are returned in order of date into the system</span></span></li><li><span data-ttu-id="c4cee-174">-[トップランクの評価] の評価には、クリップがその評価の値によって返されるを指定します</span><span class="sxs-lookup"><span data-stu-id="c4cee-174">rating - [Top Rated] - specifies the clips are returned by their rating value</span></span></li><li><span data-ttu-id="c4cee-175">[最も表示] - - ビューでは、クリップがビューの数によって返されるを指定します</span><span class="sxs-lookup"><span data-stu-id="c4cee-175">views - [Most Viewed] - specifies the clips are returned by number of views</span></span></li></ul><br/> <span data-ttu-id="c4cee-176">最大サイズ:12.</span><span class="sxs-lookup"><span data-stu-id="c4cee-176">Maximum size: 12.</span></span> <span data-ttu-id="c4cee-177">既定値:「作成」します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-177">Default: "created".</span></span>| 

<a id="ID4EPE"></a>


## <a name="request-body"></a><span data-ttu-id="c4cee-178">要求本文</span><span class="sxs-lookup"><span data-stu-id="c4cee-178">Request body</span></span>

<span data-ttu-id="c4cee-179">この要求の必須メンバーはありません。</span><span class="sxs-lookup"><span data-stu-id="c4cee-179">There are no required members for this request.</span></span>

<a id="ID4E1E"></a>


## <a name="required-response-headers"></a><span data-ttu-id="c4cee-180">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c4cee-180">Required Response Headers</span></span>

| <span data-ttu-id="c4cee-181">Header</span><span class="sxs-lookup"><span data-stu-id="c4cee-181">Header</span></span>| <span data-ttu-id="c4cee-182">種類</span><span class="sxs-lookup"><span data-stu-id="c4cee-182">Type</span></span>| <span data-ttu-id="c4cee-183">説明</span><span class="sxs-lookup"><span data-stu-id="c4cee-183">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c4cee-184">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="c4cee-184">X-RequestedServiceVersion</span></span>| <span data-ttu-id="c4cee-185">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-185">string</span></span>| <span data-ttu-id="c4cee-186">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="c4cee-186">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="c4cee-187">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="c4cee-187">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>|
| <span data-ttu-id="c4cee-188">Content-Type</span><span class="sxs-lookup"><span data-stu-id="c4cee-188">Content-Type</span></span>| <span data-ttu-id="c4cee-189">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-189">string</span></span>| <span data-ttu-id="c4cee-190">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="c4cee-190">MIME type of the response body.</span></span> <span data-ttu-id="c4cee-191">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-191">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="c4cee-192">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="c4cee-192">Cache-Control</span></span>| <span data-ttu-id="c4cee-193">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-193">string</span></span>| <span data-ttu-id="c4cee-194">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="c4cee-194">Polite request to specify caching behavior.</span></span>|
| <span data-ttu-id="c4cee-195">OK</span><span class="sxs-lookup"><span data-stu-id="c4cee-195">Accept</span></span>| <span data-ttu-id="c4cee-196">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-196">string</span></span>| <span data-ttu-id="c4cee-197">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="c4cee-197">Acceptable values of Content-Type.</span></span> <span data-ttu-id="c4cee-198">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-198">Example: <b>application/json</b>.</span></span>|
| <span data-ttu-id="c4cee-199">再試行後</span><span class="sxs-lookup"><span data-stu-id="c4cee-199">Retry-After</span></span>| <span data-ttu-id="c4cee-200">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-200">string</span></span>| <span data-ttu-id="c4cee-201">後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-201">Instructs client to try again later in the case of an unavailable server.</span></span>|
| <span data-ttu-id="c4cee-202">異なる</span><span class="sxs-lookup"><span data-stu-id="c4cee-202">Vary</span></span>| <span data-ttu-id="c4cee-203">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-203">string</span></span>| <span data-ttu-id="c4cee-204">ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="c4cee-204">Instructs downstream proxies how to cache responses.</span></span>|

<a id="ID4ENH"></a>


## <a name="optional-response-headers"></a><span data-ttu-id="c4cee-205">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c4cee-205">Optional Response Headers</span></span>

| <span data-ttu-id="c4cee-206">Header</span><span class="sxs-lookup"><span data-stu-id="c4cee-206">Header</span></span>| <span data-ttu-id="c4cee-207">種類</span><span class="sxs-lookup"><span data-stu-id="c4cee-207">Type</span></span>| <span data-ttu-id="c4cee-208">説明</span><span class="sxs-lookup"><span data-stu-id="c4cee-208">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c4cee-209">Etag</span><span class="sxs-lookup"><span data-stu-id="c4cee-209">Etag</span></span>| <span data-ttu-id="c4cee-210">string</span><span class="sxs-lookup"><span data-stu-id="c4cee-210">string</span></span>| <span data-ttu-id="c4cee-211">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="c4cee-211">Used for cache optimization.</span></span> <span data-ttu-id="c4cee-212">以下に例を示します。"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="c4cee-212">Example: "686897696a7c876b7e".</span></span>|

<a id="ID4EOAAC"></a>


## <a name="response-body"></a><span data-ttu-id="c4cee-213">応答本文</span><span class="sxs-lookup"><span data-stu-id="c4cee-213">Response body</span></span>

<a id="ID4EUAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="c4cee-214">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="c4cee-214">Sample response</span></span>


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


## <a name="related-uris"></a><span data-ttu-id="c4cee-215">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="c4cee-215">Related URIs</span></span>

<span data-ttu-id="c4cee-216">次の URI は、このドキュメントでは、SCID を指定する追加のパス パラメーターを持つプライマリの 1 つと同じです。</span><span class="sxs-lookup"><span data-stu-id="c4cee-216">The following URI is identical to the primary one in this document, but with an extra path parameter to specify a SCID.</span></span> <span data-ttu-id="c4cee-217">その SCID のユーザーのクリップのみが返されます。</span><span class="sxs-lookup"><span data-stu-id="c4cee-217">Only that user's clips for that SCID will be returned.</span></span> <span data-ttu-id="c4cee-218">要求元のユーザーは、要求された SCID にアクセスする必要があります、それ以外の場合 HTTP エラー 403 が返されます。</span><span class="sxs-lookup"><span data-stu-id="c4cee-218">The requesting user must have access to the requested SCID, otherwise HTTP error 403 will be returned.</span></span>

   * <span data-ttu-id="c4cee-219">**/users/{ownerId}/scids/{scid}/clips**</span><span class="sxs-lookup"><span data-stu-id="c4cee-219">**/users/{ownerId}/scids/{scid}/clips**</span></span>

<a id="ID4ENBAC"></a>


## <a name="see-also"></a><span data-ttu-id="c4cee-220">関連項目</span><span class="sxs-lookup"><span data-stu-id="c4cee-220">See also</span></span>

<a id="ID4EPBAC"></a>


##### <a name="parent"></a><span data-ttu-id="c4cee-221">Parent</span><span class="sxs-lookup"><span data-stu-id="c4cee-221">Parent</span></span>

[<span data-ttu-id="c4cee-222">/users/{ownerId}/clips</span><span class="sxs-lookup"><span data-stu-id="c4cee-222">/users/{ownerId}/clips</span></span>](uri-usersowneridclips.md)
