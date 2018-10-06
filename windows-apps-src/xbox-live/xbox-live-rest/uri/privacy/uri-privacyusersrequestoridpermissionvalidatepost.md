---
title: POST (/users/{requestorId}/permission/validate)
assetID: 7a5ea583-ffca-5da7-a02a-535c52535928
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidatepost.html
author: KevinAsgari
description: " POST (/users/{requestorId}/permission/validate)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: edffbbff7fb9cd5fc4e471a6af1f494f4a35ea57
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4390753"
---
# <a name="post-usersrequestoridpermissionvalidate"></a>POST (/users/{requestorId}/permission/validate)
一連のユーザーをターゲット ユーザーのセットを指定したアクションを実行できるかどうかに関するはいまたは no 回答を取得します。

  * [注釈](#ID4EQ)
  * [URI パラメーター](#ID4ECB)
  * [Authorization](#ID4ENB)
  * [必要な要求ヘッダー](#ID4ESC)
  * [要求本文](#ID4E4D)
  * [HTTP ステータス コード](#ID4ETE)
  * [必要な応答ヘッダー](#ID4EIG)
  * [応答本文](#ID4E5H)

<a id="ID4EQ"></a>


## <a name="remarks"></a>注釈

要求本文には、ユーザーの一覧と、設定の一覧と、各ユーザーの設定/ペアの許可/ブロックの結果になります。

クロス ネットワーク マルチプレイヤー シナリオ (場所プライバシー通信チェックを Xbox ユーザー ID (XUID) のユーザーとそうでないネットワークに接続してユーザーの間で実行する必要があります) でユーザーの種類の[PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md)を参照してください。

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| requestorId| string| 必須。 アクションを実行するユーザーの識別子です。 設定可能な値は<code>xuid({xuid})</code>と<code>me</code>します。 これは、ログインしているユーザーでなければなりません。 値の例:<code>xuid(0987654321)</code>します。|

<a id="ID4ENB"></a>


## <a name="authorization"></a>Authorization

承認要求の使用 | 要求| 種類| 必須?| 値の例|
| --- | --- | --- | --- | --- | --- | --- |
| Xuid| 64 ビットの符号付き整数| 必須| 1234567890|

<a id="ID4ESC"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例: <code>XBL3.0 x=&lt;userhash>;&lt;token></code>|
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。値の例: 1 です。|

<a id="ID4E4D"></a>


## <a name="request-body"></a>要求本文

<a id="ID4EDE"></a>


### <a name="required-members"></a>必要なメンバー

[PermissionCheckBatchRequest (JSON)](../../json/json-permissioncheckbatchrequest.md)を参照してください。


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


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得されました。|
| 400| 要求が無効です。| 例: が正しく設定 Id、不適切な Uri などです。|
| 404| URI で指定されたユーザーが存在しません。| 指定されたリソースは見つかりませんでした。|

<a id="ID4EIG"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Type| string| 要求の本文の MIME タイプ。 値の例: <code>application/json</code>|
| Content-Length| string| 応答に送信されるバイト数です。 値の例: 34|
| キャッシュ コントロール| string| キャッシュ動作を指定する、サーバーからていねい要求します。 例: <code>no-cache, no-store</code>|

<a id="ID4E5H"></a>


## <a name="response-body"></a>応答本文

[PermissionCheckBatchResponse (JSON)](../../json/json-permissioncheckbatchresponse.md)を参照してください。

<a id="ID4ELAAC"></a>


### <a name="sample-response"></a>応答の例


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
