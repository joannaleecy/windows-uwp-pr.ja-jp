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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655677"
---
# <a name="post-usersbatch"></a><span data-ttu-id="afadc-104">POST (/users/batch)</span><span class="sxs-lookup"><span data-stu-id="afadc-104">POST (/users/batch)</span></span>
<span data-ttu-id="afadc-105">ユーザーのバッチのプレゼンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="afadc-105">Get presence for a batch of users.</span></span>
<span data-ttu-id="afadc-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="afadc-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>

  * [<span data-ttu-id="afadc-107">注釈</span><span class="sxs-lookup"><span data-stu-id="afadc-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="afadc-108">承認</span><span class="sxs-lookup"><span data-stu-id="afadc-108">Authorization</span></span>](#ID4EAB)
  * [<span data-ttu-id="afadc-109">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="afadc-109">Effect of privacy settings on resource</span></span>](#ID4EDC)
  * [<span data-ttu-id="afadc-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="afadc-110">Required Request Headers</span></span>](#ID4EYF)
  * [<span data-ttu-id="afadc-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="afadc-111">Optional Request Headers</span></span>](#ID4EGAAC)
  * [<span data-ttu-id="afadc-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="afadc-112">Request body</span></span>](#ID4EGBAC)
  * [<span data-ttu-id="afadc-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="afadc-113">Response body</span></span>](#ID4ESEAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="afadc-114">注釈</span><span class="sxs-lookup"><span data-stu-id="afadc-114">Remarks</span></span>

<span data-ttu-id="afadc-115">このメソッドは、任意のクライアント、サービス、またはユーザーのバッチのプレゼンス情報を説明しようとしているタイトルを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="afadc-115">This method should be used by any client, service, or title wanting to learn presence information for a batch of users.</span></span>

<span data-ttu-id="afadc-116">このバッチ要求の応答には、深さとパスでフィルターを指定できます。</span><span class="sxs-lookup"><span data-stu-id="afadc-116">The responses for this batch request can be filters by depth and path.</span></span> <span data-ttu-id="afadc-117">コンシューマーは、これを使用を確認し、一連のユーザーのプレゼンスを表示できます。</span><span class="sxs-lookup"><span data-stu-id="afadc-117">Consumers can use this to find out and display the presence about a set of users.</span></span> <span data-ttu-id="afadc-118">この API でのフィルターでは、プロパティで、プロパティが And or 検索として機能します。</span><span class="sxs-lookup"><span data-stu-id="afadc-118">The filters on this API work as ORs in a property, but ANDs across properties.</span></span>

<a id="ID4EAB"></a>


## <a name="authorization"></a><span data-ttu-id="afadc-119">Authorization</span><span class="sxs-lookup"><span data-stu-id="afadc-119">Authorization</span></span>

| <span data-ttu-id="afadc-120">種類</span><span class="sxs-lookup"><span data-stu-id="afadc-120">Type</span></span>| <span data-ttu-id="afadc-121">必須</span><span class="sxs-lookup"><span data-stu-id="afadc-121">Required</span></span>| <span data-ttu-id="afadc-122">説明</span><span class="sxs-lookup"><span data-stu-id="afadc-122">Description</span></span>| <span data-ttu-id="afadc-123">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="afadc-123">Response if missing</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="afadc-124">XUID</span><span class="sxs-lookup"><span data-stu-id="afadc-124">XUID</span></span>| <span data-ttu-id="afadc-125">〇</span><span class="sxs-lookup"><span data-stu-id="afadc-125">Yes</span></span>| <span data-ttu-id="afadc-126">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="afadc-126">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="afadc-127">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="afadc-127">403 Forbidden</span></span>|

<a id="ID4EDC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="afadc-128">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="afadc-128">Effect of privacy settings on resource</span></span>

<span data-ttu-id="afadc-129">このメソッドは常に、200 を返しますが、応答本文のコンテンツを返さなかった可能性があります。</span><span class="sxs-lookup"><span data-stu-id="afadc-129">This method always returns 200 OK, but might not return content in the response body.</span></span>

| <span data-ttu-id="afadc-130">要求元のユーザー</span><span class="sxs-lookup"><span data-stu-id="afadc-130">Requesting User</span></span>| <span data-ttu-id="afadc-131">ターゲット ユーザーのプライバシーの設定</span><span class="sxs-lookup"><span data-stu-id="afadc-131">Target User's Privacy Setting</span></span>| <span data-ttu-id="afadc-132">動作</span><span class="sxs-lookup"><span data-stu-id="afadc-132">Behavior</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="afadc-133">Me</span><span class="sxs-lookup"><span data-stu-id="afadc-133">me</span></span>| -| <span data-ttu-id="afadc-134">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-134">200 OK</span></span>|
| <span data-ttu-id="afadc-135">friend</span><span class="sxs-lookup"><span data-stu-id="afadc-135">friend</span></span>| <span data-ttu-id="afadc-136">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="afadc-136">everyone</span></span>| <span data-ttu-id="afadc-137">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-137">200 OK</span></span>|
| <span data-ttu-id="afadc-138">friend</span><span class="sxs-lookup"><span data-stu-id="afadc-138">friend</span></span>| <span data-ttu-id="afadc-139">友達のみ</span><span class="sxs-lookup"><span data-stu-id="afadc-139">friends only</span></span>| <span data-ttu-id="afadc-140">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-140">200 OK</span></span>|
| <span data-ttu-id="afadc-141">friend</span><span class="sxs-lookup"><span data-stu-id="afadc-141">friend</span></span>| <span data-ttu-id="afadc-142">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="afadc-142">blocked</span></span>| <span data-ttu-id="afadc-143">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-143">200 OK</span></span>|
| <span data-ttu-id="afadc-144">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="afadc-144">non-friend user</span></span>| <span data-ttu-id="afadc-145">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="afadc-145">everyone</span></span>| <span data-ttu-id="afadc-146">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-146">200 OK</span></span>|
| <span data-ttu-id="afadc-147">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="afadc-147">non-friend user</span></span>| <span data-ttu-id="afadc-148">友達のみ</span><span class="sxs-lookup"><span data-stu-id="afadc-148">friends only</span></span>| <span data-ttu-id="afadc-149">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-149">200 OK</span></span>|
| <span data-ttu-id="afadc-150">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="afadc-150">non-friend user</span></span>| <span data-ttu-id="afadc-151">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="afadc-151">blocked</span></span>| <span data-ttu-id="afadc-152">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-152">200 OK</span></span>|
| <span data-ttu-id="afadc-153">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="afadc-153">third-party site</span></span>| <span data-ttu-id="afadc-154">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="afadc-154">everyone</span></span>| <span data-ttu-id="afadc-155">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-155">200 OK</span></span>|
| <span data-ttu-id="afadc-156">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="afadc-156">third-party site</span></span>| <span data-ttu-id="afadc-157">友達のみ</span><span class="sxs-lookup"><span data-stu-id="afadc-157">friends only</span></span>| <span data-ttu-id="afadc-158">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-158">200 OK</span></span>|
| <span data-ttu-id="afadc-159">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="afadc-159">third-party site</span></span>| <span data-ttu-id="afadc-160">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="afadc-160">blocked</span></span>| <span data-ttu-id="afadc-161">200 OK</span><span class="sxs-lookup"><span data-stu-id="afadc-161">200 OK</span></span>|

<a id="ID4EYF"></a>


## <a name="required-request-headers"></a><span data-ttu-id="afadc-162">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="afadc-162">Required Request Headers</span></span>

| <span data-ttu-id="afadc-163">Header</span><span class="sxs-lookup"><span data-stu-id="afadc-163">Header</span></span>| <span data-ttu-id="afadc-164">種類</span><span class="sxs-lookup"><span data-stu-id="afadc-164">Type</span></span>| <span data-ttu-id="afadc-165">説明</span><span class="sxs-lookup"><span data-stu-id="afadc-165">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="afadc-166">Authorization</span><span class="sxs-lookup"><span data-stu-id="afadc-166">Authorization</span></span>| <span data-ttu-id="afadc-167">string</span><span class="sxs-lookup"><span data-stu-id="afadc-167">string</span></span>| <span data-ttu-id="afadc-168">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="afadc-168">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="afadc-169">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="afadc-169">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="afadc-170">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="afadc-170">x-xbl-contract-version</span></span>| <span data-ttu-id="afadc-171">string</span><span class="sxs-lookup"><span data-stu-id="afadc-171">string</span></span>| <span data-ttu-id="afadc-172">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="afadc-172">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="afadc-173">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="afadc-173">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="afadc-174">値の例:3、vnext。</span><span class="sxs-lookup"><span data-stu-id="afadc-174">Example values: 3, vnext.</span></span>|
| <span data-ttu-id="afadc-175">OK</span><span class="sxs-lookup"><span data-stu-id="afadc-175">Accept</span></span>| <span data-ttu-id="afadc-176">string</span><span class="sxs-lookup"><span data-stu-id="afadc-176">string</span></span>| <span data-ttu-id="afadc-177">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="afadc-177">Content-Types that are acceptable.</span></span> <span data-ttu-id="afadc-178">存在することによってサポートされている唯一は、application/json がヘッダーに指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="afadc-178">The only one supported by Presence is application/json, but it must be specified in the header.</span></span>|
| <span data-ttu-id="afadc-179">Accept Language</span><span class="sxs-lookup"><span data-stu-id="afadc-179">Accept-Language</span></span>| <span data-ttu-id="afadc-180">string</span><span class="sxs-lookup"><span data-stu-id="afadc-180">string</span></span>| <span data-ttu-id="afadc-181">応答内の文字列に対して許容されるロケール。</span><span class="sxs-lookup"><span data-stu-id="afadc-181">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="afadc-182">値の例: en-us (英語)。</span><span class="sxs-lookup"><span data-stu-id="afadc-182">Example values: en-US.</span></span>|
| <span data-ttu-id="afadc-183">Host</span><span class="sxs-lookup"><span data-stu-id="afadc-183">Host</span></span>| <span data-ttu-id="afadc-184">string</span><span class="sxs-lookup"><span data-stu-id="afadc-184">string</span></span>| <span data-ttu-id="afadc-185">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="afadc-185">Domain name of the server.</span></span> <span data-ttu-id="afadc-186">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="afadc-186">Example value: presencebeta.xboxlive.com.</span></span>|
| <span data-ttu-id="afadc-187">Content-Length</span><span class="sxs-lookup"><span data-stu-id="afadc-187">Content-Length</span></span>| <span data-ttu-id="afadc-188">string</span><span class="sxs-lookup"><span data-stu-id="afadc-188">string</span></span>| <span data-ttu-id="afadc-189">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="afadc-189">The length of the request body.</span></span> <span data-ttu-id="afadc-190">値の例:312.</span><span class="sxs-lookup"><span data-stu-id="afadc-190">Example value: 312.</span></span>|

<a id="ID4EGAAC"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="afadc-191">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="afadc-191">Optional Request Headers</span></span>

| <span data-ttu-id="afadc-192">Header</span><span class="sxs-lookup"><span data-stu-id="afadc-192">Header</span></span>| <span data-ttu-id="afadc-193">種類</span><span class="sxs-lookup"><span data-stu-id="afadc-193">Type</span></span>| <span data-ttu-id="afadc-194">説明</span><span class="sxs-lookup"><span data-stu-id="afadc-194">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="afadc-195">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="afadc-195">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="afadc-196">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="afadc-196">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="afadc-197">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="afadc-197">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="afadc-198">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="afadc-198">Default value: 1.</span></span>|

<a id="ID4EGBAC"></a>


## <a name="request-body"></a><span data-ttu-id="afadc-199">要求本文</span><span class="sxs-lookup"><span data-stu-id="afadc-199">Request body</span></span>

<a id="ID4EMBAC"></a>


### <a name="required-members"></a><span data-ttu-id="afadc-200">必須メンバー</span><span class="sxs-lookup"><span data-stu-id="afadc-200">Required members</span></span>

| <span data-ttu-id="afadc-201">メンバー</span><span class="sxs-lookup"><span data-stu-id="afadc-201">Member</span></span>| <span data-ttu-id="afadc-202">説明</span><span class="sxs-lookup"><span data-stu-id="afadc-202">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="afadc-203">ユーザー</span><span class="sxs-lookup"><span data-stu-id="afadc-203">users</span></span>| <span data-ttu-id="afadc-204">ユーザーについては、1100 Xuid、一度に最大でプレゼンスが Xuid をリストします。</span><span class="sxs-lookup"><span data-stu-id="afadc-204">List XUIDs of users whose presence you want to learn, with a maximum of 1100 XUIDs at a time.</span></span>|

<a id="ID4EHCAC"></a>


### <a name="optional-members"></a><span data-ttu-id="afadc-205">省略可能なメンバー</span><span class="sxs-lookup"><span data-stu-id="afadc-205">Optional members</span></span>

| <span data-ttu-id="afadc-206">メンバー</span><span class="sxs-lookup"><span data-stu-id="afadc-206">Member</span></span>| <span data-ttu-id="afadc-207">説明</span><span class="sxs-lookup"><span data-stu-id="afadc-207">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="afadc-208">deviceTypes</span><span class="sxs-lookup"><span data-stu-id="afadc-208">deviceTypes</span></span>| <span data-ttu-id="afadc-209">について知りたいユーザーによって使用されるデバイスの種類の一覧です。</span><span class="sxs-lookup"><span data-stu-id="afadc-209">List of device types used by the users you want to know about.</span></span> <span data-ttu-id="afadc-210">配列が空のまま場合、すべての可能なデバイスの種類に既定値 (つまり、none、フィルターで除外)。</span><span class="sxs-lookup"><span data-stu-id="afadc-210">If the array is left empty, it defaults to all possible device types (that is, none are filtered out).</span></span>|
| <span data-ttu-id="afadc-211">タイトル</span><span class="sxs-lookup"><span data-stu-id="afadc-211">titles</span></span>| <span data-ttu-id="afadc-212">デバイスの一覧について知りたいユーザーを種類します。</span><span class="sxs-lookup"><span data-stu-id="afadc-212">List of device types whose users you want to know about.</span></span> <span data-ttu-id="afadc-213">配列が空のまま場合、すべての可能なタイトルを既定値 (つまり、none、フィルターで除外)。</span><span class="sxs-lookup"><span data-stu-id="afadc-213">If the array is left empty, it defaults to all possible titles (that is, none are filtered out).</span></span>|
| <span data-ttu-id="afadc-214">level</span><span class="sxs-lookup"><span data-stu-id="afadc-214">level</span></span>| <span data-ttu-id="afadc-215">設定可能な値:</span><span class="sxs-lookup"><span data-stu-id="afadc-215">Possible values:</span></span> <ul><li><span data-ttu-id="afadc-216">ユーザー - ユーザー ノードの取得</span><span class="sxs-lookup"><span data-stu-id="afadc-216">user - get user nodes</span></span></li><li><span data-ttu-id="afadc-217">デバイスのユーザーを取得し、デバイス ノード</span><span class="sxs-lookup"><span data-stu-id="afadc-217">device - get user and device nodes</span></span></li><li><span data-ttu-id="afadc-218">タイトル-タイトルの基本的なレベルの情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="afadc-218">title - get basic title level information</span></span></li><li><span data-ttu-id="afadc-219">豊富なプレゼンス情報、メディア情報、またはその両方の取得 - すべて</span><span class="sxs-lookup"><span data-stu-id="afadc-219">all - get rich presence information, media information, or both</span></span></li></ul><br> <span data-ttu-id="afadc-220">既定では"title です"。</span><span class="sxs-lookup"><span data-stu-id="afadc-220">The default is "title".</span></span>|
| <span data-ttu-id="afadc-221">ガジェットの onlineOnly</span><span class="sxs-lookup"><span data-stu-id="afadc-221">onlineOnly</span></span>| <span data-ttu-id="afadc-222">このプロパティが true の場合、バッチ操作はユーザーがオフライン (クロークされているものを含む) でレコードが除外されます。</span><span class="sxs-lookup"><span data-stu-id="afadc-222">If this property is true, the batch operation will filter out records for offline users (including cloaked ones).</span></span> <span data-ttu-id="afadc-223">指定されていない場合は、オンラインとオフラインの両方のユーザーが返されます。</span><span class="sxs-lookup"><span data-stu-id="afadc-223">If it is not supplied, both online and offline users will be returned.</span></span>|

<a id="ID4E4DAC"></a>


### <a name="prohibited-members"></a><span data-ttu-id="afadc-224">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="afadc-224">Prohibited members</span></span>

<span data-ttu-id="afadc-225">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="afadc-225">All other members are prohibited in a request.</span></span>

<a id="ID4EIEAC"></a>


### <a name="sample-request"></a><span data-ttu-id="afadc-226">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="afadc-226">Sample request</span></span>


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


## <a name="response-body"></a><span data-ttu-id="afadc-227">応答本文</span><span class="sxs-lookup"><span data-stu-id="afadc-227">Response body</span></span>

<a id="ID4E1EAC"></a>


### <a name="sample-response"></a><span data-ttu-id="afadc-228">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="afadc-228">Sample response</span></span>

<span data-ttu-id="afadc-229">このメソッドが戻る、 [PresenceRecord](../../json/json-presencerecord.md)します。</span><span class="sxs-lookup"><span data-stu-id="afadc-229">This method returns a [PresenceRecord](../../json/json-presencerecord.md).</span></span>


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


## <a name="see-also"></a><span data-ttu-id="afadc-230">関連項目</span><span class="sxs-lookup"><span data-stu-id="afadc-230">See also</span></span>

<a id="ID4EMFAC"></a>


##### <a name="parent"></a><span data-ttu-id="afadc-231">Parent</span><span class="sxs-lookup"><span data-stu-id="afadc-231">Parent</span></span>

[<span data-ttu-id="afadc-232">/users/batch</span><span class="sxs-lookup"><span data-stu-id="afadc-232">/users/batch</span></span>](uri-usersbatch.md)
