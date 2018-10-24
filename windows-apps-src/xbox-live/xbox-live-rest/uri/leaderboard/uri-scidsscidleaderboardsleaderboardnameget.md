---
title: GET (/scids/{scid}/leaderboards/{leaderboardname})
assetID: 4adea46c-e910-8709-c28e-ce9178e712ef
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardnameget.html
author: KevinAsgari
description: " GET (/scids/{scid}/leaderboards/{leaderboardname})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 961351e79ca04988c78c8e0be723435b39e5bae8
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5430609"
---
# <a name="get-scidsscidleaderboardsleaderboardname"></a><span data-ttu-id="90cde-104">GET (/scids/{scid}/leaderboards/{leaderboardname})</span><span class="sxs-lookup"><span data-stu-id="90cde-104">GET (/scids/{scid}/leaderboards/{leaderboardname})</span></span>
 
<span data-ttu-id="90cde-105">定義済みグローバル ランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="90cde-105">Gets a predefined global leaderboard.</span></span>
 
<span data-ttu-id="90cde-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="90cde-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="90cde-107">注釈</span><span class="sxs-lookup"><span data-stu-id="90cde-107">Remarks</span></span>](#ID4EY)
  * [<span data-ttu-id="90cde-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90cde-108">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="90cde-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="90cde-109">Query string parameters</span></span>](#ID4EOB)
  * [<span data-ttu-id="90cde-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="90cde-110">Authorization</span></span>](#ID4EID)
  * [<span data-ttu-id="90cde-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="90cde-111">Effect of privacy settings on resource</span></span>](#ID4EDE)
  * [<span data-ttu-id="90cde-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90cde-112">Required Request Headers</span></span>](#ID4EME)
  * [<span data-ttu-id="90cde-113">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90cde-113">Optional Request Headers</span></span>](#ID4E1F)
  * [<span data-ttu-id="90cde-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="90cde-114">HTTP status codes</span></span>](#ID4E1G)
  * [<span data-ttu-id="90cde-115">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90cde-115">Response headers</span></span>](#ID4ERCAC)
  * [<span data-ttu-id="90cde-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="90cde-116">Response body</span></span>](#ID4EOEAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a><span data-ttu-id="90cde-117">注釈</span><span class="sxs-lookup"><span data-stu-id="90cde-117">Remarks</span></span>
 
<span data-ttu-id="90cde-118">ランキング Api では、読み取り専用すべてと、したがってのみ GET 動詞をサポートします。</span><span class="sxs-lookup"><span data-stu-id="90cde-118">Leaderboard APIs are all read-only and therefore only support the GET verb.</span></span> <span data-ttu-id="90cde-119">ランクと並べ替えられた「ページ」インデックス付きのプレイヤーの統計データ プラットフォームによって書き込まれた個々 のユーザー統計から派生したが反映されます。</span><span class="sxs-lookup"><span data-stu-id="90cde-119">They reflect ranked and sorted "pages" of indexed player stats that are derived from individual user stats that were written via the Data Platform.</span></span> <span data-ttu-id="90cde-120">完全なランキングのインデックスが大きくなることができ、呼び出し元は全体のいずれかを確認することはありませんが求められます、したがってこの URI はそのランキングを表示する必要があるビューの種類について具体的に説明する呼び出しを許可するいくつかのクエリ文字列引数をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="90cde-120">Full leaderboard indexes can be quite large, and callers will never ask to see one in its entirety, therefore this URI supports several query string arguments that allow a caller to be specific about what kind of view it wants to see against that leaderboard.</span></span>
 
<span data-ttu-id="90cde-121">これと同じ結果に 1 回または複数回実行している場合、GET 操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="90cde-121">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="90cde-122">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90cde-122">URI parameters</span></span>
 
| <span data-ttu-id="90cde-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="90cde-123">Parameter</span></span>| <span data-ttu-id="90cde-124">型</span><span class="sxs-lookup"><span data-stu-id="90cde-124">Type</span></span>| <span data-ttu-id="90cde-125">説明</span><span class="sxs-lookup"><span data-stu-id="90cde-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="90cde-126">scid</span><span class="sxs-lookup"><span data-stu-id="90cde-126">scid</span></span>| <span data-ttu-id="90cde-127">GUID</span><span class="sxs-lookup"><span data-stu-id="90cde-127">GUID</span></span>| <span data-ttu-id="90cde-128">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="90cde-128">Identifier of the service configuration which contains the resource being accessed.</span></span>| 
| <span data-ttu-id="90cde-129">leaderboardname</span><span class="sxs-lookup"><span data-stu-id="90cde-129">leaderboardname</span></span>| <span data-ttu-id="90cde-130">string</span><span class="sxs-lookup"><span data-stu-id="90cde-130">string</span></span>| <span data-ttu-id="90cde-131">アクセス対象の定義済みのランキング リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="90cde-131">Unique identifier of the predefined leaderboard resource being accessed.</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="90cde-132">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="90cde-132">Query string parameters</span></span>
 
| <span data-ttu-id="90cde-133">パラメーター</span><span class="sxs-lookup"><span data-stu-id="90cde-133">Parameter</span></span>| <span data-ttu-id="90cde-134">型</span><span class="sxs-lookup"><span data-stu-id="90cde-134">Type</span></span>| <span data-ttu-id="90cde-135">説明</span><span class="sxs-lookup"><span data-stu-id="90cde-135">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90cde-136">maxItems</span><span class="sxs-lookup"><span data-stu-id="90cde-136">maxItems</span></span>| <span data-ttu-id="90cde-137">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="90cde-137">32-bit unsigned integer</span></span>| <span data-ttu-id="90cde-138">ランキング結果のページで、返されるレコードの最大数。</span><span class="sxs-lookup"><span data-stu-id="90cde-138">Maximum number of leaderboard records to return in a page of results.</span></span> <span data-ttu-id="90cde-139">指定しない場合、既定の数は (10) 返されます。</span><span class="sxs-lookup"><span data-stu-id="90cde-139">If not specified, a default number will be returned (10).</span></span> <span data-ttu-id="90cde-140">MaxItems の最大値は引き続きが、大規模なデータ セットを回避する、ため、この値をターゲットにする必要がありますおそらく、最大呼び出しごとに UI が処理できるチューナーします。</span><span class="sxs-lookup"><span data-stu-id="90cde-140">The max value for maxItems is still undefined, but we want to avoid large data sets, so this value should probably target the largest set that a tuner UI could handle per call.</span></span>| 
| <span data-ttu-id="90cde-141">skipToRank</span><span class="sxs-lookup"><span data-stu-id="90cde-141">skipToRank</span></span>| <span data-ttu-id="90cde-142">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="90cde-142">32-bit unsigned integer</span></span>| <span data-ttu-id="90cde-143">ページの指定のランキング順位から始まる結果を返します。</span><span class="sxs-lookup"><span data-stu-id="90cde-143">Return a page of results starting with the specified leaderboard rank.</span></span> <span data-ttu-id="90cde-144">結果の残りの部分は、並べ替え順序をランク順になります。</span><span class="sxs-lookup"><span data-stu-id="90cde-144">The rest of the results will be in sort order by rank.</span></span> <span data-ttu-id="90cde-145">このクエリ文字列は、次の「ページ」結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="90cde-145">This query string can return a continuation token which can be fed back into a subsequent query to get "the next page" of results.</span></span>| 
| <span data-ttu-id="90cde-146">skipToUser</span><span class="sxs-lookup"><span data-stu-id="90cde-146">skipToUser</span></span>| <span data-ttu-id="90cde-147">string</span><span class="sxs-lookup"><span data-stu-id="90cde-147">string</span></span>| <span data-ttu-id="90cde-148">ページのユーザーのランクまたはスコアに関係なく、指定されたゲーマーの xuid の周囲のランキング結果を返します。</span><span class="sxs-lookup"><span data-stu-id="90cde-148">Return a page of leaderboard results around the specified gamer xuid, regardless of that user's rank or score.</span></span> <span data-ttu-id="90cde-149">ページは、定義済みのビューのページの最後の位置や統計ランキング ビューの中央で指定したユーザーと位ランクによって並べ替えられます。</span><span class="sxs-lookup"><span data-stu-id="90cde-149">The page will be ordered by percentile rank with the specified user in the last position of the page for predefined views, or in the middle for stat leaderboard views.</span></span> <span data-ttu-id="90cde-150">この種類のクエリに対して提供される continuationToken はありません。</span><span class="sxs-lookup"><span data-stu-id="90cde-150">There is no continuationToken provided for this type of query.</span></span>| 
| <span data-ttu-id="90cde-151">continuationToken</span><span class="sxs-lookup"><span data-stu-id="90cde-151">continuationToken</span></span>| <span data-ttu-id="90cde-152">string</span><span class="sxs-lookup"><span data-stu-id="90cde-152">string</span></span>| <span data-ttu-id="90cde-153">前の呼び出しでは、continuationToken が返される、呼び出し元渡すことが戻る現状有姿トークンの結果の次のページを取得するクエリ文字列。</span><span class="sxs-lookup"><span data-stu-id="90cde-153">If a previous call returned a continuationToken, then the caller can pass back that token "as is" in a query string to get the next page of results.</span></span>| 
  
<a id="ID4EID"></a>

 
## <a name="authorization"></a><span data-ttu-id="90cde-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="90cde-154">Authorization</span></span>
 
<span data-ttu-id="90cde-155">承認ロジック コンテンツ分離とアクセス制御のシナリオの実装があります。</span><span class="sxs-lookup"><span data-stu-id="90cde-155">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>
 
   * <span data-ttu-id="90cde-156">ランキング、およびユーザーの両方の統計は、呼び出し元が要求に有効な XSTS トークンを送信している任意のプラットフォーム上のクライアントから読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="90cde-156">Both leaderboards and user stats can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="90cde-157">書き込みは、データ プラットフォームでサポートされているクライアントに明らかに制限されます。</span><span class="sxs-lookup"><span data-stu-id="90cde-157">Writes are obviously limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="90cde-158">タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付きの統計情報をマークできます。</span><span class="sxs-lookup"><span data-stu-id="90cde-158">Title developers can mark statistics as open or restricted with XDP or Dev Center.</span></span> <span data-ttu-id="90cde-159">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="90cde-159">Leaderboards are open statistics.</span></span> <span data-ttu-id="90cde-160">開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="90cde-160">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="90cde-161">サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="90cde-161">User authorization to a sandbox is managed through XDP or Dev Center.</span></span>
  
<span data-ttu-id="90cde-162">チェックの擬似コードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="90cde-162">Pseudo-code for the check looks like this:</span></span>
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4EDE"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="90cde-163">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="90cde-163">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="90cde-164">ランキング データを読み取るときは、プライバシー チェックは実行されません。</span><span class="sxs-lookup"><span data-stu-id="90cde-164">No privacy checks are performed when reading leaderboard data.</span></span>
  
<a id="ID4EME"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="90cde-165">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90cde-165">Required Request Headers</span></span>
 
| <span data-ttu-id="90cde-166">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90cde-166">Header</span></span>| <span data-ttu-id="90cde-167">説明</span><span class="sxs-lookup"><span data-stu-id="90cde-167">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90cde-168">Authorization</span><span class="sxs-lookup"><span data-stu-id="90cde-168">Authorization</span></span>| <span data-ttu-id="90cde-169">[String]。</span><span class="sxs-lookup"><span data-stu-id="90cde-169">String.</span></span> <span data-ttu-id="90cde-170">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="90cde-170">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="90cde-171">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b></span><span class="sxs-lookup"><span data-stu-id="90cde-171">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b></span></span>| 
| <span data-ttu-id="90cde-172">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="90cde-172">X-RequestedServiceVersion</span></span>| <span data-ttu-id="90cde-173">[String]。</span><span class="sxs-lookup"><span data-stu-id="90cde-173">String.</span></span> <span data-ttu-id="90cde-174">この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="90cde-174">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="90cde-175">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="90cde-175">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="90cde-176">Accept</span><span class="sxs-lookup"><span data-stu-id="90cde-176">Accept</span></span>| <span data-ttu-id="90cde-177">[String]。</span><span class="sxs-lookup"><span data-stu-id="90cde-177">String.</span></span> <span data-ttu-id="90cde-178">コンテンツの種類の受け入れられるします。</span><span class="sxs-lookup"><span data-stu-id="90cde-178">Content-Types that are acceptable.</span></span> <span data-ttu-id="90cde-179">値の例:<b>アプリケーション/json</b></span><span class="sxs-lookup"><span data-stu-id="90cde-179">Example value: <b>application/json</b></span></span>| 
  
<a id="ID4E1F"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="90cde-180">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90cde-180">Optional Request Headers</span></span>
 
| <span data-ttu-id="90cde-181">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90cde-181">Header</span></span>| <span data-ttu-id="90cde-182">説明</span><span class="sxs-lookup"><span data-stu-id="90cde-182">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90cde-183">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="90cde-183">If-None-Match</span></span>| <span data-ttu-id="90cde-184">[String]。</span><span class="sxs-lookup"><span data-stu-id="90cde-184">String.</span></span> <span data-ttu-id="90cde-185">エンティティ タグ、クライアントは、キャッシュをサポートしている場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="90cde-185">Entity tag, used if client supports caching.</span></span> <span data-ttu-id="90cde-186">値の例: <b>"686897696a7c876b7e"</b></span><span class="sxs-lookup"><span data-stu-id="90cde-186">Example value: <b>"686897696a7c876b7e"</b></span></span>|  | 
  
<a id="ID4E1G"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="90cde-187">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="90cde-187">HTTP status codes</span></span>
 
<span data-ttu-id="90cde-188">サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="90cde-188">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="90cde-189">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90cde-189">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="90cde-190">コード</span><span class="sxs-lookup"><span data-stu-id="90cde-190">Code</span></span>| <span data-ttu-id="90cde-191">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="90cde-191">Reason phrase</span></span>| <span data-ttu-id="90cde-192">説明</span><span class="sxs-lookup"><span data-stu-id="90cde-192">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90cde-193">200</span><span class="sxs-lookup"><span data-stu-id="90cde-193">200</span></span>| <span data-ttu-id="90cde-194">OK</span><span class="sxs-lookup"><span data-stu-id="90cde-194">OK</span></span>| <span data-ttu-id="90cde-195">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="90cde-195">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="90cde-196">304</span><span class="sxs-lookup"><span data-stu-id="90cde-196">304</span></span>| <span data-ttu-id="90cde-197">Not Modified</span><span class="sxs-lookup"><span data-stu-id="90cde-197">Not Modified</span></span>| <span data-ttu-id="90cde-198">リソースされていない以降に変更するように要求します。</span><span class="sxs-lookup"><span data-stu-id="90cde-198">Resource not been modified since last requested.</span></span>| 
| <span data-ttu-id="90cde-199">400</span><span class="sxs-lookup"><span data-stu-id="90cde-199">400</span></span>| <span data-ttu-id="90cde-200">Bad Request</span><span class="sxs-lookup"><span data-stu-id="90cde-200">Bad Request</span></span>| <span data-ttu-id="90cde-201">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="90cde-201">Service could not understand malformed request.</span></span> <span data-ttu-id="90cde-202">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="90cde-202">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="90cde-203">401</span><span class="sxs-lookup"><span data-stu-id="90cde-203">401</span></span>| <span data-ttu-id="90cde-204">権限がありません</span><span class="sxs-lookup"><span data-stu-id="90cde-204">Unauthorized</span></span>| <span data-ttu-id="90cde-205">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="90cde-205">The request requires user authentication.</span></span>| 
| <span data-ttu-id="90cde-206">403</span><span class="sxs-lookup"><span data-stu-id="90cde-206">403</span></span>| <span data-ttu-id="90cde-207">Forbidden</span><span class="sxs-lookup"><span data-stu-id="90cde-207">Forbidden</span></span>| <span data-ttu-id="90cde-208">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="90cde-208">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="90cde-209">404</span><span class="sxs-lookup"><span data-stu-id="90cde-209">404</span></span>| <span data-ttu-id="90cde-210">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="90cde-210">Not Found</span></span>| <span data-ttu-id="90cde-211">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="90cde-211">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="90cde-212">406</span><span class="sxs-lookup"><span data-stu-id="90cde-212">406</span></span>| <span data-ttu-id="90cde-213">許容できません。</span><span class="sxs-lookup"><span data-stu-id="90cde-213">Not Acceptable</span></span>| <span data-ttu-id="90cde-214">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="90cde-214">Resource version is not supported.</span></span>| 
| <span data-ttu-id="90cde-215">408</span><span class="sxs-lookup"><span data-stu-id="90cde-215">408</span></span>| <span data-ttu-id="90cde-216">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="90cde-216">Request Timeout</span></span>| <span data-ttu-id="90cde-217">リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90cde-217">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
  
<a id="ID4ERCAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="90cde-218">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90cde-218">Response headers</span></span>
 
| <span data-ttu-id="90cde-219">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90cde-219">Header</span></span>| <span data-ttu-id="90cde-220">型</span><span class="sxs-lookup"><span data-stu-id="90cde-220">Type</span></span>| <span data-ttu-id="90cde-221">説明</span><span class="sxs-lookup"><span data-stu-id="90cde-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90cde-222">Content-Type</span><span class="sxs-lookup"><span data-stu-id="90cde-222">Content-Type</span></span>| <span data-ttu-id="90cde-223">string</span><span class="sxs-lookup"><span data-stu-id="90cde-223">string</span></span>| <span data-ttu-id="90cde-224">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-224">Required.</span></span> <span data-ttu-id="90cde-225">応答の本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="90cde-225">The MIME type of the body of the response.</span></span> <span data-ttu-id="90cde-226">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="90cde-226">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="90cde-227">Content-Length</span><span class="sxs-lookup"><span data-stu-id="90cde-227">Content-Length</span></span>| <span data-ttu-id="90cde-228">string</span><span class="sxs-lookup"><span data-stu-id="90cde-228">string</span></span>| <span data-ttu-id="90cde-229">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-229">Required.</span></span> <span data-ttu-id="90cde-230">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="90cde-230">The number of bytes being sent in the response.</span></span> <span data-ttu-id="90cde-231">例: <b>232</b>します。</span><span class="sxs-lookup"><span data-stu-id="90cde-231">Example: <b>232</b>.</span></span>| 
| <span data-ttu-id="90cde-232">ETag</span><span class="sxs-lookup"><span data-stu-id="90cde-232">ETag</span></span>| <span data-ttu-id="90cde-233">string</span><span class="sxs-lookup"><span data-stu-id="90cde-233">string</span></span>| <span data-ttu-id="90cde-234">省略可能。</span><span class="sxs-lookup"><span data-stu-id="90cde-234">Optional.</span></span> <span data-ttu-id="90cde-235">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="90cde-235">Used for cache optimization.</span></span> <span data-ttu-id="90cde-236">例: <b>686897696a7c876b7e</b>します。</span><span class="sxs-lookup"><span data-stu-id="90cde-236">Example: <b>686897696a7c876b7e</b>.</span></span>| 
  
<a id="ID4EOEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="90cde-237">応答本文</span><span class="sxs-lookup"><span data-stu-id="90cde-237">Response body</span></span>
 
<a id="ID4EUEAC"></a>

 
### <a name="response-members"></a><span data-ttu-id="90cde-238">応答のメンバー</span><span class="sxs-lookup"><span data-stu-id="90cde-238">Response Members</span></span>
 
<span data-ttu-id="90cde-239">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="90cde-239">pagingInfo</span></span> | <span data-ttu-id="90cde-240">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="90cde-240">pagingInfo</span></span>| <span data-ttu-id="90cde-241">セクション</span><span class="sxs-lookup"><span data-stu-id="90cde-241">section</span></span>| <span data-ttu-id="90cde-242">省略可能。</span><span class="sxs-lookup"><span data-stu-id="90cde-242">Optional.</span></span> <span data-ttu-id="90cde-243">MaxItems が要求で指定されたときののみを表示します。</span><span class="sxs-lookup"><span data-stu-id="90cde-243">Only present when maxItems is specified in the request.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90cde-244">continuationToken</span><span class="sxs-lookup"><span data-stu-id="90cde-244">continuationToken</span></span>| <span data-ttu-id="90cde-245">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="90cde-245">64-bit unsigned integer</span></span>| <span data-ttu-id="90cde-246">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-246">Required.</span></span> <span data-ttu-id="90cde-247">必要な場合は、その URI の結果の次のページを取得するのに<b>skipItems</b>クエリ パラメーターにフィードバックするには、どのような値を指定します。</span><span class="sxs-lookup"><span data-stu-id="90cde-247">Specifies what value to feed back into the <b>skipItems</b> query parameter to get the next page of results for that URI if desired.</span></span> <span data-ttu-id="90cde-248"><b>PagingInfo</b>が返されない場合は、データを取得するための次のページがありません。</span><span class="sxs-lookup"><span data-stu-id="90cde-248">If no <b>pagingInfo</b> is returned then there is no next page of data to be obtained.</span></span>| 
| <span data-ttu-id="90cde-249">totalCount</span><span class="sxs-lookup"><span data-stu-id="90cde-249">totalCount</span></span>| <span data-ttu-id="90cde-250">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="90cde-250">64-bit unsigned integer</span></span>| <span data-ttu-id="90cde-251">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-251">Required.</span></span> <span data-ttu-id="90cde-252">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="90cde-252">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="90cde-253">値の例: 1234567890</span><span class="sxs-lookup"><span data-stu-id="90cde-253">Example value: 1234567890</span></span>| 
 
<span data-ttu-id="90cde-254">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="90cde-254">leaderboardInfo</span></span> | <span data-ttu-id="90cde-255">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="90cde-255">leaderboardInfo</span></span>| <span data-ttu-id="90cde-256">セクション</span><span class="sxs-lookup"><span data-stu-id="90cde-256">section</span></span>| <span data-ttu-id="90cde-257">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-257">Required.</span></span> <span data-ttu-id="90cde-258">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="90cde-258">Always returned.</span></span> <span data-ttu-id="90cde-259">要求されたランキングに関するメタデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="90cde-259">Contains the metadata about the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90cde-260">displayName</span><span class="sxs-lookup"><span data-stu-id="90cde-260">displayName</span></span>| <span data-ttu-id="90cde-261">string</span><span class="sxs-lookup"><span data-stu-id="90cde-261">string</span></span>| <span data-ttu-id="90cde-262">使用されていません。</span><span class="sxs-lookup"><span data-stu-id="90cde-262">Not used.</span></span>| 
| <span data-ttu-id="90cde-263">totalCount</span><span class="sxs-lookup"><span data-stu-id="90cde-263">totalCount</span></span>| <span data-ttu-id="90cde-264">文字列 (64 ビットの符号なし整数)</span><span class="sxs-lookup"><span data-stu-id="90cde-264">string (64-bit unsigned integer)</span></span>| <span data-ttu-id="90cde-265">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-265">Required.</span></span> <span data-ttu-id="90cde-266">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="90cde-266">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="90cde-267">値の例: 1234567890</span><span class="sxs-lookup"><span data-stu-id="90cde-267">Example value: 1234567890</span></span>| 
| <span data-ttu-id="90cde-268">列</span><span class="sxs-lookup"><span data-stu-id="90cde-268">columns</span></span>| <span data-ttu-id="90cde-269">array</span><span class="sxs-lookup"><span data-stu-id="90cde-269">array</span></span>| <span data-ttu-id="90cde-270">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-270">Required.</span></span> <span data-ttu-id="90cde-271">ランキングの列。</span><span class="sxs-lookup"><span data-stu-id="90cde-271">Columns in the leaderboard.</span></span>| 
| <span data-ttu-id="90cde-272">displayName</span><span class="sxs-lookup"><span data-stu-id="90cde-272">displayName</span></span>| <span data-ttu-id="90cde-273">string</span><span class="sxs-lookup"><span data-stu-id="90cde-273">string</span></span>| <span data-ttu-id="90cde-274">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-274">Required.</span></span> <span data-ttu-id="90cde-275">ランキングの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="90cde-275">Corresponds to a column in the leaderboard.</span></span>| 
| <span data-ttu-id="90cde-276">statName</span><span class="sxs-lookup"><span data-stu-id="90cde-276">statName</span></span>| <span data-ttu-id="90cde-277">string</span><span class="sxs-lookup"><span data-stu-id="90cde-277">string</span></span>| <span data-ttu-id="90cde-278">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-278">Required.</span></span> <span data-ttu-id="90cde-279">ランキングの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="90cde-279">Corresponds to a column in the leaderboard.</span></span>| 
| <span data-ttu-id="90cde-280">type</span><span class="sxs-lookup"><span data-stu-id="90cde-280">type</span></span>| <span data-ttu-id="90cde-281">文字列</span><span class="sxs-lookup"><span data-stu-id="90cde-281">string</span></span>| <span data-ttu-id="90cde-282">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-282">Required.</span></span> <span data-ttu-id="90cde-283">ランキングの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="90cde-283">Corresponds to a column in the leaderboard.</span></span>| 
 
<span data-ttu-id="90cde-284">userList</span><span class="sxs-lookup"><span data-stu-id="90cde-284">userList</span></span> | <span data-ttu-id="90cde-285">userList</span><span class="sxs-lookup"><span data-stu-id="90cde-285">userList</span></span>| <span data-ttu-id="90cde-286">セクション</span><span class="sxs-lookup"><span data-stu-id="90cde-286">section</span></span>| <span data-ttu-id="90cde-287">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-287">Required.</span></span> <span data-ttu-id="90cde-288">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="90cde-288">Always returned.</span></span> <span data-ttu-id="90cde-289">要求されたランキングの実際のユーザーのスコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="90cde-289">Contains the actual user scores for the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90cde-290">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="90cde-290">gamertag</span></span>| <span data-ttu-id="90cde-291">string</span><span class="sxs-lookup"><span data-stu-id="90cde-291">string</span></span>| <span data-ttu-id="90cde-292">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-292">Required.</span></span> <span data-ttu-id="90cde-293">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="90cde-293">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="90cde-294">xuid</span><span class="sxs-lookup"><span data-stu-id="90cde-294">xuid</span></span>| <span data-ttu-id="90cde-295">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="90cde-295">64-bit unsigned integer</span></span>| <span data-ttu-id="90cde-296">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-296">Required.</span></span> <span data-ttu-id="90cde-297">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="90cde-297">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="90cde-298">位</span><span class="sxs-lookup"><span data-stu-id="90cde-298">percentile</span></span>| <span data-ttu-id="90cde-299">string</span><span class="sxs-lookup"><span data-stu-id="90cde-299">string</span></span>| <span data-ttu-id="90cde-300">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-300">Required.</span></span> <span data-ttu-id="90cde-301">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="90cde-301">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="90cde-302">ランク</span><span class="sxs-lookup"><span data-stu-id="90cde-302">rank</span></span>| <span data-ttu-id="90cde-303">string</span><span class="sxs-lookup"><span data-stu-id="90cde-303">string</span></span>| <span data-ttu-id="90cde-304">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-304">Required.</span></span> <span data-ttu-id="90cde-305">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="90cde-305">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="90cde-306">値</span><span class="sxs-lookup"><span data-stu-id="90cde-306">values</span></span>| <span data-ttu-id="90cde-307">array</span><span class="sxs-lookup"><span data-stu-id="90cde-307">array</span></span>| <span data-ttu-id="90cde-308">必須。</span><span class="sxs-lookup"><span data-stu-id="90cde-308">Required.</span></span> <span data-ttu-id="90cde-309">それぞれのコンマ区切り値は、ランキングの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="90cde-309">Each comma-separated value corresponds to a column in the leaderboard.</span></span>| 
  
<a id="ID4EGKAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="90cde-310">応答の例</span><span class="sxs-lookup"><span data-stu-id="90cde-310">Sample response</span></span>
 
<span data-ttu-id="90cde-311">次の要求の URI は、グローバル ランキングにランクをスキップするかを示しています。</span><span class="sxs-lookup"><span data-stu-id="90cde-311">The following request URI depicts skipping to rank on a global leaderboard.</span></span>
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/TotalFlagsCaptured/columns/deaths?maxItems=3&skipToRank=15000
         
```

 
<span data-ttu-id="90cde-312">上記の URI は、次の JSON 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="90cde-312">The URI above returns the following JSON response.</span></span>
 

```cpp
{
    "pagingInfo": {
        "continuationToken": "152",
        "totalItems": 23437
    },
    "leaderboardInfo": {
        "displayName": "Total flags captured",
        "totalCount": 23437,
        "columns": [
            {
                "displayName": "Flags Captured",
                "statName": "flagscaptured",
                "type": "Integer"
            },
            {
                "displayName": "Deaths",
                "statName": "deaths",
                "type": "Integer"
            }
        ]
    },
    "userList": [
        {
            "gamertag": "WarriorSaint",
            "xuid": 1234567890123444,
            "percentile": 0.64,
            "rank": 15000,
            "values": [
                1000,
                47
            ]
        },
        {
            "gamertag": "xxxSniper39",
            "xuid": 1234567890123555,
            "percentile": 0.64,
            "rank": 15001,
            "values": [
                998,
                17
            ]
        },
        {
            "gamertag": "WhockaWhocka",
            "xuid": 1234567890123666,
            "percentile": 0.64,
            "rank": 15002,
            "values": [
                996,
                2
            ]
        }
    ]
}
         
```

 
<span data-ttu-id="90cde-313">次の要求の URI は、グローバル ランキングにユーザーをスキップするかを示しています。</span><span class="sxs-lookup"><span data-stu-id="90cde-313">The following request URI depicts skipping to the user on a global leaderboard.</span></span>
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/totalflagscaptured?maxItems=3&skipToUser=2343737892734237
         
```

 
<span data-ttu-id="90cde-314">上記の URI は、次の JSON 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="90cde-314">The URI above returns the following JSON response.</span></span>
 

```cpp
{
    "leaderboardInfo": 
    {   
       "displayName": "Total flags captured",
       "totalCount": 23437,
       "columns": [
              {
                  "displayName": "Flags Captured",
                  "statName": "flagscaptured",
                  "type": "Integer"
              }
       ]
    },
    "userList": [
        {
            "gamertag": "AverageJoe",
            "percentile": 55.00,
            "rank": 11718,
            "value": 1219,
            "xuid": 1234567890123444
        },
        {
            "gamertag": "AreUWatchinMe",
            "percentile": 60.00,
            "rank": 14162,
            "value": 1062,
            "xuid": 2343737892734333
        },
         {
            "gamertag": "WarriorSaint",
            "percentile": 64.39,
            "rank": 15000,
            "value ": 1000,
            "xuid": 1234567890123455
        }
    ]
}
         
```

   
<a id="ID4E5KAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="90cde-315">関連項目</span><span class="sxs-lookup"><span data-stu-id="90cde-315">See also</span></span>
 
<a id="ID4EALAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="90cde-316">Parent</span><span class="sxs-lookup"><span data-stu-id="90cde-316">Parent</span></span> 

[<span data-ttu-id="90cde-317">/scids/{scid}/leaderboards/{leaderboardname}</span><span class="sxs-lookup"><span data-stu-id="90cde-317">/scids/{scid}/leaderboards/{leaderboardname}</span></span>](uri-scidsscidleaderboardsleaderboardname.md)

   