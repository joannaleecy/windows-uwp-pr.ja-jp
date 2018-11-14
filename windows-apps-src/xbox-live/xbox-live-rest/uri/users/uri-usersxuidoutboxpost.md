---
title: POST (/users/xuid({xuid})/outbox)
assetID: de991d88-efe0-04f2-f6b2-0bc3e68bfd46
permalink: en-us/docs/xboxlive/rest/uri-usersxuidoutboxpost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/outbox)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 86853a490ab407fa96d40c4b2e3deb42c5f346a3
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6248545"
---
# <a name="post-usersxuidxuidoutbox"></a><span data-ttu-id="64731-104">POST (/users/xuid({xuid})/outbox)</span><span class="sxs-lookup"><span data-stu-id="64731-104">POST (/users/xuid({xuid})/outbox)</span></span>
<span data-ttu-id="64731-105">受信者の一覧を指定されたメッセージを送信します。</span><span class="sxs-lookup"><span data-stu-id="64731-105">Sends a specified message to a list of recipients.</span></span>
<span data-ttu-id="64731-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="64731-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>

  * [<span data-ttu-id="64731-107">注釈</span><span class="sxs-lookup"><span data-stu-id="64731-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="64731-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="64731-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="64731-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="64731-109">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="64731-110">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="64731-110">Effect of privacy settings on resource</span></span>](#ID4EYB)
  * [<span data-ttu-id="64731-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="64731-111">Request body</span></span>](#ID4E3F)
  * [<span data-ttu-id="64731-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="64731-112">HTTP status codes</span></span>](#ID4ETCAC)
  * [<span data-ttu-id="64731-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="64731-113">Response body</span></span>](#ID4E1EAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="64731-114">注釈</span><span class="sxs-lookup"><span data-stu-id="64731-114">Remarks</span></span>

<span data-ttu-id="64731-115">この API は、サポートのみのコンテンツの種類は、"アプリケーション/json"、呼び出しごとの HTTP ヘッダーのために必要です。</span><span class="sxs-lookup"><span data-stu-id="64731-115">The only content type this API supports is "application/json", which is required in the HTTP headers of each call.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="64731-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="64731-116">URI parameters</span></span>

| <span data-ttu-id="64731-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="64731-117">Parameter</span></span>| <span data-ttu-id="64731-118">型</span><span class="sxs-lookup"><span data-stu-id="64731-118">Type</span></span>| <span data-ttu-id="64731-119">説明</span><span class="sxs-lookup"><span data-stu-id="64731-119">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="64731-120">xuid</span><span class="sxs-lookup"><span data-stu-id="64731-120">xuid</span></span> | <span data-ttu-id="64731-121">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="64731-121">unsigned 64-bit integer</span></span> | <span data-ttu-id="64731-122">Xbox ユーザー ID (XUID) 要求を行っているプレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="64731-122">The Xbox User ID (XUID) of the player who is making the request.</span></span> |

<a id="ID4ENB"></a>


## <a name="authorization"></a><span data-ttu-id="64731-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="64731-123">Authorization</span></span>

<span data-ttu-id="64731-124">ユーザーのメッセージを送信するには、ユーザー要求と有効なゴールド サブスクリプションが必要です。</span><span class="sxs-lookup"><span data-stu-id="64731-124">You must have your own user claim and a valid gold subscription to send a user message.</span></span>

<a id="ID4EYB"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="64731-125">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="64731-125">Effect of privacy settings on resource</span></span>

<span data-ttu-id="64731-126">正常にメッセージを送信するユーザー、プレイヤーにかどうかプレイヤーの友人、結果 200 の結果コード。</span><span class="sxs-lookup"><span data-stu-id="64731-126">Successfully sending a user message to a player, whether that player is a friend or not, results in a result code of 200.</span></span> <span data-ttu-id="64731-127">ただし、によりブロックされている他の人物にメッセージを送信する場合、受信側では、メッセージは表示されませんが、メッセージが成功したことを示すは表示されません。</span><span class="sxs-lookup"><span data-stu-id="64731-127">However, if you send a message to someone who has blocked you, the recipient will not receive the message, and you will not receive any indication that your message wasn't successful.</span></span>

<span data-ttu-id="64731-128">メッセージ数に送信できると 1 日あたり数のフレンドとフレンド以外の場合、次のようにはも制限があります。</span><span class="sxs-lookup"><span data-stu-id="64731-128">There are also limits on how many messages can be sent per day and to how many friends and non-friends, as follows.</span></span>

   * <span data-ttu-id="64731-129">メッセージあたり 20 見知らぬユーザー</span><span class="sxs-lookup"><span data-stu-id="64731-129">20 strangers per message</span></span>
   * <span data-ttu-id="64731-130">24 時間ごと 200 見知らぬユーザー</span><span class="sxs-lookup"><span data-stu-id="64731-130">200 strangers per 24 hours</span></span>
   * <span data-ttu-id="64731-131">24 時間ごとに 250 の合計メッセージ</span><span class="sxs-lookup"><span data-stu-id="64731-131">250 total messages per 24 hours</span></span>
   * <span data-ttu-id="64731-132">2500 24 時間ごとの受信者を合計します。</span><span class="sxs-lookup"><span data-stu-id="64731-132">2500 total recipients per 24 hours</span></span>

| <span data-ttu-id="64731-133">ユーザーの要求</span><span class="sxs-lookup"><span data-stu-id="64731-133">Requesting User</span></span>| <span data-ttu-id="64731-134">ターゲット ユーザーのプライバシー設定</span><span class="sxs-lookup"><span data-stu-id="64731-134">Target User's Privacy Setting</span></span>| <span data-ttu-id="64731-135">動作</span><span class="sxs-lookup"><span data-stu-id="64731-135">Behavior</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="64731-136">me</span><span class="sxs-lookup"><span data-stu-id="64731-136">me</span></span>| -| <span data-ttu-id="64731-137">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="64731-137">As described.</span></span>|
| <span data-ttu-id="64731-138">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="64731-138">friend</span></span>| <span data-ttu-id="64731-139">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="64731-139">everyone</span></span>| <span data-ttu-id="64731-140">200 OK</span><span class="sxs-lookup"><span data-stu-id="64731-140">200 OK</span></span>|
| <span data-ttu-id="64731-141">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="64731-141">friend</span></span>| <span data-ttu-id="64731-142">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="64731-142">friends only</span></span>| <span data-ttu-id="64731-143">200 OK</span><span class="sxs-lookup"><span data-stu-id="64731-143">200 OK</span></span>|
| <span data-ttu-id="64731-144">フレンド登録の依頼</span><span class="sxs-lookup"><span data-stu-id="64731-144">friend</span></span>| <span data-ttu-id="64731-145">ブロック</span><span class="sxs-lookup"><span data-stu-id="64731-145">blocked</span></span>| <span data-ttu-id="64731-146">200 OK</span><span class="sxs-lookup"><span data-stu-id="64731-146">200 OK</span></span>|
| <span data-ttu-id="64731-147">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="64731-147">non-friend user</span></span>| <span data-ttu-id="64731-148">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="64731-148">everyone</span></span>| <span data-ttu-id="64731-149">200 OK</span><span class="sxs-lookup"><span data-stu-id="64731-149">200 OK</span></span>|
| <span data-ttu-id="64731-150">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="64731-150">non-friend user</span></span>| <span data-ttu-id="64731-151">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="64731-151">friends only</span></span>| <span data-ttu-id="64731-152">200 OK</span><span class="sxs-lookup"><span data-stu-id="64731-152">200 OK</span></span>|
| <span data-ttu-id="64731-153">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="64731-153">non-friend user</span></span>| <span data-ttu-id="64731-154">ブロック</span><span class="sxs-lookup"><span data-stu-id="64731-154">blocked</span></span>| <span data-ttu-id="64731-155">200 OK</span><span class="sxs-lookup"><span data-stu-id="64731-155">200 OK</span></span>|
| <span data-ttu-id="64731-156">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="64731-156">third-party site</span></span>| <span data-ttu-id="64731-157">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="64731-157">everyone</span></span>| <span data-ttu-id="64731-158">200 OK</span><span class="sxs-lookup"><span data-stu-id="64731-158">200 OK</span></span>|
| <span data-ttu-id="64731-159">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="64731-159">third-party site</span></span>| <span data-ttu-id="64731-160">フレンドのみ</span><span class="sxs-lookup"><span data-stu-id="64731-160">friends only</span></span>| <span data-ttu-id="64731-161">200 OK</span><span class="sxs-lookup"><span data-stu-id="64731-161">200 OK</span></span>|
| <span data-ttu-id="64731-162">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="64731-162">third-party site</span></span>| <span data-ttu-id="64731-163">ブロック</span><span class="sxs-lookup"><span data-stu-id="64731-163">blocked</span></span>| <span data-ttu-id="64731-164">200 OK</span><span class="sxs-lookup"><span data-stu-id="64731-164">200 OK</span></span>|

<a id="ID4E3F"></a>


## <a name="request-body"></a><span data-ttu-id="64731-165">要求本文</span><span class="sxs-lookup"><span data-stu-id="64731-165">Request body</span></span>

| <span data-ttu-id="64731-166">プロパティ</span><span class="sxs-lookup"><span data-stu-id="64731-166">Property</span></span>| <span data-ttu-id="64731-167">型</span><span class="sxs-lookup"><span data-stu-id="64731-167">Type</span></span>| <span data-ttu-id="64731-168">最大長</span><span class="sxs-lookup"><span data-stu-id="64731-168">Maximum Length</span></span>| <span data-ttu-id="64731-169">消費者</span><span class="sxs-lookup"><span data-stu-id="64731-169">Consumers</span></span>| <span data-ttu-id="64731-170">注釈</span><span class="sxs-lookup"><span data-stu-id="64731-170">Remarks</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="64731-171">header</span><span class="sxs-lookup"><span data-stu-id="64731-171">header</span></span>| <span data-ttu-id="64731-172">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="64731-172">Header</span></span>|  | <span data-ttu-id="64731-173">すべての</span><span class="sxs-lookup"><span data-stu-id="64731-173">All</span></span>| <span data-ttu-id="64731-174">ユーザーのメッセージのヘッダー</span><span class="sxs-lookup"><span data-stu-id="64731-174">User message header</span></span>|
| <span data-ttu-id="64731-175">メッセージ テキスト</span><span class="sxs-lookup"><span data-stu-id="64731-175">messageText</span></span>| <span data-ttu-id="64731-176">string</span><span class="sxs-lookup"><span data-stu-id="64731-176">string</span></span>| <span data-ttu-id="64731-177">250</span><span class="sxs-lookup"><span data-stu-id="64731-177">250</span></span>| <span data-ttu-id="64731-178">Windows 8 を除くすべてのプラットフォーム</span><span class="sxs-lookup"><span data-stu-id="64731-178">All platforms except Windows 8</span></span>| <span data-ttu-id="64731-179">ユーザーのメッセージ テキスト (utf-8)</span><span class="sxs-lookup"><span data-stu-id="64731-179">User message text (UTF-8)</span></span>|

#### <a name="header"></a><span data-ttu-id="64731-180">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="64731-180">Header</span></span>

| <span data-ttu-id="64731-181">プロパティ</span><span class="sxs-lookup"><span data-stu-id="64731-181">Property</span></span>| <span data-ttu-id="64731-182">型</span><span class="sxs-lookup"><span data-stu-id="64731-182">Type</span></span>| <span data-ttu-id="64731-183">最大長</span><span class="sxs-lookup"><span data-stu-id="64731-183">Maximum Length</span></span>| <span data-ttu-id="64731-184">消費者</span><span class="sxs-lookup"><span data-stu-id="64731-184">Consumers</span></span>| <span data-ttu-id="64731-185">注釈</span><span class="sxs-lookup"><span data-stu-id="64731-185">Remarks</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="64731-186">受信者</span><span class="sxs-lookup"><span data-stu-id="64731-186">recipients</span></span>| <span data-ttu-id="64731-187">ユーザーの</span><span class="sxs-lookup"><span data-stu-id="64731-187">User[]</span></span>| <span data-ttu-id="64731-188">20</span><span class="sxs-lookup"><span data-stu-id="64731-188">20</span></span>| <span data-ttu-id="64731-189">すべての</span><span class="sxs-lookup"><span data-stu-id="64731-189">All</span></span>| <span data-ttu-id="64731-190">メッセージの受信者の一覧</span><span class="sxs-lookup"><span data-stu-id="64731-190">List of message recipients</span></span>|

#### <a name="user"></a><span data-ttu-id="64731-191">ユーザー</span><span class="sxs-lookup"><span data-stu-id="64731-191">User</span></span>

| <span data-ttu-id="64731-192">プロパティ</span><span class="sxs-lookup"><span data-stu-id="64731-192">Property</span></span>| <span data-ttu-id="64731-193">型</span><span class="sxs-lookup"><span data-stu-id="64731-193">Type</span></span>| <span data-ttu-id="64731-194">最大長</span><span class="sxs-lookup"><span data-stu-id="64731-194">Maximum Length</span></span>| <span data-ttu-id="64731-195">消費者</span><span class="sxs-lookup"><span data-stu-id="64731-195">Consumers</span></span>| <span data-ttu-id="64731-196">注釈</span><span class="sxs-lookup"><span data-stu-id="64731-196">Remarks</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="64731-197">xuid</span><span class="sxs-lookup"><span data-stu-id="64731-197">xuid</span></span>| <span data-ttu-id="64731-198">ulong</span><span class="sxs-lookup"><span data-stu-id="64731-198">ulong</span></span>|  | <span data-ttu-id="64731-199">すべての</span><span class="sxs-lookup"><span data-stu-id="64731-199">All</span></span>| <span data-ttu-id="64731-200">受信者はの XUID です。</span><span class="sxs-lookup"><span data-stu-id="64731-200">Recipient's XUID.</span></span> <span data-ttu-id="64731-201">ゲーマータグが送信される場合は使用されません。</span><span class="sxs-lookup"><span data-stu-id="64731-201">Not used if gamertag is sent.</span></span>|
| <span data-ttu-id="64731-202">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="64731-202">gamertag</span></span>| <span data-ttu-id="64731-203">string</span><span class="sxs-lookup"><span data-stu-id="64731-203">string</span></span>| <span data-ttu-id="64731-204">15</span><span class="sxs-lookup"><span data-stu-id="64731-204">15</span></span>| <span data-ttu-id="64731-205">すべての</span><span class="sxs-lookup"><span data-stu-id="64731-205">All</span></span>| <span data-ttu-id="64731-206">受信者のゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="64731-206">Recipient's gamertag.</span></span> <span data-ttu-id="64731-207">XUID が送信される場合は使用されません。</span><span class="sxs-lookup"><span data-stu-id="64731-207">Not used if XUID is sent.</span></span>|

#### <a name="sample-request-body"></a><span data-ttu-id="64731-208">要求本文のサンプル</span><span class="sxs-lookup"><span data-stu-id="64731-208">Sample Request Body</span></span> 

```cpp
{
          "header":
          {
            "recipients":
            [{"gamertag":"GoTeamEmily"},
            {"gamertag":"Longstreet360"}]
          },
          "messageText":"random user text"
        }

```


<a id="ID4ETCAC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="64731-209">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="64731-209">HTTP status codes</span></span>

<span data-ttu-id="64731-210">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="64731-210">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="64731-211">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="64731-211">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="64731-212">コード</span><span class="sxs-lookup"><span data-stu-id="64731-212">Code</span></span>| <span data-ttu-id="64731-213">説明</span><span class="sxs-lookup"><span data-stu-id="64731-213">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="64731-214">200</span><span class="sxs-lookup"><span data-stu-id="64731-214">200</span></span>| <span data-ttu-id="64731-215">成功します。</span><span class="sxs-lookup"><span data-stu-id="64731-215">Success.</span></span>|
| <span data-ttu-id="64731-216">400</span><span class="sxs-lookup"><span data-stu-id="64731-216">400</span></span>| <span data-ttu-id="64731-217">受信者の一覧が空または最大の長さを超えています。または、ゲーマータグと XUID の両方が指定されました。または、メッセージ テキストが長すぎます。</span><span class="sxs-lookup"><span data-stu-id="64731-217">List of recipients is empty or exceeds maximum length; or both gamertag and XUID were specified; or messageText is too long.</span></span>|
| <span data-ttu-id="64731-218">403</span><span class="sxs-lookup"><span data-stu-id="64731-218">403</span></span>| <span data-ttu-id="64731-219">XUID を変換することはできません。</span><span class="sxs-lookup"><span data-stu-id="64731-219">XUID cannot be converted.</span></span>|
| <span data-ttu-id="64731-220">404</span><span class="sxs-lookup"><span data-stu-id="64731-220">404</span></span>| <span data-ttu-id="64731-221">ゲーマータグが無効であるか、ユーザーが見つからない。</span><span class="sxs-lookup"><span data-stu-id="64731-221">Gamertag is invalid or user cannot be found.</span></span>|
| <span data-ttu-id="64731-222">409</span><span class="sxs-lookup"><span data-stu-id="64731-222">409</span></span>| <span data-ttu-id="64731-223">ユーザーは、システムによって 1 日あたりの制限に達した。</span><span class="sxs-lookup"><span data-stu-id="64731-223">User has reached daily limit imposed by the system.</span></span>|
| <span data-ttu-id="64731-224">500</span><span class="sxs-lookup"><span data-stu-id="64731-224">500</span></span>| <span data-ttu-id="64731-225">サーバー側の一般的なエラーです。</span><span class="sxs-lookup"><span data-stu-id="64731-225">General server-side error.</span></span>|

<a id="ID4E1EAC"></a>


## <a name="response-body"></a><span data-ttu-id="64731-226">応答本文</span><span class="sxs-lookup"><span data-stu-id="64731-226">Response body</span></span>

<span data-ttu-id="64731-227">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="64731-227">No objects are sent in the body of the response.</span></span>

<a id="ID4EJFAC"></a>


## <a name="see-also"></a><span data-ttu-id="64731-228">関連項目</span><span class="sxs-lookup"><span data-stu-id="64731-228">See also</span></span>

<a id="ID4ELFAC"></a>


##### <a name="parent"></a><span data-ttu-id="64731-229">Parent</span><span class="sxs-lookup"><span data-stu-id="64731-229">Parent</span></span>  

[<span data-ttu-id="64731-230">/users/xuid({xuid})/outbox</span><span class="sxs-lookup"><span data-stu-id="64731-230">/users/xuid({xuid})/outbox</span></span>](uri-usersxuidoutbox.md)


<a id="ID4EZFAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a><span data-ttu-id="64731-231">参照[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)</span><span class="sxs-lookup"><span data-stu-id="64731-231">Reference  [Standard HTTP status codes](../../additional/httpstatuscodes.md)</span></span>
