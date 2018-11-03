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
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5968575"
---
# <a name="get-usersowneridpeoplemute"></a><span data-ttu-id="2b9e1-104">GET (/users/{ownerId}/people/mute)</span><span class="sxs-lookup"><span data-stu-id="2b9e1-104">GET (/users/{ownerId}/people/mute)</span></span>
<span data-ttu-id="2b9e1-105">ユーザーのミュートの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-105">Gets the mute list for a user.</span></span>

  * [<span data-ttu-id="2b9e1-106">注釈</span><span class="sxs-lookup"><span data-stu-id="2b9e1-106">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="2b9e1-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2b9e1-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="2b9e1-108">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="2b9e1-108">Effect of privacy settings on resource</span></span>](#ID4EEB)
  * [<span data-ttu-id="2b9e1-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="2b9e1-109">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="2b9e1-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2b9e1-110">Required Request Headers</span></span>](#ID4ESC)
  * [<span data-ttu-id="2b9e1-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="2b9e1-111">Request body</span></span>](#ID4EPE)
  * [<span data-ttu-id="2b9e1-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="2b9e1-112">HTTP status codes</span></span>](#ID4E1E)
  * [<span data-ttu-id="2b9e1-113">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2b9e1-113">Required Response Headers</span></span>](#ID4E3G)
  * [<span data-ttu-id="2b9e1-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="2b9e1-114">Response body</span></span>](#ID4ETAAC)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="2b9e1-115">注釈</span><span class="sxs-lookup"><span data-stu-id="2b9e1-115">Remarks</span></span>

<span data-ttu-id="2b9e1-116">ターゲットを指定すると場合、この URI は、ユーザーがない場合、ユーザーがミュートの一覧で、空の場合、そのユーザーのみを返します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-116">If a target is given, this URI returns only that user if the user is on the mute list, or else empty if the user is not.</span></span>

<a id="ID4EZ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="2b9e1-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2b9e1-117">URI parameters</span></span>

| <span data-ttu-id="2b9e1-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2b9e1-118">Parameter</span></span>| <span data-ttu-id="2b9e1-119">型</span><span class="sxs-lookup"><span data-stu-id="2b9e1-119">Type</span></span>| <span data-ttu-id="2b9e1-120">説明</span><span class="sxs-lookup"><span data-stu-id="2b9e1-120">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="2b9e1-121">ownerId</span><span class="sxs-lookup"><span data-stu-id="2b9e1-121">ownerId</span></span>| <span data-ttu-id="2b9e1-122">string</span><span class="sxs-lookup"><span data-stu-id="2b9e1-122">string</span></span>| <span data-ttu-id="2b9e1-123">必須。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-123">Required.</span></span> <span data-ttu-id="2b9e1-124">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-124">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="2b9e1-125">設定可能な値は"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-125">The possible values are "me", <code>xuid({xuid})</code>, or gt({gamertag}).</span></span> <span data-ttu-id="2b9e1-126">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-126">Must be the authenticated user.</span></span> <span data-ttu-id="2b9e1-127">値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-127">Example values: <code>xuid(2603643534573581)</code>, <code>gt(SomeGamertag)</code>.</span></span> <span data-ttu-id="2b9e1-128">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-128">Maximum size: none.</span></span> |

<a id="ID4EEB"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="2b9e1-129">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="2b9e1-129">Effect of privacy settings on resource</span></span>

<span data-ttu-id="2b9e1-130">なし。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-130">None.</span></span>

<a id="ID4ENB"></a>


## <a name="authorization"></a><span data-ttu-id="2b9e1-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="2b9e1-131">Authorization</span></span>

<span data-ttu-id="2b9e1-132">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="2b9e1-132">Authorization claims used</span></span> | <span data-ttu-id="2b9e1-133">要求</span><span class="sxs-lookup"><span data-stu-id="2b9e1-133">Claim</span></span>| <span data-ttu-id="2b9e1-134">種類</span><span class="sxs-lookup"><span data-stu-id="2b9e1-134">Type</span></span>| <span data-ttu-id="2b9e1-135">必須?</span><span class="sxs-lookup"><span data-stu-id="2b9e1-135">Required?</span></span>| <span data-ttu-id="2b9e1-136">値の例</span><span class="sxs-lookup"><span data-stu-id="2b9e1-136">Example value</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2b9e1-137">Xuid</span><span class="sxs-lookup"><span data-stu-id="2b9e1-137">Xuid</span></span>| <span data-ttu-id="2b9e1-138">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="2b9e1-138">64-bit signed integer</span></span>| <span data-ttu-id="2b9e1-139">必須</span><span class="sxs-lookup"><span data-stu-id="2b9e1-139">yes</span></span>| <span data-ttu-id="2b9e1-140">1234567890</span><span class="sxs-lookup"><span data-stu-id="2b9e1-140">1234567890</span></span>|

<a id="ID4ESC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="2b9e1-141">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2b9e1-141">Required Request Headers</span></span>

| <span data-ttu-id="2b9e1-142">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2b9e1-142">Header</span></span>| <span data-ttu-id="2b9e1-143">型</span><span class="sxs-lookup"><span data-stu-id="2b9e1-143">Type</span></span>| <span data-ttu-id="2b9e1-144">説明</span><span class="sxs-lookup"><span data-stu-id="2b9e1-144">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2b9e1-145">Authorization</span><span class="sxs-lookup"><span data-stu-id="2b9e1-145">Authorization</span></span> | <span data-ttu-id="2b9e1-146">string</span><span class="sxs-lookup"><span data-stu-id="2b9e1-146">string</span></span>| <span data-ttu-id="2b9e1-147">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-147">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="2b9e1-148">値の例:<code>Xauth=&lt;authtoken></code>します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-148">Example value: <code>Xauth=&lt;authtoken></code>.</span></span> <span data-ttu-id="2b9e1-149">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-149">Maximum size: none.</span></span>|
| <span data-ttu-id="2b9e1-150">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="2b9e1-150">X-RequestedServiceVersion</span></span>| <span data-ttu-id="2b9e1-151">string</span><span class="sxs-lookup"><span data-stu-id="2b9e1-151">string</span></span>| <span data-ttu-id="2b9e1-152">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-152">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="2b9e1-153">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-153">The request will only be routed to that service after verifying the validity of the header, the claims in the authorization token, and so on.</span></span> <span data-ttu-id="2b9e1-154">値の例: <code>1</code>、<code>vnext</code>します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-154">Example values: <code>1</code>, <code>vnext</code>.</span></span> <span data-ttu-id="2b9e1-155">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-155">Maximum size: none.</span></span>|
| <span data-ttu-id="2b9e1-156">Accept</span><span class="sxs-lookup"><span data-stu-id="2b9e1-156">Accept</span></span>| <span data-ttu-id="2b9e1-157">string</span><span class="sxs-lookup"><span data-stu-id="2b9e1-157">string</span></span>| <span data-ttu-id="2b9e1-158">コンテンツの種類の受け入れられるします。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-158">Content-Types that are acceptable.</span></span> <span data-ttu-id="2b9e1-159">値の例:<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-159">Example value: <code>application/json</code>.</span></span> <span data-ttu-id="2b9e1-160">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-160">Maximum size: none.</span></span>|

<a id="ID4EPE"></a>


## <a name="request-body"></a><span data-ttu-id="2b9e1-161">要求本文</span><span class="sxs-lookup"><span data-stu-id="2b9e1-161">Request body</span></span>

<span data-ttu-id="2b9e1-162">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-162">No objects are sent in the body of this request.</span></span>

<a id="ID4E1E"></a>


## <a name="http-status-codes"></a><span data-ttu-id="2b9e1-163">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="2b9e1-163">HTTP status codes</span></span>

<span data-ttu-id="2b9e1-164">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-164">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="2b9e1-165">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-165">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="2b9e1-166">コード</span><span class="sxs-lookup"><span data-stu-id="2b9e1-166">Code</span></span>| <span data-ttu-id="2b9e1-167">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="2b9e1-167">Reason phrase</span></span>| <span data-ttu-id="2b9e1-168">説明</span><span class="sxs-lookup"><span data-stu-id="2b9e1-168">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2b9e1-169">200</span><span class="sxs-lookup"><span data-stu-id="2b9e1-169">200</span></span>| <span data-ttu-id="2b9e1-170">OK</span><span class="sxs-lookup"><span data-stu-id="2b9e1-170">OK</span></span>| <span data-ttu-id="2b9e1-171">ミュート リストの要求が成功した場合。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-171">Successful request for the mute list.</span></span>|
| <span data-ttu-id="2b9e1-172">400</span><span class="sxs-lookup"><span data-stu-id="2b9e1-172">400</span></span>| <span data-ttu-id="2b9e1-173">Bad Request</span><span class="sxs-lookup"><span data-stu-id="2b9e1-173">Bad Request</span></span>| <span data-ttu-id="2b9e1-174">URI で指定されたターゲット ID が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-174">The target ID specified in the URI is not valid.</span></span>|
| <span data-ttu-id="2b9e1-175">403</span><span class="sxs-lookup"><span data-stu-id="2b9e1-175">403</span></span>| <span data-ttu-id="2b9e1-176">Forbidden</span><span class="sxs-lookup"><span data-stu-id="2b9e1-176">Forbidden</span></span>| <span data-ttu-id="2b9e1-177">URI で指定された所有者は、認証されたユーザーではありません。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-177">The owner specified in the URI is not the authenticated user.</span></span>|
| <span data-ttu-id="2b9e1-178">404</span><span class="sxs-lookup"><span data-stu-id="2b9e1-178">404</span></span>| <span data-ttu-id="2b9e1-179">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-179">Not Found</span></span>| <span data-ttu-id="2b9e1-180">URI で指定された所有者は存在しません。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-180">The owner specified in the URI does not exist.</span></span>|

<a id="ID4E3G"></a>


## <a name="required-response-headers"></a><span data-ttu-id="2b9e1-181">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2b9e1-181">Required Response Headers</span></span>

| <span data-ttu-id="2b9e1-182">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2b9e1-182">Header</span></span>| <span data-ttu-id="2b9e1-183">型</span><span class="sxs-lookup"><span data-stu-id="2b9e1-183">Type</span></span>| <span data-ttu-id="2b9e1-184">説明</span><span class="sxs-lookup"><span data-stu-id="2b9e1-184">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2b9e1-185">Content-Type</span><span class="sxs-lookup"><span data-stu-id="2b9e1-185">Content-Type</span></span>| <span data-ttu-id="2b9e1-186">string</span><span class="sxs-lookup"><span data-stu-id="2b9e1-186">string</span></span>| <span data-ttu-id="2b9e1-187">要求の本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-187">The MIME type of the body of the request.</span></span> <span data-ttu-id="2b9e1-188">値の例:</span><span class="sxs-lookup"><span data-stu-id="2b9e1-188">Example value:</span></span> <code>application/json</code>|
| <span data-ttu-id="2b9e1-189">Content-Length</span><span class="sxs-lookup"><span data-stu-id="2b9e1-189">Content-Length</span></span>| <span data-ttu-id="2b9e1-190">string</span><span class="sxs-lookup"><span data-stu-id="2b9e1-190">string</span></span>| <span data-ttu-id="2b9e1-191">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-191">The number of bytes being sent in the response.</span></span> <span data-ttu-id="2b9e1-192">値の例: 34</span><span class="sxs-lookup"><span data-stu-id="2b9e1-192">Example value: 34</span></span>|
| <span data-ttu-id="2b9e1-193">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="2b9e1-193">Cache-Control</span></span>| <span data-ttu-id="2b9e1-194">string</span><span class="sxs-lookup"><span data-stu-id="2b9e1-194">string</span></span>| <span data-ttu-id="2b9e1-195">キャッシュ動作を指定するサーバーからていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-195">Polite request from the server to specify caching behavior.</span></span> <span data-ttu-id="2b9e1-196">例:</span><span class="sxs-lookup"><span data-stu-id="2b9e1-196">Example:</span></span> <code>no-cache, no-store</code>|

<a id="ID4ETAAC"></a>


## <a name="response-body"></a><span data-ttu-id="2b9e1-197">応答本文</span><span class="sxs-lookup"><span data-stu-id="2b9e1-197">Response body</span></span>

<a id="ID4EZAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="2b9e1-198">応答の例</span><span class="sxs-lookup"><span data-stu-id="2b9e1-198">Sample response</span></span>

<span data-ttu-id="2b9e1-199">[UserList](../../json/json-userlist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2b9e1-199">See [UserList](../../json/json-userlist.md).</span></span>


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


## <a name="see-also"></a><span data-ttu-id="2b9e1-200">関連項目</span><span class="sxs-lookup"><span data-stu-id="2b9e1-200">See also</span></span>

<a id="ID4ELBAC"></a>


##### <a name="parent"></a><span data-ttu-id="2b9e1-201">Parent</span><span class="sxs-lookup"><span data-stu-id="2b9e1-201">Parent</span></span>

[<span data-ttu-id="2b9e1-202">/users/{ownerId}/people/mute</span><span class="sxs-lookup"><span data-stu-id="2b9e1-202">/users/{ownerId}/people/mute</span></span>](uri-privacyusersowneridpeoplemute.md)
