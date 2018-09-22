---
title: /json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json
assetID: d004d715-d73c-693e-2a0b-ce64f482642b
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fa553cce9ee3179f32573e00c1e215ab46e89b21
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4122410"
---
# <a name="jsonusersxuidxuidscidssciddatapathandfilenamejson"></a>/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json
ダウンロード、アップロード、またはファイルを削除します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。| 
| scid| guid| ルックアップ サービス構成の ID です。| 
| pathAndFileName| string| アクセスできる項目のパスとファイル名。 パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[DELETE](uri-jsonusersxuidscidssciddatapathandfilenametype-delete.md)

&nbsp;&nbsp;ファイルを削除します。 

[GET](uri-jsonusersxuidscidssciddatapathandfilenametype-get.md)

&nbsp;&nbsp;ファイルをダウンロードします。

[PUT](uri-jsonusersxuidscidssciddatapathandfilenametype-put.md)

&nbsp;&nbsp;ファイルをアップロードします。 Json の種類のデータの複数のブロックのアップロードがサポートされていません。 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ URI](atoc-reference-storagev2.md)

   