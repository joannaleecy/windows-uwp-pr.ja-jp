---
title: POST (/titles/{Title Id}/sessionhosts)
assetID: 8558b336-1af9-8143-9752-477ceb3a8e4e
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionhosts-post.html
author: KevinAsgari
description: " POST (/titles/{Title Id}/sessionhosts)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 147df5a3032aa950b7b301f7990c5456db200d2c
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4205787"
---
# <a name="post-titlestitle-idsessionhosts"></a>POST (/titles/{Title Id}/sessionhosts)
新しいクラスターの要求を作成します。 これらの Uri のドメインが`gameserverms.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [必要な要求ヘッダー](#ID4EGB)
  * [要求本文](#ID4E5B)
  * [必要な応答ヘッダー](#ID4ELD)
  * [応答本文](#ID4ESD)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 説明| 
| --- | --- | 
| titleId| 要求の操作のタイトルの ID です。| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a>ホスト名

gameserverms.xboxlive.com
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
要求を行う場合、次の表に示すようにヘッダーは必要です。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | 
| Content-Type| application/json| 送信されたデータの種類です。| 
  
<a id="ID4E5B"></a>

 
## <a name="request-body"></a>要求本文
 
要求は、次のメンバーを含む JSON オブジェクトを含める必要があります。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| sessionId| これは、指定した呼び出し元の識別子。 割り当てられ、返されるセッション ホストに割り当てられます。 後でこの識別子によって特定 sessionhost を参照できます。 グローバルに一意である必要があります (つまり GUID)。| 
| SandboxId| サンド ボックスで割り当てられるセッション ホストをします。| 
| cloudGameId| クラウド ゲームの識別子です。| 
| 場所| 優先する場所の順序指定された一覧から割り当てられるセッションたいです。| 
| sessionCookie| これは、呼び出し元が指定されている不透明な文字列です。 Sessionhost に関連付けられたし、ゲームのコードで参照できます。 このメンバーを使用して、クライアントから少量の情報を (最大サイズは 4 KB) サーバーに渡します。| 
| gameModelId| ゲーム モードの識別子です。| 
 
<a id="ID4EDD"></a>

 
### <a name="sample-request"></a>要求の例
 

```cpp
{
        "sessionId": "3536d3e6-e85d-4f47-b898-9617d19dabcd",
        "sandboxId": "ISST.0",
        "cloudGameId": "1b7f9925-369c-4301-b1f7-1125dce25776",
        "locations": [
        "West US",
        "East US",
        "West Europe"
        ],
        "sessionCookie": "Caller provided opaque string",
        "gameModeId": "2162d32c-7ac8-40e9-9b1f-56676b8b2513"
        }
      
```

   
<a id="ID4ELD"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
なし。
  
<a id="ID4ESD"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ホスト名| インスタンスのホスト名。| 
| portMappings| ポートのマッピングです。| 
| 地域| 地域のインスタンスがでホストされています。| 
| secureContext| セキュア デバイス アドレスです。| 
 
<a id="ID4ESE"></a>

 
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
        "region": "WestUS",
        "secureContext": "AQDc8Hen/QCDJwWRPcW/1QEEAiABAACdOJU8JNujcXyUPwUBCnue+g=="
        }
      
```

   
<a id="remarks"></a>

 
## <a name="remarks"></a>注釈
 
次の応答コードを受け取ったとき、タイトルはサービスへの呼び出しをのみ再試行する必要があります。
 
   * 200-成功の応答が返されます。
   * 400-無効なパラメーターまたは形式が正しくない要求本文。
   * 401: Unauthorized
   * 404-タイトル id を割り当てられているすべてのサブスクリプションはありません。
   * 409-この応答が可能な場合、同じ要求が同時にほぼで (同じ sessionId) に加えられたします。 セッションのホストが既に指定した sessionId しアクティブになって割り当て要求が行われた場合はその sessionhost に関する詳しい情報が返されます。 セッション ホストただしがない場合アクティブなは、まだ、競合が表示されます。
   * 500-予期しないサーバー エラー。
   * 503-なし sessionhosts StandingBy します。 これらのリソースの一部は無料ときは、要求を再試行します。
   
<a id="ID4EFG"></a>

 
## <a name="see-also"></a>関連項目
 [/titles/{titleId}/sessionhosts](uri-titlestitleidsessionhosts.md)

  