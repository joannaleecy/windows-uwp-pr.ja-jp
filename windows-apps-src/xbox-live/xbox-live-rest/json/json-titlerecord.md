---
title: TitleRecord (JSON)
assetID: 8e1bd699-e408-67c8-31da-2d968adfbc21
permalink: en-us/docs/xboxlive/rest/json-titlerecord.html
description: " TitleRecord (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 89baf7e9a737428d492246f1647a561a4a8170cf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603987"
---
# <a name="titlerecord-json"></a>TitleRecord (JSON)
タイトル、名前、最終変更タイムスタンプなどについて説明します。 
<a id="ID4EN"></a>

 
## <a name="titlerecord"></a>TitleRecord
 
TitleRecord DeviceRecord、または、LastSeenRecord、含める必要がありますは含まれません。
 
TitleRecord オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| id| 32 ビット符号なし整数| レコードのタイトルの Id。| 
| name| string| ローカライズされたタイトルの名前。| 
| activity (アクティビティ)| [ActivityRecord](json-activityrecord.md)| タイトル内のユーザーのアクティビティ。 深さが"all"かどうかにのみ返されます。| 
| lastModified| DateTime| レコードが最後に更新されたときの UTC タイムスタンプ。| 
| 配置| string| ユーザー インターフェイス内でアプリの場所。 可能性には、"fill"、"full"、「スナップ」または"background"が含まれます。 既定では「完全」のデバイス アプリを配置することはできません。| 
| 状態| string| タイトルの状態。 "Active"または「非アクティブ」にすることができます (既定)。 タイトルは、アクティビティおよび非アクティブ状態の基準に基づいて状態を設定します。| 
  
<a id="ID4E6C"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EUD"></a>

 
##### <a name="reference"></a>リファレンス 

[POST (/users/xuid({xuid})/devices/current/titles/current)](../uri/presence/uri-usersxuiddevicescurrenttitlescurrentpost.md)

   