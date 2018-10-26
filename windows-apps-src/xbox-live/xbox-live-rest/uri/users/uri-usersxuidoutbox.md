---
title: /users/xuid({xuid})/outbox
assetID: 0b66b885-15ff-be55-f8be-e6e9d85d087e
permalink: en-us/docs/xboxlive/rest/uri-usersxuidoutbox.html
author: KevinAsgari
description: " /users/xuid({xuid})/outbox"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 804abf3882763d7333772dfc671a82b550fa9302
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5543539"
---
# <a name="usersxuidxuidoutbox"></a>/users/xuid({xuid})/outbox
ユーザーに送信専用アクセスが許可のメッセージは、Xbox LIVE サービスに送信トレイします。 これらの Uri のドメインが`msg.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid | 64 ビットの符号なし整数 | Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。 | 
  
<a id="ID4EXB"></a>

 
## <a name="valid-methods"></a>有効なメソッド 

[POST (/users/xuid({xuid})/outbox)](uri-usersxuidoutboxpost.md)

&nbsp;&nbsp;受信者の一覧を指定されたメッセージを送信します。 
 
<a id="ID4EFC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a>Parent  

[ユーザー URI](atoc-reference-users.md)

   