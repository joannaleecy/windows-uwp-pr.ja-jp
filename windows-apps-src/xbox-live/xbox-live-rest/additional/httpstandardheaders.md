---
title: 標準の HTTP 要求および応答ヘッダー
assetID: a5f8fd96-9393-5234-04ad-837e5c117c92
permalink: en-us/docs/xboxlive/rest/httpstandardheaders.html
description: " 標準の HTTP 要求および応答ヘッダー"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ca97e82365eab40266b3ffdd84924f71289eede6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57636517"
---
# <a name="standard-http-request-and-response-headers"></a>標準の HTTP 要求および応答ヘッダー
 
<a id="ID4ES"></a>

 
## <a name="request-headers"></a>要求ヘッダー
 
次の表では、Xbox Live サービスを要求する場合に使用する標準 HTTP ヘッダーを示します。
 
| Header| Value| 説明| 
| --- | --- | --- | 
| x-xbl-contract-version| 1| API コントラクトのバージョン。 すべての Xbox Live サービス要求に必要です。| 
| Authorization| STSTokenString| STS の認証トークンです。 このヘッダーの値を取得してから、 <b>GetTokenAndSignatureResult.Token</b>プロパティ。 | 
| Content-Type| application/xml、application/json、マルチパート/フォーム データやアプリケーション/x-www-form-urlencoded| 要求と共に送信されるコンテンツの種類を指定します。| 
| Content-Length| 整数値| POST 要求で送信されるデータの長さを指定します。| 
| Accept Language | String| 返される任意の文字列をローカライズする方法を指定します。 参照してください<a href="https://msdn.microsoft.com/en-us/library/bb975829.aspx">Xbox 360 のプログラミングの高度な</a>言語/ロケールの有効な組み合わせの一覧についてはします。| 
  
<a id="ID4E6C"></a>

 
## <a name="response-headers"></a>応答ヘッダー
 
次の表では、Xbox Live サービスの応答で使用される標準の HTTP ヘッダーを示します。
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Content-Type| application/xml, application/json| 返されるコンテンツの種類を指定します。| 
| Content-Length| 整数値| 返されるデータの長さを指定します。| 
  
<a id="ID4EEE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)

   