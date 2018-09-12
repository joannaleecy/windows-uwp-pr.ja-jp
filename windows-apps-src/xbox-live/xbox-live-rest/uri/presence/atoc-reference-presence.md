---
title: プレゼンス Uri
assetID: 4ba44d9c-8615-cacc-2eee-7ff5e7c74383
permalink: en-us/docs/xboxlive/rest/atoc-reference-presence.html
author: KevinAsgari
description: " プレゼンス Uri"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f4c2a34d47f894e2ac9aeaf6228c8ebd41348306
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881987"
---
# <a name="presence-uris"></a>プレゼンス Uri
 
このセクションでは、*プレゼンス*の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法についての詳細を提供します。
 
Xbox 360、Windows Phone デバイスの場合、または Windows を実行しているゲームのみでは、このサービスを使用できます。
 
これらの Uri のドメインは、userpresence.xboxlive.com です。
 
リアルタイム アクティビティ (RTA) サービスを使用して、ユーザーのプレゼンスの変更をサブスクライブできます。
 
<a id="ID4ERB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[ユーザー/バッチ](uri-usersbatch.md)

&nbsp;&nbsp;ユーザーのバッチのプレゼンスをアクセスします。

[ユーザー/me](uri-usersme.md)

&nbsp;&nbsp;現在のユーザーのプレゼンスにアクセスします。

[ユーザー/me/グループ/{モニカー}](uri-usersmegroupsmoniker.md)

&nbsp;&nbsp;[グループの presencerecord を要求してにアクセスします。

[/users/xuid({xuid})](uri-usersxuid.md)

&nbsp;&nbsp;別のユーザーまたはクライアントの有無にアクセスします。

[/users/xuid({xuid})/devices/current/titles/current](uri-usersxuiddevicescurrenttitlescurrent.md)

&nbsp;&nbsp;タイトルまたはタイトルのユーザーの有無にアクセスします。

[ユーザー/xuid ({xuid})/groups/{モニカー}](uri-usersxuidgroupsmoniker.md)

&nbsp;&nbsp;グループの presencerecord を要求してにアクセスします。

[ユーザー/xuid ({xuid})/groups/{モニカー} ブロードキャスト/](uri-usersxuidgroupsmonikerbroadcasting.md)

&nbsp;&nbsp;アクセス グループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードは、URI に表示される XUID に関連します。

[ユーザー/xuid ({xuid})/groups/{モニカー}/ブロードキャスト/数](uri-usersxuidgroupsmonikerbroadcastingcount.md)

&nbsp;&nbsp;アクセス グループ モニカーで指定されているブロードキャスト ユーザーの数は、URI に表示される XUID に関連します。
 
<a id="ID4EMC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) の参照](../atoc-xboxlivews-reference-uris.md)

   