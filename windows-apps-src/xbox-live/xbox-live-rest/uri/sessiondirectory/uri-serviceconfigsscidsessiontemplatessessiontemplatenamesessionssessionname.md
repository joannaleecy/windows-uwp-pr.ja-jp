---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}
assetID: 55ce6459-1714-49bc-6231-b547ddf04143
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.html
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: da8d61634d0a849d51e2ab6ff143469ec05cc75c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57657477"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a>/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}
作成およびセッションを取得する PUT および GET 操作をサポートしています。
<a id="ID4EO"></a>


## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| scid| GUID| サービス構成の識別子 (SCID) です。 パート 1 のセッション識別子。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 パート 2 のセッション識別子。|
| セッション名| GUID| セッションの一意の ID。 パート 3 のセッション識別子。| 

<a id="ID4EBC"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.md)

&nbsp;&nbsp;セッション オブジェクトを取得します。

[PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.md)

&nbsp;&nbsp;作成、更新、またはセッションに参加します。

<a id="ID4EOC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EQC"></a>


##### <a name="parent"></a>Parent

[セッション ディレクトリの Uri](atoc-reference-sessiondirectory.md)
