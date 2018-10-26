---
title: /serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}
assetID: 25deb7fe-859c-01d2-d14f-455a36c08a7c
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketid.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 19021d01f5f3af65b8a239a9a7521646e78e0bd6
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5557439"
---
# <a name="serviceconfigsscidhoppershoppernameticketsticketid"></a>/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}

マッチ チケットの削除操作をサポートしています。

> [!IMPORTANT]
> この URI コントラクト 103 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EW"></a>


## <a name="remarks"></a>注釈
この URI は、対象ユーザーの構成では所有者識別子の値の xuid、gt、および me をサポートしています。  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成 id (SCID)。|
| name| string| ホッパーの名前。|
| ticketId| GUID| チケットの id。|

<a id="ID4EJC"></a>


## <a name="valid-methods"></a>有効なメソッド

[DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})](uri-scidhoppernameticketiddelete.md)

&nbsp;&nbsp;マッチ チケットを削除します。

<a id="ID4ETC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EVC"></a>


##### <a name="parent"></a>Parent  

[マッチメイキング URI](atoc-reference-matchtickets.md)
