---
title: GET (/users/{ownerId}/people/mute)
assetID: 49b6c830-95f7-3200-0e46-0a1af573971c
permalink: en-us/docs/xboxlive/rest/uri-privacyusersowneridpeoplemuteget.html
description: " GET (/users/{ownerId}/people/mute)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 94e2bf4d04619ffa3348ae08fc37964cdc58e7b5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661587"
---
# <a name="get-usersowneridpeoplemute"></a><span data-ttu-id="dafca-104">GET (/users/{ownerId}/people/mute)</span><span class="sxs-lookup"><span data-stu-id="dafca-104">GET (/users/{ownerId}/people/mute)</span></span>
<span data-ttu-id="dafca-105">ユーザーのミュートの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="dafca-105">Gets the mute list for a user.</span></span>

  * [<span data-ttu-id="dafca-106">注釈</span><span class="sxs-lookup"><span data-stu-id="dafca-106">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="dafca-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="dafca-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="dafca-108">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="dafca-108">Effect of privacy settings on resource</span></span>](#ID4EEB)
  * [<span data-ttu-id="dafca-109">承認</span><span class="sxs-lookup"><span data-stu-id="dafca-109">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="dafca-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="dafca-110">Required Request Headers</span></span>](#ID4ESC)
  * [<span data-ttu-id="dafca-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="dafca-111">Request body</span></span>](#ID4EPE)
  * [<span data-ttu-id="dafca-112">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="dafca-112">HTTP status codes</span></span>](#ID4E1E)
  * [<span data-ttu-id="dafca-113">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="dafca-113">Required Response Headers</span></span>](#ID4E3G)
  * [<span data-ttu-id="dafca-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="dafca-114">Response body</span></span>](#ID4ETAAC)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="dafca-115">注釈</span><span class="sxs-lookup"><span data-stu-id="dafca-115">Remarks</span></span>

<span data-ttu-id="dafca-116">この URI にターゲットを指定した場合、ユーザーがない場合、ユーザーがミュートの一覧で、空の場合のみ、そのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="dafca-116">If a target is given, this URI returns only that user if the user is on the mute list, or else empty if the user is not.</span></span>

<a id="ID4EZ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="dafca-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="dafca-117">URI parameters</span></span>

| <span data-ttu-id="dafca-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="dafca-118">Parameter</span></span>| <span data-ttu-id="dafca-119">種類</span><span class="sxs-lookup"><span data-stu-id="dafca-119">Type</span></span>| <span data-ttu-id="dafca-120">説明</span><span class="sxs-lookup"><span data-stu-id="dafca-120">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="dafca-121">ownerId</span><span class="sxs-lookup"><span data-stu-id="dafca-121">ownerId</span></span>| <span data-ttu-id="dafca-122">string</span><span class="sxs-lookup"><span data-stu-id="dafca-122">string</span></span>| <span data-ttu-id="dafca-123">必須。</span><span class="sxs-lookup"><span data-stu-id="dafca-123">Required.</span></span> <span data-ttu-id="dafca-124">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="dafca-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="dafca-125">使用可能な値は"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。</span><span class="sxs-lookup"><span data-stu-id="dafca-125">The possible values are "me", <code>xuid({xuid})</code>, or gt({gamertag}).</span></span> <span data-ttu-id="dafca-126">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="dafca-126">Must be the authenticated user.</span></span> <span data-ttu-id="dafca-127">値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。</span><span class="sxs-lookup"><span data-stu-id="dafca-127">Example values: <code>xuid(2603643534573581)</code>, <code>gt(SomeGamertag)</code>.</span></span> <span data-ttu-id="dafca-128">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="dafca-128">Maximum size: none.</span></span> |

<a id="ID4EEB"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="dafca-129">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="dafca-129">Effect of privacy settings on resource</span></span>

<span data-ttu-id="dafca-130">なし。</span><span class="sxs-lookup"><span data-stu-id="dafca-130">None.</span></span>

<a id="ID4ENB"></a>


## <a name="authorization"></a><span data-ttu-id="dafca-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="dafca-131">Authorization</span></span>

<span data-ttu-id="dafca-132">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="dafca-132">Authorization claims used</span></span> | <span data-ttu-id="dafca-133">要求</span><span class="sxs-lookup"><span data-stu-id="dafca-133">Claim</span></span>| <span data-ttu-id="dafca-134">種類</span><span class="sxs-lookup"><span data-stu-id="dafca-134">Type</span></span>| <span data-ttu-id="dafca-135">必須?</span><span class="sxs-lookup"><span data-stu-id="dafca-135">Required?</span></span>| <span data-ttu-id="dafca-136">値の例</span><span class="sxs-lookup"><span data-stu-id="dafca-136">Example value</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="dafca-137">xuid</span><span class="sxs-lookup"><span data-stu-id="dafca-137">Xuid</span></span>| <span data-ttu-id="dafca-138">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="dafca-138">64-bit signed integer</span></span>| <span data-ttu-id="dafca-139">○</span><span class="sxs-lookup"><span data-stu-id="dafca-139">yes</span></span>| <span data-ttu-id="dafca-140">1234567890</span><span class="sxs-lookup"><span data-stu-id="dafca-140">1234567890</span></span>|

<a id="ID4ESC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="dafca-141">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="dafca-141">Required Request Headers</span></span>

| <span data-ttu-id="dafca-142">Header</span><span class="sxs-lookup"><span data-stu-id="dafca-142">Header</span></span>| <span data-ttu-id="dafca-143">種類</span><span class="sxs-lookup"><span data-stu-id="dafca-143">Type</span></span>| <span data-ttu-id="dafca-144">説明</span><span class="sxs-lookup"><span data-stu-id="dafca-144">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="dafca-145">Authorization</span><span class="sxs-lookup"><span data-stu-id="dafca-145">Authorization</span></span> | <span data-ttu-id="dafca-146">string</span><span class="sxs-lookup"><span data-stu-id="dafca-146">string</span></span>| <span data-ttu-id="dafca-147">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="dafca-147">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="dafca-148">値の例:<code>Xauth=&lt;authtoken></code>します。</span><span class="sxs-lookup"><span data-stu-id="dafca-148">Example value: <code>Xauth=&lt;authtoken></code>.</span></span> <span data-ttu-id="dafca-149">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="dafca-149">Maximum size: none.</span></span>|
| <span data-ttu-id="dafca-150">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="dafca-150">X-RequestedServiceVersion</span></span>| <span data-ttu-id="dafca-151">string</span><span class="sxs-lookup"><span data-stu-id="dafca-151">string</span></span>| <span data-ttu-id="dafca-152">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="dafca-152">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="dafca-153">要求はのみにルーティングと、ヘッダー、承認トークンでクレームの妥当性を確認した後のサービスします。</span><span class="sxs-lookup"><span data-stu-id="dafca-153">The request will only be routed to that service after verifying the validity of the header, the claims in the authorization token, and so on.</span></span> <span data-ttu-id="dafca-154">値の例: <code>1</code>、<code>vnext</code>します。</span><span class="sxs-lookup"><span data-stu-id="dafca-154">Example values: <code>1</code>, <code>vnext</code>.</span></span> <span data-ttu-id="dafca-155">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="dafca-155">Maximum size: none.</span></span>|
| <span data-ttu-id="dafca-156">OK</span><span class="sxs-lookup"><span data-stu-id="dafca-156">Accept</span></span>| <span data-ttu-id="dafca-157">string</span><span class="sxs-lookup"><span data-stu-id="dafca-157">string</span></span>| <span data-ttu-id="dafca-158">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="dafca-158">Content-Types that are acceptable.</span></span> <span data-ttu-id="dafca-159">値の例:<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="dafca-159">Example value: <code>application/json</code>.</span></span> <span data-ttu-id="dafca-160">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="dafca-160">Maximum size: none.</span></span>|

<a id="ID4EPE"></a>


## <a name="request-body"></a><span data-ttu-id="dafca-161">要求本文</span><span class="sxs-lookup"><span data-stu-id="dafca-161">Request body</span></span>

<span data-ttu-id="dafca-162">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="dafca-162">No objects are sent in the body of this request.</span></span>

<a id="ID4E1E"></a>


## <a name="http-status-codes"></a><span data-ttu-id="dafca-163">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="dafca-163">HTTP status codes</span></span>

<span data-ttu-id="dafca-164">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="dafca-164">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="dafca-165">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="dafca-165">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="dafca-166">コード</span><span class="sxs-lookup"><span data-stu-id="dafca-166">Code</span></span>| <span data-ttu-id="dafca-167">理由語句</span><span class="sxs-lookup"><span data-stu-id="dafca-167">Reason phrase</span></span>| <span data-ttu-id="dafca-168">説明</span><span class="sxs-lookup"><span data-stu-id="dafca-168">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="dafca-169">200</span><span class="sxs-lookup"><span data-stu-id="dafca-169">200</span></span>| <span data-ttu-id="dafca-170">OK</span><span class="sxs-lookup"><span data-stu-id="dafca-170">OK</span></span>| <span data-ttu-id="dafca-171">ミュートのリストの要求が成功した場合。</span><span class="sxs-lookup"><span data-stu-id="dafca-171">Successful request for the mute list.</span></span>|
| <span data-ttu-id="dafca-172">400</span><span class="sxs-lookup"><span data-stu-id="dafca-172">400</span></span>| <span data-ttu-id="dafca-173">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="dafca-173">Bad Request</span></span>| <span data-ttu-id="dafca-174">URI で指定されたターゲットの ID が無効です。</span><span class="sxs-lookup"><span data-stu-id="dafca-174">The target ID specified in the URI is not valid.</span></span>|
| <span data-ttu-id="dafca-175">403</span><span class="sxs-lookup"><span data-stu-id="dafca-175">403</span></span>| <span data-ttu-id="dafca-176">Forbidden</span><span class="sxs-lookup"><span data-stu-id="dafca-176">Forbidden</span></span>| <span data-ttu-id="dafca-177">URI で指定された所有者は、認証されたユーザーではありません。</span><span class="sxs-lookup"><span data-stu-id="dafca-177">The owner specified in the URI is not the authenticated user.</span></span>|
| <span data-ttu-id="dafca-178">404</span><span class="sxs-lookup"><span data-stu-id="dafca-178">404</span></span>| <span data-ttu-id="dafca-179">検出不可</span><span class="sxs-lookup"><span data-stu-id="dafca-179">Not Found</span></span>| <span data-ttu-id="dafca-180">URI で指定された所有者が存在しません。</span><span class="sxs-lookup"><span data-stu-id="dafca-180">The owner specified in the URI does not exist.</span></span>|

<a id="ID4E3G"></a>


## <a name="required-response-headers"></a><span data-ttu-id="dafca-181">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="dafca-181">Required Response Headers</span></span>

| <span data-ttu-id="dafca-182">Header</span><span class="sxs-lookup"><span data-stu-id="dafca-182">Header</span></span>| <span data-ttu-id="dafca-183">種類</span><span class="sxs-lookup"><span data-stu-id="dafca-183">Type</span></span>| <span data-ttu-id="dafca-184">説明</span><span class="sxs-lookup"><span data-stu-id="dafca-184">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="dafca-185">Content-Type</span><span class="sxs-lookup"><span data-stu-id="dafca-185">Content-Type</span></span>| <span data-ttu-id="dafca-186">string</span><span class="sxs-lookup"><span data-stu-id="dafca-186">string</span></span>| <span data-ttu-id="dafca-187">要求の本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="dafca-187">The MIME type of the body of the request.</span></span> <span data-ttu-id="dafca-188">値の例: <code>application/json</code></span><span class="sxs-lookup"><span data-stu-id="dafca-188">Example value: <code>application/json</code></span></span>|
| <span data-ttu-id="dafca-189">Content-Length</span><span class="sxs-lookup"><span data-stu-id="dafca-189">Content-Length</span></span>| <span data-ttu-id="dafca-190">string</span><span class="sxs-lookup"><span data-stu-id="dafca-190">string</span></span>| <span data-ttu-id="dafca-191">応答で送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="dafca-191">The number of bytes being sent in the response.</span></span> <span data-ttu-id="dafca-192">値の例:34</span><span class="sxs-lookup"><span data-stu-id="dafca-192">Example value: 34</span></span>|
| <span data-ttu-id="dafca-193">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="dafca-193">Cache-Control</span></span>| <span data-ttu-id="dafca-194">string</span><span class="sxs-lookup"><span data-stu-id="dafca-194">string</span></span>| <span data-ttu-id="dafca-195">キャッシュの動作を指定する、サーバーから正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="dafca-195">Polite request from the server to specify caching behavior.</span></span> <span data-ttu-id="dafca-196">例: <code>no-cache, no-store</code></span><span class="sxs-lookup"><span data-stu-id="dafca-196">Example: <code>no-cache, no-store</code></span></span>|

<a id="ID4ETAAC"></a>


## <a name="response-body"></a><span data-ttu-id="dafca-197">応答本文</span><span class="sxs-lookup"><span data-stu-id="dafca-197">Response body</span></span>

<a id="ID4EZAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="dafca-198">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="dafca-198">Sample response</span></span>

<span data-ttu-id="dafca-199">参照してください[UserList](../../json/json-userlist.md)します。</span><span class="sxs-lookup"><span data-stu-id="dafca-199">See [UserList](../../json/json-userlist.md).</span></span>


```cpp
{
    "users":
    [
        { "xuid":"12345" },
        { "xuid":"23456" }
    ]
}

```


<a id="ID4EJBAC"></a>


## <a name="see-also"></a><span data-ttu-id="dafca-200">関連項目</span><span class="sxs-lookup"><span data-stu-id="dafca-200">See also</span></span>

<a id="ID4ELBAC"></a>


##### <a name="parent"></a><span data-ttu-id="dafca-201">Parent</span><span class="sxs-lookup"><span data-stu-id="dafca-201">Parent</span></span>

[<span data-ttu-id="dafca-202">/users/{ownerId}/people/mute</span><span class="sxs-lookup"><span data-stu-id="dafca-202">/users/{ownerId}/people/mute</span></span>](uri-privacyusersowneridpeoplemute.md)
