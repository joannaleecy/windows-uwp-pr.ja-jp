---
author: Xansky
ms.assetid: A26A287C-B4B0-49E9-BB28-6F02472AE1BA
description: 日付範囲やその他のオプション フィルターを指定して、特定のアプリケーションの広告キャンペーンのパフォーマンスに関する集計データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: 広告キャンペーンのパフォーマンス データの取得
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 337342378fc42b33c0bddb980b143ab195305458
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5768416"
---
# <a name="get-ad-campaign-performance-data"></a>広告キャンペーンのパフォーマンス データの取得


日付範囲やその他のオプション フィルターを指定して、アプリケーションに関するプロモーション用広告キャンペーンのパフォーマンス データの集計サマリーを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 このメソッドは、データを JSON 形式で返します。

このメソッドは、Windows デベロッパー センター ダッシュボードの[アプリのインストールの広告レポート](../publish/app-install-ads-reports.md)で提供されるデータと同じデータを返します。 広告キャンペーンについて詳しくは、「[アプリ向けの広告キャンペーンの作成](../publish/create-an-ad-campaign-for-your-app.md)」をご覧ください。

広告キャンペーンの詳細を作成、更新、取得するには、[Microsoft Store プロモーション API](run-ad-campaigns-using-windows-store-services.md) の[広告キャンペーンの管理](manage-ad-campaigns.md)メソッドを使用します。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                              |
|--------|--------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/promotion``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                |
|---------------|--------|---------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

特定のアプリに関する広告キャンペーンのパフォーマンス データを取得するには、*applicationId* パラメーターを使用します。 開発者アカウントに関連付けられているすべてのアプリに関する広告パフォーマンス データを取得するには、*applicationId* パラメーターは省略します。

| パラメーター     | 型   | 説明     | 必須かどうか |
|---------------|--------|-----------------|----------|
| applicationId   | string    | 広告キャンペーンのパフォーマンス データを取得するアプリの [Store ID](in-app-purchases-and-trials.md#store-ids) です。 |    必須ではない      |
|  startDate  |  date   |  広告キャンペーンのパフォーマンス データを取得する日付範囲の開始日です。YYYY/MM/DD の形式で指定します。 既定値は、現在の日付から 30 日を差し引いた日付になります。   |   必須ではない    |
| endDate   |  date   |  広告キャンペーンのパフォーマンス データを取得する日付範囲の終了日です。YYYY/MM/DD の形式で指定します。 既定値は、現在の日付から 1 日を差し引いた日付になります。   |   必須ではない    |
| top   |  int   |  要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。   |   必須ではない    |
| skip   | int    |  クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。   |   必須ではない    |
| filter   |  string   |  応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 サポートされているフィルターは **campaignId** のみです。 各ステートメントでは **eq** や **ne** 演算子を使用できます。また、ステートメントを **and** や **or** で結合することもできます。  *filter* パラメーターの例: ```filter=campaignId eq '100023'```。   |   必須ではない    |
|  aggregationLevel  |  string   | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定されていない場合、既定値は <strong>day</strong> です。    |   必須ではない    |
| orderby   |  string   |  <p>広告キャンペーンのパフォーマンス データに関する結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターは次のいずれかの文字列になります。</p><ul><li><strong>date</strong></li><li><strong>campaignId</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,campaignId</em></p>   |   必須ではない    |
|  groupby  |  string   |  <p>指定したフィールドのみにデータ集計を適用するステートメントです。 次のフィールドを指定できます。</p><ul><li><strong>campaignId</strong></li><li><strong>applicationId</strong></li><li><strong>date</strong></li><li><strong>currencyCode</strong></li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em>&amp;groupby=applicationId&amp;aggregationLevel=week</em></p>   |   必須ではない    |


### <a name="request-example"></a>要求の例

広告キャンペーンのパフォーマンス データを取得するための要求の例を、いくつか次に示します。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/promotion?aggregationLevel=week&groupby=applicationId,campaignId,date  HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/promotion?applicationId=9NBLGGH0XK8Z&startDate=2015/1/20&endDate=2016/8/31&skip=0&filter=campaignId eq '31007388' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型   | 説明  |
|------------|--------|---------------|
| Value      | array  | 広告キャンペーンのパフォーマンスに関する集計データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[キャンペーンのパフォーマンス オブジェクト](#campaign-performance-object)」セクションをご覧ください。          |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 5 に設定されたが、クエリに対するデータに 5 個を超える項目が含まれている場合に、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。                                |


<span id="campaign-performance-object" />


### <a name="campaign-performance-object"></a>キャンペーンのパフォーマンス オブジェクト

*Value* 配列の要素には、次の値が含まれます。

| 値               | 型   | 説明            |
|---------------------|--------|------------------------|
| date                | string | 広告キャンペーンのパフォーマンス データの対象となる日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId       | string | 広告キャンペーンのパフォーマンス データを取得するアプリのストア ID です。                     |
| campaignId     | string | 広告キャンペーンの ID です。           |
| lineId     | string |    このパフォーマンス データを生成した広告キャンペーン[配信ライン](manage-delivery-lines-for-ad-campaigns.md)の ID です。        |
| currencyCode              | string | キャンペーン予算の通貨コードです。              |
| spend          | string |  広告キャンペーンで消費した予算金額です。     |
| impressions           | long | キャンペーンの広告インプレッションの数です。        |
| installs              | long | キャンペーンに関連するアプリのインストールの数です。   |
| clicks            | long | キャンペーンの広告クリックの数です。      |
| iapInstalls            | long | キャンペーンに関連するアドオン (アプリ内購入または IAP とも呼ばれます) のインストールの数。      |
| activeUsers            | long | キャンペーンの一部である広告をクリックし、アプリに戻ったユーザーの数です。      |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2015-04-12",
      "applicationId": "9WZDNCRFJ31Q",
      "campaignId": "4568",
      "lineId": "0001",
      "currencyCode": "USD",
      "spend": 700.6,
      "impressions": 200,
      "installs": 30,
      "clicks": 8,
      "iapInstalls": 0,
      "activeUsers": 0
    },
    {
      "date": "2015-05-12",
      "applicationId": "9WZDNCRFJ31Q",
      "campaignId": "1234",
      "lineId": "0002",
      "currencyCode": "USD",
      "spend": 325.3,
      "impressions": 20,
      "installs": 2,
      "clicks": 5,
      "iapInstalls": 0,
      "activeUsers": 0
    }
  ],
  "@nextLink": "promotion?applicationId=9NBLGGGZ5QDR&aggregationLevel=day&startDate=2015/1/20&endDate=2016/8/31&top=2&skip=2",
  "TotalCount": 1917
}
```

## <a name="related-topics"></a>関連トピック

* [アプリの広告キャンペーンの作成](https://msdn.microsoft.com/windows/uwp/publish/create-an-ad-campaign-for-your-app)
* [Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
