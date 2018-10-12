---
title: GET (/users/xuid({xuid})/inbox)
assetID: c603910d-b430-f157-2634-ceddea89f2bd
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/inbox)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3d27ed6fa81bfd8618f19938c97a56361c16c009
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4535797"
---
# <a name="get-usersxuidxuidinbox"></a>GET (/users/xuid({xuid})/inbox)
サービスから指定したメッセージの概要をユーザー数を取得します。
これらの Uri のドメインが`msg.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [クエリ文字列パラメーター](#ID4EIC)
  * [Authorization](#ID4EGE)
  * [リソースのプライバシーの設定の効果](#ID4ETE)
  * [HTTP ステータス コード](#ID4E5E)
  * [JavaScript Object Notation (JSON) の応答](#ID4EMH)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

ユーザーのメッセージ要約にはには、メッセージの件名のみが含まれています。 ユーザーが生成したメッセージの場合、これは、現在メッセージ テキストの最初の 20 文字。 システム メッセージは、"LIVE System"などの別のサブジェクトを提供することができます。

メッセージが送信された注文の逆の順序で返されますつまり、新しいメッセージは、最初に返されます。

この API はサポートのみコンテンツの種類は、"アプリケーション/json"、呼び出しごとの HTTP ヘッダーのために必要です。

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。|

<a id="ID4EIC"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| プロパティ| 型| 最大長| 注釈|
| --- | --- | --- | --- | --- | --- | --- |
| maxItems| int| 100| メッセージの最大数が返されます。|
| continuationToken| string|  | 以前の列挙呼び出し; で返される文字列列挙値を続行するために使用します。|
| skipItems| int| 100| をスキップするメッセージの数continuationToken が存在する場合は無視されます。|

<a id="ID4EGE"></a>


## <a name="authorization"></a>Authorization

独自のユーザーがユーザーのメッセージの概要を取得する要求が必要です。

<a id="ID4ETE"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

のみユーザー メッセージを列挙することができます。

<a id="ID4E5E"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| 要求が成功しました。|
| 400| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。|
| 403| ユーザーまたはサービスの要求は許可されていません。|
| 404| 有効な XUID が URI ではありません。|
| 409| 基になるコレクションでは、渡された継続トークンに基づいて変更されます。|
| 416| スキップされる項目の数は、利用可能な項目の数を超えています。|
| 500| サーバー側の一般的なエラーです。|

<a id="ID4EMH"></a>


## <a name="javascript-object-notation-json-response"></a>JavaScript Object Notation (JSON) の応答

正常に呼び出されると、サービスは結果データを JSON 形式で返します。

| プロパティ| 型| 最大長| 注釈|
| --- | --- | --- | --- |
| 結果| メッセージの| 100| ユーザーのメッセージの配列|
| pagingInfo| PagingInfo|  | 現在の結果セットのページング情報|

#### <a name="message"></a>メッセージ

| プロパティ| 型| 最大長| 注釈|
| --- | --- | --- | --- |
| header| ヘッダー|  | ユーザーのメッセージのヘッダー|
| messageSummary| string| 20| UTF-8 です。通常はメッセージの最初の 20 文字|

#### <a name="header"></a>ヘッダー

| プロパティ| 型| 最大長| 注釈|
| --- | --- | --- | --- |
| id| string| 50| メッセージ id、メッセージの詳細を取得またはメッセージを削除するために使用します。|
| isRead| bool|  | ユーザーがメッセージの詳細を既に「ことを示すしますフラグ。|
| 送信| DateTime|  | UTC 日付と時刻は、メッセージが送信されました。 (サービスによって提供されます)。|
| 有効期限| DateTime|  | UTC 日付と時刻は、有効期限が切れるメッセージ。 (すべてのメッセージによって、将来的に決定する、最長有効期間がある)。|
| メッセージの種類| string| 50| メッセージの種類: ユーザー、システム、FriendRequest、ビデオ、QuickChat、VideoChat、PartyChat、タイトル、GameInvite します。|
| senderXuid| ulong|  | 送信者の XUID です。|
| 送信者| string| 15| 送信者のゲーマータグです。|
| hasAudio| bool|  | かどうか、メッセージには、オーディオ (声) 添付ファイルがあります。|
| hasPhoto| bool|  | メッセージに写真の添付ファイルがあるかどうか。|
| hasText| bool|  | かどうか、メッセージには、テキストが含まれています。|

#### <a name="paging-info"></a>ページング情報

| プロパティ| 型| 最大長| 注釈|
| --- | --- | --- | --- |
| continuationToken| string| 100| 必要に応じてサーバーによって返されます。 列挙体の続行を後で呼び出すを許可します。|
| totalItems| int|  | 受信トレイのメッセージの合計数。|

#### <a name="sample-response"></a>応答の例

```cpp
{
          "results":
          [
            {
              "header":
              {
                "expiration":"2011-10-11T23:59:59.9999999",
                "id":"opaqueBlobOfText",
                "messageType":"User",
                "isRead":false,
                "senderXuid":"123456789",
                "sender":"Striker",
                "sent":"2011-05-08T17:30:00Z",
                "hasAudio":false,
                "hasPhoto":false,
                "hasText":true
              },
            "messageSummary":"first 20 chars"
          },
          ...
        ],
        "pagingInfo":
          {
          "continuationToken":"opaqueBlobOfText"
          "totalItems":5,
          }
        }

```

#### <a name="error-response"></a>エラー応答

エラーの場合、サービスはサービスの環境からの値が含まれている全て、errorResponse オブジェクトを返す可能性があります。

| プロパティ| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| errorSource| string| エラーが発生した場所を指定します。|
| errorCode| int| (Null にすることができます) エラーに関連付けられている数値コードです。|
| エラー メッセージ| string| 詳細を表示するように構成する場合のエラーの説明します。|

<a id="ID4EIKAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EKKAC"></a>


##### <a name="parent"></a>Parent  

[/users/xuid({xuid})/inbox](uri-usersxuidinbox.md)


<a id="ID4EWKAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a>参照[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)
