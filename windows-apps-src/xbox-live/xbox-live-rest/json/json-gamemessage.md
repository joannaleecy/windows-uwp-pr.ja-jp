---
title: GameMessage (JSON)
assetID: c11606e6-701f-5807-4aef-5608c98ad831
permalink: en-us/docs/xboxlive/rest/json-gamemessage.html
author: KevinAsgari
description: " GameMessage (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 089d2a492c8878e79bd60de1226c948e1eee7e0f
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4620580"
---
# <a name="gamemessage-json"></a>GameMessage (JSON)
ゲーム セッションのメッセージ キューにメッセージのデータを定義する JSON オブジェクト。 
<a id="ID4EN"></a>

  
 
GameMessage JSON オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| data| 8 ビットの符号なし整数の配列| ゲームのクライアントが他のゲームのクライアントに送信する必要がある Base64 でエンコードされたデータ。 この値は、サーバーに不透明です。 | 
| senderXuid| 64 ビットの符号なし整数| メッセージを送信するプレイヤーの Xbox ユーザー ID です。 | 
| シーケンス番号| 32 ビット符号付き整数| ゲームのメッセージのシーケンス番号。 この値は、サーバーが割り当てられます。 シーケンス番号を単調に増加することが保証連続することができない可能性があります。 シーケンス番号が一意メッセージ キュー内では、メッセージ キュー間ではなくします。 | 
| queueIndex| 32 ビット符号付き整数| メッセージのセッション メッセージ キューのインデックス。 使用可能な値は、0 ~ 3 です。| 
| タイムスタンプ| DateTime| サーバーは、UTC で、ゲームのメッセージをキューに作成されたときの時間。 | 
  
<a id="ID4ERC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
    "queueIndex": 0,
    "sequenceNumber": 5,
    "senderXuid": 65536,
    "timestamp": "2011-06-23T18:49:50Z",
    "data": null
}
    
```

  
<a id="ID4E1C"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E3C"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EGD"></a>

 
##### <a name="reference"></a>リファレンス 

[GameSession (JSON)](json-gamesession.md)

   