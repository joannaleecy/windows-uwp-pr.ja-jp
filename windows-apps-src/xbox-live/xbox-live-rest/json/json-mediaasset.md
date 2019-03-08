---
title: MediaAsset (JSON)
assetID: 858c720a-1648-738b-bb43-f050e7cac19e
permalink: en-us/docs/xboxlive/rest/json-mediaasset.html
description: " MediaAsset (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 308a65b7c049a6aba0405865bab63fb9d28b8506
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623477"
---
# <a name="mediaasset-json"></a>MediaAsset (JSON)
実績またはその報酬に関連付けられたメディア資産。
<a id="ID4EN"></a>


## <a name="mediaasset"></a>MediaAsset

MediaAsset オブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| name| string| "Tile01"など、MediaAsset の名前。|
| type| MediaAssetType 列挙型| メディア資産の種類: <ul><li>アイコン (0):アチーブメントのアイコン。</li><li>アート (1):デジタル アート資産。</li></ul> | 
| url| string| MediaAsset の URL。|

<a id="ID4EFC"></a>


## <a name="sample-json-syntax"></a>サンプルの JSON の構文


```json
{
  "name":"Icon Name",
  "type":"Icon",
  "url":"https://www.xbox.com"
}

```


<a id="ID4EOC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EQC"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)
