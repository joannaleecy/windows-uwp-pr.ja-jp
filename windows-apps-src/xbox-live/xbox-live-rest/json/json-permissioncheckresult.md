---
title: PermissionCheckResult (JSON)
assetID: 1cf147fa-4ff1-3299-0822-0fc1726d1600
permalink: en-us/docs/xboxlive/rest/json-permissioncheckresult.html
description: " PermissionCheckResult (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dc13826be1b6f81201d069f5ade7ea5ba6668cd0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598447"
---
# <a name="permissioncheckresult-json"></a>PermissionCheckResult (JSON)
1 つのターゲット ユーザーに対して 1 つのアクセス許可の設定の 1 人のユーザーからのチェックの結果。 
<a id="ID4EP"></a>

 
## <a name="permissioncheckresult"></a>PermissionCheckResult
 
PermissionCheckResult オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| reason| string| (省略可能)。 A <b>PermissionResultCode</b> 、アクセス許可が拒否された理由を示す値場合<b>IsAllowed</b>が false であった。| 
| restrictedSetting| string| (省略可能)。 場合、 <b>PermissionResultCode</b>値、<b>理由</b>メンバーは、要求元の権限の確認が失敗したことを示す特権の失敗を示します。| 
  
<a id="ID4E6B"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
    "reason": "MissingPrivilege",
    "restrictedSetting": "VideoCommunications"
}
    
```

  
<a id="ID4EIC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EKC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   