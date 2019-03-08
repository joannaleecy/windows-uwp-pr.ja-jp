---
title: GameSessionSummary (JSON)
assetID: 50cf91ba-29d3-1260-7643-bcb3f8d74fc0
permalink: en-us/docs/xboxlive/rest/json-gamesessionsummary.html
description: " GameSessionSummary (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8dace19404ae7c8b1d1ef296a21c874e4dd14c6f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613387"
---
# <a name="gamesessionsummary-json"></a>GameSessionSummary (JSON)
ゲーム セッションの集計データを表す JSON オブジェクトです。 
<a id="ID4EN"></a>

  
 
GameSessionSummary JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| CreationTime| DateTime| 日付と時刻 (utc)、セッションの作成時にします。 | 
| customData| 8 ビット符号なし整数の配列| ゲームに固有のセッション データの 1024 バイト数。 この値は、サーバーに対して非透過的です。 | 
| displayName| string| 表示ゲームの名前のセッション、最大長が 128 文字です。 この値は、サーバーに対して非透過的です。 | 
| hasEnded| ブール値| セッションが終了した場合は true と false それ以外の場合。 さらにデータがセッションに送信されていることを防ぐ場合は true。 マークとして読み取り専用のゲーム セッションにこのフィールドを設定します。 | 
| sessionId| 文字列、セッション id。 | 
| titleId| 32 ビット符号なし整数| ゲーム セッションを作成するタイトルの ID。| 
| variant| 32 ビット符号付き整数| ゲームのバリアント。 この値は、サーバーに対して非透過的です。| 
  
<a id="ID4EID"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
    "sessionId": "702e5aaf-e7bd-4a7c-abea-9dd4be10edec",
    "titleId": 1297287259,
    "variant": 1,
    "displayName": "Contoso Cards",
    "creationTime": "2011-06-23T17:13:06Z",
    "customData": null,
    "hasEnded": false,
}
    
```

  
<a id="ID4ERD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ETD"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E4D"></a>

 
##### <a name="reference"></a>リファレンス 

[GameSession (JSON)](json-gamesession.md)

   