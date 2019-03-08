---
title: MultiplayerSessionReference (JSON)
assetID: 6e03e060-8c9b-b394-415f-af7e85be569f
permalink: en-us/docs/xboxlive/rest/json-multiplayersessionreference.html
description: " MultiplayerSessionReference (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5986079e1cae3338d8cc24a9e85f6941cf4fbec4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651247"
---
# <a name="multiplayersessionreference-json"></a>MultiplayerSessionReference (JSON)
表す JSON オブジェクト、 **MultiplayerSessionReference**します。 
<a id="ID4EQ"></a>

  
 
MultiplayerSessionReference JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| scid| GUID| サービス構成の識別子 (SCID) です。 パート 1 のセッション識別子。| 
| templateName | string | セッション テンプレートの現在のインスタンスの名前です。 パート 2 のセッション識別子。 | 
| name | string | セッションの名前。 パート 3 のセッション識別子。 | 
  
<a id="ID4EZ"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文 
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVB"></a>

 
##### <a name="reference"></a>リファレンス 

[MultiplayerSession (JSON)](json-multiplayersession.md)

   