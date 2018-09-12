---
title: (/Serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}) を取得します。
assetID: 6a4c4a13-c968-3271-cbc3-b742a8de98b3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.html
author: KevinAsgari
description: " (/Serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}) を取得します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f1b1c9d15cc1bc06c14a44d395b478cdc536fd74
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3936176"
---
# <a name="get-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a>(/Serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}) を取得します。
セッション オブジェクトを取得します。

> [!IMPORTANT]
> この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EMB)
  * [HTTP ステータス コード](#ID4EZB)
  * [要求本文](#ID4E6B)
  * [応答本文](#ID4EKC)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドは、指定した名前のセッション ドキュメント欄が「し、、セッションを取得します。 成功した場合、そのすべての属性を使用して、セッション オブジェクトが、サーバーから取得を返します。 このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionAsync**でラップすることができます。 直接 GET メソッドのパラメーターでは指定されている**MultiplayerSessionReference**オブジェクトの場合、セッションでは、 **GetCurrentSessionAsync**の*sessionReference*パラメーターで渡されるは似ています。

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
サービスは、MPSD に適用される、HTTP ステータス コードを返します。  
<a id="ID4E6B"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EKC"></a>


## <a name="response-body"></a>応答本文
[MultiplayerSession (](../../json/json-multiplayersession.md)json) 応答構造を参照してください。  
<a id="ID4ETC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EVC"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)
