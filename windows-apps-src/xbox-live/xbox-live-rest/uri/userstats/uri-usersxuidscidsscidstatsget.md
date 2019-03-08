---
title: GET (/users/xuid({xuid})/scids/{scid}/stats)
assetID: af117e87-6f1d-6448-9adf-7cf890d1380f
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstatsget.html
description: " GET (/users/xuid({xuid})/scids/{scid}/stats)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: baf965dcbd23bf00d7d0953726f9f20852324e5e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662387"
---
# <a name="get-usersxuidxuidscidsscidstats"></a><span data-ttu-id="943d9-104">GET (/users/xuid({xuid})/scids/{scid}/stats)</span><span class="sxs-lookup"><span data-stu-id="943d9-104">GET (/users/xuid({xuid})/scids/{scid}/stats)</span></span>
<span data-ttu-id="943d9-105">指定したユーザーに代わってユーザー統計名のコンマ区切りリストによってスコープ サービス構成を取得します。</span><span class="sxs-lookup"><span data-stu-id="943d9-105">Gets a service configuration scoped by a comma-delimited list of user statistic names on behalf of the specified user.</span></span>
<span data-ttu-id="943d9-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="943d9-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>

  * [<span data-ttu-id="943d9-107">注釈</span><span class="sxs-lookup"><span data-stu-id="943d9-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="943d9-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="943d9-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="943d9-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="943d9-109">Query string parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="943d9-110">承認</span><span class="sxs-lookup"><span data-stu-id="943d9-110">Authorization</span></span>](#ID4EUC)
  * [<span data-ttu-id="943d9-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="943d9-111">Required Request Headers</span></span>](#ID4EPD)
  * [<span data-ttu-id="943d9-112">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="943d9-112">Optional Request Headers</span></span>](#ID4EYE)
  * [<span data-ttu-id="943d9-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="943d9-113">Request body</span></span>](#ID4E3F)
  * [<span data-ttu-id="943d9-114">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="943d9-114">HTTP status codes</span></span>](#ID4EHG)
  * [<span data-ttu-id="943d9-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="943d9-115">Response body</span></span>](#ID4E5BAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="943d9-116">注釈</span><span class="sxs-lookup"><span data-stu-id="943d9-116">Remarks</span></span>

<span data-ttu-id="943d9-117">クライアントには、新しいプレーヤーの統計情報システムのプレイヤーの代わりのタイトルの統計情報を読み書きする方法が必要があります。</span><span class="sxs-lookup"><span data-stu-id="943d9-117">clients need a way to read and write title statistics on behalf of players to our new player statistics system.</span></span>

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="943d9-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="943d9-118">URI parameters</span></span>

| <span data-ttu-id="943d9-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="943d9-119">Parameter</span></span>| <span data-ttu-id="943d9-120">種類</span><span class="sxs-lookup"><span data-stu-id="943d9-120">Type</span></span>| <span data-ttu-id="943d9-121">説明</span><span class="sxs-lookup"><span data-stu-id="943d9-121">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="943d9-122">xuid</span><span class="sxs-lookup"><span data-stu-id="943d9-122">xuid</span></span>| <span data-ttu-id="943d9-123">GUID</span><span class="sxs-lookup"><span data-stu-id="943d9-123">GUID</span></span>| <span data-ttu-id="943d9-124">Xbox ユーザー ID (XUID) の対象サービスの構成にアクセスするユーザーです。</span><span class="sxs-lookup"><span data-stu-id="943d9-124">Xbox User ID (XUID) of the user on whose behalf to access the service configuration.</span></span>|
| <span data-ttu-id="943d9-125">scid</span><span class="sxs-lookup"><span data-stu-id="943d9-125">scid</span></span>| <span data-ttu-id="943d9-126">GUID</span><span class="sxs-lookup"><span data-stu-id="943d9-126">GUID</span></span>| <span data-ttu-id="943d9-127">アクセスされるリソースを含むサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="943d9-127">Identifier of the service configuration that contains the resource being accessed.</span></span>|

<a id="ID4EPB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="943d9-128">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="943d9-128">Query string parameters</span></span>

| <span data-ttu-id="943d9-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="943d9-129">Parameter</span></span>| <span data-ttu-id="943d9-130">種類</span><span class="sxs-lookup"><span data-stu-id="943d9-130">Type</span></span>| <span data-ttu-id="943d9-131">説明</span><span class="sxs-lookup"><span data-stu-id="943d9-131">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="943d9-132">statNames</span><span class="sxs-lookup"><span data-stu-id="943d9-132">statNames</span></span>| <span data-ttu-id="943d9-133">string</span><span class="sxs-lookup"><span data-stu-id="943d9-133">string</span></span>| <span data-ttu-id="943d9-134">唯一のクエリ文字列パラメーターは、コンマで区切られたユーザー統計名 URI の名詞です。たとえば、次の URI 通知、サービス URI で指定されたユーザー id の代わり、4 つの統計情報が要求したこと。</span><span class="sxs-lookup"><span data-stu-id="943d9-134">The only query string parameter is the comma delimited user statistic name URI noun.For example, the following URI informs the service that four statistics are requested on behalf of the user id specified in the URI.</span></span> <span data-ttu-id="943d9-135">`https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots`1 回の呼び出しで要求できる統計の数に制限があり、この制限には慎重に検討「スイート スポット」開発者の利便性とします。URI の長さの実用性。</span><span class="sxs-lookup"><span data-stu-id="943d9-135">`https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots`There will be a limit on the number of statistics that can be requested in a single call, and that limit will carefully consider a "sweet spot" for developer convenience vs. URI length practicality.</span></span> <span data-ttu-id="943d9-136">たとえば、制限は、統計名のテキスト (コンマを含む) の価値のいずれかの 600 文字または最大 10 個の統計情報によって判断できます。</span><span class="sxs-lookup"><span data-stu-id="943d9-136">For example, the limit might be determined by either 600 characters worth of statistic name text (including the commas), or 10 statistics maximum.</span></span> <span data-ttu-id="943d9-137">このような単純な GET 有効に HTTP が頻度の高いクライアントから呼び出しの量を削減する、一般的に要求の統計情報のキャッシュします。</span><span class="sxs-lookup"><span data-stu-id="943d9-137">Enabling a simple GET like this enables HTTP caching for commonly requested statistics, which reduces call volume from chatty clients.</span></span> |

<a id="ID4EUC"></a>


## <a name="authorization"></a><span data-ttu-id="943d9-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="943d9-138">Authorization</span></span>

<span data-ttu-id="943d9-139">コンテンツの分離とアクセス制御のシナリオで実装された承認ロジックがあります。</span><span class="sxs-lookup"><span data-stu-id="943d9-139">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>

   * <span data-ttu-id="943d9-140">呼び出し元の要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングおよびユーザーの両方の統計情報を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="943d9-140">Both leaderboards and user statistics can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="943d9-141">書き込みは、当然ながら、データ プラットフォームでサポートされているクライアントに制限されます。</span><span class="sxs-lookup"><span data-stu-id="943d9-141">Writes are obviously limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="943d9-142">タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="943d9-142">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="943d9-143">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="943d9-143">Leaderboards are open statistics.</span></span> <span data-ttu-id="943d9-144">統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="943d9-144">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="943d9-145">サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="943d9-145">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>

<span data-ttu-id="943d9-146">チェックの擬似コードのようになります。</span><span class="sxs-lookup"><span data-stu-id="943d9-146">Pseudo-code for the check looks like this:</span></span>


```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.

```


<a id="ID4EPD"></a>


## <a name="required-request-headers"></a><span data-ttu-id="943d9-147">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="943d9-147">Required Request Headers</span></span>

| <span data-ttu-id="943d9-148">Header</span><span class="sxs-lookup"><span data-stu-id="943d9-148">Header</span></span>| <span data-ttu-id="943d9-149">種類</span><span class="sxs-lookup"><span data-stu-id="943d9-149">Type</span></span>| <span data-ttu-id="943d9-150">説明</span><span class="sxs-lookup"><span data-stu-id="943d9-150">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="943d9-151">Authorization</span><span class="sxs-lookup"><span data-stu-id="943d9-151">Authorization</span></span>| <span data-ttu-id="943d9-152">string</span><span class="sxs-lookup"><span data-stu-id="943d9-152">string</span></span>| <span data-ttu-id="943d9-153">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="943d9-153">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="943d9-154">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="943d9-154">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|

<a id="ID4EYE"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="943d9-155">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="943d9-155">Optional Request Headers</span></span>

| <span data-ttu-id="943d9-156">Header</span><span class="sxs-lookup"><span data-stu-id="943d9-156">Header</span></span>| <span data-ttu-id="943d9-157">種類</span><span class="sxs-lookup"><span data-stu-id="943d9-157">Type</span></span>| <span data-ttu-id="943d9-158">説明</span><span class="sxs-lookup"><span data-stu-id="943d9-158">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="943d9-159">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="943d9-159">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="943d9-160">この要求が送られるサービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="943d9-160">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="943d9-161">要求はのみにルーティング サービスの認証トークンの要求ヘッダーの有効性を確認した後と。</span><span class="sxs-lookup"><span data-stu-id="943d9-161">The request will only be routed to that service after verifying the validity of the header, the claims in the authentication token, and so on.</span></span> <span data-ttu-id="943d9-162">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="943d9-162">Default value: 1.</span></span>|

<a id="ID4E3F"></a>


## <a name="request-body"></a><span data-ttu-id="943d9-163">要求本文</span><span class="sxs-lookup"><span data-stu-id="943d9-163">Request body</span></span>

<span data-ttu-id="943d9-164">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="943d9-164">No objects are sent in the body of this request.</span></span>

<a id="ID4EHG"></a>


## <a name="http-status-codes"></a><span data-ttu-id="943d9-165">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="943d9-165">HTTP status codes</span></span>

<span data-ttu-id="943d9-166">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="943d9-166">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="943d9-167">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="943d9-167">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="943d9-168">コード</span><span class="sxs-lookup"><span data-stu-id="943d9-168">Code</span></span>| <span data-ttu-id="943d9-169">理由語句</span><span class="sxs-lookup"><span data-stu-id="943d9-169">Reason phrase</span></span>| <span data-ttu-id="943d9-170">説明</span><span class="sxs-lookup"><span data-stu-id="943d9-170">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="943d9-171">200</span><span class="sxs-lookup"><span data-stu-id="943d9-171">200</span></span>| <span data-ttu-id="943d9-172">OK</span><span class="sxs-lookup"><span data-stu-id="943d9-172">OK</span></span>| <span data-ttu-id="943d9-173">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="943d9-173">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="943d9-174">304</span><span class="sxs-lookup"><span data-stu-id="943d9-174">304</span></span>| <span data-ttu-id="943d9-175">変更されていません</span><span class="sxs-lookup"><span data-stu-id="943d9-175">Not Modified</span></span>| <span data-ttu-id="943d9-176">リソースされていない最後の要求以降に変更します。</span><span class="sxs-lookup"><span data-stu-id="943d9-176">Resource not been modified since last requested.</span></span>|
| <span data-ttu-id="943d9-177">400</span><span class="sxs-lookup"><span data-stu-id="943d9-177">400</span></span>| <span data-ttu-id="943d9-178">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="943d9-178">Bad Request</span></span>| <span data-ttu-id="943d9-179">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="943d9-179">Service could not understand malformed request.</span></span> <span data-ttu-id="943d9-180">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="943d9-180">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="943d9-181">401</span><span class="sxs-lookup"><span data-stu-id="943d9-181">401</span></span>| <span data-ttu-id="943d9-182">権限がありません</span><span class="sxs-lookup"><span data-stu-id="943d9-182">Unauthorized</span></span>| <span data-ttu-id="943d9-183">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="943d9-183">The request requires user authentication.</span></span>|
| <span data-ttu-id="943d9-184">403</span><span class="sxs-lookup"><span data-stu-id="943d9-184">403</span></span>| <span data-ttu-id="943d9-185">Forbidden</span><span class="sxs-lookup"><span data-stu-id="943d9-185">Forbidden</span></span>| <span data-ttu-id="943d9-186">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="943d9-186">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="943d9-187">404</span><span class="sxs-lookup"><span data-stu-id="943d9-187">404</span></span>| <span data-ttu-id="943d9-188">検出不可</span><span class="sxs-lookup"><span data-stu-id="943d9-188">Not Found</span></span>| <span data-ttu-id="943d9-189">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="943d9-189">The specified resource could not be found.</span></span>|
| <span data-ttu-id="943d9-190">406</span><span class="sxs-lookup"><span data-stu-id="943d9-190">406</span></span>| <span data-ttu-id="943d9-191">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="943d9-191">Not Acceptable</span></span>| <span data-ttu-id="943d9-192">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="943d9-192">Resource version is not supported.</span></span>|
| <span data-ttu-id="943d9-193">408</span><span class="sxs-lookup"><span data-stu-id="943d9-193">408</span></span>| <span data-ttu-id="943d9-194">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="943d9-194">Request Timeout</span></span>| <span data-ttu-id="943d9-195">リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。</span><span class="sxs-lookup"><span data-stu-id="943d9-195">Resource version is not supported; should be rejected by the MVC layer.</span></span>|

<a id="ID4E5BAC"></a>


## <a name="response-body"></a><span data-ttu-id="943d9-196">応答本文</span><span class="sxs-lookup"><span data-stu-id="943d9-196">Response body</span></span>

<a id="ID4EECAC"></a>


### <a name="sample-response"></a><span data-ttu-id="943d9-197">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="943d9-197">Sample response</span></span>


```cpp
{
    "user": {
    "xuid": "123456789",
        "gamertag": "WarriorSaint",
        "stats": [
            {
                "statname": "Wins",
                "type": "Integer",
                "value": 40
            },
            {
                "statname": "Kills",
                "type": "Integer",
                "value": 700
            },
            {
                "statname": "KDRatio",
                "type": "Double",
                "value": 2.23
            },
            {
                "statname": "Headshots",
                "type": "Integer",
                "value": 173
            }
        ],
    }
}

```


<a id="ID4EOCAC"></a>


## <a name="see-also"></a><span data-ttu-id="943d9-198">関連項目</span><span class="sxs-lookup"><span data-stu-id="943d9-198">See also</span></span>

<a id="ID4EQCAC"></a>


##### <a name="parent"></a><span data-ttu-id="943d9-199">Parent</span><span class="sxs-lookup"><span data-stu-id="943d9-199">Parent</span></span>

[<span data-ttu-id="943d9-200">/users/xuid({xuid})/scids/{scid}/stats</span><span class="sxs-lookup"><span data-stu-id="943d9-200">/users/xuid({xuid})/scids/{scid}/stats</span></span>](uri-usersxuidscidsscidstats.md)
