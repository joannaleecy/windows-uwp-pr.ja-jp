---
title: MediaAsset (JSON)
assetID: 858c720a-1648-738b-bb43-f050e7cac19e
permalink: en-us/docs/xboxlive/rest/json-mediaasset.html
author: KevinAsgari
description: " MediaAsset (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b50cb58f6c6262d653e90e1e6ca9666cecadf680
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7556501"
---
# <a name="mediaasset-json"></a>MediaAsset (JSON)
実績やそのリワードに関連付けられているメディア アセット。
<a id="ID4EN"></a>


## <a name="mediaasset"></a>MediaAsset

MediaAsset オブジェクトでは、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| name| string| "Tile01"など、MediaAsset の名前です。|
| type| MediaAssetType 列挙型| メディア アセットの種類。 <ul><li>アイコン (0): 実績アイコンです。</li><li>アート (1): デジタル アート アセット。</li></ul> | 
| url| string| MediaAsset の URL。|

<a id="ID4EFC"></a>


## <a name="sample-json-syntax"></a>JSON 構文の例


```json
{
  "name":"Icon Name",
  "type":"Icon",
  "url":"http://www.xbox.com"
}

```


<a id="ID4EOC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EQC"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)
