---
title: Player (JSON)
assetID: eaf6d082-869b-d2d3-d548-5cef65e54541
permalink: en-us/docs/xboxlive/rest/json-player.html
description: " Player (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a5967cbfecd47c5675926bd45939442c45dda7b6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622497"
---
# <a name="player-json"></a>Player (JSON)
プレーヤーのゲームのセッションでデータを格納します。 
<a id="ID4EN"></a>

 
## <a name="player"></a>プレイヤー
 
Player オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| customData| 8 ビット符号なし整数の配列| プレーヤーのゲームに固有のデータを 1024 バイトの Base64 にエンコードされます。 この値は、サーバーに対して非透過的です。| 
| ゲーマータグ| string| ゲーマータグ — 15 文字の最大値-プレーヤーの。 クライアントは、プレーヤーを識別するときに、UI にこの値を使用する必要があります。 | 
| isCurrentlyInSession| ブール値| プレーヤーをセッションで現在使用されて、セッションのままかを示します。| 
| seatIndex| 32 ビット符号付き整数| セッションでプレイヤーのインデックス。| 
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID)、プレイヤーの。| 
  
<a id="ID4E3C"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
    "xuid": 2533274790412952,
    "gamertag":"MyTestUser",
    "seatindex": 3
    "customData":"AIHJ2?iE?/jiKE!l5S=T..."
    "isCurrentlyInSession":"true"
}
    
```

  
<a id="ID4EFD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EHD"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ERD"></a>

 
##### <a name="reference"></a>リファレンス 

[GameSession (JSON)](json-gamesession.md)

   