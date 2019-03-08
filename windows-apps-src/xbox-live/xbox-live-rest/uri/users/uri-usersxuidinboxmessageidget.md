---
title: GET (/users/xuid({xuid})/inbox/{messageId})
assetID: d76563d0-2c74-0308-054b-762c80392a02
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxmessageidget.html
description: " GET (/users/xuid({xuid})/inbox/{messageId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 29b4c57468148a431a10e0d74f85d360ff0992b3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618057"
---
# <a name="get-usersxuidxuidinboxmessageid"></a><span data-ttu-id="d57b3-104">GET (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="d57b3-104">GET (/users/xuid({xuid})/inbox/{messageId})</span></span>
<span data-ttu-id="d57b3-105">開封済みにサービスで、特定のユーザー メッセージの詳細なメッセージ テキストを取得します。</span><span class="sxs-lookup"><span data-stu-id="d57b3-105">Retrieves the detailed message text for a particular user message, marking it as read on the service.</span></span>
<span data-ttu-id="d57b3-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d57b3-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>

  * [<span data-ttu-id="d57b3-107">注釈</span><span class="sxs-lookup"><span data-stu-id="d57b3-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="d57b3-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d57b3-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="d57b3-109">承認</span><span class="sxs-lookup"><span data-stu-id="d57b3-109">Authorization</span></span>](#ID4ERB)
  * [<span data-ttu-id="d57b3-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="d57b3-110">Request body</span></span>](#ID4E3B)
  * [<span data-ttu-id="d57b3-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="d57b3-111">Effect of privacy settings on resource</span></span>](#ID4EJC)
  * [<span data-ttu-id="d57b3-112">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="d57b3-112">HTTP status codes</span></span>](#ID4EUC)
  * [<span data-ttu-id="d57b3-113">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="d57b3-113">JavaScript Object Notation (JSON) Response</span></span>](#ID4EUE)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="d57b3-114">注釈</span><span class="sxs-lookup"><span data-stu-id="d57b3-114">Remarks</span></span>

<span data-ttu-id="d57b3-115">取得操作は、ユーザー、システム、および FriendRequest メッセージの種類でのみ実行できます。</span><span class="sxs-lookup"><span data-stu-id="d57b3-115">The get operation can only be performed on the User, System, and FriendRequest message types.</span></span>

<span data-ttu-id="d57b3-116">この URI には、Xbox.com での更新が必要です。</span><span class="sxs-lookup"><span data-stu-id="d57b3-116">This URI requires a refresh on Xbox.com.</span></span> <span data-ttu-id="d57b3-117">現時点では、ユーザーがサインアウトするまでに戻り、Xbox 360 は読み取り/未読の状態を更新できません。</span><span class="sxs-lookup"><span data-stu-id="d57b3-117">Currently, the Xbox 360 will not update the read/unread state until a user signs out and back in.</span></span>

<span data-ttu-id="d57b3-118">この API はサポートのみコンテンツの種類は、"application/json"に必要な各呼び出しの HTTP ヘッダーが。</span><span class="sxs-lookup"><span data-stu-id="d57b3-118">The only content type this API supports is "application/json", which is required in the HTTP headers of each call.</span></span>

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="d57b3-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d57b3-119">URI parameters</span></span>

| <span data-ttu-id="d57b3-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d57b3-120">Parameter</span></span>| <span data-ttu-id="d57b3-121">種類</span><span class="sxs-lookup"><span data-stu-id="d57b3-121">Type</span></span>| <span data-ttu-id="d57b3-122">説明</span><span class="sxs-lookup"><span data-stu-id="d57b3-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="d57b3-123">xuid</span><span class="sxs-lookup"><span data-stu-id="d57b3-123">xuid</span></span> | <span data-ttu-id="d57b3-124">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d57b3-124">unsigned 64-bit integer</span></span> | <span data-ttu-id="d57b3-125">Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。</span><span class="sxs-lookup"><span data-stu-id="d57b3-125">The Xbox User ID (XUID) of the player who is making the request.</span></span> |
| <span data-ttu-id="d57b3-126">メッセージ Id</span><span class="sxs-lookup"><span data-stu-id="d57b3-126">messageId</span></span> | <span data-ttu-id="d57b3-127">string[50]</span><span class="sxs-lookup"><span data-stu-id="d57b3-127">string[50]</span></span> | <span data-ttu-id="d57b3-128">メッセージの取得中または削除の ID。</span><span class="sxs-lookup"><span data-stu-id="d57b3-128">ID of the message being retrieved or deleted.</span></span> |

<a id="ID4ERB"></a>


## <a name="authorization"></a><span data-ttu-id="d57b3-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="d57b3-129">Authorization</span></span>

<span data-ttu-id="d57b3-130">ユーザー メッセージを取得する要求、独自のユーザーが必要です。</span><span class="sxs-lookup"><span data-stu-id="d57b3-130">You must have your own user claim to retrieve a user message.</span></span>

<a id="ID4E3B"></a>


## <a name="request-body"></a><span data-ttu-id="d57b3-131">要求本文</span><span class="sxs-lookup"><span data-stu-id="d57b3-131">Request body</span></span>

<span data-ttu-id="d57b3-132">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="d57b3-132">No objects are sent in the body of this request.</span></span>

<a id="ID4EJC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="d57b3-133">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="d57b3-133">Effect of privacy settings on resource</span></span>

<span data-ttu-id="d57b3-134">のみ、独自のユーザー メッセージを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d57b3-134">Only you can retrieve your own user messages.</span></span>

<a id="ID4EUC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="d57b3-135">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="d57b3-135">HTTP status codes</span></span>

<span data-ttu-id="d57b3-136">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="d57b3-136">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="d57b3-137">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="d57b3-137">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="d57b3-138">コード</span><span class="sxs-lookup"><span data-stu-id="d57b3-138">Code</span></span>| <span data-ttu-id="d57b3-139">説明</span><span class="sxs-lookup"><span data-stu-id="d57b3-139">Description</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="d57b3-140">200</span><span class="sxs-lookup"><span data-stu-id="d57b3-140">200</span></span>| <span data-ttu-id="d57b3-141">成功しました。</span><span class="sxs-lookup"><span data-stu-id="d57b3-141">Success.</span></span>|
| <span data-ttu-id="d57b3-142">400</span><span class="sxs-lookup"><span data-stu-id="d57b3-142">400</span></span>| <span data-ttu-id="d57b3-143">XUID を適切に変換することはできません。</span><span class="sxs-lookup"><span data-stu-id="d57b3-143">The XUID cannot be converted properly.</span></span>|
| <span data-ttu-id="d57b3-144">403</span><span class="sxs-lookup"><span data-stu-id="d57b3-144">403</span></span>| <span data-ttu-id="d57b3-145">XUID を変換することはできませんまたは有効な XUID 要求が見つかりません。</span><span class="sxs-lookup"><span data-stu-id="d57b3-145">The XUID cannot be converted or a valid XUID claim cannot be found.</span></span>|
| <span data-ttu-id="d57b3-146">404</span><span class="sxs-lookup"><span data-stu-id="d57b3-146">404</span></span>| <span data-ttu-id="d57b3-147">有効な XUID が存在しないか、メッセージ ID が見つからないか、正しく解析されます。</span><span class="sxs-lookup"><span data-stu-id="d57b3-147">A valid XUID is missing, or the message ID cannot be found or is parsed incorrectly.</span></span>|
| <span data-ttu-id="d57b3-148">500</span><span class="sxs-lookup"><span data-stu-id="d57b3-148">500</span></span>| <span data-ttu-id="d57b3-149">一般的なサーバー側のエラー、またはメッセージの種類は、GET の無効です。</span><span class="sxs-lookup"><span data-stu-id="d57b3-149">General server-side error, or the message type is not valid for GET.</span></span>|

<a id="ID4EUE"></a>


## <a name="javascript-object-notation-json-response"></a><span data-ttu-id="d57b3-150">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="d57b3-150">JavaScript Object Notation (JSON) Response</span></span>

<span data-ttu-id="d57b3-151">正常に呼び出されると、サービスは、JSON 形式で結果データを返します。</span><span class="sxs-lookup"><span data-stu-id="d57b3-151">If called successfully, the service returns the results data in a JSON format.</span></span> <span data-ttu-id="d57b3-152">ルート オブジェクトは、UserMessageHeader オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="d57b3-152">The root object is a UserMessageHeader object.</span></span>

#### <a name="usermessageheader"></a><span data-ttu-id="d57b3-153">UserMessageHeader</span><span class="sxs-lookup"><span data-stu-id="d57b3-153">UserMessageHeader</span></span>

| <span data-ttu-id="d57b3-154">プロパティ</span><span class="sxs-lookup"><span data-stu-id="d57b3-154">Property</span></span>| <span data-ttu-id="d57b3-155">種類</span><span class="sxs-lookup"><span data-stu-id="d57b3-155">Type</span></span>| <span data-ttu-id="d57b3-156">最大長</span><span class="sxs-lookup"><span data-stu-id="d57b3-156">Maximum Length</span></span>| <span data-ttu-id="d57b3-157">注釈</span><span class="sxs-lookup"><span data-stu-id="d57b3-157">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="d57b3-158">header</span><span class="sxs-lookup"><span data-stu-id="d57b3-158">header</span></span>| <span data-ttu-id="d57b3-159">Header</span><span class="sxs-lookup"><span data-stu-id="d57b3-159">Header</span></span>|  | <span data-ttu-id="d57b3-160">JSON オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d57b3-160">JSON object</span></span>|
| <span data-ttu-id="d57b3-161">メッセージ テキスト</span><span class="sxs-lookup"><span data-stu-id="d57b3-161">messageText</span></span>| <span data-ttu-id="d57b3-162">string</span><span class="sxs-lookup"><span data-stu-id="d57b3-162">string</span></span>| <span data-ttu-id="d57b3-163">256</span><span class="sxs-lookup"><span data-stu-id="d57b3-163">256</span></span>| <span data-ttu-id="d57b3-164">UTF-8</span><span class="sxs-lookup"><span data-stu-id="d57b3-164">UTF-8</span></span>|

#### <a name="header"></a><span data-ttu-id="d57b3-165">Header</span><span class="sxs-lookup"><span data-stu-id="d57b3-165">Header</span></span>

| <span data-ttu-id="d57b3-166">プロパティ</span><span class="sxs-lookup"><span data-stu-id="d57b3-166">Property</span></span>| <span data-ttu-id="d57b3-167">種類</span><span class="sxs-lookup"><span data-stu-id="d57b3-167">Type</span></span>| <span data-ttu-id="d57b3-168">最大長</span><span class="sxs-lookup"><span data-stu-id="d57b3-168">Maximum Length</span></span>| <span data-ttu-id="d57b3-169">注釈</span><span class="sxs-lookup"><span data-stu-id="d57b3-169">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="d57b3-170">送信</span><span class="sxs-lookup"><span data-stu-id="d57b3-170">sent</span></span>| <span data-ttu-id="d57b3-171">DateTime</span><span class="sxs-lookup"><span data-stu-id="d57b3-171">DateTime</span></span>|  | <span data-ttu-id="d57b3-172">日付と時刻、メッセージは送信されました。</span><span class="sxs-lookup"><span data-stu-id="d57b3-172">Date and time the message was sent.</span></span> <span data-ttu-id="d57b3-173">(サービスによって提供されます。)</span><span class="sxs-lookup"><span data-stu-id="d57b3-173">(Provided by the service.)</span></span>|
| <span data-ttu-id="d57b3-174">有効期限</span><span class="sxs-lookup"><span data-stu-id="d57b3-174">expiration</span></span>| <span data-ttu-id="d57b3-175">DateTime</span><span class="sxs-lookup"><span data-stu-id="d57b3-175">DateTime</span></span>|  | <span data-ttu-id="d57b3-176">日付と時刻、メッセージの有効期限が切れます。</span><span class="sxs-lookup"><span data-stu-id="d57b3-176">Date and time the message expires.</span></span> <span data-ttu-id="d57b3-177">(すべてのメッセージによって、今後未定の最長有効期間がある)。</span><span class="sxs-lookup"><span data-stu-id="d57b3-177">(All messages have a maximum lifetime, to be determined in the future.)</span></span>|
| <span data-ttu-id="d57b3-178">メッセージの種類</span><span class="sxs-lookup"><span data-stu-id="d57b3-178">messageType</span></span>| <span data-ttu-id="d57b3-179">string</span><span class="sxs-lookup"><span data-stu-id="d57b3-179">string</span></span>| <span data-ttu-id="d57b3-180">13</span><span class="sxs-lookup"><span data-stu-id="d57b3-180">13</span></span>| <span data-ttu-id="d57b3-181">メッセージの種類:ユーザー、システム、FriendRequest します。</span><span class="sxs-lookup"><span data-stu-id="d57b3-181">Message types: User, System, FriendRequest.</span></span>|
| <span data-ttu-id="d57b3-182">senderXuid</span><span class="sxs-lookup"><span data-stu-id="d57b3-182">senderXuid</span></span>| <span data-ttu-id="d57b3-183">ulong</span><span class="sxs-lookup"><span data-stu-id="d57b3-183">ulong</span></span>|  | <span data-ttu-id="d57b3-184">送信者の XUID です。</span><span class="sxs-lookup"><span data-stu-id="d57b3-184">XUID of sender.</span></span>|
| <span data-ttu-id="d57b3-185">センダー</span><span class="sxs-lookup"><span data-stu-id="d57b3-185">sender</span></span>| <span data-ttu-id="d57b3-186">string</span><span class="sxs-lookup"><span data-stu-id="d57b3-186">string</span></span>| <span data-ttu-id="d57b3-187">15</span><span class="sxs-lookup"><span data-stu-id="d57b3-187">15</span></span>| <span data-ttu-id="d57b3-188">送信者のゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="d57b3-188">Gamertag of sender.</span></span>|
| <span data-ttu-id="d57b3-189">hasAudio</span><span class="sxs-lookup"><span data-stu-id="d57b3-189">hasAudio</span></span>| <span data-ttu-id="d57b3-190">bool</span><span class="sxs-lookup"><span data-stu-id="d57b3-190">bool</span></span>|  | <span data-ttu-id="d57b3-191">かどうか、メッセージには、音声 (音声) 添付ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="d57b3-191">Whether the message has an audio (voice) attachment.</span></span>|
| <span data-ttu-id="d57b3-192">hasPhoto</span><span class="sxs-lookup"><span data-stu-id="d57b3-192">hasPhoto</span></span>| <span data-ttu-id="d57b3-193">bool</span><span class="sxs-lookup"><span data-stu-id="d57b3-193">bool</span></span>|  | <span data-ttu-id="d57b3-194">かどうか、メッセージの添付写真が。</span><span class="sxs-lookup"><span data-stu-id="d57b3-194">Whether the message has a photo attachment.</span></span>|
| <span data-ttu-id="d57b3-195">hasText</span><span class="sxs-lookup"><span data-stu-id="d57b3-195">hasText</span></span>| <span data-ttu-id="d57b3-196">bool</span><span class="sxs-lookup"><span data-stu-id="d57b3-196">bool</span></span>|  | <span data-ttu-id="d57b3-197">かどうか、メッセージには、テキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d57b3-197">Whether the message contains text.</span></span>|

#### <a name="sample-response"></a><span data-ttu-id="d57b3-198">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="d57b3-198">Sample response</span></span>

```cpp
{
          "header":
          {
            "expiration":"2011-10-11T23:59:59.9999999",
            "messageType":"User",
            "senderXuid":"123456789",
            "sender":"Striker",
            "sent":"2011-05-08T17:30:00Z",
            "hasAudio":false,
            "hasPhoto":false,
            "hasText":true
          },
        "messageText":"random user text up to 256 characters"
        }

```

#### <a name="error-response"></a><span data-ttu-id="d57b3-199">エラー応答</span><span class="sxs-lookup"><span data-stu-id="d57b3-199">Error Response</span></span>

<span data-ttu-id="d57b3-200">エラーが発生した場合、サービスはサービスの環境から値を含むことができる、存在する errorResponse オブジェクトを返す可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d57b3-200">In case of error, the service may return an errorResponse object, which may contain values from the environment of the service.</span></span>

| <span data-ttu-id="d57b3-201">プロパティ</span><span class="sxs-lookup"><span data-stu-id="d57b3-201">Property</span></span>| <span data-ttu-id="d57b3-202">種類</span><span class="sxs-lookup"><span data-stu-id="d57b3-202">Type</span></span>| <span data-ttu-id="d57b3-203">説明</span><span class="sxs-lookup"><span data-stu-id="d57b3-203">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="d57b3-204">errorSource</span><span class="sxs-lookup"><span data-stu-id="d57b3-204">errorSource</span></span>| <span data-ttu-id="d57b3-205">string</span><span class="sxs-lookup"><span data-stu-id="d57b3-205">string</span></span>| <span data-ttu-id="d57b3-206">エラーの発生元を示します。</span><span class="sxs-lookup"><span data-stu-id="d57b3-206">An indication of where the error originated.</span></span>|
| <span data-ttu-id="d57b3-207">エラー コード</span><span class="sxs-lookup"><span data-stu-id="d57b3-207">errorCode</span></span>| <span data-ttu-id="d57b3-208">int</span><span class="sxs-lookup"><span data-stu-id="d57b3-208">int</span></span>| <span data-ttu-id="d57b3-209">(Null にすることができます)、エラーに関連付けられている数値コードです。</span><span class="sxs-lookup"><span data-stu-id="d57b3-209">Numeric code associated with the error (can be null).</span></span>|
| <span data-ttu-id="d57b3-210">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="d57b3-210">errorMessage</span></span>| <span data-ttu-id="d57b3-211">string</span><span class="sxs-lookup"><span data-stu-id="d57b3-211">string</span></span>| <span data-ttu-id="d57b3-212">詳細を表示するように構成してある場合、エラーの詳細です。</span><span class="sxs-lookup"><span data-stu-id="d57b3-212">Details of the error if configured to show details.</span></span>|

<a id="ID4E3DAC"></a>


## <a name="see-also"></a><span data-ttu-id="d57b3-213">関連項目</span><span class="sxs-lookup"><span data-stu-id="d57b3-213">See also</span></span>

<a id="ID4E5DAC"></a>


##### <a name="parent"></a><span data-ttu-id="d57b3-214">Parent</span><span class="sxs-lookup"><span data-stu-id="d57b3-214">Parent</span></span>  

[<span data-ttu-id="d57b3-215">/users/xuid({xuid})/inbox</span><span class="sxs-lookup"><span data-stu-id="d57b3-215">/users/xuid({xuid})/inbox</span></span>](uri-usersxuidinbox.md)


<a id="ID4EMEAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a><span data-ttu-id="d57b3-216">参照[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)</span><span class="sxs-lookup"><span data-stu-id="d57b3-216">Reference  [Standard HTTP status codes](../../additional/httpstatuscodes.md)</span></span>
