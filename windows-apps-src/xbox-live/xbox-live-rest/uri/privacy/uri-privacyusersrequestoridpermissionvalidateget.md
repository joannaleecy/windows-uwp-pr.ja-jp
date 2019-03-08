---
title: GET (/users/{requestorId}/permission/validate)
assetID: 8d22c668-af9a-1d24-8d65-830c2ce913d7
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidateget.html
description: " GET (/users/{requestorId}/permission/validate)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 07ccac63b3e6681ea35405314b0cd8b93aa60f9a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594757"
---
# <a name="get-usersrequestoridpermissionvalidate"></a><span data-ttu-id="eec76-104">GET (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="eec76-104">GET (/users/{requestorId}/permission/validate)</span></span>
<span data-ttu-id="eec76-105">対象ユーザーと指定したアクションを実行するユーザーを許可するかどうかについてはいまたは no 応答を取得します。</span><span class="sxs-lookup"><span data-stu-id="eec76-105">Gets a yes-or-no answer about whether the user is allowed to perform the specified action with a target user.</span></span>

  * [<span data-ttu-id="eec76-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="eec76-106">URI parameters</span></span>](#ID4EQ)
  * [<span data-ttu-id="eec76-107">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="eec76-107">Query string parameters</span></span>](#ID4E2)
  * [<span data-ttu-id="eec76-108">承認</span><span class="sxs-lookup"><span data-stu-id="eec76-108">Authorization</span></span>](#ID4EDC)
  * [<span data-ttu-id="eec76-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eec76-109">Required Request Headers</span></span>](#ID4EID)
  * [<span data-ttu-id="eec76-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="eec76-110">Request body</span></span>](#ID4ETE)
  * [<span data-ttu-id="eec76-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="eec76-111">HTTP status codes</span></span>](#ID4E5E)
  * [<span data-ttu-id="eec76-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eec76-112">Required Response Headers</span></span>](#ID4ETG)
  * [<span data-ttu-id="eec76-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="eec76-113">Response body</span></span>](#ID4EKAAC)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="eec76-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="eec76-114">URI parameters</span></span>

| <span data-ttu-id="eec76-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="eec76-115">Parameter</span></span>| <span data-ttu-id="eec76-116">種類</span><span class="sxs-lookup"><span data-stu-id="eec76-116">Type</span></span>| <span data-ttu-id="eec76-117">説明</span><span class="sxs-lookup"><span data-stu-id="eec76-117">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="eec76-118">requestorId</span><span class="sxs-lookup"><span data-stu-id="eec76-118">requestorId</span></span>| <span data-ttu-id="eec76-119">string</span><span class="sxs-lookup"><span data-stu-id="eec76-119">string</span></span>| <span data-ttu-id="eec76-120">必須。</span><span class="sxs-lookup"><span data-stu-id="eec76-120">Required.</span></span> <span data-ttu-id="eec76-121">アクションを実行して、ユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="eec76-121">Identifier of the user performing the action.</span></span> <span data-ttu-id="eec76-122">指定できる値は<code>xuid({xuid})</code>と<code>me</code>します。</span><span class="sxs-lookup"><span data-stu-id="eec76-122">The possible values are <code>xuid({xuid})</code> and <code>me</code>.</span></span> <span data-ttu-id="eec76-123">これには、ログイン ユーザーがあります。</span><span class="sxs-lookup"><span data-stu-id="eec76-123">This must be a logged-in user.</span></span> <span data-ttu-id="eec76-124">値の例:<code>xuid(0987654321)</code>します。</span><span class="sxs-lookup"><span data-stu-id="eec76-124">Example value: <code>xuid(0987654321)</code>.</span></span>|

<a id="ID4E2"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="eec76-125">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="eec76-125">Query string parameters</span></span>

| <span data-ttu-id="eec76-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="eec76-126">Parameter</span></span>| <span data-ttu-id="eec76-127">種類</span><span class="sxs-lookup"><span data-stu-id="eec76-127">Type</span></span>| <span data-ttu-id="eec76-128">説明</span><span class="sxs-lookup"><span data-stu-id="eec76-128">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="eec76-129">設定</span><span class="sxs-lookup"><span data-stu-id="eec76-129">setting</span></span>| <span data-ttu-id="eec76-130">文字列の列挙型</span><span class="sxs-lookup"><span data-stu-id="eec76-130">string enumeration</span></span>| <span data-ttu-id="eec76-131">照合する PermissionId 値。</span><span class="sxs-lookup"><span data-stu-id="eec76-131">The PermissionId value to check against.</span></span> <span data-ttu-id="eec76-132">値の例:"CommunicateUsingText"。</span><span class="sxs-lookup"><span data-stu-id="eec76-132">Example value: "CommunicateUsingText".</span></span>|
| <span data-ttu-id="eec76-133">target</span><span class="sxs-lookup"><span data-stu-id="eec76-133">target</span></span>| <span data-ttu-id="eec76-134">string</span><span class="sxs-lookup"><span data-stu-id="eec76-134">string</span></span>| <span data-ttu-id="eec76-135">アクションの実行対象のユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="eec76-135">Identifier of the user on whom the action is to be performed.</span></span> <span data-ttu-id="eec76-136">指定できる値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="eec76-136">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="eec76-137">値の例: <code>xuid(0987654321)</code></span><span class="sxs-lookup"><span data-stu-id="eec76-137">Example values: <code>xuid(0987654321)</code></span></span>|

<a id="ID4EDC"></a>


## <a name="authorization"></a><span data-ttu-id="eec76-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="eec76-138">Authorization</span></span>

<span data-ttu-id="eec76-139">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="eec76-139">Authorization claims used</span></span> | <span data-ttu-id="eec76-140">要求</span><span class="sxs-lookup"><span data-stu-id="eec76-140">Claim</span></span>| <span data-ttu-id="eec76-141">種類</span><span class="sxs-lookup"><span data-stu-id="eec76-141">Type</span></span>| <span data-ttu-id="eec76-142">必須?</span><span class="sxs-lookup"><span data-stu-id="eec76-142">Required?</span></span>| <span data-ttu-id="eec76-143">値の例</span><span class="sxs-lookup"><span data-stu-id="eec76-143">Example value</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="eec76-144">xuid</span><span class="sxs-lookup"><span data-stu-id="eec76-144">Xuid</span></span>| <span data-ttu-id="eec76-145">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="eec76-145">64-bit signed integer</span></span>| <span data-ttu-id="eec76-146">○</span><span class="sxs-lookup"><span data-stu-id="eec76-146">yes</span></span>| <span data-ttu-id="eec76-147">1234567890</span><span class="sxs-lookup"><span data-stu-id="eec76-147">1234567890</span></span>|

<a id="ID4EID"></a>


## <a name="required-request-headers"></a><span data-ttu-id="eec76-148">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eec76-148">Required Request Headers</span></span>

| <span data-ttu-id="eec76-149">Header</span><span class="sxs-lookup"><span data-stu-id="eec76-149">Header</span></span>| <span data-ttu-id="eec76-150">種類</span><span class="sxs-lookup"><span data-stu-id="eec76-150">Type</span></span>| <span data-ttu-id="eec76-151">説明</span><span class="sxs-lookup"><span data-stu-id="eec76-151">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="eec76-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="eec76-152">Authorization</span></span>| <span data-ttu-id="eec76-153">string</span><span class="sxs-lookup"><span data-stu-id="eec76-153">string</span></span>| <span data-ttu-id="eec76-154">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="eec76-154">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="eec76-155">値の例: <code>XBL3.0 x=&lt;userhash>;&lt;token></code></span><span class="sxs-lookup"><span data-stu-id="eec76-155">Example values: <code>XBL3.0 x=&lt;userhash>;&lt;token></code></span></span>|
| <span data-ttu-id="eec76-156">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="eec76-156">X-RequestedServiceVersion</span></span>| <span data-ttu-id="eec76-157">string</span><span class="sxs-lookup"><span data-stu-id="eec76-157">string</span></span>| <span data-ttu-id="eec76-158">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="eec76-158">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="eec76-159">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。値の例:1. </span><span class="sxs-lookup"><span data-stu-id="eec76-159">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Example value: 1.</span></span>|

<a id="ID4ETE"></a>


## <a name="request-body"></a><span data-ttu-id="eec76-160">要求本文</span><span class="sxs-lookup"><span data-stu-id="eec76-160">Request body</span></span>

<span data-ttu-id="eec76-161">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="eec76-161">No objects are sent in the body of this request.</span></span>

<a id="ID4E5E"></a>


## <a name="http-status-codes"></a><span data-ttu-id="eec76-162">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="eec76-162">HTTP status codes</span></span>

<span data-ttu-id="eec76-163">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="eec76-163">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="eec76-164">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="eec76-164">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="eec76-165">コード</span><span class="sxs-lookup"><span data-stu-id="eec76-165">Code</span></span>| <span data-ttu-id="eec76-166">理由語句</span><span class="sxs-lookup"><span data-stu-id="eec76-166">Reason phrase</span></span>| <span data-ttu-id="eec76-167">説明</span><span class="sxs-lookup"><span data-stu-id="eec76-167">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="eec76-168">200</span><span class="sxs-lookup"><span data-stu-id="eec76-168">200</span></span>| <span data-ttu-id="eec76-169">OK</span><span class="sxs-lookup"><span data-stu-id="eec76-169">OK</span></span>| <span data-ttu-id="eec76-170">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="eec76-170">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="eec76-171">400</span><span class="sxs-lookup"><span data-stu-id="eec76-171">400</span></span>| <span data-ttu-id="eec76-172">要求が無効です。</span><span class="sxs-lookup"><span data-stu-id="eec76-172">The request is invalid.</span></span>| <span data-ttu-id="eec76-173">例: 設定が正しくない Id、Uri が正しくないなど。</span><span class="sxs-lookup"><span data-stu-id="eec76-173">Examples: incorrect setting IDs, incorrect URIs, etc.</span></span>|
| <span data-ttu-id="eec76-174">404</span><span class="sxs-lookup"><span data-stu-id="eec76-174">404</span></span>| <span data-ttu-id="eec76-175">URI で指定されたユーザーは存在しません。</span><span class="sxs-lookup"><span data-stu-id="eec76-175">The user specified in the URI does not exist.</span></span>| <span data-ttu-id="eec76-176">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="eec76-176">The specified resource could not be found.</span></span>|

<a id="ID4ETG"></a>


## <a name="required-response-headers"></a><span data-ttu-id="eec76-177">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eec76-177">Required Response Headers</span></span>

| <span data-ttu-id="eec76-178">Header</span><span class="sxs-lookup"><span data-stu-id="eec76-178">Header</span></span>| <span data-ttu-id="eec76-179">種類</span><span class="sxs-lookup"><span data-stu-id="eec76-179">Type</span></span>| <span data-ttu-id="eec76-180">説明</span><span class="sxs-lookup"><span data-stu-id="eec76-180">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="eec76-181">Content-Type</span><span class="sxs-lookup"><span data-stu-id="eec76-181">Content-Type</span></span>| <span data-ttu-id="eec76-182">string</span><span class="sxs-lookup"><span data-stu-id="eec76-182">string</span></span>| <span data-ttu-id="eec76-183">要求の本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="eec76-183">The MIME type of the body of the request.</span></span> <span data-ttu-id="eec76-184">値の例: <code>application/json</code></span><span class="sxs-lookup"><span data-stu-id="eec76-184">Example value: <code>application/json</code></span></span>|
| <span data-ttu-id="eec76-185">Content-Length</span><span class="sxs-lookup"><span data-stu-id="eec76-185">Content-Length</span></span>| <span data-ttu-id="eec76-186">string</span><span class="sxs-lookup"><span data-stu-id="eec76-186">string</span></span>| <span data-ttu-id="eec76-187">応答で送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="eec76-187">The number of bytes being sent in the response.</span></span> <span data-ttu-id="eec76-188">値の例:34</span><span class="sxs-lookup"><span data-stu-id="eec76-188">Example value: 34</span></span>|
| <span data-ttu-id="eec76-189">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="eec76-189">Cache-Control</span></span>| <span data-ttu-id="eec76-190">string</span><span class="sxs-lookup"><span data-stu-id="eec76-190">string</span></span>| <span data-ttu-id="eec76-191">キャッシュの動作を指定する、サーバーから正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="eec76-191">Polite request from the server to specify caching behavior.</span></span> <span data-ttu-id="eec76-192">例: <code>no-cache, no-store</code></span><span class="sxs-lookup"><span data-stu-id="eec76-192">Example: <code>no-cache, no-store</code></span></span>|

<a id="ID4EKAAC"></a>


## <a name="response-body"></a><span data-ttu-id="eec76-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="eec76-193">Response body</span></span>

<span data-ttu-id="eec76-194">参照してください[PermissionCheckResponse (JSON)](../../json/json-permissioncheckresponse.md)します。</span><span class="sxs-lookup"><span data-stu-id="eec76-194">See [PermissionCheckResponse (JSON)](../../json/json-permissioncheckresponse.md).</span></span>

<a id="ID4EWAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="eec76-195">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="eec76-195">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="eec76-196">関連項目</span><span class="sxs-lookup"><span data-stu-id="eec76-196">See also</span></span>

<a id="ID4ECBAC"></a>


##### <a name="parent"></a><span data-ttu-id="eec76-197">Parent</span><span class="sxs-lookup"><span data-stu-id="eec76-197">Parent</span></span>

[<span data-ttu-id="eec76-198">/users/{requestorId}/permission/validate</span><span class="sxs-lookup"><span data-stu-id="eec76-198">/users/{requestorId}/permission/validate</span></span>](uri-privacyusersrequestoridpermissionvalidate.md)

 [<span data-ttu-id="eec76-199">PermissionId 列挙型</span><span class="sxs-lookup"><span data-stu-id="eec76-199">PermissionId Enumeration</span></span>](../../enums/privacy-enum-permissionid.md)
