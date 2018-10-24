---
title: GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)
assetID: 613ba53f-03cb-5ed3-a5ba-be59e5a146d1
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionssessionidallocationstatus-get.html
author: KevinAsgari
description: " GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1e351bed37e0761be1f884400f81a3da537967d2
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5439075"
---
# <a name="get-titlestitleidsessionssessionidallocationstatus"></a>GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)
その sessionId によって識別 sessionhost の割り当てを取得します。 これらの Uri のドメイン`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
  * [必要な要求ヘッダー](#ID4E4)
  * [必要な応答ヘッダー](#ID4EEB)
  * [応答本文](#ID4ELB)
 
<a id="ID4E4"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
なし。
  
<a id="ID4EEB"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
なし。
  
<a id="ID4ELB"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。
 
| メンバー| 説明| 
| --- | --- | 
| description| 空の文字列 (左での下位互換性) を返します。| 
| clusterId| 空の文字列 (左での下位互換性) を返します。| 
| ホスト名| セッション ホストの URL。| 
| status| キューに入れ、満たされると、または中止されたことを示します。| 
| sessionHostId| セッション ホストの id。| 
| sessionId| (割り当て時) に提供されるクライアント セッション id。| 
| secureContext| セキュア デバイス アドレスです。| 
| portMappings| インスタンスのポート マッピングします。| 
| 地域| インスタンスの場所です。| 
| ticketId| (左での下位互換性) の現在のセッション ID。| 
| gameHostId| (左での下位互換性) 現在 sessionHostId します。| 
 
<a id="ID4EGD"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{
        "hostName": "r111ybf4drgo12kq25tc-082yo7y9sz72f2odtq1ya5yhda-155169995-ncus.cloudapp.net",
        "portMappings": [
        {
        "Key": "GSDKTCPTest",
        "Value": {
        "internal": 10100,
        "external": 10103
        }
        },
        {
        "Key": "GSDKUDPTest",
        "Value": {
        "internal": 5000,
        "external": 5000
        }
        }
        ],
        "status",:"Fulfilled",
        "region": "WestUS",
        "secureContext": "AQDc8Hen/QCDJwWRPcW/1QEEAiABAACdOJU8JNujcXyUPwUBCnue+g==",
        "sessionId": "05328154-1bbe-4f5b-8caa-4e44106712f9",
        "description": "",
        "clusterId": "",
        "sessionHostId": "r111ybf4drgo12kq25tc-082yo7y9sz72f2odtq1ya5yhda-155169995-ncus.GSDKAgent_IN_0.0",
        "ticketId": "05328154-1bbe-4f5b-8caa-4e44106712f9",
        "gameHostId": "r111ybf4drgo12kq25tc-082yo7y9sz72f2odtq1ya5yhda-155169995-ncus.GSDKAgent_IN_0.0"

      
```

  
<a id="remarks"></a>

 
### <a name="remarks"></a>注釈
 
次の応答コードを受け取ったとき、タイトルはサービスへの呼び出しを再試行のみする必要があります。
 
   * 200、成功した場合 
   * 400-要求には、無効なパラメーターが含まれています。 
   * 401: Unauthorized 
   * 404-チケット ID、タイトル ID が無効であるか、または見つかりません。 
   * 500-予期しないサーバー エラー。 
    