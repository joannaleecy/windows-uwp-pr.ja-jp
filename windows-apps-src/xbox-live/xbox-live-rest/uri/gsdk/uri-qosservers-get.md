---
title: GET (/qosservers)
assetID: 8b940c1b-947c-eab3-78ed-4384f57ea0bd
permalink: en-us/docs/xboxlive/rest/uri-qosservers-get.html
description: " GET (/qosservers)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 02d24dbf1d189b759784dbbfa7052e2c218ec27e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632067"
---
# <a name="get-qosservers"></a>GET (/qosservers)
Xbox Live コンピューティングで使用するために使用できる QoS サーバーの一覧を取得するクライアントから呼び出す URI。 これらの Uri のドメインが`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
  * [必要な要求ヘッダー](#ID4EBB)
  * [必要な応答ヘッダー](#ID4EUC)
  * [応答本文](#ID4EVD)
 
<a id="ID5EG"></a>

 
## <a name="host-name"></a>ホスト名

gameserverds.xboxlive.com
 
<a id="ID4EBB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
要求を行う場合は、次の表に示されているヘッダーが必要です。
 
| Header| Value| 説明| 
| --- | --- | --- | 
| Content-Type| application/json| 送信されるデータの型。| 
| Host| gameserverds.xboxlive.com|  | 
| Content-Length|  | 要求オブジェクトの長さ。| 
| x-xbl-contract-version| 1| API コントラクトのバージョン。| 
  
<a id="ID4EUC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
応答には、常に、次の表に示すようにヘッダーが含まれます。
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Content-Type| application/json| 応答本文でデータの型。| 
| Content-Length|  | 応答本文の長さ。| 
  
<a id="ID4EVD"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合、サービスは、次のメンバーを持つ JSON オブジェクトを返します。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| qosservers| サーバー情報の配列。| 
| serverFqdn| サーバーの完全修飾ドメイン名。| 
| serverSecureDeviceAddress| サーバーのセキュリティで保護されたデバイスのアドレス。| 
| TargetLocation| サーバーの地理的な場所。| 
 
<a id="ID4EUE"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

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

  