---
title: ページング パラメーター
assetID: f8d059fd-30e7-be60-0a46-c9a833c400c6
permalink: en-us/docs/xboxlive/rest/pagingparameters.html
author: KevinAsgari
description: " ページング パラメーター"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 337093fe7c75efee1be1ff18f94249b6693cdf84
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7556498"
---
# <a name="paging-parameters"></a>ページング パラメーター
 
一部の Xbox Live サービス Uri では、JavaScript Object Notation (JSON) オブジェクトのコレクションを返します。 これらのコレクションは、URI に接続されているクエリ文字列の一部としてページング パラメーターを指定することによって、を通じてページことができます。 ページング パラメーターの完全な一覧に依存します。 ページング パラメーターを許可するすべての Uri は、このページの下部にリンクされます。
 
<a id="ID4E2"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター 
 
| パラメーター| 必須かどうか| 種類| 説明| 
| --- | --- | --- | --- | 
| continuationToken| いいえ| string| 特定の継続トークンから項目を返します。 | 
| maxItems| いいえ| 32 ビット符号付き整数| <b>SkipItems</b>と範囲の項目を返す<b>continuationToken</b>と組み合わせることができるコレクションから返される項目の最大数。 サービスに結果の最後のページが返されていない場合でもは<b>maxItems</b>が存在しないと、 <b>maxItems</b>より少ないを返す可能性がある場合、既定値を提供可能性があります。 | 
| skipItems| いいえ| 32 ビット符号付き整数| 特定の項目数後以降の項目を返します。 たとえば、 <b>skipItems =「3」</b>項目を取得以降では、4 番目の項目を取得します。 | 
  
<a id="ID4EDD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFD"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ERD"></a>

 
##### <a name="reference--get-usersxuidxuidachievementsuriachievementsuri-achievementsusersxuidachievementsgetv2md"></a>参照[を取得する (/users/xuid({xuid})/achievements)](../uri/achievements/uri-achievementsusersxuidachievementsgetv2.md)

   