---
title: PermissionCheckBatchRequest (JSON)
assetID: 3100b17c-1b60-fdf2-3af9-7e424f1903ee
permalink: en-us/docs/xboxlive/rest/json-permissioncheckbatchrequest.html
description: " PermissionCheckBatchRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 538547c85648970ab3e9fe3ae413e8a03df814ad
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623507"
---
# <a name="permissioncheckbatchrequest-json"></a>PermissionCheckBatchRequest (JSON)
PermissionCheckBatchRequest オブジェクトのコレクション。 
<a id="ID4EP"></a>

 
## <a name="permissioncheckbatchrequest"></a>PermissionCheckBatchRequest
 
PermissionCheckBatchRequest オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| Users| ユーザーの配列| 必須。 に対するアクセス許可を確認するターゲットの配列。 この配列内の各エントリは Xbox ユーザー ID (XUID) またはネットワーク間のシナリオに対する匿名のネットワークに接続してユーザーのいずれか (「匿名」:"allUsers")。 | 
| アクセス許可| 配列[PermissionId 列挙型](../enums/privacy-enum-permissionid.md)| 必須。 各ユーザーに対して確認するアクセス許可。| 
  
<a id="ID4E3B"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
    "users":
    [
        {"xuid":"12345"},
        {"xuid":"54321"}
    ],
    "permissions":
    [
        "ShareFriendList",
        "ShareGameHistory"
    ]
}
    
```

  
<a id="ID4EFC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   