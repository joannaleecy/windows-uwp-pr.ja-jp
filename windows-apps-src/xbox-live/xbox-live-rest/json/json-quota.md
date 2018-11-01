---
title: quotaInfo (JSON)
assetID: 3147ab78-e671-e142-0a3a-688dc4079451
permalink: en-us/docs/xboxlive/rest/json-quota.html
author: KevinAsgari
description: " quotaInfo (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6cb2283f5214d1d25e1aa0e8bcba17f4c51019fd
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5882734"
---
# <a name="quotainfo-json"></a>quotaInfo (JSON)
クォータ タイトル グループについてを説明します。 
<a id="ID4EN"></a>

 
## <a name="quotainfo"></a>quotaInfo
 
QuotaInfo オブジェクトには、次の仕様があります。
 
グローバル ストレージ
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| quotaBytes| 32 ビット符号付き整数 | タイトルで使用可能なバイトの最大数。| 
| usedBytes| 32 ビット符号付き整数 | タイトルで使用されるバイト数。| 
  
<a id="ID4EXB"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 
次の例は、グローバル ストレージへの応答を示しています。
 

```json
{
    "quotaInfo":
    {
        "usedBytes":4194304,
        "quotaBytes":536870912
    }
}
      
```

  
<a id="ID4ECC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   