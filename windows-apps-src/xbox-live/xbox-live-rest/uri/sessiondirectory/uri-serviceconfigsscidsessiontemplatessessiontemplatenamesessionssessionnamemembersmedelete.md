---
title: DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)
assetID: aa5de623-7787-a47c-b7e4-305693b9fe35
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.html
author: KevinAsgari
description: " DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 273819165e5dcf6b6398cd5b62e99be358e5ae9b
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4538504"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a>DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)
メンバーをセッションから削除します。

> [!IMPORTANT]
> この URI メソッドには、X Xbl コントラクト バージョンのヘッダー要素が必要があります: 104/105 または後ですべての要求します。

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
サービスは、MPSD に適用される HTTP ステータス コードを返します。  
<a id="ID4ENB"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EYB"></a>


## <a name="response-body"></a>応答本文
[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)で応答構造を参照してください。  
<a id="ID4EBC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EDC"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)
