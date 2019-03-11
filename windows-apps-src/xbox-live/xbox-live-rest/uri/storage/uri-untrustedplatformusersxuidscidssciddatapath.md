---
title: /untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}
assetID: d1e05113-c7a3-d615-52d7-d54f08b30b44
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersxuidscidssciddatapath.html
description: " /untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1d722656412e0864b338c5444407572a13f5fbd0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650427"
---
# <a name="untrustedplatformusersxuidxuidscidssciddatapath"></a>/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}
指定されたパスにファイル情報を一覧表示します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。| 
| scid| guid| 検索するサービス構成の ID。| 
| パス| string| 返されるデータのアイテムへのパス。 一致するすべてのディレクトリとサブディレクトリが返されるを取得します。 有効な文字には、大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_) およびスラッシュ (/) が含まれます。 空にすることがあります。 最大長は 256 です。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得](uri-untrustedplatformusersxuidscidssciddatapath-get.md)

&nbsp;&nbsp;指定されたパスにファイル情報を一覧表示します。
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a>Parent 

[ストレージ Uri のタイトル](atoc-reference-storagev2.md)

   