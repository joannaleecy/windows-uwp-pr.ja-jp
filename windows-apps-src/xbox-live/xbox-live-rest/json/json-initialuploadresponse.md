---
title: InitialUploadResponse (JSON)
assetID: 6abb7d37-2c35-2cc3-d9e5-eff695235262
permalink: en-us/docs/xboxlive/rest/json-initialuploadresponse.html
author: KevinAsgari
description: " InitialUploadResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3a643775f835a87b4c1287b0954f698c4c987c10
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4122364"
---
# <a name="initialuploadresponse-json"></a>InitialUploadResponse (JSON)
 
<a id="ID4EO"></a>

 
## <a name="initialuploadresponse"></a>InitialUploadResponse
 
InitialUploadResponse オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>gameClipId</b>| string| アップロードのデータ要求に割り当てられている ID。| 
| <b>uploadUri</b>| URI| 場所は、ゲーム クリップをアップロードする必要があります。| 
| <b>largeThumbnailUri</b>| URI| 省略可能。 大きなサムネイルのアップロード場所です。 このフィールドの有無については、(アップロードが指定されているときになります) <b>InitialUploadRequest</b>で[ThumbnailSource 列挙](../enums/gvr-enum-thumbnailsource.md)値によって決まります。| 
| <b>smallThumbnailUri</b>| URI| 省略可能。 小さなサムネイルのアップロード場所です。 このフィールドの有無については、(アップロードが指定されているときになります) <b>InitialUploadRequest</b>で[ThumbnailSource 列挙](../enums/gvr-enum-thumbnailsource.md)値によって決まります。| 
  
<a id="ID4EYC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
   "gameClipId": "6b364924-5650-480f-86a7-fc002a1ee752"  ,  
   "uploadUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container",
   "largeThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/large",
   "smallThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/small"
 }
    
```

  
<a id="ID4EBD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EDD"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   