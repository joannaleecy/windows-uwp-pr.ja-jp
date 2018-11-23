---
title: /users/xuid({xuid})/outbox
assetID: 0b66b885-15ff-be55-f8be-e6e9d85d087e
permalink: en-us/docs/xboxlive/rest/uri-usersxuidoutbox.html
author: KevinAsgari
description: " /users/xuid({xuid})/outbox"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a10fbb4b2008a3c953d101111d064c6f06491e10
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7566604"
---
# <a name="usersxuidxuidoutbox"></a>/users/xuid({xuid})/outbox
ユーザーに送信専用アクセスが許可のメッセージは、Xbox LIVE サービスのトレイします。 これらの Uri のドメインが`msg.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid | 64 ビットの符号なし整数 | Xbox ユーザー ID (XUID) 要求を行っているプレイヤーのします。 | 
  
<a id="ID4EXB"></a>

 
## <a name="valid-methods"></a>有効なメソッド 

[POST (/users/xuid({xuid})/outbox)](uri-usersxuidoutboxpost.md)

&nbsp;&nbsp;受信者の一覧を指定されたメッセージを送信します。 
 
<a id="ID4EFC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a>Parent  

[ユーザー URI](atoc-reference-users.md)

   