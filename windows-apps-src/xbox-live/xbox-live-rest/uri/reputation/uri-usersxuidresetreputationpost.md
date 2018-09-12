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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881500"
---
# <a name="post-usersxuidxuidresetreputation"></a><span data-ttu-id="5cdfd-104">POST (/users/xuid({xuid})/resetreputation)</span><span class="sxs-lookup"><span data-stu-id="5cdfd-104">POST (/users/xuid({xuid})/resetreputation)</span></span>
<span data-ttu-id="5cdfd-105">により、実施チームは、アカウント ハイジャック (たとえば) した後、いくつかの任意の値を指定したユーザーの評判スコアを設定します。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-105">Enables the Enforcement team to set the specified user's Reputation Scores to some arbitrary values after (for example) an account hijacking.</span></span> <span data-ttu-id="5cdfd-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="5cdfd-107">注釈</span><span class="sxs-lookup"><span data-stu-id="5cdfd-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="5cdfd-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5cdfd-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="5cdfd-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="5cdfd-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="5cdfd-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5cdfd-110">Required Request Headers</span></span>](#ID4E5B)
  * [<span data-ttu-id="5cdfd-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="5cdfd-111">Request body</span></span>](#ID4EYD)
  * [<span data-ttu-id="5cdfd-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="5cdfd-112">HTTP status codes</span></span>](#ID4EOE)
  * [<span data-ttu-id="5cdfd-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="5cdfd-113">Response body</span></span>](#ID4EQH)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="5cdfd-114">注釈</span><span class="sxs-lookup"><span data-stu-id="5cdfd-114">Remarks</span></span>
 
<span data-ttu-id="5cdfd-115">このメソッドは、Retail を除くすべてのサンド ボックスの他のすべてのパートナーとテスト目的で、Retail を除くすべてのサンド ボックス内のユーザーによっても呼び出すことがあります。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-115">This method may also be called by any other Partners for all sandboxes except Retail, and by users in all sandboxes except Retail, for testing purposes.</span></span> <span data-ttu-id="5cdfd-116">この要求は、「基本」評判スコアをユーザーに設定し、肯定的なフィードバック良い評価の彼は重みをすべて消去アウトことに注意してください。この呼び出しを行った後、ユーザーの実際の評判は、基本スコアと自分のアンバサダー ボーナスと自分のフォロワー ボーナスになります。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-116">Note that this request sets a user's "base" reputation scores, and his positive feedback weightings will all be zeroed out. The user's actual reputation after making this call will be these base scores plus his ambassador bonus plus his follower bonus.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="5cdfd-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5cdfd-117">URI parameters</span></span>
 
| <span data-ttu-id="5cdfd-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5cdfd-118">Parameter</span></span>| <span data-ttu-id="5cdfd-119">型</span><span class="sxs-lookup"><span data-stu-id="5cdfd-119">Type</span></span>| <span data-ttu-id="5cdfd-120">説明</span><span class="sxs-lookup"><span data-stu-id="5cdfd-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5cdfd-121">xuid</span><span class="sxs-lookup"><span data-stu-id="5cdfd-121">xuid</span></span>| <span data-ttu-id="5cdfd-122">string</span><span class="sxs-lookup"><span data-stu-id="5cdfd-122">string</span></span>| <span data-ttu-id="5cdfd-123">Xbox ユーザー ID (XUID)、指定したユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-123">The Xbox User ID (XUID) of the specified user.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="5cdfd-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="5cdfd-124">Authorization</span></span>
 
<span data-ttu-id="5cdfd-125">パートナーから: **PartnerClaim**実施チームから、市販のサンド ボックスすべてのサンド ボックスに対して、 **PartnerClaim**します。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-125">From partner: For the Retail sandbox, **PartnerClaim** from the Enforcement team; for all other sandboxes, **PartnerClaim**.</span></span>
 
<span data-ttu-id="5cdfd-126">ユーザーから: 製品版、 **XuidClaim** **TitleClaim**を除くすべてのサンド ボックスにします。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-126">From user: For all Sandboxes except Retail, **XuidClaim** and **TitleClaim**.</span></span>
  
<a id="ID4E5B"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="5cdfd-127">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5cdfd-127">Required Request Headers</span></span>
 
<span data-ttu-id="5cdfd-128">すべて:**コンテンツの種類: アプリケーション/json**します。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-128">From all: **Content-Type: application/json**.</span></span>
 
<span data-ttu-id="5cdfd-129">パートナーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)、 **X-Xbl のサンド ボックス**。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-129">From partner: **X-Xbl-Contract-Version** (current version is 101), **X-Xbl-Sandbox**.</span></span>
 
<span data-ttu-id="5cdfd-130">ユーザーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-130">From user: **X-Xbl-Contract-Version** (current version is 101).</span></span>
 
| <span data-ttu-id="5cdfd-131">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5cdfd-131">Header</span></span>| <span data-ttu-id="5cdfd-132">型</span><span class="sxs-lookup"><span data-stu-id="5cdfd-132">Type</span></span>| <span data-ttu-id="5cdfd-133">説明</span><span class="sxs-lookup"><span data-stu-id="5cdfd-133">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="5cdfd-134">Authorization</span><span class="sxs-lookup"><span data-stu-id="5cdfd-134">Authorization</span></span>| <span data-ttu-id="5cdfd-135">string</span><span class="sxs-lookup"><span data-stu-id="5cdfd-135">string</span></span>| <span data-ttu-id="5cdfd-136">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-136">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="5cdfd-137">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-137">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="5cdfd-138">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="5cdfd-138">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="5cdfd-139">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-139">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="5cdfd-140">要求はのみにルーティングすると、サービスの認証トークンを要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-140">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="5cdfd-141">既定値: 101 します。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-141">Default value: 101.</span></span>| 
  
<a id="ID4EYD"></a>

 
## <a name="request-body"></a><span data-ttu-id="5cdfd-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="5cdfd-142">Request body</span></span>
 
<a id="ID4E5D"></a>

 
### <a name="sample-request"></a><span data-ttu-id="5cdfd-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="5cdfd-143">Sample request</span></span>
 
<span data-ttu-id="5cdfd-144">要求本文は、単純な[ResetReputation (JSON)](../../json/json-resetreputation.md)ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-144">The request body is a simple [ResetReputation (JSON)](../../json/json-resetreputation.md) document.</span></span>
 

```cpp
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
      
```

   
<a id="ID4EOE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="5cdfd-145">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="5cdfd-145">HTTP status codes</span></span>
 
<span data-ttu-id="5cdfd-146">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-146">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="5cdfd-147">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-147">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="5cdfd-148">コード</span><span class="sxs-lookup"><span data-stu-id="5cdfd-148">Code</span></span>| <span data-ttu-id="5cdfd-149">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="5cdfd-149">Reason phrase</span></span>| <span data-ttu-id="5cdfd-150">説明</span><span class="sxs-lookup"><span data-stu-id="5cdfd-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="5cdfd-151">200</span><span class="sxs-lookup"><span data-stu-id="5cdfd-151">200</span></span>| <span data-ttu-id="5cdfd-152">OK</span><span class="sxs-lookup"><span data-stu-id="5cdfd-152">OK</span></span>| <span data-ttu-id="5cdfd-153">OK。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-153">OK.</span></span>| 
| <span data-ttu-id="5cdfd-154">400</span><span class="sxs-lookup"><span data-stu-id="5cdfd-154">400</span></span>| <span data-ttu-id="5cdfd-155">Bad Request</span><span class="sxs-lookup"><span data-stu-id="5cdfd-155">Bad Request</span></span>| <span data-ttu-id="5cdfd-156">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-156">Service could not understand malformed request.</span></span> <span data-ttu-id="5cdfd-157">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-157">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="5cdfd-158">401</span><span class="sxs-lookup"><span data-stu-id="5cdfd-158">401</span></span>| <span data-ttu-id="5cdfd-159">権限がありません</span><span class="sxs-lookup"><span data-stu-id="5cdfd-159">Unauthorized</span></span>| <span data-ttu-id="5cdfd-160">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-160">The request requires user authentication.</span></span>| 
| <span data-ttu-id="5cdfd-161">404</span><span class="sxs-lookup"><span data-stu-id="5cdfd-161">404</span></span>| <span data-ttu-id="5cdfd-162">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-162">Not Found</span></span>| <span data-ttu-id="5cdfd-163">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-163">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="5cdfd-164">500</span><span class="sxs-lookup"><span data-stu-id="5cdfd-164">500</span></span>| <span data-ttu-id="5cdfd-165">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="5cdfd-165">Internal Server Error</span></span>| <span data-ttu-id="5cdfd-166">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-166">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="5cdfd-167">503</span><span class="sxs-lookup"><span data-stu-id="5cdfd-167">503</span></span>| <span data-ttu-id="5cdfd-168">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="5cdfd-168">Service Unavailable</span></span>| <span data-ttu-id="5cdfd-169">要求がスロット リングされた、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-169">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EQH"></a>

 
## <a name="response-body"></a><span data-ttu-id="5cdfd-170">応答本文</span><span class="sxs-lookup"><span data-stu-id="5cdfd-170">Response body</span></span>
 
<span data-ttu-id="5cdfd-171">成功した場合、応答本文は空です。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-171">On success, the response body is empty.</span></span> <span data-ttu-id="5cdfd-172">失敗した場合、 [ServiceError (JSON)](../../json/json-serviceerror.md)のドキュメントが返されます。</span><span class="sxs-lookup"><span data-stu-id="5cdfd-172">On failure, a [ServiceError (JSON)](../../json/json-serviceerror.md) document is returned.</span></span>
 
<a id="ID4E3H"></a>

 
### <a name="sample-response"></a><span data-ttu-id="5cdfd-173">応答の例</span><span class="sxs-lookup"><span data-stu-id="5cdfd-173">Sample response</span></span>
 

```cpp
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
         
```

   
<a id="ID4EHAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5cdfd-174">関連項目</span><span class="sxs-lookup"><span data-stu-id="5cdfd-174">See also</span></span>
 
<a id="ID4EJAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5cdfd-175">Parent</span><span class="sxs-lookup"><span data-stu-id="5cdfd-175">Parent</span></span> 

[<span data-ttu-id="5cdfd-176">/users/xuid({xuid})/resetreputation</span><span class="sxs-lookup"><span data-stu-id="5cdfd-176">/users/xuid({xuid})/resetreputation</span></span>](uri-usersxuidresetreputation.md)

   