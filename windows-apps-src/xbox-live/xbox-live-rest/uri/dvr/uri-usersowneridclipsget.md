---
title: 取得する (/users/{ownerId} クリップ/)
assetID: da972b4e-bc38-66f5-2222-5e79d7c8a183
permalink: en-us/docs/xboxlive/rest/uri-usersowneridclipsget.html
author: KevinAsgari
description: " 取得する (/users/{ownerId} クリップ/)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a215e9e1abb6daad2c011f38d56c2e501bd16e40
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882026"
---
# <a name="get-usersowneridclips"></a>取得する (/users/{ownerId} クリップ/)
ユーザーのクリップの一覧を取得します。
これらの Uri のドメイン`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`対象の URI の機能に応じて、します。

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

この API を使用すると、ユーザー独自のクリッピング、サービスに保存されているクリップをも他のユーザーの一覧にさまざまな方法です。 複数のエントリ ポイントは、異なるレベルのデータが返され、クエリ パラメーターによってフィルター処理するためです。 XUID の要求では、URI で指定された所有者に一致する場合、ユーザーのクリップが返されますコンテンツの分離がチェックされた後。 URI の所有者が要求の XUID を一致しない場合、指定したユーザーのクリップ返されるプライバシー チェックと要求元の XUID に対してコンテンツの分離チェックします。

ユーザーごと、サービス構成 id (scid) は、クエリが最適化されています。 または指定するさらにフィルターを使って、既定値以外の並べ替え順序の下に指定されているいくつかの状況で長い時間がかかるに戻ります。 これは、ユーザーごとのビデオのセットが大規模なより明確です。

同じ API の呼び出し内で複数のユーザーの一覧を取得するためのバッチ API はありません。 推奨されるパターン (現在) から SLS 設計者は、ユーザーごとに照会します。

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| ownerId| string| そのリソースにアクセスしているユーザーのユーザーの id。 サポートされる形式:"me"または"xuid(123456789)"。 最大長: 16 します。|

<a id="ID4EPB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- | --- |
| skipItems| 32 ビットの符号付き整数| 省略可能。 N+1 コレクション (つまり、スキップ N 項目) で始まる項目を返します。|
| continuationToken| 文字列| 省略可能。 特定の継続トークンで始まる項目を返します。 ContinuationToken パラメーターよりも優先 skipItems 両方が提供されている場合。 つまり、continuationToken パラメーターが存在する場合、skipItems パラメーターは無視されます。 最大サイズ: 36 です。|
| maxItems| 32 ビットの符号付き整数| 省略可能。 (SkipItems と項目の範囲を返す continuationToken と組み合わせることができます)、コレクションから返される項目の最大数。 MaxItems が存在しないと、(結果の最後のページが返されていない) 場合でも maxItems よりも少ない返す可能性がある場合、サービスは既定値を指定可能性があります。|
| 順序| Unicode 文字| 省略可能。 かどうかの一覧が返されます (D) escending で指定します (最初に値が最高) または (A) scending (最初に値が最も低い) 注文します。 既定: D.|
| type| GameClipTypes| 省略可能。 クリップを返すの種類のコンマ区切りのセット。 既定: すべて。|
| イベント Id| string| 省略可能。 結果をフィルター処理する eventIDs のコンマ区切りのセット。 既定: Null。|
| 修飾子| string| 省略可能。 クリップを取得するために使用する、順序の修飾子を指定します。 <ul><li>作成した - クリップがシステムに日付の順序で返されるを指定します。</li><li>評価 - [Top 評価] - クリップがから返されるが評価値を指定します</li><li>[最も表示] - - ビューは、クリップはビューの数によって返されるを指定します。</li></ul><br/> 最大サイズ: 12。 既定値:""を作成します。| 

<a id="ID4EPE"></a>


## <a name="request-body"></a>要求本文

この要求のメンバーが必要はありません。

<a id="ID4E1E"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。|
| Content-Type| string| 応答本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。|
| キャッシュ コントロール| string| キャッシュ動作を指定するていねい要求します。|
| Accept| string| コンテンツの種類の利用可能な値です。 例:<b>アプリケーション/json</b>します。|
| Retry-after| string| クライアントが利用できないサーバーの場合、後で再試行するように指示します。|
| 異なる| string| 下位のプロキシの応答をキャッシュする方法を指示します。|

<a id="ID4ENH"></a>


## <a name="optional-response-headers"></a>省略可能な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Etag| string| キャッシュの最適化のために使用します。 例:"686897696a7c876b7e"。|

<a id="ID4EOAAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EUAAC"></a>


### <a name="sample-response"></a>応答の例


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

次の URI は、このドキュメントでは、SCID を指定する追加のパス パラメーターを使って、プライマリ チャネルと同じです。 その SCID にそのユーザーのクリップのみが返されます。 要求元のユーザーに要求された SCID にアクセスする必要があります、それ以外の場合 HTTP エラー 403 が返されます。

   * **/users/{ownerId}/scids/{scid} クリップ/**

<a id="ID4ENBAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EPBAC"></a>


##### <a name="parent"></a>Parent

[/users/{ownerId} クリップ/](uri-usersowneridclips.md)
