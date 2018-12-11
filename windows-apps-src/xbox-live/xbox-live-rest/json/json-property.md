---
title: Property (JSON)
assetID: 93de547e-d936-6fcc-92cb-e4dd284dd609
permalink: en-us/docs/xboxlive/rest/json-property.html
description: " Property (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7e2a721886509c49c60d663d491f8d49bc3c95e9
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8885329"
---
# <a name="property-json"></a>Property (JSON)
マッチメイ キング要求条件のクライアントによって提供されるプロパティ データが含まれています。
<a id="ID4EN"></a>


## <a name="property"></a>プロパティ

プロパティ オブジェクトには、次仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| id| string| このプロパティの id です。|
| type| 32 ビット符号付き整数 | プロパティの型です。 サポートされる値は次のとおりです。 <ul><li>0 = 整数</li><li>1 = 文字列</li></ul>| 
| value| string| このプロパティの値。|

<a id="ID4EGC"></a>


## <a name="sample-json-syntax"></a>JSON 構文の例


```json
{
    "id":"1",
    "value":"20",
    "type":0
}

```


<a id="ID4EPC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ERC"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)
