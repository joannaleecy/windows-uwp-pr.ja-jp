---
title: GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})
assetID: 6a4c4a13-c968-3271-cbc3-b742a8de98b3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.html
author: KevinAsgari
description: " GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f1b1c9d15cc1bc06c14a44d395b478cdc536fd74
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4308345"
---
# <a name="get-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a>GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})
セッション オブジェクトを取得します。

> [!IMPORTANT]
> この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EMB)
  * [HTTP ステータス コード](#ID4EZB)
  * [要求本文](#ID4E6B)
  * [応答本文](#ID4EKC)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドは、指定した名前のセッション ドキュメントを読み込んで、セッションを取得します。 成功した場合、サーバーから取得したすべての属性と、セッション オブジェクトを返します。 このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionAsync**でラップすることができます。 直接 GET メソッドのパラメーターでは指定されている**MultiplayerSessionReference**オブジェクトで、セッションの**GetCurrentSessionAsync**の*sessionReference*パラメーターで渡されたは似ています。

GET メソッドのワイヤ形式は、次に示します。

```cpp
GET /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
      Content-Type: application/json

```



<a id="ID4EMB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成 id (SCID)。 セッション識別子のパート 1 です。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 セッション識別子のパート 2 です。|
| セッション名| GUID| セッションの一意の ID。 セッション識別子のパート 3 です。|

<a id="ID4EZB"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される HTTP ステータス コードを返します。  
<a id="ID4E6B"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EKC"></a>


## <a name="response-body"></a>応答本文
[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)の応答構造を参照してください。  
<a id="ID4ETC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EVC"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)
