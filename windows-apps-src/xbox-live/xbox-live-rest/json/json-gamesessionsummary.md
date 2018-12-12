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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8935192"
---
# <a name="gamesessionsummary-json"></a>GameSessionSummary (JSON)
ゲーム セッションの集計データを表す JSON オブジェクト。 
<a id="ID4EN"></a>

  
 
GameSessionSummary JSON オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| creationTime| DateTime| 日付と時刻とき、セッションが作成された、UTC でします。 | 
| customData| 8 ビットの符号なし整数の配列| ゲーム固有のセッション データの 1024 バイトです。 この値は、サーバーに不透明です。 | 
| displayName| string| 表示名ゲームのセッション 128 文字の最大長を持つ。 この値は、サーバーに不透明です。 | 
| hasEnded| ブール値| セッションが終了した場合は true、それ以外の場合。 さらにデータが、セッションに送信されているように true マーク読み取り専用とゲーム セッションにこのフィールドを設定します。 | 
| sessionId| 文字列セッション id。 | 
| titleId| 32 ビットの符号なし整数| ゲーム セッションの作成、タイトルの ID です。| 
| variant| 32 ビット符号付き整数| ゲームのバリアントです。 この値は、サーバーに不透明です。| 
  
<a id="ID4EID"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E4D"></a>

 
##### <a name="reference"></a>リファレンス 

[GameSession (JSON)](json-gamesession.md)

   