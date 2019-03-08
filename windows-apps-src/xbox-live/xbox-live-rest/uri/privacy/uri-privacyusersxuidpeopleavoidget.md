---
title: GET (/users/{ownerId}/people/avoid)
assetID: e3420658-4738-8e80-44da-8281726fce01
permalink: en-us/docs/xboxlive/rest/uri-privacyusersxuidpeopleavoidget.html
description: " GET (/users/{ownerId}/people/avoid)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 745893b4b975b5fbf64fe76591ec15d18af59d73
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641617"
---
# <a name="get-usersowneridpeopleavoid"></a>GET (/users/{ownerId}/people/avoid)
ユーザーの避け一覧を取得します。

  * [注釈](#ID4EQ)
  * [URI パラメーター](#ID4EZ)
  * [承認](#ID4EEB)
  * [必要な要求ヘッダー](#ID4EJC)
  * [HTTP 状態コード](#ID4EYD)
  * [必要な応答ヘッダー](#ID4E1F)
  * [応答本文](#ID4ESH)

<a id="ID4EQ"></a>


## <a name="remarks"></a>注釈

ターゲットを指定した場合はしていないかどうか、ブロック一覧に、空である場合にのみそのユーザーを返します。

<a id="ID4EZ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| ownerId| string| 必須。 リソースがアクセスされているユーザーの識別子。 指定できる値は<code>xuid({xuid})</code>します。 認証されたユーザーである必要があります。 値の例:<code>xuid(2603643534573581)</code>します。 最大サイズ: なし。 |

<a id="ID4EEB"></a>


## <a name="authorization"></a>Authorization

承認要求の使用 | 要求| 種類| 必須?| 値の例|
| --- | --- | --- | --- | --- | --- | --- |
| xuid| 64 ビット符号付き整数| ○| 1234567890|

<a id="ID4EJC"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization | string| HTTP 認証の資格情報を認証します。 値の例:<code>Xauth=&lt;authtoken></code>します。 最大サイズ: なし。|
| OK| string| コンテンツ型が許容されます。 値の例:<code>application/json</code>します。 最大サイズ: なし。|

<a id="ID4EYD"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得します。|
| 400| 要求が正しくありません| URI で指定されたターゲットの ID が無効です。|
| 403| Forbidden| URI で指定された所有者は、認証されたユーザーではありません。|
| 404| 検出不可| URI で指定された所有者が存在しません。|

<a id="ID4E1F"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 要求の本文の MIME の種類。 値の例:<code>application/json</code>します。 最大サイズ: なし。|
| Content-Length| string| 応答で送信されるバイト数。 値の例:34. 最大サイズ: なし。|
| キャッシュ制御| string| キャッシュの動作を指定する、サーバーから正常な要求です。 値の例:<code>application/json</code>します。 最大サイズ: なし。|

<a id="ID4ESH"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EYH"></a>


### <a name="sample-response"></a>応答のサンプル


```cpp
{
    "users":
    [
        { "xuid":"12345" },
        { "xuid":"23456" }
    ]
}

```


<a id="ID4EDAAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EFAAC"></a>


##### <a name="parent"></a>Parent

[/users/{ownerId}/people/avoid](uri-privacyusersxuidpeopleavoid.md)
