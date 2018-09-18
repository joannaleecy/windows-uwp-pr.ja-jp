---
title: リスト URI
assetID: 84dcbd11-86a0-8a1e-7db9-bcecf9b7f853
permalink: en-us/docs/xboxlive/rest/atoc-reference-lists.html
author: KevinAsgari
description: " リスト URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 00d09d5b1246e5a5d77a2d9bb9dec7b87f7847c8
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4024115"
---
# <a name="lists-uris"></a>リスト URI
 
このセクションでは、*ピン*の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) メソッドに関する詳細を提供します。
 
ゲームと Xbox 360、Windows Phone デバイスで、SmartGlass、または Xbox.com で実行されているアプリケーションのみが、このサービスを使用できます。
 
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

   