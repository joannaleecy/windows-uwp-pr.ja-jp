---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields
assetID: fc9b556a-7fc7-64ec-cb5c-b5cabd2ab4ce
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypefields.html
author: KevinAsgari
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 086538c2817e39cb80c66f9689327ae84a5feff2
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5859596"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a>/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields
指定された mediaitemtype と EDS の特定のバージョンのデータを想定いずれかからアクセス フィールド。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。| 
| mediaitemtype| string| 必須。 値のいずれかの[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)](uri-medialocalemetadatamediaitemtypefieldsget.md)

&nbsp;&nbsp;指定された mediaitemtype と EDS の特定のバージョンのデータを想定いずれかからフィールドを示します。
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a>Parent 

[マーケットプレース URI](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   