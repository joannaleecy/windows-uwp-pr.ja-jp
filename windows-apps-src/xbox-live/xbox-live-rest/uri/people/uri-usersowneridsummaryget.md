---
title: GET (/users/{ownerId}/summary)
assetID: 754190c9-b15d-f34b-1dca-5c92f6f67d12
permalink: en-us/docs/xboxlive/rest/uri-usersowneridsummaryget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/summary)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 73ba0cd060b3432de1cbb641a8991283974da192
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4312687"
---
# <a name="get-usersowneridsummary"></a><span data-ttu-id="34bc6-104">GET (/users/{ownerId}/summary)</span><span class="sxs-lookup"><span data-stu-id="34bc6-104">GET (/users/{ownerId}/summary)</span></span>
<span data-ttu-id="34bc6-105">呼び出し元の観点から所有者に関する集計データを取得します。</span><span class="sxs-lookup"><span data-stu-id="34bc6-105">Gets summary data about the owner from the caller's perspective.</span></span>

  * [<span data-ttu-id="34bc6-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="34bc6-106">URI parameters</span></span>](#ID4EQ)
  * [<span data-ttu-id="34bc6-107">Authorization</span><span class="sxs-lookup"><span data-stu-id="34bc6-107">Authorization</span></span>](#ID4E2)
  * [<span data-ttu-id="34bc6-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34bc6-108">Required Request Headers</span></span>](#ID4EBC)
  * [<span data-ttu-id="34bc6-109">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34bc6-109">Optional Request Headers</span></span>](#ID4EHD)
  * [<span data-ttu-id="34bc6-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="34bc6-110">Request body</span></span>](#ID4EXE)
  * [<span data-ttu-id="34bc6-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="34bc6-111">HTTP status codes</span></span>](#ID4ECF)
  * [<span data-ttu-id="34bc6-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34bc6-112">Required Response Headers</span></span>](#ID4EZG)
  * [<span data-ttu-id="34bc6-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="34bc6-113">Response body</span></span>](#ID4EGAAC)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="34bc6-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="34bc6-114">URI parameters</span></span>

| <span data-ttu-id="34bc6-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="34bc6-115">Parameter</span></span>| <span data-ttu-id="34bc6-116">型</span><span class="sxs-lookup"><span data-stu-id="34bc6-116">Type</span></span>| <span data-ttu-id="34bc6-117">説明</span><span class="sxs-lookup"><span data-stu-id="34bc6-117">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="34bc6-118">ownerId</span><span class="sxs-lookup"><span data-stu-id="34bc6-118">ownerId</span></span>| <span data-ttu-id="34bc6-119">string</span><span class="sxs-lookup"><span data-stu-id="34bc6-119">string</span></span>| <span data-ttu-id="34bc6-120">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="34bc6-120">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="34bc6-121">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="34bc6-121">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span> <span data-ttu-id="34bc6-122">値の例: <code>me</code>、 <code>xuid(2603643534573581)</code>、</span><span class="sxs-lookup"><span data-stu-id="34bc6-122">Example values: <code>me</code>, <code>xuid(2603643534573581)</code>,</span></span> <code>gt(SomeGamertag)</code>|

<a id="ID4E2"></a>


## <a name="authorization"></a><span data-ttu-id="34bc6-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="34bc6-123">Authorization</span></span>

| <b><span data-ttu-id="34bc6-124">名前</span><span class="sxs-lookup"><span data-stu-id="34bc6-124">Name</span></span></b>| <b><span data-ttu-id="34bc6-125">種類</span><span class="sxs-lookup"><span data-stu-id="34bc6-125">Type</span></span></b>| <b><span data-ttu-id="34bc6-126">説明</span><span class="sxs-lookup"><span data-stu-id="34bc6-126">Description</span></span></b>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="34bc6-127">xuid</span><span class="sxs-lookup"><span data-stu-id="34bc6-127">xuid</span></span>| <span data-ttu-id="34bc6-128">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="34bc6-128">64-bit unsigned integer</span></span>| <span data-ttu-id="34bc6-129">必須。</span><span class="sxs-lookup"><span data-stu-id="34bc6-129">Required.</span></span> <span data-ttu-id="34bc6-130">呼び出し元のユーザー id。</span><span class="sxs-lookup"><span data-stu-id="34bc6-130">user identifier of the caller.</span></span> <span data-ttu-id="34bc6-131">値の例: 2533274790395904</span><span class="sxs-lookup"><span data-stu-id="34bc6-131">Example value: 2533274790395904</span></span>|

<a id="ID4EBC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="34bc6-132">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34bc6-132">Required Request Headers</span></span>

| <span data-ttu-id="34bc6-133">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34bc6-133">Header</span></span>| <span data-ttu-id="34bc6-134">型</span><span class="sxs-lookup"><span data-stu-id="34bc6-134">Type</span></span>| <span data-ttu-id="34bc6-135">説明</span><span class="sxs-lookup"><span data-stu-id="34bc6-135">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="34bc6-136">Authorization</span><span class="sxs-lookup"><span data-stu-id="34bc6-136">Authorization</span></span>| <span data-ttu-id="34bc6-137">string</span><span class="sxs-lookup"><span data-stu-id="34bc6-137">string</span></span>| <span data-ttu-id="34bc6-138">データを承認します。</span><span class="sxs-lookup"><span data-stu-id="34bc6-138">Authorization data for .</span></span> <span data-ttu-id="34bc6-139">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="34bc6-139">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="34bc6-140">値の例: <b>XBL3.0 x = [ハッシュ]、[トークン]</b>します。</span><span class="sxs-lookup"><span data-stu-id="34bc6-140">Example value: <b>XBL3.0 x=[hash];[token]</b>.</span></span>|

<a id="ID4EHD"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="34bc6-141">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34bc6-141">Optional Request Headers</span></span>

| <span data-ttu-id="34bc6-142">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34bc6-142">Header</span></span>| <span data-ttu-id="34bc6-143">型</span><span class="sxs-lookup"><span data-stu-id="34bc6-143">Type</span></span>| <span data-ttu-id="34bc6-144">説明</span><span class="sxs-lookup"><span data-stu-id="34bc6-144">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="34bc6-145">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="34bc6-145">x-xbl-contract-version</span></span>| <span data-ttu-id="34bc6-146">string</span><span class="sxs-lookup"><span data-stu-id="34bc6-146">string</span></span>| <span data-ttu-id="34bc6-147">この要求を送信する必要があります、サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="34bc6-147">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="34bc6-148">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。値の例: 1</span><span class="sxs-lookup"><span data-stu-id="34bc6-148">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Example values: 1</span></span>|
| <span data-ttu-id="34bc6-149">Accept</span><span class="sxs-lookup"><span data-stu-id="34bc6-149">Accept</span></span>| <span data-ttu-id="34bc6-150">string</span><span class="sxs-lookup"><span data-stu-id="34bc6-150">string</span></span>| <span data-ttu-id="34bc6-151">コンテンツの種類の受け入れられるします。</span><span class="sxs-lookup"><span data-stu-id="34bc6-151">Content-Types that are acceptable.</span></span> <span data-ttu-id="34bc6-152">すべての返信はされます<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="34bc6-152">All responses will be <code>application/json</code>.</span></span>|

<a id="ID4EXE"></a>


## <a name="request-body"></a><span data-ttu-id="34bc6-153">要求本文</span><span class="sxs-lookup"><span data-stu-id="34bc6-153">Request body</span></span>

<span data-ttu-id="34bc6-154">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="34bc6-154">No objects are sent in the body of this request.</span></span>

<a id="ID4ECF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="34bc6-155">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="34bc6-155">HTTP status codes</span></span>

<span data-ttu-id="34bc6-156">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="34bc6-156">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="34bc6-157">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="34bc6-157">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="34bc6-158">コード</span><span class="sxs-lookup"><span data-stu-id="34bc6-158">Code</span></span>| <span data-ttu-id="34bc6-159">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="34bc6-159">Reason phrase</span></span>| <span data-ttu-id="34bc6-160">説明</span><span class="sxs-lookup"><span data-stu-id="34bc6-160">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="34bc6-161">200</span><span class="sxs-lookup"><span data-stu-id="34bc6-161">200</span></span>| <span data-ttu-id="34bc6-162">OK</span><span class="sxs-lookup"><span data-stu-id="34bc6-162">OK</span></span>| <span data-ttu-id="34bc6-163">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="34bc6-163">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="34bc6-164">400</span><span class="sxs-lookup"><span data-stu-id="34bc6-164">400</span></span>| <span data-ttu-id="34bc6-165">Bad Request</span><span class="sxs-lookup"><span data-stu-id="34bc6-165">Bad Request</span></span>| <span data-ttu-id="34bc6-166">ユーザー Id が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="34bc6-166">User IDs were malformed.</span></span>|
| <span data-ttu-id="34bc6-167">403</span><span class="sxs-lookup"><span data-stu-id="34bc6-167">403</span></span>| <span data-ttu-id="34bc6-168">Forbidden</span><span class="sxs-lookup"><span data-stu-id="34bc6-168">Forbidden</span></span>| <span data-ttu-id="34bc6-169">承認ヘッダーから XUID クレームを解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="34bc6-169">XUID claim could not be parsed from the authorization header.</span></span>|

<a id="ID4EZG"></a>


## <a name="required-response-headers"></a><span data-ttu-id="34bc6-170">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34bc6-170">Required Response Headers</span></span>

| <span data-ttu-id="34bc6-171">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="34bc6-171">Header</span></span>| <span data-ttu-id="34bc6-172">型</span><span class="sxs-lookup"><span data-stu-id="34bc6-172">Type</span></span>| <span data-ttu-id="34bc6-173">説明</span><span class="sxs-lookup"><span data-stu-id="34bc6-173">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="34bc6-174">Content-Length</span><span class="sxs-lookup"><span data-stu-id="34bc6-174">Content-Length</span></span>| <span data-ttu-id="34bc6-175">string</span><span class="sxs-lookup"><span data-stu-id="34bc6-175">string</span></span>| <span data-ttu-id="34bc6-176">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="34bc6-176">The number of bytes being sent in the response.</span></span> <span data-ttu-id="34bc6-177">値の例: 232 します。</span><span class="sxs-lookup"><span data-stu-id="34bc6-177">Example value: 232.</span></span>|
| <span data-ttu-id="34bc6-178">Content-Type</span><span class="sxs-lookup"><span data-stu-id="34bc6-178">Content-Type</span></span>| <span data-ttu-id="34bc6-179">string</span><span class="sxs-lookup"><span data-stu-id="34bc6-179">string</span></span>| <span data-ttu-id="34bc6-180">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="34bc6-180">MIME type of the response body.</span></span> <span data-ttu-id="34bc6-181">これは、<b>アプリケーション/json</b>でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="34bc6-181">This must be <b>application/json</b>.</span></span>|

<a id="ID4EGAAC"></a>


## <a name="response-body"></a><span data-ttu-id="34bc6-182">応答本文</span><span class="sxs-lookup"><span data-stu-id="34bc6-182">Response body</span></span>

<span data-ttu-id="34bc6-183">[PersonSummary (JSON)](../../json/json-personsummary.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="34bc6-183">See [PersonSummary (JSON)](../../json/json-personsummary.md).</span></span>

<a id="ID4ESAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="34bc6-184">応答の例</span><span class="sxs-lookup"><span data-stu-id="34bc6-184">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="34bc6-185">関連項目</span><span class="sxs-lookup"><span data-stu-id="34bc6-185">See also</span></span>

<a id="ID4E5AAC"></a>


##### <a name="parent"></a><span data-ttu-id="34bc6-186">Parent</span><span class="sxs-lookup"><span data-stu-id="34bc6-186">Parent</span></span>

[<span data-ttu-id="34bc6-187">/users/{ownerId}/summary</span><span class="sxs-lookup"><span data-stu-id="34bc6-187">/users/{ownerId}/summary</span></span>](uri-usersowneridsummary.md)
