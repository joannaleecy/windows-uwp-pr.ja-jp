---
title: ActivityRecord (JSON)
assetID: e3a7465b-3451-0266-f8ba-b7602b59f7af
permalink: en-us/docs/xboxlive/rest/json-activityrecord.html
description: " ActivityRecord (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a8679c96c86754a8b929b44b5bd4eb402d851e90
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8930399"
---
# <a name="activityrecord-json"></a>ActivityRecord (JSON)
1 つまたは複数のユーザーのリッチ プレゼンスの書式設定されたとローカライズされた文字列です。 
<a id="ID4EN"></a>

 
## <a name="activityrecord"></a>ActivityRecord
 
ActivityRecord オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| richPresence| string| フォーマットされ、ローカライズされたリッチ プレゼンス文字列。| 
| メディア| MediaRecord| ユーザーの視聴やをリッスンしています。| 
  
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

   