---
title: User (JSON)
assetID: dbc733e4-0348-0e3d-1f55-17b465e599d6
permalink: en-us/docs/xboxlive/rest/json-user.html
description: " User (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5c1b3a34ef329696d51e615dd79d57783a132d05
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641357"
---
# <a name="user-json"></a>User (JSON)
ユーザーのランキング データが含まれています。 
<a id="ID4EN"></a>

 
## <a name="user"></a>ユーザー
 
ユーザー オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| ゲーマータグ| string| Player (15 文字の最大値) のゲーマータグです。 クライアントは、プレーヤーを識別するときに、UI にこの値を使用する必要があります。| 
| ランク| 32 ビット符号付き整数| ランキング データを要求するユーザーを基準としたユーザーのランク。| 
| rating| string| ユーザーの評価。| 
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID) のユーザー。| 
  
<a id="ID4EMC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{ 
   "gamertag":"TrueBlue402",
   "rank":2,
   "rating":"2:19:21.17",
   "xuid":1234567890123456 
}
    
```

  
<a id="ID4EVC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   