---
title: GameMessage (JSON)
assetID: c11606e6-701f-5807-4aef-5608c98ad831
permalink: en-us/docs/xboxlive/rest/json-gamemessage.html
description: " GameMessage (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a2bddd9e26b4716fd1e33c4b5bbde56672b5d3f8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651297"
---
# <a name="gamemessage-json"></a>GameMessage (JSON)
ゲーム セッションのメッセージ キューでメッセージのデータを定義する JSON オブジェクト。 
<a id="ID4EN"></a>

  
 
GameMessage JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| データ| 8 ビット符号なし整数の配列| ゲームのクライアントが他のゲームのクライアントに送信する必要がある Base64 でエンコードされたデータ。 この値は、サーバーに対して非透過的です。 | 
| senderXuid| 64 ビット符号なし整数| メッセージを送信する、プレーヤーの Xbox ユーザー ID。 | 
| SequenceNumber| 32 ビット符号付き整数| ゲームのメッセージのシーケンス番号。 この値は、サーバーによって割り当てられます。 シーケンス番号を単調に増加することが保証されますが、連続することができない可能性があります。 シーケンス番号が一意のメッセージ キュー間ではなくが、メッセージ キュー内で。 | 
| queueIndex| 32 ビット符号付き整数| メッセージのセッションのメッセージ キューのインデックス。 使用可能な値は、0 ~ 3 です。| 
| タイムスタンプ| DateTime| 時刻 (utc)、サーバーによって、ゲームのメッセージのキューの作成時にします。 | 
  
<a id="ID4ERC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EGD"></a>

 
##### <a name="reference"></a>リファレンス 

[GameSession (JSON)](json-gamesession.md)

   