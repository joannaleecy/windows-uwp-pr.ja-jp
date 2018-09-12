---
title: AggregateSessionsResponse (JSON)
assetID: 020ee9b2-c96c-2e65-4e6d-f9f4bd25a374
permalink: en-us/docs/xboxlive/rest/json-aggregatesessionsresponse.html
author: KevinAsgari
description: " AggregateSessionsResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 42bf1a09144bec9cddda1ae2fd9656dc6dc8c51d
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881750"
---
# <a name="aggregatesessionsresponse-json"></a>AggregateSessionsResponse (JSON)
ユーザーの適合性のセッションは、集計されたデータが含まれています。 
<a id="ID4EN"></a>

 
## <a name="aggregatesessionsresponse"></a>AggregateSessionsResponse
 
AggregateSessionsResponse オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| totalDurationInSeconds| 64 ビットの符号付き整数| 集計期間を秒単位でセッションの合計期間です。| 
| totalJoules| 64 ビットの符号付き整数| 電力書き込みの合計-コンセントで-、集計期間。 | 
| totalSessions| 64 ビットの符号付き整数| 集計期間中のセッションの合計数。| 
| weightedAverageMets| 単精度浮動小数点数 | 加重平均代謝と同等の集計期間中のタスク (MET) の値。 MET 値は、残りの部分で個人の代謝レートを基準としたアクティビティ中に、個人の代謝レートの比率です。 静止代謝、レートが個人の太さに関係なく 1.0 MET 値は、個人の静止代謝レートを基準としたためは、さまざまな重みの人の従業員が実行しているアクティビティの強さを比較を使用できます。| 
  
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

[JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   