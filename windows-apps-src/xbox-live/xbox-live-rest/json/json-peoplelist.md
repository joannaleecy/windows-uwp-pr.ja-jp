---
title: PeopleList (JSON)
assetID: ac538652-c10c-44e5-c1e3-5314ebe8ba83
permalink: en-us/docs/xboxlive/rest/json-peoplelist.html
description: " PeopleList (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1f9ab412088707752d62cc20fd54da2639f26ddc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613327"
---
# <a name="peoplelist-json"></a>PeopleList (JSON)
コレクション[Person](json-person.md)オブジェクト。 
<a id="ID4ER"></a>

 
## <a name="peoplelist"></a>PeopleList
 
PeopleList オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| [People]| 配列[人](json-person.md)| [Person](json-person.md)連絡先リストを構成するオブジェクト。| 
| totalCount| 32 ビット符号なし整数| 合計数[Person](json-person.md)セットで使用可能なオブジェクト。 この値は、最新の応答だけでなく、セット全体のサイズを表すためにのページングのクライアントで使用できます。 値の例:680.| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
    "people": [
        {
            "xuid": "2603643534573573",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573572",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573577",
            "isFavorite": false,
            "isFollowingCaller": false
        },
    ],
    "totalCount": 3
}
    
```

  
<a id="ID4EJC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVC"></a>

 
##### <a name="reference"></a>リファレンス 

[GET (/users/{ownerId}/people)](../uri/people/uri-usersowneridpeopleget.md)

 [POST (/users/{ownerId}/people/xuids)](../uri/people/uri-usersowneridpeoplexuidspost.md)

   