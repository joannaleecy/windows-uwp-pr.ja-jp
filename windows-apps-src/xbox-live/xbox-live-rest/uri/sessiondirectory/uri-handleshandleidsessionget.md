---
title: GET (/handles/{handleId}/session)
assetID: 1f22954c-e77b-69c2-63f4-741fbd965f8f
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsessionget.html
description: " GET (/handles/{handleId}/session)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 41911dc53b316f4f323b9859d9101581ec88e497
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593897"
---
# <a name="get-handleshandleidsession"></a>GET (/handles/{handleId}/session)
指定したハンドル識別子のセッション オブジェクトを取得します。

> [!IMPORTANT]
> このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EDB)
  * [HTTP 状態コード](#ID4EOB)
  * [要求本文](#ID4EVB)
  * [応答本文](#ID4E6B)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドは、セッション (ハンドル) に指定されたサービス側のポインターを使用して、サーバーからセッション オブジェクトを取得します。 すべての属性を持つ、セッション オブジェクトを返します。 このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**します。

このメソッドの呼び出し元は、プレイヤーからハンドル ID を取得します。 **MultiplayerActivityDetails**オブジェクト。 または、呼び出し元は、ユーザーがゲームへの招待を承諾した後、プロトコルのアクティブ化から ID を取得します。

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| handleId| GUID| セッションのハンドルの一意の ID。|

<a id="ID4EOB"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EVB"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E6B"></a>


## <a name="response-body"></a>応答本文
応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。  
<a id="ID4EIC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EKC"></a>


##### <a name="parent"></a>Parent

[/handles/{handleId}/session](uri-handleshandleidsession.md)
