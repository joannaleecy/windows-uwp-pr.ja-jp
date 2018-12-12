---
title: GET (/global/scids/{scid}/data/{path})
assetID: 838abdf2-6fe3-cd7a-4356-6fb0b25a505b
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapath-get.html
description: " GET (/global/scids/{scid}/data/{path})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a242041566f2d493f178b139734327c477cad9d7
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8931362"
---
# <a name="get-globalscidssciddatapath"></a><span data-ttu-id="9d4c6-104">GET (/global/scids/{scid}/data/{path})</span><span class="sxs-lookup"><span data-stu-id="9d4c6-104">GET (/global/scids/{scid}/data/{path})</span></span>
<span data-ttu-id="9d4c6-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-105">Lists file information at a specified path.</span></span> <span data-ttu-id="9d4c6-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="9d4c6-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d4c6-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="9d4c6-108">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d4c6-108">Optional Query String Parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="9d4c6-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="9d4c6-109">Authorization</span></span>](#ID4EWC)
  * [<span data-ttu-id="9d4c6-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9d4c6-110">Required Request Headers</span></span>](#ID4EDD)
  * [<span data-ttu-id="9d4c6-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="9d4c6-111">Request body</span></span>](#ID4EME)
  * [<span data-ttu-id="9d4c6-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="9d4c6-112">HTTP status codes</span></span>](#ID4EZE)
  * [<span data-ttu-id="9d4c6-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="9d4c6-113">Response body</span></span>](#ID4EMCAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9d4c6-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d4c6-114">URI parameters</span></span>
 
| <span data-ttu-id="9d4c6-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d4c6-115">Parameter</span></span>| <span data-ttu-id="9d4c6-116">型</span><span class="sxs-lookup"><span data-stu-id="9d4c6-116">Type</span></span>| <span data-ttu-id="9d4c6-117">説明</span><span class="sxs-lookup"><span data-stu-id="9d4c6-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9d4c6-118">scid</span><span class="sxs-lookup"><span data-stu-id="9d4c6-118">scid</span></span>| <span data-ttu-id="9d4c6-119">guid</span><span class="sxs-lookup"><span data-stu-id="9d4c6-119">guid</span></span>| <span data-ttu-id="9d4c6-120">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-120">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="9d4c6-121">path</span><span class="sxs-lookup"><span data-stu-id="9d4c6-121">path</span></span>| <span data-ttu-id="9d4c6-122">string</span><span class="sxs-lookup"><span data-stu-id="9d4c6-122">string</span></span>| <span data-ttu-id="9d4c6-123">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-123">The path to the data items to return.</span></span> <span data-ttu-id="9d4c6-124">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-124">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="9d4c6-125">有効な文字には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-125">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="9d4c6-126">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-126">May be empty.</span></span> <span data-ttu-id="9d4c6-127">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-127">Max length of 256.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="9d4c6-128">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d4c6-128">Optional Query String Parameters</span></span> 
 
| <span data-ttu-id="9d4c6-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d4c6-129">Parameter</span></span>| <span data-ttu-id="9d4c6-130">型</span><span class="sxs-lookup"><span data-stu-id="9d4c6-130">Type</span></span>| <span data-ttu-id="9d4c6-131">説明</span><span class="sxs-lookup"><span data-stu-id="9d4c6-131">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="9d4c6-132">skipItems</span><span class="sxs-lookup"><span data-stu-id="9d4c6-132">skipItems</span></span>| <span data-ttu-id="9d4c6-133">int</span><span class="sxs-lookup"><span data-stu-id="9d4c6-133">int</span></span>| <span data-ttu-id="9d4c6-134">N 個の項目をスキップする n+1、コレクションから項目を返します。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-134">Return the items starting at N+1 in the collection, for example, skip N items.</span></span>| 
| <span data-ttu-id="9d4c6-135">continuationToken</span><span class="sxs-lookup"><span data-stu-id="9d4c6-135">continuationToken</span></span>| <span data-ttu-id="9d4c6-136">string</span><span class="sxs-lookup"><span data-stu-id="9d4c6-136">string</span></span>| <span data-ttu-id="9d4c6-137">特定の継続トークンで始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-137">Return the items starting at the given continuation token.</span></span> <span data-ttu-id="9d4c6-138">ContinuationToken パラメーターは skipItems より優先される場合、両方が提供されます。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-138">The continuationToken parameter takes precedence over skipItems if both are provided.</span></span> <span data-ttu-id="9d4c6-139">つまり、continuationToken パラメーターが存在する場合、skipItems パラメーターは無視されます。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-139">In other words, the skipItems parameter is ignored if continuationToken parameter is present.</span></span>| 
| <span data-ttu-id="9d4c6-140">maxItems</span><span class="sxs-lookup"><span data-stu-id="9d4c6-140">maxItems</span></span>| <span data-ttu-id="9d4c6-141">int</span><span class="sxs-lookup"><span data-stu-id="9d4c6-141">int</span></span>| <span data-ttu-id="9d4c6-142">SkipItems と項目の範囲を返す continuationToken と組み合わせることができるコレクションから返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-142">Maximum number of items to return from the collection, which can be combined with skipItems and continuationToken to return a range of items.</span></span> <span data-ttu-id="9d4c6-143">サービスに結果の最後のページが返されていない場合でもは maxItems が存在しないと、maxItems よりも少ないを返す可能性がある場合、既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-143">The service may provide a default value if maxItems is not present, and may return fewer than maxItems, even if the last page of results has not yet been returned.</span></span> | 
  
<a id="ID4EWC"></a>

 
## <a name="authorization"></a><span data-ttu-id="9d4c6-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="9d4c6-144">Authorization</span></span> 
 
<span data-ttu-id="9d4c6-145">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-145">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="9d4c6-146">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-146">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="9d4c6-147">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-147">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EDD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="9d4c6-148">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9d4c6-148">Required Request Headers</span></span>
 
| <span data-ttu-id="9d4c6-149">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9d4c6-149">Header</span></span>| <span data-ttu-id="9d4c6-150">設定値</span><span class="sxs-lookup"><span data-stu-id="9d4c6-150">Value</span></span>| <span data-ttu-id="9d4c6-151">説明</span><span class="sxs-lookup"><span data-stu-id="9d4c6-151">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="9d4c6-152">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="9d4c6-152">x-xbl-contract-version</span></span>| <span data-ttu-id="9d4c6-153">1</span><span class="sxs-lookup"><span data-stu-id="9d4c6-153">1</span></span>| <span data-ttu-id="9d4c6-154">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-154">API contract version.</span></span>| 
| <span data-ttu-id="9d4c6-155">Authorization</span><span class="sxs-lookup"><span data-stu-id="9d4c6-155">Authorization</span></span>| <span data-ttu-id="9d4c6-156">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="9d4c6-156">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="9d4c6-157">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-157">STS authentication token.</span></span> <span data-ttu-id="9d4c6-158">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-158">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="9d4c6-159">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-159">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EME"></a>

 
## <a name="request-body"></a><span data-ttu-id="9d4c6-160">要求本文</span><span class="sxs-lookup"><span data-stu-id="9d4c6-160">Request body</span></span> 
 
<span data-ttu-id="9d4c6-161">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-161">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EZE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="9d4c6-162">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="9d4c6-162">HTTP status codes</span></span> 
 
<span data-ttu-id="9d4c6-163">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-163">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="9d4c6-164">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-164">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="9d4c6-165">コード</span><span class="sxs-lookup"><span data-stu-id="9d4c6-165">Code</span></span>| <span data-ttu-id="9d4c6-166">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="9d4c6-166">Reason phrase</span></span>| <span data-ttu-id="9d4c6-167">説明</span><span class="sxs-lookup"><span data-stu-id="9d4c6-167">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="9d4c6-168">200</span><span class="sxs-lookup"><span data-stu-id="9d4c6-168">200</span></span>| <span data-ttu-id="9d4c6-169">OK</span><span class="sxs-lookup"><span data-stu-id="9d4c6-169">OK</span></span> | <span data-ttu-id="9d4c6-170">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-170">The request was successful.</span></span>| 
| <span data-ttu-id="9d4c6-171">201</span><span class="sxs-lookup"><span data-stu-id="9d4c6-171">201</span></span>| <span data-ttu-id="9d4c6-172">Created</span><span class="sxs-lookup"><span data-stu-id="9d4c6-172">Created</span></span> | <span data-ttu-id="9d4c6-173">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-173">The entity was created.</span></span>| 
| <span data-ttu-id="9d4c6-174">400</span><span class="sxs-lookup"><span data-stu-id="9d4c6-174">400</span></span>| <span data-ttu-id="9d4c6-175">Bad Request</span><span class="sxs-lookup"><span data-stu-id="9d4c6-175">Bad Request</span></span> | <span data-ttu-id="9d4c6-176">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-176">Service could not understand malformed request.</span></span> <span data-ttu-id="9d4c6-177">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-177">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="9d4c6-178">401</span><span class="sxs-lookup"><span data-stu-id="9d4c6-178">401</span></span>| <span data-ttu-id="9d4c6-179">権限がありません</span><span class="sxs-lookup"><span data-stu-id="9d4c6-179">Unauthorized</span></span> | <span data-ttu-id="9d4c6-180">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-180">The request requires user authentication.</span></span>| 
| <span data-ttu-id="9d4c6-181">403</span><span class="sxs-lookup"><span data-stu-id="9d4c6-181">403</span></span>| <span data-ttu-id="9d4c6-182">Forbidden</span><span class="sxs-lookup"><span data-stu-id="9d4c6-182">Forbidden</span></span> | <span data-ttu-id="9d4c6-183">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-183">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="9d4c6-184">404</span><span class="sxs-lookup"><span data-stu-id="9d4c6-184">404</span></span>| <span data-ttu-id="9d4c6-185">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-185">Not Found</span></span> | <span data-ttu-id="9d4c6-186">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-186">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="9d4c6-187">406</span><span class="sxs-lookup"><span data-stu-id="9d4c6-187">406</span></span>| <span data-ttu-id="9d4c6-188">許容できません。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-188">Not Acceptable</span></span> | <span data-ttu-id="9d4c6-189">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-189">Resource version is not supported.</span></span>| 
| <span data-ttu-id="9d4c6-190">408</span><span class="sxs-lookup"><span data-stu-id="9d4c6-190">408</span></span>| <span data-ttu-id="9d4c6-191">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="9d4c6-191">Request Timeout</span></span> | <span data-ttu-id="9d4c6-192">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-192">The request took too long to complete.</span></span>| 
| <span data-ttu-id="9d4c6-193">500</span><span class="sxs-lookup"><span data-stu-id="9d4c6-193">500</span></span>| <span data-ttu-id="9d4c6-194">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="9d4c6-194">Internal Server Error</span></span> | <span data-ttu-id="9d4c6-195">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-195">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="9d4c6-196">503</span><span class="sxs-lookup"><span data-stu-id="9d4c6-196">503</span></span>| <span data-ttu-id="9d4c6-197">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="9d4c6-197">Service Unavailable</span></span> | <span data-ttu-id="9d4c6-198">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-198">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="9d4c6-199">応答本文</span><span class="sxs-lookup"><span data-stu-id="9d4c6-199">Response body</span></span>
 
<span data-ttu-id="9d4c6-200">呼び出しが成功した場合は、サービスは[TitleBlob](../../json/json-titleblob.md)オブジェクトの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="9d4c6-200">If the call is successful, the service will return an array of [TitleBlob](../../json/json-titleblob.md) objects.</span></span> 
 
<a id="ID4E1CAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="9d4c6-201">応答の例</span><span class="sxs-lookup"><span data-stu-id="9d4c6-201">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="9d4c6-202">関連項目</span><span class="sxs-lookup"><span data-stu-id="9d4c6-202">See also</span></span>
 
<a id="ID4EIDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9d4c6-203">Parent</span><span class="sxs-lookup"><span data-stu-id="9d4c6-203">Parent</span></span>  

[<span data-ttu-id="9d4c6-204">/global/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="9d4c6-204">/global/scids/{scid}/data/{path}</span></span>](uri-globalscidssciddatapath.md)

  
<a id="ID4EUDAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="9d4c6-205">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="9d4c6-205">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

 [<span data-ttu-id="9d4c6-206">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="9d4c6-206">PagingInfo (JSON)</span></span>](../../json/json-paginginfo.md)

   