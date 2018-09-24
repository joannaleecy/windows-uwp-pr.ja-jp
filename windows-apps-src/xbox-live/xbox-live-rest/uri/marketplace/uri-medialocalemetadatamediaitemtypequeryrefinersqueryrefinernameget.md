---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})
assetID: 05b2449f-3ef4-4fdf-df32-e72bcfc473d2
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinernameget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 230e92bf17ebf1cfdad1eb6a21277e038fbdef25
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4151766"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinername"></a>GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})
メディア項目の種類が与えられると、指定されたクエリの調整名は、利用可能な値の一覧を示します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。| 
| mediaitemtype| string| 必須。 値のいずれかの[を取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。| 
| queryrefinername| string| 必須。 どの値が必要な「ジャンル」や「年」など、クエリの調整の名前です。 QueryRefiners を参照してください。| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a>Parent 

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [マーケットプレース URI](atoc-reference-marketplace.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   