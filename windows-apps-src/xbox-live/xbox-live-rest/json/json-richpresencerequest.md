---
title: RichPresenceRequest (JSON)
assetID: 599266be-f747-0be1-fadf-f8e0262dc27f
permalink: en-us/docs/xboxlive/rest/json-richpresencerequest.html
author: KevinAsgari
description: " RichPresenceRequest (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 92e52e4ebb58abb3a522f81a5ae4cce6486785f0
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6184261"
---
# <a name="richpresencerequest-json"></a>RichPresenceRequest (JSON)
リッチ プレゼンス情報の使用に関する情報を要求します。 
<a id="ID4EN"></a>

 
## <a name="richpresencerequest"></a>RichPresenceRequest
 
RichPresenceRequest オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| id| string| 使用するリッチ プレゼンス文字列の<b>フレンドリ名</b>。| 
| scid| string| リッチ プレゼンス文字列を定義する場所を示す Scid です。| 
| パラメーター| 文字列の配列| リッチ プレゼンス文字列を完了するための<b>フレンドリ名</b>の文字列の配列です。 列挙フレンドリ名を指定する必要があります、統計ではありません。この空のまま、以前の値が削除されます。| 
  
<a id="ID4EDC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   