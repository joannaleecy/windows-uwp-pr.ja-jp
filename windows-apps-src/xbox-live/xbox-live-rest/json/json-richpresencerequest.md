---
title: RichPresenceRequest (JSON)
assetID: 599266be-f747-0be1-fadf-f8e0262dc27f
permalink: en-us/docs/xboxlive/rest/json-richpresencerequest.html
description: " RichPresenceRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4c49da63ecd091a886a68f508af09e33fb9c58ac
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654127"
---
# <a name="richpresencerequest-json"></a>RichPresenceRequest (JSON)
豊富なプレゼンス情報の使用についての情報を要求します。 
<a id="ID4EN"></a>

 
## <a name="richpresencerequest"></a>RichPresenceRequest
 
RichPresenceRequest オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| id| string| <b>FriendlyName</b>プレゼンスの文字列を使用するのです。| 
| scid| string| プレゼンスの文字列が定義されていることを指示する Scid します。| 
| params| 文字列の配列| 配列<b>friendlyName</b>プレゼンス文字列を終了する文字列します。 列挙型の表示名のみを指定する必要があります、統計ではありません。この空のまま、以前の値が削除されます。| 
  
<a id="ID4EDC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
      id:"playingMapWeapon",
      scid:"abba0123-08ba-48ca-9f1a-21627b189b0f",
    }
    
```

  
<a id="ID4EMC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   