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
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8871183"
---
# <a name="permissioncheckbatchrequest-json"></a>PermissionCheckBatchRequest (JSON)
PermissionCheckBatchRequest オブジェクトのコレクションです。 
<a id="ID4EP"></a>

 
## <a name="permissioncheckbatchrequest"></a>PermissionCheckBatchRequest
 
PermissionCheckBatchRequest オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| Users| ユーザーの配列| 必須。 に対するアクセス許可を確認する対象の配列です。 この配列内の各エントリは、Xbox ユーザー ID (XUID) またはクロス ネットワークのシナリオの匿名のネットワークに接続してユーザーのいずれか (「匿名」:"allUsers")。 | 
| アクセス許可| [PermissionId 列挙型](../enums/privacy-enum-permissionid.md)の配列| 必須。 各ユーザーに照らしてチェックするアクセス許可します。| 
  
<a id="ID4E3B"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   