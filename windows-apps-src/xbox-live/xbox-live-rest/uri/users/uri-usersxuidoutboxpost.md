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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8920641"
---
# <a name="post-usersxuidxuidoutbox"></a>POST (/users/xuid({xuid})/outbox)
受信者の一覧を指定されたメッセージを送信します。
これらの Uri のドメインが`msg.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EAB)
  * [Authorization](#ID4ENB)
  * [リソースのプライバシーの設定の効果](#ID4EYB)
  * [要求本文](#ID4E3F)
  * [HTTP ステータス コード](#ID4ETCAC)
  * [応答本文](#ID4E1EAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

この API はサポートのみのコンテンツの種類は、"アプリケーション/json"、呼び出しごとの HTTP ヘッダーのために必要です。

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| xuid | 64 ビットの符号なし整数 | Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。 |

<a id="ID4ENB"></a>


## <a name="authorization"></a>Authorization

ユーザーのメッセージを送信するには、ユーザーの要求と有効なゴールド サブスクリプションが必要です。

<a id="ID4EYB"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

正常にメッセージを送信するユーザー、プレイヤーにかどうかプレイヤーの友人、結果 200 の結果コード。 ただし、によりブロックされている他の人物にメッセージを送信する場合、受信側では、メッセージは表示されませんが、メッセージが成功したことを示すは表示されません。

メッセージ数に送信できると 1 日あたり数のフレンドとフレンド以外の場合、次のようにはも制限があります。

   * メッセージあたり 20 見知らぬユーザー
   * 24 時間ごと 200 見知らぬユーザー
   * 24 時間ごとに 250 の合計メッセージ
   * 2500 24 時間ごとの受信者を合計します。

| ユーザーの要求| ターゲット ユーザーのプライバシー設定| 動作|
| --- | --- | --- | --- | --- | --- |
| me| -| 前述のようにします。|
| フレンド登録の依頼| すべてのユーザー| 200 OK|
| フレンド登録の依頼| フレンドのみ| 200 OK|
| フレンド登録の依頼| ブロック| 200 OK|
| フレンド以外のユーザー| すべてのユーザー| 200 OK|
| フレンド以外のユーザー| フレンドのみ| 200 OK|
| フレンド以外のユーザー| ブロック| 200 OK|
| サード パーティのサイト| すべてのユーザー| 200 OK|
| サード パーティのサイト| フレンドのみ| 200 OK|
| サード パーティのサイト| ブロック| 200 OK|

<a id="ID4E3F"></a>


## <a name="request-body"></a>要求本文

| プロパティ| 型| 最大長| 消費者| 注釈|
| --- | --- | --- | --- | --- |
| header| ヘッダー|  | すべての| ユーザーのメッセージのヘッダー|
| メッセージ テキスト| string| 250| Windows 8 を除くすべてのプラットフォーム| ユーザーのメッセージ テキスト (utf-8)|

#### <a name="header"></a>ヘッダー

| プロパティ| 型| 最大長| 消費者| 注釈|
| --- | --- | --- | --- | --- |
| 受信者| ユーザーの| 20| すべての| メッセージの受信者の一覧|

#### <a name="user"></a>ユーザー

| プロパティ| 型| 最大長| 消費者| 注釈|
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


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| 成功します。|
| 400| 受信者の一覧が空または最大の長さを超えています。または、ゲーマータグと XUID の両方が指定されました。または、メッセージ テキストが長すぎます。|
| 403| XUID を変換することはできません。|
| 404| ゲーマータグが無効であるか、ユーザーが見つからない。|
| 409| ユーザーは、システムによって 1 日あたりの制限に達したします。|
| 500| サーバー側の一般的なエラーです。|

<a id="ID4E1EAC"></a>


## <a name="response-body"></a>応答本文

応答の本文には、オブジェクトは送信されません。

<a id="ID4EJFAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ELFAC"></a>


##### <a name="parent"></a>Parent  

[/users/xuid({xuid})/outbox](uri-usersxuidoutbox.md)


<a id="ID4EZFAC"></a>


##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a>参照[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)
