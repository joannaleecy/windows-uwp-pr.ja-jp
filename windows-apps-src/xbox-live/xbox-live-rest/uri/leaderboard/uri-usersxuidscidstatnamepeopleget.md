---
title: GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})
assetID: 942cf0d7-f988-0495-cf28-cdac608b8109
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeopleget.html
description: " GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 674e52d15d115560d4813edcd9687c2fe9694c9b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650767"
---
# <a name="get-usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a><span data-ttu-id="0a7d1-104">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})</span><span class="sxs-lookup"><span data-stu-id="0a7d1-104">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all|favorite})</span></span>
<span data-ttu-id="0a7d1-105">順位付け、stat かすべての既知の連絡先、現在のユーザーまたはユーザーのお気に入りとしてそのユーザーによって指定された連絡先のみ (スコア) の値では、ソーシャル ランキングを返します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-105">Returns a social leaderboard by ranking the stat values (scores) for either all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>
<span data-ttu-id="0a7d1-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>

  * [<span data-ttu-id="0a7d1-107">注釈</span><span class="sxs-lookup"><span data-stu-id="0a7d1-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="0a7d1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0a7d1-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="0a7d1-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="0a7d1-109">Query string parameters</span></span>](#ID4ELB)
  * [<span data-ttu-id="0a7d1-110">承認</span><span class="sxs-lookup"><span data-stu-id="0a7d1-110">Authorization</span></span>](#ID4EQD)
  * [<span data-ttu-id="0a7d1-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-111">Required Request Headers</span></span>](#ID4EGE)
  * [<span data-ttu-id="0a7d1-112">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-112">Optional Request Headers</span></span>](#ID4EXF)
  * [<span data-ttu-id="0a7d1-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="0a7d1-113">Request body</span></span>](#ID4ETG)
  * [<span data-ttu-id="0a7d1-114">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="0a7d1-114">HTTP status codes</span></span>](#ID4ECEAC)
  * [<span data-ttu-id="0a7d1-115">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-115">Required Response Headers</span></span>](#ID4E1HAC)
  * [<span data-ttu-id="0a7d1-116">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-116">Optional Response Headers</span></span>](#ID4EDJAC)
  * [<span data-ttu-id="0a7d1-117">応答本文</span><span class="sxs-lookup"><span data-stu-id="0a7d1-117">Response body</span></span>](#ID4EDKAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="0a7d1-118">注釈</span><span class="sxs-lookup"><span data-stu-id="0a7d1-118">Remarks</span></span>

<span data-ttu-id="0a7d1-119">ランキング Api はすべて読み取り専用し、したがってのみ (HTTPS) 経由で GET 動詞をサポートします。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-119">Leaderboard APIs are all read-only and therefore only support the GET verb (over HTTPS).</span></span> <span data-ttu-id="0a7d1-120">ランクと並べ替え済みの「ページ」データ プラットフォームを使用して記述されている個々 のユーザーの統計から派生した統計をインデックス付きのプレーヤーが反映されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-120">They reflect ranked and sorted "pages" of indexed player stats that are derived from individual user stats that were written via the Data Platform.</span></span> <span data-ttu-id="0a7d1-121">ランキングの完全なインデックスが大きくなることができ、全体のいずれかを確認する呼び出し元が今後は、この URI がそのためにそのランキングに対して表示するビューの種類は呼び出し元を許可するいくつかのクエリ文字列引数をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-121">Full leaderboard indexes can be quite large, and callers will never ask to see one in its entirety, therefore this URI supports several query string arguments that allow a caller to be specific about what kind of view it wants to see against that leaderboard.</span></span>

<span data-ttu-id="0a7d1-122">GET 操作は、この 1 回または複数回実行された場合、同じ結果が生成されますのですべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-122">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="0a7d1-123">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0a7d1-123">URI parameters</span></span>

| <span data-ttu-id="0a7d1-124">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0a7d1-124">Parameter</span></span>| <span data-ttu-id="0a7d1-125">種類</span><span class="sxs-lookup"><span data-stu-id="0a7d1-125">Type</span></span>| <span data-ttu-id="0a7d1-126">説明</span><span class="sxs-lookup"><span data-stu-id="0a7d1-126">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="0a7d1-127">xuid</span><span class="sxs-lookup"><span data-stu-id="0a7d1-127">xuid</span></span>| <span data-ttu-id="0a7d1-128">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-128">string</span></span>| <span data-ttu-id="0a7d1-129">ユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-129">Identifier of the user.</span></span>|
| <span data-ttu-id="0a7d1-130">scid</span><span class="sxs-lookup"><span data-stu-id="0a7d1-130">scid</span></span>| <span data-ttu-id="0a7d1-131">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-131">string</span></span>| <span data-ttu-id="0a7d1-132">アクセスされるリソースを含むサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-132">Identifier of the service configuration that contains the resource being accessed.</span></span>|
| <span data-ttu-id="0a7d1-133">statname</span><span class="sxs-lookup"><span data-stu-id="0a7d1-133">statname</span></span>| <span data-ttu-id="0a7d1-134">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-134">string</span></span>| <span data-ttu-id="0a7d1-135">アクセスされているユーザーの統計リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-135">Unique identifier of the user stat resource being accessed.</span></span>|
| <span data-ttu-id="0a7d1-136">all</span><span class="sxs-lookup"><span data-stu-id="0a7d1-136">all</span></span>|<span data-ttu-id="0a7d1-137">お気に入り</span><span class="sxs-lookup"><span data-stu-id="0a7d1-137">favorite</span></span>| <span data-ttu-id="0a7d1-138">列挙</span><span class="sxs-lookup"><span data-stu-id="0a7d1-138">enumeration</span></span>| <span data-ttu-id="0a7d1-139">現在のユーザーのすべての既知の連絡先またはお気に入りのユーザーとしてそのユーザーによって指定された連絡先のみ (スコア) の値、stat をランク付けするかどうか。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-139">Whether to rank the stat values (scores) for all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>|

<a id="ID4ELB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="0a7d1-140">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="0a7d1-140">Query string parameters</span></span>

| <span data-ttu-id="0a7d1-141">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0a7d1-141">Parameter</span></span>| <span data-ttu-id="0a7d1-142">種類</span><span class="sxs-lookup"><span data-stu-id="0a7d1-142">Type</span></span>| <span data-ttu-id="0a7d1-143">説明</span><span class="sxs-lookup"><span data-stu-id="0a7d1-143">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="0a7d1-144">maxItems</span><span class="sxs-lookup"><span data-stu-id="0a7d1-144">maxItems</span></span>| <span data-ttu-id="0a7d1-145">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="0a7d1-145">32-bit unsigned integer</span></span>| <span data-ttu-id="0a7d1-146">ランキング ページの結果で返されるレコードの最大数。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-146">Maximum number of leaderboard records to return in a page of results.</span></span> <span data-ttu-id="0a7d1-147">指定されていない場合、既定の数には、(10) が返されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-147">If not specified, a default number will be returned (10).</span></span> <span data-ttu-id="0a7d1-148">MaxItems の最大値は、まだ未定義が大規模なデータ セットを回避する、ため、この値が対象おそらく最大呼び出しごとに UI が処理できるチューナーします。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-148">The max value for maxItems is still undefined, but we want to avoid large data sets, so this value should probably target the largest set that a tuner UI could handle per call.</span></span> |
| <span data-ttu-id="0a7d1-149">skipToRank</span><span class="sxs-lookup"><span data-stu-id="0a7d1-149">skipToRank</span></span>| <span data-ttu-id="0a7d1-150">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="0a7d1-150">32-bit unsigned integer</span></span>| <span data-ttu-id="0a7d1-151">以降では、指定したランキング ランクの結果のページを返します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-151">Return a page of results starting with the specified leaderboard rank.</span></span> <span data-ttu-id="0a7d1-152">残りの結果を順位で並べ替え順序になります。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-152">The rest of the results will be in sort order by rank.</span></span> <span data-ttu-id="0a7d1-153">このクエリ文字列は、[次へ] の「ページ」の結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-153">This query string can return a continuation token which can be fed back into a subsequent query to get "the next page" of results.</span></span> |
| <span data-ttu-id="0a7d1-154">skipToUser</span><span class="sxs-lookup"><span data-stu-id="0a7d1-154">skipToUser</span></span>| <span data-ttu-id="0a7d1-155">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-155">string</span></span>| <span data-ttu-id="0a7d1-156">そのユーザーのランクやスコアに関係なく、指定のゲーマー xuid の周囲のスコアボードの結果のページを返します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-156">Return a page of leaderboard results around the specified gamer xuid, regardless of that user's rank or score.</span></span> <span data-ttu-id="0a7d1-157">ページは、stat ランキング ビューの中央にまたは定義済みのビューのページの最後の位置で指定したユーザーのパーセン タイル順位で並べ替えられます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-157">The page will be ordered by percentile rank with the specified user in the last position of the page for predefined views, or in the middle for stat leaderboard views.</span></span> <span data-ttu-id="0a7d1-158">あるない<b>continuationToken</b>この種類のクエリを提供します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-158">There is no <b>continuationToken</b> provided for this type of query.</span></span> |
| <span data-ttu-id="0a7d1-159">continuationToken</span><span class="sxs-lookup"><span data-stu-id="0a7d1-159">continuationToken</span></span>| <span data-ttu-id="0a7d1-160">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-160">string</span></span>| <span data-ttu-id="0a7d1-161">前の呼び出しが返された場合、 <b>continuationToken</b>、呼び出し元返すことができるそのトークンを"現状有姿の結果の次のページを取得するクエリ文字列にし、します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-161">If a previous call returned a <b>continuationToken</b>, then the caller can pass back that token "as is" in a query string to get the next page of results.</span></span> |
| <span data-ttu-id="0a7d1-162">sort</span><span class="sxs-lookup"><span data-stu-id="0a7d1-162">sort</span></span>| <span data-ttu-id="0a7d1-163">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-163">string</span></span>| <span data-ttu-id="0a7d1-164">低-高の値の順序 (「昇順」) からの選手の一覧をランク付けするかどうかを指定するか、高から低値の順序 ("descending")。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-164">Specify whether to rank the list of players from low-to-high value order ("ascending") or high-to-low value order ("descending").</span></span> <span data-ttu-id="0a7d1-165">これは省略可能なパラメーターです。既定値は降順です。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-165">This is an optional parameter; the default is descending order.</span></span>|

<a id="ID4EQD"></a>


## <a name="authorization"></a><span data-ttu-id="0a7d1-166">Authorization</span><span class="sxs-lookup"><span data-stu-id="0a7d1-166">Authorization</span></span>

<span data-ttu-id="0a7d1-167">Xuid 承認が必要です。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-167">Xuid authorization is required.</span></span>

<span data-ttu-id="0a7d1-168">承認ロジックは、コンテンツの分離とアクセス制御のシナリオの目的で実装されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-168">Authorization logic is implemented for the purposes of content isolation and access control scenarios.</span></span>

<span data-ttu-id="0a7d1-169">呼び出し元の要求で有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングとユーザーの両方の統計情報を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-169">Both leaderboards and user stats can be read from clients on any platform, provided that the caller submits a valid XSTS token with their request.</span></span> <span data-ttu-id="0a7d1-170">書き込みは、例のように、データ プラットフォームでサポートされているクライアントに制限されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-170">Writes are (obviously) limited to clients supported by the Data Platform.</span></span>

<span data-ttu-id="0a7d1-171">タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-171">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="0a7d1-172">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-172">Leaderboards are open statistics.</span></span> <span data-ttu-id="0a7d1-173">統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-173">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="0a7d1-174">サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-174">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>

<a id="ID4EGE"></a>


## <a name="required-request-headers"></a><span data-ttu-id="0a7d1-175">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-175">Required Request Headers</span></span>

| <span data-ttu-id="0a7d1-176">Header</span><span class="sxs-lookup"><span data-stu-id="0a7d1-176">Header</span></span>| <span data-ttu-id="0a7d1-177">説明</span><span class="sxs-lookup"><span data-stu-id="0a7d1-177">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="0a7d1-178">Authorization</span><span class="sxs-lookup"><span data-stu-id="0a7d1-178">Authorization</span></span>| <span data-ttu-id="0a7d1-179">[String]。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-179">String.</span></span> <span data-ttu-id="0a7d1-180">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-180">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="0a7d1-181">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-181">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="0a7d1-182">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0a7d1-182">Content-Type</span></span>| <span data-ttu-id="0a7d1-183">[String]。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-183">String.</span></span> <span data-ttu-id="0a7d1-184">要求本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-184">The MIME type of the request body.</span></span> <span data-ttu-id="0a7d1-185">値の例:"application/json"。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-185">Example value: "application/json".</span></span>|
| <span data-ttu-id="0a7d1-186">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="0a7d1-186">X-RequestedServiceVersion</span></span>| <span data-ttu-id="0a7d1-187">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-187">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="0a7d1-188">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-188">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="0a7d1-189">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="0a7d1-189">Default value: 1.</span></span>|
| <span data-ttu-id="0a7d1-190">OK</span><span class="sxs-lookup"><span data-stu-id="0a7d1-190">Accept</span></span>| <span data-ttu-id="0a7d1-191">[String]。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-191">String.</span></span> <span data-ttu-id="0a7d1-192">使用できるコンテンツの種類の値。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-192">Acceptable Content-Type values.</span></span> <span data-ttu-id="0a7d1-193">値の例:"application/json"。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-193">Example value: "application/json".</span></span>|

<a id="ID4EXF"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="0a7d1-194">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-194">Optional Request Headers</span></span>

| <span data-ttu-id="0a7d1-195">Header</span><span class="sxs-lookup"><span data-stu-id="0a7d1-195">Header</span></span>| <span data-ttu-id="0a7d1-196">説明</span><span class="sxs-lookup"><span data-stu-id="0a7d1-196">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="0a7d1-197">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="0a7d1-197">If-None-Match</span></span>| <span data-ttu-id="0a7d1-198">[String]。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-198">String.</span></span> <span data-ttu-id="0a7d1-199">エンティティ タグ - クライアントのキャッシュをサポートしている場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-199">Entity tag - used if client supports caching.</span></span> <span data-ttu-id="0a7d1-200">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-200">Example value: "686897696a7c876b7e".</span></span>|

<a id="ID4ETG"></a>


## <a name="request-body"></a><span data-ttu-id="0a7d1-201">要求本文</span><span class="sxs-lookup"><span data-stu-id="0a7d1-201">Request body</span></span>

<span data-ttu-id="0a7d1-202">する必要がありますを表示、および accept language で指定されたロケールに一致するフォーマット形式の文字列として呼び出し元の適切な表示に戻す、データを理解する機能を最大化するには、各ユーザーの各統計値が返されます要求のヘッダー。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-202">To maximize the ability of any caller to understand the data it's getting back for proper display, each stat value for each user will be returned as a string in the format in which it should be displayed, and formatted to match the locale specified in the accept-language header in the request.</span></span> <span data-ttu-id="0a7d1-203">ローカライズされた「表示名」は、そのランキングの statname に返されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-203">A localized "display name" will also be returned for statname for that leaderboard.</span></span>

<a id="ID4E2G"></a>


### <a name="required-members"></a><span data-ttu-id="0a7d1-204">必須メンバー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-204">Required members</span></span>

| <span data-ttu-id="0a7d1-205">メンバー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-205">Member</span></span>| <span data-ttu-id="0a7d1-206">説明</span><span class="sxs-lookup"><span data-stu-id="0a7d1-206">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="0a7d1-207"><b>pagingInfo</b></span><span class="sxs-lookup"><span data-stu-id="0a7d1-207"><b>pagingInfo</b></span></span>| <span data-ttu-id="0a7d1-208">セクション</span><span class="sxs-lookup"><span data-stu-id="0a7d1-208">section</span></span>| <span data-ttu-id="0a7d1-209">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-209">Optional.</span></span> <span data-ttu-id="0a7d1-210">ページの最後のエントリのランクが totalItems を下回る場合に返されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-210">Returned when the rank of the last entry in the page is lower than totalItems.</span></span> <span data-ttu-id="0a7d1-211">このセクションでも返されません skipToUser が要求で指定した場合。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-211">This section is also not returned when skipToUser is specified in the request.</span></span>|
| <span data-ttu-id="0a7d1-212">continuationToken</span><span class="sxs-lookup"><span data-stu-id="0a7d1-212">continuationToken</span></span>| <span data-ttu-id="0a7d1-213">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-213">string</span></span>| <span data-ttu-id="0a7d1-214">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-214">Required.</span></span> <span data-ttu-id="0a7d1-215">必要な場合に、結果の次のページをその URI を取得する"continuationToken"クエリ パラメーターにフィードされる値を指定します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-215">Specifies what value to feed back into the "continuationToken" query parameter to get next page of results for that URI if desired.</span></span> <span data-ttu-id="0a7d1-216">PagingInfo が返されない場合は、ありません [次へ] の「ページ」にデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-216">If no pagingInfo is returned then there is no "next page" of data to be obtained.</span></span>|
| <span data-ttu-id="0a7d1-217">totalItems</span><span class="sxs-lookup"><span data-stu-id="0a7d1-217">totalItems</span></span>| <span data-ttu-id="0a7d1-218">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="0a7d1-218">64-bit unsigned integer</span></span>| <span data-ttu-id="0a7d1-219">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-219">Required.</span></span> <span data-ttu-id="0a7d1-220">スコアボードにおける順位エントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-220">Total number of entries in the leaderboard.</span></span>|
| <span data-ttu-id="0a7d1-221"><b>leaderboardInfo</b></span><span class="sxs-lookup"><span data-stu-id="0a7d1-221"><b>leaderboardInfo</b></span></span>| <span data-ttu-id="0a7d1-222">セクション</span><span class="sxs-lookup"><span data-stu-id="0a7d1-222">section</span></span>| <span data-ttu-id="0a7d1-223">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-223">Required.</span></span> <span data-ttu-id="0a7d1-224">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-224">Always returned.</span></span> <span data-ttu-id="0a7d1-225">要求されたランキングに関するメタデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-225">Contains the metadata about the leaderboard requested.</span></span>|
| <span data-ttu-id="0a7d1-226">displayName</span><span class="sxs-lookup"><span data-stu-id="0a7d1-226">displayName</span></span>| <span data-ttu-id="0a7d1-227">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-227">string</span></span>| <span data-ttu-id="0a7d1-228">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-228">Required.</span></span> <span data-ttu-id="0a7d1-229">定義済みのランキングのローカライズされた表示名。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-229">Localized display name for the predefined leaderboard.</span></span> <span data-ttu-id="0a7d1-230">値の例:「キャプチャ フラグの合計です。」</span><span class="sxs-lookup"><span data-stu-id="0a7d1-230">Example value: "Total flags captured".</span></span>|
| <span data-ttu-id="0a7d1-231">totalCount</span><span class="sxs-lookup"><span data-stu-id="0a7d1-231">totalCount</span></span>| <span data-ttu-id="0a7d1-232">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-232">string</span></span>| <span data-ttu-id="0a7d1-233">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-233">Required.</span></span> <span data-ttu-id="0a7d1-234">スコアボードにおける順位エントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-234">Total number of entries in the leaderboard.</span></span>|
| <span data-ttu-id="0a7d1-235">列</span><span class="sxs-lookup"><span data-stu-id="0a7d1-235">columns</span></span>| <span data-ttu-id="0a7d1-236">array</span><span class="sxs-lookup"><span data-stu-id="0a7d1-236">array</span></span>| <span data-ttu-id="0a7d1-237">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-237">Required.</span></span>|
| <span data-ttu-id="0a7d1-238">displayName</span><span class="sxs-lookup"><span data-stu-id="0a7d1-238">displayName</span></span>| <span data-ttu-id="0a7d1-239">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-239">string</span></span>| <span data-ttu-id="0a7d1-240">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-240">Required.</span></span> <span data-ttu-id="0a7d1-241">スコア_ボード内の列に対応します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-241">Corresponds to a column in the leaderboard.</span></span>|
| <span data-ttu-id="0a7d1-242">statName</span><span class="sxs-lookup"><span data-stu-id="0a7d1-242">statName</span></span>| <span data-ttu-id="0a7d1-243">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-243">string</span></span>| <span data-ttu-id="0a7d1-244">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-244">Required.</span></span> <span data-ttu-id="0a7d1-245">スコア_ボード内の列に対応します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-245">Corresponds to a column in the leaderboard.</span></span>|
| <span data-ttu-id="0a7d1-246">type</span><span class="sxs-lookup"><span data-stu-id="0a7d1-246">type</span></span>| <span data-ttu-id="0a7d1-247">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-247">string</span></span>| <span data-ttu-id="0a7d1-248">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-248">Required.</span></span> <span data-ttu-id="0a7d1-249">スコア_ボード内の列に対応します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-249">Corresponds to a column in the leaderboard.</span></span>|
| <span data-ttu-id="0a7d1-250"><b>userList</b></span><span class="sxs-lookup"><span data-stu-id="0a7d1-250"><b>userList</b></span></span>| <span data-ttu-id="0a7d1-251">セクション</span><span class="sxs-lookup"><span data-stu-id="0a7d1-251">section</span></span>| <span data-ttu-id="0a7d1-252">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-252">Required.</span></span> <span data-ttu-id="0a7d1-253">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-253">Always returned.</span></span> <span data-ttu-id="0a7d1-254">要求されたランキングの実際のユーザーのスコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-254">Contains the actual user scores for the leaderboard requested.</span></span>|
| <span data-ttu-id="0a7d1-255">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="0a7d1-255">gamertag</span></span>| <span data-ttu-id="0a7d1-256">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-256">string</span></span>| <span data-ttu-id="0a7d1-257">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-257">Required.</span></span> <span data-ttu-id="0a7d1-258">ランキング エントリ内のユーザーに対応します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-258">Corresponds to the user in the leaderboard entry.</span></span>|
| <span data-ttu-id="0a7d1-259">xuid</span><span class="sxs-lookup"><span data-stu-id="0a7d1-259">xuid</span></span>| <span data-ttu-id="0a7d1-260">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0a7d1-260">32-bit signed integer</span></span>| <span data-ttu-id="0a7d1-261">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-261">Required.</span></span> <span data-ttu-id="0a7d1-262">ランキング エントリ内のユーザーに対応します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-262">Corresponds to the user in the leaderboard entry.</span></span>|
| <span data-ttu-id="0a7d1-263">百分位数</span><span class="sxs-lookup"><span data-stu-id="0a7d1-263">percentile</span></span>| <span data-ttu-id="0a7d1-264">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-264">string</span></span>| <span data-ttu-id="0a7d1-265">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-265">Required.</span></span> <span data-ttu-id="0a7d1-266">ランキング エントリ内のユーザーに対応します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-266">Corresponds to the user in the leaderboard entry.</span></span>|
| <span data-ttu-id="0a7d1-267">ランク</span><span class="sxs-lookup"><span data-stu-id="0a7d1-267">rank</span></span>| <span data-ttu-id="0a7d1-268">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-268">string</span></span>| <span data-ttu-id="0a7d1-269">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-269">Required.</span></span> <span data-ttu-id="0a7d1-270">ランキング エントリ内のユーザーに対応します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-270">Corresponds to the user in the leaderboard entry.</span></span>|
| <span data-ttu-id="0a7d1-271">値</span><span class="sxs-lookup"><span data-stu-id="0a7d1-271">values</span></span>| <span data-ttu-id="0a7d1-272">array</span><span class="sxs-lookup"><span data-stu-id="0a7d1-272">array</span></span>| <span data-ttu-id="0a7d1-273">必須。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-273">Required.</span></span> <span data-ttu-id="0a7d1-274">コンマ区切りの各値は、スコアボードの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-274">Each comma-separated value corresponds to a column in the leaderboard.</span></span>|

<a id="ID4ECEAC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="0a7d1-275">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="0a7d1-275">HTTP status codes</span></span>

<span data-ttu-id="0a7d1-276">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-276">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="0a7d1-277">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-277">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="0a7d1-278">コード</span><span class="sxs-lookup"><span data-stu-id="0a7d1-278">Code</span></span>| <span data-ttu-id="0a7d1-279">理由語句</span><span class="sxs-lookup"><span data-stu-id="0a7d1-279">Reason phrase</span></span>| <span data-ttu-id="0a7d1-280">説明</span><span class="sxs-lookup"><span data-stu-id="0a7d1-280">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="0a7d1-281">200</span><span class="sxs-lookup"><span data-stu-id="0a7d1-281">200</span></span>| <span data-ttu-id="0a7d1-282">OK</span><span class="sxs-lookup"><span data-stu-id="0a7d1-282">OK</span></span>| <span data-ttu-id="0a7d1-283">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-283">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="0a7d1-284">304</span><span class="sxs-lookup"><span data-stu-id="0a7d1-284">304</span></span>| <span data-ttu-id="0a7d1-285">変更されていません</span><span class="sxs-lookup"><span data-stu-id="0a7d1-285">Not Modified</span></span>|  |
| <span data-ttu-id="0a7d1-286">400</span><span class="sxs-lookup"><span data-stu-id="0a7d1-286">400</span></span>| <span data-ttu-id="0a7d1-287">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="0a7d1-287">Bad Request</span></span>| | <span data-ttu-id="0a7d1-288">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-288">Service could not understand malformed request.</span></span> <span data-ttu-id="0a7d1-289">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-289">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="0a7d1-290">401</span><span class="sxs-lookup"><span data-stu-id="0a7d1-290">401</span></span>| <span data-ttu-id="0a7d1-291">権限がありません</span><span class="sxs-lookup"><span data-stu-id="0a7d1-291">Unauthorized</span></span>| | <span data-ttu-id="0a7d1-292">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-292">The request requires user authentication.</span></span>|
| <span data-ttu-id="0a7d1-293">403</span><span class="sxs-lookup"><span data-stu-id="0a7d1-293">403</span></span>| <span data-ttu-id="0a7d1-294">Forbidden</span><span class="sxs-lookup"><span data-stu-id="0a7d1-294">Forbidden</span></span>| <span data-ttu-id="0a7d1-295">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-295">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="0a7d1-296">404</span><span class="sxs-lookup"><span data-stu-id="0a7d1-296">404</span></span>| <span data-ttu-id="0a7d1-297">検出不可</span><span class="sxs-lookup"><span data-stu-id="0a7d1-297">Not Found</span></span>| <span data-ttu-id="0a7d1-298">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-298">The specified resource could not be found.</span></span>|
| <span data-ttu-id="0a7d1-299">406</span><span class="sxs-lookup"><span data-stu-id="0a7d1-299">406</span></span>| <span data-ttu-id="0a7d1-300">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="0a7d1-300">Not Acceptable</span></span>| <span data-ttu-id="0a7d1-301">リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-301">Resource version is not supported; should be rejected by the MVC layer.</span></span>|
| <span data-ttu-id="0a7d1-302">408</span><span class="sxs-lookup"><span data-stu-id="0a7d1-302">408</span></span>| <span data-ttu-id="0a7d1-303">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="0a7d1-303">Request Timeout</span></span>| <span data-ttu-id="0a7d1-304">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-304">Service could not understand malformed request.</span></span> <span data-ttu-id="0a7d1-305">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-305">Typically an invalid parameter.</span></span>|

<a id="ID4E1HAC"></a>


## <a name="required-response-headers"></a><span data-ttu-id="0a7d1-306">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-306">Required Response Headers</span></span>

| <span data-ttu-id="0a7d1-307">Header</span><span class="sxs-lookup"><span data-stu-id="0a7d1-307">Header</span></span>| <span data-ttu-id="0a7d1-308">種類</span><span class="sxs-lookup"><span data-stu-id="0a7d1-308">Type</span></span>| <span data-ttu-id="0a7d1-309">説明</span><span class="sxs-lookup"><span data-stu-id="0a7d1-309">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="0a7d1-310">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0a7d1-310">Content-Type</span></span>| <span data-ttu-id="0a7d1-311">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-311">string</span></span>| <span data-ttu-id="0a7d1-312">応答の本文の mime の種類。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-312">The mime type of the body of the response.</span></span> <span data-ttu-id="0a7d1-313">値の例:"application/json"。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-313">Example values: "application/json".</span></span>|
| <span data-ttu-id="0a7d1-314">Content-Length</span><span class="sxs-lookup"><span data-stu-id="0a7d1-314">Content-Length</span></span>| <span data-ttu-id="0a7d1-315">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-315">string</span></span>| <span data-ttu-id="0a7d1-316">応答で送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-316">The number of bytes being sent in the response.</span></span> <span data-ttu-id="0a7d1-317">値の例:"232".</span><span class="sxs-lookup"><span data-stu-id="0a7d1-317">Example value: "232".</span></span>|

<a id="ID4EDJAC"></a>


## <a name="optional-response-headers"></a><span data-ttu-id="0a7d1-318">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a7d1-318">Optional Response Headers</span></span>

| <span data-ttu-id="0a7d1-319">Header</span><span class="sxs-lookup"><span data-stu-id="0a7d1-319">Header</span></span>| <span data-ttu-id="0a7d1-320">種類</span><span class="sxs-lookup"><span data-stu-id="0a7d1-320">Type</span></span>| <span data-ttu-id="0a7d1-321">説明</span><span class="sxs-lookup"><span data-stu-id="0a7d1-321">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="0a7d1-322">ETag</span><span class="sxs-lookup"><span data-stu-id="0a7d1-322">ETag</span></span>| <span data-ttu-id="0a7d1-323">string</span><span class="sxs-lookup"><span data-stu-id="0a7d1-323">string</span></span>| <span data-ttu-id="0a7d1-324">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-324">Used for cache optimization.</span></span> <span data-ttu-id="0a7d1-325">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="0a7d1-325">Example value: "686897696a7c876b7e".</span></span>|

<a id="ID4EDKAC"></a>


## <a name="response-body"></a><span data-ttu-id="0a7d1-326">応答本文</span><span class="sxs-lookup"><span data-stu-id="0a7d1-326">Response body</span></span>

<span data-ttu-id="0a7d1-327">ソーシャル ランキング、なしのページングの要求:</span><span class="sxs-lookup"><span data-stu-id="0a7d1-327">Request for social leaderboard, no paging:</span></span>

https://leaderboards.xboxlive.com/users/xuid(2533274916402282)/scids/c1ba92a9-0000-0000-0000-000000000000/stats/EnemyDefeats/people/all?sort=descending

<a id="ID4ENKAC"></a>


### <a name="sample-response"></a><span data-ttu-id="0a7d1-328">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="0a7d1-328">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="0a7d1-329">関連項目</span><span class="sxs-lookup"><span data-stu-id="0a7d1-329">See also</span></span>

<a id="ID4EZKAC"></a>


##### <a name="parent"></a><span data-ttu-id="0a7d1-330">Parent</span><span class="sxs-lookup"><span data-stu-id="0a7d1-330">Parent</span></span>

[<span data-ttu-id="0a7d1-331">/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite}</span><span class="sxs-lookup"><span data-stu-id="0a7d1-331">/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite}</span></span>](uri-usersxuidscidstatnamepeople.md)
