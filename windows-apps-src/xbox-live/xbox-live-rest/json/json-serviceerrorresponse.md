---
title: ServiceErrorResponse (JSON)
assetID: a2077df8-f76c-0233-8e41-68267b681862
permalink: en-us/docs/xboxlive/rest/json-serviceerrorresponse.html
author: KevinAsgari
description: " ServiceErrorResponse (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4da4a36bca0cad761ef4dda89f86b23f6cf44c30
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7432350"
---
# <a name="serviceerrorresponse-json"></a>ServiceErrorResponse (JSON)
サービスのエラーが発生した場合は、適切な HTTP エラー コードが返されます。 必要に応じて、サービスもあります ServiceErrorResponse オブジェクトの下に定義されています。 運用環境での低いデータを含めることができます。 
<a id="ID4EN"></a>

 
## <a name="serviceerrorresponse"></a>ServiceErrorResponse
 
ServiceErrorResponse オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>errorCode</b>| 32 ビット符号付き整数| (Null にすることができます) エラーに関連付けられたコード。| 
| <b>エラー メッセージ</b>| string| エラーに関する詳細を追加します。| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
   "errorCode": 8377,
   "errorMessage": "XUID specified in the claim does not match URI XUID."
 }
    
```

  
<a id="ID4E5B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   