---
title: MultiplayerActivityDetails (JSON)
assetID: f982aa5e-2694-4ef9-bc55-6c099a3cf9ec
permalink: en-us/docs/xboxlive/rest/json-multiplayeractivitydetails.html
description: " MultiplayerActivityDetails (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 188bcebb8d6bff879f30dcc83d7039fbcbfae0b2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658107"
---
# <a name="multiplayeractivitydetails-json"></a>MultiplayerActivityDetails (JSON)
表す JSON オブジェクト、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**します。 

> [!NOTE] 
> このオブジェクトは、2015年マルチ プレーヤーによって実装され、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 テンプレートのコントラクト/104 105 またはそれ以降で使用するものでは。  

 
<a id="ID4ES"></a>

  
 
MultiplayerActivityDetails JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | --- | 
| SessionReference| MultiplayerSessionReference| A <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionReference</b>セッションの識別情報を表すオブジェクト。| 
| handleId| 64 ビット符号なし整数| アクティビティに対応するハンドル ID。| 
| TitleId| 32 ビット符号なし整数| タイトル ID 活動に参加するために起動する必要があります。| 
| 表示| MultiplayerSessionVisibility| A <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b>セッションの可視性の状態を示す値。| 
| JoinRestriction| MultiplayerSessionJoinRestriction| A <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionJoinRestriction</b>セッションの結合の制限を示す値。 可視性のフィールドが「開いている」に設定されている場合、この制限が適用されます。| 
| ［不可］| ブール値| セッションが一時的に閉じている場合、参加するため、false それ以外の場合は true。| 
| OwnerXboxUserId| 64 ビット符号なし整数| 活動を所有するメンバーの Xbox ユーザー ID。| 
| MaxMembersCount| 32 ビット符号なし整数| 合計のスロットの数。| 
| MembersCount| 32 ビット符号なし整数| 占有されているスロットの数。| 
  
<a id="ID4E3D"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

```json
{
  "results": [{
    "id": "11111111-ebe0-42da-885f-033860a818f6",
    "type": "activity",
    "version": 1,
    "sessionRef": {
      "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
      "templateName": "party",
      "name": "e3a836aeac6f4cbe9bcab985494d3175"
    },
    "titleId": "1234567",
    "ownerXuid": "3212",

    // Only if ?include=relatedInfo
    "relatedInfo": {
      "visibility": "open",
      "joinRestriction": "followed",
      "closed": true,
      "maxMembersCount": 8,
      "membersCount": 4,
    }
  },
  {
    "id": "11111111-ebe0-42da-885f-033860a818f7",
    "type": "activity",
    "version": 1,
    "sessionRef": {
      "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
      "templateName": "TitleStorageTestDefault",
      "name": "795fcaa7-8377-4281-bd7e-e86c12843632"
    },
    "titleId": "1234567",
    "ownerXuid": "3212",

    // Only if ?include=relatedInfo
    "relatedInfo": {
      "visibility": "open",
      "joinRestriction": "followed",
      "closed": false,
      "maxMembersCount": 8,
      "membersCount": 4,
    }
  }]
}
    
```

  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   