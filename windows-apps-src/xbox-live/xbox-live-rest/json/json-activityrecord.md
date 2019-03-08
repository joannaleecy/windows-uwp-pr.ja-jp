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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608367"
---
# <a name="activityrecord-json"></a>ActivityRecord (JSON)
1 つまたは複数のユーザーのプレゼンスの書式設定とローカライズされた文字列。 
<a id="ID4EN"></a>

 
## <a name="activityrecord"></a>ActivityRecord
 
ActivityRecord オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| richPresence| string| 書式設定され、ローカライズされたプレゼンス文字列。| 
| メディア| MediaRecord| どのようなユーザーが見ているかをリッスンします。| 
  
<a id="ID4ETB"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
        richPresence:"Team Deathmatch on Nirvana"
      }
    
```

  
<a id="ID4E3B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E5B"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   