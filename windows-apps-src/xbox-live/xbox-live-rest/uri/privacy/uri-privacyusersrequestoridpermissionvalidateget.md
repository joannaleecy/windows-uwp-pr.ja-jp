---
title: GET (/users/{requestorId}/permission/validate)
assetID: 8d22c668-af9a-1d24-8d65-830c2ce913d7
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidateget.html
author: KevinAsgari
description: " GET (/users/{requestorId}/permission/validate)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5e0ec0b8b4de64a5580ffdd83407602ee410da9c
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5834360"
---
# <a name="get-usersrequestoridpermissionvalidate"></a>GET (/users/{requestorId}/permission/validate)
ユーザーをターゲット ユーザーと、指定されたアクションの実行を許可するかどうかに関するはいまたは no 応答を取得します。

  * [URI パラメーター](#ID4EQ)
  * [クエリ文字列パラメーター](#ID4E2)
  * [Authorization](#ID4EDC)
  * [必要な要求ヘッダー](#ID4EID)
  * [要求本文](#ID4ETE)
  * [HTTP ステータス コード](#ID4E5E)
  * [必要な応答ヘッダー](#ID4ETG)
  * [応答本文](#ID4EKAAC)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| requestorId| string| 必須。 アクションを実行するユーザーの識別子です。 設定可能な値は<code>xuid({xuid})</code>と<code>me</code>します。 これは、ログインしているユーザーでなければなりません。 値の例:<code>xuid(0987654321)</code>します。|

<a id="ID4E2"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- | --- |
| 設定| 文字列の列挙| 照らしてチェックする PermissionId 値。 値の例:"CommunicateUsingText"します。|
| ターゲット| string| 実行するユーザーの操作では、ユーザーの識別子です。 設定可能な値は<code>xuid({xuid})</code>します。 値の例: <code>xuid(0987654321)</code>|

<a id="ID4EDC"></a>


## <a name="authorization"></a>Authorization

承認要求の使用 | 要求| 種類| 必須?| 値の例|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Xuid| 64 ビットの符号付き整数| 必須| 1234567890|

<a id="ID4EID"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例: <code>XBL3.0 x=&lt;userhash>;&lt;token></code>|
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。値の例: 1 です。|

<a id="ID4ETE"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E5E"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得されました。|
| 400| 要求が無効です。| 例: が正しく設定 Id、不適切な Uri などです。|
| 404| URI で指定されたユーザーが存在しません。| 指定されたリソースは見つかりませんでした。|

<a id="ID4ETG"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 要求の本文の MIME タイプ。 値の例: <code>application/json</code>|
| Content-Length| string| 応答に送信されるバイト数。 値の例: 34|
| キャッシュ コントロール| string| キャッシュ動作を指定するサーバーからていねい要求します。 例: <code>no-cache, no-store</code>|

<a id="ID4EKAAC"></a>


## <a name="response-body"></a>応答本文

[PermissionCheckResponse (JSON)](../../json/json-permissioncheckresponse.md)を参照してください。

<a id="ID4EWAAC"></a>


### <a name="sample-response"></a>応答の例


```cpp
{
    "isAllowed": false,
    "reasons":
    [
        {"reason": "BlockedByRequestor"},
        {"reason": "MissingPrivilege", "restrictedSetting": "VideoCommunications"}
    ]
}

```


<a id="ID4EABAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ECBAC"></a>


##### <a name="parent"></a>Parent

[/users/{requestorId}/permission/validate](uri-privacyusersrequestoridpermissionvalidate.md)

 [PermissionId 列挙型](../../enums/privacy-enum-permissionid.md)
