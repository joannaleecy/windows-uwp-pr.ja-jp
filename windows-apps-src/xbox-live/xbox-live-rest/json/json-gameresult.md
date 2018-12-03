---
title: GameResult (JSON)
assetID: 43d863c0-2179-ae46-5d4a-2f08cd44b667
permalink: en-us/docs/xboxlive/rest/json-gameresult.html
description: " GameResult (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b408b1aaae5e6f54958a016575c4a2c37765f1e9
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8350752"
---
# <a name="gameresult-json"></a>GameResult (JSON)
ゲーム セッションの結果を示すデータを表す JSON オブジェクト。 
<a id="ID4EN"></a>

  
 
GameResult JSON オブジェクトには、次のメンバーがあります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| blob| 8 ビットの符号なし整数の配列| タイトルに固有のカスタムの結果データです。| 
| 結果| string| ゲーム セッションにプレイヤーの参加の結果。 有効な値は、"Win"、"Loss"または「結び付けられて」はします。 | 
| スコア| 64 ビットの符号付き整数| プレイヤーがゲーム セッションで受信スコアです。| 
| time| 64 ビットの符号付き整数| ゲーム セッションのプレイヤーの時間。| 
| xuid| 64 ビットの符号なし整数| 結果の適用先のプレイヤーの Xbox ユーザー ID。| 
  
<a id="ID4EPC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
   "xuid": 2533274790412952,
   "outcome": "Win",
   "score": 100
}
    
```

  
<a id="ID4EYC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E1C"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   