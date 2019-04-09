---
description: Xbox Live ゲーム ハブのデータを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live ゲーム ハブのデータの取得
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, ゲーム ハブ
ms.localizationpriority: medium
ms.openlocfilehash: 2f9e8440384dfac755a4791e71b42dafa80cb957
ms.sourcegitcommit: e63fbd7a63a7e8c03c52f4219f34513f4b2bb411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/19/2019
ms.locfileid: "58162857"
---
# <a name="get-xbox-live-game-hub-data"></a>Xbox Live ゲーム ハブのデータの取得


[Xbox Live 対応ゲーム](https://docs.microsoft.com/gaming/xbox-live//index.md)のゲーム ハブ データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 この情報も記載されて、 [Xbox analytics レポート](../publish/xbox-analytics-report.md)パートナー センターでします。

> [!IMPORTANT]
> このメソッドは、Xbox のゲームまたは Xbox Live サービスを使用するゲームのみサポートします。 これらのゲームは、[概念の承認プロセス](../gaming/concept-approval.md)を完了する必要があります。これには、[Microsoft パートナー](https://docs.microsoft.com/gaming/xbox-live//developer-program-overview.md#microsoft-partners)が発行したゲームと [ID@Xbox プログラム](https://docs.microsoft.com/gaming/xbox-live//developer-program-overview.md#id)を介して申請されたゲームが含まれます。 このメソッドでは、[Xbox Live クリエーターズ プログラム](https://docs.microsoft.com/gaming/xbox-live//get-started-with-creators/get-started-with-xbox-live-creators.md)を介して発行されたゲームは現在サポートされていません。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI       |
|--------|----------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 種類   |  説明      |  必須  
|---------------|--------|---------------|------|
| applicationId | string | Xbox Live ゲーム ハブのデータを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。  |  〇  |
| metricType | string | 取得する Xbox Live 分析データの種類を指定する文字列です。 このメソッドでは、値 **communitymanagergamehub** を指定します。  |  〇  |
| startDate | date | 取得するゲーム ハブ データの日付範囲の開始日です。 既定値は、現在の日付の 30 日前です。 |  X  |
| endDate | date | 取得するゲーム ハブ データの日付範囲の終了日です。 既定値は現在の日付です。 |  X  |
| top | int | 要求で返すデータの行数です。 最大値および指定しない場合の既定値は 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  X  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  X  |


### <a name="request-example"></a>要求の例

次の例では、Xbox Live 対応ゲームのゲーム ハブのデータを取得する要求を示します。 *applicationId* の値は、ゲームの Store ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=communitymanagergamehub&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


| 値      | 種類   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | 指定された日付範囲の日付ごとのゲーム ハブ データを含むオブジェクトの配列です。 各オブジェクトのデータの詳細については、以下の表を参照してください。                                                                                                                      |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されていたとき、クエリに対して 10000 行を超えるデータが一致すると、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。  |


*Value* 配列の要素には、次の値が含まれます。

| Value               | 種類   | 説明                           |
|---------------------|--------|-------------------------------------------|
| date                | string | このオブジェクトに含まれるゲーム ハブ データの日付です。 |
| applicationId       | string | ゲーム ハブ データを取得しているゲームの Store ID です。     |
| gameHubLikeCount     | number |   指定の日付にゲーム ハブ ページに追加された "いいね" の数です。   |
| gameHubCommentCount          | number |  指定の日付に対象アプリのゲーム ハブ ページに追加されたコメントの数です。  |
| gameHubShareCount           | number | 指定の日付にユーザーによって対象アプリのゲーム ハブ ページが共有された回数です。   |
| gameHubFollowerCount          | number | アプリのゲーム ハブ ページの通算フォロワーの数。   |


### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2018-01-04",
      "applicationId": "9NBLGGGZ5QDR",
      "gameHubLikeCount": 10,
      "gameHubCommentCount": 1,
      "gameHubShareCount": 0,
      "gameHubFollowerCount": 15924
    },
    {
      "date": "2018-01-05",
      "applicationId": "9NBLGGGZ5QDR",
      "gameHubLikeCount": 12,
      "gameHubCommentCount": 1,
      "gameHubShareCount": 0,
      "gameHubFollowerCount": 15931
    }
  ],
  "@nextLink": null,
  "TotalCount": 26
}
```

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用して分析データにアクセス](access-analytics-data-using-windows-store-services.md)
* [Xbox Live analytics データを取得します。](get-xbox-live-analytics.md)
* [Xbox Live 成績データを取得します。](get-xbox-live-achievements-data.md)
* [Xbox Live の正常性データを取得します。](get-xbox-live-health-data.md)
* [Xbox Live クラブ活動用のデータを取得します。](get-xbox-live-club-data.md)
* [Xbox Live のマルチ プレーヤー データを取得します。](get-xbox-live-multiplayer-data.md)
