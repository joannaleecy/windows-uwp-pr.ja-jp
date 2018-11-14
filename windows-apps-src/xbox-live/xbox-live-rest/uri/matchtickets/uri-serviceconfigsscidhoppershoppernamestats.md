---
title: /serviceconfigs/{scid}/hoppers/{name}/stats
assetID: 56bb4398-445b-e8c5-a4ce-1651576ee7e7
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamestats.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/hoppers/{name}/stats"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 74712e5d20f1e74810f3123ec82dabc6b466ff1a
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6267173"
---
# <a name="serviceconfigsscidhoppersnamestats"></a>/serviceconfigs/{scid}/hoppers/{name}/stats

ホッパーの統計情報を取得する GET 操作をサポートしています。

> [!IMPORTANT]
> この URI コントラクト 103 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 103 または後ですべての要求します。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EW"></a>


## <a name="remarks"></a>注釈
この URI には、対象ユーザーの構成で所有者識別子の値の xuid、gt、および me がサポートしています。 チケットの作成者のみでは、チケットを削除したり、URI の状態を取得することができます。  
<a id="ID4E6"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成 id (SCID)。|
| name| string| ホッパーの名前です。|

<a id="ID4EEC"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/serviceconfigs/{scid}/hoppers/{name}/stats)](uri-serviceconfigsscidhoppershoppernamestatsget.md)

&nbsp;&nbsp;ホッパーの統計情報を取得します。

<a id="ID4EQC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ESC"></a>


##### <a name="parent"></a>Parent  

[マッチメイキング URI](atoc-reference-matchtickets.md)
