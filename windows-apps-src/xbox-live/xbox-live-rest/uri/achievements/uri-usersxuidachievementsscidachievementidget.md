---
title: GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})
assetID: 27318886-f084-d6a8-e582-3eb070ccbc38
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementidget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d64dc9fbae0e53880578ebff7576b028d6ecdf49
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3963115"
---
# <a name="get-usersxuidxuidachievementsscidachievementid"></a><span data-ttu-id="22f12-104">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span><span class="sxs-lookup"><span data-stu-id="22f12-104">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span></span>
<span data-ttu-id="22f12-105">実績の詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="22f12-105">Gets the details of the Achievement.</span></span> <span data-ttu-id="22f12-106">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="22f12-106">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="22f12-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="22f12-107">URI parameters</span></span>](#ID4EV)
  * [<span data-ttu-id="22f12-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="22f12-108">Authorization</span></span>](#ID4EAB)
  * [<span data-ttu-id="22f12-109">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="22f12-109">Effect of privacy settings on resource</span></span>](#ID4E4C)
  * [<span data-ttu-id="22f12-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="22f12-110">Required Request Headers</span></span>](#ID4EPG)
  * [<span data-ttu-id="22f12-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="22f12-111">Optional Request Headers</span></span>](#ID4EPH)
  * [<span data-ttu-id="22f12-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="22f12-112">Request body</span></span>](#ID4ECBAC)
  * [<span data-ttu-id="22f12-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="22f12-113">HTTP status codes</span></span>](#ID4ENBAC)
  * [<span data-ttu-id="22f12-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="22f12-114">Response body</span></span>](#ID4EBGAC)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="22f12-115">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="22f12-115">URI parameters</span></span>
 
| <span data-ttu-id="22f12-116">パラメーター</span><span class="sxs-lookup"><span data-stu-id="22f12-116">Parameter</span></span>| <span data-ttu-id="22f12-117">型</span><span class="sxs-lookup"><span data-stu-id="22f12-117">Type</span></span>| <span data-ttu-id="22f12-118">説明</span><span class="sxs-lookup"><span data-stu-id="22f12-118">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="22f12-119">xuid</span><span class="sxs-lookup"><span data-stu-id="22f12-119">xuid</span></span>| <span data-ttu-id="22f12-120">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="22f12-120">64-bit unsigned integer</span></span>| <span data-ttu-id="22f12-121">Xbox ユーザー ID (XUID) がリソースにアクセスしているユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="22f12-121">Xbox User ID (XUID) of the user whose resource is being accessed.</span></span> <span data-ttu-id="22f12-122">認証されたユーザーの XUID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="22f12-122">Must match the XUID of the authenticated user.</span></span>| 
| <span data-ttu-id="22f12-123">scid</span><span class="sxs-lookup"><span data-stu-id="22f12-123">scid</span></span>| <span data-ttu-id="22f12-124">GUID</span><span class="sxs-lookup"><span data-stu-id="22f12-124">GUID</span></span>| <span data-ttu-id="22f12-125">その実績にアクセスしているサービス構成の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="22f12-125">Unique identifier of the service configuration whose achievement is being accessed.</span></span>| 
| <span data-ttu-id="22f12-126">achievementid</span><span class="sxs-lookup"><span data-stu-id="22f12-126">achievementid</span></span>| <span data-ttu-id="22f12-127">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="22f12-127">32-bit unsigned integer</span></span>| <span data-ttu-id="22f12-128">アクセスされている実績の (指定された SCID) 内で一意の識別子です。</span><span class="sxs-lookup"><span data-stu-id="22f12-128">Unique (within the specified SCID) identifier of the achievement that is being accessed.</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="authorization"></a><span data-ttu-id="22f12-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="22f12-129">Authorization</span></span>
 
<span data-ttu-id="22f12-130">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="22f12-130">Authorization claims used</span></span> | <span data-ttu-id="22f12-131">要求</span><span class="sxs-lookup"><span data-stu-id="22f12-131">Claim</span></span>| <span data-ttu-id="22f12-132">必須?</span><span class="sxs-lookup"><span data-stu-id="22f12-132">Required?</span></span>| <span data-ttu-id="22f12-133">説明</span><span class="sxs-lookup"><span data-stu-id="22f12-133">Description</span></span>| <span data-ttu-id="22f12-134">不足している場合の動作</span><span class="sxs-lookup"><span data-stu-id="22f12-134">Behavior if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="22f12-135">ユーザー</span><span class="sxs-lookup"><span data-stu-id="22f12-135">User</span></span>| <span data-ttu-id="22f12-136">はい</span><span class="sxs-lookup"><span data-stu-id="22f12-136">Yes</span></span>| <span data-ttu-id="22f12-137">Xbox live、要求が作成されている対象の有効なユーザーです。</span><span class="sxs-lookup"><span data-stu-id="22f12-137">A valid user on Xbox LIVE for whom the request is being made.</span></span>| <span data-ttu-id="22f12-138">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="22f12-138">403 Forbidden</span></span>| 
| <span data-ttu-id="22f12-139">Title (タイトル)</span><span class="sxs-lookup"><span data-stu-id="22f12-139">Title</span></span>| <span data-ttu-id="22f12-140">いいえ</span><span class="sxs-lookup"><span data-stu-id="22f12-140">No</span></span>| <span data-ttu-id="22f12-141">呼び出し元のタイトルです。</span><span class="sxs-lookup"><span data-stu-id="22f12-141">The calling title.</span></span>| <span data-ttu-id="22f12-142">AuthZ によって異なります。</span><span class="sxs-lookup"><span data-stu-id="22f12-142">Depends on AuthZ.</span></span> <span data-ttu-id="22f12-143">2013 月 1 日の時点で AuthZ は不足するいると、パブリックとしてマークされていないすべての Scid にアクセスが拒否されるための要求を提供しません。</span><span class="sxs-lookup"><span data-stu-id="22f12-143">As of May 1, 2013, AuthZ does not supply a claim when missing and will therefore deny access to any SCIDs not marked as public.</span></span>| 
| <span data-ttu-id="22f12-144">サンド ボックス</span><span class="sxs-lookup"><span data-stu-id="22f12-144">Sandbox</span></span>| <span data-ttu-id="22f12-145">いいえ</span><span class="sxs-lookup"><span data-stu-id="22f12-145">No</span></span>| <span data-ttu-id="22f12-146">サンド ボックスが、結果を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="22f12-146">The sandbox from which the results should be retrieved.</span></span>| <span data-ttu-id="22f12-147">AuthZ によって異なります。</span><span class="sxs-lookup"><span data-stu-id="22f12-147">Depends on AuthZ.</span></span> <span data-ttu-id="22f12-148">2013 月 1 日の時点で AuthZ は既定の要求を提供しません不足している場合。</span><span class="sxs-lookup"><span data-stu-id="22f12-148">As of May 1, 2013, AuthZ does not supply a default claim when missing.</span></span>| 
  
<a id="ID4E4C"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="22f12-149">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="22f12-149">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="22f12-150">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="22f12-150">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="22f12-151">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="22f12-151">Requesting User</span></span>| <span data-ttu-id="22f12-152">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="22f12-152">Target User's Privacy Setting</span></span>| <span data-ttu-id="22f12-153">動作</span><span class="sxs-lookup"><span data-stu-id="22f12-153">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="22f12-154">me</span><span class="sxs-lookup"><span data-stu-id="22f12-154">me</span></span>| -| <span data-ttu-id="22f12-155">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="22f12-155">As described.</span></span>| 
| <span data-ttu-id="22f12-156">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="22f12-156">friend</span></span>| <span data-ttu-id="22f12-157">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="22f12-157">everyone</span></span>| <span data-ttu-id="22f12-158">OK</span><span class="sxs-lookup"><span data-stu-id="22f12-158">OK</span></span>| 
| <span data-ttu-id="22f12-159">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="22f12-159">friend</span></span>| <span data-ttu-id="22f12-160">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="22f12-160">friends only</span></span>| <span data-ttu-id="22f12-161">OK</span><span class="sxs-lookup"><span data-stu-id="22f12-161">OK</span></span>| 
| <span data-ttu-id="22f12-162">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="22f12-162">friend</span></span>| <span data-ttu-id="22f12-163">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="22f12-163">blocked</span></span>| <span data-ttu-id="22f12-164">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="22f12-164">Forbidden.</span></span>| 
| <span data-ttu-id="22f12-165">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="22f12-165">non-friend user</span></span>| <span data-ttu-id="22f12-166">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="22f12-166">everyone</span></span>| <span data-ttu-id="22f12-167">OK</span><span class="sxs-lookup"><span data-stu-id="22f12-167">OK</span></span>| 
| <span data-ttu-id="22f12-168">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="22f12-168">non-friend user</span></span>| <span data-ttu-id="22f12-169">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="22f12-169">friends only</span></span>| <span data-ttu-id="22f12-170">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="22f12-170">Forbidden.</span></span>| 
| <span data-ttu-id="22f12-171">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="22f12-171">non-friend user</span></span>| <span data-ttu-id="22f12-172">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="22f12-172">blocked</span></span>| <span data-ttu-id="22f12-173">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="22f12-173">Forbidden.</span></span>| 
| <span data-ttu-id="22f12-174">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="22f12-174">third-party site</span></span>| <span data-ttu-id="22f12-175">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="22f12-175">everyone</span></span>| <span data-ttu-id="22f12-176">OK</span><span class="sxs-lookup"><span data-stu-id="22f12-176">OK</span></span>| 
| <span data-ttu-id="22f12-177">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="22f12-177">third-party site</span></span>| <span data-ttu-id="22f12-178">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="22f12-178">friends only</span></span>| <span data-ttu-id="22f12-179">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="22f12-179">Forbidden.</span></span>| 
| <span data-ttu-id="22f12-180">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="22f12-180">third-party site</span></span>| <span data-ttu-id="22f12-181">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="22f12-181">blocked</span></span>| <span data-ttu-id="22f12-182">禁止されています。</span><span class="sxs-lookup"><span data-stu-id="22f12-182">Forbidden.</span></span>| 
  
<a id="ID4EPG"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="22f12-183">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="22f12-183">Required Request Headers</span></span>
 
| <span data-ttu-id="22f12-184">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="22f12-184">Header</span></span>| <span data-ttu-id="22f12-185">型</span><span class="sxs-lookup"><span data-stu-id="22f12-185">Type</span></span>| <span data-ttu-id="22f12-186">説明</span><span class="sxs-lookup"><span data-stu-id="22f12-186">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="22f12-187">Authorization</span><span class="sxs-lookup"><span data-stu-id="22f12-187">Authorization</span></span>| <span data-ttu-id="22f12-188">string</span><span class="sxs-lookup"><span data-stu-id="22f12-188">string</span></span>| <span data-ttu-id="22f12-189">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="22f12-189">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="22f12-190">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。</span><span class="sxs-lookup"><span data-stu-id="22f12-190">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
  
<a id="ID4EPH"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="22f12-191">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="22f12-191">Optional Request Headers</span></span>
 
| <span data-ttu-id="22f12-192">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="22f12-192">Header</span></span>| <span data-ttu-id="22f12-193">型</span><span class="sxs-lookup"><span data-stu-id="22f12-193">Type</span></span>| <span data-ttu-id="22f12-194">説明</span><span class="sxs-lookup"><span data-stu-id="22f12-194">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="22f12-195">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="22f12-195">X-RequestedServiceVersion</span></span>| <span data-ttu-id="22f12-196">string</span><span class="sxs-lookup"><span data-stu-id="22f12-196">string</span></span>| <span data-ttu-id="22f12-197">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="22f12-197">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="22f12-198">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="22f12-198">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="22f12-199">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="22f12-199">Default value: 1.</span></span>| 
| <span data-ttu-id="22f12-200">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="22f12-200">x-xbl-contract-version</span></span>| <span data-ttu-id="22f12-201">string</span><span class="sxs-lookup"><span data-stu-id="22f12-201">string</span></span>| <span data-ttu-id="22f12-202">V1 既定値です。</span><span class="sxs-lookup"><span data-stu-id="22f12-202">Defaults to V1.</span></span>| 
| <span data-ttu-id="22f12-203">同意言語</span><span class="sxs-lookup"><span data-stu-id="22f12-203">Accept-Language</span></span>| <span data-ttu-id="22f12-204">string</span><span class="sxs-lookup"><span data-stu-id="22f12-204">string</span></span>| <span data-ttu-id="22f12-205">目的のロケールとフォールバック (FR-FR, fr, EN-GB、en 世界、EN-US など) の一覧です。</span><span class="sxs-lookup"><span data-stu-id="22f12-205">List of desired locales and fallbacks (e.g., fr-FR, fr, en-GB, en-WW, en-US).</span></span> <span data-ttu-id="22f12-206">ローカライズされた文字列の一致が見つかるまで、実績サービスは、一覧で動作します。</span><span class="sxs-lookup"><span data-stu-id="22f12-206">The Achievements service will work through the list until it finds matching localized strings.</span></span> <span data-ttu-id="22f12-207">見つからない場合は、ユーザーの IP アドレスに由来するユーザーのトークンで定義されている場所と一致しようとします。</span><span class="sxs-lookup"><span data-stu-id="22f12-207">If none are found, it attempts to match the location defined in the user token, which comes from the user's IP address.</span></span> <span data-ttu-id="22f12-208">一致しないローカライズされた文字列でもが見つかった場合、タイトル開発者/発行元によって提供される既定の文字列を使用します。</span><span class="sxs-lookup"><span data-stu-id="22f12-208">If still no matching localized strings are found, it uses the default strings provided by the title developer/publisher.</span></span> | 
  
<a id="ID4ECBAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="22f12-209">要求本文</span><span class="sxs-lookup"><span data-stu-id="22f12-209">Request body</span></span>
 
<span data-ttu-id="22f12-210">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="22f12-210">No objects are sent in the body of this request.</span></span>
  
<a id="ID4ENBAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="22f12-211">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="22f12-211">HTTP status codes</span></span>
 
<span data-ttu-id="22f12-212">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="22f12-212">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="22f12-213">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="22f12-213">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="22f12-214">コード</span><span class="sxs-lookup"><span data-stu-id="22f12-214">Code</span></span>| <span data-ttu-id="22f12-215">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="22f12-215">Reason phrase</span></span>| <span data-ttu-id="22f12-216">説明</span><span class="sxs-lookup"><span data-stu-id="22f12-216">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="22f12-217">200</span><span class="sxs-lookup"><span data-stu-id="22f12-217">200</span></span>| <span data-ttu-id="22f12-218">OK</span><span class="sxs-lookup"><span data-stu-id="22f12-218">OK</span></span>| <span data-ttu-id="22f12-219">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="22f12-219">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="22f12-220">301</span><span class="sxs-lookup"><span data-stu-id="22f12-220">301</span></span>| <span data-ttu-id="22f12-221">完全に移動</span><span class="sxs-lookup"><span data-stu-id="22f12-221">Moved Permanently</span></span>| <span data-ttu-id="22f12-222">サービスは、さまざまな URI に移動しました。</span><span class="sxs-lookup"><span data-stu-id="22f12-222">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="22f12-223">307</span><span class="sxs-lookup"><span data-stu-id="22f12-223">307</span></span>| <span data-ttu-id="22f12-224">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="22f12-224">Temporary Redirect</span></span>| <span data-ttu-id="22f12-225">このリソースの URI が一時的に変更されました。</span><span class="sxs-lookup"><span data-stu-id="22f12-225">The URI for this resource has temporarily changed.</span></span>| 
| <span data-ttu-id="22f12-226">400</span><span class="sxs-lookup"><span data-stu-id="22f12-226">400</span></span>| <span data-ttu-id="22f12-227">Bad Request</span><span class="sxs-lookup"><span data-stu-id="22f12-227">Bad Request</span></span>| <span data-ttu-id="22f12-228">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="22f12-228">Service could not understand malformed request.</span></span> <span data-ttu-id="22f12-229">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="22f12-229">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="22f12-230">401</span><span class="sxs-lookup"><span data-stu-id="22f12-230">401</span></span>| <span data-ttu-id="22f12-231">権限がありません</span><span class="sxs-lookup"><span data-stu-id="22f12-231">Unauthorized</span></span>| <span data-ttu-id="22f12-232">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="22f12-232">The request requires user authentication.</span></span>| 
| <span data-ttu-id="22f12-233">403</span><span class="sxs-lookup"><span data-stu-id="22f12-233">403</span></span>| <span data-ttu-id="22f12-234">Forbidden</span><span class="sxs-lookup"><span data-stu-id="22f12-234">Forbidden</span></span>| <span data-ttu-id="22f12-235">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="22f12-235">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="22f12-236">404</span><span class="sxs-lookup"><span data-stu-id="22f12-236">404</span></span>| <span data-ttu-id="22f12-237">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="22f12-237">Not Found</span></span>| <span data-ttu-id="22f12-238">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="22f12-238">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="22f12-239">406</span><span class="sxs-lookup"><span data-stu-id="22f12-239">406</span></span>| <span data-ttu-id="22f12-240">許容できません。</span><span class="sxs-lookup"><span data-stu-id="22f12-240">Not Acceptable</span></span>| <span data-ttu-id="22f12-241">リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。</span><span class="sxs-lookup"><span data-stu-id="22f12-241">Resource version is not supported; should be rejected by the MVC layer.</span></span>| 
| <span data-ttu-id="22f12-242">408</span><span class="sxs-lookup"><span data-stu-id="22f12-242">408</span></span>| <span data-ttu-id="22f12-243">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="22f12-243">Request Timeout</span></span>| <span data-ttu-id="22f12-244">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="22f12-244">The request took too long to complete.</span></span>| 
| <span data-ttu-id="22f12-245">410</span><span class="sxs-lookup"><span data-stu-id="22f12-245">410</span></span>| <span data-ttu-id="22f12-246">なった</span><span class="sxs-lookup"><span data-stu-id="22f12-246">Gone</span></span>| <span data-ttu-id="22f12-247">要求されたリソースが利用可能ではなくなりました。</span><span class="sxs-lookup"><span data-stu-id="22f12-247">The requested resource is no longer available.</span></span>| 
  
<a id="ID4EBGAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="22f12-248">応答本文</span><span class="sxs-lookup"><span data-stu-id="22f12-248">Response body</span></span>
 
<a id="ID4EHGAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="22f12-249">応答の例</span><span class="sxs-lookup"><span data-stu-id="22f12-249">Sample response</span></span>
 

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
                "url":"http://www.xbox.com"
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

 
## <a name="see-also"></a><span data-ttu-id="22f12-250">関連項目</span><span class="sxs-lookup"><span data-stu-id="22f12-250">See also</span></span>
 
<a id="ID4ETGAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="22f12-251">Parent</span><span class="sxs-lookup"><span data-stu-id="22f12-251">Parent</span></span> 

[<span data-ttu-id="22f12-252">ユーザー/xuid ({xuid})/achievements/{scid}/{achievementid}</span><span class="sxs-lookup"><span data-stu-id="22f12-252">/users/xuid({xuid})/achievements/{scid}/{achievementid}</span></span>](uri-usersxuidachievementsscidachievementid.md)

   