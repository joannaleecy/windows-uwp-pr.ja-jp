---
title: GET (/users/xuid({xuid})/inbox/{messageId})
assetID: d76563d0-2c74-0308-054b-762c80392a02
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxmessageidget.html
description: " GET (/users/xuid({xuid})/inbox/{messageId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 29b4c57468148a431a10e0d74f85d360ff0992b3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618057"
---
# <a name="get-usersxuidxuidinboxmessageid"></a>GET (/users/xuid({xuid})/inbox/{messageId})
開封済みにサービスで、特定のユーザー メッセージの詳細なメッセージ テキストを取得します。
これらの Uri のドメインが`msg.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [承認](#ID4ERB)
  * [要求本文](#ID4E3B)
  * [リソースのプライバシーの設定の効果](#ID4EJC)
  * [HTTP 状態コード](#ID4EUC)
  * [JavaScript Object Notation (JSON) の応答](#ID4EUE)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

取得操作は、ユーザー、システム、および FriendRequest メッセージの種類でのみ実行できます。

この URI には、Xbox.com での更新が必要です。 現時点では、ユーザーがサインアウトするまでに戻り、Xbox 360 は読み取り/未読の状態を更新できません。

この API はサポートのみコンテンツの種類は、"application/json"に必要な各呼び出しの HTTP ヘッダーが。

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| xuid | 64 ビット符号なし整数 | Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。 |
| メッセージ Id | string[50] | メッセージの取得中または削除の ID。 |

<a id="ID4ERB"></a>


## <a name="authorization"></a>Authorization

ユーザー メッセージを取得する要求、独自のユーザーが必要です。

<a id="ID4E3B"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EJC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

のみ、独自のユーザー メッセージを取得できます。

<a id="ID4EUC"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 説明|
| --- | --- | --- | --- | --- |
| 200| 成功しました。|
| 400| XUID を適切に変換することはできません。|
| 403| XUID を変換することはできませんまたは有効な XUID 要求が見つかりません。|
| 404| 有効な XUID が存在しないか、メッセージ ID が見つからないか、正しく解析されます。|
| 500| 一般的なサーバー側のエラー、またはメッセージの種類は、GET の無効です。|

<a id="ID4EUE"></a>


## <a name="javascript-object-notation-json-response"></a>JavaScript Object Notation (JSON) の応答

正常に呼び出されると、サービスは、JSON 形式で結果データを返します。 ルート オブジェクトは、UserMessageHeader オブジェクトです。

#### <a name="usermessageheader"></a>UserMessageHeader

| プロパティ| 種類| 最大長| 注釈|
| --- | --- | --- | --- |
| header| Header|  | JSON オブジェクト|
| メッセージ テキスト| string| 256| UTF-8|

#### <a name="header"></a>Header

| プロパティ| 種類| 最大長| 注釈|
| --- | --- | --- | --- |
| 送信| DateTime|  | 日付と時刻、メッセージは送信されました。 (サービスによって提供されます。)|
| 有効期限| DateTime|  | 日付と時刻、メッセージの有効期限が切れます。 (すべてのメッセージによって、今後未定の最長有効期間がある)。|
| メッセージの種類| string| 13| メッセージの種類:ユーザー、システム、FriendRequest します。|
| senderXuid| ulong|  | 送信者の XUID です。|
| センダー| string| 15| 送信者のゲーマータグです。|
| hasAudio| bool|  | かどうか、メッセージには、音声 (音声) 添付ファイルがあります。|
| hasPhoto| bool|  | かどうか、メッセージの添付写真が。|
| hasText| bool|  | かどうか、メッセージには、テキストが含まれています。|

#### <a name="sample-response"></a>応答のサンプル

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

エラーが発生した場合、サービスはサービスの環境から値を含むことができる、存在する errorResponse オブジェクトを返す可能性があります。

| プロパティ| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| errorSource| string| エラーの発生元を示します。|
| エラー コード| int| (Null にすることができます)、エラーに関連付けられている数値コードです。|
| エラー メッセージ| string| 詳細を表示するように構成してある場合、エラーの詳細です。|

<a id="ID4E3DAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E5DAC"></a>


##### <a name="parent"></a>Parent  

[/users/xuid({xuid})/inbox](uri-usersxuidinbox.md)


<a id="ID4EMEAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a>参照[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)
