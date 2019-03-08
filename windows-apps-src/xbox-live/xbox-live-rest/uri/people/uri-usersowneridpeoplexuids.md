---
title: /users/{ownerId}/people/xuids
assetID: db2faec7-9f6c-f240-586a-45d6ed596e88
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuids.html
description: " /users/{ownerId}/people/xuids"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 27b7695ba163bf0ca832a96df030868e646e0abc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57626337"
---
# <a name="usersowneridpeoplexuids"></a>/users/{ownerId}/people/xuids
XUID によってユーザーを呼び出し元のユーザーのコレクションからアクセスされます。 これらの Uri のドメインが`social.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| ownerId| string| リソースがアクセスされているユーザーの識別子。 認証されたユーザーに一致する必要があります。 使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[投稿](uri-usersowneridpeoplexuidspost.md)

&nbsp;&nbsp;呼び出し元のユーザーからコレクションの XUID によってユーザーを取得します。
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a>Parent 

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   