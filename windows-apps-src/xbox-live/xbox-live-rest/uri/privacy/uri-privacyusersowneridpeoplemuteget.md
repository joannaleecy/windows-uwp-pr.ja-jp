---
title: GET (/users/{ownerId}/people/mute)
assetID: 49b6c830-95f7-3200-0e46-0a1af573971c
permalink: en-us/docs/xboxlive/rest/uri-privacyusersowneridpeoplemuteget.html
description: " GET (/users/{ownerId}/people/mute)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 94e2bf4d04619ffa3348ae08fc37964cdc58e7b5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661587"
---
# <a name="get-usersowneridpeoplemute"></a>GET (/users/{ownerId}/people/mute)
ユーザーのミュートの一覧を取得します。

  * [注釈](#ID4EQ)
  * [URI パラメーター](#ID4EZ)
  * [リソースのプライバシーの設定の効果](#ID4EEB)
  * [承認](#ID4ENB)
  * [必要な要求ヘッダー](#ID4ESC)
  * [要求本文](#ID4EPE)
  * [HTTP 状態コード](#ID4E1E)
  * [必要な応答ヘッダー](#ID4E3G)
  * [応答本文](#ID4ETAAC)

<a id="ID4EQ"></a>


## <a name="remarks"></a>注釈

この URI にターゲットを指定した場合、ユーザーがない場合、ユーザーがミュートの一覧で、空の場合のみ、そのユーザーを返します。

<a id="ID4EZ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| ownerId| string| 必須。 リソースがアクセスされているユーザーの識別子。 使用可能な値は"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。 認証されたユーザーである必要があります。 値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。 最大サイズ: なし。 |

<a id="ID4EEB"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

なし。

<a id="ID4ENB"></a>


## <a name="authorization"></a>Authorization

承認要求の使用 | 要求| 種類| 必須?| 値の例|
| --- | --- | --- | --- | --- | --- | --- |
| xuid| 64 ビット符号付き整数| ○| 1234567890|

<a id="ID4ESC"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization | string| HTTP 認証の資格情報を認証します。 値の例:<code>Xauth=&lt;authtoken></code>します。 最大サイズ: なし。|
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングと、ヘッダー、承認トークンでクレームの妥当性を確認した後のサービスします。 値の例: <code>1</code>、<code>vnext</code>します。 最大サイズ: なし。|
| OK| string| コンテンツ型が許容されます。 値の例:<code>application/json</code>します。 最大サイズ: なし。|

<a id="ID4EPE"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E1E"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| ミュートのリストの要求が成功した場合。|
| 400| 要求が正しくありません| URI で指定されたターゲットの ID が無効です。|
| 403| Forbidden| URI で指定された所有者は、認証されたユーザーではありません。|
| 404| 検出不可| URI で指定された所有者が存在しません。|

<a id="ID4E3G"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 要求の本文の MIME の種類。 値の例: <code>application/json</code>|
| Content-Length| string| 応答で送信されるバイト数。 値の例:34|
| キャッシュ制御| string| キャッシュの動作を指定する、サーバーから正常な要求です。 例: <code>no-cache, no-store</code>|

<a id="ID4ETAAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EZAAC"></a>


### <a name="sample-response"></a>応答のサンプル

参照してください[UserList](../../json/json-userlist.md)します。


```cpp
{
    "users":
    [
        { "xuid":"12345" },
        { "xuid":"23456" }
    ]
}

```


<a id="ID4EJBAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ELBAC"></a>


##### <a name="parent"></a>Parent

[/users/{ownerId}/people/mute](uri-privacyusersowneridpeoplemute.md)
