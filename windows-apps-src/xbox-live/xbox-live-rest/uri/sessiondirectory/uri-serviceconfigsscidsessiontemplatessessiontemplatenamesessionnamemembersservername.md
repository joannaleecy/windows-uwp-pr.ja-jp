---
title: /serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/servers/{サーバー名}
assetID: aed0764f-4e3d-e0b3-1ea0-543c32f3f822
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.html
author: KevinAsgari
description: " /serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/servers/{サーバー名}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b451d5aca9e855e204cb1178bf8ae30fb33ed015
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881740"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a>/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/servers/{サーバー名}
セッションの指定されたサーバーを削除する削除操作をサポートしています。
<a id="ID4EO"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| scid| GUID| サービス構成 id (SCID)。 セッション識別子のパート 1 です。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 セッション識別子のパート 2 です。|
| セッション名| GUID| セッションの一意の ID。 セッション識別子のパート 3 です。| 

<a id="ID4E3B"></a>


## <a name="valid-methods"></a>有効なメソッド

[(/Serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/servers/{サーバー名}) を削除します。](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.md)

&nbsp;&nbsp;指定されたサーバーは、セッションから削除します。

<a id="ID4EGC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EIC"></a>


##### <a name="parent"></a>Parent

[セッション ディレクトリ Uri](atoc-reference-sessiondirectory.md)
