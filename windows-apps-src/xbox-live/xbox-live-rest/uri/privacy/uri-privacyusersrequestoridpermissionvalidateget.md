---
title: GET (/users/{requestorId}/permission/validate)
assetID: 8d22c668-af9a-1d24-8d65-830c2ce913d7
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidateget.html
author: KevinAsgari
description: " GET (/users/{requestorId}/permission/validate)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2c75a0975179b599201fac91141f8c85ace11790
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4176590"
---
# <a name="get-usersrequestoridpermissionvalidate"></a><span data-ttu-id="25cb6-104">GET (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="25cb6-104">GET (/users/{requestorId}/permission/validate)</span></span>
<span data-ttu-id="25cb6-105">対象ユーザーを指定したアクションを実行するユーザーを許可するかどうかに関するはいまたは no 応答を取得します。</span><span class="sxs-lookup"><span data-stu-id="25cb6-105">Gets a yes-or-no answer about whether the user is allowed to perform the specified action with a target user.</span></span>

  * [<span data-ttu-id="25cb6-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="25cb6-106">URI parameters</span></span>](#ID4EQ)
  * [<span data-ttu-id="25cb6-107">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="25cb6-107">Query string parameters</span></span>](#ID4E2)
  * [<span data-ttu-id="25cb6-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="25cb6-108">Authorization</span></span>](#ID4EDC)
  * [<span data-ttu-id="25cb6-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25cb6-109">Required Request Headers</span></span>](#ID4EID)
  * [<span data-ttu-id="25cb6-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="25cb6-110">Request body</span></span>](#ID4ETE)
  * [<span data-ttu-id="25cb6-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="25cb6-111">HTTP status codes</span></span>](#ID4E5E)
  * [<span data-ttu-id="25cb6-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25cb6-112">Required Response Headers</span></span>](#ID4ETG)
  * [<span data-ttu-id="25cb6-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="25cb6-113">Response body</span></span>](#ID4EKAAC)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="25cb6-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="25cb6-114">URI parameters</span></span>

| <span data-ttu-id="25cb6-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="25cb6-115">Parameter</span></span>| <span data-ttu-id="25cb6-116">型</span><span class="sxs-lookup"><span data-stu-id="25cb6-116">Type</span></span>| <span data-ttu-id="25cb6-117">説明</span><span class="sxs-lookup"><span data-stu-id="25cb6-117">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="25cb6-118">requestorId</span><span class="sxs-lookup"><span data-stu-id="25cb6-118">requestorId</span></span>| <span data-ttu-id="25cb6-119">string</span><span class="sxs-lookup"><span data-stu-id="25cb6-119">string</span></span>| <span data-ttu-id="25cb6-120">必須。</span><span class="sxs-lookup"><span data-stu-id="25cb6-120">Required.</span></span> <span data-ttu-id="25cb6-121">アクションを実行するユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="25cb6-121">Identifier of the user performing the action.</span></span> <span data-ttu-id="25cb6-122">設定可能な値は<code>xuid({xuid})</code>と<code>me</code>します。</span><span class="sxs-lookup"><span data-stu-id="25cb6-122">The possible values are <code>xuid({xuid})</code> and <code>me</code>.</span></span> <span data-ttu-id="25cb6-123">これは、ログインしているユーザーでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="25cb6-123">This must be a logged-in user.</span></span> <span data-ttu-id="25cb6-124">値の例:<code>xuid(0987654321)</code>します。</span><span class="sxs-lookup"><span data-stu-id="25cb6-124">Example value: <code>xuid(0987654321)</code>.</span></span>|

<a id="ID4E2"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="25cb6-125">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="25cb6-125">Query string parameters</span></span>

| <span data-ttu-id="25cb6-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="25cb6-126">Parameter</span></span>| <span data-ttu-id="25cb6-127">型</span><span class="sxs-lookup"><span data-stu-id="25cb6-127">Type</span></span>| <span data-ttu-id="25cb6-128">説明</span><span class="sxs-lookup"><span data-stu-id="25cb6-128">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="25cb6-129">設定</span><span class="sxs-lookup"><span data-stu-id="25cb6-129">setting</span></span>| <span data-ttu-id="25cb6-130">文字列の列挙</span><span class="sxs-lookup"><span data-stu-id="25cb6-130">string enumeration</span></span>| <span data-ttu-id="25cb6-131">照らしてチェックする PermissionId 値。</span><span class="sxs-lookup"><span data-stu-id="25cb6-131">The PermissionId value to check against.</span></span> <span data-ttu-id="25cb6-132">値の例:"CommunicateUsingText"です。</span><span class="sxs-lookup"><span data-stu-id="25cb6-132">Example value: "CommunicateUsingText".</span></span>|
| <span data-ttu-id="25cb6-133">ターゲット</span><span class="sxs-lookup"><span data-stu-id="25cb6-133">target</span></span>| <span data-ttu-id="25cb6-134">string</span><span class="sxs-lookup"><span data-stu-id="25cb6-134">string</span></span>| <span data-ttu-id="25cb6-135">実行するユーザーの操作では、ユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="25cb6-135">Identifier of the user on whom the action is to be performed.</span></span> <span data-ttu-id="25cb6-136">設定可能な値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="25cb6-136">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="25cb6-137">値の例:</span><span class="sxs-lookup"><span data-stu-id="25cb6-137">Example values:</span></span> <code>xuid(0987654321)</code>|

<a id="ID4EDC"></a>


## <a name="authorization"></a><span data-ttu-id="25cb6-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="25cb6-138">Authorization</span></span>

<span data-ttu-id="25cb6-139">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="25cb6-139">Authorization claims used</span></span> | <span data-ttu-id="25cb6-140">要求</span><span class="sxs-lookup"><span data-stu-id="25cb6-140">Claim</span></span>| <span data-ttu-id="25cb6-141">種類</span><span class="sxs-lookup"><span data-stu-id="25cb6-141">Type</span></span>| <span data-ttu-id="25cb6-142">必須?</span><span class="sxs-lookup"><span data-stu-id="25cb6-142">Required?</span></span>| <span data-ttu-id="25cb6-143">値の例</span><span class="sxs-lookup"><span data-stu-id="25cb6-143">Example value</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="25cb6-144">Xuid</span><span class="sxs-lookup"><span data-stu-id="25cb6-144">Xuid</span></span>| <span data-ttu-id="25cb6-145">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="25cb6-145">64-bit signed integer</span></span>| <span data-ttu-id="25cb6-146">必須</span><span class="sxs-lookup"><span data-stu-id="25cb6-146">yes</span></span>| <span data-ttu-id="25cb6-147">1234567890</span><span class="sxs-lookup"><span data-stu-id="25cb6-147">1234567890</span></span>|

<a id="ID4EID"></a>


## <a name="required-request-headers"></a><span data-ttu-id="25cb6-148">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25cb6-148">Required Request Headers</span></span>

| <span data-ttu-id="25cb6-149">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25cb6-149">Header</span></span>| <span data-ttu-id="25cb6-150">型</span><span class="sxs-lookup"><span data-stu-id="25cb6-150">Type</span></span>| <span data-ttu-id="25cb6-151">説明</span><span class="sxs-lookup"><span data-stu-id="25cb6-151">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="25cb6-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="25cb6-152">Authorization</span></span>| <span data-ttu-id="25cb6-153">string</span><span class="sxs-lookup"><span data-stu-id="25cb6-153">string</span></span>| <span data-ttu-id="25cb6-154">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="25cb6-154">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="25cb6-155">値の例:</span><span class="sxs-lookup"><span data-stu-id="25cb6-155">Example values:</span></span> <code>XBL3.0 x=&lt;userhash>;&lt;token></code>|
| <span data-ttu-id="25cb6-156">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="25cb6-156">X-RequestedServiceVersion</span></span>| <span data-ttu-id="25cb6-157">string</span><span class="sxs-lookup"><span data-stu-id="25cb6-157">string</span></span>| <span data-ttu-id="25cb6-158">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="25cb6-158">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="25cb6-159">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。値の例: 1 です。</span><span class="sxs-lookup"><span data-stu-id="25cb6-159">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Example value: 1.</span></span>|

<a id="ID4ETE"></a>


## <a name="request-body"></a><span data-ttu-id="25cb6-160">要求本文</span><span class="sxs-lookup"><span data-stu-id="25cb6-160">Request body</span></span>

<span data-ttu-id="25cb6-161">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="25cb6-161">No objects are sent in the body of this request.</span></span>

<a id="ID4E5E"></a>


## <a name="http-status-codes"></a><span data-ttu-id="25cb6-162">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="25cb6-162">HTTP status codes</span></span>

<span data-ttu-id="25cb6-163">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="25cb6-163">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="25cb6-164">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="25cb6-164">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="25cb6-165">コード</span><span class="sxs-lookup"><span data-stu-id="25cb6-165">Code</span></span>| <span data-ttu-id="25cb6-166">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="25cb6-166">Reason phrase</span></span>| <span data-ttu-id="25cb6-167">説明</span><span class="sxs-lookup"><span data-stu-id="25cb6-167">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="25cb6-168">200</span><span class="sxs-lookup"><span data-stu-id="25cb6-168">200</span></span>| <span data-ttu-id="25cb6-169">OK</span><span class="sxs-lookup"><span data-stu-id="25cb6-169">OK</span></span>| <span data-ttu-id="25cb6-170">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="25cb6-170">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="25cb6-171">400</span><span class="sxs-lookup"><span data-stu-id="25cb6-171">400</span></span>| <span data-ttu-id="25cb6-172">要求が無効です。</span><span class="sxs-lookup"><span data-stu-id="25cb6-172">The request is invalid.</span></span>| <span data-ttu-id="25cb6-173">例: が正しく設定 Id、不適切な Uri などです。</span><span class="sxs-lookup"><span data-stu-id="25cb6-173">Examples: incorrect setting IDs, incorrect URIs, etc.</span></span>|
| <span data-ttu-id="25cb6-174">404</span><span class="sxs-lookup"><span data-stu-id="25cb6-174">404</span></span>| <span data-ttu-id="25cb6-175">URI で指定されたユーザーが存在しません。</span><span class="sxs-lookup"><span data-stu-id="25cb6-175">The user specified in the URI does not exist.</span></span>| <span data-ttu-id="25cb6-176">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="25cb6-176">The specified resource could not be found.</span></span>|

<a id="ID4ETG"></a>


## <a name="required-response-headers"></a><span data-ttu-id="25cb6-177">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25cb6-177">Required Response Headers</span></span>

| <span data-ttu-id="25cb6-178">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25cb6-178">Header</span></span>| <span data-ttu-id="25cb6-179">型</span><span class="sxs-lookup"><span data-stu-id="25cb6-179">Type</span></span>| <span data-ttu-id="25cb6-180">説明</span><span class="sxs-lookup"><span data-stu-id="25cb6-180">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="25cb6-181">Content-Type</span><span class="sxs-lookup"><span data-stu-id="25cb6-181">Content-Type</span></span>| <span data-ttu-id="25cb6-182">string</span><span class="sxs-lookup"><span data-stu-id="25cb6-182">string</span></span>| <span data-ttu-id="25cb6-183">要求の本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="25cb6-183">The MIME type of the body of the request.</span></span> <span data-ttu-id="25cb6-184">値の例:</span><span class="sxs-lookup"><span data-stu-id="25cb6-184">Example value:</span></span> <code>application/json</code>|
| <span data-ttu-id="25cb6-185">Content-Length</span><span class="sxs-lookup"><span data-stu-id="25cb6-185">Content-Length</span></span>| <span data-ttu-id="25cb6-186">string</span><span class="sxs-lookup"><span data-stu-id="25cb6-186">string</span></span>| <span data-ttu-id="25cb6-187">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="25cb6-187">The number of bytes being sent in the response.</span></span> <span data-ttu-id="25cb6-188">値の例: 34</span><span class="sxs-lookup"><span data-stu-id="25cb6-188">Example value: 34</span></span>|
| <span data-ttu-id="25cb6-189">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="25cb6-189">Cache-Control</span></span>| <span data-ttu-id="25cb6-190">string</span><span class="sxs-lookup"><span data-stu-id="25cb6-190">string</span></span>| <span data-ttu-id="25cb6-191">キャッシュ動作を指定するサーバーからていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="25cb6-191">Polite request from the server to specify caching behavior.</span></span> <span data-ttu-id="25cb6-192">例:</span><span class="sxs-lookup"><span data-stu-id="25cb6-192">Example:</span></span> <code>no-cache, no-store</code>|

<a id="ID4EKAAC"></a>


## <a name="response-body"></a><span data-ttu-id="25cb6-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="25cb6-193">Response body</span></span>

<span data-ttu-id="25cb6-194">[PermissionCheckResponse (JSON)](../../json/json-permissioncheckresponse.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="25cb6-194">See [PermissionCheckResponse (JSON)](../../json/json-permissioncheckresponse.md).</span></span>

<a id="ID4EWAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="25cb6-195">応答の例</span><span class="sxs-lookup"><span data-stu-id="25cb6-195">Sample response</span></span>


```cpp
{
    "isAllowed": false,
    "reasons":
    [
        {"reason": "BlockedByRequestor"},
        {"reason": "MissingPrivilege", "restrictedSetting": "VideoCommunications"}
    ]
}

```


<a id="ID4EABAC"></a>


## <a name="see-also"></a><span data-ttu-id="25cb6-196">関連項目</span><span class="sxs-lookup"><span data-stu-id="25cb6-196">See also</span></span>

<a id="ID4ECBAC"></a>


##### <a name="parent"></a><span data-ttu-id="25cb6-197">Parent</span><span class="sxs-lookup"><span data-stu-id="25cb6-197">Parent</span></span>

[<span data-ttu-id="25cb6-198">/users/{requestorId}/permission/validate</span><span class="sxs-lookup"><span data-stu-id="25cb6-198">/users/{requestorId}/permission/validate</span></span>](uri-privacyusersrequestoridpermissionvalidate.md)

 [<span data-ttu-id="25cb6-199">PermissionId 列挙型</span><span class="sxs-lookup"><span data-stu-id="25cb6-199">PermissionId Enumeration</span></span>](../../enums/privacy-enum-permissionid.md)
