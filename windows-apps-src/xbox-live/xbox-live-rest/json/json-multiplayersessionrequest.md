---
title: MultiplayerSessionRequest (JSON)
assetID: 2e311c6d-3427-5a39-1989-06dc08483057
permalink: en-us/docs/xboxlive/rest/json-multiplayersessionrequest.html
description: " MultiplayerSessionRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 18929c060adeae47f0305422dd312e7410f93981
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628347"
---
# <a name="multiplayersessionrequest-json"></a>MultiplayerSessionRequest (JSON)
操作の要求の JSON オブジェクトが渡される、 **MultiplayerSession**オブジェクト。 
<a id="ID4EQ"></a>

  
 
MultiplayerSessionRequest JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| 定数| オブジェクト| セッションの定数を生成するためにセッションのテンプレートとマージする読み取り専用の設定。 | 
| プロパティ | オブジェクト | セッションのプロパティへの結合を変更します。| 
| members.me | オブジェクト| 定数とよくプロパティなどの最上位レベルの対応します。 PUT メソッドは、ユーザー、セッションのメンバーである必要があり、必要に応じて、ユーザーを追加します。 "Me"が null として指定されている場合は、要求を行うメンバーが、セッションから削除されます。 | 
| メンバー | オブジェクト| 0 から始まるインデックスによって識別される、セッションに追加するユーザーを表すその他のオブジェクト。 既にセッションには、メンバーが含まれている場合でも、要求内のメンバーの数は常に 0 を開始します。 メンバーは、要求で表示される順序でセッションに追加されます。 メンバー プロパティは、ユーザーに属しているユーザーによってのみ設定できます。 | 
| サーバー | オブジェクト| 関連付けられているサーバーの参加要素のセットに更新プログラム、セッションに追加されたものを示す値。 サーバーが null として指定されている場合、そのサーバーのエントリは、セッションから削除されます。 | 
  
<a id="ID4EZ"></a>

 
## <a name="request-structure"></a>要求の構造
 

```json
{
  "constants": { /* Property Bag */ },
  "properties": { /* Property Bag */ },
  "members": {
    // Requires a service principal. Existing members can be deleted by index.
    // Not available on large sessions.
    "5": null,

    // Reservation requests must start with zero. New users will get added in order to the end of the session's member list.
    // Large sessions don't support reservations.
    "reserve_0": {
      "constants": { /* Property Bag */ }
    },
    "reserve_1": {
      "constants": { /* Property Bag */ }
    },

    // Requires a user principal with a xuid claim. Can be 'null' to remove myself from the session.
    "me": {
      "constants": { /* Property Bag */ },
      "properties": { /* Property Bag */ },
    }
  },

  // Requires a server principal.
  "servers": {
    // Can be any name. The value can be 'null' to remove the server from the session.
    "name": {
      "constants": {  /* Property Bag */ },
      "properties": {  /* Property Bag */ }
    }
  }
}
```

  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EMB"></a>

 
##### <a name="reference"></a>リファレンス 

[MultiplayerSession (JSON)](json-multiplayersession.md)

 [PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})](../uri/sessiondirectory/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.md)

   