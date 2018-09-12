---
title: /serviceconfigs//hoppers/{呼び出します}/tickets/{ticketid}
assetID: 25deb7fe-859c-01d2-d14f-455a36c08a7c
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketid.html
author: KevinAsgari
description: " /serviceconfigs//hoppers/{呼び出します}/tickets/{ticketid}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dd7ed139fffb8bdb10ac5074d5e9725753678f1c
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881791"
---
# <a name="serviceconfigsscidhoppershoppernameticketsticketid"></a>/serviceconfigs//hoppers/{呼び出します}/tickets/{ticketid}

マッチ チケットの削除操作をサポートしています。

> [!IMPORTANT]
> この URI コントラクト 103 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EW"></a>


## <a name="remarks"></a>注釈
この URI には、対象ユーザーの構成で所有者識別子の値の xuid、gt、および me がサポートしています。  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成 id (SCID)。|
| name| string| ホッパーの名前です。|
| ticketId| GUID| チケットの id。|

<a id="ID4EJC"></a>


## <a name="valid-methods"></a>有効なメソッド

[(/Serviceconfigs//hoppers/{呼び出します}/tickets/{ticketid}) を削除します。](uri-scidhoppernameticketiddelete.md)

&nbsp;&nbsp;マッチ チケットを削除します。

<a id="ID4ETC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EVC"></a>


##### <a name="parent"></a>Parent  

[マッチメイ キング Uri](atoc-reference-matchtickets.md)
