---
title: PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})
assetID: e3e4f164-ac5e-cbd9-8c05-2e1ac00dc55e
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.html
description: " PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d35b3f89f8b866a5236e8f5ac91eb37d9a82d306
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598557"
---
# <a name="put-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="4158a-104">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="4158a-104">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>
<span data-ttu-id="4158a-105">作成、更新、またはセッションに参加します。</span><span class="sxs-lookup"><span data-stu-id="4158a-105">Creates, updates, or joins a session.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4158a-106">この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="4158a-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="4158a-107">注釈</span><span class="sxs-lookup"><span data-stu-id="4158a-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="4158a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4158a-108">URI parameters</span></span>](#ID4EYB)
  * [<span data-ttu-id="4158a-109">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="4158a-109">HTTP status codes</span></span>](#ID4EFC)
  * [<span data-ttu-id="4158a-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="4158a-110">Request body</span></span>](#ID4EOC)
  * [<span data-ttu-id="4158a-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="4158a-111">Response body</span></span>](#ID4E4C)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="4158a-112">注釈</span><span class="sxs-lookup"><span data-stu-id="4158a-112">Remarks</span></span>

<span data-ttu-id="4158a-113">この HTTP/REST メソッドを作成、結合、または同じ JSON 要求本文のテンプレートのサブセットを送信することによって、セッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="4158a-113">This HTTP/REST method creates, joins, or updates a session, depending on what subset of the same JSON request body template is sent.</span></span> <span data-ttu-id="4158a-114">成功した場合を返します、 **MultiplayerSession**サーバーから返された応答を含むオブジェクトします。</span><span class="sxs-lookup"><span data-stu-id="4158a-114">On success, it returns a **MultiplayerSession** object containing the response returned from the server.</span></span> <span data-ttu-id="4158a-115">属性が属性に渡されるで異なる可能性があります**MultiplayerSession**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="4158a-115">The attributes in it might be different from the attributes in the passed-in **MultiplayerSession** object.</span></span> <span data-ttu-id="4158a-116">このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionAsync**します。</span><span class="sxs-lookup"><span data-stu-id="4158a-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionAsync**.</span></span>

<span data-ttu-id="4158a-117">セッションの作成と更新操作では、適用する変更を表すアプリケーション/json 本文を含む PUT を使用します。</span><span class="sxs-lookup"><span data-stu-id="4158a-117">Session creation and update operations use PUT with an application/json body that represents the changes to apply.</span></span> <span data-ttu-id="4158a-118">操作はべき等であるは、同じ変更の複数のアプリケーション追加効果ありません。</span><span class="sxs-lookup"><span data-stu-id="4158a-118">The operations are idempotent, that is, multiple applications of the same changes have no additional effect.</span></span>

<span data-ttu-id="4158a-119">JSON 要求本文には、セッションのデータ構造がミラー化します。</span><span class="sxs-lookup"><span data-stu-id="4158a-119">The JSON request body mirrors the session data structure.</span></span> <span data-ttu-id="4158a-120">すべてのフィールドとサブ フィールドは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="4158a-120">All fields and sub-fields are optional.</span></span>

<span data-ttu-id="4158a-121">PUT メソッドのセッションの作成または結合モードのワイヤ形式は、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4158a-121">The wire format for the PUT method's session creation or joining mode is shown below.</span></span>

> [!NOTE]
> <span data-ttu-id="4158a-122">このパターンを使用して処理します。</span><span class="sxs-lookup"><span data-stu-id="4158a-122">Take care using this pattern.</span></span> <span data-ttu-id="4158a-123">Upates 盲目的にセッションの現在の状態に関係なく適用されます。</span><span class="sxs-lookup"><span data-stu-id="4158a-123">Upates are applied blindly, no matter the current state of the session.</span></span>



```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
         Content-Type: application/json

```



<span data-ttu-id="4158a-124">PUT メソッドのセッションの更新モードのワイヤ形式は、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4158a-124">The wire format for the PUT method's session update mode is shown below.</span></span>

```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
         Content-Type: application/json

```



<span data-ttu-id="4158a-125">セッションのプロパティを更新する PUT メソッドのワイヤ形式は、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4158a-125">The wire format for the PUT method to update session properties is shown below.</span></span> <span data-ttu-id="4158a-126">プロパティとして持つが下にあるオブジェクトの本文はセッション URI に PUT 操作と同等です。</span><span class="sxs-lookup"><span data-stu-id="4158a-126">It is equivalent to a PUT operation to the session URI with a body having nothing but the object below as properties.</span></span> <span data-ttu-id="4158a-127">違いは、この操作がエラー コード 404 を返すことをセッションが存在しない場合に見つかりません。</span><span class="sxs-lookup"><span data-stu-id="4158a-127">The difference is that this operation returns error code 404 Not Found if the session does not exist.</span></span> <span data-ttu-id="4158a-128">この操作は、If-match ヘッダーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="4158a-128">This operation supports the If-Match header.</span></span>

```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001/properties HTTP/1.1
         Content-Type: application/json

         { "system": { }, "custom": { } }

```



<a id="ID4EYB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="4158a-129">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4158a-129">URI parameters</span></span>

| <span data-ttu-id="4158a-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4158a-130">Parameter</span></span>| <span data-ttu-id="4158a-131">種類</span><span class="sxs-lookup"><span data-stu-id="4158a-131">Type</span></span>| <span data-ttu-id="4158a-132">説明</span><span class="sxs-lookup"><span data-stu-id="4158a-132">Description</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="4158a-133">scid</span><span class="sxs-lookup"><span data-stu-id="4158a-133">scid</span></span>| <span data-ttu-id="4158a-134">GUID</span><span class="sxs-lookup"><span data-stu-id="4158a-134">GUID</span></span>| <span data-ttu-id="4158a-135">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="4158a-135">Service configuration identifier (SCID).</span></span> <span data-ttu-id="4158a-136">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="4158a-136">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="4158a-137">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="4158a-137">sessionTemplateName</span></span>| <span data-ttu-id="4158a-138">string</span><span class="sxs-lookup"><span data-stu-id="4158a-138">string</span></span>| <span data-ttu-id="4158a-139">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="4158a-139">Name of the current instance of the session template.</span></span> <span data-ttu-id="4158a-140">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="4158a-140">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="4158a-141">セッション名</span><span class="sxs-lookup"><span data-stu-id="4158a-141">sessionName</span></span>| <span data-ttu-id="4158a-142">GUID</span><span class="sxs-lookup"><span data-stu-id="4158a-142">GUID</span></span>| <span data-ttu-id="4158a-143">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="4158a-143">Unique ID of the session.</span></span> <span data-ttu-id="4158a-144">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="4158a-144">Part 3 of the session identifier.</span></span>|

<a id="ID4EFC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="4158a-145">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="4158a-145">HTTP status codes</span></span>
<span data-ttu-id="4158a-146">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="4158a-146">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EOC"></a>


## <a name="request-body"></a><span data-ttu-id="4158a-147">要求本文</span><span class="sxs-lookup"><span data-stu-id="4158a-147">Request body</span></span>

<span data-ttu-id="4158a-148">作成またはセッションに参加するためのサンプル要求本文を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4158a-148">Below is a sample request body for creating or joining a session.</span></span> <span data-ttu-id="4158a-149">要求本文の次のメンバーは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="4158a-149">The following members of the request body are optional.</span></span> <span data-ttu-id="4158a-150">要求では、他のすべての可能なメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="4158a-150">All other possible members are prohibited in a request.</span></span>

| <span data-ttu-id="4158a-151">メンバー</span><span class="sxs-lookup"><span data-stu-id="4158a-151">Member</span></span>| <span data-ttu-id="4158a-152">種類</span><span class="sxs-lookup"><span data-stu-id="4158a-152">Type</span></span>| <span data-ttu-id="4158a-153">説明</span><span class="sxs-lookup"><span data-stu-id="4158a-153">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="4158a-154">定数</span><span class="sxs-lookup"><span data-stu-id="4158a-154">constants</span></span>| <span data-ttu-id="4158a-155">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="4158a-155">object</span></span>| <span data-ttu-id="4158a-156">セッションの定数を生成するためにセッションのテンプレートとマージする読み取り専用の設定。</span><span class="sxs-lookup"><span data-stu-id="4158a-156">Read-only settings that are merged with the session template to produce the constants for the session.</span></span> |
| <span data-ttu-id="4158a-157">プロパティ</span><span class="sxs-lookup"><span data-stu-id="4158a-157">properties</span></span> | <span data-ttu-id="4158a-158">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="4158a-158">object</span></span> | <span data-ttu-id="4158a-159">セッションのプロパティへの結合を変更します。</span><span class="sxs-lookup"><span data-stu-id="4158a-159">Changes to be merged into the session properties.</span></span>|
| <span data-ttu-id="4158a-160">members.me</span><span class="sxs-lookup"><span data-stu-id="4158a-160">members.me</span></span> | <span data-ttu-id="4158a-161">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="4158a-161">object</span></span>| <span data-ttu-id="4158a-162">定数とよくプロパティなどの最上位レベルの対応します。</span><span class="sxs-lookup"><span data-stu-id="4158a-162">Constants and properties that work much like their top-level counterparts.</span></span> <span data-ttu-id="4158a-163">PUT メソッドは、ユーザー、セッションのメンバーである必要があり、必要に応じて、ユーザーを追加します。</span><span class="sxs-lookup"><span data-stu-id="4158a-163">Any PUT method requires the user to be a member of the session, and adds the user if necessary.</span></span> <span data-ttu-id="4158a-164">"Me"が null として指定されている場合は、要求を行うメンバーが、セッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="4158a-164">If "me" is specified as null, the member making the request is removed from the session.</span></span> |
| <span data-ttu-id="4158a-165">メンバー</span><span class="sxs-lookup"><span data-stu-id="4158a-165">members</span></span> | <span data-ttu-id="4158a-166">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="4158a-166">object</span></span>| <span data-ttu-id="4158a-167">0 から始まるインデックスによって識別される、セッションに追加するユーザーを表すその他のオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="4158a-167">Other objects that represent users to add to the session, keyed by a zero-based index.</span></span> <span data-ttu-id="4158a-168">既にセッションには、メンバーが含まれている場合でも、要求内のメンバーの数は常に 0 を開始します。</span><span class="sxs-lookup"><span data-stu-id="4158a-168">The number of members in a request always starts with 0, even if the session already contains members.</span></span> <span data-ttu-id="4158a-169">メンバーは、要求で表示される順序でセッションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="4158a-169">Members are added to the session in the order in which they appear in the request.</span></span> <span data-ttu-id="4158a-170">メンバー プロパティは、ユーザーに属しているユーザーによってのみ設定できます。</span><span class="sxs-lookup"><span data-stu-id="4158a-170">Member properties can only be set by the user to whom they belong.</span></span> |
| <span data-ttu-id="4158a-171">サーバー</span><span class="sxs-lookup"><span data-stu-id="4158a-171">servers</span></span> | <span data-ttu-id="4158a-172">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="4158a-172">object</span></span>| <span data-ttu-id="4158a-173">関連付けられているサーバーの参加要素のセットに更新プログラム、セッションに追加されたものを示す値。</span><span class="sxs-lookup"><span data-stu-id="4158a-173">Values indicating updates and additions to the session's set of associated server participants.</span></span> <span data-ttu-id="4158a-174">サーバーが null として指定されている場合、そのサーバーのエントリは、セッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="4158a-174">If a server is specified as null, that server entry is removed from the session.</span></span> |



```cpp
{
  "properties": {
    "custom": {"KANWE": "MGMSY"},
    "system": {}
  },
  "constants": {
    "custom": {},
    "system": {"visibility": "open"}
  },
  "members": {
    "reserve_0": {
    "constants": {
      "custom": {"type": "leader"},
      "system": {"xuid": "5500461"} }}
   }
}

```


<a id="ID4E4C"></a>


## <a name="response-body"></a><span data-ttu-id="4158a-175">応答本文</span><span class="sxs-lookup"><span data-stu-id="4158a-175">Response body</span></span>

<span data-ttu-id="4158a-176">作成またはセッションに参加するためのサンプルの応答本文:</span><span class="sxs-lookup"><span data-stu-id="4158a-176">Sample response body for creating or joining a session:</span></span>


```cpp
{
  "contractVersion": 104,
  "correlationId": "0FE81338-EE96-46E3-A3B5-2DBBD6C41C3B",
  "nextTimer": "2009-06-15T13:45:30.0900000Z",

  "initializing": {
    "stage": "measuring",
    "stageStartTime": "2009-06-15T13:45:30.0900000Z",
    "episode": 1
  },

  "hostCandidates": [ "ab90a362", "99582e67" ],

  "constants": {
    "system": {"visibility": "open"},
    "custom": {}
  },

  "properties": {
     "system": { "turn": [] },
     "custom": { "myProperty": "myValue" }
  },

  "members": {
      "1": {
        "properties": {
        "system": { },
        "custom": { }
      },

      "constants": {
        "system": { "xuid": "5500461" },
        "custom": { }
      }

      "gamertag": "stacy",
      "deviceToken": "9f4032ba7",
      "reserved": true,
      "activeTitleId": "8397267",
      "joinTime": "2009-06-15T13:45:30.0900000Z",
      "turn": true,
      "initializationFailure": "latency",
      "initializationEpisode": 1,
      "next": 4
    },
  },

  "membersInfo": {
      "first": 1,
      "next": 4,
      "count": 1,
      "accepted": 0
  },

  "servers": {
      "name": {
        "constants": { },
        "properties": { }
      }
  }
}

```


<a id="ID4EID"></a>


## <a name="see-also"></a><span data-ttu-id="4158a-177">関連項目</span><span class="sxs-lookup"><span data-stu-id="4158a-177">See also</span></span>

<a id="ID4EKD"></a>


##### <a name="parent"></a><span data-ttu-id="4158a-178">Parent</span><span class="sxs-lookup"><span data-stu-id="4158a-178">Parent</span></span>

[<span data-ttu-id="4158a-179">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="4158a-179">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)
