---
title: ゲーム DVR URI
assetID: 472f705e-bf28-7894-b1ba-80933d8746a6
permalink: en-us/docs/xboxlive/rest/atoc-reference-dvr.html
author: KevinAsgari
description: " ゲーム DVR URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7c9be3254d9264c1d06dd0a327c36b473a457a35
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5437283"
---
# <a name="game-dvr-uris"></a>ゲーム DVR URI
 
このセクションでは、*ゲーム DVR*の Xbox Live サービスからユニバーサル リソース識別子 (URI) アドレスと関連付けられたハイパー テキスト トランスポート プロトコル (HTTP) メソッドについての詳細を提供します。
 
本体のみが、ゲーム クリップを記録できますにアクセスできる任意のデバイスがクリップを表示できます。
 
によっては、対象の URI の関数は、これらの Uri のドメインは。
 
   *  gameclipsmetadata.xboxlive.com 
   *  gameclipstransfer.xboxlive.com 
  
<a id="ID4EZB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/public/scids/{scid}/clips](uri-publicscidclips.md)

&nbsp;&nbsp;クリップをパブリックにアクセスします。 この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。 詳しくは、後のセクションをご覧ください。

[/{uri}](uri-uri.md)

&nbsp;&nbsp;ゲーム クリップ データにアクセスします。

[/users/me/scids/{scid}/clips](uri-usersmescidclips.md)

&nbsp;&nbsp;最初のアクセスは、要求をアップロードします。

[/users/me/scids/{scid}/clips/{gameClipId}](uri-usersmescidclipsgameclipid.md)

&nbsp;&nbsp;ゲーム クリップ データへのアクセスとメタデータ。

[/users/{ownerId}/clips](uri-usersowneridclips.md)

&nbsp;&nbsp;ユーザーのクリップのアクセスの一覧です。

[/users/{ownerId}/scids/{scid}/clips/{gameClipId}](uri-usersowneridscidclipsgameclipid.md)

&nbsp;&nbsp;すべての Id を見つけることがわかっている場合はシステムから 1 つのゲーム クリップにアクセスします。
 
<a id="ID4EOC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   