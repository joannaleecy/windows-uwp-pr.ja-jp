---
title: /users/xuid(xuid)/lists/PINS/{listname}
assetID: b6421b11-fcd1-cfdb-c1fa-6cab3dab89d9
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistname.html
author: KevinAsgari
description: " /users/xuid(xuid)/lists/PINS/{listname}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3b76637d0c88e4ef2bc8905ff1b4dd894fd819a0
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6204625"
---
# <a name="usersxuidxuidlistspinslistname"></a>/users/xuid(xuid)/lists/PINS/{listname}
リストの項目にアクセスします。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID)。| 
| listtype| string| (その使用方法と動作) の一覧の種類です。 常に「ピン」これらのメソッドに関連します。| 
| リスト| string| 一覧の名前 (際に指定された listtype の一覧がどの)。 常に"XBLPins"の項目のピン留めします。| 
  
<a id="ID4EGC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[DELETE](uri-usersxuidlistspinslistnamedelete.md)

&nbsp;&nbsp;一覧から項目を削除します。

[GET](uri-usersxuidlistspinslistnameget.md)

&nbsp;&nbsp;リストの内容を返します。

[POST](uri-usersxuidlistspinslistnamepost.md)

&nbsp;&nbsp;クエリ文字列パラメーター **insertIndex**に基づいてインデックスの一覧に項目を挿入します。

[PUT](uri-usersxuidlistspinslistnameput.md)

&nbsp;&nbsp;要求本文内の各項目に指定されたインデックスに従ってリスト内の項目を更新します。
 
<a id="ID4EZC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E2C"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   