---
title: POST (/users/batch)
assetID: bd0b18fe-8a6d-d591-5b13-bcd9643e945a
permalink: en-us/docs/xboxlive/rest/uri-usersbatchpost.html
description: " POST (/users/batch)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 47376338a1c515aa00a7e0247df4cc16ee0db8d2
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8351718"
---
# <a name="post-usersbatch"></a><span data-ttu-id="2d428-104">POST (/users/batch)</span><span class="sxs-lookup"><span data-stu-id="2d428-104">POST (/users/batch)</span></span>
<span data-ttu-id="2d428-105">ユーザーのバッチのプレゼンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="2d428-105">Get presence for a batch of users.</span></span>
<span data-ttu-id="2d428-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2d428-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>

  * [<span data-ttu-id="2d428-107">注釈</span><span class="sxs-lookup"><span data-stu-id="2d428-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="2d428-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="2d428-108">Authorization</span></span>](#ID4EAB)
  * [<span data-ttu-id="2d428-109">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="2d428-109">Effect of privacy settings on resource</span></span>](#ID4EDC)
  * [<span data-ttu-id="2d428-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d428-110">Required Request Headers</span></span>](#ID4EYF)
  * [<span data-ttu-id="2d428-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d428-111">Optional Request Headers</span></span>](#ID4EGAAC)
  * [<span data-ttu-id="2d428-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="2d428-112">Request body</span></span>](#ID4EGBAC)
  * [<span data-ttu-id="2d428-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="2d428-113">Response body</span></span>](#ID4ESEAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="2d428-114">注釈</span><span class="sxs-lookup"><span data-stu-id="2d428-114">Remarks</span></span>

<span data-ttu-id="2d428-115">このメソッドは、任意クライアント、サービス、またはユーザーのバッチのプレゼンス情報についてはしようとしているタイトルで使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d428-115">This method should be used by any client, service, or title wanting to learn presence information for a batch of users.</span></span>

<span data-ttu-id="2d428-116">このバッチ要求の応答を深度とパスによってフィルターができます。</span><span class="sxs-lookup"><span data-stu-id="2d428-116">The responses for this batch request can be filters by depth and path.</span></span> <span data-ttu-id="2d428-117">消費者は、これを使用について説明し、一連のユーザーのプレゼンスを表示できます。</span><span class="sxs-lookup"><span data-stu-id="2d428-117">Consumers can use this to find out and display the presence about a set of users.</span></span> <span data-ttu-id="2d428-118">この API のフィルターでは、プロパティの間では、プロパティで And で Or として動作します。</span><span class="sxs-lookup"><span data-stu-id="2d428-118">The filters on this API work as ORs in a property, but ANDs across properties.</span></span>

<a id="ID4EAB"></a>


## <a name="authorization"></a><span data-ttu-id="2d428-119">Authorization</span><span class="sxs-lookup"><span data-stu-id="2d428-119">Authorization</span></span>

| <span data-ttu-id="2d428-120">型</span><span class="sxs-lookup"><span data-stu-id="2d428-120">Type</span></span>| <span data-ttu-id="2d428-121">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2d428-121">Required</span></span>| <span data-ttu-id="2d428-122">説明</span><span class="sxs-lookup"><span data-stu-id="2d428-122">Description</span></span>| <span data-ttu-id="2d428-123">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="2d428-123">Response if missing</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="2d428-124">XUID</span><span class="sxs-lookup"><span data-stu-id="2d428-124">XUID</span></span>| <span data-ttu-id="2d428-125">はい</span><span class="sxs-lookup"><span data-stu-id="2d428-125">Yes</span></span>| <span data-ttu-id="2d428-126">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="2d428-126">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="2d428-127">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="2d428-127">403 Forbidden</span></span>|

<a id="ID4EDC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="2d428-128">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="2d428-128">Effect of privacy settings on resource</span></span>

<span data-ttu-id="2d428-129">このメソッドは常に、200 を返します。 がコンテンツを応答本文で返されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2d428-129">This method always returns 200 OK, but might not return content in the response body.</span></span>

| <span data-ttu-id="2d428-130">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="2d428-130">Requesting User</span></span>| <span data-ttu-id="2d428-131">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="2d428-131">Target User's Privacy Setting</span></span>| <span data-ttu-id="2d428-132">動作</span><span class="sxs-lookup"><span data-stu-id="2d428-132">Behavior</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2d428-133">me</span><span class="sxs-lookup"><span data-stu-id="2d428-133">me</span></span>| -| <span data-ttu-id="2d428-134">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-134">200 OK</span></span>|
| <span data-ttu-id="2d428-135">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="2d428-135">friend</span></span>| <span data-ttu-id="2d428-136">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="2d428-136">everyone</span></span>| <span data-ttu-id="2d428-137">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-137">200 OK</span></span>|
| <span data-ttu-id="2d428-138">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="2d428-138">friend</span></span>| <span data-ttu-id="2d428-139">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="2d428-139">friends only</span></span>| <span data-ttu-id="2d428-140">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-140">200 OK</span></span>|
| <span data-ttu-id="2d428-141">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="2d428-141">friend</span></span>| <span data-ttu-id="2d428-142">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="2d428-142">blocked</span></span>| <span data-ttu-id="2d428-143">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-143">200 OK</span></span>|
| <span data-ttu-id="2d428-144">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="2d428-144">non-friend user</span></span>| <span data-ttu-id="2d428-145">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="2d428-145">everyone</span></span>| <span data-ttu-id="2d428-146">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-146">200 OK</span></span>|
| <span data-ttu-id="2d428-147">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="2d428-147">non-friend user</span></span>| <span data-ttu-id="2d428-148">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="2d428-148">friends only</span></span>| <span data-ttu-id="2d428-149">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-149">200 OK</span></span>|
| <span data-ttu-id="2d428-150">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="2d428-150">non-friend user</span></span>| <span data-ttu-id="2d428-151">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="2d428-151">blocked</span></span>| <span data-ttu-id="2d428-152">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-152">200 OK</span></span>|
| <span data-ttu-id="2d428-153">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="2d428-153">third-party site</span></span>| <span data-ttu-id="2d428-154">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="2d428-154">everyone</span></span>| <span data-ttu-id="2d428-155">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-155">200 OK</span></span>|
| <span data-ttu-id="2d428-156">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="2d428-156">third-party site</span></span>| <span data-ttu-id="2d428-157">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="2d428-157">friends only</span></span>| <span data-ttu-id="2d428-158">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-158">200 OK</span></span>|
| <span data-ttu-id="2d428-159">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="2d428-159">third-party site</span></span>| <span data-ttu-id="2d428-160">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="2d428-160">blocked</span></span>| <span data-ttu-id="2d428-161">200 OK</span><span class="sxs-lookup"><span data-stu-id="2d428-161">200 OK</span></span>|

<a id="ID4EYF"></a>


## <a name="required-request-headers"></a><span data-ttu-id="2d428-162">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d428-162">Required Request Headers</span></span>

| <span data-ttu-id="2d428-163">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d428-163">Header</span></span>| <span data-ttu-id="2d428-164">型</span><span class="sxs-lookup"><span data-stu-id="2d428-164">Type</span></span>| <span data-ttu-id="2d428-165">説明</span><span class="sxs-lookup"><span data-stu-id="2d428-165">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2d428-166">Authorization</span><span class="sxs-lookup"><span data-stu-id="2d428-166">Authorization</span></span>| <span data-ttu-id="2d428-167">string</span><span class="sxs-lookup"><span data-stu-id="2d428-167">string</span></span>| <span data-ttu-id="2d428-168">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="2d428-168">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="2d428-169">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="2d428-169">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="2d428-170">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="2d428-170">x-xbl-contract-version</span></span>| <span data-ttu-id="2d428-171">string</span><span class="sxs-lookup"><span data-stu-id="2d428-171">string</span></span>| <span data-ttu-id="2d428-172">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="2d428-172">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="2d428-173">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="2d428-173">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="2d428-174">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="2d428-174">Example values: 3, vnext.</span></span>|
| <span data-ttu-id="2d428-175">Accept</span><span class="sxs-lookup"><span data-stu-id="2d428-175">Accept</span></span>| <span data-ttu-id="2d428-176">string</span><span class="sxs-lookup"><span data-stu-id="2d428-176">string</span></span>| <span data-ttu-id="2d428-177">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="2d428-177">Content-Types that are acceptable.</span></span> <span data-ttu-id="2d428-178">プレゼンスでサポートされている 1 つのみがアプリケーション/json がヘッダーで指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d428-178">The only one supported by Presence is application/json, but it must be specified in the header.</span></span>|
| <span data-ttu-id="2d428-179">同意言語</span><span class="sxs-lookup"><span data-stu-id="2d428-179">Accept-Language</span></span>| <span data-ttu-id="2d428-180">string</span><span class="sxs-lookup"><span data-stu-id="2d428-180">string</span></span>| <span data-ttu-id="2d428-181">応答で文字列を許容できるロケールです。</span><span class="sxs-lookup"><span data-stu-id="2d428-181">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="2d428-182">値の例: EN-US にします。</span><span class="sxs-lookup"><span data-stu-id="2d428-182">Example values: en-US.</span></span>|
| <span data-ttu-id="2d428-183">Host</span><span class="sxs-lookup"><span data-stu-id="2d428-183">Host</span></span>| <span data-ttu-id="2d428-184">string</span><span class="sxs-lookup"><span data-stu-id="2d428-184">string</span></span>| <span data-ttu-id="2d428-185">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="2d428-185">Domain name of the server.</span></span> <span data-ttu-id="2d428-186">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="2d428-186">Example value: presencebeta.xboxlive.com.</span></span>|
| <span data-ttu-id="2d428-187">Content-Length</span><span class="sxs-lookup"><span data-stu-id="2d428-187">Content-Length</span></span>| <span data-ttu-id="2d428-188">string</span><span class="sxs-lookup"><span data-stu-id="2d428-188">string</span></span>| <span data-ttu-id="2d428-189">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="2d428-189">The length of the request body.</span></span> <span data-ttu-id="2d428-190">値の例: 312 します。</span><span class="sxs-lookup"><span data-stu-id="2d428-190">Example value: 312.</span></span>|

<a id="ID4EGAAC"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="2d428-191">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d428-191">Optional Request Headers</span></span>

| <span data-ttu-id="2d428-192">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d428-192">Header</span></span>| <span data-ttu-id="2d428-193">型</span><span class="sxs-lookup"><span data-stu-id="2d428-193">Type</span></span>| <span data-ttu-id="2d428-194">説明</span><span class="sxs-lookup"><span data-stu-id="2d428-194">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2d428-195">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="2d428-195">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="2d428-196">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="2d428-196">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="2d428-197">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="2d428-197">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="2d428-198">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="2d428-198">Default value: 1.</span></span>|

<a id="ID4EGBAC"></a>


## <a name="request-body"></a><span data-ttu-id="2d428-199">要求本文</span><span class="sxs-lookup"><span data-stu-id="2d428-199">Request body</span></span>

<a id="ID4EMBAC"></a>


### <a name="required-members"></a><span data-ttu-id="2d428-200">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="2d428-200">Required members</span></span>

| <span data-ttu-id="2d428-201">メンバー</span><span class="sxs-lookup"><span data-stu-id="2d428-201">Member</span></span>| <span data-ttu-id="2d428-202">説明</span><span class="sxs-lookup"><span data-stu-id="2d428-202">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2d428-203">ユーザー</span><span class="sxs-lookup"><span data-stu-id="2d428-203">users</span></span>| <span data-ttu-id="2d428-204">については、一度に 1100 Xuid、最大プレゼンスがユーザーの Xuid をリストします。</span><span class="sxs-lookup"><span data-stu-id="2d428-204">List XUIDs of users whose presence you want to learn, with a maximum of 1100 XUIDs at a time.</span></span>|

<a id="ID4EHCAC"></a>


### <a name="optional-members"></a><span data-ttu-id="2d428-205">省略可能なメンバー</span><span class="sxs-lookup"><span data-stu-id="2d428-205">Optional members</span></span>

| <span data-ttu-id="2d428-206">メンバー</span><span class="sxs-lookup"><span data-stu-id="2d428-206">Member</span></span>| <span data-ttu-id="2d428-207">説明</span><span class="sxs-lookup"><span data-stu-id="2d428-207">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2d428-208">deviceTypes</span><span class="sxs-lookup"><span data-stu-id="2d428-208">deviceTypes</span></span>| <span data-ttu-id="2d428-209">について知りたいユーザーに使用されるデバイスの種類の一覧です。</span><span class="sxs-lookup"><span data-stu-id="2d428-209">List of device types used by the users you want to know about.</span></span> <span data-ttu-id="2d428-210">空の配列の場合、既定値はすべて可能なデバイスの種類 (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="2d428-210">If the array is left empty, it defaults to all possible device types (that is, none are filtered out).</span></span>|
| <span data-ttu-id="2d428-211">タイトル</span><span class="sxs-lookup"><span data-stu-id="2d428-211">titles</span></span>| <span data-ttu-id="2d428-212">デバイスの一覧について理解していることをユーザーを種類します。</span><span class="sxs-lookup"><span data-stu-id="2d428-212">List of device types whose users you want to know about.</span></span> <span data-ttu-id="2d428-213">空の配列の場合、既定値はすべての可能なタイトル (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="2d428-213">If the array is left empty, it defaults to all possible titles (that is, none are filtered out).</span></span>|
| <span data-ttu-id="2d428-214">level</span><span class="sxs-lookup"><span data-stu-id="2d428-214">level</span></span>| <span data-ttu-id="2d428-215">設定可能な値:</span><span class="sxs-lookup"><span data-stu-id="2d428-215">Possible values:</span></span> <ul><li><span data-ttu-id="2d428-216">ユーザーのユーザーのノードを入手します。</span><span class="sxs-lookup"><span data-stu-id="2d428-216">user - get user nodes</span></span></li><li><span data-ttu-id="2d428-217">デバイスで入手するユーザーとデバイス ノード</span><span class="sxs-lookup"><span data-stu-id="2d428-217">device - get user and device nodes</span></span></li><li><span data-ttu-id="2d428-218">タイトルのタイトルの基本的なレベルの情報の取得</span><span class="sxs-lookup"><span data-stu-id="2d428-218">title - get basic title level information</span></span></li><li><span data-ttu-id="2d428-219">リッチ プレゼンス情報やメディアについては、すべてを取得します。</span><span class="sxs-lookup"><span data-stu-id="2d428-219">all - get rich presence information, media information, or both</span></span></li></ul><br> <span data-ttu-id="2d428-220">既定値は、「タイトル」です。</span><span class="sxs-lookup"><span data-stu-id="2d428-220">The default is "title".</span></span>|
| <span data-ttu-id="2d428-221">ガジェットの onlineOnly</span><span class="sxs-lookup"><span data-stu-id="2d428-221">onlineOnly</span></span>| <span data-ttu-id="2d428-222">このプロパティが true の場合、バッチ操作がオフライン ユーザー (回答が決まるものも含む) のレコードを絞り込まれます。</span><span class="sxs-lookup"><span data-stu-id="2d428-222">If this property is true, the batch operation will filter out records for offline users (including cloaked ones).</span></span> <span data-ttu-id="2d428-223">指定されていない場合は、オンラインとオフライン両方のユーザーが返されます。</span><span class="sxs-lookup"><span data-stu-id="2d428-223">If it is not supplied, both online and offline users will be returned.</span></span>|

<a id="ID4E4DAC"></a>


### <a name="prohibited-members"></a><span data-ttu-id="2d428-224">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="2d428-224">Prohibited members</span></span>

<span data-ttu-id="2d428-225">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="2d428-225">All other members are prohibited in a request.</span></span>

<a id="ID4EIEAC"></a>


### <a name="sample-request"></a><span data-ttu-id="2d428-226">要求の例</span><span class="sxs-lookup"><span data-stu-id="2d428-226">Sample request</span></span>


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


## <a name="response-body"></a><span data-ttu-id="2d428-227">応答本文</span><span class="sxs-lookup"><span data-stu-id="2d428-227">Response body</span></span>

<a id="ID4E1EAC"></a>


### <a name="sample-response"></a><span data-ttu-id="2d428-228">応答の例</span><span class="sxs-lookup"><span data-stu-id="2d428-228">Sample response</span></span>

<span data-ttu-id="2d428-229">このメソッドは、 [PresenceRecord](../../json/json-presencerecord.md)を返します。</span><span class="sxs-lookup"><span data-stu-id="2d428-229">This method returns a [PresenceRecord](../../json/json-presencerecord.md).</span></span>


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


## <a name="see-also"></a><span data-ttu-id="2d428-230">関連項目</span><span class="sxs-lookup"><span data-stu-id="2d428-230">See also</span></span>

<a id="ID4EMFAC"></a>


##### <a name="parent"></a><span data-ttu-id="2d428-231">Parent</span><span class="sxs-lookup"><span data-stu-id="2d428-231">Parent</span></span>

[<span data-ttu-id="2d428-232">/users/batch</span><span class="sxs-lookup"><span data-stu-id="2d428-232">/users/batch</span></span>](uri-usersbatch.md)
