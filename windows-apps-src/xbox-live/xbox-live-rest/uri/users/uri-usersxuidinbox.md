---
title: /users/xuid({xuid})/inbox
assetID: 352740c6-42e2-0000-495d-bf384dc3e941
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinbox.html
description: " /users/xuid({xuid})/inbox"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8ded70b32dfd291d17a43a1741b26710f681a397
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8742541"
---
# <a name="usersxuidxuidinbox"></a>/users/xuid({xuid})/inbox
ユーザーへのアクセスの Xbox LIVE サービスの受信トレイのメッセージを提供します。 これらの Uri のドメインが`msg.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid | 64 ビットの符号なし整数 | Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。 | 
| メッセージ Id | 文字列 [50] | 取得または削除されるメッセージの ID です。 | 
  
<a id="ID4EDC"></a>

 
## <a name="valid-methods"></a>有効なメソッド 

[GET (/users/xuid({xuid})/inbox)](uri-usersxuidinboxget.md)

&nbsp;&nbsp;サービスから指定したメッセージの概要をユーザー数を取得します。 

[DELETE (/users/xuid({xuid})/inbox/{messageId})](uri-usersxuidinboxmessageiddelete.md)

&nbsp;&nbsp;ユーザーの受信トレイでユーザーのメッセージを削除します。

[GET (/users/xuid({xuid})/inbox/{messageId})](uri-usersxuidinboxmessageidget.md)

&nbsp;&nbsp;サービスの読み取りとしてマークすること、特定のユーザーのメッセージの詳細なメッセージ テキストを取得します。 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a>Parent  

[ユーザー URI](atoc-reference-users.md)

   