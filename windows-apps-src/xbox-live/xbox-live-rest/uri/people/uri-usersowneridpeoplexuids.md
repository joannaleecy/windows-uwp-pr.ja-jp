---
title: ユーザー/xuid/users/{ownerId}
assetID: db2faec7-9f6c-f240-586a-45d6ed596e88
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuids.html
author: KevinAsgari
description: " ユーザー/xuid/users/{ownerId}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 715659b8bb001697fc9386be6ec587b3682793c5
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882396"
---
# <a name="usersowneridpeoplexuids"></a>ユーザー/xuid/users/{ownerId}
XUID によってユーザーを呼び出し元のユーザーのコレクションからアクセスします。 これらの Uri のドメインが`social.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| ownerId| string| そのリソースにアクセスしているユーザーの識別子。 認証されたユーザーに一致する必要があります。 設定可能な値とは、"me"、だけ、または gt({gamertag}) です。| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[POST](uri-usersowneridpeoplexuidspost.md)

&nbsp;&nbsp;呼び出し元のユーザーからコレクションに対応する XUID によってユーザーを取得します。
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) の参照](../atoc-xboxlivews-reference-uris.md)

   