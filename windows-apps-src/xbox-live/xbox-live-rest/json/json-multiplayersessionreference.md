---
title: MultiplayerSessionReference (JSON)
assetID: 6e03e060-8c9b-b394-415f-af7e85be569f
permalink: en-us/docs/xboxlive/rest/json-multiplayersessionreference.html
author: KevinAsgari
description: " MultiplayerSessionReference (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7dfa27115e1c7ebc9be657ff4fb3f6946406dd8b
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4679051"
---
# <a name="multiplayersessionreference-json"></a>MultiplayerSessionReference (JSON)
**MultiplayerSessionReference**を表す JSON オブジェクト。 
<a id="ID4EQ"></a>

  
 
MultiplayerSessionReference JSON オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| scid| GUID| サービス構成 id (SCID)。 セッション識別子のパート 1 です。| 
| templateName | string | セッション テンプレートの現在のインスタンスの名前です。 セッション識別子のパート 2 です。 | 
| name | string | セッションの名前です。 セッション識別子のパート 3 です。 | 
  
<a id="ID4EZ"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例 
 

```json
{
  "scid": "8d050174-412b-4d51-a29b-d55a34edfdb7",
  "templateName": "integration",
  "name": "19de0095d8bb41048f19edbbb6bc6b04"
}
  
    
```

  
<a id="ID4EJB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ELB"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVB"></a>

 
##### <a name="reference"></a>リファレンス 

[MultiplayerSession (JSON)](json-multiplayersession.md)

   