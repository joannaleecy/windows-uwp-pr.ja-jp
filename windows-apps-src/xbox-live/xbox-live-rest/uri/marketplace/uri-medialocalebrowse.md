---
title: /media/{marketplaceId}/browse
assetID: 4fedc780-b3c2-c83b-e7af-9e18666a4771
permalink: en-us/docs/xboxlive/rest/uri-medialocalebrowse.html
description: " /media/{marketplaceId}/browse"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f692fb66580e20ffeefb3595b8cf9d795f504311
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589687"
---
# <a name="mediamarketplaceidbrowse"></a>/media/{marketplaceId}/browse
1 つのメディアのグループ内の項目を参照できます。 参照 API には、1 つのメディアのグループ内の項目を参照するクライアントが使用できます。 データのページは、非連続的に継続トークンを使用する代わりに、skipItems パラメーターを使用してアクセスできます。
 
この API では、特定の項目の子内で参照できます。 たとえばを Xbox 360 ゲームの ID と MediaItemType パラメーターに渡して、これにより、参照と diltering アバター項目やゲームの DLC など、その項目の子で。
 
この API は、クエリの絞り込み条件を受け入れます。
 
子を取得するためのいくつかのシナリオは次のとおりです。
 
   * アルバム トラックを
   * 季節シリーズ
   * エピソードに季節
   * ミュージック ビデオへの追跡します。
   * アーティストのアルバムに
   * ゲームのアドオン (DLC、アバター、テーマなど) にゲーム
  
これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EMB)
 
<a id="ID4EMB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。| 
  
<a id="ID4ENC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (media/{marketplaceId}/browse)](uri-medialocalebrowseget.md)

&nbsp;&nbsp;1 つのメディアのグループ内の項目を参照できます。 
 
<a id="ID4EXC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EZC"></a>

 
##### <a name="parent"></a>Parent 

[Marketplace の Uri](atoc-reference-marketplace.md)

  
<a id="ID4EDD"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS の一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   