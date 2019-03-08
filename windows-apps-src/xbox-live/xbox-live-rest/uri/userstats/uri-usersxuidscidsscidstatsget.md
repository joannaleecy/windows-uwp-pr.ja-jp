---
title: GET (/users/xuid({xuid})/scids/{scid}/stats)
assetID: af117e87-6f1d-6448-9adf-7cf890d1380f
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstatsget.html
description: " GET (/users/xuid({xuid})/scids/{scid}/stats)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: baf965dcbd23bf00d7d0953726f9f20852324e5e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662387"
---
# <a name="get-usersxuidxuidscidsscidstats"></a>GET (/users/xuid({xuid})/scids/{scid}/stats)
指定したユーザーに代わってユーザー統計名のコンマ区切りリストによってスコープ サービス構成を取得します。
これらの Uri のドメインが`userstats.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [クエリ文字列パラメーター](#ID4EPB)
  * [承認](#ID4EUC)
  * [必要な要求ヘッダー](#ID4EPD)
  * [省略可能な要求ヘッダー](#ID4EYE)
  * [要求本文](#ID4E3F)
  * [HTTP 状態コード](#ID4EHG)
  * [応答本文](#ID4E5BAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

クライアントには、新しいプレーヤーの統計情報システムのプレイヤーの代わりのタイトルの統計情報を読み書きする方法が必要があります。

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| xuid| GUID| Xbox ユーザー ID (XUID) の対象サービスの構成にアクセスするユーザーです。|
| scid| GUID| アクセスされるリソースを含むサービス構成の識別子です。|

<a id="ID4EPB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- | --- |
| statNames| string| 唯一のクエリ文字列パラメーターは、コンマで区切られたユーザー統計名 URI の名詞です。たとえば、次の URI 通知、サービス URI で指定されたユーザー id の代わり、4 つの統計情報が要求したこと。 `https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots`1 回の呼び出しで要求できる統計の数に制限があり、この制限には慎重に検討「スイート スポット」開発者の利便性とします。URI の長さの実用性。 たとえば、制限は、統計名のテキスト (コンマを含む) の価値のいずれかの 600 文字または最大 10 個の統計情報によって判断できます。 このような単純な GET 有効に HTTP が頻度の高いクライアントから呼び出しの量を削減する、一般的に要求の統計情報のキャッシュします。 |

<a id="ID4EUC"></a>


## <a name="authorization"></a>Authorization

コンテンツの分離とアクセス制御のシナリオで実装された承認ロジックがあります。

   * 呼び出し元の要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングおよびユーザーの両方の統計情報を読み取ることができます。 書き込みは、当然ながら、データ プラットフォームでサポートされているクライアントに制限されます。
   * タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。 ランキングは、統計を開くです。 統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。 サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。

チェックの擬似コードのようになります。


```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.

```


<a id="ID4EPD"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。|

<a id="ID4EYE"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求が送られるサービスの名前/番号をビルドします。 要求はのみにルーティング サービスの認証トークンの要求ヘッダーの有効性を確認した後と。 ［既定値］:1. |

<a id="ID4E3F"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EHG"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得します。|
| 304| 変更されていません| リソースされていない最後の要求以降に変更します。|
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。|
| 401| 権限がありません| 要求には、ユーザー認証が必要です。|
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。|
| 404| 検出不可| 指定されたリソースが見つかりませんでした。|
| 406| Not Acceptable| リソースのバージョンがサポートされていません。|
| 408| 要求のタイムアウト| リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。|

<a id="ID4E5BAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EECAC"></a>


### <a name="sample-response"></a>応答のサンプル


```cpp
{
    "user": {
    "xuid": "123456789",
        "gamertag": "WarriorSaint",
        "stats": [
            {
                "statname": "Wins",
                "type": "Integer",
                "value": 40
            },
            {
                "statname": "Kills",
                "type": "Integer",
                "value": 700
            },
            {
                "statname": "KDRatio",
                "type": "Double",
                "value": 2.23
            },
            {
                "statname": "Headshots",
                "type": "Integer",
                "value": 173
            }
        ],
    }
}

```


<a id="ID4EOCAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EQCAC"></a>


##### <a name="parent"></a>Parent

[/users/xuid({xuid})/scids/{scid}/stats](uri-usersxuidscidsscidstats.md)
