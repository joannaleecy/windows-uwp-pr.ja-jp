---
author: Xansky
ms.assetid: 99DB5622-3700-4FB2-803B-DA447A1FD7B7
description: 1 日あたりのアプリの使用状況データを取得する特定の日付範囲やその他のオプション フィルターを Microsoft Store 分析 API でこのメソッドを使います。
title: アプリの使用状況 (日単位) の取得
ms.author: mhopkins
ms.date: 08/15/2018
ms.topic: article
keywords: windows 10, uwp, Store サービス, Microsoft Store 分析 API, 使用状況
ms.localizationpriority: medium
ms.openlocfilehash: 5d533f0e28161e17c3a842f6c3c4c6b6ef4a196d
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5888961"
---
# <a name="get-daily-app-usage"></a>アプリの使用状況 (日単位) の取得

(過去 90 日間のみ) 特定の日付範囲やその他のオプション フィルターを使って、アプリケーションに関する JSON 形式で (Xbox のマルチプレイヤーは含まない) 集計の使用状況データを取得するのに、Microsoft Store 分析 api の以下のメソッドを使用します。 この情報も[使用状況] レポート](../publish/usage-report.md)では、Windows デベロッパー センター ダッシュ ボードで使用できます。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求

### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                               |
|--------|---------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/usagedaily``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター     | 型   |  説明                                                                                                    |  必須かどうか  |
|---------------|--------|-----------------------------------------------------------------------------------------------------------------|------------|
| applicationId | string | レビュー データを取得するアプリの [Store ID](in-app-purchases-and-trials.md#store-ids) です。 |  必須       |
| startDate     | date   | 取得するレビュー データの日付範囲の開始日です。 既定値は現在の日付です。                   |  必須ではない        |
| endDate       | date   | 取得するレビュー データの日付範囲の終了日です。 既定値は現在の日付です。                     |  必須ではない        |
| top           | int    | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。                          |  必須ではない        |
| skip          | int    | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。                         |  必須ではない        |  
| filter        |string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および eq 演算子または ne 演算子と関連付けられる値が含まれており、and や or を使用してステートメントを組み合わせることができます。 filter パラメーターでは、文字列値を単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。 <ul><li>**market**</li><li>**deviceType**</li><li>**packageVersion**</li></ul>                                                                                                                                              | 必須ではない         |  
| orderby       | string | 結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターは次のいずれかの文字列になります。<ul><li>**date**</li><li>**applicationId**</li><li>**applicationName**</li><li>**market**</li><li>**packageVersion**</li><li>**deviceType**</li><li>**subscriptionName**</li><li>**dailySessionCount**</li><li>**engagementDurationMinutes**</li><li>**dailyActiveUsers**</li><li>**dailyActiveDevices**</li><li>**dailyNewUsers**</li><li>**monthlyActiveUsers**</li><li>**monthlyActiveDevices**</li><li>**monthlyNewUsers**</li></ul><p><em>order</em> パラメーターは省略可能であり、**asc** または **desc** を指定して、各フィールドを昇順または降順にすることができます。 既定値は **asc** です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p>                                                                                                   |  必須ではない        |
| groupby       | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 応答本文から次のフィールドを指定することができます。 <ul><li>**applicationName**</li><li>**subscriptionName**</li><li>**deviceType**</li><li>**packageVersion**</li><li>**market**</li><li>**date**</li></ul><p>返されるデータ行には、<em>groupby</em> パラメーターに指定したフィールドと次の値が含まれます。</p><ul><li>**applicationId**</li><li>**subscriptionName**</li><li>**dailySessionCount**</li><li>**engagementDurationMinutes**</li><li>**dailyActiveUsers**</li><li>**dailyActiveDevices**</li><li>**dailyNewUsers**</li><li>**monthlyActiveUsers**</li><li>**monthlyActiveDevices**</li><li>**monthlyNewUsers**</li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em>&amp;groupby=ageGroup,market&amp;aggregationLevel=week</em></p>                                                                                                             |  必須ではない        |


### <a name="request-example"></a>要求の例

次の例では、1 日あたりのアプリの使用状況データを取得する要求を示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```http
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/usagedaily?applicationId=XXXXXXXXXXXX&startDate=2018-08-10&endDate=2018-08-14 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答



### <a name="response-body"></a>応答本文

| 値      | 型   | 説明                                                                                                                         |
|------------|--------|-------------------------------------------------------------------------------------------------------------------------------------|
| Value      | array  | 集計の使用状況データが含まれるオブジェクトの配列です。 各オブジェクトのデータの詳細については、以下の表を参照してください。 |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターを 10000 に設定した場合、クエリに適合するレビュー データが 10,000 行を超えると、この値が返されます。                 |
| TotalCount | int    | クエリの結果データ内の行の総数です。                                                                          |

 
### <a name="usage-values"></a>使用率の値

*Value* 配列の要素には、次の値が含まれます。

| 値                     | 型    | 説明                                                               |
|---------------------------|---------|---------------------------------------------------------------------------|
| date                      | string  | 使用状況データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。        |
| applicationId             | string  | 使用状況データを取得するアプリのストア ID です。          |
| applicationName           | string  | アプリの表示名です。                                              |
| deviceType                | string  | 次の文字列のいずれかを指定する、使用状況が発生したデバイスの種類。<ul><li>**PC**</li><li>**Phone**</li><li>**Console**</li><li>**Tablet**</li><li>**IoT**</li><li>**Server**</li><li>**Holographic**</li><li>**Unknown**</li></ul>                                                                                                         |
| packageVersion            | string  | 使用状況が発生したパッケージのバージョン。                          |
| market                    | string  | 顧客にアプリが使用されている市場の ISO 3166 国コードです。 |
| subscriptionName          | string  | Xbox Game Pass を通じて使用量があったかどうかを示します。                            |
| dailySessionCount         | long    | その日上のユーザー セッションの数。                                  |
| engagementDurationMinutes | double  | ユーザーが積極的に個別のアプリを起動したときに始まり、時間の期間で測定されたアプリ (プロセスが開始) を使用して終了 (プロセスの終了) または後に一定の期間の終了位置分。             |
| dailyActiveUsers          | long    | その日にアプリを使用しているユーザーの数。                           |
| dailyActiveDevices        | long    | すべてのユーザーがアプリを操作するために使用 1 日あたりのデバイスの数。  |
| dailyNewUsers             | long    | 最初にその日にアプリを使用したユーザーの数。    |
| monthlyActiveUsers        | long    | アプリをその月を使っているユーザーの数。                         |
| monthlyActiveDevices      | long    | または一定の期間後にデバイスを個別の期間、アプリを起動したときに始まり (プロセスが開始) のアプリを実行していると、終了 (プロセスの終了) したときに終了の数です。                                      |
| monthlyNewUsers           | long    | その月を初めてアプリを使用したユーザーの数。  |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2018-08-10",
      "applicationId": "XXXXXXXXXXXX",
      "applicationName": "My App",
      "market": "All",
      "packageVersion": "All",
      "deviceType": "All",
      "subscriptionName": "All",
      "dailySessionCount": 17718,
      "engagementDurationMinutes": 582540.2,
      "dailyActiveUsers": 7078,
      "dailyActiveDevices": 6964,
      "dailyNewUsers": 1727,
      "monthlyActiveUsers": 123609,
      "monthlyActiveDevices": 116723,
      "monthlyNewUsers": 72271
    },
    {
      "date": "2018-08-11",
      "applicationId": "XXXXXXXXXXXX",
      "applicationName": "My App",
      "market": "All",
      "packageVersion": "All",
      "deviceType": "All",
      "subscriptionName": "All",
      "dailySessionCount": 19899,
      "engagementDurationMinutes": 655379.7,
      "dailyActiveUsers": 7877,
      "dailyActiveDevices": 7789,
      "dailyNewUsers": 2062,
      "monthlyActiveUsers": 123666,
      "monthlyActiveDevices": 116770,
      "monthlyNewUsers": 72276
    },
    {
      "date": "2018-08-12",
      "applicationId": "XXXXXXXXXXXX",
      "applicationName": "My App",
      "market": "All",
      "packageVersion": "All",
      "deviceType": "All",
      "subscriptionName": "All",
      "dailySessionCount": 21349,
      "engagementDurationMinutes": 735640.5,
      "dailyActiveUsers": 8456,
      "dailyActiveDevices": 8309,
      "dailyNewUsers": 2433,
      "monthlyActiveUsers": 124241,
      "monthlyActiveDevices": 117289,
      "monthlyNewUsers": 72732
    }
  ],
  "@nextLink": null,
  "TotalCount": 3
}
```

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [毎月アプリ ussage を取得します。](get-app-usage-monthly.md)
* [アプリの入手数の取得](get-app-acquisitions.md)
* [アドオンの入手数の取得](get-in-app-acquisitions.md)
* [エラー報告データの取得](get-error-reporting-data.md)
