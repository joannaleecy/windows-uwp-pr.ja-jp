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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645827"
---
# <a name="post-usersmescidsscidclipsgameclipid"></a><span data-ttu-id="bd1b5-104">POST (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="bd1b5-104">POST (/users/me/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="bd1b5-105">ユーザーのデータのゲームのクリップのメタデータを更新します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-105">Update game clip metadata for the user's own data.</span></span> <span data-ttu-id="bd1b5-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="bd1b5-107">注釈</span><span class="sxs-lookup"><span data-stu-id="bd1b5-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="bd1b5-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bd1b5-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="bd1b5-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd1b5-109">Required Request Headers</span></span>](#ID4ELB)
  * [<span data-ttu-id="bd1b5-110">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd1b5-110">Optional Request Headers</span></span>](#ID4EXD)
  * [<span data-ttu-id="bd1b5-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="bd1b5-111">Request body</span></span>](#ID4EAF)
  * [<span data-ttu-id="bd1b5-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd1b5-112">Required Response Headers</span></span>](#ID4EVF)
  * [<span data-ttu-id="bd1b5-113">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd1b5-113">Optional Response Headers</span></span>](#ID4EJAAC)
  * [<span data-ttu-id="bd1b5-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="bd1b5-114">Response body</span></span>](#ID4EJBAC)
  * [<span data-ttu-id="bd1b5-115">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="bd1b5-115">Related URIs</span></span>](#ID4EWBAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="bd1b5-116">注釈</span><span class="sxs-lookup"><span data-stu-id="bd1b5-116">Remarks</span></span>
 
<span data-ttu-id="bd1b5-117">ゲームのクリップのメタデータを更新するための API は、1 のゲームのクリップ、タイトル、アクセシビリティなどのメタデータを更新、および更新 (評価を適用することや、ビューのカウントをインクリメント) などのパブリック属性の 2 つのカテゴリに分類の他のゲームのクリップの。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-117">The API for updating game clip metadata falls into two categories, updating the metadata of one's own game clips such as accessibility and title, and updating of the public attributes (like applying a rating or incrementing the view count) of any other game clip.</span></span> <span data-ttu-id="bd1b5-118">URI に XUID が、要求で XUID が一致しない場合は、パブリック データのみを編集できるし、他のデータを編集するすべての要求は拒否されます。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-118">If the XUID in the URI does not match the XUID in the claim, only the public data can be edited and any request to edit any of the other data will be denied.</span></span> <span data-ttu-id="bd1b5-119">編集を試行している複数のフィールドの場合とうち 1 つは、要求に対して無効です、全体の要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-119">In the case multiple fields are attempting to be edited and one of them is invalid for the request, the entire request would fail.</span></span>
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bd1b5-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bd1b5-120">URI parameters</span></span>
 
| <span data-ttu-id="bd1b5-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bd1b5-121">Parameter</span></span>| <span data-ttu-id="bd1b5-122">種類</span><span class="sxs-lookup"><span data-stu-id="bd1b5-122">Type</span></span>| <span data-ttu-id="bd1b5-123">説明</span><span class="sxs-lookup"><span data-stu-id="bd1b5-123">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bd1b5-124">scid</span><span class="sxs-lookup"><span data-stu-id="bd1b5-124">scid</span></span>| <span data-ttu-id="bd1b5-125">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-125">string</span></span>| <span data-ttu-id="bd1b5-126">サービス アクセスされているリソースの ID を構成します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-126">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="bd1b5-127">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-127">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="bd1b5-128">gameClipId</span><span class="sxs-lookup"><span data-stu-id="bd1b5-128">gameClipId</span></span>| <span data-ttu-id="bd1b5-129">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-129">string</span></span>| <span data-ttu-id="bd1b5-130">アクセスされているリソースの ID をゲーム クリップだった。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-130">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4ELB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="bd1b5-131">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd1b5-131">Required Request Headers</span></span>
 
| <span data-ttu-id="bd1b5-132">Header</span><span class="sxs-lookup"><span data-stu-id="bd1b5-132">Header</span></span>| <span data-ttu-id="bd1b5-133">種類</span><span class="sxs-lookup"><span data-stu-id="bd1b5-133">Type</span></span>| <span data-ttu-id="bd1b5-134">説明</span><span class="sxs-lookup"><span data-stu-id="bd1b5-134">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bd1b5-135">Authorization</span><span class="sxs-lookup"><span data-stu-id="bd1b5-135">Authorization</span></span>| <span data-ttu-id="bd1b5-136">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-136">string</span></span>| <span data-ttu-id="bd1b5-137">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-137">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="bd1b5-138">値の例:<b>Xauth=&lt;authtoken></b></span><span class="sxs-lookup"><span data-stu-id="bd1b5-138">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="bd1b5-139">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="bd1b5-139">X-RequestedServiceVersion</span></span>| <span data-ttu-id="bd1b5-140">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-140">string</span></span>| <span data-ttu-id="bd1b5-141">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-141">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="bd1b5-142">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-142">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="bd1b5-143">Content-Type</span><span class="sxs-lookup"><span data-stu-id="bd1b5-143">Content-Type</span></span>| <span data-ttu-id="bd1b5-144">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-144">string</span></span>| <span data-ttu-id="bd1b5-145">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-145">MIME type of the response body.</span></span> <span data-ttu-id="bd1b5-146">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-146">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="bd1b5-147">OK</span><span class="sxs-lookup"><span data-stu-id="bd1b5-147">Accept</span></span>| <span data-ttu-id="bd1b5-148">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-148">string</span></span>| <span data-ttu-id="bd1b5-149">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-149">Acceptable values of Content-Type.</span></span> <span data-ttu-id="bd1b5-150">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-150">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="bd1b5-151">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="bd1b5-151">Cache-Control</span></span>| <span data-ttu-id="bd1b5-152">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-152">string</span></span>| <span data-ttu-id="bd1b5-153">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-153">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EXD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="bd1b5-154">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd1b5-154">Optional Request Headers</span></span>
 
| <span data-ttu-id="bd1b5-155">Header</span><span class="sxs-lookup"><span data-stu-id="bd1b5-155">Header</span></span>| <span data-ttu-id="bd1b5-156">種類</span><span class="sxs-lookup"><span data-stu-id="bd1b5-156">Type</span></span>| <span data-ttu-id="bd1b5-157">説明</span><span class="sxs-lookup"><span data-stu-id="bd1b5-157">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bd1b5-158">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="bd1b5-158">Accept-Encoding</span></span>| <span data-ttu-id="bd1b5-159">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-159">string</span></span>| <span data-ttu-id="bd1b5-160">許容される圧縮エンコーディング。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-160">Acceptable compression encodings.</span></span> <span data-ttu-id="bd1b5-161">値の例: gzip、deflate の id。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-161">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="bd1b5-162">ETag</span><span class="sxs-lookup"><span data-stu-id="bd1b5-162">ETag</span></span>| <span data-ttu-id="bd1b5-163">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-163">string</span></span>| <span data-ttu-id="bd1b5-164">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-164">Used for cache optimization.</span></span> <span data-ttu-id="bd1b5-165">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-165">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EAF"></a>

 
## <a name="request-body"></a><span data-ttu-id="bd1b5-166">要求本文</span><span class="sxs-lookup"><span data-stu-id="bd1b5-166">Request body</span></span>
 
<span data-ttu-id="bd1b5-167">要求の本文にする必要があります、 [UpdateMetadataRequest](../../json/json-updatemetadatarequest.md) JSON 形式のオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-167">The body of the request should be an [UpdateMetadataRequest](../../json/json-updatemetadatarequest.md) object in JSON format.</span></span> <span data-ttu-id="bd1b5-168">例:</span><span class="sxs-lookup"><span data-stu-id="bd1b5-168">Examples:</span></span>
 
<span data-ttu-id="bd1b5-169">ユーザーのクリップの名前を変更して、可視性:</span><span class="sxs-lookup"><span data-stu-id="bd1b5-169">Changing User Clip Name and Visibility:</span></span>
 

```cpp
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
<span data-ttu-id="bd1b5-170">(これはほんの一例であるため、このフィールドのスキーマは、呼び出し元) のタイトルのプロパティだけを変更するには。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-170">Changing just title properties (this is just an example, since the schema of this field is up to the caller):</span></span>
 

```cpp
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EVF"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="bd1b5-171">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd1b5-171">Required Response Headers</span></span>
 
| <span data-ttu-id="bd1b5-172">Header</span><span class="sxs-lookup"><span data-stu-id="bd1b5-172">Header</span></span>| <span data-ttu-id="bd1b5-173">種類</span><span class="sxs-lookup"><span data-stu-id="bd1b5-173">Type</span></span>| <span data-ttu-id="bd1b5-174">説明</span><span class="sxs-lookup"><span data-stu-id="bd1b5-174">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bd1b5-175">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="bd1b5-175">X-RequestedServiceVersion</span></span>| <span data-ttu-id="bd1b5-176">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-176">string</span></span>| <span data-ttu-id="bd1b5-177">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-177">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="bd1b5-178">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-178">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="bd1b5-179">Content-Type</span><span class="sxs-lookup"><span data-stu-id="bd1b5-179">Content-Type</span></span>| <span data-ttu-id="bd1b5-180">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-180">string</span></span>| <span data-ttu-id="bd1b5-181">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-181">MIME type of the response body.</span></span> <span data-ttu-id="bd1b5-182">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-182">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="bd1b5-183">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="bd1b5-183">Cache-Control</span></span>| <span data-ttu-id="bd1b5-184">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-184">string</span></span>| <span data-ttu-id="bd1b5-185">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-185">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="bd1b5-186">OK</span><span class="sxs-lookup"><span data-stu-id="bd1b5-186">Accept</span></span>| <span data-ttu-id="bd1b5-187">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-187">string</span></span>| <span data-ttu-id="bd1b5-188">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-188">Acceptable values of Content-Type.</span></span> <span data-ttu-id="bd1b5-189">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-189">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="bd1b5-190">再試行後</span><span class="sxs-lookup"><span data-stu-id="bd1b5-190">Retry-After</span></span>| <span data-ttu-id="bd1b5-191">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-191">string</span></span>| <span data-ttu-id="bd1b5-192">後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-192">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="bd1b5-193">異なる</span><span class="sxs-lookup"><span data-stu-id="bd1b5-193">Vary</span></span>| <span data-ttu-id="bd1b5-194">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-194">string</span></span>| <span data-ttu-id="bd1b5-195">ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-195">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4EJAAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="bd1b5-196">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd1b5-196">Optional Response Headers</span></span>
 
| <span data-ttu-id="bd1b5-197">Header</span><span class="sxs-lookup"><span data-stu-id="bd1b5-197">Header</span></span>| <span data-ttu-id="bd1b5-198">種類</span><span class="sxs-lookup"><span data-stu-id="bd1b5-198">Type</span></span>| <span data-ttu-id="bd1b5-199">説明</span><span class="sxs-lookup"><span data-stu-id="bd1b5-199">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bd1b5-200">Etag</span><span class="sxs-lookup"><span data-stu-id="bd1b5-200">Etag</span></span>| <span data-ttu-id="bd1b5-201">string</span><span class="sxs-lookup"><span data-stu-id="bd1b5-201">string</span></span>| <span data-ttu-id="bd1b5-202">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-202">Used for cache optimization.</span></span> <span data-ttu-id="bd1b5-203">以下に例を示します。"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-203">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EJBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="bd1b5-204">応答本文</span><span class="sxs-lookup"><span data-stu-id="bd1b5-204">Response body</span></span>
 
<span data-ttu-id="bd1b5-205">HTTP 状態コード 200 のメタデータの更新の完了時に返されます。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-205">Upon successful update of the metadata an HTTP status code of 200 will be returned.</span></span>
 
<span data-ttu-id="bd1b5-206">それ以外の場合、適切な HTTP 状態コードで JSON 形式で ServiceErrorResponse オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-206">Otherwise a ServiceErrorResponse object in JSON format will be returned with an appropriate HTTP status code.</span></span>
  
<a id="ID4EWBAC"></a>

 
## <a name="related-uris"></a><span data-ttu-id="bd1b5-207">関連する Uri</span><span class="sxs-lookup"><span data-stu-id="bd1b5-207">Related URIs</span></span>
 
<span data-ttu-id="bd1b5-208">次の Uri は、メタデータにパブリック フィールドを更新します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-208">The following URIs update public fields in the metadata.</span></span> <span data-ttu-id="bd1b5-209">これらの要求に必要な本文はありません。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-209">There is no body required for these requests.</span></span> <span data-ttu-id="bd1b5-210">HTTP 状態コード 200 のメタデータの更新の完了時に返されます。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-210">Upon successful update of the metadata an HTTP status code of 200 will be returned.</span></span> <span data-ttu-id="bd1b5-211">それ以外の場合、適切な HTTP 状態コードで JSON 形式で ServiceErrorResponse オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-211">Otherwise a ServiceErrorResponse object in JSON format will be returned with an appropriate HTTP status code.</span></span>
 
   * <span data-ttu-id="bd1b5-212">**POST/users/{ownerId} {scid}/scids//clips/{gameClipId}/ratings/評価 {value}** -指定したクリップを指定された評価が適用されます。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-212">**POST /users/{ownerId}/scids/{scid}/clips/{gameClipId}/ratings/{rating value}** - applies the specified rating to the specified clip.</span></span> <span data-ttu-id="bd1b5-213">評価の値 1 から 5 まで整数である必要があります。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-213">Rating Value should be an integer between 1 and 5.</span></span>
   * <span data-ttu-id="bd1b5-214">**/Users/{ownerId} {scid}/scids//clips/{gameClipId} を投稿/フラグ**-強制でチェックする可能性のある問題のあるコンテンツを格納するクリップのフラグを設定します。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-214">**POST /users/{ownerId}/scids/{scid}/clips/{gameClipId}/flag** - flags the clip to contain potentially questionable content to be checked by enforcement.</span></span>
   * <span data-ttu-id="bd1b5-215">**POST/users/{ownerId} {scid}/scids//clips/{gameClipId} ビュー/** -指定したゲームのクリップのビューのカウントをインクリメントします。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-215">**POST /users/{ownerId}/scids/{scid}/clips/{gameClipId}/views** - increments the view count for the specified game clip.</span></span> <span data-ttu-id="bd1b5-216">これはという名前のいない適切な再生の 75% ~ 80% が完了したときに再生が開始されるをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="bd1b5-216">It is recommended that this is called not right when playback is started, but when 75%-80% of playback has been completed.</span></span>
   
<a id="ID4EMCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="bd1b5-217">関連項目</span><span class="sxs-lookup"><span data-stu-id="bd1b5-217">See also</span></span>
 
<a id="ID4EOCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bd1b5-218">Parent</span><span class="sxs-lookup"><span data-stu-id="bd1b5-218">Parent</span></span> 

[<span data-ttu-id="bd1b5-219">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="bd1b5-219">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

   