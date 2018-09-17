---
title: GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)
assetID: 890e3f93-4fdc-955f-d849-ba9579d5c1eb
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstatsgetvaluemetadata.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2c795dbd2b6193798b472e51526bdd9e2f6b4622
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3982612"
---
# <a name="get-usersxuidxuidscidsscidstatsincludevaluemetadata"></a><span data-ttu-id="fddf0-104">GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)</span><span class="sxs-lookup"><span data-stu-id="fddf0-104">GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)</span></span>
<span data-ttu-id="fddf0-105">指定されたサービス構成内のユーザーの統計情報の値に関連付けられたメタデータを含む、指定された統計情報の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="fddf0-105">Gets a list of specified statistics, including metadata associated with the statistic values, for a user in a specified service configuration.</span></span>
<span data-ttu-id="fddf0-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="fddf0-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>

  * [<span data-ttu-id="fddf0-107">注釈</span><span class="sxs-lookup"><span data-stu-id="fddf0-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="fddf0-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fddf0-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="fddf0-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="fddf0-109">Query string parameters</span></span>](#ID4ELB)
  * [<span data-ttu-id="fddf0-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="fddf0-110">Authorization</span></span>](#ID4EWC)
  * [<span data-ttu-id="fddf0-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fddf0-111">Required Request Headers</span></span>](#ID4ERD)
  * [<span data-ttu-id="fddf0-112">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fddf0-112">Optional Request Headers</span></span>](#ID4EDF)
  * [<span data-ttu-id="fddf0-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="fddf0-113">Request body</span></span>](#ID4EHG)
  * [<span data-ttu-id="fddf0-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="fddf0-114">HTTP status codes</span></span>](#ID4ESG)
  * [<span data-ttu-id="fddf0-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="fddf0-115">Response body</span></span>](#ID4EJCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="fddf0-116">注釈</span><span class="sxs-lookup"><span data-stu-id="fddf0-116">Remarks</span></span>

<span data-ttu-id="fddf0-117">かどうか。 含める = valuemetadata クエリ パラメーターは、モデルとレース トラックで時間を実現するために使用された車の色など、ユーザーの統計値に関連付けられたメタデータを含めるへの応答をことができます。</span><span class="sxs-lookup"><span data-stu-id="fddf0-117">The ?include=valuemetadata query parameter allows the response to include any metadata associated with the user stat values, such as the model and color of a car used to achieve a time on a race track.</span></span>

<span data-ttu-id="fddf0-118">応答には、値のメタデータを含める、要求の呼び出しが 3 のヘッダー値 X Xbl コントラクト バージョンを設定することもあります。</span><span class="sxs-lookup"><span data-stu-id="fddf0-118">To include value metadata in the response, the request call must also set the header value X-Xbl-Contract-Version to 3.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="fddf0-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fddf0-119">URI parameters</span></span>

| <span data-ttu-id="fddf0-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fddf0-120">Parameter</span></span>| <span data-ttu-id="fddf0-121">型</span><span class="sxs-lookup"><span data-stu-id="fddf0-121">Type</span></span>| <span data-ttu-id="fddf0-122">説明</span><span class="sxs-lookup"><span data-stu-id="fddf0-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="fddf0-123">xuid</span><span class="sxs-lookup"><span data-stu-id="fddf0-123">xuid</span></span>| <span data-ttu-id="fddf0-124">GUID</span><span class="sxs-lookup"><span data-stu-id="fddf0-124">GUID</span></span>| <span data-ttu-id="fddf0-125">Xbox ユーザー ID (XUID) がに代わってサービス構成にアクセスするユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="fddf0-125">Xbox User ID (XUID) of the user on whose behalf to access the service configuration.</span></span>|
| <span data-ttu-id="fddf0-126">scid</span><span class="sxs-lookup"><span data-stu-id="fddf0-126">scid</span></span>| <span data-ttu-id="fddf0-127">GUID</span><span class="sxs-lookup"><span data-stu-id="fddf0-127">GUID</span></span>| <span data-ttu-id="fddf0-128">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="fddf0-128">Identifier of the service configuration that contains the resource being accessed.</span></span>|

<a id="ID4ELB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="fddf0-129">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="fddf0-129">Query string parameters</span></span>

| <span data-ttu-id="fddf0-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fddf0-130">Parameter</span></span>| <span data-ttu-id="fddf0-131">型</span><span class="sxs-lookup"><span data-stu-id="fddf0-131">Type</span></span>| <span data-ttu-id="fddf0-132">説明</span><span class="sxs-lookup"><span data-stu-id="fddf0-132">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="fddf0-133">statNames</span><span class="sxs-lookup"><span data-stu-id="fddf0-133">statNames</span></span>| <span data-ttu-id="fddf0-134">string</span><span class="sxs-lookup"><span data-stu-id="fddf0-134">string</span></span>| <span data-ttu-id="fddf0-135">コンマ区切りの統計情報のユーザー名のリスト。たとえば、次の URI 通知サービス URI で指定されたユーザー id の代理として 4 つの統計情報を要求します。{: nomakrdown}</span><span class="sxs-lookup"><span data-stu-id="fddf0-135">A comma delimited list of user statistic names.For example, the following URI informs the service that four statistics are requested on behalf of the user id specified in the URI.{::nomakrdown}</span></span><br/><br/>`https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots?include=valuemetadata`| 
| <span data-ttu-id="fddf0-136">含める = valuemetadata</span><span class="sxs-lookup"><span data-stu-id="fddf0-136">include=valuemetadata</span></span>| <span data-ttu-id="fddf0-137">string</span><span class="sxs-lookup"><span data-stu-id="fddf0-137">string</span></span>| <span data-ttu-id="fddf0-138">応答には、uset 統計の値に関連付けられている任意の値のメタデータが含まれていることを示します。</span><span class="sxs-lookup"><span data-stu-id="fddf0-138">Indicates that the response includes any value metadata associated with the uset stat values.</span></span>|

<a id="ID4EWC"></a>


## <a name="authorization"></a><span data-ttu-id="fddf0-139">Authorization</span><span class="sxs-lookup"><span data-stu-id="fddf0-139">Authorization</span></span>

<span data-ttu-id="fddf0-140">承認ロジック コンテンツ分離とアクセス制御のシナリオの実装があります。</span><span class="sxs-lookup"><span data-stu-id="fddf0-140">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>

   * <span data-ttu-id="fddf0-141">ランキング、およびユーザーの両方の統計情報は、呼び出し元が有効な XSTS トークンの要求で送信するに任意のプラットフォーム上のクライアントから読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="fddf0-141">Both leaderboards and user statistics can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="fddf0-142">書き込みは、データ プラットフォームでサポートされているクライアントに制限されます。</span><span class="sxs-lookup"><span data-stu-id="fddf0-142">Writes are limited to clients supported by the Data Platform.</span></span>
   * <span data-ttu-id="fddf0-143">タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付き統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="fddf0-143">Title developers can mark statistics as open or restricted with XDP or Dev Center.</span></span> <span data-ttu-id="fddf0-144">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="fddf0-144">Leaderboards are open statistics.</span></span> <span data-ttu-id="fddf0-145">開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="fddf0-145">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="fddf0-146">サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="fddf0-146">User authorization to a sandbox is managed through XDP or Dev Center.</span></span>

<span data-ttu-id="fddf0-147">チェックの擬似コードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="fddf0-147">Pseudo-code for the check looks like this:</span></span>


```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.

```


<a id="ID4ERD"></a>


## <a name="required-request-headers"></a><span data-ttu-id="fddf0-148">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fddf0-148">Required Request Headers</span></span>

| <span data-ttu-id="fddf0-149">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fddf0-149">Header</span></span>| <span data-ttu-id="fddf0-150">型</span><span class="sxs-lookup"><span data-stu-id="fddf0-150">Type</span></span>| <span data-ttu-id="fddf0-151">説明</span><span class="sxs-lookup"><span data-stu-id="fddf0-151">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="fddf0-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="fddf0-152">Authorization</span></span>| <span data-ttu-id="fddf0-153">string</span><span class="sxs-lookup"><span data-stu-id="fddf0-153">string</span></span>| <span data-ttu-id="fddf0-154">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="fddf0-154">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="fddf0-155">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。</span><span class="sxs-lookup"><span data-stu-id="fddf0-155">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="fddf0-156">X Xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="fddf0-156">X-Xbl-Contract-Version</span></span>| <span data-ttu-id="fddf0-157">string</span><span class="sxs-lookup"><span data-stu-id="fddf0-157">string</span></span>| <span data-ttu-id="fddf0-158">使用する API のバージョンを示します。</span><span class="sxs-lookup"><span data-stu-id="fddf0-158">Indicates which version of the API to use.</span></span> <span data-ttu-id="fddf0-159">この値は、応答に値のメタデータを含めるために「3」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fddf0-159">This value must be set to "3" in order to include value metadata in the response.</span></span>|

<a id="ID4EDF"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="fddf0-160">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fddf0-160">Optional Request Headers</span></span>

| <span data-ttu-id="fddf0-161">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fddf0-161">Header</span></span>| <span data-ttu-id="fddf0-162">型</span><span class="sxs-lookup"><span data-stu-id="fddf0-162">Type</span></span>| <span data-ttu-id="fddf0-163">説明</span><span class="sxs-lookup"><span data-stu-id="fddf0-163">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="fddf0-164">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="fddf0-164">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="fddf0-165">この要求を送信する必要があります、サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="fddf0-165">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="fddf0-166">要求はのみにルーティングされ、サービスの認証トークン内の要求ヘッダーの有効性を確認した後です。</span><span class="sxs-lookup"><span data-stu-id="fddf0-166">The request will only be routed to that service after verifying the validity of the header, the claims in the authentication token, and so on.</span></span> <span data-ttu-id="fddf0-167">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="fddf0-167">Default value: 1.</span></span>|

<a id="ID4EHG"></a>


## <a name="request-body"></a><span data-ttu-id="fddf0-168">要求本文</span><span class="sxs-lookup"><span data-stu-id="fddf0-168">Request body</span></span>

<span data-ttu-id="fddf0-169">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="fddf0-169">No objects are sent in the body of this request.</span></span>

<a id="ID4ESG"></a>


## <a name="http-status-codes"></a><span data-ttu-id="fddf0-170">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="fddf0-170">HTTP status codes</span></span>

<span data-ttu-id="fddf0-171">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="fddf0-171">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="fddf0-172">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fddf0-172">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="fddf0-173">コード</span><span class="sxs-lookup"><span data-stu-id="fddf0-173">Code</span></span>| <span data-ttu-id="fddf0-174">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="fddf0-174">Reason phrase</span></span>| <span data-ttu-id="fddf0-175">説明</span><span class="sxs-lookup"><span data-stu-id="fddf0-175">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="fddf0-176">200</span><span class="sxs-lookup"><span data-stu-id="fddf0-176">200</span></span>| <span data-ttu-id="fddf0-177">OK</span><span class="sxs-lookup"><span data-stu-id="fddf0-177">OK</span></span>| <span data-ttu-id="fddf0-178">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="fddf0-178">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="fddf0-179">304</span><span class="sxs-lookup"><span data-stu-id="fddf0-179">304</span></span>| <span data-ttu-id="fddf0-180">Not Modified</span><span class="sxs-lookup"><span data-stu-id="fddf0-180">Not Modified</span></span>| <span data-ttu-id="fddf0-181">リソースされていない以降に変更するように要求します。</span><span class="sxs-lookup"><span data-stu-id="fddf0-181">Resource not been modified since last requested.</span></span>|
| <span data-ttu-id="fddf0-182">400</span><span class="sxs-lookup"><span data-stu-id="fddf0-182">400</span></span>| <span data-ttu-id="fddf0-183">Bad Request</span><span class="sxs-lookup"><span data-stu-id="fddf0-183">Bad Request</span></span>| <span data-ttu-id="fddf0-184">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fddf0-184">Service could not understand malformed request.</span></span> <span data-ttu-id="fddf0-185">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="fddf0-185">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="fddf0-186">401</span><span class="sxs-lookup"><span data-stu-id="fddf0-186">401</span></span>| <span data-ttu-id="fddf0-187">権限がありません</span><span class="sxs-lookup"><span data-stu-id="fddf0-187">Unauthorized</span></span>| <span data-ttu-id="fddf0-188">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="fddf0-188">The request requires user authentication.</span></span>|
| <span data-ttu-id="fddf0-189">403</span><span class="sxs-lookup"><span data-stu-id="fddf0-189">403</span></span>| <span data-ttu-id="fddf0-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="fddf0-190">Forbidden</span></span>| <span data-ttu-id="fddf0-191">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="fddf0-191">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="fddf0-192">404</span><span class="sxs-lookup"><span data-stu-id="fddf0-192">404</span></span>| <span data-ttu-id="fddf0-193">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="fddf0-193">Not Found</span></span>| <span data-ttu-id="fddf0-194">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="fddf0-194">The specified resource could not be found.</span></span>|
| <span data-ttu-id="fddf0-195">406</span><span class="sxs-lookup"><span data-stu-id="fddf0-195">406</span></span>| <span data-ttu-id="fddf0-196">許容できません。</span><span class="sxs-lookup"><span data-stu-id="fddf0-196">Not Acceptable</span></span>| <span data-ttu-id="fddf0-197">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="fddf0-197">Resource version is not supported.</span></span>|
| <span data-ttu-id="fddf0-198">408</span><span class="sxs-lookup"><span data-stu-id="fddf0-198">408</span></span>| <span data-ttu-id="fddf0-199">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="fddf0-199">Request Timeout</span></span>| <span data-ttu-id="fddf0-200">リソースのバージョンがサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fddf0-200">Resource version is not supported; should be rejected by the MVC layer.</span></span>|

<a id="ID4EJCAC"></a>


## <a name="response-body"></a><span data-ttu-id="fddf0-201">応答本文</span><span class="sxs-lookup"><span data-stu-id="fddf0-201">Response body</span></span>

<a id="ID4EPCAC"></a>


### <a name="sample-response"></a><span data-ttu-id="fddf0-202">応答の例</span><span class="sxs-lookup"><span data-stu-id="fddf0-202">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="fddf0-203">関連項目</span><span class="sxs-lookup"><span data-stu-id="fddf0-203">See also</span></span>

<a id="ID4E2CAC"></a>


##### <a name="parent"></a><span data-ttu-id="fddf0-204">Parent</span><span class="sxs-lookup"><span data-stu-id="fddf0-204">Parent</span></span>

[<span data-ttu-id="fddf0-205">/users/xuid({xuid})/scids/{scid}/stats</span><span class="sxs-lookup"><span data-stu-id="fddf0-205">/users/xuid({xuid})/scids/{scid}/stats</span></span>](uri-usersxuidscidsscidstats.md)
