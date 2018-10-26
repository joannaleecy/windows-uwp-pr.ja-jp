---
title: UserClaims (JSON)
assetID: f88d5ee0-2875-fcfb-3098-3cd6afce8748
permalink: en-us/docs/xboxlive/rest/json-userclaims.html
author: KevinAsgari
description: " UserClaims (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 92595459537e10b9786022e2a450a117496eaffa
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5556109"
---
# <a name="userclaims-json"></a>UserClaims (JSON)
現在の認証されたユーザーに関する情報を返します。 
<a id="ID4EN"></a>

 
## <a name="userclaims"></a>UserClaims
 
UserClaims オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| ゲーマータグ| string| ユーザーのゲーマータグです。| 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) ユーザーのします。| 
  
<a id="ID4EZB"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
   "xuid" : 2533274790412952,
   "gamertag" : "gamer"

}
    
```

  
<a id="ID4ECC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   