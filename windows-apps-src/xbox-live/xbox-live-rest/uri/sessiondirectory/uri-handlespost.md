---
title: POST (/handles)
assetID: 21f3e289-0b0e-2731-befb-bd4c0d71973e
permalink: en-us/docs/xboxlive/rest/uri-handlespost.html
author: KevinAsgari
description: " POST (/handles)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: aa749dac2638dbdb1f474300e9799e3e67827079
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7147386"
---
# <a name="post-handles"></a>POST (/handles)
ユーザーの現在のアクティビティのマルチプレイヤー セッションを設定し、必要な場合は、セッション メンバーを招待します。

> [!IMPORTANT]
> このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EHB)
  * [HTTP ステータス コード](#ID4EPB)
  * [要求本文](#ID4EVB)
  * [応答本文](#ID4EJC)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

現在のアクティビティ セッションを設定するのには、この HTTP/REST メソッドを使用できます。 この場合、メソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.SetActivityAsync**でラップすることができます。 要求本文には、JSON ファイルで、「アクティビティ」の種類] フィールドに**sessionRef**オブジェクトを使用して、セッションの参照を定義する必要があります。 応答本文は取得されません。 セッション参照で指定された項目の定義、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionReference**を参照してください。

この POST メソッドは、セッションへのハンドルによって指定されたユーザーを招待するも使用できます。 この場合、メソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.SendInvitesAsync**でラップすることができます。 このような POST メソッドの使用には、セッションの参照を定義する、要求本文が必要ですが、型フィールド「招待」に設定します。 応答本文では、招待ハンドルです。

<a id="ID4EHB"></a>


## <a name="uri-parameters"></a>URI パラメーター

なし

<a id="ID4EPB"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される HTTP ステータス コードを返します。  
<a id="ID4EVB"></a>


## <a name="request-body"></a>要求本文

<a id="ID4E1B"></a>


### <a name="request-body-for-setting-activity"></a>要求本文のアクティビティの設定


```cpp
{
  "version": 1,
  "type": "activity",
  "sessionRef": {
    "scid": "bd6c41c3-01c3-468a-a3b5-3e0fe8133862",
    "templateName": "deathmatch",
    // The session name is optional in a POST; if not specified, MPSD fills in a GUID.//
    "name": "session-49"
  },
}

```


<a id="ID4EBC"></a>


### <a name="request-body-for-sending-invites"></a>招待を送信するための要求本文


```cpp
{
  // Common handle fields
  "id: "47ca0049-a5ba-4bc1-aa22-fcf834ce4c13",
  "version": 1,
  "type": "invite",
  "sessionRef": {
    "scid": "bd6c41c3-01c3-468a-a3b5-3e0fe8133862",
    "templateName": "deathmatch",
    "name": "session-49"
   },
   "inviteAttributes": {
     "titleId" : {titleId}, // The title being invited to, in decimal uint32. This value is used to find the title name and/or image.
     "context" : {context}, // The title defined context token. Must be 256 characters or less when URI-encoded.
     "contextString" : {contextstring}, // The string name of a custom invite string to display in the invite notification.
     "senderString" : {sender} // The string name of the sender when the sender is a service.
   },
   "invitedXuid": "3210",
}

```


<a id="ID4EJC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EOC"></a>


### <a name="response-body-for-setting-activity"></a>アクティビティを設定するための応答本文
なし。  
<a id="ID4ESC"></a>


### <a name="response-body-for-sending-invites"></a>招待を送信するための応答本文
招待ハンドル。   
<a id="ID4EXC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EZC"></a>


##### <a name="parent"></a>Parent

[/handles](uri-handles.md)
