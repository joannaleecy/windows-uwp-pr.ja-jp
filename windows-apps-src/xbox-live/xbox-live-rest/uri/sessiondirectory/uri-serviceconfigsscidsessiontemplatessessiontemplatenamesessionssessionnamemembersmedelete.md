---
title: 削除 (/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/メンバー/me)
assetID: aa5de623-7787-a47c-b7e4-305693b9fe35
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.html
author: KevinAsgari
description: " 削除 (/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/メンバー/me)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 273819165e5dcf6b6398cd5b62e99be358e5ae9b
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881580"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a>削除 (/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/メンバー/me)
メンバーをセッションから削除します。

> [!IMPORTANT]
> この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4E3)
  * [HTTP ステータス コード](#ID4EHB)
  * [要求本文](#ID4ENB)
  * [応答本文](#ID4EYB)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈
すべてのセッション メンバー リソースの操作には、Xbox ユーザー ID (XUID) 承認が必要です。  
<a id="ID4E3"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成 id (SCID)。 セッション識別子のパート 1 です。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 セッション識別子のパート 2 です。|
| セッション名| GUID| セッションの一意の ID。 セッション識別子のパート 3 です。|

<a id="ID4EHB"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される、HTTP ステータス コードを返します。  
<a id="ID4ENB"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EYB"></a>


## <a name="response-body"></a>応答本文
[MultiplayerSession (](../../json/json-multiplayersession.md)json) 応答構造を参照してください。  
<a id="ID4EBC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EDC"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/メンバー/me](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)
