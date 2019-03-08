---
title: POST (/users/xuid({xuid})/outbox)
assetID: de991d88-efe0-04f2-f6b2-0bc3e68bfd46
permalink: en-us/docs/xboxlive/rest/uri-usersxuidoutboxpost.html
description: " POST (/users/xuid({xuid})/outbox)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2b225e8441fee3d499f172e2e5701096cdbc161a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594287"
---
# <a name="post-usersxuidxuidoutbox"></a><span data-ttu-id="cf217-104">POST (/users/xuid({xuid})/outbox)</span><span class="sxs-lookup"><span data-stu-id="cf217-104">POST (/users/xuid({xuid})/outbox)</span></span>
<span data-ttu-id="cf217-105">受信者の一覧を指定したメッセージを送信します。</span><span class="sxs-lookup"><span data-stu-id="cf217-105">Sends a specified message to a list of recipients.</span></span>
<span data-ttu-id="cf217-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cf217-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>

  * [<span data-ttu-id="cf217-107">注釈</span><span class="sxs-lookup"><span data-stu-id="cf217-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="cf217-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf217-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="cf217-109">承認</span><span class="sxs-lookup"><span data-stu-id="cf217-109">Authorization</span></span>](#ID4ENB)
  * [<span data-ttu-id="cf217-110">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="cf217-110">Effect of privacy settings on resource</span></span>](#ID4EYB)
  * [<span data-ttu-id="cf217-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="cf217-111">Request body</span></span>](#ID4E3F)
  * [<span data-ttu-id="cf217-112">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="cf217-112">HTTP status codes</span></span>](#ID4ETCAC)
  * [<span data-ttu-id="cf217-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="cf217-113">Response body</span></span>](#ID4E1EAC)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="cf217-114">注釈</span><span class="sxs-lookup"><span data-stu-id="cf217-114">Remarks</span></span>

<span data-ttu-id="cf217-115">この API はサポートのみコンテンツの種類は、"application/json"に必要な各呼び出しの HTTP ヘッダーが。</span><span class="sxs-lookup"><span data-stu-id="cf217-115">The only content type this API supports is "application/json", which is required in the HTTP headers of each call.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="cf217-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf217-116">URI parameters</span></span>

| <span data-ttu-id="cf217-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf217-117">Parameter</span></span>| <span data-ttu-id="cf217-118">種類</span><span class="sxs-lookup"><span data-stu-id="cf217-118">Type</span></span>| <span data-ttu-id="cf217-119">説明</span><span class="sxs-lookup"><span data-stu-id="cf217-119">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="cf217-120">xuid</span><span class="sxs-lookup"><span data-stu-id="cf217-120">xuid</span></span> | <span data-ttu-id="cf217-121">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="cf217-121">unsigned 64-bit integer</span></span> | <span data-ttu-id="cf217-122">Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。</span><span class="sxs-lookup"><span data-stu-id="cf217-122">The Xbox User ID (XUID) of the player who is making the request.</span></span> |

<a id="ID4ENB"></a>


## <a name="authorization"></a><span data-ttu-id="cf217-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="cf217-123">Authorization</span></span>

<span data-ttu-id="cf217-124">ユーザー メッセージを送信するには、独自のユーザー要求とゴールドの有効なサブスクリプションが必要です。</span><span class="sxs-lookup"><span data-stu-id="cf217-124">You must have your own user claim and a valid gold subscription to send a user message.</span></span>

<a id="ID4EYB"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="cf217-125">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="cf217-125">Effect of privacy settings on resource</span></span>

<span data-ttu-id="cf217-126">結果コード 200 の結果か、そのプレイヤーがフレンドかどうかをプレーヤーにユーザー メッセージを正常に送信します。</span><span class="sxs-lookup"><span data-stu-id="cf217-126">Successfully sending a user message to a player, whether that player is a friend or not, results in a result code of 200.</span></span> <span data-ttu-id="cf217-127">ただし、ブロックした人にメッセージを送信する場合、受信者は、メッセージを受け取りません、任意のメッセージが成功したことを示す値を受け取りません。</span><span class="sxs-lookup"><span data-stu-id="cf217-127">However, if you send a message to someone who has blocked you, the recipient will not receive the message, and you will not receive any indication that your message wasn't successful.</span></span>

<span data-ttu-id="cf217-128">メッセージの数に送信できますと 1 日あたり数の友人や友人以外の場合、次のようには制限もあります。</span><span class="sxs-lookup"><span data-stu-id="cf217-128">There are also limits on how many messages can be sent per day and to how many friends and non-friends, as follows.</span></span>

   * <span data-ttu-id="cf217-129">メッセージあたり 20 知らない</span><span class="sxs-lookup"><span data-stu-id="cf217-129">20 strangers per message</span></span>
   * <span data-ttu-id="cf217-130">24 時間あたり 200 知らない</span><span class="sxs-lookup"><span data-stu-id="cf217-130">200 strangers per 24 hours</span></span>
   * <span data-ttu-id="cf217-131">24 時間ごとに 250 の合計メッセージ</span><span class="sxs-lookup"><span data-stu-id="cf217-131">250 total messages per 24 hours</span></span>
   * <span data-ttu-id="cf217-132">24 時間あたり 2500 人の受信者</span><span class="sxs-lookup"><span data-stu-id="cf217-132">2500 total recipients per 24 hours</span></span>

| <span data-ttu-id="cf217-133">要求元のユーザー</span><span class="sxs-lookup"><span data-stu-id="cf217-133">Requesting User</span></span>| <span data-ttu-id="cf217-134">ターゲット ユーザーのプライバシーの設定</span><span class="sxs-lookup"><span data-stu-id="cf217-134">Target User's Privacy Setting</span></span>| <span data-ttu-id="cf217-135">動作</span><span class="sxs-lookup"><span data-stu-id="cf217-135">Behavior</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="cf217-136">Me</span><span class="sxs-lookup"><span data-stu-id="cf217-136">me</span></span>| -| <span data-ttu-id="cf217-137">前述のようにします。</span><span class="sxs-lookup"><span data-stu-id="cf217-137">As described.</span></span>|
| <span data-ttu-id="cf217-138">friend</span><span class="sxs-lookup"><span data-stu-id="cf217-138">friend</span></span>| <span data-ttu-id="cf217-139">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="cf217-139">everyone</span></span>| <span data-ttu-id="cf217-140">200 OK</span><span class="sxs-lookup"><span data-stu-id="cf217-140">200 OK</span></span>|
| <span data-ttu-id="cf217-141">friend</span><span class="sxs-lookup"><span data-stu-id="cf217-141">friend</span></span>| <span data-ttu-id="cf217-142">友達のみ</span><span class="sxs-lookup"><span data-stu-id="cf217-142">friends only</span></span>| <span data-ttu-id="cf217-143">200 OK</span><span class="sxs-lookup"><span data-stu-id="cf217-143">200 OK</span></span>|
| <span data-ttu-id="cf217-144">friend</span><span class="sxs-lookup"><span data-stu-id="cf217-144">friend</span></span>| <span data-ttu-id="cf217-145">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="cf217-145">blocked</span></span>| <span data-ttu-id="cf217-146">200 OK</span><span class="sxs-lookup"><span data-stu-id="cf217-146">200 OK</span></span>|
| <span data-ttu-id="cf217-147">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="cf217-147">non-friend user</span></span>| <span data-ttu-id="cf217-148">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="cf217-148">everyone</span></span>| <span data-ttu-id="cf217-149">200 OK</span><span class="sxs-lookup"><span data-stu-id="cf217-149">200 OK</span></span>|
| <span data-ttu-id="cf217-150">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="cf217-150">non-friend user</span></span>| <span data-ttu-id="cf217-151">友達のみ</span><span class="sxs-lookup"><span data-stu-id="cf217-151">friends only</span></span>| <span data-ttu-id="cf217-152">200 OK</span><span class="sxs-lookup"><span data-stu-id="cf217-152">200 OK</span></span>|
| <span data-ttu-id="cf217-153">フレンド以外のユーザー</span><span class="sxs-lookup"><span data-stu-id="cf217-153">non-friend user</span></span>| <span data-ttu-id="cf217-154">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="cf217-154">blocked</span></span>| <span data-ttu-id="cf217-155">200 OK</span><span class="sxs-lookup"><span data-stu-id="cf217-155">200 OK</span></span>|
| <span data-ttu-id="cf217-156">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="cf217-156">third-party site</span></span>| <span data-ttu-id="cf217-157">すべてのユーザー</span><span class="sxs-lookup"><span data-stu-id="cf217-157">everyone</span></span>| <span data-ttu-id="cf217-158">200 OK</span><span class="sxs-lookup"><span data-stu-id="cf217-158">200 OK</span></span>|
| <span data-ttu-id="cf217-159">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="cf217-159">third-party site</span></span>| <span data-ttu-id="cf217-160">友達のみ</span><span class="sxs-lookup"><span data-stu-id="cf217-160">friends only</span></span>| <span data-ttu-id="cf217-161">200 OK</span><span class="sxs-lookup"><span data-stu-id="cf217-161">200 OK</span></span>|
| <span data-ttu-id="cf217-162">サード パーティのサイト</span><span class="sxs-lookup"><span data-stu-id="cf217-162">third-party site</span></span>| <span data-ttu-id="cf217-163">ブロック済み</span><span class="sxs-lookup"><span data-stu-id="cf217-163">blocked</span></span>| <span data-ttu-id="cf217-164">200 OK</span><span class="sxs-lookup"><span data-stu-id="cf217-164">200 OK</span></span>|

<a id="ID4E3F"></a>


## <a name="request-body"></a><span data-ttu-id="cf217-165">要求本文</span><span class="sxs-lookup"><span data-stu-id="cf217-165">Request body</span></span>

| <span data-ttu-id="cf217-166">プロパティ</span><span class="sxs-lookup"><span data-stu-id="cf217-166">Property</span></span>| <span data-ttu-id="cf217-167">種類</span><span class="sxs-lookup"><span data-stu-id="cf217-167">Type</span></span>| <span data-ttu-id="cf217-168">最大長</span><span class="sxs-lookup"><span data-stu-id="cf217-168">Maximum Length</span></span>| <span data-ttu-id="cf217-169">コンシューマー</span><span class="sxs-lookup"><span data-stu-id="cf217-169">Consumers</span></span>| <span data-ttu-id="cf217-170">注釈</span><span class="sxs-lookup"><span data-stu-id="cf217-170">Remarks</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="cf217-171">header</span><span class="sxs-lookup"><span data-stu-id="cf217-171">header</span></span>| <span data-ttu-id="cf217-172">Header</span><span class="sxs-lookup"><span data-stu-id="cf217-172">Header</span></span>|  | <span data-ttu-id="cf217-173">すべての</span><span class="sxs-lookup"><span data-stu-id="cf217-173">All</span></span>| <span data-ttu-id="cf217-174">ユーザー メッセージのヘッダー</span><span class="sxs-lookup"><span data-stu-id="cf217-174">User message header</span></span>|
| <span data-ttu-id="cf217-175">メッセージ テキスト</span><span class="sxs-lookup"><span data-stu-id="cf217-175">messageText</span></span>| <span data-ttu-id="cf217-176">string</span><span class="sxs-lookup"><span data-stu-id="cf217-176">string</span></span>| <span data-ttu-id="cf217-177">250</span><span class="sxs-lookup"><span data-stu-id="cf217-177">250</span></span>| <span data-ttu-id="cf217-178">Windows 8 を除くすべてのプラットフォーム</span><span class="sxs-lookup"><span data-stu-id="cf217-178">All platforms except Windows 8</span></span>| <span data-ttu-id="cf217-179">ユーザー メッセージ テキスト (utf-8)</span><span class="sxs-lookup"><span data-stu-id="cf217-179">User message text (UTF-8)</span></span>|

#### <a name="header"></a><span data-ttu-id="cf217-180">Header</span><span class="sxs-lookup"><span data-stu-id="cf217-180">Header</span></span>

| <span data-ttu-id="cf217-181">プロパティ</span><span class="sxs-lookup"><span data-stu-id="cf217-181">Property</span></span>| <span data-ttu-id="cf217-182">種類</span><span class="sxs-lookup"><span data-stu-id="cf217-182">Type</span></span>| <span data-ttu-id="cf217-183">最大長</span><span class="sxs-lookup"><span data-stu-id="cf217-183">Maximum Length</span></span>| <span data-ttu-id="cf217-184">コンシューマー</span><span class="sxs-lookup"><span data-stu-id="cf217-184">Consumers</span></span>| <span data-ttu-id="cf217-185">注釈</span><span class="sxs-lookup"><span data-stu-id="cf217-185">Remarks</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="cf217-186">受信者</span><span class="sxs-lookup"><span data-stu-id="cf217-186">recipients</span></span>| <span data-ttu-id="cf217-187">ユーザーの</span><span class="sxs-lookup"><span data-stu-id="cf217-187">User[]</span></span>| <span data-ttu-id="cf217-188">20</span><span class="sxs-lookup"><span data-stu-id="cf217-188">20</span></span>| <span data-ttu-id="cf217-189">すべての</span><span class="sxs-lookup"><span data-stu-id="cf217-189">All</span></span>| <span data-ttu-id="cf217-190">メッセージの受信者の一覧</span><span class="sxs-lookup"><span data-stu-id="cf217-190">List of message recipients</span></span>|

#### <a name="user"></a><span data-ttu-id="cf217-191">ユーザー</span><span class="sxs-lookup"><span data-stu-id="cf217-191">User</span></span>

| <span data-ttu-id="cf217-192">プロパティ</span><span class="sxs-lookup"><span data-stu-id="cf217-192">Property</span></span>| <span data-ttu-id="cf217-193">種類</span><span class="sxs-lookup"><span data-stu-id="cf217-193">Type</span></span>| <span data-ttu-id="cf217-194">最大長</span><span class="sxs-lookup"><span data-stu-id="cf217-194">Maximum Length</span></span>| <span data-ttu-id="cf217-195">コンシューマー</span><span class="sxs-lookup"><span data-stu-id="cf217-195">Consumers</span></span>| <span data-ttu-id="cf217-196">注釈</span><span class="sxs-lookup"><span data-stu-id="cf217-196">Remarks</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="cf217-197">xuid</span><span class="sxs-lookup"><span data-stu-id="cf217-197">xuid</span></span>| <span data-ttu-id="cf217-198">ulong</span><span class="sxs-lookup"><span data-stu-id="cf217-198">ulong</span></span>|  | <span data-ttu-id="cf217-199">すべての</span><span class="sxs-lookup"><span data-stu-id="cf217-199">All</span></span>| <span data-ttu-id="cf217-200">受信者はの XUID です。</span><span class="sxs-lookup"><span data-stu-id="cf217-200">Recipient's XUID.</span></span> <span data-ttu-id="cf217-201">ゲーマータグが送信される場合は使用されません。</span><span class="sxs-lookup"><span data-stu-id="cf217-201">Not used if gamertag is sent.</span></span>|
| <span data-ttu-id="cf217-202">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="cf217-202">gamertag</span></span>| <span data-ttu-id="cf217-203">string</span><span class="sxs-lookup"><span data-stu-id="cf217-203">string</span></span>| <span data-ttu-id="cf217-204">15</span><span class="sxs-lookup"><span data-stu-id="cf217-204">15</span></span>| <span data-ttu-id="cf217-205">すべての</span><span class="sxs-lookup"><span data-stu-id="cf217-205">All</span></span>| <span data-ttu-id="cf217-206">受信者のゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="cf217-206">Recipient's gamertag.</span></span> <span data-ttu-id="cf217-207">XUID が送信される場合は使用されません。</span><span class="sxs-lookup"><span data-stu-id="cf217-207">Not used if XUID is sent.</span></span>|

#### <a name="sample-request-body"></a><span data-ttu-id="cf217-208">要求本文のサンプル</span><span class="sxs-lookup"><span data-stu-id="cf217-208">Sample Request Body</span></span> 

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


## <a name="http-status-codes"></a><span data-ttu-id="cf217-209">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="cf217-209">HTTP status codes</span></span>

<span data-ttu-id="cf217-210">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="cf217-210">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="cf217-211">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="cf217-211">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="cf217-212">コード</span><span class="sxs-lookup"><span data-stu-id="cf217-212">Code</span></span>| <span data-ttu-id="cf217-213">説明</span><span class="sxs-lookup"><span data-stu-id="cf217-213">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="cf217-214">200</span><span class="sxs-lookup"><span data-stu-id="cf217-214">200</span></span>| <span data-ttu-id="cf217-215">成功しました。</span><span class="sxs-lookup"><span data-stu-id="cf217-215">Success.</span></span>|
| <span data-ttu-id="cf217-216">400</span><span class="sxs-lookup"><span data-stu-id="cf217-216">400</span></span>| <span data-ttu-id="cf217-217">受信者の一覧が空か、最大長を超えています。または、ゲーマータグと XUID の両方が指定されました。または、メッセージ テキストが長すぎます。</span><span class="sxs-lookup"><span data-stu-id="cf217-217">List of recipients is empty or exceeds maximum length; or both gamertag and XUID were specified; or messageText is too long.</span></span>|
| <span data-ttu-id="cf217-218">403</span><span class="sxs-lookup"><span data-stu-id="cf217-218">403</span></span>| <span data-ttu-id="cf217-219">XUID を変換することはできません。</span><span class="sxs-lookup"><span data-stu-id="cf217-219">XUID cannot be converted.</span></span>|
| <span data-ttu-id="cf217-220">404</span><span class="sxs-lookup"><span data-stu-id="cf217-220">404</span></span>| <span data-ttu-id="cf217-221">ゲーマータグが正しくないか、ユーザーが見つかりません。</span><span class="sxs-lookup"><span data-stu-id="cf217-221">Gamertag is invalid or user cannot be found.</span></span>|
| <span data-ttu-id="cf217-222">409</span><span class="sxs-lookup"><span data-stu-id="cf217-222">409</span></span>| <span data-ttu-id="cf217-223">ユーザーは、システムによる 1 日の上限に達しました。</span><span class="sxs-lookup"><span data-stu-id="cf217-223">User has reached daily limit imposed by the system.</span></span>|
| <span data-ttu-id="cf217-224">500</span><span class="sxs-lookup"><span data-stu-id="cf217-224">500</span></span>| <span data-ttu-id="cf217-225">サーバー側の一般エラーです。</span><span class="sxs-lookup"><span data-stu-id="cf217-225">General server-side error.</span></span>|

<a id="ID4E1EAC"></a>


## <a name="response-body"></a><span data-ttu-id="cf217-226">応答本文</span><span class="sxs-lookup"><span data-stu-id="cf217-226">Response body</span></span>

<span data-ttu-id="cf217-227">応答の本文では、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="cf217-227">No objects are sent in the body of the response.</span></span>

<a id="ID4EJFAC"></a>


## <a name="see-also"></a><span data-ttu-id="cf217-228">関連項目</span><span class="sxs-lookup"><span data-stu-id="cf217-228">See also</span></span>

<a id="ID4ELFAC"></a>


##### <a name="parent"></a><span data-ttu-id="cf217-229">Parent</span><span class="sxs-lookup"><span data-stu-id="cf217-229">Parent</span></span>  

[<span data-ttu-id="cf217-230">/users/xuid({xuid})/outbox</span><span class="sxs-lookup"><span data-stu-id="cf217-230">/users/xuid({xuid})/outbox</span></span>](uri-usersxuidoutbox.md)


<a id="ID4EZFAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a><span data-ttu-id="cf217-231">参照[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)</span><span class="sxs-lookup"><span data-stu-id="cf217-231">Reference  [Standard HTTP status codes](../../additional/httpstatuscodes.md)</span></span>
