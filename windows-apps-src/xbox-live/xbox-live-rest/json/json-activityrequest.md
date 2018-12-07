---
title: ActivityRequest (JSON)
assetID: 9eb03ab7-352c-4465-ec86-d544e76f63f9
permalink: en-us/docs/xboxlive/rest/json-activityrequest.html
description: " ActivityRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 791a566d278b92aeb34ab36d38719b44e9cc6c8f
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8729298"
---
# <a name="activityrequest-json"></a>ActivityRequest (JSON)
1 つまたは複数のユーザーのリッチ プレゼンスに関する情報を要求します。 
<a id="ID4EN"></a>

 
## <a name="activityrequest"></a>ActivityRequest
 
ActivityRequest オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| richPresence| [RichPresenceRequest](json-richpresencerequest.md)| ために使用するリッチ プレゼンス文字列のフレンドリ名。| 
| メディア| MediaRequest| どのようなユーザーのメディアの情報が視聴またはをリッスンします。| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
    richPresence:
    {
      id:"playingMapWeapon",
      scid:"abba0123-08ba-48ca-9f1a-21627b189b0f"
    }
  }
    
```

  
<a id="ID4E5B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   