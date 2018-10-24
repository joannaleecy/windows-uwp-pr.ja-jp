---
title: GET (/users/{ownerId}/people)
assetID: c948d031-ec19-7571-31ef-23cb9c5ebfaf
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopleget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/people)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d08a8ff9e04b255944128ffc1cd1c0b101180d8f
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483515"
---
# <a name="get-usersowneridpeople"></a>GET (/users/{ownerId}/people)
呼び出し元のユーザーのコレクションを取得します。
これらの Uri のドメインは、 `social.xboxlive.com`。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [クエリ文字列パラメーター](#ID4EJB)
  * [Authorization](#ID4ERD)
  * [必要な要求ヘッダー](#ID4EZE)
  * [省略可能な要求ヘッダー](#ID4EYF)
  * [要求本文](#ID4E5G)
  * [HTTP ステータス ・ コード](#ID4EJH)
  * [必要な応答ヘッダー](#ID4EBBAC)
  * [応答本文](#ID4ENCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

GET 操作は、1 回または複数回実行された場合は、同じ結果を生成これは、すべてのリソースを変更しません。

<a id="ID4E5"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| ownerId| string| リソースにアクセスしているユーザーの識別子です。 認証済みのユーザーに一致する必要があります。 使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。|

<a id="ID4EJB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- | --- |
| 表示| string| ビューに関連付けられているユーザーが返されます。 既定値は、[すべて] です。 設定できる値は次のとおりです。 <ul><li><b>すべて</b>のユーザーのユーザー] の一覧で、すべてのユーザーを返します。 これは既定値です。</li><li><b>お気に入り</b>のお気に入りの属性を持っているユーザーのユーザー] ボックスの一覧で、すべてのユーザーを返します。</li><li><b>LegacyXboxLiveFriends</b> - は、従来の Xbox LIVE のフレンドでもあるユーザーのユーザー] ボックスの一覧のすべてのユーザーを返します。</li></br>**注:** 呼び出し元のユーザーが所有しているユーザーとは異なる場合、**すべて**の値のみがサポートされます。|
| startIndex| 32 ビット符号なし整数| 項目の指定したインデックスを開始位置を返します。  
| maxItems| 32 ビット符号なし整数| 開始インデックス位置からコレクションから取得するユーザーの最大数。 場合<b>maxItems</b>が存在しない場合があります<b>maxItems</b>よりも少ない (結果の最後のページが返されていない) 場合でも、サービスは既定値を指定ことがあります。|

<a id="ID4ERD"></a>


## <a name="authorization"></a>Authorization

| 型| 必須かどうか| 説明| 応答がない場合は、|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| XUID| 必須| 呼び出し元には、ユーザーの Xbox ユーザー ID (XUID) があります。| 401 権限がありません。|

<a id="ID4EZE"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| [String]。 Xbox LIVE 用のデータを承認します。 これは、通常、暗号化された XSTS トークンです。 値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>。|

<a id="ID4EYF"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| ヘッダー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion| Xbox LIVE サービスは、この要求を送信するのには、名または番号を作成します。 要求は、ヘッダー、認証トークンなどの要求の妥当性を確認した後、そのサービスにのみルーティングされます。既定値: 1。|
| Accept| [String]。 コンテンツ タイプの応答で呼び出し元を受け入れる。 すべての応答は、<b>アプリケーションまたは json</b>です。|

<a id="ID4E5G"></a>


## <a name="request-body"></a>要求本文

オブジェクトはこの要求の本文に送信されません。

<a id="ID4EJH"></a>


## <a name="http-status-codes"></a>HTTP ステータス ・ コード

サービスは、このリソースにこのメソッドを使用して行われた要求への応答では、このセクションのステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧については、[標準的な HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| 成功します。|
| 400| 要求が正しくありません。| クエリ パラメーターやユーザ Id は、形式が正しくありませんでした。|
| 403| Forbidden| 承認ヘッダーの XUID の要求を解析できませんでした。|

<a id="ID4EBBAC"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Length| 32 ビット符号なし整数| 長さをバイト単位で、応答の本体です。 値の例: 22 です。|
| Content-Type| string| 応答本体の MIME の種類です。 常に<b>アプリケーションまたは json</b>になります。|

<a id="ID4ENCAC"></a>


## <a name="response-body"></a>応答本文

呼び出しが成功した場合、サービスは、呼び出し元のユーザーのコレクション、および呼び出し元のユーザーのコレクションを格納した配列でユーザーの合計数を返します。 [PeopleList (JSON)](../../json/json-peoplelist.md)を参照してください。

<a id="ID4EZCAC"></a>


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
