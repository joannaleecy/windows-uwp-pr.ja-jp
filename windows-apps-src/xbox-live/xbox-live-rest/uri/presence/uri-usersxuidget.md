---
title: GET (/users/xuid({xuid}))
assetID: c97ef943-8bea-8a41-90d7-faea874284c8
permalink: en-us/docs/xboxlive/rest/uri-usersxuidget.html
description: " GET (/users/xuid({xuid}))"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5fcc5d3b6a172eccab0656da39e6896b4df50840
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650927"
---
# <a name="get-usersxuidxuid"></a><span data-ttu-id="42dd4-104">GET (/users/xuid({xuid}))</span><span class="sxs-lookup"><span data-stu-id="42dd4-104">GET (/users/xuid({xuid}))</span></span>
<span data-ttu-id="42dd4-105">別のユーザーまたはクライアントのプレゼンスを検出します。</span><span class="sxs-lookup"><span data-stu-id="42dd4-105">Discover the presence of another user or client.</span></span>
<span data-ttu-id="42dd4-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="42dd4-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>

  * [<span data-ttu-id="42dd4-107">注釈</span><span class="sxs-lookup"><span data-stu-id="42dd4-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="42dd4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="42dd4-108">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="42dd4-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="42dd4-109">Query string parameters</span></span>](#ID4EOB)
  * [<span data-ttu-id="42dd4-110">承認</span><span class="sxs-lookup"><span data-stu-id="42dd4-110">Authorization</span></span>](#ID4E4C)
  * [<span data-ttu-id="42dd4-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="42dd4-111">Effect of privacy settings on resource</span></span>](#ID4EAE)
  * [<span data-ttu-id="42dd4-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42dd4-112">Required Request Headers</span></span>](#ID4EVH)
  * [<span data-ttu-id="42dd4-113">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42dd4-113">Optional Request Headers</span></span>](#ID4E1BAC)
  * [<span data-ttu-id="42dd4-114">要求本文</span><span class="sxs-lookup"><span data-stu-id="42dd4-114">Request body</span></span>](#ID4E1CAC)
  * [<span data-ttu-id="42dd4-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="42dd4-115">Response body</span></span>](#ID4EFDAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="42dd4-116">注釈</span><span class="sxs-lookup"><span data-stu-id="42dd4-116">Remarks</span></span>

<span data-ttu-id="42dd4-117">一部を提供する応答をフィルター処理すること、 [PresenceRecord](../../json/json-presencerecord.md)コンシューマーはオブジェクト全体に興味がない場合。</span><span class="sxs-lookup"><span data-stu-id="42dd4-117">The response can be filtered to provide part of the [PresenceRecord](../../json/json-presencerecord.md) if the consumer is not interested in the entire object.</span></span>

> [!NOTE] 
> <span data-ttu-id="42dd4-118">返されるデータは、プライバシーとコンテンツの分離の規則によって制限されます。</span><span class="sxs-lookup"><span data-stu-id="42dd4-118">The data returned is constrained by privacy and content isolation rules.</span></span>



<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="42dd4-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="42dd4-119">URI parameters</span></span>

| <span data-ttu-id="42dd4-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="42dd4-120">Parameter</span></span>| <span data-ttu-id="42dd4-121">種類</span><span class="sxs-lookup"><span data-stu-id="42dd4-121">Type</span></span>| <span data-ttu-id="42dd4-122">説明</span><span class="sxs-lookup"><span data-stu-id="42dd4-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="42dd4-123">xuid</span><span class="sxs-lookup"><span data-stu-id="42dd4-123">xuid</span></span>| <span data-ttu-id="42dd4-124">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="42dd4-124">64-bit unsigned integer</span></span>| <span data-ttu-id="42dd4-125">Xbox ユーザー ID (XUID) の対象ユーザーです。</span><span class="sxs-lookup"><span data-stu-id="42dd4-125">Xbox User ID (XUID) of the target user.</span></span>|

<a id="ID4EOB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="42dd4-126">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="42dd4-126">Query string parameters</span></span>

| <span data-ttu-id="42dd4-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="42dd4-127">Parameter</span></span>| <span data-ttu-id="42dd4-128">種類</span><span class="sxs-lookup"><span data-stu-id="42dd4-128">Type</span></span>| <span data-ttu-id="42dd4-129">説明</span><span class="sxs-lookup"><span data-stu-id="42dd4-129">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42dd4-130">level</span><span class="sxs-lookup"><span data-stu-id="42dd4-130">level</span></span>| <span data-ttu-id="42dd4-131">string</span><span class="sxs-lookup"><span data-stu-id="42dd4-131">string</span></span>| <span data-ttu-id="42dd4-132">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="42dd4-132">Optional.</span></span> <ul><li><span data-ttu-id="42dd4-133"><b>ユーザー</b>:ユーザー ノードのみを返します。</span><span class="sxs-lookup"><span data-stu-id="42dd4-133"><b>user</b>: Returns only the user node.</span></span></li><li><span data-ttu-id="42dd4-134"><b>デバイス</b>:ノードとデバイスのノードをユーザーに返されます。</span><span class="sxs-lookup"><span data-stu-id="42dd4-134"><b>device</b>: Returns user node and device nodes.</span></span></li><li><span data-ttu-id="42dd4-135"><b>タイトル</b>:既定。</span><span class="sxs-lookup"><span data-stu-id="42dd4-135"><b>title</b>: Default.</span></span> <span data-ttu-id="42dd4-136">アクティビティを除くツリー全体を返します。</span><span class="sxs-lookup"><span data-stu-id="42dd4-136">Returns the whole tree except activity.</span></span></li><li><span data-ttu-id="42dd4-137"><b>すべて</b>:アクティビティ レベルのプレゼンスを含む、ツリー全体を返します。</span><span class="sxs-lookup"><span data-stu-id="42dd4-137"><b>all</b>: Returns the whole tree, including activity-level presence.</span></span></li></ul> |

<a id="ID4E4C"></a>


## <a name="authorization"></a><span data-ttu-id="42dd4-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="42dd4-138">Authorization</span></span>

| <span data-ttu-id="42dd4-139">種類</span><span class="sxs-lookup"><span data-stu-id="42dd4-139">Type</span></span>| <span data-ttu-id="42dd4-140">必須</span><span class="sxs-lookup"><span data-stu-id="42dd4-140">Required</span></span>| <span data-ttu-id="42dd4-141">説明</span><span class="sxs-lookup"><span data-stu-id="42dd4-141">Description</span></span>| <span data-ttu-id="42dd4-142">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="42dd4-142">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42dd4-143">XUID</span><span class="sxs-lookup"><span data-stu-id="42dd4-143">XUID</span></span>| <span data-ttu-id="42dd4-144">〇</span><span class="sxs-lookup"><span data-stu-id="42dd4-144">Yes</span></span>| <span data-ttu-id="42dd4-145">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="42dd4-145">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="42dd4-146">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="42dd4-146">403 Forbidden</span></span>|

<a id="ID4EAE"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="42dd4-147">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="42dd4-147">Effect of privacy settings on resource</span></span>

<span data-ttu-id="42dd4-148">このメソッドは常に、200 を返しますが、応答本文のコンテンツを返さなかった可能性があります。</span><span class="sxs-lookup"><span data-stu-id="42dd4-148">This method always returns 200 OK, but might not return content in the response body.</span></span>

| <span data-ttu-id="42dd4-149">要求元のユーザー</span><span class="sxs-lookup"><span data-stu-id="42dd4-149">Requesting User</span></span>| <span data-ttu-id="42dd4-150">ターゲット ユーザーのプライバシーの設定</span><span class="sxs-lookup"><span data-stu-id="42dd4-150">Target User's Privacy Setting</span></span>| <span data-ttu-id="42dd4-151">動作</span><span class="sxs-lookup"><span data-stu-id="42dd4-151">Behavior</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42dd4-152">Me</span><span class="sxs-lookup"><span data-stu-id="42dd4-152">me</span></span>| -| <span data-ttu-id="42dd4-153">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-153">200 OK</span></span>|
| <span data-ttu-id="42dd4-154">friend</span><span class="sxs-lookup"><span data-stu-id="42dd4-154">friend</span></span>| <span data-ttu-id="42dd4-155">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="42dd4-155">everyone</span></span>| <span data-ttu-id="42dd4-156">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-156">200 OK</span></span>|
| <span data-ttu-id="42dd4-157">friend</span><span class="sxs-lookup"><span data-stu-id="42dd4-157">friend</span></span>| <span data-ttu-id="42dd4-158">友達のみ</span><span class="sxs-lookup"><span data-stu-id="42dd4-158">friends only</span></span>| <span data-ttu-id="42dd4-159">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-159">200 OK</span></span>|
| <span data-ttu-id="42dd4-160">friend</span><span class="sxs-lookup"><span data-stu-id="42dd4-160">friend</span></span>| <span data-ttu-id="42dd4-161">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="42dd4-161">blocked</span></span>| <span data-ttu-id="42dd4-162">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-162">200 OK</span></span>|
| <span data-ttu-id="42dd4-163">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="42dd4-163">non-friend user</span></span>| <span data-ttu-id="42dd4-164">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="42dd4-164">everyone</span></span>| <span data-ttu-id="42dd4-165">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-165">200 OK</span></span>|
| <span data-ttu-id="42dd4-166">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="42dd4-166">non-friend user</span></span>| <span data-ttu-id="42dd4-167">友達のみ</span><span class="sxs-lookup"><span data-stu-id="42dd4-167">friends only</span></span>| <span data-ttu-id="42dd4-168">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-168">200 OK</span></span>|
| <span data-ttu-id="42dd4-169">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="42dd4-169">non-friend user</span></span>| <span data-ttu-id="42dd4-170">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="42dd4-170">blocked</span></span>| <span data-ttu-id="42dd4-171">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-171">200 OK</span></span>|
| <span data-ttu-id="42dd4-172">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="42dd4-172">third-party site</span></span>| <span data-ttu-id="42dd4-173">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="42dd4-173">everyone</span></span>| <span data-ttu-id="42dd4-174">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-174">200 OK</span></span>|
| <span data-ttu-id="42dd4-175">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="42dd4-175">third-party site</span></span>| <span data-ttu-id="42dd4-176">友達のみ</span><span class="sxs-lookup"><span data-stu-id="42dd4-176">friends only</span></span>| <span data-ttu-id="42dd4-177">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-177">200 OK</span></span>|
| <span data-ttu-id="42dd4-178">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="42dd4-178">third-party site</span></span>| <span data-ttu-id="42dd4-179">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="42dd4-179">blocked</span></span>| <span data-ttu-id="42dd4-180">200 OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-180">200 OK</span></span>|

<a id="ID4EVH"></a>


## <a name="required-request-headers"></a><span data-ttu-id="42dd4-181">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42dd4-181">Required Request Headers</span></span>

| <span data-ttu-id="42dd4-182">Header</span><span class="sxs-lookup"><span data-stu-id="42dd4-182">Header</span></span>| <span data-ttu-id="42dd4-183">種類</span><span class="sxs-lookup"><span data-stu-id="42dd4-183">Type</span></span>| <span data-ttu-id="42dd4-184">説明</span><span class="sxs-lookup"><span data-stu-id="42dd4-184">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42dd4-185">Authorization</span><span class="sxs-lookup"><span data-stu-id="42dd4-185">Authorization</span></span>| <span data-ttu-id="42dd4-186">string</span><span class="sxs-lookup"><span data-stu-id="42dd4-186">string</span></span>| <span data-ttu-id="42dd4-187">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="42dd4-187">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="42dd4-188">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="42dd4-188">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="42dd4-189">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="42dd4-189">x-xbl-contract-version</span></span>| <span data-ttu-id="42dd4-190">string</span><span class="sxs-lookup"><span data-stu-id="42dd4-190">string</span></span>| <span data-ttu-id="42dd4-191">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="42dd4-191">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="42dd4-192">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="42dd4-192">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="42dd4-193">値の例:3、vnext。</span><span class="sxs-lookup"><span data-stu-id="42dd4-193">Example values: 3, vnext.</span></span>|
| <span data-ttu-id="42dd4-194">OK</span><span class="sxs-lookup"><span data-stu-id="42dd4-194">Accept</span></span>| <span data-ttu-id="42dd4-195">string</span><span class="sxs-lookup"><span data-stu-id="42dd4-195">string</span></span>| <span data-ttu-id="42dd4-196">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="42dd4-196">Content-Types that are acceptable.</span></span> <span data-ttu-id="42dd4-197">存在することによってサポートされている唯一は、application/json がヘッダーに指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="42dd4-197">The only one supported by Presence is application/json, but it must be specified in the header.</span></span>|
| <span data-ttu-id="42dd4-198">Accept Language</span><span class="sxs-lookup"><span data-stu-id="42dd4-198">Accept-Language</span></span>| <span data-ttu-id="42dd4-199">string</span><span class="sxs-lookup"><span data-stu-id="42dd4-199">string</span></span>| <span data-ttu-id="42dd4-200">応答内の文字列に対して許容されるロケール。</span><span class="sxs-lookup"><span data-stu-id="42dd4-200">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="42dd4-201">値の例: en-us (英語)。</span><span class="sxs-lookup"><span data-stu-id="42dd4-201">Example values: en-US.</span></span>|
| <span data-ttu-id="42dd4-202">Host</span><span class="sxs-lookup"><span data-stu-id="42dd4-202">Host</span></span>| <span data-ttu-id="42dd4-203">string</span><span class="sxs-lookup"><span data-stu-id="42dd4-203">string</span></span>| <span data-ttu-id="42dd4-204">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="42dd4-204">Domain name of the server.</span></span> <span data-ttu-id="42dd4-205">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="42dd4-205">Example value: presencebeta.xboxlive.com.</span></span>|

<a id="ID4E1BAC"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="42dd4-206">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42dd4-206">Optional Request Headers</span></span>

| <span data-ttu-id="42dd4-207">Header</span><span class="sxs-lookup"><span data-stu-id="42dd4-207">Header</span></span>| <span data-ttu-id="42dd4-208">種類</span><span class="sxs-lookup"><span data-stu-id="42dd4-208">Type</span></span>| <span data-ttu-id="42dd4-209">説明</span><span class="sxs-lookup"><span data-stu-id="42dd4-209">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42dd4-210">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="42dd4-210">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="42dd4-211">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="42dd4-211">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="42dd4-212">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="42dd4-212">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="42dd4-213">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="42dd4-213">Default value: 1.</span></span>|

<a id="ID4E1CAC"></a>


## <a name="request-body"></a><span data-ttu-id="42dd4-214">要求本文</span><span class="sxs-lookup"><span data-stu-id="42dd4-214">Request body</span></span>

<span data-ttu-id="42dd4-215">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="42dd4-215">No objects are sent in the body of this request.</span></span>

<a id="ID4EFDAC"></a>


## <a name="response-body"></a><span data-ttu-id="42dd4-216">応答本文</span><span class="sxs-lookup"><span data-stu-id="42dd4-216">Response body</span></span>

<a id="ID4ELDAC"></a>


### <a name="sample-response"></a><span data-ttu-id="42dd4-217">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="42dd4-217">Sample response</span></span>

<span data-ttu-id="42dd4-218">ユーザーの既存のレコードはありませんが、デバイスのレコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="42dd4-218">If there is no existing record for the user, a record with no devices is returned.</span></span>


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


## <a name="see-also"></a><span data-ttu-id="42dd4-219">関連項目</span><span class="sxs-lookup"><span data-stu-id="42dd4-219">See also</span></span>

<a id="ID4EZDAC"></a>


##### <a name="parent"></a><span data-ttu-id="42dd4-220">Parent</span><span class="sxs-lookup"><span data-stu-id="42dd4-220">Parent</span></span>

[<span data-ttu-id="42dd4-221">/users/xuid({xuid})</span><span class="sxs-lookup"><span data-stu-id="42dd4-221">/users/xuid({xuid})</span></span>](uri-usersxuid.md)
