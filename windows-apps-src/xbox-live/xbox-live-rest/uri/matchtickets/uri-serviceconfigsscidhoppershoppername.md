---
title: /serviceconfigs/{scid}/hoppers/{hoppername}
assetID: ba1e129d-b4c4-6535-46ce-fd184465c85f
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppername.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/hoppers/{hoppername}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5e02a4ea5ba9c21337032daad44579f6001360cd
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4615982"
---
# <a name="serviceconfigsscidhoppershoppername"></a>/serviceconfigs/{scid}/hoppers/{hoppername}

マッチ チケットを作成する POST 操作をサポートしています。

> [!IMPORTANT]
> この URI コントラクト 103 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成 id (SCID)。|
| hoppername | string | ホッパーの名前。 |

<a id="ID4E2B"></a>


## <a name="valid-methods"></a>有効なメソッド

[POST (/serviceconfigs/{scid}/hoppers/{hoppername})](uri-serviceconfigsscidhoppershoppernamepost.md)

&nbsp;&nbsp;指定したマッチ チケットを作成します。

<a id="ID4EFC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EHC"></a>


##### <a name="parent"></a>Parent  

[マッチメイキング URI](atoc-reference-matchtickets.md)
