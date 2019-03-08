---
title: POST (/users/me/resetreputation)
assetID: 1a4fed45-f608-dac2-3384-2ee493112f7b
permalink: en-us/docs/xboxlive/rest/uri-usersmeresetreputationpost.html
description: " POST (/users/me/resetreputation)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fc770673ac7e4034004f58032c7fa66cb28413e7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632687"
---
# <a name="post-usersmeresetreputation"></a><span data-ttu-id="affa3-104">POST (/users/me/resetreputation)</span><span class="sxs-lookup"><span data-stu-id="affa3-104">POST (/users/me/resetreputation)</span></span>
<span data-ttu-id="affa3-105">強制チーム アカウント ハイジャックでは (たとえば) 後、現在のユーザーの評価スコアをいくつかの任意の値に設定を有効にします。</span><span class="sxs-lookup"><span data-stu-id="affa3-105">Enables the Enforcement team to set the current user's Reputation Scores to some arbitrary values after (for example) an account hijacking.</span></span> <span data-ttu-id="affa3-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="affa3-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="affa3-107">注釈</span><span class="sxs-lookup"><span data-stu-id="affa3-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="affa3-108">承認</span><span class="sxs-lookup"><span data-stu-id="affa3-108">Authorization</span></span>](#ID4E5)
  * [<span data-ttu-id="affa3-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="affa3-109">Required Request Headers</span></span>](#ID4ETB)
  * [<span data-ttu-id="affa3-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="affa3-110">Request body</span></span>](#ID4END)
  * [<span data-ttu-id="affa3-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="affa3-111">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="affa3-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="affa3-112">Response body</span></span>](#ID4EFH)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="affa3-113">注釈</span><span class="sxs-lookup"><span data-stu-id="affa3-113">Remarks</span></span>
 
<span data-ttu-id="affa3-114">テスト目的で、製品版を除くすべてのサンド ボックス内のユーザーと他のパートナーの製品版を除くすべてのサンド ボックスによって、このメソッドを呼び出すことも可能性があります。</span><span class="sxs-lookup"><span data-stu-id="affa3-114">This method may also be called by any other Partners for all sandboxes except Retail, and by users in all sandboxes except Retail, for testing purposes.</span></span> <span data-ttu-id="affa3-115">この要求設定、ユーザーの「基本」評判のスコア、建設的なフィードバックの重み付けがすべてゼロ化ことに注意してください。この呼び出しを行った後、ユーザーの実際の評価は、これらの基本スコアと、アンバサダー ボーナスと自分のフォロワー ボーナスになります。</span><span class="sxs-lookup"><span data-stu-id="affa3-115">Note that this request sets a user's "base" reputation scores, and his positive feedback weightings will all be zeroed out. The user's actual reputation after making this call will be these base scores plus his ambassador bonus plus his follower bonus.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="authorization"></a><span data-ttu-id="affa3-116">Authorization</span><span class="sxs-lookup"><span data-stu-id="affa3-116">Authorization</span></span>
 
<span data-ttu-id="affa3-117">パートナー: から小売サンド ボックスの**PartnerClaim**強制チームからは他のすべてのサンド ボックス**PartnerClaim**します。</span><span class="sxs-lookup"><span data-stu-id="affa3-117">From partner: For the Retail sandbox, **PartnerClaim** from the Enforcement team; for all other sandboxes, **PartnerClaim**.</span></span>
 
<span data-ttu-id="affa3-118">ユーザー: から製品版を除くすべてのサンド ボックスの**XuidClaim**と**TitleClaim**します。</span><span class="sxs-lookup"><span data-stu-id="affa3-118">From user: For all Sandboxes except Retail, **XuidClaim** and **TitleClaim**.</span></span>
  
<a id="ID4ETB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="affa3-119">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="affa3-119">Required Request Headers</span></span>
 
<span data-ttu-id="affa3-120">All: から**コンテンツの種類: アプリケーション/json**します。</span><span class="sxs-lookup"><span data-stu-id="affa3-120">From all: **Content-Type: application/json**.</span></span>
 
<span data-ttu-id="affa3-121">パートナー: から**X Xbl コントラクト バージョン**(現在のバージョンが 101)、 **X-Xbl-サンド ボックス**します。</span><span class="sxs-lookup"><span data-stu-id="affa3-121">From partner: **X-Xbl-Contract-Version** (current version is 101), **X-Xbl-Sandbox**.</span></span>
 
<span data-ttu-id="affa3-122">ユーザー: から**X Xbl コントラクト バージョン**(現在のバージョンでは 101 です)。</span><span class="sxs-lookup"><span data-stu-id="affa3-122">From user: **X-Xbl-Contract-Version** (current version is 101).</span></span>
 
| <span data-ttu-id="affa3-123">Header</span><span class="sxs-lookup"><span data-stu-id="affa3-123">Header</span></span>| <span data-ttu-id="affa3-124">種類</span><span class="sxs-lookup"><span data-stu-id="affa3-124">Type</span></span>| <span data-ttu-id="affa3-125">説明</span><span class="sxs-lookup"><span data-stu-id="affa3-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="affa3-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="affa3-126">Authorization</span></span>| <span data-ttu-id="affa3-127">string</span><span class="sxs-lookup"><span data-stu-id="affa3-127">string</span></span>| <span data-ttu-id="affa3-128">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="affa3-128">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="affa3-129">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="affa3-129">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="affa3-130">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="affa3-130">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="affa3-131">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="affa3-131">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="affa3-132">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="affa3-132">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="affa3-133">［既定値］:101.</span><span class="sxs-lookup"><span data-stu-id="affa3-133">Default value: 101.</span></span>| 
  
<a id="ID4END"></a>

 
## <a name="request-body"></a><span data-ttu-id="affa3-134">要求本文</span><span class="sxs-lookup"><span data-stu-id="affa3-134">Request body</span></span>
 
<a id="ID4ETD"></a>

 
### <a name="sample-request"></a><span data-ttu-id="affa3-135">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="affa3-135">Sample request</span></span>
 
<span data-ttu-id="affa3-136">要求本文は、単純な[ResetReputation (JSON)](../../json/json-resetreputation.md)ドキュメント。</span><span class="sxs-lookup"><span data-stu-id="affa3-136">The request body is a simple [ResetReputation (JSON)](../../json/json-resetreputation.md) document.</span></span>
 

```cpp
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
      
```

   
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="affa3-137">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="affa3-137">HTTP status codes</span></span>
 
<span data-ttu-id="affa3-138">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="affa3-138">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="affa3-139">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="affa3-139">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="affa3-140">コード</span><span class="sxs-lookup"><span data-stu-id="affa3-140">Code</span></span>| <span data-ttu-id="affa3-141">理由語句</span><span class="sxs-lookup"><span data-stu-id="affa3-141">Reason phrase</span></span>| <span data-ttu-id="affa3-142">説明</span><span class="sxs-lookup"><span data-stu-id="affa3-142">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="affa3-143">200</span><span class="sxs-lookup"><span data-stu-id="affa3-143">200</span></span>| <span data-ttu-id="affa3-144">OK</span><span class="sxs-lookup"><span data-stu-id="affa3-144">OK</span></span>| <span data-ttu-id="affa3-145">OK。</span><span class="sxs-lookup"><span data-stu-id="affa3-145">OK.</span></span>| 
| <span data-ttu-id="affa3-146">400</span><span class="sxs-lookup"><span data-stu-id="affa3-146">400</span></span>| <span data-ttu-id="affa3-147">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="affa3-147">Bad Request</span></span>| <span data-ttu-id="affa3-148">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="affa3-148">Service could not understand malformed request.</span></span> <span data-ttu-id="affa3-149">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="affa3-149">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="affa3-150">401</span><span class="sxs-lookup"><span data-stu-id="affa3-150">401</span></span>| <span data-ttu-id="affa3-151">権限がありません</span><span class="sxs-lookup"><span data-stu-id="affa3-151">Unauthorized</span></span>| <span data-ttu-id="affa3-152">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="affa3-152">The request requires user authentication.</span></span>| 
| <span data-ttu-id="affa3-153">404</span><span class="sxs-lookup"><span data-stu-id="affa3-153">404</span></span>| <span data-ttu-id="affa3-154">検出不可</span><span class="sxs-lookup"><span data-stu-id="affa3-154">Not Found</span></span>| <span data-ttu-id="affa3-155">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="affa3-155">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="affa3-156">500</span><span class="sxs-lookup"><span data-stu-id="affa3-156">500</span></span>| <span data-ttu-id="affa3-157">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="affa3-157">Internal Server Error</span></span>| <span data-ttu-id="affa3-158">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="affa3-158">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="affa3-159">503</span><span class="sxs-lookup"><span data-stu-id="affa3-159">503</span></span>| <span data-ttu-id="affa3-160">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="affa3-160">Service Unavailable</span></span>| <span data-ttu-id="affa3-161">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="affa3-161">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EFH"></a>

 
## <a name="response-body"></a><span data-ttu-id="affa3-162">応答本文</span><span class="sxs-lookup"><span data-stu-id="affa3-162">Response body</span></span>
 
<span data-ttu-id="affa3-163">成功した場合、応答本文が空です。</span><span class="sxs-lookup"><span data-stu-id="affa3-163">On success, the response body is empty.</span></span> <span data-ttu-id="affa3-164">失敗した場合、[サービス エラー (JSON)](../../json/json-serviceerror.md)ドキュメントが返されます。</span><span class="sxs-lookup"><span data-stu-id="affa3-164">On failure, a [ServiceError (JSON)](../../json/json-serviceerror.md) document is returned.</span></span>
 
<a id="ID4ERH"></a>

 
### <a name="sample-response"></a><span data-ttu-id="affa3-165">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="affa3-165">Sample response</span></span>
 

```cpp
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
         
```

   
<a id="ID4E2H"></a>

 
## <a name="see-also"></a><span data-ttu-id="affa3-166">関連項目</span><span class="sxs-lookup"><span data-stu-id="affa3-166">See also</span></span>
 
<a id="ID4E4H"></a>

 
##### <a name="parent"></a><span data-ttu-id="affa3-167">Parent</span><span class="sxs-lookup"><span data-stu-id="affa3-167">Parent</span></span> 

[<span data-ttu-id="affa3-168">/users/me/resetreputation</span><span class="sxs-lookup"><span data-stu-id="affa3-168">/users/me/resetreputation</span></span>](uri-usersmeresetreputation.md)

   