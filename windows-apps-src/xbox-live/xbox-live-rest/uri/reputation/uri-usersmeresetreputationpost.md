---
title: POST (/users/me/resetreputation)
assetID: 1a4fed45-f608-dac2-3384-2ee493112f7b
permalink: en-us/docs/xboxlive/rest/uri-usersmeresetreputationpost.html
author: KevinAsgari
description: " POST (/users/me/resetreputation)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1a8bfe8a76b83c78886c48f7e15de274fe89a52a
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4388193"
---
# <a name="post-usersmeresetreputation"></a><span data-ttu-id="40a14-104">POST (/users/me/resetreputation)</span><span class="sxs-lookup"><span data-stu-id="40a14-104">POST (/users/me/resetreputation)</span></span>
<span data-ttu-id="40a14-105">により、実施チームは、アカウント ハイジャック (たとえば) 後、現在のユーザーの評判スコアをいくつかの任意の値に設定します。</span><span class="sxs-lookup"><span data-stu-id="40a14-105">Enables the Enforcement team to set the current user's Reputation Scores to some arbitrary values after (for example) an account hijacking.</span></span> <span data-ttu-id="40a14-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="40a14-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="40a14-107">注釈</span><span class="sxs-lookup"><span data-stu-id="40a14-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="40a14-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="40a14-108">Authorization</span></span>](#ID4E5)
  * [<span data-ttu-id="40a14-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40a14-109">Required Request Headers</span></span>](#ID4ETB)
  * [<span data-ttu-id="40a14-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="40a14-110">Request body</span></span>](#ID4END)
  * [<span data-ttu-id="40a14-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="40a14-111">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="40a14-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="40a14-112">Response body</span></span>](#ID4EFH)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="40a14-113">注釈</span><span class="sxs-lookup"><span data-stu-id="40a14-113">Remarks</span></span>
 
<span data-ttu-id="40a14-114">テストのために、Retail を除くすべてのサンド ボックス内のユーザーと Retail を除くすべてのサンド ボックスの他のパートナー様により、このメソッドを呼び出すも可能性があります。</span><span class="sxs-lookup"><span data-stu-id="40a14-114">This method may also be called by any other Partners for all sandboxes except Retail, and by users in all sandboxes except Retail, for testing purposes.</span></span> <span data-ttu-id="40a14-115">この要求は、「基本」評判スコアをユーザーに設定し、肯定的なフィードバック良い評価の彼は重みをすべて消去アウトことに注意してください。この呼び出しを行った後、ユーザーの実際の評判は、この基本スコアと自分のアンバサダー ボーナスと自分のフォロワー ボーナスになります。</span><span class="sxs-lookup"><span data-stu-id="40a14-115">Note that this request sets a user's "base" reputation scores, and his positive feedback weightings will all be zeroed out. The user's actual reputation after making this call will be these base scores plus his ambassador bonus plus his follower bonus.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="authorization"></a><span data-ttu-id="40a14-116">Authorization</span><span class="sxs-lookup"><span data-stu-id="40a14-116">Authorization</span></span>
 
<span data-ttu-id="40a14-117">パートナーから: **PartnerClaim**実施チームから、市販のサンド ボックスすべての他のサンド ボックスに対して、 **PartnerClaim**します。</span><span class="sxs-lookup"><span data-stu-id="40a14-117">From partner: For the Retail sandbox, **PartnerClaim** from the Enforcement team; for all other sandboxes, **PartnerClaim**.</span></span>
 
<span data-ttu-id="40a14-118">ユーザーから: 製品版、 **XuidClaim** **TitleClaim**を除くすべてのサンド ボックスにします。</span><span class="sxs-lookup"><span data-stu-id="40a14-118">From user: For all Sandboxes except Retail, **XuidClaim** and **TitleClaim**.</span></span>
  
<a id="ID4ETB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="40a14-119">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40a14-119">Required Request Headers</span></span>
 
<span data-ttu-id="40a14-120">すべてから:**コンテンツの種類: アプリケーション/json**します。</span><span class="sxs-lookup"><span data-stu-id="40a14-120">From all: **Content-Type: application/json**.</span></span>
 
<span data-ttu-id="40a14-121">パートナーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)、 **X の Xbl のサンド ボックス**です。</span><span class="sxs-lookup"><span data-stu-id="40a14-121">From partner: **X-Xbl-Contract-Version** (current version is 101), **X-Xbl-Sandbox**.</span></span>
 
<span data-ttu-id="40a14-122">ユーザーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)。</span><span class="sxs-lookup"><span data-stu-id="40a14-122">From user: **X-Xbl-Contract-Version** (current version is 101).</span></span>
 
| <span data-ttu-id="40a14-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40a14-123">Header</span></span>| <span data-ttu-id="40a14-124">型</span><span class="sxs-lookup"><span data-stu-id="40a14-124">Type</span></span>| <span data-ttu-id="40a14-125">説明</span><span class="sxs-lookup"><span data-stu-id="40a14-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="40a14-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="40a14-126">Authorization</span></span>| <span data-ttu-id="40a14-127">string</span><span class="sxs-lookup"><span data-stu-id="40a14-127">string</span></span>| <span data-ttu-id="40a14-128">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="40a14-128">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="40a14-129">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。</span><span class="sxs-lookup"><span data-stu-id="40a14-129">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="40a14-130">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="40a14-130">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="40a14-131">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="40a14-131">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="40a14-132">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="40a14-132">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="40a14-133">既定値: 101 します。</span><span class="sxs-lookup"><span data-stu-id="40a14-133">Default value: 101.</span></span>| 
  
<a id="ID4END"></a>

 
## <a name="request-body"></a><span data-ttu-id="40a14-134">要求本文</span><span class="sxs-lookup"><span data-stu-id="40a14-134">Request body</span></span>
 
<a id="ID4ETD"></a>

 
### <a name="sample-request"></a><span data-ttu-id="40a14-135">要求の例</span><span class="sxs-lookup"><span data-stu-id="40a14-135">Sample request</span></span>
 
<span data-ttu-id="40a14-136">要求本文は、単純な[ResetReputation (JSON)](../../json/json-resetreputation.md)ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="40a14-136">The request body is a simple [ResetReputation (JSON)](../../json/json-resetreputation.md) document.</span></span>
 

```cpp
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
      
```

   
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="40a14-137">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="40a14-137">HTTP status codes</span></span>
 
<span data-ttu-id="40a14-138">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="40a14-138">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="40a14-139">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="40a14-139">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="40a14-140">コード</span><span class="sxs-lookup"><span data-stu-id="40a14-140">Code</span></span>| <span data-ttu-id="40a14-141">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="40a14-141">Reason phrase</span></span>| <span data-ttu-id="40a14-142">説明</span><span class="sxs-lookup"><span data-stu-id="40a14-142">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="40a14-143">200</span><span class="sxs-lookup"><span data-stu-id="40a14-143">200</span></span>| <span data-ttu-id="40a14-144">OK</span><span class="sxs-lookup"><span data-stu-id="40a14-144">OK</span></span>| <span data-ttu-id="40a14-145">OK。</span><span class="sxs-lookup"><span data-stu-id="40a14-145">OK.</span></span>| 
| <span data-ttu-id="40a14-146">400</span><span class="sxs-lookup"><span data-stu-id="40a14-146">400</span></span>| <span data-ttu-id="40a14-147">Bad Request</span><span class="sxs-lookup"><span data-stu-id="40a14-147">Bad Request</span></span>| <span data-ttu-id="40a14-148">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="40a14-148">Service could not understand malformed request.</span></span> <span data-ttu-id="40a14-149">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="40a14-149">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="40a14-150">401</span><span class="sxs-lookup"><span data-stu-id="40a14-150">401</span></span>| <span data-ttu-id="40a14-151">権限がありません</span><span class="sxs-lookup"><span data-stu-id="40a14-151">Unauthorized</span></span>| <span data-ttu-id="40a14-152">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="40a14-152">The request requires user authentication.</span></span>| 
| <span data-ttu-id="40a14-153">404</span><span class="sxs-lookup"><span data-stu-id="40a14-153">404</span></span>| <span data-ttu-id="40a14-154">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="40a14-154">Not Found</span></span>| <span data-ttu-id="40a14-155">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="40a14-155">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="40a14-156">500</span><span class="sxs-lookup"><span data-stu-id="40a14-156">500</span></span>| <span data-ttu-id="40a14-157">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="40a14-157">Internal Server Error</span></span>| <span data-ttu-id="40a14-158">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="40a14-158">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="40a14-159">503</span><span class="sxs-lookup"><span data-stu-id="40a14-159">503</span></span>| <span data-ttu-id="40a14-160">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="40a14-160">Service Unavailable</span></span>| <span data-ttu-id="40a14-161">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="40a14-161">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EFH"></a>

 
## <a name="response-body"></a><span data-ttu-id="40a14-162">応答本文</span><span class="sxs-lookup"><span data-stu-id="40a14-162">Response body</span></span>
 
<span data-ttu-id="40a14-163">成功した場合、応答本文は空です。</span><span class="sxs-lookup"><span data-stu-id="40a14-163">On success, the response body is empty.</span></span> <span data-ttu-id="40a14-164">失敗した場合、 [ServiceError (JSON)](../../json/json-serviceerror.md)ドキュメントが返されます。</span><span class="sxs-lookup"><span data-stu-id="40a14-164">On failure, a [ServiceError (JSON)](../../json/json-serviceerror.md) document is returned.</span></span>
 
<a id="ID4ERH"></a>

 
### <a name="sample-response"></a><span data-ttu-id="40a14-165">応答の例</span><span class="sxs-lookup"><span data-stu-id="40a14-165">Sample response</span></span>
 

```cpp
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
         
```

   
<a id="ID4E2H"></a>

 
## <a name="see-also"></a><span data-ttu-id="40a14-166">関連項目</span><span class="sxs-lookup"><span data-stu-id="40a14-166">See also</span></span>
 
<a id="ID4E4H"></a>

 
##### <a name="parent"></a><span data-ttu-id="40a14-167">Parent</span><span class="sxs-lookup"><span data-stu-id="40a14-167">Parent</span></span> 

[<span data-ttu-id="40a14-168">/users/me/resetreputation</span><span class="sxs-lookup"><span data-stu-id="40a14-168">/users/me/resetreputation</span></span>](uri-usersmeresetreputation.md)

   