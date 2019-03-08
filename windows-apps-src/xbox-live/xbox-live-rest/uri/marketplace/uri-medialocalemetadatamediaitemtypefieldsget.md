---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)
assetID: 0ecf27d8-905d-af52-4060-43353d7a3e29
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypefieldsget.html
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 70b43719f3daa86f8e34289545e454cb5d209545
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57656427"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a>GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)
元のいずれかを特定 mediaitemtype と EDS の特定のバージョンのデータに期待できるフィールドを一覧表示します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。| 
| mediaitemtype| string| 必須。 値の 1 つ[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a>Parent 

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields](uri-medialocalemetadatamediaitemtypefields.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS の一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace の Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   