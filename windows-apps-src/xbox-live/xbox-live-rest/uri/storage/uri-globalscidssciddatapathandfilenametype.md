---
title: /global/scids/{scid}/data/{pathAndFileName},{type}
assetID: 774ce2dc-15c5-fe12-42b9-4e040bd4d2cf
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /global/scids/{scid}/data/{pathAndFileName},{type}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cd4323f8d4f929a46f0636facbc52e451b7a582e
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4470968"
---
# <a name="globalscidssciddatapathandfilenametype"></a>/global/scids/{scid}/data/{pathAndFileName},{type}
ファイルをダウンロードします。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| guid| ルックアップ サービス構成の ID です。| 
| pathAndFileName| string| アクセスできる項目のパスとファイル名。 パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。| 
| type| 文字列| データの形式です。 使用可能な値: バイナリ、config または json します。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET](uri-globalscidssciddatapathandfilenametype-get.md)

&nbsp;&nbsp;ファイルをダウンロードします。
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ URI](atoc-reference-storagev2.md)

   