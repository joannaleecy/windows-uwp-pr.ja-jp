---
title: GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )
assetID: 8a3df075-ccdf-18f2-ab0c-275f25cc22e3
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcastingget.html
description: " GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fe9f0b880fb405b6374a1f7edb49f364def87bb7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640947"
---
# <a name="get-usersxuidxuidgroupsmonikerbroadcasting-"></a><span data-ttu-id="e2e11-104">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span><span class="sxs-lookup"><span data-stu-id="e2e11-104">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span></span>
<span data-ttu-id="e2e11-105">URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンスのレコードを取得します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-105">Retrieves the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="e2e11-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e2e11-107">注釈</span><span class="sxs-lookup"><span data-stu-id="e2e11-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="e2e11-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e2e11-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="e2e11-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e2e11-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="e2e11-110">承認</span><span class="sxs-lookup"><span data-stu-id="e2e11-110">Authorization</span></span>](#ID4EKC)
  * [<span data-ttu-id="e2e11-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="e2e11-111">Effect of privacy settings on resource</span></span>](#ID4EQD)
  * [<span data-ttu-id="e2e11-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e2e11-112">Required Request Headers</span></span>](#ID4EEH)
  * [<span data-ttu-id="e2e11-113">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e2e11-113">Optional Request Headers</span></span>](#ID4EMBAC)
  * [<span data-ttu-id="e2e11-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="e2e11-114">Request body</span></span>](#ID4EMCAC)
  * [<span data-ttu-id="e2e11-115">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e2e11-115">HTTP status codes</span></span>](#ID4EXCAC)
  * [<span data-ttu-id="e2e11-116">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e2e11-116">Required Response Headers</span></span>](#ID4E3GAC)
  * [<span data-ttu-id="e2e11-117">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e2e11-117">Optional Response Headers</span></span>](#ID4EMJAC)
  * [<span data-ttu-id="e2e11-118">応答本文</span><span class="sxs-lookup"><span data-stu-id="e2e11-118">Response body</span></span>](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="e2e11-119">注釈</span><span class="sxs-lookup"><span data-stu-id="e2e11-119">Remarks</span></span>
 
<span data-ttu-id="e2e11-120">アクセス グループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンスのレコードに関連する XUID URI に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-120">Accesses the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e2e11-121">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e2e11-121">URI parameters</span></span>
 
| <span data-ttu-id="e2e11-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e2e11-122">Parameter</span></span>| <span data-ttu-id="e2e11-123">種類</span><span class="sxs-lookup"><span data-stu-id="e2e11-123">Type</span></span>| <span data-ttu-id="e2e11-124">説明</span><span class="sxs-lookup"><span data-stu-id="e2e11-124">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e2e11-125">xuid</span><span class="sxs-lookup"><span data-stu-id="e2e11-125">xuid</span></span>| <span data-ttu-id="e2e11-126">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-126">string</span></span>| <span data-ttu-id="e2e11-127">Xbox ユーザー ID (XUID) のグループで Xuid に関連するユーザーです。</span><span class="sxs-lookup"><span data-stu-id="e2e11-127">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="e2e11-128">モニカー</span><span class="sxs-lookup"><span data-stu-id="e2e11-128">moniker</span></span>| <span data-ttu-id="e2e11-129">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-129">string</span></span>| <span data-ttu-id="e2e11-130">ユーザーのグループを定義する文字列。</span><span class="sxs-lookup"><span data-stu-id="e2e11-130">String defining the group of users.</span></span> <span data-ttu-id="e2e11-131">現時点ではのみ受け入れられたモニカーでは、"People"が大文字の 'P' です。</span><span class="sxs-lookup"><span data-stu-id="e2e11-131">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="e2e11-132">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e2e11-132">Query string parameters</span></span>
 
| <span data-ttu-id="e2e11-133">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e2e11-133">Parameter</span></span>| <span data-ttu-id="e2e11-134">種類</span><span class="sxs-lookup"><span data-stu-id="e2e11-134">Type</span></span>| <span data-ttu-id="e2e11-135">説明</span><span class="sxs-lookup"><span data-stu-id="e2e11-135">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e2e11-136">level</span><span class="sxs-lookup"><span data-stu-id="e2e11-136">level</span></span>| <span data-ttu-id="e2e11-137">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-137">string</span></span>| <span data-ttu-id="e2e11-138">このクエリ文字列で指定された詳細情報のレベルを返します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-138">Returns the level of detail as specified by this query string.</span></span> <span data-ttu-id="e2e11-139">有効なオプションには、"user"、"device"、"title"および「すべて」が含まれます。"User"、レベルは、DeviceRecord 入れ子になったオブジェクトがない PresenceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="e2e11-139">Valid options include "user", "device", "title", and "all".The level "user" is the PresenceRecord object without the DeviceRecord nested object.</span></span> <span data-ttu-id="e2e11-140">「デバイス」のレベルは、TitleRecord 入れ子になったオブジェクトがない PresenceRecord と DeviceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="e2e11-140">The level "device" is the PresenceRecord and DeviceRecord objects without the TitleRecord nested object.</span></span> <span data-ttu-id="e2e11-141">"Title"、レベルは、ActivityRecord 入れ子になったオブジェクトがない PresenceRecord、DeviceRecord、TitleRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="e2e11-141">The level "title" is the PresenceRecord, DeviceRecord, and TitleRecord objects without the ActivityRecord nested object.</span></span> <span data-ttu-id="e2e11-142">「すべて」のレベルは、入れ子になったすべてのオブジェクトを含む、全体のレコードです。このパラメーターが指定されていない場合、サービスのタイトルのレベルに既定値 (タイトルの詳細には、このユーザーのプレゼンスを返します、)。</span><span class="sxs-lookup"><span data-stu-id="e2e11-142">The level "all" is the entire record, including all nested objects.If this parameter is not provided, the service defaults to the title level (that is, it returns presence for this user down to the details of title).</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a><span data-ttu-id="e2e11-143">Authorization</span><span class="sxs-lookup"><span data-stu-id="e2e11-143">Authorization</span></span>
 
<span data-ttu-id="e2e11-144">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="e2e11-144">Authorization claims used</span></span> | <span data-ttu-id="e2e11-145">要求</span><span class="sxs-lookup"><span data-stu-id="e2e11-145">Claim</span></span>| <span data-ttu-id="e2e11-146">種類</span><span class="sxs-lookup"><span data-stu-id="e2e11-146">Type</span></span>| <span data-ttu-id="e2e11-147">必須?</span><span class="sxs-lookup"><span data-stu-id="e2e11-147">Required?</span></span>| <span data-ttu-id="e2e11-148">値の例</span><span class="sxs-lookup"><span data-stu-id="e2e11-148">Example value</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e2e11-149"><b>xuid</b></span><span class="sxs-lookup"><span data-stu-id="e2e11-149"><b>Xuid</b></span></span>| <span data-ttu-id="e2e11-150">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="e2e11-150">64-bit signed integer</span></span>| <span data-ttu-id="e2e11-151">○</span><span class="sxs-lookup"><span data-stu-id="e2e11-151">yes</span></span>| <span data-ttu-id="e2e11-152">1234567890</span><span class="sxs-lookup"><span data-stu-id="e2e11-152">1234567890</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="e2e11-153">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="e2e11-153">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="e2e11-154">サービスは常に返します 200 OK 要求自体が正しく構成されている場合。</span><span class="sxs-lookup"><span data-stu-id="e2e11-154">The service will always return 200 OK if the request itself is well-formed.</span></span> <span data-ttu-id="e2e11-155">ただし、プライバシーに関するチェックが適合しない場合に、応答からの情報をフィルター処理には。</span><span class="sxs-lookup"><span data-stu-id="e2e11-155">However, it will filter out information from the response when privacy checks do not pass.</span></span>
 
<span data-ttu-id="e2e11-156">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="e2e11-156">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="e2e11-157">要求元のユーザー</span><span class="sxs-lookup"><span data-stu-id="e2e11-157">Requesting User</span></span>| <span data-ttu-id="e2e11-158">ターゲット ユーザーのプライバシーの設定</span><span class="sxs-lookup"><span data-stu-id="e2e11-158">Target User's Privacy Setting</span></span>| <span data-ttu-id="e2e11-159">動作</span><span class="sxs-lookup"><span data-stu-id="e2e11-159">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e2e11-160">Me</span><span class="sxs-lookup"><span data-stu-id="e2e11-160">me</span></span>| -| <span data-ttu-id="e2e11-161">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="e2e11-161">As described.</span></span>| 
| <span data-ttu-id="e2e11-162">friend</span><span class="sxs-lookup"><span data-stu-id="e2e11-162">friend</span></span>| <span data-ttu-id="e2e11-163">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="e2e11-163">everyone</span></span>| <span data-ttu-id="e2e11-164">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="e2e11-164">As described.</span></span>| 
| <span data-ttu-id="e2e11-165">friend</span><span class="sxs-lookup"><span data-stu-id="e2e11-165">friend</span></span>| <span data-ttu-id="e2e11-166">友達のみ</span><span class="sxs-lookup"><span data-stu-id="e2e11-166">friends only</span></span>| <span data-ttu-id="e2e11-167">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="e2e11-167">As described.</span></span>| 
| <span data-ttu-id="e2e11-168">friend</span><span class="sxs-lookup"><span data-stu-id="e2e11-168">friend</span></span>| <span data-ttu-id="e2e11-169">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="e2e11-169">blocked</span></span>| <span data-ttu-id="e2e11-170">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-170">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="e2e11-171">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="e2e11-171">non-friend user</span></span>| <span data-ttu-id="e2e11-172">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="e2e11-172">everyone</span></span>| <span data-ttu-id="e2e11-173">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="e2e11-173">As described.</span></span>| 
| <span data-ttu-id="e2e11-174">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="e2e11-174">non-friend user</span></span>| <span data-ttu-id="e2e11-175">友達のみ</span><span class="sxs-lookup"><span data-stu-id="e2e11-175">friends only</span></span>| <span data-ttu-id="e2e11-176">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-176">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="e2e11-177">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="e2e11-177">non-friend user</span></span>| <span data-ttu-id="e2e11-178">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="e2e11-178">blocked</span></span>| <span data-ttu-id="e2e11-179">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-179">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="e2e11-180">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="e2e11-180">third-party site</span></span>| <span data-ttu-id="e2e11-181">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="e2e11-181">everyone</span></span>| <span data-ttu-id="e2e11-182">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-182">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="e2e11-183">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="e2e11-183">third-party site</span></span>| <span data-ttu-id="e2e11-184">友達のみ</span><span class="sxs-lookup"><span data-stu-id="e2e11-184">friends only</span></span>| <span data-ttu-id="e2e11-185">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-185">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="e2e11-186">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="e2e11-186">third-party site</span></span>| <span data-ttu-id="e2e11-187">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="e2e11-187">blocked</span></span>| <span data-ttu-id="e2e11-188">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-188">As described - the service will filter out data.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="e2e11-189">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e2e11-189">Required Request Headers</span></span>
 
| <span data-ttu-id="e2e11-190">Header</span><span class="sxs-lookup"><span data-stu-id="e2e11-190">Header</span></span>| <span data-ttu-id="e2e11-191">種類</span><span class="sxs-lookup"><span data-stu-id="e2e11-191">Type</span></span>| <span data-ttu-id="e2e11-192">説明</span><span class="sxs-lookup"><span data-stu-id="e2e11-192">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e2e11-193">Authorization</span><span class="sxs-lookup"><span data-stu-id="e2e11-193">Authorization</span></span>| <span data-ttu-id="e2e11-194">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-194">string</span></span>| <span data-ttu-id="e2e11-195">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-195">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="e2e11-196">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="e2e11-196">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="e2e11-197">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="e2e11-197">x-xbl-contract-version</span></span>| <span data-ttu-id="e2e11-198">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-198">string</span></span>| <span data-ttu-id="e2e11-199">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="e2e11-199">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="e2e11-200">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="e2e11-200">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="e2e11-201">値の例:3、vnext。</span><span class="sxs-lookup"><span data-stu-id="e2e11-201">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="e2e11-202">OK</span><span class="sxs-lookup"><span data-stu-id="e2e11-202">Accept</span></span>| <span data-ttu-id="e2e11-203">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-203">string</span></span>| <span data-ttu-id="e2e11-204">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-204">Content-Types that are acceptable.</span></span> <span data-ttu-id="e2e11-205">1 つだけの存在がサポートされますが<b>、application/json</b>が、まだ必要がありますに指定するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="e2e11-205">The only one Presence supports is <b>application/json</b>, but it still must be specified in the header.</span></span>| 
| <span data-ttu-id="e2e11-206">Accept Language</span><span class="sxs-lookup"><span data-stu-id="e2e11-206">Accept-Language</span></span>| <span data-ttu-id="e2e11-207">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-207">string</span></span>| <span data-ttu-id="e2e11-208">応答内の文字列に対して許容されるロケール。</span><span class="sxs-lookup"><span data-stu-id="e2e11-208">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="e2e11-209">値の例: en-us (英語)。</span><span class="sxs-lookup"><span data-stu-id="e2e11-209">Example value: en-US.</span></span>| 
| <span data-ttu-id="e2e11-210">Host</span><span class="sxs-lookup"><span data-stu-id="e2e11-210">Host</span></span>| <span data-ttu-id="e2e11-211">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-211">string</span></span>| <span data-ttu-id="e2e11-212">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="e2e11-212">Domain name of the server.</span></span> <span data-ttu-id="e2e11-213">値の例: userpresence.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-213">Example value: userpresence.xboxlive.com.</span></span>| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="e2e11-214">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e2e11-214">Optional Request Headers</span></span>
 
| <span data-ttu-id="e2e11-215">Header</span><span class="sxs-lookup"><span data-stu-id="e2e11-215">Header</span></span>| <span data-ttu-id="e2e11-216">種類</span><span class="sxs-lookup"><span data-stu-id="e2e11-216">Type</span></span>| <span data-ttu-id="e2e11-217">説明</span><span class="sxs-lookup"><span data-stu-id="e2e11-217">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e2e11-218">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="e2e11-218">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="e2e11-219">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="e2e11-219">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="e2e11-220">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="e2e11-220">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="e2e11-221">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="e2e11-221">Default value: 1.</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="e2e11-222">要求本文</span><span class="sxs-lookup"><span data-stu-id="e2e11-222">Request body</span></span>
 
<span data-ttu-id="e2e11-223">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e2e11-223">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="e2e11-224">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e2e11-224">HTTP status codes</span></span>
 
<span data-ttu-id="e2e11-225">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-225">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="e2e11-226">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-226">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="e2e11-227">コード</span><span class="sxs-lookup"><span data-stu-id="e2e11-227">Code</span></span>| <span data-ttu-id="e2e11-228">理由語句</span><span class="sxs-lookup"><span data-stu-id="e2e11-228">Reason phrase</span></span>| <span data-ttu-id="e2e11-229">説明</span><span class="sxs-lookup"><span data-stu-id="e2e11-229">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e2e11-230">200</span><span class="sxs-lookup"><span data-stu-id="e2e11-230">200</span></span>| <span data-ttu-id="e2e11-231">OK</span><span class="sxs-lookup"><span data-stu-id="e2e11-231">OK</span></span>| <span data-ttu-id="e2e11-232">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-232">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="e2e11-233">400</span><span class="sxs-lookup"><span data-stu-id="e2e11-233">400</span></span>| <span data-ttu-id="e2e11-234">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="e2e11-234">Bad Request</span></span>| <span data-ttu-id="e2e11-235">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="e2e11-235">Service could not understand malformed request.</span></span> <span data-ttu-id="e2e11-236">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="e2e11-236">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="e2e11-237">401</span><span class="sxs-lookup"><span data-stu-id="e2e11-237">401</span></span>| <span data-ttu-id="e2e11-238">権限がありません</span><span class="sxs-lookup"><span data-stu-id="e2e11-238">Unauthorized</span></span>| <span data-ttu-id="e2e11-239">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="e2e11-239">The request requires user authentication.</span></span>| 
| <span data-ttu-id="e2e11-240">403</span><span class="sxs-lookup"><span data-stu-id="e2e11-240">403</span></span>| <span data-ttu-id="e2e11-241">Forbidden</span><span class="sxs-lookup"><span data-stu-id="e2e11-241">Forbidden</span></span>| <span data-ttu-id="e2e11-242">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="e2e11-242">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="e2e11-243">404</span><span class="sxs-lookup"><span data-stu-id="e2e11-243">404</span></span>| <span data-ttu-id="e2e11-244">検出不可</span><span class="sxs-lookup"><span data-stu-id="e2e11-244">Not Found</span></span>| <span data-ttu-id="e2e11-245">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="e2e11-245">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="e2e11-246">405</span><span class="sxs-lookup"><span data-stu-id="e2e11-246">405</span></span>| <span data-ttu-id="e2e11-247">許可されていないメソッド</span><span class="sxs-lookup"><span data-stu-id="e2e11-247">Method Not Allowed</span></span>| <span data-ttu-id="e2e11-248">HTTP メソッドは、サポートされていないコンテンツの種類で使用されました。</span><span class="sxs-lookup"><span data-stu-id="e2e11-248">HTTP method was used on an unsupported content type.</span></span>| 
| <span data-ttu-id="e2e11-249">406</span><span class="sxs-lookup"><span data-stu-id="e2e11-249">406</span></span>| <span data-ttu-id="e2e11-250">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="e2e11-250">Not Acceptable</span></span>| <span data-ttu-id="e2e11-251">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e2e11-251">Resource version is not supported.</span></span>| 
| <span data-ttu-id="e2e11-252">500</span><span class="sxs-lookup"><span data-stu-id="e2e11-252">500</span></span>| <span data-ttu-id="e2e11-253">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="e2e11-253">Request Timeout</span></span>| <span data-ttu-id="e2e11-254">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="e2e11-254">Service could not understand malformed request.</span></span> <span data-ttu-id="e2e11-255">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="e2e11-255">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="e2e11-256">503</span><span class="sxs-lookup"><span data-stu-id="e2e11-256">503</span></span>| <span data-ttu-id="e2e11-257">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="e2e11-257">Request Timeout</span></span>| <span data-ttu-id="e2e11-258">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="e2e11-258">Service could not understand malformed request.</span></span> <span data-ttu-id="e2e11-259">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="e2e11-259">Typically an invalid parameter.</span></span>| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="e2e11-260">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e2e11-260">Required Response Headers</span></span>
 
| <span data-ttu-id="e2e11-261">Header</span><span class="sxs-lookup"><span data-stu-id="e2e11-261">Header</span></span>| <span data-ttu-id="e2e11-262">種類</span><span class="sxs-lookup"><span data-stu-id="e2e11-262">Type</span></span>| <span data-ttu-id="e2e11-263">説明</span><span class="sxs-lookup"><span data-stu-id="e2e11-263">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e2e11-264">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="e2e11-264">x-xbl-contract-version</span></span>| <span data-ttu-id="e2e11-265">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-265">string</span></span>| <span data-ttu-id="e2e11-266">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="e2e11-266">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="e2e11-267">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="e2e11-267">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="e2e11-268">値の例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="e2e11-268">Example values: 1, vnext.</span></span>| 
| <span data-ttu-id="e2e11-269">Content-Type</span><span class="sxs-lookup"><span data-stu-id="e2e11-269">Content-Type</span></span>| <span data-ttu-id="e2e11-270">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-270">string</span></span>| <span data-ttu-id="e2e11-271">要求の本文の mime の種類。</span><span class="sxs-lookup"><span data-stu-id="e2e11-271">The mime type of the body of the request.</span></span> <span data-ttu-id="e2e11-272">値の例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-272">Example value: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="e2e11-273">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="e2e11-273">Cache-Control</span></span>| <span data-ttu-id="e2e11-274">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-274">string</span></span>| <span data-ttu-id="e2e11-275">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="e2e11-275">Polite request to specify caching behavior.</span></span> <span data-ttu-id="e2e11-276">値の例:"no-cache"。</span><span class="sxs-lookup"><span data-stu-id="e2e11-276">Example values: "no-cache".</span></span>| 
| <span data-ttu-id="e2e11-277">X-XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="e2e11-277">X-XblCorrelationId</span></span>| <span data-ttu-id="e2e11-278">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-278">string</span></span>| <span data-ttu-id="e2e11-279">サーバーが返すし、クライアントによって受信されるを関連付けるためにサービスによって生成された値。</span><span class="sxs-lookup"><span data-stu-id="e2e11-279">Service-generated value to correlate what the server returns and what is received by the client.</span></span> <span data-ttu-id="e2e11-280">値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"。</span><span class="sxs-lookup"><span data-stu-id="e2e11-280">Example value: "4106d0bc-1cb3-47bd-83fd-57d041c6febe".</span></span>| 
| <span data-ttu-id="e2e11-281">X のコンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="e2e11-281">X-Content-Type-Option</span></span>| <span data-ttu-id="e2e11-282">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-282">string</span></span>| <span data-ttu-id="e2e11-283">SDL 準拠の値を返します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-283">Returns the SDL-compliant value.</span></span> <span data-ttu-id="e2e11-284">値の例:"nosniff"。</span><span class="sxs-lookup"><span data-stu-id="e2e11-284">Example value: "nosniff".</span></span>| 
| <span data-ttu-id="e2e11-285">日付</span><span class="sxs-lookup"><span data-stu-id="e2e11-285">Date</span></span>| <span data-ttu-id="e2e11-286">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-286">string</span></span>| <span data-ttu-id="e2e11-287">日付/時刻、メッセージが送信されました。</span><span class="sxs-lookup"><span data-stu-id="e2e11-287">The date/time the message was sent.</span></span> <span data-ttu-id="e2e11-288">値の例:"(火)、17 年 2012年 11 月 10時 33分: 31 GMT」。</span><span class="sxs-lookup"><span data-stu-id="e2e11-288">Example value: "Tue, 17 Nov 2012 10:33:31 GMT".</span></span>| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="e2e11-289">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e2e11-289">Optional Response Headers</span></span>
 
| <span data-ttu-id="e2e11-290">Header</span><span class="sxs-lookup"><span data-stu-id="e2e11-290">Header</span></span>| <span data-ttu-id="e2e11-291">種類</span><span class="sxs-lookup"><span data-stu-id="e2e11-291">Type</span></span>| <span data-ttu-id="e2e11-292">説明</span><span class="sxs-lookup"><span data-stu-id="e2e11-292">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e2e11-293">再試行後</span><span class="sxs-lookup"><span data-stu-id="e2e11-293">Retry-After</span></span>| <span data-ttu-id="e2e11-294">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-294">string</span></span>| <span data-ttu-id="e2e11-295">503 HTTP エラーで返されます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-295">Returned on 503 HTTP errors.</span></span> <span data-ttu-id="e2e11-296">クライアント呼び出しを再試行する前に待機する時間に知ることができます。</span><span class="sxs-lookup"><span data-stu-id="e2e11-296">Lets client know how long to wait before retrying the call.</span></span> <span data-ttu-id="e2e11-297">値の例:"120".</span><span class="sxs-lookup"><span data-stu-id="e2e11-297">Example values: "120".</span></span>| 
| <span data-ttu-id="e2e11-298">Content-Length</span><span class="sxs-lookup"><span data-stu-id="e2e11-298">Content-Length</span></span>| <span data-ttu-id="e2e11-299">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-299">string</span></span>| <span data-ttu-id="e2e11-300">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="e2e11-300">Length of response body.</span></span> <span data-ttu-id="e2e11-301">値の例:"527".</span><span class="sxs-lookup"><span data-stu-id="e2e11-301">Example value: "527".</span></span>| 
| <span data-ttu-id="e2e11-302">コンテンツ エンコーディング</span><span class="sxs-lookup"><span data-stu-id="e2e11-302">Content-Encoding</span></span>| <span data-ttu-id="e2e11-303">string</span><span class="sxs-lookup"><span data-stu-id="e2e11-303">string</span></span>| <span data-ttu-id="e2e11-304">応答のエンコードの種類。</span><span class="sxs-lookup"><span data-stu-id="e2e11-304">Encoding type of the response.</span></span> <span data-ttu-id="e2e11-305">値の例:"gzip"です。</span><span class="sxs-lookup"><span data-stu-id="e2e11-305">Example value: "gzip".</span></span>| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="e2e11-306">応答本文</span><span class="sxs-lookup"><span data-stu-id="e2e11-306">Response body</span></span>
 
<span data-ttu-id="e2e11-307">この API は、URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンスのレコードを取得します。</span><span class="sxs-lookup"><span data-stu-id="e2e11-307">This API retrieves the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="e2e11-308">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="e2e11-308">Sample response</span></span>
 

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
                         name:"Halo 5",
                         lastModified:"2012-09-17T07:15:23.4930000",
                         placement:"full",
                         state:"active",
                         activity:
                         {
                             richPresence:"Playing on Valhalla",    
                             broadcast:
                            {
                                "id":"broadcast id from broadcasting service",
                                "session":"3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                                "provider":"Twitch",
                                "started":"2014-01-15T15:15:23.493Z",
                                "viewers":42
                           }
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
                         name:"Halo Waypoint",
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
                         name:"Halo Gamehelp",
                         state:"active",
                         timestamp:"2012-09-17T07:15:23.4930000",
                         activity:
                         {
                             richPresence:"Viewing warthog help"
                         }
                     }
                 ]
             }
         ]
     }
 ]

         
```

   
<a id="ID4EQLAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e2e11-309">関連項目</span><span class="sxs-lookup"><span data-stu-id="e2e11-309">See also</span></span>
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e2e11-310">Parent</span><span class="sxs-lookup"><span data-stu-id="e2e11-310">Parent</span></span> 

[<span data-ttu-id="e2e11-311">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="e2e11-311">/users/xuid({xuid})/groups/{moniker}</span></span>](uri-usersxuidgroupsmoniker.md)

   