---
title: PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})
assetID: e3e4f164-ac5e-cbd9-8c05-2e1ac00dc55e
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.html
author: KevinAsgari
description: " PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 92cf7ab408b14e74a8f231d6c81e3077a0a40be5
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4531185"
---
# <a name="put-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a>PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})
作成、更新、またはセッションに参加します。

> [!IMPORTANT]
> この URI メソッドには、X Xbl コントラクト バージョンのヘッダー要素が必要があります: 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EYB)
  * [HTTP ステータス コード](#ID4EFC)
  * [要求本文](#ID4EOC)
  * [応答本文](#ID4E4C)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、作成すると、途中参加、または同じ JSON 要求本文のテンプレートのサブセットが送信されるに応じて、セッションを更新します。 成功した場合、サーバーから返された応答を含む**MultiplayerSession**オブジェクトを返します。 その内の属性は、渡された**MultiplayerSession**オブジェクト内の属性から異なる可能性があります。 このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionAsync**でラップすることができます。

セッションの作成と更新操作は、適用される変更を表すアプリケーション/json 本文と put メソッドを使用します。 操作は、等は、同様の変更の複数のアプリケーションには追加の効果にありません。

JSON 要求本文には、セッション データ構造体がミラー化します。 すべてのフィールドとサブ フィールドは省略可能です。

PUT メソッドのセッションの作成やモードへの参加ワイヤ形式は、次に示します。

> [!NOTE]
> このパターンを使用して処理します。 Upates セッションの現在の状態に関係なく、無条件に適用されます。



```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
         Content-Type: application/json

```



PUT メソッドのセッション更新のモードのワイヤ形式は、次に示します。

```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
         Content-Type: application/json

```



セッションのプロパティを更新する PUT メソッドのワイヤ形式は、次に示します。 本文の下にあるオブジェクトがプロパティとしてしなくてセッション URI に PUT 操作するのと同じです。 違いは、この操作に 404 のエラー コードが返されるセッションが存在しない場合は見つかりませんでした。 この操作は、If-match ヘッダーをサポートしています。

```cpp
PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001/properties HTTP/1.1
         Content-Type: application/json

         { "system": { }, "custom": { } }

```



<a id="ID4EYB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- |
| scid| GUID| サービス構成 id (SCID)。 セッション識別子のパート 1 です。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 セッション識別子のパート 2 です。|
| セッション名| GUID| セッションの一意の ID。 セッション識別子のパート 3 です。|

<a id="ID4EFC"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される HTTP ステータス コードを返します。  
<a id="ID4EOC"></a>


## <a name="request-body"></a>要求本文

以下の作成またはセッションに参加するためのサンプル要求本文です。 要求本文の次のメンバーは省略可能です。 要求では、他の可能なすべてのメンバーが禁止されています。

| メンバー| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- |
| 定数| object| セッションの定数を生成するセッション テンプレートと結合された読み取り専用の設定。 |
| プロパティ | object | セッションのプロパティへの結合を変更します。|
| members.me | object| 定数および機能もプロパティなどのトップレベルの対応します。 PUT メソッドでは、ユーザーが、セッションのメンバーである必要があり、必要に応じて、ユーザーを追加します。 Null として"me"を指定する場合は、要求を行っているメンバーがセッションから削除されます。 |
| メンバー | object| 0 から始まるインデックスでキーを持つ、セッションに追加するユーザーを表すその他のオブジェクト。 要求のメンバー数常に 0 から始まり、場合でも、既にセッションにはメンバーが含まれています。 要求で表示される順序でセッションにメンバーが追加されます。 メンバーのプロパティは、先に属しているユーザーでのみ設定できます。 |
| サーバー | object| 関連付けられているサーバーの参加者のセットに更新プログラムと、セッションに追加されたことを示す値。 サーバーが null として指定されている場合、そのサーバーのエントリは、セッションから削除されます。 |



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

応答の本文を作成またはセッションに参加するためにサンプル:


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
