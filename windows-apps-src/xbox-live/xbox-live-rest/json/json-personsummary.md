---
title: PersonSummary (JSON)
assetID: 22fedb5f-5602-98d8-04a6-786fe3905921
permalink: en-us/docs/xboxlive/rest/json-personsummary.html
author: KevinAsgari
description: " PersonSummary (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cb093f624d27f28cace771896cf52146059bc332
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4359879"
---
# <a name="personsummary-json"></a>PersonSummary (JSON)
[ユーザー (JSON)](json-person.md)オブジェクトのコレクションです。 
<a id="ID4ER"></a>

 
## <a name="personsummary"></a>PersonSummary
 
PersonSummary オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| hasCallerMarkedTargetAsFavorite| ブール値| かどうか、呼び出し元では、お気に入りとして、ターゲットをマークいます。 値の例: true| 
| hasCallerMarkedTargetAsKnown| ブール値| かどうか、呼び出し元が、ターゲット済みとしてマーク呼ばれます。 値の例: true| 
| isCallerFollowingTarget| ブール値| かどうか、呼び出し元が、ターゲットをフォローします。 値の例: true| 
| isTargetFollowingCaller| ブール値| かどうか、ターゲットでは、呼び出し元がフォローします。 値の例: true| 
| legacyFriendStatus| string| 従来のフレンドのように、呼び出し元のターゲット状態です。 "None"、"MutuallyAccepted"、"OutgoingRequest"または"IncomingRequest"をすることができます。 値の例:"MutuallyAccepted"| 
| recentChangeCount| 32 ビット符号なし整数| 省略可能。 ターゲットのソーシャル グラフの最新の変更の数です。 この値は、ユーザーが、独自の概要を表示するときにのみ存在します。 値の例: 5| 
| targetFollowerCount| > 32 ビット符号なし整数| 次のターゲットはユーザーの数です。 値の例: 1308| 
| targetFollowingCount| 32 ビット符号なし整数| ターゲットは、次のユーザーの数です。 値の例: 112| 
| 透かし| string| 省略可能。 ターゲットの最新の変更透かしします。 この値は、ユーザーが、独自の概要を表示するときにのみ存在します。 値の例: 5| 
  
<a id="ID4E4D"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
    "targetFollowingCount": 87,
    "targetFollowerCount": 19,
    "isCallerFollowingTarget": true,
    "isTargetFollowingCaller": false,
    "hasCallerMarkedTargetAsFavorite": true,
    "hasCallerMarkedTargetAsKnown": true,
    "legacyFriendStatus": "None",
    "recentChangeCount": 5,
    "watermark": "5246775845000319351"
}
    
```

  
<a id="ID4EGE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIE"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   