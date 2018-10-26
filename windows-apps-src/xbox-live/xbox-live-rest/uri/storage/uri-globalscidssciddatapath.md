---
title: /global/scids/{scid}/data/{path}
assetID: d6353cd3-9127-98d4-bb99-5df690e07022
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapath.html
author: KevinAsgari
description: " /global/scids/{scid}/data/{path}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 92615300a23f3d1e5013abd6d03b92270d0ae12c
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5556359"
---
# <a name="globalscidssciddatapath"></a>/global/scids/{scid}/data/{path}
指定されたパスのファイル情報の一覧を示します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| guid| ルックアップ サービス構成の ID です。| 
| path| string| 返されるデータ項目へのパス。 一致するすべてのディレクトリとサブディレクトリを取得する返されます。 有効な文字には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。 空にすることがあります。 256 の最大の長さ。| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET](uri-globalscidssciddatapath-get.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ URI](atoc-reference-storagev2.md)

   