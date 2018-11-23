---
title: GET (/users/{ownerId}/people/mute)
assetID: 49b6c830-95f7-3200-0e46-0a1af573971c
permalink: en-us/docs/xboxlive/rest/uri-privacyusersowneridpeoplemuteget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/people/mute)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fd9c5a1f95873028d38dfacea9d91393ab7dba12
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7575889"
---
# <a name="get-usersowneridpeoplemute"></a><span data-ttu-id="06019-104">GET (/users/{ownerId}/people/mute)</span><span class="sxs-lookup"><span data-stu-id="06019-104">GET (/users/{ownerId}/people/mute)</span></span>
<span data-ttu-id="06019-105">ユーザーのミュートの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="06019-105">Gets the mute list for a user.</span></span>

  * [<span data-ttu-id="06019-106">注釈</span><span class="sxs-lookup"><span data-stu-id="06019-106">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="06019-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="06019-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="06019-108">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="06019-108">Effect of privacy settings on resource</span></span>](#ID4EEB)
  * [<span data-ttu-id="06019-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="06019-109">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="06019-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="06019-110">Required Request Headers</span></span>](#ID4ESC)
  * [<span data-ttu-id="06019-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="06019-111">Request body</span></span>](#ID4EPE)
  * [<span data-ttu-id="06019-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="06019-112">HTTP status codes</span></span>](#ID4E1E)
  * [<span data-ttu-id="06019-113">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="06019-113">Required Response Headers</span></span>](#ID4E3G)
  * [<span data-ttu-id="06019-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="06019-114">Response body</span></span>](#ID4ETAAC)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="06019-115">注釈</span><span class="sxs-lookup"><span data-stu-id="06019-115">Remarks</span></span>

<span data-ttu-id="06019-116">この URI にターゲットを指定すると、ユーザーがない場合、ユーザーがミュートの一覧で、空の場合のみ、そのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="06019-116">If a target is given, this URI returns only that user if the user is on the mute list, or else empty if the user is not.</span></span>

<a id="ID4EZ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="06019-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="06019-117">URI parameters</span></span>

| <span data-ttu-id="06019-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="06019-118">Parameter</span></span>| <span data-ttu-id="06019-119">型</span><span class="sxs-lookup"><span data-stu-id="06019-119">Type</span></span>| <span data-ttu-id="06019-120">説明</span><span class="sxs-lookup"><span data-stu-id="06019-120">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="06019-121">ownerId</span><span class="sxs-lookup"><span data-stu-id="06019-121">ownerId</span></span>| <span data-ttu-id="06019-122">string</span><span class="sxs-lookup"><span data-stu-id="06019-122">string</span></span>| <span data-ttu-id="06019-123">必須。</span><span class="sxs-lookup"><span data-stu-id="06019-123">Required.</span></span> <span data-ttu-id="06019-124">そのリソースにアクセスしているユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="06019-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="06019-125">可能な値は、"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。</span><span class="sxs-lookup"><span data-stu-id="06019-125">The possible values are "me", <code>xuid({xuid})</code>, or gt({gamertag}).</span></span> <span data-ttu-id="06019-126">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="06019-126">Must be the authenticated user.</span></span> <span data-ttu-id="06019-127">値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。</span><span class="sxs-lookup"><span data-stu-id="06019-127">Example values: <code>xuid(2603643534573581)</code>, <code>gt(SomeGamertag)</code>.</span></span> <span data-ttu-id="06019-128">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="06019-128">Maximum size: none.</span></span> |

<a id="ID4EEB"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="06019-129">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="06019-129">Effect of privacy settings on resource</span></span>

<span data-ttu-id="06019-130">なし。</span><span class="sxs-lookup"><span data-stu-id="06019-130">None.</span></span>

<a id="ID4ENB"></a>


## <a name="authorization"></a><span data-ttu-id="06019-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="06019-131">Authorization</span></span>

<span data-ttu-id="06019-132">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="06019-132">Authorization claims used</span></span> | <span data-ttu-id="06019-133">要求</span><span class="sxs-lookup"><span data-stu-id="06019-133">Claim</span></span>| <span data-ttu-id="06019-134">種類</span><span class="sxs-lookup"><span data-stu-id="06019-134">Type</span></span>| <span data-ttu-id="06019-135">必須?</span><span class="sxs-lookup"><span data-stu-id="06019-135">Required?</span></span>| <span data-ttu-id="06019-136">値の例</span><span class="sxs-lookup"><span data-stu-id="06019-136">Example value</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="06019-137">Xuid</span><span class="sxs-lookup"><span data-stu-id="06019-137">Xuid</span></span>| <span data-ttu-id="06019-138">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="06019-138">64-bit signed integer</span></span>| <span data-ttu-id="06019-139">必須</span><span class="sxs-lookup"><span data-stu-id="06019-139">yes</span></span>| <span data-ttu-id="06019-140">1234567890</span><span class="sxs-lookup"><span data-stu-id="06019-140">1234567890</span></span>|

<a id="ID4ESC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="06019-141">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="06019-141">Required Request Headers</span></span>

| <span data-ttu-id="06019-142">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="06019-142">Header</span></span>| <span data-ttu-id="06019-143">型</span><span class="sxs-lookup"><span data-stu-id="06019-143">Type</span></span>| <span data-ttu-id="06019-144">説明</span><span class="sxs-lookup"><span data-stu-id="06019-144">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="06019-145">Authorization</span><span class="sxs-lookup"><span data-stu-id="06019-145">Authorization</span></span> | <span data-ttu-id="06019-146">string</span><span class="sxs-lookup"><span data-stu-id="06019-146">string</span></span>| <span data-ttu-id="06019-147">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="06019-147">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="06019-148">値の例:<code>Xauth=&lt;authtoken></code>します。</span><span class="sxs-lookup"><span data-stu-id="06019-148">Example value: <code>Xauth=&lt;authtoken></code>.</span></span> <span data-ttu-id="06019-149">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="06019-149">Maximum size: none.</span></span>|
| <span data-ttu-id="06019-150">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="06019-150">X-RequestedServiceVersion</span></span>| <span data-ttu-id="06019-151">string</span><span class="sxs-lookup"><span data-stu-id="06019-151">string</span></span>| <span data-ttu-id="06019-152">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="06019-152">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="06019-153">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="06019-153">The request will only be routed to that service after verifying the validity of the header, the claims in the authorization token, and so on.</span></span> <span data-ttu-id="06019-154">値の例: <code>1</code>、<code>vnext</code>します。</span><span class="sxs-lookup"><span data-stu-id="06019-154">Example values: <code>1</code>, <code>vnext</code>.</span></span> <span data-ttu-id="06019-155">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="06019-155">Maximum size: none.</span></span>|
| <span data-ttu-id="06019-156">Accept</span><span class="sxs-lookup"><span data-stu-id="06019-156">Accept</span></span>| <span data-ttu-id="06019-157">string</span><span class="sxs-lookup"><span data-stu-id="06019-157">string</span></span>| <span data-ttu-id="06019-158">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="06019-158">Content-Types that are acceptable.</span></span> <span data-ttu-id="06019-159">値の例:<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="06019-159">Example value: <code>application/json</code>.</span></span> <span data-ttu-id="06019-160">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="06019-160">Maximum size: none.</span></span>|

<a id="ID4EPE"></a>


## <a name="request-body"></a><span data-ttu-id="06019-161">要求本文</span><span class="sxs-lookup"><span data-stu-id="06019-161">Request body</span></span>

<span data-ttu-id="06019-162">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="06019-162">No objects are sent in the body of this request.</span></span>

<a id="ID4E1E"></a>


## <a name="http-status-codes"></a><span data-ttu-id="06019-163">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="06019-163">HTTP status codes</span></span>

<span data-ttu-id="06019-164">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="06019-164">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="06019-165">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="06019-165">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="06019-166">コード</span><span class="sxs-lookup"><span data-stu-id="06019-166">Code</span></span>| <span data-ttu-id="06019-167">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="06019-167">Reason phrase</span></span>| <span data-ttu-id="06019-168">説明</span><span class="sxs-lookup"><span data-stu-id="06019-168">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="06019-169">200</span><span class="sxs-lookup"><span data-stu-id="06019-169">200</span></span>| <span data-ttu-id="06019-170">OK</span><span class="sxs-lookup"><span data-stu-id="06019-170">OK</span></span>| <span data-ttu-id="06019-171">ミュートの一覧については要求が成功した場合。</span><span class="sxs-lookup"><span data-stu-id="06019-171">Successful request for the mute list.</span></span>|
| <span data-ttu-id="06019-172">400</span><span class="sxs-lookup"><span data-stu-id="06019-172">400</span></span>| <span data-ttu-id="06019-173">Bad Request</span><span class="sxs-lookup"><span data-stu-id="06019-173">Bad Request</span></span>| <span data-ttu-id="06019-174">URI で指定されたターゲット ID が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="06019-174">The target ID specified in the URI is not valid.</span></span>|
| <span data-ttu-id="06019-175">403</span><span class="sxs-lookup"><span data-stu-id="06019-175">403</span></span>| <span data-ttu-id="06019-176">Forbidden</span><span class="sxs-lookup"><span data-stu-id="06019-176">Forbidden</span></span>| <span data-ttu-id="06019-177">URI で指定された所有者は、認証されたユーザーではありません。</span><span class="sxs-lookup"><span data-stu-id="06019-177">The owner specified in the URI is not the authenticated user.</span></span>|
| <span data-ttu-id="06019-178">404</span><span class="sxs-lookup"><span data-stu-id="06019-178">404</span></span>| <span data-ttu-id="06019-179">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="06019-179">Not Found</span></span>| <span data-ttu-id="06019-180">URI で指定された所有者は存在しません。</span><span class="sxs-lookup"><span data-stu-id="06019-180">The owner specified in the URI does not exist.</span></span>|

<a id="ID4E3G"></a>


## <a name="required-response-headers"></a><span data-ttu-id="06019-181">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="06019-181">Required Response Headers</span></span>

| <span data-ttu-id="06019-182">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="06019-182">Header</span></span>| <span data-ttu-id="06019-183">型</span><span class="sxs-lookup"><span data-stu-id="06019-183">Type</span></span>| <span data-ttu-id="06019-184">説明</span><span class="sxs-lookup"><span data-stu-id="06019-184">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="06019-185">Content-Type</span><span class="sxs-lookup"><span data-stu-id="06019-185">Content-Type</span></span>| <span data-ttu-id="06019-186">string</span><span class="sxs-lookup"><span data-stu-id="06019-186">string</span></span>| <span data-ttu-id="06019-187">要求の本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="06019-187">The MIME type of the body of the request.</span></span> <span data-ttu-id="06019-188">値の例:</span><span class="sxs-lookup"><span data-stu-id="06019-188">Example value:</span></span> <code>application/json</code>|
| <span data-ttu-id="06019-189">Content-Length</span><span class="sxs-lookup"><span data-stu-id="06019-189">Content-Length</span></span>| <span data-ttu-id="06019-190">string</span><span class="sxs-lookup"><span data-stu-id="06019-190">string</span></span>| <span data-ttu-id="06019-191">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="06019-191">The number of bytes being sent in the response.</span></span> <span data-ttu-id="06019-192">値の例: 34</span><span class="sxs-lookup"><span data-stu-id="06019-192">Example value: 34</span></span>|
| <span data-ttu-id="06019-193">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="06019-193">Cache-Control</span></span>| <span data-ttu-id="06019-194">string</span><span class="sxs-lookup"><span data-stu-id="06019-194">string</span></span>| <span data-ttu-id="06019-195">キャッシュ動作を指定する、サーバーからていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="06019-195">Polite request from the server to specify caching behavior.</span></span> <span data-ttu-id="06019-196">例:</span><span class="sxs-lookup"><span data-stu-id="06019-196">Example:</span></span> <code>no-cache, no-store</code>|

<a id="ID4ETAAC"></a>


## <a name="response-body"></a><span data-ttu-id="06019-197">応答本文</span><span class="sxs-lookup"><span data-stu-id="06019-197">Response body</span></span>

<a id="ID4EZAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="06019-198">応答の例</span><span class="sxs-lookup"><span data-stu-id="06019-198">Sample response</span></span>

<span data-ttu-id="06019-199">[UserList](../../json/json-userlist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="06019-199">See [UserList](../../json/json-userlist.md).</span></span>


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


## <a name="see-also"></a><span data-ttu-id="06019-200">関連項目</span><span class="sxs-lookup"><span data-stu-id="06019-200">See also</span></span>

<a id="ID4ELBAC"></a>


##### <a name="parent"></a><span data-ttu-id="06019-201">Parent</span><span class="sxs-lookup"><span data-stu-id="06019-201">Parent</span></span>

[<span data-ttu-id="06019-202">/users/{ownerId}/people/mute</span><span class="sxs-lookup"><span data-stu-id="06019-202">/users/{ownerId}/people/mute</span></span>](uri-privacyusersowneridpeoplemute.md)
