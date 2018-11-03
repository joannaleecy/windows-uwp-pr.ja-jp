---
title: TitleBlob (JSON)
assetID: fd1c904d-e8d0-f61f-e403-40b25bd4ac14
permalink: en-us/docs/xboxlive/rest/json-titleblob.html
author: KevinAsgari
description: " TitleBlob (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a6ed09f078be5c7063d00d35d3bc3749f791d042
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5970804"
---
# <a name="titleblob-json"></a>TitleBlob (JSON)
記憶域のタイトルに関する情報が含まれています。 
<a id="ID4EP"></a>

 
## <a name="titleblob"></a>TitleBlob
 
TitleBlob オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| clientFileTime| DateTime| [オプション]ファイルの最後のアップロードの日時。| 
| displayName| string| [オプション]ユーザーに表示されているファイルの名前。| 
| etag| string| タグで使用するファイルをダウンロードし、要求をアップロードします。| 
| fileName| string| ファイルの名前です。| 
| size| 64 ビットの符号付き整数| ファイルのバイトのサイズ。| 
| smartBlobType| string| [オプション]データの種類です。 使用可能な値: config、json、バイナリします。| 
  
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

   