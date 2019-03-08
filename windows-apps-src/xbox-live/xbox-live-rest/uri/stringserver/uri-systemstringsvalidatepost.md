---
title: POST (/system/strings/validate)
assetID: 6a59bc0b-8edd-87bf-efaf-f16efa3bedf7
permalink: en-us/docs/xboxlive/rest/uri-systemstringsvalidatepost.html
description: " POST (/system/strings/validate)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 70e86567f449674c7a046e072437d9ee715dc6d6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57595507"
---
# <a name="post-systemstringsvalidate"></a>POST (/system/strings/validate)
検証のための文字列の配列を受け取り、等しいサイズの結果の配列を返します。 これらの Uri のドメインが`client-strings.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [必要な要求ヘッダー](#ID4EIB)
  * [要求本文](#ID4ELC)
  * [HTTP 状態コード](#ID4E4C)
  * [応答本文](#ID4ETF)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
各結果は、対応する文字列が Xbox LIVE では容認でき、該当する場合は、問題のある文字列を含むかどうかを示します。
 
同じ文字列が常に同じ結果になります。 非成功の結果を受信する場合は、結果を分析し、それに応じて、文字列を変更します。
 
 

> [!NOTE] 
> 結果の<b>VerifyStringResult</b>文字列の最初の問題のある単語をレポートのみになります。 ある可能性があります、文字列内での問題のある追加します。 文字列を使用できるようにする問題のある単語を置換する場合は、問題のある単語または部分文字列の置換、追加の問題が発生した部分文字列を検索する文字列を再検証してください。  

 
  
<a id="ID4EIB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | 
| Authorization| 認証トークンです。 以下に例を示します。XBL3.0 x = [ハッシュ] です。[トークン] です。| 
| x-xbl-contract-version| 整数 API コントラクトのバージョン。 この api は、1 または 2 を指定する必要があります。| 
  
<a id="ID4ELC"></a>

 
## <a name="request-body"></a>要求本文
 
要求本文は、文字列、配列のサイズに制限はありませんし、文字列あたり 512 文字の配列です。
 
<a id="ID4ETC"></a>

 
### <a name="sample-request"></a>要求のサンプル
 

```cpp
{
    "stringstoVerify":
    [
        "Poppycock",
        "The quick brown fox jumped over the lazy dog.",
        "Hey, want to hang out?",
        "oh noes"
    ]
}
      
```

   
<a id="ID4E4C"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 200| OK| すべての文字列が正常に処理されました。 これは必ずしもすべての文字列には、正の値の Hresult が必要があります。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。| 
| 406| Not Acceptable| 不足している<b>コンテンツの種類: アプリケーション/json</b>ヘッダー。| 
| 408| 要求のタイムアウト| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
  
<a id="ID4ETF"></a>

 
## <a name="response-body"></a>応答本文
 
配列を返します[VerifyStringResult (JSON)](../../json/json-verifystringresult.md)要求の配列と同じサイズの。
  
<a id="ID4EAG"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ECG"></a>

 
##### <a name="parent"></a>Parent 

[/system/strings/validate](uri-systemstringsvalidate.md)

   