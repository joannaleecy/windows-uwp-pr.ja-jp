---
title: POST (/users/{ownerId}/people/xuids)
assetID: e20bfb58-9c3b-14ed-6462-85d42fa6fe1a
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuidspost.html
author: KevinAsgari
description: " POST (/users/{ownerId}/people/xuids)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 91bcae367e42b3dc728b794d1e68550e86dcfeaa
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5764206"
---
# <a name="post-usersowneridpeoplexuids"></a>POST (/users/{ownerId}/people/xuids)
呼び出し元のユーザーからコレクションに対応する XUID によってユーザーを取得します。 これらの Uri のドメインが`social.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [Authorization](#ID4EJB)
  * [必要な要求ヘッダー](#ID4ERC)
  * [オプションの要求ヘッダー](#ID4EBE)
  * [要求本文](#ID4EHF)
  * [HTTP ステータス コード](#ID4EKH)
  * [必要な応答ヘッダー](#ID4ENBAC)
  * [応答本文](#ID4EZCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
POST ので、これと同じ結果に 1 回または複数回実行している場合、操作はすべてのリソースを変更しません。
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| ownerId| string| そのリソースにアクセスしているユーザーの識別子です。 認証されたユーザーに一致する必要があります。 可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。| 
  
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
| Content-Length| 32 ビットの符号なし整数。 、バイトで本文の長さを要求します。 値の例: 22 します。| 
| Content-Type| [String]。 要求本文の MIME タイプ。 これは、<b>アプリケーション/json</b>でなければなりません。| 
  
<a id="ID4EBE"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。| 
| Accept| [String]。 コンテンツ タイプを呼び出し元が応答で受け取る。 すべての応答は、<b>アプリケーション/json</b>です。| 
  
<a id="ID4EHF"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4ENF"></a>

 
### <a name="required-members"></a>必要なメンバー
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| XuidList| 呼び出し元のユーザーのコレクションから返される人を識別する Xuid の配列です。 [XuidList (JSON)](../../json/json-xuidlist.md)を参照してください。| 
  
<a id="ID4EKG"></a>

 
### <a name="optional-members"></a>省略可能なメンバー
 
この要求の省略可能なメンバーはありません。
  
<a id="ID4EVG"></a>

 
### <a name="prohibited-members"></a>禁止されているメンバー
 
要求では、その他のすべてのメンバーが禁止されています。
  
<a id="ID4EAH"></a>

 
### <a name="sample-request"></a>要求の例
 

```cpp
{
    "xuids": [
        "2533274790395904", 
        "2533274792986770", 
        "2533274794866999"
    ]
}
      
```

   
<a id="ID4EKH"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| メソッドは、「取得」するときに成功します。| 
| 204| No Content| 成功の方法が「追加」または「削除」します。| 
| 400| Bad Request| メソッドのパラメーターが不足しているか、正しくないか、ユーザー Id が正しくありません。| 
| 403| Forbidden| 承認ヘッダーから XUID クレームを解析できませんでした。| 
  
<a id="ID4ENBAC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-Length| 32 ビットの符号なし整数| バイト単位の長さ、応答本文。 値の例: 22 します。| 
| Content-Type| string| 応答本文の MIME タイプ。 これにより、<b>アプリケーション/json</b>は常になります。| 
  
<a id="ID4EZCAC"></a>

 
## <a name="response-body"></a>応答本文
 
応答本文は要求メソッドは、「取得」するときにのみ送信されます。 「追加」または「削除」の応答の本文はありません。
 
「取得」メソッドの呼び出しが成功した場合は、サービスはコレクション、および呼び出し元のユーザーのコレクションが含まれた配列で、呼び出し元のユーザーのユーザーの合計数を返します。 「追加」と「削除」メソッドの応答は返されません。 [PeopleList (JSON)](../../json/json-peoplelist.md)を参照してください。
 
<a id="ID4EHDAC"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{
    "people": [
        {
            "xuid": "2603643534573573",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573572",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573577",
            "isFavorite": false,
            "isFollowingCaller": false
        },
    ],
    "totalCount": 3
}
         
```

   
<a id="ID4ERDAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ETDAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/{ownerId}/people/xuids](uri-usersowneridpeoplexuids.md)

   