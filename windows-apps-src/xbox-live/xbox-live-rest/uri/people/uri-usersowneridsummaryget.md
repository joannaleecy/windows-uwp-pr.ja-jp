---
title: GET (/users/{ownerId}/summary)
assetID: 754190c9-b15d-f34b-1dca-5c92f6f67d12
permalink: en-us/docs/xboxlive/rest/uri-usersowneridsummaryget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/summary)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 60938acedd58934ec8b758d435776f227e82b91d
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7567337"
---
# <a name="get-usersowneridsummary"></a><span data-ttu-id="42ee5-104">GET (/users/{ownerId}/summary)</span><span class="sxs-lookup"><span data-stu-id="42ee5-104">GET (/users/{ownerId}/summary)</span></span>
<span data-ttu-id="42ee5-105">呼び出し元の観点から、所有者に関する集計データを取得します。</span><span class="sxs-lookup"><span data-stu-id="42ee5-105">Gets summary data about the owner from the caller's perspective.</span></span>

  * [<span data-ttu-id="42ee5-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="42ee5-106">URI parameters</span></span>](#ID4EQ)
  * [<span data-ttu-id="42ee5-107">Authorization</span><span class="sxs-lookup"><span data-stu-id="42ee5-107">Authorization</span></span>](#ID4E2)
  * [<span data-ttu-id="42ee5-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42ee5-108">Required Request Headers</span></span>](#ID4EBC)
  * [<span data-ttu-id="42ee5-109">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42ee5-109">Optional Request Headers</span></span>](#ID4EHD)
  * [<span data-ttu-id="42ee5-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="42ee5-110">Request body</span></span>](#ID4EXE)
  * [<span data-ttu-id="42ee5-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="42ee5-111">HTTP status codes</span></span>](#ID4ECF)
  * [<span data-ttu-id="42ee5-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42ee5-112">Required Response Headers</span></span>](#ID4EZG)
  * [<span data-ttu-id="42ee5-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="42ee5-113">Response body</span></span>](#ID4EGAAC)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="42ee5-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="42ee5-114">URI parameters</span></span>

| <span data-ttu-id="42ee5-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="42ee5-115">Parameter</span></span>| <span data-ttu-id="42ee5-116">型</span><span class="sxs-lookup"><span data-stu-id="42ee5-116">Type</span></span>| <span data-ttu-id="42ee5-117">説明</span><span class="sxs-lookup"><span data-stu-id="42ee5-117">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="42ee5-118">ownerId</span><span class="sxs-lookup"><span data-stu-id="42ee5-118">ownerId</span></span>| <span data-ttu-id="42ee5-119">string</span><span class="sxs-lookup"><span data-stu-id="42ee5-119">string</span></span>| <span data-ttu-id="42ee5-120">そのリソースにアクセスしているユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="42ee5-120">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="42ee5-121">可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="42ee5-121">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span> <span data-ttu-id="42ee5-122">値の例: <code>me</code>、 <code>xuid(2603643534573581)</code>、</span><span class="sxs-lookup"><span data-stu-id="42ee5-122">Example values: <code>me</code>, <code>xuid(2603643534573581)</code>,</span></span> <code>gt(SomeGamertag)</code>|

<a id="ID4E2"></a>


## <a name="authorization"></a><span data-ttu-id="42ee5-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="42ee5-123">Authorization</span></span>

| <b><span data-ttu-id="42ee5-124">名前</span><span class="sxs-lookup"><span data-stu-id="42ee5-124">Name</span></span></b>| <b><span data-ttu-id="42ee5-125">種類</span><span class="sxs-lookup"><span data-stu-id="42ee5-125">Type</span></span></b>| <b><span data-ttu-id="42ee5-126">説明</span><span class="sxs-lookup"><span data-stu-id="42ee5-126">Description</span></span></b>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42ee5-127">xuid</span><span class="sxs-lookup"><span data-stu-id="42ee5-127">xuid</span></span>| <span data-ttu-id="42ee5-128">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="42ee5-128">64-bit unsigned integer</span></span>| <span data-ttu-id="42ee5-129">必須。</span><span class="sxs-lookup"><span data-stu-id="42ee5-129">Required.</span></span> <span data-ttu-id="42ee5-130">呼び出し元のユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="42ee5-130">user identifier of the caller.</span></span> <span data-ttu-id="42ee5-131">値の例: 2533274790395904</span><span class="sxs-lookup"><span data-stu-id="42ee5-131">Example value: 2533274790395904</span></span>|

<a id="ID4EBC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="42ee5-132">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42ee5-132">Required Request Headers</span></span>

| <span data-ttu-id="42ee5-133">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42ee5-133">Header</span></span>| <span data-ttu-id="42ee5-134">型</span><span class="sxs-lookup"><span data-stu-id="42ee5-134">Type</span></span>| <span data-ttu-id="42ee5-135">説明</span><span class="sxs-lookup"><span data-stu-id="42ee5-135">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42ee5-136">Authorization</span><span class="sxs-lookup"><span data-stu-id="42ee5-136">Authorization</span></span>| <span data-ttu-id="42ee5-137">string</span><span class="sxs-lookup"><span data-stu-id="42ee5-137">string</span></span>| <span data-ttu-id="42ee5-138">データを承認します。</span><span class="sxs-lookup"><span data-stu-id="42ee5-138">Authorization data for .</span></span> <span data-ttu-id="42ee5-139">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="42ee5-139">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="42ee5-140">値の例: <b>XBL3.0 x = [ハッシュ]、[トークン]</b>します。</span><span class="sxs-lookup"><span data-stu-id="42ee5-140">Example value: <b>XBL3.0 x=[hash];[token]</b>.</span></span>|

<a id="ID4EHD"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="42ee5-141">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42ee5-141">Optional Request Headers</span></span>

| <span data-ttu-id="42ee5-142">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42ee5-142">Header</span></span>| <span data-ttu-id="42ee5-143">型</span><span class="sxs-lookup"><span data-stu-id="42ee5-143">Type</span></span>| <span data-ttu-id="42ee5-144">説明</span><span class="sxs-lookup"><span data-stu-id="42ee5-144">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42ee5-145">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="42ee5-145">x-xbl-contract-version</span></span>| <span data-ttu-id="42ee5-146">string</span><span class="sxs-lookup"><span data-stu-id="42ee5-146">string</span></span>| <span data-ttu-id="42ee5-147">この要求を送信する必要があります、サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="42ee5-147">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="42ee5-148">要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。値の例: 1</span><span class="sxs-lookup"><span data-stu-id="42ee5-148">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Example values: 1</span></span>|
| <span data-ttu-id="42ee5-149">Accept</span><span class="sxs-lookup"><span data-stu-id="42ee5-149">Accept</span></span>| <span data-ttu-id="42ee5-150">string</span><span class="sxs-lookup"><span data-stu-id="42ee5-150">string</span></span>| <span data-ttu-id="42ee5-151">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="42ee5-151">Content-Types that are acceptable.</span></span> <span data-ttu-id="42ee5-152">すべての返信はされます<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="42ee5-152">All responses will be <code>application/json</code>.</span></span>|

<a id="ID4EXE"></a>


## <a name="request-body"></a><span data-ttu-id="42ee5-153">要求本文</span><span class="sxs-lookup"><span data-stu-id="42ee5-153">Request body</span></span>

<span data-ttu-id="42ee5-154">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="42ee5-154">No objects are sent in the body of this request.</span></span>

<a id="ID4ECF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="42ee5-155">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="42ee5-155">HTTP status codes</span></span>

<span data-ttu-id="42ee5-156">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="42ee5-156">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="42ee5-157">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="42ee5-157">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="42ee5-158">コード</span><span class="sxs-lookup"><span data-stu-id="42ee5-158">Code</span></span>| <span data-ttu-id="42ee5-159">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="42ee5-159">Reason phrase</span></span>| <span data-ttu-id="42ee5-160">説明</span><span class="sxs-lookup"><span data-stu-id="42ee5-160">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42ee5-161">200</span><span class="sxs-lookup"><span data-stu-id="42ee5-161">200</span></span>| <span data-ttu-id="42ee5-162">OK</span><span class="sxs-lookup"><span data-stu-id="42ee5-162">OK</span></span>| <span data-ttu-id="42ee5-163">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="42ee5-163">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="42ee5-164">400</span><span class="sxs-lookup"><span data-stu-id="42ee5-164">400</span></span>| <span data-ttu-id="42ee5-165">Bad Request</span><span class="sxs-lookup"><span data-stu-id="42ee5-165">Bad Request</span></span>| <span data-ttu-id="42ee5-166">ユーザー Id が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="42ee5-166">User IDs were malformed.</span></span>|
| <span data-ttu-id="42ee5-167">403</span><span class="sxs-lookup"><span data-stu-id="42ee5-167">403</span></span>| <span data-ttu-id="42ee5-168">Forbidden</span><span class="sxs-lookup"><span data-stu-id="42ee5-168">Forbidden</span></span>| <span data-ttu-id="42ee5-169">承認ヘッダーから XUID クレームを解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="42ee5-169">XUID claim could not be parsed from the authorization header.</span></span>|

<a id="ID4EZG"></a>


## <a name="required-response-headers"></a><span data-ttu-id="42ee5-170">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42ee5-170">Required Response Headers</span></span>

| <span data-ttu-id="42ee5-171">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="42ee5-171">Header</span></span>| <span data-ttu-id="42ee5-172">型</span><span class="sxs-lookup"><span data-stu-id="42ee5-172">Type</span></span>| <span data-ttu-id="42ee5-173">説明</span><span class="sxs-lookup"><span data-stu-id="42ee5-173">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="42ee5-174">Content-Length</span><span class="sxs-lookup"><span data-stu-id="42ee5-174">Content-Length</span></span>| <span data-ttu-id="42ee5-175">string</span><span class="sxs-lookup"><span data-stu-id="42ee5-175">string</span></span>| <span data-ttu-id="42ee5-176">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="42ee5-176">The number of bytes being sent in the response.</span></span> <span data-ttu-id="42ee5-177">値の例: 232 します。</span><span class="sxs-lookup"><span data-stu-id="42ee5-177">Example value: 232.</span></span>|
| <span data-ttu-id="42ee5-178">Content-Type</span><span class="sxs-lookup"><span data-stu-id="42ee5-178">Content-Type</span></span>| <span data-ttu-id="42ee5-179">string</span><span class="sxs-lookup"><span data-stu-id="42ee5-179">string</span></span>| <span data-ttu-id="42ee5-180">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="42ee5-180">MIME type of the response body.</span></span> <span data-ttu-id="42ee5-181">これは、<b>アプリケーション/json</b>でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="42ee5-181">This must be <b>application/json</b>.</span></span>|

<a id="ID4EGAAC"></a>


## <a name="response-body"></a><span data-ttu-id="42ee5-182">応答本文</span><span class="sxs-lookup"><span data-stu-id="42ee5-182">Response body</span></span>

<span data-ttu-id="42ee5-183">[PersonSummary (JSON)](../../json/json-personsummary.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="42ee5-183">See [PersonSummary (JSON)](../../json/json-personsummary.md).</span></span>

<a id="ID4ESAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="42ee5-184">応答の例</span><span class="sxs-lookup"><span data-stu-id="42ee5-184">Sample response</span></span>


```cpp
{
    "targetFollowingCount": 87,
    "targetFollowerCount": 19,
    "isCallerFollowingTarget": true,
    "isTargetFollowingCaller": false,
    "hasCallerMarkedTargetAsFavorite": true,
    "hasCallerMarkedTargetAsKnown": true,
    "legacyFriendStatus": "None",
    "recentChangeCount": 5,
    "watermark": "5246775845000319351"
}

```


<a id="ID4E3AAC"></a>


## <a name="see-also"></a><span data-ttu-id="42ee5-185">関連項目</span><span class="sxs-lookup"><span data-stu-id="42ee5-185">See also</span></span>

<a id="ID4E5AAC"></a>


##### <a name="parent"></a><span data-ttu-id="42ee5-186">Parent</span><span class="sxs-lookup"><span data-stu-id="42ee5-186">Parent</span></span>

[<span data-ttu-id="42ee5-187">/users/{ownerId}/summary</span><span class="sxs-lookup"><span data-stu-id="42ee5-187">/users/{ownerId}/summary</span></span>](uri-usersowneridsummary.md)
