---
title: GET (/users/xuid({xuid})/scids/{scid}/stats)
assetID: af117e87-6f1d-6448-9adf-7cf890d1380f
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstatsget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/scids/{scid}/stats)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c0c2159b85749169a56ce9b27dc387c3ee1ea0c8
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7151821"
---
# <a name="get-usersxuidxuidscidsscidstats"></a>GET (/users/xuid({xuid})/scids/{scid}/stats)
スコープ指定されたユーザーに代わってユーザー統計情報名のコンマ区切りの一覧でサービス構成を取得します。
これらの Uri のドメインが`userstats.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [クエリ文字列パラメーター](#ID4EPB)
  * [Authorization](#ID4EUC)
  * [必要な要求ヘッダー](#ID4EPD)
  * [オプションの要求ヘッダー](#ID4EYE)
  * [要求本文](#ID4E3F)
  * [HTTP ステータス コード](#ID4EHG)
  * [応答本文](#ID4E5BAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

クライアントには、新しいプレイヤーの統計情報システムへのプレイヤーの代理としてタイトルの統計情報を読み書きする方法が必要です。

<a id="ID4EEB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| xuid| GUID| Xbox ユーザー ID (XUID) サービス構成にアクセスする対象ユーザーのです。|
| scid| GUID| アクセス対象のリソースが含まれているサービス構成の識別子です。|

<a id="ID4EPB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- | --- |
| statNames| string| 唯一のクエリ文字列パラメーターは、コンマで区切られたユーザー統計情報名 URI 名詞です。たとえば、次の URI に通知サービス URI で指定されたユーザー id の代理として 4 つの統計情報を要求します。 `https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots`1 つの呼び出しで要求できる統計の数に制限があり、その制限は URI の長さの実用性と開発者の利便性の「スイート スポット」を慎重に検討します。 たとえば、制限は、統計情報名のテキスト (コンマを含む) の価値があるか 600 文字または最大 10 個の統計情報によって決まります可能性があります。 このようなシンプルな GET 有効 HTTP ようにクライアントからの呼び出しの量は減少よく要求される統計情報をキャッシュします。 |

<a id="ID4EUC"></a>


## <a name="authorization"></a>Authorization

コンテンツ分離とアクセス制御のシナリオ向けに実装承認ロジックがあります。

   * ランキング、およびユーザーの両方の統計情報は、呼び出し元が要求に有効な XSTS トークンを送信している任意のプラットフォーム上のクライアントから読み取ることができます。 書き込みは、データ プラットフォームでサポートされているクライアントに明らかに制限されます。
   * タイトル デベロッパーは、open または XDP またはパートナー センターで制限付きの統計情報をマークできます。 ランキングは、統計を開くです。 開いている統計情報は、サンド ボックスに、ユーザーが許可されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。 サンド ボックスへのユーザーの承認は XDP またはパートナー センターで管理されます。

チェックの擬似コードは、このようになります。


```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.

```


<a id="ID4EPD"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。|

<a id="ID4EYE"></a>


## <a name="optional-request-headers"></a>オプションの要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求を送信する必要があります、サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。 既定値: 1 です。|

<a id="ID4E3F"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EHG"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得されました。|
| 304| Not Modified| リソースされていない以降に変更するように要求します。|
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。|
| 401| 権限がありません| 要求には、ユーザー認証が必要です。|
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。|
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。|
| 406| 許容できません。| リソースのバージョンがサポートされていません。|
| 408| 要求のタイムアウト| リソースのバージョンがサポートされていません。MVC レイヤーによって拒否する必要があります。|

<a id="ID4E5BAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EECAC"></a>


### <a name="sample-response"></a>応答の例


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
