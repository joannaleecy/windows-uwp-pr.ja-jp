---
title: User (JSON)
assetID: dbc733e4-0348-0e3d-1f55-17b465e599d6
permalink: en-us/docs/xboxlive/rest/json-user.html
author: KevinAsgari
description: " User (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 255fe2918f10bb3b941cf2023ff358c58e191cbf
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6273053"
---
# <a name="user-json"></a>User (JSON)
ユーザーのランキング データが含まれています。 
<a id="ID4EN"></a>

 
## <a name="user"></a>ユーザー
 
ユーザー オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| ゲーマータグ| string| (最大で 15 文字の) プレイヤーのゲーマータグです。 クライアントは、プレイヤーを識別するために、UI でこの値を使用する必要があります。| 
| ランク| 32 ビット符号付き整数| ランキング データを要求しているユーザーを基準としたユーザーのランク。| 
| rating| string| ユーザーの評価です。| 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) ユーザーのします。| 
  
<a id="ID4EMC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   