---
title: /users/xuid({xuid})/achievements/{scid}/{achievementid}
assetID: 656a6d63-1a11-b0a5-63d2-2b010abd62e7
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementid.html
description: " /users/xuid({xuid})/achievements/{scid}/{achievementid}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 00c577f60b67f15f75c47b5e737ca12819695110
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599447"
---
# <a name="usersxuidxuidachievementsscidachievementid"></a>/users/xuid({xuid})/achievements/{scid}/{achievementid}
その構成済みのメタデータとユーザーに固有のデータを含む、実績に関する詳細を返します。 

> [!NOTE] 
> プラットフォームでのみサポートされます。 

 
これらの Uri のドメインが`achievements.xboxlive.com`します。
 
  * [URI パラメーター](#ID4E2)
 
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID)、ユーザーがリソースにアクセスされているのです。 認証されたユーザーの XUID に一致する必要があります。| 
| scid| GUID| 達成にアクセスしているサービス構成の一意の識別子。| 
| achievementid| 32 ビット符号なし整数| アクセスされている実績を (指定された SCID) 内で一意の識別子です。| 
  
<a id="ID4EMC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})](uri-usersxuidachievementsscidachievementidget.md)

&nbsp;&nbsp;実績の詳細を取得します。
 
<a id="ID4EWC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EYC"></a>

 
##### <a name="parent"></a>Parent 

[アチーブメントの Uri](atoc-reference-achievementsv2.md)

   