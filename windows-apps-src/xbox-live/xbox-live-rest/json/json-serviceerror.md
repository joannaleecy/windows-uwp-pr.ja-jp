---
title: ServiceError (JSON)
assetID: 81c43f6e-bfff-c4b5-d25c-eace22649f01
permalink: en-us/docs/xboxlive/rest/json-serviceerror.html
author: KevinAsgari
description: " ServiceError (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9f9f5cb3f4dc0565cafc073cea35e3e6e00d273f
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881658"
---
# <a name="serviceerror-json"></a>ServiceError (JSON)
サービスに呼び出しが失敗したときに返されるエラーに関する情報が含まれています。 
<a id="ID4EN"></a>

 
## <a name="serviceerror"></a>ServiceError
 
ServiceError オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| code| 32 ビットの符号付き整数 | エラーの種類です。 設定可能な値は、以下の表をご覧ください。 | 
| ソース| string | エラーが発生したサービスの名前です。 たとえば、値を<code>ReputationFD</code>評判サービスでエラーがあったことを示します。 | 
| description| string| エラーの説明。 | 
 
<a id="ID4EBC"></a>

 
### <a name="error-codes"></a>エラー コード
 
| 値| 説明| 
| --- | --- | --- | --- | --- | 
| 0| 成功エラーがない場合| 
| 4000| POST 要求に失敗しましたの検証で送信される要求本文 JSON ドキュメントが無効です。 詳細については説明フィールドを参照してください。 | 
| 4100| ユーザーはない存在の XUID を要求 URI に含まれているは XBOX Live で有効なユーザーにはありません。| 
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

[JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   