---
title: SessionEntry (JSON)
assetID: b5cf5c3d-83b8-635f-d1a5-0be5d9434ea5
permalink: en-us/docs/xboxlive/rest/json-sessionentry.html
description: " SessionEntry (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 73133f898ff219477cb60f54798cbd81acb87ebe
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589737"
---
# <a name="sessionentry-json"></a>SessionEntry (JSON)
フィットネス セッションにはデータが含まれます。 
<a id="ID4EN"></a>

 
## <a name="sessionentry"></a>SessionEntry
 
SessionEntry オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| durationInSeconds| 32 ビット符号付き整数 | 期間: 秒単位で、セッションのです。 | 
| コンセント| 32 ビット符号付き整数 | エネルギー —、コンセントで、セッションに書き込みます。 | 
| 満たされる| 単精度浮動小数点数| 平均では、セッションの期間にわたって値が満たされます。 MET 値は、保存時の個々 の代謝率の基準としたアクティビティの中に、個々 の代謝レートの比率です。 代謝のレートを置くは、個々 の重みに関係なく 1.0 MET 値は、個々 の配置されている代謝率の基準としたためは、さまざまな重みの個人によって実行されるアクティビティの強度を比較に使用できます。| 
| serverTimestamp| DateTime| 時間: UTC に基づいています: サーバーにエントリが入力されました。 | 
| ソース| 8 ビット符号なし整数| セッションのソース。| 
| タイムスタンプ| DateTime| 時間-世界協定時刻 (UTC) に基づいて、クライアントのエントリが作成されました。 | 
| titleId| 64 ビット符号なし整数| タイトル: 10 進数で、エントリを作成します。| 
  
<a id="ID4EFE"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   