---
title: /global/scids/{scid}/data/{path}
assetID: d6353cd3-9127-98d4-bb99-5df690e07022
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapath.html
description: " /global/scids/{scid}/data/{path}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b8788ae6773c53c2f86b3f51ee9023876416feeb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618867"
---
# <a name="globalscidssciddatapath"></a>/global/scids/{scid}/data/{path}
指定されたパスにファイル情報を一覧表示します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| scid| guid| 検索するサービス構成の ID。| 
| パス| string| 返されるデータのアイテムへのパス。 一致するすべてのディレクトリとサブディレクトリが返されるを取得します。 有効な文字には、大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_) およびスラッシュ (/) が含まれます。 空にすることがあります。 最大長は 256 です。| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得](uri-globalscidssciddatapath-get.md)

&nbsp;&nbsp;指定されたパスにファイル情報を一覧表示します。
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a>Parent 

[ストレージ Uri のタイトル](atoc-reference-storagev2.md)

   