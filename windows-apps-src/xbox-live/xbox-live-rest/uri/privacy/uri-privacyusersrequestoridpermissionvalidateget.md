---
title: GET (/users/{requestorId}/permission/validate)
assetID: 8d22c668-af9a-1d24-8d65-830c2ce913d7
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidateget.html
description: " GET (/users/{requestorId}/permission/validate)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 07ccac63b3e6681ea35405314b0cd8b93aa60f9a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594757"
---
# <a name="get-usersrequestoridpermissionvalidate"></a>GET (/users/{requestorId}/permission/validate)
対象ユーザーと指定したアクションを実行するユーザーを許可するかどうかについてはいまたは no 応答を取得します。

  * [URI パラメーター](#ID4EQ)
  * [クエリ文字列パラメーター](#ID4E2)
  * [承認](#ID4EDC)
  * [必要な要求ヘッダー](#ID4EID)
  * [要求本文](#ID4ETE)
  * [HTTP 状態コード](#ID4E5E)
  * [必要な応答ヘッダー](#ID4ETG)
  * [応答本文](#ID4EKAAC)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| requestorId| string| 必須。 アクションを実行して、ユーザーの識別子。 指定できる値は<code>xuid({xuid})</code>と<code>me</code>します。 これには、ログイン ユーザーがあります。 値の例:<code>xuid(0987654321)</code>します。|

<a id="ID4E2"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- | --- |
| 設定| 文字列の列挙型| 照合する PermissionId 値。 値の例:"CommunicateUsingText"。|
| target| string| アクションの実行対象のユーザーの識別子。 指定できる値は<code>xuid({xuid})</code>します。 値の例: <code>xuid(0987654321)</code>|

<a id="ID4EDC"></a>


## <a name="authorization"></a>Authorization

承認要求の使用 | 要求| 種類| 必須?| 値の例|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| xuid| 64 ビット符号付き整数| ○| 1234567890|

<a id="ID4EID"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例: <code>XBL3.0 x=&lt;userhash>;&lt;token></code>|
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。値の例:1. |

<a id="ID4ETE"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E5E"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得します。|
| 400| 要求が無効です。| 例: 設定が正しくない Id、Uri が正しくないなど。|
| 404| URI で指定されたユーザーは存在しません。| 指定されたリソースが見つかりませんでした。|

<a id="ID4ETG"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 要求の本文の MIME の種類。 値の例: <code>application/json</code>|
| Content-Length| string| 応答で送信されるバイト数。 値の例:34|
| キャッシュ制御| string| キャッシュの動作を指定する、サーバーから正常な要求です。 例: <code>no-cache, no-store</code>|

<a id="ID4EKAAC"></a>


## <a name="response-body"></a>応答本文

参照してください[PermissionCheckResponse (JSON)](../../json/json-permissioncheckresponse.md)します。

<a id="ID4EWAAC"></a>


### <a name="sample-response"></a>応答のサンプル


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
