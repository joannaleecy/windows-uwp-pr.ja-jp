---
title: DELETE (/users/me/scids/{scid}/clips/{gameClipId})
assetID: 486fac60-6884-2e3f-9ef8-8de5da0ad8af
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipiddelete.html
author: KevinAsgari
description: " DELETE (/users/me/scids/{scid}/clips/{gameClipId})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a68d765cfdec81da064b0522ea2ff9a4be12bafb
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4155042"
---
# <a name="delete-usersmescidsscidclipsgameclipid"></a><span data-ttu-id="4fd06-104">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="4fd06-104">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="4fd06-105">これらの Uri のドメインは、ゲーム クリップを削除`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`問題の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-105">Delete game clip The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="4fd06-106">注釈</span><span class="sxs-lookup"><span data-stu-id="4fd06-106">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="4fd06-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4fd06-107">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="4fd06-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="4fd06-108">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="4fd06-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-109">Required Request Headers</span></span>](#ID4EYB)
  * [<span data-ttu-id="4fd06-110">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-110">Optional Request Headers</span></span>](#ID4EEE)
  * [<span data-ttu-id="4fd06-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="4fd06-111">Request body</span></span>](#ID4ENF)
  * [<span data-ttu-id="4fd06-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="4fd06-112">HTTP status codes</span></span>](#ID4EYF)
  * [<span data-ttu-id="4fd06-113">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-113">Required Response Headers</span></span>](#ID4EIAAC)
  * [<span data-ttu-id="4fd06-114">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-114">Optional Response Headers</span></span>](#ID4E2CAC)
  * [<span data-ttu-id="4fd06-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="4fd06-115">Response body</span></span>](#ID4E2DAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="4fd06-116">注釈</span><span class="sxs-lookup"><span data-stu-id="4fd06-116">Remarks</span></span>
 
<span data-ttu-id="4fd06-117">GameClips サービスからユーザーのビデオを削除するためのメカニズムを提供します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-117">Provides a mechanism for deleting the user's own video from the GameClips service.</span></span> <span data-ttu-id="4fd06-118">削除、時にすべてのメタデータと実際のビデオ アセット (生成されると元) は、システムから削除されます。</span><span class="sxs-lookup"><span data-stu-id="4fd06-118">Upon delete, all metadata and the actual video assets (generated and original) are removed from the system .</span></span> <span data-ttu-id="4fd06-119">これは、永続的な操作です。</span><span class="sxs-lookup"><span data-stu-id="4fd06-119">This is a permanent operation.</span></span> 

> [!NOTE] 
> <span data-ttu-id="4fd06-120">指定された所有者 ID は、正常に削除要求の承認トークンで呼び出し元と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4fd06-120">The owner ID specified must match the caller in the authorization token for the delete request to succeed.</span></span> 


  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="4fd06-121">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4fd06-121">URI parameters</span></span>
 
| <span data-ttu-id="4fd06-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4fd06-122">Parameter</span></span>| <span data-ttu-id="4fd06-123">型</span><span class="sxs-lookup"><span data-stu-id="4fd06-123">Type</span></span>| <span data-ttu-id="4fd06-124">説明</span><span class="sxs-lookup"><span data-stu-id="4fd06-124">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="4fd06-125">scid</span><span class="sxs-lookup"><span data-stu-id="4fd06-125">scid</span></span>| <span data-ttu-id="4fd06-126">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-126">string</span></span>| <span data-ttu-id="4fd06-127">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="4fd06-127">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="4fd06-128">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4fd06-128">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="4fd06-129">gameClipId</span><span class="sxs-lookup"><span data-stu-id="4fd06-129">gameClipId</span></span>| <span data-ttu-id="4fd06-130">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-130">string</span></span>| <span data-ttu-id="4fd06-131">ゲーム クリップだったにアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="4fd06-131">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4ENB"></a>

 
## <a name="authorization"></a><span data-ttu-id="4fd06-132">Authorization</span><span class="sxs-lookup"><span data-stu-id="4fd06-132">Authorization</span></span>
 
<span data-ttu-id="4fd06-133">Xuid クレームだけでは、このメソッドに必要です。</span><span class="sxs-lookup"><span data-stu-id="4fd06-133">Only the Xuid claim is required for this method.</span></span>
  
<a id="ID4EYB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="4fd06-134">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-134">Required Request Headers</span></span>
 
| <span data-ttu-id="4fd06-135">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-135">Header</span></span>| <span data-ttu-id="4fd06-136">型</span><span class="sxs-lookup"><span data-stu-id="4fd06-136">Type</span></span>| <span data-ttu-id="4fd06-137">説明</span><span class="sxs-lookup"><span data-stu-id="4fd06-137">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="4fd06-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="4fd06-138">Authorization</span></span>| <span data-ttu-id="4fd06-139">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-139">string</span></span>| <span data-ttu-id="4fd06-140">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-140">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="4fd06-141">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="4fd06-141">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="4fd06-142">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="4fd06-142">X-RequestedServiceVersion</span></span>| <span data-ttu-id="4fd06-143">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-143">string</span></span>| <span data-ttu-id="4fd06-144">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="4fd06-144">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="4fd06-145">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-145">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="4fd06-146">Content-Type</span><span class="sxs-lookup"><span data-stu-id="4fd06-146">Content-Type</span></span>| <span data-ttu-id="4fd06-147">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-147">string</span></span>| <span data-ttu-id="4fd06-148">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="4fd06-148">MIME type of the response body.</span></span> <span data-ttu-id="4fd06-149">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-149">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="4fd06-150">Accept</span><span class="sxs-lookup"><span data-stu-id="4fd06-150">Accept</span></span>| <span data-ttu-id="4fd06-151">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-151">string</span></span>| <span data-ttu-id="4fd06-152">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="4fd06-152">Acceptable values of Content-Type.</span></span> <span data-ttu-id="4fd06-153">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-153">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="4fd06-154">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="4fd06-154">Cache-Control</span></span>| <span data-ttu-id="4fd06-155">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-155">string</span></span>| <span data-ttu-id="4fd06-156">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-156">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EEE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="4fd06-157">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-157">Optional Request Headers</span></span>
 
| <span data-ttu-id="4fd06-158">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-158">Header</span></span>| <span data-ttu-id="4fd06-159">型</span><span class="sxs-lookup"><span data-stu-id="4fd06-159">Type</span></span>| <span data-ttu-id="4fd06-160">説明</span><span class="sxs-lookup"><span data-stu-id="4fd06-160">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="4fd06-161">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="4fd06-161">Accept-Encoding</span></span>| <span data-ttu-id="4fd06-162">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-162">string</span></span>| <span data-ttu-id="4fd06-163">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="4fd06-163">Acceptable compression encodings.</span></span> <span data-ttu-id="4fd06-164">値の例: gzip、圧縮を識別します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-164">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="4fd06-165">ETag</span><span class="sxs-lookup"><span data-stu-id="4fd06-165">ETag</span></span>| <span data-ttu-id="4fd06-166">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-166">string</span></span>| <span data-ttu-id="4fd06-167">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-167">Used for cache optimization.</span></span> <span data-ttu-id="4fd06-168">値の例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="4fd06-168">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4ENF"></a>

 
## <a name="request-body"></a><span data-ttu-id="4fd06-169">要求本文</span><span class="sxs-lookup"><span data-stu-id="4fd06-169">Request body</span></span>
 
<span data-ttu-id="4fd06-170">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="4fd06-170">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EYF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="4fd06-171">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="4fd06-171">HTTP status codes</span></span>
 
<span data-ttu-id="4fd06-172">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-172">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="4fd06-173">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4fd06-173">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="4fd06-174">コード</span><span class="sxs-lookup"><span data-stu-id="4fd06-174">Code</span></span>| <span data-ttu-id="4fd06-175">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="4fd06-175">Reason phrase</span></span>| <span data-ttu-id="4fd06-176">説明</span><span class="sxs-lookup"><span data-stu-id="4fd06-176">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="4fd06-177">204</span><span class="sxs-lookup"><span data-stu-id="4fd06-177">204</span></span>| <span data-ttu-id="4fd06-178">OK</span><span class="sxs-lookup"><span data-stu-id="4fd06-178">OK</span></span>| <span data-ttu-id="4fd06-179">クリップが正常に削除します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-179">Successful deletion of the clip.</span></span>| 
| <span data-ttu-id="4fd06-180">401</span><span class="sxs-lookup"><span data-stu-id="4fd06-180">401</span></span>| <span data-ttu-id="4fd06-181">権限がありません</span><span class="sxs-lookup"><span data-stu-id="4fd06-181">Unauthorized</span></span>| <span data-ttu-id="4fd06-182">要求の認証トークンの形式で問題があります。</span><span class="sxs-lookup"><span data-stu-id="4fd06-182">There is a problem with the auth token format in the request.</span></span>| 
| <span data-ttu-id="4fd06-183">403</span><span class="sxs-lookup"><span data-stu-id="4fd06-183">403</span></span>| <span data-ttu-id="4fd06-184">Forbidden</span><span class="sxs-lookup"><span data-stu-id="4fd06-184">Forbidden</span></span>| <span data-ttu-id="4fd06-185">一部の必須の要求は含まれていません。</span><span class="sxs-lookup"><span data-stu-id="4fd06-185">Some required claims are missing.</span></span>| 
| <span data-ttu-id="4fd06-186">404</span><span class="sxs-lookup"><span data-stu-id="4fd06-186">404</span></span>| <span data-ttu-id="4fd06-187">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-187">Not Found</span></span>| <span data-ttu-id="4fd06-188">URL に指定されているクリップが存在しませんでした (または 2 つ目の時間を削除されました)。</span><span class="sxs-lookup"><span data-stu-id="4fd06-188">The clip specified in the URL was not present (or it was deleted a second time).</span></span>| 
| <span data-ttu-id="4fd06-189">503</span><span class="sxs-lookup"><span data-stu-id="4fd06-189">503</span></span>| <span data-ttu-id="4fd06-190">許容できません。</span><span class="sxs-lookup"><span data-stu-id="4fd06-190">Not Acceptable</span></span>| <span data-ttu-id="4fd06-191">サービスまたはダウン ストリームの依存関係はいくつかダウンしています。</span><span class="sxs-lookup"><span data-stu-id="4fd06-191">The service or some downstream dependencies are down.</span></span> <span data-ttu-id="4fd06-192">標準のバックオフ動作を指定して再試行します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-192">Retry with standard back-off behavior.</span></span>| 
  
<a id="ID4EIAAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="4fd06-193">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-193">Required Response Headers</span></span>
 
| <span data-ttu-id="4fd06-194">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-194">Header</span></span>| <span data-ttu-id="4fd06-195">型</span><span class="sxs-lookup"><span data-stu-id="4fd06-195">Type</span></span>| <span data-ttu-id="4fd06-196">説明</span><span class="sxs-lookup"><span data-stu-id="4fd06-196">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="4fd06-197">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="4fd06-197">X-RequestedServiceVersion</span></span>| <span data-ttu-id="4fd06-198">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-198">string</span></span>| <span data-ttu-id="4fd06-199">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="4fd06-199">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="4fd06-200">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-200">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="4fd06-201">Content-Type</span><span class="sxs-lookup"><span data-stu-id="4fd06-201">Content-Type</span></span>| <span data-ttu-id="4fd06-202">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-202">string</span></span>| <span data-ttu-id="4fd06-203">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="4fd06-203">MIME type of the response body.</span></span> <span data-ttu-id="4fd06-204">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-204">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="4fd06-205">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="4fd06-205">Cache-Control</span></span>| <span data-ttu-id="4fd06-206">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-206">string</span></span>| <span data-ttu-id="4fd06-207">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-207">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="4fd06-208">Accept</span><span class="sxs-lookup"><span data-stu-id="4fd06-208">Accept</span></span>| <span data-ttu-id="4fd06-209">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-209">string</span></span>| <span data-ttu-id="4fd06-210">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="4fd06-210">Acceptable values of Content-Type.</span></span> <span data-ttu-id="4fd06-211">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-211">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="4fd06-212">Retry-after</span><span class="sxs-lookup"><span data-stu-id="4fd06-212">Retry-After</span></span>| <span data-ttu-id="4fd06-213">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-213">string</span></span>| <span data-ttu-id="4fd06-214">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-214">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="4fd06-215">異なる</span><span class="sxs-lookup"><span data-stu-id="4fd06-215">Vary</span></span>| <span data-ttu-id="4fd06-216">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-216">string</span></span>| <span data-ttu-id="4fd06-217">下位のプロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-217">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4E2CAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="4fd06-218">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-218">Optional Response Headers</span></span>
 
| <span data-ttu-id="4fd06-219">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4fd06-219">Header</span></span>| <span data-ttu-id="4fd06-220">型</span><span class="sxs-lookup"><span data-stu-id="4fd06-220">Type</span></span>| <span data-ttu-id="4fd06-221">説明</span><span class="sxs-lookup"><span data-stu-id="4fd06-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="4fd06-222">Etag</span><span class="sxs-lookup"><span data-stu-id="4fd06-222">Etag</span></span>| <span data-ttu-id="4fd06-223">string</span><span class="sxs-lookup"><span data-stu-id="4fd06-223">string</span></span>| <span data-ttu-id="4fd06-224">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-224">Used for cache optimization.</span></span> <span data-ttu-id="4fd06-225">例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="4fd06-225">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4E2DAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="4fd06-226">応答本文</span><span class="sxs-lookup"><span data-stu-id="4fd06-226">Response body</span></span>
 
<span data-ttu-id="4fd06-227">サービスが成功すると、204 (No content) の HTTP ステータス コードで応答します。</span><span class="sxs-lookup"><span data-stu-id="4fd06-227">The service will respond with an HTTP status code of 204 (No content) upon success.</span></span> <span data-ttu-id="4fd06-228">しようとして、同じオブジェクトを削除するか、存在しないオブジェクトに 404 が返されます。</span><span class="sxs-lookup"><span data-stu-id="4fd06-228">Trying to delete the same object or a non-existent object will return 404.</span></span>
 
<span data-ttu-id="4fd06-229">エラー発生時**ServiceErrorResponse**オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="4fd06-229">In case of errors, a **ServiceErrorResponse** object will be returned.</span></span>
  
<a id="ID4EJEAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="4fd06-230">関連項目</span><span class="sxs-lookup"><span data-stu-id="4fd06-230">See also</span></span>
 
<a id="ID4ELEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="4fd06-231">Parent</span><span class="sxs-lookup"><span data-stu-id="4fd06-231">Parent</span></span> 

[<span data-ttu-id="4fd06-232">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="4fd06-232">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

   