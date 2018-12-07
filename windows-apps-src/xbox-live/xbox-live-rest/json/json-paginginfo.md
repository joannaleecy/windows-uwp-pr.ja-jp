---
title: PagingInfo (JSON)
assetID: 645e575d-3e8e-d954-90e6-e51dd83da93b
permalink: en-us/docs/xboxlive/rest/json-paginginfo.html
description: " PagingInfo (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0e773d73499e79fe23f736a536027932ca1a07b4
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8791660"
---
# <a name="paginginfo-json"></a>PagingInfo (JSON)
データのページで返される結果のページング情報が含まれています。 
<a id="ID4EN"></a>

 
## <a name="paginginfo"></a>PagingInfo
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| continuationToken| string| 結果の次のページにアクセスするために使用する不透明な継続トークンです。 最大 32 文字以下です。呼び出し元では、次のコレクション内の項目のセットを取得するために、 <b>continuationToken</b>クエリ パラメーターでは、この値を指定できます。 このプロパティが<b>null</b>の場合、項目がない追加コレクション内します。 このプロパティは、必要な場合でも、 <b>skipItems</b>でページングされるコレクションが提供されます。| 
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

   