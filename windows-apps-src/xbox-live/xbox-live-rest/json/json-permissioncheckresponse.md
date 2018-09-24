---
title: PermissionCheckResponse (JSON)
assetID: 7a749001-b569-b0e0-2a35-f299474c8710
permalink: en-us/docs/xboxlive/rest/json-permissioncheckresponse.html
author: KevinAsgari
description: " PermissionCheckResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f04da7d375b404a5d05dcf5d5e9905b00b7545d9
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4152484"
---
# <a name="permissioncheckresponse-json"></a>PermissionCheckResponse (JSON)
1 つの対象ユーザーに対して 1 つのアクセス許可の設定を 1 人のユーザーからチェックの結果。 
<a id="ID4EN"></a>

 
## <a name="permissioncheckresponse"></a>PermissionCheckResponse
 
PermissionCheckResponse オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| どう| ブール値| 必須。 このメンバーは、ターゲット ユーザーと要求された操作を実行する要求元のユーザーが許可されている場合<b>は true</b> 。| 
| 結果| [PermissionCheckResult (JSON)](json-permissioncheckresult.md)の配列| 省略可能。 <b>どう</b>された false 要求者に関連するもので、チェックが拒否された場合は、アクセス許可が拒否された理由を示します。| 
  
<a id="ID4E3B"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
    "isAllowed": false,
    "reasons":
    [
        {"reason": "BlockedByRequestor"},
        {"reason": "MissingPrivilege", "restrictedSetting": "VideoCommunications"}
    ]
}
    
```

  
<a id="ID4EFC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   