---
title: RichPresenceRequest (JSON)
assetID: 599266be-f747-0be1-fadf-f8e0262dc27f
permalink: en-us/docs/xboxlive/rest/json-richpresencerequest.html
author: KevinAsgari
description: " RichPresenceRequest (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9d1158832623b88efb0a614680f0c0fb579f79d4
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3984006"
---
# <a name="richpresencerequest-json"></a>RichPresenceRequest (JSON)
リッチ プレゼンス情報の使用に関する情報を要求します。 
<a id="ID4EN"></a>

 
## <a name="richpresencerequest"></a>RichPresenceRequest
 
RichPresenceRequest オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| id| string| 使用するリッチ プレゼンス文字列の<b>フレンドリ名</b>。| 
| scid| string| リッチ プレゼンス文字列が定義されている場所を示す Scid です。| 
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

   