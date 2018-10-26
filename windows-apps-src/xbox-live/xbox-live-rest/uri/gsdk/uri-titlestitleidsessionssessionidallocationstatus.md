---
title: /titles/{titleId}/sessions/{sessionId}/allocationStatus
assetID: 55611f4b-4ba4-fa9a-ce44-fcc4a6df1b35
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionssessionidallocationstatus.html
author: KevinAsgari
description: " /titles/{titleId}/sessions/{sessionId}/allocationStatus"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 203e0eb87502d618d5bc4649d7bb81861c41b23a
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5547167"
---
# <a name="titlestitleidsessionssessionidallocationstatus"></a>/titles/{titleId}/sessions/{sessionId}/allocationStatus
特定のタイトル id とセッション id、チケットの要求の状態を取得します。 これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EU)
  * [ホスト名](#ID4EPB)
  * [有効なメソッド](#ID4EWB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 説明| 
| --- | --- | 
| titleId| 要求の操作のタイトルの ID です。| 
| sessionId| 検索するセッションの ID。| 
  
<a id="ID4EPB"></a>

 
## <a name="host-name"></a>ホスト名
 
gameserverms.xboxlive.com
  
<a id="ID4EWB"></a>

 
## <a name="valid-methods"></a>有効なメソッド
  
[GET](uri-titlestitleidsessionssessionidallocationstatus-get.md)
 
&nbsp;&nbsp;その sessionId によって識別 sessionhost の割り当てを取得します。
   