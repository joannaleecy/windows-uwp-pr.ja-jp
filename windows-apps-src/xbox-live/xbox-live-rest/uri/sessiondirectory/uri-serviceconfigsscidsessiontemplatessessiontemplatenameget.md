---
title: GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName})
assetID: 81139619-dc27-1601-30ba-08f6c45aaaca
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenameget.html
description: " GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e70c2412728eafe76e520e871fbe106c4b1a8ea3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57590747"
---
# <a name="get-serviceconfigsscidsessiontemplatessessiontemplatename"></a>GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName})
セッションのテンプレート名のセットを取得します。

> [!IMPORTANT]
> この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [URI パラメーター](#ID4ET)
  * [HTTP 状態コード](#ID4E5)
  * [要求本文](#ID4EFB)
  * [応答本文](#ID4EQB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成の識別子 (SCID)。 セッションの第 1 部 id。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 セッションの第 2 部 id。 |

<a id="ID4E5"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EFB"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EQB"></a>


## <a name="response-body"></a>応答本文


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


<a id="ID4EZB"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E2B"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}](uri-serviceconfigsscidsessiontemplatessessiontemplatename.md)
