---
title: GET (/users/{ownerId}/summary)
assetID: 754190c9-b15d-f34b-1dca-5c92f6f67d12
permalink: en-us/docs/xboxlive/rest/uri-usersowneridsummaryget.html
description: " GET (/users/{ownerId}/summary)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3b228adab7b035ec8f4e65fc8b7458228a677987
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613997"
---
# <a name="get-usersowneridsummary"></a><span data-ttu-id="84daf-104">GET (/users/{ownerId}/summary)</span><span class="sxs-lookup"><span data-stu-id="84daf-104">GET (/users/{ownerId}/summary)</span></span>
<span data-ttu-id="84daf-105">呼び出し元の観点から、所有者に関する概要データを取得します。</span><span class="sxs-lookup"><span data-stu-id="84daf-105">Gets summary data about the owner from the caller's perspective.</span></span>

  * [<span data-ttu-id="84daf-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="84daf-106">URI parameters</span></span>](#ID4EQ)
  * [<span data-ttu-id="84daf-107">承認</span><span class="sxs-lookup"><span data-stu-id="84daf-107">Authorization</span></span>](#ID4E2)
  * [<span data-ttu-id="84daf-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="84daf-108">Required Request Headers</span></span>](#ID4EBC)
  * [<span data-ttu-id="84daf-109">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="84daf-109">Optional Request Headers</span></span>](#ID4EHD)
  * [<span data-ttu-id="84daf-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="84daf-110">Request body</span></span>](#ID4EXE)
  * [<span data-ttu-id="84daf-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="84daf-111">HTTP status codes</span></span>](#ID4ECF)
  * [<span data-ttu-id="84daf-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="84daf-112">Required Response Headers</span></span>](#ID4EZG)
  * [<span data-ttu-id="84daf-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="84daf-113">Response body</span></span>](#ID4EGAAC)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="84daf-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="84daf-114">URI parameters</span></span>

| <span data-ttu-id="84daf-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="84daf-115">Parameter</span></span>| <span data-ttu-id="84daf-116">種類</span><span class="sxs-lookup"><span data-stu-id="84daf-116">Type</span></span>| <span data-ttu-id="84daf-117">説明</span><span class="sxs-lookup"><span data-stu-id="84daf-117">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="84daf-118">ownerId</span><span class="sxs-lookup"><span data-stu-id="84daf-118">ownerId</span></span>| <span data-ttu-id="84daf-119">string</span><span class="sxs-lookup"><span data-stu-id="84daf-119">string</span></span>| <span data-ttu-id="84daf-120">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="84daf-120">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="84daf-121">使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="84daf-121">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span> <span data-ttu-id="84daf-122">値の例: <code>me</code>、 <code>xuid(2603643534573581)</code>、 <code>gt(SomeGamertag)</code></span><span class="sxs-lookup"><span data-stu-id="84daf-122">Example values: <code>me</code>, <code>xuid(2603643534573581)</code>, <code>gt(SomeGamertag)</code></span></span>|

<a id="ID4E2"></a>


## <a name="authorization"></a><span data-ttu-id="84daf-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="84daf-123">Authorization</span></span>

| <span data-ttu-id="84daf-124"><b>名前</b></span><span class="sxs-lookup"><span data-stu-id="84daf-124"><b>Name</b></span></span>| <span data-ttu-id="84daf-125"><b>型</b></span><span class="sxs-lookup"><span data-stu-id="84daf-125"><b>Type</b></span></span>| <span data-ttu-id="84daf-126"><b>説明</b></span><span class="sxs-lookup"><span data-stu-id="84daf-126"><b>Description</b></span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="84daf-127">xuid</span><span class="sxs-lookup"><span data-stu-id="84daf-127">xuid</span></span>| <span data-ttu-id="84daf-128">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="84daf-128">64-bit unsigned integer</span></span>| <span data-ttu-id="84daf-129">必須。</span><span class="sxs-lookup"><span data-stu-id="84daf-129">Required.</span></span> <span data-ttu-id="84daf-130">呼び出し元のユーザー識別子。</span><span class="sxs-lookup"><span data-stu-id="84daf-130">user identifier of the caller.</span></span> <span data-ttu-id="84daf-131">値の例:2533274790395904</span><span class="sxs-lookup"><span data-stu-id="84daf-131">Example value: 2533274790395904</span></span>|

<a id="ID4EBC"></a>


## <a name="required-request-headers"></a><span data-ttu-id="84daf-132">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="84daf-132">Required Request Headers</span></span>

| <span data-ttu-id="84daf-133">Header</span><span class="sxs-lookup"><span data-stu-id="84daf-133">Header</span></span>| <span data-ttu-id="84daf-134">種類</span><span class="sxs-lookup"><span data-stu-id="84daf-134">Type</span></span>| <span data-ttu-id="84daf-135">説明</span><span class="sxs-lookup"><span data-stu-id="84daf-135">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="84daf-136">Authorization</span><span class="sxs-lookup"><span data-stu-id="84daf-136">Authorization</span></span>| <span data-ttu-id="84daf-137">string</span><span class="sxs-lookup"><span data-stu-id="84daf-137">string</span></span>| <span data-ttu-id="84daf-138">承認データです。</span><span class="sxs-lookup"><span data-stu-id="84daf-138">Authorization data for .</span></span> <span data-ttu-id="84daf-139">これは、通常、暗号化された XSTS トークンです。</span><span class="sxs-lookup"><span data-stu-id="84daf-139">This is typically an encrypted XSTS token.</span></span> <span data-ttu-id="84daf-140">値の例:<b>XBL3.0 x=[hash];[token]</b>.</span><span class="sxs-lookup"><span data-stu-id="84daf-140">Example value: <b>XBL3.0 x=[hash];[token]</b>.</span></span>|

<a id="ID4EHD"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="84daf-141">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="84daf-141">Optional Request Headers</span></span>

| <span data-ttu-id="84daf-142">Header</span><span class="sxs-lookup"><span data-stu-id="84daf-142">Header</span></span>| <span data-ttu-id="84daf-143">種類</span><span class="sxs-lookup"><span data-stu-id="84daf-143">Type</span></span>| <span data-ttu-id="84daf-144">説明</span><span class="sxs-lookup"><span data-stu-id="84daf-144">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="84daf-145">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="84daf-145">x-xbl-contract-version</span></span>| <span data-ttu-id="84daf-146">string</span><span class="sxs-lookup"><span data-stu-id="84daf-146">string</span></span>| <span data-ttu-id="84daf-147">この要求が送られるサービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="84daf-147">Build name/number of the service to which this request should be directed.</span></span> <span data-ttu-id="84daf-148">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。値の例:1</span><span class="sxs-lookup"><span data-stu-id="84daf-148">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Example values: 1</span></span>|
| <span data-ttu-id="84daf-149">OK</span><span class="sxs-lookup"><span data-stu-id="84daf-149">Accept</span></span>| <span data-ttu-id="84daf-150">string</span><span class="sxs-lookup"><span data-stu-id="84daf-150">string</span></span>| <span data-ttu-id="84daf-151">コンテンツ型が許容されます。</span><span class="sxs-lookup"><span data-stu-id="84daf-151">Content-Types that are acceptable.</span></span> <span data-ttu-id="84daf-152">すべての応答がなります<code>application/json</code>します。</span><span class="sxs-lookup"><span data-stu-id="84daf-152">All responses will be <code>application/json</code>.</span></span>|

<a id="ID4EXE"></a>


## <a name="request-body"></a><span data-ttu-id="84daf-153">要求本文</span><span class="sxs-lookup"><span data-stu-id="84daf-153">Request body</span></span>

<span data-ttu-id="84daf-154">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="84daf-154">No objects are sent in the body of this request.</span></span>

<a id="ID4ECF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="84daf-155">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="84daf-155">HTTP status codes</span></span>

<span data-ttu-id="84daf-156">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="84daf-156">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="84daf-157">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="84daf-157">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="84daf-158">コード</span><span class="sxs-lookup"><span data-stu-id="84daf-158">Code</span></span>| <span data-ttu-id="84daf-159">理由語句</span><span class="sxs-lookup"><span data-stu-id="84daf-159">Reason phrase</span></span>| <span data-ttu-id="84daf-160">説明</span><span class="sxs-lookup"><span data-stu-id="84daf-160">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="84daf-161">200</span><span class="sxs-lookup"><span data-stu-id="84daf-161">200</span></span>| <span data-ttu-id="84daf-162">OK</span><span class="sxs-lookup"><span data-stu-id="84daf-162">OK</span></span>| <span data-ttu-id="84daf-163">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="84daf-163">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="84daf-164">400</span><span class="sxs-lookup"><span data-stu-id="84daf-164">400</span></span>| <span data-ttu-id="84daf-165">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="84daf-165">Bad Request</span></span>| <span data-ttu-id="84daf-166">ユーザー Id は、形式が正しくありませんでした。</span><span class="sxs-lookup"><span data-stu-id="84daf-166">User IDs were malformed.</span></span>|
| <span data-ttu-id="84daf-167">403</span><span class="sxs-lookup"><span data-stu-id="84daf-167">403</span></span>| <span data-ttu-id="84daf-168">Forbidden</span><span class="sxs-lookup"><span data-stu-id="84daf-168">Forbidden</span></span>| <span data-ttu-id="84daf-169">Authorization ヘッダーから XUID 要求を解析できませんでした。</span><span class="sxs-lookup"><span data-stu-id="84daf-169">XUID claim could not be parsed from the authorization header.</span></span>|

<a id="ID4EZG"></a>


## <a name="required-response-headers"></a><span data-ttu-id="84daf-170">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="84daf-170">Required Response Headers</span></span>

| <span data-ttu-id="84daf-171">Header</span><span class="sxs-lookup"><span data-stu-id="84daf-171">Header</span></span>| <span data-ttu-id="84daf-172">種類</span><span class="sxs-lookup"><span data-stu-id="84daf-172">Type</span></span>| <span data-ttu-id="84daf-173">説明</span><span class="sxs-lookup"><span data-stu-id="84daf-173">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="84daf-174">Content-Length</span><span class="sxs-lookup"><span data-stu-id="84daf-174">Content-Length</span></span>| <span data-ttu-id="84daf-175">string</span><span class="sxs-lookup"><span data-stu-id="84daf-175">string</span></span>| <span data-ttu-id="84daf-176">応答で送信されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="84daf-176">The number of bytes being sent in the response.</span></span> <span data-ttu-id="84daf-177">値の例:232.</span><span class="sxs-lookup"><span data-stu-id="84daf-177">Example value: 232.</span></span>|
| <span data-ttu-id="84daf-178">Content-Type</span><span class="sxs-lookup"><span data-stu-id="84daf-178">Content-Type</span></span>| <span data-ttu-id="84daf-179">string</span><span class="sxs-lookup"><span data-stu-id="84daf-179">string</span></span>| <span data-ttu-id="84daf-180">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="84daf-180">MIME type of the response body.</span></span> <span data-ttu-id="84daf-181">これでなければなりません<b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="84daf-181">This must be <b>application/json</b>.</span></span>|

<a id="ID4EGAAC"></a>


## <a name="response-body"></a><span data-ttu-id="84daf-182">応答本文</span><span class="sxs-lookup"><span data-stu-id="84daf-182">Response body</span></span>

<span data-ttu-id="84daf-183">参照してください[PersonSummary (JSON)](../../json/json-personsummary.md)します。</span><span class="sxs-lookup"><span data-stu-id="84daf-183">See [PersonSummary (JSON)](../../json/json-personsummary.md).</span></span>

<a id="ID4ESAAC"></a>


### <a name="sample-response"></a><span data-ttu-id="84daf-184">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="84daf-184">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="84daf-185">関連項目</span><span class="sxs-lookup"><span data-stu-id="84daf-185">See also</span></span>

<a id="ID4E5AAC"></a>


##### <a name="parent"></a><span data-ttu-id="84daf-186">Parent</span><span class="sxs-lookup"><span data-stu-id="84daf-186">Parent</span></span>

[<span data-ttu-id="84daf-187">/users/{ownerId}/summary</span><span class="sxs-lookup"><span data-stu-id="84daf-187">/users/{ownerId}/summary</span></span>](uri-usersowneridsummary.md)
