---
title: GameResult (JSON)
assetID: 43d863c0-2179-ae46-5d4a-2f08cd44b667
permalink: en-us/docs/xboxlive/rest/json-gameresult.html
author: KevinAsgari
description: " GameResult (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 24f5af1639f5348fe20c36c56c1301f723d832f7
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5171050"
---
# <a name="gameresult-json"></a>GameResult (JSON)
ゲーム セッションの結果を示すデータを表す JSON オブジェクト。 
<a id="ID4EN"></a>

  
 
GameResult JSON オブジェクトには、次のメンバーがあります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| blob| 8 ビットの符号なし整数の配列| タイトルに固有のカスタムの結果データ。| 
| 結果| string| ゲーム セッションにプレイヤーの参加の結果。 有効な値は、「獲得」、"Loss"または「結び付けられて」はします。 | 
| スコア| 64 ビットの符号付き整数| プレイヤーがゲーム セッションで受信スコアです。| 
| time| 64 ビットの符号付き整数| ゲーム セッションのプレイヤーの時間。| 
| xuid| 64 ビットの符号なし整数| 結果の適用先のプレイヤーの Xbox ユーザー ID です。| 
  
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

   