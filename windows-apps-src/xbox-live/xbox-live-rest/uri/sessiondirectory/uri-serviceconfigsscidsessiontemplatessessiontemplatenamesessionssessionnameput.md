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
# <a name="put-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a>PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})
作成、更新、またはセッションに参加します。

> [!IMPORTANT]
> この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EYB)
  * [HTTP 状態コード](#ID4EFC)
  * [要求本文](#ID4EOC)
  * [応答本文](#ID4E4C)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドを作成、結合、または同じ JSON 要求本文のテンプレートのサブセットを送信することによって、セッションを更新します。 成功した場合を返します、 **MultiplayerSession**サーバーから返された応答を含むオブジェクトします。 属性が属性に渡されるで異なる可能性があります**MultiplayerSession**オブジェクト。 このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionAsync**します。

セッションの作成と更新操作では、適用する変更を表すアプリケーション/json 本文を含む PUT を使用します。 操作はべき等であるは、同じ変更の複数のアプリケーション追加効果ありません。

JSON 要求本文には、セッションのデータ構造がミラー化します。 すべてのフィールドとサブ フィールドは省略可能です。

PUT メソッドのセッションの作成または結合モードのワイヤ形式は、以下に示します。

> [!NOTE]
> このパターンを使用して処理します。 Upates 盲目的にセッションの現在の状態に関係なく適用されます。



```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
         Content-Type: application/json

```



PUT メソッドのセッションの更新モードのワイヤ形式は、以下に示します。

```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
         Content-Type: application/json

```



セッションのプロパティを更新する PUT メソッドのワイヤ形式は、以下に示します。 プロパティとして持つが下にあるオブジェクトの本文はセッション URI に PUT 操作と同等です。 違いは、この操作がエラー コード 404 を返すことをセッションが存在しない場合に見つかりません。 この操作は、If-match ヘッダーをサポートします。

```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001/properties HTTP/1.1
         Content-Type: application/json

         { "system": { }, "custom": { } }

```



<a id="ID4EYB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- |
| scid| GUID| サービス構成の識別子 (SCID) です。 パート 1 のセッション識別子。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 パート 2 のセッション識別子。|
| セッション名| GUID| セッションの一意の ID。 パート 3 のセッション識別子。|

<a id="ID4EFC"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EOC"></a>


## <a name="request-body"></a>要求本文

作成またはセッションに参加するためのサンプル要求本文を次に示します。 要求本文の次のメンバーは省略可能です。 要求では、他のすべての可能なメンバーが禁止されています。

| メンバー| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- |
| 定数| オブジェクト| セッションの定数を生成するためにセッションのテンプレートとマージする読み取り専用の設定。 |
| プロパティ | オブジェクト | セッションのプロパティへの結合を変更します。|
| members.me | オブジェクト| 定数とよくプロパティなどの最上位レベルの対応します。 PUT メソッドは、ユーザー、セッションのメンバーである必要があり、必要に応じて、ユーザーを追加します。 "Me"が null として指定されている場合は、要求を行うメンバーが、セッションから削除されます。 |
| メンバー | オブジェクト| 0 から始まるインデックスによって識別される、セッションに追加するユーザーを表すその他のオブジェクト。 既にセッションには、メンバーが含まれている場合でも、要求内のメンバーの数は常に 0 を開始します。 メンバーは、要求で表示される順序でセッションに追加されます。 メンバー プロパティは、ユーザーに属しているユーザーによってのみ設定できます。 |
| サーバー | オブジェクト| 関連付けられているサーバーの参加要素のセットに更新プログラム、セッションに追加されたものを示す値。 サーバーが null として指定されている場合、そのサーバーのエントリは、セッションから削除されます。 |



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


## <a name="response-body"></a>応答本文

作成またはセッションに参加するためのサンプルの応答本文:


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


## <a name="see-also"></a>関連項目

<a id="ID4EKD"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)
