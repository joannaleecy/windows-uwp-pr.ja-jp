---
title: ResetReputation (JSON)
assetID: 15edb5e7-a00b-4188-9b49-9db5774c4a10
permalink: en-us/docs/xboxlive/rest/json-resetreputation.html
author: KevinAsgari
description: " ResetReputation (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1c2462419559ad179b2824b2735a5aad4ee63725
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5556545"
---
# <a name="resetreputation-json"></a>ResetReputation (JSON)
ユーザーの既存のスコアを変更する必要があります新しい基本評判スコアが含まれています。 
<a id="ID4EN"></a>

 
## <a name="resetreputation"></a>ResetReputation
 
ResetReputation オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| fairplayReputation| number| 目的の基本 (有効な範囲 0 ~ 75) のユーザーのフェアプレイ評判スコア。| 
| commsReputation| number| 目的の基本 (有効な範囲 0 ~ 75) のユーザーの通信の評判スコア。| 
| userContentReputation| number| 目的の基本 (有効な範囲 0 ~ 75) のユーザーの UserContent 評判スコア。| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   