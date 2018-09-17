---
title: PagingInfo (JSON)
assetID: 645e575d-3e8e-d954-90e6-e51dd83da93b
permalink: en-us/docs/xboxlive/rest/json-paginginfo.html
author: KevinAsgari
description: " PagingInfo (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 933169945c865fc6bc6f7b8b7ba7872fff98d1b8
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3980978"
---
# <a name="paginginfo-json"></a>PagingInfo (JSON)
データのページで返される結果のページング情報が含まれています。 
<a id="ID4EN"></a>

 
## <a name="paginginfo"></a>PagingInfo
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| continuationToken| string| 結果の次のページにアクセスするために使用する不透明な継続トークンです。 最大 32 文字以下です。呼び出し元は、次のコレクション内の項目のセットを取得するために、 <b>continuationToken</b>クエリ パラメーターでは、この値を指定できます。 このプロパティが<b>null</b>の場合、項目がない追加コレクション内です。 このプロパティは、必要な場合でも、 <b>skipItems</b>でページングされるコレクションが提供されます。| 
| totalItems| 32 ビット符号付き整数| コレクション内の項目の合計数。 これが指定されていない場合は、サービスは、コレクションのサイズにリアルタイムで表示を提供することはできません。| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
   "continuationToken":"16354135464161213-0708c1ba-147f-48cc-9ad9-546gaadg648"
   "totalItems":5,
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   