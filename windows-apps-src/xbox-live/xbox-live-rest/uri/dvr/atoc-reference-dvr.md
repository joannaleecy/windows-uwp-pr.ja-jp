---
title: ゲーム DVR URI
assetID: 472f705e-bf28-7894-b1ba-80933d8746a6
permalink: en-us/docs/xboxlive/rest/atoc-reference-dvr.html
description: " ゲーム DVR URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b4bfd6e51efce4c6ec85db99a10a44a776dcb840
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617847"
---
# <a name="game-dvr-uris"></a>ゲーム DVR URI
 
このセクションでは、Universal Resource Identifier (URI) アドレスおよび関連付けられているハイパー テキスト転送プロトコル (HTTP) メソッドの詳細を提供の Xbox Live サービスから*ゲーム録画*します。
 
コンソールのみが、ゲームのクリップを記録できますが、アクセスできる任意のデバイスは、クリップを表示できます。
 
対象の URI の関数によっては、これらの Uri のドメイン。
 
   *  gameclipsmetadata.xboxlive.com 
   *  gameclipstransfer.xboxlive.com 
  
<a id="ID4EZB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/public/scids/{scid}/clips](uri-publicscidclips.md)

&nbsp;&nbsp;クリップをパブリックにアクセスします。 この URI 実際に指定できます 2 つの形式で`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。 詳しくは、後のセクションをご覧ください。

[/{uri}](uri-uri.md)

&nbsp;&nbsp;クリップのゲーム データにアクセスします。

[/users/me/scids/{scid}/clips](uri-usersmescidclips.md)

&nbsp;&nbsp;初期のアクセスは、要求をアップロードします。

[/users/me/scids/{scid}/clips/{gameClipId}](uri-usersmescidclipsgameclipid.md)

&nbsp;&nbsp;ゲームのクリップのデータ アクセスとメタデータ。

[/users/{ownerId}/clips](uri-usersowneridclips.md)

&nbsp;&nbsp;ユーザーのクリップのアクセス リスト。

[/users/{ownerId}/scids/{scid}/clips/{gameClipId}](uri-usersowneridscidclipsgameclipid.md)

&nbsp;&nbsp;特定するすべての Id がわかっている場合は、ゲームの 1 つのクリップをシステムからアクセスします。
 
<a id="ID4EOC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a>Parent 

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   