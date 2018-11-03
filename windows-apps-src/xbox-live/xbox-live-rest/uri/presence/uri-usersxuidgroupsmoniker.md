---
title: /users/xuid({xuid})/groups/{moniker}
assetID: 7c73236b-95ee-723b-e5e0-68252c953e14
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmoniker.html
author: KevinAsgari
description: " /users/xuid({xuid})/groups/{moniker}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 640635458f50046a8fbc6a9cf539c659950e163e
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5988373"
---
# <a name="usersxuidxuidgroupsmoniker"></a>/users/xuid({xuid})/groups/{moniker}
グループの PresenceRecord にアクセスします。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID)、グループ内の Xuid に関連するユーザーのします。| 
| モニカー| string| ユーザーのグループを定義する文字列です。 現時点では受け入れられるモニカーだけでは、大文字の 'P'"People"でです。| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/xuid({xuid})/groups/{moniker} )](uri-usersxuidgroupsmonikerget.md)

&nbsp;&nbsp;グループの PresenceRecord を取得します。
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a>Parent 

[プレゼンス URI](atoc-reference-presence.md)

   