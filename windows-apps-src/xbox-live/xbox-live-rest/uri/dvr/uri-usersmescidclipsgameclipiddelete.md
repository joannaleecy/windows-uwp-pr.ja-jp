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
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4258576"
---
# <a name="delete-usersmescidsscidclipsgameclipid"></a><span data-ttu-id="e72ca-104">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="e72ca-104">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="e72ca-105">これらの Uri のドメインは、ゲーム クリップを削除`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`問題の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-105">Delete game clip The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="e72ca-106">注釈</span><span class="sxs-lookup"><span data-stu-id="e72ca-106">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="e72ca-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e72ca-107">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="e72ca-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="e72ca-108">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="e72ca-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-109">Required Request Headers</span></span>](#ID4EYB)
  * [<span data-ttu-id="e72ca-110">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-110">Optional Request Headers</span></span>](#ID4EEE)
  * [<span data-ttu-id="e72ca-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="e72ca-111">Request body</span></span>](#ID4ENF)
  * [<span data-ttu-id="e72ca-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="e72ca-112">HTTP status codes</span></span>](#ID4EYF)
  * [<span data-ttu-id="e72ca-113">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-113">Required Response Headers</span></span>](#ID4EIAAC)
  * [<span data-ttu-id="e72ca-114">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-114">Optional Response Headers</span></span>](#ID4E2CAC)
  * [<span data-ttu-id="e72ca-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="e72ca-115">Response body</span></span>](#ID4E2DAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="e72ca-116">注釈</span><span class="sxs-lookup"><span data-stu-id="e72ca-116">Remarks</span></span>
 
<span data-ttu-id="e72ca-117">GameClips サービスからユーザーのビデオを削除するためのメカニズムを提供します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-117">Provides a mechanism for deleting the user's own video from the GameClips service.</span></span> <span data-ttu-id="e72ca-118">削除、時にすべてのメタデータと実際のビデオ アセット (生成されると元) は、システムから削除されます。</span><span class="sxs-lookup"><span data-stu-id="e72ca-118">Upon delete, all metadata and the actual video assets (generated and original) are removed from the system .</span></span> <span data-ttu-id="e72ca-119">これは、永続的な操作です。</span><span class="sxs-lookup"><span data-stu-id="e72ca-119">This is a permanent operation.</span></span> 

> [!NOTE] 
> <span data-ttu-id="e72ca-120">指定された所有者 ID は、正常に削除要求の承認トークンで呼び出し元と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e72ca-120">The owner ID specified must match the caller in the authorization token for the delete request to succeed.</span></span> 


  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e72ca-121">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e72ca-121">URI parameters</span></span>
 
| <span data-ttu-id="e72ca-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e72ca-122">Parameter</span></span>| <span data-ttu-id="e72ca-123">型</span><span class="sxs-lookup"><span data-stu-id="e72ca-123">Type</span></span>| <span data-ttu-id="e72ca-124">説明</span><span class="sxs-lookup"><span data-stu-id="e72ca-124">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="e72ca-125">scid</span><span class="sxs-lookup"><span data-stu-id="e72ca-125">scid</span></span>| <span data-ttu-id="e72ca-126">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-126">string</span></span>| <span data-ttu-id="e72ca-127">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="e72ca-127">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="e72ca-128">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e72ca-128">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="e72ca-129">gameClipId</span><span class="sxs-lookup"><span data-stu-id="e72ca-129">gameClipId</span></span>| <span data-ttu-id="e72ca-130">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-130">string</span></span>| <span data-ttu-id="e72ca-131">ゲーム クリップだったにアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="e72ca-131">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4ENB"></a>

 
## <a name="authorization"></a><span data-ttu-id="e72ca-132">Authorization</span><span class="sxs-lookup"><span data-stu-id="e72ca-132">Authorization</span></span>
 
<span data-ttu-id="e72ca-133">Xuid クレームだけでは、このメソッドに必要です。</span><span class="sxs-lookup"><span data-stu-id="e72ca-133">Only the Xuid claim is required for this method.</span></span>
  
<a id="ID4EYB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="e72ca-134">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-134">Required Request Headers</span></span>
 
| <span data-ttu-id="e72ca-135">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-135">Header</span></span>| <span data-ttu-id="e72ca-136">型</span><span class="sxs-lookup"><span data-stu-id="e72ca-136">Type</span></span>| <span data-ttu-id="e72ca-137">説明</span><span class="sxs-lookup"><span data-stu-id="e72ca-137">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e72ca-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="e72ca-138">Authorization</span></span>| <span data-ttu-id="e72ca-139">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-139">string</span></span>| <span data-ttu-id="e72ca-140">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-140">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="e72ca-141">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="e72ca-141">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="e72ca-142">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="e72ca-142">X-RequestedServiceVersion</span></span>| <span data-ttu-id="e72ca-143">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-143">string</span></span>| <span data-ttu-id="e72ca-144">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="e72ca-144">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="e72ca-145">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-145">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="e72ca-146">Content-Type</span><span class="sxs-lookup"><span data-stu-id="e72ca-146">Content-Type</span></span>| <span data-ttu-id="e72ca-147">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-147">string</span></span>| <span data-ttu-id="e72ca-148">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="e72ca-148">MIME type of the response body.</span></span> <span data-ttu-id="e72ca-149">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-149">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="e72ca-150">Accept</span><span class="sxs-lookup"><span data-stu-id="e72ca-150">Accept</span></span>| <span data-ttu-id="e72ca-151">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-151">string</span></span>| <span data-ttu-id="e72ca-152">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="e72ca-152">Acceptable values of Content-Type.</span></span> <span data-ttu-id="e72ca-153">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-153">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="e72ca-154">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="e72ca-154">Cache-Control</span></span>| <span data-ttu-id="e72ca-155">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-155">string</span></span>| <span data-ttu-id="e72ca-156">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-156">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EEE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="e72ca-157">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-157">Optional Request Headers</span></span>
 
| <span data-ttu-id="e72ca-158">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-158">Header</span></span>| <span data-ttu-id="e72ca-159">型</span><span class="sxs-lookup"><span data-stu-id="e72ca-159">Type</span></span>| <span data-ttu-id="e72ca-160">説明</span><span class="sxs-lookup"><span data-stu-id="e72ca-160">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e72ca-161">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="e72ca-161">Accept-Encoding</span></span>| <span data-ttu-id="e72ca-162">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-162">string</span></span>| <span data-ttu-id="e72ca-163">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="e72ca-163">Acceptable compression encodings.</span></span> <span data-ttu-id="e72ca-164">値の例: gzip、圧縮を識別します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-164">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="e72ca-165">ETag</span><span class="sxs-lookup"><span data-stu-id="e72ca-165">ETag</span></span>| <span data-ttu-id="e72ca-166">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-166">string</span></span>| <span data-ttu-id="e72ca-167">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-167">Used for cache optimization.</span></span> <span data-ttu-id="e72ca-168">値の例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="e72ca-168">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4ENF"></a>

 
## <a name="request-body"></a><span data-ttu-id="e72ca-169">要求本文</span><span class="sxs-lookup"><span data-stu-id="e72ca-169">Request body</span></span>
 
<span data-ttu-id="e72ca-170">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e72ca-170">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EYF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="e72ca-171">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="e72ca-171">HTTP status codes</span></span>
 
<span data-ttu-id="e72ca-172">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-172">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="e72ca-173">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e72ca-173">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="e72ca-174">コード</span><span class="sxs-lookup"><span data-stu-id="e72ca-174">Code</span></span>| <span data-ttu-id="e72ca-175">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="e72ca-175">Reason phrase</span></span>| <span data-ttu-id="e72ca-176">説明</span><span class="sxs-lookup"><span data-stu-id="e72ca-176">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e72ca-177">204</span><span class="sxs-lookup"><span data-stu-id="e72ca-177">204</span></span>| <span data-ttu-id="e72ca-178">OK</span><span class="sxs-lookup"><span data-stu-id="e72ca-178">OK</span></span>| <span data-ttu-id="e72ca-179">クリップが正常に削除します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-179">Successful deletion of the clip.</span></span>| 
| <span data-ttu-id="e72ca-180">401</span><span class="sxs-lookup"><span data-stu-id="e72ca-180">401</span></span>| <span data-ttu-id="e72ca-181">権限がありません</span><span class="sxs-lookup"><span data-stu-id="e72ca-181">Unauthorized</span></span>| <span data-ttu-id="e72ca-182">要求の認証トークンの形式で問題があります。</span><span class="sxs-lookup"><span data-stu-id="e72ca-182">There is a problem with the auth token format in the request.</span></span>| 
| <span data-ttu-id="e72ca-183">403</span><span class="sxs-lookup"><span data-stu-id="e72ca-183">403</span></span>| <span data-ttu-id="e72ca-184">Forbidden</span><span class="sxs-lookup"><span data-stu-id="e72ca-184">Forbidden</span></span>| <span data-ttu-id="e72ca-185">一部の必須の要求は含まれていません。</span><span class="sxs-lookup"><span data-stu-id="e72ca-185">Some required claims are missing.</span></span>| 
| <span data-ttu-id="e72ca-186">404</span><span class="sxs-lookup"><span data-stu-id="e72ca-186">404</span></span>| <span data-ttu-id="e72ca-187">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-187">Not Found</span></span>| <span data-ttu-id="e72ca-188">URL に指定されているクリップが存在しませんでした (または 2 つ目の時間を削除されました)。</span><span class="sxs-lookup"><span data-stu-id="e72ca-188">The clip specified in the URL was not present (or it was deleted a second time).</span></span>| 
| <span data-ttu-id="e72ca-189">503</span><span class="sxs-lookup"><span data-stu-id="e72ca-189">503</span></span>| <span data-ttu-id="e72ca-190">許容できません。</span><span class="sxs-lookup"><span data-stu-id="e72ca-190">Not Acceptable</span></span>| <span data-ttu-id="e72ca-191">サービスまたはダウン ストリームの依存関係はいくつかダウンしています。</span><span class="sxs-lookup"><span data-stu-id="e72ca-191">The service or some downstream dependencies are down.</span></span> <span data-ttu-id="e72ca-192">標準のバックオフ動作を指定して再試行します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-192">Retry with standard back-off behavior.</span></span>| 
  
<a id="ID4EIAAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="e72ca-193">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-193">Required Response Headers</span></span>
 
| <span data-ttu-id="e72ca-194">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-194">Header</span></span>| <span data-ttu-id="e72ca-195">型</span><span class="sxs-lookup"><span data-stu-id="e72ca-195">Type</span></span>| <span data-ttu-id="e72ca-196">説明</span><span class="sxs-lookup"><span data-stu-id="e72ca-196">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e72ca-197">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="e72ca-197">X-RequestedServiceVersion</span></span>| <span data-ttu-id="e72ca-198">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-198">string</span></span>| <span data-ttu-id="e72ca-199">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="e72ca-199">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="e72ca-200">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-200">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="e72ca-201">Content-Type</span><span class="sxs-lookup"><span data-stu-id="e72ca-201">Content-Type</span></span>| <span data-ttu-id="e72ca-202">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-202">string</span></span>| <span data-ttu-id="e72ca-203">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="e72ca-203">MIME type of the response body.</span></span> <span data-ttu-id="e72ca-204">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-204">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="e72ca-205">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="e72ca-205">Cache-Control</span></span>| <span data-ttu-id="e72ca-206">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-206">string</span></span>| <span data-ttu-id="e72ca-207">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-207">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="e72ca-208">Accept</span><span class="sxs-lookup"><span data-stu-id="e72ca-208">Accept</span></span>| <span data-ttu-id="e72ca-209">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-209">string</span></span>| <span data-ttu-id="e72ca-210">コンテンツの種類の許容値です。</span><span class="sxs-lookup"><span data-stu-id="e72ca-210">Acceptable values of Content-Type.</span></span> <span data-ttu-id="e72ca-211">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-211">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="e72ca-212">Retry-after</span><span class="sxs-lookup"><span data-stu-id="e72ca-212">Retry-After</span></span>| <span data-ttu-id="e72ca-213">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-213">string</span></span>| <span data-ttu-id="e72ca-214">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-214">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="e72ca-215">異なる</span><span class="sxs-lookup"><span data-stu-id="e72ca-215">Vary</span></span>| <span data-ttu-id="e72ca-216">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-216">string</span></span>| <span data-ttu-id="e72ca-217">下位のプロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-217">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4E2CAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="e72ca-218">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-218">Optional Response Headers</span></span>
 
| <span data-ttu-id="e72ca-219">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e72ca-219">Header</span></span>| <span data-ttu-id="e72ca-220">型</span><span class="sxs-lookup"><span data-stu-id="e72ca-220">Type</span></span>| <span data-ttu-id="e72ca-221">説明</span><span class="sxs-lookup"><span data-stu-id="e72ca-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e72ca-222">Etag</span><span class="sxs-lookup"><span data-stu-id="e72ca-222">Etag</span></span>| <span data-ttu-id="e72ca-223">string</span><span class="sxs-lookup"><span data-stu-id="e72ca-223">string</span></span>| <span data-ttu-id="e72ca-224">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-224">Used for cache optimization.</span></span> <span data-ttu-id="e72ca-225">例:"686897696a7c876b7e"です。</span><span class="sxs-lookup"><span data-stu-id="e72ca-225">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4E2DAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="e72ca-226">応答本文</span><span class="sxs-lookup"><span data-stu-id="e72ca-226">Response body</span></span>
 
<span data-ttu-id="e72ca-227">サービスが成功すると、204 (No content) の HTTP ステータス コードで応答します。</span><span class="sxs-lookup"><span data-stu-id="e72ca-227">The service will respond with an HTTP status code of 204 (No content) upon success.</span></span> <span data-ttu-id="e72ca-228">しようとして、同じオブジェクトを削除するか、存在しないオブジェクトに 404 が返されます。</span><span class="sxs-lookup"><span data-stu-id="e72ca-228">Trying to delete the same object or a non-existent object will return 404.</span></span>
 
<span data-ttu-id="e72ca-229">エラー発生時**ServiceErrorResponse**オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="e72ca-229">In case of errors, a **ServiceErrorResponse** object will be returned.</span></span>
  
<a id="ID4EJEAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e72ca-230">関連項目</span><span class="sxs-lookup"><span data-stu-id="e72ca-230">See also</span></span>
 
<a id="ID4ELEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e72ca-231">Parent</span><span class="sxs-lookup"><span data-stu-id="e72ca-231">Parent</span></span> 

[<span data-ttu-id="e72ca-232">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="e72ca-232">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

   