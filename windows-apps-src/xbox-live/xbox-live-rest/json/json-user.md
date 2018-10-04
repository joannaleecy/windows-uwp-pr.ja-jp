---
title: User (JSON)
assetID: dbc733e4-0348-0e3d-1f55-17b465e599d6
permalink: en-us/docs/xboxlive/rest/json-user.html
author: KevinAsgari
description: " User (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7070d829000821cb48d8fcbaa4fde1d6f393b16a
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4313587"
---
# <a name="user-json"></a>User (JSON)
ユーザーのランキング データが含まれています。 
<a id="ID4EN"></a>

 
## <a name="user"></a>ユーザー
 
ユーザー オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| ゲーマータグ| string| (最大で 15 文字の) プレイヤーのゲーマータグです。 クライアントは、プレイヤーを識別するため、UI でこの値を使用する必要があります。| 
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

   