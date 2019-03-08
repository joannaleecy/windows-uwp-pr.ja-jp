---
title: /serviceconfigs/{scid}/hoppers/{name}/stats
assetID: 56bb4398-445b-e8c5-a4ce-1651576ee7e7
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamestats.html
description: " /serviceconfigs/{scid}/hoppers/{name}/stats"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 04376505b76296e052ea431f2a4e5fcfeac7b9e4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613937"
---
# <a name="serviceconfigsscidhoppersnamestats"></a>/serviceconfigs/{scid}/hoppers/{name}/stats

Hopper の統計情報を取得するための GET 操作をサポートしています。

> [!IMPORTANT]
> この URI は、コントラクト 103 以降で使用するためのものがおり、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EW"></a>


## <a name="remarks"></a>注釈
この URI は、ターゲット ユーザーの構成の所有者の識別子の値 xuid、gt、および私をサポートします。 チケットの作成者だけでは、チケットを削除したり、URI の状態を取得することができます。  
<a id="ID4E6"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成識別子 (SCID)。|
| name| string| Hopper の名前。|

<a id="ID4EEC"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/serviceconfigs/{scid}/hoppers/{name}/stats)](uri-serviceconfigsscidhoppershoppernamestatsget.md)

&nbsp;&nbsp;Hopper の統計情報を取得します。

<a id="ID4EQC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ESC"></a>


##### <a name="parent"></a>Parent  

[Uri のマッチメイ キング](atoc-reference-matchtickets.md)
