---
author: mcleanbyron
ms.assetid: A26A287C-B4B0-49E9-BB28-6F02472AE1BA
description: "特定の日付範囲などのオプション フィルターを使って、指定したアプリケーションの広告キャンペーンのパフォーマンスに関する集計データを取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。"
title: "広告キャンペーンのパフォーマンス データの取得"
translationtype: Human Translation
ms.sourcegitcommit: 67845c76448ed13fd458cb3ee9eb2b75430faade
ms.openlocfilehash: 8859658675d31deccc3403e4862c47a54ca25b1a

---

# 広告キャンペーンのパフォーマンス データの取得


特定の日付範囲などのオプション フィルターを使って、アプリケーションに関する広告キャンペーンのパフォーマンス データの集計サマリーを取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。 このメソッドは、データを JSON 形式で返します。

このメソッドは、Windows デベロッパー センター ダッシュボードの[アプリのインストールの広告レポート](../publish/app-install-ads-reports.md)で提供されるデータと同じデータを返します。 広告キャンペーンについて詳しくは、「[アプリ向けの広告キャンペーンの作成](https://msdn.microsoft.com/windows/uwp/publish/create-an-ad-campaign-for-your-app)」をご覧ください。

お客様のデベロッパー センター アカウントで作成されたすべての広告キャンペーンに関する完全な詳細情報を取得するには、この記事の後半に記載されている「[すべての広告キャンペーンの詳細を取得する](#get-details-for-all-ad-campaigns)」をご覧ください。

## 前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## 要求


### 要求の構文

| メソッド | 要求 URI                                                              |
|--------|--------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/promotion``` |

<span />

### 要求ヘッダー

| ヘッダー        | 型   | 説明                |
|---------------|--------|---------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span />

### 要求パラメーター

特定のアプリに関する広告キャンペーンのパフォーマンス データを取得するには、*applicationId* パラメーターを使用します。 開発者アカウントに関連付けられているすべてのアプリに関する広告パフォーマンス データを取得するには、*applicationId* パラメーターは省略します。

| パラメーター     | 型   | 説明     | 必須かどうか |
|---------------|--------|-----------------|----------|
| applicationId   | string    | 広告キャンペーンのパフォーマンス データを取得するアプリのストア ID です。 ストア ID は、デベロッパー センター ダッシュボードの[アプリ ID ページ](../publish/view-app-identity-details.md)で確認できます。 ストア ID の例は 9NBLGGH4R315 です。 |    必須ではない      |
|  startDate  |  date   |  広告キャンペーンのパフォーマンス データを取得する日付範囲の開始日です。YYYY/MM/DD の形式で指定します。 既定値は、現在の日付から 30 日を差し引いた日付になります。   |   必須ではない    |
| endDate   |  date   |  広告キャンペーンのパフォーマンス データを取得する日付範囲の終了日です。YYYY/MM/DD の形式で指定します。 既定値は、現在の日付から 1 日を差し引いた日付になります。   |   必須ではない    |
| top   |  int   |  要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。   |   ×    |
| skip   | int    |  クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。   |   ×    |
| filter   |  string   |  応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 サポートされているフィルターは **campaignId** のみです。 各ステートメントでは **eq** や **ne** 演算子を使用できます。また、ステートメントを **and** や **or** で結合することもできます。  *filter* パラメーターの例: ```filter=campaignId eq '100023'```。   |   必須ではない    |
|  aggregationLevel  |  string   | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定されていない場合、既定値は <strong>day</strong> です。    |   ×    |
| orderby   |  string   |  <p>広告キャンペーンのパフォーマンス データに関する結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。 <em>field</em> パラメーターには、次のいずれかの文字列を指定できます。</p><ul><li><strong>date</strong></li><li><strong>campaignId</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,campaignId</em></p>   |   必須ではない    |
|  groupby  |  string   |  <p>データ集計を指定したフィールドのみに適用するステートメントです。 次のフィールドを指定できます。</p><ul><li><strong>campaignId</strong></li><li><strong>applicationId</strong></li><li><strong>date</strong></li><li><strong>currencyCode</strong></li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em>&amp;groupby=applicationId&amp;aggregationLevel=week</em></p>   |   必須ではない    |


<span />
 

### 要求の例

広告キャンペーンのパフォーマンス データを取得するための要求の例を、いくつか次に示します。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/promotion?aggregationLevel=week&groupby=applicationId,campaignId,date  HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/promotion?applicationId=9NBLGGH0XK8Z&startDate=2015/1/20&endDate=2016/8/31&skip=0&filter=campaignId eq '31007388' HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答


### 応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                            |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Value      | array  | 広告キャンペーンのパフォーマンスに関する集計データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[キャンペーンのパフォーマンス オブジェクト](#campaign-performance-object)」セクションをご覧ください。                                                                                                                      |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 5 に設定されたが、クエリに対するデータに 5 個を超える項目が含まれている場合に、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。                                                                                                                                                                                                                             |

<span id="campaign-performance-object" />
### キャンペーンのパフォーマンス オブジェクト

*Value* 配列の要素には、次の値が含まれます。

| 値               | 型   | 説明            |
|---------------------|--------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| date                | string | 広告キャンペーンのパフォーマンス データの対象となる日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId       | string | 広告キャンペーンのパフォーマンス データを取得するアプリのストア ID です。                     |
| campaignId     | string | 広告キャンペーンの ID です。           |
| currencyCode              | string | キャンペーン予算の通貨コードです。              |
| spend          | string |  広告キャンペーンで消費した予算金額です。     |
| impressions           | long | キャンペーンの広告インプレッションの数です。        |
| installs              | long | キャンペーンに関連するアプリのインストールの数です。   |
| clicks            | long | キャンペーンの広告クリックの数です。      |

<span />

### 応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2015-04-12",
      "applicationId": "9WZDNCRFJ31Q",
      "campaignId": "4568",
      "currencyCode": "USD",
      "spend": 700.6,
      "impressions": 200,
      "installs": 30,
      "clicks": 8
    },
    {
      "date": "2015-05-12",
      "applicationId": "9WZDNCRFJ31Q",
      "campaignId": "1234",
      "currencyCode": "USD",
      "spend": 325.3,
      "impressions": 20,
      "installs": 2,
      "clicks": 5
    }
  ],
  "@nextLink": "promotion?applicationId=9NBLGGGZ5QDR&aggregationLevel=day& startDate=2015/1/20&endDate=2016/8/31&top=2&skip=2",
  "TotalCount": 1917
}
```

<span id="get-details-for-all-ad-campaigns" />
## すべての広告キャンペーンの詳細情報を取得する


Windows デベロッパー センターアカウントに登録されているアプリ用に作成されたすべての広告キャンペーンの詳細情報を取得するには、以下のメソッドを使用します。 このメソッドは、データを JSON 形式で返します。 広告キャンペーンについて詳しくは、「[アプリ向けの広告キャンペーンの作成](https://msdn.microsoft.com/windows/uwp/publish/create-an-ad-campaign-for-your-app)」をご覧ください。

### 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

### 要求


#### 要求の構文

| メソッド | 要求 URI                                                              |
|--------|--------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/adscampaign``` |

<span />

#### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span />

#### 要求パラメーター

| パラメーター     | 型   | 説明     | 必須かどうか |
|---------------|--------|-----------------|----------|
| top           | int    | 要求で返すデータの行数です。 最大値、および指定されない場合の既定値は、1000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |    ×      |
| skip           | int    | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=100 と skip=0 を指定すると、データの最初の 100 行が取得され、top=100 と skip=100 を指定すると、データの次の 100 行が取得されます。 |    必須ではない      |


<span />
 

#### 要求の例

すべての広告キャンペーンの詳細情報を取得するための要求の例を、いくつか次に示します。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/adscampaign?top=10&skip=0  HTTP/1.1
Authorization: Bearer <your access token>
```

### 応答


#### 応答本文

| 値      | 型   | 説明  |
|------------|--------|--------------|
| Value      | array  | 広告キャンペーンの詳細情報が含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[キャンペーン オブジェクト](#campaign-object)」セクションをご覧ください。                        |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 5 に設定されたが、クエリに対するデータに 5 個を超える項目が含まれている場合に、この値が返されます。 |                                   |

<span id="campaign-object" />
#### キャンペーン オブジェクト

*Value* 配列の要素には、次の値が含まれます。

| 値               | 型   | 説明          |
|---------------------|--------|------------------|
| id     | string | 広告キャンペーンの ID です。 |
| name     | string | 広告キャンペーンの名前です。 |
| createDate     | string | 広告キャンペーンが作成された日付です。UTC タイム ゾーンで表されます。 |
| startDate     | string | 広告キャンペーンの開始日です。UTC タイム ゾーンで表されます。 |
| endDate     | string | 広告キャンペーンの終了日です。UTC タイム ゾーンで表されます。 |
| applicationId       | string | 広告キャンペーンが関連付けられているアプリのストア ID です。 ストア ID は、デベロッパー センター ダッシュボードの[アプリ ID ページ](../publish/view-app-identity-details.md)で確認できます。 ストア ID の例は 9NBLGGH4R315 です。                    |
| budget     | number | 広告キャンペーンの予算です。           |
| budgetType    | string | 広告キャンペーンの予算の種類です。 これは、**Monthly** または **Total** のどちらかの文字列になります。           |
| currencyCode              | string | キャンペーン予算の通貨コードです。              |
| type              | string | 広告キャンペーンの種類です。 これは、**Paid**、**House**、または **Community** のいずれかの文字列になります。             |
| status              | string | 広告キャンペーンの状態です。 これは、**Active**、**UserPaused**、**Pending**、**Ended**、または **SystemPaused** のいずれかの文字列 になります。             |
| targetingType              | string | 広告キャンペーンのターゲット設定の種類です。 これは、**Auto**、**Manual**、または **Segment** のいずれかの文字列 になります。             |
| target              | dictionary | キャンペーンのターゲット情報を含むキーと値のペアのディクショナリです。 このオブジェクトについて詳しくは、次の「[ターゲット オブジェクト](#target-object)」セクションをご覧ください。             |

<span />

<span id="target-object" />
#### ターゲット オブジェクト

このリソースは、次のキーと値のペアのディクショナリです。

| キー               | 型   | 値          |
|---------------------|--------|------------------|
| Country     | array |   広告キャンペーンの対象となる国や地域に関する ISO 3166 alpha-2 コードを含む文字列が 1 つまたは複数使用されます。 |
| OsVersion     | array | 広告キャンペーンの対象となる OS のバージョンを指定する文字列 (**10** または **8.x**) が 1 つまたは複数使用されます。  |
| Age     |  array |  対象年齢の範囲を指定する文字列 (**Age13To17**、**Age18To24**、**Age25To34**、**Age35To49**、**Age50AndAbove**) が 1 つまたは複数使用されます。 |
| Gender     |  array |  対象となる性別を指定する文字列 (**Female** または **Male**) が 1 つまたは複数使用されます。 |
| DeviceType       |  array  |  対象となるデバイスの種類を指定する文字列 (**PC/Tablet** または **Phone**) が 1 つまたは複数使用されます。                  |
| Segment     |  array |    対象となる顧客セグメントの ID を含む文字列が 1 つまたは複数使用されます。       |


<span />

#### 応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
   "Value": [
      {
         "id":31010026,
         "name": "Contoso App 1 Campaign",
         "createDate":"2016-07-14T10:01:21Z",
         "startDate":"2016-07-21T11:23:36Z",
         "applicationId":"9NBLGGH0XK8Z",
         "budget": 100,
         "budgetType":"Monthly",
         "currencyCode": "USD",
         "type": "Paid",
         "status": "Active",
         "targetingType": "Auto",
         "target": null
      },
      {
         "id":31010025,
         "name":"Contoso App 2 Campaign",
         "createDate":"2016-07-14T10:02:21Z",
         "startDate":"2016-07-21T11:18:44Z",
         "endDate":"2016-08-21T11:18:44Z",
         "applicationId":"9WZDNCRDX48S",
         "budget": 50,
         "budgetType":"Total",
         "currencyCode": "USD",
         "type": "Paid",
         "status": "Ended",
         "targetingType": "Manual",
         "target": {
            "Country": [
               "US",
               "BR",
               "FR",
               "IN",
               "IT"
            ],
            "OsVersion": [
               "8.X"
            ],
            "Age": [
               "Age18To24",
               "Age25To34",
               "Age35To49",
               "Age50AndAbove"
            ],
            "Gender": [
               "Male"
            ],
            "DeviceType": [
               "PC/Tablet",
               "Phone"
            ]
         }
      }
   ]
}
```

## 関連トピック

* [アプリのインストールの広告レポート](../publish/app-install-ads-reports.md)
* [アプリ向けの広告キャンペーンの作成](https://msdn.microsoft.com/windows/uwp/publish/create-an-ad-campaign-for-your-app)
* [Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)



<!--HONumber=Nov16_HO1-->


