---
title: GET (/untrustedplatform/users/xuid({xuid})/scids/{scid})
assetID: ef295295-fee1-b247-2a45-3accf2816fd2
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersxuidscidsscid-get.html
description: " GET (/untrustedplatform/users/xuid({xuid})/scids/{scid})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 50b91334b184114cd86e07574142768d63f747f9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618127"
---
# <a name="get-untrustedplatformusersxuidxuidscidsscid"></a><span data-ttu-id="0816f-104">GET (/untrustedplatform/users/xuid({xuid})/scids/{scid})</span><span class="sxs-lookup"><span data-stu-id="0816f-104">GET (/untrustedplatform/users/xuid({xuid})/scids/{scid})</span></span>
<span data-ttu-id="0816f-105">このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="0816f-105">Retrieves quota information for this storage type.</span></span> <span data-ttu-id="0816f-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="0816f-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="0816f-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0816f-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="0816f-108">承認</span><span class="sxs-lookup"><span data-stu-id="0816f-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="0816f-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0816f-109">Required Request Headers</span></span>](#ID4ENB)
  * [<span data-ttu-id="0816f-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="0816f-110">Request body</span></span>](#ID4EWC)
  * [<span data-ttu-id="0816f-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="0816f-111">HTTP status codes</span></span>](#ID4EBD)
  * [<span data-ttu-id="0816f-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="0816f-112">Response body</span></span>](#ID4EUAAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0816f-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0816f-113">URI parameters</span></span>
 
| <span data-ttu-id="0816f-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0816f-114">Parameter</span></span>| <span data-ttu-id="0816f-115">種類</span><span class="sxs-lookup"><span data-stu-id="0816f-115">Type</span></span>| <span data-ttu-id="0816f-116">説明</span><span class="sxs-lookup"><span data-stu-id="0816f-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0816f-117">xuid</span><span class="sxs-lookup"><span data-stu-id="0816f-117">xuid</span></span>| <span data-ttu-id="0816f-118">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="0816f-118">unsigned 64-bit integer</span></span>| <span data-ttu-id="0816f-119">Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。</span><span class="sxs-lookup"><span data-stu-id="0816f-119">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="0816f-120">scid</span><span class="sxs-lookup"><span data-stu-id="0816f-120">scid</span></span>| <span data-ttu-id="0816f-121">guid</span><span class="sxs-lookup"><span data-stu-id="0816f-121">guid</span></span>| <span data-ttu-id="0816f-122">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="0816f-122">the ID of the service config to look up.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="0816f-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="0816f-123">Authorization</span></span>
 
<span data-ttu-id="0816f-124">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="0816f-124">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="0816f-125">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="0816f-125">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="0816f-126">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="0816f-126">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ENB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="0816f-127">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0816f-127">Required Request Headers</span></span>
 
| <span data-ttu-id="0816f-128">Header</span><span class="sxs-lookup"><span data-stu-id="0816f-128">Header</span></span>| <span data-ttu-id="0816f-129">Value</span><span class="sxs-lookup"><span data-stu-id="0816f-129">Value</span></span>| <span data-ttu-id="0816f-130">説明</span><span class="sxs-lookup"><span data-stu-id="0816f-130">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0816f-131">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="0816f-131">x-xbl-contract-version</span></span>| <span data-ttu-id="0816f-132">1</span><span class="sxs-lookup"><span data-stu-id="0816f-132">1</span></span>| <span data-ttu-id="0816f-133">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="0816f-133">API contract version.</span></span>| 
| <span data-ttu-id="0816f-134">Authorization</span><span class="sxs-lookup"><span data-stu-id="0816f-134">Authorization</span></span>| <span data-ttu-id="0816f-135">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="0816f-135">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="0816f-136">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="0816f-136">STS authentication token.</span></span> <span data-ttu-id="0816f-137">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="0816f-137">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="0816f-138">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0816f-138">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="request-body"></a><span data-ttu-id="0816f-139">要求本文</span><span class="sxs-lookup"><span data-stu-id="0816f-139">Request body</span></span>
 
<span data-ttu-id="0816f-140">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="0816f-140">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="0816f-141">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="0816f-141">HTTP status codes</span></span> 
 
<span data-ttu-id="0816f-142">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="0816f-142">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="0816f-143">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="0816f-143">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="0816f-144">コード</span><span class="sxs-lookup"><span data-stu-id="0816f-144">Code</span></span>| <span data-ttu-id="0816f-145">理由語句</span><span class="sxs-lookup"><span data-stu-id="0816f-145">Reason phrase</span></span>| <span data-ttu-id="0816f-146">説明</span><span class="sxs-lookup"><span data-stu-id="0816f-146">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0816f-147">200</span><span class="sxs-lookup"><span data-stu-id="0816f-147">200</span></span>| <span data-ttu-id="0816f-148">OK</span><span class="sxs-lookup"><span data-stu-id="0816f-148">OK</span></span> | <span data-ttu-id="0816f-149">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="0816f-149">The request was successful.</span></span>| 
| <span data-ttu-id="0816f-150">201</span><span class="sxs-lookup"><span data-stu-id="0816f-150">201</span></span>| <span data-ttu-id="0816f-151">作成日</span><span class="sxs-lookup"><span data-stu-id="0816f-151">Created</span></span> | <span data-ttu-id="0816f-152">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="0816f-152">The entity was created.</span></span>| 
| <span data-ttu-id="0816f-153">400</span><span class="sxs-lookup"><span data-stu-id="0816f-153">400</span></span>| <span data-ttu-id="0816f-154">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="0816f-154">Bad Request</span></span> | <span data-ttu-id="0816f-155">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="0816f-155">Service could not understand malformed request.</span></span> <span data-ttu-id="0816f-156">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="0816f-156">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="0816f-157">401</span><span class="sxs-lookup"><span data-stu-id="0816f-157">401</span></span>| <span data-ttu-id="0816f-158">権限がありません</span><span class="sxs-lookup"><span data-stu-id="0816f-158">Unauthorized</span></span> | <span data-ttu-id="0816f-159">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="0816f-159">The request requires user authentication.</span></span>| 
| <span data-ttu-id="0816f-160">403</span><span class="sxs-lookup"><span data-stu-id="0816f-160">403</span></span>| <span data-ttu-id="0816f-161">Forbidden</span><span class="sxs-lookup"><span data-stu-id="0816f-161">Forbidden</span></span> | <span data-ttu-id="0816f-162">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="0816f-162">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="0816f-163">404</span><span class="sxs-lookup"><span data-stu-id="0816f-163">404</span></span>| <span data-ttu-id="0816f-164">検出不可</span><span class="sxs-lookup"><span data-stu-id="0816f-164">Not Found</span></span> | <span data-ttu-id="0816f-165">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="0816f-165">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="0816f-166">406</span><span class="sxs-lookup"><span data-stu-id="0816f-166">406</span></span>| <span data-ttu-id="0816f-167">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="0816f-167">Not Acceptable</span></span> | <span data-ttu-id="0816f-168">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0816f-168">Resource version is not supported.</span></span>| 
| <span data-ttu-id="0816f-169">408</span><span class="sxs-lookup"><span data-stu-id="0816f-169">408</span></span>| <span data-ttu-id="0816f-170">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="0816f-170">Request Timeout</span></span> | <span data-ttu-id="0816f-171">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="0816f-171">The request took too long to complete.</span></span>| 
| <span data-ttu-id="0816f-172">500</span><span class="sxs-lookup"><span data-stu-id="0816f-172">500</span></span>| <span data-ttu-id="0816f-173">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="0816f-173">Internal Server Error</span></span> | <span data-ttu-id="0816f-174">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="0816f-174">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="0816f-175">503</span><span class="sxs-lookup"><span data-stu-id="0816f-175">503</span></span>| <span data-ttu-id="0816f-176">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="0816f-176">Service Unavailable</span></span> | <span data-ttu-id="0816f-177">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="0816f-177">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="0816f-178">応答本文</span><span class="sxs-lookup"><span data-stu-id="0816f-178">Response body</span></span>
 
<span data-ttu-id="0816f-179">呼び出しが成功したサービスを返します、 [quotaInfo](../../json/json-quota.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="0816f-179">If the call is successful, the service will return a [quotaInfo](../../json/json-quota.md) object.</span></span>
 
<a id="ID4ECBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="0816f-180">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="0816f-180">Sample response</span></span>
 

```cpp
{
  "quotaInfo" :
  {
    "usedBytes" : 619,
    "quotaBytes" : 16777216
  }
}
         
```

   
<a id="ID4EOBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="0816f-181">関連項目</span><span class="sxs-lookup"><span data-stu-id="0816f-181">See also</span></span>
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="0816f-182">Parent</span><span class="sxs-lookup"><span data-stu-id="0816f-182">Parent</span></span> 

[<span data-ttu-id="0816f-183">/untrustedplatform/users/xuid({xuid})/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="0816f-183">/untrustedplatform/users/xuid({xuid})/scids/{scid}</span></span>](uri-untrustedplatformusersxuidscidsscid.md)

  
<a id="ID4E1BAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="0816f-184">リファレンス</span><span class="sxs-lookup"><span data-stu-id="0816f-184">Reference</span></span> 

[<span data-ttu-id="0816f-185">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="0816f-185">quotaInfo (JSON)</span></span>](../../json/json-quota.md)

   