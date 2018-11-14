---
title: PeopleList (JSON)
assetID: ac538652-c10c-44e5-c1e3-5314ebe8ba83
permalink: en-us/docs/xboxlive/rest/json-peoplelist.html
author: KevinAsgari
description: " PeopleList (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 261ab440091ce3825c1025e2831b054807910e94
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6253347"
---
# <a name="peoplelist-json"></a>PeopleList (JSON)
[Person](json-person.md)オブジェクトのコレクションです。 
<a id="ID4ER"></a>

 
## <a name="peoplelist"></a>PeopleList
 
PeopleList オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| People| [ユーザー](json-person.md)の配列| ユーザーのリストを構成する[Person](json-person.md)オブジェクト。| 
| totalCount| 32 ビットの符号なし整数| セットで利用可能な[Person](json-person.md)オブジェクトの合計数。 この値は、全体のセットだけでなく、最新の応答のサイズを表すためにのページングのクライアントで使用できます。 値の例: 680 します。| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVC"></a>

 
##### <a name="reference"></a>リファレンス 

[GET (/users/{ownerId}/people)](../uri/people/uri-usersowneridpeopleget.md)

 [POST (/users/{ownerId}/people/xuids)](../uri/people/uri-usersowneridpeoplexuidspost.md)

   