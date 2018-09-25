---
title: /users/{ownerId}/people/{targetid}
assetID: 9dd19e75-3b48-d7e0-fc65-6760c15ddf62
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopletargetid.html
author: KevinAsgari
description: " /users/{ownerId}/people/{targetid}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7693d9e60a9fdf58eba8aecdd8618c0a78ecef44
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4173142"
---
# <a name="usersowneridpeopletargetid"></a>/users/{ownerId}/people/{targetid}
呼び出し元のユーザーのコレクションからターゲット ID によってユーザーにアクセスします。 これらの Uri のドメインが`social.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| ownerId| string| そのリソースにアクセスしているユーザーの識別子です。 認証されたユーザーに一致する必要があります。 設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。| 
| targetid| string| 所有者の People リストで、Xbox ユーザー ID (XUID) か、ゲーマータグがデータを取得するユーザーの識別子です。 値の例: xuid(2603643534573581)、gt(SomeGamertag) します。| 
  
<a id="ID4EQB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET](uri-usersowneridpeopletargetidget.md)

&nbsp;&nbsp;呼び出し元のユーザーのコレクションからターゲット ID によってユーザーを取得します。
 
<a id="ID4E1B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E3B"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   