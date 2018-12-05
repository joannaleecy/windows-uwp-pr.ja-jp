---
title: GET (/trustedplatform/users/xuid({xuid})/scids/{scid})
assetID: 29c8c12a-5d9f-89c1-a739-c600bad893c2
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidsscid-get.html
description: " GET (/trustedplatform/users/xuid({xuid})/scids/{scid})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8425d5349b57cac209e177a9d9c013e28a433647
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8713804"
---
# <a name="get-trustedplatformusersxuidxuidscidsscid"></a><span data-ttu-id="222d5-104">GET (/trustedplatform/users/xuid({xuid})/scids/{scid})</span><span class="sxs-lookup"><span data-stu-id="222d5-104">GET (/trustedplatform/users/xuid({xuid})/scids/{scid})</span></span>
<span data-ttu-id="222d5-105">このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="222d5-105">Retrieves quota information for this storage type.</span></span> <span data-ttu-id="222d5-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="222d5-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="222d5-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="222d5-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="222d5-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="222d5-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="222d5-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="222d5-109">Required Request Headers</span></span>](#ID4ENB)
  * [<span data-ttu-id="222d5-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="222d5-110">Request body</span></span>](#ID4EWC)
  * [<span data-ttu-id="222d5-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="222d5-111">HTTP status codes</span></span>](#ID4EBD)
  * [<span data-ttu-id="222d5-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="222d5-112">Response body</span></span>](#ID4EUAAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="222d5-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="222d5-113">URI parameters</span></span>
 
| <span data-ttu-id="222d5-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="222d5-114">Parameter</span></span>| <span data-ttu-id="222d5-115">型</span><span class="sxs-lookup"><span data-stu-id="222d5-115">Type</span></span>| <span data-ttu-id="222d5-116">説明</span><span class="sxs-lookup"><span data-stu-id="222d5-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="222d5-117">xuid</span><span class="sxs-lookup"><span data-stu-id="222d5-117">xuid</span></span>| <span data-ttu-id="222d5-118">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="222d5-118">unsigned 64-bit integer</span></span>| <span data-ttu-id="222d5-119">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="222d5-119">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="222d5-120">scid</span><span class="sxs-lookup"><span data-stu-id="222d5-120">scid</span></span>| <span data-ttu-id="222d5-121">guid</span><span class="sxs-lookup"><span data-stu-id="222d5-121">guid</span></span>| <span data-ttu-id="222d5-122">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="222d5-122">the ID of the service config to look up.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="222d5-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="222d5-123">Authorization</span></span>
 
<span data-ttu-id="222d5-124">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="222d5-124">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="222d5-125">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは 403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="222d5-125">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="222d5-126">ヘッダーが見つからないか無効な場合は、サービスは 401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="222d5-126">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ENB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="222d5-127">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="222d5-127">Required Request Headers</span></span>
 
| <span data-ttu-id="222d5-128">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="222d5-128">Header</span></span>| <span data-ttu-id="222d5-129">設定値</span><span class="sxs-lookup"><span data-stu-id="222d5-129">Value</span></span>| <span data-ttu-id="222d5-130">説明</span><span class="sxs-lookup"><span data-stu-id="222d5-130">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="222d5-131">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="222d5-131">x-xbl-contract-version</span></span>| <span data-ttu-id="222d5-132">1</span><span class="sxs-lookup"><span data-stu-id="222d5-132">1</span></span>| <span data-ttu-id="222d5-133">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="222d5-133">API contract version.</span></span>| 
| <span data-ttu-id="222d5-134">Authorization</span><span class="sxs-lookup"><span data-stu-id="222d5-134">Authorization</span></span>| <span data-ttu-id="222d5-135">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="222d5-135">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="222d5-136">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="222d5-136">STS authentication token.</span></span> <span data-ttu-id="222d5-137">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="222d5-137">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="222d5-138">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="222d5-138">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="request-body"></a><span data-ttu-id="222d5-139">要求本文</span><span class="sxs-lookup"><span data-stu-id="222d5-139">Request body</span></span>
 
<span data-ttu-id="222d5-140">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="222d5-140">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="222d5-141">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="222d5-141">HTTP status codes</span></span> 
 
<span data-ttu-id="222d5-142">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="222d5-142">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="222d5-143">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="222d5-143">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="222d5-144">コード</span><span class="sxs-lookup"><span data-stu-id="222d5-144">Code</span></span>| <span data-ttu-id="222d5-145">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="222d5-145">Reason phrase</span></span>| <span data-ttu-id="222d5-146">説明</span><span class="sxs-lookup"><span data-stu-id="222d5-146">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="222d5-147">200</span><span class="sxs-lookup"><span data-stu-id="222d5-147">200</span></span>| <span data-ttu-id="222d5-148">OK</span><span class="sxs-lookup"><span data-stu-id="222d5-148">OK</span></span> | <span data-ttu-id="222d5-149">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="222d5-149">The request was successful.</span></span>| 
| <span data-ttu-id="222d5-150">201</span><span class="sxs-lookup"><span data-stu-id="222d5-150">201</span></span>| <span data-ttu-id="222d5-151">Created</span><span class="sxs-lookup"><span data-stu-id="222d5-151">Created</span></span> | <span data-ttu-id="222d5-152">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="222d5-152">The entity was created.</span></span>| 
| <span data-ttu-id="222d5-153">400</span><span class="sxs-lookup"><span data-stu-id="222d5-153">400</span></span>| <span data-ttu-id="222d5-154">Bad Request</span><span class="sxs-lookup"><span data-stu-id="222d5-154">Bad Request</span></span> | <span data-ttu-id="222d5-155">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="222d5-155">Service could not understand malformed request.</span></span> <span data-ttu-id="222d5-156">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="222d5-156">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="222d5-157">401</span><span class="sxs-lookup"><span data-stu-id="222d5-157">401</span></span>| <span data-ttu-id="222d5-158">権限がありません</span><span class="sxs-lookup"><span data-stu-id="222d5-158">Unauthorized</span></span> | <span data-ttu-id="222d5-159">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="222d5-159">The request requires user authentication.</span></span>| 
| <span data-ttu-id="222d5-160">403</span><span class="sxs-lookup"><span data-stu-id="222d5-160">403</span></span>| <span data-ttu-id="222d5-161">Forbidden</span><span class="sxs-lookup"><span data-stu-id="222d5-161">Forbidden</span></span> | <span data-ttu-id="222d5-162">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="222d5-162">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="222d5-163">404</span><span class="sxs-lookup"><span data-stu-id="222d5-163">404</span></span>| <span data-ttu-id="222d5-164">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="222d5-164">Not Found</span></span> | <span data-ttu-id="222d5-165">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="222d5-165">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="222d5-166">406</span><span class="sxs-lookup"><span data-stu-id="222d5-166">406</span></span>| <span data-ttu-id="222d5-167">許容できません。</span><span class="sxs-lookup"><span data-stu-id="222d5-167">Not Acceptable</span></span> | <span data-ttu-id="222d5-168">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="222d5-168">Resource version is not supported.</span></span>| 
| <span data-ttu-id="222d5-169">408</span><span class="sxs-lookup"><span data-stu-id="222d5-169">408</span></span>| <span data-ttu-id="222d5-170">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="222d5-170">Request Timeout</span></span> | <span data-ttu-id="222d5-171">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="222d5-171">The request took too long to complete.</span></span>| 
| <span data-ttu-id="222d5-172">500</span><span class="sxs-lookup"><span data-stu-id="222d5-172">500</span></span>| <span data-ttu-id="222d5-173">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="222d5-173">Internal Server Error</span></span> | <span data-ttu-id="222d5-174">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="222d5-174">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="222d5-175">503</span><span class="sxs-lookup"><span data-stu-id="222d5-175">503</span></span>| <span data-ttu-id="222d5-176">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="222d5-176">Service Unavailable</span></span> | <span data-ttu-id="222d5-177">要求が調整された、秒 (例: 5 秒後) のクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="222d5-177">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="222d5-178">応答本文</span><span class="sxs-lookup"><span data-stu-id="222d5-178">Response body</span></span>
 
<span data-ttu-id="222d5-179">呼び出しが成功した場合は、サービスは[quotaInfo](../../json/json-quota.md)オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="222d5-179">If the call is successful, the service will return a [quotaInfo](../../json/json-quota.md) object.</span></span> 
 
<a id="ID4ECBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="222d5-180">応答の例</span><span class="sxs-lookup"><span data-stu-id="222d5-180">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="222d5-181">関連項目</span><span class="sxs-lookup"><span data-stu-id="222d5-181">See also</span></span>
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="222d5-182">Parent</span><span class="sxs-lookup"><span data-stu-id="222d5-182">Parent</span></span> 

[<span data-ttu-id="222d5-183">/trustedplatform/users/xuid({xuid})/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="222d5-183">/trustedplatform/users/xuid({xuid})/scids/{scid}</span></span>](uri-trustedplatformusersxuidscidsscid.md)

  
<a id="ID4E1BAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="222d5-184">リファレンス</span><span class="sxs-lookup"><span data-stu-id="222d5-184">Reference</span></span> 

[<span data-ttu-id="222d5-185">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="222d5-185">quotaInfo (JSON)</span></span>](../../json/json-quota.md)

   