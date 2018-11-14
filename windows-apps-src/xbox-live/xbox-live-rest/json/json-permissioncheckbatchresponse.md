---
title: PermissionCheckBatchResponse (JSON)
assetID: f157ed8d-7483-1b34-bc3d-e3fcf6a7d055
permalink: en-us/docs/xboxlive/rest/json-permissioncheckbatchresponse.html
author: KevinAsgari
description: " PermissionCheckBatchResponse (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4b9996c8631b44eafcee3d5300c330ed4d89a296
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6261116"
---
# <a name="permissioncheckbatchresponse-json"></a>PermissionCheckBatchResponse (JSON)
バッチのアクセス許可の結果は、複数のユーザーのアクセス許可の値の一覧を確認します。 
<a id="ID4EN"></a>

 
## <a name="permissioncheckbatchresponse"></a>PermissionCheckBatchResponse
 
PermissionCheckBatchResponse オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| Responses| [PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)の配列| 必須。 その要求と同じ順序で、元の要求で要求されている各アクセス許可に対して[PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)オブジェクト。| 
  
<a id="ID4EQB"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
    "responses":
    [
        {
            "user": {"xuid":"12345"},
            "permissions":
            [
                {
                    "isAllowed":true
                },
                {
                    "isAllowed":true
                }
            ]
        },
        {
            "user": {"xuid":"54321"},
            "permissions":
            [
                {
                    "isAllowed":false,
                    "reasons":
                    [
                        {"reason":"NotAllowed"}
                    ]
                },
                {
                    "isAllowed":false,
                    "reasons":
                    [
                        {"reason":"PrivilegeRestrictsTarget", "restrictedSetting":"AllowProfileViewing"}
                    ]
                }
            ]
        }
    ]
}
    
```

  
<a id="ID4EZB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E2B"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   