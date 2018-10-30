---
title: リスト URI
assetID: 84dcbd11-86a0-8a1e-7db9-bcecf9b7f853
permalink: en-us/docs/xboxlive/rest/atoc-reference-lists.html
author: KevinAsgari
description: " リスト URI"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 63c84b68f990392d17342e333b18e5f5d38d2266
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5755599"
---
# <a name="lists-uris"></a>リスト URI
 
このセクションでは、*ピン*の Xbox Live サービスからユニバーサル リソース識別子 (URI) アドレスと関連付けられたハイパー テキスト トランスポート プロトコル (HTTP) メソッドに関する詳細を提供します。
 
ゲームと Xbox 360、Windows Phone デバイスで、SmartGlass、または Xbox.com で実行されているアプリケーションのみには、このサービスを使用できます。
 
これらの Uri のドメインは、eplists.xboxlive.com です。
 
<a id="ID4EPB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/xuid(xuid)/lists/PINS/{listname}](uri-usersxuidlistspinslistname.md)

&nbsp;&nbsp;リストの項目にアクセスします。

[/users/xuid(xuid)/lists/PINS/{listname}/ContainsItems](uri-usersxuidlistspinslistnamecontainsitems.md)

&nbsp;&nbsp;全体の一覧を取得することがなく一連項目 (itemId により指定) にはが一覧に含まれているかどうかを決定します。

[/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}](uri-usersxuidlistspinslistnameindex.md)

&nbsp;&nbsp;一覧内の項目を移動します。

[/users/xuid(xuid)/lists/PINS/{listname}/RemoveItems](uri-usersxuidlistspinslistnameremoveitems.md)

&nbsp;&nbsp;一覧から項目を削除します。
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   