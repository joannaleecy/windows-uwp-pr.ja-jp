---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch
assetID: 4f8e1ece-2ba8-9ea4-e551-2a69c499d7b9
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigscidsessiontemplatessessiontemplatenamebatch.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c1f1add0104ad166620dbdff79936e6a99379df3
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5986237"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamebatch"></a>/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch
セッション テンプレート レベルでバッチ クエリを作成する POST 操作をサポートしています。

> [!IMPORTANT]
> このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成 id (SCID)。 セッション識別子のパート 1 です。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 セッション識別子のパート 2 です。|

<a id="ID4E2B"></a>


## <a name="valid-methods"></a>有効なメソッド

[POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)](uri-serviceconfigscidsessiontemplatessessiontemplatenamebatchpost.md)

&nbsp;&nbsp;複数の Xbox ユーザー Id には、バッチ クエリを作成します。

<a id="ID4EFC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EHC"></a>


##### <a name="parent"></a>Parent

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)
