---
title: MultiplayerActivityDetails (JSON)
assetID: f982aa5e-2694-4ef9-bc55-6c099a3cf9ec
permalink: en-us/docs/xboxlive/rest/json-multiplayeractivitydetails.html
author: KevinAsgari
description: " MultiplayerActivityDetails (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a23b4f984bc7edef77af7e020b62fcc7d8fcbf9f
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5746845"
---
# <a name="multiplayeractivitydetails-json"></a>MultiplayerActivityDetails (JSON)
**Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**を表す JSON オブジェクト。 

> [!NOTE] 
> このオブジェクトは、2015年マルチプレイヤーで実装され、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用する概念があることです。  

 
<a id="ID4ES"></a>

  
 
MultiplayerActivityDetails JSON オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | --- | 
| SessionReference| MultiplayerSessionReference| セッションの識別情報を表す<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionReference</b>オブジェクトを返します。| 
| ハンドル id を使用| 64 ビットの符号なし整数| アクティビティに対応するハンドル ID です。| 
| TitleId| 32 ビットの符号なし整数| タイトル ID は、アクティビティに参加するために起動する必要があります。| 
| 表示| MultiplayerSessionVisibility| セッションの可視性の状態を示す<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b>値。| 
| による| MultiplayerSessionJoinRestriction| セッションへの参加制限を示す<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionJoinRestriction</b>値。 表示のフィールドが「開く」に設定されている場合、この制限が適用されます。| 
| 終了| ブール値| セッションが一時的に閉じている場合、参加するため、false それ以外の場合は true。| 
| OwnerXboxUserId| 64 ビットの符号なし整数| アクティビティを所有しているメンバーの Xbox ユーザー ID。| 
| MaxMembersCount| 32 ビットの符号なし整数| スロットの合計数。| 
| MembersCount| 32 ビットの符号なし整数| スロットを占有の数。| 
  
<a id="ID4E3D"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   