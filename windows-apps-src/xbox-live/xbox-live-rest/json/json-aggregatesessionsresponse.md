---
title: AggregateSessionsResponse (JSON)
assetID: 020ee9b2-c96c-2e65-4e6d-f9f4bd25a374
permalink: en-us/docs/xboxlive/rest/json-aggregatesessionsresponse.html
description: " AggregateSessionsResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ef026fd5096d047b2014faaf95a667c69827e043
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8332384"
---
# <a name="aggregatesessionsresponse-json"></a>AggregateSessionsResponse (JSON)
ユーザーの適合性のセッションの集計データが含まれています。 
<a id="ID4EN"></a>

 
## <a name="aggregatesessionsresponse"></a>AggregateSessionsResponse
 
AggregateSessionsResponse オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| totalDurationInSeconds| 64 ビットの符号付き整数| 集計期間を秒単位でセッションの合計期間です。| 
| totalJoules| 64 ビットの符号付き整数| エネルギーの書き込みの合計-コンセントで-集計期間中です。 | 
| totalSessions| 64 ビットの符号付き整数| 集計期間中のセッションの合計数。| 
| weightedAverageMets| 単精度浮動小数点数 | 加重平均代謝と同等の集計期間中のタスク (MET) の値。 MET 値は、アクティビティを残りの部分で個人の代謝レートを基準とした時に、個々 の代謝レートの比率です。 静止の代謝レートは、個々 の太さに関係なく 1.0 MET 値は、個々 のユーザーの静止代謝レートを基準としたためは、さまざまな重みの人の従業員が実行しているアクティビティの強さを比較する使用できます。| 
  
<a id="ID4ESC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
   "totalSessions" : 300,
   "totalDurationInSeconds" : 1240,
   "totalJoules" :  21600,
   "weightedAvgMet" : 21,
}

    
```

  
<a id="ID4E2C"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E4C"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   