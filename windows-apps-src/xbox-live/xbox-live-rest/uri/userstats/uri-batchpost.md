---
title: POST (/batch)
assetID: f5997c8e-82c7-0fba-9991-ce1116db4830
permalink: en-us/docs/xboxlive/rest/uri-batchpost.html
author: KevinAsgari
description: " POST (/batch)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: db832032a40b40d4b3a774a56487f7065d9cd8ff
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4014723"
---
# <a name="post-batch"></a><span data-ttu-id="58fcc-104">POST (/batch)</span><span class="sxs-lookup"><span data-stu-id="58fcc-104">POST (/batch)</span></span>
<span data-ttu-id="58fcc-105">POST メソッドは複数のタイトルに複数のプレイヤーの統計情報の複雑なバッチ要求の GET メソッドとして機能します。</span><span class="sxs-lookup"><span data-stu-id="58fcc-105">POST method that functions as a GET method for complex batch requests for multiple player statistics across multiple titles.</span></span> <span data-ttu-id="58fcc-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="58fcc-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>
 
<a id="ID4ET"></a>

 
## <a name="remarks"></a><span data-ttu-id="58fcc-107">注釈</span><span class="sxs-lookup"><span data-stu-id="58fcc-107">Remarks</span></span>
 
<span data-ttu-id="58fcc-108">タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付き統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="58fcc-108">Title developers can mark statistics as open or restricted with XDP or Dev Center.</span></span> <span data-ttu-id="58fcc-109">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="58fcc-109">Leaderboards are open statistics.</span></span> <span data-ttu-id="58fcc-110">開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="58fcc-110">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="58fcc-111">サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="58fcc-111">User authorization to a sandbox is managed through XDP or Dev Center.</span></span>
  
  * [<span data-ttu-id="58fcc-112">注釈</span><span class="sxs-lookup"><span data-stu-id="58fcc-112">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="58fcc-113">注釈</span><span class="sxs-lookup"><span data-stu-id="58fcc-113">Remarks</span></span>](#ID4EFB)
  * [<span data-ttu-id="58fcc-114">Authorization</span><span class="sxs-lookup"><span data-stu-id="58fcc-114">Authorization</span></span>](#ID4EUB)
  * [<span data-ttu-id="58fcc-115">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="58fcc-115">Required Request Headers</span></span>](#ID4ETC)
  * [<span data-ttu-id="58fcc-116">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="58fcc-116">Optional Request Headers</span></span>](#ID4E3D)
  * [<span data-ttu-id="58fcc-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="58fcc-117">Request body</span></span>](#ID4EAF)
  * [<span data-ttu-id="58fcc-118">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="58fcc-118">HTTP status codes</span></span>](#ID4EWF)
  * [<span data-ttu-id="58fcc-119">応答本文</span><span class="sxs-lookup"><span data-stu-id="58fcc-119">Response body</span></span>](#ID4ENBAC)
 
<a id="ID4EFB"></a>

 
## <a name="remarks"></a><span data-ttu-id="58fcc-120">注釈</span><span class="sxs-lookup"><span data-stu-id="58fcc-120">Remarks</span></span>
 
<span data-ttu-id="58fcc-121">呼び出し元では、ユーザー、サービス構成 Id (Scid)、およびそれらの統計情報を取得するための Scid ごとの統計情報名の一覧の配列でメッセージの本文が提供されます。</span><span class="sxs-lookup"><span data-stu-id="58fcc-121">The caller provides a message body with an array of users, service configuration IDs (SCIDs) and a list of statistic names per SCIDs for which to retrieve those statistics.</span></span>
 
<span data-ttu-id="58fcc-122">詳しくは、見つけることがある前に[GET](uri-usersxuidscidsscidstatsget.md)メソッド読み取りより複雑なこのバッチ モード ページ、シンプルな単一統計情報を確認すると便利です。</span><span class="sxs-lookup"><span data-stu-id="58fcc-122">You may find it more useful to review the simple, single-statistic [GET](uri-usersxuidscidsscidstatsget.md) method before you read this more complex, batch-mode page.</span></span>
  
<a id="ID4EUB"></a>

 
## <a name="authorization"></a><span data-ttu-id="58fcc-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="58fcc-123">Authorization</span></span>
 
<span data-ttu-id="58fcc-124">承認ロジック コンテンツ分離とアクセス制御のシナリオの実装があります。</span><span class="sxs-lookup"><span data-stu-id="58fcc-124">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>
 
   * <span data-ttu-id="58fcc-125">ランキング、およびユーザーの両方の統計情報は、呼び出し元が有効な XSTS トークンの要求で送信するに任意のプラットフォーム上のクライアントから読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="58fcc-125">Both leaderboards and user statistics can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="58fcc-126">書き込みはでサポートされているクライアントに明らかに制限します。</span><span class="sxs-lookup"><span data-stu-id="58fcc-126">Writes are obviously limited to clients supported by the .</span></span>
   * <span data-ttu-id="58fcc-127">タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付き統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="58fcc-127">Title developers can mark statistics as open or restricted with XDP or Dev Center.</span></span> <span data-ttu-id="58fcc-128">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="58fcc-128">Leaderboards are open statistics.</span></span> <span data-ttu-id="58fcc-129">開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="58fcc-129">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="58fcc-130">サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="58fcc-130">User authorization to a sandbox is managed through XDP or Dev Center.</span></span>
  
<span data-ttu-id="58fcc-131">次の例では、チェックの擬似コードを示します。</span><span class="sxs-lookup"><span data-stu-id="58fcc-131">The following example is pseudo-code for the check:</span></span>
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4ETC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="58fcc-132">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="58fcc-132">Required Request Headers</span></span>
 
| <span data-ttu-id="58fcc-133">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="58fcc-133">Header</span></span>| <span data-ttu-id="58fcc-134">型</span><span class="sxs-lookup"><span data-stu-id="58fcc-134">Type</span></span>| <span data-ttu-id="58fcc-135">説明</span><span class="sxs-lookup"><span data-stu-id="58fcc-135">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="58fcc-136">Authorization</span><span class="sxs-lookup"><span data-stu-id="58fcc-136">Authorization</span></span>| <span data-ttu-id="58fcc-137">string</span><span class="sxs-lookup"><span data-stu-id="58fcc-137">string</span></span>| <span data-ttu-id="58fcc-138">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="58fcc-138">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="58fcc-139">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。</span><span class="sxs-lookup"><span data-stu-id="58fcc-139">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
  
<a id="ID4E3D"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="58fcc-140">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="58fcc-140">Optional Request Headers</span></span>
 
| <span data-ttu-id="58fcc-141">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="58fcc-141">Header</span></span>| <span data-ttu-id="58fcc-142">型</span><span class="sxs-lookup"><span data-stu-id="58fcc-142">Type</span></span>| <span data-ttu-id="58fcc-143">説明</span><span class="sxs-lookup"><span data-stu-id="58fcc-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="58fcc-144">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="58fcc-144">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="58fcc-145">この要求を送信する必要があります、サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="58fcc-145">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="58fcc-146">要求はのみにルーティングされ、サービスの認証トークン内の要求ヘッダーの有効性を確認した後です。</span><span class="sxs-lookup"><span data-stu-id="58fcc-146">The request will only be routed to that service after verifying the validity of the header, the claims in the authentication token, and so on.</span></span> <span data-ttu-id="58fcc-147">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="58fcc-147">Default value: 1.</span></span>| 
  
<a id="ID4EAF"></a>

 
## <a name="request-body"></a><span data-ttu-id="58fcc-148">要求本文</span><span class="sxs-lookup"><span data-stu-id="58fcc-148">Request body</span></span>
 
<a id="ID4EIF"></a>

 
### <a name="sample-request"></a><span data-ttu-id="58fcc-149">要求の例</span><span class="sxs-lookup"><span data-stu-id="58fcc-149">Sample request</span></span>
 
<span data-ttu-id="58fcc-150">次の投稿の本文には、2 つの異なるユーザーに対する 2 つの異なる Scid から 4 つの統計情報が要求されているサービスが通知されます。</span><span class="sxs-lookup"><span data-stu-id="58fcc-150">the following POST body informs the service that four statistics are being requested from two different SCIDs for two different users.</span></span>
 

```cpp
{    
"requestedusers": [
                1234567890123460,
                1234567890123234
            ],
            "requestedscids": [
                {
                    "scid": "c402ff50-3e76-11e2-a25f-0800200c1212",
                    "requestedstats": [
                        "Test4FirefightKills",
                        "Test4FirefightHeadshots"
                    ]
                },
                {
                    "scid": "c402ff50-3e76-11e2-a25f-0800200c0343",
                    "requestedstats": [
                        "OverallTestKills",
                        "TestHeadshots"
                    ]
                }
            ] 
}
      
```

   
<a id="ID4EWF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="58fcc-151">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="58fcc-151">HTTP status codes</span></span>
 
<span data-ttu-id="58fcc-152">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="58fcc-152">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="58fcc-153">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="58fcc-153">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="58fcc-154">コード</span><span class="sxs-lookup"><span data-stu-id="58fcc-154">Code</span></span>| <span data-ttu-id="58fcc-155">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="58fcc-155">Reason phrase</span></span>| <span data-ttu-id="58fcc-156">説明</span><span class="sxs-lookup"><span data-stu-id="58fcc-156">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="58fcc-157">200</span><span class="sxs-lookup"><span data-stu-id="58fcc-157">200</span></span>| <span data-ttu-id="58fcc-158">OK</span><span class="sxs-lookup"><span data-stu-id="58fcc-158">OK</span></span>| <span data-ttu-id="58fcc-159">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="58fcc-159">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="58fcc-160">304</span><span class="sxs-lookup"><span data-stu-id="58fcc-160">304</span></span>| <span data-ttu-id="58fcc-161">Not Modified</span><span class="sxs-lookup"><span data-stu-id="58fcc-161">Not Modified</span></span>| <span data-ttu-id="58fcc-162">リソースされていない以降に変更するように要求します。</span><span class="sxs-lookup"><span data-stu-id="58fcc-162">Resource not been modified since last requested.</span></span>| 
| <span data-ttu-id="58fcc-163">400</span><span class="sxs-lookup"><span data-stu-id="58fcc-163">400</span></span>| <span data-ttu-id="58fcc-164">Bad Request</span><span class="sxs-lookup"><span data-stu-id="58fcc-164">Bad Request</span></span>| <span data-ttu-id="58fcc-165">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="58fcc-165">Service could not understand malformed request.</span></span> <span data-ttu-id="58fcc-166">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="58fcc-166">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="58fcc-167">401</span><span class="sxs-lookup"><span data-stu-id="58fcc-167">401</span></span>| <span data-ttu-id="58fcc-168">権限がありません</span><span class="sxs-lookup"><span data-stu-id="58fcc-168">Unauthorized</span></span>| <span data-ttu-id="58fcc-169">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="58fcc-169">The request requires user authentication.</span></span>| 
| <span data-ttu-id="58fcc-170">403</span><span class="sxs-lookup"><span data-stu-id="58fcc-170">403</span></span>| <span data-ttu-id="58fcc-171">Forbidden</span><span class="sxs-lookup"><span data-stu-id="58fcc-171">Forbidden</span></span>| <span data-ttu-id="58fcc-172">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="58fcc-172">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="58fcc-173">404</span><span class="sxs-lookup"><span data-stu-id="58fcc-173">404</span></span>| <span data-ttu-id="58fcc-174">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="58fcc-174">Not Found</span></span>| <span data-ttu-id="58fcc-175">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="58fcc-175">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="58fcc-176">406</span><span class="sxs-lookup"><span data-stu-id="58fcc-176">406</span></span>| <span data-ttu-id="58fcc-177">許容できません。</span><span class="sxs-lookup"><span data-stu-id="58fcc-177">Not Acceptable</span></span>| <span data-ttu-id="58fcc-178">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="58fcc-178">Resource version is not supported.</span></span>| 
| <span data-ttu-id="58fcc-179">408</span><span class="sxs-lookup"><span data-stu-id="58fcc-179">408</span></span>| <span data-ttu-id="58fcc-180">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="58fcc-180">Request Timeout</span></span>| <span data-ttu-id="58fcc-181">リソースのバージョンがサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="58fcc-181">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
  
<a id="ID4ENBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="58fcc-182">応答本文</span><span class="sxs-lookup"><span data-stu-id="58fcc-182">Response body</span></span>
 
<a id="ID4EXBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="58fcc-183">応答の例</span><span class="sxs-lookup"><span data-stu-id="58fcc-183">Sample response</span></span>
 

```cpp
{    
   "users":[          
       {    
      "xuid": "123456789"
        "gamertag": "WarriorSaint",
        "scids":[
          {
             "scid":"c402ff50-3e76-11e2-a25f-0800200c1212",
             "stats":  [
          {
                 "statname":"Test4FirefightKills",
                 "type":"Integer",
                 "value":7
             },
          {
                 "statname":"Test4FirefightHeadshots",
                 "type":"Integer",
                 "value":4
             }]
                        },
          {
             "scid":"c402ff50-3e76-11e2-a25f-0800200c0343",
             "stats":  [
          {
                 "statname":"OverallTestKills",
                 "type":"Integer",
                 "value":3434
             },
          {
                 "statname":"TestHeadshots",
                 "type":"Integer",
                 "value":41
             }]
          }],
                   },
    {    
                   "gamertag":"TigerShark",
                   "xuid":1234567890123234
        "scids":[
          {
             "scid":"123456789",
             "stats":  [
          {
                 "statname":"Test4FirefightKills",
                 "type":"Integer",
                 "value":63
             },
          {
                 "statname":"Test4FirefightHeadshots",
                 "type":"Integer",
                 "value":12
             }]
                        },
          {
"scid":"987654321",
             "stats":  [
          {
                 "statname":"OverallTestKills",
                 "type":"Integer",
                 "value":375
             },
          {
                 "statname":"TestHeadshots",
                 "type":"Integer",
                 "value":34
             }]
          }],
                   }]
}
         
```

   
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="58fcc-184">関連項目</span><span class="sxs-lookup"><span data-stu-id="58fcc-184">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="58fcc-185">Parent</span><span class="sxs-lookup"><span data-stu-id="58fcc-185">Parent</span></span> 

[<span data-ttu-id="58fcc-186">/batch</span><span class="sxs-lookup"><span data-stu-id="58fcc-186">/batch</span></span>](uri-batch.md)

   