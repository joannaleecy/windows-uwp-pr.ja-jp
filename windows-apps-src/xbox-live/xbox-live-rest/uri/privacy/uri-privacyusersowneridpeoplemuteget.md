---
title: GET (/users/{ownerId}/people/mute)
assetID: 49b6c830-95f7-3200-0e46-0a1af573971c
permalink: en-us/docs/xboxlive/rest/uri-privacyusersowneridpeoplemuteget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/people/mute)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: af9f52e04a163e0839017e1d051653d968df816d
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4313569"
---
# <a name="get-usersowneridpeoplemute"></a>GET (/users/{ownerId}/people/mute)
ユーザーのミュートの一覧を取得します。

  * [注釈](#ID4EQ)
  * [URI パラメーター](#ID4EZ)
  * [リソースのプライバシーの設定の効果](#ID4EEB)
  * [Authorization](#ID4ENB)
  * [必要な要求ヘッダー](#ID4ESC)
  * [要求本文](#ID4EPE)
  * [HTTP ステータス コード](#ID4E1E)
  * [必要な応答ヘッダー](#ID4E3G)
  * [応答本文](#ID4ETAAC)

<a id="ID4EQ"></a>


## <a name="remarks"></a>注釈

この URI にターゲットを指定すると、ユーザーがない場合、ユーザーがミュートの一覧で、空の場合のみ、そのユーザーを返します。

<a id="ID4EZ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| ownerId| string| 必須。 そのリソースにアクセスしているユーザーの識別子です。 設定可能な値は"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。 認証されたユーザーである必要があります。 値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。 最大サイズ: なし。 |

<a id="ID4EEB"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

なし。

<a id="ID4ENB"></a>


## <a name="authorization"></a>Authorization

承認要求の使用 | 要求| 種類| 必須?| 値の例|
| --- | --- | --- | --- | --- | --- | --- |
| Xuid| 64 ビットの符号付き整数| 必須| 1234567890|

<a id="ID4ESC"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization | string| HTTP 認証の資格情報を認証します。 値の例:<code>Xauth=&lt;authtoken></code>します。 最大サイズ: なし。|
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 値の例: <code>1</code>、<code>vnext</code>します。 最大サイズ: なし。|
| Accept| string| コンテンツの種類の受け入れられるします。 値の例:<code>application/json</code>します。 最大サイズ: なし。|

<a id="ID4EPE"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E1E"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| ミュート リストの要求が成功した場合。|
| 400| Bad Request| URI で指定されたターゲット ID が正しくありません。|
| 403| Forbidden| URI で指定された所有者は、認証されたユーザーではありません。|
| 404| Not Found します。| URI で指定された所有者は存在しません。|

<a id="ID4E3G"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 要求の本文の MIME タイプ。 値の例: <code>application/json</code>|
| Content-Length| string| 応答に送信されるバイト数。 値の例: 34|
| キャッシュ コントロール| string| キャッシュ動作を指定するサーバーからていねい要求します。 例: <code>no-cache, no-store</code>|

<a id="ID4ETAAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EZAAC"></a>


### <a name="sample-response"></a>応答の例

[UserList](../../json/json-userlist.md)を参照してください。


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
