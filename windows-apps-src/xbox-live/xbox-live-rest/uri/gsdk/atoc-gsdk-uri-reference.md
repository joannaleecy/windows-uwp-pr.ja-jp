---
title: ゲーム サーバー ユニバーサル リソース識別子 (URI) リファレンス
assetID: bbd7e3f3-77ac-6ffd-8951-fe4b8b48eb4c
permalink: en-us/docs/xboxlive/rest/atoc-gsdk-uri-reference.html
author: KevinAsgari
description: " ゲーム サーバー ユニバーサル リソース識別子 (URI) リファレンス"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 757375f18ddf935b19baad84501dfd4d5415a197
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5559161"
---
# <a name="game-server-universal-resource-identifier-uri-reference"></a>ゲーム サーバー ユニバーサル リソース識別子 (URI) リファレンス
Uri のクライアントで、タイトルのゲーム サーバー開発キット サーバーのインスタンスを作成するために使用します。 これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
<a id="ID4EY"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/qosservers](uri-qosservers.md)

&nbsp;&nbsp;URI が利用可能な QoS サーバーの一覧を取得する Xbox Live エンジンで使用するためにクライアントによって呼び出されます。

[/titles/{titleId}/clusters](uri-titlestitleidclusters.md)

&nbsp;&nbsp;により、クライアントは、タイトルの Xbox Live Compute サーバー インスタンスを作成する URI。

[/titles/{titleId}/variants](uri-titlestitleidvariants.md)

&nbsp;&nbsp;URI は、タイトルの利用可能な言語バリアントを取得するクライアントによって呼び出されます。

[/titles/{titleId}/sessionhosts](uri-titlestitleidsessionhosts.md)

&nbsp;&nbsp;特定のタイトル id が割り当ての Xbox Live Compute sessionhost を要求します。

[/titles/{titleId}/sessions/{sessionId}/allocationStatus](uri-titlestitleidsessionssessionidallocationstatus.md)

&nbsp;&nbsp;特定のタイトル id とセッション id、チケットの要求の状態を取得します。
 