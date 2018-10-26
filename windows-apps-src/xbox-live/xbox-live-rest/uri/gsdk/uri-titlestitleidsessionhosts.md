---
title: /titles/{titleId}/sessionhosts
assetID: 92d9bdd2-5c8f-761b-3f9a-50f8db7b843c
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionhosts.html
author: KevinAsgari
description: " /titles/{titleId}/sessionhosts"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 10ceab8cedb8a4047e4e431716a2b58c060e7e99
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5551951"
---
# <a name="titlestitleidsessionhosts"></a>/titles/{titleId}/sessionhosts
特定のタイトル id が割り当ての Xbox Live Compute sessionhost を要求します。これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EU)
  * [ホスト名](#ID4EIB)
  * [有効なメソッド](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 説明| 
| --- | --- | 
| titleId| 要求の操作のタイトルの ID です。| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a>ホスト名
 
gameserverms.xboxlive.com
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a>有効なメソッド
  
[POST](uri-titlestitleidsessionhosts-post.md)
 
&nbsp;&nbsp;新しいクラスターの要求を作成します。
   