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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608307"
---
# <a name="aggregatesessionsresponse-json"></a>AggregateSessionsResponse (JSON)
ユーザーのフィットネス セッションの集計データが含まれています。 
<a id="ID4EN"></a>

 
## <a name="aggregatesessionsresponse"></a>AggregateSessionsResponse
 
AggregateSessionsResponse オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| totalDurationInSeconds| 64 ビット符号付き整数| 集計期間 (秒) のセッションの合計継続時間。| 
| totalJoules| 64 ビット符号付き整数| 燃焼されるエネルギーの合計: の単位はジュール: 集計期間にわたるします。 | 
| totalSessions| 64 ビット符号付き整数| 集計期間にわたるセッションの合計数。| 
| weightedAverageMets| 単精度浮動小数点数 | 加重平均代謝値と等価のタスク (MET) 集計期間。 MET 値は、保存時の個々 の代謝率の基準としたアクティビティの中に、個々 の代謝レートの比率です。 代謝のレートを置くは、個々 の重みに関係なく 1.0 MET 値は、個々 の配置されている代謝率の基準としたためは、さまざまな重みの個人によって実行されるアクティビティの強度を比較に使用できます。| 
  
<a id="ID4ESC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   