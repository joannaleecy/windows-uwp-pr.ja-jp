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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8324246"
---
# <a name="get-usersowneridpeopleavoid"></a><span data-ttu-id="c9aca-104">GET (/users/{ownerId}/people/avoid)</span><span class="sxs-lookup"><span data-stu-id="c9aca-104">GET (/users/{ownerId}/people/avoid)</span></span>
<span data-ttu-id="c9aca-105">ユーザーの回避一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-105">Gets the Avoid list for a user.</span></span>

  * [<span data-ttu-id="c9aca-106">注釈</span><span class="sxs-lookup"><span data-stu-id="c9aca-106">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="c9aca-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9aca-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="c9aca-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="c9aca-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="c9aca-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9aca-109">Required Request Headers</span></span>](#ID4EJC)
  * [<span data-ttu-id="c9aca-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="c9aca-110">HTTP status codes</span></span>](#ID4EYD)
  * [<span data-ttu-id="c9aca-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9aca-111">Required Response Headers</span></span>](#ID4E1F)
  * [<span data-ttu-id="c9aca-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="c9aca-112">Response body</span></span>](#ID4ESH)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="c9aca-113">注釈</span><span class="sxs-lookup"><span data-stu-id="c9aca-113">Remarks</span></span>

<span data-ttu-id="c9aca-114">ターゲットを指定するはしている場合、ブロックの一覧に、空いないいるかどうかにのみそのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-114">If a target is given, only returns that user if they're on the block list, or else empty if they're not.</span></span>

<a id="ID4EZ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="c9aca-115">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9aca-115">URI parameters</span></span>

| <span data-ttu-id="c9aca-116">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9aca-116">Parameter</span></span>| <span data-ttu-id="c9aca-117">型</span><span class="sxs-lookup"><span data-stu-id="c9aca-117">Type</span></span>| <span data-ttu-id="c9aca-118">説明</span><span class="sxs-lookup"><span data-stu-id="c9aca-118">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="c9aca-119">ownerId</span><span class="sxs-lookup"><span data-stu-id="c9aca-119">ownerId</span></span>| <span data-ttu-id="c9aca-120">string</span><span class="sxs-lookup"><span data-stu-id="c9aca-120">string</span></span>| <span data-ttu-id="c9aca-121">必須。</span><span class="sxs-lookup"><span data-stu-id="c9aca-121">Required.</span></span> <span data-ttu-id="c9aca-122">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="c9aca-122">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="c9aca-123">可能な値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-123">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="c9aca-124">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="c9aca-124">Must be the authenticated user.</span></span> <span data-ttu-id="c9aca-125">値の例:<code>xuid(2603643534573581)</code>します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-125">Example value: <code>xuid(2603643534573581)</code>.</span></span> <span data-ttu-id="c9aca-126">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="c9aca-126">Maximum size: none.</span></span> |

<a id="ID4EEB"></a>


## <a name="authorization"></a><span data-ttu-id="c9aca-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="c9aca-127">Authorization</span></span>

<span data-ttu-id="c9aca-128">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="c9aca-128">Authorization claims used</span></span> | <span data-ttu-id="c9aca-129">要求</span><span class="sxs-lookup"><span data-stu-id="c9aca-129">Claim</span></span>| <span data-ttu-id="c9aca-130">種類</span><span class="sxs-lookup"><span data-stu-id="c9aca-130">Type</span></span>| <span data-ttu-id="c9aca-131">必須?</span><span class="sxs-lookup"><span data-stu-id="c9aca-131">Required?</span></span>| <span data-ttu-id="c9aca-132">値の例</span><span class="sxs-lookup"><span data-stu-id="c9aca-132">Example value</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c9aca-133">Xuid</span><span class="sxs-lookup"><span data-stu-id="c9aca-133">Xuid</span></span>| <span data-ttu-id="c9aca-134">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="c9aca-134">64-bit signed integer</span></span>| <span data-ttu-id="c9aca-135">必須</span><span class="sxs-lookup"><span data-stu-id="c9aca-135">yes</span></span>| <span data-ttu-id="c9aca-136">1234567890</span><span class="sxs-lookup"><span data-stu-id="c9aca-136">1234567890</span></span>|

<a id="ID4EJC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="c9aca-137">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9aca-137">Required Request Headers</span></span>

| <span data-ttu-id="c9aca-138">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9aca-138">Header</span></span>| <span data-ttu-id="c9aca-139">型</span><span class="sxs-lookup"><span data-stu-id="c9aca-139">Type</span></span>| <span data-ttu-id="c9aca-140">説明</span><span class="sxs-lookup"><span data-stu-id="c9aca-140">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c9aca-141">Authorization</span><span class="sxs-lookup"><span data-stu-id="c9aca-141">Authorization</span></span> | <span data-ttu-id="c9aca-142">string</span><span class="sxs-lookup"><span data-stu-id="c9aca-142">string</span></span>| <span data-ttu-id="c9aca-143">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-143">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="c9aca-144">値の例:<code>Xauth=&lt;authtoken></code>します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-144">Example value: <code>Xauth=&lt;authtoken></code>.</span></span> <span data-ttu-id="c9aca-145">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="c9aca-145">Maximum size: none.</span></span>|
| <span data-ttu-id="c9aca-146">Accept</span><span class="sxs-lookup"><span data-stu-id="c9aca-146">Accept</span></span>| <span data-ttu-id="c9aca-147">string</span><span class="sxs-lookup"><span data-stu-id="c9aca-147">string</span></span>| <span data-ttu-id="c9aca-148">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="c9aca-148">Content-Types that are acceptable.</span></span> <span data-ttu-id="c9aca-149">値の例:<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-149">Example value: <code>application/json</code>.</span></span> <span data-ttu-id="c9aca-150">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="c9aca-150">Maximum size: none.</span></span>|

<a id="ID4EYD"></a>


## <a name="http-status-codes"></a><span data-ttu-id="c9aca-151">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="c9aca-151">HTTP status codes</span></span>

<span data-ttu-id="c9aca-152">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-152">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="c9aca-153">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c9aca-153">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="c9aca-154">コード</span><span class="sxs-lookup"><span data-stu-id="c9aca-154">Code</span></span>| <span data-ttu-id="c9aca-155">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="c9aca-155">Reason phrase</span></span>| <span data-ttu-id="c9aca-156">説明</span><span class="sxs-lookup"><span data-stu-id="c9aca-156">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c9aca-157">200</span><span class="sxs-lookup"><span data-stu-id="c9aca-157">200</span></span>| <span data-ttu-id="c9aca-158">OK</span><span class="sxs-lookup"><span data-stu-id="c9aca-158">OK</span></span>| <span data-ttu-id="c9aca-159">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="c9aca-159">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="c9aca-160">400</span><span class="sxs-lookup"><span data-stu-id="c9aca-160">400</span></span>| <span data-ttu-id="c9aca-161">Bad Request</span><span class="sxs-lookup"><span data-stu-id="c9aca-161">Bad Request</span></span>| <span data-ttu-id="c9aca-162">URI で指定されたターゲット ID が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="c9aca-162">The target ID specified in the URI is not valid.</span></span>|
| <span data-ttu-id="c9aca-163">403</span><span class="sxs-lookup"><span data-stu-id="c9aca-163">403</span></span>| <span data-ttu-id="c9aca-164">Forbidden</span><span class="sxs-lookup"><span data-stu-id="c9aca-164">Forbidden</span></span>| <span data-ttu-id="c9aca-165">URI で指定された所有者は、認証されたユーザーではありません。</span><span class="sxs-lookup"><span data-stu-id="c9aca-165">The owner specified in the URI is not the authenticated user.</span></span>|
| <span data-ttu-id="c9aca-166">404</span><span class="sxs-lookup"><span data-stu-id="c9aca-166">404</span></span>| <span data-ttu-id="c9aca-167">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="c9aca-167">Not Found</span></span>| <span data-ttu-id="c9aca-168">URI で指定された所有者は存在しません。</span><span class="sxs-lookup"><span data-stu-id="c9aca-168">The owner specified in the URI does not exist.</span></span>|

<a id="ID4E1F"></a>


## <a name="required-response-headers"></a><span data-ttu-id="c9aca-169">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9aca-169">Required Response Headers</span></span>

| <span data-ttu-id="c9aca-170">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9aca-170">Header</span></span>| <span data-ttu-id="c9aca-171">型</span><span class="sxs-lookup"><span data-stu-id="c9aca-171">Type</span></span>| <span data-ttu-id="c9aca-172">説明</span><span class="sxs-lookup"><span data-stu-id="c9aca-172">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c9aca-173">Content-Type</span><span class="sxs-lookup"><span data-stu-id="c9aca-173">Content-Type</span></span>| <span data-ttu-id="c9aca-174">string</span><span class="sxs-lookup"><span data-stu-id="c9aca-174">string</span></span>| <span data-ttu-id="c9aca-175">要求の本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="c9aca-175">The MIME type of the body of the request.</span></span> <span data-ttu-id="c9aca-176">値の例:<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-176">Example value: <code>application/json</code>.</span></span> <span data-ttu-id="c9aca-177">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="c9aca-177">Maximum size: none.</span></span>|
| <span data-ttu-id="c9aca-178">Content-Length</span><span class="sxs-lookup"><span data-stu-id="c9aca-178">Content-Length</span></span>| <span data-ttu-id="c9aca-179">string</span><span class="sxs-lookup"><span data-stu-id="c9aca-179">string</span></span>| <span data-ttu-id="c9aca-180">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="c9aca-180">The number of bytes being sent in the response.</span></span> <span data-ttu-id="c9aca-181">値の例: 34 します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-181">Example value: 34.</span></span> <span data-ttu-id="c9aca-182">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="c9aca-182">Maximum size: none.</span></span>|
| <span data-ttu-id="c9aca-183">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="c9aca-183">Cache-Control</span></span>| <span data-ttu-id="c9aca-184">string</span><span class="sxs-lookup"><span data-stu-id="c9aca-184">string</span></span>| <span data-ttu-id="c9aca-185">キャッシュ動作を指定するサーバーからていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-185">Polite request from the server to specify caching behavior.</span></span> <span data-ttu-id="c9aca-186">値の例:<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="c9aca-186">Example value: <code>application/json</code>.</span></span> <span data-ttu-id="c9aca-187">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="c9aca-187">Maximum size: none.</span></span>|

<a id="ID4ESH"></a>


## <a name="response-body"></a><span data-ttu-id="c9aca-188">応答本文</span><span class="sxs-lookup"><span data-stu-id="c9aca-188">Response body</span></span>

<a id="ID4EYH"></a>


### <a name="sample-response"></a><span data-ttu-id="c9aca-189">応答の例</span><span class="sxs-lookup"><span data-stu-id="c9aca-189">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="c9aca-190">関連項目</span><span class="sxs-lookup"><span data-stu-id="c9aca-190">See also</span></span>

<a id="ID4EFAAC"></a>


##### <a name="parent"></a><span data-ttu-id="c9aca-191">Parent</span><span class="sxs-lookup"><span data-stu-id="c9aca-191">Parent</span></span>

[<span data-ttu-id="c9aca-192">/users/{ownerId}/people/avoid</span><span class="sxs-lookup"><span data-stu-id="c9aca-192">/users/{ownerId}/people/avoid</span></span>](uri-privacyusersxuidpeopleavoid.md)
