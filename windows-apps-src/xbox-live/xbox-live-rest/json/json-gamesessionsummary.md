---
title: GameSessionSummary (JSON)
assetID: 50cf91ba-29d3-1260-7643-bcb3f8d74fc0
permalink: en-us/docs/xboxlive/rest/json-gamesessionsummary.html
author: KevinAsgari
description: " GameSessionSummary (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 610f771641352447f9d38fc4217231ba3230e6fb
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4502151"
---
# <a name="gamesessionsummary-json"></a>GameSessionSummary (JSON)
ゲーム セッションの集計データを表す JSON オブジェクト。 
<a id="ID4EN"></a>

  
 
GameSessionSummary JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| creationTime| DateTime| 日付と、セッションが作成された、UTC で。 | 
| customData| 8 ビットの符号なし整数の配列| ゲーム固有のセッション データの 1024 バイトです。 この値は、サーバーに不透明です。 | 
| displayName| string| 表示名ゲームのセッション 128 文字の最大長を持つ。 この値は、サーバーに不透明です。 | 
| hasEnded| ブール値| セッションが終了した場合は true、それ以外の場合。 さらにデータがセッションに送信されているように true マーク読み取り専用とゲーム セッションにこのフィールドを設定します。 | 
| sessionId| 文字列セッション id。 | 
| titleId| 32 ビット符号なし整数| ゲーム セッションの作成、タイトルの ID です。| 
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

   