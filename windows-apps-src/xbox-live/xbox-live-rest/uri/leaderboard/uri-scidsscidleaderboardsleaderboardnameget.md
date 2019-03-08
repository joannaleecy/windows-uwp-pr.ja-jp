---
title: GET (/scids/{scid}/leaderboards/{leaderboardname})
assetID: 4adea46c-e910-8709-c28e-ce9178e712ef
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardnameget.html
description: " GET (/scids/{scid}/leaderboards/{leaderboardname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b0d313262a642ee0db956f6d3264025931e63e8a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57629497"
---
# <a name="get-scidsscidleaderboardsleaderboardname"></a><span data-ttu-id="3f9f2-104">GET (/scids/{scid}/leaderboards/{leaderboardname})</span><span class="sxs-lookup"><span data-stu-id="3f9f2-104">GET (/scids/{scid}/leaderboards/{leaderboardname})</span></span>
 
<span data-ttu-id="3f9f2-105">定義済みのグローバルなランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-105">Gets a predefined global leaderboard.</span></span>
 
<span data-ttu-id="3f9f2-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="3f9f2-107">注釈</span><span class="sxs-lookup"><span data-stu-id="3f9f2-107">Remarks</span></span>](#ID4EY)
  * [<span data-ttu-id="3f9f2-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f9f2-108">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="3f9f2-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f9f2-109">Query string parameters</span></span>](#ID4EOB)
  * [<span data-ttu-id="3f9f2-110">承認</span><span class="sxs-lookup"><span data-stu-id="3f9f2-110">Authorization</span></span>](#ID4EID)
  * [<span data-ttu-id="3f9f2-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="3f9f2-111">Effect of privacy settings on resource</span></span>](#ID4EDE)
  * [<span data-ttu-id="3f9f2-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3f9f2-112">Required Request Headers</span></span>](#ID4EME)
  * [<span data-ttu-id="3f9f2-113">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3f9f2-113">Optional Request Headers</span></span>](#ID4E1F)
  * [<span data-ttu-id="3f9f2-114">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3f9f2-114">HTTP status codes</span></span>](#ID4E1G)
  * [<span data-ttu-id="3f9f2-115">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3f9f2-115">Response headers</span></span>](#ID4ERCAC)
  * [<span data-ttu-id="3f9f2-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="3f9f2-116">Response body</span></span>](#ID4EOEAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a><span data-ttu-id="3f9f2-117">注釈</span><span class="sxs-lookup"><span data-stu-id="3f9f2-117">Remarks</span></span>
 
<span data-ttu-id="3f9f2-118">ランキング Api はすべて読み取り専用し、したがってのみ GET 動詞をサポートします。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-118">Leaderboard APIs are all read-only and therefore only support the GET verb.</span></span> <span data-ttu-id="3f9f2-119">ランクと並べ替え済みの「ページ」データ プラットフォームを使用して記述されている個々 のユーザーの統計から派生した統計をインデックス付きのプレーヤーが反映されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-119">They reflect ranked and sorted "pages" of indexed player stats that are derived from individual user stats that were written via the Data Platform.</span></span> <span data-ttu-id="3f9f2-120">ランキングの完全なインデックスが大きくなることができ、全体のいずれかを確認する呼び出し元が今後は、この URI がそのためにそのランキングに対して表示するビューの種類は呼び出し元を許可するいくつかのクエリ文字列引数をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-120">Full leaderboard indexes can be quite large, and callers will never ask to see one in its entirety, therefore this URI supports several query string arguments that allow a caller to be specific about what kind of view it wants to see against that leaderboard.</span></span>
 
<span data-ttu-id="3f9f2-121">GET 操作は、この 1 回または複数回実行された場合、同じ結果が生成されますのですべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-121">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3f9f2-122">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f9f2-122">URI parameters</span></span>
 
| <span data-ttu-id="3f9f2-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f9f2-123">Parameter</span></span>| <span data-ttu-id="3f9f2-124">種類</span><span class="sxs-lookup"><span data-stu-id="3f9f2-124">Type</span></span>| <span data-ttu-id="3f9f2-125">説明</span><span class="sxs-lookup"><span data-stu-id="3f9f2-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3f9f2-126">scid</span><span class="sxs-lookup"><span data-stu-id="3f9f2-126">scid</span></span>| <span data-ttu-id="3f9f2-127">GUID</span><span class="sxs-lookup"><span data-stu-id="3f9f2-127">GUID</span></span>| <span data-ttu-id="3f9f2-128">アクセスされるリソースを含むサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-128">Identifier of the service configuration which contains the resource being accessed.</span></span>| 
| <span data-ttu-id="3f9f2-129">leaderboardname</span><span class="sxs-lookup"><span data-stu-id="3f9f2-129">leaderboardname</span></span>| <span data-ttu-id="3f9f2-130">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-130">string</span></span>| <span data-ttu-id="3f9f2-131">アクセスされる定義済みのランキング リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-131">Unique identifier of the predefined leaderboard resource being accessed.</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="3f9f2-132">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f9f2-132">Query string parameters</span></span>
 
| <span data-ttu-id="3f9f2-133">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f9f2-133">Parameter</span></span>| <span data-ttu-id="3f9f2-134">種類</span><span class="sxs-lookup"><span data-stu-id="3f9f2-134">Type</span></span>| <span data-ttu-id="3f9f2-135">説明</span><span class="sxs-lookup"><span data-stu-id="3f9f2-135">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f9f2-136">maxItems</span><span class="sxs-lookup"><span data-stu-id="3f9f2-136">maxItems</span></span>| <span data-ttu-id="3f9f2-137">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3f9f2-137">32-bit unsigned integer</span></span>| <span data-ttu-id="3f9f2-138">ランキング ページの結果で返されるレコードの最大数。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-138">Maximum number of leaderboard records to return in a page of results.</span></span> <span data-ttu-id="3f9f2-139">指定されていない場合、既定の数には、(10) が返されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-139">If not specified, a default number will be returned (10).</span></span> <span data-ttu-id="3f9f2-140">MaxItems の最大値は、まだ未定義が大規模なデータ セットを回避する、ため、この値が対象おそらく最大呼び出しごとに UI が処理できるチューナーします。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-140">The max value for maxItems is still undefined, but we want to avoid large data sets, so this value should probably target the largest set that a tuner UI could handle per call.</span></span>| 
| <span data-ttu-id="3f9f2-141">skipToRank</span><span class="sxs-lookup"><span data-stu-id="3f9f2-141">skipToRank</span></span>| <span data-ttu-id="3f9f2-142">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3f9f2-142">32-bit unsigned integer</span></span>| <span data-ttu-id="3f9f2-143">以降では、指定したランキング ランクの結果のページを返します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-143">Return a page of results starting with the specified leaderboard rank.</span></span> <span data-ttu-id="3f9f2-144">残りの結果を順位で並べ替え順序になります。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-144">The rest of the results will be in sort order by rank.</span></span> <span data-ttu-id="3f9f2-145">このクエリ文字列は、[次へ] の「ページ」の結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-145">This query string can return a continuation token which can be fed back into a subsequent query to get "the next page" of results.</span></span>| 
| <span data-ttu-id="3f9f2-146">skipToUser</span><span class="sxs-lookup"><span data-stu-id="3f9f2-146">skipToUser</span></span>| <span data-ttu-id="3f9f2-147">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-147">string</span></span>| <span data-ttu-id="3f9f2-148">そのユーザーのランクやスコアに関係なく、指定のゲーマー xuid の周囲のスコアボードの結果のページを返します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-148">Return a page of leaderboard results around the specified gamer xuid, regardless of that user's rank or score.</span></span> <span data-ttu-id="3f9f2-149">ページは、stat ランキング ビューの中央にまたは定義済みのビューのページの最後の位置で指定したユーザーのパーセン タイル順位で並べ替えられます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-149">The page will be ordered by percentile rank with the specified user in the last position of the page for predefined views, or in the middle for stat leaderboard views.</span></span> <span data-ttu-id="3f9f2-150">この種類のクエリに対して提供される continuationToken はありません。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-150">There is no continuationToken provided for this type of query.</span></span>| 
| <span data-ttu-id="3f9f2-151">continuationToken</span><span class="sxs-lookup"><span data-stu-id="3f9f2-151">continuationToken</span></span>| <span data-ttu-id="3f9f2-152">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-152">string</span></span>| <span data-ttu-id="3f9f2-153">前の呼び出しで、continuationToken が返された場合はし、呼び出し元ことができますを送り返すそのトークンを"現状有姿結果の次のページを取得するクエリ文字列で。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-153">If a previous call returned a continuationToken, then the caller can pass back that token "as is" in a query string to get the next page of results.</span></span>| 
  
<a id="ID4EID"></a>

 
## <a name="authorization"></a><span data-ttu-id="3f9f2-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="3f9f2-154">Authorization</span></span>
 
<span data-ttu-id="3f9f2-155">コンテンツの分離とアクセス制御のシナリオで実装された承認ロジックがあります。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-155">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>
 
   * <span data-ttu-id="3f9f2-156">呼び出し元の要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングとユーザーの両方の統計情報を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-156">Both leaderboards and user stats can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="3f9f2-157">書き込みは、当然ながら、データ プラットフォームでサポートされているクライアントに制限されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-157">Writes are obviously limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="3f9f2-158">タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-158">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="3f9f2-159">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-159">Leaderboards are open statistics.</span></span> <span data-ttu-id="3f9f2-160">統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-160">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="3f9f2-161">サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-161">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>
  
<span data-ttu-id="3f9f2-162">チェックの擬似コードのようになります。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-162">Pseudo-code for the check looks like this:</span></span>
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4EDE"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="3f9f2-163">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="3f9f2-163">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="3f9f2-164">ランキング データを読み取る場合は、プライバシーに関するチェックは行われません。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-164">No privacy checks are performed when reading leaderboard data.</span></span>
  
<a id="ID4EME"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="3f9f2-165">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3f9f2-165">Required Request Headers</span></span>
 
| <span data-ttu-id="3f9f2-166">Header</span><span class="sxs-lookup"><span data-stu-id="3f9f2-166">Header</span></span>| <span data-ttu-id="3f9f2-167">説明</span><span class="sxs-lookup"><span data-stu-id="3f9f2-167">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f9f2-168">Authorization</span><span class="sxs-lookup"><span data-stu-id="3f9f2-168">Authorization</span></span>| <span data-ttu-id="3f9f2-169">[String]。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-169">String.</span></span> <span data-ttu-id="3f9f2-170">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-170">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="3f9f2-171">値の例:<b>XBL3.0 x=&lt;userhash>;&lt;token></b></span><span class="sxs-lookup"><span data-stu-id="3f9f2-171">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b></span></span>| 
| <span data-ttu-id="3f9f2-172">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="3f9f2-172">X-RequestedServiceVersion</span></span>| <span data-ttu-id="3f9f2-173">[String]。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-173">String.</span></span> <span data-ttu-id="3f9f2-174">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-174">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="3f9f2-175">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="3f9f2-175">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="3f9f2-176">OK</span><span class="sxs-lookup"><span data-stu-id="3f9f2-176">Accept</span></span>| <span data-ttu-id="3f9f2-177">[String]。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-177">String.</span></span> <span data-ttu-id="3f9f2-178">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-178">Content-Types that are acceptable.</span></span> <span data-ttu-id="3f9f2-179">値の例:<b>アプリケーション/json</b></span><span class="sxs-lookup"><span data-stu-id="3f9f2-179">Example value: <b>application/json</b></span></span>| 
  
<a id="ID4E1F"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="3f9f2-180">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3f9f2-180">Optional Request Headers</span></span>
 
| <span data-ttu-id="3f9f2-181">Header</span><span class="sxs-lookup"><span data-stu-id="3f9f2-181">Header</span></span>| <span data-ttu-id="3f9f2-182">説明</span><span class="sxs-lookup"><span data-stu-id="3f9f2-182">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f9f2-183">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="3f9f2-183">If-None-Match</span></span>| <span data-ttu-id="3f9f2-184">[String]。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-184">String.</span></span> <span data-ttu-id="3f9f2-185">クライアント キャッシュをサポートしている場合に使用されるエンティティ タグ。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-185">Entity tag, used if client supports caching.</span></span> <span data-ttu-id="3f9f2-186">値の例:<b>"686897696a7c876b7e"</b></span><span class="sxs-lookup"><span data-stu-id="3f9f2-186">Example value: <b>"686897696a7c876b7e"</b></span></span>|  | 
  
<a id="ID4E1G"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="3f9f2-187">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3f9f2-187">HTTP status codes</span></span>
 
<span data-ttu-id="3f9f2-188">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-188">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="3f9f2-189">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-189">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="3f9f2-190">コード</span><span class="sxs-lookup"><span data-stu-id="3f9f2-190">Code</span></span>| <span data-ttu-id="3f9f2-191">理由語句</span><span class="sxs-lookup"><span data-stu-id="3f9f2-191">Reason phrase</span></span>| <span data-ttu-id="3f9f2-192">説明</span><span class="sxs-lookup"><span data-stu-id="3f9f2-192">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f9f2-193">200</span><span class="sxs-lookup"><span data-stu-id="3f9f2-193">200</span></span>| <span data-ttu-id="3f9f2-194">OK</span><span class="sxs-lookup"><span data-stu-id="3f9f2-194">OK</span></span>| <span data-ttu-id="3f9f2-195">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-195">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="3f9f2-196">304</span><span class="sxs-lookup"><span data-stu-id="3f9f2-196">304</span></span>| <span data-ttu-id="3f9f2-197">変更されていません</span><span class="sxs-lookup"><span data-stu-id="3f9f2-197">Not Modified</span></span>| <span data-ttu-id="3f9f2-198">リソースされていない最後の要求以降に変更します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-198">Resource not been modified since last requested.</span></span>| 
| <span data-ttu-id="3f9f2-199">400</span><span class="sxs-lookup"><span data-stu-id="3f9f2-199">400</span></span>| <span data-ttu-id="3f9f2-200">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="3f9f2-200">Bad Request</span></span>| <span data-ttu-id="3f9f2-201">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-201">Service could not understand malformed request.</span></span> <span data-ttu-id="3f9f2-202">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-202">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="3f9f2-203">401</span><span class="sxs-lookup"><span data-stu-id="3f9f2-203">401</span></span>| <span data-ttu-id="3f9f2-204">権限がありません</span><span class="sxs-lookup"><span data-stu-id="3f9f2-204">Unauthorized</span></span>| <span data-ttu-id="3f9f2-205">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-205">The request requires user authentication.</span></span>| 
| <span data-ttu-id="3f9f2-206">403</span><span class="sxs-lookup"><span data-stu-id="3f9f2-206">403</span></span>| <span data-ttu-id="3f9f2-207">Forbidden</span><span class="sxs-lookup"><span data-stu-id="3f9f2-207">Forbidden</span></span>| <span data-ttu-id="3f9f2-208">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-208">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="3f9f2-209">404</span><span class="sxs-lookup"><span data-stu-id="3f9f2-209">404</span></span>| <span data-ttu-id="3f9f2-210">検出不可</span><span class="sxs-lookup"><span data-stu-id="3f9f2-210">Not Found</span></span>| <span data-ttu-id="3f9f2-211">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-211">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="3f9f2-212">406</span><span class="sxs-lookup"><span data-stu-id="3f9f2-212">406</span></span>| <span data-ttu-id="3f9f2-213">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="3f9f2-213">Not Acceptable</span></span>| <span data-ttu-id="3f9f2-214">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-214">Resource version is not supported.</span></span>| 
| <span data-ttu-id="3f9f2-215">408</span><span class="sxs-lookup"><span data-stu-id="3f9f2-215">408</span></span>| <span data-ttu-id="3f9f2-216">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="3f9f2-216">Request Timeout</span></span>| <span data-ttu-id="3f9f2-217">リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-217">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
  
<a id="ID4ERCAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="3f9f2-218">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3f9f2-218">Response headers</span></span>
 
| <span data-ttu-id="3f9f2-219">Header</span><span class="sxs-lookup"><span data-stu-id="3f9f2-219">Header</span></span>| <span data-ttu-id="3f9f2-220">種類</span><span class="sxs-lookup"><span data-stu-id="3f9f2-220">Type</span></span>| <span data-ttu-id="3f9f2-221">説明</span><span class="sxs-lookup"><span data-stu-id="3f9f2-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f9f2-222">Content-Type</span><span class="sxs-lookup"><span data-stu-id="3f9f2-222">Content-Type</span></span>| <span data-ttu-id="3f9f2-223">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-223">string</span></span>| <span data-ttu-id="3f9f2-224">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-224">Required.</span></span> <span data-ttu-id="3f9f2-225">応答の本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-225">The MIME type of the body of the response.</span></span> <span data-ttu-id="3f9f2-226">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-226">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="3f9f2-227">Content-Length</span><span class="sxs-lookup"><span data-stu-id="3f9f2-227">Content-Length</span></span>| <span data-ttu-id="3f9f2-228">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-228">string</span></span>| <span data-ttu-id="3f9f2-229">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-229">Required.</span></span> <span data-ttu-id="3f9f2-230">応答で送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-230">The number of bytes being sent in the response.</span></span> <span data-ttu-id="3f9f2-231">以下に例を示します。<b>232</b>.</span><span class="sxs-lookup"><span data-stu-id="3f9f2-231">Example: <b>232</b>.</span></span>| 
| <span data-ttu-id="3f9f2-232">ETag</span><span class="sxs-lookup"><span data-stu-id="3f9f2-232">ETag</span></span>| <span data-ttu-id="3f9f2-233">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-233">string</span></span>| <span data-ttu-id="3f9f2-234">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-234">Optional.</span></span> <span data-ttu-id="3f9f2-235">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-235">Used for cache optimization.</span></span> <span data-ttu-id="3f9f2-236">以下に例を示します。<b>686897696a7c876b7e</b>します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-236">Example: <b>686897696a7c876b7e</b>.</span></span>| 
  
<a id="ID4EOEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="3f9f2-237">応答本文</span><span class="sxs-lookup"><span data-stu-id="3f9f2-237">Response body</span></span>
 
<a id="ID4EUEAC"></a>

 
### <a name="response-members"></a><span data-ttu-id="3f9f2-238">応答のメンバー</span><span class="sxs-lookup"><span data-stu-id="3f9f2-238">Response Members</span></span>
 
<span data-ttu-id="3f9f2-239">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="3f9f2-239">pagingInfo</span></span> | <span data-ttu-id="3f9f2-240">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="3f9f2-240">pagingInfo</span></span>| <span data-ttu-id="3f9f2-241">セクション</span><span class="sxs-lookup"><span data-stu-id="3f9f2-241">section</span></span>| <span data-ttu-id="3f9f2-242">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-242">Optional.</span></span> <span data-ttu-id="3f9f2-243">MaxItems が要求で指定した場合にだけ表示されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-243">Only present when maxItems is specified in the request.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f9f2-244">continuationToken</span><span class="sxs-lookup"><span data-stu-id="3f9f2-244">continuationToken</span></span>| <span data-ttu-id="3f9f2-245">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3f9f2-245">64-bit unsigned integer</span></span>| <span data-ttu-id="3f9f2-246">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-246">Required.</span></span> <span data-ttu-id="3f9f2-247">フィードバックするどのような値を指定します、 <b>skipItems</b>クエリ パラメーターが必要な場合、その URI の結果の次のページを取得します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-247">Specifies what value to feed back into the <b>skipItems</b> query parameter to get the next page of results for that URI if desired.</span></span> <span data-ttu-id="3f9f2-248">ない場合は<b>pagingInfo</b>を取得するデータの次のページはありませんが返されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-248">If no <b>pagingInfo</b> is returned then there is no next page of data to be obtained.</span></span>| 
| <span data-ttu-id="3f9f2-249">totalCount</span><span class="sxs-lookup"><span data-stu-id="3f9f2-249">totalCount</span></span>| <span data-ttu-id="3f9f2-250">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3f9f2-250">64-bit unsigned integer</span></span>| <span data-ttu-id="3f9f2-251">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-251">Required.</span></span> <span data-ttu-id="3f9f2-252">スコアボードにおける順位エントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-252">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="3f9f2-253">値の例:1234567890</span><span class="sxs-lookup"><span data-stu-id="3f9f2-253">Example value: 1234567890</span></span>| 
 
<span data-ttu-id="3f9f2-254">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="3f9f2-254">leaderboardInfo</span></span> | <span data-ttu-id="3f9f2-255">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="3f9f2-255">leaderboardInfo</span></span>| <span data-ttu-id="3f9f2-256">セクション</span><span class="sxs-lookup"><span data-stu-id="3f9f2-256">section</span></span>| <span data-ttu-id="3f9f2-257">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-257">Required.</span></span> <span data-ttu-id="3f9f2-258">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-258">Always returned.</span></span> <span data-ttu-id="3f9f2-259">要求されたランキングに関するメタデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-259">Contains the metadata about the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f9f2-260">displayName</span><span class="sxs-lookup"><span data-stu-id="3f9f2-260">displayName</span></span>| <span data-ttu-id="3f9f2-261">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-261">string</span></span>| <span data-ttu-id="3f9f2-262">使用されません。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-262">Not used.</span></span>| 
| <span data-ttu-id="3f9f2-263">totalCount</span><span class="sxs-lookup"><span data-stu-id="3f9f2-263">totalCount</span></span>| <span data-ttu-id="3f9f2-264">文字列 (64 ビット符号なし整数)</span><span class="sxs-lookup"><span data-stu-id="3f9f2-264">string (64-bit unsigned integer)</span></span>| <span data-ttu-id="3f9f2-265">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-265">Required.</span></span> <span data-ttu-id="3f9f2-266">スコアボードにおける順位エントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-266">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="3f9f2-267">値の例:1234567890</span><span class="sxs-lookup"><span data-stu-id="3f9f2-267">Example value: 1234567890</span></span>| 
| <span data-ttu-id="3f9f2-268">列</span><span class="sxs-lookup"><span data-stu-id="3f9f2-268">columns</span></span>| <span data-ttu-id="3f9f2-269">array</span><span class="sxs-lookup"><span data-stu-id="3f9f2-269">array</span></span>| <span data-ttu-id="3f9f2-270">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-270">Required.</span></span> <span data-ttu-id="3f9f2-271">スコアボードにおける順位列。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-271">Columns in the leaderboard.</span></span>| 
| <span data-ttu-id="3f9f2-272">displayName</span><span class="sxs-lookup"><span data-stu-id="3f9f2-272">displayName</span></span>| <span data-ttu-id="3f9f2-273">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-273">string</span></span>| <span data-ttu-id="3f9f2-274">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-274">Required.</span></span> <span data-ttu-id="3f9f2-275">スコア_ボード内の列に対応します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-275">Corresponds to a column in the leaderboard.</span></span>| 
| <span data-ttu-id="3f9f2-276">statName</span><span class="sxs-lookup"><span data-stu-id="3f9f2-276">statName</span></span>| <span data-ttu-id="3f9f2-277">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-277">string</span></span>| <span data-ttu-id="3f9f2-278">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-278">Required.</span></span> <span data-ttu-id="3f9f2-279">スコア_ボード内の列に対応します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-279">Corresponds to a column in the leaderboard.</span></span>| 
| <span data-ttu-id="3f9f2-280">type</span><span class="sxs-lookup"><span data-stu-id="3f9f2-280">type</span></span>| <span data-ttu-id="3f9f2-281">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-281">string</span></span>| <span data-ttu-id="3f9f2-282">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-282">Required.</span></span> <span data-ttu-id="3f9f2-283">スコア_ボード内の列に対応します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-283">Corresponds to a column in the leaderboard.</span></span>| 
 
<span data-ttu-id="3f9f2-284">userList</span><span class="sxs-lookup"><span data-stu-id="3f9f2-284">userList</span></span> | <span data-ttu-id="3f9f2-285">userList</span><span class="sxs-lookup"><span data-stu-id="3f9f2-285">userList</span></span>| <span data-ttu-id="3f9f2-286">セクション</span><span class="sxs-lookup"><span data-stu-id="3f9f2-286">section</span></span>| <span data-ttu-id="3f9f2-287">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-287">Required.</span></span> <span data-ttu-id="3f9f2-288">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-288">Always returned.</span></span> <span data-ttu-id="3f9f2-289">要求されたランキングの実際のユーザーのスコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-289">Contains the actual user scores for the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f9f2-290">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="3f9f2-290">gamertag</span></span>| <span data-ttu-id="3f9f2-291">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-291">string</span></span>| <span data-ttu-id="3f9f2-292">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-292">Required.</span></span> <span data-ttu-id="3f9f2-293">ランキング エントリ内のユーザーに対応します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-293">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="3f9f2-294">xuid</span><span class="sxs-lookup"><span data-stu-id="3f9f2-294">xuid</span></span>| <span data-ttu-id="3f9f2-295">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3f9f2-295">64-bit unsigned integer</span></span>| <span data-ttu-id="3f9f2-296">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-296">Required.</span></span> <span data-ttu-id="3f9f2-297">ランキング エントリ内のユーザーに対応します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-297">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="3f9f2-298">百分位数</span><span class="sxs-lookup"><span data-stu-id="3f9f2-298">percentile</span></span>| <span data-ttu-id="3f9f2-299">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-299">string</span></span>| <span data-ttu-id="3f9f2-300">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-300">Required.</span></span> <span data-ttu-id="3f9f2-301">ランキング エントリ内のユーザーに対応します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-301">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="3f9f2-302">ランク</span><span class="sxs-lookup"><span data-stu-id="3f9f2-302">rank</span></span>| <span data-ttu-id="3f9f2-303">string</span><span class="sxs-lookup"><span data-stu-id="3f9f2-303">string</span></span>| <span data-ttu-id="3f9f2-304">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-304">Required.</span></span> <span data-ttu-id="3f9f2-305">ランキング エントリ内のユーザーに対応します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-305">Corresponds to the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="3f9f2-306">値</span><span class="sxs-lookup"><span data-stu-id="3f9f2-306">values</span></span>| <span data-ttu-id="3f9f2-307">array</span><span class="sxs-lookup"><span data-stu-id="3f9f2-307">array</span></span>| <span data-ttu-id="3f9f2-308">必須。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-308">Required.</span></span> <span data-ttu-id="3f9f2-309">コンマ区切りの各値は、スコアボードの列に対応します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-309">Each comma-separated value corresponds to a column in the leaderboard.</span></span>| 
  
<a id="ID4EGKAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="3f9f2-310">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="3f9f2-310">Sample response</span></span>
 
<span data-ttu-id="3f9f2-311">次の要求 URI は、グローバルなランキングのランクをスキップしていますかを示しています。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-311">The following request URI depicts skipping to rank on a global leaderboard.</span></span>
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/TotalFlagsCaptured/columns/deaths?maxItems=3&skipToRank=15000
         
```

 
<span data-ttu-id="3f9f2-312">上記の URI は、次の JSON 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-312">The URI above returns the following JSON response.</span></span>
 

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

 
<span data-ttu-id="3f9f2-313">次の要求 URI は、グローバルなランキングをユーザーにスキップを示しています。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-313">The following request URI depicts skipping to the user on a global leaderboard.</span></span>
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/totalflagscaptured?maxItems=3&skipToUser=2343737892734237
         
```

 
<span data-ttu-id="3f9f2-314">上記の URI は、次の JSON 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="3f9f2-314">The URI above returns the following JSON response.</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="3f9f2-315">関連項目</span><span class="sxs-lookup"><span data-stu-id="3f9f2-315">See also</span></span>
 
<a id="ID4EALAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3f9f2-316">Parent</span><span class="sxs-lookup"><span data-stu-id="3f9f2-316">Parent</span></span> 

[<span data-ttu-id="3f9f2-317">/scids/{scid}/leaderboards/{leaderboardname}</span><span class="sxs-lookup"><span data-stu-id="3f9f2-317">/scids/{scid}/leaderboards/{leaderboardname}</span></span>](uri-scidsscidleaderboardsleaderboardname.md)

   