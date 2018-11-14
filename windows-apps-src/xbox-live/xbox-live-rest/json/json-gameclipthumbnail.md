---
title: GameClipThumbnail (JSON)
assetID: 3ed87fc1-734c-d8b5-d908-0ae3359769ed
permalink: en-us/docs/xboxlive/rest/json-gameclipthumbnail.html
author: KevinAsgari
description: " GameClipThumbnail (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4fae93f76d9c8647b2d4264463b434d86897e2a5
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6279419"
---
# <a name="gameclipthumbnail-json"></a>GameClipThumbnail (JSON)
個々 のサムネイルに関連する情報が含まれています。 1 つのクリップを複数のサイズが存在することができますされ、表示用の適切なものを選択するクライアントまでなります。 
<a id="ID4EN"></a>

 
## <a name="gameclipthumbnail"></a>GameClipThumbnail
 
GameClipThumbnail オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>uri</b>| string| サムネイル画像の URI です。| 
| <b>fileSize</b>| 32 ビットの符号なし整数| サムネイル画像の合計ファイル サイズ。| 
| <b>thumbnailType</b>| ThumbnailType| サムネイル画像の種類です。| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
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

   