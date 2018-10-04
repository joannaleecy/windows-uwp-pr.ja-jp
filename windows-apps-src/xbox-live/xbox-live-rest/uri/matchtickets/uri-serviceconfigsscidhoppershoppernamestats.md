---
title: /serviceconfigs/{scid}/hoppers/{name}/stats
assetID: 56bb4398-445b-e8c5-a4ce-1651576ee7e7
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamestats.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/hoppers/{name}/stats"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0742ad87e68f7d0c6ed6346873aa3dd6c56edee0
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4351012"
---
# <a name="serviceconfigsscidhoppersnamestats"></a>/serviceconfigs/{scid}/hoppers/{name}/stats

ホッパーの統計情報を取得するための取得操作をサポートしています。

> [!IMPORTANT]
> この URI コントラクト 103 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EW"></a>


## <a name="remarks"></a>注釈
この URI は、対象ユーザーの構成では所有者識別子の値の xuid、gt、および me をサポートしています。 チケットの作成者のみでは、チケットを削除したり、URI の状態を取得することができます。  
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
