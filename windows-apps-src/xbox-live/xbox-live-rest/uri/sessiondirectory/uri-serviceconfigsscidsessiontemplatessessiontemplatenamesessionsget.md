---
title: GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)
assetID: 9daac964-0b25-3430-fcfd-0f8658aceee1
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionsget.html
description: " GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1020c9d9c378a95070a7b0bf3faeb9d2c6751d51
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627477"
---
# <a name="get-serviceconfigsscidsessiontemplatessessiontemplatenamesessions"></a>GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)
セッション テンプレートのドキュメントを取得します。

> [!IMPORTANT]
> この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EKB)
  * [HTTP 状態コード](#ID4EXB)
  * [要求本文](#ID4EAC)
  * [応答本文](#ID4EKC)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、指定されたフィルターのセッションのテンプレート情報を取得します。 このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsAsync**します。


> [!NOTE] 
> このメソッドを呼び出して 2015年マルチ プレーヤーの<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync</b>します。  



> [!NOTE] 
> このメソッドを呼び出すたびには、キーワード、Xbox ユーザー ID フィルター、またはその両方を含める必要があります。 呼び出し元がの適切なアクセス許可を持たない場合、<i>プライベート</i>と<i>予約</i>パラメーター、メソッドを返すエラー コード 403 Forbidden、実際には、このようなセッションが存在するかどうか。  


<a id="ID4EKB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- | --- |
| scid| GUID| サービス構成の識別子 (SCID) です。 セッションの第 1 部 id。|
| キーワード| string| 結果文字列で識別されるだけでセッションをフィルター処理するために使用するキーワードです。|
| xuid| GUID| セッションを取得する対象のユーザーの Xbox ユーザー Id。 ユーザーは、セッションでアクティブである必要があります。 |
| 予約| string| セッションの一覧が、ユーザー同意していないものも含まれますかどうかを示す値。 このパラメーターを設定することができますのみ true に設定します。 この設定は、呼び出し元に、セッションにサーバー レベルのアクセスを要求または呼び出し元の XUID は Xbox のユーザー ID のフィルターに一致する要求。 |
| 非アクティブ| string| セッションの一覧が、ユーザーが承諾しましたが、積極的に再生しないものを含むかどうかを示す値。 このパラメーターを設定することができますのみ true に設定します。 |
| プライベート| string| プライベート セッション、セッションの一覧を示す値。 このパラメーターを設定することができますのみ true に設定します。 サーバーからサーバーを照会するときに、または自身のセッションのクエリを実行する場合にのみ有効です。 Xbox のユーザー ID のフィルターに一致する要求の呼び出し元の XUID または、呼び出し元に、セッションにサーバー レベルのアクセスを必要このパラメーターを true に設定します。 |
| visibility| string| 結果をフィルター処理で使用される表示状態を示す列挙値。 現在このパラメーターのみ設定できます開くを開いているセッションを含める。 参照してください<b>MultiplayerSessionVisibility</b>します。 |
| version| string| 正の整数バージョンの主要なセッションまたはセッションの下位に含めます。 値は 100 剰余の要求のコントラクトのバージョン以下である必要があります。 |
| Take| string| 正の整数のセッションの最大数を取得します。|

<a id="ID4EXB"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EAC"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EKC"></a>


## <a name="response-body"></a>応答本文

このメソッドからの戻り値は、いくつかのセッションに含まれるデータをインラインでのセッションの参照の JSON 配列です。


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


<a id="ID4EUC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EWC"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.md)
