---
title: /global/scids/{scid}/data/{pathAndFileName},{type}
assetID: 774ce2dc-15c5-fe12-42b9-4e040bd4d2cf
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapathandfilenametype.html
description: " /global/scids/{scid}/data/{pathAndFileName},{type}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d8c58ee4888cbbe7d9a752531c489b1da3fdde86
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57656237"
---
# <a name="globalscidssciddatapathandfilenametype"></a>/global/scids/{scid}/data/{pathAndFileName},{type}
ファイルをダウンロードします。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| scid| guid| 検索するサービス構成の ID。| 
| pathAndFileName| string| アクセスする項目のパスとファイル名。 有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。| 
| type| string| データの形式です。 指定できる値は。 バイナリ、構成、または json です。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得](uri-globalscidssciddatapathandfilenametype-get.md)

&nbsp;&nbsp;ファイルをダウンロードします。
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a>Parent 

[ストレージ Uri のタイトル](atoc-reference-storagev2.md)

   