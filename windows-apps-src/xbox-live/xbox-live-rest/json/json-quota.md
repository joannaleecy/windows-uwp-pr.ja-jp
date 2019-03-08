---
title: quotaInfo (JSON)
assetID: 3147ab78-e671-e142-0a3a-688dc4079451
permalink: en-us/docs/xboxlive/rest/json-quota.html
description: " quotaInfo (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f3499fdba972d6e953813fc490d080910921698e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654117"
---
# <a name="quotainfo-json"></a>quotaInfo (JSON)
タイトルのグループのクォータについてを説明します。 
<a id="ID4EN"></a>

 
## <a name="quotainfo"></a>QuotaInfo
 
QuotaInfo オブジェクトには、次の仕様があります。
 
グローバル ストレージ
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| quotaBytes| 32 ビット符号付き整数 | タイトルに使用できるバイトの最大数。| 
| usedBytes| 32 ビット符号付き整数 | タイトルに使用されるバイト数。| 
  
<a id="ID4EXB"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 
次の例では、グローバル ストレージの応答を示します。
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   