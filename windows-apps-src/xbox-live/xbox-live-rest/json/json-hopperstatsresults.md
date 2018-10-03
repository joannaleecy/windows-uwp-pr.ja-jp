---
title: HopperStatsResults (JSON)
assetID: 91927da1-2e97-f7bc-ae62-7e0e9966b98e
permalink: en-us/docs/xboxlive/rest/json-hopperstatsresults.html
author: KevinAsgari
description: " HopperStatsResults (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 17b6bf856dd87abc72a000cb92724baf91452d73
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4265520"
---
# <a name="hopperstatsresults-json"></a>HopperStatsResults (JSON)
ホッパーの統計情報を表す JSON オブジェクト。 
<a id="ID4EN"></a>

  
 
HopperStatsResults JSON オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| hopperName| string| 選択したホッパーの名前です。| 
| 待機時間| 32 ビット符号付き整数| 照合時間 (秒の整数)、ホッパーの平均です。 | 
| カタログの作成| 32 ビット符号付き整数| 一致するものをホッパーで待機しているユーザーの数。| 
  
<a id="ID4EW"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例 
 

```json
{
      "hopperName":"contosoawesome2",
      "waitTime":30,
      "population":1
    }
  
    
```

  
<a id="ID4EGB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIB"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EUB"></a>

 
##### <a name="reference"></a>リファレンス 

[GET (/serviceconfigs/{scid}/hoppers/{name}/stats)](../uri/matchtickets/uri-serviceconfigsscidhoppershoppernamestatsget.md)

   