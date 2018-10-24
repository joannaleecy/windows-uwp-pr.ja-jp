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
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483515"
---
# <a name="get-usersowneridpeople"></a><span data-ttu-id="a458f-104">GET (/users/{ownerId}/people)</span><span class="sxs-lookup"><span data-stu-id="a458f-104">GET (/users/{ownerId}/people)</span></span>
<span data-ttu-id="a458f-105">呼び出し元のユーザーのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="a458f-105">Gets caller's people collection.</span></span>
<span data-ttu-id="a458f-106">これらの Uri のドメインは、 `social.xboxlive.com`。</span><span class="sxs-lookup"><span data-stu-id="a458f-106">The domain for these URIs is `social.xboxlive.com`.</span></span>

  * [<span data-ttu-id="a458f-107">注釈</span><span class="sxs-lookup"><span data-stu-id="a458f-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="a458f-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a458f-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="a458f-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a458f-109">Query string parameters</span></span>](#ID4EJB)
  * [<span data-ttu-id="a458f-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="a458f-110">Authorization</span></span>](#ID4ERD)
  * [<span data-ttu-id="a458f-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a458f-111">Required Request Headers</span></span>](#ID4EZE)
  * [<span data-ttu-id="a458f-112">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a458f-112">Optional Request Headers</span></span>](#ID4EYF)
  * [<span data-ttu-id="a458f-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="a458f-113">Request body</span></span>](#ID4E5G)
  * [<span data-ttu-id="a458f-114">HTTP ステータス ・ コード</span><span class="sxs-lookup"><span data-stu-id="a458f-114">HTTP status codes</span></span>](#ID4EJH)
  * [<span data-ttu-id="a458f-115">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a458f-115">Required Response Headers</span></span>](#ID4EBBAC)
  * [<span data-ttu-id="a458f-116">応答本文</span><span class="sxs-lookup"><span data-stu-id="a458f-116">Response body</span></span>](#ID4ENCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="a458f-117">注釈</span><span class="sxs-lookup"><span data-stu-id="a458f-117">Remarks</span></span>

<span data-ttu-id="a458f-118">GET 操作は、1 回または複数回実行された場合は、同じ結果を生成これは、すべてのリソースを変更しません。</span><span class="sxs-lookup"><span data-stu-id="a458f-118">GET operations won't modify any resources so this will produce the same results if executed once or multiple times.</span></span>

<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="a458f-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a458f-119">URI parameters</span></span>

| <span data-ttu-id="a458f-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a458f-120">Parameter</span></span>| <span data-ttu-id="a458f-121">型</span><span class="sxs-lookup"><span data-stu-id="a458f-121">Type</span></span>| <span data-ttu-id="a458f-122">説明</span><span class="sxs-lookup"><span data-stu-id="a458f-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="a458f-123">ownerId</span><span class="sxs-lookup"><span data-stu-id="a458f-123">ownerId</span></span>| <span data-ttu-id="a458f-124">string</span><span class="sxs-lookup"><span data-stu-id="a458f-124">string</span></span>| <span data-ttu-id="a458f-125">リソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="a458f-125">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="a458f-126">認証済みのユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a458f-126">Must match the authenticated user.</span></span> <span data-ttu-id="a458f-127">使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="a458f-127">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>|

<a id="ID4EJB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="a458f-128">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a458f-128">Query string parameters</span></span>

| <span data-ttu-id="a458f-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a458f-129">Parameter</span></span>| <span data-ttu-id="a458f-130">型</span><span class="sxs-lookup"><span data-stu-id="a458f-130">Type</span></span>| <span data-ttu-id="a458f-131">説明</span><span class="sxs-lookup"><span data-stu-id="a458f-131">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a458f-132">表示</span><span class="sxs-lookup"><span data-stu-id="a458f-132">view</span></span>| <span data-ttu-id="a458f-133">string</span><span class="sxs-lookup"><span data-stu-id="a458f-133">string</span></span>| <span data-ttu-id="a458f-134">ビューに関連付けられているユーザーが返されます。</span><span class="sxs-lookup"><span data-stu-id="a458f-134">Return the people associated with a view.</span></span> <span data-ttu-id="a458f-135">既定値は、[すべて] です。</span><span class="sxs-lookup"><span data-stu-id="a458f-135">The default value is "all".</span></span> <span data-ttu-id="a458f-136">設定できる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a458f-136">The possible values are:</span></span> <ul><li><span data-ttu-id="a458f-137"><b>すべて</b>のユーザーのユーザー] の一覧で、すべてのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="a458f-137"><b>All</b> - Returns all People on the user's People list.</span></span> <span data-ttu-id="a458f-138">これは既定値です。</span><span class="sxs-lookup"><span data-stu-id="a458f-138">This is the default value.</span></span></li><li><span data-ttu-id="a458f-139"><b>お気に入り</b>のお気に入りの属性を持っているユーザーのユーザー] ボックスの一覧で、すべてのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="a458f-139"><b>Favorite</b> - Returns all People on the user's People list who have the Favorite attribute.</span></span></li><li><span data-ttu-id="a458f-140"><b>LegacyXboxLiveFriends</b> - は、従来の Xbox LIVE のフレンドでもあるユーザーのユーザー] ボックスの一覧のすべてのユーザーを返します。</span><span class="sxs-lookup"><span data-stu-id="a458f-140"><b>LegacyXboxLiveFriends</b> - Returns all People on the user's People list who are also legacy Xbox LIVE friends.</span></span></li></br><span data-ttu-id="a458f-141">**注:** 呼び出し元のユーザーが所有しているユーザーとは異なる場合、**すべて**の値のみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="a458f-141">**Note:**  Only the **All** value is supported if the calling user is different than the owning user.</span></span>|
| <span data-ttu-id="a458f-142">startIndex</span><span class="sxs-lookup"><span data-stu-id="a458f-142">startIndex</span></span>| <span data-ttu-id="a458f-143">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="a458f-143">32-bit unsigned integer</span></span>| <span data-ttu-id="a458f-144">項目の指定したインデックスを開始位置を返します。</span><span class="sxs-lookup"><span data-stu-id="a458f-144">Return the items starting at the given index.</span></span>  
| <span data-ttu-id="a458f-145">maxItems</span><span class="sxs-lookup"><span data-stu-id="a458f-145">maxItems</span></span>| <span data-ttu-id="a458f-146">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="a458f-146">32-bit unsigned integer</span></span>| <span data-ttu-id="a458f-147">開始インデックス位置からコレクションから取得するユーザーの最大数。</span><span class="sxs-lookup"><span data-stu-id="a458f-147">Maximum number of people to return from the collection starting from the start index.</span></span> <span data-ttu-id="a458f-148">場合<b>maxItems</b>が存在しない場合があります<b>maxItems</b>よりも少ない (結果の最後のページが返されていない) 場合でも、サービスは既定値を指定ことがあります。</span><span class="sxs-lookup"><span data-stu-id="a458f-148">The service may provide a default value if <b>maxItems</b> is not present and may return fewer than <b>maxItems</b> (even if the last page of results has not yet been returned).</span></span>|

<a id="ID4ERD"></a>


## <a name="authorization"></a><span data-ttu-id="a458f-149">Authorization</span><span class="sxs-lookup"><span data-stu-id="a458f-149">Authorization</span></span>

| <span data-ttu-id="a458f-150">型</span><span class="sxs-lookup"><span data-stu-id="a458f-150">Type</span></span>| <span data-ttu-id="a458f-151">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="a458f-151">Required</span></span>| <span data-ttu-id="a458f-152">説明</span><span class="sxs-lookup"><span data-stu-id="a458f-152">Description</span></span>| <span data-ttu-id="a458f-153">応答がない場合は、</span><span class="sxs-lookup"><span data-stu-id="a458f-153">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a458f-154">XUID</span><span class="sxs-lookup"><span data-stu-id="a458f-154">XUID</span></span>| <span data-ttu-id="a458f-155">必須</span><span class="sxs-lookup"><span data-stu-id="a458f-155">yes</span></span>| <span data-ttu-id="a458f-156">呼び出し元には、ユーザーの Xbox ユーザー ID (XUID) があります。</span><span class="sxs-lookup"><span data-stu-id="a458f-156">Caller has user's Xbox User ID (XUID).</span></span>| <span data-ttu-id="a458f-157">401 権限がありません。</span><span class="sxs-lookup"><span data-stu-id="a458f-157">401 Unauthorized</span></span>|

<a id="ID4EZE"></a>


## <a name="required-request-headers"></a><span data-ttu-id="a458f-158">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a458f-158">Required Request Headers</span></span>

| <span data-ttu-id="a458f-159">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a458f-159">Header</span></span>| <span data-ttu-id="a458f-160">説明</span><span class="sxs-lookup"><span data-stu-id="a458f-160">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a458f-161">Authorization</span><span class="sxs-lookup"><span data-stu-id="a458f-161">Authorization</span></span>| <span data-ttu-id="a458f-162">[String]。</span><span class="sxs-lookup"><span data-stu-id="a458f-162">String.</span></span> <span data-ttu-id="a458f-163">Xbox LIVE 用のデータを承認します。</span><span class="sxs-lookup"><span data-stu-id="a458f-163">Authorization data for Xbox LIVE.</span></span> <span data-ttu-id="a458f-164">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="a458f-164">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="a458f-165">値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>。</span><span class="sxs-lookup"><span data-stu-id="a458f-165">Example value: <b>XBL3.0 x=&lt;userhash>;&lt;token></b>.</span></span>|

<a id="ID4EYF"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="a458f-166">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a458f-166">Optional Request Headers</span></span>

| <span data-ttu-id="a458f-167">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a458f-167">Header</span></span>| <span data-ttu-id="a458f-168">説明</span><span class="sxs-lookup"><span data-stu-id="a458f-168">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a458f-169">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="a458f-169">X-RequestedServiceVersion</span></span>| <span data-ttu-id="a458f-170">Xbox LIVE サービスは、この要求を送信するのには、名または番号を作成します。</span><span class="sxs-lookup"><span data-stu-id="a458f-170">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="a458f-171">要求は、ヘッダー、認証トークンなどの要求の妥当性を確認した後、そのサービスにのみルーティングされます。既定値: 1。</span><span class="sxs-lookup"><span data-stu-id="a458f-171">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>|
| <span data-ttu-id="a458f-172">Accept</span><span class="sxs-lookup"><span data-stu-id="a458f-172">Accept</span></span>| <span data-ttu-id="a458f-173">[String]。</span><span class="sxs-lookup"><span data-stu-id="a458f-173">String.</span></span> <span data-ttu-id="a458f-174">コンテンツ タイプの応答で呼び出し元を受け入れる。</span><span class="sxs-lookup"><span data-stu-id="a458f-174">Content-Types that the caller accepts in the response.</span></span> <span data-ttu-id="a458f-175">すべての応答は、<b>アプリケーションまたは json</b>です。</span><span class="sxs-lookup"><span data-stu-id="a458f-175">All responses are <b>application/json</b>.</span></span>|

<a id="ID4E5G"></a>


## <a name="request-body"></a><span data-ttu-id="a458f-176">要求本文</span><span class="sxs-lookup"><span data-stu-id="a458f-176">Request body</span></span>

<span data-ttu-id="a458f-177">オブジェクトはこの要求の本文に送信されません。</span><span class="sxs-lookup"><span data-stu-id="a458f-177">No objects are sent in the body of this request.</span></span>

<a id="ID4EJH"></a>


## <a name="http-status-codes"></a><span data-ttu-id="a458f-178">HTTP ステータス ・ コード</span><span class="sxs-lookup"><span data-stu-id="a458f-178">HTTP status codes</span></span>

<span data-ttu-id="a458f-179">サービスは、このリソースにこのメソッドを使用して行われた要求への応答では、このセクションのステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="a458f-179">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="a458f-180">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧については、[標準的な HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a458f-180">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="a458f-181">コード</span><span class="sxs-lookup"><span data-stu-id="a458f-181">Code</span></span>| <span data-ttu-id="a458f-182">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="a458f-182">Reason phrase</span></span>| <span data-ttu-id="a458f-183">説明</span><span class="sxs-lookup"><span data-stu-id="a458f-183">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a458f-184">200</span><span class="sxs-lookup"><span data-stu-id="a458f-184">200</span></span>| <span data-ttu-id="a458f-185">OK</span><span class="sxs-lookup"><span data-stu-id="a458f-185">OK</span></span>| <span data-ttu-id="a458f-186">成功します。</span><span class="sxs-lookup"><span data-stu-id="a458f-186">Success.</span></span>|
| <span data-ttu-id="a458f-187">400</span><span class="sxs-lookup"><span data-stu-id="a458f-187">400</span></span>| <span data-ttu-id="a458f-188">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="a458f-188">Bad Request</span></span>| <span data-ttu-id="a458f-189">クエリ パラメーターやユーザ Id は、形式が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="a458f-189">Query parameters or user IDs were malformed.</span></span>|
| <span data-ttu-id="a458f-190">403</span><span class="sxs-lookup"><span data-stu-id="a458f-190">403</span></span>| <span data-ttu-id="a458f-191">Forbidden</span><span class="sxs-lookup"><span data-stu-id="a458f-191">Forbidden</span></span>| <span data-ttu-id="a458f-192">承認ヘッダーの XUID の要求を解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="a458f-192">XUID claim could not be parsed from the authorization header.</span></span>|

<a id="ID4EBBAC"></a>


## <a name="required-response-headers"></a><span data-ttu-id="a458f-193">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a458f-193">Required Response Headers</span></span>

| <span data-ttu-id="a458f-194">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a458f-194">Header</span></span>| <span data-ttu-id="a458f-195">型</span><span class="sxs-lookup"><span data-stu-id="a458f-195">Type</span></span>| <span data-ttu-id="a458f-196">説明</span><span class="sxs-lookup"><span data-stu-id="a458f-196">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a458f-197">Content-Length</span><span class="sxs-lookup"><span data-stu-id="a458f-197">Content-Length</span></span>| <span data-ttu-id="a458f-198">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="a458f-198">32-bit unsigned integer</span></span>| <span data-ttu-id="a458f-199">長さをバイト単位で、応答の本体です。</span><span class="sxs-lookup"><span data-stu-id="a458f-199">Length, in bytes, of the response body.</span></span> <span data-ttu-id="a458f-200">値の例: 22 です。</span><span class="sxs-lookup"><span data-stu-id="a458f-200">Example value: 22.</span></span>|
| <span data-ttu-id="a458f-201">Content-Type</span><span class="sxs-lookup"><span data-stu-id="a458f-201">Content-Type</span></span>| <span data-ttu-id="a458f-202">string</span><span class="sxs-lookup"><span data-stu-id="a458f-202">string</span></span>| <span data-ttu-id="a458f-203">応答本体の MIME の種類です。</span><span class="sxs-lookup"><span data-stu-id="a458f-203">MIME type of the response body.</span></span> <span data-ttu-id="a458f-204">常に<b>アプリケーションまたは json</b>になります。</span><span class="sxs-lookup"><span data-stu-id="a458f-204">This will always be <b>application/json</b>.</span></span>|

<a id="ID4ENCAC"></a>


## <a name="response-body"></a><span data-ttu-id="a458f-205">応答本文</span><span class="sxs-lookup"><span data-stu-id="a458f-205">Response body</span></span>

<span data-ttu-id="a458f-206">呼び出しが成功した場合、サービスは、呼び出し元のユーザーのコレクション、および呼び出し元のユーザーのコレクションを格納した配列でユーザーの合計数を返します。</span><span class="sxs-lookup"><span data-stu-id="a458f-206">If the call is successful, the service returns the total number of people in the caller's people collection, and an array containing the caller's people collection.</span></span> <span data-ttu-id="a458f-207">[PeopleList (JSON)](../../json/json-peoplelist.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a458f-207">See [PeopleList (JSON)](../../json/json-peoplelist.md).</span></span>

<a id="ID4EZCAC"></a>


### <a name="sample-response"></a><span data-ttu-id="a458f-208">応答の例</span><span class="sxs-lookup"><span data-stu-id="a458f-208">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="a458f-209">関連項目</span><span class="sxs-lookup"><span data-stu-id="a458f-209">See also</span></span>

<a id="ID4EFDAC"></a>


##### <a name="parent"></a><span data-ttu-id="a458f-210">Parent</span><span class="sxs-lookup"><span data-stu-id="a458f-210">Parent</span></span>

[<span data-ttu-id="a458f-211">/users/{ownerId}/people</span><span class="sxs-lookup"><span data-stu-id="a458f-211">/users/{ownerId}/people</span></span>](uri-usersowneridpeople.md)
