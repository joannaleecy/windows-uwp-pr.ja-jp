---
title: /users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}
assetID: 0983dad0-59b7-45b7-505d-603e341fe0cc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeople.html
description: " /users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 85a6470a64ceef3b154384d1ca859fb28733aad3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632577"
---
# <a name="usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a>/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}
ソーシャル (ランク付け) ランキングにアクセスします。
これらの Uri のドメインが`leaderboards.xboxlive.com`します。

  * [URI パラメーター](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| xuid| string| ユーザーの識別子です。|
| scid| string| アクセスされるリソースを含むサービス構成の識別子です。|
| statname| string| アクセスされているユーザーの統計リソースの一意の識別子。|
| すべて\|お気に入り| 列挙| 現在のユーザーのすべての既知の連絡先またはお気に入りのユーザーとしてそのユーザーによって指定された連絡先のみ (スコア) の値、stat をランク付けするかどうか。|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})](uri-usersxuidscidstatnamepeopleget.md)

&nbsp;&nbsp;順位付け、stat かすべての既知の連絡先、現在のユーザーまたはユーザーのお気に入りとしてそのユーザーによって指定された連絡先のみ (スコア) の値では、ソーシャル ランキングを返します。

<a id="ID4EYC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E1C"></a>


##### <a name="parent"></a>Parent

[Uri のランキング](atoc-reference-leaderboard.md)
