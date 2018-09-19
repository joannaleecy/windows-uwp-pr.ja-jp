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
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4055613"
---
# <a name="get-usersowneridpeople"></a>GET (/users/{ownerId}/people)
呼び出し元のユーザーのコレクションを取得します。
これらの Uri のドメインが`social.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [クエリ文字列パラメーター](#ID4EJB)
  * [Authorization](#ID4ERD)
  * [必要な要求ヘッダー](#ID4EZE)
  * [省略可能な要求ヘッダー](#ID4EYF)
  * [要求本文](#ID4E5G)
  * [HTTP ステータス コード](#ID4EJH)
  * [必要な応答ヘッダー](#ID4EBBAC)
  * [応答本文](#ID4ENCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

これと同じ結果に 1 回または複数回実行する場合、GET 操作はすべてのリソースを変更しません。

<a id="ID4E5"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| ownerId| string| そのリソースにアクセスしているユーザーの識別子です。 認証されたユーザーに一致する必要があります。 設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。|

<a id="ID4EJB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- | --- |
| 表示| string| ビューに関連付けられているユーザーを返します。 既定値は、"all"です。 設定できる値は次のとおりです。 <ul><li><b>すべて</b>のユーザーの People リスト上のすべてのユーザーを返します。 これは既定値です。</li><li><b>お気に入り</b>お気に入り属性を持っているユーザーの People リスト上のすべてのユーザーを返します。</li><li><b>LegacyXboxLiveFriends</b> - を持っている従来の Xbox LIVE のフレンドでも、ユーザーの People リスト上のすべてのユーザーを返します。</li></br>**注:** 呼び出し元のユーザーが所有するユーザーと異なる場合、**すべて**の値のみがサポートされています。|
| startIndex| 32 ビット符号なし整数| 特定のインデックスを開始する項目を返します。  
| maxItems| 32 ビット符号なし整数| スタート画面のインデックスから始まるコレクションから返されるユーザーの最大数。 <b>MaxItems</b>が存在しないと、(結果の最後のページが返されていない) 場合でも同様に返す<b>maxItems</b>よりも少ない可能性がある場合、サービスは既定値を提供可能性があります。|

<a id="ID4ERD"></a>


## <a name="authorization"></a>Authorization

| 型| 必須かどうか| 説明| 不足している場合、応答|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| XUID| 必須| 呼び出し元では、ユーザーの Xbox ユーザー ID (XUID) があります。| 401 承認されていません。|

<a id="ID4EZE"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| [String]。 Xbox LIVE のデータを承認します。 これは、通常、暗号化された XSTS トークンです。 値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>します。|

<a id="ID4EYF"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| ヘッダー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。|
| Accept| [String]。 コンテンツ タイプを呼び出し元が応答で受け取る。 すべての応答は、<b>アプリケーション/json</b>です。|

<a id="ID4E5G"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EJH"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| 成功します。|
| 400| Bad Request| クエリ パラメーターやユーザー Id は、正しくありませんでした。|
| 403| Forbidden| 承認ヘッダーから XUID クレームを解析できませんでした。|

<a id="ID4EBBAC"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Length| 32 ビット符号なし整数| バイト単位の長さ、応答本文。 値の例: 22 します。|
| Content-Type| string| 応答本文の MIME タイプ。 これにより、<b>アプリケーション/json</b>は常になります。|

<a id="ID4ENCAC"></a>


## <a name="response-body"></a>応答本文

呼び出しが成功した場合は、サービスは、呼び出し元のユーザーのコレクション、および呼び出し元のユーザーのコレクションが含まれた配列内のユーザーの合計数を返します。 [PeopleList (JSON)](../../json/json-peoplelist.md)を参照してください。

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
