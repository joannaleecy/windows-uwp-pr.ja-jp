---
title: GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )
assetID: 2b2df42e-9b39-3906-36e4-fd9ff22add04
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcastingcountget.html
description: " GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 219942838902381d7c9be91287056c422ea7957e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616817"
---
# <a name="get-usersxuidxuidgroupsmonikerbroadcastingcount-"></a><span data-ttu-id="cc766-104">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span><span class="sxs-lookup"><span data-stu-id="cc766-104">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span></span>
<span data-ttu-id="cc766-105">URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーの数を取得します。</span><span class="sxs-lookup"><span data-stu-id="cc766-105">Retrieves the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="cc766-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cc766-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="cc766-107">注釈</span><span class="sxs-lookup"><span data-stu-id="cc766-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="cc766-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cc766-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="cc766-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="cc766-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="cc766-110">承認</span><span class="sxs-lookup"><span data-stu-id="cc766-110">Authorization</span></span>](#ID4EKC)
  * [<span data-ttu-id="cc766-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="cc766-111">Effect of privacy settings on resource</span></span>](#ID4EQD)
  * [<span data-ttu-id="cc766-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cc766-112">Required Request Headers</span></span>](#ID4EEH)
  * [<span data-ttu-id="cc766-113">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cc766-113">Optional Request Headers</span></span>](#ID4EMBAC)
  * [<span data-ttu-id="cc766-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="cc766-114">Request body</span></span>](#ID4EMCAC)
  * [<span data-ttu-id="cc766-115">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="cc766-115">HTTP status codes</span></span>](#ID4EXCAC)
  * [<span data-ttu-id="cc766-116">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cc766-116">Required Response Headers</span></span>](#ID4E3GAC)
  * [<span data-ttu-id="cc766-117">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cc766-117">Optional Response Headers</span></span>](#ID4EMJAC)
  * [<span data-ttu-id="cc766-118">応答本文</span><span class="sxs-lookup"><span data-stu-id="cc766-118">Response body</span></span>](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="cc766-119">注釈</span><span class="sxs-lookup"><span data-stu-id="cc766-119">Remarks</span></span>
 
<span data-ttu-id="cc766-120">URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーの数を取得します。</span><span class="sxs-lookup"><span data-stu-id="cc766-120">Retrieves the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="cc766-121">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cc766-121">URI parameters</span></span>
 
| <span data-ttu-id="cc766-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cc766-122">Parameter</span></span>| <span data-ttu-id="cc766-123">種類</span><span class="sxs-lookup"><span data-stu-id="cc766-123">Type</span></span>| <span data-ttu-id="cc766-124">説明</span><span class="sxs-lookup"><span data-stu-id="cc766-124">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cc766-125">xuid</span><span class="sxs-lookup"><span data-stu-id="cc766-125">xuid</span></span>| <span data-ttu-id="cc766-126">string</span><span class="sxs-lookup"><span data-stu-id="cc766-126">string</span></span>| <span data-ttu-id="cc766-127">Xbox ユーザー ID (XUID) のグループで Xuid に関連するユーザーです。</span><span class="sxs-lookup"><span data-stu-id="cc766-127">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="cc766-128">モニカー</span><span class="sxs-lookup"><span data-stu-id="cc766-128">moniker</span></span>| <span data-ttu-id="cc766-129">string</span><span class="sxs-lookup"><span data-stu-id="cc766-129">string</span></span>| <span data-ttu-id="cc766-130">ユーザーのグループを定義する文字列。</span><span class="sxs-lookup"><span data-stu-id="cc766-130">String defining the group of users.</span></span> <span data-ttu-id="cc766-131">現時点ではのみ受け入れられたモニカーでは、"People"が大文字の 'P' です。</span><span class="sxs-lookup"><span data-stu-id="cc766-131">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="cc766-132">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="cc766-132">Query string parameters</span></span>
 
| <span data-ttu-id="cc766-133">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cc766-133">Parameter</span></span>| <span data-ttu-id="cc766-134">種類</span><span class="sxs-lookup"><span data-stu-id="cc766-134">Type</span></span>| <span data-ttu-id="cc766-135">説明</span><span class="sxs-lookup"><span data-stu-id="cc766-135">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cc766-136">level</span><span class="sxs-lookup"><span data-stu-id="cc766-136">level</span></span>| <span data-ttu-id="cc766-137">string</span><span class="sxs-lookup"><span data-stu-id="cc766-137">string</span></span>| <span data-ttu-id="cc766-138">このクエリ文字列で指定された詳細情報のレベルを返します。</span><span class="sxs-lookup"><span data-stu-id="cc766-138">Returns the level of detail as specified by this query string.</span></span> <span data-ttu-id="cc766-139">有効なオプションには、"user"、"device"、"title"および「すべて」が含まれます。"User"、レベルは、DeviceRecord 入れ子になったオブジェクトがない PresenceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="cc766-139">Valid options include "user", "device", "title", and "all".The level "user" is the PresenceRecord object without the DeviceRecord nested object.</span></span> <span data-ttu-id="cc766-140">「デバイス」のレベルは、TitleRecord 入れ子になったオブジェクトがない PresenceRecord と DeviceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="cc766-140">The level "device" is the PresenceRecord and DeviceRecord objects without the TitleRecord nested object.</span></span> <span data-ttu-id="cc766-141">"Title"、レベルは、ActivityRecord 入れ子になったオブジェクトがない PresenceRecord、DeviceRecord、TitleRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="cc766-141">The level "title" is the PresenceRecord, DeviceRecord, and TitleRecord objects without the ActivityRecord nested object.</span></span> <span data-ttu-id="cc766-142">「すべて」のレベルは、入れ子になったすべてのオブジェクトを含む、全体のレコードです。このパラメーターが指定されていない場合、サービスのタイトルのレベルに既定値 (タイトルの詳細には、このユーザーのプレゼンスを返します、)。</span><span class="sxs-lookup"><span data-stu-id="cc766-142">The level "all" is the entire record, including all nested objects.If this parameter is not provided, the service defaults to the title level (that is, it returns presence for this user down to the details of title).</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a><span data-ttu-id="cc766-143">Authorization</span><span class="sxs-lookup"><span data-stu-id="cc766-143">Authorization</span></span>
 
<span data-ttu-id="cc766-144">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="cc766-144">Authorization claims used</span></span> | <span data-ttu-id="cc766-145">要求</span><span class="sxs-lookup"><span data-stu-id="cc766-145">Claim</span></span>| <span data-ttu-id="cc766-146">種類</span><span class="sxs-lookup"><span data-stu-id="cc766-146">Type</span></span>| <span data-ttu-id="cc766-147">必須?</span><span class="sxs-lookup"><span data-stu-id="cc766-147">Required?</span></span>| <span data-ttu-id="cc766-148">値の例</span><span class="sxs-lookup"><span data-stu-id="cc766-148">Example value</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cc766-149"><b>xuid</b></span><span class="sxs-lookup"><span data-stu-id="cc766-149"><b>Xuid</b></span></span>| <span data-ttu-id="cc766-150">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="cc766-150">64-bit signed integer</span></span>| <span data-ttu-id="cc766-151">○</span><span class="sxs-lookup"><span data-stu-id="cc766-151">yes</span></span>| <span data-ttu-id="cc766-152">1234567890</span><span class="sxs-lookup"><span data-stu-id="cc766-152">1234567890</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="cc766-153">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="cc766-153">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="cc766-154">サービスは常に返します 200 OK 要求自体が正しく構成されている場合。</span><span class="sxs-lookup"><span data-stu-id="cc766-154">The service will always return 200 OK if the request itself is well-formed.</span></span> <span data-ttu-id="cc766-155">ただし、プライバシーに関するチェックが適合しない場合に、応答からの情報をフィルター処理には。</span><span class="sxs-lookup"><span data-stu-id="cc766-155">However, it will filter out information from the response when privacy checks do not pass.</span></span>
 
<span data-ttu-id="cc766-156">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="cc766-156">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="cc766-157">要求元のユーザー</span><span class="sxs-lookup"><span data-stu-id="cc766-157">Requesting User</span></span>| <span data-ttu-id="cc766-158">ターゲット ユーザーのプライバシーの設定</span><span class="sxs-lookup"><span data-stu-id="cc766-158">Target User's Privacy Setting</span></span>| <span data-ttu-id="cc766-159">動作</span><span class="sxs-lookup"><span data-stu-id="cc766-159">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cc766-160">Me</span><span class="sxs-lookup"><span data-stu-id="cc766-160">me</span></span>| -| <span data-ttu-id="cc766-161">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="cc766-161">As described.</span></span>| 
| <span data-ttu-id="cc766-162">friend</span><span class="sxs-lookup"><span data-stu-id="cc766-162">friend</span></span>| <span data-ttu-id="cc766-163">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="cc766-163">everyone</span></span>| <span data-ttu-id="cc766-164">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="cc766-164">As described.</span></span>| 
| <span data-ttu-id="cc766-165">friend</span><span class="sxs-lookup"><span data-stu-id="cc766-165">friend</span></span>| <span data-ttu-id="cc766-166">友達のみ</span><span class="sxs-lookup"><span data-stu-id="cc766-166">friends only</span></span>| <span data-ttu-id="cc766-167">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="cc766-167">As described.</span></span>| 
| <span data-ttu-id="cc766-168">friend</span><span class="sxs-lookup"><span data-stu-id="cc766-168">friend</span></span>| <span data-ttu-id="cc766-169">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="cc766-169">blocked</span></span>| <span data-ttu-id="cc766-170">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="cc766-170">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cc766-171">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="cc766-171">non-friend user</span></span>| <span data-ttu-id="cc766-172">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="cc766-172">everyone</span></span>| <span data-ttu-id="cc766-173">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="cc766-173">As described.</span></span>| 
| <span data-ttu-id="cc766-174">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="cc766-174">non-friend user</span></span>| <span data-ttu-id="cc766-175">友達のみ</span><span class="sxs-lookup"><span data-stu-id="cc766-175">friends only</span></span>| <span data-ttu-id="cc766-176">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="cc766-176">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cc766-177">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="cc766-177">non-friend user</span></span>| <span data-ttu-id="cc766-178">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="cc766-178">blocked</span></span>| <span data-ttu-id="cc766-179">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="cc766-179">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cc766-180">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="cc766-180">third-party site</span></span>| <span data-ttu-id="cc766-181">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="cc766-181">everyone</span></span>| <span data-ttu-id="cc766-182">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="cc766-182">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cc766-183">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="cc766-183">third-party site</span></span>| <span data-ttu-id="cc766-184">友達のみ</span><span class="sxs-lookup"><span data-stu-id="cc766-184">friends only</span></span>| <span data-ttu-id="cc766-185">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="cc766-185">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cc766-186">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="cc766-186">third-party site</span></span>| <span data-ttu-id="cc766-187">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="cc766-187">blocked</span></span>| <span data-ttu-id="cc766-188">-の説明に従ってそのサービスと、データが除外されます。</span><span class="sxs-lookup"><span data-stu-id="cc766-188">As described - the service will filter out data.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="cc766-189">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cc766-189">Required Request Headers</span></span>
 
| <span data-ttu-id="cc766-190">Header</span><span class="sxs-lookup"><span data-stu-id="cc766-190">Header</span></span>| <span data-ttu-id="cc766-191">種類</span><span class="sxs-lookup"><span data-stu-id="cc766-191">Type</span></span>| <span data-ttu-id="cc766-192">説明</span><span class="sxs-lookup"><span data-stu-id="cc766-192">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cc766-193">Authorization</span><span class="sxs-lookup"><span data-stu-id="cc766-193">Authorization</span></span>| <span data-ttu-id="cc766-194">string</span><span class="sxs-lookup"><span data-stu-id="cc766-194">string</span></span>| <span data-ttu-id="cc766-195">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="cc766-195">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="cc766-196">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="cc766-196">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="cc766-197">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="cc766-197">x-xbl-contract-version</span></span>| <span data-ttu-id="cc766-198">string</span><span class="sxs-lookup"><span data-stu-id="cc766-198">string</span></span>| <span data-ttu-id="cc766-199">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="cc766-199">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="cc766-200">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="cc766-200">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="cc766-201">値の例:3、vnext。</span><span class="sxs-lookup"><span data-stu-id="cc766-201">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="cc766-202">OK</span><span class="sxs-lookup"><span data-stu-id="cc766-202">Accept</span></span>| <span data-ttu-id="cc766-203">string</span><span class="sxs-lookup"><span data-stu-id="cc766-203">string</span></span>| <span data-ttu-id="cc766-204">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="cc766-204">Content-Types that are acceptable.</span></span> <span data-ttu-id="cc766-205">1 つだけの存在がサポートされますが<b>、application/json</b>が、まだ必要がありますに指定するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="cc766-205">The only one Presence supports is <b>application/json</b>, but it still must be specified in the header.</span></span>| 
| <span data-ttu-id="cc766-206">Accept Language</span><span class="sxs-lookup"><span data-stu-id="cc766-206">Accept-Language</span></span>| <span data-ttu-id="cc766-207">string</span><span class="sxs-lookup"><span data-stu-id="cc766-207">string</span></span>| <span data-ttu-id="cc766-208">応答内の文字列に対して許容されるロケール。</span><span class="sxs-lookup"><span data-stu-id="cc766-208">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="cc766-209">値の例: en-us (英語)。</span><span class="sxs-lookup"><span data-stu-id="cc766-209">Example value: en-US.</span></span>| 
| <span data-ttu-id="cc766-210">Host</span><span class="sxs-lookup"><span data-stu-id="cc766-210">Host</span></span>| <span data-ttu-id="cc766-211">string</span><span class="sxs-lookup"><span data-stu-id="cc766-211">string</span></span>| <span data-ttu-id="cc766-212">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="cc766-212">Domain name of the server.</span></span> <span data-ttu-id="cc766-213">値の例: userpresence.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="cc766-213">Example value: userpresence.xboxlive.com.</span></span>| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="cc766-214">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cc766-214">Optional Request Headers</span></span>
 
| <span data-ttu-id="cc766-215">Header</span><span class="sxs-lookup"><span data-stu-id="cc766-215">Header</span></span>| <span data-ttu-id="cc766-216">種類</span><span class="sxs-lookup"><span data-stu-id="cc766-216">Type</span></span>| <span data-ttu-id="cc766-217">説明</span><span class="sxs-lookup"><span data-stu-id="cc766-217">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cc766-218">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="cc766-218">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="cc766-219">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="cc766-219">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="cc766-220">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="cc766-220">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="cc766-221">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="cc766-221">Default value: 1.</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="cc766-222">要求本文</span><span class="sxs-lookup"><span data-stu-id="cc766-222">Request body</span></span>
 
<span data-ttu-id="cc766-223">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="cc766-223">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="cc766-224">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="cc766-224">HTTP status codes</span></span>
 
<span data-ttu-id="cc766-225">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="cc766-225">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="cc766-226">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="cc766-226">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="cc766-227">コード</span><span class="sxs-lookup"><span data-stu-id="cc766-227">Code</span></span>| <span data-ttu-id="cc766-228">理由語句</span><span class="sxs-lookup"><span data-stu-id="cc766-228">Reason phrase</span></span>| <span data-ttu-id="cc766-229">説明</span><span class="sxs-lookup"><span data-stu-id="cc766-229">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cc766-230">200</span><span class="sxs-lookup"><span data-stu-id="cc766-230">200</span></span>| <span data-ttu-id="cc766-231">OK</span><span class="sxs-lookup"><span data-stu-id="cc766-231">OK</span></span>| <span data-ttu-id="cc766-232">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="cc766-232">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="cc766-233">400</span><span class="sxs-lookup"><span data-stu-id="cc766-233">400</span></span>| <span data-ttu-id="cc766-234">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="cc766-234">Bad Request</span></span>| <span data-ttu-id="cc766-235">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="cc766-235">Service could not understand malformed request.</span></span> <span data-ttu-id="cc766-236">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="cc766-236">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="cc766-237">401</span><span class="sxs-lookup"><span data-stu-id="cc766-237">401</span></span>| <span data-ttu-id="cc766-238">権限がありません</span><span class="sxs-lookup"><span data-stu-id="cc766-238">Unauthorized</span></span>| <span data-ttu-id="cc766-239">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="cc766-239">The request requires user authentication.</span></span>| 
| <span data-ttu-id="cc766-240">403</span><span class="sxs-lookup"><span data-stu-id="cc766-240">403</span></span>| <span data-ttu-id="cc766-241">Forbidden</span><span class="sxs-lookup"><span data-stu-id="cc766-241">Forbidden</span></span>| <span data-ttu-id="cc766-242">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="cc766-242">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="cc766-243">404</span><span class="sxs-lookup"><span data-stu-id="cc766-243">404</span></span>| <span data-ttu-id="cc766-244">検出不可</span><span class="sxs-lookup"><span data-stu-id="cc766-244">Not Found</span></span>| <span data-ttu-id="cc766-245">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="cc766-245">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="cc766-246">405</span><span class="sxs-lookup"><span data-stu-id="cc766-246">405</span></span>| <span data-ttu-id="cc766-247">許可されていないメソッド</span><span class="sxs-lookup"><span data-stu-id="cc766-247">Method Not Allowed</span></span>| <span data-ttu-id="cc766-248">HTTP メソッドは、サポートされていないコンテンツの種類で使用されました。</span><span class="sxs-lookup"><span data-stu-id="cc766-248">HTTP method was used on an unsupported content type.</span></span>| 
| <span data-ttu-id="cc766-249">406</span><span class="sxs-lookup"><span data-stu-id="cc766-249">406</span></span>| <span data-ttu-id="cc766-250">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="cc766-250">Not Acceptable</span></span>| <span data-ttu-id="cc766-251">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="cc766-251">Resource version is not supported.</span></span>| 
| <span data-ttu-id="cc766-252">500</span><span class="sxs-lookup"><span data-stu-id="cc766-252">500</span></span>| <span data-ttu-id="cc766-253">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="cc766-253">Request Timeout</span></span>| <span data-ttu-id="cc766-254">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="cc766-254">Service could not understand malformed request.</span></span> <span data-ttu-id="cc766-255">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="cc766-255">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="cc766-256">503</span><span class="sxs-lookup"><span data-stu-id="cc766-256">503</span></span>| <span data-ttu-id="cc766-257">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="cc766-257">Request Timeout</span></span>| <span data-ttu-id="cc766-258">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="cc766-258">Service could not understand malformed request.</span></span> <span data-ttu-id="cc766-259">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="cc766-259">Typically an invalid parameter.</span></span>| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="cc766-260">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cc766-260">Required Response Headers</span></span>
 
| <span data-ttu-id="cc766-261">Header</span><span class="sxs-lookup"><span data-stu-id="cc766-261">Header</span></span>| <span data-ttu-id="cc766-262">種類</span><span class="sxs-lookup"><span data-stu-id="cc766-262">Type</span></span>| <span data-ttu-id="cc766-263">説明</span><span class="sxs-lookup"><span data-stu-id="cc766-263">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cc766-264">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="cc766-264">x-xbl-contract-version</span></span>| <span data-ttu-id="cc766-265">string</span><span class="sxs-lookup"><span data-stu-id="cc766-265">string</span></span>| <span data-ttu-id="cc766-266">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="cc766-266">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="cc766-267">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="cc766-267">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="cc766-268">値の例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="cc766-268">Example values: 1, vnext.</span></span>| 
| <span data-ttu-id="cc766-269">Content-Type</span><span class="sxs-lookup"><span data-stu-id="cc766-269">Content-Type</span></span>| <span data-ttu-id="cc766-270">string</span><span class="sxs-lookup"><span data-stu-id="cc766-270">string</span></span>| <span data-ttu-id="cc766-271">要求の本文の mime の種類。</span><span class="sxs-lookup"><span data-stu-id="cc766-271">The mime type of the body of the request.</span></span> <span data-ttu-id="cc766-272">値の例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="cc766-272">Example value: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="cc766-273">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="cc766-273">Cache-Control</span></span>| <span data-ttu-id="cc766-274">string</span><span class="sxs-lookup"><span data-stu-id="cc766-274">string</span></span>| <span data-ttu-id="cc766-275">キャッシュの動作を指定する正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="cc766-275">Polite request to specify caching behavior.</span></span> <span data-ttu-id="cc766-276">値の例:"no-cache"。</span><span class="sxs-lookup"><span data-stu-id="cc766-276">Example values: "no-cache".</span></span>| 
| <span data-ttu-id="cc766-277">X-XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="cc766-277">X-XblCorrelationId</span></span>| <span data-ttu-id="cc766-278">string</span><span class="sxs-lookup"><span data-stu-id="cc766-278">string</span></span>| <span data-ttu-id="cc766-279">サーバーが返すし、クライアントによって受信されるを関連付けるためにサービスによって生成された値。</span><span class="sxs-lookup"><span data-stu-id="cc766-279">Service-generated value to correlate what the server returns and what is received by the client.</span></span> <span data-ttu-id="cc766-280">値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"。</span><span class="sxs-lookup"><span data-stu-id="cc766-280">Example value: "4106d0bc-1cb3-47bd-83fd-57d041c6febe".</span></span>| 
| <span data-ttu-id="cc766-281">X のコンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="cc766-281">X-Content-Type-Option</span></span>| <span data-ttu-id="cc766-282">string</span><span class="sxs-lookup"><span data-stu-id="cc766-282">string</span></span>| <span data-ttu-id="cc766-283">SDL 準拠の値を返します。</span><span class="sxs-lookup"><span data-stu-id="cc766-283">Returns the SDL-compliant value.</span></span> <span data-ttu-id="cc766-284">値の例:"nosniff"。</span><span class="sxs-lookup"><span data-stu-id="cc766-284">Example value: "nosniff".</span></span>| 
| <span data-ttu-id="cc766-285">日付</span><span class="sxs-lookup"><span data-stu-id="cc766-285">Date</span></span>| <span data-ttu-id="cc766-286">string</span><span class="sxs-lookup"><span data-stu-id="cc766-286">string</span></span>| <span data-ttu-id="cc766-287">日付/時刻、メッセージが送信されました。</span><span class="sxs-lookup"><span data-stu-id="cc766-287">The date/time the message was sent.</span></span> <span data-ttu-id="cc766-288">値の例:"(火)、17 年 2012年 11 月 10時 33分: 31 GMT」。</span><span class="sxs-lookup"><span data-stu-id="cc766-288">Example value: "Tue, 17 Nov 2012 10:33:31 GMT".</span></span>| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="cc766-289">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cc766-289">Optional Response Headers</span></span>
 
| <span data-ttu-id="cc766-290">Header</span><span class="sxs-lookup"><span data-stu-id="cc766-290">Header</span></span>| <span data-ttu-id="cc766-291">種類</span><span class="sxs-lookup"><span data-stu-id="cc766-291">Type</span></span>| <span data-ttu-id="cc766-292">説明</span><span class="sxs-lookup"><span data-stu-id="cc766-292">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cc766-293">再試行後</span><span class="sxs-lookup"><span data-stu-id="cc766-293">Retry-After</span></span>| <span data-ttu-id="cc766-294">string</span><span class="sxs-lookup"><span data-stu-id="cc766-294">string</span></span>| <span data-ttu-id="cc766-295">503 HTTP エラーで返されます。</span><span class="sxs-lookup"><span data-stu-id="cc766-295">Returned on 503 HTTP errors.</span></span> <span data-ttu-id="cc766-296">クライアント呼び出しを再試行する前に待機する時間に知ることができます。</span><span class="sxs-lookup"><span data-stu-id="cc766-296">Lets client know how long to wait before retrying the call.</span></span> <span data-ttu-id="cc766-297">値の例:"120".</span><span class="sxs-lookup"><span data-stu-id="cc766-297">Example values: "120".</span></span>| 
| <span data-ttu-id="cc766-298">Content-Length</span><span class="sxs-lookup"><span data-stu-id="cc766-298">Content-Length</span></span>| <span data-ttu-id="cc766-299">string</span><span class="sxs-lookup"><span data-stu-id="cc766-299">string</span></span>| <span data-ttu-id="cc766-300">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="cc766-300">Length of response body.</span></span> <span data-ttu-id="cc766-301">値の例:"527".</span><span class="sxs-lookup"><span data-stu-id="cc766-301">Example value: "527".</span></span>| 
| <span data-ttu-id="cc766-302">コンテンツ エンコーディング</span><span class="sxs-lookup"><span data-stu-id="cc766-302">Content-Encoding</span></span>| <span data-ttu-id="cc766-303">string</span><span class="sxs-lookup"><span data-stu-id="cc766-303">string</span></span>| <span data-ttu-id="cc766-304">応答のエンコードの種類。</span><span class="sxs-lookup"><span data-stu-id="cc766-304">Encoding type of the response.</span></span> <span data-ttu-id="cc766-305">値の例:"gzip"です。</span><span class="sxs-lookup"><span data-stu-id="cc766-305">Example value: "gzip".</span></span>| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="cc766-306">応答本文</span><span class="sxs-lookup"><span data-stu-id="cc766-306">Response body</span></span>
 
<span data-ttu-id="cc766-307">この API は、ブロードキャスト、パラメーターの現在の数の数を返します。</span><span class="sxs-lookup"><span data-stu-id="cc766-307">This API returns a count of the current number of broadcasts given the parameters.</span></span>
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="cc766-308">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="cc766-308">Sample response</span></span>
 

```cpp
{
    "count":42
 }

         
```

   
<a id="ID4EQLAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="cc766-309">関連項目</span><span class="sxs-lookup"><span data-stu-id="cc766-309">See also</span></span>
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cc766-310">Parent</span><span class="sxs-lookup"><span data-stu-id="cc766-310">Parent</span></span> 

[<span data-ttu-id="cc766-311">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="cc766-311">/users/xuid({xuid})/groups/{moniker}</span></span>](uri-usersxuidgroupsmoniker.md)

   