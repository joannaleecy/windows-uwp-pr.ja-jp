---
title: GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})
assetID: dbd60c93-9d8e-609b-0ae3-b3f7ee26ba2d
permalink: en-us/docs/xboxlive/rest/uri-usersowneridscidclipsgameclipidget.html
description: " GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5d2858b11bf8fb902ea07a016c8f41db375013f9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640957"
---
# <a name="get-usersowneridscidsscidclipsgameclipid"></a><span data-ttu-id="0933d-104">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="0933d-104">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="0933d-105">指定することのすべての Id がわかっている場合は、システムからゲームの 1 つのクリップを取得します。</span><span class="sxs-lookup"><span data-stu-id="0933d-105">Get a single game clip from the system if all the IDs to locate it are known.</span></span> <span data-ttu-id="0933d-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="0933d-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="0933d-107">注釈</span><span class="sxs-lookup"><span data-stu-id="0933d-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="0933d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0933d-108">URI parameters</span></span>](#ID4EVB)
  * [<span data-ttu-id="0933d-109">承認</span><span class="sxs-lookup"><span data-stu-id="0933d-109">Authorization</span></span>](#ID4EAC)
  * [<span data-ttu-id="0933d-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0933d-110">Required Request Headers</span></span>](#ID4EUH)
  * [<span data-ttu-id="0933d-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0933d-111">Optional Request Headers</span></span>](#ID4EBCAC)
  * [<span data-ttu-id="0933d-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="0933d-112">Request body</span></span>](#ID4ETDAC)
  * [<span data-ttu-id="0933d-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="0933d-113">HTTP status codes</span></span>](#ID4E5DAC)
  * [<span data-ttu-id="0933d-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0933d-114">Required Response Headers</span></span>](#ID4EQIAC)
  * [<span data-ttu-id="0933d-115">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0933d-115">Optional Response Headers</span></span>](#ID4EJLAC)
  * [<span data-ttu-id="0933d-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="0933d-116">Response body</span></span>](#ID4EJMAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="0933d-117">注釈</span><span class="sxs-lookup"><span data-stu-id="0933d-117">Remarks</span></span>
 
<span data-ttu-id="0933d-118">すべてのデータをクエリでは、クリップ、**ゲーム クリップだった**メタデータ クエリから返されるオブジェクトします。</span><span class="sxs-lookup"><span data-stu-id="0933d-118">All data to query for the clip is available in the **GameClip** objects as returned from any metadata query.</span></span> <span data-ttu-id="0933d-119">**XUID**、 **ServiceConfigId**、 **GameClipId**と**SandboxId**この API を使用して 1 つのゲーム クリップを取得する要求の要求でが必要です。</span><span class="sxs-lookup"><span data-stu-id="0933d-119">**XUID**, **ServiceConfigId**, **GameClipId** and **SandboxId** in the claims of the request are required to get a single game clip via this API.</span></span> <span data-ttu-id="0933d-120">ゲームのクリップは強制は、フラグが設定されている、またはコンテンツの分離やプライバシーを確認、ユーザーが特定のゲームのクリップを取得するアクセス許可を持たないことを確認、API は HTTP ステータス コード 404 (Not Found) を返します。</span><span class="sxs-lookup"><span data-stu-id="0933d-120">If the game clip has been flagged for enforcement, or Content Isolation or privacy checks determine that the user does not have permission to get the specific game clip, the API will return an HTTP status code of 404 (Not Found).</span></span>
 
<span data-ttu-id="0933d-121">**SandboxId**今すぐ、XToken 内の要求から取得され、適用します。</span><span class="sxs-lookup"><span data-stu-id="0933d-121">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="0933d-122">場合、 **SandboxId**エンターテイメント検出サービス (EDS) は 400 Bad request エラーをスローしが存在しません。</span><span class="sxs-lookup"><span data-stu-id="0933d-122">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>
 
<span data-ttu-id="0933d-123">この API は、有効期限が切れた Uri を更新にも使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0933d-123">This API must also be used to refresh expired URIs.</span></span> <span data-ttu-id="0933d-124">クエリが完了したら、ゲームのクリップの任意の有効期限が切れた Uri が適宜更新すること。</span><span class="sxs-lookup"><span data-stu-id="0933d-124">When the query is complete, any expired URIs for the game clip will be refreshed accordingly.</span></span> 

> [!NOTE] 
> <span data-ttu-id="0933d-125">URI の更新は、最大 30 ~ 40 秒この要求が完了した後にかかります。</span><span class="sxs-lookup"><span data-stu-id="0933d-125">A URI refresh can take up to 30-40 seconds after this request is done.</span></span> <span data-ttu-id="0933d-126">URI の有効期限が切れている場合、ストリーミング操作をすぐに使用しようとしています。 に HTTP 500 ステータス コードが IIS Smooth Streaming サーバーから取得されます。</span><span class="sxs-lookup"><span data-stu-id="0933d-126">If the URI has expired, attempting to use it immediately for streaming operations will get an HTTP 500 status code from the IIS Smooth Streaming Servers.</span></span> <span data-ttu-id="0933d-127">これを短縮する方法に取り組んでいます、この注はその作業の進行状況と、それに従って更新されます。</span><span class="sxs-lookup"><span data-stu-id="0933d-127">We are working on ways to shorten this, and this note will be updated accordingly as that work progresses.</span></span> 


  
<a id="ID4EVB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0933d-128">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0933d-128">URI parameters</span></span>
 
| <span data-ttu-id="0933d-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0933d-129">Parameter</span></span>| <span data-ttu-id="0933d-130">種類</span><span class="sxs-lookup"><span data-stu-id="0933d-130">Type</span></span>| <span data-ttu-id="0933d-131">説明</span><span class="sxs-lookup"><span data-stu-id="0933d-131">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="0933d-132">ownerId</span><span class="sxs-lookup"><span data-stu-id="0933d-132">ownerId</span></span>| <span data-ttu-id="0933d-133">string</span><span class="sxs-lookup"><span data-stu-id="0933d-133">string</span></span>| <span data-ttu-id="0933d-134">リソースがアクセスされているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="0933d-134">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="0933d-135">サポートされている形式:"xuid(123456789)"または"me"。</span><span class="sxs-lookup"><span data-stu-id="0933d-135">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="0933d-136">最大長:16.</span><span class="sxs-lookup"><span data-stu-id="0933d-136">Maximum length: 16.</span></span>| 
| <span data-ttu-id="0933d-137">scid</span><span class="sxs-lookup"><span data-stu-id="0933d-137">scid</span></span>| <span data-ttu-id="0933d-138">string</span><span class="sxs-lookup"><span data-stu-id="0933d-138">string</span></span>| <span data-ttu-id="0933d-139">サービス アクセスされているリソースの ID を構成します。</span><span class="sxs-lookup"><span data-stu-id="0933d-139">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="0933d-140">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0933d-140">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="0933d-141">gameClipId</span><span class="sxs-lookup"><span data-stu-id="0933d-141">gameClipId</span></span>| <span data-ttu-id="0933d-142">string</span><span class="sxs-lookup"><span data-stu-id="0933d-142">string</span></span>| <span data-ttu-id="0933d-143">アクセスされているリソースの ID をゲーム クリップだった。</span><span class="sxs-lookup"><span data-stu-id="0933d-143">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="authorization"></a><span data-ttu-id="0933d-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="0933d-144">Authorization</span></span>
 
<span data-ttu-id="0933d-145">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="0933d-145">Authorization claims used</span></span> | <span data-ttu-id="0933d-146">要求</span><span class="sxs-lookup"><span data-stu-id="0933d-146">Claim</span></span>| <span data-ttu-id="0933d-147">種類</span><span class="sxs-lookup"><span data-stu-id="0933d-147">Type</span></span>| <span data-ttu-id="0933d-148">必須?</span><span class="sxs-lookup"><span data-stu-id="0933d-148">Required?</span></span>| <span data-ttu-id="0933d-149">値の例</span><span class="sxs-lookup"><span data-stu-id="0933d-149">Example value</span></span>| <span data-ttu-id="0933d-150">注釈</span><span class="sxs-lookup"><span data-stu-id="0933d-150">Remarks</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0933d-151">xuid</span><span class="sxs-lookup"><span data-stu-id="0933d-151">Xuid</span></span>| <span data-ttu-id="0933d-152">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0933d-152">64-bit signed integer</span></span>| <span data-ttu-id="0933d-153">○</span><span class="sxs-lookup"><span data-stu-id="0933d-153">yes</span></span>| <span data-ttu-id="0933d-154">1234567890</span><span class="sxs-lookup"><span data-stu-id="0933d-154">1234567890</span></span>|  | 
| <span data-ttu-id="0933d-155">TitleId</span><span class="sxs-lookup"><span data-stu-id="0933d-155">TitleId</span></span>| <span data-ttu-id="0933d-156">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0933d-156">64-bit signed integer</span></span>| <span data-ttu-id="0933d-157">○</span><span class="sxs-lookup"><span data-stu-id="0933d-157">yes</span></span>| <span data-ttu-id="0933d-158">1234567890</span><span class="sxs-lookup"><span data-stu-id="0933d-158">1234567890</span></span>| <span data-ttu-id="0933d-159">使用される<b>コンテンツ分離</b>を確認します。</span><span class="sxs-lookup"><span data-stu-id="0933d-159">Used for <b>Content-Isolation</b> check.</span></span>| 
| <span data-ttu-id="0933d-160">sandboxId</span><span class="sxs-lookup"><span data-stu-id="0933d-160">SandboxId</span></span>| <span data-ttu-id="0933d-161">16 進数のバイナリ</span><span class="sxs-lookup"><span data-stu-id="0933d-161">hexadecimal binary</span></span>| <span data-ttu-id="0933d-162">○</span><span class="sxs-lookup"><span data-stu-id="0933d-162">yes</span></span>|  | <span data-ttu-id="0933d-163">参照する場合の適切な領域をシステムに指示され、使用<b>コンテンツ分離</b>を確認します。</span><span class="sxs-lookup"><span data-stu-id="0933d-163">Directs the system to the correct area for lookups, and used for <b>Content-Isolation</b> check.</span></span>| 
  
<span data-ttu-id="0933d-164">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="0933d-164">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="0933d-165">要求元のユーザー</span><span class="sxs-lookup"><span data-stu-id="0933d-165">Requesting User</span></span>| <span data-ttu-id="0933d-166">ターゲット ユーザーのプライバシーの設定</span><span class="sxs-lookup"><span data-stu-id="0933d-166">Target User's Privacy Setting</span></span>| <span data-ttu-id="0933d-167">動作</span><span class="sxs-lookup"><span data-stu-id="0933d-167">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0933d-168">Me</span><span class="sxs-lookup"><span data-stu-id="0933d-168">me</span></span>| -| <span data-ttu-id="0933d-169">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="0933d-169">As described.</span></span>| 
| <span data-ttu-id="0933d-170">friend</span><span class="sxs-lookup"><span data-stu-id="0933d-170">friend</span></span>| <span data-ttu-id="0933d-171">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="0933d-171">everyone</span></span>| <span data-ttu-id="0933d-172">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0933d-172">Forbidden.</span></span>| 
| <span data-ttu-id="0933d-173">friend</span><span class="sxs-lookup"><span data-stu-id="0933d-173">friend</span></span>| <span data-ttu-id="0933d-174">友達のみ</span><span class="sxs-lookup"><span data-stu-id="0933d-174">friends only</span></span>| <span data-ttu-id="0933d-175">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0933d-175">Forbidden.</span></span>| 
| <span data-ttu-id="0933d-176">friend</span><span class="sxs-lookup"><span data-stu-id="0933d-176">friend</span></span>| <span data-ttu-id="0933d-177">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="0933d-177">blocked</span></span>| <span data-ttu-id="0933d-178">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0933d-178">Forbidden.</span></span>| 
| <span data-ttu-id="0933d-179">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="0933d-179">non-friend user</span></span>| <span data-ttu-id="0933d-180">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="0933d-180">everyone</span></span>| <span data-ttu-id="0933d-181">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0933d-181">Forbidden.</span></span>| 
| <span data-ttu-id="0933d-182">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="0933d-182">non-friend user</span></span>| <span data-ttu-id="0933d-183">友達のみ</span><span class="sxs-lookup"><span data-stu-id="0933d-183">friends only</span></span>| <span data-ttu-id="0933d-184">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0933d-184">Forbidden.</span></span>| 
| <span data-ttu-id="0933d-185">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="0933d-185">non-friend user</span></span>| <span data-ttu-id="0933d-186">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="0933d-186">blocked</span></span>| <span data-ttu-id="0933d-187">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0933d-187">Forbidden.</span></span>| 
| <span data-ttu-id="0933d-188">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="0933d-188">third-party site</span></span>| <span data-ttu-id="0933d-189">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="0933d-189">everyone</span></span>| <span data-ttu-id="0933d-190">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0933d-190">Forbidden.</span></span>| 
| <span data-ttu-id="0933d-191">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="0933d-191">third-party site</span></span>| <span data-ttu-id="0933d-192">友達のみ</span><span class="sxs-lookup"><span data-stu-id="0933d-192">friends only</span></span>| <span data-ttu-id="0933d-193">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0933d-193">Forbidden.</span></span>| 
| <span data-ttu-id="0933d-194">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="0933d-194">third-party site</span></span>| <span data-ttu-id="0933d-195">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="0933d-195">blocked</span></span>| <span data-ttu-id="0933d-196">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0933d-196">Forbidden.</span></span>| 
 
<a id="ID4EUH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="0933d-197">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0933d-197">Required Request Headers</span></span>
 
| <span data-ttu-id="0933d-198">Header</span><span class="sxs-lookup"><span data-stu-id="0933d-198">Header</span></span>| <span data-ttu-id="0933d-199">種類</span><span class="sxs-lookup"><span data-stu-id="0933d-199">Type</span></span>| <span data-ttu-id="0933d-200">説明</span><span class="sxs-lookup"><span data-stu-id="0933d-200">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0933d-201">Authorization</span><span class="sxs-lookup"><span data-stu-id="0933d-201">Authorization</span></span>| <span data-ttu-id="0933d-202">string</span><span class="sxs-lookup"><span data-stu-id="0933d-202">string</span></span>| <span data-ttu-id="0933d-203">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="0933d-203">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="0933d-204">値の例:<b>Xauth=&lt;authtoken></b></span><span class="sxs-lookup"><span data-stu-id="0933d-204">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="0933d-205">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="0933d-205">X-RequestedServiceVersion</span></span>| <span data-ttu-id="0933d-206">string</span><span class="sxs-lookup"><span data-stu-id="0933d-206">string</span></span>| <span data-ttu-id="0933d-207">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="0933d-207">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="0933d-208">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="0933d-208">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="0933d-209">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0933d-209">Content-Type</span></span>| <span data-ttu-id="0933d-210">string</span><span class="sxs-lookup"><span data-stu-id="0933d-210">string</span></span>| <span data-ttu-id="0933d-211">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="0933d-211">MIME type of the response body.</span></span> <span data-ttu-id="0933d-212">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0933d-212">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0933d-213">OK</span><span class="sxs-lookup"><span data-stu-id="0933d-213">Accept</span></span>| <span data-ttu-id="0933d-214">string</span><span class="sxs-lookup"><span data-stu-id="0933d-214">string</span></span>| <span data-ttu-id="0933d-215">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="0933d-215">Acceptable values of Content-Type.</span></span> <span data-ttu-id="0933d-216">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0933d-216">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0933d-217">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="0933d-217">Cache-Control</span></span>| <span data-ttu-id="0933d-218">string</span><span class="sxs-lookup"><span data-stu-id="0933d-218">string</span></span>| <span data-ttu-id="0933d-219">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="0933d-219">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EBCAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="0933d-220">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0933d-220">Optional Request Headers</span></span>
 
| <span data-ttu-id="0933d-221">Header</span><span class="sxs-lookup"><span data-stu-id="0933d-221">Header</span></span>| <span data-ttu-id="0933d-222">種類</span><span class="sxs-lookup"><span data-stu-id="0933d-222">Type</span></span>| <span data-ttu-id="0933d-223">説明</span><span class="sxs-lookup"><span data-stu-id="0933d-223">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0933d-224">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="0933d-224">Accept-Encoding</span></span>| <span data-ttu-id="0933d-225">string</span><span class="sxs-lookup"><span data-stu-id="0933d-225">string</span></span>| <span data-ttu-id="0933d-226">許容される圧縮エンコーディング。</span><span class="sxs-lookup"><span data-stu-id="0933d-226">Acceptable compression encodings.</span></span> <span data-ttu-id="0933d-227">値の例: gzip、deflate の id。</span><span class="sxs-lookup"><span data-stu-id="0933d-227">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="0933d-228">ETag</span><span class="sxs-lookup"><span data-stu-id="0933d-228">ETag</span></span>| <span data-ttu-id="0933d-229">string</span><span class="sxs-lookup"><span data-stu-id="0933d-229">string</span></span>| <span data-ttu-id="0933d-230">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="0933d-230">Used for cache optimization.</span></span> <span data-ttu-id="0933d-231">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="0933d-231">Example value: "686897696a7c876b7e".</span></span>| 
| <span data-ttu-id="0933d-232">範囲</span><span class="sxs-lookup"><span data-stu-id="0933d-232">Range</span></span>| <span data-ttu-id="0933d-233">string</span><span class="sxs-lookup"><span data-stu-id="0933d-233">string</span></span>|  | 
  
<a id="ID4ETDAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="0933d-234">要求本文</span><span class="sxs-lookup"><span data-stu-id="0933d-234">Request body</span></span>
 
<span data-ttu-id="0933d-235">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="0933d-235">No objects are sent in the body of this request.</span></span>
  
<a id="ID4E5DAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="0933d-236">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="0933d-236">HTTP status codes</span></span>
 
<span data-ttu-id="0933d-237">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="0933d-237">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="0933d-238">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="0933d-238">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="0933d-239">コード</span><span class="sxs-lookup"><span data-stu-id="0933d-239">Code</span></span>| <span data-ttu-id="0933d-240">理由語句</span><span class="sxs-lookup"><span data-stu-id="0933d-240">Reason phrase</span></span>| <span data-ttu-id="0933d-241">説明</span><span class="sxs-lookup"><span data-stu-id="0933d-241">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0933d-242">200</span><span class="sxs-lookup"><span data-stu-id="0933d-242">200</span></span>| <span data-ttu-id="0933d-243">OK</span><span class="sxs-lookup"><span data-stu-id="0933d-243">OK</span></span>| <span data-ttu-id="0933d-244">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="0933d-244">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="0933d-245">301</span><span class="sxs-lookup"><span data-stu-id="0933d-245">301</span></span>| <span data-ttu-id="0933d-246">完全に移動</span><span class="sxs-lookup"><span data-stu-id="0933d-246">Moved Permanently</span></span>|  | 
| <span data-ttu-id="0933d-247">307</span><span class="sxs-lookup"><span data-stu-id="0933d-247">307</span></span>| <span data-ttu-id="0933d-248">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="0933d-248">Temporary Redirect</span></span>|  | 
| <span data-ttu-id="0933d-249">400</span><span class="sxs-lookup"><span data-stu-id="0933d-249">400</span></span>| <span data-ttu-id="0933d-250">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="0933d-250">Bad Request</span></span>| <span data-ttu-id="0933d-251">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="0933d-251">Service could not understand malformed request.</span></span> <span data-ttu-id="0933d-252">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="0933d-252">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="0933d-253">401</span><span class="sxs-lookup"><span data-stu-id="0933d-253">401</span></span>| <span data-ttu-id="0933d-254">権限がありません</span><span class="sxs-lookup"><span data-stu-id="0933d-254">Unauthorized</span></span>| <span data-ttu-id="0933d-255">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="0933d-255">The request requires user authentication.</span></span>| 
| <span data-ttu-id="0933d-256">403</span><span class="sxs-lookup"><span data-stu-id="0933d-256">403</span></span>| <span data-ttu-id="0933d-257">Forbidden</span><span class="sxs-lookup"><span data-stu-id="0933d-257">Forbidden</span></span>| <span data-ttu-id="0933d-258">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="0933d-258">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="0933d-259">404</span><span class="sxs-lookup"><span data-stu-id="0933d-259">404</span></span>| <span data-ttu-id="0933d-260">検出不可</span><span class="sxs-lookup"><span data-stu-id="0933d-260">Not Found</span></span>| <span data-ttu-id="0933d-261">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="0933d-261">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="0933d-262">406</span><span class="sxs-lookup"><span data-stu-id="0933d-262">406</span></span>| <span data-ttu-id="0933d-263">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="0933d-263">Not Acceptable</span></span>| <span data-ttu-id="0933d-264">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0933d-264">Resource version is not supported.</span></span>| 
| <span data-ttu-id="0933d-265">408</span><span class="sxs-lookup"><span data-stu-id="0933d-265">408</span></span>| <span data-ttu-id="0933d-266">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="0933d-266">Request Timeout</span></span>| <span data-ttu-id="0933d-267">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="0933d-267">The request took too long to complete.</span></span>| 
| <span data-ttu-id="0933d-268">410</span><span class="sxs-lookup"><span data-stu-id="0933d-268">410</span></span>| <span data-ttu-id="0933d-269">なった</span><span class="sxs-lookup"><span data-stu-id="0933d-269">Gone</span></span>| <span data-ttu-id="0933d-270">要求されたリソースは使用できなくします。</span><span class="sxs-lookup"><span data-stu-id="0933d-270">The requested resource is no longer available.</span></span>| 
  
<a id="ID4EQIAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="0933d-271">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0933d-271">Required Response Headers</span></span>
 
| <span data-ttu-id="0933d-272">Header</span><span class="sxs-lookup"><span data-stu-id="0933d-272">Header</span></span>| <span data-ttu-id="0933d-273">種類</span><span class="sxs-lookup"><span data-stu-id="0933d-273">Type</span></span>| <span data-ttu-id="0933d-274">説明</span><span class="sxs-lookup"><span data-stu-id="0933d-274">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0933d-275">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="0933d-275">X-RequestedServiceVersion</span></span>| <span data-ttu-id="0933d-276">string</span><span class="sxs-lookup"><span data-stu-id="0933d-276">string</span></span>| <span data-ttu-id="0933d-277">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="0933d-277">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="0933d-278">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="0933d-278">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="0933d-279">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0933d-279">Content-Type</span></span>| <span data-ttu-id="0933d-280">string</span><span class="sxs-lookup"><span data-stu-id="0933d-280">string</span></span>| <span data-ttu-id="0933d-281">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="0933d-281">MIME type of the response body.</span></span> <span data-ttu-id="0933d-282">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0933d-282">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0933d-283">OK</span><span class="sxs-lookup"><span data-stu-id="0933d-283">Accept</span></span>| <span data-ttu-id="0933d-284">string</span><span class="sxs-lookup"><span data-stu-id="0933d-284">string</span></span>| <span data-ttu-id="0933d-285">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="0933d-285">Acceptable values of Content-Type.</span></span> <span data-ttu-id="0933d-286">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0933d-286">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0933d-287">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="0933d-287">Cache-Control</span></span>| <span data-ttu-id="0933d-288">string</span><span class="sxs-lookup"><span data-stu-id="0933d-288">string</span></span>| <span data-ttu-id="0933d-289">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="0933d-289">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="0933d-290">再試行後</span><span class="sxs-lookup"><span data-stu-id="0933d-290">Retry-After</span></span>| <span data-ttu-id="0933d-291">string</span><span class="sxs-lookup"><span data-stu-id="0933d-291">string</span></span>| <span data-ttu-id="0933d-292">後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。</span><span class="sxs-lookup"><span data-stu-id="0933d-292">Instructs client to try again later in the case of an unavailable server.</span></span> <span data-ttu-id="0933d-293">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0933d-293">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0933d-294">異なる</span><span class="sxs-lookup"><span data-stu-id="0933d-294">Vary</span></span>| <span data-ttu-id="0933d-295">string</span><span class="sxs-lookup"><span data-stu-id="0933d-295">string</span></span>| <span data-ttu-id="0933d-296">ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="0933d-296">Instructs downstream proxies how to cache responses.</span></span> <span data-ttu-id="0933d-297">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0933d-297">Example: <b>application/json</b>.</span></span>| 
  
<a id="ID4EJLAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="0933d-298">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0933d-298">Optional Response Headers</span></span>
 
| <span data-ttu-id="0933d-299">Header</span><span class="sxs-lookup"><span data-stu-id="0933d-299">Header</span></span>| <span data-ttu-id="0933d-300">種類</span><span class="sxs-lookup"><span data-stu-id="0933d-300">Type</span></span>| <span data-ttu-id="0933d-301">説明</span><span class="sxs-lookup"><span data-stu-id="0933d-301">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0933d-302">ETag</span><span class="sxs-lookup"><span data-stu-id="0933d-302">ETag</span></span>| <span data-ttu-id="0933d-303">string</span><span class="sxs-lookup"><span data-stu-id="0933d-303">string</span></span>| <span data-ttu-id="0933d-304">キャッシュの最適化に使用されます。</span><span class="sxs-lookup"><span data-stu-id="0933d-304">Used for cache optimization.</span></span> <span data-ttu-id="0933d-305">値の例:"686897696a7c876b7e"。</span><span class="sxs-lookup"><span data-stu-id="0933d-305">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EJMAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="0933d-306">応答本文</span><span class="sxs-lookup"><span data-stu-id="0933d-306">Response body</span></span>
 
<a id="ID4EPMAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="0933d-307">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="0933d-307">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="0933d-308">関連項目</span><span class="sxs-lookup"><span data-stu-id="0933d-308">See also</span></span>
 
<a id="ID4E2MAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="0933d-309">Parent</span><span class="sxs-lookup"><span data-stu-id="0933d-309">Parent</span></span> 

[<span data-ttu-id="0933d-310">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="0933d-310">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersowneridscidclipsgameclipid.md)

  
<a id="ID4EFNAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="0933d-311">詳細情報</span><span class="sxs-lookup"><span data-stu-id="0933d-311">Further Information</span></span> 

[<span data-ttu-id="0933d-312">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="0933d-312">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

 [<span data-ttu-id="0933d-313">その他の参照</span><span class="sxs-lookup"><span data-stu-id="0933d-313">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   