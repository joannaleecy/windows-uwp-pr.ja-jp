---
title: GET (/sessions/{sessionId}/scids/{scid}/data/{path})
assetID: 007821b8-16f0-2fe1-5196-890743d77775
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapath-get.html
description: " GET (/sessions/{sessionId}/scids/{scid}/data/{path})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 28a279347fa5a463c0d482a624af831c0cdb0fba
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623717"
---
# <a name="get-sessionssessionidscidssciddatapath"></a><span data-ttu-id="52af2-104">GET (/sessions/{sessionId}/scids/{scid}/data/{path})</span><span class="sxs-lookup"><span data-stu-id="52af2-104">GET (/sessions/{sessionId}/scids/{scid}/data/{path})</span></span>
<span data-ttu-id="52af2-105">指定されたパスにファイル情報を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="52af2-105">Lists file information at a specified path.</span></span> <span data-ttu-id="52af2-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="52af2-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="52af2-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="52af2-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="52af2-108">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="52af2-108">Optional Query String Parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="52af2-109">承認</span><span class="sxs-lookup"><span data-stu-id="52af2-109">Authorization</span></span>](#ID4EWC)
  * [<span data-ttu-id="52af2-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="52af2-110">Required Request Headers</span></span>](#ID4EDD)
  * [<span data-ttu-id="52af2-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="52af2-111">Request body</span></span>](#ID4EME)
  * [<span data-ttu-id="52af2-112">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="52af2-112">HTTP status codes</span></span>](#ID4EZE)
  * [<span data-ttu-id="52af2-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="52af2-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="52af2-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="52af2-114">URI parameters</span></span>
 
| <span data-ttu-id="52af2-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="52af2-115">Parameter</span></span>| <span data-ttu-id="52af2-116">種類</span><span class="sxs-lookup"><span data-stu-id="52af2-116">Type</span></span>| <span data-ttu-id="52af2-117">説明</span><span class="sxs-lookup"><span data-stu-id="52af2-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="52af2-118">sessionId</span><span class="sxs-lookup"><span data-stu-id="52af2-118">sessionId</span></span>| <span data-ttu-id="52af2-119">string</span><span class="sxs-lookup"><span data-stu-id="52af2-119">string</span></span>| <span data-ttu-id="52af2-120">検索する、セッションの ID。</span><span class="sxs-lookup"><span data-stu-id="52af2-120">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="52af2-121">scid</span><span class="sxs-lookup"><span data-stu-id="52af2-121">scid</span></span>| <span data-ttu-id="52af2-122">guid</span><span class="sxs-lookup"><span data-stu-id="52af2-122">guid</span></span>| <span data-ttu-id="52af2-123">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="52af2-123">The ID of the service config to look up.</span></span>| 
| <span data-ttu-id="52af2-124">パス</span><span class="sxs-lookup"><span data-stu-id="52af2-124">path</span></span>| <span data-ttu-id="52af2-125">string</span><span class="sxs-lookup"><span data-stu-id="52af2-125">string</span></span>| <span data-ttu-id="52af2-126">返されるデータのアイテムへのパス。</span><span class="sxs-lookup"><span data-stu-id="52af2-126">The path to the data items to return.</span></span> <span data-ttu-id="52af2-127">一致するすべてのディレクトリとサブディレクトリが返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="52af2-127">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="52af2-128">有効な文字には、大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_) およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="52af2-128">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="52af2-129">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="52af2-129">May be empty.</span></span> <span data-ttu-id="52af2-130">最大長は 256 です。</span><span class="sxs-lookup"><span data-stu-id="52af2-130">Max length of 256.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="52af2-131">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="52af2-131">Optional Query String Parameters</span></span> 
 
| <span data-ttu-id="52af2-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="52af2-132">Parameter</span></span>| <span data-ttu-id="52af2-133">種類</span><span class="sxs-lookup"><span data-stu-id="52af2-133">Type</span></span>| <span data-ttu-id="52af2-134">説明</span><span class="sxs-lookup"><span data-stu-id="52af2-134">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="52af2-135">skipItems</span><span class="sxs-lookup"><span data-stu-id="52af2-135">skipItems</span></span>| <span data-ttu-id="52af2-136">int</span><span class="sxs-lookup"><span data-stu-id="52af2-136">int</span></span>| <span data-ttu-id="52af2-137">N 個の項目をスキップする、コレクション内の N + 1 で始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="52af2-137">Return the items starting at N+1 in the collection, for example, skip N items.</span></span>| 
| <span data-ttu-id="52af2-138">continuationToken</span><span class="sxs-lookup"><span data-stu-id="52af2-138">continuationToken</span></span>| <span data-ttu-id="52af2-139">string</span><span class="sxs-lookup"><span data-stu-id="52af2-139">string</span></span>| <span data-ttu-id="52af2-140">指定された継続トークンで始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="52af2-140">Return the items starting at the given continuation token.</span></span> <span data-ttu-id="52af2-141">ContinuationToken パラメーターよりも優先 skipItems 両方を指定しない場合。</span><span class="sxs-lookup"><span data-stu-id="52af2-141">The continuationToken parameter takes precedence over skipItems if both are provided.</span></span> <span data-ttu-id="52af2-142">つまり、skipItems パラメーターには、continuationToken パラメーターが存在する場合は無視されます。</span><span class="sxs-lookup"><span data-stu-id="52af2-142">In other words, the skipItems parameter is ignored if continuationToken parameter is present.</span></span>| 
| <span data-ttu-id="52af2-143">maxItems</span><span class="sxs-lookup"><span data-stu-id="52af2-143">maxItems</span></span>| <span data-ttu-id="52af2-144">int</span><span class="sxs-lookup"><span data-stu-id="52af2-144">int</span></span>| <span data-ttu-id="52af2-145">SkipItems と項目の範囲を取得するように continuationToken と組み合わせて使用できるコレクションから返されるアイテムの最大数。</span><span class="sxs-lookup"><span data-stu-id="52af2-145">Maximum number of items to return from the collection, which can be combined with skipItems and continuationToken to return a range of items.</span></span> <span data-ttu-id="52af2-146">MaxItems が存在しないと、maxItems、未満を返すことが場合の結果の最後のページが返されていない場合でも、サービスに、既定値であると指定可能性があります。</span><span class="sxs-lookup"><span data-stu-id="52af2-146">The service may provide a default value if maxItems is not present, and may return fewer than maxItems, even if the last page of results has not yet been returned.</span></span> | 
  
<a id="ID4EWC"></a>

 
## <a name="authorization"></a><span data-ttu-id="52af2-147">Authorization</span><span class="sxs-lookup"><span data-stu-id="52af2-147">Authorization</span></span> 
 
<span data-ttu-id="52af2-148">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="52af2-148">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="52af2-149">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="52af2-149">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="52af2-150">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="52af2-150">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EDD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="52af2-151">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="52af2-151">Required Request Headers</span></span>
 
| <span data-ttu-id="52af2-152">Header</span><span class="sxs-lookup"><span data-stu-id="52af2-152">Header</span></span>| <span data-ttu-id="52af2-153">Value</span><span class="sxs-lookup"><span data-stu-id="52af2-153">Value</span></span>| <span data-ttu-id="52af2-154">説明</span><span class="sxs-lookup"><span data-stu-id="52af2-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="52af2-155">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="52af2-155">x-xbl-contract-version</span></span>| <span data-ttu-id="52af2-156">1</span><span class="sxs-lookup"><span data-stu-id="52af2-156">1</span></span>| <span data-ttu-id="52af2-157">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="52af2-157">API contract version.</span></span>| 
| <span data-ttu-id="52af2-158">Authorization</span><span class="sxs-lookup"><span data-stu-id="52af2-158">Authorization</span></span>| <span data-ttu-id="52af2-159">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="52af2-159">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="52af2-160">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="52af2-160">STS authentication token.</span></span> <span data-ttu-id="52af2-161">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="52af2-161">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="52af2-162">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="52af2-162">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EME"></a>

 
## <a name="request-body"></a><span data-ttu-id="52af2-163">要求本文</span><span class="sxs-lookup"><span data-stu-id="52af2-163">Request body</span></span> 
 
<span data-ttu-id="52af2-164">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="52af2-164">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EZE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="52af2-165">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="52af2-165">HTTP status codes</span></span>
 
<span data-ttu-id="52af2-166">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="52af2-166">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="52af2-167">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="52af2-167">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="52af2-168">コード</span><span class="sxs-lookup"><span data-stu-id="52af2-168">Code</span></span>| <span data-ttu-id="52af2-169">理由語句</span><span class="sxs-lookup"><span data-stu-id="52af2-169">Reason phrase</span></span>| <span data-ttu-id="52af2-170">説明</span><span class="sxs-lookup"><span data-stu-id="52af2-170">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="52af2-171">200</span><span class="sxs-lookup"><span data-stu-id="52af2-171">200</span></span>| <span data-ttu-id="52af2-172">OK</span><span class="sxs-lookup"><span data-stu-id="52af2-172">OK</span></span>| <span data-ttu-id="52af2-173">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="52af2-173">The request was successful.</span></span>| 
| <span data-ttu-id="52af2-174">201</span><span class="sxs-lookup"><span data-stu-id="52af2-174">201</span></span>| <span data-ttu-id="52af2-175">作成日</span><span class="sxs-lookup"><span data-stu-id="52af2-175">Created</span></span>| <span data-ttu-id="52af2-176">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="52af2-176">The entity was created.</span></span>| 
| <span data-ttu-id="52af2-177">400</span><span class="sxs-lookup"><span data-stu-id="52af2-177">400</span></span>| <span data-ttu-id="52af2-178">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="52af2-178">Bad Request</span></span>| <span data-ttu-id="52af2-179">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="52af2-179">Service could not understand malformed request.</span></span> <span data-ttu-id="52af2-180">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="52af2-180">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="52af2-181">401</span><span class="sxs-lookup"><span data-stu-id="52af2-181">401</span></span>| <span data-ttu-id="52af2-182">権限がありません</span><span class="sxs-lookup"><span data-stu-id="52af2-182">Unauthorized</span></span>| <span data-ttu-id="52af2-183">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="52af2-183">The request requires user authentication.</span></span>| 
| <span data-ttu-id="52af2-184">403</span><span class="sxs-lookup"><span data-stu-id="52af2-184">403</span></span>| <span data-ttu-id="52af2-185">Forbidden</span><span class="sxs-lookup"><span data-stu-id="52af2-185">Forbidden</span></span>| <span data-ttu-id="52af2-186">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="52af2-186">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="52af2-187">404</span><span class="sxs-lookup"><span data-stu-id="52af2-187">404</span></span>| <span data-ttu-id="52af2-188">検出不可</span><span class="sxs-lookup"><span data-stu-id="52af2-188">Not Found</span></span>| <span data-ttu-id="52af2-189">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="52af2-189">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="52af2-190">406</span><span class="sxs-lookup"><span data-stu-id="52af2-190">406</span></span>| <span data-ttu-id="52af2-191">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="52af2-191">Not Acceptable</span></span>| <span data-ttu-id="52af2-192">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="52af2-192">Resource version is not supported.</span></span>| 
| <span data-ttu-id="52af2-193">408</span><span class="sxs-lookup"><span data-stu-id="52af2-193">408</span></span>| <span data-ttu-id="52af2-194">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="52af2-194">Request Timeout</span></span>| <span data-ttu-id="52af2-195">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="52af2-195">The request took too long to complete.</span></span>| 
| <span data-ttu-id="52af2-196">500</span><span class="sxs-lookup"><span data-stu-id="52af2-196">500</span></span>| <span data-ttu-id="52af2-197">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="52af2-197">Internal Server Error</span></span>| <span data-ttu-id="52af2-198">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="52af2-198">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="52af2-199">503</span><span class="sxs-lookup"><span data-stu-id="52af2-199">503</span></span>| <span data-ttu-id="52af2-200">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="52af2-200">Service Unavailable</span></span>| <span data-ttu-id="52af2-201">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="52af2-201">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="52af2-202">応答本文</span><span class="sxs-lookup"><span data-stu-id="52af2-202">Response body</span></span>
 
<span data-ttu-id="52af2-203">呼び出しが成功した場合、サービスは、の配列を返しますが[TitleBlob](../../json/json-titleblob.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="52af2-203">If the call is successful, the service will return an array of [TitleBlob](../../json/json-titleblob.md) objects.</span></span> 
 
<a id="ID4ECCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="52af2-204">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="52af2-204">Sample response</span></span>
 

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

   
<a id="ID4EOCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="52af2-205">関連項目</span><span class="sxs-lookup"><span data-stu-id="52af2-205">See also</span></span>
 
<a id="ID4EQCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="52af2-206">Parent</span><span class="sxs-lookup"><span data-stu-id="52af2-206">Parent</span></span>  

[<span data-ttu-id="52af2-207">/sessions/{sessionId}/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="52af2-207">/sessions/{sessionId}/scids/{scid}/data/{path}</span></span>](uri-sessionssessionidscidssciddatapath.md)

  
<a id="ID4E3CAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="52af2-208">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="52af2-208">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

 [<span data-ttu-id="52af2-209">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="52af2-209">PagingInfo (JSON)</span></span>](../../json/json-paginginfo.md)

   