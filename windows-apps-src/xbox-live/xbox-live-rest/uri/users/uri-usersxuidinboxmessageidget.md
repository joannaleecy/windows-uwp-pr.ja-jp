---
title: GET (/users/xuid({xuid})/inbox/{messageId})
assetID: d76563d0-2c74-0308-054b-762c80392a02
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxmessageidget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/inbox/{messageId})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e3885caae38d1ce69d3ae8e6f7d8de8839cb30ef
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5755344"
---
# <a name="get-usersxuidxuidinboxmessageid"></a>GET (/users/xuid({xuid})/inbox/{messageId})
サービスでの読み取りとしてマークすること、特定のユーザーのメッセージの詳細なメッセージ テキストを取得します。
これらの Uri のドメインが`msg.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [Authorization](#ID4ERB)
  * [要求本文](#ID4E3B)
  * [リソースのプライバシーの設定の効果](#ID4EJC)
  * [HTTP ステータス コード](#ID4EUC)
  * [JavaScript Object Notation (JSON) の応答](#ID4EUE)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

Get 操作は、ユーザー、システム、および FriendRequest メッセージの種類でのみ実行できます。

この URI には、Xbox.com に更新が必要です。 現時点では、Xbox 360 は、状態を更新読み取り/未読メに戻すまで、ユーザーがサインアウトしたとします。

この API はサポートのみのコンテンツの種類は、"アプリケーション/json"、呼び出しごとの HTTP ヘッダーのために必要です。

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| xuid | 64 ビットの符号なし整数 | Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。 |
| メッセージ Id | 文字列 [50] | 取得または削除されるメッセージの ID です。 |

<a id="ID4ERB"></a>


## <a name="authorization"></a>Authorization

独自のユーザーがユーザーのメッセージを取得する要求が必要です。

<a id="ID4E3B"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EJC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

のみ、独自のユーザーのメッセージを取得できます。

<a id="ID4EUC"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 説明|
| --- | --- | --- | --- | --- |
| 200| 成功します。|
| 400| XUID を適切に変換することはできません。|
| 403| XUID に変換することはできませんか、有効な XUID クレームが見つかったことはできません。|
| 404| 有効な XUID が見つからないか、またはメッセージ ID が見つからないか、解析されます。|
| 500| サーバー側の一般的なエラー、またはメッセージの種類は、GET に対して有効ではありません。|

<a id="ID4EUE"></a>


## <a name="javascript-object-notation-json-response"></a>JavaScript Object Notation (JSON) の応答

正常に呼び出されると、サービスは結果データを JSON 形式で返します。 ルート オブジェクトは、UserMessageHeader オブジェクトです。

#### <a name="usermessageheader"></a>UserMessageHeader

| プロパティ| 型| 最大長| 注釈|
| --- | --- | --- | --- |
| header| ヘッダー|  | JSON オブジェクト|
| メッセージ テキスト| string| 256| UTF-8|

#### <a name="header"></a>ヘッダー

| プロパティ| 型| 最大長| 注釈|
| --- | --- | --- | --- |
| 送信| DateTime|  | 日付と時刻は、メッセージが送信されました。 (サービスによって提供されます)。|
| 有効期限| DateTime|  | 日付と時刻のメッセージの有効期限が切れます。 (すべてのメッセージによって、将来的に決定する、最長有効期間がある)。|
| メッセージの種類| string| 13| メッセージの種類: ユーザー、システム、FriendRequest します。|
| senderXuid| ulong|  | 送信者の XUID です。|
| 送信者| string| 15| 送信者のゲーマータグです。|
| hasAudio| bool|  | かどうか、メッセージには、オーディオ (声) 添付ファイルがあります。|
| hasPhoto| bool|  | メッセージに写真の添付ファイルがあるかどうか。|
| hasText| bool|  | かどうか、メッセージには、テキストが含まれています。|

#### <a name="sample-response"></a>応答の例

```cpp
{
          "header":
          {
            "expiration":"2011-10-11T23:59:59.9999999",
            "messageType":"User",
            "senderXuid":"123456789",
            "sender":"Striker",
            "sent":"2011-05-08T17:30:00Z",
            "hasAudio":false,
            "hasPhoto":false,
            "hasText":true
          },
        "messageText":"random user text up to 256 characters"
        }

```

#### <a name="error-response"></a>エラー応答

エラーの場合、サービスは、サービスの環境から値を含めることができますが、全て、errorResponse オブジェクトを返すことがあります。

| プロパティ| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| errorSource| string| エラーが発生した場所を指定します。|
| errorCode| int| (Null にすることができます)、エラーに関連付けられている数値コードです。|
| エラー メッセージ| string| 詳細を表示するように構成する場合のエラーの説明します。|

<a id="ID4E3DAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E5DAC"></a>


##### <a name="parent"></a>Parent  

[/users/xuid({xuid})/inbox](uri-usersxuidinbox.md)


<a id="ID4EMEAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a>参照[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)
