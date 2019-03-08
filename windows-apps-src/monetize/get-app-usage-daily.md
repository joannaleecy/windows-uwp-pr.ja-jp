---
ms.assetid: 99DB5622-3700-4FB2-803B-DA447A1FD7B7
description: Microsoft Store analytics API でこのメソッドを使用して、特定の日付範囲とその他のオプションのフィルターの毎日のアプリ使用状況データを取得します。
title: アプリの使用状況 (日単位) の取得
ms.date: 08/15/2018
ms.topic: article
keywords: windows 10、uwp、Store services、Microsoft Store analytics API では、使用状況
ms.localizationpriority: medium
ms.openlocfilehash: d3460b61e6a9a7c36be6fd87c4dc7fcc1ab811d1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613107"
---
# <a name="get-daily-app-usage"></a>アプリの使用状況 (日単位) の取得

Microsoft Store analytics API でこのメソッドを使用して、JSON 形式で指定した日付範囲 (過去 90 日間のみ) とその他のオプションのフィルターの中にアプリケーションの総使用量のデータ (Xbox マルチプレイヤーを含まない) を取得します。 この情報も記載されて、[使用状況レポート](../publish/usage-report.md)パートナー センターでします。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求

### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                               |
|--------|---------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/usagedaily``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター     | 種類   |  説明                                                                                                    |  必須  |
|---------------|--------|-----------------------------------------------------------------------------------------------------------------|------------|
| applicationId | string | レビュー データを取得するアプリの [Store ID](in-app-purchases-and-trials.md#store-ids) です。 |  〇       |
| startDate     | date   | 取得するレビュー データの日付範囲の開始日です。 既定値は現在の日付です。                   |  X        |
| endDate       | date   | 取得するレビュー データの日付範囲の終了日です。 既定値は現在の日付です。                     |  X        |
| top           | int    | 要求で返すデータの行数です。 最大値および指定しない場合の既定値は 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。                          |  X        |
| skip          | int    | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。                         |  X        |  
| filter        |string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文と、eq、ne または演算子に関連付けられている値からフィールド名が含まれていますとを使用してステートメントを組み合わせることができますとまたはまたはします。 文字列の値は、フィルター パラメーターで単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。 <ul><li>**market**</li><li>**deviceType**</li><li>**packageVersion**</li></ul>                                                                                                                                              | X         |  
| orderby       | string | 結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターには、次のいずれかの文字列を指定できます。<ul><li>**date**</li><li>**applicationId**</li><li>**applicationName**</li><li>**market**</li><li>**packageVersion**</li><li>**deviceType**</li><li>**subscriptionName**</li><li>**dailySessionCount**</li><li>**engagementDurationMinutes**</li><li>**dailyActiveUsers**</li><li>**dailyActiveDevices**</li><li>**DailyNewUsers**</li><li>**monthlyActiveUsers**</li><li>**monthlyActiveDevices**</li><li>**monthlyNewUsers**</li></ul><p><em>order</em> パラメーターは省略可能であり、**asc** または **desc** を指定して、各フィールドを昇順または降順にすることができます。 既定値は **asc** です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p>                                                                                                   |  X        |
| groupby       | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 応答本文から次のフィールドを指定することができます。 <ul><li>**applicationName**</li><li>**subscriptionName**</li><li>**deviceType**</li><li>**packageVersion**</li><li>**market**</li><li>**date**</li></ul><p>返されるデータ行には、<em>groupby</em> パラメーターに指定したフィールドと次の値が含まれます。</p><ul><li>**applicationId**</li><li>**subscriptionName**</li><li>**dailySessionCount**</li><li>**engagementDurationMinutes**</li><li>**dailyActiveUsers**</li><li>**dailyActiveDevices**</li><li>**DailyNewUsers**</li><li>**monthlyActiveUsers**</li><li>**monthlyActiveDevices**</li><li>**monthlyNewUsers**</li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em>&amp;groupby=ageGroup,market&amp;aggregationLevel=week</em></p>                                                                                                             |  X        |


### <a name="request-example"></a>要求の例

次の例では、毎日のアプリ使用状況データを取得するための要求を示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```http
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/usagedaily?applicationId=XXXXXXXXXXXX&startDate=2018-08-10&endDate=2018-08-14 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答



### <a name="response-body"></a>応答本文

| Value      | 種類   | 説明                                                                                                                         |
|------------|--------|-------------------------------------------------------------------------------------------------------------------------------------|
| Value      | array  | 総使用量データを格納するオブジェクトの配列。 各オブジェクトのデータの詳細については、以下の表を参照してください。 |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターを 10000 に設定した場合、クエリに適合するレビュー データが 10,000 行を超えると、この値が返されます。                 |
| TotalCount | int    | クエリの結果データ内の行の総数です。                                                                          |

 
### <a name="usage-values"></a>使用量の値

*Value* 配列の要素には、次の値が含まれます。

| Value                     | 種類    | 説明                                                               |
|---------------------------|---------|---------------------------------------------------------------------------|
| date                      | string  | 使用状況データの日付範囲の最初の日付。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。        |
| applicationId             | string  | 使用状況データを取得するアプリの Store ID。          |
| applicationName           | string  | アプリの表示名です。                                              |
| deviceType                | string  | 次の文字列のいずれかを指定する使用状況が発生したデバイスの種類。<ul><li>**PC**</li><li>**Phone**</li><li>**Console**</li><li>**タブレット**</li><li>**IoT**</li><li>**サーバー**</li><li>**Holographic**</li><li>**Unknown**</li></ul>                                                                                                         |
| packageVersion            | string  | 使用状況が発生したパッケージのバージョン。                          |
| market                    | string  | 顧客がアプリを使用する市場の ISO 3166 国コード。 |
| subscriptionName          | string  | 使用状況を通じて、Xbox Game Pass かどうかを示しています。                            |
| dailySessionCount         | long    | その日にユーザー セッションの数。                                  |
| engagementDurationMinutes | double  | ユーザーが積極的にアプリの起動時に開始時間の個別の期間で計測されたアプリ (プロセスの起動) を使用してと終了 (プロセスの終了) を終了するとき、または一定の期間後に、分。             |
| dailyActiveUsers          | long    | その日に、アプリを使用しているユーザーの数。                           |
| dailyActiveDevices        | long    | すべてのユーザーがアプリと対話に使用される 1 日のデバイスの数。  |
| dailyNewUsers             | long    | その日の初めてのアプリを使用したお客様の数。    |
| monthlyActiveUsers        | long    | その月に、アプリを使用しているユーザーの数。                         |
| monthlyActiveDevices      | long    | または一定の期間後に異なる一定期間、アプリの起動時に開始 (プロセスの起動)、アプリを実行しているアドレスと終了 (プロセスの終了)、終了時にデバイスの数。                                      |
| monthlyNewUsers           | long    | その月の初めてのアプリを使用したお客様の数。  |


### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

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

* [Microsoft Store サービスを使用して分析データにアクセス](access-analytics-data-using-windows-store-services.md)
* [アプリの月次 ussage を取得します。](get-app-usage-monthly.md)
* [アプリの取得数を取得します。](get-app-acquisitions.md)
* [アドオンの取得数を取得します。](get-in-app-acquisitions.md)
* [エラー報告データを取得します。](get-error-reporting-data.md)
