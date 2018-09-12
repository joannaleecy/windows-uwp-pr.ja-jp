---
title: Presencerecord を要求して (JSON)
assetID: 414e6ef5-f7bd-70d0-7386-7aa1c3a56e21
permalink: en-us/docs/xboxlive/rest/json-presencerecord.html
author: KevinAsgari
description: " Presencerecord を要求して (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c365760f68aa7c87422e747606175ae9a12f0574
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882393"
---
# <a name="presencerecord-json"></a>Presencerecord を要求して (JSON)
1 人のユーザーのオンライン プレゼンスに関するデータ。
<a id="ID4EN"></a>


## <a name="presencerecord"></a>Presencerecord を要求して

Presencerecord を要求してオブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| xuid| string| Xbox ユーザー ID (XUID) 対象ユーザーのします。 提供されるプレゼンス データは、このユーザーによってです。|
| devices| [DeviceRecord](json-devicerecord.md)の配列| ユーザーのデバイスのレコードの一覧です。|
| 状態| string| Xbox live ユーザーのアクティビティ。 設定可能な値: <ul><li>オンライン: ユーザーは、少なくとも 1 つのデバイスのレコードを持っています。</li><li>離れた: ユーザーが Xbox LIVE にサインインした任意のタイトルでアクティブではありません。</li><li>オフライン: ユーザーでは、任意のデバイスに存在しません。</li></ul> | 
| lastSeen| [LastSeenRecord](json-lastseenrecord.md)| 最後に検出された情報は、ユーザーには、有効な DeviceRecords があるない場合のみ利用できます。 オブジェクトは、キャッシュから削除された場合、データが返されません、永続的なストアがないためです。|

<a id="ID4E2C"></a>


## <a name="sample-json-syntax"></a>JSON 構文の例


```json
{
  xuid:"0123456789",
  state:"online",
  devices:
  [{
    type:"D",
    titles:
    [{
      id:"12341234",
      name:"Contoso 5",
      state:"active",
      placement:"fill",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Team Deathmatch on Nirvana"
      }
    },
    {
      id:"12341235",
      name:"Contoso Waypoint",
      timestamp:"2012-09-17T07:15:23.4930000",
      placement:"snapped",
      state:"active",
      activity:
      {
        richPresence:"Using radar"
      }
    }]
  },
  {
    type:"W8",
    titles:
    [{
      id:"23452345",
      name:"Contoso Gamehelp",
      state:"active",
      placement:"full",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Nirvana page"
      }
    }]
  }]
}

```


<a id="ID4EED"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EGD"></a>


##### <a name="parent"></a>Parent

[JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)


<a id="ID4EQD"></a>


##### <a name="reference"></a>リファレンス

[POST (ユーザー/バッチ)](../uri/presence/uri-usersbatchpost.md)

 [取得する (ユーザー/me)](../uri/presence/uri-usersmeget.md)

 [削除 (/users/xuid({xuid})/devices/current/titles/current)](../uri/presence/uri-usersxuiddevicescurrenttitlescurrentdelete.md)

 [GET (/users/xuid({xuid}))](../uri/presence/uri-usersxuidget.md)
