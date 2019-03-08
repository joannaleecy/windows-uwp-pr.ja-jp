---
title: LastSeenRecord (JSON)
assetID: 6a93202c-801c-03c6-8386-6acd0f366780
permalink: en-us/docs/xboxlive/rest/json-lastseenrecord.html
description: " LastSeenRecord (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e06de31cabaedb68ed57d3d4f2ff30614ceb6317
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613377"
---
# <a name="lastseenrecord-json"></a>LastSeenRecord (JSON)
システムが最終ユーザー、ユーザーが有効な DeviceRecord を持たないときに使用できるを見た場合について説明します。 
<a id="ID4EN"></a>

 
## <a name="lastseenrecord"></a>LastSeenRecord
 
LastSeenRecord オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| deviceType| string| ユーザーが最後にあるデバイスの種類。| 
| titleId| 32 ビット符号なし整数| ユーザーが最後の現在のタイトルの識別子です。| 
| titleName| string| ユーザーが最後の現在のタイトルの名前。| 
| タイムスタンプ| DateTime| ユーザーが最後の存在を示す UTC タイムスタンプ。| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E5C"></a>

 
##### <a name="reference"></a>リファレンス   