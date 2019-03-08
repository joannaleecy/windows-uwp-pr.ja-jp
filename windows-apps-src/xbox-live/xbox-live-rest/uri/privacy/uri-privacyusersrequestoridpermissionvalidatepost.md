---
title: POST (/users/{requestorId}/permission/validate)
assetID: 7a5ea583-ffca-5da7-a02a-535c52535928
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidatepost.html
description: " POST (/users/{requestorId}/permission/validate)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: edd91560ffb5d81b30da4b1453612cc5853a456f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623427"
---
# <a name="post-usersrequestoridpermissionvalidate"></a>POST (/users/{requestorId}/permission/validate)
対象ユーザーのセットで指定されたアクションを実行するユーザーを許可するかどうかについての回答をはいまたは no のセットを取得します。

  * [注釈](#ID4EQ)
  * [URI パラメーター](#ID4ECB)
  * [承認](#ID4ENB)
  * [必要な要求ヘッダー](#ID4ESC)
  * [要求本文](#ID4E4D)
  * [HTTP 状態コード](#ID4ETE)
  * [必要な応答ヘッダー](#ID4EIG)
  * [応答本文](#ID4E5H)

<a id="ID4EQ"></a>


## <a name="remarks"></a>注釈

要求本文には、ユーザーの一覧と、設定の一覧と、ユーザー/設定の各ペアの許可/ブロックの結果になります。

ネットワーク間のマルチ プレーヤー シナリオ (、プライバシーに関する通信のチェックを Xbox ユーザー ID (XUID) を持つユーザーとそうでないネットワークに接続してユーザーの間実行する必要があります) でを参照してください[PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md)ユーザーの種類。

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| requestorId| string| 必須。 アクションを実行して、ユーザーの識別子。 指定できる値は<code>xuid({xuid})</code>と<code>me</code>します。 これには、ログイン ユーザーがあります。 値の例:<code>xuid(0987654321)</code>します。|

<a id="ID4ENB"></a>


## <a name="authorization"></a>Authorization

承認要求の使用 | 要求| 種類| 必須?| 値の例|
| --- | --- | --- | --- | --- | --- | --- |
| xuid| 64 ビット符号付き整数| ○| 1234567890|

<a id="ID4ESC"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例: <code>XBL3.0 x=&lt;userhash>;&lt;token></code>|
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。値の例:1. |

<a id="ID4E4D"></a>


## <a name="request-body"></a>要求本文

<a id="ID4EDE"></a>


### <a name="required-members"></a>必須メンバー

参照してください[PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md)します。


```cpp
{
    "users":
    [
        {"xuid":"12345"},
        {"xuid":"54321"}
    ],
    "permissions":
    [
        "ViewTargetGameHistory",
        "ViewTargetProfile"
    ]
}

```


<a id="ID4ETE"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得します。|
| 400| 要求が無効です。| 例: 設定が正しくない Id、Uri が正しくないなど。|
| 404| URI で指定されたユーザーは存在しません。| 指定されたリソースが見つかりませんでした。|

<a id="ID4EIG"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 要求の本文の MIME の種類。 値の例: <code>application/json</code>|
| Content-Length| string| 応答で送信されるバイト数。 値の例:34|
| キャッシュ制御| string| キャッシュの動作を指定する、サーバーから正常な要求です。 例: <code>no-cache, no-store</code>|

<a id="ID4E5H"></a>


## <a name="response-body"></a>応答本文

参照してください[PermissionCheckBatchResponse (JSON)](../../json/json-permissioncheckbatchresponse.md)します。

<a id="ID4ELAAC"></a>


### <a name="sample-response"></a>応答のサンプル


```cpp
{
    "responses":
    [
        {
            "user": {"xuid":"12345"},
            "permissions":
            [
                {
                    "isAllowed":true
                },
                {
                    "isAllowed":true
                }
            ]
        },
        {
            "user": {"xuid":"54321"},
            "permissions":
            [
                {
                    "isAllowed":false,
                    "reasons":
                    [
                        {"reason":"NotAllowed"}
                    ]
                },
                {
                    "isAllowed":false,
                    "reasons":
                    [
                        {"reason":"PrivilegeRest", "restrictedSetting":"AllowProfileViewing"}
                    ]
                }
            ]
        }
    ]
}

```


<a id="ID4EVAAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EXAAC"></a>


##### <a name="parent"></a>Parent

[/users/{requestorId}/permission/validate](uri-privacyusersrequestoridpermissionvalidate.md)

 [PermissionId 列挙型](../../enums/privacy-enum-permissionid.md)
