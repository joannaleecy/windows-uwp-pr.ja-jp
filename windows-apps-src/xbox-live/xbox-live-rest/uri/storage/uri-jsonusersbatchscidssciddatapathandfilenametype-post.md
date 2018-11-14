---
title: POST (/json/users/batch/scids/{scid}/data/{pathAndFileName},json)
assetID: fb4cff17-2721-89c5-6646-5ab76952b411
permalink: en-us/docs/xboxlive/rest/uri-jsonusersbatchscidssciddatapathandfilenametype-post.html
author: KevinAsgari
description: " POST (/json/users/batch/scids/{scid}/data/{pathAndFileName},json)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 592467707c67e82531af31c52ba38fbfb04080db
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6257375"
---
# <a name="post-jsonusersbatchscidssciddatapathandfilenamejson"></a><span data-ttu-id="4414d-104">POST (/json/users/batch/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="4414d-104">POST (/json/users/batch/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="4414d-105">同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="4414d-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="4414d-106">ダウンロードするファイルは、要求の URI によって決定されます。</span><span class="sxs-lookup"><span data-stu-id="4414d-106">The file to be downloaded is determined by the URI of the request.</span></span> <span data-ttu-id="4414d-107">要求の本文には、ダウンロードするファイル持つにはユーザーの Xuid のリストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="4414d-107">The body of the request contains the list of XUIDs of the users whose files to download.</span></span> <span data-ttu-id="4414d-108">応答の本文は、特定のユーザーと独自のヘッダー ファイルを表す各部分をマルチパート MIME メッセージになります。</span><span class="sxs-lookup"><span data-stu-id="4414d-108">The body of the response will be a multi-part MIME message, with each part representing a file for a particular user with its own set of headers.</span></span> <span data-ttu-id="4414d-109">成功と失敗の混在する応答の部分のことができます。</span><span class="sxs-lookup"><span data-stu-id="4414d-109">It's possible for the parts of the response to be a mix of successes and failures.</span></span> <span data-ttu-id="4414d-110">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="4414d-110">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="4414d-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4414d-111">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="4414d-112">Authorization</span><span class="sxs-lookup"><span data-stu-id="4414d-112">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="4414d-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="4414d-113">Request body</span></span>](#ID4EPB)
  * [<span data-ttu-id="4414d-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="4414d-114">HTTP status codes</span></span>](#ID4E3C)
  * [<span data-ttu-id="4414d-115">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4414d-115">Required Response Headers</span></span>](#ID4EPAAC)
  * [<span data-ttu-id="4414d-116">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4414d-116">Optional Response Headers</span></span>](#ID4ESBAC)
  * [<span data-ttu-id="4414d-117">応答本文</span><span class="sxs-lookup"><span data-stu-id="4414d-117">Response body</span></span>](#ID4E3CAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="4414d-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4414d-118">URI parameters</span></span>
 
| <span data-ttu-id="4414d-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4414d-119">Parameter</span></span>| <span data-ttu-id="4414d-120">型</span><span class="sxs-lookup"><span data-stu-id="4414d-120">Type</span></span>| <span data-ttu-id="4414d-121">説明</span><span class="sxs-lookup"><span data-stu-id="4414d-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="4414d-122">scid</span><span class="sxs-lookup"><span data-stu-id="4414d-122">scid</span></span>| <span data-ttu-id="4414d-123">guid</span><span class="sxs-lookup"><span data-stu-id="4414d-123">guid</span></span>| <span data-ttu-id="4414d-124">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="4414d-124">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="4414d-125">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="4414d-125">pathAndFileName</span></span>| <span data-ttu-id="4414d-126">string</span><span class="sxs-lookup"><span data-stu-id="4414d-126">string</span></span>| <span data-ttu-id="4414d-127">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="4414d-127">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="4414d-128">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="4414d-128">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="4414d-129">ファイル名可能性がありますいない空にすること、期間の終了または 2 つの連続するピリオドが含まれます。</span><span class="sxs-lookup"><span data-stu-id="4414d-129">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="4414d-130">Authorization</span><span class="sxs-lookup"><span data-stu-id="4414d-130">Authorization</span></span> 
 
<span data-ttu-id="4414d-131">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="4414d-131">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="4414d-132">呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="4414d-132">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="4414d-133">ヘッダーが見つからないか無効な場合は、サービスは、401 不正な応答を返します。</span><span class="sxs-lookup"><span data-stu-id="4414d-133">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EPB"></a>

 
## <a name="request-body"></a><span data-ttu-id="4414d-134">要求本文</span><span class="sxs-lookup"><span data-stu-id="4414d-134">Request body</span></span>
 
| <span data-ttu-id="4414d-135">プロパティ</span><span class="sxs-lookup"><span data-stu-id="4414d-135">Property</span></span>| <span data-ttu-id="4414d-136">型</span><span class="sxs-lookup"><span data-stu-id="4414d-136">Type</span></span>| <span data-ttu-id="4414d-137">説明</span><span class="sxs-lookup"><span data-stu-id="4414d-137">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="4414d-138">xuid</span><span class="sxs-lookup"><span data-stu-id="4414d-138">xuids</span></span>| <span data-ttu-id="4414d-139">64 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="4414d-139">array of unsigned 64-bit integers</span></span>| <span data-ttu-id="4414d-140">ファイルをダウンロードする対象の Xuid のリスト。</span><span class="sxs-lookup"><span data-stu-id="4414d-140">The list of XUIDs for which to download files.</span></span>| 
 
<a id="ID4EQC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="4414d-141">要求の例</span><span class="sxs-lookup"><span data-stu-id="4414d-141">Sample request</span></span>
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="4414d-142">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="4414d-142">HTTP status codes</span></span> 
 
<span data-ttu-id="4414d-143">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="4414d-143">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="4414d-144">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4414d-144">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="4414d-145">コード</span><span class="sxs-lookup"><span data-stu-id="4414d-145">Code</span></span>| <span data-ttu-id="4414d-146">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="4414d-146">Reason phrase</span></span>| <span data-ttu-id="4414d-147">説明</span><span class="sxs-lookup"><span data-stu-id="4414d-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="4414d-148">200</span><span class="sxs-lookup"><span data-stu-id="4414d-148">200</span></span>| <span data-ttu-id="4414d-149">OK</span><span class="sxs-lookup"><span data-stu-id="4414d-149">OK</span></span> | <span data-ttu-id="4414d-150">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="4414d-150">The request was successful.</span></span>| 
| <span data-ttu-id="4414d-151">201</span><span class="sxs-lookup"><span data-stu-id="4414d-151">201</span></span>| <span data-ttu-id="4414d-152">Created</span><span class="sxs-lookup"><span data-stu-id="4414d-152">Created</span></span> | <span data-ttu-id="4414d-153">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="4414d-153">The entity was created.</span></span>| 
| <span data-ttu-id="4414d-154">400</span><span class="sxs-lookup"><span data-stu-id="4414d-154">400</span></span>| <span data-ttu-id="4414d-155">Bad Request</span><span class="sxs-lookup"><span data-stu-id="4414d-155">Bad Request</span></span> | <span data-ttu-id="4414d-156">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4414d-156">Service could not understand malformed request.</span></span> <span data-ttu-id="4414d-157">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="4414d-157">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="4414d-158">401</span><span class="sxs-lookup"><span data-stu-id="4414d-158">401</span></span>| <span data-ttu-id="4414d-159">権限がありません</span><span class="sxs-lookup"><span data-stu-id="4414d-159">Unauthorized</span></span> | <span data-ttu-id="4414d-160">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="4414d-160">The request requires user authentication.</span></span>| 
| <span data-ttu-id="4414d-161">403</span><span class="sxs-lookup"><span data-stu-id="4414d-161">403</span></span>| <span data-ttu-id="4414d-162">Forbidden</span><span class="sxs-lookup"><span data-stu-id="4414d-162">Forbidden</span></span> | <span data-ttu-id="4414d-163">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="4414d-163">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="4414d-164">404</span><span class="sxs-lookup"><span data-stu-id="4414d-164">404</span></span>| <span data-ttu-id="4414d-165">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="4414d-165">Not Found</span></span> | <span data-ttu-id="4414d-166">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="4414d-166">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="4414d-167">406</span><span class="sxs-lookup"><span data-stu-id="4414d-167">406</span></span>| <span data-ttu-id="4414d-168">許容できません。</span><span class="sxs-lookup"><span data-stu-id="4414d-168">Not Acceptable</span></span> | <span data-ttu-id="4414d-169">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="4414d-169">Resource version is not supported.</span></span>| 
| <span data-ttu-id="4414d-170">408</span><span class="sxs-lookup"><span data-stu-id="4414d-170">408</span></span>| <span data-ttu-id="4414d-171">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="4414d-171">Request Timeout</span></span> | <span data-ttu-id="4414d-172">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="4414d-172">The request took too long to complete.</span></span>| 
| <span data-ttu-id="4414d-173">500</span><span class="sxs-lookup"><span data-stu-id="4414d-173">500</span></span>| <span data-ttu-id="4414d-174">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="4414d-174">Internal Server Error</span></span> | <span data-ttu-id="4414d-175">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="4414d-175">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="4414d-176">503</span><span class="sxs-lookup"><span data-stu-id="4414d-176">503</span></span>| <span data-ttu-id="4414d-177">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="4414d-177">Service Unavailable</span></span> | <span data-ttu-id="4414d-178">要求がスロット リングされた、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="4414d-178">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EPAAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="4414d-179">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4414d-179">Required Response Headers</span></span>
 
| <span data-ttu-id="4414d-180">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4414d-180">Header</span></span>| <span data-ttu-id="4414d-181">説明</span><span class="sxs-lookup"><span data-stu-id="4414d-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="4414d-182">コンテンツ廃棄</span><span class="sxs-lookup"><span data-stu-id="4414d-182">Content-Disposition</span></span>| <span data-ttu-id="4414d-183">一部の内容について説明します。</span><span class="sxs-lookup"><span data-stu-id="4414d-183">Describes the contents of the part.</span></span> <span data-ttu-id="4414d-184">ヘッダーの"name"と"filename"部分は、このファイルに属していることをユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="4414d-184">The "name" and "filename" parts of the header are the XUID of the user that this file belongs to.</span></span>| 
| <span data-ttu-id="4414d-185">HttpStatusCode</span><span class="sxs-lookup"><span data-stu-id="4414d-185">HttpStatusCode</span></span>| <span data-ttu-id="4414d-186">この特定のファイルの取得に関連する HTTP ステータス コード。</span><span class="sxs-lookup"><span data-stu-id="4414d-186">The HTTP status code related to retrieving this particular file.</span></span>| 
  
<a id="ID4ESBAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="4414d-187">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4414d-187">Optional Response Headers</span></span>
 
| <span data-ttu-id="4414d-188">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4414d-188">Header</span></span>| <span data-ttu-id="4414d-189">説明</span><span class="sxs-lookup"><span data-stu-id="4414d-189">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="4414d-190">ETag</span><span class="sxs-lookup"><span data-stu-id="4414d-190">ETag</span></span>| <span data-ttu-id="4414d-191">ETag は、web サーバーの URL で見つかったリソースの特定のバージョンによって割り当てられる不透明な識別子です。</span><span class="sxs-lookup"><span data-stu-id="4414d-191">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="4414d-192">その URL でリソースのコンテンツが変更された場合は、新しいとは異なる ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="4414d-192">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="4414d-193">Content-Type</span><span class="sxs-lookup"><span data-stu-id="4414d-193">Content-Type</span></span>| <span data-ttu-id="4414d-194">場合は、ファイルが正常に取得された、これは、ファイルのコンテンツの種類。</span><span class="sxs-lookup"><span data-stu-id="4414d-194">If the file was successfully retrieved, this is the Content-Type of the file.</span></span>| 
| <span data-ttu-id="4414d-195">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="4414d-195">Content-Range</span></span>| <span data-ttu-id="4414d-196">ファイルが正常に取得された、部分的なダウンロードの場合は、応答に含まれているファイルのバイトの範囲です。</span><span class="sxs-lookup"><span data-stu-id="4414d-196">If the file was successfully retrieved and is a partial download, this is the range of bytes of the file contained in the response.</span></span> | 
  
<a id="ID4E3CAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="4414d-197">応答本文</span><span class="sxs-lookup"><span data-stu-id="4414d-197">Response body</span></span>
 
<span data-ttu-id="4414d-198">呼び出しが成功した場合は、サービスは、マルチパート応答で、要求されたファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="4414d-198">If the call is successful, the service will return the contents of the requested files in a multi-part response.</span></span>
 
<a id="ID4EGDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="4414d-199">応答の例</span><span class="sxs-lookup"><span data-stu-id="4414d-199">Sample response</span></span> 
 

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

 
## <a name="see-also"></a><span data-ttu-id="4414d-200">関連項目</span><span class="sxs-lookup"><span data-stu-id="4414d-200">See also</span></span>
 
<a id="ID4EWDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="4414d-201">Parent</span><span class="sxs-lookup"><span data-stu-id="4414d-201">Parent</span></span> 

[<span data-ttu-id="4414d-202">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="4414d-202">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersbatchscidssciddatapathandfilenametype.md)

   