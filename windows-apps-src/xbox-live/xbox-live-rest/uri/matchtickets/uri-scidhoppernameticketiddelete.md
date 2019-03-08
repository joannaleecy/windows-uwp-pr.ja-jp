---
title: DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})
assetID: d9ff3f21-aa70-af41-afa1-9a9244fcdb95
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketiddelete.html
description: " DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fdd28cb94b31102d9af98aa95afde45424dadce9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589667"
---
# <a name="delete-serviceconfigsscidhoppershoppernameticketsticketid"></a>DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})

一致のチケットを削除します。

> [!IMPORTANT]
> このメソッドは、コントラクト 103 以降で使用するためのものがし、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4E2)
  * [承認](#ID4EGB)
  * [HTTP 状態コード](#ID4EOC)
  * [要求本文](#ID4EXC)
  * [応答本文](#ID4ECD)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、サービス構成の ID (SCID) レベルで名前付き hopper から指定したチケット ID を削除します。 このメソッドによってラップできる**Microsoft.Xbox.Services.Matchmaking.MatchmakingService.DeleteMatchTicketAsync**します。  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成識別子 (SCID)。|
| name| string| Hopper の名前。|
| TicketId| GUID| チケット id。|

<a id="ID4EGB"></a>


## <a name="authorization"></a>Authorization

| 種類| 必須| 説明| 不足している場合の応答|
| --- | --- | --- | --- | --- | --- | --- | --- |
| XUID (ユーザー ID)| ○| 要求を行うユーザーは、チケットによって参照されるチケット セッションのメンバーである必要があります。| 403|
| 特権とデバイスの種類| ○| ユーザーの deviceType は、コンソールに設定されている場合は、それぞれのクレームでマルチ プレーヤーの特権を持つユーザーのみがマッチメイ キング サービスを呼び出すことが許可されます。| 403|

<a id="ID4EOC"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EXC"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4ECD"></a>


## <a name="response-body"></a>応答本文

応答の本文では、オブジェクトは送信されません。

<a id="ID4EPD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ERD"></a>


##### <a name="parent"></a>Parent  

[/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}](uri-scidhoppernameticketid.md)
