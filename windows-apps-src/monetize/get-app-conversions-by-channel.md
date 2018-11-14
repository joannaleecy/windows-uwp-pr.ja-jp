---
author: Xansky
description: 日付範囲やその他のオプション フィルターを指定して、アプリケーションに関するチャネルごとの集計コンバージョン データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: チャネルごとのアプリのコンバージョンの取得
ms.author: mhopkins
ms.date: 08/04/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, アプリのコンバージョン, チャネル
ms.localizationpriority: medium
ms.openlocfilehash: ecb5d5dfbfcbabbd3fa3004c84e2a1a5fff9f2d6
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6276189"
---
# <a name="get-app-conversions-by-channel"></a>チャネルごとのアプリのコンバージョンの取得

日付範囲やその他のオプション フィルターを指定して、アプリケーションに関するチャネルごとの集計コンバージョンを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。

* *コンバージョン*は、(Microsoft アカウントでサインインした) ユーザーが、アプリ (有料の場合も無料の場合も含む) のライセンスを新しく取得したことを意味します。
* *チャネル*はユーザーがアプリの内容ページにアクセスするために使用した方法 (たとえば、ストアを通じて、または[カスタム アプリ プロモーション キャンペーン](../publish/create-a-custom-app-promotion-campaign.md)) です。

この情報も[取得] レポート](../publish/acquisitions-report.md#app-page-views-and-conversions-by-channel)では、パートナー センターで使用できます。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI       |
|--------|----------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/appchannelconversions``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | コンバージョン データを取得するアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) です。 ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。 |  必須  |
| startDate | date | 取得するコンバージョン データの日付範囲の開始日です。 既定値は 1/1/2016 です。 |  必須ではない  |
| endDate | date | 取得するコンバージョン データの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  必須ではない  |
| filter | string  | 応答本文をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントでは **eq** や **ne** 演算子を使用できます。また、ステートメントを **and** や **or** で結合することもできます。 フィルター ステートメントで、次の文字列を指定できます。 詳細については、この記事の「[コンバージョン値](#conversion-values)」をご覧ください。 <ul><li><strong>applicationName</strong></li><li><strong>appType</strong></li><li><strong>customCampaignId</strong></li><li><strong>referrerUriDomain</strong></li><li><strong>channelType</strong></li><li><strong>storeClient</strong></li><li><strong>deviceType</strong></li><li><strong>market</strong></li></ul><p>*filter* パラメーターの例: <em>filter=deviceType eq 'PC'</em>。</p> | 必須ではない   |
| aggregationLevel | string | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定されていない場合、既定値は <strong>day</strong> です。 | 必須ではない |
| orderby | string | それぞれのコンバージョンについて結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターは次のいずれかの文字列になります。<ul><li><strong>date</strong></li><li><strong>applicationName</strong></li><li><strong>appType</strong></li><li><strong>customCampaignId</strong></li><li><strong>referrerUriDomain</strong></li><li><strong>channelType</strong></li><li><strong>storeClient</strong></li><li><strong>deviceType</strong></li><li><strong>market</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  必須ではない  |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 次のフィールドを指定できます。<ul><li><strong>date</strong></li><li><strong>applicationName</strong></li><li><strong>appType</strong></li><li><strong>customCampaignId</strong></li><li><strong>referrerUriDomain</strong></li><li><strong>channelType</strong></li><li><strong>storeClient</strong></li><li><strong>deviceType</strong></li><li><strong>market</strong></li></ul><p>返されるデータ行には、<em>groupby</em> パラメーターに指定したフィールドと次の値が含まれます。</p><ul><li><strong>date</strong></li><li><strong>applicationId</strong></li><li><strong>conversionCount</strong></li><li><strong>clickCount</strong></li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em>groupby=ageGroup,market&amp;aggregationLevel=week</em></p> |  必須ではない  |


### <a name="request-example"></a>要求の例

アプリのコンバージョン データを取得するための要求の例を、いくつか次に示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/appchannelconversions?applicationId=9NBLGGGZ5QDR&startDate=1/1/2017&endDate=2/1/2017&top=10&skip=0  HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/appchannelconversions?applicationId=9NBLGGGZ5QDR&startDate=1/1/2017&endDate=4/31/2017&skip=0&filter=market eq 'US'  HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | アプリに関する集計コンバージョン データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[コンバージョン値](#conversion-values)」セクションをご覧ください。                                                                                                                      |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10 に設定されたが、クエリのコンバージョン データに 10 を超える行が含まれている場合に、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。      |


### <a name="conversion-values"></a>コンバージョン値

*Value* 配列のオブジェクトには、次の値が含まれます。

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| date                | string | コンバージョン データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId       | string | コンバージョン データを取得するアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) です。     |
| applicationName     | string | コンバージョン データを取得するアプリの表示名です。        |
| appType          | string |  コンバージョン データを取得する製品の種類です。 このメソッドでは、サポートされている唯一の値は **App** です。            |
| customCampaignId           | string |  アプリに関連付けられている[カスタム アプリ プロモーション キャンペーン](../publish/create-a-custom-app-promotion-campaign.md)の ID 文字列です。   |
| referrerUriDomain           | string |  カスタム アプリ プロモーション キャンペーン ID を含むアプリの登録情報がアクティブ化されたドメインを指定します。   |
| channelType           | string |  コンバージョンのチャネルを指定する次のいずれかの文字列です。<ul><li><strong>CustomCampaignId</strong></li><li><strong>Store Traffic</strong></li><li><strong>Other</strong></li></ul>    |
| storeClient         | string | コンバージョンが発生したストアのバージョンです。 現時点では、サポートされている唯一の値は **SFC** です。    |
| deviceType          | string | 次のいずれかの文字列です。<ul><li><strong>PC</strong></li><li><strong>Phone</strong></li><li><strong>Console</strong></li><li><strong>IoT</strong></li><li><strong>Holographic</strong></li><li><strong>Unknown</strong></li></ul>            |
| market              | string | コンバージョンが発生した市場の ISO 3166 国コードです。    |
| clickCount              | number  |     アプリの内容へのリンクをクリックした顧客の数です。      |           
| conversionCount            | number  |   顧客のコンバージョンの数です。         |          


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2016-01-01",
      "applicationId": "9NBLGGGZ5QDR",
      "applicationName": "Contoso App",
      "appType": "App",
      "customCampaignId": "",
      "referrerUriDomain": "Universal Client Store",
      "channelType": "Store Traffic",
      "storeClient": "SFC",
      "deviceType": "PC",
      "market": "US",
      "clickCount": 7,
      "conversionCount": 0
    }
  ],
  "@nextLink": null,
  "TotalCount": 1
}
```

## <a name="related-topics"></a>関連トピック

* [取得レポート](../publish/acquisitions-report.md)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [アプリの入手数の取得](get-app-acquisitions.md)
