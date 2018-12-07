---
title: UserSettings (JSON)
assetID: 17c030cb-05e0-f78e-5ab1-cdbd8b801ceb
permalink: en-us/docs/xboxlive/rest/json-usersettings.html
description: " UserSettings (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5451c59ab608105677a657ade41154bd2b622f5e
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8748325"
---
# <a name="usersettings-json"></a>UserSettings (JSON)
現在の認証されたユーザーの設定を返します。 
<a id="ID4EN"></a>

 
## <a name="usersettings"></a>UserSettings
 
UserSettings オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| id| 32 ビットの符号なし整数| 設定の識別子です。| 
| ソース| 32 ビットの符号なし整数| 設定のソースを表します。 | 
| titleId| 32 ビットの符号なし整数| 設定に関連付けられているタイトルの識別子です。 | 
| value| 8 ビットの符号なし整数の配列| 設定の値を表します。 クライアント設定を取得してデータを読み取ることができるため表現の書式設定する必要がありますについて説明します。 | 
  
<a id="ID4EJC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
   "id":268697600,
   "source":1,
   "titleId":1297287259,
   "value":"CAAAAA=="
}
    
```

  
<a id="ID4ESC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EUC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   