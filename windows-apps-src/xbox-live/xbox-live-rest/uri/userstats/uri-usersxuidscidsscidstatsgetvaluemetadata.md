---
title: GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)
assetID: 890e3f93-4fdc-955f-d849-ba9579d5c1eb
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstatsgetvaluemetadata.html
description: " GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 55ad44d4c29a2d7a43c76c4df2a78e08462fa65f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612717"
---
# <a name="get-usersxuidxuidscidsscidstatsincludevaluemetadata"></a><span data-ttu-id="ea3ff-104">GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)</span><span class="sxs-lookup"><span data-stu-id="ea3ff-104">GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)</span></span>
<span data-ttu-id="ea3ff-105">指定したサービス構成内のユーザーに対して、統計情報の値に関連付けられているメタデータを含む、指定した統計情報の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-105">Gets a list of specified statistics, including metadata associated with the statistic values, for a user in a specified service configuration.</span></span>
<span data-ttu-id="ea3ff-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>

  * [<span data-ttu-id="ea3ff-107">注釈</span><span class="sxs-lookup"><span data-stu-id="ea3ff-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="ea3ff-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ea3ff-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="ea3ff-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ea3ff-109">Query string parameters</span></span>](#ID4ELB)
  * [<span data-ttu-id="ea3ff-110">承認</span><span class="sxs-lookup"><span data-stu-id="ea3ff-110">Authorization</span></span>](#ID4EWC)
  * [<span data-ttu-id="ea3ff-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ea3ff-111">Required Request Headers</span></span>](#ID4ERD)
  * [<span data-ttu-id="ea3ff-112">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ea3ff-112">Optional Request Headers</span></span>](#ID4EDF)
  * [<span data-ttu-id="ea3ff-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="ea3ff-113">Request body</span></span>](#ID4EHG)
  * [<span data-ttu-id="ea3ff-114">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="ea3ff-114">HTTP status codes</span></span>](#ID4ESG)
  * [<span data-ttu-id="ea3ff-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="ea3ff-115">Response body</span></span>](#ID4EJCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="ea3ff-116">注釈</span><span class="sxs-lookup"><span data-stu-id="ea3ff-116">Remarks</span></span>

<span data-ttu-id="ea3ff-117">でしょうか。 含める valuemetadata = クエリ パラメーターは、ユーザーの統計値など、モデルと競合トラック上の時間を実現するために使用する、車の色に関連付けられたメタデータを含めるへの応答を使用できます。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-117">The ?include=valuemetadata query parameter allows the response to include any metadata associated with the user stat values, such as the model and color of a car used to achieve a time on a race track.</span></span>

<span data-ttu-id="ea3ff-118">値のメタデータを応答に含めるに要求の呼び出しが 3 の X Xbl コントラクト バージョン ヘッダーの値を設定することもあります。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-118">To include value metadata in the response, the request call must also set the header value X-Xbl-Contract-Version to 3.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="ea3ff-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ea3ff-119">URI parameters</span></span>

| <span data-ttu-id="ea3ff-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ea3ff-120">Parameter</span></span>| <span data-ttu-id="ea3ff-121">種類</span><span class="sxs-lookup"><span data-stu-id="ea3ff-121">Type</span></span>| <span data-ttu-id="ea3ff-122">説明</span><span class="sxs-lookup"><span data-stu-id="ea3ff-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="ea3ff-123">xuid</span><span class="sxs-lookup"><span data-stu-id="ea3ff-123">xuid</span></span>| <span data-ttu-id="ea3ff-124">GUID</span><span class="sxs-lookup"><span data-stu-id="ea3ff-124">GUID</span></span>| <span data-ttu-id="ea3ff-125">Xbox ユーザー ID (XUID) の対象サービスの構成にアクセスするユーザーです。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-125">Xbox User ID (XUID) of the user on whose behalf to access the service configuration.</span></span>|
| <span data-ttu-id="ea3ff-126">scid</span><span class="sxs-lookup"><span data-stu-id="ea3ff-126">scid</span></span>| <span data-ttu-id="ea3ff-127">GUID</span><span class="sxs-lookup"><span data-stu-id="ea3ff-127">GUID</span></span>| <span data-ttu-id="ea3ff-128">アクセスされるリソースを含むサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-128">Identifier of the service configuration that contains the resource being accessed.</span></span>|

<a id="ID4ELB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="ea3ff-129">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ea3ff-129">Query string parameters</span></span>

| <span data-ttu-id="ea3ff-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ea3ff-130">Parameter</span></span>| <span data-ttu-id="ea3ff-131">種類</span><span class="sxs-lookup"><span data-stu-id="ea3ff-131">Type</span></span>| <span data-ttu-id="ea3ff-132">説明</span><span class="sxs-lookup"><span data-stu-id="ea3ff-132">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ea3ff-133">statNames</span><span class="sxs-lookup"><span data-stu-id="ea3ff-133">statNames</span></span>| <span data-ttu-id="ea3ff-134">string</span><span class="sxs-lookup"><span data-stu-id="ea3ff-134">string</span></span>| <span data-ttu-id="ea3ff-135">ユーザー統計名のリストのコンマ区切り。たとえば、次の URI 通知、サービス URI で指定されたユーザー id の代わり、4 つの統計情報が要求したこと。{0}:: nomakrdown}</span><span class="sxs-lookup"><span data-stu-id="ea3ff-135">A comma delimited list of user statistic names.For example, the following URI informs the service that four statistics are requested on behalf of the user id specified in the URI.{::nomakrdown}</span></span><br/><br/>`https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots?include=valuemetadata`| 
| <span data-ttu-id="ea3ff-136">含める valuemetadata を =</span><span class="sxs-lookup"><span data-stu-id="ea3ff-136">include=valuemetadata</span></span>| <span data-ttu-id="ea3ff-137">string</span><span class="sxs-lookup"><span data-stu-id="ea3ff-137">string</span></span>| <span data-ttu-id="ea3ff-138">応答に使用統計値に関連付けられた任意の値のメタデータが含まれていることを示します。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-138">Indicates that the response includes any value metadata associated with the uset stat values.</span></span>|

<a id="ID4EWC"></a>


## <a name="authorization"></a><span data-ttu-id="ea3ff-139">Authorization</span><span class="sxs-lookup"><span data-stu-id="ea3ff-139">Authorization</span></span>

<span data-ttu-id="ea3ff-140">コンテンツの分離とアクセス制御のシナリオで実装された承認ロジックがあります。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-140">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>

   * <span data-ttu-id="ea3ff-141">呼び出し元の要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングおよびユーザーの両方の統計情報を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-141">Both leaderboards and user statistics can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="ea3ff-142">書き込みは、データ プラットフォームでサポートされているクライアントに制限されます。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-142">Writes are limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="ea3ff-143">タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-143">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="ea3ff-144">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-144">Leaderboards are open statistics.</span></span> <span data-ttu-id="ea3ff-145">統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-145">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="ea3ff-146">サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-146">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>

<span data-ttu-id="ea3ff-147">チェックの擬似コードのようになります。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-147">Pseudo-code for the check looks like this:</span></span>


```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.

```


<a id="ID4ERD"></a>


## <a name="required-request-headers"></a><span data-ttu-id="ea3ff-148">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ea3ff-148">Required Request Headers</span></span>

| <span data-ttu-id="ea3ff-149">Header</span><span class="sxs-lookup"><span data-stu-id="ea3ff-149">Header</span></span>| <span data-ttu-id="ea3ff-150">種類</span><span class="sxs-lookup"><span data-stu-id="ea3ff-150">Type</span></span>| <span data-ttu-id="ea3ff-151">説明</span><span class="sxs-lookup"><span data-stu-id="ea3ff-151">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ea3ff-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="ea3ff-152">Authorization</span></span>| <span data-ttu-id="ea3ff-153">string</span><span class="sxs-lookup"><span data-stu-id="ea3ff-153">string</span></span>| <span data-ttu-id="ea3ff-154">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-154">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="ea3ff-155">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-155">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="ea3ff-156">X Xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="ea3ff-156">X-Xbl-Contract-Version</span></span>| <span data-ttu-id="ea3ff-157">string</span><span class="sxs-lookup"><span data-stu-id="ea3ff-157">string</span></span>| <span data-ttu-id="ea3ff-158">使用する API のバージョンを示します。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-158">Indicates which version of the API to use.</span></span> <span data-ttu-id="ea3ff-159">この値は、値のメタデータを応答に含めるために、「3」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-159">This value must be set to "3" in order to include value metadata in the response.</span></span>|

<a id="ID4EDF"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="ea3ff-160">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ea3ff-160">Optional Request Headers</span></span>

| <span data-ttu-id="ea3ff-161">Header</span><span class="sxs-lookup"><span data-stu-id="ea3ff-161">Header</span></span>| <span data-ttu-id="ea3ff-162">種類</span><span class="sxs-lookup"><span data-stu-id="ea3ff-162">Type</span></span>| <span data-ttu-id="ea3ff-163">説明</span><span class="sxs-lookup"><span data-stu-id="ea3ff-163">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ea3ff-164">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="ea3ff-164">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="ea3ff-165">この要求が送られるサービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-165">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="ea3ff-166">要求はのみにルーティング サービスの認証トークンの要求ヘッダーの有効性を確認した後と。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-166">The request will only be routed to that service after verifying the validity of the header, the claims in the authentication token, and so on.</span></span> <span data-ttu-id="ea3ff-167">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="ea3ff-167">Default value: 1.</span></span>|

<a id="ID4EHG"></a>


## <a name="request-body"></a><span data-ttu-id="ea3ff-168">要求本文</span><span class="sxs-lookup"><span data-stu-id="ea3ff-168">Request body</span></span>

<span data-ttu-id="ea3ff-169">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-169">No objects are sent in the body of this request.</span></span>

<a id="ID4ESG"></a>


## <a name="http-status-codes"></a><span data-ttu-id="ea3ff-170">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="ea3ff-170">HTTP status codes</span></span>

<span data-ttu-id="ea3ff-171">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-171">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="ea3ff-172">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-172">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="ea3ff-173">コード</span><span class="sxs-lookup"><span data-stu-id="ea3ff-173">Code</span></span>| <span data-ttu-id="ea3ff-174">理由語句</span><span class="sxs-lookup"><span data-stu-id="ea3ff-174">Reason phrase</span></span>| <span data-ttu-id="ea3ff-175">説明</span><span class="sxs-lookup"><span data-stu-id="ea3ff-175">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ea3ff-176">200</span><span class="sxs-lookup"><span data-stu-id="ea3ff-176">200</span></span>| <span data-ttu-id="ea3ff-177">OK</span><span class="sxs-lookup"><span data-stu-id="ea3ff-177">OK</span></span>| <span data-ttu-id="ea3ff-178">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-178">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="ea3ff-179">304</span><span class="sxs-lookup"><span data-stu-id="ea3ff-179">304</span></span>| <span data-ttu-id="ea3ff-180">変更されていません</span><span class="sxs-lookup"><span data-stu-id="ea3ff-180">Not Modified</span></span>| <span data-ttu-id="ea3ff-181">リソースされていない最後の要求以降に変更します。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-181">Resource not been modified since last requested.</span></span>|
| <span data-ttu-id="ea3ff-182">400</span><span class="sxs-lookup"><span data-stu-id="ea3ff-182">400</span></span>| <span data-ttu-id="ea3ff-183">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="ea3ff-183">Bad Request</span></span>| <span data-ttu-id="ea3ff-184">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-184">Service could not understand malformed request.</span></span> <span data-ttu-id="ea3ff-185">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-185">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="ea3ff-186">401</span><span class="sxs-lookup"><span data-stu-id="ea3ff-186">401</span></span>| <span data-ttu-id="ea3ff-187">権限がありません</span><span class="sxs-lookup"><span data-stu-id="ea3ff-187">Unauthorized</span></span>| <span data-ttu-id="ea3ff-188">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-188">The request requires user authentication.</span></span>|
| <span data-ttu-id="ea3ff-189">403</span><span class="sxs-lookup"><span data-stu-id="ea3ff-189">403</span></span>| <span data-ttu-id="ea3ff-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="ea3ff-190">Forbidden</span></span>| <span data-ttu-id="ea3ff-191">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-191">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="ea3ff-192">404</span><span class="sxs-lookup"><span data-stu-id="ea3ff-192">404</span></span>| <span data-ttu-id="ea3ff-193">検出不可</span><span class="sxs-lookup"><span data-stu-id="ea3ff-193">Not Found</span></span>| <span data-ttu-id="ea3ff-194">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-194">The specified resource could not be found.</span></span>|
| <span data-ttu-id="ea3ff-195">406</span><span class="sxs-lookup"><span data-stu-id="ea3ff-195">406</span></span>| <span data-ttu-id="ea3ff-196">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="ea3ff-196">Not Acceptable</span></span>| <span data-ttu-id="ea3ff-197">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-197">Resource version is not supported.</span></span>|
| <span data-ttu-id="ea3ff-198">408</span><span class="sxs-lookup"><span data-stu-id="ea3ff-198">408</span></span>| <span data-ttu-id="ea3ff-199">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="ea3ff-199">Request Timeout</span></span>| <span data-ttu-id="ea3ff-200">リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。</span><span class="sxs-lookup"><span data-stu-id="ea3ff-200">Resource version is not supported; should be rejected by the MVC layer.</span></span>|

<a id="ID4EJCAC"></a>


## <a name="response-body"></a><span data-ttu-id="ea3ff-201">応答本文</span><span class="sxs-lookup"><span data-stu-id="ea3ff-201">Response body</span></span>

<a id="ID4EPCAC"></a>


### <a name="sample-response"></a><span data-ttu-id="ea3ff-202">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="ea3ff-202">Sample response</span></span>


```cpp
{
  "user": {
    "xuid": "123456789",
    "gamertag": "WarriorSaint",
    "stats": [
      {
        "statname": "Wins",
        "type": "Integer",
        "value": 40,
        "valuemetadata" : "{\"region\" : \"EU\", \"isRanked\" : true}"
      },
      {
        "statname": "Kills",
        "type": "Integer",
        "value": 700,
        "valuemetadata" : "{\"longestKillStreak" : 15, \"favoriteTarget\" : \"CrazyPigeon\"}"
      },
      {
        "statname": "KDRatio",
        "type": "Double",
        "value": 2.23,
        "valuemetadata" : "{\"totalKills\" : 700, \"totalDeaths\" : 314}"
      },
      {
        "statname": "Headshots",
        "type": "Integer",
        "value": 173,
        "valuemetadata" : ""
      }
    ],
  }
}

```


<a id="ID4EZCAC"></a>


## <a name="see-also"></a><span data-ttu-id="ea3ff-203">関連項目</span><span class="sxs-lookup"><span data-stu-id="ea3ff-203">See also</span></span>

<a id="ID4E2CAC"></a>


##### <a name="parent"></a><span data-ttu-id="ea3ff-204">Parent</span><span class="sxs-lookup"><span data-stu-id="ea3ff-204">Parent</span></span>

[<span data-ttu-id="ea3ff-205">/users/xuid({xuid})/scids/{scid}/stats</span><span class="sxs-lookup"><span data-stu-id="ea3ff-205">/users/xuid({xuid})/scids/{scid}/stats</span></span>](uri-usersxuidscidsscidstats.md)
