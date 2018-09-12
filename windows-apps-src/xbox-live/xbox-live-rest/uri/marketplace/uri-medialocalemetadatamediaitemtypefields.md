---
title: /media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaItemType}/フィールド
assetID: fc9b556a-7fc7-64ec-cb5c-b5cabd2ab4ce
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypefields.html
author: KevinAsgari
description: " /media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaItemType}/フィールド"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f5bdcb8b854a8b71f232c8a1cc73cd12bc587015
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881732"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a>/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaItemType}/フィールド
いずれか、特定の mediaitemtype と EDS の特定のバージョンのデータとアクセス フィールド。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。| 
| mediaitemtype| string| 必須。 値のいずれか[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaItemType} フィールド/)](uri-medialocalemetadatamediaitemtypefieldsget.md)

&nbsp;&nbsp;いずれか、特定の mediaitemtype と EDS の特定のバージョンのデータとフィールドの一覧を示します。
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a>Parent 

[Marketplace Uri](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   