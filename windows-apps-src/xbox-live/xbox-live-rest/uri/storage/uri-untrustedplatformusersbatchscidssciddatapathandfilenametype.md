---
title: ユーザー/untrustedplatform//global/scids/{scid}/data/{pathAndFileName} {の種類} をバッチ処理/
assetID: c2909e75-e108-3555-c157-f2d552f10e9f
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersbatchscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " ユーザー/untrustedplatform//global/scids/{scid}/data/{pathAndFileName} {の種類} をバッチ処理/"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 04952a183a2903a5c296a6b27af35766bccbddc1
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3961863"
---
# <a name="untrustedplatformusersbatchscidssciddatapathandfilenametype"></a>ユーザー/untrustedplatform//global/scids/{scid}/data/{pathAndFileName} {の種類} をバッチ処理/
同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| guid| ルックアップ サービス構成の ID です。| 
| pathAndFileName| string| アクセスできる項目のパスとファイル名。 (となどを含む最終的なスラッシュ) のパス部分に有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。| 
| type| 文字列| データの形式です。 設定可能な値は、バイナリ json です。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[POST](uri-untrustedplatformusersbatchscidssciddatapathandfilenametype-post.md)

&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ Uri](atoc-reference-storagev2.md)

   