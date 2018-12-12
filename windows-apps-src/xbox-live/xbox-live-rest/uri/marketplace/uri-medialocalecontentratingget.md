---
title: GET (/media/{marketplaceId}/contentRating)
assetID: e677acdb-d905-3bea-b0ca-6d8becd663c0
permalink: en-us/docs/xboxlive/rest/uri-medialocalecontentratingget.html
description: " GET (/media/{marketplaceId}/contentRating)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8d1cb9d09de8671d4cd3d61e96a8335412237e5c
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8944634"
---
# <a name="get-mediamarketplaceidcontentrating"></a>GET (/media/{marketplaceId}/contentRating)
コンテンツの規制のトークンを取得します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4ELB)
  * [クエリ文字列パラメーター](#ID4EWB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
保護者子が表示できるコンテンツを適用することは、複雑な作業です。 だけでなく各メディア項目の種類は、独自の評価システムがそれらの評価システムは国によって異なることができます。 これはすべての項目を適切にフィルターを指定する必要があるデータの複数の異なる部分があることを意味します。
 
すべてのパラメーターを指定する、すべての API 呼び出しで、代わりは、この API は、他の Api で**combinedContentRating**パラメーターに渡すし、同じ情報をまだ通信する値を生成します。 これは、この API に渡されるいくつかのパラメーターは、その他の Api の 1 つ、再利用可能な値に折りたたまれたとき、Api を使用し、保守、やすくするために設計されています。
 
頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(リリース エンターテイメント探索サービス (EDS) の間など)、したがって、長期間のキャッシュ可能性があります。 **CombinedContentRating**パラメーターにより、わかりやすいエラー メッセージで渡した値が有効である場合を受け入れることを意味する API 呼び出し元だけ必要があります、更新された値を取得するには、もう一度この API を呼び出します。 指定されていなければ、API が**combinedContentRating**パラメーターを受け取る場合、コンテンツのフィルター処理は行われません保護者に基づいています。 

> [!NOTE] 
> これとは限りません。 のみ"安全"コンテンツが返されること - すべてのコンテンツが返されること、明示的な可能性のあるコンテンツを含むことを意味します。 


  
<a id="ID4ELB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | 
| marketplaceId| string| 必須。 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。| 
  
<a id="ID4EWB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| filterExplicit| ブール値| 省略可能。 明示的な音楽をフィルター処理します。| 
| filterFamilyOnlyApps| ブール値| 省略可能。 わかりやすいファミリとしてマークいないアプリをフィルター処理します。| 
| filterUnrated| ブール値| 省略可能。 か、応答に評価されるコンテンツを含めることがかどうかを決定します。| 
| maxGameRating| 32 ビット符号付き整数| 省略可能。 ゲームをフィルター処理します。| 
| maxMovieRating| 32 ビット符号付き整数| 省略可能。 特定のレベルを超える映画をフィルター処理します。| 
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

   