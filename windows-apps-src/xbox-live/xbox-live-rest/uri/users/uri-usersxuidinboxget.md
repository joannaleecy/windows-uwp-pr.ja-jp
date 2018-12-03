---
title: GET (/users/xuid({xuid})/inbox)
assetID: c603910d-b430-f157-2634-ceddea89f2bd
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxget.html
description: " GET (/users/xuid({xuid})/inbox)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 05f75510f15f6e6c5f1b1673673428c00f7a6c16
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8348501"
---
# <a name="get-usersxuidxuidinbox"></a><span data-ttu-id="05adb-104">GET (/users/xuid({xuid})/inbox)</span><span class="sxs-lookup"><span data-stu-id="05adb-104">GET (/users/xuid({xuid})/inbox)</span></span>
<span data-ttu-id="05adb-105">サービスから指定したメッセージの概要をユーザー数を取得します。</span><span class="sxs-lookup"><span data-stu-id="05adb-105">Retrieves a specified number of user message summaries from the service.</span></span>
<span data-ttu-id="05adb-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="05adb-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>

  * [<span data-ttu-id="05adb-107">注釈</span><span class="sxs-lookup"><span data-stu-id="05adb-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="05adb-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="05adb-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="05adb-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="05adb-109">Query string parameters</span></span>](#ID4EIC)
  * [<span data-ttu-id="05adb-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="05adb-110">Authorization</span></span>](#ID4EGE)
  * [<span data-ttu-id="05adb-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="05adb-111">Effect of privacy settings on resource</span></span>](#ID4ETE)
  * [<span data-ttu-id="05adb-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="05adb-112">HTTP status codes</span></span>](#ID4E5E)
  * [<span data-ttu-id="05adb-113">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="05adb-113">JavaScript Object Notation (JSON) Response</span></span>](#ID4EMH)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="05adb-114">注釈</span><span class="sxs-lookup"><span data-stu-id="05adb-114">Remarks</span></span>

<span data-ttu-id="05adb-115">ユーザーのメッセージ要約にはには、メッセージの件名のみが含まれています。</span><span class="sxs-lookup"><span data-stu-id="05adb-115">A user message summary contains only the message subject.</span></span> <span data-ttu-id="05adb-116">ユーザーが生成したメッセージの場合、これは、現在のメッセージ テキストは、最初の 20 文字。</span><span class="sxs-lookup"><span data-stu-id="05adb-116">For user-generated messages, this is currently the first 20 characters of the message text.</span></span> <span data-ttu-id="05adb-117">システム メッセージは、"LIVE System"などの別のサブジェクトを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="05adb-117">System messages may provide an alternate subject, such as "LIVE System".</span></span>

<span data-ttu-id="05adb-118">メッセージが送信された注文の逆の順序で返されますつまり、新しいメッセージは、最初に返されます。</span><span class="sxs-lookup"><span data-stu-id="05adb-118">Messages are returned in the reverse of the order they were sent; that is, newer messages are returned first.</span></span>

<span data-ttu-id="05adb-119">この API は、サポートのみのコンテンツの種類は、"アプリケーション/json"、呼び出しごとの HTTP ヘッダーのために必要です。</span><span class="sxs-lookup"><span data-stu-id="05adb-119">The only content type this API supports is "application/json", which is required in the HTTP headers of each call.</span></span>

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="05adb-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="05adb-120">URI parameters</span></span>

| <span data-ttu-id="05adb-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="05adb-121">Parameter</span></span>| <span data-ttu-id="05adb-122">型</span><span class="sxs-lookup"><span data-stu-id="05adb-122">Type</span></span>| <span data-ttu-id="05adb-123">説明</span><span class="sxs-lookup"><span data-stu-id="05adb-123">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="05adb-124">xuid</span><span class="sxs-lookup"><span data-stu-id="05adb-124">xuid</span></span>| <span data-ttu-id="05adb-125">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="05adb-125">unsigned 64-bit integer</span></span>| <span data-ttu-id="05adb-126">Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。</span><span class="sxs-lookup"><span data-stu-id="05adb-126">The Xbox User ID (XUID) of the player who is making the request.</span></span>|

<a id="ID4EIC"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="05adb-127">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="05adb-127">Query string parameters</span></span>

| <span data-ttu-id="05adb-128">プロパティ</span><span class="sxs-lookup"><span data-stu-id="05adb-128">Property</span></span>| <span data-ttu-id="05adb-129">型</span><span class="sxs-lookup"><span data-stu-id="05adb-129">Type</span></span>| <span data-ttu-id="05adb-130">最大長</span><span class="sxs-lookup"><span data-stu-id="05adb-130">Maximum Length</span></span>| <span data-ttu-id="05adb-131">注釈</span><span class="sxs-lookup"><span data-stu-id="05adb-131">Remarks</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="05adb-132">maxItems</span><span class="sxs-lookup"><span data-stu-id="05adb-132">maxItems</span></span>| <span data-ttu-id="05adb-133">int</span><span class="sxs-lookup"><span data-stu-id="05adb-133">int</span></span>| <span data-ttu-id="05adb-134">100</span><span class="sxs-lookup"><span data-stu-id="05adb-134">100</span></span>| <span data-ttu-id="05adb-135">メッセージの最大数が返されます。</span><span class="sxs-lookup"><span data-stu-id="05adb-135">Maximum number of messages returned.</span></span>|
| <span data-ttu-id="05adb-136">continuationToken</span><span class="sxs-lookup"><span data-stu-id="05adb-136">continuationToken</span></span>| <span data-ttu-id="05adb-137">string</span><span class="sxs-lookup"><span data-stu-id="05adb-137">string</span></span>|  | <span data-ttu-id="05adb-138">以前の列挙呼び出し; で返される文字列列挙値を続行するために使用します。</span><span class="sxs-lookup"><span data-stu-id="05adb-138">String returned in a previous enumeration call; used to continue enumeration.</span></span>|
| <span data-ttu-id="05adb-139">skipItems</span><span class="sxs-lookup"><span data-stu-id="05adb-139">skipItems</span></span>| <span data-ttu-id="05adb-140">int</span><span class="sxs-lookup"><span data-stu-id="05adb-140">int</span></span>| <span data-ttu-id="05adb-141">100</span><span class="sxs-lookup"><span data-stu-id="05adb-141">100</span></span>| <span data-ttu-id="05adb-142">をスキップするメッセージの数continuationToken が存在する場合は無視されます。</span><span class="sxs-lookup"><span data-stu-id="05adb-142">Number of messages to skip; ignored if continuationToken is present.</span></span>|

<a id="ID4EGE"></a>


## <a name="authorization"></a><span data-ttu-id="05adb-143">Authorization</span><span class="sxs-lookup"><span data-stu-id="05adb-143">Authorization</span></span>

<span data-ttu-id="05adb-144">独自のユーザーがユーザーのメッセージの概要を取得する要求が必要です。</span><span class="sxs-lookup"><span data-stu-id="05adb-144">You must have your own user claim to retrieve a user message summary.</span></span>

<a id="ID4ETE"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="05adb-145">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="05adb-145">Effect of privacy settings on resource</span></span>

<span data-ttu-id="05adb-146">のみユーザー メッセージを列挙することができます。</span><span class="sxs-lookup"><span data-stu-id="05adb-146">Only you can enumerate your own user messages.</span></span>

<a id="ID4E5E"></a>


## <a name="http-status-codes"></a><span data-ttu-id="05adb-147">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="05adb-147">HTTP status codes</span></span>

<span data-ttu-id="05adb-148">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="05adb-148">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="05adb-149">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="05adb-149">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="05adb-150">コード</span><span class="sxs-lookup"><span data-stu-id="05adb-150">Code</span></span>| <span data-ttu-id="05adb-151">説明</span><span class="sxs-lookup"><span data-stu-id="05adb-151">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="05adb-152">200</span><span class="sxs-lookup"><span data-stu-id="05adb-152">200</span></span>| <span data-ttu-id="05adb-153">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="05adb-153">The request was successful.</span></span>|
| <span data-ttu-id="05adb-154">400</span><span class="sxs-lookup"><span data-stu-id="05adb-154">400</span></span>| <span data-ttu-id="05adb-155">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="05adb-155">Service could not understand malformed request.</span></span> <span data-ttu-id="05adb-156">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="05adb-156">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="05adb-157">403</span><span class="sxs-lookup"><span data-stu-id="05adb-157">403</span></span>| <span data-ttu-id="05adb-158">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="05adb-158">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="05adb-159">404</span><span class="sxs-lookup"><span data-stu-id="05adb-159">404</span></span>| <span data-ttu-id="05adb-160">有効な XUID が URI ではありません。</span><span class="sxs-lookup"><span data-stu-id="05adb-160">A valid XUID is missing in the URI.</span></span>|
| <span data-ttu-id="05adb-161">409</span><span class="sxs-lookup"><span data-stu-id="05adb-161">409</span></span>| <span data-ttu-id="05adb-162">基になるコレクションでは、渡された継続トークンに基づいて変更されます。</span><span class="sxs-lookup"><span data-stu-id="05adb-162">The underlying collection changed based on the continuation token that was passed.</span></span>|
| <span data-ttu-id="05adb-163">416</span><span class="sxs-lookup"><span data-stu-id="05adb-163">416</span></span>| <span data-ttu-id="05adb-164">スキップされる項目の数は、利用可能な項目の数を超えています。</span><span class="sxs-lookup"><span data-stu-id="05adb-164">The number of items to skip is larger than the number of available items.</span></span>|
| <span data-ttu-id="05adb-165">500</span><span class="sxs-lookup"><span data-stu-id="05adb-165">500</span></span>| <span data-ttu-id="05adb-166">サーバー側の一般的なエラーです。</span><span class="sxs-lookup"><span data-stu-id="05adb-166">General server-side error.</span></span>|

<a id="ID4EMH"></a>


## <a name="javascript-object-notation-json-response"></a><span data-ttu-id="05adb-167">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="05adb-167">JavaScript Object Notation (JSON) Response</span></span>

<span data-ttu-id="05adb-168">正常に呼び出されると、サービスは、JSON 形式での結果データを返します。</span><span class="sxs-lookup"><span data-stu-id="05adb-168">If called successfully, the service returns the results data in a JSON format.</span></span>

| <span data-ttu-id="05adb-169">プロパティ</span><span class="sxs-lookup"><span data-stu-id="05adb-169">Property</span></span>| <span data-ttu-id="05adb-170">型</span><span class="sxs-lookup"><span data-stu-id="05adb-170">Type</span></span>| <span data-ttu-id="05adb-171">最大長</span><span class="sxs-lookup"><span data-stu-id="05adb-171">Maximum Length</span></span>| <span data-ttu-id="05adb-172">注釈</span><span class="sxs-lookup"><span data-stu-id="05adb-172">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="05adb-173">結果</span><span class="sxs-lookup"><span data-stu-id="05adb-173">results</span></span>| <span data-ttu-id="05adb-174">メッセージの</span><span class="sxs-lookup"><span data-stu-id="05adb-174">Message[]</span></span>| <span data-ttu-id="05adb-175">100</span><span class="sxs-lookup"><span data-stu-id="05adb-175">100</span></span>| <span data-ttu-id="05adb-176">ユーザーのメッセージの配列</span><span class="sxs-lookup"><span data-stu-id="05adb-176">Array of user messages</span></span>|
| <span data-ttu-id="05adb-177">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="05adb-177">pagingInfo</span></span>| <span data-ttu-id="05adb-178">PagingInfo</span><span class="sxs-lookup"><span data-stu-id="05adb-178">PagingInfo</span></span>|  | <span data-ttu-id="05adb-179">現在の結果セットのページング情報</span><span class="sxs-lookup"><span data-stu-id="05adb-179">Paging information for the current set of results</span></span>|

#### <a name="message"></a><span data-ttu-id="05adb-180">メッセージ</span><span class="sxs-lookup"><span data-stu-id="05adb-180">Message</span></span>

| <span data-ttu-id="05adb-181">プロパティ</span><span class="sxs-lookup"><span data-stu-id="05adb-181">Property</span></span>| <span data-ttu-id="05adb-182">型</span><span class="sxs-lookup"><span data-stu-id="05adb-182">Type</span></span>| <span data-ttu-id="05adb-183">最大長</span><span class="sxs-lookup"><span data-stu-id="05adb-183">Maximum Length</span></span>| <span data-ttu-id="05adb-184">注釈</span><span class="sxs-lookup"><span data-stu-id="05adb-184">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="05adb-185">header</span><span class="sxs-lookup"><span data-stu-id="05adb-185">header</span></span>| <span data-ttu-id="05adb-186">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="05adb-186">Header</span></span>|  | <span data-ttu-id="05adb-187">ユーザーのメッセージのヘッダー</span><span class="sxs-lookup"><span data-stu-id="05adb-187">User message header</span></span>|
| <span data-ttu-id="05adb-188">messageSummary</span><span class="sxs-lookup"><span data-stu-id="05adb-188">messageSummary</span></span>| <span data-ttu-id="05adb-189">string</span><span class="sxs-lookup"><span data-stu-id="05adb-189">string</span></span>| <span data-ttu-id="05adb-190">20</span><span class="sxs-lookup"><span data-stu-id="05adb-190">20</span></span>| <span data-ttu-id="05adb-191">UTF-8 です。通常はメッセージの最初の 20 文字</span><span class="sxs-lookup"><span data-stu-id="05adb-191">UTF-8; usually first 20 characters of message</span></span>|

#### <a name="header"></a><span data-ttu-id="05adb-192">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="05adb-192">Header</span></span>

| <span data-ttu-id="05adb-193">プロパティ</span><span class="sxs-lookup"><span data-stu-id="05adb-193">Property</span></span>| <span data-ttu-id="05adb-194">型</span><span class="sxs-lookup"><span data-stu-id="05adb-194">Type</span></span>| <span data-ttu-id="05adb-195">最大長</span><span class="sxs-lookup"><span data-stu-id="05adb-195">Maximum Length</span></span>| <span data-ttu-id="05adb-196">注釈</span><span class="sxs-lookup"><span data-stu-id="05adb-196">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="05adb-197">id</span><span class="sxs-lookup"><span data-stu-id="05adb-197">id</span></span>| <span data-ttu-id="05adb-198">string</span><span class="sxs-lookup"><span data-stu-id="05adb-198">string</span></span>| <span data-ttu-id="05adb-199">50</span><span class="sxs-lookup"><span data-stu-id="05adb-199">50</span></span>| <span data-ttu-id="05adb-200">メッセージ id、メッセージの詳細を取得またはメッセージを削除するために使用します。</span><span class="sxs-lookup"><span data-stu-id="05adb-200">Message identifier, used for retrieving message details or deleting messages.</span></span>|
| <span data-ttu-id="05adb-201">isRead</span><span class="sxs-lookup"><span data-stu-id="05adb-201">isRead</span></span>| <span data-ttu-id="05adb-202">bool</span><span class="sxs-lookup"><span data-stu-id="05adb-202">bool</span></span>|  | <span data-ttu-id="05adb-203">ユーザーがメッセージの詳細を既に「ことを示すしますフラグ。</span><span class="sxs-lookup"><span data-stu-id="05adb-203">Flag indicating that the user has already read the message details.</span></span>|
| <span data-ttu-id="05adb-204">送信</span><span class="sxs-lookup"><span data-stu-id="05adb-204">sent</span></span>| <span data-ttu-id="05adb-205">DateTime</span><span class="sxs-lookup"><span data-stu-id="05adb-205">DateTime</span></span>|  | <span data-ttu-id="05adb-206">UTC 日付と時刻は、メッセージが送信されました。</span><span class="sxs-lookup"><span data-stu-id="05adb-206">UTC date and time the message was sent.</span></span> <span data-ttu-id="05adb-207">(サービスによって提供されます)。</span><span class="sxs-lookup"><span data-stu-id="05adb-207">(Provided by the service.)</span></span>|
| <span data-ttu-id="05adb-208">有効期限</span><span class="sxs-lookup"><span data-stu-id="05adb-208">expiration</span></span>| <span data-ttu-id="05adb-209">DateTime</span><span class="sxs-lookup"><span data-stu-id="05adb-209">DateTime</span></span>|  | <span data-ttu-id="05adb-210">UTC 日付と時刻は、有効期限が切れるメッセージ。</span><span class="sxs-lookup"><span data-stu-id="05adb-210">UTC date and time the message expires.</span></span> <span data-ttu-id="05adb-211">(すべてのメッセージによって、将来的に決定する、最長有効期間がある)。</span><span class="sxs-lookup"><span data-stu-id="05adb-211">(All messages have a maximum lifetime, to be determined in the future.)</span></span>|
| <span data-ttu-id="05adb-212">メッセージの種類</span><span class="sxs-lookup"><span data-stu-id="05adb-212">messageType</span></span>| <span data-ttu-id="05adb-213">string</span><span class="sxs-lookup"><span data-stu-id="05adb-213">string</span></span>| <span data-ttu-id="05adb-214">50</span><span class="sxs-lookup"><span data-stu-id="05adb-214">50</span></span>| <span data-ttu-id="05adb-215">メッセージの種類: ユーザー、システム、FriendRequest、ビデオ、QuickChat、VideoChat、PartyChat、タイトル、GameInvite します。</span><span class="sxs-lookup"><span data-stu-id="05adb-215">Message types: User, System, FriendRequest, Video, QuickChat, VideoChat, PartyChat, Title, GameInvite.</span></span>|
| <span data-ttu-id="05adb-216">senderXuid</span><span class="sxs-lookup"><span data-stu-id="05adb-216">senderXuid</span></span>| <span data-ttu-id="05adb-217">ulong</span><span class="sxs-lookup"><span data-stu-id="05adb-217">ulong</span></span>|  | <span data-ttu-id="05adb-218">送信者の XUID です。</span><span class="sxs-lookup"><span data-stu-id="05adb-218">XUID of sender.</span></span>|
| <span data-ttu-id="05adb-219">送信者</span><span class="sxs-lookup"><span data-stu-id="05adb-219">sender</span></span>| <span data-ttu-id="05adb-220">string</span><span class="sxs-lookup"><span data-stu-id="05adb-220">string</span></span>| <span data-ttu-id="05adb-221">15</span><span class="sxs-lookup"><span data-stu-id="05adb-221">15</span></span>| <span data-ttu-id="05adb-222">送信者のゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="05adb-222">Gamertag of sender.</span></span>|
| <span data-ttu-id="05adb-223">hasAudio</span><span class="sxs-lookup"><span data-stu-id="05adb-223">hasAudio</span></span>| <span data-ttu-id="05adb-224">bool</span><span class="sxs-lookup"><span data-stu-id="05adb-224">bool</span></span>|  | <span data-ttu-id="05adb-225">かどうか、メッセージには、オーディオ (声) 添付ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="05adb-225">Whether the message has an audio (voice) attachment.</span></span>|
| <span data-ttu-id="05adb-226">hasPhoto</span><span class="sxs-lookup"><span data-stu-id="05adb-226">hasPhoto</span></span>| <span data-ttu-id="05adb-227">bool</span><span class="sxs-lookup"><span data-stu-id="05adb-227">bool</span></span>|  | <span data-ttu-id="05adb-228">メッセージに写真の添付ファイルかどうか。</span><span class="sxs-lookup"><span data-stu-id="05adb-228">Whether the message has a photo attachment.</span></span>|
| <span data-ttu-id="05adb-229">hasText</span><span class="sxs-lookup"><span data-stu-id="05adb-229">hasText</span></span>| <span data-ttu-id="05adb-230">bool</span><span class="sxs-lookup"><span data-stu-id="05adb-230">bool</span></span>|  | <span data-ttu-id="05adb-231">かどうか、メッセージには、テキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="05adb-231">Whether the message contains text.</span></span>|

#### <a name="paging-info"></a><span data-ttu-id="05adb-232">ページング情報</span><span class="sxs-lookup"><span data-stu-id="05adb-232">Paging Info</span></span>

| <span data-ttu-id="05adb-233">プロパティ</span><span class="sxs-lookup"><span data-stu-id="05adb-233">Property</span></span>| <span data-ttu-id="05adb-234">型</span><span class="sxs-lookup"><span data-stu-id="05adb-234">Type</span></span>| <span data-ttu-id="05adb-235">最大長</span><span class="sxs-lookup"><span data-stu-id="05adb-235">Maximum Length</span></span>| <span data-ttu-id="05adb-236">注釈</span><span class="sxs-lookup"><span data-stu-id="05adb-236">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="05adb-237">continuationToken</span><span class="sxs-lookup"><span data-stu-id="05adb-237">continuationToken</span></span>| <span data-ttu-id="05adb-238">string</span><span class="sxs-lookup"><span data-stu-id="05adb-238">string</span></span>| <span data-ttu-id="05adb-239">100</span><span class="sxs-lookup"><span data-stu-id="05adb-239">100</span></span>| <span data-ttu-id="05adb-240">必要に応じてサーバーによって返されます。</span><span class="sxs-lookup"><span data-stu-id="05adb-240">Optionally returned by server.</span></span> <span data-ttu-id="05adb-241">列挙を続行するそれ以降の呼び出しを許可します。</span><span class="sxs-lookup"><span data-stu-id="05adb-241">Allows later calls to continue enumeration.</span></span>|
| <span data-ttu-id="05adb-242">totalItems</span><span class="sxs-lookup"><span data-stu-id="05adb-242">totalItems</span></span>| <span data-ttu-id="05adb-243">int</span><span class="sxs-lookup"><span data-stu-id="05adb-243">int</span></span>|  | <span data-ttu-id="05adb-244">受信トレイのメッセージの合計数。</span><span class="sxs-lookup"><span data-stu-id="05adb-244">Total number of messages in inbox.</span></span>|

#### <a name="sample-response"></a><span data-ttu-id="05adb-245">応答の例</span><span class="sxs-lookup"><span data-stu-id="05adb-245">Sample response</span></span>

```cpp
{
          "results":
          [
            {
              "header":
              {
                "expiration":"2011-10-11T23:59:59.9999999",
                "id":"opaqueBlobOfText",
                "messageType":"User",
                "isRead":false,
                "senderXuid":"123456789",
                "sender":"Striker",
                "sent":"2011-05-08T17:30:00Z",
                "hasAudio":false,
                "hasPhoto":false,
                "hasText":true
              },
            "messageSummary":"first 20 chars"
          },
          ...
        ],
        "pagingInfo":
          {
          "continuationToken":"opaqueBlobOfText"
          "totalItems":5,
          }
        }

```

#### <a name="error-response"></a><span data-ttu-id="05adb-246">エラー応答</span><span class="sxs-lookup"><span data-stu-id="05adb-246">Error Response</span></span>

<span data-ttu-id="05adb-247">エラーの場合、サービスはサービスの環境から値を含めることができますが、全て、errorResponse オブジェクトを返すことがあります。</span><span class="sxs-lookup"><span data-stu-id="05adb-247">In case of error, the service may return an errorResponse object, which may contain values from the environment of the service.</span></span>

| <span data-ttu-id="05adb-248">プロパティ</span><span class="sxs-lookup"><span data-stu-id="05adb-248">Property</span></span>| <span data-ttu-id="05adb-249">型</span><span class="sxs-lookup"><span data-stu-id="05adb-249">Type</span></span>| <span data-ttu-id="05adb-250">説明</span><span class="sxs-lookup"><span data-stu-id="05adb-250">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="05adb-251">errorSource</span><span class="sxs-lookup"><span data-stu-id="05adb-251">errorSource</span></span>| <span data-ttu-id="05adb-252">string</span><span class="sxs-lookup"><span data-stu-id="05adb-252">string</span></span>| <span data-ttu-id="05adb-253">エラーが発生した場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="05adb-253">An indication of where the error originated.</span></span>|
| <span data-ttu-id="05adb-254">errorCode</span><span class="sxs-lookup"><span data-stu-id="05adb-254">errorCode</span></span>| <span data-ttu-id="05adb-255">int</span><span class="sxs-lookup"><span data-stu-id="05adb-255">int</span></span>| <span data-ttu-id="05adb-256">(Null にすることができます)、エラーに関連付けられている数値コードです。</span><span class="sxs-lookup"><span data-stu-id="05adb-256">Numeric code associated with the error (can be null).</span></span>|
| <span data-ttu-id="05adb-257">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="05adb-257">errorMessage</span></span>| <span data-ttu-id="05adb-258">string</span><span class="sxs-lookup"><span data-stu-id="05adb-258">string</span></span>| <span data-ttu-id="05adb-259">詳細を表示するように構成する場合のエラーの説明します。</span><span class="sxs-lookup"><span data-stu-id="05adb-259">Details of the error if configured to show details.</span></span>|

<a id="ID4EIKAC"></a>


## <a name="see-also"></a><span data-ttu-id="05adb-260">関連項目</span><span class="sxs-lookup"><span data-stu-id="05adb-260">See also</span></span>

<a id="ID4EKKAC"></a>


##### <a name="parent"></a><span data-ttu-id="05adb-261">Parent</span><span class="sxs-lookup"><span data-stu-id="05adb-261">Parent</span></span>  

[<span data-ttu-id="05adb-262">/users/xuid({xuid})/inbox</span><span class="sxs-lookup"><span data-stu-id="05adb-262">/users/xuid({xuid})/inbox</span></span>](uri-usersxuidinbox.md)


<a id="ID4EWKAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a><span data-ttu-id="05adb-263">参照[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)</span><span class="sxs-lookup"><span data-stu-id="05adb-263">Reference  [Standard HTTP status codes](../../additional/httpstatuscodes.md)</span></span>
