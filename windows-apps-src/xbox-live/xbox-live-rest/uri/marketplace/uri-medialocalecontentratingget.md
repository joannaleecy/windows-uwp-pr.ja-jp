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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641587"
---
# <a name="get-mediamarketplaceidcontentrating"></a>GET (/media/{marketplaceId}/contentRating)
コンテンツのレーティング トークンを取得します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4ELB)
  * [クエリ文字列パラメーター](#ID4EWB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
複雑なタスクは、子が参照を許可するコンテンツに対する保護者による制御を適用します。 だけでなくは各メディア項目の種類が、独自の評価システムが、これらの評価システムは、国を変更できます。 これはすべての項目を適切にフィルターを指定する必要があるデータのいくつかの異なる部分があることを意味します。
 
すべてのパラメーターを指定する、すべての API 呼び出しで、代わりに、この API に渡す値を生成**combinedContentRating**他の Api でのパラメーターと同じ情報を引き続き通信します。 これは、やすく Api を使用して、保守がその他の Api の 1 つの再利用可能な値にこの API に渡されるいくつかのパラメーターが折りたたまれている設計されています。
 
頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(リリース エンターテイメント検出サービス (EDS) の間など)、したがって、長期間のキャッシュ可能性があります。 API を受け入れる、 **combinedContentRating**パラメーターに渡された値が有効でない場合は、意味のあるエラー メッセージは、呼び出し元が単なる更新後の値を取得するには、もう一度この API を呼び出す必要がありますを示す値。 API を受け入れる場合、 **combinedContentRating**コンテンツのフィルター処理は行われません保護者による制限に基づいて、指定されたパラメーターが 1 つにはありません。 

> [!NOTE] 
> わけでは「安全」のみのコンテンツが返されるか--すべてのコンテンツが返されるか、明示的な可能性のあるコンテンツを含むことを意味します。 


  
<a id="ID4ELB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | 
| marketplaceId| string| 必須。 文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。| 
  
<a id="ID4EWB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| filterExplicit| ブール値| (省略可能)。 明示的な音楽をフィルター処理します。| 
| filterFamilyOnlyApps| ブール値| (省略可能)。 フィルター アプリのわかりやすいファミリとしてマークされません。| 
| filterUnrated| ブール値| (省略可能)。 かどうか、評価済みでないコンテンツを応答に含める必要があるかどうかを判断します。| 
| maxGameRating| 32 ビット符号付き整数| (省略可能)。 ゲームをフィルター処理します。| 
| maxMovieRating| 32 ビット符号付き整数| (省略可能)。 特定のレベルより上の映画をフィルター処理します。| 
| maxTVRating| 32 ビット符号付き整数| (省略可能)。 テレビをフィルター処理します。| 
  
<a id="ID4E5D"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAE"></a>

 
##### <a name="parent"></a>Parent 

[/media/{marketplaceId}/contentRating](uri-medialocalecontentrating.md)

  
<a id="ID4EKE"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS の一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace の Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   