---
title: GET (/users/xuid({xuid})/groups/{moniker} )
assetID: 63aa7e5d-0599-5850-756d-3079c0772238
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/groups/{moniker} )"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 40f562c29e6860d7d566b96f34dfce8b9b438c7a
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4018053"
---
# <a name="get-usersxuidxuidgroupsmoniker-"></a><span data-ttu-id="18560-104">GET (/users/xuid({xuid})/groups/{moniker} )</span><span class="sxs-lookup"><span data-stu-id="18560-104">GET (/users/xuid({xuid})/groups/{moniker} )</span></span>
<span data-ttu-id="18560-105">グループの presencerecord を要求してを取得します。</span><span class="sxs-lookup"><span data-stu-id="18560-105">Gets the PresenceRecord for a group.</span></span> <span data-ttu-id="18560-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="18560-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="18560-107">注釈</span><span class="sxs-lookup"><span data-stu-id="18560-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="18560-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="18560-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="18560-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="18560-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="18560-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="18560-110">Authorization</span></span>](#ID4EKC)
  * [<span data-ttu-id="18560-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="18560-111">Effect of privacy settings on resource</span></span>](#ID4EQD)
  * [<span data-ttu-id="18560-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-112">Required Request Headers</span></span>](#ID4EEH)
  * [<span data-ttu-id="18560-113">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-113">Optional Request Headers</span></span>](#ID4EMBAC)
  * [<span data-ttu-id="18560-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="18560-114">Request body</span></span>](#ID4EMCAC)
  * [<span data-ttu-id="18560-115">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="18560-115">HTTP status codes</span></span>](#ID4EXCAC)
  * [<span data-ttu-id="18560-116">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-116">Required Response Headers</span></span>](#ID4E3GAC)
  * [<span data-ttu-id="18560-117">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-117">Optional Response Headers</span></span>](#ID4EMJAC)
  * [<span data-ttu-id="18560-118">応答本文</span><span class="sxs-lookup"><span data-stu-id="18560-118">Response body</span></span>](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="18560-119">注釈</span><span class="sxs-lookup"><span data-stu-id="18560-119">Remarks</span></span>
 
<span data-ttu-id="18560-120">URI のユーザーに関連するモニカーによって指定されたグループ内のユーザーを取得し、それらのユーザーの presencerecord を要求してを返します。</span><span class="sxs-lookup"><span data-stu-id="18560-120">Retrieves the users in the group specified by the moniker related to the user in the URI, and returns the PresenceRecord for those users.</span></span> <span data-ttu-id="18560-121">プライバシーやコンテンツの分離で区切られているデータは単には返されません。</span><span class="sxs-lookup"><span data-stu-id="18560-121">Data that is gated by Privacy or Content Isolation will simply not be returned.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="18560-122">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="18560-122">URI parameters</span></span>
 
| <span data-ttu-id="18560-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="18560-123">Parameter</span></span>| <span data-ttu-id="18560-124">型</span><span class="sxs-lookup"><span data-stu-id="18560-124">Type</span></span>| <span data-ttu-id="18560-125">説明</span><span class="sxs-lookup"><span data-stu-id="18560-125">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="18560-126">xuid</span><span class="sxs-lookup"><span data-stu-id="18560-126">xuid</span></span>| <span data-ttu-id="18560-127">string</span><span class="sxs-lookup"><span data-stu-id="18560-127">string</span></span>| <span data-ttu-id="18560-128">Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連するのです。</span><span class="sxs-lookup"><span data-stu-id="18560-128">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="18560-129">モニカー</span><span class="sxs-lookup"><span data-stu-id="18560-129">moniker</span></span>| <span data-ttu-id="18560-130">string</span><span class="sxs-lookup"><span data-stu-id="18560-130">string</span></span>| <span data-ttu-id="18560-131">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="18560-131">String defining the group of users.</span></span> <span data-ttu-id="18560-132">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="18560-132">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="18560-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="18560-133">Query string parameters</span></span>
 
| <span data-ttu-id="18560-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="18560-134">Parameter</span></span>| <span data-ttu-id="18560-135">型</span><span class="sxs-lookup"><span data-stu-id="18560-135">Type</span></span>| <span data-ttu-id="18560-136">説明</span><span class="sxs-lookup"><span data-stu-id="18560-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="18560-137">level</span><span class="sxs-lookup"><span data-stu-id="18560-137">level</span></span>| <span data-ttu-id="18560-138">string</span><span class="sxs-lookup"><span data-stu-id="18560-138">string</span></span>| <span data-ttu-id="18560-139">このクエリ文字列で指定された詳細レベルを返します。</span><span class="sxs-lookup"><span data-stu-id="18560-139">Returns the level of detail as specified by this query string.</span></span> <span data-ttu-id="18560-140">有効なオプションには、「ユーザー」、「デバイス」、「タイトル」および"all"が含まれます。「ユーザー」レベルは、DeviceRecord 入れ子になったオブジェクトがない presencerecord を要求してオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="18560-140">Valid options include "user", "device", "title", and "all".The level "user" is the PresenceRecord object without the DeviceRecord nested object.</span></span> <span data-ttu-id="18560-141">「デバイス」レベルでは、TitleRecord 入れ子になったオブジェクトがない presencerecord を要求してと DeviceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="18560-141">The level "device" is the PresenceRecord and DeviceRecord objects without the TitleRecord nested object.</span></span> <span data-ttu-id="18560-142">「タイトル」レベルでは、ActivityRecord 入れ子になったオブジェクトがない presencerecord を要求して、DeviceRecord、TitleRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="18560-142">The level "title" is the PresenceRecord, DeviceRecord, and TitleRecord objects without the ActivityRecord nested object.</span></span> <span data-ttu-id="18560-143">"All"レベルでは、すべての入れ子になったオブジェクトを含むレコード全体です。このパラメーターが指定されていない場合、サービスのレベルをタイトルに既定値 (タイトルの詳細は、このユーザーのプレゼンスを返す、)。</span><span class="sxs-lookup"><span data-stu-id="18560-143">The level "all" is the entire record, including all nested objects.If this parameter is not provided, the service defaults to the title level (that is, it returns presence for this user down to the details of title).</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a><span data-ttu-id="18560-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="18560-144">Authorization</span></span>
 
<span data-ttu-id="18560-145">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="18560-145">Authorization claims used</span></span> | <span data-ttu-id="18560-146">要求</span><span class="sxs-lookup"><span data-stu-id="18560-146">Claim</span></span>| <span data-ttu-id="18560-147">種類</span><span class="sxs-lookup"><span data-stu-id="18560-147">Type</span></span>| <span data-ttu-id="18560-148">必須?</span><span class="sxs-lookup"><span data-stu-id="18560-148">Required?</span></span>| <span data-ttu-id="18560-149">値の例</span><span class="sxs-lookup"><span data-stu-id="18560-149">Example value</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="18560-150">Xuid</span><span class="sxs-lookup"><span data-stu-id="18560-150">Xuid</span></span></b>| <span data-ttu-id="18560-151">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="18560-151">64-bit signed integer</span></span>| <span data-ttu-id="18560-152">必須</span><span class="sxs-lookup"><span data-stu-id="18560-152">yes</span></span>| <span data-ttu-id="18560-153">1234567890</span><span class="sxs-lookup"><span data-stu-id="18560-153">1234567890</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="18560-154">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="18560-154">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="18560-155">サービスが常に返す 200 OK 要求自体が整形式である場合。</span><span class="sxs-lookup"><span data-stu-id="18560-155">The service will always return 200 OK if the request itself is well-formed.</span></span> <span data-ttu-id="18560-156">ただし、プライバシー チェックを渡さない場合、応答からの情報をフィルター処理には。</span><span class="sxs-lookup"><span data-stu-id="18560-156">However, it will filter out information from the response when privacy checks do not pass.</span></span>
 
<span data-ttu-id="18560-157">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="18560-157">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="18560-158">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="18560-158">Requesting User</span></span>| <span data-ttu-id="18560-159">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="18560-159">Target User's Privacy Setting</span></span>| <span data-ttu-id="18560-160">動作</span><span class="sxs-lookup"><span data-stu-id="18560-160">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="18560-161">me</span><span class="sxs-lookup"><span data-stu-id="18560-161">me</span></span>| -| <span data-ttu-id="18560-162">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="18560-162">As described.</span></span>| 
| <span data-ttu-id="18560-163">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="18560-163">friend</span></span>| <span data-ttu-id="18560-164">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="18560-164">everyone</span></span>| <span data-ttu-id="18560-165">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="18560-165">As described.</span></span>| 
| <span data-ttu-id="18560-166">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="18560-166">friend</span></span>| <span data-ttu-id="18560-167">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="18560-167">friends only</span></span>| <span data-ttu-id="18560-168">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="18560-168">As described.</span></span>| 
| <span data-ttu-id="18560-169">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="18560-169">friend</span></span>| <span data-ttu-id="18560-170">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="18560-170">blocked</span></span>| <span data-ttu-id="18560-171">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="18560-171">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="18560-172">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="18560-172">non-friend user</span></span>| <span data-ttu-id="18560-173">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="18560-173">everyone</span></span>| <span data-ttu-id="18560-174">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="18560-174">As described.</span></span>| 
| <span data-ttu-id="18560-175">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="18560-175">non-friend user</span></span>| <span data-ttu-id="18560-176">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="18560-176">friends only</span></span>| <span data-ttu-id="18560-177">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="18560-177">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="18560-178">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="18560-178">non-friend user</span></span>| <span data-ttu-id="18560-179">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="18560-179">blocked</span></span>| <span data-ttu-id="18560-180">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="18560-180">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="18560-181">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="18560-181">third-party site</span></span>| <span data-ttu-id="18560-182">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="18560-182">everyone</span></span>| <span data-ttu-id="18560-183">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="18560-183">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="18560-184">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="18560-184">third-party site</span></span>| <span data-ttu-id="18560-185">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="18560-185">friends only</span></span>| <span data-ttu-id="18560-186">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="18560-186">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="18560-187">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="18560-187">third-party site</span></span>| <span data-ttu-id="18560-188">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="18560-188">blocked</span></span>| <span data-ttu-id="18560-189">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="18560-189">As described - the service will filter out data.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="18560-190">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-190">Required Request Headers</span></span>
 
| <span data-ttu-id="18560-191">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-191">Header</span></span>| <span data-ttu-id="18560-192">型</span><span class="sxs-lookup"><span data-stu-id="18560-192">Type</span></span>| <span data-ttu-id="18560-193">説明</span><span class="sxs-lookup"><span data-stu-id="18560-193">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="18560-194">Authorization</span><span class="sxs-lookup"><span data-stu-id="18560-194">Authorization</span></span>| <span data-ttu-id="18560-195">string</span><span class="sxs-lookup"><span data-stu-id="18560-195">string</span></span>| <span data-ttu-id="18560-196">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="18560-196">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="18560-197">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。</span><span class="sxs-lookup"><span data-stu-id="18560-197">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="18560-198">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="18560-198">x-xbl-contract-version</span></span>| <span data-ttu-id="18560-199">string</span><span class="sxs-lookup"><span data-stu-id="18560-199">string</span></span>| <span data-ttu-id="18560-200">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="18560-200">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="18560-201">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="18560-201">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="18560-202">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="18560-202">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="18560-203">Accept</span><span class="sxs-lookup"><span data-stu-id="18560-203">Accept</span></span>| <span data-ttu-id="18560-204">string</span><span class="sxs-lookup"><span data-stu-id="18560-204">string</span></span>| <span data-ttu-id="18560-205">コンテンツの種類の受け入れられるします。</span><span class="sxs-lookup"><span data-stu-id="18560-205">Content-Types that are acceptable.</span></span> <span data-ttu-id="18560-206">1 つだけのプレゼンスがサポートは<b>アプリケーション/json</b>がでも指定ヘッダーで。</span><span class="sxs-lookup"><span data-stu-id="18560-206">The only one Presence supports is <b>application/json</b>, but it still must be specified in the header.</span></span>| 
| <span data-ttu-id="18560-207">言語を受け入れる</span><span class="sxs-lookup"><span data-stu-id="18560-207">Accept-Language</span></span>| <span data-ttu-id="18560-208">string</span><span class="sxs-lookup"><span data-stu-id="18560-208">string</span></span>| <span data-ttu-id="18560-209">応答で文字列を許容できるロケールです。</span><span class="sxs-lookup"><span data-stu-id="18560-209">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="18560-210">値の例: EN-US にします。</span><span class="sxs-lookup"><span data-stu-id="18560-210">Example value: en-US.</span></span>| 
| <span data-ttu-id="18560-211">Host</span><span class="sxs-lookup"><span data-stu-id="18560-211">Host</span></span>| <span data-ttu-id="18560-212">string</span><span class="sxs-lookup"><span data-stu-id="18560-212">string</span></span>| <span data-ttu-id="18560-213">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="18560-213">Domain name of the server.</span></span> <span data-ttu-id="18560-214">値の例: userpresence.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="18560-214">Example value: userpresence.xboxlive.com.</span></span>| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="18560-215">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-215">Optional Request Headers</span></span>
 
| <span data-ttu-id="18560-216">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-216">Header</span></span>| <span data-ttu-id="18560-217">型</span><span class="sxs-lookup"><span data-stu-id="18560-217">Type</span></span>| <span data-ttu-id="18560-218">説明</span><span class="sxs-lookup"><span data-stu-id="18560-218">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="18560-219">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="18560-219">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="18560-220">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="18560-220">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="18560-221">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="18560-221">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="18560-222">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="18560-222">Default value: 1.</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="18560-223">要求本文</span><span class="sxs-lookup"><span data-stu-id="18560-223">Request body</span></span>
 
<span data-ttu-id="18560-224">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="18560-224">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="18560-225">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="18560-225">HTTP status codes</span></span>
 
<span data-ttu-id="18560-226">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="18560-226">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="18560-227">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="18560-227">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="18560-228">コード</span><span class="sxs-lookup"><span data-stu-id="18560-228">Code</span></span>| <span data-ttu-id="18560-229">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="18560-229">Reason phrase</span></span>| <span data-ttu-id="18560-230">説明</span><span class="sxs-lookup"><span data-stu-id="18560-230">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="18560-231">200</span><span class="sxs-lookup"><span data-stu-id="18560-231">200</span></span>| <span data-ttu-id="18560-232">OK</span><span class="sxs-lookup"><span data-stu-id="18560-232">OK</span></span>| <span data-ttu-id="18560-233">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="18560-233">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="18560-234">400</span><span class="sxs-lookup"><span data-stu-id="18560-234">400</span></span>| <span data-ttu-id="18560-235">Bad Request</span><span class="sxs-lookup"><span data-stu-id="18560-235">Bad Request</span></span>| <span data-ttu-id="18560-236">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="18560-236">Service could not understand malformed request.</span></span> <span data-ttu-id="18560-237">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="18560-237">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="18560-238">401</span><span class="sxs-lookup"><span data-stu-id="18560-238">401</span></span>| <span data-ttu-id="18560-239">権限がありません</span><span class="sxs-lookup"><span data-stu-id="18560-239">Unauthorized</span></span>| <span data-ttu-id="18560-240">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="18560-240">The request requires user authentication.</span></span>| 
| <span data-ttu-id="18560-241">403</span><span class="sxs-lookup"><span data-stu-id="18560-241">403</span></span>| <span data-ttu-id="18560-242">Forbidden</span><span class="sxs-lookup"><span data-stu-id="18560-242">Forbidden</span></span>| <span data-ttu-id="18560-243">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="18560-243">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="18560-244">404</span><span class="sxs-lookup"><span data-stu-id="18560-244">404</span></span>| <span data-ttu-id="18560-245">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="18560-245">Not Found</span></span>| <span data-ttu-id="18560-246">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="18560-246">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="18560-247">405</span><span class="sxs-lookup"><span data-stu-id="18560-247">405</span></span>| <span data-ttu-id="18560-248">Method Not Allowed</span><span class="sxs-lookup"><span data-stu-id="18560-248">Method Not Allowed</span></span>| <span data-ttu-id="18560-249">HTTP メソッドは、サポートされていないコンテンツの種類に対して使用されました。</span><span class="sxs-lookup"><span data-stu-id="18560-249">HTTP method was used on an unsupported content type.</span></span>| 
| <span data-ttu-id="18560-250">406</span><span class="sxs-lookup"><span data-stu-id="18560-250">406</span></span>| <span data-ttu-id="18560-251">許容できません。</span><span class="sxs-lookup"><span data-stu-id="18560-251">Not Acceptable</span></span>| <span data-ttu-id="18560-252">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="18560-252">Resource version is not supported.</span></span>| 
| <span data-ttu-id="18560-253">500</span><span class="sxs-lookup"><span data-stu-id="18560-253">500</span></span>| <span data-ttu-id="18560-254">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="18560-254">Request Timeout</span></span>| <span data-ttu-id="18560-255">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="18560-255">Service could not understand malformed request.</span></span> <span data-ttu-id="18560-256">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="18560-256">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="18560-257">503</span><span class="sxs-lookup"><span data-stu-id="18560-257">503</span></span>| <span data-ttu-id="18560-258">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="18560-258">Request Timeout</span></span>| <span data-ttu-id="18560-259">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="18560-259">Service could not understand malformed request.</span></span> <span data-ttu-id="18560-260">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="18560-260">Typically an invalid parameter.</span></span>| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="18560-261">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-261">Required Response Headers</span></span>
 
| <span data-ttu-id="18560-262">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-262">Header</span></span>| <span data-ttu-id="18560-263">型</span><span class="sxs-lookup"><span data-stu-id="18560-263">Type</span></span>| <span data-ttu-id="18560-264">説明</span><span class="sxs-lookup"><span data-stu-id="18560-264">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="18560-265">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="18560-265">x-xbl-contract-version</span></span>| <span data-ttu-id="18560-266">string</span><span class="sxs-lookup"><span data-stu-id="18560-266">string</span></span>| <span data-ttu-id="18560-267">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="18560-267">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="18560-268">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="18560-268">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="18560-269">値の例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="18560-269">Example values: 1, vnext.</span></span>| 
| <span data-ttu-id="18560-270">Content-Type</span><span class="sxs-lookup"><span data-stu-id="18560-270">Content-Type</span></span>| <span data-ttu-id="18560-271">string</span><span class="sxs-lookup"><span data-stu-id="18560-271">string</span></span>| <span data-ttu-id="18560-272">要求の本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="18560-272">The mime type of the body of the request.</span></span> <span data-ttu-id="18560-273">値の例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="18560-273">Example value: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="18560-274">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="18560-274">Cache-Control</span></span>| <span data-ttu-id="18560-275">string</span><span class="sxs-lookup"><span data-stu-id="18560-275">string</span></span>| <span data-ttu-id="18560-276">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="18560-276">Polite request to specify caching behavior.</span></span> <span data-ttu-id="18560-277">値の例:"no-cache"します。</span><span class="sxs-lookup"><span data-stu-id="18560-277">Example values: "no-cache".</span></span>| 
| <span data-ttu-id="18560-278">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="18560-278">X-XblCorrelationId</span></span>| <span data-ttu-id="18560-279">string</span><span class="sxs-lookup"><span data-stu-id="18560-279">string</span></span>| <span data-ttu-id="18560-280">サーバーが返すし、クライアントが受信を関連付けるサービスで生成された値です。</span><span class="sxs-lookup"><span data-stu-id="18560-280">Service-generated value to correlate what the server returns and what is received by the client.</span></span> <span data-ttu-id="18560-281">値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"です。</span><span class="sxs-lookup"><span data-stu-id="18560-281">Example value: "4106d0bc-1cb3-47bd-83fd-57d041c6febe".</span></span>| 
| <span data-ttu-id="18560-282">X コンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="18560-282">X-Content-Type-Option</span></span>| <span data-ttu-id="18560-283">string</span><span class="sxs-lookup"><span data-stu-id="18560-283">string</span></span>| <span data-ttu-id="18560-284">SDL 準拠の値を返します。</span><span class="sxs-lookup"><span data-stu-id="18560-284">Returns the SDL-compliant value.</span></span> <span data-ttu-id="18560-285">値の例:"nosniff"です。</span><span class="sxs-lookup"><span data-stu-id="18560-285">Example value: "nosniff".</span></span>| 
| <span data-ttu-id="18560-286">Date</span><span class="sxs-lookup"><span data-stu-id="18560-286">Date</span></span>| <span data-ttu-id="18560-287">string</span><span class="sxs-lookup"><span data-stu-id="18560-287">string</span></span>| <span data-ttu-id="18560-288">メッセージが送信された日付/時刻。</span><span class="sxs-lookup"><span data-stu-id="18560-288">The date/time the message was sent.</span></span> <span data-ttu-id="18560-289">値の例:"火曜日 2012 年 1 17 年 11 月 10時 33分: 31 GMT"します。</span><span class="sxs-lookup"><span data-stu-id="18560-289">Example value: "Tue, 17 Nov 2012 10:33:31 GMT".</span></span>| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="18560-290">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-290">Optional Response Headers</span></span>
 
| <span data-ttu-id="18560-291">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="18560-291">Header</span></span>| <span data-ttu-id="18560-292">型</span><span class="sxs-lookup"><span data-stu-id="18560-292">Type</span></span>| <span data-ttu-id="18560-293">説明</span><span class="sxs-lookup"><span data-stu-id="18560-293">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="18560-294">Retry-after</span><span class="sxs-lookup"><span data-stu-id="18560-294">Retry-After</span></span>| <span data-ttu-id="18560-295">string</span><span class="sxs-lookup"><span data-stu-id="18560-295">string</span></span>| <span data-ttu-id="18560-296">503 HTTP エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="18560-296">Returned on 503 HTTP errors.</span></span> <span data-ttu-id="18560-297">クライアントに呼び出しを再試行するまで待機する時間に知らせることができます。</span><span class="sxs-lookup"><span data-stu-id="18560-297">Lets client know how long to wait before retrying the call.</span></span> <span data-ttu-id="18560-298">値の例:「120」します。</span><span class="sxs-lookup"><span data-stu-id="18560-298">Example values: "120".</span></span>| 
| <span data-ttu-id="18560-299">Content-Length</span><span class="sxs-lookup"><span data-stu-id="18560-299">Content-Length</span></span>| <span data-ttu-id="18560-300">string</span><span class="sxs-lookup"><span data-stu-id="18560-300">string</span></span>| <span data-ttu-id="18560-301">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="18560-301">Length of response body.</span></span> <span data-ttu-id="18560-302">値の例:「527」です。</span><span class="sxs-lookup"><span data-stu-id="18560-302">Example value: "527".</span></span>| 
| <span data-ttu-id="18560-303">コンテンツ エンコード</span><span class="sxs-lookup"><span data-stu-id="18560-303">Content-Encoding</span></span>| <span data-ttu-id="18560-304">string</span><span class="sxs-lookup"><span data-stu-id="18560-304">string</span></span>| <span data-ttu-id="18560-305">応答の種類をエンコードします。</span><span class="sxs-lookup"><span data-stu-id="18560-305">Encoding type of the response.</span></span> <span data-ttu-id="18560-306">値の例:"gzip"します。</span><span class="sxs-lookup"><span data-stu-id="18560-306">Example value: "gzip".</span></span>| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="18560-307">応答本文</span><span class="sxs-lookup"><span data-stu-id="18560-307">Response body</span></span>
 
<span data-ttu-id="18560-308">この API は、要求から Xuid ごとに 1 つの presencerecord を要求してオブジェクトの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="18560-308">This API returns an array of PresenceRecord objects, one for each of the XUIDs from the request.</span></span>
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="18560-309">応答の例</span><span class="sxs-lookup"><span data-stu-id="18560-309">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="18560-310">関連項目</span><span class="sxs-lookup"><span data-stu-id="18560-310">See also</span></span>
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="18560-311">Parent</span><span class="sxs-lookup"><span data-stu-id="18560-311">Parent</span></span> 

[<span data-ttu-id="18560-312">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="18560-312">/users/xuid({xuid})/groups/{moniker}</span></span>](uri-usersxuidgroupsmoniker.md)

   