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
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8752404"
---
# <a name="get-globalscidsscid"></a><span data-ttu-id="92f08-104">GET (/global/scids/{scid})</span><span class="sxs-lookup"><span data-stu-id="92f08-104">GET (/global/scids/{scid})</span></span>
<span data-ttu-id="92f08-105">このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="92f08-105">Retrieves quota information for this storage type.</span></span> <span data-ttu-id="92f08-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="92f08-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="92f08-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92f08-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="92f08-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="92f08-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="92f08-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="92f08-109">Required Request Headers</span></span>](#ID4ENB)
  * [<span data-ttu-id="92f08-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="92f08-110">Request body</span></span>](#ID4EWC)
  * [<span data-ttu-id="92f08-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="92f08-111">HTTP status codes</span></span>](#ID4EBD)
  * [<span data-ttu-id="92f08-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="92f08-112">Response body</span></span>](#ID4EUAAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="92f08-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92f08-113">URI parameters</span></span>
 
| <span data-ttu-id="92f08-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="92f08-114">Parameter</span></span>| <span data-ttu-id="92f08-115">型</span><span class="sxs-lookup"><span data-stu-id="92f08-115">Type</span></span>| <span data-ttu-id="92f08-116">説明</span><span class="sxs-lookup"><span data-stu-id="92f08-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="92f08-117">scid</span><span class="sxs-lookup"><span data-stu-id="92f08-117">scid</span></span>| <span data-ttu-id="92f08-118">guid</span><span class="sxs-lookup"><span data-stu-id="92f08-118">guid</span></span>| <span data-ttu-id="92f08-119">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="92f08-119">the ID of the service config to look up.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="92f08-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="92f08-120">Authorization</span></span>
 
<span data-ttu-id="92f08-121">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="92f08-121">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="92f08-122">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="92f08-122">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="92f08-123">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="92f08-123">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ENB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="92f08-124">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="92f08-124">Required Request Headers</span></span>
 
| <span data-ttu-id="92f08-125">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="92f08-125">Header</span></span>| <span data-ttu-id="92f08-126">設定値</span><span class="sxs-lookup"><span data-stu-id="92f08-126">Value</span></span>| <span data-ttu-id="92f08-127">説明</span><span class="sxs-lookup"><span data-stu-id="92f08-127">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="92f08-128">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="92f08-128">x-xbl-contract-version</span></span>| <span data-ttu-id="92f08-129">1</span><span class="sxs-lookup"><span data-stu-id="92f08-129">1</span></span>| <span data-ttu-id="92f08-130">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="92f08-130">API contract version.</span></span>| 
| <span data-ttu-id="92f08-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="92f08-131">Authorization</span></span>| <span data-ttu-id="92f08-132">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="92f08-132">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="92f08-133">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="92f08-133">STS authentication token.</span></span> <span data-ttu-id="92f08-134">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="92f08-134">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="92f08-135">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="92f08-135">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="request-body"></a><span data-ttu-id="92f08-136">要求本文</span><span class="sxs-lookup"><span data-stu-id="92f08-136">Request body</span></span>
 
<span data-ttu-id="92f08-137">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="92f08-137">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="92f08-138">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="92f08-138">HTTP status codes</span></span> 
 
<span data-ttu-id="92f08-139">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="92f08-139">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="92f08-140">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="92f08-140">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="92f08-141">コード</span><span class="sxs-lookup"><span data-stu-id="92f08-141">Code</span></span>| <span data-ttu-id="92f08-142">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="92f08-142">Reason phrase</span></span>| <span data-ttu-id="92f08-143">説明</span><span class="sxs-lookup"><span data-stu-id="92f08-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="92f08-144">200</span><span class="sxs-lookup"><span data-stu-id="92f08-144">200</span></span>| <span data-ttu-id="92f08-145">OK</span><span class="sxs-lookup"><span data-stu-id="92f08-145">OK</span></span> | <span data-ttu-id="92f08-146">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="92f08-146">The request was successful.</span></span>| 
| <span data-ttu-id="92f08-147">201</span><span class="sxs-lookup"><span data-stu-id="92f08-147">201</span></span>| <span data-ttu-id="92f08-148">Created</span><span class="sxs-lookup"><span data-stu-id="92f08-148">Created</span></span> | <span data-ttu-id="92f08-149">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="92f08-149">The entity was created.</span></span>| 
| <span data-ttu-id="92f08-150">400</span><span class="sxs-lookup"><span data-stu-id="92f08-150">400</span></span>| <span data-ttu-id="92f08-151">Bad Request</span><span class="sxs-lookup"><span data-stu-id="92f08-151">Bad Request</span></span> | <span data-ttu-id="92f08-152">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="92f08-152">Service could not understand malformed request.</span></span> <span data-ttu-id="92f08-153">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="92f08-153">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="92f08-154">401</span><span class="sxs-lookup"><span data-stu-id="92f08-154">401</span></span>| <span data-ttu-id="92f08-155">権限がありません</span><span class="sxs-lookup"><span data-stu-id="92f08-155">Unauthorized</span></span> | <span data-ttu-id="92f08-156">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="92f08-156">The request requires user authentication.</span></span>| 
| <span data-ttu-id="92f08-157">403</span><span class="sxs-lookup"><span data-stu-id="92f08-157">403</span></span>| <span data-ttu-id="92f08-158">Forbidden</span><span class="sxs-lookup"><span data-stu-id="92f08-158">Forbidden</span></span> | <span data-ttu-id="92f08-159">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="92f08-159">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="92f08-160">404</span><span class="sxs-lookup"><span data-stu-id="92f08-160">404</span></span>| <span data-ttu-id="92f08-161">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="92f08-161">Not Found</span></span> | <span data-ttu-id="92f08-162">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="92f08-162">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="92f08-163">406</span><span class="sxs-lookup"><span data-stu-id="92f08-163">406</span></span>| <span data-ttu-id="92f08-164">許容できません。</span><span class="sxs-lookup"><span data-stu-id="92f08-164">Not Acceptable</span></span> | <span data-ttu-id="92f08-165">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="92f08-165">Resource version is not supported.</span></span>| 
| <span data-ttu-id="92f08-166">408</span><span class="sxs-lookup"><span data-stu-id="92f08-166">408</span></span>| <span data-ttu-id="92f08-167">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="92f08-167">Request Timeout</span></span> | <span data-ttu-id="92f08-168">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="92f08-168">The request took too long to complete.</span></span>| 
| <span data-ttu-id="92f08-169">500</span><span class="sxs-lookup"><span data-stu-id="92f08-169">500</span></span>| <span data-ttu-id="92f08-170">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="92f08-170">Internal Server Error</span></span> | <span data-ttu-id="92f08-171">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="92f08-171">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="92f08-172">503</span><span class="sxs-lookup"><span data-stu-id="92f08-172">503</span></span>| <span data-ttu-id="92f08-173">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="92f08-173">Service Unavailable</span></span> | <span data-ttu-id="92f08-174">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="92f08-174">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="92f08-175">応答本文</span><span class="sxs-lookup"><span data-stu-id="92f08-175">Response body</span></span>
 
<span data-ttu-id="92f08-176">呼び出しが成功した場合は、サービスは[quotaInfo](../../json/json-quota.md)オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="92f08-176">If the call is successful, the service will return a [quotaInfo](../../json/json-quota.md) object.</span></span> 
 
<a id="ID4ECBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="92f08-177">応答の例</span><span class="sxs-lookup"><span data-stu-id="92f08-177">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="92f08-178">関連項目</span><span class="sxs-lookup"><span data-stu-id="92f08-178">See also</span></span>
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="92f08-179">Parent</span><span class="sxs-lookup"><span data-stu-id="92f08-179">Parent</span></span> 

[<span data-ttu-id="92f08-180">/global/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="92f08-180">/global/scids/{scid}</span></span>](uri-globalscidsscid.md)

  
<a id="ID4E1BAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="92f08-181">リファレンス</span><span class="sxs-lookup"><span data-stu-id="92f08-181">Reference</span></span> 

[<span data-ttu-id="92f08-182">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="92f08-182">quotaInfo (JSON)</span></span>](../../json/json-quota.md)

   