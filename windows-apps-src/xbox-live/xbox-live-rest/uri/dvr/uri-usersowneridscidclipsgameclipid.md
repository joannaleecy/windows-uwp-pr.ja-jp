---
title: /users/{ownerId}/scids/{scid}/clips/{gameClipId}
assetID: 49b68418-71f1-c5a2-3a9b-869fd1fa663c
permalink: en-us/docs/xboxlive/rest/uri-usersowneridscidclipsgameclipid.html
description: " /users/{ownerId}/scids/{scid}/clips/{gameClipId}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e7ea92e89d54df17e8d82084d840a7ee9ef7d032
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658337"
---
# <a name="usersowneridscidsscidclipsgameclipid"></a>/users/{ownerId}/scids/{scid}/clips/{gameClipId}
特定するすべての Id がわかっている場合は、ゲームの 1 つのクリップをシステムからアクセスします。 これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。
 
  * [URI パラメーター](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| ownerId| string| リソースがアクセスされているユーザーのユーザー id。 サポートされている形式:"xuid(123456789)"または"me"。 最大長:16.| 
| scid| string| サービス アクセスされているリソースの ID を構成します。 認証されたユーザーの SCID に一致する必要があります。| 
| gameClipId| string| アクセスされているリソースの ID をゲーム クリップだった。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})](uri-usersowneridscidclipsgameclipidget.md)

&nbsp;&nbsp;指定することのすべての Id がわかっている場合は、システムからゲームの 1 つのクリップを取得します。
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a>Parent 

[ゲーム録画 Uri](atoc-reference-dvr.md)

   