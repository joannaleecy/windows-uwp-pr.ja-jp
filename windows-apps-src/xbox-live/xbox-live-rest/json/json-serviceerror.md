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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57631707"
---
# <a name="serviceerror-json"></a>ServiceError (JSON)
サービスへの呼び出しが失敗したときに返されるエラーについてを説明します。 
<a id="ID4EN"></a>

 
## <a name="serviceerror"></a>ServiceError
 
サービス エラー オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| code| 32 ビット符号付き整数 | エラーの種類。 使用可能な値は、次の表を参照してください。 | 
| ソース| string | エラーが発生したサービスの名前。 たとえばの値<code>ReputationFD</code>評価サービスでエラーがあったことを示します。 | 
| 説明| string| エラーの説明。 | 
 
<a id="ID4EBC"></a>

 
### <a name="error-codes"></a>エラー コード
 
| Value| 説明| 
| --- | --- | --- | --- | --- | 
| 0| 成功エラーはありません| 
| 4000| POST 要求が失敗しました検証で送信される要求本文の JSON ドキュメントが無効です。 詳細については、説明フィールドを参照してください。 | 
| 4100| ユーザーがいない存在、XUID 要求 URI に含まれているは、XBOX Live の有効なユーザーを表していません。| 
| 4500| 承認エラー、呼び出し元は、要求された操作を実行する権限がありません。| 
| 5000| サービスで内部エラーがサービス エラー発生しました| 
| 5300| サービス利用不可、サービスは使用できません。| 
   
<a id="ID4EQE"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   