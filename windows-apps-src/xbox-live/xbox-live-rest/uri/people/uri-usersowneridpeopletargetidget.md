---
title: GET (/users/{ownerId}/people/{targetid})
assetID: 2fd37b8e-b886-14f2-3399-59f530d85e4e
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopletargetidget.html
description: " GET (/users/{ownerId}/people/{targetid})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 408b4df30f53e27b04e2a1e654e9686d2b359637
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8751341"
---
# <a name="get-usersowneridpeopletargetid"></a>GET (/users/{ownerId}/people/{targetid})
呼び出し元のユーザーのコレクションからターゲット ID でユーザーを取得します。 これらの Uri のドメインが`social.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [Authorization](#ID4EJB)
  * [必要な要求ヘッダー](#ID4ERC)
  * [オプションの要求ヘッダー](#ID4EQD)
  * [要求本文](#ID4EWE)
  * [HTTP ステータス コード](#ID4EBF)
  * [必要な応答ヘッダー](#ID4EDH)
  * [応答本文](#ID4EQAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
これと同じ結果に 1 回または複数回実行している場合、GET 操作はすべてのリソースを変更しません。
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| ownerId| string| そのリソースにアクセスしているユーザーの識別子です。 認証されたユーザーに一致する必要があります。 設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。| 
| targetid| string| 所有者のユーザーのリストが Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからのデータを取得するユーザーの識別子です。 値の例: xuid(2603643534573581)、gt(SomeGamertag) します。| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a>Authorization
 
| 型| 必須かどうか| 説明| 不足している場合、応答| 
| --- | --- | --- | --- | --- | --- | --- | 
| XUID| 必須| 呼び出し元が、ユーザーの Xbox ユーザー ID (XUID)。| 401 承認されていません。| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| [String]。 Xbox LIVE のデータを承認します。 これは、通常、暗号化された XSTS トークンです。 値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。| 
  
<a id="ID4EQD"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。| 
| Accept| [String]。 コンテンツ タイプを呼び出し元が応答で受け取る。 すべての応答は、<b>アプリケーション/json</b>です。| 
  
<a id="ID4EWE"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EBF"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| 成功します。| 
| 400| Bad Request| ユーザー Id が正しくありませんでした。| 
| 403| Forbidden| 承認ヘッダーから XUID クレームを解析できませんでした。| 
| 404| Not Found します。| 対象ユーザーが所有者の People リストに見つかりませんでした。| 
  
<a id="ID4EDH"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-Length| 32 ビットの符号なし整数| バイト単位の長さ、応答本文。 値の例: 22 します。| 
| Content-Type| string| 応答本文の MIME タイプ。 これにより、<b>アプリケーション/json</b>は常になります。| 
  
<a id="ID4EQAAC"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合は、サービスは、対象のユーザーを返します。 [Person (JSON)](../../json/json-person.md)を参照してください。
 
<a id="ID4E3AAC"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{
    "xuid": "2603643534573581",
    "isFavorite": false,
    "isFollowingCaller": false,
    "socialNetworks": ["LegacyXboxLive"]
}
         
```

   
<a id="ID4EGBAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIBAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/{ownerId}/people/{targetid}](uri-usersowneridpeopletargetid.md)

   