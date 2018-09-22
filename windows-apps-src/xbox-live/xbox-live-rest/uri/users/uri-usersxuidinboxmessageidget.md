---
title: GET (/users/xuid({xuid})/inbox/{messageId})
assetID: d76563d0-2c74-0308-054b-762c80392a02
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxmessageidget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/inbox/{messageId})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8e94396f86b235aafce2e8a65f93eedbdc96f46b
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4126944"
---
# <a name="get-usersxuidxuidinboxmessageid"></a><span data-ttu-id="fb6b1-104">GET (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="fb6b1-104">GET (/users/xuid({xuid})/inbox/{messageId})</span></span>
<span data-ttu-id="fb6b1-105">サービスの読み取りとしてマーク、特定のユーザーのメッセージの詳細なメッセージ テキストを取得します。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-105">Retrieves the detailed message text for a particular user message, marking it as read on the service.</span></span>
<span data-ttu-id="fb6b1-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>

  * [<span data-ttu-id="fb6b1-107">注釈</span><span class="sxs-lookup"><span data-stu-id="fb6b1-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="fb6b1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fb6b1-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="fb6b1-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="fb6b1-109">Authorization</span></span>](#ID4ERB)
  * [<span data-ttu-id="fb6b1-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="fb6b1-110">Request body</span></span>](#ID4E3B)
  * [<span data-ttu-id="fb6b1-111">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="fb6b1-111">Effect of privacy settings on resource</span></span>](#ID4EJC)
  * [<span data-ttu-id="fb6b1-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="fb6b1-112">HTTP status codes</span></span>](#ID4EUC)
  * [<span data-ttu-id="fb6b1-113">JavaScript オブジェクト Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="fb6b1-113">JavaScript Object Notation (JSON) Response</span></span>](#ID4EUE)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="fb6b1-114">注釈</span><span class="sxs-lookup"><span data-stu-id="fb6b1-114">Remarks</span></span>

<span data-ttu-id="fb6b1-115">Get 操作は、ユーザー、システム、および FriendRequest メッセージの種類でのみ実行できます。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-115">The get operation can only be performed on the User, System, and FriendRequest message types.</span></span>

<span data-ttu-id="fb6b1-116">この URI には、Xbox.com に更新が必要です。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-116">This URI requires a refresh on Xbox.com.</span></span> <span data-ttu-id="fb6b1-117">現時点では、まで、ユーザーがサインアウトしたとに戻り、Xbox 360 は読み取り/未読メ状態を更新されません。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-117">Currently, the Xbox 360 will not update the read/unread state until a user signs out and back in.</span></span>

<span data-ttu-id="fb6b1-118">この API は、サポートのみコンテンツの種類は、"アプリケーション/json"、呼び出しごとの HTTP ヘッダーのために必要です。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-118">The only content type this API supports is "application/json", which is required in the HTTP headers of each call.</span></span>

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="fb6b1-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fb6b1-119">URI parameters</span></span>

| <span data-ttu-id="fb6b1-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fb6b1-120">Parameter</span></span>| <span data-ttu-id="fb6b1-121">型</span><span class="sxs-lookup"><span data-stu-id="fb6b1-121">Type</span></span>| <span data-ttu-id="fb6b1-122">説明</span><span class="sxs-lookup"><span data-stu-id="fb6b1-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="fb6b1-123">xuid</span><span class="sxs-lookup"><span data-stu-id="fb6b1-123">xuid</span></span> | <span data-ttu-id="fb6b1-124">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="fb6b1-124">unsigned 64-bit integer</span></span> | <span data-ttu-id="fb6b1-125">Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-125">The Xbox User ID (XUID) of the player who is making the request.</span></span> |
| <span data-ttu-id="fb6b1-126">メッセージ Id</span><span class="sxs-lookup"><span data-stu-id="fb6b1-126">messageId</span></span> | <span data-ttu-id="fb6b1-127">文字列 [50]</span><span class="sxs-lookup"><span data-stu-id="fb6b1-127">string[50]</span></span> | <span data-ttu-id="fb6b1-128">取得または削除されるメッセージの ID です。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-128">ID of the message being retrieved or deleted.</span></span> |

<a id="ID4ERB"></a>


## <a name="authorization"></a><span data-ttu-id="fb6b1-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="fb6b1-129">Authorization</span></span>

<span data-ttu-id="fb6b1-130">独自のユーザーがユーザーのメッセージを取得する要求が必要です。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-130">You must have your own user claim to retrieve a user message.</span></span>

<a id="ID4E3B"></a>


## <a name="request-body"></a><span data-ttu-id="fb6b1-131">要求本文</span><span class="sxs-lookup"><span data-stu-id="fb6b1-131">Request body</span></span>

<span data-ttu-id="fb6b1-132">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-132">No objects are sent in the body of this request.</span></span>

<a id="ID4EJC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="fb6b1-133">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="fb6b1-133">Effect of privacy settings on resource</span></span>

<span data-ttu-id="fb6b1-134">だけユーザー メッセージを取得できます。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-134">Only you can retrieve your own user messages.</span></span>

<a id="ID4EUC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="fb6b1-135">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="fb6b1-135">HTTP status codes</span></span>

<span data-ttu-id="fb6b1-136">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-136">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="fb6b1-137">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-137">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="fb6b1-138">コード</span><span class="sxs-lookup"><span data-stu-id="fb6b1-138">Code</span></span>| <span data-ttu-id="fb6b1-139">説明</span><span class="sxs-lookup"><span data-stu-id="fb6b1-139">Description</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="fb6b1-140">200</span><span class="sxs-lookup"><span data-stu-id="fb6b1-140">200</span></span>| <span data-ttu-id="fb6b1-141">成功します。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-141">Success.</span></span>|
| <span data-ttu-id="fb6b1-142">400</span><span class="sxs-lookup"><span data-stu-id="fb6b1-142">400</span></span>| <span data-ttu-id="fb6b1-143">XUID を適切に変換することはできません。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-143">The XUID cannot be converted properly.</span></span>|
| <span data-ttu-id="fb6b1-144">403</span><span class="sxs-lookup"><span data-stu-id="fb6b1-144">403</span></span>| <span data-ttu-id="fb6b1-145">XUID に変換することはできませんか、有効な XUID クレームが見つかったことはできません。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-145">The XUID cannot be converted or a valid XUID claim cannot be found.</span></span>|
| <span data-ttu-id="fb6b1-146">404</span><span class="sxs-lookup"><span data-stu-id="fb6b1-146">404</span></span>| <span data-ttu-id="fb6b1-147">有効な XUID が見つからないか、またはメッセージ ID が見つからないか、解析されます。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-147">A valid XUID is missing, or the message ID cannot be found or is parsed incorrectly.</span></span>|
| <span data-ttu-id="fb6b1-148">500</span><span class="sxs-lookup"><span data-stu-id="fb6b1-148">500</span></span>| <span data-ttu-id="fb6b1-149">サーバー側の一般的なエラー、またはメッセージの種類は、GET に対して有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-149">General server-side error, or the message type is not valid for GET.</span></span>|

<a id="ID4EUE"></a>


## <a name="javascript-object-notation-json-response"></a><span data-ttu-id="fb6b1-150">JavaScript オブジェクト Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="fb6b1-150">JavaScript Object Notation (JSON) Response</span></span>

<span data-ttu-id="fb6b1-151">正常に呼び出されると、サービスは結果データを JSON 形式で返します。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-151">If called successfully, the service returns the results data in a JSON format.</span></span> <span data-ttu-id="fb6b1-152">ルート オブジェクトは、UserMessageHeader オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-152">The root object is a UserMessageHeader object.</span></span>

#### <a name="usermessageheader"></a><span data-ttu-id="fb6b1-153">UserMessageHeader</span><span class="sxs-lookup"><span data-stu-id="fb6b1-153">UserMessageHeader</span></span>

| <span data-ttu-id="fb6b1-154">プロパティ</span><span class="sxs-lookup"><span data-stu-id="fb6b1-154">Property</span></span>| <span data-ttu-id="fb6b1-155">型</span><span class="sxs-lookup"><span data-stu-id="fb6b1-155">Type</span></span>| <span data-ttu-id="fb6b1-156">最大長</span><span class="sxs-lookup"><span data-stu-id="fb6b1-156">Maximum Length</span></span>| <span data-ttu-id="fb6b1-157">注釈</span><span class="sxs-lookup"><span data-stu-id="fb6b1-157">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="fb6b1-158">header</span><span class="sxs-lookup"><span data-stu-id="fb6b1-158">header</span></span>| <span data-ttu-id="fb6b1-159">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fb6b1-159">Header</span></span>|  | <span data-ttu-id="fb6b1-160">JSON オブジェクト</span><span class="sxs-lookup"><span data-stu-id="fb6b1-160">JSON object</span></span>|
| <span data-ttu-id="fb6b1-161">メッセージ テキスト</span><span class="sxs-lookup"><span data-stu-id="fb6b1-161">messageText</span></span>| <span data-ttu-id="fb6b1-162">string</span><span class="sxs-lookup"><span data-stu-id="fb6b1-162">string</span></span>| <span data-ttu-id="fb6b1-163">256</span><span class="sxs-lookup"><span data-stu-id="fb6b1-163">256</span></span>| <span data-ttu-id="fb6b1-164">UTF-8</span><span class="sxs-lookup"><span data-stu-id="fb6b1-164">UTF-8</span></span>|

#### <a name="header"></a><span data-ttu-id="fb6b1-165">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fb6b1-165">Header</span></span>

| <span data-ttu-id="fb6b1-166">プロパティ</span><span class="sxs-lookup"><span data-stu-id="fb6b1-166">Property</span></span>| <span data-ttu-id="fb6b1-167">型</span><span class="sxs-lookup"><span data-stu-id="fb6b1-167">Type</span></span>| <span data-ttu-id="fb6b1-168">最大長</span><span class="sxs-lookup"><span data-stu-id="fb6b1-168">Maximum Length</span></span>| <span data-ttu-id="fb6b1-169">注釈</span><span class="sxs-lookup"><span data-stu-id="fb6b1-169">Remarks</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="fb6b1-170">送信</span><span class="sxs-lookup"><span data-stu-id="fb6b1-170">sent</span></span>| <span data-ttu-id="fb6b1-171">DateTime</span><span class="sxs-lookup"><span data-stu-id="fb6b1-171">DateTime</span></span>|  | <span data-ttu-id="fb6b1-172">メッセージが送信された日付と時刻。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-172">Date and time the message was sent.</span></span> <span data-ttu-id="fb6b1-173">(サービスによって提供されます)。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-173">(Provided by the service.)</span></span>|
| <span data-ttu-id="fb6b1-174">有効期限</span><span class="sxs-lookup"><span data-stu-id="fb6b1-174">expiration</span></span>| <span data-ttu-id="fb6b1-175">DateTime</span><span class="sxs-lookup"><span data-stu-id="fb6b1-175">DateTime</span></span>|  | <span data-ttu-id="fb6b1-176">日付と時刻のメッセージの有効期限が切れます。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-176">Date and time the message expires.</span></span> <span data-ttu-id="fb6b1-177">(すべてのメッセージによって、決定する、今後の最長有効期間がある)。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-177">(All messages have a maximum lifetime, to be determined in the future.)</span></span>|
| <span data-ttu-id="fb6b1-178">メッセージの種類</span><span class="sxs-lookup"><span data-stu-id="fb6b1-178">messageType</span></span>| <span data-ttu-id="fb6b1-179">string</span><span class="sxs-lookup"><span data-stu-id="fb6b1-179">string</span></span>| <span data-ttu-id="fb6b1-180">13</span><span class="sxs-lookup"><span data-stu-id="fb6b1-180">13</span></span>| <span data-ttu-id="fb6b1-181">メッセージの種類: ユーザー、システム、FriendRequest します。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-181">Message types: User, System, FriendRequest.</span></span>|
| <span data-ttu-id="fb6b1-182">senderXuid</span><span class="sxs-lookup"><span data-stu-id="fb6b1-182">senderXuid</span></span>| <span data-ttu-id="fb6b1-183">ulong</span><span class="sxs-lookup"><span data-stu-id="fb6b1-183">ulong</span></span>|  | <span data-ttu-id="fb6b1-184">送信者の XUID です。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-184">XUID of sender.</span></span>|
| <span data-ttu-id="fb6b1-185">送信者</span><span class="sxs-lookup"><span data-stu-id="fb6b1-185">sender</span></span>| <span data-ttu-id="fb6b1-186">string</span><span class="sxs-lookup"><span data-stu-id="fb6b1-186">string</span></span>| <span data-ttu-id="fb6b1-187">15</span><span class="sxs-lookup"><span data-stu-id="fb6b1-187">15</span></span>| <span data-ttu-id="fb6b1-188">送信者のゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-188">Gamertag of sender.</span></span>|
| <span data-ttu-id="fb6b1-189">hasAudio</span><span class="sxs-lookup"><span data-stu-id="fb6b1-189">hasAudio</span></span>| <span data-ttu-id="fb6b1-190">bool</span><span class="sxs-lookup"><span data-stu-id="fb6b1-190">bool</span></span>|  | <span data-ttu-id="fb6b1-191">かどうか、メッセージは、オーディオ (声) の添付ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-191">Whether the message has an audio (voice) attachment.</span></span>|
| <span data-ttu-id="fb6b1-192">hasPhoto</span><span class="sxs-lookup"><span data-stu-id="fb6b1-192">hasPhoto</span></span>| <span data-ttu-id="fb6b1-193">bool</span><span class="sxs-lookup"><span data-stu-id="fb6b1-193">bool</span></span>|  | <span data-ttu-id="fb6b1-194">かどうか、メッセージは、写真の添付ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-194">Whether the message has a photo attachment.</span></span>|
| <span data-ttu-id="fb6b1-195">hasText</span><span class="sxs-lookup"><span data-stu-id="fb6b1-195">hasText</span></span>| <span data-ttu-id="fb6b1-196">bool</span><span class="sxs-lookup"><span data-stu-id="fb6b1-196">bool</span></span>|  | <span data-ttu-id="fb6b1-197">かどうか、メッセージには、テキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-197">Whether the message contains text.</span></span>|

#### <a name="sample-response"></a><span data-ttu-id="fb6b1-198">応答の例</span><span class="sxs-lookup"><span data-stu-id="fb6b1-198">Sample response</span></span>

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

#### <a name="error-response"></a><span data-ttu-id="fb6b1-199">エラー応答</span><span class="sxs-lookup"><span data-stu-id="fb6b1-199">Error Response</span></span>

<span data-ttu-id="fb6b1-200">エラーの場合、サービスはサービスの環境からの値が含まれている全て、errorResponse オブジェクトを返す可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-200">In case of error, the service may return an errorResponse object, which may contain values from the environment of the service.</span></span>

| <span data-ttu-id="fb6b1-201">プロパティ</span><span class="sxs-lookup"><span data-stu-id="fb6b1-201">Property</span></span>| <span data-ttu-id="fb6b1-202">型</span><span class="sxs-lookup"><span data-stu-id="fb6b1-202">Type</span></span>| <span data-ttu-id="fb6b1-203">説明</span><span class="sxs-lookup"><span data-stu-id="fb6b1-203">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="fb6b1-204">errorSource</span><span class="sxs-lookup"><span data-stu-id="fb6b1-204">errorSource</span></span>| <span data-ttu-id="fb6b1-205">string</span><span class="sxs-lookup"><span data-stu-id="fb6b1-205">string</span></span>| <span data-ttu-id="fb6b1-206">エラーの発生元の項目を示します。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-206">An indication of where the error originated.</span></span>|
| <span data-ttu-id="fb6b1-207">errorCode</span><span class="sxs-lookup"><span data-stu-id="fb6b1-207">errorCode</span></span>| <span data-ttu-id="fb6b1-208">int</span><span class="sxs-lookup"><span data-stu-id="fb6b1-208">int</span></span>| <span data-ttu-id="fb6b1-209">(Null にすることができます) エラーに関連付けられている数値コードです。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-209">Numeric code associated with the error (can be null).</span></span>|
| <span data-ttu-id="fb6b1-210">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="fb6b1-210">errorMessage</span></span>| <span data-ttu-id="fb6b1-211">string</span><span class="sxs-lookup"><span data-stu-id="fb6b1-211">string</span></span>| <span data-ttu-id="fb6b1-212">詳細を表示するように構成する場合のエラーの説明します。</span><span class="sxs-lookup"><span data-stu-id="fb6b1-212">Details of the error if configured to show details.</span></span>|

<a id="ID4E3DAC"></a>


## <a name="see-also"></a><span data-ttu-id="fb6b1-213">関連項目</span><span class="sxs-lookup"><span data-stu-id="fb6b1-213">See also</span></span>

<a id="ID4E5DAC"></a>


##### <a name="parent"></a><span data-ttu-id="fb6b1-214">Parent</span><span class="sxs-lookup"><span data-stu-id="fb6b1-214">Parent</span></span>  

[<span data-ttu-id="fb6b1-215">/users/xuid({xuid})/inbox</span><span class="sxs-lookup"><span data-stu-id="fb6b1-215">/users/xuid({xuid})/inbox</span></span>](uri-usersxuidinbox.md)


<a id="ID4EMEAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a><span data-ttu-id="fb6b1-216">参照[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)</span><span class="sxs-lookup"><span data-stu-id="fb6b1-216">Reference  [Standard HTTP status codes](../../additional/httpstatuscodes.md)</span></span>
