---
title: /serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}
assetID: 25deb7fe-859c-01d2-d14f-455a36c08a7c
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketid.html
description: " /serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9722d06af64c5fd24f53485a1bcfe765f89b08cf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627317"
---
# <a name="serviceconfigsscidhoppershoppernameticketsticketid"></a>/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}

一致するチケットの削除操作をサポートしています。

> [!IMPORTANT]
> この URI は、コントラクト 103 以降で使用するためのものがおり、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EW"></a>


## <a name="remarks"></a>注釈
この URI は、ターゲット ユーザーの構成の所有者の識別子の値 xuid、gt、および私をサポートします。  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成識別子 (SCID)。|
| name| string| Hopper の名前。|
| TicketId| GUID| チケット id。|

<a id="ID4EJC"></a>


## <a name="valid-methods"></a>有効なメソッド

[DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})](uri-scidhoppernameticketiddelete.md)

&nbsp;&nbsp;一致のチケットを削除します。

<a id="ID4ETC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EVC"></a>


##### <a name="parent"></a>Parent  

[Uri のマッチメイ キング](atoc-reference-matchtickets.md)
