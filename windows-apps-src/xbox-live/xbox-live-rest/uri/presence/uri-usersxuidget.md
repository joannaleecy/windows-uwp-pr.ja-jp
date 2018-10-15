---
title: GET (/users/xuid({xuid}))
assetID: c97ef943-8bea-8a41-90d7-faea874284c8
permalink: en-us/docs/xboxlive/rest/uri-usersxuidget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid}))"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 308ecbddb5d62ae98d576f56af4cd3f7363c2c5a
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4615181"
---
# <a name="get-usersxuidxuid"></a><span data-ttu-id="152f0-104">GET (/users/xuid({xuid}))</span><span class="sxs-lookup"><span data-stu-id="152f0-104">GET (/users/xuid({xuid}))</span></span>
<span data-ttu-id="152f0-105">別のユーザーまたはクライアントの有無を検出します。</span><span class="sxs-lookup"><span data-stu-id="152f0-105">Discover the presence of another user or client.</span></span>
<span data-ttu-id="152f0-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="152f0-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>

  * [<span data-ttu-id="152f0-107">注釈</span><span class="sxs-lookup"><span data-stu-id="152f0-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="152f0-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="152f0-108">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="152f0-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="152f0-109">Query string parameters</span></span>](#ID4EOB)
  * [<span data-ttu-id="152f0-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="152f0-110">Authorization</span></span>](#ID4E4C)
  * [<span data-ttu-id="152f0-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="152f0-111">Effect of privacy settings on resource</span></span>](#ID4EAE)
  * [<span data-ttu-id="152f0-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="152f0-112">Required Request Headers</span></span>](#ID4EVH)
  * [<span data-ttu-id="152f0-113">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="152f0-113">Optional Request Headers</span></span>](#ID4E1BAC)
  * [<span data-ttu-id="152f0-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="152f0-114">Request body</span></span>](#ID4E1CAC)
  * [<span data-ttu-id="152f0-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="152f0-115">Response body</span></span>](#ID4EFDAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="152f0-116">注釈</span><span class="sxs-lookup"><span data-stu-id="152f0-116">Remarks</span></span>

<span data-ttu-id="152f0-117">応答には、コンシューマーは、全体のオブジェクトに興味がない場合は、 [PresenceRecord](../../json/json-presencerecord.md)の一部を提供するフィルターを適用できます。</span><span class="sxs-lookup"><span data-stu-id="152f0-117">The response can be filtered to provide part of the [PresenceRecord](../../json/json-presencerecord.md) if the consumer is not interested in the entire object.</span></span>

> [!NOTE] 
> <span data-ttu-id="152f0-118">返されるデータは、プライバシーとコンテンツの分離の規則によって制限されます。</span><span class="sxs-lookup"><span data-stu-id="152f0-118">The data returned is constrained by privacy and content isolation rules.</span></span>



<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="152f0-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="152f0-119">URI parameters</span></span>

| <span data-ttu-id="152f0-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="152f0-120">Parameter</span></span>| <span data-ttu-id="152f0-121">型</span><span class="sxs-lookup"><span data-stu-id="152f0-121">Type</span></span>| <span data-ttu-id="152f0-122">説明</span><span class="sxs-lookup"><span data-stu-id="152f0-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="152f0-123">xuid</span><span class="sxs-lookup"><span data-stu-id="152f0-123">xuid</span></span>| <span data-ttu-id="152f0-124">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="152f0-124">64-bit unsigned integer</span></span>| <span data-ttu-id="152f0-125">Xbox ユーザー ID (XUID) 対象ユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="152f0-125">Xbox User ID (XUID) of the target user.</span></span>|

<a id="ID4EOB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="152f0-126">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="152f0-126">Query string parameters</span></span>

| <span data-ttu-id="152f0-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="152f0-127">Parameter</span></span>| <span data-ttu-id="152f0-128">型</span><span class="sxs-lookup"><span data-stu-id="152f0-128">Type</span></span>| <span data-ttu-id="152f0-129">説明</span><span class="sxs-lookup"><span data-stu-id="152f0-129">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="152f0-130">level</span><span class="sxs-lookup"><span data-stu-id="152f0-130">level</span></span>| <span data-ttu-id="152f0-131">string</span><span class="sxs-lookup"><span data-stu-id="152f0-131">string</span></span>| <span data-ttu-id="152f0-132">省略可能。</span><span class="sxs-lookup"><span data-stu-id="152f0-132">Optional.</span></span> <ul><li><span data-ttu-id="152f0-133"><b>ユーザー</b>: ユーザー ノードのみを返します。</span><span class="sxs-lookup"><span data-stu-id="152f0-133"><b>user</b>: Returns only the user node.</span></span></li><li><span data-ttu-id="152f0-134"><b>デバイス</b>: ユーザー ノードとデバイス ノードを返します。</span><span class="sxs-lookup"><span data-stu-id="152f0-134"><b>device</b>: Returns user node and device nodes.</span></span></li><li><span data-ttu-id="152f0-135"><b>タイトル</b>: 既定値します。</span><span class="sxs-lookup"><span data-stu-id="152f0-135"><b>title</b>: Default.</span></span> <span data-ttu-id="152f0-136">アクティビティを除くツリー全体を返します。</span><span class="sxs-lookup"><span data-stu-id="152f0-136">Returns the whole tree except activity.</span></span></li><li><span data-ttu-id="152f0-137"><b>すべて</b>: アクティビティ レベルのプレゼンスを含むツリー全体を返します。</span><span class="sxs-lookup"><span data-stu-id="152f0-137"><b>all</b>: Returns the whole tree, including activity-level presence.</span></span></li></ul> |

<a id="ID4E4C"></a>


## <a name="authorization"></a><span data-ttu-id="152f0-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="152f0-138">Authorization</span></span>

| <span data-ttu-id="152f0-139">型</span><span class="sxs-lookup"><span data-stu-id="152f0-139">Type</span></span>| <span data-ttu-id="152f0-140">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="152f0-140">Required</span></span>| <span data-ttu-id="152f0-141">説明</span><span class="sxs-lookup"><span data-stu-id="152f0-141">Description</span></span>| <span data-ttu-id="152f0-142">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="152f0-142">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="152f0-143">XUID</span><span class="sxs-lookup"><span data-stu-id="152f0-143">XUID</span></span>| <span data-ttu-id="152f0-144">はい</span><span class="sxs-lookup"><span data-stu-id="152f0-144">Yes</span></span>| <span data-ttu-id="152f0-145">呼び出し元のように、Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="152f0-145">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="152f0-146">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="152f0-146">403 Forbidden</span></span>|

<a id="ID4EAE"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="152f0-147">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="152f0-147">Effect of privacy settings on resource</span></span>

<span data-ttu-id="152f0-148">このメソッドは常に、200 を返しますがコンテンツを応答本文で返されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="152f0-148">This method always returns 200 OK, but might not return content in the response body.</span></span>

| <span data-ttu-id="152f0-149">ユーザーを要求します。</span><span class="sxs-lookup"><span data-stu-id="152f0-149">Requesting User</span></span>| <span data-ttu-id="152f0-150">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="152f0-150">Target User's Privacy Setting</span></span>| <span data-ttu-id="152f0-151">動作</span><span class="sxs-lookup"><span data-stu-id="152f0-151">Behavior</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="152f0-152">me</span><span class="sxs-lookup"><span data-stu-id="152f0-152">me</span></span>| -| <span data-ttu-id="152f0-153">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-153">200 OK</span></span>|
| <span data-ttu-id="152f0-154">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="152f0-154">friend</span></span>| <span data-ttu-id="152f0-155">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="152f0-155">everyone</span></span>| <span data-ttu-id="152f0-156">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-156">200 OK</span></span>|
| <span data-ttu-id="152f0-157">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="152f0-157">friend</span></span>| <span data-ttu-id="152f0-158">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="152f0-158">friends only</span></span>| <span data-ttu-id="152f0-159">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-159">200 OK</span></span>|
| <span data-ttu-id="152f0-160">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="152f0-160">friend</span></span>| <span data-ttu-id="152f0-161">ブロック</span><span class="sxs-lookup"><span data-stu-id="152f0-161">blocked</span></span>| <span data-ttu-id="152f0-162">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-162">200 OK</span></span>|
| <span data-ttu-id="152f0-163">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="152f0-163">non-friend user</span></span>| <span data-ttu-id="152f0-164">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="152f0-164">everyone</span></span>| <span data-ttu-id="152f0-165">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-165">200 OK</span></span>|
| <span data-ttu-id="152f0-166">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="152f0-166">non-friend user</span></span>| <span data-ttu-id="152f0-167">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="152f0-167">friends only</span></span>| <span data-ttu-id="152f0-168">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-168">200 OK</span></span>|
| <span data-ttu-id="152f0-169">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="152f0-169">non-friend user</span></span>| <span data-ttu-id="152f0-170">ブロック</span><span class="sxs-lookup"><span data-stu-id="152f0-170">blocked</span></span>| <span data-ttu-id="152f0-171">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-171">200 OK</span></span>|
| <span data-ttu-id="152f0-172">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="152f0-172">third-party site</span></span>| <span data-ttu-id="152f0-173">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="152f0-173">everyone</span></span>| <span data-ttu-id="152f0-174">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-174">200 OK</span></span>|
| <span data-ttu-id="152f0-175">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="152f0-175">third-party site</span></span>| <span data-ttu-id="152f0-176">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="152f0-176">friends only</span></span>| <span data-ttu-id="152f0-177">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-177">200 OK</span></span>|
| <span data-ttu-id="152f0-178">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="152f0-178">third-party site</span></span>| <span data-ttu-id="152f0-179">ブロック</span><span class="sxs-lookup"><span data-stu-id="152f0-179">blocked</span></span>| <span data-ttu-id="152f0-180">200 OK</span><span class="sxs-lookup"><span data-stu-id="152f0-180">200 OK</span></span>|

<a id="ID4EVH"></a>


## <a name="required-request-headers"></a><span data-ttu-id="152f0-181">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="152f0-181">Required Request Headers</span></span>

| <span data-ttu-id="152f0-182">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="152f0-182">Header</span></span>| <span data-ttu-id="152f0-183">型</span><span class="sxs-lookup"><span data-stu-id="152f0-183">Type</span></span>| <span data-ttu-id="152f0-184">説明</span><span class="sxs-lookup"><span data-stu-id="152f0-184">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="152f0-185">Authorization</span><span class="sxs-lookup"><span data-stu-id="152f0-185">Authorization</span></span>| <span data-ttu-id="152f0-186">string</span><span class="sxs-lookup"><span data-stu-id="152f0-186">string</span></span>| <span data-ttu-id="152f0-187">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="152f0-187">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="152f0-188">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="152f0-188">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="152f0-189">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="152f0-189">x-xbl-contract-version</span></span>| <span data-ttu-id="152f0-190">string</span><span class="sxs-lookup"><span data-stu-id="152f0-190">string</span></span>| <span data-ttu-id="152f0-191">この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="152f0-191">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="152f0-192">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="152f0-192">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="152f0-193">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="152f0-193">Example values: 3, vnext.</span></span>|
| <span data-ttu-id="152f0-194">Accept</span><span class="sxs-lookup"><span data-stu-id="152f0-194">Accept</span></span>| <span data-ttu-id="152f0-195">string</span><span class="sxs-lookup"><span data-stu-id="152f0-195">string</span></span>| <span data-ttu-id="152f0-196">コンテンツの種類の受け入れられるします。</span><span class="sxs-lookup"><span data-stu-id="152f0-196">Content-Types that are acceptable.</span></span> <span data-ttu-id="152f0-197">プレゼンスでサポートされている 1 つだけがアプリケーション/json がヘッダーで指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="152f0-197">The only one supported by Presence is application/json, but it must be specified in the header.</span></span>|
| <span data-ttu-id="152f0-198">同意言語</span><span class="sxs-lookup"><span data-stu-id="152f0-198">Accept-Language</span></span>| <span data-ttu-id="152f0-199">string</span><span class="sxs-lookup"><span data-stu-id="152f0-199">string</span></span>| <span data-ttu-id="152f0-200">応答で文字列を許容できるロケールです。</span><span class="sxs-lookup"><span data-stu-id="152f0-200">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="152f0-201">値の例: EN-US にします。</span><span class="sxs-lookup"><span data-stu-id="152f0-201">Example values: en-US.</span></span>|
| <span data-ttu-id="152f0-202">Host</span><span class="sxs-lookup"><span data-stu-id="152f0-202">Host</span></span>| <span data-ttu-id="152f0-203">string</span><span class="sxs-lookup"><span data-stu-id="152f0-203">string</span></span>| <span data-ttu-id="152f0-204">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="152f0-204">Domain name of the server.</span></span> <span data-ttu-id="152f0-205">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="152f0-205">Example value: presencebeta.xboxlive.com.</span></span>|

<a id="ID4E1BAC"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="152f0-206">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="152f0-206">Optional Request Headers</span></span>

| <span data-ttu-id="152f0-207">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="152f0-207">Header</span></span>| <span data-ttu-id="152f0-208">型</span><span class="sxs-lookup"><span data-stu-id="152f0-208">Type</span></span>| <span data-ttu-id="152f0-209">説明</span><span class="sxs-lookup"><span data-stu-id="152f0-209">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="152f0-210">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="152f0-210">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="152f0-211">この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="152f0-211">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="152f0-212">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="152f0-212">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="152f0-213">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="152f0-213">Default value: 1.</span></span>|

<a id="ID4E1CAC"></a>


## <a name="request-body"></a><span data-ttu-id="152f0-214">要求本文</span><span class="sxs-lookup"><span data-stu-id="152f0-214">Request body</span></span>

<span data-ttu-id="152f0-215">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="152f0-215">No objects are sent in the body of this request.</span></span>

<a id="ID4EFDAC"></a>


## <a name="response-body"></a><span data-ttu-id="152f0-216">応答本文</span><span class="sxs-lookup"><span data-stu-id="152f0-216">Response body</span></span>

<a id="ID4ELDAC"></a>


### <a name="sample-response"></a><span data-ttu-id="152f0-217">応答の例</span><span class="sxs-lookup"><span data-stu-id="152f0-217">Sample response</span></span>

<span data-ttu-id="152f0-218">ユーザーの既存のレコードがない場合は、デバイスを持つレコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="152f0-218">If there is no existing record for the user, a record with no devices is returned.</span></span>


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


<a id="ID4EXDAC"></a>


## <a name="see-also"></a><span data-ttu-id="152f0-219">関連項目</span><span class="sxs-lookup"><span data-stu-id="152f0-219">See also</span></span>

<a id="ID4EZDAC"></a>


##### <a name="parent"></a><span data-ttu-id="152f0-220">Parent</span><span class="sxs-lookup"><span data-stu-id="152f0-220">Parent</span></span>

[<span data-ttu-id="152f0-221">/users/xuid({xuid})</span><span class="sxs-lookup"><span data-stu-id="152f0-221">/users/xuid({xuid})</span></span>](uri-usersxuid.md)
