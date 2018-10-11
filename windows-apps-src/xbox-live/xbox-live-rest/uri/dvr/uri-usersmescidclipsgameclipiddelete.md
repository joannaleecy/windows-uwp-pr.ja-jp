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
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4505486"
---
# <a name="delete-usersmescidsscidclipsgameclipid"></a><span data-ttu-id="14d2c-104">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="14d2c-104">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="14d2c-105">これらの Uri のドメインは、ゲーム クリップを削除`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に問題の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-105">Delete game clip The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="14d2c-106">注釈</span><span class="sxs-lookup"><span data-stu-id="14d2c-106">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="14d2c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="14d2c-107">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="14d2c-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="14d2c-108">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="14d2c-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-109">Required Request Headers</span></span>](#ID4EYB)
  * [<span data-ttu-id="14d2c-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-110">Optional Request Headers</span></span>](#ID4EEE)
  * [<span data-ttu-id="14d2c-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="14d2c-111">Request body</span></span>](#ID4ENF)
  * [<span data-ttu-id="14d2c-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="14d2c-112">HTTP status codes</span></span>](#ID4EYF)
  * [<span data-ttu-id="14d2c-113">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-113">Required Response Headers</span></span>](#ID4EIAAC)
  * [<span data-ttu-id="14d2c-114">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-114">Optional Response Headers</span></span>](#ID4E2CAC)
  * [<span data-ttu-id="14d2c-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="14d2c-115">Response body</span></span>](#ID4E2DAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="14d2c-116">注釈</span><span class="sxs-lookup"><span data-stu-id="14d2c-116">Remarks</span></span>
 
<span data-ttu-id="14d2c-117">GameClips サービスからユーザーのビデオを削除するためのメカニズムを提供します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-117">Provides a mechanism for deleting the user's own video from the GameClips service.</span></span> <span data-ttu-id="14d2c-118">削除、時にすべてのメタデータと実際のビデオ アセット (生成されると元) は、システムから削除されます。</span><span class="sxs-lookup"><span data-stu-id="14d2c-118">Upon delete, all metadata and the actual video assets (generated and original) are removed from the system .</span></span> <span data-ttu-id="14d2c-119">これは、永続的な操作です。</span><span class="sxs-lookup"><span data-stu-id="14d2c-119">This is a permanent operation.</span></span> 

> [!NOTE] 
> <span data-ttu-id="14d2c-120">指定された所有者 ID は、呼び出し元に正常に削除要求の認証トークンと一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="14d2c-120">The owner ID specified must match the caller in the authorization token for the delete request to succeed.</span></span> 


  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="14d2c-121">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="14d2c-121">URI parameters</span></span>
 
| <span data-ttu-id="14d2c-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="14d2c-122">Parameter</span></span>| <span data-ttu-id="14d2c-123">型</span><span class="sxs-lookup"><span data-stu-id="14d2c-123">Type</span></span>| <span data-ttu-id="14d2c-124">説明</span><span class="sxs-lookup"><span data-stu-id="14d2c-124">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="14d2c-125">scid</span><span class="sxs-lookup"><span data-stu-id="14d2c-125">scid</span></span>| <span data-ttu-id="14d2c-126">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-126">string</span></span>| <span data-ttu-id="14d2c-127">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="14d2c-127">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="14d2c-128">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="14d2c-128">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="14d2c-129">gameClipId</span><span class="sxs-lookup"><span data-stu-id="14d2c-129">gameClipId</span></span>| <span data-ttu-id="14d2c-130">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-130">string</span></span>| <span data-ttu-id="14d2c-131">GameClip にアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="14d2c-131">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4ENB"></a>

 
## <a name="authorization"></a><span data-ttu-id="14d2c-132">Authorization</span><span class="sxs-lookup"><span data-stu-id="14d2c-132">Authorization</span></span>
 
<span data-ttu-id="14d2c-133">Xuid クレームだけでは、このメソッドでは必要があります。</span><span class="sxs-lookup"><span data-stu-id="14d2c-133">Only the Xuid claim is required for this method.</span></span>
  
<a id="ID4EYB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="14d2c-134">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-134">Required Request Headers</span></span>
 
| <span data-ttu-id="14d2c-135">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-135">Header</span></span>| <span data-ttu-id="14d2c-136">型</span><span class="sxs-lookup"><span data-stu-id="14d2c-136">Type</span></span>| <span data-ttu-id="14d2c-137">説明</span><span class="sxs-lookup"><span data-stu-id="14d2c-137">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="14d2c-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="14d2c-138">Authorization</span></span>| <span data-ttu-id="14d2c-139">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-139">string</span></span>| <span data-ttu-id="14d2c-140">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-140">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="14d2c-141">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="14d2c-141">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="14d2c-142">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="14d2c-142">X-RequestedServiceVersion</span></span>| <span data-ttu-id="14d2c-143">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-143">string</span></span>| <span data-ttu-id="14d2c-144">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="14d2c-144">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="14d2c-145">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-145">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="14d2c-146">Content-Type</span><span class="sxs-lookup"><span data-stu-id="14d2c-146">Content-Type</span></span>| <span data-ttu-id="14d2c-147">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-147">string</span></span>| <span data-ttu-id="14d2c-148">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="14d2c-148">MIME type of the response body.</span></span> <span data-ttu-id="14d2c-149">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-149">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="14d2c-150">Accept</span><span class="sxs-lookup"><span data-stu-id="14d2c-150">Accept</span></span>| <span data-ttu-id="14d2c-151">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-151">string</span></span>| <span data-ttu-id="14d2c-152">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="14d2c-152">Acceptable values of Content-Type.</span></span> <span data-ttu-id="14d2c-153">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-153">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="14d2c-154">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="14d2c-154">Cache-Control</span></span>| <span data-ttu-id="14d2c-155">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-155">string</span></span>| <span data-ttu-id="14d2c-156">キャッシュ動作を指定する正し要求します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-156">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EEE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="14d2c-157">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-157">Optional Request Headers</span></span>
 
| <span data-ttu-id="14d2c-158">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-158">Header</span></span>| <span data-ttu-id="14d2c-159">型</span><span class="sxs-lookup"><span data-stu-id="14d2c-159">Type</span></span>| <span data-ttu-id="14d2c-160">説明</span><span class="sxs-lookup"><span data-stu-id="14d2c-160">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="14d2c-161">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="14d2c-161">Accept-Encoding</span></span>| <span data-ttu-id="14d2c-162">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-162">string</span></span>| <span data-ttu-id="14d2c-163">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="14d2c-163">Acceptable compression encodings.</span></span> <span data-ttu-id="14d2c-164">値の例: gzip、身元を圧縮します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-164">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="14d2c-165">ETag</span><span class="sxs-lookup"><span data-stu-id="14d2c-165">ETag</span></span>| <span data-ttu-id="14d2c-166">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-166">string</span></span>| <span data-ttu-id="14d2c-167">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-167">Used for cache optimization.</span></span> <span data-ttu-id="14d2c-168">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="14d2c-168">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4ENF"></a>

 
## <a name="request-body"></a><span data-ttu-id="14d2c-169">要求本文</span><span class="sxs-lookup"><span data-stu-id="14d2c-169">Request body</span></span>
 
<span data-ttu-id="14d2c-170">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="14d2c-170">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EYF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="14d2c-171">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="14d2c-171">HTTP status codes</span></span>
 
<span data-ttu-id="14d2c-172">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-172">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="14d2c-173">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="14d2c-173">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="14d2c-174">コード</span><span class="sxs-lookup"><span data-stu-id="14d2c-174">Code</span></span>| <span data-ttu-id="14d2c-175">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="14d2c-175">Reason phrase</span></span>| <span data-ttu-id="14d2c-176">説明</span><span class="sxs-lookup"><span data-stu-id="14d2c-176">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="14d2c-177">204</span><span class="sxs-lookup"><span data-stu-id="14d2c-177">204</span></span>| <span data-ttu-id="14d2c-178">OK</span><span class="sxs-lookup"><span data-stu-id="14d2c-178">OK</span></span>| <span data-ttu-id="14d2c-179">クリップが正常に削除します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-179">Successful deletion of the clip.</span></span>| 
| <span data-ttu-id="14d2c-180">401</span><span class="sxs-lookup"><span data-stu-id="14d2c-180">401</span></span>| <span data-ttu-id="14d2c-181">権限がありません</span><span class="sxs-lookup"><span data-stu-id="14d2c-181">Unauthorized</span></span>| <span data-ttu-id="14d2c-182">要求の認証トークンの形式で問題があります。</span><span class="sxs-lookup"><span data-stu-id="14d2c-182">There is a problem with the auth token format in the request.</span></span>| 
| <span data-ttu-id="14d2c-183">403</span><span class="sxs-lookup"><span data-stu-id="14d2c-183">403</span></span>| <span data-ttu-id="14d2c-184">Forbidden</span><span class="sxs-lookup"><span data-stu-id="14d2c-184">Forbidden</span></span>| <span data-ttu-id="14d2c-185">一部の必須の要求は含まれていません。</span><span class="sxs-lookup"><span data-stu-id="14d2c-185">Some required claims are missing.</span></span>| 
| <span data-ttu-id="14d2c-186">404</span><span class="sxs-lookup"><span data-stu-id="14d2c-186">404</span></span>| <span data-ttu-id="14d2c-187">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-187">Not Found</span></span>| <span data-ttu-id="14d2c-188">URL で指定されたクリップが存在しませんでした (または 2 つ目の時間が削除されました)。</span><span class="sxs-lookup"><span data-stu-id="14d2c-188">The clip specified in the URL was not present (or it was deleted a second time).</span></span>| 
| <span data-ttu-id="14d2c-189">503</span><span class="sxs-lookup"><span data-stu-id="14d2c-189">503</span></span>| <span data-ttu-id="14d2c-190">許容できません。</span><span class="sxs-lookup"><span data-stu-id="14d2c-190">Not Acceptable</span></span>| <span data-ttu-id="14d2c-191">サービスまたは一部ダウン ストリームの依存関係ダウンしています。</span><span class="sxs-lookup"><span data-stu-id="14d2c-191">The service or some downstream dependencies are down.</span></span> <span data-ttu-id="14d2c-192">標準的なバックオフ動作を指定して再試行します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-192">Retry with standard back-off behavior.</span></span>| 
  
<a id="ID4EIAAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="14d2c-193">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-193">Required Response Headers</span></span>
 
| <span data-ttu-id="14d2c-194">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-194">Header</span></span>| <span data-ttu-id="14d2c-195">型</span><span class="sxs-lookup"><span data-stu-id="14d2c-195">Type</span></span>| <span data-ttu-id="14d2c-196">説明</span><span class="sxs-lookup"><span data-stu-id="14d2c-196">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="14d2c-197">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="14d2c-197">X-RequestedServiceVersion</span></span>| <span data-ttu-id="14d2c-198">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-198">string</span></span>| <span data-ttu-id="14d2c-199">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="14d2c-199">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="14d2c-200">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-200">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="14d2c-201">Content-Type</span><span class="sxs-lookup"><span data-stu-id="14d2c-201">Content-Type</span></span>| <span data-ttu-id="14d2c-202">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-202">string</span></span>| <span data-ttu-id="14d2c-203">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="14d2c-203">MIME type of the response body.</span></span> <span data-ttu-id="14d2c-204">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-204">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="14d2c-205">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="14d2c-205">Cache-Control</span></span>| <span data-ttu-id="14d2c-206">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-206">string</span></span>| <span data-ttu-id="14d2c-207">キャッシュ動作を指定する正し要求します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-207">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="14d2c-208">Accept</span><span class="sxs-lookup"><span data-stu-id="14d2c-208">Accept</span></span>| <span data-ttu-id="14d2c-209">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-209">string</span></span>| <span data-ttu-id="14d2c-210">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="14d2c-210">Acceptable values of Content-Type.</span></span> <span data-ttu-id="14d2c-211">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-211">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="14d2c-212">Retry-after</span><span class="sxs-lookup"><span data-stu-id="14d2c-212">Retry-After</span></span>| <span data-ttu-id="14d2c-213">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-213">string</span></span>| <span data-ttu-id="14d2c-214">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-214">Instructs client to try again later in the case of an unavailable server.</span></span>| 
| <span data-ttu-id="14d2c-215">異なる</span><span class="sxs-lookup"><span data-stu-id="14d2c-215">Vary</span></span>| <span data-ttu-id="14d2c-216">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-216">string</span></span>| <span data-ttu-id="14d2c-217">下位のプロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-217">Instructs downstream proxies how to cache responses.</span></span>| 
  
<a id="ID4E2CAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="14d2c-218">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-218">Optional Response Headers</span></span>
 
| <span data-ttu-id="14d2c-219">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="14d2c-219">Header</span></span>| <span data-ttu-id="14d2c-220">型</span><span class="sxs-lookup"><span data-stu-id="14d2c-220">Type</span></span>| <span data-ttu-id="14d2c-221">説明</span><span class="sxs-lookup"><span data-stu-id="14d2c-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="14d2c-222">Etag</span><span class="sxs-lookup"><span data-stu-id="14d2c-222">Etag</span></span>| <span data-ttu-id="14d2c-223">string</span><span class="sxs-lookup"><span data-stu-id="14d2c-223">string</span></span>| <span data-ttu-id="14d2c-224">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-224">Used for cache optimization.</span></span> <span data-ttu-id="14d2c-225">例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="14d2c-225">Example: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4E2DAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="14d2c-226">応答本文</span><span class="sxs-lookup"><span data-stu-id="14d2c-226">Response body</span></span>
 
<span data-ttu-id="14d2c-227">サービスが 204 (内容なし)、成功時の HTTP ステータス コードを使って応答します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-227">The service will respond with an HTTP status code of 204 (No content) upon success.</span></span> <span data-ttu-id="14d2c-228">しようとして、同じオブジェクトを削除するか、存在しないオブジェクトは 404 を返します。</span><span class="sxs-lookup"><span data-stu-id="14d2c-228">Trying to delete the same object or a non-existent object will return 404.</span></span>
 
<span data-ttu-id="14d2c-229">エラー発生時**ServiceErrorResponse**オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="14d2c-229">In case of errors, a **ServiceErrorResponse** object will be returned.</span></span>
  
<a id="ID4EJEAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="14d2c-230">関連項目</span><span class="sxs-lookup"><span data-stu-id="14d2c-230">See also</span></span>
 
<a id="ID4ELEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="14d2c-231">Parent</span><span class="sxs-lookup"><span data-stu-id="14d2c-231">Parent</span></span> 

[<span data-ttu-id="14d2c-232">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="14d2c-232">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

   