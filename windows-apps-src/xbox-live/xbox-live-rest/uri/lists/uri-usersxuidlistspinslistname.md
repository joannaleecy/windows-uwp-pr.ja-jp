---
title: /users/xuid(xuid)/lists/PINS/{listname}
assetID: b6421b11-fcd1-cfdb-c1fa-6cab3dab89d9
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistname.html
description: " /users/xuid(xuid)/lists/PINS/{listname}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0f9610b400e9530f86e264cea30bfdfdd1b09c8d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627997"
---
# <a name="usersxuidxuidlistspinslistname"></a>/users/xuid(xuid)/lists/PINS/{listname}
リスト内の項目にアクセスします。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox のユーザー ID (XUID)。| 
| listtype| string| (その使用方法およびどのように機能します) のリストの種類。 常に「ピン」これらのメソッドに関連します。| 
| listname| string| リストの名前 (を操作する特定の listtype のどのリスト)。 常に"XBLPins"の項目のピンです。| 
  
<a id="ID4EGC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[DELETE](uri-usersxuidlistspinslistnamedelete.md)

&nbsp;&nbsp;一覧から項目を削除します。

[取得](uri-usersxuidlistspinslistnameget.md)

&nbsp;&nbsp;一覧の内容を返します。

[投稿](uri-usersxuidlistspinslistnamepost.md)

&nbsp;&nbsp;クエリ文字列パラメーターに基づいてインデックス位置にある一覧に項目を挿入**insertIndex**します。

[PUT](uri-usersxuidlistspinslistnameput.md)

&nbsp;&nbsp;要求本文内の各項目に指定されたインデックスによってリスト内の項目を更新します。
 
<a id="ID4EZC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E2C"></a>

 
##### <a name="parent"></a>Parent 

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   