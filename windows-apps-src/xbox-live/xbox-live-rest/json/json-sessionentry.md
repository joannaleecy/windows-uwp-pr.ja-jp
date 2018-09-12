---
title: SessionEntry (JSON)
assetID: b5cf5c3d-83b8-635f-d1a5-0be5d9434ea5
permalink: en-us/docs/xboxlive/rest/json-sessionentry.html
author: KevinAsgari
description: " SessionEntry (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6076f4dfbef0f926563f4696f8ee0e2660d0fc24
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881867"
---
# <a name="sessionentry-json"></a>SessionEntry (JSON)
フィットネス セッションは、データが含まれています。 
<a id="ID4EN"></a>

 
## <a name="sessionentry"></a>SessionEntry
 
SessionEntry オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| durationInSeconds| 32 ビットの符号付き整数 | 継続時間-秒単位で、セッションのします。 | 
| コンセント| 32 ビットの符号付き整数 | 電力-コンセントで-セッションに書き込みます。 | 
| 満たされています。| 単精度浮動小数点数| 平均には、セッションの期間の値が満たされています。 MET 値は、残りの部分で個人の代謝レートを基準としたアクティビティ中に、個人の代謝レートの比率です。 静止代謝、レートが個人の太さに関係なく 1.0 MET 値は、個人の静止代謝レートを基準としたためは、さまざまな重みの人の従業員が実行しているアクティビティの強さを比較を使用できます。| 
| serverTimestamp| DateTime| 時間: UTC に基づいて-エントリは、サーバーで入力されたものです。 | 
| ソース| 8 ビットの符号なし整数| セッションのソース。| 
| タイムスタンプ| DateTime| 時間: 協定世界時 (UTC) に基づく-エントリは、クライアントで作成されました。 | 
| titleId| 64 ビットの符号なし整数| タイトル: 10 進数で、エントリを作成します。| 
  
<a id="ID4EFE"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
   "titleId" : "1234567",
   "timestamp" : "2011-11-18T08:08:46Z",
   "serverTimestamp" : "2011-11-20T04:04:23Z",
   "durationInSeconds" : 240,
   "joules" :  1600,
   "met" :  "124"
   "source" :  "1"
}
    
```

  
<a id="ID4EOE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQE"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   