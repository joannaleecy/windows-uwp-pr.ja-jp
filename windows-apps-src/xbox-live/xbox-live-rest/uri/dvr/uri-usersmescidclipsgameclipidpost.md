---
title: POST (/users/me/scids/{scid}/clips/{gameClipId})
assetID: 410aecad-57f9-c3dc-f35f-19c4d8dfb704
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipidpost.html
author: KevinAsgari
description: " POST (/users/me/scids/{scid}/clips/{gameClipId})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 28c8b9e20e990c51c6b3d7e56e72f4d5d6551b39
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4173116"
---
# <a name="post-usersmescidsscidclipsgameclipid"></a><span data-ttu-id="0b995-104">POST (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="0b995-104">POST (/users/me/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="0b995-105">ユーザーのデータのゲーム クリップ メタデータを更新します。</span><span class="sxs-lookup"><span data-stu-id="0b995-105">Update game clip metadata for the user's own data.</span></span> <span data-ttu-id="0b995-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`問題の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="0b995-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="0b995-107">注釈</span><span class="sxs-lookup"><span data-stu-id="0b995-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="0b995-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0b995-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="0b995-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-109">Required Request Headers</span></span>](#ID4ELB)
  * [<span data-ttu-id="0b995-110">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-110">Optional Request Headers</span></span>](#ID4EXD)
  * [<span data-ttu-id="0b995-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="0b995-111">Request body</span></span>](#ID4EAF)
  * [<span data-ttu-id="0b995-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-112">Required Response Headers</span></span>](#ID4EVF)
  * [<span data-ttu-id="0b995-113">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-113">Optional Response Headers</span></span>](#ID4EJAAC)
  * [<span data-ttu-id="0b995-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="0b995-114">Response body</span></span>](#ID4EJBAC)
  * [<span data-ttu-id="0b995-115">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="0b995-115">Related URIs</span></span>](#ID4EWBAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="0b995-116">注釈</span><span class="sxs-lookup"><span data-stu-id="0b995-116">Remarks</span></span>
 
<span data-ttu-id="0b995-117">ゲーム クリップ メタデータを更新するための API は、1 のゲーム クリップのアクセシビリティと、タイトルなどのメタデータを更新し、パブリックの属性 (評価を適用することや、ビュー カウントをインクリメント) などの更新は、2 つのカテゴリに分類されます。 その他のゲーム クリップのします。</span><span class="sxs-lookup"><span data-stu-id="0b995-117">The API for updating game clip metadata falls into two categories, updating the metadata of one's own game clips such as accessibility and title, and updating of the public attributes (like applying a rating or incrementing the view count) of any other game clip.</span></span> <span data-ttu-id="0b995-118">URI の XUID が要求で XUID が一致しない場合パブリック データのみを編集できるし、その他のデータを編集するすべての要求が拒否されます。</span><span class="sxs-lookup"><span data-stu-id="0b995-118">If the XUID in the URI does not match the XUID in the claim, only the public data can be edited and any request to edit any of the other data will be denied.</span></span> <span data-ttu-id="0b995-119">編集する場合は、複数のフィールドがしようとして、それらのいずれかが正しくない要求の全体の要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="0b995-119">In the case multiple fields are attempting to be edited and one of them is invalid for the request, the entire request would fail.</span></span>
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0b995-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0b995-120">URI parameters</span></span>
 
| <span data-ttu-id="0b995-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0b995-121">Parameter</span></span>| <span data-ttu-id="0b995-122">型</span><span class="sxs-lookup"><span data-stu-id="0b995-122">Type</span></span>| <span data-ttu-id="0b995-123">説明</span><span class="sxs-lookup"><span data-stu-id="0b995-123">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0b995-124">scid</span><span class="sxs-lookup"><span data-stu-id="0b995-124">scid</span></span>| <span data-ttu-id="0b995-125">string</span><span class="sxs-lookup"><span data-stu-id="0b995-125">string</span></span>| <span data-ttu-id="0b995-126">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="0b995-126">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="0b995-127">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b995-127">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="0b995-128">gameClipId</span><span class="sxs-lookup"><span data-stu-id="0b995-128">gameClipId</span></span>| <span data-ttu-id="0b995-129">string</span><span class="sxs-lookup"><span data-stu-id="0b995-129">string</span></span>| <span data-ttu-id="0b995-130">ゲーム クリップだったにアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="0b995-130">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4ELB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="0b995-131">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-131">Required Request Headers</span></span>
 
| <span data-ttu-id="0b995-132">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-132">Header</span></span>| <span data-ttu-id="0b995-133">型</span><span class="sxs-lookup"><span data-stu-id="0b995-133">Type</span></span>| <span data-ttu-id="0b995-134">説明</span><span class="sxs-lookup"><span data-stu-id="0b995-134">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0b995-135">Authorization</span><span class="sxs-lookup"><span data-stu-id="0b995-135">Authorization</span></span>| <span data-ttu-id="0b995-136">string</span><span class="sxs-lookup"><span data-stu-id="0b995-136">string</span></span>| <span data-ttu-id="0b995-137">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="0b995-137">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="0b995-138">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="0b995-138">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="0b995-139">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="0b995-139">X-RequestedServiceVersion</span></span>| <span data-ttu-id="0b995-140">string</span><span class="sxs-lookup"><span data-stu-id="0b995-140">string</span></span>| <span data-ttu-id="0b995-141">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="0b995-141">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="0b995-142">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="0b995-142">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="0b995-143">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0b995-143">Content-Type</span></span>| <span data-ttu-id="0b995-144">string</span><span class="sxs-lookup"><span data-stu-id="0b995-144">string</span></span>| <span data-ttu-id="0b995-145">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="0b995-145">MIME type of the response body.</span></span> <span data-ttu-id="0b995-146">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0b995-146">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0b995-147">Accept</span><span class="sxs-lookup"><span data-stu-id="0b995-147">Accept</span></span>| <span data-ttu-id="0b995-148">string</span><span class="sxs-lookup"><span data-stu-id="0b995-148">string</span></span>| <span data-ttu-id="0b995-149">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="0b995-149">Acceptable values of Content-Type.</span></span> <span data-ttu-id="0b995-150">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0b995-150">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0b995-151">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="0b995-151">Cache-Control</span></span>| <span data-ttu-id="0b995-152">string</span><span class="sxs-lookup"><span data-stu-id="0b995-152">string</span></span>| <span data-ttu-id="0b995-153">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="0b995-153">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EXD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="0b995-154">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-154">Optional Request Headers</span></span>
 
| <span data-ttu-id="0b995-155">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-155">Header</span></span>| <span data-ttu-id="0b995-156">型</span><span class="sxs-lookup"><span data-stu-id="0b995-156">Type</span></span>| <span data-ttu-id="0b995-157">説明</span><span class="sxs-lookup"><span data-stu-id="0b995-157">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0b995-158">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="0b995-158">Accept-Encoding</span></span>| <span data-ttu-id="0b995-159">string</span><span class="sxs-lookup"><span data-stu-id="0b995-159">string</span></span>| <span data-ttu-id="0b995-160">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="0b995-160">Acceptable compression encodings.</span></span> <span data-ttu-id="0b995-161">値の例: gzip、圧縮を識別します。</span><span class="sxs-lookup"><span data-stu-id="0b995-161">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="0b995-162">ETag</span><span class="sxs-lookup"><span data-stu-id="0b995-162">ETag</span></span>| <span data-ttu-id="0b995-163">string</span><span class="sxs-lookup"><span data-stu-id="0b995-163">string</span></span>| <span data-ttu-id="0b995-164">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="0b995-164">Used for cache optimization.</span></span> <span data-ttu-id="0b995-165">値の例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="0b995-165">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EAF"></a>

 
## <a name="request-body"></a><span data-ttu-id="0b995-166">要求本文</span><span class="sxs-lookup"><span data-stu-id="0b995-166">Request body</span></span>
 
<span data-ttu-id="0b995-167">要求の本文には、JSON 形式で[UpdateMetadataRequest](../../json/json-updatemetadatarequest.md)オブジェクトを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b995-167">The body of the request should be an [UpdateMetadataRequest](../../json/json-updatemetadatarequest.md) object in JSON format.</span></span> <span data-ttu-id="0b995-168">例:</span><span class="sxs-lookup"><span data-stu-id="0b995-168">Examples:</span></span>
 
<span data-ttu-id="0b995-169">ユーザーのクリップ名と認知度を変更します。</span><span class="sxs-lookup"><span data-stu-id="0b995-169">Changing User Clip Name and Visibility:</span></span>
 

```cpp
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
<span data-ttu-id="0b995-170">タイトルのプロパティ (これは単なる例、このフィールドのスキーマは、呼び出し元であるため) だけを変更するには。</span><span class="sxs-lookup"><span data-stu-id="0b995-170">Changing just title properties (this is just an example, since the schema of this field is up to the caller):</span></span>
 

```cpp
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EVF"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="0b995-171">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-171">Required Response Headers</span></span>
 
| <span data-ttu-id="0b995-172">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-172">Header</span></span>| <span data-ttu-id="0b995-173">型</span><span class="sxs-lookup"><span data-stu-id="0b995-173">Type</span></span>| <span data-ttu-id="0b995-174">説明</span><span class="sxs-lookup"><span data-stu-id="0b995-174">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0b995-175">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="0b995-175">X-RequestedServiceVersion</span></span>| <span data-ttu-id="0b995-176">string</span><span class="sxs-lookup"><span data-stu-id="0b995-176">string</span></span>| <span data-ttu-id="0b995-177">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="0b995-177">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="0b995-178">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="0b995-178">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="0b995-179">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0b995-179">Content-Type</span></span>| <span data-ttu-id="0b995-180">string</span><span class="sxs-lookup"><span data-stu-id="0b995-180">string</span></span>| <span data-ttu-id="0b995-181">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="0b995-181">MIME type of the response body.</span></span> <span data-ttu-id="0b995-182">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0b995-182">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0b995-183">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="0b995-183">Cache-Control</span></span>| <span data-ttu-id="0b995-184">string</span><span class="sxs-lookup"><span data-stu-id="0b995-184">string</span></span>| <span data-ttu-id="0b995-185">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="0b995-185">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="0b995-186">Accept</span><span class="sxs-lookup"><span data-stu-id="0b995-186">Accept</span></span>| <span data-ttu-id="0b995-187">string</span><span class="sxs-lookup"><span data-stu-id="0b995-187">string</span></span>| <span data-ttu-id="0b995-188">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="0b995-188">Acceptable values of Content-Type.</span></span> <span data-ttu-id="0b995-189">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0b995-189">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0b995-190">Retry-after</span><span class="sxs-lookup"><span data-stu-id="0b995-190">Retry-After</span></span>| <span data-ttu-id="0b995-191">string</span><span class="sxs-lookup"><span data-stu-id="0b995-191">string</span></span>| <span data-ttu-id="0b995-192">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="0b995-192">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="0b995-193">異なる</span><span class="sxs-lookup"><span data-stu-id="0b995-193">Vary</span></span>| <span data-ttu-id="0b995-194">string</span><span class="sxs-lookup"><span data-stu-id="0b995-194">string</span></span>| <span data-ttu-id="0b995-195">下位のプロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="0b995-195">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4EJAAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="0b995-196">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-196">Optional Response Headers</span></span>
 
| <span data-ttu-id="0b995-197">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b995-197">Header</span></span>| <span data-ttu-id="0b995-198">型</span><span class="sxs-lookup"><span data-stu-id="0b995-198">Type</span></span>| <span data-ttu-id="0b995-199">説明</span><span class="sxs-lookup"><span data-stu-id="0b995-199">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0b995-200">Etag</span><span class="sxs-lookup"><span data-stu-id="0b995-200">Etag</span></span>| <span data-ttu-id="0b995-201">string</span><span class="sxs-lookup"><span data-stu-id="0b995-201">string</span></span>| <span data-ttu-id="0b995-202">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="0b995-202">Used for cache optimization.</span></span> <span data-ttu-id="0b995-203">例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="0b995-203">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EJBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="0b995-204">応答本文</span><span class="sxs-lookup"><span data-stu-id="0b995-204">Response body</span></span>
 
<span data-ttu-id="0b995-205">HTTP ステータス コード 200 メタデータの更新が成功時が返されます。</span><span class="sxs-lookup"><span data-stu-id="0b995-205">Upon successful update of the metadata an HTTP status code of 200 will be returned.</span></span>
 
<span data-ttu-id="0b995-206">それ以外の場合、適切な HTTP ステータス コードを JSON 形式で ServiceErrorResponse オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="0b995-206">Otherwise a ServiceErrorResponse object in JSON format will be returned with an appropriate HTTP status code.</span></span>
  
<a id="ID4EWBAC"></a>

 
## <a name="related-uris"></a><span data-ttu-id="0b995-207">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="0b995-207">Related URIs</span></span>
 
<span data-ttu-id="0b995-208">次の Uri は、メタデータのパブリック フィールドを更新します。</span><span class="sxs-lookup"><span data-stu-id="0b995-208">The following URIs update public fields in the metadata.</span></span> <span data-ttu-id="0b995-209">これらの要求に必要な本文はありません。</span><span class="sxs-lookup"><span data-stu-id="0b995-209">There is no body required for these requests.</span></span> <span data-ttu-id="0b995-210">HTTP ステータス コード 200 メタデータの更新が成功時が返されます。</span><span class="sxs-lookup"><span data-stu-id="0b995-210">Upon successful update of the metadata an HTTP status code of 200 will be returned.</span></span> <span data-ttu-id="0b995-211">それ以外の場合、適切な HTTP ステータス コードを JSON 形式で ServiceErrorResponse オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="0b995-211">Otherwise a ServiceErrorResponse object in JSON format will be returned with an appropriate HTTP status code.</span></span>
 
   * <span data-ttu-id="0b995-212">**POST/users/{ownerId} {scid}/scids//clips/{gameClipId}/ratings/{評価値}** - には、指定したクリップに指定した評価が適用されます。</span><span class="sxs-lookup"><span data-stu-id="0b995-212">**POST /users/{ownerId}/scids/{scid}/clips/{gameClipId}/ratings/{rating value}** - applies the specified rating to the specified clip.</span></span> <span data-ttu-id="0b995-213">評価値 1 ~ 5 間整数である必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b995-213">Rating Value should be an integer between 1 and 5.</span></span>
   * <span data-ttu-id="0b995-214">**投稿/users/{ownerId} {scid}/scids//clips/{gameClipId}/フラグ**- フラグのクリップを強制をチェックする可能性のある問題のあるコンテンツが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0b995-214">**POST /users/{ownerId}/scids/{scid}/clips/{gameClipId}/flag** - flags the clip to contain potentially questionable content to be checked by enforcement.</span></span>
   * <span data-ttu-id="0b995-215">**POST/users/{ownerId} {scid}/scids//clips/{gameClipId} ビュー/** -指定されたゲーム クリップのビューのカウントをインクリメントします。</span><span class="sxs-lookup"><span data-stu-id="0b995-215">**POST /users/{ownerId}/scids/{scid}/clips/{gameClipId}/views** - increments the view count for the specified game clip.</span></span> <span data-ttu-id="0b995-216">これはという名前のない適切な再生の 75%-80% が完了したとき、再生が開始されるをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0b995-216">It is recommended that this is called not right when playback is started, but when 75%-80% of playback has been completed.</span></span>
   
<a id="ID4EMCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="0b995-217">関連項目</span><span class="sxs-lookup"><span data-stu-id="0b995-217">See also</span></span>
 
<a id="ID4EOCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="0b995-218">Parent</span><span class="sxs-lookup"><span data-stu-id="0b995-218">Parent</span></span> 

[<span data-ttu-id="0b995-219">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="0b995-219">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

   