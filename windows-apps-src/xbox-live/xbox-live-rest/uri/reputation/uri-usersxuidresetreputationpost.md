---
title: POST (/users/xuid({xuid})/resetreputation)
assetID: 3b76857f-b043-2c76-cf0c-c8f355fe3849
permalink: en-us/docs/xboxlive/rest/uri-usersxuidresetreputationpost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/resetreputation)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5b39060c84742f1b37087b17ebc33b021b2c5eb7
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5869857"
---
# <a name="post-usersxuidxuidresetreputation"></a><span data-ttu-id="960cc-104">POST (/users/xuid({xuid})/resetreputation)</span><span class="sxs-lookup"><span data-stu-id="960cc-104">POST (/users/xuid({xuid})/resetreputation)</span></span>
<span data-ttu-id="960cc-105">により、実施チームは、アカウント ハイジャック (たとえば) したら、任意の値をいくつかを指定したユーザーの評判スコアを設定します。</span><span class="sxs-lookup"><span data-stu-id="960cc-105">Enables the Enforcement team to set the specified user's Reputation Scores to some arbitrary values after (for example) an account hijacking.</span></span> <span data-ttu-id="960cc-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="960cc-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="960cc-107">注釈</span><span class="sxs-lookup"><span data-stu-id="960cc-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="960cc-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="960cc-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="960cc-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="960cc-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="960cc-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="960cc-110">Required Request Headers</span></span>](#ID4E5B)
  * [<span data-ttu-id="960cc-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="960cc-111">Request body</span></span>](#ID4EYD)
  * [<span data-ttu-id="960cc-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="960cc-112">HTTP status codes</span></span>](#ID4EOE)
  * [<span data-ttu-id="960cc-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="960cc-113">Response body</span></span>](#ID4EQH)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="960cc-114">注釈</span><span class="sxs-lookup"><span data-stu-id="960cc-114">Remarks</span></span>
 
<span data-ttu-id="960cc-115">このメソッドは、Retail を除くすべてのサンド ボックスの他のすべてのパートナーとテストのために、Retail を除くすべてのサンド ボックス内のユーザーによっても呼び出すことがあります。</span><span class="sxs-lookup"><span data-stu-id="960cc-115">This method may also be called by any other Partners for all sandboxes except Retail, and by users in all sandboxes except Retail, for testing purposes.</span></span> <span data-ttu-id="960cc-116">この要求は、「基本」評判スコアをユーザーに設定し、肯定的なフィードバック良い評価の彼は重みをすべて消去アウトことに注意してください。この呼び出しを行った後、ユーザーの実際の評判は、この基本スコアと自分のアンバサダー ボーナスと自分のフォロワー ボーナスになります。</span><span class="sxs-lookup"><span data-stu-id="960cc-116">Note that this request sets a user's "base" reputation scores, and his positive feedback weightings will all be zeroed out. The user's actual reputation after making this call will be these base scores plus his ambassador bonus plus his follower bonus.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="960cc-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="960cc-117">URI parameters</span></span>
 
| <span data-ttu-id="960cc-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="960cc-118">Parameter</span></span>| <span data-ttu-id="960cc-119">型</span><span class="sxs-lookup"><span data-stu-id="960cc-119">Type</span></span>| <span data-ttu-id="960cc-120">説明</span><span class="sxs-lookup"><span data-stu-id="960cc-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="960cc-121">xuid</span><span class="sxs-lookup"><span data-stu-id="960cc-121">xuid</span></span>| <span data-ttu-id="960cc-122">string</span><span class="sxs-lookup"><span data-stu-id="960cc-122">string</span></span>| <span data-ttu-id="960cc-123">Xbox ユーザー ID (XUID) 指定したユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="960cc-123">The Xbox User ID (XUID) of the specified user.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="960cc-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="960cc-124">Authorization</span></span>
 
<span data-ttu-id="960cc-125">パートナーから: **PartnerClaim**実施チームから、市販のサンド ボックスすべての他のサンド ボックスに対して、 **PartnerClaim**します。</span><span class="sxs-lookup"><span data-stu-id="960cc-125">From partner: For the Retail sandbox, **PartnerClaim** from the Enforcement team; for all other sandboxes, **PartnerClaim**.</span></span>
 
<span data-ttu-id="960cc-126">ユーザーから: 製品版、 **XuidClaim** **TitleClaim**を除くすべてのサンド ボックスにします。</span><span class="sxs-lookup"><span data-stu-id="960cc-126">From user: For all Sandboxes except Retail, **XuidClaim** and **TitleClaim**.</span></span>
  
<a id="ID4E5B"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="960cc-127">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="960cc-127">Required Request Headers</span></span>
 
<span data-ttu-id="960cc-128">すべてから:**コンテンツの種類: アプリケーション/json**します。</span><span class="sxs-lookup"><span data-stu-id="960cc-128">From all: **Content-Type: application/json**.</span></span>
 
<span data-ttu-id="960cc-129">パートナーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)、 **X の Xbl のサンド ボックス**です。</span><span class="sxs-lookup"><span data-stu-id="960cc-129">From partner: **X-Xbl-Contract-Version** (current version is 101), **X-Xbl-Sandbox**.</span></span>
 
<span data-ttu-id="960cc-130">ユーザーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)。</span><span class="sxs-lookup"><span data-stu-id="960cc-130">From user: **X-Xbl-Contract-Version** (current version is 101).</span></span>
 
| <span data-ttu-id="960cc-131">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="960cc-131">Header</span></span>| <span data-ttu-id="960cc-132">型</span><span class="sxs-lookup"><span data-stu-id="960cc-132">Type</span></span>| <span data-ttu-id="960cc-133">説明</span><span class="sxs-lookup"><span data-stu-id="960cc-133">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="960cc-134">Authorization</span><span class="sxs-lookup"><span data-stu-id="960cc-134">Authorization</span></span>| <span data-ttu-id="960cc-135">string</span><span class="sxs-lookup"><span data-stu-id="960cc-135">string</span></span>| <span data-ttu-id="960cc-136">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="960cc-136">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="960cc-137">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"します。</span><span class="sxs-lookup"><span data-stu-id="960cc-137">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="960cc-138">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="960cc-138">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="960cc-139">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="960cc-139">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="960cc-140">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="960cc-140">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="960cc-141">既定値: 101 します。</span><span class="sxs-lookup"><span data-stu-id="960cc-141">Default value: 101.</span></span>| 
  
<a id="ID4EYD"></a>

 
## <a name="request-body"></a><span data-ttu-id="960cc-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="960cc-142">Request body</span></span>
 
<a id="ID4E5D"></a>

 
### <a name="sample-request"></a><span data-ttu-id="960cc-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="960cc-143">Sample request</span></span>
 
<span data-ttu-id="960cc-144">要求本文は、単純な[ResetReputation (JSON)](../../json/json-resetreputation.md)ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="960cc-144">The request body is a simple [ResetReputation (JSON)](../../json/json-resetreputation.md) document.</span></span>
 

```cpp
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
      
```

   
<a id="ID4EOE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="960cc-145">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="960cc-145">HTTP status codes</span></span>
 
<span data-ttu-id="960cc-146">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="960cc-146">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="960cc-147">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="960cc-147">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="960cc-148">コード</span><span class="sxs-lookup"><span data-stu-id="960cc-148">Code</span></span>| <span data-ttu-id="960cc-149">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="960cc-149">Reason phrase</span></span>| <span data-ttu-id="960cc-150">説明</span><span class="sxs-lookup"><span data-stu-id="960cc-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="960cc-151">200</span><span class="sxs-lookup"><span data-stu-id="960cc-151">200</span></span>| <span data-ttu-id="960cc-152">OK</span><span class="sxs-lookup"><span data-stu-id="960cc-152">OK</span></span>| <span data-ttu-id="960cc-153">OK。</span><span class="sxs-lookup"><span data-stu-id="960cc-153">OK.</span></span>| 
| <span data-ttu-id="960cc-154">400</span><span class="sxs-lookup"><span data-stu-id="960cc-154">400</span></span>| <span data-ttu-id="960cc-155">Bad Request</span><span class="sxs-lookup"><span data-stu-id="960cc-155">Bad Request</span></span>| <span data-ttu-id="960cc-156">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="960cc-156">Service could not understand malformed request.</span></span> <span data-ttu-id="960cc-157">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="960cc-157">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="960cc-158">401</span><span class="sxs-lookup"><span data-stu-id="960cc-158">401</span></span>| <span data-ttu-id="960cc-159">権限がありません</span><span class="sxs-lookup"><span data-stu-id="960cc-159">Unauthorized</span></span>| <span data-ttu-id="960cc-160">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="960cc-160">The request requires user authentication.</span></span>| 
| <span data-ttu-id="960cc-161">404</span><span class="sxs-lookup"><span data-stu-id="960cc-161">404</span></span>| <span data-ttu-id="960cc-162">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="960cc-162">Not Found</span></span>| <span data-ttu-id="960cc-163">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="960cc-163">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="960cc-164">500</span><span class="sxs-lookup"><span data-stu-id="960cc-164">500</span></span>| <span data-ttu-id="960cc-165">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="960cc-165">Internal Server Error</span></span>| <span data-ttu-id="960cc-166">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="960cc-166">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="960cc-167">503</span><span class="sxs-lookup"><span data-stu-id="960cc-167">503</span></span>| <span data-ttu-id="960cc-168">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="960cc-168">Service Unavailable</span></span>| <span data-ttu-id="960cc-169">要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="960cc-169">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EQH"></a>

 
## <a name="response-body"></a><span data-ttu-id="960cc-170">応答本文</span><span class="sxs-lookup"><span data-stu-id="960cc-170">Response body</span></span>
 
<span data-ttu-id="960cc-171">成功した場合、応答本文は空です。</span><span class="sxs-lookup"><span data-stu-id="960cc-171">On success, the response body is empty.</span></span> <span data-ttu-id="960cc-172">失敗した場合、 [ServiceError (JSON)](../../json/json-serviceerror.md)ドキュメントが返されます。</span><span class="sxs-lookup"><span data-stu-id="960cc-172">On failure, a [ServiceError (JSON)](../../json/json-serviceerror.md) document is returned.</span></span>
 
<a id="ID4E3H"></a>

 
### <a name="sample-response"></a><span data-ttu-id="960cc-173">応答の例</span><span class="sxs-lookup"><span data-stu-id="960cc-173">Sample response</span></span>
 

```cpp
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
         
```

   
<a id="ID4EHAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="960cc-174">関連項目</span><span class="sxs-lookup"><span data-stu-id="960cc-174">See also</span></span>
 
<a id="ID4EJAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="960cc-175">Parent</span><span class="sxs-lookup"><span data-stu-id="960cc-175">Parent</span></span> 

[<span data-ttu-id="960cc-176">/users/xuid({xuid})/resetreputation</span><span class="sxs-lookup"><span data-stu-id="960cc-176">/users/xuid({xuid})/resetreputation</span></span>](uri-usersxuidresetreputation.md)

   