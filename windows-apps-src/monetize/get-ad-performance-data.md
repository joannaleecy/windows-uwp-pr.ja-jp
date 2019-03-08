---
ms.assetid: 235EBA39-8F64-4499-9833-4CCA9C737477
description: 日付範囲やその他のオプション フィルターを指定して、アプリケーションの広告のパフォーマンスに関する集計データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: 広告のパフォーマンス データの取得
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, 広告, パフォーマンス
ms.localizationpriority: medium
ms.openlocfilehash: c6bec86929284e49e4e882597422d316276c0a33
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627887"
---
# <a name="get-ad-performance-data"></a>広告のパフォーマンス データの取得


日付範囲やその他のオプション フィルターを指定して、アプリケーションの広告のパフォーマンスに関する集計データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 このメソッドは、データを JSON 形式で返します。

このメソッドが用意されている同じデータを返します、[パフォーマンス レポートをアドバタイズ](../publish/advertising-performance-report.md)パートナー センターでします。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

詳しくは、「[Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)」をご覧ください。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                              |
|--------|--------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/adsperformance``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明           |
|---------------|--------|--------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

特定のアプリに関する広告のパフォーマンス データを取得するには、*applicationId* パラメーターを使用します。 開発者アカウントに関連付けられているすべてのアプリに関する広告パフォーマンス データを取得するには、*applicationId* パラメーターは省略します。

| パラメーター     | 種類   | 説明     | 必須 |
|---------------|--------|-----------------|----------|
| applicationId   | string    | 広告のパフォーマンス データを取得するアプリの [Store ID](in-app-purchases-and-trials.md#store-ids) です。  |    X      |
| startDate   | date    | 広告のパフォーマンス データを取得する日付範囲の開始日です。YYYY/MM/DD の形式で指定します。 既定値は、現在の日付から 30 日を差し引いた日付になります。 |    X      |
| endDate   | date    | 広告のパフォーマンス データを取得する日付範囲の終了日です。YYYY/MM/DD の形式で指定します。 既定値は、現在の日付から 1 日を差し引いた日付になります。 |    X      |
| top   | int    | 要求で返すデータの行数です。 最大値および指定しない場合の既定値は 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |    X      |
| skip   | int    | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |    X      |
| filter   | string    | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 詳しくは、次の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。 |    X      |
| aggregationLevel   | string    | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定しない場合、既定値は <strong>day</strong> です。 |    X      |
| orderby   | string    | 結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターには、次のいずれかの文字列を指定できます。<ul><li><strong>date</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>adUnitId</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |    X      |
| groupby   | string    | 指定したフィールドのみにデータ集計を適用するステートメントです。 次のフィールドを指定できます。</p><ul><li><strong>applicationId</strong></li><li><strong>applicationName</strong></li><li><strong>date</strong></li><li><strong>accountCurrencyCode</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>adUnitName</strong></li><li><strong>adUnitId</strong></li><li><strong>pubCenterAppName</strong></li><li><strong>adProvider</strong></li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em>&amp;groupby=applicationId&amp;aggregationLevel=week</em></p> |    X      |


### <a name="filter-fields"></a>フィルター フィールド

要求本文の *filter* パラメーターには、応答内の行をフィルター処理する 1 つまたは複数のステートメントが含まれます。 各ステートメントには **eq** 演算子または **ne** 演算子と関連付けられるフィールドと値が含まれ、**and** または **or** を使ってステートメントを組み合わせることができます。 *filter* パラメーターの例を次に示します。

-   *filter=market eq 'US' and deviceType eq 'phone'*

サポートされているフィールドの一覧については、次の表をご覧ください。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。

| フィールド | 説明                                                              |
|--------|--------------------------------------------------------------------------|
| market    | 広告が提供された市場の ISO 3166 国コードを含む文字列です。 |
| deviceType    | 次のいずれかの文字列です。<strong>PC やタブレット</strong>または<strong>Phone</strong>します。 |
| adUnitId    | フィルターに適用する広告ユニット ID を指定する文字列です。 |
| pubCenterAppName    | フィルターに適用する、現在のアプリの pubCenter 名を指定する文字列です。 |
| adProvider    | フィルターに適用する広告プロバイダー名を指定する文字列です。 |
| date    | フィルターに適用する YYYY/MM/DD 形式の日付を指定する文字列です。 |


### <a name="request-example"></a>要求の例

広告のパフォーマンス データを取得するための要求の例を、いくつか次に示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/adsperformance?applicationId=9NBLGGH4R315&startDate=1/1/2015&endDate=2/1/2015&top=10&skip=0  HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/adsperformance?applicationId=9NBLGGH4R315&startDate=8/1/2015&endDate=8/31/2015&skip=0&$filter=market eq 'US' and deviceType eq 'phone’ eq 'US'; and gender eq 'm'  HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| Value      | 種類   | 説明                                                                                                                                                                                                                                                                            |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Value      | array  | 広告のパフォーマンスに関する集計データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[広告のパフォーマンスの値](#ad-performance-values)」セクションをご覧ください。                                                                                                                      |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 5 に設定されたが、クエリに対するデータに 5 個を超える項目が含まれている場合に、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。                          |


### <a name="ad-performance-values"></a>広告のパフォーマンスの値

*Value* 配列の要素には、次の値が含まれます。

| Value               | 種類   | 説明                                                                                                                                                                                                                              |
|---------------------|--------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| date                | string | 広告のパフォーマンス データの対象となる日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId       | string | 広告のパフォーマンス データを取得するアプリのストア ID です。     |
| applicationName     | string | アプリの表示名です。                         |
| adUnitId           | string | 広告ユニットの ID です。        |
| adUnitName           | string | パートナー センターの開発者によって指定された、ad ユニットの名前。              |
| adProvider           |  string  |  広告プロバイダーの名前です。   |
| deviceType          | string | 広告が提供されたデバイスの種類です。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                              |
| market              | string | 広告が提供された市場の ISO 3166 国コードです。             |
| accountCurrencyCode     | string | アカウントの通貨コードです。        |
| pubCenterAppName       |  string  |   パートナー センターでアプリに関連付けられている pubCenter アプリの名前。   |
| adProviderRequests        | int | 指定した広告プロバイダーに対する広告要求の数です。                 |
| impressions           | int | 広告インプレッションの数です。        |
| clicks            | int | クリックの数です。       |
| revenueInAccountCurrency       | number | アカウントの国/地域の通貨に基づく収益です。       |
| requests              | int | 広告要求の数です。                 |


### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2015-03-09",
      "applicationId": "9NBLGGH4R315",
      "applicationName": "Contoso Demo",
      "market": "US",
      "deviceType": "phone",
      "adUnitId":"10765920",
      "adUnitName":"TestAdUnit",
      "revenueInAccountCurrency": 10.0,
      "impressions": 1000,
      "requests": 10000,
      "clicks": 1,
      "accountCurrencyCode":"USD"
    },
    {
      "date": "2015-03-09",
      "applicationId": "9NBLGGH4R315",
      "applicationName": "Contoso Demo",
      "market": "US",
      "deviceType": "phone",
      "adUnitId":"10795110",
      "adUnitName":"TestAdUnit2",
      "revenueInAccountCurrency": 20.0,
      "impressions": 2000,
      "requests": 20000,
      "clicks": 3,
      "accountCurrencyCode":"USD"
    },
  ],
  "@nextLink": "adsperformance?applicationId=9NBLGGH4R315&aggregationLevel=week&startDate=2015/03/01&endDate=2016/02/01&top=2&skip=2",
  "TotalCount": 191753
}

```

## <a name="related-topics"></a>関連トピック

* [広告パフォーマンス レポート](../publish/advertising-performance-report.md)
* [Microsoft Store サービスを使用して分析データにアクセス](access-analytics-data-using-windows-store-services.md)
