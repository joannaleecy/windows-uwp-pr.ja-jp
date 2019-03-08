---
title: GET (/global/scids/{scid})
assetID: 7c8cd028-e94a-45e1-fe34-c9deae2d6042
permalink: en-us/docs/xboxlive/rest/uri-globalscidsscid-get.html
description: " GET (/global/scids/{scid})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a91e13c33c02a34f844773e7a54ac55bf8e98338
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645977"
---
# <a name="get-globalscidsscid"></a><span data-ttu-id="f9f62-104">GET (/global/scids/{scid})</span><span class="sxs-lookup"><span data-stu-id="f9f62-104">GET (/global/scids/{scid})</span></span>
<span data-ttu-id="f9f62-105">このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="f9f62-105">Retrieves quota information for this storage type.</span></span> <span data-ttu-id="f9f62-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f9f62-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f9f62-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9f62-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="f9f62-108">承認</span><span class="sxs-lookup"><span data-stu-id="f9f62-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="f9f62-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9f62-109">Required Request Headers</span></span>](#ID4ENB)
  * [<span data-ttu-id="f9f62-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="f9f62-110">Request body</span></span>](#ID4EWC)
  * [<span data-ttu-id="f9f62-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f9f62-111">HTTP status codes</span></span>](#ID4EBD)
  * [<span data-ttu-id="f9f62-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="f9f62-112">Response body</span></span>](#ID4EUAAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f9f62-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9f62-113">URI parameters</span></span>
 
| <span data-ttu-id="f9f62-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9f62-114">Parameter</span></span>| <span data-ttu-id="f9f62-115">種類</span><span class="sxs-lookup"><span data-stu-id="f9f62-115">Type</span></span>| <span data-ttu-id="f9f62-116">説明</span><span class="sxs-lookup"><span data-stu-id="f9f62-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f9f62-117">scid</span><span class="sxs-lookup"><span data-stu-id="f9f62-117">scid</span></span>| <span data-ttu-id="f9f62-118">guid</span><span class="sxs-lookup"><span data-stu-id="f9f62-118">guid</span></span>| <span data-ttu-id="f9f62-119">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="f9f62-119">the ID of the service config to look up.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="f9f62-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="f9f62-120">Authorization</span></span>
 
<span data-ttu-id="f9f62-121">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9f62-121">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="f9f62-122">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="f9f62-122">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="f9f62-123">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="f9f62-123">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ENB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="f9f62-124">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9f62-124">Required Request Headers</span></span>
 
| <span data-ttu-id="f9f62-125">Header</span><span class="sxs-lookup"><span data-stu-id="f9f62-125">Header</span></span>| <span data-ttu-id="f9f62-126">Value</span><span class="sxs-lookup"><span data-stu-id="f9f62-126">Value</span></span>| <span data-ttu-id="f9f62-127">説明</span><span class="sxs-lookup"><span data-stu-id="f9f62-127">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f9f62-128">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="f9f62-128">x-xbl-contract-version</span></span>| <span data-ttu-id="f9f62-129">1</span><span class="sxs-lookup"><span data-stu-id="f9f62-129">1</span></span>| <span data-ttu-id="f9f62-130">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="f9f62-130">API contract version.</span></span>| 
| <span data-ttu-id="f9f62-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="f9f62-131">Authorization</span></span>| <span data-ttu-id="f9f62-132">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="f9f62-132">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="f9f62-133">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="f9f62-133">STS authentication token.</span></span> <span data-ttu-id="f9f62-134">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="f9f62-134">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="f9f62-135">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f9f62-135">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="request-body"></a><span data-ttu-id="f9f62-136">要求本文</span><span class="sxs-lookup"><span data-stu-id="f9f62-136">Request body</span></span>
 
<span data-ttu-id="f9f62-137">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="f9f62-137">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="f9f62-138">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f9f62-138">HTTP status codes</span></span> 
 
<span data-ttu-id="f9f62-139">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="f9f62-139">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="f9f62-140">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="f9f62-140">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="f9f62-141">コード</span><span class="sxs-lookup"><span data-stu-id="f9f62-141">Code</span></span>| <span data-ttu-id="f9f62-142">理由語句</span><span class="sxs-lookup"><span data-stu-id="f9f62-142">Reason phrase</span></span>| <span data-ttu-id="f9f62-143">説明</span><span class="sxs-lookup"><span data-stu-id="f9f62-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f9f62-144">200</span><span class="sxs-lookup"><span data-stu-id="f9f62-144">200</span></span>| <span data-ttu-id="f9f62-145">OK</span><span class="sxs-lookup"><span data-stu-id="f9f62-145">OK</span></span> | <span data-ttu-id="f9f62-146">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="f9f62-146">The request was successful.</span></span>| 
| <span data-ttu-id="f9f62-147">201</span><span class="sxs-lookup"><span data-stu-id="f9f62-147">201</span></span>| <span data-ttu-id="f9f62-148">作成日</span><span class="sxs-lookup"><span data-stu-id="f9f62-148">Created</span></span> | <span data-ttu-id="f9f62-149">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="f9f62-149">The entity was created.</span></span>| 
| <span data-ttu-id="f9f62-150">400</span><span class="sxs-lookup"><span data-stu-id="f9f62-150">400</span></span>| <span data-ttu-id="f9f62-151">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="f9f62-151">Bad Request</span></span> | <span data-ttu-id="f9f62-152">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="f9f62-152">Service could not understand malformed request.</span></span> <span data-ttu-id="f9f62-153">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="f9f62-153">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="f9f62-154">401</span><span class="sxs-lookup"><span data-stu-id="f9f62-154">401</span></span>| <span data-ttu-id="f9f62-155">権限がありません</span><span class="sxs-lookup"><span data-stu-id="f9f62-155">Unauthorized</span></span> | <span data-ttu-id="f9f62-156">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="f9f62-156">The request requires user authentication.</span></span>| 
| <span data-ttu-id="f9f62-157">403</span><span class="sxs-lookup"><span data-stu-id="f9f62-157">403</span></span>| <span data-ttu-id="f9f62-158">Forbidden</span><span class="sxs-lookup"><span data-stu-id="f9f62-158">Forbidden</span></span> | <span data-ttu-id="f9f62-159">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="f9f62-159">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="f9f62-160">404</span><span class="sxs-lookup"><span data-stu-id="f9f62-160">404</span></span>| <span data-ttu-id="f9f62-161">検出不可</span><span class="sxs-lookup"><span data-stu-id="f9f62-161">Not Found</span></span> | <span data-ttu-id="f9f62-162">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="f9f62-162">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="f9f62-163">406</span><span class="sxs-lookup"><span data-stu-id="f9f62-163">406</span></span>| <span data-ttu-id="f9f62-164">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="f9f62-164">Not Acceptable</span></span> | <span data-ttu-id="f9f62-165">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="f9f62-165">Resource version is not supported.</span></span>| 
| <span data-ttu-id="f9f62-166">408</span><span class="sxs-lookup"><span data-stu-id="f9f62-166">408</span></span>| <span data-ttu-id="f9f62-167">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="f9f62-167">Request Timeout</span></span> | <span data-ttu-id="f9f62-168">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="f9f62-168">The request took too long to complete.</span></span>| 
| <span data-ttu-id="f9f62-169">500</span><span class="sxs-lookup"><span data-stu-id="f9f62-169">500</span></span>| <span data-ttu-id="f9f62-170">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="f9f62-170">Internal Server Error</span></span> | <span data-ttu-id="f9f62-171">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="f9f62-171">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="f9f62-172">503</span><span class="sxs-lookup"><span data-stu-id="f9f62-172">503</span></span>| <span data-ttu-id="f9f62-173">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="f9f62-173">Service Unavailable</span></span> | <span data-ttu-id="f9f62-174">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="f9f62-174">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="f9f62-175">応答本文</span><span class="sxs-lookup"><span data-stu-id="f9f62-175">Response body</span></span>
 
<span data-ttu-id="f9f62-176">呼び出しが成功したサービスを返します、 [quotaInfo](../../json/json-quota.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f9f62-176">If the call is successful, the service will return a [quotaInfo](../../json/json-quota.md) object.</span></span> 
 
<a id="ID4ECBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="f9f62-177">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="f9f62-177">Sample response</span></span>
 

```cpp
{
  "quotaInfo":
  {
    "usedBytes":619,
    "quotaBytes":16777216
  }
}
         
```

   
<a id="ID4EOBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f9f62-178">関連項目</span><span class="sxs-lookup"><span data-stu-id="f9f62-178">See also</span></span>
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f9f62-179">Parent</span><span class="sxs-lookup"><span data-stu-id="f9f62-179">Parent</span></span> 

[<span data-ttu-id="f9f62-180">/global/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="f9f62-180">/global/scids/{scid}</span></span>](uri-globalscidsscid.md)

  
<a id="ID4E1BAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="f9f62-181">リファレンス</span><span class="sxs-lookup"><span data-stu-id="f9f62-181">Reference</span></span> 

[<span data-ttu-id="f9f62-182">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="f9f62-182">quotaInfo (JSON)</span></span>](../../json/json-quota.md)

   