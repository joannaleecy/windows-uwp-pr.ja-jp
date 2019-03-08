---
title: ServiceErrorResponse (JSON)
assetID: a2077df8-f76c-0233-8e41-68267b681862
permalink: en-us/docs/xboxlive/rest/json-serviceerrorresponse.html
description: " ServiceErrorResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 86f9389f6f76c1c51955a6c784393e9b05909298
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57597507"
---
# <a name="serviceerrorresponse-json"></a>ServiceErrorResponse (JSON)
サービスのエラーが発生した場合に適切な HTTP エラー コードが返されます。 必要に応じて、以下に定義されている、サービスは ServiceErrorResponse オブジェクトを含めることもできます。 運用環境での低いデータを含めることができます。 
<a id="ID4EN"></a>

 
## <a name="serviceerrorresponse"></a>ServiceErrorResponse
 
ServiceErrorResponse オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>errorCode</b>| 32 ビット符号付き整数| (Null にすることができます)、エラーに関連付けられているコードです。| 
| <b>errorMessage</b>| string| エラーの詳細を追加します。| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   