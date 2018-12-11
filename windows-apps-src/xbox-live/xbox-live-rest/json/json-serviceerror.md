---
title: ServiceError (JSON)
assetID: 81c43f6e-bfff-c4b5-d25c-eace22649f01
permalink: en-us/docs/xboxlive/rest/json-serviceerror.html
description: " ServiceError (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: da3d682a1b66d25a12f21a93e9596d13afae7f90
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8872600"
---
# <a name="serviceerror-json"></a>ServiceError (JSON)
サービスに呼び出しが失敗したときに返されるエラーに関する情報が含まれています。 
<a id="ID4EN"></a>

 
## <a name="serviceerror"></a>ServiceError
 
ServiceError オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| code| 32 ビット符号付き整数 | エラーの種類です。 使用可能な値は、以下の表をご覧ください。 | 
| ソース| string | エラーが発生したサービスの名前。 たとえば、値の<code>ReputationFD</code>評判サービスでエラーがあったことを示します。 | 
| description| string| エラーの説明です。 | 
 
<a id="ID4EBC"></a>

 
### <a name="error-codes"></a>エラー コード
 
| 値| 説明| 
| --- | --- | --- | --- | --- | 
| 0| 成功エラーなし| 
| 4000| POST 要求に失敗しましたの検証で送信される要求本文 JSON ドキュメントが無効です。 詳細については説明フィールドを参照してください。 | 
| 4100| ユーザーがいない存在、XUID 要求 URI に含まれているは XBOX Live で有効なユーザーにはありません。| 
| 4500| 承認エラー、呼び出し元は、要求された操作を実行する権限がありません。| 
| 5000| サービスの内部エラーがあったにサービスのエラー| 
| 5300| サービス提供を停止、サービスは利用できません。| 
   
<a id="ID4EQE"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
    
```

  
<a id="ID4EZE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E2E"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   