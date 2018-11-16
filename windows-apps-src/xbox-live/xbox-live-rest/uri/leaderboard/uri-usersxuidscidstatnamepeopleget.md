---
title: GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})
assetID: 942cf0d7-f988-0495-cf28-cdac608b8109
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeopleget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: efe340b348e8547ea068018404301ed47009877b
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7111930"
---
# <a name="get-usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a><span data-ttu-id="4bae6-104">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})</span><span class="sxs-lookup"><span data-stu-id="4bae6-104">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all|favorite})</span></span>
<span data-ttu-id="4bae6-105">ランキング、統計値は、すべての既知の連絡先の現在のユーザーや、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) によって、ソーシャル ランキングを返します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-105">Returns a social leaderboard by ranking the stat values (scores) for either all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>
<span data-ttu-id="4bae6-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>

  * [<span data-ttu-id="4bae6-107">注釈</span><span class="sxs-lookup"><span data-stu-id="4bae6-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="4bae6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bae6-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="4bae6-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bae6-109">Query string parameters</span></span>](#ID4ELB)
  * [<span data-ttu-id="4bae6-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="4bae6-110">Authorization</span></span>](#ID4EQD)
  * [<span data-ttu-id="4bae6-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-111">Required Request Headers</span></span>](#ID4EGE)
  * [<span data-ttu-id="4bae6-112">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-112">Optional Request Headers</span></span>](#ID4EXF)
  * [<span data-ttu-id="4bae6-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="4bae6-113">Request body</span></span>](#ID4ETG)
  * [<span data-ttu-id="4bae6-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="4bae6-114">HTTP status codes</span></span>](#ID4ECEAC)
  * [<span data-ttu-id="4bae6-115">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-115">Required Response Headers</span></span>](#ID4E1HAC)
  * [<span data-ttu-id="4bae6-116">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-116">Optional Response Headers</span></span>](#ID4EDJAC)
  * [<span data-ttu-id="4bae6-117">応答本文</span><span class="sxs-lookup"><span data-stu-id="4bae6-117">Response body</span></span>](#ID4EDKAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="4bae6-118">注釈</span><span class="sxs-lookup"><span data-stu-id="4bae6-118">Remarks</span></span>

<span data-ttu-id="4bae6-119">ランキング Api すべて読み取り専用あり、したがってのみ (https) GET 動詞をサポートします。</span><span class="sxs-lookup"><span data-stu-id="4bae6-119">Leaderboard APIs are all read-only and therefore only support the GET verb (over HTTPS).</span></span> <span data-ttu-id="4bae6-120">ランクと並べ替えられた「ページ」インデックス付きのプレイヤーの統計データ プラットフォームによって書き込まれた個々 のユーザー統計から派生したが反映されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-120">They reflect ranked and sorted "pages" of indexed player stats that are derived from individual user stats that were written via the Data Platform.</span></span> <span data-ttu-id="4bae6-121">完全なランキングのインデックスが大きくなることができ、呼び出し元はまとまりでいずれかを確認することはありませんが求められます、したがってこの URI はそのランキングを表示する必要があるビューの種類について具体的に説明する呼び出しを許可するいくつかのクエリ文字列引数をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-121">Full leaderboard indexes can be quite large, and callers will never ask to see one in its entirety, therefore this URI supports several query string arguments that allow a caller to be specific about what kind of view it wants to see against that leaderboard.</span></span>

<span data-ttu-id="4bae6-122">これと同じ結果に 1 回または複数回実行する場合、GET 操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="4bae6-122">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="4bae6-123">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bae6-123">URI parameters</span></span>

| <span data-ttu-id="4bae6-124">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bae6-124">Parameter</span></span>| <span data-ttu-id="4bae6-125">型</span><span class="sxs-lookup"><span data-stu-id="4bae6-125">Type</span></span>| <span data-ttu-id="4bae6-126">説明</span><span class="sxs-lookup"><span data-stu-id="4bae6-126">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="4bae6-127">xuid</span><span class="sxs-lookup"><span data-stu-id="4bae6-127">xuid</span></span>| <span data-ttu-id="4bae6-128">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-128">string</span></span>| <span data-ttu-id="4bae6-129">ユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="4bae6-129">Identifier of the user.</span></span>|
| <span data-ttu-id="4bae6-130">scid</span><span class="sxs-lookup"><span data-stu-id="4bae6-130">scid</span></span>| <span data-ttu-id="4bae6-131">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-131">string</span></span>| <span data-ttu-id="4bae6-132">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="4bae6-132">Identifier of the service configuration that contains the resource being accessed.</span></span>|
| <span data-ttu-id="4bae6-133">statname</span><span class="sxs-lookup"><span data-stu-id="4bae6-133">statname</span></span>| <span data-ttu-id="4bae6-134">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-134">string</span></span>| <span data-ttu-id="4bae6-135">アクセス対象のユーザー統計リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="4bae6-135">Unique identifier of the user stat resource being accessed.</span></span>|
| <span data-ttu-id="4bae6-136">すべて</span><span class="sxs-lookup"><span data-stu-id="4bae6-136">all</span></span>|<span data-ttu-id="4bae6-137">お気に入り</span><span class="sxs-lookup"><span data-stu-id="4bae6-137">favorite</span></span>| <span data-ttu-id="4bae6-138">列挙型</span><span class="sxs-lookup"><span data-stu-id="4bae6-138">enumeration</span></span>| <span data-ttu-id="4bae6-139">現在のユーザーの既知のすべての連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) の値、統計をランク付けするかどうか。</span><span class="sxs-lookup"><span data-stu-id="4bae6-139">Whether to rank the stat values (scores) for all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>|

<a id="ID4ELB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="4bae6-140">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bae6-140">Query string parameters</span></span>

| <span data-ttu-id="4bae6-141">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bae6-141">Parameter</span></span>| <span data-ttu-id="4bae6-142">型</span><span class="sxs-lookup"><span data-stu-id="4bae6-142">Type</span></span>| <span data-ttu-id="4bae6-143">説明</span><span class="sxs-lookup"><span data-stu-id="4bae6-143">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="4bae6-144">maxItems</span><span class="sxs-lookup"><span data-stu-id="4bae6-144">maxItems</span></span>| <span data-ttu-id="4bae6-145">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="4bae6-145">32-bit unsigned integer</span></span>| <span data-ttu-id="4bae6-146">ランキング結果のページで、返されるレコードの最大数。</span><span class="sxs-lookup"><span data-stu-id="4bae6-146">Maximum number of leaderboard records to return in a page of results.</span></span> <span data-ttu-id="4bae6-147">指定しない場合、既定の数は (10) 返されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-147">If not specified, a default number will be returned (10).</span></span> <span data-ttu-id="4bae6-148">MaxItems の最大値がまだ未定義が大規模なデータ セットを回避する、ため、この値をターゲットにする必要がありますおそらく、最大呼び出しごとに UI が処理できるチューナーします。</span><span class="sxs-lookup"><span data-stu-id="4bae6-148">The max value for maxItems is still undefined, but we want to avoid large data sets, so this value should probably target the largest set that a tuner UI could handle per call.</span></span> |
| <span data-ttu-id="4bae6-149">skipToRank</span><span class="sxs-lookup"><span data-stu-id="4bae6-149">skipToRank</span></span>| <span data-ttu-id="4bae6-150">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="4bae6-150">32-bit unsigned integer</span></span>| <span data-ttu-id="4bae6-151">ページの指定のランキング順位から始まる結果を返します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-151">Return a page of results starting with the specified leaderboard rank.</span></span> <span data-ttu-id="4bae6-152">結果の残りの部分は、並べ替え順序をランク順になります。</span><span class="sxs-lookup"><span data-stu-id="4bae6-152">The rest of the results will be in sort order by rank.</span></span> <span data-ttu-id="4bae6-153">このクエリ文字列は、次の「ページ」結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-153">This query string can return a continuation token which can be fed back into a subsequent query to get "the next page" of results.</span></span> |
| <span data-ttu-id="4bae6-154">skipToUser</span><span class="sxs-lookup"><span data-stu-id="4bae6-154">skipToUser</span></span>| <span data-ttu-id="4bae6-155">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-155">string</span></span>| <span data-ttu-id="4bae6-156">ページのユーザーのランクまたはスコアに関係なく、指定されたゲーマーの xuid の周囲のランキング結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-156">Return a page of leaderboard results around the specified gamer xuid, regardless of that user's rank or score.</span></span> <span data-ttu-id="4bae6-157">ページは、定義済みのビューのページの最後の位置や統計ランキング ビューの中央で指定されたユーザーで位ランクによって並べ替えられます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-157">The page will be ordered by percentile rank with the specified user in the last position of the page for predefined views, or in the middle for stat leaderboard views.</span></span> <span data-ttu-id="4bae6-158">この種類のクエリに対して提供される<b>continuationToken</b>はありません。</span><span class="sxs-lookup"><span data-stu-id="4bae6-158">There is no <b>continuationToken</b> provided for this type of query.</span></span> |
| <span data-ttu-id="4bae6-159">continuationToken</span><span class="sxs-lookup"><span data-stu-id="4bae6-159">continuationToken</span></span>| <span data-ttu-id="4bae6-160">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-160">string</span></span>| <span data-ttu-id="4bae6-161">前の呼び出しには、 <b>continuationToken</b>が返される、呼び出し元渡すことが戻る現状有姿トークンの結果の次のページを取得するクエリ文字列で。</span><span class="sxs-lookup"><span data-stu-id="4bae6-161">If a previous call returned a <b>continuationToken</b>, then the caller can pass back that token "as is" in a query string to get the next page of results.</span></span> |
| <span data-ttu-id="4bae6-162">sort</span><span class="sxs-lookup"><span data-stu-id="4bae6-162">sort</span></span>| <span data-ttu-id="4bae6-163">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-163">string</span></span>| <span data-ttu-id="4bae6-164">高-低値 (「降順」) の順序または低-高値の順序"") からのプレイヤーの一覧をランク付けするかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-164">Specify whether to rank the list of players from low-to-high value order ("ascending") or high-to-low value order ("descending").</span></span> <span data-ttu-id="4bae6-165">これは、オプションのパラメーターです。既定値は降順です。</span><span class="sxs-lookup"><span data-stu-id="4bae6-165">This is an optional parameter; the default is descending order.</span></span>|

<a id="ID4EQD"></a>


## <a name="authorization"></a><span data-ttu-id="4bae6-166">Authorization</span><span class="sxs-lookup"><span data-stu-id="4bae6-166">Authorization</span></span>

<span data-ttu-id="4bae6-167">Xuid の承認が必要です。</span><span class="sxs-lookup"><span data-stu-id="4bae6-167">Xuid authorization is required.</span></span>

<span data-ttu-id="4bae6-168">コンテンツの分離とアクセス制御のシナリオの目的上、承認ロジックが実装されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-168">Authorization logic is implemented for the purposes of content isolation and access control scenarios.</span></span>

<span data-ttu-id="4bae6-169">ランキング、およびユーザーの両方の統計は、呼び出し元が有効な XSTS トークンは要求を送信すること、任意のプラットフォーム上のクライアントから読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-169">Both leaderboards and user stats can be read from clients on any platform, provided that the caller submits a valid XSTS token with their request.</span></span> <span data-ttu-id="4bae6-170">書き込みは、(当然ながら)、データ プラットフォームでサポートされているクライアントに制限されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-170">Writes are (obviously) limited to clients supported by the Data Platform.</span></span>

<span data-ttu-id="4bae6-171">タイトル デベロッパーは、open または XDP またはパートナー センターで制限付きの統計情報をマークできます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-171">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="4bae6-172">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="4bae6-172">Leaderboards are open statistics.</span></span> <span data-ttu-id="4bae6-173">開いている統計情報は、サンド ボックスに、ユーザーが許可されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-173">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="4bae6-174">サンド ボックスへのユーザーの承認は XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-174">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>

<a id="ID4EGE"></a>


## <a name="required-request-headers"></a><span data-ttu-id="4bae6-175">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-175">Required Request Headers</span></span>

| <span data-ttu-id="4bae6-176">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-176">Header</span></span>| <span data-ttu-id="4bae6-177">説明</span><span class="sxs-lookup"><span data-stu-id="4bae6-177">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="4bae6-178">Authorization</span><span class="sxs-lookup"><span data-stu-id="4bae6-178">Authorization</span></span>| <span data-ttu-id="4bae6-179">[String]。</span><span class="sxs-lookup"><span data-stu-id="4bae6-179">String.</span></span> <span data-ttu-id="4bae6-180">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-180">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="4bae6-181">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="4bae6-181">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="4bae6-182">Content-Type</span><span class="sxs-lookup"><span data-stu-id="4bae6-182">Content-Type</span></span>| <span data-ttu-id="4bae6-183">[String]。</span><span class="sxs-lookup"><span data-stu-id="4bae6-183">String.</span></span> <span data-ttu-id="4bae6-184">要求本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="4bae6-184">The MIME type of the request body.</span></span> <span data-ttu-id="4bae6-185">値の例:"アプリケーション/json"。</span><span class="sxs-lookup"><span data-stu-id="4bae6-185">Example value: "application/json".</span></span>|
| <span data-ttu-id="4bae6-186">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="4bae6-186">X-RequestedServiceVersion</span></span>| <span data-ttu-id="4bae6-187">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="4bae6-187">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="4bae6-188">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="4bae6-188">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="4bae6-189">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="4bae6-189">Default value: 1.</span></span>|
| <span data-ttu-id="4bae6-190">Accept</span><span class="sxs-lookup"><span data-stu-id="4bae6-190">Accept</span></span>| <span data-ttu-id="4bae6-191">[String]。</span><span class="sxs-lookup"><span data-stu-id="4bae6-191">String.</span></span> <span data-ttu-id="4bae6-192">利用可能なコンテンツの種類の値。</span><span class="sxs-lookup"><span data-stu-id="4bae6-192">Acceptable Content-Type values.</span></span> <span data-ttu-id="4bae6-193">値の例:"アプリケーション/json"。</span><span class="sxs-lookup"><span data-stu-id="4bae6-193">Example value: "application/json".</span></span>|

<a id="ID4EXF"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="4bae6-194">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-194">Optional Request Headers</span></span>

| <span data-ttu-id="4bae6-195">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-195">Header</span></span>| <span data-ttu-id="4bae6-196">説明</span><span class="sxs-lookup"><span data-stu-id="4bae6-196">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="4bae6-197">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="4bae6-197">If-None-Match</span></span>| <span data-ttu-id="4bae6-198">[String]。</span><span class="sxs-lookup"><span data-stu-id="4bae6-198">String.</span></span> <span data-ttu-id="4bae6-199">エンティティ タグのクライアントでは、キャッシュがサポートされる場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-199">Entity tag - used if client supports caching.</span></span> <span data-ttu-id="4bae6-200">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="4bae6-200">Example value: "686897696a7c876b7e".</span></span>|

<a id="ID4ETG"></a>


## <a name="request-body"></a><span data-ttu-id="4bae6-201">要求本文</span><span class="sxs-lookup"><span data-stu-id="4bae6-201">Request body</span></span>

<span data-ttu-id="4bae6-202">する必要がありますが表示され、accept 言語で指定されたロケールに一致するフォーマットの形式の文字列として適切な表示のもう一度取得データを理解する任意の呼び出し元の機能を最大限には、ユーザーごとに各統計値が返されます要求ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="4bae6-202">To maximize the ability of any caller to understand the data it's getting back for proper display, each stat value for each user will be returned as a string in the format in which it should be displayed, and formatted to match the locale specified in the accept-language header in the request.</span></span> <span data-ttu-id="4bae6-203">ローカライズされた「表示名」は、そのランキングの statname の返されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-203">A localized "display name" will also be returned for statname for that leaderboard.</span></span>

<a id="ID4E2G"></a>


### <a name="required-members"></a><span data-ttu-id="4bae6-204">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="4bae6-204">Required members</span></span>

| <span data-ttu-id="4bae6-205">メンバー</span><span class="sxs-lookup"><span data-stu-id="4bae6-205">Member</span></span>| <span data-ttu-id="4bae6-206">説明</span><span class="sxs-lookup"><span data-stu-id="4bae6-206">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <b><span data-ttu-id="4bae6-207">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="4bae6-207">pagingInfo</span></span></b>| <span data-ttu-id="4bae6-208">セクション</span><span class="sxs-lookup"><span data-stu-id="4bae6-208">section</span></span>| <span data-ttu-id="4bae6-209">省略可能。</span><span class="sxs-lookup"><span data-stu-id="4bae6-209">Optional.</span></span> <span data-ttu-id="4bae6-210">ページの最後のエントリのランクが totalItems よりも小さい場合に返されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-210">Returned when the rank of the last entry in the page is lower than totalItems.</span></span> <span data-ttu-id="4bae6-211">このセクションもいないときに返される skipToUser は要求で指定されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-211">This section is also not returned when skipToUser is specified in the request.</span></span>|
| <span data-ttu-id="4bae6-212">continuationToken</span><span class="sxs-lookup"><span data-stu-id="4bae6-212">continuationToken</span></span>| <span data-ttu-id="4bae6-213">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-213">string</span></span>| <span data-ttu-id="4bae6-214">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-214">Required.</span></span> <span data-ttu-id="4bae6-215">必要な場合は、その URI の結果の次のページを取得するのに"continuationToken"のクエリ パラメーターにフィードバックする値を指定します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-215">Specifies what value to feed back into the "continuationToken" query parameter to get next page of results for that URI if desired.</span></span> <span data-ttu-id="4bae6-216">PagingInfo が返されない場合は、なし「の次のページ」データを取得できます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-216">If no pagingInfo is returned then there is no "next page" of data to be obtained.</span></span>|
| <span data-ttu-id="4bae6-217">totalItems</span><span class="sxs-lookup"><span data-stu-id="4bae6-217">totalItems</span></span>| <span data-ttu-id="4bae6-218">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="4bae6-218">64-bit unsigned integer</span></span>| <span data-ttu-id="4bae6-219">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-219">Required.</span></span> <span data-ttu-id="4bae6-220">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="4bae6-220">Total number of entries in the leaderboard.</span></span>|
| <b><span data-ttu-id="4bae6-221">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="4bae6-221">leaderboardInfo</span></span></b>| <span data-ttu-id="4bae6-222">セクション</span><span class="sxs-lookup"><span data-stu-id="4bae6-222">section</span></span>| <span data-ttu-id="4bae6-223">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-223">Required.</span></span> <span data-ttu-id="4bae6-224">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-224">Always returned.</span></span> <span data-ttu-id="4bae6-225">要求されたランキングに関するメタデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-225">Contains the metadata about the leaderboard requested.</span></span>|
| <span data-ttu-id="4bae6-226">displayName</span><span class="sxs-lookup"><span data-stu-id="4bae6-226">displayName</span></span>| <span data-ttu-id="4bae6-227">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-227">string</span></span>| <span data-ttu-id="4bae6-228">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-228">Required.</span></span> <span data-ttu-id="4bae6-229">定義済みのランキングのローカライズされた表示名。</span><span class="sxs-lookup"><span data-stu-id="4bae6-229">Localized display name for the predefined leaderboard.</span></span> <span data-ttu-id="4bae6-230">値の例:「キャプチャ フラグの合計」。</span><span class="sxs-lookup"><span data-stu-id="4bae6-230">Example value: "Total flags captured".</span></span>|
| <span data-ttu-id="4bae6-231">totalCount</span><span class="sxs-lookup"><span data-stu-id="4bae6-231">totalCount</span></span>| <span data-ttu-id="4bae6-232">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-232">string</span></span>| <span data-ttu-id="4bae6-233">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-233">Required.</span></span> <span data-ttu-id="4bae6-234">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="4bae6-234">Total number of entries in the leaderboard.</span></span>|
| <span data-ttu-id="4bae6-235">列</span><span class="sxs-lookup"><span data-stu-id="4bae6-235">columns</span></span>| <span data-ttu-id="4bae6-236">array</span><span class="sxs-lookup"><span data-stu-id="4bae6-236">array</span></span>| <span data-ttu-id="4bae6-237">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-237">Required.</span></span>|
| <span data-ttu-id="4bae6-238">displayName</span><span class="sxs-lookup"><span data-stu-id="4bae6-238">displayName</span></span>| <span data-ttu-id="4bae6-239">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-239">string</span></span>| <span data-ttu-id="4bae6-240">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-240">Required.</span></span> <span data-ttu-id="4bae6-241">ランキングの列に対応しています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-241">Corresponds to a column in the leaderboard.</span></span>|
| <span data-ttu-id="4bae6-242">statName</span><span class="sxs-lookup"><span data-stu-id="4bae6-242">statName</span></span>| <span data-ttu-id="4bae6-243">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-243">string</span></span>| <span data-ttu-id="4bae6-244">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-244">Required.</span></span> <span data-ttu-id="4bae6-245">ランキングの列に対応しています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-245">Corresponds to a column in the leaderboard.</span></span>|
| <span data-ttu-id="4bae6-246">type</span><span class="sxs-lookup"><span data-stu-id="4bae6-246">type</span></span>| <span data-ttu-id="4bae6-247">文字列</span><span class="sxs-lookup"><span data-stu-id="4bae6-247">string</span></span>| <span data-ttu-id="4bae6-248">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-248">Required.</span></span> <span data-ttu-id="4bae6-249">ランキングの列に対応しています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-249">Corresponds to a column in the leaderboard.</span></span>|
| <b><span data-ttu-id="4bae6-250">userList</span><span class="sxs-lookup"><span data-stu-id="4bae6-250">userList</span></span></b>| <span data-ttu-id="4bae6-251">セクション</span><span class="sxs-lookup"><span data-stu-id="4bae6-251">section</span></span>| <span data-ttu-id="4bae6-252">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-252">Required.</span></span> <span data-ttu-id="4bae6-253">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="4bae6-253">Always returned.</span></span> <span data-ttu-id="4bae6-254">要求されたランキングの実際のユーザーのスコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-254">Contains the actual user scores for the leaderboard requested.</span></span>|
| <span data-ttu-id="4bae6-255">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="4bae6-255">gamertag</span></span>| <span data-ttu-id="4bae6-256">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-256">string</span></span>| <span data-ttu-id="4bae6-257">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-257">Required.</span></span> <span data-ttu-id="4bae6-258">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-258">Corresponds to the user in the leaderboard entry.</span></span>|
| <span data-ttu-id="4bae6-259">xuid</span><span class="sxs-lookup"><span data-stu-id="4bae6-259">xuid</span></span>| <span data-ttu-id="4bae6-260">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="4bae6-260">32-bit signed integer</span></span>| <span data-ttu-id="4bae6-261">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-261">Required.</span></span> <span data-ttu-id="4bae6-262">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-262">Corresponds to the user in the leaderboard entry.</span></span>|
| <span data-ttu-id="4bae6-263">位</span><span class="sxs-lookup"><span data-stu-id="4bae6-263">percentile</span></span>| <span data-ttu-id="4bae6-264">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-264">string</span></span>| <span data-ttu-id="4bae6-265">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-265">Required.</span></span> <span data-ttu-id="4bae6-266">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-266">Corresponds to the user in the leaderboard entry.</span></span>|
| <span data-ttu-id="4bae6-267">ランク</span><span class="sxs-lookup"><span data-stu-id="4bae6-267">rank</span></span>| <span data-ttu-id="4bae6-268">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-268">string</span></span>| <span data-ttu-id="4bae6-269">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-269">Required.</span></span> <span data-ttu-id="4bae6-270">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="4bae6-270">Corresponds to the user in the leaderboard entry.</span></span>|
| <span data-ttu-id="4bae6-271">値</span><span class="sxs-lookup"><span data-stu-id="4bae6-271">values</span></span>| <span data-ttu-id="4bae6-272">array</span><span class="sxs-lookup"><span data-stu-id="4bae6-272">array</span></span>| <span data-ttu-id="4bae6-273">必須。</span><span class="sxs-lookup"><span data-stu-id="4bae6-273">Required.</span></span> <span data-ttu-id="4bae6-274">それぞれのコンマ区切り値は、ランキングの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-274">Each comma-separated value corresponds to a column in the leaderboard.</span></span>|

<a id="ID4ECEAC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="4bae6-275">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="4bae6-275">HTTP status codes</span></span>

<span data-ttu-id="4bae6-276">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-276">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="4bae6-277">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4bae6-277">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="4bae6-278">コード</span><span class="sxs-lookup"><span data-stu-id="4bae6-278">Code</span></span>| <span data-ttu-id="4bae6-279">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="4bae6-279">Reason phrase</span></span>| <span data-ttu-id="4bae6-280">説明</span><span class="sxs-lookup"><span data-stu-id="4bae6-280">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="4bae6-281">200</span><span class="sxs-lookup"><span data-stu-id="4bae6-281">200</span></span>| <span data-ttu-id="4bae6-282">OK</span><span class="sxs-lookup"><span data-stu-id="4bae6-282">OK</span></span>| <span data-ttu-id="4bae6-283">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="4bae6-283">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="4bae6-284">304</span><span class="sxs-lookup"><span data-stu-id="4bae6-284">304</span></span>| <span data-ttu-id="4bae6-285">Not Modified</span><span class="sxs-lookup"><span data-stu-id="4bae6-285">Not Modified</span></span>|  |
| <span data-ttu-id="4bae6-286">400</span><span class="sxs-lookup"><span data-stu-id="4bae6-286">400</span></span>| <span data-ttu-id="4bae6-287">Bad Request</span><span class="sxs-lookup"><span data-stu-id="4bae6-287">Bad Request</span></span>| | <span data-ttu-id="4bae6-288">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4bae6-288">Service could not understand malformed request.</span></span> <span data-ttu-id="4bae6-289">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="4bae6-289">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="4bae6-290">401</span><span class="sxs-lookup"><span data-stu-id="4bae6-290">401</span></span>| <span data-ttu-id="4bae6-291">権限がありません</span><span class="sxs-lookup"><span data-stu-id="4bae6-291">Unauthorized</span></span>| | <span data-ttu-id="4bae6-292">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="4bae6-292">The request requires user authentication.</span></span>|
| <span data-ttu-id="4bae6-293">403</span><span class="sxs-lookup"><span data-stu-id="4bae6-293">403</span></span>| <span data-ttu-id="4bae6-294">Forbidden</span><span class="sxs-lookup"><span data-stu-id="4bae6-294">Forbidden</span></span>| <span data-ttu-id="4bae6-295">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="4bae6-295">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="4bae6-296">404</span><span class="sxs-lookup"><span data-stu-id="4bae6-296">404</span></span>| <span data-ttu-id="4bae6-297">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-297">Not Found</span></span>| <span data-ttu-id="4bae6-298">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="4bae6-298">The specified resource could not be found.</span></span>|
| <span data-ttu-id="4bae6-299">406</span><span class="sxs-lookup"><span data-stu-id="4bae6-299">406</span></span>| <span data-ttu-id="4bae6-300">許容できません。</span><span class="sxs-lookup"><span data-stu-id="4bae6-300">Not Acceptable</span></span>| <span data-ttu-id="4bae6-301">リソースのバージョンがサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4bae6-301">Resource version is not supported; should be rejected by the MVC layer.</span></span>|
| <span data-ttu-id="4bae6-302">408</span><span class="sxs-lookup"><span data-stu-id="4bae6-302">408</span></span>| <span data-ttu-id="4bae6-303">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="4bae6-303">Request Timeout</span></span>| <span data-ttu-id="4bae6-304">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4bae6-304">Service could not understand malformed request.</span></span> <span data-ttu-id="4bae6-305">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="4bae6-305">Typically an invalid parameter.</span></span>|

<a id="ID4E1HAC"></a>


## <a name="required-response-headers"></a><span data-ttu-id="4bae6-306">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-306">Required Response Headers</span></span>

| <span data-ttu-id="4bae6-307">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-307">Header</span></span>| <span data-ttu-id="4bae6-308">型</span><span class="sxs-lookup"><span data-stu-id="4bae6-308">Type</span></span>| <span data-ttu-id="4bae6-309">説明</span><span class="sxs-lookup"><span data-stu-id="4bae6-309">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="4bae6-310">Content-Type</span><span class="sxs-lookup"><span data-stu-id="4bae6-310">Content-Type</span></span>| <span data-ttu-id="4bae6-311">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-311">string</span></span>| <span data-ttu-id="4bae6-312">応答の本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="4bae6-312">The mime type of the body of the response.</span></span> <span data-ttu-id="4bae6-313">値の例:"アプリケーション/json"。</span><span class="sxs-lookup"><span data-stu-id="4bae6-313">Example values: "application/json".</span></span>|
| <span data-ttu-id="4bae6-314">Content-Length</span><span class="sxs-lookup"><span data-stu-id="4bae6-314">Content-Length</span></span>| <span data-ttu-id="4bae6-315">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-315">string</span></span>| <span data-ttu-id="4bae6-316">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="4bae6-316">The number of bytes being sent in the response.</span></span> <span data-ttu-id="4bae6-317">値の例:「232」。</span><span class="sxs-lookup"><span data-stu-id="4bae6-317">Example value: "232".</span></span>|

<a id="ID4EDJAC"></a>


## <a name="optional-response-headers"></a><span data-ttu-id="4bae6-318">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-318">Optional Response Headers</span></span>

| <span data-ttu-id="4bae6-319">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bae6-319">Header</span></span>| <span data-ttu-id="4bae6-320">型</span><span class="sxs-lookup"><span data-stu-id="4bae6-320">Type</span></span>| <span data-ttu-id="4bae6-321">説明</span><span class="sxs-lookup"><span data-stu-id="4bae6-321">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="4bae6-322">ETag</span><span class="sxs-lookup"><span data-stu-id="4bae6-322">ETag</span></span>| <span data-ttu-id="4bae6-323">string</span><span class="sxs-lookup"><span data-stu-id="4bae6-323">string</span></span>| <span data-ttu-id="4bae6-324">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="4bae6-324">Used for cache optimization.</span></span> <span data-ttu-id="4bae6-325">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="4bae6-325">Example value: "686897696a7c876b7e".</span></span>|

<a id="ID4EDKAC"></a>


## <a name="response-body"></a><span data-ttu-id="4bae6-326">応答本文</span><span class="sxs-lookup"><span data-stu-id="4bae6-326">Response body</span></span>

<span data-ttu-id="4bae6-327">要求のソーシャル ランキング、ないページング:</span><span class="sxs-lookup"><span data-stu-id="4bae6-327">Request for social leaderboard, no paging:</span></span>

https://leaderboards.xboxlive.com/users/xuid(2533274916402282)/scids/c1ba92a9-0000-0000-0000-000000000000/stats/EnemyDefeats/people/all?sort=descending

<a id="ID4ENKAC"></a>


### <a name="sample-response"></a><span data-ttu-id="4bae6-328">応答の例</span><span class="sxs-lookup"><span data-stu-id="4bae6-328">Sample response</span></span>


```cpp
{
    "pagingInfo": null,
    "leaderboardInfo": {
        "displayName": "Kills",
        "totalCount": 3,
        "columns": [
            {
                "displayName": "Kills",
                "statName": "enemydefeats",
                "type": "integer"
            }
        ]
    },
    "userList": [
        {
            "gamertag":"xxxSniper39",
            "xuid":"1234567890123555",
            "percentile":1.0,
            "rank":1,
            "values": [
                "47"
            ]
        },
        {
            "gamertag":"WarriorSaint",
            "xuid":"2533274916402282",
            "percentile":0.66,
            "rank":2,
            "values": [
                "42"
            ]
        },
        {
            "gamertag":"WhockaWhocka",
            "xuid":"1234567890123666",
            "percentile":0.33,
            "rank":3,
            "values": [
                "12"
            ]
        }
    ]
}

```


<a id="ID4EXKAC"></a>


## <a name="see-also"></a><span data-ttu-id="4bae6-329">関連項目</span><span class="sxs-lookup"><span data-stu-id="4bae6-329">See also</span></span>

<a id="ID4EZKAC"></a>


##### <a name="parent"></a><span data-ttu-id="4bae6-330">Parent</span><span class="sxs-lookup"><span data-stu-id="4bae6-330">Parent</span></span>

[<span data-ttu-id="4bae6-331">ユーザー/xuid ({xuid})/scids/{scid}/stats/{statname)/people/{all\ | favorite}</span><span class="sxs-lookup"><span data-stu-id="4bae6-331">/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite}</span></span>](uri-usersxuidscidstatnamepeople.md)
