---
title: TitleBlob (JSON)
assetID: fd1c904d-e8d0-f61f-e403-40b25bd4ac14
permalink: en-us/docs/xboxlive/rest/json-titleblob.html
description: " TitleBlob (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 51a0b17a46d1c71ffdf9098d4637ca59d840c90a
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8889944"
---
# <a name="titleblob-json"></a>TitleBlob (JSON)
記憶域からのタイトルに関する情報が含まれています。 
<a id="ID4EP"></a>

 
## <a name="titleblob"></a>TitleBlob
 
TitleBlob オブジェクトには、次仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| clientFileTime| DateTime| [オプション]ファイルの最後のアップロードの日時。| 
| displayName| string| [オプション]ユーザーに表示されているファイルの名前。| 
| etag| string| タグで使用されるファイルをダウンロードして要求をアップロードします。| 
| fileName| string| ファイルの名前。| 
| size| 64 ビットの符号付き整数| ファイルのバイトのサイズ。| 
| smartBlobType| string| [オプション]データの種類です。 使用可能な値: config、json、バイナリ。| 
  
<a id="ID4E6C"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
    "fileName":"foo\bar\blob.txt,binary",
    "clientFileTime":"2012-01-01T01:02:03.1234567Z",
    "displayName":"Friendly Name",
    "size":12,
    "etag":"0x8CEB3E4F8F3A5BF",
    "smartBlobType":"binary"
}
      
```

  
<a id="ID4EID"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EKD"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   