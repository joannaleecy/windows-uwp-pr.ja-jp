---
author: Xansky
description: Xbox Live のマルチプレイヤー データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live のマルチプレイヤー データの取得
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, マルチプレイヤー
ms.localizationpriority: medium
ms.openlocfilehash: 6074f3774d099c63f6c39ac4ef0e95a7b6745912
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6971206"
---
# <a name="get-xbox-live-multiplayer-data"></a>Xbox Live のマルチプレイヤー データの取得


[Xbox Live 対応ゲーム](../xbox-live/index.md)のマルチプレイヤー データを日単位または月単位で取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 この情報は、 [Xbox 分析レポート](../publish/xbox-analytics-report.md)では、パートナー センターで利用可能なもできます。

> [!IMPORTANT]
> このメソッドは、Xbox のゲームまたは Xbox Live サービスを使用するゲームのみサポートします。 これらのゲームは、[概念の承認プロセス](../gaming/concept-approval.md)を完了する必要があります。これには、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)が発行したゲームと [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)を介して申請されたゲームが含まれます。 このメソッドでは、[Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)を介して発行されたゲームは現在サポートされていません。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI       |
|--------|----------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター


| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | Xbox Live のマルチプレイヤー データを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。  |  必須  |
| metricType | string | 取得する Xbox Live 分析データの種類を指定する文字列です。 このメソッドでは、日単位のマルチプレイヤー データを取得するには値 **multiplayerdaily** を指定し、月単位のマルチプレイヤー データを取得するには **multiplayermonthly** を指定します。  |  必須  |
| startDate | date | 取得するマルチプレイヤー データの日付範囲の開始日です。 **multiplayerdaily** の場合、既定値は現在の日付の 3 か月前になります。 **multiplayermonthly** の場合、既定値は現在の日付の 1 年前になります。 |  必須ではない  |
| endDate | date | 取得するマルチプレイヤー データの日付範囲終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  必須ではない  |
| filter | string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>deviceType</strong></li><li><strong>packageVersion</strong></li><li><strong>market</strong></li><li><strong>subscriptionName</strong></li></ul> | 必須ではない   |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>date</strong></li><li><strong>deviceType</strong></li><li><strong>packageVersion</strong></li><li><strong>market</strong></li><li><strong>subscriptionName</strong></li></ul><p/>1 つ以上の *groupby* フィールドを指定した場合、指定しなかった他のすべての *groupby* フィールドについては、応答本文での値が **All** になります。 |  必須ではない  |


### <a name="request-example"></a>要求の例

次の例では、Xbox Live 対応ゲームのマルチプレイヤー データを取得する要求を示します。 *applicationId* の値は、ゲームの Store ID に置き換えてください。


```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=multiplayerdaily&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

| 値      | 型   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | マルチプレイヤー データを含むオブジェクトの配列です。各オブジェクトは、指定された日単位または月単位の期間のデータ セットを表し、指定された **filter** 値と **groupby** 値によって整理されます。 各オブジェクトに格納されるデータについて詳しくは、「[日単位のマルチプレイヤー分析](#daily-multiplayer-analytics)」と「[月単位のマルチプレイヤー分析](#monthly-multiplayer-analytics)」の各セクションをご覧ください。     |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されていたとき、クエリに対して 10000 行を超えるデータが一致すると、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。 |


### <a name="daily-multiplayer-analytics"></a>日単位のマルチユーザー分析

日単位のマルチプレイヤー分析データを要求した場合 (つまり、**metricType** パラメーターに **multiplayerdaily** を指定した場合)、*Value* 配列の要素には次の値が格納されます。

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| date                | string | マルチプレイヤー データの日付です。 |
| applicationId       | string | マルチプレイヤー データを取得しているゲームの Store ID です。     |
| applicationName       | string |  マルチプレイヤー データを取得しているゲームの名前です。     |
| market       | string | マルチプレイヤー データが取得された市場を表す 2 文字の ISO 3166 国コードです。       |
| packageVersion     | string |  ゲームのパッケージ バージョンです。4 つの部分から構成されます。  |
| deviceType          | string | マルチプレイヤー データが取得されたデバイスの種類を示す、以下のいずれかの文字列です。<p/><ul><li><strong>Console</strong></li><li><strong>PC</strong></li><li>**Unknown**</li></ul>  |
| subscriptionName     | string |  マルチプレイヤー データに使われたサブスクリプションの名前です。 取り得る値には、**Xbox Game Pass** と **""** (サブスクリプションなしの場合) があります。  |
| dailySessionCount     | number |  指定の日付における、ゲームのマルチプレイヤー セッションの数です。  |
| engagementDurationMinutes     | number |  指定の日付にユーザーがゲームのマルチプレイヤー セッションに参加していた合計秒数です。  |
| dailyActiveUsers     | number |  指定の日付における、ゲームのアクティブなマルチプレイヤー ユーザーの合計数です。  |
| dailyActiveDevices     | number |  指定の日付にゲームのマルチプレイヤー セッションがプレイされたアクティブなデバイスの合計数です。  |
| dailyNewUsers     | number |  指定の日付における、ゲームの新規マルチプレイヤー ユーザーの合計数です。  |
| monthlyActiveUsers     | number |  指定の日付を含む月における、ゲームのアクティブなマルチプレイヤー ユーザーの合計数です。  |
| monthlyActiveDevices     | number | 指定の日付を含む月にゲームのマルチプレイヤー セッションがプレイされたアクティブなデバイスの合計数です。   |
| monthlyNewUsers     | number |  指定の日付を含む月における、ゲームの新規マルチプレイヤー ユーザーの合計数です。  |


### <a name="monthly-multiplayer-analytics"></a>月単位のマルチプレイヤー分析

月単位のマルチプレイヤー分析データを要求した場合 (つまり、**metricType** パラメーターに **multiplayermonthly** を指定した場合)、*Value* 配列の要素には次の値が格納されます。

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| date                | string | マルチプレイヤー データの月の最初の日付です。 |
| applicationId       | string | マルチプレイヤー データを取得しているゲームの Store ID です。     |
| applicationName       | string |  マルチプレイヤー データを取得しているゲームの名前です。     |
| market       | string | マルチプレイヤー データが取得された市場を表す 2 文字の ISO 3166 国コードです。       |
| packageVersion     | string |  ゲームのパッケージ バージョンです。4 つの部分から構成されます。  |
| deviceType          | string | マルチプレイヤー データが取得されたデバイスの種類を示す、以下のいずれかの文字列です。<p/><ul><li><strong>Console</strong></li><li><strong>PC</strong></li><li>**Unknown**</li></ul>  |
| subscriptionName     | string |  マルチプレイヤー データに使われたサブスクリプションの名前です。 取り得る値には、**Xbox Game Pass** と **""** (サブスクリプションなしの場合) があります。  |
| monthlySessionCount     | number |  指定の月における、ゲームのマルチプレイヤー セッションの数です。   |
| engagementDurationMinutes     | number |  指定の月にユーザーがゲームのマルチプレイヤー セッションに参加していた合計秒数です。  |
| monthlyActiveUsers     | number | 指定の月における、ゲームのアクティブなマルチプレイヤー ユーザーの合計数です。   |
| monthlyActiveDevices     | number | 指定の月にゲームのマルチプレイヤー セッションがプレイされたアクティブなデバイスの合計数です。   |
| monthlyNewUsers     | number |  指定の月における、ゲームの新規マルチプレイヤー ユーザーの合計数です。  |
| averageDailyActiveUsers     | number |  指定の月における、ゲームのアクティブなマルチプレイヤー ユーザーの 1 日あたりの平均数です。  |
| averageDailyActiveDevices     | number |  指定の月にゲームのマルチプレイヤー セッションがプレイされたアクティブなデバイスの平均数です。  |


### <a name="response-example"></a>応答の例

この要求に日単位のメトリックを指定した場合 (つまり、**metricType** パラメーターに **multiplayerdaily** を指定した場合) の JSON 応答本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2018-01-07",
      "applicationId": "9NBLGGGZ5QDR",
      "applicationName": "Contoso Sports",
      "market": "All",
      "packageVersion": "",
      "deviceType": "All",
      "subscriptionName": "All",
      "dailySessionCount": 976711,
      "engagementDurationMinutes": 16836064.5,
      "dailyActiveUsers": 180377,
      "dailyActiveDevices": 153359,
      "dailyNewUsers": 8638,
      "monthlyActiveUsers": 779984,
      "monthlyActiveDevices": 606495,
      "monthlyNewUsers": 212093
    },
    {
      "date": "2018-01-05",
      "applicationId": "9NBLGGGZ5QDR",
      "applicationName": "Contoso Sports",
      "market": "All",
      "packageVersion": "",
      "deviceType": "All",
      "subscriptionName": "All",
      "dailySessionCount": 857433,
      "engagementDurationMinutes": 14087724.5,
      "dailyActiveUsers": 166630,
      "dailyActiveDevices": 143065,
      "dailyNewUsers": 9646,
      "monthlyActiveUsers": 764947,
      "monthlyActiveDevices": 595368,
      "monthlyNewUsers": 204248
    },
  ],
  "@nextLink": null,
  "TotalCount":2
}
```

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [Xbox Live の分析データの取得](get-xbox-live-analytics.md)
* [Xbox Live の実績データの取得](get-xbox-live-achievements-data.md)
* [Xbox Live の正常性データの取得](get-xbox-live-health-data.md)
* [Xbox Live ゲーム ハブのデータの取得](get-xbox-live-game-hub-data.md)
* [Xbox Live クラブのデータの取得](get-xbox-live-club-data.md)
