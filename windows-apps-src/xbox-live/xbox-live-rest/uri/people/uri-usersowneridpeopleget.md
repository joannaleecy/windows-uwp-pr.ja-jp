---
title: GET (/users/{ownerId}/people)
assetID: c948d031-ec19-7571-31ef-23cb9c5ebfaf
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopleget.html
description: " GET (/users/{ownerId}/people)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6c8672188a93b2e8d27a081ae068387e7ee7aa42
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623767"
---
# <a name="get-usersowneridpeople"></a>GET (/users/{ownerId}/people)
呼び出し元のユーザー コレクションを取得します。
これらの Uri のドメインが`social.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [クエリ文字列パラメーター](#ID4EJB)
  * [承認](#ID4ERD)
  * [必要な要求ヘッダー](#ID4EZE)
  * [省略可能な要求ヘッダー](#ID4EYF)
  * [要求本文](#ID4E5G)
  * [HTTP 状態コード](#ID4EJH)
  * [必要な応答ヘッダー](#ID4EBBAC)
  * [応答本文](#ID4ENCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

GET 操作は、この 1 回または複数回実行された場合、同じ結果が生成されますのですべてのリソースを変更しません。

<a id="ID4E5"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| ownerId| string| リソースがアクセスされているユーザーの識別子。 認証されたユーザーに一致する必要があります。 使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。|

<a id="ID4EJB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- | --- |
| 表示| string| ビューに関連付けられているユーザーを返します。 既定値は、"all"です。 設定できる値は次のとおりです。 <ul><li><b>すべて</b>-ユーザーの連絡先リスト上のすべてのユーザーを返します。 これが既定値です。</li><li><b>お気に入り</b>-お気に入りの属性を持っているユーザーの連絡先リスト上のすべてのユーザーを返します。</li><li><b>LegacyXboxLiveFriends</b> -従来の Xbox LIVE フレンドでもあるユーザーの連絡先リスト上のすべてのユーザーを返します。</li></br>**注:** のみ、**すべて**呼び出し元のユーザーが所有しているユーザーと異なる場合、値はサポートされています。|
| startIndex| 32 ビット符号なし整数| 指定したインデックスから始まるアイテムを返します。  
| maxItems| 32 ビット符号なし整数| 開始インデックス位置からコレクションから返されるユーザーの最大数。 場合、サービスは、既定値を指定可能性があります<b>maxItems</b>が存在しないより少ないを返すことが<b>maxItems</b> (結果の最後のページはまだ返送されていない) 場合でもです。|

<a id="ID4ERD"></a>


## <a name="authorization"></a>Authorization

| 種類| 必須| 説明| 不足している場合の応答|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| XUID| ○| 呼び出し元が、ユーザーの Xbox ユーザー ID (XUID)。| 401 許可されていません|

<a id="ID4EZE"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| [String]。 Xbox LIVE の承認データです。 これは、通常、暗号化された XSTS トークンです。 値の例:<b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。|

<a id="ID4EYF"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| Header| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. |
| OK| [String]。 コンテンツ タイプを呼び出し元が応答で受け取る。 すべての応答は<b>、application/json</b>します。|

<a id="ID4E5G"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EJH"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| 成功しました。|
| 400| 要求が正しくありません| クエリ パラメーターまたはユーザー Id は、形式が正しくありませんでした。|
| 403| Forbidden| Authorization ヘッダーから XUID 要求を解析できませんでした。|

<a id="ID4EBBAC"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Length| 32 ビット符号なし整数| 長さをバイト単位で、応答本文。 値の例:22.|
| Content-Type| string| 応答本文の MIME の種類。 常に<b>、application/json</b>します。|

<a id="ID4ENCAC"></a>


## <a name="response-body"></a>応答本文

呼び出しが成功した場合、サービスは、呼び出し元のユーザーのコレクション、および呼び出し元のユーザー コレクションを格納する配列内のユーザーの合計数を返します。 参照してください[PeopleList (JSON)](../../json/json-peoplelist.md)します。

<a id="ID4EZCAC"></a>


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
            "isFollowingCaller": false,
            "isFavorite": false
        },
    ],
    "totalCount": 3
}

```


<a id="ID4EDDAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EFDAC"></a>


##### <a name="parent"></a>Parent

[/users/{ownerId}/people](uri-usersowneridpeople.md)
