---
author: Xansky
description: Xbox Live の正常性データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live の正常性データの取得
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, 正常性, クライアント エラー
ms.localizationpriority: medium
ms.openlocfilehash: e2143f04b1b2641123929f5f833df2421f77b99e
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5764191"
---
# <a name="get-xbox-live-health-data"></a>Xbox Live の正常性データの取得


[Xbox Live 対応ゲーム](../xbox-live/index.md)の正常性データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 この情報は、Windows デベロッパー センター ダッシュボードの [Xbox 分析レポート](../publish/xbox-analytics-report.md)でも確認できます。

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
| applicationId | string | Xbox Live の正常性データを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。  |  必須  |
| metricType | string | 取得する Xbox Live 分析データの種類を指定する文字列です。 このメソッドでは、値 **callingpattern** を指定します。  |  必須  |
| startDate | date | 取得する正常性データの日付範囲の開始日です。 既定値は、現在の日付の 30 日前です。 |  必須ではない  |
| endDate | date | 取得する正常性データの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  必須ではない  |
| filter | string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>deviceType</strong></li><li><strong>packageVersion</strong></li><li><strong>sandboxId</strong></li></ul> | 必須ではない   |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>date</strong></li><li><strong>deviceType</strong></li><li><strong>packageVersion</strong></li><li><strong>sandboxId</strong></li></ul><p/>1 つ以上の *groupby* フィールドを指定した場合、指定しなかった他のすべての *groupby* フィールドについては、応答本文での値が **All** になります。 |  必須ではない  |


### <a name="request-example"></a>要求の例

次の例では、Xbox Live 対応ゲームの正常性データを取得する要求を示します。 *applicationId* の値は、ゲームの Store ID に置き換えてください。


```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=callingpattern&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

| 値      | 型   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | 正常性データを含むオブジェクトの配列です。 各オブジェクト内のデータについて詳しくは、次の表をご覧ください。                                                                                                                      |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されていたとき、クエリに対して 10000 行を超えるデータが一致すると、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。   |


*Value* 配列の要素には、次の値が含まれます。

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| applicationId       | string | 正常性データを取得するゲームの Store ID です。     |
| date                | string | 正常性データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| deviceType          | string | ゲームが使われたデバイスの種類を指定する、以下のいずれかの文字列です。<p/><ul><li><strong>XboxOne</strong></li><li><strong>WindowsOneCore</strong> (この値は PC を示します)</li><li><strong>Unknown</strong></li></ul>  |
| sandboxId     | string |   ゲーム用に作成されたサンドボックス ID です。 これは値 RETAIL か、またはプライベート サンドボックスの ID になります。   |
| packageVersion     | string |  ゲームのパッケージ バージョンです。4 つの部分から構成されます。  |
| callingPattern     | object |  指定の日付範囲にゲームで利用された各 Xbox Live サービスから返された各状態コードについて、サービス応答、デバイス、ユーザー データを提供する [callingPattern](#callingpattern) オブジェクトです。     |


### <a name="callingpattern"></a>callingPattern

| 値      | 型   | 説明                  |
|------------|--------|-------------------------------------------------------|
| service      | string  |   正常性データに関連する Xbox Live サービスの名前です。       |
| endpoint      | string  |   正常性データに関連する Xbox Live サービスのエンドポイントです。        |
| httpStatusCode      | string  |  この正常性データのセットに対する HTTP 状態コードです。<p/><p/>**注**&nbsp;&nbsp;状態コード **429E** は、呼び出し中に[きめ細かなレート制限](../xbox-live/using-xbox-live/best-practices/fine-grained-rate-limiting.md)が適用されなかったためにサービス呼び出しが成功したことを示します。 サービスの負荷が高まると、今後きめ細かなレート制限が適用される可能性があり、その場合は呼び出しに対して [HTTP 429 状態コード](../xbox-live/using-xbox-live/best-practices/fine-grained-rate-limiting.md#http-429-response-object)が返されます。         |
| serviceResponses      | number  | 指定の状態コードを返したサービス応答の数です。         |
| uniqueDevices      | number  |  サービスを呼び出して指定の状態コードを受け取った一意のデバイスの数です。       |
| uniqueUsers      | number  |   指定の状態コードを受け取った一意のユーザーの数です。       |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。 この例のサービス名とエンドポイントは実際のものではなく、例示の目的で使われているだけです。

```json
{
  "Value": [
    {
      "applicationId": "9NBLGGGZ5QDR",
      "date": "2018-01-30",
      "deviceType": "All",
      "sandboxId": "RETAIL",
      "packageVersion": "Unknown",
      "callingpattern": [
        {
          "service": "userstats",
          "endpoint": "UserStats.BatchReadHandler.POST",
          "httpStatusCode": "200",
          "serviceResponses": 160891,
          "uniqueDevices": 410,
          "uniqueUsers": 410
        },
        {
          "service": "userstats",
          "endpoint": "UserStats.BatchStatReadHandler.GET",
          "httpStatusCode": "200",
          "serviceResponses": 422,
          "uniqueDevices": 0,
          "uniqueUsers": 30
        }
      ],
    }
  ],
  "@nextLink": null,
  "TotalCount": 1
}
```

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [Xbox Live の分析データの取得](get-xbox-live-analytics.md)
* [Xbox Live の実績データの取得](get-xbox-live-achievements-data.md)
* [Xbox Live ゲーム ハブのデータの取得](get-xbox-live-game-hub-data.md)
* [Xbox Live クラブのデータの取得](get-xbox-live-club-data.md)
* [Xbox Live のマルチプレイヤー データの取得](get-xbox-live-multiplayer-data.md)
