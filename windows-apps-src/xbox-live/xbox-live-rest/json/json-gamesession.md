---
title: GameSession (JSON)
assetID: 325af9ae-a9a9-5b36-8342-1aff5aff01d1
permalink: en-us/docs/xboxlive/rest/json-gamesession.html
description: " GameSession (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ca7276ccdc13d896d19873811b4fa9df9a831cd1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646517"
---
# <a name="gamesession-json"></a>GameSession (JSON)
マルチ プレーヤーのセッションのゲーム データを表す JSON オブジェクトです。 
<a id="ID4ER"></a>

  
 
GameSession JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| CreationTime| DateTime| 日付と時刻 (utc)、セッションの作成時にします。 | 
| customData| 8 ビット符号なし整数の配列| ゲームに固有のセッション データの 1024 バイト数。 この値は、サーバーに対して非透過的です。 | 
| displayName| string| 表示ゲームの名前のセッション、最大長が 128 文字です。 この値は、サーバーに対して非透過的です。 | 
| hasEnded| ブール値| セッションが終了した場合は true と false それ以外の場合。 さらにデータがセッションに送信されていることを防ぐ場合は true。 マークとして読み取り専用のゲーム セッションにこのフィールドを設定します。 | 
| IsClosed| ブール値| True の場合は、セッションが閉じられたでき、複数プレイヤー追加、および false それ以外の場合。 この値が true の場合は、セッションに参加する要求は拒否されます。 | 
| maxPlayers| 32 ビット符号付き整数| セッションを同時にすることができるプレーヤーの最大数。 値の範囲は、2 個から 16 です。 セッションには、プレーヤーの最大数が含まれていますとさらに、セッションに参加する要求は拒否されます。 | 
| playersCanBeRemovedBy| PlayerAcl| その他のプレイヤーをセッションから削除を許可されているプレーヤーを示す値。 指定できる値は取ります、Self、および AnyPlayer です。 | 
| 名簿| player オブジェクトの配列| セッションのプレイヤーの配列。 リストには、現在のプレーヤーとのセッションで以前が残っているプレイヤーが含まれています。 名簿のプレイヤーの順序は変更できません。 新しいプレーヤーは、配列の末尾に追加されます。 | 
| seatsAvailable| 32 ビット符号付き整数| プレーヤーの最大数に達する前にセッションに参加できますも選手の数。 この値は読み取り専用、常に maxPlayers フィールドの値より小さい。 | 
| sessionId| string| セッション ID、セッションが作成されたときに、MPSD によって割り当てられます。 この値にがセッションに格納されている情報にアクセスするときに、URI に通常含まれて。| 
| titleId| 32 ビット符号なし整数| ゲーム セッションを作成するタイトルの ID。| 
| variant| 32 ビット符号付き整数| ゲームのバリアント。 この値は、サーバーに対して非透過的です。| 
| visibility| VisibilityLevel| セッションの可視性を示す値。 設定可能な値は、次のとおりです。PlayersCurrentlyInSession、PlayersEverInSession、およびそのすべてのユーザー。| 
  
<a id="ID4EEF"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
    "sessionId": "702e5aaf-e7bd-4a7c-abea-9dd4be10edec",
    "titleId": 1297287259,
    "variant": 1,
    "displayName": "Contoso Cards",
    "creationTime": "2011-06-23T17:13:06Z",
    "customData": null,
    "maxPlayers": 4,
    "seatsAvailable": 4,
    "isClosed": false,
    "hasEnded": false,
    "roster": [],
    "visibility": "PlayersCurrentlyInSession",
    "playersCanBeRemovedBy": "Self",
 }
    
```

  
<a id="ID4ENF"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EPF"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EZF"></a>

 
##### <a name="reference"></a>リファレンス 

[GameMessage (JSON)](json-gamemessage.md)

 [GameSessionSummary (JSON)](json-gamesessionsummary.md)

 [プレーヤー (JSON)](json-player.md)

   