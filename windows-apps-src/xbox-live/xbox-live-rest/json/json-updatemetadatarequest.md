---
title: UpdateMetadataRequest (JSON)
assetID: 0bc210e3-c1dc-9267-e322-aadb9f0a074a
permalink: en-us/docs/xboxlive/rest/json-updatemetadatarequest.html
author: KevinAsgari
description: " UpdateMetadataRequest (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0ac315552420135870d0a3c83354bc53fba903f6
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5558726"
---
# <a name="updatemetadatarequest-json"></a>UpdateMetadataRequest (JSON)
このメタデータは、クリップを更新する必要があります。 
<a id="ID4EN"></a>

 
## <a name="updatemetadatarequest"></a>UpdateMetadataRequest
 
UpdateMetadataRequest オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| userCaption| string| ゲーム クリップのユーザーが入力した以外にローカライズされた文字列を変更します。| 
| visibility| [GameClipVisibility 列挙型](../enums/gvr-enum-gameclipvisibility.md)| これは、システムで公開されるゲーム クリップの可視性を変更します。| 
| titleData| string| タイトルに固有のプロパティ バッグです。 最大サイズ: 10 kb です。| 
  
<a id="ID4EBC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 
ユーザーのクリップ名と認知度を変更します。
 

```json
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
タイトルのプロパティ (これは単なる例、このフィールドのスキーマは、呼び出し元であるため) だけを変更するには。
 

```json
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a>リファレンス 

[POST (/users/me/scids/{scid}/clips/{gameClipId})](../uri/dvr/uri-usersmescidclipsgameclipidpost.md)

   