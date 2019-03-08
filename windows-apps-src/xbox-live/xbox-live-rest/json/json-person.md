---
title: Person (JSON)
assetID: b49234b1-03cd-f16e-c293-c74174382167
permalink: en-us/docs/xboxlive/rest/json-person.html
description: " Person (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 175d66ffc7744ca8203fe7681fcb0167e150f012
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640867"
---
# <a name="person-json"></a>Person (JSON)
ユーザーのシステムで 1 人のユーザーに関するメタデータ。 
<a id="ID4EN"></a>

 
## <a name="person"></a>人
 
Person オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| xuid| string| 必須。 Xbox ユーザー ID (XUID)、10 進数です。 値の例:2603643534573573.| 
| isFavorite| ブール値| 必須。 かどうかこの人は、ユーザーが関心の詳細です。 ユーザーがユーザー一覧にユーザー数が非常に大きいことがあるできます、ため、大好きな人をエクスペリエンスの優先順位し、お気に入りのない他のユーザーの前に表示する必要があります。| 
| isFollowingCaller| ブール値| (省略可能)。 このユーザーがユーザーをフォローしているかどうかが代わりに API 呼び出しが行われました。| 
| socialNetworks| 文字列の配列| (省略可能)。 この人と、ユーザーは、外部ネットワーク内でリレーションシップを持ちます。| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a>リファレンス 

[/users/{ownerId}/people/{targetid}](../uri/people/uri-usersowneridpeopletargetid.md)

 [/users/{ownerId}/people/xuids](../uri/people/uri-usersowneridpeoplexuids.md)

   