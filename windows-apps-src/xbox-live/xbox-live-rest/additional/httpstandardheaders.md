---
title: 標準の HTTP 要求および応答ヘッダー
assetID: a5f8fd96-9393-5234-04ad-837e5c117c92
permalink: en-us/docs/xboxlive/rest/httpstandardheaders.html
author: KevinAsgari
description: " 標準の HTTP 要求および応答ヘッダー"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 31499f8d6fa41d888afd84bea64f7f9de0585b96
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4507907"
---
# <a name="standard-http-request-and-response-headers"></a>標準の HTTP 要求および応答ヘッダー
 
<a id="ID4ES"></a>

 
## <a name="request-headers"></a>要求ヘッダー
 
次の表は、Xbox Live サービス要求を作成するときに使用する標準的な HTTP ヘッダーを示します。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | 
| x xbl コントラクト バージョン| 1| API コントラクト バージョンです。 Xbox Live サービスのすべての要求に必要です。| 
| Authorization| STSTokenString| STS 認証トークンです。 このヘッダーの値は、 <b>GetTokenAndSignatureResult.Token</b>プロパティから取得されます。 | 
| Content-Type| アプリケーション/xml、アプリケーション/json、マルチパート/フォーム データまたはアプリケーション/x-www-form-urlencoded| 要求で送信されているコンテンツの種類を指定します。| 
| Content-Length| 整数値| POST 要求で送信されたデータの長さを指定します。| 
| 受け入れる言語 | String| 返される任意の文字列をローカライズする方法を指定します。 有効な言語/ロケールの組み合わせの一覧については、 <a href="http://msdn.microsoft.com/en-us/library/bb975829.aspx">Xbox 360 プログラミングの詳細</a>を参照してください。| 
  
<a id="ID4E6C"></a>

 
## <a name="response-headers"></a>応答ヘッダー
 
次の表は、Xbox Live サービスの応答で使用される標準の HTTP ヘッダーを示します。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Content-Type| アプリケーション/xml、アプリケーション/json| 返されるコンテンツの種類を指定します。| 
| Content-Length| 整数値| 返されるデータの長さを指定します。| 
  
<a id="ID4EEE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

   