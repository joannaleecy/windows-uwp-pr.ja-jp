---
title: POST (/users/me/scids/{scid}/clips/{gameClipId})
assetID: 410aecad-57f9-c3dc-f35f-19c4d8dfb704
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipidpost.html
description: " POST (/users/me/scids/{scid}/clips/{gameClipId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 89f3b53631f5570ab6d0d0619f6678fc3e3c2dd2
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8326703"
---
# <a name="post-usersmescidsscidclipsgameclipid"></a><span data-ttu-id="d19d4-104">POST (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="d19d4-104">POST (/users/me/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="d19d4-105">ユーザーのデータのゲーム クリップ メタデータを更新します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-105">Update game clip metadata for the user's own data.</span></span> <span data-ttu-id="d19d4-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="d19d4-107">注釈</span><span class="sxs-lookup"><span data-stu-id="d19d4-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="d19d4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d19d4-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="d19d4-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-109">Required Request Headers</span></span>](#ID4ELB)
  * [<span data-ttu-id="d19d4-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-110">Optional Request Headers</span></span>](#ID4EXD)
  * [<span data-ttu-id="d19d4-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="d19d4-111">Request body</span></span>](#ID4EAF)
  * [<span data-ttu-id="d19d4-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-112">Required Response Headers</span></span>](#ID4EVF)
  * [<span data-ttu-id="d19d4-113">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-113">Optional Response Headers</span></span>](#ID4EJAAC)
  * [<span data-ttu-id="d19d4-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="d19d4-114">Response body</span></span>](#ID4EJBAC)
  * [<span data-ttu-id="d19d4-115">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="d19d4-115">Related URIs</span></span>](#ID4EWBAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="d19d4-116">注釈</span><span class="sxs-lookup"><span data-stu-id="d19d4-116">Remarks</span></span>
 
<span data-ttu-id="d19d4-117">ゲーム クリップ メタデータを更新するための API は、自分自身のゲーム クリップのアクセシビリティと、タイトルなどのメタデータを更新し、パブリックの属性 (評価を適用することや、ビュー カウントをインクリメント) などの更新は、2 つのカテゴリに分類されます。 その他の任意のゲーム クリップのします。</span><span class="sxs-lookup"><span data-stu-id="d19d4-117">The API for updating game clip metadata falls into two categories, updating the metadata of one's own game clips such as accessibility and title, and updating of the public attributes (like applying a rating or incrementing the view count) of any other game clip.</span></span> <span data-ttu-id="d19d4-118">URI の XUID クレームの XUID が一致しない場合は、パブリック データのみを編集できるし、他のデータを編集するすべての要求が拒否されます。</span><span class="sxs-lookup"><span data-stu-id="d19d4-118">If the XUID in the URI does not match the XUID in the claim, only the public data can be edited and any request to edit any of the other data will be denied.</span></span> <span data-ttu-id="d19d4-119">編集する場合は、複数のフィールドがしようとして、それらのいずれかが正しくない要求の全体の要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-119">In the case multiple fields are attempting to be edited and one of them is invalid for the request, the entire request would fail.</span></span>
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d19d4-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d19d4-120">URI parameters</span></span>
 
| <span data-ttu-id="d19d4-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d19d4-121">Parameter</span></span>| <span data-ttu-id="d19d4-122">型</span><span class="sxs-lookup"><span data-stu-id="d19d4-122">Type</span></span>| <span data-ttu-id="d19d4-123">説明</span><span class="sxs-lookup"><span data-stu-id="d19d4-123">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d19d4-124">scid</span><span class="sxs-lookup"><span data-stu-id="d19d4-124">scid</span></span>| <span data-ttu-id="d19d4-125">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-125">string</span></span>| <span data-ttu-id="d19d4-126">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="d19d4-126">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="d19d4-127">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d19d4-127">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="d19d4-128">gameClipId</span><span class="sxs-lookup"><span data-stu-id="d19d4-128">gameClipId</span></span>| <span data-ttu-id="d19d4-129">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-129">string</span></span>| <span data-ttu-id="d19d4-130">GameClip にアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="d19d4-130">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4ELB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="d19d4-131">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-131">Required Request Headers</span></span>
 
| <span data-ttu-id="d19d4-132">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-132">Header</span></span>| <span data-ttu-id="d19d4-133">型</span><span class="sxs-lookup"><span data-stu-id="d19d4-133">Type</span></span>| <span data-ttu-id="d19d4-134">説明</span><span class="sxs-lookup"><span data-stu-id="d19d4-134">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d19d4-135">Authorization</span><span class="sxs-lookup"><span data-stu-id="d19d4-135">Authorization</span></span>| <span data-ttu-id="d19d4-136">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-136">string</span></span>| <span data-ttu-id="d19d4-137">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-137">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="d19d4-138">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="d19d4-138">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="d19d4-139">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="d19d4-139">X-RequestedServiceVersion</span></span>| <span data-ttu-id="d19d4-140">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-140">string</span></span>| <span data-ttu-id="d19d4-141">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="d19d4-141">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="d19d4-142">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-142">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="d19d4-143">Content-Type</span><span class="sxs-lookup"><span data-stu-id="d19d4-143">Content-Type</span></span>| <span data-ttu-id="d19d4-144">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-144">string</span></span>| <span data-ttu-id="d19d4-145">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="d19d4-145">MIME type of the response body.</span></span> <span data-ttu-id="d19d4-146">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-146">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="d19d4-147">Accept</span><span class="sxs-lookup"><span data-stu-id="d19d4-147">Accept</span></span>| <span data-ttu-id="d19d4-148">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-148">string</span></span>| <span data-ttu-id="d19d4-149">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="d19d4-149">Acceptable values of Content-Type.</span></span> <span data-ttu-id="d19d4-150">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-150">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="d19d4-151">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="d19d4-151">Cache-Control</span></span>| <span data-ttu-id="d19d4-152">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-152">string</span></span>| <span data-ttu-id="d19d4-153">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-153">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EXD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="d19d4-154">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-154">Optional Request Headers</span></span>
 
| <span data-ttu-id="d19d4-155">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-155">Header</span></span>| <span data-ttu-id="d19d4-156">型</span><span class="sxs-lookup"><span data-stu-id="d19d4-156">Type</span></span>| <span data-ttu-id="d19d4-157">説明</span><span class="sxs-lookup"><span data-stu-id="d19d4-157">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d19d4-158">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="d19d4-158">Accept-Encoding</span></span>| <span data-ttu-id="d19d4-159">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-159">string</span></span>| <span data-ttu-id="d19d4-160">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="d19d4-160">Acceptable compression encodings.</span></span> <span data-ttu-id="d19d4-161">値の例: gzip、圧縮を識別します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-161">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="d19d4-162">ETag</span><span class="sxs-lookup"><span data-stu-id="d19d4-162">ETag</span></span>| <span data-ttu-id="d19d4-163">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-163">string</span></span>| <span data-ttu-id="d19d4-164">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-164">Used for cache optimization.</span></span> <span data-ttu-id="d19d4-165">値の例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="d19d4-165">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EAF"></a>

 
## <a name="request-body"></a><span data-ttu-id="d19d4-166">要求本文</span><span class="sxs-lookup"><span data-stu-id="d19d4-166">Request body</span></span>
 
<span data-ttu-id="d19d4-167">要求の本文には、JSON 形式で[UpdateMetadataRequest](../../json/json-updatemetadatarequest.md)オブジェクトを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d19d4-167">The body of the request should be an [UpdateMetadataRequest](../../json/json-updatemetadatarequest.md) object in JSON format.</span></span> <span data-ttu-id="d19d4-168">例:</span><span class="sxs-lookup"><span data-stu-id="d19d4-168">Examples:</span></span>
 
<span data-ttu-id="d19d4-169">ユーザーのクリップの名前を変更して表示します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-169">Changing User Clip Name and Visibility:</span></span>
 

```cpp
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
<span data-ttu-id="d19d4-170">タイトルのプロパティ (これは単なる例、このフィールドのスキーマは、呼び出し元であるため) だけを変更するには。</span><span class="sxs-lookup"><span data-stu-id="d19d4-170">Changing just title properties (this is just an example, since the schema of this field is up to the caller):</span></span>
 

```cpp
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EVF"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="d19d4-171">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-171">Required Response Headers</span></span>
 
| <span data-ttu-id="d19d4-172">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-172">Header</span></span>| <span data-ttu-id="d19d4-173">型</span><span class="sxs-lookup"><span data-stu-id="d19d4-173">Type</span></span>| <span data-ttu-id="d19d4-174">説明</span><span class="sxs-lookup"><span data-stu-id="d19d4-174">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d19d4-175">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="d19d4-175">X-RequestedServiceVersion</span></span>| <span data-ttu-id="d19d4-176">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-176">string</span></span>| <span data-ttu-id="d19d4-177">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="d19d4-177">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="d19d4-178">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-178">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="d19d4-179">Content-Type</span><span class="sxs-lookup"><span data-stu-id="d19d4-179">Content-Type</span></span>| <span data-ttu-id="d19d4-180">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-180">string</span></span>| <span data-ttu-id="d19d4-181">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="d19d4-181">MIME type of the response body.</span></span> <span data-ttu-id="d19d4-182">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-182">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="d19d4-183">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="d19d4-183">Cache-Control</span></span>| <span data-ttu-id="d19d4-184">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-184">string</span></span>| <span data-ttu-id="d19d4-185">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-185">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="d19d4-186">Accept</span><span class="sxs-lookup"><span data-stu-id="d19d4-186">Accept</span></span>| <span data-ttu-id="d19d4-187">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-187">string</span></span>| <span data-ttu-id="d19d4-188">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="d19d4-188">Acceptable values of Content-Type.</span></span> <span data-ttu-id="d19d4-189">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-189">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="d19d4-190">Retry-after</span><span class="sxs-lookup"><span data-stu-id="d19d4-190">Retry-After</span></span>| <span data-ttu-id="d19d4-191">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-191">string</span></span>| <span data-ttu-id="d19d4-192">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-192">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="d19d4-193">異なる</span><span class="sxs-lookup"><span data-stu-id="d19d4-193">Vary</span></span>| <span data-ttu-id="d19d4-194">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-194">string</span></span>| <span data-ttu-id="d19d4-195">下位のプロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-195">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4EJAAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="d19d4-196">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-196">Optional Response Headers</span></span>
 
| <span data-ttu-id="d19d4-197">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d19d4-197">Header</span></span>| <span data-ttu-id="d19d4-198">型</span><span class="sxs-lookup"><span data-stu-id="d19d4-198">Type</span></span>| <span data-ttu-id="d19d4-199">説明</span><span class="sxs-lookup"><span data-stu-id="d19d4-199">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d19d4-200">Etag</span><span class="sxs-lookup"><span data-stu-id="d19d4-200">Etag</span></span>| <span data-ttu-id="d19d4-201">string</span><span class="sxs-lookup"><span data-stu-id="d19d4-201">string</span></span>| <span data-ttu-id="d19d4-202">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-202">Used for cache optimization.</span></span> <span data-ttu-id="d19d4-203">例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="d19d4-203">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EJBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="d19d4-204">応答本文</span><span class="sxs-lookup"><span data-stu-id="d19d4-204">Response body</span></span>
 
<span data-ttu-id="d19d4-205">HTTP ステータス コード 200 メタデータの更新が成功時が返されます。</span><span class="sxs-lookup"><span data-stu-id="d19d4-205">Upon successful update of the metadata an HTTP status code of 200 will be returned.</span></span>
 
<span data-ttu-id="d19d4-206">それ以外の場合、適切な HTTP 状態コードを JSON 形式で ServiceErrorResponse オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="d19d4-206">Otherwise a ServiceErrorResponse object in JSON format will be returned with an appropriate HTTP status code.</span></span>
  
<a id="ID4EWBAC"></a>

 
## <a name="related-uris"></a><span data-ttu-id="d19d4-207">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="d19d4-207">Related URIs</span></span>
 
<span data-ttu-id="d19d4-208">次の Uri は、メタデータのパブリック フィールドを更新します。</span><span class="sxs-lookup"><span data-stu-id="d19d4-208">The following URIs update public fields in the metadata.</span></span> <span data-ttu-id="d19d4-209">これらの要求に必要な本文はありません。</span><span class="sxs-lookup"><span data-stu-id="d19d4-209">There is no body required for these requests.</span></span> <span data-ttu-id="d19d4-210">HTTP ステータス コード 200 メタデータの更新が成功時が返されます。</span><span class="sxs-lookup"><span data-stu-id="d19d4-210">Upon successful update of the metadata an HTTP status code of 200 will be returned.</span></span> <span data-ttu-id="d19d4-211">それ以外の場合、適切な HTTP 状態コードを JSON 形式で ServiceErrorResponse オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="d19d4-211">Otherwise a ServiceErrorResponse object in JSON format will be returned with an appropriate HTTP status code.</span></span>
 
   * <span data-ttu-id="d19d4-212">**POST/users/{ownerId} {scid}/scids//clips/{gameClipId}/ratings/{評価値}** のでは、指定したクリップに指定した評価が適用されます。</span><span class="sxs-lookup"><span data-stu-id="d19d4-212">**POST /users/{ownerId}/scids/{scid}/clips/{gameClipId}/ratings/{rating value}** - applies the specified rating to the specified clip.</span></span> <span data-ttu-id="d19d4-213">評価値 1 ~ 5 間整数である必要があります。</span><span class="sxs-lookup"><span data-stu-id="d19d4-213">Rating Value should be an integer between 1 and 5.</span></span>
   * <span data-ttu-id="d19d4-214">**/Users/{ownerId} {scid}/scids//clips/{gameClipId} を投稿/フラグ**- によって実施オンにする可能性のある問題のあるコンテンツを格納するクリップをフラグします。</span><span class="sxs-lookup"><span data-stu-id="d19d4-214">**POST /users/{ownerId}/scids/{scid}/clips/{gameClipId}/flag** - flags the clip to contain potentially questionable content to be checked by enforcement.</span></span>
   * <span data-ttu-id="d19d4-215">**POST/users/{ownerId} {scid}/scids//clips/{gameClipId} ビュー/** -指定されたゲーム クリップのビューのカウントをインクリメントします。</span><span class="sxs-lookup"><span data-stu-id="d19d4-215">**POST /users/{ownerId}/scids/{scid}/clips/{gameClipId}/views** - increments the view count for the specified game clip.</span></span> <span data-ttu-id="d19d4-216">これはという名前のない適切な再生の 75%-80% が完了したとき、再生が開始されるをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d19d4-216">It is recommended that this is called not right when playback is started, but when 75%-80% of playback has been completed.</span></span>
   
<a id="ID4EMCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d19d4-217">関連項目</span><span class="sxs-lookup"><span data-stu-id="d19d4-217">See also</span></span>
 
<a id="ID4EOCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d19d4-218">Parent</span><span class="sxs-lookup"><span data-stu-id="d19d4-218">Parent</span></span> 

[<span data-ttu-id="d19d4-219">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="d19d4-219">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

   