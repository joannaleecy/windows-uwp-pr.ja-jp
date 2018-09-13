---
title: /serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}
assetID: 55ce6459-1714-49bc-6231-b547ddf04143
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.html
author: KevinAsgari
description: " /serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 43054e909ce6e4a3d472a6a6480cd0812afa5ad4
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3964335"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a>/serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}
作成してセッションを取得する PUT と取得の操作をサポートしています。
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

[(/Serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}) を取得します。](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.md)

&nbsp;&nbsp;セッション オブジェクトを取得します。

[PUT (/serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション})](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.md)

&nbsp;&nbsp;作成、更新、またはセッションに参加します。

<a id="ID4EOC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EQC"></a>


##### <a name="parent"></a>Parent

[セッション ディレクトリ Uri](atoc-reference-sessiondirectory.md)
