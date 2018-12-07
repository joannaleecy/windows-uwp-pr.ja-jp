---
title: GameClipUri (JSON)
assetID: 03c097e8-7f29-1026-7a77-5c785b8511e9
permalink: en-us/docs/xboxlive/rest/json-gameclipuri.html
description: " GameClipUri (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9b7c30815a2d6e9a8bcac0730f0330ea41624c3e
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8729093"
---
# <a name="gameclipuri-json"></a>GameClipUri (JSON)
 
<a id="ID4EO"></a>

 
## <a name="gameclipuri"></a>GameClipUri
 
GameClipUri オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>uri</b>| string| ビデオのアセットの場所への URI。| 
| <b>fileSize</b>| 32 ビットの符号なし整数| サムネイル画像の合計ファイル サイズ。| 
| <b>uriType</b>| GameClipUriType| URI の種類です。| 
| <b>有効期限</b>| DateTime| この応答に含まれている URI の有効期限の時刻。 URL の場合は、空のまたは再生する前に有効期限切れと見なされ、呼び出し元は RefreshUrl API を呼び出す必要があります。| 
  
<a id="ID4EMC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
         "uri": "http://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
         "fileSize": 1234565,
         "uriType": "Download",
         "expiration": "9999-12-31T23:59:59.9999999"
       }
    
```

  
<a id="ID4EVC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   