---
title: 取得する (/users/{ownerId}/概要)
assetID: 754190c9-b15d-f34b-1dca-5c92f6f67d12
permalink: en-us/docs/xboxlive/rest/uri-usersowneridsummaryget.html
author: KevinAsgari
description: " 取得する (/users/{ownerId}/概要)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 73ba0cd060b3432de1cbb641a8991283974da192
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881834"
---
# <a name="get-usersowneridsummary"></a><span data-ttu-id="ddf29-104">取得する (/users/{ownerId}/概要)</span><span class="sxs-lookup"><span data-stu-id="ddf29-104">GET (/users/{ownerId}/summary)</span></span>
<span data-ttu-id="ddf29-105">呼び出し元の観点から、所有者に関する集計データを取得します。</span><span class="sxs-lookup"><span data-stu-id="ddf29-105">Gets summary data about the owner from the caller's perspective.</span></span>

  * [<span data-ttu-id="ddf29-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ddf29-106">URI parameters</span></span>](#ID4EQ)
  * [<span data-ttu-id="ddf29-107">Authorization</span><span class="sxs-lookup"><span data-stu-id="ddf29-107">Authorization</span></span>](#ID4E2)
  * [<span data-ttu-id="ddf29-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ddf29-108">Required Request Headers</span></span>](#ID4EBC)
  * [<span data-ttu-id="ddf29-109">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ddf29-109">Optional Request Headers</span></span>](#ID4EHD)
  * [<span data-ttu-id="ddf29-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="ddf29-110">Request body</span></span>](#ID4EXE)
  * [<span data-ttu-id="ddf29-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ddf29-111">HTTP status codes</span></span>](#ID4ECF)
  * [<span data-ttu-id="ddf29-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ddf29-112">Required Response Headers</span></span>](#ID4EZG)
  * [<span data-ttu-id="ddf29-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="ddf29-113">Response body</span></span>](#ID4EGAAC)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="ddf29-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ddf29-114">URI parameters</span></span>

| <span data-ttu-id="ddf29-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ddf29-115">Parameter</span></span>| <span data-ttu-id="ddf29-116">型</span><span class="sxs-lookup"><span data-stu-id="ddf29-116">Type</span></span>| <span data-ttu-id="ddf29-117">説明</span><span class="sxs-lookup"><span data-stu-id="ddf29-117">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="ddf29-118">ownerId</span><span class="sxs-lookup"><span data-stu-id="ddf29-118">ownerId</span></span>| <span data-ttu-id="ddf29-119">string</span><span class="sxs-lookup"><span data-stu-id="ddf29-119">string</span></span>| <span data-ttu-id="ddf29-120">そのリソースにアクセスしているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="ddf29-120">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="ddf29-121">設定可能な値とは、"me"、だけ、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="ddf29-121">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span> <span data-ttu-id="ddf29-122">値の例: <code>me</code>、 <code>xuid(2603643534573581)</code>、</span><span class="sxs-lookup"><span data-stu-id="ddf29-122">Example values: <code>me</code>, <code>xuid(2603643534573581)</code>,</span></span> <code>gt(SomeGamertag)</code>|

<a id="ID4E2"></a>


## <a name="authorization"></a><span data-ttu-id="ddf29-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="ddf29-123">Authorization</span></span>

| <b><span data-ttu-id="ddf29-124">名前</span><span class="sxs-lookup"><span data-stu-id="ddf29-124">Name</span></span></b>| <b><span data-ttu-id="ddf29-125">種類</span><span class="sxs-lookup"><span data-stu-id="ddf29-125">Type</span></span></b>| <b><span data-ttu-id="ddf29-126">説明</span><span class="sxs-lookup"><span data-stu-id="ddf29-126">Description</span></span></b>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ddf29-127">xuid</span><span class="sxs-lookup"><span data-stu-id="ddf29-127">xuid</span></span>| <span data-ttu-id="ddf29-128">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ddf29-128">64-bit unsigned integer</span></span>| <span data-ttu-id="ddf29-129">必須。</span><span class="sxs-lookup"><span data-stu-id="ddf29-129">Required.</span></span> <span data-ttu-id="ddf29-130">呼び出し元のユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="ddf29-130">user identifier of the caller.</span></span> <span data-ttu-id="ddf29-131">値の例: 2533274790395904</span><span class="sxs-lookup"><span data-stu-id="ddf29-131">Example value: 2533274790395904</span></span>|

<a id="ID4EBC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="ddf29-132">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ddf29-132">Required Request Headers</span></span>

| <span data-ttu-id="ddf29-133">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ddf29-133">Header</span></span>| <span data-ttu-id="ddf29-134">型</span><span class="sxs-lookup"><span data-stu-id="ddf29-134">Type</span></span>| <span data-ttu-id="ddf29-135">説明</span><span class="sxs-lookup"><span data-stu-id="ddf29-135">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ddf29-136">Authorization</span><span class="sxs-lookup"><span data-stu-id="ddf29-136">Authorization</span></span>| <span data-ttu-id="ddf29-137">string</span><span class="sxs-lookup"><span data-stu-id="ddf29-137">string</span></span>| <span data-ttu-id="ddf29-138">承認のデータです。</span><span class="sxs-lookup"><span data-stu-id="ddf29-138">Authorization data for .</span></span> <span data-ttu-id="ddf29-139">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="ddf29-139">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="ddf29-140">値の例: <b>XBL3.0 x = [ハッシュ]、[トークン]</b>します。</span><span class="sxs-lookup"><span data-stu-id="ddf29-140">Example value: <b>XBL3.0 x=[hash];[token]</b>.</span></span>|

<a id="ID4EHD"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="ddf29-141">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ddf29-141">Optional Request Headers</span></span>

| <span data-ttu-id="ddf29-142">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ddf29-142">Header</span></span>| <span data-ttu-id="ddf29-143">型</span><span class="sxs-lookup"><span data-stu-id="ddf29-143">Type</span></span>| <span data-ttu-id="ddf29-144">説明</span><span class="sxs-lookup"><span data-stu-id="ddf29-144">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ddf29-145">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="ddf29-145">x-xbl-contract-version</span></span>| <span data-ttu-id="ddf29-146">string</span><span class="sxs-lookup"><span data-stu-id="ddf29-146">string</span></span>| <span data-ttu-id="ddf29-147">この要求を送信する必要があります、サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="ddf29-147">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="ddf29-148">要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。値の例: 1</span><span class="sxs-lookup"><span data-stu-id="ddf29-148">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Example values: 1</span></span>|
| <span data-ttu-id="ddf29-149">Accept</span><span class="sxs-lookup"><span data-stu-id="ddf29-149">Accept</span></span>| <span data-ttu-id="ddf29-150">string</span><span class="sxs-lookup"><span data-stu-id="ddf29-150">string</span></span>| <span data-ttu-id="ddf29-151">コンテンツの種類の受け入れられる。</span><span class="sxs-lookup"><span data-stu-id="ddf29-151">Content-Types that are acceptable.</span></span> <span data-ttu-id="ddf29-152">すべての返信はされます<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="ddf29-152">All responses will be <code>application/json</code>.</span></span>|

<a id="ID4EXE"></a>


## <a name="request-body"></a><span data-ttu-id="ddf29-153">要求本文</span><span class="sxs-lookup"><span data-stu-id="ddf29-153">Request body</span></span>

<span data-ttu-id="ddf29-154">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="ddf29-154">No objects are sent in the body of this request.</span></span>

<a id="ID4ECF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="ddf29-155">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ddf29-155">HTTP status codes</span></span>

<span data-ttu-id="ddf29-156">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="ddf29-156">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="ddf29-157">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ddf29-157">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="ddf29-158">コード</span><span class="sxs-lookup"><span data-stu-id="ddf29-158">Code</span></span>| <span data-ttu-id="ddf29-159">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="ddf29-159">Reason phrase</span></span>| <span data-ttu-id="ddf29-160">説明</span><span class="sxs-lookup"><span data-stu-id="ddf29-160">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ddf29-161">200</span><span class="sxs-lookup"><span data-stu-id="ddf29-161">200</span></span>| <span data-ttu-id="ddf29-162">OK</span><span class="sxs-lookup"><span data-stu-id="ddf29-162">OK</span></span>| <span data-ttu-id="ddf29-163">セッションが正常に取得されます。</span><span class="sxs-lookup"><span data-stu-id="ddf29-163">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="ddf29-164">400</span><span class="sxs-lookup"><span data-stu-id="ddf29-164">400</span></span>| <span data-ttu-id="ddf29-165">Bad Request</span><span class="sxs-lookup"><span data-stu-id="ddf29-165">Bad Request</span></span>| <span data-ttu-id="ddf29-166">ユーザー Id が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="ddf29-166">User IDs were malformed.</span></span>|
| <span data-ttu-id="ddf29-167">403</span><span class="sxs-lookup"><span data-stu-id="ddf29-167">403</span></span>| <span data-ttu-id="ddf29-168">Forbidden</span><span class="sxs-lookup"><span data-stu-id="ddf29-168">Forbidden</span></span>| <span data-ttu-id="ddf29-169">承認ヘッダーに XUID クレームを解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="ddf29-169">XUID claim could not be parsed from the authorization header.</span></span>|

<a id="ID4EZG"></a>


## <a name="required-response-headers"></a><span data-ttu-id="ddf29-170">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ddf29-170">Required Response Headers</span></span>

| <span data-ttu-id="ddf29-171">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ddf29-171">Header</span></span>| <span data-ttu-id="ddf29-172">型</span><span class="sxs-lookup"><span data-stu-id="ddf29-172">Type</span></span>| <span data-ttu-id="ddf29-173">説明</span><span class="sxs-lookup"><span data-stu-id="ddf29-173">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ddf29-174">Content-Length</span><span class="sxs-lookup"><span data-stu-id="ddf29-174">Content-Length</span></span>| <span data-ttu-id="ddf29-175">string</span><span class="sxs-lookup"><span data-stu-id="ddf29-175">string</span></span>| <span data-ttu-id="ddf29-176">応答に送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="ddf29-176">The number of bytes being sent in the response.</span></span> <span data-ttu-id="ddf29-177">値の例: 232 します。</span><span class="sxs-lookup"><span data-stu-id="ddf29-177">Example value: 232.</span></span>|
| <span data-ttu-id="ddf29-178">Content-Type</span><span class="sxs-lookup"><span data-stu-id="ddf29-178">Content-Type</span></span>| <span data-ttu-id="ddf29-179">string</span><span class="sxs-lookup"><span data-stu-id="ddf29-179">string</span></span>| <span data-ttu-id="ddf29-180">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="ddf29-180">MIME type of the response body.</span></span> <span data-ttu-id="ddf29-181">これは、<b>アプリケーション/json</b>でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="ddf29-181">This must be <b>application/json</b>.</span></span>|

<a id="ID4EGAAC"></a>


## <a name="response-body"></a><span data-ttu-id="ddf29-182">応答本文</span><span class="sxs-lookup"><span data-stu-id="ddf29-182">Response body</span></span>

<span data-ttu-id="ddf29-183">[PersonSummary (JSON)](../../json/json-personsummary.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ddf29-183">See [PersonSummary (JSON)](../../json/json-personsummary.md).</span></span>

<a id="ID4ESAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="ddf29-184">応答の例</span><span class="sxs-lookup"><span data-stu-id="ddf29-184">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="ddf29-185">関連項目</span><span class="sxs-lookup"><span data-stu-id="ddf29-185">See also</span></span>

<a id="ID4E5AAC"></a>


##### <a name="parent"></a><span data-ttu-id="ddf29-186">Parent</span><span class="sxs-lookup"><span data-stu-id="ddf29-186">Parent</span></span>

[<span data-ttu-id="ddf29-187">/users/{ownerId}/概要</span><span class="sxs-lookup"><span data-stu-id="ddf29-187">/users/{ownerId}/summary</span></span>](uri-usersowneridsummary.md)
