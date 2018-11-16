---
title: POST (/users/batch)
assetID: bd0b18fe-8a6d-d591-5b13-bcd9643e945a
permalink: en-us/docs/xboxlive/rest/uri-usersbatchpost.html
author: KevinAsgari
description: " POST (/users/batch)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9187aa43d3d4ee3a76ec834ac0352b66fe59167f
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6837631"
---
# <a name="post-usersbatch"></a><span data-ttu-id="bd95e-104">POST (/users/batch)</span><span class="sxs-lookup"><span data-stu-id="bd95e-104">POST (/users/batch)</span></span>
<span data-ttu-id="bd95e-105">ユーザーのバッチのプレゼンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-105">Get presence for a batch of users.</span></span>
<span data-ttu-id="bd95e-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>

  * [<span data-ttu-id="bd95e-107">注釈</span><span class="sxs-lookup"><span data-stu-id="bd95e-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="bd95e-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="bd95e-108">Authorization</span></span>](#ID4EAB)
  * [<span data-ttu-id="bd95e-109">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="bd95e-109">Effect of privacy settings on resource</span></span>](#ID4EDC)
  * [<span data-ttu-id="bd95e-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd95e-110">Required Request Headers</span></span>](#ID4EYF)
  * [<span data-ttu-id="bd95e-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd95e-111">Optional Request Headers</span></span>](#ID4EGAAC)
  * [<span data-ttu-id="bd95e-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="bd95e-112">Request body</span></span>](#ID4EGBAC)
  * [<span data-ttu-id="bd95e-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="bd95e-113">Response body</span></span>](#ID4ESEAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="bd95e-114">注釈</span><span class="sxs-lookup"><span data-stu-id="bd95e-114">Remarks</span></span>

<span data-ttu-id="bd95e-115">このメソッドは、すべてクライアント、サービス、またはユーザーのバッチのプレゼンス情報についてはしようとしているタイトルで使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bd95e-115">This method should be used by any client, service, or title wanting to learn presence information for a batch of users.</span></span>

<span data-ttu-id="bd95e-116">このバッチ要求の応答は、深度とパスによってフィルターできます。</span><span class="sxs-lookup"><span data-stu-id="bd95e-116">The responses for this batch request can be filters by depth and path.</span></span> <span data-ttu-id="bd95e-117">消費者は、これを使用を確認し、一連のユーザーのプレゼンスを表示できます。</span><span class="sxs-lookup"><span data-stu-id="bd95e-117">Consumers can use this to find out and display the presence about a set of users.</span></span> <span data-ttu-id="bd95e-118">この API のフィルターでは、プロパティの間では、プロパティで And で Or として動作します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-118">The filters on this API work as ORs in a property, but ANDs across properties.</span></span>

<a id="ID4EAB"></a>


## <a name="authorization"></a><span data-ttu-id="bd95e-119">Authorization</span><span class="sxs-lookup"><span data-stu-id="bd95e-119">Authorization</span></span>

| <span data-ttu-id="bd95e-120">型</span><span class="sxs-lookup"><span data-stu-id="bd95e-120">Type</span></span>| <span data-ttu-id="bd95e-121">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="bd95e-121">Required</span></span>| <span data-ttu-id="bd95e-122">説明</span><span class="sxs-lookup"><span data-stu-id="bd95e-122">Description</span></span>| <span data-ttu-id="bd95e-123">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="bd95e-123">Response if missing</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="bd95e-124">XUID</span><span class="sxs-lookup"><span data-stu-id="bd95e-124">XUID</span></span>| <span data-ttu-id="bd95e-125">はい</span><span class="sxs-lookup"><span data-stu-id="bd95e-125">Yes</span></span>| <span data-ttu-id="bd95e-126">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="bd95e-126">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="bd95e-127">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="bd95e-127">403 Forbidden</span></span>|

<a id="ID4EDC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="bd95e-128">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="bd95e-128">Effect of privacy settings on resource</span></span>

<span data-ttu-id="bd95e-129">このメソッドは常に、200 を返しますがコンテンツを応答本文で返されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bd95e-129">This method always returns 200 OK, but might not return content in the response body.</span></span>

| <span data-ttu-id="bd95e-130">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="bd95e-130">Requesting User</span></span>| <span data-ttu-id="bd95e-131">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="bd95e-131">Target User's Privacy Setting</span></span>| <span data-ttu-id="bd95e-132">動作</span><span class="sxs-lookup"><span data-stu-id="bd95e-132">Behavior</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="bd95e-133">me</span><span class="sxs-lookup"><span data-stu-id="bd95e-133">me</span></span>| -| <span data-ttu-id="bd95e-134">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-134">200 OK</span></span>|
| <span data-ttu-id="bd95e-135">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="bd95e-135">friend</span></span>| <span data-ttu-id="bd95e-136">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="bd95e-136">everyone</span></span>| <span data-ttu-id="bd95e-137">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-137">200 OK</span></span>|
| <span data-ttu-id="bd95e-138">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="bd95e-138">friend</span></span>| <span data-ttu-id="bd95e-139">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="bd95e-139">friends only</span></span>| <span data-ttu-id="bd95e-140">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-140">200 OK</span></span>|
| <span data-ttu-id="bd95e-141">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="bd95e-141">friend</span></span>| <span data-ttu-id="bd95e-142">ブロック</span><span class="sxs-lookup"><span data-stu-id="bd95e-142">blocked</span></span>| <span data-ttu-id="bd95e-143">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-143">200 OK</span></span>|
| <span data-ttu-id="bd95e-144">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="bd95e-144">non-friend user</span></span>| <span data-ttu-id="bd95e-145">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="bd95e-145">everyone</span></span>| <span data-ttu-id="bd95e-146">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-146">200 OK</span></span>|
| <span data-ttu-id="bd95e-147">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="bd95e-147">non-friend user</span></span>| <span data-ttu-id="bd95e-148">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="bd95e-148">friends only</span></span>| <span data-ttu-id="bd95e-149">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-149">200 OK</span></span>|
| <span data-ttu-id="bd95e-150">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="bd95e-150">non-friend user</span></span>| <span data-ttu-id="bd95e-151">ブロック</span><span class="sxs-lookup"><span data-stu-id="bd95e-151">blocked</span></span>| <span data-ttu-id="bd95e-152">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-152">200 OK</span></span>|
| <span data-ttu-id="bd95e-153">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="bd95e-153">third-party site</span></span>| <span data-ttu-id="bd95e-154">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="bd95e-154">everyone</span></span>| <span data-ttu-id="bd95e-155">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-155">200 OK</span></span>|
| <span data-ttu-id="bd95e-156">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="bd95e-156">third-party site</span></span>| <span data-ttu-id="bd95e-157">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="bd95e-157">friends only</span></span>| <span data-ttu-id="bd95e-158">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-158">200 OK</span></span>|
| <span data-ttu-id="bd95e-159">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="bd95e-159">third-party site</span></span>| <span data-ttu-id="bd95e-160">ブロック</span><span class="sxs-lookup"><span data-stu-id="bd95e-160">blocked</span></span>| <span data-ttu-id="bd95e-161">200 OK</span><span class="sxs-lookup"><span data-stu-id="bd95e-161">200 OK</span></span>|

<a id="ID4EYF"></a>


## <a name="required-request-headers"></a><span data-ttu-id="bd95e-162">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd95e-162">Required Request Headers</span></span>

| <span data-ttu-id="bd95e-163">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd95e-163">Header</span></span>| <span data-ttu-id="bd95e-164">型</span><span class="sxs-lookup"><span data-stu-id="bd95e-164">Type</span></span>| <span data-ttu-id="bd95e-165">説明</span><span class="sxs-lookup"><span data-stu-id="bd95e-165">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="bd95e-166">Authorization</span><span class="sxs-lookup"><span data-stu-id="bd95e-166">Authorization</span></span>| <span data-ttu-id="bd95e-167">string</span><span class="sxs-lookup"><span data-stu-id="bd95e-167">string</span></span>| <span data-ttu-id="bd95e-168">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-168">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="bd95e-169">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="bd95e-169">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="bd95e-170">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="bd95e-170">x-xbl-contract-version</span></span>| <span data-ttu-id="bd95e-171">string</span><span class="sxs-lookup"><span data-stu-id="bd95e-171">string</span></span>| <span data-ttu-id="bd95e-172">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="bd95e-172">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="bd95e-173">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="bd95e-173">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="bd95e-174">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-174">Example values: 3, vnext.</span></span>|
| <span data-ttu-id="bd95e-175">Accept</span><span class="sxs-lookup"><span data-stu-id="bd95e-175">Accept</span></span>| <span data-ttu-id="bd95e-176">string</span><span class="sxs-lookup"><span data-stu-id="bd95e-176">string</span></span>| <span data-ttu-id="bd95e-177">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="bd95e-177">Content-Types that are acceptable.</span></span> <span data-ttu-id="bd95e-178">プレゼンスでサポートされている 1 つのみがアプリケーション/json がヘッダーで指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bd95e-178">The only one supported by Presence is application/json, but it must be specified in the header.</span></span>|
| <span data-ttu-id="bd95e-179">同意言語</span><span class="sxs-lookup"><span data-stu-id="bd95e-179">Accept-Language</span></span>| <span data-ttu-id="bd95e-180">string</span><span class="sxs-lookup"><span data-stu-id="bd95e-180">string</span></span>| <span data-ttu-id="bd95e-181">応答で文字列を許容できるロケールです。</span><span class="sxs-lookup"><span data-stu-id="bd95e-181">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="bd95e-182">値の例: EN-US にします。</span><span class="sxs-lookup"><span data-stu-id="bd95e-182">Example values: en-US.</span></span>|
| <span data-ttu-id="bd95e-183">Host</span><span class="sxs-lookup"><span data-stu-id="bd95e-183">Host</span></span>| <span data-ttu-id="bd95e-184">string</span><span class="sxs-lookup"><span data-stu-id="bd95e-184">string</span></span>| <span data-ttu-id="bd95e-185">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="bd95e-185">Domain name of the server.</span></span> <span data-ttu-id="bd95e-186">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-186">Example value: presencebeta.xboxlive.com.</span></span>|
| <span data-ttu-id="bd95e-187">Content-Length</span><span class="sxs-lookup"><span data-stu-id="bd95e-187">Content-Length</span></span>| <span data-ttu-id="bd95e-188">string</span><span class="sxs-lookup"><span data-stu-id="bd95e-188">string</span></span>| <span data-ttu-id="bd95e-189">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="bd95e-189">The length of the request body.</span></span> <span data-ttu-id="bd95e-190">値の例: 312 します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-190">Example value: 312.</span></span>|

<a id="ID4EGAAC"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="bd95e-191">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd95e-191">Optional Request Headers</span></span>

| <span data-ttu-id="bd95e-192">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bd95e-192">Header</span></span>| <span data-ttu-id="bd95e-193">型</span><span class="sxs-lookup"><span data-stu-id="bd95e-193">Type</span></span>| <span data-ttu-id="bd95e-194">説明</span><span class="sxs-lookup"><span data-stu-id="bd95e-194">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="bd95e-195">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="bd95e-195">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="bd95e-196">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="bd95e-196">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="bd95e-197">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="bd95e-197">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="bd95e-198">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="bd95e-198">Default value: 1.</span></span>|

<a id="ID4EGBAC"></a>


## <a name="request-body"></a><span data-ttu-id="bd95e-199">要求本文</span><span class="sxs-lookup"><span data-stu-id="bd95e-199">Request body</span></span>

<a id="ID4EMBAC"></a>


### <a name="required-members"></a><span data-ttu-id="bd95e-200">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="bd95e-200">Required members</span></span>

| <span data-ttu-id="bd95e-201">メンバー</span><span class="sxs-lookup"><span data-stu-id="bd95e-201">Member</span></span>| <span data-ttu-id="bd95e-202">説明</span><span class="sxs-lookup"><span data-stu-id="bd95e-202">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="bd95e-203">ユーザー</span><span class="sxs-lookup"><span data-stu-id="bd95e-203">users</span></span>| <span data-ttu-id="bd95e-204">については、一度に 1100 Xuid の最大プレゼンスがユーザーの Xuid をリストします。</span><span class="sxs-lookup"><span data-stu-id="bd95e-204">List XUIDs of users whose presence you want to learn, with a maximum of 1100 XUIDs at a time.</span></span>|

<a id="ID4EHCAC"></a>


### <a name="optional-members"></a><span data-ttu-id="bd95e-205">省略可能なメンバー</span><span class="sxs-lookup"><span data-stu-id="bd95e-205">Optional members</span></span>

| <span data-ttu-id="bd95e-206">メンバー</span><span class="sxs-lookup"><span data-stu-id="bd95e-206">Member</span></span>| <span data-ttu-id="bd95e-207">説明</span><span class="sxs-lookup"><span data-stu-id="bd95e-207">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="bd95e-208">deviceTypes</span><span class="sxs-lookup"><span data-stu-id="bd95e-208">deviceTypes</span></span>| <span data-ttu-id="bd95e-209">について知りたいユーザーに使用されるデバイスの種類の一覧です。</span><span class="sxs-lookup"><span data-stu-id="bd95e-209">List of device types used by the users you want to know about.</span></span> <span data-ttu-id="bd95e-210">空の配列の場合、既定値はすべての可能なデバイスの種類 (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="bd95e-210">If the array is left empty, it defaults to all possible device types (that is, none are filtered out).</span></span>|
| <span data-ttu-id="bd95e-211">タイトル</span><span class="sxs-lookup"><span data-stu-id="bd95e-211">titles</span></span>| <span data-ttu-id="bd95e-212">デバイスの一覧について理解していることをユーザーを種類します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-212">List of device types whose users you want to know about.</span></span> <span data-ttu-id="bd95e-213">空の配列の場合、既定値はすべての可能なタイトル (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="bd95e-213">If the array is left empty, it defaults to all possible titles (that is, none are filtered out).</span></span>|
| <span data-ttu-id="bd95e-214">level</span><span class="sxs-lookup"><span data-stu-id="bd95e-214">level</span></span>| <span data-ttu-id="bd95e-215">設定可能な値:</span><span class="sxs-lookup"><span data-stu-id="bd95e-215">Possible values:</span></span> <ul><li><span data-ttu-id="bd95e-216">ユーザーのユーザーのノードを入手します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-216">user - get user nodes</span></span></li><li><span data-ttu-id="bd95e-217">デバイスで入手するユーザーとデバイス ノード</span><span class="sxs-lookup"><span data-stu-id="bd95e-217">device - get user and device nodes</span></span></li><li><span data-ttu-id="bd95e-218">タイトルのタイトルの基本的なレベルの情報の取得</span><span class="sxs-lookup"><span data-stu-id="bd95e-218">title - get basic title level information</span></span></li><li><span data-ttu-id="bd95e-219">リッチ プレゼンス情報やメディアについては、すべてを取得します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-219">all - get rich presence information, media information, or both</span></span></li></ul><br> <span data-ttu-id="bd95e-220">既定値は、「タイトル」です。</span><span class="sxs-lookup"><span data-stu-id="bd95e-220">The default is "title".</span></span>|
| <span data-ttu-id="bd95e-221">ガジェットの onlineOnly</span><span class="sxs-lookup"><span data-stu-id="bd95e-221">onlineOnly</span></span>| <span data-ttu-id="bd95e-222">このプロパティが true の場合、バッチ操作がオフラインのユーザーが (回答が決まるものを含む) のレコードを絞り込まれます。</span><span class="sxs-lookup"><span data-stu-id="bd95e-222">If this property is true, the batch operation will filter out records for offline users (including cloaked ones).</span></span> <span data-ttu-id="bd95e-223">指定されていない場合は、オンラインとオフライン両方のユーザーが返されます。</span><span class="sxs-lookup"><span data-stu-id="bd95e-223">If it is not supplied, both online and offline users will be returned.</span></span>|

<a id="ID4E4DAC"></a>


### <a name="prohibited-members"></a><span data-ttu-id="bd95e-224">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="bd95e-224">Prohibited members</span></span>

<span data-ttu-id="bd95e-225">要求では、他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="bd95e-225">All other members are prohibited in a request.</span></span>

<a id="ID4EIEAC"></a>


### <a name="sample-request"></a><span data-ttu-id="bd95e-226">要求の例</span><span class="sxs-lookup"><span data-stu-id="bd95e-226">Sample request</span></span>


```cpp
{
  users:
  [
    "1234567890",
    "4567890123",
    "7890123456"
  ]
}

```


<a id="ID4ESEAC"></a>


## <a name="response-body"></a><span data-ttu-id="bd95e-227">応答本文</span><span class="sxs-lookup"><span data-stu-id="bd95e-227">Response body</span></span>

<a id="ID4E1EAC"></a>


### <a name="sample-response"></a><span data-ttu-id="bd95e-228">応答の例</span><span class="sxs-lookup"><span data-stu-id="bd95e-228">Sample response</span></span>

<span data-ttu-id="bd95e-229">このメソッドは、 [PresenceRecord](../../json/json-presencerecord.md)を返します。</span><span class="sxs-lookup"><span data-stu-id="bd95e-229">This method returns a [PresenceRecord](../../json/json-presencerecord.md).</span></span>


```cpp
{
  xuid:"0123456789",
  state:"online",
  devices:
  [{
    type:"D",
    titles:
    [{
      id:"12341234",
      name:"Contoso 5",
      state:"active",
      placement:"fill",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Team Deathmatch on Nirvana"
      }
    },
    {
      id:"12341235",
      name:"Contoso Waypoint",
      timestamp:"2012-09-17T07:15:23.4930000",
      placement:"snapped",
      state:"active",
      activity:
      {
        richPresence:"Using radar"
      }
    }]
  },
  {
    type:W8,
    titles:
    [{
      id:"23452345",
      name:"Contoso Gamehelp",
      state:"active",
      placement:"full",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Nirvana page",
      }
    }]
  }]
}

```


<a id="ID4EKFAC"></a>


## <a name="see-also"></a><span data-ttu-id="bd95e-230">関連項目</span><span class="sxs-lookup"><span data-stu-id="bd95e-230">See also</span></span>

<a id="ID4EMFAC"></a>


##### <a name="parent"></a><span data-ttu-id="bd95e-231">Parent</span><span class="sxs-lookup"><span data-stu-id="bd95e-231">Parent</span></span>

[<span data-ttu-id="bd95e-232">/users/batch</span><span class="sxs-lookup"><span data-stu-id="bd95e-232">/users/batch</span></span>](uri-usersbatch.md)
