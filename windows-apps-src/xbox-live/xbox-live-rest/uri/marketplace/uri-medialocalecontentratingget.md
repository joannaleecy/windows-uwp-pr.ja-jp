---
title: GET (/media/{marketplaceId}/contentRating)
assetID: e677acdb-d905-3bea-b0ca-6d8becd663c0
permalink: en-us/docs/xboxlive/rest/uri-medialocalecontentratingget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/contentRating)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e4cfbbccea617a19d85b9f5601c33f94839dd9ae
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6048694"
---
# <a name="get-mediamarketplaceidcontentrating"></a>GET (/media/{marketplaceId}/contentRating)
コンテンツの規制のトークンを取得します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4ELB)
  * [クエリ文字列パラメーター](#ID4EWB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
複雑なタスクがキッズ子が表示できるコンテンツを適用することです。 だけでなく各メディア項目の種類は、独自の評価システムがそれらの評価システムは国によって異なることができます。 これはすべての項目を正しくフィルターを指定する必要があるデータの複数の異なる部分があることを意味します。
 
すべてのパラメーターを指定する、すべての API 呼び出しで、代わりは、この API は、その他の Api で**combinedContentRating**パラメーターに渡すし、同じ情報をまだ通信する値を生成します。 これは、この API に渡されるいくつかのパラメーターは、その他の Api の 1 つ、再利用可能な値に折りたたまれたとき、Api を使用し、保守、やすくするために設計されています。
 
頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(リリース エンターテイメント探索サービス (EDS) の間など)、そのため、長期間のキャッシュ可能性があります。 **CombinedContentRating**パラメーターにより、わかりやすいエラー メッセージで渡した値が有効である場合を受け入れることを意味する API 呼び出し元単なる必要があります、更新された値を取得するには、もう一度この API を呼び出します。 指定されていなければ、API が**combinedContentRating**パラメーターを受け取る場合、コンテンツのフィルター処理は行われません保護者に基づいています。 

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
| filterUnrated| ブール値| 省略可能。 か、応答に評価されるコンテンツを含めることがかどうかを決定します。| 
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

   