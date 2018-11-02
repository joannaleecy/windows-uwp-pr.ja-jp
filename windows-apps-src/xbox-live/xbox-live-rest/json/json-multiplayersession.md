---
title: MultiplayerSession (JSON)
assetID: d013af81-bfbf-c50a-5696-2bb561448616
permalink: en-us/docs/xboxlive/rest/json-multiplayersession.html
author: KevinAsgari
description: " MultiplayerSession (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3ece4cc753bcaf10b3e9ff36543647515891464a
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5919976"
---
# <a name="multiplayersession-json"></a><span data-ttu-id="2f09b-104">MultiplayerSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="2f09b-104">MultiplayerSession (JSON)</span></span>
<span data-ttu-id="2f09b-105">**MultiplayerSession**を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="2f09b-105">A JSON object representing the **MultiplayerSession**.</span></span> 
<a id="ID4EQ"></a>

  
 
<span data-ttu-id="2f09b-106">MultiplayerSession JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="2f09b-106">The MultiplayerSession JSON object has the following specification.</span></span>
 
| <span data-ttu-id="2f09b-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="2f09b-107">Member</span></span>| <span data-ttu-id="2f09b-108">種類</span><span class="sxs-lookup"><span data-stu-id="2f09b-108">Type</span></span>| <span data-ttu-id="2f09b-109">説明</span><span class="sxs-lookup"><span data-stu-id="2f09b-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2f09b-110">定数</span><span class="sxs-lookup"><span data-stu-id="2f09b-110">constants</span></span>| <span data-ttu-id="2f09b-111">object</span><span class="sxs-lookup"><span data-stu-id="2f09b-111">object</span></span>| <span data-ttu-id="2f09b-112">セッションの定数を生成するセッション テンプレートと結合された読み取り専用の設定。</span><span class="sxs-lookup"><span data-stu-id="2f09b-112">Read-only settings that are merged with the session template to produce the constants for the session.</span></span> | 
| <span data-ttu-id="2f09b-113">プロパティ</span><span class="sxs-lookup"><span data-stu-id="2f09b-113">properties</span></span> | <span data-ttu-id="2f09b-114">object</span><span class="sxs-lookup"><span data-stu-id="2f09b-114">object</span></span> | <span data-ttu-id="2f09b-115">セッションのプロパティへの結合を変更します。</span><span class="sxs-lookup"><span data-stu-id="2f09b-115">Changes to be merged into the session properties.</span></span>| 
| <span data-ttu-id="2f09b-116">members.me</span><span class="sxs-lookup"><span data-stu-id="2f09b-116">members.me</span></span> | <span data-ttu-id="2f09b-117">object</span><span class="sxs-lookup"><span data-stu-id="2f09b-117">object</span></span>| <span data-ttu-id="2f09b-118">定数および機能もプロパティなどの最上位の相当します。</span><span class="sxs-lookup"><span data-stu-id="2f09b-118">Constants and properties that work much like their top-level counterparts.</span></span> <span data-ttu-id="2f09b-119">PUT メソッドでは、セッションのメンバーであることをユーザーに要求し、必要に応じて、ユーザーを追加します。</span><span class="sxs-lookup"><span data-stu-id="2f09b-119">Any PUT method requires the user to be a member of the session, and adds the user if necessary.</span></span> <span data-ttu-id="2f09b-120">Null として"me"を指定する場合は、要求を行っているメンバーがセッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="2f09b-120">If "me" is specified as null, the member making the request is removed from the session.</span></span> | 
| <span data-ttu-id="2f09b-121">メンバー</span><span class="sxs-lookup"><span data-stu-id="2f09b-121">members</span></span> | <span data-ttu-id="2f09b-122">object</span><span class="sxs-lookup"><span data-stu-id="2f09b-122">object</span></span>| <span data-ttu-id="2f09b-123">0 から始まるインデックスでキーを持つ、セッションに追加するユーザーを表すその他のオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="2f09b-123">Other objects that represent users to add to the session, keyed by a zero-based index.</span></span> <span data-ttu-id="2f09b-124">要求のメンバー数常に 0 から始まり、場合でも、既にセッションにはメンバーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2f09b-124">The number of members in a request always starts with 0, even if the session already contains members.</span></span> <span data-ttu-id="2f09b-125">要求で表示される順序でセッションにメンバーが追加されます。</span><span class="sxs-lookup"><span data-stu-id="2f09b-125">Members are added to the session in the order in which they appear in the request.</span></span> <span data-ttu-id="2f09b-126">メンバーのプロパティは、先に属しているユーザーでのみ設定できます。</span><span class="sxs-lookup"><span data-stu-id="2f09b-126">Member properties can only be set by the user to whom they belong.</span></span> | 
| <span data-ttu-id="2f09b-127">サーバー</span><span class="sxs-lookup"><span data-stu-id="2f09b-127">servers</span></span> | <span data-ttu-id="2f09b-128">object</span><span class="sxs-lookup"><span data-stu-id="2f09b-128">object</span></span>| <span data-ttu-id="2f09b-129">関連付けられているサーバーの参加者のセットに更新プログラムと、セッションに追加されたことを示す値。</span><span class="sxs-lookup"><span data-stu-id="2f09b-129">Values indicating updates and additions to the session's set of associated server participants.</span></span> <span data-ttu-id="2f09b-130">サーバーが null として指定されている場合、そのサーバーのエントリは、セッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="2f09b-130">If a server is specified as null, that server entry is removed from the session.</span></span> | 
  
<a id="ID4EZ"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="2f09b-131">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="2f09b-131">Sample JSON syntax</span></span>
 

```json
{
      "properties": {
        "system": {
          "turn": []
        },
        "custom": {
          "KANWE": "MGMSY"
        }
      },
      "constants": {
        "system": {
          "visibility": "open"
        },
        "custom": {}
      },
      "servers": {},
      "members": {
        "first": 0,
        "end": 1,
        "count": 1,
        "accepted": 0,
        "0": {
          "next": 1,
          "pending": true,
          "properties": {
            "system": {},
            "custom": {}
          },
          "constants":  {
            "system": {
              "xuid": 5500461
            },
            "custom": {
              "8216": "WXMRJ"
            }
          }
        }
      },
      "key": "8d050174-412b-4d51-a29b-d55a34edfdb7~integration~bcd0088d76a94c60be4b75f139243a1f"
    }
  
    
```

  
<a id="ID4EHB"></a>

 
## <a name="request-structure"></a><span data-ttu-id="2f09b-132">要求の構造</span><span class="sxs-lookup"><span data-stu-id="2f09b-132">Request Structure</span></span>
<span data-ttu-id="2f09b-133">この JSON 仕様に関連付けられている要求の構造、 [MultiplayerSessionRequest (JSON)](json-multiplayersessionrequest.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2f09b-133">For the request structure associated with this JSON specification, see [MultiplayerSessionRequest (JSON)](json-multiplayersessionrequest.md).</span></span>  
<a id="ID4EPB"></a>

 
## <a name="response-structure"></a><span data-ttu-id="2f09b-134">応答構造</span><span class="sxs-lookup"><span data-stu-id="2f09b-134">Response Structure</span></span>
 

```json
{
  // The contract version of this rendering of the session. A function of the contract version of the request and constants/system/version.
  "contractVersion": 107,

  // The branch and change number of the session as of this rendering.
  "branch": "bd6c41c3-01c3-468a-a3b5-3e0fe8133862",
  "changeNumber": 5,

  // Use for tracing.
  // If an empty session is deleted and then restarted, the correlation ID will remain the same.
  "correlationId": "0fe81338-ee96-46e3-a3b5-2dbbd6c41c3b",

  // The time that the session began.
  // If an empty session is deleted and then restarted, this time will be the time of the restart.
  "startTime": "2009-06-15T13:45:30.0900000Z",

  // If any timeouts are in progress, this is the time that the next one will fire.
  "nextTimer": "2009-06-15T13:45:30.0900000Z",

  // Present during member initialization.
  // The "stage" goes from "joining" to "measuring" to "evaluating".
  // If episode #1 fails, then "stage" is set to "failed" and the session cannot be initialized.
  // Otherwise, when an initialization episode completes, the "initializing" object is removed.
  // If "autoEvaluate" is set, "evaluating" is skipped. If neither "metrics" nor "measurementServerAddresses" is set, "measuring" is skipped.
  "initializing": {
    "stage": "measuring",
    "stageStartTime": "2009-06-15T13:45:30.0900000Z",
    "episode": 1
  },

  // Set after the "measuring" stage of initialization episode #1, if "peerToHostRequirements" is set and no /properties/system/host is set.
  // Cleared once a /properties/system/host is set.
  // Host candidates are device tokens listed in order, order of preference.
  "hostCandidates": [ "ab90a362", "99582e67" ],

  "constants": { /* Property Bag */ },
  "properties": { /* Property Bag */ },

  "members": {
    // On large sessions, at most one entry is present, "me".
    "1": {
      "constants": { /* Property Bag */ },
      "properties": { /* Property Bag */ },
      // Only if the member has accepted. Optional (not set if no gamertag claim was found).
      "gamertag": "stacy",
      // This is set when the member uploads a secure device address. It's a case-insensitive string that can be used for equality comparisons.
      "deviceToken": "9f4032ba7",
      // This is set to "open", "moderate", or "strict" when the member uploads a V1.x secure device address.
      "nat": "strict",
      // This value is removed once the user does their first PUT to the session.
      "reserved": true,
      // If the member is active, this is the title in which they are active, in decimal.
      "activeTitleId": "8397267",
      // The time the user joined the session. If "reserved" is true, the time the reservation was made.
      "joinTime": "2009-06-15T13:45:30.0900000Z",
      // Present if this member is in the /properties/system/turn array, otherwise not.
      "turn": true,

      // Set when transitioning out of the "joining" or "measuring" stage if this member doesn't pass.
      // In order of precedence, could be set to "timeout", "latency", "bandwidthdown", "bandwidthup", "network", "group", or "episode".
      // The "network" value means the network configuration and/or conditions (such as conflicting NAT) prevented the QoS metrics from being measured.
      // The only possible value at the end of "joining" is "group". (On timeout from "joining", the reservation is removed.)
      // The "episode" value is set after a failed "evaluation" stage on all members of the initialization episode that didn't fail during "joining" or "measuring".
      "initializationFailure": "latency",

      // If "memberInitialization" is set and the member was added with "initialize": true, this is set to the initialization episode that the member will participate in.
      // One is a special value used for the members added to a new session at create time.
      // Removed when the initialization episode ends.
      "initializationEpisode": 1,

      // The next member's index, which is the same as 'next' below if there's no more.
      "next": 4
    },
    "4": { "next": 5 /* etc */ }
  },

  "membersInfo": {
    "first": 1,  // The first member's index.
    "next": 5,  // The index that the next member added will get.
    "count": 2,  // The number of members.
    "accepted": 1  // The number of members that are no longer 'reserved'.
  },

  "servers": {
    "name": {
      "constants": { /* Property Bag */ },
      "properties": { /* Property Bag */ }
    }
  }
}
    
```

  
<a id="ID4EWB"></a>

 
## <a name="see-also"></a><span data-ttu-id="2f09b-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="2f09b-135">See also</span></span>
 
<a id="ID4EYB"></a>

 
##### <a name="parent"></a><span data-ttu-id="2f09b-136">Parent</span><span class="sxs-lookup"><span data-stu-id="2f09b-136">Parent</span></span> 

[<span data-ttu-id="2f09b-137">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="2f09b-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   