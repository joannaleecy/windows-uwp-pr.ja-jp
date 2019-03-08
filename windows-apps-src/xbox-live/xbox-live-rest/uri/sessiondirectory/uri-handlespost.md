---
title: POST (/handles)
assetID: 21f3e289-0b0e-2731-befb-bd4c0d71973e
permalink: en-us/docs/xboxlive/rest/uri-handlespost.html
description: " POST (/handles)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ed3482b8e629749d294ed25944db16372cc7fee6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594747"
---
# <a name="post-handles"></a>POST (/handles)
ユーザーの現在のアクティビティのマルチ プレーヤーのセッションを設定し、必要な場合は、セッションのメンバーを招待します。

> [!IMPORTANT]
> このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EHB)
  * [HTTP 状態コード](#ID4EPB)
  * [要求本文](#ID4EVB)
  * [応答本文](#ID4EJC)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

現在のアクティビティのセッションを設定するのには、この HTTP/REST メソッドを使用できます。 メソッドをラップしてこの場合、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.SetActivityAsync**します。 要求本文は、セッションを定義する必要がありますを使用して、参照、 **sessionRef** 「アクティビティ」の種類 フィールドに、JSON ファイル内のオブジェクト。 応答本文は取得されません。 セッションの参照で指定された項目の定義は、次を参照してください。 **Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionReference**します。

この POST メソッドがセッションへのハンドルで指定されたユーザーを招待することもできます。 メソッドをラップしてこの場合、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.SendInvitesAsync**します。 この POST メソッドの使用には、セッションの参照を定義する、要求本文が必要ですが、型のフィールド「招待」に設定します。 応答本文はな招待ハンドルです。

<a id="ID4EHB"></a>


## <a name="uri-parameters"></a>URI パラメーター

なし

<a id="ID4EPB"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EVB"></a>


## <a name="request-body"></a>要求本文

<a id="ID4E1B"></a>


### <a name="request-body-for-setting-activity"></a>要求アクティビティを設定するための本文


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
招待のハンドル。   
<a id="ID4EXC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EZC"></a>


##### <a name="parent"></a>Parent

[/handles](uri-handles.md)
