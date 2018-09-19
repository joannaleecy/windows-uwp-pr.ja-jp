---
title: GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})
assetID: 942cf0d7-f988-0495-cf28-cdac608b8109
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeopleget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c62703d43197962e313e364df2cdc3650bd2a792
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4061147"
---
# <a name="get-usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a>GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})
ランキング、統計値のいずれかすべての既知の連絡先の現在のユーザーや、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア)、ソーシャル ランキングを返します。
これらの Uri のドメインが`leaderboards.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EAB)
  * [クエリ文字列パラメーター](#ID4ELB)
  * [Authorization](#ID4EQD)
  * [必要な要求ヘッダー](#ID4EGE)
  * [省略可能な要求ヘッダー](#ID4EXF)
  * [要求本文](#ID4ETG)
  * [HTTP ステータス コード](#ID4ECEAC)
  * [必要な応答ヘッダー](#ID4E1HAC)
  * [省略可能な応答ヘッダー](#ID4EDJAC)
  * [応答本文](#ID4EDKAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

ランキング Api すべて読み取り専用あり、したがってのみ (https) GET 動詞をサポートします。 ランクと並べ替えられた「ページ」インデックス付きのプレイヤーの統計データ プラットフォームによって書き込まれた個々 のユーザー統計から派生したが反映されます。 完全なランキングのインデックスが大きくなることができ、呼び出し元はまとまりでいずれかを確認することはありませんが求められます、したがってこの URI はそのランキングを表示する必要があるビューの種類について具体的に説明する呼び出しを許可するいくつかのクエリ文字列引数をサポートしています。

これと同じ結果に 1 回または複数回実行する場合、GET 操作はすべてのリソースを変更しません。

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| xuid| string| ユーザーの識別子です。|
| scid| string| アクセス対象のリソースが含まれているサービス構成の識別子です。|
| statname| string| アクセス対象のユーザー統計リソースの一意の識別子。|
| すべて|お気に入り| 列挙値| 現在のユーザーの既知のすべての連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) の値、統計をランク付けするかどうか。|

<a id="ID4ELB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- | --- |
| maxItems| 32 ビット符号なし整数| ランキング結果のページで、返されるレコードの最大数。 指定しない場合、既定の数は (10) 返されます。 MaxItems の最大値がまだ未定義が大規模なデータ セットを回避する、ため、この値をターゲットにする必要があります可能性があります、最大チューナー呼び出しごと UI を処理します。 |
| skipToRank| 32 ビット符号なし整数| ページの指定したランキング ランクで始まる結果が返されます。 結果の残りの部分は、並べ替え順序をランク順になります。 このクエリ文字列は、次の「ページ」結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。 |
| skipToUser| string| ページのユーザーのランクまたはスコアに関係なく、指定されたゲーマーの xuid の周囲のランキング結果が返されます。 ページは、定義済みのビューのページの最後の位置や統計ランキング ビューの中央で指定したユーザーと位ランクによって並べ替えられます。 この種類のクエリに対して提供される<b>continuationToken</b>はありません。 |
| continuationToken| string| 前の呼び出しに<b>continuationToken</b>が返された場合しは、呼び出し戻る現状有姿トークンの結果の次のページを取得するクエリ文字列にします。 |
| 並べ替え| string| 高-低値 (「降順」) の順序または低-高値の順序 (「昇順」) からのプレイヤーの一覧をランク付けするかどうかを指定します。 これは、オプションのパラメーターです。既定値は降順です。|

<a id="ID4EQD"></a>


## <a name="authorization"></a>Authorization

Xuid の承認が必要です。

コンテンツの分離とアクセス制御のシナリオの目的上、承認ロジックが実装されます。

ランキング、およびユーザーの両方の統計は、呼び出し元がその要求で有効な XSTS トークンを送信している任意のプラットフォーム上のクライアントから読み取ることができます。 書き込みは、(当然ながら)、データ プラットフォームでサポートされているクライアントに制限されます。

タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付き統計をマークできます。 ランキングは、統計を開くです。 開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。 サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。

<a id="ID4EGE"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| [String]。 HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。|
| Content-Type| [String]。 要求本文の MIME タイプ。 値の例:"アプリケーション/json"します。|
| X RequestedServiceVersion| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 既定値: 1 です。|
| Accept| [String]。 利用可能なコンテンツの種類の値。 値の例:"アプリケーション/json"します。|

<a id="ID4EXF"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| ヘッダー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| If-None-Match| [String]。 エンティティ タグのクライアントでは、キャッシュがサポートされる場合に使われます。 値の例:"686897696a7c876b7e"です。|

<a id="ID4ETG"></a>


## <a name="request-body"></a>要求本文

これがする必要がありますが表示され、accept 言語で指定されたロケールに一致するフォーマット形式の文字列として返される各ユーザーの各統計値を適切な表示をもう一度取得データを理解する任意の呼び出し元の機能を最大限に高める要求ヘッダー。 ローカライズされた「表示名」は、該当するスコア_ボード statname の返されます。

<a id="ID4E2G"></a>


### <a name="required-members"></a>必要なメンバー

| メンバー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <b>pagingInfo</b>| セクション| 省略可能。 ページの最後のエントリのランクが totalItems よりも小さい場合に返されます。 このセクションもいないときに返される skipToUser が要求で指定します。|
| continuationToken| string| 必須。 必要な場合、結果の次のページをその URI を取得するのに"continuationToken"のクエリ パラメーターにフィードバックする値を指定します。 PagingInfo が返されない場合は、なし「の次のページ」データを取得できます。|
| totalItems| 64 ビットの符号なし整数| 必須。 ランキングのエントリの合計数。|
| <b>leaderboardInfo</b>| セクション| 必須。 常に返されます。 要求されたランキングに関するメタデータが含まれています。|
| displayName| string| 必須。 定義済みのランキングのローカライズされた表示名。 値の例:「キャプチャ フラグの合計」します。|
| totalCount| string| 必須。 ランキングのエントリの合計数。|
| 列| array| 必須。|
| displayName| string| 必須。 ランキングの列に対応します。|
| statName| string| 必須。 ランキングの列に対応します。|
| type| 文字列| 必須。 ランキングの列に対応します。|
| <b>userList</b>| セクション| 必須。 常に返されます。 要求されたランキングの実際のユーザーのスコアが含まれています。|
| ゲーマータグ| string| 必須。 ランキングのエントリで、ユーザーに対応しています。|
| xuid| 32 ビット符号付き整数| 必須。 ランキングのエントリで、ユーザーに対応しています。|
| 位| string| 必須。 ランキングのエントリで、ユーザーに対応しています。|
| ランク| string| 必須。 ランキングのエントリで、ユーザーに対応しています。|
| 値| array| 必須。 それぞれのコンマ区切り値は、ランキングの列に対応します。|

<a id="ID4ECEAC"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得されました。|
| 304| Not Modified|  |
| 400| Bad Request| | サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。|
| 401| 権限がありません| | 要求には、ユーザー認証が必要です。|
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。|
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。|
| 406| 許容できません。| リソースのバージョンがサポートされていません。MVC レイヤーによって拒否する必要があります。|
| 408| 要求のタイムアウト| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。|

<a id="ID4E1HAC"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 応答の本文の mime タイプ。 値の例:"アプリケーション/json"します。|
| Content-Length| string| 応答に送信されるバイト数。 値の例:「232」します。|

<a id="ID4EDJAC"></a>


## <a name="optional-response-headers"></a>省略可能な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| ETag| string| キャッシュの最適化のために使用します。 値の例:"686897696a7c876b7e"です。|

<a id="ID4EDKAC"></a>


## <a name="response-body"></a>応答本文

要求のソーシャル ランキング、ページングなし:

https://leaderboards.xboxlive.com/users/xuid(2533274916402282)/scids/c1ba92a9-0000-0000-0000-000000000000/stats/EnemyDefeats/people/all?sort=descending

<a id="ID4ENKAC"></a>


### <a name="sample-response"></a>応答の例


```cpp
{
    "pagingInfo": null,
    "leaderboardInfo": {
        "displayName": "Kills",
        "totalCount": 3,
        "columns": [
            {
                "displayName": "Kills",
                "statName": "enemydefeats",
                "type": "integer"
            }
        ]
    },
    "userList": [
        {
            "gamertag":"xxxSniper39",
            "xuid":"1234567890123555",
            "percentile":1.0,
            "rank":1,
            "values": [
                "47"
            ]
        },
        {
            "gamertag":"WarriorSaint",
            "xuid":"2533274916402282",
            "percentile":0.66,
            "rank":2,
            "values": [
                "42"
            ]
        },
        {
            "gamertag":"WhockaWhocka",
            "xuid":"1234567890123666",
            "percentile":0.33,
            "rank":3,
            "values": [
                "12"
            ]
        }
    ]
}

```


<a id="ID4EXKAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EZKAC"></a>


##### <a name="parent"></a>Parent

[ユーザー/xuid ({xuid})/scids/{scid}/stats/{statname) そして {all\ | お気に入り}](uri-usersxuidscidstatnamepeople.md)
