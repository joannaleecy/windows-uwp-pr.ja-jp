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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632247"
---
# <a name="get-usersxuidxuidinbox"></a><span data-ttu-id="a0f08-104">GET (/users/xuid({xuid})/inbox)</span><span class="sxs-lookup"><span data-stu-id="a0f08-104">GET (/users/xuid({xuid})/inbox)</span></span>
<span data-ttu-id="a0f08-105">サービスから、指定された数のユーザー メッセージの概要を取得します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-105">Retrieves a specified number of user message summaries from the service.</span></span>
<span data-ttu-id="a0f08-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>

  * [<span data-ttu-id="a0f08-107">注釈</span><span class="sxs-lookup"><span data-stu-id="a0f08-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="a0f08-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0f08-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="a0f08-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0f08-109">Query string parameters</span></span>](#ID4EIC)
  * [<span data-ttu-id="a0f08-110">承認</span><span class="sxs-lookup"><span data-stu-id="a0f08-110">Authorization</span></span>](#ID4EGE)
  * [<span data-ttu-id="a0f08-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="a0f08-111">Effect of privacy settings on resource</span></span>](#ID4ETE)
  * [<span data-ttu-id="a0f08-112">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a0f08-112">HTTP status codes</span></span>](#ID4E5E)
  * [<span data-ttu-id="a0f08-113">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="a0f08-113">JavaScript Object Notation (JSON) Response</span></span>](#ID4EMH)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="a0f08-114">注釈</span><span class="sxs-lookup"><span data-stu-id="a0f08-114">Remarks</span></span>

<span data-ttu-id="a0f08-115">ユーザー メッセージ概要にはには、メッセージの件名のみが含まれています。</span><span class="sxs-lookup"><span data-stu-id="a0f08-115">A user message summary contains only the message subject.</span></span> <span data-ttu-id="a0f08-116">ユーザーが生成したメッセージの場合、これは現在メッセージ テキストの最初の 20 文字です。</span><span class="sxs-lookup"><span data-stu-id="a0f08-116">For user-generated messages, this is currently the first 20 characters of the message text.</span></span> <span data-ttu-id="a0f08-117">システム メッセージは、「ライブ システム」などの代わりのサブジェクトを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="a0f08-117">System messages may provide an alternate subject, such as "LIVE System".</span></span>

<span data-ttu-id="a0f08-118">メッセージが送信された順序の逆の順序で返されますつまり、新しいメッセージが最初に返されます。</span><span class="sxs-lookup"><span data-stu-id="a0f08-118">Messages are returned in the reverse of the order they were sent; that is, newer messages are returned first.</span></span>

<span data-ttu-id="a0f08-119">この API はサポートのみコンテンツの種類は、"application/json"に必要な各呼び出しの HTTP ヘッダーが。</span><span class="sxs-lookup"><span data-stu-id="a0f08-119">The only content type this API supports is "application/json", which is required in the HTTP headers of each call.</span></span>

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="a0f08-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0f08-120">URI parameters</span></span>

| <span data-ttu-id="a0f08-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0f08-121">Parameter</span></span>| <span data-ttu-id="a0f08-122">種類</span><span class="sxs-lookup"><span data-stu-id="a0f08-122">Type</span></span>| <span data-ttu-id="a0f08-123">説明</span><span class="sxs-lookup"><span data-stu-id="a0f08-123">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="a0f08-124">xuid</span><span class="sxs-lookup"><span data-stu-id="a0f08-124">xuid</span></span>| <span data-ttu-id="a0f08-125">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="a0f08-125">unsigned 64-bit integer</span></span>| <span data-ttu-id="a0f08-126">Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。</span><span class="sxs-lookup"><span data-stu-id="a0f08-126">The Xbox User ID (XUID) of the player who is making the request.</span></span>|

<a id="ID4EIC"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="a0f08-127">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0f08-127">Query string parameters</span></span>

| <span data-ttu-id="a0f08-128">プロパティ</span><span class="sxs-lookup"><span data-stu-id="a0f08-128">Property</span></span>| <span data-ttu-id="a0f08-129">種類</span><span class="sxs-lookup"><span data-stu-id="a0f08-129">Type</span></span>| <span data-ttu-id="a0f08-130">最大長</span><span class="sxs-lookup"><span data-stu-id="a0f08-130">Maximum Length</span></span>| <span data-ttu-id="a0f08-131">注釈</span><span class="sxs-lookup"><span data-stu-id="a0f08-131">Remarks</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a0f08-132">maxItems</span><span class="sxs-lookup"><span data-stu-id="a0f08-132">maxItems</span></span>| <span data-ttu-id="a0f08-133">int</span><span class="sxs-lookup"><span data-stu-id="a0f08-133">int</span></span>| <span data-ttu-id="a0f08-134">100</span><span class="sxs-lookup"><span data-stu-id="a0f08-134">100</span></span>| <span data-ttu-id="a0f08-135">メッセージの最大数が返されます。</span><span class="sxs-lookup"><span data-stu-id="a0f08-135">Maximum number of messages returned.</span></span>|
| <span data-ttu-id="a0f08-136">continuationToken</span><span class="sxs-lookup"><span data-stu-id="a0f08-136">continuationToken</span></span>| <span data-ttu-id="a0f08-137">string</span><span class="sxs-lookup"><span data-stu-id="a0f08-137">string</span></span>|  | <span data-ttu-id="a0f08-138">前列挙体の呼び出しで返される文字列列挙を続行するために使用します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-138">String returned in a previous enumeration call; used to continue enumeration.</span></span>|
| <span data-ttu-id="a0f08-139">skipItems</span><span class="sxs-lookup"><span data-stu-id="a0f08-139">skipItems</span></span>| <span data-ttu-id="a0f08-140">int</span><span class="sxs-lookup"><span data-stu-id="a0f08-140">int</span></span>| <span data-ttu-id="a0f08-141">100</span><span class="sxs-lookup"><span data-stu-id="a0f08-141">100</span></span>| <span data-ttu-id="a0f08-142">をスキップするメッセージの数continuationToken が存在する場合は無視されます。</span><span class="sxs-lookup"><span data-stu-id="a0f08-142">Number of messages to skip; ignored if continuationToken is present.</span></span>|

<a id="ID4EGE"></a>


## <a name="authorization"></a><span data-ttu-id="a0f08-143">Authorization</span><span class="sxs-lookup"><span data-stu-id="a0f08-143">Authorization</span></span>

<span data-ttu-id="a0f08-144">ユーザー メッセージの概要を取得する要求、独自のユーザーが必要です。</span><span class="sxs-lookup"><span data-stu-id="a0f08-144">You must have your own user claim to retrieve a user message summary.</span></span>

<a id="ID4ETE"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="a0f08-145">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="a0f08-145">Effect of privacy settings on resource</span></span>

<span data-ttu-id="a0f08-146">のみ、独自のユーザー メッセージを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="a0f08-146">Only you can enumerate your own user messages.</span></span>

<a id="ID4E5E"></a>


## <a name="http-status-codes"></a><span data-ttu-id="a0f08-147">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a0f08-147">HTTP status codes</span></span>

<span data-ttu-id="a0f08-148">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-148">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="a0f08-149">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-149">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="a0f08-150">コード</span><span class="sxs-lookup"><span data-stu-id="a0f08-150">Code</span></span>| <span data-ttu-id="a0f08-151">説明</span><span class="sxs-lookup"><span data-stu-id="a0f08-151">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a0f08-152">200</span><span class="sxs-lookup"><span data-stu-id="a0f08-152">200</span></span>| <span data-ttu-id="a0f08-153">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-153">The request was successful.</span></span>|
| <span data-ttu-id="a0f08-154">400</span><span class="sxs-lookup"><span data-stu-id="a0f08-154">400</span></span>| <span data-ttu-id="a0f08-155">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="a0f08-155">Service could not understand malformed request.</span></span> <span data-ttu-id="a0f08-156">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="a0f08-156">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="a0f08-157">403</span><span class="sxs-lookup"><span data-stu-id="a0f08-157">403</span></span>| <span data-ttu-id="a0f08-158">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="a0f08-158">The request is not allowed for the user or service.</span></span>|
| <span data-ttu-id="a0f08-159">404</span><span class="sxs-lookup"><span data-stu-id="a0f08-159">404</span></span>| <span data-ttu-id="a0f08-160">有効な XUID が URI ではありません。</span><span class="sxs-lookup"><span data-stu-id="a0f08-160">A valid XUID is missing in the URI.</span></span>|
| <span data-ttu-id="a0f08-161">409</span><span class="sxs-lookup"><span data-stu-id="a0f08-161">409</span></span>| <span data-ttu-id="a0f08-162">渡された継続トークンに基づいて、基になるコレクションを変更します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-162">The underlying collection changed based on the continuation token that was passed.</span></span>|
| <span data-ttu-id="a0f08-163">416</span><span class="sxs-lookup"><span data-stu-id="a0f08-163">416</span></span>| <span data-ttu-id="a0f08-164">スキップする項目の数は、利用可能な項目の数を超えています。</span><span class="sxs-lookup"><span data-stu-id="a0f08-164">The number of items to skip is larger than the number of available items.</span></span>|
| <span data-ttu-id="a0f08-165">500</span><span class="sxs-lookup"><span data-stu-id="a0f08-165">500</span></span>| <span data-ttu-id="a0f08-166">サーバー側の一般エラーです。</span><span class="sxs-lookup"><span data-stu-id="a0f08-166">General server-side error.</span></span>|

<a id="ID4EMH"></a>


## <a name="javascript-object-notation-json-response"></a><span data-ttu-id="a0f08-167">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="a0f08-167">JavaScript Object Notation (JSON) Response</span></span>

<span data-ttu-id="a0f08-168">正常に呼び出されると、サービスは、JSON 形式で結果データを返します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-168">If called successfully, the service returns the results data in a JSON format.</span></span>

| <span data-ttu-id="a0f08-169">プロパティ</span><span class="sxs-lookup"><span data-stu-id="a0f08-169">Property</span></span>| <span data-ttu-id="a0f08-170">種類</span><span class="sxs-lookup"><span data-stu-id="a0f08-170">Type</span></span>| <span data-ttu-id="a0f08-171">最大長</span><span class="sxs-lookup"><span data-stu-id="a0f08-171">Maximum Length</span></span>| <span data-ttu-id="a0f08-172">注釈</span><span class="sxs-lookup"><span data-stu-id="a0f08-172">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="a0f08-173">結果</span><span class="sxs-lookup"><span data-stu-id="a0f08-173">results</span></span>| <span data-ttu-id="a0f08-174">メッセージの</span><span class="sxs-lookup"><span data-stu-id="a0f08-174">Message[]</span></span>| <span data-ttu-id="a0f08-175">100</span><span class="sxs-lookup"><span data-stu-id="a0f08-175">100</span></span>| <span data-ttu-id="a0f08-176">ユーザー メッセージの配列</span><span class="sxs-lookup"><span data-stu-id="a0f08-176">Array of user messages</span></span>|
| <span data-ttu-id="a0f08-177">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="a0f08-177">pagingInfo</span></span>| <span data-ttu-id="a0f08-178">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="a0f08-178">PagingInfo</span></span>|  | <span data-ttu-id="a0f08-179">現在の結果セットのページング情報</span><span class="sxs-lookup"><span data-stu-id="a0f08-179">Paging information for the current set of results</span></span>|

#### <a name="message"></a><span data-ttu-id="a0f08-180">メッセージ</span><span class="sxs-lookup"><span data-stu-id="a0f08-180">Message</span></span>

| <span data-ttu-id="a0f08-181">プロパティ</span><span class="sxs-lookup"><span data-stu-id="a0f08-181">Property</span></span>| <span data-ttu-id="a0f08-182">種類</span><span class="sxs-lookup"><span data-stu-id="a0f08-182">Type</span></span>| <span data-ttu-id="a0f08-183">最大長</span><span class="sxs-lookup"><span data-stu-id="a0f08-183">Maximum Length</span></span>| <span data-ttu-id="a0f08-184">注釈</span><span class="sxs-lookup"><span data-stu-id="a0f08-184">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="a0f08-185">header</span><span class="sxs-lookup"><span data-stu-id="a0f08-185">header</span></span>| <span data-ttu-id="a0f08-186">Header</span><span class="sxs-lookup"><span data-stu-id="a0f08-186">Header</span></span>|  | <span data-ttu-id="a0f08-187">ユーザー メッセージのヘッダー</span><span class="sxs-lookup"><span data-stu-id="a0f08-187">User message header</span></span>|
| <span data-ttu-id="a0f08-188">messageSummary</span><span class="sxs-lookup"><span data-stu-id="a0f08-188">messageSummary</span></span>| <span data-ttu-id="a0f08-189">string</span><span class="sxs-lookup"><span data-stu-id="a0f08-189">string</span></span>| <span data-ttu-id="a0f08-190">20</span><span class="sxs-lookup"><span data-stu-id="a0f08-190">20</span></span>| <span data-ttu-id="a0f08-191">UTF-8 です。通常は最初の 20 文字のメッセージ</span><span class="sxs-lookup"><span data-stu-id="a0f08-191">UTF-8; usually first 20 characters of message</span></span>|

#### <a name="header"></a><span data-ttu-id="a0f08-192">Header</span><span class="sxs-lookup"><span data-stu-id="a0f08-192">Header</span></span>

| <span data-ttu-id="a0f08-193">プロパティ</span><span class="sxs-lookup"><span data-stu-id="a0f08-193">Property</span></span>| <span data-ttu-id="a0f08-194">種類</span><span class="sxs-lookup"><span data-stu-id="a0f08-194">Type</span></span>| <span data-ttu-id="a0f08-195">最大長</span><span class="sxs-lookup"><span data-stu-id="a0f08-195">Maximum Length</span></span>| <span data-ttu-id="a0f08-196">注釈</span><span class="sxs-lookup"><span data-stu-id="a0f08-196">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="a0f08-197">id</span><span class="sxs-lookup"><span data-stu-id="a0f08-197">id</span></span>| <span data-ttu-id="a0f08-198">string</span><span class="sxs-lookup"><span data-stu-id="a0f08-198">string</span></span>| <span data-ttu-id="a0f08-199">50</span><span class="sxs-lookup"><span data-stu-id="a0f08-199">50</span></span>| <span data-ttu-id="a0f08-200">メッセージ id、メッセージの詳細を取得またはメッセージを削除するために使用します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-200">Message identifier, used for retrieving message details or deleting messages.</span></span>|
| <span data-ttu-id="a0f08-201">isRead</span><span class="sxs-lookup"><span data-stu-id="a0f08-201">isRead</span></span>| <span data-ttu-id="a0f08-202">bool</span><span class="sxs-lookup"><span data-stu-id="a0f08-202">bool</span></span>|  | <span data-ttu-id="a0f08-203">ユーザーがメッセージの詳細を既に読み取ることを示すフラグします。</span><span class="sxs-lookup"><span data-stu-id="a0f08-203">Flag indicating that the user has already read the message details.</span></span>|
| <span data-ttu-id="a0f08-204">送信</span><span class="sxs-lookup"><span data-stu-id="a0f08-204">sent</span></span>| <span data-ttu-id="a0f08-205">DateTime</span><span class="sxs-lookup"><span data-stu-id="a0f08-205">DateTime</span></span>|  | <span data-ttu-id="a0f08-206">UTC の日付と時刻、メッセージは送信されました。</span><span class="sxs-lookup"><span data-stu-id="a0f08-206">UTC date and time the message was sent.</span></span> <span data-ttu-id="a0f08-207">(サービスによって提供されます。)</span><span class="sxs-lookup"><span data-stu-id="a0f08-207">(Provided by the service.)</span></span>|
| <span data-ttu-id="a0f08-208">有効期限</span><span class="sxs-lookup"><span data-stu-id="a0f08-208">expiration</span></span>| <span data-ttu-id="a0f08-209">DateTime</span><span class="sxs-lookup"><span data-stu-id="a0f08-209">DateTime</span></span>|  | <span data-ttu-id="a0f08-210">メッセージの有効期限日時 (utc)。</span><span class="sxs-lookup"><span data-stu-id="a0f08-210">UTC date and time the message expires.</span></span> <span data-ttu-id="a0f08-211">(すべてのメッセージによって、今後未定の最長有効期間がある)。</span><span class="sxs-lookup"><span data-stu-id="a0f08-211">(All messages have a maximum lifetime, to be determined in the future.)</span></span>|
| <span data-ttu-id="a0f08-212">メッセージの種類</span><span class="sxs-lookup"><span data-stu-id="a0f08-212">messageType</span></span>| <span data-ttu-id="a0f08-213">string</span><span class="sxs-lookup"><span data-stu-id="a0f08-213">string</span></span>| <span data-ttu-id="a0f08-214">50</span><span class="sxs-lookup"><span data-stu-id="a0f08-214">50</span></span>| <span data-ttu-id="a0f08-215">メッセージの種類:ユーザー、システム、FriendRequest、ビデオ、QuickChat VideoChat、PartyChat、タイトル、GameInvite します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-215">Message types: User, System, FriendRequest, Video, QuickChat, VideoChat, PartyChat, Title, GameInvite.</span></span>|
| <span data-ttu-id="a0f08-216">senderXuid</span><span class="sxs-lookup"><span data-stu-id="a0f08-216">senderXuid</span></span>| <span data-ttu-id="a0f08-217">ulong</span><span class="sxs-lookup"><span data-stu-id="a0f08-217">ulong</span></span>|  | <span data-ttu-id="a0f08-218">送信者の XUID です。</span><span class="sxs-lookup"><span data-stu-id="a0f08-218">XUID of sender.</span></span>|
| <span data-ttu-id="a0f08-219">センダー</span><span class="sxs-lookup"><span data-stu-id="a0f08-219">sender</span></span>| <span data-ttu-id="a0f08-220">string</span><span class="sxs-lookup"><span data-stu-id="a0f08-220">string</span></span>| <span data-ttu-id="a0f08-221">15</span><span class="sxs-lookup"><span data-stu-id="a0f08-221">15</span></span>| <span data-ttu-id="a0f08-222">送信者のゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="a0f08-222">Gamertag of sender.</span></span>|
| <span data-ttu-id="a0f08-223">hasAudio</span><span class="sxs-lookup"><span data-stu-id="a0f08-223">hasAudio</span></span>| <span data-ttu-id="a0f08-224">bool</span><span class="sxs-lookup"><span data-stu-id="a0f08-224">bool</span></span>|  | <span data-ttu-id="a0f08-225">かどうか、メッセージには、音声 (音声) 添付ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="a0f08-225">Whether the message has an audio (voice) attachment.</span></span>|
| <span data-ttu-id="a0f08-226">hasPhoto</span><span class="sxs-lookup"><span data-stu-id="a0f08-226">hasPhoto</span></span>| <span data-ttu-id="a0f08-227">bool</span><span class="sxs-lookup"><span data-stu-id="a0f08-227">bool</span></span>|  | <span data-ttu-id="a0f08-228">かどうか、メッセージの添付写真が。</span><span class="sxs-lookup"><span data-stu-id="a0f08-228">Whether the message has a photo attachment.</span></span>|
| <span data-ttu-id="a0f08-229">hasText</span><span class="sxs-lookup"><span data-stu-id="a0f08-229">hasText</span></span>| <span data-ttu-id="a0f08-230">bool</span><span class="sxs-lookup"><span data-stu-id="a0f08-230">bool</span></span>|  | <span data-ttu-id="a0f08-231">かどうか、メッセージには、テキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="a0f08-231">Whether the message contains text.</span></span>|

#### <a name="paging-info"></a><span data-ttu-id="a0f08-232">ページングの情報</span><span class="sxs-lookup"><span data-stu-id="a0f08-232">Paging Info</span></span>

| <span data-ttu-id="a0f08-233">プロパティ</span><span class="sxs-lookup"><span data-stu-id="a0f08-233">Property</span></span>| <span data-ttu-id="a0f08-234">種類</span><span class="sxs-lookup"><span data-stu-id="a0f08-234">Type</span></span>| <span data-ttu-id="a0f08-235">最大長</span><span class="sxs-lookup"><span data-stu-id="a0f08-235">Maximum Length</span></span>| <span data-ttu-id="a0f08-236">注釈</span><span class="sxs-lookup"><span data-stu-id="a0f08-236">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="a0f08-237">continuationToken</span><span class="sxs-lookup"><span data-stu-id="a0f08-237">continuationToken</span></span>| <span data-ttu-id="a0f08-238">string</span><span class="sxs-lookup"><span data-stu-id="a0f08-238">string</span></span>| <span data-ttu-id="a0f08-239">100</span><span class="sxs-lookup"><span data-stu-id="a0f08-239">100</span></span>| <span data-ttu-id="a0f08-240">必要に応じて、サーバーによって返されます。</span><span class="sxs-lookup"><span data-stu-id="a0f08-240">Optionally returned by server.</span></span> <span data-ttu-id="a0f08-241">列挙を続けるための以降の呼び出しを許可します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-241">Allows later calls to continue enumeration.</span></span>|
| <span data-ttu-id="a0f08-242">totalItems</span><span class="sxs-lookup"><span data-stu-id="a0f08-242">totalItems</span></span>| <span data-ttu-id="a0f08-243">int</span><span class="sxs-lookup"><span data-stu-id="a0f08-243">int</span></span>|  | <span data-ttu-id="a0f08-244">受信トレイのメッセージの合計数。</span><span class="sxs-lookup"><span data-stu-id="a0f08-244">Total number of messages in inbox.</span></span>|

#### <a name="sample-response"></a><span data-ttu-id="a0f08-245">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="a0f08-245">Sample response</span></span>

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

#### <a name="error-response"></a><span data-ttu-id="a0f08-246">エラー応答</span><span class="sxs-lookup"><span data-stu-id="a0f08-246">Error Response</span></span>

<span data-ttu-id="a0f08-247">エラーが発生した場合、サービスはサービスの環境から値を含むことができる、存在する errorResponse オブジェクトを返す可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a0f08-247">In case of error, the service may return an errorResponse object, which may contain values from the environment of the service.</span></span>

| <span data-ttu-id="a0f08-248">プロパティ</span><span class="sxs-lookup"><span data-stu-id="a0f08-248">Property</span></span>| <span data-ttu-id="a0f08-249">種類</span><span class="sxs-lookup"><span data-stu-id="a0f08-249">Type</span></span>| <span data-ttu-id="a0f08-250">説明</span><span class="sxs-lookup"><span data-stu-id="a0f08-250">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a0f08-251">errorSource</span><span class="sxs-lookup"><span data-stu-id="a0f08-251">errorSource</span></span>| <span data-ttu-id="a0f08-252">string</span><span class="sxs-lookup"><span data-stu-id="a0f08-252">string</span></span>| <span data-ttu-id="a0f08-253">エラーの発生元を示します。</span><span class="sxs-lookup"><span data-stu-id="a0f08-253">An indication of where the error originated.</span></span>|
| <span data-ttu-id="a0f08-254">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a0f08-254">errorCode</span></span>| <span data-ttu-id="a0f08-255">int</span><span class="sxs-lookup"><span data-stu-id="a0f08-255">int</span></span>| <span data-ttu-id="a0f08-256">(Null にすることができます)、エラーに関連付けられている数値コードです。</span><span class="sxs-lookup"><span data-stu-id="a0f08-256">Numeric code associated with the error (can be null).</span></span>|
| <span data-ttu-id="a0f08-257">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="a0f08-257">errorMessage</span></span>| <span data-ttu-id="a0f08-258">string</span><span class="sxs-lookup"><span data-stu-id="a0f08-258">string</span></span>| <span data-ttu-id="a0f08-259">詳細を表示するように構成してある場合、エラーの詳細です。</span><span class="sxs-lookup"><span data-stu-id="a0f08-259">Details of the error if configured to show details.</span></span>|

<a id="ID4EIKAC"></a>


## <a name="see-also"></a><span data-ttu-id="a0f08-260">関連項目</span><span class="sxs-lookup"><span data-stu-id="a0f08-260">See also</span></span>

<a id="ID4EKKAC"></a>


##### <a name="parent"></a><span data-ttu-id="a0f08-261">Parent</span><span class="sxs-lookup"><span data-stu-id="a0f08-261">Parent</span></span>  

[<span data-ttu-id="a0f08-262">/users/xuid({xuid})/inbox</span><span class="sxs-lookup"><span data-stu-id="a0f08-262">/users/xuid({xuid})/inbox</span></span>](uri-usersxuidinbox.md)


<a id="ID4EWKAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a><span data-ttu-id="a0f08-263">参照[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)</span><span class="sxs-lookup"><span data-stu-id="a0f08-263">Reference  [Standard HTTP status codes](../../additional/httpstatuscodes.md)</span></span>
