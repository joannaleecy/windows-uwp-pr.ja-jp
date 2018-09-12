---
title: ユーザー/xuid ({xuid})/scids/{scid}/stats/{statname) そして {すべて | お気に入り}
assetID: 0983dad0-59b7-45b7-505d-603e341fe0cc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeople.html
author: KevinAsgari
description: " ユーザー/xuid ({xuid})/scids/{scid}/stats/{statname) そして {すべて | お気に入り}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 161c7e96faf3ec217aeb188ccb3b5b1e354d217e
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3928719"
---
# <a name="usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a>ユーザー/xuid ({xuid})/scids/{scid}/stats/{statname) そして {すべて | お気に入り}
ソーシャル (ランク付け) ランキングにアクセスします。
これらの Uri のドメインが`leaderboards.xboxlive.com`します。

  * [URI パラメーター](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| xuid| string| ユーザーの識別子です。|
| scid| string| アクセス対象のリソースが含まれているサービス構成の識別子です。|
| statname| string| アクセス対象のユーザー統計リソースの一意の識別子。|
| all\ | お気に入り| 列挙値| 現在のユーザーの既知のすべての連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) の値、統計をランク付けするかどうか。|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})](uri-usersxuidscidstatnamepeopleget.md)

&nbsp;&nbsp;ランキング、統計の現在のユーザーのいずれかのすべての既知連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) の値によって、ソーシャル ランキングを返します。

<a id="ID4EYC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E1C"></a>


##### <a name="parent"></a>Parent

[ランキングの Uri](atoc-reference-leaderboard.md)
