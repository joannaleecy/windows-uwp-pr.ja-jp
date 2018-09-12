---
title: EDS は、絞り込み条件をクエリします。
assetID: ab5c066a-a48b-3042-351d-d0a15f663276
permalink: en-us/docs/xboxlive/rest/edsqueryrefiners.html
author: KevinAsgari
description: " EDS は、絞り込み条件をクエリします。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b049965d619a7c25108e2b6308b18f1e402fecab
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881729"
---
# <a name="eds-query-refiners"></a>EDS は、絞り込み条件をクエリします。
 
<a id="ID4EO"></a>

  
 
次のパラメーターよりターゲット一連の項目をエンターテイメント探索サービス (EDS) クエリを絞り込むされることができます。 すべての API でのこれらのパラメーターが必要ですが、クエリの絞り込み条件を受け入れるすべての API でこれらを使用しています。
 
パラメーターの名前は、その値として"queryRefiners"パラメーターにで渡すことができます。 このは、戻り値、要求されたクエリの調整を繰り返し発生する場合に返される項目の数が適用されると、クエリの調整の各値ごとに分類します。
 
この作業実践方法を以下に示します。
 
   * 参照 API への呼び出しが行われたなど、パラメーターは、"queryRefiners ジャンルを ="。
   * API は、8 つのゲームを返します。 だけでなく、項目の項目を持つ各ジャンルの一覧が返されますと共に、項目の数がそのジャンルに属しています。 ゲームの場合があります"一人称視点のシューティング: 3、パズル: 5"。
   * 2 番目のクエリが行われます。 最初のと同じですが、"ジャンル = 一人称視点のシューティング"が追加されます。
   * 応答には、「一人称視点のシューティング」カテゴリに属するすべての 3 つのみのゲームにはできるようになりましたが含まれています。
  
| パラメーター| データ型| 説明| 
| --- | --- | --- | 
| <b>年</b>| string| 10 年間ですべての項目する必要がありますリリースされています。| 
| <b>ジャンル</b>| 文字列の配列| すべての項目が必要なジャンルの一覧。| 
| <b>labelOwner</b>| string| アーティスト、アルバム、またはトラックに関連付けられているミュージック ラベル。| 
| <b>ネットワーク</b>| 文字列の配列| 項目を作成したネットワーク。| 
| <b>studio</b>| 文字列の配列| 項目を作成した studio。| 
| <b>xboxAppCategories</b>| 文字列の配列| すべての Xbox アプリに必要なカテゴリの一覧。| 
| <b>xboxAvatarClothes</b>| 文字列の配列| すべての Xbox アバター項目洋服の種類の一覧が必要です。| 
| <b>xboxAvatarStores</b>| 文字列の配列| どのすべての Xbox にアバター項目が所属する必要がありますストアの一覧。| 
| <b>xboxGamePublisherBits</b>| 文字列の配列| すべてのゲームの種類の項目や AppType 項目に対して設定する必要がありますゲーム パブリッシャー ビットの一覧。| 
| <b>xboxIsBrowsable</b>| ブール値| <b>True</b>を返す場合は、実践的なコンテンツだけでなく、直接操作できる完全なゲームです。 既定値は<b>false</b>。| 
| <b>xboxHasChildMediaItemTypes</b>| 文字列の配列| ゲームのメディアのグループで返された項目にすべてのメディア項目の種類は、指定された値のいずれかの子が必要です。| 
  
<a id="ID4EEF"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGF"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ESF"></a>

 
##### <a name="further-information"></a>詳細情報 

[Marketplace Uri](../uri/marketplace/atoc-reference-marketplace.md)

   