---
title: Person (JSON)
assetID: b49234b1-03cd-f16e-c293-c74174382167
permalink: en-us/docs/xboxlive/rest/json-person.html
author: KevinAsgari
description: " Person (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7e8e4ac4e91c4359ca20822297ccb625d09e3d59
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4616332"
---
# <a name="person-json"></a>Person (JSON)
People システムで 1 人のユーザーに関するメタデータ。 
<a id="ID4EN"></a>

 
## <a name="person"></a>人
 
Person オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| xuid| string| 必須。 Xbox ユーザー ID (XUID)、10 進数。 値の例: 2603643534573573 します。| 
| isFavorite| ブール値| 必須。 かどうかこのユーザーは、ユーザーが気詳細です。 ユーザーでは自分のユーザー リスト内にユーザー数が非常に大規模ながあるためお気に入りユーザーをエクスペリエンスに優先順位し、お気に入りではない他のユーザーの前に表示する必要があります。| 
| isFollowingCaller| ブール値| 省略可能。 このユーザーがユーザーをフォローするかどうかを代わりに、API 呼び出ししました。| 
| socialNetworks| 文字列の配列| 省略可能。 外部ネットワーク内でユーザーがこの人と関係のあります。| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
    "xuid": "2603643534573581",
    "isFavorite": false,
    "isFollowingCaller": false,
    "socialNetworks": ["LegacyXboxLive"]
}
    
```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a>リファレンス 

[/users/{ownerId}/people/{targetid}](../uri/people/uri-usersowneridpeopletargetid.md)

 [/users/{ownerId}/people/xuids](../uri/people/uri-usersowneridpeoplexuids.md)

   