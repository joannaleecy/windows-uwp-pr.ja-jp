---
title: GET (/users/{ownerId}/people/avoid)
assetID: e3420658-4738-8e80-44da-8281726fce01
permalink: en-us/docs/xboxlive/rest/uri-privacyusersxuidpeopleavoidget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/people/avoid)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 68237ed101870a8fed4b7b5fb298006f784a0910
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5700260"
---
# <a name="get-usersowneridpeopleavoid"></a>GET (/users/{ownerId}/people/avoid)
ユーザーの回避一覧を取得します。

  * [注釈](#ID4EQ)
  * [URI パラメーター](#ID4EZ)
  * [Authorization](#ID4EEB)
  * [必要な要求ヘッダー](#ID4EJC)
  * [HTTP ステータス コード](#ID4EYD)
  * [必要な応答ヘッダー](#ID4E1F)
  * [応答本文](#ID4ESH)

<a id="ID4EQ"></a>


## <a name="remarks"></a>注釈

ターゲットを指定するはしている場合、ブロックの一覧に、空いないいるかどうかにのみそのユーザーを返します。

<a id="ID4EZ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| ownerId| string| 必須。 そのリソースにアクセスしているユーザーの識別子です。 設定可能な値は<code>xuid({xuid})</code>します。 認証されたユーザーである必要があります。 値の例:<code>xuid(2603643534573581)</code>します。 最大サイズ: なし。 |

<a id="ID4EEB"></a>


## <a name="authorization"></a>Authorization

承認要求の使用 | 要求| 種類| 必須?| 値の例|
| --- | --- | --- | --- | --- | --- | --- |
| Xuid| 64 ビットの符号付き整数| 必須| 1234567890|

<a id="ID4EJC"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization | string| HTTP の認証の資格情報を認証します。 値の例:<code>Xauth=&lt;authtoken></code>します。 最大サイズ: なし。|
| Accept| string| コンテンツの種類の受け入れられるします。 値の例:<code>application/json</code>します。 最大サイズ: なし。|

<a id="ID4EYD"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得されました。|
| 400| Bad Request| URI で指定されたターゲット ID が正しくありません。|
| 403| Forbidden| URI で指定された所有者は、認証されたユーザーではありません。|
| 404| Not Found します。| URI で指定された所有者は存在しません。|

<a id="ID4E1F"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 要求の本文の MIME タイプ。 値の例:<code>application/json</code>します。 最大サイズ: なし。|
| Content-Length| string| 応答に送信されるバイト数。 値の例: 34 します。 最大サイズ: なし。|
| キャッシュ コントロール| string| キャッシュ動作を指定するサーバーからていねい要求します。 値の例:<code>application/json</code>します。 最大サイズ: なし。|

<a id="ID4ESH"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EYH"></a>


### <a name="sample-response"></a>応答の例


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
