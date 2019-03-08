---
title: ビデオの EDS 逆引き参照
assetID: 773f7a8e-7571-3aec-96d6-478437696ea6
permalink: en-us/docs/xboxlive/rest/edsreverselookup.html
description: " ビデオの EDS 逆引き参照"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d535dec8a95eba4d486bfc6946e187e2da66ae49
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598437"
---
# <a name="eds-reverse-lookup-for-video"></a>ビデオの EDS 逆引き参照
 
  * [逆引き参照手順](#ID4EQ)
 
<a id="ID4EQ"></a>

 
## <a name="reverse-lookup-steps"></a>逆引き参照手順
 
すべてのビデオ メディアの種類のエンターテイメント検出サービス (EDS) の逆引き参照がサポートされています (**MediaItemType.Movie**、 **MediaItemType.TVSeries**、 **MediaItemType.TVEpisode**、 **MediaItemType.TVSeason**、および**MediaItemType.TVShow**)、および**MediaItemType.Unknown**します。
 
逆引き参照では、渡される 4 つのパラメーターが必要です。 
   * `idType=ScopedMediaId`
   * `ids=` プロバイダーのメディア ID
   * `ScopeIdType=Title`
   * `ScopeId=` プロバイダー ID のタイトル
 
 
通常、逆引き参照では、2 つの手順が必要です。 
   * 使用できない場合 (たとえば、詳細の呼び出し) からプロバイダー メディア id を取得します。 

```cpp
GET /media/en-us/details?ids=4eeaf5b4-9af2-56e4-a738-68b48e954494&desiredMediaItemTypes=Movie&desired=Providers
```

 
   * 逆引き参照を使用するための呼び出しを発行、 **ProviderMediaId**前の応答からフィールド。 

```cpp
GET /media/en-us/details?ids=047d19ca-3a7d-462c-bdbb-163543125583&idType=ScopedMediaId&desiredMediaItemTypes=Movie&fields=all&ScopeIdType=Title&ScopeId=0x5848085B
```

 
  
 
場合、 **ProviderMediaId** EDS からフィールドが取得されていないし、フィールドは、EDS に正しく渡す URL エンコードする必要があります。
  
<a id="ID4EOC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4E3C"></a>

 
##### <a name="further-information"></a>詳細情報 

[Marketplace の Uri](../uri/marketplace/atoc-reference-marketplace.md)

   