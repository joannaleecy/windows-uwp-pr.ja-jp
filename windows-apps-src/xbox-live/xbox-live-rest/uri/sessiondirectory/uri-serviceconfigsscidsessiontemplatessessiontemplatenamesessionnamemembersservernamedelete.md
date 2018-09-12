---
title: (/Serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/servers/{サーバー名}) を削除します。
assetID: 39c921d1-a166-74b9-fcbc-ea3c0c58cc40
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.html
author: KevinAsgari
description: " (/Serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/servers/{サーバー名}) を削除します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 12feca7761faa441023f2f242903d4fec2f0284d
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881482"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a>(/Serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/servers/{サーバー名}) を削除します。
指定されたサーバーは、セッションから削除します。

> [!IMPORTANT]
> この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。

  * [URI パラメーター](#ID4ET)
  * [HTTP ステータス コード](#ID4E5)
  * [要求本文](#ID4EFB)
  * [応答本文](#ID4EOB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成 id (SCID)。 セッション識別子のパート 1 です。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 セッション識別子のパート 2 です。|
| セッション名| GUID| セッションの一意の ID。 セッション識別子のパート 3 です。|

<a id="ID4E5"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される、HTTP ステータス コードを返します。  
<a id="ID4EFB"></a>


## <a name="request-body"></a>要求本文
[MultiplayerSessionRequest (](../../json/json-multiplayersessionrequest.md)json) の要求の構造を参照してください。  
<a id="ID4EOB"></a>


## <a name="response-body"></a>応答本文
[MultiplayerSession (](../../json/json-multiplayersession.md)json) 応答構造を参照してください。  
<a id="ID4E1B"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E3B"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/servers/{サーバー名}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.md)
