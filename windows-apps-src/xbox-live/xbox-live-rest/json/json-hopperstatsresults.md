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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881883"
---
# <a name="hopperstatsresults-json"></a>HopperStatsResults (JSON)
ホッパーの統計情報を表す JSON オブジェクト。 
<a id="ID4EN"></a>

  
 
HopperStatsResults JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| 呼び出します| string| 選択したホッパーの名前です。| 
| 待機時間| 32 ビットの符号付き整数| 照合時間 (秒の整数)、ホッパーの平均です。 | 
| 高コスト| 32 ビットの符号付き整数| ホッパーでマッチを待っているユーザーの数。| 
  
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

[JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EUB"></a>

 
##### <a name="reference"></a>リファレンス 

[取得する (/serviceconfigs//hoppers/name {/統計)](../uri/matchtickets/uri-serviceconfigsscidhoppershoppernamestatsget.md)

   