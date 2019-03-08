---
title: /serviceconfigs/{scid}/hoppers/{hoppername}
assetID: ba1e129d-b4c4-6535-46ce-fd184465c85f
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppername.html
description: " /serviceconfigs/{scid}/hoppers/{hoppername}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1db069f59eeba565a257531907d6be0b1dcd189d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598427"
---
# <a name="serviceconfigsscidhoppershoppername"></a>/serviceconfigs/{scid}/hoppers/{hoppername}

一致のチケットを作成する POST 操作をサポートしています。

> [!IMPORTANT]
> この URI は、コントラクト 103 以降で使用するためのものがおり、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成識別子 (SCID)。|
| hoppername | string | Hopper の名前。 |

<a id="ID4E2B"></a>


## <a name="valid-methods"></a>有効なメソッド

[POST (/serviceconfigs/{scid}/hoppers/{hoppername})](uri-serviceconfigsscidhoppershoppernamepost.md)

&nbsp;&nbsp;指定した一致のチケットを作成します。

<a id="ID4EFC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EHC"></a>


##### <a name="parent"></a>Parent  

[Uri のマッチメイ キング](atoc-reference-matchtickets.md)
