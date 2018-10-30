---
title: LastSeenRecord (JSON)
assetID: 6a93202c-801c-03c6-8386-6acd0f366780
permalink: en-us/docs/xboxlive/rest/json-lastseenrecord.html
author: KevinAsgari
description: " LastSeenRecord (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8d4889ced5f8942c080b3336bda8c0d8d9b25af2
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5742804"
---
# <a name="lastseenrecord-json"></a>LastSeenRecord (JSON)
利用できるは、ユーザーには、有効な DeviceRecord があるないと、ユーザーが最後システムに表示されていた場合について説明します。 
<a id="ID4EN"></a>

 
## <a name="lastseenrecord"></a>LastSeenRecord
 
LastSeenRecord オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| deviceType| string| ユーザーが過去の現在のデバイスの種類。| 
| titleId| 32 ビットの符号なし整数| ユーザーが過去の現在のタイトルの識別子です。| 
| titleName| string| ユーザーが過去の現在のタイトルの名前です。| 
| タイムスタンプ| DateTime| Utc 形式のユーザーが過去の存在を示すタイムスタンプ。| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
  deviceType:W8,    
  titleId:"23452345",
  titleName:"My Awesome Game",
  timestamp:"2012-09-17T07:15:23.4930000"
}
    
```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E5C"></a>

 
##### <a name="reference"></a>リファレンス   