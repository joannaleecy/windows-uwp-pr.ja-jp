---
title: POST (/users/xuid({xuid})/outbox)
assetID: de991d88-efe0-04f2-f6b2-0bc3e68bfd46
permalink: en-us/docs/xboxlive/rest/uri-usersxuidoutboxpost.html
description: " POST (/users/xuid({xuid})/outbox)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2b225e8441fee3d499f172e2e5701096cdbc161a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594287"
---
# <a name="post-usersxuidxuidoutbox"></a>POST (/users/xuid({xuid})/outbox)
受信者の一覧を指定したメッセージを送信します。
これらの Uri のドメインが`msg.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EAB)
  * [承認](#ID4ENB)
  * [リソースのプライバシーの設定の効果](#ID4EYB)
  * [要求本文](#ID4E3F)
  * [HTTP 状態コード](#ID4ETCAC)
  * [応答本文](#ID4E1EAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

この API はサポートのみコンテンツの種類は、"application/json"に必要な各呼び出しの HTTP ヘッダーが。

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| xuid | 64 ビット符号なし整数 | Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。 |

<a id="ID4ENB"></a>


## <a name="authorization"></a>Authorization

ユーザー メッセージを送信するには、独自のユーザー要求とゴールドの有効なサブスクリプションが必要です。

<a id="ID4EYB"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

結果コード 200 の結果か、そのプレイヤーがフレンドかどうかをプレーヤーにユーザー メッセージを正常に送信します。 ただし、ブロックした人にメッセージを送信する場合、受信者は、メッセージを受け取りません、任意のメッセージが成功したことを示す値を受け取りません。

メッセージの数に送信できますと 1 日あたり数の友人や友人以外の場合、次のようには制限もあります。

   * メッセージあたり 20 知らない
   * 24 時間あたり 200 知らない
   * 24 時間ごとに 250 の合計メッセージ
   * 24 時間あたり 2500 人の受信者

| 要求元のユーザー| ターゲット ユーザーのプライバシーの設定| 動作|
| --- | --- | --- | --- | --- | --- |
| Me| -| 前述のようにします。|
| friend| すべてのユーザー| 200 OK|
| friend| 友達のみ| 200 OK|
| friend| ブロック済み| 200 OK|
| フレンド以外のユーザー| すべてのユーザー| 200 OK|
| フレンド以外のユーザー| 友達のみ| 200 OK|
| フレンド以外のユーザー| ブロック済み| 200 OK|
| サード パーティのサイト| すべてのユーザー| 200 OK|
| サード パーティのサイト| 友達のみ| 200 OK|
| サード パーティのサイト| ブロック済み| 200 OK|

<a id="ID4E3F"></a>


## <a name="request-body"></a>要求本文

| プロパティ| 種類| 最大長| コンシューマー| 注釈|
| --- | --- | --- | --- | --- |
| header| Header|  | すべての| ユーザー メッセージのヘッダー|
| メッセージ テキスト| string| 250| Windows 8 を除くすべてのプラットフォーム| ユーザー メッセージ テキスト (utf-8)|

#### <a name="header"></a>Header

| プロパティ| 種類| 最大長| コンシューマー| 注釈|
| --- | --- | --- | --- | --- |
| 受信者| ユーザーの| 20| すべての| メッセージの受信者の一覧|

#### <a name="user"></a>ユーザー

| プロパティ| 種類| 最大長| コンシューマー| 注釈|
| --- | --- | --- | --- | --- |
| xuid| ulong|  | すべての| 受信者はの XUID です。 ゲーマータグが送信される場合は使用されません。|
| ゲーマータグ| string| 15| すべての| 受信者のゲーマータグです。 XUID が送信される場合は使用されません。|

#### <a name="sample-request-body"></a>要求本文のサンプル 

```cpp
{
          "header":
          {
            "recipients":
            [{"gamertag":"GoTeamEmily"},
            {"gamertag":"Longstreet360"}]
          },
          "messageText":"random user text"
        }

```


<a id="ID4ETCAC"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| 成功しました。|
| 400| 受信者の一覧が空か、最大長を超えています。または、ゲーマータグと XUID の両方が指定されました。または、メッセージ テキストが長すぎます。|
| 403| XUID を変換することはできません。|
| 404| ゲーマータグが正しくないか、ユーザーが見つかりません。|
| 409| ユーザーは、システムによる 1 日の上限に達しました。|
| 500| サーバー側の一般エラーです。|

<a id="ID4E1EAC"></a>


## <a name="response-body"></a>応答本文

応答の本文では、オブジェクトは送信されません。

<a id="ID4EJFAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ELFAC"></a>


##### <a name="parent"></a>Parent  

[/users/xuid({xuid})/outbox](uri-usersxuidoutbox.md)


<a id="ID4EZFAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a>参照[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)
