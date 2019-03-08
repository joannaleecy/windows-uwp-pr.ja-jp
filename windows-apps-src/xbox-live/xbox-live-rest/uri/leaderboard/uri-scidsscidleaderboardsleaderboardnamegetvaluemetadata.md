---
title: GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)
assetID: ee69a9e3-ea91-3cf5-a10a-811762cba892
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardnamegetvaluemetadata.html
description: " GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fad57c5e989d933777c913030faaa594c6bbd059
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623437"
---
# <a name="get-scidsscidleaderboardsleaderboardnameincludevaluemetadata"></a>GET (/scids/{scid}/leaderboards/{leaderboardname}?include=valuemetadata)
 
ランキングの値に関連付けられたメタデータと共に定義済みのグローバルなランキングを取得します。
 
これらの Uri のドメインが`leaderboards.xboxlive.com`します。
 
  * [注釈](#ID4EY)
  * [URI パラメーター](#ID4EHB)
  * [クエリ文字列パラメーター](#ID4ESB)
  * [承認](#ID4EVD)
  * [リソースのプライバシーの設定の効果](#ID4EQE)
  * [必要な要求ヘッダー](#ID4EZE)
  * [省略可能な要求ヘッダー](#ID4EOG)
  * [HTTP 状態コード](#ID4EOH)
  * [応答ヘッダー](#ID4EFDAC)
  * [応答本文](#ID4ECFAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a>注釈
 
でしょうか。 含める valuemetadata = クエリ パラメーターがランキングの値に関連付けられたメタデータを含めるへの応答を使用できます。 値のメタデータには、指定されたクライアントが含まれています。 モデルとの競合の追跡に最適な時間を実現するために使用される、自動車の色など、値に関連付けられたデータ。
 
値のメタデータは、スコアボード自体ではなく、スコアボードの基に、ユーザーの状態で定義されます。
 
ランキング Api はすべて読み取り専用し、したがってのみ GET 動詞をサポートします。 ランクと並べ替え済みの「ページ」データ プラットフォームを使用して記述されている個々 のユーザーの統計から派生した統計をインデックス付きのプレーヤーが反映されます。 ランキングの完全なインデックスが大きくなることができ、全体のいずれかを確認する呼び出し元が今後は、この URI がそのためにそのランキングに対して表示するビューの種類は呼び出し元を許可するいくつかのクエリ文字列引数をサポートしています。
 
GET 操作は、この 1 回または複数回実行された場合、同じ結果が生成されますのですべてのリソースを変更しません。
  
<a id="ID4EHB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| scid| GUID| アクセスされるリソースを含むサービス構成の識別子です。| 
| leaderboardname| string| アクセスされる定義済みのランキング リソースの一意の識別子。| 
  
<a id="ID4ESB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 含める valuemetadata を =| string| 応答にランキングの値に関連付けられた任意の値のメタデータが含まれていることを示します。| 
| maxItems| 32 ビット符号なし整数| ランキング ページの結果で返されるレコードの最大数。 指定されていない場合、既定の数には、(10) が返されます。 MaxItems の最大値は、まだ未定義が大規模なデータ セットを回避する、ため、この値が対象おそらく最大呼び出しごとに UI が処理できるチューナーします。| 
| skipToRank| 32 ビット符号なし整数| 以降では、指定したランキング ランクの結果のページを返します。 残りの結果を順位で並べ替え順序になります。 このクエリ文字列は、[次へ] の「ページ」の結果を取得する後続のクエリに取り込むことができる継続トークンを返すことができます。| 
| skipToUser| string| そのユーザーのランクやスコアに関係なく、指定のゲーマー xuid の周囲のスコアボードの結果のページを返します。 ページは、stat ランキング ビューの中央にまたは定義済みのビューのページの最後の位置で指定したユーザーのパーセン タイル順位で並べ替えられます。 この種類のクエリに対して提供される continuationToken はありません。| 
| continuationToken| string| 前の呼び出しで、continuationToken が返された場合はし、呼び出し元ことができますを送り返すそのトークンを"現状有姿結果の次のページを取得するクエリ文字列で。| 
  
<a id="ID4EVD"></a>

 
## <a name="authorization"></a>Authorization
 
コンテンツの分離とアクセス制御のシナリオで実装された承認ロジックがあります。
 
   * 呼び出し元の要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングとユーザーの両方の統計情報を読み取ることができます。 書き込みは、当然ながら、データ プラットフォームでサポートされているクライアントに制限されます。
   * タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。 ランキングは、統計を開くです。 統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。 サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。
  
チェックの擬似コードのようになります。
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4EQE"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果
 
ランキング データを読み取る場合は、プライバシーに関するチェックは行われません。
  
<a id="ID4EZE"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| [String]。 HTTP 認証の資格情報を認証します。 値の例:<b>XBL3.0 x=&lt;userhash>;&lt;token></b>| 
| X Xbl コントラクト バージョン| [String]。 使用する API のバージョンを示します。 この値は、値のメタデータを応答に含めるために、「3」に設定する必要があります。| 
| X RequestedServiceVersion| [String]。 この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. | 
| OK| [String]。 コンテンツ型が許容されます。 値の例:<b>アプリケーション/json</b>| 
  
<a id="ID4EOG"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| If-None-Match| [String]。 クライアント キャッシュをサポートしている場合に使用されるエンティティ タグ。 値の例:<b>"686897696a7c876b7e"</b>|  | 
  
<a id="ID4EOH"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得します。| 
| 304| 変更されていません| リソースされていない最後の要求以降に変更します。| 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 406| Not Acceptable| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。| 
  
<a id="ID4EFDAC"></a>

 
## <a name="response-headers"></a>応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-Type| string| 必須。 応答の本文の MIME の種類。 例: <b>、application/json</b>します。| 
| Content-Length| string| 必須。 応答で送信されるバイト数。 以下に例を示します。<b>232</b>.| 
| ETag| string| (省略可能)。 キャッシュの最適化に使用されます。 以下に例を示します。<b>686897696a7c876b7e</b>します。| 
  
<a id="ID4ECFAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EIFAC"></a>

 
### <a name="response-members"></a>応答のメンバー
 
pagingInfo | pagingInfo| セクション| (省略可能)。 MaxItems が要求で指定した場合にだけ表示されます。| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| continuationToken| 64 ビット符号なし整数| 必須。 フィードバックするどのような値を指定します、 <b>skipItems</b>クエリ パラメーターが必要な場合、その URI の結果の次のページを取得します。 ない場合は<b>pagingInfo</b>を取得するデータの次のページはありませんが返されます。| 
| totalItems| 64 ビット符号なし整数| 必須。 スコアボードにおける順位エントリの合計数。 値の例:1234567890| 
 
leaderboardInfo | leaderboardInfo| セクション| 必須。 常に返されます。 要求されたランキングに関するメタデータが含まれています。| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| displayName| string| 使用されません。| 
| totalCount| 文字列 (64 ビット符号なし整数)| 必須。 スコアボードにおける順位エントリの合計数。 値の例:1234567890| 
| columnDefinition| JSON オブジェクト| 必須。 スコアボードにおける順位列をについて説明します。| 
| columnDefinition.displayName| string| 必須。 スコアボードにおける列のわかりやすい名前。| 
| columnDefinition.statName| string| 必須。 ユーザー統計に基づく、スコアボードの名前。| 
| columnDefinition.type| string| 必須。 列にユーザー状態のデータ型。| 
 
userList | userList| セクション| 必須。 常に返されます。 要求されたランキングの実際のユーザーのスコアが含まれています。| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ゲーマータグ| string| 必須。 ランキング エントリ内のユーザーのゲーマータグです。| 
| xuid| 64 ビット符号なし整数| 必須。 ランキング エントリ内のユーザーの Xbox ユーザー ID。| 
| 百分位数| string| 必須。 スコアボードにおけるユーザーの百分位数のランク。| 
| ランク| string| 必須。 スコアボードにおけるユーザーの数値のランク。| 
| value| string| 必須。 スコアボードの基になる統計のユーザーの値。| 
| valueMetadata| string| 必須。 文字列のコンマ区切り形式の文字列ペア"\"名前\":\"値\",..."

この値は空の文字列でメタデータがない場合 |。 
  
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 
次の要求 URI は、グローバルなランキングのランクをスキップしていますかを示しています。
 

```cpp
https://leaderboards.xboxlive.com/scids/0FA0D955-56CF-49DE-8668-05D82E6D45C4/leaderboards/TotalFlagsCaptured?include=valuemetadata&maxItems=3&skipToRank=15000
         
```

 
値のメタデータを返すために、次のヘッダーを指定も必要があります。
 

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

   