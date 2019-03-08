---
title: PermissionCheckBatchResponse (JSON)
assetID: f157ed8d-7483-1b34-bc3d-e3fcf6a7d055
permalink: en-us/docs/xboxlive/rest/json-permissioncheckbatchresponse.html
description: " PermissionCheckBatchResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6ac79d3361e83993c372b1d651e97e900788d39f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613347"
---
# <a name="permissioncheckbatchresponse-json"></a>PermissionCheckBatchResponse (JSON)
バッチのアクセス許可の結果は、複数のユーザーのアクセス許可の値の一覧を確認します。 
<a id="ID4EN"></a>

 
## <a name="permissioncheckbatchresponse"></a>PermissionCheckBatchResponse
 
PermissionCheckBatchResponse オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| Responses| 配列[PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)| 必須。 A [PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)権限ごとに、その要求と同じ順序で、元の要求で要求されているオブジェクト。| 
  
<a id="ID4EQB"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   