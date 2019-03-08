---
title: ページング パラメーター
assetID: f8d059fd-30e7-be60-0a46-c9a833c400c6
permalink: en-us/docs/xboxlive/rest/pagingparameters.html
description: " ページング パラメーター"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fe80e1666f9eab8caf7e0bbdb2b537bd7661c9a9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627297"
---
# <a name="paging-parameters"></a>ページング パラメーター
 
一部の Xbox Live サービス Uri は、JavaScript Object Notation (JSON) オブジェクトのコレクションを返します。 これらのコレクションは、ページングのパラメーターを指定する URI に接続されているクエリ文字列の一部としてによってを介してページングされることができます。 ページングのパラメーターの完全な一覧に従います。 ページングのパラメーターを許可するすべての Uri は、このページの下部にリンクされます。
 
<a id="ID4E2"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター 
 
| パラメーター| 必須| 種類| 説明| 
| --- | --- | --- | --- | 
| continuationToken| X| string| 指定された継続トークンで始まる項目を返します。 | 
| maxItems| X| 32 ビット符号付き整数| 組み合わせて使用できるコレクションから返されるアイテムの最大数<b>skipItems</b>と<b>continuationToken</b>を項目の範囲を返します。 場合、サービスは、既定値を指定可能性があります<b>maxItems</b>が存在しないより少ないを返すことが<b>maxItems</b>結果の最後のページが返されていない場合でも、します。 | 
| skipItems| X| 32 ビット符号付き整数| 指定されたアイテム数の後に開始アイテムを返します。 たとえば、 <b>skipItems =「3」</b>項目を取得以降の 4 番目の項目を取得します。 | 
  
<a id="ID4EDD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFD"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ERD"></a>

 
##### <a name="reference--get-usersxuidxuidachievementsuriachievementsuri-achievementsusersxuidachievementsgetv2md"></a>Reference  [GET (/users/xuid({xuid})/achievements)](../uri/achievements/uri-achievementsusersxuidachievementsgetv2.md)

   