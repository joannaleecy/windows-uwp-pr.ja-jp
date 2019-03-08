---
title: DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)
assetID: aa5de623-7787-a47c-b7e4-305693b9fe35
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.html
description: " DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3de35398f4685a0b0cfda1a251c65ed6a74956d7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57637197"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a>DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)
セッションからメンバーを削除します。

> [!IMPORTANT]
> この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4E3)
  * [HTTP 状態コード](#ID4EHB)
  * [要求本文](#ID4ENB)
  * [応答本文](#ID4EYB)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈
すべてのセッションのメンバー リソース操作には、Xbox のユーザー ID (XUID) 承認が必要です。  
<a id="ID4E3"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成の識別子 (SCID) です。 パート 1 のセッション識別子。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 パート 2 のセッション識別子。|
| セッション名| GUID| セッションの一意の ID。 パート 3 のセッション識別子。|

<a id="ID4EHB"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4ENB"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EYB"></a>


## <a name="response-body"></a>応答本文
応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。  
<a id="ID4EBC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EDC"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)
