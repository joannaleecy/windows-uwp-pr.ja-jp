---
title: GET (/global/scids/{scid})
assetID: 7c8cd028-e94a-45e1-fe34-c9deae2d6042
permalink: en-us/docs/xboxlive/rest/uri-globalscidsscid-get.html
author: KevinAsgari
description: " GET (/global/scids/{scid})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1b6bf357ccfd6b835dff0e54eb2d6d34f81ba291
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5993043"
---
# <a name="get-globalscidsscid"></a><span data-ttu-id="f4259-104">GET (/global/scids/{scid})</span><span class="sxs-lookup"><span data-stu-id="f4259-104">GET (/global/scids/{scid})</span></span>
<span data-ttu-id="f4259-105">このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="f4259-105">Retrieves quota information for this storage type.</span></span> <span data-ttu-id="f4259-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f4259-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f4259-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f4259-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="f4259-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="f4259-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="f4259-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f4259-109">Required Request Headers</span></span>](#ID4ENB)
  * [<span data-ttu-id="f4259-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="f4259-110">Request body</span></span>](#ID4EWC)
  * [<span data-ttu-id="f4259-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="f4259-111">HTTP status codes</span></span>](#ID4EBD)
  * [<span data-ttu-id="f4259-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="f4259-112">Response body</span></span>](#ID4EUAAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f4259-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f4259-113">URI parameters</span></span>
 
| <span data-ttu-id="f4259-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f4259-114">Parameter</span></span>| <span data-ttu-id="f4259-115">型</span><span class="sxs-lookup"><span data-stu-id="f4259-115">Type</span></span>| <span data-ttu-id="f4259-116">説明</span><span class="sxs-lookup"><span data-stu-id="f4259-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f4259-117">scid</span><span class="sxs-lookup"><span data-stu-id="f4259-117">scid</span></span>| <span data-ttu-id="f4259-118">guid</span><span class="sxs-lookup"><span data-stu-id="f4259-118">guid</span></span>| <span data-ttu-id="f4259-119">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="f4259-119">the ID of the service config to look up.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="f4259-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="f4259-120">Authorization</span></span>
 
<span data-ttu-id="f4259-121">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4259-121">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="f4259-122">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="f4259-122">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="f4259-123">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="f4259-123">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ENB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="f4259-124">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f4259-124">Required Request Headers</span></span>
 
| <span data-ttu-id="f4259-125">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f4259-125">Header</span></span>| <span data-ttu-id="f4259-126">設定値</span><span class="sxs-lookup"><span data-stu-id="f4259-126">Value</span></span>| <span data-ttu-id="f4259-127">説明</span><span class="sxs-lookup"><span data-stu-id="f4259-127">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4259-128">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="f4259-128">x-xbl-contract-version</span></span>| <span data-ttu-id="f4259-129">1</span><span class="sxs-lookup"><span data-stu-id="f4259-129">1</span></span>| <span data-ttu-id="f4259-130">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="f4259-130">API contract version.</span></span>| 
| <span data-ttu-id="f4259-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="f4259-131">Authorization</span></span>| <span data-ttu-id="f4259-132">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="f4259-132">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="f4259-133">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="f4259-133">STS authentication token.</span></span> <span data-ttu-id="f4259-134">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="f4259-134">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="f4259-135">STS トークンを取得して、承認ヘッダーの作成について詳しくは、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f4259-135">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="request-body"></a><span data-ttu-id="f4259-136">要求本文</span><span class="sxs-lookup"><span data-stu-id="f4259-136">Request body</span></span>
 
<span data-ttu-id="f4259-137">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="f4259-137">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="f4259-138">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="f4259-138">HTTP status codes</span></span> 
 
<span data-ttu-id="f4259-139">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="f4259-139">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="f4259-140">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f4259-140">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="f4259-141">コード</span><span class="sxs-lookup"><span data-stu-id="f4259-141">Code</span></span>| <span data-ttu-id="f4259-142">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="f4259-142">Reason phrase</span></span>| <span data-ttu-id="f4259-143">説明</span><span class="sxs-lookup"><span data-stu-id="f4259-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f4259-144">200</span><span class="sxs-lookup"><span data-stu-id="f4259-144">200</span></span>| <span data-ttu-id="f4259-145">OK</span><span class="sxs-lookup"><span data-stu-id="f4259-145">OK</span></span> | <span data-ttu-id="f4259-146">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="f4259-146">The request was successful.</span></span>| 
| <span data-ttu-id="f4259-147">201</span><span class="sxs-lookup"><span data-stu-id="f4259-147">201</span></span>| <span data-ttu-id="f4259-148">Created</span><span class="sxs-lookup"><span data-stu-id="f4259-148">Created</span></span> | <span data-ttu-id="f4259-149">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="f4259-149">The entity was created.</span></span>| 
| <span data-ttu-id="f4259-150">400</span><span class="sxs-lookup"><span data-stu-id="f4259-150">400</span></span>| <span data-ttu-id="f4259-151">Bad Request</span><span class="sxs-lookup"><span data-stu-id="f4259-151">Bad Request</span></span> | <span data-ttu-id="f4259-152">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f4259-152">Service could not understand malformed request.</span></span> <span data-ttu-id="f4259-153">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="f4259-153">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="f4259-154">401</span><span class="sxs-lookup"><span data-stu-id="f4259-154">401</span></span>| <span data-ttu-id="f4259-155">権限がありません</span><span class="sxs-lookup"><span data-stu-id="f4259-155">Unauthorized</span></span> | <span data-ttu-id="f4259-156">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="f4259-156">The request requires user authentication.</span></span>| 
| <span data-ttu-id="f4259-157">403</span><span class="sxs-lookup"><span data-stu-id="f4259-157">403</span></span>| <span data-ttu-id="f4259-158">Forbidden</span><span class="sxs-lookup"><span data-stu-id="f4259-158">Forbidden</span></span> | <span data-ttu-id="f4259-159">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f4259-159">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="f4259-160">404</span><span class="sxs-lookup"><span data-stu-id="f4259-160">404</span></span>| <span data-ttu-id="f4259-161">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="f4259-161">Not Found</span></span> | <span data-ttu-id="f4259-162">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="f4259-162">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="f4259-163">406</span><span class="sxs-lookup"><span data-stu-id="f4259-163">406</span></span>| <span data-ttu-id="f4259-164">許容できません。</span><span class="sxs-lookup"><span data-stu-id="f4259-164">Not Acceptable</span></span> | <span data-ttu-id="f4259-165">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="f4259-165">Resource version is not supported.</span></span>| 
| <span data-ttu-id="f4259-166">408</span><span class="sxs-lookup"><span data-stu-id="f4259-166">408</span></span>| <span data-ttu-id="f4259-167">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="f4259-167">Request Timeout</span></span> | <span data-ttu-id="f4259-168">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="f4259-168">The request took too long to complete.</span></span>| 
| <span data-ttu-id="f4259-169">500</span><span class="sxs-lookup"><span data-stu-id="f4259-169">500</span></span>| <span data-ttu-id="f4259-170">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="f4259-170">Internal Server Error</span></span> | <span data-ttu-id="f4259-171">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="f4259-171">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="f4259-172">503</span><span class="sxs-lookup"><span data-stu-id="f4259-172">503</span></span>| <span data-ttu-id="f4259-173">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="f4259-173">Service Unavailable</span></span> | <span data-ttu-id="f4259-174">要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="f4259-174">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="f4259-175">応答本文</span><span class="sxs-lookup"><span data-stu-id="f4259-175">Response body</span></span>
 
<span data-ttu-id="f4259-176">呼び出しが成功した場合、サービスは[quotaInfo](../../json/json-quota.md)オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="f4259-176">If the call is successful, the service will return a [quotaInfo](../../json/json-quota.md) object.</span></span> 
 
<a id="ID4ECBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="f4259-177">応答の例</span><span class="sxs-lookup"><span data-stu-id="f4259-177">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="f4259-178">関連項目</span><span class="sxs-lookup"><span data-stu-id="f4259-178">See also</span></span>
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f4259-179">Parent</span><span class="sxs-lookup"><span data-stu-id="f4259-179">Parent</span></span> 

[<span data-ttu-id="f4259-180">/global/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="f4259-180">/global/scids/{scid}</span></span>](uri-globalscidsscid.md)

  
<a id="ID4E1BAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="f4259-181">リファレンス</span><span class="sxs-lookup"><span data-stu-id="f4259-181">Reference</span></span> 

[<span data-ttu-id="f4259-182">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="f4259-182">quotaInfo (JSON)</span></span>](../../json/json-quota.md)

   