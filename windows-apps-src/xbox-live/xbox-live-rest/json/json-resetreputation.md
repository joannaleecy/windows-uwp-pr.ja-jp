---
title: ResetReputation (JSON)
assetID: 15edb5e7-a00b-4188-9b49-9db5774c4a10
permalink: en-us/docs/xboxlive/rest/json-resetreputation.html
description: " ResetReputation (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d09c8bbc1130f91dfea3d4c35e391dcf9adcf127
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57649417"
---
# <a name="resetreputation-json"></a>ResetReputation (JSON)
ユーザーの既存のスコアを変更する必要があります新しい基本評価スコアが含まれています。 
<a id="ID4EN"></a>

 
## <a name="resetreputation"></a>ResetReputation
 
ResetReputation オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| fairplayReputation| number| 必要な基本ユーザー (有効な範囲 0 ~ 75) の Fairplay 評価スコア。| 
| commsReputation| number| 必要な基本ユーザー (有効な範囲 0 ~ 75) の通信の評価スコア。| 
| userContentReputation| number| 必要な基本のユーザー (有効な範囲 0 ~ 75) UserContent 評価スコア。| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   