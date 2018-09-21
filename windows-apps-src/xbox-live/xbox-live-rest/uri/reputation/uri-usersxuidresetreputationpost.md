---
title: POST (/users/xuid({xuid})/resetreputation)
assetID: 3b76857f-b043-2c76-cf0c-c8f355fe3849
permalink: en-us/docs/xboxlive/rest/uri-usersxuidresetreputationpost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/resetreputation)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5fefcfd0f49449095b08a1463931513440bc69c1
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4086166"
---
# <a name="post-usersxuidxuidresetreputation"></a><span data-ttu-id="acbba-104">POST (/users/xuid({xuid})/resetreputation)</span><span class="sxs-lookup"><span data-stu-id="acbba-104">POST (/users/xuid({xuid})/resetreputation)</span></span>
<span data-ttu-id="acbba-105">により、実施チームは、アカウント ハイジャック (たとえば) したら、任意の値をいくつかを指定したユーザーの評判スコアを設定します。</span><span class="sxs-lookup"><span data-stu-id="acbba-105">Enables the Enforcement team to set the specified user's Reputation Scores to some arbitrary values after (for example) an account hijacking.</span></span> <span data-ttu-id="acbba-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="acbba-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="acbba-107">注釈</span><span class="sxs-lookup"><span data-stu-id="acbba-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="acbba-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="acbba-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="acbba-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="acbba-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="acbba-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="acbba-110">Required Request Headers</span></span>](#ID4E5B)
  * [<span data-ttu-id="acbba-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="acbba-111">Request body</span></span>](#ID4EYD)
  * [<span data-ttu-id="acbba-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="acbba-112">HTTP status codes</span></span>](#ID4EOE)
  * [<span data-ttu-id="acbba-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="acbba-113">Response body</span></span>](#ID4EQH)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="acbba-114">注釈</span><span class="sxs-lookup"><span data-stu-id="acbba-114">Remarks</span></span>
 
<span data-ttu-id="acbba-115">テストのために、Retail を除くすべてのサンド ボックス内のユーザーと Retail を除くすべてのサンド ボックスの他のパートナー様により、このメソッドを呼び出すも可能性があります。</span><span class="sxs-lookup"><span data-stu-id="acbba-115">This method may also be called by any other Partners for all sandboxes except Retail, and by users in all sandboxes except Retail, for testing purposes.</span></span> <span data-ttu-id="acbba-116">この要求は、「基本」評判スコアをユーザーに設定し、肯定的なフィードバック良い評価の彼は重みをすべて消去ことに注意してください。この呼び出しを行った後、ユーザーの実際の評判は、この基本スコアと自分のアンバサダー ボーナスと自分のフォロワー ボーナスになります。</span><span class="sxs-lookup"><span data-stu-id="acbba-116">Note that this request sets a user's "base" reputation scores, and his positive feedback weightings will all be zeroed out. The user's actual reputation after making this call will be these base scores plus his ambassador bonus plus his follower bonus.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="acbba-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="acbba-117">URI parameters</span></span>
 
| <span data-ttu-id="acbba-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="acbba-118">Parameter</span></span>| <span data-ttu-id="acbba-119">型</span><span class="sxs-lookup"><span data-stu-id="acbba-119">Type</span></span>| <span data-ttu-id="acbba-120">説明</span><span class="sxs-lookup"><span data-stu-id="acbba-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="acbba-121">xuid</span><span class="sxs-lookup"><span data-stu-id="acbba-121">xuid</span></span>| <span data-ttu-id="acbba-122">string</span><span class="sxs-lookup"><span data-stu-id="acbba-122">string</span></span>| <span data-ttu-id="acbba-123">Xbox ユーザー ID (XUID) の指定したユーザーです。</span><span class="sxs-lookup"><span data-stu-id="acbba-123">The Xbox User ID (XUID) of the specified user.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="acbba-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="acbba-124">Authorization</span></span>
 
<span data-ttu-id="acbba-125">パートナーから: **PartnerClaim**実施チームから、市販のサンド ボックスすべてのサンド ボックスに対して、 **PartnerClaim**します。</span><span class="sxs-lookup"><span data-stu-id="acbba-125">From partner: For the Retail sandbox, **PartnerClaim** from the Enforcement team; for all other sandboxes, **PartnerClaim**.</span></span>
 
<span data-ttu-id="acbba-126">ユーザーから: 製品版、 **XuidClaim** **TitleClaim**を除くすべてのサンド ボックスにします。</span><span class="sxs-lookup"><span data-stu-id="acbba-126">From user: For all Sandboxes except Retail, **XuidClaim** and **TitleClaim**.</span></span>
  
<a id="ID4E5B"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="acbba-127">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="acbba-127">Required Request Headers</span></span>
 
<span data-ttu-id="acbba-128">すべてから:**コンテンツの種類: アプリケーション/json**します。</span><span class="sxs-lookup"><span data-stu-id="acbba-128">From all: **Content-Type: application/json**.</span></span>
 
<span data-ttu-id="acbba-129">パートナーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)、 **X-Xbl-サンド ボックス**です。</span><span class="sxs-lookup"><span data-stu-id="acbba-129">From partner: **X-Xbl-Contract-Version** (current version is 101), **X-Xbl-Sandbox**.</span></span>
 
<span data-ttu-id="acbba-130">ユーザーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)。</span><span class="sxs-lookup"><span data-stu-id="acbba-130">From user: **X-Xbl-Contract-Version** (current version is 101).</span></span>
 
| <span data-ttu-id="acbba-131">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="acbba-131">Header</span></span>| <span data-ttu-id="acbba-132">型</span><span class="sxs-lookup"><span data-stu-id="acbba-132">Type</span></span>| <span data-ttu-id="acbba-133">説明</span><span class="sxs-lookup"><span data-stu-id="acbba-133">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="acbba-134">Authorization</span><span class="sxs-lookup"><span data-stu-id="acbba-134">Authorization</span></span>| <span data-ttu-id="acbba-135">string</span><span class="sxs-lookup"><span data-stu-id="acbba-135">string</span></span>| <span data-ttu-id="acbba-136">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="acbba-136">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="acbba-137">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。</span><span class="sxs-lookup"><span data-stu-id="acbba-137">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="acbba-138">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="acbba-138">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="acbba-139">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="acbba-139">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="acbba-140">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="acbba-140">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="acbba-141">既定値: 101 します。</span><span class="sxs-lookup"><span data-stu-id="acbba-141">Default value: 101.</span></span>| 
  
<a id="ID4EYD"></a>

 
## <a name="request-body"></a><span data-ttu-id="acbba-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="acbba-142">Request body</span></span>
 
<a id="ID4E5D"></a>

 
### <a name="sample-request"></a><span data-ttu-id="acbba-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="acbba-143">Sample request</span></span>
 
<span data-ttu-id="acbba-144">要求本文は、単純な[ResetReputation (JSON)](../../json/json-resetreputation.md)ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="acbba-144">The request body is a simple [ResetReputation (JSON)](../../json/json-resetreputation.md) document.</span></span>
 

```cpp
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
      
```

   
<a id="ID4EOE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="acbba-145">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="acbba-145">HTTP status codes</span></span>
 
<span data-ttu-id="acbba-146">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="acbba-146">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="acbba-147">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="acbba-147">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="acbba-148">コード</span><span class="sxs-lookup"><span data-stu-id="acbba-148">Code</span></span>| <span data-ttu-id="acbba-149">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="acbba-149">Reason phrase</span></span>| <span data-ttu-id="acbba-150">説明</span><span class="sxs-lookup"><span data-stu-id="acbba-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="acbba-151">200</span><span class="sxs-lookup"><span data-stu-id="acbba-151">200</span></span>| <span data-ttu-id="acbba-152">OK</span><span class="sxs-lookup"><span data-stu-id="acbba-152">OK</span></span>| <span data-ttu-id="acbba-153">OK。</span><span class="sxs-lookup"><span data-stu-id="acbba-153">OK.</span></span>| 
| <span data-ttu-id="acbba-154">400</span><span class="sxs-lookup"><span data-stu-id="acbba-154">400</span></span>| <span data-ttu-id="acbba-155">Bad Request</span><span class="sxs-lookup"><span data-stu-id="acbba-155">Bad Request</span></span>| <span data-ttu-id="acbba-156">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="acbba-156">Service could not understand malformed request.</span></span> <span data-ttu-id="acbba-157">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="acbba-157">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="acbba-158">401</span><span class="sxs-lookup"><span data-stu-id="acbba-158">401</span></span>| <span data-ttu-id="acbba-159">権限がありません</span><span class="sxs-lookup"><span data-stu-id="acbba-159">Unauthorized</span></span>| <span data-ttu-id="acbba-160">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="acbba-160">The request requires user authentication.</span></span>| 
| <span data-ttu-id="acbba-161">404</span><span class="sxs-lookup"><span data-stu-id="acbba-161">404</span></span>| <span data-ttu-id="acbba-162">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="acbba-162">Not Found</span></span>| <span data-ttu-id="acbba-163">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="acbba-163">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="acbba-164">500</span><span class="sxs-lookup"><span data-stu-id="acbba-164">500</span></span>| <span data-ttu-id="acbba-165">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="acbba-165">Internal Server Error</span></span>| <span data-ttu-id="acbba-166">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="acbba-166">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="acbba-167">503</span><span class="sxs-lookup"><span data-stu-id="acbba-167">503</span></span>| <span data-ttu-id="acbba-168">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="acbba-168">Service Unavailable</span></span>| <span data-ttu-id="acbba-169">要求が調整された、クライアント再試行値 (例: 5 秒後) を秒単位で後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="acbba-169">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EQH"></a>

 
## <a name="response-body"></a><span data-ttu-id="acbba-170">応答本文</span><span class="sxs-lookup"><span data-stu-id="acbba-170">Response body</span></span>
 
<span data-ttu-id="acbba-171">成功した場合、応答本文は空です。</span><span class="sxs-lookup"><span data-stu-id="acbba-171">On success, the response body is empty.</span></span> <span data-ttu-id="acbba-172">失敗した場合、 [ServiceError (JSON)](../../json/json-serviceerror.md)ドキュメントが返されます。</span><span class="sxs-lookup"><span data-stu-id="acbba-172">On failure, a [ServiceError (JSON)](../../json/json-serviceerror.md) document is returned.</span></span>
 
<a id="ID4E3H"></a>

 
### <a name="sample-response"></a><span data-ttu-id="acbba-173">応答の例</span><span class="sxs-lookup"><span data-stu-id="acbba-173">Sample response</span></span>
 

```cpp
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
         
```

   
<a id="ID4EHAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="acbba-174">関連項目</span><span class="sxs-lookup"><span data-stu-id="acbba-174">See also</span></span>
 
<a id="ID4EJAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="acbba-175">Parent</span><span class="sxs-lookup"><span data-stu-id="acbba-175">Parent</span></span> 

[<span data-ttu-id="acbba-176">/users/xuid({xuid})/resetreputation</span><span class="sxs-lookup"><span data-stu-id="acbba-176">/users/xuid({xuid})/resetreputation</span></span>](uri-usersxuidresetreputation.md)

   