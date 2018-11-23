---
title: 標準の HTTP 要求および応答ヘッダー
assetID: a5f8fd96-9393-5234-04ad-837e5c117c92
permalink: en-us/docs/xboxlive/rest/httpstandardheaders.html
author: KevinAsgari
description: " 標準の HTTP 要求および応答ヘッダー"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b1d86a870e32457b903053c7a8c3b1d722c9c559
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7566804"
---
# <a name="standard-http-request-and-response-headers"></a>標準の HTTP 要求および応答ヘッダー
 
<a id="ID4ES"></a>

 
## <a name="request-headers"></a>要求ヘッダー
 
次の表では、Xbox Live サービス要求を行うときに使用する標準的な HTTP ヘッダーを示します。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | 
| x xbl コントラクト バージョン| 1| API コントラクト バージョンです。 Xbox Live サービスのすべての要求に必要です。| 
| Authorization| STSTokenString| STS 認証トークン。 このヘッダーの値は、 <b>GetTokenAndSignatureResult.Token</b>プロパティから取得されます。 | 
| Content-Type| アプリケーション/xml、アプリケーション/json、マルチパート/フォーム データまたはアプリケーション/x-。-form-urlencoded| 要求が送信されているコンテンツの種類を指定します。| 
| Content-Length| 整数値| POST 要求で送信されたデータの長さを指定します。| 
| 同意言語 | String| 返される任意の文字列をローカライズする方法を指定します。 有効な言語/ロケールの組み合わせの一覧については、<a href="http://msdn.microsoft.com/en-us/library/bb975829.aspx">高度な Xbox 360 のプログラミング</a>を参照してください。| 
  
<a id="ID4E6C"></a>

 
## <a name="response-headers"></a>応答ヘッダー
 
次の表では、Xbox Live サービスの応答で使用される標準の HTTP ヘッダーを示します。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Content-Type| アプリケーション xml/アプリケーション/json| 返されるコンテンツの種類を指定します。| 
| Content-Length| 整数値| 返されるデータの長さを指定します。| 
  
<a id="ID4EEE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

   