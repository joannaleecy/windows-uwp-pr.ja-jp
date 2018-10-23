---
title: /users/xuid({xuid})/inbox
assetID: 352740c6-42e2-0000-495d-bf384dc3e941
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinbox.html
author: KevinAsgari
description: " /users/xuid({xuid})/inbox"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 944b2c9f0e5758444295ef9ec189d84728a3845d
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5396500"
---
# <a name="usersxuidxuidinbox"></a>/users/xuid({xuid})/inbox
ユーザーへのアクセスの Xbox LIVE サービスの受信トレイのメッセージを提供します。 これらの Uri のドメインが`msg.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid | 64 ビットの符号なし整数 | Xbox ユーザー ID (XUID) 要求を行っているプレイヤーのします。 | 
| メッセージ Id | 文字列 [50] | 取得または削除されるメッセージの ID です。 | 
  
<a id="ID4EDC"></a>

 
## <a name="valid-methods"></a>有効なメソッド 

[GET (/users/xuid({xuid})/inbox)](uri-usersxuidinboxget.md)

&nbsp;&nbsp;サービスから指定されたユーザー メッセージ概要数を取得します。 

[DELETE (/users/xuid({xuid})/inbox/{messageId})](uri-usersxuidinboxmessageiddelete.md)

&nbsp;&nbsp;ユーザーの受信トレイでユーザーのメッセージを削除します。

[GET (/users/xuid({xuid})/inbox/{messageId})](uri-usersxuidinboxmessageidget.md)

&nbsp;&nbsp;サービスのマーキング、特定のユーザー メッセージの詳細なメッセージ テキストを取得します。 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a>Parent  

[ユーザー URI](atoc-reference-users.md)

   