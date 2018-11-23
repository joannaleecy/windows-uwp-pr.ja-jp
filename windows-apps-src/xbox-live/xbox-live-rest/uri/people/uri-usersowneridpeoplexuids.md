---
title: /users/{ownerId}/people/xuids
assetID: db2faec7-9f6c-f240-586a-45d6ed596e88
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuids.html
author: KevinAsgari
description: " /users/{ownerId}/people/xuids"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d2b915e185462e65f68fefce009d6081e7cddf37
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7572782"
---
# <a name="usersowneridpeoplexuids"></a>/users/{ownerId}/people/xuids
XUID によって people を呼び出し元のユーザーのコレクションからアクセスします。 これらの Uri のドメインが`social.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| ownerId| string| そのリソースにアクセスしているユーザーの id。 認証されたユーザーに一致する必要があります。 可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[POST](uri-usersowneridpeoplexuidspost.md)

&nbsp;&nbsp;呼び出し元のユーザーからコレクションに対応する XUID によってユーザーを取得します。
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   