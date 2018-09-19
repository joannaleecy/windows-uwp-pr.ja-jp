---
title: GET (/json/users/xuid({xuid})/scids/{scid})
assetID: a015fb75-f072-ee9b-000b-e6e93beed903
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidsscid-get.html
author: KevinAsgari
description: " GET (/json/users/xuid({xuid})/scids/{scid})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 05f9f09bd64658d2bef3f2c235177bd6053790ca
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4054033"
---
# <a name="get-jsonusersxuidxuidscidsscid"></a><span data-ttu-id="5ebbd-104">GET (/json/users/xuid({xuid})/scids/{scid})</span><span class="sxs-lookup"><span data-stu-id="5ebbd-104">GET (/json/users/xuid({xuid})/scids/{scid})</span></span>
<span data-ttu-id="5ebbd-105">このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-105">Retrieves quota information for this storage type.</span></span> <span data-ttu-id="5ebbd-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="5ebbd-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5ebbd-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="5ebbd-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="5ebbd-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="5ebbd-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5ebbd-109">Required Request Headers</span></span>](#ID4ENB)
  * [<span data-ttu-id="5ebbd-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="5ebbd-110">Request body</span></span>](#ID4EWC)
  * [<span data-ttu-id="5ebbd-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="5ebbd-111">HTTP status codes</span></span>](#ID4EBD)
  * [<span data-ttu-id="5ebbd-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="5ebbd-112">Response body</span></span>](#ID4EUAAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="5ebbd-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5ebbd-113">URI parameters</span></span>
 
| <span data-ttu-id="5ebbd-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5ebbd-114">Parameter</span></span>| <span data-ttu-id="5ebbd-115">型</span><span class="sxs-lookup"><span data-stu-id="5ebbd-115">Type</span></span>| <span data-ttu-id="5ebbd-116">説明</span><span class="sxs-lookup"><span data-stu-id="5ebbd-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5ebbd-117">xuid</span><span class="sxs-lookup"><span data-stu-id="5ebbd-117">xuid</span></span>| <span data-ttu-id="5ebbd-118">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="5ebbd-118">unsigned 64-bit integer</span></span>| <span data-ttu-id="5ebbd-119">Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-119">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="5ebbd-120">scid</span><span class="sxs-lookup"><span data-stu-id="5ebbd-120">scid</span></span>| <span data-ttu-id="5ebbd-121">guid</span><span class="sxs-lookup"><span data-stu-id="5ebbd-121">guid</span></span>| <span data-ttu-id="5ebbd-122">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-122">the ID of the service config to look up.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="5ebbd-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="5ebbd-123">Authorization</span></span>
 
<span data-ttu-id="5ebbd-124">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-124">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="5ebbd-125">呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは 403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-125">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="5ebbd-126">ヘッダーが見つからないか無効な場合は、サービスは、401 不正な応答を返します。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-126">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ENB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="5ebbd-127">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5ebbd-127">Required Request Headers</span></span>
 
| <span data-ttu-id="5ebbd-128">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5ebbd-128">Header</span></span>| <span data-ttu-id="5ebbd-129">設定値</span><span class="sxs-lookup"><span data-stu-id="5ebbd-129">Value</span></span>| <span data-ttu-id="5ebbd-130">説明</span><span class="sxs-lookup"><span data-stu-id="5ebbd-130">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="5ebbd-131">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="5ebbd-131">x-xbl-contract-version</span></span>| <span data-ttu-id="5ebbd-132">1</span><span class="sxs-lookup"><span data-stu-id="5ebbd-132">1</span></span>| <span data-ttu-id="5ebbd-133">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-133">API contract version.</span></span>| 
| <span data-ttu-id="5ebbd-134">Authorization</span><span class="sxs-lookup"><span data-stu-id="5ebbd-134">Authorization</span></span>| <span data-ttu-id="5ebbd-135">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="5ebbd-135">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="5ebbd-136">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-136">STS authentication token.</span></span> <span data-ttu-id="5ebbd-137">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-137">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="5ebbd-138">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-138">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="request-body"></a><span data-ttu-id="5ebbd-139">要求本文</span><span class="sxs-lookup"><span data-stu-id="5ebbd-139">Request body</span></span>
 
<span data-ttu-id="5ebbd-140">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-140">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="5ebbd-141">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="5ebbd-141">HTTP status codes</span></span> 
 
<span data-ttu-id="5ebbd-142">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-142">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="5ebbd-143">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-143">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="5ebbd-144">コード</span><span class="sxs-lookup"><span data-stu-id="5ebbd-144">Code</span></span>| <span data-ttu-id="5ebbd-145">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="5ebbd-145">Reason phrase</span></span>| <span data-ttu-id="5ebbd-146">説明</span><span class="sxs-lookup"><span data-stu-id="5ebbd-146">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="5ebbd-147">200</span><span class="sxs-lookup"><span data-stu-id="5ebbd-147">200</span></span>| <span data-ttu-id="5ebbd-148">OK</span><span class="sxs-lookup"><span data-stu-id="5ebbd-148">OK</span></span> | <span data-ttu-id="5ebbd-149">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-149">The request was successful.</span></span>| 
| <span data-ttu-id="5ebbd-150">201</span><span class="sxs-lookup"><span data-stu-id="5ebbd-150">201</span></span>| <span data-ttu-id="5ebbd-151">Created</span><span class="sxs-lookup"><span data-stu-id="5ebbd-151">Created</span></span> | <span data-ttu-id="5ebbd-152">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-152">The entity was created.</span></span>| 
| <span data-ttu-id="5ebbd-153">400</span><span class="sxs-lookup"><span data-stu-id="5ebbd-153">400</span></span>| <span data-ttu-id="5ebbd-154">Bad Request</span><span class="sxs-lookup"><span data-stu-id="5ebbd-154">Bad Request</span></span> | <span data-ttu-id="5ebbd-155">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-155">Service could not understand malformed request.</span></span> <span data-ttu-id="5ebbd-156">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-156">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="5ebbd-157">401</span><span class="sxs-lookup"><span data-stu-id="5ebbd-157">401</span></span>| <span data-ttu-id="5ebbd-158">権限がありません</span><span class="sxs-lookup"><span data-stu-id="5ebbd-158">Unauthorized</span></span> | <span data-ttu-id="5ebbd-159">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-159">The request requires user authentication.</span></span>| 
| <span data-ttu-id="5ebbd-160">403</span><span class="sxs-lookup"><span data-stu-id="5ebbd-160">403</span></span>| <span data-ttu-id="5ebbd-161">Forbidden</span><span class="sxs-lookup"><span data-stu-id="5ebbd-161">Forbidden</span></span> | <span data-ttu-id="5ebbd-162">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-162">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="5ebbd-163">404</span><span class="sxs-lookup"><span data-stu-id="5ebbd-163">404</span></span>| <span data-ttu-id="5ebbd-164">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-164">Not Found</span></span> | <span data-ttu-id="5ebbd-165">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-165">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="5ebbd-166">406</span><span class="sxs-lookup"><span data-stu-id="5ebbd-166">406</span></span>| <span data-ttu-id="5ebbd-167">許容できません。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-167">Not Acceptable</span></span> | <span data-ttu-id="5ebbd-168">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-168">Resource version is not supported.</span></span>| 
| <span data-ttu-id="5ebbd-169">408</span><span class="sxs-lookup"><span data-stu-id="5ebbd-169">408</span></span>| <span data-ttu-id="5ebbd-170">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="5ebbd-170">Request Timeout</span></span> | <span data-ttu-id="5ebbd-171">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-171">The request took too long to complete.</span></span>| 
| <span data-ttu-id="5ebbd-172">500</span><span class="sxs-lookup"><span data-stu-id="5ebbd-172">500</span></span>| <span data-ttu-id="5ebbd-173">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="5ebbd-173">Internal Server Error</span></span> | <span data-ttu-id="5ebbd-174">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-174">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="5ebbd-175">503</span><span class="sxs-lookup"><span data-stu-id="5ebbd-175">503</span></span>| <span data-ttu-id="5ebbd-176">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="5ebbd-176">Service Unavailable</span></span> | <span data-ttu-id="5ebbd-177">要求が調整された、クライアント再試行値 (例: 5 秒後) を秒単位で後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-177">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="5ebbd-178">応答本文</span><span class="sxs-lookup"><span data-stu-id="5ebbd-178">Response body</span></span>
 
<span data-ttu-id="5ebbd-179">呼び出しが成功した場合は、サービスは[quotaInfo](../../json/json-quota.md)オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="5ebbd-179">If the call is successful, the service will return a [quotaInfo](../../json/json-quota.md) object.</span></span> 
 
<a id="ID4ECBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="5ebbd-180">応答の例</span><span class="sxs-lookup"><span data-stu-id="5ebbd-180">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="5ebbd-181">関連項目</span><span class="sxs-lookup"><span data-stu-id="5ebbd-181">See also</span></span>
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5ebbd-182">Parent</span><span class="sxs-lookup"><span data-stu-id="5ebbd-182">Parent</span></span> 

[<span data-ttu-id="5ebbd-183">/json/users/xuid({xuid})/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="5ebbd-183">/json/users/xuid({xuid})/scids/{scid}</span></span>](uri-jsonusersxuidscidsscid.md)

  
<a id="ID4E1BAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="5ebbd-184">リファレンス</span><span class="sxs-lookup"><span data-stu-id="5ebbd-184">Reference</span></span> 

[<span data-ttu-id="5ebbd-185">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="5ebbd-185">quotaInfo (JSON)</span></span>](../../json/json-quota.md)

   