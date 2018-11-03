---
title: /users/xuid({xuid})/achievements/{scid}/{achievementid}
assetID: 656a6d63-1a11-b0a5-63d2-2b010abd62e7
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementid.html
author: KevinAsgari
description: " /users/xuid({xuid})/achievements/{scid}/{achievementid}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9766222ea3a1c8671eadd42458b1c5aceaf0f587
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5983764"
---
# <a name="usersxuidxuidachievementsscidachievementid"></a>/users/xuid({xuid})/achievements/{scid}/{achievementid}
構成済みのメタデータとユーザー固有のデータを含む、実績の詳細を返します。 

> [!NOTE] 
> プラットフォームでのみサポートされます。 

 
これらの Uri のドメインが`achievements.xboxlive.com`します。
 
  * [URI パラメーター](#ID4E2)
 
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) がリソースにアクセスしているユーザーのします。 認証されたユーザーの XUID が一致する必要があります。| 
| scid| GUID| 対象の実績にアクセスしているサービス構成の一意の識別子。| 
| achievementid| 32 ビットの符号なし整数| アクセスされている実績を (指定された SCID) 内で一意の識別子です。| 
  
<a id="ID4EMC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})](uri-usersxuidachievementsscidachievementidget.md)

&nbsp;&nbsp;実績の詳細を取得します。
 
<a id="ID4EWC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EYC"></a>

 
##### <a name="parent"></a>Parent 

[実績 URI](atoc-reference-achievementsv2.md)

   