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
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9045453"
---
# <a name="standard-http-request-and-response-headers"></a>標準の HTTP 要求および応答ヘッダー
 
<a id="ID4ES"></a>

 
## <a name="request-headers"></a>要求ヘッダー
 
次の表では、Xbox Live サービス要求を作成するときに使用される標準の HTTP ヘッダーを示します。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | 
| x xbl コントラクト バージョン| 1| API コントラクト バージョンです。 すべての Xbox Live サービス要求に必要です。| 
| Authorization| STSTokenString| STS 認証トークンです。 このヘッダーの値は、 <b>GetTokenAndSignatureResult.Token</b>プロパティから取得されます。 | 
| Content-Type| アプリケーション/xml、アプリケーション/json、マルチパート/フォーム データまたはアプリケーション/x-。-form-urlencoded| 要求で送信されているコンテンツの種類を指定します。| 
| Content-Length| 整数値| POST 要求で送信されたデータの長さを指定します。| 
| 同意言語 | String| 返される任意の文字列をローカライズする方法を指定します。 有効な言語/ロケールの組み合わせの一覧については、 <a href="https://msdn.microsoft.com/en-us/library/bb975829.aspx">Xbox 360 プログラミングの詳細</a>を参照してください。| 
  
<a id="ID4E6C"></a>

 
## <a name="response-headers"></a>応答ヘッダー
 
次の表では、Xbox Live サービスの応答で使用される標準の HTTP ヘッダーを示します。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Content-Type| アプリケーション/xml、アプリケーション/json| 返されるコンテンツの種類を指定します。| 
| Content-Length| 整数値| 返されるデータの長さを指定します。| 
  
<a id="ID4EEE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

   