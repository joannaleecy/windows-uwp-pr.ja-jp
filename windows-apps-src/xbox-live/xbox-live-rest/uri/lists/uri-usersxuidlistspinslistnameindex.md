---
title: /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
assetID: edcb19bd-87a5-732b-0c45-6f7355fc2dd1
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameindex.html
description: " /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b56b563c72c206340aa2c1ce9f73aa8dfe50809d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641227"
---
# <a name="usersxuidxuidlistspinslistnameindexindexinsertindexinsertindex"></a>/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
一覧内の項目に移動します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| XUID| string| ユーザーの XUID です。| 
| listname| string| 操作するリストの名前。| 
| インデックス| string| 移動するアイテムの現在のインデックスを指定します。 インデックス値が 0 または正の整数の場合は、これは、項目の現在のインデックスを呼び出しの要求本文を空にする必要があります。 ただし、インデックス値が「-1」の場合は、ItemId またはプロバイダー/ProviderID 呼び出しの要求本文内で移動する項目を指定してください。 | 
  
<a id="ID4EHC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[投稿](uri-usersxuidlistspinslistnameindexpost.md)

&nbsp;&nbsp;リストの項目を一覧内の別の位置に移動します。
 
<a id="ID4ERC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ETC"></a>

 
##### <a name="parent"></a>Parent 

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   