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
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8890788"
---
# <a name="get-usersowneridscidsscidclipsgameclipid"></a><span data-ttu-id="0d2c2-104">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="0d2c2-104">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span></span>
<span data-ttu-id="0d2c2-105">すべての Id を見つけることがわかっている場合は、システムから 1 つのゲーム クリップを取得します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-105">Get a single game clip from the system if all the IDs to locate it are known.</span></span> <span data-ttu-id="0d2c2-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="0d2c2-107">注釈</span><span class="sxs-lookup"><span data-stu-id="0d2c2-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="0d2c2-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0d2c2-108">URI parameters</span></span>](#ID4EVB)
  * [<span data-ttu-id="0d2c2-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="0d2c2-109">Authorization</span></span>](#ID4EAC)
  * [<span data-ttu-id="0d2c2-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-110">Required Request Headers</span></span>](#ID4EUH)
  * [<span data-ttu-id="0d2c2-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-111">Optional Request Headers</span></span>](#ID4EBCAC)
  * [<span data-ttu-id="0d2c2-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="0d2c2-112">Request body</span></span>](#ID4ETDAC)
  * [<span data-ttu-id="0d2c2-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0d2c2-113">HTTP status codes</span></span>](#ID4E5DAC)
  * [<span data-ttu-id="0d2c2-114">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-114">Required Response Headers</span></span>](#ID4EQIAC)
  * [<span data-ttu-id="0d2c2-115">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-115">Optional Response Headers</span></span>](#ID4EJLAC)
  * [<span data-ttu-id="0d2c2-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="0d2c2-116">Response body</span></span>](#ID4EJMAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="0d2c2-117">注釈</span><span class="sxs-lookup"><span data-stu-id="0d2c2-117">Remarks</span></span>
 
<span data-ttu-id="0d2c2-118">クリップを照会するすべてのデータは**GameClip**オブジェクトとして任意のメタデータ クエリから返される利用できます。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-118">All data to query for the clip is available in the **GameClip** objects as returned from any metadata query.</span></span> <span data-ttu-id="0d2c2-119">この API 経由で 1 つのゲーム クリップを取得するのには、 **XUID**、 **ServiceConfigId**、 **GameClipId**要求の要求で**SandboxId**が必要です。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-119">**XUID**, **ServiceConfigId**, **GameClipId** and **SandboxId** in the claims of the request are required to get a single game clip via this API.</span></span> <span data-ttu-id="0d2c2-120">ゲームのクリップが実施のフラグが設定された、またはコンテンツの分離またはプライバシー チェックがユーザーに特定のゲーム クリップを取得するためのアクセス許可が必要がない判断、API は 404 (見つかりません) の HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-120">If the game clip has been flagged for enforcement, or Content Isolation or privacy checks determine that the user does not have permission to get the specific game clip, the API will return an HTTP status code of 404 (Not Found).</span></span>
 
<span data-ttu-id="0d2c2-121">**SandboxId**はここで、XToken で要求から取得され、適用されます。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-121">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="0d2c2-122">**SandboxId**が存在しない場合は、エンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-122">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>
 
<span data-ttu-id="0d2c2-123">この API は、有効期限が切れた Uri の更新にも使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-123">This API must also be used to refresh expired URIs.</span></span> <span data-ttu-id="0d2c2-124">クエリが完了したら、ゲーム クリップに有効期限が切れたな Uri が更新されたそれに応じて。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-124">When the query is complete, any expired URIs for the game clip will be refreshed accordingly.</span></span> 

> [!NOTE] 
> <span data-ttu-id="0d2c2-125">URI 更新は、最大 30 ~ 40 秒この要求が完了したらにかかることができます。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-125">A URI refresh can take up to 30-40 seconds after this request is done.</span></span> <span data-ttu-id="0d2c2-126">URI の有効期限が切れた場合しようとするとすぐにストリーミング操作の使用すると、IIS スムーズ ストリーミング サーバーから HTTP 500 ステータス コードは取得します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-126">If the URI has expired, attempting to use it immediately for streaming operations will get an HTTP 500 status code from the IIS Smooth Streaming Servers.</span></span> <span data-ttu-id="0d2c2-127">これには、短縮する方法に取り組んでいます、この注がその作業の進行に応じて更新されます。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-127">We are working on ways to shorten this, and this note will be updated accordingly as that work progresses.</span></span> 


  
<a id="ID4EVB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0d2c2-128">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0d2c2-128">URI parameters</span></span>
 
| <span data-ttu-id="0d2c2-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0d2c2-129">Parameter</span></span>| <span data-ttu-id="0d2c2-130">型</span><span class="sxs-lookup"><span data-stu-id="0d2c2-130">Type</span></span>| <span data-ttu-id="0d2c2-131">説明</span><span class="sxs-lookup"><span data-stu-id="0d2c2-131">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="0d2c2-132">ownerId</span><span class="sxs-lookup"><span data-stu-id="0d2c2-132">ownerId</span></span>| <span data-ttu-id="0d2c2-133">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-133">string</span></span>| <span data-ttu-id="0d2c2-134">そのリソースにアクセスしているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-134">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="0d2c2-135">サポートされる形式:"me"または"xuid(123456789)"します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-135">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="0d2c2-136">最大長: 16 します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-136">Maximum length: 16.</span></span>| 
| <span data-ttu-id="0d2c2-137">scid</span><span class="sxs-lookup"><span data-stu-id="0d2c2-137">scid</span></span>| <span data-ttu-id="0d2c2-138">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-138">string</span></span>| <span data-ttu-id="0d2c2-139">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-139">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="0d2c2-140">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-140">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="0d2c2-141">gameClipId</span><span class="sxs-lookup"><span data-stu-id="0d2c2-141">gameClipId</span></span>| <span data-ttu-id="0d2c2-142">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-142">string</span></span>| <span data-ttu-id="0d2c2-143">GameClip にアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-143">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="authorization"></a><span data-ttu-id="0d2c2-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="0d2c2-144">Authorization</span></span>
 
<span data-ttu-id="0d2c2-145">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="0d2c2-145">Authorization claims used</span></span> | <span data-ttu-id="0d2c2-146">要求</span><span class="sxs-lookup"><span data-stu-id="0d2c2-146">Claim</span></span>| <span data-ttu-id="0d2c2-147">種類</span><span class="sxs-lookup"><span data-stu-id="0d2c2-147">Type</span></span>| <span data-ttu-id="0d2c2-148">必須?</span><span class="sxs-lookup"><span data-stu-id="0d2c2-148">Required?</span></span>| <span data-ttu-id="0d2c2-149">値の例</span><span class="sxs-lookup"><span data-stu-id="0d2c2-149">Example value</span></span>| <span data-ttu-id="0d2c2-150">注釈</span><span class="sxs-lookup"><span data-stu-id="0d2c2-150">Remarks</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d2c2-151">Xuid</span><span class="sxs-lookup"><span data-stu-id="0d2c2-151">Xuid</span></span>| <span data-ttu-id="0d2c2-152">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0d2c2-152">64-bit signed integer</span></span>| <span data-ttu-id="0d2c2-153">必須</span><span class="sxs-lookup"><span data-stu-id="0d2c2-153">yes</span></span>| <span data-ttu-id="0d2c2-154">1234567890</span><span class="sxs-lookup"><span data-stu-id="0d2c2-154">1234567890</span></span>|  | 
| <span data-ttu-id="0d2c2-155">TitleId</span><span class="sxs-lookup"><span data-stu-id="0d2c2-155">TitleId</span></span>| <span data-ttu-id="0d2c2-156">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0d2c2-156">64-bit signed integer</span></span>| <span data-ttu-id="0d2c2-157">必須</span><span class="sxs-lookup"><span data-stu-id="0d2c2-157">yes</span></span>| <span data-ttu-id="0d2c2-158">1234567890</span><span class="sxs-lookup"><span data-stu-id="0d2c2-158">1234567890</span></span>| <span data-ttu-id="0d2c2-159"><b>コンテンツ分離</b>チェックに使用されます。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-159">Used for <b>Content-Isolation</b> check.</span></span>| 
| <span data-ttu-id="0d2c2-160">SandboxId</span><span class="sxs-lookup"><span data-stu-id="0d2c2-160">SandboxId</span></span>| <span data-ttu-id="0d2c2-161">16 進数のバイナリ</span><span class="sxs-lookup"><span data-stu-id="0d2c2-161">hexadecimal binary</span></span>| <span data-ttu-id="0d2c2-162">必須</span><span class="sxs-lookup"><span data-stu-id="0d2c2-162">yes</span></span>|  | <span data-ttu-id="0d2c2-163">検索では、適切な領域をシステムに指示し、<b>コンテンツ分離</b>チェックに使用します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-163">Directs the system to the correct area for lookups, and used for <b>Content-Isolation</b> check.</span></span>| 
  
<span data-ttu-id="0d2c2-164">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="0d2c2-164">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="0d2c2-165">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="0d2c2-165">Requesting User</span></span>| <span data-ttu-id="0d2c2-166">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="0d2c2-166">Target User's Privacy Setting</span></span>| <span data-ttu-id="0d2c2-167">動作</span><span class="sxs-lookup"><span data-stu-id="0d2c2-167">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d2c2-168">me</span><span class="sxs-lookup"><span data-stu-id="0d2c2-168">me</span></span>| -| <span data-ttu-id="0d2c2-169">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-169">As described.</span></span>| 
| <span data-ttu-id="0d2c2-170">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="0d2c2-170">friend</span></span>| <span data-ttu-id="0d2c2-171">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-171">everyone</span></span>| <span data-ttu-id="0d2c2-172">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-172">Forbidden.</span></span>| 
| <span data-ttu-id="0d2c2-173">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="0d2c2-173">friend</span></span>| <span data-ttu-id="0d2c2-174">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="0d2c2-174">friends only</span></span>| <span data-ttu-id="0d2c2-175">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-175">Forbidden.</span></span>| 
| <span data-ttu-id="0d2c2-176">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="0d2c2-176">friend</span></span>| <span data-ttu-id="0d2c2-177">ブロック</span><span class="sxs-lookup"><span data-stu-id="0d2c2-177">blocked</span></span>| <span data-ttu-id="0d2c2-178">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-178">Forbidden.</span></span>| 
| <span data-ttu-id="0d2c2-179">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-179">non-friend user</span></span>| <span data-ttu-id="0d2c2-180">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-180">everyone</span></span>| <span data-ttu-id="0d2c2-181">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-181">Forbidden.</span></span>| 
| <span data-ttu-id="0d2c2-182">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-182">non-friend user</span></span>| <span data-ttu-id="0d2c2-183">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="0d2c2-183">friends only</span></span>| <span data-ttu-id="0d2c2-184">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-184">Forbidden.</span></span>| 
| <span data-ttu-id="0d2c2-185">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-185">non-friend user</span></span>| <span data-ttu-id="0d2c2-186">ブロック</span><span class="sxs-lookup"><span data-stu-id="0d2c2-186">blocked</span></span>| <span data-ttu-id="0d2c2-187">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-187">Forbidden.</span></span>| 
| <span data-ttu-id="0d2c2-188">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="0d2c2-188">third-party site</span></span>| <span data-ttu-id="0d2c2-189">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-189">everyone</span></span>| <span data-ttu-id="0d2c2-190">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-190">Forbidden.</span></span>| 
| <span data-ttu-id="0d2c2-191">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="0d2c2-191">third-party site</span></span>| <span data-ttu-id="0d2c2-192">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="0d2c2-192">friends only</span></span>| <span data-ttu-id="0d2c2-193">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-193">Forbidden.</span></span>| 
| <span data-ttu-id="0d2c2-194">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="0d2c2-194">third-party site</span></span>| <span data-ttu-id="0d2c2-195">ブロック</span><span class="sxs-lookup"><span data-stu-id="0d2c2-195">blocked</span></span>| <span data-ttu-id="0d2c2-196">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-196">Forbidden.</span></span>| 
 
<a id="ID4EUH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="0d2c2-197">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-197">Required Request Headers</span></span>
 
| <span data-ttu-id="0d2c2-198">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-198">Header</span></span>| <span data-ttu-id="0d2c2-199">型</span><span class="sxs-lookup"><span data-stu-id="0d2c2-199">Type</span></span>| <span data-ttu-id="0d2c2-200">説明</span><span class="sxs-lookup"><span data-stu-id="0d2c2-200">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d2c2-201">Authorization</span><span class="sxs-lookup"><span data-stu-id="0d2c2-201">Authorization</span></span>| <span data-ttu-id="0d2c2-202">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-202">string</span></span>| <span data-ttu-id="0d2c2-203">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-203">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="0d2c2-204">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="0d2c2-204">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="0d2c2-205">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="0d2c2-205">X-RequestedServiceVersion</span></span>| <span data-ttu-id="0d2c2-206">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-206">string</span></span>| <span data-ttu-id="0d2c2-207">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-207">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="0d2c2-208">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-208">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="0d2c2-209">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0d2c2-209">Content-Type</span></span>| <span data-ttu-id="0d2c2-210">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-210">string</span></span>| <span data-ttu-id="0d2c2-211">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-211">MIME type of the response body.</span></span> <span data-ttu-id="0d2c2-212">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-212">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0d2c2-213">Accept</span><span class="sxs-lookup"><span data-stu-id="0d2c2-213">Accept</span></span>| <span data-ttu-id="0d2c2-214">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-214">string</span></span>| <span data-ttu-id="0d2c2-215">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-215">Acceptable values of Content-Type.</span></span> <span data-ttu-id="0d2c2-216">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-216">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0d2c2-217">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="0d2c2-217">Cache-Control</span></span>| <span data-ttu-id="0d2c2-218">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-218">string</span></span>| <span data-ttu-id="0d2c2-219">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-219">Polite request to specify caching behavior.</span></span>| 
  
<a id="ID4EBCAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="0d2c2-220">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-220">Optional Request Headers</span></span>
 
| <span data-ttu-id="0d2c2-221">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-221">Header</span></span>| <span data-ttu-id="0d2c2-222">型</span><span class="sxs-lookup"><span data-stu-id="0d2c2-222">Type</span></span>| <span data-ttu-id="0d2c2-223">説明</span><span class="sxs-lookup"><span data-stu-id="0d2c2-223">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d2c2-224">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="0d2c2-224">Accept-Encoding</span></span>| <span data-ttu-id="0d2c2-225">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-225">string</span></span>| <span data-ttu-id="0d2c2-226">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-226">Acceptable compression encodings.</span></span> <span data-ttu-id="0d2c2-227">値の例: gzip、身元を圧縮します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-227">Example values: gzip, deflate, identity.</span></span>| 
| <span data-ttu-id="0d2c2-228">ETag</span><span class="sxs-lookup"><span data-stu-id="0d2c2-228">ETag</span></span>| <span data-ttu-id="0d2c2-229">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-229">string</span></span>| <span data-ttu-id="0d2c2-230">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-230">Used for cache optimization.</span></span> <span data-ttu-id="0d2c2-231">値の例:"686897696a7c876b7e"します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-231">Example value: "686897696a7c876b7e".</span></span>| 
| <span data-ttu-id="0d2c2-232">範囲</span><span class="sxs-lookup"><span data-stu-id="0d2c2-232">Range</span></span>| <span data-ttu-id="0d2c2-233">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-233">string</span></span>|  | 
  
<a id="ID4ETDAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="0d2c2-234">要求本文</span><span class="sxs-lookup"><span data-stu-id="0d2c2-234">Request body</span></span>
 
<span data-ttu-id="0d2c2-235">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-235">No objects are sent in the body of this request.</span></span>
  
<a id="ID4E5DAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="0d2c2-236">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0d2c2-236">HTTP status codes</span></span>
 
<span data-ttu-id="0d2c2-237">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-237">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="0d2c2-238">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-238">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="0d2c2-239">コード</span><span class="sxs-lookup"><span data-stu-id="0d2c2-239">Code</span></span>| <span data-ttu-id="0d2c2-240">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="0d2c2-240">Reason phrase</span></span>| <span data-ttu-id="0d2c2-241">説明</span><span class="sxs-lookup"><span data-stu-id="0d2c2-241">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d2c2-242">200</span><span class="sxs-lookup"><span data-stu-id="0d2c2-242">200</span></span>| <span data-ttu-id="0d2c2-243">OK</span><span class="sxs-lookup"><span data-stu-id="0d2c2-243">OK</span></span>| <span data-ttu-id="0d2c2-244">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-244">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="0d2c2-245">301</span><span class="sxs-lookup"><span data-stu-id="0d2c2-245">301</span></span>| <span data-ttu-id="0d2c2-246">完全に移動</span><span class="sxs-lookup"><span data-stu-id="0d2c2-246">Moved Permanently</span></span>|  | 
| <span data-ttu-id="0d2c2-247">307</span><span class="sxs-lookup"><span data-stu-id="0d2c2-247">307</span></span>| <span data-ttu-id="0d2c2-248">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="0d2c2-248">Temporary Redirect</span></span>|  | 
| <span data-ttu-id="0d2c2-249">400</span><span class="sxs-lookup"><span data-stu-id="0d2c2-249">400</span></span>| <span data-ttu-id="0d2c2-250">Bad Request</span><span class="sxs-lookup"><span data-stu-id="0d2c2-250">Bad Request</span></span>| <span data-ttu-id="0d2c2-251">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-251">Service could not understand malformed request.</span></span> <span data-ttu-id="0d2c2-252">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-252">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="0d2c2-253">401</span><span class="sxs-lookup"><span data-stu-id="0d2c2-253">401</span></span>| <span data-ttu-id="0d2c2-254">権限がありません</span><span class="sxs-lookup"><span data-stu-id="0d2c2-254">Unauthorized</span></span>| <span data-ttu-id="0d2c2-255">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-255">The request requires user authentication.</span></span>| 
| <span data-ttu-id="0d2c2-256">403</span><span class="sxs-lookup"><span data-stu-id="0d2c2-256">403</span></span>| <span data-ttu-id="0d2c2-257">Forbidden</span><span class="sxs-lookup"><span data-stu-id="0d2c2-257">Forbidden</span></span>| <span data-ttu-id="0d2c2-258">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-258">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="0d2c2-259">404</span><span class="sxs-lookup"><span data-stu-id="0d2c2-259">404</span></span>| <span data-ttu-id="0d2c2-260">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-260">Not Found</span></span>| <span data-ttu-id="0d2c2-261">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-261">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="0d2c2-262">406</span><span class="sxs-lookup"><span data-stu-id="0d2c2-262">406</span></span>| <span data-ttu-id="0d2c2-263">許容できません。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-263">Not Acceptable</span></span>| <span data-ttu-id="0d2c2-264">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-264">Resource version is not supported.</span></span>| 
| <span data-ttu-id="0d2c2-265">408</span><span class="sxs-lookup"><span data-stu-id="0d2c2-265">408</span></span>| <span data-ttu-id="0d2c2-266">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="0d2c2-266">Request Timeout</span></span>| <span data-ttu-id="0d2c2-267">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-267">The request took too long to complete.</span></span>| 
| <span data-ttu-id="0d2c2-268">410</span><span class="sxs-lookup"><span data-stu-id="0d2c2-268">410</span></span>| <span data-ttu-id="0d2c2-269">なった</span><span class="sxs-lookup"><span data-stu-id="0d2c2-269">Gone</span></span>| <span data-ttu-id="0d2c2-270">要求されたリソースが利用可能ではなくなりました。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-270">The requested resource is no longer available.</span></span>| 
  
<a id="ID4EQIAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="0d2c2-271">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-271">Required Response Headers</span></span>
 
| <span data-ttu-id="0d2c2-272">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-272">Header</span></span>| <span data-ttu-id="0d2c2-273">型</span><span class="sxs-lookup"><span data-stu-id="0d2c2-273">Type</span></span>| <span data-ttu-id="0d2c2-274">説明</span><span class="sxs-lookup"><span data-stu-id="0d2c2-274">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d2c2-275">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="0d2c2-275">X-RequestedServiceVersion</span></span>| <span data-ttu-id="0d2c2-276">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-276">string</span></span>| <span data-ttu-id="0d2c2-277">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-277">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="0d2c2-278">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-278">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="0d2c2-279">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0d2c2-279">Content-Type</span></span>| <span data-ttu-id="0d2c2-280">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-280">string</span></span>| <span data-ttu-id="0d2c2-281">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-281">MIME type of the response body.</span></span> <span data-ttu-id="0d2c2-282">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-282">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0d2c2-283">Accept</span><span class="sxs-lookup"><span data-stu-id="0d2c2-283">Accept</span></span>| <span data-ttu-id="0d2c2-284">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-284">string</span></span>| <span data-ttu-id="0d2c2-285">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-285">Acceptable values of Content-Type.</span></span> <span data-ttu-id="0d2c2-286">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-286">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0d2c2-287">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="0d2c2-287">Cache-Control</span></span>| <span data-ttu-id="0d2c2-288">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-288">string</span></span>| <span data-ttu-id="0d2c2-289">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-289">Polite request to specify caching behavior.</span></span>| 
| <span data-ttu-id="0d2c2-290">Retry-after</span><span class="sxs-lookup"><span data-stu-id="0d2c2-290">Retry-After</span></span>| <span data-ttu-id="0d2c2-291">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-291">string</span></span>| <span data-ttu-id="0d2c2-292">クライアントが利用できないサーバーの場合、後で再試行するように指示します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-292">Instructs client to try again later in the case of an unavailable server.</span></span> <span data-ttu-id="0d2c2-293">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-293">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="0d2c2-294">異なる</span><span class="sxs-lookup"><span data-stu-id="0d2c2-294">Vary</span></span>| <span data-ttu-id="0d2c2-295">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-295">string</span></span>| <span data-ttu-id="0d2c2-296">下位のプロキシの応答をキャッシュする方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-296">Instructs downstream proxies how to cache responses.</span></span> <span data-ttu-id="0d2c2-297">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-297">Example: <b>application/json</b>.</span></span>| 
  
<a id="ID4EJLAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="0d2c2-298">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-298">Optional Response Headers</span></span>
 
| <span data-ttu-id="0d2c2-299">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d2c2-299">Header</span></span>| <span data-ttu-id="0d2c2-300">型</span><span class="sxs-lookup"><span data-stu-id="0d2c2-300">Type</span></span>| <span data-ttu-id="0d2c2-301">説明</span><span class="sxs-lookup"><span data-stu-id="0d2c2-301">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d2c2-302">ETag</span><span class="sxs-lookup"><span data-stu-id="0d2c2-302">ETag</span></span>| <span data-ttu-id="0d2c2-303">string</span><span class="sxs-lookup"><span data-stu-id="0d2c2-303">string</span></span>| <span data-ttu-id="0d2c2-304">キャッシュの最適化のために使用します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-304">Used for cache optimization.</span></span> <span data-ttu-id="0d2c2-305">値の例:"686897696a7c876b7e"します。</span><span class="sxs-lookup"><span data-stu-id="0d2c2-305">Example value: "686897696a7c876b7e".</span></span>| 
  
<a id="ID4EJMAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="0d2c2-306">応答本文</span><span class="sxs-lookup"><span data-stu-id="0d2c2-306">Response body</span></span>
 
<a id="ID4EPMAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="0d2c2-307">応答の例</span><span class="sxs-lookup"><span data-stu-id="0d2c2-307">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="0d2c2-308">関連項目</span><span class="sxs-lookup"><span data-stu-id="0d2c2-308">See also</span></span>
 
<a id="ID4E2MAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="0d2c2-309">Parent</span><span class="sxs-lookup"><span data-stu-id="0d2c2-309">Parent</span></span> 

[<span data-ttu-id="0d2c2-310">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="0d2c2-310">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersowneridscidclipsgameclipid.md)

  
<a id="ID4EFNAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="0d2c2-311">詳細情報</span><span class="sxs-lookup"><span data-stu-id="0d2c2-311">Further Information</span></span> 

[<span data-ttu-id="0d2c2-312">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="0d2c2-312">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

 [<span data-ttu-id="0d2c2-313">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="0d2c2-313">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   