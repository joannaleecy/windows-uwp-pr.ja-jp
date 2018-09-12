---
title: ユーザー/xuid ({xuid})/achievements/{scid}/{achievementid}
assetID: 656a6d63-1a11-b0a5-63d2-2b010abd62e7
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementid.html
author: KevinAsgari
description: " ユーザー/xuid ({xuid})/achievements/{scid}/{achievementid}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f58b4b5f8cf135aaaad5e23095c4c00278dcec83
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881667"
---
# <a name="usersxuidxuidachievementsscidachievementid"></a>ユーザー/xuid ({xuid})/achievements/{scid}/{achievementid}
ユーザーに固有のデータ、設定されたメタデータを含む、実績の詳細を返します。 

> [!NOTE] 
> プラットフォームののみサポートされます。 

 
これらの Uri のドメインが`achievements.xboxlive.com`します。
 
  * [URI パラメーター](#ID4E2)
 
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) がリソースにアクセスしているユーザーのです。 認証されたユーザーの XUID に一致する必要があります。| 
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

[実績 Uri](atoc-reference-achievementsv2.md)

   