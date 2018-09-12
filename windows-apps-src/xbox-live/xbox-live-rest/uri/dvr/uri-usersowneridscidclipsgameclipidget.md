---
title: (/Users/{ownerId}/scids/{scid}/clips/{gameClipId}) を取得します。
assetID: dbd60c93-9d8e-609b-0ae3-b3f7ee26ba2d
permalink: en-us/docs/xboxlive/rest/uri-usersowneridscidclipsgameclipidget.html
author: KevinAsgari
description: " (/Users/{ownerId}/scids/{scid}/clips/{gameClipId}) を取得します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 13b96b0d2f1f674533dd2c070bd1a10884bb7370
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882305"
---
# <a name="get-usersowneridscidsscidclipsgameclipid"></a><span data-ttu-id="f9cf9-104">(/Users/{ownerId}/scids/{scid}/clips/{gameClipId}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-104">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="f9cf9-105">すべての Id を見つけることがわかっている場合、システムから 1 つのゲーム クリップを取得します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-105">Get a single game clip from the system if all the IDs to locate it are known.</span></span> <span data-ttu-id="f9cf9-106">これらの Uri のドメイン`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`対象の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="f9cf9-107">注釈</span><span class="sxs-lookup"><span data-stu-id="f9cf9-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="f9cf9-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9cf9-108">URI parameters</span></span>](#ID4EVB)
  * [<span data-ttu-id="f9cf9-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="f9cf9-109">Authorization</span></span>](#ID4EAC)
  * [<span data-ttu-id="f9cf9-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-110">Required Request Headers</span></span>](#ID4EUH)
  * [<span data-ttu-id="f9cf9-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-111">Optional Request Headers</span></span>](#ID4EBCAC)
  * [<span data-ttu-id="f9cf9-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="f9cf9-112">Request body</span></span>](#ID4ETDAC)
  * [<span data-ttu-id="f9cf9-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="f9cf9-113">HTTP status codes</span></span>](#ID4E5DAC)
  * [<span data-ttu-id="f9cf9-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-114">Required Response Headers</span></span>](#ID4EQIAC)
  * [<span data-ttu-id="f9cf9-115">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-115">Optional Response Headers</span></span>](#ID4EJLAC)
  * [<span data-ttu-id="f9cf9-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="f9cf9-116">Response body</span></span>](#ID4EJMAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="f9cf9-117">注釈</span><span class="sxs-lookup"><span data-stu-id="f9cf9-117">Remarks</span></span>
 
<span data-ttu-id="f9cf9-118">クリップを照会するすべてのデータは、**ゲーム クリップだった**オブジェクトのメタデータ クエリから返されるです。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-118">All data to query for the clip is available in the **GameClip** objects as returned from any metadata query.</span></span> <span data-ttu-id="f9cf9-119">この API を介してゲーム クリップが 1 つを取得するのには、 **XUID**、 **ServiceConfigId**、 **GameClipId**要求の要求で**SandboxId**が必要です。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-119">**XUID**, **ServiceConfigId**, **GameClipId** and **SandboxId** in the claims of the request are required to get a single game clip via this API.</span></span> <span data-ttu-id="f9cf9-120">ゲーム クリップが実施のフラグが設定された、またはコンテンツの分離またはプライバシー チェックのユーザーに特定のゲーム クリップを取得するためのアクセス許可が必要がない判断、API は 404 (Not Found) の HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-120">If the game clip has been flagged for enforcement, or Content Isolation or privacy checks determine that the user does not have permission to get the specific game clip, the API will return an HTTP status code of 404 (Not Found).</span></span>
 
<span data-ttu-id="f9cf9-121">**SandboxId**は今すぐ、XToken で要求から取得し、適用します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-121">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="f9cf9-122">**SandboxId**が存在しない場合のエンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-122">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>
 
<span data-ttu-id="f9cf9-123">この API は、有効期限が切れた Uri の更新にも使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-123">This API must also be used to refresh expired URIs.</span></span> <span data-ttu-id="f9cf9-124">クエリが完了したら、任意の有効期限が切れた Uri ゲーム クリップのリフレッシュされますそれに応じて。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-124">When the query is complete, any expired URIs for the game clip will be refreshed accordingly.</span></span> 

> [!NOTE] 
> <span data-ttu-id="f9cf9-125">URI の更新を最大 30 ~ 40 秒この要求を完了とかかります。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-125">A URI refresh can take up to 30-40 seconds after this request is done.</span></span> <span data-ttu-id="f9cf9-126">URI の有効期限が切れた場合、しようとするとすぐにストリーミング操作の使用すると、HTTP 500 の状態コードがスムーズ ストリーミングを IIS サーバーから表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-126">If the URI has expired, attempting to use it immediately for streaming operations will get an HTTP 500 status code from the IIS Smooth Streaming Servers.</span></span> <span data-ttu-id="f9cf9-127">これは、短縮する方法に取り組んでいます、この注はその作業の進行に応じて更新されます。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-127">We are working on ways to shorten this, and this note will be updated accordingly as that work progresses.</span></span> 


  
<a id="ID4EVB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f9cf9-128">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9cf9-128">URI parameters</span></span>
 
| <span data-ttu-id="f9cf9-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9cf9-129">Parameter</span></span>| <span data-ttu-id="f9cf9-130">型</span><span class="sxs-lookup"><span data-stu-id="f9cf9-130">Type</span></span>| <span data-ttu-id="f9cf9-131">説明</span><span class="sxs-lookup"><span data-stu-id="f9cf9-131">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="f9cf9-132">ownerId</span><span class="sxs-lookup"><span data-stu-id="f9cf9-132">ownerId</span></span>| <span data-ttu-id="f9cf9-133">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-133">string</span></span>| <span data-ttu-id="f9cf9-134">そのリソースにアクセスしているユーザーのユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-134">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="f9cf9-135">サポートされる形式:"me"または"xuid(123456789)"。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-135">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="f9cf9-136">最大長: 16 します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-136">Maximum length: 16.</span></span>| 
| <span data-ttu-id="f9cf9-137">scid</span><span class="sxs-lookup"><span data-stu-id="f9cf9-137">scid</span></span>| <span data-ttu-id="f9cf9-138">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-138">string</span></span>| <span data-ttu-id="f9cf9-139">アクセスしているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-139">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="f9cf9-140">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-140">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="f9cf9-141">gameClipId</span><span class="sxs-lookup"><span data-stu-id="f9cf9-141">gameClipId</span></span>| <span data-ttu-id="f9cf9-142">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-142">string</span></span>| <span data-ttu-id="f9cf9-143">ゲーム クリップだったにアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-143">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="authorization"></a><span data-ttu-id="f9cf9-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="f9cf9-144">Authorization</span></span>
 
<span data-ttu-id="f9cf9-145">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="f9cf9-145">Authorization claims used</span></span> | <span data-ttu-id="f9cf9-146">要求</span><span class="sxs-lookup"><span data-stu-id="f9cf9-146">Claim</span></span>| <span data-ttu-id="f9cf9-147">種類</span><span class="sxs-lookup"><span data-stu-id="f9cf9-147">Type</span></span>| <span data-ttu-id="f9cf9-148">必須?</span><span class="sxs-lookup"><span data-stu-id="f9cf9-148">Required?</span></span>| <span data-ttu-id="f9cf9-149">値の例</span><span class="sxs-lookup"><span data-stu-id="f9cf9-149">Example value</span></span>| <span data-ttu-id="f9cf9-150">注釈</span><span class="sxs-lookup"><span data-stu-id="f9cf9-150">Remarks</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f9cf9-151">Xuid</span><span class="sxs-lookup"><span data-stu-id="f9cf9-151">Xuid</span></span>| <span data-ttu-id="f9cf9-152">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="f9cf9-152">64-bit signed integer</span></span>| <span data-ttu-id="f9cf9-153">必須</span><span class="sxs-lookup"><span data-stu-id="f9cf9-153">yes</span></span>| <span data-ttu-id="f9cf9-154">1234567890</span><span class="sxs-lookup"><span data-stu-id="f9cf9-154">1234567890</span></span>|  | 
| <span data-ttu-id="f9cf9-155">TitleId</span><span class="sxs-lookup"><span data-stu-id="f9cf9-155">TitleId</span></span>| <span data-ttu-id="f9cf9-156">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="f9cf9-156">64-bit signed integer</span></span>| <span data-ttu-id="f9cf9-157">必須</span><span class="sxs-lookup"><span data-stu-id="f9cf9-157">yes</span></span>| <span data-ttu-id="f9cf9-158">1234567890</span><span class="sxs-lookup"><span data-stu-id="f9cf9-158">1234567890</span></span>| <span data-ttu-id="f9cf9-159"><b>コンテンツ分離</b>チェックに使用されます。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-159">Used for <b>Content-Isolation</b> check.</span></span>| 
| <span data-ttu-id="f9cf9-160">SandboxId</span><span class="sxs-lookup"><span data-stu-id="f9cf9-160">SandboxId</span></span>| <span data-ttu-id="f9cf9-161">16 進数のバイナリ</span><span class="sxs-lookup"><span data-stu-id="f9cf9-161">hexadecimal binary</span></span>| <span data-ttu-id="f9cf9-162">必須</span><span class="sxs-lookup"><span data-stu-id="f9cf9-162">yes</span></span>|  | <span data-ttu-id="f9cf9-163">検索では、適切な領域をシステムに指示し、<b>コンテンツ分離</b>チェックに使用します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-163">Directs the system to the correct area for lookups, and used for <b>Content-Isolation</b> check.</span></span>| 
  
<span data-ttu-id="f9cf9-164">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="f9cf9-164">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="f9cf9-165">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="f9cf9-165">Requesting User</span></span>| <span data-ttu-id="f9cf9-166">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="f9cf9-166">Target User's Privacy Setting</span></span>| <span data-ttu-id="f9cf9-167">動作</span><span class="sxs-lookup"><span data-stu-id="f9cf9-167">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f9cf9-168">me</span><span class="sxs-lookup"><span data-stu-id="f9cf9-168">me</span></span>| -| <span data-ttu-id="f9cf9-169">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-169">As described.</span></span>| 
| <span data-ttu-id="f9cf9-170">フレンド</span><span class="sxs-lookup"><span data-stu-id="f9cf9-170">friend</span></span>| <span data-ttu-id="f9cf9-171">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-171">everyone</span></span>| <span data-ttu-id="f9cf9-172">許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-172">Forbidden.</span></span>| 
| <span data-ttu-id="f9cf9-173">フレンド</span><span class="sxs-lookup"><span data-stu-id="f9cf9-173">friend</span></span>| <span data-ttu-id="f9cf9-174">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="f9cf9-174">friends only</span></span>| <span data-ttu-id="f9cf9-175">許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-175">Forbidden.</span></span>| 
| <span data-ttu-id="f9cf9-176">フレンド</span><span class="sxs-lookup"><span data-stu-id="f9cf9-176">friend</span></span>| <span data-ttu-id="f9cf9-177">ブロック</span><span class="sxs-lookup"><span data-stu-id="f9cf9-177">blocked</span></span>| <span data-ttu-id="f9cf9-178">許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-178">Forbidden.</span></span>| 
| <span data-ttu-id="f9cf9-179">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-179">non-friend user</span></span>| <span data-ttu-id="f9cf9-180">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-180">everyone</span></span>| <span data-ttu-id="f9cf9-181">許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-181">Forbidden.</span></span>| 
| <span data-ttu-id="f9cf9-182">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-182">non-friend user</span></span>| <span data-ttu-id="f9cf9-183">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="f9cf9-183">friends only</span></span>| <span data-ttu-id="f9cf9-184">許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-184">Forbidden.</span></span>| 
| <span data-ttu-id="f9cf9-185">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-185">non-friend user</span></span>| <span data-ttu-id="f9cf9-186">ブロック</span><span class="sxs-lookup"><span data-stu-id="f9cf9-186">blocked</span></span>| <span data-ttu-id="f9cf9-187">許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-187">Forbidden.</span></span>| 
| <span data-ttu-id="f9cf9-188">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="f9cf9-188">third-party site</span></span>| <span data-ttu-id="f9cf9-189">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-189">everyone</span></span>| <span data-ttu-id="f9cf9-190">許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-190">Forbidden.</span></span>| 
| <span data-ttu-id="f9cf9-191">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="f9cf9-191">third-party site</span></span>| <span data-ttu-id="f9cf9-192">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="f9cf9-192">friends only</span></span>| <span data-ttu-id="f9cf9-193">許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-193">Forbidden.</span></span>| 
| <span data-ttu-id="f9cf9-194">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="f9cf9-194">third-party site</span></span>| <span data-ttu-id="f9cf9-195">ブロック</span><span class="sxs-lookup"><span data-stu-id="f9cf9-195">blocked</span></span>| <span data-ttu-id="f9cf9-196">許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-196">Forbidden.</span></span>| 
 
<a id="ID4EUH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="f9cf9-197">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-197">Required Request Headers</span></span>
 
| <span data-ttu-id="f9cf9-198">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-198">Header</span></span>| <span data-ttu-id="f9cf9-199">型</span><span class="sxs-lookup"><span data-stu-id="f9cf9-199">Type</span></span>| <span data-ttu-id="f9cf9-200">説明</span><span class="sxs-lookup"><span data-stu-id="f9cf9-200">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f9cf9-201">Authorization</span><span class="sxs-lookup"><span data-stu-id="f9cf9-201">Authorization</span></span>| <span data-ttu-id="f9cf9-202">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-202">string</span></span>| <span data-ttu-id="f9cf9-203">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-203">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="f9cf9-204">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="f9cf9-204">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="f9cf9-205">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="f9cf9-205">X-RequestedServiceVersion</span></span>| <span data-ttu-id="f9cf9-206">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-206">string</span></span>| <span data-ttu-id="f9cf9-207">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-207">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="f9cf9-208">要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-208">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="f9cf9-209">Content-Type</span><span class="sxs-lookup"><span data-stu-id="f9cf9-209">Content-Type</span></span>| <span data-ttu-id="f9cf9-210">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-210">string</span></span>| <span data-ttu-id="f9cf9-211">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-211">MIME type of the response body.</span></span> <span data-ttu-id="f9cf9-212">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-212">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="f9cf9-213">Accept</span><span class="sxs-lookup"><span data-stu-id="f9cf9-213">Accept</span></span>| <span data-ttu-id="f9cf9-214">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-214">string</span></span>| <span data-ttu-id="f9cf9-215">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-215">Acceptable values of Content-Type.</span></span> <span data-ttu-id="f9cf9-216">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-216">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="f9cf9-217">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="f9cf9-217">Cache-Control</span></span>| <span data-ttu-id="f9cf9-218">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-218">string</span></span>| <span data-ttu-id="f9cf9-219">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-219">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EBCAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="f9cf9-220">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-220">Optional Request Headers</span></span>
 
| <span data-ttu-id="f9cf9-221">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-221">Header</span></span>| <span data-ttu-id="f9cf9-222">型</span><span class="sxs-lookup"><span data-stu-id="f9cf9-222">Type</span></span>| <span data-ttu-id="f9cf9-223">説明</span><span class="sxs-lookup"><span data-stu-id="f9cf9-223">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f9cf9-224">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="f9cf9-224">Accept-Encoding</span></span>| <span data-ttu-id="f9cf9-225">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-225">string</span></span>| <span data-ttu-id="f9cf9-226">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-226">Acceptable compression encodings.</span></span> <span data-ttu-id="f9cf9-227">値の例: gzip、圧縮の id。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-227">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="f9cf9-228">ETag</span><span class="sxs-lookup"><span data-stu-id="f9cf9-228">ETag</span></span>| <span data-ttu-id="f9cf9-229">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-229">string</span></span>| <span data-ttu-id="f9cf9-230">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-230">Used for cache optimization.</span></span> <span data-ttu-id="f9cf9-231">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-231">Example value: "686897696a7c876b7e".</span></span>| 
| <span data-ttu-id="f9cf9-232">範囲</span><span class="sxs-lookup"><span data-stu-id="f9cf9-232">Range</span></span>| <span data-ttu-id="f9cf9-233">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-233">string</span></span>|  | 
  
<a id="ID4ETDAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="f9cf9-234">要求本文</span><span class="sxs-lookup"><span data-stu-id="f9cf9-234">Request body</span></span>
 
<span data-ttu-id="f9cf9-235">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-235">No objects are sent in the body of this request.</span></span>
  
<a id="ID4E5DAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="f9cf9-236">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="f9cf9-236">HTTP status codes</span></span>
 
<span data-ttu-id="f9cf9-237">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-237">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="f9cf9-238">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-238">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="f9cf9-239">コード</span><span class="sxs-lookup"><span data-stu-id="f9cf9-239">Code</span></span>| <span data-ttu-id="f9cf9-240">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="f9cf9-240">Reason phrase</span></span>| <span data-ttu-id="f9cf9-241">説明</span><span class="sxs-lookup"><span data-stu-id="f9cf9-241">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f9cf9-242">200</span><span class="sxs-lookup"><span data-stu-id="f9cf9-242">200</span></span>| <span data-ttu-id="f9cf9-243">OK</span><span class="sxs-lookup"><span data-stu-id="f9cf9-243">OK</span></span>| <span data-ttu-id="f9cf9-244">セッションが正常に取得されます。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-244">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="f9cf9-245">301</span><span class="sxs-lookup"><span data-stu-id="f9cf9-245">301</span></span>| <span data-ttu-id="f9cf9-246">完全に移動</span><span class="sxs-lookup"><span data-stu-id="f9cf9-246">Moved Permanently</span></span>|  | 
| <span data-ttu-id="f9cf9-247">307</span><span class="sxs-lookup"><span data-stu-id="f9cf9-247">307</span></span>| <span data-ttu-id="f9cf9-248">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="f9cf9-248">Temporary Redirect</span></span>|  | 
| <span data-ttu-id="f9cf9-249">400</span><span class="sxs-lookup"><span data-stu-id="f9cf9-249">400</span></span>| <span data-ttu-id="f9cf9-250">Bad Request</span><span class="sxs-lookup"><span data-stu-id="f9cf9-250">Bad Request</span></span>| <span data-ttu-id="f9cf9-251">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-251">Service could not understand malformed request.</span></span> <span data-ttu-id="f9cf9-252">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-252">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="f9cf9-253">401</span><span class="sxs-lookup"><span data-stu-id="f9cf9-253">401</span></span>| <span data-ttu-id="f9cf9-254">権限がありません</span><span class="sxs-lookup"><span data-stu-id="f9cf9-254">Unauthorized</span></span>| <span data-ttu-id="f9cf9-255">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-255">The request requires user authentication.</span></span>| 
| <span data-ttu-id="f9cf9-256">403</span><span class="sxs-lookup"><span data-stu-id="f9cf9-256">403</span></span>| <span data-ttu-id="f9cf9-257">Forbidden</span><span class="sxs-lookup"><span data-stu-id="f9cf9-257">Forbidden</span></span>| <span data-ttu-id="f9cf9-258">要求は、ユーザーまたはサービスは許可されません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-258">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="f9cf9-259">404</span><span class="sxs-lookup"><span data-stu-id="f9cf9-259">404</span></span>| <span data-ttu-id="f9cf9-260">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-260">Not Found</span></span>| <span data-ttu-id="f9cf9-261">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-261">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="f9cf9-262">406</span><span class="sxs-lookup"><span data-stu-id="f9cf9-262">406</span></span>| <span data-ttu-id="f9cf9-263">許容できません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-263">Not Acceptable</span></span>| <span data-ttu-id="f9cf9-264">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-264">Resource version is not supported.</span></span>| 
| <span data-ttu-id="f9cf9-265">408</span><span class="sxs-lookup"><span data-stu-id="f9cf9-265">408</span></span>| <span data-ttu-id="f9cf9-266">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="f9cf9-266">Request Timeout</span></span>| <span data-ttu-id="f9cf9-267">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-267">The request took too long to complete.</span></span>| 
| <span data-ttu-id="f9cf9-268">410</span><span class="sxs-lookup"><span data-stu-id="f9cf9-268">410</span></span>| <span data-ttu-id="f9cf9-269">無効</span><span class="sxs-lookup"><span data-stu-id="f9cf9-269">Gone</span></span>| <span data-ttu-id="f9cf9-270">要求されたリソースが利用可能ではなくなりました。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-270">The requested resource is no longer available.</span></span>| 
  
<a id="ID4EQIAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="f9cf9-271">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-271">Required Response Headers</span></span>
 
| <span data-ttu-id="f9cf9-272">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-272">Header</span></span>| <span data-ttu-id="f9cf9-273">型</span><span class="sxs-lookup"><span data-stu-id="f9cf9-273">Type</span></span>| <span data-ttu-id="f9cf9-274">説明</span><span class="sxs-lookup"><span data-stu-id="f9cf9-274">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f9cf9-275">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="f9cf9-275">X-RequestedServiceVersion</span></span>| <span data-ttu-id="f9cf9-276">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-276">string</span></span>| <span data-ttu-id="f9cf9-277">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-277">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="f9cf9-278">要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-278">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="f9cf9-279">Content-Type</span><span class="sxs-lookup"><span data-stu-id="f9cf9-279">Content-Type</span></span>| <span data-ttu-id="f9cf9-280">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-280">string</span></span>| <span data-ttu-id="f9cf9-281">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-281">MIME type of the response body.</span></span> <span data-ttu-id="f9cf9-282">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-282">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="f9cf9-283">Accept</span><span class="sxs-lookup"><span data-stu-id="f9cf9-283">Accept</span></span>| <span data-ttu-id="f9cf9-284">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-284">string</span></span>| <span data-ttu-id="f9cf9-285">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-285">Acceptable values of Content-Type.</span></span> <span data-ttu-id="f9cf9-286">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-286">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="f9cf9-287">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="f9cf9-287">Cache-Control</span></span>| <span data-ttu-id="f9cf9-288">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-288">string</span></span>| <span data-ttu-id="f9cf9-289">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-289">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="f9cf9-290">Retry-after</span><span class="sxs-lookup"><span data-stu-id="f9cf9-290">Retry-After</span></span>| <span data-ttu-id="f9cf9-291">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-291">string</span></span>| <span data-ttu-id="f9cf9-292">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-292">Instructs client to try again later in the case of an unavailable server.</span></span> <span data-ttu-id="f9cf9-293">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-293">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="f9cf9-294">異なる</span><span class="sxs-lookup"><span data-stu-id="f9cf9-294">Vary</span></span>| <span data-ttu-id="f9cf9-295">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-295">string</span></span>| <span data-ttu-id="f9cf9-296">下位のプロキシの応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-296">Instructs downstream proxies how to cache responses.</span></span> <span data-ttu-id="f9cf9-297">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-297">Example: <b>application/json</b>.</span></span>| 
  
<a id="ID4EJLAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="f9cf9-298">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-298">Optional Response Headers</span></span>
 
| <span data-ttu-id="f9cf9-299">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9cf9-299">Header</span></span>| <span data-ttu-id="f9cf9-300">型</span><span class="sxs-lookup"><span data-stu-id="f9cf9-300">Type</span></span>| <span data-ttu-id="f9cf9-301">説明</span><span class="sxs-lookup"><span data-stu-id="f9cf9-301">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f9cf9-302">ETag</span><span class="sxs-lookup"><span data-stu-id="f9cf9-302">ETag</span></span>| <span data-ttu-id="f9cf9-303">string</span><span class="sxs-lookup"><span data-stu-id="f9cf9-303">string</span></span>| <span data-ttu-id="f9cf9-304">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-304">Used for cache optimization.</span></span> <span data-ttu-id="f9cf9-305">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="f9cf9-305">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EJMAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="f9cf9-306">応答本文</span><span class="sxs-lookup"><span data-stu-id="f9cf9-306">Response body</span></span>
 
<a id="ID4EPMAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="f9cf9-307">応答の例</span><span class="sxs-lookup"><span data-stu-id="f9cf9-307">Sample response</span></span>
 

```cpp
{
 "gameClip": {
   "xuid": "2716903703773872",
   "clipName": "1234567890",
   "titleName": "",
   "gameClipId": "cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000",
   "state": "Published",
   "dateRecorded": "2013-05-08T21:32:17.4201279Z",
   "lastModified": "2013-05-08T21:34:48.8117829Z",
   "userCaption": "",
   "type": "DeveloperInitiated",
   "source": "Console",
   "visibility": "Public",
   "durationInSeconds": 30,
   "scid": "00000000-0000-0012-0023-000000000070",
   "titleId": 0,
   "rating": 0,
   "ratingCount": 0,
   "views": 0,
   "titleData": "",
   "systemProperties": "",
   "savedByUser": false,
   "thumbnails": [
     {
       "uri": "http:\/\/localhost\/users\/xuid(2716903703773872)\/scids\/00000000-0000-0012-0023-000000000070\/clips\/cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000\/thumbnails\/large",
       "fileSize": 0,
       "thumbnailType": "Large"
     },
     {
       "uri": "http:\/\/localhost\/users\/xuid(2716903703773872)\/scids\/00000000-0000-0012-0023-000000000070\/clips\/cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000\/thumbnails\/small",
       "fileSize": 0,
       "thumbnailType": "Small"
     }
   ],
   "gameClipUris": [
     {
       "uri": "http:\/\/localhost\/users\/xuid(2716903703773872)\/scids\/00000000-0000-0012-0023-000000000070\/clips\/cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000",
       "fileSize": 9332015,
       "uriType": "Download",
       "expiration": "9999-12-31T23:59:59.9999999"
     }
   ]
 }
}
         
```

   
<a id="ID4EZMAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f9cf9-308">関連項目</span><span class="sxs-lookup"><span data-stu-id="f9cf9-308">See also</span></span>
 
<a id="ID4E2MAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f9cf9-309">Parent</span><span class="sxs-lookup"><span data-stu-id="f9cf9-309">Parent</span></span> 

[<span data-ttu-id="f9cf9-310">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="f9cf9-310">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersowneridscidclipsgameclipid.md)

  
<a id="ID4EFNAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="f9cf9-311">詳細情報</span><span class="sxs-lookup"><span data-stu-id="f9cf9-311">Further Information</span></span> 

[<span data-ttu-id="f9cf9-312">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="f9cf9-312">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

 [<span data-ttu-id="f9cf9-313">その他の参照</span><span class="sxs-lookup"><span data-stu-id="f9cf9-313">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   