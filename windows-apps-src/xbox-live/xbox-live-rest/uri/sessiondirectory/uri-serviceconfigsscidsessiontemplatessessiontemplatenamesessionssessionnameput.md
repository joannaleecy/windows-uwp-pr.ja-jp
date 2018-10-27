---
title: PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})
assetID: e3e4f164-ac5e-cbd9-8c05-2e1ac00dc55e
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.html
author: KevinAsgari
description: " PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 75c5e104add620c68f06a589be8f49f2a625de63
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5693863"
---
# <a name="put-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="9fe91-104">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="9fe91-104">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>
<span data-ttu-id="9fe91-105">作成、更新、またはセッションに参加します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-105">Creates, updates, or joins a session.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="9fe91-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要があります: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="9fe91-107">注釈</span><span class="sxs-lookup"><span data-stu-id="9fe91-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="9fe91-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9fe91-108">URI parameters</span></span>](#ID4EYB)
  * [<span data-ttu-id="9fe91-109">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="9fe91-109">HTTP status codes</span></span>](#ID4EFC)
  * [<span data-ttu-id="9fe91-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="9fe91-110">Request body</span></span>](#ID4EOC)
  * [<span data-ttu-id="9fe91-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="9fe91-111">Response body</span></span>](#ID4E4C)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="9fe91-112">注釈</span><span class="sxs-lookup"><span data-stu-id="9fe91-112">Remarks</span></span>

<span data-ttu-id="9fe91-113">この HTTP/REST メソッドでは、作成すると、参加、または同じ JSON 要求本文のテンプレートのサブセットを送信することによって、セッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-113">This HTTP/REST method creates, joins, or updates a session, depending on what subset of the same JSON request body template is sent.</span></span> <span data-ttu-id="9fe91-114">成功した場合、サーバーから返された応答を含む**MultiplayerSession**オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-114">On success, it returns a **MultiplayerSession** object containing the response returned from the server.</span></span> <span data-ttu-id="9fe91-115">その属性は、渡された**MultiplayerSession**オブジェクト内の属性から異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9fe91-115">The attributes in it might be different from the attributes in the passed-in **MultiplayerSession** object.</span></span> <span data-ttu-id="9fe91-116">このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="9fe91-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionAsync**.</span></span>

<span data-ttu-id="9fe91-117">セッションの作成と更新操作は、適用される変更を表すアプリケーション/json 本文と put メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-117">Session creation and update operations use PUT with an application/json body that represents the changes to apply.</span></span> <span data-ttu-id="9fe91-118">操作は、等は、同様の変更の複数のアプリケーションには追加の効果にありません。</span><span class="sxs-lookup"><span data-stu-id="9fe91-118">The operations are idempotent, that is, multiple applications of the same changes have no additional effect.</span></span>

<span data-ttu-id="9fe91-119">JSON 要求本文は、セッション データ構造体をミラー化します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-119">The JSON request body mirrors the session data structure.</span></span> <span data-ttu-id="9fe91-120">すべてのフィールドとサブ フィールドは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="9fe91-120">All fields and sub-fields are optional.</span></span>

<span data-ttu-id="9fe91-121">PUT メソッドのセッションの作成やモードへの参加ワイヤ形式は、次に示します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-121">The wire format for the PUT method's session creation or joining mode is shown below.</span></span>

> [!NOTE]
> <span data-ttu-id="9fe91-122">このパターンを使用して処理します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-122">Take care using this pattern.</span></span> <span data-ttu-id="9fe91-123">Upates セッションの現在の状態に関係なく、無条件に適用されます。</span><span class="sxs-lookup"><span data-stu-id="9fe91-123">Upates are applied blindly, no matter the current state of the session.</span></span>



```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
         Content-Type: application/json

```



<span data-ttu-id="9fe91-124">PUT メソッドのセッション更新のモードのワイヤ形式は、次に示します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-124">The wire format for the PUT method's session update mode is shown below.</span></span>

```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
         Content-Type: application/json

```



<span data-ttu-id="9fe91-125">セッションのプロパティを更新する PUT メソッドのワイヤ形式は、次に示します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-125">The wire format for the PUT method to update session properties is shown below.</span></span> <span data-ttu-id="9fe91-126">プロパティとして下にあるオブジェクトが何もしなくて本文ですセッション URI に PUT 操作に相当します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-126">It is equivalent to a PUT operation to the session URI with a body having nothing but the object below as properties.</span></span> <span data-ttu-id="9fe91-127">違いは、この操作に 404 のエラー コードが返されるセッションが存在しない場合に見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="9fe91-127">The difference is that this operation returns error code 404 Not Found if the session does not exist.</span></span> <span data-ttu-id="9fe91-128">この操作は、If-match ヘッダーをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="9fe91-128">This operation supports the If-Match header.</span></span>

```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001/properties HTTP/1.1
         Content-Type: application/json

         { "system": { }, "custom": { } }

```



<a id="ID4EYB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="9fe91-129">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9fe91-129">URI parameters</span></span>

| <span data-ttu-id="9fe91-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9fe91-130">Parameter</span></span>| <span data-ttu-id="9fe91-131">型</span><span class="sxs-lookup"><span data-stu-id="9fe91-131">Type</span></span>| <span data-ttu-id="9fe91-132">説明</span><span class="sxs-lookup"><span data-stu-id="9fe91-132">Description</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="9fe91-133">scid</span><span class="sxs-lookup"><span data-stu-id="9fe91-133">scid</span></span>| <span data-ttu-id="9fe91-134">GUID</span><span class="sxs-lookup"><span data-stu-id="9fe91-134">GUID</span></span>| <span data-ttu-id="9fe91-135">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="9fe91-135">Service configuration identifier (SCID).</span></span> <span data-ttu-id="9fe91-136">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="9fe91-136">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="9fe91-137">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="9fe91-137">sessionTemplateName</span></span>| <span data-ttu-id="9fe91-138">string</span><span class="sxs-lookup"><span data-stu-id="9fe91-138">string</span></span>| <span data-ttu-id="9fe91-139">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="9fe91-139">Name of the current instance of the session template.</span></span> <span data-ttu-id="9fe91-140">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="9fe91-140">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="9fe91-141">セッション名</span><span class="sxs-lookup"><span data-stu-id="9fe91-141">sessionName</span></span>| <span data-ttu-id="9fe91-142">GUID</span><span class="sxs-lookup"><span data-stu-id="9fe91-142">GUID</span></span>| <span data-ttu-id="9fe91-143">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="9fe91-143">Unique ID of the session.</span></span> <span data-ttu-id="9fe91-144">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="9fe91-144">Part 3 of the session identifier.</span></span>|

<a id="ID4EFC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="9fe91-145">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="9fe91-145">HTTP status codes</span></span>
<span data-ttu-id="9fe91-146">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-146">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EOC"></a>


## <a name="request-body"></a><span data-ttu-id="9fe91-147">要求本文</span><span class="sxs-lookup"><span data-stu-id="9fe91-147">Request body</span></span>

<span data-ttu-id="9fe91-148">以下の作成またはセッションに参加するためのサンプル要求本文です。</span><span class="sxs-lookup"><span data-stu-id="9fe91-148">Below is a sample request body for creating or joining a session.</span></span> <span data-ttu-id="9fe91-149">要求本文の次のメンバーは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="9fe91-149">The following members of the request body are optional.</span></span> <span data-ttu-id="9fe91-150">要求では、他の可能なすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="9fe91-150">All other possible members are prohibited in a request.</span></span>

| <span data-ttu-id="9fe91-151">メンバー</span><span class="sxs-lookup"><span data-stu-id="9fe91-151">Member</span></span>| <span data-ttu-id="9fe91-152">種類</span><span class="sxs-lookup"><span data-stu-id="9fe91-152">Type</span></span>| <span data-ttu-id="9fe91-153">説明</span><span class="sxs-lookup"><span data-stu-id="9fe91-153">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="9fe91-154">定数</span><span class="sxs-lookup"><span data-stu-id="9fe91-154">constants</span></span>| <span data-ttu-id="9fe91-155">object</span><span class="sxs-lookup"><span data-stu-id="9fe91-155">object</span></span>| <span data-ttu-id="9fe91-156">セッションの定数を生成するセッション テンプレートと結合された読み取り専用の設定。</span><span class="sxs-lookup"><span data-stu-id="9fe91-156">Read-only settings that are merged with the session template to produce the constants for the session.</span></span> |
| <span data-ttu-id="9fe91-157">プロパティ</span><span class="sxs-lookup"><span data-stu-id="9fe91-157">properties</span></span> | <span data-ttu-id="9fe91-158">object</span><span class="sxs-lookup"><span data-stu-id="9fe91-158">object</span></span> | <span data-ttu-id="9fe91-159">セッションのプロパティへの結合を変更します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-159">Changes to be merged into the session properties.</span></span>|
| <span data-ttu-id="9fe91-160">members.me</span><span class="sxs-lookup"><span data-stu-id="9fe91-160">members.me</span></span> | <span data-ttu-id="9fe91-161">object</span><span class="sxs-lookup"><span data-stu-id="9fe91-161">object</span></span>| <span data-ttu-id="9fe91-162">定数および機能もプロパティなどの最上位の相当します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-162">Constants and properties that work much like their top-level counterparts.</span></span> <span data-ttu-id="9fe91-163">PUT メソッドでは、セッションのメンバーであることをユーザーに要求し、必要に応じて、ユーザーを追加します。</span><span class="sxs-lookup"><span data-stu-id="9fe91-163">Any PUT method requires the user to be a member of the session, and adds the user if necessary.</span></span> <span data-ttu-id="9fe91-164">Null として"me"を指定する場合は、要求を行っているメンバーがセッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="9fe91-164">If "me" is specified as null, the member making the request is removed from the session.</span></span> |
| <span data-ttu-id="9fe91-165">メンバー</span><span class="sxs-lookup"><span data-stu-id="9fe91-165">members</span></span> | <span data-ttu-id="9fe91-166">object</span><span class="sxs-lookup"><span data-stu-id="9fe91-166">object</span></span>| <span data-ttu-id="9fe91-167">0 から始まるインデックスでキーを持つ、セッションに追加するユーザーを表すその他のオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="9fe91-167">Other objects that represent users to add to the session, keyed by a zero-based index.</span></span> <span data-ttu-id="9fe91-168">要求のメンバー数常に 0 から始まり、場合でも、既にセッションにはメンバーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="9fe91-168">The number of members in a request always starts with 0, even if the session already contains members.</span></span> <span data-ttu-id="9fe91-169">要求で表示される順序でセッションにメンバーが追加されます。</span><span class="sxs-lookup"><span data-stu-id="9fe91-169">Members are added to the session in the order in which they appear in the request.</span></span> <span data-ttu-id="9fe91-170">メンバーのプロパティは、先に属しているユーザーでのみ設定できます。</span><span class="sxs-lookup"><span data-stu-id="9fe91-170">Member properties can only be set by the user to whom they belong.</span></span> |
| <span data-ttu-id="9fe91-171">サーバー</span><span class="sxs-lookup"><span data-stu-id="9fe91-171">servers</span></span> | <span data-ttu-id="9fe91-172">object</span><span class="sxs-lookup"><span data-stu-id="9fe91-172">object</span></span>| <span data-ttu-id="9fe91-173">関連付けられているサーバーの参加者のセットに更新プログラムと、セッションに追加されたことを示す値。</span><span class="sxs-lookup"><span data-stu-id="9fe91-173">Values indicating updates and additions to the session's set of associated server participants.</span></span> <span data-ttu-id="9fe91-174">サーバーが null として指定されている場合、そのサーバーのエントリは、セッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="9fe91-174">If a server is specified as null, that server entry is removed from the session.</span></span> |



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


## <a name="response-body"></a><span data-ttu-id="9fe91-175">応答本文</span><span class="sxs-lookup"><span data-stu-id="9fe91-175">Response body</span></span>

<span data-ttu-id="9fe91-176">応答本文を作成またはセッションに参加するためにサンプル:</span><span class="sxs-lookup"><span data-stu-id="9fe91-176">Sample response body for creating or joining a session:</span></span>


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


## <a name="see-also"></a><span data-ttu-id="9fe91-177">関連項目</span><span class="sxs-lookup"><span data-stu-id="9fe91-177">See also</span></span>

<a id="ID4EKD"></a>


##### <a name="parent"></a><span data-ttu-id="9fe91-178">Parent</span><span class="sxs-lookup"><span data-stu-id="9fe91-178">Parent</span></span>

[<span data-ttu-id="9fe91-179">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="9fe91-179">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)
