---
title: GET (/users/{ownerId}/people/avoid)
assetID: e3420658-4738-8e80-44da-8281726fce01
permalink: en-us/docs/xboxlive/rest/uri-privacyusersxuidpeopleavoidget.html
description: " GET (/users/{ownerId}/people/avoid)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 745893b4b975b5fbf64fe76591ec15d18af59d73
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641617"
---
# <a name="get-usersowneridpeopleavoid"></a><span data-ttu-id="fb483-104">GET (/users/{ownerId}/people/avoid)</span><span class="sxs-lookup"><span data-stu-id="fb483-104">GET (/users/{ownerId}/people/avoid)</span></span>
<span data-ttu-id="fb483-105">ユーザーの避け一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="fb483-105">Gets the Avoid list for a user.</span></span>

  * [<span data-ttu-id="fb483-106">注釈</span><span class="sxs-lookup"><span data-stu-id="fb483-106">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="fb483-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fb483-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="fb483-108">承認</span><span class="sxs-lookup"><span data-stu-id="fb483-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="fb483-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fb483-109">Required Request Headers</span></span>](#ID4EJC)
  * [<span data-ttu-id="fb483-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="fb483-110">HTTP status codes</span></span>](#ID4EYD)
  * [<span data-ttu-id="fb483-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fb483-111">Required Response Headers</span></span>](#ID4E1F)
  * [<span data-ttu-id="fb483-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="fb483-112">Response body</span></span>](#ID4ESH)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="fb483-113">注釈</span><span class="sxs-lookup"><span data-stu-id="fb483-113">Remarks</span></span>

<span data-ttu-id="fb483-114">ターゲットを指定した場合はしていないかどうか、ブロック一覧に、空である場合にのみそのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="fb483-114">If a target is given, only returns that user if they're on the block list, or else empty if they're not.</span></span>

<a id="ID4EZ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="fb483-115">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fb483-115">URI parameters</span></span>

| <span data-ttu-id="fb483-116">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fb483-116">Parameter</span></span>| <span data-ttu-id="fb483-117">種類</span><span class="sxs-lookup"><span data-stu-id="fb483-117">Type</span></span>| <span data-ttu-id="fb483-118">説明</span><span class="sxs-lookup"><span data-stu-id="fb483-118">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="fb483-119">ownerId</span><span class="sxs-lookup"><span data-stu-id="fb483-119">ownerId</span></span>| <span data-ttu-id="fb483-120">string</span><span class="sxs-lookup"><span data-stu-id="fb483-120">string</span></span>| <span data-ttu-id="fb483-121">必須。</span><span class="sxs-lookup"><span data-stu-id="fb483-121">Required.</span></span> <span data-ttu-id="fb483-122">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="fb483-122">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="fb483-123">指定できる値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="fb483-123">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="fb483-124">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb483-124">Must be the authenticated user.</span></span> <span data-ttu-id="fb483-125">値の例:<code>xuid(2603643534573581)</code>します。</span><span class="sxs-lookup"><span data-stu-id="fb483-125">Example value: <code>xuid(2603643534573581)</code>.</span></span> <span data-ttu-id="fb483-126">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="fb483-126">Maximum size: none.</span></span> |

<a id="ID4EEB"></a>


## <a name="authorization"></a><span data-ttu-id="fb483-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="fb483-127">Authorization</span></span>

<span data-ttu-id="fb483-128">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="fb483-128">Authorization claims used</span></span> | <span data-ttu-id="fb483-129">要求</span><span class="sxs-lookup"><span data-stu-id="fb483-129">Claim</span></span>| <span data-ttu-id="fb483-130">種類</span><span class="sxs-lookup"><span data-stu-id="fb483-130">Type</span></span>| <span data-ttu-id="fb483-131">必須?</span><span class="sxs-lookup"><span data-stu-id="fb483-131">Required?</span></span>| <span data-ttu-id="fb483-132">値の例</span><span class="sxs-lookup"><span data-stu-id="fb483-132">Example value</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="fb483-133">xuid</span><span class="sxs-lookup"><span data-stu-id="fb483-133">Xuid</span></span>| <span data-ttu-id="fb483-134">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="fb483-134">64-bit signed integer</span></span>| <span data-ttu-id="fb483-135">○</span><span class="sxs-lookup"><span data-stu-id="fb483-135">yes</span></span>| <span data-ttu-id="fb483-136">1234567890</span><span class="sxs-lookup"><span data-stu-id="fb483-136">1234567890</span></span>|

<a id="ID4EJC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="fb483-137">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fb483-137">Required Request Headers</span></span>

| <span data-ttu-id="fb483-138">Header</span><span class="sxs-lookup"><span data-stu-id="fb483-138">Header</span></span>| <span data-ttu-id="fb483-139">種類</span><span class="sxs-lookup"><span data-stu-id="fb483-139">Type</span></span>| <span data-ttu-id="fb483-140">説明</span><span class="sxs-lookup"><span data-stu-id="fb483-140">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="fb483-141">Authorization</span><span class="sxs-lookup"><span data-stu-id="fb483-141">Authorization</span></span> | <span data-ttu-id="fb483-142">string</span><span class="sxs-lookup"><span data-stu-id="fb483-142">string</span></span>| <span data-ttu-id="fb483-143">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="fb483-143">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="fb483-144">値の例:<code>Xauth=&lt;authtoken></code>します。</span><span class="sxs-lookup"><span data-stu-id="fb483-144">Example value: <code>Xauth=&lt;authtoken></code>.</span></span> <span data-ttu-id="fb483-145">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="fb483-145">Maximum size: none.</span></span>|
| <span data-ttu-id="fb483-146">OK</span><span class="sxs-lookup"><span data-stu-id="fb483-146">Accept</span></span>| <span data-ttu-id="fb483-147">string</span><span class="sxs-lookup"><span data-stu-id="fb483-147">string</span></span>| <span data-ttu-id="fb483-148">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="fb483-148">Content-Types that are acceptable.</span></span> <span data-ttu-id="fb483-149">値の例:<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="fb483-149">Example value: <code>application/json</code>.</span></span> <span data-ttu-id="fb483-150">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="fb483-150">Maximum size: none.</span></span>|

<a id="ID4EYD"></a>


## <a name="http-status-codes"></a><span data-ttu-id="fb483-151">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="fb483-151">HTTP status codes</span></span>

<span data-ttu-id="fb483-152">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="fb483-152">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="fb483-153">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="fb483-153">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="fb483-154">コード</span><span class="sxs-lookup"><span data-stu-id="fb483-154">Code</span></span>| <span data-ttu-id="fb483-155">理由語句</span><span class="sxs-lookup"><span data-stu-id="fb483-155">Reason phrase</span></span>| <span data-ttu-id="fb483-156">説明</span><span class="sxs-lookup"><span data-stu-id="fb483-156">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="fb483-157">200</span><span class="sxs-lookup"><span data-stu-id="fb483-157">200</span></span>| <span data-ttu-id="fb483-158">OK</span><span class="sxs-lookup"><span data-stu-id="fb483-158">OK</span></span>| <span data-ttu-id="fb483-159">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="fb483-159">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="fb483-160">400</span><span class="sxs-lookup"><span data-stu-id="fb483-160">400</span></span>| <span data-ttu-id="fb483-161">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="fb483-161">Bad Request</span></span>| <span data-ttu-id="fb483-162">URI で指定されたターゲットの ID が無効です。</span><span class="sxs-lookup"><span data-stu-id="fb483-162">The target ID specified in the URI is not valid.</span></span>|
| <span data-ttu-id="fb483-163">403</span><span class="sxs-lookup"><span data-stu-id="fb483-163">403</span></span>| <span data-ttu-id="fb483-164">Forbidden</span><span class="sxs-lookup"><span data-stu-id="fb483-164">Forbidden</span></span>| <span data-ttu-id="fb483-165">URI で指定された所有者は、認証されたユーザーではありません。</span><span class="sxs-lookup"><span data-stu-id="fb483-165">The owner specified in the URI is not the authenticated user.</span></span>|
| <span data-ttu-id="fb483-166">404</span><span class="sxs-lookup"><span data-stu-id="fb483-166">404</span></span>| <span data-ttu-id="fb483-167">検出不可</span><span class="sxs-lookup"><span data-stu-id="fb483-167">Not Found</span></span>| <span data-ttu-id="fb483-168">URI で指定された所有者が存在しません。</span><span class="sxs-lookup"><span data-stu-id="fb483-168">The owner specified in the URI does not exist.</span></span>|

<a id="ID4E1F"></a>


## <a name="required-response-headers"></a><span data-ttu-id="fb483-169">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fb483-169">Required Response Headers</span></span>

| <span data-ttu-id="fb483-170">Header</span><span class="sxs-lookup"><span data-stu-id="fb483-170">Header</span></span>| <span data-ttu-id="fb483-171">種類</span><span class="sxs-lookup"><span data-stu-id="fb483-171">Type</span></span>| <span data-ttu-id="fb483-172">説明</span><span class="sxs-lookup"><span data-stu-id="fb483-172">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="fb483-173">Content-Type</span><span class="sxs-lookup"><span data-stu-id="fb483-173">Content-Type</span></span>| <span data-ttu-id="fb483-174">string</span><span class="sxs-lookup"><span data-stu-id="fb483-174">string</span></span>| <span data-ttu-id="fb483-175">要求の本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="fb483-175">The MIME type of the body of the request.</span></span> <span data-ttu-id="fb483-176">値の例:<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="fb483-176">Example value: <code>application/json</code>.</span></span> <span data-ttu-id="fb483-177">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="fb483-177">Maximum size: none.</span></span>|
| <span data-ttu-id="fb483-178">Content-Length</span><span class="sxs-lookup"><span data-stu-id="fb483-178">Content-Length</span></span>| <span data-ttu-id="fb483-179">string</span><span class="sxs-lookup"><span data-stu-id="fb483-179">string</span></span>| <span data-ttu-id="fb483-180">応答で送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="fb483-180">The number of bytes being sent in the response.</span></span> <span data-ttu-id="fb483-181">値の例:34.</span><span class="sxs-lookup"><span data-stu-id="fb483-181">Example value: 34.</span></span> <span data-ttu-id="fb483-182">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="fb483-182">Maximum size: none.</span></span>|
| <span data-ttu-id="fb483-183">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="fb483-183">Cache-Control</span></span>| <span data-ttu-id="fb483-184">string</span><span class="sxs-lookup"><span data-stu-id="fb483-184">string</span></span>| <span data-ttu-id="fb483-185">キャッシュの動作を指定する、サーバーから正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="fb483-185">Polite request from the server to specify caching behavior.</span></span> <span data-ttu-id="fb483-186">値の例:<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="fb483-186">Example value: <code>application/json</code>.</span></span> <span data-ttu-id="fb483-187">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="fb483-187">Maximum size: none.</span></span>|

<a id="ID4ESH"></a>


## <a name="response-body"></a><span data-ttu-id="fb483-188">応答本文</span><span class="sxs-lookup"><span data-stu-id="fb483-188">Response body</span></span>

<a id="ID4EYH"></a>


### <a name="sample-response"></a><span data-ttu-id="fb483-189">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="fb483-189">Sample response</span></span>


```cpp
{
    "users":
    [
        { "xuid":"12345" },
        { "xuid":"23456" }
    ]
}

```


<a id="ID4EDAAC"></a>


## <a name="see-also"></a><span data-ttu-id="fb483-190">関連項目</span><span class="sxs-lookup"><span data-stu-id="fb483-190">See also</span></span>

<a id="ID4EFAAC"></a>


##### <a name="parent"></a><span data-ttu-id="fb483-191">Parent</span><span class="sxs-lookup"><span data-stu-id="fb483-191">Parent</span></span>

[<span data-ttu-id="fb483-192">/users/{ownerId}/people/avoid</span><span class="sxs-lookup"><span data-stu-id="fb483-192">/users/{ownerId}/people/avoid</span></span>](uri-privacyusersxuidpeopleavoid.md)
