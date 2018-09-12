---
title: 取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)
assetID: 0fcbef77-4607-765e-72e1-d2e7620e2c61
permalink: en-us/docs/xboxlive/rest/uri-medialocalemediaitemtypequeryrefinersubqueryrefinervaluesget.html
author: KevinAsgari
description: " 取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 036a64f893ab1581d42f1601204b383968c607e3
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3933560"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinersubqueryrefinervalues"></a>取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)
指定されたクエリの調整値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧を取得します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EDB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
クエリの調整値で**queryRefinerValue**クエリに渡される URI 語幹で禁止されている文字の調整値を許可する動作を行うという名前のクエリ文字列パラメーターとして渡されます。
 
この API は、音楽ののみサポートされます。
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。| 
  
<a id="ID4EOB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQB"></a>

 
##### <a name="parent"></a>Parent 

[/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.md)

  
<a id="ID4E1B"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   