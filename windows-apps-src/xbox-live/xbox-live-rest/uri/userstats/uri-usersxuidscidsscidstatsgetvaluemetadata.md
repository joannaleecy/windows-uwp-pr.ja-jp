---
title: GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)
assetID: 890e3f93-4fdc-955f-d849-ba9579d5c1eb
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstatsgetvaluemetadata.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2c795dbd2b6193798b472e51526bdd9e2f6b4622
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4415263"
---
# <a name="get-usersxuidxuidscidsscidstatsincludevaluemetadata"></a>GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)
指定されたサービス構成でのユーザーに対して、統計情報の値に関連付けられたメタデータを含む、指定された統計情報の一覧を取得します。
これらの Uri のドメインが`userstats.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EAB)
  * [クエリ文字列パラメーター](#ID4ELB)
  * [Authorization](#ID4EWC)
  * [必要な要求ヘッダー](#ID4ERD)
  * [オプションの要求ヘッダー](#ID4EDF)
  * [要求本文](#ID4EHG)
  * [HTTP ステータス コード](#ID4ESG)
  * [応答本文](#ID4EJCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

かどうか。 含める = valuemetadata クエリ パラメーターには、モデルとレース トラックの時間を実現するために使用された車の色など、ユーザーの統計値に関連付けられたメタデータを含めるへの応答がことができます。

応答には、値のメタデータを含める、要求の呼び出しが 3 のヘッダー値 X Xbl コントラクト バージョンを設定することもする必要があります。

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| xuid| GUID| Xbox ユーザー ID (XUID) サービス構成にアクセスする対象ユーザーのします。|
| scid| GUID| アクセス対象のリソースが含まれているサービス構成の識別子です。|

<a id="ID4ELB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- | --- |
| statNames| string| コンマ区切りの統計情報のユーザー名のリスト。たとえば、次の URI は、通知サービス URI で指定されたユーザー id の代理として 4 つの統計情報を要求します。{: nomakrdown}<br/><br/>`https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots?include=valuemetadata`| 
| 含める = valuemetadata| string| 応答には、uset 統計の値に関連付けられた値メタデータが含まれていることを示します。|

<a id="ID4EWC"></a>


## <a name="authorization"></a>Authorization

コンテンツ分離とアクセス制御のシナリオ向けに実装承認ロジックがあります。

   * ランキング、およびユーザーの両方の統計情報は、呼び出し元が要求に有効な XSTS トークンを送信している、任意のプラットフォーム上のクライアントから読み取ることができます。 書き込みは、データ プラットフォームでサポートされているクライアントに制限されます。
   * タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付きの統計情報をマークできます。 ランキングは、統計を開くです。 開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。 サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。

チェックの擬似コードは、次のようになります。


```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.

```


<a id="ID4ERD"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。|
| X Xbl コントラクト バージョン| string| 使用する API のバージョンを示します。 この値は、応答に値のメタデータを含めるために、「3」に設定する必要があります。|

<a id="ID4EDF"></a>


## <a name="optional-request-headers"></a>オプションの要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求を送信する必要があります、サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 既定値: 1 です。|

<a id="ID4EHG"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4ESG"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得されました。|
| 304| Not Modified| リソースされていない以降に変更するように要求します。|
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。|
| 401| 権限がありません| 要求には、ユーザー認証が必要です。|
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。|
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。|
| 406| 許容できません。| リソースのバージョンがサポートされていません。|
| 408| 要求のタイムアウト| リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。|

<a id="ID4EJCAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EPCAC"></a>


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
        "value": 40,
        "valuemetadata" : "{\"region\" : \"EU\", \"isRanked\" : true}"
      },
      {
        "statname": "Kills",
        "type": "Integer",
        "value": 700,
        "valuemetadata" : "{\"longestKillStreak" : 15, \"favoriteTarget\" : \"CrazyPigeon\"}"
      },
      {
        "statname": "KDRatio",
        "type": "Double",
        "value": 2.23,
        "valuemetadata" : "{\"totalKills\" : 700, \"totalDeaths\" : 314}"
      },
      {
        "statname": "Headshots",
        "type": "Integer",
        "value": 173,
        "valuemetadata" : ""
      }
    ],
  }
}

```


<a id="ID4EZCAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E2CAC"></a>


##### <a name="parent"></a>Parent

[/users/xuid({xuid})/scids/{scid}/stats](uri-usersxuidscidsscidstats.md)
