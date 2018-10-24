---
title: POST (/users/{ownerId}/people/xuids)
assetID: e20bfb58-9c3b-14ed-6462-85d42fa6fe1a
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuidspost.html
author: KevinAsgari
description: " POST (/users/{ownerId}/people/xuids)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 27fbc0e209439fca01cf1e7d8c7c3bf98c4b9053
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483534"
---
# <a name="post-usersowneridpeoplexuids"></a>POST (/users/{ownerId}/people/xuids)
呼び出し元のユーザーからコレクションの XUID のユーザーを取得します。 これらの Uri のドメインは、 `social.xboxlive.com`。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [Authorization](#ID4EJB)
  * [必要な要求ヘッダー](#ID4ERC)
  * [省略可能な要求ヘッダー](#ID4EBE)
  * [要求本文](#ID4EHF)
  * [HTTP ステータス ・ コード](#ID4EKH)
  * [必要な応答ヘッダー](#ID4ENBAC)
  * [応答本文](#ID4EZCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
投稿操作を使うと、1 回または複数回実行された場合は、同じ結果を生成これは、このリソースは変更されません。
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| ownerId| string| リソースにアクセスしているユーザーの識別子です。 認証済みのユーザーに一致する必要があります。 使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a>Authorization
 
| 型| 必須かどうか| 説明| 応答がない場合は、| 
| --- | --- | --- | --- | --- | --- | --- | 
| XUID| 必須| 呼び出し元には、ユーザーの Xbox ユーザー ID (XUID) があります。| 401 権限がありません。| 
  
<a id="ID4ERC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| [String]。 Xbox LIVE 用のデータを承認します。 これは、通常、暗号化された XSTS トークンです。 値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>。| 
| Content-Length| 32 ビット符号なし整数。 長さをバイト単位で要求の本体です。 値の例: 22 です。| 
| Content-Type| [String]。 要求の本体の MIME の種類です。 <b>アプリケーションと json</b>でなければなりません。| 
  
<a id="ID4EBE"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| Xbox LIVE サービスは、この要求を送信するのには、名または番号を作成します。 要求は、ヘッダー、認証トークンなどの要求の妥当性を確認した後、そのサービスにのみルーティングされます。既定値: 1。| 
| Accept| [String]。 コンテンツ タイプの応答で呼び出し元を受け入れる。 すべての応答は、<b>アプリケーションまたは json</b>です。| 
  
<a id="ID4EHF"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4ENF"></a>

 
### <a name="required-members"></a>必要なメンバー
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| XuidList| 呼び出し元のユーザーのコレクションから返されるユーザーを識別する Xuid の配列です。 [XuidList (JSON)](../../json/json-xuidlist.md)を参照してください。| 
  
<a id="ID4EKG"></a>

 
### <a name="optional-members"></a>省略可能なメンバー
 
この要求に対して省略可能なメンバーはありません。
  
<a id="ID4EVG"></a>

 
### <a name="prohibited-members"></a>禁止されているメンバー
 
要求では、他のすべてのメンバーは禁止されています。
  
<a id="ID4EAH"></a>

 
### <a name="sample-request"></a>要求のサンプル
 

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

 
## <a name="http-status-codes"></a>HTTP ステータス ・ コード
 
サービスは、このリソースにこのメソッドを使用して行われた要求への応答では、このセクションのステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧については、[標準的な HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| "Get"メソッドは、するときに成功します。| 
| 204| コンテンツはありません。| 成功がメソッドの追加] または [削除] します。| 
| 400| 要求が正しくありません。| メソッドのパラメーターが指定されてないか、または形式が正しくない、またはユーザー Id の形式が正しくありませんでした。| 
| 403| Forbidden| 承認ヘッダーの XUID の要求を解析できませんでした。| 
  
<a id="ID4ENBAC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-Length| 32 ビット符号なし整数| 長さをバイト単位で、応答の本体です。 値の例: 22 です。| 
| Content-Type| string| 応答本体の MIME の種類です。 常に<b>アプリケーションまたは json</b>になります。| 
  
<a id="ID4EZCAC"></a>

 
## <a name="response-body"></a>応答本文
 
応答の本体は、"get"要求のメソッドは、ときにのみ送信されます。 追加] または [削除] の応答の本体がありません。
 
"Get"メソッドの呼び出しが成功した場合は、サービスはコレクション、および呼び出し元のユーザーのコレクションを格納した配列、呼び出し元のユーザーにユーザーの合計数を返します。 メソッドの追加] および [削除] の応答は返されません。 [PeopleList (JSON)](../../json/json-peoplelist.md)を参照してください。
 
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

   