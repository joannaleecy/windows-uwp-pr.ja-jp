---
title: /media/{marketplaceId}/contentRating
assetID: 573cf378-36a4-cc82-0029-37d268da933c
permalink: en-us/docs/xboxlive/rest/uri-medialocalecontentrating.html
author: KevinAsgari
description: " /media/{marketplaceId}/contentRating"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 64aa0cdd7b1167ee139774114ad65e507bce759e
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5682004"
---
# <a name="mediamarketplaceidcontentrating"></a>/media/{marketplaceId}/contentRating
コンテンツの規制トークンにアクセスします。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。| 
  
<a id="ID4EUB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/media/{marketplaceId}/contentRating)](uri-medialocalecontentratingget.md)

&nbsp;&nbsp;コンテンツの規制のトークンを取得します。
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a>Parent 

[マーケットプレース URI](atoc-reference-marketplace.md)

  
<a id="ID4EKC"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   