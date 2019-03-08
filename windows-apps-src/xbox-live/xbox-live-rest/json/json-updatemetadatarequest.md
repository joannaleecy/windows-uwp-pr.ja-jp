---
title: UpdateMetadataRequest (JSON)
assetID: 0bc210e3-c1dc-9267-e322-aadb9f0a074a
permalink: en-us/docs/xboxlive/rest/json-updatemetadatarequest.html
description: " UpdateMetadataRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a76e4b12e0ffadb112913775b500ac0d39d413d5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57597767"
---
# <a name="updatemetadatarequest-json"></a>UpdateMetadataRequest (JSON)
このメタデータは、クリップを更新する必要があります。 
<a id="ID4EN"></a>

 
## <a name="updatemetadatarequest"></a>UpdateMetadataRequest
 
UpdateMetadataRequest オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| userCaption| string| ゲームのクリップをユーザーが入力した非ローカライズ文字列を変更します。| 
| visibility| [GameClipVisibility 列挙型](../enums/gvr-enum-gameclipvisibility.md)| システムでパブリッシュされるゲームのクリップの可視性を変更します。| 
| titleData| string| タイトルに固有のプロパティ バッグ。 最大サイズ:10 KB。| 
  
<a id="ID4EBC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 
ユーザーのクリップの名前を変更して、可視性:
 

```json
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
(これはほんの一例であるため、このフィールドのスキーマは、呼び出し元) のタイトルのプロパティだけを変更するには。
 

```json
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a>リファレンス 

[POST (/users/me/scids/{scid}/clips/{gameClipId})](../uri/dvr/uri-usersmescidclipsgameclipidpost.md)

   