---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}
assetID: 1e2f5fd3-3d14-9a97-ffbf-ab2a18ff4f15
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.html
author: KevinAsgari
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: af1090dd5dc33d3070ddafc9c79105d09c400a3c
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4356630"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinername"></a>/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}
メディア項目の種類が与えられると、指定されたクエリの絞り込み条件名は、利用可能な値にアクセスします。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。| 
| mediaitemtype| string| 必須。 値のいずれか[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。| 
| queryrefinername| string| 必須。 どの値が必要な「ジャンル」や「年」など、クエリの絞り込み条件の名前です。 QueryRefiners を参照してください。| 
  
<a id="ID4EKC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinernameget.md)

&nbsp;&nbsp;メディア項目の種類が与えられると、指定されたクエリの絞り込み条件名は、利用可能な値の一覧を示します。
 
<a id="ID4EUC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EWC"></a>

 
##### <a name="parent"></a>Parent 

[マーケットプレース URI](atoc-reference-marketplace.md)

  
<a id="ID4EAD"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   