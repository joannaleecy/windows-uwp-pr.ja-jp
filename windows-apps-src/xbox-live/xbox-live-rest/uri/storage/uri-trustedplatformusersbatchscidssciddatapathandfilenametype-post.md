---
title: POST (/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type})
assetID: 0c89b845-c40f-b28e-f102-d2a96f58dcf9
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersbatchscidssciddatapathandfilenametype-post.html
description: " POST (/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 504a73534b9ee536970caec1b5fd1ea6ce731b31
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650547"
---
# <a name="post-trustedplatformusersbatchscidssciddatapathandfilenametype"></a><span data-ttu-id="c9fe1-104">POST (/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="c9fe1-104">POST (/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="c9fe1-105">同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="c9fe1-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="c9fe1-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9fe1-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="c9fe1-108">承認</span><span class="sxs-lookup"><span data-stu-id="c9fe1-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="c9fe1-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="c9fe1-109">Request body</span></span>](#ID4EPB)
  * [<span data-ttu-id="c9fe1-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c9fe1-110">HTTP status codes</span></span>](#ID4E3C)
  * [<span data-ttu-id="c9fe1-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9fe1-111">Required Response Headers</span></span>](#ID4EPAAC)
  * [<span data-ttu-id="c9fe1-112">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9fe1-112">Optional Response Headers</span></span>](#ID4ESBAC)
  * [<span data-ttu-id="c9fe1-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="c9fe1-113">Response body</span></span>](#ID4E3CAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c9fe1-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9fe1-114">URI parameters</span></span>
 
| <span data-ttu-id="c9fe1-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9fe1-115">Parameter</span></span>| <span data-ttu-id="c9fe1-116">種類</span><span class="sxs-lookup"><span data-stu-id="c9fe1-116">Type</span></span>| <span data-ttu-id="c9fe1-117">説明</span><span class="sxs-lookup"><span data-stu-id="c9fe1-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c9fe1-118">scid</span><span class="sxs-lookup"><span data-stu-id="c9fe1-118">scid</span></span>| <span data-ttu-id="c9fe1-119">guid</span><span class="sxs-lookup"><span data-stu-id="c9fe1-119">guid</span></span>| <span data-ttu-id="c9fe1-120">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-120">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="c9fe1-121">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="c9fe1-121">pathAndFileName</span></span>| <span data-ttu-id="c9fe1-122">string</span><span class="sxs-lookup"><span data-stu-id="c9fe1-122">string</span></span>| <span data-ttu-id="c9fe1-123">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-123">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="c9fe1-124">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-124">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="c9fe1-125">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-125">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="c9fe1-126">type</span><span class="sxs-lookup"><span data-stu-id="c9fe1-126">type</span></span>| <span data-ttu-id="c9fe1-127">string</span><span class="sxs-lookup"><span data-stu-id="c9fe1-127">string</span></span>| <span data-ttu-id="c9fe1-128">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-128">The format of the data.</span></span> <span data-ttu-id="c9fe1-129">有効値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-129">Possible values are binary or json.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="c9fe1-130">Authorization</span><span class="sxs-lookup"><span data-stu-id="c9fe1-130">Authorization</span></span> 
 
<span data-ttu-id="c9fe1-131">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-131">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="c9fe1-132">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-132">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="c9fe1-133">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-133">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EPB"></a>

 
## <a name="request-body"></a><span data-ttu-id="c9fe1-134">要求本文</span><span class="sxs-lookup"><span data-stu-id="c9fe1-134">Request body</span></span>
 
| <span data-ttu-id="c9fe1-135">プロパティ</span><span class="sxs-lookup"><span data-stu-id="c9fe1-135">Property</span></span>| <span data-ttu-id="c9fe1-136">種類</span><span class="sxs-lookup"><span data-stu-id="c9fe1-136">Type</span></span>| <span data-ttu-id="c9fe1-137">説明</span><span class="sxs-lookup"><span data-stu-id="c9fe1-137">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c9fe1-138">xuid</span><span class="sxs-lookup"><span data-stu-id="c9fe1-138">xuids</span></span>| <span data-ttu-id="c9fe1-139">64 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="c9fe1-139">array of unsigned 64-bit integers</span></span>| <span data-ttu-id="c9fe1-140">ファイルをダウンロードする Xuid の一覧。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-140">The list of XUIDs for which to download files.</span></span>| 
 
<a id="ID4EQC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="c9fe1-141">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="c9fe1-141">Sample request</span></span>
 

```cpp
{
    "xuids" : 
    [
      12345,
      45678,
      78901
    ]
}
      
```

   
<a id="ID4E3C"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="c9fe1-142">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c9fe1-142">HTTP status codes</span></span> 
 
<span data-ttu-id="c9fe1-143">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-143">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="c9fe1-144">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-144">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="c9fe1-145">コード</span><span class="sxs-lookup"><span data-stu-id="c9fe1-145">Code</span></span>| <span data-ttu-id="c9fe1-146">理由語句</span><span class="sxs-lookup"><span data-stu-id="c9fe1-146">Reason phrase</span></span>| <span data-ttu-id="c9fe1-147">説明</span><span class="sxs-lookup"><span data-stu-id="c9fe1-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c9fe1-148">200</span><span class="sxs-lookup"><span data-stu-id="c9fe1-148">200</span></span>| <span data-ttu-id="c9fe1-149">OK</span><span class="sxs-lookup"><span data-stu-id="c9fe1-149">OK</span></span> | <span data-ttu-id="c9fe1-150">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-150">The request was successful.</span></span>| 
| <span data-ttu-id="c9fe1-151">201</span><span class="sxs-lookup"><span data-stu-id="c9fe1-151">201</span></span>| <span data-ttu-id="c9fe1-152">作成日</span><span class="sxs-lookup"><span data-stu-id="c9fe1-152">Created</span></span> | <span data-ttu-id="c9fe1-153">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-153">The entity was created.</span></span>| 
| <span data-ttu-id="c9fe1-154">400</span><span class="sxs-lookup"><span data-stu-id="c9fe1-154">400</span></span>| <span data-ttu-id="c9fe1-155">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="c9fe1-155">Bad Request</span></span> | <span data-ttu-id="c9fe1-156">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-156">Service could not understand malformed request.</span></span> <span data-ttu-id="c9fe1-157">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-157">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="c9fe1-158">401</span><span class="sxs-lookup"><span data-stu-id="c9fe1-158">401</span></span>| <span data-ttu-id="c9fe1-159">権限がありません</span><span class="sxs-lookup"><span data-stu-id="c9fe1-159">Unauthorized</span></span> | <span data-ttu-id="c9fe1-160">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-160">The request requires user authentication.</span></span>| 
| <span data-ttu-id="c9fe1-161">403</span><span class="sxs-lookup"><span data-stu-id="c9fe1-161">403</span></span>| <span data-ttu-id="c9fe1-162">Forbidden</span><span class="sxs-lookup"><span data-stu-id="c9fe1-162">Forbidden</span></span> | <span data-ttu-id="c9fe1-163">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-163">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="c9fe1-164">404</span><span class="sxs-lookup"><span data-stu-id="c9fe1-164">404</span></span>| <span data-ttu-id="c9fe1-165">検出不可</span><span class="sxs-lookup"><span data-stu-id="c9fe1-165">Not Found</span></span> | <span data-ttu-id="c9fe1-166">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-166">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="c9fe1-167">406</span><span class="sxs-lookup"><span data-stu-id="c9fe1-167">406</span></span>| <span data-ttu-id="c9fe1-168">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="c9fe1-168">Not Acceptable</span></span> | <span data-ttu-id="c9fe1-169">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-169">Resource version is not supported.</span></span>| 
| <span data-ttu-id="c9fe1-170">408</span><span class="sxs-lookup"><span data-stu-id="c9fe1-170">408</span></span>| <span data-ttu-id="c9fe1-171">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="c9fe1-171">Request Timeout</span></span> | <span data-ttu-id="c9fe1-172">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-172">The request took too long to complete.</span></span>| 
| <span data-ttu-id="c9fe1-173">500</span><span class="sxs-lookup"><span data-stu-id="c9fe1-173">500</span></span>| <span data-ttu-id="c9fe1-174">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="c9fe1-174">Internal Server Error</span></span> | <span data-ttu-id="c9fe1-175">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-175">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="c9fe1-176">503</span><span class="sxs-lookup"><span data-stu-id="c9fe1-176">503</span></span>| <span data-ttu-id="c9fe1-177">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="c9fe1-177">Service Unavailable</span></span> | <span data-ttu-id="c9fe1-178">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-178">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EPAAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="c9fe1-179">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9fe1-179">Required Response Headers</span></span>
 
| <span data-ttu-id="c9fe1-180">Header</span><span class="sxs-lookup"><span data-stu-id="c9fe1-180">Header</span></span>| <span data-ttu-id="c9fe1-181">説明</span><span class="sxs-lookup"><span data-stu-id="c9fe1-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c9fe1-182">Content-disposition</span><span class="sxs-lookup"><span data-stu-id="c9fe1-182">Content-Disposition</span></span>| <span data-ttu-id="c9fe1-183">パーツの内容について説明します。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-183">Describes the contents of the part.</span></span> <span data-ttu-id="c9fe1-184">ヘッダーの"name"および"filename"の部分は、このファイルが属しているユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-184">The "name" and "filename" parts of the header are the XUID of the user that this file belongs to.</span></span>| 
| <span data-ttu-id="c9fe1-185">HttpStatusCode</span><span class="sxs-lookup"><span data-stu-id="c9fe1-185">HttpStatusCode</span></span>| <span data-ttu-id="c9fe1-186">この特定のファイルを取得する HTTP ステータス コード。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-186">The HTTP status code related to retrieving this particular file.</span></span>| 
  
<a id="ID4ESBAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="c9fe1-187">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9fe1-187">Optional Response Headers</span></span>
 
| <span data-ttu-id="c9fe1-188">Header</span><span class="sxs-lookup"><span data-stu-id="c9fe1-188">Header</span></span>| <span data-ttu-id="c9fe1-189">説明</span><span class="sxs-lookup"><span data-stu-id="c9fe1-189">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c9fe1-190">ETag</span><span class="sxs-lookup"><span data-stu-id="c9fe1-190">ETag</span></span>| <span data-ttu-id="c9fe1-191">ETag は、URL にあるリソースの特定のバージョンの web サーバーによって割り当てられた非透過識別子です。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-191">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="c9fe1-192">その URL でリソースのコンテンツが変わる場合は、新しいとは異なる ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-192">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="c9fe1-193">Content-Type</span><span class="sxs-lookup"><span data-stu-id="c9fe1-193">Content-Type</span></span>| <span data-ttu-id="c9fe1-194">ファイルが正常に取得される場合、ファイルのコンテンツの種類になります。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-194">If the file was successfully retrieved, this is the Content-Type of the file.</span></span>| 
| <span data-ttu-id="c9fe1-195">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="c9fe1-195">Content-Range</span></span>| <span data-ttu-id="c9fe1-196">ファイルが正常に取得された、部分的なダウンロードが場合は、これは、応答に含まれているファイルのバイトの範囲です。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-196">If the file was successfully retrieved and is a partial download, this is the range of bytes of the file contained in the response.</span></span> | 
  
<a id="ID4E3CAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="c9fe1-197">応答本文</span><span class="sxs-lookup"><span data-stu-id="c9fe1-197">Response body</span></span>
 
<span data-ttu-id="c9fe1-198">呼び出しが成功した場合、サービスは、マルチパートの応答で、要求されたファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="c9fe1-198">If the call is successful, the service will return the contents of the requested files in a multi-part response.</span></span>
 
<a id="ID4EGDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="c9fe1-199">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="c9fe1-199">Sample response</span></span> 
 

```cpp
HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: multipart/form-data; boundary=c0a9fd75-d036-4294-8b7b-85fea15a31bb

228
--c0a9fd75-d036-4294-8b7b-85fea15a31bb
Content-Disposition: binary; name="123"; filename="123"
HttpStatusCode: 200
ETag: 0x8CF327717411C31
Content-Type: application/octet-stream

asdf123
--c0a9fd75-d036-4294-8b7b-85fea15a31bb
Content-Disposition: binary; name="456"; filename="456"
HttpStatusCode: 200
ETag: 0x8CF32771E954BB8
Content-Type: application/octet-stream

asdf456
--c0a9fd75-d036-4294-8b7b-85fea15a31bb
Content-Disposition: binary; name="789"; filename="789"
HttpStatusCode: 404


--c0a9fd75-d036-4294-8b7b-85fea15a31bb--

0

```

   
<a id="ID4EUDAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c9fe1-200">関連項目</span><span class="sxs-lookup"><span data-stu-id="c9fe1-200">See also</span></span>
 
<a id="ID4EWDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c9fe1-201">Parent</span><span class="sxs-lookup"><span data-stu-id="c9fe1-201">Parent</span></span> 

[<span data-ttu-id="c9fe1-202">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="c9fe1-202">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersbatchscidssciddatapathandfilenametype.md)

   