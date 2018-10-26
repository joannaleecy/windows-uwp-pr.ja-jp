---
title: /users/xuid({xuid})/groups/{moniker}/broadcasting
assetID: cf8319f6-46a2-b263-ea4c-f1ce403b571b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcasting.html
author: KevinAsgari
description: " /users/xuid({xuid})/groups/{moniker}/broadcasting"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dc5bd4804d706d05aa1b4ef48199c36b21e322bc
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5554673"
---
# <a name="usersxuidxuidgroupsmonikerbroadcasting"></a>/users/xuid({xuid})/groups/{moniker}/broadcasting
URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードにアクセスします。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID)、グループ内の Xuid に関連するユーザーのします。| 
| モニカー| string| ユーザーのグループを定義する文字列です。 現時点では受け入れられるモニカーだけでは、大文字の 'P'"People"でです。| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )](uri-usersxuidgroupsmonikerbroadcastingget.md)

&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードを取得します。
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a>Parent 

[プレゼンス URI](atoc-reference-presence.md)

   