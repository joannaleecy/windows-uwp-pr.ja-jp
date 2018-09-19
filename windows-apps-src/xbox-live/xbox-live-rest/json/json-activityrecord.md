---
title: ActivityRecord (JSON)
assetID: e3a7465b-3451-0266-f8ba-b7602b59f7af
permalink: en-us/docs/xboxlive/rest/json-activityrecord.html
author: KevinAsgari
description: " ActivityRecord (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0eb34d64daa9b1349c4f956a59ccf5d8efa5b565
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4055651"
---
# <a name="activityrecord-json"></a>ActivityRecord (JSON)
1 つまたは複数のユーザーのリッチ プレゼンスの書式設定されたとローカライズされた文字列です。 
<a id="ID4EN"></a>

 
## <a name="activityrecord"></a>ActivityRecord
 
ActivityRecord オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| richPresence| string| フォーマットされて、ローカライズされたリッチ プレゼンス文字列。| 
| メディア| MediaRecord| どのようなユーザーが視聴またはをリッスンします。| 
  
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

   