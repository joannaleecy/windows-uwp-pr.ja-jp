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
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8741013"
---
# <a name="get-scidsscidleaderboardsleaderboardnameincludevaluemetadata"></a><span data-ttu-id="6f692-104">GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)</span><span class="sxs-lookup"><span data-stu-id="6f692-104">GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)</span></span>
 
<span data-ttu-id="6f692-105">ランキングの値に関連付けられたメタデータと共に定義済みグローバル ランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="6f692-105">Gets a predefined global leaderboard along with any metadata associated with the leaderboard values.</span></span>
 
<span data-ttu-id="6f692-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="6f692-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="6f692-107">注釈</span><span class="sxs-lookup"><span data-stu-id="6f692-107">Remarks</span></span>](#ID4EY)
  * [<span data-ttu-id="6f692-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6f692-108">URI parameters</span></span>](#ID4EHB)
  * [<span data-ttu-id="6f692-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="6f692-109">Query string parameters</span></span>](#ID4ESB)
  * [<span data-ttu-id="6f692-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="6f692-110">Authorization</span></span>](#ID4EVD)
  * [<span data-ttu-id="6f692-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="6f692-111">Effect of privacy settings on resource</span></span>](#ID4EQE)
  * [<span data-ttu-id="6f692-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f692-112">Required Request Headers</span></span>](#ID4EZE)
  * [<span data-ttu-id="6f692-113">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f692-113">Optional Request Headers</span></span>](#ID4EOG)
  * [<span data-ttu-id="6f692-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="6f692-114">HTTP status codes</span></span>](#ID4EOH)
  * [<span data-ttu-id="6f692-115">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f692-115">Response headers</span></span>](#ID4EFDAC)
  * [<span data-ttu-id="6f692-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="6f692-116">Response body</span></span>](#ID4ECFAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a><span data-ttu-id="6f692-117">注釈</span><span class="sxs-lookup"><span data-stu-id="6f692-117">Remarks</span></span>
 
<span data-ttu-id="6f692-118">かどうか。 含める = valuemetadata クエリ パラメーターは、ランキングの値に関連付けられたメタデータを含めるへの応答をことができます。</span><span class="sxs-lookup"><span data-stu-id="6f692-118">The ?include=valuemetadata query parameter allows the response to include any metadata associated with the leaderboard values.</span></span> <span data-ttu-id="6f692-119">値のメタデータには、指定されたクライアントが含まれているデータ モデルやレース トラックに最適な時間を実現するために使用された車の色など、値に関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="6f692-119">The value metadata contains client specified data associated with the value, such as the model and color of a car used to achieve a best time on a race track.</span></span>
 
<span data-ttu-id="6f692-120">値のメタデータは、ランキングのランキング自体ではなく基になっているユーザー統計で定義されます。</span><span class="sxs-lookup"><span data-stu-id="6f692-120">Value metadata is defined on the user stat that the leaderboard is based on, not on the leaderboard itself.</span></span>
 
<span data-ttu-id="6f692-121">ランキング Api すべて読み取り専用あり、したがってのみ GET 動詞をサポートします。</span><span class="sxs-lookup"><span data-stu-id="6f692-121">Leaderboard APIs are all read-only and therefore only support the GET verb.</span></span> <span data-ttu-id="6f692-122">ランクのページと並べ替えられた「ページ」は、個々 のユーザーの統計データ プラットフォームによって書き込まれたから派生されたインデックス付きのプレイヤーの統計が反映されます。</span><span class="sxs-lookup"><span data-stu-id="6f692-122">They reflect ranked and sorted "pages" of indexed player stats that are derived from individual user stats that were written via the Data Platform.</span></span> <span data-ttu-id="6f692-123">完全なランキングのインデックスが大きくなることができ、呼び出し元は完全にいずれかを確認することはありませんが求められます、したがってこの URI はそのランキングを表示する必要があるビューの種類について具体的に説明する呼び出し元を許可するいくつかのクエリ文字列引数をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="6f692-123">Full leaderboard indexes can be quite large, and callers will never ask to see one in its entirety, therefore this URI supports several query string arguments that allow a caller to be specific about what kind of view it wants to see against that leaderboard.</span></span>
 
<span data-ttu-id="6f692-124">これと同じ結果に 1 回または複数回実行している場合、GET 操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="6f692-124">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4EHB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="6f692-125">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6f692-125">URI parameters</span></span>
 
| <span data-ttu-id="6f692-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6f692-126">Parameter</span></span>| <span data-ttu-id="6f692-127">型</span><span class="sxs-lookup"><span data-stu-id="6f692-127">Type</span></span>| <span data-ttu-id="6f692-128">説明</span><span class="sxs-lookup"><span data-stu-id="6f692-128">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6f692-129">scid</span><span class="sxs-lookup"><span data-stu-id="6f692-129">scid</span></span>| <span data-ttu-id="6f692-130">GUID</span><span class="sxs-lookup"><span data-stu-id="6f692-130">GUID</span></span>| <span data-ttu-id="6f692-131">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="6f692-131">Identifier of the service configuration which contains the resource being accessed.</span></span>| 
| <span data-ttu-id="6f692-132">leaderboardname</span><span class="sxs-lookup"><span data-stu-id="6f692-132">leaderboardname</span></span>| <span data-ttu-id="6f692-133">string</span><span class="sxs-lookup"><span data-stu-id="6f692-133">string</span></span>| <span data-ttu-id="6f692-134">アクセス対象の定義済みのランキング リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="6f692-134">Unique identifier of the predefined leaderboard resource being accessed.</span></span>| 
  
<a id="ID4ESB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="6f692-135">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="6f692-135">Query string parameters</span></span>
 
| <span data-ttu-id="6f692-136">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6f692-136">Parameter</span></span>| <span data-ttu-id="6f692-137">型</span><span class="sxs-lookup"><span data-stu-id="6f692-137">Type</span></span>| <span data-ttu-id="6f692-138">説明</span><span class="sxs-lookup"><span data-stu-id="6f692-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6f692-139">含める = valuemetadata</span><span class="sxs-lookup"><span data-stu-id="6f692-139">include=valuemetadata</span></span>| <span data-ttu-id="6f692-140">string</span><span class="sxs-lookup"><span data-stu-id="6f692-140">string</span></span>| <span data-ttu-id="6f692-141">応答には、ランキングの値に関連付けられた値メタデータが含まれていることを示します。</span><span class="sxs-lookup"><span data-stu-id="6f692-141">Indicates that the response includes any value metadata associated with the leaderboard values.</span></span>| 
| <span data-ttu-id="6f692-142">maxItems</span><span class="sxs-lookup"><span data-stu-id="6f692-142">maxItems</span></span>| <span data-ttu-id="6f692-143">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6f692-143">32-bit unsigned integer</span></span>| <span data-ttu-id="6f692-144">ランキング結果のページで、返されるレコードの最大数。</span><span class="sxs-lookup"><span data-stu-id="6f692-144">Maximum number of leaderboard records to return in a page of results.</span></span> <span data-ttu-id="6f692-145">指定しない場合、既定の数は (10) 返されます。</span><span class="sxs-lookup"><span data-stu-id="6f692-145">If not specified, a default number will be returned (10).</span></span> <span data-ttu-id="6f692-146">MaxItems の最大値がまだ未定義が、大規模なデータ セットを回避する、ため、この値をターゲットにする必要があります可能性があります、最大チューナー呼び出しごと UI を処理します。</span><span class="sxs-lookup"><span data-stu-id="6f692-146">The max value for maxItems is still undefined, but we want to avoid large data sets, so this value should probably target the largest set that a tuner UI could handle per call.</span></span>| 
| <span data-ttu-id="6f692-147">skipToRank</span><span class="sxs-lookup"><span data-stu-id="6f692-147">skipToRank</span></span>| <span data-ttu-id="6f692-148">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6f692-148">32-bit unsigned integer</span></span>| <span data-ttu-id="6f692-149">ページの指定したランキング順位以降の結果を返します。</span><span class="sxs-lookup"><span data-stu-id="6f692-149">Return a page of results starting with the specified leaderboard rank.</span></span> <span data-ttu-id="6f692-150">結果の残りの部分は、並べ替え順序をランク順になります。</span><span class="sxs-lookup"><span data-stu-id="6f692-150">The rest of the results will be in sort order by rank.</span></span> <span data-ttu-id="6f692-151">このクエリ文字列は、次の「ページ」結果を取得する後続のクエリに戻すことができる継続トークンを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="6f692-151">This query string can return a continuation token which can be fed back into a subsequent query to get "the next page" of results.</span></span>| 
| <span data-ttu-id="6f692-152">skipToUser</span><span class="sxs-lookup"><span data-stu-id="6f692-152">skipToUser</span></span>| <span data-ttu-id="6f692-153">string</span><span class="sxs-lookup"><span data-stu-id="6f692-153">string</span></span>| <span data-ttu-id="6f692-154">ページのユーザーのランクまたはスコアに関係なく、指定されたゲーマーの xuid の周囲のランキング結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="6f692-154">Return a page of leaderboard results around the specified gamer xuid, regardless of that user's rank or score.</span></span> <span data-ttu-id="6f692-155">ページは、定義済みのビューのページの最後の位置や統計ランキング ビューの中央で指定したユーザーと位ランクによって並べ替えられます。</span><span class="sxs-lookup"><span data-stu-id="6f692-155">The page will be ordered by percentile rank with the specified user in the last position of the page for predefined views, or in the middle for stat leaderboard views.</span></span> <span data-ttu-id="6f692-156">この種類のクエリに対して提供される continuationToken はありません。</span><span class="sxs-lookup"><span data-stu-id="6f692-156">There is no continuationToken provided for this type of query.</span></span>| 
| <span data-ttu-id="6f692-157">continuationToken</span><span class="sxs-lookup"><span data-stu-id="6f692-157">continuationToken</span></span>| <span data-ttu-id="6f692-158">string</span><span class="sxs-lookup"><span data-stu-id="6f692-158">string</span></span>| <span data-ttu-id="6f692-159">前の呼び出しでは、continuationToken が返される、呼び出し元渡すことが戻る現状有姿トークンの結果の次のページを取得するクエリ文字列で。</span><span class="sxs-lookup"><span data-stu-id="6f692-159">If a previous call returned a continuationToken, then the caller can pass back that token "as is" in a query string to get the next page of results.</span></span>| 
  
<a id="ID4EVD"></a>

 
## <a name="authorization"></a><span data-ttu-id="6f692-160">Authorization</span><span class="sxs-lookup"><span data-stu-id="6f692-160">Authorization</span></span>
 
<span data-ttu-id="6f692-161">コンテンツ分離とアクセス制御のシナリオ向けに実装承認ロジックがあります。</span><span class="sxs-lookup"><span data-stu-id="6f692-161">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>
 
   * <span data-ttu-id="6f692-162">ランキング、およびユーザーの両方の統計は、呼び出し元が要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントから読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="6f692-162">Both leaderboards and user stats can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="6f692-163">書き込みは、データ プラットフォームでサポートされているクライアントに明らかに制限されます。</span><span class="sxs-lookup"><span data-stu-id="6f692-163">Writes are obviously limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="6f692-164">タイトル デベロッパーは、open または XDP またはパートナー センターで制限付きの統計情報をマークできます。</span><span class="sxs-lookup"><span data-stu-id="6f692-164">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="6f692-165">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="6f692-165">Leaderboards are open statistics.</span></span> <span data-ttu-id="6f692-166">開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="6f692-166">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="6f692-167">サンド ボックスへのユーザーの承認は XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="6f692-167">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>
  
<span data-ttu-id="6f692-168">チェックの擬似コードは、このようになります。</span><span class="sxs-lookup"><span data-stu-id="6f692-168">Pseudo-code for the check looks like this:</span></span>
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4EQE"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="6f692-169">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="6f692-169">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="6f692-170">ランキング データを読み取るときは、プライバシー チェックは実行されません。</span><span class="sxs-lookup"><span data-stu-id="6f692-170">No privacy checks are performed when reading leaderboard data.</span></span>
  
<a id="ID4EZE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="6f692-171">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f692-171">Required Request Headers</span></span>
 
| <span data-ttu-id="6f692-172">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f692-172">Header</span></span>| <span data-ttu-id="6f692-173">説明</span><span class="sxs-lookup"><span data-stu-id="6f692-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6f692-174">Authorization</span><span class="sxs-lookup"><span data-stu-id="6f692-174">Authorization</span></span>| <span data-ttu-id="6f692-175">[String]。</span><span class="sxs-lookup"><span data-stu-id="6f692-175">String.</span></span> <span data-ttu-id="6f692-176">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="6f692-176">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="6f692-177">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b></span><span class="sxs-lookup"><span data-stu-id="6f692-177">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b></span></span>| 
| <span data-ttu-id="6f692-178">X Xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="6f692-178">X-Xbl-Contract-Version</span></span>| <span data-ttu-id="6f692-179">[String]。</span><span class="sxs-lookup"><span data-stu-id="6f692-179">String.</span></span> <span data-ttu-id="6f692-180">使用する API のバージョンを示します。</span><span class="sxs-lookup"><span data-stu-id="6f692-180">Indicates which version of the API to use.</span></span> <span data-ttu-id="6f692-181">この値は、応答に値のメタデータを含めるために、「3」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f692-181">This value must be set to "3" in order to include value metadata in the response.</span></span>| 
| <span data-ttu-id="6f692-182">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="6f692-182">X-RequestedServiceVersion</span></span>| <span data-ttu-id="6f692-183">[String]。</span><span class="sxs-lookup"><span data-stu-id="6f692-183">String.</span></span> <span data-ttu-id="6f692-184">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="6f692-184">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="6f692-185">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="6f692-185">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="6f692-186">Accept</span><span class="sxs-lookup"><span data-stu-id="6f692-186">Accept</span></span>| <span data-ttu-id="6f692-187">[String]。</span><span class="sxs-lookup"><span data-stu-id="6f692-187">String.</span></span> <span data-ttu-id="6f692-188">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="6f692-188">Content-Types that are acceptable.</span></span> <span data-ttu-id="6f692-189">値の例:<b>アプリケーション/json</b></span><span class="sxs-lookup"><span data-stu-id="6f692-189">Example value: <b>application/json</b></span></span>| 
  
<a id="ID4EOG"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="6f692-190">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f692-190">Optional Request Headers</span></span>
 
| <span data-ttu-id="6f692-191">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f692-191">Header</span></span>| <span data-ttu-id="6f692-192">説明</span><span class="sxs-lookup"><span data-stu-id="6f692-192">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6f692-193">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="6f692-193">If-None-Match</span></span>| <span data-ttu-id="6f692-194">[String]。</span><span class="sxs-lookup"><span data-stu-id="6f692-194">String.</span></span> <span data-ttu-id="6f692-195">エンティティ タグ、クライアントは、キャッシュがサポートされる場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="6f692-195">Entity tag, used if client supports caching.</span></span> <span data-ttu-id="6f692-196">値の例: <b>"686897696a7c876b7e"</b></span><span class="sxs-lookup"><span data-stu-id="6f692-196">Example value: <b>"686897696a7c876b7e"</b></span></span>|  | 
  
<a id="ID4EOH"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="6f692-197">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="6f692-197">HTTP status codes</span></span>
 
<span data-ttu-id="6f692-198">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="6f692-198">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="6f692-199">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6f692-199">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="6f692-200">コード</span><span class="sxs-lookup"><span data-stu-id="6f692-200">Code</span></span>| <span data-ttu-id="6f692-201">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="6f692-201">Reason phrase</span></span>| <span data-ttu-id="6f692-202">説明</span><span class="sxs-lookup"><span data-stu-id="6f692-202">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6f692-203">200</span><span class="sxs-lookup"><span data-stu-id="6f692-203">200</span></span>| <span data-ttu-id="6f692-204">OK</span><span class="sxs-lookup"><span data-stu-id="6f692-204">OK</span></span>| <span data-ttu-id="6f692-205">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="6f692-205">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="6f692-206">304</span><span class="sxs-lookup"><span data-stu-id="6f692-206">304</span></span>| <span data-ttu-id="6f692-207">Not Modified</span><span class="sxs-lookup"><span data-stu-id="6f692-207">Not Modified</span></span>| <span data-ttu-id="6f692-208">リソースされていない以降に変更するように要求します。</span><span class="sxs-lookup"><span data-stu-id="6f692-208">Resource not been modified since last requested.</span></span>| 
| <span data-ttu-id="6f692-209">400</span><span class="sxs-lookup"><span data-stu-id="6f692-209">400</span></span>| <span data-ttu-id="6f692-210">Bad Request</span><span class="sxs-lookup"><span data-stu-id="6f692-210">Bad Request</span></span>| <span data-ttu-id="6f692-211">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6f692-211">Service could not understand malformed request.</span></span> <span data-ttu-id="6f692-212">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="6f692-212">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="6f692-213">401</span><span class="sxs-lookup"><span data-stu-id="6f692-213">401</span></span>| <span data-ttu-id="6f692-214">権限がありません</span><span class="sxs-lookup"><span data-stu-id="6f692-214">Unauthorized</span></span>| <span data-ttu-id="6f692-215">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="6f692-215">The request requires user authentication.</span></span>| 
| <span data-ttu-id="6f692-216">403</span><span class="sxs-lookup"><span data-stu-id="6f692-216">403</span></span>| <span data-ttu-id="6f692-217">Forbidden</span><span class="sxs-lookup"><span data-stu-id="6f692-217">Forbidden</span></span>| <span data-ttu-id="6f692-218">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="6f692-218">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="6f692-219">404</span><span class="sxs-lookup"><span data-stu-id="6f692-219">404</span></span>| <span data-ttu-id="6f692-220">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="6f692-220">Not Found</span></span>| <span data-ttu-id="6f692-221">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="6f692-221">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="6f692-222">406</span><span class="sxs-lookup"><span data-stu-id="6f692-222">406</span></span>| <span data-ttu-id="6f692-223">許容できません。</span><span class="sxs-lookup"><span data-stu-id="6f692-223">Not Acceptable</span></span>| <span data-ttu-id="6f692-224">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="6f692-224">Resource version is not supported.</span></span>| 
| <span data-ttu-id="6f692-225">408</span><span class="sxs-lookup"><span data-stu-id="6f692-225">408</span></span>| <span data-ttu-id="6f692-226">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="6f692-226">Request Timeout</span></span>| <span data-ttu-id="6f692-227">リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f692-227">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
  
<a id="ID4EFDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="6f692-228">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f692-228">Response headers</span></span>
 
| <span data-ttu-id="6f692-229">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f692-229">Header</span></span>| <span data-ttu-id="6f692-230">型</span><span class="sxs-lookup"><span data-stu-id="6f692-230">Type</span></span>| <span data-ttu-id="6f692-231">説明</span><span class="sxs-lookup"><span data-stu-id="6f692-231">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6f692-232">Content-Type</span><span class="sxs-lookup"><span data-stu-id="6f692-232">Content-Type</span></span>| <span data-ttu-id="6f692-233">string</span><span class="sxs-lookup"><span data-stu-id="6f692-233">string</span></span>| <span data-ttu-id="6f692-234">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-234">Required.</span></span> <span data-ttu-id="6f692-235">応答の本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="6f692-235">The MIME type of the body of the response.</span></span> <span data-ttu-id="6f692-236">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="6f692-236">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="6f692-237">Content-Length</span><span class="sxs-lookup"><span data-stu-id="6f692-237">Content-Length</span></span>| <span data-ttu-id="6f692-238">string</span><span class="sxs-lookup"><span data-stu-id="6f692-238">string</span></span>| <span data-ttu-id="6f692-239">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-239">Required.</span></span> <span data-ttu-id="6f692-240">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="6f692-240">The number of bytes being sent in the response.</span></span> <span data-ttu-id="6f692-241">例: <b>232</b>します。</span><span class="sxs-lookup"><span data-stu-id="6f692-241">Example: <b>232</b>.</span></span>| 
| <span data-ttu-id="6f692-242">ETag</span><span class="sxs-lookup"><span data-stu-id="6f692-242">ETag</span></span>| <span data-ttu-id="6f692-243">string</span><span class="sxs-lookup"><span data-stu-id="6f692-243">string</span></span>| <span data-ttu-id="6f692-244">省略可能。</span><span class="sxs-lookup"><span data-stu-id="6f692-244">Optional.</span></span> <span data-ttu-id="6f692-245">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="6f692-245">Used for cache optimization.</span></span> <span data-ttu-id="6f692-246">例: <b>686897696a7c876b7e</b>します。</span><span class="sxs-lookup"><span data-stu-id="6f692-246">Example: <b>686897696a7c876b7e</b>.</span></span>| 
  
<a id="ID4ECFAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="6f692-247">応答本文</span><span class="sxs-lookup"><span data-stu-id="6f692-247">Response body</span></span>
 
<a id="ID4EIFAC"></a>

 
### <a name="response-members"></a><span data-ttu-id="6f692-248">応答のメンバー</span><span class="sxs-lookup"><span data-stu-id="6f692-248">Response Members</span></span>
 
<span data-ttu-id="6f692-249">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="6f692-249">pagingInfo</span></span> | <span data-ttu-id="6f692-250">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="6f692-250">pagingInfo</span></span>| <span data-ttu-id="6f692-251">セクション</span><span class="sxs-lookup"><span data-stu-id="6f692-251">section</span></span>| <span data-ttu-id="6f692-252">省略可能。</span><span class="sxs-lookup"><span data-stu-id="6f692-252">Optional.</span></span> <span data-ttu-id="6f692-253">MaxItems が要求で指定された場合にのみ表示します。</span><span class="sxs-lookup"><span data-stu-id="6f692-253">Only present when maxItems is specified in the request.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6f692-254">continuationToken</span><span class="sxs-lookup"><span data-stu-id="6f692-254">continuationToken</span></span>| <span data-ttu-id="6f692-255">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6f692-255">64-bit unsigned integer</span></span>| <span data-ttu-id="6f692-256">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-256">Required.</span></span> <span data-ttu-id="6f692-257">必要な場合は、その URI の結果の次のページを取得するのに<b>skipItems</b>クエリ パラメーターにフィードバックするには、どのような値を指定します。</span><span class="sxs-lookup"><span data-stu-id="6f692-257">Specifies what value to feed back into the <b>skipItems</b> query parameter to get the next page of results for that URI if desired.</span></span> <span data-ttu-id="6f692-258"><b>PagingInfo</b>が返されない場合は、データを取得するための次のページがありません。</span><span class="sxs-lookup"><span data-stu-id="6f692-258">If no <b>pagingInfo</b> is returned then there is no next page of data to be obtained.</span></span>| 
| <span data-ttu-id="6f692-259">totalItems</span><span class="sxs-lookup"><span data-stu-id="6f692-259">totalItems</span></span>| <span data-ttu-id="6f692-260">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6f692-260">64-bit unsigned integer</span></span>| <span data-ttu-id="6f692-261">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-261">Required.</span></span> <span data-ttu-id="6f692-262">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="6f692-262">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="6f692-263">値の例: 1234567890</span><span class="sxs-lookup"><span data-stu-id="6f692-263">Example value: 1234567890</span></span>| 
 
<span data-ttu-id="6f692-264">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="6f692-264">leaderboardInfo</span></span> | <span data-ttu-id="6f692-265">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="6f692-265">leaderboardInfo</span></span>| <span data-ttu-id="6f692-266">セクション</span><span class="sxs-lookup"><span data-stu-id="6f692-266">section</span></span>| <span data-ttu-id="6f692-267">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-267">Required.</span></span> <span data-ttu-id="6f692-268">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="6f692-268">Always returned.</span></span> <span data-ttu-id="6f692-269">要求されたランキングに関するメタデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6f692-269">Contains the metadata about the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6f692-270">displayName</span><span class="sxs-lookup"><span data-stu-id="6f692-270">displayName</span></span>| <span data-ttu-id="6f692-271">string</span><span class="sxs-lookup"><span data-stu-id="6f692-271">string</span></span>| <span data-ttu-id="6f692-272">使用されていません。</span><span class="sxs-lookup"><span data-stu-id="6f692-272">Not used.</span></span>| 
| <span data-ttu-id="6f692-273">totalCount</span><span class="sxs-lookup"><span data-stu-id="6f692-273">totalCount</span></span>| <span data-ttu-id="6f692-274">文字列 (64 ビットの符号なし整数)</span><span class="sxs-lookup"><span data-stu-id="6f692-274">string (64-bit unsigned integer)</span></span>| <span data-ttu-id="6f692-275">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-275">Required.</span></span> <span data-ttu-id="6f692-276">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="6f692-276">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="6f692-277">値の例: 1234567890</span><span class="sxs-lookup"><span data-stu-id="6f692-277">Example value: 1234567890</span></span>| 
| <span data-ttu-id="6f692-278">columnDefinition</span><span class="sxs-lookup"><span data-stu-id="6f692-278">columnDefinition</span></span>| <span data-ttu-id="6f692-279">JSON オブジェクト</span><span class="sxs-lookup"><span data-stu-id="6f692-279">JSON object</span></span>| <span data-ttu-id="6f692-280">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-280">Required.</span></span> <span data-ttu-id="6f692-281">ランキングの列について説明します。</span><span class="sxs-lookup"><span data-stu-id="6f692-281">Describes the column in the leaderboard.</span></span>| 
| <span data-ttu-id="6f692-282">columnDefinition.displayName</span><span class="sxs-lookup"><span data-stu-id="6f692-282">columnDefinition.displayName</span></span>| <span data-ttu-id="6f692-283">string</span><span class="sxs-lookup"><span data-stu-id="6f692-283">string</span></span>| <span data-ttu-id="6f692-284">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-284">Required.</span></span> <span data-ttu-id="6f692-285">ランキングの列のわかりやすい名前。</span><span class="sxs-lookup"><span data-stu-id="6f692-285">A descriptive name of the column in the leaderboard.</span></span>| 
| <span data-ttu-id="6f692-286">columnDefinition.statName</span><span class="sxs-lookup"><span data-stu-id="6f692-286">columnDefinition.statName</span></span>| <span data-ttu-id="6f692-287">string</span><span class="sxs-lookup"><span data-stu-id="6f692-287">string</span></span>| <span data-ttu-id="6f692-288">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-288">Required.</span></span> <span data-ttu-id="6f692-289">ユーザーの統計に基づくランキングの名前です。</span><span class="sxs-lookup"><span data-stu-id="6f692-289">The name of the user stat that the leaderboard is based on.</span></span>| 
| <span data-ttu-id="6f692-290">columnDefinition.type</span><span class="sxs-lookup"><span data-stu-id="6f692-290">columnDefinition.type</span></span>| <span data-ttu-id="6f692-291">string</span><span class="sxs-lookup"><span data-stu-id="6f692-291">string</span></span>| <span data-ttu-id="6f692-292">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-292">Required.</span></span> <span data-ttu-id="6f692-293">列で、ユーザーの統計のデータ型。</span><span class="sxs-lookup"><span data-stu-id="6f692-293">The data type of the user stat in the column.</span></span>| 
 
<span data-ttu-id="6f692-294">userList</span><span class="sxs-lookup"><span data-stu-id="6f692-294">userList</span></span> | <span data-ttu-id="6f692-295">userList</span><span class="sxs-lookup"><span data-stu-id="6f692-295">userList</span></span>| <span data-ttu-id="6f692-296">セクション</span><span class="sxs-lookup"><span data-stu-id="6f692-296">section</span></span>| <span data-ttu-id="6f692-297">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-297">Required.</span></span> <span data-ttu-id="6f692-298">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="6f692-298">Always returned.</span></span> <span data-ttu-id="6f692-299">要求されたランキングの実際のユーザーのスコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6f692-299">Contains the actual user scores for the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6f692-300">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="6f692-300">gamertag</span></span>| <span data-ttu-id="6f692-301">string</span><span class="sxs-lookup"><span data-stu-id="6f692-301">string</span></span>| <span data-ttu-id="6f692-302">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-302">Required.</span></span> <span data-ttu-id="6f692-303">ランキングのエントリ内のユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="6f692-303">The gamertag of the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="6f692-304">xuid</span><span class="sxs-lookup"><span data-stu-id="6f692-304">xuid</span></span>| <span data-ttu-id="6f692-305">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6f692-305">64-bit unsigned integer</span></span>| <span data-ttu-id="6f692-306">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-306">Required.</span></span> <span data-ttu-id="6f692-307">ランキングのエントリ内のユーザーの Xbox ユーザー ID。</span><span class="sxs-lookup"><span data-stu-id="6f692-307">The Xbox user ID of the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="6f692-308">位</span><span class="sxs-lookup"><span data-stu-id="6f692-308">percentile</span></span>| <span data-ttu-id="6f692-309">string</span><span class="sxs-lookup"><span data-stu-id="6f692-309">string</span></span>| <span data-ttu-id="6f692-310">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-310">Required.</span></span> <span data-ttu-id="6f692-311">ユーザーのランキングのランキングを位です。</span><span class="sxs-lookup"><span data-stu-id="6f692-311">The user's percentile rank in the leaderboard.</span></span>| 
| <span data-ttu-id="6f692-312">ランク</span><span class="sxs-lookup"><span data-stu-id="6f692-312">rank</span></span>| <span data-ttu-id="6f692-313">string</span><span class="sxs-lookup"><span data-stu-id="6f692-313">string</span></span>| <span data-ttu-id="6f692-314">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-314">Required.</span></span> <span data-ttu-id="6f692-315">ランキングで、ユーザーの数値のランク。</span><span class="sxs-lookup"><span data-stu-id="6f692-315">The user's numeric rank in the leaderboard.</span></span>| 
| <span data-ttu-id="6f692-316">value</span><span class="sxs-lookup"><span data-stu-id="6f692-316">value</span></span>| <span data-ttu-id="6f692-317">string</span><span class="sxs-lookup"><span data-stu-id="6f692-317">string</span></span>| <span data-ttu-id="6f692-318">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-318">Required.</span></span> <span data-ttu-id="6f692-319">ランキングを基になる統計のユーザーの値です。</span><span class="sxs-lookup"><span data-stu-id="6f692-319">The user's value of the stat on which the leaderboard is based.</span></span>| 
| <span data-ttu-id="6f692-320">valueMetadata</span><span class="sxs-lookup"><span data-stu-id="6f692-320">valueMetadata</span></span>| <span data-ttu-id="6f692-321">string</span><span class="sxs-lookup"><span data-stu-id="6f692-321">string</span></span>| <span data-ttu-id="6f692-322">必須。</span><span class="sxs-lookup"><span data-stu-id="6f692-322">Required.</span></span> <span data-ttu-id="6f692-323">文字列のコンマ区切り"\"name\"の形式での文字列のペア: \"value\「,.」</span><span class="sxs-lookup"><span data-stu-id="6f692-323">A string of comma separated string pairs, in the format "\"name\" : \"value\", ..."</span></span>

<span data-ttu-id="6f692-324">メタデータがない場合は、この値は、空の文字列 |。</span><span class="sxs-lookup"><span data-stu-id="6f692-324">If there is no metadata, this value is an empty string.|</span></span> 
  
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="6f692-325">応答の例</span><span class="sxs-lookup"><span data-stu-id="6f692-325">Sample response</span></span>
 
<span data-ttu-id="6f692-326">次の要求の URI は、グローバル ランキングでランクをスキップするかを示しています。</span><span class="sxs-lookup"><span data-stu-id="6f692-326">The following request URI depicts skipping to rank on a global leaderboard.</span></span>
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/TotalFlagsCaptured?include=valuemetadata&maxItems=3&skipToRank=15000
         
```

 
<span data-ttu-id="6f692-327">値のメタデータを取得するために、次のヘッダーを指定もする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f692-327">In order to return value metadata, the following header must also be specified.</span></span>
 

```cpp
X-Xbl-Contract-Version : 3
          
```

 
<span data-ttu-id="6f692-328">上記の URI は、次の JSON 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="6f692-328">The URI above returns the following JSON response.</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="6f692-329">関連項目</span><span class="sxs-lookup"><span data-stu-id="6f692-329">See also</span></span>
 
<a id="ID4EBMAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="6f692-330">Parent</span><span class="sxs-lookup"><span data-stu-id="6f692-330">Parent</span></span> 

[<span data-ttu-id="6f692-331">/scids/{scid}/leaderboards/{leaderboardname}</span><span class="sxs-lookup"><span data-stu-id="6f692-331">/scids/{scid}/leaderboards/{leaderboardname}</span></span>](uri-scidsscidleaderboardsleaderboardname.md)

   