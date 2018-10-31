---
title: MatchTicket (JSON)
assetID: 12617677-47f2-e517-af53-5ab9687eea2a
permalink: en-us/docs/xboxlive/rest/json-matchticket.html
author: KevinAsgari
description: " MatchTicket (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5dbc410c809358c6df7a4eb2686b81c4017ed550
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5833128"
---
# <a name="matchticket-json"></a>MatchTicket (JSON)
プレイヤーがマルチプレイヤー セッション ディレクトリ (MPSD) を通じて他のプレイヤーを検索に使用するマッチ チケットを表す JSON オブジェクト。 
<a id="ID4EN"></a>

  
 
MatchTicket JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| serviceConfig| GUID| セッションのサービス構成 id (SCID)。| 
| hopperName| string| このチケットを配置すること、ホッパーの名前です。| 
| giveUpDuration| 32 ビット符号付き整数| 最大待機時間 (秒の整数)。| 
| preserveSession| 列挙型| セッションに一致するようになると、セッションを再利用する必要があるかどうかを示す値。 値は、「ことはありません」または"always"します。 | 
| ticketSessionRef| MultiplayerSessionReference| プレイヤーまたはグループは、現在再生中のセッションの<b>MultiplayerSessionReference</b>オブジェクトです。 このメンバーは必須です。 | 
| ticketAttributes| オブジェクトの配列| プレイヤーのユーザーが指定の属性と値について、チケットのコレクションです。| 
| プレイヤー| オブジェクトの配列| それぞれのユーザーが指定の属性のプロパティ バッグに、プレイヤーのオブジェクトのコレクションです。 | 
  
<a id="ID4EW"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
        "serviceConfig": "07617C5B-3423-4505-B6C6-10A16E1E5DDB",
        "hopperName": "TestHopper",
        "giveUpDuration": 10,
        "preserveSession": "never",
        "ticketSessionRef": {
        "scid": "AFFEABDF-0000-0000-0000-000000000001",
        "templateName": "TestTemplate",
        "sessionName": "5E551041-0000-0000-0000-000000000001"
    },
    "ticketAttributes": {
        "desiredMap": "Test Map",
        "desiredGameType": "Test GameType"
    },
    "players": [
        {
            "xuid": 123412345123,
            "playerAttributes": {
                "skill": 5,
                "ageRange": "teenager"
            }
        },
        {
          "xuid": 123412345124,
          "playerAttributes": {
              "skill": 15,
              "ageRange": "twenty-something"
          }
        }
      ]
    }
  
    
```

  
<a id="ID4EEB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGB"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   