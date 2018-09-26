---
title: GET (/users/{ownerId}/people)
assetID: c948d031-ec19-7571-31ef-23cb9c5ebfaf
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopleget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/people)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d08a8ff9e04b255944128ffc1cd1c0b101180d8f
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4209509"
---
# <a name="get-usersowneridpeople"></a><span data-ttu-id="b4ab5-104">GET (/users/{ownerId}/people)</span><span class="sxs-lookup"><span data-stu-id="b4ab5-104">GET (/users/{ownerId}/people)</span></span>
<span data-ttu-id="b4ab5-105">呼び出し元のユーザーのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-105">Gets caller's people collection.</span></span>
<span data-ttu-id="b4ab5-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-106">The domain for these URIs is `social.xboxlive.com`.</span></span>

  * [<span data-ttu-id="b4ab5-107">注釈</span><span class="sxs-lookup"><span data-stu-id="b4ab5-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="b4ab5-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab5-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="b4ab5-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab5-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="b4ab5-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="b4ab5-110">Authorization</span></span>](#ID4ERD)
  * [<span data-ttu-id="b4ab5-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab5-111">Required Request Headers</span></span>](#ID4EZE)
  * [<span data-ttu-id="b4ab5-112">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab5-112">Optional Request Headers</span></span>](#ID4EYF)
  * [<span data-ttu-id="b4ab5-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="b4ab5-113">Request body</span></span>](#ID4E5G)
  * [<span data-ttu-id="b4ab5-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="b4ab5-114">HTTP status codes</span></span>](#ID4EJH)
  * [<span data-ttu-id="b4ab5-115">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab5-115">Required Response Headers</span></span>](#ID4EBBAC)
  * [<span data-ttu-id="b4ab5-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="b4ab5-116">Response body</span></span>](#ID4ENCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="b4ab5-117">注釈</span><span class="sxs-lookup"><span data-stu-id="b4ab5-117">Remarks</span></span>

<span data-ttu-id="b4ab5-118">これと同じ結果に 1 回または複数回実行する場合、GET 操作はすべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-118">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>

<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="b4ab5-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab5-119">URI parameters</span></span>

| <span data-ttu-id="b4ab5-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab5-120">Parameter</span></span>| <span data-ttu-id="b4ab5-121">型</span><span class="sxs-lookup"><span data-stu-id="b4ab5-121">Type</span></span>| <span data-ttu-id="b4ab5-122">説明</span><span class="sxs-lookup"><span data-stu-id="b4ab5-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="b4ab5-123">ownerId</span><span class="sxs-lookup"><span data-stu-id="b4ab5-123">ownerId</span></span>| <span data-ttu-id="b4ab5-124">string</span><span class="sxs-lookup"><span data-stu-id="b4ab5-124">string</span></span>| <span data-ttu-id="b4ab5-125">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-125">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="b4ab5-126">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-126">Must match the authenticated user.</span></span> <span data-ttu-id="b4ab5-127">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-127">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>|

<a id="ID4EJB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="b4ab5-128">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab5-128">Query string parameters</span></span>

| <span data-ttu-id="b4ab5-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab5-129">Parameter</span></span>| <span data-ttu-id="b4ab5-130">型</span><span class="sxs-lookup"><span data-stu-id="b4ab5-130">Type</span></span>| <span data-ttu-id="b4ab5-131">説明</span><span class="sxs-lookup"><span data-stu-id="b4ab5-131">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="b4ab5-132">表示</span><span class="sxs-lookup"><span data-stu-id="b4ab5-132">view</span></span>| <span data-ttu-id="b4ab5-133">string</span><span class="sxs-lookup"><span data-stu-id="b4ab5-133">string</span></span>| <span data-ttu-id="b4ab5-134">ビューに関連付けられているユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-134">Return the people associated with a view.</span></span> <span data-ttu-id="b4ab5-135">既定値は、"all"です。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-135">The default value is "all".</span></span> <span data-ttu-id="b4ab5-136">設定できる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-136">The possible values are:</span></span> <ul><li><span data-ttu-id="b4ab5-137"><b>すべて</b>のユーザーの People リスト上のすべてのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-137"><b>All</b> - Returns all People on the user's People list.</span></span> <span data-ttu-id="b4ab5-138">これは既定値です。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-138">This is the default value.</span></span></li><li><span data-ttu-id="b4ab5-139"><b>お気に入り</b>お気に入り属性を持っているユーザーの People リスト上のすべてのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-139"><b>Favorite</b> - Returns all People on the user's People list who have the Favorite attribute.</span></span></li><li><span data-ttu-id="b4ab5-140"><b>LegacyXboxLiveFriends</b> - を持っている従来の Xbox LIVE のフレンドでも、ユーザーの People リスト上のすべてのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-140"><b>LegacyXboxLiveFriends</b> - Returns all People on the user's People list who are also legacy Xbox LIVE friends.</span></span></li></br><span data-ttu-id="b4ab5-141">**注:** 呼び出し元のユーザーが所有するユーザーと異なる場合、**すべて**の値のみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-141">**Note:**  Only the **All** value is supported if the calling user is different than the owning user.</span></span>|
| <span data-ttu-id="b4ab5-142">startIndex</span><span class="sxs-lookup"><span data-stu-id="b4ab5-142">startIndex</span></span>| <span data-ttu-id="b4ab5-143">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="b4ab5-143">32-bit unsigned integer</span></span>| <span data-ttu-id="b4ab5-144">特定のインデックスを開始する項目を返します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-144">Return the items starting at the given index.</span></span>  
| <span data-ttu-id="b4ab5-145">maxItems</span><span class="sxs-lookup"><span data-stu-id="b4ab5-145">maxItems</span></span>| <span data-ttu-id="b4ab5-146">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="b4ab5-146">32-bit unsigned integer</span></span>| <span data-ttu-id="b4ab5-147">スタート画面のインデックスから始まるコレクションから返されるユーザーの最大数。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-147">Maximum number of people to return from the collection starting from the start index.</span></span> <span data-ttu-id="b4ab5-148"><b>MaxItems</b>が存在しないと、(結果の最後のページが返されていない) 場合でも同様に返す<b>maxItems</b>よりも少ない可能性がある場合、サービスは既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-148">The service may provide a default value if <b>maxItems</b> is not present and may return fewer than <b>maxItems</b> (even if the last page of results has not yet been returned).</span></span>|

<a id="ID4ERD"></a>


## <a name="authorization"></a><span data-ttu-id="b4ab5-149">Authorization</span><span class="sxs-lookup"><span data-stu-id="b4ab5-149">Authorization</span></span>

| <span data-ttu-id="b4ab5-150">型</span><span class="sxs-lookup"><span data-stu-id="b4ab5-150">Type</span></span>| <span data-ttu-id="b4ab5-151">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="b4ab5-151">Required</span></span>| <span data-ttu-id="b4ab5-152">説明</span><span class="sxs-lookup"><span data-stu-id="b4ab5-152">Description</span></span>| <span data-ttu-id="b4ab5-153">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="b4ab5-153">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="b4ab5-154">XUID</span><span class="sxs-lookup"><span data-stu-id="b4ab5-154">XUID</span></span>| <span data-ttu-id="b4ab5-155">必須</span><span class="sxs-lookup"><span data-stu-id="b4ab5-155">yes</span></span>| <span data-ttu-id="b4ab5-156">呼び出し元では、ユーザーの Xbox ユーザー ID (XUID) があります。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-156">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="b4ab5-157">401 承認されていません。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-157">401 Unauthorized</span></span>|

<a id="ID4EZE"></a>


## <a name="required-request-headers"></a><span data-ttu-id="b4ab5-158">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab5-158">Required Request Headers</span></span>

| <span data-ttu-id="b4ab5-159">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab5-159">Header</span></span>| <span data-ttu-id="b4ab5-160">説明</span><span class="sxs-lookup"><span data-stu-id="b4ab5-160">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="b4ab5-161">Authorization</span><span class="sxs-lookup"><span data-stu-id="b4ab5-161">Authorization</span></span>| <span data-ttu-id="b4ab5-162">[String]。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-162">String.</span></span> <span data-ttu-id="b4ab5-163">Xbox LIVE のデータを承認します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-163">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="b4ab5-164">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-164">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="b4ab5-165">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-165">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>|

<a id="ID4EYF"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="b4ab5-166">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab5-166">Optional Request Headers</span></span>

| <span data-ttu-id="b4ab5-167">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab5-167">Header</span></span>| <span data-ttu-id="b4ab5-168">説明</span><span class="sxs-lookup"><span data-stu-id="b4ab5-168">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="b4ab5-169">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="b4ab5-169">X-RequestedServiceVersion</span></span>| <span data-ttu-id="b4ab5-170">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-170">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="b4ab5-171">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-171">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>|
| <span data-ttu-id="b4ab5-172">Accept</span><span class="sxs-lookup"><span data-stu-id="b4ab5-172">Accept</span></span>| <span data-ttu-id="b4ab5-173">[String]。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-173">String.</span></span> <span data-ttu-id="b4ab5-174">コンテンツ タイプを呼び出し元が応答で受け取る。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-174">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="b4ab5-175">すべての応答は、<b>アプリケーション/json</b>です。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-175">All responses are <b>application/json</b>.</span></span>|

<a id="ID4E5G"></a>


## <a name="request-body"></a><span data-ttu-id="b4ab5-176">要求本文</span><span class="sxs-lookup"><span data-stu-id="b4ab5-176">Request body</span></span>

<span data-ttu-id="b4ab5-177">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-177">No objects are sent in the body of this request.</span></span>

<a id="ID4EJH"></a>


## <a name="http-status-codes"></a><span data-ttu-id="b4ab5-178">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="b4ab5-178">HTTP status codes</span></span>

<span data-ttu-id="b4ab5-179">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-179">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="b4ab5-180">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-180">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="b4ab5-181">コード</span><span class="sxs-lookup"><span data-stu-id="b4ab5-181">Code</span></span>| <span data-ttu-id="b4ab5-182">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="b4ab5-182">Reason phrase</span></span>| <span data-ttu-id="b4ab5-183">説明</span><span class="sxs-lookup"><span data-stu-id="b4ab5-183">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="b4ab5-184">200</span><span class="sxs-lookup"><span data-stu-id="b4ab5-184">200</span></span>| <span data-ttu-id="b4ab5-185">OK</span><span class="sxs-lookup"><span data-stu-id="b4ab5-185">OK</span></span>| <span data-ttu-id="b4ab5-186">成功します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-186">Success.</span></span>|
| <span data-ttu-id="b4ab5-187">400</span><span class="sxs-lookup"><span data-stu-id="b4ab5-187">400</span></span>| <span data-ttu-id="b4ab5-188">Bad Request</span><span class="sxs-lookup"><span data-stu-id="b4ab5-188">Bad Request</span></span>| <span data-ttu-id="b4ab5-189">クエリ パラメーターやユーザー Id は、正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-189">Query parameters or user IDs were malformed.</span></span>|
| <span data-ttu-id="b4ab5-190">403</span><span class="sxs-lookup"><span data-stu-id="b4ab5-190">403</span></span>| <span data-ttu-id="b4ab5-191">Forbidden</span><span class="sxs-lookup"><span data-stu-id="b4ab5-191">Forbidden</span></span>| <span data-ttu-id="b4ab5-192">承認ヘッダーから XUID クレームを解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-192">XUID claim could not be parsed from the authorization header.</span></span>|

<a id="ID4EBBAC"></a>


## <a name="required-response-headers"></a><span data-ttu-id="b4ab5-193">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab5-193">Required Response Headers</span></span>

| <span data-ttu-id="b4ab5-194">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab5-194">Header</span></span>| <span data-ttu-id="b4ab5-195">型</span><span class="sxs-lookup"><span data-stu-id="b4ab5-195">Type</span></span>| <span data-ttu-id="b4ab5-196">説明</span><span class="sxs-lookup"><span data-stu-id="b4ab5-196">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="b4ab5-197">Content-Length</span><span class="sxs-lookup"><span data-stu-id="b4ab5-197">Content-Length</span></span>| <span data-ttu-id="b4ab5-198">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="b4ab5-198">32-bit unsigned integer</span></span>| <span data-ttu-id="b4ab5-199">バイト単位の長さ、応答本文。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-199">Length, in bytes, of the response body.</span></span> <span data-ttu-id="b4ab5-200">値の例: 22 します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-200">Example value: 22.</span></span>|
| <span data-ttu-id="b4ab5-201">Content-Type</span><span class="sxs-lookup"><span data-stu-id="b4ab5-201">Content-Type</span></span>| <span data-ttu-id="b4ab5-202">string</span><span class="sxs-lookup"><span data-stu-id="b4ab5-202">string</span></span>| <span data-ttu-id="b4ab5-203">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-203">MIME type of the response body.</span></span> <span data-ttu-id="b4ab5-204">これにより、<b>アプリケーション/json</b>は常になります。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-204">This will always be <b>application/json</b>.</span></span>|

<a id="ID4ENCAC"></a>


## <a name="response-body"></a><span data-ttu-id="b4ab5-205">応答本文</span><span class="sxs-lookup"><span data-stu-id="b4ab5-205">Response body</span></span>

<span data-ttu-id="b4ab5-206">呼び出しが成功した場合は、サービスは、呼び出し元のユーザーのコレクション、および呼び出し元のユーザーのコレクションが含まれた配列内のユーザーの合計数を返します。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-206">If the call is successful, the service returns the total number of people in the caller's people collection, and an array containing the caller's people collection.</span></span> <span data-ttu-id="b4ab5-207">[PeopleList (JSON)](../../json/json-peoplelist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b4ab5-207">See [PeopleList (JSON)](../../json/json-peoplelist.md).</span></span>

<a id="ID4EZCAC"></a>


### <a name="sample-response"></a><span data-ttu-id="b4ab5-208">応答の例</span><span class="sxs-lookup"><span data-stu-id="b4ab5-208">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="b4ab5-209">関連項目</span><span class="sxs-lookup"><span data-stu-id="b4ab5-209">See also</span></span>

<a id="ID4EFDAC"></a>


##### <a name="parent"></a><span data-ttu-id="b4ab5-210">Parent</span><span class="sxs-lookup"><span data-stu-id="b4ab5-210">Parent</span></span>

[<span data-ttu-id="b4ab5-211">/users/{ownerId}/people</span><span class="sxs-lookup"><span data-stu-id="b4ab5-211">/users/{ownerId}/people</span></span>](uri-usersowneridpeople.md)
