---
title: TitleAssociation (JSON)
assetID: 05f4edbb-cc3d-c17d-0979-aac9e44a4988
permalink: en-us/docs/xboxlive/rest/json-titleassociation.html
description: " TitleAssociation (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 21a583e7556f98b827a63de3948f43d76f25c907
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8928925"
---
# <a name="titleassociation-json"></a>TitleAssociation (JSON)
実績に関連付けられているタイトルです。 
<a id="ID4EN"></a>

 
## <a name="titleassociation"></a>TitleAssociation
 
TitleAssociation オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| name| string| コンテンツのローカライズされた名前です。| 
| id| string| タイトル Id (32 ビット符号なし整数、10 進数で返されます)。| 
| version| string| (該当する場合) に関連付けられているタイトルの特定のバージョン。| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
  "name":"Microsoft Achievements Sample",
  "id":3051199919,
  "version":"abc"
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   