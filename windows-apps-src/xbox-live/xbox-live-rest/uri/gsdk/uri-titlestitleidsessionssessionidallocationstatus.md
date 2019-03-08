---
title: /titles/{titleId}/sessions/{sessionId}/allocationStatus
assetID: 55611f4b-4ba4-fa9a-ce44-fcc4a6df1b35
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionssessionidallocationstatus.html
description: " /titles/{titleId}/sessions/{sessionId}/allocationStatus"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: aa66b81d1e363488a6969ab31d7091b695f09ae4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603307"
---
# <a name="titlestitleidsessionssessionidallocationstatus"></a>/titles/{titleId}/sessions/{sessionId}/allocationStatus
指定したタイトルの id とセッション id は、チケット要求の状態を取得します。 これらの Uri のドメインが`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EU)
  * [ホスト名](#ID4EPB)
  * [有効なメソッド](#ID4EWB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 説明| 
| --- | --- | 
| titleId| 要求の操作対象のタイトルの ID。| 
| sessionId| 検索する、セッションの ID。| 
  
<a id="ID4EPB"></a>

 
## <a name="host-name"></a>ホスト名
 
gameserverms.xboxlive.com
  
<a id="ID4EWB"></a>

 
## <a name="valid-methods"></a>有効なメソッド
  
[取得](uri-titlestitleidsessionssessionidallocationstatus-get.md)
 
&nbsp;&nbsp;そのセッション Id で識別される sessionhost の割り当て状態を返します。
   