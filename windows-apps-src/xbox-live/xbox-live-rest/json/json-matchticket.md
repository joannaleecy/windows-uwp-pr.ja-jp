---
title: MatchTicket (JSON)
assetID: 12617677-47f2-e517-af53-5ab9687eea2a
permalink: en-us/docs/xboxlive/rest/json-matchticket.html
description: " MatchTicket (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4bc638dfe7735856295ed92f35e244213be7bc1e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608337"
---
# <a name="matchticket-json"></a>MatchTicket (JSON)
一致するチケット、プレイヤー、マルチ プレーヤーのセッション ディレクトリ (MPSD) を介して他のプレーヤーを見つけたりするために使用を表す JSON オブジェクトです。 
<a id="ID4EN"></a>

  
 
MatchTicket JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| serviceConfig| GUID| セッションのサービス構成識別子 (SCID)。| 
| hopperName| string| このチケットの配置の hopper の名前です。| 
| giveUpDuration| 32 ビット符号付き整数| 最大待機時間 (秒単位の整数)。| 
| preserveSession| 列挙| 一致するセッションとしてセッションを再利用する必要があるかどうかを示す値。 指定できる値は、"never"または「常に」です。 | 
| ticketSessionRef| MultiplayerSessionReference| <b>MultiplayerSessionReference</b>プレーヤーまたはグループが現在を再生中のセッションのオブジェクト。 このメンバーが常に必要です。 | 
| ticketAttributes| オブジェクトの配列| プレイヤーのユーザーが指定した属性と、チケットに関する値のコレクションです。| 
| プレーヤー| オブジェクトの配列| ユーザーが指定した属性のプロパティ バッグと各プレイヤーのオブジェクトのコレクションです。 | 
  
<a id="ID4EW"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   