---
title: Property (JSON)
assetID: 93de547e-d936-6fcc-92cb-e4dd284dd609
permalink: en-us/docs/xboxlive/rest/json-property.html
author: KevinAsgari
description: " Property (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d37054d03f6ebe8299db78673dc631c9b4b4bc16
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5860964"
---
# <a name="property-json"></a>Property (JSON)
マッチメイ キング要求条件のクライアントによって提供されるプロパティ データが含まれています。
<a id="ID4EN"></a>


## <a name="property"></a>プロパティ

プロパティ オブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| id| string| このプロパティの id。|
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
