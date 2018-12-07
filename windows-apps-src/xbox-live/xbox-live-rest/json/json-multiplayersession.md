---
title: MultiplayerSession (JSON)
assetID: d013af81-bfbf-c50a-5696-2bb561448616
permalink: en-us/docs/xboxlive/rest/json-multiplayersession.html
description: " MultiplayerSession (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 32eca20af0714c5968cf51fcd568d89f2768f369
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8785961"
---
# <a name="multiplayersession-json"></a>MultiplayerSession (JSON)
**MultiplayerSession**を表す JSON オブジェクト。 
<a id="ID4EQ"></a>

  
 
MultiplayerSession JSON オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| 定数| object| セッションの定数を生成するセッション テンプレートと結合された読み取り専用の設定。 | 
| プロパティ | object | セッションのプロパティへの結合を変更します。| 
| members.me | object| 定数および機能もプロパティなどのトップレベルの相当します。 PUT メソッドでは、ユーザーが、セッションのメンバーである必要があり、必要に応じて、ユーザーを追加します。 "Me"が null として指定されている場合は、要求を行っているメンバーがセッションから削除されます。 | 
| メンバー | object| 0 から始まるインデックスを使用してキーを持つ、セッションに追加するユーザーを表すその他のオブジェクト。 既にセッションには、メンバーが含まれている場合でも、要求のメンバーの数は常に 0 で始まります。 メンバーは、要求で表示される順序でセッションに追加されます。 メンバーのプロパティは、先に属しているユーザーでのみ設定できます。 | 
| サーバー | object| 関連付けられているサーバーの参加者のセットに更新プログラムと、セッションに追加されたことを示す値。 サーバーが null として指定されている場合、そのサーバーのエントリは、セッションから削除されます。 | 
  
<a id="ID4EZ"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

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

 
## <a name="request-structure"></a>要求の構造
この JSON 仕様に関連付けられている要求の構造、 [MultiplayerSessionRequest (JSON)](json-multiplayersessionrequest.md)を参照してください。  
<a id="ID4EPB"></a>

 
## <a name="response-structure"></a>応答構造
 

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

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EYB"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   