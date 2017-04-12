---
author: mcleanbyron
ms.assetid: f0c0325e-ad61-4238-a096-c37802db3d3b
description: "アプリの特定のエラーに関する詳細データを取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。"
title: "アプリのエラーに関する詳細情報の取得"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス, Windows ストア分析 API, エラー, 詳細"
ms.openlocfilehash: cfab1c8f5149d4c6d02a9fa94287a4e204a11a7f
ms.sourcegitcommit: 64cfb79fd27b09d49df99e8c9c46792c884593a7
translationtype: HT
---
# <a name="get-details-for-an-error-in-your-app"></a>アプリのエラーに関する詳細情報の取得

アプリの特定のエラーに関する JSON 形式の詳細データを取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。 このメソッドで取得できるのは、過去 30 日以内に発生したエラーの詳細のみです。 詳細なエラー データは、Windows デベロッパー センター ダッシュボードの[状態レポート](../publish/health-report.md)の **[エラー]** セクションで確認することもできます。

このメソッドを使うには、その前にまず「[エラー報告データの取得](get-error-reporting-data.md)」のメソッドを使って、詳細情報を取得するエラーの ID を取得する必要があります。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* 詳細情報を取得するエラーの ID を取得します。 この ID を取得するには、「[エラー報告データの取得](get-error-reporting-data.md)」のメソッドを使い、そのメソッドの応答本文で **failureHash** の値を使います。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/failuredetails``` |

<span/> 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/> 

### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | 詳細なエラー データを取得するアプリのストア ID です。 ストア ID は、デベロッパー センター ダッシュボードの[アプリ ID ページ](../publish/view-app-identity-details.md)で確認できます。 ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。 |  必須  |
| failureHash | string | 取得する詳細情報の対象となるエラーの一意の ID です。 目的のエラーについてこの ID を取得するには、「[エラー報告データの取得](get-error-reporting-data.md)」のメソッドを使い、そのメソッドの応答本文で **failureHash** の値を使います。 |  必須  |
| startDate | date | 取得する詳細なエラー データの日付範囲の開始日です。 既定値は、現在の日付の 30 日前です。 |  必須ではない  |
| endDate | date | 取得する詳細なエラー データの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10 と skip=0 を指定すると、データの最初の 10 行が取得され、top=10 と skip=10 を指定すると、データの次の 10 行が取得されます。 |  必須ではない  |
| filter |string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 詳しくは、次の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。 | 必須ではない   |
| orderby | string | 結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。 <em>field</em> パラメーターには、次のいずれかの文字列を指定できます。<ul><li><strong>date</strong></li><li><strong>market</strong></li><li><strong>cabId</strong></li><li><strong>cabExpirationTime</strong></li><li><strong>deviceType</strong></li><li><strong>deviceModel</strong></li><li><strong>osVersion</strong></li><li><strong>packageVersion</strong></li><li><strong>osBuild</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  必須ではない  |

<span/>
 
### <a name="filter-fields"></a>フィルター フィールド

要求の *filter* パラメーターには、応答内の行をフィルター処理する 1 つまたは複数のステートメントが含まれます。 各ステートメントには **eq** 演算子または **ne** 演算子と関連付けられるフィールドと値が含まれ、**and** または **or** を使ってステートメントを組み合わせることができます。 *filter* パラメーターの例を次に示します。

-   *filter=market eq 'US' and osVersion eq 'Windows 10'*
-   *filter=market ne 'US' and osVersion ne 'Windows 8'*

サポートされているフィールドの一覧については、次の表をご覧ください。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。

| フィールド        |  説明        |
|---------------|-----------------|
| osVersion | 次のいずれかの文字列です。<ul><li><strong>Windows Phone 7.5</strong></li><li><strong>Windows Phone 8</strong></li><li><strong>Windows Phone 8.1</strong></li><li><strong>Windows Phone 10</strong></li><li><strong>Windows 8</strong></li><li><strong>Windows 8.1</strong></li><li><strong>Windows 10</strong></li><li><strong>Unknown</strong></li></ul> |
| osBuild | エラーが発生したときにアプリを実行していた OS のビルド番号です。 |
| market | エラーが発生したときにアプリを実行していたデバイスの市場の ISO 3166 国コードが含まれた文字列です。 |
| deviceType | エラーが発生したときにアプリを実行していたデバイスの種類を指定する、以下のいずれかの文字列です。<ul><li><strong>PC</strong></li><li><strong>Phone</strong></li><li><strong>Console</strong></li><li><strong>IoT</strong></li><li><strong>Holographic</strong></li><li><strong>Unknown</strong></li></ul> |
| deviceModel | エラーが発生したときにアプリを実行していたデバイスのモデルを指定する文字列です。 |
| cabId | このエラーに関連付けられている CAB ファイルの一意の ID です。 |
| cabExpirationTime | CAB ファイルの有効期限が切れ、ダウンロードできなくなる日付と時刻 (ISO 8601形式) です。 |
| packageVersion | このエラーに関連付けられているアプリ パッケージのバージョンです。 |

<span/> 

### <a name="request-example"></a>要求の例

詳細なエラー データを取得するための要求の例を次に示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/failuredetails?applicationId=9NBLGGGZ5QDR&failureHash=012e33e3-dbc9-b12f-c124-9d9810f05d8b&startDate=2016-11-05&endDate=2016-11-06&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/failuredetails?applicationId=9NBLGGGZ5QDR&failureHash=012e33e3-dbc9-b12f-c124-9d9810f05d8b&startDate=2016-11-05&endDate=2016-11-06&top=10&skip=0&filter=market eq 'US' and deviceType eq 'Windows.Desktop' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型    | 説明    |
|------------|---------|------------|
| Value      | array   | 詳細なエラー データが含まれているオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[エラーの詳細情報の値](#error-detail-values)」セクションをご覧ください。          |
| @nextLink  | string  | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。 |
| TotalCount | inumber | クエリの結果データ内の行の総数です。        |

<span id="error-detail-values"/>
### <a name="error-detail-values"></a>エラーの詳細情報の値

*Value* 配列の要素には、次の値が含まれます。

| 値           | 型    | 説明     |
|-----------------|---------|----------------------------|
| date            | string  | エラー データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId   | string  | 詳細なエラー データを取得したアプリのストア ID です。      |
| failureName     | string  | エラーの名前です。 これと同じ名前が、Windows デベロッパー センター ダッシュボードの[状態レポート](../publish/health-report.md)の **[エラー]** セクションにも表示されます。            |
| failureHash     | string  | エラーの一意の識別子です。     |
| osVersion       | string  | エラーが発生した OS のバージョンです。    |
| market          | string  | デバイスの市場の ISO 3166 国コードです。     |
| deviceType      | string  | エラーが発生したデバイスの種類です。     |
| packageVersion  | string  | このエラーに関連付けられているアプリ パッケージのバージョンです。    |
| osBuild         | string  | エラーが発生した OS のビルド番号です。       |
| cabId           | string  | このエラーに関連付けられている CAB ファイルの一意の ID です。   |
| cabExpirationTime  | string  | CAB ファイルの有効期限が切れ、ダウンロードできなくなる日付と時刻 (ISO 8601形式) です。   |
| deviceModel           | string  | エラーが発生したときにアプリを実行していたデバイスのモデルを指定する文字列です。   |
| cabDownloadable           | Boolean  | このユーザーが CAB ファイルをダウンロードできるかどうかを示します。   |

<span/> 

### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "applicationId": "9NBLGGGZ5QDR ",
      "failureHash": "012345-5dbc9-b12f-c124-9d9810f05d8b",
      "failureName": "STOWED_EXCEPTION_System.UriFormatException_exe!ContosoGame.GroupedItems+_ItemView_ItemClick_d__9.MoveNext",
      "date": "2015-02-05 09:11:25",
      "cabId": "133637331323",
      "cabExpirationTime": "2016-12-05 09:11:25",
      "market": "US",
      "osBuild": "10.0.10240",
      "packageVersion": "1.0.2.6",
      "deviceModel": "Contoso Computer",
      "osVersion": "Windows 10",
      "deviceType": "Windows.Desktop",
      "cabDownloadable": false
    }
  ],
  "@nextLink": null,
  "TotalCount": 1
}
```

## <a name="related-topics"></a>関連トピック

* [状態レポート](../publish/health-report.md)
* [Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリのエラーに関するスタック トレースの取得](get-the-stack-trace-for-an-error-in-your-app.md)
