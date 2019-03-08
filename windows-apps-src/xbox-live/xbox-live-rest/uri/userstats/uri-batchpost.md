---
title: POST (/batch)
assetID: f5997c8e-82c7-0fba-9991-ce1116db4830
permalink: en-us/docs/xboxlive/rest/uri-batchpost.html
description: " POST (/batch)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a854fc830c87afbf675a379599916bf3db919539
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645837"
---
# <a name="post-batch"></a><span data-ttu-id="48ac7-104">POST (/batch)</span><span class="sxs-lookup"><span data-stu-id="48ac7-104">POST (/batch)</span></span>
<span data-ttu-id="48ac7-105">複数のタイトル、プレーヤーの統計情報を複数の複雑なバッチ要求の GET メソッドとして機能するメソッドを投稿します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-105">POST method that functions as a GET method for complex batch requests for multiple player statistics across multiple titles.</span></span> <span data-ttu-id="48ac7-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>
 
<a id="ID4ET"></a>

 
## <a name="remarks"></a><span data-ttu-id="48ac7-107">注釈</span><span class="sxs-lookup"><span data-stu-id="48ac7-107">Remarks</span></span>
 
<span data-ttu-id="48ac7-108">タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="48ac7-108">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="48ac7-109">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="48ac7-109">Leaderboards are open statistics.</span></span> <span data-ttu-id="48ac7-110">統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="48ac7-110">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="48ac7-111">サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="48ac7-111">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>
  
  * [<span data-ttu-id="48ac7-112">注釈</span><span class="sxs-lookup"><span data-stu-id="48ac7-112">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="48ac7-113">注釈</span><span class="sxs-lookup"><span data-stu-id="48ac7-113">Remarks</span></span>](#ID4EFB)
  * [<span data-ttu-id="48ac7-114">承認</span><span class="sxs-lookup"><span data-stu-id="48ac7-114">Authorization</span></span>](#ID4EUB)
  * [<span data-ttu-id="48ac7-115">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="48ac7-115">Required Request Headers</span></span>](#ID4ETC)
  * [<span data-ttu-id="48ac7-116">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="48ac7-116">Optional Request Headers</span></span>](#ID4E3D)
  * [<span data-ttu-id="48ac7-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="48ac7-117">Request body</span></span>](#ID4EAF)
  * [<span data-ttu-id="48ac7-118">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="48ac7-118">HTTP status codes</span></span>](#ID4EWF)
  * [<span data-ttu-id="48ac7-119">応答本文</span><span class="sxs-lookup"><span data-stu-id="48ac7-119">Response body</span></span>](#ID4ENBAC)
 
<a id="ID4EFB"></a>

 
## <a name="remarks"></a><span data-ttu-id="48ac7-120">注釈</span><span class="sxs-lookup"><span data-stu-id="48ac7-120">Remarks</span></span>
 
<span data-ttu-id="48ac7-121">呼び出し元は、ユーザー、サービスの構成 Id (SCIDs) およびこれらの統計情報を取得する対象の SCIDs ごとの統計名の一覧の配列で、メッセージ本文を提供します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-121">The caller provides a message body with an array of users, service configuration IDs (SCIDs) and a list of statistic names per SCIDs for which to retrieve those statistics.</span></span>
 
<span data-ttu-id="48ac7-122">単純な 1 つ統計情報を確認するのには役に立つ場合があります[取得](uri-usersxuidscidsscidstatsget.md)メソッドのこの複雑ですが、バッチ モードのページを読む前にします。</span><span class="sxs-lookup"><span data-stu-id="48ac7-122">You may find it more useful to review the simple, single-statistic [GET](uri-usersxuidscidsscidstatsget.md) method before you read this more complex, batch-mode page.</span></span>
  
<a id="ID4EUB"></a>

 
## <a name="authorization"></a><span data-ttu-id="48ac7-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="48ac7-123">Authorization</span></span>
 
<span data-ttu-id="48ac7-124">コンテンツの分離とアクセス制御のシナリオで実装された承認ロジックがあります。</span><span class="sxs-lookup"><span data-stu-id="48ac7-124">There is authorization logic implemented for content-isolation and access-control scenarios.</span></span>
 
   * <span data-ttu-id="48ac7-125">呼び出し元の要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングおよびユーザーの両方の統計情報を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="48ac7-125">Both leaderboards and user statistics can be read from clients on any platform, provided that the caller submits a valid XSTS token with the request.</span></span> <span data-ttu-id="48ac7-126">サポートされているクライアントに明らかに制限されています。 書き込みは、します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-126">Writes are obviously limited to clients supported by the .</span></span>
   * <span data-ttu-id="48ac7-127">タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。</span><span class="sxs-lookup"><span data-stu-id="48ac7-127">Title developers can mark statistics as open or restricted with XDP or Partner Center.</span></span> <span data-ttu-id="48ac7-128">ランキングは、統計を開くです。</span><span class="sxs-lookup"><span data-stu-id="48ac7-128">Leaderboards are open statistics.</span></span> <span data-ttu-id="48ac7-129">統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="48ac7-129">Open statistics can be accessed by Smartglass, as well as iOS, Android, Windows, Windows Phone, and web applications, as long as the user is authorized to the sandbox.</span></span> <span data-ttu-id="48ac7-130">サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。</span><span class="sxs-lookup"><span data-stu-id="48ac7-130">User authorization to a sandbox is managed through XDP or Partner Center.</span></span>
  
<span data-ttu-id="48ac7-131">次の例は、チェックの擬似コードに示します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-131">The following example is pseudo-code for the check:</span></span>
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4ETC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="48ac7-132">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="48ac7-132">Required Request Headers</span></span>
 
| <span data-ttu-id="48ac7-133">Header</span><span class="sxs-lookup"><span data-stu-id="48ac7-133">Header</span></span>| <span data-ttu-id="48ac7-134">種類</span><span class="sxs-lookup"><span data-stu-id="48ac7-134">Type</span></span>| <span data-ttu-id="48ac7-135">説明</span><span class="sxs-lookup"><span data-stu-id="48ac7-135">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="48ac7-136">Authorization</span><span class="sxs-lookup"><span data-stu-id="48ac7-136">Authorization</span></span>| <span data-ttu-id="48ac7-137">string</span><span class="sxs-lookup"><span data-stu-id="48ac7-137">string</span></span>| <span data-ttu-id="48ac7-138">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-138">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="48ac7-139">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="48ac7-139">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
  
<a id="ID4E3D"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="48ac7-140">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="48ac7-140">Optional Request Headers</span></span>
 
| <span data-ttu-id="48ac7-141">Header</span><span class="sxs-lookup"><span data-stu-id="48ac7-141">Header</span></span>| <span data-ttu-id="48ac7-142">種類</span><span class="sxs-lookup"><span data-stu-id="48ac7-142">Type</span></span>| <span data-ttu-id="48ac7-143">説明</span><span class="sxs-lookup"><span data-stu-id="48ac7-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="48ac7-144">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="48ac7-144">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="48ac7-145">この要求が送られるサービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="48ac7-145">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="48ac7-146">要求はのみにルーティング サービスの認証トークンの要求ヘッダーの有効性を確認した後と。</span><span class="sxs-lookup"><span data-stu-id="48ac7-146">The request will only be routed to that service after verifying the validity of the header, the claims in the authentication token, and so on.</span></span> <span data-ttu-id="48ac7-147">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="48ac7-147">Default value: 1.</span></span>| 
  
<a id="ID4EAF"></a>

 
## <a name="request-body"></a><span data-ttu-id="48ac7-148">要求本文</span><span class="sxs-lookup"><span data-stu-id="48ac7-148">Request body</span></span>
 
<a id="ID4EIF"></a>

 
### <a name="sample-request"></a><span data-ttu-id="48ac7-149">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="48ac7-149">Sample request</span></span>
 
<span data-ttu-id="48ac7-150">次の POST の本文は、2 人のユーザーの 2 つの異なる SCIDs から 4 つの統計情報が要求されていることをサービスに通知します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-150">the following POST body informs the service that four statistics are being requested from two different SCIDs for two different users.</span></span>
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="48ac7-151">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="48ac7-151">HTTP status codes</span></span>
 
<span data-ttu-id="48ac7-152">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-152">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="48ac7-153">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-153">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="48ac7-154">コード</span><span class="sxs-lookup"><span data-stu-id="48ac7-154">Code</span></span>| <span data-ttu-id="48ac7-155">理由語句</span><span class="sxs-lookup"><span data-stu-id="48ac7-155">Reason phrase</span></span>| <span data-ttu-id="48ac7-156">説明</span><span class="sxs-lookup"><span data-stu-id="48ac7-156">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="48ac7-157">200</span><span class="sxs-lookup"><span data-stu-id="48ac7-157">200</span></span>| <span data-ttu-id="48ac7-158">OK</span><span class="sxs-lookup"><span data-stu-id="48ac7-158">OK</span></span>| <span data-ttu-id="48ac7-159">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-159">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="48ac7-160">304</span><span class="sxs-lookup"><span data-stu-id="48ac7-160">304</span></span>| <span data-ttu-id="48ac7-161">変更されていません</span><span class="sxs-lookup"><span data-stu-id="48ac7-161">Not Modified</span></span>| <span data-ttu-id="48ac7-162">リソースされていない最後の要求以降に変更します。</span><span class="sxs-lookup"><span data-stu-id="48ac7-162">Resource not been modified since last requested.</span></span>| 
| <span data-ttu-id="48ac7-163">400</span><span class="sxs-lookup"><span data-stu-id="48ac7-163">400</span></span>| <span data-ttu-id="48ac7-164">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="48ac7-164">Bad Request</span></span>| <span data-ttu-id="48ac7-165">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="48ac7-165">Service could not understand malformed request.</span></span> <span data-ttu-id="48ac7-166">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="48ac7-166">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="48ac7-167">401</span><span class="sxs-lookup"><span data-stu-id="48ac7-167">401</span></span>| <span data-ttu-id="48ac7-168">権限がありません</span><span class="sxs-lookup"><span data-stu-id="48ac7-168">Unauthorized</span></span>| <span data-ttu-id="48ac7-169">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="48ac7-169">The request requires user authentication.</span></span>| 
| <span data-ttu-id="48ac7-170">403</span><span class="sxs-lookup"><span data-stu-id="48ac7-170">403</span></span>| <span data-ttu-id="48ac7-171">Forbidden</span><span class="sxs-lookup"><span data-stu-id="48ac7-171">Forbidden</span></span>| <span data-ttu-id="48ac7-172">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="48ac7-172">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="48ac7-173">404</span><span class="sxs-lookup"><span data-stu-id="48ac7-173">404</span></span>| <span data-ttu-id="48ac7-174">検出不可</span><span class="sxs-lookup"><span data-stu-id="48ac7-174">Not Found</span></span>| <span data-ttu-id="48ac7-175">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="48ac7-175">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="48ac7-176">406</span><span class="sxs-lookup"><span data-stu-id="48ac7-176">406</span></span>| <span data-ttu-id="48ac7-177">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="48ac7-177">Not Acceptable</span></span>| <span data-ttu-id="48ac7-178">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="48ac7-178">Resource version is not supported.</span></span>| 
| <span data-ttu-id="48ac7-179">408</span><span class="sxs-lookup"><span data-stu-id="48ac7-179">408</span></span>| <span data-ttu-id="48ac7-180">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="48ac7-180">Request Timeout</span></span>| <span data-ttu-id="48ac7-181">リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。</span><span class="sxs-lookup"><span data-stu-id="48ac7-181">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
  
<a id="ID4ENBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="48ac7-182">応答本文</span><span class="sxs-lookup"><span data-stu-id="48ac7-182">Response body</span></span>
 
<a id="ID4EXBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="48ac7-183">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="48ac7-183">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="48ac7-184">関連項目</span><span class="sxs-lookup"><span data-stu-id="48ac7-184">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="48ac7-185">Parent</span><span class="sxs-lookup"><span data-stu-id="48ac7-185">Parent</span></span> 

[<span data-ttu-id="48ac7-186">/batch</span><span class="sxs-lookup"><span data-stu-id="48ac7-186">/batch</span></span>](uri-batch.md)

   