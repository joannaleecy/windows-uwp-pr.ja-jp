---
title: /users/xuid({xuid})/devices/current/titles/current
assetID: f149c68b-9874-e348-4e1d-6acf5d305c49
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrent.html
author: KevinAsgari
description: " /users/xuid({xuid})/devices/current/titles/current"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5c3573a4df36db20b5e318390507ac448aa0141a
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5746187"
---
# <a name="usersxuidxuiddevicescurrenttitlescurrent"></a>/users/xuid({xuid})/devices/current/titles/current
タイトルまたはタイトルのユーザーの有無にアクセスします。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) 対象ユーザーのします。| 
  
<a id="ID4EUB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[DELETE (/users/xuid({xuid})/devices/current/titles/current)](uri-usersxuiddevicescurrenttitlescurrentdelete.md)

&nbsp;&nbsp;[PresenceRecord](../../json/json-presencerecord.md)有効期限が切れるのを待っているではなく、終了のタイトルのプレゼンスを削除します。

[POST (/users/xuid({xuid})/devices/current/titles/current)](uri-usersxuiddevicescurrenttitlescurrentpost.md)

&nbsp;&nbsp;ユーザーのプレゼンスでは、タイトルを更新します。
 
<a id="ID4EBC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EDC"></a>

 
##### <a name="parent"></a>Parent 

[プレゼンス URI](atoc-reference-presence.md)

   