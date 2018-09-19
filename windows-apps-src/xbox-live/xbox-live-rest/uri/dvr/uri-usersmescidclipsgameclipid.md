---
title: /users/me/scids/{scid}/clips/{gameClipId}
assetID: f5bead69-4fc9-f551-39cb-c8754645ac88
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipid.html
author: KevinAsgari
description: " /users/me/scids/{scid}/clips/{gameClipId}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6b5d33a8bb8b0f21ea05ac22a7d15ccb4b160b9a
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4054663"
---
# <a name="usersmescidsscidclipsgameclipid"></a>/users/me/scids/{scid}/clips/{gameClipId}
ゲーム クリップ データへのアクセスとメタデータ。 これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`問題の URI の機能に応じて、します。
 
  * [URI パラメーター](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| string| アクセスされているリソースのサービス構成 ID。 認証されたユーザーの SCID に一致する必要があります。| 
| gameClipId| string| ゲーム クリップだったにアクセスしているリソースの ID です。| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[DELETE (/users/me/scids/{scid}/clips/{gameClipId})](uri-usersmescidclipsgameclipiddelete.md)

&nbsp;&nbsp;ゲーム クリップを削除します。

[POST (/users/me/scids/{scid}/clips/{gameClipId})](uri-usersmescidclipsgameclipidpost.md)

&nbsp;&nbsp;ユーザーのデータのゲーム クリップ メタデータを更新します。
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a>Parent 

[ゲーム DVR URI](atoc-reference-dvr.md)

   