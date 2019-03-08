---
title: GET (/users/{ownerId}/people)
assetID: c948d031-ec19-7571-31ef-23cb9c5ebfaf
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopleget.html
description: " GET (/users/{ownerId}/people)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6c8672188a93b2e8d27a081ae068387e7ee7aa42
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623767"
---
# <a name="get-usersowneridpeople"></a><span data-ttu-id="e47d1-104">GET (/users/{ownerId}/people)</span><span class="sxs-lookup"><span data-stu-id="e47d1-104">GET (/users/{ownerId}/people)</span></span>
<span data-ttu-id="e47d1-105">呼び出し元のユーザー コレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-105">Gets caller's people collection.</span></span>
<span data-ttu-id="e47d1-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-106">The domain for these URIs is `social.xboxlive.com`.</span></span>

  * [<span data-ttu-id="e47d1-107">注釈</span><span class="sxs-lookup"><span data-stu-id="e47d1-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="e47d1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e47d1-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="e47d1-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e47d1-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="e47d1-110">承認</span><span class="sxs-lookup"><span data-stu-id="e47d1-110">Authorization</span></span>](#ID4ERD)
  * [<span data-ttu-id="e47d1-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e47d1-111">Required Request Headers</span></span>](#ID4EZE)
  * [<span data-ttu-id="e47d1-112">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e47d1-112">Optional Request Headers</span></span>](#ID4EYF)
  * [<span data-ttu-id="e47d1-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="e47d1-113">Request body</span></span>](#ID4E5G)
  * [<span data-ttu-id="e47d1-114">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e47d1-114">HTTP status codes</span></span>](#ID4EJH)
  * [<span data-ttu-id="e47d1-115">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e47d1-115">Required Response Headers</span></span>](#ID4EBBAC)
  * [<span data-ttu-id="e47d1-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="e47d1-116">Response body</span></span>](#ID4ENCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="e47d1-117">注釈</span><span class="sxs-lookup"><span data-stu-id="e47d1-117">Remarks</span></span>

<span data-ttu-id="e47d1-118">GET 操作は、この 1 回または複数回実行された場合、同じ結果が生成されますのですべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="e47d1-118">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>

<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="e47d1-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e47d1-119">URI parameters</span></span>

| <span data-ttu-id="e47d1-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e47d1-120">Parameter</span></span>| <span data-ttu-id="e47d1-121">種類</span><span class="sxs-lookup"><span data-stu-id="e47d1-121">Type</span></span>| <span data-ttu-id="e47d1-122">説明</span><span class="sxs-lookup"><span data-stu-id="e47d1-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="e47d1-123">ownerId</span><span class="sxs-lookup"><span data-stu-id="e47d1-123">ownerId</span></span>| <span data-ttu-id="e47d1-124">string</span><span class="sxs-lookup"><span data-stu-id="e47d1-124">string</span></span>| <span data-ttu-id="e47d1-125">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="e47d1-125">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="e47d1-126">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e47d1-126">Must match the authenticated user.</span></span> <span data-ttu-id="e47d1-127">使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="e47d1-127">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>|

<a id="ID4EJB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="e47d1-128">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e47d1-128">Query string parameters</span></span>

| <span data-ttu-id="e47d1-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e47d1-129">Parameter</span></span>| <span data-ttu-id="e47d1-130">種類</span><span class="sxs-lookup"><span data-stu-id="e47d1-130">Type</span></span>| <span data-ttu-id="e47d1-131">説明</span><span class="sxs-lookup"><span data-stu-id="e47d1-131">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="e47d1-132">表示</span><span class="sxs-lookup"><span data-stu-id="e47d1-132">view</span></span>| <span data-ttu-id="e47d1-133">string</span><span class="sxs-lookup"><span data-stu-id="e47d1-133">string</span></span>| <span data-ttu-id="e47d1-134">ビューに関連付けられているユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-134">Return the people associated with a view.</span></span> <span data-ttu-id="e47d1-135">既定値は、"all"です。</span><span class="sxs-lookup"><span data-stu-id="e47d1-135">The default value is "all".</span></span> <span data-ttu-id="e47d1-136">設定できる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="e47d1-136">The possible values are:</span></span> <ul><li><span data-ttu-id="e47d1-137"><b>すべて</b>-ユーザーの連絡先リスト上のすべてのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-137"><b>All</b> - Returns all People on the user's People list.</span></span> <span data-ttu-id="e47d1-138">これが既定値です。</span><span class="sxs-lookup"><span data-stu-id="e47d1-138">This is the default value.</span></span></li><li><span data-ttu-id="e47d1-139"><b>お気に入り</b>-お気に入りの属性を持っているユーザーの連絡先リスト上のすべてのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-139"><b>Favorite</b> - Returns all People on the user's People list who have the Favorite attribute.</span></span></li><li><span data-ttu-id="e47d1-140"><b>LegacyXboxLiveFriends</b> -従来の Xbox LIVE フレンドでもあるユーザーの連絡先リスト上のすべてのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-140"><b>LegacyXboxLiveFriends</b> - Returns all People on the user's People list who are also legacy Xbox LIVE friends.</span></span></li></br><span data-ttu-id="e47d1-141">**注:** のみ、**すべて**呼び出し元のユーザーが所有しているユーザーと異なる場合、値はサポートされています。</span><span class="sxs-lookup"><span data-stu-id="e47d1-141">**Note:**  Only the **All** value is supported if the calling user is different than the owning user.</span></span>|
| <span data-ttu-id="e47d1-142">startIndex</span><span class="sxs-lookup"><span data-stu-id="e47d1-142">startIndex</span></span>| <span data-ttu-id="e47d1-143">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e47d1-143">32-bit unsigned integer</span></span>| <span data-ttu-id="e47d1-144">指定したインデックスから始まるアイテムを返します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-144">Return the items starting at the given index.</span></span>  
| <span data-ttu-id="e47d1-145">maxItems</span><span class="sxs-lookup"><span data-stu-id="e47d1-145">maxItems</span></span>| <span data-ttu-id="e47d1-146">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e47d1-146">32-bit unsigned integer</span></span>| <span data-ttu-id="e47d1-147">開始インデックス位置からコレクションから返されるユーザーの最大数。</span><span class="sxs-lookup"><span data-stu-id="e47d1-147">Maximum number of people to return from the collection starting from the start index.</span></span> <span data-ttu-id="e47d1-148">場合、サービスは、既定値を指定可能性があります<b>maxItems</b>が存在しないより少ないを返すことが<b>maxItems</b> (結果の最後のページはまだ返送されていない) 場合でもです。</span><span class="sxs-lookup"><span data-stu-id="e47d1-148">The service may provide a default value if <b>maxItems</b> is not present and may return fewer than <b>maxItems</b> (even if the last page of results has not yet been returned).</span></span>|

<a id="ID4ERD"></a>


## <a name="authorization"></a><span data-ttu-id="e47d1-149">Authorization</span><span class="sxs-lookup"><span data-stu-id="e47d1-149">Authorization</span></span>

| <span data-ttu-id="e47d1-150">種類</span><span class="sxs-lookup"><span data-stu-id="e47d1-150">Type</span></span>| <span data-ttu-id="e47d1-151">必須</span><span class="sxs-lookup"><span data-stu-id="e47d1-151">Required</span></span>| <span data-ttu-id="e47d1-152">説明</span><span class="sxs-lookup"><span data-stu-id="e47d1-152">Description</span></span>| <span data-ttu-id="e47d1-153">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="e47d1-153">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="e47d1-154">XUID</span><span class="sxs-lookup"><span data-stu-id="e47d1-154">XUID</span></span>| <span data-ttu-id="e47d1-155">○</span><span class="sxs-lookup"><span data-stu-id="e47d1-155">yes</span></span>| <span data-ttu-id="e47d1-156">呼び出し元が、ユーザーの Xbox ユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="e47d1-156">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="e47d1-157">401 許可されていません</span><span class="sxs-lookup"><span data-stu-id="e47d1-157">401 Unauthorized</span></span>|

<a id="ID4EZE"></a>


## <a name="required-request-headers"></a><span data-ttu-id="e47d1-158">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e47d1-158">Required Request Headers</span></span>

| <span data-ttu-id="e47d1-159">Header</span><span class="sxs-lookup"><span data-stu-id="e47d1-159">Header</span></span>| <span data-ttu-id="e47d1-160">説明</span><span class="sxs-lookup"><span data-stu-id="e47d1-160">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="e47d1-161">Authorization</span><span class="sxs-lookup"><span data-stu-id="e47d1-161">Authorization</span></span>| <span data-ttu-id="e47d1-162">[String]。</span><span class="sxs-lookup"><span data-stu-id="e47d1-162">String.</span></span> <span data-ttu-id="e47d1-163">Xbox LIVE の承認データです。</span><span class="sxs-lookup"><span data-stu-id="e47d1-163">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="e47d1-164">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="e47d1-164">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="e47d1-165">値の例:<b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-165">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>|

<a id="ID4EYF"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="e47d1-166">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e47d1-166">Optional Request Headers</span></span>

| <span data-ttu-id="e47d1-167">Header</span><span class="sxs-lookup"><span data-stu-id="e47d1-167">Header</span></span>| <span data-ttu-id="e47d1-168">説明</span><span class="sxs-lookup"><span data-stu-id="e47d1-168">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="e47d1-169">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="e47d1-169">X-RequestedServiceVersion</span></span>| <span data-ttu-id="e47d1-170">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="e47d1-170">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="e47d1-171">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="e47d1-171">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>|
| <span data-ttu-id="e47d1-172">OK</span><span class="sxs-lookup"><span data-stu-id="e47d1-172">Accept</span></span>| <span data-ttu-id="e47d1-173">[String]。</span><span class="sxs-lookup"><span data-stu-id="e47d1-173">String.</span></span> <span data-ttu-id="e47d1-174">コンテンツ タイプを呼び出し元が応答で受け取る。</span><span class="sxs-lookup"><span data-stu-id="e47d1-174">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="e47d1-175">すべての応答は<b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-175">All responses are <b>application/json</b>.</span></span>|

<a id="ID4E5G"></a>


## <a name="request-body"></a><span data-ttu-id="e47d1-176">要求本文</span><span class="sxs-lookup"><span data-stu-id="e47d1-176">Request body</span></span>

<span data-ttu-id="e47d1-177">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e47d1-177">No objects are sent in the body of this request.</span></span>

<a id="ID4EJH"></a>


## <a name="http-status-codes"></a><span data-ttu-id="e47d1-178">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e47d1-178">HTTP status codes</span></span>

<span data-ttu-id="e47d1-179">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-179">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="e47d1-180">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-180">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="e47d1-181">コード</span><span class="sxs-lookup"><span data-stu-id="e47d1-181">Code</span></span>| <span data-ttu-id="e47d1-182">理由語句</span><span class="sxs-lookup"><span data-stu-id="e47d1-182">Reason phrase</span></span>| <span data-ttu-id="e47d1-183">説明</span><span class="sxs-lookup"><span data-stu-id="e47d1-183">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="e47d1-184">200</span><span class="sxs-lookup"><span data-stu-id="e47d1-184">200</span></span>| <span data-ttu-id="e47d1-185">OK</span><span class="sxs-lookup"><span data-stu-id="e47d1-185">OK</span></span>| <span data-ttu-id="e47d1-186">成功しました。</span><span class="sxs-lookup"><span data-stu-id="e47d1-186">Success.</span></span>|
| <span data-ttu-id="e47d1-187">400</span><span class="sxs-lookup"><span data-stu-id="e47d1-187">400</span></span>| <span data-ttu-id="e47d1-188">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="e47d1-188">Bad Request</span></span>| <span data-ttu-id="e47d1-189">クエリ パラメーターまたはユーザー Id は、形式が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="e47d1-189">Query parameters or user IDs were malformed.</span></span>|
| <span data-ttu-id="e47d1-190">403</span><span class="sxs-lookup"><span data-stu-id="e47d1-190">403</span></span>| <span data-ttu-id="e47d1-191">Forbidden</span><span class="sxs-lookup"><span data-stu-id="e47d1-191">Forbidden</span></span>| <span data-ttu-id="e47d1-192">Authorization ヘッダーから XUID 要求を解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="e47d1-192">XUID claim could not be parsed from the authorization header.</span></span>|

<a id="ID4EBBAC"></a>


## <a name="required-response-headers"></a><span data-ttu-id="e47d1-193">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e47d1-193">Required Response Headers</span></span>

| <span data-ttu-id="e47d1-194">Header</span><span class="sxs-lookup"><span data-stu-id="e47d1-194">Header</span></span>| <span data-ttu-id="e47d1-195">種類</span><span class="sxs-lookup"><span data-stu-id="e47d1-195">Type</span></span>| <span data-ttu-id="e47d1-196">説明</span><span class="sxs-lookup"><span data-stu-id="e47d1-196">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="e47d1-197">Content-Length</span><span class="sxs-lookup"><span data-stu-id="e47d1-197">Content-Length</span></span>| <span data-ttu-id="e47d1-198">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e47d1-198">32-bit unsigned integer</span></span>| <span data-ttu-id="e47d1-199">長さをバイト単位で、応答本文。</span><span class="sxs-lookup"><span data-stu-id="e47d1-199">Length, in bytes, of the response body.</span></span> <span data-ttu-id="e47d1-200">値の例:22.</span><span class="sxs-lookup"><span data-stu-id="e47d1-200">Example value: 22.</span></span>|
| <span data-ttu-id="e47d1-201">Content-Type</span><span class="sxs-lookup"><span data-stu-id="e47d1-201">Content-Type</span></span>| <span data-ttu-id="e47d1-202">string</span><span class="sxs-lookup"><span data-stu-id="e47d1-202">string</span></span>| <span data-ttu-id="e47d1-203">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="e47d1-203">MIME type of the response body.</span></span> <span data-ttu-id="e47d1-204">常に<b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-204">This will always be <b>application/json</b>.</span></span>|

<a id="ID4ENCAC"></a>


## <a name="response-body"></a><span data-ttu-id="e47d1-205">応答本文</span><span class="sxs-lookup"><span data-stu-id="e47d1-205">Response body</span></span>

<span data-ttu-id="e47d1-206">呼び出しが成功した場合、サービスは、呼び出し元のユーザーのコレクション、および呼び出し元のユーザー コレクションを格納する配列内のユーザーの合計数を返します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-206">If the call is successful, the service returns the total number of people in the caller's people collection, and an array containing the caller's people collection.</span></span> <span data-ttu-id="e47d1-207">参照してください[PeopleList (JSON)](../../json/json-peoplelist.md)します。</span><span class="sxs-lookup"><span data-stu-id="e47d1-207">See [PeopleList (JSON)](../../json/json-peoplelist.md).</span></span>

<a id="ID4EZCAC"></a>


### <a name="sample-response"></a><span data-ttu-id="e47d1-208">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="e47d1-208">Sample response</span></span>


```cpp
{
    "people": [
        {
            "xuid": "2603643534573573",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573572",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573577",
            "isFollowingCaller": false,
            "isFavorite": false
        },
    ],
    "totalCount": 3
}

```


<a id="ID4EDDAC"></a>


## <a name="see-also"></a><span data-ttu-id="e47d1-209">関連項目</span><span class="sxs-lookup"><span data-stu-id="e47d1-209">See also</span></span>

<a id="ID4EFDAC"></a>


##### <a name="parent"></a><span data-ttu-id="e47d1-210">Parent</span><span class="sxs-lookup"><span data-stu-id="e47d1-210">Parent</span></span>

[<span data-ttu-id="e47d1-211">/users/{ownerId}/people</span><span class="sxs-lookup"><span data-stu-id="e47d1-211">/users/{ownerId}/people</span></span>](uri-usersowneridpeople.md)
