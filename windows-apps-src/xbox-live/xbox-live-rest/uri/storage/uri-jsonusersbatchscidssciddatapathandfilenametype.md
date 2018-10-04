---
title: /json/users/batch/scids/{scid}/data/{pathAndFileName},json
assetID: 06ae159f-7739-1330-df15-871d260e6ba1
permalink: en-us/docs/xboxlive/rest/uri-jsonusersbatchscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /json/users/batch/scids/{scid}/data/{pathAndFileName},json"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8b620144bbeee783835f5bf9181381a4c9b38a66
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4357692"
---
# <a name="jsonusersbatchscidssciddatapathandfilenamejson"></a>/json/users/batch/scids/{scid}/data/{pathAndFileName},json
同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| guid| ルックアップ サービス構成の ID です。| 
| pathAndFileName| string| アクセスできる項目のパスとファイル名。 パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[POST](uri-jsonusersbatchscidssciddatapathandfilenametype-post.md)

&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。 ダウンロードするファイルは、要求の URI によって決定されます。 要求の本文には、ダウンロードするファイル持つにはユーザーの Xuid のリストが含まれています。 応答の本文が含まれるマルチパート MIME メッセージ、独自のヘッダーのセットを特定のユーザーのファイルを表す各部分になります。 成功と失敗の混在する応答の部分のことができます。
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ URI](atoc-reference-storagev2.md)

   