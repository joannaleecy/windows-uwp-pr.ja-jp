---
title: /users/{ownerId}/scids/{scid}/clips/{gameClipId}
assetID: 49b68418-71f1-c5a2-3a9b-869fd1fa663c
permalink: en-us/docs/xboxlive/rest/uri-usersowneridscidclipsgameclipid.html
author: KevinAsgari
description: " /users/{ownerId}/scids/{scid}/clips/{gameClipId}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d12f9e530ee6d703aa324cb6380591aab31facfd
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4356593"
---
# <a name="usersowneridscidsscidclipsgameclipid"></a>/users/{ownerId}/scids/{scid}/clips/{gameClipId}
すべての Id を見つけることがわかっている場合はシステムから 1 つのゲーム クリップにアクセスします。 これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`対象の URI の機能に応じて、します。
 
  * [URI パラメーター](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| ownerId| string| そのリソースにアクセスしているユーザーのユーザー id。 サポートされる形式:"me"または"xuid(123456789)"です。 最大長: 16 します。| 
| scid| string| サービスにアクセスしているリソースの ID を構成します。 認証されたユーザーの SCID に一致する必要があります。| 
| gameClipId| string| GameClip にアクセスしているリソースの ID です。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})](uri-usersowneridscidclipsgameclipidget.md)

&nbsp;&nbsp;すべての Id を見つけることがわかっている場合は、システムから 1 つのゲーム クリップを取得します。
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a>Parent 

[ゲーム DVR URI](atoc-reference-dvr.md)

   