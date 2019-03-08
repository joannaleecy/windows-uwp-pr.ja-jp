---
title: DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})
assetID: 39c921d1-a166-74b9-fcbc-ea3c0c58cc40
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.html
description: " DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 65da52284d49d4d9384685d073f13bd93b10a30b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658317"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a>DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})
セッションから、指定したサーバーを削除します。

> [!IMPORTANT]
> この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [URI パラメーター](#ID4ET)
  * [HTTP 状態コード](#ID4E5)
  * [要求本文](#ID4EFB)
  * [応答本文](#ID4EOB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成の識別子 (SCID) です。 パート 1 のセッション識別子。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 パート 2 のセッション識別子。|
| セッション名| GUID| セッションの一意の ID。 パート 3 のセッション識別子。|

<a id="ID4E5"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EFB"></a>


## <a name="request-body"></a>要求本文
要求の構造を参照してください。 [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md)します。  
<a id="ID4EOB"></a>


## <a name="response-body"></a>応答本文
応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。  
<a id="ID4E1B"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E3B"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.md)
