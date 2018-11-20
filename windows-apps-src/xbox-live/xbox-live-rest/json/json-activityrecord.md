---
title: ActivityRecord (JSON)
assetID: e3a7465b-3451-0266-f8ba-b7602b59f7af
permalink: en-us/docs/xboxlive/rest/json-activityrecord.html
author: KevinAsgari
description: " ActivityRecord (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bb78941f2ab9cab4395dbb1ba5eb8fb3b09dee08
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7442049"
---
# <a name="activityrecord-json"></a>ActivityRecord (JSON)
1 つまたは複数のユーザーのリッチ プレゼンスの形式とローカライズされた文字列です。 
<a id="ID4EN"></a>

 
## <a name="activityrecord"></a>ActivityRecord
 
ActivityRecord オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| richPresence| string| フォーマットし、ローカライズされたリッチ プレゼンス文字列。| 
| メディア| MediaRecord| どのようなユーザーは視聴またはをリッスンしています。| 
  
<a id="ID4ETB"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
        richPresence:"Team Deathmatch on Nirvana"
      }
    
```

  
<a id="ID4E3B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E5B"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   