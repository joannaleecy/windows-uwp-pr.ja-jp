---
title: (ユーザー/xuid ({xuid})/groups/{モニカー}) を取得します。
assetID: 63aa7e5d-0599-5850-756d-3079c0772238
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerget.html
author: KevinAsgari
description: " (ユーザー/xuid ({xuid})/groups/{モニカー}) を取得します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 40f562c29e6860d7d566b96f34dfce8b9b438c7a
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882135"
---
# <a name="get-usersxuidxuidgroupsmoniker-"></a><span data-ttu-id="202a5-104">(ユーザー/xuid ({xuid})/groups/{モニカー}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="202a5-104">GET (/users/xuid({xuid})/groups/{moniker} )</span></span>
<span data-ttu-id="202a5-105">グループの presencerecord を要求してを取得します。</span><span class="sxs-lookup"><span data-stu-id="202a5-105">Gets the PresenceRecord for a group.</span></span> <span data-ttu-id="202a5-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="202a5-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="202a5-107">注釈</span><span class="sxs-lookup"><span data-stu-id="202a5-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="202a5-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="202a5-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="202a5-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="202a5-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="202a5-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="202a5-110">Authorization</span></span>](#ID4EKC)
  * [<span data-ttu-id="202a5-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="202a5-111">Effect of privacy settings on resource</span></span>](#ID4EQD)
  * [<span data-ttu-id="202a5-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-112">Required Request Headers</span></span>](#ID4EEH)
  * [<span data-ttu-id="202a5-113">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-113">Optional Request Headers</span></span>](#ID4EMBAC)
  * [<span data-ttu-id="202a5-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="202a5-114">Request body</span></span>](#ID4EMCAC)
  * [<span data-ttu-id="202a5-115">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="202a5-115">HTTP status codes</span></span>](#ID4EXCAC)
  * [<span data-ttu-id="202a5-116">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-116">Required Response Headers</span></span>](#ID4E3GAC)
  * [<span data-ttu-id="202a5-117">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-117">Optional Response Headers</span></span>](#ID4EMJAC)
  * [<span data-ttu-id="202a5-118">応答本文</span><span class="sxs-lookup"><span data-stu-id="202a5-118">Response body</span></span>](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="202a5-119">注釈</span><span class="sxs-lookup"><span data-stu-id="202a5-119">Remarks</span></span>
 
<span data-ttu-id="202a5-120">URI のユーザーに関連するモニカーによって指定されたグループ内のユーザーを取得し、それらのユーザーの presencerecord を要求してを返します。</span><span class="sxs-lookup"><span data-stu-id="202a5-120">Retrieves the users in the group specified by the moniker related to the user in the URI, and returns the PresenceRecord for those users.</span></span> <span data-ttu-id="202a5-121">プライバシーやコンテンツの分離で区切られているデータは単には返されません。</span><span class="sxs-lookup"><span data-stu-id="202a5-121">Data that is gated by Privacy or Content Isolation will simply not be returned.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="202a5-122">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="202a5-122">URI parameters</span></span>
 
| <span data-ttu-id="202a5-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="202a5-123">Parameter</span></span>| <span data-ttu-id="202a5-124">型</span><span class="sxs-lookup"><span data-stu-id="202a5-124">Type</span></span>| <span data-ttu-id="202a5-125">説明</span><span class="sxs-lookup"><span data-stu-id="202a5-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="202a5-126">xuid</span><span class="sxs-lookup"><span data-stu-id="202a5-126">xuid</span></span>| <span data-ttu-id="202a5-127">string</span><span class="sxs-lookup"><span data-stu-id="202a5-127">string</span></span>| <span data-ttu-id="202a5-128">Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連するのです。</span><span class="sxs-lookup"><span data-stu-id="202a5-128">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="202a5-129">モニカー</span><span class="sxs-lookup"><span data-stu-id="202a5-129">moniker</span></span>| <span data-ttu-id="202a5-130">string</span><span class="sxs-lookup"><span data-stu-id="202a5-130">string</span></span>| <span data-ttu-id="202a5-131">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="202a5-131">String defining the group of users.</span></span> <span data-ttu-id="202a5-132">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="202a5-132">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="202a5-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="202a5-133">Query string parameters</span></span>
 
| <span data-ttu-id="202a5-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="202a5-134">Parameter</span></span>| <span data-ttu-id="202a5-135">型</span><span class="sxs-lookup"><span data-stu-id="202a5-135">Type</span></span>| <span data-ttu-id="202a5-136">説明</span><span class="sxs-lookup"><span data-stu-id="202a5-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="202a5-137">level</span><span class="sxs-lookup"><span data-stu-id="202a5-137">level</span></span>| <span data-ttu-id="202a5-138">string</span><span class="sxs-lookup"><span data-stu-id="202a5-138">string</span></span>| <span data-ttu-id="202a5-139">このクエリ文字列で指定された詳細レベルを返します。</span><span class="sxs-lookup"><span data-stu-id="202a5-139">Returns the level of detail as specified by this query string.</span></span> <span data-ttu-id="202a5-140">有効なオプションには、「ユーザー」、「デバイス」、"title"、"all"が含まれます。「ユーザー」レベルは、DeviceRecord 入れ子になったオブジェクトがない presencerecord を要求してオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="202a5-140">Valid options include "user", "device", "title", and "all".The level "user" is the PresenceRecord object without the DeviceRecord nested object.</span></span> <span data-ttu-id="202a5-141">「デバイス」レベルでは、TitleRecord 入れ子になったオブジェクトがない presencerecord を要求してと DeviceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="202a5-141">The level "device" is the PresenceRecord and DeviceRecord objects without the TitleRecord nested object.</span></span> <span data-ttu-id="202a5-142">"Title"レベルでは、ActivityRecord 入れ子になったオブジェクトがない presencerecord を要求して、DeviceRecord、および TitleRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="202a5-142">The level "title" is the PresenceRecord, DeviceRecord, and TitleRecord objects without the ActivityRecord nested object.</span></span> <span data-ttu-id="202a5-143">"All"レベルでは、すべての入れ子になったオブジェクトを含むレコード全体です。このパラメーターが指定されていない場合、サービスのタイトルのレベルに既定値 (タイトルの詳細までは、このユーザーのプレゼンスを返す、)。</span><span class="sxs-lookup"><span data-stu-id="202a5-143">The level "all" is the entire record, including all nested objects.If this parameter is not provided, the service defaults to the title level (that is, it returns presence for this user down to the details of title).</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a><span data-ttu-id="202a5-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="202a5-144">Authorization</span></span>
 
<span data-ttu-id="202a5-145">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="202a5-145">Authorization claims used</span></span> | <span data-ttu-id="202a5-146">要求</span><span class="sxs-lookup"><span data-stu-id="202a5-146">Claim</span></span>| <span data-ttu-id="202a5-147">種類</span><span class="sxs-lookup"><span data-stu-id="202a5-147">Type</span></span>| <span data-ttu-id="202a5-148">必須?</span><span class="sxs-lookup"><span data-stu-id="202a5-148">Required?</span></span>| <span data-ttu-id="202a5-149">値の例</span><span class="sxs-lookup"><span data-stu-id="202a5-149">Example value</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="202a5-150">Xuid</span><span class="sxs-lookup"><span data-stu-id="202a5-150">Xuid</span></span></b>| <span data-ttu-id="202a5-151">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="202a5-151">64-bit signed integer</span></span>| <span data-ttu-id="202a5-152">必須</span><span class="sxs-lookup"><span data-stu-id="202a5-152">yes</span></span>| <span data-ttu-id="202a5-153">1234567890</span><span class="sxs-lookup"><span data-stu-id="202a5-153">1234567890</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="202a5-154">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="202a5-154">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="202a5-155">サービスは常に返します 200 OK 要求自体が整形式である場合。</span><span class="sxs-lookup"><span data-stu-id="202a5-155">The service will always return 200 OK if the request itself is well-formed.</span></span> <span data-ttu-id="202a5-156">ただし、プライバシー チェックを渡さない場合、応答からの情報をフィルター処理がされます。</span><span class="sxs-lookup"><span data-stu-id="202a5-156">However, it will filter out information from the response when privacy checks do not pass.</span></span>
 
<span data-ttu-id="202a5-157">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="202a5-157">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="202a5-158">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="202a5-158">Requesting User</span></span>| <span data-ttu-id="202a5-159">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="202a5-159">Target User's Privacy Setting</span></span>| <span data-ttu-id="202a5-160">動作</span><span class="sxs-lookup"><span data-stu-id="202a5-160">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="202a5-161">me</span><span class="sxs-lookup"><span data-stu-id="202a5-161">me</span></span>| -| <span data-ttu-id="202a5-162">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="202a5-162">As described.</span></span>| 
| <span data-ttu-id="202a5-163">フレンド</span><span class="sxs-lookup"><span data-stu-id="202a5-163">friend</span></span>| <span data-ttu-id="202a5-164">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="202a5-164">everyone</span></span>| <span data-ttu-id="202a5-165">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="202a5-165">As described.</span></span>| 
| <span data-ttu-id="202a5-166">フレンド</span><span class="sxs-lookup"><span data-stu-id="202a5-166">friend</span></span>| <span data-ttu-id="202a5-167">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="202a5-167">friends only</span></span>| <span data-ttu-id="202a5-168">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="202a5-168">As described.</span></span>| 
| <span data-ttu-id="202a5-169">フレンド</span><span class="sxs-lookup"><span data-stu-id="202a5-169">friend</span></span>| <span data-ttu-id="202a5-170">ブロック</span><span class="sxs-lookup"><span data-stu-id="202a5-170">blocked</span></span>| <span data-ttu-id="202a5-171">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="202a5-171">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="202a5-172">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="202a5-172">non-friend user</span></span>| <span data-ttu-id="202a5-173">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="202a5-173">everyone</span></span>| <span data-ttu-id="202a5-174">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="202a5-174">As described.</span></span>| 
| <span data-ttu-id="202a5-175">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="202a5-175">non-friend user</span></span>| <span data-ttu-id="202a5-176">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="202a5-176">friends only</span></span>| <span data-ttu-id="202a5-177">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="202a5-177">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="202a5-178">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="202a5-178">non-friend user</span></span>| <span data-ttu-id="202a5-179">ブロック</span><span class="sxs-lookup"><span data-stu-id="202a5-179">blocked</span></span>| <span data-ttu-id="202a5-180">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="202a5-180">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="202a5-181">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="202a5-181">third-party site</span></span>| <span data-ttu-id="202a5-182">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="202a5-182">everyone</span></span>| <span data-ttu-id="202a5-183">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="202a5-183">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="202a5-184">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="202a5-184">third-party site</span></span>| <span data-ttu-id="202a5-185">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="202a5-185">friends only</span></span>| <span data-ttu-id="202a5-186">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="202a5-186">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="202a5-187">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="202a5-187">third-party site</span></span>| <span data-ttu-id="202a5-188">ブロック</span><span class="sxs-lookup"><span data-stu-id="202a5-188">blocked</span></span>| <span data-ttu-id="202a5-189">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="202a5-189">As described - the service will filter out data.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="202a5-190">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-190">Required Request Headers</span></span>
 
| <span data-ttu-id="202a5-191">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-191">Header</span></span>| <span data-ttu-id="202a5-192">型</span><span class="sxs-lookup"><span data-stu-id="202a5-192">Type</span></span>| <span data-ttu-id="202a5-193">説明</span><span class="sxs-lookup"><span data-stu-id="202a5-193">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="202a5-194">Authorization</span><span class="sxs-lookup"><span data-stu-id="202a5-194">Authorization</span></span>| <span data-ttu-id="202a5-195">string</span><span class="sxs-lookup"><span data-stu-id="202a5-195">string</span></span>| <span data-ttu-id="202a5-196">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="202a5-196">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="202a5-197">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="202a5-197">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="202a5-198">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="202a5-198">x-xbl-contract-version</span></span>| <span data-ttu-id="202a5-199">string</span><span class="sxs-lookup"><span data-stu-id="202a5-199">string</span></span>| <span data-ttu-id="202a5-200">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="202a5-200">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="202a5-201">要求はのみにルーティングすると、サービスの認証トークンを要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="202a5-201">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="202a5-202">値の例: 3、vnext します。</span><span class="sxs-lookup"><span data-stu-id="202a5-202">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="202a5-203">Accept</span><span class="sxs-lookup"><span data-stu-id="202a5-203">Accept</span></span>| <span data-ttu-id="202a5-204">string</span><span class="sxs-lookup"><span data-stu-id="202a5-204">string</span></span>| <span data-ttu-id="202a5-205">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="202a5-205">Content-Types that are acceptable.</span></span> <span data-ttu-id="202a5-206">1 つだけのプレゼンスがサポートは<b>アプリケーション/json</b>はも指定ヘッダーで。</span><span class="sxs-lookup"><span data-stu-id="202a5-206">The only one Presence supports is <b>application/json</b>, but it still must be specified in the header.</span></span>| 
| <span data-ttu-id="202a5-207">同意言語</span><span class="sxs-lookup"><span data-stu-id="202a5-207">Accept-Language</span></span>| <span data-ttu-id="202a5-208">string</span><span class="sxs-lookup"><span data-stu-id="202a5-208">string</span></span>| <span data-ttu-id="202a5-209">応答で文字列を許容できるロケールです。</span><span class="sxs-lookup"><span data-stu-id="202a5-209">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="202a5-210">値の例: EN-US にします。</span><span class="sxs-lookup"><span data-stu-id="202a5-210">Example value: en-US.</span></span>| 
| <span data-ttu-id="202a5-211">Host</span><span class="sxs-lookup"><span data-stu-id="202a5-211">Host</span></span>| <span data-ttu-id="202a5-212">string</span><span class="sxs-lookup"><span data-stu-id="202a5-212">string</span></span>| <span data-ttu-id="202a5-213">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="202a5-213">Domain name of the server.</span></span> <span data-ttu-id="202a5-214">値の例: userpresence.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="202a5-214">Example value: userpresence.xboxlive.com.</span></span>| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="202a5-215">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-215">Optional Request Headers</span></span>
 
| <span data-ttu-id="202a5-216">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-216">Header</span></span>| <span data-ttu-id="202a5-217">型</span><span class="sxs-lookup"><span data-stu-id="202a5-217">Type</span></span>| <span data-ttu-id="202a5-218">説明</span><span class="sxs-lookup"><span data-stu-id="202a5-218">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="202a5-219">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="202a5-219">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="202a5-220">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="202a5-220">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="202a5-221">要求はのみにルーティングすると、サービスの認証トークンを要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="202a5-221">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="202a5-222">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="202a5-222">Default value: 1.</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="202a5-223">要求本文</span><span class="sxs-lookup"><span data-stu-id="202a5-223">Request body</span></span>
 
<span data-ttu-id="202a5-224">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="202a5-224">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="202a5-225">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="202a5-225">HTTP status codes</span></span>
 
<span data-ttu-id="202a5-226">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="202a5-226">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="202a5-227">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="202a5-227">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="202a5-228">コード</span><span class="sxs-lookup"><span data-stu-id="202a5-228">Code</span></span>| <span data-ttu-id="202a5-229">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="202a5-229">Reason phrase</span></span>| <span data-ttu-id="202a5-230">説明</span><span class="sxs-lookup"><span data-stu-id="202a5-230">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="202a5-231">200</span><span class="sxs-lookup"><span data-stu-id="202a5-231">200</span></span>| <span data-ttu-id="202a5-232">OK</span><span class="sxs-lookup"><span data-stu-id="202a5-232">OK</span></span>| <span data-ttu-id="202a5-233">セッションが正常に取得されます。</span><span class="sxs-lookup"><span data-stu-id="202a5-233">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="202a5-234">400</span><span class="sxs-lookup"><span data-stu-id="202a5-234">400</span></span>| <span data-ttu-id="202a5-235">Bad Request</span><span class="sxs-lookup"><span data-stu-id="202a5-235">Bad Request</span></span>| <span data-ttu-id="202a5-236">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="202a5-236">Service could not understand malformed request.</span></span> <span data-ttu-id="202a5-237">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="202a5-237">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="202a5-238">401</span><span class="sxs-lookup"><span data-stu-id="202a5-238">401</span></span>| <span data-ttu-id="202a5-239">権限がありません</span><span class="sxs-lookup"><span data-stu-id="202a5-239">Unauthorized</span></span>| <span data-ttu-id="202a5-240">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="202a5-240">The request requires user authentication.</span></span>| 
| <span data-ttu-id="202a5-241">403</span><span class="sxs-lookup"><span data-stu-id="202a5-241">403</span></span>| <span data-ttu-id="202a5-242">Forbidden</span><span class="sxs-lookup"><span data-stu-id="202a5-242">Forbidden</span></span>| <span data-ttu-id="202a5-243">要求は、ユーザーまたはサービスは許可されません。</span><span class="sxs-lookup"><span data-stu-id="202a5-243">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="202a5-244">404</span><span class="sxs-lookup"><span data-stu-id="202a5-244">404</span></span>| <span data-ttu-id="202a5-245">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="202a5-245">Not Found</span></span>| <span data-ttu-id="202a5-246">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="202a5-246">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="202a5-247">405</span><span class="sxs-lookup"><span data-stu-id="202a5-247">405</span></span>| <span data-ttu-id="202a5-248">Method Not Allowed</span><span class="sxs-lookup"><span data-stu-id="202a5-248">Method Not Allowed</span></span>| <span data-ttu-id="202a5-249">HTTP メソッドは、サポートされていないコンテンツの種類で使用されました。</span><span class="sxs-lookup"><span data-stu-id="202a5-249">HTTP method was used on an unsupported content type.</span></span>| 
| <span data-ttu-id="202a5-250">406</span><span class="sxs-lookup"><span data-stu-id="202a5-250">406</span></span>| <span data-ttu-id="202a5-251">許容できません。</span><span class="sxs-lookup"><span data-stu-id="202a5-251">Not Acceptable</span></span>| <span data-ttu-id="202a5-252">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="202a5-252">Resource version is not supported.</span></span>| 
| <span data-ttu-id="202a5-253">500</span><span class="sxs-lookup"><span data-stu-id="202a5-253">500</span></span>| <span data-ttu-id="202a5-254">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="202a5-254">Request Timeout</span></span>| <span data-ttu-id="202a5-255">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="202a5-255">Service could not understand malformed request.</span></span> <span data-ttu-id="202a5-256">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="202a5-256">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="202a5-257">503</span><span class="sxs-lookup"><span data-stu-id="202a5-257">503</span></span>| <span data-ttu-id="202a5-258">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="202a5-258">Request Timeout</span></span>| <span data-ttu-id="202a5-259">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="202a5-259">Service could not understand malformed request.</span></span> <span data-ttu-id="202a5-260">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="202a5-260">Typically an invalid parameter.</span></span>| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="202a5-261">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-261">Required Response Headers</span></span>
 
| <span data-ttu-id="202a5-262">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-262">Header</span></span>| <span data-ttu-id="202a5-263">型</span><span class="sxs-lookup"><span data-stu-id="202a5-263">Type</span></span>| <span data-ttu-id="202a5-264">説明</span><span class="sxs-lookup"><span data-stu-id="202a5-264">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="202a5-265">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="202a5-265">x-xbl-contract-version</span></span>| <span data-ttu-id="202a5-266">string</span><span class="sxs-lookup"><span data-stu-id="202a5-266">string</span></span>| <span data-ttu-id="202a5-267">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="202a5-267">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="202a5-268">要求はのみにルーティングすると、サービスの認証トークンを要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="202a5-268">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="202a5-269">値の例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="202a5-269">Example values: 1, vnext.</span></span>| 
| <span data-ttu-id="202a5-270">Content-Type</span><span class="sxs-lookup"><span data-stu-id="202a5-270">Content-Type</span></span>| <span data-ttu-id="202a5-271">string</span><span class="sxs-lookup"><span data-stu-id="202a5-271">string</span></span>| <span data-ttu-id="202a5-272">要求の本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="202a5-272">The mime type of the body of the request.</span></span> <span data-ttu-id="202a5-273">値の例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="202a5-273">Example value: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="202a5-274">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="202a5-274">Cache-Control</span></span>| <span data-ttu-id="202a5-275">string</span><span class="sxs-lookup"><span data-stu-id="202a5-275">string</span></span>| <span data-ttu-id="202a5-276">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="202a5-276">Polite request to specify caching behavior.</span></span> <span data-ttu-id="202a5-277">値の例:「は」。</span><span class="sxs-lookup"><span data-stu-id="202a5-277">Example values: "no-cache".</span></span>| 
| <span data-ttu-id="202a5-278">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="202a5-278">X-XblCorrelationId</span></span>| <span data-ttu-id="202a5-279">string</span><span class="sxs-lookup"><span data-stu-id="202a5-279">string</span></span>| <span data-ttu-id="202a5-280">サーバーが返すし、クライアントで何が受信されたを関連付けるにサービスで生成された値。</span><span class="sxs-lookup"><span data-stu-id="202a5-280">Service-generated value to correlate what the server returns and what is received by the client.</span></span> <span data-ttu-id="202a5-281">値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"。</span><span class="sxs-lookup"><span data-stu-id="202a5-281">Example value: "4106d0bc-1cb3-47bd-83fd-57d041c6febe".</span></span>| 
| <span data-ttu-id="202a5-282">X コンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="202a5-282">X-Content-Type-Option</span></span>| <span data-ttu-id="202a5-283">string</span><span class="sxs-lookup"><span data-stu-id="202a5-283">string</span></span>| <span data-ttu-id="202a5-284">SDL に準拠した値を返します。</span><span class="sxs-lookup"><span data-stu-id="202a5-284">Returns the SDL-compliant value.</span></span> <span data-ttu-id="202a5-285">値の例:"nosniff"。</span><span class="sxs-lookup"><span data-stu-id="202a5-285">Example value: "nosniff".</span></span>| 
| <span data-ttu-id="202a5-286">Date</span><span class="sxs-lookup"><span data-stu-id="202a5-286">Date</span></span>| <span data-ttu-id="202a5-287">string</span><span class="sxs-lookup"><span data-stu-id="202a5-287">string</span></span>| <span data-ttu-id="202a5-288">メッセージが送信された日付/時刻。</span><span class="sxs-lookup"><span data-stu-id="202a5-288">The date/time the message was sent.</span></span> <span data-ttu-id="202a5-289">値の例:"火曜日、17 年 2012年 11 月 10時 33分: 31 GMT"。</span><span class="sxs-lookup"><span data-stu-id="202a5-289">Example value: "Tue, 17 Nov 2012 10:33:31 GMT".</span></span>| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="202a5-290">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-290">Optional Response Headers</span></span>
 
| <span data-ttu-id="202a5-291">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="202a5-291">Header</span></span>| <span data-ttu-id="202a5-292">型</span><span class="sxs-lookup"><span data-stu-id="202a5-292">Type</span></span>| <span data-ttu-id="202a5-293">説明</span><span class="sxs-lookup"><span data-stu-id="202a5-293">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="202a5-294">Retry-after</span><span class="sxs-lookup"><span data-stu-id="202a5-294">Retry-After</span></span>| <span data-ttu-id="202a5-295">string</span><span class="sxs-lookup"><span data-stu-id="202a5-295">string</span></span>| <span data-ttu-id="202a5-296">503 HTTP エラーに返されます。</span><span class="sxs-lookup"><span data-stu-id="202a5-296">Returned on 503 HTTP errors.</span></span> <span data-ttu-id="202a5-297">クライアントに呼び出しを再試行するまで待機する時間に知らせることができます。</span><span class="sxs-lookup"><span data-stu-id="202a5-297">Lets client know how long to wait before retrying the call.</span></span> <span data-ttu-id="202a5-298">値の例:「120」。</span><span class="sxs-lookup"><span data-stu-id="202a5-298">Example values: "120".</span></span>| 
| <span data-ttu-id="202a5-299">Content-Length</span><span class="sxs-lookup"><span data-stu-id="202a5-299">Content-Length</span></span>| <span data-ttu-id="202a5-300">string</span><span class="sxs-lookup"><span data-stu-id="202a5-300">string</span></span>| <span data-ttu-id="202a5-301">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="202a5-301">Length of response body.</span></span> <span data-ttu-id="202a5-302">値の例:「527」。</span><span class="sxs-lookup"><span data-stu-id="202a5-302">Example value: "527".</span></span>| 
| <span data-ttu-id="202a5-303">コンテンツ エンコード</span><span class="sxs-lookup"><span data-stu-id="202a5-303">Content-Encoding</span></span>| <span data-ttu-id="202a5-304">string</span><span class="sxs-lookup"><span data-stu-id="202a5-304">string</span></span>| <span data-ttu-id="202a5-305">応答の種類をエンコードします。</span><span class="sxs-lookup"><span data-stu-id="202a5-305">Encoding type of the response.</span></span> <span data-ttu-id="202a5-306">値の例:"gzip"。</span><span class="sxs-lookup"><span data-stu-id="202a5-306">Example value: "gzip".</span></span>| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="202a5-307">応答本文</span><span class="sxs-lookup"><span data-stu-id="202a5-307">Response body</span></span>
 
<span data-ttu-id="202a5-308">この API は、要求から Xuid ごとに 1 つ presencerecord を要求してオブジェクトの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="202a5-308">This API returns an array of PresenceRecord objects, one for each of the XUIDs from the request.</span></span>
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="202a5-309">応答の例</span><span class="sxs-lookup"><span data-stu-id="202a5-309">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="202a5-310">関連項目</span><span class="sxs-lookup"><span data-stu-id="202a5-310">See also</span></span>
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="202a5-311">Parent</span><span class="sxs-lookup"><span data-stu-id="202a5-311">Parent</span></span> 

[<span data-ttu-id="202a5-312">ユーザー/xuid ({xuid})/groups/{モニカー}</span><span class="sxs-lookup"><span data-stu-id="202a5-312">/users/xuid({xuid})/groups/{moniker}</span></span>](uri-usersxuidgroupsmoniker.md)

   