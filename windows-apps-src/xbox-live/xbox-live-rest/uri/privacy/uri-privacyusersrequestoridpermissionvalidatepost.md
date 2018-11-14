---
title: POST (/users/{requestorId}/permission/validate)
assetID: 7a5ea583-ffca-5da7-a02a-535c52535928
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidatepost.html
author: KevinAsgari
description: " POST (/users/{requestorId}/permission/validate)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0848aaa74fcecec599c701d944c54defae1fa011
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6275602"
---
# <a name="post-usersrequestoridpermissionvalidate"></a><span data-ttu-id="9536f-104">POST (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="9536f-104">POST (/users/{requestorId}/permission/validate)</span></span>
<span data-ttu-id="9536f-105">一連のユーザーをターゲット ユーザーのセットを指定したアクションを実行できるかどうかに関するはいまたは no に対する回答を取得します。</span><span class="sxs-lookup"><span data-stu-id="9536f-105">Gets a set of yes-or-no answers about whether the user is allowed to perform specified actions with a set of target users.</span></span>

  * [<span data-ttu-id="9536f-106">注釈</span><span class="sxs-lookup"><span data-stu-id="9536f-106">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="9536f-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9536f-107">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="9536f-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="9536f-108">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="9536f-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9536f-109">Required Request Headers</span></span>](#ID4ESC)
  * [<span data-ttu-id="9536f-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="9536f-110">Request body</span></span>](#ID4E4D)
  * [<span data-ttu-id="9536f-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="9536f-111">HTTP status codes</span></span>](#ID4ETE)
  * [<span data-ttu-id="9536f-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9536f-112">Required Response Headers</span></span>](#ID4EIG)
  * [<span data-ttu-id="9536f-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="9536f-113">Response body</span></span>](#ID4E5H)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="9536f-114">注釈</span><span class="sxs-lookup"><span data-stu-id="9536f-114">Remarks</span></span>

<span data-ttu-id="9536f-115">要求本文には、ユーザーの一覧と、設定の一覧と、各ユーザーの設定/ペアの許可/ブロックの結果になります。</span><span class="sxs-lookup"><span data-stu-id="9536f-115">The request body takes a list of users and a list of settings, and the result is an allowed/blocked result for each user/setting pair.</span></span>

<span data-ttu-id="9536f-116">シナリオではクロス ネットワーク マルチプレイヤー (場所プライバシー通信チェックを Xbox ユーザー ID (XUID) のユーザーとそうでないネットワークに接続してユーザーの間で実行する必要があります)、ユーザーの種類の[PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9536f-116">In cross-network multiplayer scenarios (where privacy communications checks must be performed between users that have an Xbox User ID (XUID) and off-network users that do not), please refer to [PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md) for User types.</span></span>

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="9536f-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9536f-117">URI parameters</span></span>

| <span data-ttu-id="9536f-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9536f-118">Parameter</span></span>| <span data-ttu-id="9536f-119">型</span><span class="sxs-lookup"><span data-stu-id="9536f-119">Type</span></span>| <span data-ttu-id="9536f-120">説明</span><span class="sxs-lookup"><span data-stu-id="9536f-120">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="9536f-121">requestorId</span><span class="sxs-lookup"><span data-stu-id="9536f-121">requestorId</span></span>| <span data-ttu-id="9536f-122">string</span><span class="sxs-lookup"><span data-stu-id="9536f-122">string</span></span>| <span data-ttu-id="9536f-123">必須。</span><span class="sxs-lookup"><span data-stu-id="9536f-123">Required.</span></span> <span data-ttu-id="9536f-124">アクションを実行しているユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="9536f-124">Identifier of the user performing the action.</span></span> <span data-ttu-id="9536f-125">可能な値は<code>xuid({xuid})</code>と<code>me</code>します。</span><span class="sxs-lookup"><span data-stu-id="9536f-125">The possible values are <code>xuid({xuid})</code> and <code>me</code>.</span></span> <span data-ttu-id="9536f-126">これは、ログインしているユーザーでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="9536f-126">This must be a logged-in user.</span></span> <span data-ttu-id="9536f-127">値の例:<code>xuid(0987654321)</code>します。</span><span class="sxs-lookup"><span data-stu-id="9536f-127">Example value: <code>xuid(0987654321)</code>.</span></span>|

<a id="ID4ENB"></a>


## <a name="authorization"></a><span data-ttu-id="9536f-128">Authorization</span><span class="sxs-lookup"><span data-stu-id="9536f-128">Authorization</span></span>

<span data-ttu-id="9536f-129">承認要求の使用</span><span class="sxs-lookup"><span data-stu-id="9536f-129">Authorization claims used</span></span> | <span data-ttu-id="9536f-130">要求</span><span class="sxs-lookup"><span data-stu-id="9536f-130">Claim</span></span>| <span data-ttu-id="9536f-131">種類</span><span class="sxs-lookup"><span data-stu-id="9536f-131">Type</span></span>| <span data-ttu-id="9536f-132">必須?</span><span class="sxs-lookup"><span data-stu-id="9536f-132">Required?</span></span>| <span data-ttu-id="9536f-133">値の例</span><span class="sxs-lookup"><span data-stu-id="9536f-133">Example value</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="9536f-134">Xuid</span><span class="sxs-lookup"><span data-stu-id="9536f-134">Xuid</span></span>| <span data-ttu-id="9536f-135">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="9536f-135">64-bit signed integer</span></span>| <span data-ttu-id="9536f-136">必須</span><span class="sxs-lookup"><span data-stu-id="9536f-136">yes</span></span>| <span data-ttu-id="9536f-137">1234567890</span><span class="sxs-lookup"><span data-stu-id="9536f-137">1234567890</span></span>|

<a id="ID4ESC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="9536f-138">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9536f-138">Required Request Headers</span></span>

| <span data-ttu-id="9536f-139">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9536f-139">Header</span></span>| <span data-ttu-id="9536f-140">型</span><span class="sxs-lookup"><span data-stu-id="9536f-140">Type</span></span>| <span data-ttu-id="9536f-141">説明</span><span class="sxs-lookup"><span data-stu-id="9536f-141">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="9536f-142">Authorization</span><span class="sxs-lookup"><span data-stu-id="9536f-142">Authorization</span></span>| <span data-ttu-id="9536f-143">string</span><span class="sxs-lookup"><span data-stu-id="9536f-143">string</span></span>| <span data-ttu-id="9536f-144">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="9536f-144">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="9536f-145">値の例:</span><span class="sxs-lookup"><span data-stu-id="9536f-145">Example values:</span></span> <code>XBL3.0 x=&lt;userhash>;&lt;token></code>|
| <span data-ttu-id="9536f-146">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="9536f-146">X-RequestedServiceVersion</span></span>| <span data-ttu-id="9536f-147">string</span><span class="sxs-lookup"><span data-stu-id="9536f-147">string</span></span>| <span data-ttu-id="9536f-148">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="9536f-148">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="9536f-149">要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。値の例: 1 です。</span><span class="sxs-lookup"><span data-stu-id="9536f-149">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Example value: 1.</span></span>|

<a id="ID4E4D"></a>


## <a name="request-body"></a><span data-ttu-id="9536f-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="9536f-150">Request body</span></span>

<a id="ID4EDE"></a>


### <a name="required-members"></a><span data-ttu-id="9536f-151">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="9536f-151">Required members</span></span>

<span data-ttu-id="9536f-152">[PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9536f-152">See [PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md).</span></span>


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


## <a name="http-status-codes"></a><span data-ttu-id="9536f-153">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="9536f-153">HTTP status codes</span></span>

<span data-ttu-id="9536f-154">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="9536f-154">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="9536f-155">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9536f-155">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="9536f-156">コード</span><span class="sxs-lookup"><span data-stu-id="9536f-156">Code</span></span>| <span data-ttu-id="9536f-157">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="9536f-157">Reason phrase</span></span>| <span data-ttu-id="9536f-158">説明</span><span class="sxs-lookup"><span data-stu-id="9536f-158">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="9536f-159">200</span><span class="sxs-lookup"><span data-stu-id="9536f-159">200</span></span>| <span data-ttu-id="9536f-160">OK</span><span class="sxs-lookup"><span data-stu-id="9536f-160">OK</span></span>| <span data-ttu-id="9536f-161">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="9536f-161">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="9536f-162">400</span><span class="sxs-lookup"><span data-stu-id="9536f-162">400</span></span>| <span data-ttu-id="9536f-163">要求が無効です。</span><span class="sxs-lookup"><span data-stu-id="9536f-163">The request is invalid.</span></span>| <span data-ttu-id="9536f-164">例: が正しく設定 Id、不適切な Uri などです。</span><span class="sxs-lookup"><span data-stu-id="9536f-164">Examples: incorrect setting IDs, incorrect URIs, etc.</span></span>|
| <span data-ttu-id="9536f-165">404</span><span class="sxs-lookup"><span data-stu-id="9536f-165">404</span></span>| <span data-ttu-id="9536f-166">URI で指定されたユーザーが存在しません。</span><span class="sxs-lookup"><span data-stu-id="9536f-166">The user specified in the URI does not exist.</span></span>| <span data-ttu-id="9536f-167">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="9536f-167">The specified resource could not be found.</span></span>|

<a id="ID4EIG"></a>


## <a name="required-response-headers"></a><span data-ttu-id="9536f-168">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9536f-168">Required Response Headers</span></span>

| <span data-ttu-id="9536f-169">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9536f-169">Header</span></span>| <span data-ttu-id="9536f-170">型</span><span class="sxs-lookup"><span data-stu-id="9536f-170">Type</span></span>| <span data-ttu-id="9536f-171">説明</span><span class="sxs-lookup"><span data-stu-id="9536f-171">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="9536f-172">Content-Type</span><span class="sxs-lookup"><span data-stu-id="9536f-172">Content-Type</span></span>| <span data-ttu-id="9536f-173">string</span><span class="sxs-lookup"><span data-stu-id="9536f-173">string</span></span>| <span data-ttu-id="9536f-174">要求の本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="9536f-174">The MIME type of the body of the request.</span></span> <span data-ttu-id="9536f-175">値の例:</span><span class="sxs-lookup"><span data-stu-id="9536f-175">Example value:</span></span> <code>application/json</code>|
| <span data-ttu-id="9536f-176">Content-Length</span><span class="sxs-lookup"><span data-stu-id="9536f-176">Content-Length</span></span>| <span data-ttu-id="9536f-177">string</span><span class="sxs-lookup"><span data-stu-id="9536f-177">string</span></span>| <span data-ttu-id="9536f-178">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="9536f-178">The number of bytes being sent in the response.</span></span> <span data-ttu-id="9536f-179">値の例: 34</span><span class="sxs-lookup"><span data-stu-id="9536f-179">Example value: 34</span></span>|
| <span data-ttu-id="9536f-180">キャッシュ コントロール</span><span class="sxs-lookup"><span data-stu-id="9536f-180">Cache-Control</span></span>| <span data-ttu-id="9536f-181">string</span><span class="sxs-lookup"><span data-stu-id="9536f-181">string</span></span>| <span data-ttu-id="9536f-182">キャッシュ動作を指定する、サーバーからていねい要求します。</span><span class="sxs-lookup"><span data-stu-id="9536f-182">Polite request from the server to specify caching behavior.</span></span> <span data-ttu-id="9536f-183">例:</span><span class="sxs-lookup"><span data-stu-id="9536f-183">Example:</span></span> <code>no-cache, no-store</code>|

<a id="ID4E5H"></a>


## <a name="response-body"></a><span data-ttu-id="9536f-184">応答本文</span><span class="sxs-lookup"><span data-stu-id="9536f-184">Response body</span></span>

<span data-ttu-id="9536f-185">[PermissionCheckBatchResponse (JSON)](../../json/json-permissioncheckbatchresponse.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9536f-185">See [PermissionCheckBatchResponse (JSON)](../../json/json-permissioncheckbatchresponse.md).</span></span>

<a id="ID4ELAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="9536f-186">応答の例</span><span class="sxs-lookup"><span data-stu-id="9536f-186">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="9536f-187">関連項目</span><span class="sxs-lookup"><span data-stu-id="9536f-187">See also</span></span>

<a id="ID4EXAAC"></a>


##### <a name="parent"></a><span data-ttu-id="9536f-188">Parent</span><span class="sxs-lookup"><span data-stu-id="9536f-188">Parent</span></span>

[<span data-ttu-id="9536f-189">/users/{requestorId}/permission/validate</span><span class="sxs-lookup"><span data-stu-id="9536f-189">/users/{requestorId}/permission/validate</span></span>](uri-privacyusersrequestoridpermissionvalidate.md)

 [<span data-ttu-id="9536f-190">PermissionId 列挙型</span><span class="sxs-lookup"><span data-stu-id="9536f-190">PermissionId Enumeration</span></span>](../../enums/privacy-enum-permissionid.md)
