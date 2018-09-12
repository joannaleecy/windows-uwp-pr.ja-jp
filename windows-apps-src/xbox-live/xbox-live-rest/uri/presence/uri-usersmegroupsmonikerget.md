---
title: 取得する (ユーザー/me/グループ/{モニカー})
assetID: c2527a08-411b-d4e4-422f-a8438804bfe6
permalink: en-us/docs/xboxlive/rest/uri-usersmegroupsmonikerget.html
author: KevinAsgari
description: " 取得する (ユーザー/me/グループ/{モニカー})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b308668dd24d72b57167a90d5eb297203c2e60c1
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881928"
---
# <a name="get-usersmegroupsmoniker-"></a><span data-ttu-id="cd413-104">取得する (ユーザー/me/グループ/{モニカー})</span><span class="sxs-lookup"><span data-stu-id="cd413-104">GET (/users/me/groups/{moniker} )</span></span>
<span data-ttu-id="cd413-105">[グループの presencerecord を要求してを取得します。</span><span class="sxs-lookup"><span data-stu-id="cd413-105">Gets the PresenceRecord for my group.</span></span> <span data-ttu-id="cd413-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cd413-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="cd413-107">注釈</span><span class="sxs-lookup"><span data-stu-id="cd413-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="cd413-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd413-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="cd413-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd413-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="cd413-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="cd413-110">Authorization</span></span>](#ID4EKC)
  * [<span data-ttu-id="cd413-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="cd413-111">Effect of privacy settings on resource</span></span>](#ID4EQD)
  * [<span data-ttu-id="cd413-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-112">Required Request Headers</span></span>](#ID4EEH)
  * [<span data-ttu-id="cd413-113">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-113">Optional Request Headers</span></span>](#ID4EMBAC)
  * [<span data-ttu-id="cd413-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="cd413-114">Request body</span></span>](#ID4EMCAC)
  * [<span data-ttu-id="cd413-115">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="cd413-115">HTTP status codes</span></span>](#ID4EXCAC)
  * [<span data-ttu-id="cd413-116">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-116">Required Response Headers</span></span>](#ID4E3GAC)
  * [<span data-ttu-id="cd413-117">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-117">Optional Response Headers</span></span>](#ID4EMJAC)
  * [<span data-ttu-id="cd413-118">応答本文</span><span class="sxs-lookup"><span data-stu-id="cd413-118">Response body</span></span>](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="cd413-119">注釈</span><span class="sxs-lookup"><span data-stu-id="cd413-119">Remarks</span></span>
 
<span data-ttu-id="cd413-120">ユーザーの要求に関連するモニカーによって指定されたグループ内のユーザーを取得し、それらのユーザーの presencerecord を要求してを返します。</span><span class="sxs-lookup"><span data-stu-id="cd413-120">Retrieves the users in the group specified by the moniker related to the user in the claims, and returns the PresenceRecord for those users.</span></span> <span data-ttu-id="cd413-121">プライバシーやコンテンツの分離で区切られているデータは単には返されません。</span><span class="sxs-lookup"><span data-stu-id="cd413-121">Data that is gated by Privacy or Content Isolation will simply not be returned.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="cd413-122">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd413-122">URI parameters</span></span>
 
| <span data-ttu-id="cd413-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd413-123">Parameter</span></span>| <span data-ttu-id="cd413-124">型</span><span class="sxs-lookup"><span data-stu-id="cd413-124">Type</span></span>| <span data-ttu-id="cd413-125">説明</span><span class="sxs-lookup"><span data-stu-id="cd413-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cd413-126">モニカー</span><span class="sxs-lookup"><span data-stu-id="cd413-126">moniker</span></span>| <span data-ttu-id="cd413-127">string</span><span class="sxs-lookup"><span data-stu-id="cd413-127">string</span></span>| <span data-ttu-id="cd413-128">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="cd413-128">String defining the group of users.</span></span> <span data-ttu-id="cd413-129">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="cd413-129">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="cd413-130">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd413-130">Query string parameters</span></span>
 
| <span data-ttu-id="cd413-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd413-131">Parameter</span></span>| <span data-ttu-id="cd413-132">型</span><span class="sxs-lookup"><span data-stu-id="cd413-132">Type</span></span>| <span data-ttu-id="cd413-133">説明</span><span class="sxs-lookup"><span data-stu-id="cd413-133">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd413-134">level</span><span class="sxs-lookup"><span data-stu-id="cd413-134">level</span></span>| <span data-ttu-id="cd413-135">string</span><span class="sxs-lookup"><span data-stu-id="cd413-135">string</span></span>| <span data-ttu-id="cd413-136">このクエリ文字列で指定された詳細レベルを返します。</span><span class="sxs-lookup"><span data-stu-id="cd413-136">Returns the level of detail as specified by this query string.</span></span> <span data-ttu-id="cd413-137">有効なオプションには、「ユーザー」、「デバイス」、"title"、"all"が含まれます。「ユーザー」レベルは、DeviceRecord 入れ子になったオブジェクトがない presencerecord を要求してオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="cd413-137">Valid options include "user", "device", "title", and "all".The level "user" is the PresenceRecord object without the DeviceRecord nested object.</span></span> <span data-ttu-id="cd413-138">「デバイス」レベルでは、TitleRecord 入れ子になったオブジェクトがない presencerecord を要求してと DeviceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="cd413-138">The level "device" is the PresenceRecord and DeviceRecord objects without the TitleRecord nested object.</span></span> <span data-ttu-id="cd413-139">"Title"レベルでは、ActivityRecord 入れ子になったオブジェクトがない presencerecord を要求して、DeviceRecord、および TitleRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="cd413-139">The level "title" is the PresenceRecord, DeviceRecord, and TitleRecord objects without the ActivityRecord nested object.</span></span> <span data-ttu-id="cd413-140">"All"レベルでは、すべての入れ子になったオブジェクトを含むレコード全体です。このパラメーターが指定されていない場合、サービスのタイトルのレベルに既定値 (タイトルの詳細までは、このユーザーのプレゼンスを返す、)。</span><span class="sxs-lookup"><span data-stu-id="cd413-140">The level "all" is the entire record, including all nested objects.If this parameter is not provided, the service defaults to the title level (that is, it returns presence for this user down to the details of title).</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a><span data-ttu-id="cd413-141">Authorization</span><span class="sxs-lookup"><span data-stu-id="cd413-141">Authorization</span></span>
 
<span data-ttu-id="cd413-142">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="cd413-142">Authorization claims used</span></span> | <span data-ttu-id="cd413-143">要求</span><span class="sxs-lookup"><span data-stu-id="cd413-143">Claim</span></span>| <span data-ttu-id="cd413-144">種類</span><span class="sxs-lookup"><span data-stu-id="cd413-144">Type</span></span>| <span data-ttu-id="cd413-145">必須?</span><span class="sxs-lookup"><span data-stu-id="cd413-145">Required?</span></span>| <span data-ttu-id="cd413-146">値の例</span><span class="sxs-lookup"><span data-stu-id="cd413-146">Example value</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="cd413-147">Xuid</span><span class="sxs-lookup"><span data-stu-id="cd413-147">Xuid</span></span></b>| <span data-ttu-id="cd413-148">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="cd413-148">64-bit signed integer</span></span>| <span data-ttu-id="cd413-149">必須</span><span class="sxs-lookup"><span data-stu-id="cd413-149">yes</span></span>| <span data-ttu-id="cd413-150">1234567890</span><span class="sxs-lookup"><span data-stu-id="cd413-150">1234567890</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="cd413-151">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="cd413-151">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="cd413-152">サービスは常に返します 200 OK 要求自体が整形式である場合。</span><span class="sxs-lookup"><span data-stu-id="cd413-152">The service will always return 200 OK if the request itself is well-formed.</span></span> <span data-ttu-id="cd413-153">ただし、プライバシー チェックを渡さない場合、応答からの情報をフィルター処理がされます。</span><span class="sxs-lookup"><span data-stu-id="cd413-153">However, it will filter out information from the response when privacy checks do not pass.</span></span>
 
<span data-ttu-id="cd413-154">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="cd413-154">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="cd413-155">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="cd413-155">Requesting User</span></span>| <span data-ttu-id="cd413-156">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="cd413-156">Target User's Privacy Setting</span></span>| <span data-ttu-id="cd413-157">動作</span><span class="sxs-lookup"><span data-stu-id="cd413-157">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd413-158">me</span><span class="sxs-lookup"><span data-stu-id="cd413-158">me</span></span>| -| <span data-ttu-id="cd413-159">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="cd413-159">As described.</span></span>| 
| <span data-ttu-id="cd413-160">フレンド</span><span class="sxs-lookup"><span data-stu-id="cd413-160">friend</span></span>| <span data-ttu-id="cd413-161">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="cd413-161">everyone</span></span>| <span data-ttu-id="cd413-162">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="cd413-162">As described.</span></span>| 
| <span data-ttu-id="cd413-163">フレンド</span><span class="sxs-lookup"><span data-stu-id="cd413-163">friend</span></span>| <span data-ttu-id="cd413-164">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="cd413-164">friends only</span></span>| <span data-ttu-id="cd413-165">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="cd413-165">As described.</span></span>| 
| <span data-ttu-id="cd413-166">フレンド</span><span class="sxs-lookup"><span data-stu-id="cd413-166">friend</span></span>| <span data-ttu-id="cd413-167">ブロック</span><span class="sxs-lookup"><span data-stu-id="cd413-167">blocked</span></span>| <span data-ttu-id="cd413-168">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="cd413-168">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cd413-169">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="cd413-169">non-friend user</span></span>| <span data-ttu-id="cd413-170">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="cd413-170">everyone</span></span>| <span data-ttu-id="cd413-171">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="cd413-171">As described.</span></span>| 
| <span data-ttu-id="cd413-172">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="cd413-172">non-friend user</span></span>| <span data-ttu-id="cd413-173">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="cd413-173">friends only</span></span>| <span data-ttu-id="cd413-174">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="cd413-174">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cd413-175">ユーザーのフレンドではないです。</span><span class="sxs-lookup"><span data-stu-id="cd413-175">non-friend user</span></span>| <span data-ttu-id="cd413-176">ブロック</span><span class="sxs-lookup"><span data-stu-id="cd413-176">blocked</span></span>| <span data-ttu-id="cd413-177">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="cd413-177">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cd413-178">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="cd413-178">third-party site</span></span>| <span data-ttu-id="cd413-179">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="cd413-179">everyone</span></span>| <span data-ttu-id="cd413-180">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="cd413-180">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cd413-181">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="cd413-181">third-party site</span></span>| <span data-ttu-id="cd413-182">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="cd413-182">friends only</span></span>| <span data-ttu-id="cd413-183">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="cd413-183">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="cd413-184">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="cd413-184">third-party site</span></span>| <span data-ttu-id="cd413-185">ブロック</span><span class="sxs-lookup"><span data-stu-id="cd413-185">blocked</span></span>| <span data-ttu-id="cd413-186">ように、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="cd413-186">As described - the service will filter out data.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="cd413-187">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-187">Required Request Headers</span></span>
 
| <span data-ttu-id="cd413-188">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-188">Header</span></span>| <span data-ttu-id="cd413-189">型</span><span class="sxs-lookup"><span data-stu-id="cd413-189">Type</span></span>| <span data-ttu-id="cd413-190">説明</span><span class="sxs-lookup"><span data-stu-id="cd413-190">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd413-191">Authorization</span><span class="sxs-lookup"><span data-stu-id="cd413-191">Authorization</span></span>| <span data-ttu-id="cd413-192">string</span><span class="sxs-lookup"><span data-stu-id="cd413-192">string</span></span>| <span data-ttu-id="cd413-193">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="cd413-193">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="cd413-194">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="cd413-194">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="cd413-195">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="cd413-195">x-xbl-contract-version</span></span>| <span data-ttu-id="cd413-196">string</span><span class="sxs-lookup"><span data-stu-id="cd413-196">string</span></span>| <span data-ttu-id="cd413-197">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="cd413-197">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="cd413-198">要求はのみにルーティングすると、サービスの認証トークンを要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="cd413-198">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="cd413-199">値の例: 3、vnext します。</span><span class="sxs-lookup"><span data-stu-id="cd413-199">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="cd413-200">Accept</span><span class="sxs-lookup"><span data-stu-id="cd413-200">Accept</span></span>| <span data-ttu-id="cd413-201">string</span><span class="sxs-lookup"><span data-stu-id="cd413-201">string</span></span>| <span data-ttu-id="cd413-202">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="cd413-202">Content-Types that are acceptable.</span></span> <span data-ttu-id="cd413-203">1 つだけのプレゼンスがサポートは<b>アプリケーション/json</b>はも指定ヘッダーで。</span><span class="sxs-lookup"><span data-stu-id="cd413-203">The only one Presence supports is <b>application/json</b>, but it still must be specified in the header.</span></span>| 
| <span data-ttu-id="cd413-204">同意言語</span><span class="sxs-lookup"><span data-stu-id="cd413-204">Accept-Language</span></span>| <span data-ttu-id="cd413-205">string</span><span class="sxs-lookup"><span data-stu-id="cd413-205">string</span></span>| <span data-ttu-id="cd413-206">応答で文字列を許容できるロケールです。</span><span class="sxs-lookup"><span data-stu-id="cd413-206">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="cd413-207">値の例: EN-US にします。</span><span class="sxs-lookup"><span data-stu-id="cd413-207">Example value: en-US.</span></span>| 
| <span data-ttu-id="cd413-208">Host</span><span class="sxs-lookup"><span data-stu-id="cd413-208">Host</span></span>| <span data-ttu-id="cd413-209">string</span><span class="sxs-lookup"><span data-stu-id="cd413-209">string</span></span>| <span data-ttu-id="cd413-210">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="cd413-210">Domain name of the server.</span></span> <span data-ttu-id="cd413-211">値の例: userpresence.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="cd413-211">Example value: userpresence.xboxlive.com.</span></span>| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="cd413-212">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-212">Optional Request Headers</span></span>
 
| <span data-ttu-id="cd413-213">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-213">Header</span></span>| <span data-ttu-id="cd413-214">型</span><span class="sxs-lookup"><span data-stu-id="cd413-214">Type</span></span>| <span data-ttu-id="cd413-215">説明</span><span class="sxs-lookup"><span data-stu-id="cd413-215">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd413-216">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="cd413-216">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="cd413-217">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="cd413-217">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="cd413-218">要求はのみにルーティングすると、サービスの認証トークンを要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="cd413-218">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="cd413-219">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="cd413-219">Default value: 1.</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="cd413-220">要求本文</span><span class="sxs-lookup"><span data-stu-id="cd413-220">Request body</span></span>
 
<span data-ttu-id="cd413-221">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="cd413-221">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="cd413-222">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="cd413-222">HTTP status codes</span></span>
 
<span data-ttu-id="cd413-223">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="cd413-223">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="cd413-224">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cd413-224">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="cd413-225">コード</span><span class="sxs-lookup"><span data-stu-id="cd413-225">Code</span></span>| <span data-ttu-id="cd413-226">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="cd413-226">Reason phrase</span></span>| <span data-ttu-id="cd413-227">説明</span><span class="sxs-lookup"><span data-stu-id="cd413-227">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd413-228">200</span><span class="sxs-lookup"><span data-stu-id="cd413-228">200</span></span>| <span data-ttu-id="cd413-229">OK</span><span class="sxs-lookup"><span data-stu-id="cd413-229">OK</span></span>| <span data-ttu-id="cd413-230">セッションが正常に取得されます。</span><span class="sxs-lookup"><span data-stu-id="cd413-230">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="cd413-231">400</span><span class="sxs-lookup"><span data-stu-id="cd413-231">400</span></span>| <span data-ttu-id="cd413-232">Bad Request</span><span class="sxs-lookup"><span data-stu-id="cd413-232">Bad Request</span></span>| <span data-ttu-id="cd413-233">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cd413-233">Service could not understand malformed request.</span></span> <span data-ttu-id="cd413-234">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="cd413-234">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="cd413-235">401</span><span class="sxs-lookup"><span data-stu-id="cd413-235">401</span></span>| <span data-ttu-id="cd413-236">権限がありません</span><span class="sxs-lookup"><span data-stu-id="cd413-236">Unauthorized</span></span>| <span data-ttu-id="cd413-237">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="cd413-237">The request requires user authentication.</span></span>| 
| <span data-ttu-id="cd413-238">403</span><span class="sxs-lookup"><span data-stu-id="cd413-238">403</span></span>| <span data-ttu-id="cd413-239">Forbidden</span><span class="sxs-lookup"><span data-stu-id="cd413-239">Forbidden</span></span>| <span data-ttu-id="cd413-240">要求は、ユーザーまたはサービスは許可されません。</span><span class="sxs-lookup"><span data-stu-id="cd413-240">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="cd413-241">404</span><span class="sxs-lookup"><span data-stu-id="cd413-241">404</span></span>| <span data-ttu-id="cd413-242">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="cd413-242">Not Found</span></span>| <span data-ttu-id="cd413-243">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="cd413-243">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="cd413-244">405</span><span class="sxs-lookup"><span data-stu-id="cd413-244">405</span></span>| <span data-ttu-id="cd413-245">Method Not Allowed</span><span class="sxs-lookup"><span data-stu-id="cd413-245">Method Not Allowed</span></span>| <span data-ttu-id="cd413-246">HTTP メソッドは、サポートされていないコンテンツの種類で使用されました。</span><span class="sxs-lookup"><span data-stu-id="cd413-246">HTTP method was used on an unsupported content type.</span></span>| 
| <span data-ttu-id="cd413-247">406</span><span class="sxs-lookup"><span data-stu-id="cd413-247">406</span></span>| <span data-ttu-id="cd413-248">許容できません。</span><span class="sxs-lookup"><span data-stu-id="cd413-248">Not Acceptable</span></span>| <span data-ttu-id="cd413-249">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="cd413-249">Resource version is not supported.</span></span>| 
| <span data-ttu-id="cd413-250">500</span><span class="sxs-lookup"><span data-stu-id="cd413-250">500</span></span>| <span data-ttu-id="cd413-251">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="cd413-251">Request Timeout</span></span>| <span data-ttu-id="cd413-252">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cd413-252">Service could not understand malformed request.</span></span> <span data-ttu-id="cd413-253">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="cd413-253">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="cd413-254">503</span><span class="sxs-lookup"><span data-stu-id="cd413-254">503</span></span>| <span data-ttu-id="cd413-255">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="cd413-255">Request Timeout</span></span>| <span data-ttu-id="cd413-256">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cd413-256">Service could not understand malformed request.</span></span> <span data-ttu-id="cd413-257">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="cd413-257">Typically an invalid parameter.</span></span>| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="cd413-258">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-258">Required Response Headers</span></span>
 
| <span data-ttu-id="cd413-259">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-259">Header</span></span>| <span data-ttu-id="cd413-260">型</span><span class="sxs-lookup"><span data-stu-id="cd413-260">Type</span></span>| <span data-ttu-id="cd413-261">説明</span><span class="sxs-lookup"><span data-stu-id="cd413-261">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd413-262">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="cd413-262">x-xbl-contract-version</span></span>| <span data-ttu-id="cd413-263">string</span><span class="sxs-lookup"><span data-stu-id="cd413-263">string</span></span>| <span data-ttu-id="cd413-264">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="cd413-264">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="cd413-265">要求はのみにルーティングすると、サービスの認証トークンを要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="cd413-265">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="cd413-266">値の例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="cd413-266">Example values: 1, vnext.</span></span>| 
| <span data-ttu-id="cd413-267">Content-Type</span><span class="sxs-lookup"><span data-stu-id="cd413-267">Content-Type</span></span>| <span data-ttu-id="cd413-268">string</span><span class="sxs-lookup"><span data-stu-id="cd413-268">string</span></span>| <span data-ttu-id="cd413-269">要求の本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="cd413-269">The mime type of the body of the request.</span></span> <span data-ttu-id="cd413-270">値の例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="cd413-270">Example value: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="cd413-271">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="cd413-271">Cache-Control</span></span>| <span data-ttu-id="cd413-272">string</span><span class="sxs-lookup"><span data-stu-id="cd413-272">string</span></span>| <span data-ttu-id="cd413-273">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="cd413-273">Polite request to specify caching behavior.</span></span> <span data-ttu-id="cd413-274">値の例:「は」。</span><span class="sxs-lookup"><span data-stu-id="cd413-274">Example values: "no-cache".</span></span>| 
| <span data-ttu-id="cd413-275">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="cd413-275">X-XblCorrelationId</span></span>| <span data-ttu-id="cd413-276">string</span><span class="sxs-lookup"><span data-stu-id="cd413-276">string</span></span>| <span data-ttu-id="cd413-277">サーバーが返すし、クライアントで何が受信されたを関連付けるにサービスで生成された値。</span><span class="sxs-lookup"><span data-stu-id="cd413-277">Service-generated value to correlate what the server returns and what is received by the client.</span></span> <span data-ttu-id="cd413-278">値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"。</span><span class="sxs-lookup"><span data-stu-id="cd413-278">Example value: "4106d0bc-1cb3-47bd-83fd-57d041c6febe".</span></span>| 
| <span data-ttu-id="cd413-279">X コンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="cd413-279">X-Content-Type-Option</span></span>| <span data-ttu-id="cd413-280">string</span><span class="sxs-lookup"><span data-stu-id="cd413-280">string</span></span>| <span data-ttu-id="cd413-281">SDL に準拠した値を返します。</span><span class="sxs-lookup"><span data-stu-id="cd413-281">Returns the SDL-compliant value.</span></span> <span data-ttu-id="cd413-282">値の例:"nosniff"。</span><span class="sxs-lookup"><span data-stu-id="cd413-282">Example value: "nosniff".</span></span>| 
| <span data-ttu-id="cd413-283">Date</span><span class="sxs-lookup"><span data-stu-id="cd413-283">Date</span></span>| <span data-ttu-id="cd413-284">string</span><span class="sxs-lookup"><span data-stu-id="cd413-284">string</span></span>| <span data-ttu-id="cd413-285">メッセージが送信された日付/時刻。</span><span class="sxs-lookup"><span data-stu-id="cd413-285">The date/time the message was sent.</span></span> <span data-ttu-id="cd413-286">値の例:"火曜日、17 年 2012年 11 月 10時 33分: 31 GMT"。</span><span class="sxs-lookup"><span data-stu-id="cd413-286">Example value: "Tue, 17 Nov 2012 10:33:31 GMT".</span></span>| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="cd413-287">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-287">Optional Response Headers</span></span>
 
| <span data-ttu-id="cd413-288">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd413-288">Header</span></span>| <span data-ttu-id="cd413-289">型</span><span class="sxs-lookup"><span data-stu-id="cd413-289">Type</span></span>| <span data-ttu-id="cd413-290">説明</span><span class="sxs-lookup"><span data-stu-id="cd413-290">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd413-291">Retry-after</span><span class="sxs-lookup"><span data-stu-id="cd413-291">Retry-After</span></span>| <span data-ttu-id="cd413-292">string</span><span class="sxs-lookup"><span data-stu-id="cd413-292">string</span></span>| <span data-ttu-id="cd413-293">503 HTTP エラーに返されます。</span><span class="sxs-lookup"><span data-stu-id="cd413-293">Returned on 503 HTTP errors.</span></span> <span data-ttu-id="cd413-294">クライアントに呼び出しを再試行するまで待機する時間に知らせることができます。</span><span class="sxs-lookup"><span data-stu-id="cd413-294">Lets client know how long to wait before retrying the call.</span></span> <span data-ttu-id="cd413-295">値の例:「120」。</span><span class="sxs-lookup"><span data-stu-id="cd413-295">Example values: "120".</span></span>| 
| <span data-ttu-id="cd413-296">Content-Length</span><span class="sxs-lookup"><span data-stu-id="cd413-296">Content-Length</span></span>| <span data-ttu-id="cd413-297">string</span><span class="sxs-lookup"><span data-stu-id="cd413-297">string</span></span>| <span data-ttu-id="cd413-298">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="cd413-298">Length of response body.</span></span> <span data-ttu-id="cd413-299">値の例:「527」。</span><span class="sxs-lookup"><span data-stu-id="cd413-299">Example value: "527".</span></span>| 
| <span data-ttu-id="cd413-300">コンテンツ エンコード</span><span class="sxs-lookup"><span data-stu-id="cd413-300">Content-Encoding</span></span>| <span data-ttu-id="cd413-301">string</span><span class="sxs-lookup"><span data-stu-id="cd413-301">string</span></span>| <span data-ttu-id="cd413-302">応答の種類をエンコードします。</span><span class="sxs-lookup"><span data-stu-id="cd413-302">Encoding type of the response.</span></span> <span data-ttu-id="cd413-303">値の例:"gzip"。</span><span class="sxs-lookup"><span data-stu-id="cd413-303">Example value: "gzip".</span></span>| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="cd413-304">応答本文</span><span class="sxs-lookup"><span data-stu-id="cd413-304">Response body</span></span>
 
<span data-ttu-id="cd413-305">この API は、要求から Xuid ごとに 1 つ presencerecord を要求してオブジェクトの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="cd413-305">This API returns an array of PresenceRecord objects, one for each of the XUIDs from the request.</span></span>
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="cd413-306">応答の例</span><span class="sxs-lookup"><span data-stu-id="cd413-306">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="cd413-307">関連項目</span><span class="sxs-lookup"><span data-stu-id="cd413-307">See also</span></span>
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cd413-308">Parent</span><span class="sxs-lookup"><span data-stu-id="cd413-308">Parent</span></span> 

[<span data-ttu-id="cd413-309">ユーザー/me/グループ/{モニカー}</span><span class="sxs-lookup"><span data-stu-id="cd413-309">/users/me/groups/{moniker}</span></span>](uri-usersmegroupsmoniker.md)

   