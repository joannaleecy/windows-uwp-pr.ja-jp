---
title: ビデオの逆引き参照を EDS
assetID: 773f7a8e-7571-3aec-96d6-478437696ea6
permalink: en-us/docs/xboxlive/rest/edsreverselookup.html
author: KevinAsgari
description: " ビデオの逆引き参照を EDS"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b259ae20bd07c6869bc6646fc44a70f994a261b7
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3933016"
---
# <a name="eds-reverse-lookup-for-video"></a>ビデオの逆引き参照を EDS
 
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

 
   * 応答には、以前から**ProviderMediaId**フィールドを使用して逆の検索のための呼び出しを発行します。 

```cpp
GET /media/en-us/details?ids=047d19ca-3a7d-462c-bdbb-163543125583&idType=ScopedMediaId&desiredMediaItemTypes=Movie&fields=all&ScopeIdType=Title&ScopeId=0x5848085B
```

 
  
 
**ProviderMediaId**フィールドが EDS から取得されていない場合、フィールドは、EDS に正しくを渡される URL エンコードである必要があります。
  
<a id="ID4EOC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4E3C"></a>

 
##### <a name="further-information"></a>詳細情報 

[Marketplace Uri](../uri/marketplace/atoc-reference-marketplace.md)

   