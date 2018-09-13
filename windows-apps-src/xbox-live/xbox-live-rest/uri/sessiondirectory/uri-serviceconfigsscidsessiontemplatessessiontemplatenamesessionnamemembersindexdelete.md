---
title: (/Serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/members/{インデックス}) を削除します。
assetID: 00aa2f3d-69a6-6d68-e99b-aad4b102aba3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindexdelete.html
author: KevinAsgari
description: " (/Serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/members/{インデックス}) を削除します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 03adb20f796e7bff59214999febad38434a2a287
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3958459"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersindex"></a>(/Serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/members/{インデックス}) を削除します。
指定したメンバーをセッションから削除します。

> [!IMPORTANT]
> この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要があります: 104/105 または後ですべての要求します。

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
サービスは、MPSD に適用される HTTP ステータス コードを返します。  
<a id="ID4EFB"></a>


## <a name="request-body"></a>要求本文
[MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md)の要求の構造を参照してください。  
<a id="ID4EOB"></a>


## <a name="response-body"></a>応答本文
[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)の応答構造を参照してください。  
<a id="ID4EYB"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E1B"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/members/{インデックス}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.md)
