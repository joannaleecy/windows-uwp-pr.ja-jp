---
title: GET (/handles/{handle-id})
assetID: c95b5ab5-d56a-f70d-20d8-afb48d122ccd
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidget.html
description: " GET (/handles/{handle-id})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 501d36f4d1ac079af15d6bb7f35a90d5328fc8db
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598467"
---
# <a name="get-handleshandle-id"></a>GET (/handles/{handle-id})
ハンドルの ID で指定されたハンドルを取得します。

> [!IMPORTANT]
> このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EDB)
  * [HTTP 状態コード](#ID4EOB)
  * [要求本文](#ID4EUB)
  * [応答本文](#ID4E5B)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドは、指定したハンドルのため、セッションのユーザーの現在のアクティビティを取得します。 すべての属性を持つ、セッション オブジェクトを返します。 このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**します。

このメソッドの呼び出し元は、プレイヤーからハンドル ID を取得します。 **MultiplayerActivityDetails**オブジェクト。 または、呼び出し元は、ユーザーがゲームへの招待を承諾した後、プロトコルのアクティブ化から ID を取得します。

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| handleId| GUID| セッションのハンドルの一意の ID。|

<a id="ID4EOB"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EUB"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E5B"></a>


## <a name="response-body"></a>応答本文
応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。  
<a id="ID4EKC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EMC"></a>


##### <a name="parent"></a>Parent

[/handles/{handleId}](uri-handleshandleid.md)
