---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}
assetID: 55ce6459-1714-49bc-6231-b547ddf04143
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7bd61e7a3092fb094e7c4dc03c9644299bd5a8f1
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5555924"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a>/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}
PUT と取得の操作を作成してセッションを取得をサポートしています。
<a id="ID4EO"></a>


## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| scid| GUID| サービス構成 id (SCID)。 セッション識別子のパート 1 です。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 セッション識別子のパート 2 です。|
| セッション名| GUID| セッションの一意の ID。 セッション識別子のパート 3 です。| 

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

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)
