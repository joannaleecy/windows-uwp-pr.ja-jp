---
title: POST (/users/xuid({xuid})/resetreputation)
assetID: 3b76857f-b043-2c76-cf0c-c8f355fe3849
permalink: en-us/docs/xboxlive/rest/uri-usersxuidresetreputationpost.html
description: " POST (/users/xuid({xuid})/resetreputation)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2918249eaf359b383e89f24b8a37352bc3fe5132
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623527"
---
# <a name="post-usersxuidxuidresetreputation"></a><span data-ttu-id="da8cc-104">POST (/users/xuid({xuid})/resetreputation)</span><span class="sxs-lookup"><span data-stu-id="da8cc-104">POST (/users/xuid({xuid})/resetreputation)</span></span>
<span data-ttu-id="da8cc-105">強制チーム アカウント ハイジャックでは (たとえば) 後、指定したユーザーの評価スコアをいくつかの任意の値に設定を有効にします。</span><span class="sxs-lookup"><span data-stu-id="da8cc-105">Enables the Enforcement team to set the specified user's Reputation Scores to some arbitrary values after (for example) an account hijacking.</span></span> <span data-ttu-id="da8cc-106">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="da8cc-106">The domain for these URIs is `reputation.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="da8cc-107">注釈</span><span class="sxs-lookup"><span data-stu-id="da8cc-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="da8cc-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da8cc-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="da8cc-109">承認</span><span class="sxs-lookup"><span data-stu-id="da8cc-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="da8cc-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da8cc-110">Required Request Headers</span></span>](#ID4E5B)
  * [<span data-ttu-id="da8cc-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="da8cc-111">Request body</span></span>](#ID4EYD)
  * [<span data-ttu-id="da8cc-112">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da8cc-112">HTTP status codes</span></span>](#ID4EOE)
  * [<span data-ttu-id="da8cc-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="da8cc-113">Response body</span></span>](#ID4EQH)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="da8cc-114">注釈</span><span class="sxs-lookup"><span data-stu-id="da8cc-114">Remarks</span></span>
 
<span data-ttu-id="da8cc-115">テスト目的で、製品版を除くすべてのサンド ボックス内のユーザーと他のパートナーの製品版を除くすべてのサンド ボックスによって、このメソッドを呼び出すことも可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da8cc-115">This method may also be called by any other Partners for all sandboxes except Retail, and by users in all sandboxes except Retail, for testing purposes.</span></span> <span data-ttu-id="da8cc-116">この要求設定、ユーザーの「基本」評判のスコア、建設的なフィードバックの重み付けがすべてゼロ化ことに注意してください。この呼び出しを行った後、ユーザーの実際の評価は、これらの基本スコアと、アンバサダー ボーナスと自分のフォロワー ボーナスになります。</span><span class="sxs-lookup"><span data-stu-id="da8cc-116">Note that this request sets a user's "base" reputation scores, and his positive feedback weightings will all be zeroed out. The user's actual reputation after making this call will be these base scores plus his ambassador bonus plus his follower bonus.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="da8cc-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da8cc-117">URI parameters</span></span>
 
| <span data-ttu-id="da8cc-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="da8cc-118">Parameter</span></span>| <span data-ttu-id="da8cc-119">種類</span><span class="sxs-lookup"><span data-stu-id="da8cc-119">Type</span></span>| <span data-ttu-id="da8cc-120">説明</span><span class="sxs-lookup"><span data-stu-id="da8cc-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="da8cc-121">xuid</span><span class="sxs-lookup"><span data-stu-id="da8cc-121">xuid</span></span>| <span data-ttu-id="da8cc-122">string</span><span class="sxs-lookup"><span data-stu-id="da8cc-122">string</span></span>| <span data-ttu-id="da8cc-123">Xbox ユーザー ID (XUID) の指定したユーザー。</span><span class="sxs-lookup"><span data-stu-id="da8cc-123">The Xbox User ID (XUID) of the specified user.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a><span data-ttu-id="da8cc-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="da8cc-124">Authorization</span></span>
 
<span data-ttu-id="da8cc-125">パートナー: から小売サンド ボックスの**PartnerClaim**強制チームからは他のすべてのサンド ボックス**PartnerClaim**します。</span><span class="sxs-lookup"><span data-stu-id="da8cc-125">From partner: For the Retail sandbox, **PartnerClaim** from the Enforcement team; for all other sandboxes, **PartnerClaim**.</span></span>
 
<span data-ttu-id="da8cc-126">ユーザー: から製品版を除くすべてのサンド ボックスの**XuidClaim**と**TitleClaim**します。</span><span class="sxs-lookup"><span data-stu-id="da8cc-126">From user: For all Sandboxes except Retail, **XuidClaim** and **TitleClaim**.</span></span>
  
<a id="ID4E5B"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="da8cc-127">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da8cc-127">Required Request Headers</span></span>
 
<span data-ttu-id="da8cc-128">All: から**コンテンツの種類: アプリケーション/json**します。</span><span class="sxs-lookup"><span data-stu-id="da8cc-128">From all: **Content-Type: application/json**.</span></span>
 
<span data-ttu-id="da8cc-129">パートナー: から**X Xbl コントラクト バージョン**(現在のバージョンが 101)、 **X-Xbl-サンド ボックス**します。</span><span class="sxs-lookup"><span data-stu-id="da8cc-129">From partner: **X-Xbl-Contract-Version** (current version is 101), **X-Xbl-Sandbox**.</span></span>
 
<span data-ttu-id="da8cc-130">ユーザー: から**X Xbl コントラクト バージョン**(現在のバージョンでは 101 です)。</span><span class="sxs-lookup"><span data-stu-id="da8cc-130">From user: **X-Xbl-Contract-Version** (current version is 101).</span></span>
 
| <span data-ttu-id="da8cc-131">Header</span><span class="sxs-lookup"><span data-stu-id="da8cc-131">Header</span></span>| <span data-ttu-id="da8cc-132">種類</span><span class="sxs-lookup"><span data-stu-id="da8cc-132">Type</span></span>| <span data-ttu-id="da8cc-133">説明</span><span class="sxs-lookup"><span data-stu-id="da8cc-133">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="da8cc-134">Authorization</span><span class="sxs-lookup"><span data-stu-id="da8cc-134">Authorization</span></span>| <span data-ttu-id="da8cc-135">string</span><span class="sxs-lookup"><span data-stu-id="da8cc-135">string</span></span>| <span data-ttu-id="da8cc-136">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="da8cc-136">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="da8cc-137">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="da8cc-137">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="da8cc-138">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="da8cc-138">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="da8cc-139">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="da8cc-139">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="da8cc-140">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="da8cc-140">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="da8cc-141">［既定値］:101.</span><span class="sxs-lookup"><span data-stu-id="da8cc-141">Default value: 101.</span></span>| 
  
<a id="ID4EYD"></a>

 
## <a name="request-body"></a><span data-ttu-id="da8cc-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="da8cc-142">Request body</span></span>
 
<a id="ID4E5D"></a>

 
### <a name="sample-request"></a><span data-ttu-id="da8cc-143">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="da8cc-143">Sample request</span></span>
 
<span data-ttu-id="da8cc-144">要求本文は、単純な[ResetReputation (JSON)](../../json/json-resetreputation.md)ドキュメント。</span><span class="sxs-lookup"><span data-stu-id="da8cc-144">The request body is a simple [ResetReputation (JSON)](../../json/json-resetreputation.md) document.</span></span>
 

```cpp
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
      
```

   
<a id="ID4EOE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="da8cc-145">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da8cc-145">HTTP status codes</span></span>
 
<span data-ttu-id="da8cc-146">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="da8cc-146">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="da8cc-147">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="da8cc-147">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="da8cc-148">コード</span><span class="sxs-lookup"><span data-stu-id="da8cc-148">Code</span></span>| <span data-ttu-id="da8cc-149">理由語句</span><span class="sxs-lookup"><span data-stu-id="da8cc-149">Reason phrase</span></span>| <span data-ttu-id="da8cc-150">説明</span><span class="sxs-lookup"><span data-stu-id="da8cc-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="da8cc-151">200</span><span class="sxs-lookup"><span data-stu-id="da8cc-151">200</span></span>| <span data-ttu-id="da8cc-152">OK</span><span class="sxs-lookup"><span data-stu-id="da8cc-152">OK</span></span>| <span data-ttu-id="da8cc-153">OK。</span><span class="sxs-lookup"><span data-stu-id="da8cc-153">OK.</span></span>| 
| <span data-ttu-id="da8cc-154">400</span><span class="sxs-lookup"><span data-stu-id="da8cc-154">400</span></span>| <span data-ttu-id="da8cc-155">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="da8cc-155">Bad Request</span></span>| <span data-ttu-id="da8cc-156">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="da8cc-156">Service could not understand malformed request.</span></span> <span data-ttu-id="da8cc-157">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="da8cc-157">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="da8cc-158">401</span><span class="sxs-lookup"><span data-stu-id="da8cc-158">401</span></span>| <span data-ttu-id="da8cc-159">権限がありません</span><span class="sxs-lookup"><span data-stu-id="da8cc-159">Unauthorized</span></span>| <span data-ttu-id="da8cc-160">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="da8cc-160">The request requires user authentication.</span></span>| 
| <span data-ttu-id="da8cc-161">404</span><span class="sxs-lookup"><span data-stu-id="da8cc-161">404</span></span>| <span data-ttu-id="da8cc-162">検出不可</span><span class="sxs-lookup"><span data-stu-id="da8cc-162">Not Found</span></span>| <span data-ttu-id="da8cc-163">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="da8cc-163">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="da8cc-164">500</span><span class="sxs-lookup"><span data-stu-id="da8cc-164">500</span></span>| <span data-ttu-id="da8cc-165">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="da8cc-165">Internal Server Error</span></span>| <span data-ttu-id="da8cc-166">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="da8cc-166">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="da8cc-167">503</span><span class="sxs-lookup"><span data-stu-id="da8cc-167">503</span></span>| <span data-ttu-id="da8cc-168">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="da8cc-168">Service Unavailable</span></span>| <span data-ttu-id="da8cc-169">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="da8cc-169">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EQH"></a>

 
## <a name="response-body"></a><span data-ttu-id="da8cc-170">応答本文</span><span class="sxs-lookup"><span data-stu-id="da8cc-170">Response body</span></span>
 
<span data-ttu-id="da8cc-171">成功した場合、応答本文が空です。</span><span class="sxs-lookup"><span data-stu-id="da8cc-171">On success, the response body is empty.</span></span> <span data-ttu-id="da8cc-172">失敗した場合、[サービス エラー (JSON)](../../json/json-serviceerror.md)ドキュメントが返されます。</span><span class="sxs-lookup"><span data-stu-id="da8cc-172">On failure, a [ServiceError (JSON)](../../json/json-serviceerror.md) document is returned.</span></span>
 
<a id="ID4E3H"></a>

 
### <a name="sample-response"></a><span data-ttu-id="da8cc-173">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="da8cc-173">Sample response</span></span>
 

```cpp
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
         
```

   
<a id="ID4EHAAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="da8cc-174">関連項目</span><span class="sxs-lookup"><span data-stu-id="da8cc-174">See also</span></span>
 
<a id="ID4EJAAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="da8cc-175">Parent</span><span class="sxs-lookup"><span data-stu-id="da8cc-175">Parent</span></span> 

[<span data-ttu-id="da8cc-176">/users/xuid({xuid})/resetreputation</span><span class="sxs-lookup"><span data-stu-id="da8cc-176">/users/xuid({xuid})/resetreputation</span></span>](uri-usersxuidresetreputation.md)

   