---
ms.assetid: 7b07a6ca-4be1-497c-a901-0a2da3762555
description: プロモーション用の広告キャンペーンを作成、編集、取得するには、Microsoft Store プロモーション API の以下のメソッドを使います。
title: 広告キャンペーンの管理
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store プロモーション API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 6529c1a21865b2997d36e9b254b19f971f620490
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7835844"
---
# <a name="manage-ad-campaigns"></a>広告キャンペーンの管理

アプリのプロモーション用の広告キャンペーンを作成、編集、取得するには、[Microsoft Store プロモーション API](run-ad-campaigns-using-windows-store-services.md) の以下のメソッドを使います。 このメソッドを使って作成した各キャンペーンに関連付けることができるのは、1 つのアプリのみです。

>**注:**&nbsp;&nbsp;プログラムで作成したキャンペーンには、パートナー センターでアクセスできることとも作成して、パートナー センターを使用して広告キャンペーンを管理することができます。 パートナー センターでの広告キャンペーンの管理について詳しくは、[アプリの広告キャンペーンの作成](../publish/create-an-ad-campaign-for-your-app.md)を参照してください。

これらのメソッドを使ってキャンペーンを作成または更新する場合、通常は以下のメソッドも 1 つ以上呼び出し、キャンペーンに関連付けられた*配信ライン*、*対象プロファイル*、*クリエイティブ*を管理します。 キャンペーン、配信ライン、ターゲット プロファイル、クリエイティブ間の関係について詳しくは、「[Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api)」をご覧ください。

* [広告キャンペーンの配信ラインの管理](manage-delivery-lines-for-ad-campaigns.md)
* [広告キャンペーンの対象プロファイルの管理](manage-targeting-profiles-for-ad-campaigns.md)
* [広告キャンペーンのクリエイティブの管理](manage-creatives-for-ad-campaigns.md)

## <a name="prerequisites"></a>前提条件

これらのメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store プロモーション API に関するすべての[前提条件](run-ad-campaigns-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。

  >**注:**&nbsp;&nbsp;前提条件の一部として、そのする[パートナー センターで、少なくとも 1 つの有料広告キャンペーンを作成](../publish/create-an-ad-campaign-for-your-app.md)していることを確認する、広告キャンペーンの支払い方法を少なくとも 1 つパートナー センターで追加します。 この API を使用して作成した広告キャンペーンの配信ラインでは、パートナー センターで**の広告キャンペーン**] ページで選んだ既定の支払い方法を自動的に請求されます。

* これらのメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。


## <a name="request"></a>要求

これらのメソッドでは、次の URL が使用されます。

| メソッドの種類 | 要求 URI                                                      |  説明  |
|--------|------------------------------------------------------------------|---------------|
| POST   | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign``` |  新しい広告キャンペーンを作成します。  |
| PUT    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign/{campaignId}``` |  *campaignId* により指定された広告キャンペーンを編集します。  |
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign/{campaignId}``` |  *campaignId* により指定された広告キャンペーンを取得します。  |
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign``` |  広告キャンペーンのクエリ。 サポートされるクエリ パラメーターの「[パラメーター](#parameters)」セクションをご覧ください。  |


### <a name="header"></a>ヘッダー

| ヘッダー        | 型   | 説明         |
|---------------|--------|---------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |
| 追跡 ID   | GUID   | 省略可能。 呼び出しフローを追跡する ID。                                  |


<span id="parameters"/> 

### <a name="parameters"></a>パラメーター

広告キャンペーンを問い合わせる GET メソッドは、次のオプション クエリ パラメーターをサポートします。

| 名前        | 種類   |  説明      |    
|-------------|--------|---------------|------|
| skip  |  int   | クエリでスキップする行数です。 データ セットを操作するには、このパラメーターを使用します。 たとえば、fetch=10 と skip=0 を指定すると、データの最初の 10 行が取得され、top=10 と skip=10 を指定すると、データの次の 10 行が取得されます。    |       
| fetch  |  整数   | 要求で返すデータの行数です。    |       
| campaignSetSortColumn  |  文字列   | 応答本文で、指定されたフィールドにより[キャンペーン](#campaign) オブジェクトを順序付けます。 構文は <em>CampaignSetSortColumn=field</em> です。ここで、<em>field</em> パラメーターは次のいずれかの文字列になります。</p><ul><li><strong>id</strong></li><li><strong>createdDateTime</strong></li></ul><p>既定値は **createdDateTime** です。     |     
| isDescending  |  ブール値   | 応答本文で、[キャンペーン](#campaign) オブジェクトを降順または昇順で並べ替えます。   |         
| storeProductId  |  文字列   | 指定された[ストア ID](in-app-purchases-and-trials.md#store-ids) を持つアプリに関連付けられた広告キャンペーンのみ返す場合は、この値を使います。 製品のストア ID の例は、9nblggh42cfd です。   |         
| label  |  文字列   | [キャンペーン](#campaign) オブジェクトに指定された*ラベル*が含まれる広告キャンペーンのみ返す場合は、この値を使います。    |       |    


### <a name="request-body"></a>要求本文

POST メソッドと PUT メソッドには、[キャンペーン](#campaign) オブジェクトの必須フィールドと設定または変更する追加フィールドを持つ JSON 要求本文が必要です。


### <a name="request-examples"></a>要求の例

次の例は、POST メソッドを呼び出して広告キャンペーンを作成する方法を示しています。

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign HTTP/1.1
Authorization: Bearer <your access token>

{
    "name": "Contoso App Campaign",
    "storeProductId": "9nblggh42cfd",
    "configuredStatus": "Active",
    "objective": "DriveInstalls",
    "type": "Community"
}
```

次の例は、GET メソッドを呼び出して特定の広告キャンペーンを取得する方法を示しています。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign/31043481  HTTP/1.1
Authorization: Bearer <your access token>
```

次の例は、GET メソッドを呼び出して、作成日により並べ替えられた一連の広告キャンペーンを問い合わせる方法を示しています。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/campaign?storeProductId=9nblggh42cfd&fetch=100&skip=0&campaignSetSortColumn=createdDateTime HTTP/1.1
Authorization: Bearer <your access token>
```


## <a name="response"></a>応答

これらのメソッドは、呼び出したメソッドに応じて 1 つ以上の[キャンペーン](#campaign) オブジェクトを含む JSON 応答本文を返します。 次の例は、特定のキャンペーンの GET メソッドの応答本文を示しています。

```json
{
    "Data": {
        "id": 31043481,
        "name": "Contoso App Campaign",
        "createdDate": "2017-01-17T10:12:15Z",
        "storeProductId": "9nblggh42cfd",
        "configuredStatus": "Active",
        "effectiveStatus": "Active",
        "effectiveStatusReasons": [
            "{\"ValidationStatusReasons\":null}"
        ],
        "labels": [],
        "objective": "DriveInstalls",
        "type": "Paid",
        "lines": [
            {
                "id": 31043476,
                "name": "Contoso App Campaign - Paid Line"
            }
        ]
    }
}
```


<span id="campaign"/>

## <a name="campaign-object"></a>キャンペーン オブジェクト

これらのメソッドの要求本文と応答本文には、次のフィールドが含まれています。 この表は、読み取り専用のフィールド (つまり、PUT メソッドで変更できない) と POST メソッドの要求本文で必須のフィールドを示しています。

| フィールド        | 型   |  説明      |  読み取り専用かどうか  | 既定値  | POST に必須かどうか |  
|--------------|--------|---------------|------|-------------|------------|
|  id   |  整数   |  広告キャンペーンの ID です。     |   ○    |      |  ×     |       
|  name   |  文字列   |   広告キャンペーンの名前です。    |    ×   |      |  ○     |       
|  configuredStatus   |  文字列   |  開発者により指定された広告キャンペーンのステータスを指定する次のいずれかの値です。 <ul><li>**Active**</li><li>**Inactive**</li></ul>     |  ×     |  Active    |   ○    |       
|  effectiveStatus   |  文字列   |   システム検証に基づいて広告キャンペーンの有効ステータスを指定する次のいずれかの値です。 <ul><li>**Active**</li><li>**Inactive**</li><li>**Processing**</li></ul>    |    ○   |      |   ×      |       
|  effectiveStatusReasons   |  配列   |  広告キャンペーンの有効ステータスの理由を指定する次のうち 1 つ以上の値です。 <ul><li>**AdCreativesInactive**</li><li>**BillingFailed**</li><li>**AdLinesInactive**</li><li>**ValidationFailed**</li><li>**Failed**</li></ul>      |  ○     |     |    ×     |       
|  storeProductId   |  文字列   |  この広告キャンペーンが関連付けられているアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) です。 製品のストア ID の例は、9nblggh42cfd です。     |   ○    |      |  ○     |       
|  labels   |  配列   |   キャンペーンのカスタム ラベルを表す 1 つ以上の文字列です。 これらのラベルは、キャンペーンの検索とタグ付けに使われます。    |   ×    |  null    |    ×     |       
|  type   | 文字列    |  キャンペーンの種類を指定する次のいずれかの値です。 <ul><li>**有料**</li><li>**自社**</li><li>**コミュニティ**</li></ul>      |   ○    |      |   ○    |       
|  objective   |  文字列   |  キャンペーンの目的を指定する次のいずれかの値です。 <ul><li>**DriveInstall**</li><li>**DriveReengagement**</li><li>**DriveInAppPurchase**</li></ul>     |   ×    |  DriveInstall    |   ○    |       
|  lines   |  配列   |   広告キャンペーンに関連づけられた[配信ライン](manage-delivery-lines-for-ad-campaigns.md#line)を識別する 1 つ以上のオブジェクトです。 このフィールドの各オブジェクトは、配信ラインの ID と名前を指定する *id* フィールドと *name* フィールドで構成されます。     |   ×    |      |    ×     |       
|  createdDate   |  文字列   |  広告キャンペーンが作成された日時 (ISO 8601 形式)。     |  ○     |      |     ×    |       |


## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md)
* [広告キャンペーンの配信ラインの管理](manage-delivery-lines-for-ad-campaigns.md)
* [広告キャンペーンの対象プロファイルの管理](manage-targeting-profiles-for-ad-campaigns.md)
* [広告キャンペーンのクリエイティブの管理](manage-creatives-for-ad-campaigns.md)
* [広告キャンペーンのパフォーマンス データの取得](get-ad-campaign-performance-data.md)
