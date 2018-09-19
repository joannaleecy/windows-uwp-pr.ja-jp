---
title: プレゼンス URI
assetID: 4ba44d9c-8615-cacc-2eee-7ff5e7c74383
permalink: en-us/docs/xboxlive/rest/atoc-reference-presence.html
author: KevinAsgari
description: " プレゼンス URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f4c2a34d47f894e2ac9aeaf6228c8ebd41348306
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4052099"
---
# <a name="presence-uris"></a>プレゼンス URI
 
このセクションでは、*プレゼンス*の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。
 
Xbox 360、Windows Phone デバイス、または Windows を実行しているゲームだけでは、このサービスを使用できます。
 
これらの Uri のドメインは、userpresence.xboxlive.com です。
 
リアルタイム アクティビティ (RTA) サービスを使用して、ユーザーのプレゼンスの変更をサブスクライブすることができます。
 
<a id="ID4ERB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/batch](uri-usersbatch.md)

&nbsp;&nbsp;ユーザーのバッチのプレゼンスをアクセスします。

[/users/me](uri-usersme.md)

&nbsp;&nbsp;現在のユーザーのプレゼンスにアクセスします。

[/users/me/groups/{moniker}](uri-usersmegroupsmoniker.md)

&nbsp;&nbsp;[グループの presencerecord を要求してにアクセスします。

[/users/xuid({xuid})](uri-usersxuid.md)

&nbsp;&nbsp;別のユーザーまたはクライアントの有無にアクセスします。

[/users/xuid({xuid})/devices/current/titles/current](uri-usersxuiddevicescurrenttitlescurrent.md)

&nbsp;&nbsp;タイトルまたはタイトルのユーザーのプレゼンスにアクセスします。

[/users/xuid({xuid})/groups/{moniker}](uri-usersxuidgroupsmoniker.md)

&nbsp;&nbsp;グループの presencerecord を要求してにアクセスします。

[/users/xuid({xuid})/groups/{moniker}/broadcasting](uri-usersxuidgroupsmonikerbroadcasting.md)

&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードにアクセスします。

[/users/xuid({xuid})/groups/{moniker}/broadcasting/count](uri-usersxuidgroupsmonikerbroadcastingcount.md)

&nbsp;&nbsp;アクセス グループ モニカーで指定されているブロードキャスト ユーザーの数は、URI に表示される XUID に関連します。
 
<a id="ID4EMC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   