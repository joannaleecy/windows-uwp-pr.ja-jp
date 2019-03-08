---
title: ゲーム サーバー Universal Resource Identifier (URI) のリファレンス
assetID: bbd7e3f3-77ac-6ffd-8951-fe4b8b48eb4c
permalink: en-us/docs/xboxlive/rest/atoc-gsdk-uri-reference.html
description: " ゲーム サーバー Universal Resource Identifier (URI) のリファレンス"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a9a0a38cff9214485b2d7e8b1f8a28acb3207444
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662597"
---
# <a name="game-server-universal-resource-identifier-uri-reference"></a>ゲーム サーバー Universal Resource Identifier (URI) のリファレンス
タイトルのゲーム Server 開発キットのサーバー インスタンスを作成するのに使用する Uri。 これらの Uri のドメインが`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
<a id="ID4EY"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/qosservers](uri-qosservers.md)

&nbsp;&nbsp;Xbox Live コンピューティングで使用するために使用できる QoS サーバーの一覧を取得するクライアントから呼び出す URI。

[/titles/{titleId}/clusters](uri-titlestitleidclusters.md)

&nbsp;&nbsp;により、クライアントはタイトルの Xbox Live コンピューティング サーバー インスタンスを作成する URI。

[/titles/{titleId}/variants](uri-titlestitleidvariants.md)

&nbsp;&nbsp;タイトルの使用可能なバリエーションを取得するクライアントから呼び出す URI。

[/titles/{titleId}/sessionhosts](uri-titlestitleidsessionhosts.md)

&nbsp;&nbsp;指定したタイトルの id に割り当てられる Xbox Live コンピューティング sessionhost を要求します。

[/titles/{titleId}/sessions/{sessionId}/allocationStatus](uri-titlestitleidsessionssessionidallocationstatus.md)

&nbsp;&nbsp;指定したタイトルの id とセッション id は、チケット要求の状態を取得します。
 