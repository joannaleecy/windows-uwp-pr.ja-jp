---
title: /users/me/scids/{scid}/clips/{gameClipId}
assetID: f5bead69-4fc9-f551-39cb-c8754645ac88
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipid.html
description: " /users/me/scids/{scid}/clips/{gameClipId}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3cbe2d2c996b466fd94287129f1add0868f05b05
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8753915"
---
# <a name="usersmescidsscidclipsgameclipid"></a>/users/me/scids/{scid}/clips/{gameClipId}
ゲーム クリップ データへのアクセスとメタデータ。 これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。
 
  * [URI パラメーター](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| string| アクセスされているリソースのサービス構成 ID。 認証されたユーザーの SCID に一致する必要があります。| 
| gameClipId| string| GameClip にアクセスしているリソースの ID です。| 
  
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

   