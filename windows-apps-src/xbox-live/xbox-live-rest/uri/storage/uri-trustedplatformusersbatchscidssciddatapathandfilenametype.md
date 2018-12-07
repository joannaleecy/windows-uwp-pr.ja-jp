---
title: /trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}
assetID: c92d247a-5ea1-7a06-36db-7c67a1dc3151
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersbatchscidssciddatapathandfilenametype.html
description: " /trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 716632e355fd37512f6777f1b877f11280c689eb
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8745329"
---
# <a name="trustedplatformusersbatchscidssciddatapathandfilenametype"></a>/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}
同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| guid| ルックアップ サービス構成の ID です。| 
| pathAndFileName| string| アクセスできる項目のパスとファイルの名前です。 パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名を空にすることがありますはいない期間の終了または 2 つの連続するピリオドが含まれてはします。| 
| type| 文字列| データの形式です。 使用可能な値とは、バイナリまたは json です。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[POST](uri-trustedplatformusersbatchscidssciddatapathandfilenametype-post.md)

&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ URI](atoc-reference-storagev2.md)

   