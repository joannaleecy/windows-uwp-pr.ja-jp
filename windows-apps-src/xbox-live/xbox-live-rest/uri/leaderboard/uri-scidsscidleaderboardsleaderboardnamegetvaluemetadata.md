---
title: GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)
assetID: ee69a9e3-ea91-3cf5-a10a-811762cba892
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardnamegetvaluemetadata.html
author: KevinAsgari
description: " GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 63f5d2967219a909a82e0e638fb9c852670e9749
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5441307"
---
# <a name="get-scidsscidleaderboardsleaderboardnameincludevaluemetadata"></a><span data-ttu-id="3846a-104">GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)</span><span class="sxs-lookup"><span data-stu-id="3846a-104">GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)</span></span>
 
<span data-ttu-id="3846a-105">ランキングの値に関連付けられたメタデータと共に定義済みグローバル ランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="3846a-105">Gets a predefined global leaderboard along with any metadata associated with the leaderboard values.</span></span>
 
<span data-ttu-id="3846a-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3846a-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="3846a-107">注釈</span><span class="sxs-lookup"><span data-stu-id="3846a-107">Remarks</span></span>](#ID4EY)
  * [<span data-ttu-id="3846a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3846a-108">URI parameters</span></span>](#ID4EHB)
  * [<span data-ttu-id="3846a-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="3846a-109">Query string parameters</span></span>](#ID4ESB)
  * [<span data-ttu-id="3846a-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="3846a-110">Authorization</span></span>](#ID4EVD)
  * [<span data-ttu-id="3846a-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="3846a-111">Effect of privacy settings on resource</span></span>](#ID4EQE)
  * [<span data-ttu-id="3846a-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3846a-112">Required Request Headers</span></span>](#ID4EZE)
  * [<span data-ttu-id="3846a-113">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3846a-113">Optional Request Headers</span></span>](#ID4EOG)
  * [<span data-ttu-id="3846a-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3846a-114">HTTP status codes</span></span>](#ID4EOH)
  * [<span data-ttu-id="3846a-115">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3846a-115">Response headers</span></span>](#ID4EFDAC)
  * [<span data-ttu-id="3846a-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="3846a-116">Response body</span></span>](#ID4ECFAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a><span data-ttu-id="3846a-117">注釈</span><span class="sxs-lookup"><span data-stu-id="3846a-117">Remarks</span></span>
 
<span data-ttu-id="3846a-118">かどうか。 含める = valuemetadata クエリ パラメーターには、ランキングの値に関連付けられたメタデータを含めるへの応答がことができます。</span><span class="sxs-lookup"><span data-stu-id="3846a-118">The ?include=valuemetadata query parameter allows the response to include any metadata associated with the leaderboard values.</span></span> <span data-ttu-id="3846a-119">値のメタデータには、指定されたクライアントが含まれています。 データ モデルやレース トラックに最適な時間を実現するために使用された車の色などの値に関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="3846a-119">The value metadata contains client specified data associated with the value, such as the model and color of a car used to achieve a best time on a race track.</span></span>
 
<span data-ttu-id="3846a-120">値のメタデータは、ランキングのランキング自体ではなく基になっているユーザー統計で定義されます。</span><span class="sxs-lookup"><span data-stu-id="3846a-120">Value metadata is defined on the user stat that the leaderboard is based on, not on the leaderboard itself.</span></span>
 
<span data-ttu-id="3846a-121">ランキング Api では、読み取り専用すべてと、したがってのみ GET 動詞をサポートします。</span><span class="sxs-lookup"><span data-stu-id="3846a-121">Leaderboard APIs are all read-only and therefore only support the GET verb.</span></span> <span data-ttu-id="3846a-122">ランクと並べ替えられた「ページ」インデックス付きのプレイヤーの統計データ プラットフォームによって書き込まれた個々 のユーザー統計から派生したが反映されます。</span><span class="sxs-lookup"><span data-stu-id="3846a-122">They reflect ranked and sorted "pages" of indexed player stats that are derived from individual user stats that were written via the Data Platform.</span></span> <span data-ttu-id="3846a-123">完全なランキングのインデックスが大きくなることができ、呼び出し元は全体のいずれかを確認することはありませんが求められます、したがってこの URI はそのランキングを表示する必要があるビューの種類について具体的に説明する呼び出しを許可するいくつかのクエリ文字列引数をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="3846a-123">Full leaderboard indexes can be quite large, and callers will never ask to see one in its entirety, therefore this URI supports several query string arguments that allow a caller to be specific about what kind of view it wants to see against that leaderboard.</span></span>
 
<span data-ttu-id="3846a-124">これと同じ結果に 1 回または複数回実行している場合、GET 操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="3846a-124">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>
  
<a id="ID4EHB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3846a-125">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3846a-125">URI parameters</span></span>
 
| <span data-ttu-id="3846a-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3846a-126">Parameter</span></span>| <span data-ttu-id="3846a-127">型</span><span class="sxs-lookup"><span data-stu-id="3846a-127">Type</span></span>| <span data-ttu-id="3846a-128">説明</span><span class="sxs-lookup"><span data-stu-id="3846a-128">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3846a-129">scid</span><span class="sxs-lookup"><span data-stu-id="3846a-129">scid</span></span>| <span data-ttu-id="3846a-130">GUID</span><span class="sxs-lookup"><span data-stu-id="3846a-130">GUID</span></span>| <span data-ttu-id="3846a-131">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="3846a-131">Identifier of the service configuration which contains the resource being accessed.</span></span>| 
| <span data-ttu-id="3846a-132">leaderboardname</span><span class="sxs-lookup"><span data-stu-id="3846a-132">leaderboardname</span></span>| <span data-ttu-id="3846a-133">string</span><span class="sxs-lookup"><span data-stu-id="3846a-133">string</span></span>| <span data-ttu-id="3846a-134">アクセス対象の定義済みのランキング リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="3846a-134">Unique identifier of the predefined leaderboard resource being accessed.</span></span>| 
  
<a id="ID4ESB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="3846a-135">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="3846a-135">Query string parameters</span></span>
 
| <span data-ttu-id="3846a-136">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3846a-136">Parameter</span></span>| <span data-ttu-id="3846a-137">型</span><span class="sxs-lookup"><span data-stu-id="3846a-137">Type</span></span>| <span data-ttu-id="3846a-138">説明</span><span class="sxs-lookup"><span data-stu-id="3846a-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3846a-139">含める = valuemetadata</span><span class="sxs-lookup"><span data-stu-id="3846a-139">include=valuemetadata</span></span>| <span data-ttu-id="3846a-140">string</span><span class="sxs-lookup"><span data-stu-id="3846a-140">string</span></span>| <span data-ttu-id="3846a-141">応答には、ランキングの値に関連付けられた値メタデータが含まれていることを示します。</span><span class="sxs-lookup"><span data-stu-id="3846a-141">Indicates that the response includes any value metadata associated with the leaderboard values.</span></span>| 
| <span data-ttu-id="3846a-142">maxItems</span><span class="sxs-lookup"><span data-stu-id="3846a-142">maxItems</span></span>| <span data-ttu-id="3846a-143">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3846a-143">32-bit unsigned integer</span></span>| <span data-ttu-id="3846a-144">ランキング結果のページで、返されるレコードの最大数。</span><span class="sxs-lookup"><span data-stu-id="3846a-144">Maximum number of leaderboard records to return in a page of results.</span></span> <span data-ttu-id="3846a-145">指定しない場合、既定の数は (10) 返されます。</span><span class="sxs-lookup"><span data-stu-id="3846a-145">If not specified, a default number will be returned (10).</span></span> <span data-ttu-id="3846a-146">MaxItems の最大値は引き続きが、大規模なデータ セットを回避する、ため、この値をターゲットにする必要がありますおそらく、最大呼び出しごとに UI が処理できるチューナーします。</span><span class="sxs-lookup"><span data-stu-id="3846a-146">The max value for maxItems is still undefined, but we want to avoid large data sets, so this value should probably target the largest set that a tuner UI could handle per call.</span></span>| 
| <span data-ttu-id="3846a-147">skipToRank</span><span class="sxs-lookup"><span data-stu-id="3846a-147">skipToRank</span></span>| <span data-ttu-id="3846a-148">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3846a-148">32-bit unsigned integer</span></span>| <span data-ttu-id="3846a-149">ページの指定のランキング順位から始まる結果を返します。</span><span class="sxs-lookup"><span data-stu-id="3846a-149">Return a page of results starting with the specified leaderboard rank.</span></span> <span data-ttu-id="3846a-150">結果の残りの部分は、並べ替え順序をランク順になります。</span><span class="sxs-lookup"><span data-stu-id="3846a-150">The rest of the results will be in sort order by rank.</span></span> <span data-ttu-id="3846a-151">このクエリ文字列は、次の「ページ」結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="3846a-151">This query string can return a continuation token which can be fed back into a subsequent query to get "the next page" of results.</span></span>| 
| <span data-ttu-id="3846a-152">skipToUser</span><span class="sxs-lookup"><span data-stu-id="3846a-152">skipToUser</span></span>| <span data-ttu-id="3846a-153">string</span><span class="sxs-lookup"><span data-stu-id="3846a-153">string</span></span>| <span data-ttu-id="3846a-154">ページのユーザーのランクまたはスコアに関係なく、指定されたゲーマーの xuid の周囲のランキング結果を返します。</span><span class="sxs-lookup"><span data-stu-id="3846a-154">Return a page of leaderboard results around the specified gamer xuid, regardless of that user's rank or score.</span></span> <span data-ttu-id="3846a-155">ページは、定義済みのビューのページの最後の位置や統計ランキング ビューの中央で指定したユーザーと位ランクによって並べ替えられます。</span><span class="sxs-lookup"><span data-stu-id="3846a-155">The page will be ordered by percentile rank with the specified user in the last position of the page for predefined views, or in the middle for stat leaderboard views.</span></span> <span data-ttu-id="3846a-156">この種類のクエリに対して提供される continuationToken はありません。</span><span class="sxs-lookup"><span data-stu-id="3846a-156">There is no continuationToken provided for this type of query.</span></span>| 
| <span data-ttu-id="3846a-157">continuationToken</span><span class="sxs-lookup"><span data-stu-id="3846a-157">continuationToken</span></span>| <span data-ttu-id="3846a-158">string</span><span class="sxs-lookup"><span data-stu-id="3846a-158">string</span></span>| <span data-ttu-id="3846a-159">前の呼び出しでは、continuationToken が返される、呼び出し元渡すことが戻る現状有姿トークンの結果の次のページを取得するクエリ文字列。</span><span class="sxs-lookup"><span data-stu-id="3846a-159">If a previous call returned a continuationToken, then the caller can pass back that token "as is" in a query string to get the next page of results.</span></span>| 
  
<a id="ID4EVD"></a>

 
## <a name="authorization"></a><span data-ttu-id="3846a-160">Authorization</span><span class="sxs-lookup"><span data-stu-id="3846a-160">Authorization</span></span>
 
<span data-ttu-id="3846a-161">承認ロジック コンテンツ分離とアクセス制御のシナリオの実装があります。</span><span class="sxs-lookup"><span data-stu-id="3846a-161">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>
 
   * <span data-ttu-id="3846a-162">ランキング、およびユーザーの両方の統計は、呼び出し元が要求に有効な XSTS トークンを送信している任意のプラットフォーム上のクライアントから読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="3846a-162">Both leaderboards and user stats can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="3846a-163">書き込みは、データ プラットフォームでサポートされているクライアントに明らかに制限されます。</span><span class="sxs-lookup"><span data-stu-id="3846a-163">Writes are obviously limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="3846a-164">タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付きの統計情報をマークできます。</span><span class="sxs-lookup"><span data-stu-id="3846a-164">Title developers can mark statistics as open or restricted with XDP or Dev Center.</span></span> <span data-ttu-id="3846a-165">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="3846a-165">Leaderboards are open statistics.</span></span> <span data-ttu-id="3846a-166">開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="3846a-166">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="3846a-167">サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="3846a-167">User authorization to a sandbox is managed through XDP or Dev Center.</span></span>
  
<span data-ttu-id="3846a-168">チェックの擬似コードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="3846a-168">Pseudo-code for the check looks like this:</span></span>
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4EQE"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="3846a-169">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="3846a-169">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="3846a-170">ランキング データを読み取るときは、プライバシー チェックは実行されません。</span><span class="sxs-lookup"><span data-stu-id="3846a-170">No privacy checks are performed when reading leaderboard data.</span></span>
  
<a id="ID4EZE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="3846a-171">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3846a-171">Required Request Headers</span></span>
 
| <span data-ttu-id="3846a-172">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3846a-172">Header</span></span>| <span data-ttu-id="3846a-173">説明</span><span class="sxs-lookup"><span data-stu-id="3846a-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3846a-174">Authorization</span><span class="sxs-lookup"><span data-stu-id="3846a-174">Authorization</span></span>| <span data-ttu-id="3846a-175">[String]。</span><span class="sxs-lookup"><span data-stu-id="3846a-175">String.</span></span> <span data-ttu-id="3846a-176">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="3846a-176">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="3846a-177">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b></span><span class="sxs-lookup"><span data-stu-id="3846a-177">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b></span></span>| 
| <span data-ttu-id="3846a-178">X Xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="3846a-178">X-Xbl-Contract-Version</span></span>| <span data-ttu-id="3846a-179">[String]。</span><span class="sxs-lookup"><span data-stu-id="3846a-179">String.</span></span> <span data-ttu-id="3846a-180">使用する API のバージョンを示します。</span><span class="sxs-lookup"><span data-stu-id="3846a-180">Indicates which version of the API to use.</span></span> <span data-ttu-id="3846a-181">この値は、応答に値のメタデータを含めるために、「3」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3846a-181">This value must be set to "3" in order to include value metadata in the response.</span></span>| 
| <span data-ttu-id="3846a-182">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="3846a-182">X-RequestedServiceVersion</span></span>| <span data-ttu-id="3846a-183">[String]。</span><span class="sxs-lookup"><span data-stu-id="3846a-183">String.</span></span> <span data-ttu-id="3846a-184">この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="3846a-184">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="3846a-185">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="3846a-185">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="3846a-186">Accept</span><span class="sxs-lookup"><span data-stu-id="3846a-186">Accept</span></span>| <span data-ttu-id="3846a-187">[String]。</span><span class="sxs-lookup"><span data-stu-id="3846a-187">String.</span></span> <span data-ttu-id="3846a-188">コンテンツの種類の受け入れられるします。</span><span class="sxs-lookup"><span data-stu-id="3846a-188">Content-Types that are acceptable.</span></span> <span data-ttu-id="3846a-189">値の例:<b>アプリケーション/json</b></span><span class="sxs-lookup"><span data-stu-id="3846a-189">Example value: <b>application/json</b></span></span>| 
  
<a id="ID4EOG"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="3846a-190">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3846a-190">Optional Request Headers</span></span>
 
| <span data-ttu-id="3846a-191">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3846a-191">Header</span></span>| <span data-ttu-id="3846a-192">説明</span><span class="sxs-lookup"><span data-stu-id="3846a-192">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3846a-193">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="3846a-193">If-None-Match</span></span>| <span data-ttu-id="3846a-194">[String]。</span><span class="sxs-lookup"><span data-stu-id="3846a-194">String.</span></span> <span data-ttu-id="3846a-195">エンティティ タグ、クライアントは、キャッシュをサポートしている場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="3846a-195">Entity tag, used if client supports caching.</span></span> <span data-ttu-id="3846a-196">値の例: <b>"686897696a7c876b7e"</b></span><span class="sxs-lookup"><span data-stu-id="3846a-196">Example value: <b>"686897696a7c876b7e"</b></span></span>|  | 
  
<a id="ID4EOH"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="3846a-197">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3846a-197">HTTP status codes</span></span>
 
<span data-ttu-id="3846a-198">サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="3846a-198">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="3846a-199">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3846a-199">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="3846a-200">コード</span><span class="sxs-lookup"><span data-stu-id="3846a-200">Code</span></span>| <span data-ttu-id="3846a-201">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="3846a-201">Reason phrase</span></span>| <span data-ttu-id="3846a-202">説明</span><span class="sxs-lookup"><span data-stu-id="3846a-202">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3846a-203">200</span><span class="sxs-lookup"><span data-stu-id="3846a-203">200</span></span>| <span data-ttu-id="3846a-204">OK</span><span class="sxs-lookup"><span data-stu-id="3846a-204">OK</span></span>| <span data-ttu-id="3846a-205">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="3846a-205">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="3846a-206">304</span><span class="sxs-lookup"><span data-stu-id="3846a-206">304</span></span>| <span data-ttu-id="3846a-207">Not Modified</span><span class="sxs-lookup"><span data-stu-id="3846a-207">Not Modified</span></span>| <span data-ttu-id="3846a-208">リソースされていない以降に変更するように要求します。</span><span class="sxs-lookup"><span data-stu-id="3846a-208">Resource not been modified since last requested.</span></span>| 
| <span data-ttu-id="3846a-209">400</span><span class="sxs-lookup"><span data-stu-id="3846a-209">400</span></span>| <span data-ttu-id="3846a-210">Bad Request</span><span class="sxs-lookup"><span data-stu-id="3846a-210">Bad Request</span></span>| <span data-ttu-id="3846a-211">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3846a-211">Service could not understand malformed request.</span></span> <span data-ttu-id="3846a-212">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="3846a-212">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="3846a-213">401</span><span class="sxs-lookup"><span data-stu-id="3846a-213">401</span></span>| <span data-ttu-id="3846a-214">権限がありません</span><span class="sxs-lookup"><span data-stu-id="3846a-214">Unauthorized</span></span>| <span data-ttu-id="3846a-215">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="3846a-215">The request requires user authentication.</span></span>| 
| <span data-ttu-id="3846a-216">403</span><span class="sxs-lookup"><span data-stu-id="3846a-216">403</span></span>| <span data-ttu-id="3846a-217">Forbidden</span><span class="sxs-lookup"><span data-stu-id="3846a-217">Forbidden</span></span>| <span data-ttu-id="3846a-218">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="3846a-218">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="3846a-219">404</span><span class="sxs-lookup"><span data-stu-id="3846a-219">404</span></span>| <span data-ttu-id="3846a-220">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="3846a-220">Not Found</span></span>| <span data-ttu-id="3846a-221">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="3846a-221">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="3846a-222">406</span><span class="sxs-lookup"><span data-stu-id="3846a-222">406</span></span>| <span data-ttu-id="3846a-223">許容できません。</span><span class="sxs-lookup"><span data-stu-id="3846a-223">Not Acceptable</span></span>| <span data-ttu-id="3846a-224">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="3846a-224">Resource version is not supported.</span></span>| 
| <span data-ttu-id="3846a-225">408</span><span class="sxs-lookup"><span data-stu-id="3846a-225">408</span></span>| <span data-ttu-id="3846a-226">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="3846a-226">Request Timeout</span></span>| <span data-ttu-id="3846a-227">リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3846a-227">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
  
<a id="ID4EFDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="3846a-228">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3846a-228">Response headers</span></span>
 
| <span data-ttu-id="3846a-229">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3846a-229">Header</span></span>| <span data-ttu-id="3846a-230">型</span><span class="sxs-lookup"><span data-stu-id="3846a-230">Type</span></span>| <span data-ttu-id="3846a-231">説明</span><span class="sxs-lookup"><span data-stu-id="3846a-231">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3846a-232">Content-Type</span><span class="sxs-lookup"><span data-stu-id="3846a-232">Content-Type</span></span>| <span data-ttu-id="3846a-233">string</span><span class="sxs-lookup"><span data-stu-id="3846a-233">string</span></span>| <span data-ttu-id="3846a-234">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-234">Required.</span></span> <span data-ttu-id="3846a-235">応答の本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="3846a-235">The MIME type of the body of the response.</span></span> <span data-ttu-id="3846a-236">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="3846a-236">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="3846a-237">Content-Length</span><span class="sxs-lookup"><span data-stu-id="3846a-237">Content-Length</span></span>| <span data-ttu-id="3846a-238">string</span><span class="sxs-lookup"><span data-stu-id="3846a-238">string</span></span>| <span data-ttu-id="3846a-239">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-239">Required.</span></span> <span data-ttu-id="3846a-240">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="3846a-240">The number of bytes being sent in the response.</span></span> <span data-ttu-id="3846a-241">例: <b>232</b>します。</span><span class="sxs-lookup"><span data-stu-id="3846a-241">Example: <b>232</b>.</span></span>| 
| <span data-ttu-id="3846a-242">ETag</span><span class="sxs-lookup"><span data-stu-id="3846a-242">ETag</span></span>| <span data-ttu-id="3846a-243">string</span><span class="sxs-lookup"><span data-stu-id="3846a-243">string</span></span>| <span data-ttu-id="3846a-244">省略可能。</span><span class="sxs-lookup"><span data-stu-id="3846a-244">Optional.</span></span> <span data-ttu-id="3846a-245">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="3846a-245">Used for cache optimization.</span></span> <span data-ttu-id="3846a-246">例: <b>686897696a7c876b7e</b>します。</span><span class="sxs-lookup"><span data-stu-id="3846a-246">Example: <b>686897696a7c876b7e</b>.</span></span>| 
  
<a id="ID4ECFAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="3846a-247">応答本文</span><span class="sxs-lookup"><span data-stu-id="3846a-247">Response body</span></span>
 
<a id="ID4EIFAC"></a>

 
### <a name="response-members"></a><span data-ttu-id="3846a-248">応答のメンバー</span><span class="sxs-lookup"><span data-stu-id="3846a-248">Response Members</span></span>
 
<span data-ttu-id="3846a-249">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="3846a-249">pagingInfo</span></span> | <span data-ttu-id="3846a-250">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="3846a-250">pagingInfo</span></span>| <span data-ttu-id="3846a-251">セクション</span><span class="sxs-lookup"><span data-stu-id="3846a-251">section</span></span>| <span data-ttu-id="3846a-252">省略可能。</span><span class="sxs-lookup"><span data-stu-id="3846a-252">Optional.</span></span> <span data-ttu-id="3846a-253">MaxItems が要求で指定されたときののみを表示します。</span><span class="sxs-lookup"><span data-stu-id="3846a-253">Only present when maxItems is specified in the request.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3846a-254">continuationToken</span><span class="sxs-lookup"><span data-stu-id="3846a-254">continuationToken</span></span>| <span data-ttu-id="3846a-255">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3846a-255">64-bit unsigned integer</span></span>| <span data-ttu-id="3846a-256">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-256">Required.</span></span> <span data-ttu-id="3846a-257">必要な場合は、その URI の結果の次のページを取得するのに<b>skipItems</b>クエリ パラメーターにフィードバックするには、どのような値を指定します。</span><span class="sxs-lookup"><span data-stu-id="3846a-257">Specifies what value to feed back into the <b>skipItems</b> query parameter to get the next page of results for that URI if desired.</span></span> <span data-ttu-id="3846a-258"><b>PagingInfo</b>が返されない場合は、データを取得するための次のページがありません。</span><span class="sxs-lookup"><span data-stu-id="3846a-258">If no <b>pagingInfo</b> is returned then there is no next page of data to be obtained.</span></span>| 
| <span data-ttu-id="3846a-259">totalItems</span><span class="sxs-lookup"><span data-stu-id="3846a-259">totalItems</span></span>| <span data-ttu-id="3846a-260">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3846a-260">64-bit unsigned integer</span></span>| <span data-ttu-id="3846a-261">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-261">Required.</span></span> <span data-ttu-id="3846a-262">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="3846a-262">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="3846a-263">値の例: 1234567890</span><span class="sxs-lookup"><span data-stu-id="3846a-263">Example value: 1234567890</span></span>| 
 
<span data-ttu-id="3846a-264">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="3846a-264">leaderboardInfo</span></span> | <span data-ttu-id="3846a-265">leaderboardInfo</span><span class="sxs-lookup"><span data-stu-id="3846a-265">leaderboardInfo</span></span>| <span data-ttu-id="3846a-266">セクション</span><span class="sxs-lookup"><span data-stu-id="3846a-266">section</span></span>| <span data-ttu-id="3846a-267">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-267">Required.</span></span> <span data-ttu-id="3846a-268">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="3846a-268">Always returned.</span></span> <span data-ttu-id="3846a-269">要求されたランキングに関するメタデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3846a-269">Contains the metadata about the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3846a-270">displayName</span><span class="sxs-lookup"><span data-stu-id="3846a-270">displayName</span></span>| <span data-ttu-id="3846a-271">string</span><span class="sxs-lookup"><span data-stu-id="3846a-271">string</span></span>| <span data-ttu-id="3846a-272">使用されていません。</span><span class="sxs-lookup"><span data-stu-id="3846a-272">Not used.</span></span>| 
| <span data-ttu-id="3846a-273">totalCount</span><span class="sxs-lookup"><span data-stu-id="3846a-273">totalCount</span></span>| <span data-ttu-id="3846a-274">文字列 (64 ビットの符号なし整数)</span><span class="sxs-lookup"><span data-stu-id="3846a-274">string (64-bit unsigned integer)</span></span>| <span data-ttu-id="3846a-275">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-275">Required.</span></span> <span data-ttu-id="3846a-276">ランキングのエントリの合計数。</span><span class="sxs-lookup"><span data-stu-id="3846a-276">Total number of entries in the leaderboard.</span></span> <span data-ttu-id="3846a-277">値の例: 1234567890</span><span class="sxs-lookup"><span data-stu-id="3846a-277">Example value: 1234567890</span></span>| 
| <span data-ttu-id="3846a-278">columnDefinition</span><span class="sxs-lookup"><span data-stu-id="3846a-278">columnDefinition</span></span>| <span data-ttu-id="3846a-279">JSON オブジェクト</span><span class="sxs-lookup"><span data-stu-id="3846a-279">JSON object</span></span>| <span data-ttu-id="3846a-280">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-280">Required.</span></span> <span data-ttu-id="3846a-281">ランキングの列について説明します。</span><span class="sxs-lookup"><span data-stu-id="3846a-281">Describes the column in the leaderboard.</span></span>| 
| <span data-ttu-id="3846a-282">columnDefinition.displayName</span><span class="sxs-lookup"><span data-stu-id="3846a-282">columnDefinition.displayName</span></span>| <span data-ttu-id="3846a-283">string</span><span class="sxs-lookup"><span data-stu-id="3846a-283">string</span></span>| <span data-ttu-id="3846a-284">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-284">Required.</span></span> <span data-ttu-id="3846a-285">ランキングの列のわかりやすい名前。</span><span class="sxs-lookup"><span data-stu-id="3846a-285">A descriptive name of the column in the leaderboard.</span></span>| 
| <span data-ttu-id="3846a-286">columnDefinition.statName</span><span class="sxs-lookup"><span data-stu-id="3846a-286">columnDefinition.statName</span></span>| <span data-ttu-id="3846a-287">string</span><span class="sxs-lookup"><span data-stu-id="3846a-287">string</span></span>| <span data-ttu-id="3846a-288">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-288">Required.</span></span> <span data-ttu-id="3846a-289">ランキングがに基づいてユーザーの統計の名前。</span><span class="sxs-lookup"><span data-stu-id="3846a-289">The name of the user stat that the leaderboard is based on.</span></span>| 
| <span data-ttu-id="3846a-290">columnDefinition.type</span><span class="sxs-lookup"><span data-stu-id="3846a-290">columnDefinition.type</span></span>| <span data-ttu-id="3846a-291">string</span><span class="sxs-lookup"><span data-stu-id="3846a-291">string</span></span>| <span data-ttu-id="3846a-292">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-292">Required.</span></span> <span data-ttu-id="3846a-293">列で、ユーザー統計のデータ型。</span><span class="sxs-lookup"><span data-stu-id="3846a-293">The data type of the user stat in the column.</span></span>| 
 
<span data-ttu-id="3846a-294">userList</span><span class="sxs-lookup"><span data-stu-id="3846a-294">userList</span></span> | <span data-ttu-id="3846a-295">userList</span><span class="sxs-lookup"><span data-stu-id="3846a-295">userList</span></span>| <span data-ttu-id="3846a-296">セクション</span><span class="sxs-lookup"><span data-stu-id="3846a-296">section</span></span>| <span data-ttu-id="3846a-297">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-297">Required.</span></span> <span data-ttu-id="3846a-298">常に返されます。</span><span class="sxs-lookup"><span data-stu-id="3846a-298">Always returned.</span></span> <span data-ttu-id="3846a-299">要求されたランキングの実際のユーザーのスコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3846a-299">Contains the actual user scores for the leaderboard requested.</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3846a-300">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="3846a-300">gamertag</span></span>| <span data-ttu-id="3846a-301">string</span><span class="sxs-lookup"><span data-stu-id="3846a-301">string</span></span>| <span data-ttu-id="3846a-302">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-302">Required.</span></span> <span data-ttu-id="3846a-303">ランキングのエントリ内のユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="3846a-303">The gamertag of the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="3846a-304">xuid</span><span class="sxs-lookup"><span data-stu-id="3846a-304">xuid</span></span>| <span data-ttu-id="3846a-305">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3846a-305">64-bit unsigned integer</span></span>| <span data-ttu-id="3846a-306">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-306">Required.</span></span> <span data-ttu-id="3846a-307">ランキングのエントリで、ユーザーの Xbox ユーザー ID です。</span><span class="sxs-lookup"><span data-stu-id="3846a-307">The Xbox user ID of the user in the leaderboard entry.</span></span>| 
| <span data-ttu-id="3846a-308">位</span><span class="sxs-lookup"><span data-stu-id="3846a-308">percentile</span></span>| <span data-ttu-id="3846a-309">string</span><span class="sxs-lookup"><span data-stu-id="3846a-309">string</span></span>| <span data-ttu-id="3846a-310">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-310">Required.</span></span> <span data-ttu-id="3846a-311">ユーザーのランキングのランキングを位です。</span><span class="sxs-lookup"><span data-stu-id="3846a-311">The user's percentile rank in the leaderboard.</span></span>| 
| <span data-ttu-id="3846a-312">ランク</span><span class="sxs-lookup"><span data-stu-id="3846a-312">rank</span></span>| <span data-ttu-id="3846a-313">string</span><span class="sxs-lookup"><span data-stu-id="3846a-313">string</span></span>| <span data-ttu-id="3846a-314">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-314">Required.</span></span> <span data-ttu-id="3846a-315">ランキングで、ユーザーの数値のランク。</span><span class="sxs-lookup"><span data-stu-id="3846a-315">The user's numeric rank in the leaderboard.</span></span>| 
| <span data-ttu-id="3846a-316">value</span><span class="sxs-lookup"><span data-stu-id="3846a-316">value</span></span>| <span data-ttu-id="3846a-317">string</span><span class="sxs-lookup"><span data-stu-id="3846a-317">string</span></span>| <span data-ttu-id="3846a-318">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-318">Required.</span></span> <span data-ttu-id="3846a-319">ランキングの基になる統計のユーザーの値。</span><span class="sxs-lookup"><span data-stu-id="3846a-319">The user's value of the stat on which the leaderboard is based.</span></span>| 
| <span data-ttu-id="3846a-320">valueMetadata</span><span class="sxs-lookup"><span data-stu-id="3846a-320">valueMetadata</span></span>| <span data-ttu-id="3846a-321">string</span><span class="sxs-lookup"><span data-stu-id="3846a-321">string</span></span>| <span data-ttu-id="3846a-322">必須。</span><span class="sxs-lookup"><span data-stu-id="3846a-322">Required.</span></span> <span data-ttu-id="3846a-323">文字列のコンマ区切り"\"name\"の形式での文字列のペア: \"value\「,.」</span><span class="sxs-lookup"><span data-stu-id="3846a-323">A string of comma separated string pairs, in the format "\"name\" : \"value\", ..."</span></span>

<span data-ttu-id="3846a-324">メタデータがない場合は、この値は、空の文字列 |。</span><span class="sxs-lookup"><span data-stu-id="3846a-324">If there is no metadata, this value is an empty string.|</span></span> 
  
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="3846a-325">応答の例</span><span class="sxs-lookup"><span data-stu-id="3846a-325">Sample response</span></span>
 
<span data-ttu-id="3846a-326">次の要求の URI は、グローバル ランキングにランクをスキップするかを示しています。</span><span class="sxs-lookup"><span data-stu-id="3846a-326">The following request URI depicts skipping to rank on a global leaderboard.</span></span>
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/TotalFlagsCaptured?include=valuemetadata&maxItems=3&skipToRank=15000
         
```

 
<span data-ttu-id="3846a-327">値のメタデータを取得するために、次のヘッダーを指定もする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3846a-327">In order to return value metadata, the following header must also be specified.</span></span>
 

```cpp
X-Xbl-Contract-Version : 3
          
```

 
<span data-ttu-id="3846a-328">上記の URI は、次の JSON 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="3846a-328">The URI above returns the following JSON response.</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="3846a-329">関連項目</span><span class="sxs-lookup"><span data-stu-id="3846a-329">See also</span></span>
 
<a id="ID4EBMAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3846a-330">Parent</span><span class="sxs-lookup"><span data-stu-id="3846a-330">Parent</span></span> 

[<span data-ttu-id="3846a-331">/scids/{scid}/leaderboards/{leaderboardname}</span><span class="sxs-lookup"><span data-stu-id="3846a-331">/scids/{scid}/leaderboards/{leaderboardname}</span></span>](uri-scidsscidleaderboardsleaderboardname.md)

   