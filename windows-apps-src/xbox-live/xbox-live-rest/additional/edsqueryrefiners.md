---
title: EDS クエリの絞り込み条件
assetID: ab5c066a-a48b-3042-351d-d0a15f663276
permalink: en-us/docs/xboxlive/rest/edsqueryrefiners.html
author: KevinAsgari
description: " EDS クエリの絞り込み条件"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b049965d619a7c25108e2b6308b18f1e402fecab
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4090424"
---
# <a name="eds-query-refiners"></a>EDS クエリの絞り込み条件
 
<a id="ID4EO"></a>

  
 
複数の対象となる一連の項目をエンターテイメント探索サービス (EDS) クエリを絞り込むは以下のパラメーターを使用できます。 いずれかの API に none これらのパラメーターが必要ですが、クエリの絞り込み条件を受け入れるいずれかの API でこれらを使用しています。
 
パラメーター名は"queryRefiners"パラメーターに値としてで渡すことができます。 このその後、戻り値のクエリの調整の各値ごとに分けて、要求されたクエリの調整を繰り返し発生する場合に返される項目の数が適用されます。
 
この作業の実践方法を次に示します。
 
   * 参照 API への呼び出しが行われた、パラメーターを含む"queryRefiners ジャンル ="します。
   * この API は、8 ゲームを返します。 だけでなく、項目の項目を持つ各ジャンルの一覧が返されます、と共にそのジャンルに属している項目の数。 ゲームの場合があります"一人称視点のシューティング: 3、パズル: 5"します。
   * 2 番目のクエリが行われます。 最初のと同じされる点を除けば"ジャンル一人称視点のシューティング ="が追加されます。
   * 応答には、「一人称視点のシューティング」カテゴリに属するすべての 3 つのゲームにはできるようになりましたが含まれています。
  
| パラメーター| データ型| 説明| 
| --- | --- | --- | 
| <b>年</b>| string| 10 年間ですべての項目する必要がありますリリースされています。| 
| <b>ジャンル</b>| 文字列の配列| すべての項目が必要なジャンルの一覧。| 
| <b>labelOwner</b>| string| アーティスト、アルバム、またはトラックに関連付けられているミュージック ラベル。| 
| <b>ネットワーク</b>| 文字列の配列| 項目を作成するネットワーク。| 
| <b>studio</b>| 文字列の配列| 項目の作成、studio します。| 
| <b>xboxAppCategories</b>| 文字列の配列| すべての Xbox アプリに必要なカテゴリの一覧。| 
| <b>xboxAvatarClothes</b>| 文字列の配列| 洋服の種類の一覧にすべての Xbox アバター項目が必要です。| 
| <b>xboxAvatarStores</b>| 文字列の配列| アバター項目所属するすべての Xbox にストアの一覧。| 
| <b>xboxGamePublisherBits</b>| 文字列の配列| すべてのゲームの種類の項目や AppType 項目に対して設定する必要がありますゲーム パブリッシャー ビットの一覧。| 
| <b>xboxIsBrowsable</b>| ブール値| <b>True</b>を返す場合は、実践的なコンテンツだけでなく、直接実践的な完全なゲームです。 既定値は<b>false</b>。| 
| <b>xboxHasChildMediaItemTypes</b>| 文字列の配列| ゲームのメディアのグループで返されたすべての項目がメディア項目の種類は、指定された値のいずれかの子が必要です。| 
  
<a id="ID4EEF"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGF"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ESF"></a>

 
##### <a name="further-information"></a>詳細情報 

[マーケットプレース URI](../uri/marketplace/atoc-reference-marketplace.md)

   