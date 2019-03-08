---
title: PersonSummary (JSON)
assetID: 22fedb5f-5602-98d8-04a6-786fe3905921
permalink: en-us/docs/xboxlive/rest/json-personsummary.html
description: " PersonSummary (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a787992507405a70185140e879be731d72806eff
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612627"
---
# <a name="personsummary-json"></a>PersonSummary (JSON)
コレクション[人 (JSON)](json-person.md)オブジェクト。 
<a id="ID4ER"></a>

 
## <a name="personsummary"></a>PersonSummary
 
PersonSummary オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| hasCallerMarkedTargetAsFavorite| ブール値| かどうか、呼び出し元が、ターゲットは、お気に入りとしてマークしました。 例の値: true| 
| hasCallerMarkedTargetAsKnown| ブール値| かどうか、呼び出し元がマーク ターゲットと呼ばれます。 例の値: true| 
| isCallerFollowingTarget| ブール値| かどうか、呼び出し元が、ターゲットをフォローします。 例の値: true| 
| isTargetFollowingCaller| ブール値| かどうか、ターゲットが呼び出し元をフォローします。 例の値: true| 
| legacyFriendStatus| string| 呼び出し側から見た対象の状態を従来のフレンドです。 "None"、"MutuallyAccepted"、"OutgoingRequest"または"IncomingRequest"を指定できます。 値の例:"MutuallyAccepted"| 
| recentChangeCount| 32 ビット符号なし整数| (省略可能)。 ターゲットのソーシャル グラフでの最近の変更の数。 この値は、ユーザーが独自の概要を表示するときにのみ存在します。 値の例:5| 
| targetFollowerCount| > 32 ビット符号なし整数| ターゲットをフォローしているユーザーの数。 値の例:1308| 
| targetFollowingCount| 32 ビット符号なし整数| ターゲットは、次のユーザーの数。 値の例:112| 
| 基準値| string| (省略可能)。 ターゲットの最近の変更ウォーターマーク。 この値は、ユーザーが独自の概要を表示するときにのみ存在します。 値の例:5| 
  
<a id="ID4E4D"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   