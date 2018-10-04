---
title: GET (/serviceconfigs/{scid}/sessions)
assetID: adc65d0b-58dd-bfb9-54c8-9bc9d02e68ec
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessionsget.html
author: KevinAsgari
description: " GET (/serviceconfigs/{scid}/sessions)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7ada5040c97dcb283146cb528cf2107294b9b88b
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4314315"
---
# <a name="get-serviceconfigsscidsessions"></a>GET (/serviceconfigs/{scid}/sessions)
指定したセッション情報を取得します。

> [!IMPORTANT]
> このメソッドが X Xbl コントラクト バージョンのヘッダーの要素が必要になりました。 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EKB)
  * [HTTP ステータス コード](#ID4EXB)
  * [要求本文](#ID4EAC)
  * [応答本文](#ID4ELC)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドは、指定されたフィルターのセッション情報を取得します。 このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsAsync**でラップすることができます。


> [!NOTE] 
> 2015 マルチプレイヤーでは、このメソッドは<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync</b>によって呼び出されます。  



> [!NOTE] 
> このメソッドを呼び出すたびには、キーワード、Xbox ユーザー ID のフィルター、またはその両方を含める必要があります。 呼び出し元が、<i>プライベート</i>と<i>予約</i>のパラメーターの適切なアクセス許可を持たない場合、このメソッドは、そのようなセッションが実際に存在するかどうか 403 Forbidden のエラー コードを返します。  


<a id="ID4EKB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- | --- |
| scid| GUID| サービス構成 id (SCID)。 パート 1 セッションの id。|
| キーワード| string| キーワードで文字列を識別するだけでセッションに結果をフィルター処理するために使用します。|
| xuid| GUID| セッションを取得する対象のユーザーの Xbox ユーザー Id。 ユーザーは、セッション内でアクティブである必要があります。|
| 予約| string| 示す値をユーザーが持っていないセッションのリストが含まれている場合は受け入れ。 このパラメーターを設定することのみを true に設定します。 この設定は、呼び出し元が、セッションにサーバー レベルのアクセスを必要と、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。 |
| 非アクティブです| string| セッションの一覧を含むをユーザーが受け入れられますがアクティブにプレイしていないかどうかを示す値。 このパラメーターを設定することのみを true に設定します。|
| プライベート| string| プライベート セッション、セッションの一覧を示す値。 このパラメーターを設定することのみを true に設定します。 独自のセッションをクエリするときにのみ、またはサーバー間を照会すると、無効です。 このパラメーターを true に設定、呼び出し元が、セッションにサーバー レベルのアクセスを必要とまたは Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。 |
| visibility| string| 結果のフィルタ リングで使われる表示状態を示す列挙値。 現在このパラメーターのみに設定できます開くを開いているセッションを含めます。 <b>MultiplayerSessionVisibility</b>を参照してください。|
| version| string| 正の整数セッションのメジャー バージョンまたはセッションの低下を示すが含まれます。 値は 100 モジュロ要求のコントラクト バージョン以下である必要があります。|
| アプリでは| string| 正の整数セッションの最大数を示すを取得します。|

<a id="ID4EXB"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される HTTP ステータス コードを返します。  
<a id="ID4EAC"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4ELC"></a>


## <a name="response-body"></a>応答本文

このメソッドからの戻り値は、いくつかのセッション データが含まれているインラインでのセッション参照の JSON 配列です。


```cpp
{
    "results": [ {
            "xuid": "9876",    // If the session was found from a xuid, that xuid.
            "startTime": "2009-06-15T13:45:30.0900000Z",
            "sessionRef": {
                "scid": "foo",
                "templateName": "bar",
                "name": "session-seven"
            },
            "accepted": 4,    // Approximate number of non-reserved members.
            "status": "active",    // or "reserved" or "inactive". This is the state of the user in the session, not the session itself. Only present if the session was found using a xuid.
            "visibility": "open",    // or "private", "visible", or "full"
            "joinRestriction": "local",    // or "followed". Only present if 'visibility' is "open" or "full" and the session has a join restriction.
            "myTurn": true,    // Not present is the same as 'false'. Only present if the session was found using a xuid.
            "keywords": [ "one", "two" ]
        }
    ]
}

```


<a id="ID4EWC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EYC"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid}/sessions](uri-serviceconfigsscidsessions.md)
