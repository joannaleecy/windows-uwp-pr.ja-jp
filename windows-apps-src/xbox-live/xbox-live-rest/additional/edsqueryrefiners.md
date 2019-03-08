---
title: EDS クエリの絞り込み条件
assetID: ab5c066a-a48b-3042-351d-d0a15f663276
permalink: en-us/docs/xboxlive/rest/edsqueryrefiners.html
description: " EDS クエリの絞り込み条件"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c00ff971e05003ec88c47d3803e565f6e9406c47
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611467"
---
# <a name="eds-query-refiners"></a>EDS クエリの絞り込み条件
 
<a id="ID4EO"></a>

  
 
対象が絞られた一連の項目をエンターテイメント検出サービス (EDS) クエリを絞り込むには、次のパラメーターを使用できます。 これらのパラメーターのいずれもが任意の API で必要ですが、クエリ絞り込みの条件を受け入れる任意の API でこれらを使用しています。
 
パラメーター名は"queryRefiners"パラメーターに値としてで渡すことができます。 このは、戻り値が、要求されたクエリの調整を繰り返し表示する場合に返される項目の数が適用される、クエリ絞り込み条件のそれぞれの値によって分類します。
 
この実習で作業する方法を次に示します。
 
   * 参照 API への呼び出しが行われるパラメーターを含める"queryRefiners ジャンルを ="。
   * API は、8 つのゲームを返します。 項目に加えて項目が含まれている各ジャンルの一覧と共に返される、項目の数がそのジャンルに属しています。 この可能性があります、ゲームの"Shooter:3、パズル:5".
   * 2 番目のクエリが行われます。 1 番目と同じことを除いて"ジャンル Shooter ="が追加されます。
   * 応答には、"Shooter"カテゴリに属するすべての 3 つだけのゲームが含まれるようになりました。
  
| パラメーター| データ型| 説明| 
| --- | --- | --- | 
| <b>10 年間</b>| string| 10 年間ですべての項目する必要がありますがリリースされています。| 
| <b>genre</b>| 文字列の配列| すべての項目が必要なジャンルのリスト。| 
| <b>labelOwner</b>| string| アーティスト、アルバム、またはトラックに関連付けられている音楽のラベル。| 
| <b>network</b>| 文字列の配列| このネットワークは、アイテムを作成します。| 
| <b>studio</b>| 文字列の配列| アイテムを作成、studio。| 
| <b>xboxAppCategories</b>| 文字列の配列| すべての Xbox アプリに必要なカテゴリの一覧。| 
| <b>xboxAvatarClothes</b>| 文字列の配列| Clothing の種類の一覧に Xbox アバターのすべての項目が必要です。| 
| <b>xboxAvatarStores</b>| 文字列の配列| アバターの項目が属する必要がありますすべてを Xbox にストアの一覧。| 
| <b>xboxGamePublisherBits</b>| 文字列の配列| すべてのゲームの種類の項目または AppType 項目で設定する必要がありますゲームの発行元のビットの一覧。| 
| <b>xboxIsBrowsable</b>| ブール値| 場合<b>true</b>、実践的なコンテンツだけでなく、直接操作ではない完全なゲームが返されます。 既定値は<b>false</b>します。| 
| <b>xboxHasChildMediaItemTypes</b>| 文字列の配列| ゲームのメディアのグループにすべての返された項目のメディア項目の種類が指定された値のいずれかの子が必要です。| 
  
<a id="ID4EEF"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGF"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ESF"></a>

 
##### <a name="further-information"></a>詳細情報 

[Marketplace の Uri](../uri/marketplace/atoc-reference-marketplace.md)

   