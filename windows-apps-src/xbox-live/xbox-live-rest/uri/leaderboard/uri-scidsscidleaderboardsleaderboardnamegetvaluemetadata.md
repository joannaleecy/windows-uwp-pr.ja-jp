---
title: GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)
assetID: ee69a9e3-ea91-3cf5-a10a-811762cba892
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardnamegetvaluemetadata.html
description: " GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fad57c5e989d933777c913030faaa594c6bbd059
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623437"
---
# <a name="get-scidsscidleaderboardsleaderboardnameincludevaluemetadata"></a><span data-ttu-id="f4ab6-104">GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)</span><span class="sxs-lookup"><span data-stu-id="f4ab6-104">GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)</span></span>
 
<span data-ttu-id="f4ab6-105">ランキングの値に関連付けられたメタデータと共に定義済みのグローバルなランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-105">Gets a predefined global leaderboard along with any metadata associated with the leaderboard values.</span></span>
 
<span data-ttu-id="f4ab6-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f4ab6-107">注釈</span><span class="sxs-lookup"><span data-stu-id="f4ab6-107">Remarks</span></span>](#ID4EY)
  * [<span data-ttu-id="f4ab6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f4ab6-108">URI parameters</span></span>](#ID4EHB)
  * [<span data-ttu-id="f4ab6-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f4ab6-109">Query string parameters</span></span>](#ID4ESB)
  * [<span data-ttu-id="f4ab6-110">承認</span><span class="sxs-lookup"><span data-stu-id="f4ab6-110">Authorization</span></span>](#ID4EVD)
  * [<span data-ttu-id="f4ab6-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="f4ab6-111">Effect of privacy settings on resource</span></span>](#ID4EQE)
  * [<span data-ttu-id="f4ab6-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f4ab6-112">Required Request Headers</span></span>](#ID4EZE)
  * [<span data-ttu-id="f4ab6-113">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f4ab6-113">Optional Request Headers</span></span>](#ID4EOG)
  * [<span data-ttu-id="f4ab6-114">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f4ab6-114">HTTP status codes</span></span>](#ID4EOH)
  * [<span data-ttu-id="f4ab6-115">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f4ab6-115">Response headers</span></span>](#ID4EFDAC)
  * [<span data-ttu-id="f4ab6-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="f4ab6-116">Response body</span></span>](#ID4ECFAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a><span data-ttu-id="f4ab6-117">注釈</span><span class="sxs-lookup"><span data-stu-id="f4ab6-117">Remarks</span></span>
 
<span data-ttu-id="f4ab6-118">でしょうか。 含める valuemetadata = クエリ パラメーターがランキングの値に関連付けられたメタデータを含めるへの応答を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-118">The ?include=valuemetadata query parameter allows the response to include any metadata associated with the leaderboard values.</span></span> <span data-ttu-id="f4ab6-119">値のメタデータには、指定されたクライアントが含まれています。 モデルとの競合の追跡に最適な時間を実現するために使用される、自動車の色など、値に関連付けられたデータ。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-119">The value metadata contains client specified data associated with the value, such as the model and color of a car used to achieve a best time on a race track.</span></span>
 
<span data-ttu-id="f4ab6-120">値のメタデータは、スコアボード自体ではなく、スコアボードの基に、ユーザーの状態で定義されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-120">Value metadata is defined on the user stat that the leaderboard is based on, not on the leaderboard itself.</span></span>
 
<span data-ttu-id="f4ab6-121">ランキング Api はすべて読み取り専用し、したがってのみ GET 動詞をサポートします。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-121">Leaderboard APIs are all read-only and therefore only support the GET verb.</span></span> <span data-ttu-id="f4ab6-122">ランクと並べ替え済みの「ページ」データ プラットフォームを使用して記述されている個々 のユーザーの統計から派生した統計をインデックス付きのプレーヤーが反映されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-122">They reflect ranked and sorted "pages" of indexed player stats that are derived from individual user stats that were written via the Data Platform.</span></span> <span data-ttu-id="f4ab6-123">ランキングの完全なインデックスが大きくなることができ、全体のいずれかを確認する呼び出し元が今後は、この URI がそのためにそのランキングに対して表示するビューの種類は呼び出し元を許可するいくつかのクエリ文字列引数をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-123">Full leaderboard indexes can be quite large, and callers will never ask to see one in its entirety, therefore this URI supports several query string arguments that allow a caller to be specific about what kind of view it wants to see against that leaderboard.</span></span>
 
<span data-ttu-id="f4ab6-124">GET 操作は、この 1 回または複数回実行された場合、同じ結果が生成されますのですべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-124">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4EHB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f4ab6-125">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f4ab6-125">URI parameters</span></span>
 
| <span data-ttu-id="f4ab6-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f4ab6-126">Parameter</span></span>| <span data-ttu-id="f4ab6-127">種類</span><span class="sxs-lookup"><span data-stu-id="f4ab6-127">Type</span></span>| <span data-ttu-id="f4ab6-128">説明</span><span class="sxs-lookup"><span data-stu-id="f4ab6-128">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f4ab6-129">scid</span><span class="sxs-lookup"><span data-stu-id="f4ab6-129">scid</span></span>| <span data-ttu-id="f4ab6-130">GUID</span><span class="sxs-lookup"><span data-stu-id="f4ab6-130">GUID</span></span>| <span data-ttu-id="f4ab6-131">アクセスされるリソースを含むサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-131">Identifier of the service configuration which contains the resource being accessed.</span></span>| 
| <span data-ttu-id="f4ab6-132">leaderboardname</span><span class="sxs-lookup"><span data-stu-id="f4ab6-132">leaderboardname</span></span>| <span data-ttu-id="f4ab6-133">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-133">string</span></span>| <span data-ttu-id="f4ab6-134">アクセスされる定義済みのランキング リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-134">Unique identifier of the predefined leaderboard resource being accessed.</span></span>| 
  
<a id="ID4ESB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="f4ab6-135">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f4ab6-135">Query string parameters</span></span>
 
| <span data-ttu-id="f4ab6-136">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f4ab6-136">Parameter</span></span>| <span data-ttu-id="f4ab6-137">種類</span><span class="sxs-lookup"><span data-stu-id="f4ab6-137">Type</span></span>| <span data-ttu-id="f4ab6-138">説明</span><span class="sxs-lookup"><span data-stu-id="f4ab6-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4ab6-139">含める valuemetadata を =</span><span class="sxs-lookup"><span data-stu-id="f4ab6-139">include=valuemetadata</span></span>| <span data-ttu-id="f4ab6-140">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-140">string</span></span>| <span data-ttu-id="f4ab6-141">応答にランキングの値に関連付けられた任意の値のメタデータが含まれていることを示します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-141">Indicates that the response includes any value metadata associated with the leaderboard values.</span></span>| 
| <span data-ttu-id="f4ab6-142">maxItems</span><span class="sxs-lookup"><span data-stu-id="f4ab6-142">maxItems</span></span>| <span data-ttu-id="f4ab6-143">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f4ab6-143">32-bit unsigned integer</span></span>| <span data-ttu-id="f4ab6-144">ランキング ページの結果で返されるレコードの最大数。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-144">Maximum number of leaderboard records to return in a page of results.</span></span> <span data-ttu-id="f4ab6-145">指定されていない場合、既定の数には、(10) が返されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-145">If not specified, a default number will be returned (10).</span></span> <span data-ttu-id="f4ab6-146">MaxItems の最大値は、まだ未定義が大規模なデータ セットを回避する、ため、この値が対象おそらく最大呼び出しごとに UI が処理できるチューナーします。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-146">The max value for maxItems is still undefined, but we want to avoid large data sets, so this value should probably target the largest set that a tuner UI could handle per call.</span></span>| 
| <span data-ttu-id="f4ab6-147">skipToRank</span><span class="sxs-lookup"><span data-stu-id="f4ab6-147">skipToRank</span></span>| <span data-ttu-id="f4ab6-148">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f4ab6-148">32-bit unsigned integer</span></span>| <span data-ttu-id="f4ab6-149">以降では、指定したランキング ランクの結果のページを返します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-149">Return a page of results starting with the specified leaderboard rank.</span></span> <span data-ttu-id="f4ab6-150">残りの結果を順位で並べ替え順序になります。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-150">The rest of the results will be in sort order by rank.</span></span> <span data-ttu-id="f4ab6-151">このクエリ文字列は、[次へ] の「ページ」の結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-151">This query string can return a continuation token which can be fed back into a subsequent query to get "the next page" of results.</span></span>| 
| <span data-ttu-id="f4ab6-152">skipToUser</span><span class="sxs-lookup"><span data-stu-id="f4ab6-152">skipToUser</span></span>| <span data-ttu-id="f4ab6-153">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-153">string</span></span>| <span data-ttu-id="f4ab6-154">そのユーザーのランクやスコアに関係なく、指定のゲーマー xuid の周囲のスコアボードの結果のページを返します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-154">Return a page of leaderboard results around the specified gamer xuid, regardless of that user's rank or score.</span></span> <span data-ttu-id="f4ab6-155">ページは、stat ランキング ビューの中央にまたは定義済みのビューのページの最後の位置で指定したユーザーのパーセン タイル順位で並べ替えられます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-155">The page will be ordered by percentile rank with the specified user in the last position of the page for predefined views, or in the middle for stat leaderboard views.</span></span> <span data-ttu-id="f4ab6-156">この種類のクエリに対して提供される continuationToken はありません。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-156">There is no continuationToken provided for this type of query.</span></span>| 
| <span data-ttu-id="f4ab6-157">continuationToken</span><span class="sxs-lookup"><span data-stu-id="f4ab6-157">continuationToken</span></span>| <span data-ttu-id="f4ab6-158">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-158">string</span></span>| <span data-ttu-id="f4ab6-159">前の呼び出しで、continuationToken が返された場合はし、呼び出し元ことができますを送り返すそのトークンを"現状有姿結果の次のページを取得するクエリ文字列で。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-159">If a previous call returned a continuationToken, then the caller can pass back that token "as is" in a query string to get the next page of results.</span></span>| 
  
<a id="ID4EVD"></a>

 
## <a name="authorization"></a><span data-ttu-id="f4ab6-160">Authorization</span><span class="sxs-lookup"><span data-stu-id="f4ab6-160">Authorization</span></span>
 
<span data-ttu-id="f4ab6-161">コンテンツの分離とアクセス制御のシナリオで実装された承認ロジックがあります。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-161">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>
 
   * <span data-ttu-id="f4ab6-162">呼び出し元の要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングとユーザーの両方の統計情報を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-162">Both leaderboards and user stats can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="f4ab6-163">書き込みは、当然ながら、データ プラットフォームでサポートされているクライアントに制限されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-163">Writes are obviously limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="f4ab6-164">タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-164">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="f4ab6-165">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-165">Leaderboards are open statistics.</span></span> <span data-ttu-id="f4ab6-166">統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-166">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="f4ab6-167">サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-167">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>
  
<span data-ttu-id="f4ab6-168">チェックの擬似コードのようになります。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-168">Pseudo-code for the check looks like this:</span></span>
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4EQE"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="f4ab6-169">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="f4ab6-169">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="f4ab6-170">ランキング データを読み取る場合は、プライバシーに関するチェックは行われません。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-170">No privacy checks are performed when reading leaderboard data.</span></span>
  
<a id="ID4EZE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="f4ab6-171">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f4ab6-171">Required Request Headers</span></span>
 
| <span data-ttu-id="f4ab6-172">Header</span><span class="sxs-lookup"><span data-stu-id="f4ab6-172">Header</span></span>| <span data-ttu-id="f4ab6-173">説明</span><span class="sxs-lookup"><span data-stu-id="f4ab6-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4ab6-174">Authorization</span><span class="sxs-lookup"><span data-stu-id="f4ab6-174">Authorization</span></span>| <span data-ttu-id="f4ab6-175">[String]。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-175">String.</span></span> <span data-ttu-id="f4ab6-176">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-176">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="f4ab6-177">値の例:<b>XBL3.0 x=&lt;userhash>;&lt;token></b></span><span class="sxs-lookup"><span data-stu-id="f4ab6-177">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b></span></span>| 
| <span data-ttu-id="f4ab6-178">X Xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="f4ab6-178">X-Xbl-Contract-Version</span></span>| <span data-ttu-id="f4ab6-179">[String]。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-179">String.</span></span> <span data-ttu-id="f4ab6-180">使用する API のバージョンを示します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-180">Indicates which version of the API to use.</span></span> <span data-ttu-id="f4ab6-181">この値は、値のメタデータを応答に含めるために、「3」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-181">This value must be set to "3" in order to include value metadata in the response.</span></span>| 
| <span data-ttu-id="f4ab6-182">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="f4ab6-182">X-RequestedServiceVersion</span></span>| <span data-ttu-id="f4ab6-183">[String]。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-183">String.</span></span> <span data-ttu-id="f4ab6-184">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-184">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="f4ab6-185">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="f4ab6-185">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="f4ab6-186">OK</span><span class="sxs-lookup"><span data-stu-id="f4ab6-186">Accept</span></span>| <span data-ttu-id="f4ab6-187">[String]。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-187">String.</span></span> <span data-ttu-id="f4ab6-188">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-188">Content-Types that are acceptable.</span></span> <span data-ttu-id="f4ab6-189">値の例:<b>アプリケーション/json</b></span><span class="sxs-lookup"><span data-stu-id="f4ab6-189">Example value: <b>application/json</b></span></span>| 
  
<a id="ID4EOG"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="f4ab6-190">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f4ab6-190">Optional Request Headers</span></span>
 
| <span data-ttu-id="f4ab6-191">Header</span><span class="sxs-lookup"><span data-stu-id="f4ab6-191">Header</span></span>| <span data-ttu-id="f4ab6-192">説明</span><span class="sxs-lookup"><span data-stu-id="f4ab6-192">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4ab6-193">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="f4ab6-193">If-None-Match</span></span>| <span data-ttu-id="f4ab6-194">[String]。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-194">String.</span></span> <span data-ttu-id="f4ab6-195">クライアント キャッシュをサポートしている場合に使用されるエンティティ タグ。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-195">Entity tag, used if client supports caching.</span></span> <span data-ttu-id="f4ab6-196">値の例:<b>"686897696a7c876b7e"</b></span><span class="sxs-lookup"><span data-stu-id="f4ab6-196">Example value: <b>"686897696a7c876b7e"</b></span></span>|  | 
  
<a id="ID4EOH"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="f4ab6-197">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f4ab6-197">HTTP status codes</span></span>
 
<span data-ttu-id="f4ab6-198">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-198">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="f4ab6-199">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-199">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="f4ab6-200">コード</span><span class="sxs-lookup"><span data-stu-id="f4ab6-200">Code</span></span>| <span data-ttu-id="f4ab6-201">理由語句</span><span class="sxs-lookup"><span data-stu-id="f4ab6-201">Reason phrase</span></span>| <span data-ttu-id="f4ab6-202">説明</span><span class="sxs-lookup"><span data-stu-id="f4ab6-202">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4ab6-203">200</span><span class="sxs-lookup"><span data-stu-id="f4ab6-203">200</span></span>| <span data-ttu-id="f4ab6-204">OK</span><span class="sxs-lookup"><span data-stu-id="f4ab6-204">OK</span></span>| <span data-ttu-id="f4ab6-205">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-205">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="f4ab6-206">304</span><span class="sxs-lookup"><span data-stu-id="f4ab6-206">304</span></span>| <span data-ttu-id="f4ab6-207">変更されていません</span><span class="sxs-lookup"><span data-stu-id="f4ab6-207">Not Modified</span></span>| <span data-ttu-id="f4ab6-208">リソースされていない最後の要求以降に変更します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-208">Resource not been modified since last requested.</span></span>| 
| <span data-ttu-id="f4ab6-209">400</span><span class="sxs-lookup"><span data-stu-id="f4ab6-209">400</span></span>| <span data-ttu-id="f4ab6-210">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="f4ab6-210">Bad Request</span></span>| <span data-ttu-id="f4ab6-211">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-211">Service could not understand malformed request.</span></span> <span data-ttu-id="f4ab6-212">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-212">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="f4ab6-213">401</span><span class="sxs-lookup"><span data-stu-id="f4ab6-213">401</span></span>| <span data-ttu-id="f4ab6-214">権限がありません</span><span class="sxs-lookup"><span data-stu-id="f4ab6-214">Unauthorized</span></span>| <span data-ttu-id="f4ab6-215">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-215">The request requires user authentication.</span></span>| 
| <span data-ttu-id="f4ab6-216">403</span><span class="sxs-lookup"><span data-stu-id="f4ab6-216">403</span></span>| <span data-ttu-id="f4ab6-217">Forbidden</span><span class="sxs-lookup"><span data-stu-id="f4ab6-217">Forbidden</span></span>| <span data-ttu-id="f4ab6-218">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-218">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="f4ab6-219">404</span><span class="sxs-lookup"><span data-stu-id="f4ab6-219">404</span></span>| <span data-ttu-id="f4ab6-220">検出不可</span><span class="sxs-lookup"><span data-stu-id="f4ab6-220">Not Found</span></span>| <span data-ttu-id="f4ab6-221">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-221">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="f4ab6-222">406</span><span class="sxs-lookup"><span data-stu-id="f4ab6-222">406</span></span>| <span data-ttu-id="f4ab6-223">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="f4ab6-223">Not Acceptable</span></span>| <span data-ttu-id="f4ab6-224">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-224">Resource version is not supported.</span></span>| 
| <span data-ttu-id="f4ab6-225">408</span><span class="sxs-lookup"><span data-stu-id="f4ab6-225">408</span></span>| <span data-ttu-id="f4ab6-226">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="f4ab6-226">Request Timeout</span></span>| <span data-ttu-id="f4ab6-227">リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-227">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
  
<a id="ID4EFDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="f4ab6-228">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f4ab6-228">Response headers</span></span>
 
| <span data-ttu-id="f4ab6-229">Header</span><span class="sxs-lookup"><span data-stu-id="f4ab6-229">Header</span></span>| <span data-ttu-id="f4ab6-230">種類</span><span class="sxs-lookup"><span data-stu-id="f4ab6-230">Type</span></span>| <span data-ttu-id="f4ab6-231">説明</span><span class="sxs-lookup"><span data-stu-id="f4ab6-231">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4ab6-232">Content-Type</span><span class="sxs-lookup"><span data-stu-id="f4ab6-232">Content-Type</span></span>| <span data-ttu-id="f4ab6-233">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-233">string</span></span>| <span data-ttu-id="f4ab6-234">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-234">Required.</span></span> <span data-ttu-id="f4ab6-235">応答の本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-235">The MIME type of the body of the response.</span></span> <span data-ttu-id="f4ab6-236">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-236">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="f4ab6-237">Content-Length</span><span class="sxs-lookup"><span data-stu-id="f4ab6-237">Content-Length</span></span>| <span data-ttu-id="f4ab6-238">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-238">string</span></span>| <span data-ttu-id="f4ab6-239">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-239">Required.</span></span> <span data-ttu-id="f4ab6-240">応答で送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-240">The number of bytes being sent in the response.</span></span> <span data-ttu-id="f4ab6-241">以下に例を示します。<b>232</b>.</span><span class="sxs-lookup"><span data-stu-id="f4ab6-241">Example: <b>232</b>.</span></span>| 
| <span data-ttu-id="f4ab6-242">ETag</span><span class="sxs-lookup"><span data-stu-id="f4ab6-242">ETag</span></span>| <span data-ttu-id="f4ab6-243">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-243">string</span></span>| <span data-ttu-id="f4ab6-244">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-244">Optional.</span></span> <span data-ttu-id="f4ab6-245">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-245">Used for cache optimization.</span></span> <span data-ttu-id="f4ab6-246">以下に例を示します。<b>686897696a7c876b7e</b>します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-246">Example: <b>686897696a7c876b7e</b>.</span></span>| 
  
<a id="ID4ECFAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="f4ab6-247">応答本文</span><span class="sxs-lookup"><span data-stu-id="f4ab6-247">Response body</span></span>
 
<a id="ID4EIFAC"></a>

 
### <a name="response-members"></a><span data-ttu-id="f4ab6-248">応答のメンバー</span><span class="sxs-lookup"><span data-stu-id="f4ab6-248">Response Members</span></span>
 
<span data-ttu-id="f4ab6-249">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="f4ab6-249">pagingInfo</span></span> | <span data-ttu-id="f4ab6-250">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="f4ab6-250">pagingInfo</span></span>| <span data-ttu-id="f4ab6-251">セクション</span><span class="sxs-lookup"><span data-stu-id="f4ab6-251">section</span></span>| <span data-ttu-id="f4ab6-252">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-252">Optional.</span></span> <span data-ttu-id="f4ab6-253">MaxItems が要求で指定した場合にだけ表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-253">Only present when maxItems is specified in the request.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4ab6-254">continuationToken</span><span class="sxs-lookup"><span data-stu-id="f4ab6-254">continuationToken</span></span>| <span data-ttu-id="f4ab6-255">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f4ab6-255">64-bit unsigned integer</span></span>| <span data-ttu-id="f4ab6-256">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-256">Required.</span></span> <span data-ttu-id="f4ab6-257">フィードバックするどのような値を指定します、 <b>skipItems</b>クエリ パラメーターが必要な場合、その URI の結果の次のページを取得します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-257">Specifies what value to feed back into the <b>skipItems</b> query parameter to get the next page of results for that URI if desired.</span></span> <span data-ttu-id="f4ab6-258">ない場合は<b>pagingInfo</b>を取得するデータの次のページはありませんが返されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-258">If no <b>pagingInfo</b> is returned then there is no next page of data to be obtained.</span></span>| 
| <span data-ttu-id="f4ab6-259">totalItems</span><span class="sxs-lookup"><span data-stu-id="f4ab6-259">totalItems</span></span>| <span data-ttu-id="f4ab6-260">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f4ab6-260">64-bit unsigned integer</span></span>| <span data-ttu-id="f4ab6-261">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-261">Required.</span></span> <span data-ttu-id="f4ab6-262">スコアボードにおける順位エントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-262">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="f4ab6-263">値の例:1234567890</span><span class="sxs-lookup"><span data-stu-id="f4ab6-263">Example value: 1234567890</span></span>| 
 
<span data-ttu-id="f4ab6-264">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="f4ab6-264">leaderboardInfo</span></span> | <span data-ttu-id="f4ab6-265">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="f4ab6-265">leaderboardInfo</span></span>| <span data-ttu-id="f4ab6-266">セクション</span><span class="sxs-lookup"><span data-stu-id="f4ab6-266">section</span></span>| <span data-ttu-id="f4ab6-267">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-267">Required.</span></span> <span data-ttu-id="f4ab6-268">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-268">Always returned.</span></span> <span data-ttu-id="f4ab6-269">要求されたランキングに関するメタデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-269">Contains the metadata about the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4ab6-270">displayName</span><span class="sxs-lookup"><span data-stu-id="f4ab6-270">displayName</span></span>| <span data-ttu-id="f4ab6-271">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-271">string</span></span>| <span data-ttu-id="f4ab6-272">使用されません。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-272">Not used.</span></span>| 
| <span data-ttu-id="f4ab6-273">totalCount</span><span class="sxs-lookup"><span data-stu-id="f4ab6-273">totalCount</span></span>| <span data-ttu-id="f4ab6-274">文字列 (64 ビット符号なし整数)</span><span class="sxs-lookup"><span data-stu-id="f4ab6-274">string (64-bit unsigned integer)</span></span>| <span data-ttu-id="f4ab6-275">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-275">Required.</span></span> <span data-ttu-id="f4ab6-276">スコアボードにおける順位エントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-276">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="f4ab6-277">値の例:1234567890</span><span class="sxs-lookup"><span data-stu-id="f4ab6-277">Example value: 1234567890</span></span>| 
| <span data-ttu-id="f4ab6-278">columnDefinition</span><span class="sxs-lookup"><span data-stu-id="f4ab6-278">columnDefinition</span></span>| <span data-ttu-id="f4ab6-279">JSON オブジェクト</span><span class="sxs-lookup"><span data-stu-id="f4ab6-279">JSON object</span></span>| <span data-ttu-id="f4ab6-280">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-280">Required.</span></span> <span data-ttu-id="f4ab6-281">スコアボードにおける順位列をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-281">Describes the column in the leaderboard.</span></span>| 
| <span data-ttu-id="f4ab6-282">columnDefinition.displayName</span><span class="sxs-lookup"><span data-stu-id="f4ab6-282">columnDefinition.displayName</span></span>| <span data-ttu-id="f4ab6-283">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-283">string</span></span>| <span data-ttu-id="f4ab6-284">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-284">Required.</span></span> <span data-ttu-id="f4ab6-285">スコアボードにおける列のわかりやすい名前。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-285">A descriptive name of the column in the leaderboard.</span></span>| 
| <span data-ttu-id="f4ab6-286">columnDefinition.statName</span><span class="sxs-lookup"><span data-stu-id="f4ab6-286">columnDefinition.statName</span></span>| <span data-ttu-id="f4ab6-287">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-287">string</span></span>| <span data-ttu-id="f4ab6-288">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-288">Required.</span></span> <span data-ttu-id="f4ab6-289">ユーザー統計に基づく、スコアボードの名前。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-289">The name of the user stat that the leaderboard is based on.</span></span>| 
| <span data-ttu-id="f4ab6-290">columnDefinition.type</span><span class="sxs-lookup"><span data-stu-id="f4ab6-290">columnDefinition.type</span></span>| <span data-ttu-id="f4ab6-291">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-291">string</span></span>| <span data-ttu-id="f4ab6-292">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-292">Required.</span></span> <span data-ttu-id="f4ab6-293">列にユーザー状態のデータ型。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-293">The data type of the user stat in the column.</span></span>| 
 
<span data-ttu-id="f4ab6-294">userList</span><span class="sxs-lookup"><span data-stu-id="f4ab6-294">userList</span></span> | <span data-ttu-id="f4ab6-295">userList</span><span class="sxs-lookup"><span data-stu-id="f4ab6-295">userList</span></span>| <span data-ttu-id="f4ab6-296">セクション</span><span class="sxs-lookup"><span data-stu-id="f4ab6-296">section</span></span>| <span data-ttu-id="f4ab6-297">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-297">Required.</span></span> <span data-ttu-id="f4ab6-298">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-298">Always returned.</span></span> <span data-ttu-id="f4ab6-299">要求されたランキングの実際のユーザーのスコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-299">Contains the actual user scores for the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4ab6-300">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="f4ab6-300">gamertag</span></span>| <span data-ttu-id="f4ab6-301">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-301">string</span></span>| <span data-ttu-id="f4ab6-302">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-302">Required.</span></span> <span data-ttu-id="f4ab6-303">ランキング エントリ内のユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-303">The gamertag of the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="f4ab6-304">xuid</span><span class="sxs-lookup"><span data-stu-id="f4ab6-304">xuid</span></span>| <span data-ttu-id="f4ab6-305">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f4ab6-305">64-bit unsigned integer</span></span>| <span data-ttu-id="f4ab6-306">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-306">Required.</span></span> <span data-ttu-id="f4ab6-307">ランキング エントリ内のユーザーの Xbox ユーザー ID。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-307">The Xbox user ID of the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="f4ab6-308">百分位数</span><span class="sxs-lookup"><span data-stu-id="f4ab6-308">percentile</span></span>| <span data-ttu-id="f4ab6-309">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-309">string</span></span>| <span data-ttu-id="f4ab6-310">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-310">Required.</span></span> <span data-ttu-id="f4ab6-311">スコアボードにおけるユーザーの百分位数のランク。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-311">The user's percentile rank in the leaderboard.</span></span>| 
| <span data-ttu-id="f4ab6-312">ランク</span><span class="sxs-lookup"><span data-stu-id="f4ab6-312">rank</span></span>| <span data-ttu-id="f4ab6-313">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-313">string</span></span>| <span data-ttu-id="f4ab6-314">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-314">Required.</span></span> <span data-ttu-id="f4ab6-315">スコアボードにおけるユーザーの数値のランク。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-315">The user's numeric rank in the leaderboard.</span></span>| 
| <span data-ttu-id="f4ab6-316">value</span><span class="sxs-lookup"><span data-stu-id="f4ab6-316">value</span></span>| <span data-ttu-id="f4ab6-317">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-317">string</span></span>| <span data-ttu-id="f4ab6-318">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-318">Required.</span></span> <span data-ttu-id="f4ab6-319">スコアボードの基になる統計のユーザーの値。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-319">The user's value of the stat on which the leaderboard is based.</span></span>| 
| <span data-ttu-id="f4ab6-320">valueMetadata</span><span class="sxs-lookup"><span data-stu-id="f4ab6-320">valueMetadata</span></span>| <span data-ttu-id="f4ab6-321">string</span><span class="sxs-lookup"><span data-stu-id="f4ab6-321">string</span></span>| <span data-ttu-id="f4ab6-322">必須。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-322">Required.</span></span> <span data-ttu-id="f4ab6-323">文字列のコンマ区切り形式の文字列ペア"\"名前\":\"値\",..."</span><span class="sxs-lookup"><span data-stu-id="f4ab6-323">A string of comma separated string pairs, in the format "\"name\" : \"value\", ..."</span></span>

<span data-ttu-id="f4ab6-324">この値は空の文字列でメタデータがない場合 |。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-324">If there is no metadata, this value is an empty string.|</span></span> 
  
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="f4ab6-325">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="f4ab6-325">Sample response</span></span>
 
<span data-ttu-id="f4ab6-326">次の要求 URI は、グローバルなランキングのランクをスキップしていますかを示しています。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-326">The following request URI depicts skipping to rank on a global leaderboard.</span></span>
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/TotalFlagsCaptured?include=valuemetadata&maxItems=3&skipToRank=15000
         
```

 
<span data-ttu-id="f4ab6-327">値のメタデータを返すために、次のヘッダーを指定も必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-327">In order to return value metadata, the following header must also be specified.</span></span>
 

```cpp
X-Xbl-Contract-Version : 3
          
```

 
<span data-ttu-id="f4ab6-328">上記の URI は、次の JSON 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="f4ab6-328">The URI above returns the following JSON response.</span></span>
 

```cpp
{
    "pagingInfo": {
        "continuationToken": "15003",
        "totalItems": 23437
    },
    "leaderboardInfo": {
        "displayName": "Total flags captured",
        "totalCount": 23437,
        "columnDefinition" : 
            {
                "displayName": "Flags Captured",
                "statName": "flagscaptured",
                "type": "Integer"
            }
    },
    "userList": [
        {
            "gamertag": "WarriorSaint",
            "xuid": "1234567890123444",
            "percentile": 0.64,
            "rank": 15000,
            "value": "1002",
            "valuemetadata" : "{\"color\" : \"silver\",\"weight\" : 2000, \"israining\" : false}"
        },
        {
            "gamertag": "xxxSniper39",
            "xuid": "1234567890123555",
            "percentile": 0.64,
            "rank": 15001,
            "value": "993",
            "valuemetadata" : "{\"color\" : \"silver\",\"weight\" : 2020, \"israining\" : true}"
 
        },
        {
            "gamertag": "WhockaWhocka",
            "xuid": "1234567890123666",
            "percentile": 0.64,
            "rank": 15002,
            "value": "700",
            "valuemetadata" : "{\"color\" : \"red\",\"weight\" : 300, \"israining\" : false}"
        }
    ]
}
         
```

   
<a id="ID4E6LAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f4ab6-329">関連項目</span><span class="sxs-lookup"><span data-stu-id="f4ab6-329">See also</span></span>
 
<a id="ID4EBMAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f4ab6-330">Parent</span><span class="sxs-lookup"><span data-stu-id="f4ab6-330">Parent</span></span> 

[<span data-ttu-id="f4ab6-331">/scids/{scid}/leaderboards/{leaderboardname}</span><span class="sxs-lookup"><span data-stu-id="f4ab6-331">/scids/{scid}/leaderboards/{leaderboardname}</span></span>](uri-scidsscidleaderboardsleaderboardname.md)

   