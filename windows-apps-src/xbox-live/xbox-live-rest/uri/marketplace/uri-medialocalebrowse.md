---
title: /media/{marketplaceId} 参照/
assetID: 4fedc780-b3c2-c83b-e7af-9e18666a4771
permalink: en-us/docs/xboxlive/rest/uri-medialocalebrowse.html
author: KevinAsgari
description: " /media/{marketplaceId} 参照/"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 776db1cf795ae964621d751d6b4b72d22ba82c2d
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3935210"
---
# <a name="mediamarketplaceidbrowse"></a>/media/{marketplaceId} 参照/
1 つのメディア グループ内の項目を参照できます。 参照 API は、クライアントから 1 つのメディア グループ内の項目を参照できます。 非連続的に継続トークンを使用するのではなく skipItems パラメーターを使用してデータのページにアクセスできます。
 
この API では、指定した項目の子内で参照できます。 たとえば、Xbox 360 ゲームの ID と MediaItemType パラメーターに渡して、これにより、閲覧、diltering アバター項目や、ゲームの DLC など、その項目の子にします。
 
この API は、絞り込み条件のクエリを受け取ります。
 
子を取得するためのいくつかのシナリオは次のとおりです。
 
   * アルバムのトラックに
   * 時期にシリーズ
   * エピソードする時期
   * 音楽ビデオへの追跡します。
   * アルバムのアーティスト
   * ゲームのアドオン (DLC、アバター、テーマなど) へのゲーム
  
これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EMB)
 
<a id="ID4EMB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。| 
  
<a id="ID4ENC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得する (メディア/{marketplaceId} 参照/)](uri-medialocalebrowseget.md)

&nbsp;&nbsp;1 つのメディア グループ内の項目を参照できます。 
 
<a id="ID4EXC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EZC"></a>

 
##### <a name="parent"></a>Parent 

[Marketplace Uri](atoc-reference-marketplace.md)

  
<a id="ID4EDD"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   