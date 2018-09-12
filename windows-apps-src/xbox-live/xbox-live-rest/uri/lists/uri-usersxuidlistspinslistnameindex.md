---
title: ユーザー/xuid (xuid)//ピン/{リスト} の一覧を示します (/members) のインデックス/かどうか insertIndex = {insertIndex}。
assetID: edcb19bd-87a5-732b-0c45-6f7355fc2dd1
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameindex.html
author: KevinAsgari
description: " ユーザー/xuid (xuid)//ピン/{リスト} の一覧を示します (/members) のインデックス/かどうか insertIndex = {insertIndex}。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d4b1be4ab591a5bea8d7bc70fb7f7dcb29e4f548
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881550"
---
# <a name="usersxuidxuidlistspinslistnameindexindexinsertindexinsertindex"></a>ユーザー/xuid (xuid)//ピン/{リスト} の一覧を示します (/members) のインデックス/かどうか insertIndex = {insertIndex}。
一覧内の項目を移動します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| XUID| string| ユーザーの XUID です。| 
| リスト| string| 操作の一覧の名前です。| 
| インデックス| string| 移動する項目の現在のインデックスを指定します。 インデックス値が 0 または正の整数の場合は、これは、項目の現在のインデックスを参照し、呼び出しの要求本文は空にする必要があります。 ただし、インデックス値が「-1」の場合は、ItemId または呼び出しの要求本文には、プロバイダー/ProviderID によって移動する項目を指定してください。 | 
  
<a id="ID4EHC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[POST](uri-usersxuidlistspinslistnameindexpost.md)

&nbsp;&nbsp;リスト内の異なる位置に一覧で項目を移動します。
 
<a id="ID4ERC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ETC"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) の参照](../atoc-xboxlivews-reference-uris.md)

   