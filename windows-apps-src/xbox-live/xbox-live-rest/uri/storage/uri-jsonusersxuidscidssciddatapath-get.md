---
title: GET (/json/users/xuid({xuid})/scids/{scid}/data/{path})
assetID: ab73c1af-d914-b498-6a12-8f74eec349d0
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapath-get.html
author: KevinAsgari
description: " GET (/json/users/xuid({xuid})/scids/{scid}/data/{path})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4ef285dfa79c47c9bd058d593c1102e581cbe460
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4618845"
---
# <a name="get-jsonusersxuidxuidscidssciddatapath"></a><span data-ttu-id="34b4f-104">GET (/json/users/xuid({xuid})/scids/{scid}/data/{path})</span><span class="sxs-lookup"><span data-stu-id="34b4f-104">GET (/json/users/xuid({xuid})/scids/{scid}/data/{path})</span></span>
<span data-ttu-id="34b4f-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="34b4f-105">Lists file information at a specified path.</span></span> <span data-ttu-id="34b4f-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="34b4f-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="34b4f-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="34b4f-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="34b4f-108">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="34b4f-108">Optional Query String Parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="34b4f-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="34b4f-109">Authorization</span></span>](#ID4EUC)
  * [<span data-ttu-id="34b4f-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34b4f-110">Required Request Headers</span></span>](#ID4EBD)
  * [<span data-ttu-id="34b4f-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="34b4f-111">Request body</span></span>](#ID4EKE)
  * [<span data-ttu-id="34b4f-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="34b4f-112">HTTP status codes</span></span>](#ID4EXE)
  * [<span data-ttu-id="34b4f-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="34b4f-113">Response body</span></span>](#ID4EKCAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="34b4f-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="34b4f-114">URI parameters</span></span>
 
| <span data-ttu-id="34b4f-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="34b4f-115">Parameter</span></span>| <span data-ttu-id="34b4f-116">型</span><span class="sxs-lookup"><span data-stu-id="34b4f-116">Type</span></span>| <span data-ttu-id="34b4f-117">説明</span><span class="sxs-lookup"><span data-stu-id="34b4f-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="34b4f-118">xuid</span><span class="sxs-lookup"><span data-stu-id="34b4f-118">xuid</span></span>| <span data-ttu-id="34b4f-119">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="34b4f-119">unsigned 64-bit integer</span></span>| <span data-ttu-id="34b4f-120">Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="34b4f-120">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="34b4f-121">scid</span><span class="sxs-lookup"><span data-stu-id="34b4f-121">scid</span></span>| <span data-ttu-id="34b4f-122">guid</span><span class="sxs-lookup"><span data-stu-id="34b4f-122">guid</span></span>| <span data-ttu-id="34b4f-123">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="34b4f-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="34b4f-124">path</span><span class="sxs-lookup"><span data-stu-id="34b4f-124">path</span></span>| <span data-ttu-id="34b4f-125">string</span><span class="sxs-lookup"><span data-stu-id="34b4f-125">string</span></span>| <span data-ttu-id="34b4f-126">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="34b4f-126">The path to the data items to return.</span></span> <span data-ttu-id="34b4f-127">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="34b4f-127">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="34b4f-128">有効な文字には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="34b4f-128">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="34b4f-129">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="34b4f-129">May be empty.</span></span> <span data-ttu-id="34b4f-130">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="34b4f-130">Max length of 256.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="34b4f-131">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="34b4f-131">Optional Query String Parameters</span></span> 
 
| <span data-ttu-id="34b4f-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="34b4f-132">Parameter</span></span>| <span data-ttu-id="34b4f-133">型</span><span class="sxs-lookup"><span data-stu-id="34b4f-133">Type</span></span>| <span data-ttu-id="34b4f-134">説明</span><span class="sxs-lookup"><span data-stu-id="34b4f-134">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="34b4f-135">skipItems</span><span class="sxs-lookup"><span data-stu-id="34b4f-135">skipItems</span></span>| <span data-ttu-id="34b4f-136">int</span><span class="sxs-lookup"><span data-stu-id="34b4f-136">int</span></span>| <span data-ttu-id="34b4f-137">N 個の項目をスキップする n+1、コレクションから項目を返します。</span><span class="sxs-lookup"><span data-stu-id="34b4f-137">Return the items starting at N+1 in the collection, for example, skip N items.</span></span>| 
| <span data-ttu-id="34b4f-138">continuationToken</span><span class="sxs-lookup"><span data-stu-id="34b4f-138">continuationToken</span></span>| <span data-ttu-id="34b4f-139">string</span><span class="sxs-lookup"><span data-stu-id="34b4f-139">string</span></span>| <span data-ttu-id="34b4f-140">特定の継続トークンから項目を返します。</span><span class="sxs-lookup"><span data-stu-id="34b4f-140">Return the items starting at the given continuation token.</span></span> <span data-ttu-id="34b4f-141">ContinuationToken パラメーターは skipItems より優先される場合は両方が提供されます。</span><span class="sxs-lookup"><span data-stu-id="34b4f-141">The continuationToken parameter takes precedence over skipItems if both are provided.</span></span> <span data-ttu-id="34b4f-142">つまり、continuationToken パラメーターが存在する場合、skipItems パラメーターは無視されます。</span><span class="sxs-lookup"><span data-stu-id="34b4f-142">In other words, the skipItems parameter is ignored if continuationToken parameter is present.</span></span>| 
| <span data-ttu-id="34b4f-143">maxItems</span><span class="sxs-lookup"><span data-stu-id="34b4f-143">maxItems</span></span>| <span data-ttu-id="34b4f-144">int</span><span class="sxs-lookup"><span data-stu-id="34b4f-144">int</span></span>| <span data-ttu-id="34b4f-145">SkipItems と項目の範囲を返す continuationToken と組み合わせることができるコレクションから返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="34b4f-145">Maximum number of items to return from the collection, which can be combined with skipItems and continuationToken to return a range of items.</span></span> <span data-ttu-id="34b4f-146">サービスに結果の最後のページが返されていない場合でもは maxItems が存在しないと、maxItems より少ないを返す可能性がある場合、既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="34b4f-146">The service may provide a default value if maxItems is not present, and may return fewer than maxItems, even if the last page of results has not yet been returned.</span></span> | 
  
<a id="ID4EUC"></a>

 
## <a name="authorization"></a><span data-ttu-id="34b4f-147">Authorization</span><span class="sxs-lookup"><span data-stu-id="34b4f-147">Authorization</span></span> 
 
<span data-ttu-id="34b4f-148">要求は、有効な Xbox LIVE の承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="34b4f-148">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="34b4f-149">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="34b4f-149">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="34b4f-150">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="34b4f-150">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EBD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="34b4f-151">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34b4f-151">Required Request Headers</span></span>
 
| <span data-ttu-id="34b4f-152">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34b4f-152">Header</span></span>| <span data-ttu-id="34b4f-153">設定値</span><span class="sxs-lookup"><span data-stu-id="34b4f-153">Value</span></span>| <span data-ttu-id="34b4f-154">説明</span><span class="sxs-lookup"><span data-stu-id="34b4f-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="34b4f-155">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="34b4f-155">x-xbl-contract-version</span></span>| <span data-ttu-id="34b4f-156">1</span><span class="sxs-lookup"><span data-stu-id="34b4f-156">1</span></span>| <span data-ttu-id="34b4f-157">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="34b4f-157">API contract version.</span></span>| 
| <span data-ttu-id="34b4f-158">Authorization</span><span class="sxs-lookup"><span data-stu-id="34b4f-158">Authorization</span></span>| <span data-ttu-id="34b4f-159">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="34b4f-159">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="34b4f-160">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="34b4f-160">STS authentication token.</span></span> <span data-ttu-id="34b4f-161">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="34b4f-161">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="34b4f-162">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="34b4f-162">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EKE"></a>

 
## <a name="request-body"></a><span data-ttu-id="34b4f-163">要求本文</span><span class="sxs-lookup"><span data-stu-id="34b4f-163">Request body</span></span> 
 
<span data-ttu-id="34b4f-164">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="34b4f-164">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EXE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="34b4f-165">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="34b4f-165">HTTP status codes</span></span> 
 
<span data-ttu-id="34b4f-166">サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="34b4f-166">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="34b4f-167">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="34b4f-167">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="34b4f-168">コード</span><span class="sxs-lookup"><span data-stu-id="34b4f-168">Code</span></span>| <span data-ttu-id="34b4f-169">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="34b4f-169">Reason phrase</span></span>| <span data-ttu-id="34b4f-170">説明</span><span class="sxs-lookup"><span data-stu-id="34b4f-170">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="34b4f-171">200</span><span class="sxs-lookup"><span data-stu-id="34b4f-171">200</span></span>| <span data-ttu-id="34b4f-172">OK</span><span class="sxs-lookup"><span data-stu-id="34b4f-172">OK</span></span> | <span data-ttu-id="34b4f-173">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="34b4f-173">The request was successful.</span></span>| 
| <span data-ttu-id="34b4f-174">201</span><span class="sxs-lookup"><span data-stu-id="34b4f-174">201</span></span>| <span data-ttu-id="34b4f-175">Created</span><span class="sxs-lookup"><span data-stu-id="34b4f-175">Created</span></span> | <span data-ttu-id="34b4f-176">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="34b4f-176">The entity was created.</span></span>| 
| <span data-ttu-id="34b4f-177">400</span><span class="sxs-lookup"><span data-stu-id="34b4f-177">400</span></span>| <span data-ttu-id="34b4f-178">Bad Request</span><span class="sxs-lookup"><span data-stu-id="34b4f-178">Bad Request</span></span> | <span data-ttu-id="34b4f-179">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="34b4f-179">Service could not understand malformed request.</span></span> <span data-ttu-id="34b4f-180">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="34b4f-180">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="34b4f-181">401</span><span class="sxs-lookup"><span data-stu-id="34b4f-181">401</span></span>| <span data-ttu-id="34b4f-182">権限がありません</span><span class="sxs-lookup"><span data-stu-id="34b4f-182">Unauthorized</span></span> | <span data-ttu-id="34b4f-183">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="34b4f-183">The request requires user authentication.</span></span>| 
| <span data-ttu-id="34b4f-184">403</span><span class="sxs-lookup"><span data-stu-id="34b4f-184">403</span></span>| <span data-ttu-id="34b4f-185">Forbidden</span><span class="sxs-lookup"><span data-stu-id="34b4f-185">Forbidden</span></span> | <span data-ttu-id="34b4f-186">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="34b4f-186">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="34b4f-187">404</span><span class="sxs-lookup"><span data-stu-id="34b4f-187">404</span></span>| <span data-ttu-id="34b4f-188">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="34b4f-188">Not Found</span></span> | <span data-ttu-id="34b4f-189">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="34b4f-189">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="34b4f-190">406</span><span class="sxs-lookup"><span data-stu-id="34b4f-190">406</span></span>| <span data-ttu-id="34b4f-191">許容できません。</span><span class="sxs-lookup"><span data-stu-id="34b4f-191">Not Acceptable</span></span> | <span data-ttu-id="34b4f-192">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="34b4f-192">Resource version is not supported.</span></span>| 
| <span data-ttu-id="34b4f-193">408</span><span class="sxs-lookup"><span data-stu-id="34b4f-193">408</span></span>| <span data-ttu-id="34b4f-194">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="34b4f-194">Request Timeout</span></span> | <span data-ttu-id="34b4f-195">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="34b4f-195">The request took too long to complete.</span></span>| 
| <span data-ttu-id="34b4f-196">500</span><span class="sxs-lookup"><span data-stu-id="34b4f-196">500</span></span>| <span data-ttu-id="34b4f-197">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="34b4f-197">Internal Server Error</span></span> | <span data-ttu-id="34b4f-198">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="34b4f-198">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="34b4f-199">503</span><span class="sxs-lookup"><span data-stu-id="34b4f-199">503</span></span>| <span data-ttu-id="34b4f-200">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="34b4f-200">Service Unavailable</span></span> | <span data-ttu-id="34b4f-201">要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="34b4f-201">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EKCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="34b4f-202">応答本文</span><span class="sxs-lookup"><span data-stu-id="34b4f-202">Response body</span></span>
 
<span data-ttu-id="34b4f-203">呼び出しが成功した場合は、サービスは[TitleBlob](../../json/json-titleblob.md)オブジェクトの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="34b4f-203">If the call is successful, the service will return an array of [TitleBlob](../../json/json-titleblob.md) objects.</span></span>
 
<a id="ID4EYCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="34b4f-204">応答の例</span><span class="sxs-lookup"><span data-stu-id="34b4f-204">Sample response</span></span>
 

```cpp
{
"blobs":
[
    {
        "fileName":"foo\bar\blob.txt,json",
        "clientFileTime":"2012-01-01T01:02:03.1234567Z",
        "displayName":"Friendly Name",
        "size":12,
        "etag":"0x8CEB3E4F8F3A5BF"
    },
    {
        "fileName":"foo\bar\blob2.txt,json",
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

   
<a id="ID4EEDAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="34b4f-205">関連項目</span><span class="sxs-lookup"><span data-stu-id="34b4f-205">See also</span></span>
 
<a id="ID4EGDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="34b4f-206">Parent</span><span class="sxs-lookup"><span data-stu-id="34b4f-206">Parent</span></span>  

[<span data-ttu-id="34b4f-207">/json/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="34b4f-207">/json/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>](uri-jsonusersxuidscidssciddatapath.md)

  
<a id="ID4ESDAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="34b4f-208">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="34b4f-208">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

 [<span data-ttu-id="34b4f-209">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="34b4f-209">PagingInfo (JSON)</span></span>](../../json/json-paginginfo.md)

   