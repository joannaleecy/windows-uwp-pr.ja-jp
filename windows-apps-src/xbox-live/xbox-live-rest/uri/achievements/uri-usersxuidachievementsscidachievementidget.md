---
title: GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})
assetID: 27318886-f084-d6a8-e582-3eb070ccbc38
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementidget.html
description: " GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 19083937d48d8c312215f1734513d83c59f52f0d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627507"
---
# <a name="get-usersxuidxuidachievementsscidachievementid"></a><span data-ttu-id="03ba8-104">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span><span class="sxs-lookup"><span data-stu-id="03ba8-104">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span></span>
<span data-ttu-id="03ba8-105">実績の詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-105">Gets the details of the Achievement.</span></span> <span data-ttu-id="03ba8-106">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-106">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="03ba8-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="03ba8-107">URI parameters</span></span>](#ID4EV)
  * [<span data-ttu-id="03ba8-108">承認</span><span class="sxs-lookup"><span data-stu-id="03ba8-108">Authorization</span></span>](#ID4EAB)
  * [<span data-ttu-id="03ba8-109">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="03ba8-109">Effect of privacy settings on resource</span></span>](#ID4E4C)
  * [<span data-ttu-id="03ba8-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="03ba8-110">Required Request Headers</span></span>](#ID4EPG)
  * [<span data-ttu-id="03ba8-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="03ba8-111">Optional Request Headers</span></span>](#ID4EPH)
  * [<span data-ttu-id="03ba8-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="03ba8-112">Request body</span></span>](#ID4ECBAC)
  * [<span data-ttu-id="03ba8-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="03ba8-113">HTTP status codes</span></span>](#ID4ENBAC)
  * [<span data-ttu-id="03ba8-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="03ba8-114">Response body</span></span>](#ID4EBGAC)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="03ba8-115">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="03ba8-115">URI parameters</span></span>
 
| <span data-ttu-id="03ba8-116">パラメーター</span><span class="sxs-lookup"><span data-stu-id="03ba8-116">Parameter</span></span>| <span data-ttu-id="03ba8-117">種類</span><span class="sxs-lookup"><span data-stu-id="03ba8-117">Type</span></span>| <span data-ttu-id="03ba8-118">説明</span><span class="sxs-lookup"><span data-stu-id="03ba8-118">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="03ba8-119">xuid</span><span class="sxs-lookup"><span data-stu-id="03ba8-119">xuid</span></span>| <span data-ttu-id="03ba8-120">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="03ba8-120">64-bit unsigned integer</span></span>| <span data-ttu-id="03ba8-121">Xbox ユーザー ID (XUID)、ユーザーがリソースにアクセスされているのです。</span><span class="sxs-lookup"><span data-stu-id="03ba8-121">Xbox User ID (XUID) of the user whose resource is being accessed.</span></span> <span data-ttu-id="03ba8-122">認証されたユーザーの XUID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="03ba8-122">Must match the XUID of the authenticated user.</span></span>| 
| <span data-ttu-id="03ba8-123">scid</span><span class="sxs-lookup"><span data-stu-id="03ba8-123">scid</span></span>| <span data-ttu-id="03ba8-124">GUID</span><span class="sxs-lookup"><span data-stu-id="03ba8-124">GUID</span></span>| <span data-ttu-id="03ba8-125">達成にアクセスしているサービス構成の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="03ba8-125">Unique identifier of the service configuration whose achievement is being accessed.</span></span>| 
| <span data-ttu-id="03ba8-126">achievementid</span><span class="sxs-lookup"><span data-stu-id="03ba8-126">achievementid</span></span>| <span data-ttu-id="03ba8-127">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="03ba8-127">32-bit unsigned integer</span></span>| <span data-ttu-id="03ba8-128">アクセスされている実績を (指定された SCID) 内で一意の識別子です。</span><span class="sxs-lookup"><span data-stu-id="03ba8-128">Unique (within the specified SCID) identifier of the achievement that is being accessed.</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="authorization"></a><span data-ttu-id="03ba8-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="03ba8-129">Authorization</span></span>
 
<span data-ttu-id="03ba8-130">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="03ba8-130">Authorization claims used</span></span> | <span data-ttu-id="03ba8-131">要求</span><span class="sxs-lookup"><span data-stu-id="03ba8-131">Claim</span></span>| <span data-ttu-id="03ba8-132">必須?</span><span class="sxs-lookup"><span data-stu-id="03ba8-132">Required?</span></span>| <span data-ttu-id="03ba8-133">説明</span><span class="sxs-lookup"><span data-stu-id="03ba8-133">Description</span></span>| <span data-ttu-id="03ba8-134">不足している場合の動作</span><span class="sxs-lookup"><span data-stu-id="03ba8-134">Behavior if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="03ba8-135">ユーザー</span><span class="sxs-lookup"><span data-stu-id="03ba8-135">User</span></span>| <span data-ttu-id="03ba8-136">〇</span><span class="sxs-lookup"><span data-stu-id="03ba8-136">Yes</span></span>| <span data-ttu-id="03ba8-137">Xbox LIVE、要求が行われるに有効なユーザー。</span><span class="sxs-lookup"><span data-stu-id="03ba8-137">A valid user on Xbox LIVE for whom the request is being made.</span></span>| <span data-ttu-id="03ba8-138">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="03ba8-138">403 Forbidden</span></span>| 
| <span data-ttu-id="03ba8-139">タイトル</span><span class="sxs-lookup"><span data-stu-id="03ba8-139">Title</span></span>| <span data-ttu-id="03ba8-140">X</span><span class="sxs-lookup"><span data-stu-id="03ba8-140">No</span></span>| <span data-ttu-id="03ba8-141">呼び出し元のタイトル。</span><span class="sxs-lookup"><span data-stu-id="03ba8-141">The calling title.</span></span>| <span data-ttu-id="03ba8-142">AuthZ に依存します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-142">Depends on AuthZ.</span></span> <span data-ttu-id="03ba8-143">2013 年 5 月 1 日現在 AuthZ は不足するいると、public としてマークされていない任意の SCIDs にアクセスが拒否されますので、要求を提供していません。</span><span class="sxs-lookup"><span data-stu-id="03ba8-143">As of May 1, 2013, AuthZ does not supply a claim when missing and will therefore deny access to any SCIDs not marked as public.</span></span>| 
| <span data-ttu-id="03ba8-144">サンドボックス</span><span class="sxs-lookup"><span data-stu-id="03ba8-144">Sandbox</span></span>| <span data-ttu-id="03ba8-145">X</span><span class="sxs-lookup"><span data-stu-id="03ba8-145">No</span></span>| <span data-ttu-id="03ba8-146">結果の取得元のサンド ボックス。</span><span class="sxs-lookup"><span data-stu-id="03ba8-146">The sandbox from which the results should be retrieved.</span></span>| <span data-ttu-id="03ba8-147">AuthZ に依存します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-147">Depends on AuthZ.</span></span> <span data-ttu-id="03ba8-148">2013 年 5 月 1 日現在 AuthZ は既定の要求を指定しない不足しているときにします。</span><span class="sxs-lookup"><span data-stu-id="03ba8-148">As of May 1, 2013, AuthZ does not supply a default claim when missing.</span></span>| 
  
<a id="ID4E4C"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="03ba8-149">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="03ba8-149">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="03ba8-150">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="03ba8-150">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="03ba8-151">要求元のユーザー</span><span class="sxs-lookup"><span data-stu-id="03ba8-151">Requesting User</span></span>| <span data-ttu-id="03ba8-152">ターゲット ユーザーのプライバシーの設定</span><span class="sxs-lookup"><span data-stu-id="03ba8-152">Target User's Privacy Setting</span></span>| <span data-ttu-id="03ba8-153">動作</span><span class="sxs-lookup"><span data-stu-id="03ba8-153">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="03ba8-154">Me</span><span class="sxs-lookup"><span data-stu-id="03ba8-154">me</span></span>| -| <span data-ttu-id="03ba8-155">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="03ba8-155">As described.</span></span>| 
| <span data-ttu-id="03ba8-156">friend</span><span class="sxs-lookup"><span data-stu-id="03ba8-156">friend</span></span>| <span data-ttu-id="03ba8-157">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="03ba8-157">everyone</span></span>| <span data-ttu-id="03ba8-158">OK</span><span class="sxs-lookup"><span data-stu-id="03ba8-158">OK</span></span>| 
| <span data-ttu-id="03ba8-159">friend</span><span class="sxs-lookup"><span data-stu-id="03ba8-159">friend</span></span>| <span data-ttu-id="03ba8-160">友達のみ</span><span class="sxs-lookup"><span data-stu-id="03ba8-160">friends only</span></span>| <span data-ttu-id="03ba8-161">OK</span><span class="sxs-lookup"><span data-stu-id="03ba8-161">OK</span></span>| 
| <span data-ttu-id="03ba8-162">friend</span><span class="sxs-lookup"><span data-stu-id="03ba8-162">friend</span></span>| <span data-ttu-id="03ba8-163">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="03ba8-163">blocked</span></span>| <span data-ttu-id="03ba8-164">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="03ba8-164">Forbidden.</span></span>| 
| <span data-ttu-id="03ba8-165">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="03ba8-165">non-friend user</span></span>| <span data-ttu-id="03ba8-166">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="03ba8-166">everyone</span></span>| <span data-ttu-id="03ba8-167">OK</span><span class="sxs-lookup"><span data-stu-id="03ba8-167">OK</span></span>| 
| <span data-ttu-id="03ba8-168">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="03ba8-168">non-friend user</span></span>| <span data-ttu-id="03ba8-169">友達のみ</span><span class="sxs-lookup"><span data-stu-id="03ba8-169">friends only</span></span>| <span data-ttu-id="03ba8-170">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="03ba8-170">Forbidden.</span></span>| 
| <span data-ttu-id="03ba8-171">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="03ba8-171">non-friend user</span></span>| <span data-ttu-id="03ba8-172">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="03ba8-172">blocked</span></span>| <span data-ttu-id="03ba8-173">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="03ba8-173">Forbidden.</span></span>| 
| <span data-ttu-id="03ba8-174">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="03ba8-174">third-party site</span></span>| <span data-ttu-id="03ba8-175">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="03ba8-175">everyone</span></span>| <span data-ttu-id="03ba8-176">OK</span><span class="sxs-lookup"><span data-stu-id="03ba8-176">OK</span></span>| 
| <span data-ttu-id="03ba8-177">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="03ba8-177">third-party site</span></span>| <span data-ttu-id="03ba8-178">友達のみ</span><span class="sxs-lookup"><span data-stu-id="03ba8-178">friends only</span></span>| <span data-ttu-id="03ba8-179">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="03ba8-179">Forbidden.</span></span>| 
| <span data-ttu-id="03ba8-180">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="03ba8-180">third-party site</span></span>| <span data-ttu-id="03ba8-181">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="03ba8-181">blocked</span></span>| <span data-ttu-id="03ba8-182">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="03ba8-182">Forbidden.</span></span>| 
  
<a id="ID4EPG"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="03ba8-183">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="03ba8-183">Required Request Headers</span></span>
 
| <span data-ttu-id="03ba8-184">Header</span><span class="sxs-lookup"><span data-stu-id="03ba8-184">Header</span></span>| <span data-ttu-id="03ba8-185">種類</span><span class="sxs-lookup"><span data-stu-id="03ba8-185">Type</span></span>| <span data-ttu-id="03ba8-186">説明</span><span class="sxs-lookup"><span data-stu-id="03ba8-186">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="03ba8-187">Authorization</span><span class="sxs-lookup"><span data-stu-id="03ba8-187">Authorization</span></span>| <span data-ttu-id="03ba8-188">string</span><span class="sxs-lookup"><span data-stu-id="03ba8-188">string</span></span>| <span data-ttu-id="03ba8-189">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-189">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="03ba8-190">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="03ba8-190">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
  
<a id="ID4EPH"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="03ba8-191">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="03ba8-191">Optional Request Headers</span></span>
 
| <span data-ttu-id="03ba8-192">Header</span><span class="sxs-lookup"><span data-stu-id="03ba8-192">Header</span></span>| <span data-ttu-id="03ba8-193">種類</span><span class="sxs-lookup"><span data-stu-id="03ba8-193">Type</span></span>| <span data-ttu-id="03ba8-194">説明</span><span class="sxs-lookup"><span data-stu-id="03ba8-194">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="03ba8-195">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="03ba8-195">X-RequestedServiceVersion</span></span>| <span data-ttu-id="03ba8-196">string</span><span class="sxs-lookup"><span data-stu-id="03ba8-196">string</span></span>| <span data-ttu-id="03ba8-197">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="03ba8-197">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="03ba8-198">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="03ba8-198">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="03ba8-199">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="03ba8-199">Default value: 1.</span></span>| 
| <span data-ttu-id="03ba8-200">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="03ba8-200">x-xbl-contract-version</span></span>| <span data-ttu-id="03ba8-201">string</span><span class="sxs-lookup"><span data-stu-id="03ba8-201">string</span></span>| <span data-ttu-id="03ba8-202">V1 の既定値です。</span><span class="sxs-lookup"><span data-stu-id="03ba8-202">Defaults to V1.</span></span>| 
| <span data-ttu-id="03ba8-203">Accept Language</span><span class="sxs-lookup"><span data-stu-id="03ba8-203">Accept-Language</span></span>| <span data-ttu-id="03ba8-204">string</span><span class="sxs-lookup"><span data-stu-id="03ba8-204">string</span></span>| <span data-ttu-id="03ba8-205">目的のロケールとフォールバック (FR-FR、fr、EN-GB、en WW、EN-US など) の一覧です。</span><span class="sxs-lookup"><span data-stu-id="03ba8-205">List of desired locales and fallbacks (e.g., fr-FR, fr, en-GB, en-WW, en-US).</span></span> <span data-ttu-id="03ba8-206">ローカライズされた文字列の一致が見つかるまで一覧をアチーブメント サービスの動作します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-206">The Achievements service will work through the list until it finds matching localized strings.</span></span> <span data-ttu-id="03ba8-207">見つからない場合、ユーザーの IP アドレスから付属しているユーザー トークンで定義されている場所を照合しようと試みます。</span><span class="sxs-lookup"><span data-stu-id="03ba8-207">If none are found, it attempts to match the location defined in the user token, which comes from the user's IP address.</span></span> <span data-ttu-id="03ba8-208">いない対応するローカライズされた文字列もが見つかった場合は、タイトルの開発者/発行元によって提供される既定の文字列を使用します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-208">If still no matching localized strings are found, it uses the default strings provided by the title developer/publisher.</span></span> | 
  
<a id="ID4ECBAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="03ba8-209">要求本文</span><span class="sxs-lookup"><span data-stu-id="03ba8-209">Request body</span></span>
 
<span data-ttu-id="03ba8-210">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="03ba8-210">No objects are sent in the body of this request.</span></span>
  
<a id="ID4ENBAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="03ba8-211">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="03ba8-211">HTTP status codes</span></span>
 
<span data-ttu-id="03ba8-212">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-212">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="03ba8-213">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-213">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="03ba8-214">コード</span><span class="sxs-lookup"><span data-stu-id="03ba8-214">Code</span></span>| <span data-ttu-id="03ba8-215">理由語句</span><span class="sxs-lookup"><span data-stu-id="03ba8-215">Reason phrase</span></span>| <span data-ttu-id="03ba8-216">説明</span><span class="sxs-lookup"><span data-stu-id="03ba8-216">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="03ba8-217">200</span><span class="sxs-lookup"><span data-stu-id="03ba8-217">200</span></span>| <span data-ttu-id="03ba8-218">OK</span><span class="sxs-lookup"><span data-stu-id="03ba8-218">OK</span></span>| <span data-ttu-id="03ba8-219">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-219">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="03ba8-220">301</span><span class="sxs-lookup"><span data-stu-id="03ba8-220">301</span></span>| <span data-ttu-id="03ba8-221">完全に移動</span><span class="sxs-lookup"><span data-stu-id="03ba8-221">Moved Permanently</span></span>| <span data-ttu-id="03ba8-222">サービスが別の URI に移動します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-222">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="03ba8-223">307</span><span class="sxs-lookup"><span data-stu-id="03ba8-223">307</span></span>| <span data-ttu-id="03ba8-224">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="03ba8-224">Temporary Redirect</span></span>| <span data-ttu-id="03ba8-225">このリソースの URI が一時的に変更されました。</span><span class="sxs-lookup"><span data-stu-id="03ba8-225">The URI for this resource has temporarily changed.</span></span>| 
| <span data-ttu-id="03ba8-226">400</span><span class="sxs-lookup"><span data-stu-id="03ba8-226">400</span></span>| <span data-ttu-id="03ba8-227">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="03ba8-227">Bad Request</span></span>| <span data-ttu-id="03ba8-228">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="03ba8-228">Service could not understand malformed request.</span></span> <span data-ttu-id="03ba8-229">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="03ba8-229">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="03ba8-230">401</span><span class="sxs-lookup"><span data-stu-id="03ba8-230">401</span></span>| <span data-ttu-id="03ba8-231">権限がありません</span><span class="sxs-lookup"><span data-stu-id="03ba8-231">Unauthorized</span></span>| <span data-ttu-id="03ba8-232">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="03ba8-232">The request requires user authentication.</span></span>| 
| <span data-ttu-id="03ba8-233">403</span><span class="sxs-lookup"><span data-stu-id="03ba8-233">403</span></span>| <span data-ttu-id="03ba8-234">Forbidden</span><span class="sxs-lookup"><span data-stu-id="03ba8-234">Forbidden</span></span>| <span data-ttu-id="03ba8-235">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="03ba8-235">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="03ba8-236">404</span><span class="sxs-lookup"><span data-stu-id="03ba8-236">404</span></span>| <span data-ttu-id="03ba8-237">検出不可</span><span class="sxs-lookup"><span data-stu-id="03ba8-237">Not Found</span></span>| <span data-ttu-id="03ba8-238">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="03ba8-238">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="03ba8-239">406</span><span class="sxs-lookup"><span data-stu-id="03ba8-239">406</span></span>| <span data-ttu-id="03ba8-240">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="03ba8-240">Not Acceptable</span></span>| <span data-ttu-id="03ba8-241">リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。</span><span class="sxs-lookup"><span data-stu-id="03ba8-241">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
| <span data-ttu-id="03ba8-242">408</span><span class="sxs-lookup"><span data-stu-id="03ba8-242">408</span></span>| <span data-ttu-id="03ba8-243">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="03ba8-243">Request Timeout</span></span>| <span data-ttu-id="03ba8-244">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="03ba8-244">The request took too long to complete.</span></span>| 
| <span data-ttu-id="03ba8-245">410</span><span class="sxs-lookup"><span data-stu-id="03ba8-245">410</span></span>| <span data-ttu-id="03ba8-246">なった</span><span class="sxs-lookup"><span data-stu-id="03ba8-246">Gone</span></span>| <span data-ttu-id="03ba8-247">要求されたリソースは使用できなくします。</span><span class="sxs-lookup"><span data-stu-id="03ba8-247">The requested resource is no longer available.</span></span>| 
  
<a id="ID4EBGAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="03ba8-248">応答本文</span><span class="sxs-lookup"><span data-stu-id="03ba8-248">Response body</span></span>
 
<a id="ID4EHGAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="03ba8-249">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="03ba8-249">Sample response</span></span>
 

```cpp
{
    "achievement":
    {
        "id":"3",
        "serviceConfigId":"b5dd9daf-0000-0000-0000-000000000000",
        "name":"Default NameString for Microsoft Achievements Sample Achievement 3",
        "titleAssociations":
        [{
                "name":"Microsoft Achievements Sample",
                "id":3051199919,
                "version":"abc"
        }],
        "progressState":"Achieved",
        "progression":
        {
                "requirements":null,
                "timeUnlocked":"2013-01-17T03:19:00.3087016Z",
        },
        "mediaAssets":
        [{
                "name":"Icon Name",
                "type":"Icon",
                "url":"https://www.xbox.com"
        }],
        "platform":"D",
        "isSecret":true,
        "description":"Default DescriptionString for Microsoft Achievements Sample Achievement 3",
        "lockedDescription":"Default UnachievedString for Microsoft Achievements Sample Achievement 3",
        "productId":"12345678-1234-1234-1234-123456789012",
        "achievementType":"Challenge",
        "participationType":"Individual",
        "timeWindow":
        {
                "startDate":"2013-02-01T00:00:00Z",
                "endDate":"2100-07-01T00:00:00Z"
        },
        "rewards":
        [{
                "name":null,
                "description":null,
                "value":"10",
                "type":"Gamerscore",
                "valueType":"Int"
        },
        {
                "name":"Default Name for InAppReward for Microsoft Achievements Sample Achievement 3",
                "description":"Default Description for InAppReward for Microsoft Achievements Sample Achievement 3",
                "value":"1",
                "type":"InApp",
                "valueType":"String"
        }],
        "estimatedTime":"06:12:14",
        "deeplink":"aWFtYWRlZXBsaW5r",
        "isRevoked":false
    }
}
         
```

   
<a id="ID4ERGAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="03ba8-250">関連項目</span><span class="sxs-lookup"><span data-stu-id="03ba8-250">See also</span></span>
 
<a id="ID4ETGAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="03ba8-251">Parent</span><span class="sxs-lookup"><span data-stu-id="03ba8-251">Parent</span></span> 

[<span data-ttu-id="03ba8-252">/users/xuid({xuid})/achievements/{scid}/{achievementid}</span><span class="sxs-lookup"><span data-stu-id="03ba8-252">/users/xuid({xuid})/achievements/{scid}/{achievementid}</span></span>](uri-usersxuidachievementsscidachievementid.md)

   