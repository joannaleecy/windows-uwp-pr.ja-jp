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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8347603"
---
# <a name="get-usersxuidxuidscidsscidstatsincludevaluemetadata"></a><span data-ttu-id="90c73-104">GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)</span><span class="sxs-lookup"><span data-stu-id="90c73-104">GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)</span></span>
<span data-ttu-id="90c73-105">指定されたサービス構成でのユーザーに対して、統計情報の値に関連付けられたメタデータを含む、指定された統計情報の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="90c73-105">Gets a list of specified statistics, including metadata associated with the statistic values, for a user in a specified service configuration.</span></span>
<span data-ttu-id="90c73-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="90c73-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>

  * [<span data-ttu-id="90c73-107">注釈</span><span class="sxs-lookup"><span data-stu-id="90c73-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="90c73-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90c73-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="90c73-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="90c73-109">Query string parameters</span></span>](#ID4ELB)
  * [<span data-ttu-id="90c73-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="90c73-110">Authorization</span></span>](#ID4EWC)
  * [<span data-ttu-id="90c73-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90c73-111">Required Request Headers</span></span>](#ID4ERD)
  * [<span data-ttu-id="90c73-112">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90c73-112">Optional Request Headers</span></span>](#ID4EDF)
  * [<span data-ttu-id="90c73-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="90c73-113">Request body</span></span>](#ID4EHG)
  * [<span data-ttu-id="90c73-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="90c73-114">HTTP status codes</span></span>](#ID4ESG)
  * [<span data-ttu-id="90c73-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="90c73-115">Response body</span></span>](#ID4EJCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="90c73-116">注釈</span><span class="sxs-lookup"><span data-stu-id="90c73-116">Remarks</span></span>

<span data-ttu-id="90c73-117">しますか? を含める = valuemetadata クエリ パラメーターでは、モデルとレース トラックの時間を実現するために使用される車の色など、ユーザーの統計値に関連付けられたメタデータを含めるへの応答します。</span><span class="sxs-lookup"><span data-stu-id="90c73-117">The ?include=valuemetadata query parameter allows the response to include any metadata associated with the user stat values, such as the model and color of a car used to achieve a time on a race track.</span></span>

<span data-ttu-id="90c73-118">応答には、値のメタデータを含める、要求の呼び出しが 3 のヘッダー値 X Xbl コントラクト バージョンを設定することもあります。</span><span class="sxs-lookup"><span data-stu-id="90c73-118">To include value metadata in the response, the request call must also set the header value X-Xbl-Contract-Version to 3.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="90c73-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90c73-119">URI parameters</span></span>

| <span data-ttu-id="90c73-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="90c73-120">Parameter</span></span>| <span data-ttu-id="90c73-121">型</span><span class="sxs-lookup"><span data-stu-id="90c73-121">Type</span></span>| <span data-ttu-id="90c73-122">説明</span><span class="sxs-lookup"><span data-stu-id="90c73-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="90c73-123">xuid</span><span class="sxs-lookup"><span data-stu-id="90c73-123">xuid</span></span>| <span data-ttu-id="90c73-124">GUID</span><span class="sxs-lookup"><span data-stu-id="90c73-124">GUID</span></span>| <span data-ttu-id="90c73-125">Xbox ユーザー ID (XUID) サービス構成にアクセスする対象ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="90c73-125">Xbox User ID (XUID) of the user on whose behalf to access the service configuration.</span></span>|
| <span data-ttu-id="90c73-126">scid</span><span class="sxs-lookup"><span data-stu-id="90c73-126">scid</span></span>| <span data-ttu-id="90c73-127">GUID</span><span class="sxs-lookup"><span data-stu-id="90c73-127">GUID</span></span>| <span data-ttu-id="90c73-128">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="90c73-128">Identifier of the service configuration that contains the resource being accessed.</span></span>|

<a id="ID4ELB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="90c73-129">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="90c73-129">Query string parameters</span></span>

| <span data-ttu-id="90c73-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="90c73-130">Parameter</span></span>| <span data-ttu-id="90c73-131">型</span><span class="sxs-lookup"><span data-stu-id="90c73-131">Type</span></span>| <span data-ttu-id="90c73-132">説明</span><span class="sxs-lookup"><span data-stu-id="90c73-132">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="90c73-133">statNames</span><span class="sxs-lookup"><span data-stu-id="90c73-133">statNames</span></span>| <span data-ttu-id="90c73-134">string</span><span class="sxs-lookup"><span data-stu-id="90c73-134">string</span></span>| <span data-ttu-id="90c73-135">コンマ区切りの統計情報のユーザー名のリスト。たとえば、次の URI は、通知サービス URI で指定されたユーザー id の代理として 4 つの統計情報を要求します。{: nomakrdown}</span><span class="sxs-lookup"><span data-stu-id="90c73-135">A comma delimited list of user statistic names.For example, the following URI informs the service that four statistics are requested on behalf of the user id specified in the URI.{::nomakrdown}</span></span><br/><br/>`https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots?include=valuemetadata`| 
| <span data-ttu-id="90c73-136">含める = valuemetadata</span><span class="sxs-lookup"><span data-stu-id="90c73-136">include=valuemetadata</span></span>| <span data-ttu-id="90c73-137">string</span><span class="sxs-lookup"><span data-stu-id="90c73-137">string</span></span>| <span data-ttu-id="90c73-138">応答には、uset 統計の値に関連付けられた値メタデータが含まれていることを示します。</span><span class="sxs-lookup"><span data-stu-id="90c73-138">Indicates that the response includes any value metadata associated with the uset stat values.</span></span>|

<a id="ID4EWC"></a>


## <a name="authorization"></a><span data-ttu-id="90c73-139">Authorization</span><span class="sxs-lookup"><span data-stu-id="90c73-139">Authorization</span></span>

<span data-ttu-id="90c73-140">承認ロジック コンテンツ分離とアクセス制御のシナリオの実装があります。</span><span class="sxs-lookup"><span data-stu-id="90c73-140">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>

   * <span data-ttu-id="90c73-141">ランキング、およびユーザーの両方の統計情報は、呼び出し元が要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントから読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="90c73-141">Both leaderboards and user statistics can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="90c73-142">書き込みは、データ プラットフォームでサポートされているクライアントに制限されます。</span><span class="sxs-lookup"><span data-stu-id="90c73-142">Writes are limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="90c73-143">タイトル デベロッパーは、open または XDP またはパートナー センターで制限付きの統計情報をマークできます。</span><span class="sxs-lookup"><span data-stu-id="90c73-143">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="90c73-144">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="90c73-144">Leaderboards are open statistics.</span></span> <span data-ttu-id="90c73-145">開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="90c73-145">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="90c73-146">サンド ボックスへのユーザーの承認は XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="90c73-146">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>

<span data-ttu-id="90c73-147">チェックの擬似コードは、このようになります。</span><span class="sxs-lookup"><span data-stu-id="90c73-147">Pseudo-code for the check looks like this:</span></span>


```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.

```


<a id="ID4ERD"></a>


## <a name="required-request-headers"></a><span data-ttu-id="90c73-148">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90c73-148">Required Request Headers</span></span>

| <span data-ttu-id="90c73-149">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90c73-149">Header</span></span>| <span data-ttu-id="90c73-150">型</span><span class="sxs-lookup"><span data-stu-id="90c73-150">Type</span></span>| <span data-ttu-id="90c73-151">説明</span><span class="sxs-lookup"><span data-stu-id="90c73-151">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="90c73-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="90c73-152">Authorization</span></span>| <span data-ttu-id="90c73-153">string</span><span class="sxs-lookup"><span data-stu-id="90c73-153">string</span></span>| <span data-ttu-id="90c73-154">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="90c73-154">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="90c73-155">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="90c73-155">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="90c73-156">X Xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="90c73-156">X-Xbl-Contract-Version</span></span>| <span data-ttu-id="90c73-157">string</span><span class="sxs-lookup"><span data-stu-id="90c73-157">string</span></span>| <span data-ttu-id="90c73-158">使用する API のバージョンを示します。</span><span class="sxs-lookup"><span data-stu-id="90c73-158">Indicates which version of the API to use.</span></span> <span data-ttu-id="90c73-159">この値は、応答に値のメタデータを含めるために、「3」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90c73-159">This value must be set to "3" in order to include value metadata in the response.</span></span>|

<a id="ID4EDF"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="90c73-160">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90c73-160">Optional Request Headers</span></span>

| <span data-ttu-id="90c73-161">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90c73-161">Header</span></span>| <span data-ttu-id="90c73-162">型</span><span class="sxs-lookup"><span data-stu-id="90c73-162">Type</span></span>| <span data-ttu-id="90c73-163">説明</span><span class="sxs-lookup"><span data-stu-id="90c73-163">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="90c73-164">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="90c73-164">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="90c73-165">この要求を送信する必要があります、サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="90c73-165">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="90c73-166">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="90c73-166">The request will only be routed to that service after verifying the validity of the header, the claims in the authentication token, and so on.</span></span> <span data-ttu-id="90c73-167">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="90c73-167">Default value: 1.</span></span>|

<a id="ID4EHG"></a>


## <a name="request-body"></a><span data-ttu-id="90c73-168">要求本文</span><span class="sxs-lookup"><span data-stu-id="90c73-168">Request body</span></span>

<span data-ttu-id="90c73-169">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="90c73-169">No objects are sent in the body of this request.</span></span>

<a id="ID4ESG"></a>


## <a name="http-status-codes"></a><span data-ttu-id="90c73-170">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="90c73-170">HTTP status codes</span></span>

<span data-ttu-id="90c73-171">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="90c73-171">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="90c73-172">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90c73-172">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="90c73-173">コード</span><span class="sxs-lookup"><span data-stu-id="90c73-173">Code</span></span>| <span data-ttu-id="90c73-174">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="90c73-174">Reason phrase</span></span>| <span data-ttu-id="90c73-175">説明</span><span class="sxs-lookup"><span data-stu-id="90c73-175">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="90c73-176">200</span><span class="sxs-lookup"><span data-stu-id="90c73-176">200</span></span>| <span data-ttu-id="90c73-177">OK</span><span class="sxs-lookup"><span data-stu-id="90c73-177">OK</span></span>| <span data-ttu-id="90c73-178">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="90c73-178">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="90c73-179">304</span><span class="sxs-lookup"><span data-stu-id="90c73-179">304</span></span>| <span data-ttu-id="90c73-180">Not Modified</span><span class="sxs-lookup"><span data-stu-id="90c73-180">Not Modified</span></span>| <span data-ttu-id="90c73-181">リソースされていない以降に変更するように要求します。</span><span class="sxs-lookup"><span data-stu-id="90c73-181">Resource not been modified since last requested.</span></span>|
| <span data-ttu-id="90c73-182">400</span><span class="sxs-lookup"><span data-stu-id="90c73-182">400</span></span>| <span data-ttu-id="90c73-183">Bad Request</span><span class="sxs-lookup"><span data-stu-id="90c73-183">Bad Request</span></span>| <span data-ttu-id="90c73-184">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="90c73-184">Service could not understand malformed request.</span></span> <span data-ttu-id="90c73-185">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="90c73-185">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="90c73-186">401</span><span class="sxs-lookup"><span data-stu-id="90c73-186">401</span></span>| <span data-ttu-id="90c73-187">権限がありません</span><span class="sxs-lookup"><span data-stu-id="90c73-187">Unauthorized</span></span>| <span data-ttu-id="90c73-188">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="90c73-188">The request requires user authentication.</span></span>|
| <span data-ttu-id="90c73-189">403</span><span class="sxs-lookup"><span data-stu-id="90c73-189">403</span></span>| <span data-ttu-id="90c73-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="90c73-190">Forbidden</span></span>| <span data-ttu-id="90c73-191">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="90c73-191">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="90c73-192">404</span><span class="sxs-lookup"><span data-stu-id="90c73-192">404</span></span>| <span data-ttu-id="90c73-193">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="90c73-193">Not Found</span></span>| <span data-ttu-id="90c73-194">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="90c73-194">The specified resource could not be found.</span></span>|
| <span data-ttu-id="90c73-195">406</span><span class="sxs-lookup"><span data-stu-id="90c73-195">406</span></span>| <span data-ttu-id="90c73-196">許容できません。</span><span class="sxs-lookup"><span data-stu-id="90c73-196">Not Acceptable</span></span>| <span data-ttu-id="90c73-197">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="90c73-197">Resource version is not supported.</span></span>|
| <span data-ttu-id="90c73-198">408</span><span class="sxs-lookup"><span data-stu-id="90c73-198">408</span></span>| <span data-ttu-id="90c73-199">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="90c73-199">Request Timeout</span></span>| <span data-ttu-id="90c73-200">リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90c73-200">Resource version is not supported; should be rejected by the MVC layer.</span></span>|

<a id="ID4EJCAC"></a>


## <a name="response-body"></a><span data-ttu-id="90c73-201">応答本文</span><span class="sxs-lookup"><span data-stu-id="90c73-201">Response body</span></span>

<a id="ID4EPCAC"></a>


### <a name="sample-response"></a><span data-ttu-id="90c73-202">応答の例</span><span class="sxs-lookup"><span data-stu-id="90c73-202">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="90c73-203">関連項目</span><span class="sxs-lookup"><span data-stu-id="90c73-203">See also</span></span>

<a id="ID4E2CAC"></a>


##### <a name="parent"></a><span data-ttu-id="90c73-204">Parent</span><span class="sxs-lookup"><span data-stu-id="90c73-204">Parent</span></span>

[<span data-ttu-id="90c73-205">/users/xuid({xuid})/scids/{scid}/stats</span><span class="sxs-lookup"><span data-stu-id="90c73-205">/users/xuid({xuid})/scids/{scid}/stats</span></span>](uri-usersxuidscidsscidstats.md)
