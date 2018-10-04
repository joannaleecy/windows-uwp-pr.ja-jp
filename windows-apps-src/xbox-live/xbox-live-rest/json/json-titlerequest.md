---
title: TitleRequest (JSON)
assetID: 43aeb6f9-726d-9260-e2ba-f005ea688bf1
permalink: en-us/docs/xboxlive/rest/json-titlerequest.html
author: KevinAsgari
description: " TitleRequest (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 98adbf3f170c679452f4a78a18097b83e93faffa
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4310237"
---
# <a name="titlerequest-json"></a>TitleRequest (JSON)
タイトルに関する情報を要求します。 
<a id="ID4EN"></a>

 
## <a name="titlerequest"></a>TitleRequest
 
TitleRequest オブジェクトでは、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| id| 32 ビット符号なし整数| タイトルの識別子です。| 
| activity (アクティビティ)| [ActivityRequest](json-activityrequest.md)| タイトルでの利用可能な場合は、リッチ プレゼンスおよびメディア情報をなどの情報をします。| 
| 状態| string| かどうか、ユーザーがアクティブか。 ユーザーを非アクティブとしてマークするには、このフィールドが必要です。 既定では「アクティブ」です。| 
| 配置| string| タイトルの配置モード。 設定可能な値には、「完全」、「入力と」、「スナップ」または"background"が含まれます。 既定値は、「完全」です。| 
  
<a id="ID4EJC"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
  id:"12341234",
  placement:"snapped",
  state:"active",
  activity:
  {
    richPresence:
    {
      id:"playingMapWeapon",
      scid:"82b11353-08ba-48ca-9f1a-21627b189b0f"
    }
  }
}
    
```

  
<a id="ID4ESC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EUC"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E5C"></a>

 
##### <a name="reference"></a>リファレンス 

[POST (/users/xuid({xuid})/devices/current/titles/current)](../uri/presence/uri-usersxuiddevicescurrenttitlescurrentpost.md)

   