---
title: /users/xuid({xuid})/groups/{moniker}/broadcasting
assetID: cf8319f6-46a2-b263-ea4c-f1ce403b571b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcasting.html
description: " /users/xuid({xuid})/groups/{moniker}/broadcasting"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 98eaa60204e3c98eb1b09a13372f7b0c084a6608
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8753458"
---
# <a name="usersxuidxuidgroupsmonikerbroadcasting"></a>/users/xuid({xuid})/groups/{moniker}/broadcasting
URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードにアクセスします。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連します。| 
| モニカー| string| ユーザーのグループを定義する文字列です。 現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )](uri-usersxuidgroupsmonikerbroadcastingget.md)

&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードを取得します。
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a>Parent 

[プレゼンス URI](atoc-reference-presence.md)

   