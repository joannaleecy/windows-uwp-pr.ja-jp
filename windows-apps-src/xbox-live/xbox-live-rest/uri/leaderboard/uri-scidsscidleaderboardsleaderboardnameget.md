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
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4621354"
---
# <a name="get-scidsscidleaderboardsleaderboardname"></a><span data-ttu-id="bfd02-104">GET (/scids/{scid}/leaderboards/{leaderboardname})</span><span class="sxs-lookup"><span data-stu-id="bfd02-104">GET (/scids/{scid}/leaderboards/{leaderboardname})</span></span>
 
<span data-ttu-id="bfd02-105">定義済みグローバル ランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-105">Gets a predefined global leaderboard.</span></span>
 
<span data-ttu-id="bfd02-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="bfd02-107">注釈</span><span class="sxs-lookup"><span data-stu-id="bfd02-107">Remarks</span></span>](#ID4EY)
  * [<span data-ttu-id="bfd02-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfd02-108">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="bfd02-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfd02-109">Query string parameters</span></span>](#ID4EOB)
  * [<span data-ttu-id="bfd02-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="bfd02-110">Authorization</span></span>](#ID4EID)
  * [<span data-ttu-id="bfd02-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="bfd02-111">Effect of privacy settings on resource</span></span>](#ID4EDE)
  * [<span data-ttu-id="bfd02-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfd02-112">Required Request Headers</span></span>](#ID4EME)
  * [<span data-ttu-id="bfd02-113">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfd02-113">Optional Request Headers</span></span>](#ID4E1F)
  * [<span data-ttu-id="bfd02-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="bfd02-114">HTTP status codes</span></span>](#ID4E1G)
  * [<span data-ttu-id="bfd02-115">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfd02-115">Response headers</span></span>](#ID4ERCAC)
  * [<span data-ttu-id="bfd02-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="bfd02-116">Response body</span></span>](#ID4EOEAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a><span data-ttu-id="bfd02-117">注釈</span><span class="sxs-lookup"><span data-stu-id="bfd02-117">Remarks</span></span>
 
<span data-ttu-id="bfd02-118">ランキング Api では、読み取り専用すべてと、したがってのみ GET 動詞をサポートします。</span><span class="sxs-lookup"><span data-stu-id="bfd02-118">Leaderboard APIs are all read-only and therefore only support the GET verb.</span></span> <span data-ttu-id="bfd02-119">ランクと並べ替えられた「ページ」インデックス付きのプレイヤーの統計データ プラットフォームによって書き込まれた個々 のユーザー統計から派生したが反映されます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-119">They reflect ranked and sorted "pages" of indexed player stats that are derived from individual user stats that were written via the Data Platform.</span></span> <span data-ttu-id="bfd02-120">完全なランキングのインデックスが大きくなることができ、呼び出し元は全体のいずれかを確認することはありませんが求められます、したがってこの URI はそのランキングを表示する必要があるビューの種類について具体的に説明する呼び出しを許可するいくつかのクエリ文字列引数をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="bfd02-120">Full leaderboard indexes can be quite large, and callers will never ask to see one in its entirety, therefore this URI supports several query string arguments that allow a caller to be specific about what kind of view it wants to see against that leaderboard.</span></span>
 
<span data-ttu-id="bfd02-121">これと同じ結果に 1 回または複数回実行している場合、GET 操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="bfd02-121">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bfd02-122">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfd02-122">URI parameters</span></span>
 
| <span data-ttu-id="bfd02-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfd02-123">Parameter</span></span>| <span data-ttu-id="bfd02-124">型</span><span class="sxs-lookup"><span data-stu-id="bfd02-124">Type</span></span>| <span data-ttu-id="bfd02-125">説明</span><span class="sxs-lookup"><span data-stu-id="bfd02-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bfd02-126">scid</span><span class="sxs-lookup"><span data-stu-id="bfd02-126">scid</span></span>| <span data-ttu-id="bfd02-127">GUID</span><span class="sxs-lookup"><span data-stu-id="bfd02-127">GUID</span></span>| <span data-ttu-id="bfd02-128">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="bfd02-128">Identifier of the service configuration which contains the resource being accessed.</span></span>| 
| <span data-ttu-id="bfd02-129">leaderboardname</span><span class="sxs-lookup"><span data-stu-id="bfd02-129">leaderboardname</span></span>| <span data-ttu-id="bfd02-130">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-130">string</span></span>| <span data-ttu-id="bfd02-131">アクセス対象の定義済みのランキング リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="bfd02-131">Unique identifier of the predefined leaderboard resource being accessed.</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="bfd02-132">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfd02-132">Query string parameters</span></span>
 
| <span data-ttu-id="bfd02-133">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfd02-133">Parameter</span></span>| <span data-ttu-id="bfd02-134">型</span><span class="sxs-lookup"><span data-stu-id="bfd02-134">Type</span></span>| <span data-ttu-id="bfd02-135">説明</span><span class="sxs-lookup"><span data-stu-id="bfd02-135">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bfd02-136">maxItems</span><span class="sxs-lookup"><span data-stu-id="bfd02-136">maxItems</span></span>| <span data-ttu-id="bfd02-137">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bfd02-137">32-bit unsigned integer</span></span>| <span data-ttu-id="bfd02-138">ランキング結果のページで、返されるレコードの最大数。</span><span class="sxs-lookup"><span data-stu-id="bfd02-138">Maximum number of leaderboard records to return in a page of results.</span></span> <span data-ttu-id="bfd02-139">指定しない場合、既定の数は (10) 返されます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-139">If not specified, a default number will be returned (10).</span></span> <span data-ttu-id="bfd02-140">MaxItems の最大値は引き続きが、大規模なデータ セットを回避する、ため、この値をターゲットにする必要がありますおそらく、最大呼び出しごとに UI が処理できるチューナーします。</span><span class="sxs-lookup"><span data-stu-id="bfd02-140">The max value for maxItems is still undefined, but we want to avoid large data sets, so this value should probably target the largest set that a tuner UI could handle per call.</span></span>| 
| <span data-ttu-id="bfd02-141">skipToRank</span><span class="sxs-lookup"><span data-stu-id="bfd02-141">skipToRank</span></span>| <span data-ttu-id="bfd02-142">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bfd02-142">32-bit unsigned integer</span></span>| <span data-ttu-id="bfd02-143">ページの指定のランキング順位から始まる結果を返します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-143">Return a page of results starting with the specified leaderboard rank.</span></span> <span data-ttu-id="bfd02-144">結果の残りの部分は、並べ替え順序をランク順になります。</span><span class="sxs-lookup"><span data-stu-id="bfd02-144">The rest of the results will be in sort order by rank.</span></span> <span data-ttu-id="bfd02-145">このクエリ文字列は、次の「ページ」結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-145">This query string can return a continuation token which can be fed back into a subsequent query to get "the next page" of results.</span></span>| 
| <span data-ttu-id="bfd02-146">skipToUser</span><span class="sxs-lookup"><span data-stu-id="bfd02-146">skipToUser</span></span>| <span data-ttu-id="bfd02-147">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-147">string</span></span>| <span data-ttu-id="bfd02-148">ページのユーザーのランクまたはスコアに関係なく、指定されたゲーマーの xuid の周囲のランキング結果を返します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-148">Return a page of leaderboard results around the specified gamer xuid, regardless of that user's rank or score.</span></span> <span data-ttu-id="bfd02-149">ページは、定義済みのビューのページの最後の位置や統計ランキング ビューの中央で指定したユーザーと位ランクによって並べ替えられます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-149">The page will be ordered by percentile rank with the specified user in the last position of the page for predefined views, or in the middle for stat leaderboard views.</span></span> <span data-ttu-id="bfd02-150">この種類のクエリに対して提供される continuationToken はありません。</span><span class="sxs-lookup"><span data-stu-id="bfd02-150">There is no continuationToken provided for this type of query.</span></span>| 
| <span data-ttu-id="bfd02-151">continuationToken</span><span class="sxs-lookup"><span data-stu-id="bfd02-151">continuationToken</span></span>| <span data-ttu-id="bfd02-152">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-152">string</span></span>| <span data-ttu-id="bfd02-153">前の呼び出しでは、continuationToken が返される、呼び出し元渡すことが戻る現状有姿トークンの結果の次のページを取得するクエリ文字列。</span><span class="sxs-lookup"><span data-stu-id="bfd02-153">If a previous call returned a continuationToken, then the caller can pass back that token "as is" in a query string to get the next page of results.</span></span>| 
  
<a id="ID4EID"></a>

 
## <a name="authorization"></a><span data-ttu-id="bfd02-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="bfd02-154">Authorization</span></span>
 
<span data-ttu-id="bfd02-155">承認ロジック コンテンツ分離とアクセス制御のシナリオの実装があります。</span><span class="sxs-lookup"><span data-stu-id="bfd02-155">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>
 
   * <span data-ttu-id="bfd02-156">ランキング、およびユーザーの両方の統計は、呼び出し元が要求に有効な XSTS トークンを送信している任意のプラットフォーム上のクライアントから読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-156">Both leaderboards and user stats can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="bfd02-157">書き込みは、データ プラットフォームでサポートされているクライアントに明らかに制限されます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-157">Writes are obviously limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="bfd02-158">タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付きの統計情報をマークできます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-158">Title developers can mark statistics as open or restricted with XDP or Dev Center.</span></span> <span data-ttu-id="bfd02-159">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="bfd02-159">Leaderboards are open statistics.</span></span> <span data-ttu-id="bfd02-160">開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-160">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="bfd02-161">サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-161">User authorization to a sandbox is managed through XDP or Dev Center.</span></span>
  
<span data-ttu-id="bfd02-162">チェックの擬似コードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="bfd02-162">Pseudo-code for the check looks like this:</span></span>
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4EDE"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="bfd02-163">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="bfd02-163">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="bfd02-164">ランキング データを読み取るときは、プライバシー チェックは実行されません。</span><span class="sxs-lookup"><span data-stu-id="bfd02-164">No privacy checks are performed when reading leaderboard data.</span></span>
  
<a id="ID4EME"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="bfd02-165">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfd02-165">Required Request Headers</span></span>
 
| <span data-ttu-id="bfd02-166">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfd02-166">Header</span></span>| <span data-ttu-id="bfd02-167">説明</span><span class="sxs-lookup"><span data-stu-id="bfd02-167">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bfd02-168">Authorization</span><span class="sxs-lookup"><span data-stu-id="bfd02-168">Authorization</span></span>| <span data-ttu-id="bfd02-169">[String]。</span><span class="sxs-lookup"><span data-stu-id="bfd02-169">String.</span></span> <span data-ttu-id="bfd02-170">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-170">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="bfd02-171">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b></span><span class="sxs-lookup"><span data-stu-id="bfd02-171">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b></span></span>| 
| <span data-ttu-id="bfd02-172">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="bfd02-172">X-RequestedServiceVersion</span></span>| <span data-ttu-id="bfd02-173">[String]。</span><span class="sxs-lookup"><span data-stu-id="bfd02-173">String.</span></span> <span data-ttu-id="bfd02-174">この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="bfd02-174">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="bfd02-175">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="bfd02-175">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="bfd02-176">Accept</span><span class="sxs-lookup"><span data-stu-id="bfd02-176">Accept</span></span>| <span data-ttu-id="bfd02-177">[String]。</span><span class="sxs-lookup"><span data-stu-id="bfd02-177">String.</span></span> <span data-ttu-id="bfd02-178">コンテンツの種類の受け入れられるします。</span><span class="sxs-lookup"><span data-stu-id="bfd02-178">Content-Types that are acceptable.</span></span> <span data-ttu-id="bfd02-179">値の例:<b>アプリケーション/json</b></span><span class="sxs-lookup"><span data-stu-id="bfd02-179">Example value: <b>application/json</b></span></span>| 
  
<a id="ID4E1F"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="bfd02-180">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfd02-180">Optional Request Headers</span></span>
 
| <span data-ttu-id="bfd02-181">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfd02-181">Header</span></span>| <span data-ttu-id="bfd02-182">説明</span><span class="sxs-lookup"><span data-stu-id="bfd02-182">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bfd02-183">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="bfd02-183">If-None-Match</span></span>| <span data-ttu-id="bfd02-184">[String]。</span><span class="sxs-lookup"><span data-stu-id="bfd02-184">String.</span></span> <span data-ttu-id="bfd02-185">エンティティ タグ、クライアントは、キャッシュをサポートしている場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-185">Entity tag, used if client supports caching.</span></span> <span data-ttu-id="bfd02-186">値の例: <b>"686897696a7c876b7e"</b></span><span class="sxs-lookup"><span data-stu-id="bfd02-186">Example value: <b>"686897696a7c876b7e"</b></span></span>|  | 
  
<a id="ID4E1G"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="bfd02-187">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="bfd02-187">HTTP status codes</span></span>
 
<span data-ttu-id="bfd02-188">サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-188">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="bfd02-189">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="bfd02-189">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="bfd02-190">コード</span><span class="sxs-lookup"><span data-stu-id="bfd02-190">Code</span></span>| <span data-ttu-id="bfd02-191">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="bfd02-191">Reason phrase</span></span>| <span data-ttu-id="bfd02-192">説明</span><span class="sxs-lookup"><span data-stu-id="bfd02-192">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bfd02-193">200</span><span class="sxs-lookup"><span data-stu-id="bfd02-193">200</span></span>| <span data-ttu-id="bfd02-194">OK</span><span class="sxs-lookup"><span data-stu-id="bfd02-194">OK</span></span>| <span data-ttu-id="bfd02-195">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="bfd02-195">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="bfd02-196">304</span><span class="sxs-lookup"><span data-stu-id="bfd02-196">304</span></span>| <span data-ttu-id="bfd02-197">Not Modified</span><span class="sxs-lookup"><span data-stu-id="bfd02-197">Not Modified</span></span>| <span data-ttu-id="bfd02-198">リソースされていない以降に変更するように要求します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-198">Resource not been modified since last requested.</span></span>| 
| <span data-ttu-id="bfd02-199">400</span><span class="sxs-lookup"><span data-stu-id="bfd02-199">400</span></span>| <span data-ttu-id="bfd02-200">Bad Request</span><span class="sxs-lookup"><span data-stu-id="bfd02-200">Bad Request</span></span>| <span data-ttu-id="bfd02-201">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bfd02-201">Service could not understand malformed request.</span></span> <span data-ttu-id="bfd02-202">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="bfd02-202">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="bfd02-203">401</span><span class="sxs-lookup"><span data-stu-id="bfd02-203">401</span></span>| <span data-ttu-id="bfd02-204">権限がありません</span><span class="sxs-lookup"><span data-stu-id="bfd02-204">Unauthorized</span></span>| <span data-ttu-id="bfd02-205">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="bfd02-205">The request requires user authentication.</span></span>| 
| <span data-ttu-id="bfd02-206">403</span><span class="sxs-lookup"><span data-stu-id="bfd02-206">403</span></span>| <span data-ttu-id="bfd02-207">Forbidden</span><span class="sxs-lookup"><span data-stu-id="bfd02-207">Forbidden</span></span>| <span data-ttu-id="bfd02-208">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="bfd02-208">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="bfd02-209">404</span><span class="sxs-lookup"><span data-stu-id="bfd02-209">404</span></span>| <span data-ttu-id="bfd02-210">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="bfd02-210">Not Found</span></span>| <span data-ttu-id="bfd02-211">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="bfd02-211">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="bfd02-212">406</span><span class="sxs-lookup"><span data-stu-id="bfd02-212">406</span></span>| <span data-ttu-id="bfd02-213">許容できません。</span><span class="sxs-lookup"><span data-stu-id="bfd02-213">Not Acceptable</span></span>| <span data-ttu-id="bfd02-214">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="bfd02-214">Resource version is not supported.</span></span>| 
| <span data-ttu-id="bfd02-215">408</span><span class="sxs-lookup"><span data-stu-id="bfd02-215">408</span></span>| <span data-ttu-id="bfd02-216">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="bfd02-216">Request Timeout</span></span>| <span data-ttu-id="bfd02-217">リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bfd02-217">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
  
<a id="ID4ERCAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="bfd02-218">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfd02-218">Response headers</span></span>
 
| <span data-ttu-id="bfd02-219">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfd02-219">Header</span></span>| <span data-ttu-id="bfd02-220">型</span><span class="sxs-lookup"><span data-stu-id="bfd02-220">Type</span></span>| <span data-ttu-id="bfd02-221">説明</span><span class="sxs-lookup"><span data-stu-id="bfd02-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bfd02-222">Content-Type</span><span class="sxs-lookup"><span data-stu-id="bfd02-222">Content-Type</span></span>| <span data-ttu-id="bfd02-223">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-223">string</span></span>| <span data-ttu-id="bfd02-224">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-224">Required.</span></span> <span data-ttu-id="bfd02-225">応答の本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="bfd02-225">The MIME type of the body of the response.</span></span> <span data-ttu-id="bfd02-226">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-226">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="bfd02-227">Content-Length</span><span class="sxs-lookup"><span data-stu-id="bfd02-227">Content-Length</span></span>| <span data-ttu-id="bfd02-228">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-228">string</span></span>| <span data-ttu-id="bfd02-229">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-229">Required.</span></span> <span data-ttu-id="bfd02-230">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="bfd02-230">The number of bytes being sent in the response.</span></span> <span data-ttu-id="bfd02-231">例: <b>232</b>します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-231">Example: <b>232</b>.</span></span>| 
| <span data-ttu-id="bfd02-232">ETag</span><span class="sxs-lookup"><span data-stu-id="bfd02-232">ETag</span></span>| <span data-ttu-id="bfd02-233">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-233">string</span></span>| <span data-ttu-id="bfd02-234">省略可能。</span><span class="sxs-lookup"><span data-stu-id="bfd02-234">Optional.</span></span> <span data-ttu-id="bfd02-235">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-235">Used for cache optimization.</span></span> <span data-ttu-id="bfd02-236">例: <b>686897696a7c876b7e</b>します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-236">Example: <b>686897696a7c876b7e</b>.</span></span>| 
  
<a id="ID4EOEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="bfd02-237">応答本文</span><span class="sxs-lookup"><span data-stu-id="bfd02-237">Response body</span></span>
 
<a id="ID4EUEAC"></a>

 
### <a name="response-members"></a><span data-ttu-id="bfd02-238">応答のメンバー</span><span class="sxs-lookup"><span data-stu-id="bfd02-238">Response Members</span></span>
 
<span data-ttu-id="bfd02-239">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="bfd02-239">pagingInfo</span></span> | <span data-ttu-id="bfd02-240">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="bfd02-240">pagingInfo</span></span>| <span data-ttu-id="bfd02-241">セクション</span><span class="sxs-lookup"><span data-stu-id="bfd02-241">section</span></span>| <span data-ttu-id="bfd02-242">省略可能。</span><span class="sxs-lookup"><span data-stu-id="bfd02-242">Optional.</span></span> <span data-ttu-id="bfd02-243">MaxItems が要求で指定されたときののみを表示します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-243">Only present when maxItems is specified in the request.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bfd02-244">continuationToken</span><span class="sxs-lookup"><span data-stu-id="bfd02-244">continuationToken</span></span>| <span data-ttu-id="bfd02-245">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bfd02-245">64-bit unsigned integer</span></span>| <span data-ttu-id="bfd02-246">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-246">Required.</span></span> <span data-ttu-id="bfd02-247">必要な場合は、その URI の結果の次のページを取得するのに<b>skipItems</b>クエリ パラメーターにフィードバックするには、どのような値を指定します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-247">Specifies what value to feed back into the <b>skipItems</b> query parameter to get the next page of results for that URI if desired.</span></span> <span data-ttu-id="bfd02-248"><b>PagingInfo</b>が返されない場合は、データを取得するための次のページがありません。</span><span class="sxs-lookup"><span data-stu-id="bfd02-248">If no <b>pagingInfo</b> is returned then there is no next page of data to be obtained.</span></span>| 
| <span data-ttu-id="bfd02-249">totalCount</span><span class="sxs-lookup"><span data-stu-id="bfd02-249">totalCount</span></span>| <span data-ttu-id="bfd02-250">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bfd02-250">64-bit unsigned integer</span></span>| <span data-ttu-id="bfd02-251">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-251">Required.</span></span> <span data-ttu-id="bfd02-252">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="bfd02-252">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="bfd02-253">値の例: 1234567890</span><span class="sxs-lookup"><span data-stu-id="bfd02-253">Example value: 1234567890</span></span>| 
 
<span data-ttu-id="bfd02-254">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="bfd02-254">leaderboardInfo</span></span> | <span data-ttu-id="bfd02-255">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="bfd02-255">leaderboardInfo</span></span>| <span data-ttu-id="bfd02-256">セクション</span><span class="sxs-lookup"><span data-stu-id="bfd02-256">section</span></span>| <span data-ttu-id="bfd02-257">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-257">Required.</span></span> <span data-ttu-id="bfd02-258">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-258">Always returned.</span></span> <span data-ttu-id="bfd02-259">要求されたランキングに関するメタデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="bfd02-259">Contains the metadata about the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bfd02-260">displayName</span><span class="sxs-lookup"><span data-stu-id="bfd02-260">displayName</span></span>| <span data-ttu-id="bfd02-261">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-261">string</span></span>| <span data-ttu-id="bfd02-262">使用されていません。</span><span class="sxs-lookup"><span data-stu-id="bfd02-262">Not used.</span></span>| 
| <span data-ttu-id="bfd02-263">totalCount</span><span class="sxs-lookup"><span data-stu-id="bfd02-263">totalCount</span></span>| <span data-ttu-id="bfd02-264">文字列 (64 ビットの符号なし整数)</span><span class="sxs-lookup"><span data-stu-id="bfd02-264">string (64-bit unsigned integer)</span></span>| <span data-ttu-id="bfd02-265">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-265">Required.</span></span> <span data-ttu-id="bfd02-266">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="bfd02-266">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="bfd02-267">値の例: 1234567890</span><span class="sxs-lookup"><span data-stu-id="bfd02-267">Example value: 1234567890</span></span>| 
| <span data-ttu-id="bfd02-268">列</span><span class="sxs-lookup"><span data-stu-id="bfd02-268">columns</span></span>| <span data-ttu-id="bfd02-269">array</span><span class="sxs-lookup"><span data-stu-id="bfd02-269">array</span></span>| <span data-ttu-id="bfd02-270">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-270">Required.</span></span> <span data-ttu-id="bfd02-271">ランキングの列。</span><span class="sxs-lookup"><span data-stu-id="bfd02-271">Columns in the leaderboard.</span></span>| 
| <span data-ttu-id="bfd02-272">displayName</span><span class="sxs-lookup"><span data-stu-id="bfd02-272">displayName</span></span>| <span data-ttu-id="bfd02-273">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-273">string</span></span>| <span data-ttu-id="bfd02-274">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-274">Required.</span></span> <span data-ttu-id="bfd02-275">ランキングの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-275">Corresponds to a column in the leaderboard.</span></span>| 
| <span data-ttu-id="bfd02-276">statName</span><span class="sxs-lookup"><span data-stu-id="bfd02-276">statName</span></span>| <span data-ttu-id="bfd02-277">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-277">string</span></span>| <span data-ttu-id="bfd02-278">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-278">Required.</span></span> <span data-ttu-id="bfd02-279">ランキングの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-279">Corresponds to a column in the leaderboard.</span></span>| 
| <span data-ttu-id="bfd02-280">type</span><span class="sxs-lookup"><span data-stu-id="bfd02-280">type</span></span>| <span data-ttu-id="bfd02-281">文字列</span><span class="sxs-lookup"><span data-stu-id="bfd02-281">string</span></span>| <span data-ttu-id="bfd02-282">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-282">Required.</span></span> <span data-ttu-id="bfd02-283">ランキングの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-283">Corresponds to a column in the leaderboard.</span></span>| 
 
<span data-ttu-id="bfd02-284">userList</span><span class="sxs-lookup"><span data-stu-id="bfd02-284">userList</span></span> | <span data-ttu-id="bfd02-285">userList</span><span class="sxs-lookup"><span data-stu-id="bfd02-285">userList</span></span>| <span data-ttu-id="bfd02-286">セクション</span><span class="sxs-lookup"><span data-stu-id="bfd02-286">section</span></span>| <span data-ttu-id="bfd02-287">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-287">Required.</span></span> <span data-ttu-id="bfd02-288">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="bfd02-288">Always returned.</span></span> <span data-ttu-id="bfd02-289">要求されたランキングの実際のユーザーのスコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="bfd02-289">Contains the actual user scores for the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bfd02-290">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="bfd02-290">gamertag</span></span>| <span data-ttu-id="bfd02-291">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-291">string</span></span>| <span data-ttu-id="bfd02-292">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-292">Required.</span></span> <span data-ttu-id="bfd02-293">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="bfd02-293">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="bfd02-294">xuid</span><span class="sxs-lookup"><span data-stu-id="bfd02-294">xuid</span></span>| <span data-ttu-id="bfd02-295">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bfd02-295">64-bit unsigned integer</span></span>| <span data-ttu-id="bfd02-296">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-296">Required.</span></span> <span data-ttu-id="bfd02-297">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="bfd02-297">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="bfd02-298">位</span><span class="sxs-lookup"><span data-stu-id="bfd02-298">percentile</span></span>| <span data-ttu-id="bfd02-299">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-299">string</span></span>| <span data-ttu-id="bfd02-300">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-300">Required.</span></span> <span data-ttu-id="bfd02-301">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="bfd02-301">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="bfd02-302">ランク</span><span class="sxs-lookup"><span data-stu-id="bfd02-302">rank</span></span>| <span data-ttu-id="bfd02-303">string</span><span class="sxs-lookup"><span data-stu-id="bfd02-303">string</span></span>| <span data-ttu-id="bfd02-304">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-304">Required.</span></span> <span data-ttu-id="bfd02-305">ランキングのエントリで、ユーザーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="bfd02-305">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="bfd02-306">値</span><span class="sxs-lookup"><span data-stu-id="bfd02-306">values</span></span>| <span data-ttu-id="bfd02-307">array</span><span class="sxs-lookup"><span data-stu-id="bfd02-307">array</span></span>| <span data-ttu-id="bfd02-308">必須。</span><span class="sxs-lookup"><span data-stu-id="bfd02-308">Required.</span></span> <span data-ttu-id="bfd02-309">それぞれのコンマ区切り値は、ランキングの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-309">Each comma-separated value corresponds to a column in the leaderboard.</span></span>| 
  
<a id="ID4EGKAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="bfd02-310">応答の例</span><span class="sxs-lookup"><span data-stu-id="bfd02-310">Sample response</span></span>
 
<span data-ttu-id="bfd02-311">次の要求の URI は、グローバル ランキングにランクをスキップするかを示しています。</span><span class="sxs-lookup"><span data-stu-id="bfd02-311">The following request URI depicts skipping to rank on a global leaderboard.</span></span>
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/TotalFlagsCaptured/columns/deaths?maxItems=3&skipToRank=15000
         
```

 
<span data-ttu-id="bfd02-312">上記の URI は、次の JSON 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-312">The URI above returns the following JSON response.</span></span>
 

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

 
<span data-ttu-id="bfd02-313">次の要求の URI は、グローバル ランキングにユーザーをスキップするかを示しています。</span><span class="sxs-lookup"><span data-stu-id="bfd02-313">The following request URI depicts skipping to the user on a global leaderboard.</span></span>
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/totalflagscaptured?maxItems=3&skipToUser=2343737892734237
         
```

 
<span data-ttu-id="bfd02-314">上記の URI は、次の JSON 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="bfd02-314">The URI above returns the following JSON response.</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="bfd02-315">関連項目</span><span class="sxs-lookup"><span data-stu-id="bfd02-315">See also</span></span>
 
<a id="ID4EALAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bfd02-316">Parent</span><span class="sxs-lookup"><span data-stu-id="bfd02-316">Parent</span></span> 

[<span data-ttu-id="bfd02-317">/scids/{scid}/leaderboards/{leaderboardname}</span><span class="sxs-lookup"><span data-stu-id="bfd02-317">/scids/{scid}/leaderboards/{leaderboardname}</span></span>](uri-scidsscidleaderboardsleaderboardname.md)

   