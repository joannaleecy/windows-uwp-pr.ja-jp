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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57602337"
---
# <a name="gameresult-json"></a>GameResult (JSON)
ゲーム セッションの結果を説明するデータを表す JSON オブジェクトです。 
<a id="ID4EN"></a>

  
 
GameResult JSON オブジェクトには、次のメンバーがあります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| blob| 8 ビット符号なし整数の配列| カスタムのタイトルに固有の結果データです。| 
| 結果| string| プレーヤーのゲーム セッションへの参加の結果。 有効な値は、"Win"、「損失」または「結び付ける」です。 | 
| スコア| 64 ビット符号付き整数| プレーヤーがゲームのセッションで受信したスコアです。| 
| time| 64 ビット符号付き整数| ゲームのセッションのプレイヤーの時間。| 
| xuid| 64 ビット符号なし整数| 結果を適用する、プレーヤーの Xbox ユーザー ID。| 
  
<a id="ID4EPC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   