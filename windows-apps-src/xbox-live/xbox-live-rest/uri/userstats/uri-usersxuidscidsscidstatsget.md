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
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8748331"
---
# <a name="get-usersxuidxuidscidsscidstats"></a><span data-ttu-id="d448e-104">GET (/users/xuid({xuid})/scids/{scid}/stats)</span><span class="sxs-lookup"><span data-stu-id="d448e-104">GET (/users/xuid({xuid})/scids/{scid}/stats)</span></span>
<span data-ttu-id="d448e-105">スコープ指定されたユーザーに代わってユーザー統計情報名のコンマ区切りのリストでサービス構成を取得します。</span><span class="sxs-lookup"><span data-stu-id="d448e-105">Gets a service configuration scoped by a comma-delimited list of user statistic names on behalf of the specified user.</span></span>
<span data-ttu-id="d448e-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d448e-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>

  * [<span data-ttu-id="d448e-107">注釈</span><span class="sxs-lookup"><span data-stu-id="d448e-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="d448e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d448e-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="d448e-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="d448e-109">Query string parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="d448e-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="d448e-110">Authorization</span></span>](#ID4EUC)
  * [<span data-ttu-id="d448e-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d448e-111">Required Request Headers</span></span>](#ID4EPD)
  * [<span data-ttu-id="d448e-112">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d448e-112">Optional Request Headers</span></span>](#ID4EYE)
  * [<span data-ttu-id="d448e-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="d448e-113">Request body</span></span>](#ID4E3F)
  * [<span data-ttu-id="d448e-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="d448e-114">HTTP status codes</span></span>](#ID4EHG)
  * [<span data-ttu-id="d448e-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="d448e-115">Response body</span></span>](#ID4E5BAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="d448e-116">注釈</span><span class="sxs-lookup"><span data-stu-id="d448e-116">Remarks</span></span>

<span data-ttu-id="d448e-117">クライアントには、読み取りし、新しいプレイヤーの統計情報システムにプレイヤーの代理としてタイトルの統計情報を記述する方法が必要があります。</span><span class="sxs-lookup"><span data-stu-id="d448e-117">clients need a way to read and write title statistics on behalf of players to our new player statistics system.</span></span>

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="d448e-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d448e-118">URI parameters</span></span>

| <span data-ttu-id="d448e-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d448e-119">Parameter</span></span>| <span data-ttu-id="d448e-120">型</span><span class="sxs-lookup"><span data-stu-id="d448e-120">Type</span></span>| <span data-ttu-id="d448e-121">説明</span><span class="sxs-lookup"><span data-stu-id="d448e-121">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="d448e-122">xuid</span><span class="sxs-lookup"><span data-stu-id="d448e-122">xuid</span></span>| <span data-ttu-id="d448e-123">GUID</span><span class="sxs-lookup"><span data-stu-id="d448e-123">GUID</span></span>| <span data-ttu-id="d448e-124">Xbox ユーザー ID (XUID) がに代わってサービス構成にアクセスするユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="d448e-124">Xbox User ID (XUID) of the user on whose behalf to access the service configuration.</span></span>|
| <span data-ttu-id="d448e-125">scid</span><span class="sxs-lookup"><span data-stu-id="d448e-125">scid</span></span>| <span data-ttu-id="d448e-126">GUID</span><span class="sxs-lookup"><span data-stu-id="d448e-126">GUID</span></span>| <span data-ttu-id="d448e-127">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="d448e-127">Identifier of the service configuration that contains the resource being accessed.</span></span>|

<a id="ID4EPB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="d448e-128">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="d448e-128">Query string parameters</span></span>

| <span data-ttu-id="d448e-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d448e-129">Parameter</span></span>| <span data-ttu-id="d448e-130">型</span><span class="sxs-lookup"><span data-stu-id="d448e-130">Type</span></span>| <span data-ttu-id="d448e-131">説明</span><span class="sxs-lookup"><span data-stu-id="d448e-131">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="d448e-132">statNames</span><span class="sxs-lookup"><span data-stu-id="d448e-132">statNames</span></span>| <span data-ttu-id="d448e-133">string</span><span class="sxs-lookup"><span data-stu-id="d448e-133">string</span></span>| <span data-ttu-id="d448e-134">唯一のクエリ文字列パラメーターは、コンマで区切られたユーザー統計情報名 URI 名詞です。たとえば、次の URI では、サービスが通知 URI で指定されたユーザー id の代理として 4 つの統計情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="d448e-134">The only query string parameter is the comma delimited user statistic name URI noun.For example, the following URI informs the service that four statistics are requested on behalf of the user id specified in the URI.</span></span> `https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots`<span data-ttu-id="d448e-135">1 つの呼び出しで要求できる統計の数に制限があり、その制限は URI の長さの実用性と開発者の利便性の「スイート スポット」を慎重に検討します。</span><span class="sxs-lookup"><span data-stu-id="d448e-135">There will be a limit on the number of statistics that can be requested in a single call, and that limit will carefully consider a "sweet spot" for developer convenience vs. URI length practicality.</span></span> <span data-ttu-id="d448e-136">たとえば、制限は、統計情報名のテキスト (コンマを含む) の価値があるか 600 文字または最大 10 個の統計情報によって決まります可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d448e-136">For example, the limit might be determined by either 600 characters worth of statistic name text (including the commas), or 10 statistics maximum.</span></span> <span data-ttu-id="d448e-137">このようなシンプルな GET を有効にするようにクライアントからの呼び出しの量は減少よく要求される統計情報の HTTP がキャッシュされるようにします。</span><span class="sxs-lookup"><span data-stu-id="d448e-137">Enabling a simple GET like this enables HTTP caching for commonly requested statistics, which reduces call volume from chatty clients.</span></span> |

<a id="ID4EUC"></a>


## <a name="authorization"></a><span data-ttu-id="d448e-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="d448e-138">Authorization</span></span>

<span data-ttu-id="d448e-139">コンテンツ分離とアクセス制御のシナリオ向けに実装承認ロジックがあります。</span><span class="sxs-lookup"><span data-stu-id="d448e-139">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>

   * <span data-ttu-id="d448e-140">ランキング、およびユーザーの両方の統計情報は、呼び出し元が要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントから読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="d448e-140">Both leaderboards and user statistics can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="d448e-141">書き込みは、データ プラットフォームでサポートされているクライアントに明らかに制限されます。</span><span class="sxs-lookup"><span data-stu-id="d448e-141">Writes are obviously limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="d448e-142">タイトル デベロッパーは、open または XDP またはパートナー センターで制限付きの統計情報をマークできます。</span><span class="sxs-lookup"><span data-stu-id="d448e-142">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="d448e-143">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="d448e-143">Leaderboards are open statistics.</span></span> <span data-ttu-id="d448e-144">開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="d448e-144">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="d448e-145">サンド ボックスへのユーザーの承認は XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="d448e-145">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>

<span data-ttu-id="d448e-146">チェックの擬似コードは、このようになります。</span><span class="sxs-lookup"><span data-stu-id="d448e-146">Pseudo-code for the check looks like this:</span></span>


```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.

```


<a id="ID4EPD"></a>


## <a name="required-request-headers"></a><span data-ttu-id="d448e-147">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d448e-147">Required Request Headers</span></span>

| <span data-ttu-id="d448e-148">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d448e-148">Header</span></span>| <span data-ttu-id="d448e-149">型</span><span class="sxs-lookup"><span data-stu-id="d448e-149">Type</span></span>| <span data-ttu-id="d448e-150">説明</span><span class="sxs-lookup"><span data-stu-id="d448e-150">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="d448e-151">Authorization</span><span class="sxs-lookup"><span data-stu-id="d448e-151">Authorization</span></span>| <span data-ttu-id="d448e-152">string</span><span class="sxs-lookup"><span data-stu-id="d448e-152">string</span></span>| <span data-ttu-id="d448e-153">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="d448e-153">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="d448e-154">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="d448e-154">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|

<a id="ID4EYE"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="d448e-155">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d448e-155">Optional Request Headers</span></span>

| <span data-ttu-id="d448e-156">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d448e-156">Header</span></span>| <span data-ttu-id="d448e-157">型</span><span class="sxs-lookup"><span data-stu-id="d448e-157">Type</span></span>| <span data-ttu-id="d448e-158">説明</span><span class="sxs-lookup"><span data-stu-id="d448e-158">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="d448e-159">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="d448e-159">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="d448e-160">この要求を送信する必要があります、サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="d448e-160">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="d448e-161">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="d448e-161">The request will only be routed to that service after verifying the validity of the header, the claims in the authentication token, and so on.</span></span> <span data-ttu-id="d448e-162">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="d448e-162">Default value: 1.</span></span>|

<a id="ID4E3F"></a>


## <a name="request-body"></a><span data-ttu-id="d448e-163">要求本文</span><span class="sxs-lookup"><span data-stu-id="d448e-163">Request body</span></span>

<span data-ttu-id="d448e-164">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="d448e-164">No objects are sent in the body of this request.</span></span>

<a id="ID4EHG"></a>


## <a name="http-status-codes"></a><span data-ttu-id="d448e-165">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="d448e-165">HTTP status codes</span></span>

<span data-ttu-id="d448e-166">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="d448e-166">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="d448e-167">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d448e-167">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="d448e-168">コード</span><span class="sxs-lookup"><span data-stu-id="d448e-168">Code</span></span>| <span data-ttu-id="d448e-169">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="d448e-169">Reason phrase</span></span>| <span data-ttu-id="d448e-170">説明</span><span class="sxs-lookup"><span data-stu-id="d448e-170">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="d448e-171">200</span><span class="sxs-lookup"><span data-stu-id="d448e-171">200</span></span>| <span data-ttu-id="d448e-172">OK</span><span class="sxs-lookup"><span data-stu-id="d448e-172">OK</span></span>| <span data-ttu-id="d448e-173">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="d448e-173">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="d448e-174">304</span><span class="sxs-lookup"><span data-stu-id="d448e-174">304</span></span>| <span data-ttu-id="d448e-175">Not Modified</span><span class="sxs-lookup"><span data-stu-id="d448e-175">Not Modified</span></span>| <span data-ttu-id="d448e-176">リソースされていない以降に変更するように要求します。</span><span class="sxs-lookup"><span data-stu-id="d448e-176">Resource not been modified since last requested.</span></span>|
| <span data-ttu-id="d448e-177">400</span><span class="sxs-lookup"><span data-stu-id="d448e-177">400</span></span>| <span data-ttu-id="d448e-178">Bad Request</span><span class="sxs-lookup"><span data-stu-id="d448e-178">Bad Request</span></span>| <span data-ttu-id="d448e-179">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d448e-179">Service could not understand malformed request.</span></span> <span data-ttu-id="d448e-180">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="d448e-180">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="d448e-181">401</span><span class="sxs-lookup"><span data-stu-id="d448e-181">401</span></span>| <span data-ttu-id="d448e-182">権限がありません</span><span class="sxs-lookup"><span data-stu-id="d448e-182">Unauthorized</span></span>| <span data-ttu-id="d448e-183">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="d448e-183">The request requires user authentication.</span></span>|
| <span data-ttu-id="d448e-184">403</span><span class="sxs-lookup"><span data-stu-id="d448e-184">403</span></span>| <span data-ttu-id="d448e-185">Forbidden</span><span class="sxs-lookup"><span data-stu-id="d448e-185">Forbidden</span></span>| <span data-ttu-id="d448e-186">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="d448e-186">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="d448e-187">404</span><span class="sxs-lookup"><span data-stu-id="d448e-187">404</span></span>| <span data-ttu-id="d448e-188">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="d448e-188">Not Found</span></span>| <span data-ttu-id="d448e-189">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="d448e-189">The specified resource could not be found.</span></span>|
| <span data-ttu-id="d448e-190">406</span><span class="sxs-lookup"><span data-stu-id="d448e-190">406</span></span>| <span data-ttu-id="d448e-191">許容できません。</span><span class="sxs-lookup"><span data-stu-id="d448e-191">Not Acceptable</span></span>| <span data-ttu-id="d448e-192">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="d448e-192">Resource version is not supported.</span></span>|
| <span data-ttu-id="d448e-193">408</span><span class="sxs-lookup"><span data-stu-id="d448e-193">408</span></span>| <span data-ttu-id="d448e-194">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="d448e-194">Request Timeout</span></span>| <span data-ttu-id="d448e-195">リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d448e-195">Resource version is not supported; should be rejected by the MVC layer.</span></span>|

<a id="ID4E5BAC"></a>


## <a name="response-body"></a><span data-ttu-id="d448e-196">応答本文</span><span class="sxs-lookup"><span data-stu-id="d448e-196">Response body</span></span>

<a id="ID4EECAC"></a>


### <a name="sample-response"></a><span data-ttu-id="d448e-197">応答の例</span><span class="sxs-lookup"><span data-stu-id="d448e-197">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="d448e-198">関連項目</span><span class="sxs-lookup"><span data-stu-id="d448e-198">See also</span></span>

<a id="ID4EQCAC"></a>


##### <a name="parent"></a><span data-ttu-id="d448e-199">Parent</span><span class="sxs-lookup"><span data-stu-id="d448e-199">Parent</span></span>

[<span data-ttu-id="d448e-200">/users/xuid({xuid})/scids/{scid}/stats</span><span class="sxs-lookup"><span data-stu-id="d448e-200">/users/xuid({xuid})/scids/{scid}/stats</span></span>](uri-usersxuidscidsscidstats.md)
