---
title: MediaAsset (JSON)
assetID: 858c720a-1648-738b-bb43-f050e7cac19e
permalink: en-us/docs/xboxlive/rest/json-mediaasset.html
author: KevinAsgari
description: " MediaAsset (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a5a56b524dbf88d96a34f769f7a25bed7bca8a1d
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4566108"
---
# <a name="mediaasset-json"></a>MediaAsset (JSON)
実績やそのリワードに関連付けられているメディア アセット。
<a id="ID4EN"></a>


## <a name="mediaasset"></a>MediaAsset

MediaAsset オブジェクトには、次の仕様があります。

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
