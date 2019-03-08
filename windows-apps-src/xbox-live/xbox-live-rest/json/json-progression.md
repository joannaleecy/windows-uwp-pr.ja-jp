---
title: Progression (JSON)
assetID: cdff6415-f12b-0a45-61f2-26dbf47b1b56
permalink: en-us/docs/xboxlive/rest/json-progression.html
description: " Progression (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dda124e5be9a4d21a1ee5b9d6130290207e31921
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593827"
---
# <a name="progression-json"></a>Progression (JSON)
ユーザーの行程アチーブメントのロックを解除します。 
<a id="ID4EN"></a>

 
## <a name="progression"></a>進行状況
 
プログレッション オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| 要件| 要件の配列| 実績を獲得するための要件とロックの解除には、ユーザーに沿った距離。| 
| timeUnlocked| DateTime| 実績が最初にロックされた時刻。| 
  
<a id="ID4ETB"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
  "requirements":
  [{
    "id":"12345678-1234-1234-1234-123456789012",
    "current":null,
    "target":"100"
  }],
  "timeUnlocked":"2013-01-17T03:19:00.3087016Z",
}
    
```

  
<a id="ID4E3B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E5B"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   