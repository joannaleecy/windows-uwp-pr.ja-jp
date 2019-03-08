---
title: POST (/titles/{Title Id}/sessionhosts)
assetID: 8558b336-1af9-8143-9752-477ceb3a8e4e
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionhosts-post.html
description: " POST (/titles/{Title Id}/sessionhosts)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 47e3ecbf0a519b92ae467199e5d454523864310a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655147"
---
# <a name="post-titlestitle-idsessionhosts"></a>POST (/titles/{Title Id}/sessionhosts)
クラスターの新しい要求を作成します。 これらの Uri のドメインが`gameserverms.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [必要な要求ヘッダー](#ID4EGB)
  * [要求本文](#ID4E5B)
  * [必要な応答ヘッダー](#ID4ELD)
  * [応答本文](#ID4ESD)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 説明| 
| --- | --- | 
| titleId| 要求の操作対象のタイトルの ID。| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a>ホスト名

gameserverms.xboxlive.com
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
要求を行う場合は、次の表に示されているヘッダーが必要です。
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | 
| Content-Type| application/json| 送信されるデータの型。| 
  
<a id="ID4E5B"></a>

 
## <a name="request-body"></a>要求本文
 
要求には、次のメンバーを持つ JSON オブジェクトを含める必要があります。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| sessionId| これは、指定された呼び出し元の識別子。 割り当てられているされ、返されるセッション ホストに割り当てられます。 後でこの識別子を使用して特定 sessionhost を参照することができます。 グローバルに一意である必要があります (つまり GUID)。| 
| sandboxId| サンド ボックスで割り当てられるセッション ホストしたいです。| 
| cloudGameId| クラウド ゲームの識別子です。| 
| 場所| 優先する場所の順序付きリストから割り当てられるセッションたいです。| 
| sessionCookie| これは、呼び出し元が指定された非透過の文字列。 関連付けられた、sessionhost と、ゲームのコードで参照できます。 このメンバーを使用して、少量の情報をクライアントから (最大サイズは 4 KB) のサーバーに渡します。| 
| gameModelId| ゲーム モードの識別子です。| 
 
<a id="ID4EDD"></a>

 
### <a name="sample-request"></a>要求のサンプル
 

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
 
呼び出しが成功した場合、サービスは、次のメンバーを持つ JSON オブジェクトを返します。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ホスト名| インスタンスのホスト名。| 
| portMappings| ポートのマッピング。| 
| リージョン| リージョン、インスタンスがホストされます。| 
| secureContext| セキュリティで保護されたデバイスのアドレス。| 
 
<a id="ID4ESE"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

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
 
タイトルがサービスへの呼び出しを再試行する必要がありますは、次の応答コードが受信したときにのみ。
 
   * 200: 成功の応答が返されます。
   * 400-無効なパラメーターまたは形式が正しくない要求の本文。
   * 401-権限がありません
   * 404-タイトル id はそれに割り当てられているすべてのサブスクリプションにありません。
   * 409 — この応答は同じ要求には、ほぼ同時に (同じ sessionId) が終わったら、します。 場合は、割り当て要求が行われ、セッション ホストが既に指定したセッション Id が既にアクティブには、その sessionhost に関する詳細情報が返されます。 セッション ホストがない場合アクティブなは、まだ、競合が表示されます。
   * 500-予期しないサーバー エラー。
   * 503-ありません sessionhosts StandingBy します。 これらのリソースの一部は無料ときは、要求を再試行します。
   
<a id="ID4EFG"></a>

 
## <a name="see-also"></a>関連項目
 [/titles/{titleId}/sessionhosts](uri-titlestitleidsessionhosts.md)

  