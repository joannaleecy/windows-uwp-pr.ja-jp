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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628157"
---
# <a name="activityrequest-json"></a>ActivityRequest (JSON)
1 つまたは複数のユーザーのプレゼンス情報の要求。 
<a id="ID4EN"></a>

 
## <a name="activityrequest"></a>ActivityRequest
 
ActivityRequest オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| richPresence| [RichPresenceRequest](json-richpresencerequest.md)| 使用する必要がある豊富なプレゼンス文字列のフレンドリ名。| 
| メディア| MediaRequest| どのようなユーザーのメディア情報が視聴またはリッスンします。| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   