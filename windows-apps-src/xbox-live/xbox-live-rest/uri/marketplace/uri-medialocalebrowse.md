---
title: /media/{marketplaceId}/browse
assetID: 4fedc780-b3c2-c83b-e7af-9e18666a4771
permalink: en-us/docs/xboxlive/rest/uri-medialocalebrowse.html
author: KevinAsgari
description: " /media/{marketplaceId}/browse"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 776db1cf795ae964621d751d6b4b72d22ba82c2d
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4537026"
---
# <a name="mediamarketplaceidbrowse"></a>/media/{marketplaceId}/browse
1 つのメディア グループ内の項目を参照できます。 参照 API は、クライアントから 1 つのメディア グループ内の項目を参照できます。 非連続的に継続トークンを使用するのではなく skipItems パラメーターを使用してデータのページにアクセスできます。
 
この API では、指定した項目の子内で参照できます。 たとえば、Xbox 360 ゲームの ID と MediaItemType パラメーターに渡して、これにより、閲覧、diltering アバター項目やゲームの DLC など、その項目の子にします。
 
この API は、クエリの絞り込み条件を受け入れます。
 
子を取得するためのいくつかのシナリオは次のとおりです。
 
   * アルバムのトラックに
   * 時期にシリーズ
   * エピソードする時期
   * 音楽ビデオへの追跡します。
   * アルバムのアーティスト
   * ゲームのアドオン (DLC、アバター、テーマなど) にゲーム
  
これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EMB)
 
<a id="ID4EMB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。| 
  
<a id="ID4ENC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (media/{marketplaceId}/browse)](uri-medialocalebrowseget.md)

&nbsp;&nbsp;1 つのメディア グループ内の項目を参照できます。 
 
<a id="ID4EXC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EZC"></a>

 
##### <a name="parent"></a>Parent 

[マーケットプレース URI](atoc-reference-marketplace.md)

  
<a id="ID4EDD"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   