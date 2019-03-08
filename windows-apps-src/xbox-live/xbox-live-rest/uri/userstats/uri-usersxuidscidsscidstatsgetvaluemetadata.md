---
title: GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)
assetID: 890e3f93-4fdc-955f-d849-ba9579d5c1eb
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstatsgetvaluemetadata.html
description: " GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 55ad44d4c29a2d7a43c76c4df2a78e08462fa65f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612717"
---
# <a name="get-usersxuidxuidscidsscidstatsincludevaluemetadata"></a>GET (/users/xuid({xuid})/scids/{scid}/stats?include=valuemetadata)
指定したサービス構成内のユーザーに対して、統計情報の値に関連付けられているメタデータを含む、指定した統計情報の一覧を取得します。
これらの Uri のドメインが`userstats.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EAB)
  * [クエリ文字列パラメーター](#ID4ELB)
  * [承認](#ID4EWC)
  * [必要な要求ヘッダー](#ID4ERD)
  * [省略可能な要求ヘッダー](#ID4EDF)
  * [要求本文](#ID4EHG)
  * [HTTP 状態コード](#ID4ESG)
  * [応答本文](#ID4EJCAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

でしょうか。 含める valuemetadata = クエリ パラメーターは、ユーザーの統計値など、モデルと競合トラック上の時間を実現するために使用する、車の色に関連付けられたメタデータを含めるへの応答を使用できます。

値のメタデータを応答に含めるに要求の呼び出しが 3 の X Xbl コントラクト バージョン ヘッダーの値を設定することもあります。

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| xuid| GUID| Xbox ユーザー ID (XUID) の対象サービスの構成にアクセスするユーザーです。|
| scid| GUID| アクセスされるリソースを含むサービス構成の識別子です。|

<a id="ID4ELB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- | --- |
| statNames| string| ユーザー統計名のリストのコンマ区切り。たとえば、次の URI 通知、サービス URI で指定されたユーザー id の代わり、4 つの統計情報が要求したこと。{0}:: nomakrdown}<br/><br/>`https://userstats.xboxlive.com/users/xuid({xuid})/scids/{scid}/stats/wins,kills,kdratio,headshots?include=valuemetadata`| 
| 含める valuemetadata を =| string| 応答に使用統計値に関連付けられた任意の値のメタデータが含まれていることを示します。|

<a id="ID4EWC"></a>


## <a name="authorization"></a>Authorization

コンテンツの分離とアクセス制御のシナリオで実装された承認ロジックがあります。

   * 呼び出し元の要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングおよびユーザーの両方の統計情報を読み取ることができます。 書き込みは、データ プラットフォームでサポートされているクライアントに制限されます。
   * タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。 ランキングは、統計を開くです。 統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。 サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。

チェックの擬似コードのようになります。


```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.

```


<a id="ID4ERD"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。|
| X Xbl コントラクト バージョン| string| 使用する API のバージョンを示します。 この値は、値のメタデータを応答に含めるために、「3」に設定する必要があります。|

<a id="ID4EDF"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求が送られるサービスの名前/番号をビルドします。 要求はのみにルーティング サービスの認証トークンの要求ヘッダーの有効性を確認した後と。 ［既定値］:1. |

<a id="ID4EHG"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4ESG"></a>


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

<a id="ID4EJCAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EPCAC"></a>


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
