---
title: プレゼンス URI
assetID: 4ba44d9c-8615-cacc-2eee-7ff5e7c74383
permalink: en-us/docs/xboxlive/rest/atoc-reference-presence.html
description: " プレゼンス URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1a46ecd48c2b0bf523ab234a5f20cf9ed6669e75
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632607"
---
# <a name="presence-uris"></a>プレゼンス URI
 
このセクションでは、Universal Resource Identifier (URI) アドレスおよび関連付けられているハイパー テキスト転送プロトコル (HTTP) メソッドの詳細を提供の Xbox Live サービスから*プレゼンス*します。
 
Xbox 360、Windows Phone デバイス、または Windows を実行しているゲームだけでは、このサービスを使用できます。
 
これらの Uri のドメインとは、userpresence.xboxlive.com です。
 
リアルタイムのアクティビティ (RTA) サービスを使用して、ユーザーのプレゼンスの変更をサブスクライブできます。
 
<a id="ID4ERB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/batch](uri-usersbatch.md)

&nbsp;&nbsp;ユーザーのバッチのアクセスが存在します。

[/users/me](uri-usersme.md)

&nbsp;&nbsp;現在のユーザーのプレゼンスにアクセスします。

[/users/me/groups/{moniker}](uri-usersmegroupsmoniker.md)

&nbsp;&nbsp;自分のグループの PresenceRecord にアクセスします。

[/users/xuid({xuid})](uri-usersxuid.md)

&nbsp;&nbsp;別のユーザーまたはクライアントの存在にアクセスします。

[/users/xuid({xuid})/devices/current/titles/current](uri-usersxuiddevicescurrenttitlescurrent.md)

&nbsp;&nbsp;タイトルまたはタイトルのユーザーの存在にアクセスします。

[/users/xuid({xuid})/groups/{moniker}](uri-usersxuidgroupsmoniker.md)

&nbsp;&nbsp;グループの PresenceRecord にアクセスします。

[/users/xuid({xuid})/groups/{moniker}/broadcasting](uri-usersxuidgroupsmonikerbroadcasting.md)

&nbsp;&nbsp;アクセス グループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンスのレコードに関連する XUID URI に表示されます。

[/users/xuid({xuid})/groups/{moniker}/broadcasting/count](uri-usersxuidgroupsmonikerbroadcastingcount.md)

&nbsp;&nbsp;アクセス グループ モニカーによって指定されたブロードキャスト ユーザーの数は、URI に表示される XUID に関連します。
 
<a id="ID4EMC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a>Parent 

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   