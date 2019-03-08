---
title: PUT (/handles/{handle-id}/session)
assetID: d8a3d473-1192-ec0c-3935-c301f4f61e03
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsessionput.html
description: " PUT (/handles/{handle-id}/session)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3a1872857d8b8e692f67e3c7b2a067ae86663c00
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641607"
---
# <a name="put-handleshandle-idsession"></a>PUT (/handles/{handle-id}/session)
作成またはハンドルの逆参照でセッションを更新します。

> [!IMPORTANT]
> このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4ECB)
  * [HTTP 状態コード](#ID4ENB)
  * [要求本文](#ID4EUB)
  * [応答本文](#ID4E6B)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドが提供されているセッション ハンドル ID を使用して、マルチ プレーヤー サービスを新規または更新されたセッションを書き込みます 結果は、サーバーから返される、新しいまたは更新されたセッションを表すオブジェクトです。 このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionByHandleAsync**します。

このメソッドの呼び出し元は、プレイヤーからハンドル ID を取得します。 **MultiplayerActivityDetails**オブジェクト。 または、呼び出し元は、ユーザーがゲームへの招待を承諾した後、プロトコルのアクティブ化から ID を取得します。

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| handleId| GUID| セッションのハンドルの一意の ID。|

<a id="ID4ENB"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EUB"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E6B"></a>


## <a name="response-body"></a>応答本文

応答の本文では、オブジェクトは送信されません。

<a id="ID4EKC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EMC"></a>


##### <a name="parent"></a>Parent

[/handles/{handleId}/session](uri-handleshandleidsession.md)
