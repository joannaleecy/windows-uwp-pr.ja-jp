---
title: TitleRecord (JSON)
assetID: 8e1bd699-e408-67c8-31da-2d968adfbc21
permalink: en-us/docs/xboxlive/rest/json-titlerecord.html
author: KevinAsgari
description: " TitleRecord (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4e7fb10a0f81e24215ebc24d2545f1197d4520bc
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4210745"
---
# <a name="titlerecord-json"></a>TitleRecord (JSON)
その名前と最終変更日のタイムスタンプを含む、タイトルに関する情報。 
<a id="ID4EN"></a>

 
## <a name="titlerecord"></a>TitleRecord
 
TitleRecord、DeviceRecord または、LastSeenRecord を含める必要がありますが、両方を含めない場合があります。
 
TitleRecord オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| id| 32 ビット符号なし整数| レコードのタイトル Id。| 
| name| string| タイトルのローカライズされた名前です。| 
| activity (アクティビティ)| [ActivityRecord](json-activityrecord.md)| タイトルでのユーザーのアクティビティ。 のみ深度"all"が返されます。| 
| lastModified| DateTime| レコードが最後に更新されたときにタイムスタンプを UTC です。| 
| 配置| string| ユーザー インターフェイス内でアプリの場所です。 可能性には、"fill"、「完全」、「スナップ」または"background"が含まれます。 既定値は、アプリを配置することができないデバイスの「完全」です。| 
| 状態| string| タイトルの状態。 「アクティブ」や「非アクティブ」にすることができます (既定)。 タイトルは、アクティビティおよび非アクティブの独自の基準に基づいて状態を設定します。| 
  
<a id="ID4E6C"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
      id:"12341234",
      name:"Contoso 5",
      state:"active",
      placement:"fill",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Team Deathmatch on Nirvana"
      }
    }
    
```

  
<a id="ID4EID"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EKD"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EUD"></a>

 
##### <a name="reference"></a>リファレンス 

[POST (/users/xuid({xuid})/devices/current/titles/current)](../uri/presence/uri-usersxuiddevicescurrenttitlescurrentpost.md)

   