---
title: GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})
assetID: 942cf0d7-f988-0495-cf28-cdac608b8109
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeopleget.html
description: " GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 674e52d15d115560d4813edcd9687c2fe9694c9b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650767"
---
# <a name="get-usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a>GET (/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite})
順位付け、stat かすべての既知の連絡先、現在のユーザーまたはユーザーのお気に入りとしてそのユーザーによって指定された連絡先のみ (スコア) の値では、ソーシャル ランキングを返します。
これらの Uri のドメインが`leaderboards.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EAB)
  * [クエリ文字列パラメーター](#ID4ELB)
  * [承認](#ID4EQD)
  * [必要な要求ヘッダー](#ID4EGE)
  * [省略可能な要求ヘッダー](#ID4EXF)
  * [要求本文](#ID4ETG)
  * [HTTP 状態コード](#ID4ECEAC)
  * [必要な応答ヘッダー](#ID4E1HAC)
  * [省略可能な応答ヘッダー](#ID4EDJAC)
  * [応答本文](#ID4EDKAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

ランキング Api はすべて読み取り専用し、したがってのみ (HTTPS) 経由で GET 動詞をサポートします。 ランクと並べ替え済みの「ページ」データ プラットフォームを使用して記述されている個々 のユーザーの統計から派生した統計をインデックス付きのプレーヤーが反映されます。 ランキングの完全なインデックスが大きくなることができ、全体のいずれかを確認する呼び出し元が今後は、この URI がそのためにそのランキングに対して表示するビューの種類は呼び出し元を許可するいくつかのクエリ文字列引数をサポートしています。

GET 操作は、この 1 回または複数回実行された場合、同じ結果が生成されますのですべてのリソースを変更しません。

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| xuid| string| ユーザーの識別子です。|
| scid| string| アクセスされるリソースを含むサービス構成の識別子です。|
| statname| string| アクセスされているユーザーの統計リソースの一意の識別子。|
| all|お気に入り| 列挙| 現在のユーザーのすべての既知の連絡先またはお気に入りのユーザーとしてそのユーザーによって指定された連絡先のみ (スコア) の値、stat をランク付けするかどうか。|

<a id="ID4ELB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- | --- |
| maxItems| 32 ビット符号なし整数| ランキング ページの結果で返されるレコードの最大数。 指定されていない場合、既定の数には、(10) が返されます。 MaxItems の最大値は、まだ未定義が大規模なデータ セットを回避する、ため、この値が対象おそらく最大呼び出しごとに UI が処理できるチューナーします。 |
| skipToRank| 32 ビット符号なし整数| 以降では、指定したランキング ランクの結果のページを返します。 残りの結果を順位で並べ替え順序になります。 このクエリ文字列は、[次へ] の「ページ」の結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。 |
| skipToUser| string| そのユーザーのランクやスコアに関係なく、指定のゲーマー xuid の周囲のスコアボードの結果のページを返します。 ページは、stat ランキング ビューの中央にまたは定義済みのビューのページの最後の位置で指定したユーザーのパーセン タイル順位で並べ替えられます。 あるない<b>continuationToken</b>この種類のクエリを提供します。 |
| continuationToken| string| 前の呼び出しが返された場合、 <b>continuationToken</b>、呼び出し元返すことができるそのトークンを"現状有姿の結果の次のページを取得するクエリ文字列にし、します。 |
| sort| string| 低-高の値の順序 (「昇順」) からの選手の一覧をランク付けするかどうかを指定するか、高から低値の順序 ("descending")。 これは省略可能なパラメーターです。既定値は降順です。|

<a id="ID4EQD"></a>


## <a name="authorization"></a>Authorization

Xuid 承認が必要です。

承認ロジックは、コンテンツの分離とアクセス制御のシナリオの目的で実装されます。

呼び出し元の要求で有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングとユーザーの両方の統計情報を読み取ることができます。 書き込みは、例のように、データ プラットフォームでサポートされているクライアントに制限されます。

タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。 ランキングは、統計を開くです。 統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。 サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。

<a id="ID4EGE"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| [String]。 HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。|
| Content-Type| [String]。 要求本文の MIME の種類。 値の例:"application/json"。|
| X RequestedServiceVersion| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:1. |
| OK| [String]。 使用できるコンテンツの種類の値。 値の例:"application/json"。|

<a id="ID4EXF"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| Header| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| If-None-Match| [String]。 エンティティ タグ - クライアントのキャッシュをサポートしている場合に使用します。 値の例:"686897696a7c876b7e"。|

<a id="ID4ETG"></a>


## <a name="request-body"></a>要求本文

する必要がありますを表示、および accept language で指定されたロケールに一致するフォーマット形式の文字列として呼び出し元の適切な表示に戻す、データを理解する機能を最大化するには、各ユーザーの各統計値が返されます要求のヘッダー。 ローカライズされた「表示名」は、そのランキングの statname に返されます。

<a id="ID4E2G"></a>


### <a name="required-members"></a>必須メンバー

| メンバー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <b>pagingInfo</b>| セクション| (省略可能)。 ページの最後のエントリのランクが totalItems を下回る場合に返されます。 このセクションでも返されません skipToUser が要求で指定した場合。|
| continuationToken| string| 必須。 必要な場合に、結果の次のページをその URI を取得する"continuationToken"クエリ パラメーターにフィードされる値を指定します。 PagingInfo が返されない場合は、ありません [次へ] の「ページ」にデータを取得します。|
| totalItems| 64 ビット符号なし整数| 必須。 スコアボードにおける順位エントリの合計数。|
| <b>leaderboardInfo</b>| セクション| 必須。 常に返されます。 要求されたランキングに関するメタデータが含まれています。|
| displayName| string| 必須。 定義済みのランキングのローカライズされた表示名。 値の例:「キャプチャ フラグの合計です。」|
| totalCount| string| 必須。 スコアボードにおける順位エントリの合計数。|
| 列| array| 必須。|
| displayName| string| 必須。 スコア_ボード内の列に対応します。|
| statName| string| 必須。 スコア_ボード内の列に対応します。|
| type| string| 必須。 スコア_ボード内の列に対応します。|
| <b>userList</b>| セクション| 必須。 常に返されます。 要求されたランキングの実際のユーザーのスコアが含まれています。|
| ゲーマータグ| string| 必須。 ランキング エントリ内のユーザーに対応します。|
| xuid| 32 ビット符号付き整数| 必須。 ランキング エントリ内のユーザーに対応します。|
| 百分位数| string| 必須。 ランキング エントリ内のユーザーに対応します。|
| ランク| string| 必須。 ランキング エントリ内のユーザーに対応します。|
| 値| array| 必須。 コンマ区切りの各値は、スコアボードの列に対応します。|

<a id="ID4ECEAC"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得します。|
| 304| 変更されていません|  |
| 400| 要求が正しくありません| | サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。|
| 401| 権限がありません| | 要求には、ユーザー認証が必要です。|
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。|
| 404| 検出不可| 指定されたリソースが見つかりませんでした。|
| 406| Not Acceptable| リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。|
| 408| 要求のタイムアウト| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。|

<a id="ID4E1HAC"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 応答の本文の mime の種類。 値の例:"application/json"。|
| Content-Length| string| 応答で送信されるバイト数。 値の例:"232".|

<a id="ID4EDJAC"></a>


## <a name="optional-response-headers"></a>省略可能な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| ETag| string| キャッシュの最適化に使用されます。 値の例:"686897696a7c876b7e"。|

<a id="ID4EDKAC"></a>


## <a name="response-body"></a>応答本文

ソーシャル ランキング、なしのページングの要求:

https://leaderboards.xboxlive.com/users/xuid(2533274916402282)/scids/c1ba92a9-0000-0000-0000-000000000000/stats/EnemyDefeats/people/all?sort=descending

<a id="ID4ENKAC"></a>


### <a name="sample-response"></a>応答のサンプル


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

[/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite}](uri-usersxuidscidstatnamepeople.md)
