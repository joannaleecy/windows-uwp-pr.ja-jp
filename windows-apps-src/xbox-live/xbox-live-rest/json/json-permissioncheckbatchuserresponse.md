---
title: PermissionCheckBatchUserResponse (JSON)
assetID: c587dbc1-9436-4d55-afcb-deb47e3c2664
permalink: en-us/docs/xboxlive/rest/json-permissioncheckbatchuserresponse.html
author: KevinAsgari
description: " PermissionCheckBatchUserResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 36726153d1364f384358471324452422f67741d2
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3933324"
---
# <a name="permissioncheckbatchuserresponse-json"></a>PermissionCheckBatchUserResponse (JSON)
バッチのアクセス許可の理由は、1 つのターゲット ユーザーのアクセス許可の値の一覧を確認します。 
<a id="ID4EN"></a>

 
## <a name="permissioncheckbatchuserresponse"></a>PermissionCheckBatchUserResponse
 
PermissionCheckBatchUserResponse オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| ユーザー| string| 必須。 このメンバーは、ターゲット ユーザーと要求された操作を実行する要求元のユーザーが許可されている場合<b>は true</b> 。| 
| アクセス許可| [PermissionCheckResponse (JSON)](json-permissioncheckresponse.md)の配列| 必須。 各要求と同じ順序で、元の要求で要求されたアクセス許可の[PermissionCheckResponse (JSON)](json-permissioncheckresponse.md) 。| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
    "User": {"Xuid": "12345"},
    "Permissions":
    [
        {
            "isAllowed": true
        },
        {
            "isAllowed": false
        },
        {
            "isAllowed": false,
            "reasons":
            [
                {"reason": "BlockedByRequestor"},
                {"reason": "MissingPrivilege", "restrictedSetting": "VideoCommunications"}
            ]
        }
    ]
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   