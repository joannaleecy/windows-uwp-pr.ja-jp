---
title: GET (/users/xuid({xuid})/inbox)
assetID: c603910d-b430-f157-2634-ceddea89f2bd
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxget.html
description: " GET (/users/xuid({xuid})/inbox)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 05f75510f15f6e6c5f1b1673673428c00f7a6c16
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632247"
---
# <a name="get-usersxuidxuidinbox"></a>GET (/users/xuid({xuid})/inbox)
サービスから、指定された数のユーザー メッセージの概要を取得します。
これらの Uri のドメインが`msg.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [クエリ文字列パラメーター](#ID4EIC)
  * [承認](#ID4EGE)
  * [リソースのプライバシーの設定の効果](#ID4ETE)
  * [HTTP 状態コード](#ID4E5E)
  * [JavaScript Object Notation (JSON) の応答](#ID4EMH)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

ユーザー メッセージ概要にはには、メッセージの件名のみが含まれています。 ユーザーが生成したメッセージの場合、これは現在メッセージ テキストの最初の 20 文字です。 システム メッセージは、「ライブ システム」などの代わりのサブジェクトを提供することができます。

メッセージが送信された順序の逆の順序で返されますつまり、新しいメッセージが最初に返されます。

この API はサポートのみコンテンツの種類は、"application/json"に必要な各呼び出しの HTTP ヘッダーが。

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。|

<a id="ID4EIC"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| プロパティ| 種類| 最大長| 注釈|
| --- | --- | --- | --- | --- | --- | --- |
| maxItems| int| 100| メッセージの最大数が返されます。|
| continuationToken| string|  | 前列挙体の呼び出しで返される文字列列挙を続行するために使用します。|
| skipItems| int| 100| をスキップするメッセージの数continuationToken が存在する場合は無視されます。|

<a id="ID4EGE"></a>


## <a name="authorization"></a>Authorization

ユーザー メッセージの概要を取得する要求、独自のユーザーが必要です。

<a id="ID4ETE"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

のみ、独自のユーザー メッセージを列挙できます。

<a id="ID4E5E"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| 要求が成功します。|
| 400| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。|
| 403| ユーザーまたはサービスは、要求することはできません。|
| 404| 有効な XUID が URI ではありません。|
| 409| 渡された継続トークンに基づいて、基になるコレクションを変更します。|
| 416| スキップする項目の数は、利用可能な項目の数を超えています。|
| 500| サーバー側の一般エラーです。|

<a id="ID4EMH"></a>


## <a name="javascript-object-notation-json-response"></a>JavaScript Object Notation (JSON) の応答

正常に呼び出されると、サービスは、JSON 形式で結果データを返します。

| プロパティ| 種類| 最大長| 注釈|
| --- | --- | --- | --- |
| 結果| メッセージの| 100| ユーザー メッセージの配列|
| pagingInfo| pagingInfo|  | 現在の結果セットのページング情報|

#### <a name="message"></a>メッセージ

| プロパティ| 種類| 最大長| 注釈|
| --- | --- | --- | --- |
| header| Header|  | ユーザー メッセージのヘッダー|
| messageSummary| string| 20| UTF-8 です。通常は最初の 20 文字のメッセージ|

#### <a name="header"></a>Header

| プロパティ| 種類| 最大長| 注釈|
| --- | --- | --- | --- |
| id| string| 50| メッセージ id、メッセージの詳細を取得またはメッセージを削除するために使用します。|
| isRead| bool|  | ユーザーがメッセージの詳細を既に読み取ることを示すフラグします。|
| 送信| DateTime|  | UTC の日付と時刻、メッセージは送信されました。 (サービスによって提供されます。)|
| 有効期限| DateTime|  | メッセージの有効期限日時 (utc)。 (すべてのメッセージによって、今後未定の最長有効期間がある)。|
| メッセージの種類| string| 50| メッセージの種類:ユーザー、システム、FriendRequest、ビデオ、QuickChat VideoChat、PartyChat、タイトル、GameInvite します。|
| senderXuid| ulong|  | 送信者の XUID です。|
| センダー| string| 15| 送信者のゲーマータグです。|
| hasAudio| bool|  | かどうか、メッセージには、音声 (音声) 添付ファイルがあります。|
| hasPhoto| bool|  | かどうか、メッセージの添付写真が。|
| hasText| bool|  | かどうか、メッセージには、テキストが含まれています。|

#### <a name="paging-info"></a>ページングの情報

| プロパティ| 種類| 最大長| 注釈|
| --- | --- | --- | --- |
| continuationToken| string| 100| 必要に応じて、サーバーによって返されます。 列挙を続けるための以降の呼び出しを許可します。|
| totalItems| int|  | 受信トレイのメッセージの合計数。|

#### <a name="sample-response"></a>応答のサンプル

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

エラーが発生した場合、サービスはサービスの環境から値を含むことができる、存在する errorResponse オブジェクトを返す可能性があります。

| プロパティ| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| errorSource| string| エラーの発生元を示します。|
| エラー コード| int| (Null にすることができます)、エラーに関連付けられている数値コードです。|
| エラー メッセージ| string| 詳細を表示するように構成してある場合、エラーの詳細です。|

<a id="ID4EIKAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EKKAC"></a>


##### <a name="parent"></a>Parent  

[/users/xuid({xuid})/inbox](uri-usersxuidinbox.md)


<a id="ID4EWKAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a>参照[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)
