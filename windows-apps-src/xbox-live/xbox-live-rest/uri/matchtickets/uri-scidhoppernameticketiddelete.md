---
title: DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})
assetID: d9ff3f21-aa70-af41-afa1-9a9244fcdb95
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketiddelete.html
author: KevinAsgari
description: " DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3780fb9f69a97d4e2522aa17a806b1fb4917a9f7
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5433739"
---
# <a name="delete-serviceconfigsscidhoppershoppernameticketsticketid"></a>DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})

マッチ チケットを削除します。

> [!IMPORTANT]
> このメソッドはコントラクト 103 以降で使用するものでは、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4E2)
  * [Authorization](#ID4EGB)
  * [HTTP ステータス コード](#ID4EOC)
  * [要求本文](#ID4EXC)
  * [応答本文](#ID4ECD)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、サービス構成 ID (SCID) レベルで名前付きのホッパーから、指定されたチケット ID を削除します。 このメソッドは、 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.DeleteMatchTicketAsync**でラップすることができます。  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成 id (SCID)。|
| name| string| ホッパーの名前。|
| ticketId| GUID| チケットの id。|

<a id="ID4EGB"></a>


## <a name="authorization"></a>Authorization

| 型| 必須かどうか| 説明| 不足している場合、応答|
| --- | --- | --- | --- | --- | --- | --- | --- |
| XUID (ユーザーの ID)| 必須| 要求を行っているユーザーは、チケットによって参照される、チケット セッションのメンバーである必要があります。| 403|
| 特権とデバイスの種類| 必須| ユーザーの deviceType がコンソールに設定されている場合、マッチメイ キング サービスへの呼び出しは、要求のマルチプレイヤー権限を持つユーザーのみが許可されています。| 403|

<a id="ID4EOC"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスは、MPSD に適用される、HTTP ステータス コードを返します。  
<a id="ID4EXC"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4ECD"></a>


## <a name="response-body"></a>応答本文

応答の本文には、オブジェクトは送信されません。

<a id="ID4EPD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ERD"></a>


##### <a name="parent"></a>Parent  

[/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}](uri-scidhoppernameticketid.md)
