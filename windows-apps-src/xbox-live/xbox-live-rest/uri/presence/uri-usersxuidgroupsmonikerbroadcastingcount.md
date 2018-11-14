---
title: /users/xuid({xuid})/groups/{moniker}/broadcasting/count
assetID: 535c8d46-7001-c31e-3e9d-82ad275095ae
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcastingcount.html
author: KevinAsgari
description: " /users/xuid({xuid})/groups/{moniker}/broadcasting/count"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dbfe207483f5814d2cd32ffcd5ac651c0ab5aa52
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6251908"
---
# <a name="usersxuidxuidgroupsmonikerbroadcastingcount"></a>/users/xuid({xuid})/groups/{moniker}/broadcasting/count
アクセス グループ モニカーで指定されているブロードキャスト ユーザーの数は、URI 内に表示される XUID に関連します。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連します。| 
| モニカー| string| ユーザーのグループを定義する文字列です。 現時点でのみ受け入れたモニカーでは、大文字の 'P'"People"でです。| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )](uri-usersxuidgroupsmonikerbroadcastingcountget.md)

&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーの数を取得します。
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a>Parent 

[プレゼンス URI](atoc-reference-presence.md)

   