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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651217"
---
# <a name="paginginfo-json"></a>PagingInfo (JSON)
ページのデータで返される結果のページング情報が含まれています。 
<a id="ID4EN"></a>

 
## <a name="paginginfo"></a>PagingInfo
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| continuationToken| string| 結果の次のページにアクセスするために使用する非透過的継続トークンです。 最大 32 文字です。呼び出し元がこの値を指定できます、 <b>continuationToken</b>次の一連のコレクション内の項目を取得するためにクエリ パラメーター。 このプロパティが場合<b>null</b>をコレクションに追加の項目はありません。 このプロパティは必須でありが提供されると、コレクションはページングされている場合でも<b>skipItems</b>します。| 
| totalItems| 32 ビット符号付き整数| コレクション内の項目の合計数。 これは、サービスは、コレクションのサイズにリアルタイム ビューを提供することがない場合、このレベルは提供されません。| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   