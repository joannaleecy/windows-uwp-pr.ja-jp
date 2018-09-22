---
title: ResetReputation (JSON)
assetID: 15edb5e7-a00b-4188-9b49-9db5774c4a10
permalink: en-us/docs/xboxlive/rest/json-resetreputation.html
author: KevinAsgari
description: " ResetReputation (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 494f4a8977a298265c264b050d6a222bd2bdd7d2
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4121474"
---
# <a name="resetreputation-json"></a>ResetReputation (JSON)
ユーザーの既存のスコアを変更する必要があります新しい基本評判スコアが含まれています。 
<a id="ID4EN"></a>

 
## <a name="resetreputation"></a>ResetReputation
 
ResetReputation オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| fairplayReputation| number| 必要な基本フェアプレイ評判スコアのユーザー (有効な範囲 0 ~ 75)。| 
| commsReputation| number| 目的の基本 (有効な範囲 0 ~ 75) のユーザーの通信の評判スコア。| 
| userContentReputation| number| 必要な基本 UserContent 評判スコアのユーザー (有効な範囲 0 ~ 75)。| 
  
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

   