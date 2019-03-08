---
title: InitialUploadResponse (JSON)
assetID: 6abb7d37-2c35-2cc3-d9e5-eff695235262
permalink: en-us/docs/xboxlive/rest/json-initialuploadresponse.html
description: " InitialUploadResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dab59fefb389cf550a1bc4fc6429f6b0970f50ab
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589837"
---
# <a name="initialuploadresponse-json"></a>InitialUploadResponse (JSON)
 
<a id="ID4EO"></a>

 
## <a name="initialuploadresponse"></a>InitialUploadResponse
 
InitialUploadResponse オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>gameClipId</b>| string| データ要求のアップロードに割り当てられた ID。| 
| <b>uploadUri</b>| URI| ゲームのクリップのアップロード先となる場所です。| 
| <b>largeThumbnailUri</b>| URI| (省略可能)。 場所は、大規模なサムネイルをアップロードする必要があります。 このフィールドの存在が続く、 [ThumbnailSource 列挙](../enums/gvr-enum-thumbnailsource.md)値、 <b>InitialUploadRequest</b> (存在するが、アップロードが指定されている場合になります)。| 
| <b>smallThumbnailUri</b>| URI| (省略可能)。 小規模のサムネイルのアップロード先となる場所です。 このフィールドの存在が続く、 [ThumbnailSource 列挙](../enums/gvr-enum-thumbnailsource.md)値、 <b>InitialUploadRequest</b> (存在するが、アップロードが指定されている場合になります)。| 
  
<a id="ID4EYC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   