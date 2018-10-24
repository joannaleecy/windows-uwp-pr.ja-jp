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
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483509"
---
# <a name="get-titlestitleidsessionssessionidallocationstatus"></a>GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)
そのセッション Id によって識別される sessionhost の割り当てを取得します。 これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`。
 
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
 
呼び出しが成功した場合、サービスは次のメンバーを含む JSON オブジェクトを返します。
 
| メンバー| 説明| 
| --- | --- | 
| description| 返します。 空の文字列を (左での下位互換性)。| 
| clusterId| 返します。 空の文字列を (左での下位互換性)。| 
| ホスト名| セッションのホストの URL です。| 
| status| キューに入れ、満たされると、または中止されたことを示します。| 
| sessionHostId| セッション ホストの id。| 
| セッション Id| 割り当て時に提供されているクライアント セッションの id。| 
| secureContext| セキュリティで保護されたデバイスのアドレスです。| 
| portMappings| インスタンスのポートのマッピングです。| 
| 地域| インスタンスの場所です。| 
| ticketId| (左内の下位互換性) 現在のセッション ID です。| 
| gameHostId| (左内の下位互換性) 現在の sessionHostId です。| 
 
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
 
タイトルがサービスへの呼び出しを再試行するは、次の応答コードを受信したときのみ。
 
   * 200-成功 
   * 400-要求には、無効なパラメーターが含まれています。 
   * 401-権限がありません 
   * 404-タイトル ID やチケットの ID が無効であるか、または見つかりません。 
   * 500: 予期しないサーバー エラーです。 
    