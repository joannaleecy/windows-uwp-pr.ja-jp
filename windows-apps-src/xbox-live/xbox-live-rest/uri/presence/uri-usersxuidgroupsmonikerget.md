---
title: GET (/users/xuid({xuid})/groups/{moniker} )
assetID: 63aa7e5d-0599-5850-756d-3079c0772238
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerget.html
description: " GET (/users/xuid({xuid})/groups/{moniker} )"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: df967677ce779fc128a8956f137a027a108d313d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623847"
---
# <a name="get-usersxuidxuidgroupsmoniker-"></a><span data-ttu-id="2e845-104">GET (/users/xuid({xuid})/groups/{moniker} )</span><span class="sxs-lookup"><span data-stu-id="2e845-104">GET (/users/xuid({xuid})/groups/{moniker} )</span></span>
<span data-ttu-id="2e845-105">グループの PresenceRecord を取得します。</span><span class="sxs-lookup"><span data-stu-id="2e845-105">Gets the PresenceRecord for a group.</span></span> <span data-ttu-id="2e845-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2e845-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="2e845-107">注釈</span><span class="sxs-lookup"><span data-stu-id="2e845-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="2e845-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2e845-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="2e845-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="2e845-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="2e845-110">承認</span><span class="sxs-lookup"><span data-stu-id="2e845-110">Authorization</span></span>](#ID4EKC)
  * [<span data-ttu-id="2e845-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="2e845-111">Effect of privacy settings on resource</span></span>](#ID4EQD)
  * [<span data-ttu-id="2e845-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2e845-112">Required Request Headers</span></span>](#ID4EEH)
  * [<span data-ttu-id="2e845-113">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2e845-113">Optional Request Headers</span></span>](#ID4EMBAC)
  * [<span data-ttu-id="2e845-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="2e845-114">Request body</span></span>](#ID4EMCAC)
  * [<span data-ttu-id="2e845-115">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="2e845-115">HTTP status codes</span></span>](#ID4EXCAC)
  * [<span data-ttu-id="2e845-116">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2e845-116">Required Response Headers</span></span>](#ID4E3GAC)
  * [<span data-ttu-id="2e845-117">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2e845-117">Optional Response Headers</span></span>](#ID4EMJAC)
  * [<span data-ttu-id="2e845-118">応答本文</span><span class="sxs-lookup"><span data-stu-id="2e845-118">Response body</span></span>](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="2e845-119">注釈</span><span class="sxs-lookup"><span data-stu-id="2e845-119">Remarks</span></span>
 
<span data-ttu-id="2e845-120">URI のユーザーに関連するモニカーで指定されたグループ内のユーザーを取得し、これらのユーザーに対して PresenceRecord を返します。</span><span class="sxs-lookup"><span data-stu-id="2e845-120">Retrieves the users in the group specified by the moniker related to the user in the URI, and returns the PresenceRecord for those users.</span></span> <span data-ttu-id="2e845-121">プライバシーやコンテンツの分離で区切られているデータは単に返されません。</span><span class="sxs-lookup"><span data-stu-id="2e845-121">Data that is gated by Privacy or Content Isolation will simply not be returned.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="2e845-122">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2e845-122">URI parameters</span></span>
 
| <span data-ttu-id="2e845-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2e845-123">Parameter</span></span>| <span data-ttu-id="2e845-124">種類</span><span class="sxs-lookup"><span data-stu-id="2e845-124">Type</span></span>| <span data-ttu-id="2e845-125">説明</span><span class="sxs-lookup"><span data-stu-id="2e845-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2e845-126">xuid</span><span class="sxs-lookup"><span data-stu-id="2e845-126">xuid</span></span>| <span data-ttu-id="2e845-127">string</span><span class="sxs-lookup"><span data-stu-id="2e845-127">string</span></span>| <span data-ttu-id="2e845-128">Xbox ユーザー ID (XUID) のグループで Xuid に関連するユーザーです。</span><span class="sxs-lookup"><span data-stu-id="2e845-128">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="2e845-129">モニカー</span><span class="sxs-lookup"><span data-stu-id="2e845-129">moniker</span></span>| <span data-ttu-id="2e845-130">string</span><span class="sxs-lookup"><span data-stu-id="2e845-130">string</span></span>| <span data-ttu-id="2e845-131">ユーザーのグループを定義する文字列。</span><span class="sxs-lookup"><span data-stu-id="2e845-131">String defining the group of users.</span></span> <span data-ttu-id="2e845-132">現時点ではのみ受け入れられたモニカーでは、"People"が大文字の 'P' です。</span><span class="sxs-lookup"><span data-stu-id="2e845-132">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="2e845-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="2e845-133">Query string parameters</span></span>
 
| <span data-ttu-id="2e845-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2e845-134">Parameter</span></span>| <span data-ttu-id="2e845-135">種類</span><span class="sxs-lookup"><span data-stu-id="2e845-135">Type</span></span>| <span data-ttu-id="2e845-136">説明</span><span class="sxs-lookup"><span data-stu-id="2e845-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2e845-137">level</span><span class="sxs-lookup"><span data-stu-id="2e845-137">level</span></span>| <span data-ttu-id="2e845-138">string</span><span class="sxs-lookup"><span data-stu-id="2e845-138">string</span></span>| <span data-ttu-id="2e845-139">このクエリ文字列で指定された詳細情報のレベルを返します。</span><span class="sxs-lookup"><span data-stu-id="2e845-139">Returns the level of detail as specified by this query string.</span></span> <span data-ttu-id="2e845-140">有効なオプションには、"user"、"device"、"title"および「すべて」が含まれます。"User"、レベルは、DeviceRecord 入れ子になったオブジェクトがない PresenceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="2e845-140">Valid options include "user", "device", "title", and "all".The level "user" is the PresenceRecord object without the DeviceRecord nested object.</span></span> <span data-ttu-id="2e845-141">「デバイス」のレベルは、TitleRecord 入れ子になったオブジェクトがない PresenceRecord と DeviceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="2e845-141">The level "device" is the PresenceRecord and DeviceRecord objects without the TitleRecord nested object.</span></span> <span data-ttu-id="2e845-142">"Title"、レベルは、ActivityRecord 入れ子になったオブジェクトがない PresenceRecord、DeviceRecord、TitleRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="2e845-142">The level "title" is the PresenceRecord, DeviceRecord, and TitleRecord objects without the ActivityRecord nested object.</span></span> <span data-ttu-id="2e845-143">「すべて」のレベルは、入れ子になったすべてのオブジェクトを含む、全体のレコードです。このパラメーターが指定されていない場合、サービスのタイトルのレベルに既定値 (タイトルの詳細には、このユーザーのプレゼンスを返します、)。</span><span class="sxs-lookup"><span data-stu-id="2e845-143">The level "all" is the entire record, including all nested objects.If this parameter is not provided, the service defaults to the title level (that is, it returns presence for this user down to the details of title).</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a><span data-ttu-id="2e845-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="2e845-144">Authorization</span></span>
 
<span data-ttu-id="2e845-145">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="2e845-145">Authorization claims used</span></span> | <span data-ttu-id="2e845-146">要求</span><span class="sxs-lookup"><span data-stu-id="2e845-146">Claim</span></span>| <span data-ttu-id="2e845-147">種類</span><span class="sxs-lookup"><span data-stu-id="2e845-147">Type</span></span>| <span data-ttu-id="2e845-148">必須?</span><span class="sxs-lookup"><span data-stu-id="2e845-148">Required?</span></span>| <span data-ttu-id="2e845-149">値の例</span><span class="sxs-lookup"><span data-stu-id="2e845-149">Example value</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2e845-150"><b>xuid</b></span><span class="sxs-lookup"><span data-stu-id="2e845-150"><b>Xuid</b></span></span>| <span data-ttu-id="2e845-151">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="2e845-151">64-bit signed integer</span></span>| <span data-ttu-id="2e845-152">○</span><span class="sxs-lookup"><span data-stu-id="2e845-152">yes</span></span>| <span data-ttu-id="2e845-153">1234567890</span><span class="sxs-lookup"><span data-stu-id="2e845-153">1234567890</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="2e845-154">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="2e845-154">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="2e845-155">サービスは常に返します 200 OK 要求自体が正しく構成されている場合。</span><span class="sxs-lookup"><span data-stu-id="2e845-155">The service will always return 200 OK if the request itself is well-formed.</span></span> <span data-ttu-id="2e845-156">ただし、プライバシーに関するチェックが適合しない場合に、応答からの情報をフィルター処理には。</span><span class="sxs-lookup"><span data-stu-id="2e845-156">However, it will filter out information from the response when privacy checks do not pass.</span></span>
 
<span data-ttu-id="2e845-157">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="2e845-157">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="2e845-158">要求元のユーザー</span><span class="sxs-lookup"><span data-stu-id="2e845-158">Requesting User</span></span>| <span data-ttu-id="2e845-159">ターゲット ユーザーのプライバシーの設定</span><span class="sxs-lookup"><span data-stu-id="2e845-159">Target User's Privacy Setting</span></span>| <span data-ttu-id="2e845-160">動作</span><span class="sxs-lookup"><span data-stu-id="2e845-160">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2e845-161">Me</span><span class="sxs-lookup"><span data-stu-id="2e845-161">me</span></span>| -| <span data-ttu-id="2e845-162">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="2e845-162">As described.</span></span>| 
| <span data-ttu-id="2e845-163">friend</span><span class="sxs-lookup"><span data-stu-id="2e845-163">friend</span></span>| <span data-ttu-id="2e845-164">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="2e845-164">everyone</span></span>| <span data-ttu-id="2e845-165">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="2e845-165">As described.</span></span>| 
| <span data-ttu-id="2e845-166">friend</span><span class="sxs-lookup"><span data-stu-id="2e845-166">friend</span></span>| <span data-ttu-id="2e845-167">友達のみ</span><span class="sxs-lookup"><span data-stu-id="2e845-167">friends only</span></span>| <span data-ttu-id="2e845-168">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="2e845-168">As described.</span></span>| 
| <span data-ttu-id="2e845-169">friend</span><span class="sxs-lookup"><span data-stu-id="2e845-169">friend</span></span>| <span data-ttu-id="2e845-170">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="2e845-170">blocked</span></span>| <span data-ttu-id="2e845-171">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="2e845-171">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="2e845-172">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="2e845-172">non-friend user</span></span>| <span data-ttu-id="2e845-173">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="2e845-173">everyone</span></span>| <span data-ttu-id="2e845-174">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="2e845-174">As described.</span></span>| 
| <span data-ttu-id="2e845-175">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="2e845-175">non-friend user</span></span>| <span data-ttu-id="2e845-176">友達のみ</span><span class="sxs-lookup"><span data-stu-id="2e845-176">friends only</span></span>| <span data-ttu-id="2e845-177">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="2e845-177">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="2e845-178">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="2e845-178">non-friend user</span></span>| <span data-ttu-id="2e845-179">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="2e845-179">blocked</span></span>| <span data-ttu-id="2e845-180">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="2e845-180">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="2e845-181">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="2e845-181">third-party site</span></span>| <span data-ttu-id="2e845-182">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="2e845-182">everyone</span></span>| <span data-ttu-id="2e845-183">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="2e845-183">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="2e845-184">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="2e845-184">third-party site</span></span>| <span data-ttu-id="2e845-185">友達のみ</span><span class="sxs-lookup"><span data-stu-id="2e845-185">friends only</span></span>| <span data-ttu-id="2e845-186">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="2e845-186">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="2e845-187">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="2e845-187">third-party site</span></span>| <span data-ttu-id="2e845-188">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="2e845-188">blocked</span></span>| <span data-ttu-id="2e845-189">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="2e845-189">As described - the service will filter out data.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="2e845-190">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2e845-190">Required Request Headers</span></span>
 
| <span data-ttu-id="2e845-191">Header</span><span class="sxs-lookup"><span data-stu-id="2e845-191">Header</span></span>| <span data-ttu-id="2e845-192">種類</span><span class="sxs-lookup"><span data-stu-id="2e845-192">Type</span></span>| <span data-ttu-id="2e845-193">説明</span><span class="sxs-lookup"><span data-stu-id="2e845-193">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2e845-194">Authorization</span><span class="sxs-lookup"><span data-stu-id="2e845-194">Authorization</span></span>| <span data-ttu-id="2e845-195">string</span><span class="sxs-lookup"><span data-stu-id="2e845-195">string</span></span>| <span data-ttu-id="2e845-196">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="2e845-196">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="2e845-197">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="2e845-197">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="2e845-198">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="2e845-198">x-xbl-contract-version</span></span>| <span data-ttu-id="2e845-199">string</span><span class="sxs-lookup"><span data-stu-id="2e845-199">string</span></span>| <span data-ttu-id="2e845-200">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="2e845-200">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="2e845-201">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="2e845-201">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="2e845-202">値の例:3、vnext。</span><span class="sxs-lookup"><span data-stu-id="2e845-202">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="2e845-203">OK</span><span class="sxs-lookup"><span data-stu-id="2e845-203">Accept</span></span>| <span data-ttu-id="2e845-204">string</span><span class="sxs-lookup"><span data-stu-id="2e845-204">string</span></span>| <span data-ttu-id="2e845-205">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="2e845-205">Content-Types that are acceptable.</span></span> <span data-ttu-id="2e845-206">1 つだけの存在がサポートされますが<b>、application/json</b>が、まだ必要がありますに指定するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="2e845-206">The only one Presence supports is <b>application/json</b>, but it still must be specified in the header.</span></span>| 
| <span data-ttu-id="2e845-207">Accept Language</span><span class="sxs-lookup"><span data-stu-id="2e845-207">Accept-Language</span></span>| <span data-ttu-id="2e845-208">string</span><span class="sxs-lookup"><span data-stu-id="2e845-208">string</span></span>| <span data-ttu-id="2e845-209">応答内の文字列に対して許容されるロケール。</span><span class="sxs-lookup"><span data-stu-id="2e845-209">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="2e845-210">値の例: en-us (英語)。</span><span class="sxs-lookup"><span data-stu-id="2e845-210">Example value: en-US.</span></span>| 
| <span data-ttu-id="2e845-211">Host</span><span class="sxs-lookup"><span data-stu-id="2e845-211">Host</span></span>| <span data-ttu-id="2e845-212">string</span><span class="sxs-lookup"><span data-stu-id="2e845-212">string</span></span>| <span data-ttu-id="2e845-213">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="2e845-213">Domain name of the server.</span></span> <span data-ttu-id="2e845-214">値の例: userpresence.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="2e845-214">Example value: userpresence.xboxlive.com.</span></span>| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="2e845-215">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2e845-215">Optional Request Headers</span></span>
 
| <span data-ttu-id="2e845-216">Header</span><span class="sxs-lookup"><span data-stu-id="2e845-216">Header</span></span>| <span data-ttu-id="2e845-217">種類</span><span class="sxs-lookup"><span data-stu-id="2e845-217">Type</span></span>| <span data-ttu-id="2e845-218">説明</span><span class="sxs-lookup"><span data-stu-id="2e845-218">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2e845-219">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="2e845-219">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="2e845-220">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="2e845-220">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="2e845-221">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="2e845-221">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="2e845-222">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="2e845-222">Default value: 1.</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="2e845-223">要求本文</span><span class="sxs-lookup"><span data-stu-id="2e845-223">Request body</span></span>
 
<span data-ttu-id="2e845-224">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="2e845-224">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="2e845-225">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="2e845-225">HTTP status codes</span></span>
 
<span data-ttu-id="2e845-226">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="2e845-226">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="2e845-227">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="2e845-227">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="2e845-228">コード</span><span class="sxs-lookup"><span data-stu-id="2e845-228">Code</span></span>| <span data-ttu-id="2e845-229">理由語句</span><span class="sxs-lookup"><span data-stu-id="2e845-229">Reason phrase</span></span>| <span data-ttu-id="2e845-230">説明</span><span class="sxs-lookup"><span data-stu-id="2e845-230">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2e845-231">200</span><span class="sxs-lookup"><span data-stu-id="2e845-231">200</span></span>| <span data-ttu-id="2e845-232">OK</span><span class="sxs-lookup"><span data-stu-id="2e845-232">OK</span></span>| <span data-ttu-id="2e845-233">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="2e845-233">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="2e845-234">400</span><span class="sxs-lookup"><span data-stu-id="2e845-234">400</span></span>| <span data-ttu-id="2e845-235">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="2e845-235">Bad Request</span></span>| <span data-ttu-id="2e845-236">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="2e845-236">Service could not understand malformed request.</span></span> <span data-ttu-id="2e845-237">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="2e845-237">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="2e845-238">401</span><span class="sxs-lookup"><span data-stu-id="2e845-238">401</span></span>| <span data-ttu-id="2e845-239">権限がありません</span><span class="sxs-lookup"><span data-stu-id="2e845-239">Unauthorized</span></span>| <span data-ttu-id="2e845-240">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="2e845-240">The request requires user authentication.</span></span>| 
| <span data-ttu-id="2e845-241">403</span><span class="sxs-lookup"><span data-stu-id="2e845-241">403</span></span>| <span data-ttu-id="2e845-242">Forbidden</span><span class="sxs-lookup"><span data-stu-id="2e845-242">Forbidden</span></span>| <span data-ttu-id="2e845-243">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="2e845-243">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="2e845-244">404</span><span class="sxs-lookup"><span data-stu-id="2e845-244">404</span></span>| <span data-ttu-id="2e845-245">検出不可</span><span class="sxs-lookup"><span data-stu-id="2e845-245">Not Found</span></span>| <span data-ttu-id="2e845-246">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="2e845-246">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="2e845-247">405</span><span class="sxs-lookup"><span data-stu-id="2e845-247">405</span></span>| <span data-ttu-id="2e845-248">許可されていないメソッド</span><span class="sxs-lookup"><span data-stu-id="2e845-248">Method Not Allowed</span></span>| <span data-ttu-id="2e845-249">HTTP メソッドは、サポートされていないコンテンツの種類で使用されました。</span><span class="sxs-lookup"><span data-stu-id="2e845-249">HTTP method was used on an unsupported content type.</span></span>| 
| <span data-ttu-id="2e845-250">406</span><span class="sxs-lookup"><span data-stu-id="2e845-250">406</span></span>| <span data-ttu-id="2e845-251">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="2e845-251">Not Acceptable</span></span>| <span data-ttu-id="2e845-252">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="2e845-252">Resource version is not supported.</span></span>| 
| <span data-ttu-id="2e845-253">500</span><span class="sxs-lookup"><span data-stu-id="2e845-253">500</span></span>| <span data-ttu-id="2e845-254">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="2e845-254">Request Timeout</span></span>| <span data-ttu-id="2e845-255">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="2e845-255">Service could not understand malformed request.</span></span> <span data-ttu-id="2e845-256">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="2e845-256">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="2e845-257">503</span><span class="sxs-lookup"><span data-stu-id="2e845-257">503</span></span>| <span data-ttu-id="2e845-258">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="2e845-258">Request Timeout</span></span>| <span data-ttu-id="2e845-259">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="2e845-259">Service could not understand malformed request.</span></span> <span data-ttu-id="2e845-260">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="2e845-260">Typically an invalid parameter.</span></span>| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="2e845-261">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2e845-261">Required Response Headers</span></span>
 
| <span data-ttu-id="2e845-262">Header</span><span class="sxs-lookup"><span data-stu-id="2e845-262">Header</span></span>| <span data-ttu-id="2e845-263">種類</span><span class="sxs-lookup"><span data-stu-id="2e845-263">Type</span></span>| <span data-ttu-id="2e845-264">説明</span><span class="sxs-lookup"><span data-stu-id="2e845-264">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2e845-265">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="2e845-265">x-xbl-contract-version</span></span>| <span data-ttu-id="2e845-266">string</span><span class="sxs-lookup"><span data-stu-id="2e845-266">string</span></span>| <span data-ttu-id="2e845-267">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="2e845-267">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="2e845-268">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="2e845-268">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="2e845-269">値の例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="2e845-269">Example values: 1, vnext.</span></span>| 
| <span data-ttu-id="2e845-270">Content-Type</span><span class="sxs-lookup"><span data-stu-id="2e845-270">Content-Type</span></span>| <span data-ttu-id="2e845-271">string</span><span class="sxs-lookup"><span data-stu-id="2e845-271">string</span></span>| <span data-ttu-id="2e845-272">要求の本文の mime の種類。</span><span class="sxs-lookup"><span data-stu-id="2e845-272">The mime type of the body of the request.</span></span> <span data-ttu-id="2e845-273">値の例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="2e845-273">Example value: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="2e845-274">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="2e845-274">Cache-Control</span></span>| <span data-ttu-id="2e845-275">string</span><span class="sxs-lookup"><span data-stu-id="2e845-275">string</span></span>| <span data-ttu-id="2e845-276">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="2e845-276">Polite request to specify caching behavior.</span></span> <span data-ttu-id="2e845-277">値の例:"no-cache"。</span><span class="sxs-lookup"><span data-stu-id="2e845-277">Example values: "no-cache".</span></span>| 
| <span data-ttu-id="2e845-278">X-XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="2e845-278">X-XblCorrelationId</span></span>| <span data-ttu-id="2e845-279">string</span><span class="sxs-lookup"><span data-stu-id="2e845-279">string</span></span>| <span data-ttu-id="2e845-280">サーバーが返すし、クライアントによって受信されるを関連付けるためにサービスによって生成された値。</span><span class="sxs-lookup"><span data-stu-id="2e845-280">Service-generated value to correlate what the server returns and what is received by the client.</span></span> <span data-ttu-id="2e845-281">値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"。</span><span class="sxs-lookup"><span data-stu-id="2e845-281">Example value: "4106d0bc-1cb3-47bd-83fd-57d041c6febe".</span></span>| 
| <span data-ttu-id="2e845-282">X のコンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="2e845-282">X-Content-Type-Option</span></span>| <span data-ttu-id="2e845-283">string</span><span class="sxs-lookup"><span data-stu-id="2e845-283">string</span></span>| <span data-ttu-id="2e845-284">SDL 準拠の値を返します。</span><span class="sxs-lookup"><span data-stu-id="2e845-284">Returns the SDL-compliant value.</span></span> <span data-ttu-id="2e845-285">値の例:"nosniff"。</span><span class="sxs-lookup"><span data-stu-id="2e845-285">Example value: "nosniff".</span></span>| 
| <span data-ttu-id="2e845-286">日付</span><span class="sxs-lookup"><span data-stu-id="2e845-286">Date</span></span>| <span data-ttu-id="2e845-287">string</span><span class="sxs-lookup"><span data-stu-id="2e845-287">string</span></span>| <span data-ttu-id="2e845-288">日付/時刻、メッセージが送信されました。</span><span class="sxs-lookup"><span data-stu-id="2e845-288">The date/time the message was sent.</span></span> <span data-ttu-id="2e845-289">値の例:"(火)、17 年 2012年 11 月 10時 33分: 31 GMT」。</span><span class="sxs-lookup"><span data-stu-id="2e845-289">Example value: "Tue, 17 Nov 2012 10:33:31 GMT".</span></span>| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="2e845-290">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2e845-290">Optional Response Headers</span></span>
 
| <span data-ttu-id="2e845-291">Header</span><span class="sxs-lookup"><span data-stu-id="2e845-291">Header</span></span>| <span data-ttu-id="2e845-292">種類</span><span class="sxs-lookup"><span data-stu-id="2e845-292">Type</span></span>| <span data-ttu-id="2e845-293">説明</span><span class="sxs-lookup"><span data-stu-id="2e845-293">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2e845-294">再試行後</span><span class="sxs-lookup"><span data-stu-id="2e845-294">Retry-After</span></span>| <span data-ttu-id="2e845-295">string</span><span class="sxs-lookup"><span data-stu-id="2e845-295">string</span></span>| <span data-ttu-id="2e845-296">503 HTTP エラーで返されます。</span><span class="sxs-lookup"><span data-stu-id="2e845-296">Returned on 503 HTTP errors.</span></span> <span data-ttu-id="2e845-297">クライアント呼び出しを再試行する前に待機する時間に知ることができます。</span><span class="sxs-lookup"><span data-stu-id="2e845-297">Lets client know how long to wait before retrying the call.</span></span> <span data-ttu-id="2e845-298">値の例:"120".</span><span class="sxs-lookup"><span data-stu-id="2e845-298">Example values: "120".</span></span>| 
| <span data-ttu-id="2e845-299">Content-Length</span><span class="sxs-lookup"><span data-stu-id="2e845-299">Content-Length</span></span>| <span data-ttu-id="2e845-300">string</span><span class="sxs-lookup"><span data-stu-id="2e845-300">string</span></span>| <span data-ttu-id="2e845-301">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="2e845-301">Length of response body.</span></span> <span data-ttu-id="2e845-302">値の例:"527".</span><span class="sxs-lookup"><span data-stu-id="2e845-302">Example value: "527".</span></span>| 
| <span data-ttu-id="2e845-303">コンテンツ エンコーディング</span><span class="sxs-lookup"><span data-stu-id="2e845-303">Content-Encoding</span></span>| <span data-ttu-id="2e845-304">string</span><span class="sxs-lookup"><span data-stu-id="2e845-304">string</span></span>| <span data-ttu-id="2e845-305">応答のエンコードの種類。</span><span class="sxs-lookup"><span data-stu-id="2e845-305">Encoding type of the response.</span></span> <span data-ttu-id="2e845-306">値の例:"gzip"です。</span><span class="sxs-lookup"><span data-stu-id="2e845-306">Example value: "gzip".</span></span>| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="2e845-307">応答本文</span><span class="sxs-lookup"><span data-stu-id="2e845-307">Response body</span></span>
 
<span data-ttu-id="2e845-308">この API は、要求から Xuid ごとに 1 つ PresenceRecord オブジェクトの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="2e845-308">This API returns an array of PresenceRecord objects, one for each of the XUIDs from the request.</span></span>
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="2e845-309">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="2e845-309">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="2e845-310">関連項目</span><span class="sxs-lookup"><span data-stu-id="2e845-310">See also</span></span>
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2e845-311">Parent</span><span class="sxs-lookup"><span data-stu-id="2e845-311">Parent</span></span> 

[<span data-ttu-id="2e845-312">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="2e845-312">/users/xuid({xuid})/groups/{moniker}</span></span>](uri-usersxuidgroupsmoniker.md)

   