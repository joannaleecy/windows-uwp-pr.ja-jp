---
title: DeviceRecord (JSON)
assetID: aca4f4d3-f9b4-8919-5b6d-5ae0fe11e162
permalink: en-us/docs/xboxlive/rest/json-devicerecord.html
description: " DeviceRecord (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9746706c00a09cd8b64913b4ae8b5c3426551e48
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8731008"
---
# <a name="devicerecord-json"></a>DeviceRecord (JSON)
、その種類と、タイトルでアクティブななど、デバイスに関する情報。 
<a id="ID4EN"></a>

 
## <a name="devicerecord"></a>DeviceRecord
 
DeviceRecord オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| type| 文字列| デバイスのデバイスの種類。 "D"、"Xbox360"、"MoLIVE"(Windows)、"WindowsPhone"、"WindowsPhone7"、"PC"(G4WL) の組み合わせが含まれます。 型が (例 iOS、Android、または web ブラウザーに埋め込まれているタイトル) の既知の場合は、"Web"が返されます。| 
| タイトル| [TitleRecord](json-titlerecord.md)の配列| このデバイス上でアクティブなタイトルの一覧。| 
  
<a id="ID4EWB"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
[{
    type:"D",
    titles:
    [{
      id:"12341234",
      name:"Contoso 5",
      state:"active",
      placement:"fill",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Team Deathmatch on Nirvana"
      }
    },
    {
      id:"12341235",
      name:"Contoso Waypoint",
      timestamp:"2012-09-17T07:15:23.4930000",
      placement:"snapped",
      state:"active",
      activity:
      {
        richPresence:"Using radar"
      }
    }]
  }]
    
```

  
<a id="ID4E6B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ENC"></a>

 
##### <a name="reference"></a>リファレンス   