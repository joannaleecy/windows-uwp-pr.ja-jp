---
title: GET (/users/{ownerId}/clips)
assetID: da972b4e-bc38-66f5-2222-5e79d7c8a183
permalink: en-us/docs/xboxlive/rest/uri-usersowneridclipsget.html
description: " GET (/users/{ownerId}/clips)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7c52daf4a07914c34f1aadc84a7238771669d65f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623207"
---
# <a name="get-usersowneridclips"></a>GET (/users/{ownerId}/clips)
ユーザーのクリップの一覧を取得します。
これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。

  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EEB)
  * [クエリ文字列パラメーター](#ID4EPB)
  * [要求本文](#ID4EPE)
  * [必要な応答ヘッダー](#ID4E1E)
  * [省略可能な応答ヘッダー](#ID4ENH)
  * [応答本文](#ID4EOAAC)
  * [関連する Uri](#ID4EABAC)

<a id="ID4EX"></a>


## <a name="remarks"></a>注釈

この API は、ユーザー独自のサービスに格納されているにも他のユーザーのクリップのクリップ リストにさまざまな方法を使用できます。 いくつかのエントリ ポイントは、さまざまなレベルからデータを返すし、クエリ パラメーターを使用してフィルター処理するためです。 要求 XUID には、URI で指定された所有者が一致すると、し、ユーザーのクリップが返されます後、コンテンツの分離を確認します。 場合は、URI の所有者では、指定したユーザーのクリップのプライバシーに関する確認と要求元 XUID に対してコンテンツの分離のチェックがに基づいて返されます、XUID、要求は一致しません。

ユーザーごと、サービス構成の id (scid) は、クエリが最適化されています。 指定するさらにフィルターまたは既定値以外の並べ替え順序以下に示すいくつかの状況で長い時間がかかるを返します。 ユーザーごとの動画の大規模な一連のより明らかになります。

同じ API の呼び出し内で複数のユーザーの一覧を取得するためのバッチ API はありません。 推奨されるパターン (現在) SLS アーキテクトからはさらに各ユーザーに対してクエリを実行します。

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| ownerId| string| リソースがアクセスされているユーザーのユーザー id。 サポートされている形式:"xuid(123456789)"または"me"。 最大長:16.|

<a id="ID4EPB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- | --- |
| skipItems| 32 ビット符号付き整数| (省略可能)。 N+1 コレクション (つまり、skip N 項目) で始まる項目を返します。|
| continuationToken| string| (省略可能)。 指定された継続トークンで始まる項目を返します。 ContinuationToken パラメーターよりも優先 skipItems 両方を指定しない場合。 つまり、skipItems パラメーターには、continuationToken パラメーターが存在する場合は無視されます。 最大サイズ:36.|
| maxItems| 32 ビット符号付き整数| (省略可能)。 (SkipItems と項目の範囲を取得するように continuationToken と組み合わせることができます) のコレクションから返されるアイテムの最大数。 MaxItems が存在しないと、(結果の最後のページはまだ返送されていない) 場合でも、maxItems よりも少ないを返すことが場合、サービスは既定値を提供できます。|
| 順序| Unicode 文字| (省略可能)。 かどうか、(D) escending に返される一覧を指定します (最初に値が最高) scending (A) または (最初に最小値) の順序。 既定:D。|
| type| GameClipTypes| (省略可能)。 返されるクリップの種類のコンマ区切りのセット。 既定:すべての。|
| イベント Id| string| (省略可能)。 結果をフィルター処理する Eventid のコンマ区切りのセット。 既定:null を返します。|
| 修飾子| string| (省略可能)。 クリップを取得するために使用される order 修飾子を指定します。 <ul><li>作成 - クリップがシステムに日付の順序で返されるを指定します</li><li>-[トップランクの評価] の評価には、クリップがその評価の値によって返されるを指定します</li><li>[最も表示] - - ビューでは、クリップがビューの数によって返されるを指定します</li></ul><br/> 最大サイズ:12. 既定値:「作成」します。| 

<a id="ID4EPE"></a>


## <a name="request-body"></a>要求本文

この要求の必須メンバーはありません。

<a id="ID4E1E"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。|
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。|
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。|
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。|
| 再試行後| string| 後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。|
| 異なる| string| ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。|

<a id="ID4ENH"></a>


## <a name="optional-response-headers"></a>省略可能な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Etag| string| キャッシュの最適化に使用されます。 以下に例を示します。"686897696a7c876b7e"。|

<a id="ID4EOAAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EUAAC"></a>


### <a name="sample-response"></a>応答のサンプル


```cpp
{
       "gameClips":
       [
           {
               "xuid": "2716903703773872",
               "clipName": "[en-US] Localized Greatest Moment Name",
               "titleName": "[en-US] Localized Title Name",
               "gameClipLocale": "en-US",
               "gameClipId": "6873f6cf-af12-48a5-8be6-f3dfc3f61538-000",
               "state": "Published",
               "dateRecorded": "2013-06-14T01:02:55.4918465Z",
               "lastModified": "2013-06-14T01:05:41.3652693Z",
               "userCaption": "Set by user!",
               "type": "DeveloperInitiated",
               "source": "Console",
               "visibility": "Public",
               "durationInSeconds": 30,
               "scid": "00000000-0000-0012-0023-000000000070",
               "titleId": 354975,
               "rating": 3.75,
               "ratingCount": 245,
               "views": 7453,
               "titleData": "",
               "systemProperties": "",
               "savedByUser": false,
               "achievementId": "AchievementId",
               "greatestMomentId": "GreatestMomentId",
               "thumbnails": [
                   {
                       "uri": "http://localhost/users/xuid(2716903703773872)/scids/00000000-0000-0012-0023-000000000070/clips/6873f6cf-af12-48a5-8be6-f3dfc3f61538-000/thumbnails/large",
                       "fileSize": 637293,
                       "thumbnailType": "Large"
                   },
                   {
                       "uri": "http://localhost/users/xuid(2716903703773872)/scids/00000000-0000-0012-0023-000000000070/clips/6873f6cf-af12-48a5-8be6-f3dfc3f61538-000/thumbnails/small",
                       "fileSize": 163998,
                       "thumbnailType": "Small"
                   }
               ],
               "gameClipUris": [
                   {
                       "uri": "http://localhost/897f65a9-63f0-45a0-926f-05a3155c04fc/GameClip-Original_4000.ism/manifest",
                       "uriType": "SmoothStreaming",
                       "expiration": "2013-06-14T01:10:08.73652Z"
                   },
                   {
                       "uri": "http://localhost/897f65a9-63f0-45a0-926f-05a3155c04fc/GameClip-Original_4000.ism/manifest(format=m3u8-aapl)",
                       "uriType": "Ahls",
                       "expiration": "2013-06-14T01:10:08.73652Z"
                   },
                   {
                       "uri": "http://localhost/users/xuid(2716903703773872)/scids/00000000-0000-0012-0023-000000000070/clips/6873f6cf-af12-48a5-8be6-f3dfc3f61538-000",
                       "fileSize": 88820,
                       "uriType": "Download",
                       "expiration": "2999-12-31T11:59:40Z"
                   }
               ]
           }
       ],
   "pagingInfo":
       {
           "continuationToken": null,
           "totalItems": 1
       }
   }

```


<a id="ID4EABAC"></a>


## <a name="related-uris"></a>関連する Uri

次の URI は、このドキュメントでは、SCID を指定する追加のパス パラメーターを持つプライマリの 1 つと同じです。 その SCID のユーザーのクリップのみが返されます。 要求元のユーザーは、要求された SCID にアクセスする必要があります、それ以外の場合 HTTP エラー 403 が返されます。

   * **/users/{ownerId}/scids/{scid}/clips**

<a id="ID4ENBAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EPBAC"></a>


##### <a name="parent"></a>Parent

[/users/{ownerId}/clips](uri-usersowneridclips.md)
