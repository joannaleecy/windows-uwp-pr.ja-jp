---
title: DELETE (/users/me/scids/{scid}/clips/{gameClipId})
assetID: 486fac60-6884-2e3f-9ef8-8de5da0ad8af
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipiddelete.html
author: KevinAsgari
description: " DELETE (/users/me/scids/{scid}/clips/{gameClipId})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 04083701697bd799ed11e0ae31952256a70b1ac3
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5768054"
---
# <a name="delete-usersmescidsscidclipsgameclipid"></a><span data-ttu-id="af5e6-104">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="af5e6-104">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="af5e6-105">これらの Uri のドメインは、ゲーム クリップを削除`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-105">Delete game clip The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="af5e6-106">注釈</span><span class="sxs-lookup"><span data-stu-id="af5e6-106">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="af5e6-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="af5e6-107">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="af5e6-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="af5e6-108">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="af5e6-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-109">Required Request Headers</span></span>](#ID4EYB)
  * [<span data-ttu-id="af5e6-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-110">Optional Request Headers</span></span>](#ID4EEE)
  * [<span data-ttu-id="af5e6-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="af5e6-111">Request body</span></span>](#ID4ENF)
  * [<span data-ttu-id="af5e6-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="af5e6-112">HTTP status codes</span></span>](#ID4EYF)
  * [<span data-ttu-id="af5e6-113">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-113">Required Response Headers</span></span>](#ID4EIAAC)
  * [<span data-ttu-id="af5e6-114">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-114">Optional Response Headers</span></span>](#ID4E2CAC)
  * [<span data-ttu-id="af5e6-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="af5e6-115">Response body</span></span>](#ID4E2DAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="af5e6-116">注釈</span><span class="sxs-lookup"><span data-stu-id="af5e6-116">Remarks</span></span>
 
<span data-ttu-id="af5e6-117">GameClips サービスからユーザーのビデオを削除するためのメカニズムを提供します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-117">Provides a mechanism for deleting the user's own video from the GameClips service.</span></span> <span data-ttu-id="af5e6-118">削除、時にすべてのメタデータと実際のビデオ アセット (生成されると元) は、システムから削除されます。</span><span class="sxs-lookup"><span data-stu-id="af5e6-118">Upon delete, all metadata and the actual video assets (generated and original) are removed from the system .</span></span> <span data-ttu-id="af5e6-119">これは、永続的な操作です。</span><span class="sxs-lookup"><span data-stu-id="af5e6-119">This is a permanent operation.</span></span> 

> [!NOTE] 
> <span data-ttu-id="af5e6-120">指定された所有者 ID は、削除が成功する要求の承認トークンで呼び出し元と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="af5e6-120">The owner ID specified must match the caller in the authorization token for the delete request to succeed.</span></span> 


  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="af5e6-121">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="af5e6-121">URI parameters</span></span>
 
| <span data-ttu-id="af5e6-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="af5e6-122">Parameter</span></span>| <span data-ttu-id="af5e6-123">型</span><span class="sxs-lookup"><span data-stu-id="af5e6-123">Type</span></span>| <span data-ttu-id="af5e6-124">説明</span><span class="sxs-lookup"><span data-stu-id="af5e6-124">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="af5e6-125">scid</span><span class="sxs-lookup"><span data-stu-id="af5e6-125">scid</span></span>| <span data-ttu-id="af5e6-126">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-126">string</span></span>| <span data-ttu-id="af5e6-127">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="af5e6-127">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="af5e6-128">認証されたユーザーの SCID が一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="af5e6-128">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="af5e6-129">gameClipId</span><span class="sxs-lookup"><span data-stu-id="af5e6-129">gameClipId</span></span>| <span data-ttu-id="af5e6-130">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-130">string</span></span>| <span data-ttu-id="af5e6-131">GameClip にアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="af5e6-131">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4ENB"></a>

 
## <a name="authorization"></a><span data-ttu-id="af5e6-132">Authorization</span><span class="sxs-lookup"><span data-stu-id="af5e6-132">Authorization</span></span>
 
<span data-ttu-id="af5e6-133">Xuid クレームだけでは、このメソッドに必要です。</span><span class="sxs-lookup"><span data-stu-id="af5e6-133">Only the Xuid claim is required for this method.</span></span>
  
<a id="ID4EYB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="af5e6-134">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-134">Required Request Headers</span></span>
 
| <span data-ttu-id="af5e6-135">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-135">Header</span></span>| <span data-ttu-id="af5e6-136">型</span><span class="sxs-lookup"><span data-stu-id="af5e6-136">Type</span></span>| <span data-ttu-id="af5e6-137">説明</span><span class="sxs-lookup"><span data-stu-id="af5e6-137">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="af5e6-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="af5e6-138">Authorization</span></span>| <span data-ttu-id="af5e6-139">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-139">string</span></span>| <span data-ttu-id="af5e6-140">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-140">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="af5e6-141">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="af5e6-141">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="af5e6-142">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="af5e6-142">X-RequestedServiceVersion</span></span>| <span data-ttu-id="af5e6-143">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-143">string</span></span>| <span data-ttu-id="af5e6-144">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="af5e6-144">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="af5e6-145">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-145">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="af5e6-146">Content-Type</span><span class="sxs-lookup"><span data-stu-id="af5e6-146">Content-Type</span></span>| <span data-ttu-id="af5e6-147">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-147">string</span></span>| <span data-ttu-id="af5e6-148">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="af5e6-148">MIME type of the response body.</span></span> <span data-ttu-id="af5e6-149">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-149">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="af5e6-150">Accept</span><span class="sxs-lookup"><span data-stu-id="af5e6-150">Accept</span></span>| <span data-ttu-id="af5e6-151">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-151">string</span></span>| <span data-ttu-id="af5e6-152">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="af5e6-152">Acceptable values of Content-Type.</span></span> <span data-ttu-id="af5e6-153">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-153">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="af5e6-154">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="af5e6-154">Cache-Control</span></span>| <span data-ttu-id="af5e6-155">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-155">string</span></span>| <span data-ttu-id="af5e6-156">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-156">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EEE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="af5e6-157">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-157">Optional Request Headers</span></span>
 
| <span data-ttu-id="af5e6-158">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-158">Header</span></span>| <span data-ttu-id="af5e6-159">型</span><span class="sxs-lookup"><span data-stu-id="af5e6-159">Type</span></span>| <span data-ttu-id="af5e6-160">説明</span><span class="sxs-lookup"><span data-stu-id="af5e6-160">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="af5e6-161">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="af5e6-161">Accept-Encoding</span></span>| <span data-ttu-id="af5e6-162">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-162">string</span></span>| <span data-ttu-id="af5e6-163">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="af5e6-163">Acceptable compression encodings.</span></span> <span data-ttu-id="af5e6-164">値の例: gzip、圧縮の id。</span><span class="sxs-lookup"><span data-stu-id="af5e6-164">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="af5e6-165">ETag</span><span class="sxs-lookup"><span data-stu-id="af5e6-165">ETag</span></span>| <span data-ttu-id="af5e6-166">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-166">string</span></span>| <span data-ttu-id="af5e6-167">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-167">Used for cache optimization.</span></span> <span data-ttu-id="af5e6-168">値の例:"686897696a7c876b7e"します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-168">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4ENF"></a>

 
## <a name="request-body"></a><span data-ttu-id="af5e6-169">要求本文</span><span class="sxs-lookup"><span data-stu-id="af5e6-169">Request body</span></span>
 
<span data-ttu-id="af5e6-170">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="af5e6-170">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EYF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="af5e6-171">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="af5e6-171">HTTP status codes</span></span>
 
<span data-ttu-id="af5e6-172">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-172">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="af5e6-173">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="af5e6-173">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="af5e6-174">コード</span><span class="sxs-lookup"><span data-stu-id="af5e6-174">Code</span></span>| <span data-ttu-id="af5e6-175">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="af5e6-175">Reason phrase</span></span>| <span data-ttu-id="af5e6-176">説明</span><span class="sxs-lookup"><span data-stu-id="af5e6-176">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="af5e6-177">204</span><span class="sxs-lookup"><span data-stu-id="af5e6-177">204</span></span>| <span data-ttu-id="af5e6-178">OK</span><span class="sxs-lookup"><span data-stu-id="af5e6-178">OK</span></span>| <span data-ttu-id="af5e6-179">クリップが正常に削除します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-179">Successful deletion of the clip.</span></span>| 
| <span data-ttu-id="af5e6-180">401</span><span class="sxs-lookup"><span data-stu-id="af5e6-180">401</span></span>| <span data-ttu-id="af5e6-181">権限がありません</span><span class="sxs-lookup"><span data-stu-id="af5e6-181">Unauthorized</span></span>| <span data-ttu-id="af5e6-182">要求の認証トークンの形式で問題があります。</span><span class="sxs-lookup"><span data-stu-id="af5e6-182">There is a problem with the auth token format in the request.</span></span>| 
| <span data-ttu-id="af5e6-183">403</span><span class="sxs-lookup"><span data-stu-id="af5e6-183">403</span></span>| <span data-ttu-id="af5e6-184">Forbidden</span><span class="sxs-lookup"><span data-stu-id="af5e6-184">Forbidden</span></span>| <span data-ttu-id="af5e6-185">一部の必須の要求は含まれていません。</span><span class="sxs-lookup"><span data-stu-id="af5e6-185">Some required claims are missing.</span></span>| 
| <span data-ttu-id="af5e6-186">404</span><span class="sxs-lookup"><span data-stu-id="af5e6-186">404</span></span>| <span data-ttu-id="af5e6-187">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-187">Not Found</span></span>| <span data-ttu-id="af5e6-188">URL で指定されているクリップが存在しませんでした (またはもう一度が削除されました)。</span><span class="sxs-lookup"><span data-stu-id="af5e6-188">The clip specified in the URL was not present (or it was deleted a second time).</span></span>| 
| <span data-ttu-id="af5e6-189">503</span><span class="sxs-lookup"><span data-stu-id="af5e6-189">503</span></span>| <span data-ttu-id="af5e6-190">許容できません。</span><span class="sxs-lookup"><span data-stu-id="af5e6-190">Not Acceptable</span></span>| <span data-ttu-id="af5e6-191">サービスまたは一部ダウン ストリームの依存関係ダウンしています。</span><span class="sxs-lookup"><span data-stu-id="af5e6-191">The service or some downstream dependencies are down.</span></span> <span data-ttu-id="af5e6-192">標準的なバックオフ動作を指定して再試行します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-192">Retry with standard back-off behavior.</span></span>| 
  
<a id="ID4EIAAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="af5e6-193">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-193">Required Response Headers</span></span>
 
| <span data-ttu-id="af5e6-194">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-194">Header</span></span>| <span data-ttu-id="af5e6-195">型</span><span class="sxs-lookup"><span data-stu-id="af5e6-195">Type</span></span>| <span data-ttu-id="af5e6-196">説明</span><span class="sxs-lookup"><span data-stu-id="af5e6-196">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="af5e6-197">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="af5e6-197">X-RequestedServiceVersion</span></span>| <span data-ttu-id="af5e6-198">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-198">string</span></span>| <span data-ttu-id="af5e6-199">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="af5e6-199">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="af5e6-200">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-200">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="af5e6-201">Content-Type</span><span class="sxs-lookup"><span data-stu-id="af5e6-201">Content-Type</span></span>| <span data-ttu-id="af5e6-202">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-202">string</span></span>| <span data-ttu-id="af5e6-203">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="af5e6-203">MIME type of the response body.</span></span> <span data-ttu-id="af5e6-204">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-204">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="af5e6-205">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="af5e6-205">Cache-Control</span></span>| <span data-ttu-id="af5e6-206">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-206">string</span></span>| <span data-ttu-id="af5e6-207">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-207">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="af5e6-208">Accept</span><span class="sxs-lookup"><span data-stu-id="af5e6-208">Accept</span></span>| <span data-ttu-id="af5e6-209">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-209">string</span></span>| <span data-ttu-id="af5e6-210">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="af5e6-210">Acceptable values of Content-Type.</span></span> <span data-ttu-id="af5e6-211">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-211">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="af5e6-212">Retry-after</span><span class="sxs-lookup"><span data-stu-id="af5e6-212">Retry-After</span></span>| <span data-ttu-id="af5e6-213">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-213">string</span></span>| <span data-ttu-id="af5e6-214">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-214">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="af5e6-215">異なる</span><span class="sxs-lookup"><span data-stu-id="af5e6-215">Vary</span></span>| <span data-ttu-id="af5e6-216">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-216">string</span></span>| <span data-ttu-id="af5e6-217">下位のプロキシの応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-217">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4E2CAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="af5e6-218">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-218">Optional Response Headers</span></span>
 
| <span data-ttu-id="af5e6-219">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="af5e6-219">Header</span></span>| <span data-ttu-id="af5e6-220">型</span><span class="sxs-lookup"><span data-stu-id="af5e6-220">Type</span></span>| <span data-ttu-id="af5e6-221">説明</span><span class="sxs-lookup"><span data-stu-id="af5e6-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="af5e6-222">Etag</span><span class="sxs-lookup"><span data-stu-id="af5e6-222">Etag</span></span>| <span data-ttu-id="af5e6-223">string</span><span class="sxs-lookup"><span data-stu-id="af5e6-223">string</span></span>| <span data-ttu-id="af5e6-224">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-224">Used for cache optimization.</span></span> <span data-ttu-id="af5e6-225">例:"686897696a7c876b7e"します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-225">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4E2DAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="af5e6-226">応答本文</span><span class="sxs-lookup"><span data-stu-id="af5e6-226">Response body</span></span>
 
<span data-ttu-id="af5e6-227">サービスが 204 (No content)、成功時の HTTP ステータス コードを使って応答します。</span><span class="sxs-lookup"><span data-stu-id="af5e6-227">The service will respond with an HTTP status code of 204 (No content) upon success.</span></span> <span data-ttu-id="af5e6-228">しようとして、同じオブジェクトを削除するか、存在しないオブジェクトに 404 が返されます。</span><span class="sxs-lookup"><span data-stu-id="af5e6-228">Trying to delete the same object or a non-existent object will return 404.</span></span>
 
<span data-ttu-id="af5e6-229">エラー発生時**ServiceErrorResponse**オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="af5e6-229">In case of errors, a **ServiceErrorResponse** object will be returned.</span></span>
  
<a id="ID4EJEAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="af5e6-230">関連項目</span><span class="sxs-lookup"><span data-stu-id="af5e6-230">See also</span></span>
 
<a id="ID4ELEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="af5e6-231">Parent</span><span class="sxs-lookup"><span data-stu-id="af5e6-231">Parent</span></span> 

[<span data-ttu-id="af5e6-232">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="af5e6-232">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

   