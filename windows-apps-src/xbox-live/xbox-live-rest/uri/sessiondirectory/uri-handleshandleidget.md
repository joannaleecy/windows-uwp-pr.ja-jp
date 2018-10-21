---
title: GET (/handles/{handle-id})
assetID: c95b5ab5-d56a-f70d-20d8-afb48d122ccd
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidget.html
author: KevinAsgari
description: " GET (/handles/{handle-id})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0f048d13c981bf07a124bd9637a36338b9dd3339
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5158434"
---
# <a name="get-handleshandle-id"></a>GET (/handles/{handle-id})
ハンドル ID で指定されたハンドルを取得します。

> [!IMPORTANT]
> このメソッドは、2015年マルチプレイヤーで使用し、および後でそのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EDB)
  * [HTTP ステータス コード](#ID4EOB)
  * [要求本文](#ID4EUB)
  * [応答本文](#ID4E5B)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、指定したハンドル、セッションでは、ユーザーの現在のアクティビティを取得します。 すべての属性を使用して、セッション オブジェクトを返します。 このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**でラップすることができます。

このメソッドの呼び出し元では、プレイヤーの**MultiplayerActivityDetails**オブジェクトからハンドル ID を取得します。 または、呼び出し元は、ユーザーがゲームへの招待を受け入れた後、プロトコルのアクティブ化から ID を取得します。

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| ハンドル id を使用| GUID| セッションのハンドルを一意の ID。|

<a id="ID4EOB"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される、HTTP ステータス コードを返します。  
<a id="ID4EUB"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E5B"></a>


## <a name="response-body"></a>応答本文
[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)の応答構造を参照してください。  
<a id="ID4EKC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EMC"></a>


##### <a name="parent"></a>Parent

[/handles/{handleId}](uri-handleshandleid.md)
