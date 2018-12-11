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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8947713"
---
# <a name="game-dvr-uris"></a>ゲーム DVR URI
 
このセクションでは、*ゲーム DVR*の Xbox Live サービスからユニバーサル リソース識別子 (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。
 
本体のみが、ゲーム クリップを記録できますにアクセスできる任意のデバイスにクリップを表示できます。
 
対象の URI の関数をに応じてにはこれらの Uri のドメインです。
 
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

   