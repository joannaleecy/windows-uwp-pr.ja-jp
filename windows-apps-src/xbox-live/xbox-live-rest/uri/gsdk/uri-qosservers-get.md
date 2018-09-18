---
title: GET (/qosservers)
assetID: 8b940c1b-947c-eab3-78ed-4384f57ea0bd
permalink: en-us/docs/xboxlive/rest/uri-qosservers-get.html
author: KevinAsgari
description: " GET (/qosservers)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 71a4787bf6b139d1a638ec783c0293d70a8ee239
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4016363"
---
# <a name="get-qosservers"></a>GET (/qosservers)
URI が利用可能な QoS サーバーの一覧を取得する Xbox Live エンジンで使用するためにクライアントによって呼び出されます。 これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
  * [必要な要求ヘッダー](#ID4EBB)
  * [必要な応答ヘッダー](#ID4EUC)
  * [応答本文](#ID4EVD)
 
<a id="ID5EG"></a>

 
## <a name="host-name"></a>ホスト名

gameserverds.xboxlive.com
 
<a id="ID4EBB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
要求を行う場合、次の表に示すようにヘッダーは必要です。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | 
| Content-Type| application/json| 送信されたデータの種類です。| 
| Host| gameserverds.xboxlive.com|  | 
| Content-Length|  | 要求オブジェクトの長さ。| 
| x xbl コントラクト バージョン| 1| API コントラクト バージョンです。| 
  
<a id="ID4EUC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
応答は常に、次の表に示すようにヘッダーを含めます。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Content-Type| application/json| 応答本文内のデータの種類です。| 
| Content-Length|  | 応答本文の長さ。| 
  
<a id="ID4EVD"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| qosservers| サーバー情報の配列です。| 
| serverFqdn| サーバーの完全修飾ドメイン名。| 
| serverSecureDeviceAddress| サーバーのセキュア デバイス アドレス。| 
| targetLocation| サーバーの地理的な場所です。| 
 
<a id="ID4EUE"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{ 
  "qosServers" : 
  [ 
    { "serverFqdn" : "xblqosncus.cloudapp.net", "serverSecureDeviceAddress" : "&lt;base-64 encoded blob>", "targetLocation" : "North Central US" },
    { "serverFqdn" : "xblqoswus.cloudapp.net", "serverSecureDeviceAddress" : "&lt;base-64 encoded blob>", "targetLocation" : "West US" },
  ]
}

      
```

   
<a id="ID4EBF"></a>

 
## <a name="see-also"></a>関連項目
 [/qosservers](uri-qosservers.md)

  