---
title: POST (ユーザー/バッチ)
assetID: bd0b18fe-8a6d-d591-5b13-bcd9643e945a
permalink: en-us/docs/xboxlive/rest/uri-usersbatchpost.html
author: KevinAsgari
description: " POST (ユーザー/バッチ)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4dd1b1859de81724a97fa40d9acdc3a1847d9421
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882382"
---
# <a name="post-usersbatch"></a><span data-ttu-id="c7095-104">POST (ユーザー/バッチ)</span><span class="sxs-lookup"><span data-stu-id="c7095-104">POST (/users/batch)</span></span>
<span data-ttu-id="c7095-105">ユーザーのバッチのプレゼンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="c7095-105">Get presence for a batch of users.</span></span>
<span data-ttu-id="c7095-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c7095-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>

  * [<span data-ttu-id="c7095-107">注釈</span><span class="sxs-lookup"><span data-stu-id="c7095-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="c7095-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="c7095-108">Authorization</span></span>](#ID4EAB)
  * [<span data-ttu-id="c7095-109">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="c7095-109">Effect of privacy settings on resource</span></span>](#ID4EDC)
  * [<span data-ttu-id="c7095-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c7095-110">Required Request Headers</span></span>](#ID4EYF)
  * [<span data-ttu-id="c7095-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c7095-111">Optional Request Headers</span></span>](#ID4EGAAC)
  * [<span data-ttu-id="c7095-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="c7095-112">Request body</span></span>](#ID4EGBAC)
  * [<span data-ttu-id="c7095-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="c7095-113">Response body</span></span>](#ID4ESEAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="c7095-114">注釈</span><span class="sxs-lookup"><span data-stu-id="c7095-114">Remarks</span></span>

<span data-ttu-id="c7095-115">このメソッドは、すべてのクライアント、サービス、またはユーザーのバッチのプレゼンス情報を確認することを予定しているタイトルで使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7095-115">This method should be used by any client, service, or title wanting to learn presence information for a batch of users.</span></span>

<span data-ttu-id="c7095-116">このバッチ要求の応答を深度とパスによってフィルターができます。</span><span class="sxs-lookup"><span data-stu-id="c7095-116">The responses for this batch request can be filters by depth and path.</span></span> <span data-ttu-id="c7095-117">消費者は、これを使ってを調べ、一連のユーザーのプレゼンスを表示できます。</span><span class="sxs-lookup"><span data-stu-id="c7095-117">Consumers can use this to find out and display the presence about a set of users.</span></span> <span data-ttu-id="c7095-118">この API で、フィルターでは、プロパティでは、プロパティで And で Or として動作します。</span><span class="sxs-lookup"><span data-stu-id="c7095-118">The filters on this API work as ORs in a property, but ANDs across properties.</span></span>

<a id="ID4EAB"></a>


## <a name="authorization"></a><span data-ttu-id="c7095-119">Authorization</span><span class="sxs-lookup"><span data-stu-id="c7095-119">Authorization</span></span>

| <span data-ttu-id="c7095-120">型</span><span class="sxs-lookup"><span data-stu-id="c7095-120">Type</span></span>| <span data-ttu-id="c7095-121">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="c7095-121">Required</span></span>| <span data-ttu-id="c7095-122">説明</span><span class="sxs-lookup"><span data-stu-id="c7095-122">Description</span></span>| <span data-ttu-id="c7095-123">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="c7095-123">Response if missing</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="c7095-124">XUID</span><span class="sxs-lookup"><span data-stu-id="c7095-124">XUID</span></span>| <span data-ttu-id="c7095-125">はい</span><span class="sxs-lookup"><span data-stu-id="c7095-125">Yes</span></span>| <span data-ttu-id="c7095-126">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="c7095-126">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="c7095-127">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="c7095-127">403 Forbidden</span></span>|

<a id="ID4EDC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="c7095-128">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="c7095-128">Effect of privacy settings on resource</span></span>

<span data-ttu-id="c7095-129">以下のメソッドは常に 200 を返します。 OK が応答本文でコンテンツが返されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c7095-129">This method always returns 200 OK, but might not return content in the response body.</span></span>

| <span data-ttu-id="c7095-130">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="c7095-130">Requesting User</span></span>| <span data-ttu-id="c7095-131">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="c7095-131">Target User's Privacy Setting</span></span>| <span data-ttu-id="c7095-132">動作</span><span class="sxs-lookup"><span data-stu-id="c7095-132">Behavior</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c7095-133">me</span><span class="sxs-lookup"><span data-stu-id="c7095-133">me</span></span>| -| <span data-ttu-id="c7095-134">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-134">200 OK</span></span>|
| <span data-ttu-id="c7095-135">フレンド</span><span class="sxs-lookup"><span data-stu-id="c7095-135">friend</span></span>| <span data-ttu-id="c7095-136">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="c7095-136">everyone</span></span>| <span data-ttu-id="c7095-137">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-137">200 OK</span></span>|
| <span data-ttu-id="c7095-138">フレンド</span><span class="sxs-lookup"><span data-stu-id="c7095-138">friend</span></span>| <span data-ttu-id="c7095-139">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="c7095-139">friends only</span></span>| <span data-ttu-id="c7095-140">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-140">200 OK</span></span>|
| <span data-ttu-id="c7095-141">フレンド</span><span class="sxs-lookup"><span data-stu-id="c7095-141">friend</span></span>| <span data-ttu-id="c7095-142">ブロック</span><span class="sxs-lookup"><span data-stu-id="c7095-142">blocked</span></span>| <span data-ttu-id="c7095-143">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-143">200 OK</span></span>|
| <span data-ttu-id="c7095-144">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="c7095-144">non-friend user</span></span>| <span data-ttu-id="c7095-145">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="c7095-145">everyone</span></span>| <span data-ttu-id="c7095-146">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-146">200 OK</span></span>|
| <span data-ttu-id="c7095-147">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="c7095-147">non-friend user</span></span>| <span data-ttu-id="c7095-148">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="c7095-148">friends only</span></span>| <span data-ttu-id="c7095-149">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-149">200 OK</span></span>|
| <span data-ttu-id="c7095-150">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="c7095-150">non-friend user</span></span>| <span data-ttu-id="c7095-151">ブロック</span><span class="sxs-lookup"><span data-stu-id="c7095-151">blocked</span></span>| <span data-ttu-id="c7095-152">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-152">200 OK</span></span>|
| <span data-ttu-id="c7095-153">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="c7095-153">third-party site</span></span>| <span data-ttu-id="c7095-154">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="c7095-154">everyone</span></span>| <span data-ttu-id="c7095-155">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-155">200 OK</span></span>|
| <span data-ttu-id="c7095-156">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="c7095-156">third-party site</span></span>| <span data-ttu-id="c7095-157">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="c7095-157">friends only</span></span>| <span data-ttu-id="c7095-158">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-158">200 OK</span></span>|
| <span data-ttu-id="c7095-159">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="c7095-159">third-party site</span></span>| <span data-ttu-id="c7095-160">ブロック</span><span class="sxs-lookup"><span data-stu-id="c7095-160">blocked</span></span>| <span data-ttu-id="c7095-161">200 OK</span><span class="sxs-lookup"><span data-stu-id="c7095-161">200 OK</span></span>|

<a id="ID4EYF"></a>


## <a name="required-request-headers"></a><span data-ttu-id="c7095-162">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c7095-162">Required Request Headers</span></span>

| <span data-ttu-id="c7095-163">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c7095-163">Header</span></span>| <span data-ttu-id="c7095-164">型</span><span class="sxs-lookup"><span data-stu-id="c7095-164">Type</span></span>| <span data-ttu-id="c7095-165">説明</span><span class="sxs-lookup"><span data-stu-id="c7095-165">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c7095-166">Authorization</span><span class="sxs-lookup"><span data-stu-id="c7095-166">Authorization</span></span>| <span data-ttu-id="c7095-167">string</span><span class="sxs-lookup"><span data-stu-id="c7095-167">string</span></span>| <span data-ttu-id="c7095-168">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="c7095-168">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="c7095-169">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="c7095-169">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="c7095-170">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="c7095-170">x-xbl-contract-version</span></span>| <span data-ttu-id="c7095-171">string</span><span class="sxs-lookup"><span data-stu-id="c7095-171">string</span></span>| <span data-ttu-id="c7095-172">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="c7095-172">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="c7095-173">要求はのみにルーティングすると、サービスの認証トークンを要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="c7095-173">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="c7095-174">値の例: 3、vnext します。</span><span class="sxs-lookup"><span data-stu-id="c7095-174">Example values: 3, vnext.</span></span>|
| <span data-ttu-id="c7095-175">Accept</span><span class="sxs-lookup"><span data-stu-id="c7095-175">Accept</span></span>| <span data-ttu-id="c7095-176">string</span><span class="sxs-lookup"><span data-stu-id="c7095-176">string</span></span>| <span data-ttu-id="c7095-177">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="c7095-177">Content-Types that are acceptable.</span></span> <span data-ttu-id="c7095-178">プレゼンスでサポートされている 1 つだけが/json、アプリケーションがヘッダーで指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7095-178">The only one supported by Presence is application/json, but it must be specified in the header.</span></span>|
| <span data-ttu-id="c7095-179">同意言語</span><span class="sxs-lookup"><span data-stu-id="c7095-179">Accept-Language</span></span>| <span data-ttu-id="c7095-180">string</span><span class="sxs-lookup"><span data-stu-id="c7095-180">string</span></span>| <span data-ttu-id="c7095-181">応答で文字列を許容できるロケールです。</span><span class="sxs-lookup"><span data-stu-id="c7095-181">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="c7095-182">値の例: EN-US にします。</span><span class="sxs-lookup"><span data-stu-id="c7095-182">Example values: en-US.</span></span>|
| <span data-ttu-id="c7095-183">Host</span><span class="sxs-lookup"><span data-stu-id="c7095-183">Host</span></span>| <span data-ttu-id="c7095-184">string</span><span class="sxs-lookup"><span data-stu-id="c7095-184">string</span></span>| <span data-ttu-id="c7095-185">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="c7095-185">Domain name of the server.</span></span> <span data-ttu-id="c7095-186">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="c7095-186">Example value: presencebeta.xboxlive.com.</span></span>|
| <span data-ttu-id="c7095-187">Content-Length</span><span class="sxs-lookup"><span data-stu-id="c7095-187">Content-Length</span></span>| <span data-ttu-id="c7095-188">string</span><span class="sxs-lookup"><span data-stu-id="c7095-188">string</span></span>| <span data-ttu-id="c7095-189">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="c7095-189">The length of the request body.</span></span> <span data-ttu-id="c7095-190">値の例: 312 します。</span><span class="sxs-lookup"><span data-stu-id="c7095-190">Example value: 312.</span></span>|

<a id="ID4EGAAC"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="c7095-191">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c7095-191">Optional Request Headers</span></span>

| <span data-ttu-id="c7095-192">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c7095-192">Header</span></span>| <span data-ttu-id="c7095-193">型</span><span class="sxs-lookup"><span data-stu-id="c7095-193">Type</span></span>| <span data-ttu-id="c7095-194">説明</span><span class="sxs-lookup"><span data-stu-id="c7095-194">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c7095-195">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="c7095-195">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="c7095-196">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="c7095-196">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="c7095-197">要求はのみにルーティングすると、サービスの認証トークンを要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="c7095-197">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="c7095-198">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="c7095-198">Default value: 1.</span></span>|

<a id="ID4EGBAC"></a>


## <a name="request-body"></a><span data-ttu-id="c7095-199">要求本文</span><span class="sxs-lookup"><span data-stu-id="c7095-199">Request body</span></span>

<a id="ID4EMBAC"></a>


### <a name="required-members"></a><span data-ttu-id="c7095-200">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="c7095-200">Required members</span></span>

| <span data-ttu-id="c7095-201">メンバー</span><span class="sxs-lookup"><span data-stu-id="c7095-201">Member</span></span>| <span data-ttu-id="c7095-202">説明</span><span class="sxs-lookup"><span data-stu-id="c7095-202">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c7095-203">ユーザー</span><span class="sxs-lookup"><span data-stu-id="c7095-203">users</span></span>| <span data-ttu-id="c7095-204">については、一度に 1100 Xuid の最大プレゼンスがユーザーの Xuid をリストします。</span><span class="sxs-lookup"><span data-stu-id="c7095-204">List XUIDs of users whose presence you want to learn, with a maximum of 1100 XUIDs at a time.</span></span>|

<a id="ID4EHCAC"></a>


### <a name="optional-members"></a><span data-ttu-id="c7095-205">省略可能なメンバー</span><span class="sxs-lookup"><span data-stu-id="c7095-205">Optional members</span></span>

| <span data-ttu-id="c7095-206">メンバー</span><span class="sxs-lookup"><span data-stu-id="c7095-206">Member</span></span>| <span data-ttu-id="c7095-207">説明</span><span class="sxs-lookup"><span data-stu-id="c7095-207">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c7095-208">deviceTypes</span><span class="sxs-lookup"><span data-stu-id="c7095-208">deviceTypes</span></span>| <span data-ttu-id="c7095-209">について知りたいユーザーで使用されるデバイスの種類の一覧です。</span><span class="sxs-lookup"><span data-stu-id="c7095-209">List of device types used by the users you want to know about.</span></span> <span data-ttu-id="c7095-210">空の配列の場合、既定値はすべてのデバイスの種類 (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="c7095-210">If the array is left empty, it defaults to all possible device types (that is, none are filtered out).</span></span>|
| <span data-ttu-id="c7095-211">タイトル</span><span class="sxs-lookup"><span data-stu-id="c7095-211">titles</span></span>| <span data-ttu-id="c7095-212">デバイスの一覧について理解していることをユーザーを種類します。</span><span class="sxs-lookup"><span data-stu-id="c7095-212">List of device types whose users you want to know about.</span></span> <span data-ttu-id="c7095-213">可能なすべてのタイトルに既定値の配列が空のままである場合 (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="c7095-213">If the array is left empty, it defaults to all possible titles (that is, none are filtered out).</span></span>|
| <span data-ttu-id="c7095-214">level</span><span class="sxs-lookup"><span data-stu-id="c7095-214">level</span></span>| <span data-ttu-id="c7095-215">設定可能な値:</span><span class="sxs-lookup"><span data-stu-id="c7095-215">Possible values:</span></span> <ul><li><span data-ttu-id="c7095-216">ユーザーのユーザーのノードを入手します。</span><span class="sxs-lookup"><span data-stu-id="c7095-216">user - get user nodes</span></span></li><li><span data-ttu-id="c7095-217">デバイスの get ユーザーとデバイス ノード</span><span class="sxs-lookup"><span data-stu-id="c7095-217">device - get user and device nodes</span></span></li><li><span data-ttu-id="c7095-218">タイトルのタイトルの基本的なレベルの情報の取得</span><span class="sxs-lookup"><span data-stu-id="c7095-218">title - get basic title level information</span></span></li><li><span data-ttu-id="c7095-219">リッチ プレゼンス情報やメディアは、すべてを取得します。</span><span class="sxs-lookup"><span data-stu-id="c7095-219">all - get rich presence information, media information, or both</span></span></li></ul><br> <span data-ttu-id="c7095-220">既定値は、「タイトル」です。</span><span class="sxs-lookup"><span data-stu-id="c7095-220">The default is "title".</span></span>|
| <span data-ttu-id="c7095-221">ガジェットの onlineOnly</span><span class="sxs-lookup"><span data-stu-id="c7095-221">onlineOnly</span></span>| <span data-ttu-id="c7095-222">このプロパティが true の場合、バッチ操作がオフラインのユーザーが (回答が決まるものを含む) のレコードをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="c7095-222">If this property is true, the batch operation will filter out records for offline users (including cloaked ones).</span></span> <span data-ttu-id="c7095-223">指定されていない場合は、オンラインとオフライン両方のユーザーが返されます。</span><span class="sxs-lookup"><span data-stu-id="c7095-223">If it is not supplied, both online and offline users will be returned.</span></span>|

<a id="ID4E4DAC"></a>


### <a name="prohibited-members"></a><span data-ttu-id="c7095-224">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="c7095-224">Prohibited members</span></span>

<span data-ttu-id="c7095-225">要求では、他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="c7095-225">All other members are prohibited in a request.</span></span>

<a id="ID4EIEAC"></a>


### <a name="sample-request"></a><span data-ttu-id="c7095-226">要求の例</span><span class="sxs-lookup"><span data-stu-id="c7095-226">Sample request</span></span>


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


## <a name="response-body"></a><span data-ttu-id="c7095-227">応答本文</span><span class="sxs-lookup"><span data-stu-id="c7095-227">Response body</span></span>

<a id="ID4E1EAC"></a>


### <a name="sample-response"></a><span data-ttu-id="c7095-228">応答の例</span><span class="sxs-lookup"><span data-stu-id="c7095-228">Sample response</span></span>

<span data-ttu-id="c7095-229">このメソッドは、 [presencerecord を要求して](../../json/json-presencerecord.md)を返します。</span><span class="sxs-lookup"><span data-stu-id="c7095-229">This method returns a [PresenceRecord](../../json/json-presencerecord.md).</span></span>


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


## <a name="see-also"></a><span data-ttu-id="c7095-230">関連項目</span><span class="sxs-lookup"><span data-stu-id="c7095-230">See also</span></span>

<a id="ID4EMFAC"></a>


##### <a name="parent"></a><span data-ttu-id="c7095-231">Parent</span><span class="sxs-lookup"><span data-stu-id="c7095-231">Parent</span></span>

[<span data-ttu-id="c7095-232">ユーザー/バッチ</span><span class="sxs-lookup"><span data-stu-id="c7095-232">/users/batch</span></span>](uri-usersbatch.md)
