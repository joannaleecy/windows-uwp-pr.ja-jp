---
title: GET (/media/{marketplaceId}/contentRating)
assetID: e677acdb-d905-3bea-b0ca-6d8becd663c0
permalink: en-us/docs/xboxlive/rest/uri-medialocalecontentratingget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/contentRating)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 456ae44dcffeede64011719c02dbeb3806792405
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4085630"
---
# <a name="get-mediamarketplaceidcontentrating"></a>GET (/media/{marketplaceId}/contentRating)
コンテンツの規制のトークンを取得します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4ELB)
  * [クエリ文字列パラメーター](#ID4EWB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
保護者子が表示できるコンテンツを適用することは、複雑な作業です。 だけでなく各メディア項目の種類は、独自の評価システムがそれらの評価システムは国によって異なることができます。 これはすべての項目を正しくフィルターを指定する必要があるデータの複数の異なる部分があることを意味します。
 
すべてのパラメーターを指定する、すべての API 呼び出しで、代わりは、この API は、その他の Api で**combinedContentRating**パラメーターに渡すとでも同じ情報を伝える値を生成します。 これは、この API に渡されるいくつかのパラメーターは、その他の Api の 1 つの再利用可能な値に折りたたまれたとき、Api を使用し、保守、やすくするために設計されています。
 
頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(リリース エンターテイメント探索サービス (EDS) の間など)、したがって、長期間のキャッシュ可能性があります。 **CombinedContentRating**パラメーターにより、わかりやすいエラー メッセージで渡した値が有効である場合を受け入れることを意味する API 呼び出し元だけ必要があります、更新された値を取得するには、もう一度この API を呼び出します。 API が**combinedContentRating**パラメーターを受け入れるいずれかが提供されない場合は、コンテンツのフィルター処理は行われません保護者に基づいています。 

> [!NOTE] 
> これとは限りません。 のみ"安全"コンテンツが返されること - すべてのコンテンツが返されること、明示的な可能性のあるコンテンツを含むことを意味します。 


  
<a id="ID4ELB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | 
| marketplaceId| string| 必須。 文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。| 
  
<a id="ID4EWB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| filterExplicit| ブール値| 省略可能。 明示的な音楽をフィルター処理します。| 
| filterFamilyOnlyApps| ブール値| 省略可能。 わかりやすいファミリとしてマークいないアプリをフィルター処理します。| 
| filterUnrated| ブール値| 省略可能。 か、評価されるコンテンツを応答に含める必要があるかどうかを決定します。| 
| maxGameRating| 32 ビット符号付き整数| 省略可能。 ゲームをフィルター処理します。| 
| maxMovieRating| 32 ビット符号付き整数| 省略可能。 特定のレベルよりも映画をフィルター処理します。| 
| maxTVRating| 32 ビット符号付き整数| 省略可能。 テレビをフィルター処理します。| 
  
<a id="ID4E5D"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAE"></a>

 
##### <a name="parent"></a>Parent 

[/media/{marketplaceId}/contentRating](uri-medialocalecontentrating.md)

  
<a id="ID4EKE"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [マーケットプレース URI](atoc-reference-marketplace.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   