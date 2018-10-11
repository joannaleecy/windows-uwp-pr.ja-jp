---
title: PermissionCheckResult (JSON)
assetID: 1cf147fa-4ff1-3299-0822-0fc1726d1600
permalink: en-us/docs/xboxlive/rest/json-permissioncheckresult.html
author: KevinAsgari
description: " PermissionCheckResult (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 308301b41b407291ffad74337172c5be8f4d2c59
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4508138"
---
# <a name="permissioncheckresult-json"></a>PermissionCheckResult (JSON)
1 つのターゲットのユーザーに対して 1 つのアクセス許可の設定の 1 人のユーザーからのチェックの結果。 
<a id="ID4EP"></a>

 
## <a name="permissioncheckresult"></a>PermissionCheckResult
 
PermissionCheckResult オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| 理由| string| 省略可能。 アクセス許可が拒否された理由を示す<b>PermissionResultCode</b>値<b>どう</b>が false の場合。| 
| restrictedSetting| string| 省略可能。 <b>理由</b>メンバーの<b>PermissionResultCode</b>値は、要求元の特権のチェックが失敗したことを示している場合は、どの特権が失敗したを示します。| 
  
<a id="ID4E6B"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   