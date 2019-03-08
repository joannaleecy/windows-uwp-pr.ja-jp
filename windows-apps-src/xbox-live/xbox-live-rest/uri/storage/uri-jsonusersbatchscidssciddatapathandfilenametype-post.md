---
title: POST (/json/users/batch/scids/{scid}/data/{pathAndFileName},json)
assetID: fb4cff17-2721-89c5-6646-5ab76952b411
permalink: en-us/docs/xboxlive/rest/uri-jsonusersbatchscidssciddatapathandfilenametype-post.html
description: " POST (/json/users/batch/scids/{scid}/data/{pathAndFileName},json)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cfe20136ad1320966fc851cf9dd6de765871c957
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623297"
---
# <a name="post-jsonusersbatchscidssciddatapathandfilenamejson"></a><span data-ttu-id="40455-104">POST (/json/users/batch/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="40455-104">POST (/json/users/batch/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="40455-105">同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="40455-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="40455-106">ファイルのダウンロードは、要求の URI によって決定されます。</span><span class="sxs-lookup"><span data-stu-id="40455-106">The file to be downloaded is determined by the URI of the request.</span></span> <span data-ttu-id="40455-107">要求の本文には、ダウンロードするファイル持つには Xuid、ユーザーの一覧が含まれています。</span><span class="sxs-lookup"><span data-stu-id="40455-107">The body of the request contains the list of XUIDs of the users whose files to download.</span></span> <span data-ttu-id="40455-108">応答の本文を各要素は、独自のヘッダーのセットを特定のユーザーのファイルを表す、マルチパート MIME メッセージとなります。</span><span class="sxs-lookup"><span data-stu-id="40455-108">The body of the response will be a multi-part MIME message, with each part representing a file for a particular user with its own set of headers.</span></span> <span data-ttu-id="40455-109">成功と失敗の組み合わせに対する応答の部分のことができます。</span><span class="sxs-lookup"><span data-stu-id="40455-109">It's possible for the parts of the response to be a mix of successes and failures.</span></span> <span data-ttu-id="40455-110">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="40455-110">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="40455-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="40455-111">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="40455-112">承認</span><span class="sxs-lookup"><span data-stu-id="40455-112">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="40455-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="40455-113">Request body</span></span>](#ID4EPB)
  * [<span data-ttu-id="40455-114">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="40455-114">HTTP status codes</span></span>](#ID4E3C)
  * [<span data-ttu-id="40455-115">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40455-115">Required Response Headers</span></span>](#ID4EPAAC)
  * [<span data-ttu-id="40455-116">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40455-116">Optional Response Headers</span></span>](#ID4ESBAC)
  * [<span data-ttu-id="40455-117">応答本文</span><span class="sxs-lookup"><span data-stu-id="40455-117">Response body</span></span>](#ID4E3CAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="40455-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="40455-118">URI parameters</span></span>
 
| <span data-ttu-id="40455-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="40455-119">Parameter</span></span>| <span data-ttu-id="40455-120">種類</span><span class="sxs-lookup"><span data-stu-id="40455-120">Type</span></span>| <span data-ttu-id="40455-121">説明</span><span class="sxs-lookup"><span data-stu-id="40455-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="40455-122">scid</span><span class="sxs-lookup"><span data-stu-id="40455-122">scid</span></span>| <span data-ttu-id="40455-123">guid</span><span class="sxs-lookup"><span data-stu-id="40455-123">guid</span></span>| <span data-ttu-id="40455-124">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="40455-124">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="40455-125">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="40455-125">pathAndFileName</span></span>| <span data-ttu-id="40455-126">string</span><span class="sxs-lookup"><span data-stu-id="40455-126">string</span></span>| <span data-ttu-id="40455-127">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="40455-127">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="40455-128">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="40455-128">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="40455-129">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="40455-129">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="40455-130">Authorization</span><span class="sxs-lookup"><span data-stu-id="40455-130">Authorization</span></span> 
 
<span data-ttu-id="40455-131">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="40455-131">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="40455-132">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="40455-132">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="40455-133">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="40455-133">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EPB"></a>

 
## <a name="request-body"></a><span data-ttu-id="40455-134">要求本文</span><span class="sxs-lookup"><span data-stu-id="40455-134">Request body</span></span>
 
| <span data-ttu-id="40455-135">プロパティ</span><span class="sxs-lookup"><span data-stu-id="40455-135">Property</span></span>| <span data-ttu-id="40455-136">種類</span><span class="sxs-lookup"><span data-stu-id="40455-136">Type</span></span>| <span data-ttu-id="40455-137">説明</span><span class="sxs-lookup"><span data-stu-id="40455-137">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="40455-138">xuid</span><span class="sxs-lookup"><span data-stu-id="40455-138">xuids</span></span>| <span data-ttu-id="40455-139">64 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="40455-139">array of unsigned 64-bit integers</span></span>| <span data-ttu-id="40455-140">ファイルをダウンロードする Xuid の一覧。</span><span class="sxs-lookup"><span data-stu-id="40455-140">The list of XUIDs for which to download files.</span></span>| 
 
<a id="ID4EQC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="40455-141">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="40455-141">Sample request</span></span>
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="40455-142">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="40455-142">HTTP status codes</span></span> 
 
<span data-ttu-id="40455-143">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="40455-143">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="40455-144">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="40455-144">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="40455-145">コード</span><span class="sxs-lookup"><span data-stu-id="40455-145">Code</span></span>| <span data-ttu-id="40455-146">理由語句</span><span class="sxs-lookup"><span data-stu-id="40455-146">Reason phrase</span></span>| <span data-ttu-id="40455-147">説明</span><span class="sxs-lookup"><span data-stu-id="40455-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="40455-148">200</span><span class="sxs-lookup"><span data-stu-id="40455-148">200</span></span>| <span data-ttu-id="40455-149">OK</span><span class="sxs-lookup"><span data-stu-id="40455-149">OK</span></span> | <span data-ttu-id="40455-150">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="40455-150">The request was successful.</span></span>| 
| <span data-ttu-id="40455-151">201</span><span class="sxs-lookup"><span data-stu-id="40455-151">201</span></span>| <span data-ttu-id="40455-152">作成日</span><span class="sxs-lookup"><span data-stu-id="40455-152">Created</span></span> | <span data-ttu-id="40455-153">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="40455-153">The entity was created.</span></span>| 
| <span data-ttu-id="40455-154">400</span><span class="sxs-lookup"><span data-stu-id="40455-154">400</span></span>| <span data-ttu-id="40455-155">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="40455-155">Bad Request</span></span> | <span data-ttu-id="40455-156">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="40455-156">Service could not understand malformed request.</span></span> <span data-ttu-id="40455-157">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="40455-157">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="40455-158">401</span><span class="sxs-lookup"><span data-stu-id="40455-158">401</span></span>| <span data-ttu-id="40455-159">権限がありません</span><span class="sxs-lookup"><span data-stu-id="40455-159">Unauthorized</span></span> | <span data-ttu-id="40455-160">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="40455-160">The request requires user authentication.</span></span>| 
| <span data-ttu-id="40455-161">403</span><span class="sxs-lookup"><span data-stu-id="40455-161">403</span></span>| <span data-ttu-id="40455-162">Forbidden</span><span class="sxs-lookup"><span data-stu-id="40455-162">Forbidden</span></span> | <span data-ttu-id="40455-163">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="40455-163">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="40455-164">404</span><span class="sxs-lookup"><span data-stu-id="40455-164">404</span></span>| <span data-ttu-id="40455-165">検出不可</span><span class="sxs-lookup"><span data-stu-id="40455-165">Not Found</span></span> | <span data-ttu-id="40455-166">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="40455-166">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="40455-167">406</span><span class="sxs-lookup"><span data-stu-id="40455-167">406</span></span>| <span data-ttu-id="40455-168">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="40455-168">Not Acceptable</span></span> | <span data-ttu-id="40455-169">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="40455-169">Resource version is not supported.</span></span>| 
| <span data-ttu-id="40455-170">408</span><span class="sxs-lookup"><span data-stu-id="40455-170">408</span></span>| <span data-ttu-id="40455-171">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="40455-171">Request Timeout</span></span> | <span data-ttu-id="40455-172">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="40455-172">The request took too long to complete.</span></span>| 
| <span data-ttu-id="40455-173">500</span><span class="sxs-lookup"><span data-stu-id="40455-173">500</span></span>| <span data-ttu-id="40455-174">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="40455-174">Internal Server Error</span></span> | <span data-ttu-id="40455-175">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="40455-175">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="40455-176">503</span><span class="sxs-lookup"><span data-stu-id="40455-176">503</span></span>| <span data-ttu-id="40455-177">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="40455-177">Service Unavailable</span></span> | <span data-ttu-id="40455-178">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="40455-178">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EPAAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="40455-179">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40455-179">Required Response Headers</span></span>
 
| <span data-ttu-id="40455-180">Header</span><span class="sxs-lookup"><span data-stu-id="40455-180">Header</span></span>| <span data-ttu-id="40455-181">説明</span><span class="sxs-lookup"><span data-stu-id="40455-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="40455-182">Content-disposition</span><span class="sxs-lookup"><span data-stu-id="40455-182">Content-Disposition</span></span>| <span data-ttu-id="40455-183">パーツの内容について説明します。</span><span class="sxs-lookup"><span data-stu-id="40455-183">Describes the contents of the part.</span></span> <span data-ttu-id="40455-184">ヘッダーの"name"および"filename"の部分は、このファイルが属しているユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="40455-184">The "name" and "filename" parts of the header are the XUID of the user that this file belongs to.</span></span>| 
| <span data-ttu-id="40455-185">HttpStatusCode</span><span class="sxs-lookup"><span data-stu-id="40455-185">HttpStatusCode</span></span>| <span data-ttu-id="40455-186">この特定のファイルを取得する HTTP ステータス コード。</span><span class="sxs-lookup"><span data-stu-id="40455-186">The HTTP status code related to retrieving this particular file.</span></span>| 
  
<a id="ID4ESBAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="40455-187">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40455-187">Optional Response Headers</span></span>
 
| <span data-ttu-id="40455-188">Header</span><span class="sxs-lookup"><span data-stu-id="40455-188">Header</span></span>| <span data-ttu-id="40455-189">説明</span><span class="sxs-lookup"><span data-stu-id="40455-189">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="40455-190">ETag</span><span class="sxs-lookup"><span data-stu-id="40455-190">ETag</span></span>| <span data-ttu-id="40455-191">ETag は、URL にあるリソースの特定のバージョンの web サーバーによって割り当てられた非透過識別子です。</span><span class="sxs-lookup"><span data-stu-id="40455-191">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="40455-192">その URL でリソースのコンテンツが変わる場合は、新しいとは異なる ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="40455-192">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="40455-193">Content-Type</span><span class="sxs-lookup"><span data-stu-id="40455-193">Content-Type</span></span>| <span data-ttu-id="40455-194">ファイルが正常に取得される場合、ファイルのコンテンツの種類になります。</span><span class="sxs-lookup"><span data-stu-id="40455-194">If the file was successfully retrieved, this is the Content-Type of the file.</span></span>| 
| <span data-ttu-id="40455-195">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="40455-195">Content-Range</span></span>| <span data-ttu-id="40455-196">ファイルが正常に取得された、部分的なダウンロードが場合は、これは、応答に含まれているファイルのバイトの範囲です。</span><span class="sxs-lookup"><span data-stu-id="40455-196">If the file was successfully retrieved and is a partial download, this is the range of bytes of the file contained in the response.</span></span> | 
  
<a id="ID4E3CAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="40455-197">応答本文</span><span class="sxs-lookup"><span data-stu-id="40455-197">Response body</span></span>
 
<span data-ttu-id="40455-198">呼び出しが成功した場合、サービスは、マルチパートの応答で、要求されたファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="40455-198">If the call is successful, the service will return the contents of the requested files in a multi-part response.</span></span>
 
<a id="ID4EGDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="40455-199">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="40455-199">Sample response</span></span> 
 

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

 
## <a name="see-also"></a><span data-ttu-id="40455-200">関連項目</span><span class="sxs-lookup"><span data-stu-id="40455-200">See also</span></span>
 
<a id="ID4EWDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="40455-201">Parent</span><span class="sxs-lookup"><span data-stu-id="40455-201">Parent</span></span> 

[<span data-ttu-id="40455-202">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="40455-202">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersbatchscidssciddatapathandfilenametype.md)

   