---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}
assetID: aed0764f-4e3d-e0b3-1ea0-543c32f3f822
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1db216c7ad7c85d15ff5e9087d6fbb4e0cbe92f3
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5551739"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a>/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}
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

[DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.md)

&nbsp;&nbsp;指定されたサーバーは、セッションから削除します。

<a id="ID4EGC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EIC"></a>


##### <a name="parent"></a>Parent

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)
