---
title: DELETE (/handles/{handleId})
assetID: 71cceff4-3a74-dc05-12db-cfe3f20a8aea
permalink: en-us/docs/xboxlive/rest/uri-handleshandleiddelete.html
description: " DELETE (/handles/{handleId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 354f3563c48139edc5d5cc041e8304998af55620
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613407"
---
# <a name="delete-handleshandleid"></a>DELETE (/handles/{handleId})
ハンドルの ID で指定されたハンドルを削除します。

> [!IMPORTANT]
> このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EAB)
  * [HTTP 状態コード](#ID4ELB)
  * [要求本文](#ID4ESB)
  * [応答本文](#ID4E4B)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈
この HTTP/REST メソッドは、指定された id ハンドルを削除し、セッションのユーザーの現在のアクティビティをクリアします。 このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.ClearActivityAsync**します。  
<a id="ID4EAB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| handleId| GUID| セッションのハンドルの一意の ID。|

<a id="ID4ELB"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4ESB"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E4B"></a>


## <a name="response-body"></a>応答本文

応答の本文では、オブジェクトは送信されません。

<a id="ID4EIC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EKC"></a>


##### <a name="parent"></a>Parent

[/handles/{handleId}](uri-handleshandleid.md)
