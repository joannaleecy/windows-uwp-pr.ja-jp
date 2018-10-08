---
title: TitleBlob (JSON)
assetID: fd1c904d-e8d0-f61f-e403-40b25bd4ac14
permalink: en-us/docs/xboxlive/rest/json-titleblob.html
author: KevinAsgari
description: " TitleBlob (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 91423df8367c275f40cd7f856a60070e1a46ad40
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4418895"
---
# <a name="titleblob-json"></a>TitleBlob (JSON)
記憶域からのタイトルに関する情報が含まれています。 
<a id="ID4EP"></a>

 
## <a name="titleblob"></a>TitleBlob
 
TitleBlob オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| clientFileTime| DateTime| [オプション]ファイルの最後のアップロードの日時。| 
| displayName| string| [オプション]ユーザーに表示されているファイルの名前。| 
| etag| string| タグで使用するファイルのダウンロードし、要求をアップロードします。| 
| fileName| string| ファイルの名前です。| 
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

   