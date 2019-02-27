---
title: GameClipThumbnail (JSON)
assetID: 3ed87fc1-734c-d8b5-d908-0ae3359769ed
permalink: en-us/docs/xboxlive/rest/json-gameclipthumbnail.html
description: " GameClipThumbnail (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ad2d35431cb4c40690978f4f3920f2e47f2b9bc0
ms.sourcegitcommit: 079801609165bc7eb69670d771a05bffe236d483
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/27/2019
ms.locfileid: "9115410"
---
# <a name="gameclipthumbnail-json"></a>GameClipThumbnail (JSON)
個々 のサムネイルに関連する情報が含まれています。 1 つのクリップを複数のサイズが存在することができ、表示用の適切なものを選択するクライアントがします。 
<a id="ID4EN"></a>

 
## <a name="gameclipthumbnail"></a>GameClipThumbnail
 
GameClipThumbnail オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>uri</b>| string| サムネイル画像の URI。| 
| <b>fileSize</b>| 32 ビット符号なし整数| サムネイル画像のファイルの合計サイズ。| 
| <b>thumbnailType</b>| ThumbnailType| サムネイル画像の種類です。| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
         "uri": "https://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
    
```

  
<a id="ID4EJC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   