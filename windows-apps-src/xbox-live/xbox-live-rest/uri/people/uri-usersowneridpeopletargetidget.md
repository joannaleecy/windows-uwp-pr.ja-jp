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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632677"
---
# <a name="get-usersowneridpeopletargetid"></a>GET (/users/{ownerId}/people/{targetid})
呼び出し元のユーザーのコレクションからターゲットの ID でユーザーを取得します。 これらの Uri のドメインが`social.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [承認](#ID4EJB)
  * [必要な要求ヘッダー](#ID4ERC)
  * [省略可能な要求ヘッダー](#ID4EQD)
  * [要求本文](#ID4EWE)
  * [HTTP 状態コード](#ID4EBF)
  * [必要な応答ヘッダー](#ID4EDH)
  * [応答本文](#ID4EQAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
GET 操作は、この 1 回または複数回実行された場合、同じ結果が生成されますのですべてのリソースを変更しません。
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| ownerId| string| リソースがアクセスされているユーザーの識別子。 認証されたユーザーに一致する必要があります。 使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。| 
| targetid| string| 所有者の連絡先リスト、Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからデータを取得するユーザーの識別子。 値の例: xuid(2603643534573581)、gt(SomeGamertag) します。| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a>Authorization
 
| 種類| 必須| 説明| 不足している場合の応答| 
| --- | --- | --- | --- | --- | --- | --- | 
| XUID| ○| 呼び出し元が、ユーザーの Xbox ユーザー ID (XUID)。| 401 許可されていません| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| [String]。 Xbox LIVE の承認データです。 これは、通常、暗号化された XSTS トークンです。 値の例:<b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。| 
  
<a id="ID4EQD"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. | 
| OK| [String]。 コンテンツ タイプを呼び出し元が応答で受け取る。 すべての応答は<b>、application/json</b>します。| 
  
<a id="ID4EWE"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EBF"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| 成功しました。| 
| 400| 要求が正しくありません| ユーザー Id は、形式が正しくありませんでした。| 
| 403| Forbidden| Authorization ヘッダーから XUID 要求を解析できませんでした。| 
| 404| 検出不可| ターゲット ユーザーは、所有者のユーザー の一覧で見つかりませんでした。| 
  
<a id="ID4EDH"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-Length| 32 ビット符号なし整数| 長さをバイト単位で、応答本文。 値の例:22.| 
| Content-Type| string| 応答本文の MIME の種類。 常に<b>、application/json</b>します。| 
  
<a id="ID4EQAAC"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合、サービスは、ターゲット ユーザーを返します。 参照してください[人 (JSON)](../../json/json-person.md)します。
 
<a id="ID4E3AAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

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

   