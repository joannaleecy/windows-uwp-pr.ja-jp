---
title: GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)
assetID: ee69a9e3-ea91-3cf5-a10a-811762cba892
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardnamegetvaluemetadata.html
author: KevinAsgari
description: " GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ff98fc1ec6188ae1b31bff36335c914b6f257e28
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5560863"
---
# <a name="get-scidsscidleaderboardsleaderboardnameincludevaluemetadata"></a>GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)
 
ランキングの値に関連付けられたメタデータと共に定義済みグローバル ランキングを取得します。
 
これらの Uri のドメインが`leaderboards.xboxlive.com`します。
 
  * [注釈](#ID4EY)
  * [URI パラメーター](#ID4EHB)
  * [クエリ文字列パラメーター](#ID4ESB)
  * [Authorization](#ID4EVD)
  * [リソースのプライバシーの設定の効果](#ID4EQE)
  * [必要な要求ヘッダー](#ID4EZE)
  * [オプションの要求ヘッダー](#ID4EOG)
  * [HTTP ステータス コード](#ID4EOH)
  * [応答ヘッダー](#ID4EFDAC)
  * [応答本文](#ID4ECFAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a>注釈
 
かどうか。 含める = valuemetadata クエリ パラメーターは、ランキング値に関連付けられたメタデータを含めるへの応答をことができます。 値のメタデータには、指定されたクライアントが含まれているデータ モデルやレース トラックに最適な時間を実現するために使用される車の色など、値に関連付けられています。
 
値のメタデータは、ランキングのランキング自体ではなく基になっているユーザー統計で定義されます。
 
ランキング Api すべて読み取り専用あり、したがってのみ GET 動詞をサポートします。 ランクのページと並べ替えられた「ページ」は、個々 のユーザーの統計データ プラットフォームによって書き込まれたから派生されたインデックス付きのプレイヤーの統計が反映されます。 完全なランキングのインデックスが大きくなることができ、呼び出し元は完全にいずれかを確認することはありませんが求められます、したがってこの URI は、呼び出し元に表示するランキングを表示する必要があるの種類について具体的に許可するいくつかのクエリ文字列引数をサポートしています。
 
これと同じ結果に 1 回または複数回実行している場合、GET 操作はすべてのリソースを変更しません。
  
<a id="ID4EHB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| GUID| アクセス対象のリソースが含まれているサービス構成の識別子です。| 
| leaderboardname| string| アクセス対象の定義済みのランキング リソースの一意の識別子。| 
  
<a id="ID4ESB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 含める = valuemetadata| string| 応答には、ランキング値に関連付けられた値メタデータが含まれていることを示します。| 
| maxItems| 32 ビットの符号なし整数| ランキング結果のページで、返されるレコードの最大数。 指定しない場合、既定の数は (10) 返されます。 MaxItems の最大値は引き続きが大規模なデータ セットを回避する、ため、この値をターゲットにする必要がありますおそらく、最大チューナー呼び出しごと UI を処理します。| 
| skipToRank| 32 ビットの符号なし整数| ページの指定したランキング順位以降の結果を返します。 結果の残りの部分は、並べ替え順序をランク順になります。 このクエリ文字列は、次の「ページ」結果を取得する後続のクエリに戻すことができる継続トークンを返すことができます。| 
| skipToUser| string| ページのユーザーのランクまたはスコアに関係なく、指定されたゲーマーの xuid の周囲のランキング結果が返されます。 ページは、定義済みのビューのページの最後の位置や統計ランキング ビューの中央で指定したユーザーと位ランクで並べ替えられます。 この種類のクエリに対して提供される continuationToken はありません。| 
| continuationToken| string| 前の呼び出しでは、continuationToken が返される、呼び出し元渡すことが戻る現状有姿トークンの結果の次のページを取得するクエリ文字列に。| 
  
<a id="ID4EVD"></a>

 
## <a name="authorization"></a>Authorization
 
コンテンツ分離とアクセス制御のシナリオ向けに実装承認ロジックがあります。
 
   * ランキング、およびユーザーの両方の統計は、呼び出し元が要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントから読み取ることができます。 書き込みは、データ プラットフォームでサポートされているクライアントに明らかに制限されます。
   * タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付きの統計情報をマークできます。 ランキングは、統計を開くです。 開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。 サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。
  
チェックの擬似コードは、このようになります。
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4EQE"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果
 
ランキング データを読み取るときは、プライバシー チェックは実行されません。
  
<a id="ID4EZE"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| [String]。 HTTP の認証の資格情報を認証します。 値の例: <b>XBL3.0 x =&lt;userhash >;&lt;トークン ></b>| 
| X Xbl コントラクト バージョン| [String]。 使用する API のバージョンを示します。 この値は、応答に値のメタデータを含めるために、「3」に設定する必要があります。| 
| X RequestedServiceVersion| [String]。 この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。| 
| Accept| [String]。 コンテンツの種類の受け入れられるします。 値の例:<b>アプリケーション/json</b>| 
  
<a id="ID4EOG"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| If-None-Match| [String]。 エンティティ タグ、クライアントは、キャッシュがサポートされる場合に使用されます。 値の例: <b>"686897696a7c876b7e"</b>|  | 
  
<a id="ID4EOH"></a>

 
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
  
<a id="ID4EFDAC"></a>

 
## <a name="response-headers"></a>応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-Type| string| 必須。 応答の本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。| 
| Content-Length| string| 必須。 応答に送信されるバイト数。 例: <b>232</b>します。| 
| ETag| string| 省略可能。 キャッシュの最適化のために使用します。 例: <b>686897696a7c876b7e</b>します。| 
  
<a id="ID4ECFAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EIFAC"></a>

 
### <a name="response-members"></a>応答のメンバー
 
pagingInfo | pagingInfo| セクション| 省略可能。 MaxItems が要求で指定された場合にのみ表示します。| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| continuationToken| 64 ビットの符号なし整数| 必須。 必要な場合は、その URI の結果の次のページを取得するのに<b>skipItems</b>クエリ パラメーターにフィードバックするには、どのような値を指定します。 <b>PagingInfo</b>が返されない場合データを取得するための次のページがありません。| 
| totalItems| 64 ビットの符号なし整数| 必須。 ランキングのエントリの合計数。 値の例: 1234567890| 
 
leaderboardInfo | leaderboardInfo| セクション| 必須。 常に返されます。 要求されたランキングに関するメタデータが含まれています。| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| displayName| string| 使用されていません。| 
| totalCount| 文字列 (64 ビットの符号なし整数)| 必須。 ランキングのエントリの合計数。 値の例: 1234567890| 
| columnDefinition| JSON オブジェクト| 必須。 ランキングの列について説明します。| 
| columnDefinition.displayName| string| 必須。 ランキングの列のわかりやすい名前。| 
| columnDefinition.statName| string| 必須。 ユーザーの統計に基づくランキングの名前です。| 
| columnDefinition.type| string| 必須。 列で、ユーザー統計のデータ型。| 
 
userList | userList| セクション| 必須。 常に返されます。 要求されたランキングの実際のユーザーのスコアが含まれています。| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ゲーマータグ| string| 必須。 ランキングのエントリ内のユーザーのゲーマータグです。| 
| xuid| 64 ビットの符号なし整数| 必須。 ランキングのエントリで、ユーザーの Xbox ユーザー ID です。| 
| 位| string| 必須。 ユーザーのランキングのランキングを位です。| 
| ランク| string| 必須。 ランキングで、ユーザーの数値のランク。| 
| value| string| 必須。 ランキングを基になる統計のユーザーの値。| 
| valueMetadata| string| 必須。 文字列のコンマ区切り"\"name\"の形式での文字列のペア: \"value\「,.」

メタデータがない場合は、この値は、空の文字列 |。 
  
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a>応答の例
 
次の要求の URI は、グローバル ランキングでランクをスキップするかを示しています。
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/TotalFlagsCaptured?include=valuemetadata&maxItems=3&skipToRank=15000
         
```

 
値のメタデータを返すには、するために、次のヘッダーを指定もする必要があります。
 

```cpp
X-Xbl-Contract-Version : 3
          
```

 
上記の URI は、次の JSON 応答を返します。
 

```cpp
{
    "pagingInfo": {
        "continuationToken": "15003",
        "totalItems": 23437
    },
    "leaderboardInfo": {
        "displayName": "Total flags captured",
        "totalCount": 23437,
        "columnDefinition" : 
            {
                "displayName": "Flags Captured",
                "statName": "flagscaptured",
                "type": "Integer"
            }
    },
    "userList": [
        {
            "gamertag": "WarriorSaint",
            "xuid": "1234567890123444",
            "percentile": 0.64,
            "rank": 15000,
            "value": "1002",
            "valuemetadata" : "{\"color\" : \"silver\",\"weight\" : 2000, \"israining\" : false}"
        },
        {
            "gamertag": "xxxSniper39",
            "xuid": "1234567890123555",
            "percentile": 0.64,
            "rank": 15001,
            "value": "993",
            "valuemetadata" : "{\"color\" : \"silver\",\"weight\" : 2020, \"israining\" : true}"
 
        },
        {
            "gamertag": "WhockaWhocka",
            "xuid": "1234567890123666",
            "percentile": 0.64,
            "rank": 15002,
            "value": "700",
            "valuemetadata" : "{\"color\" : \"red\",\"weight\" : 300, \"israining\" : false}"
        }
    ]
}
         
```

   
<a id="ID4E6LAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBMAC"></a>

 
##### <a name="parent"></a>Parent 

[/scids/{scid}/leaderboards/{leaderboardname}](uri-scidsscidleaderboardsleaderboardname.md)

   