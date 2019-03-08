---
title: POST (/users/{requestorId}/permission/validate)
assetID: 7a5ea583-ffca-5da7-a02a-535c52535928
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidatepost.html
description: " POST (/users/{requestorId}/permission/validate)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: edd91560ffb5d81b30da4b1453612cc5853a456f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623427"
---
# <a name="post-usersrequestoridpermissionvalidate"></a><span data-ttu-id="49d16-104">POST (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="49d16-104">POST (/users/{requestorId}/permission/validate)</span></span>
<span data-ttu-id="49d16-105">対象ユーザーのセットで指定されたアクションを実行するユーザーを許可するかどうかについての回答をはいまたは no のセットを取得します。</span><span class="sxs-lookup"><span data-stu-id="49d16-105">Gets a set of yes-or-no answers about whether the user is allowed to perform specified actions with a set of target users.</span></span>

  * [<span data-ttu-id="49d16-106">注釈</span><span class="sxs-lookup"><span data-stu-id="49d16-106">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="49d16-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="49d16-107">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="49d16-108">承認</span><span class="sxs-lookup"><span data-stu-id="49d16-108">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="49d16-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49d16-109">Required Request Headers</span></span>](#ID4ESC)
  * [<span data-ttu-id="49d16-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="49d16-110">Request body</span></span>](#ID4E4D)
  * [<span data-ttu-id="49d16-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="49d16-111">HTTP status codes</span></span>](#ID4ETE)
  * [<span data-ttu-id="49d16-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49d16-112">Required Response Headers</span></span>](#ID4EIG)
  * [<span data-ttu-id="49d16-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="49d16-113">Response body</span></span>](#ID4E5H)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="49d16-114">注釈</span><span class="sxs-lookup"><span data-stu-id="49d16-114">Remarks</span></span>

<span data-ttu-id="49d16-115">要求本文には、ユーザーの一覧と、設定の一覧と、ユーザー/設定の各ペアの許可/ブロックの結果になります。</span><span class="sxs-lookup"><span data-stu-id="49d16-115">The request body takes a list of users and a list of settings, and the result is an allowed/blocked result for each user/setting pair.</span></span>

<span data-ttu-id="49d16-116">ネットワーク間のマルチ プレーヤー シナリオ (、プライバシーに関する通信のチェックを Xbox ユーザー ID (XUID) を持つユーザーとそうでないネットワークに接続してユーザーの間実行する必要があります) でを参照してください[PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md)ユーザーの種類。</span><span class="sxs-lookup"><span data-stu-id="49d16-116">In cross-network multiplayer scenarios (where privacy communications checks must be performed between users that have an Xbox User ID (XUID) and off-network users that do not), please refer to [PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md) for User types.</span></span>

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="49d16-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="49d16-117">URI parameters</span></span>

| <span data-ttu-id="49d16-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="49d16-118">Parameter</span></span>| <span data-ttu-id="49d16-119">種類</span><span class="sxs-lookup"><span data-stu-id="49d16-119">Type</span></span>| <span data-ttu-id="49d16-120">説明</span><span class="sxs-lookup"><span data-stu-id="49d16-120">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="49d16-121">requestorId</span><span class="sxs-lookup"><span data-stu-id="49d16-121">requestorId</span></span>| <span data-ttu-id="49d16-122">string</span><span class="sxs-lookup"><span data-stu-id="49d16-122">string</span></span>| <span data-ttu-id="49d16-123">必須。</span><span class="sxs-lookup"><span data-stu-id="49d16-123">Required.</span></span> <span data-ttu-id="49d16-124">アクションを実行して、ユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="49d16-124">Identifier of the user performing the action.</span></span> <span data-ttu-id="49d16-125">指定できる値は<code>xuid({xuid})</code>と<code>me</code>します。</span><span class="sxs-lookup"><span data-stu-id="49d16-125">The possible values are <code>xuid({xuid})</code> and <code>me</code>.</span></span> <span data-ttu-id="49d16-126">これには、ログイン ユーザーがあります。</span><span class="sxs-lookup"><span data-stu-id="49d16-126">This must be a logged-in user.</span></span> <span data-ttu-id="49d16-127">値の例:<code>xuid(0987654321)</code>します。</span><span class="sxs-lookup"><span data-stu-id="49d16-127">Example value: <code>xuid(0987654321)</code>.</span></span>|

<a id="ID4ENB"></a>


## <a name="authorization"></a><span data-ttu-id="49d16-128">Authorization</span><span class="sxs-lookup"><span data-stu-id="49d16-128">Authorization</span></span>

<span data-ttu-id="49d16-129">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="49d16-129">Authorization claims used</span></span> | <span data-ttu-id="49d16-130">要求</span><span class="sxs-lookup"><span data-stu-id="49d16-130">Claim</span></span>| <span data-ttu-id="49d16-131">種類</span><span class="sxs-lookup"><span data-stu-id="49d16-131">Type</span></span>| <span data-ttu-id="49d16-132">必須?</span><span class="sxs-lookup"><span data-stu-id="49d16-132">Required?</span></span>| <span data-ttu-id="49d16-133">値の例</span><span class="sxs-lookup"><span data-stu-id="49d16-133">Example value</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="49d16-134">xuid</span><span class="sxs-lookup"><span data-stu-id="49d16-134">Xuid</span></span>| <span data-ttu-id="49d16-135">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="49d16-135">64-bit signed integer</span></span>| <span data-ttu-id="49d16-136">○</span><span class="sxs-lookup"><span data-stu-id="49d16-136">yes</span></span>| <span data-ttu-id="49d16-137">1234567890</span><span class="sxs-lookup"><span data-stu-id="49d16-137">1234567890</span></span>|

<a id="ID4ESC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="49d16-138">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49d16-138">Required Request Headers</span></span>

| <span data-ttu-id="49d16-139">Header</span><span class="sxs-lookup"><span data-stu-id="49d16-139">Header</span></span>| <span data-ttu-id="49d16-140">種類</span><span class="sxs-lookup"><span data-stu-id="49d16-140">Type</span></span>| <span data-ttu-id="49d16-141">説明</span><span class="sxs-lookup"><span data-stu-id="49d16-141">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="49d16-142">Authorization</span><span class="sxs-lookup"><span data-stu-id="49d16-142">Authorization</span></span>| <span data-ttu-id="49d16-143">string</span><span class="sxs-lookup"><span data-stu-id="49d16-143">string</span></span>| <span data-ttu-id="49d16-144">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="49d16-144">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="49d16-145">値の例: <code>XBL3.0 x=&lt;userhash>;&lt;token></code></span><span class="sxs-lookup"><span data-stu-id="49d16-145">Example values: <code>XBL3.0 x=&lt;userhash>;&lt;token></code></span></span>|
| <span data-ttu-id="49d16-146">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="49d16-146">X-RequestedServiceVersion</span></span>| <span data-ttu-id="49d16-147">string</span><span class="sxs-lookup"><span data-stu-id="49d16-147">string</span></span>| <span data-ttu-id="49d16-148">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="49d16-148">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="49d16-149">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。値の例:1. </span><span class="sxs-lookup"><span data-stu-id="49d16-149">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Example value: 1.</span></span>|

<a id="ID4E4D"></a>


## <a name="request-body"></a><span data-ttu-id="49d16-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="49d16-150">Request body</span></span>

<a id="ID4EDE"></a>


### <a name="required-members"></a><span data-ttu-id="49d16-151">必須メンバー</span><span class="sxs-lookup"><span data-stu-id="49d16-151">Required members</span></span>

<span data-ttu-id="49d16-152">参照してください[PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md)します。</span><span class="sxs-lookup"><span data-stu-id="49d16-152">See [PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md).</span></span>


```cpp
{
    "users":
    [
        {"xuid":"12345"},
        {"xuid":"54321"}
    ],
    "permissions":
    [
        "ViewTargetGameHistory",
        "ViewTargetProfile"
    ]
}

```


<a id="ID4ETE"></a>


## <a name="http-status-codes"></a><span data-ttu-id="49d16-153">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="49d16-153">HTTP status codes</span></span>

<span data-ttu-id="49d16-154">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="49d16-154">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="49d16-155">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="49d16-155">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="49d16-156">コード</span><span class="sxs-lookup"><span data-stu-id="49d16-156">Code</span></span>| <span data-ttu-id="49d16-157">理由語句</span><span class="sxs-lookup"><span data-stu-id="49d16-157">Reason phrase</span></span>| <span data-ttu-id="49d16-158">説明</span><span class="sxs-lookup"><span data-stu-id="49d16-158">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="49d16-159">200</span><span class="sxs-lookup"><span data-stu-id="49d16-159">200</span></span>| <span data-ttu-id="49d16-160">OK</span><span class="sxs-lookup"><span data-stu-id="49d16-160">OK</span></span>| <span data-ttu-id="49d16-161">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="49d16-161">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="49d16-162">400</span><span class="sxs-lookup"><span data-stu-id="49d16-162">400</span></span>| <span data-ttu-id="49d16-163">要求が無効です。</span><span class="sxs-lookup"><span data-stu-id="49d16-163">The request is invalid.</span></span>| <span data-ttu-id="49d16-164">例: 設定が正しくない Id、Uri が正しくないなど。</span><span class="sxs-lookup"><span data-stu-id="49d16-164">Examples: incorrect setting IDs, incorrect URIs, etc.</span></span>|
| <span data-ttu-id="49d16-165">404</span><span class="sxs-lookup"><span data-stu-id="49d16-165">404</span></span>| <span data-ttu-id="49d16-166">URI で指定されたユーザーは存在しません。</span><span class="sxs-lookup"><span data-stu-id="49d16-166">The user specified in the URI does not exist.</span></span>| <span data-ttu-id="49d16-167">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="49d16-167">The specified resource could not be found.</span></span>|

<a id="ID4EIG"></a>


## <a name="required-response-headers"></a><span data-ttu-id="49d16-168">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49d16-168">Required Response Headers</span></span>

| <span data-ttu-id="49d16-169">Header</span><span class="sxs-lookup"><span data-stu-id="49d16-169">Header</span></span>| <span data-ttu-id="49d16-170">種類</span><span class="sxs-lookup"><span data-stu-id="49d16-170">Type</span></span>| <span data-ttu-id="49d16-171">説明</span><span class="sxs-lookup"><span data-stu-id="49d16-171">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="49d16-172">Content-Type</span><span class="sxs-lookup"><span data-stu-id="49d16-172">Content-Type</span></span>| <span data-ttu-id="49d16-173">string</span><span class="sxs-lookup"><span data-stu-id="49d16-173">string</span></span>| <span data-ttu-id="49d16-174">要求の本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="49d16-174">The MIME type of the body of the request.</span></span> <span data-ttu-id="49d16-175">値の例: <code>application/json</code></span><span class="sxs-lookup"><span data-stu-id="49d16-175">Example value: <code>application/json</code></span></span>|
| <span data-ttu-id="49d16-176">Content-Length</span><span class="sxs-lookup"><span data-stu-id="49d16-176">Content-Length</span></span>| <span data-ttu-id="49d16-177">string</span><span class="sxs-lookup"><span data-stu-id="49d16-177">string</span></span>| <span data-ttu-id="49d16-178">応答で送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="49d16-178">The number of bytes being sent in the response.</span></span> <span data-ttu-id="49d16-179">値の例:34</span><span class="sxs-lookup"><span data-stu-id="49d16-179">Example value: 34</span></span>|
| <span data-ttu-id="49d16-180">キャッシュ制御</span><span class="sxs-lookup"><span data-stu-id="49d16-180">Cache-Control</span></span>| <span data-ttu-id="49d16-181">string</span><span class="sxs-lookup"><span data-stu-id="49d16-181">string</span></span>| <span data-ttu-id="49d16-182">キャッシュの動作を指定する、サーバーから正常な要求です。</span><span class="sxs-lookup"><span data-stu-id="49d16-182">Polite request from the server to specify caching behavior.</span></span> <span data-ttu-id="49d16-183">例: <code>no-cache, no-store</code></span><span class="sxs-lookup"><span data-stu-id="49d16-183">Example: <code>no-cache, no-store</code></span></span>|

<a id="ID4E5H"></a>


## <a name="response-body"></a><span data-ttu-id="49d16-184">応答本文</span><span class="sxs-lookup"><span data-stu-id="49d16-184">Response body</span></span>

<span data-ttu-id="49d16-185">参照してください[PermissionCheckBatchResponse (JSON)](../../json/json-permissioncheckbatchresponse.md)します。</span><span class="sxs-lookup"><span data-stu-id="49d16-185">See [PermissionCheckBatchResponse (JSON)](../../json/json-permissioncheckbatchresponse.md).</span></span>

<a id="ID4ELAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="49d16-186">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="49d16-186">Sample response</span></span>


```cpp
{
    "responses":
    [
        {
            "user": {"xuid":"12345"},
            "permissions":
            [
                {
                    "isAllowed":true
                },
                {
                    "isAllowed":true
                }
            ]
        },
        {
            "user": {"xuid":"54321"},
            "permissions":
            [
                {
                    "isAllowed":false,
                    "reasons":
                    [
                        {"reason":"NotAllowed"}
                    ]
                },
                {
                    "isAllowed":false,
                    "reasons":
                    [
                        {"reason":"PrivilegeRest", "restrictedSetting":"AllowProfileViewing"}
                    ]
                }
            ]
        }
    ]
}

```


<a id="ID4EVAAC"></a>


## <a name="see-also"></a><span data-ttu-id="49d16-187">関連項目</span><span class="sxs-lookup"><span data-stu-id="49d16-187">See also</span></span>

<a id="ID4EXAAC"></a>


##### <a name="parent"></a><span data-ttu-id="49d16-188">Parent</span><span class="sxs-lookup"><span data-stu-id="49d16-188">Parent</span></span>

[<span data-ttu-id="49d16-189">/users/{requestorId}/permission/validate</span><span class="sxs-lookup"><span data-stu-id="49d16-189">/users/{requestorId}/permission/validate</span></span>](uri-privacyusersrequestoridpermissionvalidate.md)

 [<span data-ttu-id="49d16-190">PermissionId 列挙型</span><span class="sxs-lookup"><span data-stu-id="49d16-190">PermissionId Enumeration</span></span>](../../enums/privacy-enum-permissionid.md)
