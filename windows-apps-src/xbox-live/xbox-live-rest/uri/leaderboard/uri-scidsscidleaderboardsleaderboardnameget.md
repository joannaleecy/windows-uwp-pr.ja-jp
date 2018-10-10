---
title: GET (/scids/{scid}/leaderboards/{leaderboardname})
assetID: 4adea46c-e910-8709-c28e-ce9178e712ef
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardnameget.html
author: KevinAsgari
description: " GET (/scids/{scid}/leaderboards/{leaderboardname})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 961351e79ca04988c78c8e0be723435b39e5bae8
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4503676"
---
# <a name="get-scidsscidleaderboardsleaderboardname"></a>GET (/scids/{scid}/leaderboards/{leaderboardname})
 
定義済みグローバル ランキングを取得します。
 
これらの Uri のドメインが`leaderboards.xboxlive.com`します。
 
  * [注釈](#ID4EY)
  * [URI パラメーター](#ID4EDB)
  * [クエリ文字列パラメーター](#ID4EOB)
  * [Authorization](#ID4EID)
  * [リソースのプライバシーの設定の効果](#ID4EDE)
  * [必要な要求ヘッダー](#ID4EME)
  * [オプションの要求ヘッダー](#ID4E1F)
  * [HTTP ステータス コード](#ID4E1G)
  * [応答ヘッダー](#ID4ERCAC)
  * [応答本文](#ID4EOEAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a>注釈
 
ランキング Api すべて読み取り専用あり、したがってのみ GET 動詞をサポートします。 ランクのページと並べ替えられた「ページ」は、個々 のユーザーの統計データ プラットフォームによって書き込まれたから派生されたインデックス付きのプレイヤーの統計が反映されます。 完全なランキングのインデックスが大きくなることができ、呼び出し元は完全にいずれかを確認することはありませんが求められます、したがってこの URI はそのランキングを表示する必要があるビューの種類について具体的に呼び出し元を許可するいくつかのクエリ文字列引数をサポートしています。
 
これと同じ結果に 1 回または複数回実行された場合、GET 操作はすべてのリソースを変更しません。
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| GUID| アクセス対象のリソースが含まれているサービス構成の識別子です。| 
| leaderboardname| string| アクセス対象の定義済みのランキング リソースの一意の識別子。| 
  
<a id="ID4EOB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| maxItems| 32 ビット符号なし整数| ランキング結果のページで、返されるレコードの最大数。 指定しない場合、既定の数は (10) 返されます。 MaxItems の最大値がまだ未定義が、大規模なデータ セットを回避する、ため、この値をターゲットにする必要がありますおそらく最大呼び出しごとに UI が処理できるチューナーします。| 
| skipToRank| 32 ビット符号なし整数| ページの指定したランキング ランクで始まる結果が返されます。 結果の残りの部分は、並べ替え順序をランク順になります。 このクエリ文字列は、「の次のページ」結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。| 
| skipToUser| string| ページのユーザーのランクまたはスコアに関係なく、指定されたゲーマーの xuid の周囲のランキング結果が返されます。 ページは、定義済みのビューのページの最後の位置や統計ランキング ビューの中央で指定したユーザーと位ランクによって並べ替えられます。 この種類のクエリに対して提供される continuationToken はありません。| 
| continuationToken| string| 前の呼び出しでは、continuationToken が返される、呼び出し元渡すことが戻る現状有姿トークンの結果の次のページを取得するクエリ文字列に。| 
  
<a id="ID4EID"></a>

 
## <a name="authorization"></a>Authorization
 
コンテンツ分離とアクセス制御のシナリオ向けに実装承認ロジックがあります。
 
   * ランキング、およびユーザーの両方の統計は、呼び出し元が要求に有効な XSTS トークンを送信している、任意のプラットフォーム上のクライアントから読み取ることができます。 書き込みは、データ プラットフォームでサポートされているクライアントに明らかに制限されます。
   * タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付きの統計情報をマークできます。 ランキングは、統計を開くです。 開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。 サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。
  
チェックの擬似コードは、次のようになります。
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4EDE"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果
 
ランキング データを読み取るときは、プライバシー チェックは実行されません。
  
<a id="ID4EME"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| [String]。 HTTP 認証の資格情報を認証します。 値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>| 
| X RequestedServiceVersion| [String]。 この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。| 
| Accept| [String]。 コンテンツの種類の受け入れられる。 値の例:<b>アプリケーション/json</b>| 
  
<a id="ID4E1F"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| If-None-Match| [String]。 エンティティ タグ、クライアントは、キャッシュがサポートされる場合に使用されます。 値の例: <b>"686897696a7c876b7e"</b>|  | 
  
<a id="ID4E1G"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得されました。| 
| 304| Not Modified| リソースされていない以降に変更するように要求します。| 
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。| 
  
<a id="ID4ERCAC"></a>

 
## <a name="response-headers"></a>応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-Type| string| 必須。 応答の本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。| 
| Content-Length| string| 必須。 応答に送信されるバイト数。 例: <b>232</b>します。| 
| ETag| string| 省略可能。 キャッシュの最適化のために使用します。 例: <b>686897696a7c876b7e</b>します。| 
  
<a id="ID4EOEAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EUEAC"></a>

 
### <a name="response-members"></a>応答のメンバー
 
pagingInfo | pagingInfo| セクション| 省略可能。 MaxItems が要求で指定されたときののみを表示します。| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| continuationToken| 64 ビットの符号なし整数| 必須。 必要な場合は、その URI の結果の次のページを取得するのに<b>skipItems</b>クエリ パラメーターにフィードバックするには、どのような値を指定します。 <b>PagingInfo</b>が返されない場合は、データを取得するための次のページがありません。| 
| totalCount| 64 ビットの符号なし整数| 必須。 ランキングのエントリの合計数。 値の例: 1234567890| 
 
leaderboardInfo | leaderboardInfo| セクション| 必須。 常に返されます。 要求されたランキングに関するメタデータが含まれています。| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| displayName| string| 使用されていません。| 
| totalCount| 文字列 (64 ビットの符号なし整数)| 必須。 ランキングのエントリの合計数。 値の例: 1234567890| 
| 列| array| 必須。 ランキングの列。| 
| displayName| string| 必須。 ランキングの列に対応します。| 
| statName| string| 必須。 ランキングの列に対応します。| 
| type| 文字列| 必須。 ランキングの列に対応します。| 
 
userList | userList| セクション| 必須。 常に返されます。 要求されたランキングの実際のユーザーのスコアが含まれています。| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ゲーマータグ| string| 必須。 ランキングのエントリで、ユーザーに対応しています。| 
| xuid| 64 ビットの符号なし整数| 必須。 ランキングのエントリで、ユーザーに対応しています。| 
| 位| string| 必須。 ランキングのエントリで、ユーザーに対応しています。| 
| ランク| string| 必須。 ランキングのエントリで、ユーザーに対応しています。| 
| 値| array| 必須。 それぞれのコンマ区切り値は、ランキングの列に対応します。| 
  
<a id="ID4EGKAC"></a>

 
### <a name="sample-response"></a>応答の例
 
次の要求の URI は、グローバル ランキングにランクをスキップするかを示しています。
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/TotalFlagsCaptured/columns/deaths?maxItems=3&skipToRank=15000
         
```

 
上記の URI は、次の JSON 応答を返します。
 

```cpp
{
    "pagingInfo": {
        "continuationToken": "152",
        "totalItems": 23437
    },
    "leaderboardInfo": {
        "displayName": "Total flags captured",
        "totalCount": 23437,
        "columns": [
            {
                "displayName": "Flags Captured",
                "statName": "flagscaptured",
                "type": "Integer"
            },
            {
                "displayName": "Deaths",
                "statName": "deaths",
                "type": "Integer"
            }
        ]
    },
    "userList": [
        {
            "gamertag": "WarriorSaint",
            "xuid": 1234567890123444,
            "percentile": 0.64,
            "rank": 15000,
            "values": [
                1000,
                47
            ]
        },
        {
            "gamertag": "xxxSniper39",
            "xuid": 1234567890123555,
            "percentile": 0.64,
            "rank": 15001,
            "values": [
                998,
                17
            ]
        },
        {
            "gamertag": "WhockaWhocka",
            "xuid": 1234567890123666,
            "percentile": 0.64,
            "rank": 15002,
            "values": [
                996,
                2
            ]
        }
    ]
}
         
```

 
次の要求の URI は、グローバル ランキングにユーザーにスキップするかを示しています。
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/totalflagscaptured?maxItems=3&skipToUser=2343737892734237
         
```

 
上記の URI は、次の JSON 応答を返します。
 

```cpp
{
    "leaderboardInfo": 
    {   
       "displayName": "Total flags captured",
       "totalCount": 23437,
       "columns": [
              {
                  "displayName": "Flags Captured",
                  "statName": "flagscaptured",
                  "type": "Integer"
              }
       ]
    },
    "userList": [
        {
            "gamertag": "AverageJoe",
            "percentile": 55.00,
            "rank": 11718,
            "value": 1219,
            "xuid": 1234567890123444
        },
        {
            "gamertag": "AreUWatchinMe",
            "percentile": 60.00,
            "rank": 14162,
            "value": 1062,
            "xuid": 2343737892734333
        },
         {
            "gamertag": "WarriorSaint",
            "percentile": 64.39,
            "rank": 15000,
            "value ": 1000,
            "xuid": 1234567890123455
        }
    ]
}
         
```

   
<a id="ID4E5KAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EALAC"></a>

 
##### <a name="parent"></a>Parent 

[/scids/{scid}/leaderboards/{leaderboardname}](uri-scidsscidleaderboardsleaderboardname.md)

   