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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659707"
---
# <a name="property-json"></a>Property (JSON)
マッチメイ キング要求条件、クライアントによって提供されるプロパティのデータが含まれています。
<a id="ID4EN"></a>


## <a name="property"></a>プロパティ

プロパティ オブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| id| string| このプロパティの id。|
| type| 32 ビット符号付き整数 | プロパティの型。 サポートされている値は次のとおりです。 <ul><li>0 = 整数</li><li>1 = 文字列</li></ul>| 
| value| string| このプロパティの値。|

<a id="ID4EGC"></a>


## <a name="sample-json-syntax"></a>サンプルの JSON の構文


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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)
