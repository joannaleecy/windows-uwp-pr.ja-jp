---
title: GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path})
assetID: 0ab5de2f-35cd-1712-8c07-2049f5f27daf
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapath-get.html
author: KevinAsgari
description: " GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d6f1da02f7a5020a7e6bd9d71e7473ed64dd1fa4
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5478734"
---
# <a name="get-trustedplatformusersxuidxuidscidssciddatapath"></a><span data-ttu-id="90a2a-104">GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path})</span><span class="sxs-lookup"><span data-stu-id="90a2a-104">GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path})</span></span>
<span data-ttu-id="90a2a-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="90a2a-105">Lists file information at a specified path.</span></span> <span data-ttu-id="90a2a-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="90a2a-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="90a2a-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90a2a-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="90a2a-108">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="90a2a-108">Optional Query String Parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="90a2a-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="90a2a-109">Authorization</span></span>](#ID4EWC)
  * [<span data-ttu-id="90a2a-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90a2a-110">Required Request Headers</span></span>](#ID4EDD)
  * [<span data-ttu-id="90a2a-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="90a2a-111">Request body</span></span>](#ID4EME)
  * [<span data-ttu-id="90a2a-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="90a2a-112">HTTP status codes</span></span>](#ID4EZE)
  * [<span data-ttu-id="90a2a-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="90a2a-113">Response body</span></span>](#ID4EMCAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="90a2a-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90a2a-114">URI parameters</span></span>
 
| <span data-ttu-id="90a2a-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="90a2a-115">Parameter</span></span>| <span data-ttu-id="90a2a-116">型</span><span class="sxs-lookup"><span data-stu-id="90a2a-116">Type</span></span>| <span data-ttu-id="90a2a-117">説明</span><span class="sxs-lookup"><span data-stu-id="90a2a-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="90a2a-118">xuid</span><span class="sxs-lookup"><span data-stu-id="90a2a-118">xuid</span></span>| <span data-ttu-id="90a2a-119">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="90a2a-119">unsigned 64-bit integer</span></span>| <span data-ttu-id="90a2a-120">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="90a2a-120">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="90a2a-121">scid</span><span class="sxs-lookup"><span data-stu-id="90a2a-121">scid</span></span>| <span data-ttu-id="90a2a-122">guid</span><span class="sxs-lookup"><span data-stu-id="90a2a-122">guid</span></span>| <span data-ttu-id="90a2a-123">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="90a2a-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="90a2a-124">path</span><span class="sxs-lookup"><span data-stu-id="90a2a-124">path</span></span>| <span data-ttu-id="90a2a-125">string</span><span class="sxs-lookup"><span data-stu-id="90a2a-125">string</span></span>| <span data-ttu-id="90a2a-126">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="90a2a-126">The path to the data items to return.</span></span> <span data-ttu-id="90a2a-127">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="90a2a-127">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="90a2a-128">有効な文字には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="90a2a-128">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="90a2a-129">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="90a2a-129">May be empty.</span></span> <span data-ttu-id="90a2a-130">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="90a2a-130">Max length of 256.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="90a2a-131">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="90a2a-131">Optional Query String Parameters</span></span> 
 
| <span data-ttu-id="90a2a-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="90a2a-132">Parameter</span></span>| <span data-ttu-id="90a2a-133">型</span><span class="sxs-lookup"><span data-stu-id="90a2a-133">Type</span></span>| <span data-ttu-id="90a2a-134">説明</span><span class="sxs-lookup"><span data-stu-id="90a2a-134">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90a2a-135">skipItems</span><span class="sxs-lookup"><span data-stu-id="90a2a-135">skipItems</span></span>| <span data-ttu-id="90a2a-136">int</span><span class="sxs-lookup"><span data-stu-id="90a2a-136">int</span></span>| <span data-ttu-id="90a2a-137">N 個の項目をスキップする n+1、コレクションから項目を返します。</span><span class="sxs-lookup"><span data-stu-id="90a2a-137">Return the items starting at N+1 in the collection, for example, skip N items.</span></span>| 
| <span data-ttu-id="90a2a-138">continuationToken</span><span class="sxs-lookup"><span data-stu-id="90a2a-138">continuationToken</span></span>| <span data-ttu-id="90a2a-139">string</span><span class="sxs-lookup"><span data-stu-id="90a2a-139">string</span></span>| <span data-ttu-id="90a2a-140">特定の継続トークンから始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="90a2a-140">Return the items starting at the given continuation token.</span></span> <span data-ttu-id="90a2a-141">ContinuationToken パラメーターよりも優先 skipItems 場合は両方が提供されます。</span><span class="sxs-lookup"><span data-stu-id="90a2a-141">The continuationToken parameter takes precedence over skipItems if both are provided.</span></span> <span data-ttu-id="90a2a-142">つまり、continuationToken パラメーターが存在する場合、skipItems パラメーターは無視されます。</span><span class="sxs-lookup"><span data-stu-id="90a2a-142">In other words, the skipItems parameter is ignored if continuationToken parameter is present.</span></span>| 
| <span data-ttu-id="90a2a-143">maxItems</span><span class="sxs-lookup"><span data-stu-id="90a2a-143">maxItems</span></span>| <span data-ttu-id="90a2a-144">int</span><span class="sxs-lookup"><span data-stu-id="90a2a-144">int</span></span>| <span data-ttu-id="90a2a-145">SkipItems と項目の範囲を返す continuationToken と組み合わせることができるコレクションから返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="90a2a-145">Maximum number of items to return from the collection, which can be combined with skipItems and continuationToken to return a range of items.</span></span> <span data-ttu-id="90a2a-146">サービスに結果の最後のページが返されていない場合でもは maxItems が存在しないと、maxItems よりも少ないを返す可能性がある場合、既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="90a2a-146">The service may provide a default value if maxItems is not present, and may return fewer than maxItems, even if the last page of results has not yet been returned.</span></span> | 
  
<a id="ID4EWC"></a>

 
## <a name="authorization"></a><span data-ttu-id="90a2a-147">Authorization</span><span class="sxs-lookup"><span data-stu-id="90a2a-147">Authorization</span></span> 
 
<span data-ttu-id="90a2a-148">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="90a2a-148">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="90a2a-149">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="90a2a-149">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="90a2a-150">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="90a2a-150">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EDD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="90a2a-151">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90a2a-151">Required Request Headers</span></span>
 
| <span data-ttu-id="90a2a-152">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="90a2a-152">Header</span></span>| <span data-ttu-id="90a2a-153">設定値</span><span class="sxs-lookup"><span data-stu-id="90a2a-153">Value</span></span>| <span data-ttu-id="90a2a-154">説明</span><span class="sxs-lookup"><span data-stu-id="90a2a-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90a2a-155">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="90a2a-155">x-xbl-contract-version</span></span>| <span data-ttu-id="90a2a-156">1</span><span class="sxs-lookup"><span data-stu-id="90a2a-156">1</span></span>| <span data-ttu-id="90a2a-157">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="90a2a-157">API contract version.</span></span>| 
| <span data-ttu-id="90a2a-158">Authorization</span><span class="sxs-lookup"><span data-stu-id="90a2a-158">Authorization</span></span>| <span data-ttu-id="90a2a-159">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="90a2a-159">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="90a2a-160">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="90a2a-160">STS authentication token.</span></span> <span data-ttu-id="90a2a-161">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="90a2a-161">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="90a2a-162">STS トークンを取得して、承認ヘッダーの作成について詳しくは、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90a2a-162">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EME"></a>

 
## <a name="request-body"></a><span data-ttu-id="90a2a-163">要求本文</span><span class="sxs-lookup"><span data-stu-id="90a2a-163">Request body</span></span> 
 
<span data-ttu-id="90a2a-164">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="90a2a-164">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EZE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="90a2a-165">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="90a2a-165">HTTP status codes</span></span> 
 
<span data-ttu-id="90a2a-166">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="90a2a-166">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="90a2a-167">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90a2a-167">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="90a2a-168">コード</span><span class="sxs-lookup"><span data-stu-id="90a2a-168">Code</span></span>| <span data-ttu-id="90a2a-169">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="90a2a-169">Reason phrase</span></span>| <span data-ttu-id="90a2a-170">説明</span><span class="sxs-lookup"><span data-stu-id="90a2a-170">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="90a2a-171">200</span><span class="sxs-lookup"><span data-stu-id="90a2a-171">200</span></span>| <span data-ttu-id="90a2a-172">OK</span><span class="sxs-lookup"><span data-stu-id="90a2a-172">OK</span></span> | <span data-ttu-id="90a2a-173">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="90a2a-173">The request was successful.</span></span>| 
| <span data-ttu-id="90a2a-174">201</span><span class="sxs-lookup"><span data-stu-id="90a2a-174">201</span></span>| <span data-ttu-id="90a2a-175">Created</span><span class="sxs-lookup"><span data-stu-id="90a2a-175">Created</span></span> | <span data-ttu-id="90a2a-176">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="90a2a-176">The entity was created.</span></span>| 
| <span data-ttu-id="90a2a-177">400</span><span class="sxs-lookup"><span data-stu-id="90a2a-177">400</span></span>| <span data-ttu-id="90a2a-178">Bad Request</span><span class="sxs-lookup"><span data-stu-id="90a2a-178">Bad Request</span></span> | <span data-ttu-id="90a2a-179">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="90a2a-179">Service could not understand malformed request.</span></span> <span data-ttu-id="90a2a-180">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="90a2a-180">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="90a2a-181">401</span><span class="sxs-lookup"><span data-stu-id="90a2a-181">401</span></span>| <span data-ttu-id="90a2a-182">権限がありません</span><span class="sxs-lookup"><span data-stu-id="90a2a-182">Unauthorized</span></span> | <span data-ttu-id="90a2a-183">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="90a2a-183">The request requires user authentication.</span></span>| 
| <span data-ttu-id="90a2a-184">403</span><span class="sxs-lookup"><span data-stu-id="90a2a-184">403</span></span>| <span data-ttu-id="90a2a-185">Forbidden</span><span class="sxs-lookup"><span data-stu-id="90a2a-185">Forbidden</span></span> | <span data-ttu-id="90a2a-186">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="90a2a-186">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="90a2a-187">404</span><span class="sxs-lookup"><span data-stu-id="90a2a-187">404</span></span>| <span data-ttu-id="90a2a-188">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="90a2a-188">Not Found</span></span> | <span data-ttu-id="90a2a-189">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="90a2a-189">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="90a2a-190">406</span><span class="sxs-lookup"><span data-stu-id="90a2a-190">406</span></span>| <span data-ttu-id="90a2a-191">許容できません。</span><span class="sxs-lookup"><span data-stu-id="90a2a-191">Not Acceptable</span></span> | <span data-ttu-id="90a2a-192">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="90a2a-192">Resource version is not supported.</span></span>| 
| <span data-ttu-id="90a2a-193">408</span><span class="sxs-lookup"><span data-stu-id="90a2a-193">408</span></span>| <span data-ttu-id="90a2a-194">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="90a2a-194">Request Timeout</span></span> | <span data-ttu-id="90a2a-195">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="90a2a-195">The request took too long to complete.</span></span>| 
| <span data-ttu-id="90a2a-196">500</span><span class="sxs-lookup"><span data-stu-id="90a2a-196">500</span></span>| <span data-ttu-id="90a2a-197">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="90a2a-197">Internal Server Error</span></span> | <span data-ttu-id="90a2a-198">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="90a2a-198">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="90a2a-199">503</span><span class="sxs-lookup"><span data-stu-id="90a2a-199">503</span></span>| <span data-ttu-id="90a2a-200">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="90a2a-200">Service Unavailable</span></span> | <span data-ttu-id="90a2a-201">要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="90a2a-201">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="90a2a-202">応答本文</span><span class="sxs-lookup"><span data-stu-id="90a2a-202">Response body</span></span>
 
<span data-ttu-id="90a2a-203">呼び出しが成功した場合、サービスは[TitleBlob](../../json/json-titleblob.md)オブジェクトの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="90a2a-203">If the call is successful, the service will return an array of [TitleBlob](../../json/json-titleblob.md) objects.</span></span>
 
<a id="ID4E1CAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="90a2a-204">応答の例</span><span class="sxs-lookup"><span data-stu-id="90a2a-204">Sample response</span></span>
 

```cpp
{
"blobs":
[
    {
        "fileName":"foo\bar\blob.txt,binary",
        "clientFileTime":"2012-01-01T01:02:03.1234567Z",
        "displayName":"Friendly Name",
        "size":12,
        "etag":"0x8CEB3E4F8F3A5BF"
    },
    {
        "fileName":"foo\bar\blob2.txt,binary",
        "displayName":"Blob 2",
        "size":4,
        "etag":"0x8CEB3FE57F1A142"
    },
    {
        "fileName":"foo\jsonblob.txt,json",
        "size":15,
        "etag":"0x8CEB40152B4A6F8"
    }
],
"pagingInfo":
    {
        "continuationToken":"54",
    }
}
         
```

   
<a id="ID4EGDAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="90a2a-205">関連項目</span><span class="sxs-lookup"><span data-stu-id="90a2a-205">See also</span></span>
 
<a id="ID4EIDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="90a2a-206">Parent</span><span class="sxs-lookup"><span data-stu-id="90a2a-206">Parent</span></span>  

[<span data-ttu-id="90a2a-207">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="90a2a-207">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>](uri-trustedplatformusersxuidscidssciddatapath.md)

  
<a id="ID4EUDAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="90a2a-208">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="90a2a-208">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

 [<span data-ttu-id="90a2a-209">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="90a2a-209">PagingInfo (JSON)</span></span>](../../json/json-paginginfo.md)

   