---
title: POST (/users/{ownerId}/people/xuids)
assetID: e20bfb58-9c3b-14ed-6462-85d42fa6fe1a
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuidspost.html
description: " POST (/users/{ownerId}/people/xuids)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1cb160f3276d215e3aba5dfd671c67fa17d883b5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589867"
---
# <a name="post-usersowneridpeoplexuids"></a>POST (/users/{ownerId}/people/xuids)
呼び出し元のユーザーからコレクションの XUID によってユーザーを取得します。 これらの Uri のドメインが`social.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [承認](#ID4EJB)
  * [必要な要求ヘッダー](#ID4ERC)
  * [省略可能な要求ヘッダー](#ID4EBE)
  * [要求本文](#ID4EHF)
  * [HTTP 状態コード](#ID4EKH)
  * [必要な応答ヘッダー](#ID4ENBAC)
  * [応答本文](#ID4EZCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
POST 操作はすべてのリソースを変更するはありませんので、この 1 回または複数回実行された場合、同じ結果が生成されます。
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| ownerId| string| リソースがアクセスされているユーザーの識別子。 認証されたユーザーに一致する必要があります。 使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。| 
  
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
| Content-Length| 32 ビット符号なし整数。 、(バイト単位)、要求本文の長さ。 値の例:22.| 
| Content-Type| [String]。 要求本文の MIME の種類。 これでなければなりません<b>、application/json</b>します。| 
  
<a id="ID4EBE"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. | 
| OK| [String]。 コンテンツ タイプを呼び出し元が応答で受け取る。 すべての応答は<b>、application/json</b>します。| 
  
<a id="ID4EHF"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4ENF"></a>

 
### <a name="required-members"></a>必須メンバー
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| XuidList| 呼び出し元のユーザーのコレクションから返されるユーザーを識別する Xuid の配列。 参照してください[XuidList (JSON)](../../json/json-xuidlist.md)します。| 
  
<a id="ID4EKG"></a>

 
### <a name="optional-members"></a>省略可能なメンバー
 
この要求のオプションのメンバーはありません。
  
<a id="ID4EVG"></a>

 
### <a name="prohibited-members"></a>禁止されているメンバー
 
要求では、その他のすべてのメンバーが禁止されています。
  
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

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| メソッドは"get"時に成功しました。| 
| 204| コンテンツはありません| 成功メソッドが「追加」または"remove"します。| 
| 400| 要求が正しくありません| メソッドのパラメーターがないか、形式が正しくない、またはユーザー Id が正しくありません。| 
| 403| Forbidden| Authorization ヘッダーから XUID 要求を解析できませんでした。| 
  
<a id="ID4ENBAC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-Length| 32 ビット符号なし整数| 長さをバイト単位で、応答本文。 値の例:22.| 
| Content-Type| string| 応答本文の MIME の種類。 常に<b>、application/json</b>します。| 
  
<a id="ID4EZCAC"></a>

 
## <a name="response-body"></a>応答本文
 
要求メソッドは"get"と応答本文はのみ送信されます。 「追加」または「削除」の応答本文はありません。
 
"Get"メソッドの呼び出しが成功した場合、サービスはコレクション、および呼び出し元のユーザー コレクションを格納する配列、呼び出し元のユーザーのユーザーの合計数を返します。 "Add"および"remove"メソッドの応答は返されません。 参照してください[PeopleList (JSON)](../../json/json-peoplelist.md)します。
 
<a id="ID4EHDAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

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

   