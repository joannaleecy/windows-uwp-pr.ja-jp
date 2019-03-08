---
title: GET (/users/me/groups/{moniker} )
assetID: c2527a08-411b-d4e4-422f-a8438804bfe6
permalink: en-us/docs/xboxlive/rest/uri-usersmegroupsmonikerget.html
description: " GET (/users/me/groups/{moniker} )"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 553ff55610ce30461bc6523aaed732aedc1efd18
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57595117"
---
# <a name="get-usersmegroupsmoniker-"></a><span data-ttu-id="a8ade-104">GET (/users/me/groups/{moniker} )</span><span class="sxs-lookup"><span data-stu-id="a8ade-104">GET (/users/me/groups/{moniker} )</span></span>
<span data-ttu-id="a8ade-105">グループ、PresenceRecord を取得します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-105">Gets the PresenceRecord for my group.</span></span> <span data-ttu-id="a8ade-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a8ade-107">注釈</span><span class="sxs-lookup"><span data-stu-id="a8ade-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="a8ade-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a8ade-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="a8ade-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a8ade-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="a8ade-110">承認</span><span class="sxs-lookup"><span data-stu-id="a8ade-110">Authorization</span></span>](#ID4EKC)
  * [<span data-ttu-id="a8ade-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="a8ade-111">Effect of privacy settings on resource</span></span>](#ID4EQD)
  * [<span data-ttu-id="a8ade-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a8ade-112">Required Request Headers</span></span>](#ID4EEH)
  * [<span data-ttu-id="a8ade-113">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a8ade-113">Optional Request Headers</span></span>](#ID4EMBAC)
  * [<span data-ttu-id="a8ade-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="a8ade-114">Request body</span></span>](#ID4EMCAC)
  * [<span data-ttu-id="a8ade-115">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a8ade-115">HTTP status codes</span></span>](#ID4EXCAC)
  * [<span data-ttu-id="a8ade-116">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a8ade-116">Required Response Headers</span></span>](#ID4E3GAC)
  * [<span data-ttu-id="a8ade-117">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a8ade-117">Optional Response Headers</span></span>](#ID4EMJAC)
  * [<span data-ttu-id="a8ade-118">応答本文</span><span class="sxs-lookup"><span data-stu-id="a8ade-118">Response body</span></span>](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="a8ade-119">注釈</span><span class="sxs-lookup"><span data-stu-id="a8ade-119">Remarks</span></span>
 
<span data-ttu-id="a8ade-120">要求でユーザーに関連するモニカーで指定されたグループ内のユーザーを取得し、これらのユーザーに対して PresenceRecord を返します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-120">Retrieves the users in the group specified by the moniker related to the user in the claims, and returns the PresenceRecord for those users.</span></span> <span data-ttu-id="a8ade-121">プライバシーやコンテンツの分離で区切られているデータは単に返されません。</span><span class="sxs-lookup"><span data-stu-id="a8ade-121">Data that is gated by Privacy or Content Isolation will simply not be returned.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a8ade-122">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a8ade-122">URI parameters</span></span>
 
| <span data-ttu-id="a8ade-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a8ade-123">Parameter</span></span>| <span data-ttu-id="a8ade-124">種類</span><span class="sxs-lookup"><span data-stu-id="a8ade-124">Type</span></span>| <span data-ttu-id="a8ade-125">説明</span><span class="sxs-lookup"><span data-stu-id="a8ade-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a8ade-126">モニカー</span><span class="sxs-lookup"><span data-stu-id="a8ade-126">moniker</span></span>| <span data-ttu-id="a8ade-127">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-127">string</span></span>| <span data-ttu-id="a8ade-128">ユーザーのグループを定義する文字列。</span><span class="sxs-lookup"><span data-stu-id="a8ade-128">String defining the group of users.</span></span> <span data-ttu-id="a8ade-129">現時点ではのみ受け入れられたモニカーでは、"People"が大文字の 'P' です。</span><span class="sxs-lookup"><span data-stu-id="a8ade-129">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="a8ade-130">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a8ade-130">Query string parameters</span></span>
 
| <span data-ttu-id="a8ade-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a8ade-131">Parameter</span></span>| <span data-ttu-id="a8ade-132">種類</span><span class="sxs-lookup"><span data-stu-id="a8ade-132">Type</span></span>| <span data-ttu-id="a8ade-133">説明</span><span class="sxs-lookup"><span data-stu-id="a8ade-133">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a8ade-134">level</span><span class="sxs-lookup"><span data-stu-id="a8ade-134">level</span></span>| <span data-ttu-id="a8ade-135">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-135">string</span></span>| <span data-ttu-id="a8ade-136">このクエリ文字列で指定された詳細情報のレベルを返します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-136">Returns the level of detail as specified by this query string.</span></span> <span data-ttu-id="a8ade-137">有効なオプションには、"user"、"device"、"title"および「すべて」が含まれます。"User"、レベルは、DeviceRecord 入れ子になったオブジェクトがない PresenceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a8ade-137">Valid options include "user", "device", "title", and "all".The level "user" is the PresenceRecord object without the DeviceRecord nested object.</span></span> <span data-ttu-id="a8ade-138">「デバイス」のレベルは、TitleRecord 入れ子になったオブジェクトがない PresenceRecord と DeviceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a8ade-138">The level "device" is the PresenceRecord and DeviceRecord objects without the TitleRecord nested object.</span></span> <span data-ttu-id="a8ade-139">"Title"、レベルは、ActivityRecord 入れ子になったオブジェクトがない PresenceRecord、DeviceRecord、TitleRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a8ade-139">The level "title" is the PresenceRecord, DeviceRecord, and TitleRecord objects without the ActivityRecord nested object.</span></span> <span data-ttu-id="a8ade-140">「すべて」のレベルは、入れ子になったすべてのオブジェクトを含む、全体のレコードです。このパラメーターが指定されていない場合、サービスのタイトルのレベルに既定値 (タイトルの詳細には、このユーザーのプレゼンスを返します、)。</span><span class="sxs-lookup"><span data-stu-id="a8ade-140">The level "all" is the entire record, including all nested objects.If this parameter is not provided, the service defaults to the title level (that is, it returns presence for this user down to the details of title).</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a><span data-ttu-id="a8ade-141">Authorization</span><span class="sxs-lookup"><span data-stu-id="a8ade-141">Authorization</span></span>
 
<span data-ttu-id="a8ade-142">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="a8ade-142">Authorization claims used</span></span> | <span data-ttu-id="a8ade-143">要求</span><span class="sxs-lookup"><span data-stu-id="a8ade-143">Claim</span></span>| <span data-ttu-id="a8ade-144">種類</span><span class="sxs-lookup"><span data-stu-id="a8ade-144">Type</span></span>| <span data-ttu-id="a8ade-145">必須?</span><span class="sxs-lookup"><span data-stu-id="a8ade-145">Required?</span></span>| <span data-ttu-id="a8ade-146">値の例</span><span class="sxs-lookup"><span data-stu-id="a8ade-146">Example value</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a8ade-147"><b>xuid</b></span><span class="sxs-lookup"><span data-stu-id="a8ade-147"><b>Xuid</b></span></span>| <span data-ttu-id="a8ade-148">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="a8ade-148">64-bit signed integer</span></span>| <span data-ttu-id="a8ade-149">○</span><span class="sxs-lookup"><span data-stu-id="a8ade-149">yes</span></span>| <span data-ttu-id="a8ade-150">1234567890</span><span class="sxs-lookup"><span data-stu-id="a8ade-150">1234567890</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="a8ade-151">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="a8ade-151">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="a8ade-152">サービスは常に返します 200 OK 要求自体が正しく構成されている場合。</span><span class="sxs-lookup"><span data-stu-id="a8ade-152">The service will always return 200 OK if the request itself is well-formed.</span></span> <span data-ttu-id="a8ade-153">ただし、プライバシーに関するチェックが適合しない場合に、応答からの情報をフィルター処理には。</span><span class="sxs-lookup"><span data-stu-id="a8ade-153">However, it will filter out information from the response when privacy checks do not pass.</span></span>
 
<span data-ttu-id="a8ade-154">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="a8ade-154">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="a8ade-155">要求元のユーザー</span><span class="sxs-lookup"><span data-stu-id="a8ade-155">Requesting User</span></span>| <span data-ttu-id="a8ade-156">ターゲット ユーザーのプライバシーの設定</span><span class="sxs-lookup"><span data-stu-id="a8ade-156">Target User's Privacy Setting</span></span>| <span data-ttu-id="a8ade-157">動作</span><span class="sxs-lookup"><span data-stu-id="a8ade-157">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a8ade-158">Me</span><span class="sxs-lookup"><span data-stu-id="a8ade-158">me</span></span>| -| <span data-ttu-id="a8ade-159">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="a8ade-159">As described.</span></span>| 
| <span data-ttu-id="a8ade-160">friend</span><span class="sxs-lookup"><span data-stu-id="a8ade-160">friend</span></span>| <span data-ttu-id="a8ade-161">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="a8ade-161">everyone</span></span>| <span data-ttu-id="a8ade-162">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="a8ade-162">As described.</span></span>| 
| <span data-ttu-id="a8ade-163">friend</span><span class="sxs-lookup"><span data-stu-id="a8ade-163">friend</span></span>| <span data-ttu-id="a8ade-164">友達のみ</span><span class="sxs-lookup"><span data-stu-id="a8ade-164">friends only</span></span>| <span data-ttu-id="a8ade-165">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="a8ade-165">As described.</span></span>| 
| <span data-ttu-id="a8ade-166">friend</span><span class="sxs-lookup"><span data-stu-id="a8ade-166">friend</span></span>| <span data-ttu-id="a8ade-167">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="a8ade-167">blocked</span></span>| <span data-ttu-id="a8ade-168">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="a8ade-168">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="a8ade-169">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="a8ade-169">non-friend user</span></span>| <span data-ttu-id="a8ade-170">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="a8ade-170">everyone</span></span>| <span data-ttu-id="a8ade-171">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="a8ade-171">As described.</span></span>| 
| <span data-ttu-id="a8ade-172">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="a8ade-172">non-friend user</span></span>| <span data-ttu-id="a8ade-173">友達のみ</span><span class="sxs-lookup"><span data-stu-id="a8ade-173">friends only</span></span>| <span data-ttu-id="a8ade-174">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="a8ade-174">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="a8ade-175">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="a8ade-175">non-friend user</span></span>| <span data-ttu-id="a8ade-176">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="a8ade-176">blocked</span></span>| <span data-ttu-id="a8ade-177">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="a8ade-177">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="a8ade-178">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="a8ade-178">third-party site</span></span>| <span data-ttu-id="a8ade-179">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="a8ade-179">everyone</span></span>| <span data-ttu-id="a8ade-180">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="a8ade-180">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="a8ade-181">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="a8ade-181">third-party site</span></span>| <span data-ttu-id="a8ade-182">友達のみ</span><span class="sxs-lookup"><span data-stu-id="a8ade-182">friends only</span></span>| <span data-ttu-id="a8ade-183">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="a8ade-183">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="a8ade-184">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="a8ade-184">third-party site</span></span>| <span data-ttu-id="a8ade-185">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="a8ade-185">blocked</span></span>| <span data-ttu-id="a8ade-186">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="a8ade-186">As described - the service will filter out data.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="a8ade-187">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a8ade-187">Required Request Headers</span></span>
 
| <span data-ttu-id="a8ade-188">Header</span><span class="sxs-lookup"><span data-stu-id="a8ade-188">Header</span></span>| <span data-ttu-id="a8ade-189">種類</span><span class="sxs-lookup"><span data-stu-id="a8ade-189">Type</span></span>| <span data-ttu-id="a8ade-190">説明</span><span class="sxs-lookup"><span data-stu-id="a8ade-190">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a8ade-191">Authorization</span><span class="sxs-lookup"><span data-stu-id="a8ade-191">Authorization</span></span>| <span data-ttu-id="a8ade-192">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-192">string</span></span>| <span data-ttu-id="a8ade-193">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-193">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="a8ade-194">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="a8ade-194">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="a8ade-195">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="a8ade-195">x-xbl-contract-version</span></span>| <span data-ttu-id="a8ade-196">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-196">string</span></span>| <span data-ttu-id="a8ade-197">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="a8ade-197">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="a8ade-198">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="a8ade-198">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="a8ade-199">値の例:3、vnext。</span><span class="sxs-lookup"><span data-stu-id="a8ade-199">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="a8ade-200">OK</span><span class="sxs-lookup"><span data-stu-id="a8ade-200">Accept</span></span>| <span data-ttu-id="a8ade-201">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-201">string</span></span>| <span data-ttu-id="a8ade-202">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="a8ade-202">Content-Types that are acceptable.</span></span> <span data-ttu-id="a8ade-203">1 つだけの存在がサポートされますが<b>、application/json</b>が、まだ必要がありますに指定するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="a8ade-203">The only one Presence supports is <b>application/json</b>, but it still must be specified in the header.</span></span>| 
| <span data-ttu-id="a8ade-204">Accept Language</span><span class="sxs-lookup"><span data-stu-id="a8ade-204">Accept-Language</span></span>| <span data-ttu-id="a8ade-205">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-205">string</span></span>| <span data-ttu-id="a8ade-206">応答内の文字列に対して許容されるロケール。</span><span class="sxs-lookup"><span data-stu-id="a8ade-206">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="a8ade-207">値の例: en-us (英語)。</span><span class="sxs-lookup"><span data-stu-id="a8ade-207">Example value: en-US.</span></span>| 
| <span data-ttu-id="a8ade-208">Host</span><span class="sxs-lookup"><span data-stu-id="a8ade-208">Host</span></span>| <span data-ttu-id="a8ade-209">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-209">string</span></span>| <span data-ttu-id="a8ade-210">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="a8ade-210">Domain name of the server.</span></span> <span data-ttu-id="a8ade-211">値の例: userpresence.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-211">Example value: userpresence.xboxlive.com.</span></span>| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="a8ade-212">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a8ade-212">Optional Request Headers</span></span>
 
| <span data-ttu-id="a8ade-213">Header</span><span class="sxs-lookup"><span data-stu-id="a8ade-213">Header</span></span>| <span data-ttu-id="a8ade-214">種類</span><span class="sxs-lookup"><span data-stu-id="a8ade-214">Type</span></span>| <span data-ttu-id="a8ade-215">説明</span><span class="sxs-lookup"><span data-stu-id="a8ade-215">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a8ade-216">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="a8ade-216">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="a8ade-217">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="a8ade-217">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="a8ade-218">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="a8ade-218">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="a8ade-219">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="a8ade-219">Default value: 1.</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="a8ade-220">要求本文</span><span class="sxs-lookup"><span data-stu-id="a8ade-220">Request body</span></span>
 
<span data-ttu-id="a8ade-221">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="a8ade-221">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="a8ade-222">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a8ade-222">HTTP status codes</span></span>
 
<span data-ttu-id="a8ade-223">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-223">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="a8ade-224">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-224">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="a8ade-225">コード</span><span class="sxs-lookup"><span data-stu-id="a8ade-225">Code</span></span>| <span data-ttu-id="a8ade-226">理由語句</span><span class="sxs-lookup"><span data-stu-id="a8ade-226">Reason phrase</span></span>| <span data-ttu-id="a8ade-227">説明</span><span class="sxs-lookup"><span data-stu-id="a8ade-227">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a8ade-228">200</span><span class="sxs-lookup"><span data-stu-id="a8ade-228">200</span></span>| <span data-ttu-id="a8ade-229">OK</span><span class="sxs-lookup"><span data-stu-id="a8ade-229">OK</span></span>| <span data-ttu-id="a8ade-230">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-230">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="a8ade-231">400</span><span class="sxs-lookup"><span data-stu-id="a8ade-231">400</span></span>| <span data-ttu-id="a8ade-232">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="a8ade-232">Bad Request</span></span>| <span data-ttu-id="a8ade-233">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="a8ade-233">Service could not understand malformed request.</span></span> <span data-ttu-id="a8ade-234">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="a8ade-234">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="a8ade-235">401</span><span class="sxs-lookup"><span data-stu-id="a8ade-235">401</span></span>| <span data-ttu-id="a8ade-236">権限がありません</span><span class="sxs-lookup"><span data-stu-id="a8ade-236">Unauthorized</span></span>| <span data-ttu-id="a8ade-237">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="a8ade-237">The request requires user authentication.</span></span>| 
| <span data-ttu-id="a8ade-238">403</span><span class="sxs-lookup"><span data-stu-id="a8ade-238">403</span></span>| <span data-ttu-id="a8ade-239">Forbidden</span><span class="sxs-lookup"><span data-stu-id="a8ade-239">Forbidden</span></span>| <span data-ttu-id="a8ade-240">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="a8ade-240">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="a8ade-241">404</span><span class="sxs-lookup"><span data-stu-id="a8ade-241">404</span></span>| <span data-ttu-id="a8ade-242">検出不可</span><span class="sxs-lookup"><span data-stu-id="a8ade-242">Not Found</span></span>| <span data-ttu-id="a8ade-243">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="a8ade-243">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="a8ade-244">405</span><span class="sxs-lookup"><span data-stu-id="a8ade-244">405</span></span>| <span data-ttu-id="a8ade-245">許可されていないメソッド</span><span class="sxs-lookup"><span data-stu-id="a8ade-245">Method Not Allowed</span></span>| <span data-ttu-id="a8ade-246">HTTP メソッドは、サポートされていないコンテンツの種類で使用されました。</span><span class="sxs-lookup"><span data-stu-id="a8ade-246">HTTP method was used on an unsupported content type.</span></span>| 
| <span data-ttu-id="a8ade-247">406</span><span class="sxs-lookup"><span data-stu-id="a8ade-247">406</span></span>| <span data-ttu-id="a8ade-248">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="a8ade-248">Not Acceptable</span></span>| <span data-ttu-id="a8ade-249">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a8ade-249">Resource version is not supported.</span></span>| 
| <span data-ttu-id="a8ade-250">500</span><span class="sxs-lookup"><span data-stu-id="a8ade-250">500</span></span>| <span data-ttu-id="a8ade-251">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="a8ade-251">Request Timeout</span></span>| <span data-ttu-id="a8ade-252">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="a8ade-252">Service could not understand malformed request.</span></span> <span data-ttu-id="a8ade-253">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="a8ade-253">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="a8ade-254">503</span><span class="sxs-lookup"><span data-stu-id="a8ade-254">503</span></span>| <span data-ttu-id="a8ade-255">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="a8ade-255">Request Timeout</span></span>| <span data-ttu-id="a8ade-256">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="a8ade-256">Service could not understand malformed request.</span></span> <span data-ttu-id="a8ade-257">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="a8ade-257">Typically an invalid parameter.</span></span>| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="a8ade-258">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a8ade-258">Required Response Headers</span></span>
 
| <span data-ttu-id="a8ade-259">Header</span><span class="sxs-lookup"><span data-stu-id="a8ade-259">Header</span></span>| <span data-ttu-id="a8ade-260">種類</span><span class="sxs-lookup"><span data-stu-id="a8ade-260">Type</span></span>| <span data-ttu-id="a8ade-261">説明</span><span class="sxs-lookup"><span data-stu-id="a8ade-261">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a8ade-262">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="a8ade-262">x-xbl-contract-version</span></span>| <span data-ttu-id="a8ade-263">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-263">string</span></span>| <span data-ttu-id="a8ade-264">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="a8ade-264">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="a8ade-265">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="a8ade-265">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="a8ade-266">値の例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="a8ade-266">Example values: 1, vnext.</span></span>| 
| <span data-ttu-id="a8ade-267">Content-Type</span><span class="sxs-lookup"><span data-stu-id="a8ade-267">Content-Type</span></span>| <span data-ttu-id="a8ade-268">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-268">string</span></span>| <span data-ttu-id="a8ade-269">要求の本文の mime の種類。</span><span class="sxs-lookup"><span data-stu-id="a8ade-269">The mime type of the body of the request.</span></span> <span data-ttu-id="a8ade-270">値の例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-270">Example value: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="a8ade-271">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="a8ade-271">Cache-Control</span></span>| <span data-ttu-id="a8ade-272">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-272">string</span></span>| <span data-ttu-id="a8ade-273">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="a8ade-273">Polite request to specify caching behavior.</span></span> <span data-ttu-id="a8ade-274">値の例:"no-cache"。</span><span class="sxs-lookup"><span data-stu-id="a8ade-274">Example values: "no-cache".</span></span>| 
| <span data-ttu-id="a8ade-275">X-XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="a8ade-275">X-XblCorrelationId</span></span>| <span data-ttu-id="a8ade-276">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-276">string</span></span>| <span data-ttu-id="a8ade-277">サーバーが返すし、クライアントによって受信されるを関連付けるためにサービスによって生成された値。</span><span class="sxs-lookup"><span data-stu-id="a8ade-277">Service-generated value to correlate what the server returns and what is received by the client.</span></span> <span data-ttu-id="a8ade-278">値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"。</span><span class="sxs-lookup"><span data-stu-id="a8ade-278">Example value: "4106d0bc-1cb3-47bd-83fd-57d041c6febe".</span></span>| 
| <span data-ttu-id="a8ade-279">X のコンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="a8ade-279">X-Content-Type-Option</span></span>| <span data-ttu-id="a8ade-280">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-280">string</span></span>| <span data-ttu-id="a8ade-281">SDL 準拠の値を返します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-281">Returns the SDL-compliant value.</span></span> <span data-ttu-id="a8ade-282">値の例:"nosniff"。</span><span class="sxs-lookup"><span data-stu-id="a8ade-282">Example value: "nosniff".</span></span>| 
| <span data-ttu-id="a8ade-283">日付</span><span class="sxs-lookup"><span data-stu-id="a8ade-283">Date</span></span>| <span data-ttu-id="a8ade-284">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-284">string</span></span>| <span data-ttu-id="a8ade-285">日付/時刻、メッセージが送信されました。</span><span class="sxs-lookup"><span data-stu-id="a8ade-285">The date/time the message was sent.</span></span> <span data-ttu-id="a8ade-286">値の例:"(火)、17 年 2012年 11 月 10時 33分: 31 GMT」。</span><span class="sxs-lookup"><span data-stu-id="a8ade-286">Example value: "Tue, 17 Nov 2012 10:33:31 GMT".</span></span>| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="a8ade-287">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a8ade-287">Optional Response Headers</span></span>
 
| <span data-ttu-id="a8ade-288">Header</span><span class="sxs-lookup"><span data-stu-id="a8ade-288">Header</span></span>| <span data-ttu-id="a8ade-289">種類</span><span class="sxs-lookup"><span data-stu-id="a8ade-289">Type</span></span>| <span data-ttu-id="a8ade-290">説明</span><span class="sxs-lookup"><span data-stu-id="a8ade-290">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a8ade-291">再試行後</span><span class="sxs-lookup"><span data-stu-id="a8ade-291">Retry-After</span></span>| <span data-ttu-id="a8ade-292">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-292">string</span></span>| <span data-ttu-id="a8ade-293">503 HTTP エラーで返されます。</span><span class="sxs-lookup"><span data-stu-id="a8ade-293">Returned on 503 HTTP errors.</span></span> <span data-ttu-id="a8ade-294">クライアント呼び出しを再試行する前に待機する時間に知ることができます。</span><span class="sxs-lookup"><span data-stu-id="a8ade-294">Lets client know how long to wait before retrying the call.</span></span> <span data-ttu-id="a8ade-295">値の例:"120".</span><span class="sxs-lookup"><span data-stu-id="a8ade-295">Example values: "120".</span></span>| 
| <span data-ttu-id="a8ade-296">Content-Length</span><span class="sxs-lookup"><span data-stu-id="a8ade-296">Content-Length</span></span>| <span data-ttu-id="a8ade-297">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-297">string</span></span>| <span data-ttu-id="a8ade-298">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="a8ade-298">Length of response body.</span></span> <span data-ttu-id="a8ade-299">値の例:"527".</span><span class="sxs-lookup"><span data-stu-id="a8ade-299">Example value: "527".</span></span>| 
| <span data-ttu-id="a8ade-300">コンテンツ エンコーディング</span><span class="sxs-lookup"><span data-stu-id="a8ade-300">Content-Encoding</span></span>| <span data-ttu-id="a8ade-301">string</span><span class="sxs-lookup"><span data-stu-id="a8ade-301">string</span></span>| <span data-ttu-id="a8ade-302">応答のエンコードの種類。</span><span class="sxs-lookup"><span data-stu-id="a8ade-302">Encoding type of the response.</span></span> <span data-ttu-id="a8ade-303">値の例:"gzip"です。</span><span class="sxs-lookup"><span data-stu-id="a8ade-303">Example value: "gzip".</span></span>| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="a8ade-304">応答本文</span><span class="sxs-lookup"><span data-stu-id="a8ade-304">Response body</span></span>
 
<span data-ttu-id="a8ade-305">この API は、要求から Xuid ごとに 1 つ PresenceRecord オブジェクトの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="a8ade-305">This API returns an array of PresenceRecord objects, one for each of the XUIDs from the request.</span></span>
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="a8ade-306">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="a8ade-306">Sample response</span></span>
 

```cpp
[
     {
         xuid:"0123456789",
         state:"online",
         devices:
         [
             {
                 type:"D",
                 titles:
                 [
                     {
                         id:"12341234",
                         name:"Contoso 5",
                         lastModified:"2012-09-17T07:15:23.4930000",
                         placement:"full",
                         state:"active",
                         activity:
                         {
                             richPresence:"Playing on Nirvana"
                         },
                     }
                 ]
             }
         ]
     },
     {
         xuid:"0123456780",
         state:"online",
         devices:
         [
             {
                 type:"D",
                 titles:
                 [
                     {
                         id:"12341235",
                         name:"Contoso Waypoint",
                         lastModified:"2012-09-17T07:15:23.4930000",
                         placement;"full",
                         state:"active",
                         activity:
                         {
                             richPresence:"Viewing stats"
                         },
                     }
                 ]
             }
         ]
     },
     {
         xuid:"0123456781",
         state:"online",
         devices:
         [
             {
                 type:"Win8",
                 titles:
                 [
                     {
                         id:"23452345",
                         name:"Contoso Gamehelp",
                         state:"active",
                         timestamp:"2012-09-17T07:15:23.4930000",
                         activity:
                         {
                             richPresence:"Viewing help"
                         }
                     }
                 ]
             }
         ]
     }
 ]
         
```

   
<a id="ID4EQLAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="a8ade-307">関連項目</span><span class="sxs-lookup"><span data-stu-id="a8ade-307">See also</span></span>
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="a8ade-308">Parent</span><span class="sxs-lookup"><span data-stu-id="a8ade-308">Parent</span></span> 

[<span data-ttu-id="a8ade-309">/users/me/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="a8ade-309">/users/me/groups/{moniker}</span></span>](uri-usersmegroupsmoniker.md)

   