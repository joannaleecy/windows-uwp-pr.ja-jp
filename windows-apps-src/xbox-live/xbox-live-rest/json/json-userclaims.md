---
title: UserClaims (JSON)
assetID: f88d5ee0-2875-fcfb-3098-3cd6afce8748
permalink: en-us/docs/xboxlive/rest/json-userclaims.html
author: KevinAsgari
description: " UserClaims (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 718c5847a1588e492c5d290d042dd4d5a9ca4283
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5691755"
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

   