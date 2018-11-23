---
title: ビデオの EDS 逆引き参照
assetID: 773f7a8e-7571-3aec-96d6-478437696ea6
permalink: en-us/docs/xboxlive/rest/edsreverselookup.html
author: KevinAsgari
description: " ビデオの EDS 逆引き参照"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e46bfb70ad377723694bfedb1dde0448564a97a8
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7581348"
---
# <a name="eds-reverse-lookup-for-video"></a>ビデオの EDS 逆引き参照
 
  * [逆の検索手順](#ID4EQ)
 
<a id="ID4EQ"></a>

 
## <a name="reverse-lookup-steps"></a>逆の検索手順
 
すべてのビデオ メディアの種類 (**MediaItemType.Movie**、 **MediaItemType.TVSeries**、 **MediaItemType.TVEpisode**、 **MediaItemType.TVSeason**、および**エンターテイメント探索サービス (EDS) の逆引き参照がサポートされています。MediaItemType.TVShow**)、および**MediaItemType.Unknown**します。
 
逆引き参照では、4 つのパラメーターを渡すことが必要です。 
   * `idType=ScopedMediaId`
   * `ids=` プロバイダーのメディア ID
   * `ScopeIdType=Title`
   * `ScopeId=` プロバイダーのタイトル ID
 
 
通常の逆引き参照では、2 つの手順が必要です。 
   * 利用できない場合 (たとえば、詳細呼び出し) からプロバイダー メディアの id を取得します。 

```cpp
GET /media/en-us/details?ids=4eeaf5b4-9af2-56e4-a738-68b48e954494&desiredMediaItemTypes=Movie&desired=Providers
```

 
   * 以前の応答から**ProviderMediaId**フィールドを使用した逆引き参照の呼び出しを発行するには。 

```cpp
GET /media/en-us/details?ids=047d19ca-3a7d-462c-bdbb-163543125583&idType=ScopedMediaId&desiredMediaItemTypes=Movie&fields=all&ScopeIdType=Title&ScopeId=0x5848085B
```

 
  
 
**ProviderMediaId**フィールドが EDS から取得されていない場合、フィールドは、EDS に正しく渡される URL エンコードである必要があります。
  
<a id="ID4EOC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4E3C"></a>

 
##### <a name="further-information"></a>詳細情報 

[マーケットプレース URI](../uri/marketplace/atoc-reference-marketplace.md)

   