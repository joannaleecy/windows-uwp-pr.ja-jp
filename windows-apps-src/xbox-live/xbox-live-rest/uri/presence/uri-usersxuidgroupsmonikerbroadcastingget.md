---
title: GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )
assetID: 8a3df075-ccdf-18f2-ab0c-275f25cc22e3
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcastingget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3dc10f18d7c1c38ac21ad6889943b8c6009f5af1
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4314121"
---
# <a name="get-usersxuidxuidgroupsmonikerbroadcasting-"></a><span data-ttu-id="1966f-104">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span><span class="sxs-lookup"><span data-stu-id="1966f-104">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span></span>
<span data-ttu-id="1966f-105">URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードを取得します。</span><span class="sxs-lookup"><span data-stu-id="1966f-105">Retrieves the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="1966f-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="1966f-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="1966f-107">注釈</span><span class="sxs-lookup"><span data-stu-id="1966f-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="1966f-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1966f-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="1966f-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="1966f-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="1966f-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="1966f-110">Authorization</span></span>](#ID4EKC)
  * [<span data-ttu-id="1966f-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="1966f-111">Effect of privacy settings on resource</span></span>](#ID4EQD)
  * [<span data-ttu-id="1966f-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-112">Required Request Headers</span></span>](#ID4EEH)
  * [<span data-ttu-id="1966f-113">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-113">Optional Request Headers</span></span>](#ID4EMBAC)
  * [<span data-ttu-id="1966f-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="1966f-114">Request body</span></span>](#ID4EMCAC)
  * [<span data-ttu-id="1966f-115">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="1966f-115">HTTP status codes</span></span>](#ID4EXCAC)
  * [<span data-ttu-id="1966f-116">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-116">Required Response Headers</span></span>](#ID4E3GAC)
  * [<span data-ttu-id="1966f-117">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-117">Optional Response Headers</span></span>](#ID4EMJAC)
  * [<span data-ttu-id="1966f-118">応答本文</span><span class="sxs-lookup"><span data-stu-id="1966f-118">Response body</span></span>](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="1966f-119">注釈</span><span class="sxs-lookup"><span data-stu-id="1966f-119">Remarks</span></span>
 
<span data-ttu-id="1966f-120">URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="1966f-120">Accesses the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="1966f-121">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1966f-121">URI parameters</span></span>
 
| <span data-ttu-id="1966f-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1966f-122">Parameter</span></span>| <span data-ttu-id="1966f-123">型</span><span class="sxs-lookup"><span data-stu-id="1966f-123">Type</span></span>| <span data-ttu-id="1966f-124">説明</span><span class="sxs-lookup"><span data-stu-id="1966f-124">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="1966f-125">xuid</span><span class="sxs-lookup"><span data-stu-id="1966f-125">xuid</span></span>| <span data-ttu-id="1966f-126">string</span><span class="sxs-lookup"><span data-stu-id="1966f-126">string</span></span>| <span data-ttu-id="1966f-127">Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連するのです。</span><span class="sxs-lookup"><span data-stu-id="1966f-127">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="1966f-128">モニカー</span><span class="sxs-lookup"><span data-stu-id="1966f-128">moniker</span></span>| <span data-ttu-id="1966f-129">string</span><span class="sxs-lookup"><span data-stu-id="1966f-129">string</span></span>| <span data-ttu-id="1966f-130">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="1966f-130">String defining the group of users.</span></span> <span data-ttu-id="1966f-131">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="1966f-131">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="1966f-132">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="1966f-132">Query string parameters</span></span>
 
| <span data-ttu-id="1966f-133">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1966f-133">Parameter</span></span>| <span data-ttu-id="1966f-134">型</span><span class="sxs-lookup"><span data-stu-id="1966f-134">Type</span></span>| <span data-ttu-id="1966f-135">説明</span><span class="sxs-lookup"><span data-stu-id="1966f-135">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1966f-136">level</span><span class="sxs-lookup"><span data-stu-id="1966f-136">level</span></span>| <span data-ttu-id="1966f-137">string</span><span class="sxs-lookup"><span data-stu-id="1966f-137">string</span></span>| <span data-ttu-id="1966f-138">このクエリ文字列で指定された詳細レベルを返します。</span><span class="sxs-lookup"><span data-stu-id="1966f-138">Returns the level of detail as specified by this query string.</span></span> <span data-ttu-id="1966f-139">有効なオプションには、「ユーザー」、「デバイス」、「タイトル」および"all"が含まれます。「ユーザー」レベルは、DeviceRecord 入れ子になったオブジェクトがない presencerecord を要求してオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="1966f-139">Valid options include "user", "device", "title", and "all".The level "user" is the PresenceRecord object without the DeviceRecord nested object.</span></span> <span data-ttu-id="1966f-140">「デバイス」レベルでは、TitleRecord 入れ子になったオブジェクトがない presencerecord を要求してと DeviceRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="1966f-140">The level "device" is the PresenceRecord and DeviceRecord objects without the TitleRecord nested object.</span></span> <span data-ttu-id="1966f-141">「タイトル」レベルでは、ActivityRecord 入れ子になったオブジェクトがない presencerecord を要求して、DeviceRecord、TitleRecord オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="1966f-141">The level "title" is the PresenceRecord, DeviceRecord, and TitleRecord objects without the ActivityRecord nested object.</span></span> <span data-ttu-id="1966f-142">"All"レベルでは、すべての入れ子になったオブジェクトを含むレコード全体です。このパラメーターが指定されていない場合、サービスのレベルをタイトルに既定値 (タイトルの詳細は、このユーザーのプレゼンスを返す、)。</span><span class="sxs-lookup"><span data-stu-id="1966f-142">The level "all" is the entire record, including all nested objects.If this parameter is not provided, the service defaults to the title level (that is, it returns presence for this user down to the details of title).</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a><span data-ttu-id="1966f-143">Authorization</span><span class="sxs-lookup"><span data-stu-id="1966f-143">Authorization</span></span>
 
<span data-ttu-id="1966f-144">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="1966f-144">Authorization claims used</span></span> | <span data-ttu-id="1966f-145">要求</span><span class="sxs-lookup"><span data-stu-id="1966f-145">Claim</span></span>| <span data-ttu-id="1966f-146">種類</span><span class="sxs-lookup"><span data-stu-id="1966f-146">Type</span></span>| <span data-ttu-id="1966f-147">必須?</span><span class="sxs-lookup"><span data-stu-id="1966f-147">Required?</span></span>| <span data-ttu-id="1966f-148">値の例</span><span class="sxs-lookup"><span data-stu-id="1966f-148">Example value</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="1966f-149">Xuid</span><span class="sxs-lookup"><span data-stu-id="1966f-149">Xuid</span></span></b>| <span data-ttu-id="1966f-150">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="1966f-150">64-bit signed integer</span></span>| <span data-ttu-id="1966f-151">必須</span><span class="sxs-lookup"><span data-stu-id="1966f-151">yes</span></span>| <span data-ttu-id="1966f-152">1234567890</span><span class="sxs-lookup"><span data-stu-id="1966f-152">1234567890</span></span>| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="1966f-153">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="1966f-153">Effect of privacy settings on resource</span></span>
 
<span data-ttu-id="1966f-154">サービスが常に返す 200 OK 要求自体が整形式である場合。</span><span class="sxs-lookup"><span data-stu-id="1966f-154">The service will always return 200 OK if the request itself is well-formed.</span></span> <span data-ttu-id="1966f-155">ただし、プライバシー チェックを渡さない場合、応答からの情報をフィルター処理には。</span><span class="sxs-lookup"><span data-stu-id="1966f-155">However, it will filter out information from the response when privacy checks do not pass.</span></span>
 
<span data-ttu-id="1966f-156">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="1966f-156">Effect of Privacy Settings on Resource</span></span> | <span data-ttu-id="1966f-157">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="1966f-157">Requesting User</span></span>| <span data-ttu-id="1966f-158">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="1966f-158">Target User's Privacy Setting</span></span>| <span data-ttu-id="1966f-159">動作</span><span class="sxs-lookup"><span data-stu-id="1966f-159">Behavior</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1966f-160">me</span><span class="sxs-lookup"><span data-stu-id="1966f-160">me</span></span>| -| <span data-ttu-id="1966f-161">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="1966f-161">As described.</span></span>| 
| <span data-ttu-id="1966f-162">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="1966f-162">friend</span></span>| <span data-ttu-id="1966f-163">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="1966f-163">everyone</span></span>| <span data-ttu-id="1966f-164">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="1966f-164">As described.</span></span>| 
| <span data-ttu-id="1966f-165">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="1966f-165">friend</span></span>| <span data-ttu-id="1966f-166">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="1966f-166">friends only</span></span>| <span data-ttu-id="1966f-167">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="1966f-167">As described.</span></span>| 
| <span data-ttu-id="1966f-168">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="1966f-168">friend</span></span>| <span data-ttu-id="1966f-169">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="1966f-169">blocked</span></span>| <span data-ttu-id="1966f-170">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1966f-170">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="1966f-171">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="1966f-171">non-friend user</span></span>| <span data-ttu-id="1966f-172">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="1966f-172">everyone</span></span>| <span data-ttu-id="1966f-173">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="1966f-173">As described.</span></span>| 
| <span data-ttu-id="1966f-174">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="1966f-174">non-friend user</span></span>| <span data-ttu-id="1966f-175">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="1966f-175">friends only</span></span>| <span data-ttu-id="1966f-176">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1966f-176">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="1966f-177">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="1966f-177">non-friend user</span></span>| <span data-ttu-id="1966f-178">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="1966f-178">blocked</span></span>| <span data-ttu-id="1966f-179">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1966f-179">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="1966f-180">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="1966f-180">third-party site</span></span>| <span data-ttu-id="1966f-181">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="1966f-181">everyone</span></span>| <span data-ttu-id="1966f-182">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1966f-182">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="1966f-183">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="1966f-183">third-party site</span></span>| <span data-ttu-id="1966f-184">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="1966f-184">friends only</span></span>| <span data-ttu-id="1966f-185">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1966f-185">As described - the service will filter out data.</span></span>| 
| <span data-ttu-id="1966f-186">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="1966f-186">third-party site</span></span>| <span data-ttu-id="1966f-187">ブロックされています。</span><span class="sxs-lookup"><span data-stu-id="1966f-187">blocked</span></span>| <span data-ttu-id="1966f-188">説明に従って、サービスがデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1966f-188">As described - the service will filter out data.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="1966f-189">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-189">Required Request Headers</span></span>
 
| <span data-ttu-id="1966f-190">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-190">Header</span></span>| <span data-ttu-id="1966f-191">型</span><span class="sxs-lookup"><span data-stu-id="1966f-191">Type</span></span>| <span data-ttu-id="1966f-192">説明</span><span class="sxs-lookup"><span data-stu-id="1966f-192">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1966f-193">Authorization</span><span class="sxs-lookup"><span data-stu-id="1966f-193">Authorization</span></span>| <span data-ttu-id="1966f-194">string</span><span class="sxs-lookup"><span data-stu-id="1966f-194">string</span></span>| <span data-ttu-id="1966f-195">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="1966f-195">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="1966f-196">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。</span><span class="sxs-lookup"><span data-stu-id="1966f-196">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="1966f-197">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="1966f-197">x-xbl-contract-version</span></span>| <span data-ttu-id="1966f-198">string</span><span class="sxs-lookup"><span data-stu-id="1966f-198">string</span></span>| <span data-ttu-id="1966f-199">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="1966f-199">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="1966f-200">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="1966f-200">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="1966f-201">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="1966f-201">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="1966f-202">Accept</span><span class="sxs-lookup"><span data-stu-id="1966f-202">Accept</span></span>| <span data-ttu-id="1966f-203">string</span><span class="sxs-lookup"><span data-stu-id="1966f-203">string</span></span>| <span data-ttu-id="1966f-204">コンテンツの種類の受け入れられるします。</span><span class="sxs-lookup"><span data-stu-id="1966f-204">Content-Types that are acceptable.</span></span> <span data-ttu-id="1966f-205">1 つだけのプレゼンスがサポートは<b>アプリケーション/json</b>がでも指定ヘッダーで。</span><span class="sxs-lookup"><span data-stu-id="1966f-205">The only one Presence supports is <b>application/json</b>, but it still must be specified in the header.</span></span>| 
| <span data-ttu-id="1966f-206">言語を受け入れる</span><span class="sxs-lookup"><span data-stu-id="1966f-206">Accept-Language</span></span>| <span data-ttu-id="1966f-207">string</span><span class="sxs-lookup"><span data-stu-id="1966f-207">string</span></span>| <span data-ttu-id="1966f-208">応答で文字列を許容できるロケールです。</span><span class="sxs-lookup"><span data-stu-id="1966f-208">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="1966f-209">値の例: EN-US にします。</span><span class="sxs-lookup"><span data-stu-id="1966f-209">Example value: en-US.</span></span>| 
| <span data-ttu-id="1966f-210">Host</span><span class="sxs-lookup"><span data-stu-id="1966f-210">Host</span></span>| <span data-ttu-id="1966f-211">string</span><span class="sxs-lookup"><span data-stu-id="1966f-211">string</span></span>| <span data-ttu-id="1966f-212">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="1966f-212">Domain name of the server.</span></span> <span data-ttu-id="1966f-213">値の例: userpresence.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="1966f-213">Example value: userpresence.xboxlive.com.</span></span>| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="1966f-214">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-214">Optional Request Headers</span></span>
 
| <span data-ttu-id="1966f-215">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-215">Header</span></span>| <span data-ttu-id="1966f-216">型</span><span class="sxs-lookup"><span data-stu-id="1966f-216">Type</span></span>| <span data-ttu-id="1966f-217">説明</span><span class="sxs-lookup"><span data-stu-id="1966f-217">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1966f-218">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="1966f-218">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="1966f-219">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="1966f-219">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="1966f-220">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="1966f-220">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="1966f-221">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="1966f-221">Default value: 1.</span></span>| 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="1966f-222">要求本文</span><span class="sxs-lookup"><span data-stu-id="1966f-222">Request body</span></span>
 
<span data-ttu-id="1966f-223">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="1966f-223">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="1966f-224">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="1966f-224">HTTP status codes</span></span>
 
<span data-ttu-id="1966f-225">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="1966f-225">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="1966f-226">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1966f-226">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="1966f-227">コード</span><span class="sxs-lookup"><span data-stu-id="1966f-227">Code</span></span>| <span data-ttu-id="1966f-228">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="1966f-228">Reason phrase</span></span>| <span data-ttu-id="1966f-229">説明</span><span class="sxs-lookup"><span data-stu-id="1966f-229">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1966f-230">200</span><span class="sxs-lookup"><span data-stu-id="1966f-230">200</span></span>| <span data-ttu-id="1966f-231">OK</span><span class="sxs-lookup"><span data-stu-id="1966f-231">OK</span></span>| <span data-ttu-id="1966f-232">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="1966f-232">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="1966f-233">400</span><span class="sxs-lookup"><span data-stu-id="1966f-233">400</span></span>| <span data-ttu-id="1966f-234">Bad Request</span><span class="sxs-lookup"><span data-stu-id="1966f-234">Bad Request</span></span>| <span data-ttu-id="1966f-235">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1966f-235">Service could not understand malformed request.</span></span> <span data-ttu-id="1966f-236">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="1966f-236">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="1966f-237">401</span><span class="sxs-lookup"><span data-stu-id="1966f-237">401</span></span>| <span data-ttu-id="1966f-238">権限がありません</span><span class="sxs-lookup"><span data-stu-id="1966f-238">Unauthorized</span></span>| <span data-ttu-id="1966f-239">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="1966f-239">The request requires user authentication.</span></span>| 
| <span data-ttu-id="1966f-240">403</span><span class="sxs-lookup"><span data-stu-id="1966f-240">403</span></span>| <span data-ttu-id="1966f-241">Forbidden</span><span class="sxs-lookup"><span data-stu-id="1966f-241">Forbidden</span></span>| <span data-ttu-id="1966f-242">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="1966f-242">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="1966f-243">404</span><span class="sxs-lookup"><span data-stu-id="1966f-243">404</span></span>| <span data-ttu-id="1966f-244">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="1966f-244">Not Found</span></span>| <span data-ttu-id="1966f-245">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="1966f-245">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="1966f-246">405</span><span class="sxs-lookup"><span data-stu-id="1966f-246">405</span></span>| <span data-ttu-id="1966f-247">Method Not Allowed</span><span class="sxs-lookup"><span data-stu-id="1966f-247">Method Not Allowed</span></span>| <span data-ttu-id="1966f-248">HTTP メソッドは、サポートされていないコンテンツの種類に対して使用されました。</span><span class="sxs-lookup"><span data-stu-id="1966f-248">HTTP method was used on an unsupported content type.</span></span>| 
| <span data-ttu-id="1966f-249">406</span><span class="sxs-lookup"><span data-stu-id="1966f-249">406</span></span>| <span data-ttu-id="1966f-250">許容できません。</span><span class="sxs-lookup"><span data-stu-id="1966f-250">Not Acceptable</span></span>| <span data-ttu-id="1966f-251">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="1966f-251">Resource version is not supported.</span></span>| 
| <span data-ttu-id="1966f-252">500</span><span class="sxs-lookup"><span data-stu-id="1966f-252">500</span></span>| <span data-ttu-id="1966f-253">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="1966f-253">Request Timeout</span></span>| <span data-ttu-id="1966f-254">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1966f-254">Service could not understand malformed request.</span></span> <span data-ttu-id="1966f-255">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="1966f-255">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="1966f-256">503</span><span class="sxs-lookup"><span data-stu-id="1966f-256">503</span></span>| <span data-ttu-id="1966f-257">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="1966f-257">Request Timeout</span></span>| <span data-ttu-id="1966f-258">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1966f-258">Service could not understand malformed request.</span></span> <span data-ttu-id="1966f-259">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="1966f-259">Typically an invalid parameter.</span></span>| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="1966f-260">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-260">Required Response Headers</span></span>
 
| <span data-ttu-id="1966f-261">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-261">Header</span></span>| <span data-ttu-id="1966f-262">型</span><span class="sxs-lookup"><span data-stu-id="1966f-262">Type</span></span>| <span data-ttu-id="1966f-263">説明</span><span class="sxs-lookup"><span data-stu-id="1966f-263">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1966f-264">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="1966f-264">x-xbl-contract-version</span></span>| <span data-ttu-id="1966f-265">string</span><span class="sxs-lookup"><span data-stu-id="1966f-265">string</span></span>| <span data-ttu-id="1966f-266">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="1966f-266">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="1966f-267">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="1966f-267">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="1966f-268">値の例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="1966f-268">Example values: 1, vnext.</span></span>| 
| <span data-ttu-id="1966f-269">Content-Type</span><span class="sxs-lookup"><span data-stu-id="1966f-269">Content-Type</span></span>| <span data-ttu-id="1966f-270">string</span><span class="sxs-lookup"><span data-stu-id="1966f-270">string</span></span>| <span data-ttu-id="1966f-271">要求の本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="1966f-271">The mime type of the body of the request.</span></span> <span data-ttu-id="1966f-272">値の例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="1966f-272">Example value: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="1966f-273">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="1966f-273">Cache-Control</span></span>| <span data-ttu-id="1966f-274">string</span><span class="sxs-lookup"><span data-stu-id="1966f-274">string</span></span>| <span data-ttu-id="1966f-275">キャッシュ動作を指定するていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="1966f-275">Polite request to specify caching behavior.</span></span> <span data-ttu-id="1966f-276">値の例:"no-cache"します。</span><span class="sxs-lookup"><span data-stu-id="1966f-276">Example values: "no-cache".</span></span>| 
| <span data-ttu-id="1966f-277">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="1966f-277">X-XblCorrelationId</span></span>| <span data-ttu-id="1966f-278">string</span><span class="sxs-lookup"><span data-stu-id="1966f-278">string</span></span>| <span data-ttu-id="1966f-279">サーバーが返すし、クライアントが受信を関連付けるサービスで生成された値です。</span><span class="sxs-lookup"><span data-stu-id="1966f-279">Service-generated value to correlate what the server returns and what is received by the client.</span></span> <span data-ttu-id="1966f-280">値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"です。</span><span class="sxs-lookup"><span data-stu-id="1966f-280">Example value: "4106d0bc-1cb3-47bd-83fd-57d041c6febe".</span></span>| 
| <span data-ttu-id="1966f-281">X コンテンツの種類オプション</span><span class="sxs-lookup"><span data-stu-id="1966f-281">X-Content-Type-Option</span></span>| <span data-ttu-id="1966f-282">string</span><span class="sxs-lookup"><span data-stu-id="1966f-282">string</span></span>| <span data-ttu-id="1966f-283">SDL 準拠の値を返します。</span><span class="sxs-lookup"><span data-stu-id="1966f-283">Returns the SDL-compliant value.</span></span> <span data-ttu-id="1966f-284">値の例:"nosniff"です。</span><span class="sxs-lookup"><span data-stu-id="1966f-284">Example value: "nosniff".</span></span>| 
| <span data-ttu-id="1966f-285">Date</span><span class="sxs-lookup"><span data-stu-id="1966f-285">Date</span></span>| <span data-ttu-id="1966f-286">string</span><span class="sxs-lookup"><span data-stu-id="1966f-286">string</span></span>| <span data-ttu-id="1966f-287">メッセージが送信された日付/時刻。</span><span class="sxs-lookup"><span data-stu-id="1966f-287">The date/time the message was sent.</span></span> <span data-ttu-id="1966f-288">値の例:"火曜日 2012 年 1 17 年 11 月 10時 33分: 31 GMT"します。</span><span class="sxs-lookup"><span data-stu-id="1966f-288">Example value: "Tue, 17 Nov 2012 10:33:31 GMT".</span></span>| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="1966f-289">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-289">Optional Response Headers</span></span>
 
| <span data-ttu-id="1966f-290">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1966f-290">Header</span></span>| <span data-ttu-id="1966f-291">型</span><span class="sxs-lookup"><span data-stu-id="1966f-291">Type</span></span>| <span data-ttu-id="1966f-292">説明</span><span class="sxs-lookup"><span data-stu-id="1966f-292">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1966f-293">Retry-after</span><span class="sxs-lookup"><span data-stu-id="1966f-293">Retry-After</span></span>| <span data-ttu-id="1966f-294">string</span><span class="sxs-lookup"><span data-stu-id="1966f-294">string</span></span>| <span data-ttu-id="1966f-295">503 HTTP エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="1966f-295">Returned on 503 HTTP errors.</span></span> <span data-ttu-id="1966f-296">クライアントに呼び出しを再試行するまで待機する時間に知らせることができます。</span><span class="sxs-lookup"><span data-stu-id="1966f-296">Lets client know how long to wait before retrying the call.</span></span> <span data-ttu-id="1966f-297">値の例:「120」します。</span><span class="sxs-lookup"><span data-stu-id="1966f-297">Example values: "120".</span></span>| 
| <span data-ttu-id="1966f-298">Content-Length</span><span class="sxs-lookup"><span data-stu-id="1966f-298">Content-Length</span></span>| <span data-ttu-id="1966f-299">string</span><span class="sxs-lookup"><span data-stu-id="1966f-299">string</span></span>| <span data-ttu-id="1966f-300">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="1966f-300">Length of response body.</span></span> <span data-ttu-id="1966f-301">値の例:「527」です。</span><span class="sxs-lookup"><span data-stu-id="1966f-301">Example value: "527".</span></span>| 
| <span data-ttu-id="1966f-302">コンテンツ エンコード</span><span class="sxs-lookup"><span data-stu-id="1966f-302">Content-Encoding</span></span>| <span data-ttu-id="1966f-303">string</span><span class="sxs-lookup"><span data-stu-id="1966f-303">string</span></span>| <span data-ttu-id="1966f-304">応答の種類をエンコードします。</span><span class="sxs-lookup"><span data-stu-id="1966f-304">Encoding type of the response.</span></span> <span data-ttu-id="1966f-305">値の例:"gzip"します。</span><span class="sxs-lookup"><span data-stu-id="1966f-305">Example value: "gzip".</span></span>| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="1966f-306">応答本文</span><span class="sxs-lookup"><span data-stu-id="1966f-306">Response body</span></span>
 
<span data-ttu-id="1966f-307">この API は、URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードを取得します。</span><span class="sxs-lookup"><span data-stu-id="1966f-307">This API retrieves the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="1966f-308">応答の例</span><span class="sxs-lookup"><span data-stu-id="1966f-308">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="1966f-309">関連項目</span><span class="sxs-lookup"><span data-stu-id="1966f-309">See also</span></span>
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="1966f-310">Parent</span><span class="sxs-lookup"><span data-stu-id="1966f-310">Parent</span></span> 

[<span data-ttu-id="1966f-311">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="1966f-311">/users/xuid({xuid})/groups/{moniker}</span></span>](uri-usersxuidgroupsmoniker.md)

   